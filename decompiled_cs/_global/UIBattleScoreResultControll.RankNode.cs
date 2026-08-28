// Namespace: 
public class UIBattleScoreResultControll.RankNode // TypeDefIndex: 10247
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56E604 Offset: 0x56E604 VA: 0x56E604
	private Action OnPlayComplete; // 0x8
	private GameObject mRootGO; // 0xC
	private GameObject mRankDisplayNodeGO; // 0x10
	private Animator mRankDisplayNodeAnimator; // 0x14
	private Transform mRankUIRoot; // 0x18
	private Text mRankNameText; // 0x1C
	private GameObject mProtectNodeGO; // 0x20
	private Text mRankChangeDescText; // 0x24
	private GameObject mRankProtectTextGO; // 0x28
	private Text mRankProtectText; // 0x2C
	private Text mProgressText; // 0x30
	private Text mProgressDescText; // 0x34
	private Slider mAddProgressSlider; // 0x38
	private Animator mProgressAnimator; // 0x3C
	private Transform mBeforeProgressImgTrans; // 0x40
	private GameObject mNoRankDisplayNodeGO; // 0x44
	private List<GameObject> mWinGOList; // 0x48
	private List<GameObject> mLoseGOList; // 0x4C
	private BaseRankUI mRankUI; // 0x50
	private Image mRankUIFxImage1; // 0x54
	private Image mRankUIFxImage2; // 0x58
	private UIBattleScoreResultControll.RankNode.RankProgressController mRankProgressController; // 0x5C
	private UIBattleScoreResultControll.RankNode.ProtectScoreProgressController mProtectScoreProgressController; // 0x60
	private AssetPool mAssetPool; // 0x64
	[CompilerGeneratedAttribute] // RVA: 0x56E614 Offset: 0x56E614 VA: 0x56E614
	private bool <Active>k__BackingField; // 0x68
	private bool mIsWin; // 0x69
	private int mOldRankScore; // 0x6C
	private int mOldRankID; // 0x70
	private int mOldStarCount; // 0x74
	public int mNewRankScore; // 0x78
	private int mNewRankID; // 0x7C
	public int mNewStarCount; // 0x80
	private int mOldProtectScore; // 0x84
	private int mNewProtectScore; // 0x88
	private long mCurrentBattleCount; // 0x90
	private long mBattleRecord; // 0x98

	// Properties
	public bool Active { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D720 Offset: 0x65D720 VA: 0x65D720
	// RVA: 0xC04C98 Offset: 0xC04C98 VA: 0xC04C98
	public void add_OnPlayComplete(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D730 Offset: 0x65D730 VA: 0x65D730
	// RVA: 0xC04DA4 Offset: 0xC04DA4 VA: 0xC04DA4
	public void remove_OnPlayComplete(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65D740 Offset: 0x65D740 VA: 0x65D740
	// RVA: 0xC04EB0 Offset: 0xC04EB0 VA: 0xC04EB0
	public bool get_Active() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D750 Offset: 0x65D750 VA: 0x65D750
	// RVA: 0xC04EB8 Offset: 0xC04EB8 VA: 0xC04EB8
	private void set_Active(bool value) { }

	// RVA: 0xC04EC0 Offset: 0xC04EC0 VA: 0xC04EC0
	public void Init(Transform root) { }

	// RVA: 0xC0556C Offset: 0xC0556C VA: 0xC0556C
	public void SetData(game.RankPlayerResult rankPlayerResult) { }

	// RVA: 0xC057FC Offset: 0xC057FC VA: 0xC057FC
	public void OnTick() { }

	// RVA: 0xC05864 Offset: 0xC05864 VA: 0xC05864
	public void SetActive(bool active) { }

	// RVA: 0xC058B0 Offset: 0xC058B0 VA: 0xC058B0
	public void Refresh(bool firstEnter) { }

	// RVA: 0xC07258 Offset: 0xC07258 VA: 0xC07258
	public void StartAnim() { }

	// RVA: 0xC072BC Offset: 0xC072BC VA: 0xC072BC
	public int GetStarRealDeltaAbs() { }

	// RVA: 0xC0747C Offset: 0xC0747C VA: 0xC0747C
	private void OnProgressControllerComplete() { }

	// RVA: 0xC06920 Offset: 0xC06920 VA: 0xC06920
	public void RefreshOldRankUI() { }

	// RVA: 0xC05B88 Offset: 0xC05B88 VA: 0xC05B88
	public void RefreshNewRankUI(bool playNormalAnim = True) { }

	// RVA: 0xC06D14 Offset: 0xC06D14 VA: 0xC06D14
	private void RefreshOldProtectScoreUI() { }

	// RVA: 0xC061F8 Offset: 0xC061F8 VA: 0xC061F8
	private void RefreshNewProtectScoreUI() { }

	// RVA: 0xC0673C Offset: 0xC0673C VA: 0xC0673C
	private int GetRankType() { }

	// RVA: 0xC06BDC Offset: 0xC06BDC VA: 0xC06BDC
	private int GetProtectScoreType() { }

	// RVA: 0xC074D8 Offset: 0xC074D8 VA: 0xC074D8
	public void RefreshOldBattleRecord() { }

	// RVA: 0xC07754 Offset: 0xC07754 VA: 0xC07754
	public void RefreshBattleRecord() { }

	// RVA: 0xC07988 Offset: 0xC07988 VA: 0xC07988
	public void Destroy() { }

	// RVA: 0xC07AD8 Offset: 0xC07AD8 VA: 0xC07AD8
	public void .ctor() { }
}
