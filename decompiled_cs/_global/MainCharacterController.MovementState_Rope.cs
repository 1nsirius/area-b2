// Namespace: 
public class MainCharacterController.MovementState_Rope : MainCharacterController.MovementStateBase // TypeDefIndex: 12580
{
	// Fields
	private MainCharacterController.MovementState_Rope.AspectState m_sub_aspect_state; // 0xC
	private readonly MainCharacterController.MovementState_Rope.SwitchAspectData m_switch_aspect_data; // 0x10
	private float last_lerp; // 0x14

	// Properties
	public MainCharacterController.MovementState_Rope.AspectState sub_aspect_state { get; }
	public override float MaxSpeed { get; }

	// Methods

	// RVA: 0xABCE98 Offset: 0xABCE98 VA: 0xABCE98
	public MainCharacterController.MovementState_Rope.AspectState get_sub_aspect_state() { }

	// RVA: 0xABCEA0 Offset: 0xABCEA0 VA: 0xABCEA0 Slot: 8
	public override float get_MaxSpeed() { }

	// RVA: 0xABCF58 Offset: 0xABCF58 VA: 0xABCF58
	public void MakeCurrentByBlockingByBlockingBoard() { }

	// RVA: 0xABCFF0 Offset: 0xABCFF0 VA: 0xABCFF0
	public void MakeCurrentByRopeToIndoor(Vector3 last_pos) { }

	// RVA: 0xABD130 Offset: 0xABD130 VA: 0xABD130
	public void MakeCurrent(MainCharacterController.MovementState_Rope.AspectState targetState) { }

	// RVA: 0xABD210 Offset: 0xABD210 VA: 0xABD210 Slot: 20
	public override void switch_aspect() { }

	// RVA: 0xABDD34 Offset: 0xABDD34 VA: 0xABDD34
	public void .ctor(MainCharacterController owner) { }

	// RVA: 0xABDE84 Offset: 0xABDE84 VA: 0xABDE84 Slot: 10
	public override void enter(MainCharacterController.MovementStateBase last) { }

	// RVA: 0xABE48C Offset: 0xABE48C VA: 0xABE48C Slot: 13
	public override void update() { }

	// RVA: 0xABE888 Offset: 0xABE888 VA: 0xABE888
	private void update_aspect_switch() { }

	// RVA: 0xABF008 Offset: 0xABF008 VA: 0xABF008
	private void update_check_suspension() { }

	// RVA: 0xABDA30 Offset: 0xABDA30 VA: 0xABDA30
	private void BeginTransitEyesRotation(Quaternion cur_coo, float min_pitch, float max_pitch) { }

	// RVA: 0xABF5AC Offset: 0xABF5AC VA: 0xABF5AC
	private void update_check_leave() { }

	// RVA: 0xABD718 Offset: 0xABD718 VA: 0xABD718
	public bool aspect_enabled(out int msgId) { }

	// RVA: 0xAC0238 Offset: 0xAC0238 VA: 0xAC0238
	public bool is_this_rope_trigger_group(BaseTriggerGroup cur_group) { }

	// RVA: 0xAC0308 Offset: 0xAC0308 VA: 0xAC0308 Slot: 24
	public override void OnAgonal() { }

	// RVA: 0xAC0344 Offset: 0xAC0344 VA: 0xAC0344 Slot: 14
	public override void to_stand(bool needSendToServer = True) { }
}
