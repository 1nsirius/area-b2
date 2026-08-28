// Namespace: 
public class client.get_recharge_items.response : SprotoTypeBase // TypeDefIndex: 9109
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private List<client.RechargeItem> _items; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public List<client.RechargeItem> items { get; set; }
	public bool HasItems { get; }

	// Methods

	// RVA: 0x243E99C Offset: 0x243E99C VA: 0x243E99C
	public long get_errorcode() { }

	// RVA: 0x243E9A4 Offset: 0x243E9A4 VA: 0x243E9A4
	public void set_errorcode(long value) { }

	// RVA: 0x243E9E8 Offset: 0x243E9E8 VA: 0x243E9E8
	public bool get_HasErrorcode() { }

	// RVA: 0x243EA18 Offset: 0x243EA18 VA: 0x243EA18
	public List<client.RechargeItem> get_items() { }

	// RVA: 0x243EA20 Offset: 0x243EA20 VA: 0x243EA20
	public void set_items(List<client.RechargeItem> value) { }

	// RVA: 0x243EA60 Offset: 0x243EA60 VA: 0x243EA60
	public bool get_HasItems() { }

	// RVA: 0x243EA90 Offset: 0x243EA90 VA: 0x243EA90
	public void .ctor() { }

	// RVA: 0x243EB2C Offset: 0x243EB2C VA: 0x243EB2C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243EBE4 Offset: 0x243EBE4 VA: 0x243EBE4 Slot: 5
	protected override void decode() { }

	// RVA: 0x243ED04 Offset: 0x243ED04 VA: 0x243ED04 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243EE64 Offset: 0x243EE64 VA: 0x243EE64 Slot: 3
	public override string ToString() { }

	// RVA: 0x243EF14 Offset: 0x243EF14 VA: 0x243EF14
	private static void .cctor() { }
}
