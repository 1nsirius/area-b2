// Namespace: 
public class AkCallbackSerializer : IDisposable // TypeDefIndex: 5886
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Methods

	// RVA: 0xFE39E0 Offset: 0xFE39E0 VA: 0xFE39E0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFE3A08 Offset: 0xFE3A08 VA: 0xFE3A08
	internal static IntPtr getCPtr(AkCallbackSerializer obj) { }

	// RVA: 0xFE3A60 Offset: 0xFE3A60 VA: 0xFE3A60 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE3A8C Offset: 0xFE3A8C VA: 0xFE3A8C Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE3B00 Offset: 0xFE3B00 VA: 0xFE3B00 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFE0320 Offset: 0xFE0320 VA: 0xFE0320
	public static AKRESULT Init(IntPtr in_pMemory, uint in_uSize) { }

	// RVA: 0xFE04E8 Offset: 0xFE04E8 VA: 0xFE04E8
	public static void Term() { }

	// RVA: 0xFE1AD4 Offset: 0xFE1AD4 VA: 0xFE1AD4
	public static IntPtr Lock() { }

	// RVA: 0xFE0608 Offset: 0xFE0608 VA: 0xFE0608
	public static void SetLocalOutput(uint in_uErrorLevel) { }

	// RVA: 0xFE2CE8 Offset: 0xFE2CE8 VA: 0xFE2CE8
	public static void Unlock() { }

	// RVA: 0xFE3C84 Offset: 0xFE3C84 VA: 0xFE3C84
	public static AKRESULT AudioSourceChangeCallbackFunc(bool in_bOtherAudioPlaying, object in_pCookie) { }

	// RVA: 0xFE3D40 Offset: 0xFE3D40 VA: 0xFE3D40
	public void .ctor() { }
}
