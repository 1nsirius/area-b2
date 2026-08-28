// Namespace: 
private class AkBankManager.AsyncBankHandle : AkBankManager.BankHandle // TypeDefIndex: 5971
{
	// Fields
	private readonly AkCallbackManager.BankCallback bankCallback; // 0x14

	// Methods

	// RVA: 0xFDD354 Offset: 0xFDD354 VA: 0xFDD354
	public void .ctor(string name, AkCallbackManager.BankCallback callback) { }

	// RVA: 0xFDD548 Offset: 0xFDD548 VA: 0xFDD548
	private static void GlobalBankCallback(uint in_bankID, IntPtr in_pInMemoryBankPtr, AKRESULT in_eLoadResult, uint in_memPoolId, object in_Cookie) { }

	// RVA: 0xFDDF80 Offset: 0xFDDF80 VA: 0xFDDF80 Slot: 4
	public override AKRESULT DoLoadBank() { }
}
