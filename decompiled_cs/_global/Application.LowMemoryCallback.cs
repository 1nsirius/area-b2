// Namespace: 
public sealed class Application.LowMemoryCallback : MulticastDelegate // TypeDefIndex: 3051
{
	// Methods

	// RVA: 0x2229B64 Offset: 0x2229B64 VA: 0x2229B64
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2225924 Offset: 0x2225924 VA: 0x2225924 Slot: 12
	public virtual void Invoke() { }

	// RVA: 0x2229B78 Offset: 0x2229B78 VA: 0x2229B78 Slot: 13
	public virtual IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

	// RVA: 0x2229BA4 Offset: 0x2229BA4 VA: 0x2229BA4 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
