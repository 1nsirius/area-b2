// Namespace: 
[Serializable]
private class DelegateSerializationHolder.DelegateEntry // TypeDefIndex: 348
{
	// Fields
	private string type; // 0x8
	private string assembly; // 0xC
	private object target; // 0x10
	private string targetTypeAssembly; // 0x14
	private string targetTypeName; // 0x18
	private string methodName; // 0x1C
	public DelegateSerializationHolder.DelegateEntry delegateEntry; // 0x20

	// Methods

	// RVA: 0x146ACC0 Offset: 0x146ACC0 VA: 0x146ACC0
	public void .ctor(Delegate del, string targetLabel) { }

	// RVA: 0x146A974 Offset: 0x146A974 VA: 0x146A974
	public Delegate DeserializeDelegate(SerializationInfo info, int index) { }
}
