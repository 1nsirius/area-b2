@echo off
title Area F2 Server
chcp 65001 >nul
cls
echo ===================================================
echo             Area F2 Server Launcher
echo ===================================================
echo.
python --version >nul 2>&1
if errorlevel 1 (
    echo [ERROR] Python is not found in PATH! Please install Python 3.10+.
    pause
    exit /b 1
)

echo Starting Game Server (HTTPS 443, TCP Sproto 12345, Admin Panel 8080)...
python run_https_443.py
pause
