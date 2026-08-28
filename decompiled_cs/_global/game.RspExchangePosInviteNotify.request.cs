// Namespace: 
public class game.RspExchangePosInviteNotify.request : SprotoTypeBase // TypeDefIndex: 9347
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _timeout_second; // 0x20

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long timeout_second { get; set; }
	public bool HasTimeout_second { get; }

	// Methods

	// RVA: 0x225FA28 Offset: 0x225FA28 VA: 0x225FA28
	public long get_uid() { }

	// RVA: 0x225FA30 Offset: 0x225FA30 VA: 0x225FA30
	public void set_uid(long value) { }

	// RVA: 0x225FA74 Offset: 0x225FA74 VA: 0x225FA74
	public bool get_HasUid() { }

	// RVA: 0x225FAA4 Offset: 0x225FAA4 VA: 0x225FAA4
	public long get_timeout_second() { }

	// RVA: 0x225FAAC Offset: 0x225FAAC VA: 0x225FAAC
	public void set_timeout_second(long value) { }

	// RVA: 0x225FAF0 Offset: 0x225FAF0 VA: 0x225FAF0
	public bool get_HasTimeout_second() { }

	// RVA: 0x225FB20 Offset: 0x225FB20 VA: 0x225FB20
	public void .ctor() { }

	// RVA: 0x225FBBC Offset: 0x225FBBC VA: 0x225FBBC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x225FC74 Offset: 0x225FC74 VA: 0x225FC74 Slot: 5
	protected override void decode() { }

	// RVA: 0x225FD50 Offset: 0x225FD50 VA: 0x225FD50 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x225FE74 Offset: 0x225FE74 VA: 0x225FE74 Slot: 3
	public override string ToString() { }

	// RVA: 0x225FF24 Offset: 0x225FF24 VA: 0x225FF24
	private static void .cctor() { }
}
