// Namespace: 
public class AliSwipHeroController // TypeDefIndex: 5509
{
	// Fields
	private Transform m_RootBase; // 0x8
	private Transform m_GoTrans; // 0xC
	private bool m_isPress; // 0x10
	private Vector3 m_lastMousePos; // 0x14
	public bool m_bIsLerp; // 0x20
	public float m_swipeScale; // 0x24
	public float m_lerpSpeedScale; // 0x28
	public float m_iCloseLerpTime; // 0x2C
	public float m_iLerpTime; // 0x30
	public float m_fLerpSpeed; // 0x34
	private float m_willMoveModelDeltaV; // 0x38
	private float m_willMoveModelDeltaH; // 0x3C
	private bool m_bStartLerpModel; // 0x40
	private float m_fStartMoveTime; // 0x44
	private float m_fEndMoveTime; // 0x48
	private float m_fCurSpeed_X; // 0x4C
	private float m_iCurLerpTime; // 0x50
	private bool m_isOpenUpDownRotate; // 0x54
	public bool dragEnabled; // 0x55
	private bool dragEnd; // 0x56
	private Vector3 localAngle; // 0x58
	private Vector3 targetAngle; // 0x64
	private float m_swipeReturnScale; // 0x70
	private AliShowPropNode nodeSetting; // 0x74
	private bool isSetRotate; // 0x78
	private Vector3 tAngle; // 0x7C
	private float rspeed; // 0x88
	private float oldSetTime; // 0x8C
	private bool isRotateGoTrans; // 0x90
	private bool isAutoRotate; // 0x91
	private float isAutoSpeed; // 0x94

	// Methods

	// RVA: 0xCB0198 Offset: 0xCB0198 VA: 0xCB0198
	public void SetDragParms(GameObject pDragObj, Transform rootTrans) { }

	// RVA: 0xCB0404 Offset: 0xCB0404 VA: 0xCB0404
	public void SetEnableDrag(bool isEnable) { }

	// RVA: 0xCB02F4 Offset: 0xCB02F4 VA: 0xCB02F4
	public void SetNodeSetting(AliShowPropNode nodeSetting) { }

	// RVA: 0xCB5B60 Offset: 0xCB5B60 VA: 0xCB5B60
	public void SetGoTrans(Transform goTrans) { }

	// RVA: 0xCB02FC Offset: 0xCB02FC VA: 0xCB02FC
	public void SetParame(float swipeScale, float lerpSpeedScale = 0, bool isOpenUpDownRotate = False, float swipeReturnScale = 3) { }

	// RVA: 0xCB1760 Offset: 0xCB1760 VA: 0xCB1760
	public void CancelDrageTouch(GameObject pDrageObj) { }

	// RVA: 0xCB9D4C Offset: 0xCB9D4C VA: 0xCB9D4C
	private void OnBeginDrag(PointerEventData eventData) { }

	// RVA: 0xCB9DD4 Offset: 0xCB9DD4 VA: 0xCB9DD4
	private void OnEndDrag(PointerEventData eventData) { }

	// RVA: 0xCB2248 Offset: 0xCB2248 VA: 0xCB2248
	public void LateUpdate() { }

	// RVA: 0xCB040C Offset: 0xCB040C VA: 0xCB040C
	public void rotateAngle(Vector3 angle, float rspeed = 5, bool isRotateGoTrans = False) { }

	// RVA: 0xCB82B8 Offset: 0xCB82B8 VA: 0xCB82B8
	public void AutoRotate(bool isAuto = True, float speed = 0,3) { }

	// RVA: 0xCBA454 Offset: 0xCBA454 VA: 0xCBA454
	private Vector3 GetForward() { }

	// RVA: 0xCB9EC4 Offset: 0xCB9EC4 VA: 0xCB9EC4
	private void ProcessSwipeHeroModel2() { }

	// RVA: 0xCBA234 Offset: 0xCBA234 VA: 0xCBA234
	private void LarpMoveModel(float deltaH, float deltaV) { }

	// RVA: 0xCBA6A8 Offset: 0xCBA6A8 VA: 0xCBA6A8
	private void ResetLerpModel() { }

	// RVA: 0xCBA6BC Offset: 0xCBA6BC VA: 0xCBA6BC
	private float GetCurAngleHorizontal() { }

	// RVA: 0xCBA790 Offset: 0xCBA790 VA: 0xCBA790
	private float GetCurAngleVerticality() { }

	// RVA: 0xCBA864 Offset: 0xCBA864 VA: 0xCBA864
	private void SetCurAngle(float angleH, float angleV) { }

	// RVA: 0xCB9D78 Offset: 0xCB9D78 VA: 0xCB9D78
	private void BeginSwipeHeroModel() { }

	// RVA: 0xCBA960 Offset: 0xCBA960 VA: 0xCBA960
	private void OnSwipeHeroModel(float deltaH, float deltaV) { }

	// RVA: 0xCB9DD8 Offset: 0xCB9DD8 VA: 0xCB9DD8
	private void EndSwipeHeroModel() { }

	// RVA: 0xCB2E90 Offset: 0xCB2E90 VA: 0xCB2E90
	public void .ctor() { }
}
