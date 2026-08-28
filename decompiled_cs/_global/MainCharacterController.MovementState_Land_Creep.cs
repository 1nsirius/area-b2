// Namespace: 
internal class MainCharacterController.MovementState_Land_Creep : MainCharacterController.MovementStateBase // TypeDefIndex: 12561
{
	// Fields
	private float _end_switch_timer; // 0xC

	// Properties
	public override float MaxSpeed { get; }

	// Methods

	// RVA: 0xABA0EC Offset: 0xABA0EC VA: 0xABA0EC Slot: 8
	public override float get_MaxSpeed() { }

	// RVA: 0xABA1A8 Offset: 0xABA1A8 VA: 0xABA1A8
	public void MakeCurrent(EBodyState targetState) { }

	// RVA: 0xABA38C Offset: 0xABA38C VA: 0xABA38C
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABA3AC Offset: 0xABA3AC VA: 0xABA3AC Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABA3DC Offset: 0xABA3DC VA: 0xABA3DC Slot: 13
	public override void update() { }

	// RVA: 0xABA438 Offset: 0xABA438 VA: 0xABA438
	private void check_switch_creep_liedown() { }

	// RVA: 0xABA83C Offset: 0xABA83C VA: 0xABA83C Slot: 14
	public override void to_stand(bool need_send_to_server = True) { }

	// RVA: 0xABAAD0 Offset: 0xABAAD0 VA: 0xABAAD0 Slot: 16
	public override void to_crouch(bool need_send_to_server = True) { }

	// RVA: 0xABAD64 Offset: 0xABAD64 VA: 0xABAD64 Slot: 19
	public override void to_compelling_run() { }

	// RVA: 0xABADB4 Offset: 0xABADB4 VA: 0xABADB4 Slot: 22
	public override void OnFall() { }

	// RVA: 0xABADF0 Offset: 0xABADF0 VA: 0xABADF0 Slot: 24
	public override void OnAgonal() { }
}
