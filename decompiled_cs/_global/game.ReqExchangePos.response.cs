// Namespace: 
public class game.ReqExchangePos.response : SprotoTypeBase // TypeDefIndex: 9251
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private bool _is_empty; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public bool is_empty { get; set; }
	public bool HasIs_empty { get; }

	// Methods

	// RVA: 0x2559630 Offset: 0x2559630 VA: 0x2559630
	public long get_errorcode() { }

	// RVA: 0x2559638 Offset: 0x2559638 VA: 0x2559638
	public void set_errorcode(long value) { }

	// RVA: 0x255967C Offset: 0x255967C VA: 0x255967C
	public bool get_HasErrorcode() { }

	// RVA: 0x25596AC Offset: 0x25596AC VA: 0x25596AC
	public bool get_is_empty() { }

	// RVA: 0x25596B4 Offset: 0x25596B4 VA: 0x25596B4
	public void set_is_empty(bool value) { }

	// RVA: 0x25596F4 Offset: 0x25596F4 VA: 0x25596F4
	public bool get_HasIs_empty() { }

	// RVA: 0x2559724 Offset: 0x2559724 VA: 0x2559724
	public void .ctor() { }

	// RVA: 0x25597C0 Offset: 0x25597C0 VA: 0x25597C0
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2559878 Offset: 0x2559878 VA: 0x2559878 Slot: 5
	protected override void decode() { }

	// RVA: 0x2559950 Offset: 0x2559950 VA: 0x2559950 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2559A70 Offset: 0x2559A70 VA: 0x2559A70 Slot: 3
	public override string ToString() { }

	// RVA: 0x2559B2C Offset: 0x2559B2C VA: 0x2559B2C
	private static void .cctor() { }
}
