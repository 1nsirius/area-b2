// Namespace: 
internal class XmlValidatingReaderImpl.ValidationEventHandling : IValidationEventHandling // TypeDefIndex: 2357
{
	// Fields
	private XmlValidatingReaderImpl reader; // 0x8
	private ValidationEventHandler eventHandler; // 0xC

	// Properties
	private object System.Xml.IValidationEventHandling.EventHandler { get; }

	// Methods

	// RVA: 0x1418CC4 Offset: 0x1418CC4 VA: 0x1418CC4
	internal void .ctor(XmlValidatingReaderImpl reader) { }

	// RVA: 0x141A7A4 Offset: 0x141A7A4 VA: 0x141A7A4 Slot: 4
	private object System.Xml.IValidationEventHandling.get_EventHandler() { }

	// RVA: 0x141A7AC Offset: 0x141A7AC VA: 0x141A7AC Slot: 5
	private void System.Xml.IValidationEventHandling.SendEvent(Exception exception, XmlSeverityType severity) { }

	// RVA: 0x1418CE4 Offset: 0x1418CE4 VA: 0x1418CE4
	internal void AddHandler(ValidationEventHandler handler) { }
}
