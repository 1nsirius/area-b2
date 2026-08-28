// Namespace: 
internal struct IJobExtensions.JobStruct<T> // TypeDefIndex: 3564
{
	// Fields
	public static IntPtr jobReflectionData; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x4FA17C Offset: 0x4FA17C VA: 0x4FA17C
	private static IJobExtensions.JobStruct.ExecuteJobFunction<T> <>f__mg$cache0; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public static IntPtr Initialize() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2244FFC Offset: 0x2244FFC VA: 0x2244FFC
	|-IJobExtensions.JobStruct<DrawBoundRayJobs.RayIntersectionListJob>.Initialize
	|
	|-RVA: 0x2245314 Offset: 0x2245314 VA: 0x2245314
	|-IJobExtensions.JobStruct<GeometryDataJob_Parallel>.Initialize
	*/

	// RVA: -1 Offset: -1
	public static void Execute(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x224530C Offset: 0x224530C VA: 0x224530C
	|-IJobExtensions.JobStruct<DrawBoundRayJobs.RayIntersectionListJob>.Execute
	|
	|-RVA: 0x2245624 Offset: 0x2245624 VA: 0x2245624
	|-IJobExtensions.JobStruct<GeometryDataJob_Parallel>.Execute
	*/
}
