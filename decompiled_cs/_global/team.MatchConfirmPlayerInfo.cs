// Namespace: 
public class team.MatchConfirmPlayerInfo : SprotoTypeBase // TypeDefIndex: 9456
{
	// Fields
	private static int max_field_count; // 0x0
	private long _uid; // 0x18
	private long _icon; // 0x20
	private bool _is_ready; // 0x28

	// Properties
	public long uid { get; set; }
	public bool HasUid { get; }
	public long icon { get; set; }
	public bool HasIcon { get; }
	public bool is_ready { get; set; }
	public bool HasIs_ready { get; }

	// Methods

	// RVA: 0xD7100C Offset: 0xD7100C VA: 0xD7100C
	public long get_uid() { }

	// RVA: 0xD71014 Offset: 0xD71014 VA: 0xD71014
	public void set_uid(long value) { }

	// RVA: 0xD71058 Offset: 0xD71058 VA: 0xD71058
	public bool get_HasUid() { }

	// RVA: 0xD71088 Offset: 0xD71088 VA: 0xD71088
	public long get_icon() { }

	// RVA: 0xD71090 Offset: 0xD71090 VA: 0xD71090
	public void set_icon(long value) { }

	// RVA: 0xD710D4 Offset: 0xD710D4 VA: 0xD710D4
	public bool get_HasIcon() { }

	// RVA: 0xD71104 Offset: 0xD71104 VA: 0xD71104
	public bool get_is_ready() { }

	// RVA: 0xD7110C Offset: 0xD7110C VA: 0xD7110C
	public void set_is_ready(bool value) { }

	// RVA: 0xD7114C Offset: 0xD7114C VA: 0xD7114C
	public bool get_HasIs_ready() { }

	// RVA: 0xD7117C Offset: 0xD7117C VA: 0xD7117C
	public void .ctor() { }

	// RVA: 0xD71218 Offset: 0xD71218 VA: 0xD71218
	public void .ctor(byte[] buffer) { }

	// RVA: 0xD712D0 Offset: 0xD712D0 VA: 0xD712D0 Slot: 5
	protected override void decode() { }

	// RVA: 0xD713F0 Offset: 0xD713F0 VA: 0xD713F0 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0xD71574 Offset: 0xD71574 VA: 0xD71574 Slot: 3
	public override string ToString() { }

	// RVA: 0xD71654 Offset: 0xD71654 VA: 0xD71654
	private static void .cctor() { }
}
