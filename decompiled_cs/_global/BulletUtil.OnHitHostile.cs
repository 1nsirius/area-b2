// Namespace: 
public sealed class BulletUtil.OnHitHostile : MulticastDelegate // TypeDefIndex: 13287
{
	// Methods

	// RVA: 0x9298B4 Offset: 0x9298B4 VA: 0x9298B4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x92784C Offset: 0x92784C VA: 0x92784C Slot: 12
	public virtual void Invoke(Character.IView characterView, Collider collider, ref RaycastHit hitInfo, CharacterBodyPart hitPart, bool hitWall) { }

	// RVA: 0x9298C8 Offset: 0x9298C8 VA: 0x9298C8 Slot: 13
	public virtual IAsyncResult BeginInvoke(Character.IView characterView, Collider collider, ref RaycastHit hitInfo, CharacterBodyPart hitPart, bool hitWall, AsyncCallback callback, object object) { }

	// RVA: 0x9299B8 Offset: 0x9299B8 VA: 0x9299B8 Slot: 14
	public virtual void EndInvoke(ref RaycastHit hitInfo, IAsyncResult result) { }
}
