// Namespace: 
protected internal class Dropdown.DropdownItem : MonoBehaviour, IPointerEnterHandler, ICancelHandler, IEventSystemHandler // TypeDefIndex: 4037
{
	// Fields
	[SerializeField] // RVA: 0x53F8D4 Offset: 0x53F8D4 VA: 0x53F8D4
	private Text m_Text; // 0xC
	[SerializeField] // RVA: 0x53F8E4 Offset: 0x53F8E4 VA: 0x53F8E4
	private Image m_Image; // 0x10
	[SerializeField] // RVA: 0x53F8F4 Offset: 0x53F8F4 VA: 0x53F8F4
	private RectTransform m_RectTransform; // 0x14
	[SerializeField] // RVA: 0x53F904 Offset: 0x53F904 VA: 0x53F904
	private Toggle m_Toggle; // 0x18

	// Properties
	public Text text { get; set; }
	public Image image { get; set; }
	public RectTransform rectTransform { get; set; }
	public Toggle toggle { get; set; }

	// Methods

	// RVA: 0x1B18F58 Offset: 0x1B18F58 VA: 0x1B18F58
	public void .ctor() { }

	// RVA: 0x1B18F60 Offset: 0x1B18F60 VA: 0x1B18F60
	public Text get_text() { }

	// RVA: 0x1B18F68 Offset: 0x1B18F68 VA: 0x1B18F68
	public void set_text(Text value) { }

	// RVA: 0x1B18F70 Offset: 0x1B18F70 VA: 0x1B18F70
	public Image get_image() { }

	// RVA: 0x1B18F78 Offset: 0x1B18F78 VA: 0x1B18F78
	public void set_image(Image value) { }

	// RVA: 0x1B18F80 Offset: 0x1B18F80 VA: 0x1B18F80
	public RectTransform get_rectTransform() { }

	// RVA: 0x1B18F88 Offset: 0x1B18F88 VA: 0x1B18F88
	public void set_rectTransform(RectTransform value) { }

	// RVA: 0x1B18EEC Offset: 0x1B18EEC VA: 0x1B18EEC
	public Toggle get_toggle() { }

	// RVA: 0x1B18F90 Offset: 0x1B18F90 VA: 0x1B18F90
	public void set_toggle(Toggle value) { }

	// RVA: 0x1B18F98 Offset: 0x1B18F98 VA: 0x1B18F98 Slot: 6
	public virtual void OnPointerEnter(PointerEventData eventData) { }

	// RVA: 0x1B1904C Offset: 0x1B1904C VA: 0x1B1904C Slot: 7
	public virtual void OnCancel(BaseEventData eventData) { }
}
