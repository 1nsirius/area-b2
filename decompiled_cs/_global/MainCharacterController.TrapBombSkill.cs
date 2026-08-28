// Namespace: 
private sealed class MainCharacterController.TrapBombSkill : MainCharacterController.SkillBase // TypeDefIndex: 12602
{
	// Fields
	private readonly MainCharacterController.TrapBombSkill.GetBackHandler mGetBackHandler; // 0x24
	private readonly MainCharacterController.TrapBombSkill.PlaceHandler mPlaceHandler; // 0x28
	public readonly LocalTrapBombCtrlr TrapBombCtrlr; // 0x2C
	private readonly List<TrapBombTrigger> mTriggers; // 0x30
	private bool mInputSwitch; // 0x34

	// Properties
	public override bool Visible { get; }
	public override int ButtonId { get; }
	public override Count Num { get; set; }

	// Methods

	// RVA: 0xAC6B60 Offset: 0xAC6B60 VA: 0xAC6B60
	public void .ctor(MainCharacterController characterCtrlr, Character.TrapBombSkill skillData) { }

	// RVA: 0xAC6F54 Offset: 0xAC6F54 VA: 0xAC6F54
	private void OnEnterIdle() { }

	// RVA: 0xAC6F58 Offset: 0xAC6F58 VA: 0xAC6F58 Slot: 16
	public override bool get_Visible() { }

	// RVA: 0xAC6F84 Offset: 0xAC6F84 VA: 0xAC6F84 Slot: 17
	public override int get_ButtonId() { }

	// RVA: 0xAC6FB8 Offset: 0xAC6FB8 VA: 0xAC6FB8 Slot: 19
	public override Count get_Num() { }

	// RVA: 0xAC7014 Offset: 0xAC7014 VA: 0xAC7014 Slot: 20
	public override void set_Num(Count value) { }

	// RVA: 0xAC70CC Offset: 0xAC70CC VA: 0xAC70CC
	private void OnToolUnequip(LocalToolBaseCtrlr toolCtrlr) { }

	// RVA: 0xAC7188 Offset: 0xAC7188 VA: 0xAC7188 Slot: 30
	public override void Update() { }

	// RVA: 0xAC77AC Offset: 0xAC77AC VA: 0xAC77AC
	private void DetermineIfCanPlace() { }

	// RVA: 0xAC9670 Offset: 0xAC9670 VA: 0xAC9670
	private static Vector3 CalcCharacterDestPos(Vector3 trapBombPos, Quaternion trapBombRot, bool isUpper) { }

	// RVA: 0xAC9A9C Offset: 0xAC9A9C VA: 0xAC9A9C
	private static int PlaceComparer(TrapBombTrigger.PlaceData a, TrapBombTrigger.PlaceData b) { }

	// RVA: 0xAC8820 Offset: 0xAC8820 VA: 0xAC8820
	private void DetermineIfCanGetBack() { }

	// RVA: 0xAC9C00 Offset: 0xAC9C00 VA: 0xAC9C00
	private static int GetBackComparer(MainCharacterController.TrapBombSkill.GetBackData x, MainCharacterController.TrapBombSkill.GetBackData y) { }

	// RVA: 0xAC9574 Offset: 0xAC9574 VA: 0xAC9574
	private void ClearInput() { }

	// RVA: 0xAC9C9C Offset: 0xAC9C9C VA: 0xAC9C9C Slot: 31
	public override void OnTriggerEnter(Collider trigger) { }

	// RVA: 0xAC9DC4 Offset: 0xAC9DC4 VA: 0xAC9DC4 Slot: 32
	public override void OnTriggerExit(Collider trigger) { }

	// RVA: 0xAC9EB4 Offset: 0xAC9EB4 VA: 0xAC9EB4 Slot: 27
	public override void OnClick() { }
}
