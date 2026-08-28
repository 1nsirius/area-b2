"""Minimal sproto pack/unpack + encode/decode for the lobby TCP protocol.

Based on cloudwu/sproto specification:
  https://github.com/cloudwu/sproto

Wire format (per frame):
  [2 bytes BE: packed_len] [packed_data]

packed_data → sproto_unpack → encoded_data = [header_encoded][body_encoded]

Sproto encoding:
  [2 bytes LE: fn (field record count)]
  [fn * 2 bytes LE: field records]
  [data section: variable-length chunks for records with value==0]

Field record values:
  0          → field data in data section: [4 bytes LE: len][len bytes]
  even > 0   → inline integer = value/2 - 1
  odd        → skip (value+1)/2 tags
"""

import struct
import sys


# ── sproto pack / unpack ────────────────────────────────────────────

def sproto_unpack(data: bytes) -> bytes:
    """Unpack sproto-packed data (reverse of SprotoPack.pack)."""
    out = bytearray()
    i = 0
    n = len(data)
    while i < n:
        bitmask = data[i]
        i += 1
        if bitmask == 0xFF:
            if i >= n:
                break
            count = data[i] + 1        # number of all-non-zero 8-byte groups
            i += 1
            chunk = data[i : i + count * 8]
            out.extend(chunk)
            i += count * 8
        else:
            group = bytearray(8)
            for bit in range(8):
                if bitmask & (1 << bit):
                    if i < n:
                        group[bit] = data[i]
                        i += 1
            out.extend(group)
    return bytes(out)


def sproto_pack(data: bytes) -> bytes:
    """Pack data using sproto packing (SprotoPack.pack)."""
    # Pad to multiple of 8
    padded = data + b'\x00' * ((8 - len(data) % 8) % 8)
    groups = [padded[j:j+8] for j in range(0, len(padded), 8)]

    out = bytearray()
    ff_buf = bytearray()   # buffer for consecutive all-non-zero groups
    ff_count = 0

    def flush_ff():
        nonlocal ff_count, ff_buf
        if ff_count > 0:
            out.append(0xFF)
            out.append(ff_count - 1)
            out.extend(ff_buf)
            ff_buf.clear()
            ff_count = 0

    for g in groups:
        non_zero = sum(1 for b in g if b != 0)
        if non_zero == 8 or (non_zero >= 6 and ff_count > 0):
            # Treat as all-non-zero group
            ff_buf.extend(g)
            ff_count += 1
        else:
            flush_ff()
            bitmask = 0
            body = bytearray()
            for bit in range(8):
                if g[bit] != 0:
                    bitmask |= (1 << bit)
                    body.append(g[bit])
            out.append(bitmask)
            out.extend(body)

    flush_ff()
    return bytes(out)


# ── sproto field encode / decode ────────────────────────────────────

def sproto_encode_fields(fields: list[tuple[int, object]]) -> bytes:
    """Encode sproto fields.

    fields: list of (tag, value) where value is:
        int   → integer field
        str   → string field (UTF-8)
        bytes → binary field
        None  → skip (field not present)

    Tags must be in ascending order.  Gaps are handled automatically.
    """
    records: list[int] = []
    data_section = bytearray()
    last_tag = -1

    for tag, value in fields:
        if value is None:
            continue

        # Insert skip markers for gaps
        gap = tag - last_tag - 1
        if gap > 0:
            skip_val = gap * 2 - 1      # odd value
            records.append(skip_val)

        if isinstance(value, int):
            if 0 <= value <= 0x7FFE:
                # Inline integer
                records.append(value * 2 + 2)
            elif -(1 << 31) <= value < (1 << 31):
                # 32-bit in data section
                records.append(0)
                data_section.extend(struct.pack('<I', 4))
                data_section.extend(struct.pack('<i', value))
            else:
                # 64-bit in data section
                records.append(0)
                data_section.extend(struct.pack('<I', 8))
                data_section.extend(struct.pack('<q', value))
        elif isinstance(value, str):
            encoded = value.encode('utf-8')
            records.append(0)
            data_section.extend(struct.pack('<I', len(encoded)))
            data_section.extend(encoded)
        elif isinstance(value, bytes):
            records.append(0)
            data_section.extend(struct.pack('<I', len(value)))
            data_section.extend(value)
        else:
            raise ValueError(f"Unsupported field type: {type(value)}")

        last_tag = tag

    # Build output: [fn LE16] [records LE16 each] [data_section]
    fn = len(records)
    out = struct.pack('<H', fn)
    for r in records:
        out += struct.pack('<H', r)
    out += bytes(data_section)
    return out


