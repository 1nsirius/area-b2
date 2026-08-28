// Namespace: 
public class SkillCtrlProxy : ISkillCtrlrProxy, IDisposable // TypeDefIndex: 5731
{
	// Fields
	private int mLastBtnId; // 0x8
	private skill_button_table.Record mRecord; // 0xC
	private ISkillController mSkillCtrl; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55EAA0 Offset: 0x55EAA0 VA: 0x55EAA0
	private readonly SkillIndex <SkillIndex>k__BackingField; // 0x14
	private int mButtonId; // 0x18
	private AssetPool mAssetPool; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x55EAB0 Offset: 0x55EAB0 VA: 0x55EAB0
	private Action OnSkillCtrlrChange; // 0x20

	// Properties
	public SkillIndex SkillIndex { get; }
	public bool Visible { get; }
	public int ButtonId { get; set; }
	public Count Num { get; }
	[TupleElementNamesAttribute] // RVA: 0x66DC90 Offset: 0x66DC90 VA: 0x66DC90
	[IsReadOnlyAttribute] // RVA: 0x66DC90 Offset: 0x66DC90 VA: 0x66DC90
	public ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66DD40 Offset: 0x66DD40 VA: 0x66DD40
	[IsReadOnlyAttribute] // RVA: 0x66DD40 Offset: 0x66DD40 VA: 0x66DD40
	public ValueTuple<float, float> ActiveTimeRange { get; }
	public string Text { get; }
	public int TextId { get; }
	public Sprite Icon { get; }
	public ESkillBtnState State { get; }
	public bool IfShowNum { get; }
	public bool ShouldShowCd { get; }
	public bool ShouldShowEnergy { get; }
	public string AttachPrefab { get; }
	public bool Dragable { get; }
	public bool IsActiveDrag { get; }

	// Methods

	// RVA: 0xF7DEBC Offset: 0xF7DEBC VA: 0xF7DEBC
	public void ResetSkillCtrlProxy(ISkillController skillCtrl) { }

	// RVA: 0xF7E174 Offset: 0xF7E174 VA: 0xF7E174 Slot: 5
	public void OnTick() { }

	// RVA: 0xF7E178 Offset: 0xF7E178 VA: 0xF7E178
	private void UpdateVisible() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABAC Offset: 0x57ABAC VA: 0x57ABAC
	// RVA: 0xF7E428 Offset: 0xF7E428 VA: 0xF7E428 Slot: 4
	public SkillIndex get_SkillIndex() { }

	// RVA: 0xF7E430 Offset: 0xF7E430 VA: 0xF7E430 Slot: 6
	public bool get_Visible() { }

	// RVA: 0xF7E690 Offset: 0xF7E690 VA: 0xF7E690 Slot: 7
	public int get_ButtonId() { }

	// RVA: 0xF7E2F0 Offset: 0xF7E2F0 VA: 0xF7E2F0
	private void set_ButtonId(int value) { }

	// RVA: 0xF7E698 Offset: 0xF7E698 VA: 0xF7E698 Slot: 8
	public Count get_Num() { }

	// RVA: 0xF7E784 Offset: 0xF7E784 VA: 0xF7E784 Slot: 9
	public ref ValueTuple<float, float> get_CdTimeRange() { }

	// RVA: 0xF7E85C Offset: 0xF7E85C VA: 0xF7E85C Slot: 10
	public ref ValueTuple<float, float> get_ActiveTimeRange() { }

	// RVA: 0xF7E934 Offset: 0xF7E934 VA: 0xF7E934 Slot: 11
	public string get_Text() { }

	// RVA: 0xF7E94C Offset: 0xF7E94C VA: 0xF7E94C Slot: 12
	public int get_TextId() { }

	// RVA: 0xF7E964 Offset: 0xF7E964 VA: 0xF7E964 Slot: 13
	public Sprite get_Icon() { }

	// RVA: 0xF7EA18 Offset: 0xF7EA18 VA: 0xF7EA18
	public void .ctor(SkillIndex skillIndex) { }

	// RVA: 0xF7E5C0 Offset: 0xF7E5C0 VA: 0xF7E5C0 Slot: 14
	public ESkillBtnState get_State() { }

	// RVA: 0xF7EAA4 Offset: 0xF7EAA4 VA: 0xF7EAA4 Slot: 15
	public bool get_IfShowNum() { }

	// RVA: 0xF7EAD0 Offset: 0xF7EAD0 VA: 0xF7EAD0 Slot: 16
	public bool get_ShouldShowCd() { }

	// RVA: 0xF7EB00 Offset: 0xF7EB00 VA: 0xF7EB00 Slot: 17
	public bool get_ShouldShowEnergy() { }

	// RVA: 0xF7EB30 Offset: 0xF7EB30 VA: 0xF7EB30 Slot: 18
	public string get_AttachPrefab() { }

	// RVA: 0xF7EB48 Offset: 0xF7EB48 VA: 0xF7EB48 Slot: 19
	public bool get_Dragable() { }

	// RVA: 0xF7EBB4 Offset: 0xF7EBB4 VA: 0xF7EBB4 Slot: 20
	public bool get_IsActiveDrag() { }

	// RVA: 0xF7ECA4 Offset: 0xF7ECA4 VA: 0xF7ECA4 Slot: 21
	public void OnClick() { }

	// RVA: 0xF7ED74 Offset: 0xF7ED74 VA: 0xF7ED74 Slot: 22
	public void OnPressDown() { }

	// RVA: 0xF7EE44 Offset: 0xF7EE44 VA: 0xF7EE44 Slot: 23
	public void OnPressUp() { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABBC Offset: 0x57ABBC VA: 0x57ABBC
	// RVA: 0xF7EF14 Offset: 0xF7EF14 VA: 0xF7EF14
	public void add_OnSkillCtrlrChange(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57ABCC Offset: 0x57ABCC VA: 0x57ABCC
	// RVA: 0xF7F020 Offset: 0xF7F020 VA: 0xF7F020
	public void remove_OnSkillCtrlrChange(Action value) { }

	// RVA: 0xF7E138 Offset: 0xF7E138 VA: 0xF7E138
	private skill_button_table.Record GetRecordByButtonId(int id) { }

	// RVA: 0xF7F12C Offset: 0xF7F12C VA: 0xF7F12C Slot: 24
	public void Dispose() { }
}
