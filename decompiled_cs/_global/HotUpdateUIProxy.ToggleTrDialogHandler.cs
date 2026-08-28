// Namespace: 
public sealed class HotUpdateUIProxy.ToggleTrDialogHandler : MulticastDelegate // TypeDefIndex: 8965
{
	// Methods

	// RVA: 0xDA3EB0 Offset: 0xDA3EB0 VA: 0xDA3EB0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xD9D25C Offset: 0xD9D25C VA: 0xD9D25C Slot: 12
	public virtual void Invoke(bool show) { }

	// RVA: 0xDA3EC4 Offset: 0xDA3EC4 VA: 0xDA3EC4 Slot: 13
	public virtual IAsyncResult BeginInvoke(bool show, AsyncCallback callback, object object) { }

	// RVA: 0xDA3F60 Offset: 0xDA3F60 VA: 0xDA3F60 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
