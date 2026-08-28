// Namespace: 
public class UIBattleFPControl : BaseView // TypeDefIndex: 5749
{
	// Fields
	private int skillButtonUpdateFrameCnts; // 0x30
	private int leftButtonUpdateFrame; // 0x34
	private UIBattleJoystick joystick; // 0x38
	private RectTransform _battleJoystickRt; // 0x3C
	private RectTransform joystickTrans; // 0x40
	private RectTransform joystickTransParent; // 0x44
	private UIDragPanel dragPanel; // 0x48
	private UIEventListener mBtnClimbing; // 0x4C
	private GameObject mBtnClimbingGo; // 0x50
	private RectTransform mBtnClimbingRt; // 0x54
	private LanguageMono mBtnClimbingText; // 0x58
	private UIEventListener mBtnClimbLadder; // 0x5C
	private GameObject mBtnClimbLadderGo; // 0x60
	private RectTransform mBtnClimbLadderRt; // 0x64
	private Scrollbar mTriggerScrollBar; // 0x68
	private GameObject mTriggerScrollBarGo; // 0x6C
	private RectTransform mTriggerScrollBarRt; // 0x70
	private Button mBtnCancel; // 0x74
	private GameObject mBtnCancelGo; // 0x78
	private RectTransform mBtnCancelRt; // 0x7C
	private Text mTriggersText; // 0x80
	private GameObject mTriggersTextGo; // 0x84
	private RectTransform mTriggersTextRt; // 0x88
	private bool _is_advans_model; // 0x8C
	private bool aim_fire; // 0x8D
	private bool mRightAimFire; // 0x8E
	private bool fire; // 0x8F
	private bool mRightFire; // 0x90
	private bool hip_fire; // 0x91
	private RectTransform mCurPoseImg; // 0x94
	private PoseImgConfig mPoseImgConfig; // 0x98
	private HPComponent0 _hpComp; // 0x9C
	private SimpleBloodPanel mExtraHPComp; // 0xA0
	private Image imgHpProgress; // 0xA4
	private Text texHpNum; // 0xA8
	private GameObject _guardBuffGo; // 0xAC
	private RectTransform mGuardBuffRt; // 0xB0
	private Image _guardBuffImg; // 0xB4
	private UIBattleFPControl.TraceBuffUI _traceBuffUI; // 0xB8
	private UIBattleFPControl.TraceBuffUI _scanBuffUI; // 0xBC
	private UIBattleCrosshair _crossShair; // 0xC0
	private bool _enabledCrossHair; // 0xC4
	private GrenadeCountDown grenadeCountdown; // 0xC8
	private MainCharacterController mainCtrl; // 0xCC
	private Text placeText; // 0xD0
	[CompilerGeneratedAttribute] // RVA: 0x55EBBC Offset: 0x55EBBC VA: 0x55EBBC
	private Action mUpdateEve; // 0xD4
	private GameObject _agonalProgressGo; // 0xD8
	private RectTransform mAgonalProgressRt; // 0xDC
	private Image _imgAgnoalProgress; // 0xE0
	private const float MAX_DEGREE = 30;
	private DoubleClickListener mDoubleClickListener; // 0xE4
	private FingerPosListener mFingerPosListener; // 0xE8
	private RectTransform mBtnFireRoot; // 0xEC
	private UIBattleFPControl.Node mBtnChangePos; // 0xF0
	private UIBattleFPControl.Node mBtnCreep; // 0xF4
	private UIBattleFPControl.Node mBtnCrouch; // 0xF8
	private UIBattleFPControl.Node mBtnKnife; // 0xFC
	private UIBattleFPControl.LockMoveNodeCtrlr mBtnLockMoveNodeCtrlr; // 0x100
	private UIBattleFPControl.MachineBtnCtrlr mBtnMachine; // 0x104
	private MarkBtnCtrlr mBtnMarkCtrlr; // 0x108
	private UIBattleFPControl.Node mBtnScout; // 0x10C
	private UIBattleFPControl.TiltBtnCtrlr mBtnTiltCtlr; // 0x110
	private FireHandler mFireHandlerL; // 0x114
	private FireHandler mFireHandlerR; // 0x118
	private FireHandler mFireHandlerW; // 0x11C
	private UIBattleFPControl.JoystickLockMoveCtrlr mJoyStickLockMoveCtrlr; // 0x120
	private RectTransform mJoyStickLockMoveIcon; // 0x124
	private List<IUiNodeCtrlr> mNodeCtrlrs; // 0x128
	private List<UIBattleFPControl.Node> mNodes; // 0x12C
	private UIBattleFPControl.Node mReload; // 0x130
	private Dictionary<UIBattleFPControl.ESkillBtnEnum, SkillButton> mSkillBtns; // 0x134
	private WeaponCompCtrlr mWeaponMain; // 0x138
	private WeaponCompCtrlr mWeaponScene; // 0x13C
	private WeaponCompCtrlr mWeaponSecond; // 0x140
	private int mUiState; // 0x144
	private uint mCurNowCameraSoundBoxId; // 0x148

