// Namespace: 
public class StringScrollListItem : MonoBehaviour // TypeDefIndex: 5706
{
	// Fields
	[SerializeField] // RVA: 0x55E7D0 Offset: 0x55E7D0 VA: 0x55E7D0
	[HeaderAttribute] // RVA: 0x55E7D0 Offset: 0x55E7D0 VA: 0x55E7D0
	private Image mImage; // 0xC
	[SerializeField] // RVA: 0x55E818 Offset: 0x55E818 VA: 0x55E818
	[HeaderAttribute] // RVA: 0x55E818 Offset: 0x55E818 VA: 0x55E818
	public Color BlueTeamBgColor; // 0x10
	[SerializeField] // RVA: 0x55E86C Offset: 0x55E86C VA: 0x55E86C
	[HeaderAttribute] // RVA: 0x55E86C Offset: 0x55E86C VA: 0x55E86C
	public Color OrangeTeamBgColor; // 0x20
	[SerializeField] // RVA: 0x55E8C0 Offset: 0x55E8C0 VA: 0x55E8C0
	[HeaderAttribute] // RVA: 0x55E8C0 Offset: 0x55E8C0 VA: 0x55E8C0
	private Text mTextUI; // 0x30
	[SerializeField] // RVA: 0x55E908 Offset: 0x55E908 VA: 0x55E908
	[HeaderAttribute] // RVA: 0x55E908 Offset: 0x55E908 VA: 0x55E908
	public Color BlueTeamTextColor; // 0x34
	[SerializeField] // RVA: 0x55E95C Offset: 0x55E95C VA: 0x55E95C
	[HeaderAttribute] // RVA: 0x55E95C Offset: 0x55E95C VA: 0x55E95C
	public Color OrangeTeamTextColor; // 0x44

	// Properties
	public string Text { get; }

	// Methods

	// RVA: 0xD80A14 Offset: 0xD80A14 VA: 0xD80A14
	private void Awake() { }

	// RVA: 0xD80AE0 Offset: 0xD80AE0 VA: 0xD80AE0
	private void SetText(string text) { }

	// RVA: 0xD8040C Offset: 0xD8040C VA: 0xD8040C
	public void SetText(string text, BattleTeam team) { }

	// RVA: 0xD808D0 Offset: 0xD808D0 VA: 0xD808D0
	public string get_Text() { }

	// RVA: 0xD80BA4 Offset: 0xD80BA4 VA: 0xD80BA4
	public void .ctor() { }
}
