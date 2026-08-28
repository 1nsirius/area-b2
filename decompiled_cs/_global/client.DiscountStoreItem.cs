// Namespace: 
public class client.DiscountStoreItem : SprotoTypeBase // TypeDefIndex: 9057
{
	// Fields
	private static int max_field_count; // 0x0
	private long _item_id; // 0x18
	private long _item_id_type; // 0x20
	private bool _bought; // 0x28
	private long _discount; // 0x30

	// Properties
	public long item_id { get; set; }
	public bool HasItem_id { get; }
	public long item_id_type { get; set; }
	public bool HasItem_id_type { get; }
	public bool bought { get; set; }
	public bool HasBought { get; }
	public long discount { get; set; }
	public bool HasDiscount { get; }

	// Methods

	// RVA: 0x12BCC6C Offset: 0x12BCC6C VA: 0x12BCC6C
	public long get_item_id() { }

	// RVA: 0x12BCC74 Offset: 0x12BCC74 VA: 0x12BCC74
	public void set_item_id(long value) { }

	// RVA: 0x12BCCB4 Offset: 0x12BCCB4 VA: 0x12BCCB4
	public bool get_HasItem_id() { }

	// RVA: 0x12BCCE0 Offset: 0x12BCCE0 VA: 0x12BCCE0
	public long get_item_id_type() { }

	// RVA: 0x12BCCE8 Offset: 0x12BCCE8 VA: 0x12BCCE8
	public void set_item_id_type(long value) { }

	// RVA: 0x12BCD28 Offset: 0x12BCD28 VA: 0x12BCD28
	public bool get_HasItem_id_type() { }

	// RVA: 0x12BCD54 Offset: 0x12BCD54 VA: 0x12BCD54
	public bool get_bought() { }

	// RVA: 0x12BCD5C Offset: 0x12BCD5C VA: 0x12BCD5C
	public void set_bought(bool value) { }

	// RVA: 0x12BCD98 Offset: 0x12BCD98 VA: 0x12BCD98
	public bool get_HasBought() { }

	// RVA: 0x12BCDC4 Offset: 0x12BCDC4 VA: 0x12BCDC4
	public long get_discount() { }

	// RVA: 0x12BCDCC Offset: 0x12BCDCC VA: 0x12BCDCC
	public void set_discount(long value) { }

	// RVA: 0x12BCE0C Offset: 0x12BCE0C VA: 0x12BCE0C
	public bool get_HasDiscount() { }

	// RVA: 0x12BCE38 Offset: 0x12BCE38 VA: 0x12BCE38
	public void .ctor() { }

	// RVA: 0x12BCED0 Offset: 0x12BCED0 VA: 0x12BCED0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x12BCF84 Offset: 0x12BCF84 VA: 0x12BCF84 Slot: 5
	protected override void decode() { }

	// RVA: 0x12BD0C4 Offset: 0x12BD0C4 VA: 0x12BD0C4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x12BD27C Offset: 0x12BD27C VA: 0x12BD27C Slot: 3
	public override string ToString() { }

	// RVA: 0x12BD4F0 Offset: 0x12BD4F0 VA: 0x12BD4F0
	private static void .cctor() { }
}
