// Namespace: 
[AddComponentMenu] // RVA: 0x551B50 Offset: 0x551B50 VA: 0x551B50
[DisallowMultipleComponent] // RVA: 0x551B50 Offset: 0x551B50 VA: 0x551B50
[RequireComponent] // RVA: 0x551B50 Offset: 0x551B50 VA: 0x551B50
[ExecuteInEditMode] // RVA: 0x551B50 Offset: 0x551B50 VA: 0x551B50
public class AkSurfaceReflector : MonoBehaviour // TypeDefIndex: 6090
{
	// Fields
	[TooltipAttribute] // RVA: 0x560458 Offset: 0x560458 VA: 0x560458
	public AcousticTexture AcousticTexture; // 0xC
	[HeaderAttribute] // RVA: 0x56048C Offset: 0x56048C VA: 0x56048C
	[TooltipAttribute] // RVA: 0x56048C Offset: 0x56048C VA: 0x56048C
	public bool EnableDiffraction; // 0x10
	[TooltipAttribute] // RVA: 0x56051C Offset: 0x56051C VA: 0x56051C
	public bool EnableDiffractionOnBoundaryEdges; // 0x11
	private MeshFilter MeshFilter; // 0x14

	// Methods

	// RVA: 0xCA47BC Offset: 0xCA47BC VA: 0xCA47BC
	public static ulong GetAkGeometrySetID(MeshFilter meshFilter) { }

	// RVA: 0xCA47EC Offset: 0xCA47EC VA: 0xCA47EC
	public static void AddGeometrySet(AcousticTexture acousticTexture, MeshFilter meshFilter, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges) { }

	// RVA: 0xCA5D94 Offset: 0xCA5D94 VA: 0xCA5D94
	public static void RemoveGeometrySet(MeshFilter meshFilter) { }

	// RVA: 0xCA5E70 Offset: 0xCA5E70 VA: 0xCA5E70
	private void Awake() { }

	// RVA: 0xCA5ED8 Offset: 0xCA5ED8 VA: 0xCA5ED8
	private void OnEnable() { }

	// RVA: 0xCA5F00 Offset: 0xCA5F00 VA: 0xCA5F00
	private void OnDisable() { }

	// RVA: 0xCA5F08 Offset: 0xCA5F08 VA: 0xCA5F08
	public void .ctor() { }
}
