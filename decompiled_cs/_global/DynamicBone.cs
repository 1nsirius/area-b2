// Namespace: 
[AddComponentMenu] // RVA: 0x550DFC Offset: 0x550DFC VA: 0x550DFC
public class DynamicBone : MonoBehaviour // TypeDefIndex: 5833
{
	// Fields
	public Transform m_Root; // 0xC
	public DynamicBone.UpdateMode m_UpdateMode; // 0x10
	[RangeAttribute] // RVA: 0x55EDB0 Offset: 0x55EDB0 VA: 0x55EDB0
	public float m_Damping; // 0x14
	public AnimationCurve m_DampingDistrib; // 0x18
	[RangeAttribute] // RVA: 0x55EDC8 Offset: 0x55EDC8 VA: 0x55EDC8
	public float m_Elasticity; // 0x1C
	public AnimationCurve m_ElasticityDistrib; // 0x20
	[RangeAttribute] // RVA: 0x55EDE0 Offset: 0x55EDE0 VA: 0x55EDE0
	public float m_Stiffness; // 0x24
	public AnimationCurve m_StiffnessDistrib; // 0x28
	[RangeAttribute] // RVA: 0x55EDF8 Offset: 0x55EDF8 VA: 0x55EDF8
	public float m_Inert; // 0x2C
	public AnimationCurve m_InertDistrib; // 0x30
	public float m_Radius; // 0x34
	public AnimationCurve m_RadiusDistrib; // 0x38
	public float m_EndLength; // 0x3C
	public Vector3 m_EndOffset; // 0x40
	public Vector3 m_Gravity; // 0x4C
	public Vector3 m_Force; // 0x58
	public List<DynamicBoneColliderBase> m_Colliders; // 0x64
	public List<Transform> m_Exclusions; // 0x68
	public DynamicBone.FreezeAxis m_FreezeAxis; // 0x6C
	public bool m_DistantDisable; // 0x70
	public Transform m_ReferenceObject; // 0x74
	public float m_DistanceToObject; // 0x78
	private Vector3 m_LocalGravity; // 0x7C
	private Vector3 m_ObjectMove; // 0x88
	private Vector3 m_ObjectPrevPosition; // 0x94
	private float m_BoneTotalLength; // 0xA0
	private float m_ObjectScale; // 0xA4
	private float m_Time; // 0xA8
	private float m_Weight; // 0xAC
	private bool m_DistantDisabled; // 0xB0
	private List<DynamicBone.Particle> m_Particles; // 0xB4

	// Methods

	// RVA: 0xD15400 Offset: 0xD15400 VA: 0xD15400
	private void Start() { }

	// RVA: 0xD15638 Offset: 0xD15638 VA: 0xD15638
	private void FixedUpdate() { }

	// RVA: 0xD1569C Offset: 0xD1569C VA: 0xD1569C
	private void Update() { }

	// RVA: 0xD156D4 Offset: 0xD156D4 VA: 0xD156D4
	private void LateUpdate() { }

	// RVA: 0xD15670 Offset: 0xD15670 VA: 0xD15670
	private void PreUpdate() { }

	// RVA: 0xD15724 Offset: 0xD15724 VA: 0xD15724
	private void CheckDistance() { }

	// RVA: 0xD16004 Offset: 0xD16004 VA: 0xD16004
	private void OnEnable() { }

	// RVA: 0xD16008 Offset: 0xD16008 VA: 0xD16008
	private void OnDisable() { }

	// RVA: 0xD1600C Offset: 0xD1600C VA: 0xD1600C
	public void SetWeight(float w) { }

	// RVA: 0xD16064 Offset: 0xD16064 VA: 0xD16064
	public float GetWeight() { }

	// RVA: 0xD159A4 Offset: 0xD159A4 VA: 0xD159A4
	private void UpdateDynamicBones() { }

	// RVA: 0xD15404 Offset: 0xD15404 VA: 0xD15404
	private void SetupParticles() { }

	// RVA: 0xD17F04 Offset: 0xD17F04 VA: 0xD17F04
	private void AppendParticles(Transform b, int parentIndex, float boneLength) { }

	// RVA: 0xD188E4 Offset: 0xD188E4 VA: 0xD188E4
	public void UpdateParameters() { }

	// RVA: 0xD15BE8 Offset: 0xD15BE8 VA: 0xD15BE8
	private void InitTransforms() { }

	// RVA: 0xD15D9C Offset: 0xD15D9C VA: 0xD15D9C
	private void ResetParticlesPosition() { }

	// RVA: 0xD1606C Offset: 0xD1606C VA: 0xD1606C
	private void UpdateParticles1() { }

	// RVA: 0xD165A0 Offset: 0xD165A0 VA: 0xD165A0
	private void UpdateParticles2() { }

	// RVA: 0xD1717C Offset: 0xD1717C VA: 0xD1717C
	private void SkipUpdateParticles() { }

	// RVA: 0xD18EFC Offset: 0xD18EFC VA: 0xD18EFC
	private static Vector3 MirrorVector(Vector3 v, Vector3 axis) { }

	// RVA: 0xD17AE4 Offset: 0xD17AE4 VA: 0xD17AE4
	private void ApplyParticlesToTransforms() { }

	// RVA: 0xD18FFC Offset: 0xD18FFC VA: 0xD18FFC
	public void .ctor() { }
}
