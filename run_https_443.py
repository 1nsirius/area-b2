"""Minimal HTTPS server on port 443. Run PowerShell as Administrator.
   Requires: cert.pem, key.pem (from gen_https_cert.py)

   Port: set env HTTPS_PORT=8443 for tests if 443 is blocked (game still needs 443).
"""
import os
import ssl
import sys
if __name__ == "__main__":
    sys.modules["run_https_443"] = sys.modules["__main__"]
import importlib
import hashlib
import hmac
import ipaddress
import re
import json
import time
import gzip
import threading
import socket
import select
import subprocess
import socketserver
import base64
from http.server import SimpleHTTPRequestHandler, ThreadingHTTPServer
from pathlib import Path
from urllib.parse import parse_qs, urlparse
from urllib.request import Request, urlopen
from urllib.error import HTTPError, URLError

try:
    from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
    from cryptography.hazmat.primitives.padding import PKCS7

    _HAS_CRYPTO = True
except Exception:
    Cipher = algorithms = modes = PKCS7 = None  # type: ignore[assignment]
    _HAS_CRYPTO = False

DIR = Path(__file__).resolve().parent
PORT = int(os.environ.get("HTTPS_PORT", "443"))
HTTP_PORT = int(os.environ.get("HTTP_PORT", "80"))
# Many builds expect a separate TCP lobby/game endpoint (commonly port 12000).
# Default to 12000 to match those expectations; override via GAME_PORT if needed.
GAME_PORT = int(os.environ.get("GAME_PORT", "12000"))

# Lightweight in-memory store for usercenter mock sessions.
_UC_LOCK = threading.Lock()
_UC_SESSIONS: dict[str, dict] = {}

# AliGames QR-code mock state (PC login/pay flow).
_ALI_QR_LOCK = threading.Lock()
_ALI_QR_LOGIN: dict[str, dict] = {}
_ALI_QR_PAY: dict[str, dict] = {}
_ALI_QR_TOKEN_INDEX: dict[str, str] = {}

# Canonical shared state is kept in services.session_manager so module-based code
# and the legacy monolith operate on the same dictionaries, not duplicated copies.
try:
    import services.session_manager as session_manager
except Exception:
    session_manager = None

if session_manager is not None:
    _UC_LOCK = session_manager._UC_LOCK
    _UC_SESSIONS = session_manager._UC_SESSIONS
    _ALI_QR_LOCK = session_manager._ALI_QR_LOCK
    _ALI_QR_LOGIN = session_manager._ALI_QR_LOGIN
    _ALI_QR_PAY = session_manager._ALI_QR_PAY
    _ALI_QR_TOKEN_INDEX = session_manager._ALI_QR_TOKEN_INDEX
    _HOLO_LOCK = session_manager._HOLO_LOCK
    _HOLO_PLAYER_TOKENS = session_manager._HOLO_PLAYER_TOKENS
    _GP_LOCK = session_manager._GP_LOCK
    _GP_TOKEN_TO_PLAYER_ID = session_manager._GP_TOKEN_TO_PLAYER_ID
    _CHAT_LOCK = session_manager._CHAT_LOCK
    _CHAT_PLAYER_STATE = session_manager._CHAT_PLAYER_STATE
    _CHAT_PENDING_PUSHES = session_manager._CHAT_PENDING_PUSHES
    _CHAT_NEXT_MSG_ID = session_manager._CHAT_NEXT_MSG_ID
    _CHAT_MAX_MESSAGES_PER_SESSION = session_manager._CHAT_MAX_MESSAGES_PER_SESSION
    _CHAT_MAX_PENDING_PUSHES_PER_PLAYER = session_manager._CHAT_MAX_PENDING_PUSHES_PER_PLAYER
    _CHAT_BOOTSTRAP_LOCK = session_manager._CHAT_BOOTSTRAP_LOCK
    _CHAT_BOOTSTRAP_STATE = session_manager._CHAT_BOOTSTRAP_STATE
    _ONLINE_LOCK = session_manager._ONLINE_LOCK
    _ONLINE_SAVE_LOCK = session_manager._ONLINE_SAVE_LOCK
    _ONLINE_STATE_PATH = session_manager._ONLINE_STATE_PATH
    _ONLINE_STATE = session_manager._ONLINE_STATE
    _LOG_LOCK = session_manager._LOG_LOCK
else:
    _UC_LOCK = threading.Lock()
    _UC_SESSIONS: dict[str, dict] = {}
    _ALI_QR_LOCK = threading.Lock()
    _ALI_QR_LOGIN: dict[str, dict] = {}
    _ALI_QR_PAY: dict[str, dict] = {}
    _ALI_QR_TOKEN_INDEX: dict[str, str] = {}
    _HOLO_LOCK = threading.Lock()
    _HOLO_PLAYER_TOKENS: dict[str, dict[str, object]] = {}
    _GP_LOCK = threading.Lock()
    _GP_TOKEN_TO_PLAYER_ID: dict[str, str] = {}
    _CHAT_LOCK = threading.RLock()
    _CHAT_PLAYER_STATE: dict[str, dict[str, object]] = {}
    _CHAT_PENDING_PUSHES: dict[str, list[tuple[str, dict[str, object]]]] = {}
    _CHAT_NEXT_MSG_ID = 1
    _CHAT_MAX_MESSAGES_PER_SESSION = 200
    _CHAT_MAX_PENDING_PUSHES_PER_PLAYER = 256
    _CHAT_BOOTSTRAP_LOCK = threading.Lock()
    _CHAT_BOOTSTRAP_STATE: dict[str, dict[str, object]] = {}
    _ONLINE_LOCK = threading.Lock()
    _ONLINE_SAVE_LOCK = threading.Lock()
    _ONLINE_STATE_PATH = DIR / "artifacts" / "online_state.json"
    _ONLINE_STATE: dict[str, object] = {}
    _LOG_LOCK = threading.Lock()

import threading
_tls = threading.local()
def _get_tls_uid(): return getattr(_tls, "uid", "1000001")

class MultiTenantDict(dict):
    def __init__(self, name):
        super().__init__()
        self.name = name
        self.storage = {}

    def _get_dict(self):
        uid = str(_get_tls_uid())
        if uid not in self.storage:
            self.storage[uid] = {}
            if self.name == "player":
                import time
                ts = int(time.time())
                n_uid = int(uid) if uid.isdigit() else 1000001
                self.storage[uid] = {
                    "uid": n_uid,
                    "name": f"Player{n_uid}",
                    "level": 1,
                    "exp": 0,
                    "icon": 0,
                    "icon_url": "",
                    "icon_frame": 0,
                    "time_zone": 0,
                    "create_time": ts,
                    "current_season_id": 1,
                    "gold": 20000,
                    "diamond": 20000,
                }
            elif self.name == "mail":
                import time
                ts = int(time.time())
                self.storage[uid] = {
                    "next_mail_id": 2,
                    "mails": [{
                        "id": 1,
                        "title": "Welcome",
                        "content": "Welcome to local server.",
                        "mail_type": 1,
                        "is_custom": True,
                        "expire_ts": ts + 30 * 86400,
                        "status": 0,
                        "rewards": [{"id": 90002, "num": 1000}],
                        "create_ts": ts,
                        "content_param": [],
                        "template_type": 0,
                    }],
                }
        return self.storage[uid]

    def get(self, key, default=None): return self._get_dict().get(key, default)
    def setdefault(self, key, default=None): return self._get_dict().setdefault(key, default)
    def __setitem__(self, key, value): self._get_dict()[key] = value
    def __getitem__(self, key): return self._get_dict()[key]
    def __delitem__(self, key): del self._get_dict()[key]
    def __contains__(self, key): return key in self._get_dict()
    def update(self, *args, **kwargs): self._get_dict().update(*args, **kwargs)
    def keys(self): return self._get_dict().keys()
    def values(self): return self._get_dict().values()
    def items(self): return self._get_dict().items()
    def copy(self): return self._get_dict().copy()
    def clear(self): self._get_dict().clear()
    def pop(self, key, *args): return self._get_dict().pop(key, *args)
    def popitem(self): return self._get_dict().popitem()

_player_data = MultiTenantDict("player")
_client_config = MultiTenantDict("config")
_store_state = MultiTenantDict("store")
_mail_state = MultiTenantDict("mail")

_TASK_TABLE: dict[int, dict] = {}
_ACTIVITY_TASK_TABLE: dict[int, dict] = {}

def _init_task_tables() -> None:
    global _TASK_TABLE, _ACTIVITY_TASK_TABLE
    if _TASK_TABLE and _ACTIVITY_TASK_TABLE:
        return
    try:
        task_lua_path = DIR / "decrypted_lua" / "Configs" / "TableData" / "task.lua"
        if task_lua_path.exists():
            with open(task_lua_path, "r", encoding="utf-8", errors="ignore") as f:
                content = f.read()
            for id_s, b in re.findall(r'\[(\d+)\]\s*=\s*\{([^}]+)\}', content):
                t_id = int(id_s)
                p1_m = re.search(r'param1\s*=\s*(\d+)', b)
                act_m = re.search(r'activation\s*=\s*(\d+)', b)
                exp_m = re.search(r'exp\s*=\s*(\d+)', b)
                gt_m = re.search(r'growth_type\s*=\s*(\d+)', b)
                t_m = re.search(r'type\s*=\s*(\d+)', b)
                _TASK_TABLE[t_id] = {
                    'param1': int(p1_m.group(1)) if p1_m else 0,
                    'activation': int(act_m.group(1)) if act_m else 0,
                    'exp': int(exp_m.group(1)) if exp_m else 0,
                    'growth_type': int(gt_m.group(1)) if gt_m else 0,
                    'type': int(t_m.group(1)) if t_m else 0,
                }
    except Exception as e:
        _append_utf8_log(f"[WARN] Failed to load task.lua: {e}")

    try:
        act_lua_path = DIR / "decrypted_lua" / "Configs" / "TableData" / "task_library.lua"
        if act_lua_path.exists():
            with open(act_lua_path, "r", encoding="utf-8", errors="ignore") as f:
                content = f.read()
            entries = re.split(r'\[(\d+)\]\s*=\s*\{', content)
            for i in range(1, len(entries), 2):
                t_id = int(entries[i])
                body = entries[i+1]
                sched_m = re.search(r'schedule_param\s*=\s*(\d+)', body)
                cond_m = re.search(r'condition_type\s*=\s*(\d+)', body)
                rw_m = re.search(r'reward\s*=\s*\{([^}]*)\}', body)
                rewards = []
                if rw_m:
                    rewards = [r.strip(' "\',') for r in re.findall(r'"([^"]+)"', rw_m.group(1))]
                _ACTIVITY_TASK_TABLE[t_id] = {
                    'schedule_param': int(sched_m.group(1)) if sched_m else 0,
                    'condition_type': int(cond_m.group(1)) if cond_m else 0,
                    'rewards': rewards,
                }
    except Exception as e:
        _append_utf8_log(f"[WARN] Failed to load task_library.lua: {e}")

def _grant_rewards_to_player(pd: dict, rewards: list[str]) -> tuple[list[str], list[tuple[int, int]], int, int]:
    granted_summary: list[str] = []
    reward_items: list[tuple[int, int]] = []
    added_gold = 0
    added_diamond = 0
    for r_str in rewards:
        parts = r_str.split("-")
        if len(parts) >= 2:
            try:
                item_id = int(parts[0])
                count = int(parts[1])
                reward_items.append((item_id, count))
                if item_id == 90001:  # Gold
                    cur_g = int(pd.get("gold", 0) or 0)
                    pd["gold"] = max(0, cur_g + count)
                    added_gold += count
                    granted_summary.append(f"{count} Gold")
                elif item_id == 90002:  # Diamond
                    cur_d = int(pd.get("diamond", 0) or 0)
                    pd["diamond"] = max(0, cur_d + count)
                    added_diamond += count
                    granted_summary.append(f"{count} Diamond")
                elif item_id == 90000:  # EXP
                    cur_e = int(pd.get("exp", 0) or 0)
                    pd["exp"] = max(0, cur_e + count)
                    granted_summary.append(f"{count} EXP")
                else:
                    owned = _store_state.get("owned_bag_items")
                    if not isinstance(owned, dict):
                        owned = {}
                        _store_state["owned_bag_items"] = owned
                    owned[str(item_id)] = max(0, int(owned.get(str(item_id), 0) or 0)) + count
                    items_dict = pd.setdefault("items", {})
                    items_dict[str(item_id)] = max(0, int(items_dict.get(str(item_id), 0) or 0)) + count
                    granted_summary.append(f"Item {item_id} x{count}")
            except Exception:
                pass
    return granted_summary, reward_items, added_gold, added_diamond


# Chat TCP mock runtime state. Keep these aliases bound to the canonical
# session_manager state so all layers see the same dictionaries and counters.
if session_manager is not None:
    _CHAT_LOCK = session_manager._CHAT_LOCK
    _CHAT_PLAYER_STATE = session_manager._CHAT_PLAYER_STATE
    _CHAT_PENDING_PUSHES = session_manager._CHAT_PENDING_PUSHES
    _CHAT_NEXT_MSG_ID = session_manager._CHAT_NEXT_MSG_ID
    _CHAT_MAX_MESSAGES_PER_SESSION = session_manager._CHAT_MAX_MESSAGES_PER_SESSION
    _CHAT_MAX_PENDING_PUSHES_PER_PLAYER = session_manager._CHAT_MAX_PENDING_PUSHES_PER_PLAYER
    _CHAT_BOOTSTRAP_LOCK = session_manager._CHAT_BOOTSTRAP_LOCK
    _CHAT_BOOTSTRAP_STATE = session_manager._CHAT_BOOTSTRAP_STATE
else:
    _CHAT_LOCK = threading.RLock()
    _CHAT_PLAYER_STATE: dict[str, dict[str, object]] = {}
    _CHAT_PENDING_PUSHES: dict[str, list[tuple[str, dict[str, object]]]] = {}
    _CHAT_NEXT_MSG_ID = 1
    _CHAT_MAX_MESSAGES_PER_SESSION = 200
    _CHAT_MAX_PENDING_PUSHES_PER_PLAYER = 256
    _CHAT_BOOTSTRAP_LOCK = threading.Lock()
    _CHAT_BOOTSTRAP_STATE: dict[str, dict[str, object]] = {}

_CHAT_BOOTSTRAP_MAX_HINTS = 3
_CHAT_BOOTSTRAP_HINT_DELAYS = (3.0, 9.0)
_CHAT_BOOTSTRAP_FORCE_NAMING_MAX = 1

_CHAT_HEADER_KEY_BY_ID: dict[int, str] = {
    1: "codec",
    2: "method",
    3: "session",
    4: "code",
    5: "error",
    6: "timestamp",
    7: "trace",
    8: "destination",
    9: "source",
}
_CHAT_HEADER_KEY_TO_ID: dict[str, int] = {v: k for k, v in _CHAT_HEADER_KEY_BY_ID.items()}

_CHAT_HEADER_VALUE_BY_ID: dict[int, str] = {
    1: "json",
    2: "sproto",
    3: "protobuf",
    4: "raw",
    5: "0",
}
_CHAT_HEADER_VALUE_TO_ID: dict[str, int] = {v: k for k, v in _CHAT_HEADER_VALUE_BY_ID.items()}


_AUDID_HMAC_MD5_PK = "QrMgt8GGYI6T52ZY5AnhtxkLzb8egpFn"


def _audid_hmac_md5_key() -> str:
    # Mirrors com/ejoy/ta/audid/utils/MD5Utils.getHmacMd5Key().
    seed = bytearray(_AUDID_HMAC_MD5_PK.encode("utf-8"))
    for i in range(len(seed)):
        seed[i] = (seed[i] + i) & 0xFF
    return seed.hex()


_AUDID_HMAC_KEY = _audid_hmac_md5_key()


def _audid_signature_for_response_body(body: bytes) -> str:
    body_text = body.decode("utf-8")
    digest_hex = hmac.new(_AUDID_HMAC_KEY.encode("utf-8"), body_text.encode("utf-8"), hashlib.md5).hexdigest()
    return base64.b64encode(digest_hex.encode("utf-8")).decode("ascii")


def _sdk_server_name_for_region(region_code: str | None) -> str:
    import services.utils as utils
    return utils._sdk_server_name_for_region(region_code)
def _chat_bootstrap_is_done(uid: object) -> bool:
    uid_s = _uid_str(uid, "")
    if not uid_s:
        return False
    with _CHAT_BOOTSTRAP_LOCK:
        state = _CHAT_BOOTSTRAP_STATE.get(uid_s)
        if not isinstance(state, dict):
            return False
        return bool(state.get("done"))


def _chat_bootstrap_mark(uid: object, key: str, value: bool = True) -> None:
    uid_s = _uid_str(uid, "")
    if not uid_s:
        return
    snapshot: dict[str, object] | None = None
    with _CHAT_BOOTSTRAP_LOCK:
        state = _CHAT_BOOTSTRAP_STATE.get(uid_s)
        if not isinstance(state, dict):
            state = {"attempts": 0}
            _CHAT_BOOTSTRAP_STATE[uid_s] = state
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
    if snapshot is not None:
        _append_utf8_log(
            "[CHAT_BOOTSTRAP] mark "
            f"uid={uid_s} key={key} value={1 if value else 0} "
            f"seen_set_player_info={1 if snapshot.get('seen_set_player_info') else 0} "
            f"seen_get_player_token={1 if snapshot.get('seen_get_player_token') else 0} "
            f"seen_chat_login={1 if snapshot.get('seen_chat_login') else 0} "
            f"attempts={int(snapshot.get('attempts') or 0)} "
            f"force_naming_attempts={int(snapshot.get('force_naming_attempts') or 0)} "
            f"done={1 if snapshot.get('done') else 0}"
        )


def _chat_bootstrap_reserve_attempt(uid: object) -> int | None:
    uid_s = _uid_str(uid, "")
    if not uid_s:
        return None
    with _CHAT_BOOTSTRAP_LOCK:
        state = _CHAT_BOOTSTRAP_STATE.get(uid_s)
        if not isinstance(state, dict):
            state = {"attempts": 0}
            _CHAT_BOOTSTRAP_STATE[uid_s] = state
        if state.get("done"):
            return None
        attempts = int(state.get("attempts") or 0)
        if attempts >= _CHAT_BOOTSTRAP_MAX_HINTS:
            return None
        attempts += 1
        state["attempts"] = attempts
        return attempts


class _RC4Stream:
    """Small stateful RC4 stream used by chat-tcpclient protocol."""

    def __init__(self, key: bytes):
        if not key:
            raise ValueError("empty RC4 key")
        s = list(range(256))
        j = 0
        key_len = len(key)
        for i in range(256):
            j = (j + s[i] + key[i % key_len]) & 0xFF
            s[i], s[j] = s[j], s[i]
        self._s = bytearray(s)
        self._i = 0
        self._j = 0

    def snapshot(self) -> tuple[bytes, int, int]:
        return bytes(self._s), self._i, self._j

    def restore(self, snapshot: tuple[bytes, int, int]) -> None:
        s, i, j = snapshot
        self._s = bytearray(s)
        self._i = i
        self._j = j

    def crypt(self, data: bytes) -> bytes:
        if not data:
            return b""
        s = self._s
        i = self._i
        j = self._j
        out = bytearray(len(data))
        for idx, b in enumerate(data):
            i = (i + 1) & 0xFF
            j = (j + s[i]) & 0xFF
            s[i], s[j] = s[j], s[i]
            k = s[(s[i] + s[j]) & 0xFF]
            out[idx] = b ^ k
        self._i = i
        self._j = j
        return bytes(out)


def _chat_clone_json(value: object) -> object:
    """Deep-copy JSON-compatible values used in chat mock responses."""
    try:
        return json.loads(json.dumps(value, ensure_ascii=False))
    except Exception:
        return value


def _chat_decode_header(chunk: bytes) -> dict[str, str]:
    header: dict[str, str] = {}
    pos = 0
    total = len(chunk)

    while pos < total:
        first = chunk[pos]
        # Key decode
        if (first & 0x80) == 0:
            key_len = first
            pos += 1
            if pos + key_len > total:
                raise ValueError("chat header key length overflow")
            key = chunk[pos : pos + key_len].decode("utf-8", errors="replace")
            pos += key_len
        else:
            key_id = first & 0x7F
            pos += 1
            key = _CHAT_HEADER_KEY_BY_ID.get(key_id, str(key_id))

        if pos >= total:
            break

        first = chunk[pos]
        # Value decode
        if (first & 0xC0) == 0:
            val_len = first
            pos += 1
            if pos + val_len > total:
                raise ValueError("chat header value length overflow")
            value = chunk[pos : pos + val_len].decode("utf-8", errors="replace")
            pos += val_len
        elif (first & 0xC0) == 0x40:
            if pos + 2 > total:
                raise ValueError("chat header short two-byte value length")
            i1 = chunk[pos]
            i2 = chunk[pos + 1]
            pos += 2
            val_len = ((i1 & 0x3F) << 8) + i2
            if pos + val_len > total:
                raise ValueError("chat header value length2 overflow")
            value = chunk[pos : pos + val_len].decode("utf-8", errors="replace")
            pos += val_len
        elif (first & 0x80) == 0x80:
            val_id = first & 0x7F
            pos += 1
            value = _CHAT_HEADER_VALUE_BY_ID.get(val_id, str(val_id))
        else:
            raise ValueError("unsupported chat header value format")

        header[key] = value

    return header


def _chat_encode_header(header: dict[str, object]) -> bytes:
    out = bytearray()
    for key, value in header.items():
        key_s = str(key)
        key_id = _CHAT_HEADER_KEY_TO_ID.get(key_s)
        if key_id is not None:
            out.append(0x80 | key_id)
        else:
            key_b = key_s.encode("utf-8", errors="replace")
            if len(key_b) >= 0x7F:
                raise ValueError("chat header key too long")
            out.append(len(key_b))
            out.extend(key_b)

        value_s = str(value)
        value_id = _CHAT_HEADER_VALUE_TO_ID.get(value_s)
        if value_id is not None:
            out.append(0x80 | value_id)
            continue

        value_b = value_s.encode("utf-8", errors="replace")
        value_len = len(value_b)
        if value_len < 0x40:
            out.append(value_len)
            out.extend(value_b)
        elif value_len < 0x4000:
            out.append(0x40 | ((value_len >> 8) & 0x3F))
            out.append(value_len & 0xFF)
            out.extend(value_b)
        else:
            raise ValueError("chat header value too long")
    return bytes(out)


def _chat_parse_login_prefix(frame_payload: bytes) -> tuple[int, int, str, bytes] | None:
    """Parse chat login prefix: [ver:1][expire:4][pid_len:1][pid][enc_payload]."""
    if len(frame_payload) < 8:
        return None
    version = frame_payload[0]
    if version not in {0, 1}:
        return None

    expire_time = int.from_bytes(frame_payload[1:5], "big", signed=False)
    # Keep a broad but realistic unix-time window to avoid false positives.
    if expire_time < 1_500_000_000 or expire_time > 4_200_000_000:
        return None

    pid_len = frame_payload[5]
    if pid_len < 4 or pid_len > 48:
        return None
    if len(frame_payload) <= 6 + pid_len:
        return None

    pid_raw = frame_payload[6 : 6 + pid_len]
    try:
        player_id = pid_raw.decode("utf-8", errors="strict")
    except Exception:
        return None
    if not player_id or not re.fullmatch(r"[0-9A-Za-z_\-]+", player_id):
        return None

    encrypted_payload = frame_payload[6 + pid_len :]
    if not encrypted_payload:
        return None
    return version, expire_time, player_id, encrypted_payload


def _env_truthy(name: str, default: str = "0") -> bool:
    import services.utils as utils
    return utils._env_truthy(name, default)
def _chat_bootstrap_should_force_naming(uid: object) -> bool:
    # Keep disabled by default: forcing Naming may trigger side effects in
    # client FSM/SDK bootstrap and hide the real missing-contract cause.
    if not _env_truthy("CHAT_FORCE_NAMING_ON_CHAT_MISS", "0"):
        return False
    uid_s = _uid_str(uid, "")
    if not uid_s:
        return False
    if _chat_bootstrap_is_done(uid_s):
        return False
    with _CHAT_BOOTSTRAP_LOCK:
        state = _CHAT_BOOTSTRAP_STATE.get(uid_s)
        if not isinstance(state, dict):
            state = {"attempts": 0}
            _CHAT_BOOTSTRAP_STATE[uid_s] = state
        tries = int(state.get("force_naming_attempts") or 0)
        if tries >= _CHAT_BOOTSTRAP_FORCE_NAMING_MAX:
            return False
        state["force_naming_attempts"] = tries + 1
        state["force_naming_ts"] = time.time()
    return True


def _parse_port_list(raw: str) -> list[int]:
    ports: list[int] = []
    if not raw:
        return ports
    for part in re.split(r"[\s,;]+", raw.strip()):
        if not part:
            continue
        try:
            p = int(part)
        except Exception:
            continue
        if 1 <= p <= 65535 and p not in ports:
            ports.append(p)
    return ports


def _win_port_pids(port: int, protocol: str) -> set[int]:
    if os.name != "nt":
        return set()
    try:
        proc = subprocess.run(
            ["netstat", "-ano"],
            capture_output=True,
            text=True,
            shell=False,
            check=False,
        )
        lines = proc.stdout.splitlines()
    except Exception:
        return set()

    protocol = protocol.upper()
    pids: set[int] = set()
    for line in lines:
        parts = line.split()
        if len(parts) < 5:
            continue
        if parts[0].upper() != protocol:
            continue
        local_addr = parts[1]
        if not local_addr.endswith(f":{port}"):
            continue

        if protocol == "TCP":
            state = parts[3].upper() if len(parts) >= 4 else ""
            if state not in {"LISTENING", "ESTABLISHED", "CLOSE_WAIT", "SYN_SENT", "SYN_RECEIVED", "FIN_WAIT_1", "FIN_WAIT_2", "TIME_WAIT"}:
                continue
            pid_part = parts[-1]
        else:
            pid_part = parts[-1]

        try:
            pid = int(pid_part)
        except ValueError:
            continue
        if pid != os.getpid():
            pids.add(pid)
    return pids


def _win_kill_pids(pids: set[int]) -> list[int]:
    killed: list[int] = []
    for pid in sorted(pids):
        try:
            # Kill any process holding the port. We only avoid killing this process itself.
            result = subprocess.run(
                ["taskkill", "/PID", str(pid), "/F"],
                capture_output=True,
                text=True,
                shell=False,
                check=False,
            )
            if result.returncode == 0:
                killed.append(pid)
                _append_utf8_log(f"[PORT CLEANUP] killed PID {pid} for occupied port")
            else:
                _append_utf8_log(f"[PORT CLEANUP] failed to kill PID {pid}: {result.stderr.strip() or result.stdout.strip()}")
        except Exception as e:
            import traceback; traceback.print_exc()
            _append_utf8_log(f"[PORT CLEANUP] error checking/killing PID {pid}: {e}")
    return killed


def _free_windows_port(port: int, protocol: str) -> None:
    if os.name != "nt":
        return
    pids = _win_port_pids(port, protocol)
    if not pids:
        return
    _append_utf8_log(f"[PORT CLEANUP] found blocking {protocol} port {port} pids={sorted(pids)}")
    _win_kill_pids(pids)


def _log_windows_port_status(port: int, protocol: str) -> None:
    if os.name != "nt":
        return
    try:
        proc = subprocess.run(
            ["netstat", "-ano"],
            capture_output=True,
            text=True,
            shell=False,
            check=False,
        )
        for line in proc.stdout.splitlines():
            if f":{port}" in line and line.split()[0].upper() == protocol.upper():
                _append_utf8_log(f"[PORT STATUS] {line}")
    except Exception as e:
        import traceback; traceback.print_exc()
        _append_utf8_log(f"[PORT STATUS] failed to query port {port}: {e}")


# CDN proxy settings
CDN_CACHE_DIR = DIR / "cache" / "f2_assets"
CDN_CACHE_DIR.mkdir(parents=True, exist_ok=True)
UPSTREAM_CDN = os.environ.get("UPSTREAM_CDN", "https://sea-res-mcd.ejoy.com")
ENABLE_CDN_PROXY = _env_truthy("ENABLE_CDN_PROXY", "1")


def _sanitize_display_name(val: object, fallback: str = "Local") -> str:
    import services.utils as utils
    return utils._sanitize_display_name(val, fallback)
F2_FILE_PREFIX = "/f2/Beta1.0/Android/File/"
F2_FILE_MARKER = "/android/file/"
F2_ASSETS_PREFIX = "/f2/assets/"
LEGACY_ASSET_FILE_GLOB = "legacy_cleanup_*/version_1_0_1/app_dec/assets/File"


def _discover_asset_file_dir() -> Path:
    """Pick the best available assets/File directory for update file serving."""
    candidates = [
        DIR / "extracted" / "obb" / "assets" / "File",
        DIR / "extracted_temp" / "assets" / "File",
        DIR / "app_dec_v60" / "assets" / "File",
        DIR / "app_dec" / "assets" / "File",
    ]

    for p in candidates:
        if p.is_dir():
            return p

    archive_root = DIR / "archive"
    if archive_root.is_dir():
        legacy_matches = sorted(archive_root.glob(LEGACY_ASSET_FILE_GLOB))
        for p in reversed(legacy_matches):
            if p.is_dir():
                return p

    # Fallback path if nothing exists yet; callers handle missing files gracefully.
    return candidates[0]


def _extract_f2_rel_path(path: str) -> str | None:
    """Extract relative file name for supported /f2/* resource URL patterns."""
    low = (path or "").lower()
    if not low.startswith("/f2/"):
        return None

    if low.startswith(F2_ASSETS_PREFIX):
        rel = path[len(F2_ASSETS_PREFIX) :].lstrip("/")
        return rel or None

    idx = low.find(F2_FILE_MARKER)
    if idx < 0:
        return None
    rel = path[idx + len(F2_FILE_MARKER) :].lstrip("/")
    return rel or None


def _extract_version_triplet_from_path(path: str) -> tuple[str, str, str] | None:
    """Parse '/<major>_<minor>_<patch>/Android/File/' if present in URL path."""
    m = re.search(r"/(\d+)_(\d+)_(\d+)/android/file/", (path or "").lower())
    if not m:
        return None
    return m.group(1), m.group(2), m.group(3)


def _parse_single_range_header(range_header: str | None, total_size: int) -> tuple[int, int] | str | None:
    """Parse a single bytes range header.

    Returns:
      - (start, end) inclusive when range is satisfiable
      - "unsat" when syntactically valid but unsatisfiable
      - None when header is missing/invalid/unsupported (range ignored)
    """
    if not range_header:
        return None

    value = range_header.strip()
    if not value.lower().startswith("bytes="):
        return None

    spec = value[6:].strip()
    if not spec or "," in spec or "-" not in spec:
        return None

    start_s, end_s = spec.split("-", 1)
    start_s = start_s.strip()
    end_s = end_s.strip()

    if not start_s and not end_s:
        return None

    try:
        if not start_s:
            # Suffix-byte-range-spec: bytes=-<length>
            suffix_len = int(end_s)
            if suffix_len <= 0 or total_size <= 0:
                return "unsat"
            if suffix_len >= total_size:
                return (0, total_size - 1)
            return (total_size - suffix_len, total_size - 1)

        start = int(start_s)
        if start < 0:
            return None
        if start >= total_size:
            return "unsat"

        if not end_s:
            end = total_size - 1
        else:
            end = int(end_s)
            if end < start:
                return None
            if end >= total_size:
                end = total_size - 1

        return (start, end)
    except ValueError:
        return None


ASSET_FILE_DIR = _discover_asset_file_dir()
VERSION_FILE = ASSET_FILE_DIR / "VERSION"
HEX32_RE = re.compile(r"^[0-9a-fA-F]{32}$")
_VERSION_MD5: str | None = None
_VERSION_INDEX: dict[str, str] | None = None
_VERSION_INDEX_MTIME_NS: int | None = None
_SYNTHETIC_F2_BLOBS: dict[str, bytes] = {}


def _proxy_cdn_asset(asset_hash: str, request_path: str) -> bytes | None:
    """Proxy and cache an asset from upstream CDN.

    Returns cached or freshly downloaded asset bytes, or None on failure.
    """
    if not ENABLE_CDN_PROXY:
        return None

    cache_file = CDN_CACHE_DIR / asset_hash
    if cache_file.is_file():
        try:
            return cache_file.read_bytes()
        except Exception as e:
            import traceback; traceback.print_exc()
            _append_utf8_log(f"[CDN] Cache read failed for {asset_hash}: {e}")

    # Try to download from upstream CDN
    upstream_url = f"{UPSTREAM_CDN}{request_path}"
    try:
        _append_utf8_log(f"[CDN] Proxying {asset_hash} from {upstream_url}")
        req = Request(upstream_url, headers={
            "User-Agent": "Dalvik/2.1.0 (Linux; U; Android 10)",
        })
        with urlopen(req, timeout=30) as response:
            data = response.read()
            # Cache for future requests
            try:
                cache_file.write_bytes(data)
                _append_utf8_log(f"[CDN] Cached {asset_hash} ({len(data)} bytes)")
            except Exception as e:
                import traceback; traceback.print_exc()
                _append_utf8_log(f"[CDN] Cache write failed for {asset_hash}: {e}")
            return data
    except (HTTPError, URLError) as e:
        _append_utf8_log(f"[CDN] Proxy failed for {asset_hash}: {e}")
        return None
    except Exception as e:
        import traceback; traceback.print_exc()
        _append_utf8_log(f"[CDN] Unexpected error proxying {asset_hash}: {e}")
        return None


def _default_version_blob() -> bytes:
    if VERSION_FILE.is_file():
        try:
            return VERSION_FILE.read_bytes()
        except Exception:
            pass
    return b""


def _register_synthetic_blob(blob: bytes) -> str:
    md5 = hashlib.md5(blob).hexdigest()
    _SYNTHETIC_F2_BLOBS[md5] = blob
    return md5


def _build_remote_update_control_body() -> bytes:
    override = os.environ.get("REMOTE_UPDATE_CONTROL_BODY")
    if override is not None:
        return override.encode("utf-8")

    enabled = False
    enabled_raw = os.environ.get("REMOTE_HOTUPDATE_ENABLED")
    if enabled_raw is not None:
        enabled = enabled_raw.strip().lower() in {"1", "true", "yes", "on"}

    payload = {"HotUpdateEnabled": enabled}
    return json.dumps(payload, separators=(",", ":"), ensure_ascii=False).encode("utf-8")


def _build_app_version_info_body(request_path: str) -> bytes:
    major = (os.environ.get("APP_VERSION_MAJOR") or "1").strip() or "1"
    patch = (os.environ.get("APP_VERSION_PATCH") or "60").strip() or "60"

    triplet = _extract_version_triplet_from_path(request_path)
    if triplet:
        major = triplet[0]
        patch = triplet[2]

    version_blob = _default_version_blob()
    version_md5 = _register_synthetic_blob(version_blob)
    body = f"MajorVersion: {major}\nPatchVersion: {patch}\nVersionMD5: {version_md5}\n"
    return body.encode("utf-8")


_LOG_LOCK = threading.Lock()


def _console_safe(s: str) -> str:
    """Make a string printable even when stdout encoding can't represent it."""
    enc = getattr(sys.stdout, "encoding", None) or "utf-8"
    try:
        return s.encode(enc, errors="backslashreplace").decode(enc, errors="strict")
    except Exception:
        return s.encode("utf-8", errors="backslashreplace").decode("utf-8", errors="strict")


def _append_utf8_log(line: str):
    try:
        import services.admin_panel as admin_panel
        tag = "SERVER"
        if line.startswith("["):
            tag_end = line.find("]")
            if tag_end > 0:
                tag = line[1:tag_end]
        admin_panel.record_admin_log(line, tag=tag)
    except Exception:
        pass
    import services.utils as utils
    return utils._append_utf8_log(line)
def _parse_content_type_boundary(content_type: object) -> bytes | None:
    raw = str(content_type or "").strip()
    if not raw:
        return None
    m = re.search(r'boundary=(?:"([^"]+)"|([^;]+))', raw, flags=re.IGNORECASE)
    if not m:
        return None
    boundary = (m.group(1) or m.group(2) or "").strip()
    if not boundary:
        return None
    try:
        return boundary.encode("utf-8", errors="strict")
    except Exception:
        return None


def _parse_multipart_parts(body: bytes, boundary: bytes) -> list[tuple[dict[str, str], bytes]]:
    if not body or not boundary:
        return []
    marker = b"--" + boundary
    parts: list[tuple[dict[str, str], bytes]] = []
    for chunk in body.split(marker):
        if not chunk:
            continue
        if chunk.startswith(b"--"):
            break
        if chunk.startswith(b"\r\n"):
            chunk = chunk[2:]
        header_end = chunk.find(b"\r\n\r\n")
        if header_end < 0:
            continue
        headers_blob = chunk[:header_end]
        payload = chunk[header_end + 4 :]
        if payload.endswith(b"\r\n"):
            payload = payload[:-2]
        headers: dict[str, str] = {}
        for raw_line in headers_blob.split(b"\r\n"):
            if b":" not in raw_line:
                continue
            k, v = raw_line.split(b":", 1)
            key = k.decode("utf-8", errors="replace").strip().lower()
            val = v.decode("utf-8", errors="replace").strip()
            if key:
                headers[key] = val
        parts.append((headers, payload))
    return parts


def _multipart_name_from_disposition(disposition: str) -> str:
    if not disposition:
        return ""
    m = re.search(r'name="([^"]+)"', disposition, flags=re.IGNORECASE)
    if not m:
        return ""
    return str(m.group(1) or "").strip()


def _capture_gbi_log(body: bytes, content_type: object, peer_ip: str) -> None:
    try:
        client_dir = DIR / "artifacts" / "logs" / "client"
        client_dir.mkdir(parents=True, exist_ok=True)
    except Exception:
        return

    ts = int(time.time() * 1000)
    tag = f"{ts}_{threading.get_ident()}"
    raw_path = client_dir / f"gbi_{tag}.multipart.bin"
    payload_path = client_dir / f"gbi_{tag}.payload.bin"
    text_path = client_dir / f"gbi_{tag}.payload.txt"

    try:
        raw_path.write_bytes(body or b"")
    except Exception:
        pass

    payload = body or b""
    boundary = _parse_content_type_boundary(content_type)
    field_name = ""
    if boundary:
        try:
            for headers, part_payload in _parse_multipart_parts(payload, boundary):
                disp = str(headers.get("content-disposition") or "")
                name = _multipart_name_from_disposition(disp)
                if name == "data":
                    payload = part_payload
                    field_name = name
                    break
        except Exception:
            pass

    try:
        payload_path.write_bytes(payload)
    except Exception:
        pass

    decoded_bytes = payload
    gzip_used = False
    if len(payload) >= 2 and payload[:2] == b"\x1f\x8b":
        try:
            decoded_bytes = gzip.decompress(payload)
            gzip_used = True
        except Exception:
            decoded_bytes = payload

    preview = ""
    try:
        decoded_text = decoded_bytes.decode("utf-8", errors="replace")
        text_path.write_text(decoded_text, encoding="utf-8")
        preview = decoded_text[:220].replace("\n", "\\n")
    except Exception:
        preview = payload[:32].hex()

    _append_utf8_log(
        "[GBI_LOG] captured "
        f"peer={peer_ip} content_type={str(content_type or '')!r} "
        f"field={field_name or '-'} raw_len={len(body or b'')} payload_len={len(payload)} "
        f"gzip={1 if gzip_used else 0} "
        f"raw_file={raw_path.name} payload_file={payload_path.name} text_file={text_path.name if text_path.exists() else '-'} "
        f"preview={preview!r}"
    )


def _no_cache_headers(extra: dict[str, str] | None = None) -> dict[str, str]:
    import services.utils as utils
    return utils._no_cache_headers(extra)
def _infer_region_from_host(host: str) -> str | None:
    import services.utils as utils
    return utils._infer_region_from_host(host)
def _canonical_region_code(region_code: str | None, fallback: str | None = None) -> str:
    import services.utils as utils
    return utils._canonical_region_code(region_code, fallback)
def _infer_region_from_sdk_server_name(server_name: object) -> str | None:
    import services.utils as utils
    return utils._infer_region_from_sdk_server_name(server_name)
def _resolve_request_region(req: dict | None, host: str, *, default: str = "ustest") -> str:
    import services.utils as utils
    return utils._resolve_request_region(req, host, default=default)
def _is_p10470_service_host(host: str) -> bool:
    host = (host or "").strip().lower()
    return host.startswith("p10470-") and host.endswith(".ejoy.com")


def _is_ip_literal_host(host: str) -> bool:
    host = (host or "").strip().lower()
    if not host:
        return False
    if host.startswith("[") and host.endswith("]"):
        host = host[1:-1].strip()
    try:
        ipaddress.ip_address(host)
        return True
    except Exception:
        return False


def _allow_gangplank_config_host(host: str) -> bool:
    host = (host or "").strip().lower()
    return (
        host == "global-config.ejoy.com"
        or _is_p10470_service_host(host)
        or _is_ip_literal_host(host)
        or host in {"localhost", "127.0.0.1"}
    )


def _holo_service_base_for_region(region_code: str | None, request_host: str | None = None) -> str:
    game_host = (os.environ.get("GAME_HOST") or os.environ.get("SERVER_IP") or request_host or "").strip()
    if ":" in game_host:
        game_host = game_host.split(":")[0].strip()
    if game_host and not _env_truthy("PRESERVE_EJOY_REGIONAL_DOMAINS", "0"):
        return f"https://{game_host}"
    region = _canonical_region_code(region_code, "ustest")
    if region not in {"sgtest", "ustest", "br"}:
        region = "ustest"
    return f"https://p10470-{region}-holo.ejoy.com"


def _chat_tcp_host_for_region(region_code: str | None, request_host: str | None = None) -> str:
    game_host = (os.environ.get("GAME_HOST") or os.environ.get("SERVER_IP") or request_host or "").strip()
    if ":" in game_host:
        game_host = game_host.split(":")[0].strip()
    if game_host and not _env_truthy("PRESERVE_EJOY_REGIONAL_DOMAINS", "0"):
        return game_host
    region = _canonical_region_code(region_code, "ustest")
    if region not in {"sgtest", "ustest", "br"}:
        region = "ustest"
    return f"p10470-{region}-chat-tcpclient.ejoy.com"


def _safe_env_port(name: str, default: int) -> int:
    raw = (os.environ.get(name) or "").strip()
    if not raw:
        return default
    try:
        port = int(raw)
    except Exception:
        return default
    if 1 <= port <= 65535:
        return port
    return default


def _holo_player_token_payload(player_id: object | None) -> dict[str, object]:
    pid = str(player_id or "1000001").strip() or "1000001"
    now = int(time.time())

    ttl_raw = (os.environ.get("HOLO_TOKEN_TTL_SEC") or "86400").strip()
    try:
        ttl_sec = int(ttl_raw)
    except Exception:
        ttl_sec = 86400
    if ttl_sec < 600:
        ttl_sec = 600

    with _HOLO_LOCK:
        cached = _HOLO_PLAYER_TOKENS.get(pid)
        if cached:
            try:
                exp = int(cached.get("expire_time", 0) or 0)
            except Exception:
                exp = 0
            if exp > now + 120:
                return dict(cached)

        salt = (os.environ.get("HOLO_TOKEN_SALT") or "local-holo").strip() or "local-holo"
        moment_token = "mtk_" + hashlib.md5(f"{pid}:{salt}:moment".encode("utf-8")).hexdigest()
        # Keep key length 16 for broad compatibility with RC4 key setup.
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
        _HOLO_PLAYER_TOKENS[pid] = payload
        return dict(payload)


def _holo_player_token_by_moment_token(moment_token: object | None) -> dict[str, object] | None:
    token = str(moment_token or "").strip()
    if not token:
        return None
    with _HOLO_LOCK:
        for payload in _HOLO_PLAYER_TOKENS.values():
            if str(payload.get("moment_token") or "") == token:
                return dict(payload)

    salt = (os.environ.get("HOLO_TOKEN_SALT") or "local-holo").strip() or "local-holo"
    try:
        import database
        all_profiles = database.get_all_profiles()
        for uid_s in all_profiles.keys():
            pid = _uid_str(uid_s)
            expected = "mtk_" + hashlib.md5(f"{pid}:{salt}:moment".encode("utf-8")).hexdigest()
            if token == expected:
                key = hashlib.md5(f"{pid}:{salt}:key".encode("utf-8")).hexdigest()[:16]
                payload = {
                    "player_id": pid,
                    "playerId": pid,
                    "uid": pid,
                    "moment_token": token,
                    "key": key,
                    "expire_time": int(time.time()) + 86400 * 30,
                }
                with _HOLO_LOCK:
                    _HOLO_PLAYER_TOKENS[pid] = payload
                return dict(payload)
    except Exception:
        pass
    return None


def _holo_latest_player_token_payload() -> dict[str, object] | None:
    with _HOLO_LOCK:
        if not _HOLO_PLAYER_TOKENS:
            return None
        latest = None
        latest_expire = -1
        for payload in _HOLO_PLAYER_TOKENS.values():
            try:
                expire = int(payload.get("expire_time") or 0)
            except Exception:
                expire = 0
            if latest is None or expire > latest_expire:
                latest = payload
                latest_expire = expire
        return dict(latest) if latest is not None else None


def _safe_int(value: object, default: int = 0) -> int:
    import services.utils as utils
    return utils._safe_int(value, default)
def _uid_str(value: object, fallback: str = "1000001") -> str:
    import services.utils as utils
    return utils._uid_str(value, fallback)
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
    with _ONLINE_LOCK:
        mapping = _ONLINE_STATE.get("account_to_uid")
        if not isinstance(mapping, dict):
            mapping = {}
            _ONLINE_STATE["account_to_uid"] = mapping
        if account in mapping:
            return mapping[account]
        new_uid = 1000001
        if mapping:
            new_uid = max(mapping.values()) + 1
        mapping[account] = new_uid
        _ONLINE_STATE_PATH.parent.mkdir(parents=True, exist_ok=True)
        with _ONLINE_STATE_PATH.open("w", encoding="utf-8", newline="\n") as f:
            json.dump(_ONLINE_STATE, f, ensure_ascii=False, indent=2)
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

_ROOM_STATE: dict[str, object] = {
    "next_room_id": 100001,
    "room_id": 0,
    "owner_uid": 0,
    "battle_zone": 1,
    "map_id": 1,
    "mode_id": 0,
    "players": {},
    "snapshot_sent": False,
    "last_snapshot_push_ts": 0.0,
}
_room_state = _ROOM_STATE


def _chat_ignore_data_from_state(state: dict[str, object]) -> dict[str, list[str]]:
    sessions_raw = state.get("ignore_sessions")
    if not isinstance(sessions_raw, set):
        sessions_raw = set()
    group_types_raw = state.get("ignore_group_types")
    if not isinstance(group_types_raw, set):
        group_types_raw = set()
    return {
        "sessions": sorted(str(v) for v in sessions_raw if v is not None),
        "group_types": sorted(str(v) for v in group_types_raw if v is not None),
    }


def _chat_queue_pending_push(player_id: object, push: tuple[str, dict[str, object]]) -> None:
    pid = _uid_str(player_id, "")
    if not pid:
        return
    tag, payload = push
    if not isinstance(payload, dict):
        return
    tag_s = str(tag or "").strip() or "push-info-msg"
    payload_copy = _chat_clone_json(payload)
    if not isinstance(payload_copy, dict):
        return
    with _CHAT_LOCK:
        bucket = _CHAT_PENDING_PUSHES.get(pid)
        if not isinstance(bucket, list):
            bucket = []
            _CHAT_PENDING_PUSHES[pid] = bucket
        if len(bucket) >= _CHAT_MAX_PENDING_PUSHES_PER_PLAYER:
            del bucket[: max(1, len(bucket) - (_CHAT_MAX_PENDING_PUSHES_PER_PLAYER - 1))]
        bucket.append((tag_s, payload_copy))


def _chat_drain_pending_pushes(player_id: object, *, max_items: int = 64) -> list[tuple[str, dict[str, object]]]:
    pid = _uid_str(player_id, "")
    if not pid:
        return []
    if max_items <= 0:
        max_items = 1
    with _CHAT_LOCK:
        bucket = _CHAT_PENDING_PUSHES.get(pid)
        if not isinstance(bucket, list) or not bucket:
            return []
        drained = bucket[:max_items]
        del bucket[:max_items]
        if not bucket:
            _CHAT_PENDING_PUSHES.pop(pid, None)
    out: list[tuple[str, dict[str, object]]] = []
    for tag, payload in drained:
        if not isinstance(payload, dict):
            continue
        out.append((str(tag or "push-info-msg"), _chat_clone_json(payload)))
    return out


def _chat_normalize_group_id(group_id: object, *, fallback: str = "") -> str:
    raw = str(group_id or "").strip()
    if not raw:
        return fallback
    if raw == "group_world":
        return "group_world"
    if raw.startswith("group_"):
        return raw
    if raw.startswith("group"):
        suffix = raw
        for prefix in ("group_", "group:", "group-", "group"):
            if suffix.startswith(prefix):
                suffix = suffix[len(prefix):]
                break
        suffix = re.sub(r"[^0-9A-Za-z_\-]+", "_", suffix).strip("_")
        if suffix:
            return f"group_{suffix}"
        return fallback or "group_world"
    return raw


def _chat_room_group_id(room_id: object) -> str:
    rid = max(1, _safe_int(room_id, 1))
    return f"group_room_{rid}"


def _chat_build_group_payload(group_id: object, *, group_type: str = "group", name: str = "Group") -> dict[str, object]:
    gid = _chat_normalize_group_id(group_id, fallback="group_world")
    gtype = str(group_type or "group").strip().lower()
    if gid == "group_world":
        gtype = "world"
    elif gtype not in {"group", "team", "room"}:
        gtype = "group"
    gname = str(name or "").strip() or ("World" if gid == "group_world" else "Group")
    return {
        "group_id": gid,
        "info": {
            "name": gname,
            "type": gtype,
        },
        "attr": {
            "enable_voice": False,
        },
        "member_infos": [],
        "invited_member_infos": [],
        "personal_info": {
            "agora_channel_token": "",
        },
    }


def _chat_ensure_group_for_player(
    player_id: object,
    group_payload: object,
    *,
    queue_create_push: bool = True,
) -> str:
    pid = _uid_str(player_id, "")
    if not pid or not isinstance(group_payload, dict):
        return ""
    group_copy = _chat_clone_json(group_payload)
    if not isinstance(group_copy, dict):
        return ""
    group_id = _chat_normalize_group_id(group_copy.get("group_id"), fallback="")
    if not group_id:
        return ""
    group_copy["group_id"] = group_id

    should_push = False
    with _CHAT_LOCK:
        state_obj = _CHAT_PLAYER_STATE.get(pid)
        if not isinstance(state_obj, dict):
            state_obj = {
                "sessions": {},
                "groups": [],
                "ignore_sessions": set(),
                "ignore_group_types": set(),
            }
            _CHAT_PLAYER_STATE[pid] = state_obj

        groups_obj = state_obj.get("groups")
        if not isinstance(groups_obj, list):
            groups_obj = []
            state_obj["groups"] = groups_obj

        found = False
        for idx, group in enumerate(groups_obj):
            if not isinstance(group, dict):
                continue
            if _chat_normalize_group_id(group.get("group_id"), fallback="") != group_id:
                continue
            groups_obj[idx] = _chat_clone_json(group_copy)
            found = True
            break
        if not found:
            groups_obj.append(_chat_clone_json(group_copy))
            should_push = queue_create_push and group_id != "group_world"

    if should_push:
        _chat_queue_pending_push(
            pid,
            (
                "push-info-create-group",
                {
                    "cmd": "info_create_group",
                    "group": _chat_clone_json(group_copy),
                },
            ),
        )
    return group_id


def _chat_remove_group_for_player(
    player_id: object,
    group_id: object,
    *,
    queue_delete_push: bool = True,
) -> bool:
    pid = _uid_str(player_id, "")
    gid = _chat_normalize_group_id(group_id, fallback="")
    if not pid or not gid or gid == "group_world":
        return False

    removed = False
    with _CHAT_LOCK:
        state_obj = _CHAT_PLAYER_STATE.get(pid)
        if not isinstance(state_obj, dict):
            return False
        groups_obj = state_obj.get("groups")
        if not isinstance(groups_obj, list):
            return False
        next_groups: list[object] = []
        for group in groups_obj:
            if isinstance(group, dict) and _chat_normalize_group_id(group.get("group_id"), fallback="") == gid:
                removed = True
                continue
            next_groups.append(group)
        if removed:
            state_obj["groups"] = next_groups
            sessions_obj = state_obj.get("sessions")
            if isinstance(sessions_obj, dict):
                sessions_obj.pop(gid, None)

    if removed:
        try:
            import services.chat as chat_srv
            chat_srv._broadcast_player_status_change(pid, chat_srv.get_player_state(pid))
        except Exception:
            pass

    if removed and queue_delete_push:
        _chat_queue_pending_push(
            pid,
            (
                "push-info-delete-group",
                {
                    "cmd": "info_delete_group",
                    "group_id": gid,
                    "reason": 2,
                    "message": "",
                },
            ),
        )
    return removed


def _chat_sync_room_group_members(room_id: object, member_uids: object) -> str:
    group_id = _chat_room_group_id(room_id)
    group_payload = _chat_build_group_payload(
        group_id,
        group_type="room",
        name=f"Room {_safe_int(room_id, 0)}",
    )
    if not isinstance(member_uids, (list, tuple, set)):
        return group_id
    for raw_uid in member_uids:
        uid_s = _uid_str(raw_uid, "")
        if not uid_s:
            continue
        _chat_ensure_group_for_player(uid_s, group_payload, queue_create_push=True)
    return group_id


def _chat_remove_room_group_members(room_id: object, member_uids: object) -> None:
    group_id = _chat_room_group_id(room_id)
    if not isinstance(member_uids, (list, tuple, set)):
        return
    for raw_uid in member_uids:
        uid_s = _uid_str(raw_uid, "")
        if not uid_s:
            continue
        _chat_remove_group_for_player(uid_s, group_id, queue_delete_push=True)


def _gangplank_config_payload(
    region_hint: str | None = None,
    request_host: str | None = None,
    server_ip_hint: str | None = None,
) -> dict:
    """Return config with proper server info for UI display.

    For v1.0.60: UI reads server name from gangplank-config but treats it as localization ID.
    Try providing both numeric ID and text fields, plus game server addresses.
    """
    now_ms = int(time.time() * 1000)

    gangplank_url_sg = "https://p10470-sgtest-gangplank.ejoy.com"
    gangplank_url_us = "https://p10470-ustest-gangplank.ejoy.com"
    gangplank_url_br = "https://p10470-br-gangplank.ejoy.com"
    holo_url_sg = _holo_service_base_for_region("sgtest", request_host=request_host)
    holo_url_us = _holo_service_base_for_region("ustest", request_host=request_host)
    holo_url_br = _holo_service_base_for_region("br", request_host=request_host)
    chat_host_sg = _chat_tcp_host_for_region("sgtest", request_host=request_host)
    chat_host_us = _chat_tcp_host_for_region("ustest", request_host=request_host)
    chat_host_br = _chat_tcp_host_for_region("br", request_host=request_host)
    # Keep native mapping by default (br -> br). Allow opt-in alias for experiments.
    compat_br_alias_to_ustest = (os.environ.get("COMPAT_BR_ALIAS_TO_USTEST") or "0").strip().lower() in {
        "1",
        "true",
        "yes",
    }
    gangplank_url_br_effective = gangplank_url_us if compat_br_alias_to_ustest else gangplank_url_br

    env_default_region = _canonical_region_code(os.environ.get("DEFAULT_REGION"), "")
    if env_default_region not in {"sgtest", "ustest", "br"}:
        # Default to NA/USTEST when no explicit region is configured.
        env_default_region = "ustest"

    single_region_mode = (os.environ.get("SINGLE_REGION_MODE") or "0").strip().lower() in {
        "1",
        "true",
        "yes",
    }

    # Prefer host-derived region for gangplank requests so we do not force a
    # region switch during bootstrap (which can trigger callback races).
    default_region = env_default_region if single_region_mode else _canonical_region_code(region_hint, env_default_region)
    if default_region not in {"sgtest", "ustest", "br"}:
        default_region = env_default_region

    if default_region == "sgtest":
        gangplank_url = gangplank_url_sg
        holo_url = holo_url_sg
        chat_host_default = chat_host_sg
    elif default_region == "br":
        gangplank_url = gangplank_url_br
        holo_url = holo_url_br
        chat_host_default = chat_host_br
    else:
        gangplank_url = gangplank_url_us
        holo_url = holo_url_us
        chat_host_default = chat_host_us

    # Prefer routing holo API through gangplank host in local/private setups:
    # this avoids relying on separate holo DNS redirect chain for token bootstrap.
    holo_url_override = (
        (os.environ.get("HOLO_URL") or "").strip()
        or (os.environ.get("HOLO_PUBLIC_URL") or "").strip()
    )
    holo_url_mode = (os.environ.get("HOLO_URL_MODE") or "gangplank").strip().lower()
    if holo_url_override:
        holo_url = holo_url_override.rstrip("/")
    elif holo_url_mode in {"gangplank", "gp", "same_host", "same-host"}:
        holo_url = str(gangplank_url).rstrip("/")

    request_host_norm = str(request_host or "").strip().lower()
    if ":" in request_host_norm:
        request_host_norm = request_host_norm.split(":", 1)[0].strip()

    server_ip = (os.environ.get("SERVER_IP") or "").strip()
    if not server_ip:
        server_ip = str(server_ip_hint or "").strip()
    if server_ip in {"0.0.0.0", "127.0.0.1", "localhost"}:
        server_ip = ""
    game_host = (
        (os.environ.get("GAME_HOST") or "").strip()
        or (os.environ.get("GAME_PUBLIC_HOST") or "").strip()
        or server_ip
        or request_host_norm
        or chat_host_default
    )
    chat_host_explicit = (
        (os.environ.get("CHAT_HOST") or "").strip()
        or (os.environ.get("CHAT_PUBLIC_HOST") or "").strip()
    )
    chat_host_mode = (os.environ.get("CHAT_HOST_MODE") or "game_host").strip().lower()
    if chat_host_explicit:
        chat_host = chat_host_explicit
    elif chat_host_mode in {"native", "region", "region_dns", "ejoy"}:
        chat_host = chat_host_default
    else:
        # Private/local server default: keep chat on the same reachable host as lobby.
        chat_host = str(game_host).strip() or chat_host_default
    # Optional escape hatch for legacy environments that need game_host fallback.
    if (
        (not str(chat_host or "").strip())
        and _env_truthy("CHAT_HOST_FALLBACK_TO_GAME_HOST", "0")
        and str(game_host or "").strip()
    ):
        chat_host = str(game_host).strip()
    chat_port = _safe_env_port("CHAT_PORT", 12345)

    # Ensure all regional Gangplank & Holo service URLs point to reachable game_host
    if game_host and not _env_truthy("PRESERVE_EJOY_REGIONAL_DOMAINS", "0"):
        srv_base_url = f"https://{game_host}"
        gangplank_url_sg = srv_base_url
        gangplank_url_us = srv_base_url
        gangplank_url_br = srv_base_url
        gangplank_url_br_effective = srv_base_url
        gangplank_url = srv_base_url
        holo_url_sg = srv_base_url
        holo_url_us = srv_base_url
        holo_url_br = srv_base_url
        holo_url = srv_base_url

    default_area = "SG" if default_region == "sgtest" else ("US" if default_region == "ustest" else "BR")

    def _player_info_for_region(region_code: str) -> dict:
        area_code = "SG" if region_code == "sgtest" else ("US" if region_code == "ustest" else "BR")
        return {
            "pid": "1000001",
            "player_id": "1000001",
            "playerId": "1000001",
            "server_id": "1",
            "serverId": "1",
            "server_name": "Local",
            "serverName": "Local",
            "region": region_code,
            "area": area_code,
            "level": 1,
            "roleLevel": 1,
        }

    player_infos = {
        "sgtest": _player_info_for_region("sgtest"),
        "ustest": _player_info_for_region("ustest"),
        "br": _player_info_for_region("br"),
    }

    # Lightweight compatibility aliases used by some legacy branches.
    player_infos["sg"] = player_infos["sgtest"]
    player_infos["us"] = player_infos["ustest"]
    player_infos["na"] = player_infos["ustest"]
    player_infos["us2test"] = player_infos["ustest"]

    # Keep singular shapes flat (selected region only). Some SDK bridges fail
    # when player_info/playerInfo are inflated into map-like structures.
    top_player_info = dict(player_infos[default_region])

    row_player_info_sg = dict(player_infos["sgtest"])
    row_player_info_us = dict(player_infos["ustest"])
    row_player_info_br = dict(player_infos["br"])

    vanguard_regions = [
        {"region": "sgtest", "vanguardSvr": "https://vanguard.aligames.com", "default": default_region == "sgtest"},
        {"region": "ustest", "vanguardSvr": "https://vanguard.aligames.com", "default": default_region == "ustest"},
        {"region": "br", "vanguardSvr": "https://vanguard.aligames.com", "default": default_region == "br"},
    ]

    # Game server address: use LAN ip:port for direct TCP connections
    game_port = int(os.environ.get("GAME_PORT", "12000"))
    realm_addr = f"{game_host}:{game_port}"

    payload = {
        "product": "P10470",
        "ts": now_ms,
        "region": default_region,
        "area": default_area,
        "gangplank": gangplank_url,
        "holo": holo_url,
        "chat_host": chat_host,
        "chatHost": chat_host,
        "chat_port": chat_port,
        "chatPort": chat_port,
        "user-info": holo_url,
        "user_info": holo_url,
        "user-info-url": holo_url,
        "user_info_url": holo_url,
        "user_info_svr": holo_url,
        "user_info_svr_url": holo_url,
        "player_info": top_player_info,
        "playerInfo": top_player_info,
        "player_infos": player_infos,
        "playerInfos": player_infos,
        "gangplank-config": [
            {
                "area": "SG",
                "region": "sgtest",
                "player_info": row_player_info_sg,
                "playerInfo": row_player_info_sg,
                "player_infos": player_infos,
                "playerInfos": player_infos,
                # Try different name formats - UI might use different field
                "id": 1,  # Numeric ID
                "name": "Local Server",
                "serverName": "Local Server",
                "server_name": "Local Server",
                "nameText": "Local Server",  # Fallback text
                "serverNameText": "Local Server",
                "displayName": "Local Server",
                "desc": "Local development server",
                "description": "Local development server",
                # Status fields
                "status": 0,
                "state": 0,
                "server_status": 0,
                "serverState": 0,
                "open": True,
                "online": True,
                "maintenance": 0,
                "maintain": 0,
                "is_maintain": False,
                "isMaintenance": False,
                "maint": False,
                # URLs
                "url": gangplank_url_sg,
                "gangplank": gangplank_url_sg,
                "holo": holo_url,
                "chat_host": chat_host,
                "chatHost": chat_host,
                "chat_port": chat_port,
                "chatPort": chat_port,
                "user-info": holo_url,
                "user_info": holo_url,
                "user-info-url": holo_url,
                "user_info_url": holo_url,
                "user_info_svr": holo_url,
                "user_info_svr_url": holo_url,
                "account_center": "https://ww-hk-id-api.qookkagames.com",
                "payment_center": "https://ww-hk-pay-api.qookkagames.com",
                "qookka_center": "https://hk-account.qookkagames.com",
                # Game server addresses (critical for Lua init)
                "host": game_host,
                "ip": game_host,
                "port": game_port,
                "realm": game_host,
                "realms": [game_host],
                "realm_addr": game_host,
                "realmAddr": game_host,
                "game_host": game_host,
                "game_port": game_port,
                "game_realm": game_host,
                "game_realm_addr": game_host,
                "gameRealmAddr": game_host,
                "ip_port": game_host,
                "ipPort": game_host,
                "realm_port": game_port,
                "game_realm_port": game_port,
                "default": default_region == "sgtest",
            },
            {
                "area": "US",
                "region": "ustest",
                "player_info": row_player_info_us,
                "playerInfo": row_player_info_us,
                "player_infos": player_infos,
                "playerInfos": player_infos,
                "id": 2,
                "name": "US Test Server",
                "serverName": "US Test Server",
                "server_name": "US Test Server",
                "nameText": "US Test Server",
                "serverNameText": "US Test Server",
                "displayName": "US Test Server",
                "desc": "US test development server",
                "description": "US test development server",
                "status": 0,
                "state": 0,
                "server_status": 0,
                "serverState": 0,
                "open": True,
                "online": True,
                "maintenance": 0,
                "maintain": 0,
                "is_maintain": False,
                "isMaintenance": False,
                "maint": False,
                "url": gangplank_url_us,
                "gangplank": gangplank_url_us,
                "holo": holo_url,
                "chat_host": chat_host,
                "chatHost": chat_host,
                "chat_port": chat_port,
                "chatPort": chat_port,
                "user-info": holo_url,
                "user_info": holo_url,
                "user-info-url": holo_url,
                "user_info_url": holo_url,
                "user_info_svr": holo_url,
                "user_info_svr_url": holo_url,
                "account_center": "https://ww-hk-id-api.qookkagames.com",
                "payment_center": "https://ww-hk-pay-api.qookkagames.com",
                "qookka_center": "https://hk-account.qookkagames.com",
                "host": game_host,
                "ip": game_host,
                "port": game_port,
                "realm": game_host,
                "realms": [game_host],
                "realm_addr": game_host,
                "realmAddr": game_host,
                "game_host": game_host,
                "game_port": game_port,
                "game_realm": game_host,
                "game_realm_addr": game_host,
                "gameRealmAddr": game_host,
                "ip_port": game_host,
                "ipPort": game_host,
                "realm_port": game_port,
                "game_realm_port": game_port,
                "default": default_region == "ustest",
            },
            {
                # Some locales resolve to region=br during gangplank probing.
                # If this region is missing, login init loops forever.
                "area": "BR",
                "region": "br",
                "player_info": row_player_info_br,
                "playerInfo": row_player_info_br,
                "player_infos": player_infos,
                "playerInfos": player_infos,
                "id": 3,
                "name": "BR Test Server",
                "serverName": "BR Test Server",
                "server_name": "BR Test Server",
                "nameText": "BR Test Server",
                "serverNameText": "BR Test Server",
                "displayName": "BR Test Server",
                "desc": "BR test development server",
                "description": "BR test development server",
                "status": 0,
                "state": 0,
                "server_status": 0,
                "serverState": 0,
                "open": True,
                "online": True,
                "maintenance": 0,
                "maintain": 0,
                "is_maintain": False,
                "isMaintenance": False,
                "maint": False,
                "url": gangplank_url_br_effective,
                "gangplank": gangplank_url_br_effective,
                "holo": holo_url,
                "chat_host": chat_host,
                "chatHost": chat_host,
                "chat_port": chat_port,
                "chatPort": chat_port,
                "user-info": holo_url,
                "user_info": holo_url,
                "user-info-url": holo_url,
                "user_info_url": holo_url,
                "user_info_svr": holo_url,
                "user_info_svr_url": holo_url,
                "account_center": "https://ww-hk-id-api.qookkagames.com",
                "payment_center": "https://ww-hk-pay-api.qookkagames.com",
                "qookka_center": "https://hk-account.qookkagames.com",
                "host": game_host,
                "ip": game_host,
                "port": game_port,
                "realm": game_host,
                "realms": [game_host],
                "realm_addr": game_host,
                "realmAddr": game_host,
                "game_host": game_host,
                "game_port": game_port,
                "game_realm": game_host,
                "game_realm_addr": game_host,
                "gameRealmAddr": game_host,
                "ip_port": game_host,
                "ipPort": game_host,
                "realm_port": game_port,
                "game_realm_port": game_port,
                "default": default_region == "br",
            }
        ],
        # Additional server list at top level in case Lua reads it there
        "servers": [
            {
                "id": 1,
                "name": "Local",
                "host": game_host,
                "port": game_port,
            }
        ],
        "vanguard-config": {"regions": vanguard_regions},
        "vanguardConfig": {"regions": vanguard_regions},
    }

    # Keep multi-region rows by default; OFFICIAL init can fail with
    # "get region failed in config: br" if br row is absent.
    if single_region_mode:
        rows = payload.get("gangplank-config") or []
        selected = next(
            (row for row in rows if str(row.get("region", "")).strip().lower() == default_region),
            None,
        )
        if selected is None and rows:
            selected = rows[0]

        if selected is not None:
            selected_region = str(selected.get("region") or default_region).strip().lower() or default_region
            selected_area = str(selected.get("area") or default_area).strip() or default_area

            for row in rows:
                row["default"] = row is selected

            payload["gangplank-config"] = rows
            payload["region"] = selected_region
            payload["area"] = selected_area
            payload["gangplank"] = str(
                selected.get("gangplank") or selected.get("url") or payload.get("gangplank") or gangplank_url
            )
            payload["holo"] = str(selected.get("holo") or payload.get("holo") or holo_url)
            payload["search"] = payload["holo"]
            payload["friend"] = payload["holo"]
            payload["user-info"] = payload["holo"]
            payload["user_info"] = payload["holo"]
            payload["user-info-url"] = payload["holo"]
            payload["user_info_url"] = payload["holo"]
            payload["user_info_svr"] = payload["holo"]
            payload["user_info_svr_url"] = payload["holo"]
            payload["chat_host"] = str(selected.get("chat_host") or selected.get("chatHost") or payload.get("chat_host") or chat_host)
            payload["chatHost"] = payload["chat_host"]
            try:
                selected_chat_port = int(selected.get("chat_port") or selected.get("chatPort") or payload.get("chat_port") or chat_port)
            except Exception:
                selected_chat_port = chat_port
            payload["chat_port"] = selected_chat_port
            payload["chatPort"] = selected_chat_port
            if selected_region in player_infos:
                selected_top_player_info = dict(player_infos[selected_region])
                payload["player_info"] = selected_top_player_info
                payload["playerInfo"] = selected_top_player_info
                payload["player_infos"] = player_infos
                payload["playerInfos"] = player_infos

            vanguard_single = [
                {
                    "region": selected_region,
                    "vanguardSvr": "https://vanguard.aligames.com",
                    "default": True,
                }
            ]
            payload["vanguard-config"] = {"regions": vanguard_single}
            payload["vanguardConfig"] = {"regions": vanguard_single}

    return payload


def _launcher_server_list_detail_payload(host: str, realm_host: str, game_port: int) -> dict:
    """Build a permissive launcher server list payload.

    Some client flows fetch server rows from launcher ann/realm/detail and use
    them to populate LoginCtrl models. If this payload is absent or malformed,
    UI can fall back to maintenance/default placeholders.
    """
    region_code = _infer_region_from_host(host) or "sgtest"
    region_code = str(region_code).strip().lower() or "sgtest"
    area = "SG" if region_code in {"sg", "sgtest"} else region_code.upper()

    sdk_server_name = _sdk_server_name_for_region(region_code)
    server = {
        "id": "1",
        "serverId": "1",
        "server_id": "1",
        "sid": "1",
        "zoneId": "1",
        "zone_id": "1",
        "name": "Local",
        "serverName": "Local",
        "server_name": "Local",
        "sdkServerName": sdk_server_name,
        "sdk_server_name": sdk_server_name,
        "ip": realm_host,
        "host": realm_host,
        "port": int(game_port),
        "region": region_code,
        "area": area,
        "status": 0,
        "state": 0,
        "server_status": 0,
        "serverState": 0,
        "maintenance": 0,
        "maintain": 0,
        "is_maintain": False,
        "isMaintenance": False,
        "open": True,
        "online": True,
        "recommend": True,
        "desc": "Local server",
        "description": "Local server",
        "notice": "",
        "announcement": "",
    }

    return {
        "code": 0,
        "status": 0,
        "ret": 0,
        "success": True,
        "msg": "ok",
        "default_server": "1",
        "defaultServer": "1",
        "servers": [server],
        "server_list": [server],
        "serverList": [server],
        "realms": [server],
        "list": [server],
        "data": {
            "default_server": "1",
            "defaultServer": "1",
            "servers": [server],
            "server_list": [server],
        },
    }


def _default_server_entry(realm_host: str, game_port: int, region_code: str | None = None) -> dict:
    import services.utils as utils
    return utils._default_server_entry(realm_host, game_port, region_code)
def _normalize_server_entries(raw_servers: object, realm_host: str, game_port: int, region_code: str | None = None) -> tuple[list[dict], list[str]]:
    import services.utils as utils
    return utils._normalize_server_entries(raw_servers, realm_host, game_port, region_code)
def _log_contract_snapshot(endpoint: str, payload: dict):
    import services.utils as utils
    return utils._log_contract_snapshot(endpoint, payload)
def _ensure_alive_servers_contract(resp: dict, realm_host: str, game_port: int, region_code: str | None = None) -> dict:
    import services.utils as utils
    return utils._ensure_alive_servers_contract(resp, realm_host, game_port, region_code)
def _ensure_auth_contract(resp: dict, endpoint: str, realm_host: str, game_port: int) -> dict:
    import services.utils as utils
    return utils._ensure_auth_contract(resp, endpoint, realm_host, game_port)
def _file_md5(path: Path) -> str:
    h = hashlib.md5()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def _get_version_md5() -> str | None:
    global _VERSION_MD5
    if _VERSION_MD5 is not None:
        return _VERSION_MD5
    if not VERSION_FILE.is_file():
        _VERSION_MD5 = None
        return None
    _VERSION_MD5 = _file_md5(VERSION_FILE)
    return _VERSION_MD5


def _load_version_index() -> dict[str, str]:
    """Parse assets/File/VERSION and map md5 -> relative path.

    Some client builds request resources by md5, i.e. /File/<md5>, not by
    /File/<relativeFolder>/<name>. We already special-case VersionMD5 to serve
    VERSION; this extends it to any entry present in VERSION.
    """
    global _VERSION_INDEX, _VERSION_INDEX_MTIME_NS

    if not VERSION_FILE.is_file():
        _VERSION_INDEX = {}
        _VERSION_INDEX_MTIME_NS = None
        return _VERSION_INDEX

    try:
        st = VERSION_FILE.stat()
        mtime_ns = getattr(st, "st_mtime_ns", None) or int(st.st_mtime * 1e9)
    except Exception:
        mtime_ns = None

    if _VERSION_INDEX is not None and mtime_ns is not None and _VERSION_INDEX_MTIME_NS == mtime_ns:
        return _VERSION_INDEX

    index: dict[str, str] = {}
    try:
        text = VERSION_FILE.read_text(encoding="utf-8", errors="replace")
    except Exception:
        _VERSION_INDEX = {}
        _VERSION_INDEX_MTIME_NS = mtime_ns
        return _VERSION_INDEX

    cur_name: str | None = None
    cur_md5: str | None = None
    cur_folder: str | None = None

    def commit():
        nonlocal cur_name, cur_md5, cur_folder
        if not cur_name or not cur_md5 or not cur_folder:
            cur_name = cur_md5 = cur_folder = None
            return
        md5_lc = cur_md5.strip().lower()
        if not HEX32_RE.match(md5_lc):
            cur_name = cur_md5 = cur_folder = None
            return
        rel = f"{cur_folder.strip().strip('/')}/{cur_name.strip().lstrip('/')}"
        index[md5_lc] = rel
        cur_name = cur_md5 = cur_folder = None

    for raw in text.splitlines():
        line = raw.strip()
        if not line:
            continue
        if line.startswith("- name:"):
            commit()
            cur_name = line.split(":", 1)[1].strip()
        if cur_name and line.startswith("md5:"):
            cur_md5 = line.split(":", 1)[1].strip()
        if cur_name and line.startswith("relativeFolder:"):
            cur_folder = line.split(":", 1)[1].strip()
    commit()

    _VERSION_INDEX = index
    _VERSION_INDEX_MTIME_NS = mtime_ns
    return _VERSION_INDEX


class Handler(SimpleHTTPRequestHandler):
    def __init__(self, *a, **kw):
        super().__init__(*a, directory=str(DIR), **kw)

    def log_message(self, fmt, *args):
        msg = "%s - - [%s] %s" % (self.address_string(), self.log_date_time_string(), fmt % args)
        print(_console_safe(msg))
        _append_utf8_log(msg)

    def _host_no_port(self) -> str:
        host = (self.headers.get("Host") or "").strip().lower()
        if ":" in host:
            host = host.split(":", 1)[0]
        return host

    def _server_ip(self) -> str | None:
        """Best-effort LAN IP of this server as seen by the client.

        Prefer explicit SERVER_IP env var. Otherwise use the local socket address
        that accepted the current HTTP request (works well when the phone connects
        to this PC's LAN IP).
        """
        env_ip = (os.environ.get("SERVER_IP") or "").strip()
        if env_ip:
            return env_ip
        try:
            ip = (self.connection.getsockname()[0] or "").strip()
        except Exception:
            ip = ""
        if ip and ip not in {"0.0.0.0", "127.0.0.1"}:
            return ip
        return None

    def _realm_host_for_client(self) -> str:
        # Prefer a raw IP to avoid depending on device DNS overrides for TCP.
        return self._server_ip() or self._host_no_port() or "127.0.0.1"

    def _send_bytes(self, body: bytes, content_type: str = "application/octet-stream"):
        self._send_body(body, status=200, content_type=content_type)

    def _send_body(
        self,
        body: bytes,
        *,
        status: int = 200,
        content_type: str = "application/octet-stream",
        extra_headers: dict[str, str] | None = None,
        allow_range: bool = True,
    ):
        full_len = len(body)
        status_code = status
        body_out = body
        header_map: dict[str, str] = {"Accept-Ranges": "bytes" if allow_range else "none"}

        if status == 200 and allow_range:
            range_info = _parse_single_range_header(self.headers.get("Range"), full_len)
            if range_info == "unsat":
                self.send_response(416)
                self.send_header("Content-Type", content_type)
                self.send_header("Accept-Ranges", "bytes")
                self.send_header("Content-Range", f"bytes */{full_len}")
                self.send_header("Content-Length", "0")
                self.end_headers()
                return
            if isinstance(range_info, tuple):
                start, end = range_info
                body_out = body[start : end + 1]
                status_code = 206
                header_map["Content-Range"] = f"bytes {start}-{end}/{full_len}"

        if extra_headers:
            for k, v in extra_headers.items():
                if v is None:
                    continue
                header_map[str(k)] = str(v)

        self.send_response(status_code)
        self.send_header("Content-Type", content_type)
        self.send_header("Content-Length", str(len(body_out)))
        for k, v in header_map.items():
            self.send_header(k, v)
        self.end_headers()
        if body_out and self.command != "HEAD":
            try:
                self.wfile.write(body_out)
            except (BrokenPipeError, ConnectionResetError):
                pass

    def _send_json(
        self,
        obj,
        status: int = 200,
        *,
        content_type: str = "application/json; charset=utf-8",
        extra_headers: dict[str, str] | None = None,
    ):
        body = json.dumps(obj, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
        self._send_body(body, status=status, content_type=content_type, extra_headers=extra_headers)

    def _vanguard_token(self) -> str:
        token = (os.environ.get("VANGUARD_TOKEN") or "localtoken").strip()
        return token if token else "localtoken"

    def _vanguard_key1(self, token: str) -> bytes:
        # Mirror client logic in app_dec/smali/a/b/l/d.smali:
        # key1 = MD5(token + "1.0.2")
        s = f"{token}1.0.2".encode("utf-8")
        return hashlib.md5(s).digest()

    def _qookka_stub_payload(self) -> dict:
        """Permissive Qookka backend stub.

        Some builds fetch additional game configuration (including lobby endpoints)
        from *.qookkagames.com hosts provided by gangplank-config.
        We return a success envelope plus redundant ip/port/realm fields so the
        client can pick whichever keys it expects.
        """

        realm_host = self._realm_host_for_client()
        realm = f"{realm_host}:{GAME_PORT}"
        server_obj = {
            "ip": realm_host,
            "host": realm_host,
            "port": GAME_PORT,
            "realm": realm_host,
            "realms": [realm_host],
            "realm_addr": realm,
            "realmAddr": realm,
        }
        return {
            "code": 0,
            "ret": 0,
            "status": 0,
            "success": True,
            "msg": "ok",
            "result": 0,
            # Redundant top-level hints (in case client reads directly)
            "ip": realm_host,
            "host": realm_host,
            "port": GAME_PORT,
            "realm": realm_host,
            "realms": [realm_host],
            "realm_addr": realm,
            "realmAddr": realm,
            "server": server_obj,
            "servers": [server_obj],
            # Usual payload container
            "data": {
                **server_obj,
                "server": server_obj,
                "servers": [server_obj],
            },
        }

    def _header_value(self, *keys: str) -> str:
        for key in keys:
            val = self.headers.get(key)
            if val is None:
                continue
            val_s = str(val).strip()
            if val_s:
                return val_s
        return ""

    def _resolve_player_id_from_request(self, req_json: dict | None = None) -> str:
        req_json = req_json if isinstance(req_json, dict) else {}

        moment_token = self._header_value("moment-Token", "moment-token")
        if moment_token:
            payload = _holo_player_token_by_moment_token(moment_token)
            if isinstance(payload, dict):
                return _uid_str(payload.get("player_id") or payload.get("playerId") or payload.get("uid"))

        ejoy_token = self._header_value("Ejoy-Token", "ejoy-token", "Token", "token", "x-token")
        pid_by_token = _gp_player_id_from_token(ejoy_token)
        if pid_by_token:
            return _uid_str(pid_by_token)

        path = getattr(self, "path", "")
        # For friend action endpoints, req_json['player_id'] represents the target/applicant argument, not caller
        is_friend_action = any(act in path for act in ("/add_friend_apply", "/accept_friend_apply", "/refuse_friend_apply", "/del_friend", "/del_friend_apply"))

        if not is_friend_action:
            for key in (
                "player_id",
                "playerId",
                "uid",
                "user_id",
                "account_id",
                "accountId",
                "pid",
            ):
                if key in req_json:
                    value = _uid_str(req_json.get(key), "")
                    if value:
                        return value

            query = parse_qs(urlparse(self.path).query or "")
            for key in ("player_id", "playerId", "uid", "user_id", "account_id", "accountId", "pid"):
                value = _uid_str((query.get(key) or [""])[0], "")
                if value:
                    return value

        try:
            local_pd = globals().get("_player_data")
            if isinstance(local_pd, dict):
                val = _uid_str(local_pd.get("uid"))
                if val:
                    return val
        except Exception:
            pass
        return "1000001"

    def _online_player_snapshot(self, uid: object) -> dict[str, object]:
        local_pd = globals().get("_player_data")
        if not isinstance(local_pd, dict):
            local_pd = None
        profile = _online_ensure_profile(uid, local_pd=local_pd)
        uid_s = _uid_str(profile.get("uid"), "1000001")
        uid_i = max(1, _safe_int(uid_s, 1000001))
        import services.chat as chat_service
        cur_state = chat_service.get_player_state(uid_s)
        is_online = (cur_state != 0)
        info = {
            "player_id": uid_s,
            "playerId": uid_s,
            "user_id": uid_s,
            "id": uid_s,
            "uid": uid_s,
            "name": str(profile.get("name") or f"Player{uid_s[-4:]}"),
            "fbname": str(profile.get("name") or f"Player{uid_s[-4:]}"),
            "level": max(1, _safe_int(profile.get("level"), 1)),
            "icon": max(0, _safe_int(profile.get("icon"), 0)),
            "icon_url": str(profile.get("icon_url") or ""),
            "rank_score": max(0, _safe_int(profile.get("rank_score"), 0)),
            "state": cur_state,
        }
        out = {
            "player_id": uid_s,
            "playerId": uid_s,
            "user_id": uid_s,
            "id": uid_s,
            "uid": uid_s,
            "account": uid_s,
            "account_id": uid_s,
            "name": info["name"],
            "fbname": info.get("fbname", info["name"]),
            "level": info["level"],
            "icon": info["icon"],
            "icon_url": info["icon_url"],
            "rank_score": info.get("rank_score", 0),
            "state": cur_state,
            "is_online": is_online,
            "is_in_battle": cur_state in (6, 7),
            "is_allow_watch": True,
            "rank_level": info.get("rank_score", 0) // 100,
            "update_time": max(1, _safe_int(profile.get("update_time"), _online_now_ts())),
            "player_info": info,
        }
        return out

    def _handle_online_social_api(self, path: str, host: str, body: bytes | None = None) -> bool:
        _ = host
        req_json: dict[str, object] = {}
        if body:
            try:
                parsed = json.loads(body.decode("utf-8", errors="replace"))
                if isinstance(parsed, dict):
                    req_json = parsed
            except Exception:
                req_json = {}

        # Merge query parameters into req_json so GET-based search endpoints work.
        query_params = parse_qs(urlparse(self.path).query or "")
        for key, values in query_params.items():
            if key in req_json and req_json[key] not in (None, ""):
                continue
            if len(values) == 1:
                req_json[key] = values[0]
            else:
                req_json[key] = values

        # --- FRIEND ROUTER INJECTION ---
        caller_uid_int = self._resolve_player_id_from_request(req_json)
        import routers.friend
        res = routers.friend.handle_route(path, req_json, caller_uid_int)
        if res is not None:
            st_code, st_msg, d_obj = res
            self._send_json({"code": 0, "status": st_code, "ret": st_code, "success": True, "msg": st_msg, **d_obj})
            return True
        # -------------------------------

        def _send_ok(payload: dict[str, object]) -> None:
            resp = {
                "code": 0,
                "status": 0,
                "ret": 0,
                "success": True,
                "msg": "ok",
                **payload,
            }
            data_obj = payload.get("data")
            if not isinstance(data_obj, dict):
                mirrored = {k: v for k, v in payload.items() if k != "data"}
                resp["data"] = mirrored
            self._send_json(resp)

        local_pd = globals().get("_player_data")
        if not isinstance(local_pd, dict):
            local_pd = None
        _online_touch_local_profile(local_pd)

        if path == "/ga/client_api/get_account_infos":
            account_ids_raw = req_json.get("account_ids")
            account_ids = account_ids_raw if isinstance(account_ids_raw, list) else []
            if not account_ids:
                account_ids = [self._resolve_player_id_from_request(req_json)]
            account_list: list[dict[str, object]] = []
            now = _online_now_ts()
            for account_id in account_ids[:200]:
                uid_s = _uid_str(account_id, "")
                if not uid_s:
                    continue
                profile = self._online_player_snapshot(uid_s)
                account_list.append(
                    {
                        "account_id": uid_s,
                        "accountId": uid_s,
                        "channel": "local",
                        "official_info": {
                            "last_login_player": uid_s,
                            "nickname": str(profile.get("name") or ""),
                        },
                        "update_time": now,
                    }
                )
            _send_ok({"account_list": account_list, "data": {"account_list": account_list}})
            return True

        if path == "/player_api/get_player_info_list":
            player_ids_raw = req_json.get("player_id_list")
            player_ids = player_ids_raw if isinstance(player_ids_raw, list) else []
            if not player_ids:
                player_ids = [self._resolve_player_id_from_request(req_json)]
            player_list = [self._online_player_snapshot(uid) for uid in player_ids[:300]]
            _send_ok({"player_list": player_list, "data": {"player_list": player_list}})
            return True

        if path == "/player_search":
            search_data = str(req_json.get("search_data") or "").strip().lower()
            caller_uid = self._resolve_player_id_from_request(req_json)
            _online_ensure_profile(caller_uid, local_pd=local_pd)
            matches: list[dict[str, object]] = []
            with _ONLINE_LOCK:
                profiles = _ONLINE_STATE.get("profiles")
                if isinstance(profiles, dict):
                    for uid_s, pobj in profiles.items():
                        if not isinstance(pobj, dict):
                            continue
                        name_s = str(pobj.get("name") or "").lower()
                        if search_data and (search_data not in uid_s.lower()) and (search_data not in name_s):
                            continue
                        matches.append(self._online_player_snapshot(uid_s))
            if not matches:
                matches = [self._online_player_snapshot(caller_uid)]
            _send_ok({"player_info_list": matches[:50], "data": {"player_info_list": matches[:50]}})
            return True

        if path == "/global_player_search":
            caller_uid = self._resolve_player_id_from_request(req_json)
            _online_ensure_profile(caller_uid, local_pd=local_pd)
            search_data = str(req_json.get("search_data") or "").strip()
            search_id = "search_" + hashlib.md5(
                f"{caller_uid}:{search_data}:{int(time.time() * 1000)}".encode("utf-8")
            ).hexdigest()[:16]
            _send_ok(
                {
                    "search_id": search_id,
                    "region_count": 1,
                    "player_info_list": [],
                    "data": {"search_id": search_id, "region_count": 1, "player_info_list": []},
                }
            )
            return True

        if path.startswith("/friend/"):
            caller_uid = self._resolve_player_id_from_request(req_json)
            _online_ensure_profile(caller_uid, local_pd=local_pd)

            if path == "/friend/get_friend_id_list":
                friend_ids = _online_get_uid_list("friends", caller_uid)
                _send_ok({"friend_id_list": friend_ids, "data": {"friend_id_list": friend_ids}})
                return True

            if path == "/friend/get_friend_info_list":
                friend_ids = _online_get_uid_list("friends", caller_uid)
                friend_list: list[dict[str, object]] = []
                for uid in friend_ids:
                    snap = self._online_player_snapshot(uid)
                    pinfo = snap.get("player_info") if isinstance(snap.get("player_info"), dict) else {}
                    friend_list.append(
                        {
                            "user_id": uid,
                            "player_id": uid,
                            "name": str(snap.get("name") or ""),
                            "level": max(1, _safe_int(snap.get("level"), 1)),
                            "icon": max(0, _safe_int(snap.get("icon"), 0)),
                            "icon_url": str(snap.get("icon_url") or ""),
                            "rank_score": max(0, _safe_int(pinfo.get("rank_score") if isinstance(pinfo, dict) else 0, 0)),
                            "online": True,
                            "last_login_time": max(1, _safe_int(snap.get("update_time"), _online_now_ts())),
                        }
                    )
                _send_ok({"friend_list": friend_list, "data": {"friend_list": friend_list}})
                return True

            if path in {"/friend/get_friend_apply_list", "/friend/v2.0/get_friend_apply_list", "/friend/v2.0/get_new_friend_apply_list"}:
                state_filter: set[int] = set()
                state_raw = req_json.get("state")
                if isinstance(state_raw, list):
                    for value in state_raw:
                        state_filter.add(_safe_int(value, 0))
                elif state_raw is not None:
                    state_filter.add(_safe_int(state_raw, 0))
                if not state_filter:
                    state_filter = {0, 1, 2}

                last_index_time = _safe_int(req_json.get("last_index_time"), _safe_int(req_json.get("last_time_index"), 0))
                friend_apply_list: list[dict[str, object]] = []
                now_ts = _online_now_ts()
                with _ONLINE_LOCK:
                    applies_bucket = _ONLINE_STATE.get("friend_applies")
                    raw_list = []
                    if isinstance(applies_bucket, dict):
                        raw = applies_bucket.get(caller_uid)
                        if isinstance(raw, list):
                            raw_list = raw
                    if last_index_time <= 0:
                        for item in raw_list:
                            if not isinstance(item, dict):
                                continue
                            st = _safe_int(item.get("state"), 0)
                            if st not in state_filter:
                                continue
                            friend_apply_list.append(dict(item))
                if last_index_time > 0:
                    friend_apply_list = []
                _send_ok(
                    {
                        "last_index_time": now_ts,
                        "last_indexTime": now_ts,
                        "friend_apply_list": friend_apply_list,
                        "data": {
                            "last_index_time": now_ts,
                            "last_indexTime": now_ts,
                            "friend_apply_list": friend_apply_list,
                        },
                    }
                )
                return True

            if path in {"/friend/get_friend_to_apply_list", "/friend/v2.0/get_friend_to_apply_list"}:
                last_index_time = _safe_int(req_json.get("last_index_time"), _safe_int(req_json.get("last_time_index"), 0))
                out_list: list[dict[str, object]] = []
                now_ts = _online_now_ts()
                if last_index_time <= 0:
                    with _ONLINE_LOCK:
                        applies_bucket = _ONLINE_STATE.get("friend_applies")
                        if isinstance(applies_bucket, dict):
                            for target_uid, raw_list in applies_bucket.items():
                                if not isinstance(raw_list, list):
                                    continue
                                for item in raw_list:
                                    if not isinstance(item, dict):
                                        continue
                                    if _uid_str(item.get("user_id"), "") != caller_uid:
                                        continue
                                    to_apply = dict(item)
                                    to_apply["user_id"] = _uid_str(target_uid, "")
                                    out_list.append(to_apply)
                _send_ok(
                    {
                        "last_index_time": now_ts,
                        "last_indexTime": now_ts,
                        "friend_apply_list": out_list,
                        "data": {
                            "last_index_time": now_ts,
                            "last_indexTime": now_ts,
                            "friend_apply_list": out_list,
                        },
                    }
                )
                return True

            if path == "/friend/add_friend_apply" or path == "/friend/v2.0/add_friend_apply":
                target_uid = _uid_str(req_json.get("player_id"), "")
                content = str(req_json.get("content") or "")
                if target_uid and target_uid != caller_uid:
                    _online_ensure_profile(target_uid)
                    apply_entry = {
                        "apply_id": 0,
                        "user_id": caller_uid,
                        "state": 0,
                        "content": content,
                        "create_time": _online_now_ts(),
                        "last_index_time": _online_now_ts(),
                    }
                    changed = False
                    with _ONLINE_LOCK:
                        next_apply_id = max(1, _safe_int(_ONLINE_STATE.get("next_apply_id"), 1))
                        apply_entry["apply_id"] = next_apply_id
                        _ONLINE_STATE["next_apply_id"] = next_apply_id + 1
                        applies_bucket = _ONLINE_STATE.get("friend_applies")
                        if not isinstance(applies_bucket, dict):
                            applies_bucket = {}
                            _ONLINE_STATE["friend_applies"] = applies_bucket
                        target_list = applies_bucket.get(target_uid)
                        if not isinstance(target_list, list):
                            target_list = []
                            applies_bucket[target_uid] = target_list
                        exists = False
                        for item in target_list:
                            if not isinstance(item, dict):
                                continue
                            if _uid_str(item.get("user_id"), "") == caller_uid and _safe_int(item.get("state"), 0) == 0:
                                exists = True
                                break
                        if not exists:
                            target_list.append(apply_entry)
                            changed = True
                    if changed:
                        _save_online_state()
                _send_ok({"data": {}})
                return True

            if path == "/friend/accept_friend_apply":
                source_uid = _uid_str(req_json.get("player_id"), "")
                if source_uid and source_uid != caller_uid:
                    _online_ensure_profile(source_uid)
                    _online_add_uid("friends", caller_uid, source_uid)
                    _online_add_uid("friends", source_uid, caller_uid)
                    changed = False
                    with _ONLINE_LOCK:
                        applies_bucket = _ONLINE_STATE.get("friend_applies")
                        if isinstance(applies_bucket, dict):
                            target_list = applies_bucket.get(caller_uid)
                            if isinstance(target_list, list):
                                new_list = []
                                for item in target_list:
                                    if not isinstance(item, dict):
                                        continue
                                    if _uid_str(item.get("user_id"), "") == source_uid:
                                        changed = True
                                    new_list.append(item)
                                if len(new_list) != len(target_list):
                                    applies_bucket[caller_uid] = new_list
                    if changed:
                        _save_online_state()
                _send_ok({"data": {}})
                return True

            if path in {"/friend/refuse_friend_apply", "/friend/del_friend_apply"}:
                source_uid = _uid_str(req_json.get("player_id"), "")
                if source_uid:
                    changed = False
                    with _ONLINE_LOCK:
                        applies_bucket = _ONLINE_STATE.get("friend_applies")
                        if isinstance(applies_bucket, dict):
                            target_list = applies_bucket.get(caller_uid)
                            if isinstance(target_list, list):
                                new_list = []
                                for item in target_list:
                                    if not isinstance(item, dict):
                                        continue
                                    if _uid_str(item.get("user_id"), "") == source_uid:
                                        changed = True
                                    new_list.append(item)
                                if len(new_list) != len(target_list):
                                    applies_bucket[caller_uid] = new_list
                    if changed:
                        _save_online_state()
                _send_ok({"data": {}})
                return True

            if path == "/friend/del_friend":
                target_uid = _uid_str(req_json.get("friend_player_id"), "")
                if target_uid:
                    _online_remove_uid("friends", caller_uid, target_uid)
                    _online_remove_uid("friends", target_uid, caller_uid)
                _send_ok({"data": {}})
                return True

            if path == "/friend/add_friend_black":
                target_uid = _uid_str(req_json.get("player_id"), "")
                if target_uid:
                    _online_add_uid("friend_black", caller_uid, target_uid)
                _send_ok({"data": {}})
                return True

            if path == "/friend/del_friend_black":
                target_uid = _uid_str(req_json.get("player_id"), "")
                if target_uid:
                    _online_remove_uid("friend_black", caller_uid, target_uid)
                _send_ok({"data": {}})
                return True

            if path in {"/friend/get_friend_black_list", "/friend/v2.0/get_friend_black_list"}:
                black_ids = _online_get_uid_list("friend_black", caller_uid)
                black_list: list[dict[str, object]] = []
                for uid in black_ids:
                    snap = self._online_player_snapshot(uid)
                    black_list.append(
                        {
                            "user_id": uid,
                            "player_id": uid,
                            "name": str(snap.get("name") or ""),
                            "level": max(1, _safe_int(snap.get("level"), 1)),
                            "icon": max(0, _safe_int(snap.get("icon"), 0)),
                            "icon_url": str(snap.get("icon_url") or ""),
                        }
                    )
                _send_ok({"friend_black_list": black_list, "data": {"friend_black_list": black_list}})
                return True

            if path in {"/friend/channel/v1.0/get_friend_list", "/friend/channel/v1.0/refresh_friend_list"}:
                user_list: list[dict[str, object]] = []
                _send_ok({"user_list": user_list, "data": {"user_list": user_list}})
                return True

            if path == "/friend/v2.0/get_friend_list":
                friend_ids = _online_get_uid_list("friends", caller_uid)
                friend_list: list[dict[str, object]] = []
                for uid in friend_ids:
                    snap = self._online_player_snapshot(uid)
                    pinfo = snap.get("player_info") if isinstance(snap.get("player_info"), dict) else {}
                    friend_list.append(
                        {
                            "user_id": uid,
                            "player_id": uid,
                            "name": str(snap.get("name") or ""),
                            "level": max(1, _safe_int(snap.get("level"), 1)),
                            "icon": max(0, _safe_int(snap.get("icon"), 0)),
                            "icon_url": str(snap.get("icon_url") or ""),
                            "rank_score": max(0, _safe_int(pinfo.get("rank_score") if isinstance(pinfo, dict) else 0, 0)),
                            "online": True,
                            "last_login_time": max(1, _safe_int(snap.get("update_time"), _online_now_ts())),
                        }
                    )
                _send_ok({"friend_list": friend_list, "data": {"friend_list": friend_list}})
                return True

            if path == "/friend/v2.0/get_friend_group_member":
                _send_ok({"group_member_list": [], "data": {"group_member_list": []}})
                return True

            if path == "/friend/v2.0/get_new_friend_list":
                _send_ok({"friend_list": [], "data": {"friend_list": []}})
                return True

            if path == "/friend/get_new_friend_apply_list":
                _send_ok({"friend_apply_list": [], "data": {"friend_apply_list": []}})
                return True

        if path.startswith("/follow/"):
            caller_uid = self._resolve_player_id_from_request(req_json)
            _online_ensure_profile(caller_uid, local_pd=local_pd)

            if path == "/follow/add_follow":
                target_uid = _uid_str(req_json.get("follow_user_id"), "")
                if target_uid and target_uid != caller_uid:
                    _online_ensure_profile(target_uid)
                    _online_add_uid("follows", caller_uid, target_uid)
                follow_info = {"user_id": caller_uid, "follow_user_id": target_uid}
                _send_ok({"follow_info": follow_info, "data": {"follow_info": follow_info}})
                return True

            if path == "/follow/del_follow":
                target_uid = _uid_str(req_json.get("follow_user_id"), "")
                if target_uid:
                    _online_remove_uid("follows", caller_uid, target_uid)
                _send_ok({"data": {}})
                return True

            if path == "/follow/get_follow_ext":
                follows = _online_get_uid_list("follows", caller_uid)
                follow_ext = {"follow_cnt": len(follows)}
                _send_ok({"follow_ext": follow_ext, "data": {"follow_ext": follow_ext}})
                return True

            if path == "/follow/get_follow_id_list":
                target_uid = _uid_str(req_json.get("user_id"), caller_uid)
                followers: list[str] = []
                with _ONLINE_LOCK:
                    follows_bucket = _ONLINE_STATE.get("follows")
                    if isinstance(follows_bucket, dict):
                        for src_uid, dst_list in follows_bucket.items():
                            if not isinstance(dst_list, list):
                                continue
                            if target_uid in [str(v) for v in dst_list]:
                                followers.append(_uid_str(src_uid))
                _send_ok({"user_id_list": followers, "data": {"user_id_list": followers}})
                return True

            if path == "/follow/get_follow_list":
                target_uid = _uid_str(req_json.get("user_id"), caller_uid)
                follows = _online_get_uid_list("follows", target_uid)
                follow_list: list[dict[str, object]] = []
                for uid in follows:
                    snap = self._online_player_snapshot(uid)
                    follow_list.append(
                        {
                            "follow_user_id": uid,
                            "user_id": uid,
                            "name": str(snap.get("name") or ""),
                            "level": max(1, _safe_int(snap.get("level"), 1)),
                            "icon": max(0, _safe_int(snap.get("icon"), 0)),
                            "icon_url": str(snap.get("icon_url") or ""),
                            "last_index_time": _online_now_ts(),
                        }
                    )
                _send_ok({"follow_list": follow_list, "data": {"follow_list": follow_list}})
                return True

            if path in {"/follow/get_followed_list", "/follow/get_new_followed_list"}:
                target_uid = caller_uid
                followers: list[str] = []
                with _ONLINE_LOCK:
                    follows_bucket = _ONLINE_STATE.get("follows")
                    if isinstance(follows_bucket, dict):
                        for src_uid, dst_list in follows_bucket.items():
                            if not isinstance(dst_list, list):
                                continue
                            if target_uid in [str(v) for v in dst_list]:
                                followers.append(_uid_str(src_uid))
                follow_list: list[dict[str, object]] = []
                for uid in followers:
                    snap = self._online_player_snapshot(uid)
                    follow_list.append(
                        {
                            "follow_user_id": uid,
                            "user_id": uid,
                            "name": str(snap.get("name") or ""),
                            "level": max(1, _safe_int(snap.get("level"), 1)),
                            "icon": max(0, _safe_int(snap.get("icon"), 0)),
                            "icon_url": str(snap.get("icon_url") or ""),
                            "last_index_time": _online_now_ts(),
                        }
                    )
                last_index_time = _online_now_ts()
                _send_ok(
                    {
                        "last_index_time": last_index_time,
                        "follow_list": follow_list,
                        "data": {"last_index_time": last_index_time, "follow_list": follow_list},
                    }
                )
                return True

        return False

    def _handle_holo_api(self, path: str, host: str, body: bytes | None = None) -> bool:
        m = re.match(r"^/holo/([^/]+)/api/1/(.+)$", path or "")
        if not m:
            return False

        product = (m.group(1) or "p10470").strip().lower() or "p10470"
        api = (m.group(2) or "").strip().lstrip("/")

        req_json: dict = {}
        if body:
            try:
                parsed = json.loads(body.decode("utf-8", errors="replace"))
                if isinstance(parsed, dict):
                    req_json = parsed
            except Exception:
                req_json = {}

        query = parse_qs(urlparse(self.path).query or "")
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
                mapped_player_id = _gp_player_id_from_token(game_token)
                if mapped_player_id:
                    player_id = mapped_player_id

            token_data = _holo_player_token_payload(player_id)
            payload = {
                **ok,
                "product": product,
                **token_data,
                "data": dict(token_data),
            }
            line = f"[HOLO] player_token issued host={host} product={product} player_id={player_id}"
            print(_console_safe(line))
            _append_utf8_log(line)
            _chat_bootstrap_mark(player_id, "seen_get_player_token", True)
            _append_utf8_log(f"[CHAT_BOOTSTRAP] seen_get_player_token uid={player_id}")
            self._send_json(payload)
            return True

        if api == "user/login_token":
            seed = f"{player_id}:{int(time.time() * 1000)}:{host}:{product}"
            login_token = "holo_login_" + hashlib.md5(seed.encode("utf-8")).hexdigest()
            payload = {
                **ok,
                "login_token": login_token,
                "data": {"login_token": login_token},
            }
            self._send_json(payload)
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
                infos.append(
                    {
                        "user_id": uid,
                        "id": uid,
                        "name": f"Player_{uid}",
                        "gender": 0,
                        "bio": "",
                    }
                )

            payload = {
                **ok,
                "infos": infos,
                "data": {"infos": infos},
            }
            self._send_json(payload)
            return True

        if api in {"user/info", "user/info/location", "user/info/photo/show/avatar"}:
            info = {
                "user_id": player_id,
                "id": player_id,
                "name": f"Player_{player_id}",
                "gender": 0,
                "bio": "",
            }
            payload = {
                **ok,
                **info,
                "data": dict(info),
            }
            self._send_json(payload)
            return True

        if api in {"sensitive_words/get_s_word_list_id", "sensitive_words/get_s_word_list"}:
            payload = {
                **ok,
                "list_id": 1,
                "list": [],
                "data": {"list_id": 1, "list": []},
            }
            self._send_json(payload)
            return True

        if api == "customer_service/submit_record":
            ticket = f"cs_{int(time.time() * 1000)}"
            payload = {
                **ok,
                "ticket_id": ticket,
                "data": {"ticket_id": ticket},
            }
            self._send_json(payload)
            return True

        _append_utf8_log(f"[HOLO] generic endpoint handled host={host} product={product} api={api or '-'}")
        self._send_json({**ok, "data": {}})
        return True

    def _aes_cbc_pkcs7_encrypt_b64(self, key: bytes, plaintext: bytes) -> str:
        if not _HAS_CRYPTO:
            raise RuntimeError("cryptography not available")
        if len(key) not in (16, 24, 32):
            raise ValueError(f"invalid AES key length: {len(key)}")

        padder = PKCS7(128).padder()
        padded = padder.update(plaintext) + padder.finalize()
        encryptor = Cipher(algorithms.AES(key), modes.CBC(key)).encryptor()
        ct = encryptor.update(padded) + encryptor.finalize()
        return base64.b64encode(ct).decode("ascii")

    def _handle_vanguard(self, path: str) -> bool:
        # gamesec security module expects *HTTP response headers*:
        # - /init: header `token` must be non-empty (used to derive AES key1)
        # - other calls: header `ek` (encrypted key2) may be used to decrypt body
        token = self._vanguard_token()
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
            key1 = self._vanguard_key1(token)
            key2_plain = b"0123456789abcdef"  # 16 bytes
            ek = self._aes_cbc_pkcs7_encrypt_b64(key1, key2_plain)
            # Be extra permissive with header casing.
            headers["ek"] = ek
            headers["EK"] = ek
            headers["Ek"] = ek
            headers["eK"] = ek

        # /init is primarily for provisioning token; body can be minimal.
        if path == "/init":
            _append_utf8_log(f"[VANGUARD_RESP] path=/init token=yes ek={'yes' if ek else 'no'}")
            self._send_body(b"{}", status=200, content_type="application/json; charset=utf-8", extra_headers=headers)
            return True

        # Security SDK queries these keys immediately after /config|/load|/collect;
        # keep them non-null to avoid binder/parcel null-string failures.
        query = parse_qs(urlparse(self.path).query or "")
        requested_region = _canonical_region_code((query.get("region") or [""])[0])
        region_mode = (os.environ.get("VANGUARD_REGION_MODE") or "request").strip().lower()
        if region_mode in {"force_br", "br"}:
            req_region = "br"
        else:
            req_region = requested_region or _canonical_region_code(os.environ.get("DEFAULT_REGION"), "ustest")

        req_region = _canonical_region_code(req_region, "ustest")
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
            _append_utf8_log(
                f"[VANGUARD_RESP] path={path} token=yes ek=yes body=encrypted "
                f"retCode={vanguard_ret_code} allSwitch={vanguard_all_switch} "
                f"uploadSwitch={vanguard_upload_switch} uploadInterval={vanguard_upload_interval}"
            )
            payload_bytes = json.dumps(payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            body_b64 = self._aes_cbc_pkcs7_encrypt_b64(key2_plain, payload_bytes).encode("utf-8")
            self._send_body(body_b64, status=200, content_type="text/plain; charset=utf-8", extra_headers=headers)
            return True

        body_mode = "plain"
        if response_encrypted and not can_encrypt_response:
            body_mode = "plain-fallback"
        _append_utf8_log(
            f"[VANGUARD_RESP] path={path} token=yes ek={'yes' if ek else 'no'} body={body_mode} "
            f"retCode={vanguard_ret_code} allSwitch={vanguard_all_switch} "
            f"uploadSwitch={vanguard_upload_switch} uploadInterval={vanguard_upload_interval}"
        )
        self._send_json(payload, extra_headers=headers)
        return True

    def _trace(self, note: str = ""):
        host = self._host_no_port() or "(no-host)"
        path = self.path
        ua = (self.headers.get("User-Agent") or "").strip()
        clen = (self.headers.get("Content-Length") or "").strip()
        rng = (self.headers.get("Range") or "").strip()
        rng_note = f" range={rng}" if rng else ""
        extra = f" {note}" if note else ""
        line = f"[REQ] {self.command} host={host} path={path} len={clen}{rng_note} ua={ua}{extra}"
        print(_console_safe(line))
        _append_utf8_log(line)

    def _read_body(self, limit: int = 64 * 1024) -> bytes:
        length = int(self.headers.get("Content-Length", "0") or "0")
        if length <= 0:
            return b""
        to_read = min(length, limit)
        body = self.rfile.read(to_read)
        # Drain if client sent more than limit (avoid corrupting the stream).
        remaining = length - to_read
        if remaining > 0:
            _ = self.rfile.read(remaining)
        return body

    def _send_file(self, path: Path, content_type: str | None = None):
        st = path.stat()
        total_size = st.st_size
        if content_type is None:
            content_type = self.guess_type(str(path)) or "application/octet-stream"

        status_code = 200
        start = 0
        end = max(total_size - 1, 0)
        range_info = _parse_single_range_header(self.headers.get("Range"), total_size)
        if range_info == "unsat":
            self.send_response(416)
            self.send_header("Content-Type", content_type)
            self.send_header("Accept-Ranges", "bytes")
            self.send_header("Content-Range", f"bytes */{total_size}")
            self.send_header("Content-Length", "0")
            self.end_headers()
            return
        if isinstance(range_info, tuple):
            start, end = range_info
            status_code = 206

        content_length = 0 if total_size == 0 else (end - start + 1)

        self.send_response(status_code)
        self.send_header("Content-Type", content_type)
        self.send_header("Accept-Ranges", "bytes")
        self.send_header("Content-Length", str(content_length))
        if status_code == 206:
            self.send_header("Content-Range", f"bytes {start}-{end}/{total_size}")
        self.end_headers()

        if self.command == "HEAD" or content_length <= 0:
            return

        with path.open("rb") as f:
            if start:
                f.seek(start)
            remaining = content_length
            chunk_size = 1024 * 1024
            while remaining > 0:
                chunk = f.read(min(chunk_size, remaining))
                if not chunk:
                    break
                try:
                    self.wfile.write(chunk)
                except (BrokenPipeError, ConnectionResetError):
                    break
                remaining -= len(chunk)

    def _send_head_file(self, path: Path, content_type: str | None = None):
        st = path.stat()
        total_size = st.st_size
        if content_type is None:
            content_type = self.guess_type(str(path)) or "application/octet-stream"

        status_code = 200
        start = 0
        end = max(total_size - 1, 0)
        range_info = _parse_single_range_header(self.headers.get("Range"), total_size)
        if range_info == "unsat":
            self.send_response(416)
            self.send_header("Content-Type", content_type)
            self.send_header("Accept-Ranges", "bytes")
            self.send_header("Content-Range", f"bytes */{total_size}")
            self.send_header("Content-Length", "0")
            self.end_headers()
            return
        if isinstance(range_info, tuple):
            start, end = range_info
            status_code = 206

        content_length = 0 if total_size == 0 else (end - start + 1)

        self.send_response(status_code)
        self.send_header("Content-Type", content_type)
        self.send_header("Accept-Ranges", "bytes")
        self.send_header("Content-Length", str(content_length))
        if status_code == 206:
            self.send_header("Content-Range", f"bytes {start}-{end}/{total_size}")
        self.end_headers()

    def _send_head_bytes(self, length: int, content_type: str):
        status_code = 200
        start = 0
        end = max(length - 1, 0)
        range_info = _parse_single_range_header(self.headers.get("Range"), length)
        if range_info == "unsat":
            self.send_response(416)
            self.send_header("Content-Type", content_type)
            self.send_header("Accept-Ranges", "bytes")
            self.send_header("Content-Range", f"bytes */{length}")
            self.send_header("Content-Length", "0")
            self.end_headers()
            return
        if isinstance(range_info, tuple):
            start, end = range_info
            status_code = 206

        content_length = 0 if length == 0 else (end - start + 1)

        self.send_response(status_code)
        self.send_header("Content-Type", content_type)
        self.send_header("Accept-Ranges", "bytes")
        self.send_header("Content-Length", str(content_length))
        if status_code == 206:
            self.send_header("Content-Range", f"bytes {start}-{end}/{length}")
        self.end_headers()

    def _serve_f2_file(self, rel: str, *, head_only: bool = False, request_path: str = "") -> bool:
        rel = rel.lstrip("/")
        if not rel:
            return False

        rel_lc = rel.lower()
        if rel_lc in {"remoteupdatecontrol", "remoteupdatecontrl"}:
            body = _build_remote_update_control_body()
            if head_only:
                self._send_head_bytes(len(body), "application/json; charset=utf-8")
            else:
                self._send_body(
                    body,
                    status=200,
                    content_type="application/json; charset=utf-8",
                    allow_range=True,
                )
            return True

        if rel_lc == "app_version_info":
            # For review/<...>/1_0_60/... URLs generate version info that matches URL tuple.
            if _extract_version_triplet_from_path(request_path):
                body = _build_app_version_info_body(request_path)
                if head_only:
                    self._send_head_bytes(len(body), "text/plain; charset=utf-8")
                else:
                    self._send_bytes(body, "text/plain; charset=utf-8")
                return True

            app_version_file = ASSET_FILE_DIR / "APP_VERSION_INFO"
            if app_version_file.is_file():
                if head_only:
                    self._send_head_file(app_version_file, content_type="text/plain; charset=utf-8")
                else:
                    self._send_file(app_version_file, content_type="text/plain; charset=utf-8")
                return True

            body = _build_app_version_info_body(request_path)
            if head_only:
                self._send_head_bytes(len(body), "text/plain; charset=utf-8")
            else:
                self._send_bytes(body, "text/plain; charset=utf-8")
            return True

        if HEX32_RE.match(rel):
            synthetic = _SYNTHETIC_F2_BLOBS.get(rel_lc)
            if synthetic is not None:
                if head_only:
                    self._send_head_bytes(len(synthetic), "text/plain; charset=utf-8")
                else:
                    self._send_bytes(synthetic, "text/plain; charset=utf-8")
                return True

        version_md5 = _get_version_md5()
        if HEX32_RE.match(rel) and version_md5 and rel.lower() == version_md5.lower():
            rel = "VERSION"
        elif HEX32_RE.match(rel):
            # Many builds request arbitrary assets by md5.
            try:
                idx = _load_version_index()
                mapped = idx.get(rel.lower())
                if mapped:
                    rel = mapped
            except Exception:
                pass

        base = ASSET_FILE_DIR.resolve()
        target = (ASSET_FILE_DIR / rel).resolve()
        if base != target and base not in target.parents:
            self.send_error(400, "Invalid path")
            return True

        if target.is_file():
            if target.name in {"APP_VERSION_INFO", "VERSION"} or target.suffix == "":
                content_type = "text/plain; charset=utf-8"
            else:
                content_type = None

            if head_only:
                self._send_head_file(target, content_type=content_type)
            else:
                self._send_file(target, content_type=content_type)
            return True

        # File not found locally - try to proxy from CDN if it's an asset hash
        if HEX32_RE.match(rel):
            proxied_data = _proxy_cdn_asset(rel, request_path)
            if proxied_data is not None:
                if head_only:
                    self._send_head_bytes(len(proxied_data), "application/octet-stream")
                else:
                    self._send_bytes(proxied_data, "application/octet-stream")
                return True

        self.send_error(404, f"File not found: {rel}")
        return True

    def do_GET(self):
        import json
        self._trace()
        path = urlparse(self.path).path
        path_noslash = path.rstrip("/")
        is_gangplank_cfg_path = path_noslash in {"/p10470/gangplank-config", "/gangplank-config"}

        if path == "/" or path == "/health":
            self._send_json({"ok": True})
            return

        if path == "/ping":
            # Gangplank region probe calls this endpoint in a tight loop.
            # Keep response as tiny plain text to avoid JSON parsing ambiguity.
            self._send_body(
                b"pong",
                status=200,
                content_type="text/plain; charset=utf-8",
                extra_headers=_no_cache_headers(),
            )
            return

        host = self._host_no_port()

        if self._handle_holo_api(path, host):
            return

        if self._handle_online_social_api(path, host, body=None):
            return

        if is_gangplank_cfg_path and _allow_gangplank_config_host(host):
            # Keep body as a JSON *string* (text/plain) to avoid SDK paths that
            # auto-decode application/json into a Lua table before logging.
            region_hint = _infer_region_from_host(host)
            payload = _gangplank_config_payload(
                region_hint=region_hint,
                request_host=host,
                server_ip_hint=self._server_ip(),
            )
            _append_utf8_log(
                f"[CFG] gangplank-config served ts={payload.get('ts')} host={host} region_hint={region_hint or '-'} "
                f"holo={payload.get('holo')} chat={payload.get('chat_host')}:{payload.get('chat_port')}"
            )
            body = json.dumps(payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            self._send_body(
                body,
                status=200,
                content_type="text/plain; charset=utf-8",
                extra_headers=_no_cache_headers({"X-AF2-TS": str(payload.get("ts", ""))}),
            )
            return

        if path == "/ann/realm/ticket":
            detail_payload = _launcher_server_list_detail_payload(host, self._realm_host_for_client(), GAME_PORT)
            detail_json = json.dumps(detail_payload, ensure_ascii=False, separators=(",", ":"))
            ticket = hashlib.md5(detail_json.encode("utf-8")).hexdigest()
            now = int(time.time())
            self._send_json(
                {
                    "code": 0,
                    "status": 0,
                    "ret": 0,
                    "success": True,
                    "msg": "ok",
                    "hash": ticket,
                    "time": now,
                    "data": {"hash": ticket, "time": now},
                }
            )
            return

        if path.startswith("/ann/realm/detail/"):
            detail_payload = _launcher_server_list_detail_payload(host, self._realm_host_for_client(), GAME_PORT)
            body = json.dumps(detail_payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            self._send_body(
                body,
                status=200,
                content_type="application/json; charset=utf-8",
                extra_headers=_no_cache_headers(),
            )
            return

        if host.startswith("vanguard") and host.endswith(".aligames.com"):
            if self._handle_vanguard(path):
                return

        rel = _extract_f2_rel_path(path)
        if rel is not None:
            if self._serve_f2_file(rel, request_path=path):
                return

        # --- GP & MISC & HOLO ROUTERS INJECTION ---
        context = {
            "send_json": self._send_json,
            "send_body": self._send_body,
            "no_cache_headers": getattr(self, "_no_cache_headers", None),
            "vanguard_token": getattr(self, "_vanguard_token", ""),
            "vanguard_key1": getattr(self, "_vanguard_key1", ""),
            "append_utf8_log": getattr(self, "_append_utf8_log", None),
            "canonical_region_code": getattr(self, "_canonical_region_code", None),
        }
        
        req_json_decoded = {}
        if locals().get("body"):
            try:
                parsed = json.loads(locals().get("body").decode("utf-8", errors="replace"))
                if isinstance(parsed, dict): req_json_decoded = parsed
            except: pass
            
        caller_uid_int = self._resolve_player_id_from_request(req_json_decoded)
        import routers.gp, routers.holo, routers.misc, routers.friend, routers.chat
        query = urlparse(self.path).query if hasattr(self, 'path') else ""
        
        if routers.chat.handle_route(path, req_json_decoded, host, query, context):
            return

        res = routers.friend.handle_route(path, req_json_decoded, caller_uid_int)
        if res is not None:
            st_code, st_msg, d_obj = res
            self._send_json({"code": 0, "status": st_code, "ret": st_code, "success": True, "msg": st_msg, **d_obj})
            return

        if routers.gp.handle_route(path, req_json_decoded, host, caller_uid_int, context):
            return
            
        if routers.holo.handle_route(path, req_json_decoded, host, query, context):
            return
            
        if routers.misc.handle_route(path, req_json_decoded, host, query, context):
            return

        # Modular router fallback: for any unhandled path, return standard 200 OK JSON
        self._send_json({"code": 0, "status": 0, "ret": 0, "success": True, "msg": "ok", "data": {}})
        return

    def do_HEAD(self):
        self._trace("HEAD")
        path = urlparse(self.path).path
        path_noslash = path.rstrip("/")
        is_gangplank_cfg_path = path_noslash in {"/p10470/gangplank-config", "/gangplank-config"}

        host = self._host_no_port()
        if is_gangplank_cfg_path and _allow_gangplank_config_host(host):
            region_hint = _infer_region_from_host(host)
            payload = _gangplank_config_payload(
                region_hint=region_hint,
                request_host=host,
                server_ip_hint=self._server_ip(),
            )
            _append_utf8_log(
                f"[CFG] gangplank-config served(ts={payload.get('ts')}) via HEAD host={host} region_hint={region_hint or '-'} "
                f"holo={payload.get('holo')} chat={payload.get('chat_host')}:{payload.get('chat_port')}"
            )
            body = json.dumps(payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            self.send_response(200)
            self.send_header("Content-Type", "text/plain; charset=utf-8")
            self.send_header("Content-Length", str(len(body)))
            for k, v in _no_cache_headers({"X-AF2-TS": str(payload.get("ts", ""))}).items():
                self.send_header(k, v)
            self.end_headers()
            return
        if host.startswith("vanguard") and host.endswith(".aligames.com"):
            self.send_response(200)
            self.send_header("Content-Length", "0")
            # Provide token header even on HEAD to be extra permissive.
            tok = self._vanguard_token()
            self.send_header("token", tok)
            self.send_header("Token", tok)
            self.send_header("TOKEN", tok)
            self.send_header("x-token", tok)
            self.end_headers()
            return

        rel = _extract_f2_rel_path(path)
        if rel is not None:
            if self._serve_f2_file(rel, head_only=True, request_path=path):
                return

        super().do_HEAD()

    def do_POST(self):
        import json
        body = self._read_body()
        note = ""
        if body:
            preview = body[:512]
            try:
                preview_text = preview.decode("utf-8", errors="replace")
                note = f" body[0:512]={preview_text!r}"
            except Exception:
                note = f" body[0:512]={preview!r}"
        self._trace(note)
        path = urlparse(self.path).path
        path_noslash = path.rstrip("/")
        is_gangplank_cfg_path = path_noslash in {"/p10470/gangplank-config", "/gangplank-config"}

        host = self._host_no_port()

        if path_noslash == "/v2.0/a/audid/req":
            resp_obj = {
                "code": 0,
                "data": {},
            }
            resp_body = json.dumps(resp_obj, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            resp_signature = _audid_signature_for_response_body(resp_body)
            resp_timestamp = str(int(time.time() * 1000))
            _append_utf8_log(
                f"[AUDID] req handled host={host or '-'} status=200 body_len={len(resp_body)}"
            )
            self._send_body(
                resp_body,
                status=200,
                content_type="application/json; charset=utf-8",
                extra_headers={
                    "signature": resp_signature,
                    "x-audid-timestamp": resp_timestamp,
                },
                allow_range=False,
            )
            return

        if is_gangplank_cfg_path and _allow_gangplank_config_host(host):
            region_hint = _infer_region_from_host(host)
            payload = _gangplank_config_payload(
                region_hint=region_hint,
                request_host=host,
                server_ip_hint=self._server_ip(),
            )
            _append_utf8_log(
                f"[CFG] gangplank-config served ts={payload.get('ts')} via POST host={host} region_hint={region_hint or '-'} "
                f"holo={payload.get('holo')} chat={payload.get('chat_host')}:{payload.get('chat_port')}"
            )
            body = json.dumps(payload, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            self._send_body(
                body,
                status=200,
                content_type="text/plain; charset=utf-8",
                extra_headers=_no_cache_headers({"X-AF2-TS": str(payload.get("ts", ""))}),
            )
            return

        if self._handle_holo_api(path, host, body=body):
            return

        if self._handle_online_social_api(path, host, body=body):
            return

        def _decode_req_json() -> dict:
            if not body:
                return {}
            try:
                parsed = json.loads(body.decode("utf-8", errors="replace"))
                return parsed if isinstance(parsed, dict) else {}
            except Exception:
                return {}

        def _send_plain_json_text(payload_obj: dict, status: int = 200):
            payload_bytes = json.dumps(payload_obj, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            self._send_body(
                payload_bytes,
                status=status,
                content_type="text/plain; charset=utf-8",
                extra_headers=_no_cache_headers(),
            )

        def _send_state_response(
            state_code: int,
            state_msg: str,
            data_obj: dict,
            req_id=None,
            success_code: int = 2000000,
        ):
            is_success = state_code == success_code
            payload = {
                "id": req_id if req_id is not None else int(time.time() * 1000),
                "state": {"code": state_code, "msg": state_msg},
                "data": data_obj,
                # Compatibility mirrors for older probes/loggers.
                "code": 0 if is_success else state_code,
                "status": 0 if is_success else state_code,
                "ret": 0 if is_success else state_code,
                "success": is_success,
                "msg": "ok" if is_success else state_msg,
            }
            _send_plain_json_text(payload)

        def _send_usercenter_response(state_code: int, state_msg: str, data_obj: dict, req_id=None):
            # usercenter_protocal.lua does JSON:decode(resp.body) manually.
            # Return text/plain to avoid auto-decoding into table before that step.
            _send_state_response(state_code, state_msg, data_obj, req_id=req_id, success_code=2000000)

        # Handle /client/system.config.check from ww-hk-id-api.qookkagames.com
        if path == "/client/system.config.check":
            req_json = _decode_req_json()
            req_id = req_json.get("id") if isinstance(req_json, dict) else None

            client_obj = req_json.get("client") if isinstance(req_json, dict) else {}
            if not isinstance(client_obj, dict):
                client_obj = {}
            data_obj = req_json.get("data") if isinstance(req_json, dict) else {}
            if not isinstance(data_obj, dict):
                data_obj = {}
            pkg_info = client_obj.get("pkgInfo") if isinstance(client_obj, dict) else {}
            if not isinstance(pkg_info, dict):
                pkg_info = {}

            valid_regions = {"sgtest", "ustest", "br"}
            region_hint = _canonical_region_code(
                pkg_info.get("region")
                or client_obj.get("region")
                or req_json.get("region")
                or ""
            )
            if region_hint not in valid_regions:
                region_hint = _canonical_region_code(os.environ.get("DEFAULT_REGION"), "ustest")
                if region_hint not in valid_regions:
                    region_hint = "ustest"

            area_hint = "SG" if region_hint == "sgtest" else ("US" if region_hint == "ustest" else "BR")
            # Keep host aligned with the actual reachable server endpoint.
            game_host = (
                (os.environ.get("GAME_HOST") or "").strip()
                or (os.environ.get("GAME_PUBLIC_HOST") or "").strip()
                or self._realm_host_for_client()
            )
            game_port = int(os.environ.get("GAME_PORT", "12000"))
            now_ms = int(time.time() * 1000)

            req_config_check_time = data_obj.get("configCheckTime")
            if not isinstance(req_config_check_time, int):
                req_config_check_time = now_ms

            client_si = str(client_obj.get("si") or "").strip()
            if client_si:
                si_value = client_si
            else:
                si_seed = str(pkg_info.get("android_id") or pkg_info.get("uuid") or self.client_address[0])
                si_value = f"si-{hashlib.md5(si_seed.encode('utf-8')).hexdigest()[:16]}"

            # Source contract from usercenter_protocal.lua/ejoysdk_usercenter.lua:
            # state.code==2000000 and data.{configCheckTime,si,clientConfig}
            uc_data = {
                "configCheckTime": req_config_check_time,
                "si": si_value,
                "clientConfig": {
                    "region": region_hint,
                    "area": area_hint,
                    "host": game_host,
                    "port": game_port,
                },
                # Compatibility mirrors consumed by legacy diagnostics.
                "region": region_hint,
                "area": area_hint,
                "host": game_host,
                "ip": game_host,
                "port": game_port,
            }

            _append_utf8_log(
                f"[USERCENTER] system.config.check responded state=2000000 region={region_hint} client_si={'yes' if client_si else 'no'}"
            )
            _send_usercenter_response(2000000, "success", uc_data, req_id=req_id)
            return

        if path in {
            "/client/account.thirdParty.login",
            "/client/account.thirdParty.bind",
            "/client/account.thirdParty.list",
        }:
            req_json = _decode_req_json()
            req_id = req_json.get("id") if isinstance(req_json, dict) else None
            data_obj = req_json.get("data") if isinstance(req_json, dict) else {}
            if not isinstance(data_obj, dict):
                data_obj = {}

            third_party_type = str(data_obj.get("thirdPartyType") or "guest").strip().lower() or "guest"
            third_party_token = str(data_obj.get("thirdPartyToken") or "").strip()
            agst_token = str(data_obj.get("agstToken") or "").strip()
            token_in = str(data_obj.get("token") or "").strip()

            with _UC_LOCK:
                session = _UC_SESSIONS.get(token_in) if token_in else None
                if session is None:
                    seed = third_party_token or agst_token or token_in or f"{self.client_address[0]}:{time.time_ns()}"
                    token_out = f"uc_{hashlib.md5((third_party_type + ':' + seed + ':' + str(time.time_ns())).encode('utf-8')).hexdigest()}"
                    uid_out = f"ucuid_{hashlib.md5((third_party_type + ':' + seed).encode('utf-8')).hexdigest()[:16]}"
                    session = {
                        "token": token_out,
                        "uid": uid_out,
                        "tokenTimeout": 2592000,
                        "bindList": [],
                    }
                    _UC_SESSIONS[token_out] = session

                if path != "/client/account.thirdParty.list":
                    bind_list = session.get("bindList")
                    if not isinstance(bind_list, list):
                        bind_list = []
                        session["bindList"] = bind_list

                    third_party_uid_seed = third_party_token or agst_token or str(session.get("uid") or "")
                    third_party_uid = hashlib.md5(
                        (third_party_type + ":" + third_party_uid_seed).encode("utf-8")
                    ).hexdigest()[:24]
                    found = False
                    for entry in bind_list:
                        if isinstance(entry, dict) and entry.get("thirdPartyType") == third_party_type:
                            entry["thirdPartyUid"] = third_party_uid
                            found = True
                            break
                    if not found:
                        bind_list.append(
                            {
                                "thirdPartyType": third_party_type,
                                "thirdPartyUid": third_party_uid,
                            }
                        )

                bind_list_out = []
                bind_list_src = session.get("bindList")
                if isinstance(bind_list_src, list):
                    for item in bind_list_src:
                        if isinstance(item, dict):
                            out_item = dict(item)
                            if "thirdPartyInfo" not in out_item:
                                out_item["thirdPartyInfo"] = {
                                    "nickname": "",
                                    "avatar": "",
                                }
                            bind_list_out.append(out_item)

                if path == "/client/account.thirdParty.list":
                    uc_data = {"bindList": bind_list_out}
                else:
                    uc_data = {
                        "token": str(session.get("token") or ""),
                        "tokenTimeout": int(session.get("tokenTimeout") or 2592000),
                        "uid": str(session.get("uid") or ""),
                        "thirdPartyType": third_party_type,
                        "bindList": bind_list_out,
                    }

            _append_utf8_log(
                f"[USERCENTER] {path} responded state=2000000 thirdPartyType={third_party_type}"
            )
            _send_usercenter_response(2000000, "success", uc_data, req_id=req_id)
            return

        if host == "qrcode.flysdk.cn" and path_noslash in {
            "/pc/qrcode.login.get",
            "/pc/qrcode.login.poll",
            "/pc/qrcode.token.exchange",
            "/pc/qrcode.pay.get",
            "/pc/qrcode.pay.poll",
        }:
            req_json = _decode_req_json()
            req_id = req_json.get("id") if isinstance(req_json, dict) else None
            data_obj = req_json.get("data") if isinstance(req_json, dict) else {}
            if not isinstance(data_obj, dict):
                data_obj = {}

            def _send_ali_state(state_code: int, state_msg: str, payload_data: dict):
                # vendors/aligames.lua does JSON:decode(resp.body) and expects state/data.
                _send_state_response(
                    state_code,
                    state_msg,
                    payload_data,
                    req_id=req_id,
                    success_code=2000000,
                )

            now = int(time.time())
            now_ms = int(time.time() * 1000)

            if path_noslash == "/pc/qrcode.login.get":
                login_uuid = f"pc_login_{hashlib.md5(f'{self.client_address[0]}:{now_ms}'.encode('utf-8')).hexdigest()[:20]}"
                with _ALI_QR_LOCK:
                    _ALI_QR_LOGIN[login_uuid] = {
                        "created_at": now,
                        "poll_count": 0,
                        "token": "",
                    }

                qrcode_scheme = f"af2://mock-login/{login_uuid}"
                _append_utf8_log(f"[ALIGAMES] qrcode.login.get created uuid={login_uuid}")
                _send_ali_state(
                    2000000,
                    "success",
                    {
                        "pcLoginUuid": login_uuid,
                        "qrcodeScheme": qrcode_scheme,
                        "timeout": 300,
                    },
                )
                return

            if path_noslash == "/pc/qrcode.login.poll":
                login_uuid = str(data_obj.get("pcLoginUuid") or "").strip()
                if not login_uuid:
                    _send_ali_state(4001110, "qrcode expired", {})
                    return

                with _ALI_QR_LOCK:
                    rec = _ALI_QR_LOGIN.get(login_uuid)
                    if rec is None:
                        _send_ali_state(4001110, "qrcode expired", {})
                        return

                    rec["poll_count"] = int(rec.get("poll_count") or 0) + 1
                    autoscan = _env_truthy("ALI_QR_AUTOSCAN", "1")
                    if not autoscan and int(rec.get("poll_count") or 0) < 2:
                        _send_ali_state(2000001, "unscanned", {})
                        return

                    token = str(rec.get("token") or "")
                    if not token:
                        token = f"ali_tok_{hashlib.md5((login_uuid + ':' + str(now_ms)).encode('utf-8')).hexdigest()}"
                        rec["token"] = token
                        _ALI_QR_TOKEN_INDEX[token] = login_uuid

                _append_utf8_log(f"[ALIGAMES] qrcode.login.poll success uuid={login_uuid}")
                _send_ali_state(
                    2000000,
                    "success",
                    {
                        "token": token,
                        "timeout": 2592000,
                        "platform": "ALIGAMES",
                        "pcLoginUuid": login_uuid,
                    },
                )
                return

            if path_noslash == "/pc/qrcode.token.exchange":
                token_in = str(data_obj.get("token") or "").strip()
                if not token_in:
                    _send_ali_state(4001103, "token invalid", {})
                    return

                with _ALI_QR_LOCK:
                    login_uuid = _ALI_QR_TOKEN_INDEX.get(token_in)
                    if not login_uuid:
                        login_uuid = f"pc_login_{hashlib.md5(token_in.encode('utf-8')).hexdigest()[:20]}"
                        _ALI_QR_LOGIN.setdefault(
                            login_uuid,
                            {
                                "created_at": now,
                                "poll_count": 0,
                                "token": token_in,
                            },
                        )

                    token_out = f"ali_tok_{hashlib.md5((token_in + ':' + str(now_ms)).encode('utf-8')).hexdigest()}"
                    _ALI_QR_TOKEN_INDEX.pop(token_in, None)
                    _ALI_QR_TOKEN_INDEX[token_out] = login_uuid

                    rec = _ALI_QR_LOGIN.get(login_uuid)
                    if isinstance(rec, dict):
                        rec["token"] = token_out

                _append_utf8_log(f"[ALIGAMES] qrcode.token.exchange success login_uuid={login_uuid}")
                _send_ali_state(
                    2000000,
                    "success",
                    {
                        "token": token_out,
                        "timeout": 2592000,
                    },
                )
                return

            if path_noslash == "/pc/qrcode.pay.get":
                token_in = str(data_obj.get("token") or "").strip()
                order_info = data_obj.get("orderInfo") if isinstance(data_obj.get("orderInfo"), dict) else {}
                cp_order_id = str(order_info.get("cpOrderId") or "")
                pay_uuid = f"pc_pay_{hashlib.md5((token_in + ':' + cp_order_id + ':' + str(now_ms)).encode('utf-8')).hexdigest()[:20]}"

                with _ALI_QR_LOCK:
                    _ALI_QR_PAY[pay_uuid] = {
                        "created_at": now,
                        "poll_count": 0,
                        "cpOrderId": cp_order_id,
                    }

                qrcode_scheme = f"af2://mock-pay/{pay_uuid}"
                _append_utf8_log(f"[ALIGAMES] qrcode.pay.get created uuid={pay_uuid} order={cp_order_id or '-'}")
                _send_ali_state(
                    2000000,
                    "success",
                    {
                        "pcPayUuid": pay_uuid,
                        "qrcodeScheme": qrcode_scheme,
                        "timeout": 300,
                    },
                )
                return

            if path_noslash == "/pc/qrcode.pay.poll":
                pay_uuid = str(data_obj.get("pcPayUuid") or "").strip()
                if not pay_uuid:
                    _send_ali_state(4001110, "qrcode expired", {})
                    return

                with _ALI_QR_LOCK:
                    rec = _ALI_QR_PAY.get(pay_uuid)
                    if rec is None:
                        _send_ali_state(4001110, "qrcode expired", {})
                        return

                    rec["poll_count"] = int(rec.get("poll_count") or 0) + 1
                    autoscan = _env_truthy("ALI_QR_PAY_AUTOSCAN", "1")
                    if not autoscan and int(rec.get("poll_count") or 0) < 2:
                        _send_ali_state(2000001, "unscanned", {})
                        return

                    cp_order_id = str(rec.get("cpOrderId") or "")

                _append_utf8_log(f"[ALIGAMES] qrcode.pay.poll success uuid={pay_uuid}")
                _send_ali_state(
                    2000000,
                    "success",
                    {
                        "pcPayUuid": pay_uuid,
                        "cpOrderId": cp_order_id,
                        "tradeStatus": "SUCCESS",
                    },
                )
                return

        if host in {"magic-account.flysdk.cn", "magic-account2.daily.uc.cn"} and path_noslash == "/client/realname.info.report":
            req_json = _decode_req_json()
            req_id = req_json.get("id") if isinstance(req_json, dict) else None
            data_obj = req_json.get("data") if isinstance(req_json, dict) else {}
            if not isinstance(data_obj, dict):
                data_obj = {}
            token = str(data_obj.get("token") or "")

            # ejoysdk_lx_protocal.lua expects state.code == 1 on success.
            lx_payload = {
                "realNameInfo": {
                    "realNameStatus": 1,
                    "antiAddictionStatus": 1,
                    "adult": 1,
                    "personId": "",
                },
                "popupConfigList": [],
            }
            if token:
                lx_payload["token"] = token

            _append_utf8_log("[LINGXI] realname.info.report responded state=1")
            _send_state_response(1, "success", lx_payload, req_id=req_id, success_code=1)
            return

        if host.startswith("vanguard") and host.endswith(".aligames.com"):
            if self._handle_vanguard(path):
                return

        # --- GP & MISC & HOLO ROUTERS INJECTION ---
        context = {
            "send_json": self._send_json,
            "send_body": self._send_body,
            "no_cache_headers": getattr(self, "_no_cache_headers", None),
            "vanguard_token": getattr(self, "_vanguard_token", ""),
            "vanguard_key1": getattr(self, "_vanguard_key1", ""),
            "append_utf8_log": getattr(self, "_append_utf8_log", None),
            "canonical_region_code": getattr(self, "_canonical_region_code", None),
        }
        
        req_json_decoded = {}
        if locals().get("body"):
            try:
                parsed = json.loads(locals().get("body").decode("utf-8", errors="replace"))
                if isinstance(parsed, dict): req_json_decoded = parsed
            except: pass
            
        caller_uid_int = self._resolve_player_id_from_request(req_json_decoded)
        import routers.gp, routers.holo, routers.misc, routers.friend, routers.chat
        query = urlparse(self.path).query if hasattr(self, 'path') else ""
        
        if routers.chat.handle_route(path, req_json_decoded, host, query, context):
            return

        res = routers.friend.handle_route(path, req_json_decoded, caller_uid_int)
        if res is not None:
            st_code, st_msg, d_obj = res
            self._send_json({"code": 0, "status": st_code, "ret": st_code, "success": True, "msg": st_msg, **d_obj})
            return

        if routers.gp.handle_route(path, req_json_decoded, host, caller_uid_int, context):
            return
            
        if routers.holo.handle_route(path, req_json_decoded, host, query, context):
            return
            
        if routers.misc.handle_route(path, req_json_decoded, host, query, context):
            return

        # Modular router fallback: for any unhandled path, return standard 200 OK JSON
        self._send_json({"code": 0, "status": 0, "ret": 0, "success": True, "msg": "ok", "data": {}})
        return

class PlainHTTPHandler(Handler):
    # Same behavior as Handler, but used for plain HTTP (port 80) endpoints like holo-cdn.
    pass


class TLSServer(ThreadingHTTPServer):
    """HTTPS server variant that logs TLS handshake failures instead of swallowing them."""

    daemon_threads = True

    def get_request(self):
        while True:
            try:
                return super().get_request()
            except ssl.SSLError as e:
                msg = f"[TLS] handshake failed: {e}"
                print(_console_safe(msg), file=sys.stderr)
                _append_utf8_log(msg)


def main():
    def _ensure_windows_firewall_rules():
        import sys
        if sys.platform != "win32":
            return
        
        rule_name = "Area F2 Server v3"
        import subprocess
        try:
            res = subprocess.run(
                ["netsh", "advfirewall", "firewall", "show", "rule", f"name={rule_name} (TCP)"],
                capture_output=True, text=True, creationflags=0x08000000  # CREATE_NO_WINDOW
            )
            if "Rule Name:" in res.stdout or "Имя правила:" in res.stdout:
                return  # Rule already exists
        except Exception:
            pass

        print(f"[BOOT] Windows Firewall rule '{rule_name}' is missing. Requesting Administrator privileges to add it...")
        ps_script = (
            f"New-NetFirewallRule -DisplayName '{rule_name} (TCP)' -Direction Inbound -Action Allow -Protocol TCP -LocalPort 80,443,8290,12000-13000,22000 -ErrorAction SilentlyContinue; "
            f"New-NetFirewallRule -DisplayName '{rule_name} (UDP)' -Direction Inbound -Action Allow -Protocol UDP -LocalPort 12000-13000,22000 -ErrorAction SilentlyContinue"
        )
        import ctypes
        try:
            # 0 = SW_HIDE
            ret = ctypes.windll.shell32.ShellExecuteW(
                None, "runas", "powershell.exe", f"-WindowStyle Hidden -Command \"{ps_script}\"", None, 0
            )
            if ret > 32:
                print(f"[BOOT] Windows Firewall rules '{rule_name}' successfully requested (check UAC prompt).")
            else:
                print(f"[BOOT] Failed to add Windows Firewall rule automatically. ShellExecuteW returned {ret}.")
        except Exception as e:
            import traceback; traceback.print_exc()
            print(f"[BOOT] Failed to add Windows Firewall rule automatically: {e}")

    _ensure_windows_firewall_rules()
    cert = DIR / "cert.pem"
    key = DIR / "key.pem"
    if not cert.is_file() or not key.is_file():
        print("Missing cert.pem or key.pem. Run: python gen_https_cert.py", file=sys.stderr)
        sys.exit(1)
    ctx = ssl.SSLContext(ssl.PROTOCOL_TLS_SERVER)
    ctx.load_cert_chain(cert, key)
    # Broad compatibility with older Android TLS stacks
    ctx.minimum_version = ssl.TLSVersion.TLSv1_2

    def _on_tls_sni(sock: ssl.SSLSocket, server_name: str | None, _ssl_ctx: ssl.SSLContext):
        try:
            peer = sock.getpeername()
            if isinstance(peer, tuple) and len(peer) >= 2:
                peer_s = f"{peer[0]}:{peer[1]}"
            else:
                peer_s = str(peer)
        except Exception:
            peer_s = "?:?"
        sni = server_name or "(none)"
        _append_utf8_log(f"[TLS] client={peer_s} sni={sni}")

    try:
        ctx.set_servername_callback(_on_tls_sni)
    except Exception:
        # Some Python/OpenSSL builds may not expose SNI callback support.
        pass

    require_tcp_stub = _env_truthy("REQUIRE_TCP_STUB", "1")
    require_udp_stub = _env_truthy("REQUIRE_UDP_STUB", "0")
    # Echo UDP datagrams back on battle-related ports to satisfy simple probe/echo checks.
    udp_echo_enabled = _env_truthy("UDP_STUB_ECHO", "1")
    startup_state: dict[str, bool | None] = {"tcp": None, "udp": None}
    tcp_started_event = threading.Event()
    udp_started_event = threading.Event()

    # Keep primary lobby port from GAME_PORT, but also listen on legacy ports
    # often embedded in old IPConfigVendor lists (11000/8290).
    BATTLE_PORT = int(os.environ.get("BATTLE_PORT", "12001"))
    CHAT_PORT = int(os.environ.get("CHAT_PORT", "12345"))
    enable_chat_tcp_stub = _env_truthy("ENABLE_CHAT_TCP_STUB", "1")
    BATTLE_PUBLIC_HOST = (
        (os.environ.get("BATTLE_PUBLIC_HOST") or os.environ.get("GAME_HOST") or "127.0.0.1").strip()
        or "127.0.0.1"
    )
    # Zone ping endpoint should default to battle runtime port, not lobby/game port.
    BATTLE_ZONE_PORT = int(os.environ.get("BATTLE_ZONE_PORT", str(BATTLE_PORT)))
    stub_ports: list[int] = [GAME_PORT]
    if _env_truthy("ENABLE_COMPAT_GAME_PORTS", "1"):
        for compat_port in (11000, 8290):
            if compat_port not in stub_ports:
                stub_ports.append(compat_port)
    if BATTLE_PORT not in stub_ports:
        stub_ports.append(BATTLE_PORT)
    if BATTLE_ZONE_PORT not in stub_ports:
        stub_ports.append(BATTLE_ZONE_PORT)
    if enable_chat_tcp_stub and CHAT_PORT not in stub_ports:
        stub_ports.append(CHAT_PORT)
    for extra_port in _parse_port_list(os.environ.get("EXTRA_GAME_PORTS", "")):
        if extra_port not in stub_ports:
            stub_ports.append(extra_port)

    try:
        boot_cfg = _gangplank_config_payload(
            region_hint=_canonical_region_code(os.environ.get("DEFAULT_REGION"), "ustest"),
            request_host=(os.environ.get("GAME_HOST") or "").strip() or None,
            server_ip_hint=(os.environ.get("SERVER_IP") or "").strip() or None,
        )
        _append_utf8_log(
            "[BOOT] network routes "
            f"region={boot_cfg.get('region')} "
            f"holo={boot_cfg.get('holo')} "
            f"chat={boot_cfg.get('chat_host')}:{boot_cfg.get('chat_port')} "
            f"game_host={(os.environ.get('GAME_HOST') or '').strip() or '-'} "
            f"server_ip={(os.environ.get('SERVER_IP') or '').strip() or '-'} "
            f"chat_mode={(os.environ.get('CHAT_HOST_MODE') or 'game_host').strip() or 'game_host'}"
        )
    except Exception as exc:
        import traceback; traceback.print_exc()
        _append_utf8_log(f"[BOOT] network route summary failed: {exc}")

    def _start_http():
        try:
            httpd_plain = ThreadingHTTPServer(("0.0.0.0", HTTP_PORT), PlainHTTPHandler)
        except PermissionError as e:
            msg = f"HTTP (plain) not started on port {HTTP_PORT}: {e}"
            print(msg, file=sys.stderr)
            _append_utf8_log(msg)
            return
        except OSError as e:
            msg = f"HTTP (plain) not started on port {HTTP_PORT}: {e}"
            print(msg, file=sys.stderr)
            _append_utf8_log(msg)
            return
        msg = f"HTTP  on http://0.0.0.0:{HTTP_PORT}/ (same handlers)"
        print(msg)
        _append_utf8_log(msg)
        httpd_plain.serve_forever()

    # ── Sproto protocol helpers for TCP stub ─────────────────────────────
    try:
        from sproto_util import (
            sproto_unpack as _sproto_unpack,
            sproto_pack as _sproto_pack,
            sproto_encode_fields as _sproto_encode_fields,
            sproto_decode_fields as _sproto_decode_fields,
            build_response_frame as _sproto_build_response_frame,
            build_push_frame as _sproto_build_push_frame,
        )
        _HAS_SPROTO = True
    except Exception:
        _HAS_SPROTO = False

    # ── Persistence file for player data ─────────────────────────────
    _PLAYER_SAVE_PATH = DIR / "artifacts" / "player_save.json"
    _PLAYER_SAVE_LOCK = threading.Lock()

    def _as_int(value: object, default: int) -> int:
        if isinstance(value, bool):
            return int(value)
        try:
            return int(value)
        except Exception:
            return default

    def _int_env(name: str, default: int) -> int:
        raw = (os.environ.get(name) or "").strip()
        if not raw:
            return default
        try:
            return int(raw)
        except Exception:
            _append_utf8_log(f"[CONFIG] invalid {name}={raw!r}; use {default}")
            return default

    _DEFAULT_GOLD = _int_env("DEFAULT_GOLD", 20000)
    _DEFAULT_DIAMOND = _int_env("DEFAULT_DIAMOND", 20000)
    _DEFAULT_SPAWN_REGION_ID = _int_env("DEFAULT_SPAWN_REGION_ID", 0)
    _GUIDE_ROUND_WAIT_TIME = max(1, _int_env("GUIDE_ROUND_WAIT_TIME", 300))
    _ALWAYS_UNLOCK_TIME = _int_env("ALWAYS_UNLOCK_TIME", 1)
    _SEND_UNLOCK_CHARACTERS = _env_truthy("SEND_UNLOCK_CHARACTERS", "0")
    # query_role(msg108): when enabled, include response.show_character (client.CharacterSkin).
    # Keep disabled by default: malformed/legacy skin payloads can abort Lua handler before
    # RemotePlayerData.OnQueryRole() callback, which blocks opening the profile panel.
    _SEND_QUERY_ROLE_SHOW_CHARACTER = _env_truthy("SEND_QUERY_ROLE_SHOW_CHARACTER", "0")
    _NEVER_EXPIRE_LIMIT_TIME = _int_env("NEVER_EXPIRE_LIMIT_TIME", 9223372036854775807)
    _DEFAULT_STORE_GOLD_COST = max(1, _int_env("DEFAULT_STORE_GOLD_COST", 1000))
    _DEFAULT_STORE_DIAMOND_COST = max(1, _int_env("DEFAULT_STORE_DIAMOND_COST", 50))
    _STORE_ITEMS_PER_TYPE_LIMIT = max(200, _int_env("STORE_ITEMS_PER_TYPE_LIMIT", 800))
    _STORE_TYPE_9_LIMIT = max(32, _int_env("STORE_TYPE_9_LIMIT", 400))
    _BAG_TYPE_HERO = 2
    _BAG_TYPE_GIFT_BOX = 7
    _EVENT_TYPE_TYPE_BOX = "TYPE_BOX"
    _EVENT_TYPE_BOX_COUNT = "BOX_COUNT"
    _DISABLE_EVENT_STATS = False
    _GRANT_ALL_CONTENT = _env_truthy("GRANT_ALL_CONTENT", "1")
    _STRICT_SOURCE_CONTRACTS = _env_truthy("STRICT_SOURCE_CONTRACTS", "0")
    _SPROTO_QC_ENABLED = _env_truthy("SPROTO_QC", "1")
    _LOBBY_AD_SWITCH = _env_truthy("LOBBY_AD_SWITCH", "0")
    _LOBBY_RECRUIT_ENABLED = _env_truthy("LOBBY_RECRUIT_ENABLED", "0")
    _LOBBY_JF_SWITCH = _env_truthy("LOBBY_JF_SWITCH", "0")
    _LOBBY_GM_ENABLED = _env_truthy("LOBBY_GM_ENABLED", "0")
    _UI_CONST_LUA_PATH = DIR / "decrypted_lua" / "Consts" / "UIConst.lua"

    def _load_lua_named_enum(path: Path, enum_name: str) -> dict[str, int]:
        out: dict[str, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        in_enum = False
        await_open_brace = False
        for raw in lines:
            line = raw.strip()
            if not in_enum:
                if await_open_brace:
                    if line.startswith("{"):
                        in_enum = True
                    elif line == "" or line.startswith("--"):
                        continue
                    else:
                        await_open_brace = False

                if re.match(rf"^{re.escape(enum_name)}\s*=\s*\{{\s*$", line):
                    in_enum = True
                elif re.match(rf"^{re.escape(enum_name)}\s*=\s*$", line):
                    await_open_brace = True

            if line.startswith("}"):
                break

            m = re.match(r"^([A-Za-z_][A-Za-z0-9_]*)\s*=\s*(-?\d+)", line)
            if not m:
                continue

            out[m.group(1)] = _as_int(m.group(2), 0)

        return out

    _UI_STORE_TYPES = _load_lua_named_enum(_UI_CONST_LUA_PATH, "StoreType")
    _UI_BAG_TYPES = _load_lua_named_enum(_UI_CONST_LUA_PATH, "BagType")

    _STORE_TYPE_SALE = _as_int(_UI_STORE_TYPES.get("Sale"), 0)
    _STORE_TYPE_CHARACTER = _as_int(_UI_STORE_TYPES.get("Character"), 1)
    _STORE_TYPE_SUIT = _as_int(_UI_STORE_TYPES.get("Suit"), 2)
    _STORE_TYPE_HEAD = _as_int(_UI_STORE_TYPES.get("Head"), 3)
    _STORE_TYPE_BODY = _as_int(_UI_STORE_TYPES.get("Body"), 4)
    _STORE_TYPE_WEAPON_PT = _as_int(_UI_STORE_TYPES.get("WeaponPT"), 5)
    _STORE_TYPE_WEAPON_GJ = _as_int(_UI_STORE_TYPES.get("WeaponGJ"), 6)
    _STORE_TYPE_BUNDLE = _as_int(_UI_STORE_TYPES.get("Bundle"), 7)
    _STORE_TYPE_BOX = _as_int(_UI_STORE_TYPES.get("Box"), 9)

    _BAG_TYPE_HERO = _as_int(_UI_BAG_TYPES.get("Hero"), _BAG_TYPE_HERO)
    _BAG_TYPE_GIFT_BOX = _as_int(_UI_BAG_TYPES.get("GiftBox"), _BAG_TYPE_GIFT_BOX)

    _TYPE1_AGENT_PRICE_FALLBACK_IDS = [
        20,
        60,
        70,
        90,
        100,
        1030,
        1080,
        1090,
        110,
        120,
        1100,
        1110,
        1120,
    ]
    # Known broken preview assets in current local resources (white logo/preview in supply UI).
    _STORE_TYPE_9_TEXTURE_BLACKLIST_IDS = {20005, 20006}
    _STORE_TYPE_DEFAULT_ITEMS = {
        _STORE_TYPE_CHARACTER: [20, 60, 70, 90, 100, 110, 120],
        _STORE_TYPE_SUIT: [100, 1030, 1080, 1090, 1100, 1110, 1120],
        _STORE_TYPE_HEAD: [900220020, 900220030, 900320050],
        _STORE_TYPE_BODY: [900230020, 900230060, 900330030],
        _STORE_TYPE_WEAPON_PT: [1000110010, 1000110030, 1000120020, 1000120030],
        _STORE_TYPE_WEAPON_GJ: [50010, 50030, 50040, 50090],
        _STORE_TYPE_BUNDLE: [10001, 10002, 10003, 10004, 10005],
        _STORE_TYPE_BOX: [20001],
    }

    def _iter_lua_indexed_blocks(lines: list[str]):
        """Yield [id]={...} blocks from Lua tables without full parsing."""
        cur_id: int | None = None
        depth = 0
        block_lines: list[str] = []

        for raw in lines:
            line = raw.strip()
            if cur_id is None:
                m = re.match(r"^\[(\d+)\]\s*=\s*\{", line)
                if not m:
                    continue
                cur_id = int(m.group(1))
                block_lines = [raw]
                depth = raw.count("{") - raw.count("}")
                if depth <= 0:
                    depth = 0
            else:
                block_lines.append(raw)
                depth += raw.count("{") - raw.count("}")

            if cur_id is not None and depth <= 0:
                yield cur_id, "\n".join(block_lines)
                cur_id = None
                block_lines = []
                depth = 0

    def _load_store_type_defaults_from_lua_table(path: Path) -> dict[int, list[int]]:
        """Best-effort parser for decrypted TableData store.lua grouped by store type."""
        out: dict[int, list[int]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for cur_id, block in _iter_lua_indexed_blocks(lines):
            m_type = re.search(r"\btype\s*=\s*(\d+)", block)
            if not m_type:
                continue
            store_type = int(m_type.group(1))
            if store_type <= 0:
                continue
            arr = out.setdefault(store_type, [])
            if cur_id not in arr:
                arr.append(cur_id)

        return out

    def _load_store_item_meta_from_lua_table(path: Path) -> dict[int, dict[str, object]]:
        out: dict[int, dict[str, object]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for cur_id, block in _iter_lua_indexed_blocks(lines):
            m_type = re.search(r"\btype\s*=\s*(\d+)", block)
            if not m_type:
                continue
            m_jump = re.search(r"\bjump_type\s*=\s*\"([^\"]*)\"", block)
            m_gem = re.search(r"\bgem_price\s*=\s*(-?\d+)", block)
            m_coin = re.search(r"\bcoin_price\s*=\s*(-?\d+)", block)
            m_order = re.search(r"\border\s*=\s*(-?\d+)", block)
            out[cur_id] = {
                "type": _as_int(m_type.group(1), 0),
                "jump_type": (m_jump.group(1).strip() if m_jump else ""),
                "gem_price": _as_int(m_gem.group(1), 0) if m_gem else 0,
                "coin_price": _as_int(m_coin.group(1), 0) if m_coin else 0,
                "order": _as_int(m_order.group(1), 0) if m_order else 0,
            }

        return out

    def _load_bag_to_skin_ids_from_lua_table(path: Path) -> dict[int, list[int]]:
        out: dict[int, list[int]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for skin_id, block in _iter_lua_indexed_blocks(lines):
            m_bag = re.search(r"\bbag_id_index\s*=\s*(\d+)", block)
            if not m_bag:
                continue
            bag_id = _as_int(m_bag.group(1), 0)
            if bag_id <= 0:
                continue
            arr = out.setdefault(bag_id, [])
            if skin_id not in arr:
                arr.append(skin_id)

        return out

    def _load_bag_exchange_gold_from_lua_table(path: Path) -> dict[int, int]:
        out: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for bag_id, block in _iter_lua_indexed_blocks(lines):
            parsed_bag_id = _as_int(bag_id, 0)
            if parsed_bag_id <= 0:
                continue

            m_exchange = re.search(r"\bexchange_gold\s*=\s*(-?\d+)", block)
            if not m_exchange:
                continue

            out[parsed_bag_id] = max(0, _as_int(m_exchange.group(1), 0))

        return out

    def _load_bag_type_from_lua_table(path: Path) -> dict[int, int]:
        out: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for bag_id, block in _iter_lua_indexed_blocks(lines):
            parsed_bag_id = _as_int(bag_id, 0)
            if parsed_bag_id <= 0:
                continue

            m_type = re.search(r"\btype\s*=\s*(\d+)", block)
            if not m_type:
                continue

            out[parsed_bag_id] = max(0, _as_int(m_type.group(1), 0))

        return out

    def _load_bag_to_character_ids_from_lua_table(path: Path) -> dict[int, int]:
        out: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for bag_id, block in _iter_lua_indexed_blocks(lines):
            parsed_bag_id = _as_int(bag_id, 0)
            if parsed_bag_id <= 0:
                continue

            m_type = re.search(r"\btype\s*=\s*(\d+)", block)
            if not m_type or _as_int(m_type.group(1), 0) != _BAG_TYPE_HERO:
                continue

            m_connect = re.search(r"\bconnect_id\s*=\s*(\d+)", block)
            connect_id = _as_int(m_connect.group(1), 0) if m_connect else 0
            if connect_id > 0:
                out[parsed_bag_id] = connect_id

        return out

    def _extract_lua_named_table_body(lines: list[str], table_name: str) -> list[str]:
        """
        Return raw lines inside `table_name = { ... }` (without the outer braces).
        Best-effort line parser for decrypted Lua tables.
        """
        pattern = re.compile(rf"^\s*{re.escape(table_name)}\s*=\s*\{{")
        in_table = False
        depth = 0
        out: list[str] = []

        for raw in lines:
            if not in_table:
                if not pattern.match(raw):
                    continue
                in_table = True
                depth = raw.count("{") - raw.count("}")

            # Closing line of the table should not be included in body.
            if depth <= 0:
                break

            next_depth = depth + raw.count("{") - raw.count("}")
            if next_depth <= 0:
                break
            out.append(raw)
            depth = next_depth

        return out

    def _iter_lua_array_blocks(lines: list[str]):
        """Yield top-level `{ ... }` blocks from a Lua array body."""
        in_block = False
        depth = 0
        block_lines: list[str] = []

        for raw in lines:
            stripped = raw.strip()
            if not in_block:
                if not stripped.startswith("{"):
                    continue
                in_block = True
                block_lines = [raw]
                depth = raw.count("{") - raw.count("}")
            else:
                block_lines.append(raw)
                depth += raw.count("{") - raw.count("}")

            if in_block and depth <= 0:
                yield "\n".join(block_lines)
                in_block = False
                depth = 0
                block_lines = []

    def _load_user_guide_meta_from_lua_table(path: Path) -> dict[int, dict[str, int]]:
        out: dict[int, dict[str, int]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        table_lines = _extract_lua_named_table_body(lines, "user_guide")
        if not table_lines:
            return out

        for block in _iter_lua_array_blocks(table_lines):
            m_id = re.search(r"\bid\s*=\s*(-?\d+)", block)
            if not m_id:
                continue

            guide_id = max(0, _as_int(m_id.group(1), 0))
            if guide_id <= 0:
                continue

            m_map = re.search(r"\bmap_id\s*=\s*(-?\d+)", block)
            m_mode = re.search(r"\bmode_id\s*=\s*(-?\d+)", block)
            out[guide_id] = {
                "guide_id": guide_id,
                "map_id": max(1, _as_int(m_map.group(1), 3)) if m_map else 3,
                "mode_id": max(1, _as_int(m_mode.group(1), 2)) if m_mode else 2,
            }

        return out

    def _load_character_meta_from_lua_table(path: Path) -> dict[int, dict[str, object]]:
        out: dict[int, dict[str, object]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        def _array_ints(block: str, key: str) -> list[int]:
            m = re.search(rf"\b{re.escape(key)}\s*=\s*\{{([^}}]*)\}}", block, re.S)
            if not m:
                return []
            values = [_as_int(x, 0) for x in re.findall(r"-?\d+", m.group(1))]
            out_vals: list[int] = []
            for value in values:
                if value > 0 and value not in out_vals:
                    out_vals.append(value)
            return out_vals

        def _first_positive_array_int(block: str, key: str) -> int:
            values = _array_ints(block, key)
            if values:
                return values[0]
            return 0

        for character_id, block in _iter_lua_indexed_blocks(lines):
            if character_id <= 0:
                continue
            m_camp = re.search(r"\bcamp\s*=\s*(-?\d+)", block)
            camp = _as_int(m_camp.group(1), 1) if m_camp else 1
            if camp not in (1, 2):
                camp = 1
            m_available = re.search(r"\bavailable\s*=\s*(-?\d+)", block)
            m_unique = re.search(r"\bhas_unique_skill\s*=\s*(-?\d+)", block)
            m_default_head = re.search(r"\bdefault_head_skin\s*=\s*(-?\d+)", block)
            m_default_body = re.search(r"\bdefault_body_skin\s*=\s*(-?\d+)", block)

            primary_weapons = _array_ints(block, "primary_weapon")
            secondary_weapons = _array_ints(block, "secondary_weapon")
            main_skills = _array_ints(block, "main_skill")
            sub_skills = _array_ints(block, "sub_skills")
            out[character_id] = {
                "camp": camp,
                "available": max(0, _as_int(m_available.group(1), 1)) if m_available else 1,
                "has_unique_skill": max(0, _as_int(m_unique.group(1), 1)) if m_unique else 1,
                "default_head_skin": max(0, _as_int(m_default_head.group(1), 0)) if m_default_head else 0,
                "default_body_skin": max(0, _as_int(m_default_body.group(1), 0)) if m_default_body else 0,
                "primary_weapons": primary_weapons,
                "secondary_weapons": secondary_weapons,
                "main_skills": main_skills,
                "sub_skills": sub_skills,
                # Compatibility shortcuts used by existing code paths.
                "primary_weapon": primary_weapons[0] if primary_weapons else _first_positive_array_int(block, "primary_weapon"),
                "secondary_weapon": secondary_weapons[0] if secondary_weapons else _first_positive_array_int(block, "secondary_weapon"),
                "main_skill": main_skills[0] if main_skills else _first_positive_array_int(block, "main_skill"),
                "sub_skill": sub_skills[0] if sub_skills else _first_positive_array_int(block, "sub_skills"),
            }

        return out

    def _load_skin_meta_from_lua_table(path: Path) -> dict[int, dict[str, object]]:
        out: dict[int, dict[str, object]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        skin_table_lines = _extract_lua_named_table_body(lines, "skin")
        if not skin_table_lines:
            return out

        for skin_id, block in _iter_lua_indexed_blocks(skin_table_lines):
            parsed_skin_id = _as_int(skin_id, 0)
            if parsed_skin_id <= 0:
                continue

            m_type = re.search(r"\btype\s*=\s*(-?\d+)", block)
            m_bag = re.search(r"\bbag_id_index\s*=\s*(-?\d+)", block)
            m_chars = re.search(r"\bcharacters\s*=\s*\{([^}]*)\}", block, re.S)
            m_props = re.search(r"\bhandprops\s*=\s*\{([^}]*)\}", block, re.S)

            characters = [_as_int(x, 0) for x in re.findall(r"-?\d+", m_chars.group(1))] if m_chars else []
            characters = [x for x in characters if x > 0]
            handprops = [_as_int(x, 0) for x in re.findall(r"-?\d+", m_props.group(1))] if m_props else []
            handprops = [x for x in handprops if x > 0]

            out[parsed_skin_id] = {
                "type": _as_int(m_type.group(1), 0) if m_type else 0,
                "bag_id_index": _as_int(m_bag.group(1), 0) if m_bag else 0,
                "characters": characters,
                "handprops": handprops,
            }

        return out

    def _load_bundle_contents_from_lua_table(path: Path) -> dict[int, list[int]]:
        out: dict[int, list[int]] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for bundle_id, block in _iter_lua_indexed_blocks(lines):
            parsed_bundle_id = _as_int(bundle_id, 0)
            if parsed_bundle_id <= 0:
                continue

            m_content = re.search(r"\bcontent\s*=\s*\{([^}]*)\}", block, re.S)
            if not m_content:
                continue

            content_ids = [_as_int(x, 0) for x in re.findall(r"\d+", m_content.group(1))]
            content_ids = [x for x in content_ids if x > 0]
            if content_ids:
                out[parsed_bundle_id] = content_ids

        return out

    def _load_bundle_default_prices_from_lua_table(path: Path) -> dict[int, int]:
        out: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for bundle_id, block in _iter_lua_indexed_blocks(lines):
            parsed_bundle_id = _as_int(bundle_id, 0)
            if parsed_bundle_id <= 0:
                continue

            m_price = re.search(r"\bprice\s*=\s*\{([^}]*)\}", block, re.S)
            if not m_price:
                continue

            price_values = [_as_int(x, 0) for x in re.findall(r"\d+", m_price.group(1))]
            price_values = [x for x in price_values if x > 0]
            if not price_values:
                continue

            # Bundle UI expects a single dynamic price value. Use the highest configured value.
            out[parsed_bundle_id] = max(price_values)

        return out

    def _load_chest_to_box_ids_from_lua_table(path: Path) -> dict[int, int]:
        out: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return out

        for chest_id, block in _iter_lua_indexed_blocks(lines):
            parsed_chest_id = _as_int(chest_id, 0)
            if parsed_chest_id <= 0:
                continue

            m_box_id = re.search(r"\bbox_id\s*=\s*(\d+)", block)
            parsed_box_id = _as_int(m_box_id.group(1), 0) if m_box_id else parsed_chest_id
            if parsed_box_id <= 0:
                continue

            out[parsed_chest_id] = parsed_box_id

        return out

    def _load_box_reward_maps_from_lua_table(path: Path) -> tuple[
        dict[int, list[int]],
        dict[int, list[int]],
        dict[int, int],
        dict[int, int],
        dict[int, int],
    ]:
        box_to_set_ids: dict[int, list[int]] = {}
        set_to_collection_ids: dict[int, list[int]] = {}
        collection_to_item_id: dict[int, int] = {}
        box_display_bag_id: dict[int, int] = {}
        collection_to_weight: dict[int, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return box_to_set_ids, set_to_collection_ids, collection_to_item_id, box_display_bag_id, collection_to_weight

        for cur_id, block in _iter_lua_indexed_blocks(lines):
            m_sets = re.search(r"\bcollection_sets\s*=\s*\{([^}]*)\}", block, re.S)
            if m_sets:
                set_ids = [
                    _as_int(x, 0)
                    for x in re.findall(r"\d+", m_sets.group(1))
                ]
                set_ids = [x for x in set_ids if x > 0]
                if set_ids:
                    box_to_set_ids[cur_id] = set_ids
                m_display = re.search(r"\bdisplay_skin\s*=\s*(\d+)", block)
                if m_display:
                    box_display = _as_int(m_display.group(1), 0)
                    if box_display > 0:
                        box_display_bag_id[cur_id] = box_display

            m_collections = re.search(r"\bcollections\s*=\s*\{([^}]*)\}", block, re.S)
            if m_collections:
                collection_ids = [
                    _as_int(x, 0)
                    for x in re.findall(r"\d+", m_collections.group(1))
                ]
                collection_ids = [x for x in collection_ids if x > 0]
                if collection_ids:
                    set_to_collection_ids[cur_id] = collection_ids

            m_item = re.search(r"\bitem_id\s*=\s*(\d+)", block)
            if m_item:
                item_id = _as_int(m_item.group(1), 0)
                if item_id > 0:
                    collection_to_item_id[cur_id] = item_id
            m_weight = re.search(r"\bweight\s*=\s*(-?\d+)", block)
            if m_weight:
                collection_to_weight[cur_id] = max(1, _as_int(m_weight.group(1), 1))

        return box_to_set_ids, set_to_collection_ids, collection_to_item_id, box_display_bag_id, collection_to_weight

    def _sanitize_store_type_defaults(
        source: dict[int, list[int]],
        item_meta: dict[int, dict[str, object]],
        bag_type_by_id: dict[int, int],
        chest_to_box_ids: dict[int, int],
        box_display_map: dict[int, int],
        box_to_set_ids: dict[int, list[int]],
        set_to_collection_ids: dict[int, list[int]],
        collection_to_item_id: dict[int, int],
    ) -> dict[int, list[int]]:
        out: dict[int, list[int]] = {}
        for store_type, item_ids in source.items():
            if not isinstance(item_ids, list):
                continue
            sanitized: list[int] = []
            for item_id_raw in item_ids:
                item_id = _as_int(item_id_raw, 0)
                if item_id <= 0:
                    continue
                meta = item_meta.get(item_id, {})
                jump_type = str(meta.get("jump_type") or "").strip()
                has_price = (
                    _as_int(meta.get("gem_price"), 0) > 0
                    or _as_int(meta.get("coin_price"), 0) > 0
                )

                if store_type == _STORE_TYPE_CHARACTER:
                    # Character tab: keep only direct-purchase entries with explicit price.
                    if jump_type or not has_price:
                        continue
                elif store_type == _STORE_TYPE_BOX:
                    # Supplies store ids are chest ids; reward data is keyed by box ids.
                    if item_id in _STORE_TYPE_9_TEXTURE_BLACKLIST_IDS:
                        continue
                    resolved_box_id = _as_int(chest_to_box_ids.get(item_id), item_id)
                    display_bag_id = _as_int(box_display_map.get(resolved_box_id), 0)
                    if display_bag_id <= 0:
                        continue

                if item_id not in sanitized:
                    sanitized.append(item_id)

            if not sanitized:
                for item_id_raw in item_ids:
                    parsed = _as_int(item_id_raw, 0)
                    if store_type == _STORE_TYPE_BOX and parsed in _STORE_TYPE_9_TEXTURE_BLACKLIST_IDS:
                        continue
                    if parsed > 0 and parsed not in sanitized:
                        sanitized.append(parsed)

            if store_type == _STORE_TYPE_BOX:
                sanitized = sanitized[:_STORE_TYPE_9_LIMIT]

            out[store_type] = sanitized[:_STORE_ITEMS_PER_TYPE_LIMIT]

        return out

    def _build_store_item_to_type_map(source: dict[int, list[int]]) -> dict[int, int]:
        out: dict[int, int] = {}
        for store_type, item_ids in source.items():
            if not isinstance(item_ids, list):
                continue
            for item_id in item_ids:
                parsed = _as_int(item_id, 0)
                if parsed > 0 and parsed not in out:
                    out[parsed] = store_type
        return out

    _STORE_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "store.lua"
    _BOX_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "box.lua"
    _CHEST_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "chest.lua"
    _BAG_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "bag.lua"
    _SKIN_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "skin.lua"
    _BUNDLE_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "bundle.lua"
    _CHARACTER_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "character.lua"
    _USER_GUIDE_LUA_PATH = DIR / "decrypted_lua" / "Configs" / "TableData" / "user_guide.lua"

    (
        _BOX_ID_TO_COLLECTION_SET_IDS,
        _BOX_COLLECTION_SET_TO_COLLECTION_IDS,
        _BOX_COLLECTION_ID_TO_ITEM_ID,
        _BOX_ID_TO_DISPLAY_BAG_ID,
        _BOX_COLLECTION_ID_TO_WEIGHT,
    ) = _load_box_reward_maps_from_lua_table(_BOX_LUA_PATH)

    _CHEST_ID_TO_BOX_ID = _load_chest_to_box_ids_from_lua_table(_CHEST_LUA_PATH)

    _BAG_TO_SKIN_IDS = _load_bag_to_skin_ids_from_lua_table(_SKIN_LUA_PATH)
    _SKIN_META_BY_ID = _load_skin_meta_from_lua_table(_SKIN_LUA_PATH)
    _BAG_EXCHANGE_GOLD = _load_bag_exchange_gold_from_lua_table(_BAG_LUA_PATH)
    _BAG_TYPE_BY_ID = _load_bag_type_from_lua_table(_BAG_LUA_PATH)
    _BAG_TO_CHARACTER_ID = _load_bag_to_character_ids_from_lua_table(_BAG_LUA_PATH)
    _CHARACTER_META_BY_ID = _load_character_meta_from_lua_table(_CHARACTER_LUA_PATH)
    _USER_GUIDE_META_BY_ID = _load_user_guide_meta_from_lua_table(_USER_GUIDE_LUA_PATH)
    if not _USER_GUIDE_META_BY_ID:
        _USER_GUIDE_META_BY_ID = {
            1: {"guide_id": 1, "map_id": 3, "mode_id": 2},
        }
    _HERO_BASE_BAG_IDS: list[int] = sorted(
        _as_int(_bag_id, 0)
        for _bag_id, _bag_type in _BAG_TYPE_BY_ID.items()
        if _as_int(_bag_type, 0) == _BAG_TYPE_HERO and _as_int(_bag_id, 0) > 0 and _as_int(_bag_id, 0) % 10 == 0
    )
    _CHARACTER_IDS_BY_CAMP: dict[int, list[int]] = {1: [], 2: []}
    for _character_id, _character_meta in sorted(_CHARACTER_META_BY_ID.items()):
        _camp = _as_int(_character_meta.get("camp"), 1)
        if _camp not in (1, 2):
            continue
        if _as_int(_character_meta.get("available"), 1) <= 0:
            continue
        _CHARACTER_IDS_BY_CAMP[_camp].append(_character_id)

    _CHAR_DEFAULT_LOADOUTS: dict[int, tuple[int, int, int, int]] = {}
    for _character_id, _character_meta in _CHARACTER_META_BY_ID.items():
        _primary_opts = _character_meta.get("primary_weapons")
        _secondary_opts = _character_meta.get("secondary_weapons")
        _main_opts = _character_meta.get("main_skills")
        _sub_opts = _character_meta.get("sub_skills")
        if not isinstance(_primary_opts, list):
            _primary_opts = []
        if not isinstance(_secondary_opts, list):
            _secondary_opts = []
        if not isinstance(_main_opts, list):
            _main_opts = []
        if not isinstance(_sub_opts, list):
            _sub_opts = []
        _pri = _as_int(_primary_opts[0], _as_int(_character_meta.get("primary_weapon"), 0)) if _primary_opts else _as_int(_character_meta.get("primary_weapon"), 0)
        _sec = _as_int(_secondary_opts[0], _as_int(_character_meta.get("secondary_weapon"), 0)) if _secondary_opts else _as_int(_character_meta.get("secondary_weapon"), 0)
        _main = _as_int(_main_opts[0], _as_int(_character_meta.get("main_skill"), 0)) if _main_opts else _as_int(_character_meta.get("main_skill"), 0)
        _sub = _as_int(_sub_opts[0], _as_int(_character_meta.get("sub_skill"), 0)) if _sub_opts else _as_int(_character_meta.get("sub_skill"), 0)
        if _pri > 0 and _sec > 0 and _main > 0 and _sub > 0:
            _CHAR_DEFAULT_LOADOUTS[_character_id] = (_pri, _sec, _main, _sub)
    for _cid, _defaults in {
        1: (10036, 10074, 295, 299),
        2: (10037, 10075, 296, 300),
        3: (10038, 10076, 297, 301),
        4: (10039, 10077, 295, 299),
        5: (10040, 10078, 296, 300),
        101: (10036, 10074, 295, 299),
    }.items():
        _CHAR_DEFAULT_LOADOUTS.setdefault(_cid, _defaults)

    _BUNDLE_ID_TO_CONTENT_IDS = _load_bundle_contents_from_lua_table(_BUNDLE_LUA_PATH)

    _KNOWN_BOX_IDS: set[int] = set()
    _KNOWN_BOX_IDS.update(_as_int(x, 0) for x in _BOX_ID_TO_COLLECTION_SET_IDS.keys())
    _KNOWN_BOX_IDS.update(_as_int(x, 0) for x in _BOX_ID_TO_DISPLAY_BAG_ID.keys())
    _KNOWN_BOX_IDS.update(_as_int(x, 0) for x in _CHEST_ID_TO_BOX_ID.values())
    _KNOWN_BOX_IDS = {x for x in _KNOWN_BOX_IDS if x > 0}

    _SKIN_ID_TO_BAG_ID: dict[int, int] = {}
    for _bag_id, _skin_ids in _BAG_TO_SKIN_IDS.items():
        if not isinstance(_skin_ids, list):
            continue
        for _skin_id in _skin_ids:
            _sid = _as_int(_skin_id, 0)
            if _sid > 0 and _sid not in _SKIN_ID_TO_BAG_ID:
                _SKIN_ID_TO_BAG_ID[_sid] = _as_int(_bag_id, 0)

    _SKIN_ID_TO_TYPE: dict[int, int] = {}
    _SKIN_ID_TO_CHARACTERS: dict[int, list[int]] = {}
    _SKIN_ID_TO_HANDPROPS: dict[int, list[int]] = {}
    for _skin_id, _meta in _SKIN_META_BY_ID.items():
        _sid = _as_int(_skin_id, 0)
        if _sid <= 0 or not isinstance(_meta, dict):
            continue
        _SKIN_ID_TO_TYPE[_sid] = _as_int(_meta.get("type"), 0)
        _chars = _meta.get("characters")
        if isinstance(_chars, list):
            _SKIN_ID_TO_CHARACTERS[_sid] = [
                _as_int(x, 0) for x in _chars
                if _as_int(x, 0) > 0
            ]
        _props = _meta.get("handprops")
        if isinstance(_props, list):
            _SKIN_ID_TO_HANDPROPS[_sid] = [
                _as_int(x, 0) for x in _props
                if _as_int(x, 0) > 0
            ]

    _STORE_TYPE_DEFAULTS_FROM_LUA = _load_store_type_defaults_from_lua_table(_STORE_LUA_PATH)
    _STORE_ITEM_META_FROM_LUA = _load_store_item_meta_from_lua_table(_STORE_LUA_PATH)
    if _STORE_TYPE_DEFAULTS_FROM_LUA:
        _SANITIZED_STORE_DEFAULTS = _sanitize_store_type_defaults(
            _STORE_TYPE_DEFAULTS_FROM_LUA,
            _STORE_ITEM_META_FROM_LUA,
            _BAG_TYPE_BY_ID,
            _CHEST_ID_TO_BOX_ID,
            _BOX_ID_TO_DISPLAY_BAG_ID,
            _BOX_ID_TO_COLLECTION_SET_IDS,
            _BOX_COLLECTION_SET_TO_COLLECTION_IDS,
            _BOX_COLLECTION_ID_TO_ITEM_ID,
        )
        for _store_type, _item_ids in _SANITIZED_STORE_DEFAULTS.items():
            if _item_ids:
                _STORE_TYPE_DEFAULT_ITEMS[_store_type] = _item_ids[:_STORE_ITEMS_PER_TYPE_LIMIT]

    _type1_agent_candidates: list[tuple[int, int]] = []
    for _meta_item_id_raw, _meta_item in _STORE_ITEM_META_FROM_LUA.items():
        _meta_item_id = _as_int(_meta_item_id_raw, 0)
        if _meta_item_id <= 0:
            continue
        if _as_int(_BAG_TYPE_BY_ID.get(_meta_item_id), 0) != _BAG_TYPE_HERO:
            continue
        _has_price = (
            _as_int(_meta_item.get("gem_price"), 0) > 0
            or _as_int(_meta_item.get("coin_price"), 0) > 0
        )
        if not _has_price:
            continue
        _type1_order = _as_int(_meta_item.get("order"), 0)
        _type1_agent_candidates.append((_type1_order, _meta_item_id))

    _type1_agent_candidates.sort(key=lambda x: (x[0], x[1]))
    _type1_agent_ids: list[int] = []
    for _, _cand_id in _type1_agent_candidates:
        if _cand_id not in _type1_agent_ids:
            _type1_agent_ids.append(_cand_id)
    if _type1_agent_ids:
        _STORE_TYPE_DEFAULT_ITEMS[_STORE_TYPE_CHARACTER] = _type1_agent_ids[:_STORE_ITEMS_PER_TYPE_LIMIT]

    _STORE_ITEM_TO_TYPE = _build_store_item_to_type_map(_STORE_TYPE_DEFAULT_ITEMS)
    _STORE_TYPE_9_BOX_IDS: set[int] = set()
    for _type9_store_item_id_raw in _STORE_TYPE_DEFAULT_ITEMS.get(_STORE_TYPE_BOX, []):
        _type9_store_item_id = _as_int(_type9_store_item_id_raw, 0)
        if _type9_store_item_id <= 0:
            continue
        _resolved_type9_box_id = _as_int(_CHEST_ID_TO_BOX_ID.get(_type9_store_item_id), _type9_store_item_id)
        if _resolved_type9_box_id > 0:
            _STORE_TYPE_9_BOX_IDS.add(_resolved_type9_box_id)

    _STORE_TYPE_9_REWARD_ITEM_IDS: set[int] = set()
    for _type9_box_id in _STORE_TYPE_9_BOX_IDS:
        for _set_id in _BOX_ID_TO_COLLECTION_SET_IDS.get(_type9_box_id, []):
            for _collection_id in _BOX_COLLECTION_SET_TO_COLLECTION_IDS.get(_set_id, []):
                _reward_item_id = _as_int(_BOX_COLLECTION_ID_TO_ITEM_ID.get(_collection_id), 0)
                if _reward_item_id > 0:
                    _STORE_TYPE_9_REWARD_ITEM_IDS.add(_reward_item_id)

    def _load_sproto_field_tags_from_cs(path: Path) -> dict[str, int]:
        tags: dict[str, int] = {}
        try:
            lines = path.read_text(encoding="utf-8", errors="ignore").splitlines()
        except Exception:
            return tags

        in_fields = False
        for raw in lines:
            line = raw.strip()
            if not in_fields:
                if line.startswith("// Fields"):
                    in_fields = True

            if line.startswith("// Properties"):
                break

            m = re.match(r"^private\s+(?!static).*?\s+_([A-Za-z0-9_]+)\s*;", line)
            if not m:
                continue

            field_name = m.group(1)
            tags[field_name] = len(tags)

        return tags

    def _field_tag_or_default(tags: dict[str, int], field_name: str, default: int, contract_name: str) -> int:
        tag = _as_int(tags.get(field_name), -1)
        if tag >= 0:
            return tag
        msg = f"[CONTRACT][WARN] {contract_name}.{field_name} tag missing in decompiled source; fallback={default}"
        if _STRICT_SOURCE_CONTRACTS:
            raise RuntimeError(msg.replace("[WARN]", "[FATAL]"))
        _append_utf8_log(msg)
        return default

    _CS_NOTIFY_UNLOCK_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.notify_unlock_msg.response.cs"
    _CS_SELECT_CHARACTER_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.SelectCharacterInfo.cs"
    _CS_CLIENT_CHARACTER_PATH = DIR / "decompiled_cs" / "_global" / "client.Character.cs"
    _CS_ROLE_DATA_PATH = DIR / "decompiled_cs" / "_global" / "client.role_data.cs"
    _CS_LOAD_ROLE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.load_role.response.cs"
    _CS_QUERY_ROLE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.query_role.response.cs"
    _CS_MONEY_PATH = DIR / "decompiled_cs" / "_global" / "client.Money.cs"
    _CS_STAT_PATH = DIR / "decompiled_cs" / "_global" / "client.Stat.cs"

    _NOTIFY_UNLOCK_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_NOTIFY_UNLOCK_RESPONSE_PATH)
    _SELECT_CHARACTER_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_SELECT_CHARACTER_INFO_PATH)
    _CLIENT_CHARACTER_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHARACTER_PATH)
    _ROLE_DATA_TAGS = _load_sproto_field_tags_from_cs(_CS_ROLE_DATA_PATH)
    _LOAD_ROLE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_LOAD_ROLE_RESPONSE_PATH)
    _QUERY_ROLE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_QUERY_ROLE_RESPONSE_PATH)
    _MONEY_TAGS = _load_sproto_field_tags_from_cs(_CS_MONEY_PATH)
    _STAT_TAGS = _load_sproto_field_tags_from_cs(_CS_STAT_PATH)

    _TAG_NOTIFY_UNLOCK_ERRORCODE = _field_tag_or_default(
        _NOTIFY_UNLOCK_RESPONSE_TAGS, "errorcode", 0, "client.notify_unlock_msg.response"
    )
    _TAG_NOTIFY_UNLOCK_CHARACTERS = _field_tag_or_default(
        _NOTIFY_UNLOCK_RESPONSE_TAGS, "unlock_characters", 1, "client.notify_unlock_msg.response"
    )

    _TAG_SELECT_CHARACTER_ID = _field_tag_or_default(
        _SELECT_CHARACTER_INFO_TAGS, "character_id", 0, "game.SelectCharacterInfo"
    )
    _TAG_SELECT_CHARACTER_UNLOCK_TIME = _field_tag_or_default(
        _SELECT_CHARACTER_INFO_TAGS, "unlock_time", 1, "game.SelectCharacterInfo"
    )
    _TAG_SELECT_CHARACTER_LIMIT_TIME = _field_tag_or_default(
        _SELECT_CHARACTER_INFO_TAGS, "limit_time", 2, "game.SelectCharacterInfo"
    )

    _TAG_CLIENT_CHARACTER_ID = _field_tag_or_default(
        _CLIENT_CHARACTER_TAGS, "id", 0, "client.Character"
    )
    _TAG_CLIENT_CHARACTER_UNLOCK_TIME = _field_tag_or_default(
        _CLIENT_CHARACTER_TAGS, "unlock_time", 9, "client.Character"
    )
    _TAG_CLIENT_CHARACTER_LIMIT_TIME = _field_tag_or_default(
        _CLIENT_CHARACTER_TAGS, "limit_time", 10, "client.Character"
    )

    _TAG_ROLE_DATA_NAME = _field_tag_or_default(_ROLE_DATA_TAGS, "name", 0, "client.role_data")
    _TAG_ROLE_DATA_LEVEL = _field_tag_or_default(_ROLE_DATA_TAGS, "level", 1, "client.role_data")
    _TAG_ROLE_DATA_EXP = _field_tag_or_default(_ROLE_DATA_TAGS, "exp", 2, "client.role_data")
    _TAG_ROLE_DATA_STATS = _field_tag_or_default(_ROLE_DATA_TAGS, "stats", 3, "client.role_data")
    _TAG_ROLE_DATA_ICON = _field_tag_or_default(_ROLE_DATA_TAGS, "icon", 4, "client.role_data")
    _TAG_ROLE_DATA_MONEY = _field_tag_or_default(_ROLE_DATA_TAGS, "money", 5, "client.role_data")
    _TAG_ROLE_DATA_CHARACTERS = _field_tag_or_default(_ROLE_DATA_TAGS, "characters", 6, "client.role_data")
    _TAG_ROLE_DATA_EVENT_STATS = _field_tag_or_default(_ROLE_DATA_TAGS, "event_stats", 7, "client.role_data")
    _TAG_ROLE_DATA_CLIENT_CONFIG = _field_tag_or_default(_ROLE_DATA_TAGS, "client_config", 8, "client.role_data")
    _TAG_ROLE_DATA_ICON_URL = _field_tag_or_default(_ROLE_DATA_TAGS, "icon_url", 9, "client.role_data")
    _TAG_ROLE_DATA_TIME_ZONE = _field_tag_or_default(_ROLE_DATA_TAGS, "time_zone", 10, "client.role_data")
    _TAG_ROLE_DATA_ICON_FRAME = _field_tag_or_default(_ROLE_DATA_TAGS, "icon_frame", 11, "client.role_data")
    _TAG_ROLE_DATA_CREATE_TIME = _field_tag_or_default(_ROLE_DATA_TAGS, "create_time", 12, "client.role_data")
    _TAG_ROLE_DATA_CURRENT_SEASON_ID = _field_tag_or_default(_ROLE_DATA_TAGS, "current_season_id", 13, "client.role_data")
    _TAG_ROLE_DATA_IS_ACTIVE = _field_tag_or_default(_ROLE_DATA_TAGS, "is_active", 14, "client.role_data")

    _TAG_LOAD_ROLE_ERRORCODE = _field_tag_or_default(_LOAD_ROLE_RESPONSE_TAGS, "errorcode", 0, "client.load_role.response")
    _TAG_LOAD_ROLE_UID = _field_tag_or_default(_LOAD_ROLE_RESPONSE_TAGS, "uid", 1, "client.load_role.response")
    _TAG_LOAD_ROLE_ROLE = _field_tag_or_default(_LOAD_ROLE_RESPONSE_TAGS, "role", 2, "client.load_role.response")

    _TAG_QUERY_ROLE_ERRORCODE = _field_tag_or_default(_QUERY_ROLE_RESPONSE_TAGS, "errorcode", 0, "client.query_role.response")
    _TAG_QUERY_ROLE_UID = _field_tag_or_default(_QUERY_ROLE_RESPONSE_TAGS, "uid", 1, "client.query_role.response")
    _TAG_QUERY_ROLE_ROLE = _field_tag_or_default(_QUERY_ROLE_RESPONSE_TAGS, "role", 2, "client.query_role.response")
    _TAG_QUERY_ROLE_SHOW_CHARACTER = _field_tag_or_default(_QUERY_ROLE_RESPONSE_TAGS, "show_character", 3, "client.query_role.response")

    _TAG_MONEY_TYPE = _field_tag_or_default(_MONEY_TAGS, "money_type", 0, "client.Money")
    _TAG_MONEY_VALUE = _field_tag_or_default(_MONEY_TAGS, "money", 1, "client.Money")

    _TAG_STAT_TYPE = _field_tag_or_default(_STAT_TAGS, "type", 0, "client.Stat")
    _TAG_STAT_VALUE = _field_tag_or_default(_STAT_TAGS, "value", 1, "client.Stat")

    _CS_REQ_PING_BATTLE_ZONE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqPingBattleZoneList.response.cs"
    _CS_BATTLE_ZONE_PATH = DIR / "decompiled_cs" / "_global" / "game.BattleZone.cs"
    _CS_REQ_OPEN_MODE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqOpenMode.request.cs"
    _CS_REQ_OPEN_MODE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqOpenMode.response.cs"
    _CS_RSP_OPEN_MODE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspOpenMode.request.cs"
    _CS_RSP_CHOOSE_MAP_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspChooseMap.request.cs"
    _CS_REQ_MODE_CHOOSE_MAP_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqModeChooseMap.request.cs"
    _CS_REQ_CHOOSE_MAP_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqChooseMap.request.cs"
    _CS_REQ_MODE_CHOOSE_CAMP_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqModeChooseCamp.request.cs"
    _CS_REQ_CREATE_ROOM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqCreateRoom.request.cs"
    _CS_REQ_CREATE_ROOM_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqCreateRoom.response.cs"
    _CS_REQ_ROOM_START_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRoomStart.request.cs"
    _CS_REQ_ROOM_START_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRoomStart.response.cs"
    _CS_RSP_ROOM_START_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomStart.request.cs"
    _CS_REQ_EXCHANGE_POS_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqExchangePos.request.cs"
    _CS_REQ_EXCHANGE_POS_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqExchangePos.response.cs"
    _CS_REQ_CHOOSE_CHARACTER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqChooseCharacter.request.cs"
    _CS_RSP_CHOOSE_CHARACTER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspChooseCharacter.request.cs"
    _CS_REQ_CHOOSE_WEAPON_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqChooseWeapon.request.cs"
    _CS_RSP_CHOOSE_WEAPON_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspChooseWeapon.request.cs"
    _CS_REQ_CHARACTER_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqCharacterInfo.request.cs"
    _CS_RSP_CHARACTER_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspCharacterInfo.request.cs"
    _CS_CHARACTER_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.CharacterInfo.cs"
    _CS_REQ_HALL_CHOOSE_WEAPON_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqHallChooseWeapon.request.cs"
    _CS_RSP_HALL_CHOOSE_WEAPON_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspHallChooseWeapon.request.cs"
    _CS_RSP_UNLOCK_CHARACTER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspUnlockCharacter.request.cs"
    _CS_RSP_SYNC_CHANGED_TASK_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspSyncChangedTaskInfo.request.cs"
    _CS_RSP_SYNC_CHANGED_ACTIVITY_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspSyncChangedActivityInfo.request.cs"
    _CS_ACTIVITY_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.ActivityInfo.cs"
    _CS_ACTIVITY_TASK_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.ActivityTaskInfo.cs"
    _CS_ACTIVITY_VALUE_PATH = DIR / "decompiled_cs" / "_global" / "game.ActivityValue.cs"
    _CS_RSP_ACTIVITY_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspActivityInfo.request.cs"
    _CS_REQ_GET_ACTIVITY_REWARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqGetActivityReward.request.cs"
    _CS_REQ_GET_ACTIVITY_REWARD_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqGetActivityReward.response.cs"
    _CS_REQ_ENTER_PRE_BATTLE_STAGE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqEnterPreBattleStage.request.cs"
    _CS_RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspEnterPreBattleStage.request.cs"
    _CS_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqChooseSpawnRegionConfirm.request.cs"
    _CS_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspChooseSpawnRegionConfirm.request.cs"
    _CS_RSP_CHOOSE_WEAPON_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspChooseWeaponInfo.request.cs"
    _CS_WEAPON_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.WeaponInfo.cs"
    _CS_ATTACHMENT_PATH = DIR / "decompiled_cs" / "_global" / "game.Attachment.cs"
    _CS_RSP_PRE_BATTLE_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspPreBattleInfo.request.cs"
    _CS_PRE_BATTLE_USER_DATA_PATH = DIR / "decompiled_cs" / "_global" / "game.PreBattleUserData.cs"
    _CS_CHOOSE_WEAPON_DATA_PATH = DIR / "decompiled_cs" / "_global" / "game.ChooseWeaponData.cs"
    _CS_REQ_USER_GUIDE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqUserGuide.request.cs"
    _CS_REQ_USER_GUIDE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqUserGuide.response.cs"
    _CS_RSP_USER_GUIDE_ROUND_START_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspUserGuideRoundStart.request.cs"
    _CS_RSP_BATTLE_INFO_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspBattleInfo.request.cs"
    _CS_BATTLE_TEAM_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.BattleTeamInfo.cs"
    _CS_CHARACTER_CHOOSE_PLAYER_PATH = DIR / "decompiled_cs" / "_global" / "game.CharacterChoosePlayer.cs"
    _CS_RSP_BATTLE_RESULT_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspBattleResult.request.cs"
    _CS_RSP_PLAYERS_RESULT_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspPlayersResult.request.cs"
    _CS_RSP_BATTLE_FINAL_RESULT_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspBattleFinalResult.request.cs"
    _CS_BATTLE_PLAYER_RESULT_PATH = DIR / "decompiled_cs" / "_global" / "game.BattlePlayerResult.cs"
    _CS_COMMON_BATTLE_RESULT_PATH = DIR / "decompiled_cs" / "_global" / "game.CommonBattleResult.cs"
    _CS_RANK_PLAYER_RESULT_PATH = DIR / "decompiled_cs" / "_global" / "game.RankPlayerResult.cs"
    _CS_BOX_RESULT_PATH = DIR / "decompiled_cs" / "_global" / "game.BoxResult.cs"
    _CS_REQ_JOIN_ROOM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqJoinRoom.request.cs"
    _CS_REQ_ROOM_KICK_PLAYER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRoomKickPlayer.request.cs"
    _CS_REQ_ROOM_KICK_PLAYER_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRoomKickPlayer.response.cs"
    _CS_REQ_ROOM_CHANGE_BATTLE_ZONE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRoomChangeBattleZone.request.cs"
    _CS_RSP_JOIN_ROOM_STATE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspJoinRoomState.request.cs"
    _CS_RSP_ROOM_ENTERED_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomEntered.request.cs"
    _CS_RSP_ROOM_PLAYER_ENTERED_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomPlayerEntered.request.cs"
    _CS_RSP_ROOM_PLAYER_LEAVED_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomPlayerLeaved.request.cs"
    _CS_RSP_ROOM_OWNER_CHANGED_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomOwnerChanged.request.cs"
    _CS_RSP_ROOM_BATTLE_ZONE_CHANGED_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspRoomBattleZoneChanged.request.cs"
    _CS_RSP_POS_CHANGE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.RspPosChangeNotify.request.cs"
    _CS_GAME_PLAYER_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.PlayerInfo.cs"
    _CS_ROOM_POSITION_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.RoomPositionInfo.cs"

    _CS_CLIENT_QUERY_LEADERBOARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.query_leaderboard.request.cs"
    _CS_CLIENT_QUERY_LEADERBOARD_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.query_leaderboard.response.cs"
    _CS_CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.query_friend_leaderboard.request.cs"
    _CS_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.query_friend_leaderboard.response.cs"
    _CS_CLIENT_QUERY_ROLE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.query_role.request.cs"
    _CS_CLIENT_GM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.gm.request.cs"
    _CS_CLIENT_GM_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.gm.response.cs"
    _CS_CLIENT_GOD_PLAYER_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.god_player_req.request.cs"
    _CS_CLIENT_GOD_PLAYER_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.god_player_req.response.cs"
    _CS_CLIENT_LEADERBOARD_PLAYER_PATH = DIR / "decompiled_cs" / "_global" / "client.LeaderboardPlayer.cs"
    _CS_CLIENT_LEADERBOARD_INFO_PATH = DIR / "decompiled_cs" / "_global" / "client.LeaderboardInfo.cs"
    _CS_CLIENT_QUERY_AD_INFO_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.query_ad_info.response.cs"
    _CS_CLIENT_QUERY_RECRUIT_INFO_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.query_recruit_info.response.cs"
    _CS_CLIENT_SUBMIT_RECRUIT_CODE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.submit_recruit_code_req.request.cs"
    _CS_CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.submit_recruit_code_req.response.cs"
    _CS_CLIENT_CHANGE_ICON_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon.request.cs"
    _CS_CLIENT_CHANGE_ICON_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon.response.cs"
    _CS_CLIENT_CHANGE_ICON_URL_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon_url.request.cs"
    _CS_CLIENT_CHANGE_ICON_URL_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon_url.response.cs"
    _CS_CLIENT_CHANGE_ICON_FRAME_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon_frame.request.cs"
    _CS_CLIENT_CHANGE_ICON_FRAME_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.change_icon_frame.response.cs"
    _CS_CLIENT_GET_RANK_AWARD_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.get_rank_award_req.request.cs"
    _CS_CLIENT_GET_RANK_AWARD_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.get_rank_award_req.response.cs"
    _CS_CLIENT_GET_JF_SWITCH_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.get_jf_switch_req.request.cs"
    _CS_CLIENT_GET_JF_SWITCH_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.get_jf_switch_req.response.cs"
    _CS_CLIENT_SHARE_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.share_req.request.cs"
    _CS_CLIENT_SHARE_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.share_req.response.cs"
    _CS_CLIENT_ACTIVATE_ROLE_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.activate_role_req.request.cs"
    _CS_CLIENT_ACTIVATE_ROLE_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.activate_role_req.response.cs"
    _CS_CLIENT_ADD_SKIN_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.add_skin.request.cs"
    _CS_CLIENT_ADD_SKIN_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "client.add_skin.response.cs"
    _CS_CLIENT_SKIN_UPDATE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.skin_update_notify.request.cs"
    _CS_CLIENT_GET_REWARD_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.get_reward_notify.request.cs"
    _CS_CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.update_recharge_items_notify.request.cs"
    _CS_CLIENT_COMMON_REWARD_PATH = DIR / "decompiled_cs" / "_global" / "client.CommonReward.cs"
    _CS_CLIENT_RECHARGE_ITEM_PATH = DIR / "decompiled_cs" / "_global" / "client.RechargeItem.cs"
    _CS_GAME_REQ_AD_REWARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqAdReward.request.cs"
    _CS_CLIENT_UPDATE_MONEY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.update_money.request.cs"
    _CS_CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.update_event_stat_notify.request.cs"
    _CS_CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.recharge_success_notify.request.cs"
    _CS_CLIENT_NEW_GUY_RECRUITED_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.new_guy_recruited_notify.request.cs"
    _CS_CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.store_discount_info_notify.request.cs"
    _CS_CLIENT_ONLINE_STATUS_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "client.online_status.request.cs"
    _CS_CLIENT_DISCOUNT_STORE_ITEM_PATH = DIR / "decompiled_cs" / "_global" / "client.DiscountStoreItem.cs"

    _CS_MAIL_MAIL_LIST_RES_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.mail_list_res.request.cs"
    _CS_MAIL_MAIL_PATH = DIR / "decompiled_cs" / "_global" / "mail.Mail.cs"
    _CS_MAIL_REWARD_PATH = DIR / "decompiled_cs" / "_global" / "mail.MailReward.cs"
    _CS_MAIL_OPERATE_MAIL_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.operate_mail.request.cs"
    _CS_MAIL_OPERATE_MAIL_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "mail.operate_mail.response.cs"
    _CS_MAIL_OPERATE_RES_PATH = DIR / "decompiled_cs" / "_global" / "mail.MailOperateRes.cs"
    _CS_MAIL_DELETE_ALL_READ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.delete_all_read_mail.request.cs"
    _CS_MAIL_DELETE_ALL_READ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "mail.delete_all_read_mail.response.cs"
    _CS_MAIL_GET_ALL_REWARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.get_all_reward.request.cs"
    _CS_MAIL_GET_ALL_REWARD_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "mail.get_all_reward.response.cs"
    _CS_MAIL_NEW_MAIL_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.new_mail_notify.request.cs"
    _CS_MAIL_DELETE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "mail.mail_delete_notify.request.cs"

    _CS_TEAM_CREATE_TEAM_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.create_team_req.request.cs"
    _CS_TEAM_CREATE_TEAM_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.create_team_req.response.cs"
    _CS_TEAM_KICK_MEMBER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.kick_member_req.request.cs"
    _CS_TEAM_KICK_MEMBER_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.kick_member_req.response.cs"
    _CS_TEAM_LEAVE_TEAM_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.leave_team_req.response.cs"
    _CS_TEAM_OPERATE_READY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.operate_ready_req.request.cs"
    _CS_TEAM_OPERATE_READY_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.operate_ready_req.response.cs"
    _CS_TEAM_CHAT_ENTER_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.chat_enter_team_req.request.cs"
    _CS_TEAM_CHAT_ENTER_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.chat_enter_team_req.response.cs"
    _CS_TEAM_CHANGE_BATTLEZONE_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.change_battlezone_team_req.request.cs"
    _CS_TEAM_CHANGE_BATTLEZONE_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.change_battlezone_team_req.response.cs"
    _CS_TEAM_SYNC_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.team_sync_notify.request.cs"
    _CS_TEAM_MEMBER_SYNC_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.member_sync_notify.request.cs"
    _CS_TEAM_MEMBER_ENTER_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.team_member_enter_notify.request.cs"
    _CS_TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "team.team_member_leave_notify.request.cs"
    _CS_TEAM_DATA_PATH = DIR / "decompiled_cs" / "_global" / "team.TeamData.cs"
    _CS_TEAM_MEMBER_PATH = DIR / "decompiled_cs" / "_global" / "team.TeamMember.cs"
    _CS_TEAM_PLAYER_INFO_PATH = DIR / "decompiled_cs" / "_global" / "team.TeamPlayerInfo.cs"
    _CS_TEAM_RETURN_HALL_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.return_hall_req.response.cs"
    _CS_TEAM_RETURN_TEAM_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "team.return_team_req.response.cs"

    _CS_GAME_ASK_ALL_TASK_INFO_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.AskAllTaskInfo.response.cs"
    _CS_GAME_REQ_GET_TASK_REWARD_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqGetTaskReward.request.cs"
    _CS_GAME_REQ_GET_TASK_REWARD_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqGetTaskReward.response.cs"
    _CS_GAME_REQ_REFRESH_TASK_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRefreshTask.request.cs"
    _CS_GAME_REQ_REFRESH_TASK_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "game.ReqRefreshTask.response.cs"
    _CS_GAME_TASK_INFO_PATH = DIR / "decompiled_cs" / "_global" / "game.TaskInfo.cs"

    _CS_INVITE_REQ_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_req.request.cs"
    _CS_INVITE_REQ_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_req.response.cs"
    _CS_INVITE_REPLY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_reply_req.request.cs"
    _CS_INVITE_REPLY_RESPONSE_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_reply_req.response.cs"
    _CS_INVITE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_notify.request.cs"
    _CS_INVITE_REFUSE_NOTIFY_REQUEST_PATH = DIR / "decompiled_cs" / "_global" / "invite.invite_refuse_notify.request.cs"
    _CS_INVITE_PLAYER_INFO_PATH = DIR / "decompiled_cs" / "_global" / "invite.InvitePlayerInfo.cs"

    _REQ_PING_BATTLE_ZONE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_PING_BATTLE_ZONE_RESPONSE_PATH)
    _BATTLE_ZONE_TAGS = _load_sproto_field_tags_from_cs(_CS_BATTLE_ZONE_PATH)
    _REQ_OPEN_MODE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_OPEN_MODE_REQUEST_PATH)
    _REQ_OPEN_MODE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_OPEN_MODE_RESPONSE_PATH)
    _RSP_OPEN_MODE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_OPEN_MODE_REQUEST_PATH)
    _RSP_CHOOSE_MAP_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHOOSE_MAP_REQUEST_PATH)
    _REQ_MODE_CHOOSE_MAP_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_MODE_CHOOSE_MAP_REQUEST_PATH)
    _REQ_CHOOSE_MAP_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CHOOSE_MAP_REQUEST_PATH)
    _REQ_MODE_CHOOSE_CAMP_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_MODE_CHOOSE_CAMP_REQUEST_PATH)
    _REQ_CREATE_ROOM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CREATE_ROOM_REQUEST_PATH)
    _REQ_CREATE_ROOM_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CREATE_ROOM_RESPONSE_PATH)
    _REQ_ROOM_START_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ROOM_START_REQUEST_PATH)
    _REQ_ROOM_START_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ROOM_START_RESPONSE_PATH)
    _RSP_ROOM_START_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_START_REQUEST_PATH)
    _REQ_EXCHANGE_POS_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_EXCHANGE_POS_REQUEST_PATH)
    _REQ_EXCHANGE_POS_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_EXCHANGE_POS_RESPONSE_PATH)
    _REQ_CHOOSE_CHARACTER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CHOOSE_CHARACTER_REQUEST_PATH)
    _RSP_CHOOSE_CHARACTER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHOOSE_CHARACTER_REQUEST_PATH)
    _REQ_CHOOSE_WEAPON_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CHOOSE_WEAPON_REQUEST_PATH)
    _RSP_CHOOSE_WEAPON_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHOOSE_WEAPON_REQUEST_PATH)
    _REQ_CHARACTER_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CHARACTER_INFO_REQUEST_PATH)
    _RSP_CHARACTER_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHARACTER_INFO_REQUEST_PATH)
    _CHARACTER_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_CHARACTER_INFO_PATH)
    _REQ_HALL_CHOOSE_WEAPON_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_HALL_CHOOSE_WEAPON_REQUEST_PATH)
    _RSP_HALL_CHOOSE_WEAPON_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_HALL_CHOOSE_WEAPON_REQUEST_PATH)
    _RSP_UNLOCK_CHARACTER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_UNLOCK_CHARACTER_REQUEST_PATH)
    _RSP_SYNC_CHANGED_TASK_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_SYNC_CHANGED_TASK_INFO_REQUEST_PATH)
    _RSP_SYNC_CHANGED_ACTIVITY_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_SYNC_CHANGED_ACTIVITY_INFO_REQUEST_PATH)
    _ACTIVITY_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_ACTIVITY_INFO_PATH)
    _ACTIVITY_TASK_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_ACTIVITY_TASK_INFO_PATH)
    _ACTIVITY_VALUE_TAGS = _load_sproto_field_tags_from_cs(_CS_ACTIVITY_VALUE_PATH)
    _RSP_ACTIVITY_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ACTIVITY_INFO_REQUEST_PATH)
    _REQ_GET_ACTIVITY_REWARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_GET_ACTIVITY_REWARD_REQUEST_PATH)
    _REQ_GET_ACTIVITY_REWARD_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_GET_ACTIVITY_REWARD_RESPONSE_PATH)
    _REQ_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ENTER_PRE_BATTLE_STAGE_REQUEST_PATH)
    _RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_PATH)
    _REQ_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_PATH)
    _RSP_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_PATH)
    _RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_CHOOSE_WEAPON_INFO_REQUEST_PATH)
    _WEAPON_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_WEAPON_INFO_PATH)
    _ATTACHMENT_TAGS = _load_sproto_field_tags_from_cs(_CS_ATTACHMENT_PATH)
    _RSP_PRE_BATTLE_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_PRE_BATTLE_INFO_REQUEST_PATH)
    _PRE_BATTLE_USER_DATA_TAGS = _load_sproto_field_tags_from_cs(_CS_PRE_BATTLE_USER_DATA_PATH)
    _CHOOSE_WEAPON_DATA_TAGS = _load_sproto_field_tags_from_cs(_CS_CHOOSE_WEAPON_DATA_PATH)
    _REQ_USER_GUIDE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_USER_GUIDE_REQUEST_PATH)
    _REQ_USER_GUIDE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_USER_GUIDE_RESPONSE_PATH)
    _RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_USER_GUIDE_ROUND_START_REQUEST_PATH)
    _RSP_BATTLE_INFO_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_BATTLE_INFO_REQUEST_PATH)
    _BATTLE_TEAM_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_BATTLE_TEAM_INFO_PATH)
    _CHARACTER_CHOOSE_PLAYER_TAGS = _load_sproto_field_tags_from_cs(_CS_CHARACTER_CHOOSE_PLAYER_PATH)
    _RSP_BATTLE_RESULT_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_BATTLE_RESULT_REQUEST_PATH)
    _RSP_PLAYERS_RESULT_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_PLAYERS_RESULT_REQUEST_PATH)
    _RSP_BATTLE_FINAL_RESULT_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_BATTLE_FINAL_RESULT_REQUEST_PATH)
    _BATTLE_PLAYER_RESULT_TAGS = _load_sproto_field_tags_from_cs(_CS_BATTLE_PLAYER_RESULT_PATH)
    _COMMON_BATTLE_RESULT_TAGS = _load_sproto_field_tags_from_cs(_CS_COMMON_BATTLE_RESULT_PATH)
    _RANK_PLAYER_RESULT_TAGS = _load_sproto_field_tags_from_cs(_CS_RANK_PLAYER_RESULT_PATH)
    _BOX_RESULT_TAGS = _load_sproto_field_tags_from_cs(_CS_BOX_RESULT_PATH)
    _REQ_JOIN_ROOM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_JOIN_ROOM_REQUEST_PATH)
    _REQ_ROOM_KICK_PLAYER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ROOM_KICK_PLAYER_REQUEST_PATH)
    _REQ_ROOM_KICK_PLAYER_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ROOM_KICK_PLAYER_RESPONSE_PATH)
    _REQ_ROOM_CHANGE_BATTLE_ZONE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_REQ_ROOM_CHANGE_BATTLE_ZONE_REQUEST_PATH)
    _RSP_JOIN_ROOM_STATE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_JOIN_ROOM_STATE_REQUEST_PATH)
    _RSP_ROOM_ENTERED_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_ENTERED_REQUEST_PATH)
    _RSP_ROOM_PLAYER_ENTERED_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_PLAYER_ENTERED_REQUEST_PATH)
    _RSP_ROOM_PLAYER_LEAVED_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_PLAYER_LEAVED_REQUEST_PATH)
    _RSP_ROOM_OWNER_CHANGED_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_OWNER_CHANGED_REQUEST_PATH)
    _RSP_ROOM_BATTLE_ZONE_CHANGED_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_ROOM_BATTLE_ZONE_CHANGED_REQUEST_PATH)
    _RSP_POS_CHANGE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_RSP_POS_CHANGE_NOTIFY_REQUEST_PATH)
    _GAME_PLAYER_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_PLAYER_INFO_PATH)
    _ROOM_POSITION_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_ROOM_POSITION_INFO_PATH)

    _CLIENT_QUERY_LEADERBOARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_LEADERBOARD_REQUEST_PATH)
    _CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_LEADERBOARD_RESPONSE_PATH)
    _CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_PATH)
    _CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_PATH)
    _CLIENT_QUERY_ROLE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_ROLE_REQUEST_PATH)
    _CLIENT_GM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GM_REQUEST_PATH)
    _CLIENT_GM_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GM_RESPONSE_PATH)
    _CLIENT_GOD_PLAYER_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GOD_PLAYER_REQ_REQUEST_PATH)
    _CLIENT_GOD_PLAYER_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GOD_PLAYER_REQ_RESPONSE_PATH)
    _CLIENT_LEADERBOARD_PLAYER_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_LEADERBOARD_PLAYER_PATH)
    _CLIENT_LEADERBOARD_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_LEADERBOARD_INFO_PATH)
    _CLIENT_QUERY_AD_INFO_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_AD_INFO_RESPONSE_PATH)
    _CLIENT_QUERY_RECRUIT_INFO_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_QUERY_RECRUIT_INFO_RESPONSE_PATH)
    _CLIENT_SUBMIT_RECRUIT_CODE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_SUBMIT_RECRUIT_CODE_REQUEST_PATH)
    _CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_PATH)
    _CLIENT_CHANGE_ICON_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_REQUEST_PATH)
    _CLIENT_CHANGE_ICON_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_RESPONSE_PATH)
    _CLIENT_CHANGE_ICON_URL_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_URL_REQUEST_PATH)
    _CLIENT_CHANGE_ICON_URL_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_URL_RESPONSE_PATH)
    _CLIENT_CHANGE_ICON_FRAME_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_FRAME_REQUEST_PATH)
    _CLIENT_CHANGE_ICON_FRAME_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_CHANGE_ICON_FRAME_RESPONSE_PATH)
    _CLIENT_GET_RANK_AWARD_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GET_RANK_AWARD_REQ_REQUEST_PATH)
    _CLIENT_GET_RANK_AWARD_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GET_RANK_AWARD_REQ_RESPONSE_PATH)
    _CLIENT_GET_JF_SWITCH_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GET_JF_SWITCH_REQ_REQUEST_PATH)
    _CLIENT_GET_JF_SWITCH_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GET_JF_SWITCH_REQ_RESPONSE_PATH)
    _CLIENT_SHARE_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_SHARE_REQ_REQUEST_PATH)
    _CLIENT_SHARE_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_SHARE_REQ_RESPONSE_PATH)
    _CLIENT_ACTIVATE_ROLE_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_ACTIVATE_ROLE_REQ_REQUEST_PATH)
    _CLIENT_ACTIVATE_ROLE_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_ACTIVATE_ROLE_REQ_RESPONSE_PATH)
    _CLIENT_ADD_SKIN_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_ADD_SKIN_REQUEST_PATH)
    _CLIENT_ADD_SKIN_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_ADD_SKIN_RESPONSE_PATH)
    _CLIENT_SKIN_UPDATE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_SKIN_UPDATE_NOTIFY_REQUEST_PATH)
    _CLIENT_GET_REWARD_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_GET_REWARD_NOTIFY_REQUEST_PATH)
    _CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQUEST_PATH)
    _CLIENT_COMMON_REWARD_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_COMMON_REWARD_PATH)
    _CLIENT_RECHARGE_ITEM_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_RECHARGE_ITEM_PATH)
    _GAME_REQ_AD_REWARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_REQ_AD_REWARD_REQUEST_PATH)
    _CLIENT_UPDATE_MONEY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_UPDATE_MONEY_REQUEST_PATH)
    _CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_PATH)
    _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_PATH)
    _CLIENT_NEW_GUY_RECRUITED_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_NEW_GUY_RECRUITED_NOTIFY_REQUEST_PATH)
    _CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_PATH)
    _CLIENT_ONLINE_STATUS_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_ONLINE_STATUS_REQUEST_PATH)
    _CLIENT_DISCOUNT_STORE_ITEM_TAGS = _load_sproto_field_tags_from_cs(_CS_CLIENT_DISCOUNT_STORE_ITEM_PATH)

    _MAIL_MAIL_LIST_RES_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_MAIL_LIST_RES_REQUEST_PATH)
    _MAIL_MAIL_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_MAIL_PATH)
    _MAIL_REWARD_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_REWARD_PATH)
    _MAIL_OPERATE_MAIL_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_OPERATE_MAIL_REQUEST_PATH)
    _MAIL_OPERATE_MAIL_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_OPERATE_MAIL_RESPONSE_PATH)
    _MAIL_OPERATE_RES_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_OPERATE_RES_PATH)
    _MAIL_DELETE_ALL_READ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_DELETE_ALL_READ_REQUEST_PATH)
    _MAIL_DELETE_ALL_READ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_DELETE_ALL_READ_RESPONSE_PATH)
    _MAIL_GET_ALL_REWARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_GET_ALL_REWARD_REQUEST_PATH)
    _MAIL_GET_ALL_REWARD_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_GET_ALL_REWARD_RESPONSE_PATH)
    _MAIL_NEW_MAIL_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_NEW_MAIL_NOTIFY_REQUEST_PATH)
    _MAIL_DELETE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_MAIL_DELETE_NOTIFY_REQUEST_PATH)

    _TEAM_CREATE_TEAM_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CREATE_TEAM_REQUEST_PATH)
    _TEAM_CREATE_TEAM_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CREATE_TEAM_RESPONSE_PATH)
    _TEAM_KICK_MEMBER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_KICK_MEMBER_REQUEST_PATH)
    _TEAM_KICK_MEMBER_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_KICK_MEMBER_RESPONSE_PATH)
    _TEAM_LEAVE_TEAM_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_LEAVE_TEAM_RESPONSE_PATH)
    _TEAM_OPERATE_READY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_OPERATE_READY_REQUEST_PATH)
    _TEAM_OPERATE_READY_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_OPERATE_READY_RESPONSE_PATH)
    _TEAM_CHAT_ENTER_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CHAT_ENTER_REQUEST_PATH)
    _TEAM_CHAT_ENTER_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CHAT_ENTER_RESPONSE_PATH)
    _TEAM_CHANGE_BATTLEZONE_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CHANGE_BATTLEZONE_REQUEST_PATH)
    _TEAM_CHANGE_BATTLEZONE_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_CHANGE_BATTLEZONE_RESPONSE_PATH)
    _TEAM_SYNC_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_SYNC_NOTIFY_REQUEST_PATH)
    _TEAM_MEMBER_SYNC_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_MEMBER_SYNC_NOTIFY_REQUEST_PATH)
    _TEAM_MEMBER_ENTER_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_MEMBER_ENTER_NOTIFY_REQUEST_PATH)
    _TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_PATH)
    _TEAM_DATA_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_DATA_PATH)
    _TEAM_MEMBER_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_MEMBER_PATH)
    _TEAM_PLAYER_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_PLAYER_INFO_PATH)
    _TEAM_RETURN_HALL_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_RETURN_HALL_RESPONSE_PATH)
    _TEAM_RETURN_TEAM_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_TEAM_RETURN_TEAM_RESPONSE_PATH)

    _GAME_ASK_ALL_TASK_INFO_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_ASK_ALL_TASK_INFO_RESPONSE_PATH)
    _GAME_REQ_GET_TASK_REWARD_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_REQ_GET_TASK_REWARD_REQUEST_PATH)
    _GAME_REQ_GET_TASK_REWARD_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_REQ_GET_TASK_REWARD_RESPONSE_PATH)
    _GAME_REQ_REFRESH_TASK_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_REQ_REFRESH_TASK_REQUEST_PATH)
    _GAME_REQ_REFRESH_TASK_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_REQ_REFRESH_TASK_RESPONSE_PATH)
    _GAME_TASK_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_GAME_TASK_INFO_PATH)

    _INVITE_REQ_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_REQ_REQUEST_PATH)
    _INVITE_REQ_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_REQ_RESPONSE_PATH)
    _INVITE_REPLY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_REPLY_REQUEST_PATH)
    _INVITE_REPLY_RESPONSE_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_REPLY_RESPONSE_PATH)
    _INVITE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_NOTIFY_REQUEST_PATH)
    _INVITE_REFUSE_NOTIFY_REQUEST_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_REFUSE_NOTIFY_REQUEST_PATH)
    _INVITE_PLAYER_INFO_TAGS = _load_sproto_field_tags_from_cs(_CS_INVITE_PLAYER_INFO_PATH)

    _TAG_REQ_PING_BATTLE_ZONE_RESP_ERRORCODE = _field_tag_or_default(_REQ_PING_BATTLE_ZONE_RESPONSE_TAGS, "errorcode", 0, "game.ReqPingBattleZoneList.response")
    _TAG_REQ_PING_BATTLE_ZONE_RESP_BATTLE_ZONES = _field_tag_or_default(_REQ_PING_BATTLE_ZONE_RESPONSE_TAGS, "battle_zones", 1, "game.ReqPingBattleZoneList.response")

    _TAG_BATTLE_ZONE_ID = _field_tag_or_default(_BATTLE_ZONE_TAGS, "battle_zone_id", 0, "game.BattleZone")
    _TAG_BATTLE_ZONE_ADDRESS = _field_tag_or_default(_BATTLE_ZONE_TAGS, "address", 1, "game.BattleZone")
    _TAG_BATTLE_ZONE_NAME_KEY = _field_tag_or_default(_BATTLE_ZONE_TAGS, "name_key", 2, "game.BattleZone")
    _TAG_BATTLE_ZONE_REGION_NAME = _field_tag_or_default(_BATTLE_ZONE_TAGS, "battle_region_name", 3, "game.BattleZone")

    _TAG_REQ_OPEN_MODE_MODE_ID = _field_tag_or_default(_REQ_OPEN_MODE_REQUEST_TAGS, "mode_id", 0, "game.ReqOpenMode.request")
    _TAG_REQ_MODE_CHOOSE_MAP_MAP_ID = _field_tag_or_default(_REQ_MODE_CHOOSE_MAP_REQUEST_TAGS, "map_id", 0, "game.ReqModeChooseMap.request")
    _TAG_REQ_CHOOSE_MAP_MAP_ID = _field_tag_or_default(_REQ_CHOOSE_MAP_REQUEST_TAGS, "map_id", 0, "game.ReqChooseMap.request")
    _TAG_REQ_CHOOSE_MAP_MODE_ID = _field_tag_or_default(_REQ_CHOOSE_MAP_REQUEST_TAGS, "mode_id", 1, "game.ReqChooseMap.request")
    _TAG_REQ_MODE_CHOOSE_CAMP_CAMP = _field_tag_or_default(_REQ_MODE_CHOOSE_CAMP_REQUEST_TAGS, "camp", 0, "game.ReqModeChooseCamp.request")
    _TAG_REQ_CREATE_ROOM_BATTLE_ZONE = _field_tag_or_default(_REQ_CREATE_ROOM_REQUEST_TAGS, "battle_zone", 0, "game.ReqCreateRoom.request")
    _TAG_REQ_ROOM_START_REGION_TYPE = _field_tag_or_default(_REQ_ROOM_START_REQUEST_TAGS, "region_type", 0, "game.ReqRoomStart.request")
    _TAG_REQ_CREATE_ROOM_RESP_ERRORCODE = _field_tag_or_default(_REQ_CREATE_ROOM_RESPONSE_TAGS, "errorcode", 0, "game.ReqCreateRoom.response")
    _TAG_REQ_ROOM_START_RESP_ERRORCODE = _field_tag_or_default(_REQ_ROOM_START_RESPONSE_TAGS, "errorcode", 0, "game.ReqRoomStart.response")
    _TAG_REQ_EXCHANGE_POS_CAMP = _field_tag_or_default(_REQ_EXCHANGE_POS_REQUEST_TAGS, "camp", 0, "game.ReqExchangePos.request")
    _TAG_REQ_EXCHANGE_POS_INDEX = _field_tag_or_default(_REQ_EXCHANGE_POS_REQUEST_TAGS, "index", 1, "game.ReqExchangePos.request")
    _TAG_REQ_EXCHANGE_POS_RESP_ERRORCODE = _field_tag_or_default(_REQ_EXCHANGE_POS_RESPONSE_TAGS, "errorcode", 0, "game.ReqExchangePos.response")
    _TAG_REQ_EXCHANGE_POS_RESP_IS_EMPTY = _field_tag_or_default(_REQ_EXCHANGE_POS_RESPONSE_TAGS, "is_empty", 1, "game.ReqExchangePos.response")
    _TAG_REQ_OPEN_MODE_RESP_ERRORCODE = _field_tag_or_default(_REQ_OPEN_MODE_RESPONSE_TAGS, "errorcode", 0, "game.ReqOpenMode.response")

    _TAG_RSP_OPEN_MODE_MODE_ID = _field_tag_or_default(_RSP_OPEN_MODE_REQUEST_TAGS, "mode_id", 0, "game.RspOpenMode.request")
    _TAG_RSP_OPEN_MODE_MAP_ID = _field_tag_or_default(_RSP_OPEN_MODE_REQUEST_TAGS, "map_id", 1, "game.RspOpenMode.request")
    _TAG_RSP_OPEN_MODE_CAMP = _field_tag_or_default(_RSP_OPEN_MODE_REQUEST_TAGS, "camp", 2, "game.RspOpenMode.request")
    _TAG_RSP_CHOOSE_MAP_MAP_ID = _field_tag_or_default(_RSP_CHOOSE_MAP_REQUEST_TAGS, "map_id", 0, "game.RspChooseMap.request")
    _TAG_RSP_CHOOSE_MAP_MODE_ID = _field_tag_or_default(_RSP_CHOOSE_MAP_REQUEST_TAGS, "mode_id", 1, "game.RspChooseMap.request")

    _TAG_RSP_ROOM_START_ROUND = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "round", 0, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_COMBAT_TYPE = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "combat_type", 1, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_MAP_ID = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "map_id", 2, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_MODE_ID = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "mode_id", 3, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_WAIT_TIME = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "wait_time", 4, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_MY_TEAM = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "my_team", 5, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_OTHER_TEAM = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "other_team", 6, "game.RspRoomStart.request")
    _TAG_RSP_ROOM_START_MY_CHARACTERS = _field_tag_or_default(_RSP_ROOM_START_REQUEST_TAGS, "my_characters", 7, "game.RspRoomStart.request")

    _TAG_REQ_CHOOSE_CHARACTER_CHARACTER_ID = _field_tag_or_default(_REQ_CHOOSE_CHARACTER_REQUEST_TAGS, "character_id", 0, "game.ReqChooseCharacter.request")
    _TAG_RSP_CHOOSE_CHARACTER_UID = _field_tag_or_default(_RSP_CHOOSE_CHARACTER_REQUEST_TAGS, "uid", 0, "game.RspChooseCharacter.request")
    _TAG_RSP_CHOOSE_CHARACTER_CHARACTER_ID = _field_tag_or_default(_RSP_CHOOSE_CHARACTER_REQUEST_TAGS, "character_id", 1, "game.RspChooseCharacter.request")
    _TAG_RSP_CHOOSE_CHARACTER_PRIMARY_WEAPON_ID = _field_tag_or_default(_RSP_CHOOSE_CHARACTER_REQUEST_TAGS, "primary_weapon_id", 2, "game.RspChooseCharacter.request")
    _TAG_RSP_CHOOSE_CHARACTER_SKIN = _field_tag_or_default(_RSP_CHOOSE_CHARACTER_REQUEST_TAGS, "skin", 3, "game.RspChooseCharacter.request")

    _TAG_REQ_CHOOSE_WEAPON_KIND = _field_tag_or_default(_REQ_CHOOSE_WEAPON_REQUEST_TAGS, "kind", 0, "game.ReqChooseWeapon.request")
    _TAG_REQ_CHOOSE_WEAPON_ID = _field_tag_or_default(_REQ_CHOOSE_WEAPON_REQUEST_TAGS, "id", 1, "game.ReqChooseWeapon.request")
    _TAG_REQ_CHOOSE_WEAPON_ATTACHMENTS = _field_tag_or_default(
        _REQ_CHOOSE_WEAPON_REQUEST_TAGS, "attachments", 2, "game.ReqChooseWeapon.request"
    )
    _TAG_RSP_CHOOSE_WEAPON_SUCCESS = _field_tag_or_default(_RSP_CHOOSE_WEAPON_REQUEST_TAGS, "success", 0, "game.RspChooseWeapon.request")
    _TAG_RSP_CHOOSE_WEAPON_KIND = _field_tag_or_default(_RSP_CHOOSE_WEAPON_REQUEST_TAGS, "kind", 1, "game.RspChooseWeapon.request")
    _TAG_RSP_CHOOSE_WEAPON_ID = _field_tag_or_default(_RSP_CHOOSE_WEAPON_REQUEST_TAGS, "id", 2, "game.RspChooseWeapon.request")
    _TAG_RSP_CHOOSE_WEAPON_ATTACHMENTS = _field_tag_or_default(
        _RSP_CHOOSE_WEAPON_REQUEST_TAGS, "attachments", 3, "game.RspChooseWeapon.request"
    )
    _TAG_RSP_CHARACTER_INFO_CHARACTERS = _field_tag_or_default(
        _RSP_CHARACTER_INFO_REQUEST_TAGS, "characters", 0, "game.RspCharacterInfo.request"
    )
    _TAG_CHARACTER_INFO_ID = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "id", 0, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_CUR_PRIMARY_WEAPON = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "cur_primary_weapon", 1, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_PRIMARY_WEAPONS = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "primary_weapons", 2, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_CUR_SECONDARY_WEAPON = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "cur_secondary_weapon", 3, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_SECONDARY_WEAPONS = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "secondary_weapons", 4, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_CUR_MAIN_SKILL = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "cur_main_skill", 5, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_MAIN_SKILLS = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "main_skills", 6, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_CUR_SUB_SKILL = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "cur_sub_skill", 7, "game.CharacterInfo"
    )
    _TAG_CHARACTER_INFO_SUB_SKILLS = _field_tag_or_default(
        _CHARACTER_INFO_TAGS, "sub_skills", 8, "game.CharacterInfo"
    )
    _TAG_REQ_HALL_CHOOSE_WEAPON_CHARACTER_ID = _field_tag_or_default(
        _REQ_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "character_id", 0, "game.ReqHallChooseWeapon.request"
    )
    _TAG_REQ_HALL_CHOOSE_WEAPON_KIND = _field_tag_or_default(
        _REQ_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "kind", 1, "game.ReqHallChooseWeapon.request"
    )
    _TAG_REQ_HALL_CHOOSE_WEAPON_ID = _field_tag_or_default(
        _REQ_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "id", 2, "game.ReqHallChooseWeapon.request"
    )
    _TAG_REQ_HALL_CHOOSE_WEAPON_ATTACHMENTS = _field_tag_or_default(
        _REQ_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "attachments", 3, "game.ReqHallChooseWeapon.request"
    )
    _TAG_RSP_HALL_CHOOSE_WEAPON_CHARACTER_ID = _field_tag_or_default(
        _RSP_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "character_id", 0, "game.RspHallChooseWeapon.request"
    )
    _TAG_RSP_HALL_CHOOSE_WEAPON_KIND = _field_tag_or_default(
        _RSP_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "kind", 1, "game.RspHallChooseWeapon.request"
    )
    _TAG_RSP_HALL_CHOOSE_WEAPON_ID = _field_tag_or_default(
        _RSP_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "id", 2, "game.RspHallChooseWeapon.request"
    )
    _TAG_RSP_HALL_CHOOSE_WEAPON_ATTACHMENTS = _field_tag_or_default(
        _RSP_HALL_CHOOSE_WEAPON_REQUEST_TAGS, "attachments", 3, "game.RspHallChooseWeapon.request"
    )
    _TAG_RSP_UNLOCK_CHARACTER_CHARACTER_ID = _field_tag_or_default(
        _RSP_UNLOCK_CHARACTER_REQUEST_TAGS, "character_id", 0, "game.RspUnlockCharacter.request"
    )
    _TAG_RSP_UNLOCK_CHARACTER_LIMIT_TIME = _field_tag_or_default(
        _RSP_UNLOCK_CHARACTER_REQUEST_TAGS, "limit_time", 1, "game.RspUnlockCharacter.request"
    )
    _TAG_REQ_ENTER_PRE_BATTLE_STAGE_STAGE = _field_tag_or_default(_REQ_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS, "stage", 0, "game.ReqEnterPreBattleStage.request")
    _TAG_RSP_ENTER_PRE_BATTLE_STAGE_UID = _field_tag_or_default(_RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS, "uid", 0, "game.RspEnterPreBattleStage.request")
    _TAG_RSP_ENTER_PRE_BATTLE_STAGE_SUCCESS = _field_tag_or_default(_RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS, "success", 1, "game.RspEnterPreBattleStage.request")
    _TAG_RSP_ENTER_PRE_BATTLE_STAGE_STAGE = _field_tag_or_default(_RSP_ENTER_PRE_BATTLE_STAGE_REQUEST_TAGS, "stage", 2, "game.RspEnterPreBattleStage.request")
    _TAG_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REGION_ID = _field_tag_or_default(_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_TAGS, "region_id", 0, "game.ReqChooseSpawnRegionConfirm.request")
    _TAG_RSP_CHOOSE_SPAWN_REGION_CONFIRM_UID = _field_tag_or_default(_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_TAGS, "uid", 0, "game.RspChooseSpawnRegionConfirm.request")
    _TAG_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REGION_ID = _field_tag_or_default(_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REQUEST_TAGS, "region_id", 1, "game.RspChooseSpawnRegionConfirm.request")

    _TAG_WEAPON_INFO_ID = _field_tag_or_default(_WEAPON_INFO_TAGS, "id", 0, "game.WeaponInfo")
    _TAG_WEAPON_INFO_ATTACHMENTS = _field_tag_or_default(
        _WEAPON_INFO_TAGS, "attachments", 1, "game.WeaponInfo"
    )
    _TAG_ATTACHMENT_ID = _field_tag_or_default(_ATTACHMENT_TAGS, "id", 0, "game.Attachment")
    _TAG_ATTACHMENT_KIND = _field_tag_or_default(_ATTACHMENT_TAGS, "kind", 1, "game.Attachment")

    _TAG_RSP_CHOOSE_WEAPON_INFO_CUR_PRIMARY = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "cur_primary_weapon", 0, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_PRIMARY_WEAPONS = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "primary_weapons", 1, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_CUR_SECONDARY = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "cur_secondary_weapon", 2, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_SECONDARY_WEAPONS = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "secondary_weapons", 3, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_CUR_MAIN_SKILL = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "cur_main_skill", 4, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_MAIN_SKILLS = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "main_skills", 5, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_CUR_SUB_SKILL = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "cur_sub_skill", 6, "game.RspChooseWeaponInfo.request")
    _TAG_RSP_CHOOSE_WEAPON_INFO_SUB_SKILLS = _field_tag_or_default(_RSP_CHOOSE_WEAPON_INFO_REQUEST_TAGS, "sub_skills", 7, "game.RspChooseWeaponInfo.request")

    _TAG_RSP_PRE_BATTLE_INFO_MY_TEAM = _field_tag_or_default(_RSP_PRE_BATTLE_INFO_REQUEST_TAGS, "my_team_user_data", 0, "game.RspPreBattleInfo.request")
    _TAG_RSP_PRE_BATTLE_INFO_CHOOSE_WEAPON = _field_tag_or_default(_RSP_PRE_BATTLE_INFO_REQUEST_TAGS, "choose_weapon_data", 1, "game.RspPreBattleInfo.request")

    _TAG_PRE_BATTLE_USER_UID = _field_tag_or_default(_PRE_BATTLE_USER_DATA_TAGS, "uid", 0, "game.PreBattleUserData")
    _TAG_PRE_BATTLE_USER_CHARACTER_ID = _field_tag_or_default(_PRE_BATTLE_USER_DATA_TAGS, "character_id", 1, "game.PreBattleUserData")
    _TAG_PRE_BATTLE_USER_STAGE = _field_tag_or_default(_PRE_BATTLE_USER_DATA_TAGS, "stage", 2, "game.PreBattleUserData")

    _TAG_CHOOSE_WEAPON_DATA_CUR_PRIMARY = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "cur_primary_weapon", 0, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_PRIMARY_WEAPONS = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "primary_weapons", 1, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_CUR_SECONDARY = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "cur_secondary_weapon", 2, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_SECONDARY_WEAPONS = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "secondary_weapons", 3, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_CUR_MAIN_SKILL = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "cur_main_skill", 4, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_MAIN_SKILLS = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "main_skills", 5, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_CUR_SUB_SKILL = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "cur_sub_skill", 6, "game.ChooseWeaponData")
    _TAG_CHOOSE_WEAPON_DATA_SUB_SKILLS = _field_tag_or_default(_CHOOSE_WEAPON_DATA_TAGS, "sub_skills", 7, "game.ChooseWeaponData")

    _TAG_REQ_USER_GUIDE_GUIDE_ID = _field_tag_or_default(_REQ_USER_GUIDE_REQUEST_TAGS, "guide_id", 0, "game.ReqUserGuide.request")
    _TAG_REQ_USER_GUIDE_BATTLE_ZONE = _field_tag_or_default(_REQ_USER_GUIDE_REQUEST_TAGS, "battle_zone", 1, "game.ReqUserGuide.request")
    _TAG_REQ_USER_GUIDE_RESP_ERRORCODE = _field_tag_or_default(_REQ_USER_GUIDE_RESPONSE_TAGS, "errorcode", 0, "game.ReqUserGuide.response")
    _TAG_RSP_USER_GUIDE_ROUND = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "round", 0, "game.RspUserGuideRoundStart.request")
    _TAG_RSP_USER_GUIDE_MAP_ID = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "map_id", 1, "game.RspUserGuideRoundStart.request")
    _TAG_RSP_USER_GUIDE_MODE_ID = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "mode_id", 2, "game.RspUserGuideRoundStart.request")
    _TAG_RSP_USER_GUIDE_WAIT_TIME = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "wait_time", 3, "game.RspUserGuideRoundStart.request")
    _TAG_RSP_USER_GUIDE_TEAM = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "team", 4, "game.RspUserGuideRoundStart.request")
    _TAG_RSP_USER_GUIDE_CAMP = _field_tag_or_default(_RSP_USER_GUIDE_ROUND_START_REQUEST_TAGS, "camp", 5, "game.RspUserGuideRoundStart.request")

    _TAG_RSP_BATTLE_INFO_MAP_ID = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "map_id", 0, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_MODE_ID = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "mode_id", 1, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_BATTLE_ID = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "battle_id", 2, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_IP_PORT = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "ip_port", 3, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_TOKEN = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "token", 4, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_GUIDE_ID = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "guide_id", 5, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_MY_TEAM = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "my_team", 6, "game.RspBattleInfo.request")
    _TAG_RSP_BATTLE_INFO_OTHER_TEAM = _field_tag_or_default(_RSP_BATTLE_INFO_REQUEST_TAGS, "other_team", 7, "game.RspBattleInfo.request")

    _TAG_BATTLE_TEAM_TEAM = _field_tag_or_default(_BATTLE_TEAM_INFO_TAGS, "team", 0, "game.BattleTeamInfo")
    _TAG_BATTLE_TEAM_CAMP = _field_tag_or_default(_BATTLE_TEAM_INFO_TAGS, "camp", 1, "game.BattleTeamInfo")
    _TAG_BATTLE_TEAM_WIN_TIMES = _field_tag_or_default(_BATTLE_TEAM_INFO_TAGS, "win_times", 2, "game.BattleTeamInfo")
    _TAG_BATTLE_TEAM_PLAYERS = _field_tag_or_default(_BATTLE_TEAM_INFO_TAGS, "players", 3, "game.BattleTeamInfo")

    _TAG_CHARACTER_CHOOSE_PLAYER_UID = _field_tag_or_default(_CHARACTER_CHOOSE_PLAYER_TAGS, "uid", 0, "game.CharacterChoosePlayer")
    _TAG_CHARACTER_CHOOSE_PLAYER_BID = _field_tag_or_default(_CHARACTER_CHOOSE_PLAYER_TAGS, "bid", 1, "game.CharacterChoosePlayer")
    _TAG_CHARACTER_CHOOSE_PLAYER_NAME = _field_tag_or_default(_CHARACTER_CHOOSE_PLAYER_TAGS, "name", 2, "game.CharacterChoosePlayer")
    _TAG_CHARACTER_CHOOSE_PLAYER_REGION_ID = _field_tag_or_default(_CHARACTER_CHOOSE_PLAYER_TAGS, "region_id", 3, "game.CharacterChoosePlayer")

    _TAG_RSP_BATTLE_RESULT_RANK_RESULT = _field_tag_or_default(_RSP_BATTLE_RESULT_REQUEST_TAGS, "rank_result", 0, "game.RspBattleResult.request")
    _TAG_RSP_BATTLE_RESULT_BOX_RESULT = _field_tag_or_default(_RSP_BATTLE_RESULT_REQUEST_TAGS, "box_result", 1, "game.RspBattleResult.request")
    _TAG_RSP_PLAYERS_RESULT_RESULTS = _field_tag_or_default(
        _RSP_PLAYERS_RESULT_REQUEST_TAGS,
        "results",
        0,
        "game.RspPlayersResult.request",
    )
    _TAG_RSP_BATTLE_FINAL_RESULT_COMMON_RESULT = _field_tag_or_default(
        _RSP_BATTLE_FINAL_RESULT_REQUEST_TAGS,
        "common_result",
        0,
        "game.RspBattleFinalResult.request",
    )
    _TAG_RSP_BATTLE_FINAL_RESULT_RANK_RESULT = _field_tag_or_default(
        _RSP_BATTLE_FINAL_RESULT_REQUEST_TAGS,
        "rank_result",
        1,
        "game.RspBattleFinalResult.request",
    )
    _TAG_RSP_BATTLE_FINAL_RESULT_BOX_RESULT = _field_tag_or_default(
        _RSP_BATTLE_FINAL_RESULT_REQUEST_TAGS,
        "box_result",
        2,
        "game.RspBattleFinalResult.request",
    )

    _TAG_BATTLE_PLAYER_RESULT_UID = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "uid",
        0,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_SCORE = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "score",
        1,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_KILL = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "kill",
        2,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_ASSIST = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "assist",
        3,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_DEAD = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "dead",
        4,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_IS_NO_HURT = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "is_no_hurt",
        5,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_TIME_STAMP = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "time_stamp",
        6,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_VOICESTATE = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "voicestate",
        7,
        "game.BattlePlayerResult",
    )
    _TAG_BATTLE_PLAYER_RESULT_RANK_SCORE = _field_tag_or_default(
        _BATTLE_PLAYER_RESULT_TAGS,
        "rank_score",
        8,
        "game.BattlePlayerResult",
    )

    _TAG_COMMON_BATTLE_RESULT_MY_WIN_TIMES = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "my_win_times",
        0,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_ENEMY_WIN_TIMES = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "enemy_win_times",
        1,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_WINNERS_RANK = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "winners_rank",
        2,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_PLAYERS_RESULT = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "players_result",
        3,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_COMBAT_TYPE = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "combat_type",
        5,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_GUIDE_ID = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "guide_id",
        6,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_ADD_EXP = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "add_exp",
        7,
        "game.CommonBattleResult",
    )
    _TAG_COMMON_BATTLE_RESULT_ADD_GOLD = _field_tag_or_default(
        _COMMON_BATTLE_RESULT_TAGS,
        "add_gold",
        8,
        "game.CommonBattleResult",
    )

    _TAG_RANK_RESULT_OLD_RANK_SCORE = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "old_rank_score", 0, "game.RankPlayerResult")
    _TAG_RANK_RESULT_NEW_RANK_SCORE = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "new_rank_score", 1, "game.RankPlayerResult")
    _TAG_RANK_RESULT_OLD_PROTECT_SCORE = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "old_protect_score", 2, "game.RankPlayerResult")
    _TAG_RANK_RESULT_NEW_PROTECT_SCORE = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "new_protect_score", 3, "game.RankPlayerResult")
    _TAG_RANK_RESULT_IS_PROTECT = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "is_protect", 4, "game.RankPlayerResult")
    _TAG_RANK_RESULT_IS_OFFLINE = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "is_offline", 5, "game.RankPlayerResult")
    _TAG_RANK_RESULT_IS_WIN = _field_tag_or_default(_RANK_PLAYER_RESULT_TAGS, "is_win", 6, "game.RankPlayerResult")

    _TAG_BOX_RESULT_BOX_ID = _field_tag_or_default(_BOX_RESULT_TAGS, "box_id", 0, "game.BoxResult")
    _TAG_BOX_RESULT_ADD_RATE = _field_tag_or_default(_BOX_RESULT_TAGS, "add_rate", 1, "game.BoxResult")
    _TAG_BOX_RESULT_CURRENT_RATE = _field_tag_or_default(_BOX_RESULT_TAGS, "current_rate", 2, "game.BoxResult")

    _TAG_REQ_JOIN_ROOM_ROOM_ID = _field_tag_or_default(_REQ_JOIN_ROOM_REQUEST_TAGS, "room_id", 0, "game.ReqJoinRoom.request")
    _TAG_REQ_JOIN_ROOM_BATTLE_ZONE = _field_tag_or_default(_REQ_JOIN_ROOM_REQUEST_TAGS, "battle_zone", 1, "game.ReqJoinRoom.request")
    _TAG_REQ_ROOM_KICK_UID = _field_tag_or_default(_REQ_ROOM_KICK_PLAYER_REQUEST_TAGS, "uid", 0, "game.ReqRoomKickPlayer.request")
    _TAG_REQ_ROOM_KICK_RESP_ERRORCODE = _field_tag_or_default(_REQ_ROOM_KICK_PLAYER_RESPONSE_TAGS, "errorcode", 0, "game.ReqRoomKickPlayer.response")
    _TAG_REQ_ROOM_CHANGE_BATTLE_ZONE = _field_tag_or_default(_REQ_ROOM_CHANGE_BATTLE_ZONE_REQUEST_TAGS, "battle_zone", 0, "game.ReqRoomChangeBattleZone.request")
    _TAG_RSP_JOIN_ROOM_STATE_STATE = _field_tag_or_default(_RSP_JOIN_ROOM_STATE_REQUEST_TAGS, "state", 0, "game.RspJoinRoomState.request")
    _TAG_RSP_ROOM_ENTERED_ROOM_ID = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "room_id", 0, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_ENTERED_OWNER_ID = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "owner_id", 1, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_ENTERED_PLAYERS = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "players", 2, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_ENTERED_BATTLE_ZONE = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "battle_zone", 3, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_ENTERED_MAP_ID = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "map_id", 4, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_ENTERED_MODE_ID = _field_tag_or_default(_RSP_ROOM_ENTERED_REQUEST_TAGS, "mode_id", 5, "game.RspRoomEntered.request")
    _TAG_RSP_ROOM_PLAYER_ENTERED_PLAYER = _field_tag_or_default(_RSP_ROOM_PLAYER_ENTERED_REQUEST_TAGS, "player", 0, "game.RspRoomPlayerEntered.request")
    _TAG_RSP_ROOM_PLAYER_LEAVED_UID = _field_tag_or_default(_RSP_ROOM_PLAYER_LEAVED_REQUEST_TAGS, "uid", 0, "game.RspRoomPlayerLeaved.request")
    _TAG_RSP_ROOM_PLAYER_LEAVED_LEAVE_TYPE = _field_tag_or_default(_RSP_ROOM_PLAYER_LEAVED_REQUEST_TAGS, "leave_type", 1, "game.RspRoomPlayerLeaved.request")
    _TAG_RSP_ROOM_OWNER_CHANGED_UID = _field_tag_or_default(_RSP_ROOM_OWNER_CHANGED_REQUEST_TAGS, "uid", 0, "game.RspRoomOwnerChanged.request")
    _TAG_RSP_ROOM_BATTLE_ZONE_CHANGED_BATTLE_ZONE = _field_tag_or_default(_RSP_ROOM_BATTLE_ZONE_CHANGED_REQUEST_TAGS, "battle_zone", 0, "game.RspRoomBattleZoneChanged.request")
    _TAG_RSP_POS_CHANGE_NOTIFY_PLAYER_POSITIONS = _field_tag_or_default(_RSP_POS_CHANGE_NOTIFY_REQUEST_TAGS, "player_positions", 0, "game.RspPosChangeNotify.request")

    _TAG_GAME_PLAYER_INFO_UID = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "uid", 0, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_NAME = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "name", 1, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_LEVEL = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "level", 2, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_ICON = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "icon", 3, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_CAMP = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "camp", 4, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_INDEX = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "index", 5, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_RANK_SCORE = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "rank_score", 6, "game.PlayerInfo")
    _TAG_GAME_PLAYER_INFO_ICON_URL = _field_tag_or_default(_GAME_PLAYER_INFO_TAGS, "icon_url", 7, "game.PlayerInfo")
    _TAG_ROOM_POSITION_INFO_UID = _field_tag_or_default(_ROOM_POSITION_INFO_TAGS, "uid", 0, "game.RoomPositionInfo")
    _TAG_ROOM_POSITION_INFO_INDEX = _field_tag_or_default(_ROOM_POSITION_INFO_TAGS, "index", 1, "game.RoomPositionInfo")
    _TAG_ROOM_POSITION_INFO_CAMP = _field_tag_or_default(_ROOM_POSITION_INFO_TAGS, "camp", 2, "game.RoomPositionInfo")

    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_TYPE = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_REQUEST_TAGS, "type", 0, "client.query_leaderboard.request")
    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_START_INDEX = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_REQUEST_TAGS, "start_index", 1, "client.query_leaderboard.request")
    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_END_INDEX = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_REQUEST_TAGS, "end_index", 2, "client.query_leaderboard.request")
    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_EXTRA_ARG = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_REQUEST_TAGS, "extra_arg", 3, "client.query_leaderboard.request")
    _TAG_CLIENT_QUERY_ROLE_REQ_UID = _field_tag_or_default(_CLIENT_QUERY_ROLE_REQUEST_TAGS, "uid", 0, "client.query_role.request")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_ERRORCODE = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "errorcode", 0, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_TYPE = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "type", 1, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_PLAYERS = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "players", 2, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_RANKS = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "ranks", 3, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_MYRANK = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "myrank", 4, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_MY_RANKINFO = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "my_rankinfo", 5, "client.query_leaderboard.response")
    _TAG_CLIENT_QUERY_LEADERBOARD_RESP_EXTRA_ARG = _field_tag_or_default(_CLIENT_QUERY_LEADERBOARD_RESPONSE_TAGS, "extra_arg", 6, "client.query_leaderboard.response")

    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_TYPE = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_TAGS, "type", 0, "client.query_friend_leaderboard.request")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_FRIEND_UID_LIST = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_TAGS, "friend_uid_list", 1, "client.query_friend_leaderboard.request")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_EXTRA_ARG = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_REQUEST_TAGS, "extra_arg", 2, "client.query_friend_leaderboard.request")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_ERRORCODE = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_TAGS, "errorcode", 0, "client.query_friend_leaderboard.response")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_TYPE = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_TAGS, "type", 1, "client.query_friend_leaderboard.response")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_PLAYERS = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_TAGS, "players", 2, "client.query_friend_leaderboard.response")
    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_EXTRA_ARG = _field_tag_or_default(_CLIENT_QUERY_FRIEND_LEADERBOARD_RESPONSE_TAGS, "extra_arg", 3, "client.query_friend_leaderboard.response")

    _TAG_CLIENT_LEADERBOARD_PLAYER_UID = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "uid", 0, "client.LeaderboardPlayer")
    _TAG_CLIENT_LEADERBOARD_PLAYER_INFO = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "info", 1, "client.LeaderboardPlayer")
    _TAG_CLIENT_LEADERBOARD_PLAYER_SCORE = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "score", 2, "client.LeaderboardPlayer")
    _TAG_CLIENT_LEADERBOARD_PLAYER_SCORE2 = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "score2", 3, "client.LeaderboardPlayer")
    _TAG_CLIENT_LEADERBOARD_PLAYER_SCORE3 = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "score3", 4, "client.LeaderboardPlayer")
    _TAG_CLIENT_LEADERBOARD_PLAYER_LIKES = _field_tag_or_default(_CLIENT_LEADERBOARD_PLAYER_TAGS, "likes", 5, "client.LeaderboardPlayer")

    _TAG_CLIENT_LEADERBOARD_INFO_NAME = _field_tag_or_default(_CLIENT_LEADERBOARD_INFO_TAGS, "name", 0, "client.LeaderboardInfo")
    _TAG_CLIENT_LEADERBOARD_INFO_LABEL1 = _field_tag_or_default(_CLIENT_LEADERBOARD_INFO_TAGS, "label1", 1, "client.LeaderboardInfo")
    _TAG_CLIENT_LEADERBOARD_INFO_LABEL2 = _field_tag_or_default(_CLIENT_LEADERBOARD_INFO_TAGS, "label2", 2, "client.LeaderboardInfo")
    _TAG_CLIENT_LEADERBOARD_INFO_LABEL3 = _field_tag_or_default(_CLIENT_LEADERBOARD_INFO_TAGS, "label3", 3, "client.LeaderboardInfo")

    _TAG_CLIENT_GM_REQ_CMD = _field_tag_or_default(
        _CLIENT_GM_REQUEST_TAGS, "cmd", 0, "client.gm.request"
    )
    _TAG_CLIENT_GM_RESP_SUCCEED = _field_tag_or_default(
        _CLIENT_GM_RESPONSE_TAGS, "succeed", 0, "client.gm.response"
    )
    _TAG_CLIENT_GM_RESP_INFO = _field_tag_or_default(
        _CLIENT_GM_RESPONSE_TAGS, "info", 1, "client.gm.response"
    )
    _TAG_CLIENT_GOD_PLAYER_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_GOD_PLAYER_REQ_RESPONSE_TAGS, "errorcode", 0, "client.god_player_req.response"
    )
    _TAG_CLIENT_GOD_PLAYER_RESP_RANK = _field_tag_or_default(
        _CLIENT_GOD_PLAYER_REQ_RESPONSE_TAGS, "rank", 1, "client.god_player_req.response"
    )

    _TAG_CLIENT_QUERY_AD_INFO_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_QUERY_AD_INFO_RESPONSE_TAGS, "errorcode", 0, "client.query_ad_info.response"
    )
    _TAG_CLIENT_QUERY_AD_INFO_RESP_AD_SWITCH = _field_tag_or_default(
        _CLIENT_QUERY_AD_INFO_RESPONSE_TAGS, "ad_switch", 1, "client.query_ad_info.response"
    )

    _TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUIT_CODE = _field_tag_or_default(
        _CLIENT_QUERY_RECRUIT_INFO_RESPONSE_TAGS, "recruit_code", 0, "client.query_recruit_info.response"
    )
    _TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUITER_UID = _field_tag_or_default(
        _CLIENT_QUERY_RECRUIT_INFO_RESPONSE_TAGS, "recruiter_uid", 1, "client.query_recruit_info.response"
    )
    _TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUITEE_COUNT = _field_tag_or_default(
        _CLIENT_QUERY_RECRUIT_INFO_RESPONSE_TAGS, "recruitee_count", 2, "client.query_recruit_info.response"
    )

    _TAG_CLIENT_CHANGE_ICON_REQ_ICON = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_REQUEST_TAGS, "icon", 0, "client.change_icon.request"
    )
    _TAG_CLIENT_CHANGE_ICON_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_RESPONSE_TAGS, "errorcode", 0, "client.change_icon.response"
    )
    _TAG_CLIENT_CHANGE_ICON_RESP_ICON = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_RESPONSE_TAGS, "icon", 1, "client.change_icon.response"
    )

    _TAG_CLIENT_CHANGE_ICON_URL_REQ_ICON_URL = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_URL_REQUEST_TAGS, "icon_url", 0, "client.change_icon_url.request"
    )
    _TAG_CLIENT_CHANGE_ICON_URL_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_URL_RESPONSE_TAGS, "errorcode", 0, "client.change_icon_url.response"
    )
    _TAG_CLIENT_CHANGE_ICON_URL_RESP_ICON_URL = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_URL_RESPONSE_TAGS, "icon_url", 1, "client.change_icon_url.response"
    )

    _TAG_CLIENT_CHANGE_ICON_FRAME_REQ_ICON_FRAME = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_FRAME_REQUEST_TAGS, "icon_frame", 0, "client.change_icon_frame.request"
    )
    _TAG_CLIENT_CHANGE_ICON_FRAME_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_FRAME_RESPONSE_TAGS, "errorcode", 0, "client.change_icon_frame.response"
    )
    _TAG_CLIENT_CHANGE_ICON_FRAME_RESP_ICON_FRAME = _field_tag_or_default(
        _CLIENT_CHANGE_ICON_FRAME_RESPONSE_TAGS, "icon_frame", 1, "client.change_icon_frame.response"
    )

    _TAG_CLIENT_GET_RANK_AWARD_REQ_RANK_ID = _field_tag_or_default(
        _CLIENT_GET_RANK_AWARD_REQ_REQUEST_TAGS, "rank_id", 0, "client.get_rank_award_req.request"
    )
    _TAG_CLIENT_GET_RANK_AWARD_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_GET_RANK_AWARD_REQ_RESPONSE_TAGS, "errorcode", 0, "client.get_rank_award_req.response"
    )
    _TAG_CLIENT_GET_RANK_AWARD_RESP_REWARD_ID = _field_tag_or_default(
        _CLIENT_GET_RANK_AWARD_REQ_RESPONSE_TAGS, "reward_id", 1, "client.get_rank_award_req.response"
    )
    _TAG_CLIENT_GET_RANK_AWARD_RESP_REWARD_NUM = _field_tag_or_default(
        _CLIENT_GET_RANK_AWARD_REQ_RESPONSE_TAGS, "reward_num", 2, "client.get_rank_award_req.response"
    )

    _TAG_CLIENT_GET_JF_SWITCH_RESP_JF_SWITCH = _field_tag_or_default(
        _CLIENT_GET_JF_SWITCH_REQ_RESPONSE_TAGS, "jf_switch", 0, "client.get_jf_switch_req.response"
    )

    _TAG_CLIENT_SHARE_REQ_SHARE_TYPE = _field_tag_or_default(
        _CLIENT_SHARE_REQ_REQUEST_TAGS, "share_type", 0, "client.share_req.request"
    )
    _TAG_CLIENT_SHARE_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_SHARE_REQ_RESPONSE_TAGS, "errorcode", 0, "client.share_req.response"
    )
    _TAG_CLIENT_SHARE_RESP_SHARE_TYPE = _field_tag_or_default(
        _CLIENT_SHARE_REQ_RESPONSE_TAGS, "share_type", 1, "client.share_req.response"
    )

    _TAG_CLIENT_ACTIVATE_ROLE_REQ_CODE = _field_tag_or_default(
        _CLIENT_ACTIVATE_ROLE_REQ_REQUEST_TAGS, "code", 0, "client.activate_role_req.request"
    )
    _TAG_CLIENT_ACTIVATE_ROLE_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_ACTIVATE_ROLE_REQ_RESPONSE_TAGS, "errorcode", 0, "client.activate_role_req.response"
    )

    _TAG_CLIENT_ADD_SKIN_REQ_SKIN_ID = _field_tag_or_default(
        _CLIENT_ADD_SKIN_REQUEST_TAGS, "skin_id", 0, "client.add_skin.request"
    )
    _TAG_CLIENT_ADD_SKIN_RESP_SKIN_ID = _field_tag_or_default(
        _CLIENT_ADD_SKIN_RESPONSE_TAGS, "skin_id", 0, "client.add_skin.response"
    )
    _TAG_CLIENT_ADD_SKIN_RESP_RESULT = _field_tag_or_default(
        _CLIENT_ADD_SKIN_RESPONSE_TAGS, "result", 1, "client.add_skin.response"
    )

    _TAG_CLIENT_SKIN_UPDATE_NOTIFY_REQ_SKIN = _field_tag_or_default(
        _CLIENT_SKIN_UPDATE_NOTIFY_REQUEST_TAGS, "skin", 0, "client.skin_update_notify.request"
    )
    _TAG_CLIENT_SKIN_UPDATE_NOTIFY_REQ_NUM = _field_tag_or_default(
        _CLIENT_SKIN_UPDATE_NOTIFY_REQUEST_TAGS, "num", 1, "client.skin_update_notify.request"
    )

    _TAG_CLIENT_GET_REWARD_NOTIFY_REQ_REWARDS = _field_tag_or_default(
        _CLIENT_GET_REWARD_NOTIFY_REQUEST_TAGS, "rewards", 0, "client.get_reward_notify.request"
    )
    _TAG_CLIENT_GET_REWARD_NOTIFY_REQ_REWARD_TYPE = _field_tag_or_default(
        _CLIENT_GET_REWARD_NOTIFY_REQUEST_TAGS, "reward_type", 1, "client.get_reward_notify.request"
    )
    _TAG_CLIENT_COMMON_REWARD_REWARD_ID = _field_tag_or_default(
        _CLIENT_COMMON_REWARD_TAGS, "reward_id", 0, "client.CommonReward"
    )
    _TAG_CLIENT_COMMON_REWARD_REWARD_NUM = _field_tag_or_default(
        _CLIENT_COMMON_REWARD_TAGS, "reward_num", 1, "client.CommonReward"
    )
    _TAG_CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQ_ITEMS = _field_tag_or_default(
        _CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQUEST_TAGS, "items", 0, "client.update_recharge_items_notify.request"
    )
    _TAG_CLIENT_RECHARGE_ITEM_PRODUCT_ID = _field_tag_or_default(
        _CLIENT_RECHARGE_ITEM_TAGS, "product_id", 0, "client.RechargeItem"
    )
    _TAG_CLIENT_RECHARGE_ITEM_BASE_CURRENCY = _field_tag_or_default(
        _CLIENT_RECHARGE_ITEM_TAGS, "base_currency", 1, "client.RechargeItem"
    )
    _TAG_CLIENT_RECHARGE_ITEM_BONUS_CURRENCY = _field_tag_or_default(
        _CLIENT_RECHARGE_ITEM_TAGS, "bonus_currency", 2, "client.RechargeItem"
    )
    _TAG_CLIENT_RECHARGE_ITEM_IS_DOUBLE = _field_tag_or_default(
        _CLIENT_RECHARGE_ITEM_TAGS, "is_double", 3, "client.RechargeItem"
    )

    _TAG_CLIENT_UPDATE_MONEY_REQ_TYPE = _field_tag_or_default(
        _CLIENT_UPDATE_MONEY_REQUEST_TAGS, "type", 0, "client.update_money.request"
    )
    _TAG_CLIENT_UPDATE_MONEY_REQ_VALUE = _field_tag_or_default(
        _CLIENT_UPDATE_MONEY_REQUEST_TAGS, "value", 1, "client.update_money.request"
    )

    _TAG_CLIENT_UPDATE_EVENT_STAT_REQ_EVENT_TYPE = _field_tag_or_default(
        _CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_TAGS, "event_type", 0, "client.update_event_stat_notify.request"
    )
    _TAG_CLIENT_UPDATE_EVENT_STAT_REQ_TYPE = _field_tag_or_default(
        _CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_TAGS, "type", 1, "client.update_event_stat_notify.request"
    )
    _TAG_CLIENT_UPDATE_EVENT_STAT_REQ_VALUE = _field_tag_or_default(
        _CLIENT_UPDATE_EVENT_STAT_NOTIFY_REQUEST_TAGS, "value", 2, "client.update_event_stat_notify.request"
    )

    _TAG_CLIENT_RECHARGE_SUCCESS_REQ_MONEY_TYPE = _field_tag_or_default(
        _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS, "money_type", 0, "client.recharge_success_notify.request"
    )
    _TAG_CLIENT_RECHARGE_SUCCESS_REQ_MONEY = _field_tag_or_default(
        _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS, "money", 1, "client.recharge_success_notify.request"
    )
    _TAG_CLIENT_RECHARGE_SUCCESS_REQ_PRUDUCT_ID = _field_tag_or_default(
        _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS, "pruduct_id", 2, "client.recharge_success_notify.request"
    )
    _TAG_CLIENT_RECHARGE_SUCCESS_REQ_AMOUNT = _field_tag_or_default(
        _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS, "amount", 3, "client.recharge_success_notify.request"
    )
    _TAG_CLIENT_RECHARGE_SUCCESS_REQ_ATTACH_PARAMS = _field_tag_or_default(
        _CLIENT_RECHARGE_SUCCESS_NOTIFY_REQUEST_TAGS, "attach_params", 4, "client.recharge_success_notify.request"
    )

    _TAG_CLIENT_NEW_GUY_RECRUITED_REQ_UID = _field_tag_or_default(
        _CLIENT_NEW_GUY_RECRUITED_NOTIFY_REQUEST_TAGS, "recruitee_uid", 0, "client.new_guy_recruited_notify.request"
    )
    _TAG_CLIENT_NEW_GUY_RECRUITED_REQ_NAME = _field_tag_or_default(
        _CLIENT_NEW_GUY_RECRUITED_NOTIFY_REQUEST_TAGS, "recruitee_name", 1, "client.new_guy_recruited_notify.request"
    )

    _TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_FIX_ITEM = _field_tag_or_default(
        _CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_TAGS, "fix_item", 0, "client.store_discount_info_notify.request"
    )
    _TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_RANDOM_ITEMS = _field_tag_or_default(
        _CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_TAGS, "random_items", 1, "client.store_discount_info_notify.request"
    )
    _TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_REFRESH_TIME = _field_tag_or_default(
        _CLIENT_STORE_DISCOUNT_INFO_NOTIFY_REQUEST_TAGS, "refresh_time", 2, "client.store_discount_info_notify.request"
    )

    _TAG_CLIENT_DISCOUNT_STORE_ITEM_ID = _field_tag_or_default(
        _CLIENT_DISCOUNT_STORE_ITEM_TAGS, "item_id", 0, "client.DiscountStoreItem"
    )
    _TAG_CLIENT_DISCOUNT_STORE_ITEM_ID_TYPE = _field_tag_or_default(
        _CLIENT_DISCOUNT_STORE_ITEM_TAGS, "item_id_type", 1, "client.DiscountStoreItem"
    )
    _TAG_CLIENT_DISCOUNT_STORE_ITEM_BOUGHT = _field_tag_or_default(
        _CLIENT_DISCOUNT_STORE_ITEM_TAGS, "bought", 2, "client.DiscountStoreItem"
    )
    _TAG_CLIENT_DISCOUNT_STORE_ITEM_DISCOUNT = _field_tag_or_default(
        _CLIENT_DISCOUNT_STORE_ITEM_TAGS, "discount", 3, "client.DiscountStoreItem"
    )

    _TAG_CLIENT_ONLINE_STATUS_REQ_UID = _field_tag_or_default(
        _CLIENT_ONLINE_STATUS_REQUEST_TAGS, "uid", 0, "client.online_status.request"
    )
    _TAG_CLIENT_ONLINE_STATUS_REQ_ONLINE = _field_tag_or_default(
        _CLIENT_ONLINE_STATUS_REQUEST_TAGS, "online", 1, "client.online_status.request"
    )

    _TAG_CLIENT_SUBMIT_RECRUIT_CODE_REQ_RECRUIT_CODE = _field_tag_or_default(
        _CLIENT_SUBMIT_RECRUIT_CODE_REQUEST_TAGS, "recruit_code", 0, "client.submit_recruit_code_req.request"
    )
    _TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_ERRORCODE = _field_tag_or_default(
        _CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_TAGS, "errorcode", 0, "client.submit_recruit_code_req.response"
    )
    _TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_RECRUITER_UID = _field_tag_or_default(
        _CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_TAGS, "recruiter_uid", 1, "client.submit_recruit_code_req.response"
    )
    _TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_RECRUITER_NAME = _field_tag_or_default(
        _CLIENT_SUBMIT_RECRUIT_CODE_RESPONSE_TAGS, "recruiter_name", 2, "client.submit_recruit_code_req.response"
    )

    _TAG_GAME_ASK_ALL_TASK_INFO_RESP_TASKS_INFO = _field_tag_or_default(
        _GAME_ASK_ALL_TASK_INFO_RESPONSE_TAGS, "tasks_info", 0, "game.AskAllTaskInfo.response"
    )
    _TAG_GAME_ASK_ALL_TASK_INFO_RESP_CUR_REFRESH_CNT = _field_tag_or_default(
        _GAME_ASK_ALL_TASK_INFO_RESPONSE_TAGS, "cur_refresh_cnt", 1, "game.AskAllTaskInfo.response"
    )
    _TAG_GAME_ASK_ALL_TASK_INFO_RESP_LAST_REFRESH_TIMEOUT = _field_tag_or_default(
        _GAME_ASK_ALL_TASK_INFO_RESPONSE_TAGS,
        "daily_task_last_refresh_timeout",
        2,
        "game.AskAllTaskInfo.response",
    )
    _TAG_RSP_SYNC_CHANGED_TASK_INFO_TASKS_INFO = _field_tag_or_default(
        _RSP_SYNC_CHANGED_TASK_INFO_REQUEST_TAGS, "tasks_info", 0, "game.RspSyncChangedTaskInfo.request"
    )
    _TAG_RSP_SYNC_CHANGED_TASK_INFO_CUR_REFRESH_CNT = _field_tag_or_default(
        _RSP_SYNC_CHANGED_TASK_INFO_REQUEST_TAGS, "cur_refresh_cnt", 1, "game.RspSyncChangedTaskInfo.request"
    )
    _TAG_RSP_SYNC_CHANGED_TASK_INFO_LAST_REFRESH_TIMEOUT = _field_tag_or_default(
        _RSP_SYNC_CHANGED_TASK_INFO_REQUEST_TAGS,
        "daily_task_last_refresh_timeout",
        2,
        "game.RspSyncChangedTaskInfo.request",
    )
    _TAG_RSP_SYNC_CHANGED_ACTIVITY_INFO_INFO = _field_tag_or_default(
        _RSP_SYNC_CHANGED_ACTIVITY_INFO_REQUEST_TAGS, "info", 0, "game.RspSyncChangedActivityInfo.request"
    )
    _TAG_RSP_ACTIVITY_INFO_INFOS = _field_tag_or_default(_RSP_ACTIVITY_INFO_REQUEST_TAGS, "infos", 0, "game.RspActivityInfo.request")
    _TAG_ACTIVITY_INFO_ID = _field_tag_or_default(
        _ACTIVITY_INFO_TAGS, "id", 0, "game.ActivityInfo"
    )
    _TAG_ACTIVITY_INFO_IS_IN_TIME = _field_tag_or_default(
        _ACTIVITY_INFO_TAGS, "is_in_time", 1, "game.ActivityInfo"
    )
    _TAG_ACTIVITY_INFO_TASKS = _field_tag_or_default(
        _ACTIVITY_INFO_TAGS, "tasks", 2, "game.ActivityInfo"
    )
    _TAG_ACTIVITY_INFO_VALUES = _field_tag_or_default(
        _ACTIVITY_INFO_TAGS, "values", 3, "game.ActivityInfo"
    )
    _TAG_ACTIVITY_TASK_INFO_ID = _field_tag_or_default(_ACTIVITY_TASK_INFO_TAGS, "id", 0, "game.ActivityTaskInfo")
    _TAG_ACTIVITY_TASK_INFO_STATE = _field_tag_or_default(_ACTIVITY_TASK_INFO_TAGS, "state", 1, "game.ActivityTaskInfo")
    _TAG_ACTIVITY_TASK_INFO_VALUE = _field_tag_or_default(_ACTIVITY_TASK_INFO_TAGS, "value", 2, "game.ActivityTaskInfo")
    _TAG_ACTIVITY_TASK_INFO_MAX_VALUE = _field_tag_or_default(_ACTIVITY_TASK_INFO_TAGS, "max_value", 3, "game.ActivityTaskInfo")

    _TAG_ACTIVITY_VALUE_KEY = _field_tag_or_default(_ACTIVITY_VALUE_TAGS, "key", 0, "game.ActivityValue")
    _TAG_ACTIVITY_VALUE_VALUE1 = _field_tag_or_default(_ACTIVITY_VALUE_TAGS, "value1", 1, "game.ActivityValue")

    _TAG_REQ_GET_ACTIVITY_REWARD_REQ_ACTIVITY_ID = _field_tag_or_default(_REQ_GET_ACTIVITY_REWARD_REQUEST_TAGS, "activity_id", 0, "game.ReqGetActivityReward.request")
    _TAG_REQ_GET_ACTIVITY_REWARD_REQ_TASK_ID = _field_tag_or_default(_REQ_GET_ACTIVITY_REWARD_REQUEST_TAGS, "task_id", 1, "game.ReqGetActivityReward.request")
    _TAG_REQ_GET_ACTIVITY_REWARD_RESP_ACTIVITY_ID = _field_tag_or_default(_REQ_GET_ACTIVITY_REWARD_RESPONSE_TAGS, "activity_id", 0, "game.ReqGetActivityReward.response")
    _TAG_REQ_GET_ACTIVITY_REWARD_RESP_TASK_ID = _field_tag_or_default(_REQ_GET_ACTIVITY_REWARD_RESPONSE_TAGS, "task_id", 1, "game.ReqGetActivityReward.response")
    _TAG_REQ_GET_ACTIVITY_REWARD_RESP_ERRORCODE = _field_tag_or_default(_REQ_GET_ACTIVITY_REWARD_RESPONSE_TAGS, "errorcode", 2, "game.ReqGetActivityReward.response")
    _TAG_GAME_REQ_GET_TASK_REWARD_REQ_ID = _field_tag_or_default(
        _GAME_REQ_GET_TASK_REWARD_REQUEST_TAGS, "id", 0, "game.ReqGetTaskReward.request"
    )
    _TAG_GAME_REQ_GET_TASK_REWARD_RESP_ERRORCODE = _field_tag_or_default(
        _GAME_REQ_GET_TASK_REWARD_RESPONSE_TAGS, "errorcode", 0, "game.ReqGetTaskReward.response"
    )
    _TAG_GAME_REQ_GET_TASK_REWARD_RESP_ID = _field_tag_or_default(
        _GAME_REQ_GET_TASK_REWARD_RESPONSE_TAGS, "id", 1, "game.ReqGetTaskReward.response"
    )
    _TAG_GAME_REQ_REFRESH_TASK_REQ_SLOT = _field_tag_or_default(
        _GAME_REQ_REFRESH_TASK_REQUEST_TAGS, "slot", 0, "game.ReqRefreshTask.request"
    )
    _TAG_GAME_REQ_REFRESH_TASK_REQ_LAST_REFRESH_TIMEOUT = _field_tag_or_default(
        _GAME_REQ_REFRESH_TASK_REQUEST_TAGS,
        "daily_task_last_refresh_timeout",
        1,
        "game.ReqRefreshTask.request",
    )
    _TAG_GAME_REQ_REFRESH_TASK_RESP_ERRORCODE = _field_tag_or_default(
        _GAME_REQ_REFRESH_TASK_RESPONSE_TAGS, "errorcode", 0, "game.ReqRefreshTask.response"
    )
    _TAG_GAME_REQ_REFRESH_TASK_RESP_CUR_REFRESH_CNT = _field_tag_or_default(
        _GAME_REQ_REFRESH_TASK_RESPONSE_TAGS, "cur_refresh_cnt", 1, "game.ReqRefreshTask.response"
    )
    _TAG_GAME_REQ_REFRESH_TASK_RESP_LAST_REFRESH_TIMEOUT = _field_tag_or_default(
        _GAME_REQ_REFRESH_TASK_RESPONSE_TAGS,
        "daily_task_last_refresh_timeout",
        2,
        "game.ReqRefreshTask.response",
    )
    _TAG_GAME_TASK_INFO_ID = _field_tag_or_default(_GAME_TASK_INFO_TAGS, "id", 0, "game.TaskInfo")
    _TAG_GAME_TASK_INFO_COMPLETE_CNT = _field_tag_or_default(
        _GAME_TASK_INFO_TAGS, "compelet_cnt", 1, "game.TaskInfo"
    )
    _TAG_GAME_TASK_INFO_CUR_SLOT_IDX = _field_tag_or_default(
        _GAME_TASK_INFO_TAGS, "cur_slot_idx", 2, "game.TaskInfo"
    )
    _TAG_GAME_TASK_INFO_STATUS = _field_tag_or_default(
        _GAME_TASK_INFO_TAGS, "status", 3, "game.TaskInfo"
    )

    _TAG_MAIL_LIST_RES_MAIL_LIST = _field_tag_or_default(_MAIL_MAIL_LIST_RES_REQUEST_TAGS, "mail_list", 0, "mail.mail_list_res.request")
    _TAG_MAIL_LIST_RES_END_FLAG = _field_tag_or_default(_MAIL_MAIL_LIST_RES_REQUEST_TAGS, "end_flag", 1, "mail.mail_list_res.request")

    _TAG_MAIL_ID = _field_tag_or_default(_MAIL_MAIL_TAGS, "id", 0, "mail.Mail")
    _TAG_MAIL_TITLE = _field_tag_or_default(_MAIL_MAIL_TAGS, "title", 1, "mail.Mail")
    _TAG_MAIL_CONTENT = _field_tag_or_default(_MAIL_MAIL_TAGS, "content", 2, "mail.Mail")
    _TAG_MAIL_TYPE = _field_tag_or_default(_MAIL_MAIL_TAGS, "mail_type", 3, "mail.Mail")
    _TAG_MAIL_IS_CUSTOM = _field_tag_or_default(_MAIL_MAIL_TAGS, "is_custom", 4, "mail.Mail")
    _TAG_MAIL_EXPIRE_TS = _field_tag_or_default(_MAIL_MAIL_TAGS, "expire_ts", 5, "mail.Mail")
    _TAG_MAIL_STATUS = _field_tag_or_default(_MAIL_MAIL_TAGS, "status", 6, "mail.Mail")
    _TAG_MAIL_REWARDS = _field_tag_or_default(_MAIL_MAIL_TAGS, "rewards", 7, "mail.Mail")
    _TAG_MAIL_CREATE_TS = _field_tag_or_default(_MAIL_MAIL_TAGS, "create_ts", 8, "mail.Mail")
    _TAG_MAIL_CONTENT_PARAM = _field_tag_or_default(_MAIL_MAIL_TAGS, "content_param", 9, "mail.Mail")
    _TAG_MAIL_TEMPLATE_TYPE = _field_tag_or_default(_MAIL_MAIL_TAGS, "template_type", 10, "mail.Mail")

    _TAG_MAIL_REWARD_ID = _field_tag_or_default(_MAIL_REWARD_TAGS, "id", 0, "mail.MailReward")
    _TAG_MAIL_REWARD_NUM = _field_tag_or_default(_MAIL_REWARD_TAGS, "num", 1, "mail.MailReward")

    _TAG_MAIL_OPERATE_REQ_TYPE = _field_tag_or_default(_MAIL_OPERATE_MAIL_REQUEST_TAGS, "operate_type", 0, "mail.operate_mail.request")
    _TAG_MAIL_OPERATE_REQ_MAIL_ID = _field_tag_or_default(_MAIL_OPERATE_MAIL_REQUEST_TAGS, "mail_id", 1, "mail.operate_mail.request")
    _TAG_MAIL_OPERATE_RESP_TYPE = _field_tag_or_default(_MAIL_OPERATE_MAIL_RESPONSE_TAGS, "operate_type", 0, "mail.operate_mail.response")
    _TAG_MAIL_OPERATE_RESP_RESULT = _field_tag_or_default(_MAIL_OPERATE_MAIL_RESPONSE_TAGS, "operate_result", 1, "mail.operate_mail.response")

    _TAG_MAIL_OPERATE_RES_ID = _field_tag_or_default(_MAIL_OPERATE_RES_TAGS, "id", 0, "mail.MailOperateRes")
    _TAG_MAIL_OPERATE_RES_ERRORCODE = _field_tag_or_default(_MAIL_OPERATE_RES_TAGS, "errorcode", 1, "mail.MailOperateRes")

    _TAG_MAIL_DELETE_ALL_REQ_TYPE = _field_tag_or_default(_MAIL_DELETE_ALL_READ_REQUEST_TAGS, "mail_type", 0, "mail.delete_all_read_mail.request")
    _TAG_MAIL_DELETE_ALL_RESP_OPERATE_TYPE = _field_tag_or_default(_MAIL_DELETE_ALL_READ_RESPONSE_TAGS, "operate_type", 0, "mail.delete_all_read_mail.response")
    _TAG_MAIL_DELETE_ALL_RESP_MAIL_IDS = _field_tag_or_default(_MAIL_DELETE_ALL_READ_RESPONSE_TAGS, "mail_ids", 1, "mail.delete_all_read_mail.response")

    _TAG_MAIL_GET_ALL_REQ_TYPE = _field_tag_or_default(_MAIL_GET_ALL_REWARD_REQUEST_TAGS, "mail_type", 0, "mail.get_all_reward.request")
    _TAG_MAIL_GET_ALL_RESP_RESULTS = _field_tag_or_default(_MAIL_GET_ALL_REWARD_RESPONSE_TAGS, "operate_results", 0, "mail.get_all_reward.response")

    _TAG_MAIL_NEW_MAIL_NOTIFY_MAIL = _field_tag_or_default(_MAIL_NEW_MAIL_NOTIFY_REQUEST_TAGS, "mail", 0, "mail.new_mail_notify.request")
    _TAG_MAIL_DELETE_NOTIFY_MAIL_ID = _field_tag_or_default(_MAIL_DELETE_NOTIFY_REQUEST_TAGS, "mail_id", 0, "mail.mail_delete_notify.request")

    _TAG_TEAM_CREATE_REQ_BATTLE_ZONE = _field_tag_or_default(_TEAM_CREATE_TEAM_REQUEST_TAGS, "battle_zone", 0, "team.create_team_req.request")
    _TAG_TEAM_CREATE_REQ_COMBAT_TYPE = _field_tag_or_default(_TEAM_CREATE_TEAM_REQUEST_TAGS, "combat_type", 1, "team.create_team_req.request")
    _TAG_TEAM_CREATE_RESP_ERRORCODE = _field_tag_or_default(_TEAM_CREATE_TEAM_RESPONSE_TAGS, "errorcode", 0, "team.create_team_req.response")
    _TAG_TEAM_KICK_REQ_POS = _field_tag_or_default(_TEAM_KICK_MEMBER_REQUEST_TAGS, "kick_pos", 0, "team.kick_member_req.request")
    _TAG_TEAM_KICK_REQ_UID = _field_tag_or_default(_TEAM_KICK_MEMBER_REQUEST_TAGS, "kick_uid", 1, "team.kick_member_req.request")
    _TAG_TEAM_KICK_RESP_ERRORCODE = _field_tag_or_default(_TEAM_KICK_MEMBER_RESPONSE_TAGS, "errorcode", 0, "team.kick_member_req.response")
    _TAG_TEAM_KICK_RESP_POS = _field_tag_or_default(_TEAM_KICK_MEMBER_RESPONSE_TAGS, "kick_pos", 1, "team.kick_member_req.response")
    _TAG_TEAM_KICK_RESP_UID = _field_tag_or_default(_TEAM_KICK_MEMBER_RESPONSE_TAGS, "kick_uid", 2, "team.kick_member_req.response")
    _TAG_TEAM_LEAVE_RESP_ERRORCODE = _field_tag_or_default(_TEAM_LEAVE_TEAM_RESPONSE_TAGS, "errorcode", 0, "team.leave_team_req.response")
    _TAG_TEAM_READY_REQ_STATUS = _field_tag_or_default(_TEAM_OPERATE_READY_REQUEST_TAGS, "ready_status", 0, "team.operate_ready_req.request")
    _TAG_TEAM_READY_RESP_ERRORCODE = _field_tag_or_default(_TEAM_OPERATE_READY_RESPONSE_TAGS, "errorcode", 0, "team.operate_ready_req.response")
    _TAG_TEAM_READY_RESP_STATUS = _field_tag_or_default(_TEAM_OPERATE_READY_RESPONSE_TAGS, "ready_status", 1, "team.operate_ready_req.response")
    _TAG_TEAM_CHAT_ENTER_REQ_TEAM_ID = _field_tag_or_default(_TEAM_CHAT_ENTER_REQUEST_TAGS, "team_id", 0, "team.chat_enter_team_req.request")
    _TAG_TEAM_CHAT_ENTER_RESP_ERRORCODE = _field_tag_or_default(_TEAM_CHAT_ENTER_RESPONSE_TAGS, "errorcode", 0, "team.chat_enter_team_req.response")
    _TAG_TEAM_CHANGE_BATTLEZONE_REQ = _field_tag_or_default(_TEAM_CHANGE_BATTLEZONE_REQUEST_TAGS, "battle_zone", 0, "team.change_battlezone_team_req.request")
    _TAG_TEAM_CHANGE_BATTLEZONE_RESP_ERRORCODE = _field_tag_or_default(_TEAM_CHANGE_BATTLEZONE_RESPONSE_TAGS, "errorcode", 0, "team.change_battlezone_team_req.response")
    _TAG_TEAM_SYNC_NOTIFY_TEAM_DATA = _field_tag_or_default(_TEAM_SYNC_NOTIFY_REQUEST_TAGS, "team_data", 0, "team.team_sync_notify.request")
    _TAG_TEAM_MEMBER_SYNC_NOTIFY_MEMBER = _field_tag_or_default(_TEAM_MEMBER_SYNC_NOTIFY_REQUEST_TAGS, "member", 0, "team.member_sync_notify.request")
    _TAG_TEAM_MEMBER_ENTER_NOTIFY_NEW_MEMBER = _field_tag_or_default(_TEAM_MEMBER_ENTER_NOTIFY_REQUEST_TAGS, "new_member", 0, "team.team_member_enter_notify.request")
    _TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_TYPE = _field_tag_or_default(_TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_TAGS, "leave_type", 0, "team.team_member_leave_notify.request")
    _TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_POS = _field_tag_or_default(_TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_TAGS, "leave_pos", 1, "team.team_member_leave_notify.request")
    _TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_UID = _field_tag_or_default(_TEAM_MEMBER_LEAVE_NOTIFY_REQUEST_TAGS, "leave_uid", 2, "team.team_member_leave_notify.request")
    _TAG_TEAM_RETURN_HALL_RESP_ERRORCODE = _field_tag_or_default(
        _TEAM_RETURN_HALL_RESPONSE_TAGS, "errorcode", 0, "team.return_hall_req.response"
    )
    _TAG_TEAM_RETURN_TEAM_RESP_ERRORCODE = _field_tag_or_default(
        _TEAM_RETURN_TEAM_RESPONSE_TAGS, "errorcode", 0, "team.return_team_req.response"
    )

    _TAG_TEAM_DATA_TEAM_ID = _field_tag_or_default(_TEAM_DATA_TAGS, "team_id", 0, "team.TeamData")
    _TAG_TEAM_DATA_MEMBERS = _field_tag_or_default(_TEAM_DATA_TAGS, "members", 1, "team.TeamData")
    _TAG_TEAM_DATA_CAPTAIN_INDEX = _field_tag_or_default(_TEAM_DATA_TAGS, "captain_index", 2, "team.TeamData")
    _TAG_TEAM_DATA_CAPACITY = _field_tag_or_default(_TEAM_DATA_TAGS, "capacity", 3, "team.TeamData")
    _TAG_TEAM_DATA_BATTLE_ZONE = _field_tag_or_default(_TEAM_DATA_TAGS, "battle_zone", 4, "team.TeamData")
    _TAG_TEAM_DATA_COMBAT_TYPE = _field_tag_or_default(_TEAM_DATA_TAGS, "combat_type", 5, "team.TeamData")
    _TAG_TEAM_DATA_MIN_RANK = _field_tag_or_default(_TEAM_DATA_TAGS, "min_rank_limit", 6, "team.TeamData")
    _TAG_TEAM_DATA_MAX_RANK = _field_tag_or_default(_TEAM_DATA_TAGS, "max_rank_limit", 7, "team.TeamData")

    _TAG_TEAM_MEMBER_POS = _field_tag_or_default(_TEAM_MEMBER_TAGS, "pos", 0, "team.TeamMember")
    _TAG_TEAM_MEMBER_INFO = _field_tag_or_default(_TEAM_MEMBER_TAGS, "info", 1, "team.TeamMember")
    _TAG_TEAM_MEMBER_READY = _field_tag_or_default(_TEAM_MEMBER_TAGS, "is_ready", 2, "team.TeamMember")

    _TAG_TEAM_PLAYER_UID = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "uid", 0, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_NAME = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "name", 1, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_ICON = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "icon", 2, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_LEVEL = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "level", 3, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_MMR = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "mmr", 4, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_ICON_URL = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "icon_url", 5, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_RANK_SCORE = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "rank_score", 6, "team.TeamPlayerInfo")
    _TAG_TEAM_PLAYER_SHOW_CHARACTER = _field_tag_or_default(_TEAM_PLAYER_INFO_TAGS, "show_character", 7, "team.TeamPlayerInfo")

    # Hard-fix critical player-info tags to decompiled ground truth.
    # Prevents malformed room/team cards (e.g. NAMENAMENAMENAME / lvl 0)
    # when contract-tag autoload drifts on noisy decompilation artifacts.
    _TAG_GAME_PLAYER_INFO_UID = 0
    _TAG_GAME_PLAYER_INFO_NAME = 1
    _TAG_GAME_PLAYER_INFO_LEVEL = 2
    _TAG_GAME_PLAYER_INFO_ICON = 3
    _TAG_GAME_PLAYER_INFO_CAMP = 4
    _TAG_GAME_PLAYER_INFO_INDEX = 5
    _TAG_GAME_PLAYER_INFO_RANK_SCORE = 6
    _TAG_GAME_PLAYER_INFO_ICON_URL = 7

    _TAG_TEAM_PLAYER_UID = 0
    _TAG_TEAM_PLAYER_NAME = 1
    _TAG_TEAM_PLAYER_ICON = 2
    _TAG_TEAM_PLAYER_LEVEL = 3
    _TAG_TEAM_PLAYER_MMR = 4
    _TAG_TEAM_PLAYER_ICON_URL = 5
    _TAG_TEAM_PLAYER_RANK_SCORE = 6
    _TAG_TEAM_PLAYER_SHOW_CHARACTER = 7
    _TAG_TEAM_SYNC_NOTIFY_TEAM_DATA = 0
    _TAG_TEAM_MEMBER_SYNC_NOTIFY_MEMBER = 0
    _TAG_TEAM_MEMBER_ENTER_NOTIFY_NEW_MEMBER = 0
    _TAG_TEAM_DATA_TEAM_ID = 0
    _TAG_TEAM_DATA_MEMBERS = 1
    _TAG_TEAM_DATA_CAPTAIN_INDEX = 2
    _TAG_TEAM_DATA_CAPACITY = 3
    _TAG_TEAM_DATA_BATTLE_ZONE = 4
    _TAG_TEAM_DATA_COMBAT_TYPE = 5
    _TAG_TEAM_DATA_MIN_RANK = 6
    _TAG_TEAM_DATA_MAX_RANK = 7
    _TAG_TEAM_MEMBER_POS = 0
    _TAG_TEAM_MEMBER_INFO = 1
    # Decompiled TeamMember.decode handles `is_ready` on tag 3.
    # Using tag 2 silently drops readiness state on client side.
    _TAG_TEAM_MEMBER_READY = 3
    _TAG_RSP_JOIN_ROOM_STATE_STATE = 0
    _TAG_RSP_ROOM_ENTERED_ROOM_ID = 0
    _TAG_RSP_ROOM_ENTERED_OWNER_ID = 1
    _TAG_RSP_ROOM_ENTERED_PLAYERS = 2
    _TAG_RSP_ROOM_ENTERED_BATTLE_ZONE = 3
    _TAG_RSP_ROOM_ENTERED_MAP_ID = 4
    _TAG_RSP_ROOM_ENTERED_MODE_ID = 5
    _TAG_RSP_ROOM_PLAYER_ENTERED_PLAYER = 0

    _TAG_INVITE_REQ_UID = _field_tag_or_default(_INVITE_REQ_REQUEST_TAGS, "invite_uid", 0, "invite.invite_req.request")
    _TAG_INVITE_REQ_TYPE = _field_tag_or_default(_INVITE_REQ_REQUEST_TAGS, "invite_type", 1, "invite.invite_req.request")
    _TAG_INVITE_REQ_EXTRA_ARG = _field_tag_or_default(_INVITE_REQ_REQUEST_TAGS, "extra_arg", 2, "invite.invite_req.request")
    _TAG_INVITE_REQ_COMBAT_TYPE = _field_tag_or_default(_INVITE_REQ_REQUEST_TAGS, "combat_type", 3, "invite.invite_req.request")
    _TAG_INVITE_REQ_RESP_ERRORCODE = _field_tag_or_default(_INVITE_REQ_RESPONSE_TAGS, "errorcode", 0, "invite.invite_req.response")

    _TAG_INVITE_REPLY_REQ_INVITER_UID = _field_tag_or_default(_INVITE_REPLY_REQUEST_TAGS, "inviter_uid", 0, "invite.invite_reply_req.request")
    _TAG_INVITE_REPLY_REQ_AGREE = _field_tag_or_default(_INVITE_REPLY_REQUEST_TAGS, "agree", 1, "invite.invite_reply_req.request")
    _TAG_INVITE_REPLY_RESP_ERRORCODE = _field_tag_or_default(_INVITE_REPLY_RESPONSE_TAGS, "errorcode", 0, "invite.invite_reply_req.response")

    _TAG_INVITE_NOTIFY_PLAYER = _field_tag_or_default(_INVITE_NOTIFY_REQUEST_TAGS, "invite_player", 0, "invite.invite_notify.request")
    _TAG_INVITE_NOTIFY_TYPE = _field_tag_or_default(_INVITE_NOTIFY_REQUEST_TAGS, "invite_type", 1, "invite.invite_notify.request")
    _TAG_INVITE_NOTIFY_IDENTIFY_ID = _field_tag_or_default(_INVITE_NOTIFY_REQUEST_TAGS, "identify_id", 2, "invite.invite_notify.request")
    _TAG_INVITE_NOTIFY_COMBAT_TYPE = _field_tag_or_default(_INVITE_NOTIFY_REQUEST_TAGS, "combat_type", 3, "invite.invite_notify.request")

    _TAG_INVITE_REFUSE_UID = _field_tag_or_default(_INVITE_REFUSE_NOTIFY_REQUEST_TAGS, "uid", 0, "invite.invite_refuse_notify.request")
    _TAG_INVITE_REFUSE_TYPE = _field_tag_or_default(_INVITE_REFUSE_NOTIFY_REQUEST_TAGS, "type", 1, "invite.invite_refuse_notify.request")

    _TAG_INVITE_PLAYER_UID = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "uid", 0, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_NAME = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "name", 1, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_ICON = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "icon", 2, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_LEVEL = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "level", 3, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_ICON_URL = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "icon_url", 4, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_EXTRA_ARG = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "extra_arg", 5, "invite.InvitePlayerInfo")
    _TAG_INVITE_PLAYER_RANK_SCORE = _field_tag_or_default(_INVITE_PLAYER_INFO_TAGS, "rank_score", 6, "invite.InvitePlayerInfo")

    def _encode_select_character_info(character_id: int, unlock_time: int = 0, limit_time: int = 0) -> bytes:
        return _sproto_encode_fields([
            (_TAG_SELECT_CHARACTER_ID, character_id),
            (_TAG_SELECT_CHARACTER_UNLOCK_TIME, unlock_time),
            (_TAG_SELECT_CHARACTER_LIMIT_TIME, limit_time),
        ])

    def _encode_client_character(character_id: int, unlock_time: int = 0, limit_time: int = 0) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CLIENT_CHARACTER_ID, character_id),
            (_TAG_CLIENT_CHARACTER_UNLOCK_TIME, unlock_time),
            (_TAG_CLIENT_CHARACTER_LIMIT_TIME, limit_time),
        ])

    def _encode_client_money(money_type: str, money_value: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_MONEY_TYPE, money_type),
            (_TAG_MONEY_VALUE, money_value),
        ])

    def _encode_client_stat(stat_type: str, stat_value: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_STAT_TYPE, stat_type),
            (_TAG_STAT_VALUE, stat_value),
        ])

    def _encode_game_attachment(attachment_id: int, attachment_kind: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_ATTACHMENT_ID, attachment_id),
            (_TAG_ATTACHMENT_KIND, attachment_kind),
        ])

    def _encode_game_attachment_list(attachments: object) -> bytes:
        import struct as _st

        if not isinstance(attachments, list):
            return b""
        payload = b""
        for raw_item in attachments[:64]:
            if not isinstance(raw_item, dict):
                continue
            attachment_id = max(0, _as_int(raw_item.get("id"), 0))
            attachment_kind = max(0, _as_int(raw_item.get("kind"), 0))
            encoded_item = _encode_game_attachment(attachment_id, attachment_kind)
            payload += _st.pack("<I", len(encoded_item)) + encoded_item
        return payload

    def _encode_game_weapon_info(weapon_id: int, attachments: object = None) -> bytes:
        fields: list[tuple[int, object]] = [
            (_TAG_WEAPON_INFO_ID, weapon_id),
        ]
        attachments_blob = _encode_game_attachment_list(attachments)
        if attachments_blob:
            fields.append((_TAG_WEAPON_INFO_ATTACHMENTS, attachments_blob))
        return _sproto_encode_fields(fields)

    def _encode_game_character_info(
        character_id: int,
        cur_primary_weapon: int,
        primary_weapons: bytes,
        cur_secondary_weapon: int,
        secondary_weapons: bytes,
        cur_main_skill: int,
        main_skills: bytes,
        cur_sub_skill: int,
        sub_skills: bytes,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CHARACTER_INFO_ID, character_id),
            (_TAG_CHARACTER_INFO_CUR_PRIMARY_WEAPON, cur_primary_weapon),
            (_TAG_CHARACTER_INFO_PRIMARY_WEAPONS, primary_weapons),
            (_TAG_CHARACTER_INFO_CUR_SECONDARY_WEAPON, cur_secondary_weapon),
            (_TAG_CHARACTER_INFO_SECONDARY_WEAPONS, secondary_weapons),
            (_TAG_CHARACTER_INFO_CUR_MAIN_SKILL, cur_main_skill),
            (_TAG_CHARACTER_INFO_MAIN_SKILLS, main_skills),
            (_TAG_CHARACTER_INFO_CUR_SUB_SKILL, cur_sub_skill),
            (_TAG_CHARACTER_INFO_SUB_SKILLS, sub_skills),
        ])

    def _encode_game_choose_weapon_data(
        cur_primary_weapon: int,
        primary_weapons: bytes,
        cur_secondary_weapon: int,
        secondary_weapons: bytes,
        cur_main_skill: int,
        main_skills: bytes,
        cur_sub_skill: int,
        sub_skills: bytes,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CHOOSE_WEAPON_DATA_CUR_PRIMARY, cur_primary_weapon),
            (_TAG_CHOOSE_WEAPON_DATA_PRIMARY_WEAPONS, primary_weapons),
            (_TAG_CHOOSE_WEAPON_DATA_CUR_SECONDARY, cur_secondary_weapon),
            (_TAG_CHOOSE_WEAPON_DATA_SECONDARY_WEAPONS, secondary_weapons),
            (_TAG_CHOOSE_WEAPON_DATA_CUR_MAIN_SKILL, cur_main_skill),
            (_TAG_CHOOSE_WEAPON_DATA_MAIN_SKILLS, main_skills),
            (_TAG_CHOOSE_WEAPON_DATA_CUR_SUB_SKILL, cur_sub_skill),
            (_TAG_CHOOSE_WEAPON_DATA_SUB_SKILLS, sub_skills),
        ])

    def _encode_game_prebattle_user_data(uid: int, character_id: int, stage: int = 0) -> bytes:
        return _sproto_encode_fields([
            (_TAG_PRE_BATTLE_USER_UID, uid),
            (_TAG_PRE_BATTLE_USER_CHARACTER_ID, character_id),
            (_TAG_PRE_BATTLE_USER_STAGE, stage),
        ])

    def _encode_game_character_choose_player(uid: int, bid: int, name: str, region_id: int = 0) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CHARACTER_CHOOSE_PLAYER_UID, uid),
            (_TAG_CHARACTER_CHOOSE_PLAYER_BID, bid),
            (_TAG_CHARACTER_CHOOSE_PLAYER_NAME, name),
            (_TAG_CHARACTER_CHOOSE_PLAYER_REGION_ID, region_id),
        ])

    def _encode_game_battle_team_info(team: int, camp: int, win_times: int, players: bytes) -> bytes:
        return _sproto_encode_fields([
            (_TAG_BATTLE_TEAM_TEAM, team),
            (_TAG_BATTLE_TEAM_CAMP, camp),
            (_TAG_BATTLE_TEAM_WIN_TIMES, win_times),
            (_TAG_BATTLE_TEAM_PLAYERS, players),
        ])

    def _encode_game_rank_player_result(
        old_rank_score: int,
        new_rank_score: int,
        old_protect_score: int,
        new_protect_score: int,
        is_protect: int,
        is_offline: int,
        is_win: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_RANK_RESULT_OLD_RANK_SCORE, old_rank_score),
            (_TAG_RANK_RESULT_NEW_RANK_SCORE, new_rank_score),
            (_TAG_RANK_RESULT_OLD_PROTECT_SCORE, old_protect_score),
            (_TAG_RANK_RESULT_NEW_PROTECT_SCORE, new_protect_score),
            (_TAG_RANK_RESULT_IS_PROTECT, 1 if is_protect else 0),
            (_TAG_RANK_RESULT_IS_OFFLINE, 1 if is_offline else 0),
            (_TAG_RANK_RESULT_IS_WIN, 1 if is_win else 0),
        ])

    def _encode_game_box_result(box_id: int, add_rate: int, current_rate: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_BOX_RESULT_BOX_ID, box_id),
            (_TAG_BOX_RESULT_ADD_RATE, add_rate),
            (_TAG_BOX_RESULT_CURRENT_RATE, current_rate),
        ])

    def _encode_game_battle_player_result(
        uid: int,
        score: int,
        kill: int,
        assist: int,
        dead: int,
        is_no_hurt: bool,
        time_stamp: int,
        voicestate: int,
        rank_score: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_BATTLE_PLAYER_RESULT_UID, uid),
            (_TAG_BATTLE_PLAYER_RESULT_SCORE, score),
            (_TAG_BATTLE_PLAYER_RESULT_KILL, kill),
            (_TAG_BATTLE_PLAYER_RESULT_ASSIST, assist),
            (_TAG_BATTLE_PLAYER_RESULT_DEAD, dead),
            (_TAG_BATTLE_PLAYER_RESULT_IS_NO_HURT, 1 if is_no_hurt else 0),
            (_TAG_BATTLE_PLAYER_RESULT_TIME_STAMP, time_stamp),
            (_TAG_BATTLE_PLAYER_RESULT_VOICESTATE, voicestate),
            (_TAG_BATTLE_PLAYER_RESULT_RANK_SCORE, rank_score),
        ])

    def _encode_game_common_battle_result(
        *,
        my_win_times: int,
        enemy_win_times: int,
        winners_rank: list[int],
        players_result: list[bytes],
        combat_type: int,
        guide_id: int,
        add_exp: int,
        add_gold: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_COMMON_BATTLE_RESULT_MY_WIN_TIMES, my_win_times),
            (_TAG_COMMON_BATTLE_RESULT_ENEMY_WIN_TIMES, enemy_win_times),
            (_TAG_COMMON_BATTLE_RESULT_WINNERS_RANK, _TCPHandler._sproto_build_integer_list(winners_rank)),
            (_TAG_COMMON_BATTLE_RESULT_PLAYERS_RESULT, _TCPHandler._sproto_build_struct_list(players_result)),
            (_TAG_COMMON_BATTLE_RESULT_COMBAT_TYPE, combat_type),
            (_TAG_COMMON_BATTLE_RESULT_GUIDE_ID, guide_id),
            (_TAG_COMMON_BATTLE_RESULT_ADD_EXP, add_exp),
            (_TAG_COMMON_BATTLE_RESULT_ADD_GOLD, add_gold),
        ])

    def _normalize_player_base_icon(icon: int, icon_url: str) -> tuple[int, str]:
        """Return icon/icon_url pair accepted by PlayerBaseInfoManager.AddOrUpdate."""
        safe_icon = int(icon)
        safe_icon_url = str(icon_url or "")
        # Client rejects base-info updates when icon==0 and icon_url is empty.
        if safe_icon <= 0 and not safe_icon_url:
            safe_icon = 1
        return safe_icon, safe_icon_url

    def _encode_game_player_info(
        uid: int,
        name: str,
        level: int,
        icon: int,
        camp: int,
        index: int,
        rank_score: int,
        icon_url: str,
    ) -> bytes:
        icon, icon_url = _normalize_player_base_icon(icon, icon_url)
        return _sproto_encode_fields([
            (_TAG_GAME_PLAYER_INFO_UID, int(uid)),
            (_TAG_GAME_PLAYER_INFO_NAME, name),
            (_TAG_GAME_PLAYER_INFO_LEVEL, int(level)),
            (_TAG_GAME_PLAYER_INFO_ICON, int(icon)),
            (_TAG_GAME_PLAYER_INFO_CAMP, int(camp)),
            (_TAG_GAME_PLAYER_INFO_INDEX, int(index)),
            (_TAG_GAME_PLAYER_INFO_RANK_SCORE, int(rank_score)),
            (_TAG_GAME_PLAYER_INFO_ICON_URL, icon_url),
        ])

    def _encode_game_room_position_info(uid: int, index: int, camp: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_ROOM_POSITION_INFO_UID, int(uid)),
            (_TAG_ROOM_POSITION_INFO_INDEX, int(index)),
            (_TAG_ROOM_POSITION_INFO_CAMP, int(camp)),
        ])

    def _encode_client_leaderboard_info(name: str, label1: int, label2: int, label3: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CLIENT_LEADERBOARD_INFO_NAME, name),
            (_TAG_CLIENT_LEADERBOARD_INFO_LABEL1, label1),
            (_TAG_CLIENT_LEADERBOARD_INFO_LABEL2, label2),
            (_TAG_CLIENT_LEADERBOARD_INFO_LABEL3, label3),
        ])

    def _encode_client_leaderboard_player(
        uid: str,
        info: bytes,
        score: int,
        score2: int,
        score3: int,
        likes: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_CLIENT_LEADERBOARD_PLAYER_UID, uid),
            (_TAG_CLIENT_LEADERBOARD_PLAYER_INFO, info),
            (_TAG_CLIENT_LEADERBOARD_PLAYER_SCORE, score),
            (_TAG_CLIENT_LEADERBOARD_PLAYER_SCORE2, score2),
            (_TAG_CLIENT_LEADERBOARD_PLAYER_SCORE3, score3),
            (_TAG_CLIENT_LEADERBOARD_PLAYER_LIKES, likes),
        ])

    def _encode_mail_reward(item_id: int, num: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_MAIL_REWARD_ID, item_id),
            (_TAG_MAIL_REWARD_NUM, num),
        ])

    def _encode_mail_entry(
        mail_id: int,
        title: str,
        content: str,
        mail_type: int,
        is_custom: bool,
        expire_ts: int,
        status: int,
        rewards: bytes,
        create_ts: int,
        content_param: bytes,
        template_type: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_MAIL_ID, mail_id),
            (_TAG_MAIL_TITLE, title),
            (_TAG_MAIL_CONTENT, content),
            (_TAG_MAIL_TYPE, mail_type),
            (_TAG_MAIL_IS_CUSTOM, bool(is_custom)),
            (_TAG_MAIL_EXPIRE_TS, expire_ts),
            (_TAG_MAIL_STATUS, status),
            (_TAG_MAIL_REWARDS, rewards),
            (_TAG_MAIL_CREATE_TS, create_ts),
            (_TAG_MAIL_CONTENT_PARAM, content_param),
            (_TAG_MAIL_TEMPLATE_TYPE, template_type),
        ])

    def _encode_mail_operate_result(mail_id: int, errorcode: int) -> bytes:
        return _sproto_encode_fields([
            (_TAG_MAIL_OPERATE_RES_ID, mail_id),
            (_TAG_MAIL_OPERATE_RES_ERRORCODE, errorcode),
        ])

    def _encode_team_player_info(
        uid: int,
        name: str,
        icon: int,
        level: int,
        mmr: int,
        icon_url: str,
        rank_score: int,
        show_character: bytes | None = None,
    ) -> bytes:
        icon, icon_url = _normalize_player_base_icon(icon, icon_url)
        fields: list[tuple[int, object]] = [
            (_TAG_TEAM_PLAYER_UID, int(uid)),
            (_TAG_TEAM_PLAYER_NAME, name),
            (_TAG_TEAM_PLAYER_ICON, int(icon)),
            (_TAG_TEAM_PLAYER_LEVEL, int(level)),
            (_TAG_TEAM_PLAYER_MMR, int(mmr)),
            (_TAG_TEAM_PLAYER_ICON_URL, icon_url),
            (_TAG_TEAM_PLAYER_RANK_SCORE, int(rank_score)),
        ]
        if isinstance(show_character, (bytes, bytearray)) and len(show_character) > 0:
            fields.append((_TAG_TEAM_PLAYER_SHOW_CHARACTER, bytes(show_character)))
        return _sproto_encode_fields(fields)

    def _encode_team_member(pos: int, info: bytes, is_ready: bool) -> bytes:
        return _sproto_encode_fields([
            (_TAG_TEAM_MEMBER_POS, int(pos)),
            (_TAG_TEAM_MEMBER_INFO, info),
            (_TAG_TEAM_MEMBER_READY, bool(is_ready)),
        ])

    def _encode_team_data(
        team_id: str,
        members: bytes,
        captain_index: int,
        capacity: int,
        battle_zone: int,
        combat_type: int,
        min_rank_limit: int,
        max_rank_limit: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_TEAM_DATA_TEAM_ID, team_id),
            (_TAG_TEAM_DATA_MEMBERS, members),
            (_TAG_TEAM_DATA_CAPTAIN_INDEX, int(captain_index)),
            (_TAG_TEAM_DATA_CAPACITY, int(capacity)),
            (_TAG_TEAM_DATA_BATTLE_ZONE, int(battle_zone)),
            (_TAG_TEAM_DATA_COMBAT_TYPE, int(combat_type)),
            (_TAG_TEAM_DATA_MIN_RANK, int(min_rank_limit)),
            (_TAG_TEAM_DATA_MAX_RANK, int(max_rank_limit)),
        ])

    def _encode_invite_player_info(
        uid: int,
        name: str,
        icon: int,
        level: int,
        icon_url: str,
        extra_arg: str,
        rank_score: int,
    ) -> bytes:
        return _sproto_encode_fields([
            (_TAG_INVITE_PLAYER_UID, uid),
            (_TAG_INVITE_PLAYER_NAME, name),
            (_TAG_INVITE_PLAYER_ICON, icon),
            (_TAG_INVITE_PLAYER_LEVEL, level),
            (_TAG_INVITE_PLAYER_ICON_URL, icon_url),
            (_TAG_INVITE_PLAYER_EXTRA_ARG, extra_arg),
            (_TAG_INVITE_PLAYER_RANK_SCORE, rank_score),
        ])

    _FULL_GRANT_BAG_TYPES = {_BAG_TYPE_HERO, 3, 4, _BAG_TYPE_GIFT_BOX, 11, 13}

    _BUNDLE_PRICE_DEFAULTS = {
        10001: 99,
        10002: 199,
        10003: 299,
        10004: 399,
        10005: 499,
    }
    _BUNDLE_PRICE_DEFAULTS.update(_load_bundle_default_prices_from_lua_table(_BUNDLE_LUA_PATH))
    _DISCOUNT_STORE_TO_STORE_ID = {
        20200310: 900430020,
        20200311: 911220040,
        20200312: 1002830030,
        20200313: 50460,
        20200314: 1000120020,
        20200315: 911220040,
        20200316: 1002830030,
        20200317: 50460,
        20200318: 911220040,
        20200319: 1002830030,
        20200320: 50460,
        20200321: 911220040,
        20200322: 1002830030,
        20200323: 50460,
        20200324: 911220040,
        20200325: 1002830030,
        20200326: 50460,
        20200327: 911220040,
        20200328: 1002830030,
        20200329: 50460,
        20200330: 911220040,
        20200331: 1002830030,
    }

    def _default_store_state() -> dict:
        now_ts = int(time.time())
        refresh_sec = max(300, _int_env("STORE_DISCOUNT_REFRESH_SEC", 21600))
        return {
            "store_type_overrides": {
                _STORE_TYPE_BODY: _int_env("STORE_TYPE_4_ITEM_ID", 900230020),
                _STORE_TYPE_WEAPON_PT: _int_env("STORE_TYPE_5_ITEM_ID", 1000110010),
                _STORE_TYPE_BUNDLE: _int_env("STORE_TYPE_7_ITEM_ID", 10001),
                _STORE_TYPE_BOX: _int_env("STORE_TYPE_9_ITEM_ID", 20001),
            },
            "discount_fix_item": {
                "item_id": _int_env("DISCOUNT_FIX_ITEM_ID", 20),
                "item_id_type": 0,
                "bought": False,
                "discount": 80,
            },
            "discount_random_items": [
                {
                    "item_id": _int_env("DISCOUNT_RANDOM_ITEM_1", 60),
                    "item_id_type": 0,
                    "bought": False,
                    "discount": 70,
                },
                {
                    "item_id": _int_env("DISCOUNT_RANDOM_ITEM_2", 70),
                    "item_id_type": 0,
                    "bought": False,
                    "discount": 65,
                },
                {
                    "item_id": _int_env("DISCOUNT_RANDOM_ITEM_3", 90),
                    "item_id_type": 0,
                    "bought": False,
                    "discount": 60,
                },
            ],
            "discount_refresh_time": now_ts + refresh_sec,
            "purchase_history": {},
            "owned_bag_items": {},
            "box_open_counters": {},
        }

    def _normalize_discount_item(item: object, fallback: dict) -> dict:
        if not isinstance(item, dict):
            item = {}
        item_id = max(1, _as_int(item.get("item_id"), _as_int(fallback.get("item_id"), 20200310)))
        item_id_type = _as_int(item.get("item_id_type"), _as_int(fallback.get("item_id_type"), 1))
        if item_id_type not in (0, 1):
            item_id_type = 1
        if item_id_type == 1:
            mapped = _DISCOUNT_STORE_TO_STORE_ID.get(item_id)
            if mapped is not None and _as_int(fallback.get("item_id_type"), 1) == 0:
                item_id = mapped
                item_id_type = 0
        return {
            "item_id": item_id,
            "item_id_type": item_id_type,
            "bought": bool(_as_int(item.get("bought"), 1 if fallback.get("bought") else 0)),
            "discount": max(1, min(99, _as_int(item.get("discount"), _as_int(fallback.get("discount"), 80)))),
        }

    def _normalize_store_state(raw: object) -> dict:
        base = _default_store_state()
        if not isinstance(raw, dict):
            _apply_full_inventory_grant(base)
            return base

        normalized = {
            "store_type_overrides": dict(base["store_type_overrides"]),
            "discount_fix_item": dict(base["discount_fix_item"]),
            "discount_random_items": [dict(x) for x in base["discount_random_items"]],
            "discount_refresh_time": _as_int(base["discount_refresh_time"], int(time.time()) + 21600),
            "purchase_history": {},
            "owned_bag_items": {},
            "box_open_counters": {},
        }

        overrides = raw.get("store_type_overrides")
        if isinstance(overrides, dict):
            for key, value in overrides.items():
                store_type = _as_int(key, -1)
                item_id = _as_int(value, 0)
                if store_type > 0 and item_id > 0:
                    normalized["store_type_overrides"][store_type] = item_id

        normalized["discount_fix_item"] = _normalize_discount_item(
            raw.get("discount_fix_item"),
            normalized["discount_fix_item"],
        )
        if _as_int(normalized["discount_fix_item"].get("item_id_type"), 0) not in (0, 1):
            normalized["discount_fix_item"]["item_id_type"] = 0

        sale_store_ids = [
            _as_int(x, 0)
            for x in _STORE_TYPE_DEFAULT_ITEMS.get(_STORE_TYPE_CHARACTER, [20])
            if _as_int(x, 0) > 0
        ]
        if not sale_store_ids:
            sale_store_ids = [20]

        # Legacy saves often keep operator-style discount ids (item_id_type=1).
        # For local stub stability, keep sale items on normal store ids (item_id_type=0).
        normalized["discount_fix_item"]["item_id_type"] = 0
        if _as_int(normalized["discount_fix_item"].get("item_id"), 0) not in sale_store_ids:
            normalized["discount_fix_item"]["item_id"] = sale_store_ids[0]

        random_items = raw.get("discount_random_items")
        if isinstance(random_items, list):
            mapped: list[dict] = []
            for idx, item in enumerate(random_items[:5]):
                fallback = (
                    normalized["discount_random_items"][idx]
                    if idx < len(normalized["discount_random_items"])
                    else {
                        "item_id": [60, 70, 90, 100, 110][idx] if idx < 5 else 60,
                        "item_id_type": 0,
                        "bought": False,
                        "discount": max(35, 70 - idx * 5),
                    }
                )
                mapped.append(_normalize_discount_item(item, fallback))
            if mapped:
                for idx, item in enumerate(mapped):
                    item["item_id_type"] = 0
                    if _as_int(item.get("item_id"), 0) not in sale_store_ids:
                        item["item_id"] = sale_store_ids[min(idx + 1, len(sale_store_ids) - 1)]
                normalized["discount_random_items"] = mapped

        refresh_time = _as_int(raw.get("discount_refresh_time"), 0)
        if refresh_time > int(time.time()) - 60:
            normalized["discount_refresh_time"] = refresh_time

        history = raw.get("purchase_history")
        if isinstance(history, dict):
            history_out: dict[str, int] = {}
            for key, value in history.items():
                item_id = _as_int(key, -1)
                if item_id <= 0:
                    continue
                if _as_int(_STORE_ITEM_TO_TYPE.get(item_id), 0) == _STORE_TYPE_BOX:
                    continue
                history_out[str(item_id)] = max(0, _as_int(value, 0))
            normalized["purchase_history"] = history_out

        owned = raw.get("owned_bag_items")
        if isinstance(owned, dict):
            owned_out: dict[str, int] = {}
            for key, value in owned.items():
                bag_id = _as_int(key, -1)
                if bag_id <= 0:
                    continue
                if _as_int(_STORE_ITEM_TO_TYPE.get(bag_id), 0) == _STORE_TYPE_BOX:
                    continue
                if bag_id in _STORE_TYPE_9_REWARD_ITEM_IDS:
                    continue
                count = max(0, _as_int(value, 0))
                if count > 0:
                    owned_out[str(bag_id)] = count
            normalized["owned_bag_items"] = owned_out

        box_counters = raw.get("box_open_counters")
        if isinstance(box_counters, dict):
            counters_out: dict[str, int] = {}
            for key, value in box_counters.items():
                box_id = _as_int(key, -1)
                if box_id <= 0:
                    continue
                resolved_box_id = _as_int(_CHEST_ID_TO_BOX_ID.get(box_id), box_id)
                if _as_int(_STORE_ITEM_TO_TYPE.get(resolved_box_id), 0) == _STORE_TYPE_BOX:
                    continue
                counters_out[str(box_id)] = max(0, _as_int(value, 0))
            normalized["box_open_counters"] = counters_out

        _apply_full_inventory_grant(normalized)

        return normalized

    def _apply_full_inventory_grant(store_state: dict) -> None:
        if not _GRANT_ALL_CONTENT:
            return

        owned = store_state.get("owned_bag_items")
        if not isinstance(owned, dict):
            owned = {}
            store_state["owned_bag_items"] = owned

        grant_ids: set[int] = set()
        for bag_id_raw, bag_type_raw in _BAG_TYPE_BY_ID.items():
            bag_id = _as_int(bag_id_raw, 0)
            bag_type = _as_int(bag_type_raw, 0)
            if bag_id <= 0:
                continue
            if bag_type in _FULL_GRANT_BAG_TYPES:
                grant_ids.add(bag_id)

        for item_id_raw in _STORE_TYPE_DEFAULT_ITEMS.get(_STORE_TYPE_BUNDLE, []):
            item_id = _as_int(item_id_raw, 0)
            if item_id > 0:
                grant_ids.add(item_id)

        for bag_id in grant_ids:
            cur = max(0, _as_int(owned.get(str(bag_id)), 0))
            if cur <= 0:
                owned[str(bag_id)] = 1

        purchase_history = store_state.get("purchase_history")
        if not isinstance(purchase_history, dict):
            purchase_history = {}
            store_state["purchase_history"] = purchase_history

        agent_purchase_ids: set[int] = set()
        for item_id_raw in _STORE_TYPE_DEFAULT_ITEMS.get(_STORE_TYPE_CHARACTER, []):
            item_id = _as_int(item_id_raw, 0)
            if item_id > 0:
                agent_purchase_ids.add(item_id)
        for item_id_raw in _TYPE1_AGENT_PRICE_FALLBACK_IDS:
            item_id = _as_int(item_id_raw, 0)
            if item_id > 0:
                agent_purchase_ids.add(item_id)

        for item_id in agent_purchase_ids:
            cur = max(0, _as_int(purchase_history.get(str(item_id)), 0))
            if cur <= 0:
                purchase_history[str(item_id)] = 1

    def _build_default_mail_state(now_ts: int | None = None) -> dict:
        ts = max(1, _as_int(now_ts, int(time.time())))
        return {
            "next_mail_id": 2,
            "mails": [
                {
                    "id": 1,
                    "title": "Welcome",
                    "content": "Welcome to local server.",
                    "mail_type": 1,
                    "is_custom": True,
                    "expire_ts": ts + 30 * 86400,
                    "status": 0,  # not read
                    "rewards": [
                        {"id": 90002, "num": 1000},
                    ],
                    "create_ts": ts,
                    "content_param": [],
                    "template_type": 0,
                }
            ],
        }

    def _normalize_mail_state(raw: object) -> dict:
        default_state = _build_default_mail_state()
        if not isinstance(raw, dict):
            return default_state

        mails_src = raw.get("mails")
        mails_out: list[dict[str, object]] = []
        max_mail_id = 0
        now_ts = int(time.time())
        if isinstance(mails_src, list):
            for mail_raw in mails_src:
                if not isinstance(mail_raw, dict):
                    continue
                mail_id = max(1, _as_int(mail_raw.get("id"), 0))
                if mail_id <= 0:
                    continue
                max_mail_id = max(max_mail_id, mail_id)

                rewards_out: list[dict[str, int]] = []
                rewards_src = mail_raw.get("rewards")
                if isinstance(rewards_src, list):
                    for reward_raw in rewards_src:
                        if not isinstance(reward_raw, dict):
                            continue
                        reward_id = max(0, _as_int(reward_raw.get("id"), 0))
                        reward_num = max(0, _as_int(reward_raw.get("num"), 0))
                        if reward_id <= 0 or reward_num <= 0:
                            continue
                        rewards_out.append({"id": reward_id, "num": reward_num})

                mails_out.append({
                    "id": mail_id,
                    "title": str(mail_raw.get("title") or "Mail"),
                    "content": str(mail_raw.get("content") or ""),
                    "mail_type": max(1, _as_int(mail_raw.get("mail_type"), 1)),
                    "is_custom": bool(mail_raw.get("is_custom", True)),
                    "expire_ts": max(1, _as_int(mail_raw.get("expire_ts"), now_ts + 86400)),
                    "status": max(0, min(2, _as_int(mail_raw.get("status"), 0))),
                    "rewards": rewards_out,
                    "create_ts": max(1, _as_int(mail_raw.get("create_ts"), now_ts)),
                    "content_param": [],
                    "template_type": max(0, _as_int(mail_raw.get("template_type"), 0)),
                })

        if not mails_out:
            mails_out = list(default_state["mails"])
            max_mail_id = max(max_mail_id, 1)

        next_mail_id = max(1, _as_int(raw.get("next_mail_id"), 0))
        next_mail_id = max(next_mail_id, max_mail_id + 1)
        return {
            "next_mail_id": next_mail_id,
            "mails": mails_out,
        }

    def _normalize_saved_attachment_list(raw_value: object) -> list[dict[str, int]]:
        if isinstance(raw_value, list):
            raw_items = raw_value
        elif isinstance(raw_value, dict):
            raw_items = [raw_value]
        else:
            raw_items = []

        parsed_items: list[dict[str, int]] = []
        seen_pairs: set[tuple[int, int]] = set()
        for raw_item in raw_items[:128]:
            if not isinstance(raw_item, dict):
                continue
            attachment_id = max(0, _as_int(raw_item.get("id"), 0))
            attachment_kind = max(0, _as_int(raw_item.get("kind"), 0))
            key = (attachment_kind, attachment_id)
            if key in seen_pairs:
                continue
            seen_pairs.add(key)
            parsed_items.append({"id": attachment_id, "kind": attachment_kind})

        if not any(item.get("kind", -1) == 0 for item in parsed_items):
            parsed_items.insert(0, {"id": 0, "kind": 0})
        return parsed_items[:64]

    def _normalize_saved_weapon(raw_weapon: object, fallback_id: int) -> dict[str, object]:
        if not isinstance(raw_weapon, dict):
            raw_weapon = {}
        weapon_id = max(1, _as_int(raw_weapon.get("id"), max(1, fallback_id)))
        skin_id = max(0, _as_int(raw_weapon.get("skin"), 0))
        attachments = _normalize_saved_attachment_list(raw_weapon.get("attachments"))
        return {"id": weapon_id, "skin": skin_id, "attachments": attachments}

    def _default_spawn_region_for_camp_value(camp: object) -> int:
        """
        Canonical prebattle spawn-region defaults by camp.

        Client prebattle model uses slot ids, not scene spawn ids:
            continue
        - attacker: 255 ("default/top entry"), then 0..2
        - defender: 0..3
        """
        camp_id = _as_int(camp, 1)
        if camp_id == 1:
            return 255
        configured = max(0, _as_int(_DEFAULT_SPAWN_REGION_ID, 0))
        if configured in (0, 1, 2, 3):
            return configured
        return 0

    def _spawn_region_is_valid_for_camp_value(camp: object, region_id: object) -> bool:
        camp_id = _as_int(camp, 1)
        rid = _as_int(region_id, -1)
        if rid < 0 or rid == 999:
            return False
        if camp_id == 1:
            return rid in (255, 0, 1, 2)
        if camp_id == 2:
            return rid in (0, 1, 2, 3)
        return rid >= 0

    def _default_training_profile() -> dict[str, object]:
        default_region = _default_spawn_region_for_camp_value(1)
        return {
            "camp": 1,
            "character_id": 1,
            "primary_weapon": {"id": 10036, "skin": 0, "attachments": [{"id": 0, "kind": 0}]},
            "secondary_weapon": {"id": 10074, "skin": 0, "attachments": [{"id": 0, "kind": 0}]},
            "main_skill_id": 295,
            "sub_skill_id": 299,
            "spawn_region_id": default_region,
            "region_id": default_region,
        }

    def _default_selected_skins() -> dict[str, object]:
        return {
            "show_character_id": 0,
            "characters": {},
        }

    def _normalize_selected_skins(raw_value: object) -> dict[str, object]:
        base = _default_selected_skins()
        if not isinstance(raw_value, dict):
            raw_value = {}

        show_character_id = max(0, _as_int(raw_value.get("show_character_id"), _as_int(base.get("show_character_id"), 0)))
        characters_raw = raw_value.get("characters")
        out_characters: dict[str, dict[str, object]] = {}
        if isinstance(characters_raw, dict):
            for char_key_raw, char_entry_raw in characters_raw.items():
                char_id = max(0, _as_int(char_key_raw, _as_int(char_entry_raw.get("id"), 0) if isinstance(char_entry_raw, dict) else 0))
                if char_id <= 0:
                    continue

                char_entry = char_entry_raw if isinstance(char_entry_raw, dict) else {}
                char_skins_raw = char_entry.get("char_skins")
                char_skins: list[int] = []
                if isinstance(char_skins_raw, list):
                    for sid_raw in char_skins_raw:
                        sid = _as_int(sid_raw, 0)
                        if sid > 0 and sid not in char_skins:
                            char_skins.append(sid)

                weapon_skins_raw = char_entry.get("weapon_skins")
                weapon_skins: dict[str, list[int]] = {}
                if isinstance(weapon_skins_raw, dict):
                    for weapon_key_raw, skin_ids_raw in weapon_skins_raw.items():
                        weapon_id = max(0, _as_int(weapon_key_raw, 0))
                        if weapon_id <= 0:
                            continue
                        skin_ids: list[int] = []
                        if isinstance(skin_ids_raw, list):
                            for sid_raw in skin_ids_raw:
                                sid = _as_int(sid_raw, 0)
                                if sid > 0 and sid not in skin_ids:
                                    skin_ids.append(sid)
                        if skin_ids:
                            weapon_skins[str(weapon_id)] = skin_ids

                out_characters[str(char_id)] = {
                    "char_skins": char_skins[:16],
                    "weapon_skins": weapon_skins,
                }

        return {
            "show_character_id": show_character_id,
            "characters": out_characters,
        }

    def _normalize_training_profile(raw_profile: object) -> dict[str, object]:
        base = _default_training_profile()
        if not isinstance(raw_profile, dict):
            raw_profile = {}

        camp = _as_int(raw_profile.get("camp"), _as_int(base.get("camp"), 1))
        if camp not in (1, 2):
            camp = 1
        character_id = max(1, _as_int(raw_profile.get("character_id"), _as_int(base.get("character_id"), 1)))
        primary_weapon = _normalize_saved_weapon(
            raw_profile.get("primary_weapon"),
            _as_int((base.get("primary_weapon") or {}).get("id"), 10036),
        )
        secondary_weapon = _normalize_saved_weapon(
            raw_profile.get("secondary_weapon"),
            _as_int((base.get("secondary_weapon") or {}).get("id"), 10074),
        )
        main_skill_id = max(1, _as_int(raw_profile.get("main_skill_id"), _as_int(base.get("main_skill_id"), 295)))
        sub_skill_id = max(1, _as_int(raw_profile.get("sub_skill_id"), _as_int(base.get("sub_skill_id"), 299)))
        default_region = _default_spawn_region_for_camp_value(camp)
        spawn_region_id = _as_int(
            raw_profile.get("spawn_region_id"),
            _as_int(base.get("spawn_region_id"), default_region),
        )
        if spawn_region_id == 999:
            spawn_region_id = _as_int(base.get("spawn_region_id"), default_region)
        if not _spawn_region_is_valid_for_camp_value(camp, spawn_region_id):
            spawn_region_id = default_region
        region_id = _as_int(raw_profile.get("region_id"), spawn_region_id)
        if region_id == 999:
            region_id = spawn_region_id
        if not _spawn_region_is_valid_for_camp_value(camp, region_id):
            region_id = spawn_region_id

        return {
            "camp": camp,
            "character_id": character_id,
            "primary_weapon": primary_weapon,
            "secondary_weapon": secondary_weapon,
            "main_skill_id": main_skill_id,
            "sub_skill_id": sub_skill_id,
            "spawn_region_id": spawn_region_id,
            "region_id": region_id,
        }

    def _load_player_save() -> dict:
        try:
            if _PLAYER_SAVE_PATH.exists():
                with _PLAYER_SAVE_PATH.open("r", encoding="utf-8") as f:
                    return json.load(f)
        except Exception as exc:
            pass
        return {}

    def _save_player_data():
        """Persist _player_data/_client_config/_store_state/_mail_state to disk."""
        try:
            with _PLAYER_SAVE_LOCK:
                _PLAYER_SAVE_PATH.parent.mkdir(parents=True, exist_ok=True)
                payload = {
                    "player_data": _player_data.storage if hasattr(_player_data, "storage") else _player_data,
                    "client_config": _client_config.storage if hasattr(_client_config, "storage") else _client_config,
                    "store_state": _store_state.storage if hasattr(_store_state, "storage") else _store_state,
                    "mail_state": _mail_state.storage if hasattr(_mail_state, "storage") else _mail_state,
                }
                tmp = _PLAYER_SAVE_PATH.with_suffix(
                    f".tmp.{os.getpid()}.{threading.get_ident()}"
                )
                try:
                    with tmp.open("w", encoding="utf-8", newline="\n") as f:
                        json.dump(payload, f, ensure_ascii=False, indent=2)

                    replaced = False
                    last_exc: Exception | None = None
                    for attempt in range(3):
                        try:
                            tmp.replace(_PLAYER_SAVE_PATH)
                            replaced = True
                            last_exc = None
                            break
                        except PermissionError as exc:
                            last_exc = exc
                            time.sleep(0.05 * (attempt + 1))
                    if not replaced:
                        # Fallback for restrictive Windows file sharing on rename.
                        with _PLAYER_SAVE_PATH.open("w", encoding="utf-8", newline="\n") as f:
                            json.dump(payload, f, ensure_ascii=False, indent=2)
                        if last_exc is not None:
                            _append_utf8_log(
                                f"[SAVE] replace fallback used after PermissionError: {last_exc}"
                            )
                finally:
                    try:
                        if tmp.exists():
                            tmp.unlink()
                    except Exception:
                        pass
        except Exception as exc:
            import traceback; traceback.print_exc()
            _append_utf8_log(f"[SAVE] failed to write player save: {exc}")

    _saved = _load_player_save()

    p_data = _saved.get("player_data", {})
    if "uid" in p_data: # old format migration
        _player_data.storage = {"1000001": p_data}
        _client_config.storage = {"1000001": _saved.get("client_config", {})}
        _store_state.storage = {"1000001": _saved.get("store_state", {})}
        _mail_state.storage = {"1000001": _saved.get("mail_state", {})}
    else:
        _player_data.storage = p_data
        _client_config.storage = _saved.get("client_config", {})
        _store_state.storage = _saved.get("store_state", {})
        _mail_state.storage = _saved.get("mail_state", {})

    globals()["_player_data"] = _player_data
    globals()["_client_config"] = _client_config
    globals()["_store_state"] = _store_state
    globals()["_mail_state"] = _mail_state

    # Persist normalized save shape (legacy saves may miss new keys like gold/diamond/store_state).
    _save_player_data()

    # ── Game/battle session state ─────────────────────────────────────
    _game_state = {
        "mode_id": 0,       # 0=none, 2=guide, 3=training
        "map_id": 1,        # selected map
        "team": 1,          # BattleTeam (1=my team slot, 2=other)
        "camp": 1,          # selected camp (1=attacker, 2=defender)
        "player_bid": 1,    # local player battle slot id
        "region_id": _default_spawn_region_for_camp_value(1),   # CharacterInfo.region_id used by battle load path
        "spawn_region_id": _default_spawn_region_for_camp_value(1),
        "prebattle_stage": 1,  # 1=spawn,2=agent,3=equip,4=completed
        "_prebattle_loadout_seeded": False,  # one-shot default-loadout seed for auto-selected agent
        "_prebattle_choose_character_pushed": False,  # whether 1021 was pushed in current prebattle cycle
        "prebattle_room_started": False,  # becomes True after ReqRoomStart / RspRoomStart handshake
        "prebattle_flow_active": False,  # becomes True after room-start/prebattle handshake
        "_restart_prebattle_bootstrap_pending": False,  # one-shot lobby bootstrap after battle RestartMode
        "battle_zone": 1,   # selected battle zone id
        "region_type": 0,   # optional region type for room start
        "guide_id": 0,      # tutorial guide id
        "battle_id": 1,     # battle session id counter
        "in_battle": False,  # whether battle connection was established
        "_confirm_sent": False,  # dedup for ConfirmBattle push
        "_confirm_pending": False,  # deferred ConfirmBattle latch during training prebattle
        "_last_confirm_push_ts": 0.0,  # throttle for repeated 1055 retry pushes
        "_last_result_battle_id": 0,  # dedup for battle result push (1102)
        # ── Character / weapon selection (set by lobby handlers) ──
        "character_id": 1,
        "primary_weapon": {"id": 10036, "skin": 0, "attachments": []},
        "secondary_weapon": {"id": 10074, "skin": 0, "attachments": []},
        "main_skill_id": 295,
        "sub_skill_id": 299,
    }

    def _training_profile_from_game_state(gs: dict) -> dict[str, object]:
        return _normalize_training_profile({
            "camp": gs.get("camp"),
            "character_id": gs.get("character_id"),
            "primary_weapon": gs.get("primary_weapon"),
            "secondary_weapon": gs.get("secondary_weapon"),
            "main_skill_id": gs.get("main_skill_id"),
            "sub_skill_id": gs.get("sub_skill_id"),
            "spawn_region_id": gs.get("spawn_region_id"),
            "region_id": gs.get("region_id"),
        })

    def _apply_training_profile_to_game_state(gs: dict, profile: object) -> None:
        if not isinstance(gs, dict):
            return
        normalized = _normalize_training_profile(profile)
        gs["camp"] = normalized["camp"]
        if normalized["camp"] == 1:
            gs["team"] = 2
        elif normalized["camp"] == 2:
            gs["team"] = 1
        gs["character_id"] = normalized["character_id"]
        gs["primary_weapon"] = normalized["primary_weapon"]
        gs["secondary_weapon"] = normalized["secondary_weapon"]
        gs["main_skill_id"] = normalized["main_skill_id"]
        gs["sub_skill_id"] = normalized["sub_skill_id"]
        gs["spawn_region_id"] = normalized["spawn_region_id"]
        gs["region_id"] = normalized["region_id"]

    def _persist_training_profile(*, save: bool = False) -> None:
        if not isinstance(_player_data, dict):
            return
        _player_data["training_profile"] = _training_profile_from_game_state(_game_state)
        if save:
            _save_player_data()

    _apply_training_profile_to_game_state(_game_state, _player_data.get("training_profile"))
    _persist_training_profile(save=True)

    _MAIL_STATUS_NOT_READ = 0
    _MAIL_STATUS_READ = 1
    _MAIL_STATUS_GET_REWARD = 2

    # Currency bag ids used by CommonReward/UI rendering.
    _BAG_ID_GOLD = 90001
    _BAG_ID_DIAMOND = 90002

    try:
        _ROOM_SNAPSHOT_PUSH_MIN_INTERVAL = max(
            0.05,
            float((os.environ.get("ROOM_SNAPSHOT_PUSH_MIN_INTERVAL") or "0.35").strip() or "0.35"),
        )
    except Exception:
        _ROOM_SNAPSHOT_PUSH_MIN_INTERVAL = 0.35

    _room_state = _ROOM_STATE
    _room_state.update({
        "next_room_id": _int_env("DEFAULT_ROOM_ID", 100001),
        "room_id": 0,
        "owner_uid": 0,
        "battle_zone": _game_state.get("battle_zone", 1),
        "map_id": _game_state.get("map_id", 1),
        "mode_id": _game_state.get("mode_id", 0),
        "players": {},
        "snapshot_sent": False,
        "last_snapshot_push_ts": 0.0,
    })

    _team_state = {
        "next_team_id": _int_env("DEFAULT_TEAM_ID", 1),
        "team_id": "",
        "battle_zone": _game_state.get("battle_zone", 1),
        "combat_type": 0,
        "captain_uid": 0,
        "capacity": 5,
        "is_matching": False,
        "match_started_ts": 0,
        "match_estimated_time": 0,
        "members": {},
    }

    _invite_state = {
        "next_identify_id": 1,
        "pending": {},
    }

    _LOBBY_PUSH_LOCK = threading.Lock()
    _LOBBY_PENDING_PUSHES: dict[str, list[tuple[bytes, str]]] = {}
    _ACTIVE_LOBBY_HANDLERS: dict[str, object] = {}

    class _TCPHandler(socketserver.BaseRequestHandler):

        def _session_uid(self, pd: dict | None = None) -> int:
            raw = getattr(self, "_session_uid_value", None)
            if raw is not None:
                return max(1, _TCPHandler._sproto_read_int(raw, 1000001))
            base_pd = pd if isinstance(pd, dict) else _player_data
            uid = max(1, _TCPHandler._sproto_read_int(base_pd.get("uid"), 1000001))
            setattr(self, "_session_uid_value", uid)
            return uid

        def _set_session_uid(self, uid: object, pd: dict | None = None, *, reason: str = "") -> int:
            current = self._session_uid(pd)
            resolved = max(1, _TCPHandler._sproto_read_int(uid, current))
            setattr(self, "_session_uid_value", resolved)
            _tls.uid = resolved
            local_pd = None
            if isinstance(_player_data, dict) and _TCPHandler._sproto_read_int(_player_data.get("uid"), 0) == resolved:
                local_pd = _player_data
            _online_ensure_profile(resolved, local_pd=local_pd)
            with _LOBBY_PUSH_LOCK:
                _ACTIVE_LOBBY_HANDLERS[str(resolved)] = self
            if reason:
                _append_utf8_log(f"[TCP] session_uid set={resolved} reason={reason}")
            return resolved

        @staticmethod
        def _queue_pending_push(uid: object, push: tuple[bytes, str]) -> None:
            uid_s = _uid_str(uid, "")
            if not uid_s:
                return
            frame, tag = push
            if not isinstance(frame, (bytes, bytearray)) or not frame:
                return

            sent_live = False
            with _LOBBY_PUSH_LOCK:
                handler = _ACTIVE_LOBBY_HANDLERS.get(uid_s)

            if handler is not None:
                try:
                    handler.request.sendall(bytes(frame))
                    sent_live = True
                    _append_utf8_log(f"[TCP] push live-sent to active connection uid={uid_s} tag={tag} len={len(frame)}")
                except Exception as exc:
                    _append_utf8_log(f"[TCP] push live-send failed uid={uid_s} tag={tag}: {exc}")
                    sent_live = False

            if not sent_live:
                with _LOBBY_PUSH_LOCK:
                    bucket = _LOBBY_PENDING_PUSHES.get(uid_s)
                    if not isinstance(bucket, list):
                        bucket = []
                        _LOBBY_PENDING_PUSHES[uid_s] = bucket
                    if len(bucket) >= 256:
                        del bucket[: max(1, len(bucket) - 255)]
                    bucket.append((bytes(frame), str(tag)))
                    _append_utf8_log(f"[TCP] push queued into pending_pushes uid={uid_s} tag={tag}")

        @staticmethod
        def _queue_pending_pushes(uid: object, pushes: list[tuple[bytes, str]]) -> None:
            for push in pushes:
                _TCPHandler._queue_pending_push(uid, push)

        @staticmethod
        def _drain_pending_pushes(uid: object, max_items: int = 64) -> list[tuple[bytes, str]]:
            uid_s = _uid_str(uid, "")
            if not uid_s:
                return []
            if max_items <= 0:
                max_items = 1
            with _LOBBY_PUSH_LOCK:
                bucket = _LOBBY_PENDING_PUSHES.get(uid_s)
                if not isinstance(bucket, list) or not bucket:
                    return []
                out = bucket[:max_items]
                del bucket[:max_items]
                if not bucket:
                    _LOBBY_PENDING_PUSHES.pop(uid_s, None)
            return out

        @staticmethod
        def _team_member_uid_list() -> list[int]:
            members = _team_state.get("members")
            if not isinstance(members, dict):
                return []
            out: list[int] = []
            for uid_s in members.keys():
                uid = max(0, _safe_int(uid_s, 0))
                if uid > 0 and uid not in out:
                    out.append(uid)
            return out

        @staticmethod
        def _queue_team_pushes(pushes: list[tuple[bytes, str]], *, exclude_uid: object = None) -> None:
            excluded = max(0, _safe_int(exclude_uid, 0))
            for uid in _TCPHandler._team_member_uid_list():
                if excluded > 0 and uid == excluded:
                    continue
                _TCPHandler._queue_pending_pushes(uid, pushes)

        @staticmethod
        def _schedule_force_set_player_info_hint(
            uid: object,
            role_name: object,
            delay_s: float,
            reason: str,
        ) -> None:
            attempt = _chat_bootstrap_reserve_attempt(uid)
            if attempt is None:
                return
            uid_int = max(1, _TCPHandler._sproto_read_int(uid, 1000001))
            role_name_s = _sanitize_display_name(role_name, f"Player{uid_int}")

            def _enqueue() -> None:
                if _chat_bootstrap_is_done(uid_int):
                    return
                try:
                    frame = _sproto_build_push_frame(
                        104,
                        [
                            (0, 0),          # errorcode
                            (1, uid_int),    # uid
                            (2, role_name_s) # name
                        ],
                    )
                except Exception as exc:
                    import traceback; traceback.print_exc()
                    _append_utf8_log(f"[TCP] force_set_player_info_hint failed: {exc}")
                    return

                _TCPHandler._queue_pending_push(uid_int, (frame, "sproto-force-set-player-info-hint"))
                _append_utf8_log(
                    "[TCP] force_set_player_info_hint queued "
                    f"uid={uid_int} attempt={attempt} delay={delay_s} reason={reason}"
                )

            if delay_s <= 0:
                _enqueue()
                return

            timer = threading.Timer(delay_s, _enqueue)
            timer.daemon = True
            timer.start()

        # ── Sproto response builder ──────────────────────────────────────
        def _try_build_sproto_response(self, frame: bytes) -> list[tuple[bytes, str]] | None:
            """Decode a sproto frame and build appropriate response(s).

            Returns list of (frame_bytes, tag_string) to send sequentially,
            or None if this frame cannot be handled.
            """
            if not _HAS_SPROTO:
                return None
            if len(frame) < 4:
                return None

            payload_len = int.from_bytes(frame[:2], "big")
            packed = frame[2 : 2 + payload_len]
            if len(packed) < 2:
                return None

            try:
                unpacked = _sproto_unpack(packed)
                header_fields, header_size = _sproto_decode_fields(unpacked, 0)
            except Exception:
                return None

            msg_type = header_fields.get(0)
            session = header_fields.get(1)

            if session is None or msg_type is None:
                return None

            try:
                services.chat.record_player_activity(self._session_uid())
            except Exception:
                pass

            # ── Parse request body (after header) ──────────────────────
            req_body = {}
            try:
                req_body, _ = _sproto_decode_fields(unpacked, header_size)
            except Exception:
                pass

            self_uid = self._session_uid()
            if self_uid == _safe_int(_player_data.get("uid"), 1000001):
                pd = _player_data
            else:
                pd = _online_ensure_profile(self_uid)
            extra_pushes: list[tuple[bytes, str]] = []  # additional push frames
            pending_pushes = _TCPHandler._drain_pending_pushes(self_uid)
            if pending_pushes:
                extra_pushes.extend(pending_pushes)
                _append_utf8_log(f"[TCP] drained_pending_pushes uid={self_uid} count={len(pending_pushes)}")

            if msg_type == 7:
                _TCPHandler._room_remove_player(self_uid)
                _TCPHandler._team_remove_member(self_uid)
                _append_utf8_log(f"[TCP] hall_logout accepted uid={self_uid} (room & team removed)")
                body = None
                tag = "sproto-hall-logout-noop"
            elif msg_type == 8:
                body = [(0, int(time.time()))]
                tag = "sproto-hall-hello-resp"
            elif msg_type == 9:
                account = _TCPHandler._sproto_read_text(req_body.get(0), "").strip()
                uid = self_uid
                parsed_account_uid = 0
                if account:
                    if account.isdigit() and int(account) >= 1000001:
                        parsed_account_uid = int(account)
                    else:
                        for u_str, u_pd in _player_data.storage.items():
                            if str(u_pd.get("name", "")).strip().lower() == account.lower():
                                parsed_account_uid = int(u_str)
                                break
                    if parsed_account_uid == 0:
                        parsed_account_uid = _get_or_create_uid_for_account(account)
                
                if parsed_account_uid > 0:
                    uid = self._set_session_uid(parsed_account_uid, pd, reason="hall_gen_token.account")
                    if account and not account.startswith("game-") and not account.isdigit():
                        player_pd = _online_ensure_profile(uid)
                        current_name = player_pd.get("name")
                        if not current_name or str(current_name).startswith("Player"):
                            player_pd["name"] = account
                            if uid == _safe_int(_player_data.get("uid")):
                                _player_data["name"] = account
                                _save_player_data()
                else:
                    uid = self._set_session_uid(uid, pd, reason="hall_gen_token.default")
                if not account:
                    account = str(uid)
                token = f"local-{uid}-{abs(hash((account, uid))) & 0xFFFFFFFF:08x}"
                _gp_bind_token_player(token, uid)
                body = [
                    (0, 0),
                    (1, token),
                ]
                tag = "sproto-hall-gen-token-resp"
                _append_utf8_log(f"[TCP] hall_gen_token account={account!r} uid={uid}")
            elif msg_type == 10:
                # hall_login -> response: code=0, account=uid_string
                login_token = _TCPHandler._sproto_read_text(req_body.get(0), "").strip()
                if login_token:
                    mapped_uid = _gp_player_id_from_token(login_token)
                    if mapped_uid:
                        self_uid = self._set_session_uid(mapped_uid, pd, reason="hall_login.token")
                    else:
                        try:
                            direct_uid = int(login_token)
                        except ValueError:
                            direct_uid = _get_or_create_uid_for_account(login_token)
                        if direct_uid > 0:
                            self_uid = self._set_session_uid(direct_uid, pd, reason="hall_login.direct")
                body = [(0, 0), (1, str(self._session_uid(pd)))]
                tag = "sproto-hall-login-resp"
                force_set_player_info_hint_enabled = _env_truthy("CHAT_FORCE_SET_PLAYER_INFO_HINT", "1")
                if force_set_player_info_hint_enabled:
                    role_uid = self._session_uid(pd)
                    role_pd = self._build_query_role_profile_pd(pd, role_uid)
                    role_name = _sanitize_display_name(role_pd.get("name"), f"Player{role_uid}")
                    try:
                        set_player_info_hint_push = _sproto_build_push_frame(
                            104,
                            [
                                (0, 0),         # errorcode
                                (1, role_uid),  # uid
                                (2, role_name), # name
                            ],
                        )
                        extra_pushes.append((set_player_info_hint_push, "sproto-force-set-player-info-hint-hall-login"))
                        print(_console_safe(f"[TCP] force_set_player_info_hint on hall_login uid={role_uid} name={role_name!r}"))
                        _append_utf8_log(f"[TCP] force_set_player_info_hint on hall_login uid={role_uid} name={role_name!r}")
                    except Exception as exc:
                        import traceback; traceback.print_exc()
                        _append_utf8_log(f"[TCP] force_set_player_info_hint hall_login failed: {exc}")
            elif msg_type == 11:
                _TCPHandler._room_remove_player(self_uid)
                _TCPHandler._team_remove_member(self_uid)
                _append_utf8_log(f"[TCP] hall_leave_game accepted uid={self_uid} (room & team removed)")
                body = None
                tag = "sproto-hall-leave-game-noop"
            elif msg_type == 12:
                remote_addr = _TCPHandler._sproto_read_text(req_body.get(0), "").strip()
                local_addr = _TCPHandler._sproto_read_text(req_body.get(1), "").strip()
                _invite_state["last_remote_addr"] = remote_addr
                _invite_state["last_local_addr"] = local_addr
                _append_utf8_log(
                    "[TCP] hall_report_remote_addr "
                    f"remote={remote_addr!r} local={local_addr!r}"
                )
                body = None
                tag = "sproto-hall-report-remote-addr-noop"
            elif msg_type == 101:
                # client_hello -> response: timestamp
                import time as _t
                body = [(0, int(_t.time()))]
                tag = "sproto-client-hello-resp"
                gs = _game_state
                if bool(gs.get("_restart_prebattle_bootstrap_pending", False)):
                    mode_id = _TCPHandler._sproto_read_int(gs.get("mode_id"), 0)
                    in_battle = bool(gs.get("in_battle", False))
                    if mode_id == 3 and not in_battle:
                        gs["prebattle_room_started"] = True
                        gs["prebattle_flow_active"] = True
                        gs["prebattle_stage"] = 1
                        gs["_prebattle_loadout_seeded"] = False
                        gs["_prebattle_choose_character_pushed"] = False
                        gs["_confirm_sent"] = False
                        # Restart flow can skip explicit ReqConfirmBattle in some
                        # client branches; arm deferred-confirm fallback so stage=4
                        # can still auto-push battle_info.
                        gs["_confirm_pending"] = True
                        gs["_last_confirm_push_ts"] = 0.0
                        gs["spawn_region_id"] = _TCPHandler._resolve_spawn_region(gs, gs.get("spawn_region_id"))
                        gs["region_id"] = _TCPHandler._resolve_spawn_region(
                            gs,
                            gs.get("region_id", gs.get("spawn_region_id")),
                        )
                        _TCPHandler._ensure_character_selection_for_camp(gs)
                        _persist_training_profile(save=True)
                        extra_pushes.append((self._build_room_start_push(gs), "sproto-push-room-start-restart-bootstrap"))
                        _TCPHandler._append_prebattle_info_push(
                            extra_pushes,
                            gs,
                            _player_data,
                            tag="sproto-push-pre-battle-info-restart-bootstrap",
                        )
                        _append_utf8_log(
                            "[TCP] restart bootstrap: pushed room_start+prebattle_info "
                            f"camp={_TCPHandler._sproto_read_int(gs.get('camp'), 1)} "
                            f"region={_TCPHandler._sproto_read_int(gs.get('region_id'), 0)}"
                        )
                    else:
                        _append_utf8_log(
                            "[TCP] restart bootstrap skipped "
                            f"mode_id={mode_id} in_battle={1 if in_battle else 0}"
                        )
                    gs["_restart_prebattle_bootstrap_pending"] = False
            elif msg_type == 102:
                # client_ping -> empty response
                body = None
                tag = "sproto-ping-resp"
            elif msg_type == 103:
                # client_load_role -> response: errorcode=0, uid, role{...}
                role_uid = self._session_uid(pd)
                role_pd = self._build_query_role_profile_pd(pd, role_uid)
                body, tag = self._build_load_role_response(role_pd)
                extra_pushes.extend(self._build_money_pushes(role_pd))
                force_set_player_info_hint_enabled = _env_truthy("CHAT_FORCE_SET_PLAYER_INFO_HINT", "1")
                # Chat bootstrap fallback:
                # In some client paths SDKHelper.SetPlayerInfo() is not executed reliably,
                # so holo token fetch/chat login never starts. Emit a lightweight
                # create_role-style push once per TCP session to trigger the same
                # GangplankSetPlayerInfo flow on client side.
                if force_set_player_info_hint_enabled and not getattr(self, "_sent_set_player_info_hint", False):
                    role_name = _sanitize_display_name(
                        role_pd.get("name"),
                        f"Player{role_uid}",
                    )
                    try:
                        set_player_info_hint_push = _sproto_build_push_frame(
                            104,
                            [
                                (0, 0),         # errorcode
                                (1, role_uid),  # uid
                                (2, role_name), # name
                            ],
                        )
                        extra_pushes.append((set_player_info_hint_push, "sproto-force-set-player-info-hint"))
                        self._sent_set_player_info_hint = True
                        print(_console_safe(f"[TCP] force_set_player_info_hint uid={role_uid} name={role_name!r}"))
                        _append_utf8_log(
                            "[TCP] force_set_player_info_hint "
                            f"uid={role_uid} name={role_name!r}"
                        )
                    except Exception as exc:
                        import traceback; traceback.print_exc()
                    for delay_s in _CHAT_BOOTSTRAP_HINT_DELAYS:
                        _TCPHandler._schedule_force_set_player_info_hint(
                            role_uid,
                            role_name,
                            delay_s,
                            reason=f"load_role_delay_{delay_s}",
                        )
                    self._sent_set_player_info_hint = True
                elif not force_set_player_info_hint_enabled and not getattr(self, "_logged_set_player_info_hint_disabled", False):
                    _append_utf8_log(
                        "[TCP] force_set_player_info_hint disabled "
                        "(set CHAT_FORCE_SET_PLAYER_INFO_HINT=1 to enable)"
                    )
                    self._logged_set_player_info_hint_disabled = True
                force_lobby_reenter_hint_enabled = _env_truthy("CHAT_FORCE_LOBBY_REENTER_HINT", "0")
                # Lobby re-enter fallback:
                # Keep disabled by default because it can perturb client FSM timing.
                if force_lobby_reenter_hint_enabled and not getattr(self, "_sent_force_lobby_reenter_hint", False):
                    try:
                        force_lobby_push = _sproto_build_push_frame(418, [(_TAG_TEAM_RETURN_HALL_RESP_ERRORCODE, 0)])
                        extra_pushes.append((force_lobby_push, "sproto-force-lobby-reenter-hint"))
                        self._sent_force_lobby_reenter_hint = True
                        _append_utf8_log("[TCP] force_lobby_reenter_hint via team.return_hall_req")
                    except Exception as exc:
                        import traceback; traceback.print_exc()
                        _append_utf8_log(f"[TCP] force_lobby_reenter_hint failed: {exc}")
                elif not force_lobby_reenter_hint_enabled and not getattr(self, "_logged_force_lobby_reenter_hint_disabled", False):
                    _append_utf8_log(
                        "[TCP] force_lobby_reenter_hint disabled "
                        "(set CHAT_FORCE_LOBBY_REENTER_HINT=1 to enable)"
                    )
                    self._logged_force_lobby_reenter_hint_disabled = True
            elif msg_type == 104:
                # client_create_role -> request: name(0), icon_url(1)
                #                   -> response: errorcode(0), uid(1), name(2)
                session_uid = self._session_uid(pd)
                req_name_raw = req_body.get(0, "Player")
                if isinstance(req_name_raw, bytes):
                    req_name_raw = req_name_raw.decode("utf-8", errors="replace")
                req_name = _sanitize_display_name(
                    req_name_raw,
                    f"Player{session_uid}",
                )
                req_icon_url = req_body.get(1, "")
                if isinstance(req_icon_url, bytes):
                    req_icon_url = req_icon_url.decode("utf-8", errors="replace")
                local_uid = max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))
                if session_uid == local_uid:
                    pd["name"] = req_name
                    if req_icon_url:
                        pd["icon_url"] = req_icon_url
                    _save_player_data()
                update_fields: dict[str, object] = {"name": req_name}
                if req_icon_url:
                    update_fields["icon_url"] = req_icon_url
                _online_update_profile(
                    session_uid,
                    local_pd=pd if session_uid == local_uid else None,
                    fields=update_fields,
                )
                body = [(0, 0), (1, session_uid), (2, req_name)]
                tag = "sproto-create-role-resp"
                _log_line = f"[TCP] create_role: uid={session_uid} name={req_name!r}"
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
            elif msg_type == 105:
                # client_change_name -> request: name(0)
                #                    -> response: errorcode(0), name(1)
                session_uid = self._session_uid(pd)
                req_name_raw = req_body.get(0, pd["name"])
                if isinstance(req_name_raw, bytes):
                    req_name_raw = req_name_raw.decode("utf-8", errors="replace")
                req_name = _sanitize_display_name(
                    req_name_raw,
                    f"Player{session_uid}",
                )
                local_uid = max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))
                if session_uid == local_uid:
                    pd["name"] = req_name
                    _save_player_data()
                _online_update_profile(
                    session_uid,
                    local_pd=pd if session_uid == local_uid else None,
                    fields={"name": req_name},
                )
                body = [(0, 0), (1, req_name)]
                tag = "sproto-change-name-resp"
                _log_line = f"[TCP] change_name: uid={session_uid} name={req_name!r}"
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
            elif msg_type == 106:
                # client_gm
                gm_cmd = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_GM_REQ_CMD),
                    "",
                ).strip()
                if len(gm_cmd) > 512:
                    gm_cmd = gm_cmd[:512]
                gm_ok = bool(_LOBBY_GM_ENABLED and gm_cmd)
                gm_info = "ok" if gm_ok else "gm disabled on private server"
                body = [
                    (_TAG_CLIENT_GM_RESP_SUCCEED, gm_ok),
                    (_TAG_CLIENT_GM_RESP_INFO, gm_info),
                ]
                tag = "sproto-gm-resp"
                _append_utf8_log(
                    "[TCP] gm_req "
                    f"enabled={1 if _LOBBY_GM_ENABLED else 0} "
                    f"cmd_len={len(gm_cmd)} succeed={1 if gm_ok else 0}"
                )
            elif msg_type == 108:
                # client_query_role -> response: errorcode(0), uid(1), role(2)
                req_uid = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_CLIENT_QUERY_ROLE_REQ_UID),
                    self._session_uid(pd),
                )
                profile_pd = self._build_query_role_profile_pd(pd, req_uid)
                body, tag = self._build_query_role_response(profile_pd)
            elif msg_type == 109:
                # client_change_icon
                icon = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_CHANGE_ICON_REQ_ICON),
                        _TCPHandler._sproto_read_int(pd.get("icon"), 0),
                    ),
                )
                pd["icon"] = icon
                _save_player_data()
                body = [
                    (_TAG_CLIENT_CHANGE_ICON_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_CHANGE_ICON_RESP_ICON, icon),
                ]
                tag = "sproto-change-icon-resp"
                _append_utf8_log(f"[TCP] change_icon icon={icon}")
            elif msg_type == 110:
                # client_notify_unlock_msg -> response: errorcode(0), unlock_characters(1)
                body = [(_TAG_NOTIFY_UNLOCK_ERRORCODE, 0)]
                if _SEND_UNLOCK_CHARACTERS:
                    unlock_entries: list[bytes] = []
                    for character_id in _TCPHandler._collect_unlocked_character_ids()[:512]:
                        unlock_entries.append(_encode_select_character_info(
                            character_id,
                            unlock_time=0,
                            limit_time=0,
                        ))
                    if unlock_entries:
                        body.append((_TAG_NOTIFY_UNLOCK_CHARACTERS, _TCPHandler._sproto_build_struct_list(unlock_entries)))
                tag = "sproto-notify-unlock-msg-resp"

            elif msg_type == 117:
                # client_update_event_stat_notify is a server->client notify contract.
                # If client sends it, acknowledge and ignore without state mutation.
                event_type = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_UPDATE_EVENT_STAT_REQ_EVENT_TYPE),
                    "",
                ).strip()
                stat_type = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_UPDATE_EVENT_STAT_REQ_TYPE),
                    "",
                ).strip()
                stat_value = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_UPDATE_EVENT_STAT_REQ_VALUE),
                        0,
                    ),
                )
                body = None
                tag = "sproto-update-event-stat-client-noop"
                _append_utf8_log(
                    "[TCP] update_event_stat_from_client ignored "
                    f"event_type={event_type!r} type={stat_type!r} value={stat_value}"
                )

            elif msg_type == 118:
                # client_get_rank_award_req
                # Private-server stage-1 policy: no rank award payout, but schema-correct success response.
                rank_id = _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_GET_RANK_AWARD_REQ_RANK_ID), 0)
                body = [
                    (_TAG_CLIENT_GET_RANK_AWARD_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_GET_RANK_AWARD_RESP_REWARD_ID, 0),
                    (_TAG_CLIENT_GET_RANK_AWARD_RESP_REWARD_NUM, 0),
                ]
                tag = "sproto-get-rank-award-resp"
                _append_utf8_log(f"[TCP] get_rank_award rank_id={rank_id} reward=0")

            elif msg_type == 119:
                # client_get_skins_req -> response: skins(0), char_skins(1)
                # NOTE: Zero-length list payloads decode to nil in this client path,
                # which later crashes Lua WarehouseData on msg.char_skins access.
                # Build a minimal non-empty nested payload to keep list objects alive.
                owned_skin_counts = _TCPHandler._collect_owned_skin_counts()
                skin_entries: list[bytes] = []
                for skin_id in sorted(owned_skin_counts.keys())[:800]:
                    skin_num = max(1, _TCPHandler._sproto_read_int(owned_skin_counts.get(skin_id), 1))
                    skin_entries.append(_sproto_encode_fields([
                        (0, skin_id),     # id
                        (1, 0),           # timestamp
                        (2, False),       # new_flag
                        (3, skin_num),    # num
                    ]))

                body: list[tuple[int, object]] = []
                if skin_entries:
                    skins_list = _TCPHandler._sproto_build_struct_list(skin_entries)
                    body.append((0, skins_list))

                # client.CharacterSkin { id(0), char_skins(1:list<long>), weapon_skins(2:list<WeaponSkin>) }
                character_skin_entries: list[bytes] = []
                unlocked_character_ids = _TCPHandler._collect_unlocked_character_ids()[:512]
                if not unlocked_character_ids:
                    unlocked_character_ids = [1]

                for character_id in unlocked_character_ids:
                    selected_char_skins = _TCPHandler._get_selected_char_skins(character_id)
                    if not selected_char_skins:
                        selected_char_skins = _TCPHandler._default_character_skin_ids(character_id)
                    selected_char_skins = _TCPHandler._normalize_character_skin_ids(character_id, selected_char_skins)
                    char_skin_payload = _TCPHandler._sproto_build_integer_list(selected_char_skins[:16])

                    weapon_skin_entries: list[bytes] = []
                    selected_weapon_skins = _TCPHandler._get_selected_weapon_skins(character_id)
                    for weapon_id in sorted(selected_weapon_skins.keys())[:64]:
                        selected_skin_ids = selected_weapon_skins.get(weapon_id) or []
                        selected_skin_ids = [sid for sid in selected_skin_ids if sid > 0][:8]
                        if not selected_skin_ids:
                            continue
                        weapon_skin_entries.append(_sproto_encode_fields([
                            (0, weapon_id),
                            # client.WeaponSkin.decode reads skins on tag=2 (not tag=1).
                            (2, _TCPHandler._sproto_build_integer_list(selected_skin_ids)),
                        ]))
                    weapon_skin_payload = _TCPHandler._sproto_build_struct_list(weapon_skin_entries)

                    character_skin_entries.append(_sproto_encode_fields([
                        (0, character_id),
                        (1, char_skin_payload),
                        (2, weapon_skin_payload),
                    ]))
                char_skins_list = _TCPHandler._sproto_build_struct_list(character_skin_entries)

                body.append((1, char_skins_list))
                tag = "sproto-get-skins-resp"

            elif msg_type == 120:
                # client.use_skin
                # request: skin_id(0), char_id(1), prop_id(2)
                # response: skin_id(0), result(1)
                gs = _game_state
                skin_id = _TCPHandler._sproto_read_int(req_body.get(0), 0)
                char_id = _TCPHandler._sproto_read_int(req_body.get(1), 0)
                prop_id = _TCPHandler._sproto_read_int(req_body.get(2), -1)
                if char_id <= 0:
                    char_id = _TCPHandler._sproto_read_int(gs.get("character_id"), 1)

                ok = False
                if prop_id < 0:
                    ok = _TCPHandler._apply_selected_character_skin(char_id, skin_id)
                else:
                    ok = _TCPHandler._apply_selected_weapon_skin(char_id, prop_id, skin_id)
                    current_char = _TCPHandler._sproto_read_int(gs.get("character_id"), 0)
                    if ok and current_char == char_id:
                        primary_weapon = gs.get("primary_weapon")
                        if not isinstance(primary_weapon, dict):
                            primary_weapon = {}
                            gs["primary_weapon"] = primary_weapon
                        secondary_weapon = gs.get("secondary_weapon")
                        if not isinstance(secondary_weapon, dict):
                            secondary_weapon = {}
                            gs["secondary_weapon"] = secondary_weapon
                        if _TCPHandler._sproto_read_int(primary_weapon.get("id"), 0) == prop_id:
                            primary_weapon["skin"] = skin_id
                        elif _TCPHandler._sproto_read_int(secondary_weapon.get("id"), 0) == prop_id:
                            secondary_weapon["skin"] = skin_id

                if ok:
                    _save_player_data()
                body = [(0, skin_id), (1, bool(ok))]
                tag = "sproto-use-skin-resp"
            elif msg_type == 121:
                # client_add_skin
                # request: skin_id(0)
                # response: skin_id(0), result(1)
                skin_id = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_ADD_SKIN_REQ_SKIN_ID),
                        0,
                    ),
                )
                bag_id = _TCPHandler._sproto_read_int(_SKIN_ID_TO_BAG_ID.get(skin_id), 0)
                added = False
                if skin_id > 0 and bag_id > 0:
                    _TCPHandler._register_owned_store_item(bag_id, 1)
                    skin_counts = _TCPHandler._collect_owned_skin_counts()
                    new_count = max(1, _TCPHandler._sproto_read_int(skin_counts.get(skin_id), 1))
                    skin_push = _TCPHandler._build_skin_update_push({skin_id: new_count})
                    if skin_push is not None:
                        extra_pushes.append(skin_push)
                    _save_player_data()
                    added = True

                body = [
                    (_TAG_CLIENT_ADD_SKIN_RESP_SKIN_ID, skin_id),
                    (_TAG_CLIENT_ADD_SKIN_RESP_RESULT, bool(added)),
                ]
                tag = "sproto-add-skin-resp"
                _append_utf8_log(
                    "[TCP] add_skin "
                    f"skin_id={skin_id} bag_id={bag_id} result={1 if added else 0}"
                )
            elif msg_type == 130:
                # client_change_icon_frame
                icon_frame = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_CHANGE_ICON_FRAME_REQ_ICON_FRAME),
                        _TCPHandler._sproto_read_int(pd.get("icon_frame"), 0),
                    ),
                )
                pd["icon_frame"] = icon_frame
                _save_player_data()
                body = [
                    (_TAG_CLIENT_CHANGE_ICON_FRAME_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_CHANGE_ICON_FRAME_RESP_ICON_FRAME, icon_frame),
                ]
                tag = "sproto-change-icon-frame-resp"
                _append_utf8_log(f"[TCP] change_icon_frame icon_frame={icon_frame}")

            elif msg_type == 131:
                # client.change_show_character
                # request: character_id(0)
                # response: errorcode(0), character_id(1)
                requested_character_id = _TCPHandler._sproto_read_int(req_body.get(0), 0)
                errorcode = 0
                if requested_character_id <= 0:
                    errorcode = 1
                    character_id = _TCPHandler._get_show_character_id(0)
                else:
                    resolved_character_id, _ = _TCPHandler._build_character_skin_struct_with_id(
                        requested_character_id
                    )
                    character_id = max(1, resolved_character_id)
                    if character_id != requested_character_id:
                        _append_utf8_log(
                            "[TCP] change_show_character remapped "
                            f"requested={requested_character_id} resolved={character_id}"
                        )
                    _TCPHandler._set_show_character_id(character_id)
                    _save_player_data()
                body = [(0, errorcode), (1, character_id)]
                tag = "sproto-change-show-character-resp"

            elif msg_type == 156:
                # client.use_skin_to_weapons
                # request: skin_id(0), targets(1:list<WeaponSkinTarget{char_id,weapon_id}>)
                # response: skin_id(0), failed_targets(1:list<WeaponSkinTarget>)
                skin_id = _TCPHandler._sproto_read_int(req_body.get(0), 0)
                targets = _TCPHandler._sproto_parse_struct_list(req_body.get(1))
                failed_entries: list[bytes] = []
                had_success = False
                for target in targets:
                    if not isinstance(target, dict):
                        continue
                    char_id = _TCPHandler._sproto_read_int(target.get(0), 0)
                    weapon_id = _TCPHandler._sproto_read_int(target.get(1), 0)
                    if not _TCPHandler._apply_selected_weapon_skin(char_id, weapon_id, skin_id):
                        failed_entries.append(_sproto_encode_fields([
                            (0, char_id),
                            (1, weapon_id),
                        ]))
                    else:
                        had_success = True
                if had_success:
                    _save_player_data()
                failed_payload = _TCPHandler._sproto_build_struct_list(failed_entries)
                body = [(0, skin_id), (1, failed_payload)]
                tag = "sproto-use-skin-to-weapons-resp"

            elif msg_type == 111:
                # client_update_client_config_req
                # request: key(0 string), value(1 long)
                # response: errorcode(0), key(1), value(2)
                cfg_key = req_body.get(0, "")
                if isinstance(cfg_key, bytes):
                    cfg_key = cfg_key.decode("utf-8", errors="replace")
                cfg_val = req_body.get(1, 0)
                if isinstance(cfg_val, bytes):
                    cfg_val = int.from_bytes(cfg_val, "little", signed=True) if cfg_val else 0
                _client_config[cfg_key] = cfg_val
                _save_player_data()
                body = [(0, 0), (1, cfg_key), (2, cfg_val)]
                tag = "sproto-update-client-config-resp"
                _log_line = f"[TCP] update_client_config: {cfg_key}={cfg_val}"
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
            elif msg_type == 112:
                # client_change_icon_url
                icon_url = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_CHANGE_ICON_URL_REQ_ICON_URL),
                    _TCPHandler._sproto_read_text(pd.get("icon_url"), ""),
                ).strip()
                if len(icon_url) > 512:
                    icon_url = icon_url[:512]
                pd["icon_url"] = icon_url
                _save_player_data()
                body = [
                    (_TAG_CLIENT_CHANGE_ICON_URL_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_CHANGE_ICON_URL_RESP_ICON_URL, icon_url),
                ]
                tag = "sproto-change-icon-url-resp"
                _append_utf8_log(f"[TCP] change_icon_url len={len(icon_url)}")
            elif msg_type == 113:
                # client_update_money is a server->client notify contract.
                # If client sends it, acknowledge and keep server wallet authoritative.
                money_type = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_UPDATE_MONEY_REQ_TYPE),
                    "",
                ).strip()
                money_value = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_UPDATE_MONEY_REQ_VALUE),
                        0,
                    ),
                )
                body = None
                tag = "sproto-update-money-client-noop"
                _append_utf8_log(
                    "[TCP] update_money_from_client ignored "
                    f"type={money_type!r} value={money_value}"
                )

            elif msg_type == 114:
                # client_get_store_items_req
                # request: store_type(0)
                # response: errorcode(0), store_type(1), items(2:list<long>)
                store_type = _TCPHandler._sproto_read_int(req_body.get(0), _STORE_TYPE_CHARACTER)
                if store_type <= 0:
                    store_type = _STORE_TYPE_CHARACTER

                item_ids = _TCPHandler._default_store_items_for_type(store_type)
                purchase_history = _store_state.get("purchase_history")
                if not isinstance(purchase_history, dict):
                    purchase_history = {}
                    _store_state["purchase_history"] = purchase_history

                # Keep repeatable tabs stable; hiding purchased entries in agent tab causes
                # client cards without matching server prices.
                if store_type not in (
                    _STORE_TYPE_CHARACTER,
                    _STORE_TYPE_SUIT,
                    _STORE_TYPE_WEAPON_PT,
                    _STORE_TYPE_WEAPON_GJ,
                    _STORE_TYPE_BUNDLE,
                    _STORE_TYPE_BOX,
                ):
                    item_ids = [
                        item_id
                        for item_id in item_ids
                        if _TCPHandler._sproto_read_int(purchase_history.get(str(item_id)), 0) <= 0
                    ]

                items_list = _TCPHandler._sproto_build_integer_list(item_ids)
                body = [
                    (0, 0),
                    (1, store_type),
                    (2, items_list),
                ]
                # Lua price cache is global and keyed by item id.
                # Push prices for the requested tab so agent/sale entries are populated
                # even when client does not call msg157 explicitly.
                served_price_store_type = store_type
                price_items = _TCPHandler._build_item_price_entries_for_store_type(served_price_store_type)
                if not price_items and served_price_store_type != _STORE_TYPE_BUNDLE:
                    fallback_price_items = _TCPHandler._build_item_price_entries_for_store_type(_STORE_TYPE_BUNDLE)
                    if fallback_price_items:
                        price_items = fallback_price_items
                        served_price_store_type = _STORE_TYPE_BUNDLE

                if price_items:
                    item_prices = _TCPHandler._sproto_build_struct_list(price_items)
                    extra_pushes.append((
                        _sproto_build_push_frame(157, [
                            (0, served_price_store_type),
                            (1, item_prices),
                        ]),
                        "sproto-push-notify-item-prices",
                    ))
                    _append_utf8_log(
                        f"[TCP] push_item_prices from_store_items req_store_type={store_type} served_store_type={served_price_store_type} count={len(price_items)}"
                    )
                tag = "sproto-get-store-items-resp"
                _append_utf8_log(f"[TCP] store_items type={store_type} ids={item_ids}")

            elif msg_type == 115:
                # client_buy_store_item
                # request: item_id(0), money_type(1), item_id_type(2), not_discount_store(3)
                # response: errorcode(0), item_id(1), item_id_type(2)
                item_id = _TCPHandler._sproto_read_int(req_body.get(0), 900230020)
                money_type_raw = req_body.get(1)
                money_type_text = _TCPHandler._sproto_read_text(money_type_raw, "")
                money_type_num = _TCPHandler._sproto_read_int(money_type_raw, -1)
                item_id_type = _TCPHandler._sproto_read_int(req_body.get(2), 0)
                not_discount_store = _TCPHandler._sproto_read_int(req_body.get(3), 0) > 0
                if item_id_type not in (0, 1):
                    item_id_type = 0

                use_gold = False
                mt = money_type_text.strip().lower()
                if mt in ("gold", "coin", "2"):
                    use_gold = True
                elif mt in ("diamond", "gem", "1"):
                    use_gold = False
                elif money_type_num == 2:
                    use_gold = True
                elif money_type_num == 1:
                    use_gold = False

                if use_gold:
                    pd["gold"] = max(0, _TCPHandler._sproto_read_int(pd.get("gold"), _DEFAULT_GOLD) - _DEFAULT_STORE_GOLD_COST)
                else:
                    pd["diamond"] = max(0, _TCPHandler._sproto_read_int(pd.get("diamond"), _DEFAULT_DIAMOND) - _DEFAULT_STORE_DIAMOND_COST)

                store_type_for_item = _STORE_ITEM_TO_TYPE.get(item_id, 0)
                purchase_history = _store_state.get("purchase_history")
                if not isinstance(purchase_history, dict):
                    purchase_history = {}
                    _store_state["purchase_history"] = purchase_history
                if store_type_for_item != _STORE_TYPE_BOX:
                    purchase_history[str(item_id)] = max(
                        1,
                        _TCPHandler._sproto_read_int(purchase_history.get(str(item_id)), 0) + 1,
                    )
                is_paid_box_open = not_discount_store and store_type_for_item == _STORE_TYPE_BOX

                # Legacy bug guard: paid chest-open request must not increase free-box inventory.
                if not is_paid_box_open:
                    _TCPHandler._register_owned_store_item(item_id, 1)
                    _TCPHandler._append_box_event_pushes(
                        extra_pushes,
                        item_id,
                        include_type_box=True,
                    )

                bag_type_for_item = _TCPHandler._sproto_read_int(_BAG_TYPE_BY_ID.get(item_id), 0)
                if (not not_discount_store) and bag_type_for_item == _BAG_TYPE_GIFT_BOX:
                    bundle_content_ids = _BUNDLE_ID_TO_CONTENT_IDS.get(item_id, [])
                    if isinstance(bundle_content_ids, list) and bundle_content_ids:
                        reward_counts: dict[int, int] = {}
                        changed_skin_counts: dict[int, int] = {}
                        for content_bag_id_raw in bundle_content_ids:
                            content_bag_id = _TCPHandler._sproto_read_int(content_bag_id_raw, 0)
                            if content_bag_id <= 0:
                                continue
                            reward_counts[content_bag_id] = reward_counts.get(content_bag_id, 0) + 1
                            _TCPHandler._register_owned_store_item(content_bag_id, 1)

                            skin_ids = _BAG_TO_SKIN_IDS.get(content_bag_id)
                            if isinstance(skin_ids, list):
                                current_skin_counts = _TCPHandler._collect_owned_skin_counts()
                                for sid_raw in skin_ids:
                                    sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                                    if sid > 0:
                                        changed_skin_counts[sid] = current_skin_counts.get(sid, 1)

                        if reward_counts:
                            reward_entries = [
                                _sproto_encode_fields([
                                    (0, reward_id),
                                    (1, reward_num),
                                ])
                                for reward_id, reward_num in sorted(reward_counts.items())
                            ]
                            reward_list = _TCPHandler._sproto_build_struct_list(reward_entries)
                            extra_pushes.append((
                                _sproto_build_push_frame(141, [
                                    (0, reward_list),
                                    (1, 1),
                                ]),
                                "sproto-push-get-reward-notify",
                            ))

                        skin_push = _TCPHandler._build_skin_update_push(changed_skin_counts)
                        if skin_push is not None:
                            extra_pushes.append(skin_push)

                skin_ids = _BAG_TO_SKIN_IDS.get(item_id)
                if isinstance(skin_ids, list) and skin_ids:
                    skin_counts = _TCPHandler._collect_owned_skin_counts()
                    changed_skin_counts: dict[int, int] = {}
                    for skin_id_raw in skin_ids:
                        skin_id = _TCPHandler._sproto_read_int(skin_id_raw, 0)
                        if skin_id > 0:
                            changed_skin_counts[skin_id] = skin_counts.get(skin_id, 1)
                    skin_push = _TCPHandler._build_skin_update_push(changed_skin_counts)
                    if skin_push is not None:
                        extra_pushes.append(skin_push)

                _save_player_data()
                body = [
                    (0, 0),
                    (1, item_id),
                    (2, item_id_type),
                ]

                if not_discount_store:
                    if store_type_for_item == _STORE_TYPE_BOX:
                        # Supplies purchase must emit reward notify to close WaitPktPanel.
                        # Use box pool reward, never the box id itself.
                        reward_ids = _TCPHandler._select_box_reward_items(item_id, 1, track_open_counter=False)
                        reward_counts: dict[int, int] = {}
                        for reward_id in reward_ids:
                            reward_counts[reward_id] = reward_counts.get(reward_id, 0) + 1

                        reward_entries: list[bytes] = []
                        changed_skin_counts: dict[int, int] = {}
                        for reward_id, reward_num in reward_counts.items():
                            reward_entries.append(_sproto_encode_fields([
                                (0, reward_id),
                                (1, reward_num),
                            ]))

                        reward_list = _TCPHandler._sproto_build_struct_list(reward_entries)
                        extra_pushes.append((
                            _sproto_build_push_frame(141, [
                                (0, reward_list),
                                (1, 1),
                            ]),
                            "sproto-push-get-reward-notify",
                        ))
                        skin_push = _TCPHandler._build_skin_update_push(changed_skin_counts)
                        if skin_push is not None:
                            extra_pushes.append(skin_push)
                    else:
                        reward_entry = _sproto_encode_fields([
                            (0, item_id),
                            (1, 1),
                        ])
                        reward_list = _TCPHandler._sproto_build_struct_list([reward_entry])
                        extra_pushes.append((
                            _sproto_build_push_frame(141, [
                                (0, reward_list),
                                (1, 1),
                            ]),
                            "sproto-push-get-reward-notify",
                        ))

                    _save_player_data()

                extra_pushes.extend(self._build_money_pushes())
                tag = "sproto-buy-store-item-resp"
                _log_line = (
                    f"[TCP] buy_store_item item_id={item_id} money_type={money_type_text!r}/{money_type_num} "
                    f"item_id_type={item_id_type} not_discount_store={1 if not_discount_store else 0} "
                    f"gold={pd.get('gold')} diamond={pd.get('diamond')}"
                )
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)

            elif msg_type == 116:
                # client_get_recharge_items
                # response: errorcode(0), items(1:list<RechargeItem>)
                recharge_item = _sproto_encode_fields([
                    (0, "com.qookka.af2.diamond.small"),
                    (1, 60),
                    (2, 0),
                    (3, 0),
                ])
                items_list = _TCPHandler._sproto_build_struct_list([recharge_item])
                body = [(0, 0), (1, items_list)]
                tag = "sproto-get-recharge-items-resp"

            elif msg_type == 140:
                # client_open_box_req
                # request: box_id(0), count(1)
                # response: errorcode(0), box_id(1), count(2)
                box_id = _TCPHandler._sproto_read_int(req_body.get(0), 20001)
                box_count = max(1, _TCPHandler._sproto_read_int(req_body.get(1), 1))

                # Consume free-box inventory if present. Paid open path (115) does not use this bucket.
                _TCPHandler._consume_box_inventory(box_id, box_count)

                body = [
                    (0, 0),
                    (1, box_id),
                    (2, box_count),
                ]

                reward_ids = _TCPHandler._select_box_reward_items(box_id, box_count)
                _TCPHandler._append_box_event_pushes(
                    extra_pushes,
                    box_id,
                    include_type_box=True,
                    include_box_count=True,
                )
                resolved_box_id = _TCPHandler._resolve_box_id(box_id)
                is_supply_box_open = resolved_box_id in _STORE_TYPE_9_BOX_IDS
                reward_counts: dict[int, int] = {}
                for reward_id in reward_ids:
                    reward_counts[reward_id] = reward_counts.get(reward_id, 0) + 1

                reward_entries: list[bytes] = []
                changed_skin_counts: dict[int, int] = {}
                for reward_id, reward_num in reward_counts.items():
                    reward_entries.append(_sproto_encode_fields([
                        (0, reward_id),
                        (1, reward_num),
                    ]))
                    if not is_supply_box_open:
                        _TCPHandler._register_owned_store_item(reward_id, reward_num)

                        skin_ids = _BAG_TO_SKIN_IDS.get(reward_id)
                        if isinstance(skin_ids, list):
                            current_skin_counts = _TCPHandler._collect_owned_skin_counts()
                            for sid_raw in skin_ids:
                                sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                                if sid > 0:
                                    changed_skin_counts[sid] = current_skin_counts.get(sid, 1)

                reward_list = _TCPHandler._sproto_build_struct_list(reward_entries)
                extra_pushes.append((
                    _sproto_build_push_frame(141, [
                        (0, reward_list),
                        (1, 1),
                    ]),
                    "sproto-push-get-reward-notify",
                ))
                skin_push = _TCPHandler._build_skin_update_push(changed_skin_counts)
                if skin_push is not None:
                    extra_pushes.append(skin_push)
                _save_player_data()
                tag = "sproto-open-box-resp"

            elif msg_type == 141:
                # client_get_reward_notify is a server->client notify contract.
                # If client sends it, acknowledge and ignore without mutating inventory/economy.
                reward_entries = _TCPHandler._sproto_parse_struct_list(
                    req_body.get(_TAG_CLIENT_GET_REWARD_NOTIFY_REQ_REWARDS)
                )
                reward_type = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_GET_REWARD_NOTIFY_REQ_REWARD_TYPE),
                        0,
                    ),
                )
                sample_reward_id = 0
                sample_reward_num = 0
                if reward_entries:
                    first_reward = reward_entries[0]
                    sample_reward_id = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            first_reward.get(_TAG_CLIENT_COMMON_REWARD_REWARD_ID),
                            0,
                        ),
                    )
                    sample_reward_num = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            first_reward.get(_TAG_CLIENT_COMMON_REWARD_REWARD_NUM),
                            0,
                        ),
                    )
                body = None
                tag = "sproto-get-reward-notify-client-noop"
                _append_utf8_log(
                    "[TCP] get_reward_notify_from_client ignored "
                    f"reward_type={reward_type} reward_count={len(reward_entries)} "
                    f"sample={sample_reward_id}:{sample_reward_num}"
                )

            elif msg_type == 142:
                # client_update_recharge_items_notify is a server->client notify contract.
                # If client sends it, acknowledge and ignore.
                recharge_items = _TCPHandler._sproto_parse_struct_list(
                    req_body.get(_TAG_CLIENT_UPDATE_RECHARGE_ITEMS_NOTIFY_REQ_ITEMS)
                )
                sample_product = ""
                sample_base = 0
                sample_bonus = 0
                sample_is_double = 0
                if recharge_items:
                    first_item = recharge_items[0]
                    sample_product = _TCPHandler._sproto_read_text(
                        first_item.get(_TAG_CLIENT_RECHARGE_ITEM_PRODUCT_ID),
                        "",
                    )[:64]
                    sample_base = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            first_item.get(_TAG_CLIENT_RECHARGE_ITEM_BASE_CURRENCY),
                            0,
                        ),
                    )
                    sample_bonus = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            first_item.get(_TAG_CLIENT_RECHARGE_ITEM_BONUS_CURRENCY),
                            0,
                        ),
                    )
                    sample_is_double = 1 if _TCPHandler._sproto_read_int(
                        first_item.get(_TAG_CLIENT_RECHARGE_ITEM_IS_DOUBLE),
                        0,
                    ) else 0
                body = None
                tag = "sproto-update-recharge-items-client-noop"
                _append_utf8_log(
                    "[TCP] update_recharge_items_from_client ignored "
                    f"count={len(recharge_items)} sample={sample_product!r}:{sample_base}:{sample_bonus}:{sample_is_double}"
                )

            elif msg_type == 143:
                # client_activate_role_req
                # request: code(0)
                # response: errorcode(0)
                activate_code = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_ACTIVATE_ROLE_REQ_CODE),
                    "",
                ).strip()
                errorcode = 0 if activate_code else 1
                body = [
                    (_TAG_CLIENT_ACTIVATE_ROLE_RESP_ERRORCODE, errorcode),
                ]
                tag = "sproto-activate-role-resp"
                _append_utf8_log(
                    "[TCP] activate_role "
                    f"code_len={len(activate_code)} errorcode={errorcode}"
                )
            elif msg_type == 144:
                # client_get_jf_switch_req
                body = [
                    (_TAG_CLIENT_GET_JF_SWITCH_RESP_JF_SWITCH, 1 if _LOBBY_JF_SWITCH else 0),
                ]
                tag = "sproto-get-jf-switch-resp"
                _append_utf8_log(f"[TCP] get_jf_switch jf_switch={1 if _LOBBY_JF_SWITCH else 0}")

            elif msg_type == 145:
                # client_query_ad_info
                # response: errorcode(0), ad_switch(1)
                body = [
                    (_TAG_CLIENT_QUERY_AD_INFO_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_QUERY_AD_INFO_RESP_AD_SWITCH, bool(_LOBBY_AD_SWITCH)),
                ]
                tag = "sproto-query-ad-info-resp"
                _append_utf8_log(
                    f"[TCP] query_ad_info ad_switch={1 if _LOBBY_AD_SWITCH else 0}"
                )

            elif msg_type == 151:
                # client_query_recruit_info
                # response: recruit_code(0), recruiter_uid(1), recruitee_count(2)
                recruit_code = ""
                recruiter_uid = 0
                recruitee_count = 0
                if _LOBBY_RECRUIT_ENABLED:
                    recruit_code = f"UID{self._session_uid(pd)}"
                body = [
                    (_TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUIT_CODE, recruit_code),
                    (_TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUITER_UID, recruiter_uid),
                    (_TAG_CLIENT_QUERY_RECRUIT_INFO_RESP_RECRUITEE_COUNT, recruitee_count),
                ]
                tag = "sproto-query-recruit-info-resp"
                _append_utf8_log(
                    "[TCP] query_recruit_info "
                    f"enabled={1 if _LOBBY_RECRUIT_ENABLED else 0} "
                    f"code={recruit_code!r} recruiter_uid={recruiter_uid} count={recruitee_count}"
                )
            elif msg_type == 154:
                # client_skin_update_notify is a server->client push contract.
                # If client sends it, acknowledge with empty payload and ignore.
                req_num = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_CLIENT_SKIN_UPDATE_NOTIFY_REQ_NUM),
                    0,
                )
                body = None
                tag = "sproto-skin-update-notify-client-noop"
                _append_utf8_log(
                    "[TCP] skin_update_notify_from_client ignored "
                    f"num={req_num}"
                )
            elif msg_type == 155:
                # client_online_status is a server->client notify contract.
                # If client sends it, acknowledge and ignore.
                online_uid = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_ONLINE_STATUS_REQ_UID),
                        0,
                    ),
                )
                online_flag = 1 if _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_CLIENT_ONLINE_STATUS_REQ_ONLINE),
                    0,
                ) else 0
                body = None
                tag = "sproto-online-status-client-noop"
                _append_utf8_log(
                    "[TCP] online_status_from_client ignored "
                    f"uid={online_uid} online={online_flag}"
                )
            elif msg_type == 146:
                # client_recharge_success_notify is normally server push.
                # Private-server policy: ignore client-originated recharge notify (no economy mutation).
                money_type = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_RECHARGE_SUCCESS_REQ_MONEY_TYPE),
                    "",
                ).strip()
                money_value = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_RECHARGE_SUCCESS_REQ_MONEY),
                        0,
                    ),
                )
                product_id = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_RECHARGE_SUCCESS_REQ_PRUDUCT_ID),
                    "",
                ).strip()
                amount = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_RECHARGE_SUCCESS_REQ_AMOUNT),
                        0,
                    ),
                )
                attach_params = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_RECHARGE_SUCCESS_REQ_ATTACH_PARAMS),
                    "",
                )
                body = None
                tag = "sproto-recharge-success-client-noop"
                _append_utf8_log(
                    "[TCP] recharge_success_from_client ignored "
                    f"money_type={money_type!r} money={money_value} product_id={product_id!r} "
                    f"amount={amount} attach_len={len(attach_params)}"
                )

            elif msg_type == 147:
                # client_share_req
                share_type = _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_SHARE_REQ_SHARE_TYPE), 0)
                body = [
                    (_TAG_CLIENT_SHARE_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_SHARE_RESP_SHARE_TYPE, share_type),
                ]
                tag = "sproto-share-req-resp"
                _append_utf8_log(f"[TCP] share_req share_type={share_type}")

            elif msg_type == 148:
                # client_god_player_req
                rank_score = max(0, _TCPHandler._sproto_read_int(pd.get("rank_score"), 0))
                body = [
                    (_TAG_CLIENT_GOD_PLAYER_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_GOD_PLAYER_RESP_RANK, rank_score),
                ]
                tag = "sproto-god-player-req-resp"
                _append_utf8_log(
                    "[TCP] god_player_req "
                    f"rank={rank_score}"
                )

            elif msg_type == 149:
                # client_submit_recruit_code_req
                # response: errorcode(0), recruiter_uid(1), recruiter_name(2)
                submit_code = _TCPHandler._sproto_read_text(
                    req_body.get(_TAG_CLIENT_SUBMIT_RECRUIT_CODE_REQ_RECRUIT_CODE),
                    "",
                ).strip()
                # Private server policy: referral feature disabled by default.
                # Respond success-shaped with neutral values to avoid client-side flow breaks.
                errorcode = 0
                recruiter_uid = 0
                recruiter_name = "PrivateServer"
                if _LOBBY_RECRUIT_ENABLED:
                    recruiter_uid = _TCPHandler._sproto_read_int(pd.get("uid"), 0)
                    recruiter_name = _sanitize_display_name(pd.get("name"), "Player")
                body = [
                    (_TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_ERRORCODE, errorcode),
                    (_TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_RECRUITER_UID, recruiter_uid),
                    (_TAG_CLIENT_SUBMIT_RECRUIT_CODE_RESP_RECRUITER_NAME, recruiter_name),
                ]
                tag = "sproto-submit-recruit-code-resp"
                _append_utf8_log(
                    "[TCP] submit_recruit_code "
                    f"enabled={1 if _LOBBY_RECRUIT_ENABLED else 0} "
                    f"code_len={len(submit_code)} recruiter_uid={recruiter_uid}"
                )

            elif msg_type == 150:
                # client_new_guy_recruited_notify is a server->client notify contract.
                # If client sends it, acknowledge and ignore.
                recruitee_uid = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_NEW_GUY_RECRUITED_REQ_UID),
                        0,
                    ),
                )
                recruitee_name = _sanitize_display_name(
                    _TCPHandler._sproto_read_text(
                        req_body.get(_TAG_CLIENT_NEW_GUY_RECRUITED_REQ_NAME),
                        "",
                    ),
                    "Player",
                )
                body = None
                tag = "sproto-new-guy-recruited-client-noop"
                _append_utf8_log(
                    "[TCP] new_guy_recruited_from_client ignored "
                    f"uid={recruitee_uid} name={recruitee_name!r}"
                )

            elif msg_type == 158:
                # client_dismantle_skin
                # request: skins(0:list<DismantleInfo{skin_id,num}>)
                # response: success(0:list<DismantleInfo>), failed(1:list<DismantleInfo>)
                req_items = _TCPHandler._sproto_parse_struct_list(req_body.get(0))
                owned = _TCPHandler._ensure_store_counter_dict("owned_bag_items")

                success_items: list[bytes] = []
                failed_items: list[bytes] = []
                changed_skin_counts: dict[int, int] = {}
                dismantle_gold_gain = 0

                for req_item in req_items:
                    skin_id = _TCPHandler._sproto_read_int(req_item.get(0), 0)
                    dismantle_num = max(1, _TCPHandler._sproto_read_int(req_item.get(1), 1))
                    bag_id = _TCPHandler._sproto_read_int(_SKIN_ID_TO_BAG_ID.get(skin_id), 0)

                    if bag_id <= 0:
                        failed_items.append(_sproto_encode_fields([(0, skin_id), (1, dismantle_num)]))

                    cur_count = _TCPHandler._sproto_read_int(owned.get(str(bag_id)), 0)
                    if cur_count >= dismantle_num:
                        next_count = cur_count - dismantle_num
                        if next_count > 0:
                            owned[str(bag_id)] = next_count
                        else:
                            owned.pop(str(bag_id), None)

                        exchange_gold = _TCPHandler._sproto_read_int(_BAG_EXCHANGE_GOLD.get(bag_id), 0)
                        if exchange_gold > 0 and dismantle_num > 0:
                            dismantle_gold_gain += exchange_gold * dismantle_num

                        success_items.append(_sproto_encode_fields([(0, skin_id), (1, next_count)]))
                        changed_skin_counts[skin_id] = next_count
                    else:
                        failed_items.append(_sproto_encode_fields([(0, skin_id), (1, dismantle_num)]))

                if dismantle_gold_gain > 0:
                    cur_gold = max(0, _TCPHandler._sproto_read_int(pd.get("gold"), _DEFAULT_GOLD))
                    pd["gold"] = cur_gold + dismantle_gold_gain
                    extra_pushes.extend(self._build_money_pushes())

                body = [
                    (0, _TCPHandler._sproto_build_struct_list(success_items)),
                    (1, _TCPHandler._sproto_build_struct_list(failed_items)),
                ]

                skin_push = _TCPHandler._build_skin_update_push(changed_skin_counts)
                if skin_push is not None:
                    extra_pushes.append(skin_push)

                _save_player_data()
                tag = "sproto-dismantle-skin-resp"

            elif msg_type == 157:
                # client_notify_item_prices
                # request payload: store_type(0)
                # response payload: store_type(0), item_prices(1:list<ItemPrice>)
                req_store_type = _TCPHandler._sproto_read_int(req_body.get(0), _STORE_TYPE_BUNDLE)
                if req_store_type <= 0:
                    req_store_type = _STORE_TYPE_BUNDLE

                served_store_type = req_store_type
                price_items = _TCPHandler._build_item_price_entries_for_store_type(served_store_type)
                if not price_items and served_store_type != _STORE_TYPE_BUNDLE:
                    # Keep legacy behavior as fallback for clients that only handle bundle prices.
                    fallback_price_items = _TCPHandler._build_item_price_entries_for_store_type(_STORE_TYPE_BUNDLE)
                    if fallback_price_items:
                        price_items = fallback_price_items
                        served_store_type = _STORE_TYPE_BUNDLE

                item_prices = _TCPHandler._sproto_build_struct_list(price_items)
                body = [
                    (0, served_store_type),
                    (1, item_prices),
                ]
                tag = "sproto-notify-item-prices-resp"
                _append_utf8_log(
                    f"[TCP] notify_item_prices req_store_type={req_store_type} served_store_type={served_store_type} count={len(price_items)}"
                )

            elif msg_type == 153:
                # client_store_discount_info_notify is a server->client notify contract.
                # If client sends it, acknowledge and ignore to avoid mutating discount rotation state.
                fix_item_id = 0
                fix_item_discount = 0
                fix_item_bought = 0
                fix_item_raw = req_body.get(_TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_FIX_ITEM)
                if isinstance(fix_item_raw, bytes):
                    try:
                        fix_item_fields, _ = _sproto_decode_fields(fix_item_raw, 0)
                    except Exception:
                        fix_item_fields = {}
                    if isinstance(fix_item_fields, dict):
                        fix_item_id = max(
                            0,
                            _TCPHandler._sproto_read_int(
                                fix_item_fields.get(_TAG_CLIENT_DISCOUNT_STORE_ITEM_ID),
                                0,
                            ),
                        )
                        fix_item_discount = max(
                            0,
                            _TCPHandler._sproto_read_int(
                                fix_item_fields.get(_TAG_CLIENT_DISCOUNT_STORE_ITEM_DISCOUNT),
                                0,
                            ),
                        )
                        fix_item_bought = 1 if _TCPHandler._sproto_read_int(
                            fix_item_fields.get(_TAG_CLIENT_DISCOUNT_STORE_ITEM_BOUGHT),
                            0,
                        ) else 0

                random_items = _TCPHandler._sproto_parse_struct_list(
                    req_body.get(_TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_RANDOM_ITEMS)
                )
                random_count = len(random_items)
                refresh_time = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_CLIENT_STORE_DISCOUNT_NOTIFY_REQ_REFRESH_TIME),
                        0,
                    ),
                )

                body = None
                tag = "sproto-store-discount-info-client-noop"
                _append_utf8_log(
                    "[TCP] store_discount_info_from_client ignored "
                    f"fix_item={fix_item_id} discount={fix_item_discount} bought={fix_item_bought} "
                    f"random_count={random_count} refresh_time={refresh_time}"
                )

            elif msg_type == 152:
                # client_query_store_discount_info
                # response: fix_item(0), random_items(1), refresh_time(2)
                fix_cfg = _TCPHandler._normalize_discount_item(
                    _store_state.get("discount_fix_item"),
                    _TCPHandler._default_discount_item(20, discount=80, item_id_type=0),
                )
                valid_sale_ids = [
                    _TCPHandler._sproto_read_int(x, 0)
                    for x in _STORE_TYPE_DEFAULT_ITEMS.get(_STORE_TYPE_CHARACTER, [20])
                    if _TCPHandler._sproto_read_int(x, 0) > 0
                ]
                if not valid_sale_ids:
                    valid_sale_ids = [20]

                fix_cfg["item_id_type"] = 0
                if _TCPHandler._sproto_read_int(fix_cfg.get("item_id"), 0) not in valid_sale_ids:
                    fix_cfg["item_id"] = valid_sale_ids[0]

                random_seed_defaults = [
                    _TCPHandler._default_discount_item(60, discount=70, item_id_type=0),
                    _TCPHandler._default_discount_item(70, discount=65, item_id_type=0),
                    _TCPHandler._default_discount_item(90, discount=60, item_id_type=0),
                    _TCPHandler._default_discount_item(100, discount=55, item_id_type=0),
                    _TCPHandler._default_discount_item(110, discount=50, item_id_type=0),
                ]

                random_src = _store_state.get("discount_random_items")
                if not isinstance(random_src, list):
                    random_src = []
                random_cfg: list[dict] = []
                for idx, item in enumerate(random_src[:5]):
                    fallback = random_seed_defaults[idx] if idx < len(random_seed_defaults) else random_seed_defaults[-1]
                    normalized_item = _TCPHandler._normalize_discount_item(item, fallback)
                    if normalized_item["item_id_type"] != 0:
                        normalized_item = dict(fallback)
                        normalized_item["bought"] = bool(item.get("bought")) if isinstance(item, dict) else False
                    if _TCPHandler._sproto_read_int(normalized_item.get("item_id"), 0) not in valid_sale_ids:
                        normalized_item["item_id"] = valid_sale_ids[min(idx + 1, len(valid_sale_ids) - 1)]
                    normalized_item["item_id_type"] = 0
                    random_cfg.append(normalized_item)
                if not random_cfg:
                    random_cfg = [
                        _TCPHandler._default_discount_item(60, discount=70, item_id_type=0),
                        _TCPHandler._default_discount_item(70, discount=65, item_id_type=0),
                        _TCPHandler._default_discount_item(90, discount=60, item_id_type=0),
                    ]

                purchase_history = _store_state.get("purchase_history")
                if not isinstance(purchase_history, dict):
                    purchase_history = {}
                    _store_state["purchase_history"] = purchase_history

                fix_cfg["bought"] = _TCPHandler._sproto_read_int(
                    purchase_history.get(str(fix_cfg["item_id"])),
                    0,
                ) > 0
                for item in random_cfg:
                    item["bought"] = _TCPHandler._sproto_read_int(
                        purchase_history.get(str(item["item_id"])),
                        0,
                    ) > 0

                try:
                    random_sig = ",".join([f"{it['item_id']}:{it['item_id_type']}:{1 if it['bought'] else 0}:{it['discount']}" for it in random_cfg])
                    _append_utf8_log(
                        f"[TCP] discount_info fix={fix_cfg['item_id']}:{fix_cfg['item_id_type']}:{1 if fix_cfg['bought'] else 0}:{fix_cfg['discount']} "
                        f"random=[{random_sig}]"
                    )
                except Exception:
                    pass

                fix_item = _sproto_encode_fields([
                    (0, fix_cfg["item_id"]),
                    (1, fix_cfg["item_id_type"]),
                    (2, bool(fix_cfg["bought"])),
                    (3, fix_cfg["discount"]),
                ])
                random_items = _TCPHandler._sproto_build_struct_list([
                    _sproto_encode_fields([
                        (0, item["item_id"]),
                        (1, item["item_id_type"]),
                        (2, bool(item["bought"])),
                        (3, item["discount"]),
                    ])
                    for item in random_cfg
                ])

                now_ts = int(time.time())
                refresh_time = _TCPHandler._sproto_read_int(_store_state.get("discount_refresh_time"), now_ts + 21600)
                if refresh_time <= now_ts + 60:
                    refresh_time = now_ts + 21600
                    _store_state["discount_refresh_time"] = refresh_time
                    _save_player_data()

                body = [
                    (0, fix_item),
                    (1, random_items),
                    (2, refresh_time),
                ]
                tag = "sproto-query-store-discount-info-resp"

            elif msg_type == 107:
                # client_query_leaderboard
                _TCPHandler._log_sproto_qc(msg_type, "client.query_leaderboard.request", req_body, {
                    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_TYPE,
                    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_START_INDEX,
                    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_END_INDEX,
                    _TAG_CLIENT_QUERY_LEADERBOARD_REQ_EXTRA_ARG,
                })

                lb_type = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_LEADERBOARD_REQ_TYPE), 0))
                start_index = max(1, _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_LEADERBOARD_REQ_START_INDEX), 1))
                end_index = _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_LEADERBOARD_REQ_END_INDEX), start_index + 9)
                if end_index < start_index:
                    end_index = start_index
                count = min(50, end_index - start_index + 1)
                extra_arg = _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_LEADERBOARD_REQ_EXTRA_ARG), 0)

                self_uid_int = self._session_uid(pd)
                self_uid = str(self_uid_int)
                _online_ensure_profile(
                    self_uid_int,
                    local_pd=pd if _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid_int else None,
                )
                profile_uids: list[str] = []
                with _ONLINE_LOCK:
                    profiles_obj = _ONLINE_STATE.get("profiles")
                    if isinstance(profiles_obj, dict):
                        for raw_uid in profiles_obj.keys():
                            uid_s = _uid_str(raw_uid, "")
                            uid_num = _safe_int(uid_s, 0)
                            # Exclude test bots (UIDs >= 9000000 or 1, 2)
                            if uid_num >= 9000000 or uid_num in (1, 2):
                                continue
                            if uid_s:
                                profile_uids.append(uid_s)
                if self_uid not in profile_uids:
                    profile_uids.append(self_uid)

                seen_lb_uids: set[str] = set()
                ranked_uid_list: list[str] = []
                for uid_s in profile_uids:
                    if not uid_s or uid_s in seen_lb_uids:
                        continue
                    seen_lb_uids.add(uid_s)
                    ranked_uid_list.append(uid_s)
                if not ranked_uid_list:
                    ranked_uid_list = [self_uid]

                # Sort by leaderboard type
                def _get_lb_score(uid_s: str) -> tuple[int, int]:
                    prof = _online_ensure_profile(
                        uid_s,
                        local_pd=(
                            pd
                            if uid_s == self_uid and _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid_int
                            else None
                        ),
                    )
                    if lb_type == 2:  # Level leaderboard
                        return (_safe_int(prof.get("level"), 1), _safe_int(prof.get("exp"), 0))
                    # Default / Rank leaderboard (lb_type == 1 or other)
                    return (_safe_int(prof.get("rank_score"), 1000), _safe_int(prof.get("level"), 1))

                ranked_uid_list.sort(
                    key=lambda uid_s: (
                        -_get_lb_score(uid_s)[0],
                        -_get_lb_score(uid_s)[1],
                        _safe_int(uid_s, 0),
                    )
                )

                start_pos = max(0, start_index - 1)
                window_uids = ranked_uid_list[start_pos : start_pos + count]

                player_entries: list[bytes] = []
                ranks: list[int] = []
                for idx, entry_uid in enumerate(window_uids):
                    rank = start_index + idx
                    entry_profile = _online_ensure_profile(
                        entry_uid,
                        local_pd=(
                            pd
                            if entry_uid == self_uid and _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid_int
                            else None
                        ),
                    )
                    entry_name = _sanitize_display_name(entry_profile.get("name"), f"Player{entry_uid[-4:]}")
                    entry_level = max(1, _safe_int(entry_profile.get("level"), 1))
                    if lb_type == 2:
                        entry_score = entry_level
                    else:
                        entry_score = max(0, _safe_int(entry_profile.get("rank_score"), 0))
                    entry_icon = max(0, _safe_int(entry_profile.get("icon"), 0))
                    entry_icon_frame = max(0, _safe_int(entry_profile.get("icon_frame"), 0))
                    
                    info_blob = _encode_client_leaderboard_info(entry_name, entry_level, entry_icon, entry_icon_frame)
                    player_entries.append(
                        _encode_client_leaderboard_player(
                            entry_uid,
                            info_blob,
                            entry_score,
                            0,
                            0,
                            0,
                        )
                    )
                    ranks.append(rank)

                my_profile = _online_ensure_profile(
                    self_uid,
                    local_pd=pd if _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid_int else None,
                )
                my_name = _sanitize_display_name(my_profile.get("name"), "Local")
                my_level = max(1, _safe_int(my_profile.get("level"), 1))
                if lb_type == 2:
                    my_score = my_level
                else:
                    my_score = max(0, _safe_int(my_profile.get("rank_score"), _TCPHandler._sproto_read_int(_game_state.get("rank_score"), 0)))
                my_icon = max(0, _safe_int(my_profile.get("icon"), 0))
                my_icon_frame = max(0, _safe_int(my_profile.get("icon_frame"), 0))
                try:
                    my_rank = ranked_uid_list.index(self_uid) + 1
                except Exception:
                    my_rank = 1
                my_rank_info = _encode_client_leaderboard_player(
                    self_uid,
                    _encode_client_leaderboard_info(my_name, my_level, my_icon, my_icon_frame),
                    my_score,
                    0,
                    0,
                    0,
                )

                body = [
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_TYPE, lb_type),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_PLAYERS, _TCPHandler._sproto_build_struct_list(player_entries)),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_RANKS, _TCPHandler._sproto_build_integer_list(ranks)),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_MYRANK, my_rank),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_MY_RANKINFO, my_rank_info),
                    (_TAG_CLIENT_QUERY_LEADERBOARD_RESP_EXTRA_ARG, extra_arg),
                ]
                tag = "sproto-query-leaderboard-resp"

            elif msg_type == 132:
                # client_query_friend_leaderboard
                _TCPHandler._log_sproto_qc(msg_type, "client.query_friend_leaderboard.request", req_body, {
                    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_TYPE,
                    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_FRIEND_UID_LIST,
                    _TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_EXTRA_ARG,
                })

                lb_type = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_TYPE), 0))
                extra_arg = _TCPHandler._sproto_read_int(req_body.get(_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_EXTRA_ARG), 0)

                friend_uids: list[int] = []
                friend_payload = req_body.get(_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_REQ_FRIEND_UID_LIST)
                if isinstance(friend_payload, bytes) and len(friend_payload) >= 1:
                    import struct as _st
                    elem_size = friend_payload[0]
                    if elem_size in (4, 8):
                        offset = 1
                        while offset + elem_size <= len(friend_payload):
                            if elem_size == 4:
                                uid_val = _st.unpack_from("<i", friend_payload, offset)[0]
                            else:
                                uid_val = _st.unpack_from("<q", friend_payload, offset)[0]
                            offset += elem_size
                            if uid_val > 0:
                                friend_uids.append(int(uid_val))

                self_uid = self._session_uid(pd)
                _online_ensure_profile(
                    self_uid,
                    local_pd=pd if _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid else None,
                )
                if not friend_uids:
                    for uid_s in _online_get_uid_list("friends", self_uid):
                        uid_parsed = _safe_int(uid_s, 0)
                        if uid_parsed > 0:
                            friend_uids.append(uid_parsed)
                if self_uid not in friend_uids:
                    friend_uids.insert(0, self_uid)
                friend_uids = friend_uids[:50]

                entries: list[bytes] = []
                for idx, uid_val in enumerate(friend_uids):
                    uid_s = str(uid_val)
                    p_profile = _online_ensure_profile(
                        uid_s,
                        local_pd=(
                            pd
                            if uid_val == self_uid and _TCPHandler._sproto_read_int(pd.get("uid"), 0) == self_uid
                            else None
                        ),
                    )
                    p_name = _sanitize_display_name(p_profile.get("name"), f"Friend{uid_val % 1000}")
                    p_level = max(1, _safe_int(p_profile.get("level"), 1))
                    p_score = max(0, _safe_int(p_profile.get("rank_score"), 0))
                    p_icon = max(0, _safe_int(p_profile.get("icon"), 0))
                    p_icon_frame = max(0, _safe_int(p_profile.get("icon_frame"), 0))
                    info_blob = _encode_client_leaderboard_info(p_name, p_level, p_icon, p_icon_frame)
                    entries.append(
                        _encode_client_leaderboard_player(
                            uid_s,
                            info_blob,
                            p_score,
                            0,
                            0,
                            0,
                        )
                    )

                body = [
                    (_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_ERRORCODE, 0),
                    (_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_TYPE, lb_type),
                    (_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_PLAYERS, _TCPHandler._sproto_build_struct_list(entries)),
                    (_TAG_CLIENT_QUERY_FRIEND_LEADERBOARD_RESP_EXTRA_ARG, extra_arg),
                ]
                tag = "sproto-query-friend-leaderboard-resp"

            elif msg_type == 301:
                # invite_invite_req
                _TCPHandler._log_sproto_qc(msg_type, "invite.invite_req.request", req_body, {
                    _TAG_INVITE_REQ_UID,
                    _TAG_INVITE_REQ_TYPE,
                    _TAG_INVITE_REQ_EXTRA_ARG,
                    _TAG_INVITE_REQ_COMBAT_TYPE,
                })

                inviter_uid = self._session_uid(pd)
                invite_uid = max(1, _TCPHandler._sproto_read_int(req_body.get(_TAG_INVITE_REQ_UID), inviter_uid))
                invite_type = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_INVITE_REQ_TYPE), 0))
                combat_type = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_INVITE_REQ_COMBAT_TYPE), 0))
                identify_num = max(1, _TCPHandler._sproto_read_int(_invite_state.get("next_identify_id"), 1))
                _invite_state["next_identify_id"] = identify_num + 1
                identify_id = f"inv-{identify_num}"

                pending = _invite_state.get("pending")
                if not isinstance(pending, dict):
                    pending = {}
                    _invite_state["pending"] = pending
                pending[str(invite_uid)] = {
                    "inviter_uid": inviter_uid,
                    "invite_uid": invite_uid,
                    "invite_type": invite_type,
                    "combat_type": combat_type,
                    "identify_id": identify_id,
                    "extra_arg": _TCPHandler._sproto_read_text(req_body.get(_TAG_INVITE_REQ_EXTRA_ARG), ""),
                }

                body = [(_TAG_INVITE_REQ_RESP_ERRORCODE, 0)]
                invite_push = _TCPHandler._build_invite_notify_push(
                    invite_type,
                    identify_id,
                    combat_type,
                    inviter_uid=inviter_uid,
                )
                if invite_uid == inviter_uid:
                    extra_pushes.append(invite_push)
                else:
                    _TCPHandler._queue_pending_push(invite_uid, invite_push)
                    _append_utf8_log(
                        f"[TCP] invite_queued inviter={inviter_uid} target={invite_uid} identify={identify_id}"
                    )
                tag = "sproto-invite-req-resp"

            elif msg_type == 304:
                # invite_invite_reply_req
                _TCPHandler._log_sproto_qc(msg_type, "invite.invite_reply_req.request", req_body, {
                    _TAG_INVITE_REPLY_REQ_INVITER_UID,
                    _TAG_INVITE_REPLY_REQ_AGREE,
                })

                inviter_uid = max(1, _TCPHandler._sproto_read_int(req_body.get(_TAG_INVITE_REPLY_REQ_INVITER_UID), 0))
                agree = _TCPHandler._sproto_read_int(req_body.get(_TAG_INVITE_REPLY_REQ_AGREE), 0) > 0
                reply_uid = self._session_uid(pd)
                body = [(_TAG_INVITE_REPLY_RESP_ERRORCODE, 0)]

                pending = _invite_state.get("pending")
                invite_info = {}
                if isinstance(pending, dict):
                    invite_info = pending.pop(str(reply_uid), {}) or {}

                if not agree:
                    refuse_push = (
                        _sproto_build_push_frame(302, [
                            (_TAG_INVITE_REFUSE_UID, reply_uid),
                            (_TAG_INVITE_REFUSE_TYPE, 0),
                        ]),
                        "sproto-push-invite-refuse",
                    )
                    if inviter_uid == reply_uid:
                        extra_pushes.append(refuse_push)
                    else:
                        _TCPHandler._queue_pending_push(inviter_uid, refuse_push)
                elif inviter_uid > 0:
                    invite_type = _TCPHandler._sproto_read_int(invite_info.get("invite_type"), 0)
                    is_custom_room = (invite_type == 2) or _TCPHandler._room_is_active()
                    if is_custom_room:
                        # ── Custom Room: add replier to _room_state and broadcast room pushes ──
                        bot_pd = _online_ensure_profile(reply_uid, local_pd=pd if reply_uid == self_uid else None)
                        local_entry = _TCPHandler._room_ensure_local_player(bot_pd, _game_state, make_owner=False)

                        room_pushes: list[tuple[bytes, str]] = []
                        room_pushes.extend(_TCPHandler._room_snapshot_pushes())

                        entered_player = _encode_game_player_info(
                            _TCPHandler._sproto_read_int(local_entry.get("uid"), reply_uid),
                            str(local_entry.get("name") or "Local"),
                            max(1, _TCPHandler._sproto_read_int(local_entry.get("level"), 1)),
                            max(0, _TCPHandler._sproto_read_int(local_entry.get("icon"), 0)),
                            max(1, _TCPHandler._sproto_read_int(local_entry.get("camp"), 1)),
                            max(1, _TCPHandler._sproto_read_int(local_entry.get("index"), 1)),
                            max(0, _TCPHandler._sproto_read_int(local_entry.get("rank_score"), 0)),
                            str(local_entry.get("icon_url") or ""),
                        )
                        room_pushes.append((
                            _sproto_build_push_frame(1005, [
                                (_TAG_RSP_ROOM_PLAYER_ENTERED_PLAYER, entered_player),
                            ]),
                            "sproto-push-room-player-entered",
                        ))

                        pos_push = _TCPHandler._room_position_notify_push(reply_uid)
                        if pos_push is not None:
                            room_pushes.append(pos_push)

                        extra_pushes.extend(room_pushes)
                        _TCPHandler._queue_pending_pushes(inviter_uid, room_pushes)

                        room_id = _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)
                        if room_id > 0:
                            _chat_sync_room_group_members(room_id, [inviter_uid, reply_uid])

                        _append_utf8_log(
                            f"[TCP] invite_reply_req accepted for CUSTOM ROOM room_id={room_id} "
                            f"inviter={inviter_uid} replier={reply_uid}"
                        )
                    else:
                        # ── Team / Rookie Mode: add replier to _team_state and broadcast team sync ──
                        _TCPHandler._team_ensure_local_member(
                            pd,
                            ready_status=False,
                            force_captain=True,
                            uid_override=inviter_uid,
                        )
                        _TCPHandler._team_ensure_local_member(
                            pd,
                            ready_status=False,
                            force_captain=False,
                            uid_override=reply_uid,
                        )
                        _team_state["captain_uid"] = inviter_uid
                        sync_pushes: list[tuple[bytes, str]] = []
                        _TCPHandler._team_append_sync_pushes(sync_pushes)
                        extra_pushes.extend(sync_pushes)
                        _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=reply_uid)

                        _append_utf8_log(
                            f"[TCP] invite_reply_req accepted for TEAM team_id={_team_state.get('team_id')} "
                            f"inviter={inviter_uid} replier={reply_uid}"
                        )

                tag = "sproto-invite-reply-resp"

            elif msg_type == 401:
                # team_create_team_req
                _TCPHandler._log_sproto_qc(msg_type, "team.create_team_req.request", req_body, {
                    _TAG_TEAM_CREATE_REQ_BATTLE_ZONE,
                    _TAG_TEAM_CREATE_REQ_COMBAT_TYPE,
                })

                self_uid = self._session_uid(pd)
                _TCPHandler._team_reset()
                _team_state["team_id"] = _TCPHandler._team_allocate_id()
                _team_state["battle_zone"] = max(1, _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_CREATE_REQ_BATTLE_ZONE), _TCPHandler._sproto_read_int(_game_state.get("battle_zone"), 1)))
                _team_state["combat_type"] = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_CREATE_REQ_COMBAT_TYPE), 0))
                _TCPHandler._team_ensure_local_member(
                    pd,
                    ready_status=False,
                    force_captain=True,
                    uid_override=self_uid,
                )
                import services.chat
                services.chat.join_room_chat_group(self_uid, _team_state.get("team_id"), "team")
                body = [(_TAG_TEAM_CREATE_RESP_ERRORCODE, 0)]
                sync_pushes: list[tuple[bytes, str]] = []
                _TCPHandler._team_append_sync_pushes(sync_pushes)
                extra_pushes.extend(sync_pushes)
                _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self_uid)
                tag = "sproto-team-create-resp"

            elif msg_type == 402:
                # team_kick_member_req
                _TCPHandler._log_sproto_qc(msg_type, "team.kick_member_req.request", req_body, {
                    _TAG_TEAM_KICK_REQ_POS,
                    _TAG_TEAM_KICK_REQ_UID,
                })

                req_kick_pos = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_KICK_REQ_POS), 0))
                req_kick_uid = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_KICK_REQ_UID), 0))
                self_uid = self._session_uid(pd)
                errorcode = 0
                members = _team_state.get("members")
                if not isinstance(members, dict) or not members:
                    errorcode = 1
                elif _TCPHandler._sproto_read_int(_team_state.get("captain_uid"), 0) != self_uid:
                    errorcode = 2
                else:
                    kick_uid = req_kick_uid
                    if kick_uid <= 0 and req_kick_pos > 0:
                        for entry in members.values():
                            if not isinstance(entry, dict):
                                continue
                            if _TCPHandler._sproto_read_int(entry.get("pos"), 0) == req_kick_pos:
                                kick_uid = _TCPHandler._sproto_read_int(entry.get("uid"), 0)
                                break
                    if kick_uid <= 0 or str(kick_uid) not in members:
                        errorcode = 3
                    else:
                        members.pop(str(kick_uid), None)
                        if not members:
                            _TCPHandler._team_reset()
                        elif _TCPHandler._sproto_read_int(_team_state.get("captain_uid"), 0) == kick_uid:
                            next_candidates = [entry for entry in members.values() if isinstance(entry, dict)]
                            if next_candidates:
                                next_member = min(
                                    next_candidates,
                                    key=lambda e: (_TCPHandler._sproto_read_int(e.get("pos"), 9999), _TCPHandler._sproto_read_int(e.get("uid"), 0)),
                                )
                                _team_state["captain_uid"] = _TCPHandler._sproto_read_int(next_member.get("uid"), 0)
                            else:
                                _team_state["captain_uid"] = 0
                        req_kick_uid = kick_uid

                body = [
                    (_TAG_TEAM_KICK_RESP_ERRORCODE, errorcode),
                    (_TAG_TEAM_KICK_RESP_POS, req_kick_pos),
                    (_TAG_TEAM_KICK_RESP_UID, req_kick_uid),
                ]
                if errorcode == 0:
                    kick_push = _TCPHandler._team_member_leave_push(leave_pos=req_kick_pos, leave_type=2, leave_uid=req_kick_uid)
                    extra_pushes.append(kick_push)
                    _TCPHandler._queue_team_pushes([kick_push])
                    sync_pushes = []
                    _TCPHandler._team_append_sync_pushes(sync_pushes)
                    extra_pushes.extend(sync_pushes)
                    _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self_uid)
                tag = "sproto-team-kick-resp"

            elif msg_type == 403:
                # team_leave_team_req
                _TCPHandler._log_sproto_qc(msg_type, "team.leave_team_req.request", req_body, set())
                self_uid = self._session_uid(pd)
                import services.chat
                services.chat.leave_room_chat_group(self_uid, _team_state.get("team_id"))
                
                member_entry = _TCPHandler._team_find_member(self_uid)
                leave_pos = max(1, _TCPHandler._sproto_read_int(member_entry.get("pos"), 1)) if isinstance(member_entry, dict) else 1

                _TCPHandler._team_remove_member(self_uid)
                body = [(_TAG_TEAM_LEAVE_RESP_ERRORCODE, 0)]
                
                leave_push = _TCPHandler._team_member_leave_push(leave_pos=leave_pos, leave_type=1, leave_uid=self_uid)
                extra_pushes.append(leave_push)
                _TCPHandler._queue_team_pushes([leave_push], exclude_uid=self_uid)

                sync_pushes = []
                _TCPHandler._team_append_sync_pushes(sync_pushes)
                extra_pushes.extend(sync_pushes)
                _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self_uid)
                tag = "sproto-team-leave-resp"

            elif msg_type == 404:
                # team_operate_ready_req
                _TCPHandler._log_sproto_qc(msg_type, "team.operate_ready_req.request", req_body, {
                    _TAG_TEAM_READY_REQ_STATUS,
                })

                self_uid = self._session_uid(pd)
                ready_status = _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_READY_REQ_STATUS), 0) > 0
                _TCPHandler._team_ensure_local_member(
                    pd,
                    ready_status=ready_status,
                    force_captain=False,
                    uid_override=self_uid,
                )
                body = [
                    (_TAG_TEAM_READY_RESP_ERRORCODE, 0),
                    (_TAG_TEAM_READY_RESP_STATUS, ready_status),
                ]
                sync_pushes = []
                _TCPHandler._team_append_sync_pushes(sync_pushes)
                extra_pushes.extend(sync_pushes)
                _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self_uid)
                tag = "sproto-team-ready-resp"

            elif msg_type == 409:
                # team_team_join_match_req
                _TCPHandler._log_sproto_qc(msg_type, "team.team_join_match_req.request", req_body, set())
                self_uid = self._session_uid(pd)
                _TCPHandler._team_ensure_local_member(
                    pd,
                    ready_status=False,
                    force_captain=False,
                    uid_override=self_uid,
                )
                start_ts = int(time.time())
                estimated_time = max(0, _TCPHandler._sproto_read_int(_team_state.get("match_estimated_time"), 0))
                if estimated_time <= 0:
                    estimated_time = max(3, _int_env("TEAM_MATCH_ESTIMATED_TIME", 15))
                _team_state["is_matching"] = True
                _team_state["match_started_ts"] = start_ts
                _team_state["match_estimated_time"] = estimated_time
                body = [
                    (0, 0),  # errorcode
                ]
                extra_pushes.append((
                    _sproto_build_push_frame(415, [
                        (0, estimated_time),  # estimated_time
                        (1, start_ts),        # start_ts
                    ]),
                    "sproto-push-team-enter-match",
                ))
                _TCPHandler._queue_team_pushes(extra_pushes[-1:], exclude_uid=self_uid)
                tag = "sproto-team-join-match-resp"
                _append_utf8_log(
                    f"[TCP] team_join_match accepted start_ts={start_ts} eta={estimated_time}"
                )

            elif msg_type == 410:
                # team_team_quit_match_req
                _TCPHandler._log_sproto_qc(msg_type, "team.team_quit_match_req.request", req_body, set())
                self_uid = self._session_uid(pd)
                _team_state["is_matching"] = False
                _team_state["match_started_ts"] = 0
                _team_state["match_estimated_time"] = 0
                body = [
                    (0, 0),  # errorcode
                ]
                extra_pushes.append((
                    _sproto_build_push_frame(416, [
                        (0, self_uid),  # uid
                    ]),
                    "sproto-push-team-quit-match",
                ))
                _TCPHandler._queue_team_pushes(extra_pushes[-1:], exclude_uid=self_uid)
                tag = "sproto-team-quit-match-resp"
                _append_utf8_log(f"[TCP] team_quit_match accepted uid={self_uid}")

            elif msg_type == 412:
                # team_match_confirm_req
                _TCPHandler._log_sproto_qc(msg_type, "team.match_confirm_req.request", req_body, set())
                self_uid = self._session_uid(pd)
                body = None
                extra_pushes.append((
                    _sproto_build_push_frame(413, [
                        (0, self_uid),  # uid
                    ]),
                    "sproto-push-match-confirm-notify",
                ))
                _TCPHandler._queue_team_pushes(extra_pushes[-1:], exclude_uid=self_uid)
                tag = "sproto-team-match-confirm-resp"
                _append_utf8_log(f"[TCP] team_match_confirm accepted uid={self_uid}")

            elif msg_type == 419:
                # team_chat_enter_team_req
                _TCPHandler._log_sproto_qc(msg_type, "team.chat_enter_team_req.request", req_body, {
                    _TAG_TEAM_CHAT_ENTER_REQ_TEAM_ID,
                })

                req_team_id = _TCPHandler._sproto_read_text(req_body.get(_TAG_TEAM_CHAT_ENTER_REQ_TEAM_ID), "").strip()
                errorcode = 0
                if req_team_id and _team_state.get("team_id") not in ("", req_team_id):
                    errorcode = 1
                else:
                    if req_team_id and not _team_state.get("team_id"):
                        _team_state["team_id"] = req_team_id
                    _TCPHandler._team_ensure_local_member(
                        pd,
                        ready_status=False,
                        force_captain=False,
                        uid_override=self._session_uid(pd),
                    )
                    import services.chat
                    services.chat.join_room_chat_group(self._session_uid(pd), req_team_id or _team_state.get("team_id"), "team")

                body = [(_TAG_TEAM_CHAT_ENTER_RESP_ERRORCODE, errorcode)]
                if errorcode == 0:
                    sync_pushes = []
                    _TCPHandler._team_append_sync_pushes(sync_pushes)
                    extra_pushes.extend(sync_pushes)
                    _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self._session_uid(pd))
                tag = "sproto-team-chat-enter-resp"

            elif msg_type == 420:
                # team_change_battlezone_team_req
                _TCPHandler._log_sproto_qc(msg_type, "team.change_battlezone_team_req.request", req_body, {
                    _TAG_TEAM_CHANGE_BATTLEZONE_REQ,
                })

                errorcode = 0
                if not _team_state.get("team_id"):
                    errorcode = 1
                else:
                    _team_state["battle_zone"] = max(1, _TCPHandler._sproto_read_int(req_body.get(_TAG_TEAM_CHANGE_BATTLEZONE_REQ), _TCPHandler._sproto_read_int(_team_state.get("battle_zone"), 1)))
                body = [(_TAG_TEAM_CHANGE_BATTLEZONE_RESP_ERRORCODE, errorcode)]
                if errorcode == 0:
                    sync_pushes = []
                    _TCPHandler._team_append_sync_pushes(sync_pushes)
                    extra_pushes.extend(sync_pushes)
                    _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self._session_uid(pd))
                tag = "sproto-team-change-battlezone-resp"

            elif msg_type == 417:
                # team_return_team_req
                body = [
                    (_TAG_TEAM_RETURN_TEAM_RESP_ERRORCODE, 0),
                ]
                tag = "sproto-team-return-team-resp"

            elif msg_type == 418:
                # team_return_hall_req
                self_uid = self._session_uid(pd)
                import services.chat
                services.chat.leave_room_chat_group(self_uid, _team_state.get("team_id"))
                
                member_entry = _TCPHandler._team_find_member(self_uid)
                leave_pos = max(1, _TCPHandler._sproto_read_int(member_entry.get("pos"), 1)) if isinstance(member_entry, dict) else 1

                _TCPHandler._team_remove_member(self_uid)
                body = [
                    (_TAG_TEAM_RETURN_HALL_RESP_ERRORCODE, 0),
                ]
                leave_push = _TCPHandler._team_member_leave_push(leave_pos=leave_pos, leave_type=1, leave_uid=self_uid)
                extra_pushes.append(leave_push)
                _TCPHandler._queue_team_pushes([leave_push], exclude_uid=self_uid)
                
                sync_pushes = []
                _TCPHandler._team_append_sync_pushes(sync_pushes)
                extra_pushes.extend(sync_pushes)
                _TCPHandler._queue_team_pushes(sync_pushes, exclude_uid=self_uid)
                tag = "sproto-team-return-hall-resp"

            elif msg_type == 504:
                # mail_mail_list_req
                _TCPHandler._log_sproto_qc(msg_type, "mail.mail_list_req.request", req_body, set())
                body = None
                extra_pushes.append(_TCPHandler._mail_list_push())
                tag = "sproto-mail-list-req-resp"

            elif msg_type == 502:
                # mail_operate_mail
                _TCPHandler._log_sproto_qc(msg_type, "mail.operate_mail.request", req_body, {
                    _TAG_MAIL_OPERATE_REQ_TYPE,
                    _TAG_MAIL_OPERATE_REQ_MAIL_ID,
                })

                operate_type = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_MAIL_OPERATE_REQ_TYPE), 0))
                mail_id = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_MAIL_OPERATE_REQ_MAIL_ID), 0))
                mail = _TCPHandler._mail_find(mail_id)
                errorcode = 0
                reward_counts: dict[int, int] = {}

                if mail is None:
                    errorcode = 1
                elif operate_type == 1:
                    mails = _mail_state.get("mails")
                    if isinstance(mails, list):
                        _mail_state["mails"] = [
                            m for m in mails
                            if not (isinstance(m, dict) and _TCPHandler._sproto_read_int(m.get("id"), 0) == mail_id)
                        ]
                    extra_pushes.append((
                        _sproto_build_push_frame(506, [
                            (_TAG_MAIL_DELETE_NOTIFY_MAIL_ID, mail_id),
                        ]),
                        "sproto-push-mail-delete-notify",
                    ))
                elif operate_type == 2:
                    status = _TCPHandler._sproto_read_int(mail.get("status"), _MAIL_STATUS_NOT_READ)
                    if status == _MAIL_STATUS_NOT_READ:
                        mail["status"] = _MAIL_STATUS_READ
                elif operate_type == 3:
                    status = _TCPHandler._sproto_read_int(mail.get("status"), _MAIL_STATUS_NOT_READ)
                    if status != _MAIL_STATUS_GET_REWARD:
                        mail["status"] = _MAIL_STATUS_GET_REWARD
                        rewards_src = mail.get("rewards")
                        if isinstance(rewards_src, list):
                            for reward in rewards_src:
                                if not isinstance(reward, dict):
                                    continue
                                reward_id = _TCPHandler._normalize_mail_reward_id(
                                    _TCPHandler._sproto_read_int(reward.get("id"), 0)
                                )
                                reward_num = max(0, _TCPHandler._sproto_read_int(reward.get("num"), 0))
                                if reward_id <= 0 or reward_num <= 0:
                                    continue
                                reward_counts[reward_id] = reward_counts.get(reward_id, 0) + reward_num
                    else:
                        errorcode = 2

                if reward_counts:
                    reward_entries = [
                        _sproto_encode_fields([(0, rid), (1, num)])
                        for rid, num in sorted(reward_counts.items())
                    ]
                    extra_pushes.append((
                        _sproto_build_push_frame(141, [
                            (0, _TCPHandler._sproto_build_struct_list(reward_entries)),
                            (1, 0),
                        ]),
                        "sproto-push-get-reward-notify-mail",
                    ))

                    # Update local money only for known currency bag ids.
                    added_gold = 0
                    added_diamond = 0
                    for reward_id, reward_num in reward_counts.items():
                        money_kind = _TCPHandler._mail_reward_money_kind(reward_id)
                        if money_kind == "diamond":
                            added_diamond += reward_num
                        elif money_kind == "gold":
                            added_gold += reward_num
                    if added_gold > 0:
                        pd["gold"] = max(0, _TCPHandler._sproto_read_int(pd.get("gold"), _DEFAULT_GOLD)) + added_gold
                    if added_diamond > 0:
                        pd["diamond"] = max(0, _TCPHandler._sproto_read_int(pd.get("diamond"), _DEFAULT_DIAMOND)) + added_diamond
                    if added_gold > 0 or added_diamond > 0:
                        extra_pushes.extend(self._build_money_pushes())

                if errorcode == 0:
                    # Keep mail UI state synchronized after read/reward/delete operations.
                    extra_pushes.append(_TCPHandler._mail_list_push())

                _save_player_data()
                op_result = _encode_mail_operate_result(mail_id, errorcode)
                body = [
                    (_TAG_MAIL_OPERATE_RESP_TYPE, operate_type),
                    (_TAG_MAIL_OPERATE_RESP_RESULT, op_result),
                ]
                tag = "sproto-mail-operate-resp"

            elif msg_type == 510:
                # mail_delete_all_read_mail
                _TCPHandler._log_sproto_qc(msg_type, "mail.delete_all_read_mail.request", req_body, {
                    _TAG_MAIL_DELETE_ALL_REQ_TYPE,
                })

                req_mail_type = _TCPHandler._sproto_read_int(req_body.get(_TAG_MAIL_DELETE_ALL_REQ_TYPE), 0)
                mails = _mail_state.get("mails")
                removed_ids: list[int] = []
                if isinstance(mails, list):
                    keep: list[dict] = []
                    for mail in mails:
                        if not isinstance(mail, dict):
                            continue
                        m_type = _TCPHandler._sproto_read_int(mail.get("mail_type"), 1)
                        if req_mail_type > 0 and m_type != req_mail_type:
                            keep.append(mail)
                        status = _TCPHandler._sproto_read_int(mail.get("status"), _MAIL_STATUS_NOT_READ)
                        rewards_src = mail.get("rewards")
                        has_rewards = isinstance(rewards_src, list) and any(
                            isinstance(r, dict) and _TCPHandler._sproto_read_int(r.get("num"), 0) > 0
                            for r in rewards_src
                        )
                        can_delete = status != _MAIL_STATUS_NOT_READ and (not has_rewards or status == _MAIL_STATUS_GET_REWARD)
                        if can_delete:
                            removed_ids.append(_TCPHandler._sproto_read_int(mail.get("id"), 0))
                        else:
                            keep.append(mail)
                    _mail_state["mails"] = keep

                for removed_id in removed_ids:
                    if removed_id <= 0:
                        continue
                    extra_pushes.append((
                        _sproto_build_push_frame(506, [
                            (_TAG_MAIL_DELETE_NOTIFY_MAIL_ID, removed_id),
                        ]),
                        "sproto-push-mail-delete-notify",
                    ))

                extra_pushes.append(_TCPHandler._mail_list_push())
                _save_player_data()

                body = [
                    (_TAG_MAIL_DELETE_ALL_RESP_OPERATE_TYPE, 1),
                    (_TAG_MAIL_DELETE_ALL_RESP_MAIL_IDS, _TCPHandler._sproto_build_integer_list(removed_ids)),
                ]
                tag = "sproto-mail-delete-all-read-resp"

            elif msg_type == 511:
                # mail_get_all_reward
                _TCPHandler._log_sproto_qc(msg_type, "mail.get_all_reward.request", req_body, {
                    _TAG_MAIL_GET_ALL_REQ_TYPE,
                })

                req_mail_type = _TCPHandler._sproto_read_int(req_body.get(_TAG_MAIL_GET_ALL_REQ_TYPE), 0)
                mails = _mail_state.get("mails")
                result_entries: list[bytes] = []
                reward_counts: dict[int, int] = {}

                if isinstance(mails, list):
                    for mail in mails:
                        if not isinstance(mail, dict):
                            continue
                        m_type = _TCPHandler._sproto_read_int(mail.get("mail_type"), 1)
                        if req_mail_type > 0 and m_type != req_mail_type:
                            continue
                        status = _TCPHandler._sproto_read_int(mail.get("status"), _MAIL_STATUS_NOT_READ)
                        if status == _MAIL_STATUS_GET_REWARD:
                            continue
                        rewards_src = mail.get("rewards")
                        has_rewards = isinstance(rewards_src, list) and bool(rewards_src)
                        if not has_rewards:
                            continue

                        mail_id = _TCPHandler._sproto_read_int(mail.get("id"), 0)
                        mail["status"] = _MAIL_STATUS_GET_REWARD
                        result_entries.append(_encode_mail_operate_result(mail_id, 0))
                        for reward in rewards_src:
                            if not isinstance(reward, dict):
                                continue
                            reward_id = _TCPHandler._normalize_mail_reward_id(
                                _TCPHandler._sproto_read_int(reward.get("id"), 0)
                            )
                            reward_num = max(0, _TCPHandler._sproto_read_int(reward.get("num"), 0))
                            if reward_id <= 0 or reward_num <= 0:
                                continue
                            reward_counts[reward_id] = reward_counts.get(reward_id, 0) + reward_num

                if reward_counts:
                    reward_entries = [
                        _sproto_encode_fields([(0, rid), (1, num)])
                        for rid, num in sorted(reward_counts.items())
                    ]
                    extra_pushes.append((
                        _sproto_build_push_frame(141, [
                            (0, _TCPHandler._sproto_build_struct_list(reward_entries)),
                            (1, 0),
                        ]),
                        "sproto-push-get-reward-notify-mail-all",
                    ))

                    added_gold = 0
                    added_diamond = 0
                    for reward_id, reward_num in reward_counts.items():
                        money_kind = _TCPHandler._mail_reward_money_kind(reward_id)
                        if money_kind == "diamond":
                            added_diamond += reward_num
                        elif money_kind == "gold":
                            added_gold += reward_num
                    if added_gold > 0:
                        pd["gold"] = max(0, _TCPHandler._sproto_read_int(pd.get("gold"), _DEFAULT_GOLD)) + added_gold
                    if added_diamond > 0:
                        pd["diamond"] = max(0, _TCPHandler._sproto_read_int(pd.get("diamond"), _DEFAULT_DIAMOND)) + added_diamond
                    if added_gold > 0 or added_diamond > 0:
                        extra_pushes.extend(self._build_money_pushes())

                extra_pushes.append(_TCPHandler._mail_list_push())

                _save_player_data()
                body = [
                    (_TAG_MAIL_GET_ALL_RESP_RESULTS, _TCPHandler._sproto_build_struct_list(result_entries)),
                ]
                tag = "sproto-mail-get-all-reward-resp"

            elif msg_type == 1110:
                # game_AskAllTaskInfo
                # response: tasks_info(0), cur_refresh_cnt(1), daily_task_last_refresh_timeout(2)
                now_ts = int(time.time())
                daily_state = pd.get("daily_task_state")
                if not isinstance(daily_state, dict):
                    daily_state = {}
                    pd["daily_task_state"] = daily_state

                cur_refresh_cnt = max(
                    0,
                    _TCPHandler._sproto_read_int(daily_state.get("cur_refresh_cnt"), 3),
                )
                next_refresh_ts = max(
                    now_ts + 60,
                    _TCPHandler._sproto_read_int(
                        daily_state.get("daily_task_last_refresh_timeout"),
                        now_ts + 86400,
                    ),
                )
                if next_refresh_ts <= now_ts:
                    next_refresh_ts = now_ts + 86400
                    daily_state["daily_task_last_refresh_timeout"] = next_refresh_ts
                    daily_state["cur_refresh_cnt"] = 3
                    _save_player_data()

                tasks_payload = _TCPHandler._build_all_tasks_payload(pd)
                body = [
                    (_TAG_GAME_ASK_ALL_TASK_INFO_RESP_TASKS_INFO, tasks_payload),
                    (_TAG_GAME_ASK_ALL_TASK_INFO_RESP_CUR_REFRESH_CNT, cur_refresh_cnt),
                    (_TAG_GAME_ASK_ALL_TASK_INFO_RESP_LAST_REFRESH_TIMEOUT, next_refresh_ts),
                ]
                tag = "sproto-ask-all-task-info-resp"
                _append_utf8_log(
                    f"[TCP] ask_all_task_info count={len(pd.get('claimed_tasks', []))} "
                    f"cur_refresh_cnt={cur_refresh_cnt} next_refresh_ts={next_refresh_ts}"
                )

            elif msg_type == 1111:
                # game_RspSyncChangedTaskInfo is a server->client push contract.
                # If client sends it, acknowledge and ignore.
                task_entries = _TCPHandler._sproto_parse_struct_list(
                    req_body.get(_TAG_RSP_SYNC_CHANGED_TASK_INFO_TASKS_INFO)
                )
                cur_refresh_cnt = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_SYNC_CHANGED_TASK_INFO_CUR_REFRESH_CNT),
                        0,
                    ),
                )
                last_refresh_timeout = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_SYNC_CHANGED_TASK_INFO_LAST_REFRESH_TIMEOUT),
                        0,
                    ),
                )
                sample_task_id = 0
                sample_task_status = 0
                if task_entries:
                    sample_task = task_entries[0]
                    sample_task_id = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            sample_task.get(_TAG_GAME_TASK_INFO_ID),
                            0,
                        ),
                    )
                    sample_task_status = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            sample_task.get(_TAG_GAME_TASK_INFO_STATUS),
                            0,
                        ),
                    )
                body = None
                tag = "sproto-rsp-sync-changed-task-info-client-noop"
                _append_utf8_log(
                    "[TCP] rsp_sync_changed_task_info_from_client ignored "
                    f"count={len(task_entries)} cur_refresh_cnt={cur_refresh_cnt} "
                    f"last_refresh_timeout={last_refresh_timeout} sample={sample_task_id}:{sample_task_status}"
                )

            elif msg_type == 1112:
                # game_ReqGetTaskReward
                _init_task_tables()
                req_task_id = max(0, _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_GAME_REQ_GET_TASK_REWARD_REQ_ID),
                    0,
                ))
                claimed_tasks = pd.setdefault("claimed_tasks", [])
                if req_task_id > 0 and req_task_id not in claimed_tasks:
                    claimed_tasks.append(req_task_id)

                task_info = _TASK_TABLE.get(req_task_id, {})
                act_task_id = task_info.get("param1", 0)
                act_info = _ACTIVITY_TASK_TABLE.get(act_task_id, {})
                rewards = act_info.get("rewards", [])
                granted, reward_items, added_gold, added_diamond = _grant_rewards_to_player(pd, rewards)

                if task_info.get("activation", 0) > 0:
                    pd["daily_activation"] = pd.get("daily_activation", 0) + task_info["activation"]
                if task_info.get("exp", 0) > 0:
                    pd["exp"] = pd.get("exp", 0) + task_info["exp"]

                _save_player_data()

                body = [
                    (_TAG_GAME_REQ_GET_TASK_REWARD_RESP_ERRORCODE, 0),
                    (_TAG_GAME_REQ_GET_TASK_REWARD_RESP_ID, req_task_id),
                ]

                if reward_items:
                    reward_entries = [
                        _sproto_encode_fields([(0, rid), (1, num)])
                        for rid, num in reward_items
                    ]
                    extra_pushes.append((
                        _sproto_build_push_frame(141, [
                            (0, _TCPHandler._sproto_build_struct_list(reward_entries)),
                            (1, 0),
                        ]),
                        "sproto-push-get-reward-notify-task",
                    ))

                if added_gold > 0 or added_diamond > 0:
                    extra_pushes.extend(self._build_money_pushes(pd))

                updated_task = _sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, req_task_id),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, 1),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, 0),
                    (_TAG_GAME_TASK_INFO_STATUS, 3),
                ])
                extra_pushes.append((
                    _sproto_build_push_frame(1111, [
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_TASKS_INFO, _TCPHandler._sproto_build_struct_list([updated_task])),
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_CUR_REFRESH_CNT, 3),
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_LAST_REFRESH_TIMEOUT, int(time.time()) + 86400),
                    ]),
                    "sproto-push-sync-changed-task-info",
                ))

                tag = "sproto-req-get-task-reward-resp"
                _append_utf8_log(
                    f"[TCP] req_get_task_reward task_id={req_task_id} granted={granted}"
                )

            elif msg_type == 1113:
                # game_ReqRefreshTask
                now_ts = int(time.time())
                req_slot = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_GAME_REQ_REFRESH_TASK_REQ_SLOT),
                    1,
                )
                req_last_refresh_ts = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_GAME_REQ_REFRESH_TASK_REQ_LAST_REFRESH_TIMEOUT),
                    0,
                )

                daily_state = pd.get("daily_task_state")
                if not isinstance(daily_state, dict):
                    daily_state = {}
                    pd["daily_task_state"] = daily_state

                cur_refresh_cnt = max(
                    0,
                    _TCPHandler._sproto_read_int(daily_state.get("cur_refresh_cnt"), 3),
                )
                if cur_refresh_cnt > 0:
                    cur_refresh_cnt -= 1
                daily_state["cur_refresh_cnt"] = cur_refresh_cnt
                next_refresh_ts = now_ts + 86400
                daily_state["daily_task_last_refresh_timeout"] = next_refresh_ts

                # Pick a new task for this slot
                daily_tasks = pd.setdefault("daily_tasks", [200000, 200001, 200002, 200003])
                slot_idx = max(1, min(4, req_slot)) - 1
                current_id = daily_tasks[slot_idx] if slot_idx < len(daily_tasks) else 200000
                new_id = (current_id + 1) if current_id < 200014 else 200000
                if slot_idx < len(daily_tasks):
                    daily_tasks[slot_idx] = new_id
                else:
                    daily_tasks.append(new_id)

                _save_player_data()

                body = [
                    (_TAG_GAME_REQ_REFRESH_TASK_RESP_ERRORCODE, 0),
                    (_TAG_GAME_REQ_REFRESH_TASK_RESP_CUR_REFRESH_CNT, cur_refresh_cnt),
                    (_TAG_GAME_REQ_REFRESH_TASK_RESP_LAST_REFRESH_TIMEOUT, next_refresh_ts),
                ]

                # Push updated task in that slot
                refreshed_task = _sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, new_id),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, 1),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, slot_idx + 1),
                    (_TAG_GAME_TASK_INFO_STATUS, 2),
                ])
                extra_pushes.append((
                    _sproto_build_push_frame(1111, [
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_TASKS_INFO, _TCPHandler._sproto_build_struct_list([refreshed_task])),
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_CUR_REFRESH_CNT, cur_refresh_cnt),
                        (_TAG_RSP_SYNC_CHANGED_TASK_INFO_LAST_REFRESH_TIMEOUT, next_refresh_ts),
                    ]),
                    "sproto-push-sync-changed-task-info",
                ))

                tag = "sproto-req-refresh-task-resp"
                _append_utf8_log(
                    "[TCP] req_refresh_task "
                    f"slot={req_slot} new_id={new_id} cur_refresh_cnt={cur_refresh_cnt}"
                )

            elif msg_type == 1114:
                # game_RspSyncChangedActivityInfo is a server->client push contract.
                # If client sends it, acknowledge and ignore.
                activity_id = 0
                in_time = 0
                activity_info = req_body.get(_TAG_RSP_SYNC_CHANGED_ACTIVITY_INFO_INFO)
                if isinstance(activity_info, bytes):
                    try:
                        activity_fields, _ = _sproto_decode_fields(activity_info, 0)
                    except Exception:
                        activity_fields = {}
                    if isinstance(activity_fields, dict):
                        activity_id = max(
                            0,
                            _TCPHandler._sproto_read_int(
                                activity_fields.get(_TAG_ACTIVITY_INFO_ID),
                                0,
                            ),
                        )
                        in_time = 1 if _TCPHandler._sproto_read_int(
                            activity_fields.get(_TAG_ACTIVITY_INFO_IS_IN_TIME),
                            0,
                        ) else 0
                body = None
                tag = "sproto-rsp-sync-changed-activity-info-client-noop"
                _append_utf8_log(
                    "[TCP] rsp_sync_changed_activity_info_from_client ignored "
                    f"activity_id={activity_id} in_time={in_time}"
                )

            elif msg_type == 1120:
                # game_ReqCharacterInfo: return hall character equipment snapshot via push 1121.
                gs = _game_state
                selected_character_id = _TCPHandler._ensure_character_selection_for_camp(gs)

                unlocked_ids = _TCPHandler._collect_unlocked_character_ids(camp=gs.get("camp"))
                deduped_ids: list[int] = []
                seen_ids: set[int] = set()
                for char_raw in unlocked_ids:
                    cid = _TCPHandler._sproto_read_int(char_raw, 0)
                    if cid <= 0 or cid in seen_ids:
                        continue
                    if not _TCPHandler._character_is_available(cid):
                        continue
                    if not _TCPHandler._character_matches_camp(cid, gs.get("camp")):
                        continue
                    seen_ids.add(cid)
                    deduped_ids.append(cid)
                    if len(deduped_ids) >= 64:
                        break
                if selected_character_id > 0 and selected_character_id not in deduped_ids:
                    deduped_ids.insert(0, selected_character_id)
                if not deduped_ids:
                    deduped_ids = [selected_character_id]

                primary_weapon_state = gs.get("primary_weapon")
                if not isinstance(primary_weapon_state, dict):
                    primary_weapon_state = {}
                secondary_weapon_state = gs.get("secondary_weapon")
                if not isinstance(secondary_weapon_state, dict):
                    secondary_weapon_state = {}
                current_primary_attachments = _TCPHandler._normalize_attachment_list(
                    primary_weapon_state.get("attachments")
                )
                current_secondary_attachments = _TCPHandler._normalize_attachment_list(
                    secondary_weapon_state.get("attachments")
                )
                primary_weapon_state["attachments"] = current_primary_attachments
                secondary_weapon_state["attachments"] = current_secondary_attachments

                character_entries: list[bytes] = []
                for character_id in deduped_ids:
                    primary_options, secondary_options, main_options, sub_options = _TCPHandler._character_loadout_options(
                        character_id
                    )
                    if character_id == selected_character_id:
                        cur_primary = _TCPHandler._sproto_read_int(primary_weapon_state.get("id"), primary_options[0])
                        if cur_primary not in primary_options:
                            cur_primary = primary_options[0]
                        primary_weapon_state["id"] = cur_primary

                        cur_secondary = _TCPHandler._sproto_read_int(secondary_weapon_state.get("id"), secondary_options[0])
                        if cur_secondary not in secondary_options:
                            cur_secondary = secondary_options[0]
                        secondary_weapon_state["id"] = cur_secondary

                        cur_main_skill = _TCPHandler._sproto_read_int(gs.get("main_skill_id"), main_options[0])
                        if cur_main_skill not in main_options:
                            cur_main_skill = main_options[0]
                        gs["main_skill_id"] = cur_main_skill

                        cur_sub_skill = _TCPHandler._sproto_read_int(gs.get("sub_skill_id"), sub_options[0])
                        if cur_sub_skill not in sub_options:
                            cur_sub_skill = sub_options[0]
                        gs["sub_skill_id"] = cur_sub_skill

                        pri_structs = [
                            _encode_game_weapon_info(
                                weapon_id,
                                current_primary_attachments if weapon_id == cur_primary else [],
                            )
                            for weapon_id in primary_options
                        ]
                        sec_structs = [
                            _encode_game_weapon_info(
                                weapon_id,
                                current_secondary_attachments if weapon_id == cur_secondary else [],
                            )
                            for weapon_id in secondary_options
                        ]
                    else:
                        d_primary, d_secondary, d_main, d_sub = _TCPHandler._character_default_loadout(character_id)
                        cur_primary = d_primary if d_primary in primary_options else primary_options[0]
                        cur_secondary = d_secondary if d_secondary in secondary_options else secondary_options[0]
                        cur_main_skill = d_main if d_main in main_options else main_options[0]
                        cur_sub_skill = d_sub if d_sub in sub_options else sub_options[0]
                        pri_structs = [_encode_game_weapon_info(weapon_id, []) for weapon_id in primary_options]
                        sec_structs = [_encode_game_weapon_info(weapon_id, []) for weapon_id in secondary_options]

                    character_entries.append(
                        _encode_game_character_info(
                            character_id,
                            cur_primary,
                            _TCPHandler._sproto_build_struct_list(pri_structs),
                            cur_secondary,
                            _TCPHandler._sproto_build_struct_list(sec_structs),
                            cur_main_skill,
                            _TCPHandler._sproto_build_integer_list(main_options),
                            cur_sub_skill,
                            _TCPHandler._sproto_build_integer_list(sub_options),
                        )
                    )

                extra_pushes.append((
                    _sproto_build_push_frame(1121, [
                        (_TAG_RSP_CHARACTER_INFO_CHARACTERS, _TCPHandler._sproto_build_struct_list(character_entries)),
                    ]),
                    "sproto-push-rsp-character-info",
                ))

                _persist_training_profile(save=True)
                body = None
                tag = "sproto-req-character-info-resp"
                _append_utf8_log(
                    "[TCP] req_character_info "
                    f"camp={_TCPHandler._sproto_read_int(gs.get('camp'), 1)} "
                    f"selected={selected_character_id} count={len(character_entries)}"
                )

            elif msg_type == 1121:
                # game_RspCharacterInfo is a server->client push contract.
                # If client sends it, acknowledge and ignore.
                req_characters = _TCPHandler._sproto_parse_struct_list(
                    req_body.get(_TAG_RSP_CHARACTER_INFO_CHARACTERS)
                )
                sample_character_id = 0
                if req_characters:
                    sample_character_id = max(
                        0,
                        _TCPHandler._sproto_read_int(
                            req_characters[0].get(_TAG_CHARACTER_INFO_ID),
                            0,
                        ),
                    )
                body = None
                tag = "sproto-rsp-character-info-client-noop"
                _append_utf8_log(
                    "[TCP] rsp_character_info_from_client ignored "
                    f"count={len(req_characters)} sample_character_id={sample_character_id}"
                )

            elif msg_type == 1122:
                # game_ReqHallChooseWeapon: update hall loadout and push 1123.
                gs = _game_state
                req_character_id = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_HALL_CHOOSE_WEAPON_CHARACTER_ID),
                    _TCPHandler._sproto_read_int(gs.get("character_id"), 1),
                )
                req_kind = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_HALL_CHOOSE_WEAPON_KIND),
                    0,
                )
                req_id = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_HALL_CHOOSE_WEAPON_ID),
                    0,
                )
                req_attachments = _TCPHandler._normalize_attachment_list(
                    req_body.get(_TAG_REQ_HALL_CHOOSE_WEAPON_ATTACHMENTS)
                )

                selected_character_id = _TCPHandler._ensure_character_selection_for_camp(
                    gs,
                    preferred_character_id=req_character_id,
                )
                primary_options, secondary_options, main_options, sub_options = _TCPHandler._character_loadout_options(
                    selected_character_id
                )

                primary_weapon = gs.get("primary_weapon")
                if not isinstance(primary_weapon, dict):
                    primary_weapon = {}
                    gs["primary_weapon"] = primary_weapon
                secondary_weapon = gs.get("secondary_weapon")
                if not isinstance(secondary_weapon, dict):
                    secondary_weapon = {}
                    gs["secondary_weapon"] = secondary_weapon

                applied_id = 0
                applied_attachments: list[dict[str, int]] = []
                if req_kind == 0:
                    if req_id not in primary_options:
                        req_id = primary_options[0]
                    primary_weapon["id"] = req_id
                    primary_weapon["attachments"] = req_attachments
                    primary_weapon["skin"] = _TCPHandler._selected_weapon_visual_skin_id(
                        selected_character_id,
                        req_id,
                        primary_weapon.get("skin"),
                    )
                    applied_id = req_id
                    applied_attachments = req_attachments
                elif req_kind == 1:
                    if req_id not in secondary_options:
                        req_id = secondary_options[0]
                    secondary_weapon["id"] = req_id
                    secondary_weapon["attachments"] = req_attachments
                    secondary_weapon["skin"] = _TCPHandler._selected_weapon_visual_skin_id(
                        selected_character_id,
                        req_id,
                        secondary_weapon.get("skin"),
                    )
                    applied_id = req_id
                    applied_attachments = req_attachments
                elif req_kind == 2:
                    if req_id not in main_options:
                        req_id = main_options[0]
                    gs["main_skill_id"] = req_id
                    applied_id = req_id
                elif req_kind == 3:
                    if req_id not in sub_options:
                        req_id = sub_options[0]
                    gs["sub_skill_id"] = req_id
                    applied_id = req_id
                else:
                    req_kind = 0
                    current_primary = _TCPHandler._sproto_read_int(primary_weapon.get("id"), primary_options[0])
                    if current_primary not in primary_options:
                        current_primary = primary_options[0]
                    primary_weapon["id"] = current_primary
                    applied_id = current_primary
                    applied_attachments = _TCPHandler._normalize_attachment_list(
                        primary_weapon.get("attachments")
                    )
                    primary_weapon["attachments"] = applied_attachments

                push_body: list[tuple[int, object]] = [
                    (_TAG_RSP_HALL_CHOOSE_WEAPON_CHARACTER_ID, selected_character_id),
                    (_TAG_RSP_HALL_CHOOSE_WEAPON_KIND, req_kind),
                    (_TAG_RSP_HALL_CHOOSE_WEAPON_ID, applied_id),
                ]
                if req_kind in (0, 1):
                    push_body.append((
                        _TAG_RSP_HALL_CHOOSE_WEAPON_ATTACHMENTS,
                        _encode_game_attachment_list(applied_attachments),
                    ))

                extra_pushes.append((
                    _sproto_build_push_frame(1123, push_body),
                    "sproto-push-rsp-hall-choose-weapon",
                ))

                _persist_training_profile(save=True)
                body = None
                tag = "sproto-req-hall-choose-weapon-resp"
                _append_utf8_log(
                    "[TCP] req_hall_choose_weapon "
                    f"character_id={selected_character_id} kind={req_kind} id={applied_id} "
                    f"attachments={len(applied_attachments)}"
                )

            elif msg_type == 1123:
                # game_RspHallChooseWeapon is a server->client push contract.
                # If client sends it, acknowledge and ignore.
                rsp_character_id = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_HALL_CHOOSE_WEAPON_CHARACTER_ID),
                        0,
                    ),
                )
                rsp_kind = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_HALL_CHOOSE_WEAPON_KIND),
                        0,
                    ),
                )
                rsp_id = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_HALL_CHOOSE_WEAPON_ID),
                        0,
                    ),
                )
                rsp_attachments = _TCPHandler._normalize_attachment_list(
                    req_body.get(_TAG_RSP_HALL_CHOOSE_WEAPON_ATTACHMENTS)
                )
                body = None
                tag = "sproto-rsp-hall-choose-weapon-client-noop"
                _append_utf8_log(
                    "[TCP] rsp_hall_choose_weapon_from_client ignored "
                    f"character_id={rsp_character_id} kind={rsp_kind} id={rsp_id} "
                    f"attachments={len(rsp_attachments)}"
                )

            elif msg_type == 1124:
                # game_RspUnlockCharacter is a server->client push contract.
                # If client sends it, acknowledge and ignore.
                unlock_character_id = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_UNLOCK_CHARACTER_CHARACTER_ID),
                        0,
                    ),
                )
                unlock_limit_time = max(
                    0,
                    _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_RSP_UNLOCK_CHARACTER_LIMIT_TIME),
                        0,
                    ),
                )
                body = None
                tag = "sproto-rsp-unlock-character-client-noop"
                _append_utf8_log(
                    "[TCP] rsp_unlock_character_from_client ignored "
                    f"character_id={unlock_character_id} limit_time={unlock_limit_time}"
                )

            elif msg_type == 1125:
                # game_ReqAdReward has request-only contract (no response body fields).
                # Private-server policy: ads disabled, reward grant is intentionally no-op.
                body = None
                tag = "sproto-req-ad-reward-noop-resp"
                _append_utf8_log("[TCP] req_ad_reward ignored (ads disabled)")

            # ── Game / battle messages ────────────────────────────────

            elif msg_type == 1090:
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqActivityInfo.request", req_body, set())
                body = None
                activities_payload = _TCPHandler._build_all_activities_payload(pd)
                extra_pushes.append((
                    _sproto_build_push_frame(1097, [
                        (_TAG_RSP_ACTIVITY_INFO_INFOS, activities_payload),
                    ]),
                    "sproto-push-rsp-activity-info",
                ))
                tag = "sproto-req-activity-info-resp"
                _append_utf8_log("[TCP] req_activity_info -> pushed active activities")

            elif msg_type == 1091:
                _init_task_tables()
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqGetActivityReward.request", req_body, {0, 1})
                activity_id = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_GET_ACTIVITY_REWARD_REQ_ACTIVITY_ID), 0))
                task_id = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_GET_ACTIVITY_REWARD_REQ_TASK_ID), 0))

                claimed_act_tasks = pd.setdefault("claimed_activity_tasks", [])
                if task_id > 0 and task_id not in claimed_act_tasks:
                    claimed_act_tasks.append(task_id)

                act_info = _ACTIVITY_TASK_TABLE.get(task_id, {})
                rewards = act_info.get("rewards", [])
                granted, reward_items, added_gold, added_diamond = _grant_rewards_to_player(pd, rewards)
                _save_player_data()

                body = [
                    (_TAG_REQ_GET_ACTIVITY_REWARD_RESP_ACTIVITY_ID, activity_id),
                    (_TAG_REQ_GET_ACTIVITY_REWARD_RESP_TASK_ID, task_id),
                    (_TAG_REQ_GET_ACTIVITY_REWARD_RESP_ERRORCODE, 0),
                ]

                if reward_items:
                    reward_entries = [
                        _sproto_encode_fields([(0, rid), (1, num)])
                        for rid, num in reward_items
                    ]
                    extra_pushes.append((
                        _sproto_build_push_frame(141, [
                            (0, _TCPHandler._sproto_build_struct_list(reward_entries)),
                            (1, 0),
                        ]),
                        "sproto-push-get-reward-notify-activity",
                    ))

                if added_gold > 0 or added_diamond > 0:
                    extra_pushes.extend(self._build_money_pushes(pd))

                # Push updated single activity task state=5 (AlreadyGet)
                updated_act_task = _sproto_encode_fields([
                    (_TAG_ACTIVITY_TASK_INFO_ID, task_id),
                    (_TAG_ACTIVITY_TASK_INFO_STATE, 5),
                    (_TAG_ACTIVITY_TASK_INFO_VALUE, 1),
                    (_TAG_ACTIVITY_TASK_INFO_MAX_VALUE, 1),
                ])
                updated_act_info = _sproto_encode_fields([
                    (_TAG_ACTIVITY_INFO_ID, activity_id),
                    (_TAG_ACTIVITY_INFO_IS_IN_TIME, True),
                    (_TAG_ACTIVITY_INFO_TASKS, _TCPHandler._sproto_build_struct_list([updated_act_task])),
                    (_TAG_ACTIVITY_INFO_VALUES, _TCPHandler._sproto_build_struct_list([])),
                ])
                extra_pushes.append((
                    _sproto_build_push_frame(1114, [
                        (_TAG_RSP_SYNC_CHANGED_ACTIVITY_INFO_INFO, updated_act_info),
                    ]),
                    "sproto-push-rsp-sync-changed-activity-info",
                ))

                extra_pushes.append((
                    _sproto_build_push_frame(1093, [
                        (0, activity_id),
                        (1, task_id),
                    ]),
                    "sproto-push-rsp-activity-finish",
                ))
                tag = "sproto-req-get-activity-reward-resp"
                _append_utf8_log(
                    f"[TCP] req_get_activity_reward activity_id={activity_id} task_id={task_id} granted={granted}"
                )

            elif msg_type == 1094:
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqActivityExchangeInfo.request", req_body, {0})
                activity_id = max(0, _TCPHandler._sproto_read_int(req_body.get(0), 0))
                body = None
                extra_pushes.append((
                    _sproto_build_push_frame(1095, [
                        (0, activity_id),
                        (1, _TCPHandler._sproto_build_struct_list([])),
                        (2, _TCPHandler._sproto_build_struct_list([])),
                    ]),
                    "sproto-push-rsp-activity-exchange-info",
                ))
                tag = "sproto-req-activity-exchange-info-noop"
                _append_utf8_log(f"[TCP] req_activity_exchange_info activity_id={activity_id}")

            elif msg_type == 1096:
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqActivityExchange.request", req_body, {0, 1})
                activity_id = max(0, _TCPHandler._sproto_read_int(req_body.get(0), 0))
                exchange_id = max(0, _TCPHandler._sproto_read_int(req_body.get(1), 0))
                body = None
                extra_pushes.append((
                    _sproto_build_push_frame(1095, [
                        (0, activity_id),
                        (1, _TCPHandler._sproto_build_struct_list([])),
                        (2, _TCPHandler._sproto_build_struct_list([])),
                    ]),
                    "sproto-push-rsp-activity-exchange-info",
                ))
                tag = "sproto-req-activity-exchange-noop"
                _append_utf8_log(
                    f"[TCP] req_activity_exchange activity_id={activity_id} exchange_id={exchange_id}"
                )

            elif msg_type == 1101:
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqOperateVoiceChannel.request", req_body, {0})
                operate_type = max(0, _TCPHandler._sproto_read_int(req_body.get(0), 0))
                self_uid = self._session_uid(pd)
                channel_id = f"local-voice-{self_uid}"
                if operate_type == 0:
                    channel_id = ""
                _team_state["voice_channel_id"] = channel_id
                body = None
                extra_pushes.append((
                    _sproto_build_push_frame(1035, [
                        (0, channel_id),
                    ]),
                    "sproto-push-rsp-voice-channel",
                ))
                _TCPHandler._queue_team_pushes(extra_pushes[-1:], exclude_uid=self_uid)
                tag = "sproto-req-operate-voice-channel-noop"
                _append_utf8_log(
                    f"[TCP] req_operate_voice_channel operate_type={operate_type} channel={channel_id!r}"
                )

            elif msg_type == 1036:
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqChangeVoiceState.request", req_body, {0})
                state = max(0, _TCPHandler._sproto_read_int(req_body.get(0), 0))
                self_uid = self._session_uid(pd)
                _team_state["voice_state"] = state
                body = None
                extra_pushes.append((
                    _sproto_build_push_frame(1037, [
                        (0, state),
                        (1, self_uid),
                    ]),
                    "sproto-push-rsp-change-voice-state",
                ))
                _TCPHandler._queue_team_pushes(extra_pushes[-1:], exclude_uid=self_uid)
                tag = "sproto-req-change-voice-state-noop"
                _append_utf8_log(f"[TCP] req_change_voice_state state={state} uid={self_uid}")

            elif msg_type == 13:
                body = None
                tag = "sproto-notify-reload-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] notify_reload from client ignored req_body={req_body}")
            elif msg_type == 14:
                body = None
                tag = "sproto-notify-kick-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] notify_kick from client ignored req_body={req_body}")
            elif msg_type == 305:
                body = None
                tag = "sproto-invite-punish-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] invite_punish_notify from client ignored req_body={req_body}")
            elif msg_type == 405:
                body = None
                tag = "sproto-team-member-leave-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] team_member_leave_notify from client ignored req_body={req_body}")
            elif msg_type == 411:
                body = None
                tag = "sproto-team-match-success-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] match_success_notify from client ignored req_body={req_body}")
            elif msg_type == 414:
                body = None
                tag = "sproto-team-match-timeout-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] match_timeout_notify from client ignored req_body={req_body}")
            elif msg_type == 421:
                body = None
                tag = "sproto-team-match-punish-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] team_match_punish_notify from client ignored req_body={req_body}")
            elif msg_type == 503:
                body = None
                tag = "sproto-mail-new-mail-client-noop"
                if req_body:
                    _append_utf8_log(f"[TCP] mail_new_mail_notify from client ignored req_body={req_body}")

            elif msg_type in {413, 415, 416, 1035, 1037, 1093, 1095, 1097}:
                body = None
                tag = f"sproto-client-sent-push-contract-{msg_type}-noop"
                if req_body:
                    _append_utf8_log(
                        f"[TCP] client-sent push contract ignored type={msg_type} req_body={req_body}"
                    )

            elif msg_type == 1083:
                # game_ReqPingBattleZoneList -> response: errorcode(0), battle_zones(1)
                client_ip = self.request.getsockname()[0] if hasattr(self, "request") and self.request else BATTLE_PUBLIC_HOST
                if client_ip in ("0.0.0.0", "::"):
                    client_ip = BATTLE_PUBLIC_HOST
                zone = _sproto_encode_fields([
                    (_TAG_BATTLE_ZONE_ID, 1),
                    (_TAG_BATTLE_ZONE_ADDRESS, f"{client_ip}:{BATTLE_ZONE_PORT}"),
                    (_TAG_BATTLE_ZONE_NAME_KEY, 1),
                    (_TAG_BATTLE_ZONE_REGION_NAME, "Local Server"),
                ])
                import struct as _st
                zone_list = _st.pack('<I', len(zone)) + zone
                body = [
                    (_TAG_REQ_PING_BATTLE_ZONE_RESP_ERRORCODE, 0),
                    (_TAG_REQ_PING_BATTLE_ZONE_RESP_BATTLE_ZONES, zone_list),
                ]
                tag = "sproto-battle-zone-list-resp"

            elif msg_type == 1050:
                # game_ReqUserGuide -> response: errorcode(0)
                # Then PUSH RspUserGuideRoundStart (1100) + RspBattleInfo (1029)
                gs = _game_state
                req_guide_id = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_USER_GUIDE_GUIDE_ID), 1)
                req_battle_zone = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_USER_GUIDE_BATTLE_ZONE),
                    _TCPHandler._sproto_read_int(gs.get("battle_zone"), 1),
                )
                guide_entry = _TCPHandler._resolve_user_guide_entry(req_guide_id)

                gs["mode_id"] = guide_entry["mode_id"]
                gs["map_id"] = guide_entry["map_id"]
                gs["camp"] = 1          # guide always starts as attacker
                gs["team"] = 1
                gs["guide_id"] = guide_entry["guide_id"]
                # Guide script expects attacker-side tutorial loadout
                # (including UAV flow in Level1_States). If previous mode left
                # defender character selected, drone UI can be absent.
                _TCPHandler._ensure_character_selection_for_camp(
                    gs,
                    preferred_character_id=1,
                    force_loadout=True,
                )
                if req_battle_zone > 0:
                    gs["battle_zone"] = req_battle_zone
                gs["battle_id"] += 1
                gs["_confirm_sent"] = True  # mark as sent (from guide)
                gs["_confirm_pending"] = False

                body = [(_TAG_REQ_USER_GUIDE_RESP_ERRORCODE, 0)]
                tag = "sproto-req-user-guide-resp"

                # Push 1: RspUserGuideRoundStart
                push1_body = [
                    (_TAG_RSP_USER_GUIDE_ROUND, 1),
                    (_TAG_RSP_USER_GUIDE_MAP_ID, _TCPHandler._sproto_read_int(gs.get("map_id"), guide_entry["map_id"])),
                    (_TAG_RSP_USER_GUIDE_MODE_ID, _TCPHandler._sproto_read_int(gs.get("mode_id"), guide_entry["mode_id"])),
                    (_TAG_RSP_USER_GUIDE_WAIT_TIME, _GUIDE_ROUND_WAIT_TIME),
                    (_TAG_RSP_USER_GUIDE_TEAM, _TCPHandler._sproto_read_int(gs.get("team"), 1)),
                    (_TAG_RSP_USER_GUIDE_CAMP, _TCPHandler._sproto_read_int(gs.get("camp"), 1)),
                ]
                extra_pushes.append((_sproto_build_push_frame(1100, push1_body),
                                     "sproto-push-user-guide-round-start"))

                # Push 2: RspBattleInfo -> client connects to battle server
                battle_info = self._build_battle_info_push(gs)
                extra_pushes.append((battle_info, "sproto-push-battle-info"))

            elif msg_type == 1051:
                # game_ReqOpenMode -> response: errorcode(0)
                # Then PUSH RspOpenMode (1052)
                gs = _game_state
                req_mode = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_OPEN_MODE_MODE_ID), 3)
                gs["mode_id"] = req_mode if req_mode > 0 else 3
                gs["prebattle_stage"] = 1
                gs["_prebattle_loadout_seeded"] = False
                gs["_prebattle_choose_character_pushed"] = False
                gs["prebattle_room_started"] = False
                gs["prebattle_flow_active"] = False
                gs["_confirm_sent"] = False  # new mode -> allow new battle
                gs["_confirm_pending"] = False
                gs["_last_confirm_push_ts"] = 0.0
                gs["spawn_region_id"] = _TCPHandler._resolve_spawn_region(gs, None)
                gs["region_id"] = _TCPHandler._resolve_spawn_region(gs, gs.get("spawn_region_id"))
                selected_character_id = _TCPHandler._ensure_character_selection_for_camp(gs)
                if _TCPHandler._sproto_read_int(gs.get("mode_id"), 0) == 3:
                    _TCPHandler._room_reset()
                    gs["team"] = _TCPHandler._team_id_for_training_camp(
                        gs.get("camp"),
                        _TCPHandler._sproto_read_int(gs.get("team"), 1),
                    )
                _persist_training_profile(save=True)

                body = [(_TAG_REQ_OPEN_MODE_RESP_ERRORCODE, 0)]
                tag = "sproto-req-open-mode-resp"
                push_body = [
                    (_TAG_RSP_OPEN_MODE_MODE_ID, gs["mode_id"]),
                    (_TAG_RSP_OPEN_MODE_MAP_ID, gs["map_id"]),
                    (_TAG_RSP_OPEN_MODE_CAMP, gs["camp"]),
                ]
                extra_pushes.append((_sproto_build_push_frame(1052, push_body),
                                     "sproto-push-rsp-open-mode"))

            elif msg_type == 1053:
                # game_ReqModeChooseMap -> no response payload in source contract
                req_map = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_MODE_CHOOSE_MAP_MAP_ID), 1)
                if req_map > 0:
                    _game_state["map_id"] = req_map
                body = None
                tag = "sproto-mode-choose-map-resp"

            elif msg_type == 1054:
                # game_ReqModeChooseCamp -> no response payload in source contract
                req_camp = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_MODE_CHOOSE_CAMP_CAMP), 1)
                if req_camp > 0:
                    prev_camp = _TCPHandler._sproto_read_int(_game_state.get("camp"), 1)
                    _game_state["camp"] = req_camp
                    if _TCPHandler._sproto_read_int(_game_state.get("mode_id"), 0) == 3:
                        _game_state["team"] = _TCPHandler._team_id_for_training_camp(
                            req_camp,
                            _TCPHandler._sproto_read_int(_game_state.get("team"), 1),
                        )
                    # Attacker/defender use different prebattle region-id namespaces.
                    # Reset to camp default on camp switch so UI highlight is canonical.
                    if prev_camp != req_camp:
                        _game_state["spawn_region_id"] = _TCPHandler._resolve_spawn_region(_game_state, None)
                        _game_state["region_id"] = _TCPHandler._resolve_spawn_region(
                            _game_state,
                            _game_state.get("spawn_region_id"),
                        )
                        _game_state["_prebattle_loadout_seeded"] = False
                        _game_state["_prebattle_choose_character_pushed"] = False
                    if not _TCPHandler._spawn_region_is_valid_for_camp(
                        _game_state.get("camp"),
                        _game_state.get("spawn_region_id"),
                    ):
                        _game_state["spawn_region_id"] = _TCPHandler._resolve_spawn_region(_game_state, None)
                    if not _TCPHandler._spawn_region_is_valid_for_camp(
                        _game_state.get("camp"),
                        _game_state.get("region_id"),
                    ):
                        _game_state["region_id"] = _TCPHandler._resolve_spawn_region(
                            _game_state,
                            _game_state.get("spawn_region_id"),
                        )
                    _TCPHandler._ensure_character_selection_for_camp(_game_state)
                    _persist_training_profile(save=True)
                body = None
                tag = "sproto-mode-choose-camp-resp"

            elif msg_type == 1017:
                # game_ReqChooseMap -> notify room with RspChooseMap (1092)
                gs = _game_state
                current_mode = _TCPHandler._sproto_read_int(gs.get("mode_id"), 3)
                req_map = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_CHOOSE_MAP_MAP_ID),
                    _TCPHandler._sproto_read_int(gs.get("map_id"), 1),
                )
                req_mode = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_CHOOSE_MAP_MODE_ID),
                    _TCPHandler._sproto_read_int(gs.get("mode_id"), 3),
                )
                if req_map > 0:
                    gs["map_id"] = req_map
                if req_mode > 0:
                    prebattle_active = bool(gs.get("prebattle_flow_active")) or bool(gs.get("prebattle_room_started"))
                    if current_mode == 3 and prebattle_active and req_mode != 3:
                        _log_line = (
                            "[TCP] choose_map ignored mode switch during active training prebattle "
                            f"(requested={req_mode})"
                        )
                        print(_console_safe(_log_line)); _append_utf8_log(_log_line)
                    else:
                        gs["mode_id"] = req_mode
                if _TCPHandler._room_is_active():
                    _room_state["map_id"] = max(1, _TCPHandler._sproto_read_int(gs.get("map_id"), 1))
                    _room_state["mode_id"] = max(0, _TCPHandler._sproto_read_int(gs.get("mode_id"), 0))

                body = [
                    (_TAG_RSP_CHOOSE_MAP_MAP_ID, _TCPHandler._sproto_read_int(gs.get("map_id"), 1)),
                    (_TAG_RSP_CHOOSE_MAP_MODE_ID, _TCPHandler._sproto_read_int(gs.get("mode_id"), 3)),
                ]
                tag = "sproto-choose-map-resp"
                choose_map_push = (_sproto_build_push_frame(1092, body), "sproto-push-choose-map")
                if session == 0:
                    extra_pushes.append(choose_map_push)
                if _TCPHandler._room_is_active():
                    room_snapshot = _TCPHandler._room_snapshot_pushes()
                    extra_pushes.extend(room_snapshot)
                    self_uid = self._session_uid(pd)
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, choose_map_push)
                            _TCPHandler._queue_pending_pushes(p_uid, room_snapshot)

            elif msg_type == 1020:
                # game_ReqChooseCharacter -> respond: uid, character_id, primary_weapon_id, skins
                char_id = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_CHOOSE_CHARACTER_CHARACTER_ID), 1)
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                player_camp = 1
                if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                    player_camp = max(1, _safe_int(_room_state["players"][str(self_uid)].get("camp"), 1))
                else:
                    player_camp = max(1, _TCPHandler._sproto_read_int(_game_state.get("camp"), 1))

                player_gs = dict(_game_state)
                player_gs["camp"] = player_camp
                player_gs["character_id"] = char_id
                body, selected_char_id = _TCPHandler._build_choose_character_response_body(
                    player_gs,
                    player_pd,
                    preferred_character_id=char_id,
                    force_loadout=False,
                )
                if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                    _room_state["players"][str(self_uid)]["character_id"] = selected_char_id
                    _room_state["players"][str(self_uid)]["primary_weapon"] = player_gs.get("primary_weapon")
                    _room_state["players"][str(self_uid)]["secondary_weapon"] = player_gs.get("secondary_weapon")
                    _room_state["players"][str(self_uid)]["main_skill_id"] = player_gs.get("main_skill_id")
                    _room_state["players"][str(self_uid)]["sub_skill_id"] = player_gs.get("sub_skill_id")

                _game_state["character_id"] = selected_char_id
                _game_state["camp"] = player_camp
                _game_state["primary_weapon"] = player_gs.get("primary_weapon")
                _game_state["secondary_weapon"] = player_gs.get("secondary_weapon")
                _game_state["main_skill_id"] = player_gs.get("main_skill_id")
                _game_state["sub_skill_id"] = player_gs.get("sub_skill_id")
                _player_data["character_id"] = selected_char_id

                if self_uid == _safe_int(_player_data.get("uid")):
                    _TCPHandler._set_show_character_id(selected_char_id)
                    _game_state["_prebattle_choose_character_pushed"] = True
                    _persist_training_profile(save=True)

                tag = "sproto-choose-character-resp"
                choose_push = (_sproto_build_push_frame(1021, body), "sproto-push-choose-character")
                extra_pushes.append(choose_push)
                _TCPHandler._append_prebattle_info_push(
                    extra_pushes,
                    player_gs,
                    player_pd,
                    tag="sproto-push-pre-battle-info-character",
                    ensure_choose_character_push=False,
                )

                if _TCPHandler._room_is_active():
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, choose_push)
                            other_pd = _online_ensure_profile(p_uid)
                            other_p_entry = _room_state["players"][str(p_uid)]
                            other_camp = max(1, _safe_int(other_p_entry.get("camp"), 1))
                            other_gs = dict(_game_state)
                            other_gs["camp"] = other_camp
                            if other_p_entry.get("character_id"):
                                other_gs["character_id"] = other_p_entry["character_id"]
                            if other_p_entry.get("primary_weapon"):
                                other_gs["primary_weapon"] = other_p_entry["primary_weapon"]
                            if other_p_entry.get("secondary_weapon"):
                                other_gs["secondary_weapon"] = other_p_entry["secondary_weapon"]
                            if other_p_entry.get("main_skill_id"):
                                other_gs["main_skill_id"] = other_p_entry["main_skill_id"]
                            if other_p_entry.get("sub_skill_id"):
                                other_gs["sub_skill_id"] = other_p_entry["sub_skill_id"]
                            if other_p_entry.get("region_id"):
                                other_gs["region_id"] = other_p_entry["region_id"]
                                other_gs["spawn_region_id"] = other_p_entry["region_id"]
                            other_pushes: list[tuple[bytes, str]] = []
                            _TCPHandler._append_prebattle_info_push(
                                other_pushes,
                                other_gs,
                                other_pd,
                                tag="sproto-push-pre-battle-info-character-sync",
                                ensure_choose_character_push=False,
                            )
                            _TCPHandler._queue_pending_pushes(p_uid, other_pushes)

            elif msg_type == 1022:
                # game_ReqChooseWeaponInfo -> respond with available weapons for current character
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                is_room = _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {})
                p_entry = _room_state["players"][str(self_uid)] if is_room else None

                if is_room and p_entry:
                    player_camp = max(1, _safe_int(p_entry.get("camp"), 1))
                    selected_character_id = max(1, _safe_int(p_entry.get("character_id"), 1 if player_camp == 1 else 101))
                    primary_weapon = p_entry.get("primary_weapon")
                    if not isinstance(primary_weapon, dict):
                        primary_weapon = {}
                        p_entry["primary_weapon"] = primary_weapon
                    secondary_weapon = p_entry.get("secondary_weapon")
                    if not isinstance(secondary_weapon, dict):
                        secondary_weapon = {}
                        p_entry["secondary_weapon"] = secondary_weapon
                    main_skill_id_val = p_entry.get("main_skill_id")
                    sub_skill_id_val = p_entry.get("sub_skill_id")
                else:
                    gs = _game_state
                    selected_character_id = _TCPHandler._ensure_character_selection_for_camp(gs)
                    primary_weapon = gs.get("primary_weapon")
                    if not isinstance(primary_weapon, dict):
                        primary_weapon = {}
                        gs["primary_weapon"] = primary_weapon
                    secondary_weapon = gs.get("secondary_weapon")
                    if not isinstance(secondary_weapon, dict):
                        secondary_weapon = {}
                        gs["secondary_weapon"] = secondary_weapon
                    main_skill_id_val = gs.get("main_skill_id")
                    sub_skill_id_val = gs.get("sub_skill_id")

                primary_attachments = _TCPHandler._normalize_attachment_list(primary_weapon.get("attachments"))
                secondary_attachments = _TCPHandler._normalize_attachment_list(secondary_weapon.get("attachments"))
                primary_weapon["attachments"] = primary_attachments
                secondary_weapon["attachments"] = secondary_attachments
                primary_options, secondary_options, main_options, sub_options = _TCPHandler._character_loadout_options(
                    selected_character_id
                )

                pri_id = _TCPHandler._sproto_read_int(primary_weapon.get("id"), primary_options[0])
                if pri_id not in primary_options:
                    pri_id = primary_options[0]
                primary_weapon["id"] = pri_id

                sec_id = _TCPHandler._sproto_read_int(secondary_weapon.get("id"), secondary_options[0])
                if sec_id not in secondary_options:
                    sec_id = secondary_options[0]
                secondary_weapon["id"] = sec_id

                main_skill_id = _TCPHandler._sproto_read_int(main_skill_id_val, main_options[0])
                if main_skill_id not in main_options:
                    main_skill_id = main_options[0]
                if is_room and p_entry:
                    p_entry["main_skill_id"] = main_skill_id
                else:
                    _game_state["main_skill_id"] = main_skill_id

                sub_skill_id = _TCPHandler._sproto_read_int(sub_skill_id_val, sub_options[0])
                if sub_skill_id not in sub_options:
                    sub_skill_id = sub_options[0]
                if is_room and p_entry:
                    p_entry["sub_skill_id"] = sub_skill_id
                else:
                    _game_state["sub_skill_id"] = sub_skill_id

                pri_structs: list[bytes] = []
                for weapon_id in primary_options:
                    attachments = primary_attachments if weapon_id == pri_id else []
                    pri_structs.append(_encode_game_weapon_info(weapon_id, attachments))
                pri_list = _TCPHandler._sproto_build_struct_list(pri_structs)

                sec_structs: list[bytes] = []
                for weapon_id in secondary_options:
                    attachments = secondary_attachments if weapon_id == sec_id else []
                    sec_structs.append(_encode_game_weapon_info(weapon_id, attachments))
                sec_list = _TCPHandler._sproto_build_struct_list(sec_structs)

                main_list = _TCPHandler._sproto_build_integer_list(main_options)
                sub_list = _TCPHandler._sproto_build_integer_list(sub_options)
                body = [
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_CUR_PRIMARY, pri_id),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_PRIMARY_WEAPONS, pri_list),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_CUR_SECONDARY, sec_id),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_SECONDARY_WEAPONS, sec_list),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_CUR_MAIN_SKILL, main_skill_id),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_MAIN_SKILLS, main_list),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_CUR_SUB_SKILL, sub_skill_id),
                    (_TAG_RSP_CHOOSE_WEAPON_INFO_SUB_SKILLS, sub_list),
                ]
                tag = "sproto-choose-weapon-info-resp"
                if session == 0:
                    extra_pushes.append((
                        _sproto_build_push_frame(1023, body),
                        "sproto-push-choose-weapon-info",
                    ))

            elif msg_type == 1024:
                # game_ReqChooseWeapon -> save weapon, respond: success(0), kind(1), id(2)
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                is_room = _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {})
                p_entry = _room_state["players"][str(self_uid)] if is_room else None

                gs = dict(_game_state) if not is_room else _room_state["players"][str(self_uid)]
                pd = player_pd
                kind = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_CHOOSE_WEAPON_KIND), 0)   # 0=primary,1=secondary,2=main_skill,3=sub_skill
                wid = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_CHOOSE_WEAPON_ID), 0)
                req_has_attachments_field = (
                    isinstance(req_body, dict)
                    and _TAG_REQ_CHOOSE_WEAPON_ATTACHMENTS in req_body
                )
                req_attachments = _TCPHandler._normalize_attachment_list(
                    req_body.get(_TAG_REQ_CHOOSE_WEAPON_ATTACHMENTS)
                ) if req_has_attachments_field else []
                rsp_attachments: list[dict[str, int]] = []
                if kind == 0:
                    current_primary = gs.get("primary_weapon")
                    if not isinstance(current_primary, dict):
                        current_primary = {}
                    current_primary_id = _TCPHandler._sproto_read_int(current_primary.get("id"), 10036)
                    if wid <= 0:
                        wid = current_primary_id
                    weapon_changed = wid != current_primary_id
                    previous_attachments = _TCPHandler._normalize_attachment_list(
                        current_primary.get("attachments")
                    )
                    req_has_real = _TCPHandler._attachment_list_has_real_items(req_attachments)
                    previous_has_real = _TCPHandler._attachment_list_has_real_items(previous_attachments)
                    if req_has_attachments_field:
                        if req_has_real or not previous_has_real or weapon_changed:
                            merged_attachments = req_attachments
                        else:
                            merged_attachments = previous_attachments
                    else:
                        merged_attachments = previous_attachments
                    current_character_id = _TCPHandler._sproto_read_int(gs.get("character_id"), 0)
                    new_primary = {
                        "id": wid,
                        "skin": _TCPHandler._selected_weapon_visual_skin_id(
                            current_character_id,
                            wid,
                            current_primary.get("skin"),
                        ),
                        "attachments": merged_attachments,
                    }
                    gs["primary_weapon"] = new_primary
                    player_pd["primary_weapon"] = new_primary
                    if is_room and p_entry:
                        p_entry["primary_weapon"] = new_primary
                    if self_uid == _safe_int(_player_data.get("uid")):
                        _game_state["primary_weapon"] = new_primary
                    rsp_attachments = merged_attachments
                elif kind == 1:
                    current_secondary = gs.get("secondary_weapon")
                    if not isinstance(current_secondary, dict):
                        current_secondary = {}
                    current_secondary_id = _TCPHandler._sproto_read_int(current_secondary.get("id"), 10074)
                    if wid <= 0:
                        wid = current_secondary_id
                    weapon_changed = wid != current_secondary_id
                    previous_attachments = _TCPHandler._normalize_attachment_list(
                        current_secondary.get("attachments")
                    )
                    req_has_real = _TCPHandler._attachment_list_has_real_items(req_attachments)
                    previous_has_real = _TCPHandler._attachment_list_has_real_items(previous_attachments)
                    if req_has_attachments_field:
                        if req_has_real or not previous_has_real or weapon_changed:
                            merged_attachments = req_attachments
                        else:
                            merged_attachments = previous_attachments
                    else:
                        merged_attachments = previous_attachments
                    current_character_id = _TCPHandler._sproto_read_int(gs.get("character_id"), 0)
                    new_secondary = {
                        "id": wid,
                        "skin": _TCPHandler._selected_weapon_visual_skin_id(
                            current_character_id,
                            wid,
                            current_secondary.get("skin"),
                        ),
                        "attachments": merged_attachments,
                    }
                    gs["secondary_weapon"] = new_secondary
                    player_pd["secondary_weapon"] = new_secondary
                    if is_room and p_entry:
                        p_entry["secondary_weapon"] = new_secondary
                    if self_uid == _safe_int(_player_data.get("uid")):
                        _game_state["secondary_weapon"] = new_secondary
                    rsp_attachments = merged_attachments
                elif kind == 2:
                    gs["main_skill_id"] = wid
                    player_pd["main_skill_id"] = wid
                    if is_room and p_entry:
                        p_entry["main_skill_id"] = wid
                    if self_uid == _safe_int(_player_data.get("uid")):
                        _game_state["main_skill_id"] = wid
                elif kind == 3:
                    gs["sub_skill_id"] = wid
                    player_pd["sub_skill_id"] = wid
                    if is_room and p_entry:
                        p_entry["sub_skill_id"] = wid
                    if self_uid == _safe_int(_player_data.get("uid")):
                        _game_state["sub_skill_id"] = wid
                _persist_training_profile(save=True)
                body = [
                    (_TAG_RSP_CHOOSE_WEAPON_SUCCESS, 1),
                    (_TAG_RSP_CHOOSE_WEAPON_KIND, kind),
                    (_TAG_RSP_CHOOSE_WEAPON_ID, wid),
                ]
                if kind in (0, 1):
                    rsp_attachments_blob = _encode_game_attachment_list(rsp_attachments)
                    if rsp_attachments_blob:
                        body.append((_TAG_RSP_CHOOSE_WEAPON_ATTACHMENTS, rsp_attachments_blob))
                tag = "sproto-choose-weapon-resp"
                choose_weapon_push = (_sproto_build_push_frame(1025, body), "sproto-push-choose-weapon")
                if session == 0:
                    extra_pushes.append(choose_weapon_push)
                _TCPHandler._append_prebattle_info_push(
                    extra_pushes,
                    gs,
                    pd,
                    tag="sproto-push-pre-battle-info-weapon",
                )
                if is_room:
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, choose_weapon_push)

            elif msg_type == 1015:
                # game_ReqEnterPreBattleStage -> response: uid, success, stage
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                player_camp = 1
                if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                    player_camp = max(1, _safe_int(_room_state["players"][str(self_uid)].get("camp"), 1))
                else:
                    player_camp = max(1, _safe_int(_game_state.get("camp"), 1))

                player_gs = dict(_game_state)
                player_gs["camp"] = player_camp
                prebattle_was_started = bool(_game_state.get("prebattle_room_started", False))
                req_stage = _TCPHandler._sproto_read_int(
                    req_body.get(_TAG_REQ_ENTER_PRE_BATTLE_STAGE_STAGE),
                    _TCPHandler._sproto_read_int(_game_state.get("prebattle_stage"), 1),
                )
                req_stage = _TCPHandler._normalize_prebattle_stage(req_stage, 1)

                if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                    _room_state["players"][str(self_uid)]["prebattle_stage"] = req_stage
                    if req_stage >= 4:
                        _room_state["players"][str(self_uid)]["is_ready"] = True
                else:
                    _game_state["prebattle_stage"] = req_stage

                player_gs["prebattle_stage"] = req_stage
                _game_state["prebattle_room_started"] = True
                _game_state["prebattle_flow_active"] = True

                body = [
                    (_TAG_RSP_ENTER_PRE_BATTLE_STAGE_UID, self_uid),
                    (_TAG_RSP_ENTER_PRE_BATTLE_STAGE_SUCCESS, True),
                    (_TAG_RSP_ENTER_PRE_BATTLE_STAGE_STAGE, req_stage),
                ]
                tag = "sproto-enter-pre-battle-stage-resp"
                stage_push = (_sproto_build_push_frame(1016, body), "sproto-push-enter-pre-battle-stage")
                if session == 0:
                    extra_pushes.append(stage_push)

                _TCPHandler._append_prebattle_info_push(
                    extra_pushes,
                    player_gs,
                    player_pd,
                    tag="sproto-push-pre-battle-info-stage",
                    ensure_choose_character_push=False,
                )

                if _TCPHandler._room_is_active():
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, stage_push)
                            other_pd = _online_ensure_profile(p_uid)
                            other_p_entry = _room_state["players"][str(p_uid)]
                            other_camp = max(1, _safe_int(other_p_entry.get("camp"), 1))
                            other_gs = dict(_game_state)
                            other_gs["camp"] = other_camp
                            if other_p_entry.get("character_id"):
                                other_gs["character_id"] = other_p_entry["character_id"]
                            if other_p_entry.get("primary_weapon"):
                                other_gs["primary_weapon"] = other_p_entry["primary_weapon"]
                            if other_p_entry.get("secondary_weapon"):
                                other_gs["secondary_weapon"] = other_p_entry["secondary_weapon"]
                            if other_p_entry.get("main_skill_id"):
                                other_gs["main_skill_id"] = other_p_entry["main_skill_id"]
                            if other_p_entry.get("sub_skill_id"):
                                other_gs["sub_skill_id"] = other_p_entry["sub_skill_id"]
                            if other_p_entry.get("region_id"):
                                other_gs["region_id"] = other_p_entry["region_id"]
                                other_gs["spawn_region_id"] = other_p_entry["region_id"]
                            other_pushes: list[tuple[bytes, str]] = []
                            _TCPHandler._append_prebattle_info_push(
                                other_pushes,
                                other_gs,
                                other_pd,
                                tag="sproto-push-pre-battle-info-stage-notify",
                                ensure_choose_character_push=False,
                            )
                            _TCPHandler._queue_pending_pushes(p_uid, other_pushes)

                if req_stage >= 4:
                    _TCPHandler._check_and_launch_room_battle(extra_pushes)

            elif msg_type == 1018:
                # game_ReqChooseSpawnRegionConfirm -> response: uid, region_id
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                is_room = _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {})
                p_entry = _room_state["players"][str(self_uid)] if is_room else None

                gs = dict(_game_state) if not is_room else _room_state["players"][str(self_uid)]
                prebattle_was_started = bool(_game_state.get("prebattle_room_started", False))
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqChooseSpawnRegionConfirm.request", req_body, {
                    _TAG_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REGION_ID,
                })
                tagged_region_raw = req_body.get(_TAG_REQ_CHOOSE_SPAWN_REGION_CONFIRM_REGION_ID)
                fallback_region_raw = None
                if tagged_region_raw is None and isinstance(req_body, dict):
                    fallback_region_raw = req_body.get("region_id")
                    if fallback_region_raw is None:
                        numeric_keys = [key for key in req_body.keys() if isinstance(key, int)]
                        for key in sorted(numeric_keys):
                            candidate_raw = req_body.get(key)
                            if candidate_raw is None:
                                continue
                            candidate_id = _TCPHandler._sproto_read_int(candidate_raw, -1)
                            if candidate_id >= 0:
                                fallback_region_raw = candidate_raw
                                break
                prev_region = _TCPHandler._resolve_spawn_region(
                    gs,
                    gs.get("spawn_region_id", gs.get("region_id")),
                )
                chosen_region_raw = tagged_region_raw if tagged_region_raw is not None else fallback_region_raw
                if chosen_region_raw is None:
                    req_region = prev_region
                else:
                    req_region = _TCPHandler._resolve_spawn_region(gs, chosen_region_raw)
                gs["spawn_region_id"] = req_region
                gs["region_id"] = req_region
                player_pd["spawn_region_id"] = req_region
                player_pd["region_id"] = req_region
                if is_room and p_entry:
                    p_entry["spawn_region_id"] = req_region
                    p_entry["region_id"] = req_region
                if self_uid == _safe_int(_player_data.get("uid")):
                    _game_state["spawn_region_id"] = req_region
                    _game_state["region_id"] = req_region
                    _game_state["prebattle_room_started"] = True
                    _game_state["prebattle_flow_active"] = True
                    if not prebattle_was_started:
                        _game_state["prebattle_stage"] = 1
                        _game_state["_prebattle_loadout_seeded"] = False
                        _game_state["_prebattle_choose_character_pushed"] = False
                    elif _TCPHandler._sproto_read_int(_game_state.get("prebattle_stage"), 0) <= 0:
                        _game_state["prebattle_stage"] = 1
                        _game_state["_prebattle_loadout_seeded"] = False
                        _game_state["_prebattle_choose_character_pushed"] = False
                    _TCPHandler._ensure_character_selection_for_camp(_game_state)
                _persist_training_profile(save=True)
                tagged_region_dbg = "None"
                if tagged_region_raw is not None:
                    tagged_region_dbg = str(_TCPHandler._sproto_read_int(tagged_region_raw, -1))
                fallback_region_dbg = "None"
                if fallback_region_raw is not None:
                    fallback_region_dbg = str(_TCPHandler._sproto_read_int(fallback_region_raw, -1))
                _log_line = (
                    "[TCP] choose_spawn_region "
                    f"tag={tagged_region_dbg} fallback={fallback_region_dbg} "
                    f"prev={prev_region} resolved={req_region}"
                )
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
                body = [
                    (_TAG_RSP_CHOOSE_SPAWN_REGION_CONFIRM_UID, self_uid),
                    (_TAG_RSP_CHOOSE_SPAWN_REGION_CONFIRM_REGION_ID, req_region),
                ]
                tag = "sproto-choose-spawn-region-confirm-resp"
                region_push = (_sproto_build_push_frame(1019, body), "sproto-push-choose-spawn-region-confirm")
                if session == 0:
                    extra_pushes.append(region_push)
                _TCPHandler._append_prebattle_info_push(
                    extra_pushes,
                    gs,
                    player_pd,
                    tag="sproto-push-pre-battle-info-region",
                )
                if is_room:
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, region_push)

            elif msg_type == 1043:
                # game_ReqPreBattleInfo -> respond with current selection
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                player_camp = 1
                player_gs = dict(_game_state)
                if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                    p_entry = _room_state["players"][str(self_uid)]
                    player_camp = max(1, _safe_int(p_entry.get("camp"), 1))
                    player_gs["camp"] = player_camp
                    p_char = max(1, _safe_int(p_entry.get("character_id"), 1 if player_camp == 1 else 101))
                    player_gs["character_id"] = p_char
                    if p_entry.get("primary_weapon"):
                        player_gs["primary_weapon"] = p_entry["primary_weapon"]
                    if p_entry.get("secondary_weapon"):
                        player_gs["secondary_weapon"] = p_entry["secondary_weapon"]
                    if p_entry.get("main_skill_id"):
                        player_gs["main_skill_id"] = p_entry["main_skill_id"]
                    if p_entry.get("sub_skill_id"):
                        player_gs["sub_skill_id"] = p_entry["sub_skill_id"]
                    if p_entry.get("region_id"):
                        player_gs["region_id"] = p_entry["region_id"]
                        player_gs["spawn_region_id"] = p_entry["region_id"]
                else:
                    player_camp = max(1, _safe_int(_game_state.get("camp"), 1))
                    player_gs["camp"] = player_camp

                _TCPHandler._ensure_character_selection_for_camp(player_gs)
                body = self._build_prebattle_info_body(player_gs, player_pd)
                tag = "sproto-pre-battle-info-resp"
                if session == 0:
                    _TCPHandler._append_prebattle_info_push(
                        extra_pushes,
                        player_gs,
                        player_pd,
                        tag="sproto-push-pre-battle-info-direct",
                        ensure_choose_character_push=False,
                    )

            elif msg_type == 1055:
                # game_ReqConfirmBattle — client sends when confirming readiness
                self_uid = self._session_uid()
                player_pd = _online_ensure_profile(self_uid)
                gs = _game_state
                mode_id = _TCPHandler._sproto_read_int(gs.get("mode_id"), 0)
                if mode_id == 3:
                    prebattle_room_started = bool(gs.get("prebattle_room_started", False))
                    if not prebattle_room_started:
                        gs["prebattle_room_started"] = True
                        gs["prebattle_flow_active"] = True
                        gs["prebattle_stage"] = 1
                        gs["_prebattle_loadout_seeded"] = False
                        gs["_prebattle_choose_character_pushed"] = False
                        extra_pushes.append((self._build_room_start_push(gs, target_pd=player_pd), "sproto-push-room-start-bootstrap"))
                    else:
                        gs["prebattle_stage"] = 4
                        gs["_confirm_sent"] = False
                        _TCPHandler._check_and_launch_room_battle(extra_pushes)
                else:
                    if _TCPHandler._room_is_active() and str(self_uid) in _room_state.get("players", {}):
                        _room_state["players"][str(self_uid)]["prebattle_stage"] = 4
                        _room_state["players"][str(self_uid)]["is_ready"] = True
                    _TCPHandler._check_and_launch_room_battle(extra_pushes)

                body = None
                tag = "sproto-confirm-battle-resp"

            elif msg_type == 1001:
                # game_ReqCreateRoom -> response: errorcode(0)
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqCreateRoom.request", req_body, {
                    _TAG_REQ_CREATE_ROOM_BATTLE_ZONE,
                })

                gs = _game_state
                req_zone = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_CREATE_ROOM_BATTLE_ZONE), gs.get("battle_zone", 1))
                if req_zone > 0:
                    gs["battle_zone"] = req_zone

                _TCPHandler._room_reset()
                _room_state["room_id"] = _TCPHandler._room_allocate_id()
                _room_state["battle_zone"] = max(1, _TCPHandler._sproto_read_int(gs.get("battle_zone"), 1))
                _room_state["map_id"] = max(1, _TCPHandler._sproto_read_int(gs.get("map_id"), 1))
                room_mode = _TCPHandler._sproto_read_int(gs.get("mode_id"), 4)
                if room_mode not in (1, 4):
                    room_mode = 4
                _room_state["mode_id"] = room_mode
                gs["mode_id"] = room_mode
                local_player = _TCPHandler._room_ensure_local_player(pd, gs, make_owner=True)
                room_member_uids: list[str] = []
                room_players = _room_state.get("players")
                if isinstance(room_players, dict):
                    for entry in room_players.values():
                        if not isinstance(entry, dict):
                            continue
                        uid_s = _uid_str(entry.get("uid"), "")
                        if uid_s and uid_s not in room_member_uids:
                            room_member_uids.append(uid_s)
                _chat_sync_room_group_members(_room_state.get("room_id"), room_member_uids)

                _team_state["battle_zone"] = _room_state["battle_zone"]
                _team_state["combat_type"] = 4  # CombatType.room_mode (4)
                _TCPHandler._team_ensure_local_member(pd, ready_status=False, force_captain=True)
                _TCPHandler._team_append_sync_pushes(extra_pushes)

                now_ts = time.time()
                last_snapshot_ts = float(_room_state.get("last_snapshot_push_ts") or 0.0)
                should_push_snapshot = (
                    not bool(_room_state.get("snapshot_sent"))
                    or (now_ts - last_snapshot_ts) >= _ROOM_SNAPSHOT_PUSH_MIN_INTERVAL
                )
                if should_push_snapshot:
                    extra_pushes.extend(_TCPHandler._room_snapshot_pushes())
                    _room_state["snapshot_sent"] = True
                    _room_state["last_snapshot_push_ts"] = now_ts

                _append_utf8_log(
                    f"[TCP] create_room room_id={_TCPHandler._sproto_read_int(_room_state.get('room_id'), 0)} "
                    f"owner={_TCPHandler._sproto_read_int(local_player.get('uid'), 0)} zone={_room_state.get('battle_zone')} "
                    f"snapshot_push={1 if should_push_snapshot else 0}"
                )
                body = [(_TAG_REQ_CREATE_ROOM_RESP_ERRORCODE, 0)]
                tag = "sproto-create-room-resp"

            elif msg_type == 1002:
                # game_ReqJoinRoom -> no response payload
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqJoinRoom.request", req_body, {
                    _TAG_REQ_JOIN_ROOM_ROOM_ID,
                    _TAG_REQ_JOIN_ROOM_BATTLE_ZONE,
                })

                gs = _game_state
                req_room_id = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_JOIN_ROOM_ROOM_ID), 0))
                req_zone = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_JOIN_ROOM_BATTLE_ZONE), gs.get("battle_zone", 1))
                if req_zone > 0:
                    gs["battle_zone"] = req_zone

                if not _TCPHandler._room_is_active():
                    _room_state["room_id"] = req_room_id if req_room_id > 0 else _TCPHandler._room_allocate_id()
                elif req_room_id > 0 and _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0) != req_room_id:
                    _TCPHandler._room_reset()
                    _room_state["room_id"] = req_room_id

                _room_state["battle_zone"] = max(1, _TCPHandler._sproto_read_int(gs.get("battle_zone"), 1))
                _room_state["map_id"] = max(1, _TCPHandler._sproto_read_int(gs.get("map_id"), 1))
                room_mode = _TCPHandler._sproto_read_int(gs.get("mode_id"), 4)
                if room_mode not in (1, 4):
                    room_mode = 4
                _room_state["mode_id"] = room_mode
                gs["mode_id"] = room_mode

                players = _room_state.get("players")
                if not isinstance(players, dict):
                    players = {}
                    _room_state["players"] = players
                self_uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
                existed_before = str(self_uid) in players
                local_player = _TCPHandler._room_ensure_local_player(pd, gs, make_owner=False)
                room_member_uids: list[str] = []
                for entry in players.values():
                    if not isinstance(entry, dict):
                        continue
                    uid_s = _uid_str(entry.get("uid"), "")
                    if uid_s and uid_s not in room_member_uids:
                        room_member_uids.append(uid_s)
                _chat_sync_room_group_members(_room_state.get("room_id"), room_member_uids)

                _team_state["battle_zone"] = _room_state["battle_zone"]
                _team_state["combat_type"] = 4  # CombatType.room_mode (4)
                _TCPHandler._team_ensure_local_member(pd, ready_status=False, force_captain=False)
                _TCPHandler._team_append_sync_pushes(extra_pushes)

                room_snapshot = _TCPHandler._room_snapshot_pushes()
                extra_pushes.extend(room_snapshot)
                _room_state["snapshot_sent"] = True
                _room_state["last_snapshot_push_ts"] = time.time()

                entered_push = None
                if not existed_before:
                    entered_player = _encode_game_player_info(
                        _TCPHandler._sproto_read_int(local_player.get("uid"), 0),
                        str(local_player.get("name") or "Local"),
                        max(1, _TCPHandler._sproto_read_int(local_player.get("level"), 1)),
                        max(0, _TCPHandler._sproto_read_int(local_player.get("icon"), 0)),
                        max(1, _TCPHandler._sproto_read_int(local_player.get("camp"), 1)),
                        max(1, _TCPHandler._sproto_read_int(local_player.get("index"), 1)),
                        max(0, _TCPHandler._sproto_read_int(local_player.get("rank_score"), 0)),
                        str(local_player.get("icon_url") or ""),
                    )
                    entered_push = (
                        _sproto_build_push_frame(1005, [
                            (_TAG_RSP_ROOM_PLAYER_ENTERED_PLAYER, entered_player),
                        ]),
                        "sproto-push-room-player-entered",
                    )
                    extra_pushes.append(entered_push)

                if _TCPHandler._room_is_active():
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            if not existed_before and entered_push is not None:
                                _TCPHandler._queue_pending_push(p_uid, entered_push)
                            _TCPHandler._queue_pending_pushes(p_uid, room_snapshot)

                body = None
                tag = "sproto-join-room-resp"

            elif msg_type == 1056:
                # game_ReqExchangePos -> response: errorcode(0), is_empty(1)
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqExchangePos.request", req_body, {
                    _TAG_REQ_EXCHANGE_POS_CAMP,
                    _TAG_REQ_EXCHANGE_POS_INDEX,
                })

                gs = _game_state
                self_uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
                errorcode = 0
                is_empty = True

                if not _TCPHandler._room_is_active():
                    errorcode = 1
                else:
                    local_entry = _TCPHandler._room_ensure_local_player(pd, gs, make_owner=False)
                    req_camp = max(1, _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_REQ_EXCHANGE_POS_CAMP),
                        _TCPHandler._sproto_read_int(local_entry.get("camp"), 1),
                    ))
                    req_index = max(1, _TCPHandler._sproto_read_int(
                        req_body.get(_TAG_REQ_EXCHANGE_POS_INDEX),
                        _TCPHandler._sproto_read_int(local_entry.get("index"), 1),
                    ))

                    players = _room_state.get("players")
                    if not isinstance(players, dict):
                        players = {}
                        _room_state["players"] = players

                    current_camp = max(1, _TCPHandler._sproto_read_int(local_entry.get("camp"), 1))
                    current_index = max(1, _TCPHandler._sproto_read_int(local_entry.get("index"), 1))

                    target_entry: dict | None = None
                    for entry in players.values():
                        if not isinstance(entry, dict):
                            continue
                        target_uid = _TCPHandler._sproto_read_int(entry.get("uid"), 0)
                        if target_uid <= 0 or target_uid == self_uid:
                            continue
                        target_camp = max(1, _TCPHandler._sproto_read_int(entry.get("camp"), 1))
                        target_index = max(1, _TCPHandler._sproto_read_int(entry.get("index"), 1))
                        if target_camp == req_camp and target_index == req_index:
                            target_entry = entry
                            break

                    if isinstance(target_entry, dict):
                        is_empty = False
                        target_entry["camp"] = current_camp
                        target_entry["index"] = current_index

                    local_entry["camp"] = req_camp
                    local_entry["index"] = req_index
                    gs["camp"] = req_camp
                    gs["team"] = 2 if req_camp == 2 else 1

                    swapped_uid_val = _TCPHandler._sproto_read_int(target_entry.get("uid"), 0) if (not is_empty and isinstance(target_entry, dict)) else None
                    pos_push = _TCPHandler._room_position_notify_push(self_uid, swapped_uid=swapped_uid_val)
                    if pos_push is not None:
                        extra_pushes.append(pos_push)
                        room_snapshot = _TCPHandler._room_snapshot_pushes()
                        extra_pushes.extend(room_snapshot)
                        for p_uid_s in _room_state.get("players", {}).keys():
                            p_uid = _safe_int(p_uid_s, 0)
                            if p_uid > 0 and p_uid != self_uid:
                                _TCPHandler._queue_pending_push(p_uid, pos_push)
                                _TCPHandler._queue_pending_pushes(p_uid, room_snapshot)

                    _room_state["snapshot_sent"] = True
                    _room_state["last_snapshot_push_ts"] = time.time()

                    _append_utf8_log(
                        f"[TCP] exchange_pos uid={self_uid} camp={req_camp} index={req_index} "
                        f"slot_empty={1 if is_empty else 0}"
                    )

                body = [
                    (_TAG_REQ_EXCHANGE_POS_RESP_ERRORCODE, errorcode),
                    (_TAG_REQ_EXCHANGE_POS_RESP_IS_EMPTY, 1 if is_empty else 0),
                ]
                tag = "sproto-exchange-pos-resp"

            elif msg_type == 1013:
                # game_ReqRoomStart -> response: errorcode(0)
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqRoomStart.request", req_body, {
                    _TAG_REQ_ROOM_START_REGION_TYPE,
                })

                gs = _game_state
                req_region_type = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_ROOM_START_REGION_TYPE), gs.get("region_type", 0))
                gs["region_type"] = max(0, req_region_type)
                gs["prebattle_room_started"] = True
                gs["prebattle_flow_active"] = True
                gs["prebattle_stage"] = 1
                gs["_prebattle_loadout_seeded"] = False
                gs["_prebattle_choose_character_pushed"] = False
                gs["_confirm_sent"] = False
                gs["_last_confirm_push_ts"] = 0.0
                gs["spawn_region_id"] = _TCPHandler._resolve_spawn_region(gs, gs.get("spawn_region_id"))
                gs["region_id"] = _TCPHandler._resolve_spawn_region(gs, gs.get("region_id", gs.get("spawn_region_id")))
                _TCPHandler._ensure_character_selection_for_camp(gs)
                if _TCPHandler._sproto_read_int(gs.get("mode_id"), 0) == 3:
                    gs["team"] = _TCPHandler._team_id_for_training_camp(
                        gs.get("camp"),
                        _TCPHandler._sproto_read_int(gs.get("team"), 1),
                    )
                _persist_training_profile(save=True)
                if _TCPHandler._room_is_active():
                    _room_state["battle_launched"] = False
                    _room_state["map_id"] = max(1, _TCPHandler._sproto_read_int(gs.get("map_id"), 1))
                    _room_state["mode_id"] = max(0, _TCPHandler._sproto_read_int(gs.get("mode_id"), 0))
                    for p_entry in _room_state.get("players", {}).values():
                        if isinstance(p_entry, dict):
                            p_entry["prebattle_stage"] = 1
                            p_entry["is_ready"] = False
                    extra_pushes.extend(_TCPHandler._room_snapshot_pushes())
                    _room_state["last_snapshot_push_ts"] = time.time()
                    _room_state["snapshot_sent"] = True
                body = [(_TAG_REQ_ROOM_START_RESP_ERRORCODE, 0)]
                tag = "sproto-room-start-resp"
                room_start_push = (self._build_room_start_push(gs, target_pd=pd), "sproto-push-room-start")
                extra_pushes.append(room_start_push)
                if _TCPHandler._room_is_active():
                    self_uid = self._session_uid(pd)
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            bot_pd = _online_ensure_profile(p_uid)
                            bot_room_start_push = (self._build_room_start_push(gs, target_pd=bot_pd), "sproto-push-room-start")
                            _TCPHandler._queue_pending_push(p_uid, bot_room_start_push)
                            bot_pushes: list[tuple[bytes, str]] = []
                            _TCPHandler._append_prebattle_info_push(
                                bot_pushes,
                                gs,
                                bot_pd,
                                tag="sproto-push-pre-battle-info-room-start",
                            )
                            _TCPHandler._queue_pending_pushes(p_uid, bot_pushes)

            elif msg_type == 1006:
                # game_ReqLeaveRoom -> no response payload
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqLeaveRoom.request", req_body, set())

                self_uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
                active_room_id = _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)
                removed_entry, owner_changed_uid = _TCPHandler._room_remove_player(self_uid)
                leave_push = (
                    _sproto_build_push_frame(1007, [
                        (_TAG_RSP_ROOM_PLAYER_LEAVED_UID, self_uid),
                        (_TAG_RSP_ROOM_PLAYER_LEAVED_LEAVE_TYPE, 0),
                    ]),
                    "sproto-push-room-player-leaved",
                )
                extra_pushes.append(leave_push)
                if isinstance(removed_entry, dict) and active_room_id > 0:
                    _chat_remove_room_group_members(active_room_id, [self_uid])

                owner_push = None
                if owner_changed_uid > 0:
                    owner_push = (
                        _sproto_build_push_frame(1008, [
                            (_TAG_RSP_ROOM_OWNER_CHANGED_UID, owner_changed_uid),
                        ]),
                        "sproto-push-room-owner-changed",
                    )
                    extra_pushes.append(owner_push)

                if _TCPHandler._room_is_active():
                    room_snapshot = _TCPHandler._room_snapshot_pushes()
                    for p_uid_s in _room_state.get("players", {}).keys():
                        p_uid = _safe_int(p_uid_s, 0)
                        if p_uid > 0 and p_uid != self_uid:
                            _TCPHandler._queue_pending_push(p_uid, leave_push)
                            if owner_push:
                                _TCPHandler._queue_pending_push(p_uid, owner_push)
                            _TCPHandler._queue_pending_pushes(p_uid, room_snapshot)
                else:
                    extra_pushes.append((
                        _sproto_build_push_frame(1003, [
                            (_TAG_RSP_JOIN_ROOM_STATE_STATE, 0),
                        ]),
                        "sproto-push-join-room-state-disband",
                    ))

                body = None
                tag = "sproto-leave-room-resp"

            elif msg_type == 1061:
                # game_ReqRoomKickPlayer -> response: errorcode(0)
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqRoomKickPlayer.request", req_body, {
                    _TAG_REQ_ROOM_KICK_UID,
                })

                target_uid = max(0, _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_ROOM_KICK_UID), 0))
                self_uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
                errorcode = 0
                if not _TCPHandler._room_is_active():
                    errorcode = 1
                elif _TCPHandler._sproto_read_int(_room_state.get("owner_uid"), 0) != self_uid:
                    errorcode = 2
                elif target_uid <= 0:
                    errorcode = 3
                else:
                    active_room_id = _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)
                    removed_entry, owner_changed_uid = _TCPHandler._room_remove_player(target_uid)
                    if not isinstance(removed_entry, dict):
                        errorcode = 4
                    else:
                        if active_room_id > 0:
                            _chat_remove_room_group_members(active_room_id, [target_uid])
                        kick_push = (
                            _sproto_build_push_frame(1007, [
                                (_TAG_RSP_ROOM_PLAYER_LEAVED_UID, target_uid),
                                (_TAG_RSP_ROOM_PLAYER_LEAVED_LEAVE_TYPE, 1),
                            ]),
                            "sproto-push-room-player-kicked",
                        )
                        extra_pushes.append(kick_push)
                        _TCPHandler._queue_pending_push(target_uid, kick_push)
                        try:
                            import services.chat as chat_srv
                            chat_srv._broadcast_player_status_change(target_uid, chat_srv.get_player_state(target_uid))
                        except Exception:
                            pass
                        owner_kick_push = None
                        if owner_changed_uid > 0:
                            owner_kick_push = (
                                _sproto_build_push_frame(1008, [
                                    (_TAG_RSP_ROOM_OWNER_CHANGED_UID, owner_changed_uid),
                                ]),
                                "sproto-push-room-owner-changed",
                            )
                            extra_pushes.append(owner_kick_push)

                        if _TCPHandler._room_is_active():
                            room_snapshot = _TCPHandler._room_snapshot_pushes()
                            for p_uid_s in _room_state.get("players", {}).keys():
                                p_uid = _safe_int(p_uid_s, 0)
                                if p_uid > 0 and p_uid != self_uid and p_uid != target_uid:
                                    _TCPHandler._queue_pending_push(p_uid, kick_push)
                                    if owner_kick_push:
                                        _TCPHandler._queue_pending_push(p_uid, owner_kick_push)
                                    _TCPHandler._queue_pending_pushes(p_uid, room_snapshot)

                body = [(_TAG_REQ_ROOM_KICK_RESP_ERRORCODE, errorcode)]
                tag = "sproto-room-kick-player-resp"

            elif msg_type == 1080:
                # game_ReqRoomChangeBattleZone -> no response payload
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqRoomChangeBattleZone.request", req_body, {
                    _TAG_REQ_ROOM_CHANGE_BATTLE_ZONE,
                })

                req_zone = _TCPHandler._sproto_read_int(req_body.get(_TAG_REQ_ROOM_CHANGE_BATTLE_ZONE), _TCPHandler._sproto_read_int(_game_state.get("battle_zone"), 1))
                if req_zone > 0:
                    _game_state["battle_zone"] = req_zone
                    _room_state["battle_zone"] = req_zone
                extra_pushes.append((
                    _sproto_build_push_frame(1081, [
                        (_TAG_RSP_ROOM_BATTLE_ZONE_CHANGED_BATTLE_ZONE, _TCPHandler._sproto_read_int(_room_state.get("battle_zone"), 1)),
                    ]),
                    "sproto-push-room-battle-zone-changed",
                ))
                body = None
                tag = "sproto-room-change-battle-zone-resp"

            elif msg_type == 1041:
                # game_ReqLeaveBattle -> empty response
                gs = _game_state
                battle_id = _TCPHandler._sproto_read_int(gs.get("battle_id"), 0)
                if battle_id > 0 and _TCPHandler._sproto_read_int(gs.get("_last_result_battle_id"), 0) != battle_id:
                    extra_pushes.extend(_TCPHandler._build_leave_result_pushes(gs, target_pd=pd))
                    gs["_last_result_battle_id"] = battle_id
                gs["in_battle"] = False
                gs["_confirm_sent"] = False
                gs["_confirm_pending"] = False
                gs["_last_confirm_push_ts"] = 0.0
                gs["prebattle_room_started"] = False
                gs["prebattle_flow_active"] = False
                gs["prebattle_stage"] = 1
                gs["_prebattle_loadout_seeded"] = False
                gs["_prebattle_choose_character_pushed"] = False
                if _TCPHandler._room_is_active():
                    _room_state["battle_launched"] = False
                    for p_entry in _room_state.get("players", {}).values():
                        if isinstance(p_entry, dict):
                            p_entry["prebattle_stage"] = 1
                            p_entry["is_ready"] = False
                body = None
                tag = "sproto-leave-battle-resp"

            elif msg_type == 1030:
                # game_ReqPlayersResult -> empty response + result-list push.
                _TCPHandler._log_sproto_qc(msg_type, "game.ReqPlayersResult.request", req_body, set())
                gs = _game_state
                battle_id = _TCPHandler._sproto_read_int(gs.get("battle_id"), 0)
                if battle_id > 0:
                    players_result = _TCPHandler._build_players_result_push(gs, target_pd=pd)
                    extra_pushes.append((players_result, "sproto-push-players-result"))
                body = None
                tag = "sproto-players-result-resp"

            else:
                # Generic empty response for any unknown request type
                if session == 0:
                    return None  # server push — cannot respond
                body = None
                tag = f"sproto-generic-resp-type{msg_type}"
                # Log decoded body for unknown types to help debugging
                if req_body:
                    _log_line = f"[TCP] unknown type={msg_type} req_body={req_body}"
                    print(_console_safe(_log_line)); _append_utf8_log(_log_line)

            # session=0 means push/notification — client does NOT expect a response.
            # Sending a response for session=0 corrupts the sproto stream.
            if session == 0:
                line_info = (
                    f"[TCP] sproto decoded type={msg_type} session=0 (push) "
                    f"-> {tag} (no response, {len(extra_pushes)} pushes)"
                )
                print(_console_safe(line_info))
                _append_utf8_log(line_info)
                if extra_pushes:
                    return extra_pushes
                return []   # nothing to send

            try:
                resp = _sproto_build_response_frame(session, body)
            except Exception as exc:
                import traceback; traceback.print_exc()
                line_err = f"[TCP] sproto response build error for type={msg_type} session={session}: {exc}"
                print(_console_safe(line_err))
                _append_utf8_log(line_err)
                return None

            line_info = (
                f"[TCP] sproto decoded type={msg_type} session={session} "
                f"-> {tag} resp_len={len(resp)}"
            )
            print(_console_safe(line_info))
            _append_utf8_log(line_info)

            result: list[tuple[bytes, str]] = [(resp, tag)]
            result.extend(extra_pushes)
            return result

        @staticmethod
        def _make_role_data(
            pd: dict,
            *,
            show_character_id_override: object = None,
            force_name_empty: bool = False,
        ) -> bytes:
            """Build sproto-encoded role_data from player data dict."""
            # Build client_config as list of Stat entries:
            # each Stat = {type(0):string, value(1):long}
            import struct as _st_rd

            def _int_or_default(value: object, default: int) -> int:
                try:
                    return int(value)
                except Exception:
                    return default

            cc_entries = b''
            for cfg_key, cfg_val in _client_config.items():
                if isinstance(cfg_val, int) and cfg_val >= 0:
                    entry = _encode_client_stat(cfg_key, cfg_val)
                    cc_entries += _st_rd.pack('<I', len(entry)) + entry

            stats_entries = b""
            show_character_id = _TCPHandler._sproto_read_int(show_character_id_override, 0)
            if show_character_id <= 0:
                show_character_id = _TCPHandler._get_show_character_id(
                    _TCPHandler._sproto_read_int(_game_state.get("character_id"), 1)
                )
            rank_score_val = max(0, _int_or_default(pd.get("rank_score"), 1000))
            career_max_rank = max(rank_score_val, _int_or_default(pd.get("career_max_rank"), rank_score_val))
            king_emblem_val = max(0, _int_or_default(pd.get("king_emblem"), 1))
            current_season = max(1, _int_or_default(pd.get("current_season_id"), 1))

            for s_key, s_val in (
                ("1", king_emblem_val),      # king_emblem
                ("2", career_max_rank),      # career_max_rank
                ("3", current_season),       # current_season_id
                ("4", 1),                    # guide_id_opened
                ("5", 1),                    # guide_id_finished
                ("6", 1),                    # first_recharge
                ("7", max(0, show_character_id)), # show_character_id
                ("8", int(time.time())),     # last_change_name_ts
                ("9", 1),                    # icon_frame_unlock_state
                ("10", 100),                 # punish_score
            ):
                stat_encoded = _encode_client_stat(s_key, s_val)
                stats_entries += _st_rd.pack('<I', len(stat_encoded)) + stat_encoded

            gold = max(0, _int_or_default(pd.get("gold"), _DEFAULT_GOLD))
            diamond = max(0, _int_or_default(pd.get("diamond"), _DEFAULT_DIAMOND))
            money_entries = b''
            for money_type, amount in (("Diamond", diamond), ("Gold", gold), ("1", diamond), ("2", gold)):
                money_entry = _encode_client_money(money_type, amount)
                money_entries += _st_rd.pack('<I', len(money_entry)) + money_entry

            icon_url = pd.get("icon_url")
            if not isinstance(icon_url, str):
                icon_url = ""

            role_name = _sanitize_display_name(
                pd.get("name"),
                f"Player{max(1, _int_or_default(pd.get('uid'), 1000001))}",
            )
            if force_name_empty:
                role_name = ""

            characters_entries = _TCPHandler._build_role_characters_list()
            event_stats_entries = _TCPHandler._build_role_event_stats_list(pd)

            return _sproto_encode_fields([
                (_TAG_ROLE_DATA_NAME, role_name),
                (_TAG_ROLE_DATA_LEVEL, max(1, _int_or_default(pd.get("level"), 1))),
                (_TAG_ROLE_DATA_EXP, max(0, _int_or_default(pd.get("exp"), 0))),
                (_TAG_ROLE_DATA_STATS, stats_entries),
                (_TAG_ROLE_DATA_ICON, max(0, _int_or_default(pd.get("icon"), 0))),
                (_TAG_ROLE_DATA_MONEY, money_entries),
                (_TAG_ROLE_DATA_CHARACTERS, characters_entries),
                (_TAG_ROLE_DATA_EVENT_STATS, event_stats_entries),
                (_TAG_ROLE_DATA_CLIENT_CONFIG, cc_entries),
                (_TAG_ROLE_DATA_ICON_URL, icon_url),
                (_TAG_ROLE_DATA_TIME_ZONE, _int_or_default(pd.get("time_zone"), 0)),
                (_TAG_ROLE_DATA_ICON_FRAME, _int_or_default(pd.get("icon_frame"), 0)),
                (_TAG_ROLE_DATA_CREATE_TIME, max(1, _int_or_default(pd.get("create_time"), int(time.time())))),
                (_TAG_ROLE_DATA_CURRENT_SEASON_ID, max(1, _int_or_default(pd.get("current_season_id"), 1))),
                (_TAG_ROLE_DATA_IS_ACTIVE, 1),
            ])

        def _build_load_role_response(self, pd: dict):
            force_name_empty = _chat_bootstrap_should_force_naming(pd.get("uid"))
            role_data = self._make_role_data(pd, force_name_empty=force_name_empty)
            if force_name_empty:
                _append_utf8_log(
                    "[TCP] force_naming_hint "
                    f"uid={_TCPHandler._sproto_read_int(pd.get('uid'), 0)} reason=chat_bootstrap_missing"
                )
            body = [
                (_TAG_LOAD_ROLE_ERRORCODE, 0),
                (_TAG_LOAD_ROLE_UID, max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))),
                (_TAG_LOAD_ROLE_ROLE, role_data),
            ]
            return body, "sproto-load-role-resp"

        def _build_query_role_profile_pd(self, pd: dict, requested_uid: object) -> dict:
            local_uid = max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))
            target_uid = max(1, _TCPHandler._sproto_read_int(requested_uid, local_uid))
            target_profile = _online_ensure_profile(target_uid)

            stored_pd = {}
            if hasattr(_player_data, "storage") and str(target_uid) in _player_data.storage:
                stored_pd = _player_data.storage[str(target_uid)]
            elif isinstance(pd, dict) and _TCPHandler._sproto_read_int(pd.get("uid"), 0) == target_uid:
                stored_pd = pd

            role_pd = dict(stored_pd or pd)
            role_pd["uid"] = target_uid

            cand_name = str(stored_pd.get("name") or target_profile.get("name") or role_pd.get("name") or "").strip()
            if not cand_name or cand_name.startswith("Player"):
                if target_uid in (1000001, 1000012) or str(target_uid) in ("1000001", "1000012"):
                    cand_name = "1nsirius"
                elif str(target_profile.get("name", "")).strip() and not str(target_profile.get("name")).startswith("Player"):
                    cand_name = str(target_profile.get("name")).strip()
                else:
                    cand_name = f"Player{target_uid}"
            role_pd["name"] = cand_name

            role_pd["level"] = max(1, _TCPHandler._sproto_read_int(role_pd.get("level"), _TCPHandler._sproto_read_int(target_profile.get("level"), 1)))
            role_pd["exp"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("exp"), _TCPHandler._sproto_read_int(target_profile.get("exp"), 0)))
            role_pd["icon"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("icon"), _TCPHandler._sproto_read_int(target_profile.get("icon"), 0)))
            role_pd["icon_url"] = str(role_pd.get("icon_url") or target_profile.get("icon_url") or "")
            role_pd["icon_frame"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("icon_frame"), _TCPHandler._sproto_read_int(target_profile.get("icon_frame"), 0)))
            role_pd["time_zone"] = _TCPHandler._sproto_read_int(role_pd.get("time_zone"), _TCPHandler._sproto_read_int(target_profile.get("time_zone"), 0))
            role_pd["current_season_id"] = max(
                1,
                _TCPHandler._sproto_read_int(
                    role_pd.get("current_season_id"),
                    _TCPHandler._sproto_read_int(target_profile.get("current_season_id"), 1),
                ),
            )
            role_pd["create_time"] = max(
                1,
                _TCPHandler._sproto_read_int(
                    role_pd.get("create_time"),
                    _TCPHandler._sproto_read_int(target_profile.get("create_time"), int(time.time())),
                ),
            )
            role_pd["rank_score"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("rank_score"), _TCPHandler._sproto_read_int(target_profile.get("rank_score"), 0)))
            role_pd["gold"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("gold"), _TCPHandler._sproto_read_int(target_profile.get("gold"), _DEFAULT_GOLD)))
            role_pd["diamond"] = max(0, _TCPHandler._sproto_read_int(role_pd.get("diamond"), _TCPHandler._sproto_read_int(target_profile.get("diamond"), _DEFAULT_DIAMOND)))

            # Copy all combat & stats fields from target_profile into role_pd
            for stat_k in (
                "battle_kill", "battle_dead", "battle_assist", "battle_score",
                "battle_times", "win_times", "mvp_count", "headshots",
                "kills", "deaths", "assists", "total_matches", "wins",
                "career_max_rank", "king_emblem", "motto"
            ):
                if stat_k in target_profile:
                    role_pd[stat_k] = target_profile[stat_k]

            _append_utf8_log(
                "[TCP] query_role_profile target="
                f"{target_uid} local={local_uid} "
                f"name={role_pd.get('name')!r} level={role_pd.get('level')}"
            )
            return role_pd

        def _build_query_role_response(self, pd: dict):
            requested_show_character_id = _TCPHandler._get_show_character_id(
                _TCPHandler._sproto_read_int(_game_state.get("character_id"), 1)
            )
            resolved_show_character_id, show_character = _TCPHandler._build_character_skin_struct_with_id(
                requested_show_character_id
            )
            resolved_char_skins = _TCPHandler._get_selected_char_skins(resolved_show_character_id)
            if not resolved_char_skins:
                resolved_char_skins = _TCPHandler._default_character_skin_ids(resolved_show_character_id)
            resolved_weapon_skins = _TCPHandler._get_selected_weapon_skins(resolved_show_character_id)
            if resolved_show_character_id != requested_show_character_id:
                print(
                    "[WARNING] query_role show_character remapped: "
                    f"requested={requested_show_character_id} resolved={resolved_show_character_id}"
                )
            role_data = self._make_role_data(
                pd,
                show_character_id_override=resolved_show_character_id,
            )
            print(
                "[DEBUG] query_role: show_character_id="
                f"{requested_show_character_id} resolved={resolved_show_character_id}"
            )
            print(f"[DEBUG] query_role: show_character length={len(show_character)} bytes")
            _append_utf8_log(
                "[TCP] query_role_profile "
                f"uid={_TCPHandler._sproto_read_int(pd.get('uid'), 0)} "
                f"requested_show={requested_show_character_id} "
                f"resolved_show={resolved_show_character_id} "
                f"char_skins={resolved_char_skins[:8]} "
                f"weapon_slots={len(resolved_weapon_skins)} "
                f"show_payload_len={len(show_character)}"
            )
            body: list[tuple[int, object]] = [
                (_TAG_QUERY_ROLE_ERRORCODE, 0),
                (_TAG_QUERY_ROLE_UID, pd["uid"]),
                (_TAG_QUERY_ROLE_ROLE, role_data),
            ]
            if _SEND_QUERY_ROLE_SHOW_CHARACTER:
                body.append((_TAG_QUERY_ROLE_SHOW_CHARACTER, show_character))
            else:
                _append_utf8_log(
                    "[TCP] query_role_profile safe_mode: show_character omitted (SEND_QUERY_ROLE_SHOW_CHARACTER=0)"
                )
            return body, "sproto-query-role-resp"

        @staticmethod
        def _sproto_read_int(value: object, default: int = 0) -> int:
            if isinstance(value, bool):
                return int(value)
            if isinstance(value, int):
                return value
            if isinstance(value, bytes):
                try:
                    return int.from_bytes(value, "little", signed=True) if value else default
                except Exception:
                    return default
            try:
                return int(value)
            except Exception:
                return default

        @staticmethod
        def _normalize_prebattle_stage(value: object, default: int = 1) -> int:
            """
            Normalize prebattle stage to canonical enum 1..4.

            Observed client traffic can carry encoded-like stage values (4/6/8/10),
            where effective stage is 1/2/3/4. Keep server state canonical so gating
            and responses are stable.
            """
            raw = _TCPHandler._sproto_read_int(value, default)
            if 1 <= raw <= 4:
                return raw
            if raw >= 4 and (raw % 2) == 0:
                mapped = (raw // 2) - 1
                if 1 <= mapped <= 4:
                    return mapped
            return max(1, min(4, raw if raw > 0 else default))

        @staticmethod
        def _sproto_read_text(value: object, default: str = "") -> str:
            if isinstance(value, bytes):
                try:
                    return value.decode("utf-8", errors="replace")
                except Exception:
                    return default
            if isinstance(value, str):
                return value
            return default

        @staticmethod
        def _default_spawn_region_for_camp(camp: object) -> int:
            return _default_spawn_region_for_camp_value(camp)

        @staticmethod
        def _spawn_region_is_valid_for_camp(camp: object, region_id: object) -> bool:
            return _spawn_region_is_valid_for_camp_value(camp, region_id)

        @staticmethod
        def _resolve_spawn_region(gs: dict | None, value: object = None) -> int:
            camp_id = 1
            if isinstance(gs, dict):
                camp_id = _TCPHandler._sproto_read_int(gs.get("camp"), 1)
            default_region = _TCPHandler._default_spawn_region_for_camp(camp_id)
            if value is None:
                return default_region

            region_id = _TCPHandler._sproto_read_int(value, default_region)
            # 255 is used by some training spawn points (valid selection).
            if region_id == 999:
                return default_region
            if region_id < 0:
                return default_region
            if not _TCPHandler._spawn_region_is_valid_for_camp(camp_id, region_id):
                return default_region
            return region_id

        @staticmethod
        def _resolve_user_guide_entry(guide_id: object) -> dict[str, int]:
            requested_id = max(1, _TCPHandler._sproto_read_int(guide_id, 1))
            entry = _USER_GUIDE_META_BY_ID.get(requested_id)
            if not isinstance(entry, dict):
                entry = _USER_GUIDE_META_BY_ID.get(1)
            if not isinstance(entry, dict):
                for candidate in _USER_GUIDE_META_BY_ID.values():
                    if isinstance(candidate, dict):
                        entry = candidate
                        break

            if not isinstance(entry, dict):
                entry = {"guide_id": 1, "map_id": 3, "mode_id": 2}

            resolved_guide_id = max(1, _TCPHandler._sproto_read_int(entry.get("guide_id"), requested_id))
            resolved_map_id = max(1, _TCPHandler._sproto_read_int(entry.get("map_id"), 3))
            resolved_mode_id = max(1, _TCPHandler._sproto_read_int(entry.get("mode_id"), 2))
            return {
                "guide_id": resolved_guide_id,
                "map_id": resolved_map_id,
                "mode_id": resolved_mode_id,
            }

        @staticmethod
        def _character_camp(character_id: object) -> int:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            if cid <= 0:
                return 1
            meta = _CHARACTER_META_BY_ID.get(cid)
            if isinstance(meta, dict):
                camp = _TCPHandler._sproto_read_int(meta.get("camp"), 0)
                if camp in (1, 2):
                    return camp
            if 100 <= cid < 10000:
                return 2
            return 1

        @staticmethod
        def _character_is_available(character_id: object) -> bool:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            if cid <= 0:
                return False
            meta = _CHARACTER_META_BY_ID.get(cid)
            if isinstance(meta, dict):
                return _TCPHandler._sproto_read_int(meta.get("available"), 1) > 0
            return True

        @staticmethod
        def _character_matches_camp(character_id: object, camp: object) -> bool:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            camp_id = _TCPHandler._sproto_read_int(camp, 1)
            if cid <= 0:
                return False
            if camp_id not in (1, 2):
                camp_id = 1
            return _TCPHandler._character_camp(cid) == camp_id

        @staticmethod
        def _default_character_for_camp(camp: object) -> int:
            camp_id = _TCPHandler._sproto_read_int(camp, 1)
            if camp_id not in (1, 2):
                camp_id = 1
            known = _CHARACTER_IDS_BY_CAMP.get(camp_id) or []
            if known:
                return _TCPHandler._sproto_read_int(known[0], 1 if camp_id == 1 else 101)
            return 101 if camp_id == 2 else 1

        @staticmethod
        def _character_default_loadout(character_id: object) -> tuple[int, int, int, int]:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            defaults = _CHAR_DEFAULT_LOADOUTS.get(cid)
            if isinstance(defaults, tuple) and len(defaults) == 4:
                return (
                    max(1, _TCPHandler._sproto_read_int(defaults[0], 10036)),
                    max(1, _TCPHandler._sproto_read_int(defaults[1], 10074)),
                    max(1, _TCPHandler._sproto_read_int(defaults[2], 295)),
                    max(1, _TCPHandler._sproto_read_int(defaults[3], 299)),
                )
            return (10036, 10074, 295, 299)

        @staticmethod
        def _character_loadout_options(character_id: object) -> tuple[list[int], list[int], list[int], list[int]]:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            meta = _CHARACTER_META_BY_ID.get(cid)
            if not isinstance(meta, dict):
                d_pri, d_sec, d_main, d_sub = _TCPHandler._character_default_loadout(cid)
                return ([d_pri], [d_sec], [d_main], [d_sub])

            def _norm_list(raw_value: object) -> list[int]:
                out: list[int] = []
                if isinstance(raw_value, list):
                    for item in raw_value:
                        parsed = _TCPHandler._sproto_read_int(item, 0)
                        if parsed > 0 and parsed not in out:
                            out.append(parsed)
                return out

            pri = _norm_list(meta.get("primary_weapons"))
            sec = _norm_list(meta.get("secondary_weapons"))
            main = _norm_list(meta.get("main_skills"))
            sub = _norm_list(meta.get("sub_skills"))

            d_pri, d_sec, d_main, d_sub = _TCPHandler._character_default_loadout(cid)
            if d_pri > 0 and d_pri not in pri:
                pri.insert(0, d_pri)
            if d_sec > 0 and d_sec not in sec:
                sec.insert(0, d_sec)
            if d_main > 0 and d_main not in main:
                main.insert(0, d_main)
            if d_sub > 0 and d_sub not in sub:
                sub.insert(0, d_sub)

            if not pri:
                pri = [10036]
            if not sec:
                sec = [10074]
            if not main:
                main = [295]
            if not sub:
                sub = [299]

            return (pri[:32], sec[:32], main[:16], sub[:16])

        @staticmethod
        def _skin_type(skin_id: object) -> int:
            sid = _TCPHandler._sproto_read_int(skin_id, 0)
            if sid <= 0:
                return 0
            return _TCPHandler._sproto_read_int(_SKIN_ID_TO_TYPE.get(sid), 0)

        @staticmethod
        def _skin_handprops(skin_id: object) -> list[int]:
            sid = _TCPHandler._sproto_read_int(skin_id, 0)
            if sid <= 0:
                return []
            raw = _SKIN_ID_TO_HANDPROPS.get(sid)
            if not isinstance(raw, list):
                return []
            out: list[int] = []
            for item in raw:
                parsed = _TCPHandler._sproto_read_int(item, 0)
                if parsed > 0 and parsed not in out:
                    out.append(parsed)
            return out

        @staticmethod
        def _skin_allowed_characters(skin_id: object) -> list[int]:
            sid = _TCPHandler._sproto_read_int(skin_id, 0)
            if sid <= 0:
                return []
            raw = _SKIN_ID_TO_CHARACTERS.get(sid)
            if not isinstance(raw, list):
                return []
            out: list[int] = []
            for item in raw:
                parsed = _TCPHandler._sproto_read_int(item, 0)
                if parsed > 0 and parsed not in out:
                    out.append(parsed)
            return out

        @staticmethod
        def _default_character_skin_ids(character_id: object) -> list[int]:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            meta = _CHARACTER_META_BY_ID.get(cid)
            if not isinstance(meta, dict):
                return []
            out: list[int] = []
            for key in ("default_head_skin", "default_body_skin"):
                sid = _TCPHandler._sproto_read_int(meta.get(key), 0)
                if sid > 0 and sid not in out:
                    out.append(sid)
            return out

        @staticmethod
        def _normalize_character_skin_ids(character_id: object, skin_ids: list[int]) -> list[int]:
            cid = max(1, _TCPHandler._sproto_read_int(character_id, 1))
            defaults = _TCPHandler._default_character_skin_ids(cid)
            default_head = 0
            default_body = 0
            for default_sid in defaults:
                default_type = _TCPHandler._skin_type(default_sid)
                if default_type == 2 and default_head <= 0:
                    default_head = default_sid
                elif default_type == 3 and default_body <= 0:
                    default_body = default_sid

            suit_id = 0
            head_id = 0
            body_id = 0
            seen_ids: set[int] = set()
            for sid_raw in skin_ids:
                sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                if sid <= 0 or sid in seen_ids:
                    continue
                seen_ids.add(sid)

                allowed = _TCPHandler._skin_allowed_characters(sid)
                if allowed and cid not in allowed:
                    continue

                skin_type = _TCPHandler._skin_type(sid)
                if skin_type == 1 and suit_id <= 0:
                    suit_id = sid
                elif skin_type == 2 and head_id <= 0:
                    head_id = sid
                elif skin_type == 3 and body_id <= 0:
                    body_id = sid

            if suit_id > 0:
                return [suit_id]

            if head_id <= 0:
                head_id = default_head
            if body_id <= 0:
                body_id = default_body

            out: list[int] = []
            if head_id > 0:
                out.append(head_id)
            if body_id > 0 and body_id not in out:
                out.append(body_id)
            return out[:16]

        @staticmethod
        def _build_character_skin_struct_with_id(character_id: object) -> tuple[int, bytes]:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            if cid <= 0:
                cid = 1
            char_skins = _TCPHandler._get_selected_char_skins(cid)
            if not char_skins:
                char_skins = _TCPHandler._default_character_skin_ids(cid)
            char_skins = _TCPHandler._normalize_character_skin_ids(cid, char_skins)

            # Fallback: если скины пустые (нет метаданных для персонажа), используем персонажа по умолчанию
            if not char_skins and cid != 1:
                print(f"[WARNING] Character {cid} has no skin metadata, falling back to character 1")
                cid = 1
                char_skins = _TCPHandler._default_character_skin_ids(1)
                char_skins = _TCPHandler._normalize_character_skin_ids(1, char_skins)

            char_skin_payload = _TCPHandler._sproto_build_integer_list(char_skins[:16])

            weapon_skin_entries: list[bytes] = []
            weapon_skin_map = _TCPHandler._get_selected_weapon_skins(cid)
            for weapon_id in sorted(weapon_skin_map.keys())[:64]:
                skin_ids = [sid for sid in (weapon_skin_map.get(weapon_id) or []) if sid > 0][:8]
                if not skin_ids:
                    continue
                weapon_skin_entries.append(_sproto_encode_fields([
                    (0, weapon_id),
                    # client.WeaponSkin.decode reads skins on tag=2 (not tag=1).
                    (2, _TCPHandler._sproto_build_integer_list(skin_ids)),
                ]))
            weapon_skin_payload = _TCPHandler._sproto_build_struct_list(weapon_skin_entries)

            payload = _sproto_encode_fields([
                (0, cid),
                (1, char_skin_payload),
                (2, weapon_skin_payload),
            ])
            return cid, payload

        @staticmethod
        def _build_character_skin_struct(character_id: object) -> bytes:
            _, payload = _TCPHandler._build_character_skin_struct_with_id(character_id)
            return payload

        @staticmethod
        def _selected_skins_root() -> dict[str, object]:
            root = _player_data.get("selected_skins")
            if not isinstance(root, dict):
                root = _default_selected_skins()
                _player_data["selected_skins"] = root
            chars = root.get("characters")
            if not isinstance(chars, dict):
                chars = {}
                root["characters"] = chars
            return root

        @staticmethod
        def _selected_skin_character_entry(character_id: object, *, create: bool = True) -> dict[str, object] | None:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            if cid <= 0:
                return None
            root = _TCPHandler._selected_skins_root()
            chars = root.get("characters")
            if not isinstance(chars, dict):
                return None
            key = str(cid)
            entry = chars.get(key)
            if not isinstance(entry, dict):
                if not create:
                    return None
                entry = {"char_skins": [], "weapon_skins": {}}
                chars[key] = entry
            if not isinstance(entry.get("char_skins"), list):
                entry["char_skins"] = []
            if not isinstance(entry.get("weapon_skins"), dict):
                entry["weapon_skins"] = {}
            return entry

        @staticmethod
        def _get_selected_char_skins(character_id: object) -> list[int]:
            entry = _TCPHandler._selected_skin_character_entry(character_id, create=False)
            if not isinstance(entry, dict):
                return []
            raw = entry.get("char_skins")
            if not isinstance(raw, list):
                return []
            out: list[int] = []
            for sid_raw in raw:
                sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                if sid > 0 and sid not in out:
                    out.append(sid)
            normalized = _TCPHandler._normalize_character_skin_ids(character_id, out)
            if normalized != out:
                entry["char_skins"] = normalized
            return normalized

        @staticmethod
        def _set_selected_char_skins(character_id: object, skin_ids: list[int]) -> None:
            entry = _TCPHandler._selected_skin_character_entry(character_id, create=True)
            if not isinstance(entry, dict):
                return
            out: list[int] = []
            for sid_raw in skin_ids:
                sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                if sid > 0 and sid not in out:
                    out.append(sid)
            entry["char_skins"] = _TCPHandler._normalize_character_skin_ids(character_id, out)

        @staticmethod
        def _get_selected_weapon_skins(character_id: object) -> dict[int, list[int]]:
            entry = _TCPHandler._selected_skin_character_entry(character_id, create=False)
            if not isinstance(entry, dict):
                return {}
            raw = entry.get("weapon_skins")
            if not isinstance(raw, dict):
                return {}
            out: dict[int, list[int]] = {}
            for weapon_key_raw, skin_ids_raw in raw.items():
                weapon_id = _TCPHandler._sproto_read_int(weapon_key_raw, 0)
                if weapon_id <= 0 or not isinstance(skin_ids_raw, list):
                    continue
                skins: list[int] = []
                for sid_raw in skin_ids_raw:
                    sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                    if sid > 0 and sid not in skins:
                        skins.append(sid)
                if skins:
                    out[weapon_id] = skins[:8]
            return out

        @staticmethod
        def _set_selected_weapon_skin_list(character_id: object, weapon_id: object, skin_ids: list[int]) -> None:
            entry = _TCPHandler._selected_skin_character_entry(character_id, create=True)
            if not isinstance(entry, dict):
                return
            weapon_key = str(max(0, _TCPHandler._sproto_read_int(weapon_id, 0)))
            if weapon_key == "0":
                return
            weapon_map = entry.get("weapon_skins")
            if not isinstance(weapon_map, dict):
                weapon_map = {}
                entry["weapon_skins"] = weapon_map
            out: list[int] = []
            for sid_raw in skin_ids:
                sid = _TCPHandler._sproto_read_int(sid_raw, 0)
                if sid > 0 and sid not in out:
                    out.append(sid)
            if out:
                weapon_map[weapon_key] = out[:8]
            elif weapon_key in weapon_map:
                weapon_map.pop(weapon_key, None)

        @staticmethod
        def _selected_weapon_visual_skin_id(character_id: object, weapon_id: object, preferred_skin: object = 0) -> int:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            wid = _TCPHandler._sproto_read_int(weapon_id, 0)
            if cid <= 0 or wid <= 0:
                return 0
            selected_map = _TCPHandler._get_selected_weapon_skins(cid)
            selected_list = selected_map.get(wid) or []
            for sid in selected_list:
                if _TCPHandler._skin_type(sid) == 4:
                    return _TCPHandler._sproto_read_int(sid, 0)
            preferred = _TCPHandler._sproto_read_int(preferred_skin, 0)
            if preferred > 0 and _TCPHandler._skin_type(preferred) == 4:
                return preferred
            return 0

        @staticmethod
        def _apply_selected_character_skin(character_id: object, skin_id: object) -> bool:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            sid = _TCPHandler._sproto_read_int(skin_id, 0)
            if cid <= 0 or sid <= 0:
                return False

            skin_type = _TCPHandler._skin_type(sid)
            if skin_type not in (1, 2, 3):
                return False

            allowed = _TCPHandler._skin_allowed_characters(sid)
            if allowed and cid not in allowed:
                return False

            cur = _TCPHandler._normalize_character_skin_ids(cid, _TCPHandler._get_selected_char_skins(cid))

            # Mirrors PlayerSkinData.CharacterSkinData.SetCharacterSkinID behavior.
            if skin_type == 1:
                next_skins = [sid]
            elif skin_type in (2, 3):
                next_skins: list[int] = []
                replaced = False
                for existing_sid in cur:
                    existing_type = _TCPHandler._skin_type(existing_sid)
                    if not replaced and existing_type in (1, skin_type):
                        next_skins.append(sid)
                        replaced = True
                    if existing_type in (1, skin_type):
                        continue
                    if existing_sid not in next_skins:
                        next_skins.append(existing_sid)
                if not replaced:
                    next_skins.append(sid)
            else:
                next_skins = list(cur)
                if sid not in next_skins:
                    next_skins.append(sid)

            _TCPHandler._set_selected_char_skins(cid, next_skins)
            return True

        @staticmethod
        def _apply_selected_weapon_skin(character_id: object, weapon_id: object, skin_id: object) -> bool:
            cid = _TCPHandler._sproto_read_int(character_id, 0)
            wid = _TCPHandler._sproto_read_int(weapon_id, 0)
            sid = _TCPHandler._sproto_read_int(skin_id, 0)
            if cid <= 0 or wid <= 0 or sid <= 0:
                return False

            handprops = _TCPHandler._skin_handprops(sid)
            if handprops and wid not in handprops:
                return False

            selected_map = _TCPHandler._get_selected_weapon_skins(cid)
            cur = list(selected_map.get(wid, []))
            skin_type = _TCPHandler._skin_type(sid)
            if skin_type not in (4, 5):
                return False

            next_skins: list[int] = []
            replaced = False
            for existing_sid in cur:
                existing_type = _TCPHandler._skin_type(existing_sid)
                if not replaced and existing_type == skin_type:
                    next_skins.append(sid)
                    replaced = True
                if existing_type == skin_type:
                    continue
                if existing_sid not in next_skins:
                    next_skins.append(existing_sid)
            if not replaced:
                next_skins.append(sid)

            _TCPHandler._set_selected_weapon_skin_list(cid, wid, next_skins)
            return True

        @staticmethod
        def _get_show_character_id(default_value: int = 0) -> int:
            root = _TCPHandler._selected_skins_root()
            return max(0, _TCPHandler._sproto_read_int(root.get("show_character_id"), default_value))

        @staticmethod
        def _set_show_character_id(character_id: object) -> int:
            cid = max(0, _TCPHandler._sproto_read_int(character_id, 0))
            root = _TCPHandler._selected_skins_root()
            root["show_character_id"] = cid
            return cid

        @staticmethod
        def _team_id_for_training_camp(camp: object, default_team: int = 1) -> int:
            """
            Resolve BattleTeam for training mode from BattleCamp.

            Keep canonical mapping: attacker->team1, defender->team2.
            This aligns prebattle, room UI and battle barrier ownership.
            """
            camp_id = _TCPHandler._sproto_read_int(camp, 0)
            if camp_id == 1:
                return 1
            if camp_id == 2:
                return 2
            team_id = _TCPHandler._sproto_read_int(default_team, 1)
            if team_id in (1, 2):
                return team_id
            return 1

        @staticmethod
        def _apply_character_defaults(gs: dict, character_id: object, *, force: bool = False) -> None:
            if not isinstance(gs, dict):
                return
            defaults = _TCPHandler._character_default_loadout(character_id)
            primary = gs.get("primary_weapon")
            secondary = gs.get("secondary_weapon")
            current_primary = _TCPHandler._sproto_read_int(
                primary.get("id") if isinstance(primary, dict) else 0,
                0,
            )
            current_secondary = _TCPHandler._sproto_read_int(
                secondary.get("id") if isinstance(secondary, dict) else 0,
                0,
            )
            current_main_skill = _TCPHandler._sproto_read_int(gs.get("main_skill_id"), 0)
            current_sub_skill = _TCPHandler._sproto_read_int(gs.get("sub_skill_id"), 0)
            need_defaults = force or (
                current_primary <= 0
                or current_secondary <= 0
                or current_main_skill <= 0
                or current_sub_skill <= 0
            )
            if not need_defaults:
                return
            gs["primary_weapon"] = {"id": defaults[0], "skin": 0, "attachments": []}
            gs["secondary_weapon"] = {"id": defaults[1], "skin": 0, "attachments": []}
            gs["main_skill_id"] = defaults[2]
            gs["sub_skill_id"] = defaults[3]

        @staticmethod
        def _ensure_character_selection_for_camp(
            gs: dict,
            *,
            preferred_character_id: object = None,
            force_loadout: bool = False,
        ) -> int:
            if not isinstance(gs, dict):
                return 1
            camp_id = _TCPHandler._sproto_read_int(gs.get("camp"), 1)
            if camp_id not in (1, 2):
                camp_id = 1
                gs["camp"] = camp_id
            if _TCPHandler._sproto_read_int(gs.get("mode_id"), 0) == 3:
                gs["team"] = _TCPHandler._team_id_for_training_camp(
                    camp_id,
                    _TCPHandler._sproto_read_int(gs.get("team"), 1),
                )

            unlocked_ids = _TCPHandler._collect_unlocked_character_ids(camp=camp_id)
            if not unlocked_ids:
                unlocked_ids = list(_CHARACTER_IDS_BY_CAMP.get(camp_id) or [])
            if not unlocked_ids:
                unlocked_ids = [_TCPHandler._default_character_for_camp(camp_id)]

            deduped_ids: list[int] = []
            seen_ids: set[int] = set()
            for candidate_raw in unlocked_ids:
                candidate = _TCPHandler._sproto_read_int(candidate_raw, 0)
                if candidate <= 0 or candidate in seen_ids:
                    continue
                if not _TCPHandler._character_is_available(candidate):
                    continue
                if not _TCPHandler._character_matches_camp(candidate, camp_id):
                    continue
                seen_ids.add(candidate)
                deduped_ids.append(candidate)
            if not deduped_ids:
                deduped_ids = [_TCPHandler._default_character_for_camp(camp_id)]

            preferred = _TCPHandler._sproto_read_int(preferred_character_id, 0)
            current = _TCPHandler._sproto_read_int(gs.get("character_id"), 0)
            preferred_show = _TCPHandler._sproto_read_int(_TCPHandler._get_show_character_id(0), 0)
            selected = 0
            if preferred > 0 and preferred in deduped_ids:
                selected = preferred
            elif preferred_show > 0 and preferred_show in deduped_ids:
                selected = preferred_show
            elif current > 0 and current in deduped_ids:
                selected = current
            else:
                selected = deduped_ids[0]

            gs["character_id"] = selected
            _TCPHandler._apply_character_defaults(gs, selected, force=force_loadout or selected != current)
            primary_weapon = gs.get("primary_weapon")
            if isinstance(primary_weapon, dict):
                primary_weapon["skin"] = _TCPHandler._selected_weapon_visual_skin_id(
                    selected,
                    primary_weapon.get("id"),
                    primary_weapon.get("skin"),
                )
            secondary_weapon = gs.get("secondary_weapon")
            if isinstance(secondary_weapon, dict):
                secondary_weapon["skin"] = _TCPHandler._selected_weapon_visual_skin_id(
                    selected,
                    secondary_weapon.get("id"),
                    secondary_weapon.get("skin"),
                )
            return selected

        @staticmethod
        def _sproto_build_integer_list(items: list[int]) -> bytes:
            import struct as _st

            values = [_TCPHandler._sproto_read_int(item, 0) for item in items]
            use_i64 = any(v < -2147483648 or v > 2147483647 for v in values)
            if use_i64:
                payload = b"\x08"
                for v in values:
                    payload += _st.pack("<q", int(v))
            else:
                payload = b"\x04"
                for v in values:
                    payload += _st.pack("<i", int(v))
            return payload

        @staticmethod
        def _sproto_build_struct_list(items: list[bytes]) -> bytes:
            import struct as _st
            payload = b""
            for item in items:
                payload += _st.pack("<I", len(item)) + item
            return payload

        @staticmethod
        def _sproto_parse_struct_list(payload: object) -> list[dict[int, object]]:
            import struct as _st

            if not isinstance(payload, bytes):
                return []

            items: list[dict[int, object]] = []
            offset = 0
            total = len(payload)
            while offset + 4 <= total:
                item_len = _st.unpack_from("<I", payload, offset)[0]
                offset += 4
                if item_len <= 0 or offset + item_len > total:
                    break
                item_blob = payload[offset : offset + item_len]
                offset += item_len
                try:
                    item_fields, _ = _sproto_decode_fields(item_blob, 0)
                except Exception:
                    item_fields = {}
                if isinstance(item_fields, dict):
                    items.append(item_fields)

            return items

        @staticmethod
        def _normalize_attachment_list(raw_value: object) -> list[dict[str, int]]:
            parsed_items: list[dict[str, int]] = []
            if isinstance(raw_value, bytes):
                raw_items = _TCPHandler._sproto_parse_struct_list(raw_value)
            elif isinstance(raw_value, list):
                raw_items = raw_value
            elif isinstance(raw_value, dict):
                raw_items = [raw_value]
            else:
                raw_items = []

            seen_pairs: set[tuple[int, int]] = set()
            for raw_item in raw_items[:128]:
                attachment_id = 0
                attachment_kind = 0
                if isinstance(raw_item, dict):
                    if any(isinstance(key, int) for key in raw_item.keys()):
                        attachment_id = _TCPHandler._sproto_read_int(
                            raw_item.get(_TAG_ATTACHMENT_ID), 0
                        )
                        attachment_kind = _TCPHandler._sproto_read_int(
                            raw_item.get(_TAG_ATTACHMENT_KIND), 0
                        )
                    else:
                        attachment_id = _TCPHandler._sproto_read_int(raw_item.get("id"), 0)
                        attachment_kind = _TCPHandler._sproto_read_int(raw_item.get("kind"), 0)
                elif isinstance(raw_item, int):
                    attachment_id = _TCPHandler._sproto_read_int(raw_item, 0)
                    attachment_kind = 0

                attachment_id = max(0, attachment_id)
                attachment_kind = max(0, attachment_kind)
                key = (attachment_kind, attachment_id)
                if key in seen_pairs:
                    continue
                seen_pairs.add(key)
                parsed_items.append({"id": attachment_id, "kind": attachment_kind})

            # Client-side prebattle CheckAttachments() expects an anchor attachment with kind=0.
            if not any(item.get("kind", -1) == 0 for item in parsed_items):
                parsed_items.insert(0, {"id": 0, "kind": 0})

            return parsed_items[:64]

        @staticmethod
        def _attachment_list_has_real_items(attachments: object) -> bool:
            if not isinstance(attachments, list):
                return False
            for item in attachments:
                if not isinstance(item, dict):
                    continue
                if _TCPHandler._sproto_read_int(item.get("id"), 0) > 0:
                    return True
            return False

        @staticmethod
        def _log_sproto_qc(msg_type: int, contract_name: str, req_body: object, allowed_tags: set[int]) -> None:
            if not _SPROTO_QC_ENABLED:
                return
            if not isinstance(req_body, dict):
                return

            unexpected_tags: list[int] = []
            unexpected_keys: list[str] = []
            for key in req_body.keys():
                if isinstance(key, int):
                    if key not in allowed_tags:
                        unexpected_tags.append(key)
                else:
                    unexpected_keys.append(repr(key))

            if not unexpected_tags and not unexpected_keys:
                return

            _append_utf8_log(
                f"[SPROTO_QC] type={msg_type} contract={contract_name} "
                f"unexpected_tags={sorted(unexpected_tags)} unexpected_keys={unexpected_keys}"
            )

        @staticmethod
        def _room_reset() -> None:
            old_room_id = _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)
            old_players = _room_state.get("players")
            if old_room_id > 0 and isinstance(old_players, dict) and old_players:
                leaving_uids: set[str] = set()
                for entry in old_players.values():
                    if not isinstance(entry, dict):
                        continue
                    uid_s = _uid_str(entry.get("uid"), "")
                    if uid_s:
                        leaving_uids.add(uid_s)
                if leaving_uids:
                    _chat_remove_room_group_members(old_room_id, leaving_uids)
            _room_state["room_id"] = 0
            _room_state["owner_uid"] = 0
            _room_state["players"] = {}
            _room_state["snapshot_sent"] = False
            _room_state["last_snapshot_push_ts"] = 0.0

        @staticmethod
        def _room_allocate_id() -> int:
            room_id = max(100001, _TCPHandler._sproto_read_int(_room_state.get("next_room_id"), 100001))
            _room_state["next_room_id"] = room_id + 1
            return room_id

        @staticmethod
        def _room_is_active() -> bool:
            if _safe_int(_game_state.get("mode_id"), 0) == 3:
                return False
            room_id = _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)
            players = _room_state.get("players")
            return room_id > 0 and isinstance(players, dict) and bool(players)

        @staticmethod
        def _check_and_launch_room_battle(extra_pushes: list[tuple[bytes, str]]) -> bool:
            """Check if all room players are ready, and launch the match with synchronized battle_id."""
            if _safe_int(_game_state.get("mode_id"), 0) == 3 or not _TCPHandler._room_is_active():
                # Single-player match (e.g. training mode)
                _game_state["battle_id"] += 1
                _game_state["_confirm_sent"] = True
                _game_state["_confirm_pending"] = False
                _game_state["in_battle"] = True
                _game_state["prebattle_flow_active"] = False
                _game_state["_last_confirm_push_ts"] = time.time()
                battle_info = _TCPHandler._build_battle_info_push(_game_state, target_pd=_player_data)
                extra_pushes.append((battle_info, "sproto-push-battle-info"))
                _log_line = f"[Match] Single-player / Training battle launched: battle_id={_game_state['battle_id']} character={_game_state.get('character_id')} region={_game_state.get('region_id')}"
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
                return True

            room_players = _room_state.get("players", {})
            if not isinstance(room_players, dict) or not room_players:
                return False

            # Check if all players in the room are ready
            all_ready = True
            unready_uids = []
            for p_uid_s, p_entry in room_players.items():
                if not isinstance(p_entry, dict):
                    continue
                p_uid = _safe_int(p_entry.get("uid"), 0)
                p_stage = _safe_int(p_entry.get("prebattle_stage"), 1)
                p_ready = bool(p_entry.get("is_ready", False)) or (p_stage >= 4)
                if not p_ready:
                    all_ready = False
                    unready_uids.append(p_uid)

            if not all_ready:
                _log_line = f"[Room] PreBattle waiting for other players to ready: {unready_uids}"
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)
                return False

            # ALL players are ready!
            if not bool(_room_state.get("battle_launched", False)):
                _room_state["battle_launched"] = True
                _game_state["battle_id"] += 1
                _game_state["_confirm_sent"] = True
                _game_state["_confirm_pending"] = False
                _game_state["_last_confirm_push_ts"] = time.time()
                current_battle_id = _game_state["battle_id"]

                _log_line = (
                    f"[Room] ALL {len(room_players)} players ready! Launching synchronized "
                    f"battle_id={current_battle_id} for players={list(room_players.keys())}"
                )
                print(_console_safe(_log_line)); _append_utf8_log(_log_line)

                # Send customized battle_info to every room participant
                for p_uid_s, p_entry in room_players.items():
                    p_uid = _safe_int(p_entry.get("uid"), 0)
                    if p_uid <= 0:
                        continue
                    p_pd = _online_ensure_profile(p_uid)
                    b_push = _TCPHandler._build_battle_info_push(_game_state, target_pd=p_pd)
                    _TCPHandler._queue_pending_push(p_uid, (b_push, "sproto-push-battle-info"))

                return True

            return False

        @staticmethod
        def _room_ensure_local_player(pd: dict, gs: dict, *, make_owner: bool = False, preferred_camp: int | None = None, preferred_index: int | None = None) -> dict:
            players = _room_state.get("players")
            if not isinstance(players, dict):
                players = {}
                _room_state["players"] = players

            uid = max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))
            key = str(uid)
            entry = players.get(key)
            if not isinstance(entry, dict):
                entry = {}

            if preferred_camp is not None:
                player_camp = max(1, int(preferred_camp))
            elif entry.get("camp"):
                player_camp = max(1, _TCPHandler._sproto_read_int(entry.get("camp"), 1))
            elif make_owner:
                player_camp = max(1, _TCPHandler._sproto_read_int(gs.get("camp"), 1))
            else:
                camp1_players = [
                    v for v in players.values()
                    if isinstance(v, dict)
                    and _TCPHandler._sproto_read_int(v.get("uid"), 0) != uid
                    and _TCPHandler._sproto_read_int(v.get("camp"), 1) == 1
                ]
                camp2_players = [
                    v for v in players.values()
                    if isinstance(v, dict)
                    and _TCPHandler._sproto_read_int(v.get("uid"), 0) != uid
                    and _TCPHandler._sproto_read_int(v.get("camp"), 1) == 2
                ]
                if len(camp1_players) <= len(camp2_players):
                    player_camp = 1
                else:
                    player_camp = 2

            used_indexes_in_camp = {
                _TCPHandler._sproto_read_int(v.get("index"), 0)
                for v in players.values()
                if isinstance(v, dict)
                and _TCPHandler._sproto_read_int(v.get("uid"), 0) != uid
                and _TCPHandler._sproto_read_int(v.get("camp"), 1) == player_camp
            }

            if preferred_index is not None and preferred_index > 0 and preferred_index not in used_indexes_in_camp:
                current_index = preferred_index
            else:
                current_index = _TCPHandler._sproto_read_int(entry.get("index"), 0)
                if current_index <= 0 or current_index in used_indexes_in_camp:
                    next_index = 1
                    while next_index in used_indexes_in_camp:
                        next_index += 1
                    current_index = next_index

            entry["uid"] = uid
            entry["name"] = _sanitize_display_name(pd.get("name"), "Local")
            entry["level"] = max(1, _TCPHandler._sproto_read_int(pd.get("level"), 1))
            _icon, _icon_url = _normalize_player_base_icon(
                _TCPHandler._sproto_read_int(pd.get("icon"), 0),
                str(pd.get("icon_url") or ""),
            )
            entry["icon"] = _icon
            entry["camp"] = player_camp
            entry["index"] = current_index
            entry["rank_score"] = max(0, _TCPHandler._sproto_read_int(gs.get("rank_score"), 0))
            entry["icon_url"] = _icon_url
            players[key] = entry

            if make_owner or _TCPHandler._sproto_read_int(_room_state.get("owner_uid"), 0) <= 0:
                _room_state["owner_uid"] = uid

            return entry

        @staticmethod
        def _room_remove_player(uid: int) -> tuple[dict | None, int]:
            players = _room_state.get("players")
            if not isinstance(players, dict):
                return None, 0

            removed = players.pop(str(uid), None)
            if not isinstance(removed, dict):
                return None, 0

            owner_uid = _TCPHandler._sproto_read_int(_room_state.get("owner_uid"), 0)
            if owner_uid == uid or not players:
                _TCPHandler._room_reset()
                return removed, 0

            next_owner_candidates = [
                (entry, _TCPHandler._sproto_read_int(entry.get("index"), 9999), _TCPHandler._sproto_read_int(entry.get("uid"), 0))
                for entry in players.values()
                if isinstance(entry, dict)
            ]
            if not next_owner_candidates:
                _TCPHandler._room_reset()
                return removed, 0

            next_owner = min(next_owner_candidates, key=lambda item: (item[1], item[2]))[0]
            next_owner_uid = _TCPHandler._sproto_read_int(next_owner.get("uid"), 0)
            _room_state["owner_uid"] = next_owner_uid
            return removed, next_owner_uid

        @staticmethod
        def _room_snapshot_pushes() -> list[tuple[bytes, str]]:
            if not _TCPHandler._room_is_active():
                return []

            players = _room_state.get("players")
            if not isinstance(players, dict):
                return []

            sorted_players = sorted(
                [entry for entry in players.values() if isinstance(entry, dict)],
                key=lambda e: (
                    _TCPHandler._sproto_read_int(e.get("index"), 9999),
                    _TCPHandler._sproto_read_int(e.get("uid"), 0),
                ),
            )

            player_structs: list[bytes] = []
            for entry in sorted_players:
                player_structs.append(_encode_game_player_info(
                    _TCPHandler._sproto_read_int(entry.get("uid"), 0),
                    str(entry.get("name") or "Local"),
                    max(1, _TCPHandler._sproto_read_int(entry.get("level"), 1)),
                    max(0, _TCPHandler._sproto_read_int(entry.get("icon"), 0)),
                    max(1, _TCPHandler._sproto_read_int(entry.get("camp"), 1)),
                    max(1, _TCPHandler._sproto_read_int(entry.get("index"), 1)),
                    max(0, _TCPHandler._sproto_read_int(entry.get("rank_score"), 0)),
                    str(entry.get("icon_url") or ""),
                ))

            players_blob = _TCPHandler._sproto_build_struct_list(player_structs)
            room_state_push = _sproto_build_push_frame(1003, [
                (_TAG_RSP_JOIN_ROOM_STATE_STATE, 1),
            ])
            room_entered_push = _sproto_build_push_frame(1004, [
                (_TAG_RSP_ROOM_ENTERED_ROOM_ID, _TCPHandler._sproto_read_int(_room_state.get("room_id"), 0)),
                (_TAG_RSP_ROOM_ENTERED_OWNER_ID, _TCPHandler._sproto_read_int(_room_state.get("owner_uid"), 0)),
                (_TAG_RSP_ROOM_ENTERED_PLAYERS, players_blob),
                (_TAG_RSP_ROOM_ENTERED_BATTLE_ZONE, _TCPHandler._sproto_read_int(_room_state.get("battle_zone"), 1)),
                (_TAG_RSP_ROOM_ENTERED_MAP_ID, _TCPHandler._sproto_read_int(_room_state.get("map_id"), 1)),
                (_TAG_RSP_ROOM_ENTERED_MODE_ID, _TCPHandler._sproto_read_int(_room_state.get("mode_id"), 0)),
            ])
            return [
                (room_state_push, "sproto-push-join-room-state"),
                (room_entered_push, "sproto-push-room-entered"),
            ]

        @staticmethod
        def _room_position_notify_push(
            mover_uid: int = 0,
            swapped_uid: int | None = None,
        ) -> tuple[bytes, str] | None:
            players = _room_state.get("players")
            if not isinstance(players, dict) or not players:
                return None

            if mover_uid <= 0:
                first_entry = next((e for e in players.values() if isinstance(e, dict)), None)
                if not isinstance(first_entry, dict):
                    return None
                mover_uid = _safe_int(first_entry.get("uid"), 0)

            mover_entry = players.get(str(mover_uid))
            if not isinstance(mover_entry, dict):
                return None

            pos_items = [
                _encode_game_room_position_info(
                    mover_uid,
                    max(1, _TCPHandler._sproto_read_int(mover_entry.get("index"), 1)),
                    max(1, _TCPHandler._sproto_read_int(mover_entry.get("camp"), 1)),
                )
            ]

            if swapped_uid is not None and str(swapped_uid) in players:
                swapped_entry = players[str(swapped_uid)]
                if isinstance(swapped_entry, dict):
                    pos_items.append(
                        _encode_game_room_position_info(
                            swapped_uid,
                            max(1, _TCPHandler._sproto_read_int(swapped_entry.get("index"), 1)),
                            max(1, _TCPHandler._sproto_read_int(swapped_entry.get("camp"), 1)),
                        )
                    )

            push = _sproto_build_push_frame(1059, [
                (_TAG_RSP_POS_CHANGE_NOTIFY_PLAYER_POSITIONS, _TCPHandler._sproto_build_struct_list(pos_items)),
            ])
            return push, "sproto-push-pos-change-notify"

        @staticmethod
        def _team_reset() -> None:
            _team_state["team_id"] = ""
            _team_state["captain_uid"] = 0
            _team_state["members"] = {}

        @staticmethod
        def _team_allocate_id() -> str:
            numeric = max(1, _TCPHandler._sproto_read_int(_team_state.get("next_team_id"), 1))
            _team_state["next_team_id"] = numeric + 1
            return f"local-team-{numeric}"

        @staticmethod
        def _team_find_member(uid: int) -> dict | None:
            members = _team_state.get("members")
            if not isinstance(members, dict):
                return None
            member = members.get(str(uid))
            if isinstance(member, dict):
                return member
            return None

        @staticmethod
        def _team_remove_member(uid: object) -> bool:
            uid_val = max(1, _TCPHandler._sproto_read_int(uid, 1000001))
            members = _team_state.get("members")
            if not isinstance(members, dict):
                return False
            removed = members.pop(str(uid_val), None)
            if not isinstance(removed, dict):
                return False
            if not members:
                _TCPHandler._team_reset()
                return True
            if _TCPHandler._sproto_read_int(_team_state.get("captain_uid"), 0) == uid_val:
                next_candidates = [entry for entry in members.values() if isinstance(entry, dict)]
                if next_candidates:
                    next_member = min(
                        next_candidates,
                        key=lambda e: (
                            _TCPHandler._sproto_read_int(e.get("pos"), 9999),
                            _TCPHandler._sproto_read_int(e.get("uid"), 0),
                        ),
                    )
                    _team_state["captain_uid"] = _TCPHandler._sproto_read_int(next_member.get("uid"), 0)
                else:
                    _team_state["captain_uid"] = 0
            return True

        @staticmethod
        def _team_ensure_local_member(
            pd: dict,
            *,
            ready_status: bool | None = None,
            force_captain: bool = False,
            uid_override: object = None,
        ) -> dict:
            members = _team_state.get("members")
            if not isinstance(members, dict):
                members = {}
                _team_state["members"] = members

            pd_uid = max(1, _TCPHandler._sproto_read_int(pd.get("uid"), 1000001))
            uid = max(1, _TCPHandler._sproto_read_int(uid_override if uid_override is not None else pd_uid, pd_uid))
            key = str(uid)
            entry = members.get(key)
            if not isinstance(entry, dict):
                entry = {}

            profile = _online_ensure_profile(
                uid,
                local_pd=pd if pd_uid == uid else None,
            )
            profile_name = str(profile.get("name") or pd.get("name") or "Local")
            profile_level = max(1, _safe_int(profile.get("level"), _TCPHandler._sproto_read_int(pd.get("level"), 1)))
            profile_icon = max(0, _safe_int(profile.get("icon"), _TCPHandler._sproto_read_int(pd.get("icon"), 0)))
            profile_icon_url = str(profile.get("icon_url") or pd.get("icon_url") or "")
            profile_rank = max(
                0,
                _safe_int(
                    profile.get("rank_score"),
                    _TCPHandler._sproto_read_int(_game_state.get("rank_score"), 0),
                ),
            )

            used_positions = {
                _TCPHandler._sproto_read_int(v.get("pos"), 0)
                for v in members.values()
                if isinstance(v, dict)
            }
            pos = _TCPHandler._sproto_read_int(entry.get("pos"), 0)
            if pos <= 0:
                pos = 1
                while pos in used_positions:
                    pos += 1

            if not _team_state.get("team_id"):
                _team_state["team_id"] = _TCPHandler._team_allocate_id()
                _team_state["battle_zone"] = _TCPHandler._sproto_read_int(_game_state.get("battle_zone"), 1)

            entry["uid"] = uid
            entry["pos"] = pos
            entry["name"] = _sanitize_display_name(profile_name, "Local")
            _icon, _icon_url = _normalize_player_base_icon(
                profile_icon,
                profile_icon_url,
            )
            entry["icon"] = _icon
            entry["level"] = profile_level
            entry["mmr"] = profile_rank
            entry["icon_url"] = _icon_url
            entry["rank_score"] = profile_rank
            entry["show_character_id"] = max(
                1,
                _TCPHandler._sproto_read_int(
                    _TCPHandler._get_show_character_id(
                        _TCPHandler._sproto_read_int(_game_state.get("character_id"), 1)
                    ),
                    1,
                ),
            )
            if ready_status is not None:
                entry["is_ready"] = bool(ready_status)
            else:
                entry["is_ready"] = bool(entry.get("is_ready", False))
            members[key] = entry

            captain_uid = _TCPHandler._sproto_read_int(_team_state.get("captain_uid"), 0)
            if force_captain or captain_uid <= 0:
                _team_state["captain_uid"] = uid

            return entry

        @staticmethod
        def _team_sync_push() -> tuple[bytes, str] | None:
            members = _team_state.get("members")
            if not isinstance(members, dict) or not members:
                return None

            team_members = sorted(
                [entry for entry in members.values() if isinstance(entry, dict)],
                key=lambda e: (_TCPHandler._sproto_read_int(e.get("pos"), 9999), _TCPHandler._sproto_read_int(e.get("uid"), 0)),
            )
            member_blobs: list[bytes] = []
            for entry in team_members:
                info_blob = _encode_team_player_info(
                    _TCPHandler._sproto_read_int(entry.get("uid"), 0),
                    str(entry.get("name") or "Local"),
                    _TCPHandler._sproto_read_int(entry.get("icon"), 0),
                    max(1, _TCPHandler._sproto_read_int(entry.get("level"), 1)),
                    max(0, _TCPHandler._sproto_read_int(entry.get("mmr"), 0)),
                    str(entry.get("icon_url") or ""),
                    max(0, _TCPHandler._sproto_read_int(entry.get("rank_score"), 0)),
                )
                member_blobs.append(_encode_team_member(
                    max(1, _TCPHandler._sproto_read_int(entry.get("pos"), 1)),
                    info_blob,
                    bool(entry.get("is_ready", False)),
                ))

            members_blob = _TCPHandler._sproto_build_struct_list(member_blobs)
            captain_uid = _TCPHandler._sproto_read_int(_team_state.get("captain_uid"), 0)
            captain_pos = 1
            for entry in team_members:
                if _TCPHandler._sproto_read_int(entry.get("uid"), 0) == captain_uid:
                    captain_pos = max(1, _TCPHandler._sproto_read_int(entry.get("pos"), 1))
                    break

            team_data_blob = _encode_team_data(
                str(_team_state.get("team_id") or "local-team-0"),
                members_blob,
                captain_pos,
                max(1, _TCPHandler._sproto_read_int(_team_state.get("capacity"), 5)),
                max(1, _TCPHandler._sproto_read_int(_team_state.get("battle_zone"), 1)),
                max(0, _TCPHandler._sproto_read_int(_team_state.get("combat_type"), 0)),
                0,
                999999,
            )

            push = _sproto_build_push_frame(408, [
                (_TAG_TEAM_SYNC_NOTIFY_TEAM_DATA, team_data_blob),
            ])
            return push, "sproto-push-team-sync"

        @staticmethod
        def _team_member_enter_pushes() -> list[tuple[bytes, str]]:
            members = _team_state.get("members")
            if not isinstance(members, dict) or not members:
                return []

            team_members = sorted(
                [entry for entry in members.values() if isinstance(entry, dict)],
                key=lambda e: (_TCPHandler._sproto_read_int(e.get("pos"), 9999), _TCPHandler._sproto_read_int(e.get("uid"), 0)),
            )
            pushes: list[tuple[bytes, str]] = []
            for entry in team_members:
                info_blob = _encode_team_player_info(
                    _TCPHandler._sproto_read_int(entry.get("uid"), 0),
                    str(entry.get("name") or "Local"),
                    _TCPHandler._sproto_read_int(entry.get("icon"), 0),
                    max(1, _TCPHandler._sproto_read_int(entry.get("level"), 1)),
                    max(0, _TCPHandler._sproto_read_int(entry.get("mmr"), 0)),
                    str(entry.get("icon_url") or ""),
                    max(0, _TCPHandler._sproto_read_int(entry.get("rank_score"), 0)),
                )
                member_blob = _encode_team_member(
                    max(1, _TCPHandler._sproto_read_int(entry.get("pos"), 1)),
                    info_blob,
                    bool(entry.get("is_ready", False)),
                )
                pushes.append((
                    _sproto_build_push_frame(406, [
                        (_TAG_TEAM_MEMBER_ENTER_NOTIFY_NEW_MEMBER, member_blob),
                    ]),
                    "sproto-push-team-member-enter",
                ))
            return pushes

        @staticmethod
        def _team_member_sync_pushes() -> list[tuple[bytes, str]]:
            members = _team_state.get("members")
            if not isinstance(members, dict) or not members:
                return []

            team_members = sorted(
                [entry for entry in members.values() if isinstance(entry, dict)],
                key=lambda e: (_TCPHandler._sproto_read_int(e.get("pos"), 9999), _TCPHandler._sproto_read_int(e.get("uid"), 0)),
            )
            pushes: list[tuple[bytes, str]] = []
            for entry in team_members:
                info_blob = _encode_team_player_info(
                    _TCPHandler._sproto_read_int(entry.get("uid"), 0),
                    str(entry.get("name") or "Local"),
                    _TCPHandler._sproto_read_int(entry.get("icon"), 0),
                    max(1, _TCPHandler._sproto_read_int(entry.get("level"), 1)),
                    max(0, _TCPHandler._sproto_read_int(entry.get("mmr"), 0)),
                    str(entry.get("icon_url") or ""),
                    max(0, _TCPHandler._sproto_read_int(entry.get("rank_score"), 0)),
                )
                member_blob = _encode_team_member(
                    max(1, _TCPHandler._sproto_read_int(entry.get("pos"), 1)),
                    info_blob,
                    bool(entry.get("is_ready", False)),
                )
                pushes.append((
                    _sproto_build_push_frame(407, [
                        (_TAG_TEAM_MEMBER_SYNC_NOTIFY_MEMBER, member_blob),
                    ]),
                    "sproto-push-team-member-sync",
                ))
            return pushes

        @staticmethod
        def _team_member_leave_push(leave_pos: int, leave_type: int = 1, leave_uid: int = 0) -> tuple[bytes, str]:
            push = _sproto_build_push_frame(405, [
                (_TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_TYPE, leave_type),
                (_TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_POS, leave_pos),
                (_TAG_TEAM_MEMBER_LEAVE_NOTIFY_LEAVE_UID, leave_uid),
            ])
            return push, "sproto-push-team-member-leave"

        @staticmethod
        def _team_append_sync_pushes(extra_pushes: list[tuple[bytes, str]]) -> None:
            team_push = _TCPHandler._team_sync_push()
            if team_push is not None:
                extra_pushes.append(team_push)
            extra_pushes.extend(_TCPHandler._team_member_enter_pushes())
            extra_pushes.extend(_TCPHandler._team_member_sync_pushes())

        @staticmethod
        def _mail_find(mail_id: int) -> dict | None:
            mails = _mail_state.get("mails")
            if not isinstance(mails, list):
                return None
            for mail in mails:
                if not isinstance(mail, dict):
                    continue
                if _TCPHandler._sproto_read_int(mail.get("id"), 0) == mail_id:
                    return mail
            return None

        @staticmethod
        def _normalize_mail_reward_id(reward_id: int) -> int:
            rid = max(0, _TCPHandler._sproto_read_int(reward_id, 0))
            if rid in {1, 1001, _BAG_ID_DIAMOND}:
                return _BAG_ID_DIAMOND
            if rid in {2, 1002, _BAG_ID_GOLD}:
                return _BAG_ID_GOLD
            return rid

        @staticmethod
        def _mail_reward_money_kind(reward_id: int) -> str | None:
            rid = _TCPHandler._normalize_mail_reward_id(reward_id)
            if rid == _BAG_ID_DIAMOND:
                return "diamond"
            if rid == _BAG_ID_GOLD:
                return "gold"
            return None

        @staticmethod
        def _mail_encode_entry(mail: dict) -> bytes:
            rewards_src = mail.get("rewards")
            reward_entries: list[bytes] = []
            if isinstance(rewards_src, list):
                for reward in rewards_src:
                    if not isinstance(reward, dict):
                        continue
                    reward_id = _TCPHandler._normalize_mail_reward_id(
                        _TCPHandler._sproto_read_int(reward.get("id"), 0)
                    )
                    reward_num = _TCPHandler._sproto_read_int(reward.get("num"), 0)
                    if reward_id <= 0 or reward_num <= 0:
                        continue
                    reward_entries.append(_encode_mail_reward(reward_id, reward_num))

            rewards_blob = _TCPHandler._sproto_build_struct_list(reward_entries)
            return _encode_mail_entry(
                _TCPHandler._sproto_read_int(mail.get("id"), 0),
                str(mail.get("title") or "Mail"),
                str(mail.get("content") or ""),
                max(1, _TCPHandler._sproto_read_int(mail.get("mail_type"), 1)),
                bool(mail.get("is_custom", True)),
                _TCPHandler._sproto_read_int(mail.get("expire_ts"), int(time.time()) + 86400),
                max(0, _TCPHandler._sproto_read_int(mail.get("status"), _MAIL_STATUS_NOT_READ)),
                rewards_blob,
                _TCPHandler._sproto_read_int(mail.get("create_ts"), int(time.time())),
                b"",
                max(0, _TCPHandler._sproto_read_int(mail.get("template_type"), 0)),
            )

        @staticmethod
        def _mail_list_push() -> tuple[bytes, str]:
            mails = _mail_state.get("mails")
            if not isinstance(mails, list):
                mails = []

            sorted_mails = sorted(
                [mail for mail in mails if isinstance(mail, dict)],
                key=lambda item: -_TCPHandler._sproto_read_int(item.get("create_ts"), 0),
            )
            mail_entries = [_TCPHandler._mail_encode_entry(mail) for mail in sorted_mails]
            mail_blob = _TCPHandler._sproto_build_struct_list(mail_entries)
            push = _sproto_build_push_frame(505, [
                (_TAG_MAIL_LIST_RES_MAIL_LIST, mail_blob),
                (_TAG_MAIL_LIST_RES_END_FLAG, True),
            ])
            return push, "sproto-push-mail-list-res"

        @staticmethod
        def _build_invite_notify_push(
            invite_type: int,
            identify_id: str,
            combat_type: int,
            *,
            inviter_uid: object = None,
        ) -> tuple[bytes, str]:
            inviter_uid_val = max(1, _TCPHandler._sproto_read_int(inviter_uid, _TCPHandler._sproto_read_int(_player_data.get("uid"), 1000001)))
            inviter_profile = _online_ensure_profile(
                inviter_uid_val,
                local_pd=_player_data if _TCPHandler._sproto_read_int(_player_data.get("uid"), 0) == inviter_uid_val else None,
            )
            invite_player = _encode_invite_player_info(
                inviter_uid_val,
                _sanitize_display_name(inviter_profile.get("name"), "Local"),
                max(0, _safe_int(inviter_profile.get("icon"), 0)),
                max(1, _safe_int(inviter_profile.get("level"), 1)),
                str(inviter_profile.get("icon_url") or ""),
                "",
                max(0, _safe_int(inviter_profile.get("rank_score"), _TCPHandler._sproto_read_int(_game_state.get("rank_score"), 0))),
            )
            push = _sproto_build_push_frame(303, [
                (_TAG_INVITE_NOTIFY_PLAYER, invite_player),
                (_TAG_INVITE_NOTIFY_TYPE, max(0, invite_type)),
                (_TAG_INVITE_NOTIFY_IDENTIFY_ID, identify_id),
                (_TAG_INVITE_NOTIFY_COMBAT_TYPE, max(0, combat_type)),
            ])
            return push, "sproto-push-invite-notify"

        @staticmethod
        def _default_store_item_id_for_type(store_type: int) -> int:
            defaults = _STORE_TYPE_DEFAULT_ITEMS.get(store_type)
            if isinstance(defaults, list) and defaults:
                first_id = _TCPHandler._sproto_read_int(defaults[0], 0)
                if first_id > 0:
                    return first_id
            overrides = _store_state.get("store_type_overrides")
            if isinstance(overrides, dict):
                override = overrides.get(store_type)
                parsed = _TCPHandler._sproto_read_int(override, 0)
                if parsed > 0:
                    return parsed
            default_map = {
                _STORE_TYPE_CHARACTER: 20,
                _STORE_TYPE_SUIT: 100,
                _STORE_TYPE_HEAD: 900220020,
                _STORE_TYPE_BODY: 900230020,
                _STORE_TYPE_WEAPON_PT: 1000110010,
                _STORE_TYPE_WEAPON_GJ: 50010,
                _STORE_TYPE_BUNDLE: 10001,
                _STORE_TYPE_BOX: 20001,
            }
            return default_map.get(store_type, 0)

        @staticmethod
        def _default_store_items_for_type(store_type: int) -> list[int]:
            defaults = _STORE_TYPE_DEFAULT_ITEMS.get(store_type)
            result: list[int] = []
            if isinstance(defaults, list):
                for item_id in defaults:
                    parsed = _TCPHandler._sproto_read_int(item_id, 0)
                    if parsed > 0 and parsed not in result:
                        result.append(parsed)

            if store_type == _STORE_TYPE_CHARACTER:
                for fallback_item_id in _TYPE1_AGENT_PRICE_FALLBACK_IDS:
                    parsed = _TCPHandler._sproto_read_int(fallback_item_id, 0)
                    if parsed > 0 and parsed not in result:
                        result.append(parsed)

            if not result and store_type == _STORE_TYPE_BUNDLE:
                for bundle_id in sorted(_BUNDLE_PRICE_DEFAULTS.keys()):
                    parsed = _TCPHandler._sproto_read_int(bundle_id, 0)
                    if parsed > 0 and parsed not in result:
                        result.append(parsed)

            if not result:
                fallback_id = _TCPHandler._default_store_item_id_for_type(store_type)
                if fallback_id > 0:
                    result.append(fallback_id)

            overrides = _store_state.get("store_type_overrides")
            if isinstance(overrides, dict):
                override = _TCPHandler._sproto_read_int(overrides.get(store_type), 0)
                if override > 0 and override not in result:
                    if store_type == _STORE_TYPE_CHARACTER:
                        meta = _STORE_ITEM_META_FROM_LUA.get(override, {})
                        has_price = (
                            _TCPHandler._sproto_read_int(meta.get("gem_price"), 0) > 0
                            or _TCPHandler._sproto_read_int(meta.get("coin_price"), 0) > 0
                        )
                        if _TCPHandler._sproto_read_int(_BAG_TYPE_BY_ID.get(override), 0) != _BAG_TYPE_HERO or not has_price:
                            override = 0
                    elif store_type == _STORE_TYPE_BOX:
                        resolved_box_id = _TCPHandler._sproto_read_int(_CHEST_ID_TO_BOX_ID.get(override), override)
                        display_bag_id = _TCPHandler._sproto_read_int(_BOX_ID_TO_DISPLAY_BAG_ID.get(resolved_box_id), 0)
                        if display_bag_id <= 0:
                            override = 0

                    if override > 0:
                        result.insert(0, override)

            return result[:_STORE_ITEMS_PER_TYPE_LIMIT]

        @staticmethod
        def _is_known_box_id(box_id: int) -> bool:
            parsed = _TCPHandler._sproto_read_int(box_id, 0)
            return parsed > 0 and parsed in _KNOWN_BOX_IDS

        @staticmethod
        def _collect_type_box_counts() -> dict[str, int]:
            out: dict[str, int] = {}
            inventory = _store_state.get("box_inventory")
            if not isinstance(inventory, dict):
                return out

            for box_id_raw, count_raw in inventory.items():
                box_id = _TCPHandler._sproto_read_int(box_id_raw, 0)
                count = max(0, _TCPHandler._sproto_read_int(count_raw, 0))
                if box_id <= 0 or count <= 0:
                    continue
                resolved_box_id = _TCPHandler._resolve_box_id(box_id)
                if resolved_box_id <= 0 or not _TCPHandler._is_known_box_id(resolved_box_id):
                    continue
                if resolved_box_id in _STORE_TYPE_9_BOX_IDS:
                    continue
                box_key = str(resolved_box_id)
                out[box_key] = out.get(box_key, 0) + count

            return out

        @staticmethod
        def _consume_box_inventory(box_or_chest_id: int, count: int) -> int:
            inventory = _TCPHandler._ensure_store_counter_dict("box_inventory")
            resolved_box_id = _TCPHandler._resolve_box_id(box_or_chest_id)
            if resolved_box_id <= 0:
                return 0

            consume = max(0, _TCPHandler._sproto_read_int(count, 0))
            if consume <= 0:
                return 0

            key = str(resolved_box_id)
            cur = max(0, _TCPHandler._sproto_read_int(inventory.get(key), 0))
            if cur <= 0:
                return 0

            taken = min(cur, consume)
            remain = cur - taken
            if remain > 0:
                inventory[key] = remain
            else:
                inventory.pop(key, None)
            return taken

        @staticmethod
        def _collect_box_open_counts() -> dict[str, int]:
            out: dict[str, int] = {}
            counters = _store_state.get("box_open_counters")
            if not isinstance(counters, dict):
                return out

            for box_id_raw, count_raw in counters.items():
                box_id = _TCPHandler._sproto_read_int(box_id_raw, 0)
                count = max(0, _TCPHandler._sproto_read_int(count_raw, 0))
                if box_id <= 0 or count <= 0:
                    continue
                resolved_box_id = _TCPHandler._resolve_box_id(box_id)
                if resolved_box_id <= 0:
                    continue
                if resolved_box_id in _STORE_TYPE_9_BOX_IDS:
                    continue
                box_key = str(resolved_box_id)
                prev = out.get(box_key, 0)
                if count > prev:
                    out[box_key] = count

            return out

        @staticmethod
        def _build_event_stat_struct(event_type: str, stats: dict[str, int]) -> bytes | None:
            if not isinstance(stats, dict) or not stats:
                return None

            normalized: list[tuple[int, str, int]] = []
            for stat_key_raw, stat_val_raw in stats.items():
                stat_key_num = _TCPHandler._sproto_read_int(stat_key_raw, 0)
                stat_val = max(0, _TCPHandler._sproto_read_int(stat_val_raw, 0))
                if stat_key_num < 0 or stat_val < 0:
                    continue
                normalized.append((stat_key_num, str(stat_key_num), stat_val))

            if not normalized:
                return None

            normalized.sort(key=lambda x: x[0])
            stat_entries: list[bytes] = []
            for _, stat_key, stat_val in normalized:
                stat_entries.append(_sproto_encode_fields([
                    (0, stat_key),
                    (1, stat_val),
                ]))

            stats_list = _TCPHandler._sproto_build_struct_list(stat_entries)
            return _sproto_encode_fields([
                (0, event_type),
                (1, stats_list),
            ])

        @staticmethod
        def _build_role_event_stats_list(pd: dict | None = None) -> bytes:
            if _DISABLE_EVENT_STATS:
                return _TCPHandler._sproto_build_struct_list([])

            target_pd = pd if isinstance(pd, dict) else _player_data

            event_entries: list[bytes] = []

            # 1. ICON_UNLOCK_STATE
            icon_stats = {"0": 9223372036854775807, "1": 9223372036854775807, "2": 9223372036854775807}
            icon_unlock = _TCPHandler._build_event_stat_struct("ICON_UNLOCK_STATE", icon_stats)
            if icon_unlock is not None:
                event_entries.append(icon_unlock)

            # 2. TYPE_BOX & BOX_COUNT
            type_box = _TCPHandler._build_event_stat_struct(
                _EVENT_TYPE_TYPE_BOX,
                _TCPHandler._collect_type_box_counts(),
            )
            if type_box is not None:
                event_entries.append(type_box)

            box_count = _TCPHandler._build_event_stat_struct(
                _EVENT_TYPE_BOX_COUNT,
                _TCPHandler._collect_box_open_counts(),
            )
            if box_count is not None:
                event_entries.append(box_count)

            # Helper to create BattleStatsInfo dictionary
            def _make_combat_dict(battles, wins, kills, deaths, assists, mvp, headshots, score):
                if battles == 0 and (kills > 0 or wins > 0 or score > 0):
                    battles = max(1, wins)
                rounds = max(battles * 4, 1 if battles > 0 else 0)
                attack_rounds = max(rounds // 2, 0)
                defend_rounds = max(rounds - attack_rounds, 0)
                attack_wins = max(min(wins * 2, attack_rounds), 0)
                defend_wins = max(min(wins * 2, defend_rounds), 0)
                shots = max(kills * 15 + 20 if kills > 0 else 0, headshots * 2)
                return {
                    "1": battles,          # num (Total battles)
                    "2": wins,             # win_num (Wins)
                    "3": rounds,           # round_num (Rounds)
                    "4": score,            # score (Battle Score)
                    "5": kills,            # kill_num (Kills)
                    "6": deaths,           # dead_num (Deaths)
                    "7": assists,          # assist_num (Assists)
                    "8": assists,          # help_num (Rescue)
                    "9": 0,                # be_helped_num
                    "10": mvp,             # mvp_num (MVP)
                    "11": attack_rounds,   # attack_num
                    "12": attack_wins,     # attack_win_num
                    "13": defend_rounds,   # defend_num
                    "14": defend_wins,     # defend_win_num
                    "15": shots,           # shoot_num
                    "16": headshots,       # head_shot_num
                    "17": 0,               # melee_kill_num
                    "18": 0,               # penetrate_kill_num
                    "19": min(wins, 5),    # combo_win
                    "20": kills,           # hit_down_num
                    "21": 5000 if battles > 0 else 0, # alive_rate (50.00%)
                    "22": min(kills, 15),  # max_kill_num
                }

            # 3. Mode statistics
            all_kills = max(0, _TCPHandler._sproto_read_int(target_pd.get("battle_kill") or target_pd.get("kills"), 0))
            all_deaths = max(0, _TCPHandler._sproto_read_int(target_pd.get("battle_dead") or target_pd.get("deaths"), 0))
            all_assists = max(0, _TCPHandler._sproto_read_int(target_pd.get("battle_assist") or target_pd.get("assists"), 0))
            all_battles = max(0, _TCPHandler._sproto_read_int(target_pd.get("battle_times") or target_pd.get("total_matches"), 0))
            all_wins = max(0, _TCPHandler._sproto_read_int(target_pd.get("win_times") or target_pd.get("wins"), 0))
            all_score = max(0, _TCPHandler._sproto_read_int(target_pd.get("battle_score"), all_kills * 100 + all_assists * 50))
            all_mvp = max(0, _TCPHandler._sproto_read_int(target_pd.get("mvp_count"), 0))
            all_headshots = max(0, _TCPHandler._sproto_read_int(target_pd.get("headshots"), 0))

            # Ranked Mode
            rank_kills = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_kills"), all_kills))
            rank_deaths = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_deaths"), all_deaths))
            rank_assists = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_assists"), all_assists))
            rank_battles = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_battles"), all_battles))
            rank_wins = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_wins"), all_wins))
            rank_mvp = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_mvp"), all_mvp))
            rank_headshots = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_headshots"), all_headshots))
            rank_score = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_score_total"), rank_kills * 100 + rank_assists * 50))

            # Normal Mode
            has_explicit_normal = "normal_kills" in target_pd or "normal_battles" in target_pd
            if has_explicit_normal:
                normal_kills = max(0, _TCPHandler._sproto_read_int(target_pd.get("normal_kills"), 0))
                normal_deaths = max(0, _TCPHandler._sproto_read_int(target_pd.get("normal_deaths"), 0))
                normal_assists = max(0, _TCPHandler._sproto_read_int(target_pd.get("normal_assists"), 0))
                normal_battles = max(0, _TCPHandler._sproto_read_int(target_pd.get("normal_battles"), 0))
                normal_wins = max(0, _TCPHandler._sproto_read_int(target_pd.get("normal_wins"), 0))
            else:
                normal_kills = max(0, all_kills - rank_kills) if all_kills > rank_kills else (all_kills // 2)
                normal_deaths = max(0, all_deaths - rank_deaths) if all_deaths > rank_deaths else (all_deaths // 2)
                normal_assists = max(0, all_assists - rank_assists) if all_assists > rank_assists else (all_assists // 2)
                normal_battles = max(0, all_battles - rank_battles) if all_battles > rank_battles else (all_battles // 2)
                normal_wins = max(0, all_wins - rank_wins) if all_wins > rank_wins else (all_wins // 2)
            normal_mvp = max(0, all_mvp - rank_mvp) if all_mvp > rank_mvp else (all_mvp // 2)
            normal_headshots = max(0, all_headshots - rank_headshots) if all_headshots > rank_headshots else (all_headshots // 2)
            normal_score = max(0, normal_kills * 100 + normal_assists * 50)

            # Build mode dictionaries
            all_dict = _make_combat_dict(all_battles, all_wins, all_kills, all_deaths, all_assists, all_mvp, all_headshots, all_score)
            rank_dict = _make_combat_dict(rank_battles, rank_wins, rank_kills, rank_deaths, rank_assists, rank_mvp, rank_headshots, rank_score)
            normal_dict = _make_combat_dict(normal_battles, normal_wins, normal_kills, normal_deaths, normal_assists, normal_mvp, normal_headshots, normal_score)

            all_struct = _TCPHandler._build_event_stat_struct("EVENT_TYPE_ALL", all_dict)
            if all_struct is not None: event_entries.append(all_struct)

            rank_struct = _TCPHandler._build_event_stat_struct("EVENT_TYPE_RANK", rank_dict)
            if rank_struct is not None: event_entries.append(rank_struct)

            normal_struct = _TCPHandler._build_event_stat_struct("EVENT_TYPE_NORMAL", normal_dict)
            if normal_struct is not None: event_entries.append(normal_struct)

            # 4. Season Stats: season1, season_1, season
            rank_score_val = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_score"), 1000))
            career_max_rank = max(rank_score_val, _TCPHandler._sproto_read_int(target_pd.get("career_max_rank"), rank_score_val))
            rank_protect_score = max(0, _TCPHandler._sproto_read_int(target_pd.get("rank_protect_score"), 0))
            season_id = max(1, _TCPHandler._sproto_read_int(target_pd.get("current_season_id"), 1))

            season_stats_dict = dict(rank_dict)
            season_stats_dict.update({
                "101": rank_score_val,
                "102": career_max_rank,
                "103": 0,
                "104": rank_protect_score,
                "105": 0,
                "106": 1 if rank_score_val >= 6000 else 0,
                "107": 0,
                "108": 0,
            })

            added_season_tags = set()
            for s_tag in (f"season{season_id}", f"season_{season_id}", "season", "season1"):
                if s_tag in added_season_tags:
                    continue
                added_season_tags.add(s_tag)
                s_struct = _TCPHandler._build_event_stat_struct(s_tag, season_stats_dict)
                if s_struct is not None:
                    event_entries.append(s_struct)

            return _TCPHandler._sproto_build_struct_list(event_entries)

        @staticmethod
        def _build_all_tasks_payload(pd: dict | None = None) -> bytes:
            _init_task_tables()
            target_pd = pd if isinstance(pd, dict) else _player_data
            claimed_tasks = set(target_pd.setdefault("claimed_tasks", []))
            player_level = max(1, _TCPHandler._sproto_read_int(target_pd.get("level"), 1))

            task_structs: list[bytes] = []

            # 1. Daily Tasks (4 slots)
            daily_tasks = target_pd.setdefault("daily_tasks", [200000, 200001, 200002, 200003])
            for slot_idx, tid in enumerate(daily_tasks[:4], 1):
                tid_int = int(tid)
                status = 3 if tid_int in claimed_tasks else 2  # Ready to claim / completed
                task_structs.append(_sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, tid_int),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, 1),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, slot_idx),
                    (_TAG_GAME_TASK_INFO_STATUS, status),
                ]))

            # 2. Growth Tasks (Level milestone rewards for levels 1..60)
            # LevelID: 215000..215059 (growth_type=1)
            # TaskID: 210000..210059 (level quests)
            for lvl in range(1, 61):
                # Level Reward (LevelID)
                level_task_id = 215000 + (lvl - 1)
                if level_task_id in claimed_tasks:
                    level_status = 3  # Claimed
                elif player_level >= lvl:
                    level_status = 2  # Completed / Claimable!
                else:
                    level_status = 1  # Locked / In progress

                task_structs.append(_sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, level_task_id),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, min(player_level, lvl)),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, 0),
                    (_TAG_GAME_TASK_INFO_STATUS, level_status),
                ]))

                # Quest Task (TaskID)
                quest_task_id = 210000 + (lvl - 1)
                if quest_task_id in claimed_tasks:
                    quest_status = 3  # Claimed
                elif player_level >= lvl:
                    quest_status = 2  # Completed / Claimable!
                else:
                    quest_status = 1  # Locked / In progress

                task_structs.append(_sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, quest_task_id),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, min(player_level, lvl)),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, 0),
                    (_TAG_GAME_TASK_INFO_STATUS, quest_status),
                ]))

            # 3. Activation Boxes (220000, 220001, 220002)
            for box_id in (220000, 220001, 220002):
                box_status = 3 if box_id in claimed_tasks else 2
                task_structs.append(_sproto_encode_fields([
                    (_TAG_GAME_TASK_INFO_ID, box_id),
                    (_TAG_GAME_TASK_INFO_COMPLETE_CNT, 100),
                    (_TAG_GAME_TASK_INFO_CUR_SLOT_IDX, 0),
                    (_TAG_GAME_TASK_INFO_STATUS, box_status),
                ]))

            return _TCPHandler._sproto_build_struct_list(task_structs)

        @staticmethod
        def _build_all_activities_payload(pd: dict | None = None) -> bytes:
            _init_task_tables()
            target_pd = pd if isinstance(pd, dict) else _player_data
            claimed_act_tasks = set(target_pd.setdefault("claimed_activity_tasks", []))

            activity_structs: list[bytes] = []

            # 1. Activity 100: Seven-Day Novice Sign-In
            seven_day_tasks: list[bytes] = []
            for d in range(1, 8):
                tid = 10000 + (d - 1)
                if tid in claimed_act_tasks:
                    state = 5  # AlreadyGet (Claimed)
                else:
                    state = 4  # Finished (Ready to claim!)
                seven_day_tasks.append(_sproto_encode_fields([
                    (_TAG_ACTIVITY_TASK_INFO_ID, tid),
                    (_TAG_ACTIVITY_TASK_INFO_STATE, state),
                    (_TAG_ACTIVITY_TASK_INFO_VALUE, 1),
                    (_TAG_ACTIVITY_TASK_INFO_MAX_VALUE, 1),
                ]))

            seven_day_vals: list[bytes] = [
                _sproto_encode_fields([
                    (_TAG_ACTIVITY_VALUE_KEY, "day"),
                    (_TAG_ACTIVITY_VALUE_VALUE1, 7),
                ])
            ]

            activity_structs.append(_sproto_encode_fields([
                (_TAG_ACTIVITY_INFO_ID, 100),
                (_TAG_ACTIVITY_INFO_IS_IN_TIME, True),
                (_TAG_ACTIVITY_INFO_TASKS, _TCPHandler._sproto_build_struct_list(seven_day_tasks)),
                (_TAG_ACTIVITY_INFO_VALUES, _TCPHandler._sproto_build_struct_list(seven_day_vals)),
            ]))

            # 2. Activity 200: Daily Event
            daily_act_tasks: list[bytes] = []
            for tid in (20000, 20001):
                if tid in claimed_act_tasks:
                    state = 5
                else:
                    state = 4
                daily_act_tasks.append(_sproto_encode_fields([
                    (_TAG_ACTIVITY_TASK_INFO_ID, tid),
                    (_TAG_ACTIVITY_TASK_INFO_STATE, state),
                    (_TAG_ACTIVITY_TASK_INFO_VALUE, 1),
                    (_TAG_ACTIVITY_TASK_INFO_MAX_VALUE, 1),
                ]))

            activity_structs.append(_sproto_encode_fields([
                (_TAG_ACTIVITY_INFO_ID, 200),
                (_TAG_ACTIVITY_INFO_IS_IN_TIME, True),
                (_TAG_ACTIVITY_INFO_TASKS, _TCPHandler._sproto_build_struct_list(daily_act_tasks)),
                (_TAG_ACTIVITY_INFO_VALUES, _TCPHandler._sproto_build_struct_list([])),
            ]))

            return _TCPHandler._sproto_build_struct_list(activity_structs)

        @staticmethod
        def _collect_unlocked_character_ids(camp: object = None) -> list[int]:
            camp_id = _TCPHandler._sproto_read_int(camp, 0)
            if camp_id not in (1, 2):
                camp_id = 0

            character_ids: set[int] = set()
            if camp_id in (1, 2):
                character_ids.add(_TCPHandler._default_character_for_camp(camp_id))
            else:
                character_ids.add(1)

            owned = _store_state.get("owned_bag_items")
            if isinstance(owned, dict):
                for bag_id_raw, count_raw in owned.items():
                    bag_id = _TCPHandler._sproto_read_int(bag_id_raw, 0)
                    count = max(0, _TCPHandler._sproto_read_int(count_raw, 0))
                    if bag_id <= 0 or count <= 0:
                        continue
                    character_id = _TCPHandler._sproto_read_int(_BAG_TO_CHARACTER_ID.get(bag_id), 0)
                    if character_id > 0:
                        character_ids.add(character_id)

            if _GRANT_ALL_CONTENT:
                for character_id_raw in _BAG_TO_CHARACTER_ID.values():
                    character_id = _TCPHandler._sproto_read_int(character_id_raw, 0)
                    if character_id > 0:
                        character_ids.add(character_id)

            out = sorted(cid for cid in character_ids if _TCPHandler._character_is_available(cid))
            if camp_id in (1, 2):
                out = [cid for cid in out if _TCPHandler._character_matches_camp(cid, camp_id)]
                if not out:
                    out = [_TCPHandler._default_character_for_camp(camp_id)]
            return out

        @staticmethod
        def _build_role_characters_list() -> bytes:
            character_ids = _TCPHandler._collect_unlocked_character_ids()

            char_entries: list[bytes] = []
            for character_id in character_ids:
                char_entries.append(_encode_client_character(
                    character_id,
                    unlock_time=0,
                    limit_time=0,
                ))

            return _TCPHandler._sproto_build_struct_list(char_entries)

        @staticmethod
        def _build_event_stat_push(event_type: str, stat_type: str, value: int) -> tuple[bytes, str]:
            push = _sproto_build_push_frame(117, [
                (0, str(event_type)),
                (1, str(stat_type)),
                (2, max(0, _TCPHandler._sproto_read_int(value, 0))),
            ])
            safe_event_type = str(event_type).replace(" ", "_")
            return (push, f"sproto-push-update-event-stat-{safe_event_type}-{stat_type}")

        @staticmethod
        def _append_box_event_pushes(
            extra_pushes: list[tuple[bytes, str]],
            box_or_chest_id: int,
            *,
            include_type_box: bool = False,
            include_box_count: bool = False,
        ) -> None:
            if _DISABLE_EVENT_STATS:
                return

            resolved_box_id = _TCPHandler._resolve_box_id(box_or_chest_id)
            if resolved_box_id <= 0:
                return

            stat_key = str(resolved_box_id)

            if include_type_box and _TCPHandler._is_known_box_id(resolved_box_id) and resolved_box_id not in _STORE_TYPE_9_BOX_IDS:
                type_box_counts = _TCPHandler._collect_type_box_counts()
                extra_pushes.append(_TCPHandler._build_event_stat_push(
                    _EVENT_TYPE_TYPE_BOX,
                    stat_key,
                    type_box_counts.get(stat_key, 0),
                ))

            if include_box_count and resolved_box_id not in _STORE_TYPE_9_BOX_IDS:
                box_count_stats = _TCPHandler._collect_box_open_counts()
                extra_pushes.append(_TCPHandler._build_event_stat_push(
                    _EVENT_TYPE_BOX_COUNT,
                    stat_key,
                    box_count_stats.get(stat_key, 0),
                ))

        @staticmethod
        def _default_item_price(item_id: int, store_type: int) -> int:
            parsed_item_id = _TCPHandler._sproto_read_int(item_id, 0)
            if parsed_item_id <= 0:
                return 0

            if store_type == _STORE_TYPE_BUNDLE:
                bundle_price = _TCPHandler._sproto_read_int(_BUNDLE_PRICE_DEFAULTS.get(parsed_item_id), 0)
                if bundle_price > 0:
                    return bundle_price

            meta = _STORE_ITEM_META_FROM_LUA.get(parsed_item_id, {})
            gem_price = _TCPHandler._sproto_read_int(meta.get("gem_price"), 0)
            coin_price = _TCPHandler._sproto_read_int(meta.get("coin_price"), 0)
            if gem_price > 0:
                return gem_price
            if coin_price > 0:
                return coin_price

            if store_type == _STORE_TYPE_CHARACTER and _TCPHandler._sproto_read_int(_BAG_TYPE_BY_ID.get(parsed_item_id), 0) == _BAG_TYPE_HERO:
                return _DEFAULT_STORE_DIAMOND_COST

            fallback_bundle_price = _TCPHandler._sproto_read_int(_BUNDLE_PRICE_DEFAULTS.get(parsed_item_id), 0)
            if fallback_bundle_price > 0:
                return fallback_bundle_price

            bag_exchange_price = _TCPHandler._sproto_read_int(_BAG_EXCHANGE_GOLD.get(parsed_item_id), 0)
            if bag_exchange_price > 0:
                return bag_exchange_price

            return 1

        @staticmethod
        def _build_item_price_entries_for_store_type(store_type: int) -> list[bytes]:
            entries: list[bytes] = []
            seen: set[int] = set()

            for item_id in _TCPHandler._default_store_items_for_type(store_type):
                parsed_item_id = _TCPHandler._sproto_read_int(item_id, 0)
                if parsed_item_id <= 0 or parsed_item_id in seen:
                    continue
                seen.add(parsed_item_id)
                price = _TCPHandler._default_item_price(parsed_item_id, store_type)
                if price <= 0:
                    continue
                entries.append(_sproto_encode_fields([
                    (0, parsed_item_id),
                    (1, price),
                ]))

                if store_type == _STORE_TYPE_CHARACTER:
                    character_id = _TCPHandler._sproto_read_int(_BAG_TO_CHARACTER_ID.get(parsed_item_id), 0)
                    if character_id > 0 and character_id not in seen:
                        seen.add(character_id)
                        entries.append(_sproto_encode_fields([
                            (0, character_id),
                            (1, price),
                        ]))

            if store_type == _STORE_TYPE_CHARACTER:
                # Some client builds still resolve agent cards through legacy ids.
                # Push compatibility prices so those cards never show blank cost.
                for fallback_item_id in _TYPE1_AGENT_PRICE_FALLBACK_IDS:
                    parsed_item_id = _TCPHandler._sproto_read_int(fallback_item_id, 0)
                    if parsed_item_id <= 0 or parsed_item_id in seen:
                        continue
                    seen.add(parsed_item_id)
                    price = _TCPHandler._default_item_price(parsed_item_id, store_type)
                    if price <= 0:
                        continue
                    entries.append(_sproto_encode_fields([
                        (0, parsed_item_id),
                        (1, price),
                    ]))

            if not entries and store_type == _STORE_TYPE_BUNDLE:
                for bundle_id, bundle_price in sorted(_BUNDLE_PRICE_DEFAULTS.items()):
                    parsed_bundle_id = _TCPHandler._sproto_read_int(bundle_id, 0)
                    parsed_bundle_price = _TCPHandler._sproto_read_int(bundle_price, 0)
                    if parsed_bundle_id <= 0 or parsed_bundle_price <= 0:
                        continue
                    if parsed_bundle_id in seen:
                        continue
                    seen.add(parsed_bundle_id)
                    entries.append(_sproto_encode_fields([
                        (0, parsed_bundle_id),
                        (1, parsed_bundle_price),
                    ]))

            return entries

        @staticmethod
        def _ensure_store_counter_dict(key: str) -> dict[str, int]:
            src = _store_state.get(key)
            if not isinstance(src, dict):
                src = {}
                _store_state[key] = src
            return src

        @staticmethod
        def _register_owned_store_item(item_id: int, amount: int = 1) -> None:
            bag_id = _TCPHandler._sproto_read_int(item_id, 0)
            delta = max(1, _TCPHandler._sproto_read_int(amount, 1))
            if bag_id <= 0:
                return

            # Supplies chest ids should not be persisted as owned bag items;
            # this can make store entries appear as pre-purchased.
            if _TCPHandler._sproto_read_int(_STORE_ITEM_TO_TYPE.get(bag_id), 0) == _STORE_TYPE_BOX:
                return

            # Ignore unknown ids to avoid polluting ownership with pure store-only entries.
            if bag_id not in _BAG_TYPE_BY_ID and bag_id not in _CHEST_ID_TO_BOX_ID and bag_id not in _KNOWN_BOX_IDS:
                return

            owned = _TCPHandler._ensure_store_counter_dict("owned_bag_items")
            cur = _TCPHandler._sproto_read_int(owned.get(str(bag_id)), 0)
            owned[str(bag_id)] = max(0, cur + delta)

        @staticmethod
        def _collect_owned_skin_counts() -> dict[int, int]:
            skin_counts: dict[int, int] = {}

            def _add_by_bag_id(bag_id_raw: object, count_raw: object) -> None:
                bag_id = _TCPHandler._sproto_read_int(bag_id_raw, 0)
                count = max(0, _TCPHandler._sproto_read_int(count_raw, 0))
                if bag_id <= 0 or count <= 0:
                    return
                skin_ids = _BAG_TO_SKIN_IDS.get(bag_id)
                if not isinstance(skin_ids, list):
                    return
                for skin_id_raw in skin_ids:
                    skin_id = _TCPHandler._sproto_read_int(skin_id_raw, 0)
                    if skin_id <= 0:
                        continue
                    prev = skin_counts.get(skin_id, 0)
                    if count > prev:
                        skin_counts[skin_id] = count

            owned = _store_state.get("owned_bag_items")
            if isinstance(owned, dict):
                for bag_id, count in owned.items():
                    _add_by_bag_id(bag_id, count)

            return skin_counts

        @staticmethod
        def _build_skin_update_push(skin_counts: dict[int, int]) -> tuple[bytes, str] | None:
            if not isinstance(skin_counts, dict) or not skin_counts:
                return None

            skin_entries: list[bytes] = []
            for skin_id in sorted(skin_counts.keys())[:200]:
                sid = _TCPHandler._sproto_read_int(skin_id, 0)
                num = max(0, _TCPHandler._sproto_read_int(skin_counts.get(skin_id), 0))
                if sid <= 0:
                    continue
                skin_entries.append(_sproto_encode_fields([
                    (0, sid),
                    (1, 0),
                    (2, False),
                    (3, num),
                ]))

            if not skin_entries:
                return None

            skin_list = _TCPHandler._sproto_build_struct_list(skin_entries)
            push = _sproto_build_push_frame(154, [
                (0, skin_list),
                (1, len(skin_entries)),
            ])
            return (push, "sproto-push-skin-update-notify")

        @staticmethod
        def _resolve_box_id(box_or_chest_id: int) -> int:
            parsed_id = _TCPHandler._sproto_read_int(box_or_chest_id, 0)
            if parsed_id <= 0:
                return parsed_id
            mapped_box_id = _TCPHandler._sproto_read_int(_CHEST_ID_TO_BOX_ID.get(parsed_id), parsed_id)
            if mapped_box_id > 0:
                return mapped_box_id
            return parsed_id

        @staticmethod
        def _select_box_reward_items(box_id: int, count: int, *, track_open_counter: bool = True) -> list[int]:
            picks = max(1, _TCPHandler._sproto_read_int(count, 1))
            resolved_box_id = _TCPHandler._resolve_box_id(box_id)

            if track_open_counter and resolved_box_id in _STORE_TYPE_9_BOX_IDS:
                # Supply chest progress should not mutate BOX_COUNT state.
                track_open_counter = False

            reward_pool: list[int] = []
            seen: set[int] = set()

            for set_id in _BOX_ID_TO_COLLECTION_SET_IDS.get(resolved_box_id, []):
                for collection_id in _BOX_COLLECTION_SET_TO_COLLECTION_IDS.get(set_id, []):
                    item_id = _TCPHandler._sproto_read_int(
                        _BOX_COLLECTION_ID_TO_ITEM_ID.get(collection_id),
                        0,
                    )
                    if item_id <= 0 or item_id in seen:
                        continue
                    seen.add(item_id)
                    reward_pool.append(item_id)

            reward_pool.sort()

            if not reward_pool:
                display_bag_id = _TCPHandler._sproto_read_int(_BOX_ID_TO_DISPLAY_BAG_ID.get(resolved_box_id), 0)
                if display_bag_id > 0:
                    reward_pool.append(display_bag_id)

            if not reward_pool:
                # Never report the box itself as reward; fallback to a valid bag item.
                return [900410010 for _ in range(picks)]

            cur = 0
            counter_key = str(resolved_box_id if resolved_box_id > 0 else box_id)
            counters: dict[str, int] | None = None
            if track_open_counter:
                counters = _TCPHandler._ensure_store_counter_dict("box_open_counters")
                cur = max(0, _TCPHandler._sproto_read_int(counters.get(counter_key), 0))

            out: list[int] = []
            for idx in range(picks):
                out.append(reward_pool[(cur + idx) % len(reward_pool)])
            if track_open_counter and isinstance(counters, dict):
                counters[counter_key] = cur + picks
            return out

        def _build_money_pushes(self, pd: dict | None = None) -> list[tuple[bytes, str]]:
            # Some client builds don't initialize wallet from role.money reliably.
            # Redundant update_money pushes force a consistent Gold/Diamond sync.
            base = pd if isinstance(pd, dict) else _player_data
            gold_val = max(0, _TCPHandler._sproto_read_int(base.get("gold"), _DEFAULT_GOLD))
            diamond_val = max(0, _TCPHandler._sproto_read_int(base.get("diamond"), _DEFAULT_DIAMOND))
            names = [
                ("Gold", gold_val),
                ("Diamond", diamond_val),
                ("gold", gold_val),
                ("diamond", diamond_val),
                ("Coin", gold_val),
                ("coin", gold_val),
                ("1", diamond_val),
                ("2", gold_val),
            ]
            pushes: list[tuple[bytes, str]] = []
            for money_name, money_val in names:
                push = _sproto_build_push_frame(113, [(0, money_name), (1, money_val)])
                pushes.append((push, f"sproto-push-update-money-{money_name}"))
            return pushes

        @staticmethod
        def _default_discount_item(item_id: int, *, discount: int, bought: bool = False, item_id_type: int = 1) -> dict:
            if item_id_type not in (0, 1):
                item_id_type = 1
            return {
                "item_id": max(1, item_id),
                "item_id_type": item_id_type,
                "bought": bool(bought),
                "discount": max(1, min(99, discount)),
            }

        @staticmethod
        def _normalize_discount_item(item: object, fallback: dict) -> dict:
            if not isinstance(item, dict):
                item = {}
            item_id = _TCPHandler._sproto_read_int(item.get("item_id"), _TCPHandler._sproto_read_int(fallback.get("item_id"), 20200310))
            item_id_type = _TCPHandler._sproto_read_int(item.get("item_id_type"), _TCPHandler._sproto_read_int(fallback.get("item_id_type"), 1))
            if item_id_type not in (0, 1):
                item_id_type = 1
            if item_id_type == 1:
                mapped = _DISCOUNT_STORE_TO_STORE_ID.get(item_id)
                if mapped is not None and _TCPHandler._sproto_read_int(fallback.get("item_id_type"), 1) == 0:
                    item_id = mapped
                    item_id_type = 0
            bought = _TCPHandler._sproto_read_int(item.get("bought"), 1 if bool(fallback.get("bought")) else 0)
            discount = _TCPHandler._sproto_read_int(item.get("discount"), _TCPHandler._sproto_read_int(fallback.get("discount"), 80))
            return {
                "item_id": max(1, item_id),
                "item_id_type": item_id_type,
                "bought": bool(bought),
                "discount": max(1, min(99, discount)),
            }

        @staticmethod
        def _build_choose_character_response_body(
            gs: dict,
            pd: dict,
            *,
            preferred_character_id: object = None,
            force_loadout: bool = False,
        ) -> tuple[list[tuple[int, object]], int]:
            selected_char_id = _TCPHandler._ensure_character_selection_for_camp(
                gs,
                preferred_character_id=preferred_character_id,
                force_loadout=force_loadout,
            )
            primary_weapon = gs.get("primary_weapon")
            if not isinstance(primary_weapon, dict):
                primary_weapon = {}
                gs["primary_weapon"] = primary_weapon
            primary_weapon_id = _TCPHandler._sproto_read_int(
                primary_weapon.get("id"),
                _TCPHandler._character_default_loadout(selected_char_id)[0],
            )
            selected_char_skins = _TCPHandler._get_selected_char_skins(selected_char_id)
            if not selected_char_skins:
                selected_char_skins = _TCPHandler._default_character_skin_ids(selected_char_id)
            selected_char_skins = _TCPHandler._normalize_character_skin_ids(
                selected_char_id,
                selected_char_skins,
            )
            body: list[tuple[int, object]] = [
                (_TAG_RSP_CHOOSE_CHARACTER_UID, pd["uid"]),
                (_TAG_RSP_CHOOSE_CHARACTER_CHARACTER_ID, selected_char_id),
                (_TAG_RSP_CHOOSE_CHARACTER_PRIMARY_WEAPON_ID, primary_weapon_id),
                (_TAG_RSP_CHOOSE_CHARACTER_SKIN, _TCPHandler._sproto_build_integer_list(selected_char_skins[:16])),
            ]
            return body, selected_char_id

        @staticmethod
        def _append_prebattle_info_push(
            extra_pushes: list[tuple[bytes, str]],
            gs: dict,
            pd: dict,
            *,
            tag: str,
            ensure_choose_character_push: bool = True,
        ) -> None:
            target_uid = _safe_int(pd.get("uid"), 0)
            target_camp = max(1, _safe_int(_room_state.get("players", {}).get(str(target_uid), {}).get("camp"), gs.get("camp", 1)))
            local_gs = dict(gs)
            local_gs["camp"] = target_camp
            preferred_cid = 0
            if target_uid > 0 and str(target_uid) in _room_state.get("players", {}):
                preferred_cid = _safe_int(_room_state["players"][str(target_uid)].get("character_id"), 0)
            if preferred_cid <= 0:
                preferred_cid = 1 if target_camp == 1 else 101
            local_gs["character_id"] = preferred_cid

            if (
                ensure_choose_character_push
                and (
                    not bool(local_gs.get("_prebattle_choose_character_pushed", False))
                    or not bool(local_gs.get("prebattle_room_started", False))
                )
            ):
                choose_body, selected_char_id = _TCPHandler._build_choose_character_response_body(
                    local_gs,
                    pd,
                    preferred_character_id=preferred_cid,
                )
                extra_pushes.append((
                    _sproto_build_push_frame(1021, choose_body),
                    "sproto-push-choose-character-auto",
                ))
                local_gs["_prebattle_choose_character_pushed"] = True
                if str(target_uid) in _room_state.get("players", {}):
                    _room_state["players"][str(target_uid)]["character_id"] = selected_char_id
                _append_utf8_log(
                    "[TCP] prebattle auto choose_character push "
                    f"uid={target_uid} char_id={selected_char_id} camp={target_camp} "
                    f"stage={_TCPHandler._normalize_prebattle_stage(local_gs.get('prebattle_stage'), 1)}"
                )

            extra_pushes.append((
                _sproto_build_push_frame(1044, _TCPHandler._build_prebattle_info_body(local_gs, pd)),
                tag,
            ))

        @staticmethod
        def _build_prebattle_info_body(gs: dict, pd: dict) -> list[tuple[int, object]]:
            stage = _TCPHandler._normalize_prebattle_stage(gs.get("prebattle_stage"), 1)
            gs["prebattle_stage"] = stage
            seed_default_loadout = stage <= 1 and not bool(gs.get("_prebattle_loadout_seeded", False))
            target_uid = _safe_int(pd.get("uid"), 0)
            target_camp = max(1, _safe_int(_room_state.get("players", {}).get(str(target_uid), {}).get("camp"), gs.get("camp", 1)))
            gs["camp"] = target_camp
            preferred_cid = gs.get("character_id")
            if target_uid > 0 and str(target_uid) in _room_state.get("players", {}):
                stored_cid = _safe_int(_room_state["players"][str(target_uid)].get("character_id"), 0)
                if stored_cid > 0:
                    preferred_cid = stored_cid
            if not preferred_cid:
                preferred_cid = 1 if target_camp == 1 else 101

            character_id = _TCPHandler._ensure_character_selection_for_camp(
                gs,
                preferred_character_id=preferred_cid,
                force_loadout=seed_default_loadout,
            )
            if str(target_uid) in _room_state.get("players", {}):
                _room_state["players"][str(target_uid)]["character_id"] = character_id
            if seed_default_loadout:
                gs["_prebattle_loadout_seeded"] = True
                _append_utf8_log(
                    "[TCP] prebattle loadout seeded "
                    f"uid={target_uid} char_id={character_id} camp={target_camp} stage={stage}"
                )
            if str(target_uid) in _room_state.get("players", {}):
                t_entry = _room_state["players"][str(target_uid)]
                primary_weapon = t_entry.get("primary_weapon") or gs.get("primary_weapon")
                secondary_weapon = t_entry.get("secondary_weapon") or gs.get("secondary_weapon")
                main_skill_id_val = t_entry.get("main_skill_id") or gs.get("main_skill_id")
                sub_skill_id_val = t_entry.get("sub_skill_id") or gs.get("sub_skill_id")
            else:
                primary_weapon = gs.get("primary_weapon")
                secondary_weapon = gs.get("secondary_weapon")
                main_skill_id_val = gs.get("main_skill_id")
                sub_skill_id_val = gs.get("sub_skill_id")

            if not isinstance(primary_weapon, dict):
                primary_weapon = {}
                gs["primary_weapon"] = primary_weapon
            if not isinstance(secondary_weapon, dict):
                secondary_weapon = {}
                gs["secondary_weapon"] = secondary_weapon
            primary_attachments = _TCPHandler._normalize_attachment_list(primary_weapon.get("attachments"))
            secondary_attachments = _TCPHandler._normalize_attachment_list(secondary_weapon.get("attachments"))
            primary_weapon["attachments"] = primary_attachments
            secondary_weapon["attachments"] = secondary_attachments

            # Build player's PreBattleUserData.
            room_players = _room_state.get("players")
            if isinstance(room_players, dict) and len(room_players) > 1:
                user_data_entries: list[bytes] = []
                for p_uid_s, p_entry in room_players.items():
                    p_uid = _safe_int(p_uid_s, 0)
                    if p_uid <= 0:
                        continue
                    p_camp = max(1, _safe_int(p_entry.get("camp"), 1))
                    if p_camp == target_camp:
                        p_char_id = _safe_int(p_entry.get("character_id"), character_id if p_uid == target_uid else (1 if p_camp == 1 else 101))
                        p_stage = stage
                        user_data_entries.append(_encode_game_prebattle_user_data(
                            p_uid,
                            p_char_id,
                            stage=p_stage,
                        ))
                if not user_data_entries:
                    user_data_entries.append(_encode_game_prebattle_user_data(
                        target_uid,
                        character_id,
                        stage=stage,
                    ))
                user_list = _TCPHandler._sproto_build_struct_list(user_data_entries)
            else:
                user_data = _encode_game_prebattle_user_data(
                    pd["uid"],
                    character_id,
                    stage=stage,
                )
                user_list = _TCPHandler._sproto_build_struct_list([user_data])

            # Build ChooseWeaponData with full option lists for current character.
            primary_options, secondary_options, main_options, sub_options = _TCPHandler._character_loadout_options(
                character_id
            )

            cur_primary = _TCPHandler._sproto_read_int(primary_weapon.get("id"), primary_options[0])
            if cur_primary not in primary_options:
                cur_primary = primary_options[0]
            primary_weapon["id"] = cur_primary

            cur_secondary = _TCPHandler._sproto_read_int(secondary_weapon.get("id"), secondary_options[0])
            if cur_secondary not in secondary_options:
                cur_secondary = secondary_options[0]
            secondary_weapon["id"] = cur_secondary

            main_skill_id = _TCPHandler._sproto_read_int(main_skill_id_val, main_options[0])
            if main_skill_id not in main_options:
                main_skill_id = main_options[0]
            gs["main_skill_id"] = main_skill_id

            sub_skill_id = _TCPHandler._sproto_read_int(sub_skill_id_val, sub_options[0])
            if sub_skill_id not in sub_options:
                sub_skill_id = sub_options[0]
            gs["sub_skill_id"] = sub_skill_id

            pri_structs: list[bytes] = []
            for weapon_id in primary_options:
                attachments = primary_attachments if weapon_id == cur_primary else []
                pri_structs.append(_encode_game_weapon_info(weapon_id, attachments))
            pri_list = _TCPHandler._sproto_build_struct_list(pri_structs)

            sec_structs: list[bytes] = []
            for weapon_id in secondary_options:
                attachments = secondary_attachments if weapon_id == cur_secondary else []
                sec_structs.append(_encode_game_weapon_info(weapon_id, attachments))
            sec_list = _TCPHandler._sproto_build_struct_list(sec_structs)

            main_list = _TCPHandler._sproto_build_integer_list(main_options)
            sub_list = _TCPHandler._sproto_build_integer_list(sub_options)
            choose_data = _encode_game_choose_weapon_data(
                cur_primary,
                pri_list,
                cur_secondary,
                sec_list,
                main_skill_id,
                main_list,
                sub_skill_id,
                sub_list,
            )
            return [
                (_TAG_RSP_PRE_BATTLE_INFO_MY_TEAM, user_list),
                (_TAG_RSP_PRE_BATTLE_INFO_CHOOSE_WEAPON, choose_data),
            ]

        @staticmethod
        def _build_room_start_push(gs: dict, target_pd: dict | None = None, target_camp: int | None = None) -> bytes:
            """Build RspRoomStart (1014) push to enter prebattle multi-phase flow."""
            pd = target_pd if isinstance(target_pd, dict) else _player_data
            round_id = max(1, _TCPHandler._sproto_read_int(gs.get("round"), 1))
            is_custom_room = bool(_room_state.get("room_id")) or bool(_TCPHandler._room_is_active())
            default_mode = 4 if is_custom_room else 3
            mode_id = _TCPHandler._sproto_read_int(gs.get("mode_id"), default_mode)
            if mode_id <= 0 or (is_custom_room and mode_id == 3):
                mode_id = 4 if is_custom_room else 3
                gs["mode_id"] = mode_id
            if is_custom_room:
                combat_type = 4  # CombatType.room_mode
            else:
                combat_type = 6 if mode_id == 3 else 4
            wait_time = max(0, _TCPHandler._sproto_read_int(gs.get("wait_time"), 300))
            map_id = max(1, _TCPHandler._sproto_read_int(gs.get("map_id"), 1))
            my_bid = _TCPHandler._sproto_read_int(gs.get("player_bid"), 1)

            target_uid = _safe_int(pd.get("uid"), 0)
            if target_camp is None:
                if target_uid > 0 and _room_state.get("players", {}).get(str(target_uid)):
                    camp = max(1, _safe_int(_room_state["players"][str(target_uid)].get("camp"), 1))
                else:
                    camp = max(1, _TCPHandler._sproto_read_int(gs.get("camp"), 1))
            else:
                camp = max(1, int(target_camp))

            my_team_id = 2 if camp == 2 else 1
            other_team_id = 2 if my_team_id == 1 else 1
            spawn_region_id = _TCPHandler._resolve_spawn_region(gs, gs.get("spawn_region_id"))
            region_id = _TCPHandler._resolve_spawn_region(gs, gs.get("region_id", spawn_region_id))
            if region_id != spawn_region_id:
                region_id = spawn_region_id
            local_gs = dict(gs)
            local_gs["camp"] = camp
            preferred_cid = None
            if target_uid > 0 and str(target_uid) in _room_state.get("players", {}):
                stored_cid = _safe_int(_room_state["players"][str(target_uid)].get("character_id"), 0)
                if stored_cid > 0:
                    preferred_cid = stored_cid
            selected_character_id = _TCPHandler._ensure_character_selection_for_camp(
                local_gs,
                preferred_character_id=preferred_cid,
            )
            if target_uid > 0 and str(target_uid) in _room_state.get("players", {}):
                _room_state["players"][str(target_uid)]["character_id"] = selected_character_id

            room_players = _room_state.get("players")
            if isinstance(room_players, dict) and len(room_players) > 1:
                sorted_room_players = sorted(
                    [entry for entry in room_players.values() if isinstance(entry, dict)],
                    key=lambda e: (
                        int(e.get("camp", 1) or 1),
                        int(e.get("index", 9999) or 9999),
                        int(e.get("uid", 0) or 0),
                    ),
                )
                my_team_entries: list[bytes] = []
                other_team_entries: list[bytes] = []
                for bid_counter, p_entry in enumerate(sorted_room_players, 1):
                    p_uid = _safe_int(p_entry.get("uid"), 0)
                    if p_uid <= 0:
                        continue
                    p_camp = max(1, _safe_int(p_entry.get("camp"), 1))
                    p_name = _sanitize_display_name(p_entry.get("name"), f"Player{p_uid}")
                    p_struct = _encode_game_character_choose_player(
                        p_uid,
                        bid_counter,
                        p_name,
                        region_id,
                    )
                    if p_camp == camp:
                        my_team_entries.append(p_struct)
                    else:
                        other_team_entries.append(p_struct)
                my_team = _encode_game_battle_team_info(my_team_id, camp, 0, _TCPHandler._sproto_build_struct_list(my_team_entries))
                other_team = _encode_game_battle_team_info(other_team_id, 2 if camp == 1 else 1, 0, _TCPHandler._sproto_build_struct_list(other_team_entries))
            else:
                player = _encode_game_character_choose_player(
                    pd["uid"],
                    my_bid,
                    _sanitize_display_name(pd.get("name"), "Local"),
                    region_id,
                )
                player_list = _TCPHandler._sproto_build_struct_list([player])
                my_team = _encode_game_battle_team_info(my_team_id, camp, 0, player_list)
                other_team = _encode_game_battle_team_info(other_team_id, 2 if camp == 1 else 1, 0, b"")

            unlocked_ids = _TCPHandler._collect_unlocked_character_ids(camp=camp)
            unlocked_ids = [
                cid for cid in unlocked_ids
                if _TCPHandler._character_is_available(cid) and _TCPHandler._character_matches_camp(cid, camp)
            ]
            if selected_character_id > 0 and _TCPHandler._character_matches_camp(selected_character_id, camp):
                if selected_character_id in unlocked_ids:
                    unlocked_ids.remove(selected_character_id)
                unlocked_ids = [selected_character_id] + unlocked_ids
            deduped_ids: list[int] = []
            seen: set[int] = set()
            for character_id in unlocked_ids:
                cid = _TCPHandler._sproto_read_int(character_id, 0)
                if cid <= 0 or cid in seen:
                    continue
                if not _TCPHandler._character_is_available(cid):
                    continue
                if not _TCPHandler._character_matches_camp(cid, camp):
                    continue
                seen.add(cid)
                deduped_ids.append(cid)
                if len(deduped_ids) >= 64:
                    break
            if not deduped_ids:
                deduped_ids = [_TCPHandler._default_character_for_camp(camp)]
            character_entries = [
                _encode_select_character_info(
                    cid,
                    unlock_time=0,
                    limit_time=0,
                )
                for cid in deduped_ids
            ]
            characters_blob = _TCPHandler._sproto_build_struct_list(character_entries)

            body = [
                (_TAG_RSP_ROOM_START_ROUND, round_id),
                (_TAG_RSP_ROOM_START_COMBAT_TYPE, combat_type),
                (_TAG_RSP_ROOM_START_MAP_ID, map_id),
                (_TAG_RSP_ROOM_START_MODE_ID, mode_id),
                (_TAG_RSP_ROOM_START_WAIT_TIME, wait_time),
                (_TAG_RSP_ROOM_START_MY_TEAM, my_team),
                (_TAG_RSP_ROOM_START_OTHER_TEAM, other_team),
                (_TAG_RSP_ROOM_START_MY_CHARACTERS, characters_blob),
            ]
            return _sproto_build_push_frame(1014, body)

        @staticmethod
        def _resolve_battle_host(client_ip: str | None = None, peer_ip: str | None = None) -> str:
            if client_ip and client_ip not in ("0.0.0.0", "::", "192.168.1.9"):
                return client_ip

            target_peer = peer_ip or getattr(_TCPHandler, "_last_client_peer_ip", None)
            if target_peer:
                if target_peer in ("127.0.0.1", "localhost", "::1"):
                    return "127.0.0.1"
                try:
                    s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
                    s.settimeout(0.2)
                    s.connect((target_peer, 12000))
                    local_ip = s.getsockname()[0]
                    s.close()
                    if local_ip and local_ip not in ("0.0.0.0", "127.0.0.1"):
                        return local_ip
                except Exception:
                    pass

            env_host = (os.environ.get("BATTLE_PUBLIC_HOST") or os.environ.get("GAME_HOST") or "").strip()
            if env_host and env_host not in ("0.0.0.0", "::", "192.168.1.9", "127.0.0.1"):
                return env_host

            bound_host = getattr(_TCPHandler, "_current_bound_host", None)
            if bound_host and bound_host not in ("0.0.0.0", "::", "192.168.1.9", "127.0.0.1"):
                return bound_host

            try:
                s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
                s.settimeout(0.2)
                s.connect(("8.8.8.8", 80))
                local_ip = s.getsockname()[0]
                s.close()
                if local_ip and local_ip not in ("0.0.0.0", "127.0.0.1"):
                    return local_ip
            except Exception:
                pass

            return "127.0.0.1"

        @staticmethod
        def _build_battle_info_push(
            gs: dict,
            target_pd: dict | None = None,
            target_camp: int | None = None,
            client_ip: str | None = None,
        ) -> bytes:
            """Build RspBattleInfo (1029) push frame with current game state."""
            client_ip = _TCPHandler._resolve_battle_host(client_ip)
            pd = target_pd if isinstance(target_pd, dict) else _player_data
            my_bid = _TCPHandler._sproto_read_int(gs.get("player_bid"), 1)
            target_uid = _safe_int(pd.get("uid"), 0)
            if target_camp is None:
                if target_uid > 0 and _room_state.get("players", {}).get(str(target_uid)):
                    camp = max(1, _safe_int(_room_state["players"][str(target_uid)].get("camp"), 1))
                else:
                    camp = max(1, _TCPHandler._sproto_read_int(gs.get("camp"), 1))
            else:
                camp = max(1, int(target_camp))

            my_team_id = 2 if camp == 2 else 1
            is_custom_room = bool(_room_state.get("room_id")) or bool(_TCPHandler._room_is_active())
            mode_id = _TCPHandler._sproto_read_int(gs.get("mode_id"), 4 if is_custom_room else 3)
            if is_custom_room and mode_id in (0, 3):
                mode_id = 4
                gs["mode_id"] = 4
            elif mode_id <= 0:
                mode_id = 4 if is_custom_room else 3
                gs["mode_id"] = mode_id
            other_team_id = 2 if my_team_id == 1 else 1
            spawn_region_id = _TCPHandler._resolve_spawn_region(gs, gs.get("spawn_region_id"))
            region_id = _TCPHandler._resolve_spawn_region(gs, gs.get("region_id", spawn_region_id))
            if region_id != spawn_region_id:
                region_id = spawn_region_id

            room_players = _room_state.get("players")
            if isinstance(room_players, dict) and len(room_players) > 1:
                sorted_room_players = sorted(
                    [entry for entry in room_players.values() if isinstance(entry, dict)],
                    key=lambda e: (
                        int(e.get("camp", 1) or 1),
                        int(e.get("index", 9999) or 9999),
                        int(e.get("uid", 0) or 0),
                    ),
                )
                my_team_entries: list[bytes] = []
                other_team_entries: list[bytes] = []
                for bid_counter, p_entry in enumerate(sorted_room_players, 1):
                    p_uid = _safe_int(p_entry.get("uid"), 0)
                    if p_uid <= 0:
                        continue
                    p_camp = max(1, _safe_int(p_entry.get("camp"), 1))
                    p_name = _sanitize_display_name(p_entry.get("name"), f"Player{p_uid}")
                    p_struct = _encode_game_character_choose_player(
                        p_uid,
                        bid_counter,
                        p_name,
                        region_id,
                    )
                    if p_camp == camp:
                        my_team_entries.append(p_struct)
                    else:
                        other_team_entries.append(p_struct)
                my_team = _encode_game_battle_team_info(my_team_id, camp, 0, _TCPHandler._sproto_build_struct_list(my_team_entries))
                other_team = _encode_game_battle_team_info(other_team_id, 2 if camp == 1 else 1, 0, _TCPHandler._sproto_build_struct_list(other_team_entries))
            else:
                player = _encode_game_character_choose_player(
                    pd["uid"],
                    my_bid,
                    _sanitize_display_name(pd.get("name"), "Local"),
                    region_id,
                )
                player_list = _TCPHandler._sproto_build_struct_list([player])
                my_team = _encode_game_battle_team_info(my_team_id, camp, 0, player_list)
                other_team = _encode_game_battle_team_info(other_team_id, 2 if camp == 1 else 1, 0, b"")

            battle_body = [
                (_TAG_RSP_BATTLE_INFO_MAP_ID, gs["map_id"]),
                (_TAG_RSP_BATTLE_INFO_MODE_ID, gs["mode_id"]),
                (_TAG_RSP_BATTLE_INFO_BATTLE_ID, gs["battle_id"]),
                (_TAG_RSP_BATTLE_INFO_IP_PORT, f"{client_ip}:{BATTLE_PORT}"),
                (_TAG_RSP_BATTLE_INFO_TOKEN, "test_token_" + str(gs["battle_id"])),
                (_TAG_RSP_BATTLE_INFO_GUIDE_ID, gs.get("guide_id", 0)),
                (_TAG_RSP_BATTLE_INFO_MY_TEAM, my_team),
                (_TAG_RSP_BATTLE_INFO_OTHER_TEAM, other_team),
            ]
            return _sproto_build_push_frame(1029, battle_body)

        @staticmethod
        def _build_players_result_push(gs: dict, target_pd: dict | None = None) -> bytes:
            """Build RspPlayersResult (1031) push with player result list."""
            room_players = _room_state.get("players")
            result_entries: list[bytes] = []
            ts = int(time.time())

            if _TCPHandler._room_is_active() and isinstance(room_players, dict) and len(room_players) > 0:
                for p_uid_s, p_entry in room_players.items():
                    p_uid = _safe_int(p_entry.get("uid"), 0)
                    if p_uid <= 0:
                        continue
                    p_pd = _online_ensure_profile(p_uid)
                    p_score = 100
                    p_kills = 0
                    p_assists = 0
                    p_dead = 0
                    result_entries.append(_encode_game_battle_player_result(
                        uid=p_uid,
                        score=p_score,
                        kill=p_kills,
                        assist=p_assists,
                        dead=p_dead,
                        is_no_hurt=True,
                        time_stamp=ts,
                        voicestate=0,
                        rank_score=_safe_int(p_pd.get("rank_score"), 1000),
                    ))
            else:
                pd = target_pd if isinstance(target_pd, dict) else _player_data
                uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
                rank_score = _TCPHandler._sproto_read_int(gs.get("rank_score"), 0)
                kills = max(0, _TCPHandler._sproto_read_int(gs.get("battle_kill"), 0))
                assists = max(0, _TCPHandler._sproto_read_int(gs.get("battle_assist"), 0))
                dead = max(0, _TCPHandler._sproto_read_int(gs.get("battle_dead"), 0))
                score = max(0, _TCPHandler._sproto_read_int(gs.get("battle_score"), kills * 100 + assists * 50))
                result_entries.append(_encode_game_battle_player_result(
                    uid=uid,
                    score=score,
                    kill=kills,
                    assist=assists,
                    dead=dead,
                    is_no_hurt=(dead == 0),
                    time_stamp=ts,
                    voicestate=0,
                    rank_score=rank_score,
                ))

            players_blob = _TCPHandler._sproto_build_struct_list(result_entries)
            return _sproto_build_push_frame(1031, [
                (_TAG_RSP_PLAYERS_RESULT_RESULTS, players_blob),
            ])

        @staticmethod
        def _build_battle_final_result_push(gs: dict, target_pd: dict | None = None) -> bytes:
            """Build RspBattleFinalResult (1032) push with common/rank/box payloads."""
            pd = target_pd if isinstance(target_pd, dict) else _player_data
            uid = _TCPHandler._sproto_read_int(pd.get("uid"), 1000001)
            target_camp = max(1, _safe_int(_room_state.get("players", {}).get(str(uid), {}).get("camp"), gs.get("camp", 1)))
            win_camp = _TCPHandler._sproto_read_int(gs.get("win_camp"), 1)
            is_win = 1 if target_camp == win_camp else 0
            old_rank = _TCPHandler._sproto_read_int(gs.get("rank_score"), 0)
            rank_delta = _TCPHandler._sproto_read_int(gs.get("rank_delta"), 0)
            new_rank = old_rank + rank_delta

            kills = max(0, _TCPHandler._sproto_read_int(gs.get("battle_kill"), 0))
            assists = max(0, _TCPHandler._sproto_read_int(gs.get("battle_assist"), 0))
            dead = max(0, _TCPHandler._sproto_read_int(gs.get("battle_dead"), 0))
            score = max(0, _TCPHandler._sproto_read_int(gs.get("battle_score"), kills * 100 + assists * 50))
            rank_score = max(0, _TCPHandler._sproto_read_int(gs.get("rank_score"), old_rank))
            ts = int(time.time())
            player_result = _encode_game_battle_player_result(
                uid=uid,
                score=score,
                kill=kills,
                assist=assists,
                dead=dead,
                is_no_hurt=(dead == 0),
                time_stamp=ts,
                voicestate=0,
                rank_score=rank_score,
            )

            winners_rank: list[int] = [uid] if is_win else []
            common_result = _encode_game_common_battle_result(
                my_win_times=1 if is_win else 0,
                enemy_win_times=0 if is_win else 1,
                winners_rank=winners_rank,
                players_result=[player_result],
                combat_type=_TCPHandler._sproto_read_int(gs.get("mode_id"), 0),
                guide_id=_TCPHandler._sproto_read_int(gs.get("guide_id"), 0),
                add_exp=max(0, _TCPHandler._sproto_read_int(gs.get("battle_add_exp"), 0)),
                add_gold=max(0, _TCPHandler._sproto_read_int(gs.get("battle_add_gold"), 0)),
            )
            rank_result = _encode_game_rank_player_result(
                old_rank,
                new_rank,
                0,
                0,
                0,
                0,
                is_win,
            )
            box_result = _encode_game_box_result(0, 0, 0)
            return _sproto_build_push_frame(1032, [
                (_TAG_RSP_BATTLE_FINAL_RESULT_COMMON_RESULT, common_result),
                (_TAG_RSP_BATTLE_FINAL_RESULT_RANK_RESULT, rank_result),
                (_TAG_RSP_BATTLE_FINAL_RESULT_BOX_RESULT, box_result),
            ])

        @staticmethod
        def _build_leave_result_pushes(gs: dict, target_pd: dict | None = None) -> list[tuple[bytes, str]]:
            players_result = _TCPHandler._build_players_result_push(gs, target_pd=target_pd)
            battle_final_result = _TCPHandler._build_battle_final_result_push(gs, target_pd=target_pd)
            battle_result = _TCPHandler._build_battle_result_push(gs)
            return [
                (players_result, "sproto-push-players-result"),
                (battle_final_result, "sproto-push-battle-final-result"),
                (battle_result, "sproto-push-battle-result"),
            ]

        @staticmethod
        def _build_battle_result_push(gs: dict) -> bytes:
            """Build RspBattleResult (1102) push frame with minimal source-shaped payload."""
            old_rank = _TCPHandler._sproto_read_int(gs.get("rank_score"), 0)
            rank_delta = _TCPHandler._sproto_read_int(gs.get("rank_delta"), 0)
            new_rank = old_rank + rank_delta
            is_win = 1 if _TCPHandler._sproto_read_int(gs.get("camp"), 1) == 1 else 0

            rank_result = _encode_game_rank_player_result(
                old_rank,
                new_rank,
                0,
                0,
                0,
                0,
                is_win,
            )
            box_result = _encode_game_box_result(0, 0, 0)
            battle_result_body = [
                (_TAG_RSP_BATTLE_RESULT_RANK_RESULT, rank_result),
                (_TAG_RSP_BATTLE_RESULT_BOX_RESULT, box_result),
            ]
            return _sproto_build_push_frame(1102, battle_result_body)

        def _init_capture(self, peer: str):
            safe_peer = ''.join(ch if ch.isalnum() or ch in {'-', '_', '.'} else '_' for ch in peer)
            stamp = str(int(time.time() * 1000))
            cap_dir = DIR / "artifacts" / "captures" / "tcp"
            try:
                cap_dir.mkdir(parents=True, exist_ok=True)
            except Exception:
                self._cap_c2u = None
                self._cap_u2c = None
                return
            self._cap_c2u = cap_dir / f"{stamp}_{safe_peer}_c2u.bin"
            self._cap_u2c = cap_dir / f"{stamp}_{safe_peer}_u2c.bin"

        def _capture(self, direction: str, data: bytes):
            if not data:
                return
            p = self._cap_c2u if direction == "c2u" else self._cap_u2c
            if p is None:
                return
            try:
                with p.open("ab") as f:
                    f.write(data)
            except Exception:
                pass

        def _feed_and_log_frames(self, direction: str, data: bytes):
            # Heuristic parser for common [2-byte big-endian length][payload] framing.
            # Helps quickly map message IDs/sessions during reverse engineering.
            if not data:
                return
            if not hasattr(self, "_frame_buf"):
                self._frame_buf = {"c2u": b"", "u2c": b""}

            buf = (self._frame_buf.get(direction) or b"") + data
            parsed = 0
            while len(buf) >= 2:
                payload_len = int.from_bytes(buf[:2], "big")
                if payload_len < 1 or payload_len > 65535:
                    break
                frame_len = payload_len + 2
                if len(buf) < frame_len:
                    break

                frame = buf[:frame_len]
                payload = frame[2:]
                msg_hint = payload[0:2].hex() if len(payload) >= 2 else ""
                preview = frame[:24].hex()
                line = (
                    f"[TCP][{direction}][frame] payload_len={payload_len} "
                    f"total_len={frame_len} msg={msg_hint} hex={preview}"
                )
                print(_console_safe(line))
                _append_utf8_log(line)

                parsed += 1
                buf = buf[frame_len:]

            if parsed == 0:
                if len(buf) >= 2:
                    payload_len_be = int.from_bytes(buf[:2], "big")
                    payload_len_le = int.from_bytes(buf[:2], "little")
                    line = (
                        f"[TCP][{direction}][frame] unparsed buf_len={len(buf)} "
                        f"be_len={payload_len_be} le_len={payload_len_le} "
                        f"hex={buf[:32].hex()}"
                    )
                    print(_console_safe(line))
                    _append_utf8_log(line)
                if len(buf) > 256 * 1024:
                    # Avoid unbounded growth if the stream does not match this framing.
                    buf = buf[-64 * 1024:]

            self._frame_buf[direction] = buf

        @staticmethod
        def _maybe_build_heartbeat_ack_payload(payload: bytes) -> bytes | None:
            """Build a best-effort ACK payload for common heartbeat packets.

            Observed frame payload from client: 15 02 xx xx
            We reply with frame payload:       15 03 xx xx
            """
            if len(payload) < 2:
                return None
            if payload[0:2] != b"\x15\x02":
                return None
            return b"\x15\x03" + payload[2:]

        @staticmethod
        def _maybe_build_reconnect_ack_payload(payload: bytes) -> bytes | None:
            """Build ACK for reconnect/resume packets.

            Observed frame payload from client: 1d 02 ...
            We reply with frame payload:       1d 03 ...
            """
            if len(payload) < 2:
                return None
            if payload[0:2] != b"\x1d\x02":
                return None
            return b"\x1d\x03" + payload[2:]

        @staticmethod
        def _maybe_build_first_5502_reply_payload(payload: bytes, mode: str) -> bytes | None:
            """Optionally build a first-response payload for 55 02 startup frame."""
            if len(payload) < 2 or payload[0:2] != b"\x55\x02":
                return None
            if mode in {"0", "false", "no", "off", "none"}:
                return None
            if mode in {"1", "true", "yes", "echo", "echo5503"}:
                # Preserve the original payload body and only flip opcode 55 02 -> 55 03.
                return b"\x55\x03" + payload[2:]
            if mode in {"minimal", "minimal5503"}:
                return b"\x55\x03"
            return None

        @staticmethod
        def _maybe_build_req02_echo_reply_payload(payload: bytes) -> bytes | None:
            """Best-effort fallback: reply to unknown request opcodes xx02 with xx03.

            Many lobby calls follow a request/response opcode pattern where the
            second byte flips from 0x02 -> 0x03. This fallback keeps the client
            moving when we have not implemented a specific handler yet.
            """
            if len(payload) < 2:
                return None
            # Avoid duplicate replies for opcodes handled by dedicated logic.
            if payload[0:2] in {b"\x15\x02", b"\x1d\x02", b"\x55\x02"}:
                return None
            if payload[1] != 0x02:
                return None
            return bytes([payload[0], 0x03]) + payload[2:]

        @staticmethod
        def _chat_as_list(value: object) -> list[object]:
            if isinstance(value, list):
                return value
            if isinstance(value, tuple):
                return list(value)
            return []

        @staticmethod
        def _chat_normalize_session_id(session_id: object, player_id: object) -> str:
            player_uid = _uid_str(player_id, "1000001")
            session_s = str(session_id or "").strip()
            if not session_s:
                return f"{player_uid}:{player_uid}"
            if session_s.startswith("group"):
                return _chat_normalize_group_id(session_s, fallback="group_world")
            if ":" not in session_s:
                target_uid = _uid_str(session_s, "")
                if target_uid and target_uid.isdigit():
                    left, right = player_uid, target_uid
                    left_num, right_num = _safe_int(left, -1), _safe_int(right, -1)
                    if left_num >= 0 and right_num >= 0:
                        if left_num > right_num:
                            left, right = right, left
                    elif left > right:
                        left, right = right, left
                    return f"{left}:{right}"
                return session_s
            parts_raw = session_s.split(":")
            if len(parts_raw) < 2:
                return session_s
            left = _uid_str(parts_raw[0], "")
            right = _uid_str(parts_raw[1], "")
            if not left or not right:
                return session_s
            if left == right:
                return f"{left}:{right}"
            left_num = _safe_int(left, -1)
            right_num = _safe_int(right, -1)
            if left_num >= 0 and right_num >= 0:
                if left_num > right_num:
                    left, right = right, left
            elif left > right:
                left, right = right, left
            return f"{left}:{right}"

        @staticmethod
        def _chat_session_participants(session_id: object) -> list[str]:
            session_s = str(session_id or "").strip()
            if not session_s or session_s.startswith("group"):
                return []
            if ":" not in session_s:
                return []
            parts_raw = session_s.split(":")
            if len(parts_raw) < 2:
                return []
            out: list[str] = []
            for raw in parts_raw[:2]:
                uid_s = _uid_str(raw, "")
                if uid_s and uid_s not in out:
                    out.append(uid_s)
            return out

        @staticmethod
        def _chat_enqueue_push(player_id: object, push: tuple[str, dict[str, object]]) -> None:
            _chat_queue_pending_push(player_id, push)

        @staticmethod
        def _chat_take_pending_pushes(player_id: object, *, max_items: int = 64) -> list[tuple[str, dict[str, object]]]:
            return _chat_drain_pending_pushes(player_id, max_items=max_items)

        def _chat_ctx(self) -> dict[str, object]:
            if not hasattr(self, "_chat_ctx_state"):
                self._chat_ctx_state = {
                    "buf": b"",
                    "rc4_c2s": None,
                    "rc4_s2c": None,
                    "player_id": "1000001",
                    "token_key": "",
                    "login_seen": False,
                }
            return self._chat_ctx_state

        def _chat_init_rc4(self, player_id: str, key: str) -> bool:
            key_s = str(key or "").strip()
            if not key_s:
                return False
            key_bytes = key_s.encode("utf-8", errors="replace")
            try:
                rc4_c2s = _RC4Stream(key_bytes)
                rc4_s2c = _RC4Stream(key_bytes)
            except Exception:
                return False

            ctx = self._chat_ctx()
            ctx["rc4_c2s"] = rc4_c2s
            ctx["rc4_s2c"] = rc4_s2c
            ctx["player_id"] = str(player_id or "1000001").strip() or "1000001"
            ctx["token_key"] = key_s
            return True

        def _chat_extract_packets(self, data: bytes) -> list[bytes]:
            if not data:
                return []
            ctx = self._chat_ctx()
            buf = (ctx.get("buf") or b"") + data
            if not isinstance(buf, (bytes, bytearray)):
                buf = data

            packets: list[bytes] = []
            while len(buf) >= 4:
                payload_len = int.from_bytes(buf[:4], "big", signed=False)
                if payload_len <= 0 or payload_len > 4 * 1024 * 1024:
                    line = (
                        f"[TCP][chat] invalid frame length={payload_len} "
                        f"buf_len={len(buf)} hex={buf[:32].hex()}"
                    )
                    print(_console_safe(line))
                    _append_utf8_log(line)
                    buf = buf[1:]

                frame_len = 4 + payload_len
                if len(buf) < frame_len:
                    break
                packets.append(buf[4:frame_len])
                buf = buf[frame_len:]

            if len(buf) > 2 * 1024 * 1024:
                # Keep residual bounded if a bad stream reaches this parser.
                buf = buf[-64 * 1024 :]

            ctx["buf"] = bytes(buf)
            return packets

        def _chat_parse_decrypted_request(self, payload: bytes) -> tuple[dict[str, str], dict[str, object]] | None:
            if len(payload) < 2:
                return None
            header_len = int.from_bytes(payload[:2], "big", signed=False)
            if header_len < 1 or header_len > 4096:
                return None
            if len(payload) < 2 + header_len:
                return None

            header_chunk = payload[2 : 2 + header_len]
            body_chunk = payload[2 + header_len :]

            try:
                raw_header = _chat_decode_header(header_chunk)
            except Exception:
                return None

            try:
                msg = json.loads(body_chunk.decode("utf-8", errors="strict")) if body_chunk else {}
            except Exception:
                return None
            if not isinstance(msg, dict):
                msg = {"value": msg}

            header = {str(k): str(v) for k, v in raw_header.items()}
            msg_norm = {str(k): v for k, v in msg.items()}
            return header, msg_norm

        def _chat_decode_request_frame(self, frame_payload: bytes) -> tuple[dict[str, str], dict[str, object]] | None:
            if not frame_payload:
                return None
            ctx = self._chat_ctx()

            login_prefix = _chat_parse_login_prefix(frame_payload)
            if login_prefix is not None:
                version, expire_time, player_id, encrypted_payload = login_prefix
                token = _holo_player_token_payload(player_id)
                token_key = str(token.get("key") or "")
                if token_key:
                    current_key = str(ctx.get("token_key") or "")
                    current_player = str(ctx.get("player_id") or "")
                    if not isinstance(ctx.get("rc4_c2s"), _RC4Stream) or current_key != token_key or current_player != player_id:
                        self._chat_init_rc4(player_id, token_key)

                    rc4 = ctx.get("rc4_c2s")
                    if isinstance(rc4, _RC4Stream):
                        snap = rc4.snapshot()
                        decrypted = rc4.crypt(encrypted_payload)
                        parsed = self._chat_parse_decrypted_request(decrypted)
                        if parsed is not None:
                            ctx["login_seen"] = True
                            line = (
                                f"[TCP][chat] login prefix accepted version={version} "
                                f"player_id={player_id} expire={expire_time}"
                            )
                            print(_console_safe(line))
                            _append_utf8_log(line)
                            return parsed
                        rc4.restore(snap)

            rc4 = ctx.get("rc4_c2s")
            if not isinstance(rc4, _RC4Stream):
                latest_token = _holo_latest_player_token_payload()
                if latest_token is not None:
                    latest_player_id = str(
                        latest_token.get("player_id")
                        or latest_token.get("playerId")
                        or latest_token.get("uid")
                        or "1000001"
                    )
                    latest_key = str(latest_token.get("key") or "")
                    self._chat_init_rc4(latest_player_id, latest_key)
                    rc4 = ctx.get("rc4_c2s")

            if not isinstance(rc4, _RC4Stream):
                return None

            snap = rc4.snapshot()
            decrypted = rc4.crypt(frame_payload)
            parsed = self._chat_parse_decrypted_request(decrypted)
            if parsed is not None:
                return parsed
            rc4.restore(snap)
            return None

        def _chat_build_response_for_cmd(
            self,
            req_msg: dict[str, object],
        ) -> tuple[str, dict[str, object], list[tuple[str, dict[str, object]]]]:
            global _CHAT_NEXT_MSG_ID

            cmd = str(req_msg.get("cmd") or "").strip().lower()
            ctx = self._chat_ctx()
            player_id = str(ctx.get("player_id") or "1000001").strip() or "1000001"
            now_ts = int(time.time())

            def _default_world_group() -> dict[str, object]:
                return _chat_build_group_payload("group_world", group_type="world", name="World")

            def _ensure_world_group(groups_obj: list[object]) -> None:
                for group in groups_obj:
                    if not isinstance(group, dict):
                        continue
                    if _chat_normalize_group_id(group.get("group_id"), fallback="") == "group_world":
                        group["group_id"] = "group_world"
                        info = group.get("info")
                        if not isinstance(info, dict):
                            info = {}
                            group["info"] = info
                        info.setdefault("name", "World")
                        info.setdefault("type", "world")
                        group.setdefault("attr", {"enable_voice": False})
                        group.setdefault("member_infos", [])
                        group.setdefault("invited_member_infos", [])
                        group.setdefault("personal_info", {"agora_channel_token": ""})
                        return
                groups_obj.insert(0, _default_world_group())

            def _safe_int(value: object, default: int = 0) -> int:
                try:
                    return int(value)
                except Exception:
                    return default

            def _profile_for_user(user_id: str) -> dict[str, object]:
                uid = _uid_str(user_id, player_id)
                local_pd = None
                if isinstance(_player_data, dict) and _uid_str(_player_data.get("uid"), "") == uid:
                    local_pd = _player_data
                profile = _online_ensure_profile(uid, local_pd=local_pd)
                name = _sanitize_display_name(profile.get("name"), f"Player_{uid}")
                level = max(1, _safe_int(profile.get("level"), 1))
                icon = max(0, _safe_int(profile.get("icon"), 0))
                icon_url = str(profile.get("icon_url") or "")
                rank_score = max(0, _safe_int(profile.get("rank_score"), 0))

                uid_i = max(1, _safe_int(uid, 1000001))
                player_info = {
                    "player_id": str(uid_i),
                    "playerId": str(uid_i),
                    "user_id": str(uid_i),
                    "id": str(uid_i),
                    "name": name,
                    "fbname": name,
                    "level": level,
                    "icon": icon,
                    "icon_url": icon_url,
                    "rank_score": rank_score,
                }
                return {
                    "user_id": str(uid_i),
                    "player_id": str(uid_i),
                    "account": f"local-{uid}",
                    "update_time": now_ts,
                    "player_info": player_info,
                }

            with _CHAT_LOCK:
                def _ensure_player_state(uid: object) -> tuple[dict[str, object], dict[str, object], list[object], set[str], set[str]]:
                    uid_s = _uid_str(uid, "1000001")
                    state_obj = _CHAT_PLAYER_STATE.get(uid_s)
                    if not isinstance(state_obj, dict):
                        state_obj = {
                            "sessions": {},
                            "groups": [],
                            "ignore_sessions": set(),
                            "ignore_group_types": set(),
                        }
                        _CHAT_PLAYER_STATE[uid_s] = state_obj

                    sessions_obj = state_obj.get("sessions")
                    if not isinstance(sessions_obj, dict):
                        sessions_obj = {}
                        state_obj["sessions"] = sessions_obj
                    if "group_world" not in sessions_obj:
                        sessions_obj["group_world"] = []

                    groups_obj = state_obj.get("groups")
                    if not isinstance(groups_obj, list):
                        groups_obj = [
                            {
                                "group_id": "group_world",
                                "info": {"type": "world"},
                                "attr": {"enable_voice": False},
                            }
                        ]
                        state_obj["groups"] = groups_obj
                    elif not any(isinstance(g, dict) and g.get("group_id") == "group_world" for g in groups_obj):
                        groups_obj.insert(0, {
                            "group_id": "group_world",
                            "info": {"type": "world"},
                            "attr": {"enable_voice": False},
                        })
                    _ensure_world_group(groups_obj)

                    ignore_sessions_obj = state_obj.get("ignore_sessions")
                    if not isinstance(ignore_sessions_obj, set):
                        ignore_sessions_obj = set()
                        state_obj["ignore_sessions"] = ignore_sessions_obj

                    ignore_group_types_obj = state_obj.get("ignore_group_types")
                    if not isinstance(ignore_group_types_obj, set):
                        ignore_group_types_obj = set()
                        state_obj["ignore_group_types"] = ignore_group_types_obj

                    return (
                        state_obj,
                        sessions_obj,
                        groups_obj,
                        ignore_sessions_obj,
                        ignore_group_types_obj,
                    )

                def _group_member_ids(group_session_id: object) -> set[str]:
                    gid = _chat_normalize_group_id(group_session_id, fallback="")
                    out: set[str] = set()
                    if not gid:
                        return out
                    for known_uid, known_state in _CHAT_PLAYER_STATE.items():
                        uid_s = _uid_str(known_uid, "")
                        if not uid_s or not isinstance(known_state, dict):
                            continue
                        groups_obj = known_state.get("groups")
                        if not isinstance(groups_obj, list):
                            continue
                        for group in groups_obj:
                            if not isinstance(group, dict):
                                continue
                            if _chat_normalize_group_id(group.get("group_id"), fallback="") == gid:
                                out.add(uid_s)
                                break
                    return out

                state, sessions, groups, ignore_sessions, ignore_group_types = _ensure_player_state(player_id)

                if cmd == "login":
                    token_payload = _holo_player_token_by_moment_token(req_msg.get("token"))
                    if token_payload is not None:
                        token_player_id = _uid_str(
                            token_payload.get("player_id")
                            or token_payload.get("playerId")
                            or token_payload.get("uid")
                            or player_id,
                            player_id,
                        )
                        ctx["player_id"] = token_player_id
                        if token_player_id != player_id:
                            player_id = token_player_id
                            _tls.uid = max(1, _safe_int(player_id, 1000001))
                            state, sessions, groups, ignore_sessions, ignore_group_types = _ensure_player_state(player_id)

                    _chat_bootstrap_mark(player_id, "seen_chat_login", True)
                    _append_utf8_log(f"[CHAT_BOOTSTRAP] seen_chat_login uid={player_id}")

                    response = {
                        "code": 0,
                        "message": "ok",
                        "groups": _chat_clone_json(groups),
                        "ignore_data": _chat_ignore_data_from_state(state),
                    }
                    pushes = []
                    return cmd or "login", response, pushes

                if cmd == "heartbeat":
                    return cmd, {"code": 0, "timestamp": now_ts}, []

                if cmd == "send":
                    session_id = _TCPHandler._chat_normalize_session_id(
                        req_msg.get("session_id"),
                        player_id,
                    )

                    send_window_ts = state.get("send_window_ts")
                    if not isinstance(send_window_ts, list):
                        send_window_ts = []
                    send_window_ts = [
                        _safe_int(ts, 0)
                        for ts in send_window_ts
                        if now_ts - _safe_int(ts, 0) <= 3
                    ]
                    if len(send_window_ts) >= 12:
                        state["send_window_ts"] = send_window_ts
                        return cmd, {
                            "code": 429,
                            "message": "chat rate limit",
                        }, []
                    send_window_ts.append(now_ts)
                    state["send_window_ts"] = send_window_ts

                    content = req_msg.get("content")
                    if not isinstance(content, dict):
                        content = {
                            "type": "text",
                            "data": str(content or ""),
                        }

                    content_type = str(content.get("type") or "").strip()
                    if not content_type:
                        content_type = "text"
                    content["type"] = content_type

                    if content_type == "client_custom":
                        custom_data = content.get("data")
                        if not isinstance(custom_data, dict):
                            custom_data = {}
                        content["data"] = custom_data
                    else:
                        content_data = content.get("data")
                        if not isinstance(content_data, str):
                            content_data = str(content_data or "")
                        if len(content_data) > 1024:
                            content_data = content_data[:1024]
                        content["data"] = content_data

                    send_id = str(req_msg.get("send_id") or "")
                    if session_manager is not None:
                        msg_id = session_manager._CHAT_NEXT_MSG_ID
                        session_manager._CHAT_NEXT_MSG_ID += 1
                    else:
                        msg_id = _CHAT_NEXT_MSG_ID
                        _CHAT_NEXT_MSG_ID += 1

                    msg_obj = {
                        "session_id": session_id,
                        "msg_id": msg_id,
                        "send_id": send_id,
                        "ts": int(time.time()),
                        "src_type": "user",
                        "src_info": _profile_for_user(player_id),
                        "content": content,
                    }

                    recipient_ids: set[str] = {player_id}
                    if session_id.startswith("group"):
                        session_id = _chat_normalize_group_id(session_id, fallback="group_world")
                        msg_obj["session_id"] = session_id
                        if session_id == "group_world":
                            recipient_ids.update(list(_CHAT_PLAYER_STATE.keys()))
                        else:
                            session_name = "Room" if session_id.startswith("group_room_") else "Group"
                            session_type = "room" if session_id.startswith("group_room_") else "group"
                            _chat_ensure_group_for_player(
                                player_id,
                                _chat_build_group_payload(session_id, group_type=session_type, name=session_name),
                                queue_create_push=False,
                            )
                            recipient_ids.update(_group_member_ids(session_id))
                    else:
                        for session_uid in _TCPHandler._chat_session_participants(session_id):
                            recipient_ids.add(session_uid)

                    if len(recipient_ids) > 500:
                        recipient_ids = set(sorted(recipient_ids)[:500])

                    for rid in recipient_ids:
                        _, recipient_sessions, _, _, _ = _ensure_player_state(rid)
                        bucket = recipient_sessions.get(session_id)
                        if not isinstance(bucket, list):
                            bucket = []
                            recipient_sessions[session_id] = bucket
                        bucket.append(_chat_clone_json(msg_obj))
                        if len(bucket) > _CHAT_MAX_MESSAGES_PER_SESSION:
                            del bucket[:-_CHAT_MAX_MESSAGES_PER_SESSION]

                    pushes: list[tuple[str, dict[str, object]]] = []
                    push_payload = {
                        "cmd": "info_msg",
                        "msgs": [_chat_clone_json(msg_obj)],
                    }
                    pushes.append(("push-info-msg", _chat_clone_json(push_payload)))
                    for rid in recipient_ids:
                        if rid != player_id:
                            _TCPHandler._chat_enqueue_push(rid, ("push-info-msg", push_payload))

                    return cmd, {
                        "code": 0,
                        "session_id": session_id,
                        "msg_id": msg_id,
                        "send_id": send_id,
                        "msgs": [_chat_clone_json(msg_obj)],
                    }, pushes

                if cmd == "get_session_msg":
                    session_id = _TCPHandler._chat_normalize_session_id(
                        req_msg.get("session_id"),
                        player_id,
                    )

                    raw_msgs = sessions.get(session_id)
                    if not isinstance(raw_msgs, list):
                        raw_msgs = []

                    try:
                        max_msg_count = int(req_msg.get("max_msg_count") or 50)
                    except Exception:
                        max_msg_count = 50
                    if max_msg_count <= 0:
                        max_msg_count = 50

                    msgs = raw_msgs[-max_msg_count:]
                    return cmd, {
                        "code": 0,
                        "session_id": session_id,
                        "msgs": _chat_clone_json(msgs),
                    }, []

                if cmd == "get_latest_session":
                    sessions_resp: list[dict[str, object]] = []
                    for sid, raw_msgs in sessions.items():
                        if not isinstance(raw_msgs, list):
                            continue
                        last_msgs: list[object] = []
                        if raw_msgs:
                            last_msgs = [_chat_clone_json(raw_msgs[-1])]

                        sid_s = str(sid)
                        info_obj: dict[str, object] = {}
                        if sid_s.startswith("group"):
                            if sid_s == "group_world":
                                gtype = "world"
                                gname = "World"
                            elif sid_s.startswith("group_room_"):
                                gtype = "room"
                                gname = "Room"
                            else:
                                gtype = "group"
                                gname = "Group"
                            info_obj = {
                                "group_id": sid_s,
                                "info": {
                                    "name": gname,
                                    "type": gtype,
                                },
                                "member_infos": [],
                                "invited_member_infos": [],
                                "personal_info": {
                                    "agora_channel_token": "",
                                },
                            }

                        sessions_resp.append(
                            {
                                "session_info": {
                                    "id": sid_s,
                                    "unread": 0,
                                    "info": info_obj,
                                },
                                "last_msgs": last_msgs,
                            }
                        )

                    def _latest_ts(entry: dict[str, object]) -> int:
                        last_msgs = entry.get("last_msgs")
                        if not isinstance(last_msgs, list) or not last_msgs:
                            return 0
                        msg = last_msgs[0]
                        if not isinstance(msg, dict):
                            return 0
                        try:
                            return int(msg.get("ts") or 0)
                        except Exception:
                            return 0

                    sessions_resp.sort(key=_latest_ts, reverse=True)
                    return cmd, {
                        "code": 0,
                        "sessions": sessions_resp,
                    }, []

                if cmd in {
                    "set_msg_received",
                    "reply_add_group_member",
                    "add_group_member",
                    "remove_group_member",
                    "set_msg_readed",
                }:
                    group_id = str(req_msg.get("group_id") or "").strip()
                    if group_id:
                        return cmd, {"code": 0, "group_id": group_id}, []
                    return cmd, {"code": 0}, []

                if cmd == "ignore":
                    payload = req_msg.get("data")
                    if not isinstance(payload, dict):
                        payload = {}
                    for session_id in self._chat_as_list(payload.get("sessions")):
                        if session_id is not None:
                            ignore_sessions.add(str(session_id))
                    for group_type in self._chat_as_list(payload.get("group_types")):
                        if group_type is not None:
                            ignore_group_types.add(str(group_type))
                    return cmd, {
                        "code": 0,
                        "ignore_data": _chat_ignore_data_from_state(state),
                    }, []

                if cmd == "unignore":
                    payload = req_msg.get("data")
                    if not isinstance(payload, dict):
                        payload = {}
                    for session_id in self._chat_as_list(payload.get("sessions")):
                        if session_id is not None:
                            ignore_sessions.discard(str(session_id))
                    for group_type in self._chat_as_list(payload.get("group_types")):
                        if group_type is not None:
                            ignore_group_types.discard(str(group_type))
                    return cmd, {
                        "code": 0,
                        "ignore_data": _chat_ignore_data_from_state(state),
                    }, []

                if cmd in {"create_group", "update_group", "delete_group", "exit_group"}:
                    requested_group_id = req_msg.get("group_id")
                    group_id = _chat_normalize_group_id(requested_group_id, fallback="")
                    if not group_id:
                        group_id = f"group_{int(time.time() * 1000)}"

                    info = req_msg.get("info")
                    if not isinstance(info, dict):
                        info = {}
                    requested_type = str(info.get("type") or "").strip().lower()
                    if group_id == "group_world":
                        group_type = "world"
                    elif requested_type in {"group", "team", "room"}:
                        group_type = requested_type
                    elif group_id.startswith("group_room_"):
                        group_type = "room"
                    else:
                        group_type = "group"
                    default_name = "World" if group_id == "group_world" else ("Room" if group_type == "room" else "Group")
                    group_name = str(info.get("name") or default_name).strip() or default_name

                    member_ids: set[str] = {player_id}
                    for raw_uid in self._chat_as_list(req_msg.get("members")):
                        uid_s = _uid_str(raw_uid, "")
                        if uid_s:
                            member_ids.add(uid_s)

                    if cmd == "exit_group":
                        _chat_remove_group_for_player(player_id, group_id, queue_delete_push=True)
                        return cmd, {
                            "code": 0,
                            "group_id": group_id,
                        }, []

                    if cmd == "delete_group":
                        for known_uid in list(_CHAT_PLAYER_STATE.keys()):
                            _chat_remove_group_for_player(known_uid, group_id, queue_delete_push=True)
                        return cmd, {
                            "code": 0,
                            "group_id": group_id,
                        }, []

                    group_payload = _chat_build_group_payload(
                        group_id,
                        group_type=group_type,
                        name=group_name,
                    )
                    queue_create_push = cmd == "create_group"
                    for uid in member_ids:
                        _chat_ensure_group_for_player(
                            uid,
                            group_payload,
                            queue_create_push=queue_create_push,
                        )

                    if cmd == "update_group":
                        update_push = {
                            "cmd": "info_update_group",
                            "group": _chat_clone_json(group_payload),
                        }
                        for uid in member_ids:
                            if uid == player_id:
                                continue
                            _TCPHandler._chat_enqueue_push(uid, ("push-info-update-group", update_push))
                        return cmd, {
                            "code": 0,
                            "group_id": group_id,
                        }, [("push-info-update-group", _chat_clone_json(update_push))]

                    return cmd, {
                        "code": 0,
                        "group_id": group_id,
                    }, []

                if cmd == "get_group_be_invited_history":
                    return cmd, {
                        "code": 0,
                        "be_invited_history": [],
                    }, []

                if cmd == "get_agora_channel_token":
                    return cmd, {
                        "code": 0,
                        "token": "local-agora-token",
                    }, []

                if cmd == "get_player_info":
                    req_player_id = str(req_msg.get("player_id") or player_id).strip() or player_id
                    profile = _profile_for_user(req_player_id)
                    return cmd, {
                        "code": 0,
                        "player": _chat_clone_json(profile),
                    }, []

                if cmd == "get_player_infos":
                    player_ids = [str(v) for v in self._chat_as_list(req_msg.get("player_ids")) if v is not None]
                    players = [_profile_for_user(pid) for pid in player_ids]
                    return cmd, {
                        "code": 0,
                        "players": _chat_clone_json(players),
                    }, []

                return (cmd or "unknown"), {
                    "code": 0,
                    "message": "ok",
                }, []

        def _chat_send_packet(self, session: str, trace: str, response: dict[str, object], tag: str) -> bool:
            ctx = self._chat_ctx()
            rc4 = ctx.get("rc4_s2c")
            if not isinstance(rc4, _RC4Stream):
                return False

            session = str(session or "0")
            trace = str(trace or "").strip()

            header: dict[str, object] = {
                "codec": "json",
                "session": session,
                "destination": "chat",
                "source": "chat",
                "ts": int(time.time()),
            }
            if trace:
                header["trace"] = trace

            try:
                header_chunk = _chat_encode_header(header)
                body_chunk = json.dumps(response, ensure_ascii=False, separators=(",", ":")).encode("utf-8")
            except Exception as exc:
                import traceback; traceback.print_exc()
                line = f"[TCP][chat] encode response failed tag={tag}: {exc}"
                print(_console_safe(line))
                _append_utf8_log(line)
                return False

            plaintext = len(header_chunk).to_bytes(2, "big") + header_chunk + body_chunk
            encrypted = rc4.crypt(plaintext)
            frame = len(encrypted).to_bytes(4, "big") + encrypted

            try:
                self.request.sendall(frame)
            except Exception as exc:
                import traceback; traceback.print_exc()
                line = f"[TCP][chat] send failed tag={tag}: {exc}"
                print(_console_safe(line))
                _append_utf8_log(line)
                return False

            line = (
                f"[TCP][chat] sent tag={tag} session={session} "
                f"enc_len={len(encrypted)} hex={frame[:48].hex()}"
            )
            print(_console_safe(line))
            _append_utf8_log(line)
            self._capture("u2c", frame)
            return True

        def _chat_send_response(self, req_header: dict[str, str], response: dict[str, object], tag: str) -> bool:
            session = str(req_header.get("session") or "0")
            trace = str(req_header.get("trace") or "").strip()
            return self._chat_send_packet(session, trace, response, tag)

        def _chat_send_push(self, response: dict[str, object], tag: str) -> bool:
            return self._chat_send_packet("0", "", response, tag)

        def _chat_handle_connection(self, peer: str, listen_port: int) -> None:
            import services.chat
            services.chat.handle_chat_connection(self.request, self.client_address, listen_port)

        def _extract_framed_packets(self, direction: str, data: bytes) -> list[bytes]:
            """Return complete [len16][payload] packets for action handling."""
            if not data:
                return []
            if not hasattr(self, "_action_buf"):
                self._action_buf = {"c2u": b"", "u2c": b""}

            buf = (self._action_buf.get(direction) or b"") + data
            packets: list[bytes] = []
            while len(buf) >= 2:
                payload_len = int.from_bytes(buf[:2], "big")
                if 1 <= payload_len <= 65535:
                    frame_len = payload_len + 2
                    if len(buf) < frame_len:
                        payload_len_le = int.from_bytes(buf[:2], "little")
                        if payload_len_le != payload_len and 1 <= payload_len_le <= 65535:
                            frame_len_le = payload_len_le + 2
                            if len(buf) >= frame_len_le:
                                packets.append(buf[:frame_len_le])
                                buf = buf[frame_len_le:]
                                continue
                        break
                    packets.append(buf[:frame_len])
                    buf = buf[frame_len:]
                    continue

                payload_len_le = int.from_bytes(buf[:2], "little")
                if 1 <= payload_len_le <= 65535:
                    frame_len_le = payload_len_le + 2
                    if len(buf) < frame_len_le:
                        break
                    packets.append(buf[:frame_len_le])
                    buf = buf[frame_len_le:]
                    continue

                break

            if not packets and len(buf) > 256 * 1024:
                buf = buf[-64 * 1024:]

            self._action_buf[direction] = buf
            return packets

        def _send_payload_frame(self, payload: bytes, tag: str) -> bool:
            if not payload:
                return False
            frame = len(payload).to_bytes(2, "big") + payload
            try:
                self.request.sendall(frame)
            except Exception:
                return False

            line = f"[TCP] sent {tag} payload_len={len(payload)} hex={frame[:64].hex()}"
            print(_console_safe(line))
            _append_utf8_log(line)
            self._capture("u2c", frame)
            self._feed_and_log_frames("u2c", frame)
            return True

        def _proxy_loop(self, upstream: socket.socket):
            """Bidirectional TCP relay between game client and upstream lobby."""
            sockets = [self.request, upstream]
            while True:
                try:
                    readable, _, exceptional = select.select(sockets, [], sockets, 1.0)
                except Exception:
                    break

                if exceptional:
                    break

                for src in readable:
                    dst = upstream if src is self.request else self.request
                    try:
                        data = src.recv(4096)
                    except Exception:
                        return
                    if not data:
                        return

                    direction = "c2u" if src is self.request else "u2c"
                    snippet = data[:32]
                    line = f"[TCP][{direction}] len={len(data)} hex={snippet.hex()}"
                    print(_console_safe(line))
                    _append_utf8_log(line)
                    self._capture(direction, data)
                    self._feed_and_log_frames(direction, data)

                    try:
                        dst.sendall(data)
                    except Exception:
                        return

        def handle(self):
            try:
                peer_ip = self.client_address[0]
                if peer_ip and peer_ip not in ("127.0.0.1", "localhost", "::1"):
                    _TCPHandler._last_client_peer_ip = peer_ip
            except Exception:
                pass
            if hasattr(self, "request") and self.request:
                try:
                    bound_ip = self.request.getsockname()[0]
                    if bound_ip and bound_ip not in ("0.0.0.0", "::", "127.0.0.1"):
                        _TCPHandler._current_bound_host = bound_ip
                except Exception:
                    pass
            try:
                peer = f"{self.client_address[0]}:{self.client_address[1]}"
            except Exception:
                peer = str(self.client_address)
            try:
                listen_port = int(self.server.server_address[1])
            except Exception:
                listen_port = -1
            if listen_port > 0:
                line = f"[TCP] connect from {peer} on port {listen_port}"
            else:
                line = f"[TCP] connect from {peer}"
            print(_console_safe(line))
            _append_utf8_log(line)
            self._init_capture(peer)

            # ── Battle port: delegate to battle_server module ──
            is_battle_port = listen_port == BATTLE_PORT
            is_battle_zone_port = listen_port == BATTLE_ZONE_PORT and listen_port != GAME_PORT
            if is_battle_port or is_battle_zone_port:
                role = "battle-zone" if is_battle_zone_port and not is_battle_port else "battle"
                line_b = f"[TCP] {role} connection from {peer} on port {listen_port}"
                print(_console_safe(line_b))
                _append_utf8_log(line_b)
                try:
                    import battle_server as _battle_server_module
                    _battle_server_module = importlib.reload(_battle_server_module)
                    handle_battle_connection = _battle_server_module.handle_battle_connection
                    build_tag = str(getattr(_battle_server_module, "BATTLE_SERVER_BUILD_TAG", "unknown"))
                    module_path = str(getattr(_battle_server_module, "__file__", "unknown"))
                    line_mod = (
                        f"[TCP] battle module loaded tag={build_tag} "
                        f"path={module_path}"
                    )
                    print(_console_safe(line_mod))
                    _append_utf8_log(line_mod)
                    def _battle_log(msg: str):
                        safe = _console_safe(f"[Battle] {msg}")
                        print(safe)
                        _append_utf8_log(f"[Battle] {msg}")
                    handle_battle_connection(
                        self.request, self.client_address,
                        _game_state, _player_data, _battle_log)
                except Exception as e:
                    import traceback; traceback.print_exc()
                    line_err = f"[Battle] error: {e}"
                    print(_console_safe(line_err))
                    _append_utf8_log(line_err)
                return

            if listen_port == CHAT_PORT:
                self._chat_handle_connection(peer, listen_port)
                return

            # Optional proxy mode: forward raw TCP to the real lobby.
            # This avoids re-implementing proprietary binary protocol in Python.
            proxy_host = (os.environ.get("LOBBY_PROXY_HOST") or "").strip()
            proxy_port_raw = (os.environ.get("LOBBY_PROXY_PORT") or "12000").strip()
            try:
                proxy_port = int(proxy_port_raw)
            except Exception:
                proxy_port = 12000

            if proxy_host:
                try:
                    connect_timeout = float(os.environ.get("LOBBY_PROXY_CONNECT_TIMEOUT", "12") or "12")
                except Exception:
                    connect_timeout = 12.0
                try:
                    upstream = socket.create_connection((proxy_host, proxy_port), timeout=connect_timeout)
                except Exception as e:
                    import traceback; traceback.print_exc()
                    line_fail = f"[TCP] proxy connect failed {proxy_host}:{proxy_port}: {e}"
                    print(_console_safe(line_fail))
                    _append_utf8_log(line_fail)
                else:
                    line_ok = f"[TCP] proxy {peer} -> {proxy_host}:{proxy_port}"
                    print(_console_safe(line_ok))
                    _append_utf8_log(line_ok)
                    try:
                        try:
                            self.request.settimeout(None)
                        except Exception:
                            pass
                        try:
                            upstream.settimeout(None)
                        except Exception:
                            pass
                        self._proxy_loop(upstream)
                    finally:
                        try:
                            upstream.close()
                        except Exception:
                            pass
                    return

                line_fallback = "[TCP] proxy unavailable, falling back to local TCP stub"
                print(_console_safe(line_fallback))
                _append_utf8_log(line_fallback)

            try:
                # Keep the socket open to avoid battle disconnects caused by lobby
                # stub session expiry during active gameplay. By default we keep the
                # stub alive indefinitely (TCP_STUB_SECONDS<=0). Set a positive
                # timeout only when explicit bounded capture is needed.
                tcp_stub_seconds_raw = (os.environ.get("TCP_STUB_SECONDS", "0") or "0").strip()
                try:
                    tcp_stub_seconds = float(tcp_stub_seconds_raw)
                except Exception:
                    tcp_stub_seconds = 0.0
                end_at: float | None = None
                if tcp_stub_seconds > 0:
                    end_at = time.time() + tcp_stub_seconds
                auto_ack = (os.environ.get("TCP_AUTO_ACK", "1") or "1").strip().lower() in {"1", "true", "yes"}
                reconnect_ack = (os.environ.get("TCP_RECONNECT_ACK", "1") or "1").strip().lower() in {"1", "true", "yes"}
                reply_all_5502 = (os.environ.get("TCP_REPLY_ALL_5502", "0") or "0").strip().lower() in {"1", "true", "yes"}
                req02_echo_ack = (os.environ.get("TCP_REQ02_ECHO_ACK", "0") or "0").strip().lower() in {"1", "true", "yes"}
                first_5502_mode = (os.environ.get("TCP_FIRST_5502_REPLY", "echo5503") or "echo5503").strip().lower()
                try:
                    extra_5502_replies = int((os.environ.get("TCP_EXTRA_5502_REPLIES", "0") or "0").strip())
                except Exception:
                    extra_5502_replies = 0
                if extra_5502_replies < 0:
                    extra_5502_replies = 0

                try:
                    extra_5502_min_payload = int((os.environ.get("TCP_EXTRA_5502_MIN_PAYLOAD", "200") or "200").strip())
                except Exception:
                    extra_5502_min_payload = 200
                if extra_5502_min_payload < 0:
                    extra_5502_min_payload = 0
                extra_5502_reply_mode = (os.environ.get("TCP_EXTRA_5502_REPLY_MODE", "minimal5503") or "minimal5503").strip().lower()

                extra_5502_prefix_hex = (os.environ.get("TCP_EXTRA_5502_PREFIX_HEX", "d022") or "d022").strip().lower()
                extra_5502_prefix = b""
                if extra_5502_prefix_hex:
                    try:
                        extra_5502_prefix = bytes.fromhex(extra_5502_prefix_hex)
                    except Exception:
                        extra_5502_prefix = b""

                naming_5502_ack = (os.environ.get("TCP_NAMING_5502_ACK", "0") or "0").strip().lower() in {"1", "true", "yes"}
                naming_5502_reply_mode = (os.environ.get("TCP_NAMING_5502_REPLY_MODE", "echo5503") or "echo5503").strip().lower()
                try:
                    naming_5502_max_replies = int((os.environ.get("TCP_NAMING_5502_MAX_REPLIES", "12") or "12").strip())
                except Exception:
                    naming_5502_max_replies = 12
                if naming_5502_max_replies < 0:
                    naming_5502_max_replies = 0

                naming_5502_prefixes_raw = (os.environ.get("TCP_NAMING_5502_PREFIXES", "d232,d236,d23a,d23e,d242") or "d232,d236,d23a,d23e,d242").strip().lower()
                naming_5502_prefixes: list[bytes] = []
                for token in naming_5502_prefixes_raw.split(","):
                    p = token.strip()
                    if not p:
                        continue
                    try:
                        naming_5502_prefixes.append(bytes.fromhex(p))
                    except Exception:
                        pass

                try:
                    naming_5502_min_payload = int((os.environ.get("TCP_NAMING_5502_MIN_PAYLOAD", "24") or "24").strip())
                except Exception:
                    naming_5502_min_payload = 24
                try:
                    naming_5502_max_payload = int((os.environ.get("TCP_NAMING_5502_MAX_PAYLOAD", "40") or "40").strip())
                except Exception:
                    naming_5502_max_payload = 40
                if naming_5502_min_payload < 0:
                    naming_5502_min_payload = 0
                if naming_5502_max_payload < naming_5502_min_payload:
                    naming_5502_max_payload = naming_5502_min_payload

                selective_5502 = (os.environ.get("TCP_SELECTIVE_5502", "0") or "0").strip().lower() in {"1", "true", "yes"}
                try:
                    selective_5502_min_payload = int((os.environ.get("TCP_SELECTIVE_5502_MIN_PAYLOAD", "20") or "20").strip())
                except Exception:
                    selective_5502_min_payload = 20
                try:
                    selective_5502_max_payload = int((os.environ.get("TCP_SELECTIVE_5502_MAX_PAYLOAD", "96") or "96").strip())
                except Exception:
                    selective_5502_max_payload = 96
                if selective_5502_min_payload < 0:
                    selective_5502_min_payload = 0
                if selective_5502_max_payload < selective_5502_min_payload:
                    selective_5502_max_payload = selective_5502_min_payload

                first_5502_seen = False
                extra_5502_sent = 0
                naming_5502_sent = 0
                line_mode = (
                    f"[TCP] local stub mode auto_ack={auto_ack} "
                    f"reconnect_ack={reconnect_ack} reply_all_5502={reply_all_5502} "
                    f"req02_echo_ack={req02_echo_ack} "
                    f"first_5502_reply={first_5502_mode} "
                    f"extra_5502_replies={extra_5502_replies} "
                    f"extra_5502_min_payload={extra_5502_min_payload} "
                    f"extra_5502_prefix_hex={extra_5502_prefix_hex or '-'} "
                    f"extra_5502_reply_mode={extra_5502_reply_mode} "
                    f"naming_5502_ack={naming_5502_ack} "
                    f"naming_5502_reply_mode={naming_5502_reply_mode} "
                    f"naming_5502_max_replies={naming_5502_max_replies} "
                    f"naming_5502_prefixes={naming_5502_prefixes_raw or '-'} "
                    f"naming_5502_min={naming_5502_min_payload} "
                    f"naming_5502_max={naming_5502_max_payload} "
                    f"selective_5502={selective_5502} "
                    f"selective_5502_min={selective_5502_min_payload} "
                    f"selective_5502_max={selective_5502_max_payload} "
                    f"stub_seconds={tcp_stub_seconds:g}"
                )
                print(_console_safe(line_mode))
                _append_utf8_log(line_mode)

                sproto_mode = _HAS_SPROTO and (os.environ.get("TCP_SPROTO", "1") or "1").strip().lower() in {"1", "true", "yes"}
                if sproto_mode:
                    line_sp = "[TCP] sproto protocol handler ENABLED"
                    print(_console_safe(line_sp))
                    _append_utf8_log(line_sp)

                try:
                    self.request.settimeout(1.0)
                except Exception:
                    pass
                total = 0
                while True:
                    if end_at is not None and time.time() >= end_at:
                        line_to = (
                            f"[TCP] local stub session timeout peer={peer} "
                            f"after={tcp_stub_seconds:g}s"
                        )
                        print(_console_safe(line_to))
                        _append_utf8_log(line_to)
                        break
                    try:
                        data = self.request.recv(4096)
                    except TimeoutError:
                        continue
                    except OSError:
                        break
                    except Exception:
                        break

                    if not data:
                        break
                    total += len(data)
                    snippet = data[:64]
                    line2 = f"[TCP] recv len={len(data)} total={total} hex={snippet.hex()}"
                    print(_console_safe(line2))
                    _append_utf8_log(line2)
                    self._capture("c2u", data)
                    self._feed_and_log_frames("c2u", data)

                    stop_loop = False
                    for packet in self._extract_framed_packets("c2u", data):
                        payload = packet[2:]

                        # ── Try proper sproto protocol response first ──
                        if sproto_mode:
                            sproto_result = self._try_build_sproto_response(packet)
                            if sproto_result is not None:
                                send_ok = True
                                for resp_frame, resp_tag in sproto_result:
                                    try:
                                        self.request.sendall(resp_frame)
                                    except Exception:
                                        send_ok = False
                                        stop_loop = True
                                        break
                                    line_sent = f"[TCP] sent {resp_tag} frame_len={len(resp_frame)} hex={resp_frame[:64].hex()}"
                                    print(_console_safe(line_sent))
                                    _append_utf8_log(line_sent)
                                    self._capture("u2c", resp_frame)
                                    self._feed_and_log_frames("u2c", resp_frame)
                                if not send_ok:
                                    break
                                continue  # Skip old byte-flip handlers


                        # ── Fallback: old byte-flip handlers ──

                        if len(payload) >= 2 and payload[0:2] == b"\x55\x02":
                            reply_payload: bytes | None = None
                            reply_tag = ""
                            uses_extra_slot = False

                            if not first_5502_seen:
                                first_5502_seen = True
                                reply_payload = self._maybe_build_first_5502_reply_payload(payload, first_5502_mode)
                                reply_tag = "first-5502-reply"
                            elif reply_all_5502:
                                reply_payload = b"\x55\x03" + payload[2:]
                                reply_tag = "5502-reply"
                            elif extra_5502_sent < extra_5502_replies and len(payload) >= extra_5502_min_payload:
                                matches_extra_prefix = (not extra_5502_prefix) or (
                                    len(payload) >= (2 + len(extra_5502_prefix))
                                    and payload[2 : 2 + len(extra_5502_prefix)] == extra_5502_prefix
                                )
                                if matches_extra_prefix:
                                    reply_payload = self._maybe_build_first_5502_reply_payload(payload, extra_5502_reply_mode)
                                    reply_tag = "5502-extra-reply"
                                    uses_extra_slot = True
                            elif naming_5502_ack and naming_5502_sent < naming_5502_max_replies:
                                in_naming_size = naming_5502_min_payload <= len(payload) <= naming_5502_max_payload
                                matches_naming_prefix = False
                                if naming_5502_prefixes:
                                    for pref in naming_5502_prefixes:
                                        if len(payload) >= (2 + len(pref)) and payload[2 : 2 + len(pref)] == pref:
                                            matches_naming_prefix = True
                                            break
                                if in_naming_size and matches_naming_prefix:
                                    reply_payload = self._maybe_build_first_5502_reply_payload(payload, naming_5502_reply_mode)
                                    reply_tag = "5502-naming-reply"
                            elif selective_5502 and selective_5502_min_payload <= len(payload) <= selective_5502_max_payload:
                                reply_payload = b"\x55\x03" + payload[2:]
                                reply_tag = "5502-selective-reply"

                            if reply_payload is not None:
                                if not self._send_payload_frame(reply_payload, reply_tag):
                                    stop_loop = True
                                    break
                                if uses_extra_slot:
                                    extra_5502_sent += 1
                                if reply_tag == "5502-naming-reply":
                                    naming_5502_sent += 1

                        if reconnect_ack:
                            reconnect_payload = self._maybe_build_reconnect_ack_payload(payload)
                            if reconnect_payload is not None and not self._send_payload_frame(reconnect_payload, "reconnect-ack"):
                                stop_loop = True
                                break

                        if auto_ack:
                            ack_payload = self._maybe_build_heartbeat_ack_payload(payload)
                            if ack_payload is not None and not self._send_payload_frame(ack_payload, "heartbeat-ack"):
                                stop_loop = True
                                break

                        if req02_echo_ack:
                            generic_payload = self._maybe_build_req02_echo_reply_payload(payload)
                            if generic_payload is not None and not self._send_payload_frame(generic_payload, "req02-echo-ack"):
                                stop_loop = True
                                break

                    if stop_loop:
                        break
            finally:
                with _LOBBY_PUSH_LOCK:
                    uid_val = getattr(self, "_session_uid_value", None)
                    if uid_val:
                        uid_s = str(uid_val)
                        if _ACTIVE_LOBBY_HANDLERS.get(uid_s) is self:
                            _ACTIVE_LOBBY_HANDLERS.pop(uid_s, None)

    def _start_tcp_stub(port: int, required: bool):
        if os.name == "nt":
            _free_windows_port(port, "TCP")
        socketserver.ThreadingTCPServer.allow_reuse_address = True
        try:
            tcpd = socketserver.ThreadingTCPServer(("0.0.0.0", port), _TCPHandler)
        except OSError as e:
            _log_windows_port_status(port, "TCP")
            if os.name == "nt":
                _free_windows_port(port, "TCP")
                time.sleep(0.25)
                try:
                    tcpd = socketserver.ThreadingTCPServer(("0.0.0.0", port), _TCPHandler)
                except OSError as e2:
                    if required:
                        startup_state["tcp"] = False
                        tcp_started_event.set()
                    msg = _console_safe(f"TCP stub not started on port {port}: {e2}")
                    print(msg)
                    _append_utf8_log(msg)
                    return
            else:
                if required:
                    startup_state["tcp"] = False
                    tcp_started_event.set()
                msg = _console_safe(f"TCP stub not started on port {port}: {e}")
                print(msg)
                _append_utf8_log(msg)
                return
        if required:
            startup_state["tcp"] = True
            tcp_started_event.set()
        tcpd.daemon_threads = True
        msg = _console_safe(f"TCP  stub on 0.0.0.0:{port} (accepts connections)")
        print(msg)
        _append_utf8_log(msg)
        tcpd.serve_forever()

    _udp_caps: dict[str, Path] = {}

    def _udp_cap_path(peer: str) -> Path | None:
        safe_peer = "".join(ch if ch.isalnum() or ch in {"-", "_", "."} else "_" for ch in peer)
        try:
            cap_dir = DIR / "artifacts" / "captures" / "udp"
            cap_dir.mkdir(parents=True, exist_ok=True)
        except Exception:
            return None
        if peer not in _udp_caps:
            stamp = str(int(time.time() * 1000))
            _udp_caps[peer] = cap_dir / f"{stamp}_{safe_peer}.bin"
        return _udp_caps[peer]

    def _udp_capture(peer: str, data: bytes):
        if not data:
            return
        p = _udp_cap_path(peer)
        if p is None:
            return
        try:
            # Very small framing to preserve datagram boundaries:
            #   [8 bytes ms timestamp][4 bytes big-endian len][payload]
            ts_ms = int(time.time() * 1000).to_bytes(8, "big", signed=False)
            ln = len(data).to_bytes(4, "big", signed=False)
            with p.open("ab") as f:
                f.write(ts_ms)
                f.write(ln)
                f.write(data)
        except Exception:
            pass

    class _UDPHandler(socketserver.BaseRequestHandler):
        def handle(self):
            try:
                data, _sock = self.request
            except Exception:
                return
            if not data:
                return
            try:
                peer = f"{self.client_address[0]}:{self.client_address[1]}"
            except Exception:
                peer = str(self.client_address)
            snippet = data[:64]
            line = f"[UDP] recv from {peer} len={len(data)} hex={snippet.hex()}"
            print(_console_safe(line))
            _append_utf8_log(line)
            _udp_capture(peer, data)
            try:
                listen_port = int(self.server.server_address[1])
            except Exception:
                listen_port = 0
            if udp_echo_enabled and listen_port in {BATTLE_PORT, BATTLE_ZONE_PORT, GAME_PORT}:
                try:
                    _sock.sendto(data, self.client_address)
                    line_tx = f"[UDP] echo to {peer} len={len(data)} on port {listen_port}"
                    print(_console_safe(line_tx))
                    _append_utf8_log(line_tx)
                except Exception as e:
                    import traceback; traceback.print_exc()
                    line_err = f"[UDP] echo failed to {peer} on port {listen_port}: {e}"
                    print(_console_safe(line_err))
                    _append_utf8_log(line_err)

    def _start_udp_stub(port: int, required: bool):
        if os.name == "nt":
            _free_windows_port(port, "UDP")
        socketserver.ThreadingUDPServer.allow_reuse_address = True
        try:
            udpd = socketserver.ThreadingUDPServer(("0.0.0.0", port), _UDPHandler)
        except OSError as e:
            _log_windows_port_status(port, "UDP")
            if os.name == "nt":
                _free_windows_port(port, "UDP")
                time.sleep(0.25)
                try:
                    udpd = socketserver.ThreadingUDPServer(("0.0.0.0", port), _UDPHandler)
                except OSError as e2:
                    if required:
                        startup_state["udp"] = False
                        udp_started_event.set()
                    msg = _console_safe(f"UDP stub not started on port {port}: {e2}")
                    print(msg)
                    _append_utf8_log(msg)
                    return
            else:
                if required:
                    startup_state["udp"] = False
                    udp_started_event.set()
                msg = _console_safe(f"UDP stub not started on port {port}: {e}")
                print(msg)
                _append_utf8_log(msg)
                return
        if required:
            startup_state["udp"] = True
            udp_started_event.set()
        udpd.daemon_threads = True
        msg = _console_safe(
            f"UDP  stub on 0.0.0.0:{port} (captures datagrams; battle echo={'on' if udp_echo_enabled else 'off'})"
        )
        print(msg)
        _append_utf8_log(msg)
        udpd.serve_forever()

    try:
        httpd = TLSServer(("0.0.0.0", PORT), Handler)
    except PermissionError as e:
        print(
            "Cannot bind port %s: %s\n"
            "  1) Run PowerShell: right-click -> Run as administrator, then:\n"
            "       cd %s\n"
            "       python run_https_443.py\n"
            "  2) Or see what uses the port:  netstat -ano | findstr :%s\n"
            "  3) For a quick browser test on another port:  set HTTPS_PORT=8443\n"
            "     (the game uses https://... default port 443 — 8443 is only for manual checks)."
            % (PORT, e, DIR, PORT),
            file=sys.stderr,
        )
        sys.exit(1)
    httpd.socket = ctx.wrap_socket(httpd.socket, server_side=True)

    # Create capture directories up-front so it's obvious whether any traffic arrived.
    try:
        (DIR / "artifacts" / "captures" / "tcp").mkdir(parents=True, exist_ok=True)
    except Exception:
        pass
    try:
        (DIR / "artifacts" / "captures" / "udp").mkdir(parents=True, exist_ok=True)
    except Exception:
        pass

    if len(stub_ports) > 1:
        ports_str = ",".join(str(p) for p in stub_ports)
        msg = _console_safe(f"Lobby stub ports: {ports_str} (primary={GAME_PORT})")
        print(msg)
        _append_utf8_log(msg)

    t = threading.Thread(target=_start_http, daemon=True)
    t.start()
    for p in stub_ports:
        threading.Thread(target=_start_tcp_stub, args=(p, p == GAME_PORT), daemon=True).start()
    for p in stub_ports:
        threading.Thread(target=_start_udp_stub, args=(p, p == GAME_PORT), daemon=True).start()

    # Avoid running in a partial state where HTTPS is up but lobby stubs are missing.
    # This usually happens when another process already owns the primary GAME_PORT.
    tcp_started_event.wait(timeout=2.0)
    udp_started_event.wait(timeout=2.0)
    if require_tcp_stub and startup_state.get("tcp") is not True:
        msg = (
            f"FATAL: REQUIRE_TCP_STUB=1 and TCP stub failed on {GAME_PORT}. "
            "Stop the other server instance and restart."
        )
        print(_console_safe(msg), file=sys.stderr)
        _append_utf8_log(msg)
        sys.exit(2)
    if require_udp_stub and startup_state.get("udp") is not True:
        msg = (
            f"FATAL: REQUIRE_UDP_STUB=1 and UDP stub failed on {GAME_PORT}. "
            "Stop the other server instance and restart."
        )
        print(_console_safe(msg), file=sys.stderr)
        _append_utf8_log(msg)
        sys.exit(2)

    # Start Admin Web Panel Daemon on port 8080
    try:
        import services.admin_panel as admin_panel
        admin_panel.register_server_refs({
            "player_data": _player_data,
            "mail_state": _mail_state,
            "room_state": _room_state,
            "game_state": _game_state,
            "save_player_data": _save_player_data,
        })
        admin_panel.start_admin_server()
    except Exception as _admin_exc:
        _log_msg = f"[ADMIN] Failed to start admin panel: {_admin_exc}"
        print(_console_safe(_log_msg))
        _append_utf8_log(_log_msg)

    msg = "HTTPS on https://0.0.0.0:%s/ (serving %s)" % (PORT, DIR)
    print(msg)
    _append_utf8_log(msg)
    httpd.serve_forever()


if __name__ == "__main__":
    main()










import threading
import time
import os

def poll_reset_gadgets():
    while True:
        try:
            time.sleep(1)
            if os.path.exists("reset_gadgets.txt"):
                os.remove("reset_gadgets.txt")
                import battle_server
                with battle_server._sessions_lock:
                    for session in battle_server._sessions.values():
                        for p in session.players:
                            for t_uid in list(p.active_scene_tools):
                                del_pkt = battle_server.build_rsp_delete_scene_tool(
                                    scene_tool_unique_id=t_uid,
                                    kind=1,
                                    attacker_bid=p.bid,
                                    effect_type=0
                                )
                                try:
                                    p.sock.sendall(del_pkt)
                                except Exception:
                                    pass
        except Exception as e:
            import traceback; traceback.print_exc()
            pass

threading.Thread(target=poll_reset_gadgets, daemon=True).start()
