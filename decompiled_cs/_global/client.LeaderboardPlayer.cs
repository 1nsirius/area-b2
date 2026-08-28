// Namespace: 
public class client.LeaderboardPlayer : SprotoTypeBase // TypeDefIndex: 9063
{
	// Fields
	private static int max_field_count; // 0x0
	private string _uid; // 0x14
	private client.LeaderboardInfo _info; // 0x18
	private long _score; // 0x20
	private long _score2; // 0x28
	private long _score3; // 0x30
	private long _likes; // 0x38

	// Properties
	public string uid { get; set; }
	public bool HasUid { get; }
	public client.LeaderboardInfo info { get; set; }
	public bool HasInfo { get; }
	public long score { get; set; }
	public bool HasScore { get; }
	public long score2 { get; set; }
	public bool HasScore2 { get; }
	public long score3 { get; set; }
	public bool HasScore3 { get; }
	public long likes { get; set; }
	public bool HasLikes { get; }

	// Methods

	// RVA: 0x24329EC Offset: 0x24329EC VA: 0x24329EC
	public string get_uid() { }

	// RVA: 0x24329F4 Offset: 0x24329F4 VA: 0x24329F4
	public void set_uid(string value) { }

	// RVA: 0x2432A34 Offset: 0x2432A34 VA: 0x2432A34
	public bool get_HasUid() { }

	// RVA: 0x2432A64 Offset: 0x2432A64 VA: 0x2432A64
	public client.LeaderboardInfo get_info() { }

	// RVA: 0x2432A6C Offset: 0x2432A6C VA: 0x2432A6C
	public void set_info(client.LeaderboardInfo value) { }

	// RVA: 0x2432AAC Offset: 0x2432AAC VA: 0x2432AAC
	public bool get_HasInfo() { }

	// RVA: 0x2432ADC Offset: 0x2432ADC VA: 0x2432ADC
	public long get_score() { }

	// RVA: 0x2432AE4 Offset: 0x2432AE4 VA: 0x2432AE4
	public void set_score(long value) { }

	// RVA: 0x2432B28 Offset: 0x2432B28 VA: 0x2432B28
	public bool get_HasScore() { }

	// RVA: 0x2432B58 Offset: 0x2432B58 VA: 0x2432B58
	public long get_score2() { }

	// RVA: 0x2432B60 Offset: 0x2432B60 VA: 0x2432B60
	public void set_score2(long value) { }

	// RVA: 0x2432BA4 Offset: 0x2432BA4 VA: 0x2432BA4
	public bool get_HasScore2() { }

	// RVA: 0x2432BD4 Offset: 0x2432BD4 VA: 0x2432BD4
	public long get_score3() { }

	// RVA: 0x2432BDC Offset: 0x2432BDC VA: 0x2432BDC
	public void set_score3(long value) { }

	// RVA: 0x2432C20 Offset: 0x2432C20 VA: 0x2432C20
	public bool get_HasScore3() { }

	// RVA: 0x2432C50 Offset: 0x2432C50 VA: 0x2432C50
	public long get_likes() { }

	// RVA: 0x2432C58 Offset: 0x2432C58 VA: 0x2432C58
	public void set_likes(long value) { }

	// RVA: 0x2432C9C Offset: 0x2432C9C VA: 0x2432C9C
	public bool get_HasLikes() { }

	// RVA: 0x2432CCC Offset: 0x2432CCC VA: 0x2432CCC
	public void .ctor() { }

	// RVA: 0x2432D68 Offset: 0x2432D68 VA: 0x2432D68
	public void .ctor(byte[] buffer) { }

	// RVA: 0x2432E20 Offset: 0x2432E20 VA: 0x2432E20 Slot: 5
	protected override void decode() { }

	// RVA: 0x243302C Offset: 0x243302C VA: 0x243302C Slot: 4
	public override int encode(SprotoStream stream) { }

	// RVA: 0x24332CC Offset: 0x24332CC VA: 0x24332CC Slot: 3
	public override string ToString() { }

	// RVA: 0x24335EC Offset: 0x24335EC VA: 0x24335EC
	private static void .cctor() { }
}
