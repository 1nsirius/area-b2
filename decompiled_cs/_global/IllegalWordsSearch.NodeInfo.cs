// Namespace: 
private class IllegalWordsSearch.NodeInfo // TypeDefIndex: 9710
{
	// Fields
	public int Index; // 0x8
	public bool End; // 0xC
	public IllegalWordsSearch.NodeInfo Parent; // 0x10
	public TrieNode Node; // 0x14
	public char Type; // 0x18

	// Methods

	// RVA: 0x115E724 Offset: 0x115E724 VA: 0x115E724
	public bool TryGetValue(char c, out TrieNode node) { }

	// RVA: 0x115E760 Offset: 0x115E760 VA: 0x115E760
	public bool CanJump(char c, int index, int jump) { }

	// RVA: 0x115E860 Offset: 0x115E860 VA: 0x115E860
	public void .ctor(int index, char c, TrieNode node, IllegalWordsSearch.NodeInfo parent) { }
}
