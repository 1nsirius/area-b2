// Namespace: 
public class AkWwiseInitializationSettings : AkCommonPlatformSettings // TypeDefIndex: 6004
{
	// Fields
	[HideInInspector] // RVA: 0x55F870 Offset: 0x55F870 VA: 0x55F870
	public List<string> PlatformSettingsNameList; // 0xC
	[HideInInspector] // RVA: 0x55F880 Offset: 0x55F880 VA: 0x55F880
	public List<AkWwiseInitializationSettings.PlatformSettings> PlatformSettingsList; // 0x10
	[HideInInspector] // RVA: 0x55F890 Offset: 0x55F890 VA: 0x55F890
	public List<string> InvalidReferencePlatforms; // 0x14
	[HideInInspector] // RVA: 0x55F8A0 Offset: 0x55F8A0 VA: 0x55F8A0
	public AkCommonUserSettings UserSettings; // 0x18
	[HideInInspector] // RVA: 0x55F8B0 Offset: 0x55F8B0 VA: 0x55F8B0
	public AkCommonAdvancedSettings AdvancedSettings; // 0x1C
	[HideInInspector] // RVA: 0x55F8C0 Offset: 0x55F8C0 VA: 0x55F8C0
	public AkCommonCommSettings CommsSettings; // 0x20
	private static readonly string[] AllGlobalValues; // 0x0
	private static AkWwiseInitializationSettings m_Instance; // 0x4
	private static AkBasePlatformSettings m_ActivePlatformSettings; // 0x8

	// Properties
	public bool IsValid { get; }
	public int Count { get; }
	public static AkWwiseInitializationSettings Instance { get; }
	public static AkBasePlatformSettings ActivePlatformSettings { get; }

	// Methods

	// RVA: 0xCABF78 Offset: 0xCABF78 VA: 0xCABF78
	public bool get_IsValid() { }

	// RVA: 0xCAC030 Offset: 0xCAC030 VA: 0xCAC030
	public int get_Count() { }

	// RVA: 0xCAC0A8 Offset: 0xCAC0A8 VA: 0xCAC0A8 Slot: 11
	protected override AkCommonUserSettings GetUserSettings() { }

	// RVA: 0xCAC0B0 Offset: 0xCAC0B0 VA: 0xCAC0B0 Slot: 12
	protected override AkCommonAdvancedSettings GetAdvancedSettings() { }

	// RVA: 0xCAC0B8 Offset: 0xCAC0B8 VA: 0xCAC0B8 Slot: 13
	protected override AkCommonCommSettings GetCommsSettings() { }

	// RVA: 0xCAC0C0 Offset: 0xCAC0C0 VA: 0xCAC0C0
	public static AkWwiseInitializationSettings get_Instance() { }

	// RVA: 0xCAC274 Offset: 0xCAC274 VA: 0xCAC274
	private static AkBasePlatformSettings GetPlatformSettings(string platformName) { }

	// RVA: 0xCAC488 Offset: 0xCAC488 VA: 0xCAC488
	public static AkBasePlatformSettings get_ActivePlatformSettings() { }

	// RVA: 0xCAC628 Offset: 0xCAC628 VA: 0xCAC628
	private void OnEnable() { }

	// RVA: 0xCAC804 Offset: 0xCAC804 VA: 0xCAC804
	public static bool InitializeSoundEngine() { }

	// RVA: 0xCAD030 Offset: 0xCAD030 VA: 0xCAD030
	public static bool ResetSoundEngine(bool isPlaying) { }

	// RVA: 0xCACED8 Offset: 0xCACED8 VA: 0xCACED8
	private static void LoadInitBank() { }

	// RVA: 0xCAD180 Offset: 0xCAD180 VA: 0xCAD180
	public static void TerminateSoundEngine() { }

	// RVA: 0xCAD3D0 Offset: 0xCAD3D0 VA: 0xCAD3D0
	private static void SleepForMilliseconds(double milliseconds) { }

	// RVA: 0xCAD590 Offset: 0xCAD590 VA: 0xCAD590
	public void .ctor() { }

	// RVA: 0xCAD668 Offset: 0xCAD668 VA: 0xCAD668
	private static void .cctor() { }
}
