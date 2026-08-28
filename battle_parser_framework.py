"""Reusable parser framework primitives for battle packet decoding.

This module intentionally contains no game-specific packet schemas.
It provides:
- parse statuses and structured parse results,
- a packet descriptor registry skeleton,
- a runtime wrapper that safely parses one packet from a raw TCP buffer.
"""

from __future__ import annotations

from dataclasses import dataclass
from enum import Enum
from typing import Any, Callable


class ParseStatus(str, Enum):
    """Normalized parser outcomes for one parse attempt."""

    OK = "ok"
    NEED_MORE_DATA = "need_more_data"
    UNKNOWN_PACKET = "unknown_packet"
    MALFORMED_PACKET = "malformed_packet"


@dataclass(slots=True)
class ParseResult:
    """Result of a single packet parse attempt."""

    status: ParseStatus
    packet_id: int | None = None
    header_size: int = 0
    bytes_consumed: int = 0
    message: str = ""
    phase: str = "any"
    descriptor_name: str = ""


@dataclass(slots=True)
class PacketDescriptor:
    """Declarative description of one packet contract."""

    packet_id: int
    name: str
    phase: str = "any"
    notes: str = ""
    parser_key: str = ""
    handler_key: str = ""


class PacketRegistry:
    """Simple packet descriptor registry.

    Keeps potentially multiple descriptors per packet id to allow overlap by
    namespace/phase (for example 0x01 in ping vs gameplay namespaces).
    """

    def __init__(self):
        self._by_id: dict[int, list[PacketDescriptor]] = {}

    def register(self, descriptor: PacketDescriptor):
        packet_id = int(descriptor.packet_id)
        bucket = self._by_id.setdefault(packet_id, [])

        # Upsert by (packet_id, phase, name) so explicit framework bindings can
        # replace plain namespace-derived descriptors without duplicating rows.
        for index, existing in enumerate(bucket):
            if existing.phase == descriptor.phase and existing.name == descriptor.name:
                bucket[index] = descriptor
                return

        bucket.append(descriptor)

    def get(self, packet_id: int) -> list[PacketDescriptor]:
        return list(self._by_id.get(int(packet_id), []))

    def has_packet(self, packet_id: int) -> bool:
        return int(packet_id) in self._by_id

    def all_descriptors(self) -> list[PacketDescriptor]:
        out: list[PacketDescriptor] = []
        for descriptors in self._by_id.values():
            out.extend(descriptors)
        return out

    def unique_packet_ids(self) -> set[int]:
        return set(self._by_id.keys())

    def resolve(self, packet_id: int, phase: str = "any") -> PacketDescriptor | None:
        descriptors = self.get(packet_id)
        if not descriptors:
            return None

        if phase and phase != "any":
            for descriptor in descriptors:
                if descriptor.phase == phase:
                    return descriptor

        for descriptor in descriptors:
            if descriptor.phase == "any":
                return descriptor

        return descriptors[0]

    def lint_coverage(self, expected_packet_ids: set[int]) -> tuple[set[int], set[int]]:
        """Return (missing_ids, extra_ids) against expected packet id set."""
        expected = {int(v) for v in expected_packet_ids}
        actual = self.unique_packet_ids()
        return expected - actual, actual - expected

    def lint_phase_requirements(
        self,
        required: dict[int, dict[str, str | None]],
    ) -> list[str]:
        """Validate required phase-to-name mapping for packet ids.

        The input map format is:
            {packet_id: {phase: expected_name_or_none}}
        """
        issues: list[str] = []
        for packet_id, phase_map in required.items():
            descriptors = self.get(packet_id)
            if not descriptors:
                issues.append(f"pkt_id=0x{packet_id:X} missing all descriptors")
                continue

            by_phase: dict[str, list[PacketDescriptor]] = {}
            for descriptor in descriptors:
                by_phase.setdefault(descriptor.phase, []).append(descriptor)

            for phase, expected_name in phase_map.items():
                phase_descriptors = by_phase.get(phase, [])
                if not phase_descriptors:
                    issues.append(
                        f"pkt_id=0x{packet_id:X} missing descriptor for phase={phase}"
                    )
                    continue

                if expected_name and all(d.name != expected_name for d in phase_descriptors):
                    available = ",".join(d.name for d in phase_descriptors)
                    issues.append(
                        f"pkt_id=0x{packet_id:X} phase={phase} expected={expected_name} "
                        f"available={available}"
                    )

        return issues

    def lint_handler_bindings(
        self,
        required_packet_ids: set[int],
        *,
        phase: str = "any",
    ) -> set[int]:
        """Return packet ids missing handler bindings for the requested phase."""
        missing: set[int] = set()
        for packet_id in required_packet_ids:
            descriptor = self.resolve(int(packet_id), phase=phase)
            if descriptor is None or not descriptor.handler_key:
                missing.add(int(packet_id))
        return missing

    def __len__(self) -> int:
        return sum(len(v) for v in self._by_id.values())

    @classmethod
    def from_namespace(
        cls,
        namespace: dict[str, Any],
        name_prefix: str = "PKT_",
    ) -> "PacketRegistry":
        registry = cls()
        for name, value in namespace.items():
            if name.startswith(name_prefix) and isinstance(value, int):
                registry.register(PacketDescriptor(packet_id=value, name=name))
        return registry


