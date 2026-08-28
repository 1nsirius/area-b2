// Namespace: 
public class maps_location_table.Record : ICloneable // TypeDefIndex: 10720
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571B04 Offset: 0x571B04 VA: 0x571B04
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571B14 Offset: 0x571B14 VA: 0x571B14
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571B24 Offset: 0x571B24 VA: 0x571B24
	private string <name>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571B34 Offset: 0x571B34 VA: 0x571B34
	private int <language_id>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x571B44 Offset: 0x571B44 VA: 0x571B44
	private string <floor_name>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x571B54 Offset: 0x571B54 VA: 0x571B54
	private int <floor_name_lang_id>k__BackingField; // 0x1C

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string name { get; set; }
	public int language_id { get; set; }
	public string floor_name { get; set; }
	public int floor_name_lang_id { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x664170 Offset: 0x664170 VA: 0x664170
	// RVA: 0x197DD58 Offset: 0x197DD58 VA: 0x197DD58
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664180 Offset: 0x664180 VA: 0x664180
	// RVA: 0x197DD60 Offset: 0x197DD60 VA: 0x197DD60
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664190 Offset: 0x664190 VA: 0x664190
	// RVA: 0x197DD68 Offset: 0x197DD68 VA: 0x197DD68
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x6641A0 Offset: 0x6641A0 VA: 0x6641A0
	// RVA: 0x197DD70 Offset: 0x197DD70 VA: 0x197DD70
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6641B0 Offset: 0x6641B0 VA: 0x6641B0
	// RVA: 0x197DD78 Offset: 0x197DD78 VA: 0x197DD78
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x6641C0 Offset: 0x6641C0 VA: 0x6641C0
	// RVA: 0x197DD80 Offset: 0x197DD80 VA: 0x197DD80
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6641D0 Offset: 0x6641D0 VA: 0x6641D0
	// RVA: 0x197DD88 Offset: 0x197DD88 VA: 0x197DD88
	public int get_language_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6641E0 Offset: 0x6641E0 VA: 0x6641E0
	// RVA: 0x197DD90 Offset: 0x197DD90 VA: 0x197DD90
	private void set_language_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6641F0 Offset: 0x6641F0 VA: 0x6641F0
	// RVA: 0x197DD98 Offset: 0x197DD98 VA: 0x197DD98
	public string get_floor_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x664200 Offset: 0x664200 VA: 0x664200
	// RVA: 0x197DDA0 Offset: 0x197DDA0 VA: 0x197DDA0
	private void set_floor_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664210 Offset: 0x664210 VA: 0x664210
	// RVA: 0x197DDA8 Offset: 0x197DDA8 VA: 0x197DDA8
	public int get_floor_name_lang_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x664220 Offset: 0x664220 VA: 0x664220
	// RVA: 0x197DDB0 Offset: 0x197DDB0 VA: 0x197DDB0
	private void set_floor_name_lang_id(int value) { }

	// RVA: 0x197DB58 Offset: 0x197DB58 VA: 0x197DB58
	internal void .ctor(MemoryStream reader, Action<maps_location_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x197CC88 Offset: 0x197CC88 VA: 0x197CC88
	internal static bool SetupReadActions(Field[] fields, Action<maps_location_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x197DDC0 Offset: 0x197DDC0 VA: 0x197DDC0 Slot: 4
	public object Clone() { }
}
