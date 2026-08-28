// Namespace: 
internal struct TimeSpanFormat.FormatLiterals // TypeDefIndex: 701
{
	// Fields
	internal string AppCompatLiteral; // 0x0
	internal int dd; // 0x4
	internal int hh; // 0x8
	internal int mm; // 0xC
	internal int ss; // 0x10
	internal int ff; // 0x14
	private string[] literals; // 0x18

	// Properties
	internal string Start { get; }
	internal string DayHourSep { get; }
	internal string HourMinuteSep { get; }
	internal string MinuteSecondSep { get; }
	internal string SecondFractionSep { get; }
	internal string End { get; }

	// Methods

	// RVA: 0x76D6D4 Offset: 0x76D6D4 VA: 0x76D6D4
	internal string get_Start() { }

	// RVA: 0x76D6DC Offset: 0x76D6DC VA: 0x76D6DC
	internal string get_DayHourSep() { }

	// RVA: 0x76D6E4 Offset: 0x76D6E4 VA: 0x76D6E4
	internal string get_HourMinuteSep() { }

	// RVA: 0x76D6EC Offset: 0x76D6EC VA: 0x76D6EC
	internal string get_MinuteSecondSep() { }

	// RVA: 0x76D6F4 Offset: 0x76D6F4 VA: 0x76D6F4
	internal string get_SecondFractionSep() { }

	// RVA: 0x76D6FC Offset: 0x76D6FC VA: 0x76D6FC
	internal string get_End() { }

	// RVA: 0x18EEC8C Offset: 0x18EEC8C VA: 0x18EEC8C
	internal static TimeSpanFormat.FormatLiterals InitInvariant(bool isNegative) { }

	// RVA: 0x76D704 Offset: 0x76D704 VA: 0x76D704
	internal void Init(string format, bool useInvariantFieldLengths) { }
}
