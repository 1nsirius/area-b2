// Namespace: 
protected class LocalGunBaseCtrlr.State_AimOut : LocalToolBaseCtrlr.State_HasTarget // TypeDefIndex: 13101
{
	// Fields
	protected LocalGunBaseCtrlr.State_AimOut.FinishCallback _callback; // 0x18
	private Action _onUpdate; // 0x1C
	private Nullable<float> _startTime; // 0x20
	private Conduct _conduct; // 0x28

	// Properties
	private LocalGunBaseCtrlr ToolCtrlr { get; }

	// Methods

	// RVA: 0xCF540C Offset: 0xCF540C VA: 0xCF540C
	private LocalGunBaseCtrlr get_ToolCtrlr() { }

	// RVA: 0xCF550C Offset: 0xCF550C VA: 0xCF550C Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xCF5778 Offset: 0xCF5778 VA: 0xCF5778 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xCF5B24 Offset: 0xCF5B24 VA: 0xCF5B24 Slot: 34
	public override void update() { }

	// RVA: 0xCF5B64 Offset: 0xCF5B64 VA: 0xCF5B64 Slot: 37
	public override void Unequip(Action callback, Action onEnter, Action onUpdate, LocalToolBaseCtrlr.State targetToolState, Nullable<float> startTime, bool withAssist, bool needSendToServer) { }

	// RVA: 0xCF482C Offset: 0xCF482C VA: 0xCF482C
	public void MakeCurrent(LocalGunBaseCtrlr.State_AimOut.FinishCallback callback, LocalToolBaseCtrlr.State nextState, Action onUpdate, Nullable<float> startTime) { }

	// RVA: 0xCF5CFC Offset: 0xCF5CFC VA: 0xCF5CFC Slot: 33
	public override void leave() { }

	// RVA: 0xCF5D9C Offset: 0xCF5D9C VA: 0xCF5D9C
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668470 Offset: 0x668470 VA: 0x668470
	// RVA: 0xCF5DA4 Offset: 0xCF5DA4 VA: 0xCF5DA4
	private void <Operate>b__6_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x668480 Offset: 0x668480 VA: 0x668480
	// RVA: 0xCF5DD0 Offset: 0xCF5DD0 VA: 0xCF5DD0
	private void <enter>b__7_0(float finishTime) { }
}
