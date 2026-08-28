// Namespace: 
public class UIBattleFPEffectsControl : BaseView // TypeDefIndex: 5760
{
	// Fields
	public const int MaxDamageWarningArrowImgCount = 5;
	public const float ArrowEaseInMaxTime = 0,26666668;
	public const float ArrowStaticallyMaxTime = 1,7333333;
	public const float ArrowEaseOutMaxTime = 2;
	public static float DamageEffectRadius; // 0x0
	public const float ArrowVoiceEaseInMaxTime = 0,26666668;
	public const float ArrowVoiceStaticallyMaxTime = 0,73333335;
	public const float ArrowVoiceEaseOutMaxTime = 1;
	public static float AngleThreshouldCos; // 0x4
	private Transform _arrowParentTran; // 0x30
	private GameObject _damageWarningArrowCloneImg; // 0x34
	private Transform _arrowVoiceParentTran; // 0x38
	private GameObject _damageVoiceWarningArrowCloneImg; // 0x3C
	private readonly List<UIBattleFPEffectsControl.DamageArrow> _arrows; // 0x40
	private bool _arrowIsDirty; // 0x44
	private readonly List<UIBattleFPEffectsControl.DamageArrow> _arrowsCopy; // 0x48
	private readonly Queue<UIBattleFPEffectsControl.DamageArrow> _arrowCache; // 0x4C
	private readonly Queue<UIBattleFPEffectsControl.DamageArrow> _arrowVoiceCache; // 0x50
	private UIBattleFPEffectsControl.FullScreenEffect _f0; // 0x54
	private UIBattleFPEffectsControl.FullScreenSwitchEffect _f2; // 0x58
	private Dictionary<UIScreenEffectType, BaseUIScreenEffect> mUIScreenEffectsDic; // 0x5C
	private MainCharacterController mainCtrl; // 0x60

	// Methods

	// RVA: 0xB35DAC Offset: 0xB35DAC VA: 0xB35DAC
	public void .ctor() { }

	// RVA: 0xB35EE8 Offset: 0xB35EE8 VA: 0xB35EE8 Slot: 19
	public override void InitViews() { }

	// RVA: 0xB367BC Offset: 0xB367BC VA: 0xB367BC Slot: 20
	public override void AddListeners() { }

	// RVA: 0xB36A08 Offset: 0xB36A08 VA: 0xB36A08
	private void World_onPlayScreenEffectEvt(UIScreenEffectType type) { }

	// RVA: 0xB36AB8 Offset: 0xB36AB8 VA: 0xB36AB8 Slot: 21
	public override void Init() { }

	// RVA: 0xB36B88 Offset: 0xB36B88 VA: 0xB36B88
	private void MainCtrl_onPlayerBeDamageEvt(BattleSceneRoot.IVictimInfo cameraInfo, Nullable<Vector3> damageSource) { }

	// RVA: 0xB37E14 Offset: 0xB37E14 VA: 0xB37E14
	private void Instance_onPlayerBeShootEvt(BattleSceneRoot.IVictimInfo cameraInfo, Vector3 damagePos) { }

	// RVA: 0xB372D8 Offset: 0xB372D8 VA: 0xB372D8
	private bool IsLessThenResetAngle(ref Vector3 v0, ref Vector3 v1, float angleThreshouldCos) { }

	// RVA: 0xB35F0C Offset: 0xB35F0C VA: 0xB35F0C
	private void AddDamageWarningEffects() { }

	// RVA: 0xB364F0 Offset: 0xB364F0 VA: 0xB364F0
	private void AddFullScreenEffects() { }

	// RVA: 0xB36658 Offset: 0xB36658 VA: 0xB36658
	private void AddUIScreenEffects() { }

	// RVA: 0xB38824 Offset: 0xB38824 VA: 0xB38824
	private void RemoveListener() { }

	// RVA: 0xB38A70 Offset: 0xB38A70 VA: 0xB38A70
	public void ShowSwitchEffect(bool show = True) { }

	// RVA: 0xB38B2C Offset: 0xB38B2C VA: 0xB38B2C Slot: 22
	public override void OnMessage(object sender, object[] args) { }

	// RVA: 0xB38EB8 Offset: 0xB38EB8 VA: 0xB38EB8 Slot: 24
	public override void OnTick() { }

	// RVA: 0xB38EEC Offset: 0xB38EEC VA: 0xB38EEC
	private void UpdateDamageImgs(float deltaTime) { }

	// RVA: 0xB390D4 Offset: 0xB390D4 VA: 0xB390D4
	private void UpdateArrowEffects(float deltaTime) { }

	// RVA: 0xB392A0 Offset: 0xB392A0 VA: 0xB392A0
	private void UpdateArrowsCopy() { }

	// RVA: 0xB38C9C Offset: 0xB38C9C VA: 0xB38C9C
	public void ClearAllEffect() { }

	// RVA: 0xB39750 Offset: 0xB39750 VA: 0xB39750
	private void ClearUIScreenEffects() { }

	// RVA: 0xB38EF0 Offset: 0xB38EF0 VA: 0xB38EF0
	private void UpdateScreenBlood(float deltaTime) { }

	// RVA: 0xB39628 Offset: 0xB39628 VA: 0xB39628
	private void RemoveArrow(UIBattleFPEffectsControl.DamageArrow arrow) { }

	// RVA: 0xB377E0 Offset: 0xB377E0 VA: 0xB377E0
	private void AddArrow(UIBattleFPEffectsControl.DamageArrow arrow) { }

	// RVA: 0xB37344 Offset: 0xB37344 VA: 0xB37344
	private UIBattleFPEffectsControl.DamageArrow GetUnUsedArrow(int type = 0) { }

	// RVA: 0xB39940 Offset: 0xB39940 VA: 0xB39940 Slot: 27
	public override void OnViewDestroy() { }

	// RVA: 0xB39960 Offset: 0xB39960 VA: 0xB39960
	private static void .cctor() { }
}
