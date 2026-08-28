// Namespace: 
[AddComponentMenu] // RVA: 0x5515D4 Offset: 0x5515D4 VA: 0x5515D4
[DisallowMultipleComponent] // RVA: 0x5515D4 Offset: 0x5515D4 VA: 0x5515D4
[ExecuteInEditMode] // RVA: 0x5515D4 Offset: 0x5515D4 VA: 0x5515D4
public class AkGameObj : MonoBehaviour // TypeDefIndex: 6065
{
	// Fields
	[SerializeField] // RVA: 0x55FD28 Offset: 0x55FD28 VA: 0x55FD28
	private AkGameObjListenerList m_listeners; // 0xC
	public bool isEnvironmentAware; // 0x10
	[SerializeField] // RVA: 0x55FD38 Offset: 0x55FD38 VA: 0x55FD38
	private bool isStaticObject; // 0x11
	private Collider m_Collider; // 0x14
	private AkGameObjEnvironmentData m_envData; // 0x18
	private AkGameObjPositionData m_posData; // 0x1C
	public AkGameObjPositionOffsetData m_positionOffsetData; // 0x20
	private bool isRegistered; // 0x24
	[HideInInspector] // RVA: 0x55FD48 Offset: 0x55FD48 VA: 0x55FD48
	[SerializeField] // RVA: 0x55FD48 Offset: 0x55FD48 VA: 0x55FD48
	private AkGameObjPosOffsetData m_posOffsetData; // 0x28
	private const int AK_NUM_LISTENERS = 8;
	[HideInInspector] // RVA: 0x55FD78 Offset: 0x55FD78 VA: 0x55FD78
	[SerializeField] // RVA: 0x55FD78 Offset: 0x55FD78 VA: 0x55FD78
	private int listenerMask; // 0x2C

	// Properties
	public bool IsUsingDefaultListeners { get; }
	public List<AkAudioListener> ListenerList { get; }

	// Methods

	// RVA: 0x1BA34C0 Offset: 0x1BA34C0 VA: 0x1BA34C0
	public bool get_IsUsingDefaultListeners() { }

	// RVA: 0x1BA34E4 Offset: 0x1BA34E4 VA: 0x1BA34E4
	public List<AkAudioListener> get_ListenerList() { }

	// RVA: 0x1BA3510 Offset: 0x1BA3510 VA: 0x1BA3510
	internal void AddListener(AkAudioListener listener) { }

	// RVA: 0x1BA354C Offset: 0x1BA354C VA: 0x1BA354C
	internal void RemoveListener(AkAudioListener listener) { }

	// RVA: 0x1BA3588 Offset: 0x1BA3588 VA: 0x1BA3588
	public AKRESULT Register() { }

	// RVA: 0x1BA3668 Offset: 0x1BA3668 VA: 0x1BA3668
	private void Awake() { }

	// RVA: 0x1BA3F28 Offset: 0x1BA3F28 VA: 0x1BA3F28
	private void CheckStaticStatus() { }

	// RVA: 0x1BA3F2C Offset: 0x1BA3F2C VA: 0x1BA3F2C
	private void OnEnable() { }

	// RVA: 0x1BA3F44 Offset: 0x1BA3F44 VA: 0x1BA3F44
	private void OnDestroy() { }

	// RVA: 0x1BA4108 Offset: 0x1BA4108 VA: 0x1BA4108
	private void Update() { }

	// RVA: 0x1BA44E4 Offset: 0x1BA44E4 VA: 0x1BA44E4 Slot: 4
	public virtual Vector3 GetPosition() { }

	// RVA: 0x1BA467C Offset: 0x1BA467C VA: 0x1BA467C Slot: 5
	public virtual Vector3 GetForward() { }

	// RVA: 0x1BA46BC Offset: 0x1BA46BC VA: 0x1BA46BC Slot: 6
	public virtual Vector3 GetUpward() { }

	// RVA: 0x1BA46FC Offset: 0x1BA46FC VA: 0x1BA46FC
	private void OnTriggerEnter(Collider other) { }

	// RVA: 0x1BA4718 Offset: 0x1BA4718 VA: 0x1BA4718
	private void OnTriggerExit(Collider other) { }

	// RVA: 0x1BA4A60 Offset: 0x1BA4A60 VA: 0x1BA4A60
	public void .ctor() { }
}
