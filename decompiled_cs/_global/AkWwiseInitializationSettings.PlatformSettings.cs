// Namespace: 
public abstract class AkWwiseInitializationSettings.PlatformSettings : AkCommonPlatformSettings // TypeDefIndex: 6005
{
	// Fields
	[SerializeField] // RVA: 0x56DA24 Offset: 0x56DA24 VA: 0x56DA24
	[HideInInspector] // RVA: 0x56DA24 Offset: 0x56DA24 VA: 0x56DA24
	private List<string> IgnorePropertyNameList; // 0xC
	[SerializeField] // RVA: 0x56DA54 Offset: 0x56DA54 VA: 0x56DA54
	[HideInInspector] // RVA: 0x56DA54 Offset: 0x56DA54 VA: 0x56DA54
	private List<string> GlobalPropertyNameList; // 0x10
	private HashSet<string> _GlobalPropertyHashSet; // 0x14

	// Properties
	public HashSet<string> GlobalPropertyHashSet { get; set; }

	// Methods

	// RVA: 0xCAEA28 Offset: 0xCAEA28 VA: 0xCAEA28
	public void IgnorePropertyValue(string propertyPath) { }

	// RVA: 0xCAEACC Offset: 0xCAEACC VA: 0xCAEACC
	public bool IsPropertyIgnored(string propertyPath) { }

	// RVA: 0xCABE6C Offset: 0xCABE6C VA: 0xCABE6C
	protected void .ctor() { }

	// RVA: 0xCAEB4C Offset: 0xCAEB4C VA: 0xCAEB4C
	public void SetUseGlobalPropertyValue(string propertyPath, bool use) { }

	// RVA: 0xCAEC18 Offset: 0xCAEC18 VA: 0xCAEC18
	public void SetGlobalPropertyValues(IEnumerable enumerable) { }

	// RVA: 0xCAEFA4 Offset: 0xCAEFA4 VA: 0xCAEFA4
	private bool IsUsingGlobalPropertyValue(string propertyPath) { }

	// RVA: 0xCAF024 Offset: 0xCAF024 VA: 0xCAF024
	public HashSet<string> get_GlobalPropertyHashSet() { }

	// RVA: 0xCAF0BC Offset: 0xCAF0BC VA: 0xCAF0BC
	public void set_GlobalPropertyHashSet(HashSet<string> value) { }
}
