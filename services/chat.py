import os
import sys
import json
import time
import socket
import select
import struct
import hashlib
import threading
from typing import Any

import services.session_manager as session_manager
from services.session_manager import (
    _CHAT_LOCK,
    _CHAT_PLAYER_STATE,
    _CHAT_PENDING_PUSHES,
    _CHAT_NEXT_MSG_ID,
    _CHAT_MAX_MESSAGES_PER_SESSION,
    _CHAT_MAX_PENDING_PUSHES_PER_PLAYER,
    _CHAT_BOOTSTRAP_LOCK,
    _CHAT_BOOTSTRAP_STATE,
)
import services.db as db
import services.utils as utils

# ─────────────────────────────────────────────────────────────────────────────
# RC4 Stream Cipher for EjoySDK Chat TCP protocol
# ─────────────────────────────────────────────────────────────────────────────

class _RC4Stream:
    """Stateful RC4 stream cipher matching _ejoysdk_crypt."""
    def __init__(self, key: bytes):
        if not key:
            key = b"default_key"
        self.s = list(range(256))
        j = 0
        klen = len(key)
        for i in range(256):
            j = (j + self.s[i] + key[i % klen]) & 0xFF
            self.s[i], self.s[j] = self.s[j], self.s[i]
        self.i = 0
        self.j = 0

    def crypt(self, data: bytes) -> bytes:
        if not data:
            return b""
        out = bytearray(len(data))
        s = self.s
        i = self.i
        j = self.j
        for idx, b in enumerate(data):
            i = (i + 1) & 0xFF
            j = (j + s[i]) & 0xFF
            s[i], s[j] = s[j], s[i]
            k = s[(s[i] + s[j]) & 0xFF]
            out[idx] = b ^ k
        self.i = i
        self.j = j
        return bytes(out)


# ─────────────────────────────────────────────────────────────────────────────
# Header & Packet Protocol Utilities
# ─────────────────────────────────────────────────────────────────────────────

_KTT: dict[int, str] = {
    1: "codec",
    2: "method",
    3: "session",
    4: "code",
    5: "error",
    6: "timestamp",
    7: "trace",
    8: "destination",
    9: "source",
}
_KTT_REV: dict[str, int] = {v: k for k, v in _KTT.items()}

_VTT: dict[int, str] = {
    1: "json",
    2: "sproto",
    3: "protobuf",
    4: "raw",
    5: "0",
}
_VTT_REV: dict[str, int] = {v: k for k, v in _VTT.items()}


def _chat_encode_key(k: str) -> bytes:
    k_str = str(k)
    kt = _KTT_REV.get(k_str)
    if kt is not None:
        return bytes([0x80 | kt])
    k_bytes = k_str.encode("utf-8")
    assert len(k_bytes) < 0x7F, f"key length larger than 127: {k_str}"
    return bytes([len(k_bytes)]) + k_bytes


def _chat_encode_value(v: object) -> bytes:
    v_str = str(v)
    vt = _VTT_REV.get(v_str)
    if vt is not None:
        return bytes([0x80 | vt])
    v_bytes = v_str.encode("utf-8")
    lenv = len(v_bytes)
    if lenv < 0x40:
        return bytes([lenv]) + v_bytes
    elif lenv < 0x4000:
        return bytes([0x40 | (lenv >> 8), lenv & 0xFF]) + v_bytes
    else:
        raise ValueError(f"Not supported string length: {lenv}")


def _chat_encode_header(header: dict[str, object]) -> bytes:
    packlist: list[bytes] = []
    for k, v in header.items():
        if v is None:
            continue
        packlist.append(_chat_encode_key(k))
        packlist.append(_chat_encode_value(v))
    return b"".join(packlist)


def _chat_decode_header(chunk: bytes) -> dict[str, str]:
    header: dict[str, str] = {}
    if not chunk:
        return header
    pos = 0
    total = len(chunk)
    while pos < total:
        byte = chunk[pos]
        if (byte & 0x80) == 0:
            lenk = byte
            pos += 1
            if pos + lenk > total:
                break
            key = chunk[pos : pos + lenk].decode("utf-8", errors="replace")
            pos += lenk
        else:
            kt = byte & 0x7F
            key = _KTT.get(kt, f"key_{kt}")
            pos += 1

        if pos >= total:
            break

        byte = chunk[pos]
        if (byte & 0xC0) == 0:
            lenv = byte
            pos += 1
            if pos + lenv > total:
                break
            value = chunk[pos : pos + lenv].decode("utf-8", errors="replace")
            pos += lenv
        elif (byte & 0xC0) == 0x40:
            if pos + 1 >= total:
                break
            b0 = byte
            b1 = chunk[pos + 1]
            lenv = ((b0 & 0x3F) << 8) | b1
            pos += 2
            if pos + lenv > total:
                break
            value = chunk[pos : pos + lenv].decode("utf-8", errors="replace")
            pos += lenv
        elif (byte & 0x80) == 0x80:
            vt = byte & 0x7F
            value = _VTT.get(vt, f"val_{vt}")
            pos += 1
        else:
            break

        header[key] = value
    return header


