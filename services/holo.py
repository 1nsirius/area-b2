import os
import time
import hashlib
import services.session_manager as session_manager

def _uid_str(uid: object, default: str = "") -> str:
    # Minimal version of uid_str for services
    try:
        s = str(uid).strip()
        return s if s else default
    except Exception:
        return default

def chat_bootstrap_mark(uid: object, key: str, value: bool = True, logger=None) -> None:
    uid_s = _uid_str(uid, "")
    if not uid_s:
        return
    snapshot: dict[str, object] | None = None
    with session_manager._CHAT_BOOTSTRAP_LOCK:
        state = session_manager._CHAT_BOOTSTRAP_STATE.get(uid_s)
        if not isinstance(state, dict):
            state = {"attempts": 0}
            session_manager._CHAT_BOOTSTRAP_STATE[uid_s] = state
        state[key] = value
        if value and key in {"seen_get_player_token", "seen_chat_login"}:
            state["done"] = True
        if key in {"seen_set_player_info", "seen_get_player_token", "seen_chat_login"}:
            snapshot = {
                "attempts": int(state.get("attempts") or 0),
                "force_naming_attempts": int(state.get("force_naming_attempts") or 0),
                "seen_set_player_info": bool(state.get("seen_set_player_info")),
                "seen_get_player_token": bool(state.get("seen_get_player_token")),
                "seen_chat_login": bool(state.get("seen_chat_login")),
                "done": bool(state.get("done")),
            }
    if snapshot is not None and logger is not None:
        logger(
            f"[CHAT_BOOTSTRAP] mark "
            f"uid={uid_s} key={key} value={1 if value else 0} "
            f"seen_set_player_info={1 if snapshot.get('seen_set_player_info') else 0} "
            f"seen_get_player_token={1 if snapshot.get('seen_get_player_token') else 0} "
            f"seen_chat_login={1 if snapshot.get('seen_chat_login') else 0} "
        )

def holo_player_token_payload(player_id: object | None) -> dict[str, object]:
    pid = str(player_id or "1000001").strip() or "1000001"
    now = int(time.time())

    ttl_raw = (os.environ.get("HOLO_TOKEN_TTL_SEC") or "86400").strip()
    try:
        ttl_sec = int(ttl_raw)
    except Exception:
        ttl_sec = 86400
    if ttl_sec < 600:
        ttl_sec = 600

    with session_manager._HOLO_LOCK:
        cached = session_manager._HOLO_PLAYER_TOKENS.get(pid)
        if cached:
            try:
                exp = int(cached.get("expire_time", 0) or 0)
            except Exception:
                exp = 0
            if exp > now + 120:
                return dict(cached)

        salt = (os.environ.get("HOLO_TOKEN_SALT") or "local-holo").strip() or "local-holo"
        moment_token = "mtk_" + hashlib.md5(f"{pid}:{salt}:moment".encode("utf-8")).hexdigest()
        key = hashlib.md5(f"{pid}:{salt}:key".encode("utf-8")).hexdigest()[:16]
        expire_time = now + ttl_sec

        payload = {
            "player_id": pid,
            "playerId": pid,
            "uid": pid,
            "moment_token": moment_token,
            "key": key,
            "expire_time": expire_time,
        }
        session_manager._HOLO_PLAYER_TOKENS[pid] = payload
        return dict(payload)
