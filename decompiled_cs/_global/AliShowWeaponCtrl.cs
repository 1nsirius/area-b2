// Namespace: 
public class AliShowWeaponCtrl : AliShow3DBasic // TypeDefIndex: 5508
{
	// Fields
	private const string MODEL_HERO_ROOT_NAME = "HeroRoom/HeroBase";
	private const string MODEL_GOROTATE_ROOT_NAME = "HeroRoom/HeroBase/GoRotate";
	private const string XLINE = "HeroRoom/CubeX";
	private const string LOOKATTRANS1 = "HeroRoom/LookAt1";
	private const string LOOKATTRANS2 = "HeroRoom/LookAt2";
	private const string LOOKATTRANS = "HeroRoom/HeroBase/LookAt";
	private const string MODEL_HERO_LIGHT_NAME = "Camera/HeroLight";
	private const string MODEL_WEAPON_LIGHT_NAME = "Camera/WeaponLight";
	[CompilerGeneratedAttribute] // RVA: 0x55DE00 Offset: 0x55DE00 VA: 0x55DE00
	private int <weaponSkinId>k__BackingField; // 0x2C
	protected int animationId; // 0x30
	private Transform m_lightHeroRoot; // 0x34
	private Transform m_lightWeaponRoot; // 0x38
	private Transform HeroBaseTrans; // 0x3C
	private Transform XLineTrans; // 0x40
	private Transform LookAtTrans; // 0x44
	private Transform LookAtTrans1; // 0x48
	private Transform LookAtTrans2; // 0x4C
	private Vector3 m_heroCtrDefaultPos; // 0x50
	protected GameObject m_ModelGameObject; // 0x5C
	protected Animator m_ModelAnimator; // 0x60
	protected List<ulong> effectIds; // 0x64
	private RectTransform HeroBaseRectTrans; // 0x68
	private Transform m_GoRotateTrans; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x55DE10 Offset: 0x55DE10 VA: 0x55DE10
	private bool <isInitSuccess>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x55DE20 Offset: 0x55DE20 VA: 0x55DE20
	private bool <destroyed>k__BackingField; // 0x71
	protected AliSwipHeroController swipController; // 0x74
	private GameObject m_DragObject; // 0x78
	private float _defaultFieldOfView; // 0x7C
	private float _easeToFOVValue; // 0x80
	private Vector2 _fromHeroPos; // 0x84
	private Vector2 _targetHeroPos; // 0x8C
	private float _PositionVelocity; // 0x94
	protected float progress; // 0x98
	private int currentLevel; // 0x9C
	private int[] toolAttachment; // 0xA0
	private Vector3 PendantPosOffset; // 0xA4
	private Vector3 PendantEuler; // 0xB0
	private AttachmentPoints attachmentPoints; // 0xBC
	private Vector3 SightPosOffset; // 0x2F0
	private Vector3 SightEuler; // 0x2FC
	private bool isEquipSight; // 0x308
	private bool isEquipPendant; // 0x309
	private AliAngleDebug angleDebugComp; // 0x30C
	private Vector3 targetEuler; // 0x310
	private bool defaultRotAuto; // 0x31C
	private float startFov; // 0x320
	private int startFovLevel; // 0x324
	private Vector3 startObjPos; // 0x328
	private Vector3 targetObjPos; // 0x334
	public bool isMoving; // 0x340

	// Properties
	public int weaponSkinId { get; set; }
	protected bool isInitSuccess { get; set; }
	public bool destroyed { get; set; }
	public float FieldOfView { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x579E5C Offset: 0x579E5C VA: 0x579E5C
	// RVA: 0xCB6F20 Offset: 0xCB6F20 VA: 0xCB6F20
	public int get_weaponSkinId() { }

	[CompilerGeneratedAttribute] // RVA: 0x579E6C Offset: 0x579E6C VA: 0x579E6C
	// RVA: 0xCB6F28 Offset: 0xCB6F28 VA: 0xCB6F28
	private void set_weaponSkinId(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579E7C Offset: 0x579E7C VA: 0x579E7C
	// RVA: 0xCB6F30 Offset: 0xCB6F30 VA: 0xCB6F30
	protected bool get_isInitSuccess() { }

	[CompilerGeneratedAttribute] // RVA: 0x579E8C Offset: 0x579E8C VA: 0x579E8C
	// RVA: 0xCB6F38 Offset: 0xCB6F38 VA: 0xCB6F38
	private void set_isInitSuccess(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579E9C Offset: 0x579E9C VA: 0x579E9C
	// RVA: 0xCB6F40 Offset: 0xCB6F40 VA: 0xCB6F40
	public bool get_destroyed() { }

	[CompilerGeneratedAttribute] // RVA: 0x579EAC Offset: 0x579EAC VA: 0x579EAC
	// RVA: 0xCB6F48 Offset: 0xCB6F48 VA: 0xCB6F48
	public void set_destroyed(bool value) { }

	// RVA: 0xCB6F50 Offset: 0xCB6F50 VA: 0xCB6F50 Slot: 8
	public virtual void Awake(int weaponSkinId, GameObject dragObj, int[] toolAttachment, int defaultViewLevel = 1) { }

	// RVA: 0xCB3FA4 Offset: 0xCB3FA4 VA: 0xCB3FA4
	public void ResetScene() { }

	// RVA: 0xCB71F4 Offset: 0xCB71F4 VA: 0xCB71F4 Slot: 4
	protected override void CreateDisplayModel(int defaultViewLevel = 1) { }

	// RVA: 0xCB85E0 Offset: 0xCB85E0 VA: 0xCB85E0 Slot: 5
	public override void Clear() { }

	// RVA: 0xCB42F8 Offset: 0xCB42F8 VA: 0xCB42F8
	public void SetHeroOffsetPos(Vector2 offsetPos) { }

	// RVA: 0xCB4510 Offset: 0xCB4510 VA: 0xCB4510
	public void ResetView() { }

	// RVA: 0xCB82C4 Offset: 0xCB82C4 VA: 0xCB82C4
	public void InitViewLevel(int level = 1) { }

	// RVA: 0xCB4740 Offset: 0xCB4740 VA: 0xCB4740
	public bool SetViewLevel(int level = 1) { }

	// RVA: 0xCB89D0 Offset: 0xCB89D0 VA: 0xCB89D0
	public float GetFovForLevel(int level) { }

	// RVA: 0xCB8C4C Offset: 0xCB8C4C VA: 0xCB8C4C Slot: 9
	public virtual void Update() { }

	// RVA: 0xCB917C Offset: 0xCB917C VA: 0xCB917C
	public float get_FieldOfView() { }

	// RVA: 0xCB8854 Offset: 0xCB8854 VA: 0xCB8854
	public void set_FieldOfView(float value) { }

	// RVA: 0xCB9234 Offset: 0xCB9234 VA: 0xCB9234 Slot: 10
	public virtual void LateUpdate() { }

	// RVA: 0xCB925C Offset: 0xCB925C VA: 0xCB925C Slot: 7
	protected override bool InitSceneRoot() { }

	// RVA: 0xCB350C Offset: 0xCB350C VA: 0xCB350C
	public void .ctor() { }
}
