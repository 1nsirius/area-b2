// Namespace: 
public class PlayerSelfToolTip // TypeDefIndex: 5651
{
	// Fields
	private RectTransform trans; // 0x8
	private Camera worldViewCam; // 0xC
	private Func<Vector3> targetPosGetter; // 0x10

	// Methods

	// RVA: 0x2CE4F70 Offset: 0x2CE4F70 VA: 0x2CE4F70
	public void .ctor(RectTransform trans) { }

	// RVA: 0x2CE4F90 Offset: 0x2CE4F90 VA: 0x2CE4F90
	public void Init(Func<Vector3> target, Camera camera) { }

	// RVA: 0x2CE4F9C Offset: 0x2CE4F9C VA: 0x2CE4F9C
	public void Hide() { }

	// RVA: 0x2CE5050 Offset: 0x2CE5050 VA: 0x2CE5050
	public void UpdatePos() { }

	// RVA: 0x2CE52A4 Offset: 0x2CE52A4 VA: 0x2CE52A4
	private static float CalcScaleByDistance(Vector3 selfPos, Vector3 pos) { }
}
