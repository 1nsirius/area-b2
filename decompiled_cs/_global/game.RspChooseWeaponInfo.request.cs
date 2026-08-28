// Namespace: 
public class game.RspChooseWeaponInfo.request : SprotoTypeBase // TypeDefIndex: 9341
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

	// RVA: 0x225DF7C Offset: 0x225DF7C VA: 0x225DF7C
	public long get_cur_primary_weapon() { }

	// RVA: 0x225DF84 Offset: 0x225DF84 VA: 0x225DF84
	public void set_cur_primary_weapon(long value) { }

	// RVA: 0x225DFC8 Offset: 0x225DFC8 VA: 0x225DFC8
	public bool get_HasCur_primary_weapon() { }

	// RVA: 0x225DFF8 Offset: 0x225DFF8 VA: 0x225DFF8
	public List<game.WeaponInfo> get_primary_weapons() { }

	// RVA: 0x225E000 Offset: 0x225E000 VA: 0x225E000
	public void set_primary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x225E040 Offset: 0x225E040 VA: 0x225E040
	public bool get_HasPrimary_weapons() { }

	// RVA: 0x225E070 Offset: 0x225E070 VA: 0x225E070
	public long get_cur_secondary_weapon() { }

	// RVA: 0x225E078 Offset: 0x225E078 VA: 0x225E078
	public void set_cur_secondary_weapon(long value) { }

	// RVA: 0x225E0BC Offset: 0x225E0BC VA: 0x225E0BC
	public bool get_HasCur_secondary_weapon() { }

	// RVA: 0x225E0EC Offset: 0x225E0EC VA: 0x225E0EC
	public List<game.WeaponInfo> get_secondary_weapons() { }

	// RVA: 0x225E0F4 Offset: 0x225E0F4 VA: 0x225E0F4
	public void set_secondary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x225E134 Offset: 0x225E134 VA: 0x225E134
	public bool get_HasSecondary_weapons() { }

	// RVA: 0x225E164 Offset: 0x225E164 VA: 0x225E164
	public long get_cur_main_skill() { }

	// RVA: 0x225E16C Offset: 0x225E16C VA: 0x225E16C
	public void set_cur_main_skill(long value) { }

	// RVA: 0x225E1B0 Offset: 0x225E1B0 VA: 0x225E1B0
	public bool get_HasCur_main_skill() { }

	// RVA: 0x225E1E0 Offset: 0x225E1E0 VA: 0x225E1E0
	public List<long> get_main_skills() { }

	// RVA: 0x225E1E8 Offset: 0x225E1E8 VA: 0x225E1E8
	public void set_main_skills(List<long> value) { }

	// RVA: 0x225E228 Offset: 0x225E228 VA: 0x225E228
	public bool get_HasMain_skills() { }

	// RVA: 0x225E258 Offset: 0x225E258 VA: 0x225E258
	public long get_cur_sub_skill() { }

	// RVA: 0x225E260 Offset: 0x225E260 VA: 0x225E260
	public void set_cur_sub_skill(long value) { }

	// RVA: 0x225E2A4 Offset: 0x225E2A4 VA: 0x225E2A4
	public bool get_HasCur_sub_skill() { }

	// RVA: 0x225E2D4 Offset: 0x225E2D4 VA: 0x225E2D4
	public List<long> get_sub_skills() { }

	// RVA: 0x225E2DC Offset: 0x225E2DC VA: 0x225E2DC
	public void set_sub_skills(List<long> value) { }

	// RVA: 0x225E31C Offset: 0x225E31C VA: 0x225E31C
	public bool get_HasSub_skills() { }

	// RVA: 0x225E34C Offset: 0x225E34C VA: 0x225E34C
	public void .ctor() { }

	// RVA: 0x225E3E8 Offset: 0x225E3E8 VA: 0x225E3E8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225E4A0 Offset: 0x225E4A0 VA: 0x225E4A0 Slot: 5
	protected override void decode() { }

	// RVA: 0x225E720 Offset: 0x225E720 VA: 0x225E720 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225EAC0 Offset: 0x225EAC0 VA: 0x225EAC0 Slot: 3
	public override string ToString() { }

	// RVA: 0x225EEE8 Offset: 0x225EEE8 VA: 0x225EEE8
	private static void .cctor() { }
}
