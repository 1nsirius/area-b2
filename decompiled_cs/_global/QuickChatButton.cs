// Namespace: 
[RequireComponent] // RVA: 0x550CA0 Offset: 0x550CA0 VA: 0x550CA0
[RequireComponent] // RVA: 0x550CA0 Offset: 0x550CA0 VA: 0x550CA0
public class QuickChatButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler // TypeDefIndex: 5698
{
	// Fields
	public RectTransform Icon; // 0xC
	public float DragRadiusLimit; // 0x10
	private Vector2 mPressDelta; // 0x14
	public float RouletteActiveTime; // 0x1C
	public Vector3 ActiveScale; // 0x20
	private float mPressTime; // 0x2C
	private bool mIsPress; // 0x30
	private Vector3 mOriginScale; // 0x34
	private RectTransform mRectTransform; // 0x40
	[FormerlySerializedAsAttribute] // RVA: 0x55E58C Offset: 0x55E58C VA: 0x55E58C
	[SerializeField] // RVA: 0x55E58C Offset: 0x55E58C VA: 0x55E58C
	private QuickChatRoulette mQuickChatRoulette; // 0x44
	[FormerlySerializedAsAttribute] // RVA: 0x55E5E0 Offset: 0x55E5E0 VA: 0x55E5E0
	[SerializeField] // RVA: 0x55E5E0 Offset: 0x55E5E0 VA: 0x55E5E0
	private Image mCDRing; // 0x48
	[FormerlySerializedAsAttribute] // RVA: 0x55E630 Offset: 0x55E630 VA: 0x55E630
	[SerializeField] // RVA: 0x55E630 Offset: 0x55E630 VA: 0x55E630
	private Image Highlight; // 0x4C
	[SerializeField] // RVA: 0x55E67C Offset: 0x55E67C VA: 0x55E67C
	private GameObject mSelectinList; // 0x50
	private CanvasGroup mCanvasGroup; // 0x54

	// Properties
	public Vector2 OriginPoint { get; }

	// Methods

	// RVA: 0x2CEDD28 Offset: 0x2CEDD28 VA: 0x2CEDD28
	public Vector2 get_OriginPoint() { }

	// RVA: 0x2CEDE50 Offset: 0x2CEDE50 VA: 0x2CEDE50
	private void Awake() { }

	// RVA: 0x2CEDED4 Offset: 0x2CEDED4 VA: 0x2CEDED4
	private void Start() { }

	// RVA: 0x2CEE154 Offset: 0x2CEE154 VA: 0x2CEE154
	private void Update() { }

	// RVA: 0x2CEE838 Offset: 0x2CEE838 VA: 0x2CEE838 Slot: 4
	public void OnPointerDown(PointerEventData eventData) { }

	// RVA: 0x2CEE894 Offset: 0x2CEE894 VA: 0x2CEE894 Slot: 5
	public void OnPointerUp(PointerEventData eventData) { }

	// RVA: 0x2CEEDEC Offset: 0x2CEEDEC VA: 0x2CEEDEC Slot: 6
	public void OnDrag(PointerEventData eventData) { }

	// RVA: 0x2CEF604 Offset: 0x2CEF604 VA: 0x2CEF604
	public void .ctor() { }
}
