// Namespace: 
public struct SortedDictionary.Enumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator, IDictionaryEnumerator // TypeDefIndex: 2099
{
	// Fields
	private SortedSet.Enumerator<KeyValuePair<TKey, TValue>> _treeEnum; // 0x0
	private int _getEnumeratorRetType; // 0x0

	// Properties
	public KeyValuePair<TKey, TValue> Current { get; }
	internal bool NotStartedOrEnded { get; }
	private object System.Collections.IEnumerator.Current { get; }
	private object System.Collections.IDictionaryEnumerator.Key { get; }
	private object System.Collections.IDictionaryEnumerator.Value { get; }
	private DictionaryEntry System.Collections.IDictionaryEnumerator.Entry { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(SortedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFD5C Offset: 0x7CFD5C VA: 0x7CFD5C
	|-SortedDictionary.Enumerator<char, char>..ctor
	|
	|-RVA: 0x7CFE08 Offset: 0x7CFE08 VA: 0x7CFE08
	|-SortedDictionary.Enumerator<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFD64 Offset: 0x7CFD64 VA: 0x7CFD64
	|-SortedDictionary.Enumerator<char, char>.MoveNext
	|
	|-RVA: 0x7CFE10 Offset: 0x7CFE10 VA: 0x7CFE10
	|-SortedDictionary.Enumerator<object, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFD6C Offset: 0x7CFD6C VA: 0x7CFD6C
	|-SortedDictionary.Enumerator<char, char>.Dispose
	|
	|-RVA: 0x7CFE18 Offset: 0x7CFE18 VA: 0x7CFE18
	|-SortedDictionary.Enumerator<object, object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public KeyValuePair<TKey, TValue> get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFD90 Offset: 0x7CFD90 VA: 0x7CFD90
	|-SortedDictionary.Enumerator<char, char>.get_Current
	|
	|-RVA: 0x7CFE3C Offset: 0x7CFE3C VA: 0x7CFE3C
	|-SortedDictionary.Enumerator<object, object>.get_Current
	*/

	// RVA: -1 Offset: -1
	internal bool get_NotStartedOrEnded() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFD98 Offset: 0x7CFD98 VA: 0x7CFD98
	|-SortedDictionary.Enumerator<char, char>.get_NotStartedOrEnded
	|
	|-RVA: 0x7CFE50 Offset: 0x7CFE50 VA: 0x7CFE50
	|-SortedDictionary.Enumerator<object, object>.get_NotStartedOrEnded
	*/

	// RVA: -1 Offset: -1
	internal void Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDCC Offset: 0x7CFDCC VA: 0x7CFDCC
	|-SortedDictionary.Enumerator<char, char>.Reset
	|
	|-RVA: 0x7CFE84 Offset: 0x7CFE84 VA: 0x7CFE84
	|-SortedDictionary.Enumerator<object, object>.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDD4 Offset: 0x7CFDD4 VA: 0x7CFDD4
	|-SortedDictionary.Enumerator<char, char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFE8C Offset: 0x7CFE8C VA: 0x7CFE8C
	|-SortedDictionary.Enumerator<object, object>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDDC Offset: 0x7CFDDC VA: 0x7CFDDC
	|-SortedDictionary.Enumerator<char, char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFE94 Offset: 0x7CFE94 VA: 0x7CFE94
	|-SortedDictionary.Enumerator<object, object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IDictionaryEnumerator.get_Key() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDE4 Offset: 0x7CFDE4 VA: 0x7CFDE4
	|-SortedDictionary.Enumerator<char, char>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7CFE9C Offset: 0x7CFE9C VA: 0x7CFE9C
	|-SortedDictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Key
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private object System.Collections.IDictionaryEnumerator.get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDEC Offset: 0x7CFDEC VA: 0x7CFDEC
	|-SortedDictionary.Enumerator<char, char>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7CFEA4 Offset: 0x7CFEA4 VA: 0x7CFEA4
	|-SortedDictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Value
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private DictionaryEntry System.Collections.IDictionaryEnumerator.get_Entry() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7CFDF4 Offset: 0x7CFDF4 VA: 0x7CFDF4
	|-SortedDictionary.Enumerator<char, char>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7CFEAC Offset: 0x7CFEAC VA: 0x7CFEAC
	|-SortedDictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Entry
	*/
}
