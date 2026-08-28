// Namespace: 
[NativeTypeAttribute] // RVA: 0x52C250 Offset: 0x52C250 VA: 0x52C250
[Serializable]
public struct ParticleSystem.MinMaxCurve // TypeDefIndex: 3848
{
	// Fields
	[SerializeField] // RVA: 0x52C3F0 Offset: 0x52C3F0 VA: 0x52C3F0
	private ParticleSystemCurveMode m_Mode; // 0x0
	[SerializeField] // RVA: 0x52C400 Offset: 0x52C400 VA: 0x52C400
	private float m_CurveMultiplier; // 0x4
	[SerializeField] // RVA: 0x52C410 Offset: 0x52C410 VA: 0x52C410
	private AnimationCurve m_CurveMin; // 0x8
	[SerializeField] // RVA: 0x52C420 Offset: 0x52C420 VA: 0x52C420
	private AnimationCurve m_CurveMax; // 0xC
	[SerializeField] // RVA: 0x52C430 Offset: 0x52C430 VA: 0x52C430
	private float m_ConstantMin; // 0x10
	[SerializeField] // RVA: 0x52C440 Offset: 0x52C440 VA: 0x52C440
	private float m_ConstantMax; // 0x14

	// Properties
	public ParticleSystemCurveMode mode { get; }

	// Methods

	// RVA: 0x813418 Offset: 0x813418 VA: 0x813418
	public ParticleSystemCurveMode get_mode() { }

	// RVA: 0x813420 Offset: 0x813420 VA: 0x813420
	public float Evaluate(float time) { }

	// RVA: 0x81342C Offset: 0x81342C VA: 0x81342C
	public float Evaluate(float time, float lerpFactor) { }
}
