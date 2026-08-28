// Namespace: 
public class AkThreadProperties : IDisposable // TypeDefIndex: 5867
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public int nPriority { get; set; }
	public uint uStackSize { get; set; }
	public int uSchedPolicy { get; set; }
	public uint dwAffinityMask { get; set; }

	// Methods

	// RVA: 0xCA6774 Offset: 0xCA6774 VA: 0xCA6774
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xCA679C Offset: 0xCA679C VA: 0xCA679C
	internal static IntPtr getCPtr(AkThreadProperties obj) { }

	// RVA: 0xCA67F4 Offset: 0xCA67F4 VA: 0xCA67F4 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xCA6820 Offset: 0xCA6820 VA: 0xCA6820 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xCA6894 Offset: 0xCA6894 VA: 0xCA6894 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xCA6A18 Offset: 0xCA6A18 VA: 0xCA6A18
	public void set_nPriority(int value) { }

	// RVA: 0xCA6AA8 Offset: 0xCA6AA8 VA: 0xCA6AA8
	public int get_nPriority() { }

	// RVA: 0xCA6B30 Offset: 0xCA6B30 VA: 0xCA6B30
	public void set_uStackSize(uint value) { }

	// RVA: 0xCA6BC0 Offset: 0xCA6BC0 VA: 0xCA6BC0
	public uint get_uStackSize() { }

	// RVA: 0xCA6C48 Offset: 0xCA6C48 VA: 0xCA6C48
	public void set_uSchedPolicy(int value) { }

	// RVA: 0xCA6CD8 Offset: 0xCA6CD8 VA: 0xCA6CD8
	public int get_uSchedPolicy() { }

	// RVA: 0xCA6D60 Offset: 0xCA6D60 VA: 0xCA6D60
	public void set_dwAffinityMask(uint value) { }

	// RVA: 0xCA6DF0 Offset: 0xCA6DF0 VA: 0xCA6DF0
	public uint get_dwAffinityMask() { }

	// RVA: 0xCA6E78 Offset: 0xCA6E78 VA: 0xCA6E78
	public void .ctor() { }
}
