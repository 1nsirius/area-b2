// Namespace: 
public abstract class MainCharacterController.EmptySkillController : ISkillController // TypeDefIndex: 12594
{
	// Fields
	[TupleElementNamesAttribute] // RVA: 0x57906C Offset: 0x57906C VA: 0x57906C
	private static readonly ValueTuple<float, float> mDefaultTimeRange; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x57910C Offset: 0x57910C VA: 0x57910C
	private Count <Num>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x57911C Offset: 0x57911C VA: 0x57911C
	private ButtonPriority <Priority>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x57912C Offset: 0x57912C VA: 0x57912C
	private bool <IsActive>k__BackingField; // 0x18

	// Properties
	public virtual bool Visible { get; }
	public virtual int ButtonId { get; set; }
	public virtual Count Num { get; set; }
	public virtual ButtonPriority Priority { get; set; }
	[TupleElementNamesAttribute] // RVA: 0x66EF7C Offset: 0x66EF7C VA: 0x66EF7C
	[IsReadOnlyAttribute] // RVA: 0x66EF7C Offset: 0x66EF7C VA: 0x66EF7C
	public virtual ValueTuple<float, float> CdTimeRange { get; }
	[TupleElementNamesAttribute] // RVA: 0x66F02C Offset: 0x66F02C VA: 0x66F02C
	[IsReadOnlyAttribute] // RVA: 0x66F02C Offset: 0x66F02C VA: 0x66F02C
	public virtual ValueTuple<float, float> ActiveTimeRange { get; }
	public virtual bool IsActive { get; set; }

	// Methods

	// RVA: 0xAB5B08 Offset: 0xAB5B08 VA: 0xAB5B08 Slot: 16
	public virtual bool get_Visible() { }

	// RVA: 0xAB5B10 Offset: 0xAB5B10 VA: 0xAB5B10 Slot: 17
	public virtual int get_ButtonId() { }

	// RVA: 0xAB5B18 Offset: 0xAB5B18 VA: 0xAB5B18 Slot: 18
	public virtual void set_ButtonId(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667E10 Offset: 0x667E10 VA: 0x667E10
	// RVA: 0xAB5BA0 Offset: 0xAB5BA0 VA: 0xAB5BA0 Slot: 19
	public virtual Count get_Num() { }

	[CompilerGeneratedAttribute] // RVA: 0x667E20 Offset: 0x667E20 VA: 0x667E20
	// RVA: 0xAB5BB4 Offset: 0xAB5BB4 VA: 0xAB5BB4 Slot: 20
	public virtual void set_Num(Count value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667E30 Offset: 0x667E30 VA: 0x667E30
	// RVA: 0xAB5BC0 Offset: 0xAB5BC0 VA: 0xAB5BC0 Slot: 21
	public virtual ButtonPriority get_Priority() { }

	[CompilerGeneratedAttribute] // RVA: 0x667E40 Offset: 0x667E40 VA: 0x667E40
	// RVA: 0xAB5BD4 Offset: 0xAB5BD4 VA: 0xAB5BD4 Slot: 22
	public virtual void set_Priority(ButtonPriority value) { }

	// RVA: 0xAB5BE0 Offset: 0xAB5BE0 VA: 0xAB5BE0 Slot: 23
	public virtual ref ValueTuple<float, float> get_CdTimeRange() { }

	// RVA: 0xAB5C68 Offset: 0xAB5C68 VA: 0xAB5C68 Slot: 24
	public virtual ref ValueTuple<float, float> get_ActiveTimeRange() { }

	[CompilerGeneratedAttribute] // RVA: 0x667E50 Offset: 0x667E50 VA: 0x667E50
	// RVA: 0xAB5CF0 Offset: 0xAB5CF0 VA: 0xAB5CF0 Slot: 25
	public virtual bool get_IsActive() { }

	[CompilerGeneratedAttribute] // RVA: 0x667E60 Offset: 0x667E60 VA: 0x667E60
	// RVA: 0xAB5CF8 Offset: 0xAB5CF8 VA: 0xAB5CF8 Slot: 26
	public virtual void set_IsActive(bool value) { }

	// RVA: 0xAB5D00 Offset: 0xAB5D00 VA: 0xAB5D00 Slot: 27
	public virtual void OnClick() { }

	// RVA: 0xAB5D04 Offset: 0xAB5D04 VA: 0xAB5D04 Slot: 28
	public virtual void OnPressDown() { }

	// RVA: 0xAB5D08 Offset: 0xAB5D08 VA: 0xAB5D08 Slot: 29
	public virtual void OnPressUp() { }

	// RVA: 0xAB5D0C Offset: 0xAB5D0C VA: 0xAB5D0C
	protected void .ctor() { }

	// RVA: 0xAB5DD8 Offset: 0xAB5DD8 VA: 0xAB5DD8
	private static void .cctor() { }
}
