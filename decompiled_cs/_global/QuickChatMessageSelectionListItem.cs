// Namespace: 
public class QuickChatMessageSelectionListItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler // TypeDefIndex: 5700
{
	// Fields
	private uint mQuickMessageID; // 0xC
	[FormerlySerializedAsAttribute] // RVA: 0x55E68C Offset: 0x55E68C VA: 0x55E68C
	[SerializeField] // RVA: 0x55E68C Offset: 0x55E68C VA: 0x55E68C
	private QuickChatMessageSelectionListItem.ItemClickedEvent m_OnClick; // 0x10

	// Properties
	public uint QuickMessageID { get; set; }
	public QuickChatMessageSelectionListItem.ItemClickedEvent onClick { get; set; }

	// Methods

	// RVA: 0x2CEFB24 Offset: 0x2CEFB24 VA: 0x2CEFB24
	public uint get_QuickMessageID() { }

	// RVA: 0x2CEFA7C Offset: 0x2CEFA7C VA: 0x2CEFA7C
	public void set_QuickMessageID(uint value) { }

	// RVA: 0x2CEFB2C Offset: 0x2CEFB2C VA: 0x2CEFB2C
	public QuickChatMessageSelectionListItem.ItemClickedEvent get_onClick() { }

	// RVA: 0x2CEFB34 Offset: 0x2CEFB34 VA: 0x2CEFB34
	public void set_onClick(QuickChatMessageSelectionListItem.ItemClickedEvent value) { }

	// RVA: 0x2CEFB3C Offset: 0x2CEFB3C VA: 0x2CEFB3C Slot: 4
	public void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0x2CEFBBC Offset: 0x2CEFBBC VA: 0x2CEFBBC
	public void .ctor() { }
}
