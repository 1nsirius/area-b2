// Namespace: 
public class AkLogger // TypeDefIndex: 5998
{
	// Fields
	private static AkLogger ms_Instance; // 0x0
	private AkLogger.ErrorLoggerInteropDelegate errorLoggerDelegate; // 0x8

	// Properties
	public static AkLogger Instance { get; }

	// Methods

	// RVA: 0x1BAA574 Offset: 0x1BAA574 VA: 0x1BAA574
	private void .ctor() { }

	// RVA: 0x1BAA6D8 Offset: 0x1BAA6D8 VA: 0x1BAA6D8
	public static AkLogger get_Instance() { }

	// RVA: 0x1BAA764 Offset: 0x1BAA764 VA: 0x1BAA764 Slot: 1
	protected override void Finalize() { }

	// RVA: 0x1BAA8BC Offset: 0x1BAA8BC VA: 0x1BAA8BC
	public void Init() { }

	[MonoPInvokeCallbackAttribute] // RVA: 0x57B24C Offset: 0x57B24C VA: 0x57B24C
	// RVA: 0x1BAA4D0 Offset: 0x1BAA4D0 VA: 0x1BAA4D0
	public static void WwiseInternalLogError(string message) { }

	// RVA: 0x1BAA8C0 Offset: 0x1BAA8C0 VA: 0x1BAA8C0
	public static void Message(string message) { }

	// RVA: 0x1BAA964 Offset: 0x1BAA964 VA: 0x1BAA964
	public static void Warning(string message) { }

	// RVA: 0x1BAAA08 Offset: 0x1BAAA08 VA: 0x1BAAA08
	public static void Error(string message) { }

	// RVA: 0x1BAAAAC Offset: 0x1BAAAAC VA: 0x1BAAAAC
	private static void .cctor() { }
}
