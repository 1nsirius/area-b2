// Namespace: 
[Serializable]
public class AkiOSSettings.PlatformAdvancedSettings : AkCommonAdvancedSettings // TypeDefIndex: 6036
{
	// Fields
	[TooltipAttribute] // RVA: 0x56DAB4 Offset: 0x56DAB4 VA: 0x56DAB4
	public AkiOSSettings.PlatformAdvancedSettings.Category m_AudioSessionCategory; // 0x38
	[TooltipAttribute] // RVA: 0x56DAE8 Offset: 0x56DAE8 VA: 0x56DAE8
	[AkEnumFlagAttribute] // RVA: 0x56DAE8 Offset: 0x56DAE8 VA: 0x56DAE8
	public AkiOSSettings.PlatformAdvancedSettings.CategoryOptions m_AudioSessionCategoryOptions; // 0x3C
	[TooltipAttribute] // RVA: 0x56DB88 Offset: 0x56DB88 VA: 0x56DB88
	public AkiOSSettings.PlatformAdvancedSettings.Mode m_AudioSessionMode; // 0x40

	// Methods

	// RVA: 0xCAF260 Offset: 0xCAF260 VA: 0xCAF260 Slot: 7
	public override void CopyTo(AkPlatformInitSettings settings) { }

	// RVA: 0xCAF264 Offset: 0xCAF264 VA: 0xCAF264
	public void .ctor() { }
}
