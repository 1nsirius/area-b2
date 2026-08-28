// Namespace: 
[Serializable]
private class UTF7Encoding.Decoder : DecoderNLS, ISerializable // TypeDefIndex: 459
{
	// Fields
	internal int bits; // 0x1C
	internal int bitCount; // 0x20
	internal bool firstByte; // 0x24

	// Properties
	internal override bool HasState { get; }

	// Methods

	// RVA: 0x1281BEC Offset: 0x1281BEC VA: 0x1281BEC
	public void .ctor(UTF7Encoding encoding) { }

	// RVA: 0x1281BF4 Offset: 0x1281BF4 VA: 0x1281BF4
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1281EAC Offset: 0x1281EAC VA: 0x1281EAC Slot: 13
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1281FDC Offset: 0x1281FDC VA: 0x1281FDC Slot: 4
	public override void Reset() { }

	// RVA: 0x1282010 Offset: 0x1282010 VA: 0x1282010 Slot: 14
	internal override bool get_HasState() { }
}
