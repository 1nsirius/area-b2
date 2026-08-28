// Namespace: 
public class battle_mode_table.Record : ICloneable // TypeDefIndex: 10540
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56ECD4 Offset: 0x56ECD4 VA: 0x56ECD4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56ECE4 Offset: 0x56ECE4 VA: 0x56ECE4
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56ECF4 Offset: 0x56ECF4 VA: 0x56ECF4
	private int <lang_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56ED04 Offset: 0x56ED04 VA: 0x56ED04
	private string <class_type>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56ED14 Offset: 0x56ED14 VA: 0x56ED14
	private int <choose_character_time>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56ED24 Offset: 0x56ED24 VA: 0x56ED24
	private int <prepare_time>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56ED34 Offset: 0x56ED34 VA: 0x56ED34
	private int <battle_time>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56ED44 Offset: 0x56ED44 VA: 0x56ED44
	private int <hold_on_time>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56ED54 Offset: 0x56ED54 VA: 0x56ED54
	private int <defuser_time>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56ED64 Offset: 0x56ED64 VA: 0x56ED64
	private int <allow_leave>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x56ED74 Offset: 0x56ED74 VA: 0x56ED74
	private int <allow_round_replay>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56ED84 Offset: 0x56ED84 VA: 0x56ED84
	private int <allow_region_selection_of_defender>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56ED94 Offset: 0x56ED94 VA: 0x56ED94
	private int <show_other_team_info>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x56EDA4 Offset: 0x56EDA4 VA: 0x56EDA4
	private int <allow_return_when_pre_battle>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56EDB4 Offset: 0x56EDB4 VA: 0x56EDB4
	private string <mode_choose_bg>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x56EDC4 Offset: 0x56EDC4 VA: 0x56EDC4
	private string <script>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x56EDD4 Offset: 0x56EDD4 VA: 0x56EDD4
	private int <infinite_item>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x56EDE4 Offset: 0x56EDE4 VA: 0x56EDE4
	private int <infinite_bullet>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x56EDF4 Offset: 0x56EDF4 VA: 0x56EDF4
	private int <reset_item>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x56EE04 Offset: 0x56EE04 VA: 0x56EE04
	private int <can_selected_in_room>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x56EE14 Offset: 0x56EE14 VA: 0x56EE14
	private int <select_available>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x56EE24 Offset: 0x56EE24 VA: 0x56EE24
	private int <select_weight>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x56EE34 Offset: 0x56EE34 VA: 0x56EE34
	private int[] <additional_skill>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x56EE44 Offset: 0x56EE44 VA: 0x56EE44
	private int[] <additional_skill_target>k__BackingField; // 0x64

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public int lang_index { get; set; }
	public string class_type { get; set; }
	public int choose_character_time { get; set; }
	public int prepare_time { get; set; }
	public int battle_time { get; set; }
	public int hold_on_time { get; set; }
	public int defuser_time { get; set; }
	public int allow_leave { get; set; }
	public int allow_round_replay { get; set; }
	public int allow_region_selection_of_defender { get; set; }
	public int show_other_team_info { get; set; }
	public int allow_return_when_pre_battle { get; set; }
	public string mode_choose_bg { get; set; }
	public string script { get; set; }
	public int infinite_item { get; set; }
	public int infinite_bullet { get; set; }
	public int reset_item { get; set; }
	public int can_selected_in_room { get; set; }
	public int select_available { get; set; }
	public int select_weight { get; set; }
	public int[] additional_skill { get; set; }
	public int[] additional_skill_target { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65E510 Offset: 0x65E510 VA: 0x65E510
	// RVA: 0x1E92324 Offset: 0x1E92324 VA: 0x1E92324
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E520 Offset: 0x65E520 VA: 0x65E520
	// RVA: 0x1E9232C Offset: 0x1E9232C VA: 0x1E9232C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E530 Offset: 0x65E530 VA: 0x65E530
	// RVA: 0x1E92334 Offset: 0x1E92334 VA: 0x1E92334
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E540 Offset: 0x65E540 VA: 0x65E540
	// RVA: 0x1E9233C Offset: 0x1E9233C VA: 0x1E9233C
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E550 Offset: 0x65E550 VA: 0x65E550
	// RVA: 0x1E92344 Offset: 0x1E92344 VA: 0x1E92344
	public int get_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E560 Offset: 0x65E560 VA: 0x65E560
	// RVA: 0x1E9234C Offset: 0x1E9234C VA: 0x1E9234C
	private void set_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E570 Offset: 0x65E570 VA: 0x65E570
	// RVA: 0x1E92354 Offset: 0x1E92354 VA: 0x1E92354
	public string get_class_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E580 Offset: 0x65E580 VA: 0x65E580
	// RVA: 0x1E9235C Offset: 0x1E9235C VA: 0x1E9235C
	private void set_class_type(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E590 Offset: 0x65E590 VA: 0x65E590
	// RVA: 0x1E92364 Offset: 0x1E92364 VA: 0x1E92364
	public int get_choose_character_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5A0 Offset: 0x65E5A0 VA: 0x65E5A0
	// RVA: 0x1E9236C Offset: 0x1E9236C VA: 0x1E9236C
	private void set_choose_character_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5B0 Offset: 0x65E5B0 VA: 0x65E5B0
	// RVA: 0x1E92374 Offset: 0x1E92374 VA: 0x1E92374
	public int get_prepare_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5C0 Offset: 0x65E5C0 VA: 0x65E5C0
	// RVA: 0x1E9237C Offset: 0x1E9237C VA: 0x1E9237C
	private void set_prepare_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5D0 Offset: 0x65E5D0 VA: 0x65E5D0
	// RVA: 0x1E92384 Offset: 0x1E92384 VA: 0x1E92384
	public int get_battle_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5E0 Offset: 0x65E5E0 VA: 0x65E5E0
	// RVA: 0x1E9238C Offset: 0x1E9238C VA: 0x1E9238C
	private void set_battle_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E5F0 Offset: 0x65E5F0 VA: 0x65E5F0
	// RVA: 0x1E92394 Offset: 0x1E92394 VA: 0x1E92394
	public int get_hold_on_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E600 Offset: 0x65E600 VA: 0x65E600
	// RVA: 0x1E9239C Offset: 0x1E9239C VA: 0x1E9239C
	private void set_hold_on_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E610 Offset: 0x65E610 VA: 0x65E610
	// RVA: 0x1E923A4 Offset: 0x1E923A4 VA: 0x1E923A4
	public int get_defuser_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E620 Offset: 0x65E620 VA: 0x65E620
	// RVA: 0x1E923AC Offset: 0x1E923AC VA: 0x1E923AC
	private void set_defuser_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E630 Offset: 0x65E630 VA: 0x65E630
	// RVA: 0x1E923B4 Offset: 0x1E923B4 VA: 0x1E923B4
	public int get_allow_leave() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E640 Offset: 0x65E640 VA: 0x65E640
	// RVA: 0x1E923BC Offset: 0x1E923BC VA: 0x1E923BC
	private void set_allow_leave(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E650 Offset: 0x65E650 VA: 0x65E650
	// RVA: 0x1E923C4 Offset: 0x1E923C4 VA: 0x1E923C4
	public int get_allow_round_replay() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E660 Offset: 0x65E660 VA: 0x65E660
	// RVA: 0x1E923CC Offset: 0x1E923CC VA: 0x1E923CC
	private void set_allow_round_replay(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E670 Offset: 0x65E670 VA: 0x65E670
	// RVA: 0x1E923D4 Offset: 0x1E923D4 VA: 0x1E923D4
	public int get_allow_region_selection_of_defender() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E680 Offset: 0x65E680 VA: 0x65E680
	// RVA: 0x1E923DC Offset: 0x1E923DC VA: 0x1E923DC
	private void set_allow_region_selection_of_defender(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E690 Offset: 0x65E690 VA: 0x65E690
	// RVA: 0x1E923E4 Offset: 0x1E923E4 VA: 0x1E923E4
	public int get_show_other_team_info() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6A0 Offset: 0x65E6A0 VA: 0x65E6A0
	// RVA: 0x1E923EC Offset: 0x1E923EC VA: 0x1E923EC
	private void set_show_other_team_info(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6B0 Offset: 0x65E6B0 VA: 0x65E6B0
	// RVA: 0x1E923F4 Offset: 0x1E923F4 VA: 0x1E923F4
	public int get_allow_return_when_pre_battle() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6C0 Offset: 0x65E6C0 VA: 0x65E6C0
	// RVA: 0x1E923FC Offset: 0x1E923FC VA: 0x1E923FC
	private void set_allow_return_when_pre_battle(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6D0 Offset: 0x65E6D0 VA: 0x65E6D0
	// RVA: 0x1E92404 Offset: 0x1E92404 VA: 0x1E92404
	public string get_mode_choose_bg() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6E0 Offset: 0x65E6E0 VA: 0x65E6E0
	// RVA: 0x1E9240C Offset: 0x1E9240C VA: 0x1E9240C
	private void set_mode_choose_bg(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E6F0 Offset: 0x65E6F0 VA: 0x65E6F0
	// RVA: 0x1E92414 Offset: 0x1E92414 VA: 0x1E92414
	public string get_script() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E700 Offset: 0x65E700 VA: 0x65E700
	// RVA: 0x1E9241C Offset: 0x1E9241C VA: 0x1E9241C
	private void set_script(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E710 Offset: 0x65E710 VA: 0x65E710
	// RVA: 0x1E92424 Offset: 0x1E92424 VA: 0x1E92424
	public int get_infinite_item() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E720 Offset: 0x65E720 VA: 0x65E720
	// RVA: 0x1E9242C Offset: 0x1E9242C VA: 0x1E9242C
	private void set_infinite_item(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E730 Offset: 0x65E730 VA: 0x65E730
	// RVA: 0x1E92434 Offset: 0x1E92434 VA: 0x1E92434
	public int get_infinite_bullet() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E740 Offset: 0x65E740 VA: 0x65E740
	// RVA: 0x1E9243C Offset: 0x1E9243C VA: 0x1E9243C
	private void set_infinite_bullet(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E750 Offset: 0x65E750 VA: 0x65E750
	// RVA: 0x1E92444 Offset: 0x1E92444 VA: 0x1E92444
	public int get_reset_item() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E760 Offset: 0x65E760 VA: 0x65E760
	// RVA: 0x1E9244C Offset: 0x1E9244C VA: 0x1E9244C
	private void set_reset_item(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E770 Offset: 0x65E770 VA: 0x65E770
	// RVA: 0x1E92454 Offset: 0x1E92454 VA: 0x1E92454
	public int get_can_selected_in_room() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E780 Offset: 0x65E780 VA: 0x65E780
	// RVA: 0x1E9245C Offset: 0x1E9245C VA: 0x1E9245C
	private void set_can_selected_in_room(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E790 Offset: 0x65E790 VA: 0x65E790
	// RVA: 0x1E92464 Offset: 0x1E92464 VA: 0x1E92464
	public int get_select_available() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7A0 Offset: 0x65E7A0 VA: 0x65E7A0
	// RVA: 0x1E9246C Offset: 0x1E9246C VA: 0x1E9246C
	private void set_select_available(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7B0 Offset: 0x65E7B0 VA: 0x65E7B0
	// RVA: 0x1E92474 Offset: 0x1E92474 VA: 0x1E92474
	public int get_select_weight() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7C0 Offset: 0x65E7C0 VA: 0x65E7C0
	// RVA: 0x1E9247C Offset: 0x1E9247C VA: 0x1E9247C
	private void set_select_weight(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7D0 Offset: 0x65E7D0 VA: 0x65E7D0
	// RVA: 0x1E92484 Offset: 0x1E92484 VA: 0x1E92484
	public int[] get_additional_skill() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7E0 Offset: 0x65E7E0 VA: 0x65E7E0
	// RVA: 0x1E9248C Offset: 0x1E9248C VA: 0x1E9248C
	private void set_additional_skill(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65E7F0 Offset: 0x65E7F0 VA: 0x65E7F0
	// RVA: 0x1E92494 Offset: 0x1E92494 VA: 0x1E92494
	public int[] get_additional_skill_target() { }

	[CompilerGeneratedAttribute] // RVA: 0x65E800 Offset: 0x65E800 VA: 0x65E800
	// RVA: 0x1E9249C Offset: 0x1E9249C VA: 0x1E9249C
	private void set_additional_skill_target(int[] value) { }

	// RVA: 0x1E92124 Offset: 0x1E92124 VA: 0x1E92124
	internal void .ctor(MemoryStream reader, Action<battle_mode_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E8F534 Offset: 0x1E8F534 VA: 0x1E8F534
	internal static bool SetupReadActions(Field[] fields, Action<battle_mode_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E924AC Offset: 0x1E924AC VA: 0x1E924AC Slot: 4
	public object Clone() { }
}
