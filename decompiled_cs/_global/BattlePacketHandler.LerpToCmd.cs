// Namespace: 
private class BattlePacketHandler.LerpToCmd : PacketCommand<Packet, BattlePacketHandler.LerpToCmd> // TypeDefIndex: 11469
{
	// Fields
	private LerpData mLerpData; // 0x10
	private U64Id mUid; // 0x18

	// Properties
	public override bool NeedRecord { get; }

	// Methods

	// RVA: 0x955B5C Offset: 0x955B5C VA: 0x955B5C Slot: 10
	public override bool get_NeedRecord() { }

	// RVA: 0x955B64 Offset: 0x955B64 VA: 0x955B64
	public BattlePacketHandler.LerpToCmd Init(U64Id uid, LerpData lerpData) { }

	// RVA: 0x955B7C Offset: 0x955B7C VA: 0x955B7C Slot: 13
	public override void Dispose() { }

	// RVA: 0x955BF0 Offset: 0x955BF0 VA: 0x955BF0 Slot: 11
	public override void Redo() { }

	// RVA: 0x955D18 Offset: 0x955D18 VA: 0x955D18 Slot: 12
	public override void Undo() { }

	// RVA: 0x955D1C Offset: 0x955D1C VA: 0x955D1C
	public void .ctor() { }
}
