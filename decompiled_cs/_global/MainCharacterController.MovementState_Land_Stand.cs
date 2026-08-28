// Namespace: 
internal class MainCharacterController.MovementState_Land_Stand : MainCharacterController.MovementStateBase // TypeDefIndex: 12568
{
	// Fields
	private bool _need_send_to_server; // 0xC

	// Properties
	public override float MaxSpeed { get; }

	// Methods

	// RVA: 0xABC114 Offset: 0xABC114 VA: 0xABC114
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABC140 Offset: 0xABC140 VA: 0xABC140 Slot: 8
	public override float get_MaxSpeed() { }

	// RVA: 0xAB8BB4 Offset: 0xAB8BB4 VA: 0xAB8BB4
	public void MakeCurrent(bool need_send_to_server = True) { }

	// RVA: 0xABC398 Offset: 0xABC398 VA: 0xABC398 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABC498 Offset: 0xABC498 VA: 0xABC498 Slot: 13
	public override void update() { }

	// RVA: 0xABC50C Offset: 0xABC50C VA: 0xABC50C Slot: 11
	public override void leave() { }

	// RVA: 0xABC544 Offset: 0xABC544 VA: 0xABC544 Slot: 16
	public override void to_crouch(bool need_send_to_server = True) { }

	// RVA: 0xABC588 Offset: 0xABC588 VA: 0xABC588 Slot: 17
	public override void to_creep(EBodyState targetState) { }

	// RVA: 0xABC5CC Offset: 0xABC5CC VA: 0xABC5CC Slot: 18
	public override void to_run() { }

	// RVA: 0xABC634 Offset: 0xABC634 VA: 0xABC634 Slot: 19
	public override void to_compelling_run() { }

	// RVA: 0xABC644 Offset: 0xABC644 VA: 0xABC644 Slot: 21
	public override void to_jump(IJumpTrigger jumpTrigger, in JumpPoints points) { }

	// RVA: 0xABC680 Offset: 0xABC680 VA: 0xABC680 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABC6BC Offset: 0xABC6BC VA: 0xABC6BC Slot: 15
	public override void to_mounted_lmg() { }

	// RVA: 0xABC788 Offset: 0xABC788 VA: 0xABC788 Slot: 24
	public override void OnAgonal() { }
}
