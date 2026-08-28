// Namespace: 
[Serializable]
public struct SortedSet.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator, ISerializable, IDeserializationCallback // TypeDefIndex: 2116
{
	// Fields
	private static readonly SortedSet.Node<T> s_dummyNode; // 0x0
	private SortedSet<T> _tree; // 0x0
	private int _version; // 0x0
	private Stack<SortedSet.Node<T>> _stack; // 0x0
	private SortedSet.Node<T> _current; // 0x0
	private bool _reverse; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }
	internal bool NotStartedOrEnded { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(SortedSet<T> set) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFF80 Offset: 0x7CFF80 VA: 0x7CFF80
	|-SortedSet.Enumerator<KeyValuePair<char, char>>..ctor
	|
	|-RVA: 0x7CFFFC Offset: 0x7CFFFC VA: 0x7CFFFC
	|-SortedSet.Enumerator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x7D0084 Offset: 0x7D0084 VA: 0x7D0084
	|-SortedSet.Enumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1
	internal void .ctor(SortedSet<T> set, bool reverse) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFF88 Offset: 0x7CFF88 VA: 0x7CFF88
	|-SortedSet.Enumerator<KeyValuePair<char, char>>..ctor
	|
	|-RVA: 0x7D0004 Offset: 0x7D0004 VA: 0x7D0004
	|-SortedSet.Enumerator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x7D008C Offset: 0x7D008C VA: 0x7D008C
	|-SortedSet.Enumerator<object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFF90 Offset: 0x7CFF90 VA: 0x7CFF90
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.System.Runtime.Serialization.ISerializable.GetObjectData
	|
	|-RVA: 0x7D000C Offset: 0x7D000C VA: 0x7D000C
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.System.Runtime.Serialization.ISerializable.GetObjectData
	|
	|-RVA: 0x7D0094 Offset: 0x7D0094 VA: 0x7D0094
	|-SortedSet.Enumerator<object>.System.Runtime.Serialization.ISerializable.GetObjectData
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFA4 Offset: 0x7CFFA4 VA: 0x7CFFA4
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	|
	|-RVA: 0x7D0020 Offset: 0x7D0020 VA: 0x7D0020
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	|
	|-RVA: 0x7D00A8 Offset: 0x7D00A8 VA: 0x7D00A8
	|-SortedSet.Enumerator<object>.System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
	*/

	// RVA: -1 Offset: -1
	private void Initialize() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFB4 Offset: 0x7CFFB4 VA: 0x7CFFB4
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.Initialize
	|
	|-RVA: 0x7D0030 Offset: 0x7D0030 VA: 0x7D0030
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.Initialize
	|
	|-RVA: 0x7D00B8 Offset: 0x7D00B8 VA: 0x7D00B8
	|-SortedSet.Enumerator<object>.Initialize
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFBC Offset: 0x7CFFBC VA: 0x7CFFBC
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.MoveNext
	|
	|-RVA: 0x7D0038 Offset: 0x7D0038 VA: 0x7D0038
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x7D00C0 Offset: 0x7D00C0 VA: 0x7D00C0
	|-SortedSet.Enumerator<object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFC4 Offset: 0x7CFFC4 VA: 0x7CFFC4
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.Dispose
	|
	|-RVA: 0x7D0040 Offset: 0x7D0040 VA: 0x7D0040
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.Dispose
	|
	|-RVA: 0x7D00C8 Offset: 0x7D00C8 VA: 0x7D00C8
	|-SortedSet.Enumerator<object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFC8 Offset: 0x7CFFC8 VA: 0x7CFFC8
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.get_Current
	|
	|-RVA: 0x7D0044 Offset: 0x7D0044 VA: 0x7D0044
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.get_Current
	|
	|-RVA: 0x7D00CC Offset: 0x7D00CC VA: 0x7D00CC
	|-SortedSet.Enumerator<object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFD0 Offset: 0x7CFFD0 VA: 0x7CFFD0
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7D0058 Offset: 0x7D0058 VA: 0x7D0058
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7D00D4 Offset: 0x7D00D4 VA: 0x7D00D4
	|-SortedSet.Enumerator<object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1
	internal bool get_NotStartedOrEnded() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFD8 Offset: 0x7CFFD8 VA: 0x7CFFD8
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.get_NotStartedOrEnded
	|
	|-RVA: 0x7D0060 Offset: 0x7D0060 VA: 0x7D0060
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.get_NotStartedOrEnded
	|
	|-RVA: 0x7D00DC Offset: 0x7D00DC VA: 0x7D00DC
	|-SortedSet.Enumerator<object>.get_NotStartedOrEnded
	*/

	// RVA: -1 Offset: -1
	internal void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFEC Offset: 0x7CFFEC VA: 0x7CFFEC
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.Reset
	|
	|-RVA: 0x7D0074 Offset: 0x7D0074 VA: 0x7D0074
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.Reset
	|
	|-RVA: 0x7D00F0 Offset: 0x7D00F0 VA: 0x7D00F0
	|-SortedSet.Enumerator<object>.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFFF4 Offset: 0x7CFFF4 VA: 0x7CFFF4
	|-SortedSet.Enumerator<KeyValuePair<char, char>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7D007C Offset: 0x7D007C VA: 0x7D007C
	|-SortedSet.Enumerator<KeyValuePair<object, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7D00F8 Offset: 0x7D00F8 VA: 0x7D00F8
	|-SortedSet.Enumerator<object>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1
	private static void .cctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24F3CA8 Offset: 0x24F3CA8 VA: 0x24F3CA8
	|-SortedSet.Enumerator<KeyValuePair<char, char>>..cctor
	|
	|-RVA: 0x24F4CA0 Offset: 0x24F4CA0 VA: 0x24F4CA0
	|-SortedSet.Enumerator<KeyValuePair<object, object>>..cctor
	|
	|-RVA: 0x24F5C44 Offset: 0x24F5C44 VA: 0x24F5C44
	|-SortedSet.Enumerator<object>..cctor
	*/
}
