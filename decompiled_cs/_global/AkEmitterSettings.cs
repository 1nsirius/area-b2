// Namespace: 
public class AkEmitterSettings : IDisposable // TypeDefIndex: 5900
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint reflectAuxBusID { get; set; }
	public float reflectionMaxPathLength { get; set; }
	public float reflectionsAuxBusGain { get; set; }
	public uint reflectionsOrder { get; set; }
	public uint reflectorFilterMask { get; set; }
	public float roomReverbAuxBusGain { get; set; }
	public uint diffractionMaxEdges { get; set; }
	public uint diffractionMaxPaths { get; set; }
	public float diffractionMaxPathLength { get; set; }
	public byte useImageSources { get; set; }

	// Methods

	// RVA: 0xFEA160 Offset: 0xFEA160 VA: 0xFEA160
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFEA188 Offset: 0xFEA188 VA: 0xFEA188
	internal static IntPtr getCPtr(AkEmitterSettings obj) { }

	// RVA: 0xFEA1E0 Offset: 0xFEA1E0 VA: 0xFEA1E0 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFEA20C Offset: 0xFEA20C VA: 0xFEA20C Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFEA280 Offset: 0xFEA280 VA: 0xFEA280 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFEA404 Offset: 0xFEA404 VA: 0xFEA404
	public void .ctor() { }

	// RVA: 0xFEA4A0 Offset: 0xFEA4A0 VA: 0xFEA4A0
	public void set_reflectAuxBusID(uint value) { }

	// RVA: 0xFEA530 Offset: 0xFEA530 VA: 0xFEA530
	public uint get_reflectAuxBusID() { }

	// RVA: 0xFEA5B8 Offset: 0xFEA5B8 VA: 0xFEA5B8
	public void set_reflectionMaxPathLength(float value) { }

	// RVA: 0xFEA648 Offset: 0xFEA648 VA: 0xFEA648
	public float get_reflectionMaxPathLength() { }

	// RVA: 0xFEA6D0 Offset: 0xFEA6D0 VA: 0xFEA6D0
	public void set_reflectionsAuxBusGain(float value) { }

	// RVA: 0xFEA760 Offset: 0xFEA760 VA: 0xFEA760
	public float get_reflectionsAuxBusGain() { }

	// RVA: 0xFEA7E8 Offset: 0xFEA7E8 VA: 0xFEA7E8
	public void set_reflectionsOrder(uint value) { }

	// RVA: 0xFEA878 Offset: 0xFEA878 VA: 0xFEA878
	public uint get_reflectionsOrder() { }

	// RVA: 0xFEA900 Offset: 0xFEA900 VA: 0xFEA900
	public void set_reflectorFilterMask(uint value) { }

	// RVA: 0xFEA990 Offset: 0xFEA990 VA: 0xFEA990
	public uint get_reflectorFilterMask() { }

	// RVA: 0xFEAA18 Offset: 0xFEAA18 VA: 0xFEAA18
	public void set_roomReverbAuxBusGain(float value) { }

	// RVA: 0xFEAAA8 Offset: 0xFEAAA8 VA: 0xFEAAA8
	public float get_roomReverbAuxBusGain() { }

	// RVA: 0xFEAB30 Offset: 0xFEAB30 VA: 0xFEAB30
	public void set_diffractionMaxEdges(uint value) { }

	// RVA: 0xFEABC0 Offset: 0xFEABC0 VA: 0xFEABC0
	public uint get_diffractionMaxEdges() { }

	// RVA: 0xFEAC48 Offset: 0xFEAC48 VA: 0xFEAC48
	public void set_diffractionMaxPaths(uint value) { }

	// RVA: 0xFEACD8 Offset: 0xFEACD8 VA: 0xFEACD8
	public uint get_diffractionMaxPaths() { }

	// RVA: 0xFEAD60 Offset: 0xFEAD60 VA: 0xFEAD60
	public void set_diffractionMaxPathLength(float value) { }

	// RVA: 0xFEADF0 Offset: 0xFEADF0 VA: 0xFEADF0
	public float get_diffractionMaxPathLength() { }

	// RVA: 0xFEAE78 Offset: 0xFEAE78 VA: 0xFEAE78
	public void set_useImageSources(byte value) { }

	// RVA: 0xFEAF08 Offset: 0xFEAF08 VA: 0xFEAF08
	public byte get_useImageSources() { }
}
