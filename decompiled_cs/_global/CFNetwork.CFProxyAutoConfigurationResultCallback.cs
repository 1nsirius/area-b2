// Namespace: 
private sealed class CFNetwork.CFProxyAutoConfigurationResultCallback : MulticastDelegate // TypeDefIndex: 1601
{
	// Methods

	// RVA: 0x18D2DC8 Offset: 0x18D2DC8 VA: 0x18D2DC8
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x18D3A34 Offset: 0x18D3A34 VA: 0x18D3A34 Slot: 12
	public virtual void Invoke(IntPtr client, IntPtr proxyList, IntPtr error) { }

	// RVA: 0x18D3E90 Offset: 0x18D3E90 VA: 0x18D3E90 Slot: 13
	public virtual IAsyncResult BeginInvoke(IntPtr client, IntPtr proxyList, IntPtr error, AsyncCallback callback, object object) { }

	// RVA: 0x18D3F58 Offset: 0x18D3F58 VA: 0x18D3F58 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
