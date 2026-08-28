// Namespace: 
public class UIBattleSurveillanceCamControl : BaseView // TypeDefIndex: 5804
{
	// Fields
	private F2NormalButton mScanBtn; // 0x30
	private F2NormalButton mBack2CharacterUIBtn; // 0x34
	private F2NormalButton mRightScanBtn; // 0x38
	private UIDragPanel _dragPanel; // 0x3C
	private GameObject _dragPanelGo; // 0x40
	private F2NormalButton mLeftSwitchBtn; // 0x44
	private F2NormalButton mRightSwitchBtn; // 0x48
	private Image _operatorImg; // 0x4C
	private Text _operatorNameText; // 0x50
	private Image _ownerImg; // 0x54
	private F2NormalButton mBtnCancel; // 0x58
	private Scrollbar mTriggerScrollBar; // 0x5C
	private GameObject mTriggerScrollBarGo; // 0x60
	private RectTransform mTriggerScrollBarRt; // 0x64
	private Text mTriggersText; // 0x68
	private GameObject mTriggersTextGo; // 0x6C
	private RectTransform mTriggersTextRt; // 0x70
	private GameObject mSnowFlakeEffectGo; // 0x74
	private const float CICLE_FLAG_WIDTH = 40;
	private readonly Dictionary<U64Id, UIBattleSurveillanceCamControl.CicleFlag> _flagDic; // 0x78
	private readonly List<UIBattleSurveillanceCamControl.CicleFlag> _flags; // 0x7C
	private readonly List<UIBattleSurveillanceCamControl.CicleFlag> _flagsCopy; // 0x80
	private bool _flagsIsDirty; // 0x84
	private U64Id _curLookedMiniCarId; // 0x88
	private UIBattleSurveillanceCamControl.CicleFlag _curCicleFlag; // 0x90
	private byte _curOperatorOfMiniCarId; // 0x94
	private RectTransform _cicleGoParent; // 0x98
	private GameObject _miniCarCicleCloneGo; // 0x9C
	private bool _isCurMiniCarDead; // 0xA0
	private Text placeText; // 0xA4
	private uint mCurNowCameraSoundBoxId; // 0xA8
	[CompilerGeneratedAttribute] // RVA: 0x55EBEC Offset: 0x55EBEC VA: 0x55EBEC
	private IBattleSurveillanceCamObserverHelper <MiniCarObserveHelper>k__BackingField; // 0xAC
	private float broadCastSurCamControlOpenDelayTimer; // 0xB0
	private int mUiState; // 0xB4

