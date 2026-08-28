// Namespace: 
internal class XmlTextReaderImpl.DtdParserProxy : IDtdParserAdapterV1, IDtdParserAdapterWithValidation, IDtdParserAdapter // TypeDefIndex: 2349
{
	// Fields
	private XmlTextReaderImpl reader; // 0x8

	// Properties
	private XmlNameTable System.Xml.IDtdParserAdapter.NameTable { get; }
	private IXmlNamespaceResolver System.Xml.IDtdParserAdapter.NamespaceResolver { get; }
	private Uri System.Xml.IDtdParserAdapter.BaseUri { get; }
	private bool System.Xml.IDtdParserAdapter.IsEof { get; }
	private char[] System.Xml.IDtdParserAdapter.ParsingBuffer { get; }
	private int System.Xml.IDtdParserAdapter.ParsingBufferLength { get; }
	private int System.Xml.IDtdParserAdapter.CurrentPosition { get; set; }
	private int System.Xml.IDtdParserAdapter.EntityStackLength { get; }
	private bool System.Xml.IDtdParserAdapter.IsEntityEolNormalized { get; }
	private int System.Xml.IDtdParserAdapter.LineNo { get; }
	private int System.Xml.IDtdParserAdapter.LineStartPosition { get; }
	private bool System.Xml.IDtdParserAdapterWithValidation.DtdValidation { get; }
	private IValidationEventHandling System.Xml.IDtdParserAdapterWithValidation.ValidationEventHandling { get; }
	private bool System.Xml.IDtdParserAdapterV1.Normalization { get; }
	private bool System.Xml.IDtdParserAdapterV1.Namespaces { get; }
	private bool System.Xml.IDtdParserAdapterV1.V1CompatibilityMode { get; }

	// Methods

	// RVA: 0x14119C8 Offset: 0x14119C8 VA: 0x14119C8
	internal void .ctor(XmlTextReaderImpl reader) { }

	// RVA: 0x14119E8 Offset: 0x14119E8 VA: 0x14119E8 Slot: 9
	private XmlNameTable System.Xml.IDtdParserAdapter.get_NameTable() { }

	// RVA: 0x1411A14 Offset: 0x1411A14 VA: 0x1411A14 Slot: 10
	private IXmlNamespaceResolver System.Xml.IDtdParserAdapter.get_NamespaceResolver() { }

	// RVA: 0x1411A40 Offset: 0x1411A40 VA: 0x1411A40 Slot: 11
	private Uri System.Xml.IDtdParserAdapter.get_BaseUri() { }

	// RVA: 0x1411A6C Offset: 0x1411A6C VA: 0x1411A6C Slot: 18
	private bool System.Xml.IDtdParserAdapter.get_IsEof() { }

	// RVA: 0x1411A98 Offset: 0x1411A98 VA: 0x1411A98 Slot: 12
	private char[] System.Xml.IDtdParserAdapter.get_ParsingBuffer() { }

	// RVA: 0x1411AC4 Offset: 0x1411AC4 VA: 0x1411AC4 Slot: 13
	private int System.Xml.IDtdParserAdapter.get_ParsingBufferLength() { }

	// RVA: 0x1411AF0 Offset: 0x1411AF0 VA: 0x1411AF0 Slot: 14
	private int System.Xml.IDtdParserAdapter.get_CurrentPosition() { }

	// RVA: 0x1411B1C Offset: 0x1411B1C VA: 0x1411B1C Slot: 15
	private void System.Xml.IDtdParserAdapter.set_CurrentPosition(int value) { }

	// RVA: 0x1411B50 Offset: 0x1411B50 VA: 0x1411B50 Slot: 19
	private int System.Xml.IDtdParserAdapter.get_EntityStackLength() { }

	// RVA: 0x1411B7C Offset: 0x1411B7C VA: 0x1411B7C Slot: 20
	private bool System.Xml.IDtdParserAdapter.get_IsEntityEolNormalized() { }

