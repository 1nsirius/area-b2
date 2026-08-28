// Namespace: 
public class client.buy_store_item.request : SprotoTypeBase // TypeDefIndex: 9078
{
	// Fields
	private static int max_field_count; // 0x0
	private long _item_id; // 0x18
	private string _money_type; // 0x20
	private long _item_id_type; // 0x28
	private bool _not_discount_store; // 0x30

	// Properties
	public long item_id { get; set; }
	public bool HasItem_id { get; }
	public string money_type { get; set; }
	public bool HasMoney_type { get; }
	public long item_id_type { get; set; }
	public bool HasItem_id_type { get; }
	public bool not_discount_store { get; set; }
	public bool HasNot_discount_store { get; }

	// Methods

	// RVA: 0x2437DA4 Offset: 0x2437DA4 VA: 0x2437DA4
	public long get_item_id() { }

	// RVA: 0x2437DAC Offset: 0x2437DAC VA: 0x2437DAC
	public void set_item_id(long value) { }

	// RVA: 0x2437DF0 Offset: 0x2437DF0 VA: 0x2437DF0
	public bool get_HasItem_id() { }

	// RVA: 0x2437E20 Offset: 0x2437E20 VA: 0x2437E20
	public string get_money_type() { }

	// RVA: 0x2437E28 Offset: 0x2437E28 VA: 0x2437E28
	public void set_money_type(string value) { }

	// RVA: 0x2437E68 Offset: 0x2437E68 VA: 0x2437E68
	public bool get_HasMoney_type() { }

	// RVA: 0x2437E98 Offset: 0x2437E98 VA: 0x2437E98
	public long get_item_id_type() { }

	// RVA: 0x2437EA0 Offset: 0x2437EA0 VA: 0x2437EA0
	public void set_item_id_type(long value) { }

	// RVA: 0x2437EE4 Offset: 0x2437EE4 VA: 0x2437EE4
	public bool get_HasItem_id_type() { }

	// RVA: 0x2437F14 Offset: 0x2437F14 VA: 0x2437F14
	public bool get_not_discount_store() { }

	// RVA: 0x2437F1C Offset: 0x2437F1C VA: 0x2437F1C
	public void set_not_discount_store(bool value) { }

	// RVA: 0x2437F5C Offset: 0x2437F5C VA: 0x2437F5C
	public bool get_HasNot_discount_store() { }

	// RVA: 0x2437F8C Offset: 0x2437F8C VA: 0x2437F8C
	public void .ctor() { }

	// RVA: 0x2438028 Offset: 0x2438028 VA: 0x2438028
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24380E0 Offset: 0x24380E0 VA: 0x24380E0 Slot: 5
	protected override void decode() { }

	// RVA: 0x2438234 Offset: 0x2438234 VA: 0x2438234 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2438410 Offset: 0x2438410 VA: 0x2438410 Slot: 3
	public override string ToString() { }

	// RVA: 0x2438664 Offset: 0x2438664 VA: 0x2438664
	private static void .cctor() { }
}
