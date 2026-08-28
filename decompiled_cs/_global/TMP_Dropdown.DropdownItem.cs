// Namespace: 
protected internal class TMP_Dropdown.DropdownItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler // TypeDefIndex: 4686
{
	// Fields
	[SerializeField] // RVA: 0x54B328 Offset: 0x54B328 VA: 0x54B328
	private TMP_Text m_Text; // 0xC
	[SerializeField] // RVA: 0x54B338 Offset: 0x54B338 VA: 0x54B338
	private Image m_Image; // 0x10
	[SerializeField] // RVA: 0x54B348 Offset: 0x54B348 VA: 0x54B348
	private RectTransform m_RectTransform; // 0x14
	[SerializeField] // RVA: 0x54B358 Offset: 0x54B358 VA: 0x54B358
	private Toggle m_Toggle; // 0x18

	// Properties
	public TMP_Text text { get; set; }
	public Image image { get; set; }
	public RectTransform rectTransform { get; set; }
	public Toggle toggle { get; set; }

	// Methods

	// RVA: 0xE24700 Offset: 0xE24700 VA: 0xE24700
	public TMP_Text get_text() { }

	// RVA: 0xE2224C Offset: 0xE2224C VA: 0xE2224C
	public void set_text(TMP_Text value) { }

	// RVA: 0xE24708 Offset: 0xE24708 VA: 0xE24708
	public Image get_image() { }

	// RVA: 0xE22254 Offset: 0xE22254 VA: 0xE22254
	public void set_image(Image value) { }

	// RVA: 0xE23B00 Offset: 0xE23B00 VA: 0xE23B00
	public RectTransform get_rectTransform() { }

	// RVA: 0xE22264 Offset: 0xE22264 VA: 0xE22264
	public void set_rectTransform(RectTransform value) { }

	// RVA: 0xE23F0C Offset: 0xE23F0C VA: 0xE23F0C
	public Toggle get_toggle() { }

	// RVA: 0xE2225C Offset: 0xE2225C VA: 0xE2225C
	public void set_toggle(Toggle value) { }

	// RVA: 0xE24D54 Offset: 0xE24D54 VA: 0xE24D54 Slot: 6
	public virtual void OnPointerEnter(PointerEventData eventData) { }

	// RVA: 0xE24E08 Offset: 0xE24E08 VA: 0xE24E08 Slot: 7
	public virtual void OnCancel(BaseEventData eventData) { }

	// RVA: 0xE24EC8 Offset: 0xE24EC8 VA: 0xE24EC8
	public void .ctor() { }
}
