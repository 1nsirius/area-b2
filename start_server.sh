#!/usr/bin/env bash
echo "==================================================="
echo "            Area F2 Server Launcher"
echo "==================================================="
if ! command -v python3 &> /dev/null; then
    echo "[ERROR] python3 could not be found. Please install Python 3.10+."
    exit 1
fi
echo "Starting Game Server..."
python3 run_https_443.py
