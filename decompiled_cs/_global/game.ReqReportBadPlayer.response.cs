// Namespace: 
public class game.ReqReportBadPlayer.response : SprotoTypeBase // TypeDefIndex: 9291
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _uid; // 0x20

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long uid { get; set; }
	public bool HasUid { get; }

	// Methods

	// RVA: 0x25603E8 Offset: 0x25603E8 VA: 0x25603E8
	public long get_errorcode() { }

	// RVA: 0x25603F0 Offset: 0x25603F0 VA: 0x25603F0
	public void set_errorcode(long value) { }

	// RVA: 0x2560434 Offset: 0x2560434 VA: 0x2560434
	public bool get_HasErrorcode() { }

	// RVA: 0x2560464 Offset: 0x2560464 VA: 0x2560464
	public long get_uid() { }

	// RVA: 0x256046C Offset: 0x256046C VA: 0x256046C
	public void set_uid(long value) { }

	// RVA: 0x25604B0 Offset: 0x25604B0 VA: 0x25604B0
	public bool get_HasUid() { }

	// RVA: 0x25604E0 Offset: 0x25604E0 VA: 0x25604E0
	public void .ctor() { }

	// RVA: 0x256057C Offset: 0x256057C VA: 0x256057C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2560634 Offset: 0x2560634 VA: 0x2560634 Slot: 5
	protected override void decode() { }

	// RVA: 0x2560710 Offset: 0x2560710 VA: 0x2560710 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2560834 Offset: 0x2560834 VA: 0x2560834 Slot: 3
	public override string ToString() { }

	// RVA: 0x25608E4 Offset: 0x25608E4 VA: 0x25608E4
	private static void .cctor() { }
}
