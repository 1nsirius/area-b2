// Namespace: 
internal class Tokenizer.StreamTokenReader : Tokenizer.ITokenReader // TypeDefIndex: 909
{
	// Fields
	internal StreamReader _in; // 0x8
	internal int _numCharRead; // 0xC

	// Properties
	internal int NumCharEncountered { get; }

	// Methods

	// RVA: 0x19EEED4 Offset: 0x19EEED4 VA: 0x19EEED4
	internal void .ctor(StreamReader input) { }

	// RVA: 0x19EF7D4 Offset: 0x19EF7D4 VA: 0x19EF7D4 Slot: 5
	public virtual int Read() { }

	// RVA: 0x19EEDB8 Offset: 0x19EEDB8 VA: 0x19EEDB8
	internal int get_NumCharEncountered() { }
}