def _chat_parse_login_prefix(frame_payload: bytes) -> tuple[int, int, str, bytes] | None:
    # Login packet format:
    #   server_version: uint8 (1 byte)
    #   expire_time:    uint32 (4 bytes, big endian)
    #   player_id_len:  uint8 (1 byte)
    #   player_id:      string (player_id_len bytes)
    #   encrypted_body: remainder
    if len(frame_payload) < 6:
        return None
    version = frame_payload[0]
    expire_time = int.from_bytes(frame_payload[1:5], "big")
    pid_len = frame_payload[5]
    if len(frame_payload) < 6 + pid_len:
        return None
    pid_bytes = frame_payload[6:6 + pid_len]
    player_id = pid_bytes.decode("utf-8", errors="replace")
    encrypted_body = frame_payload[6 + pid_len:]
    return version, expire_time, player_id, encrypted_body


def _chat_clone_json(value: object) -> object:
    try:
        return json.loads(json.dumps(value, ensure_ascii=False))
    except Exception:
        return value


def _chat_as_list(value: object) -> list[object]:
    if isinstance(value, list):
        return value
    if isinstance(value, tuple):
        return list(value)
    if value is None:
        return []
    return [value]


# ─────────────────────────────────────────────────────────────────────────────
# Active Connections & Dynamic Online Status
# ─────────────────────────────────────────────────────────────────────────────

_CHAT_ACTIVE_PLAYERS: dict[str, float] = {}
_PLAYER_LAST_BROADCASTED_STATE: dict[str, int] = {}


def record_player_activity(player_id: object) -> None:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return
    was_online = is_player_online(pid_s)
    with _CHAT_LOCK:
        _CHAT_ACTIVE_PLAYERS[pid_s] = time.time()
    if not was_online:
        new_state = get_player_state(pid_s)
        _broadcast_player_status_change(pid_s, new_state)


def remove_player_activity(player_id: object) -> None:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return
    with _CHAT_LOCK:
        _CHAT_ACTIVE_PLAYERS.pop(pid_s, None)
    # Trigger status change broadcast immediately
    _broadcast_player_status_change(pid_s, 0)


def is_player_online(player_id: object) -> bool:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return False
    with _CHAT_LOCK:
        last_ts = _CHAT_ACTIVE_PLAYERS.get(pid_s)
        if last_ts is not None and (time.time() - last_ts < 120.0):
            return True
    return False


def get_player_state(player_id: object) -> int:
    pid_s = utils._uid_str(player_id, "")
    if not is_player_online(pid_s):
        return 0  # Offline
    # Check if in room via room_state
    try:
        from run_https_443 import _room_state as r_state
        if isinstance(r_state, dict) and isinstance(r_state.get("players"), dict):
            if pid_s in r_state["players"]:
                return 4  # InRoom
    except Exception:
        pass
    with _CHAT_LOCK:
        pstate = _CHAT_PLAYER_STATE.get(pid_s)
        if pstate and isinstance(pstate.get("groups"), list):
            for g in pstate["groups"]:
                if isinstance(g, dict) and g.get("info", {}).get("type") in ("room", "team"):
                    return 4  # InRoom
    return 2  # InHall (Online)


def push_friend_info_change(target_uid: object, changed_uid: object) -> None:
    target_s = utils._uid_str(target_uid, "")
    changed_s = utils._uid_str(changed_uid, "")
    if not target_s or not changed_s:
        return
    profile_payload = get_player_profile_payload(changed_s)
    enqueue_push(
        target_s,
        "push-friend-info-change",
        {"user_list": [profile_payload]},
        method="friend/player/v1.0/friend_info_change",
    )
    utils._append_utf8_log(f"[PUSH:FRIEND] friend_info_change to {target_s} for {changed_s} state={profile_payload.get('state')}")


def _broadcast_player_status_change(player_id: object, new_state: int) -> None:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return
    _PLAYER_LAST_BROADCASTED_STATE[pid_s] = new_state
    try:
        import database
        friends = database.get_friends(int(pid_s))
        for f_uid in friends:
            f_s = str(f_uid)
            if is_player_online(f_s):
                push_friend_info_change(f_s, pid_s)
    except Exception as exc:
        utils._append_utf8_log(f"[PUSH:FRIEND] status broadcast error for {pid_s}: {exc}")


def _check_and_broadcast_all_status_changes() -> None:
    try:
        import database
        all_profiles = database.get_all_profiles()
        for uid_int in all_profiles.keys():
            uid_s = str(uid_int)
            cur_state = get_player_state(uid_s)
            old_state = _PLAYER_LAST_BROADCASTED_STATE.get(uid_s, -1)
            if cur_state != old_state:
                _broadcast_player_status_change(uid_s, cur_state)
    except Exception as exc:
        utils._append_utf8_log(f"[STATUS_CHECKER] check loop error: {exc}")


def _status_checker_daemon_loop() -> None:
    while True:
        try:
            time.sleep(5.0)
            _check_and_broadcast_all_status_changes()
        except Exception:
            pass


_STATUS_THREAD = threading.Thread(target=_status_checker_daemon_loop, daemon=True, name="FriendStatusChecker")
_STATUS_THREAD.start()


# ─────────────────────────────────────────────────────────────────────────────
# Profile & Player State Helpers (Single Source of Truth)
# ─────────────────────────────────────────────────────────────────────────────

