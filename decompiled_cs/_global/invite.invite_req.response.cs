// Namespace: 
public class invite.invite_req.response : SprotoTypeBase // TypeDefIndex: 9426
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }

	// Methods

	// RVA: 0x22702DC Offset: 0x22702DC VA: 0x22702DC
	public long get_errorcode() { }

	// RVA: 0x22702E4 Offset: 0x22702E4 VA: 0x22702E4
	public void set_errorcode(long value) { }

	// RVA: 0x2270328 Offset: 0x2270328 VA: 0x2270328
	public bool get_HasErrorcode() { }

	// RVA: 0x2270358 Offset: 0x2270358 VA: 0x2270358
	public void .ctor() { }

	// RVA: 0x22703F4 Offset: 0x22703F4 VA: 0x22703F4
	public void .ctor(byte[] buffer) { }

	// RVA: 0x22704AC Offset: 0x22704AC VA: 0x22704AC Slot: 5
	protected override void decode() { }

	// RVA: 0x2270534 Offset: 0x2270534 VA: 0x2270534 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x22705F4 Offset: 0x22705F4 VA: 0x22705F4 Slot: 3
	public override string ToString() { }

	// RVA: 0x2270684 Offset: 0x2270684 VA: 0x2270684
	private static void .cctor() { }
}
