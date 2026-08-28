// Namespace: 
private struct DrawBoundRayJobs.RayIntersectionJob : IJobParallelFor // TypeDefIndex: 7389
{
	// Fields
	[ReadOnlyAttribute] // RVA: 0x56DD7C Offset: 0x56DD7C VA: 0x56DD7C
	public NativeArray<Bounds> boundsArray; // 0x0
	[ReadOnlyAttribute] // RVA: 0x56DD8C Offset: 0x56DD8C VA: 0x56DD8C
	public NativeArray<Bounds> boundsTpArray; // 0xC
	[ReadOnlyAttribute] // RVA: 0x56DD9C Offset: 0x56DD9C VA: 0x56DD9C
	public NativeArray<Bounds> boundsRigArray; // 0x18
	[WriteOnlyAttribute] // RVA: 0x56DDAC Offset: 0x56DDAC VA: 0x56DDAC
	public NativeArray<int> intersectList; // 0x24
	[WriteOnlyAttribute] // RVA: 0x56DDBC Offset: 0x56DDBC VA: 0x56DDBC
	public NativeArray<int> intersectTpList; // 0x30
	[WriteOnlyAttribute] // RVA: 0x56DDCC Offset: 0x56DDCC VA: 0x56DDCC
	public NativeArray<int> intersectRigList; // 0x3C
	[ReadOnlyAttribute] // RVA: 0x56DDDC Offset: 0x56DDDC VA: 0x56DDDC
	public int tpCount; // 0x48
	[ReadOnlyAttribute] // RVA: 0x56DDEC Offset: 0x56DDEC VA: 0x56DDEC
	public int rigCount; // 0x4C
	[ReadOnlyAttribute] // RVA: 0x56DDFC Offset: 0x56DDFC VA: 0x56DDFC
	public int raysCount; // 0x50
	[ReadOnlyAttribute] // RVA: 0x56DE0C Offset: 0x56DE0C VA: 0x56DE0C
	public NativeArray<Ray> raysArray; // 0x54
	[ReadOnlyAttribute] // RVA: 0x56DE1C Offset: 0x56DE1C VA: 0x56DE1C
	public NativeArray<float> raysDistList; // 0x60

	// Methods

	// RVA: 0x746F70 Offset: 0x746F70 VA: 0x746F70 Slot: 4
	public void Execute(int i) { }
}
