// Namespace: 
internal class MainCharacterController.MovementState_ClimbLadder : MainCharacterController.MovementStateBase // TypeDefIndex: 12553
{
	// Fields
	private bool mIsUp; // 0xC
	private Conduct mConduct; // 0x10

	// Properties
	private ILadder mLadder { get; }
	public override bool AboutEquipEnabled { get; }

	// Methods

	// RVA: 0xAB7338 Offset: 0xAB7338 VA: 0xAB7338
	private ILadder get_mLadder() { }

	// RVA: 0xAB7384 Offset: 0xAB7384 VA: 0xAB7384 Slot: 9
	public override bool get_AboutEquipEnabled() { }

	// RVA: 0xAB738C Offset: 0xAB738C VA: 0xAB738C
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xAB73AC Offset: 0xAB73AC VA: 0xAB73AC Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xAB7C74 Offset: 0xAB7C74 VA: 0xAB7C74 Slot: 13
	public override void update() { }

	// RVA: 0xAB7C9C Offset: 0xAB7C9C VA: 0xAB7C9C Slot: 11
	public override void leave() { }

	// RVA: 0xAB7D2C Offset: 0xAB7D2C VA: 0xAB7D2C
	public void MakeCurrent(Collider trigger) { }

	// RVA: 0xAB7E5C Offset: 0xAB7E5C VA: 0xAB7E5C Slot: 24
	public override void OnAgonal() { }
}
