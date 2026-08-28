// Namespace: 
private class YamlDocument.AnchorAssigningVisitor : YamlVisitorBase // TypeDefIndex: 5082
{
	// Fields
	private readonly HashSet<string> existingAnchors; // 0x8
	private readonly Dictionary<YamlNode, bool> visitedNodes; // 0xC

	// Methods

	// RVA: 0x1A2338C Offset: 0x1A2338C VA: 0x1A2338C
	public void AssignAnchors(YamlDocument document) { }

	// RVA: 0x1A23B60 Offset: 0x1A23B60 VA: 0x1A23B60
	private bool VisitNodeAndFindDuplicates(YamlNode node) { }

	// RVA: 0x1A23C90 Offset: 0x1A23C90 VA: 0x1A23C90 Slot: 11
	public override void Visit(YamlScalarNode scalar) { }

	// RVA: 0x1A23C94 Offset: 0x1A23C94 VA: 0x1A23C94 Slot: 13
	public override void Visit(YamlMappingNode mapping) { }

	// RVA: 0x1A23CC4 Offset: 0x1A23CC4 VA: 0x1A23CC4 Slot: 12
	public override void Visit(YamlSequenceNode sequence) { }

	// RVA: 0x1A232CC Offset: 0x1A232CC VA: 0x1A232CC
	public void .ctor() { }
}
