// Namespace: 
public class game.RoomPositionInfo : SprotoTypeBase // TypeDefIndex: 9305
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _index; // 0x20
	private long _camp; // 0x28

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long index { get; set; }
	public bool HasIndex { get; }
	public long camp { get; set; }
	public bool HasCamp { get; }

	// Methods

	// RVA: 0x2256DC0 Offset: 0x2256DC0 VA: 0x2256DC0
	public long get_uid() { }

	// RVA: 0x2256DC8 Offset: 0x2256DC8 VA: 0x2256DC8
	public void set_uid(long value) { }

	// RVA: 0x2256E0C Offset: 0x2256E0C VA: 0x2256E0C
	public bool get_HasUid() { }

	// RVA: 0x2256E3C Offset: 0x2256E3C VA: 0x2256E3C
	public long get_index() { }

	// RVA: 0x2256E44 Offset: 0x2256E44 VA: 0x2256E44
	public void set_index(long value) { }

	// RVA: 0x2256E88 Offset: 0x2256E88 VA: 0x2256E88
	public bool get_HasIndex() { }

	// RVA: 0x2256EB8 Offset: 0x2256EB8 VA: 0x2256EB8
	public long get_camp() { }

	// RVA: 0x2256EC0 Offset: 0x2256EC0 VA: 0x2256EC0
	public void set_camp(long value) { }

	// RVA: 0x2256F04 Offset: 0x2256F04 VA: 0x2256F04
	public bool get_HasCamp() { }

	// RVA: 0x2256F34 Offset: 0x2256F34 VA: 0x2256F34
	public void .ctor() { }

	// RVA: 0x2256FD0 Offset: 0x2256FD0 VA: 0x2256FD0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2257088 Offset: 0x2257088 VA: 0x2257088 Slot: 5
	protected override void decode() { }

	// RVA: 0x22571AC Offset: 0x22571AC VA: 0x22571AC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2257334 Offset: 0x2257334 VA: 0x2257334 Slot: 3
	public override string ToString() { }

	// RVA: 0x225740C Offset: 0x225740C VA: 0x225740C
	private static void .cctor() { }
}
