// Namespace: 
public class client.query_ad_info.response : SprotoTypeBase // TypeDefIndex: 9145
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private bool _ad_switch; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public bool ad_switch { get; set; }
	public bool HasAd_switch { get; }

	// Methods

	// RVA: 0x2445AD8 Offset: 0x2445AD8 VA: 0x2445AD8
	public long get_errorcode() { }

	// RVA: 0x2445AE0 Offset: 0x2445AE0 VA: 0x2445AE0
	public void set_errorcode(long value) { }

	// RVA: 0x2445B24 Offset: 0x2445B24 VA: 0x2445B24
	public bool get_HasErrorcode() { }

	// RVA: 0x2445B54 Offset: 0x2445B54 VA: 0x2445B54
	public bool get_ad_switch() { }

	// RVA: 0x2445B5C Offset: 0x2445B5C VA: 0x2445B5C
	public void set_ad_switch(bool value) { }

	// RVA: 0x2445B9C Offset: 0x2445B9C VA: 0x2445B9C
	public bool get_HasAd_switch() { }

	// RVA: 0x2445BCC Offset: 0x2445BCC VA: 0x2445BCC
	public void .ctor() { }

	// RVA: 0x2445C68 Offset: 0x2445C68 VA: 0x2445C68
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2445D20 Offset: 0x2445D20 VA: 0x2445D20 Slot: 5
	protected override void decode() { }

	// RVA: 0x2445DF8 Offset: 0x2445DF8 VA: 0x2445DF8 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2445F18 Offset: 0x2445F18 VA: 0x2445F18 Slot: 3
	public override string ToString() { }

	// RVA: 0x2445FD4 Offset: 0x2445FD4 VA: 0x2445FD4
	private static void .cctor() { }
}
