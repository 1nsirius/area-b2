"""
Area F2 Battle Destruction Service Module.

Provides protocol-level handling and state management for:
- Wall, floor, and hatch destruction (WallBlock, DynamicWallBlock, Pillar, ReinforceBlock)
- Door and window barricades (BlockingBoard, 14x3 / 13x3 grids)
- Steel reinforcements (ReinforceWall / RefactorReinforced)
- Training target dummies (SimpleQuintain / TargetModel)

Uses client-authoritative U64 UniqueId decoding (EntryType + ContentId + Index1 + Index2)
without heavy server-side 3D raycasting.
"""

from __future__ import annotations

import json
import math
import os
import struct
import threading
from pathlib import Path
from typing import Any, Callable

# ═══════════════════════════════════════════════════════════════════════════════
#  EntryType & UniqueId Constants (from proto.common.EntryType)
# ═══════════════════════════════════════════════════════════════════════════════

ENTRY_TYPE_DEFAULT = 0
ENTRY_TYPE_STATIC_OBJECT = 1
ENTRY_TYPE_WALL_BLOCK = 2
ENTRY_TYPE_REINFORCE_WALL = 3
ENTRY_TYPE_DYNAMIC_WALL_BLOCK = 4
ENTRY_TYPE_PILLAR = 5
ENTRY_TYPE_SIMPLE_QUINTAIN = 6
ENTRY_TYPE_EXPLOSIVE = 7
ENTRY_TYPE_SHIELD = 8
ENTRY_TYPE_VEHICLE = 9
ENTRY_TYPE_PLAYER = 10
ENTRY_TYPE_DEFENSE_REGION = 11
ENTRY_TYPE_CRITICAL_REGION = 12
ENTRY_TYPE_MONITOR = 13
ENTRY_TYPE_ARMOR_PACKAGE = 14
ENTRY_TYPE_TRAP_BOMB = 15
ENTRY_TYPE_ELECTRIC_BOX = 16
ENTRY_TYPE_GRENADE = 17
ENTRY_TYPE_REMOTE_BOMB = 18
ENTRY_TYPE_TRACKER = 19
ENTRY_TYPE_NEURO_TOXIN = 20
ENTRY_TYPE_REINFORCE_BLOCK = 21
ENTRY_TYPE_REINFORCE_ITEM = 22
ENTRY_TYPE_BOMB_GUN_BULLET = 23
ENTRY_TYPE_THERMITE_BOMB = 24
ENTRY_TYPE_MOUNTED_LMG = 25
ENTRY_TYPE_ELECTRO_MAGNETIC_PULSE = 26
ENTRY_TYPE_SMOKE_BOMB = 27
ENTRY_TYPE_BARDED_WIRE = 28
ENTRY_TYPE_WIFI = 29
ENTRY_TYPE_FLASH_BOMB = 30
ENTRY_TYPE_POISON_BOMB = 31
ENTRY_TYPE_POISON_BOMB_SMOKE = 32
ENTRY_TYPE_SHOCK_GRENADE = 33
ENTRY_TYPE_TARGET_MODEL = 34
ENTRY_TYPE_DEFUSER = 35
ENTRY_TYPE_BOMB_REGION = 36
ENTRY_TYPE_SHOCK_SENSOR = 37
ENTRY_TYPE_ACTIVE_DEFENSE_SYSTEM = 38
ENTRY_TYPE_GUN = 39

WALL_ENTRY_KINDS: set[int] = {
    ENTRY_TYPE_WALL_BLOCK,            # 2: Static wall / floor block
    ENTRY_TYPE_REINFORCE_WALL,        # 3: Reinforced wall
    ENTRY_TYPE_DYNAMIC_WALL_BLOCK,    # 4: Dynamic wall / doorway / window block
    ENTRY_TYPE_PILLAR,                # 5: Pillar
    ENTRY_TYPE_REINFORCE_BLOCK,       # 21: Reinforcement segment
}

TARGET_ENTRY_KINDS: set[int] = {
    ENTRY_TYPE_SIMPLE_QUINTAIN,       # 6: Simple quintain
    ENTRY_TYPE_TARGET_MODEL,          # 34: Target model dummy
}

# ═══════════════════════════════════════════════════════════════════════════════
#  DestroyType & EffectType Constants
# ═══════════════════════════════════════════════════════════════════════════════

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

BLOCKING_BOARD_STATE_DEACTIVE = 0
BLOCKING_BOARD_STATE_ACTIVE = 1

REINFORCED_STATE_INIT = 0
REINFORCED_STATE_DEACTIVED = 1
REINFORCED_STATE_ACTIVING1 = 2
REINFORCED_STATE_ACTIVING2 = 3
REINFORCED_STATE_ACTIVED1 = 4
REINFORCED_STATE_ACTIVED2 = 5
REINFORCED_STATE_DELETED = 6

# Barricade grid dimensions
DOOR_BARRICADE_ROWS = 14
DOOR_BARRICADE_COLS = 3
DOOR_BARRICADE_TOTAL = 42

WINDOW_BARRICADE_ROWS = 13
WINDOW_BARRICADE_COLS = 3
WINDOW_BARRICADE_TOTAL = 39

MAX_BARRICADE_MELEE_HITS = 3


# ═══════════════════════════════════════════════════════════════════════════════
#  UniqueId Bitwise Helpers
# ═══════════════════════════════════════════════════════════════════════════════

def decode_unique_id(raw_u64: int) -> tuple[int, int, int, int]:
    """
    Decode 64-bit UniqueId into (kind, local_id, index1, index2).
    - High 32 bits: kind (10 bits, >> 22), local_id (22 bits, & 0x3FFFFF)
    - Low 32 bits:  index1 (16 bits, >> 16), index2 (16 bits, & 0xFFFF)
    """
    val = int(raw_u64) & 0xFFFFFFFFFFFFFFFF
    high = (val >> 32) & 0xFFFFFFFF
    low = val & 0xFFFFFFFF
    kind = (high >> 22) & 0x3FF
    local_id = high & 0x3FFFFF
    index1 = (low >> 16) & 0xFFFF
    index2 = low & 0xFFFF
    return kind, local_id, index1, index2


def encode_unique_id(kind: int, local_id: int, index1: int = 0, index2: int = 0) -> int:
    """Encode (kind, local_id, index1, index2) into a 64-bit UniqueId."""
    high = ((kind & 0x3FF) << 22) | (local_id & 0x3FFFFF)
    low = ((index1 & 0xFFFF) << 16) | (index2 & 0xFFFF)
    return ((high << 32) | low) & 0xFFFFFFFFFFFFFFFF


def destroy_type_to_effect_type(destroy_type: int) -> int:
    """Map DestroyType enum to EffectType enum."""
    dt = int(destroy_type or 0)
    if dt == DESTROY_TYPE_GUN_DAMAGE:
        return EFFECT_TYPE_GUN
    if dt == DESTROY_TYPE_EXPLOSIVE_DAMAGE:
        return EFFECT_TYPE_EXPLOSIVE
    if dt == DESTROY_TYPE_SNIPE_GUN_DAMAGE:
        return EFFECT_TYPE_SNIPE_GUN
    if dt == DESTROY_TYPE_HAMMER_DAMAGE:
        return EFFECT_TYPE_HAMMER
    if dt == DESTROY_TYPE_MELEE_DAMAGE:
        return EFFECT_TYPE_MELEE
    if dt == DESTROY_TYPE_ELECTRIC_DAMAGE:
        return EFFECT_TYPE_ELECTRIC
    if dt == DESTROY_TYPE_THERMITE_BOMB:
        return EFFECT_TYPE_THERMITE_BOMB
    if dt == DESTROY_TYPE_BURN_DAMAGE:
        return EFFECT_TYPE_BURN
    if dt == DESTROY_TYPE_SHOT_GUN_DAMAGE:
        return EFFECT_TYPE_SHOT_GUN
    if dt == DESTROY_TYPE_ELEC_MAG_PULSE:
        return EFFECT_TYPE_ELECTROMAGNETIC_DAMAGE
    return EFFECT_TYPE_NONE


# ═══════════════════════════════════════════════════════════════════════════════
#  Barricade Grid Helpers
# ═══════════════════════════════════════════════════════════════════════════════

def get_barricade_hit_cluster(
    hit_block_idx: int,
    is_heavy_hit: bool = False,
    is_window: bool = False,
) -> list[int]:
    """
    Compute cluster of broken blocks for a barricade hit.
    - Standard gunfire: 1-2 blocks around hit point.
    - Heavy hit (hammer, melee attack, shotgun, breach): 6 blocks (2 rows x 3 cols).
    """
    total_blocks = WINDOW_BARRICADE_TOTAL if is_window else DOOR_BARRICADE_TOTAL
    rows = WINDOW_BARRICADE_ROWS if is_window else DOOR_BARRICADE_ROWS
    cols = 3

    hit_idx = max(0, min(int(hit_block_idx or 0), total_blocks - 1))
    if not is_heavy_hit:
        # Gunfire hit: return the hit block and optionally the same row adjacent block
        cluster = [hit_idx]
        col = hit_idx % cols
        row = hit_idx // cols
        if col < cols - 1 and (hit_idx + 1) < total_blocks:
            cluster.append(hit_idx + 1)
        elif col > 0:
            cluster.append(hit_idx - 1)
        return cluster

    # Heavy hit: destroy 2 full rows (6 blocks) centered on hit row
    hit_row = hit_idx // cols
    start_row = max(0, hit_row - 1 if hit_row > 0 else 0)
    end_row = min(rows, start_row + 2)
    if end_row - start_row < 2 and start_row > 0:
        start_row = max(0, start_row - 1)

    cluster = []
    for r in range(start_row, end_row):
        for c in range(cols):
            idx = r * cols + c
            if idx < total_blocks:
                cluster.append(idx)
    return sorted(set(cluster))


