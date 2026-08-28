import sqlite3
import json
import logging
from pathlib import Path

logger = logging.getLogger("areaf2_server.db")
logger.setLevel(logging.INFO)

DB_PATH = Path(__file__).resolve().parent / "artifacts" / "database.db"
JSON_PATH = Path(__file__).resolve().parent / "artifacts" / "online_state.json"

def get_connection():
    conn = sqlite3.connect(DB_PATH, check_same_thread=False)
    conn.row_factory = sqlite3.Row
    return conn

def init_db():
    DB_PATH.parent.mkdir(parents=True, exist_ok=True)
    conn = get_connection()
    conn.execute("PRAGMA journal_mode=WAL;")
    
    with conn:
        conn.execute("""
            CREATE TABLE IF NOT EXISTS profiles (
                uid INTEGER PRIMARY KEY,
                name TEXT,
                level INTEGER,
                exp INTEGER,
                icon INTEGER,
                icon_url TEXT,
                icon_frame INTEGER,
                time_zone INTEGER,
                current_season_id INTEGER,
                create_time INTEGER,
                gold INTEGER,
                diamond INTEGER,
                rank_score INTEGER,
                show_character_id INTEGER,
                update_time INTEGER
            )
        """)
        
        conn.execute("""
            CREATE TABLE IF NOT EXISTS friends (
                uid INTEGER,
                friend_uid INTEGER,
                PRIMARY KEY (uid, friend_uid)
            )
        """)
        
        conn.execute("""
            CREATE TABLE IF NOT EXISTS friend_applies (
                apply_id INTEGER PRIMARY KEY,
                uid INTEGER,
                applicant_uid INTEGER,
                state INTEGER,
                content TEXT,
                create_time INTEGER,
                last_index_time INTEGER
            )
        """)
        
        conn.execute("""
            CREATE TABLE IF NOT EXISTS server_state (
                key TEXT PRIMARY KEY,
                value_int INTEGER,
                value_text TEXT
            )
        """)
        
        conn.execute("""
            CREATE TABLE IF NOT EXISTS accounts (
                account TEXT PRIMARY KEY,
                uid INTEGER
            )
        """)
    
    _migrate_from_json_if_needed(conn)
    return conn

