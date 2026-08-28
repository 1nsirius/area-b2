// Namespace: 
public class wp_normal_gun_table.Record : ICloneable // TypeDefIndex: 10872
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5734C4 Offset: 0x5734C4 VA: 0x5734C4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5734D4 Offset: 0x5734D4 VA: 0x5734D4
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5734E4 Offset: 0x5734E4 VA: 0x5734E4
	private int <gun_data_index>k__BackingField; // 0x10

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int gun_data_index { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6674F0 Offset: 0x6674F0 VA: 0x6674F0
	// RVA: 0x102FB08 Offset: 0x102FB08 VA: 0x102FB08
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x667500 Offset: 0x667500 VA: 0x667500
	// RVA: 0x102FB10 Offset: 0x102FB10 VA: 0x102FB10
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667510 Offset: 0x667510 VA: 0x667510
	// RVA: 0x102FB18 Offset: 0x102FB18 VA: 0x102FB18
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x667520 Offset: 0x667520 VA: 0x667520
	// RVA: 0x102FB20 Offset: 0x102FB20 VA: 0x102FB20
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667530 Offset: 0x667530 VA: 0x667530
	// RVA: 0x102FB28 Offset: 0x102FB28 VA: 0x102FB28
	public int get_gun_data_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x667540 Offset: 0x667540 VA: 0x667540
	// RVA: 0x102FB30 Offset: 0x102FB30 VA: 0x102FB30
	private void set_gun_data_index(int value) { }

	// RVA: 0x102F908 Offset: 0x102F908 VA: 0x102F908
	internal void .ctor(MemoryStream reader, Action<wp_normal_gun_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x102EF30 Offset: 0x102EF30 VA: 0x102EF30
	internal static bool SetupReadActions(Field[] fields, Action<wp_normal_gun_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x102FB40 Offset: 0x102FB40 VA: 0x102FB40 Slot: 4
	public object Clone() { }
}
