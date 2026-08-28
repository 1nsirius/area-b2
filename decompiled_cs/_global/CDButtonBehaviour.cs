// Namespace: 
public class CDButtonBehaviour : MonoBehaviour // TypeDefIndex: 5613
{
	// Fields
	private Button _btn; // 0xC
	private Image _background; // 0x10
	private Image _fg; // 0x14
	private float _backGroundAlpha; // 0x18
	private Image _ring; // 0x1C
	private float duration; // 0x20
	private float _startTime; // 0x24
	public bool _enable; // 0x28
	public bool needSetColor; // 0x29
	public bool reverseVal; // 0x2A
	public bool needHideRing; // 0x2B

	// Methods

	// RVA: 0xD4C750 Offset: 0xD4C750 VA: 0xD4C750
	private void Awake() { }

	// RVA: 0xD4C928 Offset: 0xD4C928 VA: 0xD4C928
	private void Update() { }

	// RVA: 0xD4CBA4 Offset: 0xD4CBA4 VA: 0xD4CBA4
	private void SetCDButtonGrey(bool gray = True) { }

	// RVA: 0xD4CCF8 Offset: 0xD4CCF8 VA: 0xD4CCF8
	private void OnDisable() { }

	// RVA: 0xD4CD00 Offset: 0xD4CD00 VA: 0xD4CD00
	public static void PerformCDOperation(GameObject go, float duration, bool needSetColor = True, bool reverseVal = True, bool needHideRing = False) { }

	// RVA: 0xD4CF54 Offset: 0xD4CF54 VA: 0xD4CF54
	public static bool IsPerformingCDOperation(GameObject go) { }

	// RVA: 0xD4D034 Offset: 0xD4D034 VA: 0xD4D034
	public static void CanclePerformCDOperation(GameObject go) { }

	// RVA: 0xD4D264 Offset: 0xD4D264 VA: 0xD4D264
	public void .ctor() { }
}
