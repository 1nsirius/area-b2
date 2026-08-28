// Namespace: 
public class game.CharacterInfo : SprotoTypeBase // TypeDefIndex: 9205
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _cur_primary_weapon; // 0x20
	private List<game.WeaponInfo> _primary_weapons; // 0x28
	private long _cur_secondary_weapon; // 0x30
	private List<game.WeaponInfo> _secondary_weapons; // 0x38
	private long _cur_main_skill; // 0x40
	private List<long> _main_skills; // 0x48
	private long _cur_sub_skill; // 0x50
	private List<long> _sub_skills; // 0x58

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
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

	// RVA: 0x254E4E0 Offset: 0x254E4E0 VA: 0x254E4E0
	public long get_id() { }

	// RVA: 0x254E4E8 Offset: 0x254E4E8 VA: 0x254E4E8
	public void set_id(long value) { }

	// RVA: 0x254E52C Offset: 0x254E52C VA: 0x254E52C
	public bool get_HasId() { }

	// RVA: 0x254E55C Offset: 0x254E55C VA: 0x254E55C
	public long get_cur_primary_weapon() { }

	// RVA: 0x254E564 Offset: 0x254E564 VA: 0x254E564
	public void set_cur_primary_weapon(long value) { }

	// RVA: 0x254E5A8 Offset: 0x254E5A8 VA: 0x254E5A8
	public bool get_HasCur_primary_weapon() { }

	// RVA: 0x254E5D8 Offset: 0x254E5D8 VA: 0x254E5D8
	public List<game.WeaponInfo> get_primary_weapons() { }

	// RVA: 0x254E5E0 Offset: 0x254E5E0 VA: 0x254E5E0
	public void set_primary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x254E620 Offset: 0x254E620 VA: 0x254E620
	public bool get_HasPrimary_weapons() { }

	// RVA: 0x254E650 Offset: 0x254E650 VA: 0x254E650
	public long get_cur_secondary_weapon() { }

	// RVA: 0x254E658 Offset: 0x254E658 VA: 0x254E658
	public void set_cur_secondary_weapon(long value) { }

	// RVA: 0x254E69C Offset: 0x254E69C VA: 0x254E69C
	public bool get_HasCur_secondary_weapon() { }

	// RVA: 0x254E6CC Offset: 0x254E6CC VA: 0x254E6CC
	public List<game.WeaponInfo> get_secondary_weapons() { }

	// RVA: 0x254E6D4 Offset: 0x254E6D4 VA: 0x254E6D4
	public void set_secondary_weapons(List<game.WeaponInfo> value) { }

	// RVA: 0x254E714 Offset: 0x254E714 VA: 0x254E714
	public bool get_HasSecondary_weapons() { }

	// RVA: 0x254E744 Offset: 0x254E744 VA: 0x254E744
	public long get_cur_main_skill() { }

	// RVA: 0x254E74C Offset: 0x254E74C VA: 0x254E74C
	public void set_cur_main_skill(long value) { }

	// RVA: 0x254E790 Offset: 0x254E790 VA: 0x254E790
	public bool get_HasCur_main_skill() { }

	// RVA: 0x254E7C0 Offset: 0x254E7C0 VA: 0x254E7C0
	public List<long> get_main_skills() { }

	// RVA: 0x254E7C8 Offset: 0x254E7C8 VA: 0x254E7C8
	public void set_main_skills(List<long> value) { }

	// RVA: 0x254E808 Offset: 0x254E808 VA: 0x254E808
	public bool get_HasMain_skills() { }

	// RVA: 0x254E838 Offset: 0x254E838 VA: 0x254E838
	public long get_cur_sub_skill() { }

	// RVA: 0x254E840 Offset: 0x254E840 VA: 0x254E840
	public void set_cur_sub_skill(long value) { }

	// RVA: 0x254E884 Offset: 0x254E884 VA: 0x254E884
	public bool get_HasCur_sub_skill() { }

	// RVA: 0x254E8B4 Offset: 0x254E8B4 VA: 0x254E8B4
	public List<long> get_sub_skills() { }

	// RVA: 0x254E8BC Offset: 0x254E8BC VA: 0x254E8BC
	public void set_sub_skills(List<long> value) { }

	// RVA: 0x254E8FC Offset: 0x254E8FC VA: 0x254E8FC
	public bool get_HasSub_skills() { }

	// RVA: 0x254E92C Offset: 0x254E92C VA: 0x254E92C
	public void .ctor() { }

	// RVA: 0x254E9C8 Offset: 0x254E9C8 VA: 0x254E9C8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254EA80 Offset: 0x254EA80 VA: 0x254EA80 Slot: 5
	protected override void decode() { }

	// RVA: 0x254ED3C Offset: 0x254ED3C VA: 0x254ED3C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254F140 Offset: 0x254F140 VA: 0x254F140 Slot: 3
	public override string ToString() { }

	// RVA: 0x254F5E0 Offset: 0x254F5E0 VA: 0x254F5E0
	private static void .cctor() { }
}
