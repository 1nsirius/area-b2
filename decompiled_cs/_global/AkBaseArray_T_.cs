// Namespace: 
[DefaultMemberAttribute] // RVA: 0x551064 Offset: 0x551064 VA: 0x551064
public abstract class AkBaseArray<T> : IDisposable // TypeDefIndex: 6009
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x55F8D0 Offset: 0x55F8D0 VA: 0x55F8D0
	private int <Capacity>k__BackingField; // 0x0
	private IntPtr m_Buffer; // 0x0

	// Properties
	public int Capacity { get; set; }
	protected abstract int StructureSize { get; }
	public T Item { get; set; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(int capacity) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682924 Offset: 0x2682924 VA: 0x2682924
	|-AkBaseArray<AkAcousticSurface>..ctor
	|-AkBaseArray<AkDiffractionPathInfo>..ctor
	|-AkBaseArray<AkExternalSourceInfo>..ctor
	|-AkBaseArray<AkObjectInfo>..ctor
	|-AkBaseArray<AkObstructionOcclusionValues>..ctor
	|-AkBaseArray<AkPropagationPathInfo>..ctor
	|-AkBaseArray<AkReflectionPathInfo>..ctor
	|-AkBaseArray<AkSourceSettings>..ctor
	|-AkBaseArray<AkTriangle>..ctor
	|-AkBaseArray<AkVertex>..ctor
	|-AkBaseArray<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682A7C Offset: 0x2682A7C VA: 0x2682A7C
	|-AkBaseArray<AkAcousticSurface>.Dispose
	|-AkBaseArray<AkDiffractionPathInfo>.Dispose
	|-AkBaseArray<AkExternalSourceInfo>.Dispose
	|-AkBaseArray<AkObjectInfo>.Dispose
	|-AkBaseArray<AkObstructionOcclusionValues>.Dispose
	|-AkBaseArray<AkPropagationPathInfo>.Dispose
	|-AkBaseArray<AkReflectionPathInfo>.Dispose
	|-AkBaseArray<AkSourceSettings>.Dispose
	|-AkBaseArray<AkTriangle>.Dispose
	|-AkBaseArray<AkVertex>.Dispose
	|-AkBaseArray<object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 1
	protected override void Finalize() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682BC0 Offset: 0x2682BC0 VA: 0x2682BC0
	|-AkBaseArray<AkAcousticSurface>.Finalize
	|-AkBaseArray<AkDiffractionPathInfo>.Finalize
	|-AkBaseArray<AkExternalSourceInfo>.Finalize
	|-AkBaseArray<AkObjectInfo>.Finalize
	|-AkBaseArray<AkObstructionOcclusionValues>.Finalize
	|-AkBaseArray<AkPropagationPathInfo>.Finalize
	|-AkBaseArray<AkReflectionPathInfo>.Finalize
	|-AkBaseArray<AkSourceSettings>.Finalize
	|-AkBaseArray<AkTriangle>.Finalize
	|-AkBaseArray<AkVertex>.Finalize
	|-AkBaseArray<object>.Finalize
	*/

	[CompilerGeneratedAttribute] // RVA: 0x57B2C4 Offset: 0x57B2C4 VA: 0x57B2C4
	// RVA: -1 Offset: -1
	public int get_Capacity() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682C70 Offset: 0x2682C70 VA: 0x2682C70
	|-AkBaseArray<object>.get_Capacity
	*/

	[CompilerGeneratedAttribute] // RVA: 0x57B2D4 Offset: 0x57B2D4 VA: 0x57B2D4
	// RVA: -1 Offset: -1
	private void set_Capacity(int value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682C78 Offset: 0x2682C78 VA: 0x2682C78
	|-AkBaseArray<object>.set_Capacity
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public virtual int Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682C80 Offset: 0x2682C80 VA: 0x2682C80
	|-AkBaseArray<AkAcousticSurface>.Count
	|-AkBaseArray<AkDiffractionPathInfo>.Count
	|-AkBaseArray<AkExternalSourceInfo>.Count
	|-AkBaseArray<AkObjectInfo>.Count
	|-AkBaseArray<AkObstructionOcclusionValues>.Count
	|-AkBaseArray<AkPropagationPathInfo>.Count
	|-AkBaseArray<AkReflectionPathInfo>.Count
	|-AkBaseArray<AkSourceSettings>.Count
	|-AkBaseArray<AkTriangle>.Count
	|-AkBaseArray<AkVertex>.Count
	|-AkBaseArray<object>.Count
	*/

	// RVA: -1 Offset: -1 Slot: 6
	protected abstract int get_StructureSize();
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-AkBaseArray<object>.get_StructureSize
	*/

	// RVA: -1 Offset: -1 Slot: 7
	protected virtual void DefaultConstructAtIntPtr(IntPtr address) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682CBC Offset: 0x2682CBC VA: 0x2682CBC
	|-AkBaseArray<AkDiffractionPathInfo>.DefaultConstructAtIntPtr
	|-AkBaseArray<AkPropagationPathInfo>.DefaultConstructAtIntPtr
	|-AkBaseArray<AkReflectionPathInfo>.DefaultConstructAtIntPtr
	|-AkBaseArray<object>.DefaultConstructAtIntPtr
	*/

	// RVA: -1 Offset: -1 Slot: 8
	protected virtual void ReleaseAllocatedMemoryFromReferenceAtIntPtr(IntPtr address) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682CC0 Offset: 0x2682CC0 VA: 0x2682CC0
	|-AkBaseArray<AkAcousticSurface>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkDiffractionPathInfo>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkObjectInfo>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkObstructionOcclusionValues>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkPropagationPathInfo>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkReflectionPathInfo>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkSourceSettings>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkTriangle>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<AkVertex>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	|-AkBaseArray<object>.ReleaseAllocatedMemoryFromReferenceAtIntPtr
	*/

	// RVA: -1 Offset: -1 Slot: 9
	protected abstract T CreateNewReferenceFromIntPtr(IntPtr address);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-AkBaseArray<object>.CreateNewReferenceFromIntPtr
	*/

	// RVA: -1 Offset: -1 Slot: 10
	protected abstract void CloneIntoReferenceFromIntPtr(IntPtr address, T other);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-AkBaseArray<object>.CloneIntoReferenceFromIntPtr
	*/

	// RVA: -1 Offset: -1
	public T get_Item(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682CC4 Offset: 0x2682CC4 VA: 0x2682CC4
	|-AkBaseArray<AkAcousticSurface>.get_Item
	|-AkBaseArray<AkTriangle>.get_Item
	|-AkBaseArray<AkVertex>.get_Item
	|-AkBaseArray<object>.get_Item
	*/

	// RVA: -1 Offset: -1
	public void set_Item(int index, T value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682D34 Offset: 0x2682D34 VA: 0x2682D34
	|-AkBaseArray<AkExternalSourceInfo>.set_Item
	|-AkBaseArray<object>.set_Item
	*/

	// RVA: -1 Offset: -1
	public IntPtr GetBuffer() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682DAC Offset: 0x2682DAC VA: 0x2682DAC
	|-AkBaseArray<AkAcousticSurface>.GetBuffer
	|-AkBaseArray<AkDiffractionPathInfo>.GetBuffer
	|-AkBaseArray<AkExternalSourceInfo>.GetBuffer
	|-AkBaseArray<AkObjectInfo>.GetBuffer
	|-AkBaseArray<AkObstructionOcclusionValues>.GetBuffer
	|-AkBaseArray<AkPropagationPathInfo>.GetBuffer
	|-AkBaseArray<AkReflectionPathInfo>.GetBuffer
	|-AkBaseArray<AkSourceSettings>.GetBuffer
	|-AkBaseArray<AkTriangle>.GetBuffer
	|-AkBaseArray<AkVertex>.GetBuffer
	|-AkBaseArray<object>.GetBuffer
	*/

	// RVA: -1 Offset: -1
	protected IntPtr GetObjectPtr(int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x2682DB4 Offset: 0x2682DB4 VA: 0x2682DB4
	|-AkBaseArray<object>.GetObjectPtr
	*/
}
