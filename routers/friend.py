import hashlib
import time

import database
from services import db as online_db
from services.friend import (
    get_friend_list, get_friend_apply_list, get_friend_to_apply_list,
    add_friend_apply, accept_friend_apply, accept_friend_apply_by_applicant,
    refuse_friend_apply, refuse_friend_apply_by_applicant,
    del_friend, search_players, FriendError
)

def handle_route(path: str, req_json: dict, caller_uid: int) -> tuple[int, str, dict] | None:
    """
    Parses the HTTP request (network layer), delegates to the business logic,
    and formats the JSON response.
    
    Returns:
        (state_code, state_msg, data_obj) if the path belongs to this domain.
        None if the path is not part of this domain.
    """
    
    # Normalize paths
    # Some paths have /v2.0/ or /channel/v1.0/ prefix, so we strip them to match standard endpoints.
    normalized_path = path.replace("/v2.0", "").replace("/channel/v1.0", "")
    
    if normalized_path not in (
        "/friend/get_friend_list",
        "/friend/add_friend_apply",
        "/friend/accept_friend_apply",
        "/friend/refuse_friend_apply",
        "/friend/get_friend_apply_list",
        "/friend/get_friend_id_list",
        "/friend/get_friend_info_list",
        "/friend/get_friend_to_apply_list",
        "/friend/get_new_friend_apply_list",
        "/friend/get_new_friend_list",
        "/friend/del_friend",
        "/friend/del_friend_apply",
        "/friend/add_friend_black",
        "/friend/del_friend_black",
        "/friend/get_friend_black_list",
        "/friend/get_friend_group_member",
        "/player_search",
        "/global_player_search"
        , "/invite/send", "/invite/reply", "/invite/list"
    ):
        return None

    if not caller_uid:
        return (401, "Unauthorized", {})

    # Extract default last_index_time for syncing responses
    last_index_time = req_json.get("last_index_time", 0)

    try:
        # -----------------------------
        # GET FRIENDS
        # -----------------------------
        if normalized_path in (
            "/friend/get_friend_list", 
            "/friend/get_friend_id_list", 
            "/friend/get_friend_info_list", 
            "/friend/get_new_friend_list"
        ):
            friends = get_friend_list(caller_uid)
            friend_uids = database.get_friends(caller_uid)
            return (2000000, "ok", {
                "friend_list": friends,
                "friend_info_list": friends,
                "friend_id_list": [str(fid) for fid in friend_uids],
                "last_index_time": last_index_time or int(time.time() * 1000),
                "last_indexTime": last_index_time or int(time.time() * 1000)
            })
            
        # -----------------------------
        # ADD APPLY
        # -----------------------------
        elif normalized_path == "/friend/add_friend_apply":
            target_uid = int(req_json.get("friend_uid") or req_json.get("target_uid") or req_json.get("player_id") or 0)
            content = str(req_json.get("content") or req_json.get("apply_content") or "")
            add_friend_apply(applicant_uid=caller_uid, target_uid=target_uid, content=content)
            return (2000000, "ok", {})
            
        # -----------------------------
        # ACCEPT APPLY
        # -----------------------------
        elif normalized_path == "/friend/accept_friend_apply":
            applicant_uid = int(req_json.get("player_id") or req_json.get("friend_player_id") or req_json.get("apply_id") or 0)
            if req_json.get("apply_id") is not None and applicant_uid == int(req_json.get("apply_id") or 0):
                accept_friend_apply(uid=caller_uid, apply_id=applicant_uid)
            else:
                accept_friend_apply_by_applicant(uid=caller_uid, applicant_uid=applicant_uid)
            return (2000000, "ok", {})
            
        # -----------------------------
        # REFUSE APPLY
        # -----------------------------
        elif normalized_path == "/friend/refuse_friend_apply":
            applicant_uid = int(req_json.get("player_id") or req_json.get("friend_player_id") or req_json.get("apply_id") or 0)
            if req_json.get("apply_id") is not None and applicant_uid == int(req_json.get("apply_id") or 0):
                refuse_friend_apply(uid=caller_uid, apply_id=applicant_uid)
            else:
                refuse_friend_apply_by_applicant(uid=caller_uid, applicant_uid=applicant_uid)
            return (2000000, "ok", {})
            
        # -----------------------------
        # GET INCOMING APPLIES
        # -----------------------------
        elif normalized_path in ("/friend/get_friend_apply_list", "/friend/get_new_friend_apply_list"):
            applies = get_friend_apply_list(caller_uid, last_index_time=last_index_time)
            resp_lit = max([a["last_index_time"] for a in applies], default=last_index_time or int(time.time() * 1000))
            return (2000000, "ok", {
                "friend_apply_list": applies,
                "apply_list": applies,
                "last_index_time": resp_lit,
                "last_indexTime": resp_lit,
            })
            
        # -----------------------------
        # GET OUTGOING APPLIES
        # -----------------------------
        elif normalized_path == "/friend/get_friend_to_apply_list":
            applies = get_friend_to_apply_list(caller_uid, last_index_time=last_index_time)
            resp_lit = max([a["last_index_time"] for a in applies], default=last_index_time or int(time.time() * 1000))
            return (2000000, "ok", {
                "friend_apply_list": applies,
                "friend_to_apply_list": applies,
                "apply_list": applies,
                "last_index_time": resp_lit,
                "last_indexTime": resp_lit,
            })
            
        # -----------------------------
        # DELETE FRIEND
        # -----------------------------
        elif normalized_path == "/friend/del_friend":
            target_uid = int(req_json.get("friend_player_id") or req_json.get("player_id") or req_json.get("friend_uid") or req_json.get("friend_id") or 0)
            del_friend(uid=caller_uid, target_uid=target_uid)
            return (2000000, "ok", {})
            
        # -----------------------------
        # OTHER NO-OP ENDPOINTS
        # -----------------------------
        elif normalized_path == "/friend/del_friend_apply":
            return (2000000, "ok", {})
            
        elif normalized_path in ("/friend/add_friend_black", "/friend/del_friend_black"):
            return (2000000, "ok", {})
            
        elif normalized_path == "/friend/get_friend_black_list":
            return (2000000, "ok", {"black_list": []})
            
        elif normalized_path == "/friend/get_friend_group_member":
            return (2000000, "ok", {"group_member_list": []})

        elif normalized_path in ("/friend/get_channel_friends", "/friend/refresh_channel_friends"):
            return (2000000, "ok", {
                "channel_friend_list": [],
                "channel_friends": [],
                "last_index_time": last_index_time or int(time.time() * 1000),
                "last_indexTime": last_index_time or int(time.time() * 1000)
            })
            
        # -----------------------------
        # SEARCH
        # -----------------------------
        elif normalized_path == "/player_search":
            query = str(req_json.get("search_data") or "").strip()
            if not query:
                query = str(req_json.get("keyword") or "").strip()
            if not query:
                query = str(req_json.get("name") or "").strip()
            if not query:
                query = str(req_json.get("account") or "").strip()
            if not query:
                query = str(req_json.get("query") or "").strip()
            if not query:
                query = str(req_json.get("nick") or req_json.get("nickname") or "").strip()

            results = search_players(query)
            return (2000000, "ok", {"player_info_list": results})

        elif normalized_path == "/global_player_search":
            query = str(req_json.get("search_data") or "").strip()
            if not query:
                query = str(req_json.get("keyword") or "").strip()
            if not query:
                query = str(req_json.get("name") or "").strip()
            if not query:
                query = str(req_json.get("account") or "").strip()
            if not query:
                query = str(req_json.get("query") or "").strip()
            if not query:
                query = str(req_json.get("nick") or req_json.get("nickname") or "").strip()

            results = search_players(query)
            search_id = "search_" + hashlib.md5(
                f"{caller_uid}:{query}:{int(time.time() * 1000)}".encode("utf-8")
            ).hexdigest()[:16]
            return (2000000, "ok", {
                "search_id": search_id,
                "region_count": 1,
                "player_info_list": results,
            })

        # -----------------------------
        # SIMPLE INVITE EMULATION (HTTP)
        # -----------------------------
        elif normalized_path == "/invite/send":
            target_uid = int(req_json.get("target_uid") or req_json.get("friend_uid") or req_json.get("player_id") or 0)
            if not target_uid:
                return (4000001, "missing target_uid", {})

            now = int(time.time())
            invite = {
                "from_uid": caller_uid,
                "to_uid": target_uid,
                "invite_id": int(now * 1000),
                "create_time": now,
            }

            with online_db._ONLINE_LOCK:
                invites_bucket = online_db._ONLINE_STATE.get("invites")
                if not isinstance(invites_bucket, dict):
                    invites_bucket = {}
                    online_db._ONLINE_STATE["invites"] = invites_bucket
                target_list = invites_bucket.get(str(target_uid))
                if not isinstance(target_list, list):
                    target_list = []
                    invites_bucket[str(target_uid)] = target_list
                target_list.append(invite)
                try:
                    online_db._save_online_state()
                except Exception:
                    pass

            return (2000000, "ok", {})

        elif normalized_path == "/invite/list":
            # list pending invites for caller
            with online_db._ONLINE_LOCK:
                invites_bucket = online_db._ONLINE_STATE.get("invites") or {}
                pending = invites_bucket.get(str(caller_uid)) or []
            return (2000000, "ok", {"invites": list(pending)})

        elif normalized_path == "/invite/reply":
            # reply: accept or refuse an invite
            invite_id = int(req_json.get("invite_id") or 0)
            action = str(req_json.get("action") or "refuse").lower()
            if not invite_id:
                return (4000002, "missing invite_id", {})

            handled = False
            with online_db._ONLINE_LOCK:
                invites_bucket = online_db._ONLINE_STATE.get("invites") or {}
                # search across all incoming lists for this invite id
                for target, lst in invites_bucket.items():
                    if not isinstance(lst, list):
                        continue
                    for inv in list(lst):
                        if int(inv.get("invite_id") or 0) == invite_id and int(inv.get("to_uid") or 0) == caller_uid:
                            lst.remove(inv)
                            handled = True
                            from_uid = int(inv.get("from_uid") or 0)
                            # accept -> add friends both sides
                            if action == "accept" and from_uid:
                                try:
                                    database.add_friend(caller_uid, from_uid)
                                    database.add_friend(from_uid, caller_uid)
                                except Exception:
                                    pass
                            break
                try:
                    online_db._save_online_state()
                except Exception:
                    pass

            if not handled:
                return (1003, "invite not found", {})
            return (2000000, "ok", {})
            
    except FriendError as e:
        return (e.code, e.message, {})
    except Exception as e:
        import traceback
        traceback.print_exc()
        return (5000000, "Internal Server Error", {})
        
    return None
