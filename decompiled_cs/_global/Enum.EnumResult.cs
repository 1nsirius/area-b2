// Namespace: 
private struct Enum.EnumResult // TypeDefIndex: 202
{
	// Fields
	internal object parsedEnum; // 0x0
	internal bool canThrow; // 0x4
	internal Enum.ParseFailureKind m_failure; // 0x8
	internal string m_failureMessageID; // 0xC
	internal string m_failureParameter; // 0x10
	internal object m_failureMessageFormatArgument; // 0x14
	internal Exception m_innerException; // 0x18

	// Methods

	// RVA: 0x768D30 Offset: 0x768D30 VA: 0x768D30
	internal void Init(bool canMethodThrow) { }

	// RVA: 0x768D38 Offset: 0x768D38 VA: 0x768D38
	internal void SetFailure(Exception unhandledException) { }

	// RVA: 0x768D48 Offset: 0x768D48 VA: 0x768D48
	internal void SetFailure(Enum.ParseFailureKind failure, string failureParameter) { }

	// RVA: 0x768D50 Offset: 0x768D50 VA: 0x768D50
	internal void SetFailure(Enum.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument) { }

	// RVA: 0x768D6C Offset: 0x768D6C VA: 0x768D6C
	internal Exception GetEnumParseException() { }
}
