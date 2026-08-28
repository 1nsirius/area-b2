import time
import logging
import database
from services import db as online_db

logger = logging.getLogger("areaf2_server.services.friend")

class FriendError(Exception):
    """Custom exception for business logic errors in the friend domain."""
    def __init__(self, code: int, message: str):
        self.code = code
        self.message = message
        super().__init__(self.message)


def _as_uid(value: object) -> int | None:
    try:
        uid = int(str(value).strip())
    except Exception:
        return None
    return uid if uid > 0 else None


def _profile_payload(profile: dict) -> dict:
    import services.chat as chat_service
    uid = _as_uid(profile.get("uid")) or _as_uid(profile.get("player_id")) or 0
    uid_s = str(uid)
    name = str(profile.get("name") or f"Player{uid_s[-4:] or '0001'}")
    level = int(profile.get("level") or 1)
    icon = int(profile.get("icon") or 0)
    icon_url = str(profile.get("icon_url") or "")
    fbname = str(profile.get("fbname") or "")
    rank_score = int(profile.get("rank_score") or 0)
    cur_state = chat_service.get_player_state(uid_s)
    is_online = (cur_state != 0)

    return {
        "player_id": uid_s,
        "playerId": uid_s,
        "user_id": uid_s,
        "id": uid_s,
        "uid": uid,
        "name": name,
        "level": level,
        "icon": icon,
        "icon_url": icon_url,
        "fbname": fbname,
        "rank_score": rank_score,
        "is_online": is_online,
        "is_in_battle": cur_state in (6, 7),
        "is_allow_watch": True,
        "rank_level": rank_score // 100,
        "state": cur_state,
        "player_info": {
            "player_id": uid_s,
            "playerId": uid_s,
            "user_id": uid_s,
            "id": uid_s,
            "uid": uid,
            "name": name,
            "level": level,
            "icon": icon,
            "icon_url": icon_url,
            "fbname": fbname,
            "rank_score": rank_score,
            "state": cur_state,
        },
    }


def _normalize_query(value: object) -> str:
    return str(value or "").strip().lower()


def _upsert_profile(profile: dict) -> dict | None:
    uid = _as_uid(profile.get("uid"))
    if uid is None:
        return None

    payload = {
        "uid": uid,
        "name": str(profile.get("name") or f"Player{str(uid)[-4:] or '0001'}"),
        "level": int(profile.get("level") or 1),
        "exp": int(profile.get("exp") or 0),
        "icon": int(profile.get("icon") or 0),
        "icon_url": str(profile.get("icon_url") or ""),
        "icon_frame": int(profile.get("icon_frame") or 0),
        "time_zone": int(profile.get("time_zone") or 0),
        "current_season_id": int(profile.get("current_season_id") or 1),
        "create_time": int(profile.get("create_time") or int(time.time())),
        "gold": int(profile.get("gold") or 0),
        "diamond": int(profile.get("diamond") or 0),
        "rank_score": int(profile.get("rank_score") or 0),
        "show_character_id": int(profile.get("show_character_id") or 1),
        "update_time": int(profile.get("update_time") or int(time.time())),
    }

    current = database.get_profile(uid)
    if current:
        try:
            database.update_profile(uid, **payload)
        except Exception:
            pass
    else:
        try:
            database.create_profile(payload)
        except Exception:
            pass

    return database.get_profile(uid) or payload


def _resolve_profile(uid: object) -> dict | None:
    uid_int = _as_uid(uid)
    if uid_int is None:
        return None
    uid_s = str(uid_int)

    local_pd = None
    try:
        if hasattr(globals().get("_player_data", None), "storage"):
            local_pd = globals()["_player_data"].storage.get(uid_s)
    except Exception:
        local_pd = None

    try:
        online_profile = online_db._online_ensure_profile(uid_int, local_pd=local_pd)
    except Exception:
        online_profile = None

    db_profile = database.get_profile(uid_int)

    merged = dict(db_profile or {})
    if isinstance(online_profile, dict):
        for k, v in online_profile.items():
            if v not in (None, "", 0) or k not in merged:
                merged[k] = v

    if isinstance(local_pd, dict):
        for k in ("name", "icon", "icon_url", "level", "rank_score", "gold", "diamond"):
            if k in local_pd and local_pd[k] is not None:
                merged[k] = local_pd[k]

    if not merged:
        merged = {
            "uid": uid_int,
            "name": f"Player{uid_s[-4:]}",
            "level": 1,
            "icon": 0,
            "icon_url": "",
            "rank_score": 0,
        }

    merged["uid"] = uid_int
    _upsert_profile(merged)
    return merged


