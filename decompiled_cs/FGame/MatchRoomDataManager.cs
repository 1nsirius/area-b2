namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553F8C Offset: 0x553F8C VA: 0x553F8C
public class MatchRoomDataManager : BaseSingleton<MatchRoomDataManager> // TypeDefIndex: 9928
{
	// Methods

	// RVA: 0xF455D0 Offset: 0xF455D0 VA: 0xF455D0
	public void Initialize() { }

	// RVA: 0xF5C12C Offset: 0xF5C12C VA: 0xF5C12C
	private void OnEnterMatchNtf(SprotoTypeBase msg) { }

	// RVA: 0xF5C4E4 Offset: 0xF5C4E4 VA: 0xF5C4E4
	private void OnChangeBattleZone(SprotoTypeBase msg) { }

	// RVA: 0xF5C714 Offset: 0xF5C714 VA: 0xF5C714
	private void OnCancelMatchNtf(SprotoTypeBase msg) { }

	// RVA: 0xF5CB98 Offset: 0xF5CB98 VA: 0xF5CB98
	public void SendChangeReadyStateReq() { }

	// RVA: 0xF5CCE4 Offset: 0xF5CCE4 VA: 0xF5CCE4
	public void SendCreateRoomReq() { }

	// RVA: 0xF5CE58 Offset: 0xF5CE58 VA: 0xF5CE58
	public void SendCreateRankRoomReq() { }

	// RVA: 0xF5CFCC Offset: 0xF5CFCC VA: 0xF5CFCC
	public void SendExitRoomReq() { }

	// RVA: 0xF5D074 Offset: 0xF5D074 VA: 0xF5D074
	public void SendInviteReplayReq(uint inviterUid, bool agree) { }

	// RVA: 0xF5D24C Offset: 0xF5D24C VA: 0xF5D24C
	public void SendInviteRefuseAllReq() { }

	// RVA: 0xF5D4A4 Offset: 0xF5D4A4 VA: 0xF5D4A4
	public void SendKickReq(int pos, uint kickUid) { }

	// RVA: 0xF5D5BC Offset: 0xF5D5BC VA: 0xF5D5BC
	public void SendStartMatch() { }

	// RVA: 0xF429D4 Offset: 0xF429D4 VA: 0xF429D4
	public void Shutdown() { }

	// RVA: 0xF5D6CC Offset: 0xF5D6CC VA: 0xF5D6CC
	private void OnInviteRefuseNtf(SprotoTypeBase msg) { }

	// RVA: 0xF5D954 Offset: 0xF5D954 VA: 0xF5D954
	private void OnKickMemberRsp(SprotoTypeBase msg) { }

	// RVA: 0xF5DB84 Offset: 0xF5DB84 VA: 0xF5DB84
	private void OnMatchConfirmNtf(SprotoTypeBase msg) { }

	// RVA: 0xF5DE00 Offset: 0xF5DE00 VA: 0xF5DE00
	private void OnMatchTimeOutNtf(SprotoTypeBase msg) { }

	// RVA: 0xF5E0D0 Offset: 0xF5E0D0 VA: 0xF5E0D0
	private void OnPlayerOperateReadyRsp(SprotoTypeBase msg) { }

	// RVA: 0xF5C3C8 Offset: 0xF5C3C8 VA: 0xF5C3C8
	private static void PrintException(SprotoTypeBase msg, Exception e) { }

	// RVA: 0xF5E300 Offset: 0xF5E300 VA: 0xF5E300
	public void .ctor() { }
}

} // namespace FGame
