// Namespace: 
public class UIBattleMiniCarControl : BaseView // TypeDefIndex: 5776
{
	// Fields
	private F2NormalButton mScanBtn; // 0x30
	private UIBattleJoystick _joystick; // 0x34
	private RectTransform _battleJoystickRt; // 0x38
	private GameObject _joystickRendererGo; // 0x3C
	private UIBattleMiniCarControl.JoystickTrans mJoystickTrans; // 0x40
	private F2NormalButton mLeftFireBtn; // 0x44
	private F2NormalButton mBack2CharacterUIBtn; // 0x48
	private F2NormalButton mJumpBtn; // 0x4C
	private F2NormalButton mRightScanBtn; // 0x50
	private GameObject mDragPanelGo; // 0x54
	private UIDragPanel _dragPanel; // 0x58
	private F2NormalButton mFireBtn; // 0x5C
	private F2NormalButton mLeftSwitchBtn; // 0x60
	private F2NormalButton mRightSwitchBtn; // 0x64
	private Image _carImg; // 0x68
	private Image _operatorImg; // 0x6C
	private Text _operatorNameText; // 0x70
	private Image _ownerImg; // 0x74
	private Text _ownerNameText; // 0x78
	private F2NormalButton mBtnCancel; // 0x7C
	private Scrollbar mTriggerScrollBar; // 0x80
	private GameObject mTriggerScrollBarGo; // 0x84
	private RectTransform mTriggerScrollBarRt; // 0x88
	private Text mTriggersText; // 0x8C
	private GameObject mTriggersTextGo; // 0x90
	private RectTransform mTriggersTextRt; // 0x94
	private GameObject mSnowFlakeEffectGo; // 0x98
	private RectTransform mNormalDecorationsRt; // 0x9C
	private const float CICLE_FLAG_WIDTH = 40;
	private const float CICLE_FLAG_INTERVAL = 3;
	private readonly Dictionary<U64Id, UIBattleMiniCarControl.CicleFlag> _flagDic; // 0xA0
	private readonly List<UIBattleMiniCarControl.CicleFlag> _flags; // 0xA4
	private readonly List<UIBattleMiniCarControl.CicleFlag> _flagsCopy; // 0xA8
	private bool _flagsIsDirty; // 0xAC
	private U64Id _curLookedMiniCarId; // 0xB0
	private UIBattleMiniCarControl.CicleFlag _curCicleFlag; // 0xB8
	private byte _curOperatorOfMiniCarId; // 0xBC
	private int _curSceneMiniCarCount; // 0xC0
	private RectTransform _cicleGoParent; // 0xC4
	private GameObject _miniCarCicleCloneGo; // 0xC8
	private bool _isCurMiniCarDead; // 0xCC
	[CompilerGeneratedAttribute] // RVA: 0x55EBDC Offset: 0x55EBDC VA: 0x55EBDC
	private IBattleMiniCarObserverHelper <MiniCarObserveHelper>k__BackingField; // 0xD0
	private UIBattleCrosshair _crossShair; // 0xD4
	private bool _enabledCrossHair; // 0xD8
	private NaviPathControl _naviPath; // 0xDC
	private Text placeText; // 0xE0
	private uint mCurNowCameraSoundBoxId; // 0xE4
	private int mUiState; // 0xE8

