// Namespace: 
public class AliShow3DBasic // TypeDefIndex: 5498
{
	// Fields
	public const string MODEL_SHOW_ROOT_NAME = "Show3DModelRoom";
	public const string MODEL_CAMERA_ROOT_NAME = "Camera";
	public const string MODEL_CAMERABG_ROOT_NAME = "CameraBg";
	public GameObject m_Camera; // 0x8
	public Camera m_CameraTarget; // 0xC
	public AliShowPropNode nodeSetting; // 0x10
	public RenderTexture heroRT; // 0x14
	public RenderTexture bgRT; // 0x18
	public Camera m_BGCametaTarget; // 0x1C
	public GameObject m_modelShowRoot; // 0x20
	public Transform m_CameraRoot; // 0x24
	public Transform m_CameraBgRoot; // 0x28

	// Methods

	// RVA: 0xCAF5AC Offset: 0xCAF5AC VA: 0xCAF5AC Slot: 4
	protected virtual void CreateDisplayModel(int defaultViewLevel = 1) { }

	// RVA: 0xCAF890 Offset: 0xCAF890 VA: 0xCAF890 Slot: 5
	public virtual void Clear() { }

	// RVA: 0xCAF9AC Offset: 0xCAF9AC VA: 0xCAF9AC Slot: 6
	public virtual void ReleaseRT() { }

	// RVA: 0xCAFAD8 Offset: 0xCAFAD8 VA: 0xCAFAD8 Slot: 7
	protected virtual bool InitSceneRoot() { }

	// RVA: 0xCAFE90 Offset: 0xCAFE90 VA: 0xCAFE90
	public void .ctor() { }
}
