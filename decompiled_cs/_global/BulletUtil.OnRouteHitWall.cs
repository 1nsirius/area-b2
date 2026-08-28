// Namespace: 
public sealed class BulletUtil.OnRouteHitWall : MulticastDelegate // TypeDefIndex: 13289
{
	// Methods

	// RVA: 0x929FFC Offset: 0x929FFC VA: 0x929FFC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x929228 Offset: 0x929228 VA: 0x929228 Slot: 12
	public virtual void Invoke(ref RaycastHit hitInfo) { }

	// RVA: 0x92A010 Offset: 0x92A010 VA: 0x92A010 Slot: 13
	public virtual IAsyncResult BeginInvoke(ref RaycastHit hitInfo, AsyncCallback callback, object object) { }

	// RVA: 0x92A0AC Offset: 0x92A0AC VA: 0x92A0AC Slot: 14
	public virtual void EndInvoke(ref RaycastHit hitInfo, IAsyncResult result) { }
}
