// Namespace: 
public class AkImageSourceSettings : IDisposable // TypeDefIndex: 5907
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public AkImageSourceParams params_ { get; set; }

	// Methods

	// RVA: 0x1BA6500 Offset: 0x1BA6500 VA: 0x1BA6500
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA6528 Offset: 0x1BA6528 VA: 0x1BA6528
	internal static IntPtr getCPtr(AkImageSourceSettings obj) { }

	// RVA: 0x1BA6580 Offset: 0x1BA6580 VA: 0x1BA6580 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BA65AC Offset: 0x1BA65AC VA: 0x1BA65AC Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BA6620 Offset: 0x1BA6620 VA: 0x1BA6620 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BA67A4 Offset: 0x1BA67A4 VA: 0x1BA67A4
	public void .ctor() { }

	// RVA: 0x1BA6840 Offset: 0x1BA6840 VA: 0x1BA6840
	public void .ctor(AkVector in_sourcePosition, float in_fDistanceScalingFactor, float in_fLevel) { }

	// RVA: 0x1BA6904 Offset: 0x1BA6904 VA: 0x1BA6904
	public void SetOneTexture(uint in_texture) { }

	// RVA: 0x1BA6994 Offset: 0x1BA6994 VA: 0x1BA6994
	public void SetName(string in_pName) { }

	// RVA: 0x1BA6A24 Offset: 0x1BA6A24 VA: 0x1BA6A24
	public void set_params_(AkImageSourceParams value) { }

	// RVA: 0x1BA6AFC Offset: 0x1BA6AFC VA: 0x1BA6AFC
	public AkImageSourceParams get_params_() { }
}
