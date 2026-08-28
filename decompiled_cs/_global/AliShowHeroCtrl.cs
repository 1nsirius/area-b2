// Namespace: 
public class AliShowHeroCtrl : AliShow3DBasic // TypeDefIndex: 5500
{
	// Fields
	private const string MODEL_HERO_ROOT_NAME = "HeroRoom/HeroBase";
	private const string MODEL_HERO_LIGHT_NAME = "Camera/HeroLight";
	private const string MODEL_WEAPON_LIGHT_NAME = "Camera/WeaponLight";
	[CompilerGeneratedAttribute] // RVA: 0x55DDA0 Offset: 0x55DDA0 VA: 0x55DDA0
	private int <characterId>k__BackingField; // 0x2C
	protected int animationId; // 0x30
	private Transform m_lightHeroRoot; // 0x34
	private Transform m_lightWeaponRoot; // 0x38
	private Transform m_heroControllerTrans; // 0x3C
	protected GameObject m_ModelGameObject; // 0x40
	protected Animator[] m_ModelAnims; // 0x44
	protected GameObject[] m_ModelVfxObjs; // 0x48
	protected char_skin_suit_table.Record m_SuitSkinCfg; // 0x4C
	protected Animator m_ModelAnimator; // 0x50
	protected List<ulong> effectIds; // 0x54
	private RectTransform m_heroRectTrans; // 0x58
	private Transform cameraTrans; // 0x5C
	public bool isMoving; // 0x60
	public bool isPlayEnterAnim; // 0x61
	[CompilerGeneratedAttribute] // RVA: 0x55DDB0 Offset: 0x55DDB0 VA: 0x55DDB0
	private bool <isInitSuccess>k__BackingField; // 0x62
	[CompilerGeneratedAttribute] // RVA: 0x55DDC0 Offset: 0x55DDC0 VA: 0x55DDC0
	private bool <destroyed>k__BackingField; // 0x63
	protected AliSwipHeroController swipController; // 0x64
	private GameObject m_DragObject; // 0x68
	private character_table.Record charCfg; // 0x6C
	private float _defaultFieldOfView; // 0x70
	private float _easeToFOVValue; // 0x74
	private Vector2 _fromHeroPos; // 0x78
	private Vector2 _targetHeroPos; // 0x80
	private float _PositionVelocity; // 0x88
	protected float progress; // 0x8C
	private int currentLevel; // 0x90
	private Vector3 cameraFromLocalPos; // 0x94
	private Vector3 cameraTargetLocalPos; // 0xA0
	public int curBodyId; // 0xAC
	public int curHeadId; // 0xB0
	public int curSuitId; // 0xB4
	private float StartInitTime; // 0xB8
	private Quaternion RoleRotation; // 0xBC
	public bool enableSwitchLevel; // 0xCC
	private bool playRotEnterAnim; // 0xCD
	private float rotStartTime; // 0xD0
	private float targetFOV; // 0xD4
	private bool isRot; // 0xD8
	private int startFovLevel; // 0xDC
	private float startFov; // 0xE0

	// Properties
	public int characterId { get; set; }
	protected bool isInitSuccess { get; set; }
	public bool destroyed { get; set; }
	public float FieldOfView { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x579D24 Offset: 0x579D24 VA: 0x579D24
	// RVA: 0xCAFF08 Offset: 0xCAFF08 VA: 0xCAFF08
	public int get_characterId() { }

	[CompilerGeneratedAttribute] // RVA: 0x579D34 Offset: 0x579D34 VA: 0x579D34
	// RVA: 0xCAFF10 Offset: 0xCAFF10 VA: 0xCAFF10
	private void set_characterId(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579D44 Offset: 0x579D44 VA: 0x579D44
	// RVA: 0xCAFF18 Offset: 0xCAFF18 VA: 0xCAFF18
	protected bool get_isInitSuccess() { }

	[CompilerGeneratedAttribute] // RVA: 0x579D54 Offset: 0x579D54 VA: 0x579D54
	// RVA: 0xCAFF20 Offset: 0xCAFF20 VA: 0xCAFF20
	private void set_isInitSuccess(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x579D64 Offset: 0x579D64 VA: 0x579D64
	// RVA: 0xCAFF28 Offset: 0xCAFF28 VA: 0xCAFF28
	public bool get_destroyed() { }

	[CompilerGeneratedAttribute] // RVA: 0x579D74 Offset: 0x579D74 VA: 0x579D74
	// RVA: 0xCAFF30 Offset: 0xCAFF30 VA: 0xCAFF30
	public void set_destroyed(bool value) { }

	// RVA: 0xCAFF38 Offset: 0xCAFF38 VA: 0xCAFF38 Slot: 8
	public virtual void Awake(int characterId, GameObject dragObj, int defaultViewLevel = 1) { }

	// RVA: 0xCB0314 Offset: 0xCB0314 VA: 0xCB0314
	public void PlayEnterAnim(Action finishCallBack) { }

	// RVA: 0xCB045C Offset: 0xCB045C VA: 0xCB045C
	private void PlayEnter() { }

	// RVA: 0xCB07E4 Offset: 0xCB07E4 VA: 0xCB07E4
	public void SetSkinId(int charSkinBodyId, int charSkinHeadId, int suitSkinId) { }

	// RVA: 0xCB07F0 Offset: 0xCB07F0 VA: 0xCB07F0
	public void ResetScene() { }

	// RVA: 0xCB093C Offset: 0xCB093C VA: 0xCB093C Slot: 4
	protected override void CreateDisplayModel(int defaultViewLevel = 1) { }

	// RVA: 0xCB137C Offset: 0xCB137C VA: 0xCB137C Slot: 5
	public override void Clear() { }

	// RVA: 0xCB18BC Offset: 0xCB18BC VA: 0xCB18BC
	public void SetHeroOffsetPos(Vector2 offsetPos) { }

	// RVA: 0xCB19AC Offset: 0xCB19AC VA: 0xCB19AC
	public void ResetView() { }

	// RVA: 0xCB1164 Offset: 0xCB1164 VA: 0xCB1164
	public void InitViewLevel(int level = 1) { }

	// RVA: 0xCB1DFC Offset: 0xCB1DFC VA: 0xCB1DFC
	public float GetFovForLevel(int level) { }

	// RVA: 0xCB1BDC Offset: 0xCB1BDC VA: 0xCB1BDC
	public bool SetViewLevel(int level = 1, bool init = False) { }

	// RVA: 0xCB1E54 Offset: 0xCB1E54 VA: 0xCB1E54 Slot: 9
	public virtual void Update() { }

	// RVA: 0xCB2168 Offset: 0xCB2168 VA: 0xCB2168
	public float get_FieldOfView() { }

	// RVA: 0xCB1A60 Offset: 0xCB1A60 VA: 0xCB1A60
	public void set_FieldOfView(float value) { }

	// RVA: 0xCB2220 Offset: 0xCB2220 VA: 0xCB2220 Slot: 10
	public virtual void LateUpdate() { }

	// RVA: 0xCB28B0 Offset: 0xCB28B0 VA: 0xCB28B0 Slot: 7
	protected override bool InitSceneRoot() { }

	// RVA: 0xCAF3C0 Offset: 0xCAF3C0 VA: 0xCAF3C0
	public void .ctor() { }
}
