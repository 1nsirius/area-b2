// Namespace: 
public class sensitivity_table.Record : ICloneable // TypeDefIndex: 10804
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5729B4 Offset: 0x5729B4 VA: 0x5729B4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5729C4 Offset: 0x5729C4 VA: 0x5729C4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5729D4 Offset: 0x5729D4 VA: 0x5729D4
	private float <value1>k__BackingField; // 0x10

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public float value1 { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x665ED0 Offset: 0x665ED0 VA: 0x665ED0
	// RVA: 0x1F2930C Offset: 0x1F2930C VA: 0x1F2930C
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x665EE0 Offset: 0x665EE0 VA: 0x665EE0
	// RVA: 0x1F29314 Offset: 0x1F29314 VA: 0x1F29314
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665EF0 Offset: 0x665EF0 VA: 0x665EF0
	// RVA: 0x1F2931C Offset: 0x1F2931C VA: 0x1F2931C
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x665F00 Offset: 0x665F00 VA: 0x665F00
	// RVA: 0x1F29324 Offset: 0x1F29324 VA: 0x1F29324
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665F10 Offset: 0x665F10 VA: 0x665F10
	// RVA: 0x1F2932C Offset: 0x1F2932C VA: 0x1F2932C
	public float get_value1() { }

	[CompilerGeneratedAttribute] // RVA: 0x665F20 Offset: 0x665F20 VA: 0x665F20
	// RVA: 0x1F29334 Offset: 0x1F29334 VA: 0x1F29334
	private void set_value1(float value) { }

	// RVA: 0x1F2910C Offset: 0x1F2910C VA: 0x1F2910C
	internal void .ctor(MemoryStream reader, Action<sensitivity_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F28734 Offset: 0x1F28734 VA: 0x1F28734
	internal static bool SetupReadActions(Field[] fields, Action<sensitivity_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F29344 Offset: 0x1F29344 VA: 0x1F29344 Slot: 4
	public object Clone() { }
}
