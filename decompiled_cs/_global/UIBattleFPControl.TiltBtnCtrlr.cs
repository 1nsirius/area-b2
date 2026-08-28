// Namespace: 
private class UIBattleFPControl.TiltBtnCtrlr : IUiNodeCtrlr, IDisposable // TypeDefIndex: 5756
{
	// Fields
	private UIBattleFPControl.Node mBtnLeftTilt; // 0x8
	private UIBattleFPControl.Node mBtnRightTilt; // 0xC
	private PressButton mPressBtnLeft; // 0x10
	private PressButton mPressBtnRight; // 0x14
	private bool mTiltleft; // 0x18
	private bool mTiltright; // 0x19

	// Properties
	private MainCharacterController mainCtrl { get; }

	// Methods

	// RVA: 0xB34F60 Offset: 0xB34F60 VA: 0xB34F60
	private MainCharacterController get_mainCtrl() { }

	// RVA: 0xB3501C Offset: 0xB3501C VA: 0xB3501C Slot: 6
	public void Dispose() { }

	// RVA: 0xB32D24 Offset: 0xB32D24 VA: 0xB32D24 Slot: 4
	public void SetEnable(bool en) { }

	// RVA: 0xB35060 Offset: 0xB35060 VA: 0xB35060 Slot: 5
	public void Update() { }

	// RVA: 0xB291C8 Offset: 0xB291C8 VA: 0xB291C8
	public void Init(RectTransform parentTransform, GameObject dragPanel) { }

	// RVA: 0xB351F8 Offset: 0xB351F8 VA: 0xB351F8
	private void OnBtnLeftTiltToggle() { }

	// RVA: 0xB352B4 Offset: 0xB352B4 VA: 0xB352B4
	private void OnBtnLeftTiltToggleOff() { }

	// RVA: 0xB35314 Offset: 0xB35314 VA: 0xB35314
	private void OnBtnLeftTiltToggleOn() { }

	// RVA: 0xB35378 Offset: 0xB35378 VA: 0xB35378
	private void OnBtnRightTiltToggle() { }

	// RVA: 0xB35434 Offset: 0xB35434 VA: 0xB35434
	private void OnBtnRightTiltToggleOff() { }

	// RVA: 0xB35494 Offset: 0xB35494 VA: 0xB35494
	private void OnBtnRightTiltToggleOn() { }

	// RVA: 0xB354F8 Offset: 0xB354F8 VA: 0xB354F8
	private static void UpdateDragAble(UIEventListener listener) { }

	// RVA: 0xB35648 Offset: 0xB35648 VA: 0xB35648
	private void UpdateLeftTilt() { }

	// RVA: 0xB359F0 Offset: 0xB359F0 VA: 0xB359F0
	private void UpdateRightTilt() { }

	// RVA: 0xB35D98 Offset: 0xB35D98 VA: 0xB35D98
	public void .ctor() { }
}
