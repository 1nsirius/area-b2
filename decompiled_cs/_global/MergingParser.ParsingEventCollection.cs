// Namespace: 
private sealed class MergingParser.ParsingEventCollection : IEnumerable<LinkedListNode<ParsingEvent>>, IEnumerable // TypeDefIndex: 5122
{
	// Fields
	private readonly LinkedList<ParsingEvent> _events; // 0x8
	private readonly HashSet<LinkedListNode<ParsingEvent>> _deleted; // 0xC
	private readonly Dictionary<string, LinkedListNode<ParsingEvent>> _references; // 0x10

	// Methods

	// RVA: 0x1A0EFF8 Offset: 0x1A0EFF8 VA: 0x1A0EFF8
	public void .ctor() { }

	// RVA: 0x1A10384 Offset: 0x1A10384 VA: 0x1A10384
	public void AddAfter(LinkedListNode<ParsingEvent> node, IEnumerable<ParsingEvent> items) { }

	// RVA: 0x1A0FA44 Offset: 0x1A0FA44 VA: 0x1A0FA44
	public void Add(ParsingEvent item) { }

	// RVA: 0x1A0FBC4 Offset: 0x1A0FBC4 VA: 0x1A0FBC4
	public void MarkDeleted(LinkedListNode<ParsingEvent> node) { }

	// RVA: 0x1A0F8D4 Offset: 0x1A0F8D4 VA: 0x1A0F8D4
	public void CleanMarked() { }

	[IteratorStateMachineAttribute] // RVA: 0x54EDB4 Offset: 0x54EDB4 VA: 0x54EDB4
	// RVA: 0x1A106C4 Offset: 0x1A106C4 VA: 0x1A106C4
	public IEnumerable<LinkedListNode<ParsingEvent>> FromAnchor(string anchor) { }

	// RVA: 0x1A0F0EC Offset: 0x1A0F0EC VA: 0x1A0F0EC Slot: 4
	public IEnumerator<LinkedListNode<ParsingEvent>> GetEnumerator() { }

	// RVA: 0x1A112D4 Offset: 0x1A112D4 VA: 0x1A112D4 Slot: 5
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[IteratorStateMachineAttribute] // RVA: 0x54EE2C Offset: 0x54EE2C VA: 0x54EE2C
	// RVA: 0x1A11248 Offset: 0x1A11248 VA: 0x1A11248
	private IEnumerator<LinkedListNode<ParsingEvent>> GetEnumerator(LinkedListNode<ParsingEvent> node) { }

	// RVA: 0x1A11138 Offset: 0x1A11138 VA: 0x1A11138
	private void AddReference(ParsingEvent item, LinkedListNode<ParsingEvent> node) { }
}
