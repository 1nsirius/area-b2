// Namespace: 
public sealed class AkTriggerBase.Trigger : MulticastDelegate // TypeDefIndex: 6094
{
	// Methods

	// RVA: 0xCA8AAC Offset: 0xCA8AAC VA: 0xCA8AAC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xCA8AC0 Offset: 0xCA8AC0 VA: 0xCA8AC0 Slot: 12
	public virtual void Invoke(GameObject in_gameObject) { }

	// RVA: 0xCA92E8 Offset: 0xCA92E8 VA: 0xCA92E8 Slot: 13
	public virtual IAsyncResult BeginInvoke(GameObject in_gameObject, AsyncCallback callback, object object) { }

	// RVA: 0xCA9314 Offset: 0xCA9314 VA: 0xCA9314 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
