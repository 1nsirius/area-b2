// Namespace: 
private class MeshSimplifier.BlendShapeContainer // TypeDefIndex: 5199
{
	// Fields
	private string shapeName; // 0x8
	private MeshSimplifier.BlendShapeFrameContainer[] frames; // 0xC

	// Methods

	// RVA: 0x236A294 Offset: 0x236A294 VA: 0x236A294
	public void .ctor(BlendShape blendShape) { }

	// RVA: 0x2366DF4 Offset: 0x2366DF4 VA: 0x2366DF4
	public void MoveVertexElement(int dst, int src) { }

	// RVA: 0x236296C Offset: 0x236296C VA: 0x236296C
	public void InterpolateVertexAttributes(int dst, int i0, int i1, int i2, ref Vector3 barycentricCoord) { }

	// RVA: 0x2366E90 Offset: 0x2366E90 VA: 0x2366E90
	public void Resize(int length, bool trimExess = False) { }

	// RVA: 0x2369E40 Offset: 0x2369E40 VA: 0x2369E40
	public BlendShape ToBlendShape() { }
}
