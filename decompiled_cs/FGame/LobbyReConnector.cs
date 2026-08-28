namespace FGame
{

// Namespace: FGame
public class LobbyReConnector : BaseReConnector // TypeDefIndex: 9979
{
	// Fields
	private bool mWaitingRoomRsp; // 0x18
	private bool mWaitingBattleRsp; // 0x19
	private bool mWaitingTestState; // 0x1A

	// Methods

	// RVA: 0xF490A8 Offset: 0xF490A8 VA: 0xF490A8 Slot: 6
	public override void Update() { }

	// RVA: 0xF4A2D8 Offset: 0xF4A2D8 VA: 0xF4A2D8 Slot: 8
	protected override void LeaveState(BaseReConnector.ReConnState nextState) { }

	// RVA: 0xF4AE84 Offset: 0xF4AE84 VA: 0xF4AE84 Slot: 9
	protected override void EnterState(BaseReConnector.ReConnState lastState) { }

	// RVA: 0xF4BF64 Offset: 0xF4BF64 VA: 0xF4BF64
	private void OnChoosingRolesResponse(SprotoTypeBase msg) { }

	// RVA: 0xF4C050 Offset: 0xF4C050 VA: 0xF4C050
	private void OnGameRspBattleInfo(SprotoTypeBase msg) { }

	// RVA: 0xF49944 Offset: 0xF49944 VA: 0xF49944
	private void TryTestState() { }

	// RVA: 0xF4C710 Offset: 0xF4C710 VA: 0xF4C710
	public void .ctor() { }
}

} // namespace FGame
