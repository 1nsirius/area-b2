// Namespace: 
private class IllegalWordsSearchEx.TrieNode // TypeDefIndex: 9716
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x56DEDC Offset: 0x56DEDC VA: 0x56DEDC
	private bool <End>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x56DEEC Offset: 0x56DEEC VA: 0x56DEEC
	private List<string> <Results>k__BackingField; // 0xC
	private Dictionary<char, IllegalWordsSearchEx.TrieNode> m_values; // 0x10
	private uint minflag; // 0x14
	private uint maxflag; // 0x18
	[CompilerGeneratedAttribute] // RVA: 0x56DEFC Offset: 0x56DEFC VA: 0x56DEFC
	private bool <IsRepeat>k__BackingField; // 0x1C
	[CompilerGeneratedAttribute] // RVA: 0x56DF0C Offset: 0x56DF0C VA: 0x56DF0C
	private IllegalWordsSearchEx.TrieNode <Parent>k__BackingField; // 0x20
	[CompilerGeneratedAttribute] // RVA: 0x56DF1C Offset: 0x56DF1C VA: 0x56DF1C
	private int <LastMatchLocation>k__BackingField; // 0x24

	// Properties
	public bool End { get; set; }
	public List<string> Results { get; set; }
	public bool IsRepeat { get; set; }
	public IllegalWordsSearchEx.TrieNode Parent { get; set; }
	public int LastMatchLocation { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x65C850 Offset: 0x65C850 VA: 0x65C850
	// RVA: 0xF1D2A8 Offset: 0xF1D2A8 VA: 0xF1D2A8
	public bool get_End() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C860 Offset: 0x65C860 VA: 0x65C860
	// RVA: 0xF1D2B0 Offset: 0xF1D2B0 VA: 0xF1D2B0
	public void set_End(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65C870 Offset: 0x65C870 VA: 0x65C870
	// RVA: 0xF1D2B8 Offset: 0xF1D2B8 VA: 0xF1D2B8
	public List<string> get_Results() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C880 Offset: 0x65C880 VA: 0x65C880
	// RVA: 0xF1D2C0 Offset: 0xF1D2C0 VA: 0xF1D2C0
	public void set_Results(List<string> value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65C890 Offset: 0x65C890 VA: 0x65C890
	// RVA: 0xF1D2C8 Offset: 0xF1D2C8 VA: 0xF1D2C8
	public bool get_IsRepeat() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C8A0 Offset: 0x65C8A0 VA: 0x65C8A0
	// RVA: 0xF1D2D0 Offset: 0xF1D2D0 VA: 0xF1D2D0
	public void set_IsRepeat(bool value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65C8B0 Offset: 0x65C8B0 VA: 0x65C8B0
	// RVA: 0xF1D2D8 Offset: 0xF1D2D8 VA: 0xF1D2D8
	public IllegalWordsSearchEx.TrieNode get_Parent() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C8C0 Offset: 0x65C8C0 VA: 0x65C8C0
	// RVA: 0xF1D2E0 Offset: 0xF1D2E0 VA: 0xF1D2E0
	public void set_Parent(IllegalWordsSearchEx.TrieNode value) { }

	[CompilerGeneratedAttribute] // RVA: 0x65C8D0 Offset: 0x65C8D0 VA: 0x65C8D0
	// RVA: 0xF1D2E8 Offset: 0xF1D2E8 VA: 0xF1D2E8
	public int get_LastMatchLocation() { }

	[CompilerGeneratedAttribute] // RVA: 0x65C8E0 Offset: 0x65C8E0 VA: 0x65C8E0
	// RVA: 0xF1D2F0 Offset: 0xF1D2F0 VA: 0xF1D2F0
	public void set_LastMatchLocation(int value) { }

	// RVA: 0xF1D2F8 Offset: 0xF1D2F8 VA: 0xF1D2F8
	public void .ctor() { }

	// RVA: 0xF1D3C0 Offset: 0xF1D3C0 VA: 0xF1D3C0
	public bool TryGetValue(char c, out IllegalWordsSearchEx.TrieNode node) { }

	// RVA: 0xF1D470 Offset: 0xF1D470 VA: 0xF1D470
	public void Add(IllegalWordsSearchEx.TreeNode t, IllegalWordsSearchEx.TrieNode node) { }

	// RVA: 0xF1D6F8 Offset: 0xF1D6F8 VA: 0xF1D6F8
	public IllegalWordsSearchEx.TrieNode GetParent(int pNum) { }

	// RVA: 0xF1D734 Offset: 0xF1D734 VA: 0xF1D734
	public IllegalWordsSearchEx.TrieNode[] ToArray() { }
}