def get_player_profile_payload(uid: object, *, local_pd: object = None) -> dict[str, object]:
    """
    Builds the authoritative full player profile for chat and social endpoints.
    Contains both top-level fields and nested 'player_info' required by client Lua.
    """
    profile = db._online_ensure_profile(uid, local_pd=local_pd)
    uid_s = utils._uid_str(profile.get("uid"), "1000001")
    name = str(profile.get("name") or f"Player{uid_s[-4:] or '0001'}")
    level = max(1, utils._safe_int(profile.get("level"), 1))
    icon = max(0, utils._safe_int(profile.get("icon"), 0))
    icon_url = str(profile.get("icon_url") or "")
    rank_score = max(0, utils._safe_int(profile.get("rank_score"), 0))
    fbname = str(profile.get("fbname") or name)
    now_ts = int(time.time())
    cur_state = get_player_state(uid_s)
    is_online = (cur_state != 0)

    player_info = {
        "player_id": uid_s,
        "playerId": uid_s,
        "user_id": uid_s,
        "id": uid_s,
        "uid": uid_s,
        "name": name,
        "fbname": fbname,
        "level": level,
        "icon": icon,
        "icon_url": icon_url,
        "rank_score": rank_score,
        "state": cur_state,
    }
    return {
        "player_id": uid_s,
        "playerId": uid_s,
        "user_id": uid_s,
        "id": uid_s,
        "uid": uid_s,
        "account": f"local-{uid_s}",
        "account_id": uid_s,
        "name": name,
        "fbname": fbname,
        "level": level,
        "icon": icon,
        "icon_url": icon_url,
        "rank_score": rank_score,
        "state": cur_state,
        "is_online": is_online,
        "is_in_battle": cur_state in (6, 7),
        "is_allow_watch": True,
        "rank_level": rank_score // 100,
        "update_time": max(1, utils._safe_int(profile.get("update_time"), now_ts)),
        "player_info": player_info,
    }


def _chat_normalize_group_id(group_id: object, *, fallback: str = "group_world") -> str:
    gid = utils._uid_str(group_id, "").strip()
    if not gid:
        return fallback
    if gid in {"world", "group_world", "0"}:
        return "group_world"
    if gid.startswith("group_"):
        return gid
    return f"group_{gid}"


def _chat_normalize_session_id(session_id: object, caller_uid: object) -> str:
    sid = utils._uid_str(session_id, "").strip()
    caller = utils._uid_str(caller_uid, "1000001")
    if not sid or sid in {"world", "group_world", "0"}:
        return "group_world"
    if sid.startswith("group_"):
        return sid
    if ":" in sid:
        parts = [p.strip() for p in sid.split(":") if p.strip()]
        if len(parts) == 2:
            return f"{parts[0]}:{parts[1]}"
    # If a numeric UID was passed as friend channel:
    if sid.isdigit():
        p1 = int(caller) if caller.isdigit() else 1000001
        p2 = int(sid)
        if p1 <= p2:
            return f"{p1}:{p2}"
        return f"{p2}:{p1}"
    return sid


def _chat_session_participants(session_id: str) -> list[str]:
    if ":" in session_id:
        parts = [p.strip() for p in session_id.split(":") if p.strip()]
        if len(parts) == 2:
            return parts
    return [session_id]


def _chat_ignore_data_from_state(state: dict[str, object]) -> dict[str, list[str]]:
    ign_sess = state.get("ignore_sessions")
    ign_grp = state.get("ignore_group_types")
    return {
        "sessions": sorted(list(ign_sess)) if isinstance(ign_sess, set) else [],
        "group_types": sorted(list(ign_grp)) if isinstance(ign_grp, set) else [],
    }


def _ensure_player_state(uid: object) -> dict[str, object]:
    uid_s = utils._uid_str(uid, "1000001")
    with _CHAT_LOCK:
        state_obj = _CHAT_PLAYER_STATE.get(uid_s)
        if not isinstance(state_obj, dict):
            state_obj = {
                "sessions": {},
                "groups": [],
                "ignore_sessions": set(),
                "ignore_group_types": set(),
                "send_window_ts": [],
            }
            _CHAT_PLAYER_STATE[uid_s] = state_obj

        sessions_obj = state_obj.get("sessions")
        if not isinstance(sessions_obj, dict):
            sessions_obj = {}
            state_obj["sessions"] = sessions_obj
        if "group_world" not in sessions_obj:
            sessions_obj["group_world"] = []

        groups_obj = state_obj.get("groups")
        if not isinstance(groups_obj, list):
            groups_obj = []
            state_obj["groups"] = groups_obj

        # Always guarantee group_world is present in groups list
        has_world = any(isinstance(g, dict) and g.get("group_id") == "group_world" for g in groups_obj)
        if not has_world:
            groups_obj.insert(0, {
                "group_id": "group_world",
                "info": {"name": "World", "type": "world"},
                "attr": {"enable_voice": False},
                "member_infos": [],
                "invited_member_infos": [],
                "personal_info": {"agora_channel_token": ""},
            })

        return state_obj


