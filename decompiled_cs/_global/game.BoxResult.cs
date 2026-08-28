// Namespace: 
public class game.BoxResult : SprotoTypeBase // TypeDefIndex: 9203
{
	// Fields
	private static int max_field_count; // 0x0
	private long _box_id; // 0x18
	private long _add_rate; // 0x20
	private long _current_rate; // 0x28

	// Properties
	public long box_id { get; set; }
	public bool HasBox_id { get; }
	public long add_rate { get; set; }
	public bool HasAdd_rate { get; }
	public long current_rate { get; set; }
	public bool HasCurrent_rate { get; }

	// Methods

	// RVA: 0x254D4F8 Offset: 0x254D4F8 VA: 0x254D4F8
	public long get_box_id() { }

	// RVA: 0x254D500 Offset: 0x254D500 VA: 0x254D500
	public void set_box_id(long value) { }

	// RVA: 0x254D544 Offset: 0x254D544 VA: 0x254D544
	public bool get_HasBox_id() { }

	// RVA: 0x254D574 Offset: 0x254D574 VA: 0x254D574
	public long get_add_rate() { }

	// RVA: 0x254D57C Offset: 0x254D57C VA: 0x254D57C
	public void set_add_rate(long value) { }

	// RVA: 0x254D5C0 Offset: 0x254D5C0 VA: 0x254D5C0
	public bool get_HasAdd_rate() { }

	// RVA: 0x254D5F0 Offset: 0x254D5F0 VA: 0x254D5F0
	public long get_current_rate() { }

	// RVA: 0x254D5F8 Offset: 0x254D5F8 VA: 0x254D5F8
	public void set_current_rate(long value) { }

	// RVA: 0x254D63C Offset: 0x254D63C VA: 0x254D63C
	public bool get_HasCurrent_rate() { }

	// RVA: 0x254D66C Offset: 0x254D66C VA: 0x254D66C
	public void .ctor() { }

	// RVA: 0x254D708 Offset: 0x254D708 VA: 0x254D708
	public void .ctor(byte[] buffer) { }

	// RVA: 0x254D7C0 Offset: 0x254D7C0 VA: 0x254D7C0 Slot: 5
	protected override void decode() { }

	// RVA: 0x254D8E4 Offset: 0x254D8E4 VA: 0x254D8E4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x254DA6C Offset: 0x254DA6C VA: 0x254DA6C Slot: 3
	public override string ToString() { }

	// RVA: 0x254DB44 Offset: 0x254DB44 VA: 0x254DB44
	private static void .cctor() { }
}
