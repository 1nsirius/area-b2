// Namespace: 
public class EjoySDKWpk : MonoBehaviour // TypeDefIndex: 5594
{
	// Fields
	public static EjoySDKWpk ejoySdkWpk; // 0x0
	private const string UnresolvedException = "UnresolvedException";
	private static readonly string CRASHSDK_ANDROID_CLASS; // 0x4
	private static AndroidJavaClass crashSdkObj; // 0x8
	private static int mainThreadId; // 0xC
	private bool ignoreLogFileAndUdp; // 0xC

	// Properties
	private static AndroidJavaClass CrashSdkHelper { get; }
	public static bool IsMainThread { get; }

	// Methods

	// RVA: 0xBC4378 Offset: 0xBC4378 VA: 0xBC4378
	private static AndroidJavaClass get_CrashSdkHelper() { }

	// RVA: 0xBC44B0 Offset: 0xBC44B0 VA: 0xBC44B0
	private void Awake() { }

	// RVA: 0xBC4610 Offset: 0xBC4610 VA: 0xBC4610
	private void OnDestroy() { }

	// RVA: 0xBC47B8 Offset: 0xBC47B8 VA: 0xBC47B8
	public bool StartLog() { }

	// RVA: 0xBC47C0 Offset: 0xBC47C0 VA: 0xBC47C0
	public void StopLog() { }

	// RVA: 0xBC47C4 Offset: 0xBC47C4 VA: 0xBC47C4
	public static void WriteWpkLog(LogLevel level, string msg, object[] par) { }

	// RVA: 0xBC4944 Offset: 0xBC4944 VA: 0xBC4944
	public void WriteLog(LogLevel type, string msg) { }

	// RVA: 0xBC4C94 Offset: 0xBC4C94 VA: 0xBC4C94
	public void WriteLog(LogLevel type, string format, object[] args) { }

	// RVA: 0xBC4CD4 Offset: 0xBC4CD4 VA: 0xBC4CD4
	public static bool get_IsMainThread() { }

	// RVA: 0xBC4954 Offset: 0xBC4954 VA: 0xBC4954
	private void WriteLogAll(LogLevel type, string msg) { }

	// RVA: 0xBC4E30 Offset: 0xBC4E30 VA: 0xBC4E30
	private string GetExtractStackTrace() { }

	// RVA: 0xBC4D9C Offset: 0xBC4D9C VA: 0xBC4D9C
	private string GetStrFromLogType(LogLevel type) { }

	// RVA: 0xBC4F58 Offset: 0xBC4F58 VA: 0xBC4F58
	private static void reportCSharpError(string data, string extraData) { }

	// RVA: 0xBC50D8 Offset: 0xBC50D8 VA: 0xBC50D8
	private static void reportLuaError(string data, string extraData) { }

	// RVA: 0xBC5258 Offset: 0xBC5258 VA: 0xBC5258
	private void RegisterLogFunction(string condition, string msg, LogType type) { }

	// RVA: 0xBC5330 Offset: 0xBC5330 VA: 0xBC5330
	public void .ctor() { }

	// RVA: 0xBC5338 Offset: 0xBC5338 VA: 0xBC5338
	private static void .cctor() { }
}
