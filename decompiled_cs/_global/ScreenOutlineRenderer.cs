// Namespace: 
[RequireComponent] // RVA: 0x5509F4 Offset: 0x5509F4 VA: 0x5509F4
public class ScreenOutlineRenderer : MonoBehaviour // TypeDefIndex: 5559
{
	// Fields
	public Material material; // 0xC
	public int cull_mask; // 0x10
	private static readonly int RT; // 0x0
	private static readonly int RT1; // 0x4
	private static readonly int RT2; // 0x8
	private static readonly int OUTLINE_TEX; // 0xC
	private CommandBuffer m_cb; // 0x14
	private CameraAgent m_camera; // 0x18
	private List<ScreenOutlineRenderer.ProjectorRenderer> m_renderers; // 0x1C
	private HashSet<ScreenOutlineRenderer.IProjector> m_projectors; // 0x20
	private bool m_visible; // 0x24

	// Properties
	public CameraAgent camera_agent { get; }

	// Methods

	// RVA: 0x2CF62DC Offset: 0x2CF62DC VA: 0x2CF62DC
	public CameraAgent get_camera_agent() { }

	// RVA: 0x2CF62E4 Offset: 0x2CF62E4 VA: 0x2CF62E4
	public void add_projector(ScreenOutlineRenderer.IProjector projector) { }

	// RVA: 0x2CF6364 Offset: 0x2CF6364 VA: 0x2CF6364
	public void remove_projector(ScreenOutlineRenderer.IProjector projector) { }

	// RVA: 0x2CF63E4 Offset: 0x2CF63E4 VA: 0x2CF63E4
	private void Awake() { }

	// RVA: 0x2CF6554 Offset: 0x2CF6554 VA: 0x2CF6554
	private void OnPostRender() { }

	// RVA: 0x2CF6928 Offset: 0x2CF6928 VA: 0x2CF6928
	private void draw(Vector2Int rt_size, Action set_target, Action restore_target) { }

	// RVA: 0x2CF7248 Offset: 0x2CF7248 VA: 0x2CF7248
	public void .ctor() { }

	// RVA: 0x2CF7250 Offset: 0x2CF7250 VA: 0x2CF7250
	private static void .cctor() { }
}
