// Namespace: 
public sealed class HotUpdateUIProxy.SetTrDialogButtonVisibleHandler : MulticastDelegate // TypeDefIndex: 8971
{
	// Methods

	// RVA: 0xDA395C Offset: 0xDA395C VA: 0xDA395C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xD9F820 Offset: 0xD9F820 VA: 0xD9F820 Slot: 12
	public virtual void Invoke(bool confirm, bool cancel, bool close) { }

	// RVA: 0xDA3970 Offset: 0xDA3970 VA: 0xDA3970 Slot: 13
	public virtual IAsyncResult BeginInvoke(bool confirm, bool cancel, bool close, AsyncCallback callback, object object) { }

	// RVA: 0xDA3A38 Offset: 0xDA3A38 VA: 0xDA3A38 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
