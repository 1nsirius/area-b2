// Namespace: 
public class effect_table.Record : ICloneable // TypeDefIndex: 10628
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570034 Offset: 0x570034 VA: 0x570034
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x570044 Offset: 0x570044 VA: 0x570044
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x570054 Offset: 0x570054 VA: 0x570054
	private float <trigger_last_time>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x570064 Offset: 0x570064 VA: 0x570064
	private float <trigger_frequency>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x570074 Offset: 0x570074 VA: 0x570074
	private int <effect>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x570084 Offset: 0x570084 VA: 0x570084
	private float <effect_value>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x570094 Offset: 0x570094 VA: 0x570094
	private int[] <effect_target>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x5700A4 Offset: 0x5700A4 VA: 0x5700A4
	private float <effect_time>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x5700B4 Offset: 0x5700B4 VA: 0x5700B4
	private float <effect_frequency>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x5700C4 Offset: 0x5700C4 VA: 0x5700C4
	private int <range_id>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x5700D4 Offset: 0x5700D4 VA: 0x5700D4
	private int[] <p1_particle_id>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x5700E4 Offset: 0x5700E4 VA: 0x5700E4
	private int[] <p3_particle_id>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x5700F4 Offset: 0x5700F4 VA: 0x5700F4
	private int[] <message_id>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x570104 Offset: 0x570104 VA: 0x570104
	private int <stack>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x570114 Offset: 0x570114 VA: 0x570114
	private int <state_group>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x570124 Offset: 0x570124 VA: 0x570124
	private int <group_stack>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x570134 Offset: 0x570134 VA: 0x570134
	private float <slope>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x570144 Offset: 0x570144 VA: 0x570144
	private int[] <start_remove_buff>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x570154 Offset: 0x570154 VA: 0x570154
	private int[] <start_add_buff>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x570164 Offset: 0x570164 VA: 0x570164
	private int[] <abremove_buff>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x570174 Offset: 0x570174 VA: 0x570174
	private int[] <abrecall_buff>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x570184 Offset: 0x570184 VA: 0x570184
	private int[] <remove_buff>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x570194 Offset: 0x570194 VA: 0x570194
	private int[] <recall_buff>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x5701A4 Offset: 0x5701A4 VA: 0x5701A4
	private string <info>k__BackingField; // 0x64

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public float trigger_last_time { get; set; }
	public float trigger_frequency { get; set; }
	public int effect { get; set; }
	public float effect_value { get; set; }
	public int[] effect_target { get; set; }
	public float effect_time { get; set; }
	public float effect_frequency { get; set; }
	public int range_id { get; set; }
	public int[] p1_particle_id { get; set; }
	public int[] p3_particle_id { get; set; }
	public int[] message_id { get; set; }
	public int stack { get; set; }
	public int state_group { get; set; }
	public int group_stack { get; set; }
	public float slope { get; set; }
	public int[] start_remove_buff { get; set; }
	public int[] start_add_buff { get; set; }
	public int[] abremove_buff { get; set; }
	public int[] abrecall_buff { get; set; }
	public int[] remove_buff { get; set; }
	public int[] recall_buff { get; set; }
	public string info { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660BD0 Offset: 0x660BD0 VA: 0x660BD0
	// RVA: 0x1E7442C Offset: 0x1E7442C VA: 0x1E7442C
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660BE0 Offset: 0x660BE0 VA: 0x660BE0
	// RVA: 0x1E74434 Offset: 0x1E74434 VA: 0x1E74434
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660BF0 Offset: 0x660BF0 VA: 0x660BF0
	// RVA: 0x1E7443C Offset: 0x1E7443C VA: 0x1E7443C
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x660C00 Offset: 0x660C00 VA: 0x660C00
	// RVA: 0x1E74444 Offset: 0x1E74444 VA: 0x1E74444
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660C10 Offset: 0x660C10 VA: 0x660C10
	// RVA: 0x1E7444C Offset: 0x1E7444C VA: 0x1E7444C
	public float get_trigger_last_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x660C20 Offset: 0x660C20 VA: 0x660C20
	// RVA: 0x1E74454 Offset: 0x1E74454 VA: 0x1E74454
	private void set_trigger_last_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660C30 Offset: 0x660C30 VA: 0x660C30
	// RVA: 0x1E7445C Offset: 0x1E7445C VA: 0x1E7445C
	public float get_trigger_frequency() { }

	[CompilerGeneratedAttribute] // RVA: 0x660C40 Offset: 0x660C40 VA: 0x660C40
	// RVA: 0x1E74464 Offset: 0x1E74464 VA: 0x1E74464
	private void set_trigger_frequency(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660C50 Offset: 0x660C50 VA: 0x660C50
	// RVA: 0x1E7446C Offset: 0x1E7446C VA: 0x1E7446C
	public int get_effect() { }

	[CompilerGeneratedAttribute] // RVA: 0x660C60 Offset: 0x660C60 VA: 0x660C60
	// RVA: 0x1E74474 Offset: 0x1E74474 VA: 0x1E74474
	private void set_effect(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660C70 Offset: 0x660C70 VA: 0x660C70
	// RVA: 0x1E7447C Offset: 0x1E7447C VA: 0x1E7447C
	public float get_effect_value() { }

	[CompilerGeneratedAttribute] // RVA: 0x660C80 Offset: 0x660C80 VA: 0x660C80
	// RVA: 0x1E74484 Offset: 0x1E74484 VA: 0x1E74484
	private void set_effect_value(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660C90 Offset: 0x660C90 VA: 0x660C90
	// RVA: 0x1E7448C Offset: 0x1E7448C VA: 0x1E7448C
	public int[] get_effect_target() { }

	[CompilerGeneratedAttribute] // RVA: 0x660CA0 Offset: 0x660CA0 VA: 0x660CA0
	// RVA: 0x1E74494 Offset: 0x1E74494 VA: 0x1E74494
	private void set_effect_target(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660CB0 Offset: 0x660CB0 VA: 0x660CB0
	// RVA: 0x1E7449C Offset: 0x1E7449C VA: 0x1E7449C
	public float get_effect_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x660CC0 Offset: 0x660CC0 VA: 0x660CC0
	// RVA: 0x1E744A4 Offset: 0x1E744A4 VA: 0x1E744A4
	private void set_effect_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660CD0 Offset: 0x660CD0 VA: 0x660CD0
	// RVA: 0x1E744AC Offset: 0x1E744AC VA: 0x1E744AC
	public float get_effect_frequency() { }

	[CompilerGeneratedAttribute] // RVA: 0x660CE0 Offset: 0x660CE0 VA: 0x660CE0
	// RVA: 0x1E744B4 Offset: 0x1E744B4 VA: 0x1E744B4
	private void set_effect_frequency(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660CF0 Offset: 0x660CF0 VA: 0x660CF0
	// RVA: 0x1E744BC Offset: 0x1E744BC VA: 0x1E744BC
	public int get_range_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660D00 Offset: 0x660D00 VA: 0x660D00
	// RVA: 0x1E744C4 Offset: 0x1E744C4 VA: 0x1E744C4
	private void set_range_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660D10 Offset: 0x660D10 VA: 0x660D10
	// RVA: 0x1E744CC Offset: 0x1E744CC VA: 0x1E744CC
	public int[] get_p1_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660D20 Offset: 0x660D20 VA: 0x660D20
	// RVA: 0x1E744D4 Offset: 0x1E744D4 VA: 0x1E744D4
	private void set_p1_particle_id(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660D30 Offset: 0x660D30 VA: 0x660D30
	// RVA: 0x1E744DC Offset: 0x1E744DC VA: 0x1E744DC
	public int[] get_p3_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660D40 Offset: 0x660D40 VA: 0x660D40
	// RVA: 0x1E744E4 Offset: 0x1E744E4 VA: 0x1E744E4
	private void set_p3_particle_id(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660D50 Offset: 0x660D50 VA: 0x660D50
	// RVA: 0x1E744EC Offset: 0x1E744EC VA: 0x1E744EC
	public int[] get_message_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660D60 Offset: 0x660D60 VA: 0x660D60
	// RVA: 0x1E744F4 Offset: 0x1E744F4 VA: 0x1E744F4
	private void set_message_id(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660D70 Offset: 0x660D70 VA: 0x660D70
	// RVA: 0x1E744FC Offset: 0x1E744FC VA: 0x1E744FC
	public int get_stack() { }

	[CompilerGeneratedAttribute] // RVA: 0x660D80 Offset: 0x660D80 VA: 0x660D80
	// RVA: 0x1E74504 Offset: 0x1E74504 VA: 0x1E74504
	private void set_stack(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660D90 Offset: 0x660D90 VA: 0x660D90
	// RVA: 0x1E7450C Offset: 0x1E7450C VA: 0x1E7450C
	public int get_state_group() { }

	[CompilerGeneratedAttribute] // RVA: 0x660DA0 Offset: 0x660DA0 VA: 0x660DA0
	// RVA: 0x1E74514 Offset: 0x1E74514 VA: 0x1E74514
	private void set_state_group(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660DB0 Offset: 0x660DB0 VA: 0x660DB0
	// RVA: 0x1E7451C Offset: 0x1E7451C VA: 0x1E7451C
	public int get_group_stack() { }

	[CompilerGeneratedAttribute] // RVA: 0x660DC0 Offset: 0x660DC0 VA: 0x660DC0
	// RVA: 0x1E74524 Offset: 0x1E74524 VA: 0x1E74524
	private void set_group_stack(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660DD0 Offset: 0x660DD0 VA: 0x660DD0
	// RVA: 0x1E7452C Offset: 0x1E7452C VA: 0x1E7452C
	public float get_slope() { }

	[CompilerGeneratedAttribute] // RVA: 0x660DE0 Offset: 0x660DE0 VA: 0x660DE0
	// RVA: 0x1E74534 Offset: 0x1E74534 VA: 0x1E74534
	private void set_slope(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660DF0 Offset: 0x660DF0 VA: 0x660DF0
	// RVA: 0x1E7453C Offset: 0x1E7453C VA: 0x1E7453C
	public int[] get_start_remove_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660E00 Offset: 0x660E00 VA: 0x660E00
	// RVA: 0x1E74544 Offset: 0x1E74544 VA: 0x1E74544
	private void set_start_remove_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660E10 Offset: 0x660E10 VA: 0x660E10
	// RVA: 0x1E7454C Offset: 0x1E7454C VA: 0x1E7454C
	public int[] get_start_add_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660E20 Offset: 0x660E20 VA: 0x660E20
	// RVA: 0x1E74554 Offset: 0x1E74554 VA: 0x1E74554
	private void set_start_add_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660E30 Offset: 0x660E30 VA: 0x660E30
	// RVA: 0x1E7455C Offset: 0x1E7455C VA: 0x1E7455C
	public int[] get_abremove_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660E40 Offset: 0x660E40 VA: 0x660E40
	// RVA: 0x1E74564 Offset: 0x1E74564 VA: 0x1E74564
	private void set_abremove_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660E50 Offset: 0x660E50 VA: 0x660E50
	// RVA: 0x1E7456C Offset: 0x1E7456C VA: 0x1E7456C
	public int[] get_abrecall_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660E60 Offset: 0x660E60 VA: 0x660E60
	// RVA: 0x1E74574 Offset: 0x1E74574 VA: 0x1E74574
	private void set_abrecall_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660E70 Offset: 0x660E70 VA: 0x660E70
	// RVA: 0x1E7457C Offset: 0x1E7457C VA: 0x1E7457C
	public int[] get_remove_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660E80 Offset: 0x660E80 VA: 0x660E80
	// RVA: 0x1E74584 Offset: 0x1E74584 VA: 0x1E74584
	private void set_remove_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660E90 Offset: 0x660E90 VA: 0x660E90
	// RVA: 0x1E7458C Offset: 0x1E7458C VA: 0x1E7458C
	public int[] get_recall_buff() { }

	[CompilerGeneratedAttribute] // RVA: 0x660EA0 Offset: 0x660EA0 VA: 0x660EA0
	// RVA: 0x1E74594 Offset: 0x1E74594 VA: 0x1E74594
	private void set_recall_buff(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660EB0 Offset: 0x660EB0 VA: 0x660EB0
	// RVA: 0x1E7459C Offset: 0x1E7459C VA: 0x1E7459C
	public string get_info() { }

	[CompilerGeneratedAttribute] // RVA: 0x660EC0 Offset: 0x660EC0 VA: 0x660EC0
	// RVA: 0x1E745A4 Offset: 0x1E745A4 VA: 0x1E745A4
	private void set_info(string value) { }

	// RVA: 0x1E7422C Offset: 0x1E7422C VA: 0x1E7422C
	internal void .ctor(MemoryStream reader, Action<effect_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E7163C Offset: 0x1E7163C VA: 0x1E7163C
	internal static bool SetupReadActions(Field[] fields, Action<effect_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E745B4 Offset: 0x1E745B4 VA: 0x1E745B4 Slot: 4
	public object Clone() { }
}
