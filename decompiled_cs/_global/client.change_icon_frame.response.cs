// Namespace: 
public class client.change_icon_frame.response : SprotoTypeBase // TypeDefIndex: 9085
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _icon_frame; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long icon_frame { get; set; }
	public bool HasIcon_frame { get; }

	// Methods

	// RVA: 0x2439B14 Offset: 0x2439B14 VA: 0x2439B14
	public long get_errorcode() { }

	// RVA: 0x2439B1C Offset: 0x2439B1C VA: 0x2439B1C
	public void set_errorcode(long value) { }

	// RVA: 0x2439B60 Offset: 0x2439B60 VA: 0x2439B60
	public bool get_HasErrorcode() { }

	// RVA: 0x2439B90 Offset: 0x2439B90 VA: 0x2439B90
	public long get_icon_frame() { }

	// RVA: 0x2439B98 Offset: 0x2439B98 VA: 0x2439B98
	public void set_icon_frame(long value) { }

	// RVA: 0x2439BDC Offset: 0x2439BDC VA: 0x2439BDC
	public bool get_HasIcon_frame() { }

	// RVA: 0x2439C0C Offset: 0x2439C0C VA: 0x2439C0C
	public void .ctor() { }

	// RVA: 0x2439CA8 Offset: 0x2439CA8 VA: 0x2439CA8
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2439D60 Offset: 0x2439D60 VA: 0x2439D60 Slot: 5
	protected override void decode() { }

	// RVA: 0x2439E3C Offset: 0x2439E3C VA: 0x2439E3C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2439F60 Offset: 0x2439F60 VA: 0x2439F60 Slot: 3
	public override string ToString() { }

	// RVA: 0x243A010 Offset: 0x243A010 VA: 0x243A010
	private static void .cctor() { }
}
