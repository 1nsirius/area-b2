// Namespace: 
[Serializable]
public class AkCommonOutputSettings // TypeDefIndex: 5984
{
	// Fields
	[TooltipAttribute] // RVA: 0x55EE50 Offset: 0x55EE50 VA: 0x55EE50
	public string m_AudioDeviceShareset; // 0x8
	[TooltipAttribute] // RVA: 0x55EE84 Offset: 0x55EE84 VA: 0x55EE84
	public uint m_DeviceID; // 0xC
	[TooltipAttribute] // RVA: 0x55EEB8 Offset: 0x55EEB8 VA: 0x55EEB8
	public AkCommonOutputSettings.PanningRule m_PanningRule; // 0x10
	[TooltipAttribute] // RVA: 0x55EEEC Offset: 0x55EEEC VA: 0x55EEEC
	public AkCommonOutputSettings.ChannelConfiguration m_ChannelConfig; // 0x14

	// Methods

	// RVA: 0xFE61E4 Offset: 0xFE61E4 VA: 0xFE61E4
	public void CopyTo(AkOutputSettings settings) { }

	// RVA: 0xFD5D64 Offset: 0xFD5D64 VA: 0xFD5D64
	public void .ctor() { }
}
