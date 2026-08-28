// Namespace: 
private class LocalBlockingBoardCtrlr.State_BuildBlockingBoard : LocalBuildingToolCtrlr.State_BuildIn // TypeDefIndex: 12866
{
	// Fields
	private Conduct mConduct; // 0x18
	private bool mIsForward; // 0x1C
	private BlockingBoardState mActivingState; // 0x20

	// Properties
	private LocalBlockingBoardCtrlr ToolCtrlr { get; }
	protected override float build_duration { get; }
	protected override string OperationName { get; }

	// Methods

	// RVA: 0xA3A404 Offset: 0xA3A404 VA: 0xA3A404
	private LocalBlockingBoardCtrlr get_ToolCtrlr() { }

	// RVA: 0xA3A504 Offset: 0xA3A504 VA: 0xA3A504 Slot: 41
	protected override float get_build_duration() { }

	// RVA: 0xA3A724 Offset: 0xA3A724 VA: 0xA3A724 Slot: 42
	protected override string get_OperationName() { }

	// RVA: 0xA3A7D0 Offset: 0xA3A7D0 VA: 0xA3A7D0 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xA3BEB4 Offset: 0xA3BEB4 VA: 0xA3BEB4 Slot: 34
	public override void update() { }

	// RVA: 0xA3BC00 Offset: 0xA3BC00 VA: 0xA3BC00
	private void Break() { }

	// RVA: 0xA3C2FC Offset: 0xA3C2FC VA: 0xA3C2FC Slot: 33
	public override void leave() { }

	// RVA: 0xA3C1AC Offset: 0xA3C1AC VA: 0xA3C1AC
	private void EquipWeapon(bool needSendToServer) { }

	// RVA: 0xA3C508 Offset: 0xA3C508 VA: 0xA3C508 Slot: 43
	protected override void Success() { }

	// RVA: 0xA3C5CC Offset: 0xA3C5CC VA: 0xA3C5CC
	public void .ctor() { }
}
