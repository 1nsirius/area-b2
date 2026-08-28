// Namespace: 
public class invite.invite_reply_req.request : SprotoTypeBase // TypeDefIndex: 9422
{
	// Fields
	private static int max_field_count; // 0x0
	private long _inviter_uid; // 0x18
	private bool _agree; // 0x20

	// Properties
	public long inviter_uid { get; set; }
	public bool HasInviter_uid { get; }
	public bool agree { get; set; }
	public bool HasAgree { get; }

	// Methods

	// RVA: 0x226F02C Offset: 0x226F02C VA: 0x226F02C
	public long get_inviter_uid() { }

	// RVA: 0x226F034 Offset: 0x226F034 VA: 0x226F034
	public void set_inviter_uid(long value) { }

	// RVA: 0x226F078 Offset: 0x226F078 VA: 0x226F078
	public bool get_HasInviter_uid() { }

	// RVA: 0x226F0A8 Offset: 0x226F0A8 VA: 0x226F0A8
	public bool get_agree() { }

	// RVA: 0x226F0B0 Offset: 0x226F0B0 VA: 0x226F0B0
	public void set_agree(bool value) { }

	// RVA: 0x226F0F0 Offset: 0x226F0F0 VA: 0x226F0F0
	public bool get_HasAgree() { }

	// RVA: 0x226F120 Offset: 0x226F120 VA: 0x226F120
	public void .ctor() { }

	// RVA: 0x226F1BC Offset: 0x226F1BC VA: 0x226F1BC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226F274 Offset: 0x226F274 VA: 0x226F274 Slot: 5
	protected override void decode() { }

	// RVA: 0x226F34C Offset: 0x226F34C VA: 0x226F34C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226F46C Offset: 0x226F46C VA: 0x226F46C Slot: 3
	public override string ToString() { }

	// RVA: 0x226F528 Offset: 0x226F528 VA: 0x226F528
	private static void .cctor() { }
}
