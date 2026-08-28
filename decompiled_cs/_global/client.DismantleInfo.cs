// Namespace: 
public class client.DismantleInfo : SprotoTypeBase // TypeDefIndex: 9058
{
	// Fields
	private static int max_field_count; // 0x0
	private long _skin_id; // 0x18
	private long _num; // 0x20

	// Properties
	public long skin_id { get; set; }
	public bool HasSkin_id { get; }
	public long num { get; set; }
	public bool HasNum { get; }

	// Methods

	// RVA: 0x12BD558 Offset: 0x12BD558 VA: 0x12BD558
	public long get_skin_id() { }

	// RVA: 0x12BD560 Offset: 0x12BD560 VA: 0x12BD560
	public void set_skin_id(long value) { }

	// RVA: 0x12BD5A0 Offset: 0x12BD5A0 VA: 0x12BD5A0
	public bool get_HasSkin_id() { }

	// RVA: 0x12BD5CC Offset: 0x12BD5CC VA: 0x12BD5CC
	public long get_num() { }

	// RVA: 0x12BD5D4 Offset: 0x12BD5D4 VA: 0x12BD5D4
	public void set_num(long value) { }

	// RVA: 0x12BD614 Offset: 0x12BD614 VA: 0x12BD614
	public bool get_HasNum() { }

	// RVA: 0x12BD640 Offset: 0x12BD640 VA: 0x12BD640
	public void .ctor() { }

	// RVA: 0x12BD6D8 Offset: 0x12BD6D8 VA: 0x12BD6D8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x12BD78C Offset: 0x12BD78C VA: 0x12BD78C Slot: 5
	protected override void decode() { }

	// RVA: 0x12BD858 Offset: 0x12BD858 VA: 0x12BD858 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x12BD960 Offset: 0x12BD960 VA: 0x12BD960 Slot: 3
	public override string ToString() { }

	// RVA: 0x12BDA10 Offset: 0x12BDA10 VA: 0x12BDA10
	private static void .cctor() { }
}
