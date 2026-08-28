// Namespace: 
public class client.open_box_req.response : SprotoTypeBase // TypeDefIndex: 9139
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _box_id; // 0x20
	private long _count; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long box_id { get; set; }
	public bool HasBox_id { get; }
	public long count { get; set; }
	public bool HasCount { get; }

	// Methods

	// RVA: 0x2444990 Offset: 0x2444990 VA: 0x2444990
	public long get_errorcode() { }

	// RVA: 0x2444998 Offset: 0x2444998 VA: 0x2444998
	public void set_errorcode(long value) { }

	// RVA: 0x24449DC Offset: 0x24449DC VA: 0x24449DC
	public bool get_HasErrorcode() { }

	// RVA: 0x2444A0C Offset: 0x2444A0C VA: 0x2444A0C
	public long get_box_id() { }

	// RVA: 0x2444A14 Offset: 0x2444A14 VA: 0x2444A14
	public void set_box_id(long value) { }

	// RVA: 0x2444A58 Offset: 0x2444A58 VA: 0x2444A58
	public bool get_HasBox_id() { }

	// RVA: 0x2444A88 Offset: 0x2444A88 VA: 0x2444A88
	public long get_count() { }

	// RVA: 0x2444A90 Offset: 0x2444A90 VA: 0x2444A90
	public void set_count(long value) { }

	// RVA: 0x2444AD4 Offset: 0x2444AD4 VA: 0x2444AD4
	public bool get_HasCount() { }

	// RVA: 0x2444B04 Offset: 0x2444B04 VA: 0x2444B04
	public void .ctor() { }

	// RVA: 0x2444BA0 Offset: 0x2444BA0 VA: 0x2444BA0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2444C58 Offset: 0x2444C58 VA: 0x2444C58 Slot: 5
	protected override void decode() { }

	// RVA: 0x2444D7C Offset: 0x2444D7C VA: 0x2444D7C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2444F04 Offset: 0x2444F04 VA: 0x2444F04 Slot: 3
	public override string ToString() { }

	// RVA: 0x2444FDC Offset: 0x2444FDC VA: 0x2444FDC
	private static void .cctor() { }
}
