// Namespace: 
public class StaticGoalToolTip // TypeDefIndex: 5665
{
	// Fields
	private readonly GameObject mTooltipGo; // 0x8
	private readonly RectTransform mTran; // 0xC
	private readonly IStaticGoalProxy mProxy; // 0x10
	private RectTransform mArrowRt; // 0x14
	private GameObject mArrowGo; // 0x18
	private Rect mClampRect; // 0x1C
	private Vector3 mLastScreenPos; // 0x2C
	private Image mProgressImg; // 0x38
	private Text mGoalStateTxt; // 0x3C
	private string mCurGoalState; // 0x40
	private GameObject mGoalDistGo; // 0x44
	private RectTransform mGoalDistRt; // 0x48
	private Image mGoalImgImg; // 0x4C
	private RectTransform mGoalImgRt; // 0x50
	private RectTransform mGoalNameRt; // 0x54
	private Text mGoalNameText; // 0x58
	private string mCurGoalName; // 0x5C
	private Image mFrameImg; // 0x60
	private Text mMarkNameTxt; // 0x64
	private string mCurMarkName; // 0x68

	// Methods

	// RVA: 0xD7EA68 Offset: 0xD7EA68 VA: 0xD7EA68
	public void .ctor(IStaticGoalProxy proxy, GameObject go) { }

	// RVA: 0xD7EB10 Offset: 0xD7EB10 VA: 0xD7EB10
	public void Tick() { }

	// RVA: 0xD7F56C Offset: 0xD7F56C VA: 0xD7F56C
	public void Init() { }

	// RVA: 0xD7FE38 Offset: 0xD7FE38 VA: 0xD7FE38
	public void Destroy() { }
}
