// Namespace: 
public class game.BattleZone : SprotoTypeBase // TypeDefIndex: 9202
{
	// Fields
	private static int max_field_count; // 0x0
	private long _battle_zone_id; // 0x18
	private string _address; // 0x20
	private long _name_key; // 0x28
	private string _battle_region_name; // 0x30

	// Properties
	public long battle_zone_id { get; set; }
	public bool HasBattle_zone_id { get; }
	public string address { get; set; }
	public bool HasAddress { get; }
	public long name_key { get; set; }
	public bool HasName_key { get; }
	public string battle_region_name { get; set; }
	public bool HasBattle_region_name { get; }

	// Methods

	// RVA: 0x254CBFC Offset: 0x254CBFC VA: 0x254CBFC
	public long get_battle_zone_id() { }

	// RVA: 0x254CC04 Offset: 0x254CC04 VA: 0x254CC04
	public void set_battle_zone_id(long value) { }

	// RVA: 0x254CC48 Offset: 0x254CC48 VA: 0x254CC48
	public bool get_HasBattle_zone_id() { }

	// RVA: 0x254CC78 Offset: 0x254CC78 VA: 0x254CC78
	public string get_address() { }

	// RVA: 0x254CC80 Offset: 0x254CC80 VA: 0x254CC80
	public void set_address(string value) { }

	// RVA: 0x254CCC0 Offset: 0x254CCC0 VA: 0x254CCC0
	public bool get_HasAddress() { }

	// RVA: 0x254CCF0 Offset: 0x254CCF0 VA: 0x254CCF0
	public long get_name_key() { }

	// RVA: 0x254CCF8 Offset: 0x254CCF8 VA: 0x254CCF8
	public void set_name_key(long value) { }

	// RVA: 0x254CD3C Offset: 0x254CD3C VA: 0x254CD3C
	public bool get_HasName_key() { }

	// RVA: 0x254CD6C Offset: 0x254CD6C VA: 0x254CD6C
	public string get_battle_region_name() { }

	// RVA: 0x254CD74 Offset: 0x254CD74 VA: 0x254CD74
	public void set_battle_region_name(string value) { }

	// RVA: 0x254CDB4 Offset: 0x254CDB4 VA: 0x254CDB4
	public bool get_HasBattle_region_name() { }

	// RVA: 0x254CDE4 Offset: 0x254CDE4 VA: 0x254CDE4
	public void .ctor() { }

	// RVA: 0x254CE80 Offset: 0x254CE80 VA: 0x254CE80
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254CF38 Offset: 0x254CF38 VA: 0x254CF38 Slot: 5
	protected override void decode() { }

	// RVA: 0x254D08C Offset: 0x254D08C VA: 0x254D08C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254D260 Offset: 0x254D260 VA: 0x254D260 Slot: 3
	public override string ToString() { }

	// RVA: 0x254D490 Offset: 0x254D490 VA: 0x254D490
	private static void .cctor() { }
}
