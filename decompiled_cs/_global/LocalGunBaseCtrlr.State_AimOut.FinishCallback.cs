// Namespace: 
public sealed class LocalGunBaseCtrlr.State_AimOut.FinishCallback : MulticastDelegate // TypeDefIndex: 13102
{
	// Methods

	// RVA: 0xCF4818 Offset: 0xCF4818 VA: 0xCF4818
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xCF5E7C Offset: 0xCF5E7C VA: 0xCF5E7C Slot: 12
	public virtual void Invoke(float finishTime) { }

	// RVA: 0xCF63FC Offset: 0xCF63FC VA: 0xCF63FC Slot: 13
	public virtual IAsyncResult BeginInvoke(float finishTime, AsyncCallback callback, object object) { }

	// RVA: 0xCF6498 Offset: 0xCF6498 VA: 0xCF6498 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
