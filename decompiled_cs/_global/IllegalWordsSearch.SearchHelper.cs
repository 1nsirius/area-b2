// Namespace: 
private class IllegalWordsSearch.SearchHelper : IDisposable // TypeDefIndex: 9711
{
	// Fields
	private IllegalWordsSearch.NodeInfo mainNode; // 0x8
	private List<IllegalWordsSearch.NodeInfo> nodes; // 0xC
	private TrieNode[] _first; // 0x10
	private int _jumpLength; // 0x14

	// Methods

	// RVA: 0x115C734 Offset: 0x115C734 VA: 0x115C734
	public void .ctor(ref TrieNode[] first, int jumpLength) { }

	// RVA: 0x115E958 Offset: 0x115E958 VA: 0x115E958 Slot: 4
	public void Dispose() { }

	// RVA: 0x115C7D4 Offset: 0x115C7D4 VA: 0x115C7D4
	public bool FindChar(char c, int index) { }

	// RVA: 0x115CC78 Offset: 0x115CC78 VA: 0x115CC78
	public List<StringTuple> GetKeywords() { }
}
