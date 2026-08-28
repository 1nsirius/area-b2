// Namespace: 
public class SkillButton : IDisposable // TypeDefIndex: 5729
{
	// Fields
	private ISkillCtrlrProxy mProxy; // 0x8
	private RectTransform mRootTrans; // 0xC
	private Text mNumText; // 0x10
	private LanguageMono mNameText; // 0x14
	private Image mBackImage; // 0x18
	private RectTransform mImgIconBg; // 0x1C
	private Image mIcon; // 0x20
	private Image mEnergyImg; // 0x24
	private Image mCdImg; // 0x28
	private MaskableGraphic mOutline; // 0x2C
	private CanvasGroup mRootGroup; // 0x30
	private Image mDragBg; // 0x34
	private UIEventListener mEventListener; // 0x38
	private GameObject mAttachGo; // 0x3C
	private Nullable<ESkillBtnState> mState; // 0x40
	private Vector2 mDelta; // 0x48
	private bool mEnable; // 0x50
	private readonly AssetPool mAssetPool; // 0x54
	private Nullable<Count> mLastNum; // 0x58
	private int mLastIndex; // 0x64

	// Properties
	public bool Enable { get; set; }
	private BattleConfiguration.SkillBtnColors BtnColors { get; }

	// Methods

	// RVA: 0xF7AE28 Offset: 0xF7AE28 VA: 0xF7AE28
	public bool get_Enable() { }

	// RVA: 0xF7AE30 Offset: 0xF7AE30 VA: 0xF7AE30
	public void set_Enable(bool value) { }

	// RVA: 0xF7AF70 Offset: 0xF7AF70 VA: 0xF7AF70 Slot: 5
	public virtual void Init(RectTransform trans, ISkillCtrlrProxy getter, Func<RectTransform, ISkillCtrlrProxy, SkillButton> factory, GameObject dragPanel) { }

	// RVA: 0xF7B798 Offset: 0xF7B798 VA: 0xF7B798 Slot: 6
	public virtual void OnTick() { }

	// RVA: 0xF7B5F8 Offset: 0xF7B5F8 VA: 0xF7B5F8
	private void TryRefresh(bool focus) { }

	// RVA: 0xF7BC18 Offset: 0xF7BC18 VA: 0xF7BC18
	private void Refresh(bool force) { }

	// RVA: 0xF7C2F0 Offset: 0xF7C2F0 VA: 0xF7C2F0
	private void ResetAttachTip() { }

	// RVA: 0xF7C814 Offset: 0xF7C814 VA: 0xF7C814
	private void AttachTip() { }

	// RVA: 0xF7C700 Offset: 0xF7C700 VA: 0xF7C700
	private void StartBlink() { }

	// RVA: 0xF7C228 Offset: 0xF7C228 VA: 0xF7C228
	private void ResetBlink() { }

	// RVA: 0xF7AF60 Offset: 0xF7AF60 VA: 0xF7AF60
	private void Hide() { }

	// RVA: 0xF7AF50 Offset: 0xF7AF50 VA: 0xF7AF50
	private void Show() { }

	// RVA: 0xF7D880 Offset: 0xF7D880 VA: 0xF7D880
	private BattleConfiguration.SkillBtnColors get_BtnColors() { }

	// RVA: 0xF7C3BC Offset: 0xF7C3BC VA: 0xF7C3BC
	private void RefreshStatic(int textId, Sprite icon, bool showNum) { }

	// RVA: 0xF7CA9C Offset: 0xF7CA9C VA: 0xF7CA9C
	private void RefreshState(ESkillBtnState state) { }

	// RVA: 0xF7D8C0 Offset: 0xF7D8C0 VA: 0xF7D8C0
	private void SetIconBgEnable(bool en) { }

	// RVA: 0xF7CF90 Offset: 0xF7CF90 VA: 0xF7CF90
	private void RefreshNum(Count num) { }

	// RVA: 0xF7D21C Offset: 0xF7D21C VA: 0xF7D21C
	private void RefreshCd() { }

	// RVA: 0xF7D968 Offset: 0xF7D968 VA: 0xF7D968 Slot: 7
	public virtual void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0xF7DA40 Offset: 0xF7DA40 VA: 0xF7DA40 Slot: 8
	public virtual void OnPointerDown(PointerEventData eventData) { }

	// RVA: 0xF7DB18 Offset: 0xF7DB18 VA: 0xF7DB18 Slot: 9
	public virtual void OnPointerUp(PointerEventData eventData) { }

	// RVA: 0xF7DC3C Offset: 0xF7DC3C VA: 0xF7DC3C Slot: 10
	public virtual void HandleOnDrag(PointerEventData eveData) { }

	// RVA: 0xF7B95C Offset: 0xF7B95C VA: 0xF7B95C
	private Vector2 Clip(Vector2 v, float maxLen) { }

	// RVA: 0xF7BA4C Offset: 0xF7BA4C VA: 0xF7BA4C
	protected void SetDraggerPos(Vector3 pos) { }

	// RVA: 0xF7B50C Offset: 0xF7B50C VA: 0xF7B50C
	protected void SetDragBgEnable(bool enable) { }

	// RVA: 0xF7DD38 Offset: 0xF7DD38 VA: 0xF7DD38 Slot: 4
	public void Dispose() { }

	// RVA: 0xF7DE30 Offset: 0xF7DE30 VA: 0xF7DE30
	public void .ctor() { }
}
