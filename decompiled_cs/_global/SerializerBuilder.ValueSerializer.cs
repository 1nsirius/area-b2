// Namespace: 
private class SerializerBuilder.ValueSerializer : IValueSerializer // TypeDefIndex: 4971
{
	// Fields
	private readonly IObjectGraphTraversalStrategy traversalStrategy; // 0x8
	private readonly IEventEmitter eventEmitter; // 0xC
	private readonly IEnumerable<IYamlTypeConverter> typeConverters; // 0x10
	private readonly LazyComponentRegistrationList<IEnumerable<IYamlTypeConverter>, IObjectGraphVisitor<Nothing>> preProcessingPhaseObjectGraphVisitorFactories; // 0x14
	private readonly LazyComponentRegistrationList<EmissionPhaseObjectGraphVisitorArgs, IObjectGraphVisitor<IEmitter>> emissionPhaseObjectGraphVisitorFactories; // 0x18

	// Methods

	// RVA: 0x15E734C Offset: 0x15E734C VA: 0x15E734C
	public void .ctor(IObjectGraphTraversalStrategy traversalStrategy, IEventEmitter eventEmitter, IEnumerable<IYamlTypeConverter> typeConverters, LazyComponentRegistrationList<IEnumerable<IYamlTypeConverter>, IObjectGraphVisitor<Nothing>> preProcessingPhaseObjectGraphVisitorFactories, LazyComponentRegistrationList<EmissionPhaseObjectGraphVisitorArgs, IObjectGraphVisitor<IEmitter>> emissionPhaseObjectGraphVisitorFactories) { }

	// RVA: 0x15E7F78 Offset: 0x15E7F78 VA: 0x15E7F78 Slot: 4
	public void SerializeValue(IEmitter emitter, object value, Type type) { }
}
