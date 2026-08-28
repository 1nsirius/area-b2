// Namespace: 
public class LocalGunBaseCtrlr.State_AimIn : LocalToolBaseCtrlr.State // TypeDefIndex: 13099
{
	// Properties
	protected LocalGunBaseCtrlr ToolCtrlr { get; }

	// Methods

	// RVA: 0xCF4198 Offset: 0xCF4198 VA: 0xCF4198
	protected LocalGunBaseCtrlr get_ToolCtrlr() { }

	// RVA: 0xCF4298 Offset: 0xCF4298 VA: 0xCF4298 Slot: 31
	public override void enter(LocalToolBaseCtrlr.State last) { }

	// RVA: 0xCF457C Offset: 0xCF457C VA: 0xCF457C Slot: 38
	public override void Operate(OperateInput operate, object argument) { }

	// RVA: 0xCF4858 Offset: 0xCF4858 VA: 0xCF4858 Slot: 34
	public override void update() { }

	// RVA: 0xCF4A80 Offset: 0xCF4A80 VA: 0xCF4A80 Slot: 37
	public override void Unequip(Action callback, Action onEnter, Action onUpdate, LocalToolBaseCtrlr.State targetToolState, Nullable<float> startTime, bool withAssist, bool needSendToServer) { }

	// RVA: 0xCF4C60 Offset: 0xCF4C60 VA: 0xCF4C60 Slot: 40
	public override void SwitchInAssist() { }

	// RVA: 0xCF4D60 Offset: 0xCF4D60 VA: 0xCF4D60 Slot: 41
	protected virtual void DoReload() { }

	// RVA: 0xCF4E38 Offset: 0xCF4E38 VA: 0xCF4E38 Slot: 42
	protected virtual void DoAutoReload() { }

	// RVA: 0xCF4F10 Offset: 0xCF4F10 VA: 0xCF4F10 Slot: 43
	protected virtual void DoAutoPullTheBolt() { }

	// RVA: 0xCF4F3C Offset: 0xCF4F3C VA: 0xCF4F3C
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x668410 Offset: 0x668410 VA: 0x668410
	// RVA: 0xCF4F44 Offset: 0xCF4F44 VA: 0xCF4F44
	private void <Operate>b__3_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x668420 Offset: 0x668420 VA: 0x668420
	// RVA: 0xCF4F9C Offset: 0xCF4F9C VA: 0xCF4F9C
	private void <update>b__4_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x668430 Offset: 0x668430 VA: 0x668430
	// RVA: 0xCF4FF4 Offset: 0xCF4FF4 VA: 0xCF4FF4
	private void <update>b__4_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x668440 Offset: 0x668440 VA: 0x668440
	// RVA: 0xCF5094 Offset: 0xCF5094 VA: 0xCF5094
	private void <SwitchInAssist>b__6_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x668450 Offset: 0x668450 VA: 0x668450
	// RVA: 0xCF5298 Offset: 0xCF5298 VA: 0xCF5298
	private void <DoReload>b__7_0(float finishTime) { }

	[CompilerGeneratedAttribute] // RVA: 0x668460 Offset: 0x668460 VA: 0x668460
	// RVA: 0xCF52C4 Offset: 0xCF52C4 VA: 0xCF52C4
	private void <DoAutoReload>b__8_0(float finishTime) { }
}
