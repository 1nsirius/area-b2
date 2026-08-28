import os
import json
import time
from pathlib import Path

DIR = Path(__file__).resolve().parent.parent
import re
import log_system
_log_file_path = DIR / "artifacts" / "server_requests.log"
_server_logger = log_system.setup_logger("areaf2_server", _log_file_path)



# Decodes json body directly if needed
def _decode_req_json(body: bytes) -> dict:
    if not body:
        return {}
    try:
        parsed = json.loads(body.decode("utf-8", errors="replace"))
        return parsed if isinstance(parsed, dict) else {}
    except Exception:
        return {}

def _sanitize_display_name(val: object, fallback: str = "Local") -> str:
    """Avoid numeric-only names that Unity/Lua may render as StringID:<n>."""
    try:
        s = str(val)
    except Exception:
        return fallback
    s = s.strip()
    if not s or s == "0" or s.isdigit():
        return fallback
    compact = re.sub(r"[\s_\-]+", "", s).lower()
    # Some placeholder names arrive as repeated NAME blocks (e.g. NAMENAMENAME).
    if re.fullmatch(r"(?:name){2,}", compact):
        return fallback
    return s


def _normalize_server_entries(raw_servers: object, realm_host: str, game_port: int, region_code: str | None = None) -> tuple[list[dict], list[str]]:
    default_entry = _default_server_entry(realm_host, game_port, region_code)
    servers_in = raw_servers if isinstance(raw_servers, list) else []
    repairs: list[str] = []
    out: list[dict] = []

    for raw in servers_in:
        if not isinstance(raw, dict):
            repairs.append("drop_non_dict_server")
        entry = dict(default_entry)
        entry.update(raw)

        server_name = _sanitize_display_name(
            entry.get("serverName") or entry.get("server_name") or entry.get("name"),
            fallback="Local",
        )
        if entry.get("serverName") != server_name or entry.get("server_name") != server_name:
            repairs.append("normalize_server_name")
        entry["serverName"] = server_name
        entry["server_name"] = server_name
        entry["name"] = server_name

        sdk_server_name = entry.get("sdkServerName") or entry.get("sdk_server_name")
        if not sdk_server_name:
            sdk_server_name = _sdk_server_name_for_region(region_code)
            repairs.append("inject_sdkServerName")
        entry["sdkServerName"] = sdk_server_name
        entry["sdk_server_name"] = sdk_server_name

        server_id = str(entry.get("serverId") or entry.get("server_id") or entry.get("id") or "1")
        if server_id != str(entry.get("serverId")):
            repairs.append("normalize_server_id")
        entry["id"] = server_id
        entry["serverId"] = server_id
        entry["server_id"] = server_id
        entry["sid"] = server_id
        entry["zoneId"] = server_id

        try:
            entry["port"] = int(entry.get("port") or game_port)
        except Exception:
            entry["port"] = int(game_port)
            repairs.append("normalize_port")

        realm = f"{realm_host}:{int(game_port)}"
        if not isinstance(entry.get("realm"), list) or not entry.get("realm"):
            entry["realm"] = [realm_host]
            repairs.append("normalize_realm")
        if not isinstance(entry.get("realms"), list) or not entry.get("realms"):
            entry["realms"] = [realm_host]
            repairs.append("normalize_realms")
        if not isinstance(entry.get("realm_addr"), list) or not entry.get("realm_addr"):
            entry["realm_addr"] = [realm]
            repairs.append("normalize_realm_addr")
        if not isinstance(entry.get("realmAddr"), list) or not entry.get("realmAddr"):
            entry["realmAddr"] = [realm]
            repairs.append("normalize_realmAddr")

        out.append(entry)

    if not out:
        out = [default_entry]
        repairs.append("inject_default_server")

    return out, repairs


