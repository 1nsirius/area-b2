// Namespace: 
public class F2NormalButton // TypeDefIndex: 5617
{
	// Fields
	private F2NormalButton.ButtonState mButtonState; // 0x8
	private UIEventListener eventListener; // 0xC
	private F2NormalButton.GraphicItem[] mGraphics; // 0x10
	private Image mFg; // 0x14
	private Image mBg; // 0x18
	private Text mText; // 0x1C
	private GameObject mContent; // 0x20
	private RectTransform mRt; // 0x24
	private bool mShow; // 0x28
	private bool mEnable; // 0x29

	// Properties
	public F2NormalButton.ButtonState BtnState { get; }
	public bool IsPointerDown { get; }
	public GameObject Content { get; }

	// Methods

	// RVA: 0xBC5AFC Offset: 0xBC5AFC VA: 0xBC5AFC
	public F2NormalButton.ButtonState get_BtnState() { }

	// RVA: 0xBC5B04 Offset: 0xBC5B04 VA: 0xBC5B04
	public bool get_IsPointerDown() { }

	// RVA: 0xBC5B30 Offset: 0xBC5B30 VA: 0xBC5B30
	public void add_onPointerClick(UnityAction<PointerEventData> value) { }

	// RVA: 0xBC5B64 Offset: 0xBC5B64 VA: 0xBC5B64
	public void remove_onPointerClick(UnityAction<PointerEventData> value) { }

	// RVA: 0xBC5B98 Offset: 0xBC5B98 VA: 0xBC5B98
	public GameObject get_Content() { }

	// RVA: 0xBC5BA0 Offset: 0xBC5BA0 VA: 0xBC5BA0
	private void .ctor(GameObject go) { }

	// RVA: 0xBC5C34 Offset: 0xBC5C34 VA: 0xBC5C34
	private void InitView(string[] excludeGraphicNames) { }

	// RVA: 0xBC6108 Offset: 0xBC6108 VA: 0xBC6108
	public void AddUIEventListener(GameObject dragPanel) { }

	// RVA: 0xBC6128 Offset: 0xBC6128 VA: 0xBC6128
	public void SetButtonState(F2NormalButton.ButtonState state, bool force = False) { }

	// RVA: 0xBC6940 Offset: 0xBC6940 VA: 0xBC6940
	public void Show(bool show) { }

	// RVA: 0xBC6970 Offset: 0xBC6970 VA: 0xBC6970
	public void SetEnable(bool enable) { }

	// RVA: 0xBC6990 Offset: 0xBC6990 VA: 0xBC6990
	public void SetText(string text) { }

	// RVA: 0xBC6A54 Offset: 0xBC6A54 VA: 0xBC6A54
	public static F2NormalButton CreateNormalButon(Transform parentTrans, string name, GameObject dragPanel, string[] excludeGraphicNames) { }
}
