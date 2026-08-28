// Namespace: 
[AddComponentMenu] // RVA: 0x5511C8 Offset: 0x5511C8 VA: 0x5511C8
[ExecuteInEditMode] // RVA: 0x5511C8 Offset: 0x5511C8 VA: 0x5511C8
public class AkBank : AkTriggerHandler // TypeDefIndex: 6050
{
	// Fields
	public Bank data; // 0x18
	public bool decodeBank; // 0x1C
	public bool loadAsynchronous; // 0x1D
	public bool saveDecodedBank; // 0x1E
	public List<int> unloadTriggerList; // 0x20
	[HideInInspector] // RVA: 0x55FA80 Offset: 0x55FA80 VA: 0x55FA80
	[SerializeField] // RVA: 0x55FA80 Offset: 0x55FA80 VA: 0x55FA80
	[FormerlySerializedAsAttribute] // RVA: 0x55FA80 Offset: 0x55FA80 VA: 0x55FA80
	private string bankNameInternal; // 0x24
	[HideInInspector] // RVA: 0x55FADC Offset: 0x55FADC VA: 0x55FADC
	[SerializeField] // RVA: 0x55FADC Offset: 0x55FADC VA: 0x55FADC
	[FormerlySerializedAsAttribute] // RVA: 0x55FADC Offset: 0x55FADC VA: 0x55FADC
	private byte[] valueGuidInternal; // 0x28

	// Properties
	[ObsoleteAttribute] // RVA: 0x66DDF0 Offset: 0x66DDF0 VA: 0x66DDF0
	public string bankName { get; }
	[ObsoleteAttribute] // RVA: 0x66DE24 Offset: 0x66DE24 VA: 0x66DE24
	public byte[] valueGuid { get; }

	// Methods

	// RVA: 0xFDC08C Offset: 0xFDC08C VA: 0xFDC08C Slot: 5
	protected override void Awake() { }

	// RVA: 0xFDC1B4 Offset: 0xFDC1B4 VA: 0xFDC1B4 Slot: 6
	protected override void Start() { }

	// RVA: 0xFDC264 Offset: 0xFDC264 VA: 0xFDC264 Slot: 4
	public override void HandleEvent(GameObject in_gameObject) { }

	// RVA: 0xFDC18C Offset: 0xFDC18C VA: 0xFDC18C
	public void UnloadBank(GameObject in_gameObject) { }

	// RVA: 0xFDC2D8 Offset: 0xFDC2D8 VA: 0xFDC2D8 Slot: 7
	protected override void OnDestroy() { }

	// RVA: 0xFDC3D8 Offset: 0xFDC3D8 VA: 0xFDC3D8
	public string get_bankName() { }

	// RVA: 0xFDC45C Offset: 0xFDC45C VA: 0xFDC45C
	public byte[] get_valueGuid() { }

	// RVA: 0xFDC568 Offset: 0xFDC568 VA: 0xFDC568
	public void .ctor() { }
}
