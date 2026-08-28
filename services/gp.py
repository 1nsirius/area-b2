import json
import os
from pathlib import Path
DIR = Path(__file__).resolve().parent.parent

import services.utils as utils
import services.holo
import time
import hashlib

def generate_token(vendor, pid, region_code) -> str:
    """Generates a pseudo-deterministic game token."""
    now_ms = int(time.time() * 1000)
    token_seed = f"{vendor}:{pid}:{region_code}:{now_ms}"
    return hashlib.md5(token_seed.encode("utf-8")).hexdigest()

def process_login(req, pid, vendor, platform, region_code) -> tuple[int, str]:
    """Business logic for login."""
    # Here we would normally validate signatures, DB records, etc.
    uid_num = int(pid) if pid.isdigit() else 0
    token = generate_token(vendor, pid, region_code)
    return uid_num, token


import time
import hashlib

def generate_acquire_response(req_json: dict, host: str, context: dict) -> dict:
    req = req_json
    # IMPORTANT: gangplank_v2_post() passes the whole JSON object to Lua,
    # and Lua reads fields at the top-level (body.token/body.pinfo/...).
    # So we must provide those keys at the root, not only under `data`.
    now_ms = int(time.time() * 1000)
    now = now_ms // 1000

    req = req_json

    # Values that the Lua handler frequently uses as table keys.
    platform = req.get("platform") or req.get("plat") or req.get("pf")
    with_type = req.get("with") or req.get("with_type")
    proj_code = req.get("projCode") or req.get("game") or "P10470"
    ptoken = req.get("ptoken") or req.get("token")

    pid_raw = req.get("pid") or req.get("player_id") or req.get("accountId") or req.get("account_id") or req.get("account") or req.get("user") or req.get("username")
    if pid_raw is None:
        pid_raw = "1000001"
    pid = str(pid_raw).strip() or "1000001"
    if not pid.isdigit():
        uid_num = db._get_or_create_uid_for_account(pid)
        pid = str(uid_num)
    else:
        uid_num = int(pid)

    account_id_raw = req.get("accountId") or req.get("account_id") or pid
    account_id = str(account_id_raw)

    vendor = req.get("vendor") or req.get("vendorId") or req.get("channel") or platform or "AGST"

    # Some Lua code treats channel/sub-channel as 1-based array indices.
    # Returning "0" tends to produce nil lookups and cascading crashes.
    channel_id = str(req.get("channelId") or req.get("channel_id") or "1")
    sub_channel_id = str(
        req.get("subCh")
        or req.get("sub_ch")
        or req.get("subChannelId")
        or req.get("sub_channel_id")
        or "1"
    )
    try:
        channel_id_num = int(channel_id)
    except Exception:
        channel_id_num = 1
    try:
        sub_channel_id_num = int(sub_channel_id)
    except Exception:
        sub_channel_id_num = 1

    region_code = utils._resolve_request_region(req, host, default="ustest")
    # Keep the response region consistent with the client's current config.
    # The SDK frequently uses `region` as a table key; returning "sg" while
    # the client has already switched to "sgtest" can cause nil lookups.

    # Area is typically a display/ISO-ish code (e.g., "SG") even when region
    # is a more specific environment code like "sgtest".
    area = req.get("area")
    if area is None or str(area).strip().lower().startswith("p10470"):
        if region_code in {"sg", "sgtest"}:
            area = "sg"
        elif region_code == "ustest":
            area = "us"
        else:
            area = region_code
    area = str(area).strip().lower()

    # Some Lua implementations treat `area` as an enum key and are case-sensitive.
    # In gangplank-config we advertise area as "SG", so return a matching uppercase
    # while keeping lowercase aliases to remain permissive.
    area_lc = area
    area_uc = area.upper()
    area = area_uc

    if platform is None:
        platform = vendor
    if with_type is None:
        with_type = "OFFICIAL"

    with_value = req.get("with")
    if with_value is None:
        with_value = with_type
    with_account = req.get("with_account") or req.get("withAccount") or req.get("withAccountId")
    if with_account is None:
        with_account = ptoken or account_id

    # Keep tokens deterministic-ish but obviously non-production.
    token_seed = f"{vendor}:{pid}:{region_code}:{now_ms}"
    token = hashlib.md5(token_seed.encode("utf-8")).hexdigest()

    guest = req.get("guest")
    if guest is None:
        guest = False
    is_create = req.get("is_create")
    if is_create is None:
        is_create = req.get("isCreate")
    if is_create is None:
        is_create = False

    # A lot of SDK/Lua variants expect at least one game server entry
    # and may use serverId as a table key (crashes if nil).
    server_id = str(req.get("serverId") or req.get("server_id") or "1")
    try:
        server_id_num = int(server_id)
    except Exception:
        server_id_num = 1
    if server_id_num <= 0:
        server_id_num = 1
        server_id = "1"
    sdk_server_name = utils._sanitize_display_name(
        req.get("server") or req.get("serverName") or req.get("server_name"),
        fallback=utils._sdk_server_name_for_region(region_code),
    )
    if not str(sdk_server_name).strip().lower().startswith("f2"):
        sdk_server_name = utils._sdk_server_name_for_region(region_code)

    raw_server_name = req.get("serverName") or req.get("server_name") or req.get("server")
    if raw_server_name is None:
        raw_server_name = sdk_server_name

    server_name = utils._sanitize_display_name(raw_server_name, fallback=str(sdk_server_name))
    # Some UI flows treat a numeric server name as a localized string id and
    # render it as "StringID:<n>" when the string table isn't loaded.
    # Prefer a non-numeric display name to keep the UI readable.
    if not server_name.strip() or server_name.strip() == "0" or server_name.strip().isdigit():
        server_name = str(sdk_server_name)

    # Some client scripts use `realm` (often an array) instead of ip/port fields.
    # IMPORTANT: 127.0.0.1 on the phone points to the phone itself.
    # Use this server's LAN IP to avoid relying on DNS for TCP.
    realm_host = context['realm_host_for_client']()
    realm = f"{realm_host}:{context['GAME_PORT']}"
    server_entry = {
        "serverId": server_id,
        "server_id": server_id,
        "serverID": server_id,
        "serverid": server_id,
        "sid": server_id,
        "sId": server_id,
        "zoneId": server_id,
        "zone_id": server_id,
        "zoneID": server_id,

        "serverIdNum": server_id_num,
        "server_id_num": server_id_num,
        "serverid_num": server_id_num,
        "sid_num": server_id_num,
        "zoneIdNum": server_id_num,
        "id": server_id,
        "serverName": server_name,
        "server_name": server_name,
        "serverNAME": server_name,
        "servername": server_name,
        "name": server_name,
        "sdkServerName": sdk_server_name,
        "sdk_server_name": sdk_server_name,
        # UI text fields: some builds show "<empty>" if these are missing/null.
        "desc": "Local server",
        "description": "Local server",
        "notice": "",
        "announcement": "",
        "region": region_code,
        "area": area,
        "area_code": area,
        "areaCode": area,
        "area_lc": area_lc,
        "areaLc": area_lc,
        # Different builds use different status/state conventions.
        # Provide multiple redundant keys so the client treats the server as ONLINE.
        # Some builds treat status/state==1 as maintenance.
        "status": 0,
        "state": 0,
        "server_status": 0,
        "serverState": 0,
        "open": True,
        "is_open": True,
        "online": True,
        "maintenance": 0,
        "maintain": 0,
        "is_maintain": False,
        "isMaintenance": False,
        "maint": False,
        "recommend": True,
        "host": realm_host,
        "ip": realm_host,
        "port": context['GAME_PORT'],
        "realm": [realm_host],
        "realms": [realm_host],
        "realm_addr": [realm],
        "realmAddr": [realm],
        "realm_str": realm,
        "realmStr": realm,
    }

    # pinfo is required by Lua: body.pinfo.pid / body.pinfo.with / body.pinfo.with_account
    # and some flows pass body.pinfo.attach_info into handlers.
    pinfo = {
        "pid": pid,
        "accountId": account_id,
        "account_id": account_id,
        "uid": uid_num,
        "token": token,
        "region": region_code,
        "area": area,
        "serverId": server_id,
        "serverName": server_name,
        "server_id": server_id,
        "server_name": server_name,
        "server": server_id,
        "with": with_value,
        "with_account": str(with_account),
        "ext": {"is_magic_guest": bool(guest)},
        "attach_info": {},
    }
    holo_token = services.holo.holo_player_token_payload(pid)

    # Lightweight debug to correlate client expectations.
    try:
        req_keys = ",".join(sorted(map(str, req.keys())))
    except Exception:
        req_keys = "(unavailable)"
    print(f"[ACQUIRE] host={host} region={region_code} area={area} projCode={proj_code} keys={req_keys}")

    lobby_hints = {
        "ip": realm_host,
        "host": realm_host,
        "port": context['GAME_PORT'],
        "ip_port": realm,
        "ipPort": realm,
        "realm": realm_host,
        "realms": [realm_host],
        "realm_addr": realm,
        "realmAddr": realm,
        "lobby_ip": realm_host,
        "lobby_host": realm_host,
        "lobby_port": context['GAME_PORT'],
        "lobby_ip_port": realm,
        "LobbyServerIpAddress": realm_host,
        "LobbyServerPort": context['GAME_PORT'],
    }

    resp = {
            "code": 0,
            "status": 0,
            "ret": 0,
            "success": True,
            "msg": "ok",
            # Top-level keys expected by ejoysdk_gangplank.lua
            "token": token,
            "uid": uid_num,
            "pinfo": pinfo,
            "reg": {},
            "moment_token": str(holo_token.get("moment_token") or ""),
            "key": str(holo_token.get("key") or ""),
            "expire_time": int(holo_token.get("expire_time") or 0),
            "data": {
                "guest": guest,
                "is_create": is_create,
                "isCreate": is_create,
                "pid": pid,
                "accountId": account_id,
                "account_id": account_id,
                "vendor": vendor,
                "platform": platform,
                "plat": platform,
                "type": platform,
                "with": with_type,
                "with_type": with_type,
                "region": region_code,
                "server_region": region_code,
                "serverRegion": region_code,
                "area": area,
                "area_code": area,
                "areaCode": area,
                "area_lc": area_lc,
                "areaLc": area_lc,
                "game": proj_code,
                "projCode": proj_code,
                "ptoken": ptoken,
                "login_type": platform,
                "auth_type": platform,
                "uid": uid_num,
                "pinfo": pinfo,
                "reg": {},
                "serverId": server_id,
                "server_id": server_id,
                "serverID": server_id,
                "serverid": server_id,
                "sid": server_id,
                "zoneId": server_id,
                "zone_id": server_id,

                "serverIdNum": server_id_num,
                "server_id_num": server_id_num,
                "serverid_num": server_id_num,
                "sid_num": server_id_num,
                "zoneIdNum": server_id_num,
                "serverName": server_name,
                "server_name": server_name,
                "servername": server_name,
                "serverNAME": server_name,
                "server": server_entry,
                "server_info": server_entry,
                "serverInfo": server_entry,
                "server_list": [server_entry],
                "serverList": [server_entry],
                "serverlist": [server_entry],
                # Some SDK variants expect `servers` to be an array (1-based indexing).
                # Keep both representations to avoid nil lookups that can cascade into
                # "table index is nil".
                "servers": [server_entry],
                "servers_map": {server_id: server_entry},
                "serversMap": {server_id: server_entry},
                "servers_by_id": {server_id: server_entry},
                "server_map": {server_id: server_entry},
                "area_list": [
                    {
                        "area": area,
                        "region": region_code,
                        "name": area.upper(),
                        "default": True,
                    }
                ],
                "player_info": {
                    "pid": pid,
                    "accountId": account_id,
                    "region": region_code,
                    "area": area,
                    "channelId": channel_id,
                    "channel_id": channel_id,
                    "channelIdNum": channel_id_num,
                    "channel_id_num": channel_id_num,
                    "subCh": sub_channel_id,
                    "sub_ch": sub_channel_id,
                    "subChannelId": sub_channel_id,
                    "sub_channel_id": sub_channel_id,
                    "subChNum": sub_channel_id_num,
                    "sub_ch_num": sub_channel_id_num,
                    "subChannelIdNum": sub_channel_id_num,
                    "sub_channel_id_num": sub_channel_id_num,
                    "area_code": area,
                    "areaCode": area,
                    "area_lc": area_lc,
                    "areaLc": area_lc,
                    "serverId": server_id,
                    "serverName": server_name,
                    "server_id": server_id,
                    "server_name": server_name,
                    "serverid": server_id,
                    "servername": server_name,
                    "sid": server_id,
                    "sId": server_id,
                    "sid_num": int(server_id),
                    "serverIdNum": int(server_id),
                    "server_id_num": int(server_id),
                    "serverid_num": int(server_id),
                    "zoneId": server_id,
                    "zoneID": server_id,
                    "zone_id": server_id,
                    "zoneIdNum": int(server_id),
                    "roleId": "0",
                    "roleName": "",
                    "roleLevel": 1,
                },
                "playerInfo": {
                    "pid": pid,
                    "accountId": account_id,
                    "region": region_code,
                    "area": area,
                    "channelId": channel_id,
                    "channel_id": channel_id,
                    "channelIdNum": channel_id_num,
                    "channel_id_num": channel_id_num,
                    "subCh": sub_channel_id,
                    "sub_ch": sub_channel_id,
                    "subChannelId": sub_channel_id,
                    "sub_channel_id": sub_channel_id,
                    "subChNum": sub_channel_id_num,
                    "sub_ch_num": sub_channel_id_num,
                    "subChannelIdNum": sub_channel_id_num,
                    "sub_channel_id_num": sub_channel_id_num,
                    "area_code": area,
                    "areaCode": area,
                    "area_lc": area_lc,
                    "areaLc": area_lc,
                    "serverId": server_id,
                    "serverName": server_name,
                    "server_id": server_id,
                    "server_name": server_name,
                    "serverid": server_id,
                    "servername": server_name,
                    "sid": server_id,
                    "sId": server_id,
                    "sid_num": int(server_id),
                    "serverIdNum": int(server_id),
                    "server_id_num": int(server_id),
                    "serverid_num": int(server_id),
                    "zoneId": server_id,
                    "zoneID": server_id,
                    "zone_id": server_id,
                    "zoneIdNum": int(server_id),
                    "roleId": "0",
                    "roleName": "",
                    "roleLevel": 1,
                },
                "login_info": {
                    "platform": platform,
                    "plat": platform,
                    "pf": platform,
                    "vendor": vendor,
                    "vendorId": vendor,
                    "channelId": channel_id,
                    "channel_id": channel_id,
                    "channelIdNum": channel_id_num,
                    "channel_id_num": channel_id_num,
                    "subCh": sub_channel_id,
                    "sub_ch": sub_channel_id,
                    "subChannelId": sub_channel_id,
                    "sub_channel_id": sub_channel_id,
                    "subChNum": sub_channel_id_num,
                    "sub_ch_num": sub_channel_id_num,
                    "subChannelIdNum": sub_channel_id_num,
                    "sub_channel_id_num": sub_channel_id_num,
                    "type": "acquire",
                    "login_type": platform,
                    "loginType": platform,
                    "auth_type": platform,
                    "authType": platform,
                    "with": with_type,
                    "region": region_code,
                    "area": area,
                    "area_code": area,
                    "areaCode": area,
                    "area_lc": area_lc,
                    "areaLc": area_lc,
                    "game": proj_code,
                    "pid": pid,
                    "accountId": account_id,
                    "ptoken": ptoken,
                    "token": token,
                    "serverId": server_id,
                    "serverName": server_name,
                    "server_id": server_id,
                    "server_name": server_name,
                    "serverid": server_id,
                    "servername": server_name,
                    "sid": server_id,
                    "sId": server_id,
                    "sid_num": int(server_id),
                    "serverIdNum": int(server_id),
                    "server_id_num": int(server_id),
                    "serverid_num": int(server_id),
                    "zoneId": server_id,
                    "zoneID": server_id,
                    "zone_id": server_id,
                    "zoneIdNum": int(server_id),
                },
                "loginInfo": {
                    "platform": platform,
                    "plat": platform,
                    "pf": platform,
                    "vendor": vendor,
                    "vendorId": vendor,
                    "channelId": channel_id,
                    "channel_id": channel_id,
                    "channelIdNum": channel_id_num,
                    "channel_id_num": channel_id_num,
                    "subCh": sub_channel_id,
                    "sub_ch": sub_channel_id,
                    "subChannelId": sub_channel_id,
                    "sub_channel_id": sub_channel_id,
                    "subChNum": sub_channel_id_num,
                    "sub_ch_num": sub_channel_id_num,
                    "subChannelIdNum": sub_channel_id_num,
                    "sub_channel_id_num": sub_channel_id_num,
                    "type": "acquire",
                    "login_type": platform,
                    "loginType": platform,
                    "auth_type": platform,
                    "authType": platform,
                    "with": with_type,
                    "region": region_code,
                    "area": area,
                    "area_code": area,
                    "areaCode": area,
                    "area_lc": area_lc,
                    "areaLc": area_lc,
                    "game": proj_code,
                    "pid": pid,
                    "accountId": account_id,
                    "ptoken": ptoken,
                    "token": token,
                    "serverId": server_id,
                    "serverName": server_name,
                    "server_id": server_id,
                    "server_name": server_name,
                    "serverid": server_id,
                    "servername": server_name,
                    "sid": server_id,
                    "sId": server_id,
                    "sid_num": int(server_id),
                    "serverIdNum": int(server_id),
                    "server_id_num": int(server_id),
                    "serverid_num": int(server_id),
                    "zoneId": server_id,
                    "zoneID": server_id,
                    "zone_id": server_id,
                    "zoneIdNum": int(server_id),
                },
                "token": token,
                "moment_token": str(holo_token.get("moment_token") or ""),
                "key": str(holo_token.get("key") or ""),
                "expire_time": int(holo_token.get("expire_time") or 0),
                "access_token": token,
                "session": token,
                "channelId": channel_id,
                "channel_id": channel_id,
                "channelIdNum": channel_id_num,
                "channel_id_num": channel_id_num,
                "subCh": sub_channel_id,
                "sub_ch": sub_channel_id,
                "subChannelId": sub_channel_id,
                "sub_channel_id": sub_channel_id,
                "subChNum": sub_channel_id_num,
                "sub_ch_num": sub_channel_id_num,
                "subChannelIdNum": sub_channel_id_num,
                "sub_channel_id_num": sub_channel_id_num,
                "server_time_ms": now_ms,
                "serverTimeMs": now_ms,
                "server_time": now,
                "serverTime": now,
                "time": now,
                # Common placeholders seen across similar SDKs.
                "uid": uid_num,
                "ucid": str(account_id),
            },
            "server_time_ms": now_ms,
            "server_time": now,

        }

    # Add redundant lobby endpoint hints at both top-level and inside `data`.
    # Some IL2CPP/Lua variants read these keys directly (without going through
    # the nested server list structures).
    try:
        resp.update(lobby_hints)
        if isinstance(resp.get("data"), dict):
            resp["data"].update(lobby_hints)
    except Exception:
        pass

    resp = utils._ensure_auth_contract(resp, "acquire", realm_host, context['GAME_PORT'])

    # Persist the full response locally for debugging.
    # logcat truncates long JSON strings, so fields like `data.servers`
    # may not be visible on-device even when they are present.
    try:
        dump_path = DIR / "last_acquire_response.json"
        dump_path.write_text(json.dumps(resp, ensure_ascii=False, indent=2), encoding="utf-8")
        servers_val = resp.get("data", {}).get("servers")
        servers_type = type(servers_val).__name__
        servers_len = len(servers_val) if isinstance(servers_val, list) else None
        print(f"[ACQUIRE] wrote {dump_path.name} (servers type={servers_type} len={servers_len})")
    except Exception as e:
        import traceback; traceback.print_exc()
        print(f"[ACQUIRE] dump failed: {e}")

    context['gp_bind_token_player'](token, pid)
    context['local_pd'] = globals().get("_player_data")
    context['online_ensure_profile'](pid, local_pd=context.get('local_pd') if isinstance(context.get('local_pd'), dict) else None)
    context['send_json'](resp)
    return



