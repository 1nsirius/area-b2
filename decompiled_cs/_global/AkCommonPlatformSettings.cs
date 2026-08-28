// Namespace: 
public abstract class AkCommonPlatformSettings : AkBasePlatformSettings // TypeDefIndex: 5996
{
	// Properties
	public override AkInitializationSettings AkInitializationSettings { get; }
	public override AkSpatialAudioInitSettings AkSpatialAudioInitSettings { get; }
	public override AkCallbackManager.InitializationSettings CallbackManagerInitializationSettings { get; }
	public override string InitialLanguage { get; }
	public override bool RenderDuringFocusLoss { get; }
	public override string SoundbankPath { get; }
	public override AkCommunicationSettings AkCommunicationSettings { get; }

	// Methods

	// RVA: -1 Offset: -1 Slot: 11
	protected abstract AkCommonUserSettings GetUserSettings();

	// RVA: -1 Offset: -1 Slot: 12
	protected abstract AkCommonAdvancedSettings GetAdvancedSettings();

	// RVA: -1 Offset: -1 Slot: 13
	protected abstract AkCommonCommSettings GetCommsSettings();

	// RVA: 0xFE63E8 Offset: 0xFE63E8 VA: 0xFE63E8 Slot: 4
	public override AkInitializationSettings get_AkInitializationSettings() { }

	// RVA: 0xFE67A4 Offset: 0xFE67A4 VA: 0xFE67A4 Slot: 5
	public override AkSpatialAudioInitSettings get_AkSpatialAudioInitSettings() { }

	// RVA: 0xFE6840 Offset: 0xFE6840 VA: 0xFE6840 Slot: 6
	public override AkCallbackManager.InitializationSettings get_CallbackManagerInitializationSettings() { }

	// RVA: 0xFE690C Offset: 0xFE690C VA: 0xFE690C Slot: 7
	public override string get_InitialLanguage() { }

	// RVA: 0xFE6940 Offset: 0xFE6940 VA: 0xFE6940 Slot: 8
	public override bool get_RenderDuringFocusLoss() { }

	// RVA: 0xFE6974 Offset: 0xFE6974 VA: 0xFE6974 Slot: 9
	public override string get_SoundbankPath() { }

	// RVA: 0xFE69A8 Offset: 0xFE69A8 VA: 0xFE69A8 Slot: 10
	public override AkCommunicationSettings get_AkCommunicationSettings() { }

	// RVA: 0xFE6A04 Offset: 0xFE6A04 VA: 0xFE6A04
	protected void .ctor() { }
}