# ═══════════════════════════════════════════════════════════════════════════════
#  Wall Asset Manifest & Radial Geometry Helpers
# ═══════════════════════════════════════════════════════════════════════════════

WALL_BLOCKS_MANIFEST_DEFAULT_PATH = os.path.join(
    'artifacts',
    'asset_manifests',
    'complete_wall_assets_manifest.json',
)
_WALL_BLOCKS_MANIFEST_CACHE: dict[str, dict] | None = None
_WALL_BLOCKS_MANIFEST_LOCK = threading.Lock()


def _resolve_wall_blocks_manifest_path() -> Path:
    raw_path = str(
        os.getenv('WALL_BLOCKS_MANIFEST_PATH', WALL_BLOCKS_MANIFEST_DEFAULT_PATH)
        or WALL_BLOCKS_MANIFEST_DEFAULT_PATH
    ).strip()
    manifest_path = Path(raw_path)
    if not manifest_path.is_absolute():
        manifest_path = Path(__file__).resolve().parent.parent / manifest_path
    return manifest_path


def load_wall_blocks_manifest() -> dict[str, dict]:
    global _WALL_BLOCKS_MANIFEST_CACHE
    with _WALL_BLOCKS_MANIFEST_LOCK:
        if _WALL_BLOCKS_MANIFEST_CACHE is not None:
            return _WALL_BLOCKS_MANIFEST_CACHE
        manifest_path = _resolve_wall_blocks_manifest_path()
        if not manifest_path.exists():
            alt_path = Path(__file__).resolve().parent.parent / 'artifacts' / 'asset_manifests' / 'wall_blocks_manifest.json'
            if alt_path.exists():
                manifest_path = alt_path
        try:
            _WALL_BLOCKS_MANIFEST_CACHE = json.loads(manifest_path.read_text(encoding='utf-8'))
        except Exception:
            _WALL_BLOCKS_MANIFEST_CACHE = {}
        return _WALL_BLOCKS_MANIFEST_CACHE


WALL_TO_PG_MANIFEST_DEFAULT_PATH = os.path.join(
    'artifacts',
    'asset_manifests',
    'scene_wall_to_pillar_group.json',
)
_WALL_TO_PG_CACHE: dict[str, dict] | None = None
_WALL_TO_PG_LOCK = threading.Lock()


def load_wall_to_pillar_group_manifest() -> dict[str, dict]:
    global _WALL_TO_PG_CACHE
    with _WALL_TO_PG_LOCK:
        if _WALL_TO_PG_CACHE is not None:
            return _WALL_TO_PG_CACHE
        p = Path(__file__).resolve().parent.parent / WALL_TO_PG_MANIFEST_DEFAULT_PATH
        if p.exists():
            try:
                _WALL_TO_PG_CACHE = json.loads(p.read_text(encoding='utf-8'))
                return _WALL_TO_PG_CACHE
            except Exception:
                pass
        _WALL_TO_PG_CACHE = {}
        return _WALL_TO_PG_CACHE


def _normalize_destruction_map_id(map_id: int) -> int:
    try:
        mid = int(map_id)
    except Exception:
        return 1
    if mid == 6:
        return 3
    if mid == 7:
        return 4
    if mid == 3:
        return 0
    return mid


def get_pillar_group_for_wall(map_id: int, wall_id: int) -> int | list[int] | None:
    manifest = load_wall_to_pillar_group_manifest()
    norm_mid = _normalize_destruction_map_id(map_id)
    sc_dict = manifest.get(str(map_id)) or manifest.get(str(norm_mid), {})
    val = sc_dict.get(str(wall_id))
    if val is not None:
        if isinstance(val, list):
            return [int(x) for x in val]
        return int(val)
    return None


PILLAR_SEGMENTS_3D_DEFAULT_PATH = os.path.join(
    'artifacts',
    'asset_manifests',
    'pillar_group_segments_3d.json',
)
_PILLAR_SEGMENTS_3D_CACHE: dict[str, dict] | None = None
_PILLAR_SEGMENTS_3D_LOCK = threading.Lock()


def load_pillar_group_segments_3d_manifest() -> dict[str, dict]:
    global _PILLAR_SEGMENTS_3D_CACHE
    with _PILLAR_SEGMENTS_3D_LOCK:
        if _PILLAR_SEGMENTS_3D_CACHE is not None:
            return _PILLAR_SEGMENTS_3D_CACHE
        p = Path(__file__).resolve().parent.parent / PILLAR_SEGMENTS_3D_DEFAULT_PATH
        if p.exists():
            try:
                _PILLAR_SEGMENTS_3D_CACHE = json.loads(p.read_text(encoding='utf-8'))
                return _PILLAR_SEGMENTS_3D_CACHE
            except Exception:
                pass
        _PILLAR_SEGMENTS_3D_CACHE = {}
        return _PILLAR_SEGMENTS_3D_CACHE


def calculate_broken_pillar_segments(
    map_id: int,
    group_id: int,
    hit_world: tuple[float, float, float],
    radius: float,
    is_full: bool = False,
    session: Any = None,
) -> list[tuple[int, list[int]]]:
    """
    Calculate which pillars and segments within group_id should be destroyed
    based on the 3D explosion position and blast radius.
    Returns a list of (pillar_id, [newly_broken_segments]).
    """
    all_maps_pg = load_pillar_group_segments_3d_manifest()
    norm_mid = _normalize_destruction_map_id(map_id)
    map_dict = all_maps_pg.get(str(map_id)) or all_maps_pg.get(str(norm_mid), {})
    group_data = map_dict.get(str(group_id))
    if not group_data:
        for m_dict in all_maps_pg.values():
            if str(group_id) in m_dict:
                group_data = m_dict[str(group_id)]
                break

    results: list[tuple[int, list[int]]] = []

    if is_full or not group_data:
        if group_data:
            p_set = set(int(p) for p in group_data.keys())
            # Safeguard: if group has 5 pillars (hatch crossbars), ensure 1..5 are included
            if len(p_set) == 5 or max(p_set, default=0) <= 5:
                p_set.update([1, 2, 3, 4, 5])
            pillar_ids = sorted(p_set)
        else:
            pillar_ids = list(range(1, 6))

        for pid in pillar_ids:
            if group_data and str(pid) in group_data:
                avail_segs = [int(s) for s in group_data[str(pid)].keys()]
            elif group_data and str(pid - 1) in group_data:
                avail_segs = [int(s) for s in group_data[str(pid - 1)].keys()]
            else:
                avail_segs = list(range(6))
            if session is not None and hasattr(session, 'broken_pillar_segments'):
                already_broken = session.broken_pillar_segments.setdefault(group_id, {}).setdefault(pid, set())
                new_segs = [s for s in avail_segs if s not in already_broken]
                already_broken.update(new_segs)
            else:
                new_segs = avail_segs
            if new_segs:
                results.append((pid, sorted(new_segs)))
        if session is not None and hasattr(session, 'broken_pillar_groups'):
            session.broken_pillar_groups.add(group_id)
        return results

    # Radial destruction using exact 3D distance
    for pid_str, segs_dict in group_data.items():
        pid = int(pid_str)
        to_break: list[int] = []
        for sid_str, pos in segs_dict.items():
            dist = math.sqrt(
                (pos[0] - hit_world[0]) ** 2
                + (pos[1] - hit_world[1]) ** 2
                + (pos[2] - hit_world[2]) ** 2
            )
            if dist <= radius:
                to_break.append(int(sid_str))

        if to_break:
            if session is not None and hasattr(session, 'broken_pillar_segments'):
                already_broken = session.broken_pillar_segments.setdefault(group_id, {}).setdefault(pid, set())
                new_segs = [s for s in to_break if s not in already_broken]
                already_broken.update(new_segs)
            else:
                new_segs = to_break
            if new_segs:
                results.append((pid, sorted(new_segs)))

    if session is not None and hasattr(session, 'broken_pillar_segments') and hasattr(session, 'broken_pillar_groups'):
        group_record = session.broken_pillar_segments.get(group_id, {})
        if group_data and all(len(group_record.get(int(p), set())) >= len(segs) for p, segs in group_data.items()):
            session.broken_pillar_groups.add(group_id)

    return results


# ═══════════════════════════════════════════════════════════════════════════════
#  Hatch Triads & Floor-Roof Sibling Maps
# ═══════════════════════════════════════════════════════════════════════════════

HATCH_TRIADS_MAP: dict[int, dict[int, tuple[int, int, int]]] = {
    1: {
        370: (370, 371, 369), 371: (370, 371, 369),
        373: (373, 374, 372), 374: (373, 374, 372),
        376: (376, 377, 375), 377: (376, 377, 375),
        379: (379, 380, 378), 380: (379, 380, 378),
        382: (382, 383, 381), 383: (382, 383, 381),
        385: (385, 386, 384), 386: (385, 386, 384),
        388: (388, 389, 387), 389: (388, 389, 387),
        391: (391, 392, 390), 392: (391, 392, 390),
        394: (394, 395, 393), 395: (394, 395, 393),
        397: (397, 398, 396), 398: (397, 398, 396),
        400: (400, 401, 399), 401: (400, 401, 399),
    },
    2: {
        295: (295, 296, 294), 296: (295, 296, 294),
        298: (298, 299, 297), 299: (298, 299, 297),
        301: (301, 302, 300), 302: (301, 302, 300),
        304: (304, 305, 303), 305: (304, 305, 303),
        307: (307, 308, 306), 308: (307, 308, 306),
        310: (310, 311, 309), 311: (310, 311, 309),
        313: (313, 314, 312), 314: (313, 314, 312),
    },
    3: {
        326: (326, 327, 325), 327: (326, 327, 325),
        329: (329, 330, 328), 330: (329, 330, 328),
        332: (332, 333, 331), 333: (332, 333, 331),
        335: (335, 336, 334), 336: (335, 336, 334),
        338: (338, 339, 337), 339: (338, 339, 337),
        341: (341, 342, 340), 342: (341, 342, 340),
        344: (344, 345, 343), 345: (344, 345, 343),
        347: (347, 348, 346), 348: (347, 348, 346),
        350: (350, 351, 349), 351: (350, 351, 349),
        353: (353, 354, 352), 354: (353, 354, 352),
        356: (356, 357, 355), 357: (356, 357, 355),
    },
    4: {
        210: (210, 211, 209), 211: (210, 211, 209),
        213: (213, 214, 212), 214: (213, 214, 212),
        216: (216, 217, 215), 217: (216, 217, 215),
        219: (219, 220, 218), 220: (219, 220, 218),
        222: (222, 223, 221), 223: (222, 223, 221),
    },
}

