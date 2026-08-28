// Namespace: 
public class AkImageSourceParams : IDisposable // TypeDefIndex: 5906
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkVector sourcePosition { get; set; }
	public float fDistanceScalingFactor { get; set; }
	public float fLevel { get; set; }
	public float fDiffraction { get; set; }
	public bool bDiffractedEmitterSide { get; set; }
	public bool bDiffractedListenerSide { get; set; }

	// Methods

	// RVA: 0x1BA5A14 Offset: 0x1BA5A14 VA: 0x1BA5A14
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA5A3C Offset: 0x1BA5A3C VA: 0x1BA5A3C
	internal static IntPtr getCPtr(AkImageSourceParams obj) { }

	// RVA: 0x1BA5A94 Offset: 0x1BA5A94 VA: 0x1BA5A94 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA5AC0 Offset: 0x1BA5AC0 VA: 0x1BA5AC0 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA5B34 Offset: 0x1BA5B34 VA: 0x1BA5B34 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA5CB8 Offset: 0x1BA5CB8 VA: 0x1BA5CB8
	public void .ctor() { }

	// RVA: 0x1BA5D54 Offset: 0x1BA5D54 VA: 0x1BA5D54
	public void .ctor(AkVector in_sourcePosition, float in_fDistanceScalingFactor, float in_fLevel) { }

	// RVA: 0x1BA5E18 Offset: 0x1BA5E18 VA: 0x1BA5E18
	public void set_sourcePosition(AkVector value) { }

	// RVA: 0x1BA5EB8 Offset: 0x1BA5EB8 VA: 0x1BA5EB8
	public AkVector get_sourcePosition() { }

	// RVA: 0x1BA5F88 Offset: 0x1BA5F88 VA: 0x1BA5F88
	public void set_fDistanceScalingFactor(float value) { }

	// RVA: 0x1BA6018 Offset: 0x1BA6018 VA: 0x1BA6018
	public float get_fDistanceScalingFactor() { }

	// RVA: 0x1BA60A0 Offset: 0x1BA60A0 VA: 0x1BA60A0
	public void set_fLevel(float value) { }

	// RVA: 0x1BA6130 Offset: 0x1BA6130 VA: 0x1BA6130
	public float get_fLevel() { }

	// RVA: 0x1BA61B8 Offset: 0x1BA61B8 VA: 0x1BA61B8
	public void set_fDiffraction(float value) { }

	// RVA: 0x1BA6248 Offset: 0x1BA6248 VA: 0x1BA6248
	public float get_fDiffraction() { }

	// RVA: 0x1BA62D0 Offset: 0x1BA62D0 VA: 0x1BA62D0
	public void set_bDiffractedEmitterSide(bool value) { }

	// RVA: 0x1BA6360 Offset: 0x1BA6360 VA: 0x1BA6360
	public bool get_bDiffractedEmitterSide() { }

	// RVA: 0x1BA63E8 Offset: 0x1BA63E8 VA: 0x1BA63E8
	public void set_bDiffractedListenerSide(bool value) { }

	// RVA: 0x1BA6478 Offset: 0x1BA6478 VA: 0x1BA6478
	public bool get_bDiffractedListenerSide() { }
}
