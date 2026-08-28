// Namespace: 
public class team.operate_ready_req.response : SprotoTypeBase // TypeDefIndex: 9487
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private bool _ready_status; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public bool ready_status { get; set; }
	public bool HasReady_status { get; }

	// Methods

	// RVA: 0xD78130 Offset: 0xD78130 VA: 0xD78130
	public long get_errorcode() { }

	// RVA: 0xD78138 Offset: 0xD78138 VA: 0xD78138
	public void set_errorcode(long value) { }

	// RVA: 0xD7817C Offset: 0xD7817C VA: 0xD7817C
	public bool get_HasErrorcode() { }

	// RVA: 0xD781AC Offset: 0xD781AC VA: 0xD781AC
	public bool get_ready_status() { }

	// RVA: 0xD781B4 Offset: 0xD781B4 VA: 0xD781B4
	public void set_ready_status(bool value) { }

	// RVA: 0xD781F4 Offset: 0xD781F4 VA: 0xD781F4
	public bool get_HasReady_status() { }

	// RVA: 0xD78224 Offset: 0xD78224 VA: 0xD78224
	public void .ctor() { }

	// RVA: 0xD782C0 Offset: 0xD782C0 VA: 0xD782C0
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD78378 Offset: 0xD78378 VA: 0xD78378 Slot: 5
	protected override void decode() { }

	// RVA: 0xD78450 Offset: 0xD78450 VA: 0xD78450 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD78570 Offset: 0xD78570 VA: 0xD78570 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7862C Offset: 0xD7862C VA: 0xD7862C
	private static void .cctor() { }
}
