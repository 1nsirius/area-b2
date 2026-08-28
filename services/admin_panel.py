#!/usr/bin/env python3
"""Area F2 Web Admin & Monitoring Panel Backend Service.

Provides a multi-threaded HTTP server and REST API for:
- Live Server Monitoring & Diagnostics (CPU, RAM, Sockets, Online stats).
- Player Account Management (Inspect, Edit Stats, Grant Currency/Skins/Items, Ban/Kick).
- In-Game Mail Dispatcher with Attachments & Rewards.
- Chat Management & Server Announcements (World/Room Chat).
- Active Match & Custom Room Inspector with force-terminate controls.
- Real-time Console Log Streaming via Server-Sent Events (SSE).
- Server Tuning, Rate Modifiers, and Database Backup/Restore.
"""

from __future__ import annotations

import collections
import html
import http.server
import json
import mimetypes
import os
from pathlib import Path
import re
import secrets
import socket
import sys
import threading
import time
import traceback
import urllib.parse
from typing import Any, Callable

ROOT = Path(__file__).resolve().parents[1]
CONFIG_PATH = ROOT / "config" / "admin_config.json"
WEB_ADMIN_DIR = ROOT / "web_admin"

# Thread-safe session storage
_SESSION_LOCK = threading.Lock()
_ACTIVE_SESSIONS: dict[str, dict[str, Any]] = {}

# Thread-safe log buffer for real-time SSE streaming
_LOG_LOCK = threading.Lock()
_LOG_BUFFER: collections.deque[dict[str, Any]] = collections.deque(maxlen=2000)
_LOG_LISTENERS: set[Callable[[dict[str, Any]], None]] = set()

# Chat history buffer
_CHAT_HISTORY_LOCK = threading.Lock()
_CHAT_HISTORY_BUFFER: collections.deque[dict[str, Any]] = collections.deque(maxlen=500)

_SERVER_START_TIME = time.time()
_ADMIN_SERVER_INSTANCE: http.server.ThreadingHTTPServer | None = None
_ADMIN_THREAD: threading.Thread | None = None

# Reference holders to live server states (set by run_https_443.py)
_LIVE_SERVER_REFS: dict[str, Any] = {}


def register_server_refs(refs: dict[str, Any]) -> None:
    """Register live server references from run_https_443.py."""
    _LIVE_SERVER_REFS.update(refs)


def record_admin_log(message: str, level: str = "INFO", tag: str = "ADMIN") -> None:
    """Record a log entry into the live ring buffer and notify SSE listeners."""
    entry = {
        "id": int(time.time() * 1000000),
        "timestamp": datetime_str(time.time()),
        "time_epoch": time.time(),
        "level": level,
        "tag": tag,
        "message": str(message),
    }
    with _LOG_LOCK:
        _LOG_BUFFER.append(entry)
        listeners = list(_LOG_LISTENERS)

    for listener in listeners:
        try:
            listener(entry)
        except Exception:
            pass


def record_chat_message(channel: str, sender_uid: int, sender_name: str, content: str) -> None:
    """Record a chat message in the global chat history buffer."""
    msg = {
        "id": int(time.time() * 1000),
        "timestamp": datetime_str(time.time()),
        "channel": channel,
        "sender_uid": int(sender_uid),
        "sender_name": str(sender_name),
        "content": str(content),
    }
    with _CHAT_HISTORY_LOCK:
        _CHAT_HISTORY_BUFFER.append(msg)


def datetime_str(epoch: float) -> str:
    """Format epoch timestamp to human readable string."""
    t = time.localtime(epoch)
    return time.strftime("%Y-%m-%d %H:%M:%S", t)


def load_config() -> dict[str, Any]:
    """Load configuration from config/admin_config.json with default fallbacks."""
    default_conf = {
        "admin_panel": {
            "enabled": True,
            "host": "0.0.0.0",
            "port": 8080,
            "admin_password": "admin",
            "session_timeout_seconds": 86400,
            "rate_limit_requests_per_minute": 120,
        },
        "server_tuning": {
            "server_announcement": "Welcome to Area F2 Private Server!",
            "gm_enabled": True,
            "exp_multiplier": 1.0,
            "gold_multiplier": 1.0,
            "maintenance_mode": False,
        },
    }
    if not CONFIG_PATH.exists():
        CONFIG_PATH.parent.mkdir(parents=True, exist_ok=True)
        try:
            CONFIG_PATH.write_text(json.dumps(default_conf, indent=2, ensure_ascii=False), encoding="utf-8")
        except Exception:
            pass
        return default_conf

    try:
        data = json.loads(CONFIG_PATH.read_text(encoding="utf-8"))
        if not isinstance(data, dict):
            return default_conf
        return data
    except Exception as exc:
        record_admin_log(f"Failed to parse admin_config.json: {exc}", level="WARN")
        return default_conf


def save_config(conf: dict[str, Any]) -> bool:
    """Save configuration to config/admin_config.json."""
    try:
        CONFIG_PATH.parent.mkdir(parents=True, exist_ok=True)
        CONFIG_PATH.write_text(json.dumps(conf, indent=2, ensure_ascii=False), encoding="utf-8")
        return True
    except Exception as exc:
        record_admin_log(f"Failed to save admin_config.json: {exc}", level="ERROR")
        return False


