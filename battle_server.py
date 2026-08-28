"""
Battle server for com.qookka.areaf2 private server.

Custom binary protocol over raw TCP. NOT sproto.
Wire format: compressed_uint(packet_id) + packet._output(stream)
No application-level length framing вЂ” raw stream.
Encryption: optional ChaCha20+DH, server sends 1-byte flag (0x00 = no encryption).

Packet IDs (from decompiled .cctor):
  ReqPing           = 0x01 (1)     Clientв†’Server  u32 timestamp
  RspPing           = 0x02 (2)     Serverв†’Client  u32 timestamp
  ReqEnterBattle    = 0x3ED (1005) Clientв†’Server  u32 uid, u64 battle_id, str8 token, ClientInfo
  RspRoomLoading    = 0x3EE (1006) Serverв†’Client  flags + fields (see below)
  ReqRoomLoaded     = 0x3EF (1007) Clientв†’Server  (empty)
  RspGameStart      = 0x3F0 (1008) Serverв†’Client  u32 timestamp
  RspBattleLoadSuccess = 0x3F1 (1009) Serverв†’Client u8 flag
  RspBattleId       = 0x3F2 (1010) Serverв†’Client  u64 battle_id
  ReqLoadProgress   = 0x3F3 (1011) Clientв†’Server  f32 progress
  RspLoadProgress   = 0x3F4 (1012) Serverв†’Client  u8 bid, f32 progress
"""

from __future__ import annotations

import struct
import socket
import threading
import time
import datetime
import os
import math
import json
import re
from dataclasses import dataclass
from pathlib import Path
from typing import Callable

from battle_parser_framework import (
    BattlePacketRuntime,
    PacketDescriptor,
    PacketRegistry,
    ParseStatus,
)
from battle_parser_registry_autogen import (
    BATTLE_V2_DESCRIPTOR_HANDLER_KEYS,
    BATTLE_V2_DESCRIPTOR_REQUIRED_IDS_BY_PHASE,
    BATTLE_V2_DESCRIPTOR_SPECS,
)
from battle_payload_decoders_autogen import (
    BATTLE_PAYLOAD_DECODER_SUPPORTED_CLASSES,
    decode_battle_payload_autogen,
    is_payload_decoder_supported,
)


class NeedMoreData(Exception):
    """Raised when a packet body is incomplete in the current TCP buffer."""


@dataclass(frozen=True)
class BlockingBoardProfile:
    rows: int = 14
    cols: int = 3
    half_width: float = 0.55
    half_height: float = 0.60
    local_x_bias: float = 0.0
    # Horizontal gain shrinks center dead-zone without global left/right shift.
    local_x_gain: float = 1.15
    local_y_bias: float = 0.0
    local_y_gain: float = 1.0
    local_y_metric_weight: float = 1.0
    row_top_down: bool = True
    col_mirror: bool = True
    anchor_to_center_y: float = 1.37
    name: str = 'door'

    @property
    def block_count(self) -> int:
        return max(1, int(self.rows)) * max(1, int(self.cols))


BLOCKING_BOARD_DEFAULT_PROFILE = BlockingBoardProfile(
    half_height=0.58,
    local_x_gain=1.22,
)
BLOCKING_BOARD_WINDOW_PROFILE = BlockingBoardProfile(
    rows=13,
    half_height=0.60,
    local_x_gain=1.0,
    name='window',
)
BLOCKING_BOARD_WIDE_DOOR_PROFILE = BlockingBoardProfile(
    name='wide_door',
    half_height=0.58,
    local_x_gain=1.22,
)
BLOCKING_BOARD_NARROW_DOOR_PROFILE = BlockingBoardProfile(
    name='narrow_door',
    half_height=0.58,
    local_x_gain=1.22,
    # Vertical-only correction for player-placed doors.
    local_y_bias=0.05,
    local_y_gain=1.0,
    # Prioritize row stability over X drift in asset nearest-center mapping.
    local_y_metric_weight=1.7,
)
BLOCKING_BOARD_WIDE_WINDOW_PROFILE = BlockingBoardProfile(
    rows=13,
    half_height=0.60,
    local_x_gain=1.0,
    name='wide_window',
)
BLOCKING_BOARD_NARROW_WINDOW_PROFILE = BlockingBoardProfile(
    rows=13,
    half_height=0.60,
    local_x_gain=1.0,
    # Shift window hits down by ~1 tier (most shots were resolving one tier too high).
    local_y_bias=0.15,
    local_y_gain=1.0,
    # Preplaced windows have close X-neighbors across rows; weight Y stronger.
    local_y_metric_weight=1.6,
    name='narrow_window',
)

_BLOCKING_BOARD_PROFILE_ALIASES: dict[str, BlockingBoardProfile] = {
    'door': BLOCKING_BOARD_DEFAULT_PROFILE,
    'window': BLOCKING_BOARD_WINDOW_PROFILE,
    'wide_door': BLOCKING_BOARD_WIDE_DOOR_PROFILE,
    'narrow_door': BLOCKING_BOARD_NARROW_DOOR_PROFILE,
    'wide_window': BLOCKING_BOARD_WIDE_WINDOW_PROFILE,
    'narrow_window': BLOCKING_BOARD_NARROW_WINDOW_PROFILE,
}

_BLOCKING_BOARD_PROFILE_BY_BLOCK_TYPE: dict[int, BlockingBoardProfile] = {
    0: BLOCKING_BOARD_WIDE_DOOR_PROFILE,
    1: BLOCKING_BOARD_WIDE_WINDOW_PROFILE,
    2: BLOCKING_BOARD_NARROW_DOOR_PROFILE,
    3: BLOCKING_BOARD_NARROW_WINDOW_PROFILE,
}

BlockingBoardCenters = tuple[tuple[float, float], ...]
BlockingBoardRowBand = tuple[float, float, tuple[int, ...]]
BlockingBoardRowBands = tuple[BlockingBoardRowBand, ...]

# Asset-derived block-center layouts (WallAsset.blocks[].position) indexed exactly
# like WallCollider.colliders[] / wall destroy indices on client.
_BLOCKING_BOARD_PROFILE_LAYOUT_CENTERS: dict[str, BlockingBoardCenters] = {
    'narrow_door': (
        (0.414586, 0.999631), (0.002284, 0.859422), (0.398626, 0.703452),
        (0.004135, 0.546627), (0.382889, 0.389469), (-0.006942, 0.232258),
        (0.390785, 0.07524), (0.006217, -0.080854), (0.423244, -0.221059),
        (0.370289, -0.393691), (0.391678, -0.565754), (0.404353, -0.721148),
        (0.409555, -0.878207), (0.016597, -0.992127), (0.467467, 0.85942),
        (-0.461536, 0.859424), (0.481325, 0.546625), (0.467755, 0.232264),
        (0.482838, -0.080848), (0.468882, -1.017459), (-0.412923, 0.999635),
        (-0.004987, 1.01527), (0.001363, 0.703452), (-0.399139, 0.703453),
        (-0.481269, 0.546628), (-0.005923, 0.38947), (-0.390165, 0.389471),
        (-0.475203, 0.232252), (-0.379147, 0.07522), (0.014866, 0.07523),
        (-0.476278, -0.08086), (-0.39937, -0.236646), (0.040953, -0.252315),
        (-0.473311, -0.393637), (-0.103513, -0.39366), (-0.381595, -0.550432),
        (0.034196, -0.534748), (-0.485274, -0.705897), (-0.056434, -0.694669),
        (-0.378835, -0.862405), (0.051219, -0.846584), (-0.445051, -1.017457),
    ),
    'narrow_window': (
        (0.32745, -0.623867), (0.089506, -0.779262), (0.353456, -0.92182),
        (0.03804, 0.925988), (-0.096539, 0.786069), (0.091816, 0.630093),
        (0.315025, 0.473249), (0.375891, 0.315965), (0.292854, 0.158778),
        (0.380786, 0.00179), (0.314262, -0.154307), (0.34943, -0.325899),
        (0.004681, -0.467135), (0.401227, -0.779335), (0.40735, -0.467244),
        (0.402743, 0.941545), (-0.369022, 0.925996), (0.422601, 0.630062),
        (0.332997, 0.786045), (-0.415412, 0.786086), (-0.336241, 0.630134),
        (-0.418939, 0.473363), (-0.098231, 0.473313), (-0.328859, 0.316351),
        (0.047355, 0.316144), (-0.392438, 0.159052), (-0.081508, 0.158926),
        (0.05529, 0.001819), (-0.318757, 0.001857), (-0.075671, -0.154193),
        (-0.39296, -0.154101), (0.037679, -0.294497), (-0.316295, -0.310056),
        (-0.401834, -0.467024), (-0.023476, -0.639363), (-0.349684, -0.608099),
        (-0.297888, -0.779172), (-0.032874, -0.921727), (-0.380622, -0.937883),
    ),
    'wide_door': (
        (0.944965, -0.705446), (1.011136, -0.878389), (1.113673, -1.017685),
        (0.045433, 0.998954), (0.961179, 0.858944), (0.047301, 0.719413),
        (1.126809, 0.546781), (0.00432, 0.374041), (1.138239, 0.232259),
        (-0.032141, 0.075496), (1.091353, -0.080668), (-0.046313, -0.236434),
        (1.119561, -0.393425), (0.013939, -0.550004), (1.084663, 1.014689),
        (0.582164, 0.998943), (-1.027311, 0.998975), (-0.472611, 0.998965),
        (1.033513, 0.687995), (0.512831, 0.703711), (-1.021967, 0.70387),
        (-0.465347, 0.703814), (1.011211, 0.389547), (0.501624, 0.389663),
        (-1.009897, 0.390007), (-0.508157, 0.389896), (1.001853, 0.075318),
        (0.488668, 0.075405), (-1.023053, 0.075673), (-0.538917, 0.075587),
        (0.995178, -0.236438), (0.4586, -0.236436), (-1.037083, -0.236431),
        (-0.533853, -0.236433), (1.04169, -0.534436), (0.559955, -0.549998),
        (-1.066775, -0.534456), (-1.11207, 0.859042), (-0.675542, 0.859022),
        (-0.11375, 0.858996), (0.412922, 0.85897), (0.677827, 0.546861),
        (-0.029794, 0.546993), (-1.170741, 0.547202), (-0.746003, 0.547126),
        (0.740454, 0.232345), (0.245765, 0.232459), (-0.280347, 0.232577),
        (-0.724609, 0.232681), (-1.120571, 0.232766), (0.672403, -0.080641),
        (0.182003, -0.08061), (-0.302945, -0.080579), (-0.770239, -0.080548),
        (-1.153032, -0.080524), (0.681428, -0.393425), (0.155481, -0.393424),
        (-0.365145, -0.393424), (-0.829862, -0.393424), (-1.186664, -0.393424),
        (0.358084, -0.705456), (-0.115826, -0.689931), (-0.554856, -0.731361),
        (-1.026964, -0.689947), (-1.100877, -1.017682), (-0.637211, -1.002527),
        (0.630831, -1.002529), (-0.042236, -0.992424), (-0.54974, -0.561123),
        (-0.988467, -0.862525), (-0.495853, -0.878398), (-0.080451, -0.836055),
        (0.465957, -0.862513),
    ),
}

_BLOCKING_BOARD_LAYOUT_PROFILE_ALIASES: dict[str, str] = {
    'door': 'narrow_door',
    'window': 'narrow_window',
}

# Asset-derived per-row Y bands from Mesh.m_LocalAABB (top -> bottom).
# Each row stores (y_min, y_max, candidate_block_indices) in client index space.
_BLOCKING_BOARD_PROFILE_LAYOUT_ROW_BANDS: dict[str, BlockingBoardRowBands] = {
    'narrow_door': (
        (0.937081, 1.093453, (20, 21, 0)),
        (0.781757, 0.937092, (15, 1, 14)),
        (0.625146, 0.781758, (23, 22, 2)),
        (0.468103, 0.625148, (24, 3, 16)),
        (0.310833, 0.468110, (26, 25, 4)),
        (0.153664, 0.310835, (17, 5, 27)),
        (-0.003241, 0.153701, (6, 29, 28)),
        (-0.158485, -0.003205, (18, 7, 30)),
        (-0.314947, -0.158485, (31, 32, 8)),
        (-0.472479, -0.314772, (33, 34, 9)),
        (-0.628565, -0.472472, (10, 36, 35)),
        (-0.783357, -0.627741, (11, 38, 37)),
        (-0.941466, -0.783311, (12, 40, 39)),
        (-1.093453, -0.941462, (41, 13, 19)),
    ),
    'narrow_window': (
        (0.863716, 1.019367, (16, 3, 15)),
        (0.708349, 0.863758, (19, 4, 18)),
        (0.551747, 0.708432, (20, 5, 17)),
        (0.394668, 0.551880, (21, 22, 6)),
        (0.237040, 0.394895, (23, 24, 7)),
        (0.080159, 0.238084, (25, 26, 8)),
        (-0.076748, 0.080299, (28, 27, 9)),
        (-0.232016, -0.076399, (30, 29, 10)),
        (-0.388592, -0.231698, (32, 31, 11)),
        (-0.545986, -0.388269, (33, 12, 14)),
        (-0.701878, -0.545686, (35, 34, 0)),
        (-0.856874, -0.701571, (36, 1, 13)),
        (-1.019367, -0.856641, (38, 37, 2)),
    ),
}


def _normalize_blocking_board_profile_name(value: object) -> str | None:
    if not isinstance(value, str):
        return None
    normalized = value.strip().lower().replace('-', '_').replace(' ', '_')
    if not normalized:
        return None
    return normalized


def _resolve_blocking_board_profile_from_manifest_row(
    row: dict[str, object],
    fallback: BlockingBoardProfile,
) -> BlockingBoardProfile:
    profile_name = _normalize_blocking_board_profile_name(row.get('profile'))
    if profile_name is not None:
        aliased = _BLOCKING_BOARD_PROFILE_ALIASES.get(profile_name)
        if aliased is not None:
            return aliased

    try:
        block_type = int(row.get('block_type', -1))
    except Exception:
        block_type = -1
    typed = _BLOCKING_BOARD_PROFILE_BY_BLOCK_TYPE.get(block_type)
    if typed is not None:
        return typed

    return fallback

# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Compressed uint codec (variable-length, big-endian bit pattern)
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

def cuint_encode(value: int) -> bytes:
    """Encode an unsigned integer as a compressed uint (variable-length)."""
    if value < 0:
        raise ValueError("cuint cannot be negative")
    if value < 0x80:
        return bytes([value])
    if value < 0x4000:
        return bytes([0x80 | (value >> 8), value & 0xFF])
    if value < 0x200000:
        return bytes([0xC0 | (value >> 16), (value >> 8) & 0xFF, value & 0xFF])
    if value < 0x10000000:
        return bytes([
            0xE0 | (value >> 24),
            (value >> 16) & 0xFF,
            (value >> 8) & 0xFF,
            value & 0xFF,
        ])
    # 5 bytes for larger values
    return bytes([
        0xF0,
        (value >> 24) & 0xFF,
        (value >> 16) & 0xFF,
        (value >> 8) & 0xFF,
        value & 0xFF,
    ])


def cuint_decode(data: bytes, offset: int) -> tuple[int, int]:
    """Decode a compressed uint from data at offset. Returns (value, new_offset)."""
    b0 = data[offset]
    if (b0 & 0x80) == 0:
        return b0, offset + 1
    if (b0 & 0xC0) == 0x80:
        return ((b0 & 0x3F) << 8) | data[offset + 1], offset + 2
    if (b0 & 0xE0) == 0xC0:
        return (((b0 & 0x1F) << 16) | (data[offset + 1] << 8) |
                data[offset + 2]), offset + 3
    if (b0 & 0xF0) == 0xE0:
        return (((b0 & 0x0F) << 24) | (data[offset + 1] << 16) |
                (data[offset + 2] << 8) | data[offset + 3]), offset + 4
    # 5+ bytes
    return ((data[offset + 1] << 24) | (data[offset + 2] << 16) |
            (data[offset + 3] << 8) | data[offset + 4]), offset + 5


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Binary stream writer
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

class OutputStream:
    """Binary stream builder matching the game's OutputStream serialization."""

    def __init__(self):
        self._buf = bytearray()

    def write_u8(self, v: int):
        self._buf.append(v & 0xFF)

    def write_u16(self, v: int):
        self._buf.extend(struct.pack('<H', v))

    def write_u32(self, v: int):
        self._buf.extend(struct.pack('<I', v))

    def write_s32(self, v: int):
        self._buf.extend(struct.pack('<i', v))

    def write_u64(self, v: int):
        self._buf.extend(struct.pack('<Q', v))

    def write_f32(self, v: float):
        self._buf.extend(struct.pack('<f', v))

    def write_bool(self, v: bool):
        self._buf.append(1 if v else 0)

    def write_str8(self, v: str):
        encoded = v.encode('utf-8')
        self._buf.extend(cuint_encode(len(encoded)))
        self._buf.extend(encoded)

    def write_cuint(self, v: int):
        self._buf.extend(cuint_encode(v))

    def write_bytes(self, data: bytes):
        self._buf.extend(data)

    def get_bytes(self) -> bytes:
        return bytes(self._buf)


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Binary stream reader
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

class InputStream:
    """Binary stream reader matching the game's InputStream deserialization."""

    def __init__(self, data: bytes, offset: int = 0):
        self._data = data
        self._pos = offset

    def _ensure(self, n: int):
        if self.remaining < n:
            raise NeedMoreData(f"need {n} bytes, have {self.remaining}")

    @property
    def pos(self) -> int:
        return self._pos

    @property
    def remaining(self) -> int:
        return len(self._data) - self._pos

    def read_u8(self) -> int:
        self._ensure(1)
        v = self._data[self._pos]
        self._pos += 1
        return v

    def read_u16(self) -> int:
        self._ensure(2)
        v = struct.unpack_from('<H', self._data, self._pos)[0]
        self._pos += 2
        return v

    def read_u32(self) -> int:
        self._ensure(4)
        v = struct.unpack_from('<I', self._data, self._pos)[0]
        self._pos += 4
        return v

    def read_s32(self) -> int:
        self._ensure(4)
        v = struct.unpack_from('<i', self._data, self._pos)[0]
        self._pos += 4
        return v

    def read_u64(self) -> int:
        self._ensure(8)
        v = struct.unpack_from('<Q', self._data, self._pos)[0]
        self._pos += 8
        return v

    def read_f32(self) -> float:
        self._ensure(4)
        v = struct.unpack_from('<f', self._data, self._pos)[0]
        self._pos += 4
        return v

    def read_bool(self) -> bool:
        self._ensure(1)
        v = self._data[self._pos]
        self._pos += 1
        return v != 0

    def read_str8(self) -> str:
        try:
            length, self._pos = cuint_decode(self._data, self._pos)
        except (IndexError, KeyError):
            raise NeedMoreData("incomplete cuint while reading str8")
        self._ensure(length)
        s = self._data[self._pos:self._pos + length].decode('utf-8', errors='replace')
        self._pos += length
        return s

    def read_cuint(self) -> int:
        try:
            v, self._pos = cuint_decode(self._data, self._pos)
        except (IndexError, KeyError):
            raise NeedMoreData("incomplete cuint")
        return v

    def read_bytes(self, n: int) -> bytes:
        self._ensure(n)
        b = self._data[self._pos:self._pos + n]
        self._pos += n
        return b


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Packet IDs
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

# proto.ping namespace (used during pre-battle/loading)
PKT_REQ_PING             = 0x01    # 1
PKT_RSP_PING             = 0x02    # 2

# proto.game namespace (used after battle start; note ID overlap with proto.ping)
PKT_REQ_CHARACTER_POSE                   = 0x01   # 1
PKT_RSP_CHARACTER_POSE                   = 0x02   # 2
PKT_REQ_CHARACTER_STATE                  = 0x03   # 3
PKT_RSP_CHARACTER_STATE                  = 0x04   # 4
PKT_REQ_CHARACTER_JUMP_ON                = 0x05   # 5
PKT_RSP_CHARACTER_JUMP_ON                = 0x06   # 6
PKT_REQ_CHARACTER_THROW_ROPE             = 0x09   # 9
PKT_RSP_CHARACTER_THROW_ROPE             = 0x0A   # 10
PKT_REQ_CHARACTER_INTO_WALL_SPACE        = 0x0B   # 11
PKT_RSP_CHARACTER_INTO_WALL_SPACE        = 0x0C   # 12
PKT_REQ_CHARACTER_LEAVE_WALL_SPACE       = 0x0D   # 13
PKT_RSP_CHARACTER_LEAVE_WALL_SPACE       = 0x0E   # 14
PKT_REQ_CHARACTER_CHANGE_POSE_IN_WALL    = 0x0F   # 15
PKT_RSP_CHARACTER_CHANGE_POSE_IN_WALL    = 0x10   # 16
PKT_REQ_CHARACTER_LEAVE_WALL_SPACE_BY_WINDOW = 0x11  # 17
PKT_RSP_CHARACTER_LEAVE_WALL_SPACE_BY_WINDOW = 0x12  # 18
PKT_REQ_CHARACTER_GUN_FIRE               = 0x13   # 19
PKT_RSP_EVENT_CHARACTER_GUN_FIRE         = 0x14   # 20
PKT_REQ_CHARACTER_ACTION_MELEE_ATTACK    = 0x17   # 23
PKT_RSP_CHARACTER_ACTION_MELEE_ATTACK    = 0x18   # 24
PKT_REQ_CHARACTER_LERP_POS               = 0x19   # 25
PKT_RSP_CHARACTER_LERP_POS               = 0x1A   # 26
PKT_REQ_CHARACTER_ACTION_TILT            = 0x1B   # 27
PKT_RSP_CHARACTER_ACTION_TILT            = 0x1C   # 28
PKT_REQ_CHARACTER_OPERATE_BLOCKING_BOARD = 0x1D   # 29
PKT_RSP_CHARACTER_OPERATE_BLOCKING_BOARD = 0x1E   # 30
PKT_REQ_CHARACTER_ACTION_EXPLODE         = 0x1F   # 31
PKT_RSP_CHARACTER_ACTION_EXPLODE         = 0x20   # 32
PKT_RSP_PLAYER_DEATH                     = 0x33   # 51
PKT_REQ_CHARACTER_OPERATE_EXPLOSIVE      = 0x23   # 35
PKT_RSP_CHARACTER_OPERATE_EXPLOSIVE      = 0x24   # 36
PKT_REQ_CHARACTER_OPERATE_SHIELD         = 0x35   # 53
PKT_RSP_CHARACTER_OPERATE_SHIELD         = 0x36   # 54
PKT_REQ_SHIELD_STATE_UPDATE              = 0x37   # 55
PKT_RSP_SHIELD_STATE_UPDATE              = 0x38   # 56
PKT_REQ_DESTROY_SCENE_OBJECT             = 0x47   # 71
PKT_RSP_DESTROY_SCENE_OBJECT             = 0x48   # 72
PKT_REQ_CHARACTER_ACTION_TAKE_OUT_PAD    = 0x54   # 84
PKT_RSP_CHARACTER_ACTION_TAKE_OUT_PAD    = 0x55   # 85
PKT_REQ_SCAN_ENEMIES                     = 0x58   # 88
PKT_RSP_SCAN_ENEMIES                     = 0x59   # 89
PKT_REQ_GRENADE_BEGIN                    = 0xAF   # 175
PKT_RSP_GRENADE_BEGIN                    = 0xB0   # 176
PKT_REQ_THROW_GRENADE_END                = 0xB3   # 179
PKT_RSP_THROW_GRENADE_END                = 0xB4   # 180
PKT_RSP_GRENADE_TIME_OUT                 = 0xB5   # 181
PKT_RSP_GRENADE_EXPLOSIVE_POS_REPORT     = 0xB6   # 182
PKT_REQ_GRENADE_EXPLOSIVE_POS_REPORT     = 0xB7   # 183
PKT_REQ_GRENADE_EXPLOSIVE_POS_NTF        = 0xB8   # 184
PKT_REQ_CANCEL_THROW_GRENADE             = 0xB9   # 185
PKT_RSP_CANCEL_THROW_GRENADE             = 0xBA   # 186
PKT_REQ_CHARACTER_OPERATION              = 0xBF   # 191
PKT_RSP_CHARACTER_OPERATION              = 0xC0   # 192
PKT_REQ_SYNC_CHARACTER_ACTION            = 0xC1   # 193
PKT_RSP_SYNC_CHARACTER_ACTION            = 0xC2   # 194
PKT_RSP_CHARACTER_HP_CHANGED             = 0xC4   # 196
PKT_REQ_OPERATE_TOOL                     = 0xE4   # 228
PKT_RSP_OPERATE_TOOL                     = 0xE5   # 229
PKT_REQ_BOMB_EXPLOSIVE                  = 0xD3   # 211
PKT_RSP_SMOKE_BOMB_EXPLOSIVE            = 0x468  # 1128
PKT_REQ_THROW_SCENE_TOOL                 = 0x1AF  # 431
PKT_RSP_THROW_SCENE_TOOL                 = 0x1B0  # 432
PKT_REQ_SYNC_THROW_SCENE_TOOL_POSITION   = 0x1B1  # 433
PKT_RSP_SYNC_THROW_SCENE_TOOL_POSITION   = 0x1B2  # 434
PKT_RSP_THROW_SCENE_TOOL_END             = 0x1B3  # 435
PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION = 0x1B4  # 436
PKT_RSP_REPORT_THROW_SCENE_TOOL_FINAL_POSITION = 0x1B5  # 437
PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION_WITH_RELATION = 0x1B6  # 438
PKT_RSP_REPORT_THROW_SCENE_TOOL_FINAL_POSITION_WITH_RELATION = 0x1B7  # 439
PKT_RSP_EVENT_WALL_BLOCK_DESTROY         = 0x2B   # 43
PKT_RSP_EVENT_WALL_DESTROY               = 0x2C   # 44
PKT_RSP_EVENT_CHARACTER_GUN_HURT         = 0x2D   # 45
PKT_RSP_EVENT_BLOCKING_BOARD_CONTENT_DESTROY = 0x2F   # 47
PKT_RSP_EVENT_BLOCKING_BOARD_DESTROY     = PKT_RSP_EVENT_BLOCKING_BOARD_CONTENT_DESTROY
PKT_RSP_EVENT_BLOCKING_BOARD_STATE       = 0x30   # 48
PKT_REQ_CHANGE_BLOCKING_BOARD_STATE      = 0x31   # 49
PKT_RSP_DYNAMIC_BLOCK_BREAK_STATE        = 0x7F   # 127
PKT_REQ_CHARACTER_ACTION_AIMING          = 0x3F   # 63
PKT_RSP_CHARACTER_ACTION_AIMING          = 0x40   # 64
PKT_RSP_EVENT_CHARACTER_FRIEND_EXPLOSIVE_HURT = 0x3D   # 61
PKT_RSP_EVENT_CHARACTER_ENEMY_EXPLOSIVE_HURT = 0x3E   # 62
PKT_REQ_CHARACTER_INSTALL_REINFORCED     = 0x41   # 65
PKT_RSP_CHARACTER_INSTALL_REINFORCED     = 0x42   # 66
PKT_RSP_BATTLE_RESULT                    = 0x43   # 67
PKT_REQ_CHANGE_REINFORCED_STATE          = 0x44   # 68
PKT_RSP_REINFORCED_STATE_UPDATE          = 0x45   # 69
PKT_RSP_CHANGE_REINFORCED_STATE_ERROR    = 0x46   # 70
PKT_REQ_SWITCH_CURRENT_UNMANNED_VEHICLE  = 0x56   # 86
PKT_RSP_UPDATE_UNMANNED_VEHICLE_STATE    = 0x57   # 87
PKT_REQ_UNMANNED_VEHICLE_SPAWN           = 0x5A   # 90
PKT_RSP_UNMANNED_VEHICLE_SPAWN           = 0x5B   # 91
PKT_REQ_UNMANNED_VEHICLE_POSE_DELTA      = 0x5C   # 92
PKT_RSP_UNMANNED_VEHICLE_POSE_DELTA      = 0x5D   # 93
PKT_REQ_UNMANNED_VEHICLE_TAKE_BACK       = 0x5E   # 94
PKT_RSP_UNMANNED_VEHICLE_TAKE_BACK       = 0x5F   # 95
PKT_RSP_UNMANNED_VEHICLE_DEAD            = 0x60   # 96
PKT_REQ_SWITCH_UNMANNED_VEHICLE_TO_CHARACTER = 0x61  # 97
PKT_RSP_SWITCH_UNMANNED_VEHICLE_FAILED   = 0x64   # 100
PKT_REQ_MONITOR_SCAN_ENEMIES             = 0x65   # 101
PKT_RSP_MONITOR_SCAN_ENEMIES             = 0x66   # 102
PKT_REQ_SWITCH_MONITOR_TO_CHARACTER      = 0x68   # 104
PKT_REQ_SWITCH_CURRENT_MONITOR           = 0x69   # 105
PKT_RSP_SWITCH_CURRENT_MONITOR_FAILED    = 0x6A   # 106
PKT_RSP_UPDATE_MONITOR_STATE             = 0x6B   # 107
PKT_REQ_MONITOR_POSE_DELTA               = 0x6C   # 108
PKT_RSP_MONITOR_POSE_DELTA               = 0x6D   # 109
PKT_REQ_FOUND_CRITICAL_TARGET            = 0x6F   # 111
PKT_RSP_FOUND_CRITICAL_TARGET            = 0x70   # 112
PKT_REQ_CHARACTER_CLIMB_LADDER           = 0x73   # 115
PKT_RSP_CHARACTER_CLIMB_LADDER           = 0x74   # 116
PKT_REQ_CHARACTER_LEAVE_LADDER           = 0x75   # 117
PKT_RSP_CHARACTER_LEAVE_LADDER           = 0x76   # 118
PKT_REQ_BOMB_GUN_FIRE                    = 0x80   # 128
PKT_RSP_BOMB_GUN_FIRE_RESULT             = 0x81   # 129
PKT_REQ_BOMB_BULLET_STATE                = 0x83   # 131
PKT_REQ_VEHICLE_LAUNCH_TRACKER           = 0x88   # 136
PKT_RSP_VEHICLE_LAUNCH_TRACKER           = 0x89   # 137
PKT_RSP_INSTALL_TRACKER                  = 0x8A   # 138
PKT_REQ_ACTIVE_TRACKER                   = 0x8B   # 139
PKT_RSP_ACTIVE_TRACKER                   = 0x8C   # 140
PKT_RSP_TRACKER_REPORT                   = 0x8D   # 141
PKT_REQ_DISTURBED_OPERATE                = 0x8E   # 142
PKT_REQ_CHARACTER_HAMMER_ATTACK          = 0x9B   # 155
PKT_RSP_CHARACTER_HAMMER_ATTACK          = 0x9C   # 156
PKT_REQ_CHARACTER_ACTION_HAMMER_ATTACK   = 0x9D   # 157
PKT_RSP_CHARACTER_ACTION_HAMMER_ATTACK   = 0x9E   # 158
PKT_REQ_CLIENT_CHEAT_REPORT              = 0x9F   # 159
PKT_REQ_CHARACTER_ACTION_INSTALL_TRAP_BOMB = 0xA0   # 160
PKT_RSP_CHARACTER_ACTION_INSTALL_TRAP_BOMB = 0xA1   # 161
PKT_REQ_TRAP_BOMB_INSTALLED              = 0xA2   # 162
PKT_RSP_TRAP_BOMB_INSTALLED              = 0xA3   # 163
PKT_REQ_CHARACTER_ACTION_UNINSTALL_TRAP_BOMB = 0xA4   # 164
PKT_RSP_CHARACTER_ACTION_UNINSTALL_TRAP_BOMB = 0xA5   # 165
PKT_REQ_TRAP_BOMB_UNINSTALLED            = 0xA6   # 166

VEHICLE_RELATION_OPERATOR                = 1
VEHICLE_RELATION_WATCHER                 = 2
VEHICLE_RELATION_DELEGATOR               = 3
VEHICLE_RELATION_NONE                    = 4
MONITOR_RELATION_OPERATOR                = 1
MONITOR_RELATION_WATCHER                 = 2
MONITOR_RELATION_NONE                    = 3
PKT_REQ_TRIGGER_TRAP_BOMB                = 0xA7   # 167
PKT_RSP_UPDATE_TRAP_BOMB_STATE           = 0xA8   # 168
PKT_REQ_THROW_ITEM                       = 0xC8   # 200
PKT_RSP_THROW_ITEM                       = 0xC9   # 201
PKT_REQ_ITEM_POS_REPORT                  = 0xCA   # 202
PKT_RSP_ITEM_POS_REPORT                  = 0xCB   # 203
PKT_REQ_THROW_ITEM_DROP_DOWN             = 0xD5   # 213
PKT_RSP_THROW_ITEM_DROP_DOWN             = 0xD6   # 214
PKT_REQ_THROW_ITEM_STOPED                = 0xD7   # 215
PKT_RSP_THROW_ITEM_STOPED                = 0xD8   # 216
PKT_REQ_GAME_POINTS                      = 0xDD   # 221
PKT_RSP_GAME_POINTS                      = 0xDE   # 222
PKT_REQ_OPERATE_CHARACTER                = 0xE2   # 226
PKT_RSP_OPERATE_CHARACTER                = 0xE3   # 227
PKT_REQ_THROW_NEURO_TOXIN                = 0x154  # 340
PKT_RSP_THROW_NEURO_TOXIN                = 0x155  # 341
PKT_REQ_SYNC_NEURO_TOXIN_POSITION        = 0x156  # 342
PKT_RSP_SYNC_NEURO_TOXIN_POSITION        = 0x157  # 343
PKT_REQ_THROW_NEURO_TOXIN_END            = 0x158  # 344
PKT_RSP_THROW_NEURO_TOXIN_END            = 0x159  # 345
PKT_RSP_NEURO_TOXIN_TRIGGER              = 0x15A  # 346
PKT_RSP_HIT_NEURO_TOXIN_BUFF             = 0x15B  # 347
PKT_REQ_REMOVE_NEURO_TOXIN_OPERATOR      = 0x15C  # 348
PKT_RSP_REMOVE_NEURO_TOXIN_OPERATOR      = 0x15D  # 349
PKT_REQ_REMOVE_NEURO_TOXIN_EFFECT        = 0x15E  # 350
PKT_REQ_GET_BACK_NEURO_TOXIN_OPERATOR    = 0x160  # 352
PKT_RSP_GET_BACK_NEURO_TOXIN_OPERATOR    = 0x161  # 353
PKT_REQ_GET_BACK_NEURO_TOXIN_TOOL        = 0x162  # 354
PKT_RSP_GET_BACK_NEURO_TOXIN_FAILED      = 0x163  # 355
PKT_RSP_DELETE_NEURO_TOXIN               = 0x164  # 356

PKT_REQ_WALL_INFO                         = 0x44C  # 1100
PKT_RSP_WALL_INFO                         = 0x44D  # 1101
PKT_REQ_PILLAR_GROUP_INFO                 = 0x44E  # 1102
PKT_RSP_PILLAR_GROUP_INFO                 = 0x44F  # 1103
PKT_REQ_DYNAMIC_WALL_INFO                 = 0x450  # 1104
PKT_RSP_DYNAMIC_WALL_INFO                 = 0x451  # 1105
PKT_REQ_REINFORCED_WALL_INFO              = 0x452  # 1106
PKT_RSP_REINFORCED_WALL_INFO              = 0x453  # 1107
PKT_REQ_SIMPLE_QUINTAIN_INFO              = 0x454  # 1108
PKT_RSP_SIMPLE_QUINTAIN_INFO              = 0x455  # 1109
PKT_REQ_SECURITY_CAMERA_INFO              = 0x456  # 1110
PKT_RSP_SECURITY_CAMERA_INFO              = 0x457  # 1111
PKT_REQ_GAME_PLAYER_INFO                  = 0x458  # 1112
PKT_RSP_GAME_PLAYER_INFO                  = 0x459  # 1113
PKT_REQ_VEHICLE_INFO                      = 0x45A  # 1114
PKT_RSP_VEHICLE_INFO                      = 0x45B  # 1115
PKT_REQ_SIMPLE_SCENE_ITEM_INFO            = 0x45C  # 1116
PKT_RSP_SIMPLE_SCENE_ITEM_INFO            = 0x45D  # 1117
PKT_REQ_ARMOR_PACKAGE_INFO                = 0x45E  # 1118
PKT_RSP_ARMOR_PACKAGE_INFO                = 0x45F  # 1119
PKT_REQ_ELECTRIC_BOX_INFO                 = 0x460  # 1120
PKT_RSP_ELECTRIC_BOX_INFO                 = 0x461  # 1121
PKT_REQ_MOUNTED_LMG_INFO                  = 0x462  # 1122
PKT_RSP_MOUNTED_LMG_INFO                  = 0x463  # 1123
PKT_REQ_BUFF_INFO                         = 0x464  # 1124
PKT_RSP_BUFF_INFO                         = 0x465  # 1125
PKT_RSP_TARGET_MODEL_START_RUN            = 0x262  # 610
PKT_RSP_TARGET_MODEL_DESTROY              = 0x263  # 611
PKT_RSP_TARGET_MODEL_RELIVE               = 0x264  # 612
PKT_RSP_CREATE_ENTITY                     = 0x26C  # 620

PKT_REQ_DESTROY_BLOCKING_BOARD            = 0x1C5  # 453
PKT_RSP_DESTROY_BLOCKING_BOARD            = 0x1C6  # 454
PKT_RSP_BLOCKING_BOARD_STATE              = 0x1C7  # 455
PKT_REQ_GROUND_MATERIAL                   = 0x1EB  # 491
PKT_RSP_GROUND_MATERIAL                   = 0x1EC  # 492
PKT_REQ_CHARACTER_MELEE_ATTACK            = 0x25   # 37
PKT_RSP_CHARACTER_MELEE_ATTACK            = 0x26   # 38
PKT_REQ_CHARACTER_JUMP_OVER              = 0x07   # 7
PKT_RSP_CHARACTER_JUMP_OVER              = 0x08   # 8
PKT_REQ_PLACE_TOOL_OPERATOR               = 0x168  # 360
PKT_RSP_PLACE_TOOL_OPERATOR               = 0x169  # 361
PKT_REQ_CREATE_PLACE_SCENE_TOOL           = 0x16A  # 362
PKT_RSP_CREATE_PLACE_SCENE_TOOL           = 0x16B  # 363
PKT_REQ_GET_BACK_PLACE_SCENE_TOOL_OPERATOR = 0x16C  # 364
PKT_RSP_GET_BACK_PLACE_SCENE_TOOL_OPERATOR = 0x16D  # 365
PKT_RSP_DELETE_SCENE_TOOL                 = 0x170  # 368
PKT_REQ_SYNC_PLAYER_STATE                 = 0x172  # 370
PKT_RSP_SYNC_PLAYER_STATE                 = 0x173  # 371
PKT_REQ_USE_PLACE_SCENE_TOOL_OPERATOR     = 0x174  # 372
PKT_RSP_USE_PLACE_SCENE_TOOL_OPERATOR     = 0x175  # 373
PKT_REQ_USE_SCENE_TOOL                    = 0x176  # 374
PKT_RSP_USE_SCENE_TOOL                    = 0x177  # 375
PKT_REQ_SYNC_ITEM_STATE                   = 0x179  # 377
PKT_RSP_SYNC_ITEM_STATE                   = 0x17A  # 378
PKT_RSP_REINFORCED_DEL                    = 0x17F  # 383
PKT_REQ_OPERATE_SCENE                     = 0x17C  # 380
PKT_RSP_OPERATE_SCENE                     = 0x17D  # 381
PKT_REQ_MOVE_TO_INTO_SCENE_TOOL           = 0x190  # 400
PKT_RSP_MOVE_TO_INTO_SCENE_TOOL           = 0x191  # 401
PKT_REQ_LEAVE_SCENE_TOOL                  = 0x192  # 402
PKT_RSP_LEAVE_SCENE_TOOL                  = 0x193  # 403
PKT_REQ_INTO_SCENE_TOOL                   = 0x194  # 404
PKT_RSP_INTO_SCENE_TOOL                   = 0x195  # 405
PKT_REQ_GET_BACK_PLACE_SCENE_TOOL         = 0x16E  # 366
PKT_RSP_GET_BACK_PLACE_SCENE_TOOL_FAILED  = 0x16F  # 367
PKT_REQ_KILL_ME                           = 0x1C3  # 451
PKT_RSP_KILL_ME                           = 0x1C4  # 452
PKT_RSP_PLAYER_AGONAL                     = 0xEC   # 236
PKT_REQ_SYNC_PERFORM_DATA                 = 0x1CF  # 463
PKT_RSP_SYNC_PERFORM_DATA                 = 0x1D0  # 464
PKT_REQ_SHOCK_GRENADE_BOMB                = 0x1D1  # 465
PKT_RSP_SHOCK_GRENADE_BOMB                = 0x1D2  # 466
PKT_REQ_OPERATE_GUN_RELOAD                = 0x19B  # 411
PKT_RSP_OPERATE_GUN_RELOAD                = 0x19C  # 412
PKT_REQ_SYNC_CHARACTER_WEAPON_STATE       = 0x1CC  # 460
PKT_RSP_SYNC_CHARACTER_WEAPON_STATE       = 0x1CD  # 461
PKT_REQ_SYNC_CHARACTER_ASSIST_TOOL        = 0x1FC  # 508
PKT_RSP_SYNC_CHARACTER_ASSIST_TOOL        = 0x1FD  # 509
PKT_REQ_SYNC_CHARACTER_TOOL               = 0x1FE  # 510
PKT_RSP_SYNC_CHARACTER_TOOL               = 0x1FF  # 511
PKT_REQ_SYNC_STRETCH_HAND_SHIELD_STATE    = 0x208  # 520
PKT_REQ_SYNC_HAND_SHIELD_STATE            = 0x213  # 531
PKT_REQ_TRIGGER_FLASH_HAND_SHIELD         = 0x226  # 550
PKT_REQ_GEN_ROBOT                         = 0x280  # 640
PKT_REQ_FOUND_BOMB_TARGET                 = 0x28A  # 650
PKT_RSP_FOUND_BOMB_TARGET                 = 0x28B  # 651
PKT_REQ_NOTIFY_DEFUSER_STATE              = 0x28D  # 653
PKT_RSP_NOTIFY_DEFUSER_STATE              = 0x28E  # 654
PKT_REQ_FOUND_DEFUSER                     = 0x291  # 657
PKT_RSP_FOUND_DEFUSER                     = 0x292  # 658
PKT_REQ_PICK_UP_DEFUSER                   = 0x293  # 659
PKT_REQ_DROP_DEFUSER                      = 0x294  # 660
PKT_RSP_DEFUSER_INSTALLED                 = 0x295  # 661
PKT_REQ_PLAYER_MARK                       = 0x1ED  # 493
PKT_RSP_PLAYER_MARK                       = 0x1EE  # 494
PKT_REQ_QUICK_CHAT                        = 0x29E  # 670
PKT_RSP_QUICK_CHAT                        = 0x29F  # 671
PKT_REQ_RESET_ITEM_NUM                    = 0x299  # 665
PKT_RSP_SYNC_SKILL_NUM                    = 0x2A8  # 680
PKT_RSP_SYNC_SKILL_CD                     = 0x2A9  # 681
PKT_RSP_SYNC_SKILL_ACTIVE_TIME            = 0x2AA  # 682
PKT_RSP_RESET_ALL_WEAPON_ITEM_NUM         = 0xF4251  # 1000017
PKT_RSP_RESET_GUN_CONFIG                  = 0xF425A  # 1000026
PKT_RSP_RESET_EFFECT_CONFIG               = 0xF425C  # 1000028
PKT_REQ_LEAVE_BATTLE                      = 0x258  # 600
PKT_RSP_BATTLE_OVER                       = 0x259  # 601
PKT_REQ_PLAYERS_RESULT                    = 0x7EE  # 2030
PKT_RSP_PLAYERS_RESULT                    = 0x7EF  # 2031
PKT_REQ_ADD_ROBOT                         = 0x7F0  # 2032
PKT_REQ_OPERATE_BATTLE                    = 0x7FD  # 2045
PKT_RSP_OPERATE_BATTLE                    = 0x7FE  # 2046
PKT_REQ_ROBOT_MOVE                        = 0xF426D  # 1000045
PKT_REQ_ROBOT_FIRE                        = 0xF426E  # 1000046
PKT_REQ_GAME_INFO                         = 0x4AD  # 1197
PKT_RSP_GAME_INFO                         = 0x4AE  # 1198
PKT_RSP_GAME_STAGE                        = 0x63   # 99
PKT_RSP_SPAWN_BOMB_REGION                 = 0x77   # 119
PKT_RSP_CRITICAL_REGION_STATE            = 0x78   # 120

PKT_HEARTBEAT            = 0x7D0   # 2000  (empty keepalive)
PKT_REQ_LOGOUT            = 0x7D5   # 2005  (client logout)
PKT_REQ_ENTER_BATTLE     = 0x3ED   # 1005
PKT_RSP_ROOM_LOADING     = 0x3EE   # 1006
PKT_REQ_ROOM_LOADED      = 0x3EF   # 1007
PKT_RSP_GAME_START       = 0x3F0   # 1008
PKT_RSP_BATTLE_LOAD_OK   = 0x3F1   # 1009
PKT_RSP_BATTLE_ID        = 0x3F2   # 1010
PKT_REQ_LOAD_PROGRESS    = 0x3F3   # 1011
PKT_RSP_LOAD_PROGRESS    = 0x3F4   # 1012
PKT_RSP_VEHICLE_BORN_PLACE = 0x3F5 # 1013
PKT_VERSION              = 0x3F6   # 1014  (client→server, 5x str8 version fields)

# proto.game.LeaveBattleKind enum (u8)
LEAVE_BATTLE_KIND_TO_HALL      = 0
LEAVE_BATTLE_KIND_RESTART_MODE = 1
LEAVE_BATTLE_KIND_RELOAD_MAP   = 2

# proto.game.BattleGameOverReason enum (u8)
BATTLE_OVER_REASON_NORMAL_END   = 0
BATTLE_OVER_REASON_TIME_END     = 1
BATTLE_OVER_REASON_DISCONNECT   = 2
BATTLE_OVER_REASON_SERVER_CLOSE = 3
BATTLE_OVER_REASON_SELF_LEAVE   = 4
BATTLE_OVER_REASON_RESTART_MODE = 5
BATTLE_OVER_REASON_RELOAD_MAP   = 6

# proto.common.CriticalRegionState enum (u8)
CRITICAL_REGION_STATE_NONE_PLAYERS   = 0
CRITICAL_REGION_STATE_ONLY_ATTACKERS = 1
CRITICAL_REGION_STATE_ONLY_DEFENDERS = 2
CRITICAL_REGION_STATE_BOTH_PLAYERS   = 3

# proto.common.BattleCamp enum (u8)
BATTLE_CAMP_NO_CAMP  = 0
BATTLE_CAMP_ATTACKER = 1
BATTLE_CAMP_DEFENDER = 2

# proto.common.BlockingBoardState enum (u8)
BLOCKING_BOARD_STATE_DEACTIVE = 0
BLOCKING_BOARD_STATE_FORWARD = 1
BLOCKING_BOARD_STATE_BACKWARD = 2
BLOCKING_BOARD_STATE_DEACTIVING_FORWARD = 3
BLOCKING_BOARD_STATE_DEACTIVING_BACKWARD = 4
BLOCKING_BOARD_STATE_ACTIVING_FORWARD = 5
BLOCKING_BOARD_STATE_ACTIVING_BACKWARD = 6

# proto.common.ReinforcedState enum (u8)
REINFORCED_STATE_DEACTIVED = 1
REINFORCED_STATE_ACTIVING1 = 2
REINFORCED_STATE_ACTIVING2 = 3
REINFORCED_STATE_ACTIVED1 = 4
REINFORCED_STATE_ACTIVED2 = 5

# proto.common.DestroyType enum (u8)
DESTROY_TYPE_NONE = 0
DESTROY_TYPE_GUN_DAMAGE = 1
DESTROY_TYPE_EXPLOSIVE_DAMAGE = 2
DESTROY_TYPE_SNIPE_GUN_DAMAGE = 3
DESTROY_TYPE_HAMMER_DAMAGE = 4
DESTROY_TYPE_MELEE_DAMAGE = 5
DESTROY_TYPE_ELECTRIC_DAMAGE = 6
DESTROY_TYPE_THERMITE_BOMB = 31
DESTROY_TYPE_BURN_DAMAGE = 48
DESTROY_TYPE_SHOT_GUN_DAMAGE = 68
DESTROY_TYPE_ELEC_MAG_PULSE = 75
DESTROY_TYPE_CLEAR_EVENT = 100
DESTROY_TYPE_PARENT_DESTROY = 101

# proto.common.EffectType subset (u8)
EFFECT_TYPE_NONE = 0
EFFECT_TYPE_GUN = 1
EFFECT_TYPE_EXPLOSIVE = 2
EFFECT_TYPE_SNIPE_GUN = 3
EFFECT_TYPE_HAMMER = 4
EFFECT_TYPE_MELEE = 5
EFFECT_TYPE_ELECTRIC = 6
EFFECT_TYPE_THERMITE_BOMB = 31
EFFECT_TYPE_BURN = 48
EFFECT_TYPE_SHOT_GUN = 68
EFFECT_TYPE_ELECTROMAGNETIC_DAMAGE = 75

# proto.common.SceneToolDeleteKind enum (u8)
SCENE_TOOL_DELETE_KIND_DESTROY = 1
SCENE_TOOL_DELETE_KIND_TAKE_BACK = 2
SCENE_TOOL_DELETE_KIND_USED = 3
SCENE_TOOL_DELETE_KIND_TIME_OUT = 4
SCENE_TOOL_DELETE_KIND_DIRECT_DELETE = 5

# Game.UniqueId.UniqueIdHelper kind subset used in scene-destroy flows.
UNIQUE_ID_KIND_WALL = 4
UNIQUE_ID_KIND_SIMPLE_QUINTAIN = 6
UNIQUE_ID_KIND_TARGET_MODEL = 34
TRAINING_TARGET_SCENE_ENTITY_KINDS: tuple[int, ...] = (
    UNIQUE_ID_KIND_SIMPLE_QUINTAIN,
    UNIQUE_ID_KIND_TARGET_MODEL,
)
TRAINING_TARGET_DESTROY_UID_KINDS: tuple[int, ...] = (
    UNIQUE_ID_KIND_SIMPLE_QUINTAIN,
    UNIQUE_ID_KIND_TARGET_MODEL,
)

# proto.game.PointAction subset (u32)
POINT_ACTION_KILL_ENEMY = 1
POINT_ACTION_KILL_ENEMY_REMOTE_BOMB = 2300
POINT_ACTION_HIT_TARGET_MODEL_HEAD = 58
POINT_ACTION_HIT_TARGET_MODEL_BODY = 59

# proto.game.GameStage enum (u8)
GAME_STAGE_LOADING      = 0
GAME_STAGE_PREPARE      = 1
GAME_STAGE_BATTLE       = 2
GAME_STAGE_BOMB_CONTEND = 6

try:
    TRAINING_TARGET_RESPAWN_SEC = max(
        0.25,
        float((os.getenv('TRAINING_TARGET_RESPAWN_SEC', '8.0') or '8.0').strip() or '8.0'),
    )
except Exception:
    TRAINING_TARGET_RESPAWN_SEC = 8.0

try:
    TRAINING_TARGET_RUN_DURATION_SEC = max(
        0.1,
        float((os.getenv('TRAINING_TARGET_RUN_DURATION_SEC', '1.2') or '1.2').strip() or '1.2'),
    )
except Exception:
    TRAINING_TARGET_RUN_DURATION_SEC = 1.2

try:
    TRAINING_TARGET_BODY_HITS_TO_DESTROY = max(
        1,
        int((os.getenv('TRAINING_TARGET_BODY_HITS_TO_DESTROY', '3') or '3').strip() or '3'),
    )
except Exception:
    TRAINING_TARGET_BODY_HITS_TO_DESTROY = 3

try:
    TRAINING_TARGET_HIT_HEAD_POINTS = int(
        (os.getenv('TRAINING_TARGET_HIT_HEAD_POINTS', '20') or '20').strip() or '20'
    )
except Exception:
    TRAINING_TARGET_HIT_HEAD_POINTS = 20

try:
    TRAINING_TARGET_HIT_BODY_POINTS = int(
        (os.getenv('TRAINING_TARGET_HIT_BODY_POINTS', '10') or '10').strip() or '10'
    )
except Exception:
    TRAINING_TARGET_HIT_BODY_POINTS = 10

try:
    TRAINING_TARGET_HIT_MAX_DISTANCE = max(
        1.0,
        float((os.getenv('TRAINING_TARGET_HIT_MAX_DISTANCE', '120.0') or '120.0').strip() or '120.0'),
    )
except Exception:
    TRAINING_TARGET_HIT_MAX_DISTANCE = 120.0

# Optional legacy behavior: emit synthetic training-target destroy on every gunfire.
# Disabled by default because it can distort battle flow while testing walls/structures.
TRAINING_TARGET_AUTODESTROY_ON_GUNFIRE = (
    str(os.getenv('TRAINING_TARGET_AUTODESTROY_ON_GUNFIRE', '0')).strip().lower()
    in ('1', 'true', 'yes', 'on')
)

# Minimal default target set for local training diagnostics.
TRAINING_TARGET_DEFAULTS: tuple[tuple[int, tuple[float, float, float]], ...] = (
    (1001, (0.0, 1.2, 14.0)),
    (1002, (2.2, 1.2, 14.0)),
    (1003, (-2.2, 1.2, 14.0)),
)
TRAINING_TARGET_DEFAULT_CONTENT_CONFIG_ID = 8
TRAINING_TARGET_MAP_MANIFEST_DEFAULT_PATH = os.path.join(
    'artifacts',
    'asset_manifests',
    'training_targets_map_manifest.json',
)
_TRAINING_TARGET_MAP_SEED_CACHE: dict[int, list[dict[str, object]]] | None = None
_TRAINING_TARGET_MAP_SEED_CACHE_MTIME_NS: int | None = None
_TRAINING_TARGET_MAP_SEED_CACHE_LOCK = threading.Lock()

# Known training-map destructible barricades observed in live traffic.
# Seeding them avoids stale/empty runtime state for pre-placed objects.
TRAINING_DEFAULT_BLOCKING_BOARD_IDS: tuple[int, ...] = (
    242,
    245,
    247,
    250,
    252,
)

# Empirical training-map anchors inferred from client traffic (ReqDestroyBlockingBoard / hit rays).
# They are used only as a selection hint when hit packets contain no explicit board id.
TRAINING_DEFAULT_BLOCKING_BOARD_ANCHORS: dict[int, tuple[float, float, float]] = {
    242: (-6.60, 2.90, 3.85),
    245: (-11.44, 2.90, 9.27),
    247: (-5.92, 2.90, -16.31),
    250: (-7.42, 2.90, 9.84),
    252: (-3.91, 2.91, -0.22),
}

BLOCKING_BOARD_MAP_MANIFEST_DEFAULT_PATH = os.path.join(
    'artifacts',
    'asset_manifests',
    'blocking_boards_map_manifest.json',
)
_BLOCKING_BOARD_MAP_SEED_CACHE: dict[int, list[dict[str, object]]] | None = None
_BLOCKING_BOARD_MAP_SEED_CACHE_LOCK = threading.Lock()


def _resolve_blocking_board_map_manifest_path() -> Path:
    raw_path = str(
        os.getenv(
            'BLOCKING_BOARD_MAP_MANIFEST_PATH',
            BLOCKING_BOARD_MAP_MANIFEST_DEFAULT_PATH,
        )
        or BLOCKING_BOARD_MAP_MANIFEST_DEFAULT_PATH
    ).strip()
    if not raw_path:
        raw_path = BLOCKING_BOARD_MAP_MANIFEST_DEFAULT_PATH
    manifest_path = Path(raw_path)
    if not manifest_path.is_absolute():
        manifest_path = Path(__file__).resolve().parent / manifest_path
    return manifest_path


def _load_blocking_board_map_seed_cache() -> dict[int, list[dict[str, object]]]:
    global _BLOCKING_BOARD_MAP_SEED_CACHE

    with _BLOCKING_BOARD_MAP_SEED_CACHE_LOCK:
        if _BLOCKING_BOARD_MAP_SEED_CACHE is not None:
            return _BLOCKING_BOARD_MAP_SEED_CACHE

        manifest_path = _resolve_blocking_board_map_manifest_path()
        try:
            payload = json.loads(manifest_path.read_text(encoding='utf-8'))
        except Exception:
            _BLOCKING_BOARD_MAP_SEED_CACHE = {}
            return _BLOCKING_BOARD_MAP_SEED_CACHE

        parsed: dict[int, list[dict[str, object]]] = {}
        maps = payload.get('maps') if isinstance(payload, dict) else None
        if isinstance(maps, dict):
            for raw_map_id, map_desc in maps.items():
                try:
                    map_id = int(raw_map_id)
                except Exception:
                    continue
                if map_id <= 0 or not isinstance(map_desc, dict):
                    continue

                boards_raw = map_desc.get('boards')
                if not isinstance(boards_raw, list):
                    continue

                rows: list[dict[str, object]] = []
                seen_ids: set[int] = set()
                for raw_row in boards_raw:
                    if not isinstance(raw_row, dict):
                        continue

                    try:
                        board_id = int(raw_row.get('id', 0) or 0) & 0xFFFFFFFF
                    except Exception:
                        continue
                    if board_id <= 0 or board_id in seen_ids:
                        continue

                    anchor_raw = raw_row.get('anchor')
                    if not isinstance(anchor_raw, (list, tuple)) or len(anchor_raw) < 3:
                        continue
                    try:
                        anchor = (
                            float(anchor_raw[0]),
                            float(anchor_raw[1]),
                            float(anchor_raw[2]),
                        )
                    except Exception:
                        continue

                    row: dict[str, object] = {
                        'id': board_id,
                        'anchor': anchor,
                    }
                    try:
                        block_type = int(raw_row.get('block_type', -1))
                    except Exception:
                        block_type = -1
                    if block_type in _BLOCKING_BOARD_PROFILE_BY_BLOCK_TYPE:
                        row['block_type'] = block_type

                    profile_name = _normalize_blocking_board_profile_name(raw_row.get('profile'))
                    if profile_name is not None:
                        row['profile'] = profile_name

                    try:
                        yaw = float(raw_row.get('yaw_deg'))
                        if math.isfinite(yaw):
                            row['yaw_deg'] = yaw
                    except Exception:
                        pass

                    rows.append(row)
                    seen_ids.add(board_id)

                if rows:
                    parsed[map_id] = rows

        _BLOCKING_BOARD_MAP_SEED_CACHE = parsed
        return _BLOCKING_BOARD_MAP_SEED_CACHE


def _get_blocking_board_seed_entries_for_map(map_id: int) -> list[dict[str, object]]:
    try:
        normalized_map_id = int(map_id)
    except Exception:
        return []
    if normalized_map_id <= 0:
        return []
    return _load_blocking_board_map_seed_cache().get(normalized_map_id, [])


def _resolve_training_target_map_manifest_path() -> Path:
    raw_path = str(
        os.getenv(
            'TRAINING_TARGET_MAP_MANIFEST_PATH',
            TRAINING_TARGET_MAP_MANIFEST_DEFAULT_PATH,
        )
        or TRAINING_TARGET_MAP_MANIFEST_DEFAULT_PATH
    ).strip()
    if not raw_path:
        raw_path = TRAINING_TARGET_MAP_MANIFEST_DEFAULT_PATH
    manifest_path = Path(raw_path)
    if not manifest_path.is_absolute():
        manifest_path = Path(__file__).resolve().parent / manifest_path
    return manifest_path


def _is_supported_training_target_seed_name(source_name: object) -> bool:
    del source_name
    return True


def _load_training_target_map_seed_cache() -> dict[int, list[dict[str, object]]]:
    global _TRAINING_TARGET_MAP_SEED_CACHE
    global _TRAINING_TARGET_MAP_SEED_CACHE_MTIME_NS

    with _TRAINING_TARGET_MAP_SEED_CACHE_LOCK:
        manifest_path = _resolve_training_target_map_manifest_path()
        manifest_mtime_ns: int | None
        try:
            manifest_mtime_ns = int(manifest_path.stat().st_mtime_ns)
        except Exception:
            manifest_mtime_ns = None

        if (
            _TRAINING_TARGET_MAP_SEED_CACHE is not None
            and _TRAINING_TARGET_MAP_SEED_CACHE_MTIME_NS == manifest_mtime_ns
        ):
            return _TRAINING_TARGET_MAP_SEED_CACHE

        try:
            payload = json.loads(manifest_path.read_text(encoding='utf-8'))
        except Exception:
            _TRAINING_TARGET_MAP_SEED_CACHE = {}
            _TRAINING_TARGET_MAP_SEED_CACHE_MTIME_NS = manifest_mtime_ns
            return _TRAINING_TARGET_MAP_SEED_CACHE

        parsed: dict[int, list[dict[str, object]]] = {}
        maps = payload.get('maps') if isinstance(payload, dict) else None
        if isinstance(maps, dict):
            for raw_map_id, map_desc in maps.items():
                try:
                    map_id = int(raw_map_id)
                except Exception:
                    continue
                if map_id <= 0 or not isinstance(map_desc, dict):
                    continue

                targets_raw = map_desc.get('targets')
                if not isinstance(targets_raw, list):
                    continue

                rows: list[dict[str, object]] = []
                seen_ids: set[int] = set()
                for raw_row in targets_raw:
                    if not isinstance(raw_row, dict):
                        continue
                    try:
                        target_id = int(raw_row.get('id', 0) or 0) & 0xFFFFFFFF
                    except Exception:
                        continue
                    if target_id <= 0 or target_id in seen_ids:
                        continue

                    pos_raw = raw_row.get('position')
                    if not isinstance(pos_raw, (list, tuple)) or len(pos_raw) < 3:
                        continue
                    try:
                        position = (
                            float(pos_raw[0]),
                            float(pos_raw[1]),
                            float(pos_raw[2]),
                        )
                    except Exception:
                        continue

                    row: dict[str, object] = {
                        'id': target_id,
                        'position': position,
                    }
                    try:
                        attack_config_id = int(raw_row.get('attack_config_id', 0) or 0)
                    except Exception:
                        attack_config_id = 0
                    if attack_config_id > 0:
                        row['attack_config_id'] = attack_config_id

                    try:
                        content_config_id = int(
                            raw_row.get(
                                'content_config_id',
                                raw_row.get('content_config', 0),
                            )
                            or 0
                        )
                    except Exception:
                        content_config_id = 0
                    if content_config_id > 0:
                        row['content_config_id'] = content_config_id

                    euler_raw = raw_row.get('euler')
                    if isinstance(euler_raw, (list, tuple)) and len(euler_raw) >= 3:
                        try:
                            row['euler'] = (
                                float(euler_raw[0]),
                                float(euler_raw[1]),
                                float(euler_raw[2]),
                            )
                        except Exception:
                            pass

                    try:
                        explicit_uid = int(raw_row.get('uid', 0) or 0) & 0xFFFFFFFFFFFFFFFF
                    except Exception:
                        explicit_uid = 0
                    if explicit_uid > 0:
                        row['uid'] = explicit_uid

                    source_name = raw_row.get('name')
                    if isinstance(source_name, str) and source_name:
                        if not _is_supported_training_target_seed_name(source_name):
                            continue
                        row['name'] = source_name
                    try:
                        scene_uid_kind = int(
                            raw_row.get(
                                'scene_uid_kind',
                                raw_row.get('scene_kind', 0),
                            )
                            or 0
                        )
                    except Exception:
                        scene_uid_kind = 0
                    if scene_uid_kind in TRAINING_TARGET_SCENE_ENTITY_KINDS:
                        row['scene_uid_kind'] = scene_uid_kind

                    rows.append(row)
                    seen_ids.add(target_id)

                if rows:
                    parsed[map_id] = rows

        _TRAINING_TARGET_MAP_SEED_CACHE = parsed
        _TRAINING_TARGET_MAP_SEED_CACHE_MTIME_NS = manifest_mtime_ns
        return _TRAINING_TARGET_MAP_SEED_CACHE


def _get_training_target_seed_entries_for_map(map_id: int) -> list[dict[str, object]]:
    try:
        normalized_map_id = int(map_id)
    except Exception:
        return []
    if normalized_map_id <= 0:
        return []
    return _load_training_target_map_seed_cache().get(normalized_map_id, [])


def _training_target_initial_hp(row: dict | None = None) -> int:
    base_hp = TRAINING_TARGET_BODY_HITS_TO_DESTROY
    if not isinstance(row, dict):
        return int(base_hp)

    for key in (
        'hp_max',
        'max_hp',
        'body_hits_to_destroy',
    ):
        try:
            explicit_hp = int(row.get(key, 0) or 0)
        except Exception:
            explicit_hp = 0
        if explicit_hp > 0:
            return int(explicit_hp)
    return int(base_hp)


def _build_default_training_target_state() -> dict[int, dict]:
    return {
        int(uid): {
            'uid': int(uid),
            'position': (
                float(pos[0]),
                float(pos[1]),
                float(pos[2]),
            ),
            'euler': (0.0, 0.0, 0.0),
            'scene_uid_kind': UNIQUE_ID_KIND_TARGET_MODEL,
            'content_config_id': TRAINING_TARGET_DEFAULT_CONTENT_CONFIG_ID,
            'hp': _training_target_initial_hp(),
            'alive': True,
            'relive_at': 0.0,
        }
        for uid, pos in TRAINING_TARGET_DEFAULTS
    }


def _build_training_target_state_from_seed_rows(
    rows: list[dict[str, object]],
) -> dict[int, dict]:
    state: dict[int, dict] = {}
    for row in rows:
        target_id = int(row.get('id', 0) or 0) & 0xFFFFFFFF
        if target_id <= 0:
            continue
        source_name = row.get('name')
        if isinstance(source_name, str) and source_name:
            if not _is_supported_training_target_seed_name(source_name):
                continue
        pos = row.get('position')
        if not isinstance(pos, (list, tuple)) or len(pos) < 3:
            continue
        state[target_id] = {
            'uid': target_id,
            'position': (
                float(pos[0]),
                float(pos[1]),
                float(pos[2]),
            ),
            'euler': (0.0, 0.0, 0.0),
            'scene_uid_kind': UNIQUE_ID_KIND_TARGET_MODEL,
            'content_config_id': TRAINING_TARGET_DEFAULT_CONTENT_CONFIG_ID,
            'hp': _training_target_initial_hp(row),
            'alive': True,
            'relive_at': 0.0,
        }
        if isinstance(source_name, str) and source_name:
            state[target_id]['name'] = source_name
        euler_raw = row.get('euler')
        if isinstance(euler_raw, (list, tuple)) and len(euler_raw) >= 3:
            state[target_id]['euler'] = (
                float(euler_raw[0]),
                float(euler_raw[1]),
                float(euler_raw[2]),
            )
        try:
            content_config_id = int(
                row.get(
                    'content_config_id',
                    row.get('content_config', 0),
                )
                or 0
            )
        except Exception:
            content_config_id = 0
        if content_config_id > 0:
            state[target_id]['content_config_id'] = content_config_id
        elif int(row.get('attack_config_id', 0) or 0) in (8, 9):
            state[target_id]['content_config_id'] = int(row.get('attack_config_id', 0) or 0)
        try:
            scene_uid_kind = int(
                row.get(
                    'scene_uid_kind',
                    row.get('scene_kind', 0),
                )
                or 0
            )
        except Exception:
            scene_uid_kind = 0
        if scene_uid_kind in TRAINING_TARGET_SCENE_ENTITY_KINDS:
            state[target_id]['scene_uid_kind'] = scene_uid_kind
        try:
            explicit_uid = int(row.get('uid', 0) or 0) & 0xFFFFFFFFFFFFFFFF
        except Exception:
            explicit_uid = 0
        if explicit_uid > 0:
            state[target_id]['entity_uid'] = explicit_uid
    return state


def _session_seed_training_targets_from_manifest(
    session: 'BattleSession',
    map_id: int,
) -> int:
    rows = _get_training_target_seed_entries_for_map(map_id)
    if not rows:
        return 0
    seeded_state = _build_training_target_state_from_seed_rows(rows)
    if not seeded_state:
        return 0
    session.training_target_state = seeded_state
    return len(seeded_state)


MAPS_TABLE_DEFAULT_PATH = os.path.join(
    'decrypted_lua',
    'Configs',
    'TableData',
    'maps.lua',
)
_MAP_TARGET_ZONES_CACHE: dict[int, tuple[int, ...]] | None = None
_MAP_TARGET_ZONES_CACHE_LOCK = threading.Lock()
_MAPS_TABLE_RECORD_OPEN_RE = re.compile(r'^\s*\{\s*$')
_MAPS_TABLE_ID_RE = re.compile(r'^\s*id\s*=\s*(\d+)\s*,\s*$')
_MAPS_TABLE_TARGET_ZONE_OPEN_RE = re.compile(r'^\s*target_zone\s*=\s*\{')


def _resolve_maps_table_path() -> Path:
    raw_path = str(
        os.getenv(
            'MAPS_TABLE_PATH',
            MAPS_TABLE_DEFAULT_PATH,
        )
        or MAPS_TABLE_DEFAULT_PATH
    ).strip()
    if not raw_path:
        raw_path = MAPS_TABLE_DEFAULT_PATH
    table_path = Path(raw_path)
    if not table_path.is_absolute():
        table_path = Path(__file__).resolve().parent / table_path
    return table_path


def _load_map_target_zones_cache() -> dict[int, tuple[int, ...]]:
    global _MAP_TARGET_ZONES_CACHE

    with _MAP_TARGET_ZONES_CACHE_LOCK:
        if _MAP_TARGET_ZONES_CACHE is not None:
            return _MAP_TARGET_ZONES_CACHE

        table_path = _resolve_maps_table_path()
        try:
            lines = table_path.read_text(encoding='utf-8', errors='ignore').splitlines()
        except Exception:
            _MAP_TARGET_ZONES_CACHE = {}
            return _MAP_TARGET_ZONES_CACHE

        parsed: dict[int, tuple[int, ...]] = {}
        in_record = False
        record_depth = 0
        in_target_zone = False
        target_zone_depth = 0
        current_map_id: int | None = None
        current_target_zones: list[int] = []

        for raw_line in lines:
            line = raw_line.strip()
            if not line:
                continue

            opens = raw_line.count('{')
            closes = raw_line.count('}')

            if not in_record:
                if _MAPS_TABLE_RECORD_OPEN_RE.match(raw_line):
                    in_record = True
                    record_depth = 1
                    in_target_zone = False
                    target_zone_depth = 0
                    current_map_id = None
                    current_target_zones = []
                continue

            if in_target_zone:
                token = line.rstrip(',').strip()
                if token and token.lstrip('-').isdigit():
                    try:
                        zone_id = int(token)
                    except Exception:
                        zone_id = 0
                    if zone_id > 0:
                        current_target_zones.append(zone_id)

                delta = opens - closes
                target_zone_depth += delta
                record_depth += delta
                if target_zone_depth <= 0:
                    in_target_zone = False
                if record_depth <= 0:
                    if current_map_id is not None and current_target_zones:
                        parsed[int(current_map_id)] = tuple(current_target_zones)
                    in_record = False
                continue

            id_match = _MAPS_TABLE_ID_RE.match(raw_line)
            if id_match:
                try:
                    current_map_id = int(id_match.group(1))
                except Exception:
                    current_map_id = None

            if _MAPS_TABLE_TARGET_ZONE_OPEN_RE.match(raw_line):
                in_target_zone = True
                current_target_zones = []
                target_zone_depth = opens - closes
                if target_zone_depth <= 0:
                    in_target_zone = False

            record_depth += opens - closes
            if record_depth <= 0:
                if current_map_id is not None and current_target_zones:
                    parsed[int(current_map_id)] = tuple(current_target_zones)
                in_record = False

        _MAP_TARGET_ZONES_CACHE = parsed
        return _MAP_TARGET_ZONES_CACHE


def _get_primary_target_zone_for_map(map_id: int) -> int | None:
    try:
        normalized_map_id = int(map_id)
    except Exception:
        return None
    if normalized_map_id <= 0:
        return None

    zones = _load_map_target_zones_cache().get(normalized_map_id)
    if not zones:
        return None
    for zone in zones:
        try:
            zone_id = int(zone)
        except Exception:
            continue
        if zone_id > 0:
            return zone_id
    return None


SKILL_TABLE_DEFAULT_PATH = os.path.join(
    'decrypted_lua',
    'Configs',
    'TableData',
    'skill.lua',
)
CHARACTER_TABLE_DEFAULT_PATH = os.path.join(
    'decrypted_lua',
    'Configs',
    'TableData',
    'character.lua',
)
_SKILL_RESET_CONFIG_CACHE: dict[int, dict[str, int | float]] | None = None
_SKILL_RESET_CONFIG_CACHE_LOCK = threading.Lock()
_SKILL_TABLE_ENTRY_OPEN_RE = re.compile(r'^\s*\[(\d+)\]\s*=\s*\{\s*$')
_SKILL_TABLE_ASSIGN_RE = re.compile(r'^\s*(\w+)\s*=\s*([^,]+)\s*,\s*$')
_CHARACTER_DEFAULT_SKILLS_CACHE: dict[int, dict[str, list[int]]] | None = None
_CHARACTER_DEFAULT_SKILLS_CACHE_LOCK = threading.Lock()
_CHARACTER_TABLE_ENTRY_OPEN_RE = re.compile(r'^\s*\[(\d+)\]\s*=\s*\{\s*$')
_CHARACTER_TABLE_ARRAY_INLINE_RE = re.compile(
    r'^\s*(main_skill|sub_skills)\s*=\s*\{\s*([^}]*)\s*\}\s*,\s*$'
)
_CHARACTER_TABLE_ARRAY_OPEN_RE = re.compile(r'^\s*(main_skill|sub_skills)\s*=\s*\{\s*$')


def _resolve_skill_table_path() -> Path:
    raw_path = str(
        os.getenv(
            'SKILL_TABLE_PATH',
            SKILL_TABLE_DEFAULT_PATH,
        )
        or SKILL_TABLE_DEFAULT_PATH
    ).strip()
    if not raw_path:
        raw_path = SKILL_TABLE_DEFAULT_PATH
    table_path = Path(raw_path)
    if not table_path.is_absolute():
        table_path = Path(__file__).resolve().parent / table_path
    return table_path


def _load_skill_reset_config_cache() -> dict[int, dict[str, int | float]]:
    global _SKILL_RESET_CONFIG_CACHE

    with _SKILL_RESET_CONFIG_CACHE_LOCK:
        if _SKILL_RESET_CONFIG_CACHE is not None:
            return _SKILL_RESET_CONFIG_CACHE

        table_path = _resolve_skill_table_path()
        try:
            lines = table_path.read_text(encoding='utf-8', errors='ignore').splitlines()
        except Exception:
            _SKILL_RESET_CONFIG_CACHE = {}
            return _SKILL_RESET_CONFIG_CACHE

        parsed: dict[int, dict[str, int | float]] = {}
        in_entry = False
        entry_depth = 0
        current_skill_id = 0
        current_row: dict[str, int | float] = {}

        for raw_line in lines:
            if not in_entry:
                open_match = _SKILL_TABLE_ENTRY_OPEN_RE.match(raw_line)
                if open_match:
                    try:
                        current_skill_id = int(open_match.group(1))
                    except Exception:
                        current_skill_id = 0
                    current_row = {}
                    in_entry = True
                    entry_depth = raw_line.count('{') - raw_line.count('}')
                    if entry_depth <= 0:
                        in_entry = False
                continue

            assign_match = _SKILL_TABLE_ASSIGN_RE.match(raw_line)
            if assign_match:
                key = assign_match.group(1)
                value_token = assign_match.group(2).strip()
                if key == 'init_number':
                    try:
                        current_row['init_number'] = int(value_token)
                    except Exception:
                        pass
                elif key == 'allow_reset_item':
                    try:
                        current_row['allow_reset_item'] = int(value_token)
                    except Exception:
                        pass
                elif key == 'cooldown_time':
                    try:
                        current_row['cooldown_time'] = float(value_token)
                    except Exception:
                        pass
                elif key == 'active_time':
                    try:
                        current_row['active_time'] = float(value_token)
                    except Exception:
                        pass

            entry_depth += raw_line.count('{') - raw_line.count('}')
            if entry_depth <= 0:
                if current_skill_id > 0:
                    parsed[current_skill_id] = {
                        'init_number': int(current_row.get('init_number', 0) or 0),
                        'allow_reset_item': int(current_row.get('allow_reset_item', 0) or 0),
                        'cooldown_time': float(current_row.get('cooldown_time', 0.0) or 0.0),
                        'active_time': float(current_row.get('active_time', 0.0) or 0.0),
                    }
                in_entry = False
                current_skill_id = 0
                current_row = {}
                entry_depth = 0

        _SKILL_RESET_CONFIG_CACHE = parsed
        return _SKILL_RESET_CONFIG_CACHE


def _resolve_character_table_path() -> Path:
    raw_path = str(
        os.getenv(
            'CHARACTER_TABLE_PATH',
            CHARACTER_TABLE_DEFAULT_PATH,
        )
        or CHARACTER_TABLE_DEFAULT_PATH
    ).strip()
    if not raw_path:
        raw_path = CHARACTER_TABLE_DEFAULT_PATH
    table_path = Path(raw_path)
    if not table_path.is_absolute():
        table_path = Path(__file__).resolve().parent / table_path
    return table_path


def _uniq_positive_ints(values: list[int]) -> list[int]:
    out: list[int] = []
    seen: set[int] = set()
    for raw_value in values:
        try:
            value = int(raw_value)
        except Exception:
            continue
        if value <= 0 or value in seen:
            continue
        seen.add(value)
        out.append(value)
    return out


def _load_character_default_skills_cache() -> dict[int, dict[str, list[int]]]:
    global _CHARACTER_DEFAULT_SKILLS_CACHE

    with _CHARACTER_DEFAULT_SKILLS_CACHE_LOCK:
        if _CHARACTER_DEFAULT_SKILLS_CACHE is not None:
            return _CHARACTER_DEFAULT_SKILLS_CACHE

        table_path = _resolve_character_table_path()
        try:
            lines = table_path.read_text(encoding='utf-8', errors='ignore').splitlines()
        except Exception:
            _CHARACTER_DEFAULT_SKILLS_CACHE = {}
            return _CHARACTER_DEFAULT_SKILLS_CACHE

        parsed: dict[int, dict[str, list[int]]] = {}
        in_entry = False
        entry_depth = 0
        current_char_id = 0
        current_main: list[int] = []
        current_sub: list[int] = []
        capture_field: str | None = None
        capture_depth = 0

        for raw_line in lines:
            if not in_entry:
                open_match = _CHARACTER_TABLE_ENTRY_OPEN_RE.match(raw_line)
                if open_match:
                    try:
                        current_char_id = int(open_match.group(1))
                    except Exception:
                        current_char_id = 0
                    current_main = []
                    current_sub = []
                    capture_field = None
                    capture_depth = 0
                    in_entry = True
                    entry_depth = raw_line.count('{') - raw_line.count('}')
                    if entry_depth <= 0:
                        in_entry = False
                continue

            if capture_field is not None:
                raw_numbers = re.findall(r'-?\d+', raw_line)
                if capture_field == 'main_skill':
                    current_main.extend(int(token) for token in raw_numbers)
                elif capture_field == 'sub_skills':
                    current_sub.extend(int(token) for token in raw_numbers)
                capture_depth += raw_line.count('{') - raw_line.count('}')
                if capture_depth <= 0:
                    capture_field = None
                    capture_depth = 0
            else:
                inline_match = _CHARACTER_TABLE_ARRAY_INLINE_RE.match(raw_line)
                if inline_match:
                    field_name = inline_match.group(1)
                    raw_numbers = re.findall(r'-?\d+', inline_match.group(2))
                    if field_name == 'main_skill':
                        current_main.extend(int(token) for token in raw_numbers)
                    else:
                        current_sub.extend(int(token) for token in raw_numbers)
                else:
                    open_array_match = _CHARACTER_TABLE_ARRAY_OPEN_RE.match(raw_line)
                    if open_array_match:
                        capture_field = open_array_match.group(1)
                        capture_depth = raw_line.count('{') - raw_line.count('}')
                        if capture_depth <= 0:
                            capture_field = None
                            capture_depth = 0

            entry_depth += raw_line.count('{') - raw_line.count('}')
            if entry_depth <= 0:
                if current_char_id > 0:
                    parsed[current_char_id] = {
                        'main_skill': _uniq_positive_ints(current_main),
                        'sub_skills': _uniq_positive_ints(current_sub),
                    }
                in_entry = False
                entry_depth = 0
                current_char_id = 0
                current_main = []
                current_sub = []
                capture_field = None
                capture_depth = 0

        _CHARACTER_DEFAULT_SKILLS_CACHE = parsed
        return _CHARACTER_DEFAULT_SKILLS_CACHE


def _get_character_default_skill_ids(character_id: int) -> list[int]:
    try:
        normalized_character_id = int(character_id)
    except Exception:
        return []
    if normalized_character_id <= 0:
        return []

    row = _load_character_default_skills_cache().get(normalized_character_id)
    if not isinstance(row, dict):
        return []
    main_values = row.get('main_skill', [])
    sub_values = row.get('sub_skills', [])
    if not isinstance(main_values, list):
        main_values = []
    if not isinstance(sub_values, list):
        sub_values = []
    return _uniq_positive_ints(list(main_values) + list(sub_values))


def _get_skill_reset_config(skill_id: int) -> dict[str, int | float] | None:
    try:
        normalized_skill_id = int(skill_id)
    except Exception:
        return None
    if normalized_skill_id <= 0:
        return None
    return _load_skill_reset_config_cache().get(normalized_skill_id)


def _session_seed_training_blocking_boards_from_manifest(
    session: 'BattleSession',
    map_id: int,
) -> int:
    rows = _get_blocking_board_seed_entries_for_map(map_id)
    if not rows:
        return 0

    seeded = 0
    for row in rows:
        board_id = int(row.get('id', 0) or 0) & 0xFFFFFFFF
        if board_id <= 0:
            continue

        manifest_profile = _resolve_blocking_board_profile_from_manifest_row(
            row,
            session.blocking_board_default_profile,
        )
        selected_profile = manifest_profile

        profile_overrides = session.game_state.get('blocking_board_profiles')
        if isinstance(profile_overrides, dict):
            raw_profile = profile_overrides.get(board_id)
            if raw_profile is None:
                raw_profile = profile_overrides.get(str(board_id))
            if raw_profile is not None:
                selected_profile = _coerce_blocking_board_profile(raw_profile, manifest_profile)

        session.blocking_board_profiles[board_id] = selected_profile

        session.blocking_board_states[board_id] = BLOCKING_BOARD_SEEDED_DEFAULT_STATE
        session.blocking_board_hp[board_id] = BLOCKING_BOARD_SEEDED_DEFAULT_HP
        session.dynamic_walls.setdefault(
            board_id,
            {
                'state': BLOCKING_BOARD_SEEDED_DEFAULT_STATE,
                'blocks': set(),
            },
        )

        anchor = row.get('anchor')
        if isinstance(anchor, tuple) and len(anchor) >= 3:
            session.blocking_board_anchor[board_id] = (
                float(anchor[0]),
                float(anchor[1]),
                float(anchor[2]),
            )

        yaw = row.get('yaw_deg')
        if isinstance(yaw, (int, float)) and math.isfinite(float(yaw)):
            session.blocking_board_yaw[board_id] = float(yaw)

        seeded += 1

    return seeded

# R6S-style per-plank board layout used for positional block selection.
#
# Doorway barricade geometry (confirmed by in-game observation):
#   - 14 horizontal planks stacked bottom-to-top, each spanning the full door width.
#   - Each plank has 3 breakable segments (left / centre / right).
#   - Total block indices: 14 x 3 = 42.
#   - block_index = row * 3 + col  (row 0 = bottom plank, row 13 = top plank)
#   - Client maps: visual_board = block // 3, visual_seg = block % 3
#   (all values are TUNABLE - update constants below if physical measurements change)
BLOCKING_BOARD_BLOCK_COLS: int = 3   # segments per plank: left / centre / right
BLOCKING_BOARD_BLOCK_ROWS: int = 14  # number of horizontal planks (0=bottom, 13=top)
BLOCKING_BOARD_BLOCK_COUNT: int = BLOCKING_BOARD_BLOCK_COLS * BLOCKING_BOARD_BLOCK_ROWS  # 42
# Physical half-width of the barricade from its horizontal centre (metres).
# Door barricade spans full door, ~1.1 m wide -> half ~ 0.55 m.        TUNABLE
BLOCKING_BOARD_HALF_WIDTH: float = 0.55
# Physical half-height of the barricade from its vertical centre (metres).
# Effective mapping half-height tuned from structured 3x3 shot traces.
BLOCKING_BOARD_HALF_HEIGHT: float = 0.60
# Horizontal bias in board-local X (metres).
BLOCKING_BOARD_LOCAL_X_BIAS: float = 0.0
# Horizontal gain applied after bias compensation. Values >1 reduce center
# dead-zone (easier side-column acquisition) while preserving symmetry.
BLOCKING_BOARD_LOCAL_X_GAIN: float = 1.22
# Vertical bias/gain calibrate board-local Y before row/index mapping.
BLOCKING_BOARD_LOCAL_Y_BIAS: float = 0.0
BLOCKING_BOARD_LOCAL_Y_GAIN: float = 1.0
# Mapping calibration: client matrix uses board numbers top->bottom.
BLOCKING_BOARD_ROW_TOP_DOWN: bool = True
# Mapping calibration: mirror horizontal axis so segment #1 is the visual left.
BLOCKING_BOARD_COL_MIRROR: bool = True
# Optional side-aware flip: when shot comes from the opposite side of board normal,
# invert horizontal mapping so visual left/right remains stable from shooter side.
try:
    BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE = (
        str(os.getenv('BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE', '1') or '1')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE = True
# Asset-layout (nearest-center in object-local index space) usually should not
# flip by hit side; keep this opt-in and separate from grid behavior.
try:
    BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE = (
        str(os.getenv('BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE', '0') or '0')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE = False
# Maximum newly broken segments per one shotgun request.
# Behaviour target: 1 impact center + up to 3 nearest neighbours.
BLOCKING_BOARD_MAX_NEW_SEGMENTS_PER_SHOTGUN: int = 4
# Maximum newly broken segments per one explosion request.
# Behaviour target: compact hole, not random scattered segments.
BLOCKING_BOARD_MAX_NEW_SEGMENTS_PER_EXPLOSION: int = 8
try:
    BLOCKING_BOARD_SEQUENTIAL_FALLBACK_WITHOUT_PART_INDEX = (
        str(
            os.getenv(
                'BLOCKING_BOARD_SEQUENTIAL_FALLBACK_WITHOUT_PART_INDEX',
                '1',
            )
            or '1'
        )
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_SEQUENTIAL_FALLBACK_WITHOUT_PART_INDEX = True
try:
    # Seed entries from map manifests describe anchor slots where a barricade can be
    # placed; they are not guaranteed to be spawned at round start.
    BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE = (
        str(os.getenv('BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE', '0') or '0')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE = False
BLOCKING_BOARD_SEEDED_DEFAULT_STATE: int = (
    BLOCKING_BOARD_STATE_FORWARD
    if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE
    else BLOCKING_BOARD_STATE_DEACTIVE
)
BLOCKING_BOARD_SEEDED_DEFAULT_HP: float = (
    1.0
    if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE
    else 0.0
)
try:
    BLOCKING_BOARD_COMPAT_EMIT_CONTENT_EVENT_FOR_PREPLACED = (
        str(
            os.getenv(
                'BLOCKING_BOARD_COMPAT_EMIT_CONTENT_EVENT_FOR_PREPLACED',
                '1',
            )
            or '1'
        )
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_COMPAT_EMIT_CONTENT_EVENT_FOR_PREPLACED = True
try:
    BLOCKING_BOARD_SERVER_LIKE_STRICT_MODE = (
        str(os.getenv('BLOCKING_BOARD_SERVER_LIKE_STRICT_MODE', '1') or '1')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    BLOCKING_BOARD_SERVER_LIKE_STRICT_MODE = True
# Client expects content-destroy event for preplaced boards too; keep dual-emit
# controlled by explicit compat flag even in strict server-like mode.
BLOCKING_BOARD_COMPAT_PREPLACED_CONTENT_EVENT_ENABLED = (
    BLOCKING_BOARD_COMPAT_EMIT_CONTENT_EVENT_FOR_PREPLACED
)
# Board-selection margins (profile-scaled); lower value = stricter confidence.
BLOCKING_BOARD_SELECTION_RAY_X_MARGIN: float = 1.25
BLOCKING_BOARD_SELECTION_RAY_Y_MARGIN: float = 1.35
BLOCKING_BOARD_SELECTION_SOURCE_X_MARGIN: float = 1.45
BLOCKING_BOARD_SELECTION_SOURCE_Y_MARGIN: float = 1.55
# Source-only approximation is allowed only within this normalized penalty.
# penalty = |x|/(half_width*x_margin) + |y|/(half_height*y_margin)
BLOCKING_BOARD_SOURCE_APPROX_MAX_PENALTY: float = 2.35
BLOCKING_BOARD_SOURCE_APPROX_REQUIRE_CONFIDENCE: bool = BLOCKING_BOARD_SERVER_LIKE_STRICT_MODE
# Require non-distance evidence (ray/source local confidence) when several
# boards are seeded and strict server-like mode is enabled.
BLOCKING_BOARD_SELECTION_REQUIRE_CONFIDENCE: bool = BLOCKING_BOARD_SERVER_LIKE_STRICT_MODE
# Ignore anchors far away by height when selecting nearest board without explicit id.
# Prevents cross-floor mis-targeting after map-wide seed expansion.
BLOCKING_BOARD_MAX_ANCHOR_Y_DELTA: float = 6.0
# Probe points sampled along bullet rays when client doesn't provide explicit target id.
BLOCKING_BOARD_RAY_PROBE_DISTANCES: tuple[float, ...] = (2.0, 4.0, 8.0, 12.0, 16.0)
# Max anchor distance (squared) for implicit board selection by source/ray probe points.
BLOCKING_BOARD_SELECTION_MAX_DIST_SQ: float = 1024.0
# Offset from anchor Y (placement point = player feet / floor level) to the
# barricade vertical centre.
# Empirically tuned from structured 3x3 matrix tests so top/middle/bottom
# target rows map to expected board indices.
BLOCKING_BOARD_ANCHOR_TO_CENTER_Y: float = 1.37

# Wall-channel recovery/snapshot compatibility:
# Some client flows do not request ReqWallInfo/ReqDynamicWallInfo explicitly
# before first wall hit; proactively pushing snapshots keeps wall runtime in sync.
try:
    WALL_DAMAGE_PUSH_SNAPSHOT_PACKETS = (
        str(os.getenv('WALL_DAMAGE_PUSH_SNAPSHOT_PACKETS', '1') or '1')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    WALL_DAMAGE_PUSH_SNAPSHOT_PACKETS = True

try:
    WALL_RECOVER_PUSH_SNAPSHOT_PACKETS = (
        str(os.getenv('WALL_RECOVER_PUSH_SNAPSHOT_PACKETS', '1') or '1')
        .strip()
        .lower()
        not in {'0', 'false', 'no', 'off'}
    )
except Exception:
    WALL_RECOVER_PUSH_SNAPSHOT_PACKETS = True


def _coerce_blocking_board_profile(value: object, fallback: BlockingBoardProfile) -> BlockingBoardProfile:
    if isinstance(value, BlockingBoardProfile):
        return value
    if not isinstance(value, dict):
        return fallback

    def _pick_int(name: str, default: int) -> int:
        try:
            raw = value.get(name, default)
            if raw is None:
                return int(default)
            return int(raw)
        except Exception:
            return int(default)

    def _pick_float(name: str, default: float) -> float:
        try:
            raw = value.get(name, default)
            if raw is None:
                return float(default)
            return float(raw)
        except Exception:
            return float(default)

    def _pick_bool(name: str, default: bool) -> bool:
        raw = value.get(name, default)
        if isinstance(raw, bool):
            return raw
        if raw is None:
            return bool(default)
        if isinstance(raw, (int, float)):
            return bool(raw)
        if isinstance(raw, str):
            return raw.strip().lower() in {'1', 'true', 'yes', 'on'}
        return bool(default)

    return BlockingBoardProfile(
        rows=max(1, _pick_int('rows', fallback.rows)),
        cols=max(1, _pick_int('cols', fallback.cols)),
        half_width=max(1e-6, _pick_float('half_width', fallback.half_width)),
        half_height=max(1e-6, _pick_float('half_height', fallback.half_height)),
        local_x_bias=_pick_float('local_x_bias', fallback.local_x_bias),
        local_x_gain=max(1e-6, _pick_float('local_x_gain', fallback.local_x_gain)),
        local_y_bias=_pick_float('local_y_bias', fallback.local_y_bias),
        local_y_gain=max(1e-6, _pick_float('local_y_gain', fallback.local_y_gain)),
        local_y_metric_weight=max(1e-6, _pick_float('local_y_metric_weight', fallback.local_y_metric_weight)),
        row_top_down=_pick_bool('row_top_down', fallback.row_top_down),
        col_mirror=_pick_bool('col_mirror', fallback.col_mirror),
        anchor_to_center_y=_pick_float('anchor_to_center_y', fallback.anchor_to_center_y),
        name=str(value.get('name', fallback.name) or fallback.name),
    )


def _is_board_id_in_collection(collection: object, board_id: int) -> bool:
    if collection is None:
        return False
    try:
        if isinstance(collection, dict):
            if board_id in collection:
                return True
            return str(board_id) in collection
        if isinstance(collection, (set, list, tuple)):
            return any(int(item) == int(board_id) for item in collection)
    except Exception:
        return False
    return False


def _profile_name(profile: BlockingBoardProfile) -> str:
    return profile.name or 'door'


def _get_blocking_board_layout_centers(profile: BlockingBoardProfile) -> BlockingBoardCenters | None:
    key = _normalize_blocking_board_profile_name(_profile_name(profile)) or ''
    centers = _BLOCKING_BOARD_PROFILE_LAYOUT_CENTERS.get(key)
    if centers is not None:
        return centers
    alias = _BLOCKING_BOARD_LAYOUT_PROFILE_ALIASES.get(key)
    if alias is None:
        return None
    return _BLOCKING_BOARD_PROFILE_LAYOUT_CENTERS.get(alias)


def _get_blocking_board_layout_row_bands(profile: BlockingBoardProfile) -> BlockingBoardRowBands | None:
    key = _normalize_blocking_board_profile_name(_profile_name(profile)) or ''
    bands = _BLOCKING_BOARD_PROFILE_LAYOUT_ROW_BANDS.get(key)
    if bands is not None:
        return bands
    alias = _BLOCKING_BOARD_LAYOUT_PROFILE_ALIASES.get(key)
    if alias is None:
        return None
    return _BLOCKING_BOARD_PROFILE_LAYOUT_ROW_BANDS.get(alias)


def _get_blocking_board_effective_count(profile: BlockingBoardProfile) -> int:
    centers = _get_blocking_board_layout_centers(profile)
    if centers:
        return len(centers)
    return profile.block_count

# Default battle-stage timers (milliseconds) for stage-sync packet (RspGameStage, 0x63).
DEFAULT_STAGE_TOTAL_MS = 180_000
TRAINING_STAGE_TOTAL_MS = 1_800_000


def _is_training_mode_game_state(game_state: dict | None) -> bool:
    if not isinstance(game_state, dict):
        return False
    try:
        return int(game_state.get('mode_id', 0)) == 3
    except Exception:
        return False


def _is_guide_mode_game_state(game_state: dict | None) -> bool:
    if not isinstance(game_state, dict):
        return False
    try:
        return int(game_state.get('mode_id', 0)) == 2
    except Exception:
        return False


def _should_seed_blocking_boards(game_state: dict | None) -> bool:
    # Barricade/wall interactions are required in both guide and training flows.
    return _is_training_mode_game_state(game_state) or _is_guide_mode_game_state(game_state)


def _critical_region_state_for_player_camp(camp: int) -> int:
    """Choose critical-region state that matches local camp in single-player training."""
    try:
        camp_int = int(camp)
    except Exception:
        camp_int = BATTLE_CAMP_NO_CAMP
    if camp_int == BATTLE_CAMP_ATTACKER:
        return CRITICAL_REGION_STATE_ONLY_ATTACKERS
    if camp_int == BATTLE_CAMP_DEFENDER:
        return CRITICAL_REGION_STATE_ONLY_DEFENDERS
    return CRITICAL_REGION_STATE_BOTH_PLAYERS


def _default_training_spawn_region_for_camp(camp: int) -> int:
    """Canonical training pre-battle spawn slot default by camp."""
    try:
        camp_int = int(camp)
    except Exception:
        camp_int = BATTLE_CAMP_ATTACKER
    if camp_int == BATTLE_CAMP_ATTACKER:
        # Attacker default is the top entry in spawn list.
        return 255
    if camp_int == BATTLE_CAMP_DEFENDER:
        # Defender defaults to first floor slot entry.
        return 0
    return 0


def _resolve_stage_total_ms(game_state: dict | None) -> int:
    if _is_training_mode_game_state(game_state):
        return TRAINING_STAGE_TOTAL_MS
    return DEFAULT_STAGE_TOTAL_MS


def _resolve_stage_sync_payload(
    *,
    session: 'BattleSession | None',
    game_state: dict | None,
    game_stage: int,
) -> tuple[int, int, int]:
    """Build (timestamp, total_time, remain_time) for RspGameStage."""
    now_ts = int(time.time())
    total_ms = max(1, int(_resolve_stage_total_ms(game_state)))
    remain_ms = total_ms

    if game_stage == GAME_STAGE_BATTLE and session is not None:
        started_at = session._battle_stage_started_at
        if isinstance(started_at, (int, float)) and started_at > 0:
            elapsed_ms = max(0, int((time.time() - float(started_at)) * 1000.0))
            remain_ms = max(0, total_ms - elapsed_ms)

    return now_ts, total_ms, remain_ms


KNOWN_BATTLE_PACKET_IDS: set[int] = {
    value for name, value in globals().items()
    if name.startswith('PKT_') and isinstance(value, int)
}

BATTLE_PACKET_REGISTRY = PacketRegistry.from_namespace(globals(), name_prefix='PKT_')

def _register_schema_descriptors(
    registry: PacketRegistry,
    descriptor_specs: list[dict[str, object]],
    namespace: dict[str, object],
):
    for spec in descriptor_specs:
        packet_const = str(spec.get('packet_const') or '').strip()
        packet_id = int(spec.get('packet_id') or 0)

        if packet_const:
            expected_packet_id = namespace.get(packet_const)
            if isinstance(expected_packet_id, int) and expected_packet_id != packet_id:
                raise RuntimeError(
                    f"descriptor drift for {packet_const}: "
                    f"schema={packet_id} code={expected_packet_id}"
                )

        registry.register(PacketDescriptor(
            packet_id=packet_id,
            name=str(spec.get('name') or packet_const or f"pkt_0x{packet_id:X}"),
            phase=str(spec.get('phase') or 'any'),
            notes=str(spec.get('notes') or ''),
            parser_key=str(spec.get('packet_class') or ''),
            handler_key=str(spec.get('handler_key') or ''),
        ))


_register_schema_descriptors(
    BATTLE_PACKET_REGISTRY,
    BATTLE_V2_DESCRIPTOR_SPECS,
    globals(),
)

BATTLE_OVERLAP_PHASE_REQUIREMENTS: dict[int, dict[str, str | None]] = {
    PKT_REQ_PING: {
        'loading': 'ReqPing',
        'gameplay': 'ReqCharacterPose',
    },
    PKT_RSP_PING: {
        'loading': 'RspPing',
        'gameplay': 'RspCharacterPose',
    },
}

BATTLE_HOT_PATH_PACKET_IDS: set[int] = {
    PKT_REQ_PING,
    PKT_RSP_PING,
    PKT_REQ_CHARACTER_POSE,
    PKT_RSP_CHARACTER_POSE,
    PKT_REQ_CHARACTER_STATE,
    PKT_RSP_CHARACTER_STATE,
    PKT_REQ_CHARACTER_GUN_FIRE,
    PKT_RSP_EVENT_CHARACTER_GUN_FIRE,
    PKT_REQ_SYNC_CHARACTER_ACTION,
    PKT_RSP_SYNC_CHARACTER_ACTION,
    PKT_REQ_THROW_SCENE_TOOL,
    PKT_REQ_SYNC_THROW_SCENE_TOOL_POSITION,
    PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION,
    PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION_WITH_RELATION,
    PKT_REQ_SWITCH_CURRENT_UNMANNED_VEHICLE,
    PKT_REQ_UNMANNED_VEHICLE_SPAWN,
    PKT_REQ_UNMANNED_VEHICLE_POSE_DELTA,
    PKT_REQ_ENTER_BATTLE,
    PKT_RSP_BATTLE_ID,
    PKT_RSP_ROOM_LOADING,
    PKT_REQ_LOAD_PROGRESS,
    PKT_RSP_LOAD_PROGRESS,
    PKT_REQ_ROOM_LOADED,
    PKT_RSP_BATTLE_LOAD_OK,
    PKT_RSP_GAME_START,
    PKT_VERSION,
    PKT_HEARTBEAT,
    PKT_REQ_RESET_ITEM_NUM,
}

def _descriptor_required_ids_by_phase(phase: str) -> set[int]:
    raw = BATTLE_V2_DESCRIPTOR_REQUIRED_IDS_BY_PHASE.get(phase, [])
    out: set[int] = set()
    if isinstance(raw, list):
        for value in raw:
            out.add(int(value))
    return out


BATTLE_V2_LOADING_HANDLER_REQUIRED_IDS: set[int] = _descriptor_required_ids_by_phase('loading')
BATTLE_V2_GAMEPLAY_HANDLER_REQUIRED_IDS: set[int] = _descriptor_required_ids_by_phase('gameplay')
BATTLE_V2_ANY_HANDLER_REQUIRED_IDS: set[int] = _descriptor_required_ids_by_phase('any')

BATTLE_V2_STRICT_HOTPATH_REQUIRED_IDS: set[int] = (
    set(BATTLE_V2_LOADING_HANDLER_REQUIRED_IDS)
    | set(BATTLE_V2_GAMEPLAY_HANDLER_REQUIRED_IDS)
    | set(BATTLE_V2_ANY_HANDLER_REQUIRED_IDS)
)

REGISTRY_MISSING_IDS, REGISTRY_EXTRA_IDS = BATTLE_PACKET_REGISTRY.lint_coverage(KNOWN_BATTLE_PACKET_IDS)
HOT_PATH_MISSING_IDS = BATTLE_HOT_PATH_PACKET_IDS - BATTLE_PACKET_REGISTRY.unique_packet_ids()
REGISTRY_PHASE_ISSUES = BATTLE_PACKET_REGISTRY.lint_phase_requirements(
    BATTLE_OVERLAP_PHASE_REQUIREMENTS
)
BATTLE_V2_LOADING_HANDLER_MISSING_IDS = BATTLE_PACKET_REGISTRY.lint_handler_bindings(
    BATTLE_V2_LOADING_HANDLER_REQUIRED_IDS,
    phase='loading',
)
BATTLE_V2_GAMEPLAY_HANDLER_MISSING_IDS = BATTLE_PACKET_REGISTRY.lint_handler_bindings(
    BATTLE_V2_GAMEPLAY_HANDLER_REQUIRED_IDS,
    phase='gameplay',
)
BATTLE_V2_ANY_HANDLER_MISSING_IDS = BATTLE_PACKET_REGISTRY.lint_handler_bindings(
    BATTLE_V2_ANY_HANDLER_REQUIRED_IDS,
    phase='any',
)
BATTLE_PARSER_V2 = os.getenv('BATTLE_PARSER_V2', '1').strip().lower() in (
    '1', 'true', 'yes', 'on'
)
BATTLE_PARSER_V2_STRICT_HOTPATH = os.getenv(
    'BATTLE_PARSER_V2_STRICT_HOTPATH',
    '1',
).strip().lower() in (
    '1', 'true', 'yes', 'on'
)
BATTLE_SERVER_BUILD_TAG = os.getenv(
    'BATTLE_SERVER_BUILD_TAG',
    '2026-05-21-disconnect-diagnostics-v1',
).strip()
BATTLE_HEARTBEAT_STAGE_KEEPALIVE = os.getenv(
    'BATTLE_HEARTBEAT_STAGE_KEEPALIVE',
    '1',
).strip().lower() in (
    '1', 'true', 'yes', 'on'
)
try:
    BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY = int(
        (os.getenv('BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY', '15') or '15').strip() or '15'
    )
except Exception:
    BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY = 15
if BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY <= 0:
    BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY = 15


def _is_v2_required_packet(pkt_id: int, phase: str) -> bool:
    packet_id = int(pkt_id)
    if packet_id in BATTLE_V2_ANY_HANDLER_REQUIRED_IDS:
        return True
    if phase == 'loading':
        return packet_id in BATTLE_V2_LOADING_HANDLER_REQUIRED_IDS
    if phase == 'gameplay':
        return packet_id in BATTLE_V2_GAMEPLAY_HANDLER_REQUIRED_IDS
    return packet_id in BATTLE_V2_STRICT_HOTPATH_REQUIRED_IDS


def _score_next_boundary(data: bytes, offset: int) -> int:
    """Heuristic score for a candidate packet boundary in a raw TCP buffer."""
    if offset == len(data):
        return 2
    if offset > len(data):
        return -2
    try:
        next_id, _ = cuint_decode(data, offset)
    except (IndexError, KeyError):
        return 0
    return 2 if next_id in KNOWN_BATTLE_PACKET_IDS else -1


def _select_req_0x01_variant(stream: InputStream, in_gameplay_phase: bool) -> str:
    """Disambiguate overlapping id=0x01 (ReqPing vs ReqCharacterPose)."""
    start = stream.pos
    data = stream._data
    remaining = len(data) - start

    ping_ok = remaining >= 4
    pose_ok = False
    pose_body_len = 0

    if remaining >= 5:
        # ReqCharacterPose = u32 timestamp + BattleCharacterPoseDelta.
        # Delta starts with u8 flags where only bits 0..5 are valid.
        flags = data[start + 4]
        if (flags & 0xC0) == 0:
            pose_body_len = 4 + 1 + 4 * ((flags & 0x3F).bit_count())
            pose_ok = remaining >= pose_body_len

    if not ping_ok and not pose_ok:
        raise NeedMoreData("incomplete id=0x01 packet body")

    # During loading/pre-battle, prefer ping. In gameplay, prefer pose.
    # If both shapes are possible in the current merged TCP buffer,
    # compare which candidate leaves a more plausible next packet boundary.
    if ping_ok and not pose_ok:
        return 'ping'
    if pose_ok and not ping_ok:
        return 'pose'

    ping_score = _score_next_boundary(data, start + 4)
    pose_score = _score_next_boundary(data, start + pose_body_len)

    if pose_score > ping_score:
        return 'pose'
    if ping_score > pose_score:
        return 'ping'
    return 'pose' if in_gameplay_phase else 'ping'


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Packet builders (server в†’ client)
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

def build_packet(pkt_id: int, body: bytes) -> bytes:
    """Build a complete wire packet: compressed_uint(id) + body."""
    return cuint_encode(pkt_id) + body


def _try_decode_pkt_id_from_frame(data: bytes) -> int | None:
    """Best-effort packet-id decode for outbound diagnostics."""
    if not data:
        return None
    try:
        pkt_id, _ = cuint_decode(bytes(data), 0)
        return int(pkt_id)
    except Exception:
        return None


def build_pkt_heartbeat() -> bytes:
    """Heartbeat packet has empty payload (pkt_id=0x7D0)."""
    return build_packet(PKT_HEARTBEAT, b'')


def _send_heartbeat_echo(sock: socket.socket) -> bool:
    """Best-effort heartbeat echo used to satisfy client watchdog timers."""
    try:
        sock.sendall(build_pkt_heartbeat())
        return True
    except Exception:
        return False


def build_rsp_ping(timestamp: int) -> bytes:
    out = OutputStream()
    out.write_u32(timestamp)
    return build_packet(PKT_RSP_PING, out.get_bytes())


def build_rsp_room_loading(
    my_team: int,        # BattleTeam enum (u8): 1=blue, 2=orange
    combat_type: int,    # u32
    map_id: int,         # u32
    mode_id: int,        # u32
    attacker_list: list[dict],  # list of CharacterInfo dicts
    defender_list: list[dict],  # list of CharacterInfo dicts
    round_num: int = 1,  # u8
    guide_id: int | None = None,   # optional u32
    critical_region_id: int | None = None,  # optional u32
) -> bytes:
    out = OutputStream()

    # Flags byte: bit0 = guide_id present, bit1 = critical_region_id present
    flags = 0
    if guide_id is not None:
        flags |= 1
    if critical_region_id is not None:
        flags |= 2
    out.write_u8(flags)

    # enum_type<BattleTeam, u8>
    out.write_u8(my_team)

    # u32 combat_type, map_id, mode_id
    out.write_u32(combat_type)
    out.write_u32(map_id)
    out.write_u32(mode_id)

    # optional guide_id
    if guide_id is not None:
        out.write_u32(guide_id)

    # vector<CharacterInfo> attacker
    _write_character_info_vector(out, attacker_list)
    # vector<CharacterInfo> defender
    _write_character_info_vector(out, defender_list)

    # optional critical_region_id
    if critical_region_id is not None:
        out.write_u32(critical_region_id)

    # u8 round
    out.write_u8(round_num)

    return build_packet(PKT_RSP_ROOM_LOADING, out.get_bytes())


def _write_character_info_vector(out: OutputStream, chars: list[dict]):
    """Write vector<CharacterInfo> to stream."""
    out.write_cuint(len(chars))
    for c in chars:
        _write_character_info(out, c)


def _write_character_info(out: OutputStream, c: dict):
    """Write a single CharacterInfo to stream.

    Matches proto.common.CharacterInfo._output optional flags:
      bit0 acc_id, bit1 npc_id, bit2 team, bit3 region_id, bit4 is_have_defuser.
    Required fields are serialized regardless of defaults.
    """
    acc_id = c.get('acc_id')
    npc_id = c.get('npc_id')
    team = c.get('team')
    region_id = c.get('region_id')
    is_have_defuser = c.get('is_have_defuser')

    flags = 0
    if acc_id is not None:
        flags |= 1
    if npc_id is not None:
        flags |= 2
    if team is not None:
        flags |= 4
    if region_id is not None:
        flags |= 8
    if is_have_defuser is not None:
        flags |= 0x10
    out.write_u8(flags)

    if acc_id is not None:
        out.write_u32(int(acc_id))
    if npc_id is not None:
        out.write_s32(int(npc_id))

    out.write_u8(c.get('bid', 0))
    if team is not None:
        out.write_u8(int(team))
    out.write_u8(c.get('camp', 1))
    out.write_str8(c.get('name', ''))

    # Transform: Quaternion(x,y,z,w) + Vector3(x,y,z)
    rot = c.get('rotation', (0.0, 0.0, 0.0, 1.0))
    pos = c.get('position', (0.0, 1.0, 0.0))
    for v in rot:
        out.write_f32(v)
    for v in pos:
        out.write_f32(v)

    out.write_u32(c.get('character_id', 1001))

    # vector<u32> skins
    skins = c.get('skins', [])
    out.write_cuint(len(skins))
    for s in skins:
        out.write_u32(s)

    # Weapon primary
    _write_weapon(out, c.get('primary_weapon', {}))
    # Weapon secondary
    _write_weapon(out, c.get('secondary_weapon', {}))

    out.write_u32(c.get('main_skill_id', 0))
    out.write_u32(c.get('sub_skill_id', 0))
    if region_id is not None:
        out.write_u32(int(region_id))
    if is_have_defuser is not None:
        out.write_bool(bool(is_have_defuser))
    out.write_bool(c.get('is_loaded', False))


def _write_weapon(out: OutputStream, w: dict):
    """Write Weapon: u32 id, u32 skin, vector<SCAttachment> attachments."""
    out.write_u32(w.get('id', 0))
    out.write_u32(w.get('skin', 0))
    raw_attachments = w.get('attachments', [])
    attachments: list[dict] = []
    if isinstance(raw_attachments, list):
        for att in raw_attachments:
            if not isinstance(att, dict):
                continue
            att_id = int(att.get('id', 0) or 0)
            # Skip prebattle placeholder attachment (id=0, kind=0) in battle payload.
            if att_id <= 0:
                continue
            attachments.append(att)
    out.write_cuint(len(attachments))
    for att in attachments:
        # proto.common.SCAttachment optional flags: bit0 = skin present.
        att_id = int(att.get('id', 0) or 0)
        att_skin = att.get('skin')
        if att_skin is not None:
            att_skin = int(att_skin)
        att_flags = 1 if att_skin is not None else 0
        out.write_u8(att_flags)
        out.write_u32(int(att_id))
        if att_skin is not None:
            out.write_u32(int(att_skin))


def build_rsp_game_start(timestamp: int) -> bytes:
    out = OutputStream()
    out.write_u32(timestamp)
    return build_packet(PKT_RSP_GAME_START, out.get_bytes())


def build_rsp_game_stage(
    *,
    timestamp: int,
    game_stage: int,
    total_time: int,
    remain_time: int,
) -> bytes:
    out = OutputStream()
    out.write_u32(int(timestamp) & 0xFFFFFFFF)
    out.write_u8(int(game_stage) & 0xFF)
    out.write_u32(int(total_time) & 0xFFFFFFFF)
    out.write_u32(int(remain_time) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_GAME_STAGE, out.get_bytes())


def build_rsp_spawn_bomb_region(region_ids: list[int]) -> bytes:
    out = OutputStream()
    out.write_cuint(len(region_ids))
    for rid in region_ids:
        out.write_u32(int(rid) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_SPAWN_BOMB_REGION, out.get_bytes())


def build_rsp_critical_region_state(state: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(state) & 0xFF)
    return build_packet(PKT_RSP_CRITICAL_REGION_STATE, out.get_bytes())


def build_rsp_vehicle_born_place(born_place_id: int) -> bytes:
    out = OutputStream()
    out.write_u32(int(born_place_id) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_VEHICLE_BORN_PLACE, out.get_bytes())


def build_rsp_battle_load_success(bid: int = 0) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    return build_packet(PKT_RSP_BATTLE_LOAD_OK, out.get_bytes())


def build_rsp_battle_id(battle_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(battle_id)
    return build_packet(PKT_RSP_BATTLE_ID, out.get_bytes())


def build_rsp_game_info(battle_id: int, game_stage: int | None = None) -> bytes:
    out = OutputStream()
    has_game_stage = game_stage is not None
    out.write_u8(0x01 if has_game_stage else 0x00)
    out.write_u32(int(battle_id) & 0xFFFFFFFF)
    if has_game_stage:
        out.write_u8(int(game_stage) & 0xFF)
    return build_packet(PKT_RSP_GAME_INFO, out.get_bytes())


def build_rsp_battle_over(reason: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(reason) & 0xFF)
    return build_packet(PKT_RSP_BATTLE_OVER, out.get_bytes())


def build_rsp_battle_result(
    reason: int,
    win_camp: int = BATTLE_CAMP_NO_CAMP,
    replay_bid: int = 0,
    winners_rank: list[int] | None = None,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(reason) & 0xFF)
    out.write_u8(int(win_camp) & 0xFF)
    out.write_u8(int(replay_bid) & 0xFF)
    rank_values = winners_rank or []
    out.write_cuint(len(rank_values))
    for rank in rank_values:
        out.write_u32(int(rank))
    return build_packet(PKT_RSP_BATTLE_RESULT, out.get_bytes())


def build_rsp_reset_all_weapon_item_num() -> bytes:
    return build_packet(PKT_RSP_RESET_ALL_WEAPON_ITEM_NUM, b'')


def build_rsp_reset_gun_config(config_id: int = 0) -> bytes:
    out = OutputStream()
    out.write_u32(int(config_id) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_RESET_GUN_CONFIG, out.get_bytes())


def build_rsp_reset_effect_config(config_id: int = 0) -> bytes:
    out = OutputStream()
    out.write_u32(int(config_id) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_RESET_EFFECT_CONFIG, out.get_bytes())


def build_rsp_load_progress(bid: int, progress: float) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_f32(progress)
    return build_packet(PKT_RSP_LOAD_PROGRESS, out.get_bytes())


def _read_vector3(stream: InputStream) -> tuple[float, float, float]:
    return (stream.read_f32(), stream.read_f32(), stream.read_f32())


def _write_vector3(out: OutputStream, v: tuple[float, float, float]):
    out.write_f32(float(v[0]))
    out.write_f32(float(v[1]))
    out.write_f32(float(v[2]))


def _read_quaternion(stream: InputStream) -> tuple[float, float, float, float]:
    return (stream.read_f32(), stream.read_f32(), stream.read_f32(), stream.read_f32())


def _read_battle_jump_on(stream: InputStream) -> dict:
    # proto.common.BattleCharacterJumpOn
    return {
        'pos': _read_vector3(stream),
    }


def _write_battle_jump_on(out: OutputStream, data: dict):
    _write_vector3(out, data.get('pos', (0.0, 0.0, 0.0)))


def _read_battle_jump_over(stream: InputStream) -> dict:
    # proto.common.BattleCharacterJumpOver
    return {
        'p1': _read_vector3(stream),
        'p2': _read_vector3(stream),
        'target': _read_vector3(stream),
    }


def _read_battle_leave_wall_space_by_window(stream: InputStream) -> dict:
    # proto.common.BattleCharacterLeaveWallSpaceByWindow
    return {
        'body_state': stream.read_u8(),
        'target': _read_vector3(stream),
        'point': _read_vector3(stream),
    }


def _write_battle_leave_wall_space_by_window(out: OutputStream, data: dict):
    out.write_u8(int(data.get('body_state', 0)) & 0xFF)
    _write_vector3(out, data.get('target', (0.0, 0.0, 0.0)))
    _write_vector3(out, data.get('point', (0.0, 0.0, 0.0)))


def _read_scan_enemy_info(stream: InputStream) -> dict:
    # proto.common.ScanEnemyInfo
    return {
        'bid': stream.read_u8(),
        'name': stream.read_str8(),
        'pos': _read_vector3(stream),
    }


def _write_scan_enemy_info(out: OutputStream, data: dict):
    out.write_u8(int(data.get('bid', 0)) & 0xFF)
    out.write_str8(str(data.get('name', '')))
    _write_vector3(out, data.get('pos', (0.0, 0.0, 0.0)))


def _read_transform(stream: InputStream) -> dict:
    # proto.common.Transform
    return {
        'rotation': _read_quaternion(stream),
        'position': _read_vector3(stream),
    }


def _write_quaternion(out: OutputStream, q: tuple[float, float, float, float]):
    out.write_f32(float(q[0]))
    out.write_f32(float(q[1]))
    out.write_f32(float(q[2]))
    out.write_f32(float(q[3]))


def _write_transform(out: OutputStream, transform: dict):
    _write_quaternion(out, transform.get('rotation', (0.0, 0.0, 0.0, 1.0)))
    _write_vector3(out, transform.get('position', (0.0, 0.0, 0.0)))


def _read_u64_vector(stream: InputStream) -> list[int]:
    count = stream.read_cuint()
    return [stream.read_u64() for _ in range(count)]


def _write_u64_vector(out: OutputStream, values: list[int]):
    out.write_cuint(len(values))
    for v in values:
        out.write_u64(int(v))


def _read_u32_vector(stream: InputStream) -> list[int]:
    count = stream.read_cuint()
    return [stream.read_u32() for _ in range(count)]


def _write_u32_vector(out: OutputStream, values: list[int]):
    out.write_cuint(len(values))
    for v in values:
        out.write_u32(int(v))


def _write_u16_vector(out: OutputStream, values: list[int]):
    out.write_cuint(len(values))
    for v in values:
        out.write_u16(int(v) & 0xFFFF)


def _write_u8_vector(out: OutputStream, values: list[int]):
    out.write_cuint(len(values))
    for v in values:
        out.write_u8(int(v) & 0xFF)


def _write_cuint_vector(out: OutputStream, values: list[int]):
    out.write_cuint(len(values))
    for v in values:
        out.write_cuint(int(v) & 0xFFFFFFFF)


def _read_f32_vector(stream: InputStream) -> list[float]:
    count = stream.read_cuint()
    return [stream.read_f32() for _ in range(count)]


def _write_f32_vector(out: OutputStream, values: list[float]):
    out.write_cuint(len(values))
    for v in values:
        out.write_f32(float(v))


def _read_perform_data(stream: InputStream) -> dict:
    flags = stream.read_u8()
    data: dict = {'flags': flags}
    if flags & 0x01:
        data['u64_data'] = _read_u64_vector(stream)
    if flags & 0x02:
        data['f32_data'] = _read_f32_vector(stream)
    return data


def _write_perform_data(out: OutputStream, data: dict):
    flags = int(data.get('flags', 0))
    if flags == 0:
        if 'u64_data' in data:
            flags |= 0x01
        if 'f32_data' in data:
            flags |= 0x02
    out.write_u8(flags)
    if flags & 0x01:
        _write_u64_vector(out, data.get('u64_data', []))
    if flags & 0x02:
        _write_f32_vector(out, data.get('f32_data', []))


def _read_lerp_data(stream: InputStream) -> dict:
    # proto.common.LerpData uses two flags bytes for optional transform fields.
    flags1 = stream.read_u8()
    flags2 = stream.read_u8()
    data: dict = {
        'flags1': flags1,
        'flags2': flags2,
        'duration': stream.read_f32(),
    }
    if flags1 & 0x01:
        data['char_pos_with_eyes_world'] = _read_vector3(stream)
    if flags1 & 0x02:
        data['char_rot_with_eyes_world'] = _read_quaternion(stream)
    if flags1 & 0x04:
        data['eyes_coord_with_eyes_world'] = _read_quaternion(stream)
    if flags1 & 0x08:
        data['eyes_pos'] = _read_vector3(stream)
    if flags1 & 0x10:
        data['eyes_rot'] = _read_quaternion(stream)
    if flags1 & 0x20:
        data['char_pos_with_eyes_local'] = _read_vector3(stream)
    if flags1 & 0x40:
        data['char_rot_with_eyes_local'] = _read_quaternion(stream)
    if flags1 & 0x80:
        data['eyes_coord_with_eyes_local'] = _read_quaternion(stream)
    if flags2 & 0x01:
        data['eyes_local_pos'] = _read_vector3(stream)
    if flags2 & 0x02:
        data['eyes_local_rot'] = _read_quaternion(stream)
    return data


def _write_lerp_data(out: OutputStream, data: dict):
    flags1 = int(data.get('flags1', 0))
    flags2 = int(data.get('flags2', 0))
    if flags1 == 0 and flags2 == 0:
        if 'char_pos_with_eyes_world' in data:
            flags1 |= 0x01
        if 'char_rot_with_eyes_world' in data:
            flags1 |= 0x02
        if 'eyes_coord_with_eyes_world' in data:
            flags1 |= 0x04
        if 'eyes_pos' in data:
            flags1 |= 0x08
        if 'eyes_rot' in data:
            flags1 |= 0x10
        if 'char_pos_with_eyes_local' in data:
            flags1 |= 0x20
        if 'char_rot_with_eyes_local' in data:
            flags1 |= 0x40
        if 'eyes_coord_with_eyes_local' in data:
            flags1 |= 0x80
        if 'eyes_local_pos' in data:
            flags2 |= 0x01
        if 'eyes_local_rot' in data:
            flags2 |= 0x02

    out.write_u8(flags1)
    out.write_u8(flags2)
    out.write_f32(float(data.get('duration', 0.0)))

    if flags1 & 0x01:
        _write_vector3(out, data.get('char_pos_with_eyes_world', (0.0, 0.0, 0.0)))
    if flags1 & 0x02:
        _write_quaternion(out, data.get('char_rot_with_eyes_world', (0.0, 0.0, 0.0, 1.0)))
    if flags1 & 0x04:
        _write_quaternion(out, data.get('eyes_coord_with_eyes_world', (0.0, 0.0, 0.0, 1.0)))
    if flags1 & 0x08:
        _write_vector3(out, data.get('eyes_pos', (0.0, 0.0, 0.0)))
    if flags1 & 0x10:
        _write_quaternion(out, data.get('eyes_rot', (0.0, 0.0, 0.0, 1.0)))
    if flags1 & 0x20:
        _write_vector3(out, data.get('char_pos_with_eyes_local', (0.0, 0.0, 0.0)))
    if flags1 & 0x40:
        _write_quaternion(out, data.get('char_rot_with_eyes_local', (0.0, 0.0, 0.0, 1.0)))
    if flags1 & 0x80:
        _write_quaternion(out, data.get('eyes_coord_with_eyes_local', (0.0, 0.0, 0.0, 1.0)))
    if flags2 & 0x01:
        _write_vector3(out, data.get('eyes_local_pos', (0.0, 0.0, 0.0)))
    if flags2 & 0x02:
        _write_quaternion(out, data.get('eyes_local_rot', (0.0, 0.0, 0.0, 1.0)))


def _read_transform_euler(stream: InputStream) -> dict:
    return {
        'euler': _read_vector3(stream),
        'position': _read_vector3(stream),
    }


def _write_transform_euler(out: OutputStream, transform: dict):
    _write_vector3(out, transform.get('euler', (0.0, 0.0, 0.0)))
    _write_vector3(out, transform.get('position', (0.0, 0.0, 0.0)))


def _read_throw_scene_tool_data(stream: InputStream) -> dict:
    return {
        'scene_tool_unique_id': stream.read_u64(),
        'transform': _read_transform_euler(stream),
        'speed': _read_vector3(stream),
    }


def _write_throw_scene_tool_data(out: OutputStream, tool: dict):
    out.write_u64(int(tool.get('scene_tool_unique_id', 0)))
    _write_transform_euler(out, tool.get('transform', {}))
    _write_vector3(out, tool.get('speed', (0.0, 0.0, 0.0)))


def _read_battle_ray(stream: InputStream) -> dict:
    # proto.common.BattleRay: Vector3 pos + Vector3 dir
    return {
        'pos': _read_vector3(stream),
        'dir': _read_vector3(stream),
    }


def _write_battle_ray(out: OutputStream, ray: dict):
    _write_vector3(out, ray.get('pos', (0.0, 0.0, 0.0)))
    _write_vector3(out, ray.get('dir', (0.0, 0.0, 1.0)))


def _read_hit_mark_target(stream: InputStream) -> dict:
    # proto.common.HitMarkTarget
    return {
        'hit_target_id': stream.read_u64(),
        'hit_part': stream.read_u8(),
    }


def _read_hit_target_character(stream: InputStream) -> dict:
    # proto.common.HitTargetCharacter starts with flags for optional vectors.
    flags = stream.read_u8()
    target = {
        'flags': flags,
        'bid': stream.read_u8(),
        'hit_part': stream.read_u8(),
        'part_index': stream.read_u8(),
    }
    if flags & 0x01:
        target['part_local_pos'] = _read_vector3(stream)
    if flags & 0x02:
        target['part_local_normal'] = _read_vector3(stream)
    return target


def _write_hit_target_character(out: OutputStream, target: dict):
    flags = int(target.get('flags', 0))
    if flags == 0:
        if 'part_local_pos' in target:
            flags |= 0x01
        if 'part_local_normal' in target:
            flags |= 0x02
    out.write_u8(flags)
    out.write_u8(int(target.get('bid', 0)))
    out.write_u8(int(target.get('hit_part', 0)))
    out.write_u8(int(target.get('part_index', 0)))
    if flags & 0x01:
        _write_vector3(out, target.get('part_local_pos', (0.0, 0.0, 0.0)))
    if flags & 0x02:
        _write_vector3(out, target.get('part_local_normal', (0.0, 1.0, 0.0)))


def _read_character_be_hurt_info(stream: InputStream) -> dict:
    # proto.common.CharacterBeHurtInfo
    return {
        'target': _read_hit_target_character(stream),
        'ray': _read_battle_ray(stream),
    }


def _read_one_bullet(stream: InputStream) -> dict:
    # proto.common.OneBullet uses flags for optional target and distance fields.
    flags = stream.read_u8()
    bullet = {
        'flags': flags,
        'ray': _read_battle_ray(stream),
    }
    if flags & 0x01:
        bullet['target_character'] = _read_hit_target_character(stream)
    if flags & 0x02:
        bullet['target_distance'] = stream.read_f32()
    return bullet


def _write_one_bullet_ray(out: OutputStream, bullet: dict):
    # proto.common.OneBulletRay has optional target_character via flag bit0.
    target = bullet.get('target_character')
    flags = int(bullet.get('flags', 0)) & 0x01
    if target is not None:
        flags |= 0x01
    out.write_u8(flags)
    _write_battle_ray(out, bullet.get('ray', {}))
    out.write_f32(float(bullet.get('distance', bullet.get('target_distance', 0.0))))
    if flags & 0x01:
        _write_hit_target_character(out, target or {})


def _read_melee_attack_target(stream: InputStream) -> dict:
    return {
        'hit_ray': _read_battle_ray(stream),
        'hit_distance': stream.read_f32(),
        'hit_target': _read_hit_target_character(stream),
    }


def _write_melee_attack_target(out: OutputStream, target: dict):
    _write_battle_ray(out, target.get('hit_ray', {}))
    out.write_f32(float(target.get('hit_distance', 0.0)))
    _write_hit_target_character(out, target.get('hit_target', {}))


def _read_battle_pose(stream: InputStream) -> dict:
    # proto.common.BattleCharacterPose: Vector3 pos + Vector3 rot
    return {
        'pos': _read_vector3(stream),
        'rot': _read_vector3(stream),
    }


def _write_battle_pose(out: OutputStream, pose: dict):
    _write_vector3(out, pose.get('pos', (0.0, 0.0, 0.0)))
    _write_vector3(out, pose.get('rot', (0.0, 0.0, 0.0)))


def _read_battle_character_throw_rope(stream: InputStream) -> dict:
    return {
        'target': _read_vector3(stream),
        'rope': _read_vector3(stream),
        'distance_hook_to_wall': stream.read_f32(),
        'wall_yaw': stream.read_f32(),
        'throw_type': stream.read_u8(),
    }


def _write_battle_character_throw_rope(out: OutputStream, desc: dict):
    _write_vector3(out, desc.get('target', (0.0, 0.0, 0.0)))
    _write_vector3(out, desc.get('rope', (0.0, 0.0, 0.0)))
    out.write_f32(float(desc.get('distance_hook_to_wall', 0.0)))
    out.write_f32(float(desc.get('wall_yaw', 0.0)))
    out.write_u8(int(desc.get('throw_type', 0)) & 0xFF)


def _read_battle_character_wall_space(stream: InputStream) -> dict:
    # Runtime shape inferred from req/res traces:
    # flags(u8), body_state(u8), [middle_pos(Vector3)] if flags&0x01, pos(Vector3)
    flags = stream.read_u8()
    desc: dict = {
        'flags': flags,
        'body_state': stream.read_u8(),
    }
    if flags & 0x01:
        desc['middle_pos'] = _read_vector3(stream)
    desc['pos'] = _read_vector3(stream)
    return desc


def _write_battle_character_wall_space(out: OutputStream, desc: dict):
    flags = int(desc.get('flags', 0)) & 0x01
    if 'middle_pos' in desc:
        flags |= 0x01
    out.write_u8(flags)
    out.write_u8(int(desc.get('body_state', 1)) & 0xFF)
    if flags & 0x01:
        _write_vector3(out, desc.get('middle_pos', (0.0, 0.0, 0.0)))
    _write_vector3(out, desc.get('pos', (0.0, 0.0, 0.0)))


def _read_pose_delta(stream: InputStream) -> dict:
    # proto.common.BattleCharacterPoseDelta uses a u8 bitmask before optional floats.
    flags = stream.read_u8()
    delta: dict = {'flags': flags}
    if flags & 0x01:
        delta['x'] = stream.read_f32()
    if flags & 0x02:
        delta['y'] = stream.read_f32()
    if flags & 0x04:
        delta['z'] = stream.read_f32()
    if flags & 0x08:
        delta['yaw'] = stream.read_f32()
    if flags & 0x10:
        delta['pitch'] = stream.read_f32()
    if flags & 0x20:
        delta['roll'] = stream.read_f32()
    return delta


def _write_pose_delta(out: OutputStream, delta: dict | tuple | list):
    if isinstance(delta, (tuple, list)):
        # Backward-compatible fallback for older call sites.
        values = list(delta) + [0.0] * (6 - len(delta))
        flags = 0x3F
        out.write_u8(flags)
        for i in range(6):
            out.write_f32(float(values[i]))
        return

    fields = ('x', 'y', 'z', 'yaw', 'pitch', 'roll')
    bits = (0x01, 0x02, 0x04, 0x08, 0x10, 0x20)
    flags = int(delta.get('flags', 0))
    if flags == 0:
        for bit, name in zip(bits, fields):
            if name in delta:
                flags |= bit

    out.write_u8(flags)
    for bit, name in zip(bits, fields):
        if flags & bit:
            out.write_f32(float(delta.get(name, 0.0)))


def build_rsp_character_pose(bid: int, delta: dict | tuple | list) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_pose_delta(out, delta)
    return build_packet(PKT_RSP_CHARACTER_POSE, out.get_bytes())


def build_rsp_character_state(bid: int, pose: dict, state: int, body_state: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_battle_pose(out, pose)
    out.write_u8(state)
    out.write_u8(body_state)
    return build_packet(PKT_RSP_CHARACTER_STATE, out.get_bytes())


def build_rsp_character_jump_on(
    bid: int,
    pose: dict,
    desc: dict,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    _write_battle_jump_on(out, desc)
    return build_packet(PKT_RSP_CHARACTER_JUMP_ON, out.get_bytes())


def build_rsp_character_throw_rope(
    climb_trigger_id: int,
    bid: int,
    pose: dict,
    desc: dict,
) -> bytes:
    out = OutputStream()
    out.write_u32(int(climb_trigger_id))
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    _write_battle_character_throw_rope(out, desc)
    return build_packet(PKT_RSP_CHARACTER_THROW_ROPE, out.get_bytes())


def build_rsp_character_into_wall_space(
    bid: int,
    desc: dict,
    wall_yaw: float,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_battle_character_wall_space(out, desc)
    out.write_f32(float(wall_yaw))
    return build_packet(PKT_RSP_CHARACTER_INTO_WALL_SPACE, out.get_bytes())


def build_rsp_character_jump_over(
    bid: int,
    pose: dict,
    jump_over_raw: bytes,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    out.write_bytes(jump_over_raw)
    return build_packet(PKT_RSP_CHARACTER_JUMP_OVER, out.get_bytes())


def build_rsp_character_leave_wall_space(
    bid: int,
    pose: dict,
    wall_space_raw: bytes,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    out.write_bytes(wall_space_raw)
    return build_packet(PKT_RSP_CHARACTER_LEAVE_WALL_SPACE, out.get_bytes())


def build_rsp_character_change_pose_in_wall(
    bid: int,
    pose: dict,
    body_state_raw: bytes,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    out.write_bytes(body_state_raw)
    return build_packet(PKT_RSP_CHARACTER_CHANGE_POSE_IN_WALL, out.get_bytes())


def build_rsp_character_leave_wall_space_by_window(
    bid: int,
    is_success: bool,
    dynamic_wall_id: int,
    pose: dict,
    desc: dict,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_bool(bool(is_success))
    out.write_u32(int(dynamic_wall_id))
    _write_battle_pose(out, pose)
    _write_battle_leave_wall_space_by_window(out, desc)
    return build_packet(PKT_RSP_CHARACTER_LEAVE_WALL_SPACE_BY_WINDOW, out.get_bytes())


def build_rsp_character_action_melee_attack(bid: int, melee_attack_type: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(melee_attack_type)
    return build_packet(PKT_RSP_CHARACTER_ACTION_MELEE_ATTACK, out.get_bytes())


def build_rsp_character_action_tilt(bid: int, tilt_type: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(tilt_type)
    return build_packet(PKT_RSP_CHARACTER_ACTION_TILT, out.get_bytes())


def build_rsp_event_character_gun_fire(bid: int, gun_fire_type: int, bullets: list[dict]) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(gun_fire_type)
    out.write_cuint(len(bullets))
    for bullet in bullets:
        _write_one_bullet_ray(out, bullet)
    return build_packet(PKT_RSP_EVENT_CHARACTER_GUN_FIRE, out.get_bytes())


def build_rsp_character_melee_attack(hit_target: dict | None = None) -> bytes:
    out = OutputStream()
    has_target = hit_target is not None
    out.write_u8(0x01 if has_target else 0x00)
    if has_target:
        _write_hit_target_character(out, hit_target or {})
    return build_packet(PKT_RSP_CHARACTER_MELEE_ATTACK, out.get_bytes())


def build_rsp_character_action_aiming(bid: int, aiming: bool) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_bool(bool(aiming))
    return build_packet(PKT_RSP_CHARACTER_ACTION_AIMING, out.get_bytes())


def build_rsp_character_operation(bid: int, tool_index: int, operation: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u16(tool_index)
    out.write_u16(operation)
    return build_packet(PKT_RSP_CHARACTER_OPERATION, out.get_bytes())


def build_rsp_operate_tool(
    bid: int,
    tool_index: int,
    operation_type: int,
    state: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u16(tool_index)
    out.write_u8(operation_type)
    out.write_u8(state)
    return build_packet(PKT_RSP_OPERATE_TOOL, out.get_bytes())


def build_rsp_character_lerp_pos(
    bid: int,
    body_state: int,
    pose: dict,
    lerp_data: dict,
) -> bytes:

    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u8(int(body_state) & 0xFF)
    _write_battle_pose(out, pose)
    _write_lerp_data(out, lerp_data)
    return build_packet(PKT_RSP_CHARACTER_LERP_POS, out.get_bytes())


def build_rsp_character_operate_shield(
    bid: int,
    pose: dict,
    op: int,
    *,
    flags: int | None = None,
    pos_x: float | None = None,
    pos_y: float | None = None,
    pos_z: float | None = None,
    yaw: float | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if pos_x is not None:
            flags |= 0x01
        if pos_y is not None:
            flags |= 0x02
        if pos_z is not None:
            flags |= 0x04
        if yaw is not None:
            flags |= 0x08
    flags &= 0x0F
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    _write_battle_pose(out, pose)
    out.write_u8(int(op) & 0xFF)
    if flags & 0x01:
        out.write_f32(float(pos_x or 0.0))
    if flags & 0x02:
        out.write_f32(float(pos_y or 0.0))
    if flags & 0x04:
        out.write_f32(float(pos_z or 0.0))
    if flags & 0x08:
        out.write_f32(float(yaw or 0.0))
    return build_packet(PKT_RSP_CHARACTER_OPERATE_SHIELD, out.get_bytes())


def build_rsp_shield_state_update(
    bid: int,
    shield_state: int,
    *,
    flags: int | None = None,
    pos_x: float | None = None,
    pos_y: float | None = None,
    pos_z: float | None = None,
    yaw: float | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if pos_x is not None:
            flags |= 0x01
        if pos_y is not None:
            flags |= 0x02
        if pos_z is not None:
            flags |= 0x04
        if yaw is not None:
            flags |= 0x08
    flags &= 0x0F
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    out.write_u8(int(shield_state) & 0xFF)
    if flags & 0x01:
        out.write_f32(float(pos_x or 0.0))
    if flags & 0x02:
        out.write_f32(float(pos_y or 0.0))
    if flags & 0x04:
        out.write_f32(float(pos_z or 0.0))
    if flags & 0x08:
        out.write_f32(float(yaw or 0.0))
    return build_packet(PKT_RSP_SHIELD_STATE_UPDATE, out.get_bytes())


def build_rsp_destroy_scene_object(
    destroy_type: int,
    destroy_pos: tuple[float, float, float],
    destroy_objects: list[int],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(destroy_type) & 0xFF)
    _write_vector3(out, destroy_pos)
    _write_u64_vector(out, destroy_objects)
    return build_packet(PKT_RSP_DESTROY_SCENE_OBJECT, out.get_bytes())


def build_rsp_character_action_take_out_pad(bid: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    return build_packet(PKT_RSP_CHARACTER_ACTION_TAKE_OUT_PAD, out.get_bytes())


def build_rsp_scan_enemies(
    bid: int,
    vehicle_id: int,
    pos: tuple[float, float, float],
    enemies: list[dict],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(vehicle_id))
    _write_vector3(out, pos)
    out.write_cuint(len(enemies))
    for row in enemies:
        _write_scan_enemy_info(out, row)
    return build_packet(PKT_RSP_SCAN_ENEMIES, out.get_bytes())


def build_rsp_vehicle_launch_tracker(
    bid: int,
    pos_start: tuple[float, float, float],
    pos_ends: list[tuple[float, float, float]],
    target_bids: list[int],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    _write_vector3(out, pos_start)
    out.write_cuint(len(pos_ends))
    for pos in pos_ends:
        _write_vector3(out, pos)
    out.write_cuint(len(target_bids))
    for target_bid in target_bids:
        out.write_u8(int(target_bid) & 0xFF)
    return build_packet(PKT_RSP_VEHICLE_LAUNCH_TRACKER, out.get_bytes())


def build_rsp_active_tracker(errcode: int, tool_index: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(errcode) & 0xFF)
    out.write_u16(int(tool_index) & 0xFFFF)
    return build_packet(PKT_RSP_ACTIVE_TRACKER, out.get_bytes())


def build_rsp_character_hammer_attack(
    bid: int,
    forward_ray: dict,
    remain_num: int,
    target_type: int,
    trans: dict,
    target_mat: int,
    target: dict | None = None,
) -> bytes:
    out = OutputStream()
    flags = 0x01 if target is not None else 0x00
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    _write_battle_ray(out, forward_ray)
    out.write_u32(int(remain_num) & 0xFFFFFFFF)
    if flags & 0x01:
        _write_melee_attack_target(out, target or {})
    out.write_u8(int(target_type) & 0xFF)
    _write_transform(out, trans or {})
    out.write_u8(int(target_mat) & 0xFF)
    return build_packet(PKT_RSP_CHARACTER_HAMMER_ATTACK, out.get_bytes())


def build_rsp_character_action_hammer_attack(bid: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    return build_packet(PKT_RSP_CHARACTER_ACTION_HAMMER_ATTACK, out.get_bytes())


def build_rsp_character_action_install_trap_bomb(
    trap_bomb_uid: int,
    pos: tuple[float, float, float],
    rot: tuple[float, float, float, float],
    install_type: int,
) -> bytes:
    out = OutputStream()
    out.write_u64(int(trap_bomb_uid))
    _write_vector3(out, pos)
    _write_quaternion(out, rot)
    out.write_u8(int(install_type) & 0xFF)
    return build_packet(PKT_RSP_CHARACTER_ACTION_INSTALL_TRAP_BOMB, out.get_bytes())


def build_rsp_trap_bomb_installed(
    trap_bomb_uid: int,
    block_id: int,
    bomb_pos: tuple[float, float, float],
    bomb_rot: tuple[float, float, float, float],
    install_type: int,
) -> bytes:
    out = OutputStream()
    out.write_u64(int(trap_bomb_uid))
    out.write_u32(int(block_id) & 0xFFFFFFFF)
    _write_vector3(out, bomb_pos)
    _write_quaternion(out, bomb_rot)
    out.write_u8(int(install_type) & 0xFF)
    return build_packet(PKT_RSP_TRAP_BOMB_INSTALLED, out.get_bytes())


def build_rsp_character_action_uninstall_trap_bomb(trap_bomb_uid: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(trap_bomb_uid))
    return build_packet(PKT_RSP_CHARACTER_ACTION_UNINSTALL_TRAP_BOMB, out.get_bytes())


def build_rsp_update_trap_bomb_state(
    trap_bomb_uid: int,
    item_state: int,
    attacker_bid: int | None = None,
    effect_type: int | None = None,
    flags: int | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if attacker_bid is not None:
            flags |= 0x01
        if effect_type is not None:
            flags |= 0x02
    else:
        flags = int(flags) & 0x03
    out.write_u8(flags)
    out.write_u64(int(trap_bomb_uid))
    out.write_u8(int(item_state) & 0xFF)
    if flags & 0x01:
        out.write_u8(int(attacker_bid or 0) & 0xFF)
    if flags & 0x02:
        out.write_u8(int(effect_type or 0) & 0xFF)
    return build_packet(PKT_RSP_UPDATE_TRAP_BOMB_STATE, out.get_bytes())


def build_rsp_throw_item(
    result: bool,
    throw_item_unique_id: int,
    client_param: int,
    count: int,
    ray: dict,
    angle: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_bool(bool(result))
    out.write_u64(int(throw_item_unique_id))
    out.write_u32(int(client_param) & 0xFFFFFFFF)
    out.write_u32(int(count) & 0xFFFFFFFF)
    _write_battle_ray(out, ray)
    _write_vector3(out, angle)
    return build_packet(PKT_RSP_THROW_ITEM, out.get_bytes())


def build_rsp_item_pos_report(
    throw_item_unique_id: int,
    ray: dict,
    angle: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(int(throw_item_unique_id))
    _write_battle_ray(out, ray)
    _write_vector3(out, angle)
    return build_packet(PKT_RSP_ITEM_POS_REPORT, out.get_bytes())


def build_rsp_throw_item_drop_down(
    result: bool,
    throw_item_unique_id: int,
    ray: dict,
) -> bytes:
    out = OutputStream()
    out.write_bool(bool(result))
    out.write_u64(int(throw_item_unique_id))
    _write_battle_ray(out, ray)
    return build_packet(PKT_RSP_THROW_ITEM_DROP_DOWN, out.get_bytes())


def build_rsp_throw_item_stoped(
    result: bool,
    throw_item_unique_id: int,
    trans: dict,
    relates: list[int],
) -> bytes:
    out = OutputStream()
    out.write_bool(bool(result))
    out.write_u64(int(throw_item_unique_id))
    _write_transform_euler(out, trans)
    _write_u64_vector(out, relates)
    return build_packet(PKT_RSP_THROW_ITEM_STOPED, out.get_bytes())


def build_rsp_game_points(player_id: int, points: list[dict]) -> bytes:
    out = OutputStream()
    out.write_u64(int(player_id))
    out.write_cuint(len(points))
    for row in points:
        out.write_u32(int(row.get('action', 0)) & 0xFFFFFFFF)
        out.write_s32(int(row.get('point', 0)))
    return build_packet(PKT_RSP_GAME_POINTS, out.get_bytes())


def build_rsp_event_character_gun_hurt(source_bid: int, targets: list[dict]) -> bytes:
    out = OutputStream()
    out.write_u8(int(source_bid) & 0xFF)
    out.write_cuint(len(targets))
    for t in targets:
        _write_hit_target_character(out, t.get('target', {}))
        _write_battle_ray(out, t.get('ray', {}))
    return build_packet(PKT_RSP_EVENT_CHARACTER_GUN_HURT, out.get_bytes())


def _write_character_hp(out: OutputStream, *, base_hp: int, extra_hp: int):
    out.write_u16(int(base_hp) & 0xFFFF)
    out.write_u16(int(extra_hp) & 0xFFFF)


def build_rsp_character_hp_changed(
    *,
    bid: int,
    base_hp: int,
    extra_hp: int,
    damage_type: int,
    damage_source: tuple[float, float, float] | None = None,
) -> bytes:
    out = OutputStream()
    flags = 0x01 if damage_source is not None else 0x00
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    _write_character_hp(out, base_hp=base_hp, extra_hp=extra_hp)
    out.write_u8(int(damage_type) & 0xFF)
    if damage_source is not None:
        _write_vector3(out, damage_source)
    return build_packet(PKT_RSP_CHARACTER_HP_CHANGED, out.get_bytes())


def build_rsp_player_death(
    *,
    bid: int,
    item_uid: int,
    attacker_bid: int,
    damage_type: int,
    pos: tuple[float, float, float],
    part_index: int | None = None,
    part_local_pos: tuple[float, float, float] | None = None,
) -> bytes:
    out = OutputStream()
    flags = 0
    if part_index is not None:
        flags |= 0x01
    if part_local_pos is not None:
        flags |= 0x02
    out.write_u8(flags & 0xFF)
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(item_uid) & 0xFFFFFFFFFFFFFFFF)
    out.write_u8(int(attacker_bid) & 0xFF)
    out.write_u8(int(damage_type) & 0xFF)
    _write_vector3(out, pos)
    if flags & 0x01:
        out.write_u8(int(part_index or 0) & 0xFF)
    if flags & 0x02:
        _write_vector3(out, part_local_pos or (0.0, 0.0, 0.0))
    return build_packet(PKT_RSP_PLAYER_DEATH, out.get_bytes())


def build_rsp_event_character_enemy_explosive_hurt(
    *,
    source_bid: int,
    target_bid: int,
    base_hp: int,
    extra_hp: int,
    explosive_pos: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(source_bid) & 0xFF)
    out.write_u8(int(target_bid) & 0xFF)
    _write_character_hp(out, base_hp=base_hp, extra_hp=extra_hp)
    _write_vector3(out, explosive_pos)
    return build_packet(PKT_RSP_EVENT_CHARACTER_ENEMY_EXPLOSIVE_HURT, out.get_bytes())


def build_rsp_event_character_friend_explosive_hurt(
    *,
    source_bid: int,
    target_bid: int,
    base_hp: int,
    extra_hp: int,
    explosive_pos: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(source_bid) & 0xFF)
    out.write_u8(int(target_bid) & 0xFF)
    _write_character_hp(out, base_hp=base_hp, extra_hp=extra_hp)
    _write_vector3(out, explosive_pos)
    return build_packet(PKT_RSP_EVENT_CHARACTER_FRIEND_EXPLOSIVE_HURT, out.get_bytes())


def build_rsp_delete_scene_tool(
    *,
    scene_tool_unique_id: int,
    kind: int,
    attacker_bid: int,
    effect_type: int,
) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id) & 0xFFFFFFFFFFFFFFFF)
    out.write_u8(int(kind) & 0xFF)
    out.write_u8(int(attacker_bid) & 0xFF)
    out.write_u8(int(effect_type) & 0xFF)
    return build_packet(PKT_RSP_DELETE_SCENE_TOOL, out.get_bytes())


def build_rsp_operate_character(
    bid: int,
    hand_tool_id: int,
    hand_tool_config_id: int,
    target_player_bid: int,
    state: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(hand_tool_id) & 0xFFFFFFFF)
    out.write_u32(int(hand_tool_config_id) & 0xFFFFFFFF)
    out.write_u8(int(target_player_bid) & 0xFF)
    out.write_u8(int(state) & 0xFF)
    return build_packet(PKT_RSP_OPERATE_CHARACTER, out.get_bytes())


def build_rsp_throw_neuro_toxin(
    player_bid: int,
    is_success: bool,
    scene_tool_unique_id: int,
    client_param: int,
    trans: dict,
    speed: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(player_bid) & 0xFF)
    out.write_bool(bool(is_success))
    out.write_u64(int(scene_tool_unique_id))
    out.write_u32(int(client_param) & 0xFFFFFFFF)
    _write_transform(out, trans)
    _write_vector3(out, speed)
    return build_packet(PKT_RSP_THROW_NEURO_TOXIN, out.get_bytes())


def build_rsp_sync_neuro_toxin_position(
    scene_tool_unique_id: int,
    trans: dict,
    speed: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id))
    _write_transform(out, trans)
    _write_vector3(out, speed)
    return build_packet(PKT_RSP_SYNC_NEURO_TOXIN_POSITION, out.get_bytes())


def build_rsp_throw_neuro_toxin_end(
    scene_tool_unique_id: int,
    trans: dict,
    speed: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id))
    _write_transform(out, trans)
    _write_vector3(out, speed)
    return build_packet(PKT_RSP_THROW_NEURO_TOXIN_END, out.get_bytes())


def build_rsp_remove_neuro_toxin_operator(bid: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    return build_packet(PKT_RSP_REMOVE_NEURO_TOXIN_OPERATOR, out.get_bytes())


def build_rsp_get_back_neuro_toxin_operator(
    bid: int,
    scene_tool_unique_id: int,
    player_current_transform: dict,
    state: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(scene_tool_unique_id))
    _write_transform(out, player_current_transform)
    out.write_u8(int(state) & 0xFF)
    return build_packet(PKT_RSP_GET_BACK_NEURO_TOXIN_OPERATOR, out.get_bytes())


def build_rsp_get_back_neuro_toxin_failed(bid: int, scene_tool_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(scene_tool_unique_id))
    return build_packet(PKT_RSP_GET_BACK_NEURO_TOXIN_FAILED, out.get_bytes())


def build_rsp_delete_neuro_toxin(
    scene_tool_unique_id: int,
    kind: int,
    attacker_bid: int,
    effect_type: int,
) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id))
    out.write_u8(int(kind) & 0xFF)
    out.write_u8(int(attacker_bid) & 0xFF)
    out.write_u8(int(effect_type) & 0xFF)
    return build_packet(PKT_RSP_DELETE_NEURO_TOXIN, out.get_bytes())


def build_rsp_unmanned_vehicle_take_back(vehicle_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(vehicle_id))
    return build_packet(PKT_RSP_UNMANNED_VEHICLE_TAKE_BACK, out.get_bytes())


def build_rsp_unmanned_vehicle_spawn(vehicle_id: int, pose: dict) -> bytes:
    out = OutputStream()
    out.write_u64(int(vehicle_id))
    _write_battle_pose(out, pose if isinstance(pose, dict) else {})
    return build_packet(PKT_RSP_UNMANNED_VEHICLE_SPAWN, out.get_bytes())


def build_rsp_update_unmanned_vehicle_state(
    bid: int,
    vehicle_id: int,
    relation: int = VEHICLE_RELATION_OPERATOR,
    need_switch_to_character: bool = False,
    *,
    include_relation: bool = True,
) -> bytes:
    out = OutputStream()
    flags = 0x01 if include_relation else 0x00
    out.write_u8(flags & 0x01)
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(vehicle_id))
    if flags & 0x01:
        out.write_u8(int(relation) & 0xFF)
    out.write_bool(bool(need_switch_to_character))
    return build_packet(PKT_RSP_UPDATE_UNMANNED_VEHICLE_STATE, out.get_bytes())


def build_rsp_unmanned_vehicle_pose_delta(
    bid: int,
    vehicle_id: int,
    *,
    flags: int | None = None,
    pos_x: float | None = None,
    pos_y: float | None = None,
    pos_z: float | None = None,
    yaw: float | None = None,
    view_pitch: float | None = None,
    view_yaw: float | None = None,
    view_roll: float | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if pos_x is not None:
            flags |= 0x01
        if pos_y is not None:
            flags |= 0x02
        if pos_z is not None:
            flags |= 0x04
        if yaw is not None:
            flags |= 0x08
        if view_pitch is not None:
            flags |= 0x10
        if view_yaw is not None:
            flags |= 0x20
        if view_roll is not None:
            flags |= 0x40
    flags &= 0x7F
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(vehicle_id))
    if flags & 0x01:
        out.write_f32(float(pos_x or 0.0))
    if flags & 0x02:
        out.write_f32(float(pos_y or 0.0))
    if flags & 0x04:
        out.write_f32(float(pos_z or 0.0))
    if flags & 0x08:
        out.write_f32(float(yaw or 0.0))
    if flags & 0x10:
        out.write_f32(float(view_pitch or 0.0))
    if flags & 0x20:
        out.write_f32(float(view_yaw or 0.0))
    if flags & 0x40:
        out.write_f32(float(view_roll or 0.0))
    return build_packet(PKT_RSP_UNMANNED_VEHICLE_POSE_DELTA, out.get_bytes())


def build_rsp_switch_unmanned_vehicle_failed(vehicle_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(vehicle_id))
    return build_packet(PKT_RSP_SWITCH_UNMANNED_VEHICLE_FAILED, out.get_bytes())


def build_rsp_switch_current_monitor_failed(monitor_id: int) -> bytes:
    out = OutputStream()
    out.write_u32(int(monitor_id))
    return build_packet(PKT_RSP_SWITCH_CURRENT_MONITOR_FAILED, out.get_bytes())


def build_rsp_update_monitor_state(
    bid: int,
    monitor_id: int,
    relation: int = MONITOR_RELATION_OPERATOR,
    need_switch_to_character: bool = False,
    *,
    include_relation: bool = True,
) -> bytes:
    out = OutputStream()
    flags = 0x01 if include_relation else 0x00
    out.write_u8(flags & 0x01)
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(monitor_id))
    if flags & 0x01:
        out.write_u8(int(relation) & 0xFF)
    out.write_bool(bool(need_switch_to_character))
    return build_packet(PKT_RSP_UPDATE_MONITOR_STATE, out.get_bytes())


def build_rsp_monitor_scan_enemies(
    bid: int,
    monitor_id: int,
    view_yaw: float,
    view_pitch: float,
    enemies: list[dict],
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(monitor_id))
    out.write_f32(float(view_yaw))
    out.write_f32(float(view_pitch))
    out.write_cuint(len(enemies))
    for row in enemies:
        _write_scan_enemy_info(out, row)
    return build_packet(PKT_RSP_MONITOR_SCAN_ENEMIES, out.get_bytes())


def build_rsp_monitor_pose_delta(
    bid: int,
    monitor_id: int,
    *,
    flags: int | None = None,
    view_pitch: float | None = None,
    view_yaw: float | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if view_pitch is not None:
            flags |= 0x01
        if view_yaw is not None:
            flags |= 0x02
    flags &= 0x03
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(monitor_id))
    if flags & 0x01:
        out.write_f32(float(view_pitch or 0.0))
    if flags & 0x02:
        out.write_f32(float(view_yaw or 0.0))
    return build_packet(PKT_RSP_MONITOR_POSE_DELTA, out.get_bytes())


def build_rsp_found_critical_target(
    found_player_bid: int,
    region_id: int,
    is_reconnect: bool = False,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(found_player_bid) & 0xFF)
    out.write_u32(int(region_id))
    out.write_bool(bool(is_reconnect))
    return build_packet(PKT_RSP_FOUND_CRITICAL_TARGET, out.get_bytes())


def build_rsp_found_bomb_target(
    found_player_bid: int,
    region_id: int,
    is_reconnect: bool = False,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(found_player_bid) & 0xFF)
    out.write_u32(int(region_id) & 0xFFFFFFFF)
    out.write_bool(bool(is_reconnect))
    return build_packet(PKT_RSP_FOUND_BOMB_TARGET, out.get_bytes())


def build_rsp_found_defuser(defuser_id: int, found_player_bid: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(defuser_id))
    out.write_u8(int(found_player_bid) & 0xFF)
    return build_packet(PKT_RSP_FOUND_DEFUSER, out.get_bytes())


def build_rsp_notify_defuser_state(state: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(state) & 0xFF)
    return build_packet(PKT_RSP_NOTIFY_DEFUSER_STATE, out.get_bytes())


def build_rsp_character_climb_ladder(
    bid: int,
    ladder_id: int,
    is_up: bool,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(ladder_id))
    out.write_bool(bool(is_up))
    return build_packet(PKT_RSP_CHARACTER_CLIMB_LADDER, out.get_bytes())


def build_rsp_character_leave_ladder(
    bid: int,
    ladder_id: int,
    is_up: bool,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(ladder_id))
    out.write_bool(bool(is_up))
    return build_packet(PKT_RSP_CHARACTER_LEAVE_LADDER, out.get_bytes())


def build_rsp_bomb_gun_fire_result(
    bid: int,
    bullet_id: int,
    ray: dict,
    is_success: bool = True,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(bullet_id))
    _write_battle_ray(out, ray)
    out.write_bool(bool(is_success))
    return build_packet(PKT_RSP_BOMB_GUN_FIRE_RESULT, out.get_bytes())


def build_rsp_sync_character_action(
    bid: int,
    action: int,
    duration: float,
    duration_coefficient: float,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u32(action)
    out.write_f32(duration)
    out.write_f32(duration_coefficient)
    return build_packet(PKT_RSP_SYNC_CHARACTER_ACTION, out.get_bytes())


def build_rsp_ground_material(bid: int, material: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u32(material)
    return build_packet(PKT_RSP_GROUND_MATERIAL, out.get_bytes())


def build_rsp_sync_character_tool(bid: int, tool_index: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u16(tool_index)
    return build_packet(PKT_RSP_SYNC_CHARACTER_TOOL, out.get_bytes())


def build_rsp_sync_character_assist_tool(character_bid: int, assist_tool_index: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(character_bid) & 0xFF)
    out.write_u16(int(assist_tool_index) & 0xFFFF)
    return build_packet(PKT_RSP_SYNC_CHARACTER_ASSIST_TOOL, out.get_bytes())


def build_rsp_sync_skill_num(bid: int, skill_id: int, num: int) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(skill_id) & 0xFFFFFFFF)
    out.write_u32(int(num) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_SYNC_SKILL_NUM, out.get_bytes())


def build_rsp_sync_skill_cd(skill_id: int, remain_ms: int, cd_total_ms: int) -> bytes:
    out = OutputStream()
    out.write_u32(int(skill_id) & 0xFFFFFFFF)
    out.write_u32(int(remain_ms) & 0xFFFFFFFF)
    out.write_u32(int(cd_total_ms) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_SYNC_SKILL_CD, out.get_bytes())


def build_rsp_sync_skill_active_time(skill_id: int, remain_ms: int, total_ms: int) -> bytes:
    out = OutputStream()
    out.write_u32(int(skill_id) & 0xFFFFFFFF)
    out.write_u32(int(remain_ms) & 0xFFFFFFFF)
    out.write_u32(int(total_ms) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_SYNC_SKILL_ACTIVE_TIME, out.get_bytes())


def build_rsp_sync_character_weapon_state(bid: int, weapon_state: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(weapon_state)
    return build_packet(PKT_RSP_SYNC_CHARACTER_WEAPON_STATE, out.get_bytes())


def build_rsp_sync_perform_data(bid: int, data_type: int, perform_data: dict) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u32(data_type)
    _write_perform_data(out, perform_data)
    return build_packet(PKT_RSP_SYNC_PERFORM_DATA, out.get_bytes())


def build_rsp_place_tool_operator(
    bid: int,
    hand_item_id: int,
    relevant_ids: list[int],
    affected_id: int | None,
    duration: float,
    state: int,
    lerp_data: dict,
    flags: int | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if relevant_ids:
            flags |= 0x01
        if affected_id is not None:
            flags |= 0x02
    else:
        flags = int(flags) & 0x03
    out.write_u8(flags)
    out.write_u8(bid)
    out.write_u32(hand_item_id)
    if flags & 0x01:
        _write_u64_vector(out, relevant_ids)
    if flags & 0x02:
        out.write_u64(int(affected_id or 0))
    out.write_f32(duration)
    out.write_u8(state)
    _write_lerp_data(out, lerp_data)
    return build_packet(PKT_RSP_PLACE_TOOL_OPERATOR, out.get_bytes())


def build_rsp_throw_scene_tool(
    bid: int,
    is_success: bool,
    tool: dict,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_bool(bool(is_success))
    _write_throw_scene_tool_data(out, tool)
    return build_packet(PKT_RSP_THROW_SCENE_TOOL, out.get_bytes())


def build_rsp_sync_throw_scene_tool_position(tool: dict) -> bytes:
    out = OutputStream()
    _write_throw_scene_tool_data(out, tool)
    return build_packet(PKT_RSP_SYNC_THROW_SCENE_TOOL_POSITION, out.get_bytes())


def build_rsp_throw_scene_tool_end(scene_tool_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id))
    return build_packet(PKT_RSP_THROW_SCENE_TOOL_END, out.get_bytes())


def build_rsp_report_throw_scene_tool_final_position(
    timestamp: int,
    tool: dict,
) -> bytes:
    out = OutputStream()
    out.write_u32(int(timestamp) & 0xFFFFFFFF)
    _write_throw_scene_tool_data(out, tool)
    return build_packet(PKT_RSP_REPORT_THROW_SCENE_TOOL_FINAL_POSITION, out.get_bytes())


def build_rsp_report_throw_scene_tool_final_position_with_relation(tool: dict) -> bytes:
    out = OutputStream()
    _write_throw_scene_tool_data(out, tool)
    return build_packet(PKT_RSP_REPORT_THROW_SCENE_TOOL_FINAL_POSITION_WITH_RELATION, out.get_bytes())


def build_rsp_use_scene_tool(
    bid: int,
    hand_item_id: int,
    scene_tool_unique_id: int,
    is_success: bool = True,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u32(hand_item_id)
    out.write_u64(scene_tool_unique_id)
    out.write_bool(is_success)
    return build_packet(PKT_RSP_USE_SCENE_TOOL, out.get_bytes())


def build_rsp_move_to_into_scene_tool(
    bid: int,
    scene_tool_unique_id: int,
    hand_item_id: int,
    is_success: bool = True,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u64(scene_tool_unique_id)
    out.write_u32(hand_item_id)
    out.write_bool(is_success)
    return build_packet(PKT_RSP_MOVE_TO_INTO_SCENE_TOOL, out.get_bytes())


def build_rsp_into_scene_tool(
    bid: int,
    scene_tool_unique_id: int,
    hand_item_id: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u64(scene_tool_unique_id)
    out.write_u32(hand_item_id)
    return build_packet(PKT_RSP_INTO_SCENE_TOOL, out.get_bytes())


def build_rsp_leave_scene_tool(bid: int, scene_tool_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u64(scene_tool_unique_id)
    return build_packet(PKT_RSP_LEAVE_SCENE_TOOL, out.get_bytes())


def build_rsp_get_back_place_scene_tool_failed(bid: int, scene_tool_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u64(scene_tool_unique_id)
    return build_packet(PKT_RSP_GET_BACK_PLACE_SCENE_TOOL_FAILED, out.get_bytes())


def build_rsp_get_back_place_scene_tool_operator(
    bid: int,
    scene_tool_unique_id: int,
    state: int,
    lerp_data: dict,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u64(int(scene_tool_unique_id))
    out.write_u8(int(state) & 0xFF)
    _write_lerp_data(out, lerp_data)
    return build_packet(PKT_RSP_GET_BACK_PLACE_SCENE_TOOL_OPERATOR, out.get_bytes())


def build_rsp_sync_player_state(
    bid: int,
    effect_type: int,
    effect_value: float,
    remain_time: float,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(bid) & 0xFF)
    out.write_u8(int(effect_type) & 0xFF)
    out.write_f32(float(effect_value))
    out.write_f32(float(remain_time))
    return build_packet(PKT_RSP_SYNC_PLAYER_STATE, out.get_bytes())


def build_rsp_use_place_scene_tool_operator(
    operator_bid: int,
    hand_item_id: int,
    scene_tool_unique_id: int,
    state: int,
    lerp_data: dict,
) -> bytes:
    out = OutputStream()
    out.write_u8(int(operator_bid) & 0xFF)
    out.write_u32(int(hand_item_id) & 0xFFFFFFFF)
    out.write_u64(int(scene_tool_unique_id))
    out.write_u8(int(state) & 0xFF)
    _write_lerp_data(out, lerp_data)
    return build_packet(PKT_RSP_USE_PLACE_SCENE_TOOL_OPERATOR, out.get_bytes())


def build_rsp_sync_item_state(
    item_uid: int,
    effect_type: int,
    effect_value: float,
    remain_time: float,
) -> bytes:
    out = OutputStream()
    out.write_u64(int(item_uid))
    out.write_u8(int(effect_type) & 0xFF)
    out.write_f32(float(effect_value))
    out.write_f32(float(remain_time))
    return build_packet(PKT_RSP_SYNC_ITEM_STATE, out.get_bytes())


def build_rsp_operate_scene(
    bid: int,
    hand_tool_id: int,
    hand_tool_config_id: int,
    target_index: int,
    state: int,
    *,
    flags: int | None = None,
    pose: dict | None = None,
    trans: dict | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if pose is not None:
            flags |= 0x01
        if trans is not None:
            flags |= 0x02
    flags &= 0x03
    out.write_u8(flags)
    out.write_u8(int(bid) & 0xFF)
    out.write_u32(int(hand_tool_id) & 0xFFFFFFFF)
    out.write_u32(int(hand_tool_config_id) & 0xFFFFFFFF)
    out.write_u32(int(target_index) & 0xFFFFFFFF)
    out.write_u8(int(state) & 0xFF)
    if flags & 0x01:
        _write_battle_pose(out, pose or {})
    if flags & 0x02:
        _write_transform_euler(out, trans or {})
    return build_packet(PKT_RSP_OPERATE_SCENE, out.get_bytes())



def build_rsp_player_agonal(
    player_bid: int,
    damage_type: int = 0,
    agonal_hp: int = 100,
    agonal_time: int = 30000,
    agonal_hp_speed: float = 1.0,
    agonal_time_speed: float = 1.0
) -> bytes:
    out = OutputStream()
    out.write_u8(int(player_bid) & 0xFF)
    out.write_u8(int(damage_type) & 0xFF)
    out.write_u32(int(agonal_hp))
    out.write_u32(int(agonal_time))
    out.write_f32(float(agonal_hp_speed))
    out.write_f32(float(agonal_time_speed))
    return build_packet(PKT_RSP_PLAYER_AGONAL, out.get_bytes())

def build_rsp_kill_me() -> bytes:
    return build_packet(PKT_RSP_KILL_ME, b'')


def build_rsp_shock_grenade_bomb(scene_tool_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(int(scene_tool_unique_id))
    return build_packet(PKT_RSP_SHOCK_GRENADE_BOMB, out.get_bytes())


def build_rsp_create_place_scene_tool(
    bid: int,
    scene_tool_unique_id: int,
    relevant_ids: list[int],
    affected_id: int | None,
    transform: dict,
    is_success: bool = True,
    flags: int | None = None,
) -> bytes:
    out = OutputStream()
    if flags is None:
        flags = 0
        if relevant_ids:
            flags |= 0x01
        if affected_id is not None:
            flags |= 0x02
    else:
        flags = int(flags) & 0x03
    out.write_u8(flags)
    out.write_u8(bid)
    out.write_u64(scene_tool_unique_id)
    if flags & 0x01:
        _write_u64_vector(out, relevant_ids)
    if flags & 0x02:
        out.write_u64(int(affected_id or 0))
    out.write_bool(is_success)
    _write_transform_euler(out, transform)
    return build_packet(PKT_RSP_CREATE_PLACE_SCENE_TOOL, out.get_bytes())


def build_rsp_grenade_begin(is_success: bool, grenade_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_bool(is_success)
    out.write_u64(grenade_unique_id)
    return build_packet(PKT_RSP_GRENADE_BEGIN, out.get_bytes())


def build_rsp_throw_grenade_end(
    reporter_id: int,
    grenade_unique_id: int,
    explosive_pos: tuple[float, float, float],
    throw_transform: dict,
) -> bytes:
    out = OutputStream()
    out.write_u32(reporter_id)
    out.write_u64(grenade_unique_id)
    _write_vector3(out, explosive_pos)
    _write_transform_euler(out, throw_transform)
    return build_packet(PKT_RSP_THROW_GRENADE_END, out.get_bytes())


def build_rsp_grenade_time_out(grenade_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_u64(grenade_unique_id)
    return build_packet(PKT_RSP_GRENADE_TIME_OUT, out.get_bytes())


def build_rsp_grenade_explosive_pos_report(
    grenade_unique_id: int,
    explosive_pos: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(grenade_unique_id)
    _write_vector3(out, explosive_pos)
    return build_packet(PKT_RSP_GRENADE_EXPLOSIVE_POS_REPORT, out.get_bytes())


def build_req_grenade_explosive_pos_report(
    grenade_unique_id: int,
    explosive_pos: tuple[float, float, float],
    throw_transform: dict,
) -> bytes:
    out = OutputStream()
    out.write_u64(grenade_unique_id)
    _write_vector3(out, explosive_pos)
    _write_transform_euler(out, throw_transform)
    return build_packet(PKT_REQ_GRENADE_EXPLOSIVE_POS_REPORT, out.get_bytes())


def build_req_grenade_explosive_pos_ntf(
    grenade_unique_id: int,
    remain_count: int,
    explosive_pos: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(grenade_unique_id)
    out.write_u32(remain_count)
    _write_vector3(out, explosive_pos)
    return build_packet(PKT_REQ_GRENADE_EXPLOSIVE_POS_NTF, out.get_bytes())


def build_rsp_cancel_throw_grenade(is_success: bool, grenade_unique_id: int) -> bytes:
    out = OutputStream()
    out.write_bool(is_success)
    out.write_u64(grenade_unique_id)
    return build_packet(PKT_RSP_CANCEL_THROW_GRENADE, out.get_bytes())


def build_rsp_smoke_bomb_explosive(throw_item_unique_id: int, explosive_timestamp: int) -> bytes:
    out = OutputStream()
    out.write_u64(throw_item_unique_id)
    out.write_u32(explosive_timestamp)
    return build_packet(PKT_RSP_SMOKE_BOMB_EXPLOSIVE, out.get_bytes())


def build_rsp_operate_gun_reload(
    bid: int,
    reload_type: int,
    hand_item_id: int,
    operate_state: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(reload_type)
    out.write_u32(hand_item_id)
    out.write_u8(operate_state)
    return build_packet(PKT_RSP_OPERATE_GUN_RELOAD, out.get_bytes())


def build_rsp_player_mark(bid: int, position: tuple[float, float, float]) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_vector3(out, position)
    return build_packet(PKT_RSP_PLAYER_MARK, out.get_bytes())


def build_rsp_quick_chat(bid: int, content: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u8(content)
    return build_packet(PKT_RSP_QUICK_CHAT, out.get_bytes())


def build_rsp_players_result_empty() -> bytes:
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_PLAYERS_RESULT, out.get_bytes())


def build_rsp_character_operate_blocking_board(
    bid: int,
    pose: dict,
    block_id: int,
    op: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_battle_pose(out, pose)
    out.write_cuint(block_id)
    out.write_u8(op)
    return build_packet(PKT_RSP_CHARACTER_OPERATE_BLOCKING_BOARD, out.get_bytes())


def build_rsp_event_blocking_board_state(
    board_id: int,
    player_id: int | None,
    state: int,
) -> bytes:
    out = OutputStream()
    # proto.game.RspEventBlockingBoardState starts with flags byte.
    # bit0 controls whether optional player_id (u64) is present.
    has_player_id = player_id is not None
    out.write_u8(0x01 if has_player_id else 0x00)
    out.write_cuint(board_id)
    if has_player_id:
        out.write_u64(int(player_id))
    out.write_u8(state)
    return build_packet(PKT_RSP_EVENT_BLOCKING_BOARD_STATE, out.get_bytes())


def build_rsp_character_action_explode(bid: int, hand_tool_id: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    out.write_u32(hand_tool_id)
    return build_packet(PKT_RSP_CHARACTER_ACTION_EXPLODE, out.get_bytes())


def build_rsp_character_operate_explosive(
    bid: int,
    pose: dict,
    pos: tuple[float, float, float],
    yaw: float,
    op: int,
) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_battle_pose(out, pose)
    _write_vector3(out, pos)
    out.write_f32(yaw)
    out.write_u8(op)
    return build_packet(PKT_RSP_CHARACTER_OPERATE_EXPLOSIVE, out.get_bytes())


def build_rsp_character_install_reinforced(bid: int, pose: dict, reinforced_id: int) -> bytes:
    out = OutputStream()
    out.write_u8(bid)
    _write_battle_pose(out, pose)
    out.write_cuint(reinforced_id)
    return build_packet(PKT_RSP_CHARACTER_INSTALL_REINFORCED, out.get_bytes())


def build_rsp_reinforced_state_update(reinforced_id: int, owner_bid: int, state: int) -> bytes:
    out = OutputStream()
    out.write_cuint(reinforced_id)
    out.write_u8(owner_bid)
    out.write_u8(state)
    return build_packet(PKT_RSP_REINFORCED_STATE_UPDATE, out.get_bytes())


def build_rsp_change_reinforced_state_error(reinforced_id: int) -> bytes:
    out = OutputStream()
    out.write_cuint(int(reinforced_id) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_CHANGE_REINFORCED_STATE_ERROR, out.get_bytes())


def build_rsp_event_wall_destroy(wall_id: int) -> bytes:
    out = OutputStream()
    out.write_cuint(int(wall_id) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_EVENT_WALL_DESTROY, out.get_bytes())


def build_rsp_event_wall_block_destroy(
    wall_id: int,
    damage_type: int,
    src_pos: tuple[float, float, float],
    blocks: list[int],
) -> bytes:
    out = OutputStream()
    out.write_cuint(int(wall_id) & 0xFFFFFFFF)
    out.write_u8(int(damage_type) & 0xFF)
    _write_vector3(out, src_pos)
    _write_cuint_vector(out, blocks)
    return build_packet(PKT_RSP_EVENT_WALL_BLOCK_DESTROY, out.get_bytes())


def build_rsp_reinforced_del(target_index: int) -> bytes:
    out = OutputStream()
    out.write_u32(int(target_index) & 0xFFFFFFFF)
    return build_packet(PKT_RSP_REINFORCED_DEL, out.get_bytes())


def build_rsp_wall_info(broken_walls: list[dict]) -> bytes:
    # RspWallInfo.Data: vector<Wall{id:u32, blocks:vector<u16>}>
    out = OutputStream()
    out.write_cuint(len(broken_walls))
    for wall in broken_walls:
        out.write_u32(int(wall.get('id', 0)) & 0xFFFFFFFF)
        _write_u16_vector(out, wall.get('blocks', []))
    return build_packet(PKT_RSP_WALL_INFO, out.get_bytes())


def build_rsp_dynamic_wall_info(dynamic_walls: list[dict]) -> bytes:
    # RspDynamicWallInfo.Data: vector<DynamicWall{id:u32,state:u8,blocks:vector<u16>}>
    out = OutputStream()
    out.write_cuint(len(dynamic_walls))
    for wall in dynamic_walls:
        out.write_u32(int(wall.get('id', 0)) & 0xFFFFFFFF)
        out.write_u8(int(wall.get('state', 0)) & 0xFF)
        _write_u16_vector(out, wall.get('blocks', []))
    return build_packet(PKT_RSP_DYNAMIC_WALL_INFO, out.get_bytes())


def build_rsp_reinforced_wall_info(
    reinforced_walls: list[dict],
    reinforced_wall_items: list[int],
) -> bytes:
    # RspReinforcedWallInfo.Data: vector<ReinforcedWall{id:u32,partitions:vector<id:u8,blocks:vector<u8>>}> + vector<u64>
    out = OutputStream()
    out.write_cuint(len(reinforced_walls))
    for wall in reinforced_walls:
        out.write_u32(int(wall.get('id', 0)) & 0xFFFFFFFF)
        partitions = wall.get('partitions', [])
        out.write_cuint(len(partitions))
        for part in partitions:
            out.write_u8(int(part.get('id', 0)) & 0xFF)
            _write_u8_vector(out, part.get('blocks', []))
    _write_u64_vector(out, reinforced_wall_items)
    return build_packet(PKT_RSP_REINFORCED_WALL_INFO, out.get_bytes())


def build_rsp_simple_quintain_info(broken_simple_quintains: list[int]) -> bytes:
    # RspSimpleQuintainInfo.Data: vector<u32> broken_simple_quintains
    out = OutputStream()
    _write_u32_vector(out, broken_simple_quintains)
    return build_packet(PKT_RSP_SIMPLE_QUINTAIN_INFO, out.get_bytes())


def build_rsp_pillar_group_info() -> bytes:
    # RspPillarGroupInfo.Data: vector<PillarGroup> broken_pillar_groups
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_PILLAR_GROUP_INFO, out.get_bytes())


def build_rsp_security_camera_info() -> bytes:
    # RspSecurityCameraInfo.Data: vector<u32> broken_security_cameras
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_SECURITY_CAMERA_INFO, out.get_bytes())


def build_rsp_game_player_info() -> bytes:
    # RspGamePlayerInfo.Data: vector<GamePlayerInfo> players
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_GAME_PLAYER_INFO, out.get_bytes())


def build_rsp_vehicle_info() -> bytes:
    # RspVehicleInfo.Data: vector<VehicleInfo> vehicles
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_VEHICLE_INFO, out.get_bytes())


def _write_simple_scene_item_info(out: OutputStream, item: dict):
    out.write_u64(int(item.get('uid', 0) or 0))
    transform = item.get('transform')
    if not isinstance(transform, dict):
        transform = {}
    _write_transform(out, transform)


def build_rsp_simple_scene_item_info(
    items: list[dict] | None = None,
) -> bytes:
    # RspSimpleSceneItemInfo.Data: vector<SimpleSceneItemInfo> items
    rows = [row for row in (items if isinstance(items, list) else []) if isinstance(row, dict)]
    out = OutputStream()
    out.write_cuint(len(rows))
    for row in rows:
        _write_simple_scene_item_info(out, row)
    return build_packet(PKT_RSP_SIMPLE_SCENE_ITEM_INFO, out.get_bytes())


def build_rsp_armor_package_info(session=None) -> bytes:
    out = OutputStream()
    packages = list(session.armor_packages.values()) if session else []
    out.write_cuint(len(packages))
    for pkg in packages:
        out.write_u64(pkg['uid'])
        _write_transform(out, pkg['transform'])
        out.write_u32(pkg['remain_num'])
    return build_packet(PKT_RSP_ARMOR_PACKAGE_INFO, out.get_bytes())


def build_rsp_electric_box_info() -> bytes:
    # RspElectricBoxInfo.Data: vector<ElectricBoxInfo> electric_boxes
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_ELECTRIC_BOX_INFO, out.get_bytes())


def build_rsp_mounted_lmg_info() -> bytes:
    # RspMountedLMGInfo.Data: vector<MountedLMGInfo> mounted_machine_guns
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_MOUNTED_LMG_INFO, out.get_bytes())


def build_rsp_buff_info() -> bytes:
    # RspBuffInfo.Data: vector<BuffData> buffs
    out = OutputStream()
    out.write_cuint(0)
    return build_packet(PKT_RSP_BUFF_INFO, out.get_bytes())


def build_rsp_operate_battle(op: int, is_success: bool = True) -> bytes:
    out = OutputStream()
    out.write_u8(int(op) & 0xFF)
    out.write_bool(bool(is_success))
    return build_packet(PKT_RSP_OPERATE_BATTLE, out.get_bytes())


def build_rsp_target_model_start_run(
    uid: int,
    duration: float,
    target_position: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u64(uid)
    out.write_f32(float(duration))
    _write_vector3(out, target_position)
    return build_packet(PKT_RSP_TARGET_MODEL_START_RUN, out.get_bytes())


def build_rsp_target_model_destroy(
    uid: int,
    damage_source: tuple[float, float, float] | None = None,
) -> bytes:
    out = OutputStream()
    has_damage_source = damage_source is not None
    out.write_u8(0x01 if has_damage_source else 0x00)
    out.write_u64(uid)
    if has_damage_source:
        _write_vector3(out, damage_source or (0.0, 0.0, 0.0))
    return build_packet(PKT_RSP_TARGET_MODEL_DESTROY, out.get_bytes())


def build_rsp_target_model_relive(uid: int) -> bytes:
    out = OutputStream()
    out.write_u64(uid)
    return build_packet(PKT_RSP_TARGET_MODEL_RELIVE, out.get_bytes())


def build_rsp_create_entity(
    uid: int,
    content_config_id: int,
    transform: dict | None = None,
) -> bytes:
    # RspCreateEntity.Data: u64 uid + u32 content_config_id + TransformEuler transform
    out = OutputStream()
    out.write_u64(int(uid) & 0xFFFFFFFFFFFFFFFF)
    out.write_u32(int(content_config_id) & 0xFFFFFFFF)
    _write_transform_euler(out, transform or {})
    return build_packet(PKT_RSP_CREATE_ENTITY, out.get_bytes())


def build_rsp_destroy_blocking_board(
    board_id: int,
    damage_source: tuple[float, float, float],
) -> bytes:
    out = OutputStream()
    out.write_u32(board_id)
    _write_vector3(out, damage_source)
    return build_packet(PKT_RSP_DESTROY_BLOCKING_BOARD, out.get_bytes())


def build_rsp_blocking_board_state(board_id: int, hp_percent: float) -> bytes:
    out = OutputStream()
    out.write_u32(board_id)
    out.write_f32(hp_percent)
    return build_packet(PKT_RSP_BLOCKING_BOARD_STATE, out.get_bytes())


def build_rsp_event_blocking_board_destroy(
    board_id: int,
    damage_source: tuple[float, float, float],
    destroyed_blocks: list[int],
) -> bytes:
    # Wire shape matches proto.game.RspEventBlockingBoardContentDestroy (id=0x2F).
    out = OutputStream()
    out.write_cuint(board_id)
    _write_vector3(out, damage_source)
    out.write_cuint(len(destroyed_blocks))
    for block_id in destroyed_blocks:
        out.write_cuint(block_id)
    return build_packet(PKT_RSP_EVENT_BLOCKING_BOARD_DESTROY, out.get_bytes())


def build_rsp_dynamic_block_break_state(dynamic_wall_id: int, is_breaking: bool) -> bytes:
    out = OutputStream()
    out.write_u32(int(dynamic_wall_id) & 0xFFFFFFFF)
    out.write_bool(bool(is_breaking))
    return build_packet(PKT_RSP_DYNAMIC_BLOCK_BREAK_STATE, out.get_bytes())


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Packet parsers (client в†’ server)
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

_CLIENT_INFO_STR8_FIELDS: tuple[str, ...] = (
    'app_ver',
    'utdid',
    'os',
    'account_id',
    'server_name',
    'server_id',
    'client_ip',
    'ch_user_type',
    'chuid',
    'sub_ch',
    'ch',
    'pkt_name',
    'brand',
    'uuid',
    'model',
)


def _read_client_info(stream: InputStream) -> dict:
    client_info = {'running_id': stream.read_u32()}
    for field_name in _CLIENT_INFO_STR8_FIELDS:
        client_info[field_name] = stream.read_str8()
    return client_info


def _build_payload_decoder_helpers() -> dict[str, Callable]:
    return {
        'read_vector3': _read_vector3,
        'read_quaternion': _read_quaternion,
        'read_transform': _read_transform,
        'read_transform_euler': _read_transform_euler,
        'read_throw_scene_tool_data': _read_throw_scene_tool_data,
        'read_battle_pose': _read_battle_pose,
        'read_pose_delta': _read_pose_delta,
        'read_battle_jump_on': _read_battle_jump_on,
        'read_battle_jump_over': _read_battle_jump_over,
        'read_battle_leave_wall_space_by_window': _read_battle_leave_wall_space_by_window,
        'read_battle_character_throw_rope': _read_battle_character_throw_rope,
        'read_battle_character_wall_space': _read_battle_character_wall_space,
        'read_scan_enemy_info': _read_scan_enemy_info,
        'read_battle_ray': _read_battle_ray,
        'read_hit_mark_target': _read_hit_mark_target,
        'read_hit_target_character': _read_hit_target_character,
        'read_character_be_hurt_info': _read_character_be_hurt_info,
        'read_melee_attack_target': _read_melee_attack_target,
        'read_lerp_data': _read_lerp_data,
        'read_perform_data': _read_perform_data,
        'read_one_bullet': _read_one_bullet,
        'read_client_info': _read_client_info,
    }


BATTLE_PAYLOAD_DECODER_HELPERS = _build_payload_decoder_helpers()


def _decode_payload_from_autogen(
    *,
    packet_class: str,
    stream: InputStream,
    fallback: Callable[[InputStream], dict] | None = None,
    normalizer: Callable[[dict], dict] | None = None,
) -> dict:
    start_pos = stream.pos
    if packet_class and is_payload_decoder_supported(packet_class):
        decoded: dict | None = None
        try:
            decoded = decode_battle_payload_autogen(
                packet_class,
                stream,
                helpers=BATTLE_PAYLOAD_DECODER_HELPERS,
            )
            # Guard against schema drift: decoded payload must consume
            # the whole packet body, otherwise prefer fallback parser.
            if stream.remaining != 0:
                stream._pos = start_pos
                decoded = None
        except NeedMoreData:
            raise
        except Exception:
            stream._pos = start_pos
            decoded = None
        if decoded is not None:
            if normalizer is not None:
                return normalizer(decoded)
            return decoded

    if fallback is None:
        raise NotImplementedError(f"no payload decoder and no fallback for {packet_class}")

    stream._pos = start_pos
    decoded = fallback(stream)
    if normalizer is not None:
        return normalizer(decoded)
    return decoded


def parse_req_ping(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqPing',
        stream=stream,
        fallback=lambda s: {'timestamp': s.read_u32()},
    )


def parse_req_enter_battle(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqEnterBattle',
        stream=stream,
        fallback=lambda s: {
            'uid': s.read_u32(),
            'battle_id': s.read_u64(),
            'token': s.read_str8(),
            'client_info': _read_client_info(s),
        },
    )


def parse_req_load_progress(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqLoadProgress',
        stream=stream,
        fallback=lambda s: {'progress': s.read_f32()},
    )


def parse_req_room_loaded(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqRoomLoaded',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_pkt_version(stream: InputStream) -> dict:
    """Parse PktVersion: 5 str8 version fields."""
    return _decode_payload_from_autogen(
        packet_class='PktVersion',
        stream=stream,
        fallback=lambda s: {
            'battle_gm': s.read_str8(),
            'common': s.read_str8(),
            'common_resources': s.read_str8(),
            'game': s.read_str8(),
            'scene': s.read_str8(),
        },
    )


def parse_req_character_pose(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterPose',
        stream=stream,
        fallback=lambda s: {
            'timestamp': s.read_u32(),
            'delta': _read_pose_delta(s),
        },
    )


def parse_req_character_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterState',
        stream=stream,
        fallback=lambda s: {
            'pose': _read_battle_pose(s),
            'state': s.read_u8(),
            'body_state': s.read_u8(),
        },
    )


def parse_req_character_jump_on(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterJumpOn',
        stream=stream,
        fallback=lambda s: {
            'pose': _read_battle_pose(s),
            'desc': _read_battle_jump_on(s),
        },
    )


def parse_req_character_throw_rope(stream: InputStream) -> dict:
    return {
        'climb_trigger_id': stream.read_u32(),
        'pose': _read_battle_pose(stream),
        'desc': _read_battle_character_throw_rope(stream),
    }


def parse_req_character_into_wall_space(stream: InputStream) -> dict:
    return {
        'desc': _read_battle_character_wall_space(stream),
        'wall_yaw': stream.read_f32(),
    }


def parse_req_character_jump_over(stream: InputStream) -> dict:
    pose = _read_battle_pose(stream)
    # Keep raw BattleCharacterJumpOver bytes to preserve contract exactly.
    desc_raw = stream.read_bytes(stream.remaining) if stream.remaining > 0 else b''
    return {
        'pose': pose,
        'desc_raw': desc_raw,
    }


def parse_req_character_leave_wall_space(stream: InputStream) -> dict:
    pose = _read_battle_pose(stream)
    # BattleCharacterWallSpace payload (pose-independent tail) is forwarded as-is.
    wall_space_raw = stream.read_bytes(stream.remaining) if stream.remaining > 0 else b''
    return {
        'pose': pose,
        'wall_space_raw': wall_space_raw,
    }


def parse_req_character_change_pose_in_wall(stream: InputStream) -> dict:
    pose = _read_battle_pose(stream)
    # EBodyState is serialized as enum<u8>; keep raw tail for exact echo.
    body_state_raw = stream.read_bytes(stream.remaining) if stream.remaining > 0 else b''
    return {
        'pose': pose,
        'body_state_raw': body_state_raw,
    }


def parse_req_character_leave_wall_space_by_window(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterLeaveWallSpaceByWindow',
        stream=stream,
        fallback=lambda s: {
            'dynamic_wall_id': s.read_u32(),
            'pose': _read_battle_pose(s),
            'desc': _read_battle_leave_wall_space_by_window(s),
        },
    )


def parse_req_character_gun_fire(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterGunFire',
        stream=stream,
        fallback=lambda s: {
            'gun_fire_type': s.read_u8(),
            'bullets': [_read_one_bullet(s) for _ in range(s.read_cuint())],
            'security_code': s.read_u32(),
        },
    )


def parse_req_character_action_melee_attack(stream: InputStream) -> dict:
    return {
        'melee_attack_type': stream.read_u8(),
    }


def parse_req_character_action_tilt(stream: InputStream) -> dict:
    return {
        'tilt_type': stream.read_u8(),
    }


def parse_req_character_lerp_pos(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterLerpPos',
        stream=stream,
        fallback=lambda s: {
            'body_state': s.read_u8(),
            'pose': _read_battle_pose(s),
            'lerp_data': _read_lerp_data(s),
        },
    )


def parse_req_character_operate_shield(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'pose': _read_battle_pose(stream),
        'op': stream.read_u8(),
    }
    if flags & 0x01:
        req['pos_x'] = stream.read_f32()
    if flags & 0x02:
        req['pos_y'] = stream.read_f32()
    if flags & 0x04:
        req['pos_z'] = stream.read_f32()
    if flags & 0x08:
        req['yaw'] = stream.read_f32()
    return req


def parse_req_shield_state_update(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'shield_state': stream.read_u8(),
    }
    if flags & 0x01:
        req['pos_x'] = stream.read_f32()
    if flags & 0x02:
        req['pos_y'] = stream.read_f32()
    if flags & 0x04:
        req['pos_z'] = stream.read_f32()
    if flags & 0x08:
        req['yaw'] = stream.read_f32()
    return req


def parse_req_destroy_scene_object(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'destroy_type': stream.read_u8(),
    }
    if flags & 0x01:
        req['destroy_pos'] = _read_vector3(stream)
    req['destroy_objects'] = [stream.read_u64() for _ in range(stream.read_cuint())]
    if 'destroy_pos' not in req:
        req['destroy_pos'] = (0.0, 0.0, 0.0)
    return req


def parse_req_character_action_take_out_pad(stream: InputStream) -> dict:
    del stream
    return {}


def parse_req_scan_enemies(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqScanEnemies',
        stream=stream,
        fallback=lambda s: {
            'vehicle_id': s.read_u64(),
            'pos': _read_vector3(s),
            'enemies': [_read_scan_enemy_info(s) for _ in range(s.read_cuint())],
        },
    )


def parse_req_character_operation(stream: InputStream) -> dict:
    return {
        'tool_index': stream.read_u16(),
        'operation': stream.read_u16(),
    }


def parse_req_operate_tool(stream: InputStream) -> dict:
    return {
        'tool_index': stream.read_u16(),
        'operation_type': stream.read_u8(),
        'state': stream.read_u8(),
    }


def parse_req_sync_character_action(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncCharacterAction',
        stream=stream,
        fallback=lambda s: {
            'action': s.read_u32(),
            'duration': s.read_f32(),
            'duration_coefficient': s.read_f32(),
        },
    )


def parse_req_switch_current_unmanned_vehicle(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSwitchCurrentUnmannedVehicle',
        stream=stream,
        fallback=lambda s: {
            'vehicle_id': s.read_u64(),
        },
    )


def parse_req_switch_current_monitor(stream: InputStream) -> dict:
    return {
        'monitor_id': stream.read_u32(),
    }


def parse_req_unmanned_vehicle_spawn(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqUnmannedVehicleSpawn',
        stream=stream,
        fallback=lambda s: {
            'vehicle_id': s.read_u64(),
            'pose': _read_battle_pose(s),
        },
    )


def parse_req_unmanned_vehicle_pose_delta(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqUnmannedVehiclePoseDelta',
        stream=stream,
        fallback=lambda s: _parse_req_unmanned_vehicle_pose_delta_manual(s),
    )


def parse_req_unmanned_vehicle_take_back(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqUnmannedVehicleTakeBack',
        stream=stream,
        fallback=lambda s: {
            'vehicle_id': s.read_u64(),
        },
    )


def parse_req_switch_unmanned_vehicle_to_character(stream: InputStream) -> dict:
    del stream
    return {}


def parse_req_monitor_scan_enemies(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqMonitorScanEnemies',
        stream=stream,
        fallback=lambda s: {
            'monitor_id': s.read_u32(),
            'view_yaw': s.read_f32(),
            'view_pitch': s.read_f32(),
            'enemies': [_read_scan_enemy_info(s) for _ in range(s.read_cuint())],
        },
    )


def parse_req_switch_monitor_to_character(stream: InputStream) -> dict:
    del stream
    return {}


def parse_req_monitor_pose_delta(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'monitor_id': stream.read_u32(),
    }
    if flags & 0x01:
        req['view_pitch'] = stream.read_f32()
    if flags & 0x02:
        req['view_yaw'] = stream.read_f32()
    return req


def parse_req_found_critical_target(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqFoundCriticalTarget',
        stream=stream,
        fallback=lambda s: {
            'region_id': s.read_u32(),
        },
        normalizer=lambda data: {
            'region_id': int(data.get('region_id', data.get('critical_region_id', 0)) or 0),
        },
    )


def parse_req_character_climb_ladder(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterClimbLadder',
        stream=stream,
        fallback=lambda s: {
            'ladder_id': s.read_u32(),
            'is_up': s.read_bool(),
        },
        normalizer=lambda data: {
            'ladder_id': int(data.get('ladder_id', 0) or 0),
            'is_up': bool(data.get('is_up', False)),
        },
    )


def parse_req_character_leave_ladder(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterLeaveLadder',
        stream=stream,
        fallback=lambda s: {
            'ladder_id': s.read_u32(),
            'is_up': s.read_bool(),
        },
        normalizer=lambda data: {
            'ladder_id': int(data.get('ladder_id', 0) or 0),
            'is_up': bool(data.get('is_up', False)),
        },
    )


def parse_req_bomb_gun_fire(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqBombGunFire',
        stream=stream,
        fallback=lambda s: {
            'bullet_id': s.read_u64(),
            'ray': _read_battle_ray(s),
            'euler': _read_vector3(s),
            'security_code': s.read_u32(),
        },
        normalizer=lambda data: {
            'bullet_id': int(data.get('bullet_id', 0) or 0),
            'ray': data.get('ray', {}),
            'euler': data.get('euler', data.get('angles', (0.0, 0.0, 0.0))),
            'security_code': int(data.get('security_code', 0) or 0),
        },
    )


def parse_req_bomb_bullet_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqBombBulletState',
        stream=stream,
        fallback=lambda s: _parse_req_bomb_bullet_state_manual(s),
        normalizer=lambda data: _normalize_req_bomb_bullet_state(data),
    )


def _normalize_req_bomb_bullet_state(data: dict) -> dict:
    behurt_info = data.get('behurt_info', data.get('be_hurt_info'))
    hit_target = data.get('hit_target')
    flags = int(data.get('flags', 0) or 0) & 0x03
    if flags == 0:
        if behurt_info is not None:
            flags |= 0x01
        if hit_target is not None:
            flags |= 0x02
    return {
        'flags': flags,
        'scene_tool_unique_id': int(data.get('scene_tool_unique_id', data.get('bullet_id', 0)) or 0),
        'trans': data.get('trans', data.get('transform', {})),
        'state': int(data.get('state', data.get('bullet_state', 0)) or 0) & 0xFF,
        'behurt_info': behurt_info,
        'hit_target': hit_target,
    }


def _parse_req_bomb_bullet_state_manual(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'scene_tool_unique_id': stream.read_u64(),
        'trans': _read_transform(stream),
        'state': stream.read_u8(),
    }
    if flags & 0x01:
        req['behurt_info'] = _read_character_be_hurt_info(stream)
    if flags & 0x02:
        req['hit_target'] = _read_hit_mark_target(stream)
    return req


def parse_req_vehicle_launch_tracker(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqVehicleLaunchTracker',
        stream=stream,
        fallback=lambda s: {
            'pos_start': _read_vector3(s),
            'pos_ends': [_read_vector3(s) for _ in range(s.read_cuint())],
            'target_bids': [s.read_u8() for _ in range(s.read_cuint())],
        },
        normalizer=lambda data: _normalize_req_vehicle_launch_tracker(data),
    )


def _normalize_req_vehicle_launch_tracker(data: dict) -> dict:
    pos_start_raw = data.get('pos_start', (0.0, 0.0, 0.0))
    pos_start = (0.0, 0.0, 0.0)
    if isinstance(pos_start_raw, (tuple, list)) and len(pos_start_raw) == 3:
        pos_start = (
            float(pos_start_raw[0]),
            float(pos_start_raw[1]),
            float(pos_start_raw[2]),
        )

    pos_ends: list[tuple[float, float, float]] = []
    raw_pos_ends = data.get('pos_ends', [])
    if isinstance(raw_pos_ends, list):
        for row in raw_pos_ends:
            if not isinstance(row, (tuple, list)) or len(row) != 3:
                continue
            pos_ends.append((float(row[0]), float(row[1]), float(row[2])))

    target_bids: list[int] = []
    raw_target_bids = data.get('target_bids', [])
    if isinstance(raw_target_bids, list):
        for bid in raw_target_bids:
            target_bids.append(int(bid) & 0xFF)

    return {
        'pos_start': pos_start,
        'pos_ends': pos_ends,
        'target_bids': target_bids,
    }


def parse_req_active_tracker(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqActiveTracker',
        stream=stream,
        fallback=lambda s: {
            'tool_index': s.read_u16(),
        },
        normalizer=lambda data: {
            'tool_index': int(data.get('tool_index', 0) or 0) & 0xFFFF,
        },
    )


def parse_req_disturbed_operate(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqDisturbedOperate',
        stream=stream,
        fallback=lambda s: {
            'item_uid': s.read_u64(),
            'tool_index': s.read_u16(),
            'op': s.read_u8(),
        },
        normalizer=lambda data: {
            'item_uid': int(data.get('item_uid', 0) or 0),
            'tool_index': int(data.get('tool_index', 0) or 0) & 0xFFFF,
            'op': int(data.get('op', 0) or 0) & 0xFF,
        },
    )


def parse_req_character_hammer_attack(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterHammerAttack',
        stream=stream,
        fallback=lambda s: _parse_req_character_hammer_attack_manual(s),
        normalizer=lambda data: _normalize_req_character_hammer_attack(data),
    )


def _normalize_req_character_hammer_attack(data: dict) -> dict:
    target = data.get('target')
    flags = int(data.get('flags', 0) or 0) & 0x01
    if flags == 0 and target is not None:
        flags |= 0x01
    return {
        'flags': flags,
        'forward_ray': data.get('forward_ray', {}),
        'target': target,
        'target_type': int(data.get('target_type', 0) or 0) & 0xFF,
        'trans': data.get('trans', data.get('transform', {})),
        'target_mat': int(data.get('target_mat', 0) or 0) & 0xFF,
    }


def _parse_req_character_hammer_attack_manual(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req: dict = {
        'flags': flags,
        'forward_ray': _read_battle_ray(stream),
    }
    if flags & 0x01:
        req['target'] = _read_melee_attack_target(stream)
    req['target_type'] = stream.read_u8()
    req['trans'] = _read_transform(stream)
    req['target_mat'] = stream.read_u8()
    return req


def parse_req_character_action_hammer_attack(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterActionHammerAttack',
        stream=stream,
        fallback=lambda s: {},
    )


def _coerce_vector3_tuple(value: object, default: tuple[float, float, float] = (0.0, 0.0, 0.0)) -> tuple[float, float, float]:
    if isinstance(value, (tuple, list)) and len(value) == 3:
        return (
            float(value[0]),
            float(value[1]),
            float(value[2]),
        )
    return default


def _coerce_quaternion_tuple(
    value: object,
    default: tuple[float, float, float, float] = (0.0, 0.0, 0.0, 1.0),
) -> tuple[float, float, float, float]:
    if isinstance(value, (tuple, list)) and len(value) == 4:
        return (
            float(value[0]),
            float(value[1]),
            float(value[2]),
            float(value[3]),
        )
    return default


def parse_req_client_cheat_report(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqClientCheatReport',
        stream=stream,
        fallback=lambda s: {
            'bid': s.read_u8(),
            'key': s.read_u8(),
            'value': s.read_u8(),
        },
        normalizer=lambda data: {
            'bid': int(data.get('bid', 0) or 0) & 0xFF,
            'key': int(data.get('key', 0) or 0) & 0xFF,
            'value': int(data.get('value', 0) or 0) & 0xFF,
        },
    )


def parse_req_character_action_install_trap_bomb(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterActionInstallTrapBomb',
        stream=stream,
        fallback=lambda s: {
            'trap_bomb_uid': s.read_u64(),
            'pos': _read_vector3(s),
            'rot': _read_quaternion(s),
            'install_type': s.read_u8(),
        },
        normalizer=lambda data: {
            'trap_bomb_uid': int(data.get('trap_bomb_uid', 0) or 0),
            'pos': _coerce_vector3_tuple(data.get('pos')),
            'rot': _coerce_quaternion_tuple(data.get('rot')),
            'install_type': int(data.get('install_type', 0) or 0) & 0xFF,
        },
    )


def parse_req_trap_bomb_installed(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqTrapBombInstalled',
        stream=stream,
        fallback=lambda s: {
            'trap_bomb_uid': s.read_u64(),
            'block_id': s.read_u32(),
            'bomb_pos': _read_vector3(s),
            'bomb_rot': _read_quaternion(s),
            'bomb_extens': _read_vector3(s),
            'trigger_pos': _read_vector3(s),
            'trigger_extens': _read_vector3(s),
            'install_type': s.read_u8(),
        },
        normalizer=lambda data: {
            'trap_bomb_uid': int(data.get('trap_bomb_uid', 0) or 0),
            'block_id': int(data.get('block_id', 0) or 0) & 0xFFFFFFFF,
            'bomb_pos': _coerce_vector3_tuple(data.get('bomb_pos')),
            'bomb_rot': _coerce_quaternion_tuple(data.get('bomb_rot')),
            'bomb_extens': _coerce_vector3_tuple(data.get('bomb_extens')),
            'trigger_pos': _coerce_vector3_tuple(data.get('trigger_pos')),
            'trigger_extens': _coerce_vector3_tuple(data.get('trigger_extens')),
            'install_type': int(data.get('install_type', 0) or 0) & 0xFF,
        },
    )


def parse_req_character_action_uninstall_trap_bomb(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterActionUninstallTrapBomb',
        stream=stream,
        fallback=lambda s: {
            'trap_bomb_uid': s.read_u64(),
        },
        normalizer=lambda data: {
            'trap_bomb_uid': int(data.get('trap_bomb_uid', 0) or 0),
        },
    )


def parse_req_trap_bomb_uninstalled(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqTrapBombUninstalled',
        stream=stream,
        fallback=lambda s: {
            'trap_bomb_uid': s.read_u64(),
        },
        normalizer=lambda data: {
            'trap_bomb_uid': int(data.get('trap_bomb_uid', 0) or 0),
        },
    )


def parse_req_trigger_trap_bomb(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqTriggerTrapBomb',
        stream=stream,
        fallback=lambda s: {
            'trap_bomb_uid': s.read_u64(),
            'char_pos': _read_vector3(s),
        },
        normalizer=lambda data: {
            'trap_bomb_uid': int(data.get('trap_bomb_uid', 0) or 0),
            'char_pos': _coerce_vector3_tuple(data.get('char_pos')),
        },
    )


def parse_req_throw_item(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowItem',
        stream=stream,
        fallback=lambda s: {
            'throw_item_unique_id': s.read_u64(),
            'client_param': s.read_u32(),
            'ray': _read_battle_ray(s),
            'angle': _read_vector3(s),
        },
        normalizer=lambda data: {
            'throw_item_unique_id': int(data.get('throw_item_unique_id', 0) or 0),
            'client_param': int(data.get('client_param', 0) or 0) & 0xFFFFFFFF,
            'ray': data.get('ray', {}),
            'angle': _coerce_vector3_tuple(data.get('angle')),
        },
    )


def parse_req_item_pos_report(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqItemPosReport',
        stream=stream,
        fallback=lambda s: {
            'throw_item_unique_id': s.read_u64(),
            'ray': _read_battle_ray(s),
            'angle': _read_vector3(s),
        },
        normalizer=lambda data: {
            'throw_item_unique_id': int(data.get('throw_item_unique_id', 0) or 0),
            'ray': data.get('ray', {}),
            'angle': _coerce_vector3_tuple(data.get('angle')),
        },
    )


def parse_req_throw_item_drop_down(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowItemDropDown',
        stream=stream,
        fallback=lambda s: {
            'throw_item_unique_id': s.read_u64(),
            'ray': _read_battle_ray(s),
        },
        normalizer=lambda data: {
            'throw_item_unique_id': int(data.get('throw_item_unique_id', 0) or 0),
            'ray': data.get('ray', {}),
        },
    )


def parse_req_throw_item_stoped(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowItemStoped',
        stream=stream,
        fallback=lambda s: {
            'throw_item_unique_id': s.read_u64(),
            'trans': _read_transform_euler(s),
            'relates': _read_u64_vector(s),
        },
        normalizer=lambda data: {
            'throw_item_unique_id': int(data.get('throw_item_unique_id', 0) or 0),
            'trans': data.get('trans', data.get('transform', {})),
            'relates': [
                int(row)
                for row in (data.get('relates', []) if isinstance(data.get('relates', []), list) else [])
            ],
        },
    )


def parse_req_game_points(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGamePoints',
        stream=stream,
        fallback=lambda s: {
            'player_id': s.read_u64(),
        },
        normalizer=lambda data: {
            'player_id': int(data.get('player_id', 0) or 0),
        },
    )


def parse_req_operate_character(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqOperateCharacter',
        stream=stream,
        fallback=lambda s: {
            'hand_tool_id': s.read_u32(),
            'hand_tool_config_id': s.read_u32(),
            'target_player_bid': s.read_u8(),
            'state': s.read_u8(),
        },
        normalizer=lambda data: {
            'hand_tool_id': int(data.get('hand_tool_id', 0) or 0) & 0xFFFFFFFF,
            'hand_tool_config_id': int(data.get('hand_tool_config_id', 0) or 0) & 0xFFFFFFFF,
            'target_player_bid': int(data.get('target_player_bid', 0) or 0) & 0xFF,
            'state': int(data.get('state', 0) or 0) & 0xFF,
        },
    )


def parse_req_throw_neuro_toxin(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowNeuroToxin',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
            'client_param': s.read_u32(),
            'trans': _read_transform(s),
            'speed': _read_vector3(s),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
            'client_param': int(data.get('client_param', 0) or 0) & 0xFFFFFFFF,
            'trans': data.get('trans', data.get('transform', {})),
            'speed': _coerce_vector3_tuple(data.get('speed')),
        },
    )


def parse_req_sync_neuro_toxin_position(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncNeuroToxinPosition',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
            'trans': _read_transform(s),
            'speed': _read_vector3(s),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
            'trans': data.get('trans', data.get('transform', {})),
            'speed': _coerce_vector3_tuple(data.get('speed')),
        },
    )


def _parse_req_throw_neuro_toxin_end_manual(stream: InputStream) -> dict:
    # Runtime contract gates relevant_id vector by flags bit 0.
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'scene_tool_unique_id': stream.read_u64(),
        'trans': _read_transform(stream),
        'speed': _read_vector3(stream),
    }
    if flags & 0x01:
        req['relevant_id'] = _read_u64_vector(stream)
    return req


def parse_req_throw_neuro_toxin_end(stream: InputStream) -> dict:
    req = _parse_req_throw_neuro_toxin_end_manual(stream)
    return {
        'flags': int(req.get('flags', 0) or 0) & 0xFF,
        'scene_tool_unique_id': int(req.get('scene_tool_unique_id', 0) or 0),
        'trans': req.get('trans', {}),
        'speed': _coerce_vector3_tuple(req.get('speed')),
        'relevant_id': [
            int(row)
            for row in (
                req.get('relevant_id', []) if isinstance(req.get('relevant_id', []), list) else []
            )
        ],
    }


def parse_req_remove_neuro_toxin_operator(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqRemoveNeuroToxinOperator',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_remove_neuro_toxin_effect(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqRemoveNeuroToxinEffect',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_get_back_neuro_toxin_operator(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGetBackNeuroToxinOperator',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
            'player_current_transform': _read_transform(s),
            'state': s.read_u8(),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
            'player_current_transform': data.get('player_current_transform', {}),
            'state': int(data.get('state', 0) or 0) & 0xFF,
        },
    )


def parse_req_get_back_neuro_toxin_tool(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGetBackNeuroToxinTool',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
        },
    )


def _parse_req_unmanned_vehicle_pose_delta_manual(stream: InputStream) -> dict:
    # Runtime contract uses flags before optional f32 fields.
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'vehicle_id': stream.read_u64(),
    }
    if flags & 0x01:
        req['pos_x'] = stream.read_f32()
    if flags & 0x02:
        req['pos_y'] = stream.read_f32()
    if flags & 0x04:
        req['pos_z'] = stream.read_f32()
    if flags & 0x08:
        req['yaw'] = stream.read_f32()
    if flags & 0x10:
        req['view_pitch'] = stream.read_f32()
    if flags & 0x20:
        req['view_yaw'] = stream.read_f32()
    if flags & 0x40:
        req['view_roll'] = stream.read_f32()
    return req


def parse_req_character_operate_blocking_board(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterOperateBlockingBoard',
        stream=stream,
        fallback=lambda s: {
            'pose': _read_battle_pose(s),
            'block_id': s.read_cuint(),
            'op': s.read_u8(),
        },
    )


def parse_req_change_blocking_board_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqChangeBlockingBoardState',
        stream=stream,
        fallback=lambda s: {
            'id': s.read_cuint(),
            'state': s.read_u8(),
        },
    )


def parse_req_character_melee_attack(stream: InputStream) -> dict:
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'melee_cfg_id': stream.read_u32(),
        'forward_ray': _read_battle_ray(stream),
    }
    if flags & 0x01:
        req['target'] = _read_melee_attack_target(stream)
    return req


def parse_req_character_action_aiming(stream: InputStream) -> dict:
    return {
        'aiming': stream.read_bool(),
    }


def parse_req_character_action_explode(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterActionExplodeExplosive',
        stream=stream,
        fallback=lambda s: {
            'hand_tool_id': s.read_u32(),
        },
    )


def parse_req_character_operate_explosive(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterOperateExplosive',
        stream=stream,
        fallback=lambda s: {
            'pose': _read_battle_pose(s),
            'pos': _read_vector3(s),
            'yaw': s.read_f32(),
            'op': s.read_u8(),
        },
    )


def parse_req_character_install_reinforced(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqCharacterInstallReinforced',
        stream=stream,
        fallback=lambda s: {
            'pose': _read_battle_pose(s),
            'reinforced_id': s.read_cuint(),
        },
    )


def parse_req_change_reinforced_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqChangeReinforcedState',
        stream=stream,
        fallback=lambda s: {
            'id': s.read_cuint(),
            'state': s.read_u8(),
        },
    )


def parse_req_destroy_blocking_board(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqDestroyBlockingBoard',
        stream=stream,
        fallback=lambda s: {
            'board_id': s.read_u32(),
            'damage_source': _read_vector3(s),
        },
    )


def parse_req_game_info(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGameInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_leave_battle(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqLeaveBattle',
        stream=stream,
        fallback=lambda s: {'leave_kind': s.read_u8()},
        normalizer=lambda data: {
            'leave_kind': int(data.get('kind', data.get('leave_kind', 0)) or 0),
        },
    )


def parse_req_grenade_begin(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGrenadeBegin',
        stream=stream,
        fallback=lambda s: {
            'grenade_unique_id': s.read_u64(),
        },
        normalizer=lambda data: {
            'grenade_unique_id': int(
                data.get('grenade_id', data.get('grenade_unique_id', 0)) or 0
            ),
        },
    )

def parse_req_cancel_throw_grenade(stream: InputStream) -> dict:
    return {
        'grenade_unique_id': stream.read_u64(),
    }


def parse_req_throw_grenade_end(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowGrenadeEnd',
        stream=stream,
        fallback=lambda s: {
            'grenade_unique_id': s.read_u64(),
            'explosive_pos': _read_vector3(s),
            'throw_transform': _read_transform_euler(s),
        },
        normalizer=lambda data: {
            'grenade_unique_id': int(
                data.get('grenade_id', data.get('grenade_unique_id', 0)) or 0
            ),
            'explosive_pos': data.get('dir', data.get('explosive_pos', (0.0, 0.0, 0.0))),
            'throw_transform': data.get('trans', data.get('throw_transform', {})),
        },
    )


def parse_req_grenade_explosive_pos_report(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGrenadeExplosivePosReport',
        stream=stream,
        fallback=lambda s: {
            'grenade_unique_id': s.read_u64(),
            'explosive_pos': _read_vector3(s),
            'throw_transform': _read_transform_euler(s),
        },
        normalizer=lambda data: {
            'grenade_unique_id': int(
                data.get('grenade_id', data.get('grenade_unique_id', 0)) or 0
            ),
            'explosive_pos': data.get('dir', data.get('explosive_pos', (0.0, 0.0, 0.0))),
            'throw_transform': data.get('trans', data.get('throw_transform', {})),
        },
    )


def parse_req_grenade_explosive_pos_ntf(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGrenadeExplosivePosNtf',
        stream=stream,
        fallback=lambda s: {
            'grenade_unique_id': s.read_u64(),
            'remain_count': s.read_u32(),
            'explosive_pos': _read_vector3(s),
        },
        normalizer=lambda data: {
            'grenade_unique_id': int(
                data.get('grenade_id', data.get('grenade_unique_id', 0)) or 0
            ),
            'remain_count': int(data.get('count', data.get('remain_count', 0)) or 0),
            'explosive_pos': data.get('pos', data.get('explosive_pos', (0.0, 0.0, 0.0))),
        },
    )


def parse_rsp_grenade_explosive_pos_report(stream: InputStream) -> dict:
    return {
        'grenade_unique_id': stream.read_u64(),
        'explosive_pos': _read_vector3(stream),
    }


def parse_req_bomb_explosive(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqBombExplosive',
        stream=stream,
        fallback=lambda s: {
            'throw_item_unique_id': s.read_u64(),
            'client_param': s.read_u32(),
            'transform': _read_transform_euler(s),
        },
        normalizer=lambda data: {
            'throw_item_unique_id': int(data.get('throw_item_unique_id', 0) or 0),
            'client_param': int(data.get('client_param', 0) or 0),
            'transform': data.get('trans', data.get('transform', {})),
        },
    )


def parse_req_operate_gun_reload(stream: InputStream) -> dict:
    return {
        'reload_type': stream.read_u8(),
        'hand_item_id': stream.read_u32(),
        'operate_state': stream.read_u8(),
    }


def parse_req_player_mark(stream: InputStream) -> dict:
    return {
        'position': _read_vector3(stream),
    }


def parse_req_quick_chat(stream: InputStream) -> dict:
    return {
        'content': stream.read_u8(),
    }


def parse_req_reset_item_num(stream: InputStream) -> dict:
    # proto.game.ReqResetItemNum has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqResetItemNum',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_wall_info(stream: InputStream) -> dict:
    # proto.game.ReqWallInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqWallInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_dynamic_wall_info(stream: InputStream) -> dict:
    # proto.game.ReqDynamicWallInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqDynamicWallInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_reinforced_wall_info(stream: InputStream) -> dict:
    # proto.game.ReqReinforcedWallInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqReinforcedWallInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_simple_quintain_info(stream: InputStream) -> dict:
    # proto.game.ReqSimpleQuintainInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqSimpleQuintainInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_pillar_group_info(stream: InputStream) -> dict:
    # proto.game.ReqPillarGroupInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqPillarGroupInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_security_camera_info(stream: InputStream) -> dict:
    # proto.game.ReqSecurityCameraInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqSecurityCameraInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_game_player_info(stream: InputStream) -> dict:
    # proto.game.ReqGamePlayerInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqGamePlayerInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_vehicle_info(stream: InputStream) -> dict:
    # proto.game.ReqVehicleInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqVehicleInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_simple_scene_item_info(stream: InputStream) -> dict:
    # proto.game.ReqSimpleSceneItemInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqSimpleSceneItemInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_armor_package_info(stream: InputStream) -> dict:
    # proto.game.ReqArmorPackageInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqArmorPackageInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_electric_box_info(stream: InputStream) -> dict:
    # proto.game.ReqElectricBoxInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqElectricBoxInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_mounted_lmg_info(stream: InputStream) -> dict:
    # proto.game.ReqMountedLMGInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqMountedLMGInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_buff_info(stream: InputStream) -> dict:
    # proto.game.ReqBuffInfo has an empty body.
    return _decode_payload_from_autogen(
        packet_class='ReqBuffInfo',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_players_result(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqPlayersResult',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_ground_material(stream: InputStream) -> dict:
    return {
        'material': stream.read_u32(),
    }


def parse_req_sync_character_tool(stream: InputStream) -> dict:
    return {
        'tool_index': stream.read_u16(),
    }


def parse_req_sync_character_assist_tool(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncCharacterAssistTool',
        stream=stream,
        fallback=lambda s: {
            'assist_tool_index': s.read_u16(),
        },
        normalizer=lambda data: {
            'assist_tool_index': int(data.get('assist_tool_index', 0) or 0) & 0xFFFF,
        },
    )


def parse_req_sync_stretch_hand_shield_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncStretchHandShieldState',
        stream=stream,
        fallback=lambda s: {
            'is_expanded': s.read_bool(),
        },
        normalizer=lambda data: {
            'is_expanded': bool(data.get('is_expanded', False)),
        },
    )


def parse_req_sync_hand_shield_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncHandShieldState',
        stream=stream,
        fallback=lambda s: {
            'tool_index': s.read_u16(),
            'is_in_back': s.read_bool(),
        },
        normalizer=lambda data: {
            'tool_index': int(data.get('tool_index', 0) or 0) & 0xFFFF,
            'is_in_back': bool(data.get('is_in_back', False)),
        },
    )


def parse_req_trigger_flash_hand_shield(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqTriggerFlashHandShield',
        stream=stream,
        fallback=lambda s: {
            'flash_point': _read_transform(s),
        },
        normalizer=lambda data: {
            'flash_point': data.get('flash_point', data.get('transform', {})),
        },
    )


def _parse_req_gen_robot_manual(stream: InputStream) -> dict:
    # Runtime contract uses flags for optional transform and state fields.
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'config_id': stream.read_u32(),
    }
    if flags & 0x01:
        req['transform'] = _read_transform_euler(stream)
    if flags & 0x02:
        req['state'] = stream.read_u8()
    return req


def parse_req_gen_robot(stream: InputStream) -> dict:
    req = _parse_req_gen_robot_manual(stream)
    state = req.get('state')
    return {
        'flags': int(req.get('flags', 0) or 0) & 0x03,
        'config_id': int(req.get('config_id', 0) or 0) & 0xFFFFFFFF,
        'transform': req.get('transform'),
        'state': (int(state) & 0xFF) if state is not None else None,
    }


def parse_req_found_bomb_target(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqFoundBombTarget',
        stream=stream,
        fallback=lambda s: {
            'region_id': s.read_u32(),
        },
        normalizer=lambda data: {
            'region_id': int(data.get('region_id', 0) or 0) & 0xFFFFFFFF,
        },
    )


def parse_req_notify_defuser_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqNotifyDefuserState',
        stream=stream,
        fallback=lambda s: {
            'state': s.read_u8(),
        },
        normalizer=lambda data: {
            'state': int(data.get('state', 0) or 0) & 0xFF,
        },
    )


def parse_req_found_defuser(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqFoundDefuser',
        stream=stream,
        fallback=lambda s: {
            'defuser_id': s.read_u64(),
        },
        normalizer=lambda data: {
            'defuser_id': int(data.get('defuser_id', 0) or 0),
        },
    )


def parse_req_pick_up_defuser(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqPickUpDefuser',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_drop_defuser(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqDropDefuser',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_add_robot(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqAddRobot',
        stream=stream,
        fallback=lambda s: {
            'param': s.read_str8(),
        },
        normalizer=lambda data: {
            'param': str(data.get('param', '') or ''),
        },
    )


def parse_req_operate_battle(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqOperateBattle',
        stream=stream,
        fallback=lambda s: {
            'op': s.read_u8(),
        },
        normalizer=lambda data: {
            'op': int(data.get('op', 0) or 0) & 0xFF,
        },
    )


def parse_req_robot_move(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqRobotMove',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_robot_fire(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqRobotFire',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_sync_perform_data(stream: InputStream) -> dict:
    return {
        'data_type': stream.read_u32(),
        'perform_data': _read_perform_data(stream),
    }


def parse_req_place_tool_operator(stream: InputStream) -> dict:
    flags = stream.read_u8()
    hand_item_id = stream.read_u32()
    relevant_ids = _read_u64_vector(stream) if (flags & 0x01) else []
    affected_id = stream.read_u64() if (flags & 0x02) else None
    duration = stream.read_f32()
    state = stream.read_u8()
    lerp_data = _read_lerp_data(stream)
    return {
        'flags': flags,
        'hand_item_id': hand_item_id,
        'relevant_ids': relevant_ids,
        'affected_id': affected_id,
        'duration': duration,
        'state': state,
        'lerp_data': lerp_data,
    }


def parse_req_throw_scene_tool(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqThrowSceneTool',
        stream=stream,
        fallback=lambda s: {
            'tool': _read_throw_scene_tool_data(s),
        },
    )


def parse_req_sync_throw_scene_tool_position(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncThrowSceneToolPosition',
        stream=stream,
        fallback=lambda s: {
            'tool': _read_throw_scene_tool_data(s),
        },
    )


def parse_req_report_throw_scene_tool_final_position(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqReportThrowSceneToolFinalPosition',
        stream=stream,
        fallback=lambda s: {
            'tool': _read_throw_scene_tool_data(s),
        },
    )


def parse_req_report_throw_scene_tool_final_position_with_relation(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqReportThrowSceneToolFinalPositionWithRelation',
        stream=stream,
        fallback=lambda s: {
            'tool': _read_throw_scene_tool_data(s),
            'relevant_id': _read_u64_vector(s),
        },
    )


def parse_req_create_place_scene_tool(stream: InputStream) -> dict:
    flags = stream.read_u8()
    scene_tool_unique_id = stream.read_u64()
    relevant_ids = _read_u64_vector(stream) if (flags & 0x01) else []
    affected_id = stream.read_u64() if (flags & 0x02) else None
    transform = _read_transform_euler(stream)
    return {
        'flags': flags,
        'scene_tool_unique_id': scene_tool_unique_id,
        'relevant_ids': relevant_ids,
        'affected_id': affected_id,
        'transform': transform,
    }


def parse_req_use_scene_tool(stream: InputStream) -> dict:
    return {
        'hand_item_id': stream.read_u32(),
        'scene_tool_unique_id': stream.read_u64(),
    }


def parse_req_move_to_into_scene_tool(stream: InputStream) -> dict:
    return {
        'scene_tool_unique_id': stream.read_u64(),
        'hand_item_id': stream.read_u32(),
    }


def parse_req_into_scene_tool(stream: InputStream) -> dict:
    return {
        'scene_tool_unique_id': stream.read_u64(),
        'hand_item_id': stream.read_u32(),
    }


def parse_req_get_back_place_scene_tool(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGetBackPlaceSceneTool',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
        },
    )


def parse_req_get_back_place_scene_tool_operator(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqGetBackPlaceSceneToolOperator',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
            'state': s.read_u8(),
            'lerp_data': _read_lerp_data(s),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
            'state': int(data.get('state', 0) or 0) & 0xFF,
            'lerp_data': data.get('lerp_data', {}),
        },
    )


def parse_req_sync_player_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncPlayerState',
        stream=stream,
        fallback=lambda s: {
            'effect_type': s.read_u8(),
        },
        normalizer=lambda data: {
            'effect_type': int(data.get('effect_type', 0) or 0) & 0xFF,
        },
    )


def parse_req_use_place_scene_tool_operator(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqUsePlaceSceneToolOperator',
        stream=stream,
        fallback=lambda s: {
            'hand_item_id': s.read_u32(),
            'scene_tool_unique_id': s.read_u64(),
            'state': s.read_u8(),
            'lerp_data': _read_lerp_data(s),
        },
    )


def _parse_req_operate_scene_manual(stream: InputStream) -> dict:
    # Runtime contract gates optional pose/trans by flags bits 0/1.
    flags = stream.read_u8()
    req = {
        'flags': flags,
        'hand_tool_id': stream.read_u32(),
        'hand_tool_config_id': stream.read_u32(),
        'target_index': stream.read_u32(),
        'state': stream.read_u8(),
    }
    if flags & 0x01:
        req['pose'] = _read_battle_pose(stream)
    if flags & 0x02:
        req['trans'] = _read_transform_euler(stream)
    return req


def parse_req_operate_scene(stream: InputStream) -> dict:
    req = _parse_req_operate_scene_manual(stream)
    return {
        'flags': int(req.get('flags', 0) or 0) & 0x03,
        'hand_tool_id': int(req.get('hand_tool_id', 0) or 0) & 0xFFFFFFFF,
        'hand_tool_config_id': int(req.get('hand_tool_config_id', 0) or 0) & 0xFFFFFFFF,
        'target_index': int(req.get('target_index', 0) or 0) & 0xFFFFFFFF,
        'state': int(req.get('state', 0) or 0) & 0xFF,
        'pose': req.get('pose'),
        'trans': req.get('trans'),
    }


def parse_req_kill_me(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqKillMe',
        stream=stream,
        fallback=lambda s: {},
    )


def parse_req_shock_grenade_bomb(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqShockGrenadeBomb',
        stream=stream,
        fallback=lambda s: {
            'scene_tool_unique_id': s.read_u64(),
            'trans': _read_transform(s),
        },
        normalizer=lambda data: {
            'scene_tool_unique_id': int(data.get('scene_tool_unique_id', 0) or 0),
            'trans': data.get('trans', data.get('transform', {})),
        },
    )


def parse_req_leave_scene_tool(stream: InputStream) -> dict:
    return {}


def parse_req_sync_character_weapon_state(stream: InputStream) -> dict:
    return _decode_payload_from_autogen(
        packet_class='ReqSyncCharacterWeaponState',
        stream=stream,
        fallback=lambda s: {
            'weapon_state': s.read_u8(),
        },
    )


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Battle Session (supports multiple clients per session)
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

class BattlePlayer:
    """Represents a single player connection in a battle session."""

    def __init__(self, sock: socket.socket, addr: tuple, bid: int):
        self.sock = sock
        self.addr = addr
        self.bid = bid  # battle slot id (1-based)
        self.uid: int = 0
        self.name: str = ''
        self.team: int = 1
        self.camp: int = 1
        self.character_id: int = 1
        self.loaded: bool = False
        self.progress: float = 0.0
        self.last_grenade_unique_id: int = 0
        self.last_grenade_pos: tuple[float, float, float] = (0.0, 0.0, 0.0)
        self.last_grenade_timeout_uid: int = 0
        self.active_scene_tools: set[int] = set()
        self.last_scene_tool_unique_id: int = 0
        self.last_place_scene_tool_unique_id: int = 0
        self.last_scene_tool_hand_item_id: int = 0
        self.last_place_target_wall_id: int = 0
        self.hp: int = 100
        self.is_dead: bool = False
        self.last_character_pos: tuple[float, float, float] = (0.0, 0.0, 0.0)
        self.primary_weapon: dict | None = None
        self.secondary_weapon: dict | None = None
        self.main_skill_id: int | None = None
        self.sub_skill_id: int | None = None
        self.skins: list[int] | None = None
        self.born_region_id: int | None = None
        self.last_unmanned_vehicle_id: int = 0
        self.last_unmanned_vehicle_pose: dict[str, float] = {}
        self.last_monitor_id: int = 0
        self.last_blocking_board_id: int = 0
        # Guide-mode scripting helpers (mode_id=2).
        self.guide_c4_scene_tool_unique_id: int = 0
        self.guide_scanned_enemy_bids: list[int] = []
        self.guide_pending_points: list[dict] = []
        self.guide_scripted_remote_kill_done: bool = False
        self._load_success_sent: bool = False
        self._spawn_probe_logged: bool = False
        self._hb_recv_count: int = 0
        self._hb_echo_count: int = 0
        self._recv_buf = bytearray()
        self._tx_observer: Callable[[bytes, str], None] | None = None
        self._preserve_on_disconnect: bool = False

    def send_raw(self, data: bytes) -> bool:
        if not self.sock:
            return False
        try:
            observer = self._tx_observer
            if observer is not None:
                try:
                    observer(data, 'player')
                except Exception:
                    pass
            self.sock.sendall(data)
            return True
        except Exception:
            return False

    def close(self):
        try:
            self.sock.close()
        except Exception:
            pass


def _get_live_room_state() -> dict:
    """Retrieve live _room_state dictionary from __main__ or run_https_443 module."""
    import sys
    for mod_name in ('__main__', 'run_https_443'):
        mod = sys.modules.get(mod_name)
        if mod is not None and hasattr(mod, '_room_state'):
            r = getattr(mod, '_room_state')
            if isinstance(r, dict) and 'players' in r:
                return r
    return {}


class BattleSession:
    """A single battle session that can host multiple players."""

    def __init__(self, battle_id: int, game_state: dict, player_data: dict,
                 log_fn: Callable | None = None):
        self.battle_id = battle_id
        self.game_state = game_state
        self.player_data = player_data
        self.players: dict[int, BattlePlayer] = {}  # bid -> BattlePlayer
        self._lock = threading.Lock()
        # Use 1-based bids to match lobby/pre-battle player slot conventions.
        self._next_bid = int(game_state.get('player_bid', 1) or 1)
        self._log = log_fn or (lambda msg: print(f"[Battle] {msg}"))

        # Pre-seed players from active custom room if present
        try:
            r_state = _get_live_room_state()
            room_players = r_state.get("players") if isinstance(r_state, dict) else {}
            if isinstance(room_players, dict) and len(room_players) > 0:
                sorted_room_players = sorted(
                    [entry for entry in room_players.values() if isinstance(entry, dict)],
                    key=lambda e: (
                        int(e.get("camp", 1) or 1),
                        int(e.get("index", 9999) or 9999),
                        int(e.get("uid", 0) or 0),
                    ),
                )
                for idx, p_entry in enumerate(sorted_room_players, 1):
                    p_uid = int(p_entry.get("uid", 0) or 0)
                    if p_uid <= 0:
                        continue
                    p_camp = int(p_entry.get("camp", 1) or 1)
                    p_team = 2 if p_camp == 2 else 1
                    p_name = str(p_entry.get("name") or f"Player{p_uid}")
                    p_char_id = int(p_entry.get("character_id", 0) or (1 if p_camp == 1 else 101))
                    bp = BattlePlayer(None, ('0.0.0.0', 0), idx)
                    bp.uid = p_uid
                    bp.name = p_name
                    bp.camp = p_camp
                    bp.team = p_team
                    bp.character_id = p_char_id
                    bp.primary_weapon = p_entry.get("primary_weapon")
                    bp.secondary_weapon = p_entry.get("secondary_weapon")
                    bp.main_skill_id = p_entry.get("main_skill_id")
                    bp.sub_skill_id = p_entry.get("sub_skill_id")
                    bp.skins = p_entry.get("skins")
                    bp.born_region_id = p_entry.get("region_id") or p_entry.get("spawn_region_id")
                    self.players[idx] = bp
                    self._log(f"pre-seeded room player bid={idx} uid={p_uid} name={p_name} camp={p_camp} team={p_team} char={p_char_id}")
                if self.players:
                    self._next_bid = max(self.players.keys()) + 1
        except Exception as exc:
            self._log(f"seed players from room error: {exc}")
        self._started = False
        self.stage = GAME_STAGE_BATTLE
        self._round_finished = False
        self._battle_stage_started_at: float | None = None
        self.blocking_board_states: dict[int, int] = {}
        self.armor_packages: dict[int, dict] = {}
        self.blocking_board_hp: dict[int, float] = {}
        self.blocking_board_anchor: dict[int, tuple[float, float, float]] = {}
        self.blocking_board_profiles: dict[int, BlockingBoardProfile] = {}
        self.blocking_board_default_profile = _coerce_blocking_board_profile(
            self.game_state.get('blocking_board_default_profile'),
            BLOCKING_BOARD_DEFAULT_PROFILE,
        )
        # Placement yaw (degrees) from ReqCharacterOperateBlockingBoard.pose.rot.y.
        # Used to build a stable board normal independent from shooter position.
        self.blocking_board_yaw: dict[int, float] = {}
        # Stored board facing normal (horizontal unit vector nx, nz) derived on first
        # gun-fire hit.  Constant per board; avoids re-deriving from shooter position
        # on every shot (which is noisy and causes inconsistent left/right mapping).
        self.blocking_board_normal: dict[int, tuple[float, float]] = {}
        self.last_blocking_board_id: int | None = None
        self.player_placed_blocking_board_ids: set[int] = set()
        self.ended_scene_tool_unique_ids: set[int] = set()
        self.scene_tool_board_hint: dict[int, int] = {}
        self.scene_tool_wall_hint: dict[int, int] = {}
        self.reinforced_states: dict[int, int] = {}
        # Legacy blocking-board runtime storage (barricade channel).
        self.dynamic_walls: dict[int, dict[str, object]] = {}
        self.broken_walls: dict[int, set[int]] = {}
        # Scene wall runtime storage (DestroySceneObject / wall channel).
        self.wall_dynamic_walls: dict[int, dict[str, object]] = {}
        self.wall_broken_blocks: dict[int, set[int]] = {}
        self.reinforced_walls: dict[int, dict[str, object]] = {}
        self.reinforced_wall_items: set[int] = set()
        self.training_target_state: dict[int, dict] = _build_default_training_target_state()
        self.training_target_entities_created: bool = False
        # Runtime critical-region state tracked for guide scripting.
        self.guide_critical_region_state: int = CRITICAL_REGION_STATE_ONLY_DEFENDERS
        self.guide_pending_only_attackers_state: bool = False
        self.guide_pending_only_attackers_at: float = 0.0
        self.room_loading_critical_region_id: int | None = None

        try:
            map_id = int(self.game_state.get('map_id', 0) or 0)
        except Exception:
            map_id = 0
        if _is_training_mode_game_state(self.game_state):
            seeded_training_targets = _session_seed_training_targets_from_manifest(self, map_id)
            if seeded_training_targets > 0:
                self._log(
                    f"training-target seed source=manifest map_id={map_id} "
                    f"targets={seeded_training_targets}"
                )

        if _should_seed_blocking_boards(self.game_state):
            seeded_from_manifest = _session_seed_training_blocking_boards_from_manifest(
                self,
                map_id,
            )
            if seeded_from_manifest > 0:
                self._log(
                    f"blocking-board seed source=manifest map_id={map_id} "
                    f"boards={seeded_from_manifest} "
                    f"state={BLOCKING_BOARD_SEEDED_DEFAULT_STATE} "
                    f"active={1 if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE else 0}"
                )
            elif map_id == 1:
                for board_id in TRAINING_DEFAULT_BLOCKING_BOARD_IDS:
                    normalized_board_id = int(board_id) & 0xFFFFFFFF
                    self.blocking_board_states[normalized_board_id] = BLOCKING_BOARD_SEEDED_DEFAULT_STATE
                    self.blocking_board_hp[normalized_board_id] = BLOCKING_BOARD_SEEDED_DEFAULT_HP
                    self.dynamic_walls.setdefault(
                        normalized_board_id,
                        {
                            'state': BLOCKING_BOARD_SEEDED_DEFAULT_STATE,
                            'blocks': set(),
                        },
                    )
                    anchor = TRAINING_DEFAULT_BLOCKING_BOARD_ANCHORS.get(normalized_board_id)
                    if anchor is not None:
                        self.blocking_board_anchor[normalized_board_id] = (
                            float(anchor[0]),
                            float(anchor[1]),
                            float(anchor[2]),
                        )
                self._log(
                    "blocking-board seed source=hardcoded map_id=1 "
                    f"boards={len(TRAINING_DEFAULT_BLOCKING_BOARD_IDS)} "
                    f"state={BLOCKING_BOARD_SEEDED_DEFAULT_STATE} "
                    f"active={1 if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE else 0}"
                )

    def _send_load_success_once(self, player: BattlePlayer):
        if player._load_success_sent:
            return
        player._load_success_sent = True
        success_pkt = build_rsp_battle_load_success(player.bid)
        self.broadcast(success_pkt)
        self._log(f"sent RspBattleLoadSuccess bid={player.bid} to all players")

    def _send_game_start_once(self):
        if self._started:
            return
        self._started = True
        self._round_finished = False
        self._battle_stage_started_at = time.time()
        ts = int(time.time())
        start_pkt = build_rsp_game_start(ts)
        self.broadcast(start_pkt)
        self._log(f"sent RspGameStart ts={ts} to all players")
        sec_cam_pkt = build_rsp_security_camera_info()
        self.broadcast(sec_cam_pkt)
        self._log("sent RspSecurityCameraInfo (0x457) to all players")

        map_id = int(self.game_state.get('map_id', 1) or 1)
        mode_id = int(self.game_state.get('mode_id', 0) or 0)
        if mode_id in (4, 5):
            target_zones = _load_map_target_zones_cache().get(map_id, (1, 2))
            bomb_pkt = build_rsp_spawn_bomb_region(list(target_zones))
            self.broadcast(bomb_pkt)
            self._log(f"broadcast RspSpawnBombRegion zones={list(target_zones)} map_id={map_id}")

        if mode_id != 3:
            self.stage = GAME_STAGE_PREPARE
            stage_pkt = build_rsp_game_stage(
                timestamp=ts,
                game_stage=GAME_STAGE_PREPARE,
                total_time=45,
                remain_time=45,
            )
            self.broadcast(stage_pkt)
            crit_pkt = build_rsp_critical_region_state(CRITICAL_REGION_STATE_ONLY_DEFENDERS)
            self.broadcast(crit_pkt)
            _guide_set_critical_region_state(self, CRITICAL_REGION_STATE_ONLY_DEFENDERS)
            self._log("broadcast RspGameStage PREPARE (45s) & RspCriticalRegionState ONLY_DEFENDERS")

            # Send RspVehicleBornPlace (0x3F5) to attackers to spawn drone and enter drone UI
            for p in self.players.values():
                if p.camp == BATTLE_CAMP_ATTACKER:
                    born_place_id = getattr(p, 'born_region_id', None)
                    if born_place_id is None:
                        born_place_id = int(self.game_state.get('region_id', 1) or 1)
                    if (map_id, BATTLE_CAMP_ATTACKER, int(born_place_id)) in self._TRAINING_SCENE_SLOT_REGION_FALLBACK:
                        born_place_id = self._TRAINING_SCENE_SLOT_REGION_FALLBACK[(map_id, BATTLE_CAMP_ATTACKER, int(born_place_id))]
                    veh_born_pkt = build_rsp_vehicle_born_place(int(born_place_id))
                    p.send_raw(veh_born_pkt)
                    self._log(f"sent RspVehicleBornPlace (0x3F5) born_place_id={born_place_id} to bid={p.bid} uid={p.uid}")
        else:
            self.stage = GAME_STAGE_BATTLE
            stage_pkt = build_rsp_game_stage(
                timestamp=ts,
                game_stage=GAME_STAGE_BATTLE,
                total_time=1800,
                remain_time=1800,
            )
            self.broadcast(stage_pkt)

    def tick(self):
        with self._lock:
            if not self._started or self._round_finished or self._battle_stage_started_at is None:
                return

            now = time.time()
            elapsed = now - self._battle_stage_started_at

            # 1. Preparation phase transition (45s) -> Action Phase (180s)
            if getattr(self, 'stage', GAME_STAGE_BATTLE) == GAME_STAGE_PREPARE:
                prep_duration = 45.0
                if elapsed >= prep_duration:
                    self.stage = GAME_STAGE_BATTLE
                    self._battle_stage_started_at = now
                    ts = int(now)
                    stage_pkt = build_rsp_game_stage(
                        timestamp=ts,
                        game_stage=GAME_STAGE_BATTLE,
                        total_time=180,
                        remain_time=180,
                    )
                    self.broadcast(stage_pkt)
                    crit_pkt = build_rsp_critical_region_state(CRITICAL_REGION_STATE_BOTH_PLAYERS)
                    self.broadcast(crit_pkt)
                    _guide_set_critical_region_state(self, CRITICAL_REGION_STATE_BOTH_PLAYERS)
                    self._log("[Session] Preparation phase ended -> Transitioned to GAME_STAGE_BATTLE (180s)!")
                return

            # 2. Action phase timeout (180s) -> Round won by Defenders
            if getattr(self, 'stage', GAME_STAGE_BATTLE) == GAME_STAGE_BATTLE:
                mode_id = int(self.game_state.get('mode_id', 0) or 0)
                if mode_id == 3:
                    return  # Training mode has 1800s / unlimited time
                battle_duration = 180.0
                if elapsed >= battle_duration:
                    self._round_finished = True
                    self._log("[Session] Round timer reached 0:00! Defenders win on TimeOut.")
                    res_pkt = build_rsp_battle_result(reason=3, win_camp=BATTLE_CAMP_DEFENDER)
                    self.broadcast(res_pkt)
                    over_pkt = build_rsp_battle_over(reason=BATTLE_OVER_REASON_TIME_END)
                    self.broadcast(over_pkt)

    def add_player(self, sock: socket.socket, addr: tuple) -> BattlePlayer:
        with self._lock:
            bid = self._next_bid
            self._next_bid += 1
            player = BattlePlayer(sock, addr, bid)
            self.players[bid] = player
            return player

    def remove_player(self, bid: int, force: bool = False):
        with self._lock:
            p = self.players.get(bid)
            if p:
                p.close()
                p.sock = None
                if force or _is_training_mode_game_state(self.game_state):
                    self.players.pop(bid, None)

    def try_rebind_player_by_uid(
        self,
        uid: int,
        sock: socket.socket,
        addr: tuple,
    ) -> BattlePlayer | None:
        normalized_uid = int(uid or 0)
        if normalized_uid <= 0:
            return None
        with self._lock:
            for candidate in self.players.values():
                if int(candidate.uid) != normalized_uid:
                    continue
                old_sock = candidate.sock
                candidate.sock = sock
                candidate.addr = addr
                candidate._recv_buf = bytearray()
                candidate._hb_recv_count = 0
                candidate._hb_echo_count = 0
                candidate.loaded = False
                candidate.progress = 0.0
                candidate._load_success_sent = False
                candidate._spawn_probe_logged = False
                candidate._preserve_on_disconnect = False
                if old_sock is not sock:
                    try:
                        old_sock.close()
                    except Exception:
                        pass
                return candidate
        return None

    def broadcast(self, data: bytes, exclude_bid: int | None = None):
        with self._lock:
            for bid, p in list(self.players.items()):
                if bid != exclude_bid:
                    p.send_raw(data)

    def all_loaded(self) -> bool:
        with self._lock:
            return all(p.loaded for p in self.players.values()) and len(self.players) > 0

    # mode_id -> CombatType mapping
    _COMBAT_TYPE_MAP = {
        1: 4,   # EliminateThreat in custom room -> room_mode
        2: 5,   # guide -> userguide_mode
        3: 6,   # training -> train_mode
        4: 4,   # Bomb in custom room -> room_mode
    }

    # Training spawn placement for local server.
    # Cargo Dock (map_id=1) uses region transforms extracted from
    # level02_can SpawnPoints/spawn_probes scene hierarchy.
    # For other maps (or unresolved regions), keep deterministic fallback anchors.
    _TRAINING_SCENE_REGION_SPAWNS: dict[
        tuple[int, int, int],
        tuple[tuple[float, float, float], tuple[float, float, float, float]],
    ] = {
        # map 1 attacker regions (blue: gangkou/shuangzi/quanjia)
        (1, BATTLE_CAMP_ATTACKER, 6): ((-7.436, -2.291, 65.426003), (0.0, 0.998778, 0.0, 0.049416)),
        (1, BATTLE_CAMP_ATTACKER, 7): ((-7.775, -2.407, 67.139999), (0.0, 0.975397, 0.0, 0.220457)),
        (1, BATTLE_CAMP_ATTACKER, 8): ((-9.804, -2.34, 67.193001), (0.0, 0.951562, 0.0, 0.307458)),
        (1, BATTLE_CAMP_ATTACKER, 9): ((-9.86, -2.315, 65.227997), (-0.0, 0.958326, 0.0, -0.285679)),
        (1, BATTLE_CAMP_ATTACKER, 10): ((-8.826, -2.279, 62.936001), (-0.0, 0.918195, 0.0, -0.396129)),
        (1, BATTLE_CAMP_ATTACKER, 16): ((67.100998, -4.645, -6.966), (-0.0, 0.780912, 0.0, -0.624641)),
        (1, BATTLE_CAMP_ATTACKER, 17): ((71.468002, -5.211, 5.79), (-0.0, 0.808466, 0.0, -0.588543)),
        (1, BATTLE_CAMP_ATTACKER, 18): ((66.936996, -4.647, -5.514), (-0.0, 0.896793, 0.0, -0.44245)),
        (1, BATTLE_CAMP_ATTACKER, 19): ((72.309998, -5.135, 6.984), (-0.0, 0.809271, 0.0, -0.587435)),
        (1, BATTLE_CAMP_ATTACKER, 20): ((70.163002, -5.063, 6.523), (0.0, -0.758325, 0.0, 0.651877)),
        (1, BATTLE_CAMP_ATTACKER, 26): ((-5.81, -2.243, -73.288002), (0.0, 0.090837, 0.0, 0.995866)),
        (1, BATTLE_CAMP_ATTACKER, 27): ((-6.869, -2.322, -74.653999), (0.0, 0.087023, 0.0, 0.996206)),
        (1, BATTLE_CAMP_ATTACKER, 28): ((-4.68, -2.322, -74.853004), (0.0, -0.164494, 0.0, 0.986378)),
        (1, BATTLE_CAMP_ATTACKER, 29): ((-6.409, -2.22, -71.709), (0.0, -0.044672, 0.0, 0.999002)),
        (1, BATTLE_CAMP_ATTACKER, 30): ((-4.54, -2.19, -71.979004), (0.0, 0.020173, 0.0, 0.999797)),

        # map 1 defender regions (red: zhandouquyu1/3/4/2)
        (1, BATTLE_CAMP_DEFENDER, 1): ((6.39, 1.459, -4.682), (-0.0, 0.936984, 0.0, -0.349372)),
        (1, BATTLE_CAMP_DEFENDER, 2): ((4.88, 1.459, -10.16), (0.0, -0.569253, 0.0, 0.822163)),
        (1, BATTLE_CAMP_DEFENDER, 3): ((7.081, 1.459, -6.96), (0.0, -0.718572, 0.0, 0.695453)),
        (1, BATTLE_CAMP_DEFENDER, 4): ((2.578, 1.459, -10.965), (-0.0, 0.030058, 0.0, -0.999548)),
        (1, BATTLE_CAMP_DEFENDER, 5): ((-0.447, 1.459, -4.964), (0.0, 0.991781, 0.0, 0.127944)),
        (1, BATTLE_CAMP_DEFENDER, 11): ((-2.22, 5.117, -3.944), (0.0, -0.86753, 0.0, -0.497386)),
        (1, BATTLE_CAMP_DEFENDER, 12): ((3.426, 5.117, -5.857), (-0.0, 0.779617, 0.0, -0.626257)),
        (1, BATTLE_CAMP_DEFENDER, 13): ((0.56, 5.117, -9.9), (0.0, -0.068514, 0.0, 0.99765)),
        (1, BATTLE_CAMP_DEFENDER, 14): ((1.734, 5.117, -4.394), (-0.0, 0.957021, 0.0, -0.290018)),
        (1, BATTLE_CAMP_DEFENDER, 15): ((2.93, 5.117, -8.64), (0.0, -0.331051, 0.0, 0.943613)),
        (1, BATTLE_CAMP_DEFENDER, 21): ((-0.267, -2.196, -2.687), (0.0, -0.822838, 0.0, -0.568277)),
        (1, BATTLE_CAMP_DEFENDER, 22): ((4.254, -2.196, -1.418), (0.0, -0.97097, 0.0, 0.239201)),
        (1, BATTLE_CAMP_DEFENDER, 23): ((1.331, -2.196, -1.183), (0.0, 0.935955, 0.0, 0.352121)),
        (1, BATTLE_CAMP_DEFENDER, 24): ((6.454, -2.196, -8.438), (-0.0, 0.322507, 0.0, -0.946567)),
        (1, BATTLE_CAMP_DEFENDER, 25): ((4.468, -2.196, -9.038), (-0.0, 0.25345, 0.0, -0.967348)),
        (1, BATTLE_CAMP_DEFENDER, 31): ((-9.319, -6.966, 7.512), (0.0, -0.818903, 0.0, -0.573932)),
        (1, BATTLE_CAMP_DEFENDER, 32): ((-5.291, -6.966, 10.517), (0.0, 0.96773, 0.0, 0.251988)),
        (1, BATTLE_CAMP_DEFENDER, 33): ((-0.039, -6.966, 9.379), (0.0, -0.94779, 0.0, 0.318895)),
        (1, BATTLE_CAMP_DEFENDER, 34): ((-4.98, -6.966, 3.44), (0.0, -0.0959, 0.0, -0.995391)),
        (1, BATTLE_CAMP_DEFENDER, 35): ((-3.182, -6.966, 10.117), (0.0, -0.995634, 0.0, -0.093342)),
    }

    # Fallback for UI slot-style region values (0..N) on map 1.
    _TRAINING_SCENE_SLOT_REGION_FALLBACK: dict[tuple[int, int, int], int] = {
        (1, BATTLE_CAMP_ATTACKER, 0): 26,
        (1, BATTLE_CAMP_ATTACKER, 1): 6,
        (1, BATTLE_CAMP_ATTACKER, 2): 16,
        (1, BATTLE_CAMP_DEFENDER, 0): 11,
        (1, BATTLE_CAMP_DEFENDER, 1): 1,
        (1, BATTLE_CAMP_DEFENDER, 2): 21,
        (1, BATTLE_CAMP_DEFENDER, 3): 31,
    }

    # Guide mode (mode_id=2) spawn placement for level00_tra (map_id=3).
    # Coordinates extracted from scene hierarchy:
    # Environment/Dynamic/SpawnPoints/spawn_probes/{blue,red}/ID{6,1}
    _GUIDE_SCENE_REGION_SPAWNS: dict[
        tuple[int, int, int],
        tuple[tuple[float, float, float], tuple[float, float, float, float]],
    ] = {
        (3, BATTLE_CAMP_ATTACKER, 6): ((-6.13, -2.384, -61.97), (0.0, 0.0, 0.0, 1.0)),
        (3, BATTLE_CAMP_DEFENDER, 1): ((4.807, -2.031, -7.926), (0.0, 1.0, 0.0, 0.0)),
    }

    # Guide branch frequently enters battle with region_id=0.
    # Map to concrete scene spawn ids by camp.
    _GUIDE_SCENE_REGION_FALLBACK: dict[tuple[int, int, int], int] = {
        (3, BATTLE_CAMP_ATTACKER, 0): 6,
        (3, BATTLE_CAMP_ATTACKER, 255): 6,
        (3, BATTLE_CAMP_DEFENDER, 0): 1,
        (3, BATTLE_CAMP_DEFENDER, 255): 1,
    }

    _GUIDE_SCENE_DEFAULT_REGION_BY_CAMP: dict[tuple[int, int], int] = {
        (3, BATTLE_CAMP_ATTACKER): 6,
        (3, BATTLE_CAMP_DEFENDER): 1,
    }

    _TRAINING_SPAWN_ANCHORS: dict[tuple[int, int], tuple[float, float, float]] = {
        # (map_id, camp) -> base (x, y, z)
        # Map 1 calibration:
        # attacker spawn should start on exterior approach side, defender indoors.
        (1, BATTLE_CAMP_ATTACKER): (0.0, 1.0, 14.0),
        (1, BATTLE_CAMP_DEFENDER): (0.0, 1.0, 0.0),
        (2, BATTLE_CAMP_ATTACKER): (0.0, 1.0, 14.0),
        (2, BATTLE_CAMP_DEFENDER): (0.0, 1.0, 0.0),
        (6, BATTLE_CAMP_ATTACKER): (0.0, 1.0, 14.0),
        (6, BATTLE_CAMP_DEFENDER): (0.0, 1.0, 0.0),
        (7, BATTLE_CAMP_ATTACKER): (0.0, 1.0, 14.0),
        (7, BATTLE_CAMP_DEFENDER): (0.0, 1.0, 0.0),
    }

    @staticmethod
    def _region_slot_index(map_id: int, camp: int, region_id: int) -> int:
        """Convert region_id to a compact slot index used for spawn offsets."""
        if region_id < 0 or region_id == 255:
            return 0

        # Training map (id=1): region ids may come either as UI slot index
        # or as full spawn id from maps.lua attacker_born/defender_born arrays.
        if map_id == 1:
            if camp == BATTLE_CAMP_ATTACKER:
                if region_id in (0, 1, 2):
                    return region_id
                if 26 <= region_id <= 30:
                    return 0
                if 6 <= region_id <= 10:
                    return 1
                if 16 <= region_id <= 20:
                    return 2
                return 1
            if camp == BATTLE_CAMP_DEFENDER:
                if region_id in (0, 1, 2, 3):
                    return region_id
                if 11 <= region_id <= 15:
                    return 0
                if 1 <= region_id <= 5:
                    return 1
                if 21 <= region_id <= 25:
                    return 2
                if 31 <= region_id <= 35:
                    return 3
                return 1

        # Generic fallback for other maps/modes.
        if camp == BATTLE_CAMP_DEFENDER:
            return max(0, min(3, region_id))
        return max(0, min(2, region_id))

    @classmethod
    def _resolve_training_scene_spawn_transform(
        cls,
        *,
        map_id: int,
        camp: int,
        region_id: int,
    ) -> tuple[tuple[float, float, float], tuple[float, float, float, float], str] | None:
        map_id = int(map_id)
        camp = int(camp)
        region_id = int(region_id)

        # Client prebattle sends slot ids (attacker: 255/0..2, defender: 0..3).
        # On map 1 defender, slot ids 1..3 numerically overlap scene ids 1..3,
        # so prefer explicit slot fallback first to avoid wrong-floor spawns.
        explicit_slot_region = cls._TRAINING_SCENE_SLOT_REGION_FALLBACK.get((map_id, camp, region_id))
        if explicit_slot_region is not None:
            explicit_slot_spawn = cls._TRAINING_SCENE_REGION_SPAWNS.get(
                (map_id, camp, int(explicit_slot_region))
            )
            if explicit_slot_spawn is not None:
                return explicit_slot_spawn[0], explicit_slot_spawn[1], "training-scene-slot-explicit"

        direct = cls._TRAINING_SCENE_REGION_SPAWNS.get((map_id, camp, region_id))
        if direct is not None:
            return direct[0], direct[1], "training-scene-region-id"

        slot = cls._region_slot_index(map_id, camp, region_id)
        fallback_region = cls._TRAINING_SCENE_SLOT_REGION_FALLBACK.get((map_id, camp, slot))
        if fallback_region is None:
            return None

        fallback = cls._TRAINING_SCENE_REGION_SPAWNS.get((map_id, camp, int(fallback_region)))
        if fallback is None:
            return None
        return fallback[0], fallback[1], "training-scene-slot-fallback"

    @classmethod
    def _resolve_guide_scene_spawn_transform(
        cls,
        *,
        map_id: int,
        camp: int,
        region_id: int,
    ) -> tuple[tuple[float, float, float], tuple[float, float, float, float], str] | None:
        map_id = int(map_id)
        camp = int(camp)
        region_id = int(region_id)

        direct = cls._GUIDE_SCENE_REGION_SPAWNS.get((map_id, camp, region_id))
        if direct is not None:
            return direct[0], direct[1], "guide-scene-region-id"

        fallback_region = cls._GUIDE_SCENE_REGION_FALLBACK.get((map_id, camp, region_id))
        if fallback_region is None:
            fallback_region = cls._GUIDE_SCENE_DEFAULT_REGION_BY_CAMP.get((map_id, camp))
        if fallback_region is None:
            return None

        fallback = cls._GUIDE_SCENE_REGION_SPAWNS.get((map_id, camp, int(fallback_region)))
        if fallback is None:
            return None
        return fallback[0], fallback[1], "guide-scene-camp-fallback"

    @classmethod
    def _resolve_spawn_transform(
        cls,
        *,
        map_id: int,
        mode_id: int,
        camp: int,
        region_id: int | None,
    ) -> tuple[tuple[float, float, float], tuple[float, float, float, float], str]:
        """
        Resolve spawn transform for CharacterInfo.trans.

        Returns:
          (position, rotation, source_tag)
        """
        rid = 0
        try:
            if region_id is not None:
                rid = int(region_id)
        except Exception:
            rid = 0

        mode = int(mode_id)
        map_id = int(map_id)
        camp = int(camp)

        if mode == 2:
            guide_spawn = cls._resolve_guide_scene_spawn_transform(
                map_id=map_id,
                camp=camp,
                region_id=rid,
            )
            if guide_spawn is not None:
                return guide_spawn

        scene_spawn = cls._resolve_training_scene_spawn_transform(
            map_id=map_id,
            camp=camp,
            region_id=rid,
        )
        if scene_spawn is not None:
            return scene_spawn

        key = (map_id, camp)
        base = cls._TRAINING_SPAWN_ANCHORS.get(key)
        if base is None:
            # Unknown map/camp pair in training mode: fallback to a safe deterministic point.
            return (0.0, 1.0, 14.0), (0.0, 0.0, 0.0, 1.0), "training-generic-fallback"

        slot = cls._region_slot_index(map_id, camp, rid)
        step = 4.0
        if camp == BATTLE_CAMP_DEFENDER:
            # 4 slots: [-6, -2, +2, +6]
            x_offset = (float(slot) - 1.5) * step
        else:
            # 3 slots: [-4, 0, +4]
            x_offset = (float(slot) - 1.0) * step

        pos = (base[0] + x_offset, base[1], base[2])
        rot = (0.0, 0.0, 0.0, 1.0)
        return pos, rot, "training-region-mapped"

    def _resolve_room_loading_critical_region_id(
        self,
        *,
        map_id: int,
        mode_id: int,
    ) -> tuple[int | None, str]:
        """
        Resolve SceneDesc.critical_region_id for RspRoomLoading.

        Priority:
          1) explicit value in game_state (if provided by upper-level logic);
          2) guide mode fallback from maps.lua target_zone[0].
        """
        gs = self.game_state if isinstance(self.game_state, dict) else {}

        for key in ('critical_region_id', 'real_target_region_id', 'target_region_id'):
            raw_value = gs.get(key)
            try:
                region_id = int(raw_value)
            except Exception:
                continue
            if region_id > 0:
                return region_id, f'game_state.{key}'

        if int(mode_id) == 2:
            zone_id = _get_primary_target_zone_for_map(map_id)
            if zone_id is not None and zone_id > 0:
                return int(zone_id), 'maps.target_zone[0]'

        return None, 'none'

    @staticmethod
    def _resolve_room_loading_character_skins(
        player_data: dict | None,
        character_id: object,
    ) -> list[int]:
        """
        Resolve selected character skin ids for CharacterInfo.skins in room loading.

        Source of truth mirrors lobby storage shape:
          player_data.selected_skins.characters["<character_id>"].char_skins
        """
        try:
            cid = int(character_id)
        except Exception:
            cid = 0
        if cid <= 0 or not isinstance(player_data, dict):
            return []

        selected_skins_root = player_data.get('selected_skins')
        if not isinstance(selected_skins_root, dict):
            return []
        characters = selected_skins_root.get('characters')
        if not isinstance(characters, dict):
            return []

        entry = characters.get(str(cid))
        if not isinstance(entry, dict):
            entry = characters.get(cid)
        if not isinstance(entry, dict):
            return []

        raw_char_skins = entry.get('char_skins')
        if not isinstance(raw_char_skins, list):
            return []
        return _uniq_positive_ints(list(raw_char_skins))[:16]

    def build_room_loading(self, for_player: BattlePlayer) -> bytes:
        """Build RspRoomLoading packet tailored for a specific player."""
        gs = self.game_state
        pd = self.player_data

        # Resolve character/weapon tailored for for_player
        char_id = getattr(for_player, 'character_id', None) or int(gs.get('character_id', 0) or (1 if for_player.camp == 1 else 101))
        pri_weapon = getattr(for_player, 'primary_weapon', None) or gs.get('primary_weapon', {'id': 10036, 'skin': 0, 'attachments': []})
        sec_weapon = getattr(for_player, 'secondary_weapon', None) or gs.get('secondary_weapon', {'id': 10074, 'skin': 0, 'attachments': []})
        main_skill = getattr(for_player, 'main_skill_id', None) or gs.get('main_skill_id', 295)
        sub_skill = getattr(for_player, 'sub_skill_id', None) or gs.get('sub_skill_id', 299)
        # Client CreateCharacterData reads region_id without null-check in load path,
        # so keep it always present in CharacterInfo.
        # Keep spawn-region and character region in sync. Prefer explicit
        # spawn_region_id from prebattle when available.
        spawn_region_raw = getattr(for_player, 'born_region_id', None)
        if spawn_region_raw is None:
            spawn_region_raw = gs.get('spawn_region_id', gs.get('region_id', 999))
        region_id = spawn_region_raw
        try:
            if int(region_id) < 0:
                region_id = gs.get('region_id', 999)
        except Exception:
            region_id = gs.get('region_id', 999)
        have_defuser = gs.get('is_have_defuser')

        # Build CharacterInfo for this player.
        # Important: client-side GetCharacterInfo() matches by runtime PlayerData.Uid,
        # which comes from ReqEnterBattle.uid for this connection.
        acc_id = for_player.uid or pd.get('uid', 1000001)
        # BattleTeam (Blue/Orange) and BattleCamp (Attacker/Defender) are distinct.
        player_team = for_player.team or gs.get('team', 1)
        player_camp = for_player.camp or gs.get('camp', 1)
        try:
            player_camp = int(player_camp)
        except Exception:
            player_camp = int(gs.get('camp', 1) or 1)
        if player_camp not in (BATTLE_CAMP_ATTACKER, BATTLE_CAMP_DEFENDER):
            player_camp = BATTLE_CAMP_ATTACKER
        try:
            player_team = int(player_team)
        except Exception:
            player_team = int(gs.get('team', 1) or 1)
        if player_team not in (1, 2):
            player_team = 1
        map_id = gs.get('map_id', 1)
        mode_id = gs.get('mode_id', 3)
        try:
            map_id_int = int(map_id)
        except Exception:
            map_id_int = 1
        try:
            mode_id_int = int(mode_id)
        except Exception:
            mode_id_int = 3
        # IMPORTANT:
        # do not derive critical_region_id from spawn-region selection.
        # SceneDesc.critical_region_id participates in mode logic and using
        # spawn slot id here can incorrectly gate attacker/defender traversal.
        critical_region_id, critical_region_source = self._resolve_room_loading_critical_region_id(
            map_id=map_id_int,
            mode_id=mode_id_int,
        )
        self.room_loading_critical_region_id = critical_region_id
        # Keep canonical camp->team mapping: attacker->1 (Blue), defender->2 (Orange/Red)
        if player_camp == BATTLE_CAMP_ATTACKER:
            player_team = 1
        elif player_camp == BATTLE_CAMP_DEFENDER:
            player_team = 2
        spawn_pos, spawn_rot, spawn_source = self._resolve_spawn_transform(
            map_id=map_id_int,
            mode_id=mode_id_int,
            camp=player_camp,
            region_id=region_id,
        )
        self._log(
            "spawn_transform "
            f"source={spawn_source} map_id={map_id_int} mode_id={mode_id_int} "
            f"camp={player_camp} region_id={region_id} "
            f"gs_spawn_region={gs.get('spawn_region_id')} gs_region={gs.get('region_id')} "
            f"pos=({spawn_pos[0]:.2f},{spawn_pos[1]:.2f},{spawn_pos[2]:.2f})"
        )
        self._log(
            "room_loading critical_region "
            f"value={critical_region_id} source={critical_region_source} "
            f"map_id={map_id_int} mode_id={mode_id_int}"
        )

        character_skins = self._resolve_room_loading_character_skins(
            player_data=pd,
            character_id=char_id,
        )
        if character_skins:
            self._log(
                "room_loading character_skins "
                f"char_id={char_id} skins={character_skins[:8]}"
            )

        # Build CharacterInfo for all players in session
        attacker_list = []
        defender_list = []

        all_players_to_include = list(self.players.values())
        if not any(p.bid == for_player.bid for p in all_players_to_include):
            all_players_to_include.append(for_player)
        all_players_to_include.sort(key=lambda p: p.bid)

        for p in all_players_to_include:
            p_acc_id = p.uid or (pd.get('uid', 1000001) if p.bid == for_player.bid else 1000000 + p.bid)
            p_team = p.team or player_team
            p_camp = p.camp or player_camp
            try:
                p_camp = int(p_camp)
            except Exception:
                p_camp = player_camp
            if p_camp == BATTLE_CAMP_DEFENDER:
                p_team = 2
            else:
                p_team = 1

            p_region = getattr(p, 'born_region_id', None) or region_id
            p_spawn_pos, p_spawn_rot, _ = self._resolve_spawn_transform(
                map_id=map_id_int,
                mode_id=mode_id_int,
                camp=p_camp,
                region_id=p_region,
            )
            # Offset position slightly so players on the same spawn don't overlap exactly
            if p.bid > 1:
                p_spawn_pos = (p_spawn_pos[0] + (p.bid - 1) * 1.5, p_spawn_pos[1], p_spawn_pos[2])

            p_char_id = getattr(p, 'character_id', None) or (char_id if p.bid == for_player.bid else (1 if p_camp == 1 else 101))

            p_pri = getattr(p, 'primary_weapon', None)
            if not isinstance(p_pri, dict) or not p_pri.get('id'):
                p_pri = pri_weapon if p.bid == for_player.bid else {
                    'id': 10026 if p_camp == BATTLE_CAMP_DEFENDER else 10036,
                    'skin': 0,
                    'attachments': [],
                }

            p_sec = getattr(p, 'secondary_weapon', None)
            if not isinstance(p_sec, dict) or not p_sec.get('id'):
                p_sec = sec_weapon if p.bid == for_player.bid else {
                    'id': 10074,
                    'skin': 0,
                    'attachments': [],
                }

            p_skins = getattr(p, 'skins', None)
            if not isinstance(p_skins, list) or len(p_skins) == 0:
                p_skins = character_skins if p.bid == for_player.bid else [0]

            p_main_sk = getattr(p, 'main_skill_id', None)
            if not p_main_sk:
                p_main_sk = main_skill if p.bid == for_player.bid else (1101 if p_camp == BATTLE_CAMP_DEFENDER else 1001)

            p_sub_sk = getattr(p, 'sub_skill_id', None)
            if p_sub_sk is None:
                p_sub_sk = sub_skill if p.bid == for_player.bid else 0

            p_char_entry = {
                'acc_id': int(p_acc_id),
                'npc_id': -1,
                'bid': p.bid,
                'team': p_team,
                'camp': p_camp,
                'name': p.name or (pd.get('name', 'Player') if p.bid == for_player.bid else f"Player{p_acc_id}"),
                'rotation': p_spawn_rot,
                'position': p_spawn_pos,
                'character_id': p_char_id,
                'skins': p_skins,
                'primary_weapon': p_pri,
                'secondary_weapon': p_sec,
                'main_skill_id': p_main_sk,
                'sub_skill_id': p_sub_sk,
                'region_id': region_id,
                'is_have_defuser': have_defuser,
                'is_loaded': False,
            }
            if p_camp == BATTLE_CAMP_DEFENDER:
                defender_list.append(p_char_entry)
            else:
                attacker_list.append(p_char_entry)

        my_team = for_player.team or (1 if for_player.camp == 1 else 2)

        guide_id = None
        if int(mode_id_int) == 2:
            guide_id = gs.get('guide_id', 0) or None
            critical_region_id = self.room_loading_critical_region_id
        else:
            critical_region_id = None

        combat_type = self._COMBAT_TYPE_MAP.get(mode_id_int, mode_id_int)

        # Production path: send full room-loading payload with selected character data.
        # The previous diagnostic minimal packet (empty lists + critical_region_id=999)
        # can keep client in heartbeat-only loop without progressing to load stage.
        return build_rsp_room_loading(
            my_team=my_team,
            combat_type=combat_type,
            map_id=map_id_int,
            mode_id=mode_id_int,
            attacker_list=attacker_list,
            defender_list=defender_list,
            round_num=1,
            guide_id=guide_id,
            critical_region_id=critical_region_id,
        )


# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ
#  Battle TCP Server
# в•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђв•ђ

# Global session registry вЂ” keyed by battle_id
_sessions: dict[int, BattleSession] = {}
_sessions_lock = threading.Lock()


def get_or_create_session(battle_id: int, game_state: dict, player_data: dict,
                          log_fn: Callable | None = None) -> BattleSession:
    with _sessions_lock:
        existing = _sessions.get(battle_id)
        if existing is not None:
            with existing._lock:
                is_empty = len(existing.players) == 0
            # Recreate empty session to avoid stale per-run scene states.
            if is_empty:
                _sessions[battle_id] = BattleSession(
                    battle_id,
                    game_state,
                    player_data,
                    log_fn,
                )
        if battle_id not in _sessions:
            _sessions[battle_id] = BattleSession(
                battle_id,
                game_state,
                player_data,
                log_fn,
            )
        return _sessions[battle_id]


def remove_session(battle_id: int):
    with _sessions_lock:
        _sessions.pop(battle_id, None)


def _console_safe(s: str) -> str:
    try:
        s.encode('cp866')
        return s
    except (UnicodeEncodeError, LookupError):
        return s.encode('utf-8', errors='replace').decode('ascii', errors='replace')


def _resolve_active_battle_id(
    session: BattleSession | None,
    fallback_battle_id: int,
    game_state: dict,
) -> int:
    if session is not None:
        return max(0, int(session.battle_id))

    state_battle_id = game_state.get('battle_id')
    if state_battle_id is not None:
        try:
            return max(0, int(state_battle_id))
        except (TypeError, ValueError):
            pass

    return max(0, int(fallback_battle_id))


def _resolve_game_stage(
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> int:
    if session and session._started:
        return GAME_STAGE_BATTLE
    if player and player.loaded:
        return GAME_STAGE_BATTLE
    return GAME_STAGE_LOADING


def _map_leave_kind_to_battle_over_reason(leave_kind: int) -> int:
    if leave_kind == LEAVE_BATTLE_KIND_RESTART_MODE:
        return BATTLE_OVER_REASON_RESTART_MODE
    if leave_kind == LEAVE_BATTLE_KIND_RELOAD_MAP:
        return BATTLE_OVER_REASON_RELOAD_MAP
    return BATTLE_OVER_REASON_SELF_LEAVE


def _resolve_reset_skill_ids(
    session: BattleSession | None,
    game_state: dict | None,
) -> list[int]:
    source = session.game_state if session is not None else game_state
    if not isinstance(source, dict):
        return []

    skill_ids: list[int] = []
    seen: set[int] = set()

    def _push_skill(raw_value: object) -> None:
        try:
            skill_id = int(raw_value or 0)
        except Exception:
            return
        if skill_id <= 0 or skill_id in seen:
            return
        seen.add(skill_id)
        skill_ids.append(skill_id)

    for key in ('main_skill_id', 'sub_skill_id'):
        _push_skill(source.get(key, 0))

    # Compatibility keys occasionally observed in prebattle state snapshots.
    for key in ('main_skill', 'sub_skill', 'sub_skills'):
        value = source.get(key)
        if isinstance(value, (list, tuple, set)):
            for item in value:
                _push_skill(item)
        else:
            _push_skill(value)

    if skill_ids:
        return skill_ids

    # Fallback for training setups where only character_id is known in game_state.
    for fallback_skill_id in _get_character_default_skill_ids(source.get('character_id', 0)):
        _push_skill(fallback_skill_id)

    # Final safety fallback used by the old implementation.
    if not skill_ids:
        _push_skill(295)
        _push_skill(299)
    return skill_ids


def _send_rsp_reset_item_num_ack(
    sock: socket.socket,
    peer: str,
    _log: Callable,
    *,
    session: BattleSession | None,
    player: BattlePlayer | None,
    game_state: dict | None,
):
    # Reset gadget button requires both generic reset ack and explicit skill-count sync.
    packets: list[bytes] = [
        build_rsp_reset_all_weapon_item_num(),
    ]
    bid = int(getattr(player, 'bid', 1) or 1) & 0xFF
    synced_skills: list[str] = []
    resolved_skill_ids = _resolve_reset_skill_ids(session, game_state)
    resolved_character_id = 0
    try:
        source_state = session.game_state if session is not None else game_state
        if isinstance(source_state, dict):
            resolved_character_id = int(source_state.get('character_id', 0) or 0)
    except Exception:
        resolved_character_id = 0

    for skill_id in resolved_skill_ids:
        cfg = _get_skill_reset_config(skill_id) or {}
        allow_reset_item = int(cfg.get('allow_reset_item', 1) or 0)
        if allow_reset_item <= 0:
            continue

        init_number = int(cfg.get('init_number', 0) or 0)
        cooldown_ms = int(round(float(cfg.get('cooldown_time', 0.0) or 0.0) * 1000.0))
        active_ms = int(round(float(cfg.get('active_time', 0.0) or 0.0) * 1000.0))

        if init_number >= 0:
            packets.append(build_rsp_sync_skill_num(bid, skill_id, init_number))
        packets.append(build_rsp_sync_skill_cd(skill_id, 0, max(0, cooldown_ms)))
        packets.append(build_rsp_sync_skill_active_time(skill_id, 0, max(0, active_ms)))
        synced_skills.append(f"{skill_id}:{max(0, init_number)}")

    for pkt in packets:
        sock.sendall(pkt)

    if player and hasattr(player, 'active_scene_tools'):
        for uid in player.active_scene_tools:
            del_pkt = build_rsp_delete_scene_tool(
                scene_tool_unique_id=uid,
                kind=SCENE_TOOL_DELETE_KIND_DESTROY,
                attacker_bid=bid,
                effect_type=0
            )
            sock.sendall(del_pkt)
            if session:
                session.broadcast(del_pkt, exclude_bid=bid)
        player.active_scene_tools.clear()

    _log(
        "sent reset item ack "
        f"packets={len(packets)} "
        f"resolved_skills={resolved_skill_ids if resolved_skill_ids else []} "
        f"char_id={resolved_character_id} "
        f"skills={','.join(synced_skills) if synced_skills else 'none'} "
        f"to {peer}"
    )


def _opposite_battle_camp(camp: int) -> int:
    if camp == BATTLE_CAMP_ATTACKER:
        return BATTLE_CAMP_DEFENDER
    if camp == BATTLE_CAMP_DEFENDER:
        return BATTLE_CAMP_ATTACKER
    return BATTLE_CAMP_NO_CAMP


def _player_result_rank_value(player: BattlePlayer) -> int:
    # Prefer uid when available; fallback to small runtime bid.
    if int(player.uid) > 0:
        return int(player.uid) & 0xFFFFFFFF
    return int(player.bid) & 0xFFFFFFFF


def _derive_leave_result_payload(
    reason: int,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[int, int, list[int]]:
    win_camp = BATTLE_CAMP_NO_CAMP
    replay_bid = 0
    winners_rank: list[int] = []

    # For self-leave, opposite camp is considered winner when known.
    if reason == BATTLE_OVER_REASON_SELF_LEAVE and player is not None:
        win_camp = _opposite_battle_camp(int(player.camp))
        if session is not None and win_camp != BATTLE_CAMP_NO_CAMP:
            with session._lock:
                for candidate in session.players.values():
                    if int(candidate.bid) == int(player.bid):
                        continue
                    if int(candidate.camp) != win_camp:
                        continue
                    winners_rank.append(_player_result_rank_value(candidate))
                    if replay_bid == 0:
                        replay_bid = int(candidate.bid) & 0xFF

        # If winner camp cannot be backed by any known winner, keep payload neutral.
        if not winners_rank:
            win_camp = BATTLE_CAMP_NO_CAMP

    return win_camp, replay_bid, winners_rank


def _session_send_packets(
    session: BattleSession | None,
    sock: socket.socket,
    packets: list[bytes],
):
    for pkt in packets:
        if not pkt:
            continue
        if session is not None:
            session.broadcast(pkt)
        else:
            sock.sendall(pkt)


def _record_guide_scanned_enemy_bids(player: BattlePlayer, enemies: object):
    if not isinstance(enemies, list):
        return
    known = set(int(v) & 0xFF for v in player.guide_scanned_enemy_bids)
    for row in enemies:
        if not isinstance(row, dict):
            continue
        try:
            bid = int(row.get('bid', 0) or 0) & 0xFF
        except Exception:
            continue
        if bid <= 0 or bid == int(player.bid):
            continue
        if bid in known:
            continue
        player.guide_scanned_enemy_bids.append(bid)
        known.add(bid)
        if len(player.guide_scanned_enemy_bids) > 16:
            player.guide_scanned_enemy_bids = player.guide_scanned_enemy_bids[-16:]
            known = set(int(v) & 0xFF for v in player.guide_scanned_enemy_bids)


def _select_guide_enemy_bid(player: BattlePlayer) -> int:
    for raw_bid in player.guide_scanned_enemy_bids:
        bid = int(raw_bid) & 0xFF
        if bid > 0 and bid != int(player.bid):
            return bid
    return 2 if int(player.bid) != 2 else 3


def _guide_get_critical_region_state(
    session: BattleSession | None,
) -> int:
    if session is None:
        return CRITICAL_REGION_STATE_ONLY_DEFENDERS
    return int(getattr(session, 'guide_critical_region_state', CRITICAL_REGION_STATE_ONLY_DEFENDERS))


def _guide_set_critical_region_state(
    session: BattleSession | None,
    state: int,
):
    if session is None:
        return
    session.guide_critical_region_state = int(state) & 0xFF


def _guide_push_critical_region_state(
    session: BattleSession | None,
    sock: socket.socket,
    *,
    state: int,
    _log: Callable,
    reason: str,
):
    pkt = build_rsp_critical_region_state(state)
    _session_send_packets(session, sock, [pkt])
    _guide_set_critical_region_state(session, state)
    _log(
        "guide: sent RspCriticalRegionState "
        f"state={int(state) & 0xFF} reason={reason}"
    )


def _guide_try_push_only_attackers_state(
    session: BattleSession | None,
    sock: socket.socket,
    *,
    _log: Callable,
    reason: str,
) -> bool:
    if session is None:
        return False
    if not bool(getattr(session, 'guide_pending_only_attackers_state', False)):
        return False

    ready_at = float(getattr(session, 'guide_pending_only_attackers_at', 0.0) or 0.0)
    if ready_at > 0.0 and time.time() < ready_at:
        return False

    if _guide_get_critical_region_state(session) != CRITICAL_REGION_STATE_BOTH_PLAYERS:
        return False

    _guide_push_critical_region_state(
        session,
        sock,
        state=CRITICAL_REGION_STATE_ONLY_ATTACKERS,
        _log=_log,
        reason=reason,
    )
    session.guide_pending_only_attackers_state = False
    session.guide_pending_only_attackers_at = 0.0
    return True


def _normalize_scene_tool_unique_id(value: object) -> int | None:
    try:
        scene_tool_unique_id = int(value) & 0xFFFFFFFFFFFFFFFF
    except Exception:
        return None
    if scene_tool_unique_id <= 0:
        return None
    return scene_tool_unique_id


def _decode_unique_id_components(value: object) -> tuple[int, int, int, int] | None:
    """Decode U64Id into (kind, local_id, index1, index2)."""
    try:
        raw = int(value) & 0xFFFFFFFFFFFFFFFF
    except Exception:
        return None
    low = raw & 0xFFFFFFFF
    high = (raw >> 32) & 0xFFFFFFFF
    kind = (high >> 22) & 0xFFFF
    local_id = high & 0x3FFFFF
    index1 = (low >> 16) & 0xFFFF
    index2 = low & 0xFFFF
    return kind, local_id, index1, index2


def _encode_unique_id_components(
    kind: int,
    local_id: int,
    index1: int = 0,
    index2: int = 0,
) -> int:
    """Encode (kind, local_id, index1, index2) into U64Id."""
    normalized_kind = int(kind) & 0xFFFF
    normalized_local_id = int(local_id) & 0x3FFFFF
    normalized_index1 = int(index1) & 0xFFFF
    normalized_index2 = int(index2) & 0xFFFF
    high = ((normalized_kind & 0xFFFF) << 22) | normalized_local_id
    low = ((normalized_index1 & 0xFFFF) << 16) | normalized_index2
    return ((high & 0xFFFFFFFF) << 32) | (low & 0xFFFFFFFF)


def _extract_wall_id_from_unique_id(value: object) -> int | None:
    decoded = _decode_unique_id_components(value)
    if decoded is None:
        return None
    kind, local_id, _, _ = decoded
    # Client DestroySceneObject path uses kind=4 for walls.
    if kind != UNIQUE_ID_KIND_WALL:
        return None
    wall_id = int(local_id) & 0xFFFFFFFF
    if wall_id <= 0:
        return None
    return wall_id


def _target_model_uid_variants(local_id: int) -> tuple[int, ...]:
    normalized_local_id = int(local_id) & 0xFFFFFFFF
    if normalized_local_id <= 0:
        return tuple()

    variants: list[int] = []
    for kind in (
        UNIQUE_ID_KIND_SIMPLE_QUINTAIN,
        UNIQUE_ID_KIND_TARGET_MODEL,
    ):
        encoded = _encode_unique_id_components(kind, normalized_local_id)
        if encoded > 0 and encoded not in variants:
            variants.append(encoded)

    raw_uid = int(normalized_local_id) & 0xFFFFFFFFFFFFFFFF
    if raw_uid > 0 and raw_uid not in variants:
        variants.append(raw_uid)
    return tuple(variants)


def _resolve_training_target_scene_uid_kind(
    local_id: int,
    state: dict | None = None,
) -> int:
    del local_id
    if isinstance(state, dict):
        try:
            explicit_kind = int(
                state.get(
                    'scene_uid_kind',
                    state.get('scene_kind', 0),
                )
                or 0
            )
        except Exception:
            explicit_kind = 0
        if explicit_kind in TRAINING_TARGET_SCENE_ENTITY_KINDS:
            return explicit_kind

    return UNIQUE_ID_KIND_TARGET_MODEL


def _is_training_target_model_state(
    local_id: int,
    state: dict | None = None,
) -> bool:
    return _resolve_training_target_scene_uid_kind(local_id, state) == UNIQUE_ID_KIND_TARGET_MODEL


def _resolve_training_target_entity_uid(
    local_id: int,
    state: dict | None = None,
) -> int:
    try:
        explicit_uid = int((state or {}).get('entity_uid', 0) or 0) & 0xFFFFFFFFFFFFFFFF
    except Exception:
        explicit_uid = 0
    if explicit_uid > 0:
        return explicit_uid

    normalized_local_id = int(local_id) & 0xFFFFFFFF
    if normalized_local_id <= 0:
        return 0

    scene_uid_kind = _resolve_training_target_scene_uid_kind(normalized_local_id, state)
    if scene_uid_kind in TRAINING_TARGET_SCENE_ENTITY_KINDS:
        try:
            encoded_uid = _encode_unique_id_components(scene_uid_kind, normalized_local_id)
        except Exception:
            encoded_uid = 0
        if encoded_uid > 0:
            return int(encoded_uid) & 0xFFFFFFFFFFFFFFFF

    return int(normalized_local_id) & 0xFFFFFFFFFFFFFFFF


def _resolve_training_target_content_config_id(
    local_id: int,
    state: dict | None = None,
) -> int:
    del local_id
    candidate = TRAINING_TARGET_DEFAULT_CONTENT_CONFIG_ID
    if isinstance(state, dict):
        try:
            explicit_content_id = int(
                state.get(
                    'content_config_id',
                    state.get('content_config', 0),
                )
                or 0
            )
        except Exception:
            explicit_content_id = 0
        if explicit_content_id > 0:
            candidate = explicit_content_id
        else:
            try:
                attack_config_id = int(state.get('attack_config_id', 0) or 0)
            except Exception:
                attack_config_id = 0
            if attack_config_id in (8, 9):
                candidate = attack_config_id
    if candidate <= 0:
        candidate = TRAINING_TARGET_DEFAULT_CONTENT_CONFIG_ID
    return int(candidate) & 0xFFFFFFFF


def _resolve_training_target_transform_euler(
    local_id: int,
    state: dict | None = None,
) -> dict:
    del local_id
    normalized_pos = _coerce_vector3_tuple((state or {}).get('position'))
    normalized_euler = _coerce_vector3_tuple((state or {}).get('euler'))
    return {
        'euler': (
            float(normalized_euler[0]),
            float(normalized_euler[1]),
            float(normalized_euler[2]),
        ),
        'position': (
            float(normalized_pos[0]),
            float(normalized_pos[1]),
            float(normalized_pos[2]),
        ),
    }


def _decode_destroy_scene_objects(
    values: object,
) -> tuple[list[int], list[dict[str, int]]]:
    raw_ids: list[int] = []
    decoded_rows: list[dict[str, int]] = []
    if not isinstance(values, list):
        return raw_ids, decoded_rows

    for row in values:
        try:
            raw = int(row) & 0xFFFFFFFFFFFFFFFF
        except Exception:
            continue
        raw_ids.append(raw)
        decoded = _decode_unique_id_components(raw)
        if decoded is None:
            continue
        kind, local_id, index1, index2 = decoded
        decoded_rows.append(
            {
                'raw': raw,
                'kind': int(kind) & 0xFFFF,
                'local_id': int(local_id) & 0xFFFFFFFF,
                'index1': int(index1) & 0xFFFF,
                'index2': int(index2) & 0xFFFF,
            }
        )
    return raw_ids, decoded_rows


def _extract_wall_hit_from_unique_id(value: object) -> tuple[int, int] | None:
    decoded = _decode_unique_id_components(value)
    if decoded is None:
        return None
    kind, local_id, index1, _ = decoded
    if kind != UNIQUE_ID_KIND_WALL:
        return None
    wall_id = int(local_id) & 0xFFFFFFFF
    if wall_id <= 0:
        return None
    return wall_id, int(index1) & 0xFFFF


def _extract_wall_ids_from_unique_id_vector(values: object) -> list[int]:
    if not isinstance(values, list):
        return []
    out: list[int] = []
    seen: set[int] = set()
    for raw in values:
        wall_id = _extract_wall_id_from_unique_id(raw)
        if wall_id is None or wall_id in seen:
            continue
        seen.add(wall_id)
        out.append(wall_id)
    return out


def _select_wall_hint_from_place_req(req: dict) -> int | None:
    if not isinstance(req, dict):
        return None
    # Prefer explicit affected object when it is a wall, then fallback to relevant wall list.
    affected_wall_id = _extract_wall_id_from_unique_id(req.get('affected_id'))
    if affected_wall_id is not None:
        return affected_wall_id
    relevant_wall_ids = _extract_wall_ids_from_unique_id_vector(req.get('relevant_ids', []))
    if relevant_wall_ids:
        return relevant_wall_ids[0]
    # Some payload variants use singular key from autogen naming.
    relevant_wall_ids = _extract_wall_ids_from_unique_id_vector(req.get('relevant_id', []))
    if relevant_wall_ids:
        return relevant_wall_ids[0]
    return None


def _session_mark_scene_tool_active(
    session: BattleSession | None,
    scene_tool_unique_id: object,
):
    if session is None:
        return
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return
    with session._lock:
        session.ended_scene_tool_unique_ids.discard(normalized_uid)
        session.scene_tool_board_hint.pop(normalized_uid, None)


def _session_mark_scene_tool_ended(
    session: BattleSession | None,
    scene_tool_unique_id: object,
) -> bool:
    if session is None:
        return False
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return False
    with session._lock:
        was_active = normalized_uid not in session.ended_scene_tool_unique_ids
        session.ended_scene_tool_unique_ids.add(normalized_uid)
        session.scene_tool_board_hint.pop(normalized_uid, None)
        session.scene_tool_wall_hint.pop(normalized_uid, None)
    return was_active


def _session_is_scene_tool_ended(
    session: BattleSession | None,
    scene_tool_unique_id: object,
) -> bool:
    if session is None:
        return False
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return False
    with session._lock:
        return normalized_uid in session.ended_scene_tool_unique_ids


def _extract_scene_tool_position(tool: object) -> tuple[float, float, float]:
    if not isinstance(tool, dict):
        return (0.0, 0.0, 0.0)
    transform = tool.get('transform')
    if isinstance(transform, dict):
        return _coerce_vector3_tuple(transform.get('position'))
    trans = tool.get('trans')
    if isinstance(trans, dict):
        return _coerce_vector3_tuple(trans.get('position'))
    return (0.0, 0.0, 0.0)


def _session_guess_blocking_board_id_by_position_locked(
    session: BattleSession,
    source: tuple[float, float, float],
    *,
    max_dist_sq: float = 289.0,
) -> int | None:
    if not session.blocking_board_anchor:
        return None

    src_x, src_y, src_z = source
    best_id: int | None = None
    best_dist_sq: float | None = None
    for board_id, anchor in session.blocking_board_anchor.items():
        normalized_board_id = _normalize_board_id(board_id)
        if normalized_board_id is None:
            continue
        if int(session.blocking_board_states.get(normalized_board_id, BLOCKING_BOARD_STATE_FORWARD)) == BLOCKING_BOARD_STATE_DEACTIVE:
            continue

        anchor_pos = _coerce_vector3_tuple(anchor)
        dx = src_x - anchor_pos[0]
        dy = src_y - anchor_pos[1]
        dz = src_z - anchor_pos[2]
        if abs(dy) > BLOCKING_BOARD_MAX_ANCHOR_Y_DELTA:
            continue
        dist_sq = (dx * dx) + (dy * dy) + (dz * dz)
        if best_dist_sq is None or dist_sq < best_dist_sq:
            best_dist_sq = dist_sq
            best_id = normalized_board_id

    if best_id is not None and best_dist_sq is not None and best_dist_sq <= max_dist_sq:
        return best_id
    return None


def _session_update_scene_tool_board_hint(
    session: BattleSession | None,
    scene_tool_unique_id: object,
    source: tuple[float, float, float],
):
    if session is None:
        return
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return
    with session._lock:
        guessed_id = _session_guess_blocking_board_id_by_position_locked(session, source)
        if guessed_id is not None:
            session.scene_tool_board_hint[normalized_uid] = guessed_id


def _session_get_scene_tool_board_hint(
    session: BattleSession | None,
    scene_tool_unique_id: object,
) -> int | None:
    if session is None:
        return None
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return None
    with session._lock:
        board_id = session.scene_tool_board_hint.get(normalized_uid)
        return _normalize_board_id(board_id)


def _session_set_scene_tool_wall_hint(
    session: BattleSession | None,
    scene_tool_unique_id: object,
    wall_id: object,
):
    if session is None:
        return
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    normalized_wall_id = _normalize_board_id(wall_id)
    if normalized_uid is None or normalized_wall_id is None:
        return
    with session._lock:
        session.scene_tool_wall_hint[normalized_uid] = normalized_wall_id


def _session_get_scene_tool_wall_hint(
    session: BattleSession | None,
    scene_tool_unique_id: object,
) -> int | None:
    if session is None:
        return None
    normalized_uid = _normalize_scene_tool_unique_id(scene_tool_unique_id)
    if normalized_uid is None:
        return None
    with session._lock:
        wall_id = session.scene_tool_wall_hint.get(normalized_uid)
    return _normalize_board_id(wall_id)


def _normalize_board_id(value: object) -> int | None:
    try:
        board_id = int(value) & 0xFFFFFFFF
    except Exception:
        return None
    if board_id <= 0:
        return None
    return board_id


def _ray_damage_point(
    ray: object,
    distance: object | None = None,
) -> tuple[float, float, float]:
    if not isinstance(ray, dict):
        return (0.0, 0.0, 0.0)
    origin = _coerce_vector3_tuple(ray.get('pos'))
    if distance is None:
        return origin
    try:
        dist = float(distance)
    except Exception:
        return origin
    direction = _coerce_vector3_tuple(ray.get('dir'))
    return (
        origin[0] + direction[0] * dist,
        origin[1] + direction[1] * dist,
        origin[2] + direction[2] * dist,
    )


def _extract_target_board_id_from_hit_target(hit_target: object) -> int | None:
    if isinstance(hit_target, dict):
        for key in (
            'affected_id',
            'hit_target_id',
            'target_id',
            'item_uid',
            'uid',
            'id',
            'target_uid',
            'unique_id',
        ):
            wall_hit = _extract_wall_hit_from_unique_id(hit_target.get(key))
            if wall_hit is not None:
                return wall_hit[0]

        for key in (
            'bid',
            'block_id',
            'board_id',
            'target_bid',
            'id',
        ):
            board_id = _normalize_board_id(hit_target.get(key))
            if board_id is not None:
                return board_id

        for key in (
            'hit_target_id',
            'target_id',
            'item_uid',
            'uid',
        ):
            raw_value = hit_target.get(key)
            if raw_value is None:
                continue
            wall_hit = _extract_wall_hit_from_unique_id(raw_value)
            if wall_hit is not None:
                return wall_hit[0]
            try:
                board_id = _normalize_board_id(int(raw_value) & 0xFFFFFFFF)
            except Exception:
                board_id = None
            if board_id is not None:
                return board_id

        for key in (
            'hit_target',
            'target_character',
            'target',
        ):
            nested = hit_target.get(key)
            board_id = _extract_target_board_id_from_hit_target(nested)
            if board_id is not None:
                return board_id
        return None

    wall_hit = _extract_wall_hit_from_unique_id(hit_target)
    if wall_hit is not None:
        return wall_hit[0]
    return _normalize_board_id(hit_target)


def _extract_req_target_board_id_from_gun_fire(req: dict) -> int | None:
    bullets = req.get('bullets')
    if not isinstance(bullets, list):
        return None
    for bullet in bullets:
        if not isinstance(bullet, dict):
            continue
        for key in (
            'target_character',
            'target',
            'hit_target',
        ):
            board_id = _extract_target_board_id_from_hit_target(bullet.get(key))
            if board_id is not None:
                return board_id

        behurt_info = bullet.get('behurt_info')
        if isinstance(behurt_info, dict):
            board_id = _extract_target_board_id_from_hit_target(behurt_info.get('target'))
            if board_id is not None:
                return board_id

        for key in (
            'affected_id',
            'hit_target_id',
            'target_id',
            'item_uid',
            'uid',
            'id',
            'target_uid',
            'unique_id',
        ):
            wall_hit = _extract_wall_hit_from_unique_id(bullet.get(key))
            if wall_hit is not None:
                return wall_hit[0]

        for key in (
            'hit_target_id',
            'target_id',
            'target_bid',
            'bid',
        ):
            raw_value = bullet.get(key)
            if raw_value is None:
                continue
            try:
                board_id = _normalize_board_id(int(raw_value) & 0xFFFFFFFF)
            except Exception:
                board_id = None
            if board_id is not None:
                return board_id
    return None


def _extract_req_target_board_id_from_melee_target(target: object) -> int | None:
    if not isinstance(target, dict):
        return _extract_target_board_id_from_hit_target(target)

    for key in (
        'hit_target',
        'target_character',
        'target',
    ):
        board_id = _extract_target_board_id_from_hit_target(target.get(key))
        if board_id is not None:
            return board_id

    return _extract_target_board_id_from_hit_target(target)


def _normalize_block_segment_index(value: object) -> int | None:
    try:
        block_index = int(value)
    except Exception:
        return None
    if block_index < 0:
        return None
    return block_index & 0xFFFF


def _damage_source_to_board_block_index(
    damage_source: tuple[float, float, float],
    existing_broken: set[int],
    board_anchor: tuple[float, float, float] | None = None,
    board_mid_y: float | None = None,
    board_normal: tuple[float, float] | None = None,
    total_cols: int = BLOCKING_BOARD_BLOCK_COLS,
    total_rows: int = BLOCKING_BOARD_BLOCK_ROWS,
    half_width: float = BLOCKING_BOARD_HALF_WIDTH,
    local_x_bias: float = BLOCKING_BOARD_LOCAL_X_BIAS,
    local_x_gain: float = BLOCKING_BOARD_LOCAL_X_GAIN,
    row_top_down: bool = BLOCKING_BOARD_ROW_TOP_DOWN,
    col_mirror: bool = BLOCKING_BOARD_COL_MIRROR,
    half_height: float = BLOCKING_BOARD_HALF_HEIGHT,
) -> int | None:
    """Geometric point-to-segment mapping without sequential fallback.

    NOTE: If source is not a valid board hit approximation, returns None.
    """
    if board_anchor is None:
        return None

    sx, sy, sz = damage_source
    ax, ay, az = board_anchor

    if board_normal is not None:
        hnx, hnz = board_normal
    else:
        # Last-resort normal approximation from point-to-anchor.
        hnx = sx - ax
        hnz = sz - az
        hmag = math.sqrt(hnx * hnx + hnz * hnz)
        if hmag < 0.01:
            return None
        hnx /= hmag
        hnz /= hmag

    mid_y = board_mid_y if board_mid_y is not None else ay
    local_x, local_y = _world_point_to_board_local(
        (sx, sy, sz),
        board_anchor,
        mid_y,
        (hnx, hnz),
    )

    return _local_xy_to_board_block_index(
        local_x,
        local_y,
        existing_broken,
        total_cols,
        total_rows,
        half_height,
        half_width,
        local_x_bias,
        local_x_gain,
        row_top_down,
        col_mirror,
    )


def _collect_target_block_indices_from_hit_target(
    hit_target: object,
    out: list[int],
    seen: set[int],
):
    if not isinstance(hit_target, dict):
        return

    for key in (
        'affected_id',
        'hit_target_id',
        'target_id',
        'item_uid',
        'uid',
        'id',
        'target_uid',
        'unique_id',
    ):
        wall_hit = _extract_wall_hit_from_unique_id(hit_target.get(key))
        if wall_hit is None:
            continue
        block_index = wall_hit[1]
        if block_index in seen:
            continue
        seen.add(block_index)
        out.append(block_index)

    for key in (
        'part_index',
        'partIndex',
        'block_index',
        'blockIndex',
        'segment_index',
        'segmentIndex',
        'target_part_index',
        'targetPartIndex',
    ):
        block_index = _normalize_block_segment_index(hit_target.get(key))
        if block_index is None or block_index in seen:
            continue
        seen.add(block_index)
        out.append(block_index)

    for key in (
        'relevant_ids',
        'relevant_id',
        'target_ids',
        'ids',
    ):
        rows = hit_target.get(key)
        if not isinstance(rows, list):
            continue
        for row in rows:
            wall_hit = _extract_wall_hit_from_unique_id(row)
            if wall_hit is None:
                continue
            block_index = wall_hit[1]
            if block_index in seen:
                continue
            seen.add(block_index)
            out.append(block_index)

    for key in (
        'hit_target',
        'target_character',
        'target',
    ):
        _collect_target_block_indices_from_hit_target(hit_target.get(key), out, seen)


def _extract_req_target_block_indices_from_gun_fire(req: dict) -> list[int]:
    out: list[int] = []
    seen: set[int] = set()
    bullets = req.get('bullets')
    if not isinstance(bullets, list):
        return out

    for bullet in bullets:
        if not isinstance(bullet, dict):
            continue

        for key in (
            'target_character',
            'target',
            'hit_target',
        ):
            _collect_target_block_indices_from_hit_target(bullet.get(key), out, seen)

        behurt_info = bullet.get('behurt_info')
        if isinstance(behurt_info, dict):
            _collect_target_block_indices_from_hit_target(behurt_info.get('target'), out, seen)

    return out


def _extract_req_target_block_indices_from_melee_target(target: object) -> list[int]:
    out: list[int] = []
    seen: set[int] = set()
    _collect_target_block_indices_from_hit_target(target, out, seen)
    return out


def _extract_req_ray_samples_from_gun_fire(req: dict) -> list[dict]:
    out: list[dict] = []
    bullets = req.get('bullets')
    if not isinstance(bullets, list):
        return out

    for bullet in bullets:
        if not isinstance(bullet, dict):
            continue
        ray = bullet.get('ray')
        if not isinstance(ray, dict):
            continue
        out.append(ray)
    return out


def _extract_req_ray_samples_from_melee_target(
    target: object,
    forward_ray: object | None = None,
) -> list[dict]:
    out: list[dict] = []
    if isinstance(target, dict):
        hit_ray = target.get('hit_ray')
        if isinstance(hit_ray, dict):
            out.append(hit_ray)
    if isinstance(forward_ray, dict):
        out.append(forward_ray)
    return out


def _extract_gun_fire_damage_source(req: dict) -> tuple[float, float, float]:
    bullets = req.get('bullets')
    if isinstance(bullets, list):
        for bullet in bullets:
            if not isinstance(bullet, dict):
                continue
            ray = bullet.get('ray')
            if not isinstance(ray, dict):
                continue
            if 'target_distance' in bullet:
                return _ray_damage_point(ray, bullet.get('target_distance'))
            return _ray_damage_point(ray)
    return (0.0, 0.0, 0.0)


def _extract_melee_damage_source(
    target: object,
    forward_ray: object | None = None,
) -> tuple[float, float, float]:
    if isinstance(target, dict):
        hit_ray = target.get('hit_ray')
        if isinstance(hit_ray, dict):
            return _ray_damage_point(hit_ray, target.get('hit_distance'))
    if isinstance(forward_ray, dict):
        return _ray_damage_point(forward_ray)
    return (0.0, 0.0, 0.0)


def _normalize_ray_direction(ray: object) -> tuple[float, float, float] | None:
    if not isinstance(ray, dict):
        return None
    dx, dy, dz = _coerce_vector3_tuple(ray.get('dir'))
    norm = math.sqrt(dx * dx + dy * dy + dz * dz)
    if norm < 1e-6:
        return None
    return (dx / norm, dy / norm, dz / norm)


def _iter_normalized_ray_directions(ray: object) -> list[tuple[float, float, float]]:
    if not isinstance(ray, dict):
        return []
    out: list[tuple[float, float, float]] = []

    # Variant A (most packets): ray.dir is already a direction vector.
    primary = _normalize_ray_direction(ray)
    if primary is not None:
        out.append(primary)

    # Variant B (legacy/custom encoders): ray.dir is an end-point in world space.
    pos = _coerce_vector3_tuple(ray.get('pos'))
    end = _coerce_vector3_tuple(ray.get('dir'))
    ex = float(end[0]) - float(pos[0])
    ey = float(end[1]) - float(pos[1])
    ez = float(end[2]) - float(pos[2])
    norm = math.sqrt(ex * ex + ey * ey + ez * ez)
    if norm >= 1e-6:
        alt = (ex / norm, ey / norm, ez / norm)
        if not out:
            out.append(alt)
        else:
            dot = (
                float(out[0][0]) * float(alt[0])
                + float(out[0][1]) * float(alt[1])
                + float(out[0][2]) * float(alt[2])
            )
            if dot < 0.9995:
                out.append(alt)
    return out


def _ray_sphere_hit_distance(
    ray_origin: tuple[float, float, float],
    ray_dir_norm: tuple[float, float, float],
    sphere_center: tuple[float, float, float],
    sphere_radius: float,
) -> float | None:
    if sphere_radius <= 1e-4:
        return None

    ox, oy, oz = ray_origin
    dx, dy, dz = ray_dir_norm
    cx, cy, cz = sphere_center

    lx = ox - cx
    ly = oy - cy
    lz = oz - cz
    b = lx * dx + ly * dy + lz * dz
    c = lx * lx + ly * ly + lz * lz - sphere_radius * sphere_radius
    disc = b * b - c
    if disc < 0.0:
        return None

    sqrt_disc = math.sqrt(max(0.0, disc))
    near_t = -b - sqrt_disc
    far_t = -b + sqrt_disc
    if far_t < 0.0:
        return None
    if near_t >= 0.0:
        return near_t
    return far_t


def _resolve_training_target_hit_shape(content_config_id: int) -> dict[str, float]:
    # content_config_id=8 is standing target, 9 is low/sitting target.
    if int(content_config_id) == 9:
        return {
            'head_center_y': 0.93,
            'head_radius': 0.20,
            'body_center_y': 0.58,
            'body_radius': 0.42,
        }
    return {
        'head_center_y': 1.46,
        'head_radius': 0.20,
        'body_center_y': 0.96,
        'body_radius': 0.44,
    }


def _session_pick_training_target_hit_locked(
    session: BattleSession,
    bullet: dict,
) -> dict | None:
    ray = bullet.get('ray')
    if not isinstance(ray, dict):
        return None

    ray_origin = _coerce_vector3_tuple(ray.get('pos'))
    ray_dir_candidates = _iter_normalized_ray_directions(ray)
    if not ray_dir_candidates:
        return None

    explicit_distance = 0.0
    for key in ('target_distance', 'distance'):
        if key not in bullet:
            continue
        try:
            explicit_distance = max(explicit_distance, float(bullet.get(key, 0.0) or 0.0))
        except Exception:
            continue
    max_distance = TRAINING_TARGET_HIT_MAX_DISTANCE
    if explicit_distance > 0.0:
        max_distance = min(max_distance, explicit_distance + 0.75)

    best: dict | None = None
    for raw_uid, state in session.training_target_state.items():
        try:
            target_uid = int(raw_uid) & 0xFFFFFFFF
        except Exception:
            continue
        if target_uid <= 0:
            continue
        if not bool((state or {}).get('alive', True)):
            continue
        if not _is_training_target_model_state(target_uid, state):
            continue

        pos = _coerce_vector3_tuple((state or {}).get('position'))
        content_config_id = _resolve_training_target_content_config_id(target_uid, state)
        shape = _resolve_training_target_hit_shape(content_config_id)

        body_center = (
            float(pos[0]),
            float(pos[1]) + float(shape['body_center_y']),
            float(pos[2]),
        )
        head_center = (
            float(pos[0]),
            float(pos[1]) + float(shape['head_center_y']),
            float(pos[2]),
        )

        for ray_dir_norm in ray_dir_candidates:
            body_t = _ray_sphere_hit_distance(
                ray_origin,
                ray_dir_norm,
                body_center,
                float(shape['body_radius']),
            )
            head_t = _ray_sphere_hit_distance(
                ray_origin,
                ray_dir_norm,
                head_center,
                float(shape['head_radius']),
            )
            if body_t is None and head_t is None:
                continue

            if head_t is not None and (body_t is None or head_t <= body_t):
                zone = 'head'
                hit_t = float(head_t)
            else:
                zone = 'body'
                hit_t = float(body_t)

            if hit_t < 0.0 or hit_t > max_distance:
                continue

            hit_point = (
                ray_origin[0] + ray_dir_norm[0] * hit_t,
                ray_origin[1] + ray_dir_norm[1] * hit_t,
                ray_origin[2] + ray_dir_norm[2] * hit_t,
            )
            candidate = {
                'target_uid': target_uid,
                'state': state,
                'zone': zone,
                'distance': hit_t,
                'hit_point': hit_point,
            }
            if best is None or float(candidate['distance']) < float(best['distance']):
                best = candidate
    return best


def _session_collect_training_target_gun_hit_packets(
    session: BattleSession | None,
    req: dict,
    *,
    player: BattlePlayer | None,
    _log: Callable,
) -> tuple[list[bytes], list[bytes]]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return [], []
    bullets = req.get('bullets')
    if not isinstance(bullets, list) or not bullets:
        return [], []

    target_destroy_rows: list[tuple[int, tuple[float, float, float]]] = []
    broken_simple_quintains: list[int] | None = None
    score_rows: list[dict[str, int]] = []
    debug_rows: list[str] = []
    now_ts = time.time()

    with session._lock:
        for bullet_idx, bullet in enumerate(bullets):
            if not isinstance(bullet, dict):
                continue
            hit = _session_pick_training_target_hit_locked(session, bullet)
            if hit is None:
                continue

            target_uid = int(hit['target_uid']) & 0xFFFFFFFF
            state = session.training_target_state.get(target_uid)
            if not isinstance(state, dict):
                continue
            if not bool(state.get('alive', True)):
                continue

            zone = str(hit.get('zone', 'body'))
            current_hp = int(state.get('hp', _training_target_initial_hp(state)) or 0)
            if current_hp <= 0:
                current_hp = _training_target_initial_hp(state)

            if zone == 'head':
                next_hp = 0
                action = POINT_ACTION_HIT_TARGET_MODEL_HEAD
                point_value = TRAINING_TARGET_HIT_HEAD_POINTS
            else:
                next_hp = max(0, current_hp - 1)
                action = POINT_ACTION_HIT_TARGET_MODEL_BODY
                point_value = TRAINING_TARGET_HIT_BODY_POINTS
            destroyed = next_hp <= 0

            state['hp'] = int(next_hp)
            if destroyed:
                state['alive'] = False
                state['relive_at'] = now_ts + TRAINING_TARGET_RESPAWN_SEC
                destroy_uid = _resolve_training_target_entity_uid(target_uid, state)
                if destroy_uid > 0:
                    target_destroy_rows.append(
                        (
                            int(destroy_uid) & 0xFFFFFFFFFFFFFFFF,
                            _coerce_vector3_tuple(hit.get('hit_point')),
                        )
                    )
            score_rows.append(
                {
                    'action': int(action) & 0xFFFFFFFF,
                    'point': int(point_value),
                }
            )
            debug_rows.append(
                "b#{bullet} id={uid} zone={zone} hp={hp0}->{hp1} destroyed={destroyed}".format(
                    bullet=int(bullet_idx),
                    uid=int(target_uid),
                    zone=zone,
                    hp0=int(current_hp),
                    hp1=int(next_hp),
                    destroyed=1 if destroyed else 0,
                )
            )

        if target_destroy_rows:
            broken_simple_quintains = _session_collect_broken_simple_quintains_locked(session)

    world_packets: list[bytes] = []
    for destroy_uid, hit_point in target_destroy_rows:
        world_packets.append(
            build_rsp_target_model_destroy(
                destroy_uid,
                damage_source=hit_point,
            )
        )
    if broken_simple_quintains is not None:
        world_packets.append(build_rsp_simple_quintain_info(broken_simple_quintains))

    personal_packets: list[bytes] = []
    if score_rows and player is not None:
        player_id = 0
        try:
            player_id = int(player.uid or 0)
        except Exception:
            player_id = 0
        if player_id <= 0:
            player_id = int(player.bid) if player is not None else 0
        personal_packets.append(
            build_rsp_game_points(
                player_id=player_id,
                points=score_rows,
            )
        )

    if debug_rows:
        _log(
            "training-target gun-hit "
            f"hits={len(debug_rows)} destroyed={len(target_destroy_rows)} "
            f"score_rows={len(score_rows)} "
            + " | ".join(debug_rows[:6])
        )
    return world_packets, personal_packets


def _blocking_board_damage_step(destroy_type: int) -> float:
    normalized_type = int(destroy_type) & 0xFF
    if normalized_type in {
        DESTROY_TYPE_EXPLOSIVE_DAMAGE,
        DESTROY_TYPE_THERMITE_BOMB,
    }:
        return 1.0
    if normalized_type == DESTROY_TYPE_ELEC_MAG_PULSE:
        # Keep parity with explosive contract for shock-grenade wall impact.
        return 1.0
    if normalized_type == DESTROY_TYPE_HAMMER_DAMAGE:
        return 0.55
    if normalized_type == DESTROY_TYPE_MELEE_DAMAGE:
        # Melee should require three consistent hits.
        return 0.34
    if normalized_type == DESTROY_TYPE_SNIPE_GUN_DAMAGE:
        return 0.42
    if normalized_type == DESTROY_TYPE_SHOT_GUN_DAMAGE:
        return 0.24
    return 0.14


def _session_get_blocking_board_profile_locked(session: BattleSession | None, board_id: object) -> BlockingBoardProfile:
    if session is None:
        return BLOCKING_BOARD_DEFAULT_PROFILE

    normalized_board_id = _normalize_board_id(board_id)
    if normalized_board_id is None:
        return session.blocking_board_default_profile

    existing = session.blocking_board_profiles.get(normalized_board_id)
    if existing is not None:
        return existing

    profile_overrides = session.game_state.get('blocking_board_profiles')
    if isinstance(profile_overrides, dict):
        raw_profile = profile_overrides.get(normalized_board_id)
        if raw_profile is None:
            raw_profile = profile_overrides.get(str(normalized_board_id))
        if raw_profile is not None:
            return _coerce_blocking_board_profile(
                raw_profile,
                session.blocking_board_default_profile,
            )

    return session.blocking_board_default_profile


def _session_get_blocking_board_profile(session: BattleSession | None, board_id: object) -> BlockingBoardProfile:
    if session is None:
        return BLOCKING_BOARD_DEFAULT_PROFILE
    with session._lock:
        profile = _session_get_blocking_board_profile_locked(session, board_id)
        normalized_board_id = _normalize_board_id(board_id)
        if normalized_board_id is not None:
            session.blocking_board_profiles[normalized_board_id] = profile
        return profile


def _collect_blocking_board_probe_points(
    damage_source: tuple[float, float, float],
    ray_samples: list[dict] | None = None,
) -> list[tuple[float, float, float]]:
    probes: list[tuple[float, float, float]] = [_coerce_vector3_tuple(damage_source)]
    for sample in (ray_samples or []):
        if not isinstance(sample, dict):
            continue
        origin = _coerce_vector3_tuple(sample.get('pos'))
        direction = _coerce_vector3_tuple(sample.get('dir'))
        dx, dy, dz = direction
        mag = math.sqrt(dx * dx + dy * dy + dz * dz)
        if mag <= 1e-6:
            continue

        ndx = dx / mag
        ndy = dy / mag
        ndz = dz / mag

        probes.append(origin)
        for dist in BLOCKING_BOARD_RAY_PROBE_DISTANCES:
            probes.append(
                (
                    origin[0] + ndx * dist,
                    origin[1] + ndy * dist,
                    origin[2] + ndz * dist,
                )
            )

    return probes


def _board_local_hit_penalty(
    local_x: float,
    local_y: float,
    profile: BlockingBoardProfile,
    *,
    x_margin: float,
    y_margin: float,
) -> float:
    denom_x = max(1e-6, float(profile.half_width) * float(x_margin))
    denom_y = max(1e-6, float(profile.half_height) * float(y_margin))
    return (abs(float(local_x)) / denom_x) + (abs(float(local_y)) / denom_y)


def _session_select_blocking_board_id_locked(
    session: BattleSession,
    preferred_board_id: int | None,
    damage_source: tuple[float, float, float],
    ray_samples: list[dict] | None = None,
) -> tuple[int | None, str]:
    known_ids: set[int] = set(int(v) for v in session.blocking_board_states.keys())
    known_ids.update(int(v) for v in session.blocking_board_hp.keys())
    known_ids.update(int(v) for v in session.dynamic_walls.keys())

    preferred = _normalize_board_id(preferred_board_id)
    if preferred is not None:
        if preferred in known_ids:
            return preferred, 'preferred_known'
        # Accept explicit board ids even if the session has not seen them yet.
        # Different barricade classes can use different ids, so the server must
        # not restrict discovery to a numeric range.
        session.blocking_board_states.setdefault(preferred, BLOCKING_BOARD_STATE_FORWARD)
        if float(session.blocking_board_hp.get(preferred, 1.0)) <= 0.0:
            session.blocking_board_hp[preferred] = 1.0
        else:
            session.blocking_board_hp.setdefault(preferred, 1.0)
        dyn = session.dynamic_walls.setdefault(
            preferred,
            {
                'state': int(session.blocking_board_states.get(preferred, BLOCKING_BOARD_STATE_FORWARD)) & 0xFF,
                'blocks': set(),
            },
        )
        if not isinstance(dyn.get('blocks'), set):
            dyn['blocks'] = set()
        return preferred, 'preferred_new'

    last = _normalize_board_id(session.last_blocking_board_id or 0)
    if not known_ids and last is not None:
        return last, 'last_only'

    rejected_unconfident_dbg: str | None = None
    if known_ids and session.blocking_board_anchor:
        probe_points = _collect_blocking_board_probe_points(damage_source, ray_samples)
        ranked: list[tuple[tuple[int, float, float, float, int], int, str]] = []
        for board_id in known_ids:
            normalized_board_id = int(board_id)
            if (
                int(
                    session.blocking_board_states.get(
                        normalized_board_id,
                        BLOCKING_BOARD_STATE_FORWARD,
                    )
                )
                == BLOCKING_BOARD_STATE_DEACTIVE
            ):
                continue

            anchor = session.blocking_board_anchor.get(normalized_board_id)
            if anchor is None:
                continue
            anchor_pos = _coerce_vector3_tuple(anchor)
            board_best_dist_sq: float | None = None
            for probe_x, probe_y, probe_z in probe_points:
                dx = probe_x - anchor_pos[0]
                dy = probe_y - anchor_pos[1]
                dz = probe_z - anchor_pos[2]
                if abs(dy) > BLOCKING_BOARD_MAX_ANCHOR_Y_DELTA:
                    continue
                dist_sq = (dx * dx) + (dy * dy) + (dz * dz)
                if board_best_dist_sq is None or dist_sq < board_best_dist_sq:
                    board_best_dist_sq = dist_sq

            if board_best_dist_sq is None:
                continue
            if board_best_dist_sq > BLOCKING_BOARD_SELECTION_MAX_DIST_SQ:
                continue

            profile = _session_get_blocking_board_profile_locked(session, normalized_board_id)
            board_mid_y = anchor_pos[1] + profile.anchor_to_center_y

            board_norm = session.blocking_board_normal.get(normalized_board_id)
            norm_src = 'cache'
            if board_norm is None:
                yaw = session.blocking_board_yaw.get(normalized_board_id)
                if yaw is not None and math.isfinite(float(yaw)):
                    board_norm = _yaw_to_horizontal_normal(float(yaw))
                    norm_src = 'yaw'
                else:
                    norm_src = 'none'

            ray_penalty: float | None = None
            ray_inside = False
            if board_norm is not None and ray_samples:
                for sample in ray_samples:
                    if not isinstance(sample, dict):
                        continue
                    ro = _coerce_vector3_tuple(sample.get('pos'))
                    rd = _coerce_vector3_tuple(sample.get('dir'))
                    local = _ray_board_hit_local(
                        ro,
                        rd,
                        anchor_pos,
                        board_mid_y=board_mid_y,
                        stored_normal=board_norm,
                    )
                    if local is None:
                        continue
                    lx, ly, *_ = local
                    penalty = _board_local_hit_penalty(
                        lx,
                        ly,
                        profile,
                        x_margin=BLOCKING_BOARD_SELECTION_RAY_X_MARGIN,
                        y_margin=BLOCKING_BOARD_SELECTION_RAY_Y_MARGIN,
                    )
                    if ray_penalty is None or penalty < ray_penalty:
                        ray_penalty = penalty
                    if (
                        abs(lx) <= profile.half_width * BLOCKING_BOARD_SELECTION_RAY_X_MARGIN
                        and abs(ly) <= profile.half_height * BLOCKING_BOARD_SELECTION_RAY_Y_MARGIN
                    ):
                        ray_inside = True

            source_penalty: float | None = None
            source_inside = False
            if board_norm is not None:
                lx, ly = _world_point_to_board_local(
                    damage_source,
                    anchor_pos,
                    board_mid_y,
                    board_norm,
                )
                source_penalty = _board_local_hit_penalty(
                    lx,
                    ly,
                    profile,
                    x_margin=BLOCKING_BOARD_SELECTION_SOURCE_X_MARGIN,
                    y_margin=BLOCKING_BOARD_SELECTION_SOURCE_Y_MARGIN,
                )
                source_inside = (
                    abs(lx) <= profile.half_width * BLOCKING_BOARD_SELECTION_SOURCE_X_MARGIN
                    and abs(ly) <= profile.half_height * BLOCKING_BOARD_SELECTION_SOURCE_Y_MARGIN
                )

            if ray_inside:
                tier = 0
                metric = ray_penalty or 0.0
                reason = 'ray_inside'
            elif ray_penalty is not None:
                tier = 1
                metric = ray_penalty
                reason = 'ray_near'
            elif source_inside:
                tier = 2
                metric = source_penalty or 0.0
                reason = 'source_inside'
            elif source_penalty is not None:
                tier = 3
                metric = source_penalty
                reason = 'source_near'
            else:
                tier = 4
                metric = 9999.0
                reason = 'distance_only'

            rank = (
                tier,
                float(metric),
                float(board_best_dist_sq),
                abs(float(damage_source[1]) - float(anchor_pos[1])),
                normalized_board_id,
            )
            ranked.append(
                (
                    rank,
                    normalized_board_id,
                    (
                        f"id={normalized_board_id} reason={reason} tier={tier} "
                        f"metric={float(metric):.3f} dist_sq={float(board_best_dist_sq):.2f} "
                        f"norm={norm_src}"
                    ),
                )
            )

        if ranked:
            ranked.sort(key=lambda item: item[0])
            best_rank, best_id, best_dbg = ranked[0]
            if not BLOCKING_BOARD_SELECTION_REQUIRE_CONFIDENCE or int(best_rank[0]) < 4:
                return best_id, best_dbg
            rejected_unconfident_dbg = f"reject_unconfident {best_dbg}"

    if len(known_ids) == 1:
        only_known = int(next(iter(known_ids)))
        only_known_state = int(
            session.blocking_board_states.get(only_known, BLOCKING_BOARD_STATE_FORWARD)
        )
        if only_known_state != BLOCKING_BOARD_STATE_DEACTIVE:
            if rejected_unconfident_dbg:
                return only_known, f"single_known {rejected_unconfident_dbg}"
            return only_known, 'single_known'

    active_ids = [
        int(board_id)
        for board_id in known_ids
        if int(session.blocking_board_states.get(board_id, BLOCKING_BOARD_STATE_FORWARD))
        != BLOCKING_BOARD_STATE_DEACTIVE
    ]
    if len(active_ids) == 1:
        if rejected_unconfident_dbg:
            return active_ids[0], f"single_active {rejected_unconfident_dbg}"
        return active_ids[0], 'single_active'

    if known_ids and last is not None and last in known_ids:
        last_state = int(session.blocking_board_states.get(last, BLOCKING_BOARD_STATE_FORWARD))
        if last_state != BLOCKING_BOARD_STATE_DEACTIVE:
            if rejected_unconfident_dbg:
                return last, f"last_known {rejected_unconfident_dbg}"
            return last, 'last_known'

    if rejected_unconfident_dbg:
        return None, rejected_unconfident_dbg
    return None, 'no_candidate'


def _ray_board_hit_local(
    ray_origin: tuple[float, float, float],
    ray_dir: tuple[float, float, float],
    board_anchor: tuple[float, float, float],
    board_mid_y: float | None = None,
    stored_normal: tuple[float, float] | None = None,
) -> tuple[float, float, tuple[float, float], bool] | None:
    """Intersect a bullet ray with the vertical board plane; return board-local coords.

    board_mid_y  – the world-space Y of the board's geometric centre (used for row
                   discrimination: hit above = top row, below = bottom row).  If None,
                   falls back to board_anchor.y (valid when anchor ≈ board centre).

    stored_normal – previously computed (nx, nz) unit horizontal outward normal of this
                    board.  If supplied the direction is not re-derived from the shooter
                    position, which gives *consistent* left/right mapping across all shots.

    Returns (local_x, local_y, used_normal, hit_from_back_side) where:
      local_x ∈ [−HALF_WIDTH, +HALF_WIDTH]:
          col 0 = attacker’s right,  col N−1 = attacker’s left
          (board_right = cross(world_up, board_normal) = attacker’s right direction)
      local_y = hit_y − board_mid_y  (positive = top half, row 0)
      used_normal = (nx, nz) that was actually used (for the caller to store)

    Returns None if the ray is parallel to the board or intersects behind the origin.
    """
    ox, oy, oz = ray_origin
    dx, dy, dz = ray_dir
    ax, ay, az = board_anchor

    if stored_normal is not None:
        hnx, hnz = stored_normal
    else:
        # Derive outward normal from shooter → board direction.
        hnx = ox - ax
        hnz = oz - az
        hmag = math.sqrt(hnx * hnx + hnz * hnz)
        if hmag < 0.01:
            return None  # Shooter directly above/below board or coincident
        hnx /= hmag
        hnz /= hmag

    # Plane-ray intersection:  t = (N · (A−O)) / (N · D)
    n_dot_d = hnx * dx + hnz * dz
    if abs(n_dot_d) < 1e-6:
        return None  # Ray parallel to board plane

    t = (hnx * (ax - ox) + hnz * (az - oz)) / n_dot_d
    if t < 0.02:
        return None  # Intersection behind the shooter

    # World-space hit point
    hx = ox + dx * t
    hy = oy + dy * t
    hz = oz + dz * t

    # Board right-hand axis (from attacker’s perspective):
    #   board_right = cross(world_up, board_normal)
    #               = cross((0, 1, 0), (hnx, 0, hnz))
    #               = (1·hnz − 0·0,  0·hnx − 0·hnz,  0·0 − 1·hnx)
    #               = (hnz, 0, −hnx)
    # Verification: board_normal = (+1, 0, 0), attacker faces −X → right = −Z
    #   board_right = (0, 0, −1) ✓
    rx = hnz
    rz = -hnx

    local_x = (hx - ax) * rx + (hz - az) * rz
    mid_y = board_mid_y if board_mid_y is not None else ay
    local_y = hy - mid_y
    hit_from_back_side = n_dot_d > 0.0

    return local_x, local_y, (hnx, hnz), hit_from_back_side


def _summarize_req_gun_fire_targets(req: dict) -> str:
    bullets = req.get('bullets')
    if not isinstance(bullets, list) or not bullets:
        return "tg=none"

    with_target = 0
    with_part = 0
    with_dist = 0
    part_preview: list[int] = []
    flags_preview: list[int] = []

    for bullet in bullets:
        if not isinstance(bullet, dict):
            continue

        try:
            flags_preview.append(int(bullet.get('flags', 0) or 0) & 0xFF)
        except Exception:
            pass

        target = bullet.get('target_character')
        if isinstance(target, dict):
            with_target += 1
            part = _normalize_block_segment_index(
                target.get('part_index', target.get('partIndex'))
            )
            if part is not None:
                with_part += 1
                if len(part_preview) < 4:
                    part_preview.append(int(part))

        if ('target_distance' in bullet) or ('distance' in bullet):
            with_dist += 1

    preview_flags = ','.join(str(v) for v in flags_preview[:4]) if flags_preview else '-'
    preview_parts = ','.join(str(v) for v in part_preview) if part_preview else '-'
    return (
        f"tg={with_target}/{len(bullets)} "
        f"part={with_part}/{len(bullets)} part_preview={preview_parts} "
        f"dist={with_dist}/{len(bullets)} flags={preview_flags}"
    )


def _yaw_to_horizontal_normal(yaw_deg: float) -> tuple[float, float]:
    """Convert Unity-style yaw (degrees) to horizontal unit normal (nx, nz)."""
    try:
        yaw = float(yaw_deg)
    except Exception:
        return (0.0, 1.0)
    if not math.isfinite(yaw):
        return (0.0, 1.0)

    rad = math.radians(yaw)
    nx = math.sin(rad)
    nz = math.cos(rad)
    mag = math.sqrt(nx * nx + nz * nz)
    if mag < 1e-6:
        return (0.0, 1.0)
    return (nx / mag, nz / mag)


def _is_barricade_explosion_destroy_type(destroy_type: int) -> bool:
    normalized_type = int(destroy_type) & 0xFF
    return normalized_type in {
        DESTROY_TYPE_EXPLOSIVE_DAMAGE,
        DESTROY_TYPE_THERMITE_BOMB,
        DESTROY_TYPE_ELEC_MAG_PULSE,
    }


def _world_point_to_board_local(
    world_point: tuple[float, float, float],
    board_anchor: tuple[float, float, float],
    board_mid_y: float,
    board_normal: tuple[float, float],
) -> tuple[float, float]:
    px, py, pz = world_point
    ax, _, az = board_anchor
    nx, nz = board_normal

    # board_right = cross(world_up, board_normal) = (nz, 0, -nx)
    local_x = (px - ax) * nz + (pz - az) * (-nx)
    local_y = py - board_mid_y
    return local_x, local_y


def _clustered_new_segments_around(
    center_index: int,
    existing_broken: set[int],
    *,
    max_new: int,
    centers: BlockingBoardCenters | None = None,
    total_cols: int = BLOCKING_BOARD_BLOCK_COLS,
    total_rows: int = BLOCKING_BOARD_BLOCK_ROWS,
) -> list[int]:
    """Pick up to max_new nearest intact segments around center_index.

    Deterministic ordering: distance^2, manhattan distance, row, col.
    This produces compact holes and avoids checkerboard/random patterns.
    """
    if centers:
        total = len(centers)
        if total <= 0 or max_new <= 0:
            return []

        center = max(0, min(total - 1, int(center_index)))
        center_x, center_y = centers[center]

        candidates: list[tuple[tuple[float, float, int], int]] = []
        for idx, (px, py) in enumerate(centers):
            if idx in existing_broken:
                continue
            dx = float(px) - float(center_x)
            dy = float(py) - float(center_y)
            dist2 = (dx * dx) + (dy * dy)
            manhattan = abs(dx) + abs(dy)
            key = (dist2, manhattan, idx)
            candidates.append((key, idx))

        candidates.sort(key=lambda it: it[0])
        return [idx for _, idx in candidates[:max_new]]

    total = total_cols * total_rows
    if total <= 0 or max_new <= 0:
        return []

    center = max(0, min(total - 1, int(center_index)))
    center_row = center // total_cols
    center_col = center % total_cols

    candidates: list[tuple[tuple[int, int, int, int], int]] = []
    for idx in range(total):
        if idx in existing_broken:
            continue
        row = idx // total_cols
        col = idx % total_cols
        dr = row - center_row
        dc = col - center_col
        dist2 = dr * dr + dc * dc
        manhattan = abs(dr) + abs(dc)
        key = (dist2, manhattan, row, col)
        candidates.append((key, idx))

    candidates.sort(key=lambda it: it[0])
    return [idx for _, idx in candidates[:max_new]]


def _local_xy_to_board_block_index(
    local_x: float,
    local_y: float,
    existing_broken: set[int],
    total_cols: int = BLOCKING_BOARD_BLOCK_COLS,
    total_rows: int = BLOCKING_BOARD_BLOCK_ROWS,
    half_height: float = BLOCKING_BOARD_HALF_HEIGHT,
    half_width: float = BLOCKING_BOARD_HALF_WIDTH,
    local_x_bias: float = BLOCKING_BOARD_LOCAL_X_BIAS,
    local_x_gain: float = BLOCKING_BOARD_LOCAL_X_GAIN,
    local_y_bias: float = BLOCKING_BOARD_LOCAL_Y_BIAS,
    local_y_gain: float = BLOCKING_BOARD_LOCAL_Y_GAIN,
    row_top_down: bool = BLOCKING_BOARD_ROW_TOP_DOWN,
    col_mirror: bool = BLOCKING_BOARD_COL_MIRROR,
) -> int:
    """Map board-local (x, y) coordinates to a plank block index.

        Grid layout (from attacker facing the board):
            row 0 orientation is controlled by BLOCKING_BOARD_ROW_TOP_DOWN:
                    True  -> row 0 is top plank (client-style numbering)
                    False -> row 0 is bottom plank
            col orientation is controlled by BLOCKING_BOARD_COL_MIRROR:
                    True  -> mirror X axis so segment #1 is the visual left
                    False -> direct X mapping

    local_x ∈ [−HALF_WIDTH, +HALF_WIDTH]:  horizontal position on plank.
    local_y ∈ [−half_height, +half_height]: vertical position on whole barricade
            (+half_height = top, −half_height = bottom).

    block_index = row * total_cols + col
    Client decomposes: visual_board = block // total_cols, visual_seg = block % total_cols.

    This function only maps geometry to a target cell.
    It does NOT perform fallback to nearest intact neighbours.
    """
    total = total_cols * total_rows
    _ = existing_broken

    # Vertical mapping: local_y -> normalized v in [0..1].
    # Base mapping is bottom->top; optionally flipped to top->bottom.
    y_gain = max(1e-6, float(local_y_gain))
    local_y_adj = (local_y - local_y_bias) * y_gain
    v = (local_y_adj / half_height + 1.0) * 0.5
    v = max(0.0, min(0.999, v))
    if row_top_down:
        v = 1.0 - v
    row = int(v * total_rows)
    row = max(0, min(total_rows - 1, row))

    # Horizontal mapping: local_x -> normalized u in [0..1], optionally mirrored.
    gain = max(1e-6, float(local_x_gain))
    local_x_adj = (local_x - local_x_bias) * gain
    u = (local_x_adj / half_width + 1.0) * 0.5   # [−half,+half] → [0,1]
    u = max(0.0, min(0.999, u))
    if col_mirror:
        u = 1.0 - u
    col = int(u * total_cols)
    col = max(0, min(total_cols - 1, col))

    target = row * total_cols + col
    return max(0, min(total - 1, target))


def _resolve_board_block_index_from_local(
    local_x: float,
    local_y: float,
    existing_broken: set[int],
    profile: BlockingBoardProfile,
    *,
    hit_from_back_side: bool = False,
    force_asset_row_bands: bool = False,
) -> int:
    centers = _get_blocking_board_layout_centers(profile)
    effective_col_mirror = profile.col_mirror
    if BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE and bool(hit_from_back_side):
        if (not centers) or BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE:
            effective_col_mirror = not effective_col_mirror

    if centers:
        lx = float(local_x)
        ly = float(local_y)
        ly = (ly - profile.local_y_bias) * max(1e-6, float(profile.local_y_gain))

        # Keep the same horizontal orientation controls as legacy mapping.
        if effective_col_mirror:
            lx = -lx

        profile_key = _normalize_blocking_board_profile_name(_profile_name(profile)) or ''
        use_row_bands = ('window' in profile_key) or bool(force_asset_row_bands)
        row_bands = _get_blocking_board_layout_row_bands(profile) if use_row_bands else None
        if row_bands:
            best_row_candidates: tuple[int, ...] | None = None
            best_row_gap = float('inf')
            for y_min, y_max, candidates in row_bands:
                if y_min <= ly <= y_max:
                    best_row_candidates = candidates
                    best_row_gap = 0.0
                    break
                if ly < y_min:
                    row_gap = y_min - ly
                else:
                    row_gap = ly - y_max
                if row_gap < best_row_gap:
                    best_row_gap = row_gap
                    best_row_candidates = candidates

            if best_row_candidates:
                best_idx: int | None = None
                best_score = float('inf')
                for idx in best_row_candidates:
                    if idx < 0 or idx >= len(centers):
                        continue
                    cx, cy = centers[idx]
                    dx = lx - float(cx)
                    dy = ly - float(cy)
                    # Row is fixed by Y-band; choose by X with light Y tie-breaker.
                    score = abs(dx) + (abs(dy) * 0.05)
                    if score < best_score:
                        best_score = score
                        best_idx = int(idx)
                if best_idx is not None:
                    return best_idx

        y_weight = max(1e-6, float(profile.local_y_metric_weight))

        best_idx = 0
        best_dist2 = float('inf')
        for idx, (cx, cy) in enumerate(centers):
            dx = lx - float(cx)
            dy = ly - float(cy)
            dist2 = (dx * dx) + (dy * dy * y_weight)
            if dist2 < best_dist2:
                best_dist2 = dist2
                best_idx = idx
        return best_idx

    return _local_xy_to_board_block_index(
        local_x,
        local_y,
        existing_broken,
        total_cols=profile.cols,
        total_rows=profile.rows,
        half_height=profile.half_height,
        half_width=profile.half_width,
        local_x_bias=profile.local_x_bias,
        local_x_gain=profile.local_x_gain,
        local_y_bias=profile.local_y_bias,
        local_y_gain=profile.local_y_gain,
        row_top_down=profile.row_top_down,
        col_mirror=effective_col_mirror,
    )


def _next_unbroken_block_index(
    existing_broken: set[int],
    total: int = BLOCKING_BOARD_BLOCK_COUNT,
) -> int:
    """Returns the index of the first plank not yet broken (sequential order)."""
    for i in range(total):
        if i not in existing_broken:
            return i
    return total - 1


def _session_collect_blocking_board_damage_packets(
    session: BattleSession | None,
    *,
    destroy_type: int,
    damage_source: tuple[float, float, float],
    preferred_board_id: int | None = None,
    hit_count: int = 1,
    target_block_indices: list[int] | None = None,
    ray_samples: list[dict] | None = None,
    _log: Callable | None = None,
) -> list[bytes]:
    if session is None:
        if _log is not None:
            _log(
                "blocking board damage skipped "
                "reason=no_session"
            )
        return []

    source = _coerce_vector3_tuple(damage_source)
    normalized_type = int(destroy_type) & 0xFF
    normalized_hits = max(1, int(hit_count))

    normalized_block_indices: list[int] = []
    seen_block_indices: set[int] = set()
    for row in (target_block_indices or []):
        block_index = _normalize_block_segment_index(row)
        if block_index is None or block_index in seen_block_indices:
            continue
        seen_block_indices.add(block_index)
        normalized_block_indices.append(block_index)

    normalized_ray_samples: list[dict] = []
    for row in (ray_samples or []):
        if not isinstance(row, dict):
            continue
        direction = _coerce_vector3_tuple(row.get('dir'), (0.0, 0.0, 1.0))
        dx, dy, dz = direction
        if (dx * dx) + (dy * dy) + (dz * dz) <= 1e-8:
            continue
        normalized_ray_samples.append(
            {
                'pos': _coerce_vector3_tuple(row.get('pos')),
                'dir': direction,
            }
        )

    board_id = 0
    hp_after = 0.0
    destroyed = False
    is_player_placed_board = False
    hit_wall_blocks: list[int] = []
    segment_source = 'explicit' if normalized_block_indices else 'none'
    destroyed_blocks_snapshot: list[int] = []
    map_targets_dbg: list[tuple[int, int]] = []
    board_selection_dbg = 'none'

    with session._lock:
        selected_board_id, board_selection_dbg = _session_select_blocking_board_id_locked(
            session,
            preferred_board_id,
            source,
            normalized_ray_samples,
        )
        if selected_board_id is None:
            if _log is not None:
                _log(
                    "blocking board damage skipped "
                    f"reason=no_target preferred={preferred_board_id} "
                    f"known={len(session.blocking_board_states)} last={session.last_blocking_board_id} "
                    f"select={board_selection_dbg}"
                )
            return []

        board_id = int(selected_board_id) & 0xFFFFFFFF
        board_profile = _session_get_blocking_board_profile_locked(session, board_id)
        board_layout_centers = _get_blocking_board_layout_centers(board_profile)
        board_block_count = max(1, _get_blocking_board_effective_count(board_profile))
        session.last_blocking_board_id = board_id
        session.blocking_board_anchor.setdefault(board_id, source)

        current_hp = max(0.0, min(1.0, float(session.blocking_board_hp.get(board_id, 1.0))))
        if current_hp <= 0.0:
            if _log is not None:
                _log(
                    "blocking board damage skipped "
                    f"reason=already_destroyed id={board_id}"
                )
            return []
        current_state = int(
            session.blocking_board_states.get(board_id, BLOCKING_BOARD_STATE_FORWARD)
        ) & 0xFF
        if current_state == BLOCKING_BOARD_STATE_DEACTIVE:
            if _log is not None:
                _log(
                    "blocking board damage skipped "
                    f"reason=inactive_state id={board_id}"
                )
            return []

        dyn = session.dynamic_walls.setdefault(
            board_id,
            {
                'state': int(
                    session.blocking_board_states.get(
                        board_id,
                        BLOCKING_BOARD_STATE_FORWARD,
                    )
                )
                & 0xFF,
                'blocks': set(),
            },
        )
        dyn_blocks = dyn.get('blocks')
        if not isinstance(dyn_blocks, set):
            dyn_blocks = set()
            dyn['blocks'] = dyn_blocks

        wall_blocks = session.broken_walls.setdefault(board_id, set())
        is_player_placed_board = board_id in session.player_placed_blocking_board_ids
        board_profile_key = _normalize_blocking_board_profile_name(_profile_name(board_profile)) or ''
        force_asset_row_bands = bool(
            is_player_placed_board
            and board_profile_key in {'door', 'narrow_door'}
            and _get_blocking_board_layout_row_bands(board_profile)
        )

        # Build stable board frame once for this request.
        _anchor = _coerce_vector3_tuple(session.blocking_board_anchor.get(board_id))
        # Anchor points in both placed and preplaced flows represent placement/base
        # transform, while segment mapping expects geometric center Y.
        _board_mid_y: float = _anchor[1] + board_profile.anchor_to_center_y

        _stored_norm = session.blocking_board_normal.get(board_id)
        _norm_src = 'cache'
        _yaw_used: float | None = None
        if _stored_norm is None:
            _yaw = session.blocking_board_yaw.get(board_id)
            if _yaw is not None and math.isfinite(float(_yaw)):
                _stored_norm = _yaw_to_horizontal_normal(float(_yaw))
                session.blocking_board_normal[board_id] = _stored_norm
                _norm_src = 'yaw'
                _yaw_used = float(_yaw)
            else:
                # Last-resort approximation from source-to-anchor vector.
                dx = source[0] - _anchor[0]
                dz = source[2] - _anchor[2]
                mag = math.sqrt(dx * dx + dz * dz)
                if mag > 1e-6:
                    _stored_norm = (dx / mag, dz / mag)
                    session.blocking_board_normal[board_id] = _stored_norm
                else:
                    _stored_norm = (0.0, 1.0)
                _norm_src = 'source'

        # Determine impacted cells (priority order):
        #   1) explicit segment indices from client (authoritative)
        #   2) geometric ray-plane intersections
        #   3) source approximation when confidence is sufficient
        #   4) deterministic sequential fallback as last resort
        candidate_indices: list[int] = []
        seen_candidates: set[int] = set()
        center_block_idx: int | None = None
        ray_dbg = ''
        source_penalty_dbg: float | None = None

        if normalized_block_indices:
            for blk in normalized_block_indices:
                if blk in seen_candidates:
                    continue
                seen_candidates.add(blk)
                candidate_indices.append(blk)
                if center_block_idx is None:
                    center_block_idx = blk
            segment_source = 'explicit'
        else:
            if normalized_ray_samples:
                for sample in normalized_ray_samples:
                    _ro = _coerce_vector3_tuple(sample.get('pos'))
                    _rd = _coerce_vector3_tuple(sample.get('dir'))
                    _local_result = _ray_board_hit_local(
                        _ro,
                        _rd,
                        _anchor,
                        board_mid_y=_board_mid_y,
                        stored_normal=_stored_norm,
                    )
                    if _local_result is None:
                        continue
                    lx, ly, used_norm, *tail = _local_result
                    hit_from_back_side = bool(tail[0]) if tail else False
                    if _norm_src == 'source':
                        # Keep existing approximation for this request; do not oscillate.
                        pass
                    elif _norm_src in {'cache', 'yaw'}:
                        pass
                    else:
                        session.blocking_board_normal[board_id] = used_norm
                        _norm_src = 'ray'

                    effective_col_mirror = board_profile.col_mirror
                    if BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE and hit_from_back_side:
                        if (board_layout_centers is None) or BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE:
                            effective_col_mirror = not effective_col_mirror

                    blk = _resolve_board_block_index_from_local(
                        lx,
                        ly,
                        wall_blocks,
                        board_profile,
                        hit_from_back_side=hit_from_back_side,
                        force_asset_row_bands=force_asset_row_bands,
                    )
                    if blk not in seen_candidates:
                        seen_candidates.add(blk)
                        candidate_indices.append(blk)
                    if center_block_idx is None:
                        center_block_idx = blk

                    map_board = (blk // board_profile.cols) + 1
                    map_seg = (blk % board_profile.cols) + 1
                    map_targets_dbg.append((map_board, map_seg))
                    if not ray_dbg:
                        ray_dbg = (
                            f"o=({_ro[0]:.2f},{_ro[1]:.2f},{_ro[2]:.2f}) "
                            f"anch=({_anchor[0]:.2f},{_anchor[1]:.2f},{_anchor[2]:.2f}) "
                            f"mid_y={_board_mid_y:.2f} norm=({_stored_norm[0]:.2f},{_stored_norm[1]:.2f}) "
                            f"nsrc={_norm_src}"
                            + f" side={'back' if hit_from_back_side else 'front'}"
                            + f" cm={1 if effective_col_mirror else 0}"
                            + (f" yaw={_yaw_used:.1f}" if _yaw_used is not None else "")
                            + f" lx={lx:.3f} ly={ly:.3f}"
                        )

            if candidate_indices:
                segment_source = 'ray_intersect'
            else:
                # ReqDestroyBlockingBoard and other no-ray paths: approximate from
                # source only if confidence is good enough; otherwise use sequential
                # fallback (if enabled).
                lx, ly = _world_point_to_board_local(source, _anchor, _board_mid_y, _stored_norm)
                source_penalty_dbg = _board_local_hit_penalty(
                    lx,
                    ly,
                    board_profile,
                    x_margin=BLOCKING_BOARD_SELECTION_SOURCE_X_MARGIN,
                    y_margin=BLOCKING_BOARD_SELECTION_SOURCE_Y_MARGIN,
                )
                source_is_confident = (
                    source_penalty_dbg <= BLOCKING_BOARD_SOURCE_APPROX_MAX_PENALTY
                )

                if source_is_confident or not BLOCKING_BOARD_SOURCE_APPROX_REQUIRE_CONFIDENCE:
                    blk = _resolve_board_block_index_from_local(
                        lx,
                        ly,
                        wall_blocks,
                        board_profile,
                        force_asset_row_bands=force_asset_row_bands,
                    )
                    center_block_idx = blk
                    candidate_indices = [blk]
                    segment_source = 'source_approx'
                    if not source_is_confident:
                        segment_source = 'source_approx_low_conf'
                    map_board = (blk // board_profile.cols) + 1
                    map_seg = (blk % board_profile.cols) + 1
                    map_targets_dbg.append((map_board, map_seg))
                elif BLOCKING_BOARD_SEQUENTIAL_FALLBACK_WITHOUT_PART_INDEX:
                    blk = _next_unbroken_block_index(
                        wall_blocks,
                        total=board_block_count,
                    )
                    center_block_idx = blk
                    candidate_indices = [blk]
                    segment_source = 'sequential_fallback'
                    map_board = (blk // board_profile.cols) + 1
                    map_seg = (blk % board_profile.cols) + 1
                    map_targets_dbg.append((map_board, map_seg))
                else:
                    blk = _resolve_board_block_index_from_local(
                        lx,
                        ly,
                        wall_blocks,
                        board_profile,
                        force_asset_row_bands=force_asset_row_bands,
                    )
                    center_block_idx = blk
                    candidate_indices = [blk]
                    segment_source = 'source_approx_forced'
                    map_board = (blk // board_profile.cols) + 1
                    map_seg = (blk % board_profile.cols) + 1
                    map_targets_dbg.append((map_board, map_seg))

        if not candidate_indices:
            blk = _next_unbroken_block_index(
                wall_blocks,
                total=board_block_count,
            )
            candidate_indices = [blk]
            if center_block_idx is None:
                center_block_idx = blk
            segment_source = f"{segment_source}:emergency_fallback"

        block_indices_to_break: list[int] = []
        if normalized_type == DESTROY_TYPE_SHOT_GUN_DAMAGE:
            cluster_center = center_block_idx if center_block_idx is not None else candidate_indices[0]
            block_indices_to_break = _clustered_new_segments_around(
                cluster_center,
                wall_blocks,
                max_new=BLOCKING_BOARD_MAX_NEW_SEGMENTS_PER_SHOTGUN,
                centers=board_layout_centers,
                total_cols=board_profile.cols,
                total_rows=board_profile.rows,
            )
            segment_source = f"{segment_source}:shotgun_cluster"
        elif _is_barricade_explosion_destroy_type(normalized_type):
            cluster_center = center_block_idx if center_block_idx is not None else candidate_indices[0]
            block_indices_to_break = _clustered_new_segments_around(
                cluster_center,
                wall_blocks,
                max_new=BLOCKING_BOARD_MAX_NEW_SEGMENTS_PER_EXPLOSION,
                centers=board_layout_centers,
                total_cols=board_profile.cols,
                total_rows=board_profile.rows,
            )
            segment_source = f"{segment_source}:explosion_cluster"
        else:
            # Single-hit model (gun/melee/hammer): exact segment or strict no-op.
            blk = candidate_indices[0]
            if blk not in wall_blocks:
                block_indices_to_break = [blk]
            else:
                block_indices_to_break = []
                segment_source = f"{segment_source}:noop_already_broken"

        for row in block_indices_to_break:
            block_index = int(row) & 0xFFFF
            if block_index in wall_blocks:
                continue
            wall_blocks.add(block_index)
            dyn_blocks.add(block_index)
            hit_wall_blocks.append(block_index)

        hit_wall_blocks = sorted(set(hit_wall_blocks))

        broken_count = len(wall_blocks)
        hp_after = max(
            0.0,
            (board_block_count - broken_count) / float(board_block_count),
        )
        session.blocking_board_hp[board_id] = hp_after

        if broken_count >= board_block_count:
            destroyed = True
            session.blocking_board_states[board_id] = BLOCKING_BOARD_STATE_DEACTIVE
            dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE

            destroyed_blocks_snapshot = sorted(int(v) & 0xFFFF for v in wall_blocks)

    packets: list[bytes] = []
    if hit_wall_blocks or destroyed:
        packets.append(build_rsp_blocking_board_state(board_id, hp_after))

    if hit_wall_blocks:
        if is_player_placed_board:
            packets.append(
                build_rsp_event_blocking_board_destroy(
                    board_id,
                    source,
                    hit_wall_blocks,
                )
            )
            packets.append(build_rsp_dynamic_block_break_state(board_id, True))
        else:
            packets.append(
                build_rsp_event_wall_block_destroy(
                    board_id,
                    _destroy_type_to_effect_type(normalized_type),
                    source,
                    hit_wall_blocks,
                )
            )
            if BLOCKING_BOARD_COMPAT_PREPLACED_CONTENT_EVENT_ENABLED:
                packets.append(
                    build_rsp_event_blocking_board_destroy(
                        board_id,
                        source,
                        hit_wall_blocks,
                    )
                )
    if destroyed:
        packets.insert(0, build_rsp_destroy_blocking_board(board_id, source))
        packets.insert(
            1,
            build_rsp_destroy_scene_object(
                normalized_type,
                source,
                [board_id],
            ),
        )
        final_content_blocks = destroyed_blocks_snapshot if destroyed_blocks_snapshot else [0]
        if (not hit_wall_blocks) or final_content_blocks != hit_wall_blocks:
            if is_player_placed_board:
                packets.append(
                    build_rsp_event_blocking_board_destroy(
                        board_id,
                        source,
                        final_content_blocks,
                    )
                )
            else:
                packets.append(
                    build_rsp_event_wall_block_destroy(
                        board_id,
                        _destroy_type_to_effect_type(normalized_type),
                        source,
                        final_content_blocks,
                    )
                )
                if BLOCKING_BOARD_COMPAT_PREPLACED_CONTENT_EVENT_ENABLED:
                    packets.append(
                        build_rsp_event_blocking_board_destroy(
                            board_id,
                            source,
                            final_content_blocks,
                        )
                    )
        if is_player_placed_board:
            packets.append(build_rsp_dynamic_block_break_state(board_id, False))
        packets.append(build_rsp_event_wall_destroy(board_id))

    if _log is not None:
        _log(
            "blocking board damage "
            f"id={board_id} profile={_profile_name(board_profile)} rows={board_profile.rows} cols={board_profile.cols} "
            f"bc={board_block_count} layout={'asset' if board_layout_centers else 'grid'} rb={1 if force_asset_row_bands else 0} "
            f"xcal=({board_profile.local_x_bias:.3f},{board_profile.local_x_gain:.3f},m={1 if board_profile.col_mirror else 0},sf={1 if BLOCKING_BOARD_COL_MIRROR_FLIP_BY_HIT_SIDE else 0},asf={1 if BLOCKING_BOARD_ASSET_COL_MIRROR_FLIP_BY_HIT_SIDE else 0}) "
            f"ycal=({board_profile.local_y_bias:.3f},{board_profile.local_y_gain:.3f},w={board_profile.local_y_metric_weight:.2f}) "
            f"hp={hp_after:.2f} hits={normalized_hits} "
            f"destroy_type={normalized_type} destroyed={1 if destroyed else 0} "
            f"player_placed={1 if is_player_placed_board else 0} "
            f"segments={len(hit_wall_blocks)} segment_src={segment_source} "
            f"blocks={hit_wall_blocks}"
            + f" select={board_selection_dbg}"
            + (
                f" src_pen={source_penalty_dbg:.3f}"
                if source_penalty_dbg is not None
                else ""
            )
            + (f" mapped={map_targets_dbg}" if map_targets_dbg else "")
            + (f" | ray: {ray_dbg}" if ray_dbg else "")
        )

    return packets


def _decode_rsp_event_wall_block_destroy_packet(
    packet: bytes,
) -> tuple[int, int, tuple[float, float, float], list[int]] | None:
    try:
        pkt_id, offset = cuint_decode(packet, 0)
    except Exception:
        return None
    if pkt_id != PKT_RSP_EVENT_WALL_BLOCK_DESTROY:
        return None
    try:
        stream = InputStream(packet, offset)
        wall_id = stream.read_cuint()
        damage_type = stream.read_u8()
        src_pos = _read_vector3(stream)
        blocks_count = stream.read_cuint()
        blocks = [stream.read_cuint() & 0xFFFF for _ in range(blocks_count)]
        return int(wall_id) & 0xFFFFFFFF, int(damage_type) & 0xFF, src_pos, blocks
    except Exception:
        return None


def _decode_rsp_event_wall_destroy_packet(packet: bytes) -> int | None:
    try:
        pkt_id, offset = cuint_decode(packet, 0)
    except Exception:
        return None
    if pkt_id != PKT_RSP_EVENT_WALL_DESTROY:
        return None
    try:
        stream = InputStream(packet, offset)
        wall_id = stream.read_cuint()
    except Exception:
        return None
    wall_id = int(wall_id) & 0xFFFFFFFF
    if wall_id <= 0:
        return None
    return wall_id


def _session_collect_structure_damage_packets(
    session: BattleSession | None,
    *,
    destroy_type: int,
    damage_source: tuple[float, float, float],
    preferred_board_id: int | None = None,
    hit_count: int = 1,
    target_block_indices: list[int] | None = None,
    ray_samples: list[dict] | None = None,
    emit_destroy_scene_object: bool = True,
    _log: Callable | None = None,
) -> list[bytes]:
    """Collect structure damage packets with wall/blockingboard channel separation.

    Strategy:
    1) Reuse existing geometric resolver to pick id/blocks.
    2) If wall packets are present, keep only wall channel and sync wall runtime stores.
    3) If no wall packets were produced, passthrough original blockingboard packets.
    """
    raw_packets = _session_collect_blocking_board_damage_packets(
        session,
        destroy_type=destroy_type,
        damage_source=damage_source,
        preferred_board_id=preferred_board_id,
        hit_count=hit_count,
        target_block_indices=target_block_indices,
        ray_samples=ray_samples,
        _log=_log,
    )
    if not raw_packets:
        return []

    wall_packets: list[bytes] = []
    wall_hits: dict[int, set[int]] = {}
    wall_destroy_ids: set[int] = set()
    for packet in raw_packets:
        try:
            pkt_id, _ = cuint_decode(packet, 0)
        except Exception:
            continue

        if pkt_id == PKT_RSP_EVENT_WALL_BLOCK_DESTROY:
            wall_packets.append(packet)
            decoded = _decode_rsp_event_wall_block_destroy_packet(packet)
            if decoded is None:
                continue
            wall_id, _damage_type, _src_pos, blocks = decoded
            if wall_id <= 0:
                continue
            bucket = wall_hits.setdefault(wall_id, set())
            for block_index in blocks:
                bucket.add(int(block_index) & 0xFFFF)
            continue

        if pkt_id == PKT_RSP_EVENT_WALL_DESTROY:
            wall_packets.append(packet)
            wall_id = _decode_rsp_event_wall_destroy_packet(packet)
            if wall_id is not None:
                wall_destroy_ids.add(wall_id)
            continue

    if not wall_packets:
        if _log is not None:
            _log(
                "structure damage route=blockingboard "
                f"destroy_type={int(destroy_type) & 0xFF} packets={len(raw_packets)} "
                "reason=no_wall_packets"
            )
        return raw_packets

    if session is not None:
        with session._lock:
            for wall_id, blocks in wall_hits.items():
                wall_blocks = session.wall_broken_blocks.setdefault(wall_id, set())
                wall_blocks.update(int(v) & 0xFFFF for v in blocks)

                dyn = session.wall_dynamic_walls.setdefault(
                    wall_id,
                    {
                        'state': BLOCKING_BOARD_STATE_FORWARD,
                        'blocks': set(),
                    },
                )
                state = int(dyn.get('state', BLOCKING_BOARD_STATE_FORWARD)) & 0xFF
                if state <= 0:
                    state = BLOCKING_BOARD_STATE_FORWARD
                dyn['state'] = state
                dyn_blocks = dyn.get('blocks')
                if not isinstance(dyn_blocks, set):
                    dyn_blocks = set()
                    dyn['blocks'] = dyn_blocks
                dyn_blocks.update(int(v) & 0xFFFF for v in blocks)

            for wall_id in wall_destroy_ids:
                dyn = session.wall_dynamic_walls.setdefault(
                    wall_id,
                    {
                        'state': BLOCKING_BOARD_STATE_DEACTIVE,
                        'blocks': set(),
                    },
                )
                dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE

    if emit_destroy_scene_object and wall_hits:
        destroy_objects: list[int] = []
        for wall_id, blocks in sorted(wall_hits.items()):
            for block_index in sorted(blocks):
                destroy_objects.append(
                    _encode_unique_id_components(
                        UNIQUE_ID_KIND_WALL,
                        wall_id,
                        int(block_index) & 0xFFFF,
                        0,
                    )
                )
        if destroy_objects:
            wall_packets.insert(
                0,
                build_rsp_destroy_scene_object(
                    int(destroy_type) & 0xFF,
                    damage_source,
                    destroy_objects,
                ),
            )

    snapshot_packets: list[bytes] = []
    if WALL_DAMAGE_PUSH_SNAPSHOT_PACKETS:
        snapshot_packets = _session_collect_wall_snapshot_packets(
            session,
            include_reinforced=False,
            _log=_log,
            reason='post_structure_damage',
        )
        if snapshot_packets:
            wall_packets.extend(snapshot_packets)

    if _log is not None:
        _log(
            "structure damage route=wall "
            f"destroy_type={int(destroy_type) & 0xFF} "
            f"wall_events={len(wall_hits)} wall_destroy={len(wall_destroy_ids)} "
            f"snapshots={len(snapshot_packets)} "
            f"packets={len(wall_packets)}/{len(raw_packets)} "
            f"preferred={int(preferred_board_id or 0)}"
        )

    return wall_packets


def _session_collect_explosive_structure_damage_packets(
    session: BattleSession | None,
    player: BattlePlayer | None,
    *,
    damage_source: tuple[float, float, float],
    _log: Callable | None = None,
) -> list[bytes]:
    if session is None or player is None:
        return []

    scene_tool_unique_id = int(
        player.guide_c4_scene_tool_unique_id
        or player.last_place_scene_tool_unique_id
        or player.last_scene_tool_unique_id
        or player.last_grenade_unique_id
        or 0
    ) & 0xFFFFFFFFFFFFFFFF

    wall_hint_id: int | None = None
    if scene_tool_unique_id > 0:
        wall_hint_id = _session_get_scene_tool_wall_hint(session, scene_tool_unique_id)
    if wall_hint_id is None:
        wall_hint_id = _normalize_board_id(getattr(player, 'last_place_target_wall_id', 0) or 0)

    if wall_hint_id is not None:
        packets = _session_collect_structure_damage_packets(
            session,
            destroy_type=DESTROY_TYPE_EXPLOSIVE_DAMAGE,
            damage_source=damage_source,
            preferred_board_id=wall_hint_id,
            hit_count=1,
            _log=_log,
        )
        if packets:
            if _log is not None:
                _log(
                    "explosive damage route=wall "
                    f"uid={scene_tool_unique_id} wall_id={wall_hint_id} "
                    f"packets={len(packets)}"
                )
            return packets

    if _log is not None:
        _log(
            "explosive damage route=blockingboard "
            f"uid={scene_tool_unique_id} wall_hint={int(wall_hint_id or 0)} reason=no_wall_hint_or_no_wall_packets"
        )
    return _session_collect_structure_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_EXPLOSIVE_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=None,
        hit_count=1,
        _log=_log,
    )


def _session_record_blocking_board_anchor(
    session: BattleSession | None,
    board_id: object,
    pose: object,
):
    if session is None:
        return
    normalized_board_id = _normalize_board_id(board_id)
    if normalized_board_id is None:
        return

    anchor: tuple[float, float, float] | None = None
    yaw_deg: float | None = None
    if isinstance(pose, dict):
        anchor = _coerce_vector3_tuple(pose.get('pos'))
        if pose.get('rot') is not None:
            rot = _coerce_vector3_tuple(pose.get('rot'))
            try:
                y = float(rot[1])
                if math.isfinite(y):
                    yaw_deg = y
            except Exception:
                yaw_deg = None

    with session._lock:
        session.last_blocking_board_id = normalized_board_id
        if anchor is not None:
            session.blocking_board_anchor[normalized_board_id] = anchor
            # Clear cached normal — board was re-placed, orientation may differ.
            session.blocking_board_normal.pop(normalized_board_id, None)
        if yaw_deg is not None:
            session.blocking_board_yaw[normalized_board_id] = yaw_deg


def _session_mark_player_placed_blocking_board(
    session: BattleSession | None,
    board_id: object,
):
    if session is None:
        return
    normalized_board_id = _normalize_board_id(board_id)
    if normalized_board_id is None:
        return

    with session._lock:
        session.player_placed_blocking_board_ids.add(normalized_board_id)
        session.blocking_board_profiles[normalized_board_id] = _session_get_blocking_board_profile_locked(
            session,
            normalized_board_id,
        )
        # New placement must start from a clean wall state, otherwise stale
        # broken blocks from a previous lifecycle make all new shots look like
        # "segments do not break".
        session.last_blocking_board_id = normalized_board_id
        session.blocking_board_states[normalized_board_id] = BLOCKING_BOARD_STATE_FORWARD
        session.blocking_board_hp[normalized_board_id] = 1.0
        session.broken_walls.pop(normalized_board_id, None)
        session.blocking_board_normal.pop(normalized_board_id, None)

        dyn = session.dynamic_walls.setdefault(
            normalized_board_id,
            {
                'state': int(
                    session.blocking_board_states.get(
                        normalized_board_id,
                        BLOCKING_BOARD_STATE_FORWARD,
                    )
                )
                & 0xFF,
                'blocks': set(),
            },
        )
        dyn['state'] = BLOCKING_BOARD_STATE_FORWARD
        dyn['blocks'] = set()


def _destroy_type_to_effect_type(destroy_type: int) -> int:
    mapping = {
        DESTROY_TYPE_GUN_DAMAGE: EFFECT_TYPE_GUN,
        DESTROY_TYPE_EXPLOSIVE_DAMAGE: EFFECT_TYPE_EXPLOSIVE,
        DESTROY_TYPE_SNIPE_GUN_DAMAGE: EFFECT_TYPE_SNIPE_GUN,
        DESTROY_TYPE_HAMMER_DAMAGE: EFFECT_TYPE_HAMMER,
        DESTROY_TYPE_MELEE_DAMAGE: EFFECT_TYPE_MELEE,
        DESTROY_TYPE_ELECTRIC_DAMAGE: EFFECT_TYPE_ELECTRIC,
        DESTROY_TYPE_THERMITE_BOMB: EFFECT_TYPE_THERMITE_BOMB,
        DESTROY_TYPE_BURN_DAMAGE: EFFECT_TYPE_BURN,
        DESTROY_TYPE_SHOT_GUN_DAMAGE: EFFECT_TYPE_SHOT_GUN,
        DESTROY_TYPE_ELEC_MAG_PULSE: EFFECT_TYPE_ELECTROMAGNETIC_DAMAGE,
    }
    return int(mapping.get(int(destroy_type), EFFECT_TYPE_NONE))


def _session_snapshot_broken_walls(session: BattleSession | None) -> list[dict]:
    if session is None:
        return []
    with session._lock:
        merged: dict[int, set[int]] = {}

        for wall_id, blocks in session.broken_walls.items():
            try:
                wid = int(wall_id) & 0xFFFFFFFF
            except Exception:
                continue
            if wid <= 0:
                continue
            bucket = merged.setdefault(wid, set())
            for block in (blocks or set()):
                try:
                    bucket.add(int(block) & 0xFFFF)
                except Exception:
                    continue

        for wall_id, blocks in session.wall_broken_blocks.items():
            try:
                wid = int(wall_id) & 0xFFFFFFFF
            except Exception:
                continue
            if wid <= 0:
                continue
            bucket = merged.setdefault(wid, set())
            for block in (blocks or set()):
                try:
                    bucket.add(int(block) & 0xFFFF)
                except Exception:
                    continue

        return [
            {
                'id': int(wall_id),
                'blocks': sorted(blocks),
            }
            for wall_id, blocks in sorted(merged.items())
            if blocks
        ]


def _session_snapshot_dynamic_walls(session: BattleSession | None) -> list[dict]:
    if session is None:
        return []
    with session._lock:
        merged: dict[int, dict[str, object]] = {}

        def _ingest(
            source: dict[int, dict[str, object]] | None,
            *,
            default_state: int,
        ) -> None:
            if not isinstance(source, dict):
                return
            for wall_id, desc in source.items():
                try:
                    wid = int(wall_id) & 0xFFFFFFFF
                except Exception:
                    continue
                if wid <= 0:
                    continue

                row = merged.get(wid)
                if row is None:
                    row = {
                        'state': int(default_state) & 0xFF,
                        'blocks': set(),
                    }
                    merged[wid] = row

                if isinstance(desc, dict):
                    try:
                        row['state'] = int(desc.get('state', row['state'])) & 0xFF
                    except Exception:
                        pass

                    row_blocks = row.get('blocks')
                    if not isinstance(row_blocks, set):
                        row_blocks = set()
                        row['blocks'] = row_blocks
                    for block in (desc.get('blocks', set()) or set()):
                        try:
                            row_blocks.add(int(block) & 0xFFFF)
                        except Exception:
                            continue

        # Base runtime for preplaced/placed barricades.
        _ingest(
            getattr(session, 'dynamic_walls', None),
            default_state=BLOCKING_BOARD_STATE_FORWARD,
        )
        # Wall-channel runtime (can override state/blocks for touched scene walls).
        _ingest(
            getattr(session, 'wall_dynamic_walls', None),
            default_state=BLOCKING_BOARD_STATE_DEACTIVE,
        )

        # Ensure ids present in blocking_board_states are represented in snapshot.
        for wall_id, state in (session.blocking_board_states or {}).items():
            try:
                wid = int(wall_id) & 0xFFFFFFFF
            except Exception:
                continue
            if wid <= 0:
                continue
            row = merged.setdefault(
                wid,
                {
                    'state': BLOCKING_BOARD_STATE_FORWARD,
                    'blocks': set(),
                },
            )
            try:
                row['state'] = int(state) & 0xFF
            except Exception:
                pass

        return [
            {
                'id': int(wall_id),
                'state': int(desc.get('state', BLOCKING_BOARD_STATE_DEACTIVE)) & 0xFF,
                'blocks': sorted(int(v) & 0xFFFF for v in (desc.get('blocks', set()) or set())),
            }
            for wall_id, desc in sorted(merged.items())
        ]


def _session_snapshot_reinforced_walls(
    session: BattleSession | None,
) -> tuple[list[dict], list[int]]:
    if session is None:
        return [], []
    walls: list[dict] = []
    with session._lock:
        for wall_id, desc in sorted(session.reinforced_walls.items()):
            partitions_map = desc.get('partitions', {}) if isinstance(desc, dict) else {}
            partitions: list[dict] = []
            if isinstance(partitions_map, dict):
                for part_id, blocks in sorted(partitions_map.items()):
                    partitions.append(
                        {
                            'id': int(part_id) & 0xFF,
                            'blocks': sorted(int(v) & 0xFF for v in (blocks or set())),
                        }
                    )
            walls.append({'id': int(wall_id), 'partitions': partitions})

        items = sorted(int(v) for v in session.reinforced_wall_items)

    return walls, items


def _session_collect_wall_snapshot_packets(
    session: BattleSession | None,
    *,
    include_reinforced: bool = False,
    _log: Callable | None = None,
    reason: str = '',
) -> list[bytes]:
    if session is None:
        return []

    broken_walls = _session_snapshot_broken_walls(session)
    dynamic_walls = _session_snapshot_dynamic_walls(session)
    packets: list[bytes] = [
        build_rsp_wall_info(broken_walls),
        build_rsp_dynamic_wall_info(dynamic_walls),
    ]

    reinforced_walls: list[dict] = []
    reinforced_items: list[int] = []
    if include_reinforced:
        reinforced_walls, reinforced_items = _session_snapshot_reinforced_walls(session)
        packets.append(build_rsp_reinforced_wall_info(reinforced_walls, reinforced_items))

    if _log is not None:
        _log(
            "wall snapshot pushed "
            f"reason={reason or 'unspecified'} "
            f"broken={len(broken_walls)} dynamic={len(dynamic_walls)} "
            f"reinforced={len(reinforced_walls)} packets={len(packets)}"
        )
    return packets


def _session_apply_reinforced_install(
    session: BattleSession,
    reinforced_id: int,
    owner_bid: int,
):
    rid = int(reinforced_id) & 0xFFFFFFFF
    with session._lock:
        session.reinforced_states[rid] = REINFORCED_STATE_ACTIVED1
        row = session.reinforced_walls.get(rid)
        if row is None:
            row = {
                'owner_bid': int(owner_bid) & 0xFF,
                'state': REINFORCED_STATE_ACTIVED1,
                'partitions': {0: set([0])},
            }
            session.reinforced_walls[rid] = row
        else:
            row['owner_bid'] = int(owner_bid) & 0xFF
            row['state'] = REINFORCED_STATE_ACTIVED1
            partitions = row.get('partitions')
            if not isinstance(partitions, dict):
                partitions = {}
                row['partitions'] = partitions
            if not partitions:
                partitions[0] = set([0])
        session.reinforced_wall_items.add(rid)


def _session_apply_reinforced_state_change(
    session: BattleSession,
    reinforced_id: int,
    state: int,
    owner_bid: int,
) -> bool:
    rid = int(reinforced_id) & 0xFFFFFFFF
    normalized_state = int(state) & 0xFF
    if normalized_state not in {
        REINFORCED_STATE_DEACTIVED,
        REINFORCED_STATE_ACTIVING1,
        REINFORCED_STATE_ACTIVING2,
        REINFORCED_STATE_ACTIVED1,
        REINFORCED_STATE_ACTIVED2,
    }:
        return False

    with session._lock:
        row = session.reinforced_walls.get(rid)
        if row is None:
            return False
        row['owner_bid'] = int(owner_bid) & 0xFF
        row['state'] = normalized_state
        session.reinforced_states[rid] = normalized_state
        if normalized_state == REINFORCED_STATE_DEACTIVED:
            row['partitions'] = {}
            session.reinforced_wall_items.discard(rid)
        else:
            partitions = row.get('partitions')
            if not isinstance(partitions, dict) or not partitions:
                row['partitions'] = {0: set([0])}
            session.reinforced_wall_items.add(rid)
    return True


def _session_collect_broken_simple_quintains_locked(session: BattleSession) -> list[int]:
    return sorted(
        int(uid) & 0xFFFFFFFF
        for uid, state in session.training_target_state.items()
        if not bool((state or {}).get('alive', True))
    )


def _session_apply_simple_quintain_destroy_locked(
    session: BattleSession,
    uid: int,
) -> bool:
    target_uid = int(uid) & 0xFFFFFFFF
    row = session.training_target_state.get(target_uid)
    if not isinstance(row, dict):
        return False
    if not bool(row.get('alive', True)):
        return False
    row['alive'] = False
    row['hp'] = 0
    row['relive_at'] = time.time() + TRAINING_TARGET_RESPAWN_SEC
    return True


def _session_collect_destroy_scene_packets(
    session: BattleSession | None,
    req: dict,
    _log: Callable,
) -> list[bytes]:
    destroy_type = int(req.get('destroy_type', DESTROY_TYPE_NONE) or DESTROY_TYPE_NONE)
    destroy_pos = req.get('destroy_pos', (0.0, 0.0, 0.0))
    destroy_objects, decoded_rows = _decode_destroy_scene_objects(req.get('destroy_objects', []))
    packets: list[bytes] = [
        build_rsp_destroy_scene_object(
            destroy_type,
            destroy_pos,
            destroy_objects,
        )
    ]

    if session is None or not destroy_objects:
        _log(
            "ReqDestroySceneObject decode "
            f"destroy_type={destroy_type} objects={len(destroy_objects)} "
            f"decoded={len(decoded_rows)} session={0 if session is None else 1}"
        )
        return packets

    decoded_details: list[str] = []
    wall_hits: dict[int, set[int]] = {}
    simple_quintain_ids: list[int] = []
    seen_simple_quintain_ids: set[int] = set()
    unknown_rows: list[dict[str, int]] = []
    invalid_rows = 0
    for row in decoded_rows:
        kind = int(row.get('kind', 0)) & 0xFFFF
        local_id = int(row.get('local_id', 0)) & 0xFFFFFFFF
        index1 = int(row.get('index1', 0)) & 0xFFFF
        index2 = int(row.get('index2', 0)) & 0xFFFF
        raw_value = int(row.get('raw', 0)) & 0xFFFFFFFFFFFFFFFF
        route = 'unknown'
        if local_id <= 0:
            invalid_rows += 1
            route = 'invalid_local_id'
        elif kind == UNIQUE_ID_KIND_WALL:
            route = 'wall'
            wall_hits.setdefault(local_id, set()).add(index1)
        elif kind in TRAINING_TARGET_DESTROY_UID_KINDS:
            route = 'simple_quintain'
            if local_id not in seen_simple_quintain_ids:
                seen_simple_quintain_ids.add(local_id)
                simple_quintain_ids.append(local_id)
        else:
            unknown_rows.append(row)
        decoded_details.append(
            f"0x{raw_value:016X}:k={kind}/id={local_id}/i1={index1}/i2={index2}/r={route}"
        )

    effect_type = _destroy_type_to_effect_type(destroy_type)
    with session._lock:
        wall_events = 0
        simple_events = 0
        for wall_id, requested_blocks in sorted(wall_hits.items()):
            if wall_id <= 0:
                continue
            wall_blocks = session.wall_broken_blocks.setdefault(wall_id, set())
            changed_blocks = sorted(
                int(block_index) & 0xFFFF
                for block_index in requested_blocks
                if (int(block_index) & 0xFFFF) not in wall_blocks
            )
            if not changed_blocks:
                continue
            wall_blocks.update(changed_blocks)
            dyn = session.wall_dynamic_walls.setdefault(
                wall_id,
                {
                    'state': BLOCKING_BOARD_STATE_DEACTIVE,
                    'blocks': set(),
                },
            )
            dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
            dyn_blocks = dyn.get('blocks')
            if not isinstance(dyn_blocks, set):
                dyn_blocks = set()
                dyn['blocks'] = dyn_blocks
            for block_index in changed_blocks:
                dyn_blocks.add(int(block_index) & 0xFFFF)

            packets.append(
                build_rsp_event_wall_block_destroy(
                    wall_id,
                    effect_type,
                    destroy_pos,
                    changed_blocks,
                )
            )
            wall_events += 1

        simple_quintains_changed = False
        for uid in simple_quintain_ids:
            if not _session_apply_simple_quintain_destroy_locked(session, uid):
                continue
            simple_quintains_changed = True
            simple_events += 1
            state = session.training_target_state.get(int(uid) & 0xFFFFFFFF)
            destroy_uid = int(uid) & 0xFFFFFFFFFFFFFFFF
            if _is_training_target_model_state(uid, state):
                resolved_uid = _resolve_training_target_entity_uid(uid, state)
                if resolved_uid > 0:
                    destroy_uid = int(resolved_uid) & 0xFFFFFFFFFFFFFFFF
            packets.append(
                build_rsp_target_model_destroy(
                    destroy_uid,
                    damage_source=destroy_pos,
                )
            )
        if simple_quintains_changed:
            packets.append(
                build_rsp_simple_quintain_info(
                    _session_collect_broken_simple_quintains_locked(session)
                )
            )

    _log(
        "ReqDestroySceneObject decode "
        f"destroy_type={destroy_type} effect_type={effect_type} "
        f"objects={len(destroy_objects)} decoded={len(decoded_rows)} "
        f"walls={len(wall_hits)} simple={len(simple_quintain_ids)} "
        f"unknown={len(unknown_rows)} invalid={invalid_rows}"
    )
    if decoded_details:
        _log(
            "ReqDestroySceneObject objects "
            + " | ".join(decoded_details)
        )
    _log(
        "ReqDestroySceneObject state-update "
        f"wall_events={wall_events} simple_events={simple_events} packets={len(packets)}"
    )
    return packets


def _session_collect_training_target_create_packets(
    session: BattleSession | None,
    *,
    force: bool = False,
) -> list[bytes]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return []

    rows: list[tuple[int, int, int, dict]] = []
    with session._lock:
        already_created = bool(getattr(session, 'training_target_entities_created', False))
        if already_created and not force:
            return []

        for raw_local_id, state in session.training_target_state.items():
            try:
                local_id = int(raw_local_id) & 0xFFFFFFFF
            except Exception:
                continue
            if local_id <= 0 or not _is_training_target_model_state(local_id, state):
                continue

            entity_uid = _resolve_training_target_entity_uid(local_id, state)
            if entity_uid <= 0:
                continue

            content_config_id = _resolve_training_target_content_config_id(local_id, state)
            transform = _resolve_training_target_transform_euler(local_id, state)
            rows.append((local_id, entity_uid, content_config_id, transform))

            if isinstance(state, dict):
                state['entity_uid'] = int(entity_uid) & 0xFFFFFFFFFFFFFFFF
                state['content_config_id'] = int(content_config_id) & 0xFFFFFFFF

        if not rows:
            return []
        session.training_target_entities_created = True

    return [
        build_rsp_create_entity(entity_uid, content_config_id, transform)
        for _, entity_uid, content_config_id, transform in rows
    ]


def _session_collect_training_target_snapshot_packets(
    session: BattleSession | None,
) -> list[bytes]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return []

    broken_simple_quintains: list[int] = []
    running_targets: list[tuple[int, tuple[float, float, float]]] = []
    with session._lock:
        for uid, state in session.training_target_state.items():
            if bool(state.get('alive', True)):
                local_id = int(uid) & 0xFFFFFFFF
                if _is_training_target_model_state(local_id, state):
                    entity_uid = _resolve_training_target_entity_uid(local_id, state)
                    if entity_uid <= 0:
                        continue
                    pos = state.get('position', (0.0, 0.0, 0.0))
                    running_targets.append(
                        (
                            int(entity_uid) & 0xFFFFFFFFFFFFFFFF,
                            (
                                float(pos[0]),
                                float(pos[1]),
                                float(pos[2]),
                            ),
                        )
                    )
            else:
                broken_simple_quintains.append(int(uid) & 0xFFFFFFFF)

    packets: list[bytes] = [
        build_rsp_simple_quintain_info(broken_simple_quintains),
    ]
    for entity_uid, pos in running_targets:
        packets.append(
            build_rsp_target_model_start_run(
                uid=entity_uid,
                duration=TRAINING_TARGET_RUN_DURATION_SEC,
                target_position=pos,
            )
        )
    return packets


def _session_collect_training_target_scene_items(
    session: BattleSession | None,
) -> list[dict]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return []

    items: list[dict] = []
    with session._lock:
        for raw_local_id, state in session.training_target_state.items():
            try:
                local_id = int(raw_local_id) & 0xFFFFFFFF
            except Exception:
                continue
            if local_id <= 0:
                continue

            uid = _resolve_training_target_entity_uid(local_id, state)
            if uid <= 0:
                continue

            pos = _coerce_vector3_tuple(state.get('position'))
            items.append(
                {
                    'uid': uid,
                    'transform': {
                        'rotation': (0.0, 0.0, 0.0, 1.0),
                        'position': (
                            float(pos[0]),
                            float(pos[1]),
                            float(pos[2]),
                        ),
                    },
                }
            )
    return items


def _session_collect_training_target_relive_packets(
    session: BattleSession | None,
) -> list[bytes]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return []

    now_ts = time.time()
    relived_targets: list[tuple[int, tuple[float, float, float], bool]] = []
    broken_simple_quintains: list[int] = []
    with session._lock:
        for uid, state in session.training_target_state.items():
            alive = bool(state.get('alive', True))
            relive_at = float(state.get('relive_at', 0.0) or 0.0)
            if (not alive) and relive_at > 0.0 and now_ts >= relive_at:
                state['alive'] = True
                state['hp'] = _training_target_initial_hp(state)
                state['relive_at'] = 0.0
                pos = state.get('position', (0.0, 0.0, 0.0))
                local_id = int(uid) & 0xFFFFFFFF
                entity_uid = _resolve_training_target_entity_uid(local_id, state)
                relived_targets.append(
                    (
                        int(entity_uid) & 0xFFFFFFFFFFFFFFFF,
                        (
                            float(pos[0]),
                            float(pos[1]),
                            float(pos[2]),
                        ),
                        _is_training_target_model_state(local_id, state),
                    )
                )
                alive = True
            if not alive:
                broken_simple_quintains.append(int(uid) & 0xFFFFFFFF)

    if not relived_targets:
        return []

    packets: list[bytes] = []
    for entity_uid, pos, is_target_model in relived_targets:
        if not is_target_model or entity_uid <= 0:
            continue
        packets.append(build_rsp_target_model_relive(entity_uid))
        packets.append(
            build_rsp_target_model_start_run(
                uid=entity_uid,
                duration=TRAINING_TARGET_RUN_DURATION_SEC,
                target_position=pos,
            )
        )
    packets.append(build_rsp_simple_quintain_info(broken_simple_quintains))
    return packets


def _push_training_target_snapshot_packets(
    session: BattleSession | None,
    sock: socket.socket,
    *,
    _log: Callable,
    reason: str,
    include_scene_items: bool = False,
) -> int:
    packets: list[bytes] = []
    scene_items_debug = ""
    packets.extend(_session_collect_training_target_create_packets(session))
    if include_scene_items:
        scene_items = _session_collect_training_target_scene_items(session)
        if scene_items:
            packets.append(build_rsp_simple_scene_item_info(scene_items))
            preview_rows: list[str] = []
            for item in scene_items[:4]:
                decoded = _decode_unique_id_components(item.get('uid', 0))
                if decoded is None:
                    continue
                preview_rows.append(f"k={decoded[0]}/id={decoded[1]}")
            if preview_rows:
                scene_items_debug = (
                    f" scene_items={len(scene_items)} "
                    f"scene_uid_preview={'|'.join(preview_rows)}"
                )
            else:
                scene_items_debug = f" scene_items={len(scene_items)}"
    packets.extend(_session_collect_training_target_relive_packets(session))
    packets.extend(_session_collect_training_target_snapshot_packets(session))
    if not packets:
        return 0
    _session_send_packets(session, sock, packets)
    _log(
        "training-target snapshot push "
        f"reason={reason} packets={len(packets)}{scene_items_debug}"
    )
    return len(packets)


def _session_destroy_first_training_target_packets(
    session: BattleSession | None,
    damage_source: tuple[float, float, float] | None = None,
) -> list[bytes]:
    if session is None or not _is_training_mode_game_state(session.game_state):
        return []

    destroyed_uid: int | None = None
    destroyed_entity_uid: int = 0
    destroyed_is_target_model = False
    broken_simple_quintains: list[int] = []
    with session._lock:
        for uid, state in session.training_target_state.items():
            if bool(state.get('alive', True)):
                state['alive'] = False
                state['hp'] = 0
                state['relive_at'] = time.time() + TRAINING_TARGET_RESPAWN_SEC
                destroyed_uid = int(uid)
                destroyed_entity_uid = _resolve_training_target_entity_uid(
                    int(uid) & 0xFFFFFFFF,
                    state,
                )
                destroyed_is_target_model = _is_training_target_model_state(
                    int(uid) & 0xFFFFFFFF,
                    state,
                )
                break
        for uid, state in session.training_target_state.items():
            if not bool(state.get('alive', True)):
                broken_simple_quintains.append(int(uid) & 0xFFFFFFFF)

    if destroyed_uid is None:
        return []

    packets: list[bytes] = []
    if destroyed_is_target_model and destroyed_entity_uid > 0:
        packets.append(
            build_rsp_target_model_destroy(
                destroyed_entity_uid,
                damage_source=damage_source,
            )
        )
    packets.append(build_rsp_simple_quintain_info(broken_simple_quintains))
    return packets


def _handle_req_game_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
):
    parse_req_game_info(stream)

    active_battle_id = _resolve_active_battle_id(session, battle_id, game_state)
    game_stage = _resolve_game_stage(session, player)
    _log(
        f"ReqGameInfo from {peer} "
        f"battle_id={active_battle_id} game_stage={game_stage}"
    )

    # Client recover path expects battle-id resync before gameplay stage data.
    sock.sendall(build_rsp_battle_id(active_battle_id))
    sock.sendall(build_rsp_game_info(active_battle_id, game_stage))

    # Recover hardening:
    # - on loading stage, repeat load-success if the client is already near ready,
    # - on active battle stage, push training snapshot to help fast state reattach.
    if player is not None and game_stage == GAME_STAGE_LOADING:
        if player.loaded or float(player.progress) >= 0.90:
            if session is not None:
                session._send_load_success_once(player)
            else:
                sock.sendall(build_rsp_battle_load_success(player.bid))
                _log(f"recover: sent RspBattleLoadSuccess bid={player.bid} to {peer}")

    if game_stage == GAME_STAGE_BATTLE:
        stage_ts, stage_total, stage_remain = _resolve_stage_sync_payload(
            session=session,
            game_state=session.game_state if session is not None else game_state,
            game_stage=GAME_STAGE_BATTLE,
        )
        stage_pkt = build_rsp_game_stage(
            timestamp=stage_ts,
            game_stage=GAME_STAGE_BATTLE,
            total_time=stage_total,
            remain_time=stage_remain,
        )
        sock.sendall(stage_pkt)
        _log(
            "recover: sent RspGameStage "
            f"stage={GAME_STAGE_BATTLE} total={stage_total} remain={stage_remain} to {peer}"
        )

        state_source = session.game_state if session is not None else game_state
        critical_state = CRITICAL_REGION_STATE_ONLY_DEFENDERS
        if _is_training_mode_game_state(state_source):
            critical_state = _critical_region_state_for_player_camp(
                player.camp if player is not None else state_source.get('camp', BATTLE_CAMP_ATTACKER)
            )
        sock.sendall(build_rsp_critical_region_state(critical_state))
        _guide_set_critical_region_state(session, critical_state)
        _log(
            "recover: sent RspCriticalRegionState "
            f"state={critical_state} camp={getattr(player, 'camp', None)} to {peer}"
        )

        packets: list[bytes] = []
        packets.extend(_session_collect_training_target_create_packets(session))
        packets.extend(_session_collect_training_target_relive_packets(session))
        packets.extend(_session_collect_training_target_snapshot_packets(session))
        if WALL_RECOVER_PUSH_SNAPSHOT_PACKETS:
            packets.extend(
                _session_collect_wall_snapshot_packets(
                    session,
                    include_reinforced=True,
                    _log=_log,
                    reason='battle_recover',
                )
            )
        if packets:
            if player is not None:
                for pkt in packets:
                    player.send_raw(pkt)
            else:
                _session_send_packets(session, sock, packets)
            _log(
                f"recover: pushed battle snapshot packets={len(packets)} "
                f"to {peer} stage={game_stage}"
            )


def _handle_req_leave_battle(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    _log: Callable,
    session: BattleSession | None = None,
    player: BattlePlayer | None = None,
):
    def _reset_training_session_for_reload(
        target_session: BattleSession,
        *,
        leave_kind_value: int,
    ) -> None:
        if not _is_training_mode_game_state(target_session.game_state):
            return

        full_restart_selection_reset = leave_kind_value == LEAVE_BATTLE_KIND_RESTART_MODE
        try:
            map_id = int(target_session.game_state.get('map_id', 0) or 0)
        except Exception:
            map_id = 0
        seeded_training_targets = 0
        with target_session._lock:
            target_session._started = False
            target_session._battle_stage_started_at = None
            target_session.room_loading_critical_region_id = None
            target_session.last_blocking_board_id = None
            target_session.player_placed_blocking_board_ids.clear()
            target_session.blocking_board_states.clear()
            target_session.blocking_board_hp.clear()
            target_session.blocking_board_anchor.clear()
            target_session.blocking_board_profiles.clear()
            target_session.blocking_board_yaw.clear()
            target_session.blocking_board_normal.clear()
            target_session.dynamic_walls.clear()
            target_session.broken_walls.clear()
            target_session.wall_dynamic_walls.clear()
            target_session.wall_broken_blocks.clear()
            target_session.reinforced_walls.clear()
            target_session.reinforced_wall_items.clear()
            target_session.scene_tool_board_hint.clear()
            target_session.scene_tool_wall_hint.clear()
            target_session.ended_scene_tool_unique_ids.clear()

            for p in target_session.players.values():
                p.loaded = False
                p.progress = 0.0
                p._load_success_sent = False
                p._spawn_probe_logged = False
                p._preserve_on_disconnect = False

            target_session.training_target_state = _build_default_training_target_state()
            target_session.training_target_entities_created = False
            seeded_training_targets = _session_seed_training_targets_from_manifest(
                target_session,
                map_id,
            )

            if full_restart_selection_reset and isinstance(target_session.game_state, dict):
                # Client text for "Reset map" explicitly says selection stays unchanged.
                # "Restart" resets selection state but keeps current side/camp.
                try:
                    current_camp = int(target_session.game_state.get('camp', BATTLE_CAMP_ATTACKER) or BATTLE_CAMP_ATTACKER)
                except Exception:
                    current_camp = BATTLE_CAMP_ATTACKER
                if current_camp not in (BATTLE_CAMP_ATTACKER, BATTLE_CAMP_DEFENDER):
                    current_camp = BATTLE_CAMP_ATTACKER
                default_region = _default_training_spawn_region_for_camp(current_camp)
                target_session.game_state['camp'] = current_camp
                target_session.game_state['team'] = 1 if current_camp == BATTLE_CAMP_ATTACKER else 2
                target_session.game_state['region_id'] = default_region
                target_session.game_state['spawn_region_id'] = default_region
                for key in (
                    'character_id',
                    'primary_weapon',
                    'secondary_weapon',
                    'main_skill_id',
                    'sub_skill_id',
                ):
                    target_session.game_state.pop(key, None)

            if _should_seed_blocking_boards(target_session.game_state):
                seeded_from_manifest = _session_seed_training_blocking_boards_from_manifest(
                    target_session,
                    map_id,
                )
                if seeded_from_manifest > 0:
                    _log(
                        "training reset: seeded blocking boards "
                        f"from manifest count={seeded_from_manifest} "
                        f"state={BLOCKING_BOARD_SEEDED_DEFAULT_STATE} "
                        f"active={1 if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE else 0}"
                    )
                elif map_id == 1:
                    for board_id in TRAINING_DEFAULT_BLOCKING_BOARD_IDS:
                        normalized_board_id = int(board_id) & 0xFFFFFFFF
                        target_session.blocking_board_states[normalized_board_id] = (
                            BLOCKING_BOARD_SEEDED_DEFAULT_STATE
                        )
                        target_session.blocking_board_hp[normalized_board_id] = (
                            BLOCKING_BOARD_SEEDED_DEFAULT_HP
                        )
                        target_session.dynamic_walls.setdefault(
                            normalized_board_id,
                            {
                                'state': BLOCKING_BOARD_SEEDED_DEFAULT_STATE,
                                'blocks': set(),
                            },
                        )
                        anchor = TRAINING_DEFAULT_BLOCKING_BOARD_ANCHORS.get(
                            normalized_board_id
                        )
                        if anchor is not None:
                            target_session.blocking_board_anchor[normalized_board_id] = (
                                float(anchor[0]),
                                float(anchor[1]),
                                float(anchor[2]),
                            )
                    _log(
                        "training reset: seeded blocking boards "
                        f"from hardcoded map_id=1 count={len(TRAINING_DEFAULT_BLOCKING_BOARD_IDS)} "
                        f"state={BLOCKING_BOARD_SEEDED_DEFAULT_STATE} "
                        f"active={1 if BLOCKING_BOARD_SEEDED_DEFAULT_ACTIVE else 0}"
                    )

        if seeded_training_targets > 0:
            _log(
                "training reset: seeded training targets "
                f"from manifest map_id={map_id} count={seeded_training_targets}"
            )
        _log(
            "training reset: session state cleared "
            f"leave_kind={leave_kind_value}"
        )
        if full_restart_selection_reset:
            gs_log = target_session.game_state if isinstance(target_session.game_state, dict) else {}
            _log(
                "training reset: restart-mode selection reset "
                f"camp={gs_log.get('camp')} "
                f"region={gs_log.get('region_id')} "
                f"spawn_region={gs_log.get('spawn_region_id')} "
                "loadout=default"
            )

    req = parse_req_leave_battle(stream)
    leave_kind = int(req['leave_kind'])
    reason = _map_leave_kind_to_battle_over_reason(leave_kind)
    win_camp, replay_bid, winners_rank = _derive_leave_result_payload(
        reason,
        session,
        player,
    )
    _log(
        f"ReqLeaveBattle leave_kind={leave_kind} "
        f"battle_over_reason={reason} from {peer}"
    )

    # Training mode operations (RESTART_MODE=1, RELOAD_MAP=2) keep battle session object alive.
    # - RELOAD_MAP: immediate room-loading reload (keep current selection).
    # - RESTART_MODE: return to pre-battle selection flow (agent/loadout/side/spawn).
    # Only TO_HALL (0) tears down the session.
    is_training_operation = (
        leave_kind in (LEAVE_BATTLE_KIND_RESTART_MODE, LEAVE_BATTLE_KIND_RELOAD_MAP)
        and session is not None
        and _is_training_mode_game_state(session.game_state)
    )
    is_training_restart_mode = is_training_operation and leave_kind == LEAVE_BATTLE_KIND_RESTART_MODE
    is_training_reload_map = is_training_operation and leave_kind == LEAVE_BATTLE_KIND_RELOAD_MAP

    sock.sendall(build_rsp_battle_over(reason))
    if is_training_operation:
        _log(f"sent RspBattleOver reason={reason} training_reload=1 to {peer}")
    else:
        sock.sendall(
            build_rsp_battle_result(
                reason,
                win_camp=win_camp,
                replay_bid=replay_bid,
                winners_rank=winners_rank,
            )
        )
        _log(
            f"sent RspBattleOver+RspBattleResult reason={reason} "
            f"win_camp={win_camp} replay_bid={replay_bid} "
            f"winners={len(winners_rank)} to {peer}"
        )

    if is_training_operation:
        _log(f"Training mode operation (leave_kind={leave_kind}), keeping session alive")
        _reset_training_session_for_reload(session, leave_kind_value=leave_kind)
        if player is not None:
            player._preserve_on_disconnect = True

        if is_training_reload_map and session is not None and player is not None:
            # "Reset map": direct battle reload path while preserving selection.
            try:
                reload_pkt = session.build_room_loading(player)
                sock.sendall(reload_pkt)
                _log(f"sent RspRoomLoading for map reload to {peer}")
            except Exception as exc:
                _log(f"failed to send RspRoomLoading: {exc}")
        elif is_training_restart_mode:
            # "Restart": push client back to lobby pre-battle handshake so
            # agent/loadout/side/spawn can be selected again.
            try:
                gs = session.game_state if session is not None else None
                if isinstance(gs, dict):
                    gs['in_battle'] = False
                    gs['_confirm_sent'] = False
                    gs['_confirm_pending'] = False
                    gs['_last_confirm_push_ts'] = 0.0
                    gs['prebattle_room_started'] = False
                    gs['prebattle_flow_active'] = False
                    gs['prebattle_stage'] = 1
                    # Lobby TCP stub must proactively bootstrap prebattle UI
                    # after restart; client can stay in loading if we only wait
                    # for ReqRoomStart from client side.
                    gs['_restart_prebattle_bootstrap_pending'] = True
            except Exception as exc:
                _log(f"restart-mode prebattle flag reset failed: {exc}")

            _log(
                "restart-mode: battle socket will be closed; lobby will bootstrap "
                "pre-battle selection on next client_hello"
            )
            try:
                sock.shutdown(socket.SHUT_RDWR)
            except OSError:
                pass
            try:
                sock.close()
            except OSError:
                pass
    else:
        # Only tear down session for TO_HALL (leave_kind=0)
        if session is not None and player is not None:
            try:
                session.remove_player(player.bid)
                _log(
                    f"leave teardown: removed bid={player.bid} "
                    f"from session {session.battle_id}"
                )
            except Exception as exc:
                _log(f"leave teardown: remove_player failed bid={player.bid}: {exc}")
            with session._lock:
                session_empty = len(session.players) == 0
            if session_empty:
                remove_session(session.battle_id)
                _log(f"leave teardown: removed empty session {session.battle_id}")

        # LeaveBattleInBattle should teardown current battle link after response.
        try:
            sock.shutdown(socket.SHUT_RDWR)
        except OSError:
            pass
        try:
            sock.close()
        except OSError:
            pass


def _handle_req_players_result(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    _log: Callable,
):
    parse_req_players_result(stream)
    _log(f"ReqPlayersResult from {peer}")
    sock.sendall(build_rsp_players_result_empty())
    _log(f"sent RspPlayersResultEmpty to {peer}")


def _maybe_log_spawn_probe(
    *,
    session: BattleSession | None,
    player: BattlePlayer | None,
    req_state: dict,
    _log: Callable,
):
    """
    Log first absolute pose reported by client after spawn.
    This helps calibrate map/camp/region spawn transform mappings.
    """
    if player is None:
        return
    if getattr(player, "_spawn_probe_logged", False):
        return
    if not isinstance(req_state, dict):
        return
    pose = req_state.get("pose")
    if not isinstance(pose, dict):
        return
    pos = pose.get("pos")
    rot = pose.get("rot")
    if not (isinstance(pos, (tuple, list)) and len(pos) == 3):
        return
    if not (isinstance(rot, (tuple, list)) and len(rot) == 3):
        rot = (0.0, 0.0, 0.0)

    player._spawn_probe_logged = True
    gs = session.game_state if session is not None else {}
    map_id = int(gs.get("map_id", 0) or 0) if isinstance(gs, dict) else 0
    mode_id = int(gs.get("mode_id", 0) or 0) if isinstance(gs, dict) else 0
    region_id = gs.get("region_id") if isinstance(gs, dict) else None
    camp = player.camp
    if not camp and isinstance(gs, dict):
        camp = int(gs.get("camp", 0) or 0)
    _log(
        "spawn_probe first_character_state "
        f"map_id={map_id} mode_id={mode_id} camp={int(camp)} region_id={region_id} "
        f"pos=({float(pos[0]):.2f},{float(pos[1]):.2f},{float(pos[2]):.2f}) "
        f"rot=({float(rot[0]):.2f},{float(rot[1]):.2f},{float(rot[2]):.2f})"
    )


def _v2_handle_req_ping_or_pose(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, player_data

    in_gameplay_phase = bool(session and session._started)
    req_0x01_variant = _select_req_0x01_variant(stream, in_gameplay_phase)
    if req_0x01_variant == 'pose':
        req = parse_req_character_pose(stream)
        if player:
            rsp = build_rsp_character_pose(player.bid, req['delta'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)
            _guide_try_push_only_attackers_state(
                session,
                sock,
                _log=_log,
                reason="post_explosive_followup_pose",
            )
        return session, player

    req = parse_req_ping(stream)
    _log(f"ReqPing ts={req['timestamp']} from {peer}")
    sock.sendall(build_rsp_ping(req['timestamp']))
    return session, player


def _v2_handle_req_enter_battle(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, session, player

    req = parse_req_enter_battle(stream)
    _log(
        f"ReqEnterBattle uid={req['uid']} battle_id={req['battle_id']} "
        f"token={req['token'][:32]} from {peer}"
    )

    try:
        game_state['in_battle'] = True
    except Exception:
        pass

    req_battle_id = int(req['battle_id'])
    session = get_or_create_session(req_battle_id, game_state, player_data, _log)
    player = session.try_rebind_player_by_uid(req['uid'], sock, (peer, 0))
    rebind = player is not None
    if player is None:
        player = session.add_player(sock, (peer, 0))
    player.uid = req['uid']

    p_room_entry = None
    try:
        r_state = _get_live_room_state()
        if isinstance(r_state, dict) and isinstance(r_state.get("players"), dict):
            p_room_entry = r_state["players"].get(str(req['uid']))
    except Exception:
        pass

    if isinstance(p_room_entry, dict):
        p_camp = int(p_room_entry.get("camp", 1) or 1)
        player.camp = p_camp
        player.team = 2 if p_camp == 2 else 1
        player.name = str(p_room_entry.get("name") or f"Player{player.uid}")
        p_cid = int(p_room_entry.get("character_id", 0) or 0)
        if p_cid > 0:
            player.character_id = p_cid
        if p_room_entry.get("primary_weapon"):
            player.primary_weapon = p_room_entry.get("primary_weapon")
        if p_room_entry.get("secondary_weapon"):
            player.secondary_weapon = p_room_entry.get("secondary_weapon")
        if p_room_entry.get("main_skill_id"):
            player.main_skill_id = p_room_entry.get("main_skill_id")
        if p_room_entry.get("sub_skill_id"):
            player.sub_skill_id = p_room_entry.get("sub_skill_id")
        if p_room_entry.get("region_id"):
            player.born_region_id = p_room_entry.get("region_id")
    else:
        p_camp = int(game_state.get('camp', 1) or 1)
        player.camp = p_camp
        player.team = 2 if p_camp == 2 else 1
        player.name = player_data.get('name', f"Player{player.uid}")
        p_cid = int(game_state.get('character_id', 0) or 0)
        if p_cid > 0:
            player.character_id = p_cid
        if game_state.get("primary_weapon"):
            player.primary_weapon = game_state.get("primary_weapon")
        if game_state.get("secondary_weapon"):
            player.secondary_weapon = game_state.get("secondary_weapon")
        if game_state.get("main_skill_id"):
            player.main_skill_id = game_state.get("main_skill_id")
        if game_state.get("sub_skill_id"):
            player.sub_skill_id = game_state.get("sub_skill_id")
        if game_state.get("region_id") is not None:
            player.born_region_id = game_state.get("region_id")

    ci = req.get('client_info', {})
    _log(
        "ReqEnterBattle client_info "
        f"account_id={ci.get('account_id', '')} server_id={ci.get('server_id', '')} "
        f"chuid={ci.get('chuid', '')} running_id={ci.get('running_id', 0)}"
    )

    if rebind:
        _log(f"player bid={player.bid} uid={player.uid} rebound session {req_battle_id}")
    else:
        _log(f"player bid={player.bid} uid={player.uid} joined session {req_battle_id}")

    sock.sendall(build_rsp_battle_id(req_battle_id))
    _log(f"sent RspBattleId battle_id={req_battle_id} to {peer}")

    room_loading = session.build_room_loading(player)
    sock.sendall(room_loading)
    _log(
        f"room_loading invariants: bid={player.bid} uid={player.uid} "
        f"team={player.team} camp={player.camp} "
        f"region_id={game_state.get('region_id', 999)}"
    )
    _log(f"sent RspRoomLoading ({len(room_loading)}B) hex={room_loading.hex()} to {peer}")

    return session, player


def _v2_handle_req_load_progress(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_load_progress(stream)
    _log(f"ReqLoadProgress progress={req['progress']:.2f} from {peer}")

    if player:
        player.progress = req['progress']
        rsp = build_rsp_load_progress(player.bid, req['progress'])
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

        if req['progress'] >= 0.90:
            success_pkt = build_rsp_battle_load_success(player.bid)
            if session:
                session.broadcast(success_pkt)
                _log(f"resent RspBattleLoadSuccess bid={player.bid} to all players")
            else:
                sock.sendall(success_pkt)
                _log(f"sent RspBattleLoadSuccess bid={player.bid} to {peer}")

    return session, player


def _v2_handle_req_room_loaded(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_room_loaded(stream)

    _log(f"ReqRoomLoaded from {peer}")

    if player:
        player.loaded = True

    if session and player:
        session._send_load_success_once(player)

    should_start_now = False
    if session:
        if _is_training_mode_game_state(session.game_state):
            if player and player.loaded:
                _log("training mode: local player loaded, starting battle immediately")
                should_start_now = True
        elif session.all_loaded():
            _log("all players loaded, starting battle!")
            should_start_now = True

    if should_start_now and session:
        session._send_game_start_once()
        if _is_training_mode_game_state(session.game_state):
            _push_training_target_snapshot_packets(
                session,
                sock,
                _log=_log,
                reason='room_loaded_start_v2',
                include_scene_items=False,
            )
    elif player and not session:
        success_pkt = build_rsp_battle_load_success(player.bid)
        sock.sendall(success_pkt)
        _log(f"sent RspBattleLoadSuccess bid={player.bid} to {peer}")

        ts = int(time.time())
        start_pkt = build_rsp_game_start(ts)
        sock.sendall(start_pkt)
        _log(f"sent RspGameStart ts={ts} to {peer}")
        stage_ts, stage_total, stage_remain = _resolve_stage_sync_payload(
            session=None,
            game_state=game_state,
            game_stage=GAME_STAGE_BATTLE,
        )
        stage_pkt = build_rsp_game_stage(
            timestamp=stage_ts,
            game_stage=GAME_STAGE_BATTLE,
            total_time=stage_total,
            remain_time=stage_remain,
        )
        sock.sendall(stage_pkt)
        _log(
            "sent RspGameStage "
            f"stage={GAME_STAGE_BATTLE} total={stage_total} remain={stage_remain} to {peer}"
        )

        critical_state = CRITICAL_REGION_STATE_ONLY_DEFENDERS
        if _is_training_mode_game_state(game_state):
            critical_state = _critical_region_state_for_player_camp(game_state.get('camp', BATTLE_CAMP_ATTACKER))
        critical_pkt = build_rsp_critical_region_state(critical_state)
        sock.sendall(critical_pkt)
        _guide_set_critical_region_state(session, critical_state)
        _log(
            "sent RspCriticalRegionState "
            f"state={critical_state} camp={game_state.get('camp')} to {peer}"
        )

    return session, player


def _v2_handle_pkt_heartbeat(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del stream, battle_id, game_state, player_data

    if player:
        player._hb_recv_count += 1

    # Client vn.TSPacketLink heartbeat watchdog expects inbound traffic.
    # Echo heartbeat to keep receive-side timeout fresh during quiet gameplay.
    echoed = _send_heartbeat_echo(sock)
    if echoed and player:
        player._hb_echo_count += 1
        if player._hb_echo_count in (1, 10, 30) or (player._hb_echo_count % 120) == 0:
            _log(
                f"heartbeat-echo peer={peer} "
                f"recv={player._hb_recv_count} sent={player._hb_echo_count}"
            )

    if (
        BATTLE_HEARTBEAT_STAGE_KEEPALIVE
        and session is not None
        and player is not None
        and bool(session._started)
        and player._hb_recv_count > 0
        and (player._hb_recv_count % BATTLE_HEARTBEAT_STAGE_KEEPALIVE_EVERY) == 0
    ):
        try:
            stage_ts, stage_total, stage_remain = _resolve_stage_sync_payload(
                session=session,
                game_state=session.game_state,
                game_stage=GAME_STAGE_BATTLE,
            )
            keepalive_pkt = build_rsp_game_stage(
                timestamp=stage_ts,
                game_stage=GAME_STAGE_BATTLE,
                total_time=stage_total,
                remain_time=stage_remain,
            )
            sock.sendall(keepalive_pkt)
            _log(
                "heartbeat-stage-sync "
                f"peer={peer} hb_recv={player._hb_recv_count} "
                f"stage={GAME_STAGE_BATTLE} total={stage_total} remain={stage_remain}"
            )
        except Exception as exc:
            _log(f"heartbeat-stage-sync failed peer={peer}: {exc}")

    relive_packets = _session_collect_training_target_relive_packets(session)
    if relive_packets:
        _session_send_packets(session, sock, relive_packets)

    if player and not player.loaded and player.progress >= 0.90:
        success_pkt = build_rsp_battle_load_success(player.bid)
        if session:
            session.broadcast(success_pkt)
        else:
            sock.sendall(success_pkt)
    return session, player


def _v2_handle_pkt_version(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    ver = parse_pkt_version(stream)
    _log(
        f"PktVersion from {peer}: game={ver['game']} scene={ver['scene']} "
        f"common={ver['common']} common_res={ver['common_resources']} "
        f"battle_gm={ver['battle_gm']}"
    )
    return session, player


def _v2_handle_req_reset_item_num(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, player_data

    parse_req_reset_item_num(stream)
    _send_rsp_reset_item_num_ack(
        sock,
        peer,
        _log,
        session=session,
        player=player,
        game_state=game_state,
    )
    return session, player


def _v2_handle_req_character_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    req = parse_req_character_state(stream)
    _maybe_log_spawn_probe(session=session, player=player, req_state=req, _log=_log)
    if player:
        pose = req.get('pose')
        if isinstance(pose, dict):
            player.last_character_pos = _coerce_vector3_tuple(pose.get('pos'))
        rsp = build_rsp_character_state(
            player.bid,
            req['pose'],
            req['state'],
            req['body_state'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
        _guide_try_push_only_attackers_state(
            session,
            sock,
            _log=_log,
            reason="post_explosive_followup_state",
        )
    return session, player


def _v2_handle_req_character_jump_on(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_jump_on(stream)
    if player:
        rsp = build_rsp_character_jump_on(
            player.bid,
            req['pose'],
            req['desc'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_leave_wall_space_by_window(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_leave_wall_space_by_window(stream)
    if player:
        rsp = build_rsp_character_leave_wall_space_by_window(
            player.bid,
            True,
            req['dynamic_wall_id'],
            req['pose'],
            req['desc'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _handle_character_action_melee_attack_common(
    *,
    req: dict,
    sock: socket.socket,
    session: BattleSession | None,
    player: BattlePlayer | None,
):
    if player:
        rsp = build_rsp_character_action_melee_attack(
            player.bid,
            req['melee_attack_type'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)


def _handle_character_melee_attack_common(
    *,
    req: dict,
    sock: socket.socket,
    peer: str,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
):
    target = req.get('target')
    target_hit = target.get('hit_target') if isinstance(target, dict) else None
    target_bid = (
        int(target_hit.get('bid', 0))
        if isinstance(target_hit, dict)
        else 0
    )
    _log(
        "ReqCharacterMeleeAttack "
        f"has_target={1 if isinstance(target, dict) else 0} target_bid={target_bid} from {peer}"
    )
    if player:
        rsp = build_rsp_character_melee_attack(
            target_hit if isinstance(target_hit, dict) else None
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    if session and player and target_bid in session.players and target_bid != player.bid:
        target_player = session.players[target_bid]
        if not getattr(target_player, 'is_dead', False):
            target_player.hp = 0
            target_player.is_dead = True
            _log(f"[Combat] Player bid={target_bid} ({target_player.name}) MELEE KILLED by bid={player.bid} ({player.name})!")
            hp_pkt = build_rsp_character_hp_changed(
                bid=target_bid,
                base_hp=0,
                extra_hp=0,
                damage_type=2,
                damage_source=getattr(player, 'last_character_pos', (0.0, 0.0, 0.0)),
            )
            session.broadcast(hp_pkt)
            death_pkt = build_rsp_player_death(
                bid=target_bid,
                item_uid=0,
                attacker_bid=player.bid,
                damage_type=2,
                pos=getattr(target_player, 'last_character_pos', (0.0, 0.0, 0.0)),
            )
            session.broadcast(death_pkt)

            attackers_alive = any(
                not getattr(p, 'is_dead', False)
                for p in session.players.values()
                if p.camp == BATTLE_CAMP_ATTACKER
            )
            defenders_alive = any(
                not getattr(p, 'is_dead', False)
                for p in session.players.values()
                if p.camp == BATTLE_CAMP_DEFENDER
            )
            if not defenders_alive:
                _log("[Combat] All Defenders eliminated -> Attackers Win!")
                res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_ATTACKER)
                session.broadcast(res_pkt)
                over_pkt = build_rsp_battle_over(reason=0)
                session.broadcast(over_pkt)
            elif not attackers_alive:
                _log("[Combat] All Attackers eliminated -> Defenders Win!")
                res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_DEFENDER)
                session.broadcast(res_pkt)
                over_pkt = build_rsp_battle_over(reason=0)
                session.broadcast(over_pkt)

    damage_source = _extract_melee_damage_source(
        target,
        req.get('forward_ray'),
    )
    preferred_board_id = _extract_req_target_board_id_from_melee_target(target)
    target_block_indices = _extract_req_target_block_indices_from_melee_target(target)
    ray_samples = _extract_req_ray_samples_from_melee_target(
        target,
        req.get('forward_ray'),
    )
    _log(
        "ReqCharacterMeleeAttack structure-target "
        f"id={int(preferred_board_id or 0)} blocks={target_block_indices} rays={len(ray_samples)}"
    )
    board_damage_packets = _session_collect_structure_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_MELEE_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=preferred_board_id,
        hit_count=1,
        target_block_indices=target_block_indices,
        ray_samples=ray_samples,
        _log=_log,
    )
    if board_damage_packets:
        _session_send_packets(session, sock, board_damage_packets)


def _v2_handle_req_character_action_melee_attack(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_action_melee_attack(stream)
    _handle_character_action_melee_attack_common(
        req=req,
        sock=sock,
        session=session,
        player=player,
    )
    return session, player


def _v2_handle_req_character_melee_attack(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_melee_attack(stream)
    _handle_character_melee_attack_common(
        req=req,
        sock=sock,
        peer=peer,
        _log=_log,
        session=session,
        player=player,
    )
    return session, player


def _v2_handle_req_character_gun_fire(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_gun_fire(stream)
    bullets = req.get('bullets')
    bullet_count = len(bullets) if isinstance(bullets, list) else 0
    _log(
        "ReqCharacterGunFire "
        f"type={int(req.get('gun_fire_type', 0)) & 0xFF} bullets={bullet_count} "
        f"{_summarize_req_gun_fire_targets(req)} from {peer}"
    )
    destroy_type = DESTROY_TYPE_SHOT_GUN_DAMAGE if bullet_count >= 6 else DESTROY_TYPE_GUN_DAMAGE

    if player:
        rsp = build_rsp_event_character_gun_fire(
            player.bid,
            req['gun_fire_type'],
            req['bullets'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

        # Training target loop:
        # - sync any due relives
        # - on fire request, emulate one target hit to keep target protocols active
        relive_packets = _session_collect_training_target_relive_packets(session)
        if relive_packets:
            _session_send_packets(session, sock, relive_packets)

        damage_source = _extract_gun_fire_damage_source(req)
        preferred_board_id = _extract_req_target_board_id_from_gun_fire(req)
        target_block_indices = _extract_req_target_block_indices_from_gun_fire(req)
        ray_samples = _extract_req_ray_samples_from_gun_fire(req)
        _log(
            "ReqCharacterGunFire structure-target "
            f"id={int(preferred_board_id or 0)} blocks={target_block_indices} rays={len(ray_samples)}"
        )

        if TRAINING_TARGET_AUTODESTROY_ON_GUNFIRE:
            destroy_packets = _session_destroy_first_training_target_packets(
                session,
                damage_source=damage_source,
            )
            if destroy_packets:
                _session_send_packets(session, sock, destroy_packets)
                _log(
                    f"training target destroy emitted packets={len(destroy_packets)} "
                    f"respawn_sec={TRAINING_TARGET_RESPAWN_SEC:.2f}"
                )

        # Player-vs-player hit registration:
        hurt_events_by_victim: dict[int, list[dict]] = {}
        if isinstance(req.get('bullets'), list) and session is not None:
            for b in req['bullets']:
                tc = b.get('target_character')
                if isinstance(tc, dict):
                    v_bid = int(tc.get('bid', 0))
                    if v_bid > 0 and v_bid != player.bid and v_bid in session.players:
                        hurt_info = {
                            'target': tc,
                            'ray': b.get('ray', {}),
                        }
                        if v_bid not in hurt_events_by_victim:
                            hurt_events_by_victim[v_bid] = []
                        hurt_events_by_victim[v_bid].append(hurt_info)

            for v_bid, hurt_list in hurt_events_by_victim.items():
                victim = session.players[v_bid]
                hit_part = int(hurt_list[0]['target'].get('hit_part', 2))
                if hit_part == 1:  # Headshot
                    damage = 100
                    is_headshot = True
                elif hit_part == 2:  # Trunk
                    damage = 38
                    is_headshot = False
                elif hit_part == 3:  # Legs
                    damage = 26
                    is_headshot = False
                else:
                    damage = 32
                    is_headshot = False

                cur_hp = getattr(victim, 'hp', 100)
                new_hp = max(0, cur_hp - damage)
                victim.hp = new_hp
                is_dead = (new_hp <= 0)
                if is_dead:
                    victim.is_dead = True

                hurt_pkt = build_rsp_event_character_gun_hurt(player.bid, hurt_list)
                session.broadcast(hurt_pkt)

                hp_pkt = build_rsp_character_hp_changed(
                    bid=victim.bid,
                    base_hp=new_hp,
                    extra_hp=0,
                    damage_type=1,
                    damage_source=damage_source,
                )
                session.broadcast(hp_pkt)

                shooter_points: list[dict] = []
                if is_dead:
                    shooter_points.append({'action': POINT_ACTION_KILL_ENEMY, 'point': 100})
                    death_pkt = build_rsp_player_death(
                        bid=victim.bid,
                        item_uid=0,
                        attacker_bid=player.bid,
                        damage_type=1,
                        pos=damage_source,
                        part_index=int(hurt_list[0]['target'].get('part_index', 0)),
                    )
                    session.broadcast(death_pkt)

                    if session is not None and not _is_training_mode_game_state(session.game_state):
                        attackers_alive = any(
                            not getattr(p, 'is_dead', False)
                            for p in session.players.values()
                            if p.camp == BATTLE_CAMP_ATTACKER
                        )
                        defenders_alive = any(
                            not getattr(p, 'is_dead', False)
                            for p in session.players.values()
                            if p.camp == BATTLE_CAMP_DEFENDER
                        )
                        if not defenders_alive:
                            _log("[Combat] All Defenders eliminated -> Attackers Win!")
                            res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_ATTACKER)
                            session.broadcast(res_pkt)
                            over_pkt = build_rsp_battle_over(reason=0)
                            session.broadcast(over_pkt)
                        elif not attackers_alive:
                            _log("[Combat] All Attackers eliminated -> Defenders Win!")
                            res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_DEFENDER)
                            session.broadcast(res_pkt)
                            over_pkt = build_rsp_battle_over(reason=0)
                            session.broadcast(over_pkt)

                if is_headshot:
                    shooter_points.append({'action': 2, 'point': 20})

                if shooter_points and getattr(player, 'uid', None):
                    pts_pkt = build_rsp_game_points(player.uid, shooter_points)
                    player.send_raw(pts_pkt)

                _log(
                    f"PvP Gun Hit: attacker={player.bid} victim={v_bid} part={hit_part} "
                    f"dmg={damage} hp={new_hp} dead={is_dead} headshot={is_headshot}"
                )

        target_world_packets, target_personal_packets = _session_collect_training_target_gun_hit_packets(
            session,
            req,
            player=player,
            _log=_log,
        )
        if target_world_packets:
            _session_send_packets(session, sock, target_world_packets)
        if target_personal_packets:
            for pkt in target_personal_packets:
                player.send_raw(pkt)

        board_damage_packets = _session_collect_structure_damage_packets(
            session,
            destroy_type=destroy_type,
            damage_source=damage_source,
            preferred_board_id=preferred_board_id,
            hit_count=1,
            target_block_indices=target_block_indices,
            ray_samples=ray_samples,
            _log=_log,
        )
        if board_damage_packets:
            _session_send_packets(session, sock, board_damage_packets)

        state_source = session.game_state if session is not None else {}
        if (
            session is not None
            and _is_guide_mode_game_state(state_source)
        ):
            _guide_try_push_only_attackers_state(
                session,
                sock,
                _log=_log,
                reason="post_explosive_followup_fire",
            )
    return session, player


def _v2_handle_req_sync_character_action(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_sync_character_action(stream)
    if player:
        rsp = build_rsp_sync_character_action(
            player.bid,
            req['action'],
            req['duration'],
            req['duration_coefficient'],
        )
        if session:
            session.broadcast(rsp, exclude_bid=player.bid)
            sock.sendall(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_lerp_pos(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    req = parse_req_character_lerp_pos(stream)
    if player:
        pose = req.get('pose')
        if isinstance(pose, dict):
            player.last_character_pos = _coerce_vector3_tuple(pose.get('pos'))
        rsp = build_rsp_character_lerp_pos(
            player.bid,
            req['body_state'],
            req['pose'],
            req['lerp_data'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
        _guide_try_push_only_attackers_state(
            session,
            sock,
            _log=_log,
            reason="post_explosive_followup_lerp",
        )
    return session, player


def _v2_handle_req_character_operate_shield(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_operate_shield(stream)
    if player:
        rsp = build_rsp_character_operate_shield(
            player.bid,
            req['pose'],
            req['op'],
            flags=int(req.get('flags', 0)),
            pos_x=req.get('pos_x'),
            pos_y=req.get('pos_y'),
            pos_z=req.get('pos_z'),
            yaw=req.get('yaw'),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_shield_state_update(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_shield_state_update(stream)
    if player:
        rsp = build_rsp_shield_state_update(
            player.bid,
            req['shield_state'],
            flags=int(req.get('flags', 0)),
            pos_x=req.get('pos_x'),
            pos_y=req.get('pos_y'),
            pos_z=req.get('pos_z'),
            yaw=req.get('yaw'),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_destroy_scene_object(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_destroy_scene_object(stream)
    _log(
        "ReqDestroySceneObject recv "
        f"type={int(req.get('destroy_type', DESTROY_TYPE_NONE) or DESTROY_TYPE_NONE)} "
        f"objects={len(req.get('destroy_objects', []) or [])} from {peer}"
    )
    packets = _session_collect_destroy_scene_packets(session, req, _log)
    _session_send_packets(session, sock, packets)
    return session, player


def _v2_handle_req_character_action_take_out_pad(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_character_action_take_out_pad(stream)
    if player:
        rsp = build_rsp_character_action_take_out_pad(player.bid)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_scan_enemies(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_scan_enemies(stream)
    if player:
        _record_guide_scanned_enemy_bids(player, req.get('enemies', []))
        rsp = build_rsp_scan_enemies(
            player.bid,
            req.get('vehicle_id', 0),
            req.get('pos', (0.0, 0.0, 0.0)),
            req.get('enemies', []),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_grenade_begin(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_grenade_begin(stream)
    _log(f"ReqGrenadeBegin grenade_id={req['grenade_unique_id']} from {peer}")
    if player:
        player.last_grenade_unique_id = req['grenade_unique_id']
        player.last_grenade_timeout_uid = 0
        rsp = build_rsp_grenade_begin(True, req['grenade_unique_id'])
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_grenade_end(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_grenade_end(stream)
    _log(
        f"ReqThrowGrenadeEnd grenade_id={req['grenade_unique_id']} "
        f"pos={req['explosive_pos']} from {peer}"
    )
    if player:
        player.last_grenade_unique_id = req['grenade_unique_id']
        player.last_grenade_pos = req['explosive_pos']
        player.last_grenade_timeout_uid = 0
        reporter_id = int(player.uid) if player.uid else int(player.bid)
        rsp = build_rsp_throw_grenade_end(
            reporter_id,
            req['grenade_unique_id'],
            req['explosive_pos'],
            req['throw_transform'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_grenade_explosive_pos_report(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_grenade_explosive_pos_report(stream)
    if player:
        player.last_grenade_unique_id = req['grenade_unique_id']
        player.last_grenade_pos = req['explosive_pos']
        rsp = build_rsp_grenade_explosive_pos_report(
            req['grenade_unique_id'],
            req['explosive_pos'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

        _log(
            f"ReqGrenadeExplosivePosReport grenade_id={req['grenade_unique_id']} "
            f"pos={req['explosive_pos']} from {peer}"
        )
        # Do not force timeout on the first B7 report. The client can emit
        # multiple position reports and finalize later via explode/ntf(remain=0).
    return session, player


def _v2_handle_req_grenade_explosive_pos_ntf(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_grenade_explosive_pos_ntf(stream)
    if player:
        player.last_grenade_unique_id = req['grenade_unique_id']
        player.last_grenade_pos = req['explosive_pos']
        relay = build_req_grenade_explosive_pos_ntf(
            req['grenade_unique_id'],
            req['remain_count'],
            req['explosive_pos'],
        )
        if session:
            session.broadcast(relay)
        else:
            sock.sendall(relay)

        if (
            req['remain_count'] == 0
            and player.last_grenade_timeout_uid != req['grenade_unique_id']
        ):
            timeout_rsp = build_rsp_grenade_time_out(req['grenade_unique_id'])
            if session:
                session.broadcast(timeout_rsp)
            else:
                sock.sendall(timeout_rsp)
            _log(
                f"sent RspGrenadeTimeOut grenade_id={req['grenade_unique_id']} "
                f"via ReqGrenadeExplosivePosNtf(remain=0) to {peer}"
            )
            player.last_grenade_timeout_uid = req['grenade_unique_id']
    return session, player


def _v2_handle_req_bomb_explosive(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_bomb_explosive(stream)
    _log(
        "ReqBombExplosive "
        f"throw_item_unique_id={req['throw_item_unique_id']} "
        f"client_param={req['client_param']} from {peer}"
    )
    rsp = build_rsp_smoke_bomb_explosive(
        int(req['throw_item_unique_id']),
        int(req['client_param']),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_scene_tool(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_scene_tool(stream)
    tool = req['tool']
    scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
    _log(
        "ReqThrowSceneTool "
        f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
    _session_mark_scene_tool_active(session, scene_tool_unique_id)
    _session_update_scene_tool_board_hint(
        session,
        scene_tool_unique_id,
        _extract_scene_tool_position(tool),
    )
    rsp = build_rsp_throw_scene_tool(
        player.bid if player else 0,
        True,
        tool,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_throw_scene_tool_position(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_sync_throw_scene_tool_position(stream)
    tool = req['tool']
    scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
    if _session_is_scene_tool_ended(session, scene_tool_unique_id):
        _log(
            "ReqSyncThrowSceneToolPosition ignored "
            f"scene_tool_unique_id={scene_tool_unique_id} reason=already_ended from {peer}"
        )
        return session, player
    _session_update_scene_tool_board_hint(
        session,
        scene_tool_unique_id,
        _extract_scene_tool_position(tool),
    )
    _log(
        "ReqSyncThrowSceneToolPosition "
        f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
    )
    rsp = build_rsp_sync_throw_scene_tool_position(tool)
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_report_throw_scene_tool_final_position(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_report_throw_scene_tool_final_position(stream)
    tool = req['tool']
    scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
    _session_mark_scene_tool_ended(session, scene_tool_unique_id)
    _log(
        "ReqReportThrowSceneToolFinalPosition "
        f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
    )

    timestamp_ms = int(time.time() * 1000.0) & 0xFFFFFFFF
    rsp = build_rsp_report_throw_scene_tool_final_position(timestamp_ms, tool)
    should_defer_end = bool(
        player
        and scene_tool_unique_id > 0
        and int(player.last_grenade_unique_id) == int(scene_tool_unique_id)
    )
    end_rsp = None if should_defer_end else build_rsp_throw_scene_tool_end(scene_tool_unique_id)
    if session:
        session.broadcast(rsp)
        if end_rsp is not None:
            session.broadcast(end_rsp)
    else:
        sock.sendall(rsp)
        if end_rsp is not None:
            sock.sendall(end_rsp)
    if should_defer_end:
        _log(
            "ReqReportThrowSceneToolFinalPosition defer end "
            f"scene_tool_unique_id={scene_tool_unique_id} reason=grenade_pending_explosion"
        )
    return session, player


def _v2_handle_req_report_throw_scene_tool_final_position_with_relation(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_report_throw_scene_tool_final_position_with_relation(stream)
    tool = req['tool']
    scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
    _session_mark_scene_tool_ended(session, scene_tool_unique_id)
    _log(
        "ReqReportThrowSceneToolFinalPositionWithRelation "
        f"scene_tool_unique_id={scene_tool_unique_id} "
        f"relevant_count={len(req.get('relevant_id') or [])} from {peer}"
    )
    rsp = build_rsp_report_throw_scene_tool_final_position_with_relation(tool)
    should_defer_end = bool(
        player
        and scene_tool_unique_id > 0
        and int(player.last_grenade_unique_id) == int(scene_tool_unique_id)
    )
    end_rsp = None if should_defer_end else build_rsp_throw_scene_tool_end(scene_tool_unique_id)
    if session:
        session.broadcast(rsp)
        if end_rsp is not None:
            session.broadcast(end_rsp)
    else:
        sock.sendall(rsp)
        if end_rsp is not None:
            sock.sendall(end_rsp)
    if should_defer_end:
        _log(
            "ReqReportThrowSceneToolFinalPositionWithRelation defer end "
            f"scene_tool_unique_id={scene_tool_unique_id} reason=grenade_pending_explosion"
        )
    return session, player


def _v2_handle_req_get_back_place_scene_tool(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_get_back_place_scene_tool(stream)
    scene_tool_unique_id = int(req['scene_tool_unique_id'])
    _log(
        "ReqGetBackPlaceSceneTool "
        f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
    rsp = build_rsp_get_back_place_scene_tool_failed(
        player.bid if player else 0,
        scene_tool_unique_id,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_get_back_place_scene_tool_operator(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_get_back_place_scene_tool_operator(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(
        "ReqGetBackPlaceSceneToolOperator "
        f"uid={scene_tool_unique_id} state={req.get('state', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_get_back_place_scene_tool_operator(
        bid=(player.bid if player else 0),
        scene_tool_unique_id=scene_tool_unique_id,
        state=req.get('state', 0),
        lerp_data=req.get('lerp_data', {}),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_player_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_sync_player_state(stream)
    effect_type = int(req.get('effect_type', 0) or 0)
    _log(f"ReqSyncPlayerState effect_type={effect_type} from {peer}")

    rsp = build_rsp_sync_player_state(
        bid=(player.bid if player else 0),
        effect_type=effect_type,
        effect_value=0.0,
        remain_time=0.0,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_use_place_scene_tool_operator(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_use_place_scene_tool_operator(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    hand_item_id = int(req.get('hand_item_id', 0) or 0)
    _log(
        "ReqUsePlaceSceneToolOperator "
        f"hand_item_id={hand_item_id} uid={scene_tool_unique_id} state={req.get('state', 0)} "
        f"from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
        player.last_scene_tool_hand_item_id = hand_item_id

    rsp = build_rsp_use_place_scene_tool_operator(
        operator_bid=(player.bid if player else 0),
        hand_item_id=hand_item_id,
        scene_tool_unique_id=scene_tool_unique_id,
        state=req.get('state', 0),
        lerp_data=req.get('lerp_data', {}),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_item_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_sync_item_state(stream)
    item_uid = int(req.get('item_uid', 0) or 0)
    effect_type = int(req.get('effect_type', 0) or 0)
    _log(f"ReqSyncItemState item_uid={item_uid} effect_type={effect_type} from {peer}")
    if player:
        player.last_scene_tool_unique_id = item_uid

    rsp = build_rsp_sync_item_state(
        item_uid=item_uid,
        effect_type=effect_type,
        effect_value=0.0,
        remain_time=0.0,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_operate_scene(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_operate_scene(stream)
    _log(
        "ReqOperateScene "
        f"tool_id={req.get('hand_tool_id', 0)} target_index={req.get('target_index', 0)} "
        f"state={req.get('state', 0)} flags=0x{int(req.get('flags', 0)) & 0x03:02X} from {peer}"
    )
    if player:
        player.last_scene_tool_hand_item_id = int(req.get('hand_tool_id', 0) or 0)

    rsp = build_rsp_operate_scene(
        bid=(player.bid if player else 0),
        hand_tool_id=req.get('hand_tool_id', 0),
        hand_tool_config_id=req.get('hand_tool_config_id', 0),
        target_index=req.get('target_index', 0),
        state=req.get('state', 0),
        flags=req.get('flags', 0),
        pose=req.get('pose'),
        trans=req.get('trans'),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_kill_me(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_kill_me(stream)
    _log(f"ReqKillMe from {peer}")
    
    # Fortress Armor Plate Knockdown Override
    if player is not None and getattr(player, 'has_armor_plate', False):
        player.has_armor_plate = False
        _log(f"Player {player.bid} has armor plate! Overriding death to DBNO (Agonal).")
        rsp = build_rsp_player_agonal(
            player_bid=player.bid,
            damage_type=0,
            agonal_hp=100,
            agonal_time=30000,
            agonal_hp_speed=1.0,
            agonal_time_speed=1.0
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    else:
        rsp = build_rsp_kill_me()
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    return session, player


def _v2_handle_req_shock_grenade_bomb(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_shock_grenade_bomb(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(f"ReqShockGrenadeBomb uid={scene_tool_unique_id} from {peer}")
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id
        if scene_tool_unique_id > 0:
            player.last_grenade_unique_id = scene_tool_unique_id
            player.last_grenade_timeout_uid = 0
        trans = req.get('trans') if isinstance(req, dict) else None
        if isinstance(trans, dict):
            player.last_grenade_pos = _coerce_vector3_tuple(trans.get('position'))

    trans = req.get('trans') if isinstance(req, dict) else None
    impact_pos = (
        _coerce_vector3_tuple(trans.get('position'))
        if isinstance(trans, dict)
        else (player.last_grenade_pos if player else (0.0, 0.0, 0.0))
    )

    preferred_board_id = _session_get_scene_tool_wall_hint(session, scene_tool_unique_id)
    if preferred_board_id is None:
        preferred_board_id = _session_get_scene_tool_board_hint(session, scene_tool_unique_id)
    if preferred_board_id is None and player and player.last_place_target_wall_id > 0:
        preferred_board_id = _normalize_board_id(player.last_place_target_wall_id)
    if preferred_board_id is None and player and player.last_blocking_board_id > 0:
        preferred_board_id = _normalize_board_id(player.last_blocking_board_id)
    _log(
        "ReqShockGrenadeBomb structure-target "
        f"id={int(preferred_board_id or 0)} blocks=[] rays=0"
    )

    packets: list[bytes] = [build_rsp_shock_grenade_bomb(scene_tool_unique_id)]
    if scene_tool_unique_id > 0:
        # Keep shock explosion notifications and let the client finish
        # scene-tool lifecycle naturally without early server-side stop.
        packets.append(build_req_grenade_explosive_pos_ntf(scene_tool_unique_id, 0, impact_pos))
        packets.append(build_rsp_grenade_time_out(scene_tool_unique_id))
        packets.append(build_rsp_throw_scene_tool_end(scene_tool_unique_id))
        _session_mark_scene_tool_ended(session, scene_tool_unique_id)
        _log(
            "ReqShockGrenadeBomb explosion notification sent "
            f"scene_tool_unique_id={scene_tool_unique_id}"
        )

    _session_send_packets(session, sock, packets)

    damage_source = (
        impact_pos
    )
    board_damage_packets = _session_collect_structure_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_EXPLOSIVE_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=preferred_board_id,
        hit_count=1,
        _log=_log,
    )
    if board_damage_packets:
        _session_send_packets(session, sock, board_damage_packets)
    return session, player


def _v2_handle_req_sync_character_weapon_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    req = parse_req_sync_character_weapon_state(stream)
    if player:
        rsp = build_rsp_sync_character_weapon_state(
            player.bid,
            req['weapon_state'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_character_assist_tool(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_sync_character_assist_tool(stream)
    assist_tool_index = int(req.get('assist_tool_index', 0) or 0)
    _log(f"ReqSyncCharacterAssistTool assist_tool_index={assist_tool_index} from {peer}")

    if player:
        rsp = build_rsp_sync_character_assist_tool(player.bid, assist_tool_index)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_stretch_hand_shield_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_sync_stretch_hand_shield_state(stream)
    _log(f"ReqSyncStretchHandShieldState is_expanded={req.get('is_expanded', False)} from {peer}")
    return session, player


def _v2_handle_req_sync_hand_shield_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_sync_hand_shield_state(stream)
    tool_index = int(req.get('tool_index', 0) or 0)
    _log(
        "ReqSyncHandShieldState "
        f"tool_index={tool_index} is_in_back={req.get('is_in_back', False)} from {peer}"
    )
    if player:
        player.last_scene_tool_hand_item_id = tool_index
    return session, player


def _v2_handle_req_trigger_flash_hand_shield(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_trigger_flash_hand_shield(stream)
    flash_point = req.get('flash_point', {}) if isinstance(req, dict) else {}
    _log(
        "ReqTriggerFlashHandShield "
        f"pos={flash_point.get('position', (0.0, 0.0, 0.0))} from {peer}"
    )
    return session, player


def _v2_handle_req_gen_robot(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_gen_robot(stream)
    _log(
        "ReqGenRobot "
        f"config_id={req.get('config_id', 0)} flags=0x{int(req.get('flags', 0)) & 0x03:02X} "
        f"state={req.get('state', None)} from {peer}"
    )
    return session, player


def _v2_handle_req_switch_current_unmanned_vehicle(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_switch_current_unmanned_vehicle(stream)
    vehicle_id = int(req.get('vehicle_id', 0) or 0)
    if vehicle_id == 0 and player:
        vehicle_id = int(player.last_unmanned_vehicle_id or 0)
    _log(f"ReqSwitchCurrentUnmannedVehicle vehicle_id={vehicle_id} from {peer}")

    if player and vehicle_id > 0:
        player.last_unmanned_vehicle_id = vehicle_id
        rsp = build_rsp_update_unmanned_vehicle_state(
            bid=player.bid,
            vehicle_id=vehicle_id,
            relation=VEHICLE_RELATION_OPERATOR,
            need_switch_to_character=False,
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    elif vehicle_id > 0:
        rsp = build_rsp_switch_unmanned_vehicle_failed(vehicle_id)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_unmanned_vehicle_spawn(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_unmanned_vehicle_spawn(stream)
    vehicle_id = int(req.get('vehicle_id', 0) or 0)
    pose = req.get('pose', {}) if isinstance(req.get('pose', {}), dict) else {}
    pos = pose.get('pos', (0.0, 0.0, 0.0))
    rot = pose.get('rot', (0.0, 0.0, 0.0))
    _log(
        "ReqUnmannedVehicleSpawn "
        f"vehicle_id={vehicle_id} pos={pos} rot={rot} from {peer}"
    )

    if player:
        player.last_unmanned_vehicle_id = vehicle_id
        player.last_unmanned_vehicle_pose = {
            'pos_x': float(pos[0]) if isinstance(pos, (tuple, list)) and len(pos) > 0 else 0.0,
            'pos_y': float(pos[1]) if isinstance(pos, (tuple, list)) and len(pos) > 1 else 0.0,
            'pos_z': float(pos[2]) if isinstance(pos, (tuple, list)) and len(pos) > 2 else 0.0,
            'yaw': float(rot[1]) if isinstance(rot, (tuple, list)) and len(rot) > 1 else 0.0,
            'view_pitch': float(rot[0]) if isinstance(rot, (tuple, list)) and len(rot) > 0 else 0.0,
            'view_yaw': float(rot[1]) if isinstance(rot, (tuple, list)) and len(rot) > 1 else 0.0,
            'view_roll': float(rot[2]) if isinstance(rot, (tuple, list)) and len(rot) > 2 else 0.0,
        }

    if vehicle_id > 0:
        rsp_spawn = build_rsp_unmanned_vehicle_spawn(vehicle_id=vehicle_id, pose=pose)
        if session:
            session.broadcast(rsp_spawn)
        else:
            sock.sendall(rsp_spawn)

        if player:
            rsp_state = build_rsp_update_unmanned_vehicle_state(
                bid=player.bid,
                vehicle_id=vehicle_id,
                relation=VEHICLE_RELATION_OPERATOR,
                need_switch_to_character=False,
            )
            if session:
                session.broadcast(rsp_state)
            else:
                sock.sendall(rsp_state)
    return session, player


def _v2_handle_req_unmanned_vehicle_pose_delta(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_unmanned_vehicle_pose_delta(stream)
    vehicle_id = int(req.get('vehicle_id', 0) or 0)
    if vehicle_id == 0 and player:
        vehicle_id = int(player.last_unmanned_vehicle_id or 0)
    flags = int(req.get('flags', 0) or 0) & 0x7F

    _log(
        "ReqUnmannedVehiclePoseDelta "
        f"vehicle_id={vehicle_id} flags=0x{flags:02X} from {peer}"
    )

    if player and vehicle_id > 0:
        player.last_unmanned_vehicle_id = vehicle_id
        cached = player.last_unmanned_vehicle_pose if isinstance(player.last_unmanned_vehicle_pose, dict) else {}
        for key in ('pos_x', 'pos_y', 'pos_z', 'yaw', 'view_pitch', 'view_yaw', 'view_roll'):
            if key in req:
                try:
                    cached[key] = float(req[key])
                except Exception:
                    pass
        player.last_unmanned_vehicle_pose = cached

    if vehicle_id > 0:
        bid = player.bid if player else 0
        rsp = build_rsp_unmanned_vehicle_pose_delta(
            bid=bid,
            vehicle_id=vehicle_id,
            flags=flags,
            pos_x=req.get('pos_x'),
            pos_y=req.get('pos_y'),
            pos_z=req.get('pos_z'),
            yaw=req.get('yaw'),
            view_pitch=req.get('view_pitch'),
            view_yaw=req.get('view_yaw'),
            view_roll=req.get('view_roll'),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_unmanned_vehicle_take_back(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_unmanned_vehicle_take_back(stream)
    vehicle_id = int(req.get('vehicle_id', 0) or 0)
    if vehicle_id == 0 and player:
        vehicle_id = int(player.last_unmanned_vehicle_id or 0)
    _log(f"ReqUnmannedVehicleTakeBack vehicle_id={vehicle_id} from {peer}")

    rsp = build_rsp_unmanned_vehicle_take_back(vehicle_id)
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)

    if player and vehicle_id > 0:
        player.last_unmanned_vehicle_id = 0
        player.last_unmanned_vehicle_pose = {}
        rsp_state = build_rsp_update_unmanned_vehicle_state(
            bid=player.bid,
            vehicle_id=vehicle_id,
            relation=VEHICLE_RELATION_NONE,
            need_switch_to_character=True,
        )
        if session:
            session.broadcast(rsp_state)
        else:
            sock.sendall(rsp_state)
    return session, player


def _v2_handle_req_switch_unmanned_vehicle_to_character(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_switch_unmanned_vehicle_to_character(stream)
    vehicle_id = int(player.last_unmanned_vehicle_id or 0) if player else 0
    _log(f"ReqSwitchUnmannedVehicleToCharacter vehicle_id={vehicle_id} from {peer}")

    if player and vehicle_id > 0:
        rsp = build_rsp_update_unmanned_vehicle_state(
            bid=player.bid,
            vehicle_id=vehicle_id,
            relation=VEHICLE_RELATION_NONE,
            need_switch_to_character=True,
        )
        _log(
            "RspUpdateUnmannedVehicleState "
            f"bid={player.bid} vehicle_id={vehicle_id} relation={VEHICLE_RELATION_NONE} "
            "need_switch_to_character=1"
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    elif vehicle_id > 0:
        rsp = build_rsp_switch_unmanned_vehicle_failed(vehicle_id)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_monitor_scan_enemies(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_monitor_scan_enemies(stream)
    monitor_id = int(req.get('monitor_id', 0) or 0)
    if monitor_id == 0 and player:
        monitor_id = int(player.last_monitor_id or 0)
    _log(
        "ReqMonitorScanEnemies "
        f"monitor_id={monitor_id} enemies={len(req.get('enemies', []))} from {peer}"
    )
    if player:
        if monitor_id > 0:
            player.last_monitor_id = monitor_id
        _record_guide_scanned_enemy_bids(player, req.get('enemies', []))
        rsp = build_rsp_monitor_scan_enemies(
            player.bid,
            monitor_id,
            req.get('view_yaw', 0.0),
            req.get('view_pitch', 0.0),
            req.get('enemies', []),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_switch_current_monitor(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_switch_current_monitor(stream)
    monitor_id = int(req.get('monitor_id', 0) or 0)
    prev_monitor_id = int(player.last_monitor_id or 0) if player else 0
    if monitor_id == 0 and player:
        monitor_id = prev_monitor_id
    _log(f"ReqSwitchCurrentMonitor monitor_id={monitor_id} from {peer}")

    if player and monitor_id > 0:
        packets: list[bytes] = []
        if prev_monitor_id > 0 and prev_monitor_id != monitor_id:
            packets.append(
                build_rsp_update_monitor_state(
                    bid=player.bid,
                    monitor_id=prev_monitor_id,
                    relation=MONITOR_RELATION_NONE,
                    need_switch_to_character=False,
                )
            )
            _log(
                "RspUpdateMonitorState "
                f"bid={player.bid} monitor_id={prev_monitor_id} relation={MONITOR_RELATION_NONE} "
                "need_switch_to_character=0 (clear previous monitor)"
            )
        player.last_monitor_id = monitor_id
        packets.append(
            build_rsp_update_monitor_state(
                bid=player.bid,
                monitor_id=monitor_id,
                relation=MONITOR_RELATION_OPERATOR,
                need_switch_to_character=False,
            )
        )
        _log(
            "RspUpdateMonitorState "
            f"bid={player.bid} monitor_id={monitor_id} relation={MONITOR_RELATION_OPERATOR} "
            "need_switch_to_character=0"
        )
        if session:
            for pkt in packets:
                session.broadcast(pkt)
        else:
            for pkt in packets:
                sock.sendall(pkt)
    else:
        rsp = build_rsp_switch_current_monitor_failed(monitor_id)
        _log(f"RspSwitchCurrentMonitorFailed monitor_id={monitor_id}")
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_switch_monitor_to_character(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_switch_monitor_to_character(stream)
    monitor_id = int(player.last_monitor_id or 0) if player else 0
    _log(f"ReqSwitchMonitorToCharacter monitor_id={monitor_id} from {peer}")
    if player and monitor_id > 0:
        rsp = build_rsp_update_monitor_state(
            bid=player.bid,
            monitor_id=monitor_id,
            relation=MONITOR_RELATION_NONE,
            need_switch_to_character=True,
        )
        _log(
            "RspUpdateMonitorState "
            f"bid={player.bid} monitor_id={monitor_id} relation={MONITOR_RELATION_NONE} "
            "need_switch_to_character=1"
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
        player.last_monitor_id = 0
    return session, player


def _v2_handle_req_monitor_pose_delta(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_monitor_pose_delta(stream)
    monitor_id = int(req.get('monitor_id', 0) or 0)
    if monitor_id == 0 and player:
        monitor_id = int(player.last_monitor_id or 0)
    flags = int(req.get('flags', 0) or 0) & 0x03
    _log(
        "ReqMonitorPoseDelta "
        f"monitor_id={monitor_id} flags=0x{flags:02X} from {peer}"
    )
    if player:
        if monitor_id > 0:
            player.last_monitor_id = monitor_id
        rsp = build_rsp_monitor_pose_delta(
            player.bid,
            monitor_id,
            flags=flags,
            view_pitch=req.get('view_pitch'),
            view_yaw=req.get('view_yaw'),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_found_critical_target(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_found_critical_target(stream)
    req_region_id = int(req.get('region_id', 0) or 0)
    resolved_region_id = req_region_id
    resolved_source = 'request'

    if resolved_region_id <= 0 and session is not None:
        fallback_region_id = int(session.room_loading_critical_region_id or 0)
        if fallback_region_id > 0:
            resolved_region_id = fallback_region_id
            resolved_source = 'session.room_loading_critical_region_id'

    if resolved_region_id <= 0 and session is not None:
        state_source = session.game_state if isinstance(session.game_state, dict) else {}
        if _is_guide_mode_game_state(state_source):
            fallback_zone = _get_primary_target_zone_for_map(int(state_source.get('map_id', 0) or 0))
            if fallback_zone is not None and int(fallback_zone) > 0:
                resolved_region_id = int(fallback_zone)
                resolved_source = 'maps.target_zone[0]'

    if session is not None and resolved_region_id > 0:
        session.room_loading_critical_region_id = int(resolved_region_id)

    _log(
        "ReqFoundCriticalTarget "
        f"region_id={req_region_id} resolved_region_id={resolved_region_id} "
        f"source={resolved_source} from {peer}"
    )

    if player:
        rsp = build_rsp_found_critical_target(
            player.bid,
            resolved_region_id,
            False,
        )
        crit_rsp = build_rsp_critical_region_state(CRITICAL_REGION_STATE_BOTH_PLAYERS)
        if session:
            session.broadcast(rsp)
            session.broadcast(crit_rsp)
            _guide_set_critical_region_state(session, CRITICAL_REGION_STATE_BOTH_PLAYERS)
        else:
            sock.sendall(rsp)
            sock.sendall(crit_rsp)
    return session, player


def _v2_handle_req_found_bomb_target(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_found_bomb_target(stream)
    if player:
        rsp = build_rsp_found_bomb_target(
            player.bid,
            req.get('region_id', 0),
            False,
        )
        crit_rsp = build_rsp_critical_region_state(CRITICAL_REGION_STATE_BOTH_PLAYERS)
        if session:
            session.broadcast(rsp)
            session.broadcast(crit_rsp)
            _guide_set_critical_region_state(session, CRITICAL_REGION_STATE_BOTH_PLAYERS)
        else:
            sock.sendall(rsp)
            sock.sendall(crit_rsp)
    return session, player


def _v2_handle_req_found_defuser(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_found_defuser(stream)
    found_player_bid = player.bid if player else 0
    rsp = build_rsp_found_defuser(req.get('defuser_id', 0), found_player_bid)
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_notify_defuser_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_notify_defuser_state(stream)
    rsp = build_rsp_notify_defuser_state(req.get('state', 0))
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_pick_up_defuser(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    parse_req_pick_up_defuser(stream)
    _log(f"ReqPickUpDefuser from {peer}")
    return session, player


def _v2_handle_req_drop_defuser(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    parse_req_drop_defuser(stream)
    _log(f"ReqDropDefuser from {peer}")
    return session, player


def _v2_handle_req_add_robot(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_add_robot(stream)
    _log(f"ReqAddRobot param={req.get('param', '')} from {peer}")
    return session, player


def _v2_handle_req_operate_battle(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_operate_battle(stream)
    op = int(req.get('op', 0) or 0) & 0xFF
    _log(f"ReqOperateBattle op={op} from {peer}")
    sock.sendall(build_rsp_operate_battle(op, True))
    return session, player


def _v2_handle_req_robot_move(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    parse_req_robot_move(stream)
    _log(f"ReqRobotMove from {peer}")
    return session, player


def _v2_handle_req_robot_fire(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    parse_req_robot_fire(stream)
    _log(f"ReqRobotFire from {peer}")
    return session, player


def _v2_handle_req_character_climb_ladder(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_climb_ladder(stream)
    if player:
        rsp = build_rsp_character_climb_ladder(
            player.bid,
            req.get('ladder_id', 0),
            req.get('is_up', False),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_leave_ladder(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    req = parse_req_character_leave_ladder(stream)
    if player:
        rsp = build_rsp_character_leave_ladder(
            player.bid,
            req.get('ladder_id', 0),
            req.get('is_up', False),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_bomb_gun_fire(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    req = parse_req_bomb_gun_fire(stream)
    if player:
        rsp = build_rsp_bomb_gun_fire_result(
            player.bid,
            req.get('bullet_id', 0),
            req.get('ray', {}),
            True,
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    damage_source = _ray_damage_point(req.get('ray'))
    board_damage_packets = _session_collect_structure_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_EXPLOSIVE_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=None,
        hit_count=1,
        _log=_log,
    )
    if board_damage_packets:
        _session_send_packets(session, sock, board_damage_packets)
    return session, player


def _v2_handle_req_bomb_bullet_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, peer, battle_id, game_state, player_data

    req = parse_req_bomb_bullet_state(stream)
    if player:
        player.last_scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)

    state = int(req.get('state', 0) or 0) & 0xFF
    if state != 0:
        preferred_board_id: int | None = None
        hit_target = req.get('hit_target')
        if isinstance(hit_target, dict):
            preferred_board_id = _normalize_board_id(
                int(hit_target.get('hit_target_id', 0) or 0) & 0xFFFFFFFF
            )

        damage_source = (0.0, 0.0, 0.0)
        trans = req.get('trans')
        if isinstance(trans, dict):
            damage_source = _coerce_vector3_tuple(trans.get('position'))
        elif isinstance(req.get('behurt_info'), dict):
            damage_source = _ray_damage_point(req['behurt_info'].get('ray'))

        board_damage_packets = _session_collect_structure_damage_packets(
            session,
            destroy_type=DESTROY_TYPE_EXPLOSIVE_DAMAGE,
            damage_source=damage_source,
            preferred_board_id=preferred_board_id,
            hit_count=1,
            _log=_log,
        )
        if board_damage_packets:
            _session_send_packets(session, sock, board_damage_packets)
    return session, player


def _v2_handle_req_vehicle_launch_tracker(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_vehicle_launch_tracker(stream)
    _log(
        "ReqVehicleLaunchTracker "
        f"targets={len(req.get('target_bids', []))} from {peer}"
    )
    if player:
        rsp = build_rsp_vehicle_launch_tracker(
            player.bid,
            req.get('pos_start', (0.0, 0.0, 0.0)),
            req.get('pos_ends', []),
            req.get('target_bids', []),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_active_tracker(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_active_tracker(stream)
    _log(f"ReqActiveTracker tool_index={req.get('tool_index', 0)} from {peer}")
    rsp = build_rsp_active_tracker(0, req.get('tool_index', 0))
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_disturbed_operate(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_disturbed_operate(stream)
    _log(
        "ReqDisturbedOperate "
        f"item_uid={req.get('item_uid', 0)} tool_index={req.get('tool_index', 0)} "
        f"op={req.get('op', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = int(req.get('item_uid', 0) or 0)
    return session, player


def _v2_handle_req_character_hammer_attack(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_hammer_attack(stream)
    _log(
        "ReqCharacterHammerAttack "
        f"target_type={req.get('target_type', 0)} has_target={1 if req.get('target') else 0} from {peer}"
    )
    if player:
        rsp = build_rsp_character_hammer_attack(
            bid=player.bid,
            forward_ray=req.get('forward_ray', {}),
            remain_num=0,
            target_type=req.get('target_type', 0),
            trans=req.get('trans', {}),
            target_mat=req.get('target_mat', 0),
            target=req.get('target'),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    target = req.get('target')
    damage_source = _extract_melee_damage_source(
        target,
        req.get('forward_ray'),
    )
    preferred_board_id = _extract_req_target_board_id_from_melee_target(target)
    target_block_indices = _extract_req_target_block_indices_from_melee_target(target)
    ray_samples = _extract_req_ray_samples_from_melee_target(
        target,
        req.get('forward_ray'),
    )
    board_damage_packets = _session_collect_structure_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_HAMMER_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=preferred_board_id,
        hit_count=1,
        target_block_indices=target_block_indices,
        ray_samples=ray_samples,
        _log=_log,
    )
    if board_damage_packets:
        _session_send_packets(session, sock, board_damage_packets)
    return session, player


def _v2_handle_req_character_action_hammer_attack(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_character_action_hammer_attack(stream)
    _log(f"ReqCharacterActionHammerAttack from {peer}")
    if player:
        rsp = build_rsp_character_action_hammer_attack(player.bid)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_client_cheat_report(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_client_cheat_report(stream)
    _log(
        "ReqClientCheatReport "
        f"bid={req.get('bid', 0)} key={req.get('key', 0)} value={req.get('value', 0)} from {peer}"
    )
    return session, player


def _v2_handle_req_character_action_install_trap_bomb(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_action_install_trap_bomb(stream)
    trap_bomb_uid = int(req.get('trap_bomb_uid', 0) or 0)
    _log(
        "ReqCharacterActionInstallTrapBomb "
        f"uid={trap_bomb_uid} install_type={req.get('install_type', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = trap_bomb_uid
    rsp = build_rsp_character_action_install_trap_bomb(
        trap_bomb_uid,
        req.get('pos', (0.0, 0.0, 0.0)),
        req.get('rot', (0.0, 0.0, 0.0, 1.0)),
        req.get('install_type', 0),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_trap_bomb_installed(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_trap_bomb_installed(stream)
    trap_bomb_uid = int(req.get('trap_bomb_uid', 0) or 0)
    _log(
        "ReqTrapBombInstalled "
        f"uid={trap_bomb_uid} block_id={req.get('block_id', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = trap_bomb_uid
    rsp = build_rsp_trap_bomb_installed(
        trap_bomb_uid,
        req.get('block_id', 0),
        req.get('bomb_pos', (0.0, 0.0, 0.0)),
        req.get('bomb_rot', (0.0, 0.0, 0.0, 1.0)),
        req.get('install_type', 0),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_action_uninstall_trap_bomb(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_action_uninstall_trap_bomb(stream)
    trap_bomb_uid = int(req.get('trap_bomb_uid', 0) or 0)
    _log(f"ReqCharacterActionUninstallTrapBomb uid={trap_bomb_uid} from {peer}")
    if player:
        player.last_scene_tool_unique_id = trap_bomb_uid
    rsp = build_rsp_character_action_uninstall_trap_bomb(trap_bomb_uid)
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_trap_bomb_uninstalled(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del sock, battle_id, game_state, player_data

    req = parse_req_trap_bomb_uninstalled(stream)
    trap_bomb_uid = int(req.get('trap_bomb_uid', 0) or 0)
    _log(f"ReqTrapBombUninstalled uid={trap_bomb_uid} from {peer}")
    if player:
        player.last_scene_tool_unique_id = trap_bomb_uid
    return session, player


def _v2_handle_req_trigger_trap_bomb(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_trigger_trap_bomb(stream)
    trap_bomb_uid = int(req.get('trap_bomb_uid', 0) or 0)
    _log(
        "ReqTriggerTrapBomb "
        f"uid={trap_bomb_uid} char_pos={req.get('char_pos', (0.0, 0.0, 0.0))} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = trap_bomb_uid

    rsp = build_rsp_update_trap_bomb_state(
        trap_bomb_uid=trap_bomb_uid,
        item_state=4,
        attacker_bid=(player.bid if player else None),
        effect_type=24,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_item(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_item(stream)
    throw_item_unique_id = int(req.get('throw_item_unique_id', 0) or 0)
    _log(
        "ReqThrowItem "
        f"uid={throw_item_unique_id} client_param={req.get('client_param', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = throw_item_unique_id

    rsp = build_rsp_throw_item(
        result=True,
        throw_item_unique_id=throw_item_unique_id,
        client_param=req.get('client_param', 0),
        count=1,
        ray=req.get('ray', {}),
        angle=req.get('angle', (0.0, 0.0, 0.0)),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_item_pos_report(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_item_pos_report(stream)
    throw_item_unique_id = int(req.get('throw_item_unique_id', 0) or 0)
    _log(f"ReqItemPosReport uid={throw_item_unique_id} from {peer}")
    if player:
        player.last_scene_tool_unique_id = throw_item_unique_id

    rsp = build_rsp_item_pos_report(
        throw_item_unique_id=throw_item_unique_id,
        ray=req.get('ray', {}),
        angle=req.get('angle', (0.0, 0.0, 0.0)),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_item_drop_down(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_item_drop_down(stream)
    throw_item_unique_id = int(req.get('throw_item_unique_id', 0) or 0)
    _log(f"ReqThrowItemDropDown uid={throw_item_unique_id} from {peer}")
    if player:
        player.last_scene_tool_unique_id = throw_item_unique_id

    rsp = build_rsp_throw_item_drop_down(
        result=True,
        throw_item_unique_id=throw_item_unique_id,
        ray=req.get('ray', {}),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_item_stoped(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_item_stoped(stream)
    throw_item_unique_id = int(req.get('throw_item_unique_id', 0) or 0)
    _log(
        "ReqThrowItemStoped "
        f"uid={throw_item_unique_id} relates={len(req.get('relates', []))} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = throw_item_unique_id

    rsp = build_rsp_throw_item_stoped(
        result=True,
        throw_item_unique_id=throw_item_unique_id,
        trans=req.get('trans', {}),
        relates=req.get('relates', []),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_game_points(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_game_points(stream)
    player_id = int(req.get('player_id', 0) or 0)
    if player_id == 0 and player and player.uid:
        player_id = int(player.uid)
    _log(f"ReqGamePoints player_id={player_id} from {peer}")

    points: list[dict] = []
    if player is not None and player.guide_pending_points:
        points = list(player.guide_pending_points)
        player.guide_pending_points.clear()
        _log(
            "guide: ReqGamePoints drained pending points "
            f"count={len(points)}"
        )

    rsp = build_rsp_game_points(player_id=player_id, points=points)
    sock.sendall(rsp)
    return session, player


def _v2_handle_req_operate_character(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_operate_character(stream)
    _log(
        "ReqOperateCharacter "
        f"tool_id={req.get('hand_tool_id', 0)} target_bid={req.get('target_player_bid', 0)} "
        f"state={req.get('state', 0)} from {peer}"
    )

    if player:
        rsp = build_rsp_operate_character(
            bid=player.bid,
            hand_tool_id=req.get('hand_tool_id', 0),
            hand_tool_config_id=req.get('hand_tool_config_id', 0),
            target_player_bid=req.get('target_player_bid', 0),
            state=req.get('state', 0),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_neuro_toxin(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_neuro_toxin(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(
        "ReqThrowNeuroToxin "
        f"uid={scene_tool_unique_id} client_param={req.get('client_param', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_throw_neuro_toxin(
        player_bid=(player.bid if player else 0),
        is_success=True,
        scene_tool_unique_id=scene_tool_unique_id,
        client_param=req.get('client_param', 0),
        trans=req.get('trans', {}),
        speed=req.get('speed', (0.0, 0.0, 0.0)),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_sync_neuro_toxin_position(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_sync_neuro_toxin_position(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(f"ReqSyncNeuroToxinPosition uid={scene_tool_unique_id} from {peer}")
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_sync_neuro_toxin_position(
        scene_tool_unique_id=scene_tool_unique_id,
        trans=req.get('trans', {}),
        speed=req.get('speed', (0.0, 0.0, 0.0)),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_throw_neuro_toxin_end(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_throw_neuro_toxin_end(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(
        "ReqThrowNeuroToxinEnd "
        f"uid={scene_tool_unique_id} flags=0x{int(req.get('flags', 0)) & 0xFF:02X} "
        f"relates={len(req.get('relevant_id', []))} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_throw_neuro_toxin_end(
        scene_tool_unique_id=scene_tool_unique_id,
        trans=req.get('trans', {}),
        speed=req.get('speed', (0.0, 0.0, 0.0)),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_remove_neuro_toxin_operator(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_remove_neuro_toxin_operator(stream)
    _log(f"ReqRemoveNeuroToxinOperator from {peer}")

    rsp = build_rsp_remove_neuro_toxin_operator(bid=(player.bid if player else 0))
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_remove_neuro_toxin_effect(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    parse_req_remove_neuro_toxin_effect(stream)
    _log(f"ReqRemoveNeuroToxinEffect from {peer}")
    return session, player


def _v2_handle_req_get_back_neuro_toxin_operator(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_get_back_neuro_toxin_operator(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(
        "ReqGetBackNeuroToxinOperator "
        f"uid={scene_tool_unique_id} state={req.get('state', 0)} from {peer}"
    )
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_get_back_neuro_toxin_operator(
        bid=(player.bid if player else 0),
        scene_tool_unique_id=scene_tool_unique_id,
        player_current_transform=req.get('player_current_transform', {}),
        state=req.get('state', 0),
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_get_back_neuro_toxin_tool(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_get_back_neuro_toxin_tool(stream)
    scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0)
    _log(f"ReqGetBackNeuroToxinTool uid={scene_tool_unique_id} from {peer}")
    if player:
        player.last_scene_tool_unique_id = scene_tool_unique_id

    rsp = build_rsp_get_back_neuro_toxin_failed(
        bid=(player.bid if player else 0),
        scene_tool_unique_id=scene_tool_unique_id,
    )
    if session:
        session.broadcast(rsp)
    else:
        sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_operate_blocking_board(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_operate_blocking_board(stream)
    _log(f"ReqCharacterOperateBlockingBoard block_id={req['block_id']} op={req['op']} from {peer}")
    if int(req.get('op', 0) or 0) == 1:
        _session_record_blocking_board_anchor(session, req.get('block_id'), req.get('pose'))
        _session_mark_player_placed_blocking_board(session, req.get('block_id'))
    if player:
        player.last_blocking_board_id = int(req.get('block_id', 0) or 0) & 0xFFFFFFFF
    if player:
        rsp = build_rsp_character_operate_blocking_board(
            player.bid,
            req['pose'],
            req['block_id'],
            req['op'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_change_blocking_board_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_change_blocking_board_state(stream)
    _log(f"ReqChangeBlockingBoardState id={req['id']} state={req['state']} from {peer}")
    if player:
        player.last_blocking_board_id = int(req.get('id', 0) or 0) & 0xFFFFFFFF
    if session:
        with session._lock:
            board_id = int(req['id']) & 0xFFFFFFFF
            board_state = int(req['state']) & 0xFF
            session.last_blocking_board_id = board_id
            session.blocking_board_states[board_id] = board_state
            dyn = session.dynamic_walls.setdefault(
                board_id,
                {'state': board_state, 'blocks': set()},
            )
            dyn['state'] = board_state
            if board_state != BLOCKING_BOARD_STATE_DEACTIVE:
                if float(session.blocking_board_hp.get(board_id, 1.0)) <= 0.0:
                    session.blocking_board_hp[board_id] = 1.0
                    session.broken_walls.pop(board_id, None)
                    dyn['blocks'] = set()
    player_id = int(player.uid) if (player and player.uid) else None
    evt = build_rsp_event_blocking_board_state(req['id'], player_id, req['state'])
    if session:
        session.broadcast(evt)
    else:
        sock.sendall(evt)
    return session, player


def _v2_handle_req_character_action_explode(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_action_explode(stream)
    _log(f"ReqCharacterActionExplodeExplosive hand_tool_id={req['hand_tool_id']} from {peer}")
    if player:
        rsp = build_rsp_character_action_explode(player.bid, req['hand_tool_id'])
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

        if (
            player.last_grenade_unique_id
            and player.last_grenade_timeout_uid != player.last_grenade_unique_id
        ):
            timeout_rsp = build_rsp_grenade_time_out(player.last_grenade_unique_id)
            ntf = build_req_grenade_explosive_pos_ntf(
                player.last_grenade_unique_id,
                0,
                player.last_grenade_pos,
            )
            if session:
                session.broadcast(ntf)
                session.broadcast(timeout_rsp)
            else:
                sock.sendall(ntf)
                sock.sendall(timeout_rsp)
            _log(
                f"sent RspGrenadeTimeOut grenade_id={player.last_grenade_unique_id} "
                f"via ReqCharacterActionExplode to {peer}"
            )
            _log(
                f"sent ReqGrenadeExplosivePosNtf grenade_id={player.last_grenade_unique_id} "
                f"remain=0 via ReqCharacterActionExplode to {peer}"
            )
            player.last_grenade_timeout_uid = player.last_grenade_unique_id

        explosion_damage_packets = _session_collect_explosive_structure_damage_packets(
            session,
            player,
            damage_source=player.last_grenade_pos,
            _log=_log,
        )
        if explosion_damage_packets:
            _session_send_packets(session, sock, explosion_damage_packets)

        state_source = session.game_state if session is not None else {}
        if _is_guide_mode_game_state(state_source):
            explosive_scene_tool_uid = int(
                player.guide_c4_scene_tool_unique_id
                or player.last_place_scene_tool_unique_id
                or player.last_scene_tool_unique_id
                or 0
            ) & 0xFFFFFFFFFFFFFFFF

            if explosive_scene_tool_uid > 0:
                delete_rsp = build_rsp_delete_scene_tool(
                    scene_tool_unique_id=explosive_scene_tool_uid,
                    kind=SCENE_TOOL_DELETE_KIND_USED,
                    attacker_bid=player.bid,
                    effect_type=EFFECT_TYPE_EXPLOSIVE,
                )
                _session_mark_scene_tool_ended(session, explosive_scene_tool_uid)
                _session_send_packets(session, sock, [delete_rsp])
                _log(
                    "guide: sent RspDeleteSceneTool "
                    f"uid={explosive_scene_tool_uid} kind={SCENE_TOOL_DELETE_KIND_USED} "
                    f"attacker_bid={player.bid} effect={EFFECT_TYPE_EXPLOSIVE}"
                )
            else:
                _log("guide: skip RspDeleteSceneTool reason=no_scene_tool_uid")

            if not bool(player.guide_scripted_remote_kill_done):
                enemy_bid = _select_guide_enemy_bid(player)
                damage_source = _coerce_vector3_tuple(player.last_character_pos)
                kill_packets = [
                    build_rsp_event_character_enemy_explosive_hurt(
                        source_bid=player.bid,
                        target_bid=enemy_bid,
                        base_hp=0,
                        extra_hp=0,
                        explosive_pos=damage_source,
                    ),
                    build_rsp_character_hp_changed(
                        bid=enemy_bid,
                        base_hp=0,
                        extra_hp=0,
                        damage_type=EFFECT_TYPE_EXPLOSIVE,
                        damage_source=damage_source,
                    ),
                    build_rsp_player_death(
                        bid=enemy_bid,
                        item_uid=0,
                        attacker_bid=player.bid,
                        damage_type=EFFECT_TYPE_EXPLOSIVE,
                        pos=damage_source,
                    ),
                ]
                _session_send_packets(session, sock, kill_packets)
                _log(
                    "guide: scripted explosive enemy death "
                    f"target_bid={enemy_bid} attacker_bid={player.bid} "
                    f"src=({damage_source[0]:.2f},{damage_source[1]:.2f},{damage_source[2]:.2f})"
                )

                player.guide_scripted_remote_kill_done = True
                player.guide_pending_points.append({
                    'action': POINT_ACTION_KILL_ENEMY_REMOTE_BOMB,
                    'point': 100,
                })
                _log(
                    "guide: queued game points "
                    f"action={POINT_ACTION_KILL_ENEMY_REMOTE_BOMB} point=100"
                )

                if session is not None:
                    session.guide_pending_only_attackers_state = True
                    # Let client process OnlyDefenders->BothPlayers first, then
                    # advance to OnlyAttackers on the next movement/combat sync.
                    session.guide_pending_only_attackers_at = time.time() + 0.75

                if _guide_get_critical_region_state(session) == CRITICAL_REGION_STATE_ONLY_DEFENDERS:
                    _guide_push_critical_region_state(
                        session,
                        sock,
                        state=CRITICAL_REGION_STATE_BOTH_PLAYERS,
                        _log=_log,
                        reason="post_explosive_remote_kill",
                    )
    return session, player


def _v2_handle_req_character_operate_explosive(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_operate_explosive(stream)
    _log(f"ReqCharacterOperateExplosive op={req['op']} pos={req['pos']} yaw={req['yaw']:.2f} from {peer}")
    if player:
        player.last_character_pos = _coerce_vector3_tuple(req.get('pos'))
        rsp = build_rsp_character_operate_explosive(
            player.bid,
            req['pose'],
            req['pos'],
            req['yaw'],
            req['op'],
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
    return session, player


def _v2_handle_req_character_install_reinforced(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_character_install_reinforced(stream)
    _log(f"ReqCharacterInstallReinforced id={req['reinforced_id']} from {peer}")
    if player and session:
        _session_apply_reinforced_install(session, req['reinforced_id'], player.bid)

    if player:
        rsp = build_rsp_character_install_reinforced(
            player.bid,
            req['pose'],
            req['reinforced_id'],
        )
        state_rsp = build_rsp_reinforced_state_update(
            req['reinforced_id'],
            player.bid,
            REINFORCED_STATE_ACTIVED1,
        )
        if session:
            session.broadcast(rsp)
            session.broadcast(state_rsp)
        else:
            sock.sendall(rsp)
            sock.sendall(state_rsp)
    return session, player


def _v2_handle_req_change_reinforced_state(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_change_reinforced_state(stream)
    _log(f"ReqChangeReinforcedState id={req['id']} state={req['state']} from {peer}")
    owner_bid = player.bid if player else 0
    if session is None:
        rsp = build_rsp_reinforced_state_update(req['id'], owner_bid, req['state'])
        sock.sendall(rsp)
    elif _session_apply_reinforced_state_change(session, req['id'], req['state'], owner_bid):
        rsp = build_rsp_reinforced_state_update(req['id'], owner_bid, req['state'])
        session.broadcast(rsp)
    else:
        err_rsp = build_rsp_change_reinforced_state_error(req['id'])
        sock.sendall(err_rsp)
    return session, player


def _v2_handle_req_destroy_blocking_board(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    req = parse_req_destroy_blocking_board(stream)
    board_id_raw: int = int(req['board_id']) & 0xFFFFFFFF
    damage_source: tuple[float, float, float] = req['damage_source']

    _log(
        f"ReqDestroyBlockingBoard board_id={board_id_raw} "
        f"src={damage_source} from {peer}"
    )

    packets = _session_collect_blocking_board_damage_packets(
        session,
        destroy_type=DESTROY_TYPE_HAMMER_DAMAGE,
        damage_source=damage_source,
        preferred_board_id=board_id_raw,
        hit_count=1,
        target_block_indices=None,
        ray_samples=None,
        _log=_log,
    )
    if packets:
        _session_send_packets(session, sock, packets)
    else:
        _log(
            f"DestroyBlockingBoard noop board_id={board_id_raw} "
            f"src={damage_source}"
        )

    return session, player


def _v2_handle_req_wall_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    parse_req_wall_info(stream)
    rsp = build_rsp_wall_info(_session_snapshot_broken_walls(session))
    sock.sendall(rsp)
    _log("ReqWallInfo snapshot sent")
    return session, player


def _v2_handle_req_dynamic_wall_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    parse_req_dynamic_wall_info(stream)
    rsp = build_rsp_dynamic_wall_info(_session_snapshot_dynamic_walls(session))
    sock.sendall(rsp)
    _log("ReqDynamicWallInfo snapshot sent")
    return session, player


def _v2_handle_req_reinforced_wall_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    parse_req_reinforced_wall_info(stream)
    walls, items = _session_snapshot_reinforced_walls(session)
    rsp = build_rsp_reinforced_wall_info(walls, items)
    sock.sendall(rsp)
    _log("ReqReinforcedWallInfo snapshot sent")
    return session, player


def _v2_handle_req_simple_quintain_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    parse_req_simple_quintain_info(stream)
    create_packets = _session_collect_training_target_create_packets(session)
    if create_packets:
        _session_send_packets(session, sock, create_packets)
    relive_packets = _session_collect_training_target_relive_packets(session)
    if relive_packets:
        _session_send_packets(session, sock, relive_packets)
    snapshot_packets = _session_collect_training_target_snapshot_packets(session)
    if snapshot_packets:
        _session_send_packets(session, sock, snapshot_packets)
        _log(
            "ReqSimpleQuintainInfo handled "
            f"snapshot_packets={len(snapshot_packets)}"
        )
    return session, player


def _v2_handle_req_pillar_group_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_pillar_group_info(stream)
    sock.sendall(build_rsp_pillar_group_info())
    return session, player


def _v2_handle_req_security_camera_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_security_camera_info(stream)
    sock.sendall(build_rsp_security_camera_info())
    return session, player


def _v2_handle_req_game_player_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_game_player_info(stream)
    sock.sendall(build_rsp_game_player_info())
    return session, player


def _v2_handle_req_vehicle_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_vehicle_info(stream)
    sock.sendall(build_rsp_vehicle_info())
    return session, player


def _v2_handle_req_simple_scene_item_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data

    parse_req_simple_scene_item_info(stream)
    # IMPORTANT:
    # RspSimpleSceneItemInfo on this client clears existing runtime scene props first.
    # Until we can reconstruct a full authoritative scene-item list for each map,
    # replying with a partial subset causes regressions (missing objects/wrong props).
    # Keep scene-item state from map assets and only sync damage state packets.
    packets: list[bytes] = []
    packets.extend(_session_collect_training_target_create_packets(session))
    packets.extend(_session_collect_training_target_relive_packets(session))
    packets.extend(_session_collect_training_target_snapshot_packets(session))
    if packets:
        _session_send_packets(session, sock, packets)
    _log(
        "ReqSimpleSceneItemInfo handled "
        f"scene_items_reply=skipped snapshot_packets={len(packets)}"
    )
    return session, player


def _v2_handle_req_armor_package_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_armor_package_info(stream)
    sock.sendall(build_rsp_armor_package_info(session))
    return session, player


def _v2_handle_req_electric_box_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_electric_box_info(stream)
    sock.sendall(build_rsp_electric_box_info())
    return session, player


def _v2_handle_req_mounted_lmg_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_mounted_lmg_info(stream)
    sock.sendall(build_rsp_mounted_lmg_info())
    return session, player


def _v2_handle_req_buff_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del peer, battle_id, game_state, player_data, _log

    parse_req_buff_info(stream)
    sock.sendall(build_rsp_buff_info())
    return session, player


def _v2_handle_req_game_info(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del player_data

    _handle_req_game_info(
        stream,
        sock,
        peer,
        battle_id,
        game_state,
        _log,
        session,
        player,
    )
    return session, player


def _v2_handle_req_leave_battle(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    _handle_req_leave_battle(
        stream,
        sock,
        peer,
        _log,
        session=session,
        player=player,
    )
    return session, player


def _v2_handle_req_players_result(
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    del battle_id, game_state, player_data

    _handle_req_players_result(stream, sock, peer, _log)
    return session, player


_AUTOGEN_NOOP_OK_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_NOOP_UNSUPPORTED_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_NOOP_FAIL_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_NOOP_LEGACY_SKIP_LOGGED: set[int] = set()
_AUTOGEN_RUNTIME_OK_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_RUNTIME_UNSUPPORTED_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_RUNTIME_FAIL_LOGGED: set[tuple[int, str]] = set()
_AUTOGEN_RUNTIME_COUNT_BY_ID: dict[int, int] = {}

# Some packets are still implemented in legacy _process_packet with non-trivial
# side effects (gameplay state updates/pushes). Keep legacy semantics until v2
# handlers are migrated one-by-one.
AUTOGEN_NOOP_PREFER_LEGACY_IDS: set[int] = {
    PKT_REQ_CHARACTER_JUMP_OVER,
    PKT_REQ_CHARACTER_THROW_ROPE,
    PKT_REQ_CHARACTER_INTO_WALL_SPACE,
    PKT_REQ_CHARACTER_LEAVE_WALL_SPACE,
    PKT_REQ_CHARACTER_CHANGE_POSE_IN_WALL,
    PKT_REQ_CHARACTER_ACTION_MELEE_ATTACK,
    PKT_REQ_CHARACTER_ACTION_TILT,
    PKT_REQ_CHARACTER_MELEE_ATTACK,
    PKT_REQ_CHARACTER_ACTION_AIMING,
    PKT_REQ_SWITCH_CURRENT_MONITOR,
    PKT_REQ_CANCEL_THROW_GRENADE,
    PKT_REQ_CHARACTER_OPERATION,
    PKT_REQ_OPERATE_TOOL,
    PKT_REQ_PLACE_TOOL_OPERATOR,
    PKT_REQ_CREATE_PLACE_SCENE_TOOL,
    PKT_REQ_USE_SCENE_TOOL,
    PKT_REQ_MOVE_TO_INTO_SCENE_TOOL,
    PKT_REQ_LEAVE_SCENE_TOOL,
    PKT_REQ_INTO_SCENE_TOOL,
    PKT_REQ_OPERATE_GUN_RELOAD,
    PKT_REQ_SYNC_PERFORM_DATA,
    PKT_REQ_GROUND_MATERIAL,
    PKT_REQ_PLAYER_MARK,
    PKT_REQ_SYNC_CHARACTER_TOOL,
    PKT_REQ_QUICK_CHAT,
    PKT_REQ_WALL_INFO,
    PKT_REQ_DYNAMIC_WALL_INFO,
    PKT_REQ_REINFORCED_WALL_INFO,
}


def _try_dispatch_autogen_noop(
    *,
    descriptor: PacketDescriptor,
    pkt_id: int,
    phase: str,
    stream: InputStream,
    _log: Callable,
) -> bool:
    packet_class = str(descriptor.parser_key or '').strip()
    if not packet_class:
        return False

    key = (int(pkt_id), packet_class)
    if not is_payload_decoder_supported(packet_class):
        if key not in _AUTOGEN_NOOP_UNSUPPORTED_LOGGED:
            _AUTOGEN_NOOP_UNSUPPORTED_LOGGED.add(key)
            _log(
                "parser_v2 autogen_noop unsupported "
                f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class}"
            )
        return False

    start_pos = stream.pos
    try:
        decode_battle_payload_autogen(
            packet_class,
            stream,
            helpers=BATTLE_PAYLOAD_DECODER_HELPERS,
        )
    except NeedMoreData:
        raise
    except Exception as exc:  # noqa: BLE001
        stream._pos = start_pos
        if key not in _AUTOGEN_NOOP_FAIL_LOGGED:
            _AUTOGEN_NOOP_FAIL_LOGGED.add(key)
            _log(
                "parser_v2 autogen_noop decode fail "
                f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class} err={exc}"
            )
        return False

    if key not in _AUTOGEN_NOOP_OK_LOGGED:
        _AUTOGEN_NOOP_OK_LOGGED.add(key)
        _log(
            "parser_v2 autogen_noop active "
            f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class}"
        )

    return True


def _try_dispatch_autogen_runtime(
    *,
    descriptor: PacketDescriptor,
    pkt_id: int,
    phase: str,
    stream: InputStream,
    _log: Callable,
) -> bool:
    packet_class = str(descriptor.parser_key or '').strip()
    if not packet_class:
        return False

    key = (int(pkt_id), packet_class)
    if not is_payload_decoder_supported(packet_class):
        if key not in _AUTOGEN_RUNTIME_UNSUPPORTED_LOGGED:
            _AUTOGEN_RUNTIME_UNSUPPORTED_LOGGED.add(key)
            _log(
                "parser_v2 autogen_runtime unsupported "
                f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class}"
            )
        return False

    start_pos = stream.pos
    try:
        decoded = decode_battle_payload_autogen(
            packet_class,
            stream,
            helpers=BATTLE_PAYLOAD_DECODER_HELPERS,
        )
    except NeedMoreData:
        raise
    except Exception as exc:  # noqa: BLE001
        stream._pos = start_pos
        if key not in _AUTOGEN_RUNTIME_FAIL_LOGGED:
            _AUTOGEN_RUNTIME_FAIL_LOGGED.add(key)
            _log(
                "parser_v2 autogen_runtime decode fail "
                f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class} err={exc}"
            )
        return False

    _AUTOGEN_RUNTIME_COUNT_BY_ID[pkt_id] = _AUTOGEN_RUNTIME_COUNT_BY_ID.get(pkt_id, 0) + 1
    if key not in _AUTOGEN_RUNTIME_OK_LOGGED:
        _AUTOGEN_RUNTIME_OK_LOGGED.add(key)
        decoded_keys = sorted(decoded.keys())[:8] if isinstance(decoded, dict) else []
        _log(
            "parser_v2 autogen_runtime active "
            f"pkt_id=0x{pkt_id:X} phase={phase} class={packet_class} "
            f"keys={','.join(decoded_keys)}"
        )

    return True


def _try_dispatch_legacy_bridge(
    *,
    pkt_id: int,
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[BattleSession | None, BattlePlayer | None]:
    consumed = _process_packet(
        pkt_id,
        stream,
        sock,
        peer,
        battle_id,
        game_state,
        player_data,
        _log,
        session_holder=[session],
        player_holder=[player],
        drain_unknown=False,
    )
    next_session = consumed.get('session', session)
    next_player = consumed.get('player', player)
    return next_session, next_player


BATTLE_V2_HANDLER_TABLE = {
    'req_ping_or_pose': _v2_handle_req_ping_or_pose,
    'req_enter_battle': _v2_handle_req_enter_battle,
    'req_load_progress': _v2_handle_req_load_progress,
    'req_room_loaded': _v2_handle_req_room_loaded,
    'req_character_state': _v2_handle_req_character_state,
    'req_character_jump_on': _v2_handle_req_character_jump_on,
    'req_character_leave_wall_space_by_window': _v2_handle_req_character_leave_wall_space_by_window,
    'req_character_gun_fire': _v2_handle_req_character_gun_fire,
    'req_character_action_melee_attack': _v2_handle_req_character_action_melee_attack,
    'req_character_melee_attack': _v2_handle_req_character_melee_attack,
    'req_character_lerp_pos': _v2_handle_req_character_lerp_pos,
    'req_character_operate_shield': _v2_handle_req_character_operate_shield,
    'req_shield_state_update': _v2_handle_req_shield_state_update,
    'req_destroy_scene_object': _v2_handle_req_destroy_scene_object,
    'req_character_action_take_out_pad': _v2_handle_req_character_action_take_out_pad,
    'req_scan_enemies': _v2_handle_req_scan_enemies,
    'req_sync_character_action': _v2_handle_req_sync_character_action,
    'req_grenade_begin': _v2_handle_req_grenade_begin,
    'req_throw_grenade_end': _v2_handle_req_throw_grenade_end,
    'req_grenade_explosive_pos_report': _v2_handle_req_grenade_explosive_pos_report,
    'req_grenade_explosive_pos_ntf': _v2_handle_req_grenade_explosive_pos_ntf,
    'req_bomb_explosive': _v2_handle_req_bomb_explosive,
    'req_throw_scene_tool': _v2_handle_req_throw_scene_tool,
    'req_sync_throw_scene_tool_position': _v2_handle_req_sync_throw_scene_tool_position,
    'req_report_throw_scene_tool_final_position': _v2_handle_req_report_throw_scene_tool_final_position,
    'req_report_throw_scene_tool_final_position_with_relation': _v2_handle_req_report_throw_scene_tool_final_position_with_relation,
    'req_get_back_place_scene_tool': _v2_handle_req_get_back_place_scene_tool,
    'req_get_back_place_scene_tool_operator': _v2_handle_req_get_back_place_scene_tool_operator,
    'req_sync_player_state': _v2_handle_req_sync_player_state,
    'req_use_place_scene_tool_operator': _v2_handle_req_use_place_scene_tool_operator,
    'req_sync_item_state': _v2_handle_req_sync_item_state,
    'req_operate_scene': _v2_handle_req_operate_scene,
    'req_kill_me': _v2_handle_req_kill_me,
    'req_shock_grenade_bomb': _v2_handle_req_shock_grenade_bomb,
    'req_sync_character_weapon_state': _v2_handle_req_sync_character_weapon_state,
    'req_sync_character_assist_tool': _v2_handle_req_sync_character_assist_tool,
    'req_sync_stretch_hand_shield_state': _v2_handle_req_sync_stretch_hand_shield_state,
    'req_sync_hand_shield_state': _v2_handle_req_sync_hand_shield_state,
    'req_trigger_flash_hand_shield': _v2_handle_req_trigger_flash_hand_shield,
    'req_gen_robot': _v2_handle_req_gen_robot,
    'req_switch_current_unmanned_vehicle': _v2_handle_req_switch_current_unmanned_vehicle,
    'req_unmanned_vehicle_spawn': _v2_handle_req_unmanned_vehicle_spawn,
    'req_unmanned_vehicle_pose_delta': _v2_handle_req_unmanned_vehicle_pose_delta,
    'req_unmanned_vehicle_take_back': _v2_handle_req_unmanned_vehicle_take_back,
    'req_switch_unmanned_vehicle_to_character': _v2_handle_req_switch_unmanned_vehicle_to_character,
    'req_monitor_scan_enemies': _v2_handle_req_monitor_scan_enemies,
    'req_switch_current_monitor': _v2_handle_req_switch_current_monitor,
    'req_switch_monitor_to_character': _v2_handle_req_switch_monitor_to_character,
    'req_monitor_pose_delta': _v2_handle_req_monitor_pose_delta,
    'req_found_critical_target': _v2_handle_req_found_critical_target,
    'req_found_bomb_target': _v2_handle_req_found_bomb_target,
    'req_found_defuser': _v2_handle_req_found_defuser,
    'req_notify_defuser_state': _v2_handle_req_notify_defuser_state,
    'req_pick_up_defuser': _v2_handle_req_pick_up_defuser,
    'req_drop_defuser': _v2_handle_req_drop_defuser,
    'req_add_robot': _v2_handle_req_add_robot,
    'req_operate_battle': _v2_handle_req_operate_battle,
    'req_robot_move': _v2_handle_req_robot_move,
    'req_robot_fire': _v2_handle_req_robot_fire,
    'req_character_climb_ladder': _v2_handle_req_character_climb_ladder,
    'req_character_leave_ladder': _v2_handle_req_character_leave_ladder,
    'req_bomb_gun_fire': _v2_handle_req_bomb_gun_fire,
    'req_bomb_bullet_state': _v2_handle_req_bomb_bullet_state,
    'req_vehicle_launch_tracker': _v2_handle_req_vehicle_launch_tracker,
    'req_active_tracker': _v2_handle_req_active_tracker,
    'req_disturbed_operate': _v2_handle_req_disturbed_operate,
    'req_character_hammer_attack': _v2_handle_req_character_hammer_attack,
    'req_character_action_hammer_attack': _v2_handle_req_character_action_hammer_attack,
    'req_client_cheat_report': _v2_handle_req_client_cheat_report,
    'req_character_action_install_trap_bomb': _v2_handle_req_character_action_install_trap_bomb,
    'req_trap_bomb_installed': _v2_handle_req_trap_bomb_installed,
    'req_character_action_uninstall_trap_bomb': _v2_handle_req_character_action_uninstall_trap_bomb,
    'req_trap_bomb_uninstalled': _v2_handle_req_trap_bomb_uninstalled,
    'req_trigger_trap_bomb': _v2_handle_req_trigger_trap_bomb,
    'req_throw_item': _v2_handle_req_throw_item,
    'req_item_pos_report': _v2_handle_req_item_pos_report,
    'req_throw_item_drop_down': _v2_handle_req_throw_item_drop_down,
    'req_throw_item_stoped': _v2_handle_req_throw_item_stoped,
    'req_game_points': _v2_handle_req_game_points,
    'req_operate_character': _v2_handle_req_operate_character,
    'req_throw_neuro_toxin': _v2_handle_req_throw_neuro_toxin,
    'req_sync_neuro_toxin_position': _v2_handle_req_sync_neuro_toxin_position,
    'req_throw_neuro_toxin_end': _v2_handle_req_throw_neuro_toxin_end,
    'req_remove_neuro_toxin_operator': _v2_handle_req_remove_neuro_toxin_operator,
    'req_remove_neuro_toxin_effect': _v2_handle_req_remove_neuro_toxin_effect,
    'req_get_back_neuro_toxin_operator': _v2_handle_req_get_back_neuro_toxin_operator,
    'req_get_back_neuro_toxin_tool': _v2_handle_req_get_back_neuro_toxin_tool,
    'req_character_operate_blocking_board': _v2_handle_req_character_operate_blocking_board,
    'req_change_blocking_board_state': _v2_handle_req_change_blocking_board_state,
    'req_character_action_explode': _v2_handle_req_character_action_explode,
    'req_character_operate_explosive': _v2_handle_req_character_operate_explosive,
    'req_character_install_reinforced': _v2_handle_req_character_install_reinforced,
    'req_change_reinforced_state': _v2_handle_req_change_reinforced_state,
    'req_destroy_blocking_board': _v2_handle_req_destroy_blocking_board,
    'req_wall_info': _v2_handle_req_wall_info,
    'req_dynamic_wall_info': _v2_handle_req_dynamic_wall_info,
    'req_reinforced_wall_info': _v2_handle_req_reinforced_wall_info,
    'req_simple_quintain_info': _v2_handle_req_simple_quintain_info,
    'req_pillar_group_info': _v2_handle_req_pillar_group_info,
    'req_security_camera_info': _v2_handle_req_security_camera_info,
    'req_game_player_info': _v2_handle_req_game_player_info,
    'req_vehicle_info': _v2_handle_req_vehicle_info,
    'req_simple_scene_item_info': _v2_handle_req_simple_scene_item_info,
    'req_armor_package_info': _v2_handle_req_armor_package_info,
    'req_electric_box_info': _v2_handle_req_electric_box_info,
    'req_mounted_lmg_info': _v2_handle_req_mounted_lmg_info,
    'req_buff_info': _v2_handle_req_buff_info,
    'req_game_info': _v2_handle_req_game_info,
    'req_leave_battle': _v2_handle_req_leave_battle,
    'req_players_result': _v2_handle_req_players_result,
    'pkt_heartbeat': _v2_handle_pkt_heartbeat,
    'pkt_version': _v2_handle_pkt_version,
    'req_reset_item_num': _v2_handle_req_reset_item_num,
}

BATTLE_V2_DIRECT_ID_HANDLER_TABLE: dict[int, Callable] = {
    PKT_REQ_CHARACTER_ACTION_MELEE_ATTACK: _v2_handle_req_character_action_melee_attack,
    PKT_REQ_CHARACTER_MELEE_ATTACK: _v2_handle_req_character_melee_attack,
    PKT_REQ_SWITCH_CURRENT_MONITOR: _v2_handle_req_switch_current_monitor,
}


def _dispatch_packet_v2(
    *,
    pkt_id: int,
    phase: str,
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session: BattleSession | None,
    player: BattlePlayer | None,
) -> tuple[bool, BattleSession | None, BattlePlayer | None, str | None]:
    direct_handler = BATTLE_V2_DIRECT_ID_HANDLER_TABLE.get(int(pkt_id))
    if direct_handler is not None:
        next_session, next_player = direct_handler(
            stream,
            sock,
            peer,
            battle_id,
            game_state,
            player_data,
            _log,
            session,
            player,
        )
        return True, next_session, next_player, None

    descriptor = BATTLE_PACKET_REGISTRY.resolve(pkt_id, phase=phase)
    if descriptor is None:
        reason = 'descriptor_missing' if _is_v2_required_packet(pkt_id, phase) else None
        return False, session, player, reason

    if descriptor.handler_key == 'autogen_noop':
        if pkt_id in AUTOGEN_NOOP_PREFER_LEGACY_IDS:
            if pkt_id not in _AUTOGEN_NOOP_LEGACY_SKIP_LOGGED:
                _AUTOGEN_NOOP_LEGACY_SKIP_LOGGED.add(pkt_id)
                _log(
                    "parser_v2 autogen_noop delegated to legacy "
                    f"pkt_id=0x{pkt_id:X} phase={phase}"
                )
            return False, session, player, None

        if _try_dispatch_autogen_noop(
            descriptor=descriptor,
            pkt_id=pkt_id,
            phase=phase,
            stream=stream,
            _log=_log,
        ):
            return True, session, player, None
        return False, session, player, None

    if descriptor.handler_key == 'legacy_bridge':
        next_session, next_player = _try_dispatch_legacy_bridge(
            pkt_id=pkt_id,
            stream=stream,
            sock=sock,
            peer=peer,
            battle_id=battle_id,
            game_state=game_state,
            player_data=player_data,
            _log=_log,
            session=session,
            player=player,
        )
        return True, next_session, next_player, None

    if descriptor.handler_key == 'req_autogen_runtime':
        if _try_dispatch_autogen_runtime(
            descriptor=descriptor,
            pkt_id=pkt_id,
            phase=phase,
            stream=stream,
            _log=_log,
        ):
            return True, session, player, None
        return False, session, player, None

    if not descriptor.handler_key:
        reason = 'handler_binding_missing' if _is_v2_required_packet(pkt_id, phase) else None
        return False, session, player, reason

    handler = BATTLE_V2_HANDLER_TABLE.get(descriptor.handler_key)
    if handler is None:
        _log(
            f"parser_v2 missing handler key={descriptor.handler_key} "
            f"pkt_id=0x{pkt_id:X} phase={phase}"
        )
        reason = 'handler_implementation_missing'
        return False, session, player, reason

    next_session, next_player = handler(
        stream,
        sock,
        peer,
        battle_id,
        game_state,
        player_data,
        _log,
        session,
        player,
    )
    return True, next_session, next_player, None


def handle_battle_connection(sock: socket.socket, addr: tuple,
                             game_state: dict, player_data: dict,
                             log_fn: Callable | None = None):
    """Handle a single battle TCP connection. Runs in its own thread."""
    _log = log_fn or (lambda msg: print(_console_safe(f"[Battle] {msg}")))
    peer = f"{addr[0]}:{addr[1]}"
    _log(f"connection from {peer}")
    _log(f"build_tag={BATTLE_SERVER_BUILD_TAG}")
    _log(
        "cfg "
        f"training_target_autodestroy_on_gunfire={int(TRAINING_TARGET_AUTODESTROY_ON_GUNFIRE)} "
        f"training_target_respawn_sec={TRAINING_TARGET_RESPAWN_SEC:.2f} "
        f"training_target_body_hits={TRAINING_TARGET_BODY_HITS_TO_DESTROY} "
        f"training_target_points_head={TRAINING_TARGET_HIT_HEAD_POINTS} "
        f"training_target_points_body={TRAINING_TARGET_HIT_BODY_POINTS}"
    )
    runtime_phase = 'loading'
    close_reason = 'loop_end'
    close_detail = ''
    total_recv_bytes = 0
    recv_chunks = 0
    last_pkt_id: int | None = None
    last_pkt_phase = 'loading'
    last_pkt_ts = 0.0
    last_out_pkt_id: int | None = None
    last_out_pkt_ts = 0.0
    tx_tail: list[str] = []

    def _track_outgoing(data: bytes, via: str = 'sock') -> None:
        nonlocal last_out_pkt_id, last_out_pkt_ts, tx_tail, runtime_phase
        pkt_id = _try_decode_pkt_id_from_frame(data)
        marker = f"?/{len(data)}"
        if pkt_id is not None:
            last_out_pkt_id = int(pkt_id)
            last_out_pkt_ts = time.time()
            marker = f"0x{int(pkt_id):X}/{len(data)}"
            if int(pkt_id) != PKT_HEARTBEAT:
                _log(
                    f"tx pkt_id=0x{int(pkt_id):X} len={len(data)} "
                    f"via={via} phase={runtime_phase}"
                )
        tx_tail.append(f"{marker}@{via}")
        if len(tx_tail) > 12:
            tx_tail = tx_tail[-12:]

    class _TrackedSocket:
        def __init__(self, raw_sock: socket.socket):
            self._raw_sock = raw_sock

        def sendall(self, data: bytes) -> None:
            _track_outgoing(data, 'sock')
            self._raw_sock.sendall(data)

        def __getattr__(self, name: str):
            return getattr(self._raw_sock, name)

    sock = _TrackedSocket(sock)

    try:
        # Step 1: Send encryption flag (0x00 = no encryption)
        sock.sendall(b'\x00')
        _log(f"sent encryption flag 0x00 (no encryption) to {peer}")
        _log(f"game_state: camp={game_state.get('camp')}, map_id={game_state.get('map_id')}, "
             f"mode_id={game_state.get('mode_id')}, char_id={game_state.get('character_id')}")

        sock.settimeout(60.0)
        recv_buf = bytearray()
        session: BattleSession | None = None
        player: BattlePlayer | None = None
        battle_id = game_state.get('battle_id', 1)

        runtime: BattlePacketRuntime | None = None
        if BATTLE_PARSER_V2:
            _log(
                f"parser_v2 enabled descriptors={len(BATTLE_PACKET_REGISTRY)} "
                f"unique_ids={len(KNOWN_BATTLE_PACKET_IDS)}"
            )
            _log(
                "parser_v2 schema handler_keys="
                f"{len(BATTLE_V2_DESCRIPTOR_HANDLER_KEYS)}"
            )
            _log(
                "parser_v2 payload_autogen supported_classes="
                f"{len(BATTLE_PAYLOAD_DECODER_SUPPORTED_CLASSES)}"
            )
            _log(
                "parser_v2 strict_hotpath="
                f"{'on' if BATTLE_PARSER_V2_STRICT_HOTPATH else 'off'} "
                f"required_ids={len(BATTLE_V2_STRICT_HOTPATH_REQUIRED_IDS)}"
            )
            if REGISTRY_MISSING_IDS:
                missing_preview = ','.join(f"0x{v:X}" for v in sorted(REGISTRY_MISSING_IDS)[:12])
                _log(
                    f"parser_v2 registry lint missing={len(REGISTRY_MISSING_IDS)} "
                    f"preview={missing_preview}"
                )
            if REGISTRY_EXTRA_IDS:
                extra_preview = ','.join(f"0x{v:X}" for v in sorted(REGISTRY_EXTRA_IDS)[:12])
                _log(
                    f"parser_v2 registry lint extra={len(REGISTRY_EXTRA_IDS)} "
                    f"preview={extra_preview}"
                )
            if HOT_PATH_MISSING_IDS:
                hot_missing_preview = ','.join(f"0x{v:X}" for v in sorted(HOT_PATH_MISSING_IDS)[:12])
                _log(
                    f"parser_v2 hot-path lint missing={len(HOT_PATH_MISSING_IDS)} "
                    f"preview={hot_missing_preview}"
                )
            if BATTLE_V2_LOADING_HANDLER_MISSING_IDS:
                v2_loading_preview = ','.join(
                    f"0x{v:X}" for v in sorted(BATTLE_V2_LOADING_HANDLER_MISSING_IDS)[:12]
                )
                _log(
                    f"parser_v2 handler lint loading-missing="
                    f"{len(BATTLE_V2_LOADING_HANDLER_MISSING_IDS)} "
                    f"preview={v2_loading_preview}"
                )
            if BATTLE_V2_GAMEPLAY_HANDLER_MISSING_IDS:
                v2_gameplay_preview = ','.join(
                    f"0x{v:X}" for v in sorted(BATTLE_V2_GAMEPLAY_HANDLER_MISSING_IDS)[:12]
                )
                _log(
                    f"parser_v2 handler lint gameplay-missing="
                    f"{len(BATTLE_V2_GAMEPLAY_HANDLER_MISSING_IDS)} "
                    f"preview={v2_gameplay_preview}"
                )
            if BATTLE_V2_ANY_HANDLER_MISSING_IDS:
                v2_any_preview = ','.join(
                    f"0x{v:X}" for v in sorted(BATTLE_V2_ANY_HANDLER_MISSING_IDS)[:12]
                )
                _log(
                    f"parser_v2 handler lint any-missing="
                    f"{len(BATTLE_V2_ANY_HANDLER_MISSING_IDS)} "
                    f"preview={v2_any_preview}"
                )
            if REGISTRY_PHASE_ISSUES:
                _log(f"parser_v2 overlap-phase lint issues={len(REGISTRY_PHASE_ISSUES)}")
                for issue in REGISTRY_PHASE_ISSUES[:8]:
                    _log(f"parser_v2 overlap-phase issue: {issue}")
            if (
                not HOT_PATH_MISSING_IDS
                and not REGISTRY_PHASE_ISSUES
                and not BATTLE_V2_LOADING_HANDLER_MISSING_IDS
                and not BATTLE_V2_GAMEPLAY_HANDLER_MISSING_IDS
                and not BATTLE_V2_ANY_HANDLER_MISSING_IDS
            ):
                _log(
                    f"parser_v2 hot-path lint ok ids={len(BATTLE_HOT_PATH_PACKET_IDS)} "
                    "overlap-phase=ok handlers=ok"
                )

            def _runtime_handler(pkt_id: int, stream: InputStream):
                nonlocal session, player, runtime_phase
                nonlocal last_pkt_id, last_pkt_phase, last_pkt_ts
                last_pkt_id = int(pkt_id)
                last_pkt_phase = runtime_phase
                last_pkt_ts = time.time()
                handled, next_session, next_player, reason = _dispatch_packet_v2(
                    pkt_id=pkt_id,
                    phase=runtime_phase,
                    stream=stream,
                    sock=sock,
                    peer=peer,
                    battle_id=battle_id,
                    game_state=game_state,
                    player_data=player_data,
                    _log=_log,
                    session=session,
                    player=player,
                )
                if handled:
                    session = next_session
                    player = next_player
                    return

                if (
                    reason
                    and BATTLE_PARSER_V2_STRICT_HOTPATH
                    and _is_v2_required_packet(pkt_id, runtime_phase)
                ):
                    raise RuntimeError(
                        f"V2_HOTPATH_FAIL reason={reason} "
                        f"pkt_id=0x{pkt_id:X} phase={runtime_phase}"
                    )

                consumed = _process_packet(
                    pkt_id, stream, sock, peer, battle_id,
                    game_state, player_data, _log,
                    session_holder=[session],
                    player_holder=[player],
                )
                session = consumed.get('session', session)
                player = consumed.get('player', player)

            runtime = BattlePacketRuntime(
                cuint_decode=cuint_decode,
                stream_factory=InputStream,
                packet_handler=_runtime_handler,
                need_more_exc=NeedMoreData,
                registry=BATTLE_PACKET_REGISTRY,
            )
        else:
            _log(
                "parser_v2 disabled; set BATTLE_PARSER_V2=1 "
                "to use stateful-v2 handlers"
            )

        while True:
            if session:
                session.tick()
            try:
                data = sock.recv(4096)
            except TimeoutError:
                if session:
                    session.tick()
                continue
            except OSError as os_exc:
                close_reason = 'recv_oserror'
                close_detail = repr(os_exc)
                break

            if not data:
                close_reason = 'peer_eof'
                break

            total_recv_bytes += len(data)
            recv_chunks += 1
            recv_buf.extend(data)
            _log(f"recv {len(data)}B from {peer}, buf={len(recv_buf)}, hex={data[:32].hex()}")

            # Process all complete packets in buffer
            while len(recv_buf) > 0:
                if runtime is not None:
                    runtime_phase = 'gameplay' if (session and session._started) else 'loading'
                    parse_result = runtime.parse_one(recv_buf, phase=runtime_phase)
                    if parse_result.status == ParseStatus.NEED_MORE_DATA:
                        break

                    if parse_result.status == ParseStatus.OK:
                        bytes_consumed = int(parse_result.bytes_consumed)
                        if bytes_consumed <= 0 or bytes_consumed > len(recv_buf):
                            _log(
                                f"parser_v2 invalid consumption pkt_id={parse_result.packet_id} "
                                f"consumed={bytes_consumed} buf={len(recv_buf)}"
                            )
                            recv_buf.clear()
                            break
                        recv_buf = recv_buf[bytes_consumed:]
                        continue

                    if parse_result.status == ParseStatus.UNKNOWN_PACKET:
                        is_required = (
                            parse_result.packet_id is not None
                            and _is_v2_required_packet(
                                int(parse_result.packet_id),
                                parse_result.phase,
                            )
                        )
                        if BATTLE_PARSER_V2_STRICT_HOTPATH and is_required:
                            close_reason = 'parser_v2_descriptor_missing'
                            close_detail = (
                                f"pkt=0x{int(parse_result.packet_id):X} "
                                f"phase={parse_result.phase}"
                            )
                            _log(
                                "parser_v2 hard-fail reason=descriptor_missing "
                                f"pkt_id=0x{int(parse_result.packet_id):X} "
                                f"phase={parse_result.phase} from {peer}"
                            )
                            return

                        # parser_v2 registry can lag behind legacy handlers.
                        # Probe legacy path for this packet id before dropping buffer.
                        fallback_consumed = 0
                        if parse_result.packet_id is not None:
                            fallback_stream = InputStream(
                                bytes(recv_buf),
                                int(parse_result.header_size or 0),
                            )
                            try:
                                consumed = _process_packet(
                                    int(parse_result.packet_id),
                                    fallback_stream,
                                    sock,
                                    peer,
                                    battle_id,
                                    game_state,
                                    player_data,
                                    _log,
                                    session_holder=[session],
                                    player_holder=[player],
                                    drain_unknown=False,
                                )
                                session = consumed.get('session', session)
                                player = consumed.get('player', player)
                            except NeedMoreData:
                                break
                            except Exception as fallback_exc:
                                _log(
                                    "parser_v2 legacy-fallback error "
                                    f"pkt_id={parse_result.packet_id}: {fallback_exc}"
                                )
                            else:
                                fallback_consumed = int(
                                    getattr(fallback_stream, 'pos', 0) or 0
                                )

                        if fallback_consumed > int(parse_result.header_size or 0):
                            if fallback_consumed > len(recv_buf):
                                _log(
                                    "parser_v2 legacy-fallback invalid consumption "
                                    f"pkt_id={parse_result.packet_id} "
                                    f"consumed={fallback_consumed} buf={len(recv_buf)}"
                                )
                                recv_buf.clear()
                                break
                            _log(
                                "parser_v2 legacy-fallback consumed "
                                f"pkt_id={parse_result.packet_id} bytes={fallback_consumed}"
                            )
                            recv_buf = recv_buf[fallback_consumed:]
                            continue

                        _log(
                            f"parser_v2 unknown pkt_id={parse_result.packet_id} "
                            f"phase={parse_result.phase} desc={parse_result.descriptor_name or '-'} "
                            f"msg={parse_result.message} from {peer}"
                        )
                        recv_buf.clear()
                        break

                    if (
                        parse_result.status == ParseStatus.MALFORMED_PACKET
                        and str(parse_result.message).startswith('V2_HOTPATH_FAIL')
                    ):
                        close_reason = 'parser_v2_hotpath_fail'
                        close_detail = str(parse_result.message)
                        _log(f"parser_v2 hard-fail {parse_result.message} from {peer}")
                        return

                    _log(
                        f"error processing pkt_id={parse_result.packet_id} "
                        f"from {peer}: {parse_result.message}"
                    )
                    recv_buf.clear()
                    break

                try:
                    pkt_id, new_pos = cuint_decode(bytes(recv_buf), 0)
                except (IndexError, KeyError):
                    break  # need more data

                last_pkt_id = int(pkt_id)
                last_pkt_phase = runtime_phase
                last_pkt_ts = time.time()
                stream = InputStream(bytes(recv_buf), new_pos)

                try:
                    consumed = _process_packet(
                        pkt_id, stream, sock, peer, battle_id,
                        game_state, player_data, _log,
                        session_holder=[session],
                        player_holder=[player],
                    )
                    session = consumed.get('session', session)
                    player = consumed.get('player', player)
                except NeedMoreData:
                    # Wait for more bytes for this packet body.
                    break
                except Exception as e:
                    _log(f"error processing pkt_id={pkt_id} from {peer}: {e}")
                    # Discard buffer to avoid infinite loop on malformed data
                    recv_buf.clear()
                    break

                bytes_consumed = stream.pos
                recv_buf = recv_buf[bytes_consumed:]

    except Exception as e:
        close_reason = 'connection_exception'
        close_detail = repr(e)
        _log(f"connection error from {peer}: {e}")
    finally:
        preserve_training_rejoin = bool(
            player is not None
            and session is not None
            and getattr(player, '_preserve_on_disconnect', False)
            and _is_training_mode_game_state(session.game_state)
        )

        is_training = bool(session and _is_training_mode_game_state(session.game_state))
        if player is not None and is_training and not preserve_training_rejoin:
            try:
                game_state['in_battle'] = False
                game_state['_confirm_sent'] = False
                game_state['_last_confirm_push_ts'] = 0.0
            except Exception:
                pass
        if player and session:
            _log(
                "connection summary "
                f"bid={player.bid} uid={player.uid} loaded={int(player.loaded)} "
                f"progress={player.progress:.2f} "
                f"hb_recv={player._hb_recv_count} hb_echo={player._hb_echo_count} "
                f"preserve_rejoin={1 if preserve_training_rejoin else 0}"
            )
            if not is_training:
                # Multiplayer match: preserve player slot in session for seamless rebind/reconnect
                player.sock = None
                _log(f"player bid={player.bid} uid={player.uid} socket disconnected; slot preserved for rebind in session {battle_id}")
            elif preserve_training_rejoin:
                _log(f"player bid={player.bid} preserved in session {battle_id} for training rejoin")
            else:
                session.remove_player(player.bid, force=True)
                _log(f"player bid={player.bid} removed from session {battle_id}")
        try:
            sock.close()
        except Exception:
            pass
        if last_pkt_ts > 0:
            try:
                last_pkt_iso = datetime.datetime.fromtimestamp(last_pkt_ts).isoformat(timespec='milliseconds')
            except Exception:
                last_pkt_iso = f"{last_pkt_ts:.3f}"
        else:
            last_pkt_iso = '-'
        if last_pkt_id is None:
            last_pkt_name = '-'
        else:
            last_pkt_name = f"0x{int(last_pkt_id):X}"
        if last_out_pkt_ts > 0:
            try:
                last_out_pkt_iso = datetime.datetime.fromtimestamp(last_out_pkt_ts).isoformat(
                    timespec='milliseconds'
                )
            except Exception:
                last_out_pkt_iso = f"{last_out_pkt_ts:.3f}"
        else:
            last_out_pkt_iso = '-'
        if last_out_pkt_id is None:
            last_out_pkt_name = '-'
        else:
            last_out_pkt_name = f"0x{int(last_out_pkt_id):X}"
        tx_tail_str = ','.join(tx_tail[-8:]) if tx_tail else '-'
        _log(
            "connection close detail "
            f"reason={close_reason} detail={close_detail or '-'} "
            f"chunks={recv_chunks} bytes={total_recv_bytes} "
            f"last_pkt={last_pkt_name} phase={last_pkt_phase} "
            f"last_pkt_ts={last_pkt_iso} "
            f"last_out_pkt={last_out_pkt_name} "
            f"last_out_pkt_ts={last_out_pkt_iso} "
            f"tx_tail={tx_tail_str}"
        )
        _log(f"connection closed from {peer}")


def _process_packet(
    pkt_id: int,
    stream: InputStream,
    sock: socket.socket,
    peer: str,
    battle_id: int,
    game_state: dict,
    player_data: dict,
    _log: Callable,
    session_holder: list,
    player_holder: list,
    drain_unknown: bool = True,
) -> dict:
    """Process a single received packet. Returns dict with updated session/player refs."""
    result: dict = {}
    session: BattleSession | None = session_holder[0]
    player: BattlePlayer | None = player_holder[0]
    in_gameplay_phase = bool(session and session._started)

    if pkt_id == PKT_REQ_PING:
        req_0x01_variant = _select_req_0x01_variant(stream, in_gameplay_phase)
        if req_0x01_variant == 'pose':
            req = parse_req_character_pose(stream)
            if player:
                rsp = build_rsp_character_pose(player.bid, req['delta'])
                if session:
                    session.broadcast(rsp)
                else:
                    sock.sendall(rsp)
        else:
            req = parse_req_ping(stream)
            _log(f"ReqPing ts={req['timestamp']} from {peer}")
            sock.sendall(build_rsp_ping(req['timestamp']))

    elif pkt_id == PKT_REQ_CHARACTER_STATE:
        req = parse_req_character_state(stream)
        _maybe_log_spawn_probe(session=session, player=player, req_state=req, _log=_log)
        if player:
            pose = req.get('pose')
            if isinstance(pose, dict):
                player.last_character_pos = _coerce_vector3_tuple(pose.get('pos'))
            rsp = build_rsp_character_state(player.bid, req['pose'], req['state'], req['body_state'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_THROW_ROPE:
        req = parse_req_character_throw_rope(stream)
        if player:
            rsp = build_rsp_character_throw_rope(
                req['climb_trigger_id'],
                player.bid,
                req['pose'],
                req['desc'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_INTO_WALL_SPACE:
        req = parse_req_character_into_wall_space(stream)
        if player:
            rsp = build_rsp_character_into_wall_space(
                player.bid,
                req['desc'],
                req['wall_yaw'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_JUMP_OVER:
        req = parse_req_character_jump_over(stream)
        if player:
            rsp = build_rsp_character_jump_over(
                player.bid,
                req['pose'],
                req['desc_raw'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_LEAVE_WALL_SPACE:
        req = parse_req_character_leave_wall_space(stream)
        if player:
            rsp = build_rsp_character_leave_wall_space(
                player.bid,
                req['pose'],
                req['wall_space_raw'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_CHANGE_POSE_IN_WALL:
        req = parse_req_character_change_pose_in_wall(stream)
        if player:
            rsp = build_rsp_character_change_pose_in_wall(
                player.bid,
                req['pose'],
                req['body_state_raw'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_GUN_FIRE:
        req = parse_req_character_gun_fire(stream)
        bullets = req.get('bullets')
        bullet_count_dbg = len(bullets) if isinstance(bullets, list) else 0
        destroy_type = DESTROY_TYPE_SHOT_GUN_DAMAGE if bullet_count_dbg >= 6 else DESTROY_TYPE_GUN_DAMAGE
        _log(
            "ReqCharacterGunFire "
            f"type={int(req.get('gun_fire_type', 0)) & 0xFF} bullets={bullet_count_dbg} "
            f"{_summarize_req_gun_fire_targets(req)} from {peer}"
        )
        if player:
            rsp = build_rsp_event_character_gun_fire(player.bid, req['gun_fire_type'], req['bullets'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

            # Player-to-player gunfire hit and damage processing
            if session and isinstance(req.get('bullets'), list):
                hit_targets_for_hurt = []
                for b_entry in req['bullets']:
                    if not isinstance(b_entry, dict):
                        continue
                    tgt = b_entry.get('target_character')
                    if isinstance(tgt, dict):
                        target_bid = int(tgt.get('bid', 0))
                        if target_bid in session.players and target_bid != player.bid:
                            target_player = session.players[target_bid]
                            if not getattr(target_player, 'is_dead', False):
                                hit_targets_for_hurt.append({
                                    'target': tgt,
                                    'ray': b_entry.get('ray', {}),
                                })
                                hit_part = int(tgt.get('hit_part', 0))
                                # Headshot = 100 dmg, body/limb = 35 dmg
                                dmg_amount = 100 if hit_part == 1 else 35
                                target_player.hp = max(0, getattr(target_player, 'hp', 100) - dmg_amount)
                                _log(
                                    f"[Combat] Player bid={player.bid} ({player.name}) HIT bid={target_bid} "
                                    f"({target_player.name}) part={hit_part} damage={dmg_amount} hp={target_player.hp}"
                                )
                                hp_pkt = build_rsp_character_hp_changed(
                                    bid=target_bid,
                                    base_hp=target_player.hp,
                                    extra_hp=0,
                                    damage_type=1,
                                    damage_source=getattr(player, 'last_character_pos', (0.0, 0.0, 0.0)),
                                )
                                session.broadcast(hp_pkt)

                                if target_player.hp <= 0:
                                    target_player.is_dead = True
                                    _log(f"[Combat] Player bid={target_bid} ({target_player.name}) KILLED by bid={player.bid} ({player.name})!")
                                    death_pkt = build_rsp_player_death(
                                        bid=target_bid,
                                        item_uid=0,
                                        attacker_bid=player.bid,
                                        damage_type=1,
                                        pos=getattr(target_player, 'last_character_pos', (0.0, 0.0, 0.0)),
                                    )
                                    session.broadcast(death_pkt)

                                    # Check team elimination
                                    attackers_alive = any(
                                        not getattr(p, 'is_dead', False)
                                        for p in session.players.values()
                                        if p.camp == BATTLE_CAMP_ATTACKER
                                    )
                                    defenders_alive = any(
                                        not getattr(p, 'is_dead', False)
                                        for p in session.players.values()
                                        if p.camp == BATTLE_CAMP_DEFENDER
                                    )
                                    if not defenders_alive:
                                        _log("[Combat] All Defenders eliminated -> Attackers Win!")
                                        res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_ATTACKER)
                                        session.broadcast(res_pkt)
                                        over_pkt = build_rsp_battle_over(reason=0)
                                        session.broadcast(over_pkt)
                                    elif not attackers_alive:
                                        _log("[Combat] All Attackers eliminated -> Defenders Win!")
                                        res_pkt = build_rsp_battle_result(reason=1, win_camp=BATTLE_CAMP_DEFENDER)
                                        session.broadcast(res_pkt)
                                        over_pkt = build_rsp_battle_over(reason=0)
                                        session.broadcast(over_pkt)

                if hit_targets_for_hurt:
                    hurt_pkt = build_rsp_event_character_gun_hurt(player.bid, hit_targets_for_hurt)
                    session.broadcast(hurt_pkt)

            relive_packets = _session_collect_training_target_relive_packets(session)
            if relive_packets:
                _session_send_packets(session, sock, relive_packets)

            damage_source = _extract_gun_fire_damage_source(req)
            preferred_board_id = _extract_req_target_board_id_from_gun_fire(req)
            target_block_indices = _extract_req_target_block_indices_from_gun_fire(req)
            ray_samples = _extract_req_ray_samples_from_gun_fire(req)
            _log(
                "ReqCharacterGunFire structure-target "
                f"id={int(preferred_board_id or 0)} blocks={target_block_indices} rays={len(ray_samples)}"
            )
            if TRAINING_TARGET_AUTODESTROY_ON_GUNFIRE:
                destroy_packets = _session_destroy_first_training_target_packets(
                    session,
                    damage_source=damage_source,
                )
                if destroy_packets:
                    _session_send_packets(session, sock, destroy_packets)
                    _log(
                        f"training target destroy emitted packets={len(destroy_packets)} "
                        f"respawn_sec={TRAINING_TARGET_RESPAWN_SEC:.2f}"
                    )

            target_world_packets, target_personal_packets = _session_collect_training_target_gun_hit_packets(
                session,
                req,
                player=player,
                _log=_log,
            )
            if target_world_packets:
                _session_send_packets(session, sock, target_world_packets)
            if target_personal_packets:
                for pkt in target_personal_packets:
                    player.send_raw(pkt)

            board_damage_packets = _session_collect_structure_damage_packets(
                session,
                destroy_type=destroy_type,
                damage_source=damage_source,
                preferred_board_id=preferred_board_id,
                hit_count=1,
                target_block_indices=target_block_indices,
                ray_samples=ray_samples,
                _log=_log,
            )
            if board_damage_packets:
                _session_send_packets(session, sock, board_damage_packets)

    elif pkt_id == PKT_REQ_CHARACTER_ACTION_MELEE_ATTACK:
        req = parse_req_character_action_melee_attack(stream)
        _handle_character_action_melee_attack_common(
            req=req,
            sock=sock,
            session=session,
            player=player,
        )

    elif pkt_id == PKT_REQ_CHARACTER_ACTION_TILT:
        req = parse_req_character_action_tilt(stream)
        if player:
            rsp = build_rsp_character_action_tilt(player.bid, req['tilt_type'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_OPERATION:
        req = parse_req_character_operation(stream)
        if player:
            rsp = build_rsp_character_operation(player.bid, req['tool_index'], req['operation'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_OPERATE_TOOL:
        req = parse_req_operate_tool(stream)
        if player:
            rsp = build_rsp_operate_tool(
                player.bid,
                req['tool_index'],
                req['operation_type'],
                req['state'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SYNC_CHARACTER_ACTION:
        req = parse_req_sync_character_action(stream)
        if player:
            rsp = build_rsp_sync_character_action(
                player.bid,
                req['action'],
                req['duration'],
                req['duration_coefficient'],
            )
            if session:
                session.broadcast(rsp, exclude_bid=player.bid)
                sock.sendall(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_GAME_INFO:
        _handle_req_game_info(
            stream,
            sock,
            peer,
            battle_id,
            game_state,
            _log,
            session,
            player,
        )

    elif pkt_id == PKT_REQ_LEAVE_BATTLE:
        _handle_req_leave_battle(
            stream,
            sock,
            peer,
            _log,
            session=session,
            player=player,
        )

    elif pkt_id == PKT_REQ_SWITCH_CURRENT_UNMANNED_VEHICLE:
        req = parse_req_switch_current_unmanned_vehicle(stream)
        vehicle_id = int(req.get('vehicle_id', 0) or 0)
        if vehicle_id == 0 and player:
            vehicle_id = int(player.last_unmanned_vehicle_id or 0)
        _log(f"ReqSwitchCurrentUnmannedVehicle vehicle_id={vehicle_id} from {peer}")
        if player and vehicle_id > 0:
            player.last_unmanned_vehicle_id = vehicle_id
            rsp = build_rsp_update_unmanned_vehicle_state(
                bid=player.bid,
                vehicle_id=vehicle_id,
                relation=VEHICLE_RELATION_OPERATOR,
                need_switch_to_character=False,
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SWITCH_MONITOR_TO_CHARACTER:
        parse_req_switch_monitor_to_character(stream)
        monitor_id = int(player.last_monitor_id or 0) if player else 0
        _log(f"ReqSwitchMonitorToCharacter monitor_id={monitor_id} from {peer}")
        if player and monitor_id > 0:
            rsp = build_rsp_update_monitor_state(
                bid=player.bid,
                monitor_id=monitor_id,
                relation=MONITOR_RELATION_NONE,
                need_switch_to_character=True,
            )
            _log(
                "RspUpdateMonitorState "
                f"bid={player.bid} monitor_id={monitor_id} relation={MONITOR_RELATION_NONE} "
                "need_switch_to_character=1"
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)
            player.last_monitor_id = 0

    elif pkt_id == PKT_REQ_SWITCH_CURRENT_MONITOR:
        req = parse_req_switch_current_monitor(stream)
        monitor_id = int(req.get('monitor_id', 0) or 0)
        prev_monitor_id = int(player.last_monitor_id or 0) if player else 0
        if monitor_id == 0 and player:
            monitor_id = prev_monitor_id
        _log(f"ReqSwitchCurrentMonitor monitor_id={monitor_id} from {peer}")
        if player and monitor_id > 0:
            packets: list[bytes] = []
            if prev_monitor_id > 0 and prev_monitor_id != monitor_id:
                packets.append(
                    build_rsp_update_monitor_state(
                        bid=player.bid,
                        monitor_id=prev_monitor_id,
                        relation=MONITOR_RELATION_NONE,
                        need_switch_to_character=False,
                    )
                )
                _log(
                    "RspUpdateMonitorState "
                    f"bid={player.bid} monitor_id={prev_monitor_id} relation={MONITOR_RELATION_NONE} "
                    "need_switch_to_character=0 (clear previous monitor)"
                )
            player.last_monitor_id = monitor_id
            packets.append(
                build_rsp_update_monitor_state(
                    bid=player.bid,
                    monitor_id=monitor_id,
                    relation=MONITOR_RELATION_OPERATOR,
                    need_switch_to_character=False,
                )
            )
            _log(
                "RspUpdateMonitorState "
                f"bid={player.bid} monitor_id={monitor_id} relation={MONITOR_RELATION_OPERATOR} "
                "need_switch_to_character=0"
            )
            if session:
                for pkt in packets:
                    session.broadcast(pkt)
            else:
                for pkt in packets:
                    sock.sendall(pkt)
        else:
            rsp = build_rsp_switch_current_monitor_failed(monitor_id)
            _log(f"RspSwitchCurrentMonitorFailed monitor_id={monitor_id}")
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_UNMANNED_VEHICLE_SPAWN:
        req = parse_req_unmanned_vehicle_spawn(stream)
        vehicle_id = int(req.get('vehicle_id', 0) or 0)
        pose = req.get('pose', {}) if isinstance(req.get('pose', {}), dict) else {}
        _log(
            "ReqUnmannedVehicleSpawn "
            f"vehicle_id={vehicle_id} pos={pose.get('pos', (0.0, 0.0, 0.0))} "
            f"rot={pose.get('rot', (0.0, 0.0, 0.0))} from {peer}"
        )
        if player:
            player.last_unmanned_vehicle_id = vehicle_id
        if vehicle_id > 0:
            rsp_spawn = build_rsp_unmanned_vehicle_spawn(vehicle_id=vehicle_id, pose=pose)
            if session:
                session.broadcast(rsp_spawn)
            else:
                sock.sendall(rsp_spawn)
            if player:
                rsp_state = build_rsp_update_unmanned_vehicle_state(
                    bid=player.bid,
                    vehicle_id=vehicle_id,
                    relation=VEHICLE_RELATION_OPERATOR,
                    need_switch_to_character=False,
                )
                if session:
                    session.broadcast(rsp_state)
                else:
                    sock.sendall(rsp_state)

    elif pkt_id == PKT_REQ_UNMANNED_VEHICLE_POSE_DELTA:
        req = parse_req_unmanned_vehicle_pose_delta(stream)
        vehicle_id = int(req.get('vehicle_id', 0) or 0)
        if vehicle_id == 0 and player:
            vehicle_id = int(player.last_unmanned_vehicle_id or 0)
        flags = int(req.get('flags', 0) or 0) & 0x7F
        _log(
            "ReqUnmannedVehiclePoseDelta "
            f"vehicle_id={vehicle_id} flags=0x{flags:02X} from {peer}"
        )
        if player and vehicle_id > 0:
            player.last_unmanned_vehicle_id = vehicle_id
        if vehicle_id > 0:
            rsp = build_rsp_unmanned_vehicle_pose_delta(
                bid=(player.bid if player else 0),
                vehicle_id=vehicle_id,
                flags=flags,
                pos_x=req.get('pos_x'),
                pos_y=req.get('pos_y'),
                pos_z=req.get('pos_z'),
                yaw=req.get('yaw'),
                view_pitch=req.get('view_pitch'),
                view_yaw=req.get('view_yaw'),
                view_roll=req.get('view_roll'),
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_UNMANNED_VEHICLE_TAKE_BACK:
        req = parse_req_unmanned_vehicle_take_back(stream)
        vehicle_id = int(req.get('vehicle_id', 0) or 0)
        if vehicle_id == 0 and player:
            vehicle_id = int(player.last_unmanned_vehicle_id or 0)
        _log(f"ReqUnmannedVehicleTakeBack vehicle_id={vehicle_id} from {peer}")
        rsp = build_rsp_unmanned_vehicle_take_back(vehicle_id)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)
        if player and vehicle_id > 0:
            player.last_unmanned_vehicle_id = 0
            rsp_state = build_rsp_update_unmanned_vehicle_state(
                bid=player.bid,
                vehicle_id=vehicle_id,
                relation=VEHICLE_RELATION_NONE,
                need_switch_to_character=True,
            )
            if session:
                session.broadcast(rsp_state)
            else:
                sock.sendall(rsp_state)

    elif pkt_id == PKT_REQ_SWITCH_UNMANNED_VEHICLE_TO_CHARACTER:
        parse_req_switch_unmanned_vehicle_to_character(stream)
        vehicle_id = int(player.last_unmanned_vehicle_id or 0) if player else 0
        _log(f"ReqSwitchUnmannedVehicleToCharacter vehicle_id={vehicle_id} from {peer}")
        if player and vehicle_id > 0:
            rsp = build_rsp_update_unmanned_vehicle_state(
                bid=player.bid,
                vehicle_id=vehicle_id,
                relation=VEHICLE_RELATION_NONE,
                need_switch_to_character=True,
            )
            _log(
                "RspUpdateUnmannedVehicleState "
                f"bid={player.bid} vehicle_id={vehicle_id} relation={VEHICLE_RELATION_NONE} "
                "need_switch_to_character=1"
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_GRENADE_BEGIN:
        req = parse_req_grenade_begin(stream)
        _log(f"ReqGrenadeBegin grenade_id={req['grenade_unique_id']} from {peer}")
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_timeout_uid = 0
            rsp = build_rsp_grenade_begin(True, req['grenade_unique_id'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CANCEL_THROW_GRENADE:
        req = parse_req_cancel_throw_grenade(stream)
        _log(f"ReqCancelThrowGrenade grenade_id={req['grenade_unique_id']} from {peer}")
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_timeout_uid = 0
            rsp = build_rsp_cancel_throw_grenade(True, req['grenade_unique_id'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_THROW_GRENADE_END:
        req = parse_req_throw_grenade_end(stream)
        _log(
            f"ReqThrowGrenadeEnd grenade_id={req['grenade_unique_id']} "
            f"pos={req['explosive_pos']} from {peer}"
        )
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_pos = req['explosive_pos']
            player.last_grenade_timeout_uid = 0
            reporter_id = int(player.uid) if player.uid else int(player.bid)
            rsp = build_rsp_throw_grenade_end(
                reporter_id,
                req['grenade_unique_id'],
                req['explosive_pos'],
                req['throw_transform'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_GRENADE_EXPLOSIVE_POS_REPORT:
        req = parse_req_grenade_explosive_pos_report(stream)
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_pos = req['explosive_pos']
            rsp = build_rsp_grenade_explosive_pos_report(
                req['grenade_unique_id'],
                req['explosive_pos'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

            _log(
                f"ReqGrenadeExplosivePosReport grenade_id={req['grenade_unique_id']} "
                f"pos={req['explosive_pos']} from {peer}"
            )
            # Do not force timeout on the first B7 report. The client can emit
            # multiple position reports and finalize later via explode/ntf(remain=0).

    elif pkt_id == PKT_RSP_GRENADE_EXPLOSIVE_POS_REPORT:
        req = parse_rsp_grenade_explosive_pos_report(stream)
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_pos = req['explosive_pos']
            rsp = build_rsp_grenade_explosive_pos_report(
                req['grenade_unique_id'],
                req['explosive_pos'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_GRENADE_EXPLOSIVE_POS_NTF:
        req = parse_req_grenade_explosive_pos_ntf(stream)
        if player:
            player.last_grenade_unique_id = req['grenade_unique_id']
            player.last_grenade_pos = req['explosive_pos']
            relay = build_req_grenade_explosive_pos_ntf(
                req['grenade_unique_id'],
                req['remain_count'],
                req['explosive_pos'],
            )
            if session:
                session.broadcast(relay)
            else:
                sock.sendall(relay)

            if (
                req['remain_count'] == 0
                and player.last_grenade_timeout_uid != req['grenade_unique_id']
            ):
                timeout_rsp = build_rsp_grenade_time_out(req['grenade_unique_id'])
                if session:
                    session.broadcast(timeout_rsp)
                else:
                    sock.sendall(timeout_rsp)
                _log(
                    f"sent RspGrenadeTimeOut grenade_id={req['grenade_unique_id']} "
                    f"via ReqGrenadeExplosivePosNtf(remain=0) to {peer}"
                )
                player.last_grenade_timeout_uid = req['grenade_unique_id']

    elif pkt_id == PKT_REQ_BOMB_EXPLOSIVE:
        req = parse_req_bomb_explosive(stream)
        _log(
            "ReqBombExplosive "
            f"throw_item_unique_id={req['throw_item_unique_id']} "
            f"client_param={req['client_param']} from {peer}"
        )
        rsp = build_rsp_smoke_bomb_explosive(
            int(req['throw_item_unique_id']),
            int(req['client_param']),
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    elif pkt_id == PKT_REQ_OPERATE_GUN_RELOAD:
        req = parse_req_operate_gun_reload(stream)
        if player:
            rsp = build_rsp_operate_gun_reload(
                player.bid,
                req['reload_type'],
                req['hand_item_id'],
                req['operate_state'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_PLAYER_MARK:
        req = parse_req_player_mark(stream)
        if player:
            rsp = build_rsp_player_mark(player.bid, req['position'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_QUICK_CHAT:
        req = parse_req_quick_chat(stream)
        if player:
            rsp = build_rsp_quick_chat(player.bid, req['content'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_RESET_ITEM_NUM:
        # Empty request (no body) used by newer runtime state transitions.
        parse_req_reset_item_num(stream)
        _send_rsp_reset_item_num_ack(
            sock,
            peer,
            _log,
            session=session,
            player=player,
            game_state=game_state,
        )

    elif pkt_id == PKT_REQ_PLAYERS_RESULT:
        _handle_req_players_result(stream, sock, peer, _log)

    elif pkt_id == PKT_REQ_CHARACTER_MELEE_ATTACK:
        req = parse_req_character_melee_attack(stream)
        _handle_character_melee_attack_common(
            req=req,
            sock=sock,
            peer=peer,
            _log=_log,
            session=session,
            player=player,
        )

    elif pkt_id == PKT_REQ_CHARACTER_OPERATE_BLOCKING_BOARD:
        req = parse_req_character_operate_blocking_board(stream)
        _log(f"ReqCharacterOperateBlockingBoard block_id={req['block_id']} op={req['op']} from {peer}")
        if int(req.get('op', 0) or 0) == 1:
            _session_record_blocking_board_anchor(session, req.get('block_id'), req.get('pose'))
            _session_mark_player_placed_blocking_board(session, req.get('block_id'))
        if player:
            player.last_blocking_board_id = int(req.get('block_id', 0) or 0) & 0xFFFFFFFF
        if player:
            rsp = build_rsp_character_operate_blocking_board(
                player.bid,
                req['pose'],
                req['block_id'],
                req['op'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHANGE_BLOCKING_BOARD_STATE:
        req = parse_req_change_blocking_board_state(stream)
        _log(f"ReqChangeBlockingBoardState id={req['id']} state={req['state']} from {peer}")
        if player:
            player.last_blocking_board_id = int(req.get('id', 0) or 0) & 0xFFFFFFFF
        if session:
            with session._lock:
                board_id = int(req['id']) & 0xFFFFFFFF
                board_state = int(req['state']) & 0xFF
                session.last_blocking_board_id = board_id
                session.blocking_board_states[board_id] = board_state
                dyn = session.dynamic_walls.setdefault(
                    board_id,
                    {'state': board_state, 'blocks': set()},
                )
                dyn['state'] = board_state
                if board_state != BLOCKING_BOARD_STATE_DEACTIVE:
                    if float(session.blocking_board_hp.get(board_id, 1.0)) <= 0.0:
                        session.blocking_board_hp[board_id] = 1.0
                        session.broken_walls.pop(board_id, None)
                        dyn['blocks'] = set()
        player_id = int(player.uid) if (player and player.uid) else None
        evt = build_rsp_event_blocking_board_state(req['id'], player_id, req['state'])
        if session:
            session.broadcast(evt)
        else:
            sock.sendall(evt)

    elif pkt_id == PKT_REQ_CHARACTER_ACTION_AIMING:
        req = parse_req_character_action_aiming(stream)
        if player:
            rsp = build_rsp_character_action_aiming(player.bid, req['aiming'])
            if session:
                # Local controller already applies ADS immediately.
                # Echo-to-self introduces visual snapping (3-frame jitter).
                session.broadcast(rsp, exclude_bid=player.bid)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_ACTION_EXPLODE:
        req = parse_req_character_action_explode(stream)
        _log(f"ReqCharacterActionExplodeExplosive hand_tool_id={req['hand_tool_id']} from {peer}")
        if player:
            rsp = build_rsp_character_action_explode(player.bid, req['hand_tool_id'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

            # PktCmdScenePropExplosive is driven by ReqGrenadeExplosivePosNtf.
            if (
                player.last_grenade_unique_id
                and player.last_grenade_timeout_uid != player.last_grenade_unique_id
            ):
                timeout_rsp = build_rsp_grenade_time_out(player.last_grenade_unique_id)
                ntf = build_req_grenade_explosive_pos_ntf(
                    player.last_grenade_unique_id,
                    0,
                    player.last_grenade_pos,
                )
                if session:
                    session.broadcast(ntf)
                    session.broadcast(timeout_rsp)
                else:
                    sock.sendall(ntf)
                    sock.sendall(timeout_rsp)
                _log(
                    f"sent RspGrenadeTimeOut grenade_id={player.last_grenade_unique_id} "
                    f"via ReqCharacterActionExplode to {peer}"
                )
                _log(
                    f"sent ReqGrenadeExplosivePosNtf grenade_id={player.last_grenade_unique_id} "
                    f"remain=0 via ReqCharacterActionExplode to {peer}"
                )
                player.last_grenade_timeout_uid = player.last_grenade_unique_id

            explosion_damage_packets = _session_collect_explosive_structure_damage_packets(
                session,
                player,
                damage_source=player.last_grenade_pos,
                _log=_log,
            )
            if explosion_damage_packets:
                _session_send_packets(session, sock, explosion_damage_packets)

    elif pkt_id == PKT_REQ_CHARACTER_OPERATE_EXPLOSIVE:
        req = parse_req_character_operate_explosive(stream)
        _log(f"ReqCharacterOperateExplosive op={req['op']} pos={req['pos']} yaw={req['yaw']:.2f} from {peer}")
        if player:
            rsp = build_rsp_character_operate_explosive(
                player.bid,
                req['pose'],
                req['pos'],
                req['yaw'],
                req['op'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHARACTER_INSTALL_REINFORCED:
        req = parse_req_character_install_reinforced(stream)
        _log(f"ReqCharacterInstallReinforced id={req['reinforced_id']} from {peer}")
        if player:
            rsp = build_rsp_character_install_reinforced(player.bid, req['pose'], req['reinforced_id'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CHANGE_REINFORCED_STATE:
        req = parse_req_change_reinforced_state(stream)
        _log(f"ReqChangeReinforcedState id={req['id']} state={req['state']} from {peer}")
        if session:
            session.reinforced_states[req['id']] = req['state']
        owner_bid = player.bid if player else 0
        rsp = build_rsp_reinforced_state_update(req['id'], owner_bid, req['state'])
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SIMPLE_QUINTAIN_INFO:
        parse_req_simple_quintain_info(stream)
        create_packets = _session_collect_training_target_create_packets(session)
        if create_packets:
            _session_send_packets(session, sock, create_packets)
        relive_packets = _session_collect_training_target_relive_packets(session)
        if relive_packets:
            _session_send_packets(session, sock, relive_packets)
        snapshot_packets = _session_collect_training_target_snapshot_packets(session)
        if snapshot_packets:
            _session_send_packets(session, sock, snapshot_packets)
            _log(
                "ReqSimpleQuintainInfo handled "
                f"snapshot_packets={len(snapshot_packets)}"
            )

    elif pkt_id == PKT_REQ_SIMPLE_SCENE_ITEM_INFO:
        parse_req_simple_scene_item_info(stream)
        # Client-side RspSimpleSceneItemInfo handler clears scene props/entities first.
        # Sending only a training-target subset causes map regressions and hides runtime objects.
        packets: list[bytes] = []
        packets.extend(_session_collect_training_target_create_packets(session))
        packets.extend(_session_collect_training_target_relive_packets(session))
        packets.extend(_session_collect_training_target_snapshot_packets(session))
        if packets:
            _session_send_packets(session, sock, packets)
        _log(
            "ReqSimpleSceneItemInfo handled "
            f"scene_items_reply=skipped snapshot_packets={len(packets)}"
        )

    elif pkt_id == PKT_REQ_WALL_INFO:
        parse_req_wall_info(stream)
        _log(f"ReqWallInfo from {peer}")
        sock.sendall(build_rsp_wall_info(_session_snapshot_broken_walls(session)))

    elif pkt_id == PKT_REQ_DYNAMIC_WALL_INFO:
        parse_req_dynamic_wall_info(stream)
        _log(f"ReqDynamicWallInfo from {peer}")
        sock.sendall(build_rsp_dynamic_wall_info(_session_snapshot_dynamic_walls(session)))

    elif pkt_id == PKT_REQ_REINFORCED_WALL_INFO:
        parse_req_reinforced_wall_info(stream)
        _log(f"ReqReinforcedWallInfo from {peer}")
        walls, items = _session_snapshot_reinforced_walls(session)
        sock.sendall(build_rsp_reinforced_wall_info(walls, items))

    elif pkt_id == PKT_REQ_GROUND_MATERIAL:
        req = parse_req_ground_material(stream)
        if player:
            rsp = build_rsp_ground_material(player.bid, req['material'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SYNC_CHARACTER_TOOL:
        req = parse_req_sync_character_tool(stream)
        if player:
            rsp = build_rsp_sync_character_tool(player.bid, req['tool_index'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SYNC_CHARACTER_WEAPON_STATE:
        req = parse_req_sync_character_weapon_state(stream)
        if player:
            rsp = build_rsp_sync_character_weapon_state(player.bid, req['weapon_state'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SYNC_PERFORM_DATA:
        req = parse_req_sync_perform_data(stream)
        if player:
            rsp = build_rsp_sync_perform_data(player.bid, req['data_type'], req['perform_data'])
            if session:
                session.broadcast(rsp, exclude_bid=player.bid)
                sock.sendall(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_PLACE_TOOL_OPERATOR:
        req = parse_req_place_tool_operator(stream)
        wall_hint_id = _select_wall_hint_from_place_req(req)
        _log(
            "ReqPlaceToolOperator "
            f"hand_item_id={int(req.get('hand_item_id', 0) or 0)} "
            f"flags=0x{int(req.get('flags', 0) or 0) & 0xFF:02X} "
            f"relevant={len(req.get('relevant_ids', []) or req.get('relevant_id', []))} "
            f"affected={int(req.get('affected_id', 0) or 0)} "
            f"wall_hint={wall_hint_id if wall_hint_id is not None else 0} from {peer}"
        )
        if player:
            if wall_hint_id is not None:
                player.last_place_target_wall_id = wall_hint_id
            hand_item_id = int(req.get('hand_item_id', 0) or 0)
            if hand_item_id == 67 and session is not None:
                if not getattr(player, 'has_armor_plate', False):
                    # Find a bag with plates
                    for pkg_uid, pkg in session.armor_packages.items():
                        if pkg['remain_num'] > 0:
                            pkg['remain_num'] -= 1
                            player.has_armor_plate = True
                            session.broadcast(build_rsp_armor_package_info(session))
                            # Give ExtraHP to emulate damage reduction (20% reduction approx = 25 ExtraHP for 100 BaseHP)
                            session.broadcast(build_rsp_character_hp_changed(
                                bid=player.bid,
                                base_hp=100,
                                extra_hp=25,
                                damage_type=0,
                                damage_source=None
                            ))
                            break
            rsp = build_rsp_place_tool_operator(
                player.bid,
                req['hand_item_id'],
                req['relevant_ids'],
                req['affected_id'],
                req['duration'],
                req['state'],
                req['lerp_data'],
                req['flags'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_CREATE_PLACE_SCENE_TOOL:
        req = parse_req_create_place_scene_tool(stream)
        wall_hint_id = _select_wall_hint_from_place_req(req)
        if player:
            placed_uid = int(req.get('scene_tool_unique_id', 0) or 0) & 0xFFFFFFFFFFFFFFFF
            player.last_scene_tool_unique_id = placed_uid
            player.active_scene_tools.add(placed_uid)
            player.last_place_scene_tool_unique_id = placed_uid
            player.guide_c4_scene_tool_unique_id = placed_uid
            if wall_hint_id is None:
                wall_hint_id = _normalize_board_id(player.last_place_target_wall_id)
            if wall_hint_id is not None:
                player.last_place_target_wall_id = wall_hint_id
                _session_set_scene_tool_wall_hint(session, placed_uid, wall_hint_id)
            if (placed_uid & 0xFFFFFFFF) == 9 and session is not None:
                transform = req.get('transform')
                session.armor_packages[placed_uid] = {
                    'uid': placed_uid,
                    'transform': transform,
                    'remain_num': 5,
                }
                # broadcast update so late joiners see it
                session.broadcast(build_rsp_armor_package_info(session))
            _log(
                "ReqCreatePlaceSceneTool "
                f"uid={placed_uid} flags=0x{int(req.get('flags', 0) or 0) & 0xFF:02X} "
                f"relevant={len(req.get('relevant_ids', []) or req.get('relevant_id', []))} "
                f"affected={int(req.get('affected_id', 0) or 0)} "
                f"wall_hint={wall_hint_id if wall_hint_id is not None else 0} from {peer}"
            )
            rsp = build_rsp_create_place_scene_tool(
                player.bid,
                req['scene_tool_unique_id'],
                req['relevant_ids'],
                req['affected_id'],
                req['transform'],
                True,
                req['flags'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_THROW_SCENE_TOOL:
        req = parse_req_throw_scene_tool(stream)
        tool = req['tool']
        scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
        _log(
            "ReqThrowSceneTool "
            f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
        )
        if player:
            player.last_scene_tool_unique_id = scene_tool_unique_id
            player.active_scene_tools.add(scene_tool_unique_id)
        _session_mark_scene_tool_active(session, scene_tool_unique_id)
        _session_update_scene_tool_board_hint(
            session,
            scene_tool_unique_id,
            _extract_scene_tool_position(tool),
        )
        rsp = build_rsp_throw_scene_tool(player.bid if player else 0, True, tool)
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    elif pkt_id == PKT_REQ_SYNC_THROW_SCENE_TOOL_POSITION:
        req = parse_req_sync_throw_scene_tool_position(stream)
        tool = req['tool']
        scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
        if player:
            player.last_scene_tool_unique_id = scene_tool_unique_id
        if _session_is_scene_tool_ended(session, scene_tool_unique_id):
            _log(
                "ReqSyncThrowSceneToolPosition ignored "
                f"scene_tool_unique_id={scene_tool_unique_id} reason=already_ended from {peer}"
            )
        else:
            _session_update_scene_tool_board_hint(
                session,
                scene_tool_unique_id,
                _extract_scene_tool_position(tool),
            )
            rsp = build_rsp_sync_throw_scene_tool_position(tool)
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION:
        req = parse_req_report_throw_scene_tool_final_position(stream)
        tool = req['tool']
        scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
        if player:
            player.last_scene_tool_unique_id = scene_tool_unique_id
        _session_mark_scene_tool_ended(session, scene_tool_unique_id)
        timestamp_ms = int(time.time() * 1000.0) & 0xFFFFFFFF
        rsp = build_rsp_report_throw_scene_tool_final_position(timestamp_ms, tool)
        end_rsp = build_rsp_throw_scene_tool_end(scene_tool_unique_id)
        if session:
            session.broadcast(rsp)
            session.broadcast(end_rsp)
        else:
            sock.sendall(rsp)
            sock.sendall(end_rsp)

    elif pkt_id == PKT_REQ_REPORT_THROW_SCENE_TOOL_FINAL_POSITION_WITH_RELATION:
        req = parse_req_report_throw_scene_tool_final_position_with_relation(stream)
        tool = req['tool']
        scene_tool_unique_id = int(tool.get('scene_tool_unique_id', 0) or 0)
        if player:
            player.last_scene_tool_unique_id = scene_tool_unique_id
        _session_mark_scene_tool_ended(session, scene_tool_unique_id)
        rsp = build_rsp_report_throw_scene_tool_final_position_with_relation(tool)
        end_rsp = build_rsp_throw_scene_tool_end(scene_tool_unique_id)
        if session:
            session.broadcast(rsp)
            session.broadcast(end_rsp)
        else:
            sock.sendall(rsp)
            sock.sendall(end_rsp)

    elif pkt_id == PKT_REQ_USE_SCENE_TOOL:
        req = parse_req_use_scene_tool(stream)
        if player:
            player.last_scene_tool_unique_id = req['scene_tool_unique_id']
            player.last_place_scene_tool_unique_id = int(req.get('scene_tool_unique_id', 0) or 0) & 0xFFFFFFFFFFFFFFFF
            player.guide_c4_scene_tool_unique_id = player.last_place_scene_tool_unique_id
            player.last_scene_tool_hand_item_id = req['hand_item_id']
            rsp = build_rsp_use_scene_tool(
                player.bid,
                req['hand_item_id'],
                req['scene_tool_unique_id'],
                True,
            )
            into_rsp = build_rsp_into_scene_tool(
                player.bid,
                req['scene_tool_unique_id'],
                req['hand_item_id'],
            )
            if session:
                session.broadcast(rsp)
                session.broadcast(into_rsp)
            else:
                sock.sendall(rsp)
                sock.sendall(into_rsp)

    elif pkt_id == PKT_REQ_MOVE_TO_INTO_SCENE_TOOL:
        req = parse_req_move_to_into_scene_tool(stream)
        if player:
            player.last_scene_tool_unique_id = req['scene_tool_unique_id']
            player.last_scene_tool_hand_item_id = req['hand_item_id']
            rsp = build_rsp_move_to_into_scene_tool(
                player.bid,
                req['scene_tool_unique_id'],
                req['hand_item_id'],
                True,
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_INTO_SCENE_TOOL:
        req = parse_req_into_scene_tool(stream)
        if player:
            player.last_scene_tool_unique_id = req['scene_tool_unique_id']
            player.last_scene_tool_hand_item_id = req['hand_item_id']
            rsp = build_rsp_into_scene_tool(
                player.bid,
                req['scene_tool_unique_id'],
                req['hand_item_id'],
            )
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_LEAVE_SCENE_TOOL:
        parse_req_leave_scene_tool(stream)
        if player:
            rsp = build_rsp_leave_scene_tool(player.bid, player.last_scene_tool_unique_id)
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

    elif pkt_id == PKT_REQ_GET_BACK_PLACE_SCENE_TOOL:
        req = parse_req_get_back_place_scene_tool(stream)
        scene_tool_unique_id = int(req['scene_tool_unique_id'])
        _log(
            "ReqGetBackPlaceSceneTool "
            f"scene_tool_unique_id={scene_tool_unique_id} from {peer}"
        )
        if player:
            player.last_scene_tool_unique_id = scene_tool_unique_id
        rsp = build_rsp_get_back_place_scene_tool_failed(
            player.bid if player else 0,
            scene_tool_unique_id,
        )
        if session:
            session.broadcast(rsp)
        else:
            sock.sendall(rsp)

    elif pkt_id == PKT_REQ_DESTROY_BLOCKING_BOARD:
        req = parse_req_destroy_blocking_board(stream)
        bb_id: int = int(req['board_id']) & 0xFFFFFFFF
        bb_src: tuple[float, float, float] = req['damage_source']
        _log(f"ReqDestroyBlockingBoard board_id={bb_id} src={bb_src} from {peer}")
        bb_packets = _session_collect_blocking_board_damage_packets(
            session,
            destroy_type=DESTROY_TYPE_HAMMER_DAMAGE,
            damage_source=bb_src,
            preferred_board_id=bb_id,
            hit_count=1,
            target_block_indices=None,
            ray_samples=None,
            _log=_log,
        )
        if bb_packets:
            _session_send_packets(session, sock, bb_packets)
        else:
            _log(
                f"DestroyBlockingBoard noop board_id={bb_id} src={bb_src}"
            )

    elif pkt_id == PKT_HEARTBEAT:
        # Mirror heartbeat to satisfy client-side heartbeat watchdog.
        if player:
            player._hb_recv_count += 1
        echoed = _send_heartbeat_echo(sock)
        if echoed and player:
            player._hb_echo_count += 1
            if player._hb_echo_count in (1, 10, 30) or (player._hb_echo_count % 120) == 0:
                _log(
                    f"heartbeat-echo peer={peer} "
                    f"recv={player._hb_recv_count} sent={player._hb_echo_count}"
                )

        relive_packets = _session_collect_training_target_relive_packets(session)
        if relive_packets:
            _session_send_packets(session, sock, relive_packets)

        # While loading, periodically repeat load-success as a recovery nudge.
        if player and not player.loaded and player.progress >= 0.90:
            success_pkt = build_rsp_battle_load_success(player.bid)
            if session:
                session.broadcast(success_pkt)
            else:
                sock.sendall(success_pkt)

    elif pkt_id == PKT_VERSION:
        ver = parse_pkt_version(stream)
        _log(f"PktVersion from {peer}: game={ver['game']} scene={ver['scene']} "
             f"common={ver['common']} common_res={ver['common_resources']} "
             f"battle_gm={ver['battle_gm']}")

    elif pkt_id == PKT_REQ_ENTER_BATTLE:
        req = parse_req_enter_battle(stream)
        _log(f"ReqEnterBattle uid={req['uid']} battle_id={req['battle_id']} "
             f"token={req['token'][:32]} from {peer}")

        try:
            game_state['in_battle'] = True
        except Exception:
            pass

        req_battle_id = int(req['battle_id'])
        session = get_or_create_session(req_battle_id, game_state, player_data, _log)
        player = session.try_rebind_player_by_uid(req['uid'], sock, (peer, 0))
        rebind = player is not None
        if player is None:
            player = session.add_player(sock, (peer, 0))
        player.uid = req['uid']
        p_room_entry = None
        try:
            r_state = _get_live_room_state()
            if isinstance(r_state, dict) and isinstance(r_state.get("players"), dict):
                p_room_entry = r_state["players"].get(str(req['uid']))
        except Exception:
            pass

        if isinstance(p_room_entry, dict):
            p_camp = int(p_room_entry.get("camp", 1) or 1)
            player.camp = p_camp
            player.team = 2 if p_camp == 2 else 1
            player.name = p_room_entry.get("name", player_data.get('name', f"Player{player.uid}"))
        else:
            p_camp = int(game_state.get('camp', 1) or 1)
            player.camp = p_camp
            player.team = 2 if p_camp == 2 else 1
            player.name = player_data.get('name', 'Player')

        ci = req.get('client_info', {})
        _log(
            "ReqEnterBattle client_info "
            f"account_id={ci.get('account_id', '')} server_id={ci.get('server_id', '')} "
            f"chuid={ci.get('chuid', '')} running_id={ci.get('running_id', 0)}"
        )

        result['session'] = session
        result['player'] = player

        if rebind:
            _log(f"player bid={player.bid} uid={player.uid} rebound session {req_battle_id}")
        else:
            _log(f"player bid={player.bid} uid={player.uid} joined session {req_battle_id}")

        # The client has a dedicated RspBattleId handler; send it before room loading.
        sock.sendall(build_rsp_battle_id(req_battle_id))
        _log(f"sent RspBattleId battle_id={req_battle_id} to {peer}")

        # Send RspRoomLoading
        room_loading = session.build_room_loading(player)
        sock.sendall(room_loading)
        _log(
            f"room_loading invariants: bid={player.bid} uid={player.uid} "
            f"team={player.team} camp={player.camp} "
            f"region_id={game_state.get('region_id', 999)}"
        )
        _log(f"sent RspRoomLoading ({len(room_loading)}B) hex={room_loading.hex()} to {peer}")

    elif pkt_id == PKT_REQ_LOAD_PROGRESS:
        req = parse_req_load_progress(stream)
        _log(f"ReqLoadProgress progress={req['progress']:.2f} from {peer}")

        if player:
            player.progress = req['progress']
            # Echo progress back to all players
            bid = player.bid
            rsp = build_rsp_load_progress(bid, req['progress'])
            if session:
                session.broadcast(rsp)
            else:
                sock.sendall(rsp)

            # Send load-success only in late loading and allow repeats.
            # Some client states can ignore an early single success packet.
            # Do NOT send GameStart here: rsp_game_start while still loading can
            # force reconnect/disconnect path.
            if req['progress'] >= 0.90:
                success_pkt = build_rsp_battle_load_success(player.bid)
                if session:
                    session.broadcast(success_pkt)
                    _log(f"resent RspBattleLoadSuccess bid={player.bid} to all players")
                else:
                    sock.sendall(success_pkt)
                    _log(f"sent RspBattleLoadSuccess bid={player.bid} to {peer}")

    elif pkt_id == PKT_REQ_ROOM_LOADED:
        parse_req_room_loaded(stream)
        _log(f"ReqRoomLoaded from {peer}")

        if player:
            player.loaded = True

        if session and player:
            # RspBattleLoadSuccess carries bid (u8), not a boolean flag.
            session._send_load_success_once(player)

        should_start_now = False
        if session:
            if _is_training_mode_game_state(session.game_state):
                if player and player.loaded:
                    _log("training mode: local player loaded, starting battle immediately")
                    should_start_now = True
            elif session.all_loaded():
                _log("all players loaded, starting battle!")
                should_start_now = True

        if should_start_now and session:
            session._send_game_start_once()
            if _is_training_mode_game_state(session.game_state):
                _push_training_target_snapshot_packets(
                    session,
                    sock,
                    _log=_log,
                    reason='room_loaded_start_legacy',
                    include_scene_items=False,
                )
        elif player and not session:
            # Single player вЂ” immediately start
            success_pkt = build_rsp_battle_load_success(player.bid)
            sock.sendall(success_pkt)
            _log(f"sent RspBattleLoadSuccess bid={player.bid} to {peer}")

            ts = int(time.time())
            start_pkt = build_rsp_game_start(ts)
            sock.sendall(start_pkt)
            _log(f"sent RspGameStart ts={ts} to {peer}")
            stage_ts, stage_total, stage_remain = _resolve_stage_sync_payload(
                session=None,
                game_state=game_state,
                game_stage=GAME_STAGE_BATTLE,
            )
            stage_pkt = build_rsp_game_stage(
                timestamp=stage_ts,
                game_stage=GAME_STAGE_BATTLE,
                total_time=stage_total,
                remain_time=stage_remain,
            )
            sock.sendall(stage_pkt)
            _log(
                "sent RspGameStage "
                f"stage={GAME_STAGE_BATTLE} total={stage_total} remain={stage_remain} to {peer}"
            )
            critical_state = CRITICAL_REGION_STATE_ONLY_DEFENDERS
            if _is_training_mode_game_state(game_state):
                critical_state = _critical_region_state_for_player_camp(
                    game_state.get('camp', BATTLE_CAMP_ATTACKER)
                )
            critical_pkt = build_rsp_critical_region_state(critical_state)
            sock.sendall(critical_pkt)
            _guide_set_critical_region_state(session, critical_state)
            _log(
                "sent RspCriticalRegionState "
                f"state={critical_state} camp={game_state.get('camp')} to {peer}"
            )

    else:
        # Unknown packet вЂ” log but DO NOT skip blindly.
        # Without length framing, we can't know the body size.
        # The stream position stays at the end of pkt_id, so the
        # next iteration will try to parse from here вЂ” which will
        # likely fail.  We drain the entire buffer to avoid a loop.
        remaining = stream.remaining
        _log(f"unknown pkt_id={pkt_id} (0x{pkt_id:X}), remaining={remaining}B "
             f"hex={bytes(stream._data[stream._pos:stream._pos+32]).hex()} from {peer}")
        # Drain buffer вЂ” any data following an unknown packet is unrecoverable
        if drain_unknown and remaining > 0:
            stream.read_bytes(remaining)

    return result
