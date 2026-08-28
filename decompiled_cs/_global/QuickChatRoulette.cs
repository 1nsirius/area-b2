// Namespace: 
public class QuickChatRoulette : MonoBehaviour // TypeDefIndex: 5702
{
	// Fields
	private float mAngle; // 0xC
	private int mCurIndex; // 0x10
	[FormerlySerializedAsAttribute] // RVA: 0x55E6D4 Offset: 0x55E6D4 VA: 0x55E6D4
	[SerializeField] // RVA: 0x55E6D4 Offset: 0x55E6D4 VA: 0x55E6D4
	private List<LanguageMono> mQuickChatMsgs; // 0x14
	[FormerlySerializedAsAttribute] // RVA: 0x55E724 Offset: 0x55E724 VA: 0x55E724
	[SerializeField] // RVA: 0x55E724 Offset: 0x55E724 VA: 0x55E724
	private RectTransform mPointer; // 0x18
	[FormerlySerializedAsAttribute] // RVA: 0x55E76C Offset: 0x55E76C VA: 0x55E76C
	[SerializeField] // RVA: 0x55E76C Offset: 0x55E76C VA: 0x55E76C
	private Color mHighlightItemColor; // 0x1C
	[SerializeField] // RVA: 0x55E7C0 Offset: 0x55E7C0 VA: 0x55E7C0
	private Text mTextCancel; // 0x2C

	// Properties
	public float Angle { get; set; }
	private int CurIndex { get; set; }

	// Methods

	// RVA: 0x2CEFC98 Offset: 0x2CEFC98 VA: 0x2CEFC98
	public float get_Angle() { }

	// RVA: 0x2CEF428 Offset: 0x2CEF428 VA: 0x2CEF428
	public void set_Angle(float value) { }

	// RVA: 0x2CEFE08 Offset: 0x2CEFE08 VA: 0x2CEFE08
	private int get_CurIndex() { }

	// RVA: 0x2CEFCA0 Offset: 0x2CEFCA0 VA: 0x2CEFCA0
	private void set_CurIndex(int value) { }

	// RVA: 0x2CEFE10 Offset: 0x2CEFE10 VA: 0x2CEFE10
	private void Start() { }

	// RVA: 0x2CF0180 Offset: 0x2CF0180 VA: 0x2CF0180
	private void OnDestroy() { }

	// RVA: 0x2CEED4C Offset: 0x2CEED4C VA: 0x2CEED4C
	public uint GetCurMessageID() { }

	// RVA: 0x2CEE640 Offset: 0x2CEE640 VA: 0x2CEE640
	public void SetPointerActive(bool active) { }

	// RVA: 0x2CEE5D0 Offset: 0x2CEE5D0 VA: 0x2CEE5D0
	public bool IsOpen() { }

	// RVA: 0x2CEE604 Offset: 0x2CEE604 VA: 0x2CEE604
	public void SetActive(bool active) { }

	// RVA: 0x2CF0200 Offset: 0x2CF0200 VA: 0x2CF0200
	public void .ctor() { }
}
