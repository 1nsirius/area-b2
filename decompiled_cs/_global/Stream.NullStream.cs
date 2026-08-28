// Namespace: 
[Serializable]
private sealed class Stream.NullStream : Stream // TypeDefIndex: 625
{
	// Fields
	private static Task<int> s_nullReadTask; // 0x0

	// Properties
	public override bool CanRead { get; }
	public override bool CanWrite { get; }
	public override bool CanSeek { get; }
	public override long Length { get; }
	public override long Position { get; set; }

	// Methods

	// RVA: 0x165B500 Offset: 0x165B500 VA: 0x165B500
	internal void .ctor() { }

	// RVA: 0x165BB7C Offset: 0x165BB7C VA: 0x165BB7C Slot: 7
	public override bool get_CanRead() { }

	// RVA: 0x165BB84 Offset: 0x165BB84 VA: 0x165BB84 Slot: 9
	public override bool get_CanWrite() { }

	// RVA: 0x165BB8C Offset: 0x165BB8C VA: 0x165BB8C Slot: 8
	public override bool get_CanSeek() { }

	// RVA: 0x165BB94 Offset: 0x165BB94 VA: 0x165BB94 Slot: 10
	public override long get_Length() { }

	// RVA: 0x165BBA0 Offset: 0x165BBA0 VA: 0x165BBA0 Slot: 11
	public override long get_Position() { }

	// RVA: 0x165BBAC Offset: 0x165BBAC VA: 0x165BBAC Slot: 12
	public override void set_Position(long value) { }

	// RVA: 0x165BBB0 Offset: 0x165BBB0 VA: 0x165BBB0 Slot: 16
	protected override void Dispose(bool disposing) { }

	// RVA: 0x165BBB4 Offset: 0x165BBB4 VA: 0x165BBB4 Slot: 17
	public override void Flush() { }

	// RVA: 0x165BBB8 Offset: 0x165BBB8 VA: 0x165BBB8 Slot: 18
	public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	// RVA: 0x165BC24 Offset: 0x165BC24 VA: 0x165BC24 Slot: 19
	public override int EndRead(IAsyncResult asyncResult) { }

	// RVA: 0x165BD04 Offset: 0x165BD04 VA: 0x165BD04 Slot: 21
	public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state) { }

	// RVA: 0x165BD70 Offset: 0x165BD70 VA: 0x165BD70 Slot: 22
	public override void EndWrite(IAsyncResult asyncResult) { }

	// RVA: 0x165BE50 Offset: 0x165BE50 VA: 0x165BE50 Slot: 26
	public override int Read([In] [Out] byte[] buffer, int offset, int count) { }

	[ComVisibleAttribute] // RVA: 0x4E3350 Offset: 0x4E3350 VA: 0x4E3350
	// RVA: 0x165BE58 Offset: 0x165BE58 VA: 0x165BE58 Slot: 20
	public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) { }

	// RVA: 0x165BF60 Offset: 0x165BF60 VA: 0x165BF60 Slot: 27
	public override int ReadByte() { }

	// RVA: 0x165BF68 Offset: 0x165BF68 VA: 0x165BF68 Slot: 28
	public override void Write(byte[] buffer, int offset, int count) { }

	[ComVisibleAttribute] // RVA: 0x4E3364 Offset: 0x4E3364 VA: 0x4E3364
	// RVA: 0x165BF6C Offset: 0x165BF6C VA: 0x165BF6C Slot: 23
	public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) { }

	// RVA: 0x165C04C Offset: 0x165C04C VA: 0x165C04C Slot: 29
	public override void WriteByte(byte value) { }

	// RVA: 0x165C050 Offset: 0x165C050 VA: 0x165C050 Slot: 24
	public override long Seek(long offset, SeekOrigin origin) { }

	// RVA: 0x165C05C Offset: 0x165C05C VA: 0x165C05C Slot: 25
	public override void SetLength(long length) { }
}
