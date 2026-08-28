// Namespace: 
public class character_table.Record : ICloneable // TypeDefIndex: 10584
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56F864 Offset: 0x56F864 VA: 0x56F864
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56F874 Offset: 0x56F874 VA: 0x56F874
	private string <name>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56F884 Offset: 0x56F884 VA: 0x56F884
	private string <bag_id_index>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56F894 Offset: 0x56F894 VA: 0x56F894
	private int <name_lang_index>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56F8A4 Offset: 0x56F8A4 VA: 0x56F8A4
	private int <choose_limit>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56F8B4 Offset: 0x56F8B4 VA: 0x56F8B4
	private int <camp>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56F8C4 Offset: 0x56F8C4 VA: 0x56F8C4
	private string <desc>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56F8D4 Offset: 0x56F8D4 VA: 0x56F8D4
	private int <desc_lang_index>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56F8E4 Offset: 0x56F8E4 VA: 0x56F8E4
	private int <available>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56F8F4 Offset: 0x56F8F4 VA: 0x56F8F4
	private int <default_head_skin>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x56F904 Offset: 0x56F904 VA: 0x56F904
	private int <default_body_skin>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56F914 Offset: 0x56F914 VA: 0x56F914
	private string <icon>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56F924 Offset: 0x56F924 VA: 0x56F924
	private string <pic>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x56F934 Offset: 0x56F934 VA: 0x56F934
	private int <sound_id>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56F944 Offset: 0x56F944 VA: 0x56F944
	private string <army>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x56F954 Offset: 0x56F954 VA: 0x56F954
	private int <hp>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x56F964 Offset: 0x56F964 VA: 0x56F964
	private int <dying_hp>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x56F974 Offset: 0x56F974 VA: 0x56F974
	private int <dying_time>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x56F984 Offset: 0x56F984 VA: 0x56F984
	private int <speed_level>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x56F994 Offset: 0x56F994 VA: 0x56F994
	private int <armor_level>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x56F9A4 Offset: 0x56F9A4 VA: 0x56F9A4
	private int <difficulty_level>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x56F9B4 Offset: 0x56F9B4 VA: 0x56F9B4
	private int[] <primary_weapon>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x56F9C4 Offset: 0x56F9C4 VA: 0x56F9C4
	private int[] <secondary_weapon>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x56F9D4 Offset: 0x56F9D4 VA: 0x56F9D4
	private int[] <main_skill>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x56F9E4 Offset: 0x56F9E4 VA: 0x56F9E4
	private int <default_skill1>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x56F9F4 Offset: 0x56F9F4 VA: 0x56F9F4
	private int <default_skill2>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x56FA04 Offset: 0x56FA04 VA: 0x56FA04
	private int <default_skill3>k__BackingField; // 0x70
	[CompilerGeneratedAttribute] // RVA: 0x56FA14 Offset: 0x56FA14 VA: 0x56FA14
	private int[] <sub_skills>k__BackingField; // 0x74
	[CompilerGeneratedAttribute] // RVA: 0x56FA24 Offset: 0x56FA24 VA: 0x56FA24
	private int[] <trigger_skills>k__BackingField; // 0x78
	[CompilerGeneratedAttribute] // RVA: 0x56FA34 Offset: 0x56FA34 VA: 0x56FA34
	private int <has_unique_skill>k__BackingField; // 0x7C
	[CompilerGeneratedAttribute] // RVA: 0x56FA44 Offset: 0x56FA44 VA: 0x56FA44
	private int[] <preload_particle_id_array>k__BackingField; // 0x80
	[CompilerGeneratedAttribute] // RVA: 0x56FA54 Offset: 0x56FA54 VA: 0x56FA54
	private string <ware_house_default_aoc>k__BackingField; // 0x84

	// Properties
	public int id { get; set; }
	public string name { get; set; }
	public string bag_id_index { get; set; }
	public int name_lang_index { get; set; }
	public int choose_limit { get; set; }
	public int camp { get; set; }
	public string desc { get; set; }
	public int desc_lang_index { get; set; }
	public int available { get; set; }
	public int default_head_skin { get; set; }
	public int default_body_skin { get; set; }
	public string icon { get; set; }
	public string pic { get; set; }
	public int sound_id { get; set; }
	public string army { get; set; }
	public int hp { get; set; }
	public int dying_hp { get; set; }
	public int dying_time { get; set; }
	public int speed_level { get; set; }
	public int armor_level { get; set; }
	public int difficulty_level { get; set; }
	public int[] primary_weapon { get; set; }
	public int[] secondary_weapon { get; set; }
	public int[] main_skill { get; set; }
	public int default_skill1 { get; set; }
	public int default_skill2 { get; set; }
	public int default_skill3 { get; set; }
	public int[] sub_skills { get; set; }
	public int[] trigger_skills { get; set; }
	public int has_unique_skill { get; set; }
	public int[] preload_particle_id_array { get; set; }
	public string ware_house_default_aoc { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65FC30 Offset: 0x65FC30 VA: 0x65FC30
	// RVA: 0x1E0E670 Offset: 0x1E0E670 VA: 0x1E0E670
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC40 Offset: 0x65FC40 VA: 0x65FC40
	// RVA: 0x1E0E678 Offset: 0x1E0E678 VA: 0x1E0E678
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC50 Offset: 0x65FC50 VA: 0x65FC50
	// RVA: 0x1E0E680 Offset: 0x1E0E680 VA: 0x1E0E680
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC60 Offset: 0x65FC60 VA: 0x65FC60
	// RVA: 0x1E0E688 Offset: 0x1E0E688 VA: 0x1E0E688
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC70 Offset: 0x65FC70 VA: 0x65FC70
	// RVA: 0x1E0E690 Offset: 0x1E0E690 VA: 0x1E0E690
	public string get_bag_id_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC80 Offset: 0x65FC80 VA: 0x65FC80
	// RVA: 0x1E0E698 Offset: 0x1E0E698 VA: 0x1E0E698
	private void set_bag_id_index(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FC90 Offset: 0x65FC90 VA: 0x65FC90
	// RVA: 0x1E0E6A0 Offset: 0x1E0E6A0 VA: 0x1E0E6A0
	public int get_name_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCA0 Offset: 0x65FCA0 VA: 0x65FCA0
	// RVA: 0x1E0E6A8 Offset: 0x1E0E6A8 VA: 0x1E0E6A8
	private void set_name_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCB0 Offset: 0x65FCB0 VA: 0x65FCB0
	// RVA: 0x1E0E6B0 Offset: 0x1E0E6B0 VA: 0x1E0E6B0
	public int get_choose_limit() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCC0 Offset: 0x65FCC0 VA: 0x65FCC0
	// RVA: 0x1E0E6B8 Offset: 0x1E0E6B8 VA: 0x1E0E6B8
	private void set_choose_limit(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCD0 Offset: 0x65FCD0 VA: 0x65FCD0
	// RVA: 0x1E0E6C0 Offset: 0x1E0E6C0 VA: 0x1E0E6C0
	public int get_camp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCE0 Offset: 0x65FCE0 VA: 0x65FCE0
	// RVA: 0x1E0E6C8 Offset: 0x1E0E6C8 VA: 0x1E0E6C8
	private void set_camp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FCF0 Offset: 0x65FCF0 VA: 0x65FCF0
	// RVA: 0x1E0E6D0 Offset: 0x1E0E6D0 VA: 0x1E0E6D0
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD00 Offset: 0x65FD00 VA: 0x65FD00
	// RVA: 0x1E0E6D8 Offset: 0x1E0E6D8 VA: 0x1E0E6D8
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD10 Offset: 0x65FD10 VA: 0x65FD10
	// RVA: 0x1E0E6E0 Offset: 0x1E0E6E0 VA: 0x1E0E6E0
	public int get_desc_lang_index() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD20 Offset: 0x65FD20 VA: 0x65FD20
	// RVA: 0x1E0E6E8 Offset: 0x1E0E6E8 VA: 0x1E0E6E8
	private void set_desc_lang_index(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD30 Offset: 0x65FD30 VA: 0x65FD30
	// RVA: 0x1E0E6F0 Offset: 0x1E0E6F0 VA: 0x1E0E6F0
	public int get_available() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD40 Offset: 0x65FD40 VA: 0x65FD40
	// RVA: 0x1E0E6F8 Offset: 0x1E0E6F8 VA: 0x1E0E6F8
	private void set_available(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD50 Offset: 0x65FD50 VA: 0x65FD50
	// RVA: 0x1E0E700 Offset: 0x1E0E700 VA: 0x1E0E700
	public int get_default_head_skin() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD60 Offset: 0x65FD60 VA: 0x65FD60
	// RVA: 0x1E0E708 Offset: 0x1E0E708 VA: 0x1E0E708
	private void set_default_head_skin(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD70 Offset: 0x65FD70 VA: 0x65FD70
	// RVA: 0x1E0E710 Offset: 0x1E0E710 VA: 0x1E0E710
	public int get_default_body_skin() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD80 Offset: 0x65FD80 VA: 0x65FD80
	// RVA: 0x1E0E718 Offset: 0x1E0E718 VA: 0x1E0E718
	private void set_default_body_skin(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FD90 Offset: 0x65FD90 VA: 0x65FD90
	// RVA: 0x1E0E720 Offset: 0x1E0E720 VA: 0x1E0E720
	public string get_icon() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDA0 Offset: 0x65FDA0 VA: 0x65FDA0
	// RVA: 0x1E0E728 Offset: 0x1E0E728 VA: 0x1E0E728
	private void set_icon(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDB0 Offset: 0x65FDB0 VA: 0x65FDB0
	// RVA: 0x1E0E730 Offset: 0x1E0E730 VA: 0x1E0E730
	public string get_pic() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDC0 Offset: 0x65FDC0 VA: 0x65FDC0
	// RVA: 0x1E0E738 Offset: 0x1E0E738 VA: 0x1E0E738
	private void set_pic(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDD0 Offset: 0x65FDD0 VA: 0x65FDD0
	// RVA: 0x1E0E740 Offset: 0x1E0E740 VA: 0x1E0E740
	public int get_sound_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDE0 Offset: 0x65FDE0 VA: 0x65FDE0
	// RVA: 0x1E0E748 Offset: 0x1E0E748 VA: 0x1E0E748
	private void set_sound_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FDF0 Offset: 0x65FDF0 VA: 0x65FDF0
	// RVA: 0x1E0E750 Offset: 0x1E0E750 VA: 0x1E0E750
	public string get_army() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE00 Offset: 0x65FE00 VA: 0x65FE00
	// RVA: 0x1E0E758 Offset: 0x1E0E758 VA: 0x1E0E758
	private void set_army(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE10 Offset: 0x65FE10 VA: 0x65FE10
	// RVA: 0x1E0E760 Offset: 0x1E0E760 VA: 0x1E0E760
	public int get_hp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE20 Offset: 0x65FE20 VA: 0x65FE20
	// RVA: 0x1E0E768 Offset: 0x1E0E768 VA: 0x1E0E768
	private void set_hp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE30 Offset: 0x65FE30 VA: 0x65FE30
	// RVA: 0x1E0E770 Offset: 0x1E0E770 VA: 0x1E0E770
	public int get_dying_hp() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE40 Offset: 0x65FE40 VA: 0x65FE40
	// RVA: 0x1E0E778 Offset: 0x1E0E778 VA: 0x1E0E778
	private void set_dying_hp(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE50 Offset: 0x65FE50 VA: 0x65FE50
	// RVA: 0x1E0E780 Offset: 0x1E0E780 VA: 0x1E0E780
	public int get_dying_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE60 Offset: 0x65FE60 VA: 0x65FE60
	// RVA: 0x1E0E788 Offset: 0x1E0E788 VA: 0x1E0E788
	private void set_dying_time(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE70 Offset: 0x65FE70 VA: 0x65FE70
	// RVA: 0x1E0E790 Offset: 0x1E0E790 VA: 0x1E0E790
	public int get_speed_level() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE80 Offset: 0x65FE80 VA: 0x65FE80
	// RVA: 0x1E0E798 Offset: 0x1E0E798 VA: 0x1E0E798
	private void set_speed_level(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FE90 Offset: 0x65FE90 VA: 0x65FE90
	// RVA: 0x1E0E7A0 Offset: 0x1E0E7A0 VA: 0x1E0E7A0
	public int get_armor_level() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FEA0 Offset: 0x65FEA0 VA: 0x65FEA0
	// RVA: 0x1E0E7A8 Offset: 0x1E0E7A8 VA: 0x1E0E7A8
	private void set_armor_level(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FEB0 Offset: 0x65FEB0 VA: 0x65FEB0
	// RVA: 0x1E0E7B0 Offset: 0x1E0E7B0 VA: 0x1E0E7B0
	public int get_difficulty_level() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FEC0 Offset: 0x65FEC0 VA: 0x65FEC0
	// RVA: 0x1E0E7B8 Offset: 0x1E0E7B8 VA: 0x1E0E7B8
	private void set_difficulty_level(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FED0 Offset: 0x65FED0 VA: 0x65FED0
	// RVA: 0x1E0E7C0 Offset: 0x1E0E7C0 VA: 0x1E0E7C0
	public int[] get_primary_weapon() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FEE0 Offset: 0x65FEE0 VA: 0x65FEE0
	// RVA: 0x1E0E7C8 Offset: 0x1E0E7C8 VA: 0x1E0E7C8
	private void set_primary_weapon(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FEF0 Offset: 0x65FEF0 VA: 0x65FEF0
	// RVA: 0x1E0E7D0 Offset: 0x1E0E7D0 VA: 0x1E0E7D0
	public int[] get_secondary_weapon() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF00 Offset: 0x65FF00 VA: 0x65FF00
	// RVA: 0x1E0E7D8 Offset: 0x1E0E7D8 VA: 0x1E0E7D8
	private void set_secondary_weapon(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF10 Offset: 0x65FF10 VA: 0x65FF10
	// RVA: 0x1E0E7E0 Offset: 0x1E0E7E0 VA: 0x1E0E7E0
	public int[] get_main_skill() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF20 Offset: 0x65FF20 VA: 0x65FF20
	// RVA: 0x1E0E7E8 Offset: 0x1E0E7E8 VA: 0x1E0E7E8
	private void set_main_skill(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF30 Offset: 0x65FF30 VA: 0x65FF30
	// RVA: 0x1E0E7F0 Offset: 0x1E0E7F0 VA: 0x1E0E7F0
	public int get_default_skill1() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF40 Offset: 0x65FF40 VA: 0x65FF40
	// RVA: 0x1E0E7F8 Offset: 0x1E0E7F8 VA: 0x1E0E7F8
	private void set_default_skill1(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF50 Offset: 0x65FF50 VA: 0x65FF50
	// RVA: 0x1E0E800 Offset: 0x1E0E800 VA: 0x1E0E800
	public int get_default_skill2() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF60 Offset: 0x65FF60 VA: 0x65FF60
	// RVA: 0x1E0E808 Offset: 0x1E0E808 VA: 0x1E0E808
	private void set_default_skill2(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF70 Offset: 0x65FF70 VA: 0x65FF70
	// RVA: 0x1E0E810 Offset: 0x1E0E810 VA: 0x1E0E810
	public int get_default_skill3() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF80 Offset: 0x65FF80 VA: 0x65FF80
	// RVA: 0x1E0E818 Offset: 0x1E0E818 VA: 0x1E0E818
	private void set_default_skill3(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FF90 Offset: 0x65FF90 VA: 0x65FF90
	// RVA: 0x1E0E820 Offset: 0x1E0E820 VA: 0x1E0E820
	public int[] get_sub_skills() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFA0 Offset: 0x65FFA0 VA: 0x65FFA0
	// RVA: 0x1E0E828 Offset: 0x1E0E828 VA: 0x1E0E828
	private void set_sub_skills(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFB0 Offset: 0x65FFB0 VA: 0x65FFB0
	// RVA: 0x1E0E830 Offset: 0x1E0E830 VA: 0x1E0E830
	public int[] get_trigger_skills() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFC0 Offset: 0x65FFC0 VA: 0x65FFC0
	// RVA: 0x1E0E838 Offset: 0x1E0E838 VA: 0x1E0E838
	private void set_trigger_skills(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFD0 Offset: 0x65FFD0 VA: 0x65FFD0
	// RVA: 0x1E0E840 Offset: 0x1E0E840 VA: 0x1E0E840
	public int get_has_unique_skill() { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFE0 Offset: 0x65FFE0 VA: 0x65FFE0
	// RVA: 0x1E0E848 Offset: 0x1E0E848 VA: 0x1E0E848
	private void set_has_unique_skill(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65FFF0 Offset: 0x65FFF0 VA: 0x65FFF0
	// RVA: 0x1E0E850 Offset: 0x1E0E850 VA: 0x1E0E850
	public int[] get_preload_particle_id_array() { }

	[CompilerGeneratedAttribute] // RVA: 0x660000 Offset: 0x660000 VA: 0x660000
	// RVA: 0x1E0E858 Offset: 0x1E0E858 VA: 0x1E0E858
	private void set_preload_particle_id_array(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660010 Offset: 0x660010 VA: 0x660010
	// RVA: 0x1E0E860 Offset: 0x1E0E860 VA: 0x1E0E860
	public string get_ware_house_default_aoc() { }

	[CompilerGeneratedAttribute] // RVA: 0x660020 Offset: 0x660020 VA: 0x660020
	// RVA: 0x1E0E868 Offset: 0x1E0E868 VA: 0x1E0E868
	private void set_ware_house_default_aoc(string value) { }

	// RVA: 0x1E0E470 Offset: 0x1E0E470 VA: 0x1E0E470
	internal void .ctor(MemoryStream reader, Action<character_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E0AAF8 Offset: 0x1E0AAF8 VA: 0x1E0AAF8
	internal static bool SetupReadActions(Field[] fields, Action<character_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E0E878 Offset: 0x1E0E878 VA: 0x1E0E878 Slot: 4
	public object Clone() { }
}
