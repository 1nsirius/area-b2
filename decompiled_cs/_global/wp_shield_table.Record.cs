// Namespace: 
public class wp_shield_table.Record : ICloneable // TypeDefIndex: 10880
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573534 Offset: 0x573534 VA: 0x573534
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x573544 Offset: 0x573544 VA: 0x573544
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x573554 Offset: 0x573554 VA: 0x573554
	private int <gun_data_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x573564 Offset: 0x573564 VA: 0x573564
	private int <secondary_weapon>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x573574 Offset: 0x573574 VA: 0x573574
	private float <secondary_weapon_scatter_multi>k__BackingField; // 0x18

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int gun_data_index { get; set; }
	public int secondary_weapon { get; set; }
	public float secondary_weapon_scatter_multi { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6675D0 Offset: 0x6675D0 VA: 0x6675D0
	// RVA: 0x10323B4 Offset: 0x10323B4 VA: 0x10323B4
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6675E0 Offset: 0x6675E0 VA: 0x6675E0
	// RVA: 0x10323BC Offset: 0x10323BC VA: 0x10323BC
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6675F0 Offset: 0x6675F0 VA: 0x6675F0
	// RVA: 0x10323C4 Offset: 0x10323C4 VA: 0x10323C4
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x667600 Offset: 0x667600 VA: 0x667600
	// RVA: 0x10323CC Offset: 0x10323CC VA: 0x10323CC
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667610 Offset: 0x667610 VA: 0x667610
	// RVA: 0x10323D4 Offset: 0x10323D4 VA: 0x10323D4
	public int get_gun_data_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x667620 Offset: 0x667620 VA: 0x667620
	// RVA: 0x10323DC Offset: 0x10323DC VA: 0x10323DC
	private void set_gun_data_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667630 Offset: 0x667630 VA: 0x667630
	// RVA: 0x10323E4 Offset: 0x10323E4 VA: 0x10323E4
	public int get_secondary_weapon() { }

	[CompilerGeneratedAttribute] // RVA: 0x667640 Offset: 0x667640 VA: 0x667640
	// RVA: 0x10323EC Offset: 0x10323EC VA: 0x10323EC
	private void set_secondary_weapon(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667650 Offset: 0x667650 VA: 0x667650
	// RVA: 0x10323F4 Offset: 0x10323F4 VA: 0x10323F4
	public float get_secondary_weapon_scatter_multi() { }

	[CompilerGeneratedAttribute] // RVA: 0x667660 Offset: 0x667660 VA: 0x667660
	// RVA: 0x10323FC Offset: 0x10323FC VA: 0x10323FC
	private void set_secondary_weapon_scatter_multi(float value) { }

	// RVA: 0x10321B4 Offset: 0x10321B4 VA: 0x10321B4
	internal void .ctor(MemoryStream reader, Action<wp_shield_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x103148C Offset: 0x103148C VA: 0x103148C
	internal static bool SetupReadActions(Field[] fields, Action<wp_shield_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x103240C Offset: 0x103240C VA: 0x103240C Slot: 4
	public object Clone() { }
}
