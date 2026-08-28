// Namespace: 
private class MainCharacterController.TrapBombSkill.GetBackHandler : MainCharacterController.EmptySkillController // TypeDefIndex: 12605
{
	// Fields
	private readonly LocalTrapBombCtrlr mToolCtrlr; // 0x1C
	private ButtonPriority mPriority; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x5796EC Offset: 0x5796EC VA: 0x5796EC
	private bool <HasInput>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x5796FC Offset: 0x5796FC VA: 0x5796FC
	private TrapBomb <TrapBomb>k__BackingField; // 0x2C

	// Properties
	public override ButtonPriority Priority { get; set; }
	public bool HasInput { get; set; }
	public TrapBomb TrapBomb { get; set; }
	public sealed override int ButtonId { get; set; }

	// Methods

	// RVA: 0xAC6E24 Offset: 0xAC6E24 VA: 0xAC6E24
	public void .ctor(LocalTrapBombCtrlr toolCtrlr) { }

	// RVA: 0xACA084 Offset: 0xACA084 VA: 0xACA084 Slot: 21
	public override ButtonPriority get_Priority() { }

	// RVA: 0xACA098 Offset: 0xACA098 VA: 0xACA098 Slot: 22
	public override void set_Priority(ButtonPriority value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6688F0 Offset: 0x6688F0 VA: 0x6688F0
	// RVA: 0xAC956C Offset: 0xAC956C VA: 0xAC956C
	public bool get_HasInput() { }

	[CompilerGeneratedAttribute] // RVA: 0x668900 Offset: 0x668900 VA: 0x668900
	// RVA: 0xACA0A0 Offset: 0xACA0A0 VA: 0xACA0A0
	private void set_HasInput(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x668910 Offset: 0x668910 VA: 0x668910
	// RVA: 0xAC955C Offset: 0xAC955C VA: 0xAC955C
	public TrapBomb get_TrapBomb() { }

	[CompilerGeneratedAttribute] // RVA: 0x668920 Offset: 0x668920 VA: 0x668920
	// RVA: 0xACA0A8 Offset: 0xACA0A8 VA: 0xACA0A8
	private void set_TrapBomb(TrapBomb value) { }

	// RVA: 0xACA0B0 Offset: 0xACA0B0 VA: 0xACA0B0 Slot: 17
	public sealed override int get_ButtonId() { }

	// RVA: 0xACA11C Offset: 0xACA11C VA: 0xACA11C Slot: 27
	public override void OnClick() { }

	// RVA: 0xAC9C90 Offset: 0xAC9C90 VA: 0xAC9C90
	public void Clear() { }

	// RVA: 0xAC9BE8 Offset: 0xAC9BE8 VA: 0xAC9BE8
	public void OnCanGetBack(TrapBomb trapBomb) { }

	// RVA: 0xAC9BF0 Offset: 0xAC9BF0 VA: 0xAC9BF0
	public void OnCanNotGetBack() { }

	// RVA: 0xACA128 Offset: 0xACA128 VA: 0xACA128 Slot: 18
	public sealed override void set_ButtonId(int value) { }
}
