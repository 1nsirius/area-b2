// Namespace: 
public class client.change_icon.response : SprotoTypeBase // TypeDefIndex: 9082
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _icon; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }

	// Methods

	// RVA: 0x2439198 Offset: 0x2439198 VA: 0x2439198
	public long get_errorcode() { }

	// RVA: 0x24391A0 Offset: 0x24391A0 VA: 0x24391A0
	public void set_errorcode(long value) { }

	// RVA: 0x24391E4 Offset: 0x24391E4 VA: 0x24391E4
	public bool get_HasErrorcode() { }

	// RVA: 0x2439214 Offset: 0x2439214 VA: 0x2439214
	public long get_icon() { }

	// RVA: 0x243921C Offset: 0x243921C VA: 0x243921C
	public void set_icon(long value) { }

	// RVA: 0x2439260 Offset: 0x2439260 VA: 0x2439260
	public bool get_HasIcon() { }

	// RVA: 0x2439290 Offset: 0x2439290 VA: 0x2439290
	public void .ctor() { }

	// RVA: 0x243932C Offset: 0x243932C VA: 0x243932C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24393E4 Offset: 0x24393E4 VA: 0x24393E4 Slot: 5
	protected override void decode() { }

	// RVA: 0x24394C0 Offset: 0x24394C0 VA: 0x24394C0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24395E4 Offset: 0x24395E4 VA: 0x24395E4 Slot: 3
	public override string ToString() { }

	// RVA: 0x2439694 Offset: 0x2439694 VA: 0x2439694
	private static void .cctor() { }
}
