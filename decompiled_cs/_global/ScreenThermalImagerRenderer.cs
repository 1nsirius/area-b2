// Namespace: 
[RequireComponent] // RVA: 0x550A6C Offset: 0x550A6C VA: 0x550A6C
public class ScreenThermalImagerRenderer : MonoBehaviour // TypeDefIndex: 5563
{
	// Fields
	public float imager_radius; // 0xC
	public Material material; // 0x10
	public RenderTexture _colorBuffer; // 0x14
	public RenderTexture _depthBuffer; // 0x18
	private Camera m_camera; // 0x1C
	private CommandBuffer m_cb; // 0x20
	private RenderTexture m_rt; // 0x24
	private List<ScreenThermalImagerRenderer.ProjectorRenderer> m_renderers; // 0x28
	private HashSet<ScreenThermalImagerRenderer.IProjector> m_projectors; // 0x2C
	private bool m_visible; // 0x30

	// Properties
	private float radius_ratio { get; }
	public Camera camera { get; }
	public RenderTexture RT { get; }

	// Methods

	// RVA: 0x2CF7334 Offset: 0x2CF7334 VA: 0x2CF7334
	private float get_radius_ratio() { }

	// RVA: 0x2CF734C Offset: 0x2CF734C VA: 0x2CF734C
	public Camera get_camera() { }

	// RVA: 0x2CF7354 Offset: 0x2CF7354 VA: 0x2CF7354
	public void add_projector(ScreenThermalImagerRenderer.IProjector projector) { }

	// RVA: 0x2CF73D4 Offset: 0x2CF73D4 VA: 0x2CF73D4
	public void remove_projector(ScreenThermalImagerRenderer.IProjector projector) { }

	// RVA: 0x2CF7454 Offset: 0x2CF7454 VA: 0x2CF7454
	private void Awake() { }

	// RVA: 0x2CF7578 Offset: 0x2CF7578 VA: 0x2CF7578
	private void OnEnable() { }

	// RVA: 0x2CF75B0 Offset: 0x2CF75B0 VA: 0x2CF75B0
	private void OnDisable() { }

	// RVA: 0x2CF75E8 Offset: 0x2CF75E8 VA: 0x2CF75E8
	private void OnPreRender() { }

	// RVA: 0x2CF7E40 Offset: 0x2CF7E40 VA: 0x2CF7E40
	private void OnRenderImage(RenderTexture source, RenderTexture destination) { }

	// RVA: 0x2CF8090 Offset: 0x2CF8090 VA: 0x2CF8090
	public RenderTexture get_RT() { }

	// RVA: 0x2CF8098 Offset: 0x2CF8098 VA: 0x2CF8098
	public void .ctor() { }
}
