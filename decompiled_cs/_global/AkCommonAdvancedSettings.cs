// Namespace: 
[Serializable]
public class AkCommonAdvancedSettings : AkSettingsValidationHandler // TypeDefIndex: 5993
{
	// Fields
	[TooltipAttribute] // RVA: 0x55F45C Offset: 0x55F45C VA: 0x55F45C
	public uint m_IOMemorySize; // 0x8
	[TooltipAttribute] // RVA: 0x55F490 Offset: 0x55F490 VA: 0x55F490
	public float m_TargetAutoStreamBufferLengthMs; // 0xC
	[TooltipAttribute] // RVA: 0x55F4C4 Offset: 0x55F4C4 VA: 0x55F4C4
	public bool m_UseStreamCache; // 0x10
	[TooltipAttribute] // RVA: 0x55F4F8 Offset: 0x55F4F8 VA: 0x55F4F8
	public uint m_MaximumPinnedBytesInCache; // 0x14
	[TooltipAttribute] // RVA: 0x55F52C Offset: 0x55F52C VA: 0x55F52C
	public int m_PrepareEventMemoryPoolID; // 0x18
	[TooltipAttribute] // RVA: 0x55F560 Offset: 0x55F560 VA: 0x55F560
	public bool m_EnableGameSyncPreparation; // 0x1C
	[TooltipAttribute] // RVA: 0x55F5CC Offset: 0x55F5CC VA: 0x55F5CC
	public uint m_ContinuousPlaybackLookAhead; // 0x20
	[TooltipAttribute] // RVA: 0x55F600 Offset: 0x55F600 VA: 0x55F600
	public uint m_MonitorPoolSize; // 0x24
	[TooltipAttribute] // RVA: 0x55F634 Offset: 0x55F634 VA: 0x55F634
	public uint m_MonitorQueuePoolSize; // 0x28
	[TooltipAttribute] // RVA: 0x55F668 Offset: 0x55F668 VA: 0x55F668
	public uint m_MaximumHardwareTimeoutMs; // 0x2C
	[TooltipAttribute] // RVA: 0x55F69C Offset: 0x55F69C VA: 0x55F69C
	public AkCommonAdvancedSettings.SpatialAudioSettings m_SpatialAudioSettings; // 0x30
	[TooltipAttribute] // RVA: 0x55F6EC Offset: 0x55F6EC VA: 0x55F6EC
	public bool m_RenderDuringFocusLoss; // 0x34

	// Methods

	// RVA: 0xFE562C Offset: 0xFE562C VA: 0xFE562C Slot: 5
	public virtual void CopyTo(AkDeviceSettings settings) { }

	// RVA: 0xFE5930 Offset: 0xFE5930 VA: 0xFE5930 Slot: 6
	public virtual void CopyTo(AkInitSettings settings) { }

	// RVA: 0xFE5A54 Offset: 0xFE5A54 VA: 0xFE5A54 Slot: 7
	public virtual void CopyTo(AkPlatformInitSettings settings) { }

	// RVA: 0xFE5A58 Offset: 0xFE5A58 VA: 0xFE5A58 Slot: 8
	public virtual void CopyTo(AkSpatialAudioInitSettings settings) { }

	// RVA: 0xFE5AE4 Offset: 0xFE5AE4 VA: 0xFE5AE4 Slot: 9
	public virtual void CopyTo(AkUnityPlatformSpecificSettings settings) { }

	// RVA: 0xFE5AE8 Offset: 0xFE5AE8 VA: 0xFE5AE8 Slot: 4
	public override void Validate() { }

	// RVA: 0xFD5EA8 Offset: 0xFD5EA8 VA: 0xFD5EA8
	public void .ctor() { }
}
