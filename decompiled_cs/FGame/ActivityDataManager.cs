namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553DA0 Offset: 0x553DA0 VA: 0x553DA0
public class ActivityDataManager : BaseSingleton<ActivityDataManager> // TypeDefIndex: 9854
{
	// Fields
	public static int SEVEN_DAY_ACTID_START; // 0x0
	public static int SEVEN_DAY_ACTID_END; // 0x4
	private ActivityDataManager.GroupIDSorter mSorter2; // 0x8
	private ActivityDataManager.GroupPopLevelSorter mSorterPopLevel; // 0xC
	public static ActivityDataManager.RecuriteTaskSorter mRecuriteTaskSorter; // 0x8
	public static ActivityDataManager.ExchangeTaskSorter mExchangeTaskSorter; // 0xC
	public static ActivityDataManager.ExchangeRuleSorter mExchangeRuleSorter; // 0x10
	private int mPopGroupID; // 0x10
	private bool mAutoPopEnabled; // 0x14
	private ActivityDataManager.ActivityGroup mFirstRechargeInfo; // 0x18
	private bool mDataFirstRefreshed; // 0x1C
	private bool mAutoPopStarted; // 0x1D
	private bool mPopDataGenerated; // 0x1E
	private List<ActivityDataManager.ActivityGroup> mPopList; // 0x20
	private int mFirstRechargeRedDot; // 0x24
	public Action OnDataRefreshed; // 0x28
	public ActivityDataManager.OnGetRewardFunc OnGetReward; // 0x2C
	public Action<bool> OnHasRechargeButton; // 0x30
	public Action<bool> OnHasRechargeRedPoint; // 0x34
	public Action<bool> OnHasCommonRedPoint; // 0x38
	public Action<int> OnExchangeInfoRefresh; // 0x3C
	public bool RedDotRecharge; // 0x40
	public bool ButtonRecharge; // 0x41
	public bool RedDot; // 0x42
	private Dictionary<int, ActivityDataManager.ActivityGroup> mDataDict; // 0x44
	public List<ActivityDataManager.ActivityGroup> Data; // 0x48

	// Properties
	public int PopGroupID { get; set; }
	public bool AutoPopEnabled { get; set; }
	public ActivityDataManager.ActivityGroup FirstRechargeInfo { get; set; }

	// Methods

	// RVA: 0xBDFFCC Offset: 0xBDFFCC VA: 0xBDFFCC
	public void Initialize() { }

	// RVA: 0xBE01B4 Offset: 0xBE01B4 VA: 0xBE01B4
	public void Shutdown() { }

	// RVA: 0xBE0394 Offset: 0xBE0394 VA: 0xBE0394
	public void set_PopGroupID(int value) { }

	// RVA: 0xBE039C Offset: 0xBE039C VA: 0xBE039C
	public int get_PopGroupID() { }

	// RVA: 0xBE03A4 Offset: 0xBE03A4 VA: 0xBE03A4
	public void set_AutoPopEnabled(bool value) { }

	// RVA: 0xBE03AC Offset: 0xBE03AC VA: 0xBE03AC
	public bool get_AutoPopEnabled() { }

	// RVA: 0xBE03B4 Offset: 0xBE03B4 VA: 0xBE03B4
	public void set_FirstRechargeInfo(ActivityDataManager.ActivityGroup value) { }

	// RVA: 0xBE03BC Offset: 0xBE03BC VA: 0xBE03BC
	public ActivityDataManager.ActivityGroup get_FirstRechargeInfo() { }

	// RVA: 0xBE03C4 Offset: 0xBE03C4 VA: 0xBE03C4
	public void SendQueryAll() { }

	// RVA: 0xBE046C Offset: 0xBE046C VA: 0xBE046C
	public void OnLogin() { }

	// RVA: 0xBE0478 Offset: 0xBE0478 VA: 0xBE0478
	public void SendFinish(int activityID, int taskID) { }

	// RVA: 0xBE0590 Offset: 0xBE0590 VA: 0xBE0590
	public ActivityDataManager.ActivityGroup GetGroup(int activityID) { }

