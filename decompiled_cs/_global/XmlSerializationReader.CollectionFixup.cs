// Namespace: 
protected class XmlSerializationReader.CollectionFixup // TypeDefIndex: 2529
{
	// Fields
	private XmlSerializationCollectionFixupCallback callback; // 0x8
	private object collection; // 0xC
	private object collectionItems; // 0x10
	private string id; // 0x14

	// Properties
	public XmlSerializationCollectionFixupCallback Callback { get; }
	public object Collection { get; }
	internal object Id { get; }
	public object CollectionItems { get; set; }

	// Methods

	// RVA: 0x1C22F98 Offset: 0x1C22F98 VA: 0x1C22F98
	internal void .ctor(object collection, XmlSerializationCollectionFixupCallback callback, string id) { }

	// RVA: 0x1C1FDB0 Offset: 0x1C1FDB0 VA: 0x1C1FDB0
	public XmlSerializationCollectionFixupCallback get_Callback() { }

	// RVA: 0x1C1FDB8 Offset: 0x1C1FDB8 VA: 0x1C1FDB8
	public object get_Collection() { }

	// RVA: 0x1C1D848 Offset: 0x1C1D848 VA: 0x1C1D848
	internal object get_Id() { }

	// RVA: 0x1C21D50 Offset: 0x1C21D50 VA: 0x1C21D50
	public object get_CollectionItems() { }

	// RVA: 0x1C1D850 Offset: 0x1C1D850 VA: 0x1C1D850
	internal void set_CollectionItems(object value) { }
}
