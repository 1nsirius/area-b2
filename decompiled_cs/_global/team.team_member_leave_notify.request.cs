// Namespace: 
public class team.team_member_leave_notify.request : SprotoTypeBase // TypeDefIndex: 9504
{
	// Fields
	private static int max_field_count; // 0x0
	private long _leave_type; // 0x18
	private long _leave_pos; // 0x20
	private long _leave_uid; // 0x28

	// Properties
	public long leave_type { get; set; }
	public bool HasLeave_type { get; }
	public long leave_pos { get; set; }
	public bool HasLeave_pos { get; }
	public long leave_uid { get; set; }
	public bool HasLeave_uid { get; }

	// Methods

	// RVA: 0xD7AA58 Offset: 0xD7AA58 VA: 0xD7AA58
	public long get_leave_type() { }

	// RVA: 0xD7AA60 Offset: 0xD7AA60 VA: 0xD7AA60
	public void set_leave_type(long value) { }

	// RVA: 0xD7AAA4 Offset: 0xD7AAA4 VA: 0xD7AAA4
	public bool get_HasLeave_type() { }

	// RVA: 0xD7AAD4 Offset: 0xD7AAD4 VA: 0xD7AAD4
	public long get_leave_pos() { }

	// RVA: 0xD7AADC Offset: 0xD7AADC VA: 0xD7AADC
	public void set_leave_pos(long value) { }

	// RVA: 0xD7AB20 Offset: 0xD7AB20 VA: 0xD7AB20
	public bool get_HasLeave_pos() { }

	// RVA: 0xD7AB50 Offset: 0xD7AB50 VA: 0xD7AB50
	public long get_leave_uid() { }

	// RVA: 0xD7AB58 Offset: 0xD7AB58 VA: 0xD7AB58
	public void set_leave_uid(long value) { }

	// RVA: 0xD7AB9C Offset: 0xD7AB9C VA: 0xD7AB9C
	public bool get_HasLeave_uid() { }

	// RVA: 0xD7ABCC Offset: 0xD7ABCC VA: 0xD7ABCC
	public void .ctor() { }

	// RVA: 0xD7AC68 Offset: 0xD7AC68 VA: 0xD7AC68
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD7AD20 Offset: 0xD7AD20 VA: 0xD7AD20 Slot: 5
	protected override void decode() { }

	// RVA: 0xD7AE44 Offset: 0xD7AE44 VA: 0xD7AE44 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD7AFCC Offset: 0xD7AFCC VA: 0xD7AFCC Slot: 3
	public override string ToString() { }

	// RVA: 0xD7B0A4 Offset: 0xD7B0A4 VA: 0xD7B0A4
	private static void .cctor() { }
}
