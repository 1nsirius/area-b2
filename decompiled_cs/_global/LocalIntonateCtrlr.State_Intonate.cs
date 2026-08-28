// Namespace: 
protected abstract class LocalIntonateCtrlr.State_Intonate : LocalToolBaseCtrlr.State // TypeDefIndex: 12874
{
	// Fields
	private float _end_time; // 0x14

	// Properties
	private LocalIntonateCtrlr ToolCtrlr { get; }
	protected abstract string OperationName { get; }

	// Methods

	// RVA: 0xCFE2BC Offset: 0xCFE2BC VA: 0xCFE2BC
	private LocalIntonateCtrlr get_ToolCtrlr() { }

	// RVA: -1 Offset: -1 Slot: 41
	protected abstract string get_OperationName();

	// RVA: 0xCFE3BC Offset: 0xCFE3BC VA: 0xCFE3BC Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xCFE668 Offset: 0xCFE668 VA: 0xCFE668 Slot: 34
	public override void update() { }

	// RVA: 0xCFE814 Offset: 0xCFE814 VA: 0xCFE814 Slot: 33
	public override void leave() { }

	// RVA: 0xCFE874 Offset: 0xCFE874 VA: 0xCFE874 Slot: 35
	public override void MakeCurrent() { }

	// RVA: 0xCFE918 Offset: 0xCFE918 VA: 0xCFE918 Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xCFE954 Offset: 0xCFE954 VA: 0xCFE954
	protected void onBreak() { }

	// RVA: -1 Offset: -1 Slot: 42
	protected abstract void OnIntonateStart();

	// RVA: -1 Offset: -1 Slot: 43
	protected abstract void OnIntonateFinish();

	// RVA: -1 Offset: -1 Slot: 44
	protected abstract void OnIntonateBreak();

	// RVA: 0xCFE9F4 Offset: 0xCFE9F4 VA: 0xCFE9F4
	protected void .ctor() { }
}
