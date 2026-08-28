// Namespace: 
private class CFNetwork.CFWebProxy : IWebProxy // TypeDefIndex: 1602
{
	// Fields
	private ICredentials credentials; // 0x8
	private bool userSpecified; // 0xC

	// Properties
	public ICredentials Credentials { get; }

	// Methods

	// RVA: 0x18D37A0 Offset: 0x18D37A0 VA: 0x18D37A0
	public void .ctor() { }

	// RVA: 0x18D3F64 Offset: 0x18D3F64 VA: 0x18D3F64 Slot: 6
	public ICredentials get_Credentials() { }

	// RVA: 0x18D3F6C Offset: 0x18D3F6C VA: 0x18D3F6C
	private static Uri GetProxyUri(CFProxy proxy, out NetworkCredential credentials) { }

	// RVA: 0x18D46C4 Offset: 0x18D46C4 VA: 0x18D46C4
	private static Uri GetProxyUriFromScript(IntPtr script, Uri targetUri, out NetworkCredential credentials) { }

	// RVA: 0x18D482C Offset: 0x18D482C VA: 0x18D482C
	private static Uri ExecuteProxyAutoConfigurationURL(IntPtr proxyAutoConfigURL, Uri targetUri, out NetworkCredential credentials) { }

	// RVA: 0x18D475C Offset: 0x18D475C VA: 0x18D475C
	private static Uri SelectProxy(CFProxy[] proxies, Uri targetUri, out NetworkCredential credentials) { }

	// RVA: 0x18D48C4 Offset: 0x18D48C4 VA: 0x18D48C4 Slot: 4
	public Uri GetProxy(Uri targetUri) { }

	// RVA: 0x18D4EE8 Offset: 0x18D4EE8 VA: 0x18D4EE8 Slot: 5
	public bool IsBypassed(Uri targetUri) { }
}
