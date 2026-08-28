// Namespace: 
[DebuggerDisplayAttribute] // RVA: 0x4DEB08 Offset: 0x4DEB08 VA: 0x4DEB08
[DebuggerTypeProxyAttribute] // RVA: 0x4DEB08 Offset: 0x4DEB08 VA: 0x4DEB08
[Serializable]
public sealed class Dictionary.ValueCollection<TKey, TValue> : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue> // TypeDefIndex: 1420
{
	// Fields
	private Dictionary<TKey, TValue> dictionary; // 0x0

	// Properties
	public int Count { get; }
	private bool System.Collections.Generic.ICollection<TValue>.IsReadOnly { get; }
	private bool System.Collections.ICollection.IsSynchronized { get; }
	private object System.Collections.ICollection.SyncRoot { get; }

	// Methods

	// RVA: -1 Offset: -1
	public void .ctor(Dictionary<TKey, TValue> dictionary) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F6DC0 Offset: 0x11F6DC0 VA: 0x11F6DC0
	|-Dictionary.ValueCollection<EntityID, Entity>..ctor
	|
	|-RVA: 0x11F7BAC Offset: 0x11F7BAC VA: 0x11F7BAC
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>..ctor
	|
	|-RVA: 0x11F89A0 Offset: 0x11F89A0 VA: 0x11F89A0
	|-Dictionary.ValueCollection<U64Id, int>..ctor
	|
	|-RVA: 0x11F9734 Offset: 0x11F9734 VA: 0x11F9734
	|-Dictionary.ValueCollection<U64Id, object>..ctor
	|
	|-RVA: 0x11FA47C Offset: 0x11FA47C VA: 0x11FA47C
	|-Dictionary.ValueCollection<LeaderBoardType, object>..ctor
	|
	|-RVA: 0x11FB1C4 Offset: 0x11FB1C4 VA: 0x11FB1C4
	|-Dictionary.ValueCollection<TranslateEvent, object>..ctor
	|
	|-RVA: 0x11FBF04 Offset: 0x11FBF04 VA: 0x11FBF04
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>..ctor
	|
	|-RVA: 0x11FCCF8 Offset: 0x11FCCF8 VA: 0x11FCCF8
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>..ctor
	|
	|-RVA: 0x11FDA40 Offset: 0x11FDA40 VA: 0x11FDA40
	|-Dictionary.ValueCollection<ResolverContractKey, object>..ctor
	|
	|-RVA: 0x11FE788 Offset: 0x11FE788 VA: 0x11FE788
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>..ctor
	|
	|-RVA: 0x11FF4D0 Offset: 0x11FF4D0 VA: 0x11FF4D0
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>..ctor
	|
	|-RVA: 0x1200264 Offset: 0x1200264 VA: 0x1200264
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>..ctor
	|
	|-RVA: 0x1200FAC Offset: 0x1200FAC VA: 0x1200FAC
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>..ctor
	|
	|-RVA: 0x1201CF4 Offset: 0x1201CF4 VA: 0x1201CF4
	|-Dictionary.ValueCollection<byte, object>..ctor
	|
	|-RVA: 0x1202A34 Offset: 0x1202A34 VA: 0x1202A34
	|-Dictionary.ValueCollection<byte, float>..ctor
	|
	|-RVA: 0x12037BC Offset: 0x12037BC VA: 0x12037BC
	|-Dictionary.ValueCollection<byte, uint>..ctor
	|
	|-RVA: 0x1204544 Offset: 0x1204544 VA: 0x1204544
	|-Dictionary.ValueCollection<char, object>..ctor
	|
	|-RVA: 0x1205284 Offset: 0x1205284 VA: 0x1205284
	|-Dictionary.ValueCollection<Guid, object>..ctor
	|
	|-RVA: 0x1205FCC Offset: 0x1205FCC VA: 0x1205FCC
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>..ctor
	|
	|-RVA: 0x1206E94 Offset: 0x1206E94 VA: 0x1206E94
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>..ctor
	|
	|-RVA: 0x1D55BA0 Offset: 0x1D55BA0 VA: 0x1D55BA0
	|-Dictionary.ValueCollection<int, bool>..ctor
	|
	|-RVA: 0x1D56928 Offset: 0x1D56928 VA: 0x1D56928
	|-Dictionary.ValueCollection<int, char>..ctor
	|
	|-RVA: 0x1D576BC Offset: 0x1D576BC VA: 0x1D576BC
	|-Dictionary.ValueCollection<int, int>..ctor
	|
	|-RVA: 0x1D58444 Offset: 0x1D58444 VA: 0x1D58444
	|-Dictionary.ValueCollection<int, Int32Enum>..ctor
	|
	|-RVA: 0x1D591CC Offset: 0x1D591CC VA: 0x1D591CC
	|-Dictionary.ValueCollection<int, long>..ctor
	|
	|-RVA: 0x1D59FD4 Offset: 0x1D59FD4 VA: 0x1D59FD4
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>..ctor
	|
	|-RVA: 0x1D5ADCC Offset: 0x1D5ADCC VA: 0x1D5ADCC
	|-Dictionary.ValueCollection<int, object>..ctor
	|
	|-RVA: 0x1D5BB0C Offset: 0x1D5BB0C VA: 0x1D5BB0C
	|-Dictionary.ValueCollection<int, float>..ctor
	|
	|-RVA: 0x1D5C894 Offset: 0x1D5C894 VA: 0x1D5C894
	|-Dictionary.ValueCollection<int, uint>..ctor
	|
	|-RVA: 0x1D5D61C Offset: 0x1D5D61C VA: 0x1D5D61C
	|-Dictionary.ValueCollection<Int32Enum, bool>..ctor
	|
	|-RVA: 0x1D5E3A4 Offset: 0x1D5E3A4 VA: 0x1D5E3A4
	|-Dictionary.ValueCollection<Int32Enum, int>..ctor
	|
	|-RVA: 0x1D5F12C Offset: 0x1D5F12C VA: 0x1D5F12C
	|-Dictionary.ValueCollection<Int32Enum, object>..ctor
	|
	|-RVA: 0x1D5FE6C Offset: 0x1D5FE6C VA: 0x1D5FE6C
	|-Dictionary.ValueCollection<Int32Enum, uint>..ctor
	|
	|-RVA: 0x1D60BF4 Offset: 0x1D60BF4 VA: 0x1D60BF4
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>..ctor
	|
	|-RVA: 0x1D619E8 Offset: 0x1D619E8 VA: 0x1D619E8
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>..ctor
	|
	|-RVA: 0x1D627DC Offset: 0x1D627DC VA: 0x1D627DC
	|-Dictionary.ValueCollection<long, int>..ctor
	|
	|-RVA: 0x1D63570 Offset: 0x1D63570 VA: 0x1D63570
	|-Dictionary.ValueCollection<long, object>..ctor
	|
	|-RVA: 0x1D642B8 Offset: 0x1D642B8 VA: 0x1D642B8
	|-Dictionary.ValueCollection<IntPtr, object>..ctor
	|
	|-RVA: 0x1D64FF8 Offset: 0x1D64FF8 VA: 0x1D64FF8
	|-Dictionary.ValueCollection<object, CommandInfo>..ctor
	|
	|-RVA: 0x1D65DF8 Offset: 0x1D65DF8 VA: 0x1D65DF8
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>..ctor
	|
	|-RVA: 0x1D66BEC Offset: 0x1D66BEC VA: 0x1D66BEC
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>..ctor
	|
	|-RVA: 0x1D67A10 Offset: 0x1D67A10 VA: 0x1D67A10
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>..ctor
	|
	|-RVA: 0x1D68868 Offset: 0x1D68868 VA: 0x1D68868
	|-Dictionary.ValueCollection<object, bool>..ctor
	|
	|-RVA: 0x1D695F0 Offset: 0x1D695F0 VA: 0x1D695F0
	|-Dictionary.ValueCollection<object, byte>..ctor
	|
	|-RVA: 0x1D6A378 Offset: 0x1D6A378 VA: 0x1D6A378
	|-Dictionary.ValueCollection<object, short>..ctor
	|
	|-RVA: 0x1D6B10C Offset: 0x1D6B10C VA: 0x1D6B10C
	|-Dictionary.ValueCollection<object, int>..ctor
	|
	|-RVA: 0x1D6BE94 Offset: 0x1D6BE94 VA: 0x1D6BE94
	|-Dictionary.ValueCollection<object, Int32Enum>..ctor
	|
	|-RVA: 0x1D6CC1C Offset: 0x1D6CC1C VA: 0x1D6CC1C
	|-Dictionary.ValueCollection<object, long>..ctor
	|
	|-RVA: 0x1D6DA24 Offset: 0x1D6DA24 VA: 0x1D6DA24
	|-Dictionary.ValueCollection<object, object>..ctor
	|
	|-RVA: 0x1D6E764 Offset: 0x1D6E764 VA: 0x1D6E764
	|-Dictionary.ValueCollection<object, ResourceLocator>..ctor
	|
	|-RVA: 0x1D6F558 Offset: 0x1D6F558 VA: 0x1D6F558
	|-Dictionary.ValueCollection<object, uint>..ctor
	|
	|-RVA: 0x1D702E0 Offset: 0x1D702E0 VA: 0x1D702E0
	|-Dictionary.ValueCollection<object, Playable>..ctor
	|
	|-RVA: 0x1D710D4 Offset: 0x1D710D4 VA: 0x1D710D4
	|-Dictionary.ValueCollection<ushort, object>..ctor
	|
	|-RVA: 0x1D71E14 Offset: 0x1D71E14 VA: 0x1D71E14
	|-Dictionary.ValueCollection<uint, CustomValue>..ctor
	|
	|-RVA: 0x1D72C14 Offset: 0x1D72C14 VA: 0x1D72C14
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>..ctor
	|
	|-RVA: 0x201D634 Offset: 0x201D634 VA: 0x201D634
	|-Dictionary.ValueCollection<uint, byte>..ctor
	|
	|-RVA: 0x201E3BC Offset: 0x201E3BC VA: 0x201E3BC
	|-Dictionary.ValueCollection<uint, int>..ctor
	|
	|-RVA: 0x201F144 Offset: 0x201F144 VA: 0x201F144
	|-Dictionary.ValueCollection<uint, object>..ctor
	|
	|-RVA: 0x201FE84 Offset: 0x201FE84 VA: 0x201FE84
	|-Dictionary.ValueCollection<ulong, object>..ctor
	|
	|-RVA: 0x2020BCC Offset: 0x2020BCC VA: 0x2020BCC
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>..ctor
	|
	|-RVA: 0x2021954 Offset: 0x2021954 VA: 0x2021954
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>..ctor
	|
	|-RVA: 0x202269C Offset: 0x202269C VA: 0x202269C
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>..ctor
	|
	|-RVA: 0x2023430 Offset: 0x2023430 VA: 0x2023430
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>..ctor
	|
	|-RVA: 0x2024178 Offset: 0x2024178 VA: 0x2024178
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>..ctor
	|
	|-RVA: 0x2024EC0 Offset: 0x2024EC0 VA: 0x2024EC0
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>..ctor
	|
	|-RVA: 0x2025C08 Offset: 0x2025C08 VA: 0x2025C08
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>..ctor
	|
	|-RVA: 0x2026950 Offset: 0x2026950 VA: 0x2026950
	|-Dictionary.ValueCollection<Vector3, int>..ctor
	|
	|-RVA: 0x20276E4 Offset: 0x20276E4 VA: 0x20276E4
	|-Dictionary.ValueCollection<Utils.MethodKey, object>..ctor
	|
	|-RVA: 0x202842C Offset: 0x202842C VA: 0x202842C
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>..ctor
	*/

