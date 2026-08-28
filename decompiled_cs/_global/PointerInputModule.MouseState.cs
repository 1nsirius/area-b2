// Namespace: 
protected class PointerInputModule.MouseState // TypeDefIndex: 4010
{
	// Fields
	private List<PointerInputModule.ButtonState> m_TrackedButtons; // 0x8

	// Methods

	// RVA: 0x161A980 Offset: 0x161A980 VA: 0x161A980
	public void .ctor() { }

	// RVA: 0x161C3B0 Offset: 0x161C3B0 VA: 0x161C3B0
	public bool AnyPressesThisFrame() { }

	// RVA: 0x161C4AC Offset: 0x161C4AC VA: 0x161C4AC
	public bool AnyReleasesThisFrame() { }

	// RVA: 0x161C5A8 Offset: 0x161C5A8 VA: 0x161C5A8
	public PointerInputModule.ButtonState GetButtonState(PointerEventData.InputButton button) { }

	// RVA: 0x161B7AC Offset: 0x161B7AC VA: 0x161B7AC
	public void SetButtonState(PointerEventData.InputButton button, PointerEventData.FramePressState stateForMouseButton, PointerEventData data) { }
}
