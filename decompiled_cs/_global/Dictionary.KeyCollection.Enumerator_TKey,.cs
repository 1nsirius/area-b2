// Namespace: 
[Serializable]
public struct Dictionary.KeyCollection.Enumerator<TKey, TValue> : IEnumerator<TKey>, IDisposable, IEnumerator // TypeDefIndex: 1419
{
	// Fields
	private Dictionary<TKey, TValue> dictionary; // 0x0
	private int index; // 0x0
	private int version; // 0x0
	private TKey currentKey; // 0x0

	// Properties
	public TKey Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Dictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x75163C Offset: 0x75163C VA: 0x75163C
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>..ctor
	|
	|-RVA: 0x7516AC Offset: 0x7516AC VA: 0x7516AC
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>..ctor
	|
	|-RVA: 0x751714 Offset: 0x751714 VA: 0x751714
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>..ctor
	|
	|-RVA: 0x75177C Offset: 0x75177C VA: 0x75177C
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>..ctor
	|
	|-RVA: 0x7517E4 Offset: 0x7517E4 VA: 0x7517E4
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>..ctor
	|
	|-RVA: 0x751854 Offset: 0x751854 VA: 0x751854
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>..ctor
	|
	|-RVA: 0x7518B4 Offset: 0x7518B4 VA: 0x7518B4
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>..ctor
	|
	|-RVA: 0x751924 Offset: 0x751924 VA: 0x751924
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>..ctor
	|
	|-RVA: 0x751994 Offset: 0x751994 VA: 0x751994
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>..ctor
	|
	|-RVA: 0x751A04 Offset: 0x751A04 VA: 0x751A04
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>..ctor
	|
	|-RVA: 0x751A74 Offset: 0x751A74 VA: 0x751A74
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>..ctor
	|
	|-RVA: 0x751AE4 Offset: 0x751AE4 VA: 0x751AE4
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>..ctor
	|
	|-RVA: 0x751B58 Offset: 0x751B58 VA: 0x751B58
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>..ctor
	|
	|-RVA: 0x74E948 Offset: 0x74E948 VA: 0x74E948
	|-Dictionary.KeyCollection.Enumerator<byte, object>..ctor
	|
	|-RVA: 0x74E9A8 Offset: 0x74E9A8 VA: 0x74E9A8
	|-Dictionary.KeyCollection.Enumerator<byte, float>..ctor
	|
	|-RVA: 0x74EA08 Offset: 0x74EA08 VA: 0x74EA08
	|-Dictionary.KeyCollection.Enumerator<byte, uint>..ctor
	|
	|-RVA: 0x74EA68 Offset: 0x74EA68 VA: 0x74EA68
	|-Dictionary.KeyCollection.Enumerator<char, object>..ctor
	|
	|-RVA: 0x74EAC8 Offset: 0x74EAC8 VA: 0x74EAC8
	|-Dictionary.KeyCollection.Enumerator<Guid, object>..ctor
	|
	|-RVA: 0x74EB38 Offset: 0x74EB38 VA: 0x74EB38
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>..ctor
	|
	|-RVA: 0x74EB98 Offset: 0x74EB98 VA: 0x74EB98
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>..ctor
	|
	|-RVA: 0x74EBF8 Offset: 0x74EBF8 VA: 0x74EBF8
	|-Dictionary.KeyCollection.Enumerator<int, bool>..ctor
	|
	|-RVA: 0x74EC58 Offset: 0x74EC58 VA: 0x74EC58
	|-Dictionary.KeyCollection.Enumerator<int, char>..ctor
	|
	|-RVA: 0x74ECB8 Offset: 0x74ECB8 VA: 0x74ECB8
	|-Dictionary.KeyCollection.Enumerator<int, int>..ctor
	|
	|-RVA: 0x74ED18 Offset: 0x74ED18 VA: 0x74ED18
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>..ctor
	|
	|-RVA: 0x74ED78 Offset: 0x74ED78 VA: 0x74ED78
	|-Dictionary.KeyCollection.Enumerator<int, long>..ctor
	|
	|-RVA: 0x74EDD8 Offset: 0x74EDD8 VA: 0x74EDD8
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>..ctor
	|
	|-RVA: 0x74EE38 Offset: 0x74EE38 VA: 0x74EE38
	|-Dictionary.KeyCollection.Enumerator<int, object>..ctor
	|
	|-RVA: 0x74EE98 Offset: 0x74EE98 VA: 0x74EE98
	|-Dictionary.KeyCollection.Enumerator<int, float>..ctor
	|
	|-RVA: 0x74EEF8 Offset: 0x74EEF8 VA: 0x74EEF8
	|-Dictionary.KeyCollection.Enumerator<int, uint>..ctor
	|
	|-RVA: 0x74EF58 Offset: 0x74EF58 VA: 0x74EF58
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>..ctor
	|
	|-RVA: 0x74EFB8 Offset: 0x74EFB8 VA: 0x74EFB8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>..ctor
	|
	|-RVA: 0x74F018 Offset: 0x74F018 VA: 0x74F018
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>..ctor
	|
	|-RVA: 0x74F078 Offset: 0x74F078 VA: 0x74F078
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>..ctor
	|
	|-RVA: 0x74F0D8 Offset: 0x74F0D8 VA: 0x74F0D8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>..ctor
	|
	|-RVA: 0x74F138 Offset: 0x74F138 VA: 0x74F138
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>..ctor
	|
	|-RVA: 0x74F198 Offset: 0x74F198 VA: 0x74F198
	|-Dictionary.KeyCollection.Enumerator<long, int>..ctor
	|
	|-RVA: 0x74F1FC Offset: 0x74F1FC VA: 0x74F1FC
	|-Dictionary.KeyCollection.Enumerator<long, object>..ctor
	|
	|-RVA: 0x74F260 Offset: 0x74F260 VA: 0x74F260
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>..ctor
	|
	|-RVA: 0x74F2C0 Offset: 0x74F2C0 VA: 0x74F2C0
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>..ctor
	|
	|-RVA: 0x74F320 Offset: 0x74F320 VA: 0x74F320
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>..ctor
	|
	|-RVA: 0x74F380 Offset: 0x74F380 VA: 0x74F380
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>..ctor
	|
	|-RVA: 0x74F3E0 Offset: 0x74F3E0 VA: 0x74F3E0
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>..ctor
	|
	|-RVA: 0x74F440 Offset: 0x74F440 VA: 0x74F440
	|-Dictionary.KeyCollection.Enumerator<object, bool>..ctor
	|
	|-RVA: 0x74F4A0 Offset: 0x74F4A0 VA: 0x74F4A0
	|-Dictionary.KeyCollection.Enumerator<object, byte>..ctor
	|
	|-RVA: 0x74F500 Offset: 0x74F500 VA: 0x74F500
	|-Dictionary.KeyCollection.Enumerator<object, short>..ctor
	|
	|-RVA: 0x74F560 Offset: 0x74F560 VA: 0x74F560
	|-Dictionary.KeyCollection.Enumerator<object, int>..ctor
	|
	|-RVA: 0x74F5C0 Offset: 0x74F5C0 VA: 0x74F5C0
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>..ctor
	|
	|-RVA: 0x74F620 Offset: 0x74F620 VA: 0x74F620
	|-Dictionary.KeyCollection.Enumerator<object, long>..ctor
	|
	|-RVA: 0x74F680 Offset: 0x74F680 VA: 0x74F680
	|-Dictionary.KeyCollection.Enumerator<object, object>..ctor
	|
	|-RVA: 0x74F6E0 Offset: 0x74F6E0 VA: 0x74F6E0
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>..ctor
	|
	|-RVA: 0x74F740 Offset: 0x74F740 VA: 0x74F740
	|-Dictionary.KeyCollection.Enumerator<object, uint>..ctor
	|
	|-RVA: 0x74F7A0 Offset: 0x74F7A0 VA: 0x74F7A0
	|-Dictionary.KeyCollection.Enumerator<object, Playable>..ctor
	|
	|-RVA: 0x74F800 Offset: 0x74F800 VA: 0x74F800
	|-Dictionary.KeyCollection.Enumerator<ushort, object>..ctor
	|
	|-RVA: 0x74F860 Offset: 0x74F860 VA: 0x74F860
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>..ctor
	|
	|-RVA: 0x74F8C0 Offset: 0x74F8C0 VA: 0x74F8C0
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>..ctor
	|
	|-RVA: 0x74F920 Offset: 0x74F920 VA: 0x74F920
	|-Dictionary.KeyCollection.Enumerator<uint, byte>..ctor
	|
	|-RVA: 0x74F980 Offset: 0x74F980 VA: 0x74F980
	|-Dictionary.KeyCollection.Enumerator<uint, int>..ctor
	|
	|-RVA: 0x74F9E0 Offset: 0x74F9E0 VA: 0x74F9E0
	|-Dictionary.KeyCollection.Enumerator<uint, object>..ctor
	|
	|-RVA: 0x74FA40 Offset: 0x74FA40 VA: 0x74FA40
	|-Dictionary.KeyCollection.Enumerator<ulong, object>..ctor
	|
	|-RVA: 0x74FAA4 Offset: 0x74FAA4 VA: 0x74FAA4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>..ctor
	|
	|-RVA: 0x74FB14 Offset: 0x74FB14 VA: 0x74FB14
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>..ctor
	|
	|-RVA: 0x74FB84 Offset: 0x74FB84 VA: 0x74FB84
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>..ctor
	|
	|-RVA: 0x74FBF4 Offset: 0x74FBF4 VA: 0x74FBF4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>..ctor
	|
	|-RVA: 0x74FC64 Offset: 0x74FC64 VA: 0x74FC64
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>..ctor
	|
	|-RVA: 0x74FCD4 Offset: 0x74FCD4 VA: 0x74FCD4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>..ctor
	|
	|-RVA: 0x74FD48 Offset: 0x74FD48 VA: 0x74FD48
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>..ctor
	|
	|-RVA: 0x74FDB8 Offset: 0x74FDB8 VA: 0x74FDB8
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>..ctor
	|
	|-RVA: 0x74FE2C Offset: 0x74FE2C VA: 0x74FE2C
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>..ctor
	|
	|-RVA: 0x74FE9C Offset: 0x74FE9C VA: 0x74FE9C
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751680 Offset: 0x751680 VA: 0x751680
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>.Dispose
	|
	|-RVA: 0x7516EC Offset: 0x7516EC VA: 0x7516EC
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.Dispose
	|
	|-RVA: 0x751754 Offset: 0x751754 VA: 0x751754
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>.Dispose
	|
	|-RVA: 0x7517BC Offset: 0x7517BC VA: 0x7517BC
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>.Dispose
	|
	|-RVA: 0x751824 Offset: 0x751824 VA: 0x751824
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>.Dispose
	|
	|-RVA: 0x751890 Offset: 0x751890 VA: 0x751890
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>.Dispose
	|
	|-RVA: 0x7518F4 Offset: 0x7518F4 VA: 0x7518F4
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>.Dispose
	|
	|-RVA: 0x751964 Offset: 0x751964 VA: 0x751964
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.Dispose
	|
	|-RVA: 0x7519D4 Offset: 0x7519D4 VA: 0x7519D4
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>.Dispose
	|
	|-RVA: 0x751A44 Offset: 0x751A44 VA: 0x751A44
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.Dispose
	|
	|-RVA: 0x751AB4 Offset: 0x751AB4 VA: 0x751AB4
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>.Dispose
	|
	|-RVA: 0x751B28 Offset: 0x751B28 VA: 0x751B28
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, Attachment>.Dispose
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>.Dispose
	|
	|-RVA: 0x751B98 Offset: 0x751B98 VA: 0x751B98
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.Dispose
	|
	|-RVA: 0x74E984 Offset: 0x74E984 VA: 0x74E984
	|-Dictionary.KeyCollection.Enumerator<byte, object>.Dispose
	|
	|-RVA: 0x74E9E4 Offset: 0x74E9E4 VA: 0x74E9E4
	|-Dictionary.KeyCollection.Enumerator<byte, float>.Dispose
	|
	|-RVA: 0x74EA44 Offset: 0x74EA44 VA: 0x74EA44
	|-Dictionary.KeyCollection.Enumerator<byte, uint>.Dispose
	|
	|-RVA: 0x74EAA4 Offset: 0x74EAA4 VA: 0x74EAA4
	|-Dictionary.KeyCollection.Enumerator<char, object>.Dispose
	|
	|-RVA: 0x74EB0C Offset: 0x74EB0C VA: 0x74EB0C
	|-Dictionary.KeyCollection.Enumerator<Guid, object>.Dispose
	|
	|-RVA: 0x74EB74 Offset: 0x74EB74 VA: 0x74EB74
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.Dispose
	|
	|-RVA: 0x74EBD4 Offset: 0x74EBD4 VA: 0x74EBD4
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>.Dispose
	|
	|-RVA: 0x74EC34 Offset: 0x74EC34 VA: 0x74EC34
	|-Dictionary.KeyCollection.Enumerator<int, bool>.Dispose
	|
	|-RVA: 0x74EC94 Offset: 0x74EC94 VA: 0x74EC94
	|-Dictionary.KeyCollection.Enumerator<int, char>.Dispose
	|
	|-RVA: 0x74ECF4 Offset: 0x74ECF4 VA: 0x74ECF4
	|-Dictionary.KeyCollection.Enumerator<int, int>.Dispose
	|
	|-RVA: 0x74ED54 Offset: 0x74ED54 VA: 0x74ED54
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>.Dispose
	|
	|-RVA: 0x74EDB4 Offset: 0x74EDB4 VA: 0x74EDB4
	|-Dictionary.KeyCollection.Enumerator<int, long>.Dispose
	|
	|-RVA: 0x74EE14 Offset: 0x74EE14 VA: 0x74EE14
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>.Dispose
	|
	|-RVA: 0x74EE74 Offset: 0x74EE74 VA: 0x74EE74
	|-Dictionary.KeyCollection.Enumerator<int, object>.Dispose
	|
	|-RVA: 0x74EED4 Offset: 0x74EED4 VA: 0x74EED4
	|-Dictionary.KeyCollection.Enumerator<int, float>.Dispose
	|
	|-RVA: 0x74EF34 Offset: 0x74EF34 VA: 0x74EF34
	|-Dictionary.KeyCollection.Enumerator<int, uint>.Dispose
	|
	|-RVA: 0x74EF94 Offset: 0x74EF94 VA: 0x74EF94
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>.Dispose
	|
	|-RVA: 0x74EFF4 Offset: 0x74EFF4 VA: 0x74EFF4
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>.Dispose
	|
	|-RVA: 0x74F054 Offset: 0x74F054 VA: 0x74F054
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>.Dispose
	|
	|-RVA: 0x74F0B4 Offset: 0x74F0B4 VA: 0x74F0B4
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>.Dispose
	|
	|-RVA: 0x74F114 Offset: 0x74F114 VA: 0x74F114
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.Dispose
	|
	|-RVA: 0x74F174 Offset: 0x74F174 VA: 0x74F174
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.Dispose
	|
	|-RVA: 0x74F1D8 Offset: 0x74F1D8 VA: 0x74F1D8
	|-Dictionary.KeyCollection.Enumerator<long, int>.Dispose
	|
	|-RVA: 0x74F23C Offset: 0x74F23C VA: 0x74F23C
	|-Dictionary.KeyCollection.Enumerator<long, object>.Dispose
	|
	|-RVA: 0x74F29C Offset: 0x74F29C VA: 0x74F29C
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>.Dispose
	|
	|-RVA: 0x74F2FC Offset: 0x74F2FC VA: 0x74F2FC
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>.Dispose
	|
	|-RVA: 0x74F35C Offset: 0x74F35C VA: 0x74F35C
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>.Dispose
	|
	|-RVA: 0x74F3BC Offset: 0x74F3BC VA: 0x74F3BC
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.Dispose
	|
	|-RVA: 0x74F41C Offset: 0x74F41C VA: 0x74F41C
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.Dispose
	|
	|-RVA: 0x74F47C Offset: 0x74F47C VA: 0x74F47C
	|-Dictionary.KeyCollection.Enumerator<object, bool>.Dispose
	|-Dictionary.KeyCollection.Enumerator<string, bool>.Dispose
	|
	|-RVA: 0x74F4DC Offset: 0x74F4DC VA: 0x74F4DC
	|-Dictionary.KeyCollection.Enumerator<object, byte>.Dispose
	|
	|-RVA: 0x74F53C Offset: 0x74F53C VA: 0x74F53C
	|-Dictionary.KeyCollection.Enumerator<object, short>.Dispose
	|
	|-RVA: 0x74F59C Offset: 0x74F59C VA: 0x74F59C
	|-Dictionary.KeyCollection.Enumerator<object, int>.Dispose
	|
	|-RVA: 0x74F5FC Offset: 0x74F5FC VA: 0x74F5FC
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>.Dispose
	|
	|-RVA: 0x74F65C Offset: 0x74F65C VA: 0x74F65C
	|-Dictionary.KeyCollection.Enumerator<object, long>.Dispose
	|
	|-RVA: 0x74F6BC Offset: 0x74F6BC VA: 0x74F6BC
	|-Dictionary.KeyCollection.Enumerator<object, object>.Dispose
	|-Dictionary.KeyCollection.Enumerator<Type, PostProcessAttribute>.Dispose
	|
	|-RVA: 0x74F71C Offset: 0x74F71C VA: 0x74F71C
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>.Dispose
	|
	|-RVA: 0x74F77C Offset: 0x74F77C VA: 0x74F77C
	|-Dictionary.KeyCollection.Enumerator<object, uint>.Dispose
	|
	|-RVA: 0x74F7DC Offset: 0x74F7DC VA: 0x74F7DC
	|-Dictionary.KeyCollection.Enumerator<object, Playable>.Dispose
	|
	|-RVA: 0x74F83C Offset: 0x74F83C VA: 0x74F83C
	|-Dictionary.KeyCollection.Enumerator<ushort, object>.Dispose
	|
	|-RVA: 0x74F89C Offset: 0x74F89C VA: 0x74F89C
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>.Dispose
	|
	|-RVA: 0x74F8FC Offset: 0x74F8FC VA: 0x74F8FC
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.Dispose
	|
	|-RVA: 0x74F95C Offset: 0x74F95C VA: 0x74F95C
	|-Dictionary.KeyCollection.Enumerator<uint, byte>.Dispose
	|
	|-RVA: 0x74F9BC Offset: 0x74F9BC VA: 0x74F9BC
	|-Dictionary.KeyCollection.Enumerator<uint, int>.Dispose
	|
	|-RVA: 0x74FA1C Offset: 0x74FA1C VA: 0x74FA1C
	|-Dictionary.KeyCollection.Enumerator<uint, object>.Dispose
	|
	|-RVA: 0x74FA80 Offset: 0x74FA80 VA: 0x74FA80
	|-Dictionary.KeyCollection.Enumerator<ulong, object>.Dispose
	|
	|-RVA: 0x74FAE8 Offset: 0x74FAE8 VA: 0x74FAE8
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.Dispose
	|
	|-RVA: 0x74FB54 Offset: 0x74FB54 VA: 0x74FB54
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>.Dispose
	|
	|-RVA: 0x74FBC4 Offset: 0x74FBC4 VA: 0x74FBC4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.Dispose
	|
	|-RVA: 0x74FC34 Offset: 0x74FC34 VA: 0x74FC34
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.Dispose
	|
	|-RVA: 0x74FCA4 Offset: 0x74FCA4 VA: 0x74FCA4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>.Dispose
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<string, Type>, Object>.Dispose
	|
	|-RVA: 0x74FD18 Offset: 0x74FD18 VA: 0x74FD18
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>.Dispose
	|
	|-RVA: 0x74FD88 Offset: 0x74FD88 VA: 0x74FD88
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.Dispose
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.Dispose
	|
	|-RVA: 0x74FDFC Offset: 0x74FDFC VA: 0x74FDFC
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>.Dispose
	|
	|-RVA: 0x74FE6C Offset: 0x74FE6C VA: 0x74FE6C
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>.Dispose
	|
	|-RVA: 0x74FEDC Offset: 0x74FEDC VA: 0x74FEDC
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751684 Offset: 0x751684 VA: 0x751684
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>.MoveNext
	|
	|-RVA: 0x7516F0 Offset: 0x7516F0 VA: 0x7516F0
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.MoveNext
	|
	|-RVA: 0x751758 Offset: 0x751758 VA: 0x751758
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>.MoveNext
	|
	|-RVA: 0x7517C0 Offset: 0x7517C0 VA: 0x7517C0
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>.MoveNext
	|
	|-RVA: 0x751828 Offset: 0x751828 VA: 0x751828
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>.MoveNext
	|
	|-RVA: 0x751894 Offset: 0x751894 VA: 0x751894
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>.MoveNext
	|
	|-RVA: 0x7518F8 Offset: 0x7518F8 VA: 0x7518F8
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>.MoveNext
	|
	|-RVA: 0x751968 Offset: 0x751968 VA: 0x751968
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.MoveNext
	|
	|-RVA: 0x7519D8 Offset: 0x7519D8 VA: 0x7519D8
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>.MoveNext
	|
	|-RVA: 0x751A48 Offset: 0x751A48 VA: 0x751A48
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.MoveNext
	|
	|-RVA: 0x751AB8 Offset: 0x751AB8 VA: 0x751AB8
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>.MoveNext
	|
	|-RVA: 0x751B2C Offset: 0x751B2C VA: 0x751B2C
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, Attachment>.MoveNext
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>.MoveNext
	|
	|-RVA: 0x751B9C Offset: 0x751B9C VA: 0x751B9C
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.MoveNext
	|
	|-RVA: 0x74E988 Offset: 0x74E988 VA: 0x74E988
	|-Dictionary.KeyCollection.Enumerator<byte, object>.MoveNext
	|
	|-RVA: 0x74E9E8 Offset: 0x74E9E8 VA: 0x74E9E8
	|-Dictionary.KeyCollection.Enumerator<byte, float>.MoveNext
	|
	|-RVA: 0x74EA48 Offset: 0x74EA48 VA: 0x74EA48
	|-Dictionary.KeyCollection.Enumerator<byte, uint>.MoveNext
	|
	|-RVA: 0x74EAA8 Offset: 0x74EAA8 VA: 0x74EAA8
	|-Dictionary.KeyCollection.Enumerator<char, object>.MoveNext
	|
	|-RVA: 0x74EB10 Offset: 0x74EB10 VA: 0x74EB10
	|-Dictionary.KeyCollection.Enumerator<Guid, object>.MoveNext
	|
	|-RVA: 0x74EB78 Offset: 0x74EB78 VA: 0x74EB78
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.MoveNext
	|
	|-RVA: 0x74EBD8 Offset: 0x74EBD8 VA: 0x74EBD8
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>.MoveNext
	|
	|-RVA: 0x74EC38 Offset: 0x74EC38 VA: 0x74EC38
	|-Dictionary.KeyCollection.Enumerator<int, bool>.MoveNext
	|
	|-RVA: 0x74EC98 Offset: 0x74EC98 VA: 0x74EC98
	|-Dictionary.KeyCollection.Enumerator<int, char>.MoveNext
	|
	|-RVA: 0x74ECF8 Offset: 0x74ECF8 VA: 0x74ECF8
	|-Dictionary.KeyCollection.Enumerator<int, int>.MoveNext
	|
	|-RVA: 0x74ED58 Offset: 0x74ED58 VA: 0x74ED58
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>.MoveNext
	|
	|-RVA: 0x74EDB8 Offset: 0x74EDB8 VA: 0x74EDB8
	|-Dictionary.KeyCollection.Enumerator<int, long>.MoveNext
	|
	|-RVA: 0x74EE18 Offset: 0x74EE18 VA: 0x74EE18
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>.MoveNext
	|
	|-RVA: 0x74EE78 Offset: 0x74EE78 VA: 0x74EE78
	|-Dictionary.KeyCollection.Enumerator<int, object>.MoveNext
	|
	|-RVA: 0x74EED8 Offset: 0x74EED8 VA: 0x74EED8
	|-Dictionary.KeyCollection.Enumerator<int, float>.MoveNext
	|
	|-RVA: 0x74EF38 Offset: 0x74EF38 VA: 0x74EF38
	|-Dictionary.KeyCollection.Enumerator<int, uint>.MoveNext
	|
	|-RVA: 0x74EF98 Offset: 0x74EF98 VA: 0x74EF98
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>.MoveNext
	|
	|-RVA: 0x74EFF8 Offset: 0x74EFF8 VA: 0x74EFF8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>.MoveNext
	|
	|-RVA: 0x74F058 Offset: 0x74F058 VA: 0x74F058
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>.MoveNext
	|
	|-RVA: 0x74F0B8 Offset: 0x74F0B8 VA: 0x74F0B8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>.MoveNext
	|
	|-RVA: 0x74F118 Offset: 0x74F118 VA: 0x74F118
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.MoveNext
	|
	|-RVA: 0x74F178 Offset: 0x74F178 VA: 0x74F178
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.MoveNext
	|
	|-RVA: 0x74F1DC Offset: 0x74F1DC VA: 0x74F1DC
	|-Dictionary.KeyCollection.Enumerator<long, int>.MoveNext
	|
	|-RVA: 0x74F240 Offset: 0x74F240 VA: 0x74F240
	|-Dictionary.KeyCollection.Enumerator<long, object>.MoveNext
	|
	|-RVA: 0x74F2A0 Offset: 0x74F2A0 VA: 0x74F2A0
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>.MoveNext
	|
	|-RVA: 0x74F300 Offset: 0x74F300 VA: 0x74F300
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>.MoveNext
	|
	|-RVA: 0x74F360 Offset: 0x74F360 VA: 0x74F360
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>.MoveNext
	|
	|-RVA: 0x74F3C0 Offset: 0x74F3C0 VA: 0x74F3C0
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.MoveNext
	|
	|-RVA: 0x74F420 Offset: 0x74F420 VA: 0x74F420
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.MoveNext
	|
	|-RVA: 0x74F480 Offset: 0x74F480 VA: 0x74F480
	|-Dictionary.KeyCollection.Enumerator<object, bool>.MoveNext
	|-Dictionary.KeyCollection.Enumerator<string, bool>.MoveNext
	|
	|-RVA: 0x74F4E0 Offset: 0x74F4E0 VA: 0x74F4E0
	|-Dictionary.KeyCollection.Enumerator<object, byte>.MoveNext
	|
	|-RVA: 0x74F540 Offset: 0x74F540 VA: 0x74F540
	|-Dictionary.KeyCollection.Enumerator<object, short>.MoveNext
	|
	|-RVA: 0x74F5A0 Offset: 0x74F5A0 VA: 0x74F5A0
	|-Dictionary.KeyCollection.Enumerator<object, int>.MoveNext
	|
	|-RVA: 0x74F600 Offset: 0x74F600 VA: 0x74F600
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>.MoveNext
	|
	|-RVA: 0x74F660 Offset: 0x74F660 VA: 0x74F660
	|-Dictionary.KeyCollection.Enumerator<object, long>.MoveNext
	|
	|-RVA: 0x74F6C0 Offset: 0x74F6C0 VA: 0x74F6C0
	|-Dictionary.KeyCollection.Enumerator<object, object>.MoveNext
	|-Dictionary.KeyCollection.Enumerator<Type, PostProcessAttribute>.MoveNext
	|
	|-RVA: 0x74F720 Offset: 0x74F720 VA: 0x74F720
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>.MoveNext
	|
	|-RVA: 0x74F780 Offset: 0x74F780 VA: 0x74F780
	|-Dictionary.KeyCollection.Enumerator<object, uint>.MoveNext
	|
	|-RVA: 0x74F7E0 Offset: 0x74F7E0 VA: 0x74F7E0
	|-Dictionary.KeyCollection.Enumerator<object, Playable>.MoveNext
	|
	|-RVA: 0x74F840 Offset: 0x74F840 VA: 0x74F840
	|-Dictionary.KeyCollection.Enumerator<ushort, object>.MoveNext
	|
	|-RVA: 0x74F8A0 Offset: 0x74F8A0 VA: 0x74F8A0
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>.MoveNext
	|
	|-RVA: 0x74F900 Offset: 0x74F900 VA: 0x74F900
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.MoveNext
	|
	|-RVA: 0x74F960 Offset: 0x74F960 VA: 0x74F960
	|-Dictionary.KeyCollection.Enumerator<uint, byte>.MoveNext
	|
	|-RVA: 0x74F9C0 Offset: 0x74F9C0 VA: 0x74F9C0
	|-Dictionary.KeyCollection.Enumerator<uint, int>.MoveNext
	|
	|-RVA: 0x74FA20 Offset: 0x74FA20 VA: 0x74FA20
	|-Dictionary.KeyCollection.Enumerator<uint, object>.MoveNext
	|
	|-RVA: 0x74FA84 Offset: 0x74FA84 VA: 0x74FA84
	|-Dictionary.KeyCollection.Enumerator<ulong, object>.MoveNext
	|
	|-RVA: 0x74FAEC Offset: 0x74FAEC VA: 0x74FAEC
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.MoveNext
	|
	|-RVA: 0x74FB58 Offset: 0x74FB58 VA: 0x74FB58
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>.MoveNext
	|
	|-RVA: 0x74FBC8 Offset: 0x74FBC8 VA: 0x74FBC8
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.MoveNext
	|
	|-RVA: 0x74FC38 Offset: 0x74FC38 VA: 0x74FC38
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.MoveNext
	|
	|-RVA: 0x74FCA8 Offset: 0x74FCA8 VA: 0x74FCA8
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>.MoveNext
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<string, Type>, Object>.MoveNext
	|
	|-RVA: 0x74FD1C Offset: 0x74FD1C VA: 0x74FD1C
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>.MoveNext
	|
	|-RVA: 0x74FD8C Offset: 0x74FD8C VA: 0x74FD8C
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.MoveNext
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.MoveNext
	|
	|-RVA: 0x74FE00 Offset: 0x74FE00 VA: 0x74FE00
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>.MoveNext
	|
	|-RVA: 0x74FE70 Offset: 0x74FE70 VA: 0x74FE70
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>.MoveNext
	|
	|-RVA: 0x74FEE0 Offset: 0x74FEE0 VA: 0x74FEE0
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public TKey get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751B34 Offset: 0x751B34 VA: 0x751B34
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, Attachment>.get_Current
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>.get_Current
	|
	|-RVA: 0x74F488 Offset: 0x74F488 VA: 0x74F488
	|-Dictionary.KeyCollection.Enumerator<string, bool>.get_Current
	|-Dictionary.KeyCollection.Enumerator<object, bool>.get_Current
	|
	|-RVA: 0x74F6C8 Offset: 0x74F6C8 VA: 0x74F6C8
	|-Dictionary.KeyCollection.Enumerator<Type, PostProcessAttribute>.get_Current
	|-Dictionary.KeyCollection.Enumerator<object, object>.get_Current
	|
	|-RVA: 0x74FCB0 Offset: 0x74FCB0 VA: 0x74FCB0
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<string, Type>, Object>.get_Current
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>.get_Current
	|
	|-RVA: 0x74FD94 Offset: 0x74FD94 VA: 0x74FD94
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.get_Current
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.get_Current
	|
	|-RVA: 0x75168C Offset: 0x75168C VA: 0x75168C
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>.get_Current
	|
	|-RVA: 0x7516F8 Offset: 0x7516F8 VA: 0x7516F8
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.get_Current
	|
	|-RVA: 0x751760 Offset: 0x751760 VA: 0x751760
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>.get_Current
	|
	|-RVA: 0x7517C8 Offset: 0x7517C8 VA: 0x7517C8
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>.get_Current
	|
	|-RVA: 0x751830 Offset: 0x751830 VA: 0x751830
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>.get_Current
	|
	|-RVA: 0x75189C Offset: 0x75189C VA: 0x75189C
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>.get_Current
	|
	|-RVA: 0x751900 Offset: 0x751900 VA: 0x751900
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>.get_Current
	|
	|-RVA: 0x751970 Offset: 0x751970 VA: 0x751970
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.get_Current
	|
	|-RVA: 0x7519E0 Offset: 0x7519E0 VA: 0x7519E0
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>.get_Current
	|
	|-RVA: 0x751A50 Offset: 0x751A50 VA: 0x751A50
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.get_Current
	|
	|-RVA: 0x751AC0 Offset: 0x751AC0 VA: 0x751AC0
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>.get_Current
	|
	|-RVA: 0x751BA4 Offset: 0x751BA4 VA: 0x751BA4
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.get_Current
	|
	|-RVA: 0x74E990 Offset: 0x74E990 VA: 0x74E990
	|-Dictionary.KeyCollection.Enumerator<byte, object>.get_Current
	|
	|-RVA: 0x74E9F0 Offset: 0x74E9F0 VA: 0x74E9F0
	|-Dictionary.KeyCollection.Enumerator<byte, float>.get_Current
	|
	|-RVA: 0x74EA50 Offset: 0x74EA50 VA: 0x74EA50
	|-Dictionary.KeyCollection.Enumerator<byte, uint>.get_Current
	|
	|-RVA: 0x74EAB0 Offset: 0x74EAB0 VA: 0x74EAB0
	|-Dictionary.KeyCollection.Enumerator<char, object>.get_Current
	|
	|-RVA: 0x74EB18 Offset: 0x74EB18 VA: 0x74EB18
	|-Dictionary.KeyCollection.Enumerator<Guid, object>.get_Current
	|
	|-RVA: 0x74EB80 Offset: 0x74EB80 VA: 0x74EB80
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.get_Current
	|
	|-RVA: 0x74EBE0 Offset: 0x74EBE0 VA: 0x74EBE0
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>.get_Current
	|
	|-RVA: 0x74EC40 Offset: 0x74EC40 VA: 0x74EC40
	|-Dictionary.KeyCollection.Enumerator<int, bool>.get_Current
	|
	|-RVA: 0x74ECA0 Offset: 0x74ECA0 VA: 0x74ECA0
	|-Dictionary.KeyCollection.Enumerator<int, char>.get_Current
	|
	|-RVA: 0x74ED00 Offset: 0x74ED00 VA: 0x74ED00
	|-Dictionary.KeyCollection.Enumerator<int, int>.get_Current
	|
	|-RVA: 0x74ED60 Offset: 0x74ED60 VA: 0x74ED60
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>.get_Current
	|
	|-RVA: 0x74EDC0 Offset: 0x74EDC0 VA: 0x74EDC0
	|-Dictionary.KeyCollection.Enumerator<int, long>.get_Current
	|
	|-RVA: 0x74EE20 Offset: 0x74EE20 VA: 0x74EE20
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>.get_Current
	|
	|-RVA: 0x74EE80 Offset: 0x74EE80 VA: 0x74EE80
	|-Dictionary.KeyCollection.Enumerator<int, object>.get_Current
	|
	|-RVA: 0x74EEE0 Offset: 0x74EEE0 VA: 0x74EEE0
	|-Dictionary.KeyCollection.Enumerator<int, float>.get_Current
	|
	|-RVA: 0x74EF40 Offset: 0x74EF40 VA: 0x74EF40
	|-Dictionary.KeyCollection.Enumerator<int, uint>.get_Current
	|
	|-RVA: 0x74EFA0 Offset: 0x74EFA0 VA: 0x74EFA0
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>.get_Current
	|
	|-RVA: 0x74F000 Offset: 0x74F000 VA: 0x74F000
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>.get_Current
	|
	|-RVA: 0x74F060 Offset: 0x74F060 VA: 0x74F060
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>.get_Current
	|
	|-RVA: 0x74F0C0 Offset: 0x74F0C0 VA: 0x74F0C0
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>.get_Current
	|
	|-RVA: 0x74F120 Offset: 0x74F120 VA: 0x74F120
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.get_Current
	|
	|-RVA: 0x74F180 Offset: 0x74F180 VA: 0x74F180
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.get_Current
	|
	|-RVA: 0x74F1E4 Offset: 0x74F1E4 VA: 0x74F1E4
	|-Dictionary.KeyCollection.Enumerator<long, int>.get_Current
	|
	|-RVA: 0x74F248 Offset: 0x74F248 VA: 0x74F248
	|-Dictionary.KeyCollection.Enumerator<long, object>.get_Current
	|
	|-RVA: 0x74F2A8 Offset: 0x74F2A8 VA: 0x74F2A8
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>.get_Current
	|
	|-RVA: 0x74F308 Offset: 0x74F308 VA: 0x74F308
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>.get_Current
	|
	|-RVA: 0x74F368 Offset: 0x74F368 VA: 0x74F368
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>.get_Current
	|
	|-RVA: 0x74F3C8 Offset: 0x74F3C8 VA: 0x74F3C8
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.get_Current
	|
	|-RVA: 0x74F428 Offset: 0x74F428 VA: 0x74F428
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.get_Current
	|
	|-RVA: 0x74F4E8 Offset: 0x74F4E8 VA: 0x74F4E8
	|-Dictionary.KeyCollection.Enumerator<object, byte>.get_Current
	|
	|-RVA: 0x74F548 Offset: 0x74F548 VA: 0x74F548
	|-Dictionary.KeyCollection.Enumerator<object, short>.get_Current
	|
	|-RVA: 0x74F5A8 Offset: 0x74F5A8 VA: 0x74F5A8
	|-Dictionary.KeyCollection.Enumerator<object, int>.get_Current
	|
	|-RVA: 0x74F608 Offset: 0x74F608 VA: 0x74F608
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>.get_Current
	|
	|-RVA: 0x74F668 Offset: 0x74F668 VA: 0x74F668
	|-Dictionary.KeyCollection.Enumerator<object, long>.get_Current
	|
	|-RVA: 0x74F728 Offset: 0x74F728 VA: 0x74F728
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>.get_Current
	|
	|-RVA: 0x74F788 Offset: 0x74F788 VA: 0x74F788
	|-Dictionary.KeyCollection.Enumerator<object, uint>.get_Current
	|
	|-RVA: 0x74F7E8 Offset: 0x74F7E8 VA: 0x74F7E8
	|-Dictionary.KeyCollection.Enumerator<object, Playable>.get_Current
	|
	|-RVA: 0x74F848 Offset: 0x74F848 VA: 0x74F848
	|-Dictionary.KeyCollection.Enumerator<ushort, object>.get_Current
	|
	|-RVA: 0x74F8A8 Offset: 0x74F8A8 VA: 0x74F8A8
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>.get_Current
	|
	|-RVA: 0x74F908 Offset: 0x74F908 VA: 0x74F908
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.get_Current
	|
	|-RVA: 0x74F968 Offset: 0x74F968 VA: 0x74F968
	|-Dictionary.KeyCollection.Enumerator<uint, byte>.get_Current
	|
	|-RVA: 0x74F9C8 Offset: 0x74F9C8 VA: 0x74F9C8
	|-Dictionary.KeyCollection.Enumerator<uint, int>.get_Current
	|
	|-RVA: 0x74FA28 Offset: 0x74FA28 VA: 0x74FA28
	|-Dictionary.KeyCollection.Enumerator<uint, object>.get_Current
	|
	|-RVA: 0x74FA8C Offset: 0x74FA8C VA: 0x74FA8C
	|-Dictionary.KeyCollection.Enumerator<ulong, object>.get_Current
	|
	|-RVA: 0x74FAF4 Offset: 0x74FAF4 VA: 0x74FAF4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.get_Current
	|
	|-RVA: 0x74FB60 Offset: 0x74FB60 VA: 0x74FB60
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>.get_Current
	|
	|-RVA: 0x74FBD0 Offset: 0x74FBD0 VA: 0x74FBD0
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.get_Current
	|
	|-RVA: 0x74FC40 Offset: 0x74FC40 VA: 0x74FC40
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.get_Current
	|
	|-RVA: 0x74FD24 Offset: 0x74FD24 VA: 0x74FD24
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>.get_Current
	|
	|-RVA: 0x74FE08 Offset: 0x74FE08 VA: 0x74FE08
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>.get_Current
	|
	|-RVA: 0x74FE78 Offset: 0x74FE78 VA: 0x74FE78
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>.get_Current
	|
	|-RVA: 0x74FEE8 Offset: 0x74FEE8 VA: 0x74FEE8
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x75169C Offset: 0x75169C VA: 0x75169C
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751704 Offset: 0x751704 VA: 0x751704
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75176C Offset: 0x75176C VA: 0x75176C
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7517D4 Offset: 0x7517D4 VA: 0x7517D4
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751844 Offset: 0x751844 VA: 0x751844
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7518A4 Offset: 0x7518A4 VA: 0x7518A4
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751914 Offset: 0x751914 VA: 0x751914
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751984 Offset: 0x751984 VA: 0x751984
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7519F4 Offset: 0x7519F4 VA: 0x7519F4
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751A64 Offset: 0x751A64 VA: 0x751A64
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751AD4 Offset: 0x751AD4 VA: 0x751AD4
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751B48 Offset: 0x751B48 VA: 0x751B48
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751BB8 Offset: 0x751BB8 VA: 0x751BB8
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74E998 Offset: 0x74E998 VA: 0x74E998
	|-Dictionary.KeyCollection.Enumerator<byte, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74E9F8 Offset: 0x74E9F8 VA: 0x74E9F8
	|-Dictionary.KeyCollection.Enumerator<byte, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EA58 Offset: 0x74EA58 VA: 0x74EA58
	|-Dictionary.KeyCollection.Enumerator<byte, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EAB8 Offset: 0x74EAB8 VA: 0x74EAB8
	|-Dictionary.KeyCollection.Enumerator<char, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EB28 Offset: 0x74EB28 VA: 0x74EB28
	|-Dictionary.KeyCollection.Enumerator<Guid, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EB88 Offset: 0x74EB88 VA: 0x74EB88
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EBE8 Offset: 0x74EBE8 VA: 0x74EBE8
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EC48 Offset: 0x74EC48 VA: 0x74EC48
	|-Dictionary.KeyCollection.Enumerator<int, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74ECA8 Offset: 0x74ECA8 VA: 0x74ECA8
	|-Dictionary.KeyCollection.Enumerator<int, char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74ED08 Offset: 0x74ED08 VA: 0x74ED08
	|-Dictionary.KeyCollection.Enumerator<int, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74ED68 Offset: 0x74ED68 VA: 0x74ED68
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EDC8 Offset: 0x74EDC8 VA: 0x74EDC8
	|-Dictionary.KeyCollection.Enumerator<int, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EE28 Offset: 0x74EE28 VA: 0x74EE28
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EE88 Offset: 0x74EE88 VA: 0x74EE88
	|-Dictionary.KeyCollection.Enumerator<int, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EEE8 Offset: 0x74EEE8 VA: 0x74EEE8
	|-Dictionary.KeyCollection.Enumerator<int, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EF48 Offset: 0x74EF48 VA: 0x74EF48
	|-Dictionary.KeyCollection.Enumerator<int, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74EFA8 Offset: 0x74EFA8 VA: 0x74EFA8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F008 Offset: 0x74F008 VA: 0x74F008
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F068 Offset: 0x74F068 VA: 0x74F068
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F0C8 Offset: 0x74F0C8 VA: 0x74F0C8
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F128 Offset: 0x74F128 VA: 0x74F128
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F188 Offset: 0x74F188 VA: 0x74F188
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F1EC Offset: 0x74F1EC VA: 0x74F1EC
	|-Dictionary.KeyCollection.Enumerator<long, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F250 Offset: 0x74F250 VA: 0x74F250
	|-Dictionary.KeyCollection.Enumerator<long, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F2B0 Offset: 0x74F2B0 VA: 0x74F2B0
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F310 Offset: 0x74F310 VA: 0x74F310
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F370 Offset: 0x74F370 VA: 0x74F370
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F3D0 Offset: 0x74F3D0 VA: 0x74F3D0
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F430 Offset: 0x74F430 VA: 0x74F430
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F490 Offset: 0x74F490 VA: 0x74F490
	|-Dictionary.KeyCollection.Enumerator<object, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F4F0 Offset: 0x74F4F0 VA: 0x74F4F0
	|-Dictionary.KeyCollection.Enumerator<object, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F550 Offset: 0x74F550 VA: 0x74F550
	|-Dictionary.KeyCollection.Enumerator<object, short>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F5B0 Offset: 0x74F5B0 VA: 0x74F5B0
	|-Dictionary.KeyCollection.Enumerator<object, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F610 Offset: 0x74F610 VA: 0x74F610
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F670 Offset: 0x74F670 VA: 0x74F670
	|-Dictionary.KeyCollection.Enumerator<object, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F6D0 Offset: 0x74F6D0 VA: 0x74F6D0
	|-Dictionary.KeyCollection.Enumerator<object, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F730 Offset: 0x74F730 VA: 0x74F730
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F790 Offset: 0x74F790 VA: 0x74F790
	|-Dictionary.KeyCollection.Enumerator<object, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F7F0 Offset: 0x74F7F0 VA: 0x74F7F0
	|-Dictionary.KeyCollection.Enumerator<object, Playable>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F850 Offset: 0x74F850 VA: 0x74F850
	|-Dictionary.KeyCollection.Enumerator<ushort, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F8B0 Offset: 0x74F8B0 VA: 0x74F8B0
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F910 Offset: 0x74F910 VA: 0x74F910
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F970 Offset: 0x74F970 VA: 0x74F970
	|-Dictionary.KeyCollection.Enumerator<uint, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74F9D0 Offset: 0x74F9D0 VA: 0x74F9D0
	|-Dictionary.KeyCollection.Enumerator<uint, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FA30 Offset: 0x74FA30 VA: 0x74FA30
	|-Dictionary.KeyCollection.Enumerator<uint, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FA94 Offset: 0x74FA94 VA: 0x74FA94
	|-Dictionary.KeyCollection.Enumerator<ulong, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FB04 Offset: 0x74FB04 VA: 0x74FB04
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FB74 Offset: 0x74FB74 VA: 0x74FB74
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FBE4 Offset: 0x74FBE4 VA: 0x74FBE4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FC54 Offset: 0x74FC54 VA: 0x74FC54
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FCC4 Offset: 0x74FCC4 VA: 0x74FCC4
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FD38 Offset: 0x74FD38 VA: 0x74FD38
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FDA8 Offset: 0x74FDA8 VA: 0x74FDA8
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FE1C Offset: 0x74FE1C VA: 0x74FE1C
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FE8C Offset: 0x74FE8C VA: 0x74FE8C
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74FEFC Offset: 0x74FEFC VA: 0x74FEFC
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x7516A4 Offset: 0x7516A4 VA: 0x7516A4
	|-Dictionary.KeyCollection.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75170C Offset: 0x75170C VA: 0x75170C
	|-Dictionary.KeyCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751774 Offset: 0x751774 VA: 0x751774
	|-Dictionary.KeyCollection.Enumerator<U64Id, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7517DC Offset: 0x7517DC VA: 0x7517DC
	|-Dictionary.KeyCollection.Enumerator<U64Id, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75184C Offset: 0x75184C VA: 0x75184C
	|-Dictionary.KeyCollection.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7518AC Offset: 0x7518AC VA: 0x7518AC
	|-Dictionary.KeyCollection.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75191C Offset: 0x75191C VA: 0x75191C
	|-Dictionary.KeyCollection.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75198C Offset: 0x75198C VA: 0x75198C
	|-Dictionary.KeyCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7519FC Offset: 0x7519FC VA: 0x7519FC
	|-Dictionary.KeyCollection.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751A6C Offset: 0x751A6C VA: 0x751A6C
	|-Dictionary.KeyCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751ADC Offset: 0x751ADC VA: 0x751ADC
	|-Dictionary.KeyCollection.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751B50 Offset: 0x751B50 VA: 0x751B50
	|-Dictionary.KeyCollection.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751BC0 Offset: 0x751BC0 VA: 0x751BC0
	|-Dictionary.KeyCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74E9A0 Offset: 0x74E9A0 VA: 0x74E9A0
	|-Dictionary.KeyCollection.Enumerator<byte, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EA00 Offset: 0x74EA00 VA: 0x74EA00
	|-Dictionary.KeyCollection.Enumerator<byte, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EA60 Offset: 0x74EA60 VA: 0x74EA60
	|-Dictionary.KeyCollection.Enumerator<byte, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EAC0 Offset: 0x74EAC0 VA: 0x74EAC0
	|-Dictionary.KeyCollection.Enumerator<char, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EB30 Offset: 0x74EB30 VA: 0x74EB30
	|-Dictionary.KeyCollection.Enumerator<Guid, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EB90 Offset: 0x74EB90 VA: 0x74EB90
	|-Dictionary.KeyCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EBF0 Offset: 0x74EBF0 VA: 0x74EBF0
	|-Dictionary.KeyCollection.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EC50 Offset: 0x74EC50 VA: 0x74EC50
	|-Dictionary.KeyCollection.Enumerator<int, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74ECB0 Offset: 0x74ECB0 VA: 0x74ECB0
	|-Dictionary.KeyCollection.Enumerator<int, char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74ED10 Offset: 0x74ED10 VA: 0x74ED10
	|-Dictionary.KeyCollection.Enumerator<int, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74ED70 Offset: 0x74ED70 VA: 0x74ED70
	|-Dictionary.KeyCollection.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EDD0 Offset: 0x74EDD0 VA: 0x74EDD0
	|-Dictionary.KeyCollection.Enumerator<int, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EE30 Offset: 0x74EE30 VA: 0x74EE30
	|-Dictionary.KeyCollection.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EE90 Offset: 0x74EE90 VA: 0x74EE90
	|-Dictionary.KeyCollection.Enumerator<int, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EEF0 Offset: 0x74EEF0 VA: 0x74EEF0
	|-Dictionary.KeyCollection.Enumerator<int, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EF50 Offset: 0x74EF50 VA: 0x74EF50
	|-Dictionary.KeyCollection.Enumerator<int, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74EFB0 Offset: 0x74EFB0 VA: 0x74EFB0
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F010 Offset: 0x74F010 VA: 0x74F010
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F070 Offset: 0x74F070 VA: 0x74F070
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F0D0 Offset: 0x74F0D0 VA: 0x74F0D0
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F130 Offset: 0x74F130 VA: 0x74F130
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F190 Offset: 0x74F190 VA: 0x74F190
	|-Dictionary.KeyCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F1F4 Offset: 0x74F1F4 VA: 0x74F1F4
	|-Dictionary.KeyCollection.Enumerator<long, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F258 Offset: 0x74F258 VA: 0x74F258
	|-Dictionary.KeyCollection.Enumerator<long, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F2B8 Offset: 0x74F2B8 VA: 0x74F2B8
	|-Dictionary.KeyCollection.Enumerator<IntPtr, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F318 Offset: 0x74F318 VA: 0x74F318
	|-Dictionary.KeyCollection.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F378 Offset: 0x74F378 VA: 0x74F378
	|-Dictionary.KeyCollection.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F3D8 Offset: 0x74F3D8 VA: 0x74F3D8
	|-Dictionary.KeyCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F438 Offset: 0x74F438 VA: 0x74F438
	|-Dictionary.KeyCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F498 Offset: 0x74F498 VA: 0x74F498
	|-Dictionary.KeyCollection.Enumerator<object, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F4F8 Offset: 0x74F4F8 VA: 0x74F4F8
	|-Dictionary.KeyCollection.Enumerator<object, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F558 Offset: 0x74F558 VA: 0x74F558
	|-Dictionary.KeyCollection.Enumerator<object, short>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F5B8 Offset: 0x74F5B8 VA: 0x74F5B8
	|-Dictionary.KeyCollection.Enumerator<object, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F618 Offset: 0x74F618 VA: 0x74F618
	|-Dictionary.KeyCollection.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F678 Offset: 0x74F678 VA: 0x74F678
	|-Dictionary.KeyCollection.Enumerator<object, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F6D8 Offset: 0x74F6D8 VA: 0x74F6D8
	|-Dictionary.KeyCollection.Enumerator<object, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F738 Offset: 0x74F738 VA: 0x74F738
	|-Dictionary.KeyCollection.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F798 Offset: 0x74F798 VA: 0x74F798
	|-Dictionary.KeyCollection.Enumerator<object, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F7F8 Offset: 0x74F7F8 VA: 0x74F7F8
	|-Dictionary.KeyCollection.Enumerator<object, Playable>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F858 Offset: 0x74F858 VA: 0x74F858
	|-Dictionary.KeyCollection.Enumerator<ushort, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F8B8 Offset: 0x74F8B8 VA: 0x74F8B8
	|-Dictionary.KeyCollection.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F918 Offset: 0x74F918 VA: 0x74F918
	|-Dictionary.KeyCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F978 Offset: 0x74F978 VA: 0x74F978
	|-Dictionary.KeyCollection.Enumerator<uint, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74F9D8 Offset: 0x74F9D8 VA: 0x74F9D8
	|-Dictionary.KeyCollection.Enumerator<uint, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FA38 Offset: 0x74FA38 VA: 0x74FA38
	|-Dictionary.KeyCollection.Enumerator<uint, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FA9C Offset: 0x74FA9C VA: 0x74FA9C
	|-Dictionary.KeyCollection.Enumerator<ulong, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FB0C Offset: 0x74FB0C VA: 0x74FB0C
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FB7C Offset: 0x74FB7C VA: 0x74FB7C
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FBEC Offset: 0x74FBEC VA: 0x74FBEC
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FC5C Offset: 0x74FC5C VA: 0x74FC5C
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FCCC Offset: 0x74FCCC VA: 0x74FCCC
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FD40 Offset: 0x74FD40 VA: 0x74FD40
	|-Dictionary.KeyCollection.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FDB0 Offset: 0x74FDB0 VA: 0x74FDB0
	|-Dictionary.KeyCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FE24 Offset: 0x74FE24 VA: 0x74FE24
	|-Dictionary.KeyCollection.Enumerator<Vector3, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FE94 Offset: 0x74FE94 VA: 0x74FE94
	|-Dictionary.KeyCollection.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74FF04 Offset: 0x74FF04 VA: 0x74FF04
	|-Dictionary.KeyCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.Reset
	*/
}
