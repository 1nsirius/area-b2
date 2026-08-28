// Namespace: 
private class Vertices.PolyNode // TypeDefIndex: 11194
{
	// Fields
	private const int MaxConnected = 32;
	public Vertices.PolyNode[] Connected; // 0x8
	public int NConnected; // 0xC
	public FVector2 Position; // 0x10

	// Methods

	// RVA: 0x12D7020 Offset: 0x12D7020 VA: 0x12D7020
	public void .ctor(FVector2 pos) { }

	// RVA: 0x12D837C Offset: 0x12D837C VA: 0x12D837C
	private bool IsRighter(float sinA, float cosA, float sinB, float cosB) { }

	// RVA: 0x12D6DF4 Offset: 0x12D6DF4 VA: 0x12D6DF4
	public void AddConnection(Vertices.PolyNode toMe) { }

	// RVA: 0x12D6EF4 Offset: 0x12D6EF4 VA: 0x12D6EF4
	public void RemoveConnection(Vertices.PolyNode fromMe) { }

	// RVA: 0x12D718C Offset: 0x12D718C VA: 0x12D718C
	public Vertices.PolyNode GetRightestConnection(Vertices.PolyNode incoming) { }

	// RVA: 0x12D70AC Offset: 0x12D70AC VA: 0x12D70AC
	public Vertices.PolyNode GetRightestConnection(FVector2 incomingDir) { }
}
