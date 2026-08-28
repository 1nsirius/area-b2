// Namespace: 
public class AkPathParams : IDisposable // TypeDefIndex: 5937
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkVector listenerPos { get; set; }
	public AkVector emitterPos { get; set; }
	public uint numValidPaths { get; set; }

	// Methods

	// RVA: 0x1BB6B20 Offset: 0x1BB6B20 VA: 0x1BB6B20
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BB6B48 Offset: 0x1BB6B48 VA: 0x1BB6B48
	internal static IntPtr getCPtr(AkPathParams obj) { }

	// RVA: 0x1BB6BA0 Offset: 0x1BB6BA0 VA: 0x1BB6BA0 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB6BCC Offset: 0x1BB6BCC VA: 0x1BB6BCC Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB6C40 Offset: 0x1BB6C40 VA: 0x1BB6C40 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB6DC4 Offset: 0x1BB6DC4 VA: 0x1BB6DC4
	public void set_listenerPos(AkVector value) { }

	// RVA: 0x1BB6E64 Offset: 0x1BB6E64 VA: 0x1BB6E64
	public AkVector get_listenerPos() { }

	// RVA: 0x1BB6F34 Offset: 0x1BB6F34 VA: 0x1BB6F34
	public void set_emitterPos(AkVector value) { }

	// RVA: 0x1BB6FD4 Offset: 0x1BB6FD4 VA: 0x1BB6FD4
	public AkVector get_emitterPos() { }

	// RVA: 0x1BB70A4 Offset: 0x1BB70A4 VA: 0x1BB70A4
	public void set_numValidPaths(uint value) { }

	// RVA: 0x1BB7134 Offset: 0x1BB7134 VA: 0x1BB7134
	public uint get_numValidPaths() { }

	// RVA: 0x1BB71BC Offset: 0x1BB71BC VA: 0x1BB71BC
	public void .ctor() { }
}
