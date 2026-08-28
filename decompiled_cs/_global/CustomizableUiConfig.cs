// Namespace: 
public class CustomizableUiConfig : BaseSingleton<CustomizableUiConfig> // TypeDefIndex: 5627
{
	// Fields
	private CustomizableLayout mCrtLayout; // 0x8
	private bool mEnable; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x55E0F4 Offset: 0x55E0F4 VA: 0x55E0F4
	private OperationType <OperationType>k__BackingField; // 0x10

	// Properties
	public bool Enable { get; set; }
	public OperationType OperationType { get; set; }

	// Methods

	// RVA: 0xD6A0B4 Offset: 0xD6A0B4 VA: 0xD6A0B4
	public bool get_Enable() { }

	// RVA: 0xD6A0BC Offset: 0xD6A0BC VA: 0xD6A0BC
	public void set_Enable(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A69C Offset: 0x57A69C VA: 0x57A69C
	// RVA: 0xD656B8 Offset: 0xD656B8 VA: 0xD656B8
	public OperationType get_OperationType() { }

	[CompilerGeneratedAttribute] // RVA: 0x57A6AC Offset: 0x57A6AC VA: 0x57A6AC
	// RVA: 0xD6A1A4 Offset: 0xD6A1A4 VA: 0xD6A1A4
	public void set_OperationType(OperationType value) { }

	// RVA: 0xD64BF8 Offset: 0xD64BF8 VA: 0xD64BF8
	public CustomValue GetValue(uint uid) { }

	// RVA: 0xD6A1AC Offset: 0xD6A1AC VA: 0xD6A1AC
	public void SetLayout(CustomizableLayout layout) { }

	// RVA: 0xD6A280 Offset: 0xD6A280 VA: 0xD6A280
	public bool AnyChange() { }

	// RVA: 0xD6A31C Offset: 0xD6A31C VA: 0xD6A31C
	public void .ctor() { }
}
