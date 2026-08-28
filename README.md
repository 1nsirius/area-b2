# Area F2 Server (Reborn)

Standalone Python-based game and lobby server for **Area F2**.

## 🚀 Features

- **HTTPS API Server (Port 443)**: Gangplank authentication (`/gp/p10470/v2/login`), Holo API, announcements, version check, AliPay & QR mock flows.
- **TCP Sproto Lobby Server (Port 12345)**: Matchmaking, chat rooms, team management, player profile inspection, character & weapon loadouts, store purchases, bags, mail claiming.
- **Missions & Events System**: 7-Day Novice Sign-in rewards, Daily Tasks, and Level 1–60 Milestone Progress rewards.
- **Battle Server**: Real-time battle simulation, UDP/TCP state synchronization, destruction and operator abilities.
- **Web Admin Panel (Port 8080)**: Web-based player profile editor, inventory manager, currency editor, online user list.
- **SQLite Persistence**: Clean SQLite database storing profiles, social graph, friends, accounts, and server state.

---

## 📦 Requirements

- **Python 3.10+** (Python 3.11 recommended)
- `cryptography` library:
  ```bash
  pip install -r requirements.txt
  ```

---

## 🛠️ Quick Start

### Windows
1. Open terminal as Administrator (needed for binding port 443 & firewall rules).
2. Run:
   ```cmd
   start_server.bat
   ```
   Or directly:
   ```cmd
   python run_https_443.py
   ```

### Linux / macOS
```bash
chmod +x start_server.sh
sudo ./start_server.sh
```

---

## 🌐 Web Admin Panel

Once the server is running, navigate to:
**http://localhost:8080/** (or `http://<SERVER_IP>:8080/`)

Features:
- View all registered players and real-time statistics.
- Edit Player Level, EXP, Gold, Diamonds, Rank Score, Tiers.
- Search and modify user inventories and unlocked characters.

---

## 📁 Directory Structure

```text
├── run_https_443.py                  # Main Server Orchestrator (HTTPS + TCP Lobby)
├── battle_server.py                  # Battle Server (Match gameplay & combat sync)
├── battle_parser_framework.py        # Battle packet parser framework
├── battle_parser_registry_autogen.py # Packet registry
├── battle_payload_decoders_autogen.py# Payload decoders
├── database.py                       # SQLite database interface
├── sproto_util.py                    # Sproto protocol serializer/deserializer
├── log_system.py                     # Logging subsystem
├── cert.pem / key.pem                # SSL Certificates for HTTPS
├── requirements.txt                  # Python dependencies
├── start_server.bat / .sh            # Startup launcher scripts
├── certs/                            # System certificates (including Android 910e88fa.0)
├── routers/                          # HTTP Route Handlers (auth, friends, holo, misc)
├── services/                         # Core business logic (chat, session manager, db)
├── web_admin/                        # Web Admin Panel UI frontend
├── decompiled_cs/                    # C# Sproto packet definitions
├── decrypted_lua/                    # Game table configurations (store, tasks, items)
└── artifacts/                        # SQLite Database & state files
    ├── database.db                   # Clean SQLite database
    └── online_state.json             # Runtime state cache
```

---

## 🔒 Certificates

The server uses self-signed SSL certificates (`cert.pem`, `key.pem`).
For Android devices / emulators:
- Install `certs/910e88fa.0` into the system certificate store (`/system/etc/security/cacerts/`), or
- Use a patched APK that trusts user certificates.
