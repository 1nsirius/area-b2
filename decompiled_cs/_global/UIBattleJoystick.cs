// Namespace: 
public class UIBattleJoystick : UIJoystick // TypeDefIndex: 5775
{
	// Fields
	public Text runText; // 0xB4
	private const float RADIUS_MAX_TOUCH = 111;
	[CompilerGeneratedAttribute] // RVA: 0x55EBCC Offset: 0x55EBCC VA: 0x55EBCC
	private UserInput.InputMoveType <inputMoveType>k__BackingField; // 0xB8
	private readonly Dictionary<JoystickBehaviourType, BaseJoystickBehaviour> _joystickBehavioursDic; // 0xBC
	private BaseJoystickBehaviour _curJoystickBehaviour; // 0xC0

	// Properties
	public UserInput.InputMoveType inputMoveType { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57ACBC Offset: 0x57ACBC VA: 0x57ACBC
	// RVA: 0xB2D060 Offset: 0xB2D060 VA: 0xB2D060
	public UserInput.InputMoveType get_inputMoveType() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ACCC Offset: 0x57ACCC VA: 0x57ACCC
	// RVA: 0xB43A7C Offset: 0xB43A7C VA: 0xB43A7C
	private void set_inputMoveType(UserInput.InputMoveType value) { }

	// RVA: 0xB43A84 Offset: 0xB43A84 VA: 0xB43A84 Slot: 6
	protected override void Start() { }

	// RVA: 0xB43AB0 Offset: 0xB43AB0 VA: 0xB43AB0 Slot: 67
	protected override void OnTouchMovement(float distance) { }

	// RVA: 0xB2ADF4 Offset: 0xB2ADF4 VA: 0xB2ADF4
	public void AddJoystickBehaviours(BaseJoystickBehaviour[] behaviours) { }

	// RVA: 0xB2F3A0 Offset: 0xB2F3A0 VA: 0xB2F3A0
	public void SwitchJoystickBehaviour(JoystickBehaviourType behaviourType) { }

	// RVA: 0xB43AFC Offset: 0xB43AFC VA: 0xB43AFC Slot: 68
	public override void OnTick() { }

	// RVA: 0xB43B04 Offset: 0xB43B04 VA: 0xB43B04
	public void .ctor() { }
}
