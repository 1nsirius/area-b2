// Namespace: 
public class UIEventListener : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IInitializePotentialDragHandler // TypeDefIndex: 5818
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x55ECF0 Offset: 0x55ECF0 VA: 0x55ECF0
	private UnityAction<PointerEventData> onPointerClick; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x55ED00 Offset: 0x55ED00 VA: 0x55ED00
	private UnityAction<PointerEventData> onPointerDown; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55ED10 Offset: 0x55ED10 VA: 0x55ED10
	private UnityAction<PointerEventData> onPointerUp; // 0x14
	[CompilerGeneratedAttribute] // RVA: 0x55ED20 Offset: 0x55ED20 VA: 0x55ED20
	private UnityAction<PointerEventData> onDragEve; // 0x18
	public GameObject defaultHandler; // 0x1C
	public bool defaultEnable; // 0x20
	private Nullable<int> m_pointerId; // 0x24

	// Properties
	public bool is_pointer_down { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57AECC Offset: 0x57AECC VA: 0x57AECC
	// RVA: 0xAF2D38 Offset: 0xAF2D38 VA: 0xAF2D38
	public void add_onPointerClick(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AEDC Offset: 0x57AEDC VA: 0x57AEDC
	// RVA: 0xAF2E44 Offset: 0xAF2E44 VA: 0xAF2E44
	public void remove_onPointerClick(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AEEC Offset: 0x57AEEC VA: 0x57AEEC
	// RVA: 0xAF2F50 Offset: 0xAF2F50 VA: 0xAF2F50
	public void add_onPointerDown(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AEFC Offset: 0x57AEFC VA: 0x57AEFC
	// RVA: 0xAF305C Offset: 0xAF305C VA: 0xAF305C
	public void remove_onPointerDown(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AF0C Offset: 0x57AF0C VA: 0x57AF0C
	// RVA: 0xAF3168 Offset: 0xAF3168 VA: 0xAF3168
	public void add_onPointerUp(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AF1C Offset: 0x57AF1C VA: 0x57AF1C
	// RVA: 0xAF3274 Offset: 0xAF3274 VA: 0xAF3274
	public void remove_onPointerUp(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AF2C Offset: 0x57AF2C VA: 0x57AF2C
	// RVA: 0xAF3380 Offset: 0xAF3380 VA: 0xAF3380
	public void add_onDragEve(UnityAction<PointerEventData> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AF3C Offset: 0x57AF3C VA: 0x57AF3C
	// RVA: 0xAF348C Offset: 0xAF348C VA: 0xAF348C
	public void remove_onDragEve(UnityAction<PointerEventData> value) { }

	// RVA: 0xAF3598 Offset: 0xAF3598 VA: 0xAF3598
	public bool get_is_pointer_down() { }

	// RVA: 0xAF35FC Offset: 0xAF35FC VA: 0xAF35FC
	public static UIEventListener Get(GameObject go, GameObject defaultHandler) { }

	// RVA: 0xAF37A0 Offset: 0xAF37A0 VA: 0xAF37A0
	public static UIEventListener Get(Transform parentTrans, string name, GameObject defaultHandler) { }

	// RVA: 0xAF39C4 Offset: 0xAF39C4 VA: 0xAF39C4 Slot: 11
	public virtual void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0xAF3A8C Offset: 0xAF3A8C VA: 0xAF3A8C Slot: 12
	public virtual void OnPointerDown(PointerEventData eventData) { }

	// RVA: 0xAF3BCC Offset: 0xAF3BCC VA: 0xAF3BCC Slot: 13
	public virtual void OnPointerUp(PointerEventData eventData) { }

	// RVA: 0xAF3D28 Offset: 0xAF3D28 VA: 0xAF3D28 Slot: 14
	public virtual void OnDrag(PointerEventData eventData) { }

	// RVA: 0xAF3DF0 Offset: 0xAF3DF0 VA: 0xAF3DF0 Slot: 8
	public void OnBeginDrag(PointerEventData eventData) { }

	// RVA: 0xAF3E94 Offset: 0xAF3E94 VA: 0xAF3E94 Slot: 9
	public void OnEndDrag(PointerEventData eventData) { }

	// RVA: 0xAF3F38 Offset: 0xAF3F38 VA: 0xAF3F38 Slot: 10
	private void UnityEngine.EventSystems.IInitializePotentialDragHandler.OnInitializePotentialDrag(PointerEventData eventData) { }

	// RVA: 0xAF3FFC Offset: 0xAF3FFC VA: 0xAF3FFC
	private void OnDisable() { }

	// RVA: -1 Offset: -1
	private void ThrowEvent2Default<T>(PointerEventData eventData, ExecuteEvents.EventFunction<T> handle) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x10BC0D4 Offset: 0x10BC0D4 VA: 0x10BC0D4
	|-UIEventListener.ThrowEvent2Default<object>
	|-UIEventListener.ThrowEvent2Default<IBeginDragHandler>
	|-UIEventListener.ThrowEvent2Default<IDragHandler>
	|-UIEventListener.ThrowEvent2Default<IEndDragHandler>
	|-UIEventListener.ThrowEvent2Default<IInitializePotentialDragHandler>
	|-UIEventListener.ThrowEvent2Default<IPointerClickHandler>
	|-UIEventListener.ThrowEvent2Default<IPointerDownHandler>
	|-UIEventListener.ThrowEvent2Default<IPointerUpHandler>
	*/

	// RVA: 0xAF400C Offset: 0xAF400C VA: 0xAF400C
	public void .ctor() { }
}
