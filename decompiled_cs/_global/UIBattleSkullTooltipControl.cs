// Namespace: 
public class UIBattleSkullTooltipControl : BaseView // TypeDefIndex: 5801
{
	// Fields
	public const float EaseOutTimeStamp = 1;
	public const float SkullDuration = 2;
	private RectTransform _tooltipsParent; // 0x30
	private GameObject _tooltipClone; // 0x34
	private bool _tooltipsIsDirty; // 0x38
	private readonly List<UIBattleSkullTooltipControl.SkullTooltip> _tooltips; // 0x3C
	private readonly List<UIBattleSkullTooltipControl.SkullTooltip> _tooltipsCopy; // 0x40
	private const int UNUSED_TOOLTIP_GAMEOBJECT_COUNT = 2;
	private Queue<GameObject> _unUsedTooltipGameObjects; // 0x44

	// Methods

	// RVA: 0xAEA2AC Offset: 0xAEA2AC VA: 0xAEA2AC
	public void .ctor() { }

	// RVA: 0xAEA39C Offset: 0xAEA39C VA: 0xAEA39C Slot: 19
	public override void InitViews() { }

	// RVA: 0xAEA584 Offset: 0xAEA584 VA: 0xAEA584 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xAEA698 Offset: 0xAEA698 VA: 0xAEA698
	private void RemoveListeners() { }

	// RVA: 0xAEA7AC Offset: 0xAEA7AC VA: 0xAEA7AC
	private void AddTooltip(UIBattleSkullTooltipControl.SkullTooltip tooltip) { }

	// RVA: 0xAEA834 Offset: 0xAEA834 VA: 0xAEA834
	private bool RemoveTooltip(UIBattleSkullTooltipControl.SkullTooltip tooltip) { }

	// RVA: 0xAEA95C Offset: 0xAEA95C VA: 0xAEA95C
	private void Instance_OnPlayerDeathEvt(RspPlayerDeath obj) { }

	// RVA: 0xAEAC34 Offset: 0xAEAC34 VA: 0xAEAC34
	private UIBattleSkullTooltipControl.SkullTooltip CreateSkullTooltip(RspPlayerDeath data) { }

	// RVA: 0xAEAE08 Offset: 0xAEAE08 VA: 0xAEAE08
	private GameObject GetTooltipGo() { }

	// RVA: 0xAEAF00 Offset: 0xAEAF00 VA: 0xAEAF00
	private Vector3 GetCharacterPosById(byte id) { }

	// RVA: 0xAEB324 Offset: 0xAEB324 VA: 0xAEB324 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xAEB4E0 Offset: 0xAEB4E0 VA: 0xAEB4E0
	private void UpdateTooltipsCopy() { }

	// RVA: 0xAEB9E4 Offset: 0xAEB9E4 VA: 0xAEB9E4 Slot: 27
	public override void OnViewDestroy() { }
}
