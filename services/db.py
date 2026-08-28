import os
import json
import time
import threading
from pathlib import Path

from services.session_manager import (
    _GP_LOCK, _GP_TOKEN_TO_PLAYER_ID,
    _ONLINE_LOCK, _ONLINE_SAVE_LOCK, _ONLINE_STATE_PATH, _ONLINE_STATE
)

def _uid_str(uid: object, default: str = "") -> str:
    try:
        s = str(uid).strip()
        return s if s else default
    except Exception:
        return default

def _safe_int(val: object, default: int = 0) -> int:
    try:
        return int(str(val).strip())
    except Exception:
        return default

def _append_utf8_log(line: str) -> None:
    print(line)

def _gp_bind_token_player(token: object, player_id: object) -> None:
    tok = str(token or "").strip()
    pid = _uid_str(player_id, "1000001")
    if not tok:
        return
    with _GP_LOCK:
        _GP_TOKEN_TO_PLAYER_ID[tok] = pid


def _gp_player_id_from_token(token: object) -> str | None:
    tok = str(token or "").strip()
    if not tok:
        return None
    with _GP_LOCK:
        pid = _GP_TOKEN_TO_PLAYER_ID.get(tok)
    return _uid_str(pid) if pid else None


def _default_online_state() -> dict[str, object]:
    return {
        "profiles": {},
        "friends": {},
        "friend_applies": {},
        "follows": {},
        "next_apply_id": 1,
    }


def _normalize_online_state(raw: object) -> dict[str, object]:
    out = _default_online_state()
    if not isinstance(raw, dict):
        return out
    for key in ("profiles", "friends", "friend_applies", "follows"):
        value = raw.get(key)
        if isinstance(value, dict):
            out[key] = value
    out["next_apply_id"] = max(1, _safe_int(raw.get("next_apply_id"), 1))
    return out


def _load_online_state() -> dict[str, object]:
    try:
        if _ONLINE_STATE_PATH.exists():
            with _ONLINE_STATE_PATH.open("r", encoding="utf-8") as f:
                return _normalize_online_state(json.load(f))
    except Exception as exc:
        import traceback; traceback.print_exc()
        _append_utf8_log(f"[ONLINE] load failed: {exc}")
    return _default_online_state()


def _save_online_state() -> None:
    try:
        with _ONLINE_SAVE_LOCK:
            _ONLINE_STATE_PATH.parent.mkdir(parents=True, exist_ok=True)
            tmp = _ONLINE_STATE_PATH.with_suffix(
                f".tmp.{os.getpid()}.{threading.get_ident()}"
            )
            try:
                with tmp.open("w", encoding="utf-8", newline="\n") as f:
                    json.dump(_ONLINE_STATE, f, ensure_ascii=False, indent=2)

                replaced = False
                last_exc: Exception | None = None
                for attempt in range(4):
                    try:
                        tmp.replace(_ONLINE_STATE_PATH)
                        replaced = True
                        last_exc = None
                        break
                    except PermissionError as exc:
                        last_exc = exc
                        time.sleep(0.05 * (attempt + 1))

                if not replaced:
                    # Fallback for environments where replace/delete share on target
                    # is restricted by external file handles.
                    with _ONLINE_STATE_PATH.open("w", encoding="utf-8", newline="\n") as f:
                        json.dump(_ONLINE_STATE, f, ensure_ascii=False, indent=2)
                    if last_exc is not None:
                        _append_utf8_log(
                            f"[ONLINE] replace fallback used after PermissionError: {last_exc}"
                        )
            finally:
                try:
                    if tmp.exists():
                        tmp.unlink()
                except Exception:
                    pass
    except Exception as exc:
        import traceback; traceback.print_exc()
        _append_utf8_log(f"[ONLINE] save failed: {exc}")


def _online_now_ts() -> int:
    return int(time.time())


def _online_default_profile(uid: object) -> dict[str, object]:
    uid_s = _uid_str(uid, "1000001")
    suffix = uid_s[-4:] if len(uid_s) >= 4 else uid_s
    now = _online_now_ts()
    return {
        "uid": _safe_int(uid_s, 1000001),
        "name": f"Player{suffix or '0001'}",
        "level": 1,
        "exp": 0,
        "icon": 0,
        "icon_url": "",
        "icon_frame": 0,
        "time_zone": 0,
        "current_season_id": 1,
        "create_time": now,
        "gold": 0,
        "diamond": 0,
        "rank_score": 0,
        "show_character_id": 1,
        "update_time": now,
    }


