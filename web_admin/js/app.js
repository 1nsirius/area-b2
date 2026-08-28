/**
 * Area F2 Web Admin & Monitoring Panel — Client JavaScript Application
 */

const API_BASE = '/api/v1';
let authToken = localStorage.getItem('af2_admin_token') || '';
let activeTab = 'dashboard';
let logEventSource = null;
let liveConsoleLines = [];

document.addEventListener('DOMContentLoaded', () => {
  initAuth();
  initNavigation();
  initForms();
  initConsoleStream();
});

// ─────────────────────────────────────────────────────────────────────────────
// Authentication & Session
// ─────────────────────────────────────────────────────────────────────────────

async function initAuth() {
  if (!authToken) {
    showLoginModal();
    return;
  }

  try {
    const res = await fetch(`${API_BASE}/auth/me`, {
      headers: { 'Authorization': `Bearer ${authToken}` }
    });
    const data = await res.json();
    if (data.authenticated) {
      hideLoginModal();
      loadActiveTab();
      startPolling();
    } else {
      showLoginModal();
    }
  } catch (err) {
    showLoginModal();
  }
}

function showLoginModal() {
  document.getElementById('login-modal').classList.add('active');
}

function hideLoginModal() {
  document.getElementById('login-modal').classList.remove('active');
}

async function handleLogin(password) {
  const errEl = document.getElementById('login-error');
  errEl.textContent = '';
  try {
    const res = await fetch(`${API_BASE}/auth/login`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ password })
    });
    const data = await res.json();
    if (data.success && data.data && data.data.token) {
      authToken = data.data.token;
      localStorage.setItem('af2_admin_token', authToken);
      hideLoginModal();
      showToast('Успешный вход в систему', 'success');
      loadActiveTab();
      startPolling();
      initConsoleStream();
    } else {
      errEl.textContent = data.error || 'Неверный пароль администратора';
    }
  } catch (err) {
    errEl.textContent = 'Ошибка подключения к серверу';
  }
}

function logout() {
  authToken = '';
  localStorage.removeItem('af2_admin_token');
  if (logEventSource) {
    logEventSource.close();
  }
  showLoginModal();
}

// ─────────────────────────────────────────────────────────────────────────────
// API Fetch Helper
// ─────────────────────────────────────────────────────────────────────────────

