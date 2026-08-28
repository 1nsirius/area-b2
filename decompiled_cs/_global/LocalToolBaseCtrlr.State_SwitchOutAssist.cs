// Namespace: 
protected class LocalToolBaseCtrlr.State_SwitchOutAssist : LocalToolBaseCtrlr.State // TypeDefIndex: 12905
{
	// Fields
	private bool mIsForce; // 0x14
	private Nullable<float> mStartTime; // 0x18
	private Conduct mConduct; // 0x20
	private Action mAfterSwitchOut; // 0x24
	private Action mOnUpdate; // 0x28

	// Properties
	public override bool IsInSwitchOut { get; }

	// Methods

	// RVA: 0xDBA0C8 Offset: 0xDBA0C8 VA: 0xDBA0C8 Slot: 30
	public override bool get_IsInSwitchOut() { }

	// RVA: 0xDBA0D0 Offset: 0xDBA0D0 VA: 0xDBA0D0 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xDBA4A4 Offset: 0xDBA4A4 VA: 0xDBA4A4 Slot: 33
	public override void leave() { }

	// RVA: 0xDBA540 Offset: 0xDBA540 VA: 0xDBA540 Slot: 34
	public override void update() { }

	// RVA: 0xDB85A4 Offset: 0xDB85A4 VA: 0xDB85A4
	public void MakeCurrent(Action afterSwitchOut, Action onUpdate, Nullable<float> startTime) { }

	// RVA: 0xDBA568 Offset: 0xDBA568 VA: 0xDBA568
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668190 Offset: 0x668190 VA: 0x668190
	// RVA: 0xDBA56C Offset: 0xDBA56C VA: 0xDBA56C
	private void <enter>b__7_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x6681A0 Offset: 0x6681A0 VA: 0x6681A0
	// RVA: 0xDBA644 Offset: 0xDBA644 VA: 0xDBA644
	private void <enter>b__7_1(float p) { }
}
