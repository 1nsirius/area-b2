// Namespace: 
[Serializable]
internal class UTF8Encoding.UTF8Encoder : EncoderNLS, ISerializable // TypeDefIndex: 464
{
	// Fields
	internal int surrogateChar; // 0x20

	// Properties
	internal override bool HasState { get; }

	// Methods

	// RVA: 0x128688C Offset: 0x128688C VA: 0x128688C
	public void .ctor(UTF8Encoding encoding) { }

	// RVA: 0x1287498 Offset: 0x1287498 VA: 0x1287498
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1287840 Offset: 0x1287840 VA: 0x1287840 Slot: 11
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x128799C Offset: 0x128799C VA: 0x128799C Slot: 4
	public override void Reset() { }

	// RVA: 0x12879C4 Offset: 0x12879C4 VA: 0x12879C4 Slot: 12
	internal override bool get_HasState() { }
}