def _verify_session(auth_header: str | None, cookie_header: str | None, token_query: str | None = None) -> bool:
    """Verify bearer token, session cookie, or query parameter."""
    token = None
    if token_query:
        token = str(token_query).strip()
    elif auth_header and auth_header.startswith("Bearer "):
        token = auth_header[7:].strip()
    elif cookie_header:
        for part in cookie_header.split(";"):
            part = part.strip()
            if part.startswith("admin_token="):
                token = part[12:].strip()
                break

    if not token:
        return False

    conf = load_config()
    timeout = conf.get("admin_panel", {}).get("session_timeout_seconds", 86400)
    now = time.time()

    with _SESSION_LOCK:
        sess = _ACTIVE_SESSIONS.get(token)
        if not sess:
            return False
        if now - sess["created_at"] > timeout:
            del _ACTIVE_SESSIONS[token]
            return False
        sess["last_active"] = now
        return True


class AdminHTTPRequestHandler(http.server.BaseHTTPRequestHandler):
    """Multi-threaded REST API and Static Asset Request Handler."""

    server_version = "AreaF2Admin/1.0"

    def log_message(self, format: str, *args: Any) -> None:
        """Suppress standard console spew; routes to internal buffer if error."""
        if args and str(args[1]) in ("400", "401", "403", "404", "500"):
            record_admin_log(f"HTTP {args[1]} on {self.command} {self.path}", level="WARN", tag="HTTP")

    def _send_json(self, status_code: int, payload: Any) -> None:
        """Send JSON response with proper CORS headers."""
        data = json.dumps(payload, ensure_ascii=False, default=str).encode("utf-8")
        self.send_response(status_code)
        self.send_header("Content-Type", "application/json; charset=utf-8")
        self.send_header("Content-Length", str(len(data)))
        self.send_header("Access-Control-Allow-Origin", "*")
        self.send_header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")
        self.send_header("Access-Control-Allow-Headers", "Content-Type, Authorization")
        self.end_headers()
        self.wfile.write(data)

    def _send_error(self, status_code: int, error_msg: str) -> None:
        """Send standard JSON error envelope."""
        self._send_json(status_code, {"success": False, "error": str(error_msg)})

    def _send_success(self, data: Any = None, message: str = "ok") -> None:
        """Send standard JSON success envelope."""
        self._send_json(200, {"success": True, "message": message, "data": data})

    def _read_json_body(self) -> dict[str, Any]:
        """Read and decode request body as JSON."""
        content_len = int(self.headers.get("Content-Length", 0))
        if content_len <= 0:
            return {}
        raw = self.rfile.read(content_len)
        if not raw:
            return {}
        return json.loads(raw.decode("utf-8", errors="replace"))

    def do_OPTIONS(self) -> None:
        """Handle CORS preflight requests."""
        self.send_response(204)
        self.send_header("Access-Control-Allow-Origin", "*")
        self.send_header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS")
        self.send_header("Access-Control-Allow-Headers", "Content-Type, Authorization")
        self.end_headers()

    # ─────────────────────────────────────────────────────────────────────────
    # GET Requests Routing
    # ─────────────────────────────────────────────────────────────────────────

    def do_GET(self) -> None:
        url_parts = urllib.parse.urlparse(self.path)
        path = url_parts.path
        query = urllib.parse.parse_qs(url_parts.query)
        token_q = (query.get("token") or [""])[0]

        # Public auth check endpoint
        if path == "/api/v1/auth/me":
            is_authed = _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie"), token_q)
            self._send_json(200, {"authenticated": is_authed})
            return

        # Handle SSE Live Log Stream
        if path == "/api/v1/logs/stream":
            if not _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie"), token_q):
                self._send_error(401, "Unauthorized")
                return
            self._handle_logs_stream()
            return

        # Check authentication for all other /api/v1/* routes
        if path.startswith("/api/v1/"):
            if not _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie"), token_q):
                self._send_error(401, "Unauthorized")
                return

            if path == "/api/v1/system/status":
                self._handle_get_system_status()
            elif path == "/api/v1/system/config":
                self._handle_get_system_config()
            elif path == "/api/v1/players":
                self._handle_get_players(query)
            elif re.match(r"^/api/v1/players/\d+$", path):
                uid = int(path.split("/")[-1])
                self._handle_get_player_detail(uid)
            elif path == "/api/v1/rooms":
                self._handle_get_rooms()
            elif path == "/api/v1/chat/history":
                self._handle_get_chat_history(query)
            elif path == "/api/v1/logs/download":
                self._handle_download_logs()
            elif path == "/api/v1/backup/export":
                self._handle_backup_export()
            else:
                self._send_error(404, f"API route not found: {path}")
            return

        # Serve static web frontend files (SPA)
        self._serve_static_file(path)

    # ─────────────────────────────────────────────────────────────────────────
    # POST / PUT / DELETE Requests Routing
    # ─────────────────────────────────────────────────────────────────────────

    def do_POST(self) -> None:
        url_parts = urllib.parse.urlparse(self.path)
        path = url_parts.path

        if path == "/api/v1/auth/login":
            self._handle_auth_login()
            return

        if not _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie")):
            self._send_error(401, "Unauthorized")
            return

        if path == "/api/v1/system/config":
            self._handle_post_system_config()
        elif path == "/api/v1/players":
            self._handle_post_create_player()
        elif re.match(r"^/api/v1/players/\d+/grant_item$", path):
            uid = int(path.split("/")[4])
            self._handle_post_grant_item(uid)
        elif re.match(r"^/api/v1/players/\d+/unlock_characters$", path):
            uid = int(path.split("/")[4])
            self._handle_post_unlock_characters(uid)
        elif re.match(r"^/api/v1/players/\d+/kick$", path):
            uid = int(path.split("/")[4])
            self._handle_post_kick_player(uid)
        elif re.match(r"^/api/v1/players/\d+/ban$", path):
            uid = int(path.split("/")[4])
            self._handle_post_ban_player(uid)
        elif re.match(r"^/api/v1/rooms/\w+/terminate$", path):
            room_id = path.split("/")[4]
            self._handle_post_terminate_room(room_id)
        elif path == "/api/v1/mail/send":
            self._handle_post_send_mail()
        elif path == "/api/v1/chat/send":
            self._handle_post_send_chat()
        elif path == "/api/v1/backup/import":
            self._handle_backup_import()
        else:
            self._send_error(404, f"API route not found: {path}")

    def do_PUT(self) -> None:
        url_parts = urllib.parse.urlparse(self.path)
        path = url_parts.path

        if not _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie")):
            self._send_error(401, "Unauthorized")
            return

        if re.match(r"^/api/v1/players/\d+$", path):
            uid = int(path.split("/")[-1])
            self._handle_put_update_player(uid)
        else:
            self._send_error(404, f"API route not found: {path}")

    def do_DELETE(self) -> None:
        url_parts = urllib.parse.urlparse(self.path)
        path = url_parts.path

        if not _verify_session(self.headers.get("Authorization"), self.headers.get("Cookie")):
            self._send_error(401, "Unauthorized")
            return

        if re.match(r"^/api/v1/players/\d+$", path):
            uid = int(path.split("/")[-1])
            self._handle_delete_player(uid)
        else:
            self._send_error(404, f"API route not found: {path}")

    # ─────────────────────────────────────────────────────────────────────────
    # REST API Handlers Implementation
    # ─────────────────────────────────────────────────────────────────────────

    def _handle_auth_login(self) -> None:
        try:
            body = self._read_json_body()
            password = str(body.get("password", ""))
            conf = load_config()
            expected = str(conf.get("admin_panel", {}).get("admin_password", "admin"))

            if secrets.compare_digest(password, expected):
                token = secrets.token_hex(24)
                with _SESSION_LOCK:
                    _ACTIVE_SESSIONS[token] = {
                        "created_at": time.time(),
                        "last_active": time.time(),
                    }
                record_admin_log("Admin logged in successfully", level="INFO", tag="AUTH")
                self._send_success({"token": token, "expires_in": 86400}, message="Login successful")
            else:
                record_admin_log("Failed admin login attempt (invalid password)", level="WARN", tag="AUTH")
                self._send_error(401, "Invalid administrator password")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_system_status(self) -> None:
        try:
            uptime = int(time.time() - _SERVER_START_TIME)
            pd_storage = self._get_player_data_storage()
            room_state = _LIVE_SERVER_REFS.get("room_state", {})
            online_count = self._count_online_players()

            # Inspect listening ports
            ports_status = {
                "443": {"name": "HTTPS Gate / Configs", "active": True},
                "12000": {"name": "Lobby Sproto TCP", "active": True},
                "12001": {"name": "Battle Engine UDP/TCP", "active": True},
                "12345": {"name": "EjoySDK Chat TCP", "active": True},
                "8080": {"name": "Web Admin Panel HTTP", "active": True},
            }

            active_rooms_count = 0
            if isinstance(room_state, dict) and room_state.get("room_id"):
                active_rooms_count = 1

            status_payload = {
                "server_version": "Area F2 Reborn v3.0",
                "uptime_seconds": uptime,
                "uptime_formatted": f"{uptime // 3600}h {(uptime % 3600) // 60}m {uptime % 60}s",
                "total_accounts": len(pd_storage),
                "online_players": online_count,
                "active_rooms": active_rooms_count,
                "ports": ports_status,
                "memory_info": self._get_process_memory_info(),
            }
            self._send_success(status_payload)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_system_config(self) -> None:
        conf = load_config()
        self._send_success(conf)

    def _handle_post_system_config(self) -> None:
        try:
            body = self._read_json_body()
            conf = load_config()
            if "server_tuning" in body:
                conf["server_tuning"].update(body["server_tuning"])
            if "admin_panel" in body:
                admin_updates = body["admin_panel"]
                if "admin_password" in admin_updates and admin_updates["admin_password"]:
                    conf["admin_panel"]["admin_password"] = str(admin_updates["admin_password"])
                if "session_timeout_seconds" in admin_updates:
                    conf["admin_panel"]["session_timeout_seconds"] = int(admin_updates["session_timeout_seconds"])

            if save_config(conf):
                record_admin_log("Server configuration updated via web panel", level="INFO", tag="CONFIG")
                self._send_success(conf, message="Configuration saved")
            else:
                self._send_error(500, "Failed to write configuration to disk")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_players(self, query: dict[str, list[str]]) -> None:
        try:
            search_query = query.get("q", [""])[0].strip().lower()
            status_filter = query.get("status", ["all"])[0].strip().lower()

            pd_storage = self._get_player_data_storage()
            room_players = _LIVE_SERVER_REFS.get("room_state", {}).get("players", {})

            result = []
            for uid_s, p in pd_storage.items():
                if not isinstance(p, dict):
                    continue
                try:
                    uid = int(p.get("uid") or uid_s)
                except (ValueError, TypeError):
                    continue

                name = str(p.get("name", f"Player{uid}"))
                level = int(p.get("level", 1) or 1)
                gold = int(p.get("gold", 0) or 0)
                diamond = int(p.get("diamond", 0) or 0)
                rank_score = int(p.get("rank_score", 1000) or 1000)
                is_online = self._check_is_online(uid)
                is_banned = bool(p.get("is_banned", False))
                is_in_room = str(uid) in room_players

                status = "offline"
                if is_banned:
                    status = "banned"
                elif is_in_room:
                    status = "in_match"
                elif is_online:
                    status = "online"

                # Filter checks
                if status_filter != "all" and status != status_filter:
                    continue
                if search_query:
                    if (search_query not in str(uid)) and (search_query not in name.lower()):
                        continue

                result.append({
                    "uid": uid,
                    "name": name,
                    "level": level,
                    "gold": gold,
                    "diamond": diamond,
                    "rank_score": rank_score,
                    "status": status,
                    "is_online": is_online,
                    "is_banned": is_banned,
                    "last_login": p.get("last_login_time", "N/A"),
                })

            # Sort by online status then UID
            result.sort(key=lambda x: (0 if x["is_online"] else 1, x["uid"]))
            self._send_success(result)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_player_detail(self, uid: int) -> None:
        try:
            pd_storage = self._get_player_data_storage()
            p = pd_storage.get(str(uid))
            if not p:
                self._send_error(404, f"Player {uid} not found")
                return

            detail = dict(p)
            detail["uid"] = uid
            detail["is_online"] = self._check_is_online(uid)
            self._send_success(detail)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_put_update_player(self, uid: int) -> None:
        try:
            body = self._read_json_body()
            if not body or not isinstance(body, dict):
                self._send_error(400, "Invalid JSON payload")
                return

            pd_storage = self._get_player_data_storage()
            p = pd_storage.get(str(uid))
            if not p:
                self._send_error(404, f"Player {uid} not found")
                return

            # Apply updatable fields
            updatable = [
                "name", "level", "exp", "gold", "diamond", "rank_score",
                "career_max_rank", "king_emblem", "rank_protect_score",
                "motto", "icon", "icon_frame", "show_character_id",
                "battle_kill", "battle_dead", "battle_assist", "battle_score",
                "kills", "deaths", "assists", "battle_times", "total_matches",
                "win_times", "wins", "mvp_count", "headshots",
                "rank_kills", "rank_deaths", "rank_battles", "rank_wins",
                "normal_kills", "normal_deaths", "normal_battles", "normal_wins"
            ]
            int_keys = {
                "level", "exp", "gold", "diamond", "rank_score", "career_max_rank",
                "king_emblem", "rank_protect_score", "icon", "icon_frame",
                "show_character_id", "battle_kill", "battle_dead", "battle_assist",
                "battle_score", "kills", "deaths", "assists", "battle_times",
                "total_matches", "win_times", "wins", "mvp_count", "headshots",
                "rank_kills", "rank_deaths", "rank_battles", "rank_wins",
                "normal_kills", "normal_deaths", "normal_battles", "normal_wins"
            }
            for key in updatable:
                if key in body:
                    val = body[key]
                    if key in int_keys:
                        try:
                            p[key] = int(val)
                        except (ValueError, TypeError):
                            pass
                    else:
                        p[key] = str(val)

            # Synchronize statistics aliases
            if "battle_kill" in p: p["kills"] = p["battle_kill"]
            elif "kills" in p: p["battle_kill"] = p["kills"]

            if "battle_dead" in p: p["deaths"] = p["battle_dead"]
            elif "deaths" in p: p["battle_dead"] = p["deaths"]

            if "battle_assist" in p: p["assists"] = p["battle_assist"]
            elif "assists" in p: p["battle_assist"] = p["assists"]

            if "battle_times" in p: p["total_matches"] = p["battle_times"]
            elif "total_matches" in p: p["battle_times"] = p["total_matches"]

            if "win_times" in p: p["wins"] = p["win_times"]
            elif "wins" in p: p["win_times"] = p["wins"]

            if "career_max_rank" not in p or p["career_max_rank"] < p.get("rank_score", 0):
                p["career_max_rank"] = p.get("rank_score", 0)

            # Sync in memory with live _player_data
            live_pd = _LIVE_SERVER_REFS.get("player_data")
            if isinstance(live_pd, dict) and str(live_pd.get("uid", 1000001)) == str(uid):
                for k in updatable:
                    if k in p:
                        live_pd[k] = p[k]

            # Sync with services.db (Single Source of Truth)
            try:
                import services.db as db
                with db._ONLINE_LOCK:
                    db_profile = db._ONLINE_STATE.setdefault("profiles", {}).setdefault(str(uid), {})
                    db_profile.update(p)
                    if "name" in p:
                        db._ONLINE_STATE.setdefault("account_to_uid", {})[str(p["name"])] = int(uid)
                db._save_online_state()
            except Exception as _sync_exc:
                record_admin_log(f"DB sync warning: {_sync_exc}", level="WARN", tag="DB")

            self._save_all_player_data()

            record_admin_log(f"Profile updated for UID={uid} ({p.get('name')})", level="INFO", tag="PLAYER")
            self._send_success(p, message=f"Player {uid} updated successfully")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_create_player(self) -> None:
        try:
            body = self._read_json_body()
            pd_storage = self._get_player_data_storage()

            req_uid = body.get("uid")
            if req_uid:
                uid = int(req_uid)
            else:
                existing_uids = [int(u) for u in pd_storage.keys() if u.isdigit()]
                uid = max(existing_uids, default=1000000) + 1

            if str(uid) in pd_storage:
                self._send_error(400, f"Account with UID {uid} already exists")
                return

            name = str(body.get("name", f"Player{uid}")).strip()
            gold = int(body.get("gold", 50000))
            diamond = int(body.get("diamond", 1000))
            level = int(body.get("level", 1))

            new_profile = {
                "uid": uid,
                "name": name,
                "level": level,
                "exp": 0,
                "gold": gold,
                "diamond": diamond,
                "rank_score": 1000,
                "icon": 0,
                "icon_frame": 0,
                "motto": "Area F2 Player",
                "created_time": datetime_str(time.time()),
                "is_banned": False,
            }
            pd_storage[str(uid)] = new_profile
            self._save_all_player_data()

            # Sync with services.db (Single Source of Truth)
            try:
                import services.db as db
                with db._ONLINE_LOCK:
                    db._ONLINE_STATE.setdefault("profiles", {})[str(uid)] = db._online_profile_from_player_data(new_profile)
                    db._ONLINE_STATE.setdefault("account_to_uid", {})[name] = uid
                db._save_online_state()
            except Exception as _sync_exc:
                record_admin_log(f"DB sync warning: {_sync_exc}", level="WARN", tag="DB")

            record_admin_log(f"New player created UID={uid} Name={name!r}", level="INFO", tag="PLAYER")
            self._send_success(new_profile, message=f"Player {uid} created successfully")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_delete_player(self, uid: int) -> None:
        try:
            pd_storage = self._get_player_data_storage()
            if str(uid) not in pd_storage:
                self._send_error(404, f"Player {uid} not found")
                return

            del pd_storage[str(uid)]
            self._save_all_player_data()

            # Sync with services.db
            try:
                import services.db as db
                with db._ONLINE_LOCK:
                    profiles = db._ONLINE_STATE.get("profiles", {})
                    if str(uid) in profiles:
                        del profiles[str(uid)]
                db._save_online_state()
            except Exception:
                pass

            record_admin_log(f"Player deleted UID={uid}", level="WARN", tag="PLAYER")
            self._send_success(message=f"Player {uid} deleted")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_grant_item(self, uid: int) -> None:
        try:
            body = self._read_json_body()
            pd_storage = self._get_player_data_storage()
            p = pd_storage.get(str(uid))
            if not p:
                self._send_error(404, f"Player {uid} not found")
                return

            item_type = str(body.get("type", "skin")).lower()
            item_id = int(body.get("id", 0))
            count = max(1, int(body.get("count", 1)))

            if item_type == "skin":
                skins = p.get("skins")
                if not isinstance(skins, list):
                    skins = []
                    p["skins"] = skins
                if item_id not in skins:
                    skins.append(item_id)
            elif item_type == "gold":
                p["gold"] = int(p.get("gold", 0)) + count
            elif item_type == "diamond":
                p["diamond"] = int(p.get("diamond", 0)) + count

            self._save_all_player_data()
            record_admin_log(f"Granted {item_type} ID={item_id} Count={count} to UID={uid}", level="INFO", tag="ITEM")
            self._send_success(message=f"Item granted to UID={uid}")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_unlock_characters(self, uid: int) -> None:
        try:
            pd_storage = self._get_player_data_storage()
            p = pd_storage.get(str(uid))
            if not p:
                self._send_error(404, f"Player {uid} not found")
                return

            # Unlock all known operators
            all_characters = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110]
            hero_bag = p.get("hero_bag")
            if not isinstance(hero_bag, list):
                hero_bag = []
                p["hero_bag"] = hero_bag

            for cid in all_characters:
                if cid not in hero_bag:
                    hero_bag.append(cid)

            self._save_all_player_data()
            record_admin_log(f"Unlocked all characters for UID={uid}", level="INFO", tag="PLAYER")
            self._send_success(message=f"All characters unlocked for UID={uid}")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_kick_player(self, uid: int) -> None:
        try:
            room_state = _LIVE_SERVER_REFS.get("room_state", {})
            if isinstance(room_state, dict) and "players" in room_state:
                if str(uid) in room_state["players"]:
                    del room_state["players"][str(uid)]
            record_admin_log(f"Player kicked UID={uid}", level="WARN", tag="MOD")
            self._send_success(message=f"Player {uid} kicked")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_ban_player(self, uid: int) -> None:
        try:
            pd_storage = self._get_player_data_storage()
            p = pd_storage.get(str(uid))
            if not p:
                self._send_error(404, f"Player {uid} not found")
                return

            curr_banned = bool(p.get("is_banned", False))
            p["is_banned"] = not curr_banned
            self._save_all_player_data()

            action_str = "Banned" if p["is_banned"] else "Unbanned"
            record_admin_log(f"Player {action_str} UID={uid}", level="WARN", tag="MOD")
            self._send_success({"is_banned": p["is_banned"]}, message=f"Player {uid} {action_str.lower()}")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_rooms(self) -> None:
        try:
            room_state = _LIVE_SERVER_REFS.get("room_state", {})
            game_state = _LIVE_SERVER_REFS.get("game_state", {})

            rooms = []

            # 1. Custom Multiplayer Rooms
            if isinstance(room_state, dict) and room_state.get("room_id"):
                r_id = room_state.get("room_id")
                players = []
                for p_uid_s, p_entry in room_state.get("players", {}).items():
                    players.append({
                        "uid": int(p_uid_s),
                        "name": p_entry.get("name", f"Player{p_uid_s}"),
                        "camp": int(p_entry.get("camp", 1)),
                        "character_id": int(p_entry.get("character_id", 1)),
                        "is_ready": bool(p_entry.get("is_ready", False)),
                    })
                rooms.append({
                    "room_id": f"CustomRoom-{r_id}",
                    "host_uid": room_state.get("host_uid", 1000001),
                    "map_id": room_state.get("map_id", 101),
                    "mode_id": room_state.get("mode_id", 4),
                    "status": "В 3D-Матче" if game_state.get("in_battle") else "Предбой / Лобби",
                    "player_count": len(players),
                    "players": players,
                })

            # 2. Training Mode / Single-Player Matches
            elif isinstance(game_state, dict) and (game_state.get("in_battle") or game_state.get("prebattle_room_started")):
                mode_id = int(game_state.get("mode_id", 3))
                char_id = int(game_state.get("character_id", 1))
                char_names = {
                    1: "Volcan", 2: "Magnet", 3: "Boulder", 4: "Flash", 5: "Jammer",
                    6: "Recon", 7: "Hawkeye", 8: "Wildfire", 9: "Tiger", 10: "Silence",
                    101: "Fortress", 102: "Maestro", 103: "Cobra", 104: "Bandit", 105: "Caveira"
                }
                char_label = char_names.get(char_id, f"Агент {char_id}")
                pd = self._get_player_data_storage()
                player_entry = pd.get("1000001", {})
                player_name = str(player_entry.get("name", "1nsirius")) if isinstance(player_entry, dict) else "1nsirius"
                player_uid = int(player_entry.get("uid", 1000001)) if isinstance(player_entry, dict) else 1000001
                status_label = "В 3D-Матче" if game_state.get("in_battle") else "Выбор экипировки (Предбой)"
                battle_id = game_state.get("battle_id", 1)

                rooms.append({
                    "room_id": f"Training-{battle_id}",
                    "host_uid": player_uid,
                    "map_id": int(game_state.get("map_id", 101)),
                    "mode_id": mode_id,
                    "status": status_label,
                    "player_count": 1,
                    "players": [{
                        "uid": player_uid,
                        "name": f"{player_name} ({char_label})",
                        "camp": int(game_state.get("camp", 1)),
                        "character_id": char_id,
                        "is_ready": True,
                    }],
                })

            # 3. Active 3D Battle Sessions from battle_server
            import sys
            battle_mod = sys.modules.get("battle_server")
            if battle_mod and hasattr(battle_mod, "_sessions"):
                with getattr(battle_mod, "_sessions_lock", threading.Lock()):
                    for b_id, session in getattr(battle_mod, "_sessions", {}).items():
                        session_room_id = f"Battle3D-{b_id}"
                        if not any(r["room_id"] == session_room_id for r in rooms):
                            s_players = []
                            for p in getattr(session, "players", []):
                                s_players.append({
                                    "uid": getattr(p, "uid", 0),
                                    "name": f"Player {getattr(p, 'bid', 0)}",
                                    "camp": getattr(p, "team_id", 1),
                                    "character_id": getattr(p, "character_id", 1),
                                    "is_ready": True,
                                })
                            rooms.append({
                                "room_id": session_room_id,
                                "host_uid": getattr(session, "host_uid", 1000001),
                                "map_id": 101,
                                "mode_id": 3,
                                "status": "В 3D-Матче",
                                "player_count": len(s_players),
                                "players": s_players,
                            })

            self._send_success(rooms)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_terminate_room(self, room_id: str) -> None:
        try:
            room_state = _LIVE_SERVER_REFS.get("room_state", {})
            if isinstance(room_state, dict):
                room_state.clear()
            record_admin_log(f"Terminated room ID={room_id}", level="WARN", tag="ROOM")
            self._send_success(message=f"Room {room_id} terminated")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_send_mail(self) -> None:
        try:
            body = self._read_json_body()
            target_uid_raw = str(body.get("target_uid", "all")).strip()
            title = str(body.get("title", "Server Gift")).strip()
            content = str(body.get("content", "Enjoy your rewards!")).strip()
            sender = str(body.get("sender", "System")).strip()
            expire_days = max(1, int(body.get("expire_days", 30)))
            rewards = body.get("rewards", [])

            now_ts = int(time.time())
            expire_ts = now_ts + (expire_days * 86400)
            mail_id = int(time.time() * 1000) % 2147483647

            mail_entry = {
                "id": mail_id,
                "title": title,
                "content": content,
                "sender": sender,
                "send_time": now_ts,
                "expire_time": expire_ts,
                "status": 0,
                "rewards": rewards,
            }

            mail_state = _LIVE_SERVER_REFS.get("mail_state")
            pd_storage = self._get_player_data_storage()

            if target_uid_raw.lower() == "all":
                target_uids = list(pd_storage.keys())
            else:
                target_uids = [target_uid_raw]

            sent_count = 0
            if mail_state and hasattr(mail_state, "storage"):
                for uid_s in target_uids:
                    if uid_s not in mail_state.storage:
                        mail_state.storage[uid_s] = {"mails": []}
                    mail_list = mail_state.storage[uid_s].get("mails")
                    if not isinstance(mail_list, list):
                        mail_list = []
                        mail_state.storage[uid_s]["mails"] = mail_list
                    mail_list.append(dict(mail_entry))
                    sent_count += 1
                self._save_all_player_data()

            record_admin_log(f"Dispatched in-game mail '{title}' to {sent_count} player(s)", level="INFO", tag="MAIL")
            self._send_success({"sent_count": sent_count, "mail_id": mail_id}, message=f"Mail sent to {sent_count} player(s)")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_post_send_chat(self) -> None:
        try:
            body = self._read_json_body()
            content = str(body.get("content", "")).strip()
            sender_name = str(body.get("sender_name", "SERVER")).strip()
            sender_uid = int(body.get("sender_uid", 0))
            channel = str(body.get("channel", "group_world")).strip()

            if not content:
                self._send_error(400, "Content cannot be empty")
                return

            # Broadcast to real in-game chat engine (port 12345 TCP)
            try:
                import services.chat as chat_service
                chat_service.broadcast_admin_chat_message(
                    content_str=content,
                    sender_name=sender_name,
                    sender_uid=sender_uid,
                    session_id=channel,
                )
            except Exception as e:
                record_admin_log(f"Chat broadcast error: {e}", level="WARN", tag="CHAT")

            record_chat_message(channel, sender_uid, sender_name, content)
            record_admin_log(f"Broadcast chat message: [{sender_name}]: {content}", level="INFO", tag="CHAT")
            self._send_success(message="Message broadcasted to in-game chat")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_get_chat_history(self, query: dict[str, list[str]]) -> None:
        with _CHAT_HISTORY_LOCK:
            history = list(_CHAT_HISTORY_BUFFER)
        self._send_success(history)

    def _handle_download_logs(self) -> None:
        try:
            log_file = ROOT / "server.log"
            content = b""
            if log_file.exists():
                content = log_file.read_bytes()
            else:
                with _LOG_LOCK:
                    lines = [f"[{e['timestamp']}] [{e['level']}] [{e['tag']}] {e['message']}\n" for e in _LOG_BUFFER]
                content = "".join(lines).encode("utf-8")

            self.send_response(200)
            self.send_header("Content-Type", "text/plain; charset=utf-8")
            self.send_header("Content-Disposition", 'attachment; filename="server_console.log"')
            self.send_header("Content-Length", str(len(content)))
            self.end_headers()
            self.wfile.write(content)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_backup_export(self) -> None:
        try:
            pd_storage = self._get_player_data_storage()
            backup = {
                "backup_version": 1,
                "timestamp": datetime_str(time.time()),
                "player_data": pd_storage,
            }
            data = json.dumps(backup, indent=2, ensure_ascii=False).encode("utf-8")
            self.send_response(200)
            self.send_header("Content-Type", "application/json; charset=utf-8")
            self.send_header("Content-Disposition", f'attachment; filename="areaf2_backup_{int(time.time())}.json"')
            self.send_header("Content-Length", str(len(data)))
            self.end_headers()
            self.wfile.write(data)
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_backup_import(self) -> None:
        try:
            body = self._read_json_body()
            if "player_data" not in body or not isinstance(body["player_data"], dict):
                self._send_error(400, "Invalid backup format: 'player_data' object required")
                return

            pd_storage = self._get_player_data_storage()
            pd_storage.clear()
            pd_storage.update(body["player_data"])
            self._save_all_player_data()
            record_admin_log("Restored player database from backup", level="WARN", tag="BACKUP")
            self._send_success(message="Database restored from backup successfully")
        except Exception as exc:
            self._send_error(500, str(exc))

    def _handle_logs_stream(self) -> None:
        """Server-Sent Events (SSE) log stream handler."""
        self.send_response(200)
        self.send_header("Content-Type", "text/event-stream")
        self.send_header("Cache-Control", "no-cache")
        self.send_header("Connection", "keep-alive")
        self.send_header("Access-Control-Allow-Origin", "*")
        self.end_headers()

        queue: collections.deque[dict[str, Any]] = collections.deque()
        q_event = threading.Event()

        def on_new_log(entry: dict[str, Any]) -> None:
            queue.append(entry)
            q_event.set()

        # Send initial recent buffer
        with _LOG_LOCK:
            initial = list(_LOG_BUFFER)[-100:]
            _LOG_LISTENERS.add(on_new_log)

        try:
            for entry in initial:
                msg = f"data: {json.dumps(entry, ensure_ascii=False)}\n\n"
                self.wfile.write(msg.encode("utf-8"))
            self.wfile.flush()

            while True:
                q_event.wait(timeout=1.0)
                q_event.clear()
                while queue:
                    entry = queue.popleft()
                    msg = f"data: {json.dumps(entry, ensure_ascii=False)}\n\n"
                    self.wfile.write(msg.encode("utf-8"))
                self.wfile.flush()
        except (BrokenPipeError, ConnectionResetError):
            pass
        finally:
            with _LOG_LOCK:
                _LOG_LISTENERS.discard(on_new_log)

    # ─────────────────────────────────────────────────────────────────────────
    # Static Assets & SPA Delivery
    # ─────────────────────────────────────────────────────────────────────────

    def _serve_static_file(self, path: str) -> None:
        clean_path = path.lstrip("/")
        if not clean_path or clean_path == "admin":
            clean_path = "index.html"

        file_path = (WEB_ADMIN_DIR / clean_path).resolve()
        # Security: Prevent directory traversal
        if not str(file_path).startswith(str(WEB_ADMIN_DIR.resolve())):
            file_path = WEB_ADMIN_DIR / "index.html"

        if not file_path.exists() or file_path.is_dir():
            file_path = WEB_ADMIN_DIR / "index.html"

        if not file_path.exists():
            self._send_error(404, "Frontend files not found")
            return

        mime_type, _ = mimetypes.guess_type(str(file_path))
        if not mime_type:
            mime_type = "text/plain"

        try:
            content = file_path.read_bytes()
            self.send_response(200)
            self.send_header("Content-Type", f"{mime_type}; charset=utf-8")
            self.send_header("Content-Length", str(len(content)))
            self.end_headers()
            self.wfile.write(content)
        except Exception as exc:
            self._send_error(500, str(exc))

    # ─────────────────────────────────────────────────────────────────────────
    # Helper Methods
    # ─────────────────────────────────────────────────────────────────────────

    def _get_player_data_storage(self) -> dict[str, Any]:
        storage: dict[str, Any] = {}
        try:
            import services.db as db
            with db._ONLINE_LOCK:
                profiles = db._ONLINE_STATE.get("profiles", {})
                for uid_s, prof in profiles.items():
                    if isinstance(prof, dict):
                        storage[str(uid_s)] = dict(prof)
        except Exception:
            pass

        pd = _LIVE_SERVER_REFS.get("player_data")
        if pd and hasattr(pd, "storage") and isinstance(pd.storage, dict):
            for k, v in pd.storage.items():
                if str(k) not in storage:
                    storage[str(k)] = v
                elif isinstance(v, dict):
                    storage[str(k)].update(v)
        elif isinstance(pd, dict):
            if "uid" in pd or "name" in pd:
                uid_str = str(pd.get("uid", "1000001"))
                if uid_str not in storage:
                    storage[uid_str] = dict(pd)
                else:
                    storage[uid_str].update(pd)
        return storage

    def _save_all_player_data(self) -> None:
        try:
            import services.db as db
            db._save_online_state()
        except Exception:
            pass
        save_fn = _LIVE_SERVER_REFS.get("save_player_data")
        if callable(save_fn):
            try:
                save_fn()
            except Exception:
                pass

    def _check_is_online(self, uid: int) -> bool:
        chat_mod = sys.modules.get("services.chat")
        if chat_mod and hasattr(chat_mod, "is_player_online"):
            return bool(chat_mod.is_player_online(uid))
        return False

    def _count_online_players(self) -> int:
        pd_storage = self._get_player_data_storage()
        count = 0
        for u_s in pd_storage.keys():
            if u_s.isdigit() and self._check_is_online(int(u_s)):
                count += 1
        return count

    def _get_process_memory_info(self) -> dict[str, Any]:
        import psutil  # type: ignore
        try:
            proc = psutil.Process()
            mem = proc.memory_info()
            return {
                "rss_mb": round(mem.rss / (1024 * 1024), 2),
                "cpu_percent": proc.cpu_percent(interval=0.0),
            }
        except Exception:
            return {"rss_mb": 0.0, "cpu_percent": 0.0}


