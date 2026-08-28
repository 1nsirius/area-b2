import services.db as db
import services.holo
import services.utils as utils
import time
import json
import hashlib
import re

def handle_route(path: str, req_json: dict, host: str, caller_uid_int: int, context: dict) -> bool:
    """
    Auth and GP Router.
    Returns True if handled.
    """

    if path == "/gp/p10470/v2/get_server_time":
        now_ms = int(time.time() * 1000)
        now = now_ms // 1000
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "data": {
                    "server_time_ms": now_ms,
                    "serverTimeMs": now_ms,
                    "server_time": now,
                    "serverTime": now,
                    "time": now,
                },
                "server_time_ms": now_ms,
                "serverTimeMs": now_ms,
                "server_time": now,
                "serverTime": now,
                "time": now,
            }
        )
        return True


    if path == "/gp/p10470/logined/v2/get_players":
        # Mirrors M.get_players_from_gs() in the dumped Lua.
        req_uid = context["resolve_player_id_from_request"](req_json)
        profile = db._online_ensure_profile(req_uid)
        p_name = str(profile.get("name") or f"Player{req_uid[-4:]}")
        p_level = int(profile.get("level") or 1)
        players = [
            {
                "server_id": "1",
                "serverId": "1",
                "server": "1",
                "server_name": "Local",
                "serverName": "Local",
                "player_id": req_uid,
                "playerId": req_uid,
                "player_name": p_name,
                "playerName": p_name,
                "level": p_level,
                "roleLevel": p_level,
            }
        ]
        context['send_json']({"code": 0, "status": 0, "ret": 0, "success": True, "msg": "ok", "players": players, "data": {"players": players}})
        return True

    if path == "/gp/p10470/logined/v2/alive_servers":
        # Mirrors M.alive_servers_with_auth() in the dumped Lua.
        realm_host = context['realm_host_for_client']()
        realm = f"{realm_host}:{context['GAME_PORT']}"
        region_code = utils._infer_region_from_host(host) or "sg"
        region_code = str(region_code).strip().lower()
        area = "SG" if region_code in {"sg", "sgtest"} else region_code.upper()
        servers = [
            {
                "id": "1",
                "serverId": "1",
                "server_id": "1",
                "sid": "1",
                "zoneId": "1",
                "serverName": "Local",
                "server_name": "Local",
                "name": "Local",
                "desc": "Local server",
                "description": "Local server",
                "notice": "",
                "announcement": "",
                # Many client UIs treat status/state==1 as MAINTENANCE.
                # Prefer 0 and explicitly set maintenance flags to avoid gating.
                "status": 0,
                "state": 0,
                "server_status": 0,
                "serverState": 0,
                "online": True,
                "open": True,
                "maintenance": 0,
                "maintain": 0,
                "is_maintain": False,
                "isMaintenance": False,
                "maint": False,
                "recommend": True,
                "region": region_code,
                "area": area,
                "host": realm_host,
                "ip": realm_host,
                "port": context['GAME_PORT'],
                "realm": [realm_host],
                "realms": [realm_host],
                "realm_addr": [realm],
                "realmAddr": [realm],
            }
        ]
        resp_alive = {
            "code": 0,
            "status": 0,
            "ret": 0,
            "success": True,
            "msg": "ok",
            "servers": servers,
            "data": {"servers": servers},
        }
        resp_alive = utils._ensure_alive_servers_contract(resp_alive, realm_host, context['GAME_PORT'], region_code)
        context['send_json'](resp_alive)
        return True

    if host.endswith(".qookkagames.com") or host == "qookkagames.com":
        context['send_json'](self._qookka_stub_payload())
        return True

    if path == "/dl/p10470/create":
        # Trace service stub.
        now = int(time.time())
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "data": {"trace_id": "local", "created_at": now},
            }
        )
        return True




    if path == "/gp/p10470/logined/v2/get_official_bind_info":
        # Called right after login in some builds.
        # Be permissive and include list-shaped fields to avoid nil iteration.
        resp = {
            "code": 0,
            "status": 0,
            "ret": 0,
            "success": True,
            "msg": "ok",
            "bind_info": [],
            "data": {"bind_info": []},
        }
        context['send_json'](resp)
        return True

    if path == "/gp/p10470/v2/alive_servers":
        # Lua expects: body.servers (array) and each item has realm as an array.
        # It then does: server.realm = server.realm[1] or ''
        realm_host = context['realm_host_for_client']()
        realm = f"{realm_host}:{context['GAME_PORT']}"
        region_code = utils._infer_region_from_host(host) or "sg"
        region_code = str(region_code).strip().lower()
        area = "SG" if region_code in {"sg", "sgtest"} else region_code.upper()
        servers = [
            {
                # IDs: keep both common naming conventions.
                "id": "1",
                "serverId": "1",
                "server_id": "1",
                "sid": "1",
                "zoneId": "1",
                # Names: some UIs expect snake_case; if missing they may default to 0 -> StringID:0.
                "serverName": "Local",
                "server_name": "Local",
                "name": "Local",
                "desc": "Local server",
                "description": "Local server",
                "notice": "",
                "announcement": "",
                # Many client UIs treat status/state==1 as MAINTENANCE.
                "status": 0,
                "state": 0,
                "server_status": 0,
                "serverState": 0,
                "online": True,
                "open": True,
                "maintenance": 0,
                "maintain": 0,
                "is_maintain": False,
                "isMaintenance": False,
                "maint": False,
                "recommend": True,
                "region": region_code,
                "area": area,
                "host": realm_host,
                "ip": realm_host,
                "port": context['GAME_PORT'],
                "realm": [realm_host],
                "realms": [realm_host],
                "realm_addr": [realm],
                "realmAddr": [realm],
            }
        ]
        resp_alive = {
            "code": 0,
            "status": 0,
            "ret": 0,
            "success": True,
            "msg": "ok",
            "servers": servers,
            "data": {"servers": servers},
        }
        resp_alive = utils._ensure_alive_servers_contract(resp_alive, realm_host, context['GAME_PORT'], region_code)
        context['send_json'](resp_alive)
        return True

    if path == "/gp/p10470/v2/access":
        # Called with { token = USER_INFO.token }. Keep permissive.
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "access": True,
                "data": {"access": True},
            }
        )
        return True

    if path == "/gp/p10470/v2/get_global_token":
        # Used by global_acquire_with_local_token(): expects body.global_token.
        now_ms = int(time.time() * 1000)
        token_seed = f"global:{host}:{now_ms}"
        global_token = hashlib.md5(token_seed.encode("utf-8")).hexdigest()
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "global_token": global_token,
                "data": {"global_token": global_token},
            }
        )
        return True

    if path == "/gp/p10470/v2/queue_dropout":
        # Best-effort ack for queue cancel requests.
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "data": {},
            }
        )
        return True

    if path == "/gp/p10470/v2/queue":
        import services.gp
        return services.gp.generate_queue_response(req_json, host, context)

    if path == "/gp/p10470/v2/can_pay":
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "can_pay": True,
                "data": {"can_pay": True},
            }
        )
        return True

    if path == "/gp/p10470/v2/has_set_player_info":
        # In private/local setups we prefer forcing explicit set_player_info path:
        # client-side SDK may gate holo/chat bootstrap on that stage.
        # Keep env override for compatibility:
        #   HAS_SET_PLAYER_INFO=1 -> old behavior
        #   HAS_SET_PLAYER_INFO=0 -> request client to set player info
        has_set_player_info = utils._env_truthy("HAS_SET_PLAYER_INFO", "0")
        utils._append_utf8_log(
            f"[CONTRACT] has_set_player_info reply={1 if has_set_player_info else 0}"
        )
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "has_set_player_info": has_set_player_info,
                "data": {"has_set_player_info": has_set_player_info},
            }
        )
        return True

    if path == "/gp/p10470/v2/set_player_info":
        req = req_json

        pid_raw = (
            req.get("player_id")
            or req.get("playerId")
            or req.get("pid")
            or req.get("uid")
            or req.get("user_id")
            or req.get("userId")
        )
        player_id = str(pid_raw) if pid_raw is not None else "1000001"
        player_name = str(
            req.get("player_name")
            or req.get("playerName")
            or req.get("name")
            or f"Player{player_id[-4:]}"
        )
        server_id = str(req.get("server_id") or req.get("serverId") or req.get("server") or "1")
        services.holo.chat_bootstrap_mark(player_id, "seen_set_player_info", True, utils._append_utf8_log)

        # Pre-create token material so next holo/chat stages have consistent values.
        holo_token = context['holo_player_token_payload'](player_id)
        try:
            utils._append_utf8_log(
                "[CONTRACT] set_player_info "
                f"player_id={player_id} server_id={server_id} "
                f"moment_token={str(holo_token.get('moment_token') or '')[:24]}..."
            )
        except Exception:
            pass

        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "player_id": player_id,
                "playerId": player_id,
                "player_name": player_name,
                "playerName": player_name,
                "server_id": server_id,
                "serverId": server_id,
                "moment_token": str(holo_token.get("moment_token") or ""),
                "key": str(holo_token.get("key") or ""),
                "expire_time": int(holo_token.get("expire_time") or 0),
                "data": {
                    "player_id": player_id,
                    "playerId": player_id,
                    "player_name": player_name,
                    "playerName": player_name,
                    "server_id": server_id,
                    "serverId": server_id,
                    "moment_token": str(holo_token.get("moment_token") or ""),
                    "key": str(holo_token.get("key") or ""),
                    "expire_time": int(holo_token.get("expire_time") or 0),
                },
            }
        )
        return True

    if path == "/gp/p10470/v2/realname_enabled":
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "realname_enabled": False,
                "data": {"realname_enabled": False},
            }
        )
        return True

    if path == "/gp/p10470/v2/bind":
        # bind() expects body.token when status == 200.
        now_ms = int(time.time() * 1000)
        token = hashlib.md5(f"bind:{host}:{now_ms}".encode("utf-8")).hexdigest()
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "token": token,
                "data": {"token": token},
            }
        )
        return True

    if path == "/gp/p10470/v2/query":
        # query() expects body.tokens when status == 200.
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "tokens": [],
                "data": {"tokens": []},
            }
        )
        return True

    if path == "/gp/p10470/v2/create_order":
        # create_order() expects body.order_id on success.
        order_id = f"LOCAL-{int(time.time() * 1000)}"
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "order_id": order_id,
                "data": {"order_id": order_id},
            }
        )
        return True

    if path == "/gp/p10470/v2/gen_uuid":
        # get_login_qrcode() expects body.code==0 and body.uuid.
        uuid = hashlib.md5(f"uuid:{host}:{time.time()}".encode("utf-8")).hexdigest()
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "uuid": uuid,
                "data": {"uuid": uuid},
            }
        )
        return True

    if path == "/gp/p10470/v2/validate_uuid":
        # validate_qrcode_uuid() expects body.code and may read body.status/body.login_data.
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "login_data": {},
                "data": {"login_data": {}},
            }
        )
        return True

    if path == "/gp/p10470/v2/grant_uuid_access":
        context['send_json'](
            {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                "data": {},
            }
        )
        return True



    if path in ("/gp/p10470/v2/acquire", "/gp/p10470/v2/login", "/gp/p10470/v2/global_acquire"):
        import services.gp
        resp = services.gp.generate_acquire_response(req_json, host, context)
        context['send_json'](resp)
        return True

    if path.startswith("/gp/p10470/v2/"):
        # Avoid hard failures (404) that make the client switch regions.
        context['send_json']({"code": 0, "status": 0, "ret": 0, "success": True, "msg": "ok", "data": {}})
        return True

    return False
