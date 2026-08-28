// Namespace: 
internal struct Version.VersionResult // TypeDefIndex: 326
{
	// Fields
	internal Version m_parsedVersion; // 0x0
	internal Version.ParseFailureKind m_failure; // 0x4
	internal string m_exceptionArgument; // 0x8
	internal string m_argumentName; // 0xC
	internal bool m_canThrow; // 0x10

	// Methods

	// RVA: 0x80D9A0 Offset: 0x80D9A0 VA: 0x80D9A0
	internal void Init(string argumentName, bool canThrow) { }

	// RVA: 0x80D9AC Offset: 0x80D9AC VA: 0x80D9AC
	internal void SetFailure(Version.ParseFailureKind failure) { }

	// RVA: 0x80D9B4 Offset: 0x80D9B4 VA: 0x80D9B4
	internal void SetFailure(Version.ParseFailureKind failure, string argument) { }

	// RVA: 0x80D9BC Offset: 0x80D9BC VA: 0x80D9BC
	internal Exception GetVersionParseException() { }
}
