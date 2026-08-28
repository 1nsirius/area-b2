// Namespace: 
public class invite.invite_req.request : SprotoTypeBase // TypeDefIndex: 9425
{
	// Fields
	private static int max_field_count; // 0x0
	private long _invite_uid; // 0x18
	private long _invite_type; // 0x20
	private string _extra_arg; // 0x28
	private long _combat_type; // 0x30

	// Properties
	public long invite_uid { get; set; }
	public bool HasInvite_uid { get; }
	public long invite_type { get; set; }
	public bool HasInvite_type { get; }
	public string extra_arg { get; set; }
	public bool HasExtra_arg { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }

	// Methods

	// RVA: 0x226F9A8 Offset: 0x226F9A8 VA: 0x226F9A8
	public long get_invite_uid() { }

	// RVA: 0x226F9B0 Offset: 0x226F9B0 VA: 0x226F9B0
	public void set_invite_uid(long value) { }

	// RVA: 0x226F9F4 Offset: 0x226F9F4 VA: 0x226F9F4
	public bool get_HasInvite_uid() { }

	// RVA: 0x226FA24 Offset: 0x226FA24 VA: 0x226FA24
	public long get_invite_type() { }

	// RVA: 0x226FA2C Offset: 0x226FA2C VA: 0x226FA2C
	public void set_invite_type(long value) { }

	// RVA: 0x226FA70 Offset: 0x226FA70 VA: 0x226FA70
	public bool get_HasInvite_type() { }

	// RVA: 0x226FAA0 Offset: 0x226FAA0 VA: 0x226FAA0
	public string get_extra_arg() { }

	// RVA: 0x226FAA8 Offset: 0x226FAA8 VA: 0x226FAA8
	public void set_extra_arg(string value) { }

	// RVA: 0x226FAE8 Offset: 0x226FAE8 VA: 0x226FAE8
	public bool get_HasExtra_arg() { }

	// RVA: 0x226FB18 Offset: 0x226FB18 VA: 0x226FB18
	public long get_combat_type() { }

	// RVA: 0x226FB20 Offset: 0x226FB20 VA: 0x226FB20
	public void set_combat_type(long value) { }

	// RVA: 0x226FB64 Offset: 0x226FB64 VA: 0x226FB64
	public bool get_HasCombat_type() { }

	// RVA: 0x226FB94 Offset: 0x226FB94 VA: 0x226FB94
	public void .ctor() { }

	// RVA: 0x226FC30 Offset: 0x226FC30 VA: 0x226FC30
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226FCE8 Offset: 0x226FCE8 VA: 0x226FCE8 Slot: 5
	protected override void decode() { }

	// RVA: 0x226FE40 Offset: 0x226FE40 VA: 0x226FE40 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2270020 Offset: 0x2270020 VA: 0x2270020 Slot: 3
	public override string ToString() { }

	// RVA: 0x2270274 Offset: 0x2270274 VA: 0x2270274
	private static void .cctor() { }
}
