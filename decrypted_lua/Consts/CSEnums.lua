CS_BattleCamp = CS.proto.common.BattleCamp
BattleCamp =
{
	NoCamp = 0,
	Attacker = 1,
	Defender = 2,
    
    csEnumMap = 
    {
        [CS_BattleCamp.NoCamp] = 0,
        [CS_BattleCamp.Attacker] = 1,
        [CS_BattleCamp.Defender] = 2,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_GameStage = CS.proto.common.GameStage
GameStage =
{
	Prepare = 1,
	Battle = 2,
	BombContend = 6,
    
    csEnumMap = 
    {
        [CS_GameStage.Prepare] = 1,
        [CS_GameStage.Battle] = 2,
        [CS_GameStage.BombContend] = 6,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_CriticalRegionState = CS.proto.common.CriticalRegionState
CriticalRegionState =
{
	NonePlayers = 0,
	OnlyAttackers = 1,
	OnlyDefenders = 2,
	BothPlayers = 3,
    
    csEnumMap = 
    {
        [CS_CriticalRegionState.NonePlayers] = 0,
        [CS_CriticalRegionState.OnlyAttackers] = 1,
        [CS_CriticalRegionState.OnlyDefenders] = 2,
        [CS_CriticalRegionState.BothPlayers] = 3,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_HallBattleState = CS.SprotoSprotoType.HallBattleState
HallBattleState =
{
	Offline = 0,
	InChooseName = 1,
	InHall = 2,
	InMatch = 3,
	InRoom = 4,
	InTeam = 5,
	InBattleNotStart = 6,
	InBattleStarted = 7,
    
    csEnumMap = 
    {
        [CS_HallBattleState.Offline] = 0,
        [CS_HallBattleState.InChooseName] = 1,
        [CS_HallBattleState.InHall] = 2,
        [CS_HallBattleState.InMatch] = 3,
        [CS_HallBattleState.InRoom] = 4,
        [CS_HallBattleState.InTeam] = 5,
        [CS_HallBattleState.InBattleNotStart] = 6,
        [CS_HallBattleState.InBattleStarted] = 7,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_QualityLevel = CS.FCommon.QualityLevel
QualityLevel =
{
	VeryLow = 0,
	Low = 1,
	Medium = 2,
	High = 3,
    
    csEnumMap = 
    {
        [CS_QualityLevel.VeryLow] = 0,
        [CS_QualityLevel.Low] = 1,
        [CS_QualityLevel.Medium] = 2,
        [CS_QualityLevel.High] = 3,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_BattleGameOverReason = CS.proto.common.BattleGameOverReason
BattleGameOverReason =
{
	AttackerKillDefender = 0,
	DefenderKillAttacker = 1,
	CriticalSuccess = 2,
	TimeOut = 3,
	SelfLeave = 4,
	RestartMode = 5,
	ReloadMap = 6,
	DefuserTimeOut = 7,
	DefuserCracked = 8,
	DefuserDestroyed = 9,
	BombTimeOut = 10,
    
    csEnumMap = 
    {
        [CS_BattleGameOverReason.AttackerKillDefender] = 0,
        [CS_BattleGameOverReason.DefenderKillAttacker] = 1,
        [CS_BattleGameOverReason.CriticalSuccess] = 2,
        [CS_BattleGameOverReason.TimeOut] = 3,
        [CS_BattleGameOverReason.SelfLeave] = 4,
        [CS_BattleGameOverReason.RestartMode] = 5,
        [CS_BattleGameOverReason.ReloadMap] = 6,
        [CS_BattleGameOverReason.DefuserTimeOut] = 7,
        [CS_BattleGameOverReason.DefuserCracked] = 8,
        [CS_BattleGameOverReason.DefuserDestroyed] = 9,
        [CS_BattleGameOverReason.BombTimeOut] = 10,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_CombatType = CS.SprotoSprotoType.CombatType
CombatType =
{
	normal_mode = 1,
	rank_mode = 2,
	rookie_mode = 3,
	room_mode = 4,
	userguide_mode = 5,
	train_mode = 6,
	newcomer_mode = 7,
    
    csEnumMap = 
    {
        [CS_CombatType.normal_mode] = 1,
        [CS_CombatType.rank_mode] = 2,
        [CS_CombatType.rookie_mode] = 3,
        [CS_CombatType.room_mode] = 4,
        [CS_CombatType.userguide_mode] = 5,
        [CS_CombatType.train_mode] = 6,
        [CS_CombatType.newcomer_mode] = 7,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_RoleStatsInfo = CS.SprotoSprotoType.RoleStatsInfo
RoleStatsInfo =
{
	king_emblem = 1,
	career_max_rank = 2,
	current_season_id = 3,
	guide_id_opened = 4,
	guide_id_finished = 5,
	first_recharge = 6,
	show_character_id = 7,
	last_change_name_ts = 8,
	icon_frame_unlock_state = 9,
	punish_score = 10,
	punish_history_cnt = 11,
	day_refresh_ts = 12,
	acc_login_days = 13,
	week_refresh_ts = 14,
	last_share_ts = 15,
	battle_box_rate = 16,
	total_recharge_count = 17,
	ban_leaderboard_ts = 18,
	advertising_switch = 19,
    
    csEnumMap = 
    {
        [CS_RoleStatsInfo.king_emblem] = 1,
        [CS_RoleStatsInfo.career_max_rank] = 2,
        [CS_RoleStatsInfo.current_season_id] = 3,
        [CS_RoleStatsInfo.guide_id_opened] = 4,
        [CS_RoleStatsInfo.guide_id_finished] = 5,
        [CS_RoleStatsInfo.first_recharge] = 6,
        [CS_RoleStatsInfo.show_character_id] = 7,
        [CS_RoleStatsInfo.last_change_name_ts] = 8,
        [CS_RoleStatsInfo.icon_frame_unlock_state] = 9,
        [CS_RoleStatsInfo.punish_score] = 10,
        [CS_RoleStatsInfo.punish_history_cnt] = 11,
        [CS_RoleStatsInfo.day_refresh_ts] = 12,
        [CS_RoleStatsInfo.acc_login_days] = 13,
        [CS_RoleStatsInfo.week_refresh_ts] = 14,
        [CS_RoleStatsInfo.last_share_ts] = 15,
        [CS_RoleStatsInfo.battle_box_rate] = 16,
        [CS_RoleStatsInfo.total_recharge_count] = 17,
        [CS_RoleStatsInfo.ban_leaderboard_ts] = 18,
        [CS_RoleStatsInfo.advertising_switch] = 19,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_BattleStatsInfo = CS.SprotoSprotoType.BattleStatsInfo
BattleStatsInfo =
{
	num = 1,
	win_num = 2,
	round_num = 3,
	score = 4,
	kill_num = 5,
	dead_num = 6,
	assist_num = 7,
	help_num = 8,
	be_helped_num = 9,
	mvp_num = 10,
	attack_num = 11,
	attack_win_num = 12,
	defend_num = 13,
	defend_win_num = 14,
	shoot_num = 15,
	head_shot_num = 16,
	melee_kill_num = 17,
	penetrate_kill_num = 18,
	combo_win = 19,
	hit_down_num = 20,
	alive_rate = 21,
	max_kill_num = 22,
    
    csEnumMap = 
    {
        [CS_BattleStatsInfo.num] = 1,
        [CS_BattleStatsInfo.win_num] = 2,
        [CS_BattleStatsInfo.round_num] = 3,
        [CS_BattleStatsInfo.score] = 4,
        [CS_BattleStatsInfo.kill_num] = 5,
        [CS_BattleStatsInfo.dead_num] = 6,
        [CS_BattleStatsInfo.assist_num] = 7,
        [CS_BattleStatsInfo.help_num] = 8,
        [CS_BattleStatsInfo.be_helped_num] = 9,
        [CS_BattleStatsInfo.mvp_num] = 10,
        [CS_BattleStatsInfo.attack_num] = 11,
        [CS_BattleStatsInfo.attack_win_num] = 12,
        [CS_BattleStatsInfo.defend_num] = 13,
        [CS_BattleStatsInfo.defend_win_num] = 14,
        [CS_BattleStatsInfo.shoot_num] = 15,
        [CS_BattleStatsInfo.head_shot_num] = 16,
        [CS_BattleStatsInfo.melee_kill_num] = 17,
        [CS_BattleStatsInfo.penetrate_kill_num] = 18,
        [CS_BattleStatsInfo.combo_win] = 19,
        [CS_BattleStatsInfo.hit_down_num] = 20,
        [CS_BattleStatsInfo.alive_rate] = 21,
        [CS_BattleStatsInfo.max_kill_num] = 22,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_LeaderboardType = CS.SprotoSprotoType.LeaderboardType
LeaderboardType =
{
	leaderboard_level = 1,
	leaderboard_rank = 2,
	leaderboard_character = 3,
	leaderboard_skin = 4,
    
    csEnumMap = 
    {
        [CS_LeaderboardType.leaderboard_level] = 1,
        [CS_LeaderboardType.leaderboard_rank] = 2,
        [CS_LeaderboardType.leaderboard_character] = 3,
        [CS_LeaderboardType.leaderboard_skin] = 4,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_SeasonStat = CS.SprotoSprotoType.SeasonStat
SeasonStat =
{
	rank_score = 101,
	max_rank_score = 102,
	rank_award_flag = 103,
	rank_protect_score = 104,
	is_handle_reward = 105,
	rank_god_flag = 106,
	is_reach_rank_max = 107,
	first_five_match_result = 108,
    
    csEnumMap = 
    {
        [CS_SeasonStat.rank_score] = 101,
        [CS_SeasonStat.max_rank_score] = 102,
        [CS_SeasonStat.rank_award_flag] = 103,
        [CS_SeasonStat.rank_protect_score] = 104,
        [CS_SeasonStat.is_handle_reward] = 105,
        [CS_SeasonStat.rank_god_flag] = 106,
        [CS_SeasonStat.is_reach_rank_max] = 107,
        [CS_SeasonStat.first_five_match_result] = 108,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_IconUnlockState = CS.SprotoSprotoType.IconUnlockState
IconUnlockState =
{
	state = 1,
	state2 = 2,
    
    csEnumMap = 
    {
        [CS_IconUnlockState.state] = 1,
        [CS_IconUnlockState.state2] = 2,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_BattleMode = CS.SprotoSprotoType.BattleMode
BattleMode =
{
	ELIMINATE_THREAT = 1,
	ELIMINATE_THREAT_USER_GUIDE = 2,
	TRAIN_MODE = 3,
	BOMB_MODE = 4,
    
    csEnumMap = 
    {
        [CS_BattleMode.ELIMINATE_THREAT] = 1,
        [CS_BattleMode.ELIMINATE_THREAT_USER_GUIDE] = 2,
        [CS_BattleMode.TRAIN_MODE] = 3,
        [CS_BattleMode.BOMB_MODE] = 4,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}

CS_EFsmType = CS.FGame.EFsmType
EFsmType =
{
	CONNECT_LOBBYSERVER_ERROR = 1,
	LOGIN_LOBBY_SERVER_FAILURE = 3,
	ON_DISCONNECTED_FROM_LOBBY_SERVER = 4,
	LOBBY_BeginMatch = 5,
	LOBBY_EndMatch = 6,
	LOBBY_CLICK_MATCH = 7,
	ON_CONNECT_LOBBY_SERVER_ERROR = 8,
	ON_CHANGE_ROLE = 9,
	RSP_OPEN_MODE = 10,
	ENTER_LEVELLOADINGSTATE = 11,
	SCHEME_URLOPEN = 12,
	LobbyToNormal = 13,
	SelfLeaveRoom = 14,
	ReturnToTeam = 15,
	OnSyncTeamData = 16,
	GAMEFACADE_ON_BIND = 101,
	REQ_START_GAME = 102,
	TRY_TO_CONNECT_TO_BATTLE_SERVER = 103,
	CONNECT_TO_BATTLE_SERVER_SUCCESSFUL = 104,
	LOAD_MAP = 105,
	ExitPreBattle = 107,
	RspUserGuideRoundStart = 108,
	Recruit = 109,
	InviteBattle = 110,
	GAME_BATTLE_START = 201,
	GAME_BATTLE_UI_OPEN = 202,
	GAME_BATTLE_RESULT = 203,
	ON_DISCONNECTED_FROM_BATTLE_SERVER = 205,
	DISCONNECTED_QUIT_BATTLE = 206,
	BATTLE_OVER = 207,
	SELECT_CHARACTER = 301,
	ForceLoginOut = 401,
	ForceToLobby = 402,
	CSharpMessage = 403,
	ForceToNaming = 404,
	ForceToWaitForRestartBattle = 405,
	ForceToMVP = 406,
	ON_APPLICATION_QUIT = -101,
	ON_APPLICATION_PAUSE = -100,
	CONNECTING_AND_LOGIN_LOBBY = -10,
	CONNECT_LOBBY_SERVER_CONNECTED = -9,
	LOAD_ROLE = -8,
	CREATE_ROLE = -7,
	CHANGE_NAME = -6,
	ACTIVE_ROLE = -5,
    
    csEnumMap = 
    {
        [CS_EFsmType.CONNECT_LOBBYSERVER_ERROR] = 1,
        [CS_EFsmType.LOGIN_LOBBY_SERVER_FAILURE] = 3,
        [CS_EFsmType.ON_DISCONNECTED_FROM_LOBBY_SERVER] = 4,
        [CS_EFsmType.LOBBY_BeginMatch] = 5,
        [CS_EFsmType.LOBBY_EndMatch] = 6,
        [CS_EFsmType.LOBBY_CLICK_MATCH] = 7,
        [CS_EFsmType.ON_CONNECT_LOBBY_SERVER_ERROR] = 8,
        [CS_EFsmType.ON_CHANGE_ROLE] = 9,
        [CS_EFsmType.RSP_OPEN_MODE] = 10,
        [CS_EFsmType.ENTER_LEVELLOADINGSTATE] = 11,
        [CS_EFsmType.SCHEME_URLOPEN] = 12,
        [CS_EFsmType.LobbyToNormal] = 13,
        [CS_EFsmType.SelfLeaveRoom] = 14,
        [CS_EFsmType.ReturnToTeam] = 15,
        [CS_EFsmType.OnSyncTeamData] = 16,
        [CS_EFsmType.GAMEFACADE_ON_BIND] = 101,
        [CS_EFsmType.REQ_START_GAME] = 102,
        [CS_EFsmType.TRY_TO_CONNECT_TO_BATTLE_SERVER] = 103,
        [CS_EFsmType.CONNECT_TO_BATTLE_SERVER_SUCCESSFUL] = 104,
        [CS_EFsmType.LOAD_MAP] = 105,
        [CS_EFsmType.ExitPreBattle] = 107,
        [CS_EFsmType.RspUserGuideRoundStart] = 108,
        [CS_EFsmType.Recruit] = 109,
        [CS_EFsmType.InviteBattle] = 110,
        [CS_EFsmType.GAME_BATTLE_START] = 201,
        [CS_EFsmType.GAME_BATTLE_UI_OPEN] = 202,
        [CS_EFsmType.GAME_BATTLE_RESULT] = 203,
        [CS_EFsmType.ON_DISCONNECTED_FROM_BATTLE_SERVER] = 205,
        [CS_EFsmType.DISCONNECTED_QUIT_BATTLE] = 206,
        [CS_EFsmType.BATTLE_OVER] = 207,
        [CS_EFsmType.SELECT_CHARACTER] = 301,
        [CS_EFsmType.ForceLoginOut] = 401,
        [CS_EFsmType.ForceToLobby] = 402,
        [CS_EFsmType.CSharpMessage] = 403,
        [CS_EFsmType.ForceToNaming] = 404,
        [CS_EFsmType.ForceToWaitForRestartBattle] = 405,
        [CS_EFsmType.ForceToMVP] = 406,
        [CS_EFsmType.ON_APPLICATION_QUIT] = -101,
        [CS_EFsmType.ON_APPLICATION_PAUSE] = -100,
        [CS_EFsmType.CONNECTING_AND_LOGIN_LOBBY] = -10,
        [CS_EFsmType.CONNECT_LOBBY_SERVER_CONNECTED] = -9,
        [CS_EFsmType.LOAD_ROLE] = -8,
        [CS_EFsmType.CREATE_ROLE] = -7,
        [CS_EFsmType.CHANGE_NAME] = -6,
        [CS_EFsmType.ACTIVE_ROLE] = -5,
    },
    
    Value = function (self, key)
        return self.csEnumMap[key]
    end
}