def _chat_build_group_payload(
    group_id: str,
    *,
    group_type: str = "group",
    name: str = "Group",
    member_uids: list[str] | None = None,
) -> dict[str, object]:
    members = member_uids or []
    member_infos = [get_player_profile_payload(m) for m in members]
    return {
        "group_id": group_id,
        "info": {
            "name": name,
            "type": group_type,
        },
        "attr": {
            "enable_voice": True if group_type in {"room", "team"} else False,
        },
        "member_infos": member_infos,
        "invited_member_infos": [],
        "personal_info": {
            "agora_channel_token": f"token_{group_id}",
        },
    }


def enqueue_push(
    player_id: object,
    push_tag: str,
    push_msg: dict[str, object],
    *,
    method: str | None = None,
) -> None:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return
    with _CHAT_LOCK:
        bucket = _CHAT_PENDING_PUSHES.get(pid_s)
        if not isinstance(bucket, list):
            bucket = []
            _CHAT_PENDING_PUSHES[pid_s] = bucket
        bucket.append((push_tag, _chat_clone_json(push_msg), method))
        if len(bucket) > _CHAT_MAX_PENDING_PUSHES_PER_PLAYER:
            del bucket[:- _CHAT_MAX_PENDING_PUSHES_PER_PLAYER]


def take_pending_pushes(player_id: object, *, max_items: int = 64) -> list[tuple[str, dict[str, object], str | None]]:
    pid_s = utils._uid_str(player_id, "")
    if not pid_s:
        return []
    with _CHAT_LOCK:
        bucket = _CHAT_PENDING_PUSHES.get(pid_s)
        if not isinstance(bucket, list) or not bucket:
            return []
        raw_items = bucket[:max_items]
        del bucket[:len(raw_items)]
        items = []
        for it in raw_items:
            tag = it[0]
            msg = it[1]
            method = it[2] if len(it) > 2 else None
            items.append((tag, msg, method))
        return items


def push_friend_apply(target_uid: object, applicant_uid: object) -> None:
    target_s = utils._uid_str(target_uid, "")
    appl_s = utils._uid_str(applicant_uid, "")
    if not target_s or not appl_s:
        return
    enqueue_push(
        target_s,
        "push-friend-apply",
        {"friend_apply_list": [{"user_id": appl_s, "player_id": appl_s}]},
        method="friend/player/v1.0/friend_apply",
    )
    utils._append_utf8_log(f"[PUSH:FRIEND] friend_apply push to {target_s} from {appl_s}")


def push_friend_add(uid_a: object, uid_b: object) -> None:
    a_s = utils._uid_str(uid_a, "")
    b_s = utils._uid_str(uid_b, "")
    if not a_s or not b_s:
        return
    enqueue_push(
        a_s,
        "push-friend-add",
        {"user_list": [{"user_id": b_s, "player_id": b_s}]},
        method="friend/player/v1.0/friend_add",
    )
    enqueue_push(
        b_s,
        "push-friend-add",
        {"user_list": [{"user_id": a_s, "player_id": a_s}]},
        method="friend/player/v1.0/friend_add",
    )
    utils._append_utf8_log(f"[PUSH:FRIEND] friend_add push between {a_s} and {b_s}")


def push_friend_del(uid_a: object, uid_b: object) -> None:
    a_s = utils._uid_str(uid_a, "")
    b_s = utils._uid_str(uid_b, "")
    if not a_s or not b_s:
        return
    enqueue_push(
        a_s,
        "push-friend-del",
        {"user_list": [b_s]},
        method="friend/player/v1.0/friend_del",
    )
    enqueue_push(
        b_s,
        "push-friend-del",
        {"user_list": [a_s]},
        method="friend/player/v1.0/friend_del",
    )
    utils._append_utf8_log(f"[PUSH:FRIEND] friend_del push between {a_s} and {b_s}")


def join_room_chat_group(player_id: object, room_id: object, room_type: str = "room") -> str:
    """
    Registers a player into a room / team chat group and dispatches info_create_group push.
    """
    pid_s = utils._uid_str(player_id, "")
    rid_s = utils._uid_str(room_id, "")
    if not pid_s or not rid_s:
        return ""
    group_id = f"group_room_{rid_s}" if not rid_s.startswith("group_") else rid_s
    gtype = "room" if "room" in room_type.lower() else "team"
    gname = "Room" if gtype == "room" else "Team"

    with _CHAT_LOCK:
        pstate = _ensure_player_state(pid_s)
        groups = pstate.get("groups", [])
        existing = next((g for g in groups if isinstance(g, dict) and g.get("group_id") == group_id), None)
        if existing is None:
            group_payload = _chat_build_group_payload(group_id, group_type=gtype, name=gname, member_uids=[pid_s])
            groups.append(group_payload)
            enqueue_push(pid_s, "push-info-create-group", {
                "cmd": "info_create_group",
                "group": group_payload,
            })
            utils._append_utf8_log(f"[CHAT] Player {pid_s} joined room group {group_id}")
    return group_id


