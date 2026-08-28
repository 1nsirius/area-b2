// Namespace: 
public class AkCommunicationSettings : IDisposable // TypeDefIndex: 5860
{
	// Fields
	private IntPtr swigCPtr; // 0x8
	protected bool swigCMemOwn; // 0xC

	// Properties
	public uint uPoolSize { get; set; }
	public ushort uDiscoveryBroadcastPort { get; set; }
	public ushort uCommandPort { get; set; }
	public ushort uNotificationPort { get; set; }
	public bool bInitSystemLib { get; set; }
	public string szAppNetworkName { get; set; }

	// Methods

	// RVA: 0xFE6D30 Offset: 0xFE6D30 VA: 0xFE6D30
	internal void .ctor(IntPtr cPtr, bool cMemoryOwn) { }

	// RVA: 0xFE6D58 Offset: 0xFE6D58 VA: 0xFE6D58
	internal static IntPtr getCPtr(AkCommunicationSettings obj) { }

	// RVA: 0xFE6DB0 Offset: 0xFE6DB0 VA: 0xFE6DB0 Slot: 5
	internal virtual void setCPtr(IntPtr cPtr) { }

	// RVA: 0xFE6DDC Offset: 0xFE6DDC VA: 0xFE6DDC Slot: 1
	protected override void Finalize() { }

	// RVA: 0xFE6E50 Offset: 0xFE6E50 VA: 0xFE6E50 Slot: 6
	public virtual void Dispose() { }

	// RVA: 0xFDEF24 Offset: 0xFDEF24 VA: 0xFDEF24
	public void .ctor() { }

	// RVA: 0xFE5D6C Offset: 0xFE5D6C VA: 0xFE5D6C
	public void set_uPoolSize(uint value) { }

	// RVA: 0xFE6FD4 Offset: 0xFE6FD4 VA: 0xFE6FD4
	public uint get_uPoolSize() { }

	// RVA: 0xFE5DFC Offset: 0xFE5DFC VA: 0xFE5DFC
	public void set_uDiscoveryBroadcastPort(ushort value) { }

	// RVA: 0xFE705C Offset: 0xFE705C VA: 0xFE705C
	public ushort get_uDiscoveryBroadcastPort() { }

	// RVA: 0xFE5E8C Offset: 0xFE5E8C VA: 0xFE5E8C
	public void set_uCommandPort(ushort value) { }

	// RVA: 0xFE70E4 Offset: 0xFE70E4 VA: 0xFE70E4
	public ushort get_uCommandPort() { }

	// RVA: 0xFE5F1C Offset: 0xFE5F1C VA: 0xFE5F1C
	public void set_uNotificationPort(ushort value) { }

	// RVA: 0xFE716C Offset: 0xFE716C VA: 0xFE716C
	public ushort get_uNotificationPort() { }

	// RVA: 0xFE5FAC Offset: 0xFE5FAC VA: 0xFE5FAC
	public void set_bInitSystemLib(bool value) { }

	// RVA: 0xFE71F4 Offset: 0xFE71F4 VA: 0xFE71F4
	public bool get_bInitSystemLib() { }

	// RVA: 0xFE603C Offset: 0xFE603C VA: 0xFE603C
	public void set_szAppNetworkName(string value) { }

	// RVA: 0xFE727C Offset: 0xFE727C VA: 0xFE727C
	public string get_szAppNetworkName() { }
}
