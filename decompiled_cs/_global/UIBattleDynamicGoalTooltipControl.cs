// Namespace: 
public class UIBattleDynamicGoalTooltipControl : BaseView // TypeDefIndex: 5744
{
	// Fields
	public const float ARROW_RADIUS = 50;
	public const float TOOLTIP_WIDTH = 200;
	private GameObject _tooltipClone; // 0x30
	private RectTransform _tooltipsParent; // 0x34
	private bool _tooltipsIsDirty; // 0x38
	private readonly List<DynamicGoalTooltip> _tooltips; // 0x3C
	private readonly List<DynamicGoalTooltip> _tooltipsCopy; // 0x40
	private IActorProxy actorProxy; // 0x44
	private Transform worldViewCamTran; // 0x48
	private BattleCamp _battleCamp; // 0x4C

	// Methods

	// RVA: 0xB27140 Offset: 0xB27140 VA: 0xB27140
	public void .ctor() { }

	// RVA: 0xB271F8 Offset: 0xB271F8 VA: 0xB271F8 Slot: 19
	public override void InitViews() { }

	// RVA: 0xB272F8 Offset: 0xB272F8 VA: 0xB272F8 Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB272FC Offset: 0xB272FC VA: 0xB272FC Slot: 21
	public override void Init() { }

	// RVA: 0xB27A2C Offset: 0xB27A2C VA: 0xB27A2C
	private void RemoveListeners() { }

	// RVA: 0xB274C4 Offset: 0xB274C4 VA: 0xB274C4
	private void Instance_OnDynamicGoalCreatedEvt(IEnumerable<IDynamicGoalProxy> proxies) { }

	// RVA: 0xB27A30 Offset: 0xB27A30 VA: 0xB27A30
	public void AddTooltip(IDynamicGoalProxy proxy) { }

	// RVA: 0xB27BF8 Offset: 0xB27BF8 VA: 0xB27BF8
	private void AddTooltip(DynamicGoalTooltip tooltip) { }

	// RVA: 0xB27C80 Offset: 0xB27C80 VA: 0xB27C80
	private void RemoveTooltip(DynamicGoalTooltip tooltip) { }

	// RVA: 0xB27D24 Offset: 0xB27D24 VA: 0xB27D24 Slot: 25
	public override void OnLateTick() { }

	// RVA: 0xB27D28 Offset: 0xB27D28 VA: 0xB27D28
	protected void OnUpdate() { }

	// RVA: 0xB28000 Offset: 0xB28000 VA: 0xB28000
	private void UpdateTooltipsCopy() { }

	// RVA: 0xB281B0 Offset: 0xB281B0 VA: 0xB281B0 Slot: 27
	public override void OnViewDestroy() { }
}
