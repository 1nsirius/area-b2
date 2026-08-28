// Namespace: 
public class FireHandler : ISkillCtrlrProxy, IDisposable // TypeDefIndex: 5727
{
	// Fields
	[TupleElementNamesAttribute] // RVA: 0x55E9B0 Offset: 0x55E9B0 VA: 0x55E9B0
	private static readonly ValueTuple<float, float> mDefaultTimeRange; // 0x0
	private AssetPool mAssetPool; // 0x8
	private int mButtonId; // 0xC
	private skill_button_table.Record mRecord; // 0x10
	private ESkillBtnState mState; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x55EA50 Offset: 0x55EA50 VA: 0x55EA50
	private readonly int <TextId>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x55EA60 Offset: 0x55EA60 VA: 0x55EA60
	private Sprite <Icon>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x55EA70 Offset: 0x55EA70 VA: 0x55EA70
	private Action OnClickEve; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x55EA80 Offset: 0x55EA80 VA: 0x55EA80
	private Action OnPressDownEve; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x55EA90 Offset: 0x55EA90 VA: 0x55EA90
	private Action OnPressUpEve; // 0x28

	// Properties
	public string AttachPrefab { get; }
	public bool Dragable { get; }
	public bool ShouldShowCd { get; }
	public bool ShouldShowEnergy { get; }
	public bool IfShowNum { get; }
	public bool IsActiveDrag { get; }
	public Count Num { get; }
	[TupleElementNamesAttribute] // RVA: 0x66D9D0 Offset: 0x66D9D0 VA: 0x66D9D0
	[IsReadOnlyAttribute] // RVA: 0x66D9D0 Offset: 0x66D9D0 VA: 0x66D9D0
	public ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66DA80 Offset: 0x66DA80 VA: 0x66DA80
	[IsReadOnlyAttribute] // RVA: 0x66DA80 Offset: 0x66DA80 VA: 0x66DA80
	public ValueTuple<float, float> ActiveTimeRange { get; }
	public ESkillBtnState State { get; set; }
	public string Text { get; }
	public int TextId { get; }
	public bool Visible { get; }
	public int ButtonId { get; set; }
	public Sprite Icon { get; set; }
	public SkillIndex SkillIndex { get; }

	// Methods

	// RVA: 0xF9EF5C Offset: 0xF9EF5C VA: 0xF9EF5C
	public void .ctor(int btnId) { }

	// RVA: 0xF9F2C0 Offset: 0xF9F2C0 VA: 0xF9F2C0 Slot: 18
	public string get_AttachPrefab() { }

	// RVA: 0xF9F324 Offset: 0xF9F324 VA: 0xF9F324 Slot: 19
	public bool get_Dragable() { }

	// RVA: 0xF9F32C Offset: 0xF9F32C VA: 0xF9F32C Slot: 16
	public bool get_ShouldShowCd() { }

	// RVA: 0xF9F334 Offset: 0xF9F334 VA: 0xF9F334 Slot: 17
	public bool get_ShouldShowEnergy() { }

	// RVA: 0xF9F33C Offset: 0xF9F33C VA: 0xF9F33C Slot: 15
	public bool get_IfShowNum() { }

	// RVA: 0xF9F344 Offset: 0xF9F344 VA: 0xF9F344 Slot: 20
	public bool get_IsActiveDrag() { }

	// RVA: 0xF9F34C Offset: 0xF9F34C VA: 0xF9F34C Slot: 8
	public Count get_Num() { }

	// RVA: 0xF9F364 Offset: 0xF9F364 VA: 0xF9F364 Slot: 9
	public ref ValueTuple<float, float> get_CdTimeRange() { }

	// RVA: 0xF9F3EC Offset: 0xF9F3EC VA: 0xF9F3EC Slot: 10
	public ref ValueTuple<float, float> get_ActiveTimeRange() { }

	// RVA: 0xF9F474 Offset: 0xF9F474 VA: 0xF9F474 Slot: 14
	public ESkillBtnState get_State() { }

	// RVA: 0xF9F47C Offset: 0xF9F47C VA: 0xF9F47C
	public void set_State(ESkillBtnState value) { }

	// RVA: 0xF9F484 Offset: 0xF9F484 VA: 0xF9F484 Slot: 11
	public string get_Text() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB1C Offset: 0x57AB1C VA: 0x57AB1C
	// RVA: 0xF9F4E8 Offset: 0xF9F4E8 VA: 0xF9F4E8 Slot: 12
	public int get_TextId() { }

	// RVA: 0xF9F4F0 Offset: 0xF9F4F0 VA: 0xF9F4F0 Slot: 6
	public bool get_Visible() { }

	// RVA: 0xF9F500 Offset: 0xF9F500 VA: 0xF9F500 Slot: 7
	public int get_ButtonId() { }

	// RVA: 0xF9F11C Offset: 0xF9F11C VA: 0xF9F11C
	public void set_ButtonId(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB2C Offset: 0x57AB2C VA: 0x57AB2C
	// RVA: 0xF9F508 Offset: 0xF9F508 VA: 0xF9F508 Slot: 13
	public Sprite get_Icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB3C Offset: 0x57AB3C VA: 0x57AB3C
	// RVA: 0xF9F2B8 Offset: 0xF9F2B8 VA: 0xF9F2B8
	private void set_Icon(Sprite value) { }

	// RVA: 0xF9F510 Offset: 0xF9F510 VA: 0xF9F510 Slot: 24
	public void Dispose() { }

	// RVA: 0xF9F554 Offset: 0xF9F554 VA: 0xF9F554 Slot: 21
	public void OnClick() { }

	// RVA: 0xF9F568 Offset: 0xF9F568 VA: 0xF9F568 Slot: 22
	public void OnPressDown() { }

	// RVA: 0xF9F588 Offset: 0xF9F588 VA: 0xF9F588 Slot: 23
	public void OnPressUp() { }

	// RVA: 0xF9F5A8 Offset: 0xF9F5A8 VA: 0xF9F5A8 Slot: 4
	public SkillIndex get_SkillIndex() { }

	// RVA: 0xF9F5B0 Offset: 0xF9F5B0 VA: 0xF9F5B0 Slot: 5
	public void OnTick() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB4C Offset: 0x57AB4C VA: 0x57AB4C
	// RVA: 0xF9F5B4 Offset: 0xF9F5B4 VA: 0xF9F5B4
	public void add_OnClickEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB5C Offset: 0x57AB5C VA: 0x57AB5C
	// RVA: 0xF9F6C0 Offset: 0xF9F6C0 VA: 0xF9F6C0
	public void remove_OnClickEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB6C Offset: 0x57AB6C VA: 0x57AB6C
	// RVA: 0xF9F7CC Offset: 0xF9F7CC VA: 0xF9F7CC
	public void add_OnPressDownEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB7C Offset: 0x57AB7C VA: 0x57AB7C
	// RVA: 0xF9F8D8 Offset: 0xF9F8D8 VA: 0xF9F8D8
	public void remove_OnPressDownEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB8C Offset: 0x57AB8C VA: 0x57AB8C
	// RVA: 0xF9F9E4 Offset: 0xF9F9E4 VA: 0xF9F9E4
	public void add_OnPressUpEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AB9C Offset: 0x57AB9C VA: 0x57AB9C
	// RVA: 0xF9FAF0 Offset: 0xF9FAF0 VA: 0xF9FAF0
	public void remove_OnPressUpEve(Action value) { }

	// RVA: 0xF9FBFC Offset: 0xF9FBFC VA: 0xF9FBFC
	private static void .cctor() { }
}