def _online_profile_from_player_data(pd: object) -> dict[str, object]:
    if not isinstance(pd, dict):
        return _online_default_profile("1000001")
    profile = _online_default_profile(pd.get("uid"))
    profile["uid"] = _safe_int(pd.get("uid"), profile["uid"])
    profile["name"] = str(pd.get("name") or profile["name"])
    profile["level"] = max(1, _safe_int(pd.get("level"), profile["level"]))
    profile["exp"] = max(0, _safe_int(pd.get("exp"), profile["exp"]))
    profile["icon"] = max(0, _safe_int(pd.get("icon"), profile["icon"]))
    profile["icon_url"] = str(pd.get("icon_url") or "")
    profile["icon_frame"] = max(0, _safe_int(pd.get("icon_frame"), profile["icon_frame"]))
    profile["time_zone"] = _safe_int(pd.get("time_zone"), profile["time_zone"])
    profile["current_season_id"] = max(1, _safe_int(pd.get("current_season_id"), profile["current_season_id"]))
    profile["create_time"] = max(1, _safe_int(pd.get("create_time"), profile["create_time"]))
    profile["gold"] = max(0, _safe_int(pd.get("gold"), profile["gold"]))
    profile["diamond"] = max(0, _safe_int(pd.get("diamond"), profile["diamond"]))
    raw_rank_score = pd.get("rank_score")
    if raw_rank_score in (None, ""):
        # Keep unranked users unranked in chat payloads.
        profile["rank_score"] = 0
    else:
        profile["rank_score"] = max(0, _safe_int(raw_rank_score, 0))
    profile["update_time"] = _online_now_ts()
    return profile


def _get_or_create_uid_for_account(account: str) -> int:
    acc_str = str(account or "").strip()
    if not acc_str:
        return 1000001
    with _ONLINE_LOCK:
        mapping = _ONLINE_STATE.get("account_to_uid")
        if not isinstance(mapping, dict):
            mapping = {}
            _ONLINE_STATE["account_to_uid"] = mapping

        # Direct mapping lookup (exact or case-insensitive)
        if acc_str in mapping:
            return int(mapping[acc_str])
        for k, v in mapping.items():
            if k.lower() == acc_str.lower():
                return int(v)

        # If it's already a numeric UID, return it directly
        if acc_str.isdigit():
            val = int(acc_str)
            if val >= 1000001:
                mapping[acc_str] = val
                return val

        # Check existing profiles by player name
        profiles = _ONLINE_STATE.get("profiles", {})
        if isinstance(profiles, dict):
            for u_str, u_prof in profiles.items():
                if isinstance(u_prof, dict) and str(u_prof.get("name", "")).strip().lower() == acc_str.lower():
                    matched_uid = int(u_str) if u_str.isdigit() else 1000001
                    mapping[acc_str] = matched_uid
                    return matched_uid

        # Fallback to allocating new UID
        mapped_values = [int(v) for v in mapping.values() if isinstance(v, (int, str)) and str(v).isdigit()]
        max_mapped = max(mapped_values) if mapped_values else 1000000
        max_stored = 1000000
        if hasattr(globals().get("_player_data", None), "storage"):
            pd_storage = globals()["_player_data"].storage
            if pd_storage:
                try:
                    max_stored = max(int(k) for k in pd_storage.keys() if str(k).isdigit())
                except ValueError:
                    pass

        new_uid = max(max_mapped, max_stored) + 1
        mapping[acc_str] = new_uid
        try:
            _ONLINE_STATE_PATH.parent.mkdir(parents=True, exist_ok=True)
            with _ONLINE_STATE_PATH.open("w", encoding="utf-8", newline="\n") as f:
                json.dump(_ONLINE_STATE, f, ensure_ascii=False, indent=2)
        except Exception:
            pass
        return new_uid