	// Properties
	public IBattleSurveillanceCamObserverHelper MiniCarObserveHelper { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57AD8C Offset: 0x57AD8C VA: 0x57AD8C
	// RVA: 0xAEC02C Offset: 0xAEC02C VA: 0xAEC02C
	private void set_MiniCarObserveHelper(IBattleSurveillanceCamObserverHelper value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD9C Offset: 0x57AD9C VA: 0x57AD9C
	// RVA: 0xAEC034 Offset: 0xAEC034 VA: 0xAEC034
	public IBattleSurveillanceCamObserverHelper get_MiniCarObserveHelper() { }

	// RVA: 0xAEC03C Offset: 0xAEC03C VA: 0xAEC03C
	public void .ctor() { }

	// RVA: 0xAEC19C Offset: 0xAEC19C VA: 0xAEC19C Slot: 19
	public override void InitViews() { }

	// RVA: 0xAEC8EC Offset: 0xAEC8EC VA: 0xAEC8EC Slot: 20
	public override void AddListeners() { }

	// RVA: 0xAECCC0 Offset: 0xAECCC0 VA: 0xAECCC0
	private void World_onnMiniCarOrCameraDeadEvt(int deadType, U64Id id) { }

	// RVA: 0xAECF5C Offset: 0xAECF5C VA: 0xAECF5C
	public void ShowSnowFlakeEffect(bool show = True) { }

	// RVA: 0xAED018 Offset: 0xAED018 VA: 0xAED018 Slot: 21
	public override void Init() { }

	// RVA: 0xAED42C Offset: 0xAED42C VA: 0xAED42C
	private void Instance_OnScanOperationDataRetEvt(RspMonitorScanEnemies obj) { }

	// RVA: 0xAED7EC Offset: 0xAED7EC VA: 0xAED7EC Slot: 24
	public override void OnTick() { }

	// RVA: 0xAEEAE0 Offset: 0xAEEAE0 VA: 0xAEEAE0
	private void UpdateMapLocationLabel() { }

	// RVA: 0xAEEDCC Offset: 0xAEEDCC VA: 0xAEEDCC
	private void UpdateJoystickInput() { }

	// RVA: 0xAEDD10 Offset: 0xAEDD10 VA: 0xAEDD10
	private void UpdateNormalUI() { }

	// RVA: 0xAEE31C Offset: 0xAEE31C VA: 0xAEE31C
	private void UpdateCarOperationUI() { }

	// RVA: 0xAEF1AC Offset: 0xAEF1AC VA: 0xAEF1AC
	private void UpdateFlagsCopy() { }

	// RVA: 0xAEE824 Offset: 0xAEE824 VA: 0xAEE824
	private void UpdateMiniCarSwitch() { }

	// RVA: 0xAEF738 Offset: 0xAEF738 VA: 0xAEF738
	private void RefreshCarOpUI() { }

	// RVA: 0xAEE9EC Offset: 0xAEE9EC VA: 0xAEE9EC
	private void HideSomeUI() { }

	// RVA: 0xAEF35C Offset: 0xAEF35C VA: 0xAEF35C
	private void BeforeCicleFlagChanged() { }

	// RVA: 0xAEF51C Offset: 0xAEF51C VA: 0xAEF51C
	private void AfterCicleFlagChanged() { }

	// RVA: 0xAEFE1C Offset: 0xAEFE1C VA: 0xAEFE1C
	private void MiniCarObserveHelper_OnUserFromMiniCarToCharacterControlEvt() { }

	// RVA: 0xAED0F0 Offset: 0xAED0F0 VA: 0xAED0F0
	private void InstantiateCicles() { }

	// RVA: 0xAEFE20 Offset: 0xAEFE20 VA: 0xAEFE20
	private void AddCicleFlag(ISurveillanceCamProxy proxy) { }

	// RVA: 0xAF051C Offset: 0xAF051C VA: 0xAF051C Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xAF0730 Offset: 0xAF0730 VA: 0xAF0730 Slot: 26
	public override void OnViewClose() { }

	// RVA: 0xAF08B4 Offset: 0xAF08B4 VA: 0xAF08B4
	private void __OnScanBtnBeClickedCallBackHandler() { }

	// RVA: 0xAF09C4 Offset: 0xAF09C4 VA: 0xAF09C4
	private void __OnCancleBtnBeClickedCallBackHandler() { }

	// RVA: 0xAF0A94 Offset: 0xAF0A94 VA: 0xAF0A94 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xAEDC38 Offset: 0xAEDC38 VA: 0xAEDC38
	private void UpdateNodes() { }

	// RVA: 0xAF0C50 Offset: 0xAF0C50 VA: 0xAF0C50
	private void OnUiStateChange() { }

	// RVA: 0xAF0E88 Offset: 0xAF0E88 VA: 0xAF0E88
	private bool ToBool(int v) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADAC Offset: 0x57ADAC VA: 0x57ADAC
	// RVA: 0xAF0E98 Offset: 0xAF0E98 VA: 0xAF0E98
	private void <AddListeners>b__39_0() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADBC Offset: 0x57ADBC VA: 0x57ADBC
	// RVA: 0xAF0ED8 Offset: 0xAF0ED8 VA: 0xAF0ED8
	private void <AddListeners>b__39_1() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADCC Offset: 0x57ADCC VA: 0x57ADCC
	// RVA: 0xAF0F18 Offset: 0xAF0F18 VA: 0xAF0F18
	private void <AddListeners>b__39_2(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADDC Offset: 0x57ADDC VA: 0x57ADDC
	// RVA: 0xAF0FF0 Offset: 0xAF0FF0 VA: 0xAF0FF0
	private void <AddListeners>b__39_3(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADEC Offset: 0x57ADEC VA: 0x57ADEC
	// RVA: 0xAF10C8 Offset: 0xAF10C8 VA: 0xAF10C8
	private void <AddListeners>b__39_4(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ADFC Offset: 0x57ADFC VA: 0x57ADFC
	// RVA: 0xAF11A0 Offset: 0xAF11A0 VA: 0xAF11A0
	private void <AddListeners>b__39_5(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE0C Offset: 0x57AE0C VA: 0x57AE0C
	// RVA: 0xAF11A4 Offset: 0xAF11A4 VA: 0xAF11A4
	private void <Instance_OnScanOperationDataRetEvt>b__43_0(GameObject go) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE1C Offset: 0x57AE1C VA: 0x57AE1C
	// RVA: 0xAF11B4 Offset: 0xAF11B4 VA: 0xAF11B4
	private void <__OnCancleBtnBeClickedCallBackHandler>b__62_0(GameObject go) { }
}
