import os
import base64
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives.padding import PKCS7

def aes_cbc_pkcs7_encrypt_b64(key: bytes, plaintext: bytes) -> str:
    padder = PKCS7(128).padder()
    padded = padder.update(plaintext) + padder.finalize()
    encryptor = Cipher(algorithms.AES(key), modes.CBC(key)).encryptor()
    ct = encryptor.update(padded) + encryptor.finalize()
    return base64.b64encode(ct).decode("ascii")

def handle_vanguard(path: str, context: dict) -> bool:
    """Vanguard Security SDK endpoints."""
    # gamesec security module expects *HTTP response headers*:
    # - /init: header `token` must be non-empty (used to derive AES key1)
    # - other calls: header `ek` (encrypted key2) may be used to decrypt body
    token = context['vanguard_token']()
    headers: dict[str, str] = {
        "token": token,
        "Token": token,
        "TOKEN": token,
        "x-token": token,
    }

    # IMPORTANT:
    # This build expects `ek` to be present and decryptable; if `ek` is
    # missing/empty it can crash with `IllegalArgumentException: Empty key`.
    # So we default to encrypted headers/key exchange unless explicitly disabled.
    encrypted_mode = (os.environ.get("VANGUARD_ENCRYPTED") or "1").strip() in {"1", "true", "yes"}

    # Response body mode is decoupled from header/key exchange for compatibility tests.
    # Values:
    # - plain/plaintext/json: send plaintext JSON body
    # - encrypted/enc/aes: send AES-encrypted base64 body
    # - auto/same (default): follow VANGUARD_ENCRYPTED
    response_mode = (os.environ.get("VANGUARD_RESPONSE_MODE") or "auto").strip().lower()
    response_encrypted = response_mode in {"encrypted", "enc", "aes", "cipher"}
    if response_mode in {"auto", "same"}:
        response_encrypted = encrypted_mode

    try:
        print(
            f"[VANGUARD] path={path} encrypted_headers={encrypted_mode} "
            f"response_mode={response_mode} response_encrypted={response_encrypted}"
        )
    except Exception:
        pass

    # Pre-compute ek (encrypted key2) early so /init can include it too.
    # Some builds crash with `IllegalArgumentException: Empty key` when ek is
    # missing/empty even on /init.
    key2_plain: bytes | None = None
    ek: str | None = None
    if encrypted_mode and _HAS_CRYPTO:
        key1 = context['vanguard_key1'](token)
        key2_plain = b"0123456789abcdef"  # 16 bytes
        ek = aes_cbc_pkcs7_encrypt_b64(key1, key2_plain)
        # Be extra permissive with header casing.
        headers["ek"] = ek
        headers["EK"] = ek
        headers["Ek"] = ek
        headers["eK"] = ek

    # /init is primarily for provisioning token; body can be minimal.
    if path == "/init":
        context['append_utf8_log'](f"[VANGUARD_RESP] path=/init token=yes ek={'yes' if ek else 'no'}")
        context['send_body'](b"{}", status=200, content_type="application/json; charset=utf-8", extra_headers=headers)
        return True

    # Security SDK queries these keys immediately after /config|/load|/collect;
    # keep them non-null to avoid binder/parcel null-string failures.
    query = parse_qs(urlparse(path).query or "")
    requested_region = context['canonical_region_code']((query.get("region") or [""])[0])
    region_mode = (os.environ.get("VANGUARD_REGION_MODE") or "request").strip().lower()
    if region_mode in {"force_br", "br"}:
        req_region = "br"
    else:
        req_region = requested_region or context['canonical_region_code'](os.environ.get("DEFAULT_REGION"), "ustest")

    req_region = context['canonical_region_code'](req_region, "ustest")
    if req_region not in {"sgtest", "ustest", "br"}:
        req_region = "ustest"

    def _area_for_region(region_code: str) -> str:
        return "SG" if region_code == "sgtest" else ("US" if region_code == "ustest" else "BR")

    def _build_player_info(region_code: str) -> dict:
        return {
            "pid": "1000001",
            "player_id": "1000001",
            "playerId": "1000001",
            "userid": "1000001",
            "userId": "1000001",
            "server_id": "1",
            "serverId": "1",
            "serverid": "1",
            "server_name": "Local",
            "serverName": "Local",
            "region": region_code,
            "area": _area_for_region(region_code),
            "roleLevel": 1,
            "level": 1,
        }

    vanguard_player_infos = {
        "sgtest": _build_player_info("sgtest"),
        "ustest": _build_player_info("ustest"),
        "br": _build_player_info("br"),
    }
    vanguard_player_infos["sg"] = vanguard_player_infos["sgtest"]
    vanguard_player_infos["us"] = vanguard_player_infos["ustest"]
    vanguard_player_infos["na"] = vanguard_player_infos["ustest"]
    vanguard_player_infos["us2test"] = vanguard_player_infos["ustest"]

    vanguard_player_info = dict(vanguard_player_infos[req_region])

    try:
        vanguard_ret_code = int((os.environ.get("VANGUARD_RET_CODE") or "2000").strip() or "2000")
    except Exception:
        vanguard_ret_code = 2000
    try:
        vanguard_all_switch = int((os.environ.get("VANGUARD_ALL_SWITCH") or "1").strip() or "1")
    except Exception:
        vanguard_all_switch = 1
    try:
        vanguard_upload_switch = int((os.environ.get("VANGUARD_UPLOAD_SWITCH") or "1").strip() or "1")
    except Exception:
        vanguard_upload_switch = 1
    try:
        vanguard_upload_interval = int((os.environ.get("VANGUARD_UPLOAD_INTERVAL") or "1800").strip() or "1800")
    except Exception:
        vanguard_upload_interval = 1800

    # gamesec/HttpCallForSecurity stores this JSON and reads these keys later:
    # - retCode must be 2000/2001 for config-accept path
    # - allSwitch/uploadSwitch/uploadInterval gate runtime security behavior
    payload = {
        "retCode": vanguard_ret_code,
        "retcode": vanguard_ret_code,
        "code": vanguard_ret_code,
        "ret": vanguard_ret_code,
        "status": 200,
        "success": True,
        "result": 0,
        "msg": "ok",
        "allSwitch": vanguard_all_switch,
        "uploadSwitch": vanguard_upload_switch,
        "uploadInterval": vanguard_upload_interval,
        "bRequestConfig": 1,
        "requestConfig": 1,
        "b_request_config": 1,
        "request_config": 1,
        "endpoint": "https://p10470-ustest-log-collector.ejoy.com",
        "bucket": "f2ustest-local",
        "stsServer": "https://p10470-ustest-log-collector.ejoy.com",
        "stsCallbackServer": "https://p10470-ustest-log-collector.ejoy.com/log/gbi_log",
        "path": "/log/gbi_log",
        "region": req_region,
        "serverid": "1",
        "serverId": "1",
        "userid": "1000001",
        "userId": "1000001",
        "channelId": "998236",
        "subCh": "1",
        "subChannelId": "1",
        "player_info": vanguard_player_info,
        "playerInfo": vanguard_player_info,
        "player_infos": vanguard_player_infos,
        "playerInfos": vanguard_player_infos,
        "data": {
            "region": req_region,
            "retCode": vanguard_ret_code,
            "retcode": vanguard_ret_code,
            "code": vanguard_ret_code,
            "ret": vanguard_ret_code,
            "status": 200,
            "allSwitch": vanguard_all_switch,
            "uploadSwitch": vanguard_upload_switch,
            "uploadInterval": vanguard_upload_interval,
            "bRequestConfig": 1,
            "requestConfig": 1,
            "b_request_config": 1,
            "request_config": 1,
            "endpoint": "https://p10470-ustest-log-collector.ejoy.com",
            "bucket": "f2ustest-local",
            "stsServer": "https://p10470-ustest-log-collector.ejoy.com",
            "stsCallbackServer": "https://p10470-ustest-log-collector.ejoy.com/log/gbi_log",
            "path": "/log/gbi_log",
            "serverid": "1",
            "serverId": "1",
            "userid": "1000001",
            "userId": "1000001",
            "channelId": "998236",
            "subCh": "1",
            "subChannelId": "1",
            "player_info": vanguard_player_info,
            "playerInfo": vanguard_player_info,
            "player_infos": vanguard_player_infos,
            "playerInfos": vanguard_player_infos,
        },
    }

    can_encrypt_response = response_encrypted and _HAS_CRYPTO and bool(ek) and key2_plain is not None
    if can_encrypt_response:
        context['append_utf8_log'](
            f"[VANGUARD_RESP] path={path} token=yes ek=yes body=encrypted "
            f"retCode={vanguard_ret_code} allSwitch={vanguard_all_switch} "
            f"uploadSwitch={vanguard_upload_switch} uploadInterval={vanguard_upload_interval}"
        )
        payload_bytes = json.dumps(payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
        body_b64 = aes_cbc_pkcs7_encrypt_b64(key2_plain, payload_bytes).encode("utf-8")
        context['send_body'](body_b64, status=200, content_type="text/plain; charset=utf-8", extra_headers=headers)
        return True

    body_mode = "plain"
    if response_encrypted and not can_encrypt_response:
        body_mode = "plain-fallback"
    context['append_utf8_log'](
        f"[VANGUARD_RESP] path={path} token=yes ek={'yes' if ek else 'no'} body={body_mode} "
        f"retCode={vanguard_ret_code} allSwitch={vanguard_all_switch} "
        f"uploadSwitch={vanguard_upload_switch} uploadInterval={vanguard_upload_interval}"
    )
    context['send_json'](payload, extra_headers=headers)
    return True
