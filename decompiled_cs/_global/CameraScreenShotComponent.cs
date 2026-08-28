// Namespace: 
[RequireComponent] // RVA: 0x550D74 Offset: 0x550D74 VA: 0x550D74
[ExecuteInEditMode] // RVA: 0x550D74 Offset: 0x550D74 VA: 0x550D74
public class CameraScreenShotComponent : MonoBehaviour // TypeDefIndex: 5826
{
	// Fields
	[SerializeField] // RVA: 0x55ED40 Offset: 0x55ED40 VA: 0x55ED40
	[HideInInspector] // RVA: 0x55ED40 Offset: 0x55ED40 VA: 0x55ED40
	public Camera camera; // 0xC
	[SerializeField] // RVA: 0x55ED70 Offset: 0x55ED70 VA: 0x55ED70
	[HideInInspector] // RVA: 0x55ED70 Offset: 0x55ED70 VA: 0x55ED70
	public int curSelectMapLayer; // 0x10
	public List<LevelSmallMapUIConfig.LayerSetting> layerSettings; // 0x14
	private Vector3 _cameraPos; // 0x18
	private Vector3 _localEulerAngles; // 0x24

	// Methods

	// RVA: 0xD50ED0 Offset: 0xD50ED0 VA: 0xD50ED0
	private void Awake() { }

	// RVA: 0xD51178 Offset: 0xD51178 VA: 0xD51178
	private void Init() { }

	// RVA: 0xD5113C Offset: 0xD5113C VA: 0xD5113C
	public static Vector3 GetLocalEulerAngles(float rotationOfCoordinates) { }

	// RVA: 0xD51270 Offset: 0xD51270 VA: 0xD51270
	public void .ctor() { }
}
