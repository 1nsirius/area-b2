// Namespace: 
[Serializable]
internal sealed class TextReader.SyncTextReader : TextReader // TypeDefIndex: 636
{
	// Fields
	internal TextReader _in; // 0xC

	// Methods

	// RVA: 0x1661898 Offset: 0x1661898 VA: 0x1661898
	internal void .ctor(TextReader t) { }

	// RVA: 0x1661F38 Offset: 0x1661F38 VA: 0x1661F38 Slot: 7
	public override void Close() { }

	// RVA: 0x1661F6C Offset: 0x1661F6C VA: 0x1661F6C Slot: 8
	protected override void Dispose(bool disposing) { }

	// RVA: 0x1662050 Offset: 0x1662050 VA: 0x1662050 Slot: 9
	public override int Peek() { }

	// RVA: 0x1662084 Offset: 0x1662084 VA: 0x1662084 Slot: 10
	public override int Read() { }

	// RVA: 0x16620B8 Offset: 0x16620B8 VA: 0x16620B8 Slot: 11
	public override int Read([In] [Out] char[] buffer, int index, int count) { }

	// RVA: 0x1662110 Offset: 0x1662110 VA: 0x1662110 Slot: 13
	public override string ReadLine() { }

	// RVA: 0x1662144 Offset: 0x1662144 VA: 0x1662144 Slot: 12
	public override string ReadToEnd() { }
}
