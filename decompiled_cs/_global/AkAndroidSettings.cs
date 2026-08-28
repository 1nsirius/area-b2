// Namespace: 
public class AkAndroidSettings : AkWwiseInitializationSettings.PlatformSettings // TypeDefIndex: 5962
{
	// Fields
	[HideInInspector] // RVA: 0x55EE10 Offset: 0x55EE10 VA: 0x55EE10
	public AkCommonUserSettings UserSettings; // 0x18
	[HideInInspector] // RVA: 0x55EE20 Offset: 0x55EE20 VA: 0x55EE20
	public AkAndroidSettings.PlatformAdvancedSettings AdvancedSettings; // 0x1C
	[HideInInspector] // RVA: 0x55EE30 Offset: 0x55EE30 VA: 0x55EE30
	public AkCommonCommSettings CommsSettings; // 0x20

	// Methods

	// RVA: 0xFD5AA0 Offset: 0xFD5AA0 VA: 0xFD5AA0
	public void .ctor() { }

	// RVA: 0xFD5E04 Offset: 0xFD5E04 VA: 0xFD5E04 Slot: 11
	protected override AkCommonUserSettings GetUserSettings() { }

	// RVA: 0xFD5E0C Offset: 0xFD5E0C VA: 0xFD5E0C Slot: 12
	protected override AkCommonAdvancedSettings GetAdvancedSettings() { }

	// RVA: 0xFD5E14 Offset: 0xFD5E14 VA: 0xFD5E14 Slot: 13
	protected override AkCommonCommSettings GetCommsSettings() { }
}
