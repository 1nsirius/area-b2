// Namespace: 
[AddComponentMenu] // RVA: 0x550290 Offset: 0x550290 VA: 0x550290
[RequireComponent] // RVA: 0x550290 Offset: 0x550290 VA: 0x550290
public class F2Dropdown : Dropdown // TypeDefIndex: 5479
{
	// Fields
	[SerializeField] // RVA: 0x55D7E0 Offset: 0x55D7E0 VA: 0x55D7E0
	private F2Dropdown.OnListVisibleChangeEvent m_OnListVisibleChange; // 0xC8
	[SerializeField] // RVA: 0x55D7F0 Offset: 0x55D7F0 VA: 0x55D7F0
	private RectTransform mArrow; // 0xCC

	// Properties
	public F2Dropdown.OnListVisibleChangeEvent OnListVisibleChange { get; }

	// Methods

	// RVA: 0xBC5508 Offset: 0xBC5508 VA: 0xBC5508
	public F2Dropdown.OnListVisibleChangeEvent get_OnListVisibleChange() { }

	// RVA: 0xBC5510 Offset: 0xBC5510 VA: 0xBC5510 Slot: 45
	protected override GameObject CreateBlocker(Canvas rootCanvas) { }

	// RVA: 0xBC5784 Offset: 0xBC5784 VA: 0xBC5784 Slot: 46
	protected override void DestroyBlocker(GameObject blocker) { }

	// RVA: 0xBC59F4 Offset: 0xBC59F4 VA: 0xBC59F4
	public void .ctor() { }
}
