// Namespace: 
public class AkChannelConfig : IDisposable // TypeDefIndex: 5888
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uNumChannels { get; set; }
	public uint eConfigType { get; set; }
	public uint uChannelMask { get; set; }

	// Methods

	// RVA: 0xFD64B0 Offset: 0xFD64B0 VA: 0xFD64B0
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFD6384 Offset: 0xFD6384 VA: 0xFD6384
	internal static IntPtr getCPtr(AkChannelConfig obj) { }

	// RVA: 0xFE3DDC Offset: 0xFE3DDC VA: 0xFE3DDC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE3E08 Offset: 0xFE3E08 VA: 0xFE3E08 Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE3E7C Offset: 0xFE3E7C VA: 0xFE3E7C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFE4000 Offset: 0xFE4000 VA: 0xFE4000
	public void set_uNumChannels(uint value) { }

	// RVA: 0xFE4090 Offset: 0xFE4090 VA: 0xFE4090
	public uint get_uNumChannels() { }

	// RVA: 0xFE4118 Offset: 0xFE4118 VA: 0xFE4118
	public void set_eConfigType(uint value) { }

	// RVA: 0xFE41A8 Offset: 0xFE41A8 VA: 0xFE41A8
	public uint get_eConfigType() { }

	// RVA: 0xFE4230 Offset: 0xFE4230 VA: 0xFE4230
	public void set_uChannelMask(uint value) { }

	// RVA: 0xFE42C0 Offset: 0xFE42C0 VA: 0xFE42C0
	public uint get_uChannelMask() { }

	// RVA: 0xFE4348 Offset: 0xFE4348 VA: 0xFE4348
	public void .ctor() { }

	// RVA: 0xFE43E4 Offset: 0xFE43E4 VA: 0xFE43E4
	public void .ctor(uint in_uNumChannels, uint in_uChannelMask) { }

	// RVA: 0xFE4490 Offset: 0xFE4490 VA: 0xFE4490
	public void Clear() { }

	// RVA: 0xFE4518 Offset: 0xFE4518 VA: 0xFE4518
	public void SetStandard(uint in_uChannelMask) { }

	// RVA: 0xFE45A8 Offset: 0xFE45A8 VA: 0xFE45A8
	public void SetStandardOrAnonymous(uint in_uNumChannels, uint in_uChannelMask) { }

	// RVA: 0xFE4640 Offset: 0xFE4640 VA: 0xFE4640
	public void SetAnonymous(uint in_uNumChannels) { }

	// RVA: 0xFE46D0 Offset: 0xFE46D0 VA: 0xFE46D0
	public void SetAmbisonic(uint in_uNumChannels) { }

	// RVA: 0xFE4760 Offset: 0xFE4760 VA: 0xFE4760
	public bool IsValid() { }

	// RVA: 0xFE47E8 Offset: 0xFE47E8 VA: 0xFE47E8
	public uint Serialize() { }

	// RVA: 0xFE4870 Offset: 0xFE4870 VA: 0xFE4870
	public void Deserialize(uint in_uChannelConfig) { }

	// RVA: 0xFE4900 Offset: 0xFE4900 VA: 0xFE4900
	public AkChannelConfig RemoveLFE() { }

	// RVA: 0xFE49BC Offset: 0xFE49BC VA: 0xFE49BC
	public AkChannelConfig RemoveCenter() { }

	// RVA: 0xFE4A78 Offset: 0xFE4A78 VA: 0xFE4A78
	public bool IsChannelConfigSupported() { }
}
