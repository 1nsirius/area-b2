namespace FGame
{

// Namespace: FGame
public class ReportData : BaseSingleton<ReportData> // TypeDefIndex: 9944
{
	// Fields
	private readonly HashSet<uint> mDict; // 0x8
	[CompilerGeneratedAttribute] // RVA: 0x563794 Offset: 0x563794 VA: 0x563794
	private uint <CurrentPlayerUid>k__BackingField; // 0xC
	[CompilerGeneratedAttribute] // RVA: 0x5637A4 Offset: 0x5637A4 VA: 0x5637A4
	private bool <LockReport>k__BackingField; // 0x10

	// Properties
	public uint CurrentPlayerUid { get; set; }
	public bool LockReport { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x647300 Offset: 0x647300 VA: 0x647300
	// RVA: 0xB8203C Offset: 0xB8203C VA: 0xB8203C
	public uint get_CurrentPlayerUid() { }

	[CompilerGeneratedAttribute] // RVA: 0x647310 Offset: 0x647310 VA: 0x647310
	// RVA: 0xB82044 Offset: 0xB82044 VA: 0xB82044
	public void set_CurrentPlayerUid(uint value) { }

	[CompilerGeneratedAttribute] // RVA: 0x647320 Offset: 0x647320 VA: 0x647320
	// RVA: 0xB8204C Offset: 0xB8204C VA: 0xB8204C
	public bool get_LockReport() { }

	[CompilerGeneratedAttribute] // RVA: 0x647330 Offset: 0x647330 VA: 0x647330
	// RVA: 0xB82054 Offset: 0xB82054 VA: 0xB82054
	public void set_LockReport(bool value) { }

	// RVA: 0xB8205C Offset: 0xB8205C VA: 0xB8205C
	public bool HasReportPlayer(uint accountId) { }

	// RVA: 0xB820DC Offset: 0xB820DC VA: 0xB820DC
	public void Add(uint accountId) { }

	// RVA: 0xB821E4 Offset: 0xB821E4 VA: 0xB821E4
	public void Clear() { }

	// RVA: 0xB8225C Offset: 0xB8225C VA: 0xB8225C
	public void .ctor() { }
}

} // namespace FGame
