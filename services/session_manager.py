import threading
from pathlib import Path

DIR = Path(__file__).resolve().parent.parent

# Canonical shared runtime state used by both the legacy monolith and the
# extracted module-based services. These dictionaries must stay shared.
_UC_LOCK = threading.Lock()
_UC_SESSIONS: dict[str, dict] = {}

_ALI_QR_LOCK = threading.Lock()
_ALI_QR_LOGIN: dict[str, dict] = {}
_ALI_QR_PAY: dict[str, dict] = {}
_ALI_QR_TOKEN_INDEX: dict[str, str] = {}

_HOLO_LOCK = threading.RLock()
_HOLO_PLAYER_TOKENS: dict[str, dict[str, object]] = {}

_GP_LOCK = threading.RLock()
_GP_TOKEN_TO_PLAYER_ID: dict[str, str] = {}

_CHAT_LOCK = threading.RLock()
_CHAT_PLAYER_STATE: dict[str, dict[str, object]] = {}
_CHAT_PENDING_PUSHES: dict[str, list[tuple[str, dict[str, object]]]] = {}
_CHAT_NEXT_MSG_ID = 1
_CHAT_MAX_MESSAGES_PER_SESSION = 200
_CHAT_MAX_PENDING_PUSHES_PER_PLAYER = 256

_CHAT_BOOTSTRAP_LOCK = threading.RLock()
_CHAT_BOOTSTRAP_STATE: dict[str, dict[str, object]] = {}

_ONLINE_LOCK = threading.RLock()
_ONLINE_SAVE_LOCK = threading.RLock()
_ONLINE_STATE_PATH = DIR / "artifacts" / "online_state.json"
_ONLINE_STATE: dict[str, object] = {}

_LOG_LOCK = threading.Lock()
