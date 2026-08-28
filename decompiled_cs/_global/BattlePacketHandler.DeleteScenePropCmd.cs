// Namespace: 
private class BattlePacketHandler.DeleteScenePropCmd : PacketCommand<RspDeleteSceneTool, BattlePacketHandler.DeleteScenePropCmd> // TypeDefIndex: 11477
{
	// Properties
	public override bool NeedRecord { get; }

	// Methods

	// RVA: 0x94FF58 Offset: 0x94FF58 VA: 0x94FF58 Slot: 10
	public override bool get_NeedRecord() { }

	// RVA: 0x94FF60 Offset: 0x94FF60 VA: 0x94FF60 Slot: 11
	public override void Redo() { }

	// RVA: 0x9504F4 Offset: 0x9504F4 VA: 0x9504F4
	private void OnExplosive(U64Id uid) { }

	// RVA: 0x95020C Offset: 0x95020C VA: 0x95020C
	private void OnGetBack(U64Id uid) { }

	// RVA: 0x9506B8 Offset: 0x9506B8 VA: 0x9506B8 Slot: 12
	public override void Undo() { }

	// RVA: 0x9506BC Offset: 0x9506BC VA: 0x9506BC
	public void .ctor() { }
}
