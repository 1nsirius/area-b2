// Namespace: 
internal class XmlSchemaObjectTable.XSOEnumerator : IEnumerator // TypeDefIndex: 2796
{
	// Fields
	private List<XmlSchemaObjectTable.XmlSchemaObjectEntry> entries; // 0x8
	private XmlSchemaObjectTable.EnumeratorType enumType; // 0xC
	protected int currentIndex; // 0x10
	protected int size; // 0x14
	protected XmlQualifiedName currentKey; // 0x18
	protected XmlSchemaObject currentValue; // 0x1C

	// Properties
	public object Current { get; }

	// Methods

	// RVA: 0x1067160 Offset: 0x1067160 VA: 0x1067160
	internal void .ctor(List<XmlSchemaObjectTable.XmlSchemaObjectEntry> entries, int size, XmlSchemaObjectTable.EnumeratorType enumType) { }

	// RVA: 0x1067744 Offset: 0x1067744 VA: 0x1067744 Slot: 5
	public object get_Current() { }

	// RVA: 0x1067994 Offset: 0x1067994 VA: 0x1067994 Slot: 4
	public bool MoveNext() { }

	// RVA: 0x1067A94 Offset: 0x1067A94 VA: 0x1067A94 Slot: 6
	public void Reset() { }
}
