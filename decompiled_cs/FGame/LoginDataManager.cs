namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553EF4 Offset: 0x553EF4 VA: 0x553EF4
public sealed class LoginDataManager : BaseSingleton<LoginDataManager> // TypeDefIndex: 9917
{
	// Fields
	public LoginDataManager.LoginState State; // 0x8
	public string Account; // 0xC
	public string GameToKen; // 0x10
	public bool IsGuest; // 0x14
	public string TempMsg; // 0x18
	public uint RoleId; // 0x1C
	private Dictionary<string, long> mClientConfig; // 0x20

	// Methods

	// RVA: 0xF4E660 Offset: 0xF4E660 VA: 0xF4E660
	public static bool IsBindVendorEnabled(string vendorName) { }

	// RVA: 0xF44DF0 Offset: 0xF44DF0 VA: 0xF44DF0
	public void Initialize() { }

	// RVA: 0xF42190 Offset: 0xF42190 VA: 0xF42190
	public void Shutdown() { }

	// RVA: 0xF4EAE4 Offset: 0xF4EAE4 VA: 0xF4EAE4
	private void OnLobbyConnected() { }

	// RVA: 0xF4ECFC Offset: 0xF4ECFC VA: 0xF4ECFC
	private void OnLobbyDisConnect() { }

	// RVA: 0xF4ED84 Offset: 0xF4ED84 VA: 0xF4ED84
	private void OnGenTokenResponse(SprotoTypeBase msg) { }

	// RVA: 0xF4EF78 Offset: 0xF4EF78 VA: 0xF4EF78
	private void OnLoginResponse(SprotoTypeBase msg) { }

	// RVA: 0xF4F43C Offset: 0xF4F43C VA: 0xF4F43C
	public void SendLoadRole() { }

	// RVA: 0xF50638 Offset: 0xF50638 VA: 0xF50638
	private void OnLoadRoleResponse(SprotoTypeBase msg) { }

	// RVA: 0xF51DCC Offset: 0xF51DCC VA: 0xF51DCC
	public void OnExpUpdate(SprotoTypeBase msg) { }

	// RVA: 0xF52090 Offset: 0xF52090 VA: 0xF52090
	private void OnUpdatePlayerStat(SprotoTypeBase msg) { }

	// RVA: 0xF52284 Offset: 0xF52284 VA: 0xF52284
	public void SendChangeIcon(uint iconId) { }

	// RVA: 0xF51D00 Offset: 0xF51D00 VA: 0xF51D00
	public void SendChangeIconUrl(string iconUrl) { }

	// RVA: 0xF523CC Offset: 0xF523CC VA: 0xF523CC
	public void QueryPlayerData(uint uid, Action callback) { }

	// RVA: 0xF5256C Offset: 0xF5256C VA: 0xF5256C
	private void OnNotifyUnlockMsg(SprotoTypeBase msg) { }

	// RVA: 0xF52A18 Offset: 0xF52A18 VA: 0xF52A18
	private void OnKick(SprotoTypeBase msg) { }

	// RVA: 0xF52CFC Offset: 0xF52CFC VA: 0xF52CFC
	private void OnUpdateMoney(SprotoTypeBase msg) { }

	// RVA: 0xF5338C Offset: 0xF5338C VA: 0xF5338C
	private void OnGetStoreItems(SprotoTypeBase msg) { }

	// RVA: 0xF536C0 Offset: 0xF536C0 VA: 0xF536C0
	private void OnGetStoreSales(SprotoTypeBase msg) { }

	// RVA: 0xF53A3C Offset: 0xF53A3C VA: 0xF53A3C
	private void OnNotifyStoreSales(SprotoTypeBase msg) { }

	// RVA: 0xF53DB8 Offset: 0xF53DB8 VA: 0xF53DB8
	private void OnBuyStoreItem(SprotoTypeBase msg) { }

	// RVA: 0xF54598 Offset: 0xF54598 VA: 0xF54598
	private void OnGetRechargeItems(SprotoTypeBase msg) { }

	// RVA: 0xF54858 Offset: 0xF54858 VA: 0xF54858
	private void OnUpdateBuyItemNotify(SprotoTypeBase msg) { }

	// RVA: 0xF54AD0 Offset: 0xF54AD0 VA: 0xF54AD0
	private void OnGetJFSwitch(SprotoTypeBase msg) { }

	// RVA: 0xF54D20 Offset: 0xF54D20 VA: 0xF54D20
	private void OnRechargeSuccess(SprotoTypeBase msg) { }

	// RVA: 0xF54E6C Offset: 0xF54E6C VA: 0xF54E6C
	private void OnGetNotififyItem(SprotoTypeBase msg) { }

	// RVA: 0xF550E8 Offset: 0xF550E8 VA: 0xF550E8
	private void OnShareReq(SprotoTypeBase msg) { }

	// RVA: 0xF550EC Offset: 0xF550EC VA: 0xF550EC
	private void OnQueryRecruitInfo(SprotoTypeBase msg) { }

	// RVA: 0xF5548C Offset: 0xF5548C VA: 0xF5548C
	private void OnAcceptRecruit(SprotoTypeBase msg) { }

	// RVA: 0xF5582C Offset: 0xF5582C VA: 0xF5582C
	private void OnNotifyNewRecruitee(SprotoTypeBase msg) { }

	// RVA: 0xF55B38 Offset: 0xF55B38 VA: 0xF55B38
	private void OnUnlockCharacter(SprotoTypeBase msg) { }

	// RVA: 0xF55C30 Offset: 0xF55C30 VA: 0xF55C30
	public long GetClientConfig(string key) { }

	// RVA: 0xF55CF4 Offset: 0xF55CF4 VA: 0xF55CF4
	public void .ctor() { }
}

} // namespace FGame
