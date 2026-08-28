// Namespace: 
public class EjoySDKJF : MonoBehaviour // TypeDefIndex: 5591
{
	// Fields
	public static bool OpenJF; // 0x0
	public static bool IsInit; // 0x1
	private static Dictionary<string, string> JFCode; // 0x4
	public static Dictionary<string, bool> JFSwitchSign; // 0x8
	public static EjoySDKJF ejoySDKJF; // 0xC

	// Methods

	// RVA: 0xBC1C1C Offset: 0xBC1C1C VA: 0xBC1C1C
	public static void JFUpdateEventPoint(JFCode jfCode) { }

	// RVA: 0xBC2A60 Offset: 0xBC2A60 VA: 0xBC2A60
	public static void JFUserActionPoint(JFCode jfCode) { }

	// RVA: 0xBC2CD8 Offset: 0xBC2CD8 VA: 0xBC2CD8
	public static void JFShopItemViewPoint(JFCode jfCode) { }

	// RVA: 0xBC2F50 Offset: 0xBC2F50 VA: 0xBC2F50
	public static void JFClientErrorPoint(JFCode jfCode, string msg) { }

	// RVA: 0xBC321C Offset: 0xBC321C VA: 0xBC321C
	public static void JFInitSDKData() { }

	// RVA: 0xBC2364 Offset: 0xBC2364 VA: 0xBC2364
	public static bool CheckOpen(string jf_code) { }

	// RVA: 0xBC40F0 Offset: 0xBC40F0 VA: 0xBC40F0
	private void Awake() { }

	// RVA: 0xBC38BC Offset: 0xBC38BC VA: 0xBC38BC
	private static void InitJFCode() { }

	// RVA: 0xBC41EC Offset: 0xBC41EC VA: 0xBC41EC
	private void OnDestroy() { }

	// RVA: 0xBC3320 Offset: 0xBC3320 VA: 0xBC3320
	public static void InitJFServer() { }

	// RVA: 0xBC2704 Offset: 0xBC2704 VA: 0xBC2704
	public static void CommitJFEvent(string eventName, string values) { }

	// RVA: 0xBC25DC Offset: 0xBC25DC VA: 0xBC25DC
	public static string SplitCode(string jf_code, int level = -1) { }

	// RVA: 0xBC427C Offset: 0xBC427C VA: 0xBC427C
	public void .ctor() { }

	// RVA: 0xBC4284 Offset: 0xBC4284 VA: 0xBC4284
	private static void .cctor() { }
}
