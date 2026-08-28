// Namespace: 
public class client.ItemPrice : SprotoTypeBase // TypeDefIndex: 9061
{
	// Fields
	private static int max_field_count; // 0x0
	private long _id; // 0x18
	private long _price; // 0x20

	// Properties
	public long id { get; set; }
	public bool HasId { get; }
	public long price { get; set; }
	public bool HasPrice { get; }

	// Methods

	// RVA: 0x2431B4C Offset: 0x2431B4C VA: 0x2431B4C
	public long get_id() { }

	// RVA: 0x2431B54 Offset: 0x2431B54 VA: 0x2431B54
	public void set_id(long value) { }

	// RVA: 0x2431B98 Offset: 0x2431B98 VA: 0x2431B98
	public bool get_HasId() { }

	// RVA: 0x2431BC8 Offset: 0x2431BC8 VA: 0x2431BC8
	public long get_price() { }

	// RVA: 0x2431BD0 Offset: 0x2431BD0 VA: 0x2431BD0
	public void set_price(long value) { }

	// RVA: 0x2431C14 Offset: 0x2431C14 VA: 0x2431C14
	public bool get_HasPrice() { }

	// RVA: 0x2431C44 Offset: 0x2431C44 VA: 0x2431C44
	public void .ctor() { }

	// RVA: 0x2431CE0 Offset: 0x2431CE0 VA: 0x2431CE0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2431D98 Offset: 0x2431D98 VA: 0x2431D98 Slot: 5
	protected override void decode() { }

	// RVA: 0x2431E74 Offset: 0x2431E74 VA: 0x2431E74 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2431F9C Offset: 0x2431F9C VA: 0x2431F9C Slot: 3
	public override string ToString() { }

	// RVA: 0x243204C Offset: 0x243204C VA: 0x243204C
	private static void .cctor() { }
}
