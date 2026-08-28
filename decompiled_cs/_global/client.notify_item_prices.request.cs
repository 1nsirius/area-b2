// Namespace: 
public class client.notify_item_prices.request : SprotoTypeBase // TypeDefIndex: 9132
{
	// Fields
	private static int max_field_count; // 0x0
	private long _store_type; // 0x18
	private List<client.ItemPrice> _item_prices; // 0x20

	// Properties
	public long store_type { get; set; }
	public bool HasStore_type { get; }
	public List<client.ItemPrice> item_prices { get; set; }
	public bool HasItem_prices { get; }

	// Methods

	// RVA: 0x24432F0 Offset: 0x24432F0 VA: 0x24432F0
	public long get_store_type() { }

	// RVA: 0x24432F8 Offset: 0x24432F8 VA: 0x24432F8
	public void set_store_type(long value) { }

	// RVA: 0x244333C Offset: 0x244333C VA: 0x244333C
	public bool get_HasStore_type() { }

	// RVA: 0x244336C Offset: 0x244336C VA: 0x244336C
	public List<client.ItemPrice> get_item_prices() { }

	// RVA: 0x2443374 Offset: 0x2443374 VA: 0x2443374
	public void set_item_prices(List<client.ItemPrice> value) { }

	// RVA: 0x24433B4 Offset: 0x24433B4 VA: 0x24433B4
	public bool get_HasItem_prices() { }

	// RVA: 0x24433E4 Offset: 0x24433E4 VA: 0x24433E4
	public void .ctor() { }

	// RVA: 0x2443480 Offset: 0x2443480 VA: 0x2443480
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2443538 Offset: 0x2443538 VA: 0x2443538 Slot: 5
	protected override void decode() { }

	// RVA: 0x2443658 Offset: 0x2443658 VA: 0x2443658 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24437B8 Offset: 0x24437B8 VA: 0x24437B8 Slot: 3
	public override string ToString() { }

	// RVA: 0x2443868 Offset: 0x2443868 VA: 0x2443868
	private static void .cctor() { }
}
