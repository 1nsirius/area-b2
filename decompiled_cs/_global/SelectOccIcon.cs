// Namespace: 
public class SelectOccIcon : MonoBehaviour // TypeDefIndex: 5652
{
	// Fields
	private ImageWrapper mIcon; // 0xC
	private Image mSelectedByOtherFlag; // 0x10
	private Image mLock; // 0x14
	private Text mLockText; // 0x18
	private MaskableGraphic mOutLine; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x55E46C Offset: 0x55E46C VA: 0x55E46C
	private bool <Valid>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x55E47C Offset: 0x55E47C VA: 0x55E47C
	private int <UID>k__BackingField; // 0x24
	private bool mIsDefault; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x55E48C Offset: 0x55E48C VA: 0x55E48C
	private Action<int> OnClick; // 0x2C

	// Properties
	private bool Valid { get; set; }
	public int UID { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A8DC Offset: 0x57A8DC VA: 0x57A8DC
	// RVA: 0x2CF80A0 Offset: 0x2CF80A0 VA: 0x2CF80A0
	private bool get_Valid() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A8EC Offset: 0x57A8EC VA: 0x57A8EC
	// RVA: 0x2CF80A8 Offset: 0x2CF80A8 VA: 0x2CF80A8
	private void set_Valid(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A8FC Offset: 0x57A8FC VA: 0x57A8FC
	// RVA: 0x2CF80B0 Offset: 0x2CF80B0 VA: 0x2CF80B0
	public int get_UID() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A90C Offset: 0x57A90C VA: 0x57A90C
	// RVA: 0x2CF80B8 Offset: 0x2CF80B8 VA: 0x2CF80B8
	private void set_UID(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A91C Offset: 0x57A91C VA: 0x57A91C
	// RVA: 0x2CF80C0 Offset: 0x2CF80C0 VA: 0x2CF80C0
	public void add_OnClick(Action<int> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A92C Offset: 0x57A92C VA: 0x57A92C
	// RVA: 0x2CF81CC Offset: 0x2CF81CC VA: 0x2CF81CC
	public void remove_OnClick(Action<int> value) { }

	// RVA: 0x2CF82D8 Offset: 0x2CF82D8 VA: 0x2CF82D8
	public void Init(int uid, bool isDefault) { }

	// RVA: 0x2CF85EC Offset: 0x2CF85EC VA: 0x2CF85EC
	public void RefreshIcon(string spritePath) { }

	// RVA: 0x2CF86B8 Offset: 0x2CF86B8 VA: 0x2CF86B8 Slot: 4
	public virtual void SetState(bool isSelectByOther, bool isSelectBySelf, bool isLock, string lockTip = "") { }

	// RVA: 0x2CF8878 Offset: 0x2CF8878 VA: 0x2CF8878
	public void .ctor() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A93C Offset: 0x57A93C VA: 0x57A93C
	// RVA: 0x2CF8880 Offset: 0x2CF8880 VA: 0x2CF8880
	private void <Init>b__17_0(PointerEventData pData) { }
}
