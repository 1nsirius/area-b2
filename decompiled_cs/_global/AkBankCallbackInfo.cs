// Namespace: 
public class AkBankCallbackInfo : IDisposable // TypeDefIndex: 5882
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint bankID { get; }
	public IntPtr inMemoryBankPtr { get; }
	public AKRESULT loadResult { get; }
	public int memPoolId { get; }

	// Methods

	// RVA: 0xFDC674 Offset: 0xFDC674 VA: 0xFDC674
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFDC69C Offset: 0xFDC69C VA: 0xFDC69C
	internal static IntPtr getCPtr(AkBankCallbackInfo obj) { }

	// RVA: 0xFDC6F4 Offset: 0xFDC6F4 VA: 0xFDC6F4 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFDC720 Offset: 0xFDC720 VA: 0xFDC720 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFDC794 Offset: 0xFDC794 VA: 0xFDC794 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFDC918 Offset: 0xFDC918 VA: 0xFDC918
	public uint get_bankID() { }

	// RVA: 0xFDC9A0 Offset: 0xFDC9A0 VA: 0xFDC9A0
	public IntPtr get_inMemoryBankPtr() { }

	// RVA: 0xFDCA28 Offset: 0xFDCA28 VA: 0xFDCA28
	public AKRESULT get_loadResult() { }

	// RVA: 0xFDCAB0 Offset: 0xFDCAB0 VA: 0xFDCAB0
	public int get_memPoolId() { }

	// RVA: 0xFDCB38 Offset: 0xFDCB38 VA: 0xFDCB38
	public void .ctor() { }
}
