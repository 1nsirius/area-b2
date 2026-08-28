// Namespace: 
public sealed class IJobExtensions.JobStruct.ExecuteJobFunction<T> : MulticastDelegate // TypeDefIndex: 3565
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2244414 Offset: 0x2244414 VA: 0x2244414
	|-IJobExtensions.JobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionListJob>..ctor
	|
	|-RVA: 0x2244A08 Offset: 0x2244A08 VA: 0x2244A08
	|-IJobExtensions.JobStruct.ExecuteJobFunction<GeometryDataJob_Parallel>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual void Invoke(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2244428 Offset: 0x2244428 VA: 0x2244428
	|-IJobExtensions.JobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionListJob>.Invoke
	|
	|-RVA: 0x2244A1C Offset: 0x2244A1C VA: 0x2244A1C
	|-IJobExtensions.JobStruct.ExecuteJobFunction<GeometryDataJob_Parallel>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x22448D0 Offset: 0x22448D0 VA: 0x22448D0
	|-IJobExtensions.JobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionListJob>.BeginInvoke
	|
	|-RVA: 0x2244EC4 Offset: 0x2244EC4 VA: 0x2244EC4
	|-IJobExtensions.JobStruct.ExecuteJobFunction<GeometryDataJob_Parallel>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual void EndInvoke(ref T data, ref JobRanges ranges, IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x22449E8 Offset: 0x22449E8 VA: 0x22449E8
	|-IJobExtensions.JobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionListJob>.EndInvoke
	|
	|-RVA: 0x2244FDC Offset: 0x2244FDC VA: 0x2244FDC
	|-IJobExtensions.JobStruct.ExecuteJobFunction<GeometryDataJob_Parallel>.EndInvoke
	*/
}
