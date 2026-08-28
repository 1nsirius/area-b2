// Namespace: 
[Serializable]
internal class Encoding.DefaultEncoder : Encoder, ISerializable, IObjectReference // TypeDefIndex: 445
{
	// Fields
	private Encoding m_encoding; // 0x10
	private bool m_hasInitializedEncoding; // 0x14
	internal char charLeftOver; // 0x16

	// Methods

	// RVA: 0x20AE6B0 Offset: 0x20AE6B0 VA: 0x20AE6B0
	public void .ctor(Encoding encoding) { }

	// RVA: 0x20AF548 Offset: 0x20AF548 VA: 0x20AF548
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x20AF8FC Offset: 0x20AF8FC VA: 0x20AF8FC Slot: 12
	public object GetRealObject(StreamingContext context) { }

	// RVA: 0x20AF9F4 Offset: 0x20AF9F4 VA: 0x20AF9F4 Slot: 11
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x20AFAC4 Offset: 0x20AFAC4 VA: 0x20AFAC4 Slot: 5
	public override int GetByteCount(char[] chars, int index, int count, bool flush) { }

	// RVA: 0x20AFB1C Offset: 0x20AFB1C VA: 0x20AFB1C Slot: 6
	public override int GetByteCount(char* chars, int count, bool flush) { }

	// RVA: 0x20AFB60 Offset: 0x20AFB60 VA: 0x20AFB60 Slot: 7
	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush) { }

	// RVA: 0x20AFBC8 Offset: 0x20AFBC8 VA: 0x20AFBC8 Slot: 8
	public override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, bool flush) { }
}
