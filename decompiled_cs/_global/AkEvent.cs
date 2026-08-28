// Namespace: 
[AddComponentMenu] // RVA: 0x551454 Offset: 0x551454 VA: 0x551454
[RequireComponent] // RVA: 0x551454 Offset: 0x551454 VA: 0x551454
public class AkEvent : AkDragDropTriggerHandler // TypeDefIndex: 6057
{
	// Fields
	public AkActionOnEventType actionOnEventType; // 0x18
	public AkCurveInterpolation curveInterpolation; // 0x1C
	public bool enableActionOnEvent; // 0x20
	public Event data; // 0x24
	public bool useCallbacks; // 0x28
	public List<AkEvent.CallbackData> Callbacks; // 0x2C
	public uint playingId; // 0x30
	public GameObject soundEmitterObject; // 0x34
	public float transitionDuration; // 0x38
	private AkEventCallbackMsg EventCallbackMsg; // 0x3C
	[HideInInspector] // RVA: 0x55FBF8 Offset: 0x55FBF8 VA: 0x55FBF8
	[SerializeField] // RVA: 0x55FBF8 Offset: 0x55FBF8 VA: 0x55FBF8
	[FormerlySerializedAsAttribute] // RVA: 0x55FBF8 Offset: 0x55FBF8 VA: 0x55FBF8
	private int eventIdInternal; // 0x40
	[HideInInspector] // RVA: 0x55FC50 Offset: 0x55FC50 VA: 0x55FC50
	[SerializeField] // RVA: 0x55FC50 Offset: 0x55FC50 VA: 0x55FC50
	[FormerlySerializedAsAttribute] // RVA: 0x55FC50 Offset: 0x55FC50 VA: 0x55FC50
	private byte[] valueGuidInternal; // 0x44
	[HideInInspector] // RVA: 0x55FCA8 Offset: 0x55FCA8 VA: 0x55FCA8
	[SerializeField] // RVA: 0x55FCA8 Offset: 0x55FCA8 VA: 0x55FCA8
	[FormerlySerializedAsAttribute] // RVA: 0x55FCA8 Offset: 0x55FCA8 VA: 0x55FCA8
	private AkEventCallbackData m_callbackDataInternal; // 0x48

	// Properties
	protected override BaseType WwiseType { get; }
	[ObsoleteAttribute] // RVA: 0x66DEC0 Offset: 0x66DEC0 VA: 0x66DEC0
	public int eventID { get; }
	[ObsoleteAttribute] // RVA: 0x66DEF4 Offset: 0x66DEF4 VA: 0x66DEF4
	public byte[] valueGuid { get; }
	[ObsoleteAttribute] // RVA: 0x66DF28 Offset: 0x66DF28 VA: 0x66DF28
	public AkEventCallbackData m_callbackData { get; }

	// Methods

	// RVA: 0xFEB7AC Offset: 0xFEB7AC VA: 0xFEB7AC Slot: 8
	protected override BaseType get_WwiseType() { }

	// RVA: 0xFEB7B4 Offset: 0xFEB7B4 VA: 0xFEB7B4 Slot: 6
	protected override void Start() { }

	// RVA: 0xFEB860 Offset: 0xFEB860 VA: 0xFEB860
	private void Callback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info) { }

	// RVA: 0xFD54AC Offset: 0xFD54AC VA: 0xFD54AC Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0xFEBA70 Offset: 0xFEBA70 VA: 0xFEBA70
	public void Stop(int _transitionDuration) { }

	// RVA: 0xFEBA78 Offset: 0xFEBA78 VA: 0xFEBA78
	public void Stop(int _transitionDuration, AkCurveInterpolation _curveInterpolation) { }

	// RVA: 0xFEBAC4 Offset: 0xFEBAC4 VA: 0xFEBAC4
	public int get_eventID() { }

	// RVA: 0xFEBAD8 Offset: 0xFEBAD8 VA: 0xFEBAD8
	public byte[] get_valueGuid() { }

	// RVA: 0xFEBBE4 Offset: 0xFEBBE4 VA: 0xFEBBE4
	public AkEventCallbackData get_m_callbackData() { }

	// RVA: 0xFD595C Offset: 0xFD595C VA: 0xFD595C
	public void .ctor() { }
}
