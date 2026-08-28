// Namespace: 
public class particle_table.Record : ICloneable // TypeDefIndex: 10748
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572054 Offset: 0x572054 VA: 0x572054
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572064 Offset: 0x572064 VA: 0x572064
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572074 Offset: 0x572074 VA: 0x572074
	private string <prefab_name_lod0>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572084 Offset: 0x572084 VA: 0x572084
	private string <prefab_name_lod1>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572094 Offset: 0x572094 VA: 0x572094
	private string <prefab_name_lod2>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x5720A4 Offset: 0x5720A4 VA: 0x5720A4
	private float <duration>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string prefab_name_lod0 { get; set; }
	public string prefab_name_lod1 { get; set; }
	public string prefab_name_lod2 { get; set; }
	public float duration { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x664C10 Offset: 0x664C10 VA: 0x664C10
	// RVA: 0x1EC24EC Offset: 0x1EC24EC VA: 0x1EC24EC
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664C20 Offset: 0x664C20 VA: 0x664C20
	// RVA: 0x1EC24F4 Offset: 0x1EC24F4 VA: 0x1EC24F4
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664C30 Offset: 0x664C30 VA: 0x664C30
	// RVA: 0x1EC24FC Offset: 0x1EC24FC VA: 0x1EC24FC
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x664C40 Offset: 0x664C40 VA: 0x664C40
	// RVA: 0x1EC2504 Offset: 0x1EC2504 VA: 0x1EC2504
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664C50 Offset: 0x664C50 VA: 0x664C50
	// RVA: 0x1EC250C Offset: 0x1EC250C VA: 0x1EC250C
	public string get_prefab_name_lod0() { }

	[CompilerGeneratedAttribute] // RVA: 0x664C60 Offset: 0x664C60 VA: 0x664C60
	// RVA: 0x1EC2514 Offset: 0x1EC2514 VA: 0x1EC2514
	private void set_prefab_name_lod0(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664C70 Offset: 0x664C70 VA: 0x664C70
	// RVA: 0x1EC251C Offset: 0x1EC251C VA: 0x1EC251C
	public string get_prefab_name_lod1() { }

	[CompilerGeneratedAttribute] // RVA: 0x664C80 Offset: 0x664C80 VA: 0x664C80
	// RVA: 0x1EC2524 Offset: 0x1EC2524 VA: 0x1EC2524
	private void set_prefab_name_lod1(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664C90 Offset: 0x664C90 VA: 0x664C90
	// RVA: 0x1EC252C Offset: 0x1EC252C VA: 0x1EC252C
	public string get_prefab_name_lod2() { }

	[CompilerGeneratedAttribute] // RVA: 0x664CA0 Offset: 0x664CA0 VA: 0x664CA0
	// RVA: 0x1EC2534 Offset: 0x1EC2534 VA: 0x1EC2534
	private void set_prefab_name_lod2(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664CB0 Offset: 0x664CB0 VA: 0x664CB0
	// RVA: 0x1EC253C Offset: 0x1EC253C VA: 0x1EC253C
	public float get_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x664CC0 Offset: 0x664CC0 VA: 0x664CC0
	// RVA: 0x1EC2544 Offset: 0x1EC2544 VA: 0x1EC2544
	private void set_duration(float value) { }

	// RVA: 0x1EC22EC Offset: 0x1EC22EC VA: 0x1EC22EC
	internal void .ctor(MemoryStream reader, Action<particle_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1EC141C Offset: 0x1EC141C VA: 0x1EC141C
	internal static bool SetupReadActions(Field[] fields, Action<particle_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1EC2554 Offset: 0x1EC2554 VA: 0x1EC2554 Slot: 4
	public object Clone() { }
}
