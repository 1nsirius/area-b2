// Namespace: 
public class speed_table.Record : ICloneable // TypeDefIndex: 10828
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x572CE4 Offset: 0x572CE4 VA: 0x572CE4
	private int <id>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x572CF4 Offset: 0x572CF4 VA: 0x572CF4
	private string <desc>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x572D04 Offset: 0x572D04 VA: 0x572D04
	private float <stand_speed>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x572D14 Offset: 0x572D14 VA: 0x572D14
	private float <run_speed>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x572D24 Offset: 0x572D24 VA: 0x572D24
	private float <stand_silence_speed>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x572D34 Offset: 0x572D34 VA: 0x572D34
	private float <stand_aim_speed>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x572D44 Offset: 0x572D44 VA: 0x572D44
	private float <crouch_speed>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x572D54 Offset: 0x572D54 VA: 0x572D54
	private float <crouch_silence_speed>k__BackingField; // 0x24
	[CompilerGeneratedAttribute] // RVA: 0x572D64 Offset: 0x572D64 VA: 0x572D64
	private float <crouch_aim_speed>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x572D74 Offset: 0x572D74 VA: 0x572D74
	private float <creep_speed>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x572D84 Offset: 0x572D84 VA: 0x572D84
	private float <agonal_speed>k__BackingField; // 0x30
	[CompilerGeneratedAttribute] // RVA: 0x572D94 Offset: 0x572D94 VA: 0x572D94
	private float <creep_aim_speed>k__BackingField; // 0x34
	[CompilerGeneratedAttribute] // RVA: 0x572DA4 Offset: 0x572DA4 VA: 0x572DA4
	private float <rope_speed>k__BackingField; // 0x38
	[CompilerGeneratedAttribute] // RVA: 0x572DB4 Offset: 0x572DB4 VA: 0x572DB4
	private float <rope_aim_speed>k__BackingField; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x572DC4 Offset: 0x572DC4 VA: 0x572DC4
	private float <rope_up_forward_speed>k__BackingField; // 0x40
	[CompilerGeneratedAttribute] // RVA: 0x572DD4 Offset: 0x572DD4 VA: 0x572DD4
	private float <aim_rope_up_forward_speed>k__BackingField; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x572DE4 Offset: 0x572DE4 VA: 0x572DE4
	private float <rope_up_back_speed>k__BackingField; // 0x48
	[CompilerGeneratedAttribute] // RVA: 0x572DF4 Offset: 0x572DF4 VA: 0x572DF4
	private float <aim_rope_up_back_speed>k__BackingField; // 0x4C
	[CompilerGeneratedAttribute] // RVA: 0x572E04 Offset: 0x572E04 VA: 0x572E04
	private float <rope_down_forward_speed>k__BackingField; // 0x50
	[CompilerGeneratedAttribute] // RVA: 0x572E14 Offset: 0x572E14 VA: 0x572E14
	private float <aim_rope_down_forward_speed>k__BackingField; // 0x54
	[CompilerGeneratedAttribute] // RVA: 0x572E24 Offset: 0x572E24 VA: 0x572E24
	private float <rope_down_back_speed>k__BackingField; // 0x58
	[CompilerGeneratedAttribute] // RVA: 0x572E34 Offset: 0x572E34 VA: 0x572E34
	private float <aim_rope_down_back_speed>k__BackingField; // 0x5C
	[CompilerGeneratedAttribute] // RVA: 0x572E44 Offset: 0x572E44 VA: 0x572E44
	private float <rope_fd_speed>k__BackingField; // 0x60
	[CompilerGeneratedAttribute] // RVA: 0x572E54 Offset: 0x572E54 VA: 0x572E54
	private float <ladder_speed>k__BackingField; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x572E64 Offset: 0x572E64 VA: 0x572E64
	private float <ladder_up_speed>k__BackingField; // 0x68
	[CompilerGeneratedAttribute] // RVA: 0x572E74 Offset: 0x572E74 VA: 0x572E74
	private float <ladder_down_speed>k__BackingField; // 0x6C
	[CompilerGeneratedAttribute] // RVA: 0x572E84 Offset: 0x572E84 VA: 0x572E84
	private float <ladder_fd_speed>k__BackingField; // 0x70

	// Properties
	public int id { get; set; }
	public string desc { get; set; }
	public float stand_speed { get; set; }
	public float run_speed { get; set; }
	public float stand_silence_speed { get; set; }
	public float stand_aim_speed { get; set; }
	public float crouch_speed { get; set; }
	public float crouch_silence_speed { get; set; }
	public float crouch_aim_speed { get; set; }
	public float creep_speed { get; set; }
	public float agonal_speed { get; set; }
	public float creep_aim_speed { get; set; }
	public float rope_speed { get; set; }
	public float rope_aim_speed { get; set; }
	public float rope_up_forward_speed { get; set; }
	public float aim_rope_up_forward_speed { get; set; }
	public float rope_up_back_speed { get; set; }
	public float aim_rope_up_back_speed { get; set; }
	public float rope_down_forward_speed { get; set; }
	public float aim_rope_down_forward_speed { get; set; }
	public float rope_down_back_speed { get; set; }
	public float aim_rope_down_back_speed { get; set; }
	public float rope_fd_speed { get; set; }
	public float ladder_speed { get; set; }
	public float ladder_up_speed { get; set; }
	public float ladder_down_speed { get; set; }
	public float ladder_fd_speed { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x666530 Offset: 0x666530 VA: 0x666530
	// RVA: 0x1F36208 Offset: 0x1F36208 VA: 0x1F36208
	public int get_id() { }

	[CompilerGeneratedAttribute] // RVA: 0x666540 Offset: 0x666540 VA: 0x666540
	// RVA: 0x1F36210 Offset: 0x1F36210 VA: 0x1F36210
	private void set_id(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666550 Offset: 0x666550 VA: 0x666550
	// RVA: 0x1F36218 Offset: 0x1F36218 VA: 0x1F36218
	public string get_desc() { }

	[CompilerGeneratedAttribute] // RVA: 0x666560 Offset: 0x666560 VA: 0x666560
	// RVA: 0x1F36220 Offset: 0x1F36220 VA: 0x1F36220
	private void set_desc(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666570 Offset: 0x666570 VA: 0x666570
	// RVA: 0x1F36228 Offset: 0x1F36228 VA: 0x1F36228
	public float get_stand_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666580 Offset: 0x666580 VA: 0x666580
	// RVA: 0x1F36230 Offset: 0x1F36230 VA: 0x1F36230
	private void set_stand_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666590 Offset: 0x666590 VA: 0x666590
	// RVA: 0x1F36238 Offset: 0x1F36238 VA: 0x1F36238
	public float get_run_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6665A0 Offset: 0x6665A0 VA: 0x6665A0
	// RVA: 0x1F36240 Offset: 0x1F36240 VA: 0x1F36240
	private void set_run_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6665B0 Offset: 0x6665B0 VA: 0x6665B0
	// RVA: 0x1F36248 Offset: 0x1F36248 VA: 0x1F36248
	public float get_stand_silence_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6665C0 Offset: 0x6665C0 VA: 0x6665C0
	// RVA: 0x1F36250 Offset: 0x1F36250 VA: 0x1F36250
	private void set_stand_silence_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6665D0 Offset: 0x6665D0 VA: 0x6665D0
	// RVA: 0x1F36258 Offset: 0x1F36258 VA: 0x1F36258
	public float get_stand_aim_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6665E0 Offset: 0x6665E0 VA: 0x6665E0
	// RVA: 0x1F36260 Offset: 0x1F36260 VA: 0x1F36260
	private void set_stand_aim_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6665F0 Offset: 0x6665F0 VA: 0x6665F0
	// RVA: 0x1F36268 Offset: 0x1F36268 VA: 0x1F36268
	public float get_crouch_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666600 Offset: 0x666600 VA: 0x666600
	// RVA: 0x1F36270 Offset: 0x1F36270 VA: 0x1F36270
	private void set_crouch_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666610 Offset: 0x666610 VA: 0x666610
	// RVA: 0x1F36278 Offset: 0x1F36278 VA: 0x1F36278
	public float get_crouch_silence_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666620 Offset: 0x666620 VA: 0x666620
	// RVA: 0x1F36280 Offset: 0x1F36280 VA: 0x1F36280
	private void set_crouch_silence_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666630 Offset: 0x666630 VA: 0x666630
	// RVA: 0x1F36288 Offset: 0x1F36288 VA: 0x1F36288
	public float get_crouch_aim_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666640 Offset: 0x666640 VA: 0x666640
	// RVA: 0x1F36290 Offset: 0x1F36290 VA: 0x1F36290
	private void set_crouch_aim_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666650 Offset: 0x666650 VA: 0x666650
	// RVA: 0x1F36298 Offset: 0x1F36298 VA: 0x1F36298
	public float get_creep_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666660 Offset: 0x666660 VA: 0x666660
	// RVA: 0x1F362A0 Offset: 0x1F362A0 VA: 0x1F362A0
	private void set_creep_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666670 Offset: 0x666670 VA: 0x666670
	// RVA: 0x1F362A8 Offset: 0x1F362A8 VA: 0x1F362A8
	public float get_agonal_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666680 Offset: 0x666680 VA: 0x666680
	// RVA: 0x1F362B0 Offset: 0x1F362B0 VA: 0x1F362B0
	private void set_agonal_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666690 Offset: 0x666690 VA: 0x666690
	// RVA: 0x1F362B8 Offset: 0x1F362B8 VA: 0x1F362B8
	public float get_creep_aim_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6666A0 Offset: 0x6666A0 VA: 0x6666A0
	// RVA: 0x1F362C0 Offset: 0x1F362C0 VA: 0x1F362C0
	private void set_creep_aim_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6666B0 Offset: 0x6666B0 VA: 0x6666B0
	// RVA: 0x1F362C8 Offset: 0x1F362C8 VA: 0x1F362C8
	public float get_rope_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6666C0 Offset: 0x6666C0 VA: 0x6666C0
	// RVA: 0x1F362D0 Offset: 0x1F362D0 VA: 0x1F362D0
	private void set_rope_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6666D0 Offset: 0x6666D0 VA: 0x6666D0
	// RVA: 0x1F362D8 Offset: 0x1F362D8 VA: 0x1F362D8
	public float get_rope_aim_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6666E0 Offset: 0x6666E0 VA: 0x6666E0
	// RVA: 0x1F362E0 Offset: 0x1F362E0 VA: 0x1F362E0
	private void set_rope_aim_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6666F0 Offset: 0x6666F0 VA: 0x6666F0
	// RVA: 0x1F362E8 Offset: 0x1F362E8 VA: 0x1F362E8
	public float get_rope_up_forward_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666700 Offset: 0x666700 VA: 0x666700
	// RVA: 0x1F362F0 Offset: 0x1F362F0 VA: 0x1F362F0
	private void set_rope_up_forward_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666710 Offset: 0x666710 VA: 0x666710
	// RVA: 0x1F362F8 Offset: 0x1F362F8 VA: 0x1F362F8
	public float get_aim_rope_up_forward_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666720 Offset: 0x666720 VA: 0x666720
	// RVA: 0x1F36300 Offset: 0x1F36300 VA: 0x1F36300
	private void set_aim_rope_up_forward_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666730 Offset: 0x666730 VA: 0x666730
	// RVA: 0x1F36308 Offset: 0x1F36308 VA: 0x1F36308
	public float get_rope_up_back_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666740 Offset: 0x666740 VA: 0x666740
	// RVA: 0x1F36310 Offset: 0x1F36310 VA: 0x1F36310
	private void set_rope_up_back_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666750 Offset: 0x666750 VA: 0x666750
	// RVA: 0x1F36318 Offset: 0x1F36318 VA: 0x1F36318
	public float get_aim_rope_up_back_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666760 Offset: 0x666760 VA: 0x666760
	// RVA: 0x1F36320 Offset: 0x1F36320 VA: 0x1F36320
	private void set_aim_rope_up_back_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666770 Offset: 0x666770 VA: 0x666770
	// RVA: 0x1F36328 Offset: 0x1F36328 VA: 0x1F36328
	public float get_rope_down_forward_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666780 Offset: 0x666780 VA: 0x666780
	// RVA: 0x1F36330 Offset: 0x1F36330 VA: 0x1F36330
	private void set_rope_down_forward_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666790 Offset: 0x666790 VA: 0x666790
	// RVA: 0x1F36338 Offset: 0x1F36338 VA: 0x1F36338
	public float get_aim_rope_down_forward_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6667A0 Offset: 0x6667A0 VA: 0x6667A0
	// RVA: 0x1F36340 Offset: 0x1F36340 VA: 0x1F36340
	private void set_aim_rope_down_forward_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6667B0 Offset: 0x6667B0 VA: 0x6667B0
	// RVA: 0x1F36348 Offset: 0x1F36348 VA: 0x1F36348
	public float get_rope_down_back_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6667C0 Offset: 0x6667C0 VA: 0x6667C0
	// RVA: 0x1F36350 Offset: 0x1F36350 VA: 0x1F36350
	private void set_rope_down_back_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6667D0 Offset: 0x6667D0 VA: 0x6667D0
	// RVA: 0x1F36358 Offset: 0x1F36358 VA: 0x1F36358
	public float get_aim_rope_down_back_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x6667E0 Offset: 0x6667E0 VA: 0x6667E0
	// RVA: 0x1F36360 Offset: 0x1F36360 VA: 0x1F36360
	private void set_aim_rope_down_back_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6667F0 Offset: 0x6667F0 VA: 0x6667F0
	// RVA: 0x1F36368 Offset: 0x1F36368 VA: 0x1F36368
	public float get_rope_fd_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666800 Offset: 0x666800 VA: 0x666800
	// RVA: 0x1F36370 Offset: 0x1F36370 VA: 0x1F36370
	private void set_rope_fd_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666810 Offset: 0x666810 VA: 0x666810
	// RVA: 0x1F36378 Offset: 0x1F36378 VA: 0x1F36378
	public float get_ladder_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666820 Offset: 0x666820 VA: 0x666820
	// RVA: 0x1F36380 Offset: 0x1F36380 VA: 0x1F36380
	private void set_ladder_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666830 Offset: 0x666830 VA: 0x666830
	// RVA: 0x1F36388 Offset: 0x1F36388 VA: 0x1F36388
	public float get_ladder_up_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666840 Offset: 0x666840 VA: 0x666840
	// RVA: 0x1F36390 Offset: 0x1F36390 VA: 0x1F36390
	private void set_ladder_up_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666850 Offset: 0x666850 VA: 0x666850
	// RVA: 0x1F36398 Offset: 0x1F36398 VA: 0x1F36398
	public float get_ladder_down_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666860 Offset: 0x666860 VA: 0x666860
	// RVA: 0x1F363A0 Offset: 0x1F363A0 VA: 0x1F363A0
	private void set_ladder_down_speed(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x666870 Offset: 0x666870 VA: 0x666870
	// RVA: 0x1F363A8 Offset: 0x1F363A8 VA: 0x1F363A8
	public float get_ladder_fd_speed() { }

	[CompilerGeneratedAttribute] // RVA: 0x666880 Offset: 0x666880 VA: 0x666880
	// RVA: 0x1F363B0 Offset: 0x1F363B0 VA: 0x1F363B0
	private void set_ladder_fd_speed(float value) { }

	// RVA: 0x1F36008 Offset: 0x1F36008 VA: 0x1F36008
	internal void .ctor(MemoryStream reader, Action<speed_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F32EC4 Offset: 0x1F32EC4 VA: 0x1F32EC4
	internal static bool SetupReadActions(Field[] fields, Action<speed_table.Record, MemoryStream>[] readActions) { }

	// RVA: 0x1F363C0 Offset: 0x1F363C0 VA: 0x1F363C0 Slot: 4
	public object Clone() { }
}
