// Namespace: 
public class game.ActivityExchangeItem : SprotoTypeBase // TypeDefIndex: 9192
{
	// Fields
	private static int max_field_count; // 0x0
	private long _item_id; // 0x18
	private long _num; // 0x20

	// Properties
	public long item_id { get; set; }
	public bool HasItem_id { get; }
	public long num { get; set; }
	public bool HasNum { get; }

	// Methods

	// RVA: 0x2548418 Offset: 0x2548418 VA: 0x2548418
	public long get_item_id() { }

	// RVA: 0x2548420 Offset: 0x2548420 VA: 0x2548420
	public void set_item_id(long value) { }

	// RVA: 0x2548464 Offset: 0x2548464 VA: 0x2548464
	public bool get_HasItem_id() { }

	// RVA: 0x2548494 Offset: 0x2548494 VA: 0x2548494
	public long get_num() { }

	// RVA: 0x254849C Offset: 0x254849C VA: 0x254849C
	public void set_num(long value) { }

	// RVA: 0x25484E0 Offset: 0x25484E0 VA: 0x25484E0
	public bool get_HasNum() { }

	// RVA: 0x2548510 Offset: 0x2548510 VA: 0x2548510
	public void .ctor() { }

	// RVA: 0x25485AC Offset: 0x25485AC VA: 0x25485AC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2548664 Offset: 0x2548664 VA: 0x2548664 Slot: 5
	protected override void decode() { }

	// RVA: 0x2548740 Offset: 0x2548740 VA: 0x2548740 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2548864 Offset: 0x2548864 VA: 0x2548864 Slot: 3
	public override string ToString() { }

	// RVA: 0x2548914 Offset: 0x2548914 VA: 0x2548914
	private static void .cctor() { }
}
