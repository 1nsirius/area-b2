// Namespace: 
public class game.RspOpenMode.request : SprotoTypeBase // TypeDefIndex: 9359
{
	// Fields
	private static int max_field_count; // 0x0
	private long _mode_id; // 0x18
	private long _map_id; // 0x20
	private long _camp; // 0x28

	// Properties
	public long mode_id { get; set; }
	public bool HasMode_id { get; }
	public long map_id { get; set; }
	public bool HasMap_id { get; }
	public long camp { get; set; }
	public bool HasCamp { get; }

	// Methods

	// RVA: 0x2261B30 Offset: 0x2261B30 VA: 0x2261B30
	public long get_mode_id() { }

	// RVA: 0x2261B38 Offset: 0x2261B38 VA: 0x2261B38
	public void set_mode_id(long value) { }

	// RVA: 0x2261B7C Offset: 0x2261B7C VA: 0x2261B7C
	public bool get_HasMode_id() { }

	// RVA: 0x2261BAC Offset: 0x2261BAC VA: 0x2261BAC
	public long get_map_id() { }

	// RVA: 0x2261BB4 Offset: 0x2261BB4 VA: 0x2261BB4
	public void set_map_id(long value) { }

	// RVA: 0x2261BF8 Offset: 0x2261BF8 VA: 0x2261BF8
	public bool get_HasMap_id() { }

	// RVA: 0x2261C28 Offset: 0x2261C28 VA: 0x2261C28
	public long get_camp() { }

	// RVA: 0x2261C30 Offset: 0x2261C30 VA: 0x2261C30
	public void set_camp(long value) { }

	// RVA: 0x2261C74 Offset: 0x2261C74 VA: 0x2261C74
	public bool get_HasCamp() { }

	// RVA: 0x2261CA4 Offset: 0x2261CA4 VA: 0x2261CA4
	public void .ctor() { }

	// RVA: 0x2261D40 Offset: 0x2261D40 VA: 0x2261D40
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2261DF8 Offset: 0x2261DF8 VA: 0x2261DF8 Slot: 5
	protected override void decode() { }

	// RVA: 0x2261F1C Offset: 0x2261F1C VA: 0x2261F1C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x22620A4 Offset: 0x22620A4 VA: 0x22620A4 Slot: 3
	public override string ToString() { }

	// RVA: 0x226217C Offset: 0x226217C VA: 0x226217C
	private static void .cctor() { }
}
