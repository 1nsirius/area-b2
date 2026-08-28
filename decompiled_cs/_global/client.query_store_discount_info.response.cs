// Namespace: 
public class client.query_store_discount_info.response : SprotoTypeBase // TypeDefIndex: 9160
{
	// Fields
	private static int max_field_count; // 0x0
	private client.DiscountStoreItem _fix_item; // 0x14
	private List<client.DiscountStoreItem> _random_items; // 0x18
	private long _refresh_time; // 0x20

	// Properties
	public client.DiscountStoreItem fix_item { get; set; }
	public bool HasFix_item { get; }
	public List<client.DiscountStoreItem> random_items { get; set; }
	public bool HasRandom_items { get; }
	public long refresh_time { get; set; }
	public bool HasRefresh_time { get; }

	// Methods

	// RVA: 0x244A144 Offset: 0x244A144 VA: 0x244A144
	public client.DiscountStoreItem get_fix_item() { }

	// RVA: 0x244A14C Offset: 0x244A14C VA: 0x244A14C
	public void set_fix_item(client.DiscountStoreItem value) { }

	// RVA: 0x244A18C Offset: 0x244A18C VA: 0x244A18C
	public bool get_HasFix_item() { }

	// RVA: 0x244A1BC Offset: 0x244A1BC VA: 0x244A1BC
	public List<client.DiscountStoreItem> get_random_items() { }

	// RVA: 0x244A1C4 Offset: 0x244A1C4 VA: 0x244A1C4
	public void set_random_items(List<client.DiscountStoreItem> value) { }

	// RVA: 0x244A204 Offset: 0x244A204 VA: 0x244A204
	public bool get_HasRandom_items() { }

	// RVA: 0x244A234 Offset: 0x244A234 VA: 0x244A234
	public long get_refresh_time() { }

	// RVA: 0x244A23C Offset: 0x244A23C VA: 0x244A23C
	public void set_refresh_time(long value) { }

	// RVA: 0x244A280 Offset: 0x244A280 VA: 0x244A280
	public bool get_HasRefresh_time() { }

	// RVA: 0x244A2B0 Offset: 0x244A2B0 VA: 0x244A2B0
	public void .ctor() { }

	// RVA: 0x244A34C Offset: 0x244A34C VA: 0x244A34C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244A404 Offset: 0x244A404 VA: 0x244A404 Slot: 5
	protected override void decode() { }

	// RVA: 0x244A574 Offset: 0x244A574 VA: 0x244A574 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244A730 Offset: 0x244A730 VA: 0x244A730 Slot: 3
	public override string ToString() { }

	// RVA: 0x244A7F0 Offset: 0x244A7F0 VA: 0x244A7F0
	private static void .cctor() { }
}
