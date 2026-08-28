// Namespace: 
public class weapon_table.Record : ICloneable // TypeDefIndex: 10860
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5732A4 Offset: 0x5732A4 VA: 0x5732A4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5732B4 Offset: 0x5732B4 VA: 0x5732B4
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5732C4 Offset: 0x5732C4 VA: 0x5732C4
	private int <name_lang_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5732D4 Offset: 0x5732D4 VA: 0x5732D4
	private int <type>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5732E4 Offset: 0x5732E4 VA: 0x5732E4
	private string <icon>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x5732F4 Offset: 0x5732F4 VA: 0x5732F4
	private string <icon_3d>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x573304 Offset: 0x573304 VA: 0x573304
	private int <default_sight>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x573314 Offset: 0x573314 VA: 0x573314
	private int <default_barrel>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x573324 Offset: 0x573324 VA: 0x573324
	private int <default_grip>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x573334 Offset: 0x573334 VA: 0x573334
	private int <default_under_barrel>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x573344 Offset: 0x573344 VA: 0x573344
	private float <switch_in_weapon_duration>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x573354 Offset: 0x573354 VA: 0x573354
	private float <switch_out_weapon_duration>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x573364 Offset: 0x573364 VA: 0x573364
	private float <switch_weapon_time_coefficient>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x573374 Offset: 0x573374 VA: 0x573374
	private int[] <sight>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x573384 Offset: 0x573384 VA: 0x573384
	private int[] <barrel>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x573394 Offset: 0x573394 VA: 0x573394
	private int[] <grip>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x5733A4 Offset: 0x5733A4 VA: 0x5733A4
	private int[] <under_barrel>k__BackingField; // 0x48

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int name_lang_index { get; set; }
	public int type { get; set; }
	public string icon { get; set; }
	public string icon_3d { get; set; }
	public int default_sight { get; set; }
	public int default_barrel { get; set; }
	public int default_grip { get; set; }
	public int default_under_barrel { get; set; }
	public float switch_in_weapon_duration { get; set; }
	public float switch_out_weapon_duration { get; set; }
	public float switch_weapon_time_coefficient { get; set; }
	public int[] sight { get; set; }
	public int[] barrel { get; set; }
	public int[] grip { get; set; }
	public int[] under_barrel { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6670B0 Offset: 0x6670B0 VA: 0x6670B0
	// RVA: 0x102C874 Offset: 0x102C874 VA: 0x102C874
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6670C0 Offset: 0x6670C0 VA: 0x6670C0
	// RVA: 0x102C87C Offset: 0x102C87C VA: 0x102C87C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6670D0 Offset: 0x6670D0 VA: 0x6670D0
	// RVA: 0x102C884 Offset: 0x102C884 VA: 0x102C884
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x6670E0 Offset: 0x6670E0 VA: 0x6670E0
	// RVA: 0x102C88C Offset: 0x102C88C VA: 0x102C88C
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6670F0 Offset: 0x6670F0 VA: 0x6670F0
	// RVA: 0x102C894 Offset: 0x102C894 VA: 0x102C894
	public int get_name_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x667100 Offset: 0x667100 VA: 0x667100
	// RVA: 0x102C89C Offset: 0x102C89C VA: 0x102C89C
	private void set_name_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667110 Offset: 0x667110 VA: 0x667110
	// RVA: 0x102C8A4 Offset: 0x102C8A4 VA: 0x102C8A4
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x667120 Offset: 0x667120 VA: 0x667120
	// RVA: 0x102C8AC Offset: 0x102C8AC VA: 0x102C8AC
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667130 Offset: 0x667130 VA: 0x667130
	// RVA: 0x102C8B4 Offset: 0x102C8B4 VA: 0x102C8B4
	public string get_icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x667140 Offset: 0x667140 VA: 0x667140
	// RVA: 0x102C8BC Offset: 0x102C8BC VA: 0x102C8BC
	private void set_icon(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667150 Offset: 0x667150 VA: 0x667150
	// RVA: 0x102C8C4 Offset: 0x102C8C4 VA: 0x102C8C4
	public string get_icon_3d() { }

	[CompilerGeneratedAttribute] // RVA: 0x667160 Offset: 0x667160 VA: 0x667160
	// RVA: 0x102C8CC Offset: 0x102C8CC VA: 0x102C8CC
	private void set_icon_3d(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667170 Offset: 0x667170 VA: 0x667170
	// RVA: 0x102C8D4 Offset: 0x102C8D4 VA: 0x102C8D4
	public int get_default_sight() { }

	[CompilerGeneratedAttribute] // RVA: 0x667180 Offset: 0x667180 VA: 0x667180
	// RVA: 0x102C8DC Offset: 0x102C8DC VA: 0x102C8DC
	private void set_default_sight(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667190 Offset: 0x667190 VA: 0x667190
	// RVA: 0x102C8E4 Offset: 0x102C8E4 VA: 0x102C8E4
	public int get_default_barrel() { }

	[CompilerGeneratedAttribute] // RVA: 0x6671A0 Offset: 0x6671A0 VA: 0x6671A0
	// RVA: 0x102C8EC Offset: 0x102C8EC VA: 0x102C8EC
	private void set_default_barrel(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6671B0 Offset: 0x6671B0 VA: 0x6671B0
	// RVA: 0x102C8F4 Offset: 0x102C8F4 VA: 0x102C8F4
	public int get_default_grip() { }

	[CompilerGeneratedAttribute] // RVA: 0x6671C0 Offset: 0x6671C0 VA: 0x6671C0
	// RVA: 0x102C8FC Offset: 0x102C8FC VA: 0x102C8FC
	private void set_default_grip(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6671D0 Offset: 0x6671D0 VA: 0x6671D0
	// RVA: 0x102C904 Offset: 0x102C904 VA: 0x102C904
	public int get_default_under_barrel() { }

	[CompilerGeneratedAttribute] // RVA: 0x6671E0 Offset: 0x6671E0 VA: 0x6671E0
	// RVA: 0x102C90C Offset: 0x102C90C VA: 0x102C90C
	private void set_default_under_barrel(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6671F0 Offset: 0x6671F0 VA: 0x6671F0
	// RVA: 0x102C914 Offset: 0x102C914 VA: 0x102C914
	public float get_switch_in_weapon_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x667200 Offset: 0x667200 VA: 0x667200
	// RVA: 0x102C91C Offset: 0x102C91C VA: 0x102C91C
	private void set_switch_in_weapon_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667210 Offset: 0x667210 VA: 0x667210
	// RVA: 0x102C924 Offset: 0x102C924 VA: 0x102C924
	public float get_switch_out_weapon_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x667220 Offset: 0x667220 VA: 0x667220
	// RVA: 0x102C92C Offset: 0x102C92C VA: 0x102C92C
	private void set_switch_out_weapon_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667230 Offset: 0x667230 VA: 0x667230
	// RVA: 0x102C934 Offset: 0x102C934 VA: 0x102C934
	public float get_switch_weapon_time_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x667240 Offset: 0x667240 VA: 0x667240
	// RVA: 0x102C93C Offset: 0x102C93C VA: 0x102C93C
	private void set_switch_weapon_time_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667250 Offset: 0x667250 VA: 0x667250
	// RVA: 0x102C944 Offset: 0x102C944 VA: 0x102C944
	public int[] get_sight() { }

	[CompilerGeneratedAttribute] // RVA: 0x667260 Offset: 0x667260 VA: 0x667260
	// RVA: 0x102C94C Offset: 0x102C94C VA: 0x102C94C
	private void set_sight(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667270 Offset: 0x667270 VA: 0x667270
	// RVA: 0x102C954 Offset: 0x102C954 VA: 0x102C954
	public int[] get_barrel() { }

	[CompilerGeneratedAttribute] // RVA: 0x667280 Offset: 0x667280 VA: 0x667280
	// RVA: 0x102C95C Offset: 0x102C95C VA: 0x102C95C
	private void set_barrel(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667290 Offset: 0x667290 VA: 0x667290
	// RVA: 0x102C964 Offset: 0x102C964 VA: 0x102C964
	public int[] get_grip() { }

	[CompilerGeneratedAttribute] // RVA: 0x6672A0 Offset: 0x6672A0 VA: 0x6672A0
	// RVA: 0x102C96C Offset: 0x102C96C VA: 0x102C96C
	private void set_grip(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6672B0 Offset: 0x6672B0 VA: 0x6672B0
	// RVA: 0x102C974 Offset: 0x102C974 VA: 0x102C974
	public int[] get_under_barrel() { }

	[CompilerGeneratedAttribute] // RVA: 0x6672C0 Offset: 0x6672C0 VA: 0x6672C0
	// RVA: 0x102C97C Offset: 0x102C97C VA: 0x102C97C
	private void set_under_barrel(int[] value) { }

	// RVA: 0x102C674 Offset: 0x102C674 VA: 0x102C674
	internal void .ctor(MemoryStream reader, Action<weapon_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x102A5EC Offset: 0x102A5EC VA: 0x102A5EC
	internal static bool SetupReadActions(Field[] fields, Action<weapon_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x102C98C Offset: 0x102C98C VA: 0x102C98C Slot: 4
	public object Clone() { }
}
