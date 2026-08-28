// Namespace: 
public class AkSpatialAudioInitSettings : IDisposable // TypeDefIndex: 5954
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public int uPoolID { get; set; }
	public uint uPoolSize { get; set; }
	public uint uMaxSoundPropagationDepth { get; set; }
	public uint uDiffractionFlags { get; set; }
	public float fDiffractionShadowAttenFactor { get; set; }
	public float fDiffractionShadowDegrees { get; set; }

	// Methods

	// RVA: 0xCA2B90 Offset: 0xCA2B90 VA: 0xCA2B90
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xCA2BB8 Offset: 0xCA2BB8 VA: 0xCA2BB8
	internal static IntPtr getCPtr(AkSpatialAudioInitSettings obj) { }

	// RVA: 0xCA2C10 Offset: 0xCA2C10 VA: 0xCA2C10 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xCA2C3C Offset: 0xCA2C3C VA: 0xCA2C3C Slot: 1
	protected override void Finalize() { }

	// RVA: 0xCA2CB0 Offset: 0xCA2CB0 VA: 0xCA2CB0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xCA2E34 Offset: 0xCA2E34 VA: 0xCA2E34
	public void .ctor() { }

	// RVA: 0xCA2ED0 Offset: 0xCA2ED0 VA: 0xCA2ED0
	public void set_uPoolID(int value) { }

	// RVA: 0xCA2F60 Offset: 0xCA2F60 VA: 0xCA2F60
	public int get_uPoolID() { }

	// RVA: 0xCA2FE8 Offset: 0xCA2FE8 VA: 0xCA2FE8
	public void set_uPoolSize(uint value) { }

	// RVA: 0xCA3078 Offset: 0xCA3078 VA: 0xCA3078
	public uint get_uPoolSize() { }

	// RVA: 0xCA3100 Offset: 0xCA3100 VA: 0xCA3100
	public void set_uMaxSoundPropagationDepth(uint value) { }

	// RVA: 0xCA3190 Offset: 0xCA3190 VA: 0xCA3190
	public uint get_uMaxSoundPropagationDepth() { }

	// RVA: 0xCA3218 Offset: 0xCA3218 VA: 0xCA3218
	public void set_uDiffractionFlags(uint value) { }

	// RVA: 0xCA32A8 Offset: 0xCA32A8 VA: 0xCA32A8
	public uint get_uDiffractionFlags() { }

	// RVA: 0xCA3330 Offset: 0xCA3330 VA: 0xCA3330
	public void set_fDiffractionShadowAttenFactor(float value) { }

	// RVA: 0xCA33C0 Offset: 0xCA33C0 VA: 0xCA33C0
	public float get_fDiffractionShadowAttenFactor() { }

	// RVA: 0xCA3448 Offset: 0xCA3448 VA: 0xCA3448
	public void set_fDiffractionShadowDegrees(float value) { }

	// RVA: 0xCA34D8 Offset: 0xCA34D8 VA: 0xCA34D8
	public float get_fDiffractionShadowDegrees() { }
}
