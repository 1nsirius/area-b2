// Namespace: 
public class UIDragPanel : MaskableGraphic, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler // TypeDefIndex: 5807
{
	// Fields
	private bool _isFirstDrag; // 0x64
	public readonly UIDragPanel.DragTouchesCollection mTouches; // 0x68
	private bool _startListenFirstDrag; // 0x6C

	// Properties
	public Nullable<Vector2> FingerPoint { get; }
	public Vector2 Delta { get; }
	public bool isFirstDrag { get; set; }

	// Methods

	// RVA: 0xAEEF08 Offset: 0xAEEF08 VA: 0xAEEF08
	public Nullable<Vector2> get_FingerPoint() { }

	// RVA: 0xAEEED8 Offset: 0xAEEED8 VA: 0xAEEED8
	public Vector2 get_Delta() { }

	// RVA: 0xAEEFEC Offset: 0xAEEFEC VA: 0xAEEFEC
	public bool get_isFirstDrag() { }

	// RVA: 0xAF1C44 Offset: 0xAF1C44 VA: 0xAF1C44
	private void set_isFirstDrag(bool value) { }

	// RVA: 0xAF1C4C Offset: 0xAF1C4C VA: 0xAF1C4C Slot: 7
	protected override void OnDisable() { }

	// RVA: 0xAED9F4 Offset: 0xAED9F4 VA: 0xAED9F4
	public void UpdateDelta() { }

	// RVA: 0xAF1DFC Offset: 0xAF1DFC VA: 0xAF1DFC Slot: 65
	private void UnityEngine.EventSystems.IDragHandler.OnDrag(PointerEventData eventData) { }

	// RVA: 0xAF1F28 Offset: 0xAF1F28 VA: 0xAF1F28 Slot: 63
	private void UnityEngine.EventSystems.IBeginDragHandler.OnBeginDrag(PointerEventData eventData) { }

	// RVA: 0xAF21D0 Offset: 0xAF21D0 VA: 0xAF21D0 Slot: 64
	private void UnityEngine.EventSystems.IEndDragHandler.OnEndDrag(PointerEventData eventData) { }

	// RVA: 0xAF243C Offset: 0xAF243C VA: 0xAF243C Slot: 44
	protected override void OnPopulateMesh(VertexHelper vh) { }

	// RVA: 0xAF2468 Offset: 0xAF2468 VA: 0xAF2468
	public void .ctor() { }
}
