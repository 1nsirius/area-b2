// Namespace: 
public sealed class ProtocolFunctionDictionary.typeFunc : MulticastDelegate // TypeDefIndex: 8827
{
	// Methods

	// RVA: 0x12A9414 Offset: 0x12A9414 VA: 0x12A9414
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x12A8564 Offset: 0x12A8564 VA: 0x12A8564 Slot: 12
	public virtual SprotoTypeBase Invoke(byte[] buffer, int len, int offset) { }

	// RVA: 0x12A9428 Offset: 0x12A9428 VA: 0x12A9428 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte[] buffer, int len, int offset, AsyncCallback callback, object object) { }

	// RVA: 0x12A94E0 Offset: 0x12A94E0 VA: 0x12A94E0 Slot: 14
	public virtual SprotoTypeBase EndInvoke(IAsyncResult result) { }
}
