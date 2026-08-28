// Namespace: 
public class maps_table.Record : ICloneable // TypeDefIndex: 10716
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x571944 Offset: 0x571944 VA: 0x571944
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x571954 Offset: 0x571954 VA: 0x571954
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x571964 Offset: 0x571964 VA: 0x571964
	private string <name>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x571974 Offset: 0x571974 VA: 0x571974
	private int <name_lang_index>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x571984 Offset: 0x571984 VA: 0x571984
	private string <scene_name>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x571994 Offset: 0x571994 VA: 0x571994
	private int <available>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x5719A4 Offset: 0x5719A4 VA: 0x5719A4
	private int <select_available>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x5719B4 Offset: 0x5719B4 VA: 0x5719B4
	private int <select_weight>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x5719C4 Offset: 0x5719C4 VA: 0x5719C4
	private string <map_choose_bg>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x5719D4 Offset: 0x5719D4 VA: 0x5719D4
	private string <map_bg>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x5719E4 Offset: 0x5719E4 VA: 0x5719E4
	private int[] <attacker_born_name>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x5719F4 Offset: 0x5719F4 VA: 0x5719F4
	private int[] <defender_born_name>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x571A04 Offset: 0x571A04 VA: 0x571A04
	private int[] <attacker_born>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x571A14 Offset: 0x571A14 VA: 0x571A14
	private int[] <defender_born>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x571A24 Offset: 0x571A24 VA: 0x571A24
	private int[] <drone_born>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x571A34 Offset: 0x571A34 VA: 0x571A34
	private string <map_bg_prefab>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x571A44 Offset: 0x571A44 VA: 0x571A44
	private string[] <attacker_born_ui_maps>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x571A54 Offset: 0x571A54 VA: 0x571A54
	private string <uva_destroyed_ui>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x571A64 Offset: 0x571A64 VA: 0x571A64
	private int[] <target_zone>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x571A74 Offset: 0x571A74 VA: 0x571A74
	private string[] <defender_born_ui_maps>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x571A84 Offset: 0x571A84 VA: 0x571A84
	private int[] <bomb_defender_born_name>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x571A94 Offset: 0x571A94 VA: 0x571A94
	private int[] <bomb_defender_born>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x571AA4 Offset: 0x571AA4 VA: 0x571AA4
	private int[] <bomb_target_zone>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x571AB4 Offset: 0x571AB4 VA: 0x571AB4
	private string[] <bomb_defender_born_ui_maps>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x571AC4 Offset: 0x571AC4 VA: 0x571AC4
	private string[] <sound_banks>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x571AD4 Offset: 0x571AD4 VA: 0x571AD4
	private int[] <preload_particle_id_array>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x571AE4 Offset: 0x571AE4 VA: 0x571AE4
	private string <floor_json>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x571AF4 Offset: 0x571AF4 VA: 0x571AF4
	private float <floor_sound_threshold>k__BackingField; // 0x74

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string name { get; set; }
	public int name_lang_index { get; set; }
	public string scene_name { get; set; }
	public int available { get; set; }
	public int select_available { get; set; }
	public int select_weight { get; set; }
	public string map_choose_bg { get; set; }
	public string map_bg { get; set; }
	public int[] attacker_born_name { get; set; }
	public int[] defender_born_name { get; set; }
	public int[] attacker_born { get; set; }
	public int[] defender_born { get; set; }
	public int[] drone_born { get; set; }
	public string map_bg_prefab { get; set; }
	public string[] attacker_born_ui_maps { get; set; }
	public string uva_destroyed_ui { get; set; }
	public int[] target_zone { get; set; }
	public string[] defender_born_ui_maps { get; set; }
	public int[] bomb_defender_born_name { get; set; }
	public int[] bomb_defender_born { get; set; }
	public int[] bomb_target_zone { get; set; }
	public string[] bomb_defender_born_ui_maps { get; set; }
	public string[] sound_banks { get; set; }
	public int[] preload_particle_id_array { get; set; }
	public string floor_json { get; set; }
	public float floor_sound_threshold { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x663DF0 Offset: 0x663DF0 VA: 0x663DF0
	// RVA: 0x19818AC Offset: 0x19818AC VA: 0x19818AC
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x663E00 Offset: 0x663E00 VA: 0x663E00
	// RVA: 0x19818B4 Offset: 0x19818B4 VA: 0x19818B4
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663E10 Offset: 0x663E10 VA: 0x663E10
	// RVA: 0x19818BC Offset: 0x19818BC VA: 0x19818BC
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x663E20 Offset: 0x663E20 VA: 0x663E20
	// RVA: 0x19818C4 Offset: 0x19818C4 VA: 0x19818C4
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663E30 Offset: 0x663E30 VA: 0x663E30
	// RVA: 0x19818CC Offset: 0x19818CC VA: 0x19818CC
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663E40 Offset: 0x663E40 VA: 0x663E40
	// RVA: 0x19818D4 Offset: 0x19818D4 VA: 0x19818D4
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663E50 Offset: 0x663E50 VA: 0x663E50
	// RVA: 0x19818DC Offset: 0x19818DC VA: 0x19818DC
	public int get_name_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x663E60 Offset: 0x663E60 VA: 0x663E60
	// RVA: 0x19818E4 Offset: 0x19818E4 VA: 0x19818E4
	private void set_name_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663E70 Offset: 0x663E70 VA: 0x663E70
	// RVA: 0x19818EC Offset: 0x19818EC VA: 0x19818EC
	public string get_scene_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663E80 Offset: 0x663E80 VA: 0x663E80
	// RVA: 0x19818F4 Offset: 0x19818F4 VA: 0x19818F4
	private void set_scene_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663E90 Offset: 0x663E90 VA: 0x663E90
	// RVA: 0x19818FC Offset: 0x19818FC VA: 0x19818FC
	public int get_available() { }

	[CompilerGeneratedAttribute] // RVA: 0x663EA0 Offset: 0x663EA0 VA: 0x663EA0
	// RVA: 0x1981904 Offset: 0x1981904 VA: 0x1981904
	private void set_available(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663EB0 Offset: 0x663EB0 VA: 0x663EB0
	// RVA: 0x198190C Offset: 0x198190C VA: 0x198190C
	public int get_select_available() { }

	[CompilerGeneratedAttribute] // RVA: 0x663EC0 Offset: 0x663EC0 VA: 0x663EC0
	// RVA: 0x1981914 Offset: 0x1981914 VA: 0x1981914
	private void set_select_available(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663ED0 Offset: 0x663ED0 VA: 0x663ED0
	// RVA: 0x198191C Offset: 0x198191C VA: 0x198191C
	public int get_select_weight() { }

	[CompilerGeneratedAttribute] // RVA: 0x663EE0 Offset: 0x663EE0 VA: 0x663EE0
	// RVA: 0x1981924 Offset: 0x1981924 VA: 0x1981924
	private void set_select_weight(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663EF0 Offset: 0x663EF0 VA: 0x663EF0
	// RVA: 0x198192C Offset: 0x198192C VA: 0x198192C
	public string get_map_choose_bg() { }

	[CompilerGeneratedAttribute] // RVA: 0x663F00 Offset: 0x663F00 VA: 0x663F00
	// RVA: 0x1981934 Offset: 0x1981934 VA: 0x1981934
	private void set_map_choose_bg(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663F10 Offset: 0x663F10 VA: 0x663F10
	// RVA: 0x198193C Offset: 0x198193C VA: 0x198193C
	public string get_map_bg() { }

	[CompilerGeneratedAttribute] // RVA: 0x663F20 Offset: 0x663F20 VA: 0x663F20
	// RVA: 0x1981944 Offset: 0x1981944 VA: 0x1981944
	private void set_map_bg(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663F30 Offset: 0x663F30 VA: 0x663F30
	// RVA: 0x198194C Offset: 0x198194C VA: 0x198194C
	public int[] get_attacker_born_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663F40 Offset: 0x663F40 VA: 0x663F40
	// RVA: 0x1981954 Offset: 0x1981954 VA: 0x1981954
	private void set_attacker_born_name(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663F50 Offset: 0x663F50 VA: 0x663F50
	// RVA: 0x198195C Offset: 0x198195C VA: 0x198195C
	public int[] get_defender_born_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x663F60 Offset: 0x663F60 VA: 0x663F60
	// RVA: 0x1981964 Offset: 0x1981964 VA: 0x1981964
	private void set_defender_born_name(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663F70 Offset: 0x663F70 VA: 0x663F70
	// RVA: 0x198196C Offset: 0x198196C VA: 0x198196C
	public int[] get_attacker_born() { }

	[CompilerGeneratedAttribute] // RVA: 0x663F80 Offset: 0x663F80 VA: 0x663F80
	// RVA: 0x1981974 Offset: 0x1981974 VA: 0x1981974
	private void set_attacker_born(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663F90 Offset: 0x663F90 VA: 0x663F90
	// RVA: 0x198197C Offset: 0x198197C VA: 0x198197C
	public int[] get_defender_born() { }

	[CompilerGeneratedAttribute] // RVA: 0x663FA0 Offset: 0x663FA0 VA: 0x663FA0
	// RVA: 0x1981984 Offset: 0x1981984 VA: 0x1981984
	private void set_defender_born(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663FB0 Offset: 0x663FB0 VA: 0x663FB0
	// RVA: 0x198198C Offset: 0x198198C VA: 0x198198C
	public int[] get_drone_born() { }

	[CompilerGeneratedAttribute] // RVA: 0x663FC0 Offset: 0x663FC0 VA: 0x663FC0
	// RVA: 0x1981994 Offset: 0x1981994 VA: 0x1981994
	private void set_drone_born(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663FD0 Offset: 0x663FD0 VA: 0x663FD0
	// RVA: 0x198199C Offset: 0x198199C VA: 0x198199C
	public string get_map_bg_prefab() { }

	[CompilerGeneratedAttribute] // RVA: 0x663FE0 Offset: 0x663FE0 VA: 0x663FE0
	// RVA: 0x19819A4 Offset: 0x19819A4 VA: 0x19819A4
	private void set_map_bg_prefab(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x663FF0 Offset: 0x663FF0 VA: 0x663FF0
	// RVA: 0x19819AC Offset: 0x19819AC VA: 0x19819AC
	public string[] get_attacker_born_ui_maps() { }

	[CompilerGeneratedAttribute] // RVA: 0x664000 Offset: 0x664000 VA: 0x664000
	// RVA: 0x19819B4 Offset: 0x19819B4 VA: 0x19819B4
	private void set_attacker_born_ui_maps(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664010 Offset: 0x664010 VA: 0x664010
	// RVA: 0x19819BC Offset: 0x19819BC VA: 0x19819BC
	public string get_uva_destroyed_ui() { }

	[CompilerGeneratedAttribute] // RVA: 0x664020 Offset: 0x664020 VA: 0x664020
	// RVA: 0x19819C4 Offset: 0x19819C4 VA: 0x19819C4
	private void set_uva_destroyed_ui(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664030 Offset: 0x664030 VA: 0x664030
	// RVA: 0x19819CC Offset: 0x19819CC VA: 0x19819CC
	public int[] get_target_zone() { }

	[CompilerGeneratedAttribute] // RVA: 0x664040 Offset: 0x664040 VA: 0x664040
	// RVA: 0x19819D4 Offset: 0x19819D4 VA: 0x19819D4
	private void set_target_zone(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664050 Offset: 0x664050 VA: 0x664050
	// RVA: 0x19819DC Offset: 0x19819DC VA: 0x19819DC
	public string[] get_defender_born_ui_maps() { }

	[CompilerGeneratedAttribute] // RVA: 0x664060 Offset: 0x664060 VA: 0x664060
	// RVA: 0x19819E4 Offset: 0x19819E4 VA: 0x19819E4
	private void set_defender_born_ui_maps(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664070 Offset: 0x664070 VA: 0x664070
	// RVA: 0x19819EC Offset: 0x19819EC VA: 0x19819EC
	public int[] get_bomb_defender_born_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x664080 Offset: 0x664080 VA: 0x664080
	// RVA: 0x19819F4 Offset: 0x19819F4 VA: 0x19819F4
	private void set_bomb_defender_born_name(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664090 Offset: 0x664090 VA: 0x664090
	// RVA: 0x19819FC Offset: 0x19819FC VA: 0x19819FC
	public int[] get_bomb_defender_born() { }

	[CompilerGeneratedAttribute] // RVA: 0x6640A0 Offset: 0x6640A0 VA: 0x6640A0
	// RVA: 0x1981A04 Offset: 0x1981A04 VA: 0x1981A04
	private void set_bomb_defender_born(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6640B0 Offset: 0x6640B0 VA: 0x6640B0
	// RVA: 0x1981A0C Offset: 0x1981A0C VA: 0x1981A0C
	public int[] get_bomb_target_zone() { }

	[CompilerGeneratedAttribute] // RVA: 0x6640C0 Offset: 0x6640C0 VA: 0x6640C0
	// RVA: 0x1981A14 Offset: 0x1981A14 VA: 0x1981A14
	private void set_bomb_target_zone(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6640D0 Offset: 0x6640D0 VA: 0x6640D0
	// RVA: 0x1981A1C Offset: 0x1981A1C VA: 0x1981A1C
	public string[] get_bomb_defender_born_ui_maps() { }

	[CompilerGeneratedAttribute] // RVA: 0x6640E0 Offset: 0x6640E0 VA: 0x6640E0
	// RVA: 0x1981A24 Offset: 0x1981A24 VA: 0x1981A24
	private void set_bomb_defender_born_ui_maps(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6640F0 Offset: 0x6640F0 VA: 0x6640F0
	// RVA: 0x1981A2C Offset: 0x1981A2C VA: 0x1981A2C
	public string[] get_sound_banks() { }

	[CompilerGeneratedAttribute] // RVA: 0x664100 Offset: 0x664100 VA: 0x664100
	// RVA: 0x1981A34 Offset: 0x1981A34 VA: 0x1981A34
	private void set_sound_banks(string[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664110 Offset: 0x664110 VA: 0x664110
	// RVA: 0x1981A3C Offset: 0x1981A3C VA: 0x1981A3C
	public int[] get_preload_particle_id_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x664120 Offset: 0x664120 VA: 0x664120
	// RVA: 0x1981A44 Offset: 0x1981A44 VA: 0x1981A44
	private void set_preload_particle_id_array(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664130 Offset: 0x664130 VA: 0x664130
	// RVA: 0x1981A4C Offset: 0x1981A4C VA: 0x1981A4C
	public string get_floor_json() { }

	[CompilerGeneratedAttribute] // RVA: 0x664140 Offset: 0x664140 VA: 0x664140
	// RVA: 0x1981A54 Offset: 0x1981A54 VA: 0x1981A54
	private void set_floor_json(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x664150 Offset: 0x664150 VA: 0x664150
	// RVA: 0x1981A5C Offset: 0x1981A5C VA: 0x1981A5C
	public float get_floor_sound_threshold() { }

	[CompilerGeneratedAttribute] // RVA: 0x664160 Offset: 0x664160 VA: 0x664160
	// RVA: 0x1981A64 Offset: 0x1981A64 VA: 0x1981A64
	private void set_floor_sound_threshold(float value) { }

	// RVA: 0x19816AC Offset: 0x19816AC VA: 0x19816AC
	internal void .ctor(MemoryStream reader, Action<maps_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x197E3C4 Offset: 0x197E3C4 VA: 0x197E3C4
	internal static bool SetupReadActions(Field[] fields, Action<maps_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1981A74 Offset: 0x1981A74 VA: 0x1981A74 Slot: 4
	public object Clone() { }
}
