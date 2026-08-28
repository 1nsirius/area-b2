// Namespace: 
private sealed class XdrBuilder.XdrBuildFunction : MulticastDelegate // TypeDefIndex: 2723
{
	// Methods

	// RVA: 0x183EEB0 Offset: 0x183EEB0 VA: 0x183EEB0
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x183EEC4 Offset: 0x183EEC4 VA: 0x183EEC4 Slot: 12
	public virtual void Invoke(XdrBuilder builder, object obj, string prefix) { }

	// RVA: 0x183F6C0 Offset: 0x183F6C0 VA: 0x183F6C0 Slot: 13
	public virtual IAsyncResult BeginInvoke(XdrBuilder builder, object obj, string prefix, AsyncCallback callback, object object) { }

	// RVA: 0x183F700 Offset: 0x183F700 VA: 0x183F700 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
