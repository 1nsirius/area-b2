// Namespace: 
[RequiredByNativeCodeAttribute] // RVA: 0x52C1FC Offset: 0x52C1FC VA: 0x52C1FC
public struct ParticleSystem.Particle // TypeDefIndex: 3847
{
	// Fields
	private Vector3 m_Position; // 0x0
	private Vector3 m_Velocity; // 0xC
	private Vector3 m_AnimatedVelocity; // 0x18
	private Vector3 m_InitialVelocity; // 0x24
	private Vector3 m_AxisOfRotation; // 0x30
	private Vector3 m_Rotation; // 0x3C
	private Vector3 m_AngularVelocity; // 0x48
	private Vector3 m_StartSize; // 0x54
	private Color32 m_StartColor; // 0x60
	private uint m_RandomSeed; // 0x64
	private float m_Lifetime; // 0x68
	private float m_StartLifetime; // 0x6C
	private float m_EmitAccumulator0; // 0x70
	private float m_EmitAccumulator1; // 0x74
	private uint m_Flags; // 0x78

	// Properties
	[ObsoleteAttribute] // RVA: 0x52CB24 Offset: 0x52CB24 VA: 0x52CB24
	public float lifetime { set; }
	public Vector3 position { set; }
	public Vector3 velocity { set; }
	public float remainingLifetime { set; }
	public float startLifetime { set; }
	public Color32 startColor { set; }
	public uint randomSeed { set; }
	public float startSize { set; }
	public Vector3 rotation3D { set; }
	public Vector3 angularVelocity3D { set; }

	// Methods

	// RVA: 0x813434 Offset: 0x813434 VA: 0x813434
	public void set_lifetime(float value) { }

	// RVA: 0x81343C Offset: 0x81343C VA: 0x81343C
	public void set_position(Vector3 value) { }

	// RVA: 0x813448 Offset: 0x813448 VA: 0x813448
	public void set_velocity(Vector3 value) { }

	// RVA: 0x813454 Offset: 0x813454 VA: 0x813454
	public void set_remainingLifetime(float value) { }

	// RVA: 0x81345C Offset: 0x81345C VA: 0x81345C
	public void set_startLifetime(float value) { }

	// RVA: 0x813464 Offset: 0x813464 VA: 0x813464
	public void set_startColor(Color32 value) { }

	// RVA: 0x81346C Offset: 0x81346C VA: 0x81346C
	public void set_randomSeed(uint value) { }

	// RVA: 0x813474 Offset: 0x813474 VA: 0x813474
	public void set_startSize(float value) { }

	// RVA: 0x8134C0 Offset: 0x8134C0 VA: 0x8134C0
	public void set_rotation3D(Vector3 value) { }

	// RVA: 0x8134DC Offset: 0x8134DC VA: 0x8134DC
	public void set_angularVelocity3D(Vector3 value) { }
}
