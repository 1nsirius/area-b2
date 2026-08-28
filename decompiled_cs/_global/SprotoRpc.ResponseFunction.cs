// Namespace: 
public sealed class SprotoRpc.ResponseFunction : MulticastDelegate // TypeDefIndex: 8835
{
	// Methods

	// RVA: 0x12ABC24 Offset: 0x12ABC24 VA: 0x12ABC24
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x12AC3E0 Offset: 0x12AC3E0 VA: 0x12AC3E0 Slot: 12
	public virtual byte[] Invoke(SprotoTypeBase response) { }

	// RVA: 0x12ACC30 Offset: 0x12ACC30 VA: 0x12ACC30 Slot: 13
	public virtual IAsyncResult BeginInvoke(SprotoTypeBase response, AsyncCallback callback, object object) { }

	// RVA: 0x12ACC5C Offset: 0x12ACC5C VA: 0x12ACC5C Slot: 14
	public virtual byte[] EndInvoke(IAsyncResult result) { }
}
