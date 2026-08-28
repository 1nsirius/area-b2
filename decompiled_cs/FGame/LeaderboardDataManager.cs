namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553EA4 Offset: 0x553EA4 VA: 0x553EA4
public class LeaderboardDataManager : BaseSingleton<LeaderboardDataManager> // TypeDefIndex: 9911
{
	// Fields
	public int mExpire; // 0x8

	// Methods

	// RVA: 0xF455CC Offset: 0xF455CC VA: 0xF455CC
	public void Initialize() { }

	// RVA: 0xF42930 Offset: 0xF42930 VA: 0xF42930
	public void Shutdown() { }

	// RVA: 0xF46BAC Offset: 0xF46BAC VA: 0xF46BAC
	public void SetExpireDuration(int duration) { }

	// RVA: 0xF46BB4 Offset: 0xF46BB4 VA: 0xF46BB4
	public void OnQueryLeaderboard(client.query_leaderboard.response pkt) { }

	// RVA: 0xF46FD8 Offset: 0xF46FD8 VA: 0xF46FD8
	public void OnQueryFriendLeaderboard(client.query_friend_leaderboard.response pkt) { }

	// RVA: 0xF46CBC Offset: 0xF46CBC VA: 0xF46CBC
	private LeaderBoardList Translate(client.query_leaderboard.response pkt) { }

	// RVA: 0xF470E0 Offset: 0xF470E0 VA: 0xF470E0
	private LeaderBoardList Translate(client.query_friend_leaderboard.response pkt) { }

	// RVA: 0xF478E0 Offset: 0xF478E0 VA: 0xF478E0
	private static void Sort(LeaderBoardList ret) { }

	// RVA: 0xF473B8 Offset: 0xF473B8 VA: 0xF473B8
	private LeaderBoardList CreateLeaderBoardList(int leaderBoardKey, int subKey) { }

	// RVA: 0xF4753C Offset: 0xF4753C VA: 0xF4753C
	private static LeaderBoardList.RankEntity TranslateToRankEntity(client.LeaderboardPlayer player, int rank) { }

	// RVA: 0xF47764 Offset: 0xF47764 VA: 0xF47764
	private static LeaderBoardList.RankEntity LocalCreateRankEntity(LeaderboardType leaderboardType, int subType = 0) { }

	// RVA: 0xF480E8 Offset: 0xF480E8 VA: 0xF480E8
	private static LeaderBoardList.RankEntity CreateSkinTypeEntity() { }

	// RVA: 0xF47AD4 Offset: 0xF47AD4 VA: 0xF47AD4
	private static LeaderBoardList.RankEntity CreateRankTypeEntity() { }

	// RVA: 0xF47F2C Offset: 0xF47F2C VA: 0xF47F2C
	private static LeaderBoardList.RankEntity CreateCharacterTypeEntity(int characterId) { }

	// RVA: 0xF47D00 Offset: 0xF47D00 VA: 0xF47D00
	private static LeaderBoardList.RankEntity CreateLevelTypeEntity() { }

	// RVA: 0xF487C0 Offset: 0xF487C0 VA: 0xF487C0
	private static LeaderBoardList.RankEntity CreateEmptyEntity(PlayerBaseData playerBaseInfo) { }

	// RVA: 0xF48888 Offset: 0xF48888 VA: 0xF48888
	public void .ctor() { }
}

} // namespace FGame