def leave_room_chat_group(player_id: object, room_id: object) -> None:
    pid_s = utils._uid_str(player_id, "")
    rid_s = utils._uid_str(room_id, "")
    if not pid_s or not rid_s:
        return
    group_id = f"group_room_{rid_s}" if not rid_s.startswith("group_") else rid_s
    with _CHAT_LOCK:
        pstate = _ensure_player_state(pid_s)
        groups = pstate.get("groups", [])
        pstate["groups"] = [g for g in groups if isinstance(g, dict) and g.get("group_id") != group_id]
        enqueue_push(pid_s, "push-info-delete-group", {
            "cmd": "info_delete_group",
            "group_id": group_id,
            "reason": "leave_room",
        })
        utils._append_utf8_log(f"[CHAT] Player {pid_s} left room group {group_id}")


def broadcast_admin_chat_message(
    content_str: str,
    sender_name: str = "SERVER",
    sender_uid: int = 0,
    session_id: str = "group_world",
) -> bool:
    """Broadcast a chat message from web admin panel to connected game clients."""
    global _CHAT_NEXT_MSG_ID
    now_ts = int(time.time())
    with _CHAT_LOCK:
        msg_id = _CHAT_NEXT_MSG_ID
        _CHAT_NEXT_MSG_ID += 1

        src_info = {
            "uid": int(sender_uid),
            "name": str(sender_name),
            "icon": 0,
            "icon_frame": 0,
            "level": 1,
            "vip_level": 0,
        }
        if sender_uid > 0:
            src_info = get_player_profile_payload(str(sender_uid))
            if sender_name:
                src_info["name"] = sender_name

        content = {"type": "text", "data": str(content_str)}
        msg_obj = {
            "session_id": session_id,
            "msg_id": msg_id,
            "send_id": f"admin-{msg_id}",
            "ts": now_ts,
            "src_type": "user",
            "src_info": src_info,
            "content": content,
        }

        recipient_ids = set(_CHAT_PLAYER_STATE.keys())
        for rid in recipient_ids:
            r_state = _ensure_player_state(rid)
            bucket = r_state["sessions"].setdefault(session_id, [])
            bucket.append(_chat_clone_json(msg_obj))
            if len(bucket) > _CHAT_MAX_MESSAGES_PER_SESSION:
                del bucket[:- _CHAT_MAX_MESSAGES_PER_SESSION]

        push_payload = {
            "cmd": "info_msg",
            "msgs": [_chat_clone_json(msg_obj)],
        }
        for rid in recipient_ids:
            enqueue_push(rid, "push-info-msg", push_payload)

        utils._append_utf8_log(
            f"[CHAT] Admin broadcast session={session_id} sender={sender_name} (UID {sender_uid}) text={content_str!r}"
        )
        return True


# ─────────────────────────────────────────────────────────────────────────────
# Command Dispatcher
# ─────────────────────────────────────────────────────────────────────────────

