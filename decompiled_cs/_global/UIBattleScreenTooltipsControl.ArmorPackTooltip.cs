// Namespace: 
public class UIBattleScreenTooltipsControl.ArmorPackTooltip : UIBattleScreenTooltipsControl.IScreenArrowTooltip, UIBattleScreenTooltipsControl.IScreenTooltip // TypeDefIndex: 10295
{
	// Fields
	public GameObject tooltipGo; // 0x8
	private RectTransform _tran; // 0xC
	private RectTransform _arrow; // 0x10
	private GameObject _arrowGo; // 0x14
	private GameObject _goalImgGo; // 0x18
	private int _curNum; // 0x1C
	private Text _numText; // 0x20
	public IArmorPackUIProxy proxy; // 0x24
	private Rect _clampRect; // 0x28
	private float _curDist; // 0x38
	private Vector3 _lastScreenPos; // 0x3C
	private Camera _viewCam; // 0x48
	private Transform _viewCamTran; // 0x4C

	// Properties
	public byte UID { get; }

	// Methods

	// RVA: 0xC0FBC4 Offset: 0xC0FBC4 VA: 0xC0FBC4
	public byte get_UID() { }

	// RVA: 0xC0E10C Offset: 0xC0E10C VA: 0xC0E10C
	public void .ctor(IArmorPackUIProxy proxy, GameObject go, Camera cam) { }

	// RVA: 0xC0FC9C Offset: 0xC0FC9C VA: 0xC0FC9C Slot: 4
	public void Init() { }

	// RVA: 0xC0FCA0 Offset: 0xC0FCA0 VA: 0xC0FCA0 Slot: 5
	public bool Tick(float deltaTime) { }

	// RVA: 0xC0FF00 Offset: 0xC0FF00 VA: 0xC0FF00
	private void RefreshDistText() { }

	// RVA: 0xC0E1D4 Offset: 0xC0E1D4 VA: 0xC0E1D4
	public void Init(float dynamicGoalPointSize) { }

	// RVA: 0xC100C8 Offset: 0xC100C8 VA: 0xC100C8 Slot: 6
	public void OnDestroy() { }

	// RVA: 0xC0FF04 Offset: 0xC0FF04 VA: 0xC0FF04
	private void UpdateCurArmorPackNum() { }
}
