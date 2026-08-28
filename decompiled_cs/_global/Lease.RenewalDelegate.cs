// Namespace: 
private sealed class Lease.RenewalDelegate : MulticastDelegate // TypeDefIndex: 1146
{
	// Methods

	// RVA: 0x172114C Offset: 0x172114C VA: 0x172114C
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x17214C4 Offset: 0x17214C4 VA: 0x17214C4 Slot: 12
	public virtual TimeSpan Invoke(ILease lease) { }

	// RVA: 0x1721160 Offset: 0x1721160 VA: 0x1721160 Slot: 13
	public virtual IAsyncResult BeginInvoke(ILease lease, AsyncCallback callback, object object) { }

	// RVA: 0x1721484 Offset: 0x1721484 VA: 0x1721484 Slot: 14
	public virtual TimeSpan EndInvoke(IAsyncResult result) { }
}
