// Namespace: 
public class AkSerializedCallbackHeader : IDisposable // TypeDefIndex: 5951
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public IntPtr pPackage { get; }
	public AkSerializedCallbackHeader pNext { get; }
	public AkCallbackType eType { get; }

	// Methods

	// RVA: 0x1674518 Offset: 0x1674518 VA: 0x1674518
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1674540 Offset: 0x1674540 VA: 0x1674540
	internal static IntPtr getCPtr(AkSerializedCallbackHeader obj) { }

	// RVA: 0x1674598 Offset: 0x1674598 VA: 0x1674598 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x16745C4 Offset: 0x16745C4 VA: 0x16745C4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1674638 Offset: 0x1674638 VA: 0x1674638 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x16748A4 Offset: 0x16748A4 VA: 0x16748A4
	public IntPtr get_pPackage() { }

	// RVA: 0x1674A18 Offset: 0x1674A18 VA: 0x1674A18
	public AkSerializedCallbackHeader get_pNext() { }

	// RVA: 0x1674BD4 Offset: 0x1674BD4 VA: 0x1674BD4
	public AkCallbackType get_eType() { }

	// RVA: 0x1674D44 Offset: 0x1674D44 VA: 0x1674D44
	public IntPtr GetData() { }

	// RVA: 0x1674EB4 Offset: 0x1674EB4 VA: 0x1674EB4
	public void .ctor() { }
}
