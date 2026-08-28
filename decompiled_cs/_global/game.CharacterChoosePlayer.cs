// Namespace: 
public class game.CharacterChoosePlayer : SprotoTypeBase // TypeDefIndex: 9204
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _bid; // 0x20
	private string _name; // 0x28
	private long _region_id; // 0x30

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long bid { get; set; }
	public bool HasBid { get; }
	public string name { get; set; }
	public bool HasName { get; }
	public long region_id { get; set; }
	public bool HasRegion_id { get; }

	// Methods

	// RVA: 0x254DBAC Offset: 0x254DBAC VA: 0x254DBAC
	public long get_uid() { }

	// RVA: 0x254DBB4 Offset: 0x254DBB4 VA: 0x254DBB4
	public void set_uid(long value) { }

	// RVA: 0x254DBF8 Offset: 0x254DBF8 VA: 0x254DBF8
	public bool get_HasUid() { }

	// RVA: 0x254DC28 Offset: 0x254DC28 VA: 0x254DC28
	public long get_bid() { }

	// RVA: 0x254DC30 Offset: 0x254DC30 VA: 0x254DC30
	public void set_bid(long value) { }

	// RVA: 0x254DC74 Offset: 0x254DC74 VA: 0x254DC74
	public bool get_HasBid() { }

	// RVA: 0x254DCA4 Offset: 0x254DCA4 VA: 0x254DCA4
	public string get_name() { }

	// RVA: 0x254DCAC Offset: 0x254DCAC VA: 0x254DCAC
	public void set_name(string value) { }

	// RVA: 0x254DCEC Offset: 0x254DCEC VA: 0x254DCEC
	public bool get_HasName() { }

	// RVA: 0x254DD1C Offset: 0x254DD1C VA: 0x254DD1C
	public long get_region_id() { }

	// RVA: 0x254DD24 Offset: 0x254DD24 VA: 0x254DD24
	public void set_region_id(long value) { }

	// RVA: 0x254DD68 Offset: 0x254DD68 VA: 0x254DD68
	public bool get_HasRegion_id() { }

	// RVA: 0x254DD98 Offset: 0x254DD98 VA: 0x254DD98
	public void .ctor() { }

	// RVA: 0x254DE34 Offset: 0x254DE34 VA: 0x254DE34
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254DEEC Offset: 0x254DEEC VA: 0x254DEEC Slot: 5
	protected override void decode() { }

	// RVA: 0x254E044 Offset: 0x254E044 VA: 0x254E044 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254E224 Offset: 0x254E224 VA: 0x254E224 Slot: 3
	public override string ToString() { }

	// RVA: 0x254E478 Offset: 0x254E478 VA: 0x254E478
	private static void .cctor() { }
}
