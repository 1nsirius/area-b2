// Namespace: 
internal class WebRequest.WebProxyWrapperOpaque : IAutoWebProxy, IWebProxy // TypeDefIndex: 1919
{
	// Fields
	protected readonly WebProxy webProxy; // 0x8

	// Properties
	public ICredentials Credentials { get; }

	// Methods

	// RVA: 0x1567498 Offset: 0x1567498 VA: 0x1567498 Slot: 4
	public Uri GetProxy(Uri destination) { }

	// RVA: 0x15674C8 Offset: 0x15674C8 VA: 0x15674C8 Slot: 5
	public bool IsBypassed(Uri host) { }

	// RVA: 0x15674F8 Offset: 0x15674F8 VA: 0x15674F8 Slot: 6
	public ICredentials get_Credentials() { }
}
