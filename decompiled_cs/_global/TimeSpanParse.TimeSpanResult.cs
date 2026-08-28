// Namespace: 
private struct TimeSpanParse.TimeSpanResult // TypeDefIndex: 710
{
	// Fields
	internal TimeSpan parsedTimeSpan; // 0x0
	internal TimeSpanParse.TimeSpanThrowStyle throwStyle; // 0x8
	internal TimeSpanParse.ParseFailureKind m_failure; // 0xC
	internal string m_failureMessageID; // 0x10
	internal object m_failureMessageFormatArgument; // 0x14
	internal string m_failureArgumentName; // 0x18

	// Methods

	// RVA: 0x76DC54 Offset: 0x76DC54 VA: 0x76DC54
	internal void Init(TimeSpanParse.TimeSpanThrowStyle canThrow) { }

	// RVA: 0x76DC68 Offset: 0x76DC68 VA: 0x76DC68
	internal void SetFailure(TimeSpanParse.ParseFailureKind failure, string failureMessageID) { }

	// RVA: 0x76DC90 Offset: 0x76DC90 VA: 0x76DC90
	internal void SetFailure(TimeSpanParse.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument) { }

	// RVA: 0x76DCB4 Offset: 0x76DCB4 VA: 0x76DCB4
	internal void SetFailure(TimeSpanParse.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument, string failureArgumentName) { }

	// RVA: 0x76DCD8 Offset: 0x76DCD8 VA: 0x76DCD8
	internal Exception GetTimeSpanParseException() { }
}
