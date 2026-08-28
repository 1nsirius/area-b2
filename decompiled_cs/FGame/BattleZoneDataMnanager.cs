namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E18 Offset: 0x553E18 VA: 0x553E18
public class BattleZoneDataMnanager : BaseSingleton<BattleZoneDataMnanager> // TypeDefIndex: 9890
{
	// Fields
	private static readonly string sKeyAutoSelect; // 0x0
	private static readonly string sKeyBattleZoneId; // 0x4
	private PingCheckerProcesser mCheckerProcesser; // 0x8
	private float mLastHttpGetTime; // 0xC

	// Methods

	// RVA: 0xBECB18 Offset: 0xBECB18 VA: 0xBECB18
	public void Initialize() { }

	// RVA: 0xBECE8C Offset: 0xBECE8C VA: 0xBECE8C
	public void Upadte() { }

	// RVA: 0xBED1B8 Offset: 0xBED1B8 VA: 0xBED1B8
	public void StartCheckPing() { }

	// RVA: 0xBED258 Offset: 0xBED258 VA: 0xBED258
	public void ShutSown() { }

	// RVA: 0xBED518 Offset: 0xBED518 VA: 0xBED518
	private void HandleOnAutoSelectChange(bool auto) { }

	// RVA: 0xBED5B4 Offset: 0xBED5B4 VA: 0xBED5B4
	private void HandleOnBattleZoneChange(uint battleZoneId) { }

	// RVA: 0xBED650 Offset: 0xBED650 VA: 0xBED650
	private void OnRspBattleZoneList(SprotoTypeBase msg) { }

	// RVA: 0xBEDCC0 Offset: 0xBEDCC0 VA: 0xBEDCC0
	private void OnNtfBattleZoneList(SprotoTypeBase msg) { }

	// RVA: 0xBEDF10 Offset: 0xBEDF10 VA: 0xBEDF10
	private void OnReqRoomChangeBattleZone(SprotoTypeBase msg) { }

	// RVA: 0xBEE1BC Offset: 0xBEE1BC VA: 0xBEE1BC
	private void OnTeamChangeBattleZoneTeamReq(SprotoTypeBase msg) { }

	// RVA: 0xBED8D8 Offset: 0xBED8D8 VA: 0xBED8D8
	private void RefillBattleZoneList(List<game.BattleZone> battleZonds) { }

	// RVA: 0xBEDBA4 Offset: 0xBEDBA4 VA: 0xBEDBA4
	private static void PrintException(SprotoTypeBase msg, Exception e) { }

	// RVA: 0xBEE41C Offset: 0xBEE41C VA: 0xBEE41C
	public void .ctor() { }

	// RVA: 0xBEE4B4 Offset: 0xBEE4B4 VA: 0xBEE4B4
	private static void .cctor() { }
}

} // namespace FGame
