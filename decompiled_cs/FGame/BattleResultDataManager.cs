namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553DF0 Offset: 0x553DF0 VA: 0x553DF0
public sealed class BattleResultDataManager : BaseSingleton<BattleResultDataManager> // TypeDefIndex: 9883
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x563464 Offset: 0x563464 VA: 0x563464
	private game.RspBattleFinalResult.request <BattleFinalResult>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563474 Offset: 0x563474 VA: 0x563474
	private Action OnBattleFinalResult; // 0xC

	// Properties
	public game.RspBattleFinalResult.request BattleFinalResult { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646CC0 Offset: 0x646CC0 VA: 0x646CC0
	// RVA: 0xBE9308 Offset: 0xBE9308 VA: 0xBE9308
	public game.RspBattleFinalResult.request get_BattleFinalResult() { }

	[CompilerGeneratedAttribute] // RVA: 0x646CD0 Offset: 0x646CD0 VA: 0x646CD0
	// RVA: 0xBE9310 Offset: 0xBE9310 VA: 0xBE9310
	private void set_BattleFinalResult(game.RspBattleFinalResult.request value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646CE0 Offset: 0x646CE0 VA: 0x646CE0
	// RVA: 0xBE9318 Offset: 0xBE9318 VA: 0xBE9318
	public void add_OnBattleFinalResult(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646CF0 Offset: 0x646CF0 VA: 0x646CF0
	// RVA: 0xBE9424 Offset: 0xBE9424 VA: 0xBE9424
	public void remove_OnBattleFinalResult(Action value) { }

	// RVA: 0xBE9530 Offset: 0xBE9530 VA: 0xBE9530
	public void Initialize() { }

	// RVA: 0xBE953C Offset: 0xBE953C VA: 0xBE953C
	public void OnGameEnd(game.RspBattleFinalResult.request request) { }

	// RVA: 0xBE9544 Offset: 0xBE9544 VA: 0xBE9544
	public bool IsWin(long accountID) { }

	// RVA: 0xBE966C Offset: 0xBE966C VA: 0xBE966C
	public void ResetData() { }

	// RVA: 0xBE9678 Offset: 0xBE9678 VA: 0xBE9678
	public void Shutdown() { }

	// RVA: 0xBE9684 Offset: 0xBE9684 VA: 0xBE9684
	private void OnRspBattleFinalResult(SprotoTypeBase msg) { }

	// RVA: 0xBE9734 Offset: 0xBE9734 VA: 0xBE9734
	public void .ctor() { }
}

} // namespace FGame
