// Namespace: 
private class DatatypeImplementation.SchemaDatatypeMap : IComparable // TypeDefIndex: 2610
{
	// Fields
	private string name; // 0x8
	private DatatypeImplementation type; // 0xC
	private int parentIndex; // 0x10

	// Properties
	public string Name { get; }
	public int ParentIndex { get; }

	// Methods

	// RVA: 0x19C9758 Offset: 0x19C9758 VA: 0x19C9758
	internal void .ctor(string name, DatatypeImplementation type) { }

	// RVA: 0x19C9780 Offset: 0x19C9780 VA: 0x19C9780
	internal void .ctor(string name, DatatypeImplementation type, int parentIndex) { }

	// RVA: 0x19CAAC0 Offset: 0x19CAAC0 VA: 0x19CAAC0
	public static DatatypeImplementation op_Explicit(DatatypeImplementation.SchemaDatatypeMap sdm) { }

	// RVA: 0x19CB1B8 Offset: 0x19CB1B8 VA: 0x19CB1B8
	public string get_Name() { }

	// RVA: 0x19CB1C0 Offset: 0x19CB1C0 VA: 0x19CB1C0
	public int get_ParentIndex() { }

	// RVA: 0x19CD2FC Offset: 0x19CD2FC VA: 0x19CD2FC Slot: 4
	public int CompareTo(object obj) { }
}