def start_admin_server() -> None:
    """Start the multi-threaded Admin Web Server daemon."""
    global _ADMIN_SERVER_INSTANCE, _ADMIN_THREAD

    conf = load_config()
    admin_conf = conf.get("admin_panel", {})
    if not admin_conf.get("enabled", True):
        record_admin_log("Admin panel is disabled in configuration", level="INFO")
        return

    host = str(admin_conf.get("host", "0.0.0.0"))
    port = int(admin_conf.get("port", 8080))

    try:
        http.server.ThreadingHTTPServer.allow_reuse_address = True
        server = http.server.ThreadingHTTPServer((host, port), AdminHTTPRequestHandler)
        _ADMIN_SERVER_INSTANCE = server

        def _runner():
            server.serve_forever()

        t = threading.Thread(target=_runner, name="AdminWebPanel", daemon=True)
        t.start()
        _ADMIN_THREAD = t

        record_admin_log(f"Admin Web Panel active at http://{host}:{port}/", level="INFO", tag="BOOT")
        print(f"\033[92m[ADMIN]\033[0m Web Admin Panel active at http://127.0.0.1:{port}/")
    except Exception as exc:
        record_admin_log(f"Failed to start Admin Web Panel on port {port}: {exc}", level="ERROR", tag="BOOT")
        print(f"\033[91m[ADMIN ERROR]\033[0m Could not start Admin Panel on port {port}: {exc}")


if __name__ == "__main__":
    start_admin_server()
    while True:
        time.sleep(1)
