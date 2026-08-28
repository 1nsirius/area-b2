// Namespace: 
private struct TimeSpanParse.TimeSpanTokenizer // TypeDefIndex: 708
{
	// Fields
	private int m_pos; // 0x0
	private string m_value; // 0x4

	// Properties
	internal bool EOL { get; }
	internal char NextChar { get; }
	internal char CurrentChar { get; }

	// Methods

	// RVA: 0x76DDF4 Offset: 0x76DDF4 VA: 0x76DDF4
	internal void Init(string input) { }

	// RVA: 0x76DE04 Offset: 0x76DE04 VA: 0x76DE04
	internal void Init(string input, int startPosition) { }

	// RVA: 0x76DE10 Offset: 0x76DE10 VA: 0x76DE10
	internal TimeSpanParse.TimeSpanToken GetNextToken() { }

	// RVA: 0x76DE24 Offset: 0x76DE24 VA: 0x76DE24
	internal bool get_EOL() { }

	// RVA: 0x76DE2C Offset: 0x76DE2C VA: 0x76DE2C
	internal char get_NextChar() { }

	// RVA: 0x76DE3C Offset: 0x76DE3C VA: 0x76DE3C
	internal char get_CurrentChar() { }
}
