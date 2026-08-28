// Namespace: 
public class AkPropagationPathInfo : IDisposable // TypeDefIndex: 5944
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC
	public const uint kMaxNodes = 8;

	// Properties
	public AkVector nodePoint { get; set; }
	public uint numNodes { get; set; }
	public float length { get; set; }
	public float gain { get; set; }
	public float dryDiffraction { get; set; }
	public float wetDiffraction { get; set; }

	// Methods

	// RVA: 0x1BBC6E8 Offset: 0x1BBC6E8 VA: 0x1BBC6E8
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BBC710 Offset: 0x1BBC710 VA: 0x1BBC710
	internal static IntPtr getCPtr(AkPropagationPathInfo obj) { }

	// RVA: 0x1BBC768 Offset: 0x1BBC768 VA: 0x1BBC768 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BBC794 Offset: 0x1BBC794 VA: 0x1BBC794 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BBC808 Offset: 0x1BBC808 VA: 0x1BBC808 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BBC98C Offset: 0x1BBC98C VA: 0x1BBC98C
	public void set_nodePoint(AkVector value) { }

	// RVA: 0x1BBCA2C Offset: 0x1BBCA2C VA: 0x1BBCA2C
	public AkVector get_nodePoint() { }

	// RVA: 0x1BBCAFC Offset: 0x1BBCAFC VA: 0x1BBCAFC
	public void set_numNodes(uint value) { }

	// RVA: 0x1BBCB8C Offset: 0x1BBCB8C VA: 0x1BBCB8C
	public uint get_numNodes() { }

	// RVA: 0x1BBCC14 Offset: 0x1BBCC14 VA: 0x1BBCC14
	public void set_length(float value) { }

	// RVA: 0x1BBCCA4 Offset: 0x1BBCCA4 VA: 0x1BBCCA4
	public float get_length() { }

	// RVA: 0x1BBCD2C Offset: 0x1BBCD2C VA: 0x1BBCD2C
	public void set_gain(float value) { }

	// RVA: 0x1BBCDBC Offset: 0x1BBCDBC VA: 0x1BBCDBC
	public float get_gain() { }

	// RVA: 0x1BBCE44 Offset: 0x1BBCE44 VA: 0x1BBCE44
	public void set_dryDiffraction(float value) { }

	// RVA: 0x1BBCED4 Offset: 0x1BBCED4 VA: 0x1BBCED4
	public float get_dryDiffraction() { }

	// RVA: 0x1BBCF5C Offset: 0x1BBCF5C VA: 0x1BBCF5C
	public void set_wetDiffraction(float value) { }

	// RVA: 0x1BBCFEC Offset: 0x1BBCFEC VA: 0x1BBCFEC
	public float get_wetDiffraction() { }

	// RVA: 0x1BBD074 Offset: 0x1BBD074 VA: 0x1BBD074
	public static int GetSizeOf() { }

	// RVA: 0x1BBD0F0 Offset: 0x1BBD0F0 VA: 0x1BBD0F0
	public AkVector GetNodePoint(uint idx) { }

	// RVA: 0x1BBD1C8 Offset: 0x1BBD1C8 VA: 0x1BBD1C8
	public void Clone(AkPropagationPathInfo other) { }

	// RVA: 0x1BBD2A0 Offset: 0x1BBD2A0 VA: 0x1BBD2A0
	public void .ctor() { }
}
