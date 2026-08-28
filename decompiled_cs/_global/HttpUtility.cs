// Namespace: 
public class HttpUtility // TypeDefIndex: 5849
{
	// Fields
	private static object callbacksLock; // 0x0
	private static Dictionary<string, List<Action<string, string>>> callbacks; // 0x4

	// Methods

	// RVA: 0x2CCF8E0 Offset: 0x2CCF8E0 VA: 0x2CCF8E0
	private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { }

	// RVA: 0x2CCF8E8 Offset: 0x2CCF8E8 VA: 0x2CCF8E8
	public static string HttpGet(string url, Action<string, string> callback) { }

	// RVA: 0x2CCFDBC Offset: 0x2CCFDBC VA: 0x2CCFDBC
	private static bool AddAsyncGetCallback(string url, Action<string, string> callback) { }

	// RVA: 0x2CD0174 Offset: 0x2CD0174 VA: 0x2CD0174
	public static void RemoveAsyncGetCallback(string url, Action<string, string> callback) { }

	// RVA: 0x2CD03E8 Offset: 0x2CD03E8 VA: 0x2CD03E8
	private static void InvokeAsyncGetCallbacks(string url, string error, string res) { }

	// RVA: 0x2CD0864 Offset: 0x2CD0864 VA: 0x2CD0864
	public static void HttpAsyncGet(string url, Action<string, string> callback, int timeout = 3000, string postContent) { }

	// RVA: 0x2CD0FE0 Offset: 0x2CD0FE0 VA: 0x2CD0FE0
	private static void _HttpAsyncGetCallback(IAsyncResult asynchronousResult) { }

	// RVA: 0x2CD140C Offset: 0x2CD140C VA: 0x2CD140C
	public static string HttpPost(string url, string content, Action<string, string> callback) { }

	// RVA: 0x2CD1BE4 Offset: 0x2CD1BE4 VA: 0x2CD1BE4
	public static UnityWebRequest UnityWebRequestPost(string url, string content, Action<string, string> callback, int timeout = 3000) { }

	// RVA: 0x2CD2138 Offset: 0x2CD2138 VA: 0x2CD2138
	public void .ctor() { }

	// RVA: 0x2CD2140 Offset: 0x2CD2140 VA: 0x2CD2140
	private static void .cctor() { }
}