	// RVA: 0xBE06A8 Offset: 0xBE06A8 VA: 0xBE06A8
	public ActivityDataManager.ActivityInfo GetActivity(int activityID, int taskID) { }

	// RVA: 0xBE08B8 Offset: 0xBE08B8 VA: 0xBE08B8
	private void OnQueryAllActivitiesResponse(SprotoTypeBase msg) { }

	// RVA: 0xBE0AEC Offset: 0xBE0AEC VA: 0xBE0AEC
	private void OnGetActivityRewardResponse(SprotoTypeBase msg) { }

	// RVA: 0xBE0DC4 Offset: 0xBE0DC4 VA: 0xBE0DC4
	private void OnRspActivityFinish(SprotoTypeBase msg) { }

	// RVA: 0xBE0958 Offset: 0xBE0958 VA: 0xBE0958
	private void RefreshActivityData(game.RspActivityInfo.request res) { }

	// RVA: 0xBE1208 Offset: 0xBE1208 VA: 0xBE1208
	private void AddActivityGroup(game.ActivityInfo info) { }

	// RVA: 0xBE29C0 Offset: 0xBE29C0 VA: 0xBE29C0
	private void RefreshActivityGroup(game.ActivityInfo info) { }

	// RVA: 0xBE28E4 Offset: 0xBE28E4 VA: 0xBE28E4
	private void AskExchangeInfo(int actID) { }

	// RVA: 0xBE2AAC Offset: 0xBE2AAC VA: 0xBE2AAC
	private void OnRspActivityExchangeInfo(SprotoTypeBase msg) { }

	// RVA: 0xBE334C Offset: 0xBE334C VA: 0xBE334C
	private void OnRspSyncChangedActivityInfo(SprotoTypeBase msg) { }

	// RVA: 0xBE340C Offset: 0xBE340C VA: 0xBE340C
	public void Exchange(int actID, int exchangeID) { }

	// RVA: 0xBE0C64 Offset: 0xBE0C64 VA: 0xBE0C64
	private void ProcessReward(int actID, int taskID, bool isSuccess) { }

	// RVA: 0xBE1FE4 Offset: 0xBE1FE4 VA: 0xBE1FE4
	private void ProcessGroupDataIntoList() { }

	// RVA: 0xBE0EB4 Offset: 0xBE0EB4 VA: 0xBE0EB4
	private void SetFinish(int activityID, int taskID) { }

	// RVA: 0xBE3A50 Offset: 0xBE3A50 VA: 0xBE3A50
	private void SetPopGroup() { }

	// RVA: 0xBE3154 Offset: 0xBE3154 VA: 0xBE3154
	public void RefreshRedDot() { }

	// RVA: 0xBE3E8C Offset: 0xBE3E8C VA: 0xBE3E8C
	public void TryPop() { }

	// RVA: 0xBE4064 Offset: 0xBE4064 VA: 0xBE4064
	public void OnPopedPanelClosed(string panelName) { }

	// RVA: 0xBE421C Offset: 0xBE421C VA: 0xBE421C
	public void ClearPopList() { }

	// RVA: 0xBE3980 Offset: 0xBE3980 VA: 0xBE3980
	public void SortRecuritTasks(ActivityDataManager.ActivityGroup group) { }

	// RVA: 0xBE4294 Offset: 0xBE4294 VA: 0xBE4294
	public static bool CanExchange(ActivityDataManager.ExchangeGroup group, ActivityDataManager.ExchangeRule rule) { }

	// RVA: 0xBE4548 Offset: 0xBE4548 VA: 0xBE4548
	private string IgnoreReddotKey(int actID, int exchangeID) { }

	// RVA: 0xBE28B8 Offset: 0xBE28B8 VA: 0xBE28B8
	public bool ExchangeReddotEnabled(int actID, int exchangeID) { }

	// RVA: 0xBE45F0 Offset: 0xBE45F0 VA: 0xBE45F0
	public void SetExchangeReddot(int actID, int exchangeID, bool enable) { }

	// RVA: 0xBE489C Offset: 0xBE489C VA: 0xBE489C
	public void .ctor() { }

	// RVA: 0xBE4A0C Offset: 0xBE4A0C VA: 0xBE4A0C
	private static void .cctor() { }
}

} // namespace FGame
