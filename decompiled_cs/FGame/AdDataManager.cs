namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553DB4 Offset: 0x553DB4 VA: 0x553DB4
public sealed class AdDataManager : BaseSingleton<AdDataManager> // TypeDefIndex: 9874
{
	// Fields
	private List<AdDataManager.AdInfo> mAds; // 0x8
	public Action OnUpdateAdInfo; // 0xC
	public Action OnGetReward; // 0x10
	public string mAdID; // 0x14
	private float mCD; // 0x18
	private long mPreloadStatus; // 0x20
	private bool mTimeEnable; // 0x28
	private bool mPreloadEnable; // 0x29
	private bool mAllEnable; // 0x2A
	private int mRemainTimes; // 0x2C
	private bool mIsOnWhiteList; // 0x30
	private ILuaFunctionWrap mQueryList; // 0x34
	private ILuaFunctionWrap mLoadAd; // 0x38
	private ILuaFunctionWrap mGetAdPreloadStatus; // 0x3C
	private const float PRELOAD_CHECK_CD = 300;
	private float mCurPreloadCheckCD; // 0x40
	private bool mEnableAdQuery; // 0x44
	private int mCurrentFailedTime; // 0x48
	private const int QUERY_FAILED_LIMIT = 3;
	private bool mForceStopQuery; // 0x4C

	// Properties
	public string AdID { get; }
	public float CD { get; }
	public long PreloadStatus { get; }
	public bool TimeEnable { get; }
	public bool PreloadEnable { get; }
	public bool AllEnable { get; }
	public int RemainTimes { get; }

	// Methods

	// RVA: 0xBE6864 Offset: 0xBE6864 VA: 0xBE6864
	public string get_AdID() { }

	// RVA: 0xBE686C Offset: 0xBE686C VA: 0xBE686C
	public float get_CD() { }

	// RVA: 0xBE6874 Offset: 0xBE6874 VA: 0xBE6874
	public long get_PreloadStatus() { }

	// RVA: 0xBE687C Offset: 0xBE687C VA: 0xBE687C
	public bool get_TimeEnable() { }

	// RVA: 0xBE6884 Offset: 0xBE6884 VA: 0xBE6884
	public bool get_PreloadEnable() { }

	// RVA: 0xBE688C Offset: 0xBE688C VA: 0xBE688C
	public bool get_AllEnable() { }

	// RVA: 0xBE6894 Offset: 0xBE6894 VA: 0xBE6894
	public int get_RemainTimes() { }

	// RVA: 0xBE689C Offset: 0xBE689C VA: 0xBE689C
	public void CheckFuncBinding() { }

	// RVA: 0xBE6A98 Offset: 0xBE6A98 VA: 0xBE6A98
	public void Initialize() { }

	// RVA: 0xBE6BD0 Offset: 0xBE6BD0 VA: 0xBE6BD0
	public void Shutdown() { }

	// RVA: 0xBE6CB8 Offset: 0xBE6CB8 VA: 0xBE6CB8
	public void OnLogin() { }

	// RVA: 0xBE6D6C Offset: 0xBE6D6C VA: 0xBE6D6C
	public void AskAdInfo() { }

	// RVA: 0xBE6E64 Offset: 0xBE6E64 VA: 0xBE6E64
	public void GetAdReward() { }

	// RVA: 0xBE6F0C Offset: 0xBE6F0C VA: 0xBE6F0C
	public bool IsTimeEnable() { }

	// RVA: 0xBE6F24 Offset: 0xBE6F24 VA: 0xBE6F24
	public bool IsPreloadEnable() { }

	// RVA: 0xBE6F40 Offset: 0xBE6F40 VA: 0xBE6F40
	public void OnUpdate() { }

	// RVA: 0xBE6CC4 Offset: 0xBE6CC4 VA: 0xBE6CC4
	private void CheckWhiteList() { }

	// RVA: 0xBE6FA4 Offset: 0xBE6FA4 VA: 0xBE6FA4
	private void OnQueryAdInfo(SprotoTypeBase msg) { }

	// RVA: 0xBE6F60 Offset: 0xBE6F60 VA: 0xBE6F60
	private void CheckAvalivableAdTimeAndPreloadStatus() { }

	// RVA: 0xBE70A0 Offset: 0xBE70A0 VA: 0xBE70A0
	private void CheckTime() { }

	// RVA: 0xBE7100 Offset: 0xBE7100 VA: 0xBE7100
	private void CheckPreload() { }

	// RVA: 0xBE7404 Offset: 0xBE7404 VA: 0xBE7404
	private void CheckEnable() { }

	// RVA: 0xBE7188 Offset: 0xBE7188 VA: 0xBE7188
	private void RefreshPreloadStatus() { }

	// RVA: 0xBE7494 Offset: 0xBE7494 VA: 0xBE7494
	public void OnFinishWatch() { }

	// RVA: 0xBE7548 Offset: 0xBE7548 VA: 0xBE7548
	public void LuaCallClearAds() { }

	// RVA: 0xBE75C0 Offset: 0xBE75C0 VA: 0xBE75C0
	public void LuaCallAddAds(string id, int countleft, float cdleft, int status) { }

	// RVA: 0xBE76D8 Offset: 0xBE76D8 VA: 0xBE76D8
	public void LuaCallQueryFinish() { }

	// RVA: 0xBE7954 Offset: 0xBE7954 VA: 0xBE7954
	public void SetAdQueryEnable(bool setActive) { }

	// RVA: 0xBE7904 Offset: 0xBE7904 VA: 0xBE7904
	private void CheckFailedTime() { }

	// RVA: 0xBE795C Offset: 0xBE795C VA: 0xBE795C
	public void .ctor() { }
}

} // namespace FGame
