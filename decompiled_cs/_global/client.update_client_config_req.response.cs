// Namespace: 
public class client.update_client_config_req.response : SprotoTypeBase // TypeDefIndex: 9176
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private string _key; // 0x20
	private long _value; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public string key { get; set; }
	public bool HasKey { get; }
	public long value { get; set; }
	public bool HasValue { get; }

	// Methods

	// RVA: 0x2544948 Offset: 0x2544948 VA: 0x2544948
	public long get_errorcode() { }

	// RVA: 0x2544950 Offset: 0x2544950 VA: 0x2544950
	public void set_errorcode(long value) { }

	// RVA: 0x2544994 Offset: 0x2544994 VA: 0x2544994
	public bool get_HasErrorcode() { }

	// RVA: 0x25449C4 Offset: 0x25449C4 VA: 0x25449C4
	public string get_key() { }

	// RVA: 0x25449CC Offset: 0x25449CC VA: 0x25449CC
	public void set_key(string value) { }

	// RVA: 0x2544A0C Offset: 0x2544A0C VA: 0x2544A0C
	public bool get_HasKey() { }

	// RVA: 0x2544A3C Offset: 0x2544A3C VA: 0x2544A3C
	public long get_value() { }

	// RVA: 0x2544A44 Offset: 0x2544A44 VA: 0x2544A44
	public void set_value(long value) { }

	// RVA: 0x2544A88 Offset: 0x2544A88 VA: 0x2544A88
	public bool get_HasValue() { }

	// RVA: 0x2544AB8 Offset: 0x2544AB8 VA: 0x2544AB8
	public void .ctor() { }

	// RVA: 0x2544B54 Offset: 0x2544B54 VA: 0x2544B54
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2544C0C Offset: 0x2544C0C VA: 0x2544C0C Slot: 5
	protected override void decode() { }

	// RVA: 0x2544D2C Offset: 0x2544D2C VA: 0x2544D2C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2544EA8 Offset: 0x2544EA8 VA: 0x2544EA8 Slot: 3
	public override string ToString() { }

	// RVA: 0x2544F68 Offset: 0x2544F68 VA: 0x2544F68
	private static void .cctor() { }
}