def _ensure_auth_contract(resp: dict, endpoint: str, realm_host: str, game_port: int) -> dict:
    if not isinstance(resp, dict):
        resp = {}
    data = resp.get("data")
    if not isinstance(data, dict):
        data = {}
        resp["data"] = data

    repairs: list[str] = []

    pinfo = resp.get("pinfo")
    if not isinstance(pinfo, dict):
        pinfo = data.get("pinfo")
    if not isinstance(pinfo, dict):
        pinfo = {}
        repairs.append("inject_pinfo")
    resp["pinfo"] = pinfo
    data["pinfo"] = pinfo

    region = (
        str(resp.get("region") or data.get("region") or pinfo.get("region") or "sg")
        .strip()
        .lower()
        or "sg"
    )
    area = (
        str(resp.get("area") or data.get("area") or pinfo.get("area") or ("sg" if region in {"sg", "sgtest"} else region))
        .strip()
        .upper()
    )
    server_id = str(resp.get("serverId") or data.get("serverId") or pinfo.get("serverId") or "1")
    server_name = _sanitize_display_name(
        resp.get("serverName") or data.get("serverName") or pinfo.get("serverName"),
        fallback="Local",
    )

    raw_servers = None
    for cand in (
        data.get("servers"),
        data.get("server_list"),
        data.get("serverList"),
        resp.get("servers"),
    ):
        if isinstance(cand, list):
            raw_servers = cand
            break
    if raw_servers is None and isinstance(data.get("server"), dict):
        raw_servers = [data.get("server")]

    servers, server_repairs = _normalize_server_entries(raw_servers, realm_host, game_port, region)
    repairs.extend(server_repairs)

    data["servers"] = servers
    data["server_list"] = servers
    data["serverList"] = servers
    data["server"] = servers[0]
    resp["servers"] = servers

    for target in (resp, data, pinfo):
        target["region"] = region
        target["area"] = area
        target["serverId"] = server_id
        target["server_id"] = server_id
        target["serverName"] = server_name
        target["server_name"] = server_name

    player_info = data.get("player_info")
    if not isinstance(player_info, dict):
        player_info = {}
        repairs.append("inject_player_info")
    player_info.update(
        {
            "region": region,
            "area": area,
            "serverId": server_id,
            "serverName": server_name,
            "server_id": server_id,
            "server_name": server_name,
        }
    )
    data["player_info"] = player_info
    data["playerInfo"] = player_info

    if repairs:
        uniq = ",".join(sorted(set(repairs)))
        _append_utf8_log(f"[CONTRACT] {endpoint} repaired={uniq}")
    _log_contract_snapshot(endpoint, resp)
    return resp


def _ensure_alive_servers_contract(resp: dict, realm_host: str, game_port: int, region_code: str | None = None) -> dict:
    if not isinstance(resp, dict):
        resp = {}
    data = resp.get("data")
    if not isinstance(data, dict):
        data = {}
        resp["data"] = data

    raw_servers = resp.get("servers")
    if not isinstance(raw_servers, list):
        raw_servers = data.get("servers")

    servers, repairs = _normalize_server_entries(raw_servers, realm_host, game_port, region_code)
    resp["servers"] = servers
    data["servers"] = servers

    if repairs:
        uniq = ",".join(sorted(set(repairs)))
        _append_utf8_log(f"[CONTRACT] alive_servers repaired={uniq}")
    _log_contract_snapshot("alive_servers", resp)
    return resp


def _default_server_entry(realm_host: str, game_port: int, region_code: str | None = None) -> dict:
    region = str(region_code or "sg").strip().lower() or "sg"
    area = "SG" if region in {"sg", "sgtest"} else region.upper()
    realm = f"{realm_host}:{int(game_port)}"
    sdk_server_name = _sdk_server_name_for_region(region)
    return {
        "id": "1",
        "serverId": "1",
        "server_id": "1",
        "sid": "1",
        "zoneId": "1",
        "name": "Local",
        "serverName": "Local",
        "server_name": "Local",
        "sdkServerName": sdk_server_name,
        "sdk_server_name": sdk_server_name,
        "desc": "Local server",
        "description": "Local server",
        "notice": "",
        "announcement": "",
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
        "region": region,
        "area": area,
        "host": realm_host,
        "ip": realm_host,
        "port": int(game_port),
        "realm": [realm_host],
        "realms": [realm_host],
        "realm_addr": [realm],
        "realmAddr": [realm],
    }


def _uid_str(value: object, fallback: str = "1000001") -> str:
    uid = str(value or "").strip()
    if uid:
        return uid
    return fallback


def _safe_int(value: object, default: int = 0) -> int:
    try:
        return int(value)
    except Exception:
        return default


def _append_utf8_log(line: str):
    _server_logger.info(line)


