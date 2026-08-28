// Namespace: 
public class client.update_client_config_req.request : SprotoTypeBase // TypeDefIndex: 9175
{
	// Fields
	private static int max_field_count; // 0x0
	private string _key; // 0x14
	private long _value; // 0x18

	// Properties
	public string key { get; set; }
	public bool HasKey { get; }
	public long value { get; set; }
	public bool HasValue { get; }

	// Methods

	// RVA: 0x2544408 Offset: 0x2544408 VA: 0x2544408
	public string get_key() { }

	// RVA: 0x2544410 Offset: 0x2544410 VA: 0x2544410
	public void set_key(string value) { }

	// RVA: 0x2544450 Offset: 0x2544450 VA: 0x2544450
	public bool get_HasKey() { }

	// RVA: 0x2544480 Offset: 0x2544480 VA: 0x2544480
	public long get_value() { }

	// RVA: 0x2544488 Offset: 0x2544488 VA: 0x2544488
	public void set_value(long value) { }

	// RVA: 0x25444CC Offset: 0x25444CC VA: 0x25444CC
	public bool get_HasValue() { }

	// RVA: 0x25444FC Offset: 0x25444FC VA: 0x25444FC
	public void .ctor() { }

	// RVA: 0x2544598 Offset: 0x2544598 VA: 0x2544598
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2544650 Offset: 0x2544650 VA: 0x2544650 Slot: 5
	protected override void decode() { }

	// RVA: 0x2544728 Offset: 0x2544728 VA: 0x2544728 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2544844 Offset: 0x2544844 VA: 0x2544844 Slot: 3
	public override string ToString() { }

	// RVA: 0x25448E0 Offset: 0x25448E0 VA: 0x25448E0
	private static void .cctor() { }
}
