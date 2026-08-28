// Namespace: 
private class IllegalWordsSearchEx.TreeNode // TypeDefIndex: 9715
{
	// Fields
	private char _char; // 0x8
	private IllegalWordsSearchEx.TreeNode _parent; // 0xC
	private IllegalWordsSearchEx.TreeNode _failure; // 0x10
	private List<string> _results; // 0x14
	private List<IllegalWordsSearchEx.TreeNode> _transitionsAr; // 0x18
	private Dictionary<char, IllegalWordsSearchEx.TreeNode> _transHash; // 0x1C

	// Properties
	public char Char { get; }
	public IllegalWordsSearchEx.TreeNode Parent { get; }
	public IllegalWordsSearchEx.TreeNode Failure { get; set; }
	public List<IllegalWordsSearchEx.TreeNode> Transitions { get; }
	public List<string> Results { get; }

	// Methods

	// RVA: 0xF1CDD0 Offset: 0xF1CDD0 VA: 0xF1CDD0
	public void .ctor(IllegalWordsSearchEx.TreeNode parent, char c) { }

	// RVA: 0xF1CED4 Offset: 0xF1CED4 VA: 0xF1CED4
	public void AddResult(string result) { }

	// RVA: 0xF1CF8C Offset: 0xF1CF8C VA: 0xF1CF8C
	public void AddTransition(IllegalWordsSearchEx.TreeNode node) { }

	// RVA: 0xF1D05C Offset: 0xF1D05C VA: 0xF1D05C
	public IllegalWordsSearchEx.TreeNode GetTransition(char c) { }

	// RVA: 0xF1D0FC Offset: 0xF1D0FC VA: 0xF1D0FC
	public IllegalWordsSearchEx.TreeNode GetTransition(string text, int index) { }

	// RVA: 0xF1D200 Offset: 0xF1D200 VA: 0xF1D200
	public bool ContainsTransition(char c) { }

	// RVA: 0xF1D054 Offset: 0xF1D054 VA: 0xF1D054
	public char get_Char() { }

	// RVA: 0xF1D280 Offset: 0xF1D280 VA: 0xF1D280
	public IllegalWordsSearchEx.TreeNode get_Parent() { }

	// RVA: 0xF1D288 Offset: 0xF1D288 VA: 0xF1D288
	public IllegalWordsSearchEx.TreeNode get_Failure() { }

	// RVA: 0xF1D290 Offset: 0xF1D290 VA: 0xF1D290
	public void set_Failure(IllegalWordsSearchEx.TreeNode value) { }

	// RVA: 0xF1D298 Offset: 0xF1D298 VA: 0xF1D298
	public List<IllegalWordsSearchEx.TreeNode> get_Transitions() { }

	// RVA: 0xF1D2A0 Offset: 0xF1D2A0 VA: 0xF1D2A0
	public List<string> get_Results() { }
}
