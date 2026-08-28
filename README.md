# Area F2 — Dedicated Game & Lobby Server (Reborn)

[Читать на русском](#русский) | [Read in English](#english)

---

<a name="русский"></a>
# Русский

Автономный серверный комплекс для мобильного тактического шутера Area F2. Воспроизводит сетевой стек игры: регистрацию, аутентификацию, игровое лобби, чат, магазин, систему заданий и наград, профили игроков, веб-панель управления и боевые матчи.

---

## Основные возможности

* Аутентификация: Поддержка Gangplank API (/gp/...), Holo API, гостевой вход и регистрация.
* Игровое лобби (TCP 12345): Комнаты лобби, управление командами, матчмейкинг, общий и командный чат, система друзей.
* События и миссии: 7-дневные события входа (Sign-in), ежедневные задания, награды за достижение 1–60 уровней с мгновенной синхронизацией баланса.
* Экономика и инвентарь: Покупка оперативников, оружия, скинов, сундуков, открытие наград и система почты.
* Боевой сервер: UDP/TCP синхронизация матчей, стрельба, разрушение стен/баррикад, использование гаджетов, обезвреживание заряда.
* Веб-панель администратора (HTTP 8080): Управление аккаунтами в реальном времени, изменение уровня, ранга, валюты (золото/алмазы) и выдача предметов.
* База данных: SQLite база данных для надежного хранения профилей и игрового состояния.
* Клиент в комплекте: Пропатченный APK для Android, готовый к работе без настройки сертификатов и перенаправления трафика.

---

## Системные требования

* Операционная система: Windows 10/11, Linux (Ubuntu 20.04+) или macOS.
* Python: Версия 3.10 или выше (рекомендуется Python 3.11).
* Права суперпользователя: Запуск от имени Администратора (Windows) или через sudo (Linux) обязателен (для привязки к HTTPS-порту 443).

---

## Пошаговое руководство по установке сервера

### 1. Клонирование репозитория
```bash
git clone git@github.com:1nsirius/area-b2.git
cd area-b2
```
*(Или через HTTPS: `git clone https://github.com/1nsirius/area-b2.git`)*

### 2. Установка зависимостей Python
```bash
pip install -r requirements.txt
```

---

## Запуск сервера

### Windows:
1. Запустите командную строку (CMD) или PowerShell от имени Администратора.
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

## Установка и порядок запуска клиента на устройстве (APK и кэш OBB)

Файлы игрового клиента находятся в папке client/:

### 1. Установка приложения и кэша:
* Установка APK: Установите client/apk/com.qookka.areaf2.apk на Android-устройство или эмулятор (LDPlayer, BlueStacks).
* Установка кэша OBB: Скопируйте файл кэша main.60.com.qookka.areaf2.obb во внутреннюю память телефона по пути:
  `Внутренняя память/Android/obb/com.qookka.areaf2/`
  *(Если папки com.qookka.areaf2 нет, создайте ее вручную).*

### 2. Последовательность действий при запуске игры:

1. Ввод IP-адреса сервера:
   * При первом запуске игры на экране появится всплывающее диалоговое окно для ввода IP-адреса сервера.
   * Введите IP-адрес машины, на которой запущен сервер (например, 127.0.0.1 для эмулятора на том же ПК или локальный IP-адрес вашего сервера в сети) и подтвердите ввод. Весь сетевой трафик игры будет автоматически направляться на этот адрес.

2. Выбор способа авторизации (Facebook):
   * На стартовом экране входа среди предложенных вариантов выберите вход через Facebook.

3. Ввод логина аккаунта:
   * В появившемся диалоговом окне найдите текстовое поле с плейсхолдером <EMPTY> (или пустое поле ввода).
   * Введите ваше желаемое имя пользователя/логин (например player1 или 1nsirius) и нажмите кнопку подтверждения.
   * Сервер автоматически создаст новый профиль (или загрузит существующий), и вы попадете в главное лобби игры.

---

## Веб-панель управления (Admin Panel)

После старта сервера откройте браузер:
http://localhost:8080 *(или http://<IP_СЕРВЕРА>:8080)*

* Просмотр списка зарегистрированных игроков и их онлайн-статуса.
* Изменение уровня, опыта, золота и алмазов.
* Редактирование боевой статистики (ранг, убийства, победы).
* Мгновенная выдача скинов, оружия и оперативников в инвентарь.

---

## Используемые сетевые порты

| Порт | Протокол | Назначение |
| :--- | :--- | :--- |
| 443 | TCP (HTTPS) | REST API, авторизация, конфиги, платежи, новости |
| 12345 | TCP (Sproto) | Игровое лобби, чат, инвентарь, команды, социалка |
| 8080 | TCP (HTTP) | Веб-панель администратора |
| 10000+ | UDP / TCP | Боевые игровые комнаты (Battle Server) |

---

## Решение проблем (Troubleshooting)

* PermissionError: [Errno 13] Permission denied:
  Серверу не хватает прав для открытия порта 443. Запустите консоль от имени Администратора (Windows) или используйте sudo (Linux).
* Address already in use:
  Порт 443 или 12345 занят другим приложением. Завершите процесс, занимающий порт.
* Сброс базы данных:
  Для сброса всех игроков и создания чистой БД удалите файл artifacts/database.db и перезапустите сервер.

---
---

<a name="english"></a>
# English

A standalone server suite for the tactical mobile shooter Area F2. Emulates the full game networking stack: account registration, authentication, lobby rooms, chat, store, missions, events, player profiles, web admin panel, and battle matches.

---

## Key Features

* Authentication: Gangplank API (/gp/...), Holo API, guest login, and registration.
* Game Lobby (TCP 12345): Lobby rooms, team management, matchmaking, global/team chat, friend system.
* Events & Missions: 7-day sign-in novice event, daily tasks, milestone level 1–60 progress rewards with instant balance synchronization.
* Economy & Inventory: Purchase operators, weapons, skins, crates, claim rewards, and mail.
* Battle Server: UDP/TCP match synchronization, shooting, wall/barricade destruction, operator gadgets, and defuser plant/defuse logic.
* Web Admin Panel (HTTP 8080): Real-time player management, modify player level, rank score, gold/diamonds, and grant inventory items.
* Database: Lightweight SQLite database for profile persistence.
* Patched Client Included: Patched Android APK included — works directly without certificate installation or traffic redirection.

---

## System Requirements

* OS: Windows 10/11, Linux (Ubuntu 20.04+), or macOS.
* Python: Version 3.10 or higher (Python 3.11 recommended).
* Root / Administrator privileges: Running as Administrator (Windows) or via sudo (Linux) is required to bind standard HTTPS port 443.

---

## Step-by-Step Server Installation Guide

### 1. Clone the Repository
```bash
git clone git@github.com:1nsirius/area-b2.git
cd area-b2
```
*(Or via HTTPS: `git clone https://github.com/1nsirius/area-b2.git`)*

### 2. Install Python Dependencies
```bash
pip install -r requirements.txt
```

---

## Starting the Server

### Windows:
1. Open Command Prompt or PowerShell as Administrator.
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

## Mobile Device Client Setup (APK & OBB Cache)

The client APK is pre-patched: installing custom SSL certificates or setting up traffic redirection is NOT required.

### 1. Installation:
* APK Installation: Install client/apk/com.qookka.areaf2.apk on your Android phone or emulator (e.g., LDPlayer 9, BlueStacks).
* OBB Cache Setup: Copy the cache file main.60.com.qookka.areaf2.obb into internal storage at:
  `Internal Storage/Android/obb/com.qookka.areaf2/`
  *(Create the com.qookka.areaf2 directory manually if it does not exist).*

### 2. Launch Sequence:

1. Server IP Prompt:
   * Upon launching the game for the first time, a popup dialog will request the Server IP Address.
   * Enter your server IP address (e.g., 127.0.0.1 for local emulator or your server's LAN/Public IP) and confirm. All game traffic will automatically route to this address.

2. Login Method Selection (Facebook):
   * On the main login screen, select Facebook as your login provider.

3. Account Username Entry:
   * In the popup input dialog, locate the text input field labeled with placeholder <EMPTY> (or empty input box).
   * Type your desired account username/login (e.g. player1 or 1nsirius) and press confirm.
   * The server will automatically initialize or load your player profile and log you into the game lobby.

---

## Web Admin Panel

After starting the server, open your browser:
http://localhost:8080 *(or http://<SERVER_IP>:8080)*

* View online players and account list.
* Edit Level, EXP, Gold, and Diamonds.
* Edit combat stats (Rank Score, kills, win rate).
* Grant skins, weapons, and characters directly into user inventory.

---

## Network Ports

| Port | Protocol | Description |
| :--- | :--- | :--- |
| 443 | TCP (HTTPS) | Core REST API, authentication, configs, payments, announcements |
| 12345 | TCP (Sproto) | Game lobby, chat, inventory, teams, social graph |
| 8080 | TCP (HTTP) | Web Admin Panel |
| 10000+ | UDP / TCP | Match simulation instances (Battle Server) |

---

## Troubleshooting

* PermissionError: [Errno 13] Permission denied:
  Port 443 requires elevated privileges. Run as Administrator (Windows) or use sudo (Linux).
* Address already in use:
  Port 443 or 12345 is already in use by another software. Stop the conflicting process.
* Database Reset:
  To reset all player accounts and start with a clean database, delete artifacts/database.db and restart the server.
