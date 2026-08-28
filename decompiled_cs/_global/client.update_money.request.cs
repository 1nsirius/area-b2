// Namespace: 
public class client.update_money.request : SprotoTypeBase // TypeDefIndex: 9180
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

	// RVA: 0x2545640 Offset: 0x2545640 VA: 0x2545640
	public string get_type() { }

	// RVA: 0x2545648 Offset: 0x2545648 VA: 0x2545648
	public void set_type(string value) { }

	// RVA: 0x2545688 Offset: 0x2545688 VA: 0x2545688
	public bool get_HasType() { }

	// RVA: 0x25456B8 Offset: 0x25456B8 VA: 0x25456B8
	public long get_value() { }

	// RVA: 0x25456C0 Offset: 0x25456C0 VA: 0x25456C0
	public void set_value(long value) { }

	// RVA: 0x2545704 Offset: 0x2545704 VA: 0x2545704
	public bool get_HasValue() { }

	// RVA: 0x2545734 Offset: 0x2545734 VA: 0x2545734
	public void .ctor() { }

	// RVA: 0x25457D0 Offset: 0x25457D0 VA: 0x25457D0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2545888 Offset: 0x2545888 VA: 0x2545888 Slot: 5
	protected override void decode() { }

	// RVA: 0x2545960 Offset: 0x2545960 VA: 0x2545960 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2545A7C Offset: 0x2545A7C VA: 0x2545A7C Slot: 3
	public override string ToString() { }

	// RVA: 0x2545B18 Offset: 0x2545B18 VA: 0x2545B18
	private static void .cctor() { }
}
