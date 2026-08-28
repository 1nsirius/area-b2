// Namespace: 
public class hand_props_soundbank_table.Record : ICloneable // TypeDefIndex: 10684
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571674 Offset: 0x571674 VA: 0x571674
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571684 Offset: 0x571684 VA: 0x571684
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571694 Offset: 0x571694 VA: 0x571694
	private string[] <soundbank>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5716A4 Offset: 0x5716A4 VA: 0x5716A4
	private int <size>k__BackingField; // 0x14

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public string[] soundbank { get; set; }
	public int size { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663850 Offset: 0x663850 VA: 0x663850
	// RVA: 0x196C034 Offset: 0x196C034 VA: 0x196C034
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663860 Offset: 0x663860 VA: 0x663860
	// RVA: 0x196C03C Offset: 0x196C03C VA: 0x196C03C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663870 Offset: 0x663870 VA: 0x663870
	// RVA: 0x196C044 Offset: 0x196C044 VA: 0x196C044
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663880 Offset: 0x663880 VA: 0x663880
	// RVA: 0x196C04C Offset: 0x196C04C VA: 0x196C04C
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663890 Offset: 0x663890 VA: 0x663890
	// RVA: 0x196C054 Offset: 0x196C054 VA: 0x196C054
	public string[] get_soundbank() { }

	[CompilerGeneratedAttribute] // RVA: 0x6638A0 Offset: 0x6638A0 VA: 0x6638A0
	// RVA: 0x196C05C Offset: 0x196C05C VA: 0x196C05C
	private void set_soundbank(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6638B0 Offset: 0x6638B0 VA: 0x6638B0
	// RVA: 0x196C064 Offset: 0x196C064 VA: 0x196C064
	public int get_size() { }

	[CompilerGeneratedAttribute] // RVA: 0x6638C0 Offset: 0x6638C0 VA: 0x6638C0
	// RVA: 0x196C06C Offset: 0x196C06C VA: 0x196C06C
	private void set_size(int value) { }

	// RVA: 0x196BE34 Offset: 0x196BE34 VA: 0x196BE34
	internal void .ctor(MemoryStream reader, Action<hand_props_soundbank_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x196B2B4 Offset: 0x196B2B4 VA: 0x196B2B4
	internal static bool SetupReadActions(Field[] fields, Action<hand_props_soundbank_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x196C07C Offset: 0x196C07C VA: 0x196C07C Slot: 4
	public object Clone() { }
}
