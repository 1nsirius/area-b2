namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553E40 Offset: 0x553E40 VA: 0x553E40
public sealed class DailyTaskDataManager : BaseSingleton<DailyTaskDataManager> // TypeDefIndex: 9897
{
	// Fields
	private IComparer<DailyTaskDataManager.DailyTaskInfo> mSorter1; // 0x8
	private IComparer<DailyTaskDataManager.BoxInfo> mSorter2; // 0xC
	private IComparer<DailyTaskDataManager.GrowthTaskInfo> mSorter3; // 0x10
	public bool DataEnabled; // 0x14
	public List<DailyTaskDataManager.DailyTaskInfo> SlotData; // 0x18
	public List<DailyTaskDataManager.BoxInfo> BoxData; // 0x1C
	public int CurrentActivation; // 0x20
	public int MaxiumActivation; // 0x24
	private List<int> mActivationInterval; // 0x28
	public int RefreshCount; // 0x2C
	public long RefreshTimeStamp; // 0x30
	public int LastGrowthLevel; // 0x38
	private Dictionary<int, DailyTaskDataManager.GrowthTaskInfo> mGData; // 0x3C
	public List<DailyTaskDataManager.GrowthTaskInfo> GrowthData; // 0x40
	public Action<int> OnRefreshTask; // 0x44
	public Action OnDataEnabled; // 0x48
	public Action<bool> OnHasRedDot; // 0x4C
	public Action<int> OnGetTaskReward; // 0x50
	public int EntryMode; // 0x54
	public bool HasRedDot; // 0x58
	private bool mUpdated; // 0x59

	// Methods

	// RVA: 0xBFAC7C Offset: 0xBFAC7C VA: 0xBFAC7C
	public void Initialize() { }

	// RVA: 0xBFAE2C Offset: 0xBFAE2C VA: 0xBFAE2C
	public void Shutdown() { }

	// RVA: 0xBFAFD0 Offset: 0xBFAFD0 VA: 0xBFAFD0
	public void SendGetReward(int dailyID) { }

	// RVA: 0xBFB0AC Offset: 0xBFB0AC VA: 0xBFB0AC
	public void ResetDailyTask(int slotID, long ts) { }

	// RVA: 0xBFB1C8 Offset: 0xBFB1C8 VA: 0xBFB1C8
	public void SetLastGrowthLevel(int level) { }

	// RVA: 0xBFB2F0 Offset: 0xBFB2F0 VA: 0xBFB2F0
	public void OnLogin() { }

	// RVA: 0xBFB304 Offset: 0xBFB304 VA: 0xBFB304
	public void AskAll() { }

	// RVA: 0xBFB3BC Offset: 0xBFB3BC VA: 0xBFB3BC
	private void OnAskAllTaskInfo(SprotoTypeBase msg) { }

	// RVA: 0xBFC3BC Offset: 0xBFC3BC VA: 0xBFC3BC
	private void OnSyncChangedTaskInfo(SprotoTypeBase msg) { }

	// RVA: 0xBFCD78 Offset: 0xBFCD78 VA: 0xBFCD78
	private void OnGetTaskRewardResponse(SprotoTypeBase msg) { }

	// RVA: 0xBFD280 Offset: 0xBFD280 VA: 0xBFD280
	private void OnRspRefreshTask(SprotoTypeBase msg) { }

	// RVA: 0xBFBC44 Offset: 0xBFBC44 VA: 0xBFBC44
	private void AutoInsertGrowthTasks() { }

	// RVA: 0xBFC100 Offset: 0xBFC100 VA: 0xBFC100
	private void ProcessTasks() { }

	// RVA: 0xBFCAE8 Offset: 0xBFCAE8 VA: 0xBFCAE8
	private void CalcActivation() { }

	// RVA: 0xBFD404 Offset: 0xBFD404 VA: 0xBFD404
	public int GetMiniumExchangeableGrowthTaskLevel() { }

	// RVA: 0xBFD5EC Offset: 0xBFD5EC VA: 0xBFD5EC
	public bool HasDailyRP() { }

	// RVA: 0xBFD760 Offset: 0xBFD760 VA: 0xBFD760
	public bool HasGrowthRP() { }

	// RVA: 0xBFC32C Offset: 0xBFC32C VA: 0xBFC32C
	private void CheckRP() { }

	// RVA: 0xBFD8DC Offset: 0xBFD8DC VA: 0xBFD8DC
	public float GetActivationFillAmount() { }

	// RVA: 0xBFDC2C Offset: 0xBFDC2C VA: 0xBFDC2C
	public void SetBoxPos(Transform trans, float ratio) { }

	// RVA: 0xBFDD0C Offset: 0xBFDD0C VA: 0xBFDD0C
	public void PlayAnim(Transform trans, string anim) { }

	// RVA: 0xBFDE04 Offset: 0xBFDE04 VA: 0xBFDE04
	public void .ctor() { }
}

} // namespace FGame
