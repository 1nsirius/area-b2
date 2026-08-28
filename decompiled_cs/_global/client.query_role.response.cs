// Namespace: 
public class client.query_role.response : SprotoTypeBase // TypeDefIndex: 9157
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _uid; // 0x20
	private client.role_data _role; // 0x28
	private client.CharacterSkin _show_character; // 0x2C

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long uid { get; set; }
	public bool HasUid { get; }
	public client.role_data role { get; set; }
	public bool HasRole { get; }
	public client.CharacterSkin show_character { get; set; }
	public bool HasShow_character { get; }

	// Methods

	// RVA: 0x2449588 Offset: 0x2449588 VA: 0x2449588
	public long get_errorcode() { }

	// RVA: 0x2449590 Offset: 0x2449590 VA: 0x2449590
	public void set_errorcode(long value) { }

	// RVA: 0x24495D4 Offset: 0x24495D4 VA: 0x24495D4
	public bool get_HasErrorcode() { }

	// RVA: 0x2449604 Offset: 0x2449604 VA: 0x2449604
	public long get_uid() { }

	// RVA: 0x244960C Offset: 0x244960C VA: 0x244960C
	public void set_uid(long value) { }

	// RVA: 0x2449650 Offset: 0x2449650 VA: 0x2449650
	public bool get_HasUid() { }

	// RVA: 0x2449680 Offset: 0x2449680 VA: 0x2449680
	public client.role_data get_role() { }

	// RVA: 0x2449688 Offset: 0x2449688 VA: 0x2449688
	public void set_role(client.role_data value) { }

	// RVA: 0x24496C8 Offset: 0x24496C8 VA: 0x24496C8
	public bool get_HasRole() { }

	// RVA: 0x24496F8 Offset: 0x24496F8 VA: 0x24496F8
	public client.CharacterSkin get_show_character() { }

	// RVA: 0x2449700 Offset: 0x2449700 VA: 0x2449700
	public void set_show_character(client.CharacterSkin value) { }

	// RVA: 0x2449740 Offset: 0x2449740 VA: 0x2449740
	public bool get_HasShow_character() { }

	// RVA: 0x2449770 Offset: 0x2449770 VA: 0x2449770
	public void .ctor() { }

	// RVA: 0x244980C Offset: 0x244980C VA: 0x244980C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x24498C4 Offset: 0x24498C4 VA: 0x24498C4 Slot: 5
	protected override void decode() { }

	// RVA: 0x2449A6C Offset: 0x2449A6C VA: 0x2449A6C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2449C40 Offset: 0x2449C40 VA: 0x2449C40 Slot: 3
	public override string ToString() { }

	// RVA: 0x2449E70 Offset: 0x2449E70 VA: 0x2449E70
	private static void .cctor() { }
}
