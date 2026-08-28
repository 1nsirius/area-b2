// Namespace: 
[Serializable]
public class AkCommonUserSettings : AkSettingsValidationHandler // TypeDefIndex: 5990
{
	// Fields
	[TooltipAttribute] // RVA: 0x55EF20 Offset: 0x55EF20 VA: 0x55EF20
	public string m_BasePath; // 0x8
	[TooltipAttribute] // RVA: 0x55EF54 Offset: 0x55EF54 VA: 0x55EF54
	public string m_StartupLanguage; // 0xC
	[TooltipAttribute] // RVA: 0x55EFA8 Offset: 0x55EFA8 VA: 0x55EFA8
	public uint m_PreparePoolSize; // 0x10
	[TooltipAttribute] // RVA: 0x55EFDC Offset: 0x55EFDC VA: 0x55EFDC
	public int m_CallbackManagerBufferSize; // 0x14
	[TooltipAttribute] // RVA: 0x55F010 Offset: 0x55F010 VA: 0x55F010
	public bool m_EngineLogging; // 0x18
	[TooltipAttribute] // RVA: 0x55F044 Offset: 0x55F044 VA: 0x55F044
	public uint m_MaximumNumberOfMemoryPools; // 0x1C
	[TooltipAttribute] // RVA: 0x55F078 Offset: 0x55F078 VA: 0x55F078
	public uint m_MaximumNumberOfPositioningPaths; // 0x20
	[TooltipAttribute] // RVA: 0x55F0E0 Offset: 0x55F0E0 VA: 0x55F0E0
	public uint m_DefaultPoolSize; // 0x24
	[TooltipAttribute] // RVA: 0x55F130 Offset: 0x55F130 VA: 0x55F130
	[RangeAttribute] // RVA: 0x55F130 Offset: 0x55F130 VA: 0x55F130
	public float m_MemoryCutoffThreshold; // 0x28
	[TooltipAttribute] // RVA: 0x55F180 Offset: 0x55F180 VA: 0x55F180
	public uint m_CommandQueueSize; // 0x2C
	[TooltipAttribute] // RVA: 0x55F1C8 Offset: 0x55F1C8 VA: 0x55F1C8
	public uint m_SamplesPerFrame; // 0x30
	[TooltipAttribute] // RVA: 0x55F234 Offset: 0x55F234 VA: 0x55F234
	public AkCommonOutputSettings m_MainOutputSettings; // 0x34
	[TooltipAttribute] // RVA: 0x55F280 Offset: 0x55F280 VA: 0x55F280
	[RangeAttribute] // RVA: 0x55F280 Offset: 0x55F280 VA: 0x55F280
	public float m_StreamingLookAheadRatio; // 0x38
	[TooltipAttribute] // RVA: 0x55F2D0 Offset: 0x55F2D0 VA: 0x55F2D0
	public uint m_StreamManagerPoolSize; // 0x3C
	[TooltipAttribute] // RVA: 0x55F304 Offset: 0x55F304 VA: 0x55F304
	public uint m_SampleRate; // 0x40
	[TooltipAttribute] // RVA: 0x55F338 Offset: 0x55F338 VA: 0x55F338
	public uint m_LowerEnginePoolSize; // 0x44
	[TooltipAttribute] // RVA: 0x55F38C Offset: 0x55F38C VA: 0x55F38C
	[RangeAttribute] // RVA: 0x55F38C Offset: 0x55F38C VA: 0x55F38C
	public float m_LowerEngineMemoryCutoffThreshold; // 0x48
	[TooltipAttribute] // RVA: 0x55F3DC Offset: 0x55F3DC VA: 0x55F3DC
	public ushort m_NumberOfRefillsInVoice; // 0x4C
	[TooltipAttribute] // RVA: 0x55F410 Offset: 0x55F410 VA: 0x55F410
	public AkCommonUserSettings.SpatialAudioSettings m_SpatialAudioSettings; // 0x50

	// Methods

	// RVA: 0xFE6700 Offset: 0xFE6700 VA: 0xFE6700
	public void CopyTo(AkMemSettings settings) { }

	// RVA: 0xFE6A0C Offset: 0xFE6A0C VA: 0xFE6A0C
	protected static string GetPluginPath() { }

	// RVA: 0xFE6A14 Offset: 0xFE6A14 VA: 0xFE6A14 Slot: 5
	public virtual void CopyTo(AkInitSettings settings) { }

	// RVA: 0xFE6768 Offset: 0xFE6768 VA: 0xFE6768
	public void CopyTo(AkMusicSettings settings) { }

	// RVA: 0xFE6734 Offset: 0xFE6734 VA: 0xFE6734
	public void CopyTo(AkStreamMgrSettings settings) { }

	// RVA: 0xFE6B6C Offset: 0xFE6B6C VA: 0xFE6B6C Slot: 6
	public virtual void CopyTo(AkDeviceSettings settings) { }

	// RVA: 0xFE6B70 Offset: 0xFE6B70 VA: 0xFE6B70 Slot: 7
	public virtual void CopyTo(AkPlatformInitSettings settings) { }

	// RVA: 0xFE6C34 Offset: 0xFE6C34 VA: 0xFE6C34 Slot: 8
	public virtual void CopyTo(AkSpatialAudioInitSettings settings) { }

	// RVA: 0xFE6CF0 Offset: 0xFE6CF0 VA: 0xFE6CF0 Slot: 9
	public virtual void CopyTo(AkUnityPlatformSpecificSettings settings) { }

	// RVA: 0xFE6CF4 Offset: 0xFE6CF4 VA: 0xFE6CF4 Slot: 4
	public override void Validate() { }

	// RVA: 0xFD5C14 Offset: 0xFD5C14 VA: 0xFD5C14
	public void .ctor() { }
}
