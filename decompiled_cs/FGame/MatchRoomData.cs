namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553F64 Offset: 0x553F64 VA: 0x553F64
public class MatchRoomData : BaseSingleton<MatchRoomData> // TypeDefIndex: 9925
{
	// Fields
	private const int mDefSlotMaxSize = 5;
	[CompilerGeneratedAttribute] // RVA: 0x5635B4 Offset: 0x5635B4 VA: 0x5635B4
	private byte <CaptainIndex>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x5635C4 Offset: 0x5635C4 VA: 0x5635C4
	private bool <IsInMatching>k__BackingField; // 0x9
	[CompilerGeneratedAttribute] // RVA: 0x5635D4 Offset: 0x5635D4 VA: 0x5635D4
	private int <PredictTime>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5635E4 Offset: 0x5635E4 VA: 0x5635E4
	private string <RoomId>k__BackingField; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x5635F4 Offset: 0x5635F4 VA: 0x5635F4
	private int <BattleZone>k__BackingField; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x563604 Offset: 0x563604 VA: 0x563604
	private byte <SelfIndex>k__BackingField; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x563614 Offset: 0x563614 VA: 0x563614
	private LuaArray<RoomSlot> <Slots>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x563624 Offset: 0x563624 VA: 0x563624
	private long <StartTime>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x563634 Offset: 0x563634 VA: 0x563634
	private CombatType <CombatType>k__BackingField; // 0x28
	[CompilerGeneratedAttribute] // RVA: 0x563644 Offset: 0x563644 VA: 0x563644
	private int <MinRankLimit>k__BackingField; // 0x2C
	[CompilerGeneratedAttribute] // RVA: 0x563654 Offset: 0x563654 VA: 0x563654
	private int <MaxRankLimit>k__BackingField; // 0x30

	// Properties
	public int Count { get; }
	public int PlayerCount { get; }
	public byte CaptainIndex { get; set; }
	public bool IsInMatching { get; set; }
	public int PredictTime { get; set; }
	public string RoomId { get; set; }
	public int BattleZone { get; set; }
	public byte SelfIndex { get; set; }
	public LuaArray<RoomSlot> Slots { get; set; }
	public long StartTime { get; set; }
	public CombatType CombatType { get; set; }
	public int MinRankLimit { get; set; }
	public int MaxRankLimit { get; set; }

	// Methods

	// RVA: 0xF5AE04 Offset: 0xF5AE04 VA: 0xF5AE04
	public int get_Count() { }

	// RVA: 0xF5AE80 Offset: 0xF5AE80 VA: 0xF5AE80
	public int get_PlayerCount() { }

	[CompilerGeneratedAttribute] // RVA: 0x646F50 Offset: 0x646F50 VA: 0x646F50
	// RVA: 0xF5AF98 Offset: 0xF5AF98 VA: 0xF5AF98
	public byte get_CaptainIndex() { }