async function apiRequest(endpoint, method = 'GET', body = null) {
  const options = {
    method,
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${authToken}`
    }
  };
  if (body) {
    options.body = JSON.stringify(body);
  }

  const res = await fetch(`${API_BASE}${endpoint}`, options);
  if (res.status === 401) {
    logout();
    throw new Error('Unauthorized');
  }
  return await res.json();
}

// ─────────────────────────────────────────────────────────────────────────────
// Navigation & Routing
// ─────────────────────────────────────────────────────────────────────────────

function initNavigation() {
  const navItems = document.querySelectorAll('.nav-item');
  navItems.forEach(item => {
    item.addEventListener('click', (e) => {
      e.preventDefault();
      const tab = item.getAttribute('data-tab');
      switchTab(tab);
    });
  });

  document.getElementById('btn-logout').addEventListener('click', logout);
  document.getElementById('btn-refresh').addEventListener('click', () => loadActiveTab(true));
}

function switchTab(tabName) {
  activeTab = tabName;
  document.querySelectorAll('.nav-item').forEach(el => el.classList.remove('active'));
  document.querySelectorAll('.tab-pane').forEach(el => el.classList.remove('active'));

  const navEl = document.querySelector(`.nav-item[data-tab="${tabName}"]`);
  const tabEl = document.getElementById(`tab-${tabName}`);
  if (navEl) navEl.classList.add('active');
  if (tabEl) tabEl.classList.add('active');

  const titleMap = {
    dashboard: 'Панель Мониторинга',
    players: 'Управление Аккаунтами',
    matches: 'Активные Комнаты и Матчи',
    mail: 'Внутриигровая Почта и Подарки',
    chat: 'Управление Чатом и Анонсы',
    logs: 'Живая Консоль Сервера',
    settings: 'Параметры и Настройки'
  };
  document.getElementById('page-title').textContent = titleMap[tabName] || 'Панель Управления';

  loadActiveTab();
}

function loadActiveTab(isManualRefresh = false) {
  if (activeTab === 'dashboard') loadDashboard();
  else if (activeTab === 'players') loadPlayers();
  else if (activeTab === 'matches') loadMatches();
  else if (activeTab === 'chat') loadChatHistory();
  else if (activeTab === 'settings') loadSettings();

  if (isManualRefresh) {
    showToast('Данные обновлены', 'info');
  }
}

function startPolling() {
  setInterval(() => {
    if (!authToken) return;
    if (activeTab === 'dashboard') {
      loadDashboard();
    } else if (activeTab === 'chat') {
      loadChatHistory();
    } else if (activeTab === 'matches') {
      loadMatches();
    }
  }, 2500);
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 1: DASHBOARD
// ─────────────────────────────────────────────────────────────────────────────

async function loadDashboard() {
  try {
    const res = await apiRequest('/system/status');
    if (!res.success) return;
    const data = res.data;

    document.getElementById('stat-uptime').textContent = data.uptime_formatted || '0с';
    document.getElementById('stat-ram').textContent = `${data.memory_info?.rss_mb || 0} MB`;
    document.getElementById('card-total-accounts').textContent = data.total_accounts || 0;
    document.getElementById('card-online-players').textContent = data.online_players || 0;
    document.getElementById('card-active-matches').textContent = data.active_rooms || 0;
    document.getElementById('badge-online-count').textContent = data.online_players || 0;
  } catch (err) {
    console.error('Failed to load dashboard:', err);
  }
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 2: PLAYERS (ACCOUNTS)
// ─────────────────────────────────────────────────────────────────────────────

async function loadPlayers() {
  try {
    const search = document.getElementById('player-search-input').value.trim();
    const status = document.getElementById('player-status-filter').value;
    const res = await apiRequest(`/players?q=${encodeURIComponent(search)}&status=${status}`);
    if (!res.success) return;

    const tbody = document.getElementById('players-table-body');
    if (!res.data || res.data.length === 0) {
      tbody.innerHTML = '<tr><td colspan="8" class="text-center py-4">Игроки не найдены</td></tr>';
      return;
    }

    tbody.innerHTML = res.data.map(p => {
      let statusBadge = '<span class="badge">Офлайн</span>';
      if (p.is_banned) statusBadge = '<span class="badge badge-danger">Забанен</span>';
      else if (p.status === 'in_match') statusBadge = '<span class="badge badge-warning">В матче</span>';
      else if (p.is_online) statusBadge = '<span class="badge badge-success">Онлайн</span>';

      return `
        <tr>
          <td><code class="port-num">${p.uid}</code></td>
          <td><strong>${escapeHtml(p.name)}</strong></td>
          <td>${p.level}</td>
          <td><span style="color:var(--accent-amber)">🪙 ${p.gold.toLocaleString()}</span></td>
          <td><span style="color:var(--accent-blue)">💎 ${p.diamond.toLocaleString()}</span></td>
          <td>${p.rank_score}</td>
          <td>${statusBadge}</td>
          <td>
            <div class="action-btn-group" style="display:flex;gap:0.35rem;">
              <button class="btn btn-secondary btn-sm" onclick="openPlayerEditModal(${p.uid})" title="Редактировать">✏️</button>
              <button class="btn btn-secondary btn-sm" onclick="openGrantItemModal(${p.uid})" title="Выдать предмет">🎁</button>
              <button class="btn btn-secondary btn-sm" onclick="unlockAllCharacters(${p.uid})" title="Разблокировать агентов">🔓</button>
              <button class="btn btn-secondary btn-sm" onclick="kickPlayer(${p.uid})" title="Кикнуть">👢</button>
              <button class="btn ${p.is_banned ? 'btn-primary' : 'btn-danger'} btn-sm" onclick="toggleBanPlayer(${p.uid})" title="${p.is_banned ? 'Разбанить' : 'Забанить'}">
                ${p.is_banned ? '🟢' : '🚫'}
              </button>
            </div>
          </td>
        </tr>
      `;
    }).join('');
  } catch (err) {
    console.error('Failed to load players:', err);
  }
}

async function openPlayerEditModal(uid) {
  try {
    const res = await apiRequest(`/players/${uid}`);
    if (!res.success) return;
    const p = res.data;

    document.getElementById('edit-uid').value = p.uid;
    document.getElementById('edit-modal-title').textContent = `Редактирование профиля: UID ${p.uid}`;
    document.getElementById('edit-name').value = p.name || '';
    document.getElementById('edit-level').value = p.level || 1;
    document.getElementById('edit-exp').value = p.exp || 0;
    document.getElementById('edit-gold').value = p.gold || 0;
    document.getElementById('edit-diamond').value = p.diamond || 0;
    document.getElementById('edit-motto').value = p.motto || '';
    document.getElementById('edit-icon').value = p.icon || 0;
    document.getElementById('edit-icon-frame').value = p.icon_frame || 0;

    // Tiers, Season & Royal Mark
    document.getElementById('edit-rank-score').value = p.rank_score ?? 1000;
    document.getElementById('edit-career-max-rank').value = p.career_max_rank ?? p.rank_score ?? 1000;
    document.getElementById('edit-king-emblem').value = p.king_emblem ?? 1;
    document.getElementById('edit-rank-protect-score').value = p.rank_protect_score ?? 0;

    // All Modes Combat Statistics
    document.getElementById('edit-kills').value = p.battle_kill ?? p.kills ?? 0;
    document.getElementById('edit-deaths').value = p.battle_dead ?? p.deaths ?? 0;
    document.getElementById('edit-assists').value = p.battle_assist ?? p.assists ?? 0;
    document.getElementById('edit-battle-times').value = p.battle_times ?? p.total_matches ?? 0;
    document.getElementById('edit-win-times').value = p.win_times ?? p.wins ?? 0;
    document.getElementById('edit-battle-score').value = p.battle_score ?? 0;
    document.getElementById('edit-mvp-count').value = p.mvp_count ?? 0;
    document.getElementById('edit-headshots').value = p.headshots ?? 0;

    // Ranked Mode Statistics
    document.getElementById('edit-rank-kills').value = p.rank_kills ?? p.battle_kill ?? p.kills ?? 0;
    document.getElementById('edit-rank-deaths').value = p.rank_deaths ?? p.battle_dead ?? p.deaths ?? 0;
    document.getElementById('edit-rank-battles').value = p.rank_battles ?? p.battle_times ?? p.total_matches ?? 0;
    document.getElementById('edit-rank-wins').value = p.rank_wins ?? p.win_times ?? p.wins ?? 0;
    // Reset to basic tab on open
    const basicTabBtn = document.getElementById('tab-btn-basic');
    if (basicTabBtn) {
      switchPlayerModalTab('tab-basic', basicTabBtn);
    }

    openModal('player-edit-modal');
  } catch (err) {
    showToast('Не удалось загрузить данные игрока', 'error');
  }
}

function switchPlayerModalTab(tabId, btn) {
  const modal = document.getElementById('player-edit-modal');
  if (!modal) return;
  modal.querySelectorAll('.modal-tab-btn').forEach(b => b.classList.remove('active'));
  modal.querySelectorAll('.modal-tab-content').forEach(c => c.classList.remove('active'));
  
  if (btn) btn.classList.add('active');
  const content = document.getElementById(tabId);
  if (content) content.classList.add('active');
}

async function unlockAllCharacters(uid) {
  if (!confirm(`Разблокировать всех оперативников для игрока UID ${uid}?`)) return;
  try {
    const res = await apiRequest(`/players/${uid}/unlock_characters`, 'POST');
    if (res.success) {
      showToast(`Все оперативники разблокированы для UID ${uid}`, 'success');
      loadPlayers();
    }
  } catch (err) {
    showToast('Ошибка разблокировки', 'error');
  }
}

async function kickPlayer(uid) {
  try {
    const res = await apiRequest(`/players/${uid}/kick`, 'POST');
    if (res.success) {
      showToast(`Игрок UID ${uid} отключен`, 'info');
      loadPlayers();
    }
  } catch (err) {
    showToast('Ошибка при отключении игрока', 'error');
  }
}

async function toggleBanPlayer(uid) {
  try {
    const res = await apiRequest(`/players/${uid}/ban`, 'POST');
    if (res.success) {
      const isBanned = res.data?.is_banned;
      showToast(`Игрок UID ${uid} ${isBanned ? 'заблокирован' : 'разблокирован'}`, isBanned ? 'error' : 'success');
      loadPlayers();
    }
  } catch (err) {
    showToast('Ошибка при изменении статуса блокировки', 'error');
  }
}

function openGrantItemModal(uid) {
  document.getElementById('grant-uid').value = uid;
  openModal('grant-item-modal');
}

function openNewPlayerModal() {
  openModal('create-player-modal');
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 3: MATCHES & ROOMS
// ─────────────────────────────────────────────────────────────────────────────

async function loadMatches() {
  try {
    const res = await apiRequest('/rooms');
    if (!res.success) return;
    const container = document.getElementById('rooms-container');

    if (!res.data || res.data.length === 0) {
      container.innerHTML = '<p class="empty-state">Нет активных матчей в данный момент.</p>';
      return;
    }

    container.innerHTML = res.data.map(r => `
      <div class="card mb-3">
        <div class="card-header flex-between">
          <div>
            <h3>Комната #${r.room_id} &mdash; Карта: ${r.map_id} (${r.status})</h3>
            <span class="text-muted">Хост UID: ${r.host_uid} | Игроков: ${r.player_count}</span>
          </div>
          <button class="btn btn-danger btn-sm" onclick="terminateRoom('${r.room_id}')">Завершить матч</button>
        </div>
        <div class="card-body">
          <div class="grid grid-2">
            <div>
              <h4 style="color:var(--accent-blue);margin-bottom:0.5rem;">Команда Атаки (Camp 1)</h4>
              <ul>
                ${r.players.filter(p => p.camp === 1).map(p => `<li>UID ${p.uid}: <strong>${escapeHtml(p.name)}</strong> (Агент ${p.character_id})</li>`).join('') || '<li class="text-muted">Пусто</li>'}
              </ul>
            </div>
            <div>
              <h4 style="color:var(--accent-amber);margin-bottom:0.5rem;">Команда Защиты (Camp 2)</h4>
              <ul>
                ${r.players.filter(p => p.camp === 2).map(p => `<li>UID ${p.uid}: <strong>${escapeHtml(p.name)}</strong> (Агент ${p.character_id})</li>`).join('') || '<li class="text-muted">Пусто</li>'}
              </ul>
            </div>
          </div>
        </div>
      </div>
    `).join('');
  } catch (err) {
    console.error('Failed to load matches:', err);
  }
}

async function terminateRoom(roomId) {
  if (!confirm(`Принудительно завершить матч в комнате #${roomId}?`)) return;
  try {
    const res = await apiRequest(`/rooms/${roomId}/terminate`, 'POST');
    if (res.success) {
      showToast('Матч завершен', 'success');
      loadMatches();
    }
  } catch (err) {
    showToast('Ошибка при завершении матча', 'error');
  }
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 4 & 5: MAIL & CHAT
// ─────────────────────────────────────────────────────────────────────────────

function openGlobalMailModal() {
  switchTab('mail');
  document.getElementById('mail-target-uid').value = 'all';
}

function openBroadcastChatModal() {
  switchTab('chat');
}

async function loadChatHistory() {
  try {
    const res = await apiRequest('/chat/history');
    if (!res.success) return;
    const listEl = document.getElementById('chat-history-list');

    if (!res.data || res.data.length === 0) {
      listEl.innerHTML = '<p class="empty-state">История чата пуста.</p>';
      return;
    }

    listEl.innerHTML = res.data.map(m => `
      <div class="chat-message-item">
        <div class="chat-meta">
          <span class="chat-author">[${escapeHtml(m.sender_name)}] (UID ${m.sender_uid}):</span>
          <span class="text-muted">${m.timestamp}</span>
        </div>
        <div class="chat-text">${escapeHtml(m.content)}</div>
      </div>
    `).join('');
    listEl.scrollTop = listEl.scrollHeight;
  } catch (err) {
    console.error('Failed to load chat history:', err);
  }
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 6: LIVE CONSOLE (SSE)
// ─────────────────────────────────────────────────────────────────────────────

function initConsoleStream() {
  if (logEventSource) {
    logEventSource.close();
  }

  if (!authToken) return;

  const output = document.getElementById('console-output');
  const searchFilter = document.getElementById('log-search-filter');

  try {
    logEventSource = new EventSource(`${API_BASE}/logs/stream?token=${encodeURIComponent(authToken)}`);
    let firstLine = true;
    logEventSource.onmessage = (event) => {
      try {
        if (firstLine) {
          output.innerHTML = '';
          firstLine = false;
        }
        const entry = JSON.parse(event.data);
        liveConsoleLines.push(entry);
        if (liveConsoleLines.length > 1000) liveConsoleLines.shift();

        appendConsoleLine(entry, searchFilter.value.trim().toLowerCase());
      } catch (e) {}
    };

    logEventSource.onerror = () => {
      // Reconnect handled automatically by browser
    };
  } catch (err) {
    console.error('SSE initialization error:', err);
  }

  searchFilter.addEventListener('input', () => {
    const filter = searchFilter.value.trim().toLowerCase();
    output.innerHTML = '';
    liveConsoleLines.forEach(line => appendConsoleLine(line, filter));
  });

  document.getElementById('btn-clear-logs').addEventListener('click', () => {
    output.innerHTML = '';
    liveConsoleLines = [];
  });
}

function appendConsoleLine(entry, filter = '') {
  const output = document.getElementById('console-output');
  const fullText = `[${entry.timestamp}] [${entry.tag}] ${entry.message}`.toLowerCase();
  if (filter && !fullText.includes(filter)) return;

  let tagClass = 'tag-boot';
  const tagUpper = String(entry.tag || '').toUpperCase();
  if (tagUpper.includes('TCP') || tagUpper.includes('SPROTO')) tagClass = 'tag-tcp';
  else if (tagUpper.includes('BATTLE') || tagUpper.includes('UDP')) tagClass = 'tag-battle';
  else if (tagUpper.includes('ROOM') || tagUpper.includes('PREBATTLE')) tagClass = 'tag-room';
  else if (tagUpper.includes('CHAT')) tagClass = 'tag-chat';
  else if (tagUpper.includes('ERROR') || tagUpper.includes('WARN')) tagClass = 'tag-error';

  const lineEl = document.createElement('div');
  lineEl.className = 'console-line';
  lineEl.innerHTML = `<span class="time">[${entry.timestamp}]</span> <span class="tag ${tagClass}">[${escapeHtml(entry.tag)}]</span> ${escapeHtml(entry.message)}`;

  output.appendChild(lineEl);
  output.scrollTop = output.scrollHeight;
}

function downloadServerLogs() {
  window.open(`${API_BASE}/logs/download`, '_blank');
}

// ─────────────────────────────────────────────────────────────────────────────
// TAB 7: SETTINGS & BACKUP
// ─────────────────────────────────────────────────────────────────────────────

async function loadSettings() {
  try {
    const res = await apiRequest('/system/config');
    if (!res.success) return;
    const conf = res.data;

    document.getElementById('conf-announcement').value = conf.server_tuning?.server_announcement || '';
    document.getElementById('conf-exp-mult').value = conf.server_tuning?.exp_multiplier || 1.0;
    document.getElementById('conf-gold-mult').value = conf.server_tuning?.gold_multiplier || 1.0;
    document.getElementById('conf-gm-enabled').checked = bool(conf.server_tuning?.gm_enabled);
  } catch (err) {
    console.error('Failed to load settings:', err);
  }
}

function bool(val) {
  return val === true || val === '1' || val === 1;
}

function exportBackupData() {
  window.open(`${API_BASE}/backup/export`, '_blank');
}

async function importBackupData() {
  const fileInput = document.getElementById('restore-file-input');
  if (!fileInput.files || fileInput.files.length === 0) {
    showToast('Выберите файл резервной копии .json', 'error');
    return;
  }

  if (!confirm('ВНИМАНИЕ: Восстановление перезапишет текущую базу игроков. Продолжить?')) return;

  const file = fileInput.files[0];
  const reader = new FileReader();
  reader.onload = async (e) => {
    try {
      const payload = JSON.parse(e.target.result);
      const res = await apiRequest('/backup/import', 'POST', payload);
      if (res.success) {
        showToast('База данных успешно восстановлена!', 'success');
        loadDashboard();
      } else {
        showToast(res.error || 'Ошибка восстановления', 'error');
      }
    } catch (err) {
      showToast('Неверный формат JSON файла', 'error');
    }
  };
  reader.readAsText(file);
}

// ─────────────────────────────────────────────────────────────────────────────
// Forms & Modal Handlers
// ─────────────────────────────────────────────────────────────────────────────

function initForms() {
  // Login Form
  document.getElementById('login-form').addEventListener('submit', (e) => {
    e.preventDefault();
    const pwd = document.getElementById('admin-password').value;
    handleLogin(pwd);
  });

  // Player Edit Form
  document.getElementById('player-edit-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const uid = document.getElementById('edit-uid').value;
    const body = {
      name: document.getElementById('edit-name').value.trim(),
      level: parseInt(document.getElementById('edit-level').value) || 1,
      exp: parseInt(document.getElementById('edit-exp').value) || 0,
      gold: parseInt(document.getElementById('edit-gold').value) || 0,
      diamond: parseInt(document.getElementById('edit-diamond').value) || 0,
      motto: document.getElementById('edit-motto').value.trim(),
      icon: parseInt(document.getElementById('edit-icon').value) || 0,
      icon_frame: parseInt(document.getElementById('edit-icon-frame').value) || 0,

      // Tiers, Season & Royal Mark
      rank_score: parseInt(document.getElementById('edit-rank-score').value) || 0,
      career_max_rank: parseInt(document.getElementById('edit-career-max-rank').value) || parseInt(document.getElementById('edit-rank-score').value) || 0,
      king_emblem: parseInt(document.getElementById('edit-king-emblem').value) || 0,
      rank_protect_score: parseInt(document.getElementById('edit-rank-protect-score').value) || 0,

      // All Modes Combat Statistics
      battle_kill: parseInt(document.getElementById('edit-kills').value) || 0,
      kills: parseInt(document.getElementById('edit-kills').value) || 0,
      battle_dead: parseInt(document.getElementById('edit-deaths').value) || 0,
      deaths: parseInt(document.getElementById('edit-deaths').value) || 0,
      battle_assist: parseInt(document.getElementById('edit-assists').value) || 0,
      assists: parseInt(document.getElementById('edit-assists').value) || 0,
      battle_times: parseInt(document.getElementById('edit-battle-times').value) || 0,
      total_matches: parseInt(document.getElementById('edit-battle-times').value) || 0,
      win_times: parseInt(document.getElementById('edit-win-times').value) || 0,
      wins: parseInt(document.getElementById('edit-win-times').value) || 0,
      battle_score: parseInt(document.getElementById('edit-battle-score').value) || 0,
      mvp_count: parseInt(document.getElementById('edit-mvp-count').value) || 0,
      headshots: parseInt(document.getElementById('edit-headshots').value) || 0,

      // Ranked Mode Statistics
      rank_kills: parseInt(document.getElementById('edit-rank-kills').value) || parseInt(document.getElementById('edit-kills').value) || 0,
      rank_deaths: parseInt(document.getElementById('edit-rank-deaths').value) || parseInt(document.getElementById('edit-deaths').value) || 0,
      rank_battles: parseInt(document.getElementById('edit-rank-battles').value) || parseInt(document.getElementById('edit-battle-times').value) || 0,
      rank_wins: parseInt(document.getElementById('edit-rank-wins').value) || parseInt(document.getElementById('edit-win-times').value) || 0
    };
    try {
      const res = await apiRequest(`/players/${uid}`, 'PUT', body);
      if (res.success) {
        showToast('Профиль и статистика успешно обновлены', 'success');
        closeModal('player-edit-modal');
        loadPlayers();
      } else {
        showToast(res.error || 'Ошибка сохранения профиля', 'error');
      }
    } catch (err) {
      showToast('Ошибка сохранения профиля', 'error');
    }
  });

  // Grant Item Form
  document.getElementById('grant-item-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const uid = document.getElementById('grant-uid').value;
    const body = {
      type: document.getElementById('grant-type').value,
      id: parseInt(document.getElementById('grant-id').value) || 0,
      count: parseInt(document.getElementById('grant-count').value) || 1
    };
    try {
      const res = await apiRequest(`/players/${uid}/grant_item`, 'POST', body);
      if (res.success) {
        showToast('Предмет успешно выдан!', 'success');
        closeModal('grant-item-modal');
        loadPlayers();
      }
    } catch (err) {
      showToast('Ошибка при выдаче предмета', 'error');
    }
  });

  // Create Player Form
  document.getElementById('create-player-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const uidVal = document.getElementById('create-uid').value.trim();
    const body = {
      name: document.getElementById('create-name').value.trim(),
      uid: uidVal ? parseInt(uidVal) : null,
      gold: parseInt(document.getElementById('create-gold').value) || 50000,
      diamond: parseInt(document.getElementById('create-diamond').value) || 1000
    };
    try {
      const res = await apiRequest('/players', 'POST', body);
      if (res.success) {
        showToast(`Аккаунт ${res.data.name} (UID ${res.data.uid}) создан!`, 'success');
        closeModal('create-player-modal');
        loadPlayers();
      } else {
        showToast(res.error, 'error');
      }
    } catch (err) {
      showToast('Ошибка создания аккаунта', 'error');
    }
  });

  // Mail Compose Form
  document.getElementById('mail-compose-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const gold = parseInt(document.getElementById('mail-reward-gold').value) || 0;
    const diamond = parseInt(document.getElementById('mail-reward-diamond').value) || 0;
    const rewards = [];
    if (gold > 0) rewards.push({ id: 10001, num: gold }); // 10001 Gold
    if (diamond > 0) rewards.push({ id: 10002, num: diamond }); // 10002 Diamond

    const body = {
      target_uid: document.getElementById('mail-target-uid').value.trim(),
      title: document.getElementById('mail-title').value.trim(),
      sender: document.getElementById('mail-sender').value.trim(),
      content: document.getElementById('mail-content').value.trim(),
      expire_days: 30,
      rewards
    };

    try {
      const res = await apiRequest('/mail/send', 'POST', body);
      if (res.success) {
        showToast(res.message || 'Письмо отправлено!', 'success');
        document.getElementById('mail-title').value = '';
        document.getElementById('mail-content').value = '';
      } else {
        showToast(res.error, 'error');
      }
    } catch (err) {
      showToast('Ошибка при отправке письма', 'error');
    }
  });

  // Chat Send Form
  document.getElementById('chat-send-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const body = {
      channel: document.getElementById('chat-channel').value,
      sender_name: document.getElementById('chat-sender-name').value.trim(),
      sender_uid: parseInt(document.getElementById('chat-sender-uid').value) || 0,
      content: document.getElementById('chat-message-text').value.trim()
    };

    try {
      const res = await apiRequest('/chat/send', 'POST', body);
      if (res.success) {
        showToast('Сообщение отправлено в чат!', 'success');
        document.getElementById('chat-message-text').value = '';
        loadChatHistory();
      }
    } catch (err) {
      showToast('Ошибка отправки в чат', 'error');
    }
  });

  // Settings Form
  document.getElementById('settings-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const pwd = document.getElementById('conf-admin-password').value.trim();
    const body = {
      server_tuning: {
        server_announcement: document.getElementById('conf-announcement').value.trim(),
        exp_multiplier: parseFloat(document.getElementById('conf-exp-mult').value) || 1.0,
        gold_multiplier: parseFloat(document.getElementById('conf-gold-mult').value) || 1.0,
        gm_enabled: document.getElementById('conf-gm-enabled').checked
      }
    };
    if (pwd) {
      body.admin_panel = { admin_password: pwd };
    }

    try {
      const res = await apiRequest('/system/config', 'POST', body);
      if (res.success) {
        showToast('Настройки сохранены', 'success');
        document.getElementById('conf-admin-password').value = '';
      }
    } catch (err) {
      showToast('Ошибка сохранения настроек', 'error');
    }
  });

  // Search & Filter listeners
  document.getElementById('player-search-input').addEventListener('input', debounce(loadPlayers, 300));
  document.getElementById('player-status-filter').addEventListener('change', loadPlayers);
}

// ─────────────────────────────────────────────────────────────────────────────
// Modal & Toast Utilities
// ─────────────────────────────────────────────────────────────────────────────

function openModal(id) {
  const el = document.getElementById(id);
  if (el) el.classList.add('active');
}

function closeModal(id) {
  const el = document.getElementById(id);
  if (el) el.classList.remove('active');
}

function showToast(message, type = 'info') {
  const container = document.getElementById('toast-container');
  const toast = document.createElement('div');
  toast.className = `toast toast-${type}`;
  toast.innerHTML = `<span>${escapeHtml(message)}</span>`;
  container.appendChild(toast);

  setTimeout(() => {
    toast.style.opacity = '0';
    toast.style.transform = 'translateX(100%)';
    setTimeout(() => toast.remove(), 300);
  }, 4000);
}

function escapeHtml(text) {
  if (!text) return '';
  const div = document.createElement('div');
  div.textContent = text;
  return div.innerHTML;
}

function debounce(func, wait) {
  let timeout;
  return function(...args) {
    clearTimeout(timeout);
    timeout = setTimeout(() => func.apply(this, args), wait);
  };
}
