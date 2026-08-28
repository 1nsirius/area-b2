// Namespace: 
[Serializable]
internal class Encoding.DefaultDecoder : Decoder, ISerializable, IObjectReference // TypeDefIndex: 446
{
	// Fields
	private Encoding m_encoding; // 0x10
	private bool m_hasInitializedEncoding; // 0x14

	// Methods

	// RVA: 0x20AE36C Offset: 0x20AE36C VA: 0x20AE36C
	public void .ctor(Encoding encoding) { }

	// RVA: 0x20AEEE0 Offset: 0x20AEEE0 VA: 0x20AEEE0
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x20AF234 Offset: 0x20AF234 VA: 0x20AF234 Slot: 14
	public object GetRealObject(StreamingContext context) { }

	// RVA: 0x20AF2A8 Offset: 0x20AF2A8 VA: 0x20AF2A8 Slot: 13
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x20AF378 Offset: 0x20AF378 VA: 0x20AF378 Slot: 5
	public override int GetCharCount(byte[] bytes, int index, int count) { }

	// RVA: 0x20AF3A4 Offset: 0x20AF3A4 VA: 0x20AF3A4 Slot: 6
	public override int GetCharCount(byte[] bytes, int index, int count, bool flush) { }

	// RVA: 0x20AF3FC Offset: 0x20AF3FC VA: 0x20AF3FC Slot: 7
	public override int GetCharCount(byte* bytes, int count, bool flush) { }

	// RVA: 0x20AF440 Offset: 0x20AF440 VA: 0x20AF440 Slot: 8
	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) { }

	// RVA: 0x20AF480 Offset: 0x20AF480 VA: 0x20AF480 Slot: 9
	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, bool flush) { }

	// RVA: 0x20AF4E8 Offset: 0x20AF4E8 VA: 0x20AF4E8 Slot: 10
	public override int GetChars(byte* bytes, int byteCount, char* chars, int charCount, bool flush) { }
}
