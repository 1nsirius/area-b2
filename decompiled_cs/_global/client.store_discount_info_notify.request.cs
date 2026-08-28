// Namespace: 
public class client.store_discount_info_notify.request : SprotoTypeBase // TypeDefIndex: 9170
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

	// RVA: 0x244DC9C Offset: 0x244DC9C VA: 0x244DC9C
	public client.DiscountStoreItem get_fix_item() { }

	// RVA: 0x244DCA4 Offset: 0x244DCA4 VA: 0x244DCA4
	public void set_fix_item(client.DiscountStoreItem value) { }

	// RVA: 0x244DCE4 Offset: 0x244DCE4 VA: 0x244DCE4
	public bool get_HasFix_item() { }

	// RVA: 0x244DD14 Offset: 0x244DD14 VA: 0x244DD14
	public List<client.DiscountStoreItem> get_random_items() { }

	// RVA: 0x244DD1C Offset: 0x244DD1C VA: 0x244DD1C
	public void set_random_items(List<client.DiscountStoreItem> value) { }

	// RVA: 0x244DD5C Offset: 0x244DD5C VA: 0x244DD5C
	public bool get_HasRandom_items() { }

	// RVA: 0x244DD8C Offset: 0x244DD8C VA: 0x244DD8C
	public long get_refresh_time() { }

	// RVA: 0x244DD94 Offset: 0x244DD94 VA: 0x244DD94
	public void set_refresh_time(long value) { }

	// RVA: 0x244DDD8 Offset: 0x244DDD8 VA: 0x244DDD8
	public bool get_HasRefresh_time() { }

	// RVA: 0x244DE08 Offset: 0x244DE08 VA: 0x244DE08
	public void .ctor() { }

	// RVA: 0x244DEA4 Offset: 0x244DEA4 VA: 0x244DEA4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x244DF5C Offset: 0x244DF5C VA: 0x244DF5C Slot: 5
	protected override void decode() { }

	// RVA: 0x244E0CC Offset: 0x244E0CC VA: 0x244E0CC Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x244E288 Offset: 0x244E288 VA: 0x244E288 Slot: 3
	public override string ToString() { }

	// RVA: 0x244E348 Offset: 0x244E348 VA: 0x244E348
	private static void .cctor() { }
}