FLOOR_ROOF_PAIRS_MAP: dict[int, dict[int, int]] = {
    1: {50: 53, 53: 50, 51: 54, 54: 51, 43: 52, 52: 43},
    2: {159: 164, 164: 159, 160: 165, 165: 160, 161: 166, 166: 161, 162: 167, 167: 162, 163: 168, 168: 163},
    3: {167: 172, 172: 167, 168: 173, 173: 168, 169: 174, 174: 169, 170: 175, 175: 170, 171: 176, 176: 171},
    4: {201: 208, 208: 201, 205: 207, 207: 205, 202: 206, 203: 206, 204: 206},
}

# Alias client map IDs (6=Russia, 7=Japan) to manifest map IDs (3=Russia, 4=Japan)
HATCH_TRIADS_MAP[6] = HATCH_TRIADS_MAP[3]
HATCH_TRIADS_MAP[7] = HATCH_TRIADS_MAP[4]

FLOOR_ROOF_PAIRS_MAP[6] = FLOOR_ROOF_PAIRS_MAP[3]
FLOOR_ROOF_PAIRS_MAP[7] = FLOOR_ROOF_PAIRS_MAP[4]


def get_hatch_triad(map_id: int, wall_id: int) -> tuple[int, int, int] | None:
    """Return (top_wall_id, bottom_wall_id, pillar_group_id) for a hatch, or None."""
    norm_mid = _normalize_destruction_map_id(map_id)
    triads = HATCH_TRIADS_MAP.get(int(map_id)) or HATCH_TRIADS_MAP.get(norm_mid, {})
    wid = int(wall_id)
    if wid in triads:
        return triads[wid]
    for m_triads in HATCH_TRIADS_MAP.values():
        if wid in m_triads:
            return m_triads[wid]
    return None


def get_paired_floor_roof(
    map_id: int,
    wall_id: int,
    hit_point: tuple[float, float, float] | None = None,
) -> int | None:
    """Return the paired floor or roof wall ID, or None."""
    mid = int(map_id)
    norm_mid = _normalize_destruction_map_id(map_id)
    wid = int(wall_id)
    pairs = FLOOR_ROOF_PAIRS_MAP.get(mid) or FLOOR_ROOF_PAIRS_MAP.get(norm_mid, {})
    if (mid in (4, 7) or norm_mid == 4) and wid == 206 and hit_point is not None:
        z = hit_point[2]
        if z < 2.0:
            return 202
        elif z < 9.0:
            return 203
        else:
            return 204
    if wid in pairs:
        return pairs[wid]
    for m_pairs in FLOOR_ROOF_PAIRS_MAP.values():
        if wid in m_pairs:
            return m_pairs[wid]
    return None


def get_wall_asset_blocks(asset_name: str) -> tuple[dict, list[dict]]:
    """
    Returns (size_dict, blocks_list) for a given wall name.
    blocks_list is a list of {'x': float, 'y': float, 'r': float}.
    """
    manifest = load_wall_blocks_manifest()
    clean_name = str(asset_name or '').strip().split(' ')[0].lower()

    if clean_name in manifest:
        entry = manifest[clean_name]
        return entry.get('size', {}), entry.get('blocks', [])

    asset_prefixed = f"asset_{clean_name}"
    if asset_prefixed in manifest:
        entry = manifest[asset_prefixed]
        return entry.get('size', {}), entry.get('blocks', [])

    # Fuzzy match across manifest keys
    for k, v in manifest.items():
        k_lower = k.lower().replace('asset_', '')
        if clean_name in k_lower or k_lower in clean_name:
            return v.get('size', {}), v.get('blocks', [])

    if 'lockfloor' in clean_name or 'hatch' in clean_name:
        entry = manifest.get('asset_break_lockfloor01', {})
        if entry:
            return entry.get('size', {}), entry.get('blocks', [])

    if '175x' in clean_name:
        entry = manifest.get('asset_break_wall175x3') or manifest.get('asset_break_wall175x2', {})
        if entry:
            return entry.get('size', {}), entry.get('blocks', [])

    default_entry = manifest.get('asset_break_wall250', {})
    return default_entry.get('size', {'x': 2.5, 'y': 3.25, 'z': 0.18}), default_entry.get('blocks', [])


def world_to_wall_local(
    point: tuple[float, float, float],
    anchor: tuple[float, float, float],
    yaw_deg: float,
    is_floor: bool = False,
    matrix: list[list[float]] | None = None,
) -> tuple[float, float, float]:
    """Convert world coordinates to wall local coordinates using 4x4 matrix (or legacy yaw)."""
    if matrix and len(matrix) >= 3 and len(matrix[0]) >= 4:
        px, py, pz = float(point[0]), float(point[1]), float(point[2])
        lx = matrix[0][0] * px + matrix[0][1] * py + matrix[0][2] * pz + matrix[0][3]
        ly = matrix[1][0] * px + matrix[1][1] * py + matrix[1][2] * pz + matrix[1][3]
        lz = matrix[2][0] * px + matrix[2][1] * py + matrix[2][2] * pz + matrix[2][3]
        return lx, ly, lz

    dx = float(point[0]) - float(anchor[0])
    dy = float(point[1]) - float(anchor[1])
    dz = float(point[2]) - float(anchor[2])
    rad = math.radians(-float(yaw_deg))
    cos_y = math.cos(rad)
    sin_y = math.sin(rad)
    if is_floor:
        lx = dx * cos_y - dz * sin_y
        lz = dx * sin_y + dz * cos_y
        ly = dy
    else:
        lx = dx * cos_y - dz * sin_y
        ly = dy
        lz = dx * sin_y + dz * cos_y
    return lx, ly, lz


def raycast_all_walls(
    ray_origin: tuple[float, float, float],
    ray_dir: tuple[float, float, float],
    max_range: float,
    wall_metadata: dict[int, dict],
    wall_anchors: dict[int, tuple[float, float, float]] | None = None,
) -> list[tuple[int, dict, tuple[float, float], tuple[float, float, float], float]]:
    """
    Perform analytical ray-plane intersection against all walls in wall_metadata.
    Uses authoritative 4x4 world_to_local_matrix when available, with fallback to legacy yaw.
    Returns a list of (wall_id, meta, (lx, ly), world_hit, t) sorted by t ascending.
    """
    if not wall_metadata:
        return []

    rd_len = math.sqrt(ray_dir[0] ** 2 + ray_dir[1] ** 2 + ray_dir[2] ** 2)
    if rd_len < 1e-6:
        return []
    rd = (ray_dir[0] / rd_len, ray_dir[1] / rd_len, ray_dir[2] / rd_len)
    ro = (float(ray_origin[0]), float(ray_origin[1]), float(ray_origin[2]))

    hits: list[tuple[int, dict, tuple[float, float], tuple[float, float, float], float]] = []

    for wid, meta in wall_metadata.items():
        mat = meta.get('world_to_local_matrix')
        if mat and len(mat) >= 3 and len(mat[0]) >= 4:
            # Universal 4x4 Affine Transformation (Wall plane is Z_local = 0)
            rox = mat[0][0] * ro[0] + mat[0][1] * ro[1] + mat[0][2] * ro[2] + mat[0][3]
            roy = mat[1][0] * ro[0] + mat[1][1] * ro[1] + mat[1][2] * ro[2] + mat[1][3]
            roz = mat[2][0] * ro[0] + mat[2][1] * ro[1] + mat[2][2] * ro[2] + mat[2][3]

            rdx = mat[0][0] * rd[0] + mat[0][1] * rd[1] + mat[0][2] * rd[2]
            rdy = mat[1][0] * rd[0] + mat[1][1] * rd[1] + mat[1][2] * rd[2]
            rdz = mat[2][0] * rd[0] + mat[2][1] * rd[1] + mat[2][2] * rd[2]

            if abs(rdz) < 1e-6:
                continue

            t = -roz / rdz
            if t < 0.02 or t > max_range:
                continue

            lx = rox + t * rdx
            ly = roy + t * rdy

            size_dict = meta.get('size')
            if not size_dict:
                size_dict, _ = get_wall_asset_blocks(meta.get('name', ''))
            w_size_x = float(size_dict.get('x', 2.5) or 2.5)
            w_size_y = float(size_dict.get('y', 3.25) or 3.25)

            half_w = (w_size_x * 0.5) + 0.35
            half_h = (w_size_y * 0.5) + 0.35

            if abs(lx) <= half_w and abs(ly) <= half_h:
                world_hit = (ro[0] + t * rd[0], ro[1] + t * rd[1], ro[2] + t * rd[2])
                hits.append((wid, meta, (lx, ly), world_hit, t))
            continue

        # Legacy Fallback Branch
        anchor = None
        if wall_anchors:
            anchor = wall_anchors.get(wid)
        if not anchor:
            anchor = meta.get('anchor')
        if not anchor or len(anchor) < 3:
            continue

        yaw = float(meta.get('yaw_deg', 0.0))
        is_floor = bool(meta.get('is_floor', False))
        size_dict, _ = get_wall_asset_blocks(meta.get('name', ''))

        w_size_x = float(size_dict.get('x', 2.5) or 2.5)
        w_size_y = float(size_dict.get('y', 3.25) or 3.25)

        dx = ro[0] - float(anchor[0])
        dy = ro[1] - float(anchor[1])
        dz = ro[2] - float(anchor[2])
        rad = math.radians(-yaw)
        cy = math.cos(rad)
        sy = math.sin(rad)

        if not is_floor:
            oz = dx * sy + dz * cy
            dz_dir = rd[0] * sy + rd[2] * cy
            if abs(dz_dir) < 1e-5:
                continue
            t = -oz / dz_dir
            if t < 0.05 or t > max_range:
                continue

            ox = dx * cy - dz * sy
            oy = dy
            dx_dir = rd[0] * cy - rd[2] * sy
            dy_dir = rd[1]
            lx = ox + t * dx_dir
            ly = oy + t * dy_dir

            half_w = (w_size_x * 0.5) + 0.20
            half_h = (w_size_y * 0.5) + 0.25
            if abs(lx) <= half_w and abs(ly) <= half_h:
                world_hit = (ro[0] + t * rd[0], ro[1] + t * rd[1], ro[2] + t * rd[2])
                hits.append((wid, meta, (lx, ly), world_hit, t))
        else:
            oy = dy
            dy_dir = rd[1]
            if abs(dy_dir) < 1e-5:
                continue
            t = -oy / dy_dir
            if t < 0.05 or t > max_range:
                continue

            ox = dx * cy - dz * sy
            oz = dx * sy + dz * cy
            dx_dir = rd[0] * cy - rd[2] * sy
            dz_dir = rd[0] * sy + rd[2] * cy
            lx = ox + t * dx_dir
            lz = oz + t * dz_dir

            half_x = (w_size_x * 0.5) + 0.30
            half_z = (w_size_y * 0.5) + 0.30
            if abs(lx) <= half_x and abs(lz) <= half_z:
                world_hit = (ro[0] + t * rd[0], ro[1] + t * rd[1], ro[2] + t * rd[2])
                hits.append((wid, meta, (lx, lz), world_hit, t))

    hits.sort(key=lambda item: item[4])
    return hits


