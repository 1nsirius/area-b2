// Namespace: 
[RequireComponent] // RVA: 0x5505BC Offset: 0x5505BC VA: 0x5505BC
public class ThrowLineRenderer : MonoBehaviour // TypeDefIndex: 5539
{
	// Fields
	[SerializeField] // RVA: 0x55DE50 Offset: 0x55DE50 VA: 0x55DE50
	private LineRenderer _throwlineRenderer; // 0xC
	[SerializeField] // RVA: 0x55DE60 Offset: 0x55DE60 VA: 0x55DE60
	private MeshRenderer _cycleRender; // 0x10
	[SerializeField] // RVA: 0x55DE70 Offset: 0x55DE70 VA: 0x55DE70
	private MeshRenderer _sphereRenderer; // 0x14

	// Methods

	// RVA: 0xD84C1C Offset: 0xD84C1C VA: 0xD84C1C
	private void Awake() { }

	// RVA: 0xD84D44 Offset: 0xD84D44 VA: 0xD84D44
	public void DrawEndPos(Vector3 endPos, Quaternion quaternion, float endPosSize, float sphereRadius) { }

	// RVA: 0xD850B4 Offset: 0xD850B4 VA: 0xD850B4
	public void DrawLine(List<Vector3> posList) { }

	// RVA: 0xD84C20 Offset: 0xD84C20 VA: 0xD84C20
	public void ClearLine() { }

	// RVA: 0xD85274 Offset: 0xD85274 VA: 0xD85274
	public void .ctor() { }
}
