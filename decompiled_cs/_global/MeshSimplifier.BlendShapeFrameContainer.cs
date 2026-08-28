// Namespace: 
private class MeshSimplifier.BlendShapeFrameContainer // TypeDefIndex: 5200
{
	// Fields
	private float frameWeight; // 0x8
	private ResizableArray<Vector3> deltaVertices; // 0xC
	private ResizableArray<Vector3> deltaNormals; // 0x10
	private ResizableArray<Vector3> deltaTangents; // 0x14

	// Methods

	// RVA: 0x236B850 Offset: 0x236B850 VA: 0x236B850
	public void .ctor(BlendShapeFrame frame) { }

	// RVA: 0x236B934 Offset: 0x236B934 VA: 0x236B934
	public void MoveVertexElement(int dst, int src) { }

	// RVA: 0x236BAEC Offset: 0x236BAEC VA: 0x236BAEC
	public void InterpolateVertexAttributes(int dst, int i0, int i1, int i2, ref Vector3 barycentricCoord) { }

	// RVA: 0x236C060 Offset: 0x236C060 VA: 0x236C060
	public void Resize(int length, bool trimExess = False) { }

	// RVA: 0x236C150 Offset: 0x236C150 VA: 0x236C150
	public BlendShapeFrame ToBlendShapeFrame() { }
}
