// Namespace: 
public sealed class GUI.WindowFunction : MulticastDelegate // TypeDefIndex: 3665
{
	// Methods

	// RVA: 0x1DDD86C Offset: 0x1DDD86C VA: 0x1DDD86C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1DDD024 Offset: 0x1DDD024 VA: 0x1DDD024 Slot: 12
	public virtual void Invoke(int id) { }

	// RVA: 0x1DDD880 Offset: 0x1DDD880 VA: 0x1DDD880 Slot: 13
	public virtual IAsyncResult BeginInvoke(int id, AsyncCallback callback, object object) { }

	// RVA: 0x1DDD91C Offset: 0x1DDD91C VA: 0x1DDD91C Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
