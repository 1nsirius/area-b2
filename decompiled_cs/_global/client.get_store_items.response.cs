// Namespace: 
public class client.get_store_items.response : SprotoTypeBase // TypeDefIndex: 9117
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _store_type; // 0x20
	private List<long> _items; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long store_type { get; set; }
	public bool HasStore_type { get; }
	public List<long> items { get; set; }
	public bool HasItems { get; }

	// Methods

	// RVA: 0x24403B0 Offset: 0x24403B0 VA: 0x24403B0
	public long get_errorcode() { }

	// RVA: 0x24403B8 Offset: 0x24403B8 VA: 0x24403B8
	public void set_errorcode(long value) { }

	// RVA: 0x24403FC Offset: 0x24403FC VA: 0x24403FC
	public bool get_HasErrorcode() { }

	// RVA: 0x244042C Offset: 0x244042C VA: 0x244042C
	public long get_store_type() { }

	// RVA: 0x2440434 Offset: 0x2440434 VA: 0x2440434
	public void set_store_type(long value) { }

	// RVA: 0x2440478 Offset: 0x2440478 VA: 0x2440478
	public bool get_HasStore_type() { }

	// RVA: 0x24404A8 Offset: 0x24404A8 VA: 0x24404A8
	public List<long> get_items() { }

	// RVA: 0x24404B0 Offset: 0x24404B0 VA: 0x24404B0
	public void set_items(List<long> value) { }

	// RVA: 0x24404F0 Offset: 0x24404F0 VA: 0x24404F0
	public bool get_HasItems() { }

	// RVA: 0x2440520 Offset: 0x2440520 VA: 0x2440520
	public void .ctor() { }

	// RVA: 0x24405BC Offset: 0x24405BC VA: 0x24405BC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2440674 Offset: 0x2440674 VA: 0x2440674 Slot: 5
	protected override void decode() { }

	// RVA: 0x2440794 Offset: 0x2440794 VA: 0x2440794 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2440910 Offset: 0x2440910 VA: 0x2440910 Slot: 3
	public override string ToString() { }

	// RVA: 0x24409E8 Offset: 0x24409E8 VA: 0x24409E8
	private static void .cctor() { }
}