	// Properties
	private static BattleConfiguration.SkillBtnColors BtnColors { get; }

	// Methods

	// RVA: 0xB281B8 Offset: 0xB281B8 VA: 0xB281B8
	public void .ctor() { }

	// RVA: 0xB2826C Offset: 0xB2826C VA: 0xB2826C Slot: 19
	public override void InitViews() { }

	// RVA: 0xB2AD8C Offset: 0xB2AD8C VA: 0xB2AD8C
	private void HandleOnFirePressDown() { }

	// RVA: 0xB2ADA8 Offset: 0xB2ADA8 VA: 0xB2ADA8
	private void HandleOnRightFirePressDown() { }

	// RVA: 0xB2ADC0 Offset: 0xB2ADC0 VA: 0xB2ADC0
	private void HandleOnFirePressUp() { }

	// RVA: 0xB2ADDC Offset: 0xB2ADDC VA: 0xB2ADDC
	private void HandleOnRightFirePressUp() { }

	// RVA: 0xB298C4 Offset: 0xB298C4 VA: 0xB298C4
	private void InitJoystickUI(RectTransform parentTransform) { }

	// RVA: 0xB2AF30 Offset: 0xB2AF30 VA: 0xB2AF30 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB2B70C Offset: 0xB2B70C VA: 0xB2B70C
	private void World_onBeforeSelfCharacterChange2AgonaledEvt() { }

	// RVA: 0xB2B900 Offset: 0xB2B900 VA: 0xB2B900
	private void World_onBeforeSelfCharacterFromAgonaled2NormalEvt() { }

	// RVA: 0xB2B9FC Offset: 0xB2B9FC VA: 0xB2B9FC
	private void World_OnTrackerReportEvt(RspTrackerReport.Data data) { }

	// RVA: 0xB2BBC4 Offset: 0xB2BBC4 VA: 0xB2BBC4
	private void TryToShowYouWasFound(RspTrackerReport.Data data) { }

	// RVA: 0xB2BF0C Offset: 0xB2BF0C VA: 0xB2BF0C Slot: 21
	public override void Init() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABDC Offset: 0x57ABDC VA: 0x57ABDC
	// RVA: 0xB2BF10 Offset: 0xB2BF10 VA: 0xB2BF10
	private void add_mUpdateEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABEC Offset: 0x57ABEC VA: 0x57ABEC
	// RVA: 0xB2C01C Offset: 0xB2C01C VA: 0xB2C01C
	private void remove_mUpdateEve(Action value) { }

	// RVA: 0xB2C128 Offset: 0xB2C128 VA: 0xB2C128 Slot: 24
	public override void OnTick() { }

	// RVA: 0xB2A76C Offset: 0xB2A76C VA: 0xB2A76C
	private void InitAgonalControls() { }

	// RVA: 0xB2C7D0 Offset: 0xB2C7D0 VA: 0xB2C7D0
	private void UpdateAgonalControl() { }

	// RVA: 0xB2C858 Offset: 0xB2C858 VA: 0xB2C858
	private void UpdateAgonalInfo() { }

	// RVA: 0xB2C248 Offset: 0xB2C248 VA: 0xB2C248
	private void UpdateNormalControl() { }

	// RVA: 0xB2D10C Offset: 0xB2D10C VA: 0xB2D10C
	private void UpdateJoyStickDragPos() { }

