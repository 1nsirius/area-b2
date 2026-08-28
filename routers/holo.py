import services.db as db
import services.utils as utils
import services.holo
import re
import json
import time
import hashlib
from urllib.parse import urlparse, parse_qs

def handle_route(path: str, req_json: dict, host: str, query: str, context: dict) -> bool:
    m = re.match(r"^/holo/([^/]+)/api/1/(.+)$", path or "")
    if not m:
        return False


    product = (m.group(1) or "p10470").strip().lower() or "p10470"
    api = (m.group(2) or "").strip().lstrip("/")

    if not isinstance(req_json, dict):
        req_json = {}

    if isinstance(query, str):
        query = parse_qs(query or "")
    elif query is None:
        query = {}
    player_id = (
        req_json.get("player_id")
        or req_json.get("playerId")
        or req_json.get("uid")
        or (query.get("player_id") or [""])[0]
        or (query.get("playerId") or [""])[0]
        or "1000001"
    )
    player_id = str(player_id).strip() or "1000001"

    ok = {
        "code": 0,
        "status": 0,
        "ret": 0,
        "success": True,
        "msg": "ok",
    }

    if api == "player_token/get_player_token":
        game_token = str(req_json.get("game_token") or (query.get("game_token") or [""])[0] or "").strip()
        if not game_token:
            game_token = str(req_json.get("token") or (query.get("token") or [""])[0] or "").strip()
        if not game_token:
            game_token = str(req_json.get("global_token") or (query.get("global_token") or [""])[0] or "").strip()
        if game_token.startswith("game-"):
            game_token = game_token[5:]
        if game_token:
            mapped_player_id = db._gp_player_id_from_token(game_token)
            if mapped_player_id:
                player_id = mapped_player_id

        token_data = services.holo.holo_player_token_payload(player_id)
        payload = {
            **ok,
            "product": product,
            **token_data,
            "data": dict(token_data),
        }
        line = f"[HOLO] player_token issued host={host} product={product} player_id={player_id}"
        print(line)
        utils._append_utf8_log(line)
        services.holo.chat_bootstrap_mark(player_id, 'seen_get_player_token', True, utils._append_utf8_log)
        utils._append_utf8_log(f"[CHAT_BOOTSTRAP] seen_get_player_token uid={player_id}")
        context['send_json'](payload)
        return True

    if api == "user/login_token":
        seed = f"{player_id}:{int(time.time() * 1000)}:{host}:{product}"
        login_token = "holo_login_" + hashlib.md5(seed.encode("utf-8")).hexdigest()
        payload = {
            **ok,
            "login_token": login_token,
            "data": {"login_token": login_token},
        }
        context['send_json'](payload)
        return True

    if api == "user/user_infos":
        ids = req_json.get("ids") if isinstance(req_json, dict) else None
        if not isinstance(ids, list):
            ids = []

        infos = []
        for uid_raw in ids[:30]:
            uid = str(uid_raw or "").strip()
            if not uid:
                continue
            profile = db._online_ensure_profile(uid)
            name = str(profile.get("name") or f"Player_{uid}")
            level = max(1, utils._safe_int(profile.get("level"), 1))
            icon = max(0, utils._safe_int(profile.get("icon"), 0))
            rank_score = max(0, utils._safe_int(profile.get("rank_score"), 0))

            item_info = {
                "user_id": uid,
                "player_id": uid,
                "id": uid,
                "name": name,
                "fbname": name,
                "level": level,
                "icon": icon,
                "rank_score": rank_score,
                "player_info": {
                    "user_id": uid,
                    "player_id": uid,
                    "id": uid,
                    "name": name,
                    "fbname": name,
                    "level": level,
                    "icon": icon,
                    "rank_score": rank_score,
                }
            }
            infos.append(item_info)

        payload = {
            **ok,
            "infos": infos,
            "data": {"infos": infos},
        }
        context['send_json'](payload)
        return True

    if api in {"user/info", "user/info/location", "user/info/photo/show/avatar"}:
        profile = db._online_ensure_profile(player_id)
        name = str(profile.get("name") or f"Player_{player_id}")
        level = max(1, utils._safe_int(profile.get("level"), 1))
        icon = max(0, utils._safe_int(profile.get("icon"), 0))
        rank_score = max(0, utils._safe_int(profile.get("rank_score"), 0))
        info = {
            "user_id": player_id,
            "player_id": player_id,
            "id": player_id,
            "name": name,
            "fbname": name,
            "level": level,
            "icon": icon,
            "rank_score": rank_score,
            "gender": 0,
            "bio": "",
            "player_info": {
                "user_id": player_id,
                "player_id": player_id,
                "id": player_id,
                "name": name,
                "fbname": name,
                "level": level,
                "icon": icon,
                "rank_score": rank_score,
            }
        }
        payload = {
            **ok,
            **info,
            "data": dict(info),
        }
        context['send_json'](payload)
        return True

    if api in {"sensitive_words/get_s_word_list_id", "sensitive_words/get_s_word_list"}:
        payload = {
            **ok,
            "list_id": 1,
            "list": [],
            "data": {"list_id": 1, "list": []},
        }
        context['send_json'](payload)
        return True

    if api == "customer_service/submit_record":
        ticket = f"cs_{int(time.time() * 1000)}"
        payload = {
            **ok,
            "ticket_id": ticket,
            "data": {"ticket_id": ticket},
        }
        context['send_json'](payload)
        return True

    utils._append_utf8_log(f"[HOLO] generic endpoint not handled by router: host={host} product={product} api={api or '-'}")
    return False
