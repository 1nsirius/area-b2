// Namespace: 
public sealed class BulletUtil.OnHitHostileWarnTrigger : MulticastDelegate // TypeDefIndex: 13290
{
	// Methods

	// RVA: 0x9299DC Offset: 0x9299DC VA: 0x9299DC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x9299F0 Offset: 0x9299F0 VA: 0x9299F0 Slot: 12
	public virtual void Invoke(byte uid) { }

	// RVA: 0x929E54 Offset: 0x929E54 VA: 0x929E54 Slot: 13
	public virtual IAsyncResult BeginInvoke(byte uid, AsyncCallback callback, object object) { }

	// RVA: 0x929EF0 Offset: 0x929EF0 VA: 0x929EF0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
