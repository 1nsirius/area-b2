// Namespace: 
public class team.kick_member_req.response : SprotoTypeBase // TypeDefIndex: 9471
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _kick_pos; // 0x20
	private long _kick_uid; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long kick_pos { get; set; }
	public bool HasKick_pos { get; }
	public long kick_uid { get; set; }
	public bool HasKick_uid { get; }

	// Methods

	// RVA: 0xD75BC0 Offset: 0xD75BC0 VA: 0xD75BC0
	public long get_errorcode() { }

	// RVA: 0xD75BC8 Offset: 0xD75BC8 VA: 0xD75BC8
	public void set_errorcode(long value) { }

	// RVA: 0xD75C0C Offset: 0xD75C0C VA: 0xD75C0C
	public bool get_HasErrorcode() { }

	// RVA: 0xD75C3C Offset: 0xD75C3C VA: 0xD75C3C
	public long get_kick_pos() { }

	// RVA: 0xD75C44 Offset: 0xD75C44 VA: 0xD75C44
	public void set_kick_pos(long value) { }

	// RVA: 0xD75C88 Offset: 0xD75C88 VA: 0xD75C88
	public bool get_HasKick_pos() { }

	// RVA: 0xD75CB8 Offset: 0xD75CB8 VA: 0xD75CB8
	public long get_kick_uid() { }

	// RVA: 0xD75CC0 Offset: 0xD75CC0 VA: 0xD75CC0
	public void set_kick_uid(long value) { }

	// RVA: 0xD75D04 Offset: 0xD75D04 VA: 0xD75D04
	public bool get_HasKick_uid() { }

	// RVA: 0xD75D34 Offset: 0xD75D34 VA: 0xD75D34
	public void .ctor() { }

	// RVA: 0xD75DD0 Offset: 0xD75DD0 VA: 0xD75DD0
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD75E88 Offset: 0xD75E88 VA: 0xD75E88 Slot: 5
	protected override void decode() { }

	// RVA: 0xD75FAC Offset: 0xD75FAC VA: 0xD75FAC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD76134 Offset: 0xD76134 VA: 0xD76134 Slot: 3
	public override string ToString() { }

	// RVA: 0xD7620C Offset: 0xD7620C VA: 0xD7620C
	private static void .cctor() { }
}
