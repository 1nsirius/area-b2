// Namespace: 
public sealed class NaviPathManager.PositionGetter : MulticastDelegate // TypeDefIndex: 12195
{
	// Methods

	// RVA: 0x9B3C10 Offset: 0x9B3C10 VA: 0x9B3C10
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x9B21DC Offset: 0x9B21DC VA: 0x9B21DC Slot: 12
	public virtual bool Invoke(U64Id carId, out Vector3 pos) { }

	// RVA: 0x9B3C24 Offset: 0x9B3C24 VA: 0x9B3C24 Slot: 13
	public virtual IAsyncResult BeginInvoke(U64Id carId, out Vector3 pos, AsyncCallback callback, object object) { }

	// RVA: 0x9B3CE4 Offset: 0x9B3CE4 VA: 0x9B3CE4 Slot: 14
	public virtual bool EndInvoke(out Vector3 pos, IAsyncResult result) { }
}
