namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553FF0 Offset: 0x553FF0 VA: 0x553FF0
public class PreBattleData : BaseSingleton<PreBattleData> // TypeDefIndex: 9941
{
	// Fields
	private RoundInfo m_roundInfo; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563764 Offset: 0x563764 VA: 0x563764
	private CombatType <CombatType>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x563774 Offset: 0x563774 VA: 0x563774
	private game.RspRoomStart.request <RoomStartData>k__BackingField; // 0x10

	// Properties
	public CombatType CombatType { get; set; }
	public game.RspRoomStart.request RoomStartData { get; set; }
	public RoundInfo RoundInfo { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x6472A0 Offset: 0x6472A0 VA: 0x6472A0
	// RVA: 0xB786D4 Offset: 0xB786D4 VA: 0xB786D4
	public CombatType get_CombatType() { }

	[CompilerGeneratedAttribute] // RVA: 0x6472B0 Offset: 0x6472B0 VA: 0x6472B0
	// RVA: 0xB786DC Offset: 0xB786DC VA: 0xB786DC
	private void set_CombatType(CombatType value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6472C0 Offset: 0x6472C0 VA: 0x6472C0
	// RVA: 0xB786E4 Offset: 0xB786E4 VA: 0xB786E4
	private void set_RoomStartData(game.RspRoomStart.request value) { }

	[CompilerGeneratedAttribute] // RVA: 0x6472D0 Offset: 0x6472D0 VA: 0x6472D0
	// RVA: 0xB786EC Offset: 0xB786EC VA: 0xB786EC
	public game.RspRoomStart.request get_RoomStartData() { }

	// RVA: 0xB786F4 Offset: 0xB786F4 VA: 0xB786F4
	public RoundInfo get_RoundInfo() { }

	// RVA: 0xB786FC Offset: 0xB786FC VA: 0xB786FC
	public void InitBattleRoom(uint selfPlayerUid, game.RspRoomStart.request pkt) { }

	// RVA: 0xB7874C Offset: 0xB7874C VA: 0xB7874C
	public void OnEnterSelectCharacterState() { }

	// RVA: 0xB78AB4 Offset: 0xB78AB4 VA: 0xB78AB4
	public void OpenRoundStartView() { }

	// RVA: 0xB78E74 Offset: 0xB78E74 VA: 0xB78E74
	public void OnLeaveSelectCharacterState() { }

	// RVA: 0xB78F50 Offset: 0xB78F50 VA: 0xB78F50
	public void OnDestroy() { }

	// RVA: 0xB78F5C Offset: 0xB78F5C VA: 0xB78F5C
	public void OnRemoteSelectOcc(uint playerId, int occId, List<long> skins) { }

	// RVA: 0xB7906C Offset: 0xB7906C VA: 0xB7906C
	public void OnRemoteStageChange(uint playerId, PreBattleStage stage) { }

	// RVA: 0xB79080 Offset: 0xB79080 VA: 0xB79080
	public void OnChooseSpawnRegion(uint playerId, uint regionId) { }

	// RVA: 0xB79094 Offset: 0xB79094 VA: 0xB79094
	public void LocalReady() { }

	// RVA: 0xB7924C Offset: 0xB7924C VA: 0xB7924C
	public void LocalUnReady() { }

	// RVA: 0xB79250 Offset: 0xB79250 VA: 0xB79250
	public void OnPlayerReady(uint playerId) { }

	// RVA: 0xB7927C Offset: 0xB7927C VA: 0xB7927C
	public void OnPlayerUnReady(uint playerId) { }

	// RVA: 0xB792A8 Offset: 0xB792A8 VA: 0xB792A8
	public void OnStartLoading(RspRoomLoading pkt) { }

	// RVA: 0xB792BC Offset: 0xB792BC VA: 0xB792BC
	public void OnLoadFinish(uint playerId) { }

	// RVA: 0xB792D0 Offset: 0xB792D0 VA: 0xB792D0
	public void OnRemoteOffline(uint playerId) { }

	// RVA: 0xB793EC Offset: 0xB793EC VA: 0xB793EC
	public void OnRemoteReConnect(uint playerId) { }

	// RVA: 0xB79408 Offset: 0xB79408 VA: 0xB79408
	public bool GetOfflineState(uint playerId) { }

	// RVA: 0xB79430 Offset: 0xB79430 VA: 0xB79430
	public void OnRemoteQuit(uint playerId) { }

	// RVA: 0xB79444 Offset: 0xB79444 VA: 0xB79444
	public int GetSelfWinTimes() { }

	// RVA: 0xB79488 Offset: 0xB79488 VA: 0xB79488
	public int GetOtherWinTimes() { }

	// RVA: 0xB792EC Offset: 0xB792EC VA: 0xB792EC
	private BattlePlayerOccInfo GetPlayerOccInfo(uint playerUid) { }

	// RVA: 0xB794CC Offset: 0xB794CC VA: 0xB794CC
	public void Clear() { }

	// RVA: 0xB794D8 Offset: 0xB794D8 VA: 0xB794D8
	public static string GetCharacterPicNameByUnlockId(uint uid, int unlockId) { }

	// RVA: 0xB79544 Offset: 0xB79544 VA: 0xB79544
	public static string GetCharacterPicNameByCharacterId(uint uid, int characterId) { }

	// RVA: 0xB795C4 Offset: 0xB795C4 VA: 0xB795C4
	private static bool GetCharacterSuitPicName(uint uid, out string s) { }

	// RVA: 0xB79798 Offset: 0xB79798 VA: 0xB79798
	public void .ctor() { }
}

} // namespace FGame
