// Namespace: 
public class invite.invite_notify.request : SprotoTypeBase // TypeDefIndex: 9416
{
	// Fields
	private static int max_field_count; // 0x0
	private invite.InvitePlayerInfo _invite_player; // 0x14
	private long _invite_type; // 0x18
	private string _identify_id; // 0x20
	private long _combat_type; // 0x28

	// Properties
	public invite.InvitePlayerInfo invite_player { get; set; }
	public bool HasInvite_player { get; }
	public long invite_type { get; set; }
	public bool HasInvite_type { get; }
	public string identify_id { get; set; }
	public bool HasIdentify_id { get; }
	public long combat_type { get; set; }
	public bool HasCombat_type { get; }

	// Methods

	// RVA: 0x226DD58 Offset: 0x226DD58 VA: 0x226DD58
	public invite.InvitePlayerInfo get_invite_player() { }

	// RVA: 0x226DD60 Offset: 0x226DD60 VA: 0x226DD60
	public void set_invite_player(invite.InvitePlayerInfo value) { }

	// RVA: 0x226DDA0 Offset: 0x226DDA0 VA: 0x226DDA0
	public bool get_HasInvite_player() { }

	// RVA: 0x226DDD0 Offset: 0x226DDD0 VA: 0x226DDD0
	public long get_invite_type() { }

	// RVA: 0x226DDD8 Offset: 0x226DDD8 VA: 0x226DDD8
	public void set_invite_type(long value) { }

	// RVA: 0x226DE1C Offset: 0x226DE1C VA: 0x226DE1C
	public bool get_HasInvite_type() { }

	// RVA: 0x226DE4C Offset: 0x226DE4C VA: 0x226DE4C
	public string get_identify_id() { }

	// RVA: 0x226DE54 Offset: 0x226DE54 VA: 0x226DE54
	public void set_identify_id(string value) { }

	// RVA: 0x226DE94 Offset: 0x226DE94 VA: 0x226DE94
	public bool get_HasIdentify_id() { }

	// RVA: 0x226DEC4 Offset: 0x226DEC4 VA: 0x226DEC4
	public long get_combat_type() { }

	// RVA: 0x226DECC Offset: 0x226DECC VA: 0x226DECC
	public void set_combat_type(long value) { }

	// RVA: 0x226DF10 Offset: 0x226DF10 VA: 0x226DF10
	public bool get_HasCombat_type() { }

	// RVA: 0x226DF40 Offset: 0x226DF40 VA: 0x226DF40
	public void .ctor() { }

	// RVA: 0x226DFDC Offset: 0x226DFDC VA: 0x226DFDC
	public void .ctor(byte[] buffer) { }

	// RVA: 0x226E094 Offset: 0x226E094 VA: 0x226E094 Slot: 5
	protected override void decode() { }

	// RVA: 0x226E230 Offset: 0x226E230 VA: 0x226E230 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x226E408 Offset: 0x226E408 VA: 0x226E408 Slot: 3
	public override string ToString() { }

	// RVA: 0x226E638 Offset: 0x226E638 VA: 0x226E638
	private static void .cctor() { }
}
