// Namespace: 
public sealed class Conduct.FinishCallback : MulticastDelegate // TypeDefIndex: 13283
{
	// Methods

	// RVA: 0x92FB6C Offset: 0x92FB6C VA: 0x92FB6C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x92F708 Offset: 0x92F708 VA: 0x92F708 Slot: 12
	public virtual void Invoke(float finishTime) { }

	// RVA: 0x92FB80 Offset: 0x92FB80 VA: 0x92FB80 Slot: 13
	public virtual IAsyncResult BeginInvoke(float finishTime, AsyncCallback callback, object object) { }

	// RVA: 0x92FC1C Offset: 0x92FC1C VA: 0x92FC1C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
