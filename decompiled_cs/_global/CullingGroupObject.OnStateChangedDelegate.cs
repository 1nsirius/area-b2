// Namespace: 
public sealed class CullingGroupObject.OnStateChangedDelegate : MulticastDelegate // TypeDefIndex: 7383
{
	// Methods

	// RVA: 0xD61CD4 Offset: 0xD61CD4 VA: 0xD61CD4
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0xD616C0 Offset: 0xD616C0 VA: 0xD616C0 Slot: 12
	public virtual void Invoke(int curDistanceLv, bool isVisable, bool isVisableChanged) { }

	// RVA: 0xD61CE8 Offset: 0xD61CE8 VA: 0xD61CE8 Slot: 13
	public virtual IAsyncResult BeginInvoke(int curDistanceLv, bool isVisable, bool isVisableChanged, AsyncCallback callback, object object) { }

	// RVA: 0xD61DBC Offset: 0xD61DBC VA: 0xD61DBC Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
