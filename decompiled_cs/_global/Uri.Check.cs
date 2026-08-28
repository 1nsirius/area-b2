// Namespace: 
[FlagsAttribute] // RVA: 0x4E5540 Offset: 0x4E5540 VA: 0x4E5540
private enum Uri.Check // TypeDefIndex: 1646
{
	// Fields
	public int value__; // 0x0
	public const Uri.Check None = 0;
	public const Uri.Check EscapedCanonical = 1;
	public const Uri.Check DisplayCanonical = 2;
	public const Uri.Check DotSlashAttn = 4;
	public const Uri.Check DotSlashEscaped = 128;
	public const Uri.Check BackslashInPath = 16;
	public const Uri.Check ReservedFound = 32;
	public const Uri.Check NotIriCanonical = 64;
	public const Uri.Check FoundNonAscii = 8;
}
