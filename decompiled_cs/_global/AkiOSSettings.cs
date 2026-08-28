// Namespace: 
public class AkiOSSettings : AkWwiseInitializationSettings.PlatformSettings // TypeDefIndex: 6035
{
	// Fields
	[HideInInspector] // RVA: 0x55FA00 Offset: 0x55FA00 VA: 0x55FA00
	public AkCommonUserSettings UserSettings; // 0x18
	[HideInInspector] // RVA: 0x55FA10 Offset: 0x55FA10 VA: 0x55FA10
	public AkiOSSettings.PlatformAdvancedSettings AdvancedSettings; // 0x1C
	[HideInInspector] // RVA: 0x55FA20 Offset: 0x55FA20 VA: 0x55FA20
	public AkCommonCommSettings CommsSettings; // 0x20

	// Methods

	// RVA: 0xCAF0C4 Offset: 0xCAF0C4 VA: 0xCAF0C4
	public void .ctor() { }

	// RVA: 0xCAF248 Offset: 0xCAF248 VA: 0xCAF248 Slot: 11
	protected override AkCommonUserSettings GetUserSettings() { }

	// RVA: 0xCAF250 Offset: 0xCAF250 VA: 0xCAF250 Slot: 12
	protected override AkCommonAdvancedSettings GetAdvancedSettings() { }

	// RVA: 0xCAF258 Offset: 0xCAF258 VA: 0xCAF258 Slot: 13
	protected override AkCommonCommSettings GetCommsSettings() { }
}
