// Namespace: 
private struct HttpWebRequest.AuthorizationState // TypeDefIndex: 1990
{
	// Fields
	private readonly HttpWebRequest request; // 0x0
	private readonly bool isProxy; // 0x4
	private bool isCompleted; // 0x5
	private HttpWebRequest.NtlmAuthState ntlm_auth_state; // 0x8

	// Properties
	public bool IsCompleted { get; }
	public HttpWebRequest.NtlmAuthState NtlmAuthState { get; }
	public bool IsNtlmAuthenticated { get; }

	// Methods

	// RVA: 0x7696D0 Offset: 0x7696D0 VA: 0x7696D0
	public bool get_IsCompleted() { }

	// RVA: 0x7696D8 Offset: 0x7696D8 VA: 0x7696D8
	public HttpWebRequest.NtlmAuthState get_NtlmAuthState() { }

	// RVA: 0x7696E0 Offset: 0x7696E0 VA: 0x7696E0
	public bool get_IsNtlmAuthenticated() { }

	// RVA: 0x769700 Offset: 0x769700 VA: 0x769700
	public void .ctor(HttpWebRequest request, bool isProxy) { }

	// RVA: 0x769718 Offset: 0x769718 VA: 0x769718
	public bool CheckAuthorization(WebResponse response, HttpStatusCode code) { }

	// RVA: 0x769720 Offset: 0x769720 VA: 0x769720
	public void Reset() { }

	// RVA: 0x769728 Offset: 0x769728 VA: 0x769728 Slot: 3
	public override string ToString() { }
}
