// Namespace: 
public class AliShowPendantCtrl : AliShow3DBasic // TypeDefIndex: 5505
{
	// Fields
	private const string MODEL_HERO_ROOT_NAME = "HeroRoom/HeroBase";
	private const string MODEL_GOROTATE_ROOT_NAME = "HeroRoom/HeroBase/GoRotate";
	private const string MODEL_HERO_LIGHT_NAME = "Camera/HeroLight";
	private const string MODEL_WEAPON_LIGHT_NAME = "Camera/WeaponLight";
	private Transform m_lightHeroRoot; // 0x2C
	private Transform m_lightWeaponRoot; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x55DDD0 Offset: 0x55DDD0 VA: 0x55DDD0
	private int <skinId>k__BackingField; // 0x34
	protected int animationId; // 0x38
	private Transform m_GoRotateTrans; // 0x3C
	private Transform m_heroControllerTrans; // 0x40
	protected GameObject m_ModelGameObject; // 0x44
	protected Animator m_ModelAnimator; // 0x48
	protected List<ulong> effectIds; // 0x4C
	private RectTransform m_heroRectTrans; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x55DDE0 Offset: 0x55DDE0 VA: 0x55DDE0
	private bool <isInitSuccess>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x55DDF0 Offset: 0x55DDF0 VA: 0x55DDF0
	private bool <destroyed>k__BackingField; // 0x55
	protected AliSwipHeroController swipController; // 0x58
	private GameObject m_DragObject; // 0x5C
	private float _defaultFieldOfView; // 0x60
	private float _easeToFOVValue; // 0x64
	private float _FOVVelocity; // 0x68
	private Vector2 _fromHeroPos; // 0x6C
	private Vector2 _targetHeroPos; // 0x74
	private float _PositionVelocity; // 0x7C
	protected float progress; // 0x80
	private int currentLevel; // 0x84
	private Vector3 cameraFromLocalPos; // 0x88
	private Vector3 cameraTargetLocalPos; // 0x94
	private bool isFirstRot; // 0xA0

	// Properties
	public int skinId { get; set; }
	protected bool isInitSuccess { get; set; }
	public bool destroyed { get; set; }
	public float FieldOfView { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x579DFC Offset: 0x579DFC VA: 0x579DFC
	// RVA: 0xCB532C Offset: 0xCB532C VA: 0xCB532C
	public int get_skinId() { }

	[CompilerGeneratedAttribute] // RVA: 0x579E0C Offset: 0x579E0C VA: 0x579E0C
	// RVA: 0xCB5334 Offset: 0xCB5334 VA: 0xCB5334
	private void set_skinId(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579E1C Offset: 0x579E1C VA: 0x579E1C
	// RVA: 0xCB533C Offset: 0xCB533C VA: 0xCB533C
	protected bool get_isInitSuccess() { }

	[CompilerGeneratedAttribute] // RVA: 0x579E2C Offset: 0x579E2C VA: 0x579E2C
	// RVA: 0xCB5344 Offset: 0xCB5344 VA: 0xCB5344
	private void set_isInitSuccess(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579E3C Offset: 0x579E3C VA: 0x579E3C
	// RVA: 0xCB534C Offset: 0xCB534C VA: 0xCB534C
	public bool get_destroyed() { }

	[CompilerGeneratedAttribute] // RVA: 0x579E4C Offset: 0x579E4C VA: 0x579E4C
	// RVA: 0xCB5354 Offset: 0xCB5354 VA: 0xCB5354
	public void set_destroyed(bool value) { }

	// RVA: 0xCB535C Offset: 0xCB535C VA: 0xCB535C Slot: 8
	public virtual void Awake(int skinId, GameObject dragObj, int defaultViewLevel = 1) { }

	// RVA: 0xCB40F0 Offset: 0xCB40F0 VA: 0xCB40F0
	public void ResetScene() { }

	// RVA: 0xCB5570 Offset: 0xCB5570 VA: 0xCB5570 Slot: 4
	protected override void CreateDisplayModel(int defaultViewLevel = 1) { }

	// RVA: 0xCB5D88 Offset: 0xCB5D88 VA: 0xCB5D88 Slot: 5
	public override void Clear() { }

	// RVA: 0xCB43E8 Offset: 0xCB43E8 VA: 0xCB43E8
	public void SetHeroOffsetPos(Vector2 offsetPos) { }

	// RVA: 0xCB45C4 Offset: 0xCB45C4 VA: 0xCB45C4
	public void ResetView() { }

	// RVA: 0xCB5B94 Offset: 0xCB5B94 VA: 0xCB5B94
	public void InitViewLevel(int level = 1) { }

	// RVA: 0xCB4DC4 Offset: 0xCB4DC4 VA: 0xCB4DC4
	public void SetViewLevel(int level = 1) { }

	// RVA: 0xCB61C4 Offset: 0xCB61C4 VA: 0xCB61C4 Slot: 9
	public virtual void Update() { }

	// RVA: 0xCB6348 Offset: 0xCB6348 VA: 0xCB6348
	public float get_FieldOfView() { }

	// RVA: 0xCB6048 Offset: 0xCB6048 VA: 0xCB6048
	public void set_FieldOfView(float value) { }

	// RVA: 0xCB6400 Offset: 0xCB6400 VA: 0xCB6400 Slot: 10
	public virtual void LateUpdate() { }

	// RVA: 0xCB651C Offset: 0xCB651C VA: 0xCB651C Slot: 7
	protected override bool InitSceneRoot() { }

	// RVA: 0xCB3858 Offset: 0xCB3858 VA: 0xCB3858
	public void .ctor() { }
}