	// RVA: -1 Offset: -1
	public Dictionary.ValueCollection.Enumerator<TKey, TValue> GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F6E8C Offset: 0x11F6E8C VA: 0x11F6E8C
	|-Dictionary.ValueCollection<EntityID, Entity>.GetEnumerator
	|
	|-RVA: 0x11F9800 Offset: 0x11F9800 VA: 0x11F9800
	|-Dictionary.ValueCollection<U64Id, IDisturbEntity>.GetEnumerator
	|-Dictionary.ValueCollection<U64Id, ScoutCar>.GetEnumerator
	|-Dictionary.ValueCollection<U64Id, object>.GetEnumerator
	|
	|-RVA: 0x1D6DAF0 Offset: 0x1D6DAF0 VA: 0x1D6DAF0
	|-Dictionary.ValueCollection<LightweightTriggerBase, IBlockingBoard>.GetEnumerator
	|-Dictionary.ValueCollection<Bone, Transform>.GetEnumerator
	|-Dictionary.ValueCollection<BoundingBoxAttachment, PolygonCollider2D>.GetEnumerator
	|-Dictionary.ValueCollection<string, DtdParser.UndeclaredNotation>.GetEnumerator
	|-Dictionary.ValueCollection<string, SchemaNotation>.GetEnumerator
	|-Dictionary.ValueCollection<string, GUIStyle>.GetEnumerator
	|-Dictionary.ValueCollection<string, AliasValueDeserializer.ValuePromise>.GetEnumerator
	|-Dictionary.ValueCollection<Type, PostProcessBundle>.GetEnumerator
	|-Dictionary.ValueCollection<XmlQualifiedName, SchemaAttDef>.GetEnumerator
	|-Dictionary.ValueCollection<XmlQualifiedName, SchemaElementDecl>.GetEnumerator
	|-Dictionary.ValueCollection<XmlQualifiedName, SchemaEntity>.GetEnumerator
	|-Dictionary.ValueCollection<GameObject, List<GameObject>>.GetEnumerator
	|-Dictionary.ValueCollection<GameObject, GameObject>.GetEnumerator
	|-Dictionary.ValueCollection<Material, Material>.GetEnumerator
	|-Dictionary.ValueCollection<Shader, PropertySheet>.GetEnumerator
	|-Dictionary.ValueCollection<object, object>.GetEnumerator
	|
	|-RVA: 0x1201DC0 Offset: 0x1201DC0 VA: 0x1201DC0
	|-Dictionary.ValueCollection<byte, RemoteCharacterController>.GetEnumerator
	|-Dictionary.ValueCollection<byte, List<int>>.GetEnumerator
	|-Dictionary.ValueCollection<byte, object>.GetEnumerator
	|
	|-RVA: 0x1D5AE98 Offset: 0x1D5AE98 VA: 0x1D5AE98
	|-Dictionary.ValueCollection<int, Element<FixtureProxy>>.GetEnumerator
	|-Dictionary.ValueCollection<int, effect_table.Record>.GetEnumerator
	|-Dictionary.ValueCollection<int, gun_data_table.Record>.GetEnumerator
	|-Dictionary.ValueCollection<int, PointerEventData>.GetEnumerator
	|-Dictionary.ValueCollection<int, object>.GetEnumerator
	|
	|-RVA: 0x1D711A0 Offset: 0x1D711A0 VA: 0x1D711A0
	|-Dictionary.ValueCollection<ushort, ToolBase>.GetEnumerator
	|-Dictionary.ValueCollection<ushort, object>.GetEnumerator
	|
	|-RVA: 0x201F210 Offset: 0x201F210 VA: 0x201F210
	|-Dictionary.ValueCollection<uint, BattleZoneData.BattleZoneInfo>.GetEnumerator
	|-Dictionary.ValueCollection<uint, CharacterData>.GetEnumerator
	|-Dictionary.ValueCollection<uint, CombatAreaConfig.CombatArea>.GetEnumerator
	|-Dictionary.ValueCollection<uint, BattlePlayerOccInfo>.GetEnumerator
	|-Dictionary.ValueCollection<uint, List<int>>.GetEnumerator
	|-Dictionary.ValueCollection<uint, object>.GetEnumerator
	|
	|-RVA: 0x20234FC Offset: 0x20234FC VA: 0x20234FC
	|-Dictionary.ValueCollection<ValueTuple<EBodyState, EShieldState>, RectTransform>.GetEnumerator
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.GetEnumerator
	|
	|-RVA: 0x1D5F1F8 Offset: 0x1D5F1F8 VA: 0x1D5F1F8
	|-Dictionary.ValueCollection<UIBattleFPControl.ESkillBtnEnum, SkillButton>.GetEnumerator
	|-Dictionary.ValueCollection<EffectType, List<Action<float>>>.GetEnumerator
	|-Dictionary.ValueCollection<Int32Enum, object>.GetEnumerator
	|
	|-RVA: 0x11F7C78 Offset: 0x11F7C78 VA: 0x11F7C78
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.GetEnumerator
	|
	|-RVA: 0x11F8A6C Offset: 0x11F8A6C VA: 0x11F8A6C
	|-Dictionary.ValueCollection<U64Id, int>.GetEnumerator
	|
	|-RVA: 0x11FA548 Offset: 0x11FA548 VA: 0x11FA548
	|-Dictionary.ValueCollection<LeaderBoardType, object>.GetEnumerator
	|
	|-RVA: 0x11FB290 Offset: 0x11FB290 VA: 0x11FB290
	|-Dictionary.ValueCollection<TranslateEvent, object>.GetEnumerator
	|
	|-RVA: 0x11FBFD0 Offset: 0x11FBFD0 VA: 0x11FBFD0
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.GetEnumerator
	|
	|-RVA: 0x11FCDC4 Offset: 0x11FCDC4 VA: 0x11FCDC4
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.GetEnumerator
	|
	|-RVA: 0x11FDB0C Offset: 0x11FDB0C VA: 0x11FDB0C
	|-Dictionary.ValueCollection<ResolverContractKey, object>.GetEnumerator
	|
	|-RVA: 0x11FE854 Offset: 0x11FE854 VA: 0x11FE854
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.GetEnumerator
	|
	|-RVA: 0x11FF59C Offset: 0x11FF59C VA: 0x11FF59C
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.GetEnumerator
	|
	|-RVA: 0x1200330 Offset: 0x1200330 VA: 0x1200330
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.GetEnumerator
	|
	|-RVA: 0x1201078 Offset: 0x1201078 VA: 0x1201078
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.GetEnumerator
	|
	|-RVA: 0x1202B00 Offset: 0x1202B00 VA: 0x1202B00
	|-Dictionary.ValueCollection<byte, float>.GetEnumerator
	|
	|-RVA: 0x1203888 Offset: 0x1203888 VA: 0x1203888
	|-Dictionary.ValueCollection<byte, uint>.GetEnumerator
	|
	|-RVA: 0x1204610 Offset: 0x1204610 VA: 0x1204610
	|-Dictionary.ValueCollection<char, object>.GetEnumerator
	|
	|-RVA: 0x1205350 Offset: 0x1205350 VA: 0x1205350
	|-Dictionary.ValueCollection<Guid, object>.GetEnumerator
	|
	|-RVA: 0x1206098 Offset: 0x1206098 VA: 0x1206098
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.GetEnumerator
	|
	|-RVA: 0x1206F60 Offset: 0x1206F60 VA: 0x1206F60
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.GetEnumerator
	|
	|-RVA: 0x1D55C6C Offset: 0x1D55C6C VA: 0x1D55C6C
	|-Dictionary.ValueCollection<int, bool>.GetEnumerator
	|
	|-RVA: 0x1D569F4 Offset: 0x1D569F4 VA: 0x1D569F4
	|-Dictionary.ValueCollection<int, char>.GetEnumerator
	|
	|-RVA: 0x1D57788 Offset: 0x1D57788 VA: 0x1D57788
	|-Dictionary.ValueCollection<int, int>.GetEnumerator
	|
	|-RVA: 0x1D58510 Offset: 0x1D58510 VA: 0x1D58510
	|-Dictionary.ValueCollection<int, Int32Enum>.GetEnumerator
	|
	|-RVA: 0x1D59298 Offset: 0x1D59298 VA: 0x1D59298
	|-Dictionary.ValueCollection<int, long>.GetEnumerator
	|
	|-RVA: 0x1D5A0A0 Offset: 0x1D5A0A0 VA: 0x1D5A0A0
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.GetEnumerator
	|
	|-RVA: 0x1D5BBD8 Offset: 0x1D5BBD8 VA: 0x1D5BBD8
	|-Dictionary.ValueCollection<int, float>.GetEnumerator
	|
	|-RVA: 0x1D5C960 Offset: 0x1D5C960 VA: 0x1D5C960
	|-Dictionary.ValueCollection<int, uint>.GetEnumerator
	|
	|-RVA: 0x1D5D6E8 Offset: 0x1D5D6E8 VA: 0x1D5D6E8
	|-Dictionary.ValueCollection<Int32Enum, bool>.GetEnumerator
	|
	|-RVA: 0x1D5E470 Offset: 0x1D5E470 VA: 0x1D5E470
	|-Dictionary.ValueCollection<Int32Enum, int>.GetEnumerator
	|
	|-RVA: 0x1D5FF38 Offset: 0x1D5FF38 VA: 0x1D5FF38
	|-Dictionary.ValueCollection<Int32Enum, uint>.GetEnumerator
	|
	|-RVA: 0x1D60CC0 Offset: 0x1D60CC0 VA: 0x1D60CC0
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.GetEnumerator
	|
	|-RVA: 0x1D61AB4 Offset: 0x1D61AB4 VA: 0x1D61AB4
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.GetEnumerator
	|
	|-RVA: 0x1D628A8 Offset: 0x1D628A8 VA: 0x1D628A8
	|-Dictionary.ValueCollection<long, int>.GetEnumerator
	|
	|-RVA: 0x1D6363C Offset: 0x1D6363C VA: 0x1D6363C
	|-Dictionary.ValueCollection<long, object>.GetEnumerator
	|
	|-RVA: 0x1D64384 Offset: 0x1D64384 VA: 0x1D64384
	|-Dictionary.ValueCollection<IntPtr, object>.GetEnumerator
	|
	|-RVA: 0x1D650C4 Offset: 0x1D650C4 VA: 0x1D650C4
	|-Dictionary.ValueCollection<object, CommandInfo>.GetEnumerator
	|
	|-RVA: 0x1D65EC4 Offset: 0x1D65EC4 VA: 0x1D65EC4
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.GetEnumerator
	|
	|-RVA: 0x1D66CB8 Offset: 0x1D66CB8 VA: 0x1D66CB8
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.GetEnumerator
	|
	|-RVA: 0x1D67ADC Offset: 0x1D67ADC VA: 0x1D67ADC
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.GetEnumerator
	|
	|-RVA: 0x1D68934 Offset: 0x1D68934 VA: 0x1D68934
	|-Dictionary.ValueCollection<object, bool>.GetEnumerator
	|
	|-RVA: 0x1D696BC Offset: 0x1D696BC VA: 0x1D696BC
	|-Dictionary.ValueCollection<object, byte>.GetEnumerator
	|
	|-RVA: 0x1D6A444 Offset: 0x1D6A444 VA: 0x1D6A444
	|-Dictionary.ValueCollection<object, short>.GetEnumerator
	|
	|-RVA: 0x1D6B1D8 Offset: 0x1D6B1D8 VA: 0x1D6B1D8
	|-Dictionary.ValueCollection<object, int>.GetEnumerator
	|
	|-RVA: 0x1D6BF60 Offset: 0x1D6BF60 VA: 0x1D6BF60
	|-Dictionary.ValueCollection<object, Int32Enum>.GetEnumerator
	|
	|-RVA: 0x1D6CCE8 Offset: 0x1D6CCE8 VA: 0x1D6CCE8
	|-Dictionary.ValueCollection<object, long>.GetEnumerator
	|
	|-RVA: 0x1D6E830 Offset: 0x1D6E830 VA: 0x1D6E830
	|-Dictionary.ValueCollection<object, ResourceLocator>.GetEnumerator
	|
	|-RVA: 0x1D6F624 Offset: 0x1D6F624 VA: 0x1D6F624
	|-Dictionary.ValueCollection<object, uint>.GetEnumerator
	|
	|-RVA: 0x1D703AC Offset: 0x1D703AC VA: 0x1D703AC
	|-Dictionary.ValueCollection<object, Playable>.GetEnumerator
	|
	|-RVA: 0x1D71EE0 Offset: 0x1D71EE0 VA: 0x1D71EE0
	|-Dictionary.ValueCollection<uint, CustomValue>.GetEnumerator
	|
	|-RVA: 0x1D72CE0 Offset: 0x1D72CE0 VA: 0x1D72CE0
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.GetEnumerator
	|
	|-RVA: 0x201D700 Offset: 0x201D700 VA: 0x201D700
	|-Dictionary.ValueCollection<uint, byte>.GetEnumerator
	|
	|-RVA: 0x201E488 Offset: 0x201E488 VA: 0x201E488
	|-Dictionary.ValueCollection<uint, int>.GetEnumerator
	|
	|-RVA: 0x201FF50 Offset: 0x201FF50 VA: 0x201FF50
	|-Dictionary.ValueCollection<ulong, object>.GetEnumerator
	|
	|-RVA: 0x2020C98 Offset: 0x2020C98 VA: 0x2020C98
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.GetEnumerator
	|
	|-RVA: 0x2021A20 Offset: 0x2021A20 VA: 0x2021A20
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.GetEnumerator
	|
	|-RVA: 0x2022768 Offset: 0x2022768 VA: 0x2022768
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.GetEnumerator
	|
	|-RVA: 0x2024244 Offset: 0x2024244 VA: 0x2024244
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.GetEnumerator
	|
	|-RVA: 0x2024F8C Offset: 0x2024F8C VA: 0x2024F8C
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.GetEnumerator
	|
	|-RVA: 0x2025CD4 Offset: 0x2025CD4 VA: 0x2025CD4
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.GetEnumerator
	|
	|-RVA: 0x2026A1C Offset: 0x2026A1C VA: 0x2026A1C
	|-Dictionary.ValueCollection<Vector3, int>.GetEnumerator
	|
	|-RVA: 0x20277B0 Offset: 0x20277B0 VA: 0x20277B0
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.GetEnumerator
	|
	|-RVA: 0x20284F8 Offset: 0x20284F8 VA: 0x20284F8
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 9
	public void CopyTo(TValue[] array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F6EC0 Offset: 0x11F6EC0 VA: 0x11F6EC0
	|-Dictionary.ValueCollection<EntityID, Entity>.CopyTo
	|
	|-RVA: 0x11F7CAC Offset: 0x11F7CAC VA: 0x11F7CAC
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.CopyTo
	|
	|-RVA: 0x11F8A94 Offset: 0x11F8A94 VA: 0x11F8A94
	|-Dictionary.ValueCollection<U64Id, int>.CopyTo
	|
	|-RVA: 0x11F9828 Offset: 0x11F9828 VA: 0x11F9828
	|-Dictionary.ValueCollection<U64Id, object>.CopyTo
	|
	|-RVA: 0x11FA570 Offset: 0x11FA570 VA: 0x11FA570
	|-Dictionary.ValueCollection<LeaderBoardType, object>.CopyTo
	|
	|-RVA: 0x11FB2B8 Offset: 0x11FB2B8 VA: 0x11FB2B8
	|-Dictionary.ValueCollection<TranslateEvent, object>.CopyTo
	|
	|-RVA: 0x11FC004 Offset: 0x11FC004 VA: 0x11FC004
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.CopyTo
	|
	|-RVA: 0x11FCDEC Offset: 0x11FCDEC VA: 0x11FCDEC
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.CopyTo
	|
	|-RVA: 0x11FDB34 Offset: 0x11FDB34 VA: 0x11FDB34
	|-Dictionary.ValueCollection<ResolverContractKey, object>.CopyTo
	|
	|-RVA: 0x11FE87C Offset: 0x11FE87C VA: 0x11FE87C
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.CopyTo
	|
	|-RVA: 0x11FF5C4 Offset: 0x11FF5C4 VA: 0x11FF5C4
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.CopyTo
	|
	|-RVA: 0x1200358 Offset: 0x1200358 VA: 0x1200358
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.CopyTo
	|
	|-RVA: 0x12010A0 Offset: 0x12010A0 VA: 0x12010A0
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.CopyTo
	|
	|-RVA: 0x1201DE8 Offset: 0x1201DE8 VA: 0x1201DE8
	|-Dictionary.ValueCollection<byte, object>.CopyTo
	|
	|-RVA: 0x1202B28 Offset: 0x1202B28 VA: 0x1202B28
	|-Dictionary.ValueCollection<byte, float>.CopyTo
	|
	|-RVA: 0x12038B0 Offset: 0x12038B0 VA: 0x12038B0
	|-Dictionary.ValueCollection<byte, uint>.CopyTo
	|
	|-RVA: 0x1204638 Offset: 0x1204638 VA: 0x1204638
	|-Dictionary.ValueCollection<char, object>.CopyTo
	|
	|-RVA: 0x1205378 Offset: 0x1205378 VA: 0x1205378
	|-Dictionary.ValueCollection<Guid, object>.CopyTo
	|
	|-RVA: 0x12060DC Offset: 0x12060DC VA: 0x12060DC
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.CopyTo
	|
	|-RVA: 0x1206F94 Offset: 0x1206F94 VA: 0x1206F94
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.CopyTo
	|
	|-RVA: 0x1D55C94 Offset: 0x1D55C94 VA: 0x1D55C94
	|-Dictionary.ValueCollection<int, bool>.CopyTo
	|
	|-RVA: 0x1D56A1C Offset: 0x1D56A1C VA: 0x1D56A1C
	|-Dictionary.ValueCollection<int, char>.CopyTo
	|
	|-RVA: 0x1D577B0 Offset: 0x1D577B0 VA: 0x1D577B0
	|-Dictionary.ValueCollection<int, int>.CopyTo
	|
	|-RVA: 0x1D58538 Offset: 0x1D58538 VA: 0x1D58538
	|-Dictionary.ValueCollection<int, Int32Enum>.CopyTo
	|
	|-RVA: 0x1D592D0 Offset: 0x1D592D0 VA: 0x1D592D0
	|-Dictionary.ValueCollection<int, long>.CopyTo
	|
	|-RVA: 0x1D5A0D0 Offset: 0x1D5A0D0 VA: 0x1D5A0D0
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.CopyTo
	|
	|-RVA: 0x1D5AEC0 Offset: 0x1D5AEC0 VA: 0x1D5AEC0
	|-Dictionary.ValueCollection<int, object>.CopyTo
	|
	|-RVA: 0x1D5BC00 Offset: 0x1D5BC00 VA: 0x1D5BC00
	|-Dictionary.ValueCollection<int, float>.CopyTo
	|
	|-RVA: 0x1D5C988 Offset: 0x1D5C988 VA: 0x1D5C988
	|-Dictionary.ValueCollection<int, uint>.CopyTo
	|
	|-RVA: 0x1D5D710 Offset: 0x1D5D710 VA: 0x1D5D710
	|-Dictionary.ValueCollection<Int32Enum, bool>.CopyTo
	|
	|-RVA: 0x1D5E498 Offset: 0x1D5E498 VA: 0x1D5E498
	|-Dictionary.ValueCollection<Int32Enum, int>.CopyTo
	|
	|-RVA: 0x1D5F220 Offset: 0x1D5F220 VA: 0x1D5F220
	|-Dictionary.ValueCollection<Int32Enum, object>.CopyTo
	|
	|-RVA: 0x1D5FF60 Offset: 0x1D5FF60 VA: 0x1D5FF60
	|-Dictionary.ValueCollection<Int32Enum, uint>.CopyTo
	|
	|-RVA: 0x1D60CF4 Offset: 0x1D60CF4 VA: 0x1D60CF4
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.CopyTo
	|
	|-RVA: 0x1D61AE8 Offset: 0x1D61AE8 VA: 0x1D61AE8
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.CopyTo
	|
	|-RVA: 0x1D628D0 Offset: 0x1D628D0 VA: 0x1D628D0
	|-Dictionary.ValueCollection<long, int>.CopyTo
	|
	|-RVA: 0x1D63664 Offset: 0x1D63664 VA: 0x1D63664
	|-Dictionary.ValueCollection<long, object>.CopyTo
	|
	|-RVA: 0x1D643AC Offset: 0x1D643AC VA: 0x1D643AC
	|-Dictionary.ValueCollection<IntPtr, object>.CopyTo
	|
	|-RVA: 0x1D650F4 Offset: 0x1D650F4 VA: 0x1D650F4
	|-Dictionary.ValueCollection<object, CommandInfo>.CopyTo
	|
	|-RVA: 0x1D65EF8 Offset: 0x1D65EF8 VA: 0x1D65EF8
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.CopyTo
	|
	|-RVA: 0x1D66CF0 Offset: 0x1D66CF0 VA: 0x1D66CF0
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.CopyTo
	|
	|-RVA: 0x1D67B14 Offset: 0x1D67B14 VA: 0x1D67B14
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.CopyTo
	|
	|-RVA: 0x1D6895C Offset: 0x1D6895C VA: 0x1D6895C
	|-Dictionary.ValueCollection<object, bool>.CopyTo
	|
	|-RVA: 0x1D696E4 Offset: 0x1D696E4 VA: 0x1D696E4
	|-Dictionary.ValueCollection<object, byte>.CopyTo
	|
	|-RVA: 0x1D6A46C Offset: 0x1D6A46C VA: 0x1D6A46C
	|-Dictionary.ValueCollection<object, short>.CopyTo
	|
	|-RVA: 0x1D6B200 Offset: 0x1D6B200 VA: 0x1D6B200
	|-Dictionary.ValueCollection<object, int>.CopyTo
	|
	|-RVA: 0x1D6BF88 Offset: 0x1D6BF88 VA: 0x1D6BF88
	|-Dictionary.ValueCollection<object, Int32Enum>.CopyTo
	|
	|-RVA: 0x1D6CD20 Offset: 0x1D6CD20 VA: 0x1D6CD20
	|-Dictionary.ValueCollection<object, long>.CopyTo
	|
	|-RVA: 0x1D6DB18 Offset: 0x1D6DB18 VA: 0x1D6DB18
	|-Dictionary.ValueCollection<object, object>.CopyTo
	|-Dictionary.ValueCollection<string, PropertyDescriptor>.CopyTo
	|
	|-RVA: 0x1D6E864 Offset: 0x1D6E864 VA: 0x1D6E864
	|-Dictionary.ValueCollection<object, ResourceLocator>.CopyTo
	|
	|-RVA: 0x1D6F64C Offset: 0x1D6F64C VA: 0x1D6F64C
	|-Dictionary.ValueCollection<object, uint>.CopyTo
	|
	|-RVA: 0x1D703E0 Offset: 0x1D703E0 VA: 0x1D703E0
	|-Dictionary.ValueCollection<object, Playable>.CopyTo
	|
	|-RVA: 0x1D711C8 Offset: 0x1D711C8 VA: 0x1D711C8
	|-Dictionary.ValueCollection<ushort, object>.CopyTo
	|
	|-RVA: 0x1D71F10 Offset: 0x1D71F10 VA: 0x1D71F10
	|-Dictionary.ValueCollection<uint, CustomValue>.CopyTo
	|
	|-RVA: 0x1D72D18 Offset: 0x1D72D18 VA: 0x1D72D18
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.CopyTo
	|
	|-RVA: 0x201D728 Offset: 0x201D728 VA: 0x201D728
	|-Dictionary.ValueCollection<uint, byte>.CopyTo
	|
	|-RVA: 0x201E4B0 Offset: 0x201E4B0 VA: 0x201E4B0
	|-Dictionary.ValueCollection<uint, int>.CopyTo
	|
	|-RVA: 0x201F238 Offset: 0x201F238 VA: 0x201F238
	|-Dictionary.ValueCollection<uint, object>.CopyTo
	|
	|-RVA: 0x201FF78 Offset: 0x201FF78 VA: 0x201FF78
	|-Dictionary.ValueCollection<ulong, object>.CopyTo
	|
	|-RVA: 0x2020CC0 Offset: 0x2020CC0 VA: 0x2020CC0
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.CopyTo
	|
	|-RVA: 0x2021A48 Offset: 0x2021A48 VA: 0x2021A48
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.CopyTo
	|
	|-RVA: 0x2022790 Offset: 0x2022790 VA: 0x2022790
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.CopyTo
	|
	|-RVA: 0x2023524 Offset: 0x2023524 VA: 0x2023524
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.CopyTo
	|
	|-RVA: 0x202426C Offset: 0x202426C VA: 0x202426C
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.CopyTo
	|
	|-RVA: 0x2024FB4 Offset: 0x2024FB4 VA: 0x2024FB4
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.CopyTo
	|
	|-RVA: 0x2025CFC Offset: 0x2025CFC VA: 0x2025CFC
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.CopyTo
	|
	|-RVA: 0x2026A44 Offset: 0x2026A44 VA: 0x2026A44
	|-Dictionary.ValueCollection<Vector3, int>.CopyTo
	|
	|-RVA: 0x20277D8 Offset: 0x20277D8 VA: 0x20277D8
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.CopyTo
	|
	|-RVA: 0x2028520 Offset: 0x2028520 VA: 0x2028520
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 17
	public int get_Count() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7188 Offset: 0x11F7188 VA: 0x11F7188
	|-Dictionary.ValueCollection<EntityID, Entity>.get_Count
	|
	|-RVA: 0x11F7F78 Offset: 0x11F7F78 VA: 0x11F7F78
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.get_Count
	|
	|-RVA: 0x11F8D44 Offset: 0x11F8D44 VA: 0x11F8D44
	|-Dictionary.ValueCollection<U64Id, int>.get_Count
	|
	|-RVA: 0x11F9AD8 Offset: 0x11F9AD8 VA: 0x11F9AD8
	|-Dictionary.ValueCollection<U64Id, object>.get_Count
	|
	|-RVA: 0x11FA820 Offset: 0x11FA820 VA: 0x11FA820
	|-Dictionary.ValueCollection<LeaderBoardType, object>.get_Count
	|
	|-RVA: 0x11FB564 Offset: 0x11FB564 VA: 0x11FB564
	|-Dictionary.ValueCollection<TranslateEvent, object>.get_Count
	|
	|-RVA: 0x11FC2D0 Offset: 0x11FC2D0 VA: 0x11FC2D0
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.get_Count
	|
	|-RVA: 0x11FD09C Offset: 0x11FD09C VA: 0x11FD09C
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.get_Count
	|
	|-RVA: 0x11FDDE4 Offset: 0x11FDDE4 VA: 0x11FDDE4
	|-Dictionary.ValueCollection<ResolverContractKey, object>.get_Count
	|
	|-RVA: 0x11FEB2C Offset: 0x11FEB2C VA: 0x11FEB2C
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.get_Count
	|
	|-RVA: 0x11FF874 Offset: 0x11FF874 VA: 0x11FF874
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.get_Count
	|
	|-RVA: 0x1200608 Offset: 0x1200608 VA: 0x1200608
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.get_Count
	|
	|-RVA: 0x1201350 Offset: 0x1201350 VA: 0x1201350
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.get_Count
	|
	|-RVA: 0x1202094 Offset: 0x1202094 VA: 0x1202094
	|-Dictionary.ValueCollection<byte, object>.get_Count
	|
	|-RVA: 0x1202DD4 Offset: 0x1202DD4 VA: 0x1202DD4
	|-Dictionary.ValueCollection<byte, float>.get_Count
	|
	|-RVA: 0x1203B5C Offset: 0x1203B5C VA: 0x1203B5C
	|-Dictionary.ValueCollection<byte, uint>.get_Count
	|
	|-RVA: 0x12048E4 Offset: 0x12048E4 VA: 0x12048E4
	|-Dictionary.ValueCollection<char, object>.get_Count
	|
	|-RVA: 0x1205628 Offset: 0x1205628 VA: 0x1205628
	|-Dictionary.ValueCollection<Guid, object>.get_Count
	|
	|-RVA: 0x12063D4 Offset: 0x12063D4 VA: 0x12063D4
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.get_Count
	|
	|-RVA: 0x1207260 Offset: 0x1207260 VA: 0x1207260
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.get_Count
	|
	|-RVA: 0x1D55F40 Offset: 0x1D55F40 VA: 0x1D55F40
	|-Dictionary.ValueCollection<int, bool>.get_Count
	|
	|-RVA: 0x1D56CCC Offset: 0x1D56CCC VA: 0x1D56CCC
	|-Dictionary.ValueCollection<int, char>.get_Count
	|
	|-RVA: 0x1D57A5C Offset: 0x1D57A5C VA: 0x1D57A5C
	|-Dictionary.ValueCollection<int, int>.get_Count
	|
	|-RVA: 0x1D587E4 Offset: 0x1D587E4 VA: 0x1D587E4
	|-Dictionary.ValueCollection<int, Int32Enum>.get_Count
	|
	|-RVA: 0x1D5959C Offset: 0x1D5959C VA: 0x1D5959C
	|-Dictionary.ValueCollection<int, long>.get_Count
	|
	|-RVA: 0x1D5A390 Offset: 0x1D5A390 VA: 0x1D5A390
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.get_Count
	|
	|-RVA: 0x1D5B16C Offset: 0x1D5B16C VA: 0x1D5B16C
	|-Dictionary.ValueCollection<int, object>.get_Count
	|
	|-RVA: 0x1D5BEAC Offset: 0x1D5BEAC VA: 0x1D5BEAC
	|-Dictionary.ValueCollection<int, float>.get_Count
	|
	|-RVA: 0x1D5CC34 Offset: 0x1D5CC34 VA: 0x1D5CC34
	|-Dictionary.ValueCollection<int, uint>.get_Count
	|
	|-RVA: 0x1D5D9BC Offset: 0x1D5D9BC VA: 0x1D5D9BC
	|-Dictionary.ValueCollection<Int32Enum, bool>.get_Count
	|
	|-RVA: 0x1D5E744 Offset: 0x1D5E744 VA: 0x1D5E744
	|-Dictionary.ValueCollection<Int32Enum, int>.get_Count
	|
	|-RVA: 0x1D5F4CC Offset: 0x1D5F4CC VA: 0x1D5F4CC
	|-Dictionary.ValueCollection<Int32Enum, object>.get_Count
	|
	|-RVA: 0x1D6020C Offset: 0x1D6020C VA: 0x1D6020C
	|-Dictionary.ValueCollection<Int32Enum, uint>.get_Count
	|
	|-RVA: 0x1D60FC0 Offset: 0x1D60FC0 VA: 0x1D60FC0
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.get_Count
	|
	|-RVA: 0x1D61DB4 Offset: 0x1D61DB4 VA: 0x1D61DB4
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.get_Count
	|
	|-RVA: 0x1D62B80 Offset: 0x1D62B80 VA: 0x1D62B80
	|-Dictionary.ValueCollection<long, int>.get_Count
	|
	|-RVA: 0x1D63914 Offset: 0x1D63914 VA: 0x1D63914
	|-Dictionary.ValueCollection<long, object>.get_Count
	|
	|-RVA: 0x1D64658 Offset: 0x1D64658 VA: 0x1D64658
	|-Dictionary.ValueCollection<IntPtr, object>.get_Count
	|
	|-RVA: 0x1D653B4 Offset: 0x1D653B4 VA: 0x1D653B4
	|-Dictionary.ValueCollection<object, CommandInfo>.get_Count
	|
	|-RVA: 0x1D661C4 Offset: 0x1D661C4 VA: 0x1D661C4
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.get_Count
	|
	|-RVA: 0x1D66FCC Offset: 0x1D66FCC VA: 0x1D66FCC
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.get_Count
	|
	|-RVA: 0x1D67DE0 Offset: 0x1D67DE0 VA: 0x1D67DE0
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.get_Count
	|
	|-RVA: 0x1D68C08 Offset: 0x1D68C08 VA: 0x1D68C08
	|-Dictionary.ValueCollection<object, bool>.get_Count
	|
	|-RVA: 0x1D69990 Offset: 0x1D69990 VA: 0x1D69990
	|-Dictionary.ValueCollection<object, byte>.get_Count
	|
	|-RVA: 0x1D6A71C Offset: 0x1D6A71C VA: 0x1D6A71C
	|-Dictionary.ValueCollection<object, short>.get_Count
	|
	|-RVA: 0x1D6B4AC Offset: 0x1D6B4AC VA: 0x1D6B4AC
	|-Dictionary.ValueCollection<object, int>.get_Count
	|
	|-RVA: 0x1D6C234 Offset: 0x1D6C234 VA: 0x1D6C234
	|-Dictionary.ValueCollection<object, Int32Enum>.get_Count
	|
	|-RVA: 0x1D6CFEC Offset: 0x1D6CFEC VA: 0x1D6CFEC
	|-Dictionary.ValueCollection<object, long>.get_Count
	|
	|-RVA: 0x1D6DDC4 Offset: 0x1D6DDC4 VA: 0x1D6DDC4
	|-Dictionary.ValueCollection<object, object>.get_Count
	|
	|-RVA: 0x1D6EB30 Offset: 0x1D6EB30 VA: 0x1D6EB30
	|-Dictionary.ValueCollection<object, ResourceLocator>.get_Count
	|
	|-RVA: 0x1D6F8F8 Offset: 0x1D6F8F8 VA: 0x1D6F8F8
	|-Dictionary.ValueCollection<object, uint>.get_Count
	|
	|-RVA: 0x1D706AC Offset: 0x1D706AC VA: 0x1D706AC
	|-Dictionary.ValueCollection<object, Playable>.get_Count
	|
	|-RVA: 0x1D71474 Offset: 0x1D71474 VA: 0x1D71474
	|-Dictionary.ValueCollection<ushort, object>.get_Count
	|
	|-RVA: 0x1D721D0 Offset: 0x1D721D0 VA: 0x1D721D0
	|-Dictionary.ValueCollection<uint, CustomValue>.get_Count
	|
	|-RVA: 0x1D72FF4 Offset: 0x1D72FF4 VA: 0x1D72FF4
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.get_Count
	|
	|-RVA: 0x201D9D4 Offset: 0x201D9D4 VA: 0x201D9D4
	|-Dictionary.ValueCollection<uint, byte>.get_Count
	|
	|-RVA: 0x201E75C Offset: 0x201E75C VA: 0x201E75C
	|-Dictionary.ValueCollection<uint, int>.get_Count
	|
	|-RVA: 0x201F4E4 Offset: 0x201F4E4 VA: 0x201F4E4
	|-Dictionary.ValueCollection<uint, object>.get_Count
	|
	|-RVA: 0x2020228 Offset: 0x2020228 VA: 0x2020228
	|-Dictionary.ValueCollection<ulong, object>.get_Count
	|
	|-RVA: 0x2020F6C Offset: 0x2020F6C VA: 0x2020F6C
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.get_Count
	|
	|-RVA: 0x2021CF8 Offset: 0x2021CF8 VA: 0x2021CF8
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.get_Count
	|
	|-RVA: 0x2022A40 Offset: 0x2022A40 VA: 0x2022A40
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.get_Count
	|
	|-RVA: 0x20237D4 Offset: 0x20237D4 VA: 0x20237D4
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.get_Count
	|
	|-RVA: 0x202451C Offset: 0x202451C VA: 0x202451C
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.get_Count
	|
	|-RVA: 0x2025264 Offset: 0x2025264 VA: 0x2025264
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.get_Count
	|
	|-RVA: 0x2025FAC Offset: 0x2025FAC VA: 0x2025FAC
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.get_Count
	|
	|-RVA: 0x2026CF4 Offset: 0x2026CF4 VA: 0x2026CF4
	|-Dictionary.ValueCollection<Vector3, int>.get_Count
	|
	|-RVA: 0x2027A88 Offset: 0x2027A88 VA: 0x2027A88
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.get_Count
	|
	|-RVA: 0x20287D0 Offset: 0x20287D0 VA: 0x20287D0
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.get_Count
	*/

	// RVA: -1 Offset: -1 Slot: 5
	private bool System.Collections.Generic.ICollection<TValue>.get_IsReadOnly() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F71C4 Offset: 0x11F71C4 VA: 0x11F71C4
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11F7FB4 Offset: 0x11F7FB4 VA: 0x11F7FB4
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11F8D80 Offset: 0x11F8D80 VA: 0x11F8D80
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11F9B14 Offset: 0x11F9B14 VA: 0x11F9B14
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FA85C Offset: 0x11FA85C VA: 0x11FA85C
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FB5A0 Offset: 0x11FB5A0 VA: 0x11FB5A0
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FC30C Offset: 0x11FC30C VA: 0x11FC30C
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FD0D8 Offset: 0x11FD0D8 VA: 0x11FD0D8
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FDE20 Offset: 0x11FDE20 VA: 0x11FDE20
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FEB68 Offset: 0x11FEB68 VA: 0x11FEB68
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x11FF8B0 Offset: 0x11FF8B0 VA: 0x11FF8B0
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1200644 Offset: 0x1200644 VA: 0x1200644
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x120138C Offset: 0x120138C VA: 0x120138C
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x12020D0 Offset: 0x12020D0 VA: 0x12020D0
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1202E10 Offset: 0x1202E10 VA: 0x1202E10
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1203B98 Offset: 0x1203B98 VA: 0x1203B98
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1204920 Offset: 0x1204920 VA: 0x1204920
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1205664 Offset: 0x1205664 VA: 0x1205664
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1206410 Offset: 0x1206410 VA: 0x1206410
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x120729C Offset: 0x120729C VA: 0x120729C
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D55F7C Offset: 0x1D55F7C VA: 0x1D55F7C
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D56D08 Offset: 0x1D56D08 VA: 0x1D56D08
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D57A98 Offset: 0x1D57A98 VA: 0x1D57A98
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D58820 Offset: 0x1D58820 VA: 0x1D58820
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D595D8 Offset: 0x1D595D8 VA: 0x1D595D8
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5A3CC Offset: 0x1D5A3CC VA: 0x1D5A3CC
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5B1A8 Offset: 0x1D5B1A8 VA: 0x1D5B1A8
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5BEE8 Offset: 0x1D5BEE8 VA: 0x1D5BEE8
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5CC70 Offset: 0x1D5CC70 VA: 0x1D5CC70
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5D9F8 Offset: 0x1D5D9F8 VA: 0x1D5D9F8
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5E780 Offset: 0x1D5E780 VA: 0x1D5E780
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D5F508 Offset: 0x1D5F508 VA: 0x1D5F508
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D60248 Offset: 0x1D60248 VA: 0x1D60248
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D60FFC Offset: 0x1D60FFC VA: 0x1D60FFC
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D61DF0 Offset: 0x1D61DF0 VA: 0x1D61DF0
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D62BBC Offset: 0x1D62BBC VA: 0x1D62BBC
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D63950 Offset: 0x1D63950 VA: 0x1D63950
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D64694 Offset: 0x1D64694 VA: 0x1D64694
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D653F0 Offset: 0x1D653F0 VA: 0x1D653F0
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D66200 Offset: 0x1D66200 VA: 0x1D66200
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D67008 Offset: 0x1D67008 VA: 0x1D67008
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D67E1C Offset: 0x1D67E1C VA: 0x1D67E1C
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D68C44 Offset: 0x1D68C44 VA: 0x1D68C44
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D699CC Offset: 0x1D699CC VA: 0x1D699CC
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6A758 Offset: 0x1D6A758 VA: 0x1D6A758
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6B4E8 Offset: 0x1D6B4E8 VA: 0x1D6B4E8
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6C270 Offset: 0x1D6C270 VA: 0x1D6C270
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6D028 Offset: 0x1D6D028 VA: 0x1D6D028
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6DE00 Offset: 0x1D6DE00 VA: 0x1D6DE00
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6EB6C Offset: 0x1D6EB6C VA: 0x1D6EB6C
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D6F934 Offset: 0x1D6F934 VA: 0x1D6F934
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D706E8 Offset: 0x1D706E8 VA: 0x1D706E8
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D714B0 Offset: 0x1D714B0 VA: 0x1D714B0
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D7220C Offset: 0x1D7220C VA: 0x1D7220C
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x1D73030 Offset: 0x1D73030 VA: 0x1D73030
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x201DA10 Offset: 0x201DA10 VA: 0x201DA10
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x201E798 Offset: 0x201E798 VA: 0x201E798
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x201F520 Offset: 0x201F520 VA: 0x201F520
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2020264 Offset: 0x2020264 VA: 0x2020264
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2020FA8 Offset: 0x2020FA8 VA: 0x2020FA8
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2021D34 Offset: 0x2021D34 VA: 0x2021D34
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2022A7C Offset: 0x2022A7C VA: 0x2022A7C
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2023810 Offset: 0x2023810 VA: 0x2023810
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2024558 Offset: 0x2024558 VA: 0x2024558
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x20252A0 Offset: 0x20252A0 VA: 0x20252A0
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2025FE8 Offset: 0x2025FE8 VA: 0x2025FE8
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2026D30 Offset: 0x2026D30 VA: 0x2026D30
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x2027AC4 Offset: 0x2027AC4 VA: 0x2027AC4
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	|
	|-RVA: 0x202880C Offset: 0x202880C VA: 0x202880C
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.ICollection<TValue>.get_IsReadOnly
	*/

	// RVA: -1 Offset: -1 Slot: 6
	private void System.Collections.Generic.ICollection<TValue>.Add(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F71CC Offset: 0x11F71CC VA: 0x11F71CC
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11F7FBC Offset: 0x11F7FBC VA: 0x11F7FBC
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11F8D88 Offset: 0x11F8D88 VA: 0x11F8D88
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11F9B1C Offset: 0x11F9B1C VA: 0x11F9B1C
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FA864 Offset: 0x11FA864 VA: 0x11FA864
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FB5A8 Offset: 0x11FB5A8 VA: 0x11FB5A8
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FC314 Offset: 0x11FC314 VA: 0x11FC314
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FD0E0 Offset: 0x11FD0E0 VA: 0x11FD0E0
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FDE28 Offset: 0x11FDE28 VA: 0x11FDE28
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FEB70 Offset: 0x11FEB70 VA: 0x11FEB70
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x11FF8B8 Offset: 0x11FF8B8 VA: 0x11FF8B8
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x120064C Offset: 0x120064C VA: 0x120064C
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1201394 Offset: 0x1201394 VA: 0x1201394
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x12020D8 Offset: 0x12020D8 VA: 0x12020D8
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1202E18 Offset: 0x1202E18 VA: 0x1202E18
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1203BA0 Offset: 0x1203BA0 VA: 0x1203BA0
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1204928 Offset: 0x1204928 VA: 0x1204928
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x120566C Offset: 0x120566C VA: 0x120566C
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1206418 Offset: 0x1206418 VA: 0x1206418
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x12072A4 Offset: 0x12072A4 VA: 0x12072A4
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D55F84 Offset: 0x1D55F84 VA: 0x1D55F84
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D56D10 Offset: 0x1D56D10 VA: 0x1D56D10
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D57AA0 Offset: 0x1D57AA0 VA: 0x1D57AA0
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D58828 Offset: 0x1D58828 VA: 0x1D58828
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D595E0 Offset: 0x1D595E0 VA: 0x1D595E0
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5A3D4 Offset: 0x1D5A3D4 VA: 0x1D5A3D4
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5B1B0 Offset: 0x1D5B1B0 VA: 0x1D5B1B0
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5BEF0 Offset: 0x1D5BEF0 VA: 0x1D5BEF0
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5CC78 Offset: 0x1D5CC78 VA: 0x1D5CC78
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5DA00 Offset: 0x1D5DA00 VA: 0x1D5DA00
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5E788 Offset: 0x1D5E788 VA: 0x1D5E788
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D5F510 Offset: 0x1D5F510 VA: 0x1D5F510
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D60250 Offset: 0x1D60250 VA: 0x1D60250
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D61004 Offset: 0x1D61004 VA: 0x1D61004
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D61DF8 Offset: 0x1D61DF8 VA: 0x1D61DF8
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D62BC4 Offset: 0x1D62BC4 VA: 0x1D62BC4
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D63958 Offset: 0x1D63958 VA: 0x1D63958
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6469C Offset: 0x1D6469C VA: 0x1D6469C
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D653F8 Offset: 0x1D653F8 VA: 0x1D653F8
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D66208 Offset: 0x1D66208 VA: 0x1D66208
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D67010 Offset: 0x1D67010 VA: 0x1D67010
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D67E24 Offset: 0x1D67E24 VA: 0x1D67E24
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D68C4C Offset: 0x1D68C4C VA: 0x1D68C4C
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D699D4 Offset: 0x1D699D4 VA: 0x1D699D4
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6A760 Offset: 0x1D6A760 VA: 0x1D6A760
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6B4F0 Offset: 0x1D6B4F0 VA: 0x1D6B4F0
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6C278 Offset: 0x1D6C278 VA: 0x1D6C278
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6D030 Offset: 0x1D6D030 VA: 0x1D6D030
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6DE08 Offset: 0x1D6DE08 VA: 0x1D6DE08
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6EB74 Offset: 0x1D6EB74 VA: 0x1D6EB74
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D6F93C Offset: 0x1D6F93C VA: 0x1D6F93C
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D706F0 Offset: 0x1D706F0 VA: 0x1D706F0
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D714B8 Offset: 0x1D714B8 VA: 0x1D714B8
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D72214 Offset: 0x1D72214 VA: 0x1D72214
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x1D73038 Offset: 0x1D73038 VA: 0x1D73038
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x201DA18 Offset: 0x201DA18 VA: 0x201DA18
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x201E7A0 Offset: 0x201E7A0 VA: 0x201E7A0
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x201F528 Offset: 0x201F528 VA: 0x201F528
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x202026C Offset: 0x202026C VA: 0x202026C
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2020FB0 Offset: 0x2020FB0 VA: 0x2020FB0
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2021D3C Offset: 0x2021D3C VA: 0x2021D3C
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2022A84 Offset: 0x2022A84 VA: 0x2022A84
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2023818 Offset: 0x2023818 VA: 0x2023818
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2024560 Offset: 0x2024560 VA: 0x2024560
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x20252A8 Offset: 0x20252A8 VA: 0x20252A8
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2025FF0 Offset: 0x2025FF0 VA: 0x2025FF0
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2026D38 Offset: 0x2026D38 VA: 0x2026D38
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2027ACC Offset: 0x2027ACC VA: 0x2027ACC
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.ICollection<TValue>.Add
	|
	|-RVA: 0x2028814 Offset: 0x2028814 VA: 0x2028814
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.ICollection<TValue>.Add
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private bool System.Collections.Generic.ICollection<TValue>.Remove(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7268 Offset: 0x11F7268 VA: 0x11F7268
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11F8058 Offset: 0x11F8058 VA: 0x11F8058
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11F8E24 Offset: 0x11F8E24 VA: 0x11F8E24
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11F9BB8 Offset: 0x11F9BB8 VA: 0x11F9BB8
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FA900 Offset: 0x11FA900 VA: 0x11FA900
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FB644 Offset: 0x11FB644 VA: 0x11FB644
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FC3B0 Offset: 0x11FC3B0 VA: 0x11FC3B0
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FD17C Offset: 0x11FD17C VA: 0x11FD17C
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FDEC4 Offset: 0x11FDEC4 VA: 0x11FDEC4
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FEC0C Offset: 0x11FEC0C VA: 0x11FEC0C
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x11FF954 Offset: 0x11FF954 VA: 0x11FF954
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x12006E8 Offset: 0x12006E8 VA: 0x12006E8
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1201430 Offset: 0x1201430 VA: 0x1201430
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1202174 Offset: 0x1202174 VA: 0x1202174
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1202EB4 Offset: 0x1202EB4 VA: 0x1202EB4
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1203C3C Offset: 0x1203C3C VA: 0x1203C3C
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x12049C4 Offset: 0x12049C4 VA: 0x12049C4
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1205708 Offset: 0x1205708 VA: 0x1205708
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x12064B4 Offset: 0x12064B4 VA: 0x12064B4
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1207340 Offset: 0x1207340 VA: 0x1207340
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D56020 Offset: 0x1D56020 VA: 0x1D56020
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D56DAC Offset: 0x1D56DAC VA: 0x1D56DAC
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D57B3C Offset: 0x1D57B3C VA: 0x1D57B3C
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D588C4 Offset: 0x1D588C4 VA: 0x1D588C4
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5967C Offset: 0x1D5967C VA: 0x1D5967C
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5A470 Offset: 0x1D5A470 VA: 0x1D5A470
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5B24C Offset: 0x1D5B24C VA: 0x1D5B24C
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5BF8C Offset: 0x1D5BF8C VA: 0x1D5BF8C
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5CD14 Offset: 0x1D5CD14 VA: 0x1D5CD14
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5DA9C Offset: 0x1D5DA9C VA: 0x1D5DA9C
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5E824 Offset: 0x1D5E824 VA: 0x1D5E824
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D5F5AC Offset: 0x1D5F5AC VA: 0x1D5F5AC
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D602EC Offset: 0x1D602EC VA: 0x1D602EC
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D610A0 Offset: 0x1D610A0 VA: 0x1D610A0
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D61E94 Offset: 0x1D61E94 VA: 0x1D61E94
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D62C60 Offset: 0x1D62C60 VA: 0x1D62C60
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D639F4 Offset: 0x1D639F4 VA: 0x1D639F4
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D64738 Offset: 0x1D64738 VA: 0x1D64738
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D65494 Offset: 0x1D65494 VA: 0x1D65494
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D662A4 Offset: 0x1D662A4 VA: 0x1D662A4
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D670AC Offset: 0x1D670AC VA: 0x1D670AC
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D67ED4 Offset: 0x1D67ED4 VA: 0x1D67ED4
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D68CE8 Offset: 0x1D68CE8 VA: 0x1D68CE8
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D69A70 Offset: 0x1D69A70 VA: 0x1D69A70
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6A7FC Offset: 0x1D6A7FC VA: 0x1D6A7FC
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6B58C Offset: 0x1D6B58C VA: 0x1D6B58C
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6C314 Offset: 0x1D6C314 VA: 0x1D6C314
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6D0CC Offset: 0x1D6D0CC VA: 0x1D6D0CC
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6DEA4 Offset: 0x1D6DEA4 VA: 0x1D6DEA4
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6EC10 Offset: 0x1D6EC10 VA: 0x1D6EC10
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D6F9D8 Offset: 0x1D6F9D8 VA: 0x1D6F9D8
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D7078C Offset: 0x1D7078C VA: 0x1D7078C
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D71554 Offset: 0x1D71554 VA: 0x1D71554
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D722B0 Offset: 0x1D722B0 VA: 0x1D722B0
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x1D730D4 Offset: 0x1D730D4 VA: 0x1D730D4
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x201DAB4 Offset: 0x201DAB4 VA: 0x201DAB4
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x201E83C Offset: 0x201E83C VA: 0x201E83C
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x201F5C4 Offset: 0x201F5C4 VA: 0x201F5C4
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2020308 Offset: 0x2020308 VA: 0x2020308
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x202104C Offset: 0x202104C VA: 0x202104C
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2021DD8 Offset: 0x2021DD8 VA: 0x2021DD8
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2022B20 Offset: 0x2022B20 VA: 0x2022B20
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x20238B4 Offset: 0x20238B4 VA: 0x20238B4
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x20245FC Offset: 0x20245FC VA: 0x20245FC
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2025344 Offset: 0x2025344 VA: 0x2025344
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x202608C Offset: 0x202608C VA: 0x202608C
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2026DD4 Offset: 0x2026DD4 VA: 0x2026DD4
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x2027B68 Offset: 0x2027B68 VA: 0x2027B68
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.ICollection<TValue>.Remove
	|
	|-RVA: 0x20288B0 Offset: 0x20288B0 VA: 0x20288B0
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.ICollection<TValue>.Remove
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private void System.Collections.Generic.ICollection<TValue>.Clear() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7304 Offset: 0x11F7304 VA: 0x11F7304
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11F80F4 Offset: 0x11F80F4 VA: 0x11F80F4
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11F8EC0 Offset: 0x11F8EC0 VA: 0x11F8EC0
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11F9C54 Offset: 0x11F9C54 VA: 0x11F9C54
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FA99C Offset: 0x11FA99C VA: 0x11FA99C
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FB6E0 Offset: 0x11FB6E0 VA: 0x11FB6E0
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FC44C Offset: 0x11FC44C VA: 0x11FC44C
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FD218 Offset: 0x11FD218 VA: 0x11FD218
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FDF60 Offset: 0x11FDF60 VA: 0x11FDF60
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FECA8 Offset: 0x11FECA8 VA: 0x11FECA8
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x11FF9F0 Offset: 0x11FF9F0 VA: 0x11FF9F0
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1200784 Offset: 0x1200784 VA: 0x1200784
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x12014CC Offset: 0x12014CC VA: 0x12014CC
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1202210 Offset: 0x1202210 VA: 0x1202210
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1202F50 Offset: 0x1202F50 VA: 0x1202F50
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1203CD8 Offset: 0x1203CD8 VA: 0x1203CD8
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1204A60 Offset: 0x1204A60 VA: 0x1204A60
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x12057A4 Offset: 0x12057A4 VA: 0x12057A4
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1206550 Offset: 0x1206550 VA: 0x1206550
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x12073DC Offset: 0x12073DC VA: 0x12073DC
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D560BC Offset: 0x1D560BC VA: 0x1D560BC
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D56E48 Offset: 0x1D56E48 VA: 0x1D56E48
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D57BD8 Offset: 0x1D57BD8 VA: 0x1D57BD8
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D58960 Offset: 0x1D58960 VA: 0x1D58960
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D59718 Offset: 0x1D59718 VA: 0x1D59718
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5A50C Offset: 0x1D5A50C VA: 0x1D5A50C
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5B2E8 Offset: 0x1D5B2E8 VA: 0x1D5B2E8
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5C028 Offset: 0x1D5C028 VA: 0x1D5C028
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5CDB0 Offset: 0x1D5CDB0 VA: 0x1D5CDB0
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5DB38 Offset: 0x1D5DB38 VA: 0x1D5DB38
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5E8C0 Offset: 0x1D5E8C0 VA: 0x1D5E8C0
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D5F648 Offset: 0x1D5F648 VA: 0x1D5F648
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D60388 Offset: 0x1D60388 VA: 0x1D60388
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6113C Offset: 0x1D6113C VA: 0x1D6113C
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D61F30 Offset: 0x1D61F30 VA: 0x1D61F30
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D62CFC Offset: 0x1D62CFC VA: 0x1D62CFC
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D63A90 Offset: 0x1D63A90 VA: 0x1D63A90
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D647D4 Offset: 0x1D647D4 VA: 0x1D647D4
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D65530 Offset: 0x1D65530 VA: 0x1D65530
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D66340 Offset: 0x1D66340 VA: 0x1D66340
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D67148 Offset: 0x1D67148 VA: 0x1D67148
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D67F84 Offset: 0x1D67F84 VA: 0x1D67F84
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D68D84 Offset: 0x1D68D84 VA: 0x1D68D84
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D69B0C Offset: 0x1D69B0C VA: 0x1D69B0C
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6A898 Offset: 0x1D6A898 VA: 0x1D6A898
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6B628 Offset: 0x1D6B628 VA: 0x1D6B628
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6C3B0 Offset: 0x1D6C3B0 VA: 0x1D6C3B0
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6D168 Offset: 0x1D6D168 VA: 0x1D6D168
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6DF40 Offset: 0x1D6DF40 VA: 0x1D6DF40
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6ECAC Offset: 0x1D6ECAC VA: 0x1D6ECAC
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D6FA74 Offset: 0x1D6FA74 VA: 0x1D6FA74
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D70828 Offset: 0x1D70828 VA: 0x1D70828
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D715F0 Offset: 0x1D715F0 VA: 0x1D715F0
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D7234C Offset: 0x1D7234C VA: 0x1D7234C
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x1D73170 Offset: 0x1D73170 VA: 0x1D73170
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x201DB50 Offset: 0x201DB50 VA: 0x201DB50
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x201E8D8 Offset: 0x201E8D8 VA: 0x201E8D8
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x201F660 Offset: 0x201F660 VA: 0x201F660
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x20203A4 Offset: 0x20203A4 VA: 0x20203A4
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x20210E8 Offset: 0x20210E8 VA: 0x20210E8
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2021E74 Offset: 0x2021E74 VA: 0x2021E74
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2022BBC Offset: 0x2022BBC VA: 0x2022BBC
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2023950 Offset: 0x2023950 VA: 0x2023950
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2024698 Offset: 0x2024698 VA: 0x2024698
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x20253E0 Offset: 0x20253E0 VA: 0x20253E0
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2026128 Offset: 0x2026128 VA: 0x2026128
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2026E70 Offset: 0x2026E70 VA: 0x2026E70
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x2027C04 Offset: 0x2027C04 VA: 0x2027C04
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.ICollection<TValue>.Clear
	|
	|-RVA: 0x202894C Offset: 0x202894C VA: 0x202894C
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.ICollection<TValue>.Clear
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private bool System.Collections.Generic.ICollection<TValue>.Contains(TValue item) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F73A0 Offset: 0x11F73A0 VA: 0x11F73A0
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11F8190 Offset: 0x11F8190 VA: 0x11F8190
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11F8F5C Offset: 0x11F8F5C VA: 0x11F8F5C
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11F9CF0 Offset: 0x11F9CF0 VA: 0x11F9CF0
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FAA38 Offset: 0x11FAA38 VA: 0x11FAA38
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FB77C Offset: 0x11FB77C VA: 0x11FB77C
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FC4E8 Offset: 0x11FC4E8 VA: 0x11FC4E8
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FD2B4 Offset: 0x11FD2B4 VA: 0x11FD2B4
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FDFFC Offset: 0x11FDFFC VA: 0x11FDFFC
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FED44 Offset: 0x11FED44 VA: 0x11FED44
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x11FFA8C Offset: 0x11FFA8C VA: 0x11FFA8C
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1200820 Offset: 0x1200820 VA: 0x1200820
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1201568 Offset: 0x1201568 VA: 0x1201568
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x12022AC Offset: 0x12022AC VA: 0x12022AC
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1202FEC Offset: 0x1202FEC VA: 0x1202FEC
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1203D74 Offset: 0x1203D74 VA: 0x1203D74
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1204AFC Offset: 0x1204AFC VA: 0x1204AFC
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1205840 Offset: 0x1205840 VA: 0x1205840
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x12065EC Offset: 0x12065EC VA: 0x12065EC
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1207478 Offset: 0x1207478 VA: 0x1207478
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D56158 Offset: 0x1D56158 VA: 0x1D56158
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D56EE4 Offset: 0x1D56EE4 VA: 0x1D56EE4
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D57C74 Offset: 0x1D57C74 VA: 0x1D57C74
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D589FC Offset: 0x1D589FC VA: 0x1D589FC
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D597B4 Offset: 0x1D597B4 VA: 0x1D597B4
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5A5A8 Offset: 0x1D5A5A8 VA: 0x1D5A5A8
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5B384 Offset: 0x1D5B384 VA: 0x1D5B384
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5C0C4 Offset: 0x1D5C0C4 VA: 0x1D5C0C4
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5CE4C Offset: 0x1D5CE4C VA: 0x1D5CE4C
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5DBD4 Offset: 0x1D5DBD4 VA: 0x1D5DBD4
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5E95C Offset: 0x1D5E95C VA: 0x1D5E95C
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D5F6E4 Offset: 0x1D5F6E4 VA: 0x1D5F6E4
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D60424 Offset: 0x1D60424 VA: 0x1D60424
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D611D8 Offset: 0x1D611D8 VA: 0x1D611D8
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D61FCC Offset: 0x1D61FCC VA: 0x1D61FCC
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D62D98 Offset: 0x1D62D98 VA: 0x1D62D98
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D63B2C Offset: 0x1D63B2C VA: 0x1D63B2C
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D64870 Offset: 0x1D64870 VA: 0x1D64870
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D655CC Offset: 0x1D655CC VA: 0x1D655CC
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D663DC Offset: 0x1D663DC VA: 0x1D663DC
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D671E4 Offset: 0x1D671E4 VA: 0x1D671E4
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D68020 Offset: 0x1D68020 VA: 0x1D68020
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D68E20 Offset: 0x1D68E20 VA: 0x1D68E20
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D69BA8 Offset: 0x1D69BA8 VA: 0x1D69BA8
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6A934 Offset: 0x1D6A934 VA: 0x1D6A934
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6B6C4 Offset: 0x1D6B6C4 VA: 0x1D6B6C4
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6C44C Offset: 0x1D6C44C VA: 0x1D6C44C
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6D204 Offset: 0x1D6D204 VA: 0x1D6D204
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6DFDC Offset: 0x1D6DFDC VA: 0x1D6DFDC
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6ED48 Offset: 0x1D6ED48 VA: 0x1D6ED48
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D6FB10 Offset: 0x1D6FB10 VA: 0x1D6FB10
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D708C4 Offset: 0x1D708C4 VA: 0x1D708C4
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D7168C Offset: 0x1D7168C VA: 0x1D7168C
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D723E8 Offset: 0x1D723E8 VA: 0x1D723E8
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x1D7320C Offset: 0x1D7320C VA: 0x1D7320C
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x201DBEC Offset: 0x201DBEC VA: 0x201DBEC
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x201E974 Offset: 0x201E974 VA: 0x201E974
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x201F6FC Offset: 0x201F6FC VA: 0x201F6FC
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2020440 Offset: 0x2020440 VA: 0x2020440
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2021184 Offset: 0x2021184 VA: 0x2021184
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2021F10 Offset: 0x2021F10 VA: 0x2021F10
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2022C58 Offset: 0x2022C58 VA: 0x2022C58
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x20239EC Offset: 0x20239EC VA: 0x20239EC
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2024734 Offset: 0x2024734 VA: 0x2024734
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x202547C Offset: 0x202547C VA: 0x202547C
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x20261C4 Offset: 0x20261C4 VA: 0x20261C4
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2026F0C Offset: 0x2026F0C VA: 0x2026F0C
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x2027CA0 Offset: 0x2027CA0 VA: 0x2027CA0
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.ICollection<TValue>.Contains
	|
	|-RVA: 0x20289E8 Offset: 0x20289E8 VA: 0x20289E8
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.ICollection<TValue>.Contains
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private IEnumerator<TValue> System.Collections.Generic.IEnumerable<TValue>.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F73EC Offset: 0x11F73EC VA: 0x11F73EC
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11F81DC Offset: 0x11F81DC VA: 0x11F81DC
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11F8FA0 Offset: 0x11F8FA0 VA: 0x11F8FA0
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11F9D34 Offset: 0x11F9D34 VA: 0x11F9D34
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FAA7C Offset: 0x11FAA7C VA: 0x11FAA7C
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FB7C0 Offset: 0x11FB7C0 VA: 0x11FB7C0
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FC534 Offset: 0x11FC534 VA: 0x11FC534
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FD2F8 Offset: 0x11FD2F8 VA: 0x11FD2F8
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FE040 Offset: 0x11FE040 VA: 0x11FE040
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FED88 Offset: 0x11FED88 VA: 0x11FED88
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x11FFAD0 Offset: 0x11FFAD0 VA: 0x11FFAD0
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1200864 Offset: 0x1200864 VA: 0x1200864
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x12015AC Offset: 0x12015AC VA: 0x12015AC
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x12022F0 Offset: 0x12022F0 VA: 0x12022F0
	|-Dictionary.ValueCollection<byte, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1203030 Offset: 0x1203030 VA: 0x1203030
	|-Dictionary.ValueCollection<byte, float>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1203DB8 Offset: 0x1203DB8 VA: 0x1203DB8
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1204B40 Offset: 0x1204B40 VA: 0x1204B40
	|-Dictionary.ValueCollection<char, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1205884 Offset: 0x1205884 VA: 0x1205884
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x12066A0 Offset: 0x12066A0 VA: 0x12066A0
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x12074C4 Offset: 0x12074C4 VA: 0x12074C4
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5619C Offset: 0x1D5619C VA: 0x1D5619C
	|-Dictionary.ValueCollection<int, bool>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D56F28 Offset: 0x1D56F28 VA: 0x1D56F28
	|-Dictionary.ValueCollection<int, char>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D57CB8 Offset: 0x1D57CB8 VA: 0x1D57CB8
	|-Dictionary.ValueCollection<int, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D58A40 Offset: 0x1D58A40 VA: 0x1D58A40
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5980C Offset: 0x1D5980C VA: 0x1D5980C
	|-Dictionary.ValueCollection<int, long>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5A610 Offset: 0x1D5A610 VA: 0x1D5A610
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5B3C8 Offset: 0x1D5B3C8 VA: 0x1D5B3C8
	|-Dictionary.ValueCollection<int, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5C108 Offset: 0x1D5C108 VA: 0x1D5C108
	|-Dictionary.ValueCollection<int, float>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5CE90 Offset: 0x1D5CE90 VA: 0x1D5CE90
	|-Dictionary.ValueCollection<int, uint>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5DC18 Offset: 0x1D5DC18 VA: 0x1D5DC18
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5E9A0 Offset: 0x1D5E9A0 VA: 0x1D5E9A0
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D5F728 Offset: 0x1D5F728 VA: 0x1D5F728
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D60468 Offset: 0x1D60468 VA: 0x1D60468
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D61224 Offset: 0x1D61224 VA: 0x1D61224
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D62018 Offset: 0x1D62018 VA: 0x1D62018
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D62DDC Offset: 0x1D62DDC VA: 0x1D62DDC
	|-Dictionary.ValueCollection<long, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D63B70 Offset: 0x1D63B70 VA: 0x1D63B70
	|-Dictionary.ValueCollection<long, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D648B4 Offset: 0x1D648B4 VA: 0x1D648B4
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D65634 Offset: 0x1D65634 VA: 0x1D65634
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D66428 Offset: 0x1D66428 VA: 0x1D66428
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D67244 Offset: 0x1D67244 VA: 0x1D67244
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D680B4 Offset: 0x1D680B4 VA: 0x1D680B4
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D68E64 Offset: 0x1D68E64 VA: 0x1D68E64
	|-Dictionary.ValueCollection<object, bool>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D69BEC Offset: 0x1D69BEC VA: 0x1D69BEC
	|-Dictionary.ValueCollection<object, byte>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6A978 Offset: 0x1D6A978 VA: 0x1D6A978
	|-Dictionary.ValueCollection<object, short>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6B708 Offset: 0x1D6B708 VA: 0x1D6B708
	|-Dictionary.ValueCollection<object, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6C490 Offset: 0x1D6C490 VA: 0x1D6C490
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6D25C Offset: 0x1D6D25C VA: 0x1D6D25C
	|-Dictionary.ValueCollection<object, long>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6E020 Offset: 0x1D6E020 VA: 0x1D6E020
	|-Dictionary.ValueCollection<object, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6ED94 Offset: 0x1D6ED94 VA: 0x1D6ED94
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D6FB54 Offset: 0x1D6FB54 VA: 0x1D6FB54
	|-Dictionary.ValueCollection<object, uint>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D70910 Offset: 0x1D70910 VA: 0x1D70910
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D716D0 Offset: 0x1D716D0 VA: 0x1D716D0
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D72450 Offset: 0x1D72450 VA: 0x1D72450
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x1D7326C Offset: 0x1D7326C VA: 0x1D7326C
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x201DC30 Offset: 0x201DC30 VA: 0x201DC30
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x201E9B8 Offset: 0x201E9B8 VA: 0x201E9B8
	|-Dictionary.ValueCollection<uint, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x201F740 Offset: 0x201F740 VA: 0x201F740
	|-Dictionary.ValueCollection<uint, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2020484 Offset: 0x2020484 VA: 0x2020484
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x20211C8 Offset: 0x20211C8 VA: 0x20211C8
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2021F54 Offset: 0x2021F54 VA: 0x2021F54
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2022C9C Offset: 0x2022C9C VA: 0x2022C9C
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2023A30 Offset: 0x2023A30 VA: 0x2023A30
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2024778 Offset: 0x2024778 VA: 0x2024778
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x20254C0 Offset: 0x20254C0 VA: 0x20254C0
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2026208 Offset: 0x2026208 VA: 0x2026208
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2026F50 Offset: 0x2026F50 VA: 0x2026F50
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2027CE4 Offset: 0x2027CE4 VA: 0x2027CE4
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	|
	|-RVA: 0x2028A2C Offset: 0x2028A2C VA: 0x2028A2C
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.Generic.IEnumerable<TValue>.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 12
	private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7474 Offset: 0x11F7474 VA: 0x11F7474
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11F8264 Offset: 0x11F8264 VA: 0x11F8264
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11F9014 Offset: 0x11F9014 VA: 0x11F9014
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11F9DA8 Offset: 0x11F9DA8 VA: 0x11F9DA8
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FAAF0 Offset: 0x11FAAF0 VA: 0x11FAAF0
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FB834 Offset: 0x11FB834 VA: 0x11FB834
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FC5BC Offset: 0x11FC5BC VA: 0x11FC5BC
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FD36C Offset: 0x11FD36C VA: 0x11FD36C
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FE0B4 Offset: 0x11FE0B4 VA: 0x11FE0B4
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FEDFC Offset: 0x11FEDFC VA: 0x11FEDFC
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x11FFB44 Offset: 0x11FFB44 VA: 0x11FFB44
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x12008D8 Offset: 0x12008D8 VA: 0x12008D8
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1201620 Offset: 0x1201620 VA: 0x1201620
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1202364 Offset: 0x1202364 VA: 0x1202364
	|-Dictionary.ValueCollection<byte, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x12030A4 Offset: 0x12030A4 VA: 0x12030A4
	|-Dictionary.ValueCollection<byte, float>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1203E2C Offset: 0x1203E2C VA: 0x1203E2C
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1204BB4 Offset: 0x1204BB4 VA: 0x1204BB4
	|-Dictionary.ValueCollection<char, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x12058F8 Offset: 0x12058F8 VA: 0x12058F8
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1206740 Offset: 0x1206740 VA: 0x1206740
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x120754C Offset: 0x120754C VA: 0x120754C
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D56210 Offset: 0x1D56210 VA: 0x1D56210
	|-Dictionary.ValueCollection<int, bool>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D56F9C Offset: 0x1D56F9C VA: 0x1D56F9C
	|-Dictionary.ValueCollection<int, char>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D57D2C Offset: 0x1D57D2C VA: 0x1D57D2C
	|-Dictionary.ValueCollection<int, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D58AB4 Offset: 0x1D58AB4 VA: 0x1D58AB4
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D59898 Offset: 0x1D59898 VA: 0x1D59898
	|-Dictionary.ValueCollection<int, long>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5A694 Offset: 0x1D5A694 VA: 0x1D5A694
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5B43C Offset: 0x1D5B43C VA: 0x1D5B43C
	|-Dictionary.ValueCollection<int, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5C17C Offset: 0x1D5C17C VA: 0x1D5C17C
	|-Dictionary.ValueCollection<int, float>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5CF04 Offset: 0x1D5CF04 VA: 0x1D5CF04
	|-Dictionary.ValueCollection<int, uint>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5DC8C Offset: 0x1D5DC8C VA: 0x1D5DC8C
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5EA14 Offset: 0x1D5EA14 VA: 0x1D5EA14
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D5F79C Offset: 0x1D5F79C VA: 0x1D5F79C
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D604DC Offset: 0x1D604DC VA: 0x1D604DC
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D612AC Offset: 0x1D612AC VA: 0x1D612AC
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D620A0 Offset: 0x1D620A0 VA: 0x1D620A0
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D62E50 Offset: 0x1D62E50 VA: 0x1D62E50
	|-Dictionary.ValueCollection<long, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D63BE4 Offset: 0x1D63BE4 VA: 0x1D63BE4
	|-Dictionary.ValueCollection<long, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D64928 Offset: 0x1D64928 VA: 0x1D64928
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D656BC Offset: 0x1D656BC VA: 0x1D656BC
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D664B0 Offset: 0x1D664B0 VA: 0x1D664B0
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D672D0 Offset: 0x1D672D0 VA: 0x1D672D0
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D68134 Offset: 0x1D68134 VA: 0x1D68134
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D68ED8 Offset: 0x1D68ED8 VA: 0x1D68ED8
	|-Dictionary.ValueCollection<object, bool>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D69C60 Offset: 0x1D69C60 VA: 0x1D69C60
	|-Dictionary.ValueCollection<object, byte>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6A9EC Offset: 0x1D6A9EC VA: 0x1D6A9EC
	|-Dictionary.ValueCollection<object, short>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6B77C Offset: 0x1D6B77C VA: 0x1D6B77C
	|-Dictionary.ValueCollection<object, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6C504 Offset: 0x1D6C504 VA: 0x1D6C504
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6D2E8 Offset: 0x1D6D2E8 VA: 0x1D6D2E8
	|-Dictionary.ValueCollection<object, long>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6E094 Offset: 0x1D6E094 VA: 0x1D6E094
	|-Dictionary.ValueCollection<object, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6EE1C Offset: 0x1D6EE1C VA: 0x1D6EE1C
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D6FBC8 Offset: 0x1D6FBC8 VA: 0x1D6FBC8
	|-Dictionary.ValueCollection<object, uint>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D70998 Offset: 0x1D70998 VA: 0x1D70998
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D71744 Offset: 0x1D71744 VA: 0x1D71744
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D724D8 Offset: 0x1D724D8 VA: 0x1D724D8
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x1D732F8 Offset: 0x1D732F8 VA: 0x1D732F8
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x201DCA4 Offset: 0x201DCA4 VA: 0x201DCA4
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x201EA2C Offset: 0x201EA2C VA: 0x201EA2C
	|-Dictionary.ValueCollection<uint, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x201F7B4 Offset: 0x201F7B4 VA: 0x201F7B4
	|-Dictionary.ValueCollection<uint, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x20204F8 Offset: 0x20204F8 VA: 0x20204F8
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x202123C Offset: 0x202123C VA: 0x202123C
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2021FC8 Offset: 0x2021FC8 VA: 0x2021FC8
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2022D10 Offset: 0x2022D10 VA: 0x2022D10
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2023AA4 Offset: 0x2023AA4 VA: 0x2023AA4
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x20247EC Offset: 0x20247EC VA: 0x20247EC
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2025534 Offset: 0x2025534 VA: 0x2025534
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x202627C Offset: 0x202627C VA: 0x202627C
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2026FC4 Offset: 0x2026FC4 VA: 0x2026FC4
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2027D58 Offset: 0x2027D58 VA: 0x2027D58
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.IEnumerable.GetEnumerator
	|
	|-RVA: 0x2028AA0 Offset: 0x2028AA0 VA: 0x2028AA0
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerable.GetEnumerator
	*/

	// RVA: -1 Offset: -1 Slot: 13
	private void System.Collections.ICollection.CopyTo(Array array, int index) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F74FC Offset: 0x11F74FC VA: 0x11F74FC
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11F82EC Offset: 0x11F82EC VA: 0x11F82EC
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11F9088 Offset: 0x11F9088 VA: 0x11F9088
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11F9E1C Offset: 0x11F9E1C VA: 0x11F9E1C
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FAB64 Offset: 0x11FAB64 VA: 0x11FAB64
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FB8A8 Offset: 0x11FB8A8 VA: 0x11FB8A8
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FC644 Offset: 0x11FC644 VA: 0x11FC644
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FD3E0 Offset: 0x11FD3E0 VA: 0x11FD3E0
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FE128 Offset: 0x11FE128 VA: 0x11FE128
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FEE70 Offset: 0x11FEE70 VA: 0x11FEE70
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x11FFBB8 Offset: 0x11FFBB8 VA: 0x11FFBB8
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x120094C Offset: 0x120094C VA: 0x120094C
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1201694 Offset: 0x1201694 VA: 0x1201694
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x12023D8 Offset: 0x12023D8 VA: 0x12023D8
	|-Dictionary.ValueCollection<byte, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1203118 Offset: 0x1203118 VA: 0x1203118
	|-Dictionary.ValueCollection<byte, float>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1203EA0 Offset: 0x1203EA0 VA: 0x1203EA0
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1204C28 Offset: 0x1204C28 VA: 0x1204C28
	|-Dictionary.ValueCollection<char, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x120596C Offset: 0x120596C VA: 0x120596C
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x12067E0 Offset: 0x12067E0 VA: 0x12067E0
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x12075D4 Offset: 0x12075D4 VA: 0x12075D4
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D56284 Offset: 0x1D56284 VA: 0x1D56284
	|-Dictionary.ValueCollection<int, bool>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D57010 Offset: 0x1D57010 VA: 0x1D57010
	|-Dictionary.ValueCollection<int, char>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D57DA0 Offset: 0x1D57DA0 VA: 0x1D57DA0
	|-Dictionary.ValueCollection<int, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D58B28 Offset: 0x1D58B28 VA: 0x1D58B28
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D59924 Offset: 0x1D59924 VA: 0x1D59924
	|-Dictionary.ValueCollection<int, long>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5A718 Offset: 0x1D5A718 VA: 0x1D5A718
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5B4B0 Offset: 0x1D5B4B0 VA: 0x1D5B4B0
	|-Dictionary.ValueCollection<int, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5C1F0 Offset: 0x1D5C1F0 VA: 0x1D5C1F0
	|-Dictionary.ValueCollection<int, float>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5CF78 Offset: 0x1D5CF78 VA: 0x1D5CF78
	|-Dictionary.ValueCollection<int, uint>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5DD00 Offset: 0x1D5DD00 VA: 0x1D5DD00
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5EA88 Offset: 0x1D5EA88 VA: 0x1D5EA88
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D5F810 Offset: 0x1D5F810 VA: 0x1D5F810
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D60550 Offset: 0x1D60550 VA: 0x1D60550
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D61334 Offset: 0x1D61334 VA: 0x1D61334
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D62128 Offset: 0x1D62128 VA: 0x1D62128
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D62EC4 Offset: 0x1D62EC4 VA: 0x1D62EC4
	|-Dictionary.ValueCollection<long, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D63C58 Offset: 0x1D63C58 VA: 0x1D63C58
	|-Dictionary.ValueCollection<long, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6499C Offset: 0x1D6499C VA: 0x1D6499C
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D65744 Offset: 0x1D65744 VA: 0x1D65744
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D66538 Offset: 0x1D66538 VA: 0x1D66538
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6735C Offset: 0x1D6735C VA: 0x1D6735C
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D681B4 Offset: 0x1D681B4 VA: 0x1D681B4
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D68F4C Offset: 0x1D68F4C VA: 0x1D68F4C
	|-Dictionary.ValueCollection<object, bool>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D69CD4 Offset: 0x1D69CD4 VA: 0x1D69CD4
	|-Dictionary.ValueCollection<object, byte>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6AA60 Offset: 0x1D6AA60 VA: 0x1D6AA60
	|-Dictionary.ValueCollection<object, short>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6B7F0 Offset: 0x1D6B7F0 VA: 0x1D6B7F0
	|-Dictionary.ValueCollection<object, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6C578 Offset: 0x1D6C578 VA: 0x1D6C578
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6D374 Offset: 0x1D6D374 VA: 0x1D6D374
	|-Dictionary.ValueCollection<object, long>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6E108 Offset: 0x1D6E108 VA: 0x1D6E108
	|-Dictionary.ValueCollection<object, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6EEA4 Offset: 0x1D6EEA4 VA: 0x1D6EEA4
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D6FC3C Offset: 0x1D6FC3C VA: 0x1D6FC3C
	|-Dictionary.ValueCollection<object, uint>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D70A20 Offset: 0x1D70A20 VA: 0x1D70A20
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D717B8 Offset: 0x1D717B8 VA: 0x1D717B8
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D72560 Offset: 0x1D72560 VA: 0x1D72560
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x1D73384 Offset: 0x1D73384 VA: 0x1D73384
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x201DD18 Offset: 0x201DD18 VA: 0x201DD18
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x201EAA0 Offset: 0x201EAA0 VA: 0x201EAA0
	|-Dictionary.ValueCollection<uint, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x201F828 Offset: 0x201F828 VA: 0x201F828
	|-Dictionary.ValueCollection<uint, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x202056C Offset: 0x202056C VA: 0x202056C
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x20212B0 Offset: 0x20212B0 VA: 0x20212B0
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x202203C Offset: 0x202203C VA: 0x202203C
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2022D84 Offset: 0x2022D84 VA: 0x2022D84
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2023B18 Offset: 0x2023B18 VA: 0x2023B18
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2024860 Offset: 0x2024860 VA: 0x2024860
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x20255A8 Offset: 0x20255A8 VA: 0x20255A8
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x20262F0 Offset: 0x20262F0 VA: 0x20262F0
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2027038 Offset: 0x2027038 VA: 0x2027038
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2027DCC Offset: 0x2027DCC VA: 0x2027DCC
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.ICollection.CopyTo
	|
	|-RVA: 0x2028B14 Offset: 0x2028B14 VA: 0x2028B14
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.ICollection.CopyTo
	*/

	// RVA: -1 Offset: -1 Slot: 16
	private bool System.Collections.ICollection.get_IsSynchronized() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7ACC Offset: 0x11F7ACC VA: 0x11F7ACC
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11F88C0 Offset: 0x11F88C0 VA: 0x11F88C0
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11F9654 Offset: 0x11F9654 VA: 0x11F9654
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FA39C Offset: 0x11FA39C VA: 0x11FA39C
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FB0E4 Offset: 0x11FB0E4 VA: 0x11FB0E4
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FBE24 Offset: 0x11FBE24 VA: 0x11FBE24
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FCC18 Offset: 0x11FCC18 VA: 0x11FCC18
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FD960 Offset: 0x11FD960 VA: 0x11FD960
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FE6A8 Offset: 0x11FE6A8 VA: 0x11FE6A8
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x11FF3F0 Offset: 0x11FF3F0 VA: 0x11FF3F0
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1200184 Offset: 0x1200184 VA: 0x1200184
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1200ECC Offset: 0x1200ECC VA: 0x1200ECC
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1201C14 Offset: 0x1201C14 VA: 0x1201C14
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1202954 Offset: 0x1202954 VA: 0x1202954
	|-Dictionary.ValueCollection<byte, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x12036DC Offset: 0x12036DC VA: 0x12036DC
	|-Dictionary.ValueCollection<byte, float>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1204464 Offset: 0x1204464 VA: 0x1204464
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x12051A4 Offset: 0x12051A4 VA: 0x12051A4
	|-Dictionary.ValueCollection<char, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1205EEC Offset: 0x1205EEC VA: 0x1205EEC
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1206DB4 Offset: 0x1206DB4 VA: 0x1206DB4
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1207BA8 Offset: 0x1207BA8 VA: 0x1207BA8
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D56848 Offset: 0x1D56848 VA: 0x1D56848
	|-Dictionary.ValueCollection<int, bool>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D575DC Offset: 0x1D575DC VA: 0x1D575DC
	|-Dictionary.ValueCollection<int, char>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D58364 Offset: 0x1D58364 VA: 0x1D58364
	|-Dictionary.ValueCollection<int, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D590EC Offset: 0x1D590EC VA: 0x1D590EC
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D59EF4 Offset: 0x1D59EF4 VA: 0x1D59EF4
	|-Dictionary.ValueCollection<int, long>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5ACEC Offset: 0x1D5ACEC VA: 0x1D5ACEC
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5BA2C Offset: 0x1D5BA2C VA: 0x1D5BA2C
	|-Dictionary.ValueCollection<int, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5C7B4 Offset: 0x1D5C7B4 VA: 0x1D5C7B4
	|-Dictionary.ValueCollection<int, float>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5D53C Offset: 0x1D5D53C VA: 0x1D5D53C
	|-Dictionary.ValueCollection<int, uint>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5E2C4 Offset: 0x1D5E2C4 VA: 0x1D5E2C4
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5F04C Offset: 0x1D5F04C VA: 0x1D5F04C
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D5FD8C Offset: 0x1D5FD8C VA: 0x1D5FD8C
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D60B14 Offset: 0x1D60B14 VA: 0x1D60B14
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D61908 Offset: 0x1D61908 VA: 0x1D61908
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D626FC Offset: 0x1D626FC VA: 0x1D626FC
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D63490 Offset: 0x1D63490 VA: 0x1D63490
	|-Dictionary.ValueCollection<long, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D641D8 Offset: 0x1D641D8 VA: 0x1D641D8
	|-Dictionary.ValueCollection<long, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D64F18 Offset: 0x1D64F18 VA: 0x1D64F18
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D65D18 Offset: 0x1D65D18 VA: 0x1D65D18
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D66B0C Offset: 0x1D66B0C VA: 0x1D66B0C
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D67930 Offset: 0x1D67930 VA: 0x1D67930
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D68788 Offset: 0x1D68788 VA: 0x1D68788
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D69510 Offset: 0x1D69510 VA: 0x1D69510
	|-Dictionary.ValueCollection<object, bool>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6A298 Offset: 0x1D6A298 VA: 0x1D6A298
	|-Dictionary.ValueCollection<object, byte>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6B02C Offset: 0x1D6B02C VA: 0x1D6B02C
	|-Dictionary.ValueCollection<object, short>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6BDB4 Offset: 0x1D6BDB4 VA: 0x1D6BDB4
	|-Dictionary.ValueCollection<object, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6CB3C Offset: 0x1D6CB3C VA: 0x1D6CB3C
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6D944 Offset: 0x1D6D944 VA: 0x1D6D944
	|-Dictionary.ValueCollection<object, long>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6E684 Offset: 0x1D6E684 VA: 0x1D6E684
	|-Dictionary.ValueCollection<object, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D6F478 Offset: 0x1D6F478 VA: 0x1D6F478
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D70200 Offset: 0x1D70200 VA: 0x1D70200
	|-Dictionary.ValueCollection<object, uint>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D70FF4 Offset: 0x1D70FF4 VA: 0x1D70FF4
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D71D34 Offset: 0x1D71D34 VA: 0x1D71D34
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D72B34 Offset: 0x1D72B34 VA: 0x1D72B34
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x1D73958 Offset: 0x1D73958 VA: 0x1D73958
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x201E2DC Offset: 0x201E2DC VA: 0x201E2DC
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x201F064 Offset: 0x201F064 VA: 0x201F064
	|-Dictionary.ValueCollection<uint, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x201FDA4 Offset: 0x201FDA4 VA: 0x201FDA4
	|-Dictionary.ValueCollection<uint, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2020AEC Offset: 0x2020AEC VA: 0x2020AEC
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2021874 Offset: 0x2021874 VA: 0x2021874
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x20225BC Offset: 0x20225BC VA: 0x20225BC
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2023350 Offset: 0x2023350 VA: 0x2023350
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2024098 Offset: 0x2024098 VA: 0x2024098
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2024DE0 Offset: 0x2024DE0 VA: 0x2024DE0
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2025B28 Offset: 0x2025B28 VA: 0x2025B28
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2026870 Offset: 0x2026870 VA: 0x2026870
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2027604 Offset: 0x2027604 VA: 0x2027604
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x202834C Offset: 0x202834C VA: 0x202834C
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.ICollection.get_IsSynchronized
	|
	|-RVA: 0x2029094 Offset: 0x2029094 VA: 0x2029094
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.ICollection.get_IsSynchronized
	*/

	// RVA: -1 Offset: -1 Slot: 15
	private object System.Collections.ICollection.get_SyncRoot() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x11F7AD4 Offset: 0x11F7AD4 VA: 0x11F7AD4
	|-Dictionary.ValueCollection<EntityID, Entity>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11F88C8 Offset: 0x11F88C8 VA: 0x11F88C8
	|-Dictionary.ValueCollection<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11F965C Offset: 0x11F965C VA: 0x11F965C
	|-Dictionary.ValueCollection<U64Id, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FA3A4 Offset: 0x11FA3A4 VA: 0x11FA3A4
	|-Dictionary.ValueCollection<U64Id, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FB0EC Offset: 0x11FB0EC VA: 0x11FB0EC
	|-Dictionary.ValueCollection<LeaderBoardType, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FBE2C Offset: 0x11FBE2C VA: 0x11FBE2C
	|-Dictionary.ValueCollection<TranslateEvent, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FCC20 Offset: 0x11FCC20 VA: 0x11FCC20
	|-Dictionary.ValueCollection<XPathNodeRef, XPathNodeRef>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FD968 Offset: 0x11FD968 VA: 0x11FD968
	|-Dictionary.ValueCollection<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FE6B0 Offset: 0x11FE6B0 VA: 0x11FE6B0
	|-Dictionary.ValueCollection<ResolverContractKey, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x11FF3F8 Offset: 0x11FF3F8 VA: 0x11FF3F8
	|-Dictionary.ValueCollection<ConvertUtils.TypeConvertKey, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x120018C Offset: 0x120018C VA: 0x120018C
	|-Dictionary.ValueCollection<AnimationStateData.AnimationPair, float>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1200ED4 Offset: 0x1200ED4 VA: 0x1200ED4
	|-Dictionary.ValueCollection<Skin.AttachmentKeyTuple, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1201C1C Offset: 0x1201C1C VA: 0x1201C1C
	|-Dictionary.ValueCollection<SlotBlendModes.MaterialTexturePair, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x120295C Offset: 0x120295C VA: 0x120295C
	|-Dictionary.ValueCollection<byte, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x12036E4 Offset: 0x12036E4 VA: 0x12036E4
	|-Dictionary.ValueCollection<byte, float>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x120446C Offset: 0x120446C VA: 0x120446C
	|-Dictionary.ValueCollection<byte, uint>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x12051AC Offset: 0x12051AC VA: 0x12051AC
	|-Dictionary.ValueCollection<char, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1205EF4 Offset: 0x1205EF4 VA: 0x1205EF4
	|-Dictionary.ValueCollection<Guid, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1206DBC Offset: 0x1206DBC VA: 0x1206DBC
	|-Dictionary.ValueCollection<int, UIAvatarCreator.AvatarInfo>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1207BB0 Offset: 0x1207BB0 VA: 0x1207BB0
	|-Dictionary.ValueCollection<int, UIMgr.LayerWithPanels>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D56850 Offset: 0x1D56850 VA: 0x1D56850
	|-Dictionary.ValueCollection<int, bool>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D575E4 Offset: 0x1D575E4 VA: 0x1D575E4
	|-Dictionary.ValueCollection<int, char>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5836C Offset: 0x1D5836C VA: 0x1D5836C
	|-Dictionary.ValueCollection<int, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D590F4 Offset: 0x1D590F4 VA: 0x1D590F4
	|-Dictionary.ValueCollection<int, Int32Enum>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D59EFC Offset: 0x1D59EFC VA: 0x1D59EFC
	|-Dictionary.ValueCollection<int, long>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5ACF4 Offset: 0x1D5ACF4 VA: 0x1D5ACF4
	|-Dictionary.ValueCollection<int, Nullable<U64Id>>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5BA34 Offset: 0x1D5BA34 VA: 0x1D5BA34
	|-Dictionary.ValueCollection<int, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5C7BC Offset: 0x1D5C7BC VA: 0x1D5C7BC
	|-Dictionary.ValueCollection<int, float>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5D544 Offset: 0x1D5D544 VA: 0x1D5D544
	|-Dictionary.ValueCollection<int, uint>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5E2CC Offset: 0x1D5E2CC VA: 0x1D5E2CC
	|-Dictionary.ValueCollection<Int32Enum, bool>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5F054 Offset: 0x1D5F054 VA: 0x1D5F054
	|-Dictionary.ValueCollection<Int32Enum, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D5FD94 Offset: 0x1D5FD94 VA: 0x1D5FD94
	|-Dictionary.ValueCollection<Int32Enum, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D60B1C Offset: 0x1D60B1C VA: 0x1D60B1C
	|-Dictionary.ValueCollection<Int32Enum, uint>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D61910 Offset: 0x1D61910 VA: 0x1D61910
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<int, int>>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D62704 Offset: 0x1D62704 VA: 0x1D62704
	|-Dictionary.ValueCollection<Int32Enum, ValueTuple<float, float>>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D63498 Offset: 0x1D63498 VA: 0x1D63498
	|-Dictionary.ValueCollection<long, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D641E0 Offset: 0x1D641E0 VA: 0x1D641E0
	|-Dictionary.ValueCollection<long, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D64F20 Offset: 0x1D64F20 VA: 0x1D64F20
	|-Dictionary.ValueCollection<IntPtr, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D65D20 Offset: 0x1D65D20 VA: 0x1D65D20
	|-Dictionary.ValueCollection<object, CommandInfo>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D66B14 Offset: 0x1D66B14 VA: 0x1D66B14
	|-Dictionary.ValueCollection<object, GraphAnimator.RootPair>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D67938 Offset: 0x1D67938 VA: 0x1D67938
	|-Dictionary.ValueCollection<object, AriticleBuffContainer.BuffVfx>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D68790 Offset: 0x1D68790 VA: 0x1D68790
	|-Dictionary.ValueCollection<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D69518 Offset: 0x1D69518 VA: 0x1D69518
	|-Dictionary.ValueCollection<object, bool>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6A2A0 Offset: 0x1D6A2A0 VA: 0x1D6A2A0
	|-Dictionary.ValueCollection<object, byte>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6B034 Offset: 0x1D6B034 VA: 0x1D6B034
	|-Dictionary.ValueCollection<object, short>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6BDBC Offset: 0x1D6BDBC VA: 0x1D6BDBC
	|-Dictionary.ValueCollection<object, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6CB44 Offset: 0x1D6CB44 VA: 0x1D6CB44
	|-Dictionary.ValueCollection<object, Int32Enum>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6D94C Offset: 0x1D6D94C VA: 0x1D6D94C
	|-Dictionary.ValueCollection<object, long>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6E68C Offset: 0x1D6E68C VA: 0x1D6E68C
	|-Dictionary.ValueCollection<object, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D6F480 Offset: 0x1D6F480 VA: 0x1D6F480
	|-Dictionary.ValueCollection<object, ResourceLocator>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D70208 Offset: 0x1D70208 VA: 0x1D70208
	|-Dictionary.ValueCollection<object, uint>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D70FFC Offset: 0x1D70FFC VA: 0x1D70FFC
	|-Dictionary.ValueCollection<object, Playable>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D71D3C Offset: 0x1D71D3C VA: 0x1D71D3C
	|-Dictionary.ValueCollection<ushort, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D72B3C Offset: 0x1D72B3C VA: 0x1D72B3C
	|-Dictionary.ValueCollection<uint, CustomValue>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x1D73960 Offset: 0x1D73960 VA: 0x1D73960
	|-Dictionary.ValueCollection<uint, SharedGameObjectSystem.ChannelData>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x201E2E4 Offset: 0x201E2E4 VA: 0x201E2E4
	|-Dictionary.ValueCollection<uint, byte>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x201F06C Offset: 0x201F06C VA: 0x201F06C
	|-Dictionary.ValueCollection<uint, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x201FDAC Offset: 0x201FDAC VA: 0x201FDAC
	|-Dictionary.ValueCollection<uint, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2020AF4 Offset: 0x2020AF4 VA: 0x2020AF4
	|-Dictionary.ValueCollection<ulong, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x202187C Offset: 0x202187C VA: 0x202187C
	|-Dictionary.ValueCollection<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x20225C4 Offset: 0x20225C4 VA: 0x20225C4
	|-Dictionary.ValueCollection<ValueTuple<int, int>, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2023358 Offset: 0x2023358 VA: 0x2023358
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x20240A0 Offset: 0x20240A0 VA: 0x20240A0
	|-Dictionary.ValueCollection<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2024DE8 Offset: 0x2024DE8 VA: 0x2024DE8
	|-Dictionary.ValueCollection<ValueTuple<object, object>, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2025B30 Offset: 0x2025B30 VA: 0x2025B30
	|-Dictionary.ValueCollection<ValueTuple<int, int, int>, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2026878 Offset: 0x2026878 VA: 0x2026878
	|-Dictionary.ValueCollection<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x202760C Offset: 0x202760C VA: 0x202760C
	|-Dictionary.ValueCollection<Vector3, int>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x2028354 Offset: 0x2028354 VA: 0x2028354
	|-Dictionary.ValueCollection<Utils.MethodKey, object>.System.Collections.ICollection.get_SyncRoot
	|
	|-RVA: 0x202909C Offset: 0x202909C VA: 0x202909C
	|-Dictionary.ValueCollection<YamlAttributeOverrides.AttributeKey, object>.System.Collections.ICollection.get_SyncRoot
	*/
}
