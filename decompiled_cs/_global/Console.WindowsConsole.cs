// Namespace: 
private class Console.WindowsConsole // TypeDefIndex: 341
{
	// Fields
	public static bool ctrlHandlerAdded; // 0x0
	private static Console.WindowsConsole.WindowsCancelHandler cancelHandler; // 0x4

	// Methods

	// RVA: 0x1B8B898 Offset: 0x1B8B898 VA: 0x1B8B898
	private static extern int GetConsoleCP() { }

	// RVA: 0x1B8B988 Offset: 0x1B8B988 VA: 0x1B8B988
	private static extern int GetConsoleOutputCP() { }

	// RVA: 0x1B8BA84 Offset: 0x1B8BA84 VA: 0x1B8BA84
	private static bool DoWindowsConsoleCancelEvent(int keyCode) { }

	// RVA: 0x1B89798 Offset: 0x1B89798 VA: 0x1B89798
	public static int GetInputCodePage() { }

	// RVA: 0x1B89810 Offset: 0x1B89810 VA: 0x1B89810
	public static int GetOutputCodePage() { }

	// RVA: 0x1B8BB14 Offset: 0x1B8BB14 VA: 0x1B8BB14
	private static void .cctor() { }
}