def _migrate_from_json_if_needed(conn):
    # Check if we already have profiles
    cur = conn.execute("SELECT COUNT(*) as c FROM profiles")
    if cur.fetchone()['c'] > 0:
        return  # Already migrated or has data
        
    if not JSON_PATH.exists():
        return
        
    logger.info("Migrating data from JSON to SQLite...")
    try:
        with open(JSON_PATH, "r", encoding="utf-8") as f:
            state = json.load(f)
            
        profiles = state.get("profiles", {})
        with conn:
            for uid_str, p in profiles.items():
                conn.execute("""
                    INSERT INTO profiles (
                        uid, name, level, exp, icon, icon_url, icon_frame,
                        time_zone, current_season_id, create_time, gold, diamond,
                        rank_score, show_character_id, update_time
                    ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    int(p.get("uid", uid_str)),
                    p.get("name", ""),
                    p.get("level", 1),
                    p.get("exp", 0),
                    p.get("icon", 0),
                    p.get("icon_url", ""),
                    p.get("icon_frame", 0),
                    p.get("time_zone", 0),
                    p.get("current_season_id", 1),
                    p.get("create_time", 0),
                    p.get("gold", 0),
                    p.get("diamond", 0),
                    p.get("rank_score", 0),
                    p.get("show_character_id", 1),
                    p.get("update_time", 0)
                ))
            
            friends = state.get("friends", {})
            for uid_str, friend_list in friends.items():
                uid = int(uid_str)
                for friend_uid in friend_list:
                    conn.execute("INSERT OR IGNORE INTO friends (uid, friend_uid) VALUES (?, ?)", (uid, int(friend_uid)))
            
            applies = state.get("friend_applies", {})
            for uid_str, apply_list in applies.items():
                uid = int(uid_str)
                for applicant_uid in apply_list:
                    conn.execute("INSERT OR IGNORE INTO friend_applies (uid, applicant_uid) VALUES (?, ?)", (uid, int(applicant_uid)))
                    
            next_apply_id = state.get("next_apply_id", 10)
            conn.execute("INSERT OR REPLACE INTO server_state (key, value_int) VALUES ('next_apply_id', ?)", (next_apply_id,))
            
            account_to_uid = state.get("account_to_uid", {})
            for account, uid_val in account_to_uid.items():
                conn.execute("INSERT OR IGNORE INTO accounts (account, uid) VALUES (?, ?)", (account, int(uid_val)))
            
        logger.info(f"[DATABASE] Migrated {len(profiles)} profiles from JSON to SQLite.")
        print(f"[DATABASE] Migrated {len(profiles)} profiles from JSON to SQLite.")
    except Exception as e:
        logger.error(f"Migration failed: {e}")
        print(f"Migration failed: {e}")

# Global connection for ease of use
db_conn = None

def get_db():
    global db_conn
    if db_conn is None:
        db_conn = init_db()
    return db_conn

# --- DAO Methods ---

def get_profile(uid: int) -> dict:
    conn = get_db()
    row = conn.execute("SELECT * FROM profiles WHERE uid = ?", (uid,)).fetchone()
    if row:
        return dict(row)
    return None

def create_profile(profile_dict: dict):
    conn = get_db()
    with conn:
        conn.execute("""
            INSERT INTO profiles (
                uid, name, level, exp, icon, icon_url, icon_frame,
                time_zone, current_season_id, create_time, gold, diamond,
                rank_score, show_character_id, update_time
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
        """, (
            profile_dict["uid"], profile_dict.get("name", ""), profile_dict.get("level", 1),
            profile_dict.get("exp", 0), profile_dict.get("icon", 0), profile_dict.get("icon_url", ""),
            profile_dict.get("icon_frame", 0), profile_dict.get("time_zone", 0),
            profile_dict.get("current_season_id", 1), profile_dict.get("create_time", 0),
            profile_dict.get("gold", 0), profile_dict.get("diamond", 0), profile_dict.get("rank_score", 0),
            profile_dict.get("show_character_id", 1), profile_dict.get("update_time", 0)
        ))

def update_profile(uid: int, **kwargs):
    if not kwargs:
        return
    conn = get_db()
    fields = []
    values = []
    for k, v in kwargs.items():
        fields.append(f"{k} = ?")
        values.append(v)
    values.append(uid)
    
    query = f"UPDATE profiles SET {', '.join(fields)} WHERE uid = ?"
    with conn:
        conn.execute(query, values)

def get_friends(uid: int) -> list:
    conn = get_db()
    rows = conn.execute("SELECT friend_uid FROM friends WHERE uid = ?", (uid,)).fetchall()
    return [row['friend_uid'] for row in rows]

def add_friend(uid: int, friend_uid: int):
    conn = get_db()
    with conn:
        conn.execute("INSERT OR IGNORE INTO friends (uid, friend_uid) VALUES (?, ?)", (uid, friend_uid))

def remove_friend(uid: int, friend_uid: int):
    conn = get_db()
    with conn:
        conn.execute("DELETE FROM friends WHERE uid = ? AND friend_uid = ?", (uid, friend_uid))

def get_friend_applies(uid: int, state: int | list[int] | None = None, last_index_time: int | None = None) -> list:
    conn = get_db()
    query = "SELECT * FROM friend_applies WHERE uid = ?"
    params = [uid]
    if state is None:
        query += " AND state = 0"
    elif isinstance(state, list):
        if not state:
            return []
        placeholders = ",".join("?" for _ in state)
        query += f" AND state IN ({placeholders})"
        params.extend(state)
    else:
        query += " AND state = ?"
        params.append(state)

    if last_index_time and int(last_index_time) > 0:
        lit = int(last_index_time)
        lit_ms = lit if lit > 10_000_000_000 else lit * 1000
        query += " AND last_index_time > ?"
        params.append(lit_ms)

    query += " ORDER BY create_time DESC"
    rows = conn.execute(query, params).fetchall()
    return [dict(row) for row in rows]

def get_friend_to_applies(applicant_uid: int, state: int | list[int] | None = None, last_index_time: int | None = None) -> list:
    conn = get_db()
    query = "SELECT * FROM friend_applies WHERE applicant_uid = ?"
    params = [applicant_uid]
    if state is None:
        query += " AND state = 0"
    elif isinstance(state, list):
        if not state:
            return []
        placeholders = ",".join("?" for _ in state)
        query += f" AND state IN ({placeholders})"
        params.extend(state)
    else:
        query += " AND state = ?"
        params.append(state)

    if last_index_time and int(last_index_time) > 0:
        lit = int(last_index_time)
        lit_ms = lit if lit > 10_000_000_000 else lit * 1000
        query += " AND last_index_time > ?"
        params.append(lit_ms)

    query += " ORDER BY create_time DESC"
    rows = conn.execute(query, params).fetchall()
    return [dict(row) for row in rows]

def add_friend_apply(uid: int, applicant_uid: int, state: int, content: str, create_time: int, last_index_time: int) -> int:
    conn = get_db()
    with conn:
        existing = conn.execute(
            "SELECT apply_id FROM friend_applies WHERE uid = ? AND applicant_uid = ?",
            (uid, applicant_uid)
        ).fetchone()
        if existing:
            apply_id = int(existing["apply_id"])
            conn.execute(
                "UPDATE friend_applies SET state = ?, content = ?, create_time = ?, last_index_time = ? WHERE apply_id = ?",
                (state, content, create_time, last_index_time, apply_id)
            )
            return apply_id
        else:
            apply_id = get_next_apply_id()
            conn.execute(
                "INSERT INTO friend_applies (apply_id, uid, applicant_uid, state, content, create_time, last_index_time) VALUES (?, ?, ?, ?, ?, ?, ?)",
                (apply_id, uid, applicant_uid, state, content, create_time, last_index_time)
            )
            return apply_id

def update_friend_apply_state(apply_id: int, state: int):
    conn = get_db()
    with conn:
        conn.execute("UPDATE friend_applies SET state = ? WHERE apply_id = ?", (state, apply_id))

def remove_friend_apply(apply_id: int):
    conn = get_db()
    with conn:
        conn.execute("DELETE FROM friend_applies WHERE apply_id = ?", (apply_id,))

def get_next_apply_id() -> int:
    conn = get_db()
    with conn:
        row = conn.execute("SELECT value_int FROM server_state WHERE key = 'next_apply_id'").fetchone()
        val = row['value_int'] if row else 10
        conn.execute("INSERT OR REPLACE INTO server_state (key, value_int) VALUES ('next_apply_id', ?)", (val + 1,))
        return val

def get_all_profiles() -> dict:
    conn = get_db()
    rows = conn.execute("SELECT * FROM profiles").fetchall()
    res = {}
    for row in rows:
        d = dict(row)
        res[str(d['uid'])] = d
    return res

def get_or_create_uid_for_account(account: str) -> int:
    conn = get_db()
    with conn:
        row = conn.execute("SELECT uid FROM accounts WHERE account = ?", (account,)).fetchone()
        if row:
            return row['uid']
        
        # Allocate new UID
        row = conn.execute("SELECT MAX(uid) as m FROM accounts").fetchone()
        max_mapped = row['m'] if row and row['m'] else 1000000
        
        row_p = conn.execute("SELECT MAX(uid) as m FROM profiles").fetchone()
        max_profile = row_p['m'] if row_p and row_p['m'] else 1000000
        
        new_uid = max(max_mapped, max_profile) + 1
        conn.execute("INSERT INTO accounts (account, uid) VALUES (?, ?)", (account, new_uid))
        return new_uid
