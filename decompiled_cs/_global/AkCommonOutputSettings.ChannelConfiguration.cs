// Namespace: 
[Serializable]
public class AkCommonOutputSettings.ChannelConfiguration // TypeDefIndex: 5986
{
	// Fields
	[TooltipAttribute] // RVA: 0x56D6F8 Offset: 0x56D6F8 VA: 0x56D6F8
	public AkCommonOutputSettings.ChannelConfiguration.ChannelConfigType m_ChannelConfigType; // 0x8
	[TooltipAttribute] // RVA: 0x56D72C Offset: 0x56D72C VA: 0x56D72C
	[AkEnumFlagAttribute] // RVA: 0x56D72C Offset: 0x56D72C VA: 0x56D72C
	public AkCommonOutputSettings.ChannelConfiguration.ChannelMask m_ChannelMask; // 0xC
	[TooltipAttribute] // RVA: 0x56D7CC Offset: 0x56D7CC VA: 0x56D7CC
	public uint m_NumberOfChannels; // 0x10

	// Methods

	// RVA: 0xFE6354 Offset: 0xFE6354 VA: 0xFE6354
	public void CopyTo(AkChannelConfig config) { }

	// RVA: 0xFD5DFC Offset: 0xFD5DFC VA: 0xFD5DFC
	public void .ctor() { }
}
