// Namespace: 
protected class LocalMountedLMGOperatorCtrlr.State_MountedLMGOperatorIdle : LocalToolBaseCtrlr.State // TypeDefIndex: 13043
{
	// Fields
	private bool mBodyLocked; // 0x14
	private U64Id mTargetSceneToolUid; // 0x18

	// Properties
	private LocalMountedLMGOperatorCtrlr ToolCtrlr { get; }
	public override bool BodyLocked { get; }
	public override bool AllowFall { get; }

	// Methods

	// RVA: 0xD03E00 Offset: 0xD03E00 VA: 0xD03E00
	private LocalMountedLMGOperatorCtrlr get_ToolCtrlr() { }

	// RVA: 0xD03F00 Offset: 0xD03F00 VA: 0xD03F00 Slot: 15
	public override bool get_BodyLocked() { }

	// RVA: 0xD03F08 Offset: 0xD03F08 VA: 0xD03F08 Slot: 29
	public override bool get_AllowFall() { }

	// RVA: 0xD03F20 Offset: 0xD03F20 VA: 0xD03F20 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xD04310 Offset: 0xD04310 VA: 0xD04310 Slot: 34
	public override void update() { }

	// RVA: 0xD04560 Offset: 0xD04560 VA: 0xD04560 Slot: 33
	public override void leave() { }

	// RVA: 0xD045E8 Offset: 0xD045E8 VA: 0xD045E8 Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xD039C4 Offset: 0xD039C4 VA: 0xD039C4
	public void MakeCurrent(U64Id targetSceneToolUid) { }

	// RVA: 0xD048F0 Offset: 0xD048F0 VA: 0xD048F0
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668300 Offset: 0x668300 VA: 0x668300
	// RVA: 0xD04900 Offset: 0xD04900 VA: 0xD04900
	private void <enter>b__8_0() { }
}
