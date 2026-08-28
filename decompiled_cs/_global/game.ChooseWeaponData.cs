// Namespace: 
public class game.ChooseWeaponData : SprotoTypeBase // TypeDefIndex: 9206
{
	// Fields
	private static int max_field_count; // 0x0
	private long _cur_primary_weapon; // 0x18
	private List<game.WeaponInfo> _primary_weapons; // 0x20
	private long _cur_secondary_weapon; // 0x28
	private List<game.WeaponInfo> _secondary_weapons; // 0x30
	private long _cur_main_skill; // 0x38
	private List<long> _main_skills; // 0x40
	private long _cur_sub_skill; // 0x48
	private List<long> _sub_skills; // 0x50

	// Properties
	public long cur_primary_weapon { get; set; }
	public bool HasCur_primary_weapon { get; }
	public List<game.WeaponInfo> primary_weapons { get; set; }
	public bool HasPrimary_weapons { get; }
	public long cur_secondary_weapon { get; set; }
	public bool HasCur_secondary_weapon { get; }
	public List<game.WeaponInfo> secondary_weapons { get; set; }
	public bool HasSecondary_weapons { get; }
	public long cur_main_skill { get; set; }
	public bool HasCur_main_skill { get; }
	public List<long> main_skills { get; set; }
	public bool HasMain_skills { get; }
	public long cur_sub_skill { get; set; }
	public bool HasCur_sub_skill { get; }
	public List<long> sub_skills { get; set; }
	public bool HasSub_skills { get; }

	// Methods

	// RVA: 0x254F648 Offset: 0x254F648 VA: 0x254F648
	public long get_cur_primary_weapon() { }

	// RVA: 0x254F650 Offset: 0x254F650 VA: 0x254F650
	public void set_cur_primary_weapon(long value) { }

	// RVA: 0x254F694 Offset: 0x254F694 VA: 0x254F694
	public bool get_HasCur_primary_weapon() { }

	// RVA: 0x254F6C4 Offset: 0x254F6C4 VA: 0x254F6C4
	public List<game.WeaponInfo> get_primary_weapons() { }

	// RVA: 0x254F6CC Offset: 0x254F6CC VA: 0x254F6CC
	public void set_primary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x254F70C Offset: 0x254F70C VA: 0x254F70C
	public bool get_HasPrimary_weapons() { }

	// RVA: 0x254F73C Offset: 0x254F73C VA: 0x254F73C
	public long get_cur_secondary_weapon() { }

	// RVA: 0x254F744 Offset: 0x254F744 VA: 0x254F744
	public void set_cur_secondary_weapon(long value) { }

	// RVA: 0x254F788 Offset: 0x254F788 VA: 0x254F788
	public bool get_HasCur_secondary_weapon() { }

	// RVA: 0x254F7B8 Offset: 0x254F7B8 VA: 0x254F7B8
	public List<game.WeaponInfo> get_secondary_weapons() { }

	// RVA: 0x254F7C0 Offset: 0x254F7C0 VA: 0x254F7C0
	public void set_secondary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x254F800 Offset: 0x254F800 VA: 0x254F800
	public bool get_HasSecondary_weapons() { }

	// RVA: 0x254F830 Offset: 0x254F830 VA: 0x254F830
	public long get_cur_main_skill() { }

	// RVA: 0x254F838 Offset: 0x254F838 VA: 0x254F838
	public void set_cur_main_skill(long value) { }

	// RVA: 0x254F87C Offset: 0x254F87C VA: 0x254F87C
	public bool get_HasCur_main_skill() { }

	// RVA: 0x254F8AC Offset: 0x254F8AC VA: 0x254F8AC
	public List<long> get_main_skills() { }

	// RVA: 0x254F8B4 Offset: 0x254F8B4 VA: 0x254F8B4
	public void set_main_skills(List<long> value) { }

	// RVA: 0x254F8F4 Offset: 0x254F8F4 VA: 0x254F8F4
	public bool get_HasMain_skills() { }

	// RVA: 0x254F924 Offset: 0x254F924 VA: 0x254F924
	public long get_cur_sub_skill() { }

	// RVA: 0x254F92C Offset: 0x254F92C VA: 0x254F92C
	public void set_cur_sub_skill(long value) { }

	// RVA: 0x254F970 Offset: 0x254F970 VA: 0x254F970
	public bool get_HasCur_sub_skill() { }

	// RVA: 0x254F9A0 Offset: 0x254F9A0 VA: 0x254F9A0
	public List<long> get_sub_skills() { }

	// RVA: 0x254F9A8 Offset: 0x254F9A8 VA: 0x254F9A8
	public void set_sub_skills(List<long> value) { }

	// RVA: 0x254F9E8 Offset: 0x254F9E8 VA: 0x254F9E8
	public bool get_HasSub_skills() { }

	// RVA: 0x254FA18 Offset: 0x254FA18 VA: 0x254FA18
	public void .ctor() { }

	// RVA: 0x254FAB4 Offset: 0x254FAB4 VA: 0x254FAB4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254FB6C Offset: 0x254FB6C VA: 0x254FB6C Slot: 5
	protected override void decode() { }

	// RVA: 0x254FDEC Offset: 0x254FDEC VA: 0x254FDEC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x255018C Offset: 0x255018C VA: 0x255018C Slot: 3
	public override string ToString() { }

	// RVA: 0x25505B4 Offset: 0x25505B4 VA: 0x25505B4
	private static void .cctor() { }
}
