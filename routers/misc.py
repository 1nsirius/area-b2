import services.utils as utils
import os
import json
import time
from urllib.parse import urlparse, parse_qs

def handle_route(path: str, req_json: dict, host: str, query: str, context: dict) -> bool:
    """
    Misc Router.
    Handles miscellaneous endpoints, config checks, and Vanguard security SDK.
    Returns True if handled.
    """
    
    if path == "/" or path == "/health":
        context['send_json']({"ok": True})
        return True

    if path == "/ping":
        context['send_body'](
            b"pong",
            status=200,
            content_type="text/plain; charset=utf-8",
            extra_headers=utils._no_cache_headers(),
        )
        return True
        
    if path == "/client/system.config.check":
        context['send_json']({"code": 0, "msg": "ok", "data": {}})
        return True
        
    if path == "/client/account.thirdParty.list":
        context['send_json']({"code": 0, "msg": "ok", "data": {"list": []}})
        return True
        
    if path == "/dl/p10470/create":
        context['send_json']({"code": 0, "msg": "ok", "data": {}})
        return True
        
    if path == "/log/gbi_log":
        # Returns 200 OK without JSON to avoid Android JSONException on empty
        context['send_body'](b"{}", status=200, content_type="application/json; charset=utf-8")
        return True


    if path == "/ann/realm/ticket":
        context['send_json']({"code": 0, "msg": "ok", "data": {"ticket": "test_ticket"}})
        return True
        
    if path.startswith("/ann/realm/detail/"):
        context['send_json']({"code": 0, "msg": "ok", "data": {"announcements": []}})
        return True
        
    if path.startswith("/follow/"):
        # Dead logic as per user instruction
        context['send_json']({"code": 0, "msg": "ok", "data": {}})
        return True

    return False
