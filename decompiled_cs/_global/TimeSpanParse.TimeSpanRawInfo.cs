// Namespace: 
private struct TimeSpanParse.TimeSpanRawInfo // TypeDefIndex: 709
{
	// Fields
	internal TimeSpanParse.TTT lastSeenTTT; // 0x0
	internal int tokenCount; // 0x4
	internal int SepCount; // 0x8
	internal int NumCount; // 0xC
	internal string[] literals; // 0x10
	internal TimeSpanParse.TimeSpanToken[] numbers; // 0x14
	private TimeSpanFormat.FormatLiterals m_posLoc; // 0x18
	private TimeSpanFormat.FormatLiterals m_negLoc; // 0x34
	private bool m_posLocInit; // 0x50
	private bool m_negLocInit; // 0x51
	private string m_fullPosPattern; // 0x54
	private string m_fullNegPattern; // 0x58

	// Properties
	internal TimeSpanFormat.FormatLiterals PositiveInvariant { get; }
	internal TimeSpanFormat.FormatLiterals NegativeInvariant { get; }
	internal TimeSpanFormat.FormatLiterals PositiveLocalized { get; }
	internal TimeSpanFormat.FormatLiterals NegativeLocalized { get; }

	// Methods

	// RVA: 0x76D768 Offset: 0x76D768 VA: 0x76D768
	internal TimeSpanFormat.FormatLiterals get_PositiveInvariant() { }

	// RVA: 0x76D778 Offset: 0x76D778 VA: 0x76D778
	internal TimeSpanFormat.FormatLiterals get_NegativeInvariant() { }

	// RVA: 0x76D788 Offset: 0x76D788 VA: 0x76D788
	internal TimeSpanFormat.FormatLiterals get_PositiveLocalized() { }

	// RVA: 0x76D7EC Offset: 0x76D7EC VA: 0x76D7EC
	internal TimeSpanFormat.FormatLiterals get_NegativeLocalized() { }

	// RVA: 0x76D850 Offset: 0x76D850 VA: 0x76D850
	internal bool FullAppCompatMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D88C Offset: 0x76D88C VA: 0x76D88C
	internal bool PartialAppCompatMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D8C8 Offset: 0x76D8C8 VA: 0x76D8C8
	internal bool FullMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D904 Offset: 0x76D904 VA: 0x76D904
	internal bool FullDMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D940 Offset: 0x76D940 VA: 0x76D940
	internal bool FullHMMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D97C Offset: 0x76D97C VA: 0x76D97C
	internal bool FullDHMMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D9B8 Offset: 0x76D9B8 VA: 0x76D9B8
	internal bool FullHMSMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76D9F4 Offset: 0x76D9F4 VA: 0x76D9F4
	internal bool FullDHMSMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76DA30 Offset: 0x76DA30 VA: 0x76DA30
	internal bool FullHMSFMatch(TimeSpanFormat.FormatLiterals pattern) { }

	// RVA: 0x76DA6C Offset: 0x76DA6C VA: 0x76DA6C
	internal void Init(DateTimeFormatInfo dtfi) { }

	// RVA: 0x76DA74 Offset: 0x76DA74 VA: 0x76DA74
	internal bool ProcessToken(ref TimeSpanParse.TimeSpanToken tok, ref TimeSpanParse.TimeSpanResult result) { }

	// RVA: 0x76DA7C Offset: 0x76DA7C VA: 0x76DA7C
	private bool AddSep(string sep, ref TimeSpanParse.TimeSpanResult result) { }

	// RVA: 0x76DA84 Offset: 0x76DA84 VA: 0x76DA84
	private bool AddNum(TimeSpanParse.TimeSpanToken num, ref TimeSpanParse.TimeSpanResult result) { }
}
