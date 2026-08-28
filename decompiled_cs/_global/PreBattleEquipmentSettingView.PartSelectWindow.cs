// Namespace: 
public class PreBattleEquipmentSettingView.PartSelectWindow // TypeDefIndex: 10469
{
	// Fields
	private GameObject mContent; // 0x8
	private RectTransform mRt; // 0xC
	private Text mDesc; // 0x10
	private Text mDescInfo; // 0x14
	private RectTransform mContentViewRt; // 0x18
	private readonly List<PreBattleEquipmentSettingView.PartUI> mOptionalWeaponList; // 0x1C
	private uint mCurSelectedPartId; // 0x20
	private int[] mOptionalPartIdList; // 0x24
	private AttachmentKind mKind; // 0x28
	private Action<uint, AttachmentKind> mOnEquipSelectedConfimEvt; // 0x2C
	private Animator mAnimator; // 0x30

	// Methods

	// RVA: 0xC7DF20 Offset: 0xC7DF20 VA: 0xC7DF20
	public void .ctor(RectTransform rt) { }

	// RVA: 0xC7E7FC Offset: 0xC7E7FC VA: 0xC7E7FC
	private void OnPartUISelected(PreBattleEquipmentSettingView.PartUI partUI) { }

	// RVA: 0xC7EB64 Offset: 0xC7EB64 VA: 0xC7EB64
	public void Open(uint selectedPartId, AttachmentKind kind, int[] optionalPartIdList, Action<uint, AttachmentKind> onEquipSelectedConfimEvt) { }

	// RVA: 0xC7F0FC Offset: 0xC7F0FC VA: 0xC7F0FC
	public void ShowAnimaiton(bool show) { }

	// RVA: 0xC7EB7C Offset: 0xC7EB7C VA: 0xC7EB7C
	private void Refresh() { }

	// RVA: 0xC7EA00 Offset: 0xC7EA00 VA: 0xC7EA00
	private void SetSelectedPartDescInfo(uint partId) { }

	// RVA: 0xC7F81C Offset: 0xC7F81C VA: 0xC7F81C
	public void Close() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D980 Offset: 0x65D980 VA: 0x65D980
	// RVA: 0xC7F8B4 Offset: 0xC7F8B4 VA: 0xC7F8B4
	private void <.ctor>b__11_0(PointerEventData x) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D990 Offset: 0x65D990 VA: 0x65D990
	// RVA: 0xC7F934 Offset: 0xC7F934 VA: 0xC7F934
	private void <.ctor>b__11_1(PointerEventData x) { }
}
