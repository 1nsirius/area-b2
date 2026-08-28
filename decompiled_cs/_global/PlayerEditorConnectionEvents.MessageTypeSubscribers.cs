// Namespace: 
[Serializable]
public class PlayerEditorConnectionEvents.MessageTypeSubscribers // TypeDefIndex: 3533
{
	// Fields
	[SerializeField] // RVA: 0x4F9CB4 Offset: 0x4F9CB4 VA: 0x4F9CB4
	private string m_messageTypeId; // 0x8
	public int subscriberCount; // 0xC
	public PlayerEditorConnectionEvents.MessageEvent messageCallback; // 0x10

	// Properties
	public Guid MessageTypeId { get; set; }

	// Methods

	// RVA: 0x19659A0 Offset: 0x19659A0 VA: 0x19659A0
	public void .ctor() { }

	// RVA: 0x19657EC Offset: 0x19657EC VA: 0x19657EC
	public Guid get_MessageTypeId() { }

	// RVA: 0x1965A20 Offset: 0x1965A20 VA: 0x1965A20
	public void set_MessageTypeId(Guid value) { }
}
