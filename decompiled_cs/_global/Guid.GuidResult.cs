// Namespace: 
private struct Guid.GuidResult // TypeDefIndex: 234
{
	// Fields
	internal Guid parsedGuid; // 0x0
	internal Guid.GuidParseThrowStyle throwStyle; // 0x10
	internal Guid.ParseFailureKind m_failure; // 0x14
	internal string m_failureMessageID; // 0x18
	internal object m_failureMessageFormatArgument; // 0x1C
	internal string m_failureArgumentName; // 0x20
	internal Exception m_innerException; // 0x24

	// Methods

	// RVA: 0x76E034 Offset: 0x76E034 VA: 0x76E034
	internal void Init(Guid.GuidParseThrowStyle canThrow) { }

	// RVA: 0x76E03C Offset: 0x76E03C VA: 0x76E03C
	internal void SetFailure(Exception nativeException) { }

	// RVA: 0x76E04C Offset: 0x76E04C VA: 0x76E04C
	internal void SetFailure(Guid.ParseFailureKind failure, string failureMessageID) { }

	// RVA: 0x76E078 Offset: 0x76E078 VA: 0x76E078
	internal void SetFailure(Guid.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument) { }

	// RVA: 0x76E0A0 Offset: 0x76E0A0 VA: 0x76E0A0
	internal void SetFailure(Guid.ParseFailureKind failure, string failureMessageID, object failureMessageFormatArgument, string failureArgumentName, Exception innerException) { }

	// RVA: 0x76E0C8 Offset: 0x76E0C8 VA: 0x76E0C8
	internal Exception GetGuidParseException() { }
}
