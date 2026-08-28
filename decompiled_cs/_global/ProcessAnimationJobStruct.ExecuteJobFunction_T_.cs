// Namespace: 
public sealed class ProcessAnimationJobStruct.ExecuteJobFunction<T> : MulticastDelegate // TypeDefIndex: 3784
{
	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(object object, IntPtr method) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CFF650 Offset: 0x1CFF650 VA: 0x1CFF650
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKHumanJob>..ctor
	|
	|-RVA: 0x1CFFC44 Offset: 0x1CFFC44 VA: 0x1CFFC44
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKTwoBoneJob>..ctor
	|
	|-RVA: 0x1D00238 Offset: 0x1D00238 VA: 0x1D00238
	|-ProcessAnimationJobStruct.ExecuteJobFunction<LookAtJob>..ctor
	|
	|-RVA: 0x1D0082C Offset: 0x1D0082C VA: 0x1D0082C
	|-ProcessAnimationJobStruct.ExecuteJobFunction<RagdollJob>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public virtual void Invoke(ref T data, IntPtr animationStreamPtr, IntPtr unusedPtr, ref JobRanges ranges, int jobIndex) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CFF664 Offset: 0x1CFF664 VA: 0x1CFF664
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKHumanJob>.Invoke
	|
	|-RVA: 0x1CFFC58 Offset: 0x1CFFC58 VA: 0x1CFFC58
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKTwoBoneJob>.Invoke
	|
	|-RVA: 0x1D0024C Offset: 0x1D0024C VA: 0x1D0024C
	|-ProcessAnimationJobStruct.ExecuteJobFunction<LookAtJob>.Invoke
	|
	|-RVA: 0x1D00840 Offset: 0x1D00840 VA: 0x1D00840
	|-ProcessAnimationJobStruct.ExecuteJobFunction<RagdollJob>.Invoke
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual IAsyncResult BeginInvoke(ref T data, IntPtr animationStreamPtr, IntPtr unusedPtr, ref JobRanges ranges, int jobIndex, AsyncCallback callback, object object) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CFFB0C Offset: 0x1CFFB0C VA: 0x1CFFB0C
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKHumanJob>.BeginInvoke
	|
	|-RVA: 0x1D00100 Offset: 0x1D00100 VA: 0x1D00100
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKTwoBoneJob>.BeginInvoke
	|
	|-RVA: 0x1D006F4 Offset: 0x1D006F4 VA: 0x1D006F4
	|-ProcessAnimationJobStruct.ExecuteJobFunction<LookAtJob>.BeginInvoke
	|
	|-RVA: 0x1D00CE8 Offset: 0x1D00CE8 VA: 0x1D00CE8
	|-ProcessAnimationJobStruct.ExecuteJobFunction<RagdollJob>.BeginInvoke
	*/

	// RVA: -1 Offset: -1 Slot: 14
	public virtual void EndInvoke(ref T data, ref JobRanges ranges, IAsyncResult result) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1CFFC24 Offset: 0x1CFFC24 VA: 0x1CFFC24
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKHumanJob>.EndInvoke
	|
	|-RVA: 0x1D00218 Offset: 0x1D00218 VA: 0x1D00218
	|-ProcessAnimationJobStruct.ExecuteJobFunction<IKTwoBoneJob>.EndInvoke
	|
	|-RVA: 0x1D0080C Offset: 0x1D0080C VA: 0x1D0080C
	|-ProcessAnimationJobStruct.ExecuteJobFunction<LookAtJob>.EndInvoke
	|
	|-RVA: 0x1D00E00 Offset: 0x1D00E00 VA: 0x1D00E00
	|-ProcessAnimationJobStruct.ExecuteJobFunction<RagdollJob>.EndInvoke
	*/
}
