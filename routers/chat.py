import json
import time
from urllib.parse import parse_qs

import services.chat as chat_service
import services.utils as utils
import services.db as db

def handle_route(path: str, req_json: dict, host: str, query: str, context: dict) -> bool:
    """
    Chat & Player Info HTTP Router.
    Handles endpoints required for chat player resolution and account lookups.
    Returns True if handled.
    """
    normalized_path = (path or "").strip()

    if not isinstance(req_json, dict):
        req_json = {}

    query_dict = parse_qs(query or "") if isinstance(query, str) else (query or {})

    # Extract caller UID
    caller_uid = (
        req_json.get("player_id")
        or req_json.get("playerId")
        or req_json.get("uid")
        or (query_dict.get("player_id") or [""])[0]
        or (query_dict.get("playerId") or [""])[0]
        or "1000001"
    )
    caller_uid_s = utils._uid_str(caller_uid, "1000001")

    ok = {
        "code": 0,
        "status": 0,
        "ret": 0,
        "success": True,
        "msg": "ok",
    }

    # ── PLAYER INFO LIST (ejoysdk_chat / player_info.lua: /player_api/get_player_info_list) ──
    if normalized_path == "/player_api/get_player_info_list":
        player_ids_raw = req_json.get("player_id_list")
        if not isinstance(player_ids_raw, list):
            player_ids_raw = req_json.get("player_ids")
        if not isinstance(player_ids_raw, list):
            player_ids_raw = query_dict.get("player_id_list")
        
        player_ids = player_ids_raw if isinstance(player_ids_raw, list) else []
        if not player_ids:
            player_ids = [caller_uid_s]

        player_list = []
        for pid in player_ids[:300]:
            pid_s = utils._uid_str(pid, "")
            if pid_s:
                player_list.append(chat_service.get_player_profile_payload(pid_s))

        payload = {
            **ok,
            "player_list": player_list,
            "data": {
                "player_list": player_list,
            },
        }
        utils._append_utf8_log(f"[ROUTER:CHAT] /player_api/get_player_info_list count={len(player_list)}")
        context['send_json'](payload)
        return True

    # ── ACCOUNT INFOS (/ga/client_api/get_account_infos) ──
    if normalized_path == "/ga/client_api/get_account_infos":
        account_ids_raw = req_json.get("account_ids")
        if not isinstance(account_ids_raw, list):
            account_ids_raw = query_dict.get("account_ids")
        account_ids = account_ids_raw if isinstance(account_ids_raw, list) else []
        if not account_ids:
            account_ids = [caller_uid_s]

        account_list = []
        now_ts = int(time.time())
        for acc in account_ids[:200]:
            acc_s = utils._uid_str(acc, "")
            if not acc_s:
                continue
            prof = chat_service.get_player_profile_payload(acc_s)
            account_list.append({
                "account_id": acc_s,
                "accountId": acc_s,
                "channel": "local",
                "official_info": {
                    "last_login_player": acc_s,
                    "nickname": str(prof.get("name") or f"Player_{acc_s}"),
                },
                "update_time": now_ts,
            })

        payload = {
            **ok,
            "account_list": account_list,
            "data": {
                "account_list": account_list,
            },
        }
        utils._append_utf8_log(f"[ROUTER:CHAT] /ga/client_api/get_account_infos count={len(account_list)}")
        context['send_json'](payload)
        return True

    # ── GET PLAYERS (/ga/client_api/get_players) ──
    if normalized_path in {"/ga/client_api/get_players", "/ga/client_api/get_player_infos"}:
        ids_raw = req_json.get("player_ids") or req_json.get("player_id_list") or req_json.get("account_ids")
        ids = ids_raw if isinstance(ids_raw, list) else [caller_uid_s]
        players = [chat_service.get_player_profile_payload(pid) for pid in ids[:200] if pid]

        payload = {
            **ok,
            "players": players,
            "player_list": players,
            "data": {
                "players": players,
                "player_list": players,
            },
        }
        context['send_json'](payload)
        return True

    return False
