// Namespace: 
public sealed class HotUpdateUIProxy.AppDownloadUrlHandler : MulticastDelegate // TypeDefIndex: 8964
{
	// Methods

	// RVA: 0xDA3644 Offset: 0xDA3644 VA: 0xDA3644
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xDA04C4 Offset: 0xDA04C4 VA: 0xDA04C4 Slot: 12
	public virtual void Invoke(string url) { }

	// RVA: 0xDA3658 Offset: 0xDA3658 VA: 0xDA3658 Slot: 13
	public virtual IAsyncResult BeginInvoke(string url, AsyncCallback callback, object object) { }

	// RVA: 0xDA3684 Offset: 0xDA3684 VA: 0xDA3684 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