def _online_ensure_profile(uid: object, *, local_pd: object = None) -> dict[str, object]:
    uid_s = _uid_str(uid, "1000001")
    changed = False
    with _ONLINE_LOCK:
        profiles = _ONLINE_STATE.get("profiles")
        if not isinstance(profiles, dict):
            profiles = {}
            _ONLINE_STATE["profiles"] = profiles
            changed = True

        profile_obj = profiles.get(uid_s)
        if not isinstance(profile_obj, dict):
            profile_obj = _online_default_profile(uid_s)
            profiles[uid_s] = profile_obj
            changed = True

        if isinstance(local_pd, dict):
            local_uid = _uid_str(local_pd.get("uid"), "1000001")
            if local_uid == uid_s:
                merged = _online_profile_from_player_data(local_pd)
                for key, val in merged.items():
                    if profile_obj.get(key) != val:
                        profile_obj[key] = val
                        changed = True

        out = dict(profile_obj)

    if changed:
        _save_online_state()
    return out


def _online_update_profile(
    uid: object,
    *,
    local_pd: object = None,
    fields: dict[str, object] | None = None,
) -> dict[str, object]:
    uid_s = _uid_str(uid, "1000001")
    _online_ensure_profile(uid_s, local_pd=local_pd)
    changed = False
    patch = fields if isinstance(fields, dict) else {}
    with _ONLINE_LOCK:
        profiles = _ONLINE_STATE.get("profiles")
        if not isinstance(profiles, dict):
            profiles = {}
            _ONLINE_STATE["profiles"] = profiles
            changed = True
        profile_obj = profiles.get(uid_s)
        if not isinstance(profile_obj, dict):
            profile_obj = _online_default_profile(uid_s)
            profiles[uid_s] = profile_obj
            changed = True
        for key, value in patch.items():
            if profile_obj.get(key) != value:
                profile_obj[key] = value
                changed = True
        if changed:
            profile_obj["update_time"] = _online_now_ts()
        out = dict(profile_obj)
    if changed:
        _save_online_state()
    return out


def _online_touch_local_profile(local_pd: object) -> None:
    if not isinstance(local_pd, dict):
        return
    _online_ensure_profile(local_pd.get("uid"), local_pd=local_pd)


def _online_get_uid_list(bucket_name: str, uid: object) -> list[str]:
    uid_s = _uid_str(uid, "1000001")
    with _ONLINE_LOCK:
        bucket = _ONLINE_STATE.get(bucket_name)
        if not isinstance(bucket, dict):
            return []
        raw = bucket.get(uid_s)
        if not isinstance(raw, list):
            return []
        out: list[str] = []
        seen: set[str] = set()
        for item in raw:
            item_s = _uid_str(item, "")
            if not item_s or item_s in seen:
                continue
            seen.add(item_s)
            out.append(item_s)
        return out


def _online_set_uid_list(bucket_name: str, uid: object, values: list[str]) -> None:
    uid_s = _uid_str(uid, "1000001")
    dedup: list[str] = []
    seen: set[str] = set()
    for value in values:
        value_s = _uid_str(value, "")
        if not value_s or value_s in seen:
            continue
        seen.add(value_s)
        dedup.append(value_s)
    with _ONLINE_LOCK:
        bucket = _ONLINE_STATE.get(bucket_name)
        if not isinstance(bucket, dict):
            bucket = {}
            _ONLINE_STATE[bucket_name] = bucket
        bucket[uid_s] = dedup
    _save_online_state()


def _online_add_uid(bucket_name: str, uid: object, target_uid: object) -> bool:
    uid_s = _uid_str(uid, "1000001")
    target_s = _uid_str(target_uid, "")
    if not target_s:
        return False
    changed = False
    with _ONLINE_LOCK:
        bucket = _ONLINE_STATE.get(bucket_name)
        if not isinstance(bucket, dict):
            bucket = {}
            _ONLINE_STATE[bucket_name] = bucket
            changed = True
        items = bucket.get(uid_s)
        if not isinstance(items, list):
            items = []
            bucket[uid_s] = items
            changed = True
        if target_s not in items:
            items.append(target_s)
            changed = True
    if changed:
        _save_online_state()
    return changed


def _online_remove_uid(bucket_name: str, uid: object, target_uid: object) -> bool:
    uid_s = _uid_str(uid, "1000001")
    target_s = _uid_str(target_uid, "")
    if not target_s:
        return False
    changed = False
    with _ONLINE_LOCK:
        bucket = _ONLINE_STATE.get(bucket_name)
        if not isinstance(bucket, dict):
            return False
        items = bucket.get(uid_s)
        if not isinstance(items, list):
            return False
        while target_s in items:
            items.remove(target_s)
            changed = True
    if changed:
        _save_online_state()
    return changed


_ONLINE_STATE = _load_online_state()

