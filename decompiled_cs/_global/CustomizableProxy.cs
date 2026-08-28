// Namespace: 
public class CustomizableProxy : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IDragHandler, IBeginDragHandler // TypeDefIndex: 5624
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x55E014 Offset: 0x55E014 VA: 0x55E014
	private Action<CustomizableProxy> onSelect; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x55E024 Offset: 0x55E024 VA: 0x55E024
	private Action<Vector2> onDrag; // 0x10
	public static CustomizableProxy current; // 0x0
	protected CustomizableComp m_comp; // 0x14
	protected BoundLine m_highlight; // 0x18
	protected Transform m_focusLayer; // 0x1C
	private static List<Selectable> m_compBuffer; // 0x4
	private Vector2 m_lastPointerPos; // 0x20
	private RectTransform m_rTrans; // 0x28
	private CustomizableProxy.OrigParent m_origParent; // 0x2C

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57A59C Offset: 0x57A59C VA: 0x57A59C
	// RVA: 0xD65A34 Offset: 0xD65A34 VA: 0xD65A34
	public void add_onSelect(Action<CustomizableProxy> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A5AC Offset: 0x57A5AC VA: 0x57A5AC
	// RVA: 0xD68224 Offset: 0xD68224 VA: 0xD68224
	public void remove_onSelect(Action<CustomizableProxy> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A5BC Offset: 0x57A5BC VA: 0x57A5BC
	// RVA: 0xD65B40 Offset: 0xD65B40 VA: 0xD65B40
	public void add_onDrag(Action<Vector2> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A5CC Offset: 0x57A5CC VA: 0x57A5CC
	// RVA: 0xD68330 Offset: 0xD68330 VA: 0xD68330
	public void remove_onDrag(Action<Vector2> value) { }

	// RVA: 0xD66E64 Offset: 0xD66E64 VA: 0xD66E64
	public CustomValue GetVal() { }

	// RVA: 0xD6843C Offset: 0xD6843C VA: 0xD6843C Slot: 4
	public void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0xD684B0 Offset: 0xD684B0 VA: 0xD684B0 Slot: 6
	public void OnBeginDrag(PointerEventData eventData) { }

	// RVA: 0xD684FC Offset: 0xD684FC VA: 0xD684FC Slot: 5
	public void OnDrag(PointerEventData eventData) { }

	// RVA: 0xD68808 Offset: 0xD68808 VA: 0xD68808
	private void Awake() { }

	// RVA: 0xD659A0 Offset: 0xD659A0 VA: 0xD659A0
	public void Init(Transform focusLayer, Color highLitColor) { }

	// RVA: 0xD68918 Offset: 0xD68918 VA: 0xD68918
	protected void SetAsCustomModel() { }

	// RVA: 0xD68B24 Offset: 0xD68B24 VA: 0xD68B24
	private void InitHighLit() { }

	// RVA: 0xD6858C Offset: 0xD6858C VA: 0xD6858C
	private Vector2 CalcDragDelta(PointerEventData eventData) { }

	// RVA: 0xD672FC Offset: 0xD672FC VA: 0xD672FC
	public void OnFocus() { }

	// RVA: 0xD67294 Offset: 0xD67294 VA: 0xD67294
	public void OnLoseFocus() { }

	// RVA: 0xD69044 Offset: 0xD69044 VA: 0xD69044
	private void SetHighLitVisiable(bool visiable) { }

	// RVA: 0xD68440 Offset: 0xD68440 VA: 0xD68440
	protected void OnSelect() { }

	// RVA: 0xD66E94 Offset: 0xD66E94 VA: 0xD66E94
	public void SetVal(CustomValue val) { }

	// RVA: 0xD65FFC Offset: 0xD65FFC VA: 0xD65FFC
	public void JudgeBound(Canvas canvas) { }

	// RVA: 0xD6910C Offset: 0xD6910C VA: 0xD6910C
	public static Rect GetWorldRect(Rect localRect, Matrix4x4 localToWorldMatrix) { }

	// RVA: 0xD6930C Offset: 0xD6930C VA: 0xD6930C
	public void .ctor() { }

	// RVA: 0xD69314 Offset: 0xD69314 VA: 0xD69314
	private static void .cctor() { }
}
