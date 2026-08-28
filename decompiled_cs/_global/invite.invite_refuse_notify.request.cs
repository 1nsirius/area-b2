// Namespace: 
public class invite.invite_refuse_notify.request : SprotoTypeBase // TypeDefIndex: 9420
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _type; // 0x20

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long type { get; set; }
	public bool HasType { get; }

	// Methods

	// RVA: 0x226EAC0 Offset: 0x226EAC0 VA: 0x226EAC0
	public long get_uid() { }

	// RVA: 0x226EAC8 Offset: 0x226EAC8 VA: 0x226EAC8
	public void set_uid(long value) { }

	// RVA: 0x226EB0C Offset: 0x226EB0C VA: 0x226EB0C
	public bool get_HasUid() { }

	// RVA: 0x226EB3C Offset: 0x226EB3C VA: 0x226EB3C
	public long get_type() { }

	// RVA: 0x226EB44 Offset: 0x226EB44 VA: 0x226EB44
	public void set_type(long value) { }

	// RVA: 0x226EB88 Offset: 0x226EB88 VA: 0x226EB88
	public bool get_HasType() { }

	// RVA: 0x226EBB8 Offset: 0x226EBB8 VA: 0x226EBB8
	public void .ctor() { }

	// RVA: 0x226EC54 Offset: 0x226EC54 VA: 0x226EC54
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226ED0C Offset: 0x226ED0C VA: 0x226ED0C Slot: 5
	protected override void decode() { }

	// RVA: 0x226EDE8 Offset: 0x226EDE8 VA: 0x226EDE8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226EF0C Offset: 0x226EF0C VA: 0x226EF0C Slot: 3
	public override string ToString() { }

	// RVA: 0x226EFBC Offset: 0x226EFBC VA: 0x226EFBC
	private static void .cctor() { }
}
