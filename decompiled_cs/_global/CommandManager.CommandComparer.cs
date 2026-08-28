// Namespace: 
private class CommandManager.CommandComparer : IComparer<IBaseCommand>, IEqualityComparer<IBaseCommand> // TypeDefIndex: 11381
{
	// Fields
	private static readonly CommandManager.CommandComparer mInstance; // 0x0

	// Properties
	public static IComparer<IBaseCommand> CommandBeginTimeComparer { get; }

	// Methods

	// RVA: 0xA759D0 Offset: 0xA759D0 VA: 0xA759D0
	public static IComparer<IBaseCommand> get_CommandBeginTimeComparer() { }

	// RVA: 0xA7693C Offset: 0xA7693C VA: 0xA7693C Slot: 4
	public int Compare(IBaseCommand x, IBaseCommand y) { }

	// RVA: 0xA76BD8 Offset: 0xA76BD8 VA: 0xA76BD8 Slot: 5
	public bool Equals(IBaseCommand x, IBaseCommand y) { }

	// RVA: 0xA76BE8 Offset: 0xA76BE8 VA: 0xA76BE8 Slot: 6
	public int GetHashCode(IBaseCommand obj) { }

	// RVA: 0xA76C1C Offset: 0xA76C1C VA: 0xA76C1C
	public void .ctor() { }

	// RVA: 0xA76C24 Offset: 0xA76C24 VA: 0xA76C24
	private static void .cctor() { }
}
