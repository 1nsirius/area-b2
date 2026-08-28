// Namespace: 
public sealed class HotUpdateUIProxy.BottomLeftTextHandler : MulticastDelegate // TypeDefIndex: 8959
{
	// Methods

	// RVA: 0xDA3690 Offset: 0xDA3690 VA: 0xDA3690
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xD9C14C Offset: 0xD9C14C VA: 0xD9C14C Slot: 12
	public virtual void Invoke(string text) { }

	// RVA: 0xDA36A4 Offset: 0xDA36A4 VA: 0xDA36A4 Slot: 13
	public virtual IAsyncResult BeginInvoke(string text, AsyncCallback callback, object object) { }

	// RVA: 0xDA36D0 Offset: 0xDA36D0 VA: 0xDA36D0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
