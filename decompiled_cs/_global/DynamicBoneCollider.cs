// Namespace: 
[AddComponentMenu] // RVA: 0x550E44 Offset: 0x550E44 VA: 0x550E44
public class DynamicBoneCollider : DynamicBoneColliderBase // TypeDefIndex: 5837
{
	// Fields
	public float m_Radius; // 0x20
	public float m_Height; // 0x24

	// Methods

	// RVA: 0xD1919C Offset: 0xD1919C VA: 0xD1919C
	private void OnValidate() { }

	// RVA: 0xD1924C Offset: 0xD1924C VA: 0xD1924C Slot: 4
	public override void Collide(ref Vector3 particlePosition, float particleRadius) { }

	// RVA: 0xD195EC Offset: 0xD195EC VA: 0xD195EC
	private static void OutsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius) { }

	// RVA: 0xD197E0 Offset: 0xD197E0 VA: 0xD197E0
	private static void InsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius) { }

	// RVA: 0xD199CC Offset: 0xD199CC VA: 0xD199CC
	private static void OutsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius) { }

	// RVA: 0xD19F40 Offset: 0xD19F40 VA: 0xD19F40
	private static void InsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius) { }

	// RVA: 0xD1A490 Offset: 0xD1A490 VA: 0xD1A490
	private void OnDrawGizmosSelected() { }

	// RVA: 0xD1A760 Offset: 0xD1A760 VA: 0xD1A760
	public void .ctor() { }
}
