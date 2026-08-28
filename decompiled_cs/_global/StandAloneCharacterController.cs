// Namespace: 
public class StandAloneCharacterController : MonoBehaviour // TypeDefIndex: 5519
{
	// Fields
	private CharacterController cc; // 0xC
	private EBodyState bodyState; // 0x10
	public float eyesHeight; // 0x14
	private Tween eyesHeightTween; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x55DE30 Offset: 0x55DE30 VA: 0x55DE30
	private speed_table.Record <SpeedCfg>k__BackingField; // 0x1C
	internal readonly StandAloneCharacterController.MovementStateM m_movementStateM; // 0x20
	private StandAloneCharacterController.MovementCreep movementCreep; // 0x24
	private StandAloneCharacterController.MovementCrouch movementCrouch; // 0x28
	private StandAloneCharacterController.MovementFall movementFall; // 0x2C
	private StandAloneCharacterController.MovementRun movementRun; // 0x30
	private StandAloneCharacterController.MovementStand movementStand; // 0x34
	private const float GRAVITY = 20;
	private const float DOWN_DISTANCE = 0,3;
	private float _cur_horizontal_speed; // 0x38
	private Vector3 mLastVelocity; // 0x3C
	private float m_speed_by_gravity; // 0x48
	private float mYaw; // 0x4C
	public float Pitch; // 0x50
	private BodyTiltEnum InputBodyTilt; // 0x54

	// Properties
	public EBodyState BodyState { get; set; }
	public speed_table.Record SpeedCfg { get; set; }
	public BattleConfiguration.CharacterBasicMoveCfg basicSpeedCfg { get; }
	public Vector3 Velocity { get; }
	public float BasicMaxSpeed { get; }
	public float MaxSpeed { get; }
	private XorFloat SDJC { get; }

	// Methods

	// RVA: 0xD7C47C Offset: 0xD7C47C VA: 0xD7C47C
	private void Awake() { }

	// RVA: 0xD7C4E4 Offset: 0xD7C4E4 VA: 0xD7C4E4
	private void TweenEyesHeight(float duration, float target) { }

	// RVA: 0xD7C614 Offset: 0xD7C614 VA: 0xD7C614
	public EBodyState get_BodyState() { }

	// RVA: 0xD7C61C Offset: 0xD7C61C VA: 0xD7C61C
	public void set_BodyState(EBodyState value) { }

	[IteratorStateMachineAttribute] // RVA: 0x579F5C Offset: 0x579F5C VA: 0x579F5C
	// RVA: 0xD7C6BC Offset: 0xD7C6BC VA: 0xD7C6BC
	private IEnumerator Start() { }

	// RVA: 0xD7C768 Offset: 0xD7C768 VA: 0xD7C768
	private void Update() { }

	// RVA: 0xD7C7CC Offset: 0xD7C7CC VA: 0xD7C7CC
	private void update_input_in_editor() { }

	// RVA: 0xD7CE24 Offset: 0xD7CE24 VA: 0xD7CE24
	private void update_input() { }

	[CompilerGeneratedAttribute] // RVA: 0x579FD4 Offset: 0x579FD4 VA: 0x579FD4
	// RVA: 0xD7D888 Offset: 0xD7D888 VA: 0xD7D888
	public speed_table.Record get_SpeedCfg() { }

	[CompilerGeneratedAttribute] // RVA: 0x579FE4 Offset: 0x579FE4 VA: 0x579FE4
	// RVA: 0xD7D890 Offset: 0xD7D890 VA: 0xD7D890
	private void set_SpeedCfg(speed_table.Record value) { }

	// RVA: 0xD7D898 Offset: 0xD7D898 VA: 0xD7D898
	public BattleConfiguration.CharacterBasicMoveCfg get_basicSpeedCfg() { }

	// RVA: 0xD7D298 Offset: 0xD7D298 VA: 0xD7D298
	private void update_movement() { }

	// RVA: 0xD7D8C4 Offset: 0xD7D8C4 VA: 0xD7D8C4
	private void OnFall() { }

	// RVA: 0xD7D964 Offset: 0xD7D964 VA: 0xD7D964
	private void OnLand() { }

	// RVA: 0xD7DA04 Offset: 0xD7DA04 VA: 0xD7DA04
	public Vector3 get_Velocity() { }

	// RVA: 0xD7DA18 Offset: 0xD7DA18 VA: 0xD7DA18
	public float get_BasicMaxSpeed() { }

	// RVA: 0xD7DAD8 Offset: 0xD7DAD8 VA: 0xD7DAD8
	public float get_MaxSpeed() { }

	// RVA: 0xD7DBA0 Offset: 0xD7DBA0 VA: 0xD7DBA0
	private XorFloat get_SDJC() { }

	// RVA: 0xD7D310 Offset: 0xD7D310 VA: 0xD7D310
	private void update_normal() { }

	// RVA: 0xD7DC30 Offset: 0xD7DC30 VA: 0xD7DC30
	private bool CharacterMove(Vector3 motion) { }

	// RVA: 0xD7DD40 Offset: 0xD7DD40 VA: 0xD7DD40
	private void UpdatePositionToCharacter(Vector3 lastPos) { }

	// RVA: 0xD7D1B4 Offset: 0xD7D1B4 VA: 0xD7D1B4
	private void update_rotation() { }

	// RVA: 0xD7D0A0 Offset: 0xD7D0A0 VA: 0xD7D0A0
	private void UpdateOrientationNormal() { }

	// RVA: 0xD7DD44 Offset: 0xD7DD44 VA: 0xD7DD44
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x579FF4 Offset: 0x579FF4 VA: 0x579FF4
	// RVA: 0xD7DE6C Offset: 0xD7DE6C VA: 0xD7DE6C
	private float <TweenEyesHeight>b__5_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A004 Offset: 0x57A004 VA: 0x57A004
	// RVA: 0xD7DE74 Offset: 0xD7DE74 VA: 0xD7DE74
	private void <TweenEyesHeight>b__5_1(float r) { }
}