	[CompilerGeneratedAttribute] // RVA: 0x646F60 Offset: 0x646F60 VA: 0x646F60
	// RVA: 0xF5AFA0 Offset: 0xF5AFA0 VA: 0xF5AFA0
	private void set_CaptainIndex(byte value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646F70 Offset: 0x646F70 VA: 0x646F70
	// RVA: 0xF5AFA8 Offset: 0xF5AFA8 VA: 0xF5AFA8
	public bool get_IsInMatching() { }

	[CompilerGeneratedAttribute] // RVA: 0x646F80 Offset: 0x646F80 VA: 0x646F80
	// RVA: 0xF5AFB0 Offset: 0xF5AFB0 VA: 0xF5AFB0
	private void set_IsInMatching(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646F90 Offset: 0x646F90 VA: 0x646F90
	// RVA: 0xF5AFB8 Offset: 0xF5AFB8 VA: 0xF5AFB8
	public int get_PredictTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x646FA0 Offset: 0x646FA0 VA: 0x646FA0
	// RVA: 0xF5AFC0 Offset: 0xF5AFC0 VA: 0xF5AFC0
	private void set_PredictTime(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646FB0 Offset: 0x646FB0 VA: 0x646FB0
	// RVA: 0xF5AFC8 Offset: 0xF5AFC8 VA: 0xF5AFC8
	public string get_RoomId() { }

	[CompilerGeneratedAttribute] // RVA: 0x646FC0 Offset: 0x646FC0 VA: 0x646FC0
	// RVA: 0xF5AFD0 Offset: 0xF5AFD0 VA: 0xF5AFD0
	private void set_RoomId(string value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646FD0 Offset: 0x646FD0 VA: 0x646FD0
	// RVA: 0xF5AFD8 Offset: 0xF5AFD8 VA: 0xF5AFD8
	public int get_BattleZone() { }

	[CompilerGeneratedAttribute] // RVA: 0x646FE0 Offset: 0x646FE0 VA: 0x646FE0
	// RVA: 0xF5AFE0 Offset: 0xF5AFE0 VA: 0xF5AFE0
	private void set_BattleZone(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646FF0 Offset: 0x646FF0 VA: 0x646FF0
	// RVA: 0xF5AFE8 Offset: 0xF5AFE8 VA: 0xF5AFE8
	public byte get_SelfIndex() { }

	[CompilerGeneratedAttribute] // RVA: 0x647000 Offset: 0x647000 VA: 0x647000
	// RVA: 0xF5AFF0 Offset: 0xF5AFF0 VA: 0xF5AFF0
	private void set_SelfIndex(byte value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647010 Offset: 0x647010 VA: 0x647010
	// RVA: 0xF5AE78 Offset: 0xF5AE78 VA: 0xF5AE78
	public LuaArray<RoomSlot> get_Slots() { }

	[CompilerGeneratedAttribute] // RVA: 0x647020 Offset: 0x647020 VA: 0x647020
	// RVA: 0xF5AFF8 Offset: 0xF5AFF8 VA: 0xF5AFF8
	public void set_Slots(LuaArray<RoomSlot> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647030 Offset: 0x647030 VA: 0x647030
	// RVA: 0xF5B000 Offset: 0xF5B000 VA: 0xF5B000
	public long get_StartTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x647040 Offset: 0x647040 VA: 0x647040
	// RVA: 0xF5B008 Offset: 0xF5B008 VA: 0xF5B008
	private void set_StartTime(long value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647050 Offset: 0x647050 VA: 0x647050
	// RVA: 0xF5B018 Offset: 0xF5B018 VA: 0xF5B018
	public CombatType get_CombatType() { }

	[CompilerGeneratedAttribute] // RVA: 0x647060 Offset: 0x647060 VA: 0x647060
	// RVA: 0xF5B020 Offset: 0xF5B020 VA: 0xF5B020
	private void set_CombatType(CombatType value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647070 Offset: 0x647070 VA: 0x647070
	// RVA: 0xF5B028 Offset: 0xF5B028 VA: 0xF5B028
	public int get_MinRankLimit() { }

	[CompilerGeneratedAttribute] // RVA: 0x647080 Offset: 0x647080 VA: 0x647080
	// RVA: 0xF5B030 Offset: 0xF5B030 VA: 0xF5B030
	private void set_MinRankLimit(int value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647090 Offset: 0x647090 VA: 0x647090
	// RVA: 0xF5B038 Offset: 0xF5B038 VA: 0xF5B038
	public int get_MaxRankLimit() { }

	[CompilerGeneratedAttribute] // RVA: 0x6470A0 Offset: 0x6470A0 VA: 0x6470A0
	// RVA: 0xF5B040 Offset: 0xF5B040 VA: 0xF5B040
	private void set_MaxRankLimit(int value) { }

	// RVA: 0xF5B048 Offset: 0xF5B048 VA: 0xF5B048
	public void CancelMatch() { }

	// RVA: 0xF5B11C Offset: 0xF5B11C VA: 0xF5B11C
	public RoomSlot GetSelfSlotData() { }

	// RVA: 0xF5B124 Offset: 0xF5B124 VA: 0xF5B124
	public RoomSlot GetSlotData(int index) { }

	// RVA: 0xF5B258 Offset: 0xF5B258 VA: 0xF5B258
	public bool IsNull() { }

	// RVA: 0xF5B264 Offset: 0xF5B264 VA: 0xF5B264
	public void RemoveAt(int index) { }

	// RVA: 0xF5B4C0 Offset: 0xF5B4C0 VA: 0xF5B4C0
	public static void ResetByPkt(team.TeamData pktData) { }

	// RVA: 0xF5B8E0 Offset: 0xF5B8E0 VA: 0xF5B8E0
	public void ResetMatchingState() { }

	// RVA: 0xF4A9D8 Offset: 0xF4A9D8 VA: 0xF4A9D8
	public void Clear() { }

	// RVA: 0xF5B8EC Offset: 0xF5B8EC VA: 0xF5B8EC
	public void StartMatch(int predictTime, long startTime) { }

	// RVA: 0xF5B2E4 Offset: 0xF5B2E4 VA: 0xF5B2E4
	public void UpdateSlot(int index, RoomSlot roomSlot) { }

	// RVA: 0xF5B640 Offset: 0xF5B640 VA: 0xF5B640
	private static void InnerResetByPkt(team.TeamData pktData, MatchRoomData self) { }

	// RVA: 0xF5B8FC Offset: 0xF5B8FC VA: 0xF5B8FC
	private static LuaArray<RoomSlot> InnerResetMemberByPkt(List<team.TeamMember> members) { }

	// RVA: 0xF5BD08 Offset: 0xF5BD08 VA: 0xF5BD08
	private static void InnerResetSelfIndex(MatchRoomData self) { }

	// RVA: -1 Offset: -1
	private static string List2String<T>(List<T> list) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xFBE684 Offset: 0xFBE684 VA: 0xFBE684
	|-MatchRoomData.List2String<object>
	*/

	// RVA: 0xF5B050 Offset: 0xF5B050 VA: 0xF5B050
	private void SetMatching(bool inMatching) { }

	// RVA: 0xF5BEC0 Offset: 0xF5BEC0 VA: 0xF5BEC0
	public void .ctor() { }
}

} // namespace FGame
