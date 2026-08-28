namespace FGame
{

// Namespace: FGame
[LuaCallCSharpAttribute] // RVA: 0x553DDC Offset: 0x553DDC VA: 0x553DDC
public class BattlePingData : BaseSingleton<BattlePingData> // TypeDefIndex: 9882
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x563444 Offset: 0x563444 VA: 0x563444
	private DateTime <SendTime>k__BackingField; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563454 Offset: 0x563454 VA: 0x563454
	private DateTime <SendEndTime>k__BackingField; // 0x10
	private uint mPing; // 0x18
	public static bool WritePing; // 0x0

	// Properties
	public DateTime SendTime { get; set; }
	public DateTime SendEndTime { get; set; }
	public uint Ping { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x646C80 Offset: 0x646C80 VA: 0x646C80
	// RVA: 0xBE856C Offset: 0xBE856C VA: 0xBE856C
	public DateTime get_SendTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x646C90 Offset: 0x646C90 VA: 0x646C90
	// RVA: 0xBE8578 Offset: 0xBE8578 VA: 0xBE8578
	public void set_SendTime(DateTime value) { }

	[CompilerGeneratedAttribute] // RVA: 0x646CA0 Offset: 0x646CA0 VA: 0x646CA0
	// RVA: 0xBE8588 Offset: 0xBE8588 VA: 0xBE8588
	public DateTime get_SendEndTime() { }

	[CompilerGeneratedAttribute] // RVA: 0x646CB0 Offset: 0x646CB0 VA: 0x646CB0
	// RVA: 0xBE8594 Offset: 0xBE8594 VA: 0xBE8594
	public void set_SendEndTime(DateTime value) { }

	// RVA: 0xBE85A4 Offset: 0xBE85A4 VA: 0xBE85A4
	public uint get_Ping() { }

	// RVA: 0xBE85AC Offset: 0xBE85AC VA: 0xBE85AC
	public void set_Ping(uint value) { }

	// RVA: 0xBE86CC Offset: 0xBE86CC VA: 0xBE86CC
	public void .ctor() { }

	// RVA: 0xBE8764 Offset: 0xBE8764 VA: 0xBE8764
	private static void .cctor() { }
}

} // namespace FGame
