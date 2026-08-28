// Namespace: 
[DefaultMemberAttribute] // RVA: 0x54F4B4 Offset: 0x54F4B4 VA: 0x54F4B4
private struct MeshSimplifier.Triangle // TypeDefIndex: 5195
{
	// Fields
	public int v0; // 0x0
	public int v1; // 0x4
	public int v2; // 0x8
	public int subMeshIndex; // 0xC
	public int va0; // 0x10
	public int va1; // 0x14
	public int va2; // 0x18
	public double err0; // 0x20
	public double err1; // 0x28
	public double err2; // 0x30
	public double err3; // 0x38
	public bool deleted; // 0x40
	public bool dirty; // 0x41
	public Vector3d n; // 0x48

	// Properties
	public int Item { get; set; }

	// Methods

	// RVA: 0x7C0A58 Offset: 0x7C0A58 VA: 0x7C0A58
	public int get_Item(int index) { }

	// RVA: 0x7C0A7C Offset: 0x7C0A7C VA: 0x7C0A7C
	public void set_Item(int index, int value) { }

	// RVA: 0x7C0A84 Offset: 0x7C0A84 VA: 0x7C0A84
	public void .ctor(int v0, int v1, int v2, int subMeshIndex) { }

	// RVA: 0x7C0AD0 Offset: 0x7C0AD0 VA: 0x7C0AD0
	public void GetAttributeIndices(int[] attributeIndices) { }

	// RVA: 0x7C0AD8 Offset: 0x7C0AD8 VA: 0x7C0AD8
	public void SetAttributeIndex(int index, int value) { }

	// RVA: 0x7C0AE0 Offset: 0x7C0AE0 VA: 0x7C0AE0
	public void GetErrors(double[] err) { }
}
