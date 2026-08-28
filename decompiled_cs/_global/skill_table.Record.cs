// Namespace: 
public class skill_table.Record : ICloneable // TypeDefIndex: 10808
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5729E4 Offset: 0x5729E4 VA: 0x5729E4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5729F4 Offset: 0x5729F4 VA: 0x5729F4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572A04 Offset: 0x572A04 VA: 0x572A04
	private int <desc_lang_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572A14 Offset: 0x572A14 VA: 0x572A14
	private string <note>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572A24 Offset: 0x572A24 VA: 0x572A24
	private string <name>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x572A34 Offset: 0x572A34 VA: 0x572A34
	private int <name_lang_index>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x572A44 Offset: 0x572A44 VA: 0x572A44
	private string <icon>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x572A54 Offset: 0x572A54 VA: 0x572A54
	private string <icon_3d>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x572A64 Offset: 0x572A64 VA: 0x572A64
	private int <icon_position>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x572A74 Offset: 0x572A74 VA: 0x572A74
	private string <script_config_path>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x572A84 Offset: 0x572A84 VA: 0x572A84
	private int <type>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x572A94 Offset: 0x572A94 VA: 0x572A94
	private int <index>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x572AA4 Offset: 0x572AA4 VA: 0x572AA4
	private float <deployment_id>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x572AB4 Offset: 0x572AB4 VA: 0x572AB4
	private int <init_number>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x572AC4 Offset: 0x572AC4 VA: 0x572AC4
	private int <allow_infinite_item>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x572AD4 Offset: 0x572AD4 VA: 0x572AD4
	private int <allow_reset_item>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x572AE4 Offset: 0x572AE4 VA: 0x572AE4
	private float <energy_id>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x572AF4 Offset: 0x572AF4 VA: 0x572AF4
	private float <cooldown_time>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x572B04 Offset: 0x572B04 VA: 0x572B04
	private float <active_time>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x572B14 Offset: 0x572B14 VA: 0x572B14
	private int[] <related_skill>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x572B24 Offset: 0x572B24 VA: 0x572B24
	private int[] <related_skill_target>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x572B34 Offset: 0x572B34 VA: 0x572B34
	private int <button_type>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x572B44 Offset: 0x572B44 VA: 0x572B44
	private float <safe_distance>k__BackingField; // 0x60

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public int desc_lang_index { get; set; }
	public string note { get; set; }
	public string name { get; set; }
	public int name_lang_index { get; set; }
	public string icon { get; set; }
	public string icon_3d { get; set; }
	public int icon_position { get; set; }
	public string script_config_path { get; set; }
	public int type { get; set; }
	public int index { get; set; }
	public float deployment_id { get; set; }
	public int init_number { get; set; }
	public int allow_infinite_item { get; set; }
	public int allow_reset_item { get; set; }
	public float energy_id { get; set; }
	public float cooldown_time { get; set; }
	public float active_time { get; set; }
	public int[] related_skill { get; set; }
	public int[] related_skill_target { get; set; }
	public int button_type { get; set; }
	public float safe_distance { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x665F30 Offset: 0x665F30 VA: 0x665F30
	// RVA: 0x1F2E598 Offset: 0x1F2E598 VA: 0x1F2E598
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x665F40 Offset: 0x665F40 VA: 0x665F40
	// RVA: 0x1F2E5A0 Offset: 0x1F2E5A0 VA: 0x1F2E5A0
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665F50 Offset: 0x665F50 VA: 0x665F50
	// RVA: 0x1F2E5A8 Offset: 0x1F2E5A8 VA: 0x1F2E5A8
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x665F60 Offset: 0x665F60 VA: 0x665F60
	// RVA: 0x1F2E5B0 Offset: 0x1F2E5B0 VA: 0x1F2E5B0
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665F70 Offset: 0x665F70 VA: 0x665F70
	// RVA: 0x1F2E5B8 Offset: 0x1F2E5B8 VA: 0x1F2E5B8
	public int get_desc_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x665F80 Offset: 0x665F80 VA: 0x665F80
	// RVA: 0x1F2E5C0 Offset: 0x1F2E5C0 VA: 0x1F2E5C0
	private void set_desc_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665F90 Offset: 0x665F90 VA: 0x665F90
	// RVA: 0x1F2E5C8 Offset: 0x1F2E5C8 VA: 0x1F2E5C8
	public string get_note() { }

	[CompilerGeneratedAttribute] // RVA: 0x665FA0 Offset: 0x665FA0 VA: 0x665FA0
	// RVA: 0x1F2E5D0 Offset: 0x1F2E5D0 VA: 0x1F2E5D0
	private void set_note(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665FB0 Offset: 0x665FB0 VA: 0x665FB0
	// RVA: 0x1F2E5D8 Offset: 0x1F2E5D8 VA: 0x1F2E5D8
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x665FC0 Offset: 0x665FC0 VA: 0x665FC0
	// RVA: 0x1F2E5E0 Offset: 0x1F2E5E0 VA: 0x1F2E5E0
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665FD0 Offset: 0x665FD0 VA: 0x665FD0
	// RVA: 0x1F2E5E8 Offset: 0x1F2E5E8 VA: 0x1F2E5E8
	public int get_name_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x665FE0 Offset: 0x665FE0 VA: 0x665FE0
	// RVA: 0x1F2E5F0 Offset: 0x1F2E5F0 VA: 0x1F2E5F0
	private void set_name_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x665FF0 Offset: 0x665FF0 VA: 0x665FF0
	// RVA: 0x1F2E5F8 Offset: 0x1F2E5F8 VA: 0x1F2E5F8
	public string get_icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x666000 Offset: 0x666000 VA: 0x666000
	// RVA: 0x1F2E600 Offset: 0x1F2E600 VA: 0x1F2E600
	private void set_icon(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666010 Offset: 0x666010 VA: 0x666010
	// RVA: 0x1F2E608 Offset: 0x1F2E608 VA: 0x1F2E608
	public string get_icon_3d() { }

	[CompilerGeneratedAttribute] // RVA: 0x666020 Offset: 0x666020 VA: 0x666020
	// RVA: 0x1F2E610 Offset: 0x1F2E610 VA: 0x1F2E610
	private void set_icon_3d(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666030 Offset: 0x666030 VA: 0x666030
	// RVA: 0x1F2E618 Offset: 0x1F2E618 VA: 0x1F2E618
	public int get_icon_position() { }

	[CompilerGeneratedAttribute] // RVA: 0x666040 Offset: 0x666040 VA: 0x666040
	// RVA: 0x1F2E620 Offset: 0x1F2E620 VA: 0x1F2E620
	private void set_icon_position(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666050 Offset: 0x666050 VA: 0x666050
	// RVA: 0x1F2E628 Offset: 0x1F2E628 VA: 0x1F2E628
	public string get_script_config_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x666060 Offset: 0x666060 VA: 0x666060
	// RVA: 0x1F2E630 Offset: 0x1F2E630 VA: 0x1F2E630
	private void set_script_config_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666070 Offset: 0x666070 VA: 0x666070
	// RVA: 0x1F2E638 Offset: 0x1F2E638 VA: 0x1F2E638
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x666080 Offset: 0x666080 VA: 0x666080
	// RVA: 0x1F2E640 Offset: 0x1F2E640 VA: 0x1F2E640
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666090 Offset: 0x666090 VA: 0x666090
	// RVA: 0x1F2E648 Offset: 0x1F2E648 VA: 0x1F2E648
	public int get_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x6660A0 Offset: 0x6660A0 VA: 0x6660A0
	// RVA: 0x1F2E650 Offset: 0x1F2E650 VA: 0x1F2E650
	private void set_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6660B0 Offset: 0x6660B0 VA: 0x6660B0
	// RVA: 0x1F2E658 Offset: 0x1F2E658 VA: 0x1F2E658
	public float get_deployment_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6660C0 Offset: 0x6660C0 VA: 0x6660C0
	// RVA: 0x1F2E660 Offset: 0x1F2E660 VA: 0x1F2E660
	private void set_deployment_id(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6660D0 Offset: 0x6660D0 VA: 0x6660D0
	// RVA: 0x1F2E668 Offset: 0x1F2E668 VA: 0x1F2E668
	public int get_init_number() { }

	[CompilerGeneratedAttribute] // RVA: 0x6660E0 Offset: 0x6660E0 VA: 0x6660E0
	// RVA: 0x1F2E670 Offset: 0x1F2E670 VA: 0x1F2E670
	private void set_init_number(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6660F0 Offset: 0x6660F0 VA: 0x6660F0
	// RVA: 0x1F2E678 Offset: 0x1F2E678 VA: 0x1F2E678
	public int get_allow_infinite_item() { }

	[CompilerGeneratedAttribute] // RVA: 0x666100 Offset: 0x666100 VA: 0x666100
	// RVA: 0x1F2E680 Offset: 0x1F2E680 VA: 0x1F2E680
	private void set_allow_infinite_item(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666110 Offset: 0x666110 VA: 0x666110
	// RVA: 0x1F2E688 Offset: 0x1F2E688 VA: 0x1F2E688
	public int get_allow_reset_item() { }

	[CompilerGeneratedAttribute] // RVA: 0x666120 Offset: 0x666120 VA: 0x666120
	// RVA: 0x1F2E690 Offset: 0x1F2E690 VA: 0x1F2E690
	private void set_allow_reset_item(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666130 Offset: 0x666130 VA: 0x666130
	// RVA: 0x1F2E698 Offset: 0x1F2E698 VA: 0x1F2E698
	public float get_energy_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x666140 Offset: 0x666140 VA: 0x666140
	// RVA: 0x1F2E6A0 Offset: 0x1F2E6A0 VA: 0x1F2E6A0
	private void set_energy_id(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666150 Offset: 0x666150 VA: 0x666150
	// RVA: 0x1F2E6A8 Offset: 0x1F2E6A8 VA: 0x1F2E6A8
	public float get_cooldown_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x666160 Offset: 0x666160 VA: 0x666160
	// RVA: 0x1F2E6B0 Offset: 0x1F2E6B0 VA: 0x1F2E6B0
	private void set_cooldown_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666170 Offset: 0x666170 VA: 0x666170
	// RVA: 0x1F2E6B8 Offset: 0x1F2E6B8 VA: 0x1F2E6B8
	public float get_active_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x666180 Offset: 0x666180 VA: 0x666180
	// RVA: 0x1F2E6C0 Offset: 0x1F2E6C0 VA: 0x1F2E6C0
	private void set_active_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666190 Offset: 0x666190 VA: 0x666190
	// RVA: 0x1F2E6C8 Offset: 0x1F2E6C8 VA: 0x1F2E6C8
	public int[] get_related_skill() { }

	[CompilerGeneratedAttribute] // RVA: 0x6661A0 Offset: 0x6661A0 VA: 0x6661A0
	// RVA: 0x1F2E6D0 Offset: 0x1F2E6D0 VA: 0x1F2E6D0
	private void set_related_skill(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6661B0 Offset: 0x6661B0 VA: 0x6661B0
	// RVA: 0x1F2E6D8 Offset: 0x1F2E6D8 VA: 0x1F2E6D8
	public int[] get_related_skill_target() { }

	[CompilerGeneratedAttribute] // RVA: 0x6661C0 Offset: 0x6661C0 VA: 0x6661C0
	// RVA: 0x1F2E6E0 Offset: 0x1F2E6E0 VA: 0x1F2E6E0
	private void set_related_skill_target(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6661D0 Offset: 0x6661D0 VA: 0x6661D0
	// RVA: 0x1F2E6E8 Offset: 0x1F2E6E8 VA: 0x1F2E6E8
	public int get_button_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6661E0 Offset: 0x6661E0 VA: 0x6661E0
	// RVA: 0x1F2E6F0 Offset: 0x1F2E6F0 VA: 0x1F2E6F0
	private void set_button_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6661F0 Offset: 0x6661F0 VA: 0x6661F0
	// RVA: 0x1F2E6F8 Offset: 0x1F2E6F8 VA: 0x1F2E6F8
	public float get_safe_distance() { }

	[CompilerGeneratedAttribute] // RVA: 0x666200 Offset: 0x666200 VA: 0x666200
	// RVA: 0x1F2E700 Offset: 0x1F2E700 VA: 0x1F2E700
	private void set_safe_distance(float value) { }

	// RVA: 0x1F2E398 Offset: 0x1F2E398 VA: 0x1F2E398
	internal void .ctor(MemoryStream reader, Action<skill_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F2B948 Offset: 0x1F2B948 VA: 0x1F2B948
	internal static bool SetupReadActions(Field[] fields, Action<skill_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F2E710 Offset: 0x1F2E710 VA: 0x1F2E710 Slot: 4
	public object Clone() { }
}