def handle_chat_command(
    req_msg: dict[str, object],
    player_id: str,
) -> tuple[str, dict[str, object], list[tuple[str, dict[str, object]]]]:
    global _CHAT_NEXT_MSG_ID
    cmd = str(req_msg.get("cmd") or "").strip().lower()
    now_ts = int(time.time())

    with _CHAT_LOCK:
        pstate = _ensure_player_state(player_id)
        sessions: dict[str, list[dict[str, object]]] = pstate["sessions"]
        groups: list[dict[str, object]] = pstate["groups"]
        ignore_sessions: set[str] = pstate["ignore_sessions"]
        ignore_group_types: set[str] = pstate["ignore_group_types"]

        # ── LOGIN ──
        if cmd == "login":
            token = str(req_msg.get("token") or "").strip()
            utils._append_utf8_log(f"[CHAT] login player_id={player_id} token={token[:16]}...")
            record_player_activity(player_id)
            _broadcast_player_status_change(player_id, 2)
            return cmd, {
                "code": 0,
                "token": token,
                "timestamp": now_ts,
                "groups": _chat_clone_json(groups),
                "ignore_data": _chat_ignore_data_from_state(pstate),
            }, []

        # ── PING / HEARTBEAT ──
        if cmd in {"ping", "heart_beat"}:
            record_player_activity(player_id)
            return cmd, {"code": 0, "timestamp": now_ts}, []

        # ── SEND MESSAGE (Global, Room, Friend, Recruit) ──
        if cmd == "send":
            record_player_activity(player_id)
            session_id = _chat_normalize_session_id(req_msg.get("session_id"), player_id)
            send_id = str(req_msg.get("send_id") or "")

            # Rate limiting
            send_window = pstate.get("send_window_ts", [])
            send_window = [ts for ts in send_window if now_ts - ts <= 3]
            if len(send_window) >= 15:
                pstate["send_window_ts"] = send_window
                return cmd, {"code": 429, "message": "chat rate limit"}, []
            send_window.append(now_ts)
            pstate["send_window_ts"] = send_window

            # Parse content
            content = req_msg.get("content")
            if not isinstance(content, dict):
                content = {"type": "text", "data": str(content or "")}

            content_type = str(content.get("type") or "text").strip() or "text"
            content["type"] = content_type

            if content_type == "client_custom":
                custom_data = content.get("data")
                if not isinstance(custom_data, dict):
                    custom_data = {}
                content["data"] = custom_data
            else:
                text_data = str(content.get("data") or "")
                if len(text_data) > 1024:
                    text_data = text_data[:1024]
                content["data"] = text_data

            msg_id = _CHAT_NEXT_MSG_ID
            _CHAT_NEXT_MSG_ID += 1

            sender_profile = get_player_profile_payload(player_id)

            msg_obj = {
                "session_id": session_id,
                "msg_id": msg_id,
                "send_id": send_id,
                "ts": now_ts,
                "src_type": "user",
                "src_info": sender_profile,
                "content": content,
            }

            try:
                import services.admin_panel as admin_panel
                admin_panel.record_chat_message(
                    session_id,
                    int(player_id) if str(player_id).isdigit() else 0,
                    str(sender_profile.get("name", f"Player{player_id}")),
                    str(content.get("data", ""))
                )
            except Exception:
                pass

            # Determine recipients
            recipient_ids: set[str] = {player_id}
            if session_id.startswith("group"):
                session_id = _chat_normalize_group_id(session_id, fallback="group_world")
                msg_obj["session_id"] = session_id
                if session_id == "group_world":
                    recipient_ids.update(list(_CHAT_PLAYER_STATE.keys()))
                else:
                    # Find all players that have this group registered
                    for uid_k, st_v in _CHAT_PLAYER_STATE.items():
                        if isinstance(st_v, dict):
                            grps = st_v.get("groups", [])
                            if any(isinstance(g, dict) and g.get("group_id") == session_id for g in grps):
                                recipient_ids.add(uid_k)
            else:
                # Private 1-on-1 friend chat
                for uid_part in _chat_session_participants(session_id):
                    recipient_ids.add(uid_part)

            # Store in session buckets
            for rid in recipient_ids:
                r_state = _ensure_player_state(rid)
                r_sessions = r_state["sessions"]
                bucket = r_sessions.setdefault(session_id, [])
                bucket.append(_chat_clone_json(msg_obj))
                if len(bucket) > _CHAT_MAX_MESSAGES_PER_SESSION:
                    del bucket[:- _CHAT_MAX_MESSAGES_PER_SESSION]

            # Broadcast push
            push_payload = {
                "cmd": "info_msg",
                "msgs": [_chat_clone_json(msg_obj)],
            }
            immediate_pushes = [("push-info-msg", _chat_clone_json(push_payload))]
            for rid in recipient_ids:
                if rid != player_id:
                    enqueue_push(rid, "push-info-msg", push_payload)

            utils._append_utf8_log(
                f"[CHAT] send session={session_id} type={content_type} sender={player_id} recipients={len(recipient_ids)}"
            )

            return cmd, {
                "code": 0,
                "session_id": session_id,
                "msg_id": msg_id,
                "send_id": send_id,
                "msgs": [_chat_clone_json(msg_obj)],
            }, immediate_pushes

        # ── GET SESSION MSG ──
        if cmd == "get_session_msg":
            session_id = _chat_normalize_session_id(req_msg.get("session_id"), player_id)
            raw_msgs = sessions.get(session_id, [])
            try:
                max_count = max(1, int(req_msg.get("max_msg_count") or 50))
            except Exception:
                max_count = 50
            msgs = raw_msgs[-max_count:]
            return cmd, {
                "code": 0,
                "session_id": session_id,
                "msgs": _chat_clone_json(msgs),
            }, []

        # ── GET LATEST SESSION ──
        if cmd == "get_latest_session":
            sessions_resp: list[dict[str, object]] = []
            for sid, raw_msgs in sessions.items():
                if not isinstance(raw_msgs, list):
                    continue
                last_msgs = [_chat_clone_json(raw_msgs[-1])] if raw_msgs else []
                sid_s = str(sid)
                info_obj: dict[str, object] = {}
                if sid_s.startswith("group"):
                    if sid_s == "group_world":
                        gtype, gname = "world", "World"
                    elif sid_s.startswith("group_room_"):
                        gtype, gname = "room", "Room"
                    else:
                        gtype, gname = "group", "Group"
                    info_obj = {
                        "group_id": sid_s,
                        "info": {"name": gname, "type": gtype},
                        "member_infos": [],
                        "invited_member_infos": [],
                        "personal_info": {"agora_channel_token": ""},
                    }
                sessions_resp.append({
                    "session_info": {
                        "id": sid_s,
                        "unread": 0,
                        "info": info_obj,
                    },
                    "last_msgs": last_msgs,
                })

            def _latest_ts(entry: dict[str, object]) -> int:
                l_msgs = entry.get("last_msgs")
                if isinstance(l_msgs, list) and l_msgs and isinstance(l_msgs[0], dict):
                    return int(l_msgs[0].get("ts") or 0)
                return 0

            sessions_resp.sort(key=_latest_ts, reverse=True)
            return cmd, {"code": 0, "sessions": sessions_resp}, []

        # ── CREATE / UPDATE / DELETE / EXIT GROUP ──
        if cmd in {"create_group", "update_group", "delete_group", "exit_group"}:
            group_id = _chat_normalize_group_id(req_msg.get("group_id"), fallback=f"group_{int(time.time() * 1000)}")
            info = req_msg.get("info") if isinstance(req_msg.get("info"), dict) else {}
            group_type = str(info.get("type") or ("room" if group_id.startswith("group_room_") else "group")).lower()
            group_name = str(info.get("name") or ("Room" if group_type == "room" else "Group"))

            member_ids: set[str] = {player_id}
            for raw_uid in _chat_as_list(req_msg.get("members")):
                uid_s = utils._uid_str(raw_uid, "")
                if uid_s:
                    member_ids.add(uid_s)

            if cmd == "exit_group":
                leave_room_chat_group(player_id, group_id)
                return cmd, {"code": 0, "group_id": group_id}, []

            if cmd == "delete_group":
                for uid_k in list(_CHAT_PLAYER_STATE.keys()):
                    leave_room_chat_group(uid_k, group_id)
                return cmd, {"code": 0, "group_id": group_id}, []

            group_payload = _chat_build_group_payload(
                group_id,
                group_type=group_type,
                name=group_name,
                member_uids=list(member_ids),
            )

            for uid_m in member_ids:
                m_state = _ensure_player_state(uid_m)
                m_groups = m_state["groups"]
                m_state["groups"] = [g for g in m_groups if isinstance(g, dict) and g.get("group_id") != group_id]
                m_state["groups"].append(_chat_clone_json(group_payload))
                if cmd == "create_group":
                    enqueue_push(uid_m, "push-info-create-group", {
                        "cmd": "info_create_group",
                        "group": group_payload,
                    })

            if cmd == "update_group":
                update_push = {"cmd": "info_update_group", "group": _chat_clone_json(group_payload)}
                for uid_m in member_ids:
                    if uid_m != player_id:
                        enqueue_push(uid_m, "push-info-update-group", update_push)
                return cmd, {"code": 0, "group_id": group_id}, [("push-info-update-group", _chat_clone_json(update_push))]

            return cmd, {"code": 0, "group_id": group_id}, []

        # ── IGNORE / UNIGNORE ──
        if cmd == "ignore":
            payload = req_msg.get("data") if isinstance(req_msg.get("data"), dict) else {}
            for sid in _chat_as_list(payload.get("sessions")):
                if sid: ignore_sessions.add(str(sid))
            for gtp in _chat_as_list(payload.get("group_types")):
                if gtp: ignore_group_types.add(str(gtp))
            return cmd, {"code": 0, "ignore_data": _chat_ignore_data_from_state(pstate)}, []

        if cmd == "unignore":
            payload = req_msg.get("data") if isinstance(req_msg.get("data"), dict) else {}
            for sid in _chat_as_list(payload.get("sessions")):
                if sid: ignore_sessions.discard(str(sid))
            for gtp in _chat_as_list(payload.get("group_types")):
                if gtp: ignore_group_types.discard(str(gtp))
            return cmd, {"code": 0, "ignore_data": _chat_ignore_data_from_state(pstate)}, []

        # ── GET PLAYER INFO ──
        if cmd == "get_player_info":
            target_pid = utils._uid_str(req_msg.get("player_id"), player_id)
            return cmd, {"code": 0, "player": get_player_profile_payload(target_pid)}, []

        if cmd == "get_player_infos":
            pids = [str(v) for v in _chat_as_list(req_msg.get("player_ids")) if v is not None]
            players = [get_player_profile_payload(pid) for pid in pids]
            return cmd, {"code": 0, "players": players}, []

        if cmd in {"set_msg_received", "set_msg_readed", "reply_add_group_member", "add_group_member", "remove_group_member"}:
            gid = str(req_msg.get("group_id") or "").strip()
            return cmd, ({"code": 0, "group_id": gid} if gid else {"code": 0}), []

        if cmd == "get_group_be_invited_history":
            return cmd, {"code": 0, "be_invited_history": []}, []

        if cmd == "get_agora_channel_token":
            return cmd, {"code": 0, "token": "local-agora-token"}, []

        return cmd, {"code": 0, "message": "ok"}, []