def _env_truthy(name: str, default: str = "0") -> bool:
    val = (os.environ.get(name, default) or default).strip().lower()
    return val in {"1", "true", "yes", "on"}


def _canonical_region_code(region_code: str | None, fallback: str | None = None) -> str:
    """Normalize legacy aliases into canonical region ids used by backend contracts."""
    region = str(region_code or "").strip().lower()
    aliases = {
        "sg": "sgtest",
        "us": "ustest",
        "na": "ustest",
        "us2test": "ustest",
        "us-test": "ustest",
        "us_test": "ustest",
        "brazil": "br",
        "brasil": "br",
    }
    region = aliases.get(region, region)
    if region:
        return region
    return str(fallback or "").strip().lower()


def _no_cache_headers(extra: dict[str, str] | None = None) -> dict[str, str]:
    h = {
        "Cache-Control": "no-store, no-cache, must-revalidate, max-age=0",
        "Pragma": "no-cache",
        "Expires": "0",
    }
    if extra:
        h.update(extra)
    return h


def _log_contract_snapshot(endpoint: str, payload: dict):
    data = payload.get("data") if isinstance(payload.get("data"), dict) else {}
    pinfo = payload.get("pinfo") if isinstance(payload.get("pinfo"), dict) else {}
    servers = payload.get("servers")
    if not isinstance(servers, list):
        servers = data.get("servers")
    if not isinstance(servers, list):
        servers = []

    region = (
        payload.get("region")
        or data.get("region")
        or pinfo.get("region")
        or "-"
    )
    server_id = (
        payload.get("serverId")
        or data.get("serverId")
        or pinfo.get("serverId")
        or "-"
    )
    _append_utf8_log(
        f"[CONTRACT] {endpoint} region={region} serverId={server_id} servers={len(servers)}"
    )


def _sdk_server_name_for_region(region_code: str | None) -> str:
    override = (os.environ.get("SDK_SERVER_NAME") or "").strip()
    if override:
        return override
    rc = (region_code or "").strip().lower()
    if not rc:
        return "Local"
    known = {
        "br": "f2br",
        "us": "f2us",
        "de": "f2de",
        "sg": "f2sg",
        "hk": "f2hk",
        "ustest": "f2ustest",
        "sgtest": "f2sgtest",
    }
    if rc in known:
        return known[rc]
    if rc.startswith("f2"):
        return rc
    return f"f2{rc}"


def _infer_region_from_host(host: str) -> str | None:
    """Infer region like 'sg'/'br' from hostnames such as 'p10470-br-gangplank.ejoy.com'."""
    host = (host or "").strip().lower()
    m = re.match(r"^p10470-([a-z0-9]+)-", host)
    if not m:
        return None
    return m.group(1)


def _resolve_request_region(req: dict | None, host: str, *, default: str = "ustest") -> str:
    """Resolve region from request body hints without trusting project-code placeholders."""
    req = req if isinstance(req, dict) else {}

    raw_region = str(req.get("region") or req.get("area") or "").strip().lower()
    if raw_region.startswith("p10470"):
        raw_region = ""

    pkg_region = ""
    pkg_info = req.get("pkg_info")
    if isinstance(pkg_info, dict):
        pkg_region = str(pkg_info.get("region") or pkg_info.get("area") or "").strip().lower()

    sdk_region = _infer_region_from_sdk_server_name(
        req.get("server") or req.get("serverName") or req.get("server_name")
    )
    host_region = _infer_region_from_host(host)

    for candidate in (
        raw_region,
        pkg_region,
        str(sdk_region or "").strip().lower(),
        str(host_region or "").strip().lower(),
        str(default or "").strip().lower(),
    ):
        if not candidate:
            continue
        normalized = _canonical_region_code(candidate, "")
        if normalized in {"sgtest", "ustest", "br"}:
            return normalized

    return _canonical_region_code(default, "ustest") or "ustest"



def _infer_region_from_sdk_server_name(server_name: object) -> str | None:
    """Best-effort region extraction from SDK server tokens like f2ustest."""
    token = str(server_name or "").strip().lower()
    if not token:
        return None
    if token.startswith("f2"):
        token = token[2:]
    if not re.match(r"^[a-z][a-z0-9_-]*$", token):
        return None
    norm = _canonical_region_code(token, "")
    if norm in {"sgtest", "ustest", "br"}:
        return norm
    return None


