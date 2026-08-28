// Namespace: 
internal class MainCharacterController.MovementState_Land_StandToCreep : MainCharacterController.MovementStateBase // TypeDefIndex: 12569
{
	// Fields
	private float end_timer; // 0xC
	private EBodyState target_body_state; // 0x10

	// Methods

	// RVA: 0xAB8C4C Offset: 0xAB8C4C VA: 0xAB8C4C
	public void MakeCurrent(EBodyState targetState) { }

	// RVA: 0xABC7C8 Offset: 0xABC7C8 VA: 0xABC7C8
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABC7E8 Offset: 0xABC7E8 VA: 0xABC7E8 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABC934 Offset: 0xABC934 VA: 0xABC934 Slot: 13
	public override void update() { }

	// RVA: 0xABC9D8 Offset: 0xABC9D8 VA: 0xABC9D8 Slot: 14
	public override void to_stand(bool need_send_to_server = True) { }

	// RVA: 0xABCA20 Offset: 0xABCA20 VA: 0xABCA20 Slot: 16
	public override void to_crouch(bool need_send_to_server = True) { }

	// RVA: 0xABCA68 Offset: 0xABCA68 VA: 0xABCA68 Slot: 19
	public override void to_compelling_run() { }

	// RVA: 0xABCAB8 Offset: 0xABCAB8 VA: 0xABCAB8 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABCAF4 Offset: 0xABCAF4 VA: 0xABCAF4 Slot: 24
	public override void OnAgonal() { }
}
