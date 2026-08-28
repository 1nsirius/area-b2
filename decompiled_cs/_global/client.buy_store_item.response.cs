// Namespace: 
public class client.buy_store_item.response : SprotoTypeBase // TypeDefIndex: 9079
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _item_id; // 0x20
	private long _item_id_type; // 0x28

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long item_id { get; set; }
	public bool HasItem_id { get; }
	public long item_id_type { get; set; }
	public bool HasItem_id_type { get; }

	// Methods

	// RVA: 0x24386CC Offset: 0x24386CC VA: 0x24386CC
	public long get_errorcode() { }

	// RVA: 0x24386D4 Offset: 0x24386D4 VA: 0x24386D4
	public void set_errorcode(long value) { }

	// RVA: 0x2438718 Offset: 0x2438718 VA: 0x2438718
	public bool get_HasErrorcode() { }

	// RVA: 0x2438748 Offset: 0x2438748 VA: 0x2438748
	public long get_item_id() { }

	// RVA: 0x2438750 Offset: 0x2438750 VA: 0x2438750
	public void set_item_id(long value) { }

	// RVA: 0x2438794 Offset: 0x2438794 VA: 0x2438794
	public bool get_HasItem_id() { }

	// RVA: 0x24387C4 Offset: 0x24387C4 VA: 0x24387C4
	public long get_item_id_type() { }

	// RVA: 0x24387CC Offset: 0x24387CC VA: 0x24387CC
	public void set_item_id_type(long value) { }

	// RVA: 0x2438810 Offset: 0x2438810 VA: 0x2438810
	public bool get_HasItem_id_type() { }

	// RVA: 0x2438840 Offset: 0x2438840 VA: 0x2438840
	public void .ctor() { }

	// RVA: 0x24388DC Offset: 0x24388DC VA: 0x24388DC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2438994 Offset: 0x2438994 VA: 0x2438994 Slot: 5
	protected override void decode() { }

	// RVA: 0x2438AB8 Offset: 0x2438AB8 VA: 0x2438AB8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2438C40 Offset: 0x2438C40 VA: 0x2438C40 Slot: 3
	public override string ToString() { }

	// RVA: 0x2438D18 Offset: 0x2438D18 VA: 0x2438D18
	private static void .cctor() { }
}
