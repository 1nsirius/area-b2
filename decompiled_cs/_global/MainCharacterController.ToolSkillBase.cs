// Namespace: 
private class MainCharacterController.ToolSkillBase : MainCharacterController.SkillBase // TypeDefIndex: 12601
{
	// Fields
	public readonly LocalToolBaseCtrlr LocalToolCtrlr; // 0x24

	// Properties
	public override bool Visible { get; }
	[TupleElementNamesAttribute] // RVA: 0x66F23C Offset: 0x66F23C VA: 0x66F23C
	[IsReadOnlyAttribute] // RVA: 0x66F23C Offset: 0x66F23C VA: 0x66F23C
	public override ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66F2EC Offset: 0x66F2EC VA: 0x66F2EC
	[IsReadOnlyAttribute] // RVA: 0x66F2EC Offset: 0x66F2EC VA: 0x66F2EC
	public override ValueTuple<float, float> ActiveTimeRange { get; }
	public override Count Num { get; set; }

	// Methods

	// RVA: 0xAC6954 Offset: 0xAC6954 VA: 0xAC6954 Slot: 16
	public override bool get_Visible() { }

	// RVA: 0xAC6980 Offset: 0xAC6980 VA: 0xAC6980 Slot: 23
	public override ref ValueTuple<float, float> get_CdTimeRange() { }

	// RVA: 0xAC69AC Offset: 0xAC69AC VA: 0xAC69AC Slot: 24
	public override ref ValueTuple<float, float> get_ActiveTimeRange() { }

	// RVA: 0xAB5DE0 Offset: 0xAB5DE0 VA: 0xAB5DE0
	protected void .ctor(MainCharacterController characterCtrlr, Character.ToolSkillBaseInstance skillData) { }

	// RVA: 0xAC69D8 Offset: 0xAC69D8 VA: 0xAC69D8 Slot: 33
	public override void OnLightweightTriggerEnter(LightweightTriggerBase trigger) { }

	// RVA: 0xAC6A14 Offset: 0xAC6A14 VA: 0xAC6A14 Slot: 34
	public override void OnLightweightTriggerExit(LightweightTriggerBase trigger) { }

	// RVA: 0xAC6A50 Offset: 0xAC6A50 VA: 0xAC6A50 Slot: 31
	public override void OnTriggerEnter(Collider trigger) { }

	// RVA: 0xAC6A8C Offset: 0xAC6A8C VA: 0xAC6A8C Slot: 32
	public override void OnTriggerExit(Collider trigger) { }

	// RVA: 0xAC6AC8 Offset: 0xAC6AC8 VA: 0xAC6AC8 Slot: 19
	public override Count get_Num() { }

	// RVA: 0xAC6B24 Offset: 0xAC6B24 VA: 0xAC6B24 Slot: 20
	public override void set_Num(Count value) { }
}
