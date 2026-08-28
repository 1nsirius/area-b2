// Namespace: 
[Serializable]
private class ReadOnlyCollectionBuilder.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 2972
{
	// Fields
	private readonly ReadOnlyCollectionBuilder<T> _builder; // 0x0
	private readonly int _version; // 0x0
	private int _index; // 0x0
	private T _current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(ReadOnlyCollectionBuilder<T> builder) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209FE40 Offset: 0x209FE40 VA: 0x209FE40
	|-ReadOnlyCollectionBuilder.Enumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209FE98 Offset: 0x209FE98 VA: 0x209FE98
	|-ReadOnlyCollectionBuilder.Enumerator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209FEA0 Offset: 0x209FEA0 VA: 0x209FEA0
	|-ReadOnlyCollectionBuilder.Enumerator<object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209FEA4 Offset: 0x209FEA4 VA: 0x209FEA4
	|-ReadOnlyCollectionBuilder.Enumerator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x209FF44 Offset: 0x209FF44 VA: 0x209FF44
	|-ReadOnlyCollectionBuilder.Enumerator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x20A008C Offset: 0x20A008C VA: 0x20A008C
	|-ReadOnlyCollectionBuilder.Enumerator<object>.System.Collections.IEnumerator.Reset
	*/
}