	// RVA: 0xB2D55C Offset: 0xB2D55C VA: 0xB2D55C
	private void UpdateCrossHair() { }

	// RVA: 0xB2D75C Offset: 0xB2D75C VA: 0xB2D75C
	private void UpdateTracker() { }

	// RVA: 0xB2E010 Offset: 0xB2E010 VA: 0xB2E010
	private void OnBtnReloadClick(PointerEventData eventData) { }

	// RVA: 0xB2D068 Offset: 0xB2D068 VA: 0xB2D068
	private void PostFireState() { }

	// RVA: 0xB2B878 Offset: 0xB2B878 VA: 0xB2B878
	private void ClearFireState() { }

	// RVA: 0xB2E040 Offset: 0xB2E040 VA: 0xB2E040
	private void OnBtnCrouchClick(PointerEventData eventData) { }

	// RVA: 0xB2E1A4 Offset: 0xB2E1A4 VA: 0xB2E1A4
	private void OnBtnCreepClick(PointerEventData eventData) { }

	// RVA: 0xB2E2B4 Offset: 0xB2E2B4 VA: 0xB2E2B4
	private bool IsPlayerInRopePose() { }

	// RVA: 0xB2E510 Offset: 0xB2E510 VA: 0xB2E510
	private void OnBtnMachineAtClick(PointerEventData eventData) { }

	// RVA: 0xB2E56C Offset: 0xB2E56C VA: 0xB2E56C
	private void OnBtnScoutClick() { }

	// RVA: 0xB2D2B0 Offset: 0xB2D2B0 VA: 0xB2D2B0
	private void UpdateBtnState() { }

	// RVA: 0xB2EB34 Offset: 0xB2EB34 VA: 0xB2EB34
	private void UpdateGuard() { }

	// RVA: 0xB2ED74 Offset: 0xB2ED74 VA: 0xB2ED74
	private static BattleConfiguration.SkillBtnColors get_BtnColors() { }

	// RVA: 0xB2D2CC Offset: 0xB2D2CC VA: 0xB2D2CC
	private void UpdateUIStateFromTriggerConditions() { }

	// RVA: 0xB2ABCC Offset: 0xB2ABCC VA: 0xB2ABCC
	private void RefreshPosesUIState() { }

	// RVA: 0xB2EDB4 Offset: 0xB2EDB4 VA: 0xB2EDB4
	private void UpdateRunUIState() { }

	// RVA: 0xB2EF8C Offset: 0xB2EF8C VA: 0xB2EF8C
	private void UpdateHpInfo() { }

	// RVA: 0xB2F220 Offset: 0xB2F220 VA: 0xB2F220
	private void UpdateOthers() { }

	// RVA: 0xB2F494 Offset: 0xB2F494 VA: 0xB2F494
	private void OnBtnPlaceShieldBeClicked(PointerEventData evtData) { }

	// RVA: 0xB2F498 Offset: 0xB2F498 VA: 0xB2F498
	private void OnBtnClimbingBeClicked() { }

	// RVA: 0xB2F53C Offset: 0xB2F53C VA: 0xB2F53C
	private void OnBtnClimbLadderBeClicked() { }

	// RVA: 0xB2F56C Offset: 0xB2F56C VA: 0xB2F56C
	private void OnBtnCancelBeClicked() { }

	// RVA: 0xB2F59C Offset: 0xB2F59C VA: 0xB2F59C Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xB2F834 Offset: 0xB2F834 VA: 0xB2F834
	private void CheckOthers() { }

	// RVA: 0xB2F8A8 Offset: 0xB2F8A8 VA: 0xB2F8A8 Slot: 26
	public override void OnViewClose() { }

	// RVA: 0xB2F924 Offset: 0xB2F924 VA: 0xB2F924
	private UIEventListener FindUIEventListener(Transform parentTrans, string name) { }

	// RVA: 0xB2F96C Offset: 0xB2F96C VA: 0xB2F96C Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xB2FA4C Offset: 0xB2FA4C VA: 0xB2FA4C
	private void OnBodyStateChange(EBodyState last) { }

	// RVA: 0xB2FA50 Offset: 0xB2FA50 VA: 0xB2FA50 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB2FE7C Offset: 0xB2FE7C VA: 0xB2FE7C
	private void DisposeEmptyArea() { }

