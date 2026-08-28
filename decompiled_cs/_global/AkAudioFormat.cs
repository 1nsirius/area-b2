// Namespace: 
public class AkAudioFormat : IDisposable // TypeDefIndex: 5877
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uSampleRate { get; set; }
	public AkChannelConfig channelConfig { get; set; }
	public uint uBitsPerSample { get; set; }
	public uint uBlockAlign { get; set; }
	public uint uTypeID { get; set; }
	public uint uInterleaveID { get; set; }

	// Methods

	// RVA: 0xFD5EF0 Offset: 0xFD5EF0 VA: 0xFD5EF0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFD5F18 Offset: 0xFD5F18 VA: 0xFD5F18
	internal static IntPtr getCPtr(AkAudioFormat obj) { }

	// RVA: 0xFD5F70 Offset: 0xFD5F70 VA: 0xFD5F70 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFD5F9C Offset: 0xFD5F9C VA: 0xFD5F9C Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFD6010 Offset: 0xFD6010 VA: 0xFD6010 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFD6194 Offset: 0xFD6194 VA: 0xFD6194
	public void set_uSampleRate(uint value) { }

	// RVA: 0xFD6224 Offset: 0xFD6224 VA: 0xFD6224
	public uint get_uSampleRate() { }

	// RVA: 0xFD62AC Offset: 0xFD62AC VA: 0xFD62AC
	public void set_channelConfig(AkChannelConfig value) { }

	// RVA: 0xFD63DC Offset: 0xFD63DC VA: 0xFD63DC
	public AkChannelConfig get_channelConfig() { }

	// RVA: 0xFD64D8 Offset: 0xFD64D8 VA: 0xFD64D8
	public void set_uBitsPerSample(uint value) { }

	// RVA: 0xFD6568 Offset: 0xFD6568 VA: 0xFD6568
	public uint get_uBitsPerSample() { }

	// RVA: 0xFD65F0 Offset: 0xFD65F0 VA: 0xFD65F0
	public void set_uBlockAlign(uint value) { }

	// RVA: 0xFD6680 Offset: 0xFD6680 VA: 0xFD6680
	public uint get_uBlockAlign() { }

	// RVA: 0xFD6708 Offset: 0xFD6708 VA: 0xFD6708
	public void set_uTypeID(uint value) { }

	// RVA: 0xFD6798 Offset: 0xFD6798 VA: 0xFD6798
	public uint get_uTypeID() { }

	// RVA: 0xFD6820 Offset: 0xFD6820 VA: 0xFD6820
	public void set_uInterleaveID(uint value) { }

	// RVA: 0xFD68B0 Offset: 0xFD68B0 VA: 0xFD68B0
	public uint get_uInterleaveID() { }

	// RVA: 0xFD6938 Offset: 0xFD6938 VA: 0xFD6938
	public uint GetNumChannels() { }

	// RVA: 0xFD69C0 Offset: 0xFD69C0 VA: 0xFD69C0
	public uint GetBitsPerSample() { }

	// RVA: 0xFD6A48 Offset: 0xFD6A48 VA: 0xFD6A48
	public uint GetBlockAlign() { }

	// RVA: 0xFD6AD0 Offset: 0xFD6AD0 VA: 0xFD6AD0
	public uint GetTypeID() { }

	// RVA: 0xFD6B58 Offset: 0xFD6B58 VA: 0xFD6B58
	public uint GetInterleaveID() { }

	// RVA: 0xFD6BE0 Offset: 0xFD6BE0 VA: 0xFD6BE0
	public void SetAll(uint in_uSampleRate, AkChannelConfig in_channelConfig, uint in_uBitsPerSample, uint in_uBlockAlign, uint in_uTypeID, uint in_uInterleaveID) { }

	// RVA: 0xFD6CE0 Offset: 0xFD6CE0 VA: 0xFD6CE0
	public bool IsChannelConfigSupported() { }

	// RVA: 0xFD6D68 Offset: 0xFD6D68 VA: 0xFD6D68
	public void .ctor() { }
}
