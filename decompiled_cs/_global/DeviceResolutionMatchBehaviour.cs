// Namespace: 
[ExecuteInEditMode] // RVA: 0x550B08 Offset: 0x550B08 VA: 0x550B08
public class DeviceResolutionMatchBehaviour : MonoBehaviour // TypeDefIndex: 5629
{
	// Fields
	[HeaderAttribute] // RVA: 0x55E134 Offset: 0x55E134 VA: 0x55E134
	public Vector2Int targetResolution; // 0xC
	private RectTransform _rt; // 0x14
	private float _targetAspect; // 0x18
	private float _curAspect; // 0x1C
	public bool pitchFullScreen; // 0x20
	[RangeAttribute] // RVA: 0x55E168 Offset: 0x55E168 VA: 0x55E168
	public float pitchMultiplier; // 0x24
	public float mHalfWidthShift; // 0x28
	private float _curScreenWidth; // 0x2C
	private float _curScreenHeight; // 0x30
	private float _thresholdAspect; // 0x34

	// Methods

	// RVA: 0xD132D4 Offset: 0xD132D4 VA: 0xD132D4
	private void Awake() { }

	// RVA: 0xD13394 Offset: 0xD13394 VA: 0xD13394
	private void Start() { }

	// RVA: 0xD1345C Offset: 0xD1345C VA: 0xD1345C
	private void SetResolution(float curAspect) { }

	// RVA: 0xD137AC Offset: 0xD137AC VA: 0xD137AC
	public float GetCurDeviceAspect() { }

	// RVA: 0xD13398 Offset: 0xD13398 VA: 0xD13398
	private void Update() { }

	// RVA: 0xD137C0 Offset: 0xD137C0 VA: 0xD137C0
	private void UpdateScreenInfo() { }

	// RVA: 0xD13470 Offset: 0xD13470 VA: 0xD13470
	private void ExcuteSchemeOne(float curAspect) { }

	// RVA: 0xD1367C Offset: 0xD1367C VA: 0xD1367C
	private void ExcuteSchemeTwo(float curAspect) { }

	// RVA: 0xD13878 Offset: 0xD13878 VA: 0xD13878
	public void ForceRefreshResolution() { }

	// RVA: 0xD138A8 Offset: 0xD138A8 VA: 0xD138A8
	public void .ctor() { }
}
