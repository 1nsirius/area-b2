// Namespace: 
public class UIBattleObserverControl : BaseView // TypeDefIndex: 5786
{
	// Fields
	private F2NormalButton mNextBtn; // 0x30
	private F2NormalButton mPreviousBtn; // 0x34
	private F2NormalButton mScoutBtn; // 0x38
	private UIBattleObserverControl.CircleFlag[] mFlags; // 0x3C
	private Text mCharacterName; // 0x40
	private IBattleObserverHelper mObserverHelper; // 0x44
	private UIBattleObserverControl.CircleFlag mCurFlag; // 0x48
	private HPComponent0 mNewHpComp; // 0x4C
	private SimpleBloodPanel mExtraHpComp; // 0x50
	private Text mPlaceText; // 0x54
	private PlayerFightInfoModel mPlayerFightInfoModel; // 0x58
	private PlayerFightInfoUI mPlayerInfoUI; // 0x5C
	private uint mCurNowCameraSoundBoxId; // 0x60
	private GameObject mSnowFlakeEffectGo; // 0x64
	private float mBroadCastObserverControlOpenDelayTimer; // 0x68

	// Methods

	// RVA: 0xADCA18 Offset: 0xADCA18 VA: 0xADCA18
	public void .ctor() { }

	// RVA: 0xADCA98 Offset: 0xADCA98 VA: 0xADCA98 Slot: 19
	public override void InitViews() { }

	// RVA: 0xADD360 Offset: 0xADD360 VA: 0xADD360 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xADD4E4 Offset: 0xADD4E4 VA: 0xADD4E4 Slot: 21
	public override void Init() { }

	// RVA: 0xADD684 Offset: 0xADD684 VA: 0xADD684
	private void ShowSnowFlakeEffect(bool show) { }

	// RVA: 0xADD740 Offset: 0xADD740 VA: 0xADD740
	private void OnBtnScoutClick() { }

	// RVA: 0xADDA0C Offset: 0xADDA0C VA: 0xADDA0C
	private void _observerHelper_OnObserverStateChangedEvt(IObserverStateChangeEvt evt) { }

	// RVA: 0xADDFA8 Offset: 0xADDFA8 VA: 0xADDFA8
	private Vector3 GetObservedCharacterPos() { }

	// RVA: 0xADE108 Offset: 0xADE108 VA: 0xADE108 Slot: 23
	public override void OnViewOpen(object[] objs) { }

	// RVA: 0xADF0F4 Offset: 0xADF0F4 VA: 0xADF0F4 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xADE234 Offset: 0xADE234 VA: 0xADE234
	private void SetSwitchPanelInfo() { }

	// RVA: 0xADE928 Offset: 0xADE928 VA: 0xADE928
	private void RefreshPlayerFightInfo() { }

	// RVA: 0xADEB48 Offset: 0xADEB48 VA: 0xADEB48
	private void UpdateSwitchPanel() { }

	// RVA: 0xADE5F4 Offset: 0xADE5F4 VA: 0xADE5F4
	private void RefreshHpUI() { }

	// RVA: 0xADF564 Offset: 0xADF564 VA: 0xADF564
	private void RefreshPlayerFightInfoUI() { }

	// RVA: 0xADEFE4 Offset: 0xADEFE4 VA: 0xADEFE4
	private void UpdateOthers() { }

	// RVA: 0xADF578 Offset: 0xADF578 VA: 0xADF578 Slot: 24
	public override void OnTick() { }

	// RVA: 0xADF9E4 Offset: 0xADF9E4 VA: 0xADF9E4 Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD3C Offset: 0x57AD3C VA: 0x57AD3C
	// RVA: 0xADFC34 Offset: 0xADFC34 VA: 0xADFC34
	private void <AddListeners>b__18_0(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD4C Offset: 0x57AD4C VA: 0x57AD4C
	// RVA: 0xADFD0C Offset: 0xADFD0C VA: 0xADFD0C
	private void <AddListeners>b__18_1(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD5C Offset: 0x57AD5C VA: 0x57AD5C
	// RVA: 0xADFDE4 Offset: 0xADFDE4 VA: 0xADFDE4
	private void <AddListeners>b__18_2(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AD6C Offset: 0x57AD6C VA: 0x57AD6C
	// RVA: 0xADFDE8 Offset: 0xADFDE8 VA: 0xADFDE8
	private int <SetSwitchPanelInfo>b__27_0(ICampPlayerInfo x, ICampPlayerInfo y) { }
}
