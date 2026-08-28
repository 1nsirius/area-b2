// Namespace: 
public class AkCallbackInfo : IDisposable // TypeDefIndex: 5885
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public IntPtr pCookie { get; }
	public ulong gameObjID { get; }

	// Methods

	// RVA: 0xFDEFC8 Offset: 0xFDEFC8 VA: 0xFDEFC8
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFDEFF0 Offset: 0xFDEFF0 VA: 0xFDEFF0
	internal static IntPtr getCPtr(AkCallbackInfo obj) { }

	// RVA: 0xFDF048 Offset: 0xFDF048 VA: 0xFDF048 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFDF074 Offset: 0xFDF074 VA: 0xFDF074 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFDF0E8 Offset: 0xFDF0E8 VA: 0xFDF0E8 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFDF26C Offset: 0xFDF26C VA: 0xFDF26C
	public IntPtr get_pCookie() { }

	// RVA: 0xFDF2F4 Offset: 0xFDF2F4 VA: 0xFDF2F4
	public ulong get_gameObjID() { }

	// RVA: 0xFDF37C Offset: 0xFDF37C VA: 0xFDF37C
	public void .ctor() { }
}
