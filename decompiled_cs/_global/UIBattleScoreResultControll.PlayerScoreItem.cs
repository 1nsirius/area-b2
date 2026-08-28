// Namespace: 
public class UIBattleScoreResultControll.PlayerScoreItem : IDisposable // TypeDefIndex: 10245
{
	// Fields
	public GameObject mItemGO; // 0x8
	public GameObject mWinnerMVPGO; // 0xC
	public GameObject mLoseMVPGO; // 0x10
	public GameObject contentGo; // 0x14
	public ImageWrapper career; // 0x18
	public RectTransform deadFlagRt; // 0x1C
	public RectTransform offlineFlagRt; // 0x20
	private Transform rankParent; // 0x24
	private BaseRankUI mRankUI; // 0x28
	public Image bg; // 0x2C
	public GameObject mBgGo; // 0x30
	public Text name; // 0x34
	public Text score; // 0x38
	public Text kill; // 0x3C
	public Text assist; // 0x40
	public Text dead; // 0x44
	public RectTransform microphoneRt; // 0x48
	public RectTransform loudSpeakerRt; // 0x4C
	private PlayerScoreData mCurData; // 0x50
	private GameObject mAddFriendGo; // 0x54
	private GameObject mReportGo; // 0x58
	private UIBattleScoreResultControll.ShowType mShowType; // 0x5C
	private bool mIsFriendModel; // 0x60

	// Methods

	// RVA: 0xC02040 Offset: 0xC02040 VA: 0xC02040
	public void .ctor(GameObject itemGo) { }

	// RVA: 0xC02A14 Offset: 0xC02A14 VA: 0xC02A14
	public void Destroy() { }

	// RVA: 0xBFE33C Offset: 0xBFE33C VA: 0xBFE33C
	public void ShowContent(bool show) { }

	// RVA: 0xC02A54 Offset: 0xC02A54 VA: 0xC02A54
	public void ShowSelf(bool show) { }

	// RVA: 0xC02CB0 Offset: 0xC02CB0 VA: 0xC02CB0
	public void Fill(PlayerScoreData data, UIBattleScoreResultControll.ShowType showType = 1, bool mvp = False) { }

	// RVA: 0xC0443C Offset: 0xC0443C VA: 0xC0443C
	public void Update() { }

	// RVA: 0xC043F0 Offset: 0xC043F0 VA: 0xC043F0
	private void SetRankScore(int rankScore) { }

	// RVA: 0xC04458 Offset: 0xC04458 VA: 0xC04458
	public void SetRankUIActive(bool active) { }

	// RVA: 0xC039AC Offset: 0xC039AC VA: 0xC039AC
	private void RefreshLoudSpeakerState() { }

	// RVA: 0xC03D78 Offset: 0xC03D78 VA: 0xC03D78
	private void RefreshMicrophoneState() { }

	// RVA: 0xC04494 Offset: 0xC04494 VA: 0xC04494
	public bool IsTrainMode() { }

	// RVA: 0xC0413C Offset: 0xC0413C VA: 0xC0413C
	private void RefreshdBtn() { }

	// RVA: 0xC04564 Offset: 0xC04564 VA: 0xC04564
	private void ReleaseUnmanagedResources() { }

	// RVA: 0xC046E0 Offset: 0xC046E0 VA: 0xC046E0
	private void OnSwitchBetweenFriendAndReport(bool isAddFriendModel) { }

	// RVA: 0xC046F4 Offset: 0xC046F4 VA: 0xC046F4 Slot: 4
	public void Dispose() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D6E0 Offset: 0x65D6E0 VA: 0x65D6E0
	// RVA: 0xC046F8 Offset: 0xC046F8 VA: 0xC046F8
	private void <.ctor>b__23_0(PointerEventData _) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D6F0 Offset: 0x65D6F0 VA: 0x65D6F0
	// RVA: 0xC049E0 Offset: 0xC049E0 VA: 0xC049E0
	private void <.ctor>b__23_1(PointerEventData _) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D700 Offset: 0x65D700 VA: 0x65D700
	// RVA: 0xC049E4 Offset: 0xC049E4 VA: 0xC049E4
	private void <.ctor>b__23_2(PointerEventData _) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D710 Offset: 0x65D710 VA: 0x65D710
	// RVA: 0xC04A2C Offset: 0xC04A2C VA: 0xC04A2C
	private void <.ctor>b__23_3(PointerEventData _) { }
}
