// Namespace: 
internal class GooglePlayObbDownloader : IGooglePlayObbDownloader // TypeDefIndex: 5832
{
	// Fields
	private static AndroidJavaClass EnvironmentClass; // 0x0
	private const string Environment_MediaMounted = "mounted";
	[CompilerGeneratedAttribute] // RVA: 0x55EDA0 Offset: 0x55EDA0 VA: 0x55EDA0
	private string <PublicKey>k__BackingField; // 0x8
	private string m_ExpansionFilePath; // 0xC
	private static string m_ObbPackage; // 0x4
	private static int m_ObbVersion; // 0x8

	// Properties
	public string PublicKey { get; set; }
	private static string ObbPackage { get; }
	private static int ObbVersion { get; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x57AFD4 Offset: 0x57AFD4 VA: 0x57AFD4
	// RVA: 0x2CCA6A8 Offset: 0x2CCA6A8 VA: 0x2CCA6A8 Slot: 4
	public string get_PublicKey() { }

	[CompilerGeneratedAttribute] // RVA: 0x57AFE4 Offset: 0x57AFE4 VA: 0x57AFE4
	// RVA: 0x2CCA6B0 Offset: 0x2CCA6B0 VA: 0x2CCA6B0 Slot: 5
	public void set_PublicKey(string value) { }

	// RVA: 0x2CCA6B8 Offset: 0x2CCA6B8 VA: 0x2CCA6B8
	private void ApplyPublicKey() { }

	// RVA: 0x2CCA930 Offset: 0x2CCA930 VA: 0x2CCA930 Slot: 9
	public void FetchOBB() { }

	// RVA: 0x2CCB0FC Offset: 0x2CCB0FC VA: 0x2CCB0FC Slot: 10
	public void RestartActivity() { }

	// RVA: 0x2CCB8BC Offset: 0x2CCB8BC VA: 0x2CCB8BC Slot: 6
	public string GetExpansionFilePath() { }

	// RVA: 0x2CCBD24 Offset: 0x2CCBD24 VA: 0x2CCBD24 Slot: 7
	public string GetMainOBBPath() { }

	// RVA: 0x2CCC030 Offset: 0x2CCC030 VA: 0x2CCC030 Slot: 8
	public string GetPatchOBBPath() { }

	// RVA: 0x2CCBDC0 Offset: 0x2CCBDC0 VA: 0x2CCBDC0
	private static string GetOBBPackagePath(string expansionFilePath, string prefix) { }

	// RVA: 0x2CCBC2C Offset: 0x2CCBC2C VA: 0x2CCBC2C
	private static string get_ObbPackage() { }

	// RVA: 0x2CCC0CC Offset: 0x2CCC0CC VA: 0x2CCC0CC
	private static int get_ObbVersion() { }

	// RVA: 0x2CCC1C4 Offset: 0x2CCC1C4 VA: 0x2CCC1C4
	private static void PopulateOBBProperties() { }

	// RVA: 0x2CCA604 Offset: 0x2CCA604 VA: 0x2CCA604
	public void .ctor() { }

	// RVA: 0x2CCC608 Offset: 0x2CCC608 VA: 0x2CCC608
	private static void .cctor() { }
}
