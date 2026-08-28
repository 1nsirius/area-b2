// Namespace: 
public class UIBattleCharactersTooltipControl.CharacterTooltip // TypeDefIndex: 5742
{
	// Fields
	public GameObject tooltipGo; // 0x8
	private RectTransform _tran; // 0xC
	public ICharacterProxy proxy; // 0x10
	private HPComponent1 _hpComp; // 0x14
	private static readonly Color NormalColor; // 0x0
	private static readonly Color WarningColor; // 0x10
	private Rect _clampRect; // 0x18
	public const float ARROW_RADIUS = 50;
	public const float TOOLTIP_WIDTH = 200;
	private UIBattleCharactersTooltipControl.NormalTooltipData _normalTooltipData; // 0x28
	private UIBattleCharactersTooltipControl.OldTooltipData _oldTooltipData; // 0x68
	private UIBattleCharactersTooltipControl.BloodType mCurBloodType; // 0x9C

	// Methods

	// RVA: 0xD8A524 Offset: 0xD8A524 VA: 0xD8A524
	public void .ctor(ICharacterProxy proxy, GameObject go) { }

	// RVA: 0xD8C3E0 Offset: 0xD8C3E0 VA: 0xD8C3E0
	public void Tick(float deltaTime, byte characterBID, BattleCamp camp, ref Vector3 selfPos, GameStage gameStage, bool isFPControlEnabled, bool isMiniCarControlEnabled, bool isSurveillanceCamControlEnabled, bool isAimTarget) { }

	// RVA: 0xD8E174 Offset: 0xD8E174 VA: 0xD8E174
	private void UpdateNormal(bool isFPControlEnabled, ref Vector3 selfPos, bool isExposed = False) { }

	// RVA: 0xD8EF90 Offset: 0xD8EF90 VA: 0xD8EF90
	private void UpdateNormalNotSameCamp(bool isFPControlEnabled, ref Vector3 selfPos, bool isExposed = False) { }

	// RVA: 0xD8F5EC Offset: 0xD8F5EC VA: 0xD8F5EC
	private Vector2 CalcPosition(Vector3 screenPos) { }

	// RVA: 0xD8F9C0 Offset: 0xD8F9C0 VA: 0xD8F9C0
	private static float CalcXByY(float Y, Vector2 center, float k) { }

	// RVA: 0xD8F99C Offset: 0xD8F99C VA: 0xD8F99C
	private static float CalcYByX(float k, float a, Vector2 center) { }

	// RVA: 0xD8E7B8 Offset: 0xD8E7B8 VA: 0xD8E7B8
	private void SetBloodUIColor(Color color) { }

	// RVA: 0xD8E0D4 Offset: 0xD8E0D4 VA: 0xD8E0D4
	private void SetOldUIColor(Color color) { }

	// RVA: 0xD8D9B4 Offset: 0xD8D9B4 VA: 0xD8D9B4
	private void UpdateOld(ref Vector3 selfPos) { }

	// RVA: 0xD8E824 Offset: 0xD8E824 VA: 0xD8E824
	private void UpdateEnemyBeExposed(Vector3 selfPos) { }

	// RVA: 0xD8A5B8 Offset: 0xD8A5B8 VA: 0xD8A5B8
	public void Init(BattleCamp camp) { }

	// RVA: 0xD8D814 Offset: 0xD8D814 VA: 0xD8D814
	private void UpdateAgnolProgress() { }

	// RVA: 0xD8CEC8 Offset: 0xD8CEC8 VA: 0xD8CEC8
	private void UpdateBloodProgress() { }

	// RVA: 0xD8F9E4 Offset: 0xD8F9E4 VA: 0xD8F9E4
	private Vector3 GetRectBoundaryPos(Vector3 pos) { }

	// RVA: 0xD8FC2C Offset: 0xD8FC2C VA: 0xD8FC2C
	public void UpdateArrowTran(ref Vector3 pos, Transform viewCamTran, RectTransform arrowRt) { }

	// RVA: 0xD8C268 Offset: 0xD8C268 VA: 0xD8C268
	public bool IsDead() { }

	// RVA: 0xD8CCF4 Offset: 0xD8CCF4 VA: 0xD8CCF4
	public void Destroy() { }

	// RVA: 0xD8FD34 Offset: 0xD8FD34 VA: 0xD8FD34
	private static void .cctor() { }
}
