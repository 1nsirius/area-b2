namespace FGame
{

// Namespace: FGame
public enum EFsmType // TypeDefIndex: 9959
{
	// Fields
	public int value__; // 0x0
	public const EFsmType ON_APPLICATION_PAUSE = -100;
	public const EFsmType ON_APPLICATION_QUIT = -101;
	public const EFsmType CONNECTING_AND_LOGIN_LOBBY = -10;
	public const EFsmType CONNECT_LOBBY_SERVER_CONNECTED = -9;
	public const EFsmType LOAD_ROLE = -8;
	public const EFsmType CREATE_ROLE = -7;
	public const EFsmType CHANGE_NAME = -6;
	public const EFsmType ACTIVE_ROLE = -5;
	public const EFsmType CONNECT_LOBBYSERVER_ERROR = 1;
	public const EFsmType LOGIN_LOBBY_SERVER_FAILURE = 3;
	public const EFsmType ON_DISCONNECTED_FROM_LOBBY_SERVER = 4;
	public const EFsmType LOBBY_BeginMatch = 5;
	public const EFsmType LOBBY_EndMatch = 6;
	public const EFsmType LOBBY_CLICK_MATCH = 7;
	public const EFsmType ON_CONNECT_LOBBY_SERVER_ERROR = 8;
	public const EFsmType ON_CHANGE_ROLE = 9;
	public const EFsmType RSP_OPEN_MODE = 10;
	public const EFsmType ENTER_LEVELLOADINGSTATE = 11;
	public const EFsmType SCHEME_URLOPEN = 12;
	public const EFsmType LobbyToNormal = 13;
	public const EFsmType SelfLeaveRoom = 14;
	public const EFsmType ReturnToTeam = 15;
	public const EFsmType OnSyncTeamData = 16;
	public const EFsmType GAMEFACADE_ON_BIND = 101;
	public const EFsmType REQ_START_GAME = 102;
	public const EFsmType TRY_TO_CONNECT_TO_BATTLE_SERVER = 103;
	public const EFsmType CONNECT_TO_BATTLE_SERVER_SUCCESSFUL = 104;
	public const EFsmType LOAD_MAP = 105;
	public const EFsmType ExitPreBattle = 107;
	public const EFsmType RspUserGuideRoundStart = 108;
	public const EFsmType Recruit = 109;
	public const EFsmType InviteBattle = 110;
	public const EFsmType GAME_BATTLE_START = 201;
	public const EFsmType GAME_BATTLE_UI_OPEN = 202;
	public const EFsmType GAME_BATTLE_RESULT = 203;
	public const EFsmType ON_DISCONNECTED_FROM_BATTLE_SERVER = 205;
	public const EFsmType DISCONNECTED_QUIT_BATTLE = 206;
	public const EFsmType BATTLE_OVER = 207;
	public const EFsmType SELECT_CHARACTER = 301;
	public const EFsmType ForceLoginOut = 401;
	public const EFsmType ForceToLobby = 402;
	public const EFsmType CSharpMessage = 403;
	public const EFsmType ForceToNaming = 404;
	public const EFsmType ForceToWaitForRestartBattle = 405;
	public const EFsmType ForceToMVP = 406;
}

} // namespace FGame