def raycast_wall(
    ray_origin: tuple[float, float, float],
    ray_dir: tuple[float, float, float],
    max_range: float,
    wall_metadata: dict[int, dict],
    wall_anchors: dict[int, tuple[float, float, float]] | None = None,
    preferred_wall_id: int | None = None,
) -> tuple[int | None, dict | None, tuple[float, float], tuple[float, float, float], float]:
    """
    Perform analytical ray-plane intersection against all walls in wall_metadata.
    Returns: (best_wall_id, best_meta, (best_lx, best_ly), best_world_hit, best_t)
    """
    hits = raycast_all_walls(ray_origin, ray_dir, max_range, wall_metadata, wall_anchors)
    if not hits:
        return None, None, (0.0, 0.0), (0.0, 0.0, 0.0), float('inf')
    if preferred_wall_id is not None:
        p_id = int(preferred_wall_id) & 0xFFFFFFFF
        for h in hits:
            if h[0] == p_id:
                return h
    return hits[0]


def calculate_wall_blocks_in_radius(
    wall_meta: dict,
    local_hit: tuple[float, float],
    destroy_type: int,
    broken_so_far: set[int],
    explosion_radius: float = 1.25,
) -> tuple[list[int], bool]:
    """
    Calculate wall block indices to break based on physical layout and Euclidean radius.
    Explosion / Thermite radius is 1.25m (width of one standard wall section, 2.5m diameter).
    """
    is_hatch = bool(
        wall_meta.get('is_hatch', False)
        or wall_meta.get('wall_type') == 3
        or 'hatch' in str(wall_meta.get('name', '')).lower()
        or 'lockfloor' in str(wall_meta.get('name', '')).lower()
        or 'hatch' in str(wall_meta.get('go_name', '')).lower()
        or 'lockfloor' in str(wall_meta.get('go_name', '')).lower()
    )
    dt = int(destroy_type or 0) & 0xFF
    is_explosion = (
        dt in (
            DESTROY_TYPE_EXPLOSIVE_DAMAGE,
            DESTROY_TYPE_THERMITE_BOMB,
            DESTROY_TYPE_BURN_DAMAGE,
        )
        or dt in (10, 15, 17, 18)
    )

    # Use authoritative blocks from wall_meta if present, otherwise fallback to asset lookup
    blocks = wall_meta.get('blocks')
    if not blocks:
        _, blocks = get_wall_asset_blocks(wall_meta.get('name', ''))

    total_blocks = len(blocks) if blocks else 54

    # Floor Hatch handling
    if is_hatch:
        if is_explosion or dt in (DESTROY_TYPE_SHOT_GUN_DAMAGE, DESTROY_TYPE_HAMMER_DAMAGE):
            all_blocks = list(range(total_blocks))
            new_blocks = [b for b in all_blocks if b not in broken_so_far]
            return new_blocks, True
        # For gunfire and knife attacks, do not use sequential index slicing;
        # fall through to Euclidean distance matching so hits break the exact block
        # at the impact point (e.g. center hits break center blocks).

    lx, ly = float(local_hit[0]), float(local_hit[1])

    candidates: list[tuple[float, int]] = []
    for idx, b in enumerate(blocks):
        bx = float(b.get('x', 0.0))
        by = float(b.get('y', 0.0))
        dist = math.sqrt((bx - lx) ** 2 + (by - ly) ** 2)
        candidates.append((dist, idx))

    candidates.sort(key=lambda item: item[0])

    if is_explosion or dt == DESTROY_TYPE_THERMITE_BOMB:
        # Radial explosion/thermite destruction: all blocks strictly within radius (default 1.25m)
        new_blocks = [
            idx for dist, idx in candidates
            if dist <= explosion_radius and idx not in broken_so_far
        ]
        is_full = (len(broken_so_far) + len(new_blocks)) >= total_blocks
        return new_blocks, is_full

    elif dt == DESTROY_TYPE_SHOT_GUN_DAMAGE:
        # Shotgun: up to 4 unbroken blocks strictly within shotgun spread radius
        shotgun_radius = 0.60
        new_blocks = [
            idx for dist, idx in candidates
            if dist <= shotgun_radius and idx not in broken_so_far
        ][:4]
        is_full = (len(broken_so_far) + len(new_blocks)) >= total_blocks
        return new_blocks, is_full

    elif dt == DESTROY_TYPE_HAMMER_DAMAGE:
        # Sledge hammer: creates a half-height (crouch/vault) opening (~18-20 blocks, ~1.9m diameter)
        hammer_radius = 0.95
        new_blocks = [
            idx for dist, idx in candidates
            if dist <= hammer_radius and idx not in broken_so_far
        ]
        is_full = (len(broken_so_far) + len(new_blocks)) >= total_blocks
        return new_blocks, is_full

    else:
        # Rifle, pistol, sniper, knife (melee): exactly the single block at the hit point.
        # If the impacted block is already broken (a hole), the attack passes through without destroying anything.
        if not candidates:
            return [], len(broken_so_far) >= total_blocks

        closest_dist, closest_idx = candidates[0]
        b_radius = float(blocks[closest_idx].get('r', 0.30) or 0.30)
        # Threshold to match block area (block radius + 0.10m margin, at least 0.35m)
        hit_threshold = max(b_radius + 0.10, 0.35)

        if closest_dist <= hit_threshold:
            if closest_idx in broken_so_far:
                # Impacted block is already broken -> attack passes straight through without destroying new blocks!
                return [], len(broken_so_far) >= total_blocks
            new_blocks = [closest_idx]
            is_full = (len(broken_so_far) + 1) >= total_blocks
            return new_blocks, is_full

        # Did not hit close enough to any block
        return [], len(broken_so_far) >= total_blocks


# ═══════════════════════════════════════════════════════════════════════════════
#  Destruction Engine Class
# ═══════════════════════════════════════════════════════════════════════════════

