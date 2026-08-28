// Namespace: 
public class UIBattleScoreResultControll.BoxResultPanel // TypeDefIndex: 10238
{
	// Fields
	private UIBattleScoreResultControll.BoxResultPanel.Step mCurrentStep; // 0x8
	private GameObject mRootGO; // 0xC
	private GameObject mNode1GO; // 0x10
	private Animator mNode1Animator; // 0x14
	private GameObject mNode2GO; // 0x18
	private Animator mNode2Animator; // 0x1C
	private Text mPercentageText; // 0x20
	private RectTransform mOldPercentageRT; // 0x24
	private RectTransform mNewPercentageRT; // 0x28
	private Text mPercentageChangeText; // 0x2C
	private Slider mSlider; // 0x30
	private GameObject mPercentageChangeDescGO; // 0x34
	private Text mBoxNameText; // 0x38
	private AnimationCurve mAnimationCurve; // 0x3C
	[CompilerGeneratedAttribute] // RVA: 0x56E4F4 Offset: 0x56E4F4 VA: 0x56E4F4
	private bool <Active>k__BackingField; // 0x40
	private int mActiveCount; // 0x44
	private long mBoxID; // 0x48
	private long mOldRate; // 0x50
	private long mNewRate; // 0x58
	private long mAddRate; // 0x60
	private bool mIsWin; // 0x68
	private const float STEP1_TIME = 1;
	private const float STEP2_TIME = 4;
	private const float STEP3_TIME = 0,5;
	private const float STEP4_TIME = 1;
	private float mTimeCount; // 0x6C
	private float mWidth; // 0x70
	private float mStartValue; // 0x74
	private float mEndValue; // 0x78
	private List<float> mKeyFrameTimes; // 0x7C
	private float mCurrentRate; // 0x80
	private float mRateSpeed; // 0x84
	private float mCurrentScaleX; // 0x88
	private float mOldScaleX; // 0x8C
	private float mNewScaleX; // 0x90
	private float mScaleXSpeed; // 0x94

	// Properties
	public bool Active { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65D4C0 Offset: 0x65D4C0 VA: 0x65D4C0
	// RVA: 0xBFE388 Offset: 0xBFE388 VA: 0xBFE388
	public bool get_Active() { }

	[CompilerGeneratedAttribute] // RVA: 0x65D4D0 Offset: 0x65D4D0 VA: 0x65D4D0
	// RVA: 0xBFE390 Offset: 0xBFE390 VA: 0xBFE390
	private void set_Active(bool value) { }

	// RVA: 0xBFE398 Offset: 0xBFE398 VA: 0xBFE398
	public void Init(Transform root) { }

	// RVA: 0xBFE69C Offset: 0xBFE69C VA: 0xBFE69C
	public void SetData(game.BoxResult boxResult, bool isWin) { }

	// RVA: 0xBFF040 Offset: 0xBFF040 VA: 0xBFF040
	public void OnTick() { }

	// RVA: 0xBFFAD8 Offset: 0xBFFAD8 VA: 0xBFFAD8
	public void SetActive(bool active) { }

	// RVA: 0xBFFB6C Offset: 0xBFFB6C VA: 0xBFFB6C
	public void Refresh(bool firstEnter) { }

	// RVA: 0xC00CC8 Offset: 0xC00CC8 VA: 0xC00CC8
	public void Destroy() { }

	// RVA: 0xBFE828 Offset: 0xBFE828 VA: 0xBFE828
	private void GenerateParameter() { }

	// RVA: 0xC00BDC Offset: 0xC00BDC VA: 0xC00BDC
	private float GetSliderPingpongValue(float realValue) { }

	// RVA: 0xC00CE8 Offset: 0xC00CE8 VA: 0xC00CE8
	private bool IsOdd(int n) { }

	// RVA: 0xC00D00 Offset: 0xC00D00 VA: 0xC00D00
	public void .ctor() { }
}