def generate_login_response(req_json: dict, host: str, context: dict) -> dict:
    req = req_json
    # Lua expects: body.token/body.uid/body.pinfo/body.server_secret/body.game_token
    now_ms = int(time.time() * 1000)
    now = now_ms // 1000

    req = req_json

    platform = req.get("platform") or req.get("plat") or req.get("pf")
    with_type = req.get("with") or req.get("with_type")
    proj_code = req.get("projCode") or req.get("game") or "P10470"
    ptoken = req.get("ptoken") or req.get("token")

    pid_raw = req.get("pid") or req.get("player_id") or req.get("accountId") or req.get("account_id")
    if pid_raw is None:
        pid_raw = "1000001"
    pid = str(pid_raw)
    uid_num = utils._safe_int(pid, 0)

    account_id_raw = req.get("accountId") or req.get("account_id") or pid
    account_id = str(account_id_raw)

    vendor = req.get("vendor") or req.get("vendorId") or req.get("channel") or platform or "AGST"

    host_region = utils._infer_region_from_host(host)
    region_code = utils._resolve_request_region(req, host, default="ustest")

    area = req.get("area")
    if area is None or str(area).strip().lower().startswith("p10470"):
        if region_code in {"sg", "sgtest"}:
            area = "sg"
        elif region_code == "ustest":
            area = "us"
        else:
            area = region_code
    area = str(area).strip().lower()
    area_uc = area.upper()
    area = area_uc

    if platform is None:
        platform = vendor
    if with_type is None:
        with_type = "OFFICIAL"
    with_value = req.get("with")
    if with_value is None:
        with_value = with_type
    with_account = req.get("with_account") or req.get("withAccount") or req.get("withAccountId")
    if with_account is None:
        with_account = ptoken or account_id

    token_in = req.get("token")
    if isinstance(token_in, str) and token_in:
        token = token_in
    else:
        token_seed = f"{vendor}:{pid}:{region_code}:{now_ms}"
        token = hashlib.md5(token_seed.encode("utf-8")).hexdigest()

    guest = req.get("guest")
    if guest is None:
        guest = False

    server_id = str(req.get("serverId") or req.get("server_id") or "1")
    try:
        if int(server_id) <= 0:
            server_id = "1"
    except Exception:
        server_id = "1"
    raw_server_name = req.get("serverName") or req.get("server_name")
    raw_server = req.get("server")
    if raw_server_name is None and raw_server:
        raw_server_name = raw_server
    sdk_server_name = utils._sanitize_display_name(
        raw_server or raw_server_name,
        fallback=utils._sdk_server_name_for_region(region_code),
    )
    if not str(sdk_server_name).strip().lower().startswith("f2"):
        sdk_server_name = utils._sdk_server_name_for_region(region_code)
    server_name = utils._sanitize_display_name(raw_server_name, fallback=str(sdk_server_name))

    raw_region = req.get("region") or req.get("area") or host_region
    utils._append_utf8_log(
        "[SDK_LOGIN] "
        f"server={str(raw_server or '').strip()!r} "
        f"serverName={str(raw_server_name or '').strip()!r} "
        f"serverId={str(req.get('serverId') or req.get('server_id') or '')!r} "
        f"region={str(raw_region or '').strip()!r} "
        f"resolved_region={region_code!r} resolved_area={area!r}"
    )

    req_secret = req.get("secret")
    if not isinstance(req_secret, str) or not req_secret:
        req_secret = "AA=="  # base64 for 0x00

    pinfo = {
        "pid": pid,
        "accountId": account_id,
        "account_id": account_id,
        "uid": uid_num,
        "token": token,
        "region": region_code,
        "area": area,
        "serverId": server_id,
        "serverName": server_name,
        "server_id": server_id,
        "server_name": server_name,
        "server": server_id,
        "with": with_value,
        "with_account": str(with_account),
        "ext": {"is_magic_guest": bool(guest)},
        "attach_info": {},
    }
    holo_token = services.holo.holo_player_token_payload(pid)

    resp = {
        "code": 0,
        "status": 0,
        "ret": 0,
        "success": True,
        "msg": "ok",
        "token": token,
        "uid": uid_num,
        "pinfo": pinfo,
        "moment_token": str(holo_token.get("moment_token") or ""),
        "key": str(holo_token.get("key") or ""),
        "expire_time": int(holo_token.get("expire_time") or 0),
        # We don't implement DH on the server; echoing client's exchange value
        # keeps client-side base64decode + dhsecret happy and deterministic.
        "server_secret": req_secret,
        "game_token": f"game-{token}",
        "data": {
            "token": token,
            "uid": uid_num,
            "pinfo": pinfo,
            "moment_token": str(holo_token.get("moment_token") or ""),
            "key": str(holo_token.get("key") or ""),
            "expire_time": int(holo_token.get("expire_time") or 0),
            "server_secret": req_secret,
            "game_token": f"game-{token}",
            "server_time_ms": now_ms,
            "server_time": now,
            "time": now,
            "region": region_code,
            "area": area,
            "game": proj_code,
            "projCode": proj_code,
            "ptoken": ptoken,
            "platform": platform,
            "vendor": vendor,
        },
        "server_time_ms": now_ms,
        "server_time": now,
        "time": now,
    }

    realm_host = context['realm_host_for_client']()
    realm = f"{realm_host}:{context['GAME_PORT']}"
    server_entry = utils._default_server_entry(realm_host, context['GAME_PORT'], region_code)
    server_entry["serverName"] = server_name
    server_entry["server_name"] = server_name
    server_entry["name"] = server_name
    server_entry["sdkServerName"] = sdk_server_name
    server_entry["sdk_server_name"] = sdk_server_name

    if isinstance(resp.get("data"), dict):
        resp["data"]["server"] = server_entry
        resp["data"]["server_info"] = server_entry
        resp["data"]["serverInfo"] = server_entry
        resp["data"]["server_list"] = [server_entry]
        resp["data"]["serverList"] = [server_entry]
        resp["data"]["servers"] = [server_entry]

    lobby_hints = {
        "ip": realm_host,
        "host": realm_host,
        "port": context['GAME_PORT'],
        "ip_port": realm,
        "ipPort": realm,
        "realm": realm_host,
        "realms": [realm_host],
        "realm_addr": realm,
        "realmAddr": realm,
        "lobby_ip": realm_host,
        "lobby_host": realm_host,
        "lobby_port": context['GAME_PORT'],
        "lobby_ip_port": realm,
        "LobbyServerIpAddress": realm_host,
        "LobbyServerPort": context['GAME_PORT'],
    }
    try:
        resp.update(lobby_hints)
        if isinstance(resp.get("data"), dict):
            resp["data"].update(lobby_hints)
    except Exception:
        pass

    resp = utils._ensure_auth_contract(resp, "login", realm_host, context['GAME_PORT'])

    context['gp_bind_token_player'](token, pid)
    context['local_pd'] = globals().get("_player_data")
    context['online_ensure_profile'](pid, local_pd=context.get('local_pd') if isinstance(context.get('local_pd'), dict) else None)
    context['send_json'](resp)
    return



def generate_queue_response(req_json: dict, host: str, context: dict) -> dict:
    req = req_json
    now_ms = int(time.time() * 1000)
    # Queue loop expects body.game_token/body.server_secret on 200.
    token = hashlib.md5(f"queue:{host}:{now_ms}".encode("utf-8")).hexdigest()
    context['send_json'](
        {
            "code": 0,
            "status": 0,
            "ret": 0,
            "success": True,
            "msg": "ok",
            "queue": 0,
            "ticket": "",
            "server_secret": "AA==",
            "game_token": f"game-{token}",
            "data": {
                "queue": 0,
                "ticket": "",
                "server_secret": "AA==",
                "game_token": f"game-{token}",
            },
        }
    )
    return

