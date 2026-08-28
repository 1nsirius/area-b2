// Namespace: 
public class team.kick_member_req.request : SprotoTypeBase // TypeDefIndex: 9470
{
	// Fields
	private static int max_field_count; // 0x0
	private long _kick_pos; // 0x18
	private long _kick_uid; // 0x20

	// Properties
	public long kick_pos { get; set; }
	public bool HasKick_pos { get; }
	public long kick_uid { get; set; }
	public bool HasKick_uid { get; }

	// Methods

	// RVA: 0xD7565C Offset: 0xD7565C VA: 0xD7565C
	public long get_kick_pos() { }

	// RVA: 0xD75664 Offset: 0xD75664 VA: 0xD75664
	public void set_kick_pos(long value) { }

	// RVA: 0xD756A8 Offset: 0xD756A8 VA: 0xD756A8
	public bool get_HasKick_pos() { }

	// RVA: 0xD756D8 Offset: 0xD756D8 VA: 0xD756D8
	public long get_kick_uid() { }

	// RVA: 0xD756E0 Offset: 0xD756E0 VA: 0xD756E0
	public void set_kick_uid(long value) { }

	// RVA: 0xD75724 Offset: 0xD75724 VA: 0xD75724
	public bool get_HasKick_uid() { }

	// RVA: 0xD75754 Offset: 0xD75754 VA: 0xD75754
	public void .ctor() { }

	// RVA: 0xD757F0 Offset: 0xD757F0 VA: 0xD757F0
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD758A8 Offset: 0xD758A8 VA: 0xD758A8 Slot: 5
	protected override void decode() { }

	// RVA: 0xD75984 Offset: 0xD75984 VA: 0xD75984 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD75AA8 Offset: 0xD75AA8 VA: 0xD75AA8 Slot: 3
	public override string ToString() { }

	// RVA: 0xD75B58 Offset: 0xD75B58 VA: 0xD75B58
	private static void .cctor() { }
}
