// Namespace: 
[ExtensionAttribute] // RVA: 0x550548 Offset: 0x550548 VA: 0x550548
public static class AliUnityLinq // TypeDefIndex: 5514
{
	// Methods

	// RVA: 0xCAF788 Offset: 0xCAF788 VA: 0xCAF788
	public static GameObject FindGameObjectByName(string objName) { }

	[ExtensionAttribute] // RVA: 0x579EBC Offset: 0x579EBC VA: 0x579EBC
	// RVA: 0xCBB814 Offset: 0xCBB814 VA: 0xCBB814
	public static GameObject FindGameObjectByName(Scene scene, string objName) { }

	[ExtensionAttribute] // RVA: 0x579ECC Offset: 0x579ECC VA: 0x579ECC
	// RVA: -1 Offset: -1
	public static T FindChild<T>(Transform parent, string name) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD5A28 Offset: 0xCD5A28 VA: 0xCD5A28
	|-AliUnityLinq.FindChild<object>
	|-AliUnityLinq.FindChild<Text>
	*/

	[ExtensionAttribute] // RVA: 0x579EDC Offset: 0x579EDC VA: 0x579EDC
	// RVA: 0xCBB954 Offset: 0xCBB954 VA: 0xCBB954
	public static Transform FindChildByName(Transform parent, string childName, bool containSelf = True) { }

	[ExtensionAttribute] // RVA: 0x579EEC Offset: 0x579EEC VA: 0x579EEC
	// RVA: 0xCBBAF8 Offset: 0xCBBAF8 VA: 0xCBBAF8
	public static void SetSortingOrder(GameObject gameObject, string sortLayer, int order) { }

	[ExtensionAttribute] // RVA: 0x579EFC Offset: 0x579EFC VA: 0x579EFC
	// RVA: 0xCBBC74 Offset: 0xCBBC74 VA: 0xCBBC74
	public static void AddOption(Dropdown self, Sprite option) { }

	[ExtensionAttribute] // RVA: 0x579F0C Offset: 0x579F0C VA: 0x579F0C
	// RVA: 0xCBBD34 Offset: 0xCBBD34 VA: 0xCBBD34
	public static void AddOption(Dropdown self, string option) { }

	[ExtensionAttribute] // RVA: 0x579F1C Offset: 0x579F1C VA: 0x579F1C
	// RVA: 0xCBBDF4 Offset: 0xCBBDF4 VA: 0xCBBDF4
	public static void AddOption(Dropdown self, Dropdown.OptionData option) { }

	[ExtensionAttribute] // RVA: 0x579F2C Offset: 0x579F2C VA: 0x579F2C
	// RVA: 0xCBBE90 Offset: 0xCBBE90 VA: 0xCBBE90
	public static Dropdown.OptionData GetOption(Dropdown self, int idx) { }

	[ExtensionAttribute] // RVA: 0x579F3C Offset: 0x579F3C VA: 0x579F3C
	// RVA: 0xCBBF2C Offset: 0xCBBF2C VA: 0xCBBF2C
	public static int GetOptionsCount(Dropdown self) { }

	[ExtensionAttribute] // RVA: 0x579F4C Offset: 0x579F4C VA: 0x579F4C
	// RVA: 0xCBBFC0 Offset: 0xCBBFC0 VA: 0xCBBFC0
	public static void RemoveOptions(Dropdown self, string option) { }
}
