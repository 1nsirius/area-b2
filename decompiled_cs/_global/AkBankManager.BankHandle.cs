// Namespace: 
private class AkBankManager.BankHandle // TypeDefIndex: 5970
{
	// Fields
	protected readonly string bankName; // 0x8
	protected uint m_BankID; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x56D6E8 Offset: 0x56D6E8 VA: 0x56D6E8
	private int <RefCount>k__BackingField; // 0x10

	// Properties
	public int RefCount { get; set; }

	// Methods

	// RVA: 0xFDCEA0 Offset: 0xFDCEA0 VA: 0xFDCEA0
	public void .ctor(string name) { }

	[CompilerGeneratedAttribute] // RVA: 0x6535B0 Offset: 0x6535B0 VA: 0x6535B0
	// RVA: 0xFDD448 Offset: 0xFDD448 VA: 0xFDD448
	public int get_RefCount() { }

	[CompilerGeneratedAttribute] // RVA: 0x6535C0 Offset: 0x6535C0 VA: 0x6535C0
	// RVA: 0xFDE070 Offset: 0xFDE070 VA: 0xFDE070
	private void set_RefCount(int value) { }

	// RVA: 0xFDE078 Offset: 0xFDE078 VA: 0xFDE078 Slot: 4
	public virtual AKRESULT DoLoadBank() { }

	// RVA: 0xFDD1D4 Offset: 0xFDD1D4 VA: 0xFDD1D4
	public void LoadBank() { }

	// RVA: 0xFDE10C Offset: 0xFDE10C VA: 0xFDE10C Slot: 5
	public virtual void UnloadBank() { }

	// RVA: 0xFDD344 Offset: 0xFDD344 VA: 0xFDD344
	public void IncRef() { }

	// RVA: 0xFDD37C Offset: 0xFDD37C VA: 0xFDD37C
	public void DecRef() { }

	// RVA: 0xFDD7C0 Offset: 0xFDD7C0 VA: 0xFDD7C0
	protected void LogLoadResult(AKRESULT result) { }
}
