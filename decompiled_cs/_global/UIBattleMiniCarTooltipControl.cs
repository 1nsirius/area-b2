// Namespace: 
public class UIBattleMiniCarTooltipControl : BaseView // TypeDefIndex: 5783
{
	// Fields
	private GameObject _tooltipClone; // 0x30
	private RectTransform _tooltipsParent; // 0x34
	private bool _tooltipsIsDirty; // 0x38
	private readonly List<UIBattleMiniCarTooltipControl.MiniCarTooltip> _tooltips; // 0x3C
	private readonly List<UIBattleMiniCarTooltipControl.MiniCarTooltip> _tooltipsCopy; // 0x40
	private IActorProxy actorProxy; // 0x44

	// Methods

	// RVA: 0xADA1F0 Offset: 0xADA1F0 VA: 0xADA1F0
	public void .ctor() { }

	// RVA: 0xADA2A8 Offset: 0xADA2A8 VA: 0xADA2A8 Slot: 19
	public override void InitViews() { }

	// RVA: 0xADA3A8 Offset: 0xADA3A8 VA: 0xADA3A8 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xADA3B0 Offset: 0xADA3B0 VA: 0xADA3B0 Slot: 21
	public override void Init() { }

	// RVA: 0xADA3B4 Offset: 0xADA3B4 VA: 0xADA3B4
	private void InstantiatesTooltips() { }

	// RVA: 0xADA8B4 Offset: 0xADA8B4 VA: 0xADA8B4
	public void AddTooltip(IMiniCarProxy proxy) { }

	// RVA: 0xADAF30 Offset: 0xADAF30 VA: 0xADAF30
	private void AddTooltip(UIBattleMiniCarTooltipControl.MiniCarTooltip tooltip) { }

	// RVA: 0xADAFB8 Offset: 0xADAFB8 VA: 0xADAFB8
	private bool RemoveTooltip(UIBattleMiniCarTooltipControl.MiniCarTooltip tooltip) { }

	// RVA: 0xADB0E0 Offset: 0xADB0E0 VA: 0xADB0E0 Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xADB178 Offset: 0xADB178 VA: 0xADB178
	public void ReplaceViewActor(IActorProxy proxy) { }

	// RVA: 0xADB180 Offset: 0xADB180 VA: 0xADB180 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xADB614 Offset: 0xADB614 VA: 0xADB614
	private void UpdateTooltipsCopy() { }
}
