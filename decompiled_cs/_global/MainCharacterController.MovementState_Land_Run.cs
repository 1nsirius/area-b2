// Namespace: 
internal class MainCharacterController.MovementState_Land_Run : MainCharacterController.MovementStateBase // TypeDefIndex: 12567
{
	// Properties
	public override float MaxSpeed { get; }

	// Methods

	// RVA: 0xABBC1C Offset: 0xABBC1C VA: 0xABBC1C
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABBC3C Offset: 0xABBC3C VA: 0xABBC3C Slot: 8
	public override float get_MaxSpeed() { }

	// RVA: 0xABBD60 Offset: 0xABBD60 VA: 0xABBD60
	public void MakeCurrent() { }

	// RVA: 0xABBDF0 Offset: 0xABBDF0 VA: 0xABBDF0 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABBEE4 Offset: 0xABBEE4 VA: 0xABBEE4 Slot: 13
	public override void update() { }

	// RVA: 0xABBF40 Offset: 0xABBF40 VA: 0xABBF40
	private void CheckCanRun() { }

	// RVA: 0xABBF90 Offset: 0xABBF90 VA: 0xABBF90 Slot: 14
	public override void to_stand(bool need_send_to_server = True) { }

	// RVA: 0xABBFD4 Offset: 0xABBFD4 VA: 0xABBFD4 Slot: 16
	public override void to_crouch(bool need_send_to_server = True) { }

	// RVA: 0xABC018 Offset: 0xABC018 VA: 0xABC018 Slot: 17
	public override void to_creep(EBodyState targetState) { }

	// RVA: 0xABC05C Offset: 0xABC05C VA: 0xABC05C Slot: 21
	public override void to_jump(IJumpTrigger jumpTrigger, in JumpPoints points) { }

	// RVA: 0xABC098 Offset: 0xABC098 VA: 0xABC098 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABC0D4 Offset: 0xABC0D4 VA: 0xABC0D4 Slot: 24
	public override void OnAgonal() { }
}
