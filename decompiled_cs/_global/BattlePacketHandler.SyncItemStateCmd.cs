// Namespace: 
private class BattlePacketHandler.SyncItemStateCmd : PacketCommand<RspSyncItemState, BattlePacketHandler.SyncItemStateCmd> // TypeDefIndex: 11481
{
	// Properties
	public override bool NeedRecord { get; }

	// Methods

	// RVA: 0x95EBC4 Offset: 0x95EBC4 VA: 0x95EBC4 Slot: 10
	public override bool get_NeedRecord() { }

	// RVA: 0x95EBCC Offset: 0x95EBCC VA: 0x95EBCC Slot: 11
	public override void Redo() { }

	// RVA: 0x95EF20 Offset: 0x95EF20 VA: 0x95EF20
	private IBuffStateContainer GetBuffContainer() { }

	// RVA: 0x95F674 Offset: 0x95F674 VA: 0x95F674 Slot: 12
	public override void Undo() { }

	// RVA: 0x95F678 Offset: 0x95F678 VA: 0x95F678
	public void .ctor() { }
}
