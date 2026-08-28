// Namespace: 
[AddComponentMenu] // RVA: 0x551108 Offset: 0x551108 VA: 0x551108
[RequireComponent] // RVA: 0x551108 Offset: 0x551108 VA: 0x551108
[DisallowMultipleComponent] // RVA: 0x551108 Offset: 0x551108 VA: 0x551108
public class AkAudioListener : MonoBehaviour // TypeDefIndex: 6047
{
	// Fields
	private static readonly AkAudioListener.DefaultListenerList defaultListeners; // 0x0
	private ulong akGameObjectID; // 0x10
	private List<AkGameObj> EmittersToStartListeningTo; // 0x18
	private List<AkGameObj> EmittersToStopListeningTo; // 0x1C
	public bool isDefaultListener; // 0x20
	[SerializeField] // RVA: 0x55FA70 Offset: 0x55FA70 VA: 0x55FA70
	public int listenerId; // 0x24

	// Properties
	public static AkAudioListener.DefaultListenerList DefaultListeners { get; }

	// Methods

	// RVA: 0xFD9508 Offset: 0xFD9508 VA: 0xFD9508
	public static AkAudioListener.DefaultListenerList get_DefaultListeners() { }

	// RVA: 0xFD9594 Offset: 0xFD9594 VA: 0xFD9594
	public void StartListeningToEmitter(AkGameObj emitter) { }

	// RVA: 0xFD9644 Offset: 0xFD9644 VA: 0xFD9644
	public void StopListeningToEmitter(AkGameObj emitter) { }

	// RVA: 0xFD96F4 Offset: 0xFD96F4 VA: 0xFD96F4
	public void SetIsDefaultListener(bool isDefault) { }

	// RVA: 0xFD9804 Offset: 0xFD9804 VA: 0xFD9804
	private void Awake() { }

	// RVA: 0xFD9914 Offset: 0xFD9914 VA: 0xFD9914
	private void OnEnable() { }

	// RVA: 0xFD99C8 Offset: 0xFD99C8 VA: 0xFD99C8
	private void OnDisable() { }

	// RVA: 0xFD9A7C Offset: 0xFD9A7C VA: 0xFD9A7C
	private void Update() { }

	// RVA: 0xFD9C28 Offset: 0xFD9C28 VA: 0xFD9C28
	public ulong GetAkGameObjectID() { }

	// RVA: 0xFD9C30 Offset: 0xFD9C30 VA: 0xFD9C30
	public void Migrate14() { }

	// RVA: 0xFD9D14 Offset: 0xFD9D14 VA: 0xFD9D14
	public void .ctor() { }

	// RVA: 0xFD9DCC Offset: 0xFD9DCC VA: 0xFD9DCC
	private static void .cctor() { }
}
