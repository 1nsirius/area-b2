// Namespace: 
protected class LocalToolBaseCtrlr.State_Unequip : LocalToolBaseCtrlr.State_HasTarget // TypeDefIndex: 12909
{
	// Fields
	private Conduct mConduct; // 0x18
	private Action mCallback; // 0x1C
	private Action mOnUpdate; // 0x20
	private Action mOnEnter; // 0x24
	private Nullable<float> mStartTime; // 0x28
	private bool mWithAssist; // 0x30
	private bool mNeedSendToServer; // 0x31

	// Properties
	public override bool IsInSwitchOut { get; }

	// Methods

	// RVA: 0xDBA670 Offset: 0xDBA670 VA: 0xDBA670 Slot: 30
	public override bool get_IsInSwitchOut() { }

	// RVA: 0xDBA678 Offset: 0xDBA678 VA: 0xDBA678 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xDBAD08 Offset: 0xDBAD08 VA: 0xDBAD08 Slot: 33
	public override void leave() { }

	// RVA: 0xDBADA8 Offset: 0xDBADA8 VA: 0xDBADA8 Slot: 34
	public override void update() { }

	// RVA: 0xDBADDC Offset: 0xDBADDC VA: 0xDBADDC Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xDBAF40 Offset: 0xDBAF40 VA: 0xDBAF40 Slot: 36
	public override void Equip(Action callback, bool withAssist, bool needSendToServer) { }

	// RVA: 0xDB84F0 Offset: 0xDB84F0 VA: 0xDB84F0
	public void MakeCurrent(Action callback, Action onEnter, Action onUpdate, LocalToolBaseCtrlr.State allowOperateQuerier, Nullable<float> startTime, bool withAssist, bool needSendToServer) { }

	// RVA: 0xDBAF94 Offset: 0xDBAF94 VA: 0xDBAF94
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x6681C0 Offset: 0x6681C0 VA: 0x6681C0
	// RVA: 0xDBAF98 Offset: 0xDBAF98 VA: 0xDBAF98
	private void <enter>b__9_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x6681D0 Offset: 0x6681D0 VA: 0x6681D0
	// RVA: 0xDBA9C0 Offset: 0xDBA9C0 VA: 0xDBA9C0
	private void <enter>g__DoUnequip|9_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x6681E0 Offset: 0x6681E0 VA: 0x6681E0
	// RVA: 0xDBB02C Offset: 0xDBB02C VA: 0xDBB02C
	private void <enter>b__9_2() { }

	[CompilerGeneratedAttribute] // RVA: 0x6681F0 Offset: 0x6681F0 VA: 0x6681F0
	// RVA: 0xDBB10C Offset: 0xDBB10C VA: 0xDBB10C
	private void <enter>b__9_3(float p) { }
}
