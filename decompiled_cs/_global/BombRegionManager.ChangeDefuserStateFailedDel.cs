// Namespace: 
public sealed class BombRegionManager.ChangeDefuserStateFailedDel : MulticastDelegate // TypeDefIndex: 11665
{
	// Methods

	// RVA: 0x926FDC Offset: 0x926FDC VA: 0x926FDC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x926968 Offset: 0x926968 VA: 0x926968 Slot: 12
	public virtual void Invoke(DefuserState error, DefuserState correct) { }

	// RVA: 0x926FF0 Offset: 0x926FF0 VA: 0x926FF0 Slot: 13
	public virtual IAsyncResult BeginInvoke(DefuserState error, DefuserState correct, AsyncCallback callback, object object) { }

	// RVA: 0x9270A0 Offset: 0x9270A0 VA: 0x9270A0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
