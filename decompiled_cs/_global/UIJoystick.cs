// Namespace: 
public class UIJoystick : MaskableGraphic, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler // TypeDefIndex: 5812
{
	// Fields
	public RectTransform rtTouch; // 0x64
	public RectTransform rtZone; // 0x68
	public RectTransform rtJoystick; // 0x6C
	protected RectTransform pContentRt; // 0x70
	private RectTransform rtJoystickParent; // 0x74
	[CompilerGeneratedAttribute] // RVA: 0x55EBFC Offset: 0x55EBFC VA: 0x55EBFC
	private float <MaxRadius>k__BackingField; // 0x78
	[CompilerGeneratedAttribute] // RVA: 0x55EC0C Offset: 0x55EC0C VA: 0x55EC0C
	private Vector2 <Movement>k__BackingField; // 0x7C
	private Nullable<int> pointerId; // 0x84
	protected Vector2 startPosition; // 0x8C
	private float zoneRadius; // 0x94
	public int directionCount; // 0x98
	public bool useMultiDirection; // 0x9C
	[CompilerGeneratedAttribute] // RVA: 0x55EC1C Offset: 0x55EC1C VA: 0x55EC1C
	private Vector2 <Position>k__BackingField; // 0xA0
	public Action<Vector2> OnPointerUpEvt; // 0xA8
	[CompilerGeneratedAttribute] // RVA: 0x55EC2C Offset: 0x55EC2C VA: 0x55EC2C
	private float <Angles>k__BackingField; // 0xAC
	[CompilerGeneratedAttribute] // RVA: 0x55EC3C Offset: 0x55EC3C VA: 0x55EC3C
	private float <Distance>k__BackingField; // 0xB0

	// Properties
	public float MaxRadius { get; set; }
	public Vector2 Movement { get; set; }
	public bool IsPress { get; }
	public Vector2 Position { get; set; }
	public Vector2 StartPosition { get; }
	public float Angles { get; set; }
	public float Distance { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57AE2C Offset: 0x57AE2C VA: 0x57AE2C
	// RVA: 0xAF401C Offset: 0xAF401C VA: 0xAF401C
	public float get_MaxRadius() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE3C Offset: 0x57AE3C VA: 0x57AE3C
	// RVA: 0xAF4024 Offset: 0xAF4024 VA: 0xAF4024
	public void set_MaxRadius(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE4C Offset: 0x57AE4C VA: 0x57AE4C
	// RVA: 0xAF402C Offset: 0xAF402C VA: 0xAF402C
	public Vector2 get_Movement() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE5C Offset: 0x57AE5C VA: 0x57AE5C
	// RVA: 0xAF4040 Offset: 0xAF4040 VA: 0xAF4040
	private void set_Movement(Vector2 value) { }

	// RVA: 0xAF404C Offset: 0xAF404C VA: 0xAF404C
	public bool get_IsPress() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE6C Offset: 0x57AE6C VA: 0x57AE6C
	// RVA: 0xAF40B0 Offset: 0xAF40B0 VA: 0xAF40B0
	public Vector2 get_Position() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE7C Offset: 0x57AE7C VA: 0x57AE7C
	// RVA: 0xAF40C4 Offset: 0xAF40C4 VA: 0xAF40C4
	protected void set_Position(Vector2 value) { }

	// RVA: 0xAF40D0 Offset: 0xAF40D0 VA: 0xAF40D0
	public Vector2 get_StartPosition() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE8C Offset: 0x57AE8C VA: 0x57AE8C
	// RVA: 0xAF40E4 Offset: 0xAF40E4 VA: 0xAF40E4
	public float get_Angles() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AE9C Offset: 0x57AE9C VA: 0x57AE9C
	// RVA: 0xAF40EC Offset: 0xAF40EC VA: 0xAF40EC
	private void set_Angles(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57AEAC Offset: 0x57AEAC VA: 0x57AEAC
	// RVA: 0xAF40F4 Offset: 0xAF40F4 VA: 0xAF40F4
	public float get_Distance() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AEBC Offset: 0x57AEBC VA: 0x57AEBC
	// RVA: 0xAF40FC Offset: 0xAF40FC VA: 0xAF40FC
	private void set_Distance(float value) { }

	// RVA: 0xAF4104 Offset: 0xAF4104 VA: 0xAF4104 Slot: 6
	protected override void Start() { }

	// RVA: 0xAF435C Offset: 0xAF435C VA: 0xAF435C Slot: 5
	protected override void OnEnable() { }

	// RVA: 0xAF4504 Offset: 0xAF4504 VA: 0xAF4504 Slot: 7
	protected override void OnDisable() { }

	// RVA: 0xAF4620 Offset: 0xAF4620 VA: 0xAF4620 Slot: 44
	protected override void OnPopulateMesh(VertexHelper vh) { }

	// RVA: 0xAF464C Offset: 0xAF464C VA: 0xAF464C Slot: 65
	public void OnDrag(PointerEventData eventData) { }

	// RVA: 0xAF4D10 Offset: 0xAF4D10 VA: 0xAF4D10 Slot: 66
	public virtual void OnPointerDown(PointerEventData eventData) { }

	// RVA: 0xAF4E48 Offset: 0xAF4E48 VA: 0xAF4E48 Slot: 64
	public void OnPointerUp(PointerEventData eventData) { }

	// RVA: 0xAF47A0 Offset: 0xAF47A0 VA: 0xAF47A0
	private void UpdateMovement(Vector2 position) { }

	// RVA: 0xAF5014 Offset: 0xAF5014 VA: 0xAF5014
	private void ProcessMultiDirectionJoystick(ref Vector3 positionToJoystick, ref Vector3 sourcePos) { }

	// RVA: 0xAF5438 Offset: 0xAF5438 VA: 0xAF5438
	private Vector3 GetActuralDir(float rad, out float targetRad) { }

	// RVA: 0xAF4408 Offset: 0xAF4408 VA: 0xAF4408
	private void ResetCap() { }

	// RVA: 0xAF5620 Offset: 0xAF5620 VA: 0xAF5620 Slot: 67
	protected virtual void OnTouchMovement(float distance) { }

	// RVA: 0xAF5624 Offset: 0xAF5624 VA: 0xAF5624 Slot: 68
	public virtual void OnTick() { }

	// RVA: 0xAF5628 Offset: 0xAF5628 VA: 0xAF5628
	public void .ctor() { }
}
