// Namespace: 
public class MainCharacterController.CommonSkillController : ISkillController // TypeDefIndex: 12595
{
	// Fields
	[TupleElementNamesAttribute] // RVA: 0x57913C Offset: 0x57913C VA: 0x57913C
	private static readonly ValueTuple<float, float> mDefaultTimeRange; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x5791DC Offset: 0x5791DC VA: 0x5791DC
	private Action OnClickEve; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5791EC Offset: 0x5791EC VA: 0x5791EC
	private Action OnPressDownEve; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5791FC Offset: 0x5791FC VA: 0x5791FC
	private Action OnPressUpEve; // 0x10
	private readonly Func<bool> mIsVisible; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x57920C Offset: 0x57920C VA: 0x57920C
	private Func<Count> GetNum; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x57921C Offset: 0x57921C VA: 0x57921C
	private int <ButtonId>k__BackingField; // 0x1C
	private ButtonPriority mPriority; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x57922C Offset: 0x57922C VA: 0x57922C
	private bool <IsActive>k__BackingField; // 0x28

	// Properties
	public bool Visible { get; }
	public int ButtonId { get; set; }
	public Count Num { get; }
	public ButtonPriority Priority { get; set; }
	[TupleElementNamesAttribute] // RVA: 0x66F0DC Offset: 0x66F0DC VA: 0x66F0DC
	[IsReadOnlyAttribute] // RVA: 0x66F0DC Offset: 0x66F0DC VA: 0x66F0DC
	public ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66F18C Offset: 0x66F18C VA: 0x66F18C
	[IsReadOnlyAttribute] // RVA: 0x66F18C Offset: 0x66F18C VA: 0x66F18C
	public ValueTuple<float, float> ActiveTimeRange { get; }
	public bool IsActive { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667E70 Offset: 0x667E70 VA: 0x667E70
	// RVA: 0xAB4D94 Offset: 0xAB4D94 VA: 0xAB4D94
	private void add_OnClickEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667E80 Offset: 0x667E80 VA: 0x667E80
	// RVA: 0xAB4EA0 Offset: 0xAB4EA0 VA: 0xAB4EA0
	private void remove_OnClickEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667E90 Offset: 0x667E90 VA: 0x667E90
	// RVA: 0xAB4FAC Offset: 0xAB4FAC VA: 0xAB4FAC
	private void add_OnPressDownEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667EA0 Offset: 0x667EA0 VA: 0x667EA0
	// RVA: 0xAB50B8 Offset: 0xAB50B8 VA: 0xAB50B8
	private void remove_OnPressDownEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667EB0 Offset: 0x667EB0 VA: 0x667EB0
	// RVA: 0xAB51C4 Offset: 0xAB51C4 VA: 0xAB51C4
	private void add_OnPressUpEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667EC0 Offset: 0x667EC0 VA: 0x667EC0
	// RVA: 0xAB52D0 Offset: 0xAB52D0 VA: 0xAB52D0
	private void remove_OnPressUpEve(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667ED0 Offset: 0x667ED0 VA: 0x667ED0
	// RVA: 0xAB53DC Offset: 0xAB53DC VA: 0xAB53DC
	private void add_GetNum(Func<Count> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667EE0 Offset: 0x667EE0 VA: 0x667EE0
	// RVA: 0xAB54E8 Offset: 0xAB54E8 VA: 0xAB54E8
	private void remove_GetNum(Func<Count> value) { }

	// RVA: 0xAB55F4 Offset: 0xAB55F4 VA: 0xAB55F4
	public void .ctor(int btnId, Action onClick, Action onPressDown, Action onPressUp, Func<bool> isVisible, Func<Count> getNum) { }

	// RVA: 0xAB5800 Offset: 0xAB5800 VA: 0xAB5800 Slot: 4
	public bool get_Visible() { }

	[CompilerGeneratedAttribute] // RVA: 0x667EF0 Offset: 0x667EF0 VA: 0x667EF0
	// RVA: 0xAB5878 Offset: 0xAB5878 VA: 0xAB5878 Slot: 5
	public int get_ButtonId() { }

	[CompilerGeneratedAttribute] // RVA: 0x667F00 Offset: 0x667F00 VA: 0x667F00
	// RVA: 0xAB57F8 Offset: 0xAB57F8 VA: 0xAB57F8
	public void set_ButtonId(int value) { }

	// RVA: 0xAB5880 Offset: 0xAB5880 VA: 0xAB5880 Slot: 6
	public Count get_Num() { }

	// RVA: 0xAB5908 Offset: 0xAB5908 VA: 0xAB5908 Slot: 7
	public ButtonPriority get_Priority() { }

	// RVA: 0xAB591C Offset: 0xAB591C VA: 0xAB591C Slot: 8
	public void set_Priority(ButtonPriority value) { }

	// RVA: 0xAB5924 Offset: 0xAB5924 VA: 0xAB5924 Slot: 9
	public ref ValueTuple<float, float> get_CdTimeRange() { }

	// RVA: 0xAB59AC Offset: 0xAB59AC VA: 0xAB59AC Slot: 10
	public ref ValueTuple<float, float> get_ActiveTimeRange() { }

	[CompilerGeneratedAttribute] // RVA: 0x667F10 Offset: 0x667F10 VA: 0x667F10
	// RVA: 0xAB5A34 Offset: 0xAB5A34 VA: 0xAB5A34 Slot: 11
	public bool get_IsActive() { }

	[CompilerGeneratedAttribute] // RVA: 0x667F20 Offset: 0x667F20 VA: 0x667F20
	// RVA: 0xAB5A3C Offset: 0xAB5A3C VA: 0xAB5A3C Slot: 12
	public void set_IsActive(bool value) { }

	// RVA: 0xAB5A44 Offset: 0xAB5A44 VA: 0xAB5A44 Slot: 13
	public void OnClick() { }

	// RVA: 0xAB5A58 Offset: 0xAB5A58 VA: 0xAB5A58 Slot: 14
	public void OnPressDown() { }

	// RVA: 0xAB5A6C Offset: 0xAB5A6C VA: 0xAB5A6C Slot: 15
	public void OnPressUp() { }

	// RVA: 0xAB5A80 Offset: 0xAB5A80 VA: 0xAB5A80
	private static void .cctor() { }
}
