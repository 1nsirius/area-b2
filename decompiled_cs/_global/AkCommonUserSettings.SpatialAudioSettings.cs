// Namespace: 
[Serializable]
public class AkCommonUserSettings.SpatialAudioSettings // TypeDefIndex: 5991
{
	// Fields
	[TooltipAttribute] // RVA: 0x56D800 Offset: 0x56D800 VA: 0x56D800
	public uint m_PoolSize; // 0x8
	[TooltipAttribute] // RVA: 0x56D854 Offset: 0x56D854 VA: 0x56D854
	[RangeAttribute] // RVA: 0x56D854 Offset: 0x56D854 VA: 0x56D854
	public uint m_MaxSoundPropagationDepth; // 0xC
	[TooltipAttribute] // RVA: 0x56D8D8 Offset: 0x56D8D8 VA: 0x56D8D8
	[AkEnumFlagAttribute] // RVA: 0x56D8D8 Offset: 0x56D8D8 VA: 0x56D8D8
	public AkCommonUserSettings.SpatialAudioSettings.DiffractionFlags m_DiffractionFlags; // 0x10

	// Methods

	// RVA: 0xFE6D10 Offset: 0xFE6D10 VA: 0xFE6D10
	public void .ctor() { }
}
