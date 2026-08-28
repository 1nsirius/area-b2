// Namespace: 
public class client.open_box_req.request : SprotoTypeBase // TypeDefIndex: 9138
{
	// Fields
	private static int max_field_count; // 0x0
	private long _box_id; // 0x18
	private long _count; // 0x20

	// Properties
	public long box_id { get; set; }
	public bool HasBox_id { get; }
	public long count { get; set; }
	public bool HasCount { get; }

	// Methods

	// RVA: 0x244442C Offset: 0x244442C VA: 0x244442C
	public long get_box_id() { }

	// RVA: 0x2444434 Offset: 0x2444434 VA: 0x2444434
	public void set_box_id(long value) { }

	// RVA: 0x2444478 Offset: 0x2444478 VA: 0x2444478
	public bool get_HasBox_id() { }

	// RVA: 0x24444A8 Offset: 0x24444A8 VA: 0x24444A8
	public long get_count() { }

	// RVA: 0x24444B0 Offset: 0x24444B0 VA: 0x24444B0
	public void set_count(long value) { }

	// RVA: 0x24444F4 Offset: 0x24444F4 VA: 0x24444F4
	public bool get_HasCount() { }

	// RVA: 0x2444524 Offset: 0x2444524 VA: 0x2444524
	public void .ctor() { }

	// RVA: 0x24445C0 Offset: 0x24445C0 VA: 0x24445C0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2444678 Offset: 0x2444678 VA: 0x2444678 Slot: 5
	protected override void decode() { }

	// RVA: 0x2444754 Offset: 0x2444754 VA: 0x2444754 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2444878 Offset: 0x2444878 VA: 0x2444878 Slot: 3
	public override string ToString() { }

	// RVA: 0x2444928 Offset: 0x2444928 VA: 0x2444928
	private static void .cctor() { }
}
