// Namespace: 
internal class MainCharacterController.MovementState_Land_CrouchToCreep : MainCharacterController.MovementStateBase // TypeDefIndex: 12565
{
	// Fields
	private float end_timer; // 0xC
	private EBodyState target_body_state; // 0x10

	// Methods

	// RVA: 0xABAFAC Offset: 0xABAFAC VA: 0xABAFAC
	public void MakeCurrent(EBodyState targetState) { }

	// RVA: 0xABB8B0 Offset: 0xABB8B0 VA: 0xABB8B0
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABB8D0 Offset: 0xABB8D0 VA: 0xABB8D0 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABBA1C Offset: 0xABBA1C VA: 0xABBA1C Slot: 13
	public override void update() { }

	// RVA: 0xABBAC0 Offset: 0xABBAC0 VA: 0xABBAC0 Slot: 14
	public override void to_stand(bool need_send_to_server = True) { }

	// RVA: 0xABBB08 Offset: 0xABBB08 VA: 0xABBB08 Slot: 16
	public override void to_crouch(bool need_send_to_server = True) { }

	// RVA: 0xABBB50 Offset: 0xABBB50 VA: 0xABBB50 Slot: 19
	public override void to_compelling_run() { }

	// RVA: 0xABBBA0 Offset: 0xABBBA0 VA: 0xABBBA0 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABBBDC Offset: 0xABBBDC VA: 0xABBBDC Slot: 24
	public override void OnAgonal() { }
}
