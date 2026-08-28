namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553EB8 Offset: 0x553EB8 VA: 0x553EB8
public class LobbyData : BaseSingleton<LobbyData> // TypeDefIndex: 9913
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x563554 Offset: 0x563554 VA: 0x563554
	private float <SendTime>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563564 Offset: 0x563564 VA: 0x563564
	private uint <Ping>k__BackingField; // 0xC

	// Properties
	public float SendTime { get; set; }
	public uint Ping { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646E90 Offset: 0x646E90 VA: 0x646E90
	// RVA: 0xF48A04 Offset: 0xF48A04 VA: 0xF48A04
	public float get_SendTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x646EA0 Offset: 0x646EA0 VA: 0x646EA0
	// RVA: 0xF48A0C Offset: 0xF48A0C VA: 0xF48A0C
	public void set_SendTime(float value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646EB0 Offset: 0x646EB0 VA: 0x646EB0
	// RVA: 0xF48A14 Offset: 0xF48A14 VA: 0xF48A14
	public uint get_Ping() { }

	[CompilerGeneratedAttribute] // RVA: 0x646EC0 Offset: 0x646EC0 VA: 0x646EC0
	// RVA: 0xF48A1C Offset: 0xF48A1C VA: 0xF48A1C
	public void set_Ping(uint value) { }

	// RVA: 0xF48A24 Offset: 0xF48A24 VA: 0xF48A24
	public void .ctor() { }
}

} // namespace FGame
