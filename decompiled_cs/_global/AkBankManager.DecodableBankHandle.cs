// Namespace: 
private class AkBankManager.DecodableBankHandle : AkBankManager.BankHandle // TypeDefIndex: 5972
{
	// Fields
	private readonly bool decodeBank; // 0x14
	private readonly string decodedBankPath; // 0x18
	private readonly bool saveDecodedBank; // 0x1C

	// Methods

	// RVA: 0xFDCEC0 Offset: 0xFDCEC0 VA: 0xFDCEC0
	public void .ctor(string name, bool save) { }

	// RVA: 0xFDE2C8 Offset: 0xFDE2C8 VA: 0xFDE2C8 Slot: 4
	public override AKRESULT DoLoadBank() { }

	// RVA: 0xFDE4A4 Offset: 0xFDE4A4 VA: 0xFDE4A4 Slot: 5
	public override void UnloadBank() { }
}