class DestructionEngine:
    """
    Manages session-level state and protocol packet generation for all
    map destruction, walls, floors, barricades, and reinforcements.
    """

    @staticmethod
    def handle_destroy_scene_object(
        session: Any,
        req: dict,
        packet_builders: dict[str, Callable],
        log_fn: Callable | None = None,
    ) -> list[bytes]:
        """
        Handle client ReqDestroySceneObject (0x463).
        Decodes destroy_objects vector<u64>, updates session stores, and returns
        packets to broadcast.
        """
        _log = log_fn or (lambda msg: None)
        destroy_type = int(req.get('destroy_type', DESTROY_TYPE_NONE) or DESTROY_TYPE_NONE)
        destroy_pos = req.get('destroy_pos', (0.0, 0.0, 0.0))
        raw_objects = req.get('destroy_objects', []) or []
        effect_type = destroy_type_to_effect_type(destroy_type)

        build_rsp_destroy_scene_object = packet_builders.get('build_rsp_destroy_scene_object')
        build_rsp_event_wall_block_destroy = packet_builders.get('build_rsp_event_wall_block_destroy')
        build_rsp_event_wall_destroy = packet_builders.get('build_rsp_event_wall_destroy')
        apply_simple_quintain_destroy = packet_builders.get('apply_simple_quintain_destroy')

        packets: list[bytes] = []

        # Always include the echo RspDestroySceneObject (0x464)
        if build_rsp_destroy_scene_object:
            packets.append(build_rsp_destroy_scene_object(destroy_type, destroy_pos, raw_objects))

        if session is None or not raw_objects:
            _log(f"[Destruction] ReqDestroySceneObject type={destroy_type} objects={len(raw_objects)} session=None")
            return packets

        wall_hits: dict[int, set[int]] = {}
        target_ids: set[int] = set()

        for raw_u64 in raw_objects:
            kind, local_id, index1, index2 = decode_unique_id(raw_u64)
            if local_id <= 0:
                continue

            if kind in WALL_ENTRY_KINDS:
                wall_hits.setdefault(local_id, set()).add(index1)
            elif kind in TARGET_ENTRY_KINDS:
                target_ids.add(local_id)
            else:
                _log(f"[Destruction] unhandled EntryType kind={kind} local_id={local_id} i1={index1}")

        with session._lock:
            # 1. Process wall / floor / hatch block damage
            for wall_id, requested_blocks in sorted(wall_hits.items()):
                broken_set = session.wall_broken_blocks.setdefault(wall_id, set())
                new_blocks = [b for b in sorted(requested_blocks) if b not in broken_set]
                if not new_blocks:
                    continue

                broken_set.update(new_blocks)

                # Keep dynamic wall state active for snapshot queries
                dyn = session.wall_dynamic_walls.setdefault(
                    wall_id,
                    {'state': BLOCKING_BOARD_STATE_DEACTIVE, 'blocks': set()},
                )
                dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
                dyn.setdefault('blocks', set()).update(new_blocks)

                # Check if this was a shotgun blast or explosive on a floor hatch -> full wall destroy
                is_full_destroy = destroy_type in (
                    DESTROY_TYPE_EXPLOSIVE_DAMAGE,
                    DESTROY_TYPE_SHOT_GUN_DAMAGE,
                    DESTROY_TYPE_HAMMER_DAMAGE,
                ) and len(broken_set) >= 6

                if is_full_destroy and build_rsp_event_wall_destroy:
                    packets.append(build_rsp_event_wall_destroy(wall_id))
                    _log(f"[Destruction] Wall/Hatch full destroy wall_id={wall_id} type={destroy_type}")
                elif build_rsp_event_wall_block_destroy:
                    try:
                        pkt = build_rsp_event_wall_block_destroy(
                            wall_id,
                            effect_type,
                            destroy_pos,
                            new_blocks,
                        )
                    except TypeError:
                        pkt = build_rsp_event_wall_block_destroy(
                            wall_id=wall_id,
                            damage_type=effect_type,
                            src_pos=destroy_pos,
                            blocks=new_blocks,
                        )
                    packets.append(pkt)
                    _log(f"[Destruction] Wall block destroy wall_id={wall_id} blocks={new_blocks} effect={effect_type}")

            # 2. Process training targets
            for target_id in target_ids:
                if apply_simple_quintain_destroy:
                    apply_simple_quintain_destroy(session, target_id)
                    _log(f"[Destruction] SimpleQuintain destroyed target_id={target_id}")

        return packets

    @staticmethod
    def handle_wall_damage(
        session: Any,
        destroy_type: int,
        damage_source: tuple[float, float, float],
        preferred_wall_id: int | None = None,
        ray_samples: list[dict] | None = None,
        packet_builders: dict[str, Callable] | None = None,
        log_fn: Callable | None = None,
    ) -> list[bytes]:
        """
        Resolve damage against a soft wall, floor, or hatch from gunfire, knife, explosion, or thermite.
        Uses exact raycast for directional attacks (bullets/melee) and radial selection for explosions.
        """
        _log = log_fn or (lambda msg: None)
        if session is None or not getattr(session, 'wall_metadata', None):
            return []

        pb = packet_builders or {}
        build_rsp_event_wall_block_destroy = pb.get('build_rsp_event_wall_block_destroy')
        build_rsp_event_wall_destroy = pb.get('build_rsp_event_wall_destroy')
        build_rsp_destroy_scene_object = pb.get('build_rsp_destroy_scene_object')
        build_rsp_reinforced_del = pb.get('build_rsp_reinforced_del')

        d_type = int(destroy_type or 0) & 0xFF
        is_explosion = (
            d_type in (
                DESTROY_TYPE_EXPLOSIVE_DAMAGE,
                DESTROY_TYPE_THERMITE_BOMB,
                DESTROY_TYPE_BURN_DAMAGE,
            )
            or d_type in (10, 15, 17, 18)
        )
        is_melee = (d_type in (DESTROY_TYPE_MELEE_DAMAGE, DESTROY_TYPE_HAMMER_DAMAGE))

        with session._lock:
            wall_id = None
            meta = None
            lx = 0.0
            ly = 0.0
            hit_world = damage_source

            n_walls = len(getattr(session, 'wall_metadata', {}))
            _log(
                f"[WallDmg] START d_type={d_type} is_explosion={is_explosion} is_melee={is_melee} "
                f"pref_wall={preferred_wall_id} n_walls={n_walls} "
                f"ray_samples={len(ray_samples) if ray_samples else 0} "
                f"src={tuple(round(v,2) for v in damage_source)}"
            )

            # 1. Try raycast if ray samples are present (gun fire or knife/hammer melee)
            if ray_samples:
                max_range = 2.5 if is_melee else 50.0
                for si, s in enumerate(ray_samples):
                    if not isinstance(s, dict):
                        continue
                    ro = s.get('pos')
                    rd = s.get('dir')
                    if not ro or not rd:
                        continue
                    hits = raycast_all_walls(
                        ray_origin=ro,
                        ray_dir=rd,
                        max_range=max_range,
                        wall_metadata=session.wall_metadata,
                        wall_anchors=getattr(session, 'wall_anchors', None),
                    )
                    for r_wall_id, r_meta, r_local, r_world, r_t in hits:
                        # Check if reinforced:
                        is_reinf = (
                            getattr(session, 'reinforced_states', {}).get(r_wall_id, REINFORCED_STATE_INIT)
                            in (REINFORCED_STATE_ACTIVED1, REINFORCED_STATE_ACTIVED2)
                        )
                        if is_reinf and d_type != DESTROY_TYPE_THERMITE_BOMB:
                            wall_id = r_wall_id
                            meta = r_meta
                            lx, ly = r_local
                            hit_world = r_world
                            _log(f"[WallDmg] RAY[{si}] hit REINFORCED wall={r_wall_id} t={r_t:.2f} (absorbed)")
                            break

                        r_broken = session.wall_broken_blocks.setdefault(r_wall_id, set())
                        cand_blocks, cand_full = calculate_wall_blocks_in_radius(
                            r_meta, r_local, d_type, r_broken
                        )
                        if cand_blocks or cand_full:
                            wall_id = r_wall_id
                            meta = r_meta
                            lx, ly = r_local
                            hit_world = r_world
                            _log(
                                f"[WallDmg] RAY[{si}] pos={tuple(round(v,2) for v in ro)} "
                                f"dir={tuple(round(v,3) for v in rd)} "
                                f"=> HIT wall={r_wall_id} t={r_t:.2f} local={tuple(round(v,3) for v in r_local)} "
                                f"blocks={cand_blocks}"
                            )
                            break
                        else:
                            _log(
                                f"[WallDmg] RAY[{si}] passes through broken hole in wall={r_wall_id} "
                                f"t={r_t:.2f} local={tuple(round(v,3) for v in r_local)}"
                            )
                    if wall_id is not None:
                        break

            # 2. Select target walls:
            # - For directional attacks (gunfire, knife): use single raycast wall or preferred/closest fallback.
            # - For explosions (C4, breach charge, grenades, thermite): collect ALL walls, floors, and hatches
            #   within blast_radius (2.0m) of damage_source so adjacent corner walls, junctions, and double walls
            #   are damaged together.
            target_walls: list[tuple[int, dict, tuple[float, float], float]] = []

            if not is_explosion and wall_id is not None and meta is not None:
                target_walls.append((wall_id, meta, (lx, ly), 0.0))
            elif not is_explosion:
                # Single wall fallback for non-explosive attacks
                # For melee attacks (knife/hammer), strictly require attacker to be within 2.4m reach!
                cand_id = None
                cand_meta = None
                cand_local = (0.0, 0.0)
                attacker_pos = damage_source
                if ray_samples and isinstance(ray_samples[0], dict) and ray_samples[0].get('pos'):
                    try:
                        attacker_pos = tuple(float(v) for v in ray_samples[0]['pos'])
                    except Exception:
                        attacker_pos = damage_source

                if preferred_wall_id is not None:
                    p_id = int(preferred_wall_id) & 0xFFFFFFFF
                    if p_id in session.wall_metadata:
                        cand_meta_tmp = session.wall_metadata[p_id]
                        allow_pref = True
                        if is_melee:
                            w_anc = getattr(session, 'wall_anchors', {}).get(p_id, cand_meta_tmp.get('anchor'))
                            if w_anc:
                                if math.dist(attacker_pos, w_anc) > 3.2:
                                    allow_pref = False
                        if allow_pref:
                            cand_id = p_id
                            cand_meta = cand_meta_tmp
                            mat = cand_meta.get('world_to_local_matrix')
                            if mat and len(mat) >= 3 and len(mat[0]) >= 4:
                                plx = mat[0][0]*damage_source[0] + mat[0][1]*damage_source[1] + mat[0][2]*damage_source[2] + mat[0][3]
                                ply = mat[1][0]*damage_source[0] + mat[1][1]*damage_source[1] + mat[1][2]*damage_source[2] + mat[1][3]
                                size = cand_meta.get('size', {})
                                hw = float(size.get('x', 2.5) or 2.5) * 0.5
                                hh = float(size.get('y', 3.25) or 3.25) * 0.5
                                cand_local = (max(-hw, min(hw, plx)), max(-hh, min(hh, ply)))
                            else:
                                anchor = getattr(session, 'wall_anchors', {}).get(p_id, cand_meta.get('anchor'))
                                yaw = float(cand_meta.get('yaw_deg', 0.0))
                                is_f = bool(cand_meta.get('is_floor', False))
                                if anchor:
                                    plx, ply, plz = world_to_wall_local(damage_source, anchor, yaw, is_f)
                                    cand_local = (plx, plz if is_f else ply)
                if cand_id is None:
                    best_dist = float('inf')
                    for wid, w_meta in session.wall_metadata.items():
                        mat = w_meta.get('world_to_local_matrix')
                        if mat and len(mat) >= 3 and len(mat[0]) >= 4:
                            plx = mat[0][0]*damage_source[0] + mat[0][1]*damage_source[1] + mat[0][2]*damage_source[2] + mat[0][3]
                            ply = mat[1][0]*damage_source[0] + mat[1][1]*damage_source[1] + mat[1][2]*damage_source[2] + mat[1][3]
                            plz = mat[2][0]*damage_source[0] + mat[2][1]*damage_source[1] + mat[2][2]*damage_source[2] + mat[2][3]
                            size = w_meta.get('size', {})
                            hw = float(size.get('x', 2.5) or 2.5) * 0.5
                            hh = float(size.get('y', 3.25) or 3.25) * 0.5
                            clamped_x = max(-hw, min(hw, plx))
                            clamped_y = max(-hh, min(hh, ply))
                            dist_val = math.sqrt((plx - clamped_x)**2 + (ply - clamped_y)**2 + plz*plz)
                            cand_threshold = 2.4 if is_melee else 2.5
                            if is_melee:
                                # Distance from attacker position to wall anchor / hit point
                                w_anc = getattr(session, 'wall_anchors', {}).get(wid, w_meta.get('anchor'))
                                if w_anc and math.dist(attacker_pos, w_anc) > 3.0:
                                    continue
                            if dist_val < best_dist and dist_val <= cand_threshold:
                                best_dist = dist_val
                                cand_id = wid
                                cand_meta = w_meta
                                cand_local = (clamped_x, clamped_y)
                if cand_id is not None and cand_meta is not None:
                    target_walls.append((cand_id, cand_meta, cand_local, 0.0))
            else:
                # Multi-wall radial search for explosions
                blast_radius = 2.0
                candidates: list[tuple[int, dict, tuple[float, float], float]] = []
                for wid, w_meta in session.wall_metadata.items():
                    mat = w_meta.get('world_to_local_matrix')
                    if mat and len(mat) >= 3 and len(mat[0]) >= 4:
                        plx = mat[0][0]*damage_source[0] + mat[0][1]*damage_source[1] + mat[0][2]*damage_source[2] + mat[0][3]
                        ply = mat[1][0]*damage_source[0] + mat[1][1]*damage_source[1] + mat[1][2]*damage_source[2] + mat[1][3]
                        plz = mat[2][0]*damage_source[0] + mat[2][1]*damage_source[1] + mat[2][2]*damage_source[2] + mat[2][3]
                        size = w_meta.get('size', {})
                        hw = float(size.get('x', 2.5) or 2.5) * 0.5
                        hh = float(size.get('y', 3.25) or 3.25) * 0.5
                        clamped_x = max(-hw, min(hw, plx))
                        clamped_y = max(-hh, min(hh, ply))
                        dist_val = math.sqrt((plx - clamped_x)**2 + (ply - clamped_y)**2 + plz*plz)
                        candidates.append((wid, w_meta, (clamped_x, clamped_y), dist_val))
                    else:
                        anchor = getattr(session, 'wall_anchors', {}).get(wid, w_meta.get('anchor'))
                        if not anchor:
                            continue
                        yaw = float(w_meta.get('yaw_deg', 0.0))
                        is_f = bool(w_meta.get('is_floor', False))
                        plx, ply, plz = world_to_wall_local(damage_source, anchor, yaw, is_f)
                        if is_f:
                            dist_val = math.sqrt(ply*ply + plx*plx + plz*plz)
                            candidates.append((wid, w_meta, (plx, plz), dist_val))
                        else:
                            dist_val = math.sqrt(plz*plz + plx*plx + ply*ply)
                            candidates.append((wid, w_meta, (plx, ply), dist_val))

                candidates.sort(key=lambda item: item[3])
                in_range = [c for c in candidates if c[3] <= blast_radius]

                # Ensure preferred_wall_id is included and put first if provided
                if preferred_wall_id is not None:
                    p_id = int(preferred_wall_id) & 0xFFFFFFFF
                    pref_match = next((c for c in candidates if c[0] == p_id), None)
                    if pref_match:
                        target_walls.append(pref_match)
                        for c in in_range:
                            if c[0] != p_id:
                                target_walls.append(c)
                    else:
                        target_walls.extend(in_range)
                else:
                    target_walls.extend(in_range)

                # Fallback to closest wall within 5.0m if nothing was inside blast_radius
                if not target_walls and candidates and candidates[0][3] <= 5.0:
                    target_walls.append(candidates[0])

            if not target_walls:
                _log("[WallDmg] NO WALL FOUND")
                return []

            _log(
                f"[WallDmg] RESOLVING {len(target_walls)} candidate walls: "
                f"{[(tw[0], round(tw[3], 2)) for tw in target_walls]}"
            )

            packets: list[bytes] = []
            processed_walls: set[int] = set()
            hatch_pgs_to_destroy_fully: set[int] = set()
            effect_type = destroy_type_to_effect_type(d_type)
            map_id = getattr(session, 'map_id', 1)

            # 3. Process each wall within blast radius
            for wall_id, meta, (lx, ly), dist in target_walls:
                if wall_id in processed_walls:
                    continue

                # Check reinforcement
                is_reinforced = (
                    getattr(session, 'reinforced_states', {}).get(wall_id, REINFORCED_STATE_INIT)
                    in (REINFORCED_STATE_ACTIVED1, REINFORCED_STATE_ACTIVED2)
                )
                if is_reinforced:
                    if d_type != DESTROY_TYPE_THERMITE_BOMB:
                        processed_walls.add(wall_id)
                        _log(f"[WallDmg] Wall {wall_id} is REINFORCED (absorbed)")
                        continue
                    session.reinforced_states[wall_id] = REINFORCED_STATE_DELETED
                    session.reinforced_walls.pop(wall_id, None)
                    session.reinforced_wall_items.discard(wall_id)
                    if build_rsp_reinforced_del:
                        packets.append(build_rsp_reinforced_del(wall_id))

                # Check if this wall is a floor hatch
                triad = get_hatch_triad(map_id, wall_id)
                is_hatch = bool(
                    triad is not None
                    or meta.get('is_hatch', False)
                    or meta.get('wall_type') == 3
                    or 'hatch' in str(meta.get('name', '')).lower()
                    or 'lockfloor' in str(meta.get('name', '')).lower()
                    or 'hatch' in str(meta.get('go_name', '')).lower()
                    or 'lockfloor' in str(meta.get('go_name', '')).lower()
                )

                # A) Hatch destruction: complete destruction of both top & bottom skins and all crossbars
                if is_hatch and (is_explosion or d_type in (DESTROY_TYPE_HAMMER_DAMAGE, DESTROY_TYPE_THERMITE_BOMB, DESTROY_TYPE_SHOT_GUN_DAMAGE)):
                    if triad:
                        top_id, bot_id, hatch_pg = triad
                        hatch_pgs_to_destroy_fully.add(hatch_pg)
                        hatch_skins = [top_id, bot_id]
                    else:
                        hatch_skins = [wall_id]

                    for h_id in hatch_skins:
                        if h_id not in session.wall_metadata:
                            continue
                        processed_walls.add(h_id)
                        h_meta = session.wall_metadata[h_id]
                        h_broken_set = session.wall_broken_blocks.setdefault(h_id, set())
                        h_blocks = h_meta.get('blocks')
                        if not h_blocks:
                            _, h_blocks = get_wall_asset_blocks(h_meta.get('name', ''))
                        total_h = len(h_blocks) if h_blocks else 20
                        all_h_indices = list(range(total_h))
                        h_broken_set.update(all_h_indices)
                        session.broken_walls.setdefault(h_id, set()).update(all_h_indices)
                        h_dyn = session.wall_dynamic_walls.setdefault(
                            h_id, {'state': BLOCKING_BOARD_STATE_DEACTIVE, 'blocks': set()}
                        )
                        h_dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
                        h_dyn.setdefault('blocks', set()).update(all_h_indices)

                        # Project src_pos correctly on each side of the slab so Linecast doesn't hit ceiling obstruction
                        h_anchor = getattr(session, 'wall_anchors', {}).get(h_id, h_meta.get('anchor', hit_world))
                        if triad and h_id == bot_id:
                            h_src_pos = (hit_world[0], float(h_anchor[1]) - 0.15, hit_world[2])
                        else:
                            h_src_pos = (hit_world[0], float(h_anchor[1]) + 0.15, hit_world[2])

                        if build_rsp_destroy_scene_object:
                            h_objs = [encode_unique_id(ENTRY_TYPE_DYNAMIC_WALL_BLOCK, h_id, int(b) & 0xFFFF, 0) for b in all_h_indices]
                            packets.append(build_rsp_destroy_scene_object(d_type, h_src_pos, h_objs))

                        if build_rsp_event_wall_block_destroy:
                            try:
                                packets.append(build_rsp_event_wall_block_destroy(h_id, effect_type, h_src_pos, all_h_indices))
                            except TypeError:
                                packets.append(build_rsp_event_wall_block_destroy(wall_id=h_id, damage_type=effect_type, src_pos=h_src_pos, blocks=all_h_indices))

                        if build_rsp_event_wall_destroy:
                            packets.append(build_rsp_event_wall_destroy(h_id))

                        _log(f"[WallDmg] Hatch skin {h_id} completely destroyed ({total_h} blocks, src={tuple(round(v,2) for v in h_src_pos)})")
                    continue

                # B) Regular soft wall or breakable floor destruction
                processed_walls.add(wall_id)
                broken_set = session.wall_broken_blocks.setdefault(wall_id, set())
                w_exp_radius = 1.60 if is_explosion else 1.25
                blocks_to_break, is_full_destroy = calculate_wall_blocks_in_radius(
                    meta, (lx, ly), d_type, broken_set, explosion_radius=w_exp_radius,
                )

                if blocks_to_break or is_full_destroy:
                    broken_set.update(blocks_to_break)
                    session.broken_walls.setdefault(wall_id, set()).update(blocks_to_break)
                    dyn = session.wall_dynamic_walls.setdefault(
                        wall_id, {'state': BLOCKING_BOARD_STATE_DEACTIVE, 'blocks': set()},
                    )
                    dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
                    dyn.setdefault('blocks', set()).update(blocks_to_break)

                    if build_rsp_destroy_scene_object and blocks_to_break:
                        destroy_objects = [encode_unique_id(ENTRY_TYPE_DYNAMIC_WALL_BLOCK, wall_id, int(blk) & 0xFFFF, 0) for blk in blocks_to_break]
                        packets.append(build_rsp_destroy_scene_object(d_type, hit_world, destroy_objects))

                    if blocks_to_break and build_rsp_event_wall_block_destroy:
                        try:
                            packets.append(build_rsp_event_wall_block_destroy(wall_id, effect_type, hit_world, blocks_to_break))
                        except TypeError:
                            packets.append(build_rsp_event_wall_block_destroy(wall_id=wall_id, damage_type=effect_type, src_pos=hit_world, blocks=blocks_to_break))

                    if is_full_destroy and build_rsp_event_wall_destroy:
                        packets.append(build_rsp_event_wall_destroy(wall_id))

                    _log(f"[WallDmg] Wall {wall_id} damaged {len(blocks_to_break)} blocks, full={is_full_destroy}")

                # Synchronized penetration for paired floor/roof
                paired_floor_roof_id = get_paired_floor_roof(map_id, wall_id, hit_world)
                if paired_floor_roof_id and paired_floor_roof_id in session.wall_metadata and paired_floor_roof_id not in processed_walls:
                    processed_walls.add(paired_floor_roof_id)
                    p_meta = session.wall_metadata[paired_floor_roof_id]
                    p_mat = p_meta.get('world_to_local_matrix')
                    if p_mat and len(p_mat) >= 3 and len(p_mat[0]) >= 4:
                        plx = p_mat[0][0]*hit_world[0] + p_mat[0][1]*hit_world[1] + p_mat[0][2]*hit_world[2] + p_mat[0][3]
                        ply = p_mat[1][0]*hit_world[0] + p_mat[1][1]*hit_world[1] + p_mat[1][2]*hit_world[2] + p_mat[1][3]
                        p_size = p_meta.get('size', {})
                        phw = float(p_size.get('x', 2.5) or 2.5) * 0.5
                        phh = float(p_size.get('y', 3.25) or 3.25) * 0.5
                        pl_local = (max(-phw, min(phw, plx)), max(-phh, min(phh, ply)))
                    else:
                        p_anchor = getattr(session, 'wall_anchors', {}).get(paired_floor_roof_id, p_meta.get('anchor'))
                        p_yaw = float(p_meta.get('yaw_deg', 0.0))
                        p_isf = bool(p_meta.get('is_floor', False))
                        if p_anchor:
                            pplx, pply, pplz = world_to_wall_local(hit_world, p_anchor, p_yaw, p_isf)
                            pl_local = (pplx, pplz if p_isf else pply)
                        else:
                            pl_local = (0.0, 0.0)

                    p_broken_set = session.wall_broken_blocks.setdefault(paired_floor_roof_id, set())
                    p_radius = 1.60 if is_explosion else 0.40
                    p_blocks, p_full = calculate_wall_blocks_in_radius(
                        p_meta, pl_local, d_type, p_broken_set, explosion_radius=p_radius,
                    )
                    if p_blocks or p_full:
                        p_broken_set.update(p_blocks)
                        session.broken_walls.setdefault(paired_floor_roof_id, set()).update(p_blocks)
                        p_dyn = session.wall_dynamic_walls.setdefault(
                            paired_floor_roof_id, {'state': BLOCKING_BOARD_STATE_DEACTIVE, 'blocks': set()}
                        )
                        p_dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
                        p_dyn.setdefault('blocks', set()).update(p_blocks)
                        if build_rsp_destroy_scene_object and p_blocks:
                            p_objs = [encode_unique_id(ENTRY_TYPE_DYNAMIC_WALL_BLOCK, paired_floor_roof_id, int(b) & 0xFFFF, 0) for b in p_blocks]
                            packets.append(build_rsp_destroy_scene_object(d_type, hit_world, p_objs))
                        if p_blocks and build_rsp_event_wall_block_destroy:
                            try:
                                packets.append(build_rsp_event_wall_block_destroy(paired_floor_roof_id, effect_type, hit_world, p_blocks))
                            except TypeError:
                                packets.append(build_rsp_event_wall_block_destroy(wall_id=paired_floor_roof_id, damage_type=effect_type, src_pos=hit_world, blocks=p_blocks))
                        if p_full and build_rsp_event_wall_destroy:
                            packets.append(build_rsp_event_wall_destroy(paired_floor_roof_id))
                        _log(f"[WallDmg] Paired floor/roof {paired_floor_roof_id} damaged {len(p_blocks)} blocks, full={p_full}")

            # 4. Pillar / wooden beam destruction:
            # - Hatches: destroy ALL 5 crossbars with is_full=True unconditionally.
            # - Walls: collect all pillar groups belonging to damaged walls OR within p_radius (2.0m)
            #   and destroy segments within radius.
            if is_explosion or d_type in (DESTROY_TYPE_HAMMER_DAMAGE, DESTROY_TYPE_THERMITE_BOMB):
                build_pillar_destroy = packet_builders.get('build_rsp_event_pillar_segments_destroy')
                if build_pillar_destroy:
                    p_radius = 2.00 if is_explosion else (1.00 if d_type == DESTROY_TYPE_HAMMER_DAMAGE else 1.25)
                    target_pgs: set[int] = set()

                    # Always include any hatch pillar groups affected in the blast
                    target_pgs.update(hatch_pgs_to_destroy_fully)

                    # Include pillar groups mapped to all processed walls
                    for pwid in processed_walls:
                        pw_meta = session.wall_metadata.get(pwid, {})
                        pg_id = pw_meta.get('pillar_group_id')
                        if not pg_id:
                            pg_id = get_pillar_group_for_wall(map_id, pwid)
                        if pg_id:
                            if isinstance(pg_id, list):
                                target_pgs.update(int(x) for x in pg_id)
                            else:
                                target_pgs.add(int(pg_id))

                    # 3D proximity scan across all pillar groups in map within p_radius
                    all_maps_pg = load_pillar_group_segments_3d_manifest()
                    norm_mid = _normalize_destruction_map_id(map_id)
                    map_dict = all_maps_pg.get(str(map_id)) or all_maps_pg.get(str(norm_mid), {})
                    for gid_str, g_data in map_dict.items():
                        gid = int(gid_str)
                        if gid in target_pgs:
                            continue
                        for pid_str, segs_dict in g_data.items():
                            for sid_str, pos in segs_dict.items():
                                if math.sqrt((pos[0] - hit_world[0])**2 + (pos[1] - hit_world[1])**2 + (pos[2] - hit_world[2])**2) <= p_radius:
                                    target_pgs.add(gid)
                                    break
                            if gid in target_pgs:
                                break

                    for single_pg in sorted(target_pgs):
                        pg_is_full = (single_pg in hatch_pgs_to_destroy_fully)
                        broken_pillars = calculate_broken_pillar_segments(
                            map_id=map_id,
                            group_id=single_pg,
                            hit_world=hit_world,
                            radius=p_radius,
                            is_full=pg_is_full,
                            session=session,
                        )
                        for p_id, segs in broken_pillars:
                            packets.append(build_pillar_destroy(single_pg, p_id, segs))
                        if broken_pillars:
                            _log(
                                f"[WallDmg] Explosives destroyed {len(broken_pillars)} pillars in PillarGroup {single_pg} "
                                f"(radius={p_radius}m, full={pg_is_full})"
                            )

            _log(f"[WallDmg] Resolved {len(processed_walls)} walls: {sorted(processed_walls)}, packets={len(packets)}")

        return packets

    @staticmethod
    def handle_blocking_board_damage(
        session: Any,
        board_id: int,
        hit_block_idx: int,
        damage_source: tuple[float, float, float],
        is_heavy_hit: bool,
        packet_builders: dict[str, Callable],
        log_fn: Callable | None = None,
        destroy_type: int = 0,
    ) -> list[bytes]:
        """
        Handle damage on a door/window wooden barricade.
        Updates broken blocks and HP; triggers full destruction after 3 melee hits or full HP loss.
        """
        _log = log_fn or (lambda msg: None)
        normalized_board_id = int(board_id or 0) & 0xFFFFFFFF
        if normalized_board_id <= 0:
            return []

        build_content_destroy = (
            packet_builders.get('build_rsp_event_blocking_board_destroy')
            or packet_builders.get('build_rsp_event_blocking_board_content_destroy')
        )
        build_board_destroy = packet_builders.get('build_rsp_destroy_blocking_board')
        build_board_state = packet_builders.get('build_rsp_event_blocking_board_state')

        packets: list[bytes] = []

        with session._lock:
            current_state = session.blocking_board_states.get(normalized_board_id, BLOCKING_BOARD_STATE_ACTIVE)
            if current_state == BLOCKING_BOARD_STATE_DEACTIVE:
                return []

            # Check profile for window vs door
            profile = session.blocking_board_profiles.get(normalized_board_id)
            is_window = getattr(profile, 'name', '') == 'window'
            total_blocks = WINDOW_BARRICADE_TOTAL if is_window else DOOR_BARRICADE_TOTAL

            is_hammer = (destroy_type == DESTROY_TYPE_HAMMER_DAMAGE)
            if is_hammer:
                broken_cluster = list(range(total_blocks))
            else:
                broken_cluster = get_barricade_hit_cluster(hit_block_idx, is_heavy_hit, is_window)
            dyn = session.dynamic_walls.setdefault(
                normalized_board_id,
                {'state': BLOCKING_BOARD_STATE_ACTIVE, 'blocks': set()},
            )
            existing_blocks = dyn.setdefault('blocks', set())
            new_blocks = [b for b in broken_cluster if b not in existing_blocks]
            existing_blocks.update(broken_cluster)

            # Track HP: 3 heavy hits (or 100% / 3 per hit), hammer destroys in 1 hit
            current_hp = float(session.blocking_board_hp.get(normalized_board_id, 100.0))
            damage_val = 100.0 if is_hammer else (35.0 if is_heavy_hit else 10.0)
            new_hp = max(0.0, current_hp - damage_val)
            session.blocking_board_hp[normalized_board_id] = new_hp

            _log(
                f"[Destruction] Barricade damage board_id={normalized_board_id} "
                f"hp={new_hp:.1f}% broken_blocks={len(existing_blocks)}/{total_blocks}"
            )

            # Send content destroy packet for newly broken blocks
            if new_blocks and build_content_destroy:
                try:
                    packets.append(build_content_destroy(
                        normalized_board_id,
                        damage_source,
                        new_blocks,
                    ))
                except TypeError:
                    packets.append(build_content_destroy(
                        id=normalized_board_id,
                        damage_source=damage_source,
                        blocks=new_blocks,
                    ))

            # Full board destruction
            if new_hp <= 0.0 or len(existing_blocks) >= (total_blocks * 0.26):
                session.blocking_board_states[normalized_board_id] = BLOCKING_BOARD_STATE_DEACTIVE
                dyn['state'] = BLOCKING_BOARD_STATE_DEACTIVE
                if build_board_destroy:
                    try:
                        packets.append(build_board_destroy(normalized_board_id, damage_source))
                    except TypeError:
                        packets.append(build_board_destroy(normalized_board_id))
                if build_board_state:
                    packets.append(build_board_state(normalized_board_id, None, BLOCKING_BOARD_STATE_DEACTIVE))
                _log(f"[Destruction] Barricade fully DESTROYED board_id={normalized_board_id}")

        return packets

    @staticmethod
    def handle_blocking_board_operate(
        session: Any,
        board_id: int,
        op: int,
        pose: dict,
        player_bid: int,
        packet_builders: dict[str, Callable],
        log_fn: Callable | None = None,
    ) -> list[bytes]:
        """
        Handle player initiating placement or removal of a barricade (ReqCharacterOperateBlockingBoard 0x41).
        op: 1 = Begin placing barricade animation, 2 = Begin unblocking crowbar animation.
        Only broadcasts character animation packet; world state change occurs upon completion.
        """
        _log = log_fn or (lambda msg: None)
        normalized_board_id = int(board_id or 0) & 0xFFFFFFFF
        op_val = int(op or 0)

        build_rsp_operate = packet_builders.get('build_rsp_character_operate_blocking_board')
        packets: list[bytes] = []

        if build_rsp_operate:
            packets.append(build_rsp_operate(player_bid, pose, normalized_board_id, op_val))

        if session is not None and normalized_board_id > 0:
            with session._lock:
                session.last_blocking_board_id = normalized_board_id
                if op_val == 1:
                    session.player_placed_blocking_board_ids.add(normalized_board_id)
                _log(f"[Destruction] Barricade operation STARTED board_id={normalized_board_id} op={op_val} by bid={player_bid}")

        return packets

    @staticmethod
    def handle_blocking_board_state_change(
        session: Any,
        board_id: int,
        state: int,
        player_id: int | None,
        packet_builders: dict[str, Callable],
        log_fn: Callable | None = None,
    ) -> list[bytes]:
        """
        Handle barricade state completion from client (ReqChangeBlockingBoardState 0x461).
        state: 1 = Active (Forward), 2 = Active (Backward), 0 = Deactive (Removed/Destroyed).
        """
        _log = log_fn or (lambda msg: None)
        normalized_board_id = int(board_id or 0) & 0xFFFFFFFF
        board_state = int(state or 0) & 0xFF

        build_board_state = packet_builders.get('build_rsp_event_blocking_board_state')
        build_board_destroy = packet_builders.get('build_rsp_destroy_blocking_board')

        packets: list[bytes] = []

        if session is not None and normalized_board_id > 0:
            with session._lock:
                session.last_blocking_board_id = normalized_board_id
                session.blocking_board_states[normalized_board_id] = board_state
                dyn = session.dynamic_walls.setdefault(
                    normalized_board_id,
                    {'state': board_state, 'blocks': set()},
                )
                dyn['state'] = board_state

                if board_state != BLOCKING_BOARD_STATE_DEACTIVE:
                    # Barricade newly placed or reinstalled: clean slate
                    session.blocking_board_hp[normalized_board_id] = 100.0
                    session.wall_broken_blocks.pop(normalized_board_id, None)
                    dyn['blocks'] = set()
                    if build_board_state:
                        packets.append(build_board_state(normalized_board_id, player_id, board_state))
                    _log(f"[Destruction] Barricade ACTIVATED board_id={normalized_board_id} state={board_state}")
                else:
                    # Barricade removed/deactivated
                    session.blocking_board_hp[normalized_board_id] = 0.0
                    dyn['blocks'] = set()
                    if build_board_destroy:
                        try:
                            packets.append(build_board_destroy(normalized_board_id, (0.0, 0.0, 0.0)))
                        except TypeError:
                            packets.append(build_board_destroy(normalized_board_id))
                    if build_board_state:
                        packets.append(build_board_state(normalized_board_id, player_id, BLOCKING_BOARD_STATE_DEACTIVE))
                    _log(f"[Destruction] Barricade DEACTIVATED board_id={normalized_board_id}")
        elif build_board_state:
            packets.append(build_board_state(normalized_board_id, player_id, board_state))

        return packets

    @staticmethod
    def handle_reinforced_install(
        session: Any,
        reinforced_id: int,
        pose: dict,
        player_bid: int,
        packet_builders: dict[str, Callable],
        log_fn: Callable | None = None,
    ) -> list[bytes]:
        """
        Handle defender installing a steel reinforcement wall (ReqCharacterInstallReinforced 0x59).
        """
        _log = log_fn or (lambda msg: None)
        normalized_id = int(reinforced_id or 0) & 0xFFFFFFFF

        build_rsp_install = packet_builders.get('build_rsp_character_install_reinforced')
        build_state_update = packet_builders.get('build_rsp_reinforced_state_update')

        packets: list[bytes] = []

        if build_rsp_install:
            packets.append(build_rsp_install(player_bid, pose, normalized_id))

        if build_state_update:
            packets.append(build_state_update(normalized_id, player_bid, REINFORCED_STATE_ACTIVED1))

        if session is not None and normalized_id > 0:
            with session._lock:
                session.reinforced_states[normalized_id] = REINFORCED_STATE_ACTIVED1
                session.reinforced_walls[normalized_id] = {
                    'state': REINFORCED_STATE_ACTIVED1,
                    'owner_bid': player_bid,
                }
                session.reinforced_wall_items.add(normalized_id)
                _log(f"[Destruction] ReinforcedWall INSTALLED id={normalized_id} by bid={player_bid}")

        return packets

    @staticmethod
    def snapshot_broken_walls(session: Any) -> list[dict]:
        """Generate list of broken wall records for ReqWallInfo (0x449)."""
        if session is None:
            return []
        with session._lock:
            return [
                {'id': int(wall_id) & 0xFFFFFFFF}
                for wall_id, blocks in session.wall_broken_blocks.items()
                if blocks and int(wall_id) > 0
            ]

    @staticmethod
    def snapshot_dynamic_walls(session: Any) -> list[dict]:
        """
        Generate list of dynamic wall blocks for ReqDynamicWallInfo (0x44B).
        
        CRITICAL: In Area F2 client (Wall.RecoverWall), the `blocks` list in DynamicWall contains
        the INTACT / REMAINING blocks! Any block index NOT in `blocks` is destroyed by the client.
        """
        if session is None:
            return []
        with session._lock:
            result: list[dict] = []
            all_ids = (
                set(getattr(session, 'dynamic_walls', {}).keys())
                | set(getattr(session, 'blocking_board_states', {}).keys())
                | set(getattr(session, 'wall_dynamic_walls', {}).keys())
            )
            for board_id in sorted(all_ids):
                b_id = int(board_id) & 0xFFFFFFFF
                if b_id <= 0:
                    continue
                dyn = session.dynamic_walls.get(b_id) or session.wall_dynamic_walls.get(b_id, {})
                state = int(dyn.get('state', session.blocking_board_states.get(b_id, BLOCKING_BOARD_STATE_DEACTIVE))) & 0xFF
                broken_blocks = dyn.get('blocks', set()) if isinstance(dyn, dict) else set()
                total_blocks = 42 # standard door grid count
                if state == BLOCKING_BOARD_STATE_DEACTIVE:
                    intact_blocks = []
                elif broken_blocks:
                    intact_blocks = [i for i in range(total_blocks) if i not in broken_blocks]
                else:
                    intact_blocks = list(range(total_blocks))
                result.append({
                    'id': b_id,
                    'state': state,
                    'blocks': intact_blocks,
                })
            return result

    @staticmethod
    def snapshot_reinforced_walls(session: Any) -> list[dict]:
        """Generate list of active reinforced walls for ReqReinforcedWallInfo (0x48B)."""
        if session is None:
            return []
        with session._lock:
            result: list[dict] = []
            for r_id, r_state in session.reinforced_states.items():
                normalized_id = int(r_id) & 0xFFFFFFFF
                if normalized_id <= 0 or r_state == REINFORCED_STATE_INIT:
                    continue
                result.append({
                    'id': normalized_id,
                    'state': int(r_state),
                })
            return result
