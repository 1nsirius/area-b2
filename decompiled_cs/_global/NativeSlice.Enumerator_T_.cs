// Namespace: 
[ExcludeFromDocsAttribute] // RVA: 0x4F73FC Offset: 0x4F73FC VA: 0x4F73FC
public struct NativeSlice.Enumerator<T> : IEnumerator<T>, IEnumerator, IDisposable // TypeDefIndex: 3522
{
	// Fields
	private NativeSlice<T> m_Array; // 0x0
	private int m_Index; // 0x0

	// Properties
	private object System.Collections.IEnumerator.Current { get; }
	public T Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(ref NativeSlice<T> array) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B0098 Offset: 0x7B0098 VA: 0x7B0098
	|-NativeSlice.Enumerator<int>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B00B8 Offset: 0x7B00B8 VA: 0x7B00B8
	|-NativeSlice.Enumerator<int>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B00BC Offset: 0x7B00BC VA: 0x7B00BC
	|-NativeSlice.Enumerator<int>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 8
	public void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B00FC Offset: 0x7B00FC VA: 0x7B00FC
	|-NativeSlice.Enumerator<int>.Reset
	*/

	[CompilerGeneratedAttribute] // RVA: 0x5064E8 Offset: 0x5064E8 VA: 0x5064E8
	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B0108 Offset: 0x7B0108 VA: 0x7B0108
	|-NativeSlice.Enumerator<int>.get_Current
	*/

	[CompilerGeneratedAttribute] // RVA: 0x5064F8 Offset: 0x5064F8 VA: 0x5064F8
	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7B0110 Offset: 0x7B0110 VA: 0x7B0110
	|-NativeSlice.Enumerator<int>.System.Collections.IEnumerator.get_Current
	*/
}
