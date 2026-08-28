// Namespace: 
[LuaCallCSharpAttribute] // RVA: 0x550534 Offset: 0x550534 VA: 0x550534
public class AliUIEventTrigger : EventTrigger // TypeDefIndex: 5511
{
	// Fields
	public AliUIEventTrigger.GameObjectEvent _onClick; // 0x14
	private AliUIEventTrigger.GameObjectEvent _onDown; // 0x18
	private AliUIEventTrigger.GameObjectEvent _onEnter; // 0x1C
	private AliUIEventTrigger.GameObjectEvent _onExit; // 0x20
	private AliUIEventTrigger.GameObjectEvent _onUp; // 0x24
	private AliUIEventTrigger.GameObjectEvent _onSelect; // 0x28
	private AliUIEventTrigger.GameObjectEvent _onUpdateSelect; // 0x2C
	private AliUIEventTrigger.PointerEvent _onBeginDrag; // 0x30
	private AliUIEventTrigger.PointerEvent _onDrag; // 0x34
	private AliUIEventTrigger.PointerEvent _onEndDrag; // 0x38
	private AliUIEventTrigger.PointerEvent _onLateDown; // 0x3C
	private AliUIEventTrigger.PointerEvent _onDestroy; // 0x40
	private float _lateDownTimeLimit; // 0x44
	private bool _isWaitingLateDown; // 0x48
	private const float LATE_DOWN_TIME_THRESHOLD = 0,4;

	// Properties
	public AliUIEventTrigger.GameObjectEvent onClick { get; }
	public AliUIEventTrigger.GameObjectEvent onDown { get; }
	public AliUIEventTrigger.GameObjectEvent onEnter { get; }
	public AliUIEventTrigger.GameObjectEvent onExit { get; }
	public AliUIEventTrigger.GameObjectEvent onUp { get; }
	public AliUIEventTrigger.GameObjectEvent onSelect { get; }
	public AliUIEventTrigger.GameObjectEvent onUpdateSelect { get; }
	public AliUIEventTrigger.PointerEvent BeginDrag { get; }
	public AliUIEventTrigger.PointerEvent Drag { get; }
	public AliUIEventTrigger.PointerEvent EndDrag { get; }
	public AliUIEventTrigger.PointerEvent onLateDown { get; }
	public AliUIEventTrigger.PointerEvent onDestroy { get; }

	// Methods

	// RVA: 0xCBA9F4 Offset: 0xCBA9F4 VA: 0xCBA9F4
	public AliUIEventTrigger.GameObjectEvent get_onClick() { }

	// RVA: 0xCBAAD4 Offset: 0xCBAAD4 VA: 0xCBAAD4
	public AliUIEventTrigger.GameObjectEvent get_onDown() { }

	// RVA: 0xCBAB50 Offset: 0xCBAB50 VA: 0xCBAB50
	public AliUIEventTrigger.GameObjectEvent get_onEnter() { }

	// RVA: 0xCBABCC Offset: 0xCBABCC VA: 0xCBABCC
	public AliUIEventTrigger.GameObjectEvent get_onExit() { }

	// RVA: 0xCBAC48 Offset: 0xCBAC48 VA: 0xCBAC48
	public AliUIEventTrigger.GameObjectEvent get_onUp() { }

	// RVA: 0xCBACC4 Offset: 0xCBACC4 VA: 0xCBACC4
	public AliUIEventTrigger.GameObjectEvent get_onSelect() { }

	// RVA: 0xCBAD40 Offset: 0xCBAD40 VA: 0xCBAD40
	public AliUIEventTrigger.GameObjectEvent get_onUpdateSelect() { }

	// RVA: 0xCB9B7C Offset: 0xCB9B7C VA: 0xCB9B7C
	public AliUIEventTrigger.PointerEvent get_BeginDrag() { }

	// RVA: 0xCBAE20 Offset: 0xCBAE20 VA: 0xCBAE20
	public AliUIEventTrigger.PointerEvent get_Drag() { }

	// RVA: 0xCB9C64 Offset: 0xCB9C64 VA: 0xCB9C64
	public AliUIEventTrigger.PointerEvent get_EndDrag() { }

	// RVA: 0xCBAE9C Offset: 0xCBAE9C VA: 0xCBAE9C
	public AliUIEventTrigger.PointerEvent get_onLateDown() { }

	// RVA: 0xCBAF18 Offset: 0xCBAF18 VA: 0xCBAF18
	public AliUIEventTrigger.PointerEvent get_onDestroy() { }

	// RVA: 0xCBAF94 Offset: 0xCBAF94 VA: 0xCBAF94
	private void OnDestroy() { }

	// RVA: 0xCBB064 Offset: 0xCBB064 VA: 0xCBB064
	private void Update() { }

	// RVA: 0xCB9A94 Offset: 0xCB9A94 VA: 0xCB9A94
	public static AliUIEventTrigger Get(GameObject go) { }

	// RVA: 0xCBB108 Offset: 0xCBB108 VA: 0xCBB108 Slot: 27
	public override void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0xCBB188 Offset: 0xCBB188 VA: 0xCBB188 Slot: 25
	public override void OnPointerDown(PointerEventData eventData) { }

	// RVA: 0xCBB22C Offset: 0xCBB22C VA: 0xCBB22C Slot: 21
	public override void OnPointerEnter(PointerEventData eventData) { }

	// RVA: 0xCBB2AC Offset: 0xCBB2AC VA: 0xCBB2AC Slot: 22
	public override void OnPointerExit(PointerEventData eventData) { }

	// RVA: 0xCBB334 Offset: 0xCBB334 VA: 0xCBB334 Slot: 26
	public override void OnPointerUp(PointerEventData eventData) { }

	// RVA: 0xCBB3BC Offset: 0xCBB3BC VA: 0xCBB3BC Slot: 28
	public override void OnSelect(BaseEventData eventData) { }

	// RVA: 0xCBB43C Offset: 0xCBB43C VA: 0xCBB43C Slot: 32
	public override void OnUpdateSelected(BaseEventData eventData) { }

	// RVA: 0xCBB4BC Offset: 0xCBB4BC VA: 0xCBB4BC Slot: 34
	public override void OnBeginDrag(PointerEventData eventData) { }

	// RVA: 0xCBB538 Offset: 0xCBB538 VA: 0xCBB538 Slot: 23
	public override void OnDrag(PointerEventData eventData) { }

	// RVA: 0xCBB5AC Offset: 0xCBB5AC VA: 0xCBB5AC Slot: 35
	public override void OnEndDrag(PointerEventData eventData) { }

	// RVA: 0xCBB620 Offset: 0xCBB620 VA: 0xCBB620
	public void OnClear() { }

	// RVA: 0xCBB724 Offset: 0xCBB724 VA: 0xCBB724
	public void .ctor() { }
}
