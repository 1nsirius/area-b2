// Namespace: 
private sealed class XdrBuilder.XdrEntry // TypeDefIndex: 2728
{
	// Fields
	internal SchemaNames.Token _Name; // 0x8
	internal int[] _NextStates; // 0xC
	internal XdrBuilder.XdrAttributeEntry[] _Attributes; // 0x10
	internal XdrBuilder.XdrInitFunction _InitFunc; // 0x14
	internal XdrBuilder.XdrBeginChildFunction _BeginChildFunc; // 0x18
	internal XdrBuilder.XdrEndChildFunction _EndChildFunc; // 0x1C
	internal bool _AllowText; // 0x20

	// Methods

	// RVA: 0x183FF80 Offset: 0x183FF80 VA: 0x183FF80
	internal void .ctor(SchemaNames.Token n, int[] states, XdrBuilder.XdrAttributeEntry[] attributes, XdrBuilder.XdrInitFunction init, XdrBuilder.XdrBeginChildFunction begin, XdrBuilder.XdrEndChildFunction end, bool fText) { }
}