class BattlePacketRuntime:
    """State-less runtime wrapper for safe one-packet parsing.

    The runtime doesn't know concrete schemas; the caller provides packet_handler.
    """

    def __init__(
        self,
        *,
        cuint_decode: Callable[[bytes, int], tuple[int, int]],
        stream_factory: Callable[[bytes, int], Any],
        packet_handler: Callable[[int, Any], None],
        need_more_exc: type[Exception],
        registry: PacketRegistry | None = None,
        known_packet_ids: set[int] | None = None,
    ):
        self._cuint_decode = cuint_decode
        self._stream_factory = stream_factory
        self._packet_handler = packet_handler
        self._need_more_exc = need_more_exc
        self._registry = registry
        self._known_packet_ids = known_packet_ids

    def parse_one(self, recv_buf: bytearray | bytes, *, phase: str = "any") -> ParseResult:
        if not recv_buf:
            return ParseResult(
                status=ParseStatus.NEED_MORE_DATA,
                message="empty receive buffer",
                phase=phase,
            )

        data = bytes(recv_buf)
        try:
            packet_id, header_size = self._cuint_decode(data, 0)
        except (IndexError, KeyError):
            return ParseResult(
                status=ParseStatus.NEED_MORE_DATA,
                message="incomplete packet id (cuint)",
                phase=phase,
            )

        descriptor_name = ""
        if self._registry is not None:
            descriptor = self._registry.resolve(packet_id, phase=phase)
            if descriptor is None:
                return ParseResult(
                    status=ParseStatus.UNKNOWN_PACKET,
                    packet_id=packet_id,
                    header_size=header_size,
                    message=f"unknown packet id 0x{packet_id:X} for phase={phase}",
                    phase=phase,
                )
            descriptor_name = descriptor.name

        if self._known_packet_ids is not None and packet_id not in self._known_packet_ids:
            return ParseResult(
                status=ParseStatus.UNKNOWN_PACKET,
                packet_id=packet_id,
                header_size=header_size,
                message=f"unknown packet id 0x{packet_id:X}",
                phase=phase,
                descriptor_name=descriptor_name,
            )

        stream = self._stream_factory(data, header_size)

        try:
            self._packet_handler(packet_id, stream)
        except Exception as exc:  # noqa: BLE001
            if isinstance(exc, self._need_more_exc):
                return ParseResult(
                    status=ParseStatus.NEED_MORE_DATA,
                    packet_id=packet_id,
                    header_size=header_size,
                    message=str(exc),
                    phase=phase,
                    descriptor_name=descriptor_name,
                )
            return ParseResult(
                status=ParseStatus.MALFORMED_PACKET,
                packet_id=packet_id,
                header_size=header_size,
                message=str(exc),
                phase=phase,
                descriptor_name=descriptor_name,
            )

        bytes_consumed = int(getattr(stream, "pos", header_size) or header_size)
        return ParseResult(
            status=ParseStatus.OK,
            packet_id=packet_id,
            header_size=header_size,
            bytes_consumed=bytes_consumed,
            phase=phase,
            descriptor_name=descriptor_name,
        )
