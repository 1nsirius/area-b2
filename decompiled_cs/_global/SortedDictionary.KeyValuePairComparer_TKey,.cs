// Namespace: 
[Serializable]
internal sealed class SortedDictionary.KeyValuePairComparer<TKey, TValue> : Comparer<KeyValuePair<TKey, TValue>> // TypeDefIndex: 2110
{
	// Fields
	internal IComparer<TKey> keyComparer; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(IComparer<TKey> keyComparer) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EBC34 Offset: 0x24EBC34 VA: 0x24EBC34
	|-SortedDictionary.KeyValuePairComparer<char, char>..ctor
	|
	|-RVA: 0x24EBD90 Offset: 0x24EBD90 VA: 0x24EBD90
	|-SortedDictionary.KeyValuePairComparer<object, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public override int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x24EBC98 Offset: 0x24EBC98 VA: 0x24EBC98
	|-SortedDictionary.KeyValuePairComparer<char, char>.Compare
	|
	|-RVA: 0x24EBDF4 Offset: 0x24EBDF4 VA: 0x24EBDF4
	|-SortedDictionary.KeyValuePairComparer<object, object>.Compare
	*/
}
