// Namespace: 
public static class AudioBridge // TypeDefIndex: 5596
{
	// Methods

	// RVA: 0xCC190C Offset: 0xCC190C VA: 0xCC190C
	public static void RegisterGameObj(GameObject in_gameObjectID) { }

	// RVA: 0xCC19B8 Offset: 0xCC19B8 VA: 0xCC19B8
	public static uint PostEvent(string in_pszEventName, GameObject in_gameObjectID) { }

	// RVA: 0xCC1A74 Offset: 0xCC1A74 VA: 0xCC1A74
	public static uint PostEvent(uint in_eventID, GameObject in_gameObjectID) { }

	// RVA: 0xCC1B38 Offset: 0xCC1B38 VA: 0xCC1B38
	public static AKRESULT SetSwitch(uint in_switchGroup, uint in_switchState, GameObject in_gameObjectID) { }

	// RVA: 0xCC1BFC Offset: 0xCC1BFC VA: 0xCC1BFC
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value, GameObject in_gameObjectID) { }

	// RVA: 0xCC1CC0 Offset: 0xCC1CC0 VA: 0xCC1CC0
	public static AKRESULT SetRTPCValue(uint in_rtpcID, float in_value) { }

	// RVA: 0xCC1D7C Offset: 0xCC1D7C VA: 0xCC1D7C
	public static void StopAll(GameObject in_gameObjectID) { }

	// RVA: 0xCC1E28 Offset: 0xCC1E28 VA: 0xCC1E28
	public static void StopAll() { }

	// RVA: 0xCC1ECC Offset: 0xCC1ECC VA: 0xCC1ECC
	public static void StopPlayingID(uint in_playingID) { }

	// RVA: 0xCC1F78 Offset: 0xCC1F78 VA: 0xCC1F78
	public static AKRESULT LoadBank(string in_pszString, int in_memPoolId, out uint out_bankID) { }

	// RVA: 0xCC2044 Offset: 0xCC2044 VA: 0xCC2044
	public static AKRESULT LoadBank(uint in_bankID, int in_memPoolId) { }

	// RVA: 0xCC2100 Offset: 0xCC2100 VA: 0xCC2100
	public static void LoadBankAsync(string in_pszString, int in_memPoolId, Action cb) { }

	// RVA: 0xCC2224 Offset: 0xCC2224 VA: 0xCC2224
	public static AKRESULT UnloadBank(uint in_bankID, IntPtr in_pInMemoryBankPtr, AkCallbackManager.BankCallback in_pfnBankCallback, object in_pCookie) { }
}
