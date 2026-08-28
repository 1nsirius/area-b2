// Namespace: 
public struct ParticleSystem.MainModule // TypeDefIndex: 3846
{
	// Fields
	private ParticleSystem m_ParticleSystem; // 0x0

	// Properties
	public float duration { get; }
	public bool loop { get; }
	public ParticleSystem.MinMaxCurve startDelay { get; }
	public ParticleSystemCullingMode cullingMode { set; }

	// Methods

	// RVA: 0x8133A8 Offset: 0x8133A8 VA: 0x8133A8
	internal void .ctor(ParticleSystem particleSystem) { }

	// RVA: 0x8133B0 Offset: 0x8133B0 VA: 0x8133B0
	public float get_duration() { }

	// RVA: 0x8133B8 Offset: 0x8133B8 VA: 0x8133B8
	public bool get_loop() { }

	// RVA: 0x8133C0 Offset: 0x8133C0 VA: 0x8133C0
	public ParticleSystem.MinMaxCurve get_startDelay() { }

	// RVA: 0x813410 Offset: 0x813410 VA: 0x813410
	public void set_cullingMode(ParticleSystemCullingMode value) { }

	[GeneratedByOldBindingsGeneratorAttribute] // RVA: 0x52CAB4 Offset: 0x52CAB4 VA: 0x52CAB4
	// RVA: 0x2CB0AFC Offset: 0x2CB0AFC VA: 0x2CB0AFC
	private static float GetDuration(ParticleSystem system) { }

	[GeneratedByOldBindingsGeneratorAttribute] // RVA: 0x52CAC4 Offset: 0x52CAC4 VA: 0x52CAC4
	// RVA: 0x2CB0B7C Offset: 0x2CB0B7C VA: 0x2CB0B7C
	private static bool GetLoop(ParticleSystem system) { }

	[GeneratedByOldBindingsGeneratorAttribute] // RVA: 0x52CAD4 Offset: 0x52CAD4 VA: 0x52CAD4
	// RVA: 0x2CB0C44 Offset: 0x2CB0C44 VA: 0x2CB0C44
	private static void GetStartDelay(ParticleSystem system, ref ParticleSystem.MinMaxCurve curve) { }

	[GeneratedByOldBindingsGeneratorAttribute] // RVA: 0x52CAE4 Offset: 0x52CAE4 VA: 0x52CAE4
	// RVA: 0x2CB0CCC Offset: 0x2CB0CCC VA: 0x2CB0CCC
	private static void SetCullingMode(ParticleSystem system, ParticleSystemCullingMode value) { }
}
