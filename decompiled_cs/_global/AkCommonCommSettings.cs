// Namespace: 
[Serializable]
public class AkCommonCommSettings : AkSettingsValidationHandler // TypeDefIndex: 5995
{
	// Fields
	[TooltipAttribute] // RVA: 0x55F720 Offset: 0x55F720 VA: 0x55F720
	public uint m_PoolSize; // 0x8
	public static ushort DefaultDiscoveryBroadcastPort; // 0x0
	[TooltipAttribute] // RVA: 0x55F76C Offset: 0x55F76C VA: 0x55F76C
	public ushort m_DiscoveryBroadcastPort; // 0xC
	[TooltipAttribute] // RVA: 0x55F7A0 Offset: 0x55F7A0 VA: 0x55F7A0
	public ushort m_CommandPort; // 0xE
	[TooltipAttribute] // RVA: 0x55F7D4 Offset: 0x55F7D4 VA: 0x55F7D4
	public ushort m_NotificationPort; // 0x10
	[TooltipAttribute] // RVA: 0x55F808 Offset: 0x55F808 VA: 0x55F808
	public bool m_InitializeSystemComms; // 0x12
	[TooltipAttribute] // RVA: 0x55F83C Offset: 0x55F83C VA: 0x55F83C
	public string m_NetworkName; // 0x14

	// Methods

	// RVA: 0xFE5C5C Offset: 0xFE5C5C VA: 0xFE5C5C Slot: 5
	public virtual void CopyTo(AkCommunicationSettings settings) { }

	// RVA: 0xFE60CC Offset: 0xFE60CC VA: 0xFE60CC
	public void .ctor() { }

	// RVA: 0xFE617C Offset: 0xFE617C VA: 0xFE617C
	private static void .cctor() { }
}
