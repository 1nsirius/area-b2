// Namespace: 
[AddComponentMenu] // RVA: 0x551A4C Offset: 0x551A4C VA: 0x551A4C
[RequireComponent] // RVA: 0x551A4C Offset: 0x551A4C VA: 0x551A4C
[DisallowMultipleComponent] // RVA: 0x551A4C Offset: 0x551A4C VA: 0x551A4C
public class AkSpatialAudioListener : AkSpatialAudioBase // TypeDefIndex: 6087
{
	// Fields
	private static AkSpatialAudioListener s_SpatialAudioListener; // 0x0
	private static readonly AkSpatialAudioListener.SpatialAudioListenerList spatialAudioListeners; // 0x4
	private AkAudioListener AkAudioListener; // 0x10

	// Properties
	public static AkAudioListener TheSpatialAudioListener { get; }
	public static AkSpatialAudioListener.SpatialAudioListenerList SpatialAudioListeners { get; }

	// Methods

	// RVA: 0xCA3560 Offset: 0xCA3560 VA: 0xCA3560
	public static AkAudioListener get_TheSpatialAudioListener() { }

	// RVA: 0xCA3690 Offset: 0xCA3690 VA: 0xCA3690
	public static AkSpatialAudioListener.SpatialAudioListenerList get_SpatialAudioListeners() { }

	// RVA: 0xCA371C Offset: 0xCA371C VA: 0xCA371C
	private void Awake() { }

	// RVA: 0xCA3784 Offset: 0xCA3784 VA: 0xCA3784
	private void OnEnable() { }

	// RVA: 0xCA3940 Offset: 0xCA3940 VA: 0xCA3940
	private void OnDisable() { }

	// RVA: 0xCA3AFC Offset: 0xCA3AFC VA: 0xCA3AFC
	public void .ctor() { }

	// RVA: 0xCA3B00 Offset: 0xCA3B00 VA: 0xCA3B00
	private static void .cctor() { }
}
