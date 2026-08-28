// Namespace: 
[Serializable]
public class AkGameObjListenerList : AkAudioListener.BaseListenerList // TypeDefIndex: 6067
{
	// Fields
	private AkGameObj akGameObj; // 0x10
	[SerializeField] // RVA: 0x55FDA8 Offset: 0x55FDA8 VA: 0x55FDA8
	public List<AkAudioListener> initialListenerList; // 0x14
	[SerializeField] // RVA: 0x55FDB8 Offset: 0x55FDB8 VA: 0x55FDB8
	public bool useDefaultListeners; // 0x18

	// Methods

	// RVA: 0x1BA551C Offset: 0x1BA551C VA: 0x1BA551C
	public void SetUseDefaultListeners(bool useDefault) { }

	// RVA: 0x1BA3DD4 Offset: 0x1BA3DD4 VA: 0x1BA3DD4
	public void Init(AkGameObj akGameObj) { }

	// RVA: 0x1BA578C Offset: 0x1BA578C VA: 0x1BA578C Slot: 4
	public override bool Add(AkAudioListener listener) { }

	// RVA: 0x1BA58BC Offset: 0x1BA58BC VA: 0x1BA58BC Slot: 5
	public override bool Remove(AkAudioListener listener) { }

	// RVA: 0x1BA4AE4 Offset: 0x1BA4AE4 VA: 0x1BA4AE4
	public void .ctor() { }
}
