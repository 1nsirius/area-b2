// Namespace: 
public sealed class CullingGroup.StateChanged : MulticastDelegate // TypeDefIndex: 3103
{
	// Methods

	// RVA: 0x22352C4 Offset: 0x22352C4 VA: 0x22352C4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x2234E40 Offset: 0x2234E40 VA: 0x2234E40 Slot: 12
	public virtual void Invoke(CullingGroupEvent sphere) { }

	// RVA: 0x22352D8 Offset: 0x22352D8 VA: 0x22352D8 Slot: 13
	public virtual IAsyncResult BeginInvoke(CullingGroupEvent sphere, AsyncCallback callback, object object) { }

	// RVA: 0x2235378 Offset: 0x2235378 VA: 0x2235378 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
