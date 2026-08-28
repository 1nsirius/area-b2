// Namespace: 
public class UIBattleScoreResultControll.ScoreSettlementPanel // TypeDefIndex: 10259
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56E624 Offset: 0x56E624 VA: 0x56E624
	private Action OnPlayComplete; // 0x8
	private UIBattleScoreResultControll.ScoreSettlementPanel.Step mCurrentStep; // 0xC
	private GameObject mRootGO; // 0x10
	private GameObject mLevelUpEffectGO; // 0x14
	private Text mLevelText; // 0x18
	private Text mCurExpContentText; // 0x1C
	private Text mAddExpText; // 0x20
	private Slider mAddProgressSlider; // 0x24
	private Transform mBeforeProgressImgTrans; // 0x28
	private RectTransform mHandleImgRT; // 0x2C
	private Text mGoldNumText; // 0x30
	private UIBattleScoreResultControll.RankNode mRankNode; // 0x34
	private GameObject mShareTipsGO; // 0x38
	private Text mShareTipsText; // 0x3C
	private Button mShareButton; // 0x40
	protected AssetPool mAssetPool; // 0x44
	[CompilerGeneratedAttribute] // RVA: 0x56E634 Offset: 0x56E634 VA: 0x56E634
	private bool <Active>k__BackingField; // 0x48
	private int mActiveCount; // 0x4C
	private Action OnCloseStoreUnLockSucPanelFunc; // 0x50
	private const float TIME_COUNT_1 = 1,5;
	private float mTimeCount; // 0x54
	private int mBeforeLevel; // 0x58
	private int mBeforeExp; // 0x5C
	private int mAfterLevel; // 0x60
	private int mAfterExp; // 0x64
	private int mAddExp; // 0x68
	private int mLastProgressLevel; // 0x6C
	private long mGoldNum; // 0x70

	// Properties
	public bool Active { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D760 Offset: 0x65D760 VA: 0x65D760
	// RVA: 0xC0A790 Offset: 0xC0A790 VA: 0xC0A790
	public void add_OnPlayComplete(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D770 Offset: 0x65D770 VA: 0x65D770
	// RVA: 0xC0A89C Offset: 0xC0A89C VA: 0xC0A89C
	public void remove_OnPlayComplete(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D780 Offset: 0x65D780 VA: 0x65D780
	// RVA: 0xC0A9A8 Offset: 0xC0A9A8 VA: 0xC0A9A8
	public bool get_Active() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D790 Offset: 0x65D790 VA: 0x65D790
	// RVA: 0xC0A9B0 Offset: 0xC0A9B0 VA: 0xC0A9B0
	private void set_Active(bool value) { }

	// RVA: 0xC0A9B8 Offset: 0xC0A9B8 VA: 0xC0A9B8
	public void Init(Transform root) { }

	// RVA: 0xC0AE10 Offset: 0xC0AE10 VA: 0xC0AE10
	public void OnTick() { }

	// RVA: 0xC0BD6C Offset: 0xC0BD6C VA: 0xC0BD6C
	public bool InitData() { }

	// RVA: 0xC0C194 Offset: 0xC0C194 VA: 0xC0C194
	public void SetActive(bool active) { }

	// RVA: 0xC0AEB8 Offset: 0xC0AEB8 VA: 0xC0AEB8
	private void RefreshShareTips() { }

	// RVA: 0xC0C010 Offset: 0xC0C010 VA: 0xC0C010
	private int GetGrossExp(int level, int overFlowExp) { }

	// RVA: 0xC0B868 Offset: 0xC0B868 VA: 0xC0B868
	private void CheckLevelUpReward() { }

	// RVA: 0xC0C674 Offset: 0xC0C674 VA: 0xC0C674
	private void OnCloseStoreUnLockSucPanel() { }

	// RVA: 0xC0C628 Offset: 0xC0C628 VA: 0xC0C628
	private void _TryCheckRankNodeAnim() { }

	// RVA: 0xC0C68C Offset: 0xC0C68C VA: 0xC0C68C
	private void OnRankNodeComplete() { }

	// RVA: 0xC0B140 Offset: 0xC0B140 VA: 0xC0B140
	private void SetProgress(float progress) { }

	// RVA: 0xC0C6BC Offset: 0xC0C6BC VA: 0xC0C6BC
	private void OnShareButtonClick() { }

	// RVA: 0xC0C12C Offset: 0xC0C12C VA: 0xC0C12C
	private void SetRankData(game.RankPlayerResult rankResult) { }

	// RVA: 0xC0C78C Offset: 0xC0C78C VA: 0xC0C78C
	public void Destroy() { }

	// RVA: 0xC0C87C Offset: 0xC0C87C VA: 0xC0C87C
	public void .ctor() { }
}
