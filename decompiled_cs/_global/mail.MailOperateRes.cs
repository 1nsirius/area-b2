// Namespace: 
public class mail.MailOperateRes : SprotoTypeBase // TypeDefIndex: 9429
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _errorcode; // 0x20

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }

	// Methods

	// RVA: 0x2271B20 Offset: 0x2271B20 VA: 0x2271B20
	public long get_id() { }

	// RVA: 0x2271B28 Offset: 0x2271B28 VA: 0x2271B28
	public void set_id(long value) { }

	// RVA: 0x2271B6C Offset: 0x2271B6C VA: 0x2271B6C
	public bool get_HasId() { }

	// RVA: 0x2271B9C Offset: 0x2271B9C VA: 0x2271B9C
	public long get_errorcode() { }

	// RVA: 0x2271BA4 Offset: 0x2271BA4 VA: 0x2271BA4
	public void set_errorcode(long value) { }

	// RVA: 0x2271BE8 Offset: 0x2271BE8 VA: 0x2271BE8
	public bool get_HasErrorcode() { }

	// RVA: 0x2271C18 Offset: 0x2271C18 VA: 0x2271C18
	public void .ctor() { }

	// RVA: 0x2271CB4 Offset: 0x2271CB4 VA: 0x2271CB4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2271D6C Offset: 0x2271D6C VA: 0x2271D6C Slot: 5
	protected override void decode() { }

	// RVA: 0x2271E48 Offset: 0x2271E48 VA: 0x2271E48 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2271F70 Offset: 0x2271F70 VA: 0x2271F70 Slot: 3
	public override string ToString() { }

	// RVA: 0x2272020 Offset: 0x2272020 VA: 0x2272020
	private static void .cctor() { }
}
