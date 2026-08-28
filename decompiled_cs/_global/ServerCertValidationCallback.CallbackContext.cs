// Namespace: 
private class ServerCertValidationCallback.CallbackContext // TypeDefIndex: 1968
{
	// Fields
	internal readonly object request; // 0x8
	internal readonly X509Certificate certificate; // 0xC
	internal readonly X509Chain chain; // 0x10
	internal readonly SslPolicyErrors sslPolicyErrors; // 0x14
	internal bool result; // 0x18

	// Methods

	// RVA: 0x14E5354 Offset: 0x14E5354 VA: 0x14E5354
	internal void .ctor(object request, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { }
}
