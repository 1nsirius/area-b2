"""Area F2 Admin Web Panel Router.

Provides HTTP route dispatching for administrative and monitoring endpoints.
Adheres to the project's modular architecture (routers/ and services/).
"""

from __future__ import annotations

import json
from typing import Any
import services.admin_panel as admin_service


def handle_route(path: str, req_json: dict[str, Any], host: str, query: str, context: dict[str, Any]) -> bool:
    """Dispatches admin endpoints if intercepted on standard HTTP/HTTPS gateway."""
    normalized_path = (path or "").strip()
    if not normalized_path.startswith("/api/v1/admin") and not normalized_path.startswith("/admin"):
        return False

    # Route is reserved for admin operations
    return True
