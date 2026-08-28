// Namespace: 
[LuaCallCSharpAttribute] // RVA: 0x55027C Offset: 0x55027C VA: 0x55027C
public class CustomToggleGroup : MonoBehaviour // TypeDefIndex: 5476
{
	// Fields
	[SerializeField] // RVA: 0x55D7C0 Offset: 0x55D7C0 VA: 0x55D7C0
	private List<Toggle> mList; // 0xC
	public CustomToggleGroup.ToggleEvent OnSelectedIndexChange; // 0x10
	[CompilerGeneratedAttribute] // RVA: 0x55D7D0 Offset: 0x55D7D0 VA: 0x55D7D0
	private int <SelectedIndex>k__BackingField; // 0x14

	// Properties
	public int SelectedIndex { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x579CF4 Offset: 0x579CF4 VA: 0x579CF4
	// RVA: 0xD63914 Offset: 0xD63914 VA: 0xD63914
	public int get_SelectedIndex() { }

	[CompilerGeneratedAttribute] // RVA: 0x579D04 Offset: 0x579D04 VA: 0x579D04
	// RVA: 0xD6391C Offset: 0xD6391C VA: 0xD6391C
	private void set_SelectedIndex(int value) { }

	// RVA: 0xD63924 Offset: 0xD63924 VA: 0xD63924
	public void Select(int index) { }

	// RVA: 0xD63AB0 Offset: 0xD63AB0 VA: 0xD63AB0
	private void Start() { }

	// RVA: 0xD63D4C Offset: 0xD63D4C VA: 0xD63D4C
	private void HandleOnValueChange(bool isOn) { }

	// RVA: 0xD63E80 Offset: 0xD63E80 VA: 0xD63E80
	public void .ctor() { }
}
