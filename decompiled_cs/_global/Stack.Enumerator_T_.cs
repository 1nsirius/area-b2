// Namespace: 
[Serializable]
public struct Stack.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 2124
{
	// Fields
	private readonly Stack<T> _stack; // 0x0
	private readonly int _version; // 0x0
	private int _index; // 0x0
	private T _currentElement; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Stack<T> stack) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CB70 Offset: 0x80CB70 VA: 0x80CB70
	|-Stack.Enumerator<int>..ctor
	|
	|-RVA: 0x80CBF0 Offset: 0x80CBF0 VA: 0x80CBF0
	|-Stack.Enumerator<Int32Enum>..ctor
	|
	|-RVA: 0x80CC70 Offset: 0x80CC70 VA: 0x80CC70
	|-Stack.Enumerator<object>..ctor
	|
	|-RVA: 0x80CCF0 Offset: 0x80CCF0 VA: 0x80CCF0
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CCB0 Offset: 0x80CCB0 VA: 0x80CCB0
	|-Stack.Enumerator<IEnumerator>.Dispose
	|-Stack.Enumerator<object>.Dispose
	|-Stack.Enumerator<SimpleKey>.Dispose
	|
	|-RVA: 0x80CBB0 Offset: 0x80CBB0 VA: 0x80CBB0
	|-Stack.Enumerator<int>.Dispose
	|
	|-RVA: 0x80CC30 Offset: 0x80CC30 VA: 0x80CC30
	|-Stack.Enumerator<Int32Enum>.Dispose
	|
	|-RVA: 0x80CD3C Offset: 0x80CD3C VA: 0x80CD3C
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CCBC Offset: 0x80CCBC VA: 0x80CCBC
	|-Stack.Enumerator<IEnumerator>.MoveNext
	|-Stack.Enumerator<object>.MoveNext
	|-Stack.Enumerator<SimpleKey>.MoveNext
	|
	|-RVA: 0x80CBBC Offset: 0x80CBBC VA: 0x80CBBC
	|-Stack.Enumerator<int>.MoveNext
	|
	|-RVA: 0x80CC3C Offset: 0x80CC3C VA: 0x80CC3C
	|-Stack.Enumerator<Int32Enum>.MoveNext
	|
	|-RVA: 0x80CD48 Offset: 0x80CD48 VA: 0x80CD48
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CCC4 Offset: 0x80CCC4 VA: 0x80CCC4
	|-Stack.Enumerator<IEnumerator>.get_Current
	|-Stack.Enumerator<SimpleKey>.get_Current
	|-Stack.Enumerator<object>.get_Current
	|
	|-RVA: 0x80CBC4 Offset: 0x80CBC4 VA: 0x80CBC4
	|-Stack.Enumerator<int>.get_Current
	|
	|-RVA: 0x80CC44 Offset: 0x80CC44 VA: 0x80CC44
	|-Stack.Enumerator<Int32Enum>.get_Current
	|
	|-RVA: 0x80CD50 Offset: 0x80CD50 VA: 0x80CD50
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.get_Current
	*/

	// RVA: -1 Offset: -1
	private void ThrowEnumerationNotStartedOrEnded() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CBCC Offset: 0x80CBCC VA: 0x80CBCC
	|-Stack.Enumerator<int>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x80CC4C Offset: 0x80CC4C VA: 0x80CC4C
	|-Stack.Enumerator<Int32Enum>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x80CCCC Offset: 0x80CCCC VA: 0x80CCCC
	|-Stack.Enumerator<object>.ThrowEnumerationNotStartedOrEnded
	|
	|-RVA: 0x80CD64 Offset: 0x80CD64 VA: 0x80CD64
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.ThrowEnumerationNotStartedOrEnded
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CBE0 Offset: 0x80CBE0 VA: 0x80CBE0
	|-Stack.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CC60 Offset: 0x80CC60 VA: 0x80CC60
	|-Stack.Enumerator<Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CCE0 Offset: 0x80CCE0 VA: 0x80CCE0
	|-Stack.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x80CD78 Offset: 0x80CD78 VA: 0x80CD78
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x80CBE8 Offset: 0x80CBE8 VA: 0x80CBE8
	|-Stack.Enumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CC68 Offset: 0x80CC68 VA: 0x80CC68
	|-Stack.Enumerator<Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CCE8 Offset: 0x80CCE8 VA: 0x80CCE8
	|-Stack.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x80CD80 Offset: 0x80CD80 VA: 0x80CD80
	|-Stack.Enumerator<SequenceNode.SequenceConstructPosContext>.System.Collections.IEnumerator.Reset
	*/
}