def _match_profile(profile: dict, query: str) -> bool:
    if not query:
        return False
    uid_s = str(profile.get("uid") or "")
    name_s = _normalize_query(profile.get("name"))
    fbname_s = _normalize_query(profile.get("fbname"))
    account_s = _normalize_query(profile.get("account") or profile.get("account_id"))
    nick_s = _normalize_query(profile.get("nick") or profile.get("nickname"))
    player_info = profile.get("player_info")
    player_info_name_s = ""
    if isinstance(player_info, dict):
        player_info_name_s = _normalize_query(player_info.get("name"))
        if not account_s:
            account_s = _normalize_query(player_info.get("account") or player_info.get("account_id"))
        if not nick_s:
            nick_s = _normalize_query(player_info.get("fbname") or player_info.get("nickname"))

    if query.isdigit() and uid_s == query:
        return True
    if query in uid_s.lower():
        return True
    if query in name_s:
        return True
    if query in fbname_s:
        return True
    if query in account_s:
        return True
    if query in nick_s:
        return True
    if query in player_info_name_s:
        return True
    return False

def get_friend_list(uid: int) -> list[dict]:
    """Retrieves the list of friends for a given user."""
    friend_uids = database.get_friends(uid)
    friend_profiles = []
    
    for f_uid in friend_uids:
        prof = _resolve_profile(f_uid)
        if prof:
            friend_profiles.append(_profile_payload(prof))
            
    return friend_profiles

def get_friend_apply_list(uid: int, last_index_time: int | None = None) -> list[dict]:
    """Retrieves incoming friend applications for a given user."""
    rows = database.get_friend_applies(uid, state=0, last_index_time=last_index_time)
    result = []
    for apply in rows:
        applicant_uid = int(apply["applicant_uid"])
        prof = _resolve_profile(applicant_uid)
        prof_dict = prof if prof else {"uid": applicant_uid, "name": f"Player{applicant_uid}"}
        payload = _profile_payload(prof_dict)
        
        item = {
            "apply_id": int(apply.get("apply_id", 0)),
            "uid": uid,
            "target_uid": uid,
            "applicant_uid": applicant_uid,
            "user_id": str(applicant_uid),
            "player_id": str(applicant_uid),
            "state": int(apply.get("state", 0)),
            "content": str(apply.get("content") or ""),
            "create_time": int(apply.get("create_time") or 0),
            "last_index_time": int(apply.get("last_index_time") or 0),
            "player_info": payload["player_info"],
            "player": payload,
        }
        result.append(item)
    return result

def get_friend_to_apply_list(applicant_uid: int, last_index_time: int | None = None) -> list[dict]:
    """Retrieves outgoing friend applications made by a user."""
    rows = database.get_friend_to_applies(applicant_uid, state=0, last_index_time=last_index_time)
    result = []
    for apply in rows:
        target_uid = int(apply["uid"])
        prof = _resolve_profile(target_uid)
        prof_dict = prof if prof else {"uid": target_uid, "name": f"Player{target_uid}"}
        payload = _profile_payload(prof_dict)
        
        item = {
            "apply_id": int(apply.get("apply_id", 0)),
            "uid": target_uid,
            "target_uid": target_uid,
            "applicant_uid": applicant_uid,
            "user_id": str(target_uid),
            "player_id": str(target_uid),
            "state": int(apply.get("state", 0)),
            "content": str(apply.get("content") or ""),
            "create_time": int(apply.get("create_time") or 0),
            "last_index_time": int(apply.get("last_index_time") or 0),
            "player_info": payload["player_info"],
            "player": payload,
        }
        result.append(item)
    return result


def _find_pending_apply(uid: int, *, apply_id: int | None = None, applicant_uid: int | None = None) -> dict | None:
    applies = database.get_friend_applies(uid, state=0)
    if apply_id is not None:
        for item in applies:
            if int(item.get("apply_id", 0) or 0) == apply_id:
                return item
    if applicant_uid is not None:
        for item in applies:
            if int(item.get("applicant_uid", 0) or 0) == applicant_uid:
                return item
    return None

def add_friend_apply(applicant_uid: int, target_uid: int, content: str = "") -> None:
    """Creates a new friend application."""
    if applicant_uid == target_uid:
        raise FriendError(20010, "Cannot add yourself as a friend")
        
    # Check if already friends
    existing_friends = database.get_friends(applicant_uid)
    if target_uid in existing_friends:
        raise FriendError(20000, "Already friends")
        
    # Check if target exists
    if not _resolve_profile(target_uid):
        raise FriendError(1004, "Target player not found")
        
    now = int(time.time())
    database.add_friend_apply(
        uid=target_uid,
        applicant_uid=applicant_uid,
        state=0,
        content=content,
        create_time=now,
        last_index_time=int(now * 1000)
    )
    logger.info(f"Added friend apply from {applicant_uid} to {target_uid}")
    try:
        import services.chat as chat_service
        chat_service.push_friend_apply(target_uid, applicant_uid)
    except Exception as exc:
        logger.warning(f"Failed to push friend_apply: {exc}")

