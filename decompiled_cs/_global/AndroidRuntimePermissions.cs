// Namespace: 
[ExtensionAttribute] // RVA: 0x550110 Offset: 0x550110 VA: 0x550110
public static class AndroidRuntimePermissions // TypeDefIndex: 5218
{
	// Fields
	private static AndroidJavaClass m_ajc; // 0x0
	private static AndroidJavaObject m_context; // 0x4

	// Properties
	private static AndroidJavaClass AJC { get; }
	private static AndroidJavaObject Context { get; }

	// Methods

	// RVA: 0xCBE078 Offset: 0xCBE078 VA: 0xCBE078
	private static AndroidJavaClass get_AJC() { }

	// RVA: 0xCBE1C8 Offset: 0xCBE1C8 VA: 0xCBE1C8
	private static AndroidJavaObject get_Context() { }

	// RVA: 0xCBDC94 Offset: 0xCBDC94 VA: 0xCBDC94
	public static void OpenSettings() { }

	// RVA: 0xCBD2C0 Offset: 0xCBD2C0 VA: 0xCBD2C0
	public static AndroidRuntimePermissions.Permission CheckPermission(string permission) { }

	// RVA: 0xCBE434 Offset: 0xCBE434 VA: 0xCBE434
	public static AndroidRuntimePermissions.Permission[] CheckPermissions(string[] permissions) { }

	// RVA: 0xCBDA34 Offset: 0xCBDA34 VA: 0xCBDA34
	public static AndroidRuntimePermissions.Permission RequestPermission(string permission) { }

	// RVA: 0xCBE970 Offset: 0xCBE970 VA: 0xCBE970
	public static AndroidRuntimePermissions.Permission[] RequestPermissions(string[] permissions) { }

	// RVA: 0xCBF144 Offset: 0xCBF144 VA: 0xCBF144
	private static void RequestPermissionAsync(string permission, AndroidRuntimePermissions.PermissionResult callback) { }

	// RVA: 0xCBF2D0 Offset: 0xCBF2D0 VA: 0xCBF2D0
	private static void RequestPermissionsAsync(string[] permissions, AndroidRuntimePermissions.PermissionResultMultiple callback) { }

	// RVA: 0xCBEF4C Offset: 0xCBEF4C VA: 0xCBEF4C
	public static AndroidRuntimePermissions.Permission[] ProcessPermissionRequest(string[] permissions, string resultRaw) { }

	// RVA: 0xCBE8F8 Offset: 0xCBE8F8 VA: 0xCBE8F8
	private static AndroidRuntimePermissions.Permission GetCachedPermission(string permission, AndroidRuntimePermissions.Permission defaultValue) { }

	// RVA: 0xCBEE04 Offset: 0xCBEE04 VA: 0xCBEE04
	private static string GetCachedPermissions(string[] permissions) { }

	// RVA: 0xCBF634 Offset: 0xCBF634 VA: 0xCBF634
	private static bool CachePermission(string permission, AndroidRuntimePermissions.Permission value) { }

	// RVA: 0xCBE7AC Offset: 0xCBE7AC VA: 0xCBE7AC
	private static void ValidateArgument(string[] permissions) { }

	// RVA: 0xCBF6E8 Offset: 0xCBF6E8 VA: 0xCBF6E8
	private static AndroidRuntimePermissions.Permission[] GetDummyResult(string[] permissions) { }

	[ExtensionAttribute] // RVA: 0x57978C Offset: 0x57978C VA: 0x57978C
	// RVA: 0xCBE8F0 Offset: 0xCBE8F0 VA: 0xCBE8F0
	private static AndroidRuntimePermissions.Permission ToPermission(char ch) { }

	// RVA: 0xCBF7B0 Offset: 0xCBF7B0 VA: 0xCBF7B0
	private static void .cctor() { }
}