	// RVA: 0xB2FFC0 Offset: 0xB2FFC0 VA: 0xB2FFC0
	private void HandleOnAimming() { }

	// RVA: 0xB300BC Offset: 0xB300BC VA: 0xB300BC
	private void HandleOnFingerMove(Vector2 screenPos) { }

	// RVA: 0xB2A8F4 Offset: 0xB2A8F4 VA: 0xB2A8F4
	private void InitEmptyArea(Transform root) { }

	// RVA: 0xB30328 Offset: 0xB30328 VA: 0xB30328
	private UIBattleFPControl.Node CreateNode(RectTransform root, Action ontick) { }

	// RVA: -1 Offset: -1
	private T CreateNodeCtrlr<T>() { }
	/* GenericInstMethod :
	|
	|-RVA: 0xDEEFC0 Offset: 0xDEEFC0 VA: 0xDEEFC0
	|-UIBattleFPControl.CreateNodeCtrlr<object>
	|-UIBattleFPControl.CreateNodeCtrlr<UIBattleFPControl.MachineBtnCtrlr>
	|-UIBattleFPControl.CreateNodeCtrlr<UIBattleFPControl.TiltBtnCtrlr>
	*/

	// RVA: 0xB30418 Offset: 0xB30418 VA: 0xB30418
	private SkillCtrlProxy CreateSkillProxy(SkillIndex skillIndex) { }

	// RVA: 0xB30648 Offset: 0xB30648 VA: 0xB30648
	private void InitBtnCreep(RectTransform parentTransform) { }

	// RVA: 0xB30B14 Offset: 0xB30B14 VA: 0xB30B14
	private void InitBtnCrouch(RectTransform parentTransform) { }

	// RVA: 0xB30D0C Offset: 0xB30D0C VA: 0xB30D0C
	private void InitBtnKnife(RectTransform parentTransform) { }

	// RVA: 0xB30EAC Offset: 0xB30EAC VA: 0xB30EAC
	private void InitBtnLockMove(RectTransform parentTransform) { }

	// RVA: 0xB3124C Offset: 0xB3124C VA: 0xB3124C
	private void InitBtnMachine(RectTransform parentTransform) { }

	// RVA: 0xB316DC Offset: 0xB316DC VA: 0xB316DC
	private void InitBtnMark(RectTransform parentTransform) { }

	// RVA: 0xB31798 Offset: 0xB31798 VA: 0xB31798
	private void InitBtnReload(RectTransform parentTransform) { }

	// RVA: 0xB3185C Offset: 0xB3185C VA: 0xB3185C
	private void InitBtnScout(RectTransform parentTransform) { }

	// RVA: 0xB31920 Offset: 0xB31920 VA: 0xB31920
	private void InitJoyStickLockMove(RectTransform parentTransform) { }

	// RVA: 0xB290A4 Offset: 0xB290A4 VA: 0xB290A4
	private void InitNodes(RectTransform parentTransform) { }

	// RVA: 0xB2A164 Offset: 0xB2A164 VA: 0xB2A164
	private void InitSkillBtns(RectTransform parentTransform) { }

	// RVA: 0xB29D84 Offset: 0xB29D84 VA: 0xB29D84
	private void InitWeapon(RectTransform parentTransform) { }

	// RVA: 0xB31B7C Offset: 0xB31B7C VA: 0xB31B7C
	private void InnerInitSkillBtn(RectTransform parentTransform, string name, UIBattleFPControl.ESkillBtnEnum skillBtnEnum, SkillIndex skillIndex) { }

	// RVA: 0xB31CB4 Offset: 0xB31CB4 VA: 0xB31CB4
	private void InnerInitSkillBtn(RectTransform parentTransform, string name, UIBattleFPControl.ESkillBtnEnum skillBtnEnum, ISkillCtrlrProxy skillCtrlrProxy) { }

	// RVA: 0xB31BC0 Offset: 0xB31BC0 VA: 0xB31BC0
	private FireHandler InnerInitSkillBtnFire(RectTransform parentTransform, string name, UIBattleFPControl.ESkillBtnEnum skillBtnEnum, int buttonId, Action onPressDown, Action onPressUp) { }

