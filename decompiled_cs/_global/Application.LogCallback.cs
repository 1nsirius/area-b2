// Namespace: 
public sealed class Application.LogCallback : MulticastDelegate // TypeDefIndex: 3052
{
	// Methods

	// RVA: 0x2229A9C Offset: 0x2229A9C VA: 0x2229A9C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2226248 Offset: 0x2226248 VA: 0x2226248 Slot: 12
	public virtual void Invoke(string condition, string stackTrace, LogType type) { }

	// RVA: 0x2229AB0 Offset: 0x2229AB0 VA: 0x2229AB0 Slot: 13
	public virtual IAsyncResult BeginInvoke(string condition, string stackTrace, LogType type, AsyncCallback callback, object object) { }

	// RVA: 0x2229B58 Offset: 0x2229B58 VA: 0x2229B58 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
