// Namespace: 
internal class KeyboardeDelegate : IKeyDelegate // TypeDefIndex: 5228
{
	// Fields
	public KeyCode keyCode; // 0x8
	public string desc; // 0xC
	public Action del; // 0x10

	// Properties
	private KeyCode IKeyDelegate.keyCode { get; }
	private string IKeyDelegate.desc { get; }
	private Action IKeyDelegate.del { get; }

	// Methods

	// RVA: 0x2CD3A3C Offset: 0x2CD3A3C VA: 0x2CD3A3C
	public static KeyboardeDelegate Create(KeyCode key, string des, Action del) { }

	// RVA: 0x2CD3AFC Offset: 0x2CD3AFC VA: 0x2CD3AFC Slot: 4
	private KeyCode IKeyDelegate.get_keyCode() { }

	// RVA: 0x2CD3B04 Offset: 0x2CD3B04 VA: 0x2CD3B04 Slot: 5
	private string IKeyDelegate.get_desc() { }

	// RVA: 0x2CD3B0C Offset: 0x2CD3B0C VA: 0x2CD3B0C Slot: 6
	private Action IKeyDelegate.get_del() { }

	// RVA: 0x2CD3AF4 Offset: 0x2CD3AF4 VA: 0x2CD3AF4
	public void .ctor() { }
}
