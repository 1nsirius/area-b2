// Namespace: 
public class client.add_skin.response : SprotoTypeBase // TypeDefIndex: 9076
{
	// Fields
	private static int max_field_count; // 0x0
	private long _skin_id; // 0x18
	private bool _result; // 0x20

	// Properties
	public long skin_id { get; set; }
	public bool HasSkin_id { get; }
	public bool result { get; set; }
	public bool HasResult { get; }

	// Methods

	// RVA: 0x2437838 Offset: 0x2437838 VA: 0x2437838
	public long get_skin_id() { }

	// RVA: 0x2437840 Offset: 0x2437840 VA: 0x2437840
	public void set_skin_id(long value) { }

	// RVA: 0x2437884 Offset: 0x2437884 VA: 0x2437884
	public bool get_HasSkin_id() { }

	// RVA: 0x24378B4 Offset: 0x24378B4 VA: 0x24378B4
	public bool get_result() { }

	// RVA: 0x24378BC Offset: 0x24378BC VA: 0x24378BC
	public void set_result(bool value) { }

	// RVA: 0x24378FC Offset: 0x24378FC VA: 0x24378FC
	public bool get_HasResult() { }

	// RVA: 0x243792C Offset: 0x243792C VA: 0x243792C
	public void .ctor() { }

	// RVA: 0x24379C8 Offset: 0x24379C8 VA: 0x24379C8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2437A80 Offset: 0x2437A80 VA: 0x2437A80 Slot: 5
	protected override void decode() { }

	// RVA: 0x2437B58 Offset: 0x2437B58 VA: 0x2437B58 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2437C78 Offset: 0x2437C78 VA: 0x2437C78 Slot: 3
	public override string ToString() { }

	// RVA: 0x2437D34 Offset: 0x2437D34 VA: 0x2437D34
	private static void .cctor() { }
}
