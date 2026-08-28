// Namespace: 
public class PreBattleEquipmentSettingView.PartUI // TypeDefIndex: 10466
{
	// Fields
	private RectTransform mRt; // 0x8
	private GameObject mContent; // 0xC
	private Text mName; // 0x10
	private GameObject mEquipedTextGo; // 0x14
	private GameObject mImgGo; // 0x18
	private ImageWrapper mImg; // 0x1C
	private GameObject mOutLineGo; // 0x20
	private GameObject mEquipedOutlineGo; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56E6F4 Offset: 0x56E6F4 VA: 0x56E6F4
	private uint <PartId>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56E704 Offset: 0x56E704 VA: 0x56E704
	private bool <IsEquiped>k__BackingField; // 0x2C
	public Action<PreBattleEquipmentSettingView.PartUI> OnPartClickEvt; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56E714 Offset: 0x56E714 VA: 0x56E714
	private AttachmentKind <Kind>k__BackingField; // 0x34
	private Animator mAnimator; // 0x38

	// Properties
	public uint PartId { get; set; }
	public bool IsEquiped { get; set; }
	public AttachmentKind Kind { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D910 Offset: 0x65D910 VA: 0x65D910
	// RVA: 0xC7F93C Offset: 0xC7F93C VA: 0xC7F93C
	private void set_PartId(uint value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D920 Offset: 0x65D920 VA: 0x65D920
	// RVA: 0xC7E9C4 Offset: 0xC7E9C4 VA: 0xC7E9C4
	public uint get_PartId() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D930 Offset: 0x65D930 VA: 0x65D930
	// RVA: 0xC7F944 Offset: 0xC7F944 VA: 0xC7F944
	private void set_IsEquiped(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D940 Offset: 0x65D940 VA: 0x65D940
	// RVA: 0xC7F94C Offset: 0xC7F94C VA: 0xC7F94C
	public bool get_IsEquiped() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D950 Offset: 0x65D950 VA: 0x65D950
	// RVA: 0xC7F954 Offset: 0xC7F954 VA: 0xC7F954
	private void set_Kind(AttachmentKind value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D960 Offset: 0x65D960 VA: 0x65D960
	// RVA: 0xC7F95C Offset: 0xC7F95C VA: 0xC7F95C
	public AttachmentKind get_Kind() { }

	// RVA: 0xC7E538 Offset: 0xC7E538 VA: 0xC7E538
	public void .ctor(RectTransform rt) { }

	// RVA: 0xC7F964 Offset: 0xC7F964 VA: 0xC7F964
	private void AddListeners() { }

	// RVA: 0xC7E7A4 Offset: 0xC7E7A4 VA: 0xC7E7A4
	public void Active(bool active) { }

	// RVA: 0xC7F1AC Offset: 0xC7F1AC VA: 0xC7F1AC
	public void FillData(uint partId, AttachmentKind kind) { }

	// RVA: 0xC7F1B8 Offset: 0xC7F1B8 VA: 0xC7F1B8
	public void Refresh(bool fromSelectedWindow = False) { }

	// RVA: 0xC7E9CC Offset: 0xC7E9CC VA: 0xC7E9CC
	public void SetSelected(bool selected) { }

	// RVA: 0xC7FA28 Offset: 0xC7FA28 VA: 0xC7FA28
	public void SetEquipd(bool equiped) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D970 Offset: 0x65D970 VA: 0x65D970
	// RVA: 0xC7FABC Offset: 0xC7FABC VA: 0xC7FABC
	private void <AddListeners>b__23_0(PointerEventData x) { }
}
