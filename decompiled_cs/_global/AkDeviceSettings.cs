// Namespace: 
public class AkDeviceSettings : IDisposable // TypeDefIndex: 5894
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public IntPtr pIOMemory { get; set; }
	public uint uIOMemorySize { get; set; }
	public uint uIOMemoryAlignment { get; set; }
	public int ePoolAttributes { get; set; }
	public uint uGranularity { get; set; }
	public uint uSchedulerTypeFlags { get; set; }
	public AkThreadProperties threadProperties { get; set; }
	public float fTargetAutoStmBufferLength { get; set; }
	public uint uMaxConcurrentIO { get; set; }
	public bool bUseStreamCache { get; set; }
	public uint uMaxCachePinnedBytes { get; set; }

	// Methods

	// RVA: 0xFE7340 Offset: 0xFE7340 VA: 0xFE7340
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFE7368 Offset: 0xFE7368 VA: 0xFE7368
	internal static IntPtr getCPtr(AkDeviceSettings obj) { }

	// RVA: 0xFE73C0 Offset: 0xFE73C0 VA: 0xFE73C0 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE73EC Offset: 0xFE73EC VA: 0xFE73EC Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE7460 Offset: 0xFE7460 VA: 0xFE7460 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFE75E4 Offset: 0xFE75E4 VA: 0xFE75E4
	public void set_pIOMemory(IntPtr value) { }

	// RVA: 0xFE7674 Offset: 0xFE7674 VA: 0xFE7674
	public IntPtr get_pIOMemory() { }

	// RVA: 0xFE56F0 Offset: 0xFE56F0 VA: 0xFE56F0
	public void set_uIOMemorySize(uint value) { }

	// RVA: 0xFE76FC Offset: 0xFE76FC VA: 0xFE76FC
	public uint get_uIOMemorySize() { }

	// RVA: 0xFE7784 Offset: 0xFE7784 VA: 0xFE7784
	public void set_uIOMemoryAlignment(uint value) { }

	// RVA: 0xFE7814 Offset: 0xFE7814 VA: 0xFE7814
	public uint get_uIOMemoryAlignment() { }

	// RVA: 0xFE789C Offset: 0xFE789C VA: 0xFE789C
	public void set_ePoolAttributes(int value) { }

	// RVA: 0xFE792C Offset: 0xFE792C VA: 0xFE792C
	public int get_ePoolAttributes() { }

	// RVA: 0xFE79B4 Offset: 0xFE79B4 VA: 0xFE79B4
	public void set_uGranularity(uint value) { }

	// RVA: 0xFE7A44 Offset: 0xFE7A44 VA: 0xFE7A44
	public uint get_uGranularity() { }

	// RVA: 0xFE7ACC Offset: 0xFE7ACC VA: 0xFE7ACC
	public void set_uSchedulerTypeFlags(uint value) { }

	// RVA: 0xFE7B5C Offset: 0xFE7B5C VA: 0xFE7B5C
	public uint get_uSchedulerTypeFlags() { }

	// RVA: 0xFE7BE4 Offset: 0xFE7BE4 VA: 0xFE7BE4
	public void set_threadProperties(AkThreadProperties value) { }

	// RVA: 0xFE7C84 Offset: 0xFE7C84 VA: 0xFE7C84
	public AkThreadProperties get_threadProperties() { }

	// RVA: 0xFE5780 Offset: 0xFE5780 VA: 0xFE5780
	public void set_fTargetAutoStmBufferLength(float value) { }

	// RVA: 0xFE7D54 Offset: 0xFE7D54 VA: 0xFE7D54
	public float get_fTargetAutoStmBufferLength() { }

	// RVA: 0xFE7DDC Offset: 0xFE7DDC VA: 0xFE7DDC
	public void set_uMaxConcurrentIO(uint value) { }

	// RVA: 0xFE7E6C Offset: 0xFE7E6C VA: 0xFE7E6C
	public uint get_uMaxConcurrentIO() { }

	// RVA: 0xFE5810 Offset: 0xFE5810 VA: 0xFE5810
	public void set_bUseStreamCache(bool value) { }

	// RVA: 0xFE7EF4 Offset: 0xFE7EF4 VA: 0xFE7EF4
	public bool get_bUseStreamCache() { }

	// RVA: 0xFE58A0 Offset: 0xFE58A0 VA: 0xFE58A0
	public void set_uMaxCachePinnedBytes(uint value) { }

	// RVA: 0xFE7F7C Offset: 0xFE7F7C VA: 0xFE7F7C
	public uint get_uMaxCachePinnedBytes() { }

	// RVA: 0xFE8004 Offset: 0xFE8004 VA: 0xFE8004
	public void .ctor() { }
}
