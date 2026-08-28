// Namespace: 
private class Parser.EventQueue // TypeDefIndex: 5129
{
	// Fields
	private readonly Queue<ParsingEvent> highPriorityEvents; // 0x8
	private readonly Queue<ParsingEvent> normalPriorityEvents; // 0xC

	// Properties
	public int Count { get; }

	// Methods

	// RVA: 0x1A11B08 Offset: 0x1A11B08 VA: 0x1A11B08
	public void Enqueue(ParsingEvent event) { }

	// RVA: 0x1A12310 Offset: 0x1A12310 VA: 0x1A12310
	public ParsingEvent Dequeue() { }

	// RVA: 0x1A12008 Offset: 0x1A12008 VA: 0x1A12008
	public int get_Count() { }

	// RVA: 0x1A11EC0 Offset: 0x1A11EC0 VA: 0x1A11EC0
	public void .ctor() { }
}
