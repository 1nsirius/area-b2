// Namespace: 
internal sealed class XmlTextReaderImpl.OnDefaultAttributeUseDelegate : MulticastDelegate // TypeDefIndex: 2352
{
	// Methods

	// RVA: 0x14128EC Offset: 0x14128EC VA: 0x14128EC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1412900 Offset: 0x1412900 VA: 0x1412900 Slot: 12
	public virtual void Invoke(IDtdDefaultAttributeInfo defaultAttribute, XmlTextReaderImpl coreReader) { }

	// RVA: 0x1413188 Offset: 0x1413188 VA: 0x1413188 Slot: 13
	public virtual IAsyncResult BeginInvoke(IDtdDefaultAttributeInfo defaultAttribute, XmlTextReaderImpl coreReader, AsyncCallback callback, object object) { }

	// RVA: 0x14131C0 Offset: 0x14131C0 VA: 0x14131C0 Slot: 14
	public virtual void EndInvoke(IAsyncResult result) { }
}