	// Properties
	public IBattleMiniCarObserverHelper MiniCarObserveHelper { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57ACDC Offset: 0x57ACDC VA: 0x57ACDC
	// RVA: 0xB43B94 Offset: 0xB43B94 VA: 0xB43B94
	private void set_MiniCarObserveHelper(IBattleMiniCarObserverHelper value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ACEC Offset: 0x57ACEC VA: 0x57ACEC
	// RVA: 0xB43B9C Offset: 0xB43B9C VA: 0xB43B9C
	public IBattleMiniCarObserverHelper get_MiniCarObserveHelper() { }

	// RVA: 0xB43BA4 Offset: 0xB43BA4 VA: 0xB43BA4
	public void .ctor() { }

	// RVA: 0xB43D00 Offset: 0xB43D00 VA: 0xB43D00 Slot: 19
	public override void InitViews() { }

	// RVA: 0xB44DA0 Offset: 0xB44DA0 VA: 0xB44DA0 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB45358 Offset: 0xB45358 VA: 0xB45358
	private void World_onnMiniCarOrCameraDeadEvt(int deadType, U64Id id) { }

	// RVA: 0xB456B0 Offset: 0xB456B0 VA: 0xB456B0 Slot: 21
	public override void Init() { }

	// RVA: 0xB45CB8 Offset: 0xB45CB8 VA: 0xB45CB8
	private void Instance_OnScanOperationDataRetEvt(RspScanEnemies obj) { }

	// RVA: 0xB46084 Offset: 0xB46084 VA: 0xB46084 Slot: 24
	public override void OnTick() { }

	// RVA: 0xB47BBC Offset: 0xB47BBC VA: 0xB47BBC
	private void UpdateMapLocationLabel() { }

	// RVA: 0xB480E8 Offset: 0xB480E8 VA: 0xB480E8 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xB478E8 Offset: 0xB478E8 VA: 0xB478E8
	private void UpdateCrosshair() { }

	// RVA: 0xB47E74 Offset: 0xB47E74 VA: 0xB47E74
	private void UpdateJoystickInput() { }

	// RVA: 0xB46294 Offset: 0xB46294 VA: 0xB46294
	private void UpdateNormalUI() { }

	// RVA: 0xB46AEC Offset: 0xB46AEC VA: 0xB46AEC
	private void UpdateCarOperationUI() { }

	// RVA: 0xB4829C Offset: 0xB4829C VA: 0xB4829C
	private void BeforeCicleFlagChanged() { }

	// RVA: 0xB484A8 Offset: 0xB484A8 VA: 0xB484A8
	private void AfterCicleFlagChanged() { }

	// RVA: 0xB49268 Offset: 0xB49268 VA: 0xB49268
	private void RefreshNormalDecorations(UIBattleMiniCarControl.CicleFlag flag) { }

	// RVA: 0xB480EC Offset: 0xB480EC VA: 0xB480EC
	private void UpdateFlagsCopy() { }

	// RVA: 0xB474E4 Offset: 0xB474E4 VA: 0xB474E4
	private void UpdateMiniCarSwitch() { }

	// RVA: 0xB4860C Offset: 0xB4860C VA: 0xB4860C
	private void RefreshMiniCarCiclesUISize() { }

	// RVA: 0xB487E0 Offset: 0xB487E0 VA: 0xB487E0
	private void RefreshCarOpUI() { }

	// RVA: 0xB48DD0 Offset: 0xB48DD0 VA: 0xB48DD0
	private void CheckAllMiniCarBeDestroyed() { }

	// RVA: 0xB476AC Offset: 0xB476AC VA: 0xB476AC
	private void HideSomeUI() { }

	// RVA: 0xB46290 Offset: 0xB46290 VA: 0xB46290
	private void UpdateJumpOp() { }

	// RVA: 0xB479D0 Offset: 0xB479D0 VA: 0xB479D0
	private void UpdateJoyStickDragPos() { }

	// RVA: 0xB493B0 Offset: 0xB493B0 VA: 0xB493B0
	private void MiniCarObserveHelper_OnUserFromMiniCarToCharacterControlEvt() { }

	// RVA: 0xB457D4 Offset: 0xB457D4 VA: 0xB457D4
	private void InstantiateCicles() { }

	// RVA: 0xB45950 Offset: 0xB45950 VA: 0xB45950
	private void InitOthers() { }

	// RVA: 0xB493B4 Offset: 0xB493B4 VA: 0xB493B4
	private void AddCicleFlag(IMiniCarProxy proxy, int idx) { }

	// RVA: 0xB484E0 Offset: 0xB484E0 VA: 0xB484E0
	private void RemoveCicleFlag(UIBattleMiniCarControl.CicleFlag flag) { }

	// RVA: 0xB496AC Offset: 0xB496AC VA: 0xB496AC Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xB4936C Offset: 0xB4936C VA: 0xB4936C
	private void OnClose() { }

	// RVA: 0xB496D8 Offset: 0xB496D8 VA: 0xB496D8
	private void __OnScanBtnBeClickedCallBackHandler() { }

	// RVA: 0xB49718 Offset: 0xB49718 VA: 0xB49718
	private void __OnBack2CharacterUIBtnBeClickedCallBackHandler() { }

	// RVA: 0xB49810 Offset: 0xB49810 VA: 0xB49810
	private void __OnJumpBtnBeClickedDownCallBackHandler() { }

	// RVA: 0xB4994C Offset: 0xB4994C VA: 0xB4994C
	private void __OnCancleBtnBeClickedCallBackHandler() { }

	// RVA: 0xB49A1C Offset: 0xB49A1C VA: 0xB49A1C Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB49CC4 Offset: 0xB49CC4 VA: 0xB49CC4
	private UIEventListener FindUIEventListener(Transform parentTrans, string name) { }

	// RVA: 0xB455F4 Offset: 0xB455F4 VA: 0xB455F4
	private void ShowSnowFlakeEffect(bool show) { }

	// RVA: 0xB49D0C Offset: 0xB49D0C VA: 0xB49D0C Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xB461B8 Offset: 0xB461B8 VA: 0xB461B8
	private void UpdateNodes() { }

	// RVA: 0xB49DEC Offset: 0xB49DEC VA: 0xB49DEC
	private void OnUiStateChange() { }

	// RVA: 0xB4A15C Offset: 0xB4A15C VA: 0xB4A15C
	private bool ToBool(int v) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ACFC Offset: 0x57ACFC VA: 0x57ACFC
	// RVA: 0xB4A16C Offset: 0xB4A16C VA: 0xB4A16C
	private void <Instance_OnScanOperationDataRetEvt>b__58_0(GameObject go) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD0C Offset: 0x57AD0C VA: 0x57AD0C
	// RVA: 0xB4A17C Offset: 0xB4A17C VA: 0xB4A17C
	private bool <RefreshCarOpUI>b__72_0(UIBattleMiniCarControl.CicleFlag x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD1C Offset: 0x57AD1C VA: 0x57AD1C
	// RVA: 0xB4A1C0 Offset: 0xB4A1C0 VA: 0xB4A1C0
	private void <InstantiateCicles>b__78_0(IMiniCarProxy x, int i) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD2C Offset: 0x57AD2C VA: 0x57AD2C
	// RVA: 0xB4A1C4 Offset: 0xB4A1C4 VA: 0xB4A1C4
	private void <__OnCancleBtnBeClickedCallBackHandler>b__88_0(GameObject go) { }
}
