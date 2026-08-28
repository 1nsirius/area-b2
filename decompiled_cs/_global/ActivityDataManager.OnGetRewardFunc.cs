// Namespace: 
[CSharpCallLuaAttribute] // RVA: 0x55B380 Offset: 0x55B380 VA: 0x55B380
public sealed class ActivityDataManager.OnGetRewardFunc : MulticastDelegate // TypeDefIndex: 9859
{
	// Methods

	// RVA: 0xBE6694 Offset: 0xBE6694 VA: 0xBE6694
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xBE3524 Offset: 0xBE3524 VA: 0xBE3524 Slot: 12
	public virtual void Invoke(int aid, int tid, bool succ) { }

	// RVA: 0xBE66A8 Offset: 0xBE66A8 VA: 0xBE66A8 Slot: 13
	public virtual IAsyncResult BeginInvoke(int aid, int tid, bool succ, AsyncCallback callback, object object) { }

	// RVA: 0xBE677C Offset: 0xBE677C VA: 0xBE677C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
