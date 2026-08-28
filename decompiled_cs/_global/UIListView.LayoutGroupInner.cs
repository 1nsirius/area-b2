// Namespace: 
public class UIListView.LayoutGroupInner // TypeDefIndex: 7341
{
	// Fields
	private int column; // 0x8
	private Arrangement direction; // 0xC
	private GameObject go; // 0x10
	private RectTransform rectTrans; // 0x14
	private UIContainer container; // 0x18
	private RectTransform itemPrefabTrans; // 0x1C
	private UIListView listView; // 0x20

	// Properties
	public float CellWidth { get; }
	public float CellHeight { get; }
	public int Column { get; set; }
	public int Row { get; }
	public Arrangement Direction { get; set; }
	public RectTransform rectTransform { get; }
	public UIContainer Container { get; }

	// Methods

	// RVA: 0xD88088 Offset: 0xD88088 VA: 0xD88088
	public void .ctor(GameObject go, GameObject itemPrefab) { }

	// RVA: 0xD87270 Offset: 0xD87270 VA: 0xD87270
	public float get_CellWidth() { }

	// RVA: 0xD8717C Offset: 0xD8717C VA: 0xD8717C
	public float get_CellHeight() { }

	// RVA: 0xD870CC Offset: 0xD870CC VA: 0xD870CC
	public int get_Column() { }

	// RVA: 0xD898B4 Offset: 0xD898B4 VA: 0xD898B4
	public void set_Column(int value) { }

	// RVA: 0xD89964 Offset: 0xD89964 VA: 0xD89964
	public int get_Row() { }

	// RVA: 0xD89A7C Offset: 0xD89A7C VA: 0xD89A7C
	public Arrangement get_Direction() { }

	// RVA: 0xD868AC Offset: 0xD868AC VA: 0xD868AC
	public void set_Direction(Arrangement value) { }

	// RVA: 0xD870C4 Offset: 0xD870C4 VA: 0xD870C4
	public RectTransform get_rectTransform() { }

	// RVA: 0xD896A4 Offset: 0xD896A4 VA: 0xD896A4
	public UIContainer get_Container() { }

	// RVA: 0xD86B54 Offset: 0xD86B54 VA: 0xD86B54
	public void UpdatePosition() { }
}
