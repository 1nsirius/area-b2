// Namespace: 
public static class AkBankManager // TypeDefIndex: 5969
{
	// Fields
	private static readonly Dictionary<string, AkBankManager.BankHandle> m_BankHandles; // 0x0
	private static readonly List<AkBankManager.BankHandle> BanksToUnload; // 0x4
	private static readonly Mutex m_Mutex; // 0x8

	// Methods

	// RVA: 0xFDCBD4 Offset: 0xFDCBD4 VA: 0xFDCBD4
	internal static void DoUnloadBanks() { }

	// RVA: 0xFDCDAC Offset: 0xFDCDAC VA: 0xFDCDAC
	internal static void Reset() { }

	// RVA: 0xFD190C Offset: 0xFD190C VA: 0xFD190C
	public static void LoadBank(string name, bool decodeBank, bool saveDecodedBank) { }

	// RVA: 0xFD1C90 Offset: 0xFD1C90 VA: 0xFD1C90
	public static void LoadBankAsync(string name, AkCallbackManager.BankCallback callback) { }

	// RVA: 0xFD1FD0 Offset: 0xFD1FD0 VA: 0xFD1FD0
	public static void UnloadBank(string name) { }

	// RVA: 0xFDD450 Offset: 0xFDD450 VA: 0xFDD450
	private static void .cctor() { }
}
