// Namespace: 
private class MainCharacterController.TrapBombSkill.PlaceHandler : MainCharacterController.EmptySkillController // TypeDefIndex: 12604
{
	// Fields
	private readonly LocalTrapBombCtrlr mToolCtrlr; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x5796CC Offset: 0x5796CC VA: 0x5796CC
	private bool <HasInput>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x5796DC Offset: 0x5796DC VA: 0x5796DC
	private int <ButtonId>k__BackingField; // 0x24

	// Properties
	public override bool Visible { get; }
	public bool HasInput { get; set; }
	public override int ButtonId { get; set; }
	public TrapBombTrigger.ErrorMessageId ErrorMessageId { get; set; }

	// Methods

	// RVA: 0xAC6D9C Offset: 0xAC6D9C VA: 0xAC6D9C
	public void .ctor(LocalTrapBombCtrlr toolCtrlr) { }

	// RVA: 0xACA138 Offset: 0xACA138 VA: 0xACA138 Slot: 16
	public override bool get_Visible() { }

	[CompilerGeneratedAttribute] // RVA: 0x6688B0 Offset: 0x6688B0 VA: 0x6688B0
	// RVA: 0xAC9564 Offset: 0xAC9564 VA: 0xAC9564
	public bool get_HasInput() { }

	[CompilerGeneratedAttribute] // RVA: 0x6688C0 Offset: 0x6688C0 VA: 0x6688C0
	// RVA: 0xACA164 Offset: 0xACA164 VA: 0xACA164
	private void set_HasInput(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6688D0 Offset: 0x6688D0 VA: 0x6688D0
	// RVA: 0xACA16C Offset: 0xACA16C VA: 0xACA16C Slot: 17
	public override int get_ButtonId() { }

	[CompilerGeneratedAttribute] // RVA: 0x6688E0 Offset: 0x6688E0 VA: 0x6688E0
	// RVA: 0xACA174 Offset: 0xACA174 VA: 0xACA174 Slot: 18
	public override void set_ButtonId(int value) { }

	// RVA: 0xAC996C Offset: 0xAC996C VA: 0xAC996C
	public TrapBombTrigger.ErrorMessageId get_ErrorMessageId() { }

	// RVA: 0xAC95C0 Offset: 0xAC95C0 VA: 0xAC95C0
	public void set_ErrorMessageId(TrapBombTrigger.ErrorMessageId value) { }

	// RVA: 0xAC9A14 Offset: 0xAC9A14 VA: 0xAC9A14
	public void OnCanNotPlace() { }

	// RVA: 0xAC98E4 Offset: 0xAC98E4 VA: 0xAC98E4
	public void OnCanPlace() { }

	// RVA: 0xACA17C Offset: 0xACA17C VA: 0xACA17C Slot: 27
	public override void OnClick() { }

	// RVA: 0xAC9C84 Offset: 0xAC9C84 VA: 0xAC9C84
	public void Clear() { }
}
