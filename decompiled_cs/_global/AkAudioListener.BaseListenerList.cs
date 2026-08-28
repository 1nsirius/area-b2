// Namespace: 
public class AkAudioListener.BaseListenerList // TypeDefIndex: 6048
{
	// Fields
	private readonly List<ulong> listenerIdList; // 0x8
	private readonly List<AkAudioListener> listenerList; // 0xC

	// Properties
	public List<AkAudioListener> ListenerList { get; }

	// Methods

	// RVA: 0xFD9E4C Offset: 0xFD9E4C VA: 0xFD9E4C
	public List<AkAudioListener> get_ListenerList() { }

	// RVA: 0xFD9E54 Offset: 0xFD9E54 VA: 0xFD9E54 Slot: 4
	public virtual bool Add(AkAudioListener listener) { }

	// RVA: 0xFD9FB8 Offset: 0xFD9FB8 VA: 0xFD9FB8 Slot: 5
	public virtual bool Remove(AkAudioListener listener) { }

	// RVA: 0xFDA11C Offset: 0xFDA11C VA: 0xFDA11C
	public ulong[] GetListenerIds() { }

	// RVA: 0xFDA194 Offset: 0xFDA194 VA: 0xFDA194
	public void .ctor() { }
}
