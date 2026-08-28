// Namespace: 
public class chest_table.Record : ICloneable // TypeDefIndex: 10600
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56FC14 Offset: 0x56FC14 VA: 0x56FC14
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56FC24 Offset: 0x56FC24 VA: 0x56FC24
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56FC34 Offset: 0x56FC34 VA: 0x56FC34
	private int <box_id>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56FC44 Offset: 0x56FC44 VA: 0x56FC44
	private int <number>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56FC54 Offset: 0x56FC54 VA: 0x56FC54
	private int <is_single>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int box_id { get; set; }
	public int number { get; set; }
	public int is_single { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660390 Offset: 0x660390 VA: 0x660390
	// RVA: 0x1E12380 Offset: 0x1E12380 VA: 0x1E12380
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6603A0 Offset: 0x6603A0 VA: 0x6603A0
	// RVA: 0x1E12388 Offset: 0x1E12388 VA: 0x1E12388
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6603B0 Offset: 0x6603B0 VA: 0x6603B0
	// RVA: 0x1E12390 Offset: 0x1E12390 VA: 0x1E12390
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x6603C0 Offset: 0x6603C0 VA: 0x6603C0
	// RVA: 0x1E12398 Offset: 0x1E12398 VA: 0x1E12398
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6603D0 Offset: 0x6603D0 VA: 0x6603D0
	// RVA: 0x1E123A0 Offset: 0x1E123A0 VA: 0x1E123A0
	public int get_box_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6603E0 Offset: 0x6603E0 VA: 0x6603E0
	// RVA: 0x1E123A8 Offset: 0x1E123A8 VA: 0x1E123A8
	private void set_box_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6603F0 Offset: 0x6603F0 VA: 0x6603F0
	// RVA: 0x1E123B0 Offset: 0x1E123B0 VA: 0x1E123B0
	public int get_number() { }

	[CompilerGeneratedAttribute] // RVA: 0x660400 Offset: 0x660400 VA: 0x660400
	// RVA: 0x1E123B8 Offset: 0x1E123B8 VA: 0x1E123B8
	private void set_number(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660410 Offset: 0x660410 VA: 0x660410
	// RVA: 0x1E123C0 Offset: 0x1E123C0 VA: 0x1E123C0
	public int get_is_single() { }

	[CompilerGeneratedAttribute] // RVA: 0x660420 Offset: 0x660420 VA: 0x660420
	// RVA: 0x1E123C8 Offset: 0x1E123C8 VA: 0x1E123C8
	private void set_is_single(int value) { }

	// RVA: 0x1E12180 Offset: 0x1E12180 VA: 0x1E12180
	internal void .ctor(MemoryStream reader, Action<chest_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E11458 Offset: 0x1E11458 VA: 0x1E11458
	internal static bool SetupReadActions(Field[] fields, Action<chest_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E123D0 Offset: 0x1E123D0 VA: 0x1E123D0 Slot: 4
	public object Clone() { }
}
