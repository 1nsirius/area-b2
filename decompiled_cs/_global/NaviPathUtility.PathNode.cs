// Namespace: 
private class NaviPathUtility.PathNode : IComparable<NaviPathUtility.PathNode> // TypeDefIndex: 12198
{
	// Fields
	public NaviPathVolume volume; // 0x8
	public NaviPathVolume.Outlet outlet; // 0xC
	public NaviPathUtility.PathNode from; // 0x10
	public float cost; // 0x14
	public bool closed; // 0x18

	// Methods

	// RVA: 0x9B4060 Offset: 0x9B4060 VA: 0x9B4060
	public void .ctor(NaviPathVolume volume) { }

	// RVA: 0x9B4080 Offset: 0x9B4080 VA: 0x9B4080 Slot: 4
	public int CompareTo(NaviPathUtility.PathNode other) { }
}
