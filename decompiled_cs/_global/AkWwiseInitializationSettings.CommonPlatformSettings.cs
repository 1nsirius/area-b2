// Namespace: 
public class AkWwiseInitializationSettings.CommonPlatformSettings : AkWwiseInitializationSettings.PlatformSettings // TypeDefIndex: 6006
{
	// Fields
	[HideInInspector] // RVA: 0x56DA84 Offset: 0x56DA84 VA: 0x56DA84
	public AkCommonUserSettings UserSettings; // 0x18
	[HideInInspector] // RVA: 0x56DA94 Offset: 0x56DA94 VA: 0x56DA94
	public AkCommonAdvancedSettings AdvancedSettings; // 0x1C
	[HideInInspector] // RVA: 0x56DAA4 Offset: 0x56DAA4 VA: 0x56DAA4
	public AkCommonCommSettings CommsSettings; // 0x20

	// Methods

	// RVA: 0xCAEA0C Offset: 0xCAEA0C VA: 0xCAEA0C Slot: 11
	protected override AkCommonUserSettings GetUserSettings() { }

	// RVA: 0xCAEA14 Offset: 0xCAEA14 VA: 0xCAEA14 Slot: 12
	protected override AkCommonAdvancedSettings GetAdvancedSettings() { }

	// RVA: 0xCAEA1C Offset: 0xCAEA1C VA: 0xCAEA1C Slot: 13
	protected override AkCommonCommSettings GetCommsSettings() { }

	// RVA: 0xCAEA24 Offset: 0xCAEA24 VA: 0xCAEA24
	public void .ctor() { }
}
