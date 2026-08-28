// Namespace: 
[DisallowMultipleComponent] // RVA: 0x55034C Offset: 0x55034C VA: 0x55034C
[ExecuteAlways] // RVA: 0x55034C Offset: 0x55034C VA: 0x55034C
[RequireComponent] // RVA: 0x55034C Offset: 0x55034C VA: 0x55034C
public class CircleLayoutGroup : UIBehaviour, ILayoutGroup, ILayoutController // TypeDefIndex: 5484
{
	// Fields
	[HeaderAttribute] // RVA: 0x55D820 Offset: 0x55D820 VA: 0x55D820
	[SerializeField] // RVA: 0x55D820 Offset: 0x55D820 VA: 0x55D820
	private bool mDeltaOrTotal; // 0xC
	[HeaderAttribute] // RVA: 0x55D880 Offset: 0x55D880 VA: 0x55D880
	[SerializeField] // RVA: 0x55D880 Offset: 0x55D880 VA: 0x55D880
	private float mDeltaAngle; // 0x10
	[HeaderAttribute] // RVA: 0x55D8D4 Offset: 0x55D8D4 VA: 0x55D8D4
	[SerializeField] // RVA: 0x55D8D4 Offset: 0x55D8D4 VA: 0x55D8D4
	private float mTotalAngle; // 0x14
	[HeaderAttribute] // RVA: 0x55D928 Offset: 0x55D928 VA: 0x55D928
	[SerializeField] // RVA: 0x55D928 Offset: 0x55D928 VA: 0x55D928
	private float mRadius; // 0x18
	[HeaderAttribute] // RVA: 0x55D970 Offset: 0x55D970 VA: 0x55D970
	[SerializeField] // RVA: 0x55D970 Offset: 0x55D970 VA: 0x55D970
	private bool mClockwise; // 0x1C
	[HeaderAttribute] // RVA: 0x55D9BC Offset: 0x55D9BC VA: 0x55D9BC
	[SerializeField] // RVA: 0x55D9BC Offset: 0x55D9BC VA: 0x55D9BC
	private float mStartAngle; // 0x20
	[HeaderAttribute] // RVA: 0x55DA0C Offset: 0x55DA0C VA: 0x55DA0C
	[SerializeField] // RVA: 0x55DA0C Offset: 0x55DA0C VA: 0x55DA0C
	private TextAnchor mCircleCenter; // 0x24
	[HeaderAttribute] // RVA: 0x55DA5C Offset: 0x55DA5C VA: 0x55DA5C
	[SerializeField] // RVA: 0x55DA5C Offset: 0x55DA5C VA: 0x55DA5C
	private bool mMiddle; // 0x28
	[HeaderAttribute] // RVA: 0x55DAA4 Offset: 0x55DAA4 VA: 0x55DAA4
	[SerializeField] // RVA: 0x55DAA4 Offset: 0x55DAA4 VA: 0x55DAA4
	private bool mIncludeInactiveChild; // 0x29
	private readonly Vector2 mAnchorMinMax; // 0x2C
	private bool mIsDirty; // 0x34
	private RectTransform m_Rect; // 0x38
	private List<Transform> mChildList; // 0x3C

	// Properties
	protected RectTransform rectTransform { get; }

	// Methods

	// RVA: 0xD51D68 Offset: 0xD51D68 VA: 0xD51D68
	protected RectTransform get_rectTransform() { }

	// RVA: 0xD51E1C Offset: 0xD51E1C VA: 0xD51E1C
	public int GetDirIndex(Vector2 dir) { }

	// RVA: 0xD520E0 Offset: 0xD520E0 VA: 0xD520E0
	public bool GetIndexAngle(int index, out float angle) { }

	// RVA: 0xD522C4 Offset: 0xD522C4 VA: 0xD522C4 Slot: 17
	public void SetLayoutHorizontal() { }

	// RVA: 0xD522D0 Offset: 0xD522D0 VA: 0xD522D0 Slot: 18
	public void SetLayoutVertical() { }

	// RVA: 0xD522DC Offset: 0xD522DC VA: 0xD522DC
	private void Update() { }

	// RVA: 0xD52ACC Offset: 0xD52ACC VA: 0xD52ACC Slot: 5
	protected override void OnEnable() { }

	// RVA: 0xD52AEC Offset: 0xD52AEC VA: 0xD52AEC Slot: 7
	protected override void OnDisable() { }

	// RVA: 0xD52AF4 Offset: 0xD52AF4 VA: 0xD52AF4 Slot: 13
	protected override void OnDidApplyAnimationProperties() { }

	// RVA: 0xD52B00 Offset: 0xD52B00 VA: 0xD52B00 Slot: 19
	protected virtual void OnTransformChildrenChanged() { }

	// RVA: 0xD52B0C Offset: 0xD52B0C VA: 0xD52B0C Slot: 10
	protected override void OnRectTransformDimensionsChange() { }

	// RVA: 0xD52B18 Offset: 0xD52B18 VA: 0xD52B18 Slot: 15
	protected override void OnCanvasHierarchyChanged() { }

	// RVA: 0xD52898 Offset: 0xD52898 VA: 0xD52898
	private void RebuildChildList() { }

	// RVA: 0xD52B24 Offset: 0xD52B24 VA: 0xD52B24
	public void .ctor() { }
}
