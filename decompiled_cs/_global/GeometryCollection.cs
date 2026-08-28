// Namespace: 
public class GeometryCollection : MonoBehaviour // TypeDefIndex: 5587
{
	// Fields
	public bool mIsDisplay; // 0xC
	public bool mIsUseChildRenderer; // 0xD
	public Mesh mHullMesh; // 0x10
	public Mesh mTemplateMesh; // 0x14
	public List<GeometryCollection.ObjectInfo> mObjectInfos; // 0x18
	public List<GeometryCollection.ObjectInfo> mObjectInfos1; // 0x1C
	private SharedMeshRenderer _sharedMeshRenderer; // 0x20
	public static int sDynamicBatchVertex; // 0x0
	public static bool s_useDynamic; // 0x4

	// Methods

	// RVA: 0x2CC9738 Offset: 0x2CC9738 VA: 0x2CC9738
	protected void Awake() { }

	// RVA: 0x2CC9E5C Offset: 0x2CC9E5C VA: 0x2CC9E5C
	private void OnDestroy() { }

	// RVA: 0x2CC9764 Offset: 0x2CC9764 VA: 0x2CC9764
	private void Init() { }

	// RVA: 0x2CC9E70 Offset: 0x2CC9E70 VA: 0x2CC9E70
	public void RefreshMesh() { }

	// RVA: 0x2CC9BAC Offset: 0x2CC9BAC VA: 0x2CC9BAC
	public void SetDisplay(bool display) { }

	// RVA: 0x2CC98B8 Offset: 0x2CC98B8 VA: 0x2CC98B8
	public void UseChildRenderer(bool bChild) { }

	// RVA: 0x2CCA1D8 Offset: 0x2CCA1D8 VA: 0x2CCA1D8
	public static void ToggleDynamic() { }

	// RVA: 0x2CCA368 Offset: 0x2CCA368 VA: 0x2CCA368
	public void .ctor() { }

	// RVA: 0x2CCA378 Offset: 0x2CCA378 VA: 0x2CCA378
	private static void .cctor() { }
}
