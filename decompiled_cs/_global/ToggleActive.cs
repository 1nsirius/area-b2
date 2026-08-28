// Namespace: 
public class ToggleActive : MonoBehaviour // TypeDefIndex: 5493
{
	// Fields
	[FormerlySerializedAsAttribute] // RVA: 0x55DB88 Offset: 0x55DB88 VA: 0x55DB88
	[SerializeField] // RVA: 0x55DB88 Offset: 0x55DB88 VA: 0x55DB88
	private Toggle mToggle; // 0xC
	[FormerlySerializedAsAttribute] // RVA: 0x55DBD0 Offset: 0x55DBD0 VA: 0x55DBD0
	[SerializeField] // RVA: 0x55DBD0 Offset: 0x55DBD0 VA: 0x55DBD0
	private GameObject[] mActiveObjs; // 0x10
	[FormerlySerializedAsAttribute] // RVA: 0x55DC1C Offset: 0x55DC1C VA: 0x55DC1C
	[SerializeField] // RVA: 0x55DC1C Offset: 0x55DC1C VA: 0x55DC1C
	private GameObject[] mDisactiveObjs; // 0x14

	// Methods

	// RVA: 0xD8527C Offset: 0xD8527C VA: 0xD8527C
	private void Awake() { }

	// RVA: 0xD854B4 Offset: 0xD854B4 VA: 0xD854B4
	private void OnDestroy() { }

	// RVA: 0xD853C4 Offset: 0xD853C4 VA: 0xD853C4
	public void OnToggleChange(bool toggle) { }

	// RVA: 0xD855D0 Offset: 0xD855D0 VA: 0xD855D0
	public void .ctor() { }
}
