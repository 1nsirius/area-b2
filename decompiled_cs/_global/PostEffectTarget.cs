// Namespace: 
[RequireComponent] // RVA: 0x55097C Offset: 0x55097C VA: 0x55097C
public class PostEffectTarget : MonoBehaviour // TypeDefIndex: 5558
{
	// Fields
	private Camera camMain; // 0xC
	private Camera camEffect; // 0x10
	private Vector2Int originRTSize; // 0x14
	private CameraDepthGetBuffer _cameraDepthGetBuffer; // 0x1C
	private CameraManager _cameraManager; // 0x20
	private bool _isUsedRt; // 0x24
	private bool _isUsedEffect; // 0x25
	public float CurScreenRatio; // 0x28
	private int _curColorRTID; // 0x2C
	private RenderTexture _colorRT; // 0x30
	private RenderTexture _curColorRT; // 0x34
	private RenderTexture _curRenderRT; // 0x38
	private PostEffectPost _postEffectPost; // 0x3C
	private bool _isNeedRt; // 0x40
	private bool _isNeedEffect; // 0x41
	private float _needScreenRatio; // 0x44

	// Properties
	public RenderTexture CurColorRT { get; }
	public RenderTexture CurRenderRT { get; }

	// Methods

	// RVA: 0x2CE7300 Offset: 0x2CE7300 VA: 0x2CE7300
	public void SetRenderTarget(bool b, float resRatio = 1) { }

	// RVA: 0x2CE756C Offset: 0x2CE756C VA: 0x2CE756C
	public void SetCameraTarget(bool b, Vector2Int rtSize) { }

	// RVA: 0x2CE7B64 Offset: 0x2CE7B64 VA: 0x2CE7B64
	private void Start() { }

	// RVA: 0x2CE7DD8 Offset: 0x2CE7DD8 VA: 0x2CE7DD8
	private void OnDestroy() { }

	// RVA: 0x2CE6F90 Offset: 0x2CE6F90 VA: 0x2CE6F90
	public void SwitchColorRT() { }

	// RVA: 0x2CE7E80 Offset: 0x2CE7E80 VA: 0x2CE7E80
	public void SetCurColorRT(int _rtID) { }

	// RVA: 0x2CE6840 Offset: 0x2CE6840 VA: 0x2CE6840
	public RenderTexture get_CurColorRT() { }

	// RVA: 0x2CE6848 Offset: 0x2CE6848 VA: 0x2CE6848
	public RenderTexture get_CurRenderRT() { }

	// RVA: 0x2CE80E4 Offset: 0x2CE80E4 VA: 0x2CE80E4
	private void LateUpdate() { }

	// RVA: 0x2CE824C Offset: 0x2CE824C VA: 0x2CE824C
	private void OnPreRender() { }

	// RVA: 0x2CE8360 Offset: 0x2CE8360 VA: 0x2CE8360
	public void .ctor() { }
}
