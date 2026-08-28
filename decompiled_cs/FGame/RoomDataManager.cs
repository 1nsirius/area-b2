namespace FGame
{

// Namespace: FGame
public sealed class RoomDataManager : BaseSingleton<RoomDataManager> // TypeDefIndex: 9946
{
	// Fields
	public string BattleToken; // 0x8

	// Methods

	// RVA: 0xB8279C Offset: 0xB8279C VA: 0xB8279C
	public void Initialize() { }

	// RVA: 0xB82F58 Offset: 0xB82F58 VA: 0xB82F58
	public void Shutdown() { }

	// RVA: 0xB83714 Offset: 0xB83714 VA: 0xB83714
	private void OnRspRoomEntered(SprotoTypeBase msg) { }

	// RVA: 0xB83A78 Offset: 0xB83A78 VA: 0xB83A78
	private void OnRspJoinRoomState(SprotoTypeBase msg) { }

	// RVA: 0xB83CE0 Offset: 0xB83CE0 VA: 0xB83CE0
	private void OnRspRoomPlayerLeaved(SprotoTypeBase msg) { }

	// RVA: 0xB83F4C Offset: 0xB83F4C VA: 0xB83F4C
	private void OnRspRoomPlayerEntered(SprotoTypeBase msg) { }

	// RVA: 0xB841B8 Offset: 0xB841B8 VA: 0xB841B8
	private void OnRspRoomOwnerChanged(SprotoTypeBase msg) { }

	// RVA: 0xB8449C Offset: 0xB8449C VA: 0xB8449C
	private void OnRspChangeCampSuccess(SprotoTypeBase msg) { }

	// RVA: 0xB84708 Offset: 0xB84708 VA: 0xB84708
	private void OnRspChangeCampFailure(SprotoTypeBase msg) { }

	// RVA: 0xB84974 Offset: 0xB84974 VA: 0xB84974
	private void OnRspRoomStart(SprotoTypeBase msg) { }

	// RVA: 0xB85380 Offset: 0xB85380 VA: 0xB85380
	private void OnRspEnterPreBattleStage(SprotoTypeBase msg) { }

	// RVA: 0xB8574C Offset: 0xB8574C VA: 0xB8574C
	private void OnRspChooseSpawnRegionConfirm(SprotoTypeBase msg) { }

	// RVA: 0xB859EC Offset: 0xB859EC VA: 0xB859EC
	private void OnRspChooseCharacter(SprotoTypeBase msg) { }

	// RVA: 0xB85ED8 Offset: 0xB85ED8 VA: 0xB85ED8
	private void OnRspChooseWeapon(SprotoTypeBase msg) { }

	// RVA: 0xB860BC Offset: 0xB860BC VA: 0xB860BC
	private void OnRspChooseWeaponInfo(SprotoTypeBase msg) { }

	// RVA: 0xB862A0 Offset: 0xB862A0 VA: 0xB862A0
	private void OnRspBattleInfo(SprotoTypeBase msg) { }

	// RVA: 0xB8713C Offset: 0xB8713C VA: 0xB8713C
	private void OnRspPlayersResult(SprotoTypeBase msg) { }

	// RVA: 0xB87254 Offset: 0xB87254 VA: 0xB87254
	private void OnRspPlayerOnlineState(SprotoTypeBase msg) { }

	// RVA: 0xB873D0 Offset: 0xB873D0 VA: 0xB873D0
	private void OnRspOnLineNumber(SprotoTypeBase msg) { }

	// RVA: 0xB8763C Offset: 0xB8763C VA: 0xB8763C
	private void OnRspBattlePoints(SprotoTypeBase msg) { }

	// RVA: 0xB87754 Offset: 0xB87754 VA: 0xB87754
	private void OnRspMatchBattleState(SprotoTypeBase msg) { }

	// RVA: 0xB879C0 Offset: 0xB879C0 VA: 0xB879C0
	private void OnRspVoiceChannel(SprotoTypeBase msg) { }

	// RVA: 0xB87C2C Offset: 0xB87C2C VA: 0xB87C2C
	private void OnRspChangeVoiceState(SprotoTypeBase msg) { }

	// RVA: 0xB87DAC Offset: 0xB87DAC VA: 0xB87DAC
	private void OnRspPreBattleInfo(SprotoTypeBase msg) { }

	// RVA: 0xB885A4 Offset: 0xB885A4 VA: 0xB885A4
	private void OnExchangePosNtf(SprotoTypeBase msg) { }

	// RVA: 0xB88CBC Offset: 0xB88CBC VA: 0xB88CBC
	private void OnExchangePosRsp(SprotoTypeBase msg) { }

	// RVA: 0xB88F94 Offset: 0xB88F94 VA: 0xB88F94
	private void OnKickRsp(SprotoTypeBase msg) { }

	// RVA: 0xB891C8 Offset: 0xB891C8 VA: 0xB891C8
	private void OnPosExchangeInviteNtf(SprotoTypeBase msg) { }

	// RVA: 0xB89608 Offset: 0xB89608 VA: 0xB89608
	private static void OnExchangeRefuseNtf(SprotoTypeBase msg) { }

	// RVA: 0xB88A48 Offset: 0xB88A48 VA: 0xB88A48
	private static void PrintException(SprotoTypeBase msg, Exception e) { }

	// RVA: 0xB89890 Offset: 0xB89890 VA: 0xB89890
	private void OnRspBombModeOperatorBombResult(SprotoTypeBase msg) { }

	// RVA: 0xB89C0C Offset: 0xB89C0C VA: 0xB89C0C
	private void OnChangeBattleZone(SprotoTypeBase msg) { }

	// RVA: 0xB89E88 Offset: 0xB89E88 VA: 0xB89E88
	private void OnRspChooseMap(SprotoTypeBase msg) { }

	// RVA: 0xB8A1BC Offset: 0xB8A1BC VA: 0xB8A1BC
	public void .ctor() { }
}

} // namespace FGame
