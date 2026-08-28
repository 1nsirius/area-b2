// Namespace: 
public class content_table.Record : ICloneable // TypeDefIndex: 10616
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56FDE4 Offset: 0x56FDE4 VA: 0x56FDE4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56FDF4 Offset: 0x56FDF4 VA: 0x56FDF4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56FE04 Offset: 0x56FE04 VA: 0x56FE04
	private string <name>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x56FE14 Offset: 0x56FE14 VA: 0x56FE14
	private string <model_path>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x56FE24 Offset: 0x56FE24 VA: 0x56FE24
	private int <trigger_id>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56FE34 Offset: 0x56FE34 VA: 0x56FE34
	private int <type>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56FE44 Offset: 0x56FE44 VA: 0x56FE44
	private int <remote_control>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56FE54 Offset: 0x56FE54 VA: 0x56FE54
	private float <last_time>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x56FE64 Offset: 0x56FE64 VA: 0x56FE64
	private float <delay_time>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x56FE74 Offset: 0x56FE74 VA: 0x56FE74
	private int <visible>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x56FE84 Offset: 0x56FE84 VA: 0x56FE84
	private int <sorbable>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x56FE94 Offset: 0x56FE94 VA: 0x56FE94
	private int <recyclable>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x56FEA4 Offset: 0x56FEA4 VA: 0x56FEA4
	private int <is_explosive>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x56FEB4 Offset: 0x56FEB4 VA: 0x56FEB4
	private int[] <effect_id>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56FEC4 Offset: 0x56FEC4 VA: 0x56FEC4
	private int <bullet>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x56FED4 Offset: 0x56FED4 VA: 0x56FED4
	private int <scene_hp_id>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x56FEE4 Offset: 0x56FEE4 VA: 0x56FEE4
	private int <trigger_particle_id>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x56FEF4 Offset: 0x56FEF4 VA: 0x56FEF4
	private int <effect_particle_id>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x56FF04 Offset: 0x56FF04 VA: 0x56FF04
	private int <place_particle_id>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x56FF14 Offset: 0x56FF14 VA: 0x56FF14
	private int <destroyed_particle_id>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x56FF24 Offset: 0x56FF24 VA: 0x56FF24
	private string <scene_img>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x56FF34 Offset: 0x56FF34 VA: 0x56FF34
	private int <out_screen_display>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x56FF44 Offset: 0x56FF44 VA: 0x56FF44
	private string <scene_active_uiprefab>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x56FF54 Offset: 0x56FF54 VA: 0x56FF54
	private float <scene_img_y_shift>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x56FF64 Offset: 0x56FF64 VA: 0x56FF64
	private float <scene_active_y_shift>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x56FF74 Offset: 0x56FF74 VA: 0x56FF74
	private int <scene_quantity_limit>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x56FF84 Offset: 0x56FF84 VA: 0x56FF84
	private int <allow_reset_item>k__BackingField; // 0x70

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public string name { get; set; }
	public string model_path { get; set; }
	public int trigger_id { get; set; }
	public int type { get; set; }
	public int remote_control { get; set; }
	public float last_time { get; set; }
	public float delay_time { get; set; }
	public int visible { get; set; }
	public int sorbable { get; set; }
	public int recyclable { get; set; }
	public int is_explosive { get; set; }
	public int[] effect_id { get; set; }
	public int bullet { get; set; }
	public int scene_hp_id { get; set; }
	public int trigger_particle_id { get; set; }
	public int effect_particle_id { get; set; }
	public int place_particle_id { get; set; }
	public int destroyed_particle_id { get; set; }
	public string scene_img { get; set; }
	public int out_screen_display { get; set; }
	public string scene_active_uiprefab { get; set; }
	public float scene_img_y_shift { get; set; }
	public float scene_active_y_shift { get; set; }
	public int scene_quantity_limit { get; set; }
	public int allow_reset_item { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x660730 Offset: 0x660730 VA: 0x660730
	// RVA: 0x1E6A824 Offset: 0x1E6A824 VA: 0x1E6A824
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660740 Offset: 0x660740 VA: 0x660740
	// RVA: 0x1E6A82C Offset: 0x1E6A82C VA: 0x1E6A82C
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660750 Offset: 0x660750 VA: 0x660750
	// RVA: 0x1E6A834 Offset: 0x1E6A834 VA: 0x1E6A834
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x660760 Offset: 0x660760 VA: 0x660760
	// RVA: 0x1E6A83C Offset: 0x1E6A83C VA: 0x1E6A83C
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660770 Offset: 0x660770 VA: 0x660770
	// RVA: 0x1E6A844 Offset: 0x1E6A844 VA: 0x1E6A844
	public string get_name() { }

	[CompilerGeneratedAttribute] // RVA: 0x660780 Offset: 0x660780 VA: 0x660780
	// RVA: 0x1E6A84C Offset: 0x1E6A84C VA: 0x1E6A84C
	private void set_name(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660790 Offset: 0x660790 VA: 0x660790
	// RVA: 0x1E6A854 Offset: 0x1E6A854 VA: 0x1E6A854
	public string get_model_path() { }

	[CompilerGeneratedAttribute] // RVA: 0x6607A0 Offset: 0x6607A0 VA: 0x6607A0
	// RVA: 0x1E6A85C Offset: 0x1E6A85C VA: 0x1E6A85C
	private void set_model_path(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6607B0 Offset: 0x6607B0 VA: 0x6607B0
	// RVA: 0x1E6A864 Offset: 0x1E6A864 VA: 0x1E6A864
	public int get_trigger_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6607C0 Offset: 0x6607C0 VA: 0x6607C0
	// RVA: 0x1E6A86C Offset: 0x1E6A86C VA: 0x1E6A86C
	private void set_trigger_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6607D0 Offset: 0x6607D0 VA: 0x6607D0
	// RVA: 0x1E6A874 Offset: 0x1E6A874 VA: 0x1E6A874
	public int get_type() { }

	[CompilerGeneratedAttribute] // RVA: 0x6607E0 Offset: 0x6607E0 VA: 0x6607E0
	// RVA: 0x1E6A87C Offset: 0x1E6A87C VA: 0x1E6A87C
	private void set_type(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6607F0 Offset: 0x6607F0 VA: 0x6607F0
	// RVA: 0x1E6A884 Offset: 0x1E6A884 VA: 0x1E6A884
	public int get_remote_control() { }

	[CompilerGeneratedAttribute] // RVA: 0x660800 Offset: 0x660800 VA: 0x660800
	// RVA: 0x1E6A88C Offset: 0x1E6A88C VA: 0x1E6A88C
	private void set_remote_control(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660810 Offset: 0x660810 VA: 0x660810
	// RVA: 0x1E6A894 Offset: 0x1E6A894 VA: 0x1E6A894
	public float get_last_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x660820 Offset: 0x660820 VA: 0x660820
	// RVA: 0x1E6A89C Offset: 0x1E6A89C VA: 0x1E6A89C
	private void set_last_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660830 Offset: 0x660830 VA: 0x660830
	// RVA: 0x1E6A8A4 Offset: 0x1E6A8A4 VA: 0x1E6A8A4
	public float get_delay_time() { }

	[CompilerGeneratedAttribute] // RVA: 0x660840 Offset: 0x660840 VA: 0x660840
	// RVA: 0x1E6A8AC Offset: 0x1E6A8AC VA: 0x1E6A8AC
	private void set_delay_time(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660850 Offset: 0x660850 VA: 0x660850
	// RVA: 0x1E6A8B4 Offset: 0x1E6A8B4 VA: 0x1E6A8B4
	public int get_visible() { }

	[CompilerGeneratedAttribute] // RVA: 0x660860 Offset: 0x660860 VA: 0x660860
	// RVA: 0x1E6A8BC Offset: 0x1E6A8BC VA: 0x1E6A8BC
	private void set_visible(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660870 Offset: 0x660870 VA: 0x660870
	// RVA: 0x1E6A8C4 Offset: 0x1E6A8C4 VA: 0x1E6A8C4
	public int get_sorbable() { }

	[CompilerGeneratedAttribute] // RVA: 0x660880 Offset: 0x660880 VA: 0x660880
	// RVA: 0x1E6A8CC Offset: 0x1E6A8CC VA: 0x1E6A8CC
	private void set_sorbable(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660890 Offset: 0x660890 VA: 0x660890
	// RVA: 0x1E6A8D4 Offset: 0x1E6A8D4 VA: 0x1E6A8D4
	public int get_recyclable() { }

	[CompilerGeneratedAttribute] // RVA: 0x6608A0 Offset: 0x6608A0 VA: 0x6608A0
	// RVA: 0x1E6A8DC Offset: 0x1E6A8DC VA: 0x1E6A8DC
	private void set_recyclable(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6608B0 Offset: 0x6608B0 VA: 0x6608B0
	// RVA: 0x1E6A8E4 Offset: 0x1E6A8E4 VA: 0x1E6A8E4
	public int get_is_explosive() { }

	[CompilerGeneratedAttribute] // RVA: 0x6608C0 Offset: 0x6608C0 VA: 0x6608C0
	// RVA: 0x1E6A8EC Offset: 0x1E6A8EC VA: 0x1E6A8EC
	private void set_is_explosive(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6608D0 Offset: 0x6608D0 VA: 0x6608D0
	// RVA: 0x1E6A8F4 Offset: 0x1E6A8F4 VA: 0x1E6A8F4
	public int[] get_effect_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6608E0 Offset: 0x6608E0 VA: 0x6608E0
	// RVA: 0x1E6A8FC Offset: 0x1E6A8FC VA: 0x1E6A8FC
	private void set_effect_id(int[] value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6608F0 Offset: 0x6608F0 VA: 0x6608F0
	// RVA: 0x1E6A904 Offset: 0x1E6A904 VA: 0x1E6A904
	public int get_bullet() { }

	[CompilerGeneratedAttribute] // RVA: 0x660900 Offset: 0x660900 VA: 0x660900
	// RVA: 0x1E6A90C Offset: 0x1E6A90C VA: 0x1E6A90C
	private void set_bullet(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660910 Offset: 0x660910 VA: 0x660910
	// RVA: 0x1E6A914 Offset: 0x1E6A914 VA: 0x1E6A914
	public int get_scene_hp_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660920 Offset: 0x660920 VA: 0x660920
	// RVA: 0x1E6A91C Offset: 0x1E6A91C VA: 0x1E6A91C
	private void set_scene_hp_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660930 Offset: 0x660930 VA: 0x660930
	// RVA: 0x1E6A924 Offset: 0x1E6A924 VA: 0x1E6A924
	public int get_trigger_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660940 Offset: 0x660940 VA: 0x660940
	// RVA: 0x1E6A92C Offset: 0x1E6A92C VA: 0x1E6A92C
	private void set_trigger_particle_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660950 Offset: 0x660950 VA: 0x660950
	// RVA: 0x1E6A934 Offset: 0x1E6A934 VA: 0x1E6A934
	public int get_effect_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660960 Offset: 0x660960 VA: 0x660960
	// RVA: 0x1E6A93C Offset: 0x1E6A93C VA: 0x1E6A93C
	private void set_effect_particle_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660970 Offset: 0x660970 VA: 0x660970
	// RVA: 0x1E6A944 Offset: 0x1E6A944 VA: 0x1E6A944
	public int get_place_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x660980 Offset: 0x660980 VA: 0x660980
	// RVA: 0x1E6A94C Offset: 0x1E6A94C VA: 0x1E6A94C
	private void set_place_particle_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660990 Offset: 0x660990 VA: 0x660990
	// RVA: 0x1E6A954 Offset: 0x1E6A954 VA: 0x1E6A954
	public int get_destroyed_particle_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x6609A0 Offset: 0x6609A0 VA: 0x6609A0
	// RVA: 0x1E6A95C Offset: 0x1E6A95C VA: 0x1E6A95C
	private void set_destroyed_particle_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6609B0 Offset: 0x6609B0 VA: 0x6609B0
	// RVA: 0x1E6A964 Offset: 0x1E6A964 VA: 0x1E6A964
	public string get_scene_img() { }

	[CompilerGeneratedAttribute] // RVA: 0x6609C0 Offset: 0x6609C0 VA: 0x6609C0
	// RVA: 0x1E6A96C Offset: 0x1E6A96C VA: 0x1E6A96C
	private void set_scene_img(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6609D0 Offset: 0x6609D0 VA: 0x6609D0
	// RVA: 0x1E6A974 Offset: 0x1E6A974 VA: 0x1E6A974
	public int get_out_screen_display() { }

	[CompilerGeneratedAttribute] // RVA: 0x6609E0 Offset: 0x6609E0 VA: 0x6609E0
	// RVA: 0x1E6A97C Offset: 0x1E6A97C VA: 0x1E6A97C
	private void set_out_screen_display(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6609F0 Offset: 0x6609F0 VA: 0x6609F0
	// RVA: 0x1E6A984 Offset: 0x1E6A984 VA: 0x1E6A984
	public string get_scene_active_uiprefab() { }

	[CompilerGeneratedAttribute] // RVA: 0x660A00 Offset: 0x660A00 VA: 0x660A00
	// RVA: 0x1E6A98C Offset: 0x1E6A98C VA: 0x1E6A98C
	private void set_scene_active_uiprefab(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660A10 Offset: 0x660A10 VA: 0x660A10
	// RVA: 0x1E6A994 Offset: 0x1E6A994 VA: 0x1E6A994
	public float get_scene_img_y_shift() { }

	[CompilerGeneratedAttribute] // RVA: 0x660A20 Offset: 0x660A20 VA: 0x660A20
	// RVA: 0x1E6A99C Offset: 0x1E6A99C VA: 0x1E6A99C
	private void set_scene_img_y_shift(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660A30 Offset: 0x660A30 VA: 0x660A30
	// RVA: 0x1E6A9A4 Offset: 0x1E6A9A4 VA: 0x1E6A9A4
	public float get_scene_active_y_shift() { }

	[CompilerGeneratedAttribute] // RVA: 0x660A40 Offset: 0x660A40 VA: 0x660A40
	// RVA: 0x1E6A9AC Offset: 0x1E6A9AC VA: 0x1E6A9AC
	private void set_scene_active_y_shift(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660A50 Offset: 0x660A50 VA: 0x660A50
	// RVA: 0x1E6A9B4 Offset: 0x1E6A9B4 VA: 0x1E6A9B4
	public int get_scene_quantity_limit() { }

	[CompilerGeneratedAttribute] // RVA: 0x660A60 Offset: 0x660A60 VA: 0x660A60
	// RVA: 0x1E6A9BC Offset: 0x1E6A9BC VA: 0x1E6A9BC
	private void set_scene_quantity_limit(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x660A70 Offset: 0x660A70 VA: 0x660A70
	// RVA: 0x1E6A9C4 Offset: 0x1E6A9C4 VA: 0x1E6A9C4
	public int get_allow_reset_item() { }

	[CompilerGeneratedAttribute] // RVA: 0x660A80 Offset: 0x660A80 VA: 0x660A80
	// RVA: 0x1E6A9CC Offset: 0x1E6A9CC VA: 0x1E6A9CC
	private void set_allow_reset_item(int value) { }

	// RVA: 0x1E6A624 Offset: 0x1E6A624 VA: 0x1E6A624
	internal void .ctor(MemoryStream reader, Action<content_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E674E0 Offset: 0x1E674E0 VA: 0x1E674E0
	internal static bool SetupReadActions(Field[] fields, Action<content_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1E6A9DC Offset: 0x1E6A9DC VA: 0x1E6A9DC Slot: 4
	public object Clone() { }
}
