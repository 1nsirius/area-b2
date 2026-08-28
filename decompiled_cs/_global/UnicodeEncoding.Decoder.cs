// Namespace: 
[Serializable]
private class UnicodeEncoding.Decoder : DecoderNLS, ISerializable // TypeDefIndex: 455
{
	// Fields
	internal int lastByte; // 0x1C
	internal char lastChar; // 0x20

	// Properties
	internal override bool HasState { get; }

	// Methods

	// RVA: 0x128C0C0 Offset: 0x128C0C0 VA: 0x128C0C0
	public void .ctor(UnicodeEncoding encoding) { }

	// RVA: 0x128C91C Offset: 0x128C91C VA: 0x128C91C
	internal void .ctor(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x128CDE8 Offset: 0x128CDE8 VA: 0x128CDE8 Slot: 13
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x128D054 Offset: 0x128D054 VA: 0x128D054 Slot: 4
	public override void Reset() { }

	// RVA: 0x128D084 Offset: 0x128D084 VA: 0x128D084 Slot: 14
	internal override bool get_HasState() { }
}
