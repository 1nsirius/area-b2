namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E90 Offset: 0x553E90 VA: 0x553E90
public class LeaderBoardData : BaseSingleton<LeaderBoardData> // TypeDefIndex: 9905
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x5634D4 Offset: 0x5634D4 VA: 0x5634D4
	private readonly LeaderBoardData.Event <OnUpdate>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5634E4 Offset: 0x5634E4 VA: 0x5634E4
	private readonly Dictionary<int, LeaderBoardData.RankCenter> <mLdCenter>k__BackingField; // 0xC

	// Properties
	public LeaderBoardData.Event OnUpdate { get; }
	public Dictionary<int, LeaderBoardData.RankCenter> mLdCenter { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646DC0 Offset: 0x646DC0 VA: 0x646DC0
	// RVA: 0xF46300 Offset: 0xF46300 VA: 0xF46300
	public LeaderBoardData.Event get_OnUpdate() { }

	[CompilerGeneratedAttribute] // RVA: 0x646DD0 Offset: 0x646DD0 VA: 0x646DD0
	// RVA: 0xF46308 Offset: 0xF46308 VA: 0xF46308
	public Dictionary<int, LeaderBoardData.RankCenter> get_mLdCenter() { }

	// RVA: 0xF46310 Offset: 0xF46310 VA: 0xF46310
	public LeaderBoardList GetRankList(int areaType, int rankType, int subType) { }

	// RVA: 0xF46330 Offset: 0xF46330 VA: 0xF46330
	public LeaderBoardList GetRankList(int areaType, LeaderBoardType rankType) { }

	// RVA: 0xF464AC Offset: 0xF464AC VA: 0xF464AC
	public void Replace(int areaType, LeaderBoardList list) { }

	// RVA: 0xF46768 Offset: 0xF46768 VA: 0xF46768
	public void Clear() { }

	// RVA: 0xF46844 Offset: 0xF46844 VA: 0xF46844
	public void .ctor() { }
}

} // namespace FGame
