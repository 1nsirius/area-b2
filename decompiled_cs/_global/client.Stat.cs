// Namespace: 
public class client.Stat : SprotoTypeBase // TypeDefIndex: 9067
{
	// Fields
	private static int max_field_count; // 0x0
	private string _type; // 0x14
	private long _value; // 0x18

	// Properties
	public string type { get; set; }
	public bool HasType { get; }
	public long value { get; set; }
	public bool HasValue { get; }

	// Methods

	// RVA: 0x2434E1C Offset: 0x2434E1C VA: 0x2434E1C
	public string get_type() { }

	// RVA: 0x2434E24 Offset: 0x2434E24 VA: 0x2434E24
	public void set_type(string value) { }

	// RVA: 0x2434E64 Offset: 0x2434E64 VA: 0x2434E64
	public bool get_HasType() { }

	// RVA: 0x2434E94 Offset: 0x2434E94 VA: 0x2434E94
	public long get_value() { }

	// RVA: 0x2434E9C Offset: 0x2434E9C VA: 0x2434E9C
	public void set_value(long value) { }

	// RVA: 0x2434EE0 Offset: 0x2434EE0 VA: 0x2434EE0
	public bool get_HasValue() { }

	// RVA: 0x2434F10 Offset: 0x2434F10 VA: 0x2434F10
	public void .ctor() { }

	// RVA: 0x2434FAC Offset: 0x2434FAC VA: 0x2434FAC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2435064 Offset: 0x2435064 VA: 0x2435064 Slot: 5
	protected override void decode() { }

	// RVA: 0x243513C Offset: 0x243513C VA: 0x243513C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2435258 Offset: 0x2435258 VA: 0x2435258 Slot: 3
	public override string ToString() { }

	// RVA: 0x24352F4 Offset: 0x24352F4 VA: 0x24352F4
	private static void .cctor() { }
}
