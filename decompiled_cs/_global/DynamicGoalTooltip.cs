// Namespace: 
public class DynamicGoalTooltip // TypeDefIndex: 5643
{
	// Fields
	private readonly GameObject mTooltipGo; // 0x8
	private readonly RectTransform mTran; // 0xC
	private readonly IDynamicGoalProxy mProxy; // 0x10
	private RectTransform mTextRoot; // 0x14
	private Image mFrameImg; // 0x18
	private RectTransform mArrowRt; // 0x1C
	private GameObject mArrowGo; // 0x20
	private Image mProgressRing; // 0x24
	private Text mGoalStateTxt; // 0x28
	private GameObject mGoalStateGO; // 0x2C
	private RectTransform mGoalStateRt; // 0x30
	private Text mFloorNameTxt; // 0x34
	private GameObject mFloorNameGO; // 0x38
	private RectTransform mFloorNameRt; // 0x3C
	private Text mGoalDist; // 0x40
	private GameObject mGoalDistGo; // 0x44
	private RectTransform mGoalDistRt; // 0x48
	private Image mGoalImgImg; // 0x4C
	private RectTransform mGoalImgRt; // 0x50
	private RectTransform mGoalNameRt; // 0x54
	private Text mGoalNameText; // 0x58
	private string mCurGoalName; // 0x5C
	private Text mMarkNameText; // 0x60
	private RectTransform mMarkNameRt; // 0x64
	private string mCurMarkName; // 0x68
	private Rect mClampRect; // 0x6C
	private float mCurDist; // 0x7C
	private Vector3 mLastScreenPos; // 0x80
	private string mCurGoalState; // 0x8C
	private string mCurFloorName; // 0x90

	// Methods

	// RVA: 0xD244D8 Offset: 0xD244D8 VA: 0xD244D8
	public void .ctor(IDynamicGoalProxy proxy, GameObject go) { }

	// RVA: 0xD24594 Offset: 0xD24594 VA: 0xD24594
	public bool Tick(BattleCamp camp) { }

	// RVA: 0xD25AB0 Offset: 0xD25AB0 VA: 0xD25AB0
	private void UpdateProgress() { }

	// RVA: 0xD25BB0 Offset: 0xD25BB0 VA: 0xD25BB0
	public void UpdateTextRoot() { }

	// RVA: 0xD25C28 Offset: 0xD25C28 VA: 0xD25C28
	public void Init(float dynamicGoalPointSize) { }

	// RVA: 0xD263B0 Offset: 0xD263B0 VA: 0xD263B0
	public void Destroy() { }
}
