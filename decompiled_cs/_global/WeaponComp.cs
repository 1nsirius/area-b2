// Namespace: 
public class WeaponComp // TypeDefIndex: 5677
{
	// Fields
	private Image mBackImage; // 0x8
	private Text mBulletCntTxt; // 0xC
	private Count mCapacity; // 0x10
	private ImageWrapper mCombIconMain; // 0x18
	private ImageWrapper mCombIconSelf; // 0x1C
	private Count mCrtCnt; // 0x20
	private bool mDirty; // 0x28
	private UIEventListener mEventListener; // 0x2C
	private CanvasGroup mGroup; // 0x30
	private ImageWrapper mIcon; // 0x34
	private Text mName; // 0x38
	private MaskableGraphic mOutline; // 0x3C
	private RectTransform mRoot; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x55E4CC Offset: 0x55E4CC VA: 0x55E4CC
	private bool <Visiable>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x55E4DC Offset: 0x55E4DC VA: 0x55E4DC
	private Action OnClickEvt; // 0x48

	// Properties
	public bool Visiable { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A9FC Offset: 0x57A9FC VA: 0x57A9FC
	// RVA: 0x12FE408 Offset: 0x12FE408 VA: 0x12FE408
	public bool get_Visiable() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA0C Offset: 0x57AA0C VA: 0x57AA0C
	// RVA: 0x12FE410 Offset: 0x12FE410 VA: 0x12FE410
	private void set_Visiable(bool value) { }

	// RVA: 0x12FE418 Offset: 0x12FE418 VA: 0x12FE418
	public void Init(Transform root, GameObject dragPanel) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA1C Offset: 0x57AA1C VA: 0x57AA1C
	// RVA: 0x12FE794 Offset: 0x12FE794 VA: 0x12FE794
	public void add_OnClickEvt(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA2C Offset: 0x57AA2C VA: 0x57AA2C
	// RVA: 0x12FE8A0 Offset: 0x12FE8A0 VA: 0x12FE8A0
	public void remove_OnClickEvt(Action value) { }

	// RVA: 0x12FE9AC Offset: 0x12FE9AC VA: 0x12FE9AC
	public void OnTick() { }

	// RVA: 0x12FEAA8 Offset: 0x12FEAA8 VA: 0x12FEAA8
	public void Refresh(string name, string self, string main, bool isComb) { }

	// RVA: 0x12FEC3C Offset: 0x12FEC3C VA: 0x12FEC3C
	public void RefreshCapacity(Count capacity) { }

	// RVA: 0x12FEC8C Offset: 0x12FEC8C VA: 0x12FEC8C
	public void RefreshCrtCnt(Count crtCnt) { }

	// RVA: 0x12FECDC Offset: 0x12FECDC VA: 0x12FECDC
	public void SetAsDisable() { }

	// RVA: 0x12FEF20 Offset: 0x12FEF20 VA: 0x12FEF20
	public void SetAsHighLit() { }

	// RVA: 0x12FF150 Offset: 0x12FF150 VA: 0x12FF150
	public void SetAsNormal() { }

	// RVA: 0x12FF380 Offset: 0x12FF380 VA: 0x12FF380
	public void SetBulletCntVisiable(bool visiable) { }

	// RVA: 0x12FF3E4 Offset: 0x12FF3E4 VA: 0x12FF3E4
	public void SetVisiable(bool visiable) { }

	// RVA: 0x12FE748 Offset: 0x12FE748 VA: 0x12FE748
	private void SetCompVisiable(bool visiable) { }

	// RVA: 0x12FF400 Offset: 0x12FF400 VA: 0x12FF400
	private static void SetImageEnable(Image image, bool enable) { }

	// RVA: 0x12FF45C Offset: 0x12FF45C VA: 0x12FF45C
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA3C Offset: 0x57AA3C VA: 0x57AA3C
	// RVA: 0x12FF464 Offset: 0x12FF464 VA: 0x12FF464
	private void <Init>b__17_0(PointerEventData evt) { }
}
