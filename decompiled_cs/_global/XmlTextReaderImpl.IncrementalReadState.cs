// Namespace: 
private enum XmlTextReaderImpl.IncrementalReadState // TypeDefIndex: 2343
{
	// Fields
	public int value__; // 0x0
	public const XmlTextReaderImpl.IncrementalReadState Text = 0;
	public const XmlTextReaderImpl.IncrementalReadState StartTag = 1;
	public const XmlTextReaderImpl.IncrementalReadState PI = 2;
	public const XmlTextReaderImpl.IncrementalReadState CDATA = 3;
	public const XmlTextReaderImpl.IncrementalReadState Comment = 4;
	public const XmlTextReaderImpl.IncrementalReadState Attributes = 5;
	public const XmlTextReaderImpl.IncrementalReadState AttributeValue = 6;
	public const XmlTextReaderImpl.IncrementalReadState ReadData = 7;
	public const XmlTextReaderImpl.IncrementalReadState EndElement = 8;
	public const XmlTextReaderImpl.IncrementalReadState End = 9;
	public const XmlTextReaderImpl.IncrementalReadState ReadValueChunk_OnCachedValue = 10;
	public const XmlTextReaderImpl.IncrementalReadState ReadValueChunk_OnPartialValue = 11;
	public const XmlTextReaderImpl.IncrementalReadState ReadContentAsBinary_OnCachedValue = 12;
	public const XmlTextReaderImpl.IncrementalReadState ReadContentAsBinary_OnPartialValue = 13;
	public const XmlTextReaderImpl.IncrementalReadState ReadContentAsBinary_End = 14;
}
