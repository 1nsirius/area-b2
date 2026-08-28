// Namespace: 
public class client.query_friend_leaderboard.request : SprotoTypeBase // TypeDefIndex: 9147
{
	// Fields
	private static int max_field_count; // 0x0
	private long _type; // 0x18
	private List<long> _friend_uid_list; // 0x20
	private long _extra_arg; // 0x28

	// Properties
	public long type { get; set; }
	public bool HasType { get; }
	public List<long> friend_uid_list { get; set; }
	public bool HasFriend_uid_list { get; }
	public long extra_arg { get; set; }
	public bool HasExtra_arg { get; }

	// Methods

	// RVA: 0x2446044 Offset: 0x2446044 VA: 0x2446044
	public long get_type() { }

	// RVA: 0x244604C Offset: 0x244604C VA: 0x244604C
	public void set_type(long value) { }

	// RVA: 0x2446090 Offset: 0x2446090 VA: 0x2446090
	public bool get_HasType() { }

	// RVA: 0x24460C0 Offset: 0x24460C0 VA: 0x24460C0
	public List<long> get_friend_uid_list() { }

	// RVA: 0x24460C8 Offset: 0x24460C8 VA: 0x24460C8
	public void set_friend_uid_list(List<long> value) { }

	// RVA: 0x2446108 Offset: 0x2446108 VA: 0x2446108
	public bool get_HasFriend_uid_list() { }

	// RVA: 0x2446138 Offset: 0x2446138 VA: 0x2446138
	public long get_extra_arg() { }

	// RVA: 0x2446140 Offset: 0x2446140 VA: 0x2446140
	public void set_extra_arg(long value) { }

	// RVA: 0x2446184 Offset: 0x2446184 VA: 0x2446184
	public bool get_HasExtra_arg() { }

	// RVA: 0x24461B4 Offset: 0x24461B4 VA: 0x24461B4
	public void .ctor() { }

	// RVA: 0x2446250 Offset: 0x2446250 VA: 0x2446250
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2446308 Offset: 0x2446308 VA: 0x2446308 Slot: 5
	protected override void decode() { }

	// RVA: 0x2446428 Offset: 0x2446428 VA: 0x2446428 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24465A4 Offset: 0x24465A4 VA: 0x24465A4 Slot: 3
	public override string ToString() { }

	// RVA: 0x244667C Offset: 0x244667C VA: 0x244667C
	private static void .cctor() { }
}