	// RVA: 0xB31E4C Offset: 0xB31E4C VA: 0xB31E4C
	private void KnifeOnTick() { }

	// RVA: 0xB32144 Offset: 0xB32144 VA: 0xB32144
	private void OnUiStateChange() { }

	// RVA: 0xB32D78 Offset: 0xB32D78 VA: 0xB32D78
	private void SetJoystickEnable(bool enable) { }

	// RVA: 0xB32BC8 Offset: 0xB32BC8 VA: 0xB32BC8
	private bool ToBool(int v) { }

	// RVA: 0xB32E1C Offset: 0xB32E1C VA: 0xB32E1C
	private void UpdateBtnCreep() { }

	// RVA: 0xB3326C Offset: 0xB3326C VA: 0xB3326C
	private void UpdateBtnCrouch() { }

	// RVA: 0xB2DB08 Offset: 0xB2DB08 VA: 0xB2DB08
	private void UpdateFireBtn() { }

	// RVA: 0xB2C934 Offset: 0xB2C934 VA: 0xB2C934
	private void UpdateNodes() { }

	// RVA: 0xB33998 Offset: 0xB33998 VA: 0xB33998
	private void UpdateRopeChangePos() { }

	// RVA: 0xB2EB80 Offset: 0xB2EB80 VA: 0xB2EB80
	private void UpdateWeapon() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABFC Offset: 0x57ABFC VA: 0x57ABFC
	// RVA: 0xB33AF0 Offset: 0xB33AF0 VA: 0xB33AF0
	private void <InitJoystickUI>b__52_0(Vector2 pos) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC0C Offset: 0x57AC0C VA: 0x57AC0C
	// RVA: 0xB33CA8 Offset: 0xB33CA8 VA: 0xB33CA8
	private void <AddListeners>b__53_0(PointerEventData ed) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC1C Offset: 0x57AC1C VA: 0x57AC1C
	// RVA: 0xB33CAC Offset: 0xB33CAC VA: 0xB33CAC
	private void <AddListeners>b__53_1(PointerEventData eve) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC2C Offset: 0x57AC2C VA: 0x57AC2C
	// RVA: 0xB33CB0 Offset: 0xB33CB0 VA: 0xB33CB0
	private void <AddListeners>b__53_2(PointerEventData ed) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC3C Offset: 0x57AC3C VA: 0x57AC3C
	// RVA: 0xB33CE0 Offset: 0xB33CE0 VA: 0xB33CE0
	private void <AddListeners>b__53_3() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC4C Offset: 0x57AC4C VA: 0x57AC4C
	// RVA: 0xB33CF4 Offset: 0xB33CF4 VA: 0xB33CF4
	private void <AddListeners>b__53_4() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC5C Offset: 0x57AC5C VA: 0x57AC5C
	// RVA: 0xB33D08 Offset: 0xB33D08 VA: 0xB33D08
	private void <AddListeners>b__53_5(U64Id uid, float duration) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC6C Offset: 0x57AC6C VA: 0x57AC6C
	// RVA: 0xB33DE4 Offset: 0xB33DE4 VA: 0xB33DE4
	private void <AddListeners>b__53_6(U64Id uid) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC7C Offset: 0x57AC7C VA: 0x57AC7C
	// RVA: 0xB33EB0 Offset: 0xB33EB0 VA: 0xB33EB0
	private float <World_onBeforeSelfCharacterChange2AgonaledEvt>b__54_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC8C Offset: 0x57AC8C VA: 0x57AC8C
	// RVA: 0xB33FE0 Offset: 0xB33FE0 VA: 0xB33FE0
	private void <InitSkillBtns>b__148_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AC9C Offset: 0x57AC9C VA: 0x57AC9C
	// RVA: 0xB33FEC Offset: 0xB33FEC VA: 0xB33FEC
	private void <InitSkillBtns>b__148_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ACAC Offset: 0x57ACAC VA: 0x57ACAC
	// RVA: 0xB33FF8 Offset: 0xB33FF8 VA: 0xB33FF8
	private SkillButton <InnerInitSkillBtn>g__Create|151_0(RectTransform parent, ISkillCtrlrProxy getter) { }
}
