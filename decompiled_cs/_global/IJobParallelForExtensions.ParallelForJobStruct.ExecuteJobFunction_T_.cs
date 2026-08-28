// Namespace: 
public sealed class IJobParallelForExtensions.ParallelForJobStruct.ExecuteJobFunction<T> : MulticastDelegate // TypeDefIndex: 3569
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x224562C Offset: 0x224562C VA: 0x224562C
	|-IJobParallelForExtensions.ParallelForJobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionJob>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual void Invoke(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2245640 Offset: 0x2245640 VA: 0x2245640
	|-IJobParallelForExtensions.ParallelForJobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionJob>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2245AE8 Offset: 0x2245AE8 VA: 0x2245AE8
	|-IJobParallelForExtensions.ParallelForJobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionJob>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual void EndInvoke(ref T data, ref JobRanges ranges, IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2245C00 Offset: 0x2245C00 VA: 0x2245C00
	|-IJobParallelForExtensions.ParallelForJobStruct.ExecuteJobFunction<DrawBoundRayJobs.RayIntersectionJob>.EndInvoke
	*/
}
