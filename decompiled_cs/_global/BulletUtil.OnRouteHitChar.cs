// Namespace: 
public sealed class BulletUtil.OnRouteHitChar : MulticastDelegate // TypeDefIndex: 13288
{
	// Methods

	// RVA: 0x929EFC Offset: 0x929EFC VA: 0x929EFC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x928A28 Offset: 0x928A28 VA: 0x928A28 Slot: 12
	public virtual void Invoke(Character.IView characterView, Collider collider, ref RaycastHit hitInfo, CharacterBodyPart hitPart) { }

	// RVA: 0x929F10 Offset: 0x929F10 VA: 0x929F10 Slot: 13
	public virtual IAsyncResult BeginInvoke(Character.IView characterView, Collider collider, ref RaycastHit hitInfo, CharacterBodyPart hitPart, AsyncCallback callback, object object) { }

	// RVA: 0x929FD8 Offset: 0x929FD8 VA: 0x929FD8 Slot: 14
	public virtual void EndInvoke(ref RaycastHit hitInfo, IAsyncResult result) { }
}
