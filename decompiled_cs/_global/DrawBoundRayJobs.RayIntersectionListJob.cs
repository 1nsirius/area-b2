// Namespace: 
private struct DrawBoundRayJobs.RayIntersectionListJob : IJob // TypeDefIndex: 7390
{
	// Fields
	[ReadOnlyAttribute] // RVA: 0x56DE2C Offset: 0x56DE2C VA: 0x56DE2C
	public NativeArray<int> boundsIntersected; // 0x0
	[ReadOnlyAttribute] // RVA: 0x56DE3C Offset: 0x56DE3C VA: 0x56DE3C
	public NativeArray<int> boundsRigIntersected; // 0xC
	[WriteOnlyAttribute] // RVA: 0x56DE4C Offset: 0x56DE4C VA: 0x56DE4C
	public NativeArray<int> results; // 0x18
	[WriteOnlyAttribute] // RVA: 0x56DE5C Offset: 0x56DE5C VA: 0x56DE5C
	public NativeArray<int> resultsRig; // 0x24

	// Methods

	// RVA: 0x746FD4 Offset: 0x746FD4 VA: 0x746FD4 Slot: 4
	public void Execute() { }
}
