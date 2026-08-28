// Namespace: 
public class wp_projectile_gun_table.Record : ICloneable // TypeDefIndex: 10876
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5734F4 Offset: 0x5734F4 VA: 0x5734F4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x573504 Offset: 0x573504 VA: 0x573504
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x573514 Offset: 0x573514 VA: 0x573514
	private int <gun_data_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x573524 Offset: 0x573524 VA: 0x573524
	private int <content_id>k__BackingField; // 0x14

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int gun_data_index { get; set; }
	public int content_id { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667550 Offset: 0x667550 VA: 0x667550
	// RVA: 0x1030E68 Offset: 0x1030E68 VA: 0x1030E68
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x667560 Offset: 0x667560 VA: 0x667560
	// RVA: 0x1030E70 Offset: 0x1030E70 VA: 0x1030E70
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667570 Offset: 0x667570 VA: 0x667570
	// RVA: 0x1030E78 Offset: 0x1030E78 VA: 0x1030E78
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x667580 Offset: 0x667580 VA: 0x667580
	// RVA: 0x1030E80 Offset: 0x1030E80 VA: 0x1030E80
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667590 Offset: 0x667590 VA: 0x667590
	// RVA: 0x1030E88 Offset: 0x1030E88 VA: 0x1030E88
	public int get_gun_data_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x6675A0 Offset: 0x6675A0 VA: 0x6675A0
	// RVA: 0x1030E90 Offset: 0x1030E90 VA: 0x1030E90
	private void set_gun_data_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6675B0 Offset: 0x6675B0 VA: 0x6675B0
	// RVA: 0x1030E98 Offset: 0x1030E98 VA: 0x1030E98
	public int get_content_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6675C0 Offset: 0x6675C0 VA: 0x6675C0
	// RVA: 0x1030EA0 Offset: 0x1030EA0 VA: 0x1030EA0
	private void set_content_id(int value) { }

	// RVA: 0x1030C68 Offset: 0x1030C68 VA: 0x1030C68
	internal void .ctor(MemoryStream reader, Action<wp_projectile_gun_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x10300E8 Offset: 0x10300E8 VA: 0x10300E8
	internal static bool SetupReadActions(Field[] fields, Action<wp_projectile_gun_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1030EB0 Offset: 0x1030EB0 VA: 0x1030EB0 Slot: 4
	public object Clone() { }
}
