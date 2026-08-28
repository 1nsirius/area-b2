// Namespace: 
public class UIBattleCharactersTooltipControl : BaseView // TypeDefIndex: 5733
{
	// Fields
	private bool _tooltipsIsDirty; // 0x30
	private readonly List<UIBattleCharactersTooltipControl.CharacterTooltip> _tooltips; // 0x34
	private readonly List<UIBattleCharactersTooltipControl.CharacterTooltip> _tooltipsCopy; // 0x38
	private GameObject _tooltipClone; // 0x3C
	private BattleCamp _battleCamp; // 0x40

	// Methods

	// RVA: 0xD89E0C Offset: 0xD89E0C VA: 0xD89E0C
	public void .ctor() { }

	// RVA: 0xD89EC4 Offset: 0xD89EC4 VA: 0xD89EC4 Slot: 19
	public override void InitViews() { }

	// RVA: 0xD89F70 Offset: 0xD89F70 VA: 0xD89F70 Slot: 21
	public override void Init() { }

	// RVA: 0xD8A0B4 Offset: 0xD8A0B4 VA: 0xD8A0B4
	public void InstantiatesTooltips() { }

	// RVA: 0xD8B610 Offset: 0xD8B610 VA: 0xD8B610 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xD8B618 Offset: 0xD8B618 VA: 0xD8B618 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xD8B61C Offset: 0xD8B61C VA: 0xD8B61C
	protected void OnUpdate() { }

	// RVA: 0xD8C0B8 Offset: 0xD8C0B8 VA: 0xD8C0B8
	private void UpdateTooltipsCopy() { }

	// RVA: 0xD8C340 Offset: 0xD8C340 VA: 0xD8C340
	private bool RemoveTooltip(UIBattleCharactersTooltipControl.CharacterTooltip tooltip) { }

	// RVA: 0xD8B588 Offset: 0xD8B588 VA: 0xD8B588
	private void AddTooltip(UIBattleCharactersTooltipControl.CharacterTooltip tooltip) { }
}
