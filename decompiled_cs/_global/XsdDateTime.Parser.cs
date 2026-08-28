// Namespace: 
private struct XsdDateTime.Parser // TypeDefIndex: 2850
{
	// Fields
	public XsdDateTime.DateTimeTypeCode typeCode; // 0x0
	public int year; // 0x4
	public int month; // 0x8
	public int day; // 0xC
	public int hour; // 0x10
	public int minute; // 0x14
	public int second; // 0x18
	public int fraction; // 0x1C
	public XsdDateTime.XsdDateTimeKind kind; // 0x20
	public int zoneHour; // 0x24
	public int zoneMinute; // 0x28
	private string text; // 0x2C
	private int length; // 0x30
	private static int[] Power10; // 0x0

	// Methods

	// RVA: 0x76C8C4 Offset: 0x76C8C4 VA: 0x76C8C4
	public bool Parse(string text, XsdDateTimeFlags kinds) { }

	// RVA: 0x76C8CC Offset: 0x76C8CC VA: 0x76C8CC
	private bool ParseDate(int start) { }

	// RVA: 0x76C8D4 Offset: 0x76C8D4 VA: 0x76C8D4
	private bool ParseTimeAndZoneAndWhitespace(int start) { }

	// RVA: 0x76C8DC Offset: 0x76C8DC VA: 0x76C8DC
	private bool ParseTimeAndWhitespace(int start) { }

	// RVA: 0x76C8E4 Offset: 0x76C8E4 VA: 0x76C8E4
	private bool ParseTime(ref int start) { }

	// RVA: 0x76C8EC Offset: 0x76C8EC VA: 0x76C8EC
	private bool ParseZoneAndWhitespace(int start) { }

	// RVA: 0x76C8F4 Offset: 0x76C8F4 VA: 0x76C8F4
	private bool Parse4Dig(int start, ref int num) { }

	// RVA: 0x76C8FC Offset: 0x76C8FC VA: 0x76C8FC
	private bool Parse2Dig(int start, ref int num) { }

	// RVA: 0x76C904 Offset: 0x76C904 VA: 0x76C904
	private bool ParseChar(int start, char ch) { }

	// RVA: 0x18AA370 Offset: 0x18AA370 VA: 0x18AA370
	private static bool Test(XsdDateTimeFlags left, XsdDateTimeFlags right) { }

	// RVA: 0x18AB014 Offset: 0x18AB014 VA: 0x18AB014
	private static void .cctor() { }
}
