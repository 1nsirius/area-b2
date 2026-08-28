// Namespace: 
public class AkPositioningInfo : IDisposable // TypeDefIndex: 5942
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public float fCenterPct { get; set; }
	public AkSpeakerPanningType pannerType { get; set; }
	public Ak3DPositionType e3dPositioningType { get; set; }
	public bool bHoldEmitterPosAndOrient { get; set; }
	public Ak3DSpatializationMode e3DSpatializationMode { get; set; }
	public bool bUseAttenuation { get; set; }
	public bool bUseConeAttenuation { get; set; }
	public float fInnerAngle { get; set; }
	public float fOuterAngle { get; set; }
	public float fConeMaxAttenuation { get; set; }
	public float LPFCone { get; set; }
	public float HPFCone { get; set; }
	public float fMaxDistance { get; set; }
	public float fVolDryAtMaxDist { get; set; }
	public float fVolAuxGameDefAtMaxDist { get; set; }
	public float fVolAuxUserDefAtMaxDist { get; set; }
	public float LPFValueAtMaxDist { get; set; }
	public float HPFValueAtMaxDist { get; set; }

	// Methods

	// RVA: 0x1BBAFF8 Offset: 0x1BBAFF8 VA: 0x1BBAFF8
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BBB020 Offset: 0x1BBB020 VA: 0x1BBB020
	internal static IntPtr getCPtr(AkPositioningInfo obj) { }

	// RVA: 0x1BBB078 Offset: 0x1BBB078 VA: 0x1BBB078 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BBB0A4 Offset: 0x1BBB0A4 VA: 0x1BBB0A4 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BBB118 Offset: 0x1BBB118 VA: 0x1BBB118 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BBB29C Offset: 0x1BBB29C VA: 0x1BBB29C
	public void set_fCenterPct(float value) { }

	// RVA: 0x1BBB32C Offset: 0x1BBB32C VA: 0x1BBB32C
	public float get_fCenterPct() { }

	// RVA: 0x1BBB3B4 Offset: 0x1BBB3B4 VA: 0x1BBB3B4
	public void set_pannerType(AkSpeakerPanningType value) { }

	// RVA: 0x1BBB444 Offset: 0x1BBB444 VA: 0x1BBB444
	public AkSpeakerPanningType get_pannerType() { }

	// RVA: 0x1BBB4CC Offset: 0x1BBB4CC VA: 0x1BBB4CC
	public void set_e3dPositioningType(Ak3DPositionType value) { }

	// RVA: 0x1BBB55C Offset: 0x1BBB55C VA: 0x1BBB55C
	public Ak3DPositionType get_e3dPositioningType() { }

	// RVA: 0x1BBB5E4 Offset: 0x1BBB5E4 VA: 0x1BBB5E4
	public void set_bHoldEmitterPosAndOrient(bool value) { }

	// RVA: 0x1BBB674 Offset: 0x1BBB674 VA: 0x1BBB674
	public bool get_bHoldEmitterPosAndOrient() { }

	// RVA: 0x1BBB6FC Offset: 0x1BBB6FC VA: 0x1BBB6FC
	public void set_e3DSpatializationMode(Ak3DSpatializationMode value) { }

	// RVA: 0x1BBB78C Offset: 0x1BBB78C VA: 0x1BBB78C
	public Ak3DSpatializationMode get_e3DSpatializationMode() { }

	// RVA: 0x1BBB814 Offset: 0x1BBB814 VA: 0x1BBB814
	public void set_bUseAttenuation(bool value) { }

	// RVA: 0x1BBB8A4 Offset: 0x1BBB8A4 VA: 0x1BBB8A4
	public bool get_bUseAttenuation() { }

	// RVA: 0x1BBB92C Offset: 0x1BBB92C VA: 0x1BBB92C
	public void set_bUseConeAttenuation(bool value) { }

	// RVA: 0x1BBB9BC Offset: 0x1BBB9BC VA: 0x1BBB9BC
	public bool get_bUseConeAttenuation() { }

	// RVA: 0x1BBBA44 Offset: 0x1BBBA44 VA: 0x1BBBA44
	public void set_fInnerAngle(float value) { }

	// RVA: 0x1BBBAD4 Offset: 0x1BBBAD4 VA: 0x1BBBAD4
	public float get_fInnerAngle() { }

	// RVA: 0x1BBBB5C Offset: 0x1BBBB5C VA: 0x1BBBB5C
	public void set_fOuterAngle(float value) { }

	// RVA: 0x1BBBBEC Offset: 0x1BBBBEC VA: 0x1BBBBEC
	public float get_fOuterAngle() { }

	// RVA: 0x1BBBC74 Offset: 0x1BBBC74 VA: 0x1BBBC74
	public void set_fConeMaxAttenuation(float value) { }

	// RVA: 0x1BBBD04 Offset: 0x1BBBD04 VA: 0x1BBBD04
	public float get_fConeMaxAttenuation() { }

	// RVA: 0x1BBBD8C Offset: 0x1BBBD8C VA: 0x1BBBD8C
	public void set_LPFCone(float value) { }

	// RVA: 0x1BBBE1C Offset: 0x1BBBE1C VA: 0x1BBBE1C
	public float get_LPFCone() { }

	// RVA: 0x1BBBEA4 Offset: 0x1BBBEA4 VA: 0x1BBBEA4
	public void set_HPFCone(float value) { }

	// RVA: 0x1BBBF34 Offset: 0x1BBBF34 VA: 0x1BBBF34
	public float get_HPFCone() { }

	// RVA: 0x1BBBFBC Offset: 0x1BBBFBC VA: 0x1BBBFBC
	public void set_fMaxDistance(float value) { }

	// RVA: 0x1BBC04C Offset: 0x1BBC04C VA: 0x1BBC04C
	public float get_fMaxDistance() { }

	// RVA: 0x1BBC0D4 Offset: 0x1BBC0D4 VA: 0x1BBC0D4
	public void set_fVolDryAtMaxDist(float value) { }

	// RVA: 0x1BBC164 Offset: 0x1BBC164 VA: 0x1BBC164
	public float get_fVolDryAtMaxDist() { }

	// RVA: 0x1BBC1EC Offset: 0x1BBC1EC VA: 0x1BBC1EC
	public void set_fVolAuxGameDefAtMaxDist(float value) { }

	// RVA: 0x1BBC27C Offset: 0x1BBC27C VA: 0x1BBC27C
	public float get_fVolAuxGameDefAtMaxDist() { }

	// RVA: 0x1BBC304 Offset: 0x1BBC304 VA: 0x1BBC304
	public void set_fVolAuxUserDefAtMaxDist(float value) { }

	// RVA: 0x1BBC394 Offset: 0x1BBC394 VA: 0x1BBC394
	public float get_fVolAuxUserDefAtMaxDist() { }

	// RVA: 0x1BBC41C Offset: 0x1BBC41C VA: 0x1BBC41C
	public void set_LPFValueAtMaxDist(float value) { }

	// RVA: 0x1BBC4AC Offset: 0x1BBC4AC VA: 0x1BBC4AC
	public float get_LPFValueAtMaxDist() { }

	// RVA: 0x1BBC534 Offset: 0x1BBC534 VA: 0x1BBC534
	public void set_HPFValueAtMaxDist(float value) { }

	// RVA: 0x1BBC5C4 Offset: 0x1BBC5C4 VA: 0x1BBC5C4
	public float get_HPFValueAtMaxDist() { }

	// RVA: 0x1BBC64C Offset: 0x1BBC64C VA: 0x1BBC64C
	public void .ctor() { }
}
