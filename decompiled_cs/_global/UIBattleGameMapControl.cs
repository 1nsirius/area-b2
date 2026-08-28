// Namespace: 
public class UIBattleGameMapControl : BaseView // TypeDefIndex: 5771
{
	// Fields
	private UIBattleGameMapControl.SwitchButton[] switchBtns; // 0x30
	private Button _openMapBtn; // 0x34
	private Button _closeMapBtn; // 0x38
	private IList<IUIMapView> _views; // 0x3C
	private IUIMapView _curMapView; // 0x40
	public MainCharacterController mainCtrl; // 0x44
	private Action<byte> onObservableCharacterChanged; // 0x48

	// Methods

	// RVA: 0xB3F1F4 Offset: 0xB3F1F4 VA: 0xB3F1F4
	public void .ctor() { }

	// RVA: 0xB3F260 Offset: 0xB3F260 VA: 0xB3F260 Slot: 19
	public override void InitViews() { }

	// RVA: 0xB3F53C Offset: 0xB3F53C VA: 0xB3F53C Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB3F540 Offset: 0xB3F540 VA: 0xB3F540 Slot: 21
	public override void Init() { }

	// RVA: 0xB3F74C Offset: 0xB3F74C VA: 0xB3F74C Slot: 24
	public override void OnTick() { }

	// RVA: 0xB3F750 Offset: 0xB3F750 VA: 0xB3F750
	private void TickMapView() { }

	// RVA: 0xB3F848 Offset: 0xB3F848 VA: 0xB3F848
	private void RemoveListeners() { }

	// RVA: 0xB3F84C Offset: 0xB3F84C VA: 0xB3F84C Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB3F854 Offset: 0xB3F854 VA: 0xB3F854 Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xB3F934 Offset: 0xB3F934 VA: 0xB3F934
	public void OnObservableCharacterChanged(byte characterBID) { }
}
