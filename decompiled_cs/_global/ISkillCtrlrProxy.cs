// Namespace: 
public interface ISkillCtrlrProxy : IDisposable // TypeDefIndex: 5728
{
	// Properties
	public abstract SkillIndex SkillIndex { get; }
	public abstract bool Visible { get; }
	public abstract int ButtonId { get; }
	public abstract Count Num { get; }
	[TupleElementNamesAttribute] // RVA: 0x66DB30 Offset: 0x66DB30 VA: 0x66DB30
	[IsReadOnlyAttribute] // RVA: 0x66DB30 Offset: 0x66DB30 VA: 0x66DB30
	public abstract ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66DBE0 Offset: 0x66DBE0 VA: 0x66DBE0
	[IsReadOnlyAttribute] // RVA: 0x66DBE0 Offset: 0x66DBE0 VA: 0x66DBE0
	public abstract ValueTuple<float, float> ActiveTimeRange { get; }
	public abstract string Text { get; }
	public abstract int TextId { get; }
	public abstract Sprite Icon { get; }
	public abstract ESkillBtnState State { get; }
	public abstract bool IfShowNum { get; }
	public abstract bool ShouldShowCd { get; }
	public abstract bool ShouldShowEnergy { get; }
	public abstract string AttachPrefab { get; }
	public abstract bool Dragable { get; }
	public abstract bool IsActiveDrag { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 0
	public abstract SkillIndex get_SkillIndex();

	// RVA: -1 Offset: -1 Slot: 1
	public abstract void OnTick();

	// RVA: -1 Offset: -1 Slot: 2
	public abstract bool get_Visible();

	// RVA: -1 Offset: -1 Slot: 3
	public abstract int get_ButtonId();

	// RVA: -1 Offset: -1 Slot: 4
	public abstract Count get_Num();

	// RVA: -1 Offset: -1 Slot: 5
	public abstract ref ValueTuple<float, float> get_CdTimeRange();

	// RVA: -1 Offset: -1 Slot: 6
	public abstract ref ValueTuple<float, float> get_ActiveTimeRange();

	// RVA: -1 Offset: -1 Slot: 7
	public abstract string get_Text();

	// RVA: -1 Offset: -1 Slot: 8
	public abstract int get_TextId();

	// RVA: -1 Offset: -1 Slot: 9
	public abstract Sprite get_Icon();

	// RVA: -1 Offset: -1 Slot: 10
	public abstract ESkillBtnState get_State();

	// RVA: -1 Offset: -1 Slot: 11
	public abstract bool get_IfShowNum();

	// RVA: -1 Offset: -1 Slot: 12
	public abstract bool get_ShouldShowCd();

	// RVA: -1 Offset: -1 Slot: 13
	public abstract bool get_ShouldShowEnergy();

	// RVA: -1 Offset: -1 Slot: 14
	public abstract string get_AttachPrefab();

	// RVA: -1 Offset: -1 Slot: 15
	public abstract bool get_Dragable();

	// RVA: -1 Offset: -1 Slot: 16
	public abstract bool get_IsActiveDrag();

	// RVA: -1 Offset: -1 Slot: 17
	public abstract void OnClick();

	// RVA: -1 Offset: -1 Slot: 18
	public abstract void OnPressDown();

	// RVA: -1 Offset: -1 Slot: 19
	public abstract void OnPressUp();
}
