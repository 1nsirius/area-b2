// Namespace: 
internal sealed class TimerThread.Callback : MulticastDelegate // TypeDefIndex: 1934
{
	// Methods

	// RVA: 0x180FE74 Offset: 0x180FE74 VA: 0x180FE74
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x180FE88 Offset: 0x180FE88 VA: 0x180FE88 Slot: 12
	public virtual void Invoke(TimerThread.Timer timer, int timeNoticed, object context) { }

	// RVA: 0x1810684 Offset: 0x1810684 VA: 0x1810684 Slot: 13
	public virtual IAsyncResult BeginInvoke(TimerThread.Timer timer, int timeNoticed, object context, AsyncCallback callback, object object) { }

	// RVA: 0x181072C Offset: 0x181072C VA: 0x181072C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
