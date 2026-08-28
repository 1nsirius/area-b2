// Namespace: 
[UnmanagedFunctionPointerAttribute] // RVA: 0x558F7C Offset: 0x558F7C VA: 0x558F7C
public sealed class AkLogger.ErrorLoggerInteropDelegate : MulticastDelegate // TypeDefIndex: 5999
{
	// Methods

	// RVA: 0x1BAA6C4 Offset: 0x1BAA6C4 VA: 0x1BAA6C4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1BAAB1C Offset: 0x1BAAB1C VA: 0x1BAAB1C Slot: 12
	public virtual void Invoke(string message) { }

	// RVA: 0x1BAB344 Offset: 0x1BAB344 VA: 0x1BAB344 Slot: 13
	public virtual IAsyncResult BeginInvoke(string message, AsyncCallback callback, object object) { }

	// RVA: 0x1BAB370 Offset: 0x1BAB370 VA: 0x1BAB370 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
