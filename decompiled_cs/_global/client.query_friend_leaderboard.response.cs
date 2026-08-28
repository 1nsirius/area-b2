// Namespace: 
public class client.query_friend_leaderboard.response : SprotoTypeBase // TypeDefIndex: 9148
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _type; // 0x20
	private List<client.LeaderboardPlayer> _players; // 0x28
	private long _extra_arg; // 0x30

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long type { get; set; }
	public bool HasType { get; }
	public List<client.LeaderboardPlayer> players { get; set; }
	public bool HasPlayers { get; }
	public long extra_arg { get; set; }
	public bool HasExtra_arg { get; }

	// Methods

	// RVA: 0x24466E4 Offset: 0x24466E4 VA: 0x24466E4
	public long get_errorcode() { }

	// RVA: 0x24466EC Offset: 0x24466EC VA: 0x24466EC
	public void set_errorcode(long value) { }

	// RVA: 0x2446730 Offset: 0x2446730 VA: 0x2446730
	public bool get_HasErrorcode() { }

	// RVA: 0x2446760 Offset: 0x2446760 VA: 0x2446760
	public long get_type() { }

	// RVA: 0x2446768 Offset: 0x2446768 VA: 0x2446768
	public void set_type(long value) { }

	// RVA: 0x24467AC Offset: 0x24467AC VA: 0x24467AC
	public bool get_HasType() { }

	// RVA: 0x24467DC Offset: 0x24467DC VA: 0x24467DC
	public List<client.LeaderboardPlayer> get_players() { }

	// RVA: 0x24467E4 Offset: 0x24467E4 VA: 0x24467E4
	public void set_players(List<client.LeaderboardPlayer> value) { }

	// RVA: 0x2446824 Offset: 0x2446824 VA: 0x2446824
	public bool get_HasPlayers() { }

	// RVA: 0x2446854 Offset: 0x2446854 VA: 0x2446854
	public long get_extra_arg() { }

	// RVA: 0x244685C Offset: 0x244685C VA: 0x244685C
	public void set_extra_arg(long value) { }

	// RVA: 0x24468A0 Offset: 0x24468A0 VA: 0x24468A0
	public bool get_HasExtra_arg() { }

	// RVA: 0x24468D0 Offset: 0x24468D0 VA: 0x24468D0
	public void .ctor() { }

	// RVA: 0x244696C Offset: 0x244696C VA: 0x244696C
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2446A24 Offset: 0x2446A24 VA: 0x2446A24 Slot: 5
	protected override void decode() { }

	// RVA: 0x2446BC4 Offset: 0x2446BC4 VA: 0x2446BC4 Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2446DEC Offset: 0x2446DEC VA: 0x2446DEC Slot: 3
	public override string ToString() { }

	// RVA: 0x2447058 Offset: 0x2447058 VA: 0x2447058
	private static void .cctor() { }
}
