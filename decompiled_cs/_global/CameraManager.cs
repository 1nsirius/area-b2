// Namespace: 
public class CameraManager : MonoBehaviourSingleton<CameraManager> // TypeDefIndex: 5545
{
	// Fields
	[RangeAttribute] // RVA: 0x55DE80 Offset: 0x55DE80 VA: 0x55DE80
	public float resolution_percent; // 0xC
	[RangeAttribute] // RVA: 0x55DE98 Offset: 0x55DE98 VA: 0x55DE98
	public int localwidth; // 0x10
	private Vector2Int m_resolution; // 0x14
	private CameraManager.IRenderBuffersProvider m_provider; // 0x1C
	private CameraManager.FinalCamera m_final_camera; // 0x20
	private static HashSet<CameraAgent> s_cameras; // 0x0
	[CompilerGeneratedAttribute] // RVA: 0x55DEB0 Offset: 0x55DEB0 VA: 0x55DEB0
	private static Action s_cameras_updated; // 0x4

	// Properties
	public CameraManager.IRenderBuffersProvider render_buffers_provider { get; set; }
	public bool EnableFinalCamera { get; set; }
	public Vector2Int resolution { get; set; }

	// Methods

	// RVA: 0xD4D940 Offset: 0xD4D940 VA: 0xD4D940
	public CameraManager.IRenderBuffersProvider get_render_buffers_provider() { }

	// RVA: 0xD4FA10 Offset: 0xD4FA10 VA: 0xD4FA10
	public void set_render_buffers_provider(CameraManager.IRenderBuffersProvider value) { }

	// RVA: 0xD500E0 Offset: 0xD500E0 VA: 0xD500E0
	public void set_EnableFinalCamera(bool value) { }

	// RVA: 0xD501BC Offset: 0xD501BC VA: 0xD501BC
	public bool get_EnableFinalCamera() { }

	// RVA: 0xD50294 Offset: 0xD50294 VA: 0xD50294
	public Vector2Int get_resolution() { }

	// RVA: 0xD502A8 Offset: 0xD502A8 VA: 0xD502A8
	public void set_resolution(Vector2Int value) { }

	// RVA: 0xD502B4 Offset: 0xD502B4 VA: 0xD502B4 Slot: 4
	protected override void onInit() { }

	// RVA: 0xD5053C Offset: 0xD5053C VA: 0xD5053C Slot: 5
	protected override void onFini() { }

	// RVA: 0xD4FC28 Offset: 0xD4FC28 VA: 0xD4FC28
	private void apply(CameraManager.IRenderBuffersProvider provider) { }

	// RVA: 0xD50724 Offset: 0xD50724 VA: 0xD50724
	private void final_camera_post_render() { }

	// RVA: 0xD4D364 Offset: 0xD4D364 VA: 0xD4D364
	public static void add_camera(CameraAgent ca) { }

	// RVA: 0xD4D5B8 Offset: 0xD4D5B8 VA: 0xD4D5B8
	public static void remove_camera(CameraAgent ca) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A034 Offset: 0x57A034 VA: 0x57A034
	// RVA: 0xD50860 Offset: 0xD50860 VA: 0xD50860
	private static void add_s_cameras_updated(Action value) { }

	[CompilerGeneratedAttribute] // RVA: 0x57A044 Offset: 0x57A044 VA: 0x57A044
	// RVA: 0xD509F4 Offset: 0xD509F4 VA: 0xD509F4
	private static void remove_s_cameras_updated(Action value) { }

	// RVA: 0xD50B88 Offset: 0xD50B88 VA: 0xD50B88
	public void .ctor() { }

	// RVA: 0xD50BF4 Offset: 0xD50BF4 VA: 0xD50BF4
	private static void .cctor() { }
}
