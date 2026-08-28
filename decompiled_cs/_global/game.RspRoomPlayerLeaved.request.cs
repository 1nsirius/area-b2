// Namespace: 
public class game.RspRoomPlayerLeaved.request : SprotoTypeBase // TypeDefIndex: 9377
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _leave_type; // 0x20

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long leave_type { get; set; }
	public bool HasLeave_type { get; }

	// Methods

	// RVA: 0x2264E94 Offset: 0x2264E94 VA: 0x2264E94
	public long get_uid() { }

	// RVA: 0x2264E9C Offset: 0x2264E9C VA: 0x2264E9C
	public void set_uid(long value) { }

	// RVA: 0x2264EE0 Offset: 0x2264EE0 VA: 0x2264EE0
	public bool get_HasUid() { }

	// RVA: 0x2264F10 Offset: 0x2264F10 VA: 0x2264F10
	public long get_leave_type() { }

	// RVA: 0x2264F18 Offset: 0x2264F18 VA: 0x2264F18
	public void set_leave_type(long value) { }

	// RVA: 0x2264F5C Offset: 0x2264F5C VA: 0x2264F5C
	public bool get_HasLeave_type() { }

	// RVA: 0x2264F8C Offset: 0x2264F8C VA: 0x2264F8C
	public void .ctor() { }

	// RVA: 0x2265028 Offset: 0x2265028 VA: 0x2265028
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22650E0 Offset: 0x22650E0 VA: 0x22650E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x22651BC Offset: 0x22651BC VA: 0x22651BC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x22652E0 Offset: 0x22652E0 VA: 0x22652E0 Slot: 3
	public override string ToString() { }

	// RVA: 0x2265390 Offset: 0x2265390 VA: 0x2265390
	private static void .cctor() { }
}
