// Namespace: 
public class AkOutputSettings : IDisposable // TypeDefIndex: 5935
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint audioDeviceShareset { get; set; }
	public uint idDevice { get; set; }
	public AkPanningRule ePanningRule { get; set; }
	public AkChannelConfig channelConfig { get; set; }

	// Methods

	// RVA: 0x1BA7B68 Offset: 0x1BA7B68 VA: 0x1BA7B68
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0x1BA7A3C Offset: 0x1BA7A3C VA: 0x1BA7A3C
	internal static IntPtr getCPtr(AkOutputSettings obj) { }

	// RVA: 0x1BB60BC Offset: 0x1BB60BC VA: 0x1BB60BC Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0x1BB60E8 Offset: 0x1BB60E8 VA: 0x1BB60E8 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BB615C Offset: 0x1BB615C VA: 0x1BB615C Slot: 6
	public virtual void Dispose() { }

	// RVA: 0x1BB62E0 Offset: 0x1BB62E0 VA: 0x1BB62E0
	public void .ctor() { }

	// RVA: 0x1BB637C Offset: 0x1BB637C VA: 0x1BB637C
	public void .ctor(string in_szDeviceShareSet, uint in_idDevice, AkChannelConfig in_channelConfig, AkPanningRule in_ePanning) { }

	// RVA: 0x1BB6454 Offset: 0x1BB6454 VA: 0x1BB6454
	public void .ctor(string in_szDeviceShareSet, uint in_idDevice, AkChannelConfig in_channelConfig) { }

	// RVA: 0x1BB6518 Offset: 0x1BB6518 VA: 0x1BB6518
	public void .ctor(string in_szDeviceShareSet, uint in_idDevice) { }

	// RVA: 0x1BB65C4 Offset: 0x1BB65C4 VA: 0x1BB65C4
	public void .ctor(string in_szDeviceShareSet) { }

	// RVA: 0x1BB6668 Offset: 0x1BB6668 VA: 0x1BB6668
	public void set_audioDeviceShareset(uint value) { }

	// RVA: 0x1BB66F8 Offset: 0x1BB66F8 VA: 0x1BB66F8
	public uint get_audioDeviceShareset() { }

	// RVA: 0x1BB6780 Offset: 0x1BB6780 VA: 0x1BB6780
	public void set_idDevice(uint value) { }

	// RVA: 0x1BB6810 Offset: 0x1BB6810 VA: 0x1BB6810
	public uint get_idDevice() { }

	// RVA: 0x1BB6898 Offset: 0x1BB6898 VA: 0x1BB6898
	public void set_ePanningRule(AkPanningRule value) { }

	// RVA: 0x1BB6928 Offset: 0x1BB6928 VA: 0x1BB6928
	public AkPanningRule get_ePanningRule() { }

	// RVA: 0x1BB69B0 Offset: 0x1BB69B0 VA: 0x1BB69B0
	public void set_channelConfig(AkChannelConfig value) { }

	// RVA: 0x1BB6A50 Offset: 0x1BB6A50 VA: 0x1BB6A50
	public AkChannelConfig get_channelConfig() { }
}
