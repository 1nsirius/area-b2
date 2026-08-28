// Namespace: 
public class AkMemSettings : IDisposable // TypeDefIndex: 5912
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uMaxNumPools { get; set; }
	public uint uDebugFlags { get; set; }

	// Methods

	// RVA: 0x1BA8724 Offset: 0x1BA8724 VA: 0x1BA8724
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA85F8 Offset: 0x1BA85F8 VA: 0x1BA85F8
	internal static IntPtr getCPtr(AkMemSettings obj) { }

	// RVA: 0x1BB1D8C Offset: 0x1BB1D8C VA: 0x1BB1D8C Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB1DB8 Offset: 0x1BB1DB8 VA: 0x1BB1DB8 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB1E2C Offset: 0x1BB1E2C VA: 0x1BB1E2C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB1FB0 Offset: 0x1BB1FB0 VA: 0x1BB1FB0
	public void .ctor() { }

	// RVA: 0x1BB204C Offset: 0x1BB204C VA: 0x1BB204C
	public void set_uMaxNumPools(uint value) { }

	// RVA: 0x1BB20DC Offset: 0x1BB20DC VA: 0x1BB20DC
	public uint get_uMaxNumPools() { }

	// RVA: 0x1BB2164 Offset: 0x1BB2164 VA: 0x1BB2164
	public void set_uDebugFlags(uint value) { }

	// RVA: 0x1BB21F4 Offset: 0x1BB21F4 VA: 0x1BB21F4
	public uint get_uDebugFlags() { }
}
