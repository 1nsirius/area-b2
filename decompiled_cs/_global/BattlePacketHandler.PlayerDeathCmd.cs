// Namespace: 
private class BattlePacketHandler.PlayerDeathCmd : PacketCommand<RspPlayerDeath, BattlePacketHandler.PlayerDeathCmd> // TypeDefIndex: 11459
{
	// Fields
	private ScoutCar _lastScoutCar; // 0x10
	private SecurityCamera _lastMonitor; // 0x14
	private Character.HealthPoint _lastHp; // 0x18
	private ExposeState _lastExposeState; // 0x28

	// Methods

	// RVA: 0x95880C Offset: 0x95880C VA: 0x95880C Slot: 11
	public override void Redo() { }

	// RVA: 0x958B44 Offset: 0x958B44 VA: 0x958B44
	private void TryToPlayDeadEffect(RspPlayerDeath.Data data) { }

	// RVA: 0x958CB8 Offset: 0x958CB8 VA: 0x958CB8
	private void TryToClearMessage(RspPlayerDeath.Data data) { }

	// RVA: 0x958DD0 Offset: 0x958DD0 VA: 0x958DD0 Slot: 12
	public override void Undo() { }

	// RVA: 0x958ED0 Offset: 0x958ED0 VA: 0x958ED0
	public void .ctor() { }
}
