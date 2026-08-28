// Namespace: 
public class client.update_recharge_items_notify.request : SprotoTypeBase // TypeDefIndex: 9182
{
	// Fields
	private static int max_field_count; // 0x0
	private List<client.RechargeItem> _items; // 0x14

	// Properties
	public List<client.RechargeItem> items { get; set; }
	public bool HasItems { get; }

	// Methods

	// RVA: 0x2545B88 Offset: 0x2545B88 VA: 0x2545B88
	public List<client.RechargeItem> get_items() { }

	// RVA: 0x2545B90 Offset: 0x2545B90 VA: 0x2545B90
	public void set_items(List<client.RechargeItem> value) { }

	// RVA: 0x2545BD0 Offset: 0x2545BD0 VA: 0x2545BD0
	public bool get_HasItems() { }

	// RVA: 0x2545C00 Offset: 0x2545C00 VA: 0x2545C00
	public void .ctor() { }

	// RVA: 0x2545C9C Offset: 0x2545C9C VA: 0x2545C9C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2545D54 Offset: 0x2545D54 VA: 0x2545D54 Slot: 5
	protected override void decode() { }

	// RVA: 0x2545E20 Offset: 0x2545E20 VA: 0x2545E20 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2545F18 Offset: 0x2545F18 VA: 0x2545F18 Slot: 3
	public override string ToString() { }

	// RVA: 0x2545FA8 Offset: 0x2545FA8 VA: 0x2545FA8
	private static void .cctor() { }
}
