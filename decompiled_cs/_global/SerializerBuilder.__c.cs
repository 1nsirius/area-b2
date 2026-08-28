// Namespace: 
[CompilerGeneratedAttribute] // RVA: 0x54D628 Offset: 0x54D628 VA: 0x54D628
[Serializable]
private sealed class SerializerBuilder.<>c // TypeDefIndex: 4973
{
	// Fields
	public static readonly SerializerBuilder.<>c <>9; // 0x0
	public static Func<ITypeInspector, ITypeInspector> <>9__6_0; // 0x4
	public static Func<ITypeInspector, ITypeInspector> <>9__6_2; // 0x8
	public static Func<IEnumerable<IYamlTypeConverter>, IObjectGraphVisitor<Nothing>> <>9__6_4; // 0xC
	public static Func<EmissionPhaseObjectGraphVisitorArgs, IObjectGraphVisitor<IEmitter>> <>9__6_5; // 0x10
	public static Func<EmissionPhaseObjectGraphVisitorArgs, IObjectGraphVisitor<IEmitter>> <>9__6_6; // 0x14
	public static Func<EmissionPhaseObjectGraphVisitorArgs, IObjectGraphVisitor<IEmitter>> <>9__6_7; // 0x18
	public static Action<IRegistrationLocationSelectionSyntax<IEventEmitter>> <>9__17_2; // 0x1C
	public static Func<ITypeInspector, ReadableAndWritablePropertiesTypeInspector> <>9__17_3; // 0x20
	public static Action<IRegistrationLocationSelectionSyntax<ITypeInspector>> <>9__17_4; // 0x24
	public static Action<IRegistrationLocationSelectionSyntax<IYamlTypeConverter>> <>9__20_0; // 0x28
	public static Func<IEventEmitter, JsonEventEmitter> <>9__20_1; // 0x2C
	public static Action<IRegistrationLocationSelectionSyntax<IEventEmitter>> <>9__20_2; // 0x30

	// Methods

	// RVA: 0x15E7718 Offset: 0x15E7718 VA: 0x15E7718
	private static void .cctor() { }

	// RVA: 0x15E778C Offset: 0x15E778C VA: 0x15E778C
	public void .ctor() { }

	// RVA: 0x15E7794 Offset: 0x15E7794 VA: 0x15E7794
	internal ITypeInspector <.ctor>b__6_0(ITypeInspector inner) { }

	// RVA: 0x15E7804 Offset: 0x15E7804 VA: 0x15E7804
	internal ITypeInspector <.ctor>b__6_2(ITypeInspector inner) { }

	// RVA: 0x15E7878 Offset: 0x15E7878 VA: 0x15E7878
	internal IObjectGraphVisitor<Nothing> <.ctor>b__6_4(IEnumerable<IYamlTypeConverter> typeConverters) { }

	// RVA: 0x15E78E8 Offset: 0x15E78E8 VA: 0x15E78E8
	internal IObjectGraphVisitor<IEmitter> <.ctor>b__6_5(EmissionPhaseObjectGraphVisitorArgs args) { }

	// RVA: 0x15E79A8 Offset: 0x15E79A8 VA: 0x15E79A8
	internal IObjectGraphVisitor<IEmitter> <.ctor>b__6_6(EmissionPhaseObjectGraphVisitorArgs args) { }

	// RVA: 0x15E7A80 Offset: 0x15E7A80 VA: 0x15E7A80
	internal IObjectGraphVisitor<IEmitter> <.ctor>b__6_7(EmissionPhaseObjectGraphVisitorArgs args) { }

	// RVA: 0x15E7B08 Offset: 0x15E7B08 VA: 0x15E7B08
	internal void <EnsureRoundtrip>b__17_2(IRegistrationLocationSelectionSyntax<IEventEmitter> loc) { }

	// RVA: 0x15E7BF0 Offset: 0x15E7BF0 VA: 0x15E7BF0
	internal ReadableAndWritablePropertiesTypeInspector <EnsureRoundtrip>b__17_3(ITypeInspector inner) { }

	// RVA: 0x15E7C64 Offset: 0x15E7C64 VA: 0x15E7C64
	internal void <EnsureRoundtrip>b__17_4(IRegistrationLocationSelectionSyntax<ITypeInspector> loc) { }

	// RVA: 0x15E7D38 Offset: 0x15E7D38 VA: 0x15E7D38
	internal void <JsonCompatible>b__20_0(IRegistrationLocationSelectionSyntax<IYamlTypeConverter> w) { }

	// RVA: 0x15E7E20 Offset: 0x15E7E20 VA: 0x15E7E20
	internal JsonEventEmitter <JsonCompatible>b__20_1(IEventEmitter inner) { }

	// RVA: 0x15E7E90 Offset: 0x15E7E90 VA: 0x15E7E90
	internal void <JsonCompatible>b__20_2(IRegistrationLocationSelectionSyntax<IEventEmitter> loc) { }
}
