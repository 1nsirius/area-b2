// Namespace: 
public class client.update_event_stat_notify.request : SprotoTypeBase // TypeDefIndex: 9178
{
	// Fields
	private static int max_field_count; // 0x0
	private string _event_type; // 0x14
	private string _type; // 0x18
	private long _value; // 0x20

	// Properties
	public string event_type { get; set; }
	public bool HasEvent_type { get; }
	public string type { get; set; }
	public bool HasType { get; }
	public long value { get; set; }
	public bool HasValue { get; }

	// Methods

	// RVA: 0x2544FD8 Offset: 0x2544FD8 VA: 0x2544FD8
	public string get_event_type() { }

	// RVA: 0x2544FE0 Offset: 0x2544FE0 VA: 0x2544FE0
	public void set_event_type(string value) { }

	// RVA: 0x2545020 Offset: 0x2545020 VA: 0x2545020
	public bool get_HasEvent_type() { }

	// RVA: 0x2545050 Offset: 0x2545050 VA: 0x2545050
	public string get_type() { }

	// RVA: 0x2545058 Offset: 0x2545058 VA: 0x2545058
	public void set_type(string value) { }

	// RVA: 0x2545098 Offset: 0x2545098 VA: 0x2545098
	public bool get_HasType() { }

	// RVA: 0x25450C8 Offset: 0x25450C8 VA: 0x25450C8
	public long get_value() { }

	// RVA: 0x25450D0 Offset: 0x25450D0 VA: 0x25450D0
	public void set_value(long value) { }

	// RVA: 0x2545114 Offset: 0x2545114 VA: 0x2545114
	public bool get_HasValue() { }

	// RVA: 0x2545144 Offset: 0x2545144 VA: 0x2545144
	public void .ctor() { }

	// RVA: 0x25451E0 Offset: 0x25451E0 VA: 0x25451E0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2545298 Offset: 0x2545298 VA: 0x2545298 Slot: 5
	protected override void decode() { }

	// RVA: 0x25453B4 Offset: 0x25453B4 VA: 0x25453B4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2545528 Offset: 0x2545528 VA: 0x2545528 Slot: 3
	public override string ToString() { }

	// RVA: 0x25455D0 Offset: 0x25455D0 VA: 0x25455D0
	private static void .cctor() { }
}
