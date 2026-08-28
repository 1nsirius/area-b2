// Namespace: 
public class AkWindowsSettings : AkWwiseInitializationSettings.PlatformSettings // TypeDefIndex: 6041
{
	// Fields
	[HideInInspector] // RVA: 0x55FA30 Offset: 0x55FA30 VA: 0x55FA30
	public AkCommonUserSettings UserSettings; // 0x18
	[HideInInspector] // RVA: 0x55FA40 Offset: 0x55FA40 VA: 0x55FA40
	public AkWindowsSettings.PlatformAdvancedSettings AdvancedSettings; // 0x1C
	[HideInInspector] // RVA: 0x55FA50 Offset: 0x55FA50 VA: 0x55FA50
	public AkCommonCommSettings CommsSettings; // 0x20

	// Methods

	// RVA: 0xCABE50 Offset: 0xCABE50 VA: 0xCABE50 Slot: 11
	protected override AkCommonUserSettings GetUserSettings() { }

	// RVA: 0xCABE58 Offset: 0xCABE58 VA: 0xCABE58 Slot: 12
	protected override AkCommonAdvancedSettings GetAdvancedSettings() { }

	// RVA: 0xCABE60 Offset: 0xCABE60 VA: 0xCABE60 Slot: 13
	protected override AkCommonCommSettings GetCommsSettings() { }

	// RVA: 0xCABE68 Offset: 0xCABE68 VA: 0xCABE68
	public void .ctor() { }
}
