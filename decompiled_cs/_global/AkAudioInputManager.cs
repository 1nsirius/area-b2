// Namespace: 
public static class AkAudioInputManager // TypeDefIndex: 5964
{
	// Fields
	private static bool initialized; // 0x0
	private static readonly Dictionary<uint, AkAudioInputManager.AudioSamplesDelegate> audioSamplesDelegates; // 0x4
	private static readonly Dictionary<uint, AkAudioInputManager.AudioFormatDelegate> audioFormatDelegates; // 0x8
	private static readonly AkAudioFormat audioFormat; // 0xC
	private static readonly AkAudioInputManager.AudioSamplesInteropDelegate audioSamplesDelegate; // 0x10
	private static readonly AkAudioInputManager.AudioFormatInteropDelegate audioFormatDelegate; // 0x14

	// Methods

	// RVA: 0xFD7130 Offset: 0xFD7130 VA: 0xFD7130
	public static uint PostAudioInputEvent(Event akEvent, GameObject gameObject, AkAudioInputManager.AudioSamplesDelegate sampleDelegate, AkAudioInputManager.AudioFormatDelegate formatDelegate) { }

	// RVA: 0xFD74B0 Offset: 0xFD74B0 VA: 0xFD74B0
	public static uint PostAudioInputEvent(uint akEventID, GameObject gameObject, AkAudioInputManager.AudioSamplesDelegate sampleDelegate, AkAudioInputManager.AudioFormatDelegate formatDelegate) { }

	// RVA: 0xFD75D8 Offset: 0xFD75D8 VA: 0xFD75D8
	public static uint PostAudioInputEvent(string akEventName, GameObject gameObject, AkAudioInputManager.AudioSamplesDelegate sampleDelegate, AkAudioInputManager.AudioFormatDelegate formatDelegate) { }

	[MonoPInvokeCallbackAttribute] // RVA: 0x57B13C Offset: 0x57B13C VA: 0x57B13C
	// RVA: 0xFD6E04 Offset: 0xFD6E04 VA: 0xFD6E04
	private static bool InternalAudioSamplesDelegate(uint playingID, float[] samples, uint channelIndex, uint frames) { }

	[MonoPInvokeCallbackAttribute] // RVA: 0x57B1B4 Offset: 0x57B1B4 VA: 0x57B1B4
	// RVA: 0xFD6F7C Offset: 0xFD6F7C VA: 0xFD6F7C
	private static void InternalAudioFormatDelegate(uint playingID, IntPtr format) { }

	// RVA: 0xFD7238 Offset: 0xFD7238 VA: 0xFD7238
	private static void TryInitialize() { }

	// RVA: 0xFD735C Offset: 0xFD735C VA: 0xFD735C
	private static void AddPlayingID(uint playingID, AkAudioInputManager.AudioSamplesDelegate sampleDelegate, AkAudioInputManager.AudioFormatDelegate formatDelegate) { }

	// RVA: 0xFD8040 Offset: 0xFD8040 VA: 0xFD8040
	private static void EventCallback(object cookie, AkCallbackType type, AkCallbackInfo callbackInfo) { }

	// RVA: 0xFD8250 Offset: 0xFD8250 VA: 0xFD8250
	private static void .cctor() { }
}
