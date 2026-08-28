// Namespace: 
[Serializable]
private class UTF7Encoding.Encoder : EncoderNLS, ISerializable // TypeDefIndex: 460
{
	// Fields
	internal int bits; // 0x20
	internal int bitCount; // 0x24

	// Properties
	internal override bool HasState { get; }

	// Methods

	// RVA: 0x12822B0 Offset: 0x12822B0 VA: 0x12822B0
	public void .ctor(UTF7Encoding encoding) { }

	// RVA: 0x12822B8 Offset: 0x12822B8 VA: 0x12822B8
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x128251C Offset: 0x128251C VA: 0x128251C Slot: 11
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x128262C Offset: 0x128262C VA: 0x128262C Slot: 4
	public override void Reset() { }

	// RVA: 0x128265C Offset: 0x128265C VA: 0x128265C Slot: 12
	internal override bool get_HasState() { }
}
