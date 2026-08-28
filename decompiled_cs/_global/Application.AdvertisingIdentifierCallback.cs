// Namespace: 
public sealed class Application.AdvertisingIdentifierCallback : MulticastDelegate // TypeDefIndex: 3050
{
	// Methods

	// RVA: 0x22299D4 Offset: 0x22299D4 VA: 0x22299D4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2226AE0 Offset: 0x2226AE0 VA: 0x2226AE0 Slot: 12
	public virtual void Invoke(string advertisingId, bool trackingEnabled, string errorMsg) { }

	// RVA: 0x22299E8 Offset: 0x22299E8 VA: 0x22299E8 Slot: 13
	public virtual IAsyncResult BeginInvoke(string advertisingId, bool trackingEnabled, string errorMsg, AsyncCallback callback, object object) { }

	// RVA: 0x2229A90 Offset: 0x2229A90 VA: 0x2229A90 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
