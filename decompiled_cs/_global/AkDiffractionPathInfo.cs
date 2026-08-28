// Namespace: 
public class AkDiffractionPathInfo : IDisposable // TypeDefIndex: 5896
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC
	public const uint kMaxNodes = 8;

	// Properties
	public AkTransform virtualPos { get; set; }
	public uint nodeCount { get; set; }
	public float diffraction { get; set; }
	public float totLength { get; set; }
	public float obstructionValue { get; set; }

	// Methods

	// RVA: 0xFE80A0 Offset: 0xFE80A0 VA: 0xFE80A0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFE80C8 Offset: 0xFE80C8 VA: 0xFE80C8
	internal static IntPtr getCPtr(AkDiffractionPathInfo obj) { }

	// RVA: 0xFE8120 Offset: 0xFE8120 VA: 0xFE8120 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE814C Offset: 0xFE814C VA: 0xFE814C Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE81C0 Offset: 0xFE81C0 VA: 0xFE81C0 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFE8344 Offset: 0xFE8344 VA: 0xFE8344
	public void set_virtualPos(AkTransform value) { }

	// RVA: 0xFE83E4 Offset: 0xFE83E4 VA: 0xFE83E4
	public AkTransform get_virtualPos() { }

	// RVA: 0xFE84B4 Offset: 0xFE84B4 VA: 0xFE84B4
	public void set_nodeCount(uint value) { }

	// RVA: 0xFE8544 Offset: 0xFE8544 VA: 0xFE8544
	public uint get_nodeCount() { }

	// RVA: 0xFE85CC Offset: 0xFE85CC VA: 0xFE85CC
	public void set_diffraction(float value) { }

	// RVA: 0xFE865C Offset: 0xFE865C VA: 0xFE865C
	public float get_diffraction() { }

	// RVA: 0xFE86E4 Offset: 0xFE86E4 VA: 0xFE86E4
	public void set_totLength(float value) { }

	// RVA: 0xFE8774 Offset: 0xFE8774 VA: 0xFE8774
	public float get_totLength() { }

	// RVA: 0xFE87FC Offset: 0xFE87FC VA: 0xFE87FC
	public void set_obstructionValue(float value) { }

	// RVA: 0xFE888C Offset: 0xFE888C VA: 0xFE888C
	public float get_obstructionValue() { }

	// RVA: 0xFE8914 Offset: 0xFE8914 VA: 0xFE8914
	public static int GetSizeOf() { }

	// RVA: 0xFE8990 Offset: 0xFE8990 VA: 0xFE8990
	public AkVector GetNodes(uint idx) { }

	// RVA: 0xFE8A68 Offset: 0xFE8A68 VA: 0xFE8A68
	public float GetAngles(uint idx) { }

	// RVA: 0xFE8AF8 Offset: 0xFE8AF8 VA: 0xFE8AF8
	public void Clone(AkDiffractionPathInfo other) { }

	// RVA: 0xFE8BD0 Offset: 0xFE8BD0 VA: 0xFE8BD0
	public void .ctor() { }
}
