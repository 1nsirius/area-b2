// Namespace: 
public class wp_sniper_table.Record : ICloneable // TypeDefIndex: 10884
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x573584 Offset: 0x573584 VA: 0x573584
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x573594 Offset: 0x573594 VA: 0x573594
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5735A4 Offset: 0x5735A4 VA: 0x5735A4
	private int <gun_data_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5735B4 Offset: 0x5735B4 VA: 0x5735B4
	private float <sight_aim_in_duration>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5735C4 Offset: 0x5735C4 VA: 0x5735C4
	private float <sight_aim_out_duration>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x5735D4 Offset: 0x5735D4 VA: 0x5735D4
	private float <sight_fov>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x5735E4 Offset: 0x5735E4 VA: 0x5735E4
	private float <puton_sight_duration>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x5735F4 Offset: 0x5735F4 VA: 0x5735F4
	private float <putdown_sight_duration>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x573604 Offset: 0x573604 VA: 0x573604
	private float <put_sight_time_coefficient>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x573614 Offset: 0x573614 VA: 0x573614
	private string <p1_tool_sight_animation_path>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x573624 Offset: 0x573624 VA: 0x573624
	private string <p3_tool_sight_animation_path>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x573634 Offset: 0x573634 VA: 0x573634
	private string <p1_char_sight_animation_path>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x573644 Offset: 0x573644 VA: 0x573644
	private string <p3_char_sight_animation_path>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x573654 Offset: 0x573654 VA: 0x573654
	private int <sight_sound_action>k__BackingField; // 0x3C

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int gun_data_index { get; set; }
	public float sight_aim_in_duration { get; set; }
	public float sight_aim_out_duration { get; set; }
	public float sight_fov { get; set; }
	public float puton_sight_duration { get; set; }
	public float putdown_sight_duration { get; set; }
	public float put_sight_time_coefficient { get; set; }
	public string p1_tool_sight_animation_path { get; set; }
	public string p3_tool_sight_animation_path { get; set; }
	public string p1_char_sight_animation_path { get; set; }
	public string p3_char_sight_animation_path { get; set; }
	public int sight_sound_action { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667670 Offset: 0x667670 VA: 0x667670
	// RVA: 0x1034804 Offset: 0x1034804 VA: 0x1034804
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x667680 Offset: 0x667680 VA: 0x667680
	// RVA: 0x103480C Offset: 0x103480C VA: 0x103480C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667690 Offset: 0x667690 VA: 0x667690
	// RVA: 0x1034814 Offset: 0x1034814 VA: 0x1034814
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x6676A0 Offset: 0x6676A0 VA: 0x6676A0
	// RVA: 0x103481C Offset: 0x103481C VA: 0x103481C
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6676B0 Offset: 0x6676B0 VA: 0x6676B0
	// RVA: 0x1034824 Offset: 0x1034824 VA: 0x1034824
	public int get_gun_data_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x6676C0 Offset: 0x6676C0 VA: 0x6676C0
	// RVA: 0x103482C Offset: 0x103482C VA: 0x103482C
	private void set_gun_data_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6676D0 Offset: 0x6676D0 VA: 0x6676D0
	// RVA: 0x1034834 Offset: 0x1034834 VA: 0x1034834
	public float get_sight_aim_in_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x6676E0 Offset: 0x6676E0 VA: 0x6676E0
	// RVA: 0x103483C Offset: 0x103483C VA: 0x103483C
	private void set_sight_aim_in_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6676F0 Offset: 0x6676F0 VA: 0x6676F0
	// RVA: 0x1034844 Offset: 0x1034844 VA: 0x1034844
	public float get_sight_aim_out_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x667700 Offset: 0x667700 VA: 0x667700
	// RVA: 0x103484C Offset: 0x103484C VA: 0x103484C
	private void set_sight_aim_out_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667710 Offset: 0x667710 VA: 0x667710
	// RVA: 0x1034854 Offset: 0x1034854 VA: 0x1034854
	public float get_sight_fov() { }

	[CompilerGeneratedAttribute] // RVA: 0x667720 Offset: 0x667720 VA: 0x667720
	// RVA: 0x103485C Offset: 0x103485C VA: 0x103485C
	private void set_sight_fov(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667730 Offset: 0x667730 VA: 0x667730
	// RVA: 0x1034864 Offset: 0x1034864 VA: 0x1034864
	public float get_puton_sight_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x667740 Offset: 0x667740 VA: 0x667740
	// RVA: 0x103486C Offset: 0x103486C VA: 0x103486C
	private void set_puton_sight_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667750 Offset: 0x667750 VA: 0x667750
	// RVA: 0x1034874 Offset: 0x1034874 VA: 0x1034874
	public float get_putdown_sight_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x667760 Offset: 0x667760 VA: 0x667760
	// RVA: 0x103487C Offset: 0x103487C VA: 0x103487C
	private void set_putdown_sight_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667770 Offset: 0x667770 VA: 0x667770
	// RVA: 0x1034884 Offset: 0x1034884 VA: 0x1034884
	public float get_put_sight_time_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x667780 Offset: 0x667780 VA: 0x667780
	// RVA: 0x103488C Offset: 0x103488C VA: 0x103488C
	private void set_put_sight_time_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667790 Offset: 0x667790 VA: 0x667790
	// RVA: 0x1034894 Offset: 0x1034894 VA: 0x1034894
	public string get_p1_tool_sight_animation_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6677A0 Offset: 0x6677A0 VA: 0x6677A0
	// RVA: 0x103489C Offset: 0x103489C VA: 0x103489C
	private void set_p1_tool_sight_animation_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6677B0 Offset: 0x6677B0 VA: 0x6677B0
	// RVA: 0x10348A4 Offset: 0x10348A4 VA: 0x10348A4
	public string get_p3_tool_sight_animation_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6677C0 Offset: 0x6677C0 VA: 0x6677C0
	// RVA: 0x10348AC Offset: 0x10348AC VA: 0x10348AC
	private void set_p3_tool_sight_animation_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6677D0 Offset: 0x6677D0 VA: 0x6677D0
	// RVA: 0x10348B4 Offset: 0x10348B4 VA: 0x10348B4
	public string get_p1_char_sight_animation_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6677E0 Offset: 0x6677E0 VA: 0x6677E0
	// RVA: 0x10348BC Offset: 0x10348BC VA: 0x10348BC
	private void set_p1_char_sight_animation_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6677F0 Offset: 0x6677F0 VA: 0x6677F0
	// RVA: 0x10348C4 Offset: 0x10348C4 VA: 0x10348C4
	public string get_p3_char_sight_animation_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x667800 Offset: 0x667800 VA: 0x667800
	// RVA: 0x10348CC Offset: 0x10348CC VA: 0x10348CC
	private void set_p3_char_sight_animation_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x667810 Offset: 0x667810 VA: 0x667810
	// RVA: 0x10348D4 Offset: 0x10348D4 VA: 0x10348D4
	public int get_sight_sound_action() { }

	[CompilerGeneratedAttribute] // RVA: 0x667820 Offset: 0x667820 VA: 0x667820
	// RVA: 0x10348DC Offset: 0x10348DC VA: 0x10348DC
	private void set_sight_sound_action(int value) { }

	// RVA: 0x1034604 Offset: 0x1034604 VA: 0x1034604
	internal void .ctor(MemoryStream reader, Action<wp_sniper_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1032A24 Offset: 0x1032A24 VA: 0x1032A24
	internal static bool SetupReadActions(Field[] fields, Action<wp_sniper_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x10348EC Offset: 0x10348EC VA: 0x10348EC Slot: 4
	public object Clone() { }
}