def accept_friend_apply(uid: int, apply_id: int) -> None:
    """Accepts a friend application and creates bidirectional friendship."""
    apply = _find_pending_apply(uid, apply_id=apply_id)
    
    if not apply:
        raise FriendError(1003, "Friend application not found")
        
    if apply["state"] != 0:
        raise FriendError(1005, "Friend application already processed")
        
    applicant_uid = apply["applicant_uid"]
    
    # Create friendship in SQLite database
    database.add_friend(uid, applicant_uid)
    database.add_friend(applicant_uid, uid)
    
    # Synchronize online_state
    try:
        online_db._online_add_uid("friends", uid, applicant_uid)
        online_db._online_add_uid("friends", applicant_uid, uid)
    except Exception as exc:
        logger.warning(f"Failed to sync friends to online_state: {exc}")

    # Mark apply as accepted
    database.update_friend_apply_state(apply_id, 1)
    logger.info(f"Accepted friend apply {apply_id}: {applicant_uid} <-> {uid}")

    # Dispatch real-time push to both connected clients so friend lists refresh immediately
    try:
        import services.chat as chat_service
        chat_service.push_friend_add(uid, applicant_uid)
    except Exception as exc:
        logger.warning(f"Failed to push friend_add: {exc}")

def refuse_friend_apply(uid: int, apply_id: int) -> None:
    """Refuses a friend application."""
    apply = _find_pending_apply(uid, apply_id=apply_id)
    
    if not apply:
        raise FriendError(1003, "Friend application not found")
        
    if apply["state"] != 0:
        raise FriendError(1005, "Friend application already processed")
        
    # Mark apply as refused
    database.update_friend_apply_state(apply_id, 2)
    logger.info(f"Refused friend apply {apply_id}")

def del_friend(uid: int, target_uid: int) -> None:
    """Deletes a friend bidirectionally."""
    database.remove_friend(uid, target_uid)
    database.remove_friend(target_uid, uid)
    try:
        online_db._online_remove_uid("friends", uid, target_uid)
        online_db._online_remove_uid("friends", target_uid, uid)
    except Exception as exc:
        logger.warning(f"Failed to remove friend from online_state: {exc}")
    logger.info(f"Deleted friend {target_uid} from {uid}")

    try:
        import services.chat as chat_service
        chat_service.push_friend_del(uid, target_uid)
    except Exception as exc:
        logger.warning(f"Failed to push friend_del: {exc}")


def accept_friend_apply_by_applicant(uid: int, applicant_uid: int) -> None:
    apply = _find_pending_apply(uid, applicant_uid=applicant_uid)
    if not apply:
        raise FriendError(1003, "Friend application not found")
    accept_friend_apply(uid, int(apply.get("apply_id", 0) or 0))


def refuse_friend_apply_by_applicant(uid: int, applicant_uid: int) -> None:
    apply = _find_pending_apply(uid, applicant_uid=applicant_uid)
    if not apply:
        raise FriendError(1003, "Friend application not found")
    refuse_friend_apply(uid, int(apply.get("apply_id", 0) or 0))

def search_players(query: str) -> list[dict]:
    """Searches for players by UID or Name."""
    query_s = _normalize_query(query)
    if not query_s:
        return []

    matches: dict[int, dict] = {}

    # Check online profiles first
    with online_db._ONLINE_LOCK:
        online_profiles = online_db._ONLINE_STATE.get("profiles")
        if isinstance(online_profiles, dict):
            for uid_s, profile in online_profiles.items():
                if not isinstance(profile, dict):
                    continue
                if _match_profile(profile, query_s):
                    uid = _as_uid(profile.get("uid") or uid_s)
                    if uid is not None:
                        resolved = _resolve_profile(uid) or profile
                        matches[uid] = _profile_payload(resolved)

    # Check database profiles
    all_profiles = database.get_all_profiles()
    for profile in all_profiles.values():
        if isinstance(profile, dict) and _match_profile(profile, query_s):
            uid = _as_uid(profile.get("uid"))
            if uid is not None and uid not in matches:
                resolved = _resolve_profile(uid) or profile
                matches[uid] = _profile_payload(resolved)

    result = list(matches.values())
    result.sort(key=lambda item: (str(item.get("name") or "").lower(), int(item.get("player_id") or 0)))
    return result