	// RVA: 0x1411BA8 Offset: 0x1411BA8 VA: 0x1411BA8 Slot: 22
	private void System.Xml.IDtdParserAdapter.OnNewLine(int pos) { }

	// RVA: 0x1411BDC Offset: 0x1411BDC VA: 0x1411BDC Slot: 16
	private int System.Xml.IDtdParserAdapter.get_LineNo() { }

	// RVA: 0x1411C08 Offset: 0x1411C08 VA: 0x1411C08 Slot: 17
	private int System.Xml.IDtdParserAdapter.get_LineStartPosition() { }

	// RVA: 0x1411C34 Offset: 0x1411C34 VA: 0x1411C34 Slot: 21
	private int System.Xml.IDtdParserAdapter.ReadData() { }

	// RVA: 0x1411C60 Offset: 0x1411C60 VA: 0x1411C60 Slot: 23
	private int System.Xml.IDtdParserAdapter.ParseNumericCharRef(StringBuilder internalSubsetBuilder) { }

	// RVA: 0x1411C94 Offset: 0x1411C94 VA: 0x1411C94 Slot: 24
	private int System.Xml.IDtdParserAdapter.ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder) { }

	// RVA: 0x1411CD0 Offset: 0x1411CD0 VA: 0x1411CD0 Slot: 25
	private void System.Xml.IDtdParserAdapter.ParsePI(StringBuilder sb) { }

	// RVA: 0x1411D04 Offset: 0x1411D04 VA: 0x1411D04 Slot: 26
	private void System.Xml.IDtdParserAdapter.ParseComment(StringBuilder sb) { }

	// RVA: 0x1411D38 Offset: 0x1411D38 VA: 0x1411D38 Slot: 27
	private bool System.Xml.IDtdParserAdapter.PushEntity(IDtdEntityInfo entity, out int entityId) { }

	// RVA: 0x1411D74 Offset: 0x1411D74 VA: 0x1411D74 Slot: 28
	private bool System.Xml.IDtdParserAdapter.PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId) { }

	// RVA: 0x1411DB0 Offset: 0x1411DB0 VA: 0x1411DB0 Slot: 29
	private bool System.Xml.IDtdParserAdapter.PushExternalSubset(string systemId, string publicId) { }

	// RVA: 0x1411DEC Offset: 0x1411DEC VA: 0x1411DEC Slot: 30
	private void System.Xml.IDtdParserAdapter.PushInternalDtd(string baseUri, string internalDtd) { }

	// RVA: 0x1411E28 Offset: 0x1411E28 VA: 0x1411E28 Slot: 33
	private void System.Xml.IDtdParserAdapter.Throw(Exception e) { }

	// RVA: 0x1411E5C Offset: 0x1411E5C VA: 0x1411E5C Slot: 31
	private void System.Xml.IDtdParserAdapter.OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo) { }

	// RVA: 0x1411EBC Offset: 0x1411EBC VA: 0x1411EBC Slot: 32
	private void System.Xml.IDtdParserAdapter.OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo) { }

	// RVA: 0x1411F1C Offset: 0x1411F1C VA: 0x1411F1C Slot: 7
	private bool System.Xml.IDtdParserAdapterWithValidation.get_DtdValidation() { }

	// RVA: 0x1411F48 Offset: 0x1411F48 VA: 0x1411F48 Slot: 8
	private IValidationEventHandling System.Xml.IDtdParserAdapterWithValidation.get_ValidationEventHandling() { }

	// RVA: 0x1411F74 Offset: 0x1411F74 VA: 0x1411F74 Slot: 5
	private bool System.Xml.IDtdParserAdapterV1.get_Normalization() { }

	// RVA: 0x1411FA0 Offset: 0x1411FA0 VA: 0x1411FA0 Slot: 6
	private bool System.Xml.IDtdParserAdapterV1.get_Namespaces() { }

	// RVA: 0x1411FCC Offset: 0x1411FCC VA: 0x1411FCC Slot: 4
	private bool System.Xml.IDtdParserAdapterV1.get_V1CompatibilityMode() { }
}
