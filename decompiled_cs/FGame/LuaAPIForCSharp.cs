namespace FGame
{

// Namespace: FGame
public static class LuaAPIForCSharp // TypeDefIndex: 9969
{
	// Fields
	private static ILuaFunctionWrap sLuaMessageDispatcher; // 0x0
	private static ILuaFunctionWrap sNewOpenLuaUi; // 0x4
	private static ILuaFunctionWrap sNewRemoveLuaUi; // 0x8
	private static ILuaFunctionWrap sIsLuaUiOpened; // 0xC
	private static ILuaFunctionWrap sCallLuaUiFunc; // 0x10
	private static ILuaFunctionWrap sApplyAddFriendFunc; // 0x14
	private static ILuaFunctionWrap sCheckIsFriendFunc; // 0x18
	private static ILuaFunctionWrap sGangplankBindFunc; // 0x1C
	private static ILuaFunctionWrap sGangplankSetPlayerInfoFunc; // 0x20
	private static ILuaFunctionWrap sIsShareRewardedFunc; // 0x24
	private static ILuaFunctionWrap sOpenShareBattleResultFunc; // 0x28
	private static ILuaFunctionWrap sOpenShareMvpFunc; // 0x2C
	private static ILuaFunctionWrap sOpenShareRankFunc; // 0x30
	private static ILuaFunctionWrap sCSharpUiMgrEscFunc; // 0x34
	private static ILuaFunctionWrap sGetLuaTableDataFunc; // 0x38
	private static ILuaFunctionWrap sGetLuaTableDataRecordFieldValueFunc; // 0x3C
	private static ILuaFunctionWrap sHandleFSMFunc; // 0x40
	private static ILuaFunctionWrap sGetLuaVendorNames; // 0x44
	private static ILuaFunctionWrap sGetLuaBindVendorNames; // 0x48
	private static ILuaTableWrap sJFLuaWrap; // 0x4C
	private static ILuaTableWrap sFBLuaWrap; // 0x50
	private static ILuaFunctionWrap sSendChatWrap; // 0x54

	// Methods

	// RVA: 0xF55DB8 Offset: 0xF55DB8 VA: 0xF55DB8
	public static void CallLuaUiFunc(string uiName, string funcName, object[] list) { }

	// RVA: 0xF55FCC Offset: 0xF55FCC VA: 0xF55FCC
	public static void CloseLuaUi(string uiName) { }

	// RVA: 0xF43DB0 Offset: 0xF43DB0 VA: 0xF43DB0
	public static void DispatchLuaMessage(string eventKey, object[] list) { }

	// RVA: 0xF56138 Offset: 0xF56138 VA: 0xF56138
	public static void Init() { }

	// RVA: 0xF56664 Offset: 0xF56664 VA: 0xF56664
	public static void SendChatMsg(string msg) { }

	// RVA: 0xF567D0 Offset: 0xF567D0 VA: 0xF567D0
	public static ILuaFunctionWrap JFLuaWrap(string funcName) { }

	// RVA: 0xF568FC Offset: 0xF568FC VA: 0xF568FC
	public static ILuaFunctionWrap FBLuaWrap(string funcName) { }

	// RVA: 0xF56A28 Offset: 0xF56A28 VA: 0xF56A28
	public static bool IsLuaUiOpened(string uiName) { }

	// RVA: 0xF56BE0 Offset: 0xF56BE0 VA: 0xF56BE0
	public static void Bind(string vendorName, Action<bool> callback) { }

	// RVA: 0xF51AC4 Offset: 0xF51AC4 VA: 0xF51AC4
	public static void SetPlayerInfo(uint playerId, string playerName, string serverId) { }

	// RVA: 0xF40E7C Offset: 0xF40E7C VA: 0xF40E7C
	public static void OpenLuaUi(string uiName, int layer = 0, object[] list) { }

	// RVA: 0xF56DA0 Offset: 0xF56DA0 VA: 0xF56DA0
	public static void ApplyAddFriend(long uid) { }

	// RVA: 0xF56F94 Offset: 0xF56F94 VA: 0xF56F94
	public static bool IsMyFriend(long accountId) { }

	// RVA: 0xF57168 Offset: 0xF57168 VA: 0xF57168
	public static bool IsShareEnabled() { }

	// RVA: 0xF57280 Offset: 0xF57280 VA: 0xF57280
	public static bool IsShareRewarded() { }

	// RVA: 0xF573D0 Offset: 0xF573D0 VA: 0xF573D0
	public static void OpenShareBattleResult(string battleEndTime, List<PlayerScoreData> ourScoreDatas, List<PlayerScoreData> otherScoreDatas, Action closeListener) { }

	// RVA: 0xF57638 Offset: 0xF57638 VA: 0xF57638
	public static void OpenShareMvp(Action closeListener) { }

	// RVA: 0xF577A4 Offset: 0xF577A4 VA: 0xF577A4
	public static void OpenShareRank(int rankScore, int rankStar, Action closeListener) { }

	// RVA: 0xF57A00 Offset: 0xF57A00 VA: 0xF57A00
	public static void UiMgrEsc(string uiName) { }

	// RVA: 0xF57B68 Offset: 0xF57B68 VA: 0xF57B68
	public static string[] GetLuaVendorNames() { }

	// RVA: 0xF4E894 Offset: 0xF4E894 VA: 0xF4E894
	public static string[] GetLuaBindVendorNames() { }

	// RVA: 0xF57DB8 Offset: 0xF57DB8 VA: 0xF57DB8
	public static LuaTable GetLuaTableData(string tableName) { }

	// RVA: -1 Offset: -1
	public static T GetLuaTableDataRecordFieldValue<T>(string tableName, long id, string fieldName, T defaultValue) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD9C40 Offset: 0xCD9C40 VA: 0xCD9C40
	|-LuaAPIForCSharp.GetLuaTableDataRecordFieldValue<long>
	|
	|-RVA: 0xCD9F74 Offset: 0xCD9F74 VA: 0xCD9F74
	|-LuaAPIForCSharp.GetLuaTableDataRecordFieldValue<object>
	|-LuaAPIForCSharp.GetLuaTableDataRecordFieldValue<string>
	|-LuaAPIForCSharp.GetLuaTableDataRecordFieldValue<LuaTable>
	*/

	// RVA: 0xF439EC Offset: 0xF439EC VA: 0xF439EC
	public static void HandFSM(EFsmType msgType) { }

	// RVA: -1 Offset: -1
	public static void HandFSM<T>(EFsmType msgType, string key, T v) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x10163A4 Offset: 0x10163A4 VA: 0x10163A4
	|-LuaAPIForCSharp.HandFSM<int>
	|
	|-RVA: 0x10167C4 Offset: 0x10167C4 VA: 0x10167C4
	|-LuaAPIForCSharp.HandFSM<object>
	*/

	// RVA: -1 Offset: -1
	public static void HandFSM<T, V>(EFsmType msgType, string key1, T v1, string key2, V v2) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1016598 Offset: 0x1016598 VA: 0x1016598
	|-LuaAPIForCSharp.HandFSM<object, object>
	*/

	// RVA: 0xF58008 Offset: 0xF58008 VA: 0xF58008
	private static bool CreateMsg(EFsmType msgType, out LuaTable msg) { }
}

} // namespace FGame
