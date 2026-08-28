// Namespace: 
public class TestDrag : MaskableGraphic, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler, IPointerClickHandler // TypeDefIndex: 5687
{
	// Fields
	public bool touched; // 0x64
	public Vector2 Delta; // 0x68
	private Vector2 lastPos; // 0x70
	private Vector2 latePos; // 0x78
	public Button backBtn; // 0x80
	[CompilerGeneratedAttribute] // RVA: 0x55E50C Offset: 0x55E50C VA: 0x55E50C
	private Action<PointerEventData> ClickEvent; // 0x84
	[CompilerGeneratedAttribute] // RVA: 0x55E51C Offset: 0x55E51C VA: 0x55E51C
	private Action BackBtnClickEvent; // 0x88
	private Nullable<int> m_pointerId; // 0x8C

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57AA8C Offset: 0x57AA8C VA: 0x57AA8C
	// RVA: 0xD83014 Offset: 0xD83014 VA: 0xD83014
	public void add_ClickEvent(Action<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AA9C Offset: 0x57AA9C VA: 0x57AA9C
	// RVA: 0xD83120 Offset: 0xD83120 VA: 0xD83120
	public void remove_ClickEvent(Action<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AAAC Offset: 0x57AAAC VA: 0x57AAAC
	// RVA: 0xD8322C Offset: 0xD8322C VA: 0xD8322C
	public void add_BackBtnClickEvent(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AABC Offset: 0x57AABC VA: 0x57AABC
	// RVA: 0xD83338 Offset: 0xD83338 VA: 0xD83338
	public void remove_BackBtnClickEvent(Action value) { }

	// RVA: 0xD83444 Offset: 0xD83444 VA: 0xD83444 Slot: 4
	protected override void Awake() { }

	// RVA: 0xD8350C Offset: 0xD8350C VA: 0xD8350C Slot: 6
	protected override void Start() { }

	// RVA: 0xD835C4 Offset: 0xD835C4 VA: 0xD835C4
	private void Update() { }

	// RVA: 0xD835C8 Offset: 0xD835C8 VA: 0xD835C8 Slot: 44
	protected override void OnPopulateMesh(VertexHelper vh) { }

	// RVA: 0xD835F4 Offset: 0xD835F4 VA: 0xD835F4 Slot: 65
	public void OnDrag(PointerEventData eventData) { }

	// RVA: 0xD83804 Offset: 0xD83804 VA: 0xD83804
	private void LateUpdate() { }

	// RVA: 0xD8392C Offset: 0xD8392C VA: 0xD8392C Slot: 64
	private void UnityEngine.EventSystems.IPointerUpHandler.OnPointerUp(PointerEventData eventData) { }

	// RVA: 0xD83940 Offset: 0xD83940 VA: 0xD83940 Slot: 63
	private void UnityEngine.EventSystems.IPointerDownHandler.OnPointerDown(PointerEventData eventData) { }

	// RVA: 0xD83510 Offset: 0xD83510 VA: 0xD83510
	private void ResetPos() { }

	// RVA: 0xD839F8 Offset: 0xD839F8 VA: 0xD839F8 Slot: 66
	public void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0xD83A94 Offset: 0xD83A94 VA: 0xD83A94
	private void BackBtnCallback() { }

	// RVA: 0xD83AA8 Offset: 0xD83AA8 VA: 0xD83AA8
	public void .ctor() { }
}
