// Namespace: 
public class client.online_status.request : SprotoTypeBase // TypeDefIndex: 9136
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private bool _online; // 0x20

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public bool online { get; set; }
	public bool HasOnline { get; }

	// Methods

	// RVA: 0x2443EC0 Offset: 0x2443EC0 VA: 0x2443EC0
	public long get_uid() { }

	// RVA: 0x2443EC8 Offset: 0x2443EC8 VA: 0x2443EC8
	public void set_uid(long value) { }

	// RVA: 0x2443F0C Offset: 0x2443F0C VA: 0x2443F0C
	public bool get_HasUid() { }

	// RVA: 0x2443F3C Offset: 0x2443F3C VA: 0x2443F3C
	public bool get_online() { }

	// RVA: 0x2443F44 Offset: 0x2443F44 VA: 0x2443F44
	public void set_online(bool value) { }

	// RVA: 0x2443F84 Offset: 0x2443F84 VA: 0x2443F84
	public bool get_HasOnline() { }

	// RVA: 0x2443FB4 Offset: 0x2443FB4 VA: 0x2443FB4
	public void .ctor() { }

	// RVA: 0x2444050 Offset: 0x2444050 VA: 0x2444050
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2444108 Offset: 0x2444108 VA: 0x2444108 Slot: 5
	protected override void decode() { }

	// RVA: 0x24441E0 Offset: 0x24441E0 VA: 0x24441E0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2444300 Offset: 0x2444300 VA: 0x2444300 Slot: 3
	public override string ToString() { }

	// RVA: 0x24443BC Offset: 0x24443BC VA: 0x24443BC
	private static void .cctor() { }
}
