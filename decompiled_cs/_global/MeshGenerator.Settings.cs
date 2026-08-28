// Namespace: 
[Serializable]
public struct MeshGenerator.Settings // TypeDefIndex: 7244
{
	// Fields
	public bool useClipping; // 0x0
	[SpaceAttribute] // RVA: 0x56DC90 Offset: 0x56DC90 VA: 0x56DC90
	[RangeAttribute] // RVA: 0x56DC90 Offset: 0x56DC90 VA: 0x56DC90
	public float zSpacing; // 0x4
	[SpaceAttribute] // RVA: 0x56DCCC Offset: 0x56DCCC VA: 0x56DCCC
	[HeaderAttribute] // RVA: 0x56DCCC Offset: 0x56DCCC VA: 0x56DCCC
	public bool pmaVertexColors; // 0x8
	public bool tintBlack; // 0x9
	public bool calculateTangents; // 0xA
	public bool addNormals; // 0xB
	public bool immutableTriangles; // 0xC

	// Properties
	public static MeshGenerator.Settings Default { get; }

	// Methods

	// RVA: 0x1379350 Offset: 0x1379350 VA: 0x1379350
	public static MeshGenerator.Settings get_Default() { }
}
