// Namespace: 
[Serializable]
public class AkWindowsSettings.PlatformAdvancedSettings : AkCommonAdvancedSettings // TypeDefIndex: 6042
{
	// Fields
	[TooltipAttribute] // RVA: 0x56DBBC Offset: 0x56DBBC VA: 0x56DBBC
	[AkEnumFlagAttribute] // RVA: 0x56DBBC Offset: 0x56DBBC VA: 0x56DBBC
	public AkWindowsSettings.PlatformAdvancedSettings.AudioAPI m_AudioAPI; // 0x38
	[TooltipAttribute] // RVA: 0x56DC5C Offset: 0x56DC5C VA: 0x56DC5C
	public bool m_GlobalFocus; // 0x3C

	// Methods

	// RVA: 0xCABF5C Offset: 0xCABF5C VA: 0xCABF5C Slot: 7
	public override void CopyTo(AkPlatformInitSettings settings) { }

	// RVA: 0xCABF60 Offset: 0xCABF60 VA: 0xCABF60
	public void .ctor() { }
}
