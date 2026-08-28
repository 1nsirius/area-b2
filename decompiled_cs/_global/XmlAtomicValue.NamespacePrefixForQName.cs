// Namespace: 
private class XmlAtomicValue.NamespacePrefixForQName : IXmlNamespaceResolver // TypeDefIndex: 2732
{
	// Fields
	public string prefix; // 0x8
	public string ns; // 0xC

	// Methods

	// RVA: 0x184BF44 Offset: 0x184BF44 VA: 0x184BF44
	public void .ctor(string prefix, string ns) { }

	// RVA: 0x184CE04 Offset: 0x184CE04 VA: 0x184CE04 Slot: 5
	public string LookupNamespace(string prefix) { }

	// RVA: 0x184CE38 Offset: 0x184CE38 VA: 0x184CE38 Slot: 6
	public string LookupPrefix(string namespaceName) { }

	// RVA: 0x184CE64 Offset: 0x184CE64 VA: 0x184CE64 Slot: 4
	public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope) { }
}
