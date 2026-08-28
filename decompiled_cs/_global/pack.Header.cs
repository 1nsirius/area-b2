// Namespace: 
public class pack.Header : SprotoTypeBase // TypeDefIndex: 9454
{
	// Fields
	private static int max_field_count; // 0x0
	private long _type; // 0x18
	private long _session; // 0x20
	private long _ud; // 0x28

	// Properties
	public long type { get; set; }
	public bool HasType { get; }
	public long session { get; set; }
	public bool HasSession { get; }
	public long ud { get; set; }
	public bool HasUd { get; }

	// Methods

	// RVA: 0xD70950 Offset: 0xD70950 VA: 0xD70950
	public long get_type() { }

	// RVA: 0xD70958 Offset: 0xD70958 VA: 0xD70958
	public void set_type(long value) { }

	// RVA: 0xD7099C Offset: 0xD7099C VA: 0xD7099C
	public bool get_HasType() { }

	// RVA: 0xD709CC Offset: 0xD709CC VA: 0xD709CC
	public long get_session() { }

	// RVA: 0xD709D4 Offset: 0xD709D4 VA: 0xD709D4
	public void set_session(long value) { }

	// RVA: 0xD70A18 Offset: 0xD70A18 VA: 0xD70A18
	public bool get_HasSession() { }

	// RVA: 0xD70A48 Offset: 0xD70A48 VA: 0xD70A48
	public long get_ud() { }

	// RVA: 0xD70A50 Offset: 0xD70A50 VA: 0xD70A50
	public void set_ud(long value) { }

	// RVA: 0xD70A94 Offset: 0xD70A94 VA: 0xD70A94
	public bool get_HasUd() { }

	// RVA: 0xD70AC4 Offset: 0xD70AC4 VA: 0xD70AC4
	public void .ctor() { }

	// RVA: 0xD70B60 Offset: 0xD70B60 VA: 0xD70B60
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD70C18 Offset: 0xD70C18 VA: 0xD70C18 Slot: 5
	protected override void decode() { }

	// RVA: 0xD70D3C Offset: 0xD70D3C VA: 0xD70D3C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD70EC4 Offset: 0xD70EC4 VA: 0xD70EC4 Slot: 3
	public override string ToString() { }

	// RVA: 0xD70F9C Offset: 0xD70F9C VA: 0xD70F9C
	private static void .cctor() { }
}
