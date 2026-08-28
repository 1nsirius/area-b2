namespace FGame
{

// Namespace: FGame
public static class SendMsgHelp // TypeDefIndex: 9834
{
	// Fields
	private static int robotcount; // 0x0
	public static Action<long> ReqBuyStoreItemCallback; // 0x4

	// Methods

	// RVA: 0xB8A79C Offset: 0xB8A79C VA: 0xB8A79C
	public static void CreateRole(string name) { }

	// RVA: 0xB8A8E0 Offset: 0xB8A8E0 VA: 0xB8A8E0
	public static void ActiveRole(string code) { }

	// RVA: 0xB8A9AC Offset: 0xB8A9AC VA: 0xB8A9AC
	public static void ChangeName(string name) { }

	// RVA: 0xB8AA78 Offset: 0xB8AA78 VA: 0xB8AA78
	public static void Login(string loginName, string gameToken) { }

	// RVA: 0xB8ABA0 Offset: 0xB8ABA0 VA: 0xB8ABA0
	public static void SetLoginParm(bool isGuset, string temp) { }

	// RVA: 0xB8AC74 Offset: 0xB8AC74 VA: 0xB8AC74
	public static void CreateRoom() { }

	// RVA: 0xB8ADB0 Offset: 0xB8ADB0 VA: 0xB8ADB0
	public static void QuickEnterRoom() { }

	// RVA: 0xB8AE3C Offset: 0xB8AE3C VA: 0xB8AE3C
	public static void JoinRoom(uint id) { }

	// RVA: 0xB8AFAC Offset: 0xB8AFAC VA: 0xB8AFAC
	public static void RoomStart(uint regionType) { }

	// RVA: 0xB8B0F4 Offset: 0xB8B0F4 VA: 0xB8B0F4
	public static void ReqCancalMatch() { }

	// RVA: 0xB8B19C Offset: 0xB8B19C VA: 0xB8B19C
	public static void LeaveRoom() { }

	// RVA: 0xB8B244 Offset: 0xB8B244 VA: 0xB8B244
	public static void SwitchTeam() { }

	// RVA: 0xB8B2EC Offset: 0xB8B2EC VA: 0xB8B2EC
	public static void ReqChooseMapAndMode(uint mapID, uint modeID) { }

	// RVA: 0xB8B404 Offset: 0xB8B404 VA: 0xB8B404
	public static void ReqChooseMap(uint mapID) { }

	// RVA: 0xB8B4E0 Offset: 0xB8B4E0 VA: 0xB8B4E0
	public static void ReqChooseMode(uint modeID) { }

	// RVA: 0xB8B5BC Offset: 0xB8B5BC VA: 0xB8B5BC
	public static void ReqSelectMode(uint modeID) { }

	// RVA: 0xB8B5C0 Offset: 0xB8B5C0 VA: 0xB8B5C0
	public static void ReqEnterPreBattleStageToServer(PreBattleStage stage) { }

	// RVA: 0xB8B69C Offset: 0xB8B69C VA: 0xB8B69C
	public static void ReqChooseSpawnRegionConfirmToServer(uint region_id) { }

	// RVA: 0xB8B778 Offset: 0xB8B778 VA: 0xB8B778
	public static void LocalSelectOcc(int occId) { }

	// RVA: 0xB8B854 Offset: 0xB8B854 VA: 0xB8B854
	public static void ReqCurrentSelectedCharacterEquipInfos() { }

	// RVA: 0xB8B8FC Offset: 0xB8B8FC VA: 0xB8B8FC
	public static string GetRandomName() { }

	// RVA: 0xB8BC14 Offset: 0xB8BC14 VA: 0xB8BC14
	public static void ReqUserGuide(long guideId) { }

	// RVA: 0xB8BE64 Offset: 0xB8BE64 VA: 0xB8BE64
	public static void ReqLeaveBattleInBattle(LeaveBattleKind leaveKind) { }

	// RVA: 0xB8BF34 Offset: 0xB8BF34 VA: 0xB8BF34
	public static void ReqResetItemNum() { }

	// RVA: 0xB8BFFC Offset: 0xB8BFFC VA: 0xB8BFFC
	public static void ReqOpenMode(long modeId) { }

	// RVA: 0xB8C1D4 Offset: 0xB8C1D4 VA: 0xB8C1D4
	public static void ReqModeChooseCamp(long campId) { }

	// RVA: 0xB8C2B4 Offset: 0xB8C2B4 VA: 0xB8C2B4
	public static void ReqModeChooseMap(long mapId) { }

	// RVA: 0xB8C394 Offset: 0xB8C394 VA: 0xB8C394
	public static void ReqConfirmBattle() { }

	// RVA: 0xB8C43C Offset: 0xB8C43C VA: 0xB8C43C
	public static void ReqLeaveBattle() { }

	// RVA: 0xB8C4E4 Offset: 0xB8C4E4 VA: 0xB8C4E4
	public static void ReqGenRobot(int configId, Vector3 pos, Vector3 euler, int bodyState) { }

	// RVA: 0xB8C5E8 Offset: 0xB8C5E8 VA: 0xB8C5E8
	public static void AddRoomRobot(int npcid) { }

	// RVA: 0xB8C8A4 Offset: 0xB8C8A4 VA: 0xB8C8A4
	public static void ReqCancelMatch() { }

	// RVA: 0xB8C9B8 Offset: 0xB8C9B8 VA: 0xB8C9B8
	public static void ReqKickRoomMember(uint uid) { }

	// RVA: 0xB8CA94 Offset: 0xB8CA94 VA: 0xB8CA94
	public static void ReqExchangeRoomSlot(BattleCamp camp, int targetIndex) { }

	// RVA: 0xB8CBAC Offset: 0xB8CBAC VA: 0xB8CBAC
	public static void ReqExchangeRoomSlotReplay(bool agree) { }

	// RVA: 0xB8CC78 Offset: 0xB8CC78 VA: 0xB8CC78
	public static void ReqConfirmMatch() { }

	// RVA: 0xB8CD20 Offset: 0xB8CD20 VA: 0xB8CD20
	public static void ReqGuideOperate(GuidOperation op) { }

	// RVA: 0xB8CDF0 Offset: 0xB8CDF0 VA: 0xB8CDF0
	public static void ReqBombModeOperatorBombFunc(int opCode) { }

	// RVA: 0xB8CECC Offset: 0xB8CECC VA: 0xB8CECC
	public static void ReqInviteTeam(uint targetUid, int combatType, string fbName) { }

	// RVA: 0xB8D04C Offset: 0xB8D04C VA: 0xB8D04C
	public static void ReqExchangeReply(bool agree) { }

	// RVA: 0xB8D118 Offset: 0xB8D118 VA: 0xB8D118
	public static void JoinTeam(uint id) { }

	// RVA: 0xB8D208 Offset: 0xB8D208 VA: 0xB8D208
	public static void ReqRecoverBattle() { }

	// RVA: 0xB8D2D0 Offset: 0xB8D2D0 VA: 0xB8D2D0
	public static void ReqBattleLoaded() { }

	// RVA: 0xB8D398 Offset: 0xB8D398 VA: 0xB8D398
	public static void ReqGetStoreCharacter(int type) { }

	// RVA: 0xB8D474 Offset: 0xB8D474 VA: 0xB8D474
	public static void ReqGetGiftItemPrice(int type) { }

	// RVA: 0xB8D550 Offset: 0xB8D550 VA: 0xB8D550
	public static void ReqGetStoreSales() { }

	// RVA: 0xB8D5F8 Offset: 0xB8D5F8 VA: 0xB8D5F8
	public static void GetRechargeItems() { }

	// RVA: 0xB8D6A0 Offset: 0xB8D6A0 VA: 0xB8D6A0
	public static void GetSkinsReq() { }

	// RVA: 0xB8D748 Offset: 0xB8D748 VA: 0xB8D748
	public static void RequestUseSkin(int skinId, int charId, int propId) { }

	// RVA: 0xB8D894 Offset: 0xB8D894 VA: 0xB8D894
	public static void RequestAddSkin(int skinId) { }

	// RVA: 0xB8D970 Offset: 0xB8D970 VA: 0xB8D970
	public static void ReqBuyStoreItem(int itemId, int moneyType, int itemIdType = 0, bool notDiscountStore = False, Action<long> callback) { }

	// RVA: 0xB8DB30 Offset: 0xB8DB30 VA: 0xB8DB30
	public static void ReqMailList() { }

	// RVA: 0xB8DBD8 Offset: 0xB8DBD8 VA: 0xB8DBD8
	public static void ReqOperateMail(long operateType, long mailID) { }

	// RVA: 0xB8DCF8 Offset: 0xB8DCF8 VA: 0xB8DCF8
	public static void ReqDeleteAllReadMail(MailType mailType) { }

	// RVA: 0xB8DDD4 Offset: 0xB8DDD4 VA: 0xB8DDD4
	public static void ReqGetAllReward(MailType mailType) { }

	// RVA: 0xB8DEB0 Offset: 0xB8DEB0 VA: 0xB8DEB0
	public static void ReqChangeTeamBattleZone(uint battleZoneId) { }

	// RVA: 0xB8DF8C Offset: 0xB8DF8C VA: 0xB8DF8C
	public static void ReqChangeRoomBattleZone(uint battleZoneId) { }

	// RVA: 0xB8E068 Offset: 0xB8E068 VA: 0xB8E068
	public static void ReqReportPlayer(uint accountId, string desc, List<long> reportReasons) { }

	// RVA: 0xB8E234 Offset: 0xB8E234 VA: 0xB8E234
	public static void ReqGetRankReward(long rankID) { }

	// RVA: 0xB8E314 Offset: 0xB8E314 VA: 0xB8E314
	public static void ReqSwitchShowCharacter(int characterId) { }

	// RVA: 0xB8E45C Offset: 0xB8E45C VA: 0xB8E45C
	public static void ReqChangeHeadFrame(int id) { }

	// RVA: 0xB8E538 Offset: 0xB8E538 VA: 0xB8E538
	public static void QueryLeaderBoard(int leaderBoardType, int subKey, int start, int end) { }

	// RVA: 0xB8E6B8 Offset: 0xB8E6B8 VA: 0xB8E6B8
	public static void QueryFriendLeaderBoard(int leaderBoardType, int subKey, List<long> friendList) { }

	// RVA: 0xB71088 Offset: 0xB71088 VA: 0xB71088
	public static void ReqServerSaveClientConfig(string key, long value) { }

	// RVA: 0xB8E7FC Offset: 0xB8E7FC VA: 0xB8E7FC
	public static void ReturnHallReq() { }

	// RVA: 0xB8E910 Offset: 0xB8E910 VA: 0xB8E910
	public static void ReqOperateVoiceChannel(long operate_type) { }

	// RVA: 0xB8E9F0 Offset: 0xB8E9F0 VA: 0xB8E9F0
	public static void SyncSelfVoiceState(bool loudspeakerEnabled, bool microphoneEnabled) { }

	// RVA: 0xB8EAD8 Offset: 0xB8EAD8 VA: 0xB8EAD8
	public static void ReqOpenBox(long boxID, int count) { }

	// RVA: 0xB8EBF4 Offset: 0xB8EBF4 VA: 0xB8EBF4
	public static void SendCreateTeamReq(int combatType) { }

	// RVA: 0xB8ED6C Offset: 0xB8ED6C VA: 0xB8ED6C
	public static void SendShareReq(int shareType) { }

	// RVA: 0xB8EE48 Offset: 0xB8EE48 VA: 0xB8EE48
	public static void SendQueryRecruitInfo() { }

	// RVA: 0xB8EEF0 Offset: 0xB8EEF0 VA: 0xB8EEF0
	public static void SendAcceptRecruit(string code) { }

	// RVA: 0xB8EFBC Offset: 0xB8EFBC VA: 0xB8EFBC
	private static void .cctor() { }
}

} // namespace FGame
