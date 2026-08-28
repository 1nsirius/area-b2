// Namespace: 
private class WordsSearch.TrieNode // TypeDefIndex: 9727
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56DF2C Offset: 0x56DF2C VA: 0x56DF2C
	private bool <End>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56DF3C Offset: 0x56DF3C VA: 0x56DF3C
	private List<WordsSearch.WordsSearchTuple> <Results>k__BackingField; // 0xC
	internal Dictionary<char, WordsSearch.TrieNode> m_values; // 0x10
	private uint minflag; // 0x14
	private uint maxflag; // 0x18

	// Properties
	public bool End { get; set; }
	public List<WordsSearch.WordsSearchTuple> Results { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65C8F0 Offset: 0x65C8F0 VA: 0x65C8F0
	// RVA: 0xF381EC Offset: 0xF381EC VA: 0xF381EC
	public bool get_End() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C900 Offset: 0x65C900 VA: 0x65C900
	// RVA: 0xF38B68 Offset: 0xF38B68 VA: 0xF38B68
	public void set_End(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65C910 Offset: 0x65C910 VA: 0x65C910
	// RVA: 0xF38400 Offset: 0xF38400 VA: 0xF38400
	public List<WordsSearch.WordsSearchTuple> get_Results() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C920 Offset: 0x65C920 VA: 0x65C920
	// RVA: 0xF38B70 Offset: 0xF38B70 VA: 0xF38B70
	public void set_Results(List<WordsSearch.WordsSearchTuple> value) { }

	// RVA: 0xF3756C Offset: 0xF3756C VA: 0xF3756C
	public void .ctor() { }

	// RVA: 0xF38030 Offset: 0xF38030 VA: 0xF38030
	public bool TryGetValue(char c, out WordsSearch.TrieNode node) { }

	// RVA: 0xF37634 Offset: 0xF37634 VA: 0xF37634
	public WordsSearch.TrieNode Add(char c) { }

	// RVA: 0xF37740 Offset: 0xF37740 VA: 0xF37740
	public void SetResults(string text, int index) { }

	// RVA: 0xF37B5C Offset: 0xF37B5C VA: 0xF37B5C
	public void Merge(WordsSearch.TrieNode node) { }
}
