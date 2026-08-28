// Namespace: 
public class user_guide_table.Record : ICloneable // TypeDefIndex: 10856
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573234 Offset: 0x573234 VA: 0x573234
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x573244 Offset: 0x573244 VA: 0x573244
	private int <mode_id>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x573254 Offset: 0x573254 VA: 0x573254
	private int <map_id>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x573264 Offset: 0x573264 VA: 0x573264
	private string <lua_script_name>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x573274 Offset: 0x573274 VA: 0x573274
	private string <guide_prefab_path>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x573284 Offset: 0x573284 VA: 0x573284
	private string <voice_sound_bank>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x573294 Offset: 0x573294 VA: 0x573294
	private int[] <npc_id>k__BackingField; // 0x20

	// Properties
	public int id { get; set; }
	public int mode_id { get; set; }
	public int map_id { get; set; }
	public string lua_script_name { get; set; }
	public string guide_prefab_path { get; set; }
	public string voice_sound_bank { get; set; }
	public int[] npc_id { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x666FD0 Offset: 0x666FD0 VA: 0x666FD0
	// RVA: 0x10283E0 Offset: 0x10283E0 VA: 0x10283E0
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x666FE0 Offset: 0x666FE0 VA: 0x666FE0
	// RVA: 0x10283E8 Offset: 0x10283E8 VA: 0x10283E8
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666FF0 Offset: 0x666FF0 VA: 0x666FF0
	// RVA: 0x10283F0 Offset: 0x10283F0 VA: 0x10283F0
	public int get_mode_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x667000 Offset: 0x667000 VA: 0x667000
	// RVA: 0x10283F8 Offset: 0x10283F8 VA: 0x10283F8
	private void set_mode_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667010 Offset: 0x667010 VA: 0x667010
	// RVA: 0x1028400 Offset: 0x1028400 VA: 0x1028400
	public int get_map_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x667020 Offset: 0x667020 VA: 0x667020
	// RVA: 0x1028408 Offset: 0x1028408 VA: 0x1028408
	private void set_map_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667030 Offset: 0x667030 VA: 0x667030
	// RVA: 0x1028410 Offset: 0x1028410 VA: 0x1028410
	public string get_lua_script_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x667040 Offset: 0x667040 VA: 0x667040
	// RVA: 0x1028418 Offset: 0x1028418 VA: 0x1028418
	private void set_lua_script_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667050 Offset: 0x667050 VA: 0x667050
	// RVA: 0x1028420 Offset: 0x1028420 VA: 0x1028420
	public string get_guide_prefab_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x667060 Offset: 0x667060 VA: 0x667060
	// RVA: 0x1028428 Offset: 0x1028428 VA: 0x1028428
	private void set_guide_prefab_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667070 Offset: 0x667070 VA: 0x667070
	// RVA: 0x1028430 Offset: 0x1028430 VA: 0x1028430
	public string get_voice_sound_bank() { }

	[CompilerGeneratedAttribute] // RVA: 0x667080 Offset: 0x667080 VA: 0x667080
	// RVA: 0x1028438 Offset: 0x1028438 VA: 0x1028438
	private void set_voice_sound_bank(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667090 Offset: 0x667090 VA: 0x667090
	// RVA: 0x1028440 Offset: 0x1028440 VA: 0x1028440
	public int[] get_npc_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6670A0 Offset: 0x6670A0 VA: 0x6670A0
	// RVA: 0x1028448 Offset: 0x1028448 VA: 0x1028448
	private void set_npc_id(int[] value) { }

	// RVA: 0x10281E0 Offset: 0x10281E0 VA: 0x10281E0
	internal void .ctor(MemoryStream reader, Action<user_guide_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x102719C Offset: 0x102719C VA: 0x102719C
	internal static bool SetupReadActions(Field[] fields, Action<user_guide_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1028458 Offset: 0x1028458 VA: 0x1028458 Slot: 4
	public object Clone() { }
}
