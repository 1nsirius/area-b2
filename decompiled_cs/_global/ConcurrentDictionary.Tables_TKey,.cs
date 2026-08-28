// Namespace: 
private sealed class ConcurrentDictionary.Tables<TKey, TValue> // TypeDefIndex: 1403
{
	// Fields
	internal readonly ConcurrentDictionary.Node<TKey, TValue>[] _buckets; // 0x0
	internal readonly object[] _locks; // 0x0
	internal int[] _countPerLock; // 0x0

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(ConcurrentDictionary.Node<TKey, TValue>[] buckets, object[] locks, int[] countPerLock) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1459904 Offset: 0x1459904 VA: 0x1459904
	|-ConcurrentDictionary.Tables<object, object>..ctor
	*/
}
