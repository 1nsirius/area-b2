namespace FGame
{

// Namespace: FGame
public sealed class BattleStateDataManager : BaseSingleton<BattleStateDataManager> // TypeDefIndex: 9887
{
	// Fields
	public HallBattleState BattleState; // 0x8
	private game.RspSyncHallBattleState.request mBattleStateCache; // 0xC
	private bool mBattelKickOut; // 0x10
	private bool mBattleIsFinish; // 0x11

	// Properties
	public bool BattelKickOut { get; set; }
	public bool BattleIsFinish { get; set; }

	// Methods

	// RVA: 0xBEA3DC Offset: 0xBEA3DC VA: 0xBEA3DC
	public bool IsInTeam() { }

	// RVA: 0xBEA400 Offset: 0xBEA400 VA: 0xBEA400
	public void set_BattelKickOut(bool value) { }

	// RVA: 0xBEA4BC Offset: 0xBEA4BC VA: 0xBEA4BC
	public bool get_BattelKickOut() { }

	// RVA: 0xBEA4C4 Offset: 0xBEA4C4 VA: 0xBEA4C4
	public void set_BattleIsFinish(bool value) { }

	// RVA: 0xBEA584 Offset: 0xBEA584 VA: 0xBEA584
	public bool get_BattleIsFinish() { }

	// RVA: 0xBEA58C Offset: 0xBEA58C VA: 0xBEA58C
	public void Initialize() { }

	// RVA: 0xBEA75C Offset: 0xBEA75C VA: 0xBEA75C
	public void Shutdown() { }

	// RVA: 0xBEA92C Offset: 0xBEA92C VA: 0xBEA92C
	public bool IsBattleStart() { }

	// RVA: 0xBEA954 Offset: 0xBEA954 VA: 0xBEA954
	public bool IsChoosingRoles() { }

	// RVA: 0xBEA968 Offset: 0xBEA968 VA: 0xBEA968
	public bool IsChooseName() { }

	// RVA: 0xBEA978 Offset: 0xBEA978 VA: 0xBEA978
	public bool IsInHall() { }

	// RVA: 0xBE8B04 Offset: 0xBE8B04 VA: 0xBE8B04
	public bool CanConnectBattle() { }

	// RVA: 0xBEA98C Offset: 0xBEA98C VA: 0xBEA98C
	private void OnReqSyncHallBattleState(SprotoTypeBase msg) { }

	// RVA: 0xBEB2E0 Offset: 0xBEB2E0 VA: 0xBEB2E0
	private void OnGameStateChange(string state) { }

	// RVA: 0xBEB2F0 Offset: 0xBEB2F0 VA: 0xBEB2F0
	private void OnGameingStateChange(string state) { }

	// RVA: 0xBEB6B4 Offset: 0xBEB6B4 VA: 0xBEB6B4
	public void .ctor() { }
}

} // namespace FGame