def sproto_decode_fields(data: bytes, offset: int = 0) -> tuple[dict, int]:
    """Decode sproto-encoded fields starting at offset.

    Returns (fields_dict, bytes_consumed).
    fields_dict maps tag → value (int for inline, bytes for data-section).
    """
    if offset + 2 > len(data):
        return {}, 0

    fn = struct.unpack_from('<H', data, offset)[0]
    header_size = 2 + fn * 2
    if offset + header_size > len(data):
        return {}, 0

    records = []
    for i in range(fn):
        val = struct.unpack_from('<H', data, offset + 2 + i * 2)[0]
        records.append(val)

    fields = {}
    data_offset = offset + header_size
    tag = 0
    for val in records:
        if val & 1:  # odd → skip marker
            skip = (val + 1) // 2
            tag += skip
        elif val == 0:
            # Data in data section
            if data_offset + 4 <= len(data):
                dlen = struct.unpack_from('<I', data, data_offset)[0]
                data_offset += 4
                if data_offset + dlen <= len(data):
                    fields[tag] = data[data_offset : data_offset + dlen]
                    data_offset += dlen
            tag += 1
        else:
            # Even > 0: inline integer
            fields[tag] = val // 2 - 1
            tag += 1

    return fields, data_offset - offset


# ── High-level message helpers ──────────────────────────────────────

def decode_packet(frame: bytes) -> dict:
    """Decode a full TCP frame: [2B BE len][packed payload].

    Returns dict with 'header' (type, session, ud) and 'body_fields'.
    """
    if len(frame) < 4:
        return {'error': 'too short'}

    payload_len = struct.unpack('>H', frame[:2])[0]
    packed = frame[2 : 2 + payload_len]
    unpacked = sproto_unpack(packed)

    header_fields, header_size = sproto_decode_fields(unpacked, 0)
    body_fields, _ = sproto_decode_fields(unpacked, header_size)

    return {
        'payload_len': payload_len,
        'unpacked_len': len(unpacked),
        'header': {
            'type': header_fields.get(0),
            'session': header_fields.get(1),
            'ud': header_fields.get(2),
        },
        'body_fields': body_fields,
        'header_size': header_size,
        'unpacked_hex': unpacked.hex(),
    }


def build_response_frame(session: int, body_fields: list[tuple[int, object]] | None = None) -> bytes:
    """Build a TCP response frame with given session and body fields.

    For responses, the header only needs 'session' (client uses session
    to look up the original msg ID).  'type' can be omitted.
    """
    # Header: only session (tag 1)
    header_encoded = sproto_encode_fields([(1, session)])

    # Body
    if body_fields:
        body_encoded = sproto_encode_fields(body_fields)
    else:
        body_encoded = b''

    # Concatenate and pack
    raw = header_encoded + body_encoded
    packed = sproto_pack(raw)

    # Frame: [2B BE len][packed]
    frame = struct.pack('>H', len(packed)) + packed
    return frame


def build_push_frame(msg_type: int, body_fields: list[tuple[int, object]] | None = None) -> bytes:
    """Build a server-push frame (session=0) with msg type and body."""
    header_encoded = sproto_encode_fields([(0, msg_type), (1, 0)])

    if body_fields:
        body_encoded = sproto_encode_fields(body_fields)
    else:
        body_encoded = b''

    raw = header_encoded + body_encoded
    packed = sproto_pack(raw)
    frame = struct.pack('>H', len(packed)) + packed
    return frame


def build_request_frame(msg_type: int, session: int, body_fields: list[tuple[int, object]] | None = None) -> bytes:
    """Build a client-request frame with msg type, session ID, and body fields."""
    header_encoded = sproto_encode_fields([(0, msg_type), (1, session)])
    if body_fields:
        body_encoded = sproto_encode_fields(body_fields)
    else:
        body_encoded = b''
    raw = header_encoded + body_encoded
    packed = sproto_pack(raw)
    frame = struct.pack('>H', len(packed)) + packed
    return frame


