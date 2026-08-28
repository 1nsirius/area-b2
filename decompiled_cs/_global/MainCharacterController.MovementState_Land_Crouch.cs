// Namespace: 
internal class MainCharacterController.MovementState_Land_Crouch : MainCharacterController.MovementStateBase // TypeDefIndex: 12564
{
	// Fields
	private bool _need_send_to_server; // 0xC

	// Properties
	public override float MaxSpeed { get; }

	// Methods

	// RVA: 0xABB33C Offset: 0xABB33C VA: 0xABB33C Slot: 8
	public override float get_MaxSpeed() { }

	// RVA: 0xAB68B0 Offset: 0xAB68B0 VA: 0xAB68B0
	public void MakeCurrent(bool need_send_to_server = True) { }

	// RVA: 0xABB45C Offset: 0xABB45C VA: 0xABB45C
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABB488 Offset: 0xABB488 VA: 0xABB488 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABB588 Offset: 0xABB588 VA: 0xABB588 Slot: 13
	public override void update() { }

	// RVA: 0xABB5DC Offset: 0xABB5DC VA: 0xABB5DC Slot: 14
	public override void to_stand(bool needSendToServer = True) { }

	// RVA: 0xABB620 Offset: 0xABB620 VA: 0xABB620 Slot: 17
	public override void to_creep(EBodyState targetState) { }

	// RVA: 0xABB664 Offset: 0xABB664 VA: 0xABB664 Slot: 21
	public override void to_jump(IJumpTrigger jumpTrigger, in JumpPoints points) { }

	// RVA: 0xABB6A0 Offset: 0xABB6A0 VA: 0xABB6A0 Slot: 19
	public override void to_compelling_run() { }

	// RVA: 0xABB6F0 Offset: 0xABB6F0 VA: 0xABB6F0 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABB72C Offset: 0xABB72C VA: 0xABB72C Slot: 24
	public override void OnAgonal() { }

	// RVA: 0xABB76C Offset: 0xABB76C VA: 0xABB76C Slot: 30
	public override bool AllowByToolState(LocalToolBaseCtrlr.State targetToolState) { }

	// RVA: 0xABB7A0 Offset: 0xABB7A0 VA: 0xABB7A0 Slot: 29
	public override float GetStateChangeDuration(EBodyState targetBodyState) { }
}
