// Namespace: 
[Serializable]
public struct Dictionary.ValueCollection.Enumerator<TKey, TValue> : IEnumerator<TValue>, IDisposable, IEnumerator // TypeDefIndex: 1421
{
	// Fields
	private Dictionary<TKey, TValue> dictionary; // 0x0
	private int index; // 0x0
	private int version; // 0x0
	private TValue currentValue; // 0x0

	// Properties
	public TValue Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Dictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x766600 Offset: 0x766600 VA: 0x766600
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>..ctor
	|
	|-RVA: 0x766670 Offset: 0x766670 VA: 0x766670
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>..ctor
	|
	|-RVA: 0x7666E0 Offset: 0x7666E0 VA: 0x7666E0
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>..ctor
	|
	|-RVA: 0x766740 Offset: 0x766740 VA: 0x766740
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>..ctor
	|
	|-RVA: 0x7667A0 Offset: 0x7667A0 VA: 0x7667A0
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>..ctor
	|
	|-RVA: 0x766800 Offset: 0x766800 VA: 0x766800
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>..ctor
	|
	|-RVA: 0x766860 Offset: 0x766860 VA: 0x766860
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>..ctor
	|
	|-RVA: 0x7668D0 Offset: 0x7668D0 VA: 0x7668D0
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>..ctor
	|
	|-RVA: 0x766930 Offset: 0x766930 VA: 0x766930
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>..ctor
	|
	|-RVA: 0x766990 Offset: 0x766990 VA: 0x766990
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>..ctor
	|
	|-RVA: 0x7669F0 Offset: 0x7669F0 VA: 0x7669F0
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>..ctor
	|
	|-RVA: 0x766A50 Offset: 0x766A50 VA: 0x766A50
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>..ctor
	|
	|-RVA: 0x766AB0 Offset: 0x766AB0 VA: 0x766AB0
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>..ctor
	|
	|-RVA: 0x766B10 Offset: 0x766B10 VA: 0x766B10
	|-Dictionary.ValueCollection.Enumerator<byte, object>..ctor
	|
	|-RVA: 0x766B70 Offset: 0x766B70 VA: 0x766B70
	|-Dictionary.ValueCollection.Enumerator<byte, float>..ctor
	|
	|-RVA: 0x766BD0 Offset: 0x766BD0 VA: 0x766BD0
	|-Dictionary.ValueCollection.Enumerator<byte, uint>..ctor
	|
	|-RVA: 0x766C30 Offset: 0x766C30 VA: 0x766C30
	|-Dictionary.ValueCollection.Enumerator<char, object>..ctor
	|
	|-RVA: 0x766C90 Offset: 0x766C90 VA: 0x766C90
	|-Dictionary.ValueCollection.Enumerator<Guid, object>..ctor
	|
	|-RVA: 0x766CF0 Offset: 0x766CF0 VA: 0x766CF0
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>..ctor
	|
	|-RVA: 0x766D80 Offset: 0x766D80 VA: 0x766D80
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>..ctor
	|
	|-RVA: 0x766DF0 Offset: 0x766DF0 VA: 0x766DF0
	|-Dictionary.ValueCollection.Enumerator<int, bool>..ctor
	|
	|-RVA: 0x766E50 Offset: 0x766E50 VA: 0x766E50
	|-Dictionary.ValueCollection.Enumerator<int, char>..ctor
	|
	|-RVA: 0x766EB0 Offset: 0x766EB0 VA: 0x766EB0
	|-Dictionary.ValueCollection.Enumerator<int, int>..ctor
	|
	|-RVA: 0x766F10 Offset: 0x766F10 VA: 0x766F10
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>..ctor
	|
	|-RVA: 0x766F70 Offset: 0x766F70 VA: 0x766F70
	|-Dictionary.ValueCollection.Enumerator<int, long>..ctor
	|
	|-RVA: 0x766FD4 Offset: 0x766FD4 VA: 0x766FD4
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>..ctor
	|
	|-RVA: 0x767044 Offset: 0x767044 VA: 0x767044
	|-Dictionary.ValueCollection.Enumerator<int, object>..ctor
	|
	|-RVA: 0x7670A4 Offset: 0x7670A4 VA: 0x7670A4
	|-Dictionary.ValueCollection.Enumerator<int, float>..ctor
	|
	|-RVA: 0x767104 Offset: 0x767104 VA: 0x767104
	|-Dictionary.ValueCollection.Enumerator<int, uint>..ctor
	|
	|-RVA: 0x767164 Offset: 0x767164 VA: 0x767164
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>..ctor
	|
	|-RVA: 0x7671C4 Offset: 0x7671C4 VA: 0x7671C4
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>..ctor
	|
	|-RVA: 0x759C78 Offset: 0x759C78 VA: 0x759C78
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>..ctor
	|
	|-RVA: 0x759CD8 Offset: 0x759CD8 VA: 0x759CD8
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>..ctor
	|
	|-RVA: 0x759D38 Offset: 0x759D38 VA: 0x759D38
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>..ctor
	|
	|-RVA: 0x759DA8 Offset: 0x759DA8 VA: 0x759DA8
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>..ctor
	|
	|-RVA: 0x759E18 Offset: 0x759E18 VA: 0x759E18
	|-Dictionary.ValueCollection.Enumerator<long, int>..ctor
	|
	|-RVA: 0x759E78 Offset: 0x759E78 VA: 0x759E78
	|-Dictionary.ValueCollection.Enumerator<long, object>..ctor
	|
	|-RVA: 0x759ED8 Offset: 0x759ED8 VA: 0x759ED8
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>..ctor
	|
	|-RVA: 0x759F38 Offset: 0x759F38 VA: 0x759F38
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>..ctor
	|
	|-RVA: 0x759FA8 Offset: 0x759FA8 VA: 0x759FA8
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>..ctor
	|
	|-RVA: 0x75A018 Offset: 0x75A018 VA: 0x75A018
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>..ctor
	|
	|-RVA: 0x75A08C Offset: 0x75A08C VA: 0x75A08C
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>..ctor
	|
	|-RVA: 0x75A104 Offset: 0x75A104 VA: 0x75A104
	|-Dictionary.ValueCollection.Enumerator<object, bool>..ctor
	|
	|-RVA: 0x75A164 Offset: 0x75A164 VA: 0x75A164
	|-Dictionary.ValueCollection.Enumerator<object, byte>..ctor
	|
	|-RVA: 0x75A1C4 Offset: 0x75A1C4 VA: 0x75A1C4
	|-Dictionary.ValueCollection.Enumerator<object, short>..ctor
	|
	|-RVA: 0x75A224 Offset: 0x75A224 VA: 0x75A224
	|-Dictionary.ValueCollection.Enumerator<object, int>..ctor
	|
	|-RVA: 0x75A284 Offset: 0x75A284 VA: 0x75A284
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>..ctor
	|
	|-RVA: 0x75A2E4 Offset: 0x75A2E4 VA: 0x75A2E4
	|-Dictionary.ValueCollection.Enumerator<object, long>..ctor
	|
	|-RVA: 0x75A348 Offset: 0x75A348 VA: 0x75A348
	|-Dictionary.ValueCollection.Enumerator<object, object>..ctor
	|
	|-RVA: 0x75A3A8 Offset: 0x75A3A8 VA: 0x75A3A8
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>..ctor
	|
	|-RVA: 0x75A418 Offset: 0x75A418 VA: 0x75A418
	|-Dictionary.ValueCollection.Enumerator<object, uint>..ctor
	|
	|-RVA: 0x75A478 Offset: 0x75A478 VA: 0x75A478
	|-Dictionary.ValueCollection.Enumerator<object, Playable>..ctor
	|
	|-RVA: 0x75A4E8 Offset: 0x75A4E8 VA: 0x75A4E8
	|-Dictionary.ValueCollection.Enumerator<ushort, object>..ctor
	|
	|-RVA: 0x75A548 Offset: 0x75A548 VA: 0x75A548
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>..ctor
	|
	|-RVA: 0x75A5B8 Offset: 0x75A5B8 VA: 0x75A5B8
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>..ctor
	|
	|-RVA: 0x75A62C Offset: 0x75A62C VA: 0x75A62C
	|-Dictionary.ValueCollection.Enumerator<uint, byte>..ctor
	|
	|-RVA: 0x75A68C Offset: 0x75A68C VA: 0x75A68C
	|-Dictionary.ValueCollection.Enumerator<uint, int>..ctor
	|
	|-RVA: 0x75A6EC Offset: 0x75A6EC VA: 0x75A6EC
	|-Dictionary.ValueCollection.Enumerator<uint, object>..ctor
	|
	|-RVA: 0x75A74C Offset: 0x75A74C VA: 0x75A74C
	|-Dictionary.ValueCollection.Enumerator<ulong, object>..ctor
	|
	|-RVA: 0x75A7AC Offset: 0x75A7AC VA: 0x75A7AC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>..ctor
	|
	|-RVA: 0x75A80C Offset: 0x75A80C VA: 0x75A80C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>..ctor
	|
	|-RVA: 0x75A86C Offset: 0x75A86C VA: 0x75A86C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>..ctor
	|
	|-RVA: 0x75A8CC Offset: 0x75A8CC VA: 0x75A8CC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>..ctor
	|
	|-RVA: 0x75A92C Offset: 0x75A92C VA: 0x75A92C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>..ctor
	|
	|-RVA: 0x75A98C Offset: 0x75A98C VA: 0x75A98C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>..ctor
	|
	|-RVA: 0x75A9EC Offset: 0x75A9EC VA: 0x75A9EC
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>..ctor
	|
	|-RVA: 0x75AA4C Offset: 0x75AA4C VA: 0x75AA4C
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>..ctor
	|
	|-RVA: 0x75AAAC Offset: 0x75AAAC VA: 0x75AAAC
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>..ctor
	|
	|-RVA: 0x75AB0C Offset: 0x75AB0C VA: 0x75AB0C
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x766640 Offset: 0x766640 VA: 0x766640
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>.Dispose
	|
	|-RVA: 0x76677C Offset: 0x76677C VA: 0x76677C
	|-Dictionary.ValueCollection.Enumerator<U64Id, IDisturbEntity>.Dispose
	|-Dictionary.ValueCollection.Enumerator<U64Id, ScoutCar>.Dispose
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>.Dispose
	|
	|-RVA: 0x7666B0 Offset: 0x7666B0 VA: 0x7666B0
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.Dispose
	|
	|-RVA: 0x76671C Offset: 0x76671C VA: 0x76671C
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>.Dispose
	|
	|-RVA: 0x7667DC Offset: 0x7667DC VA: 0x7667DC
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>.Dispose
	|
	|-RVA: 0x76683C Offset: 0x76683C VA: 0x76683C
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>.Dispose
	|
	|-RVA: 0x75A384 Offset: 0x75A384 VA: 0x75A384
	|-Dictionary.ValueCollection.Enumerator<LightweightTriggerBase, IBlockingBoard>.Dispose
	|-Dictionary.ValueCollection.Enumerator<Bone, Transform>.Dispose
	|-Dictionary.ValueCollection.Enumerator<BoundingBoxAttachment, PolygonCollider2D>.Dispose
	|-Dictionary.ValueCollection.Enumerator<object, object>.Dispose
	|-Dictionary.ValueCollection.Enumerator<string, DtdParser.UndeclaredNotation>.Dispose
	|-Dictionary.ValueCollection.Enumerator<string, SchemaNotation>.Dispose
	|-Dictionary.ValueCollection.Enumerator<string, AliasValueDeserializer.ValuePromise>.Dispose
	|-Dictionary.ValueCollection.Enumerator<Type, PostProcessBundle>.Dispose
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaAttDef>.Dispose
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaElementDecl>.Dispose
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaEntity>.Dispose
	|-Dictionary.ValueCollection.Enumerator<GameObject, List<GameObject>>.Dispose
	|-Dictionary.ValueCollection.Enumerator<GameObject, GameObject>.Dispose
	|-Dictionary.ValueCollection.Enumerator<Material, Material>.Dispose
	|-Dictionary.ValueCollection.Enumerator<Shader, PropertySheet>.Dispose
	|
	|-RVA: 0x7668A0 Offset: 0x7668A0 VA: 0x7668A0
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>.Dispose
	|
	|-RVA: 0x76690C Offset: 0x76690C VA: 0x76690C
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.Dispose
	|
	|-RVA: 0x76696C Offset: 0x76696C VA: 0x76696C
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>.Dispose
	|
	|-RVA: 0x7669CC Offset: 0x7669CC VA: 0x7669CC
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.Dispose
	|
	|-RVA: 0x766A2C Offset: 0x766A2C VA: 0x766A2C
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>.Dispose
	|
	|-RVA: 0x766A8C Offset: 0x766A8C VA: 0x766A8C
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>.Dispose
	|
	|-RVA: 0x766AEC Offset: 0x766AEC VA: 0x766AEC
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.Dispose
	|
	|-RVA: 0x766B4C Offset: 0x766B4C VA: 0x766B4C
	|-Dictionary.ValueCollection.Enumerator<byte, RemoteCharacterController>.Dispose
	|-Dictionary.ValueCollection.Enumerator<byte, List<int>>.Dispose
	|-Dictionary.ValueCollection.Enumerator<byte, object>.Dispose
	|
	|-RVA: 0x766BAC Offset: 0x766BAC VA: 0x766BAC
	|-Dictionary.ValueCollection.Enumerator<byte, float>.Dispose
	|
	|-RVA: 0x766C0C Offset: 0x766C0C VA: 0x766C0C
	|-Dictionary.ValueCollection.Enumerator<byte, uint>.Dispose
	|
	|-RVA: 0x766C6C Offset: 0x766C6C VA: 0x766C6C
	|-Dictionary.ValueCollection.Enumerator<char, object>.Dispose
	|
	|-RVA: 0x766CCC Offset: 0x766CCC VA: 0x766CCC
	|-Dictionary.ValueCollection.Enumerator<Guid, object>.Dispose
	|
	|-RVA: 0x766D44 Offset: 0x766D44 VA: 0x766D44
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.Dispose
	|
	|-RVA: 0x766DC0 Offset: 0x766DC0 VA: 0x766DC0
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>.Dispose
	|
	|-RVA: 0x767080 Offset: 0x767080 VA: 0x767080
	|-Dictionary.ValueCollection.Enumerator<int, Element<FixtureProxy>>.Dispose
	|-Dictionary.ValueCollection.Enumerator<int, effect_table.Record>.Dispose
	|-Dictionary.ValueCollection.Enumerator<int, gun_data_table.Record>.Dispose
	|-Dictionary.ValueCollection.Enumerator<int, object>.Dispose
	|-Dictionary.ValueCollection.Enumerator<int, PointerEventData>.Dispose
	|
	|-RVA: 0x766E2C Offset: 0x766E2C VA: 0x766E2C
	|-Dictionary.ValueCollection.Enumerator<int, bool>.Dispose
	|
	|-RVA: 0x766E8C Offset: 0x766E8C VA: 0x766E8C
	|-Dictionary.ValueCollection.Enumerator<int, char>.Dispose
	|
	|-RVA: 0x766EEC Offset: 0x766EEC VA: 0x766EEC
	|-Dictionary.ValueCollection.Enumerator<int, int>.Dispose
	|
	|-RVA: 0x766F4C Offset: 0x766F4C VA: 0x766F4C
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>.Dispose
	|
	|-RVA: 0x766FB0 Offset: 0x766FB0 VA: 0x766FB0
	|-Dictionary.ValueCollection.Enumerator<int, long>.Dispose
	|
	|-RVA: 0x767018 Offset: 0x767018 VA: 0x767018
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>.Dispose
	|
	|-RVA: 0x7670E0 Offset: 0x7670E0 VA: 0x7670E0
	|-Dictionary.ValueCollection.Enumerator<int, float>.Dispose
	|
	|-RVA: 0x767140 Offset: 0x767140 VA: 0x767140
	|-Dictionary.ValueCollection.Enumerator<int, uint>.Dispose
	|
	|-RVA: 0x7671A0 Offset: 0x7671A0 VA: 0x7671A0
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>.Dispose
	|
	|-RVA: 0x767200 Offset: 0x767200 VA: 0x767200
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>.Dispose
	|
	|-RVA: 0x759CB4 Offset: 0x759CB4 VA: 0x759CB4
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>.Dispose
	|-Dictionary.ValueCollection.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.Dispose
	|-Dictionary.ValueCollection.Enumerator<EffectType, List<Action<float>>>.Dispose
	|
	|-RVA: 0x759D14 Offset: 0x759D14 VA: 0x759D14
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>.Dispose
	|
	|-RVA: 0x759D78 Offset: 0x759D78 VA: 0x759D78
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.Dispose
	|
	|-RVA: 0x759DE8 Offset: 0x759DE8 VA: 0x759DE8
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.Dispose
	|
	|-RVA: 0x759E54 Offset: 0x759E54 VA: 0x759E54
	|-Dictionary.ValueCollection.Enumerator<long, int>.Dispose
	|
	|-RVA: 0x759EB4 Offset: 0x759EB4 VA: 0x759EB4
	|-Dictionary.ValueCollection.Enumerator<long, object>.Dispose
	|
	|-RVA: 0x759F14 Offset: 0x759F14 VA: 0x759F14
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>.Dispose
	|
	|-RVA: 0x759F7C Offset: 0x759F7C VA: 0x759F7C
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>.Dispose
	|
	|-RVA: 0x759FE8 Offset: 0x759FE8 VA: 0x759FE8
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>.Dispose
	|
	|-RVA: 0x75A05C Offset: 0x75A05C VA: 0x75A05C
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.Dispose
	|
	|-RVA: 0x75A0D0 Offset: 0x75A0D0 VA: 0x75A0D0
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.Dispose
	|
	|-RVA: 0x75A140 Offset: 0x75A140 VA: 0x75A140
	|-Dictionary.ValueCollection.Enumerator<object, bool>.Dispose
	|
	|-RVA: 0x75A1A0 Offset: 0x75A1A0 VA: 0x75A1A0
	|-Dictionary.ValueCollection.Enumerator<object, byte>.Dispose
	|
	|-RVA: 0x75A200 Offset: 0x75A200 VA: 0x75A200
	|-Dictionary.ValueCollection.Enumerator<object, short>.Dispose
	|
	|-RVA: 0x75A260 Offset: 0x75A260 VA: 0x75A260
	|-Dictionary.ValueCollection.Enumerator<object, int>.Dispose
	|
	|-RVA: 0x75A2C0 Offset: 0x75A2C0 VA: 0x75A2C0
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>.Dispose
	|
	|-RVA: 0x75A324 Offset: 0x75A324 VA: 0x75A324
	|-Dictionary.ValueCollection.Enumerator<object, long>.Dispose
	|
	|-RVA: 0x75A3E8 Offset: 0x75A3E8 VA: 0x75A3E8
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>.Dispose
	|
	|-RVA: 0x75A454 Offset: 0x75A454 VA: 0x75A454
	|-Dictionary.ValueCollection.Enumerator<object, uint>.Dispose
	|
	|-RVA: 0x75A4B8 Offset: 0x75A4B8 VA: 0x75A4B8
	|-Dictionary.ValueCollection.Enumerator<object, Playable>.Dispose
	|
	|-RVA: 0x75A524 Offset: 0x75A524 VA: 0x75A524
	|-Dictionary.ValueCollection.Enumerator<ushort, ToolBase>.Dispose
	|-Dictionary.ValueCollection.Enumerator<ushort, object>.Dispose
	|
	|-RVA: 0x75A58C Offset: 0x75A58C VA: 0x75A58C
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>.Dispose
	|
	|-RVA: 0x75A728 Offset: 0x75A728 VA: 0x75A728
	|-Dictionary.ValueCollection.Enumerator<uint, BattleZoneData.BattleZoneInfo>.Dispose
	|-Dictionary.ValueCollection.Enumerator<uint, CharacterData>.Dispose
	|-Dictionary.ValueCollection.Enumerator<uint, CombatAreaConfig.CombatArea>.Dispose
	|-Dictionary.ValueCollection.Enumerator<uint, BattlePlayerOccInfo>.Dispose
	|-Dictionary.ValueCollection.Enumerator<uint, List<int>>.Dispose
	|-Dictionary.ValueCollection.Enumerator<uint, object>.Dispose
	|
	|-RVA: 0x75A5FC Offset: 0x75A5FC VA: 0x75A5FC
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.Dispose
	|
	|-RVA: 0x75A668 Offset: 0x75A668 VA: 0x75A668
	|-Dictionary.ValueCollection.Enumerator<uint, byte>.Dispose
	|
	|-RVA: 0x75A6C8 Offset: 0x75A6C8 VA: 0x75A6C8
	|-Dictionary.ValueCollection.Enumerator<uint, int>.Dispose
	|
	|-RVA: 0x75A788 Offset: 0x75A788 VA: 0x75A788
	|-Dictionary.ValueCollection.Enumerator<ulong, object>.Dispose
	|
	|-RVA: 0x75A7E8 Offset: 0x75A7E8 VA: 0x75A7E8
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.Dispose
	|
	|-RVA: 0x75A848 Offset: 0x75A848 VA: 0x75A848
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>.Dispose
	|
	|-RVA: 0x75A8A8 Offset: 0x75A8A8 VA: 0x75A8A8
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.Dispose
	|
	|-RVA: 0x75A908 Offset: 0x75A908 VA: 0x75A908
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.Dispose
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<EBodyState, EShieldState>, RectTransform>.Dispose
	|
	|-RVA: 0x75A968 Offset: 0x75A968 VA: 0x75A968
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>.Dispose
	|
	|-RVA: 0x75A9C8 Offset: 0x75A9C8 VA: 0x75A9C8
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>.Dispose
	|
	|-RVA: 0x75AA28 Offset: 0x75AA28 VA: 0x75AA28
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.Dispose
	|
	|-RVA: 0x75AA88 Offset: 0x75AA88 VA: 0x75AA88
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>.Dispose
	|
	|-RVA: 0x75AAE8 Offset: 0x75AAE8 VA: 0x75AAE8
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>.Dispose
	|
	|-RVA: 0x75AB48 Offset: 0x75AB48 VA: 0x75AB48
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x766644 Offset: 0x766644 VA: 0x766644
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>.MoveNext
	|
	|-RVA: 0x766780 Offset: 0x766780 VA: 0x766780
	|-Dictionary.ValueCollection.Enumerator<U64Id, IDisturbEntity>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<U64Id, ScoutCar>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>.MoveNext
	|
	|-RVA: 0x7666B4 Offset: 0x7666B4 VA: 0x7666B4
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.MoveNext
	|
	|-RVA: 0x766720 Offset: 0x766720 VA: 0x766720
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>.MoveNext
	|
	|-RVA: 0x7667E0 Offset: 0x7667E0 VA: 0x7667E0
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>.MoveNext
	|
	|-RVA: 0x766840 Offset: 0x766840 VA: 0x766840
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>.MoveNext
	|
	|-RVA: 0x75A388 Offset: 0x75A388 VA: 0x75A388
	|-Dictionary.ValueCollection.Enumerator<LightweightTriggerBase, IBlockingBoard>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<Bone, Transform>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<BoundingBoxAttachment, PolygonCollider2D>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<object, object>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<string, DtdParser.UndeclaredNotation>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<string, SchemaNotation>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<string, AliasValueDeserializer.ValuePromise>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<Type, PostProcessBundle>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaAttDef>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaElementDecl>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaEntity>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<GameObject, List<GameObject>>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<GameObject, GameObject>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<Material, Material>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<Shader, PropertySheet>.MoveNext
	|
	|-RVA: 0x7668A4 Offset: 0x7668A4 VA: 0x7668A4
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>.MoveNext
	|
	|-RVA: 0x766910 Offset: 0x766910 VA: 0x766910
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.MoveNext
	|
	|-RVA: 0x766970 Offset: 0x766970 VA: 0x766970
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>.MoveNext
	|
	|-RVA: 0x7669D0 Offset: 0x7669D0 VA: 0x7669D0
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.MoveNext
	|
	|-RVA: 0x766A30 Offset: 0x766A30 VA: 0x766A30
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>.MoveNext
	|
	|-RVA: 0x766A90 Offset: 0x766A90 VA: 0x766A90
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>.MoveNext
	|
	|-RVA: 0x766AF0 Offset: 0x766AF0 VA: 0x766AF0
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.MoveNext
	|
	|-RVA: 0x766B50 Offset: 0x766B50 VA: 0x766B50
	|-Dictionary.ValueCollection.Enumerator<byte, RemoteCharacterController>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<byte, List<int>>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<byte, object>.MoveNext
	|
	|-RVA: 0x766BB0 Offset: 0x766BB0 VA: 0x766BB0
	|-Dictionary.ValueCollection.Enumerator<byte, float>.MoveNext
	|
	|-RVA: 0x766C10 Offset: 0x766C10 VA: 0x766C10
	|-Dictionary.ValueCollection.Enumerator<byte, uint>.MoveNext
	|
	|-RVA: 0x766C70 Offset: 0x766C70 VA: 0x766C70
	|-Dictionary.ValueCollection.Enumerator<char, object>.MoveNext
	|
	|-RVA: 0x766CD0 Offset: 0x766CD0 VA: 0x766CD0
	|-Dictionary.ValueCollection.Enumerator<Guid, object>.MoveNext
	|
	|-RVA: 0x766D48 Offset: 0x766D48 VA: 0x766D48
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.MoveNext
	|
	|-RVA: 0x766DC4 Offset: 0x766DC4 VA: 0x766DC4
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>.MoveNext
	|
	|-RVA: 0x767084 Offset: 0x767084 VA: 0x767084
	|-Dictionary.ValueCollection.Enumerator<int, Element<FixtureProxy>>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<int, effect_table.Record>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<int, gun_data_table.Record>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<int, object>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<int, PointerEventData>.MoveNext
	|
	|-RVA: 0x766E30 Offset: 0x766E30 VA: 0x766E30
	|-Dictionary.ValueCollection.Enumerator<int, bool>.MoveNext
	|
	|-RVA: 0x766E90 Offset: 0x766E90 VA: 0x766E90
	|-Dictionary.ValueCollection.Enumerator<int, char>.MoveNext
	|
	|-RVA: 0x766EF0 Offset: 0x766EF0 VA: 0x766EF0
	|-Dictionary.ValueCollection.Enumerator<int, int>.MoveNext
	|
	|-RVA: 0x766F50 Offset: 0x766F50 VA: 0x766F50
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>.MoveNext
	|
	|-RVA: 0x766FB4 Offset: 0x766FB4 VA: 0x766FB4
	|-Dictionary.ValueCollection.Enumerator<int, long>.MoveNext
	|
	|-RVA: 0x76701C Offset: 0x76701C VA: 0x76701C
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>.MoveNext
	|
	|-RVA: 0x7670E4 Offset: 0x7670E4 VA: 0x7670E4
	|-Dictionary.ValueCollection.Enumerator<int, float>.MoveNext
	|
	|-RVA: 0x767144 Offset: 0x767144 VA: 0x767144
	|-Dictionary.ValueCollection.Enumerator<int, uint>.MoveNext
	|
	|-RVA: 0x7671A4 Offset: 0x7671A4 VA: 0x7671A4
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>.MoveNext
	|
	|-RVA: 0x767204 Offset: 0x767204 VA: 0x767204
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>.MoveNext
	|
	|-RVA: 0x759CB8 Offset: 0x759CB8 VA: 0x759CB8
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<EffectType, List<Action<float>>>.MoveNext
	|
	|-RVA: 0x759D18 Offset: 0x759D18 VA: 0x759D18
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>.MoveNext
	|
	|-RVA: 0x759D7C Offset: 0x759D7C VA: 0x759D7C
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.MoveNext
	|
	|-RVA: 0x759DEC Offset: 0x759DEC VA: 0x759DEC
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.MoveNext
	|
	|-RVA: 0x759E58 Offset: 0x759E58 VA: 0x759E58
	|-Dictionary.ValueCollection.Enumerator<long, int>.MoveNext
	|
	|-RVA: 0x759EB8 Offset: 0x759EB8 VA: 0x759EB8
	|-Dictionary.ValueCollection.Enumerator<long, object>.MoveNext
	|
	|-RVA: 0x759F18 Offset: 0x759F18 VA: 0x759F18
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>.MoveNext
	|
	|-RVA: 0x759F80 Offset: 0x759F80 VA: 0x759F80
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>.MoveNext
	|
	|-RVA: 0x759FEC Offset: 0x759FEC VA: 0x759FEC
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>.MoveNext
	|
	|-RVA: 0x75A060 Offset: 0x75A060 VA: 0x75A060
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.MoveNext
	|
	|-RVA: 0x75A0D4 Offset: 0x75A0D4 VA: 0x75A0D4
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.MoveNext
	|
	|-RVA: 0x75A144 Offset: 0x75A144 VA: 0x75A144
	|-Dictionary.ValueCollection.Enumerator<object, bool>.MoveNext
	|
	|-RVA: 0x75A1A4 Offset: 0x75A1A4 VA: 0x75A1A4
	|-Dictionary.ValueCollection.Enumerator<object, byte>.MoveNext
	|
	|-RVA: 0x75A204 Offset: 0x75A204 VA: 0x75A204
	|-Dictionary.ValueCollection.Enumerator<object, short>.MoveNext
	|
	|-RVA: 0x75A264 Offset: 0x75A264 VA: 0x75A264
	|-Dictionary.ValueCollection.Enumerator<object, int>.MoveNext
	|
	|-RVA: 0x75A2C4 Offset: 0x75A2C4 VA: 0x75A2C4
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>.MoveNext
	|
	|-RVA: 0x75A328 Offset: 0x75A328 VA: 0x75A328
	|-Dictionary.ValueCollection.Enumerator<object, long>.MoveNext
	|
	|-RVA: 0x75A3EC Offset: 0x75A3EC VA: 0x75A3EC
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>.MoveNext
	|
	|-RVA: 0x75A458 Offset: 0x75A458 VA: 0x75A458
	|-Dictionary.ValueCollection.Enumerator<object, uint>.MoveNext
	|
	|-RVA: 0x75A4BC Offset: 0x75A4BC VA: 0x75A4BC
	|-Dictionary.ValueCollection.Enumerator<object, Playable>.MoveNext
	|
	|-RVA: 0x75A528 Offset: 0x75A528 VA: 0x75A528
	|-Dictionary.ValueCollection.Enumerator<ushort, ToolBase>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<ushort, object>.MoveNext
	|
	|-RVA: 0x75A590 Offset: 0x75A590 VA: 0x75A590
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>.MoveNext
	|
	|-RVA: 0x75A72C Offset: 0x75A72C VA: 0x75A72C
	|-Dictionary.ValueCollection.Enumerator<uint, BattleZoneData.BattleZoneInfo>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<uint, CharacterData>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<uint, CombatAreaConfig.CombatArea>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<uint, BattlePlayerOccInfo>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<uint, List<int>>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<uint, object>.MoveNext
	|
	|-RVA: 0x75A600 Offset: 0x75A600 VA: 0x75A600
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.MoveNext
	|
	|-RVA: 0x75A66C Offset: 0x75A66C VA: 0x75A66C
	|-Dictionary.ValueCollection.Enumerator<uint, byte>.MoveNext
	|
	|-RVA: 0x75A6CC Offset: 0x75A6CC VA: 0x75A6CC
	|-Dictionary.ValueCollection.Enumerator<uint, int>.MoveNext
	|
	|-RVA: 0x75A78C Offset: 0x75A78C VA: 0x75A78C
	|-Dictionary.ValueCollection.Enumerator<ulong, object>.MoveNext
	|
	|-RVA: 0x75A7EC Offset: 0x75A7EC VA: 0x75A7EC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.MoveNext
	|
	|-RVA: 0x75A84C Offset: 0x75A84C VA: 0x75A84C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>.MoveNext
	|
	|-RVA: 0x75A8AC Offset: 0x75A8AC VA: 0x75A8AC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.MoveNext
	|
	|-RVA: 0x75A90C Offset: 0x75A90C VA: 0x75A90C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.MoveNext
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<EBodyState, EShieldState>, RectTransform>.MoveNext
	|
	|-RVA: 0x75A96C Offset: 0x75A96C VA: 0x75A96C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>.MoveNext
	|
	|-RVA: 0x75A9CC Offset: 0x75A9CC VA: 0x75A9CC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>.MoveNext
	|
	|-RVA: 0x75AA2C Offset: 0x75AA2C VA: 0x75AA2C
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.MoveNext
	|
	|-RVA: 0x75AA8C Offset: 0x75AA8C VA: 0x75AA8C
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>.MoveNext
	|
	|-RVA: 0x75AAEC Offset: 0x75AAEC VA: 0x75AAEC
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>.MoveNext
	|
	|-RVA: 0x75AB4C Offset: 0x75AB4C VA: 0x75AB4C
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public TValue get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x76664C Offset: 0x76664C VA: 0x76664C
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>.get_Current
	|
	|-RVA: 0x766788 Offset: 0x766788 VA: 0x766788
	|-Dictionary.ValueCollection.Enumerator<U64Id, IDisturbEntity>.get_Current
	|-Dictionary.ValueCollection.Enumerator<U64Id, ScoutCar>.get_Current
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>.get_Current
	|
	|-RVA: 0x75A390 Offset: 0x75A390 VA: 0x75A390
	|-Dictionary.ValueCollection.Enumerator<LightweightTriggerBase, IBlockingBoard>.get_Current
	|-Dictionary.ValueCollection.Enumerator<Bone, Transform>.get_Current
	|-Dictionary.ValueCollection.Enumerator<BoundingBoxAttachment, PolygonCollider2D>.get_Current
	|-Dictionary.ValueCollection.Enumerator<string, DtdParser.UndeclaredNotation>.get_Current
	|-Dictionary.ValueCollection.Enumerator<string, SchemaNotation>.get_Current
	|-Dictionary.ValueCollection.Enumerator<string, AliasValueDeserializer.ValuePromise>.get_Current
	|-Dictionary.ValueCollection.Enumerator<Type, PostProcessBundle>.get_Current
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaAttDef>.get_Current
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaElementDecl>.get_Current
	|-Dictionary.ValueCollection.Enumerator<XmlQualifiedName, SchemaEntity>.get_Current
	|-Dictionary.ValueCollection.Enumerator<GameObject, List<GameObject>>.get_Current
	|-Dictionary.ValueCollection.Enumerator<GameObject, GameObject>.get_Current
	|-Dictionary.ValueCollection.Enumerator<Material, Material>.get_Current
	|-Dictionary.ValueCollection.Enumerator<Shader, PropertySheet>.get_Current
	|-Dictionary.ValueCollection.Enumerator<object, object>.get_Current
	|
	|-RVA: 0x766B58 Offset: 0x766B58 VA: 0x766B58
	|-Dictionary.ValueCollection.Enumerator<byte, RemoteCharacterController>.get_Current
	|-Dictionary.ValueCollection.Enumerator<byte, List<int>>.get_Current
	|-Dictionary.ValueCollection.Enumerator<byte, object>.get_Current
	|
	|-RVA: 0x76708C Offset: 0x76708C VA: 0x76708C
	|-Dictionary.ValueCollection.Enumerator<int, Element<FixtureProxy>>.get_Current
	|-Dictionary.ValueCollection.Enumerator<int, effect_table.Record>.get_Current
	|-Dictionary.ValueCollection.Enumerator<int, gun_data_table.Record>.get_Current
	|-Dictionary.ValueCollection.Enumerator<int, PointerEventData>.get_Current
	|-Dictionary.ValueCollection.Enumerator<int, object>.get_Current
	|
	|-RVA: 0x75A530 Offset: 0x75A530 VA: 0x75A530
	|-Dictionary.ValueCollection.Enumerator<ushort, ToolBase>.get_Current
	|-Dictionary.ValueCollection.Enumerator<ushort, object>.get_Current
	|
	|-RVA: 0x75A734 Offset: 0x75A734 VA: 0x75A734
	|-Dictionary.ValueCollection.Enumerator<uint, BattleZoneData.BattleZoneInfo>.get_Current
	|-Dictionary.ValueCollection.Enumerator<uint, CharacterData>.get_Current
	|-Dictionary.ValueCollection.Enumerator<uint, CombatAreaConfig.CombatArea>.get_Current
	|-Dictionary.ValueCollection.Enumerator<uint, BattlePlayerOccInfo>.get_Current
	|-Dictionary.ValueCollection.Enumerator<uint, List<int>>.get_Current
	|-Dictionary.ValueCollection.Enumerator<uint, object>.get_Current
	|
	|-RVA: 0x75A914 Offset: 0x75A914 VA: 0x75A914
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<EBodyState, EShieldState>, RectTransform>.get_Current
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.get_Current
	|
	|-RVA: 0x759CC0 Offset: 0x759CC0 VA: 0x759CC0
	|-Dictionary.ValueCollection.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.get_Current
	|-Dictionary.ValueCollection.Enumerator<EffectType, List<Action<float>>>.get_Current
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>.get_Current
	|
	|-RVA: 0x7666BC Offset: 0x7666BC VA: 0x7666BC
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.get_Current
	|
	|-RVA: 0x766728 Offset: 0x766728 VA: 0x766728
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>.get_Current
	|
	|-RVA: 0x7667E8 Offset: 0x7667E8 VA: 0x7667E8
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>.get_Current
	|
	|-RVA: 0x766848 Offset: 0x766848 VA: 0x766848
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>.get_Current
	|
	|-RVA: 0x7668AC Offset: 0x7668AC VA: 0x7668AC
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>.get_Current
	|
	|-RVA: 0x766918 Offset: 0x766918 VA: 0x766918
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.get_Current
	|
	|-RVA: 0x766978 Offset: 0x766978 VA: 0x766978
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>.get_Current
	|
	|-RVA: 0x7669D8 Offset: 0x7669D8 VA: 0x7669D8
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.get_Current
	|
	|-RVA: 0x766A38 Offset: 0x766A38 VA: 0x766A38
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>.get_Current
	|
	|-RVA: 0x766A98 Offset: 0x766A98 VA: 0x766A98
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>.get_Current
	|
	|-RVA: 0x766AF8 Offset: 0x766AF8 VA: 0x766AF8
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.get_Current
	|
	|-RVA: 0x766BB8 Offset: 0x766BB8 VA: 0x766BB8
	|-Dictionary.ValueCollection.Enumerator<byte, float>.get_Current
	|
	|-RVA: 0x766C18 Offset: 0x766C18 VA: 0x766C18
	|-Dictionary.ValueCollection.Enumerator<byte, uint>.get_Current
	|
	|-RVA: 0x766C78 Offset: 0x766C78 VA: 0x766C78
	|-Dictionary.ValueCollection.Enumerator<char, object>.get_Current
	|
	|-RVA: 0x766CD8 Offset: 0x766CD8 VA: 0x766CD8
	|-Dictionary.ValueCollection.Enumerator<Guid, object>.get_Current
	|
	|-RVA: 0x766D50 Offset: 0x766D50 VA: 0x766D50
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.get_Current
	|
	|-RVA: 0x766DCC Offset: 0x766DCC VA: 0x766DCC
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>.get_Current
	|
	|-RVA: 0x766E38 Offset: 0x766E38 VA: 0x766E38
	|-Dictionary.ValueCollection.Enumerator<int, bool>.get_Current
	|
	|-RVA: 0x766E98 Offset: 0x766E98 VA: 0x766E98
	|-Dictionary.ValueCollection.Enumerator<int, char>.get_Current
	|
	|-RVA: 0x766EF8 Offset: 0x766EF8 VA: 0x766EF8
	|-Dictionary.ValueCollection.Enumerator<int, int>.get_Current
	|
	|-RVA: 0x766F58 Offset: 0x766F58 VA: 0x766F58
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>.get_Current
	|
	|-RVA: 0x766FBC Offset: 0x766FBC VA: 0x766FBC
	|-Dictionary.ValueCollection.Enumerator<int, long>.get_Current
	|
	|-RVA: 0x767024 Offset: 0x767024 VA: 0x767024
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>.get_Current
	|
	|-RVA: 0x7670EC Offset: 0x7670EC VA: 0x7670EC
	|-Dictionary.ValueCollection.Enumerator<int, float>.get_Current
	|
	|-RVA: 0x76714C Offset: 0x76714C VA: 0x76714C
	|-Dictionary.ValueCollection.Enumerator<int, uint>.get_Current
	|
	|-RVA: 0x7671AC Offset: 0x7671AC VA: 0x7671AC
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>.get_Current
	|
	|-RVA: 0x76720C Offset: 0x76720C VA: 0x76720C
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>.get_Current
	|
	|-RVA: 0x759D20 Offset: 0x759D20 VA: 0x759D20
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>.get_Current
	|
	|-RVA: 0x759D84 Offset: 0x759D84 VA: 0x759D84
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.get_Current
	|
	|-RVA: 0x759DF4 Offset: 0x759DF4 VA: 0x759DF4
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.get_Current
	|
	|-RVA: 0x759E60 Offset: 0x759E60 VA: 0x759E60
	|-Dictionary.ValueCollection.Enumerator<long, int>.get_Current
	|
	|-RVA: 0x759EC0 Offset: 0x759EC0 VA: 0x759EC0
	|-Dictionary.ValueCollection.Enumerator<long, object>.get_Current
	|
	|-RVA: 0x759F20 Offset: 0x759F20 VA: 0x759F20
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>.get_Current
	|
	|-RVA: 0x759F88 Offset: 0x759F88 VA: 0x759F88
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>.get_Current
	|
	|-RVA: 0x759FF4 Offset: 0x759FF4 VA: 0x759FF4
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>.get_Current
	|
	|-RVA: 0x75A068 Offset: 0x75A068 VA: 0x75A068
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.get_Current
	|
	|-RVA: 0x75A0DC Offset: 0x75A0DC VA: 0x75A0DC
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.get_Current
	|
	|-RVA: 0x75A14C Offset: 0x75A14C VA: 0x75A14C
	|-Dictionary.ValueCollection.Enumerator<object, bool>.get_Current
	|
	|-RVA: 0x75A1AC Offset: 0x75A1AC VA: 0x75A1AC
	|-Dictionary.ValueCollection.Enumerator<object, byte>.get_Current
	|
	|-RVA: 0x75A20C Offset: 0x75A20C VA: 0x75A20C
	|-Dictionary.ValueCollection.Enumerator<object, short>.get_Current
	|
	|-RVA: 0x75A26C Offset: 0x75A26C VA: 0x75A26C
	|-Dictionary.ValueCollection.Enumerator<object, int>.get_Current
	|
	|-RVA: 0x75A2CC Offset: 0x75A2CC VA: 0x75A2CC
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>.get_Current
	|
	|-RVA: 0x75A330 Offset: 0x75A330 VA: 0x75A330
	|-Dictionary.ValueCollection.Enumerator<object, long>.get_Current
	|
	|-RVA: 0x75A3F4 Offset: 0x75A3F4 VA: 0x75A3F4
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>.get_Current
	|
	|-RVA: 0x75A460 Offset: 0x75A460 VA: 0x75A460
	|-Dictionary.ValueCollection.Enumerator<object, uint>.get_Current
	|
	|-RVA: 0x75A4C4 Offset: 0x75A4C4 VA: 0x75A4C4
	|-Dictionary.ValueCollection.Enumerator<object, Playable>.get_Current
	|
	|-RVA: 0x75A598 Offset: 0x75A598 VA: 0x75A598
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>.get_Current
	|
	|-RVA: 0x75A608 Offset: 0x75A608 VA: 0x75A608
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.get_Current
	|
	|-RVA: 0x75A674 Offset: 0x75A674 VA: 0x75A674
	|-Dictionary.ValueCollection.Enumerator<uint, byte>.get_Current
	|
	|-RVA: 0x75A6D4 Offset: 0x75A6D4 VA: 0x75A6D4
	|-Dictionary.ValueCollection.Enumerator<uint, int>.get_Current
	|
	|-RVA: 0x75A794 Offset: 0x75A794 VA: 0x75A794
	|-Dictionary.ValueCollection.Enumerator<ulong, object>.get_Current
	|
	|-RVA: 0x75A7F4 Offset: 0x75A7F4 VA: 0x75A7F4
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.get_Current
	|
	|-RVA: 0x75A854 Offset: 0x75A854 VA: 0x75A854
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>.get_Current
	|
	|-RVA: 0x75A8B4 Offset: 0x75A8B4 VA: 0x75A8B4
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.get_Current
	|
	|-RVA: 0x75A974 Offset: 0x75A974 VA: 0x75A974
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>.get_Current
	|
	|-RVA: 0x75A9D4 Offset: 0x75A9D4 VA: 0x75A9D4
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>.get_Current
	|
	|-RVA: 0x75AA34 Offset: 0x75AA34 VA: 0x75AA34
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.get_Current
	|
	|-RVA: 0x75AA94 Offset: 0x75AA94 VA: 0x75AA94
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>.get_Current
	|
	|-RVA: 0x75AAF4 Offset: 0x75AAF4 VA: 0x75AAF4
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>.get_Current
	|
	|-RVA: 0x75AB54 Offset: 0x75AB54 VA: 0x75AB54
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x766660 Offset: 0x766660 VA: 0x766660
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7666D0 Offset: 0x7666D0 VA: 0x7666D0
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766730 Offset: 0x766730 VA: 0x766730
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766790 Offset: 0x766790 VA: 0x766790
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7667F0 Offset: 0x7667F0 VA: 0x7667F0
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766850 Offset: 0x766850 VA: 0x766850
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7668C0 Offset: 0x7668C0 VA: 0x7668C0
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766920 Offset: 0x766920 VA: 0x766920
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766980 Offset: 0x766980 VA: 0x766980
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7669E0 Offset: 0x7669E0 VA: 0x7669E0
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766A40 Offset: 0x766A40 VA: 0x766A40
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766AA0 Offset: 0x766AA0 VA: 0x766AA0
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766B00 Offset: 0x766B00 VA: 0x766B00
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766B60 Offset: 0x766B60 VA: 0x766B60
	|-Dictionary.ValueCollection.Enumerator<byte, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766BC0 Offset: 0x766BC0 VA: 0x766BC0
	|-Dictionary.ValueCollection.Enumerator<byte, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766C20 Offset: 0x766C20 VA: 0x766C20
	|-Dictionary.ValueCollection.Enumerator<byte, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766C80 Offset: 0x766C80 VA: 0x766C80
	|-Dictionary.ValueCollection.Enumerator<char, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766CE0 Offset: 0x766CE0 VA: 0x766CE0
	|-Dictionary.ValueCollection.Enumerator<Guid, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766D70 Offset: 0x766D70 VA: 0x766D70
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766DE0 Offset: 0x766DE0 VA: 0x766DE0
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766E40 Offset: 0x766E40 VA: 0x766E40
	|-Dictionary.ValueCollection.Enumerator<int, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766EA0 Offset: 0x766EA0 VA: 0x766EA0
	|-Dictionary.ValueCollection.Enumerator<int, char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766F00 Offset: 0x766F00 VA: 0x766F00
	|-Dictionary.ValueCollection.Enumerator<int, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766F60 Offset: 0x766F60 VA: 0x766F60
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x766FC4 Offset: 0x766FC4 VA: 0x766FC4
	|-Dictionary.ValueCollection.Enumerator<int, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x767034 Offset: 0x767034 VA: 0x767034
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x767094 Offset: 0x767094 VA: 0x767094
	|-Dictionary.ValueCollection.Enumerator<int, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7670F4 Offset: 0x7670F4 VA: 0x7670F4
	|-Dictionary.ValueCollection.Enumerator<int, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x767154 Offset: 0x767154 VA: 0x767154
	|-Dictionary.ValueCollection.Enumerator<int, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7671B4 Offset: 0x7671B4 VA: 0x7671B4
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x767214 Offset: 0x767214 VA: 0x767214
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759CC8 Offset: 0x759CC8 VA: 0x759CC8
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759D28 Offset: 0x759D28 VA: 0x759D28
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759D98 Offset: 0x759D98 VA: 0x759D98
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759E08 Offset: 0x759E08 VA: 0x759E08
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759E68 Offset: 0x759E68 VA: 0x759E68
	|-Dictionary.ValueCollection.Enumerator<long, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759EC8 Offset: 0x759EC8 VA: 0x759EC8
	|-Dictionary.ValueCollection.Enumerator<long, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759F28 Offset: 0x759F28 VA: 0x759F28
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x759F98 Offset: 0x759F98 VA: 0x759F98
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A008 Offset: 0x75A008 VA: 0x75A008
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A07C Offset: 0x75A07C VA: 0x75A07C
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A0F4 Offset: 0x75A0F4 VA: 0x75A0F4
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A154 Offset: 0x75A154 VA: 0x75A154
	|-Dictionary.ValueCollection.Enumerator<object, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A1B4 Offset: 0x75A1B4 VA: 0x75A1B4
	|-Dictionary.ValueCollection.Enumerator<object, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A214 Offset: 0x75A214 VA: 0x75A214
	|-Dictionary.ValueCollection.Enumerator<object, short>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A274 Offset: 0x75A274 VA: 0x75A274
	|-Dictionary.ValueCollection.Enumerator<object, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A2D4 Offset: 0x75A2D4 VA: 0x75A2D4
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A338 Offset: 0x75A338 VA: 0x75A338
	|-Dictionary.ValueCollection.Enumerator<object, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A398 Offset: 0x75A398 VA: 0x75A398
	|-Dictionary.ValueCollection.Enumerator<object, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A408 Offset: 0x75A408 VA: 0x75A408
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A468 Offset: 0x75A468 VA: 0x75A468
	|-Dictionary.ValueCollection.Enumerator<object, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A4D8 Offset: 0x75A4D8 VA: 0x75A4D8
	|-Dictionary.ValueCollection.Enumerator<object, Playable>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A538 Offset: 0x75A538 VA: 0x75A538
	|-Dictionary.ValueCollection.Enumerator<ushort, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A5A8 Offset: 0x75A5A8 VA: 0x75A5A8
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A61C Offset: 0x75A61C VA: 0x75A61C
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A67C Offset: 0x75A67C VA: 0x75A67C
	|-Dictionary.ValueCollection.Enumerator<uint, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A6DC Offset: 0x75A6DC VA: 0x75A6DC
	|-Dictionary.ValueCollection.Enumerator<uint, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A73C Offset: 0x75A73C VA: 0x75A73C
	|-Dictionary.ValueCollection.Enumerator<uint, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A79C Offset: 0x75A79C VA: 0x75A79C
	|-Dictionary.ValueCollection.Enumerator<ulong, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A7FC Offset: 0x75A7FC VA: 0x75A7FC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A85C Offset: 0x75A85C VA: 0x75A85C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A8BC Offset: 0x75A8BC VA: 0x75A8BC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A91C Offset: 0x75A91C VA: 0x75A91C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A97C Offset: 0x75A97C VA: 0x75A97C
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75A9DC Offset: 0x75A9DC VA: 0x75A9DC
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75AA3C Offset: 0x75AA3C VA: 0x75AA3C
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75AA9C Offset: 0x75AA9C VA: 0x75AA9C
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75AAFC Offset: 0x75AAFC VA: 0x75AAFC
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75AB5C Offset: 0x75AB5C VA: 0x75AB5C
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x766668 Offset: 0x766668 VA: 0x766668
	|-Dictionary.ValueCollection.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7666D8 Offset: 0x7666D8 VA: 0x7666D8
	|-Dictionary.ValueCollection.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766738 Offset: 0x766738 VA: 0x766738
	|-Dictionary.ValueCollection.Enumerator<U64Id, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766798 Offset: 0x766798 VA: 0x766798
	|-Dictionary.ValueCollection.Enumerator<U64Id, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7667F8 Offset: 0x7667F8 VA: 0x7667F8
	|-Dictionary.ValueCollection.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766858 Offset: 0x766858 VA: 0x766858
	|-Dictionary.ValueCollection.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7668C8 Offset: 0x7668C8 VA: 0x7668C8
	|-Dictionary.ValueCollection.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766928 Offset: 0x766928 VA: 0x766928
	|-Dictionary.ValueCollection.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766988 Offset: 0x766988 VA: 0x766988
	|-Dictionary.ValueCollection.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7669E8 Offset: 0x7669E8 VA: 0x7669E8
	|-Dictionary.ValueCollection.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766A48 Offset: 0x766A48 VA: 0x766A48
	|-Dictionary.ValueCollection.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766AA8 Offset: 0x766AA8 VA: 0x766AA8
	|-Dictionary.ValueCollection.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766B08 Offset: 0x766B08 VA: 0x766B08
	|-Dictionary.ValueCollection.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766B68 Offset: 0x766B68 VA: 0x766B68
	|-Dictionary.ValueCollection.Enumerator<byte, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766BC8 Offset: 0x766BC8 VA: 0x766BC8
	|-Dictionary.ValueCollection.Enumerator<byte, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766C28 Offset: 0x766C28 VA: 0x766C28
	|-Dictionary.ValueCollection.Enumerator<byte, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766C88 Offset: 0x766C88 VA: 0x766C88
	|-Dictionary.ValueCollection.Enumerator<char, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766CE8 Offset: 0x766CE8 VA: 0x766CE8
	|-Dictionary.ValueCollection.Enumerator<Guid, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766D78 Offset: 0x766D78 VA: 0x766D78
	|-Dictionary.ValueCollection.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766DE8 Offset: 0x766DE8 VA: 0x766DE8
	|-Dictionary.ValueCollection.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766E48 Offset: 0x766E48 VA: 0x766E48
	|-Dictionary.ValueCollection.Enumerator<int, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766EA8 Offset: 0x766EA8 VA: 0x766EA8
	|-Dictionary.ValueCollection.Enumerator<int, char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766F08 Offset: 0x766F08 VA: 0x766F08
	|-Dictionary.ValueCollection.Enumerator<int, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766F68 Offset: 0x766F68 VA: 0x766F68
	|-Dictionary.ValueCollection.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x766FCC Offset: 0x766FCC VA: 0x766FCC
	|-Dictionary.ValueCollection.Enumerator<int, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x76703C Offset: 0x76703C VA: 0x76703C
	|-Dictionary.ValueCollection.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x76709C Offset: 0x76709C VA: 0x76709C
	|-Dictionary.ValueCollection.Enumerator<int, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7670FC Offset: 0x7670FC VA: 0x7670FC
	|-Dictionary.ValueCollection.Enumerator<int, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x76715C Offset: 0x76715C VA: 0x76715C
	|-Dictionary.ValueCollection.Enumerator<int, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7671BC Offset: 0x7671BC VA: 0x7671BC
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x76721C Offset: 0x76721C VA: 0x76721C
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759CD0 Offset: 0x759CD0 VA: 0x759CD0
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759D30 Offset: 0x759D30 VA: 0x759D30
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759DA0 Offset: 0x759DA0 VA: 0x759DA0
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759E10 Offset: 0x759E10 VA: 0x759E10
	|-Dictionary.ValueCollection.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759E70 Offset: 0x759E70 VA: 0x759E70
	|-Dictionary.ValueCollection.Enumerator<long, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759ED0 Offset: 0x759ED0 VA: 0x759ED0
	|-Dictionary.ValueCollection.Enumerator<long, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759F30 Offset: 0x759F30 VA: 0x759F30
	|-Dictionary.ValueCollection.Enumerator<IntPtr, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x759FA0 Offset: 0x759FA0 VA: 0x759FA0
	|-Dictionary.ValueCollection.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A010 Offset: 0x75A010 VA: 0x75A010
	|-Dictionary.ValueCollection.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A084 Offset: 0x75A084 VA: 0x75A084
	|-Dictionary.ValueCollection.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A0FC Offset: 0x75A0FC VA: 0x75A0FC
	|-Dictionary.ValueCollection.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A15C Offset: 0x75A15C VA: 0x75A15C
	|-Dictionary.ValueCollection.Enumerator<object, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A1BC Offset: 0x75A1BC VA: 0x75A1BC
	|-Dictionary.ValueCollection.Enumerator<object, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A21C Offset: 0x75A21C VA: 0x75A21C
	|-Dictionary.ValueCollection.Enumerator<object, short>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A27C Offset: 0x75A27C VA: 0x75A27C
	|-Dictionary.ValueCollection.Enumerator<object, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A2DC Offset: 0x75A2DC VA: 0x75A2DC
	|-Dictionary.ValueCollection.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A340 Offset: 0x75A340 VA: 0x75A340
	|-Dictionary.ValueCollection.Enumerator<object, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A3A0 Offset: 0x75A3A0 VA: 0x75A3A0
	|-Dictionary.ValueCollection.Enumerator<object, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A410 Offset: 0x75A410 VA: 0x75A410
	|-Dictionary.ValueCollection.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A470 Offset: 0x75A470 VA: 0x75A470
	|-Dictionary.ValueCollection.Enumerator<object, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A4E0 Offset: 0x75A4E0 VA: 0x75A4E0
	|-Dictionary.ValueCollection.Enumerator<object, Playable>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A540 Offset: 0x75A540 VA: 0x75A540
	|-Dictionary.ValueCollection.Enumerator<ushort, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A5B0 Offset: 0x75A5B0 VA: 0x75A5B0
	|-Dictionary.ValueCollection.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A624 Offset: 0x75A624 VA: 0x75A624
	|-Dictionary.ValueCollection.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A684 Offset: 0x75A684 VA: 0x75A684
	|-Dictionary.ValueCollection.Enumerator<uint, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A6E4 Offset: 0x75A6E4 VA: 0x75A6E4
	|-Dictionary.ValueCollection.Enumerator<uint, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A744 Offset: 0x75A744 VA: 0x75A744
	|-Dictionary.ValueCollection.Enumerator<uint, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A7A4 Offset: 0x75A7A4 VA: 0x75A7A4
	|-Dictionary.ValueCollection.Enumerator<ulong, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A804 Offset: 0x75A804 VA: 0x75A804
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A864 Offset: 0x75A864 VA: 0x75A864
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A8C4 Offset: 0x75A8C4 VA: 0x75A8C4
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A924 Offset: 0x75A924 VA: 0x75A924
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A984 Offset: 0x75A984 VA: 0x75A984
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75A9E4 Offset: 0x75A9E4 VA: 0x75A9E4
	|-Dictionary.ValueCollection.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75AA44 Offset: 0x75AA44 VA: 0x75AA44
	|-Dictionary.ValueCollection.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75AAA4 Offset: 0x75AAA4 VA: 0x75AAA4
	|-Dictionary.ValueCollection.Enumerator<Vector3, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75AB04 Offset: 0x75AB04 VA: 0x75AB04
	|-Dictionary.ValueCollection.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75AB64 Offset: 0x75AB64 VA: 0x75AB64
	|-Dictionary.ValueCollection.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.Reset
	*/
}