def extract_session_from_frame(frame: bytes) -> int | None:
    """Quick extraction of session ID from a TCP frame."""
    if len(frame) < 4:
        return None
    payload_len = struct.unpack('>H', frame[:2])[0]
    packed = frame[2 : 2 + payload_len]
    unpacked = sproto_unpack(packed)
    fields, _ = sproto_decode_fields(unpacked, 0)
    return fields.get(1)


def extract_type_from_frame(frame: bytes) -> int | None:
    """Quick extraction of message type from a TCP frame."""
    if len(frame) < 4:
        return None
    payload_len = struct.unpack('>H', frame[:2])[0]
    packed = frame[2 : 2 + payload_len]
    unpacked = sproto_unpack(packed)
    fields, _ = sproto_decode_fields(unpacked, 0)
    return fields.get(0)


# ── CLI test ────────────────────────────────────────────────────────

if __name__ == '__main__':
    # Test with captured packets
    print("=== First 5502 (hall_login, 49 bytes) ===")
    pkt1_hex = "002f5502161a01c4256761ff036d652d646666616366636334373565313963376261323764613264386230356507383135"
    pkt1 = bytes.fromhex(pkt1_hex)
    info1 = decode_packet(pkt1)
    print(f"  Header: type={info1['header']['type']}, session={info1['header']['session']}, ud={info1['header']['ud']}")
    print(f"  Body fields: {info1['body_fields']}")
    print(f"  Unpacked ({info1['unpacked_len']} bytes): {info1['unpacked_hex']}")

    print()
    print("=== First 5502 echo (5503) ===")
    echo_hex = "002f5503161a01c4256761ff036d652d646666616366636334373565313963376261323764613264386230356507383135"
    echo = bytes.fromhex(echo_hex)
    info_echo = decode_packet(echo)
    print(f"  Header: type={info_echo['header']['type']}, session={info_echo['header']['session']}, ud={info_echo['header']['ud']}")
    print(f"  Body fields: {info_echo['body_fields']}")

    print()
    print("=== Build hall_login response (code=0, account='1000001') ===")
    session = info1['header']['session']
    resp_frame = build_response_frame(session, [(0, 0), (1, "1000001")])
    print(f"  Frame hex: {resp_frame.hex()}")
    print(f"  Frame len: {len(resp_frame)}")
    # Verify by decoding
    resp_info = decode_packet(resp_frame)
    print(f"  Decoded header: {resp_info['header']}")
    print(f"  Decoded body: {resp_info['body_fields']}")

    print()
    print("=== Partial second 5502 (first 65 bytes visible) ===")
    pkt2_hex = "01175502d02202305d01010e00040454020208fc1c4e8e9b9d01c4203531ff043331366634313666306266666463653566336161353130623031666263370600"
    pkt2_partial = bytes.fromhex(pkt2_hex)
    # Only decode header (first segment)
    payload_len2 = struct.unpack('>H', pkt2_partial[:2])[0]
    packed2 = pkt2_partial[2:]
    unpacked2 = sproto_unpack(packed2)
    hdr2, hdr2_size = sproto_decode_fields(unpacked2, 0)
    print(f"  Payload len (declared): {payload_len2}")
    print(f"  Packed bytes available: {len(packed2)} (of {payload_len2})")
    print(f"  Header: type={hdr2.get(0)}, session={hdr2.get(1)}, ud={hdr2.get(2)}")
    # Try body too
    body2, _ = sproto_decode_fields(unpacked2, hdr2_size)
    print(f"  Body fields (partial): {body2}")

    print()
    print("=== Round-trip test: encode → pack → unpack → decode ===")
    test_fields = [(0, 42), (1, "hello"), (3, 99999)]
    encoded = sproto_encode_fields(test_fields)
    packed = sproto_pack(encoded)
    unpacked = sproto_unpack(packed)
    decoded, _ = sproto_decode_fields(unpacked)
    print(f"  Original: {test_fields}")
    print(f"  Encoded hex: {encoded.hex()}")
    print(f"  Packed hex: {packed.hex()}")  
    print(f"  Unpacked hex: {unpacked.hex()}")
    print(f"  Decoded: {decoded}")
    assert decoded[0] == 42
    assert decoded[1] == b"hello"
    assert decoded[3] == struct.pack('<i', 99999)  # large int stored as bytes in data section
    print("  ✓ Round-trip OK")