# ─────────────────────────────────────────────────────────────────────────────
# TCP Socket Protocol & Connection Handler
# ─────────────────────────────────────────────────────────────────────────────

def _chat_send_packet(
    sock: socket.socket,
    rc4_s2c: _RC4Stream,
    session: str,
    trace: str,
    response: dict[str, object],
    tag: str,
    *,
    method: str | None = None,
) -> bool:
    header: dict[str, object] = {
        "codec": "json",
        "session": str(session or "0"),
        "destination": "chat",
        "source": "chat",
        "timestamp": int(time.time()),
    }
    if trace:
        header["trace"] = trace
    if method:
        header["method"] = str(method)

    try:
        header_chunk = _chat_encode_header(header)
        body_chunk = json.dumps(response, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
        plaintext = len(header_chunk).to_bytes(2, "big") + header_chunk + body_chunk
        encrypted = rc4_s2c.crypt(plaintext)
        frame = len(encrypted).to_bytes(4, "big") + encrypted
        sock.sendall(frame)
        utils._append_utf8_log(f"[TCP][chat] sent tag={tag} method={method} session={session} len={len(frame)}")
        return True
    except Exception as exc:
        utils._append_utf8_log(f"[TCP][chat] send failed tag={tag}: {exc}")
        return False


def get_player_rc4_key(player_id: object) -> bytes:
    pid = utils._uid_str(player_id, "1000001")
    salt = (os.environ.get("HOLO_TOKEN_SALT") or "local-holo").strip() or "local-holo"
    with session_manager._HOLO_LOCK:
        cached = session_manager._HOLO_PLAYER_TOKENS.get(pid)
        if cached and cached.get("key"):
            return str(cached["key"]).encode("utf-8")
    key_str = hashlib.md5(f"{pid}:{salt}:key".encode("utf-8")).hexdigest()[:16]
    return key_str.encode("utf-8")


def handle_chat_connection(sock: socket.socket, client_address: Any, listen_port: int) -> None:
    """
    Main entry point for handling incoming connections on CHAT_PORT (12345).
    """
    peer = f"{client_address[0]}:{client_address[1]}" if isinstance(client_address, (list, tuple)) else str(client_address)
    utils._append_utf8_log(f"[TCP][chat] connection from {peer} on port {listen_port}")

    rc4_c2s: _RC4Stream | None = None
    rc4_s2c: _RC4Stream | None = None

    ctx: dict[str, Any] = {
        "player_id": "1000001",
        "login_done": False,
        "recv_buf": b"",
    }

    def _ensure_rc4_stream() -> tuple[_RC4Stream, _RC4Stream]:
        nonlocal rc4_c2s, rc4_s2c
        if rc4_c2s is None or rc4_s2c is None:
            rc4_key = get_player_rc4_key(ctx["player_id"])
            rc4_c2s = _RC4Stream(rc4_key)
            rc4_s2c = _RC4Stream(rc4_key)
        return rc4_c2s, rc4_s2c

    try:
        sock.settimeout(0.2)
    except Exception:
        pass

    end_at = time.time() + 600.0

    def _flush_pushes() -> bool:
        if not ctx["login_done"]:
            return True
        _, s2c = _ensure_rc4_stream()
        pending = take_pending_pushes(ctx["player_id"], max_items=32)
        for item in pending:
            p_tag = item[0]
            p_msg = item[1]
            p_method = item[2] if len(item) > 2 else None
            if not _chat_send_packet(sock, s2c, "0", "", p_msg, p_tag, method=p_method):
                return False
        return True

    while time.time() < end_at:
        try:
            data = sock.recv(4096)
        except (TimeoutError, socket.timeout):
            if not _flush_pushes():
                break
            continue
        except OSError:
            break
        except Exception:
            break

        if not data:
            break

        record_player_activity(ctx["player_id"])
        ctx["recv_buf"] += data

        # Extract frames [len32][payload]
        while len(ctx["recv_buf"]) >= 4:
            payload_len = int.from_bytes(ctx["recv_buf"][:4], "big")
            if payload_len <= 0 or payload_len > 1024 * 1024:
                # Corrupted stream
                ctx["recv_buf"] = b""
                break
            if len(ctx["recv_buf"]) < 4 + payload_len:
                break

            frame_payload = ctx["recv_buf"][4:4 + payload_len]
            ctx["recv_buf"] = ctx["recv_buf"][4 + payload_len:]

            # Decode frame
            req_header: dict[str, str] = {}
            req_msg: dict[str, object] = {}

            if not ctx["login_done"]:
                prefix_parsed = _chat_parse_login_prefix(frame_payload)
                if prefix_parsed:
                    version, expire_time, pid, enc_body = prefix_parsed
                    ctx["player_id"] = pid
                    ctx["login_done"] = True
                    rc4_key = get_player_rc4_key(pid)
                    rc4_c2s = _RC4Stream(rc4_key)
                    rc4_s2c = _RC4Stream(rc4_key)
                    decrypted = rc4_c2s.crypt(enc_body)
                else:
                    c2s, _ = _ensure_rc4_stream()
                    decrypted = c2s.crypt(frame_payload)
            else:
                c2s, _ = _ensure_rc4_stream()
                decrypted = c2s.crypt(frame_payload)

            if len(decrypted) >= 2:
                hdr_len = int.from_bytes(decrypted[:2], "big")
                if len(decrypted) >= 2 + hdr_len:
                    hdr_bytes = decrypted[2:2 + hdr_len]
                    body_bytes = decrypted[2 + hdr_len:]
                    req_header = _chat_decode_header(hdr_bytes)
                    try:
                        req_msg = json.loads(body_bytes.decode("utf-8", errors="replace"))
                    except Exception:
                        req_msg = {}

            cmd = str(req_msg.get("cmd") or "").strip().lower()
            utils._append_utf8_log(
                f"[TCP][chat] cmd={cmd} session={req_header.get('session', '?')} player_id={ctx['player_id']}"
            )

            tag, response, push_msgs = handle_chat_command(req_msg, ctx["player_id"])

            # Send response
            _, s2c = _ensure_rc4_stream()
            resp_session = req_header.get("session") or "0"
            resp_trace = req_header.get("trace") or ""
            if not _chat_send_packet(sock, s2c, resp_session, resp_trace, response, f"resp-{tag}"):
                return

            # Send immediate pushes
            for p_tag, p_msg in push_msgs:
                if not _chat_send_packet(sock, s2c, "0", "", p_msg, p_tag):
                    return

            if not _flush_pushes():
                return

    try:
        remove_player_activity(ctx["player_id"])
        sock.close()
    except Exception:
        pass
    utils._append_utf8_log(f"[TCP][chat] closed connection from {peer}")
