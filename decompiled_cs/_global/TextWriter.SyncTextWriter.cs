// Namespace: 
[Serializable]
internal sealed class TextWriter.SyncTextWriter : TextWriter, IDisposable // TypeDefIndex: 640
{
	// Fields
	private TextWriter _out; // 0x14

	// Properties
	public override Encoding Encoding { get; }
	public override IFormatProvider FormatProvider { get; }

	// Methods

	// RVA: 0x166249C Offset: 0x166249C VA: 0x166249C
	internal void .ctor(TextWriter t) { }

	// RVA: 0x1663B58 Offset: 0x1663B58 VA: 0x1663B58 Slot: 11
	public override Encoding get_Encoding() { }

	// RVA: 0x1663B8C Offset: 0x1663B8C VA: 0x1663B8C Slot: 7
	public override IFormatProvider get_FormatProvider() { }

	// RVA: 0x1663BC0 Offset: 0x1663BC0 VA: 0x1663BC0 Slot: 8
	public override void Close() { }

	// RVA: 0x1663BF4 Offset: 0x1663BF4 VA: 0x1663BF4 Slot: 9
	protected override void Dispose(bool disposing) { }

	// RVA: 0x1663CD8 Offset: 0x1663CD8 VA: 0x1663CD8 Slot: 10
	public override void Flush() { }

	// RVA: 0x1663D0C Offset: 0x1663D0C VA: 0x1663D0C Slot: 12
	public override void Write(char value) { }

	// RVA: 0x1663D48 Offset: 0x1663D48 VA: 0x1663D48 Slot: 13
	public override void Write(char[] buffer) { }

	// RVA: 0x1663D84 Offset: 0x1663D84 VA: 0x1663D84 Slot: 14
	public override void Write(char[] buffer, int index, int count) { }

	// RVA: 0x1663DDC Offset: 0x1663DDC VA: 0x1663DDC Slot: 15
	public override void Write(string value) { }

	// RVA: 0x1663E18 Offset: 0x1663E18 VA: 0x1663E18 Slot: 16
	public override void WriteLine() { }

	// RVA: 0x1663E4C Offset: 0x1663E4C VA: 0x1663E4C Slot: 17
	public override void WriteLine(char value) { }

	// RVA: 0x1663E88 Offset: 0x1663E88 VA: 0x1663E88 Slot: 18
	public override void WriteLine(char[] buffer, int index, int count) { }

	// RVA: 0x1663EE0 Offset: 0x1663EE0 VA: 0x1663EE0 Slot: 19
	public override void WriteLine(string value) { }

	// RVA: 0x1663F1C Offset: 0x1663F1C VA: 0x1663F1C Slot: 20
	public override void WriteLine(string format, object arg0) { }

	// RVA: 0x1663F60 Offset: 0x1663F60 VA: 0x1663F60 Slot: 21
	public override void WriteLine(string format, object arg0, object arg1) { }
}
