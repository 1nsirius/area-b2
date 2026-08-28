// Namespace: 
public class AndroidPermissionTask // TypeDefIndex: 5214
{
	// Fields
	private AndroidPermissionWindow mWindow; // 0x8
	private bool mWaitUserSetting; // 0xC
	private bool mFinished; // 0xD
	private string PERMISSION_WRITE_EXTERNAL_STORAGE; // 0x10

	// Properties
	public bool Finished { get; }

	// Methods

	// RVA: 0xCBCEAC Offset: 0xCBCEAC VA: 0xCBCEAC
	public bool get_Finished() { }

	// RVA: 0xCBCEB4 Offset: 0xCBCEB4 VA: 0xCBCEB4
	public void Initialize(AndroidPermissionWindow window) { }

	// RVA: 0xCBD6DC Offset: 0xCBD6DC VA: 0xCBD6DC
	public void ShutDown() { }

	// RVA: 0xCBD748 Offset: 0xCBD748 VA: 0xCBD748
	public void OnApplicationFocus(bool focus) { }

	// RVA: 0xCBD840 Offset: 0xCBD840 VA: 0xCBD840
	private void HandlePermissions(AndroidRuntimePermissions.Permission result) { }

	// RVA: 0xCBD944 Offset: 0xCBD944 VA: 0xCBD944
	private void OnCloseMessageWindow() { }

	// RVA: 0xCBDB64 Offset: 0xCBDB64 VA: 0xCBDB64
	private void OnRetryRequestWindow() { }

	// RVA: 0xCBDC10 Offset: 0xCBDC10 VA: 0xCBDC10
	private void OnWaitUserSetting() { }

	// RVA: 0xCBDDC4 Offset: 0xCBDDC4 VA: 0xCBDDC4
	public void .ctor() { }
}
