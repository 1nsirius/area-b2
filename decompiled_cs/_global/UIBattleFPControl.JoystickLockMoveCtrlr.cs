// Namespace: 
private class UIBattleFPControl.JoystickLockMoveCtrlr // TypeDefIndex: 5751
{
	// Fields
	private RectTransform mHighLit; // 0x8
	private Image mBgImage; // 0xC
	private RectTransform mRoot; // 0x10
	private RectTransform mUiRoot; // 0x14
	private bool mVisible; // 0x18

	// Properties
	private Vector2 mOffset { get; }
	private float mVisibleDistance { get; }

	// Methods

	// RVA: 0xB34514 Offset: 0xB34514 VA: 0xB34514
	private Vector2 get_mOffset() { }

	// RVA: 0xB34560 Offset: 0xB34560 VA: 0xB34560
	private float get_mVisibleDistance() { }

	// RVA: 0xB31A14 Offset: 0xB31A14 VA: 0xB31A14
	public void Init(RectTransform parentTransform) { }

	// RVA: 0xB33B28 Offset: 0xB33B28 VA: 0xB33B28
	public void OnPointerUp(Vector2 position) { }

	// RVA: 0xB337AC Offset: 0xB337AC VA: 0xB337AC
	public void Update(UIJoystick joystick) { }

	// RVA: 0xB346B8 Offset: 0xB346B8 VA: 0xB346B8
	private bool CalcVisible(UIJoystick joystick) { }

	// RVA: 0xB345A8 Offset: 0xB345A8 VA: 0xB345A8
	private bool IsFingerInRect(Vector2 position) { }

	// RVA: 0xB347E8 Offset: 0xB347E8 VA: 0xB347E8
	private void SetHighLit(bool highLit) { }

	// RVA: 0xB347A4 Offset: 0xB347A4 VA: 0xB347A4
	private bool SetVisible(bool v) { }

	// RVA: 0xB31A0C Offset: 0xB31A0C VA: 0xB31A0C
	public void .ctor() { }
}
