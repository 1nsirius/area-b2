# Area F2 — Dedicated Game & Lobby Server (Reborn)

[🇷🇺 Читать на русском](#-русский) | [🇬🇧 Read in English](#-english)

---

<a name="-русский"></a>
# 🇷🇺 Русский

Автономный серверный комплекс для мобильного тактического шутера **Area F2**. Воспроизводит сетевой стек игры: регистрацию, аутентификацию, игровое лобби, чат, магазин, систему заданий и наград, профили игроков, веб-панель управления и боевые матчи.

---

## 📌 Основные возможности

* **Аутентификация:** Поддержка Gangplank API (`/gp/...`), Holo API, гостевой вход и регистрация.
* **Игровое лобби (TCP 12345):** Комнаты лобби, управление командами, матчмейкинг, общий и командный чат, система друзей.
* **События и миссии:** 7-дневные события входа (Sign-in), ежедневные задания, награды за достижение 1–60 уровней с мгновенной синхронизацией баланса.
* **Экономика и инвентарь:** Покупка оперативников, оружия, скинов, сундуков, открытие наград и система почты.
* **Боевой сервер:** UDP/TCP синхронизация матчей, стрельба, разрушение стен/баррикад, использование гаджетов, обезвреживание заряда.
* **Веб-панель администратора (HTTP 8080):** Управление аккаунтами в реальном времени, изменение уровня, ранга, валюты (золото/алмазы) и выдача предметов.
* **База данных:** SQLite база данных для надежного хранения профилей и игрового состояния.
* **Клиент в комплекте:** В репозиторий включены рабочий APK и OBB-кэш для Android.

---

## 💻 Системные требования

* **ОС:** Windows 10/11, Linux (Ubuntu 20.04+) или macOS.
* **Python:** Версия **3.10** или выше (рекомендуется **Python 3.11**).
* **Git LFS:** Для загрузки OBB-кэша (`git lfs`).
* **Права суперпользователя:** Запуск от имени **Администратора (Windows)** или через **`sudo` (Linux)** обязателен (для привязки к HTTPS-порту **443**).

---

## 🚀 Пошаговое руководство по установке

### 1. Клонирование репозитория
```bash
git clone git@github.com:1nsirius/area-b2.git
cd area-b2
```
*(Или через HTTPS: `git clone https://github.com/1nsirius/area-b2.git`)*

Если вы используете Git LFS, загрузите бинарные файлы клиента:
```bash
git lfs pull
```

### 2. Установка зависимостей Python
```bash
pip install -r requirements.txt
```

---

## ▶️ Запуск сервера

### Windows:
1. Запустите командную строку (CMD) или PowerShell **от имени Администратора**.
2. В папке с сервером запустите:
   ```cmd
   start_server.bat
   ```
   *Или напрямую через Python:*
   ```cmd
   python run_https_443.py
   ```

### Linux / macOS:
```bash
chmod +x start_server.sh
sudo ./start_server.sh
```
*Или напрямую:*
```bash
sudo python3 run_https_443.py
```

---

## 📱 Установка и запуск клиента игры (APK и OBB)

Файлы игрового клиента находятся в папке `client/`:

1. **Установка APK:**
   Установите файл `client/apk/com.qookka.areaf2.apk` на Android-устройство или эмулятор (например, LDPlayer 9 / BlueStacks).
   ```bash
   adb install client/apk/com.qookka.areaf2.apk
   ```

2. **Копирование OBB-кэша:**
   Скопируйте папку с кэшем на устройство по пути `/sdcard/Android/obb/`:
   ```bash
   adb push client/obb/com.qookka.areaf2 /sdcard/Android/obb/
   ```

3. **Установка SSL-сертификата:**
   Установите системный сертификат `certs/910e88fa.0` в хранилище `/system/etc/security/cacerts/` (требуются root-права) либо используйте пропатченный APK с отключенной проверкой SSL.

4. **Перенаправление игровых доменов на IP сервера:**
   Добавьте в `/system/etc/hosts` на устройстве или в настройках DNS:
   ```text
   <IP_СЕРВЕРА> p10470-ustest-chat-tcpclient.ejoy.com
   <IP_СЕРВЕРА> ga.ejoy.com
   <IP_СЕРВЕРА> game.ejoy.com
   ```

---

## 🌐 Веб-панель управления (Admin Panel)

После старта сервера откройте:
👉 **[http://localhost:8080](http://localhost:8080)** *(или `http://<IP_СЕРВЕРА>:8080`)*

* Просмотр списка зарегистрированных игроков и их онлайн-статуса.
* Изменение уровня, опыта, золота и алмазов.
* Редактирование боевой статистики (ранг, убийства, победы).
* Мгновенная выдача скинов, оружия и оперативников в инвентарь.

---

## 🔌 Используемые сетевые порты

| Порт | Протокол | Назначение |
| :--- | :--- | :--- |
| **443** | TCP (HTTPS) | REST API, авторизация, конфиги, платежи, новости |
| **12345** | TCP (Sproto) | Игровое лобби, чат, инвентарь, команды, социалка |
| **8080** | TCP (HTTP) | Веб-панель администратора |
| **10000+** | UDP / TCP | Боевые игровые комнаты (Battle Server) |

---

## ❓ Решение проблем (Troubleshooting)

* **`PermissionError: [Errno 13] Permission denied`:**
  Серверу не хватает прав для открытия порта 443. Запустите консоль от имени Администратора (Windows) или используйте `sudo` (Linux).
* **`Address already in use`:**
  Порт 443 или 12345 занят другим приложением. Завершите процесс, занимающий порт.
* **Сброс базы данных:**
  Для сброса всех игроков и создания чистой БД удалите файл `artifacts/database.db` и перезапустите сервер.

---
---

<a name="-english"></a>
# 🇬🇧 English

A standalone server suite for the tactical mobile shooter **Area F2**. Emulates the full game networking stack: account registration, authentication, lobby rooms, chat, store, missions, events, player profiles, web admin panel, and battle matches.

---

## 📌 Key Features

* **Authentication:** Gangplank API (`/gp/...`), Holo API, guest login, and registration.
* **Game Lobby (TCP 12345):** Lobby rooms, team management, matchmaking, global/team chat, friend system.
* **Events & Missions:** 7-day sign-in novice event, daily tasks, milestone level 1–60 progress rewards with instant balance synchronization.
* **Economy & Inventory:** Purchase operators, weapons, skins, crates, claim rewards, and mail.
* **Battle Server:** UDP/TCP match synchronization, shooting, wall/barricade destruction, operator gadgets, and defuser plant/defuse logic.
* **Web Admin Panel (HTTP 8080):** Real-time player management, modify player level, rank score, gold/diamonds, and grant inventory items.
* **Database:** Lightweight SQLite database for profile persistence.
* **Client Included:** Android APK and OBB game cache bundled inside the repository via Git LFS.

---

## 💻 System Requirements

* **OS:** Windows 10/11, Linux (Ubuntu 20.04+), or macOS.
* **Python:** Version **3.10** or higher (**Python 3.11** recommended).
* **Git LFS:** Required for downloading the OBB cache (`git lfs`).
* **Root / Administrator privileges:** Running as **Administrator (Windows)** or via **`sudo` (Linux)** is required to bind standard HTTPS port **443**.

---

## 🚀 Step-by-Step Installation Guide

### 1. Clone the Repository
```bash
git clone git@github.com:1nsirius/area-b2.git
cd area-b2
```
*(Or via HTTPS: `git clone https://github.com/1nsirius/area-b2.git`)*

Fetch large client binary files via Git LFS:
```bash
git lfs pull
```

### 2. Install Python Dependencies
```bash
pip install -r requirements.txt
```

---

## ▶️ Starting the Server

### Windows:
1. Open Command Prompt or PowerShell as **Administrator**.
2. Run:
   ```cmd
   start_server.bat
   ```
   *Or directly via Python:*
   ```cmd
   python run_https_443.py
   ```

### Linux / macOS:
```bash
chmod +x start_server.sh
sudo ./start_server.sh
```
*Or directly:*
```bash
sudo python3 run_https_443.py
```

---

## 📱 Game Client Setup (APK & OBB)

Client files are located in the `client/` folder:

1. **Install APK:**
   Install `client/apk/com.qookka.areaf2.apk` on your Android device or emulator (e.g. LDPlayer 9 / BlueStacks):
   ```bash
   adb install client/apk/com.qookka.areaf2.apk
   ```

2. **Copy OBB Cache:**
   Push the OBB folder to `/sdcard/Android/obb/`:
   ```bash
   adb push client/obb/com.qookka.areaf2 /sdcard/Android/obb/
   ```

3. **Install SSL Certificate:**
   Install `certs/910e88fa.0` into the system certificate store `/system/etc/security/cacerts/` (requires root access), or use an APK with disabled SSL verification.

4. **Route Game Domains to Server IP:**
   Add to `/system/etc/hosts` or your router DNS:
   ```text
   <SERVER_IP> p10470-ustest-chat-tcpclient.ejoy.com
   <SERVER_IP> ga.ejoy.com
   <SERVER_IP> game.ejoy.com
   ```

---

## 🌐 Web Admin Panel

After starting the server, open your browser:
👉 **[http://localhost:8080](http://localhost:8080)** *(or `http://<SERVER_IP>:8080`)*

* View online players and account list.
* Edit Level, EXP, Gold, and Diamonds.
* Edit combat stats (Rank Score, kills, win rate).
* Grant skins, weapons, and characters directly into user inventory.

---

## 🔌 Network Ports

| Port | Protocol | Description |
| :--- | :--- | :--- |
| **443** | TCP (HTTPS) | Core REST API, authentication, configs, payments, announcements |
| **12345** | TCP (Sproto) | Game lobby, chat, inventory, teams, social graph |
| **8080** | TCP (HTTP) | Web Admin Panel |
| **10000+** | UDP / TCP | Match simulation instances (Battle Server) |

---

## ❓ Troubleshooting

* **`PermissionError: [Errno 13] Permission denied`:**
  Port 443 requires elevated privileges. Run as Administrator (Windows) or use `sudo` (Linux).
* **`Address already in use`:**
  Port 443 or 12345 is already in use by another software. Stop the conflicting process.
* **Database Reset:**
  To reset all player accounts and start with a clean database, delete `artifacts/database.db` and restart the server.
