// Namespace: 
public class gun_data_table.Record : ICloneable // TypeDefIndex: 10656
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x570694 Offset: 0x570694 VA: 0x570694
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5706A4 Offset: 0x5706A4 VA: 0x5706A4
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5706B4 Offset: 0x5706B4 VA: 0x5706B4
	private string <description>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5706C4 Offset: 0x5706C4 VA: 0x5706C4
	private int <desc_lang_index>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x5706D4 Offset: 0x5706D4 VA: 0x5706D4
	private int <type>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x5706E4 Offset: 0x5706E4 VA: 0x5706E4
	private int <bullet_type>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x5706F4 Offset: 0x5706F4 VA: 0x5706F4
	private int <a_number>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x570704 Offset: 0x570704 VA: 0x570704
	private int <ballistic>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x570714 Offset: 0x570714 VA: 0x570714
	private int <speed>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x570724 Offset: 0x570724 VA: 0x570724
	private int <damage_type>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x570734 Offset: 0x570734 VA: 0x570734
	private int <penetrability>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x570744 Offset: 0x570744 VA: 0x570744
	private float <fire_distance>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x570754 Offset: 0x570754 VA: 0x570754
	private float[] <damage_to_wall>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x570764 Offset: 0x570764 VA: 0x570764
	private float[] <damage_to_operator>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x570774 Offset: 0x570774 VA: 0x570774
	private float[] <damage_to_operator_suppressed>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x570784 Offset: 0x570784 VA: 0x570784
	private float[] <damage_to_operator_extended>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x570794 Offset: 0x570794 VA: 0x570794
	private int <fire_mode>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x5707A4 Offset: 0x5707A4 VA: 0x5707A4
	private int <rpm>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x5707B4 Offset: 0x5707B4 VA: 0x5707B4
	private float <cooldown>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x5707C4 Offset: 0x5707C4 VA: 0x5707C4
	private int <magazine_size>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x5707D4 Offset: 0x5707D4 VA: 0x5707D4
	private int <loading_type>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x5707E4 Offset: 0x5707E4 VA: 0x5707E4
	private int <maximum_ammunition>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x5707F4 Offset: 0x5707F4 VA: 0x5707F4
	private int <chamber>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x570804 Offset: 0x570804 VA: 0x570804
	private int <roof_type>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x570814 Offset: 0x570814 VA: 0x570814
	private float <pump_loaded_pre>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x570824 Offset: 0x570824 VA: 0x570824
	private float <pump_loaded_after>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x570834 Offset: 0x570834 VA: 0x570834
	private float <reload_pre>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x570844 Offset: 0x570844 VA: 0x570844
	private float <reload_after>k__BackingField; // 0x74
	[CompilerGeneratedAttribute] // RVA: 0x570854 Offset: 0x570854 VA: 0x570854
	private float <empty_reload_pre>k__BackingField; // 0x78
	[CompilerGeneratedAttribute] // RVA: 0x570864 Offset: 0x570864 VA: 0x570864
	private float <empty_reload_after>k__BackingField; // 0x7C
	[CompilerGeneratedAttribute] // RVA: 0x570874 Offset: 0x570874 VA: 0x570874
	private float <first_bullet_after>k__BackingField; // 0x80
	[CompilerGeneratedAttribute] // RVA: 0x570884 Offset: 0x570884 VA: 0x570884
	private float <bullet_time>k__BackingField; // 0x84
	[CompilerGeneratedAttribute] // RVA: 0x570894 Offset: 0x570894 VA: 0x570894
	private float <bullet_time_after>k__BackingField; // 0x88
	[CompilerGeneratedAttribute] // RVA: 0x5708A4 Offset: 0x5708A4 VA: 0x5708A4
	private float <reload_time_coefficient>k__BackingField; // 0x8C
	[CompilerGeneratedAttribute] // RVA: 0x5708B4 Offset: 0x5708B4 VA: 0x5708B4
	private int <can_aim>k__BackingField; // 0x90
	[CompilerGeneratedAttribute] // RVA: 0x5708C4 Offset: 0x5708C4 VA: 0x5708C4
	private float <aim_in_duration_base>k__BackingField; // 0x94
	[CompilerGeneratedAttribute] // RVA: 0x5708D4 Offset: 0x5708D4 VA: 0x5708D4
	private float <aim_out_duration_base>k__BackingField; // 0x98
	[CompilerGeneratedAttribute] // RVA: 0x5708E4 Offset: 0x5708E4 VA: 0x5708E4
	private float <aim_in_duration_coefficient>k__BackingField; // 0x9C
	[CompilerGeneratedAttribute] // RVA: 0x5708F4 Offset: 0x5708F4 VA: 0x5708F4
	private float <aim_out_duration_coefficient>k__BackingField; // 0xA0
	[CompilerGeneratedAttribute] // RVA: 0x570904 Offset: 0x570904 VA: 0x570904
	private float <aim_in_duration>k__BackingField; // 0xA4
	[CompilerGeneratedAttribute] // RVA: 0x570914 Offset: 0x570914 VA: 0x570914
	private float <aim_out_duration>k__BackingField; // 0xA8
	[CompilerGeneratedAttribute] // RVA: 0x570924 Offset: 0x570924 VA: 0x570924
	private float <aim_multiplying_power>k__BackingField; // 0xAC
	[CompilerGeneratedAttribute] // RVA: 0x570934 Offset: 0x570934 VA: 0x570934
	private float <first_recoil_change_euler_range_y_min>k__BackingField; // 0xB0
	[CompilerGeneratedAttribute] // RVA: 0x570944 Offset: 0x570944 VA: 0x570944
	private float <first_recoil_change_euler_range_y_max>k__BackingField; // 0xB4
	[CompilerGeneratedAttribute] // RVA: 0x570954 Offset: 0x570954 VA: 0x570954
	private float <recoil_change_euler_range_y_min>k__BackingField; // 0xB8
	[CompilerGeneratedAttribute] // RVA: 0x570964 Offset: 0x570964 VA: 0x570964
	private float <recoil_change_euler_range_y_max>k__BackingField; // 0xBC
	[CompilerGeneratedAttribute] // RVA: 0x570974 Offset: 0x570974 VA: 0x570974
	private float <first_recoil_change_euler_range_x_min>k__BackingField; // 0xC0
	[CompilerGeneratedAttribute] // RVA: 0x570984 Offset: 0x570984 VA: 0x570984
	private float <first_recoil_change_euler_range_x_max>k__BackingField; // 0xC4
	[CompilerGeneratedAttribute] // RVA: 0x570994 Offset: 0x570994 VA: 0x570994
	private float <recoil_change_euler_range_x_min>k__BackingField; // 0xC8
	[CompilerGeneratedAttribute] // RVA: 0x5709A4 Offset: 0x5709A4 VA: 0x5709A4
	private float <recoil_change_euler_range_x_max>k__BackingField; // 0xCC
	[CompilerGeneratedAttribute] // RVA: 0x5709B4 Offset: 0x5709B4 VA: 0x5709B4
	private float <cehuashuju1>k__BackingField; // 0xD0
	[CompilerGeneratedAttribute] // RVA: 0x5709C4 Offset: 0x5709C4 VA: 0x5709C4
	private float <recoil_coefficient>k__BackingField; // 0xD4
	[CompilerGeneratedAttribute] // RVA: 0x5709D4 Offset: 0x5709D4 VA: 0x5709D4
	private float <recoil_y_limit>k__BackingField; // 0xD8
	[CompilerGeneratedAttribute] // RVA: 0x5709E4 Offset: 0x5709E4 VA: 0x5709E4
	private float <recoil_x_limit>k__BackingField; // 0xDC
	[CompilerGeneratedAttribute] // RVA: 0x5709F4 Offset: 0x5709F4 VA: 0x5709F4
	private float[] <recoil_change_euler_range_y_min_array>k__BackingField; // 0xE0
	[CompilerGeneratedAttribute] // RVA: 0x570A04 Offset: 0x570A04 VA: 0x570A04
	private float[] <recoil_change_euler_range_y_max_array>k__BackingField; // 0xE4
	[CompilerGeneratedAttribute] // RVA: 0x570A14 Offset: 0x570A14 VA: 0x570A14
	private float[] <recoil_change_euler_range_x_min_array>k__BackingField; // 0xE8
	[CompilerGeneratedAttribute] // RVA: 0x570A24 Offset: 0x570A24 VA: 0x570A24
	private float[] <recoil_change_euler_range_x_max_array>k__BackingField; // 0xEC
	[CompilerGeneratedAttribute] // RVA: 0x570A34 Offset: 0x570A34 VA: 0x570A34
	private int <recoil_display>k__BackingField; // 0xF0
	[CompilerGeneratedAttribute] // RVA: 0x570A44 Offset: 0x570A44 VA: 0x570A44
	private float <recoil_add_variation_time>k__BackingField; // 0xF4
	[CompilerGeneratedAttribute] // RVA: 0x570A54 Offset: 0x570A54 VA: 0x570A54
	private float <recoil_recover_variation_time>k__BackingField; // 0xF8
	[CompilerGeneratedAttribute] // RVA: 0x570A64 Offset: 0x570A64 VA: 0x570A64
	private float <aim_waggle_degree>k__BackingField; // 0xFC
	[CompilerGeneratedAttribute] // RVA: 0x570A74 Offset: 0x570A74 VA: 0x570A74
	private float <cehuashuju2>k__BackingField; // 0x100
	[CompilerGeneratedAttribute] // RVA: 0x570A84 Offset: 0x570A84 VA: 0x570A84
	private float <scatter_base_degree>k__BackingField; // 0x104
	[CompilerGeneratedAttribute] // RVA: 0x570A94 Offset: 0x570A94 VA: 0x570A94
	private float <scatter_crouch_coefficient>k__BackingField; // 0x108
	[CompilerGeneratedAttribute] // RVA: 0x570AA4 Offset: 0x570AA4 VA: 0x570AA4
	private float <scatter_creep_coefficient>k__BackingField; // 0x10C
	[CompilerGeneratedAttribute] // RVA: 0x570AB4 Offset: 0x570AB4 VA: 0x570AB4
	private float <cehuashuju3>k__BackingField; // 0x110
	[CompilerGeneratedAttribute] // RVA: 0x570AC4 Offset: 0x570AC4 VA: 0x570AC4
	private float <scatter_fire_coefficient>k__BackingField; // 0x114
	[CompilerGeneratedAttribute] // RVA: 0x570AD4 Offset: 0x570AD4 VA: 0x570AD4
	private float <scatter_max_fire_degree>k__BackingField; // 0x118
	[CompilerGeneratedAttribute] // RVA: 0x570AE4 Offset: 0x570AE4 VA: 0x570AE4
	private float <scatter_speed_coefficient>k__BackingField; // 0x11C
	[CompilerGeneratedAttribute] // RVA: 0x570AF4 Offset: 0x570AF4 VA: 0x570AF4
	private float <moving_scatter_max>k__BackingField; // 0x120
	[CompilerGeneratedAttribute] // RVA: 0x570B04 Offset: 0x570B04 VA: 0x570B04
	private float <scatter_fire_variation_duration>k__BackingField; // 0x124
	[CompilerGeneratedAttribute] // RVA: 0x570B14 Offset: 0x570B14 VA: 0x570B14
	private float <scatter_decrease_value>k__BackingField; // 0x128
	[CompilerGeneratedAttribute] // RVA: 0x570B24 Offset: 0x570B24 VA: 0x570B24
	private int <basic_scatter_fire_in_center>k__BackingField; // 0x12C
	[CompilerGeneratedAttribute] // RVA: 0x570B34 Offset: 0x570B34 VA: 0x570B34
	private int <aim_process_fire>k__BackingField; // 0x130
	[CompilerGeneratedAttribute] // RVA: 0x570B44 Offset: 0x570B44 VA: 0x570B44
	private int <weapon_fire_particle_p1>k__BackingField; // 0x134
	[CompilerGeneratedAttribute] // RVA: 0x570B54 Offset: 0x570B54 VA: 0x570B54
	private int <weapon_aiming_fire_particle_p1>k__BackingField; // 0x138
	[CompilerGeneratedAttribute] // RVA: 0x570B64 Offset: 0x570B64 VA: 0x570B64
	private int <weapon_smoke_particle_p1>k__BackingField; // 0x13C
	[CompilerGeneratedAttribute] // RVA: 0x570B74 Offset: 0x570B74 VA: 0x570B74
	private int <weapon_fire_particle_p3>k__BackingField; // 0x140
	[CompilerGeneratedAttribute] // RVA: 0x570B84 Offset: 0x570B84 VA: 0x570B84
	private int <weapon_smoke_particle_p3>k__BackingField; // 0x144
	[CompilerGeneratedAttribute] // RVA: 0x570B94 Offset: 0x570B94 VA: 0x570B94
	private int <weapon_bullet_particle>k__BackingField; // 0x148
	[CompilerGeneratedAttribute] // RVA: 0x570BA4 Offset: 0x570BA4 VA: 0x570BA4
	private float[] <weapon_bullet_particle_position>k__BackingField; // 0x14C
	[CompilerGeneratedAttribute] // RVA: 0x570BB4 Offset: 0x570BB4 VA: 0x570BB4
	private float[] <weapon_bullet_particle_rotation>k__BackingField; // 0x150
	[CompilerGeneratedAttribute] // RVA: 0x570BC4 Offset: 0x570BC4 VA: 0x570BC4
	private string <fire_loop_sound_p1>k__BackingField; // 0x154
	[CompilerGeneratedAttribute] // RVA: 0x570BD4 Offset: 0x570BD4 VA: 0x570BD4
	private string <fire_tail_sound_p1>k__BackingField; // 0x158
	[CompilerGeneratedAttribute] // RVA: 0x570BE4 Offset: 0x570BE4 VA: 0x570BE4
	private string <fire_loop_sound_p3>k__BackingField; // 0x15C
	[CompilerGeneratedAttribute] // RVA: 0x570BF4 Offset: 0x570BF4 VA: 0x570BF4
	private string <fire_tail_sound_p3>k__BackingField; // 0x160
	[CompilerGeneratedAttribute] // RVA: 0x570C04 Offset: 0x570C04 VA: 0x570C04
	private int <dont_show_gunline>k__BackingField; // 0x164

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public string description { get; set; }
	public int desc_lang_index { get; set; }
	public int type { get; set; }
	public int bullet_type { get; set; }
	public int a_number { get; set; }
	public int ballistic { get; set; }
	public int speed { get; set; }
	public int damage_type { get; set; }
	public int penetrability { get; set; }
	public float fire_distance { get; set; }
	public float[] damage_to_wall { get; set; }
	public float[] damage_to_operator { get; set; }
	public float[] damage_to_operator_suppressed { get; set; }
	public float[] damage_to_operator_extended { get; set; }
	public int fire_mode { get; set; }
	public int rpm { get; set; }
	public float cooldown { get; set; }
	public int magazine_size { get; set; }
	public int loading_type { get; set; }
	public int maximum_ammunition { get; set; }
	public int chamber { get; set; }
	public int roof_type { get; set; }
	public float pump_loaded_pre { get; set; }
	public float pump_loaded_after { get; set; }
	public float reload_pre { get; set; }
	public float reload_after { get; set; }
	public float empty_reload_pre { get; set; }
	public float empty_reload_after { get; set; }
	public float first_bullet_after { get; set; }
	public float bullet_time { get; set; }
	public float bullet_time_after { get; set; }
	public float reload_time_coefficient { get; set; }
	public int can_aim { get; set; }
	public float aim_in_duration_base { get; set; }
	public float aim_out_duration_base { get; set; }
	public float aim_in_duration_coefficient { get; set; }
	public float aim_out_duration_coefficient { get; set; }
	public float aim_in_duration { get; set; }
	public float aim_out_duration { get; set; }
	public float aim_multiplying_power { get; set; }
	public float first_recoil_change_euler_range_y_min { get; set; }
	public float first_recoil_change_euler_range_y_max { get; set; }
	public float recoil_change_euler_range_y_min { get; set; }
	public float recoil_change_euler_range_y_max { get; set; }
	public float first_recoil_change_euler_range_x_min { get; set; }
	public float first_recoil_change_euler_range_x_max { get; set; }
	public float recoil_change_euler_range_x_min { get; set; }
	public float recoil_change_euler_range_x_max { get; set; }
	public float cehuashuju1 { get; set; }
	public float recoil_coefficient { get; set; }
	public float recoil_y_limit { get; set; }
	public float recoil_x_limit { get; set; }
	public float[] recoil_change_euler_range_y_min_array { get; set; }
	public float[] recoil_change_euler_range_y_max_array { get; set; }
	public float[] recoil_change_euler_range_x_min_array { get; set; }
	public float[] recoil_change_euler_range_x_max_array { get; set; }
	public int recoil_display { get; set; }
	public float recoil_add_variation_time { get; set; }
	public float recoil_recover_variation_time { get; set; }
	public float aim_waggle_degree { get; set; }
	public float cehuashuju2 { get; set; }
	public float scatter_base_degree { get; set; }
	public float scatter_crouch_coefficient { get; set; }
	public float scatter_creep_coefficient { get; set; }
	public float cehuashuju3 { get; set; }
	public float scatter_fire_coefficient { get; set; }
	public float scatter_max_fire_degree { get; set; }
	public float scatter_speed_coefficient { get; set; }
	public float moving_scatter_max { get; set; }
	public float scatter_fire_variation_duration { get; set; }
	public float scatter_decrease_value { get; set; }
	public int basic_scatter_fire_in_center { get; set; }
	public int aim_process_fire { get; set; }
	public int weapon_fire_particle_p1 { get; set; }
	public int weapon_aiming_fire_particle_p1 { get; set; }
	public int weapon_smoke_particle_p1 { get; set; }
	public int weapon_fire_particle_p3 { get; set; }
	public int weapon_smoke_particle_p3 { get; set; }
	public int weapon_bullet_particle { get; set; }
	public float[] weapon_bullet_particle_position { get; set; }
	public float[] weapon_bullet_particle_rotation { get; set; }
	public string fire_loop_sound_p1 { get; set; }
	public string fire_tail_sound_p1 { get; set; }
	public string fire_loop_sound_p3 { get; set; }
	public string fire_tail_sound_p3 { get; set; }
	public int dont_show_gunline { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x661890 Offset: 0x661890 VA: 0x661890
	// RVA: 0x1C7C078 Offset: 0x1C7C078 VA: 0x1C7C078
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6618A0 Offset: 0x6618A0 VA: 0x6618A0
	// RVA: 0x1C7C080 Offset: 0x1C7C080 VA: 0x1C7C080
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6618B0 Offset: 0x6618B0 VA: 0x6618B0
	// RVA: 0x1C7C088 Offset: 0x1C7C088 VA: 0x1C7C088
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x6618C0 Offset: 0x6618C0 VA: 0x6618C0
	// RVA: 0x1C7C090 Offset: 0x1C7C090 VA: 0x1C7C090
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6618D0 Offset: 0x6618D0 VA: 0x6618D0
	// RVA: 0x1C7C098 Offset: 0x1C7C098 VA: 0x1C7C098
	public string get_description() { }

	[CompilerGeneratedAttribute] // RVA: 0x6618E0 Offset: 0x6618E0 VA: 0x6618E0
	// RVA: 0x1C7C0A0 Offset: 0x1C7C0A0 VA: 0x1C7C0A0
	private void set_description(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6618F0 Offset: 0x6618F0 VA: 0x6618F0
	// RVA: 0x1C7C0A8 Offset: 0x1C7C0A8 VA: 0x1C7C0A8
	public int get_desc_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x661900 Offset: 0x661900 VA: 0x661900
	// RVA: 0x1C7C0B0 Offset: 0x1C7C0B0 VA: 0x1C7C0B0
	private void set_desc_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661910 Offset: 0x661910 VA: 0x661910
	// RVA: 0x1C7C0B8 Offset: 0x1C7C0B8 VA: 0x1C7C0B8
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x661920 Offset: 0x661920 VA: 0x661920
	// RVA: 0x1C7C0C0 Offset: 0x1C7C0C0 VA: 0x1C7C0C0
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661930 Offset: 0x661930 VA: 0x661930
	// RVA: 0x1C7C0C8 Offset: 0x1C7C0C8 VA: 0x1C7C0C8
	public int get_bullet_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x661940 Offset: 0x661940 VA: 0x661940
	// RVA: 0x1C7C0D0 Offset: 0x1C7C0D0 VA: 0x1C7C0D0
	private void set_bullet_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661950 Offset: 0x661950 VA: 0x661950
	// RVA: 0x1C7C0D8 Offset: 0x1C7C0D8 VA: 0x1C7C0D8
	public int get_a_number() { }

	[CompilerGeneratedAttribute] // RVA: 0x661960 Offset: 0x661960 VA: 0x661960
	// RVA: 0x1C7C0E0 Offset: 0x1C7C0E0 VA: 0x1C7C0E0
	private void set_a_number(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661970 Offset: 0x661970 VA: 0x661970
	// RVA: 0x1C7C0E8 Offset: 0x1C7C0E8 VA: 0x1C7C0E8
	public int get_ballistic() { }

	[CompilerGeneratedAttribute] // RVA: 0x661980 Offset: 0x661980 VA: 0x661980
	// RVA: 0x1C7C0F0 Offset: 0x1C7C0F0 VA: 0x1C7C0F0
	private void set_ballistic(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661990 Offset: 0x661990 VA: 0x661990
	// RVA: 0x1C7C0F8 Offset: 0x1C7C0F8 VA: 0x1C7C0F8
	public int get_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6619A0 Offset: 0x6619A0 VA: 0x6619A0
	// RVA: 0x1C7C100 Offset: 0x1C7C100 VA: 0x1C7C100
	private void set_speed(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6619B0 Offset: 0x6619B0 VA: 0x6619B0
	// RVA: 0x1C7C108 Offset: 0x1C7C108 VA: 0x1C7C108
	public int get_damage_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6619C0 Offset: 0x6619C0 VA: 0x6619C0
	// RVA: 0x1C7C110 Offset: 0x1C7C110 VA: 0x1C7C110
	private void set_damage_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6619D0 Offset: 0x6619D0 VA: 0x6619D0
	// RVA: 0x1C7C118 Offset: 0x1C7C118 VA: 0x1C7C118
	public int get_penetrability() { }

	[CompilerGeneratedAttribute] // RVA: 0x6619E0 Offset: 0x6619E0 VA: 0x6619E0
	// RVA: 0x1C7C120 Offset: 0x1C7C120 VA: 0x1C7C120
	private void set_penetrability(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6619F0 Offset: 0x6619F0 VA: 0x6619F0
	// RVA: 0x1C7C128 Offset: 0x1C7C128 VA: 0x1C7C128
	public float get_fire_distance() { }

	[CompilerGeneratedAttribute] // RVA: 0x661A00 Offset: 0x661A00 VA: 0x661A00
	// RVA: 0x1C7C130 Offset: 0x1C7C130 VA: 0x1C7C130
	private void set_fire_distance(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661A10 Offset: 0x661A10 VA: 0x661A10
	// RVA: 0x1C7C138 Offset: 0x1C7C138 VA: 0x1C7C138
	public float[] get_damage_to_wall() { }

	[CompilerGeneratedAttribute] // RVA: 0x661A20 Offset: 0x661A20 VA: 0x661A20
	// RVA: 0x1C7C140 Offset: 0x1C7C140 VA: 0x1C7C140
	private void set_damage_to_wall(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661A30 Offset: 0x661A30 VA: 0x661A30
	// RVA: 0x1C7C148 Offset: 0x1C7C148 VA: 0x1C7C148
	public float[] get_damage_to_operator() { }

	[CompilerGeneratedAttribute] // RVA: 0x661A40 Offset: 0x661A40 VA: 0x661A40
	// RVA: 0x1C7C150 Offset: 0x1C7C150 VA: 0x1C7C150
	private void set_damage_to_operator(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661A50 Offset: 0x661A50 VA: 0x661A50
	// RVA: 0x1C7C158 Offset: 0x1C7C158 VA: 0x1C7C158
	public float[] get_damage_to_operator_suppressed() { }

	[CompilerGeneratedAttribute] // RVA: 0x661A60 Offset: 0x661A60 VA: 0x661A60
	// RVA: 0x1C7C160 Offset: 0x1C7C160 VA: 0x1C7C160
	private void set_damage_to_operator_suppressed(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661A70 Offset: 0x661A70 VA: 0x661A70
	// RVA: 0x1C7C168 Offset: 0x1C7C168 VA: 0x1C7C168
	public float[] get_damage_to_operator_extended() { }

	[CompilerGeneratedAttribute] // RVA: 0x661A80 Offset: 0x661A80 VA: 0x661A80
	// RVA: 0x1C7C170 Offset: 0x1C7C170 VA: 0x1C7C170
	private void set_damage_to_operator_extended(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661A90 Offset: 0x661A90 VA: 0x661A90
	// RVA: 0x1C7C178 Offset: 0x1C7C178 VA: 0x1C7C178
	public int get_fire_mode() { }

	[CompilerGeneratedAttribute] // RVA: 0x661AA0 Offset: 0x661AA0 VA: 0x661AA0
	// RVA: 0x1C7C180 Offset: 0x1C7C180 VA: 0x1C7C180
	private void set_fire_mode(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661AB0 Offset: 0x661AB0 VA: 0x661AB0
	// RVA: 0x1C7C188 Offset: 0x1C7C188 VA: 0x1C7C188
	public int get_rpm() { }

	[CompilerGeneratedAttribute] // RVA: 0x661AC0 Offset: 0x661AC0 VA: 0x661AC0
	// RVA: 0x1C7C190 Offset: 0x1C7C190 VA: 0x1C7C190
	private void set_rpm(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661AD0 Offset: 0x661AD0 VA: 0x661AD0
	// RVA: 0x1C7C198 Offset: 0x1C7C198 VA: 0x1C7C198
	public float get_cooldown() { }

	[CompilerGeneratedAttribute] // RVA: 0x661AE0 Offset: 0x661AE0 VA: 0x661AE0
	// RVA: 0x1C7C1A0 Offset: 0x1C7C1A0 VA: 0x1C7C1A0
	private void set_cooldown(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661AF0 Offset: 0x661AF0 VA: 0x661AF0
	// RVA: 0x1C7C1A8 Offset: 0x1C7C1A8 VA: 0x1C7C1A8
	public int get_magazine_size() { }

	[CompilerGeneratedAttribute] // RVA: 0x661B00 Offset: 0x661B00 VA: 0x661B00
	// RVA: 0x1C7C1B0 Offset: 0x1C7C1B0 VA: 0x1C7C1B0
	private void set_magazine_size(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661B10 Offset: 0x661B10 VA: 0x661B10
	// RVA: 0x1C7C1B8 Offset: 0x1C7C1B8 VA: 0x1C7C1B8
	public int get_loading_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x661B20 Offset: 0x661B20 VA: 0x661B20
	// RVA: 0x1C7C1C0 Offset: 0x1C7C1C0 VA: 0x1C7C1C0
	private void set_loading_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661B30 Offset: 0x661B30 VA: 0x661B30
	// RVA: 0x1C7C1C8 Offset: 0x1C7C1C8 VA: 0x1C7C1C8
	public int get_maximum_ammunition() { }

	[CompilerGeneratedAttribute] // RVA: 0x661B40 Offset: 0x661B40 VA: 0x661B40
	// RVA: 0x1C7C1D0 Offset: 0x1C7C1D0 VA: 0x1C7C1D0
	private void set_maximum_ammunition(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661B50 Offset: 0x661B50 VA: 0x661B50
	// RVA: 0x1C7C1D8 Offset: 0x1C7C1D8 VA: 0x1C7C1D8
	public int get_chamber() { }

	[CompilerGeneratedAttribute] // RVA: 0x661B60 Offset: 0x661B60 VA: 0x661B60
	// RVA: 0x1C7C1E0 Offset: 0x1C7C1E0 VA: 0x1C7C1E0
	private void set_chamber(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661B70 Offset: 0x661B70 VA: 0x661B70
	// RVA: 0x1C7C1E8 Offset: 0x1C7C1E8 VA: 0x1C7C1E8
	public int get_roof_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x661B80 Offset: 0x661B80 VA: 0x661B80
	// RVA: 0x1C7C1F0 Offset: 0x1C7C1F0 VA: 0x1C7C1F0
	private void set_roof_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661B90 Offset: 0x661B90 VA: 0x661B90
	// RVA: 0x1C7C1F8 Offset: 0x1C7C1F8 VA: 0x1C7C1F8
	public float get_pump_loaded_pre() { }

	[CompilerGeneratedAttribute] // RVA: 0x661BA0 Offset: 0x661BA0 VA: 0x661BA0
	// RVA: 0x1C7C200 Offset: 0x1C7C200 VA: 0x1C7C200
	private void set_pump_loaded_pre(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661BB0 Offset: 0x661BB0 VA: 0x661BB0
	// RVA: 0x1C7C208 Offset: 0x1C7C208 VA: 0x1C7C208
	public float get_pump_loaded_after() { }

	[CompilerGeneratedAttribute] // RVA: 0x661BC0 Offset: 0x661BC0 VA: 0x661BC0
	// RVA: 0x1C7C210 Offset: 0x1C7C210 VA: 0x1C7C210
	private void set_pump_loaded_after(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661BD0 Offset: 0x661BD0 VA: 0x661BD0
	// RVA: 0x1C7C218 Offset: 0x1C7C218 VA: 0x1C7C218
	public float get_reload_pre() { }

	[CompilerGeneratedAttribute] // RVA: 0x661BE0 Offset: 0x661BE0 VA: 0x661BE0
	// RVA: 0x1C7C220 Offset: 0x1C7C220 VA: 0x1C7C220
	private void set_reload_pre(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661BF0 Offset: 0x661BF0 VA: 0x661BF0
	// RVA: 0x1C7C228 Offset: 0x1C7C228 VA: 0x1C7C228
	public float get_reload_after() { }

	[CompilerGeneratedAttribute] // RVA: 0x661C00 Offset: 0x661C00 VA: 0x661C00
	// RVA: 0x1C7C230 Offset: 0x1C7C230 VA: 0x1C7C230
	private void set_reload_after(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661C10 Offset: 0x661C10 VA: 0x661C10
	// RVA: 0x1C7C238 Offset: 0x1C7C238 VA: 0x1C7C238
	public float get_empty_reload_pre() { }

	[CompilerGeneratedAttribute] // RVA: 0x661C20 Offset: 0x661C20 VA: 0x661C20
	// RVA: 0x1C7C240 Offset: 0x1C7C240 VA: 0x1C7C240
	private void set_empty_reload_pre(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661C30 Offset: 0x661C30 VA: 0x661C30
	// RVA: 0x1C7C248 Offset: 0x1C7C248 VA: 0x1C7C248
	public float get_empty_reload_after() { }

	[CompilerGeneratedAttribute] // RVA: 0x661C40 Offset: 0x661C40 VA: 0x661C40
	// RVA: 0x1C7C250 Offset: 0x1C7C250 VA: 0x1C7C250
	private void set_empty_reload_after(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661C50 Offset: 0x661C50 VA: 0x661C50
	// RVA: 0x1C7C258 Offset: 0x1C7C258 VA: 0x1C7C258
	public float get_first_bullet_after() { }

	[CompilerGeneratedAttribute] // RVA: 0x661C60 Offset: 0x661C60 VA: 0x661C60
	// RVA: 0x1C7C260 Offset: 0x1C7C260 VA: 0x1C7C260
	private void set_first_bullet_after(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661C70 Offset: 0x661C70 VA: 0x661C70
	// RVA: 0x1C7C268 Offset: 0x1C7C268 VA: 0x1C7C268
	public float get_bullet_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x661C80 Offset: 0x661C80 VA: 0x661C80
	// RVA: 0x1C7C270 Offset: 0x1C7C270 VA: 0x1C7C270
	private void set_bullet_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661C90 Offset: 0x661C90 VA: 0x661C90
	// RVA: 0x1C7C278 Offset: 0x1C7C278 VA: 0x1C7C278
	public float get_bullet_time_after() { }

	[CompilerGeneratedAttribute] // RVA: 0x661CA0 Offset: 0x661CA0 VA: 0x661CA0
	// RVA: 0x1C7C280 Offset: 0x1C7C280 VA: 0x1C7C280
	private void set_bullet_time_after(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661CB0 Offset: 0x661CB0 VA: 0x661CB0
	// RVA: 0x1C7C288 Offset: 0x1C7C288 VA: 0x1C7C288
	public float get_reload_time_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x661CC0 Offset: 0x661CC0 VA: 0x661CC0
	// RVA: 0x1C7C290 Offset: 0x1C7C290 VA: 0x1C7C290
	private void set_reload_time_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661CD0 Offset: 0x661CD0 VA: 0x661CD0
	// RVA: 0x1C7C298 Offset: 0x1C7C298 VA: 0x1C7C298
	public int get_can_aim() { }

	[CompilerGeneratedAttribute] // RVA: 0x661CE0 Offset: 0x661CE0 VA: 0x661CE0
	// RVA: 0x1C7C2A0 Offset: 0x1C7C2A0 VA: 0x1C7C2A0
	private void set_can_aim(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661CF0 Offset: 0x661CF0 VA: 0x661CF0
	// RVA: 0x1C7C2A8 Offset: 0x1C7C2A8 VA: 0x1C7C2A8
	public float get_aim_in_duration_base() { }

	[CompilerGeneratedAttribute] // RVA: 0x661D00 Offset: 0x661D00 VA: 0x661D00
	// RVA: 0x1C7C2B0 Offset: 0x1C7C2B0 VA: 0x1C7C2B0
	private void set_aim_in_duration_base(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661D10 Offset: 0x661D10 VA: 0x661D10
	// RVA: 0x1C7C2B8 Offset: 0x1C7C2B8 VA: 0x1C7C2B8
	public float get_aim_out_duration_base() { }

	[CompilerGeneratedAttribute] // RVA: 0x661D20 Offset: 0x661D20 VA: 0x661D20
	// RVA: 0x1C7C2C0 Offset: 0x1C7C2C0 VA: 0x1C7C2C0
	private void set_aim_out_duration_base(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661D30 Offset: 0x661D30 VA: 0x661D30
	// RVA: 0x1C7C2C8 Offset: 0x1C7C2C8 VA: 0x1C7C2C8
	public float get_aim_in_duration_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x661D40 Offset: 0x661D40 VA: 0x661D40
	// RVA: 0x1C7C2D0 Offset: 0x1C7C2D0 VA: 0x1C7C2D0
	private void set_aim_in_duration_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661D50 Offset: 0x661D50 VA: 0x661D50
	// RVA: 0x1C7C2D8 Offset: 0x1C7C2D8 VA: 0x1C7C2D8
	public float get_aim_out_duration_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x661D60 Offset: 0x661D60 VA: 0x661D60
	// RVA: 0x1C7C2E0 Offset: 0x1C7C2E0 VA: 0x1C7C2E0
	private void set_aim_out_duration_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661D70 Offset: 0x661D70 VA: 0x661D70
	// RVA: 0x1C7C2E8 Offset: 0x1C7C2E8 VA: 0x1C7C2E8
	public float get_aim_in_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x661D80 Offset: 0x661D80 VA: 0x661D80
	// RVA: 0x1C7C2F0 Offset: 0x1C7C2F0 VA: 0x1C7C2F0
	private void set_aim_in_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661D90 Offset: 0x661D90 VA: 0x661D90
	// RVA: 0x1C7C2F8 Offset: 0x1C7C2F8 VA: 0x1C7C2F8
	public float get_aim_out_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x661DA0 Offset: 0x661DA0 VA: 0x661DA0
	// RVA: 0x1C7C300 Offset: 0x1C7C300 VA: 0x1C7C300
	private void set_aim_out_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661DB0 Offset: 0x661DB0 VA: 0x661DB0
	// RVA: 0x1C7C308 Offset: 0x1C7C308 VA: 0x1C7C308
	public float get_aim_multiplying_power() { }

	[CompilerGeneratedAttribute] // RVA: 0x661DC0 Offset: 0x661DC0 VA: 0x661DC0
	// RVA: 0x1C7C310 Offset: 0x1C7C310 VA: 0x1C7C310
	private void set_aim_multiplying_power(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661DD0 Offset: 0x661DD0 VA: 0x661DD0
	// RVA: 0x1C7C318 Offset: 0x1C7C318 VA: 0x1C7C318
	public float get_first_recoil_change_euler_range_y_min() { }

	[CompilerGeneratedAttribute] // RVA: 0x661DE0 Offset: 0x661DE0 VA: 0x661DE0
	// RVA: 0x1C7C320 Offset: 0x1C7C320 VA: 0x1C7C320
	private void set_first_recoil_change_euler_range_y_min(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661DF0 Offset: 0x661DF0 VA: 0x661DF0
	// RVA: 0x1C7C328 Offset: 0x1C7C328 VA: 0x1C7C328
	public float get_first_recoil_change_euler_range_y_max() { }

	[CompilerGeneratedAttribute] // RVA: 0x661E00 Offset: 0x661E00 VA: 0x661E00
	// RVA: 0x1C7C330 Offset: 0x1C7C330 VA: 0x1C7C330
	private void set_first_recoil_change_euler_range_y_max(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661E10 Offset: 0x661E10 VA: 0x661E10
	// RVA: 0x1C7C338 Offset: 0x1C7C338 VA: 0x1C7C338
	public float get_recoil_change_euler_range_y_min() { }

	[CompilerGeneratedAttribute] // RVA: 0x661E20 Offset: 0x661E20 VA: 0x661E20
	// RVA: 0x1C7C340 Offset: 0x1C7C340 VA: 0x1C7C340
	private void set_recoil_change_euler_range_y_min(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661E30 Offset: 0x661E30 VA: 0x661E30
	// RVA: 0x1C7C348 Offset: 0x1C7C348 VA: 0x1C7C348
	public float get_recoil_change_euler_range_y_max() { }

	[CompilerGeneratedAttribute] // RVA: 0x661E40 Offset: 0x661E40 VA: 0x661E40
	// RVA: 0x1C7C350 Offset: 0x1C7C350 VA: 0x1C7C350
	private void set_recoil_change_euler_range_y_max(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661E50 Offset: 0x661E50 VA: 0x661E50
	// RVA: 0x1C7C358 Offset: 0x1C7C358 VA: 0x1C7C358
	public float get_first_recoil_change_euler_range_x_min() { }

	[CompilerGeneratedAttribute] // RVA: 0x661E60 Offset: 0x661E60 VA: 0x661E60
	// RVA: 0x1C7C360 Offset: 0x1C7C360 VA: 0x1C7C360
	private void set_first_recoil_change_euler_range_x_min(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661E70 Offset: 0x661E70 VA: 0x661E70
	// RVA: 0x1C7C368 Offset: 0x1C7C368 VA: 0x1C7C368
	public float get_first_recoil_change_euler_range_x_max() { }

	[CompilerGeneratedAttribute] // RVA: 0x661E80 Offset: 0x661E80 VA: 0x661E80
	// RVA: 0x1C7C370 Offset: 0x1C7C370 VA: 0x1C7C370
	private void set_first_recoil_change_euler_range_x_max(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661E90 Offset: 0x661E90 VA: 0x661E90
	// RVA: 0x1C7C378 Offset: 0x1C7C378 VA: 0x1C7C378
	public float get_recoil_change_euler_range_x_min() { }

	[CompilerGeneratedAttribute] // RVA: 0x661EA0 Offset: 0x661EA0 VA: 0x661EA0
	// RVA: 0x1C7C380 Offset: 0x1C7C380 VA: 0x1C7C380
	private void set_recoil_change_euler_range_x_min(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661EB0 Offset: 0x661EB0 VA: 0x661EB0
	// RVA: 0x1C7C388 Offset: 0x1C7C388 VA: 0x1C7C388
	public float get_recoil_change_euler_range_x_max() { }

	[CompilerGeneratedAttribute] // RVA: 0x661EC0 Offset: 0x661EC0 VA: 0x661EC0
	// RVA: 0x1C7C390 Offset: 0x1C7C390 VA: 0x1C7C390
	private void set_recoil_change_euler_range_x_max(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661ED0 Offset: 0x661ED0 VA: 0x661ED0
	// RVA: 0x1C7C398 Offset: 0x1C7C398 VA: 0x1C7C398
	public float get_cehuashuju1() { }

	[CompilerGeneratedAttribute] // RVA: 0x661EE0 Offset: 0x661EE0 VA: 0x661EE0
	// RVA: 0x1C7C3A0 Offset: 0x1C7C3A0 VA: 0x1C7C3A0
	private void set_cehuashuju1(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661EF0 Offset: 0x661EF0 VA: 0x661EF0
	// RVA: 0x1C7C3A8 Offset: 0x1C7C3A8 VA: 0x1C7C3A8
	public float get_recoil_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x661F00 Offset: 0x661F00 VA: 0x661F00
	// RVA: 0x1C7C3B0 Offset: 0x1C7C3B0 VA: 0x1C7C3B0
	private void set_recoil_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661F10 Offset: 0x661F10 VA: 0x661F10
	// RVA: 0x1C7C3B8 Offset: 0x1C7C3B8 VA: 0x1C7C3B8
	public float get_recoil_y_limit() { }

	[CompilerGeneratedAttribute] // RVA: 0x661F20 Offset: 0x661F20 VA: 0x661F20
	// RVA: 0x1C7C3C0 Offset: 0x1C7C3C0 VA: 0x1C7C3C0
	private void set_recoil_y_limit(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661F30 Offset: 0x661F30 VA: 0x661F30
	// RVA: 0x1C7C3C8 Offset: 0x1C7C3C8 VA: 0x1C7C3C8
	public float get_recoil_x_limit() { }

	[CompilerGeneratedAttribute] // RVA: 0x661F40 Offset: 0x661F40 VA: 0x661F40
	// RVA: 0x1C7C3D0 Offset: 0x1C7C3D0 VA: 0x1C7C3D0
	private void set_recoil_x_limit(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661F50 Offset: 0x661F50 VA: 0x661F50
	// RVA: 0x1C7C3D8 Offset: 0x1C7C3D8 VA: 0x1C7C3D8
	public float[] get_recoil_change_euler_range_y_min_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x661F60 Offset: 0x661F60 VA: 0x661F60
	// RVA: 0x1C7C3E0 Offset: 0x1C7C3E0 VA: 0x1C7C3E0
	private void set_recoil_change_euler_range_y_min_array(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661F70 Offset: 0x661F70 VA: 0x661F70
	// RVA: 0x1C7C3E8 Offset: 0x1C7C3E8 VA: 0x1C7C3E8
	public float[] get_recoil_change_euler_range_y_max_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x661F80 Offset: 0x661F80 VA: 0x661F80
	// RVA: 0x1C7C3F0 Offset: 0x1C7C3F0 VA: 0x1C7C3F0
	private void set_recoil_change_euler_range_y_max_array(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661F90 Offset: 0x661F90 VA: 0x661F90
	// RVA: 0x1C7C3F8 Offset: 0x1C7C3F8 VA: 0x1C7C3F8
	public float[] get_recoil_change_euler_range_x_min_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x661FA0 Offset: 0x661FA0 VA: 0x661FA0
	// RVA: 0x1C7C400 Offset: 0x1C7C400 VA: 0x1C7C400
	private void set_recoil_change_euler_range_x_min_array(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661FB0 Offset: 0x661FB0 VA: 0x661FB0
	// RVA: 0x1C7C408 Offset: 0x1C7C408 VA: 0x1C7C408
	public float[] get_recoil_change_euler_range_x_max_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x661FC0 Offset: 0x661FC0 VA: 0x661FC0
	// RVA: 0x1C7C410 Offset: 0x1C7C410 VA: 0x1C7C410
	private void set_recoil_change_euler_range_x_max_array(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661FD0 Offset: 0x661FD0 VA: 0x661FD0
	// RVA: 0x1C7C418 Offset: 0x1C7C418 VA: 0x1C7C418
	public int get_recoil_display() { }

	[CompilerGeneratedAttribute] // RVA: 0x661FE0 Offset: 0x661FE0 VA: 0x661FE0
	// RVA: 0x1C7C420 Offset: 0x1C7C420 VA: 0x1C7C420
	private void set_recoil_display(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x661FF0 Offset: 0x661FF0 VA: 0x661FF0
	// RVA: 0x1C7C428 Offset: 0x1C7C428 VA: 0x1C7C428
	public float get_recoil_add_variation_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x662000 Offset: 0x662000 VA: 0x662000
	// RVA: 0x1C7C430 Offset: 0x1C7C430 VA: 0x1C7C430
	private void set_recoil_add_variation_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662010 Offset: 0x662010 VA: 0x662010
	// RVA: 0x1C7C438 Offset: 0x1C7C438 VA: 0x1C7C438
	public float get_recoil_recover_variation_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x662020 Offset: 0x662020 VA: 0x662020
	// RVA: 0x1C7C440 Offset: 0x1C7C440 VA: 0x1C7C440
	private void set_recoil_recover_variation_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662030 Offset: 0x662030 VA: 0x662030
	// RVA: 0x1C7C448 Offset: 0x1C7C448 VA: 0x1C7C448
	public float get_aim_waggle_degree() { }

	[CompilerGeneratedAttribute] // RVA: 0x662040 Offset: 0x662040 VA: 0x662040
	// RVA: 0x1C7C450 Offset: 0x1C7C450 VA: 0x1C7C450
	private void set_aim_waggle_degree(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662050 Offset: 0x662050 VA: 0x662050
	// RVA: 0x1C7C458 Offset: 0x1C7C458 VA: 0x1C7C458
	public float get_cehuashuju2() { }

	[CompilerGeneratedAttribute] // RVA: 0x662060 Offset: 0x662060 VA: 0x662060
	// RVA: 0x1C7C460 Offset: 0x1C7C460 VA: 0x1C7C460
	private void set_cehuashuju2(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662070 Offset: 0x662070 VA: 0x662070
	// RVA: 0x1C7C468 Offset: 0x1C7C468 VA: 0x1C7C468
	public float get_scatter_base_degree() { }

	[CompilerGeneratedAttribute] // RVA: 0x662080 Offset: 0x662080 VA: 0x662080
	// RVA: 0x1C7C470 Offset: 0x1C7C470 VA: 0x1C7C470
	private void set_scatter_base_degree(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662090 Offset: 0x662090 VA: 0x662090
	// RVA: 0x1C7C478 Offset: 0x1C7C478 VA: 0x1C7C478
	public float get_scatter_crouch_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x6620A0 Offset: 0x6620A0 VA: 0x6620A0
	// RVA: 0x1C7C480 Offset: 0x1C7C480 VA: 0x1C7C480
	private void set_scatter_crouch_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6620B0 Offset: 0x6620B0 VA: 0x6620B0
	// RVA: 0x1C7C488 Offset: 0x1C7C488 VA: 0x1C7C488
	public float get_scatter_creep_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x6620C0 Offset: 0x6620C0 VA: 0x6620C0
	// RVA: 0x1C7C490 Offset: 0x1C7C490 VA: 0x1C7C490
	private void set_scatter_creep_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6620D0 Offset: 0x6620D0 VA: 0x6620D0
	// RVA: 0x1C7C498 Offset: 0x1C7C498 VA: 0x1C7C498
	public float get_cehuashuju3() { }

	[CompilerGeneratedAttribute] // RVA: 0x6620E0 Offset: 0x6620E0 VA: 0x6620E0
	// RVA: 0x1C7C4A0 Offset: 0x1C7C4A0 VA: 0x1C7C4A0
	private void set_cehuashuju3(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6620F0 Offset: 0x6620F0 VA: 0x6620F0
	// RVA: 0x1C7C4A8 Offset: 0x1C7C4A8 VA: 0x1C7C4A8
	public float get_scatter_fire_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x662100 Offset: 0x662100 VA: 0x662100
	// RVA: 0x1C7C4B0 Offset: 0x1C7C4B0 VA: 0x1C7C4B0
	private void set_scatter_fire_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662110 Offset: 0x662110 VA: 0x662110
	// RVA: 0x1C7C4B8 Offset: 0x1C7C4B8 VA: 0x1C7C4B8
	public float get_scatter_max_fire_degree() { }

	[CompilerGeneratedAttribute] // RVA: 0x662120 Offset: 0x662120 VA: 0x662120
	// RVA: 0x1C7C4C0 Offset: 0x1C7C4C0 VA: 0x1C7C4C0
	private void set_scatter_max_fire_degree(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662130 Offset: 0x662130 VA: 0x662130
	// RVA: 0x1C7C4C8 Offset: 0x1C7C4C8 VA: 0x1C7C4C8
	public float get_scatter_speed_coefficient() { }

	[CompilerGeneratedAttribute] // RVA: 0x662140 Offset: 0x662140 VA: 0x662140
	// RVA: 0x1C7C4D0 Offset: 0x1C7C4D0 VA: 0x1C7C4D0
	private void set_scatter_speed_coefficient(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662150 Offset: 0x662150 VA: 0x662150
	// RVA: 0x1C7C4D8 Offset: 0x1C7C4D8 VA: 0x1C7C4D8
	public float get_moving_scatter_max() { }

	[CompilerGeneratedAttribute] // RVA: 0x662160 Offset: 0x662160 VA: 0x662160
	// RVA: 0x1C7C4E0 Offset: 0x1C7C4E0 VA: 0x1C7C4E0
	private void set_moving_scatter_max(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662170 Offset: 0x662170 VA: 0x662170
	// RVA: 0x1C7C4E8 Offset: 0x1C7C4E8 VA: 0x1C7C4E8
	public float get_scatter_fire_variation_duration() { }

	[CompilerGeneratedAttribute] // RVA: 0x662180 Offset: 0x662180 VA: 0x662180
	// RVA: 0x1C7C4F0 Offset: 0x1C7C4F0 VA: 0x1C7C4F0
	private void set_scatter_fire_variation_duration(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662190 Offset: 0x662190 VA: 0x662190
	// RVA: 0x1C7C4F8 Offset: 0x1C7C4F8 VA: 0x1C7C4F8
	public float get_scatter_decrease_value() { }

	[CompilerGeneratedAttribute] // RVA: 0x6621A0 Offset: 0x6621A0 VA: 0x6621A0
	// RVA: 0x1C7C500 Offset: 0x1C7C500 VA: 0x1C7C500
	private void set_scatter_decrease_value(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6621B0 Offset: 0x6621B0 VA: 0x6621B0
	// RVA: 0x1C7C508 Offset: 0x1C7C508 VA: 0x1C7C508
	public int get_basic_scatter_fire_in_center() { }

	[CompilerGeneratedAttribute] // RVA: 0x6621C0 Offset: 0x6621C0 VA: 0x6621C0
	// RVA: 0x1C7C510 Offset: 0x1C7C510 VA: 0x1C7C510
	private void set_basic_scatter_fire_in_center(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6621D0 Offset: 0x6621D0 VA: 0x6621D0
	// RVA: 0x1C7C518 Offset: 0x1C7C518 VA: 0x1C7C518
	public int get_aim_process_fire() { }

	[CompilerGeneratedAttribute] // RVA: 0x6621E0 Offset: 0x6621E0 VA: 0x6621E0
	// RVA: 0x1C7C520 Offset: 0x1C7C520 VA: 0x1C7C520
	private void set_aim_process_fire(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6621F0 Offset: 0x6621F0 VA: 0x6621F0
	// RVA: 0x1C7C528 Offset: 0x1C7C528 VA: 0x1C7C528
	public int get_weapon_fire_particle_p1() { }

	[CompilerGeneratedAttribute] // RVA: 0x662200 Offset: 0x662200 VA: 0x662200
	// RVA: 0x1C7C530 Offset: 0x1C7C530 VA: 0x1C7C530
	private void set_weapon_fire_particle_p1(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662210 Offset: 0x662210 VA: 0x662210
	// RVA: 0x1C7C538 Offset: 0x1C7C538 VA: 0x1C7C538
	public int get_weapon_aiming_fire_particle_p1() { }

	[CompilerGeneratedAttribute] // RVA: 0x662220 Offset: 0x662220 VA: 0x662220
	// RVA: 0x1C7C540 Offset: 0x1C7C540 VA: 0x1C7C540
	private void set_weapon_aiming_fire_particle_p1(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662230 Offset: 0x662230 VA: 0x662230
	// RVA: 0x1C7C548 Offset: 0x1C7C548 VA: 0x1C7C548
	public int get_weapon_smoke_particle_p1() { }

	[CompilerGeneratedAttribute] // RVA: 0x662240 Offset: 0x662240 VA: 0x662240
	// RVA: 0x1C7C550 Offset: 0x1C7C550 VA: 0x1C7C550
	private void set_weapon_smoke_particle_p1(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662250 Offset: 0x662250 VA: 0x662250
	// RVA: 0x1C7C558 Offset: 0x1C7C558 VA: 0x1C7C558
	public int get_weapon_fire_particle_p3() { }

	[CompilerGeneratedAttribute] // RVA: 0x662260 Offset: 0x662260 VA: 0x662260
	// RVA: 0x1C7C560 Offset: 0x1C7C560 VA: 0x1C7C560
	private void set_weapon_fire_particle_p3(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662270 Offset: 0x662270 VA: 0x662270
	// RVA: 0x1C7C568 Offset: 0x1C7C568 VA: 0x1C7C568
	public int get_weapon_smoke_particle_p3() { }

	[CompilerGeneratedAttribute] // RVA: 0x662280 Offset: 0x662280 VA: 0x662280
	// RVA: 0x1C7C570 Offset: 0x1C7C570 VA: 0x1C7C570
	private void set_weapon_smoke_particle_p3(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662290 Offset: 0x662290 VA: 0x662290
	// RVA: 0x1C7C578 Offset: 0x1C7C578 VA: 0x1C7C578
	public int get_weapon_bullet_particle() { }

	[CompilerGeneratedAttribute] // RVA: 0x6622A0 Offset: 0x6622A0 VA: 0x6622A0
	// RVA: 0x1C7C580 Offset: 0x1C7C580 VA: 0x1C7C580
	private void set_weapon_bullet_particle(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6622B0 Offset: 0x6622B0 VA: 0x6622B0
	// RVA: 0x1C7C588 Offset: 0x1C7C588 VA: 0x1C7C588
	public float[] get_weapon_bullet_particle_position() { }

	[CompilerGeneratedAttribute] // RVA: 0x6622C0 Offset: 0x6622C0 VA: 0x6622C0
	// RVA: 0x1C7C590 Offset: 0x1C7C590 VA: 0x1C7C590
	private void set_weapon_bullet_particle_position(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6622D0 Offset: 0x6622D0 VA: 0x6622D0
	// RVA: 0x1C7C598 Offset: 0x1C7C598 VA: 0x1C7C598
	public float[] get_weapon_bullet_particle_rotation() { }

	[CompilerGeneratedAttribute] // RVA: 0x6622E0 Offset: 0x6622E0 VA: 0x6622E0
	// RVA: 0x1C7C5A0 Offset: 0x1C7C5A0 VA: 0x1C7C5A0
	private void set_weapon_bullet_particle_rotation(float[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6622F0 Offset: 0x6622F0 VA: 0x6622F0
	// RVA: 0x1C7C5A8 Offset: 0x1C7C5A8 VA: 0x1C7C5A8
	public string get_fire_loop_sound_p1() { }

	[CompilerGeneratedAttribute] // RVA: 0x662300 Offset: 0x662300 VA: 0x662300
	// RVA: 0x1C7C5B0 Offset: 0x1C7C5B0 VA: 0x1C7C5B0
	private void set_fire_loop_sound_p1(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662310 Offset: 0x662310 VA: 0x662310
	// RVA: 0x1C7C5B8 Offset: 0x1C7C5B8 VA: 0x1C7C5B8
	public string get_fire_tail_sound_p1() { }

	[CompilerGeneratedAttribute] // RVA: 0x662320 Offset: 0x662320 VA: 0x662320
	// RVA: 0x1C7C5C0 Offset: 0x1C7C5C0 VA: 0x1C7C5C0
	private void set_fire_tail_sound_p1(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662330 Offset: 0x662330 VA: 0x662330
	// RVA: 0x1C7C5C8 Offset: 0x1C7C5C8 VA: 0x1C7C5C8
	public string get_fire_loop_sound_p3() { }

	[CompilerGeneratedAttribute] // RVA: 0x662340 Offset: 0x662340 VA: 0x662340
	// RVA: 0x1C7C5D0 Offset: 0x1C7C5D0 VA: 0x1C7C5D0
	private void set_fire_loop_sound_p3(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662350 Offset: 0x662350 VA: 0x662350
	// RVA: 0x1C7C5D8 Offset: 0x1C7C5D8 VA: 0x1C7C5D8
	public string get_fire_tail_sound_p3() { }

	[CompilerGeneratedAttribute] // RVA: 0x662360 Offset: 0x662360 VA: 0x662360
	// RVA: 0x1C7C5E0 Offset: 0x1C7C5E0 VA: 0x1C7C5E0
	private void set_fire_tail_sound_p3(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x662370 Offset: 0x662370 VA: 0x662370
	// RVA: 0x1C7C5E8 Offset: 0x1C7C5E8 VA: 0x1C7C5E8
	public int get_dont_show_gunline() { }

	[CompilerGeneratedAttribute] // RVA: 0x662380 Offset: 0x662380 VA: 0x662380
	// RVA: 0x1C7C5F0 Offset: 0x1C7C5F0 VA: 0x1C7C5F0
	private void set_dont_show_gunline(int value) { }

	// RVA: 0x1C7BE78 Offset: 0x1C7BE78 VA: 0x1C7BE78
	internal void .ctor(MemoryStream reader, Action<gun_data_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C72934 Offset: 0x1C72934 VA: 0x1C72934
	internal static bool SetupReadActions(Field[] fields, Action<gun_data_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1C7C600 Offset: 0x1C7C600 VA: 0x1C7C600 Slot: 4
	public object Clone() { }
}
