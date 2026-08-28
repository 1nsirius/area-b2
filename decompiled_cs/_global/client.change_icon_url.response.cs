// Namespace: 
public class client.change_icon_url.response : SprotoTypeBase // TypeDefIndex: 9088
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private string _icon_url; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public string icon_url { get; set; }
	public bool HasIcon_url { get; }

	// Methods

	// RVA: 0x243A458 Offset: 0x243A458 VA: 0x243A458
	public long get_errorcode() { }

	// RVA: 0x243A460 Offset: 0x243A460 VA: 0x243A460
	public void set_errorcode(long value) { }

	// RVA: 0x243A4A4 Offset: 0x243A4A4 VA: 0x243A4A4
	public bool get_HasErrorcode() { }

	// RVA: 0x243A4D4 Offset: 0x243A4D4 VA: 0x243A4D4
	public string get_icon_url() { }

	// RVA: 0x243A4DC Offset: 0x243A4DC VA: 0x243A4DC
	public void set_icon_url(string value) { }

	// RVA: 0x243A51C Offset: 0x243A51C VA: 0x243A51C
	public bool get_HasIcon_url() { }

	// RVA: 0x243A54C Offset: 0x243A54C VA: 0x243A54C
	public void .ctor() { }

	// RVA: 0x243A5E8 Offset: 0x243A5E8 VA: 0x243A5E8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x243A6A0 Offset: 0x243A6A0 VA: 0x243A6A0 Slot: 5
	protected override void decode() { }

	// RVA: 0x243A778 Offset: 0x243A778 VA: 0x243A778 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x243A890 Offset: 0x243A890 VA: 0x243A890 Slot: 3
	public override string ToString() { }

	// RVA: 0x243A924 Offset: 0x243A924 VA: 0x243A924
	private static void .cctor() { }
}
