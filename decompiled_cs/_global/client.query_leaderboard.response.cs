// Namespace: 
public class client.query_leaderboard.response : SprotoTypeBase // TypeDefIndex: 9151
{
	// Fields
	private static int max_field_count; // 0x0
	private long _errorcode; // 0x18
	private long _type; // 0x20
	private List<client.LeaderboardPlayer> _players; // 0x28
	private List<long> _ranks; // 0x2C
	private long _myrank; // 0x30
	private client.LeaderboardPlayer _my_rankinfo; // 0x38
	private long _extra_arg; // 0x40

	// Properties
	public long errorcode { get; set; }
	public bool HasErrorcode { get; }
	public long type { get; set; }
	public bool HasType { get; }
	public List<client.LeaderboardPlayer> players { get; set; }
	public bool HasPlayers { get; }
	public List<long> ranks { get; set; }
	public bool HasRanks { get; }
	public long myrank { get; set; }
	public bool HasMyrank { get; }
	public client.LeaderboardPlayer my_rankinfo { get; set; }
	public bool HasMy_rankinfo { get; }
	public long extra_arg { get; set; }
	public bool HasExtra_arg { get; }

	// Methods

	// RVA: 0x2447A34 Offset: 0x2447A34 VA: 0x2447A34
	public long get_errorcode() { }

	// RVA: 0x2447A3C Offset: 0x2447A3C VA: 0x2447A3C
	public void set_errorcode(long value) { }

	// RVA: 0x2447A80 Offset: 0x2447A80 VA: 0x2447A80
	public bool get_HasErrorcode() { }

	// RVA: 0x2447AB0 Offset: 0x2447AB0 VA: 0x2447AB0
	public long get_type() { }

	// RVA: 0x2447AB8 Offset: 0x2447AB8 VA: 0x2447AB8
	public void set_type(long value) { }

	// RVA: 0x2447AFC Offset: 0x2447AFC VA: 0x2447AFC
	public bool get_HasType() { }

	// RVA: 0x2447B2C Offset: 0x2447B2C VA: 0x2447B2C
	public List<client.LeaderboardPlayer> get_players() { }

	// RVA: 0x2447B34 Offset: 0x2447B34 VA: 0x2447B34
	public void set_players(List<client.LeaderboardPlayer> value) { }

	// RVA: 0x2447B74 Offset: 0x2447B74 VA: 0x2447B74
	public bool get_HasPlayers() { }

	// RVA: 0x2447BA4 Offset: 0x2447BA4 VA: 0x2447BA4
	public List<long> get_ranks() { }

	// RVA: 0x2447BAC Offset: 0x2447BAC VA: 0x2447BAC
	public void set_ranks(List<long> value) { }

	// RVA: 0x2447BEC Offset: 0x2447BEC VA: 0x2447BEC
	public bool get_HasRanks() { }

	// RVA: 0x2447C1C Offset: 0x2447C1C VA: 0x2447C1C
	public long get_myrank() { }

	// RVA: 0x2447C24 Offset: 0x2447C24 VA: 0x2447C24
	public void set_myrank(long value) { }

	// RVA: 0x2447C68 Offset: 0x2447C68 VA: 0x2447C68
	public bool get_HasMyrank() { }

	// RVA: 0x2447C98 Offset: 0x2447C98 VA: 0x2447C98
	public client.LeaderboardPlayer get_my_rankinfo() { }

	// RVA: 0x2447CA0 Offset: 0x2447CA0 VA: 0x2447CA0
	public void set_my_rankinfo(client.LeaderboardPlayer value) { }

	// RVA: 0x2447CE0 Offset: 0x2447CE0 VA: 0x2447CE0
	public bool get_HasMy_rankinfo() { }

	// RVA: 0x2447D10 Offset: 0x2447D10 VA: 0x2447D10
	public long get_extra_arg() { }

	// RVA: 0x2447D18 Offset: 0x2447D18 VA: 0x2447D18
	public void set_extra_arg(long value) { }

	// RVA: 0x2447D5C Offset: 0x2447D5C VA: 0x2447D5C
	public bool get_HasExtra_arg() { }

	// RVA: 0x2447D8C Offset: 0x2447D8C VA: 0x2447D8C
	public void .ctor() { }

	// RVA: 0x2447E28 Offset: 0x2447E28 VA: 0x2447E28
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2447EE0 Offset: 0x2447EE0 VA: 0x2447EE0 Slot: 5
	protected override void decode() { }

	// RVA: 0x244812C Offset: 0x244812C VA: 0x244812C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x2448468 Offset: 0x2448468 VA: 0x2448468 Slot: 3
	public override string ToString() { }

	// RVA: 0x244880C Offset: 0x244880C VA: 0x244880C
	private static void .cctor() { }
}
