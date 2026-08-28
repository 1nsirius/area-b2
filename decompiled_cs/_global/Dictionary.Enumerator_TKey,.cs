// Namespace: 
[Serializable]
public struct Dictionary.Enumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator, IDictionaryEnumerator // TypeDefIndex: 1417
{
	// Fields
	private Dictionary<TKey, TValue> dictionary; // 0x0
	private int version; // 0x0
	private int index; // 0x0
	private KeyValuePair<TKey, TValue> current; // 0x0
	private int getEnumeratorRetType; // 0x0

	// Properties
	public KeyValuePair<TKey, TValue> Current { get; }
	private object System.Collections.IEnumerator.Current { get; }
	private DictionaryEntry System.Collections.IDictionaryEnumerator.Entry { get; }
	private object System.Collections.IDictionaryEnumerator.Key { get; }
	private object System.Collections.IDictionaryEnumerator.Value { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(Dictionary<TKey, TValue> dictionary, int getEnumeratorRetType) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751BC8 Offset: 0x751BC8 VA: 0x751BC8
	|-Dictionary.Enumerator<EntityID, Entity>..ctor
	|
	|-RVA: 0x751C74 Offset: 0x751C74 VA: 0x751C74
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>..ctor
	|
	|-RVA: 0x751D10 Offset: 0x751D10 VA: 0x751D10
	|-Dictionary.Enumerator<U64Id, int>..ctor
	|
	|-RVA: 0x751DAC Offset: 0x751DAC VA: 0x751DAC
	|-Dictionary.Enumerator<U64Id, object>..ctor
	|
	|-RVA: 0x751E48 Offset: 0x751E48 VA: 0x751E48
	|-Dictionary.Enumerator<LeaderBoardType, object>..ctor
	|
	|-RVA: 0x751EE8 Offset: 0x751EE8 VA: 0x751EE8
	|-Dictionary.Enumerator<TranslateEvent, object>..ctor
	|
	|-RVA: 0x751F84 Offset: 0x751F84 VA: 0x751F84
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>..ctor
	|
	|-RVA: 0x752020 Offset: 0x752020 VA: 0x752020
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>..ctor
	|
	|-RVA: 0x7520C0 Offset: 0x7520C0 VA: 0x7520C0
	|-Dictionary.Enumerator<ResolverContractKey, object>..ctor
	|
	|-RVA: 0x752160 Offset: 0x752160 VA: 0x752160
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>..ctor
	|
	|-RVA: 0x752200 Offset: 0x752200 VA: 0x752200
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>..ctor
	|
	|-RVA: 0x7522A0 Offset: 0x7522A0 VA: 0x7522A0
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>..ctor
	|
	|-RVA: 0x75233C Offset: 0x75233C VA: 0x75233C
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>..ctor
	|
	|-RVA: 0x7523DC Offset: 0x7523DC VA: 0x7523DC
	|-Dictionary.Enumerator<byte, object>..ctor
	|
	|-RVA: 0x752478 Offset: 0x752478 VA: 0x752478
	|-Dictionary.Enumerator<byte, float>..ctor
	|
	|-RVA: 0x752514 Offset: 0x752514 VA: 0x752514
	|-Dictionary.Enumerator<byte, uint>..ctor
	|
	|-RVA: 0x7525B0 Offset: 0x7525B0 VA: 0x7525B0
	|-Dictionary.Enumerator<char, object>..ctor
	|
	|-RVA: 0x75264C Offset: 0x75264C VA: 0x75264C
	|-Dictionary.Enumerator<Guid, object>..ctor
	|
	|-RVA: 0x7526F4 Offset: 0x7526F4 VA: 0x7526F4
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>..ctor
	|
	|-RVA: 0x7527B0 Offset: 0x7527B0 VA: 0x7527B0
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>..ctor
	|
	|-RVA: 0x752850 Offset: 0x752850 VA: 0x752850
	|-Dictionary.Enumerator<int, bool>..ctor
	|
	|-RVA: 0x7528EC Offset: 0x7528EC VA: 0x7528EC
	|-Dictionary.Enumerator<int, char>..ctor
	|
	|-RVA: 0x752988 Offset: 0x752988 VA: 0x752988
	|-Dictionary.Enumerator<int, int>..ctor
	|
	|-RVA: 0x752A24 Offset: 0x752A24 VA: 0x752A24
	|-Dictionary.Enumerator<int, Int32Enum>..ctor
	|
	|-RVA: 0x752AC0 Offset: 0x752AC0 VA: 0x752AC0
	|-Dictionary.Enumerator<int, long>..ctor
	|
	|-RVA: 0x752B5C Offset: 0x752B5C VA: 0x752B5C
	|-Dictionary.Enumerator<int, Nullable<U64Id>>..ctor
	|
	|-RVA: 0x752C08 Offset: 0x752C08 VA: 0x752C08
	|-Dictionary.Enumerator<int, object>..ctor
	|
	|-RVA: 0x752CA4 Offset: 0x752CA4 VA: 0x752CA4
	|-Dictionary.Enumerator<int, float>..ctor
	|
	|-RVA: 0x752D40 Offset: 0x752D40 VA: 0x752D40
	|-Dictionary.Enumerator<int, uint>..ctor
	|
	|-RVA: 0x752DDC Offset: 0x752DDC VA: 0x752DDC
	|-Dictionary.Enumerator<Int32Enum, bool>..ctor
	|
	|-RVA: 0x752E78 Offset: 0x752E78 VA: 0x752E78
	|-Dictionary.Enumerator<Int32Enum, int>..ctor
	|
	|-RVA: 0x752F14 Offset: 0x752F14 VA: 0x752F14
	|-Dictionary.Enumerator<Int32Enum, object>..ctor
	|
	|-RVA: 0x752FB0 Offset: 0x752FB0 VA: 0x752FB0
	|-Dictionary.Enumerator<Int32Enum, uint>..ctor
	|
	|-RVA: 0x75304C Offset: 0x75304C VA: 0x75304C
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>..ctor
	|
	|-RVA: 0x7530EC Offset: 0x7530EC VA: 0x7530EC
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>..ctor
	|
	|-RVA: 0x75012C Offset: 0x75012C VA: 0x75012C
	|-Dictionary.Enumerator<long, int>..ctor
	|
	|-RVA: 0x7501C8 Offset: 0x7501C8 VA: 0x7501C8
	|-Dictionary.Enumerator<long, object>..ctor
	|
	|-RVA: 0x750264 Offset: 0x750264 VA: 0x750264
	|-Dictionary.Enumerator<IntPtr, object>..ctor
	|
	|-RVA: 0x750300 Offset: 0x750300 VA: 0x750300
	|-Dictionary.Enumerator<object, CommandInfo>..ctor
	|
	|-RVA: 0x7503A8 Offset: 0x7503A8 VA: 0x7503A8
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>..ctor
	|
	|-RVA: 0x750448 Offset: 0x750448 VA: 0x750448
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>..ctor
	|
	|-RVA: 0x7504E4 Offset: 0x7504E4 VA: 0x7504E4
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>..ctor
	|
	|-RVA: 0x750588 Offset: 0x750588 VA: 0x750588
	|-Dictionary.Enumerator<object, bool>..ctor
	|
	|-RVA: 0x750624 Offset: 0x750624 VA: 0x750624
	|-Dictionary.Enumerator<object, byte>..ctor
	|
	|-RVA: 0x7506C0 Offset: 0x7506C0 VA: 0x7506C0
	|-Dictionary.Enumerator<object, short>..ctor
	|
	|-RVA: 0x75075C Offset: 0x75075C VA: 0x75075C
	|-Dictionary.Enumerator<object, int>..ctor
	|
	|-RVA: 0x7507F8 Offset: 0x7507F8 VA: 0x7507F8
	|-Dictionary.Enumerator<object, Int32Enum>..ctor
	|
	|-RVA: 0x750894 Offset: 0x750894 VA: 0x750894
	|-Dictionary.Enumerator<object, long>..ctor
	|
	|-RVA: 0x750930 Offset: 0x750930 VA: 0x750930
	|-Dictionary.Enumerator<object, object>..ctor
	|
	|-RVA: 0x7509CC Offset: 0x7509CC VA: 0x7509CC
	|-Dictionary.Enumerator<object, ResourceLocator>..ctor
	|
	|-RVA: 0x750A6C Offset: 0x750A6C VA: 0x750A6C
	|-Dictionary.Enumerator<object, uint>..ctor
	|
	|-RVA: 0x750B08 Offset: 0x750B08 VA: 0x750B08
	|-Dictionary.Enumerator<object, Playable>..ctor
	|
	|-RVA: 0x750BA8 Offset: 0x750BA8 VA: 0x750BA8
	|-Dictionary.Enumerator<ushort, object>..ctor
	|
	|-RVA: 0x750C44 Offset: 0x750C44 VA: 0x750C44
	|-Dictionary.Enumerator<uint, CustomValue>..ctor
	|
	|-RVA: 0x750CEC Offset: 0x750CEC VA: 0x750CEC
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>..ctor
	|
	|-RVA: 0x750D88 Offset: 0x750D88 VA: 0x750D88
	|-Dictionary.Enumerator<uint, byte>..ctor
	|
	|-RVA: 0x750E24 Offset: 0x750E24 VA: 0x750E24
	|-Dictionary.Enumerator<uint, int>..ctor
	|
	|-RVA: 0x750EC0 Offset: 0x750EC0 VA: 0x750EC0
	|-Dictionary.Enumerator<uint, object>..ctor
	|
	|-RVA: 0x750F5C Offset: 0x750F5C VA: 0x750F5C
	|-Dictionary.Enumerator<ulong, object>..ctor
	|
	|-RVA: 0x750FF8 Offset: 0x750FF8 VA: 0x750FF8
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>..ctor
	|
	|-RVA: 0x7510A4 Offset: 0x7510A4 VA: 0x7510A4
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>..ctor
	|
	|-RVA: 0x751144 Offset: 0x751144 VA: 0x751144
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>..ctor
	|
	|-RVA: 0x7511E4 Offset: 0x7511E4 VA: 0x7511E4
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>..ctor
	|
	|-RVA: 0x751284 Offset: 0x751284 VA: 0x751284
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>..ctor
	|
	|-RVA: 0x751324 Offset: 0x751324 VA: 0x751324
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>..ctor
	|
	|-RVA: 0x7513C0 Offset: 0x7513C0 VA: 0x7513C0
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>..ctor
	|
	|-RVA: 0x751460 Offset: 0x751460 VA: 0x751460
	|-Dictionary.Enumerator<Vector3, int>..ctor
	|
	|-RVA: 0x7514FC Offset: 0x7514FC VA: 0x7514FC
	|-Dictionary.Enumerator<Utils.MethodKey, object>..ctor
	|
	|-RVA: 0x75159C Offset: 0x75159C VA: 0x75159C
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x750978 Offset: 0x750978 VA: 0x750978
	|-Dictionary.Enumerator<AkAudioListener, AkObstructionOcclusion.ObstructionOcclusionValue>.MoveNext
	|-Dictionary.Enumerator<TrieNode, TrieNode>.MoveNext
	|-Dictionary.Enumerator<WordsSearch.TrieNode, WordsSearch.TrieNode>.MoveNext
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.PostEffBuff>.MoveNext
	|-Dictionary.Enumerator<LightweightTriggerBase, ITrigger>.MoveNext
	|-Dictionary.Enumerator<Bone, Transform>.MoveNext
	|-Dictionary.Enumerator<object, object>.MoveNext
	|-Dictionary.Enumerator<string, ReddotNode>.MoveNext
	|-Dictionary.Enumerator<string, AbstractSceneLoader>.MoveNext
	|-Dictionary.Enumerator<string, AssetBundleProxy>.MoveNext
	|-Dictionary.Enumerator<string, TickTimeEvent>.MoveNext
	|-Dictionary.Enumerator<string, FastStack<IEffect>>.MoveNext
	|-Dictionary.Enumerator<string, Queue<GameObject>>.MoveNext
	|-Dictionary.Enumerator<string, object>.MoveNext
	|-Dictionary.Enumerator<string, string>.MoveNext
	|-Dictionary.Enumerator<string, GameObject>.MoveNext
	|-Dictionary.Enumerator<Type, BaseView>.MoveNext
	|-Dictionary.Enumerator<Type, SprotoTypeReader>.MoveNext
	|-Dictionary.Enumerator<Type, PostProcessBundle>.MoveNext
	|-Dictionary.Enumerator<XmlQualifiedName, SchemaElementDecl>.MoveNext
	|-Dictionary.Enumerator<Collider, ILadder>.MoveNext
	|-Dictionary.Enumerator<Collider, IRefactorReinforcedWall>.MoveNext
	|-Dictionary.Enumerator<GameObject, GameObject>.MoveNext
	|-Dictionary.Enumerator<RectTransform, GameObject>.MoveNext
	|-Dictionary.Enumerator<Text, Action<Text>>.MoveNext
	|-Dictionary.Enumerator<YamlNode, YamlNode>.MoveNext
	|
	|-RVA: 0x751C1C Offset: 0x751C1C VA: 0x751C1C
	|-Dictionary.Enumerator<EntityID, Entity>.MoveNext
	|
	|-RVA: 0x751CC0 Offset: 0x751CC0 VA: 0x751CC0
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.MoveNext
	|
	|-RVA: 0x751DF8 Offset: 0x751DF8 VA: 0x751DF8
	|-Dictionary.Enumerator<U64Id, IAllowSorbEntity>.MoveNext
	|-Dictionary.Enumerator<U64Id, MountedLMGInScene>.MoveNext
	|-Dictionary.Enumerator<U64Id, ScoutCar>.MoveNext
	|-Dictionary.Enumerator<U64Id, ISmokeEntity>.MoveNext
	|-Dictionary.Enumerator<U64Id, ITipUiProxy>.MoveNext
	|-Dictionary.Enumerator<U64Id, object>.MoveNext
	|
	|-RVA: 0x751D5C Offset: 0x751D5C VA: 0x751D5C
	|-Dictionary.Enumerator<U64Id, int>.MoveNext
	|
	|-RVA: 0x751E94 Offset: 0x751E94 VA: 0x751E94
	|-Dictionary.Enumerator<LeaderBoardType, object>.MoveNext
	|
	|-RVA: 0x750494 Offset: 0x750494 VA: 0x750494
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.BuffVfx>.MoveNext
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.MoveNext
	|
	|-RVA: 0x752F5C Offset: 0x752F5C VA: 0x752F5C
	|-Dictionary.Enumerator<SkillIndex, List<ISkillController>>.MoveNext
	|-Dictionary.Enumerator<UIScreenEffectType, BaseUIScreenEffect>.MoveNext
	|-Dictionary.Enumerator<PreBattleStage, PrepareTabBtn>.MoveNext
	|-Dictionary.Enumerator<Int32Enum, object>.MoveNext
	|-Dictionary.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.MoveNext
	|-Dictionary.Enumerator<MonitorType, Monitor>.MoveNext
	|-Dictionary.Enumerator<EntryType, GameObject>.MoveNext
	|
	|-RVA: 0x751F30 Offset: 0x751F30 VA: 0x751F30
	|-Dictionary.Enumerator<TranslateEvent, object>.MoveNext
	|
	|-RVA: 0x751FD0 Offset: 0x751FD0 VA: 0x751FD0
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.MoveNext
	|
	|-RVA: 0x75206C Offset: 0x75206C VA: 0x75206C
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.MoveNext
	|
	|-RVA: 0x750840 Offset: 0x750840 VA: 0x750840
	|-Dictionary.Enumerator<JsonProperty, JsonSerializerInternalReader.PropertyPresence>.MoveNext
	|-Dictionary.Enumerator<object, Int32Enum>.MoveNext
	|
	|-RVA: 0x75210C Offset: 0x75210C VA: 0x75210C
	|-Dictionary.Enumerator<ResolverContractKey, object>.MoveNext
	|
	|-RVA: 0x7521AC Offset: 0x7521AC VA: 0x7521AC
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.MoveNext
	|
	|-RVA: 0x75224C Offset: 0x75224C VA: 0x75224C
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.MoveNext
	|
	|-RVA: 0x7522EC Offset: 0x7522EC VA: 0x7522EC
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, Attachment>.MoveNext
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.MoveNext
	|
	|-RVA: 0x752388 Offset: 0x752388 VA: 0x752388
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.MoveNext
	|
	|-RVA: 0x752424 Offset: 0x752424 VA: 0x752424
	|-Dictionary.Enumerator<byte, RemoteCharacterController>.MoveNext
	|-Dictionary.Enumerator<byte, object>.MoveNext
	|
	|-RVA: 0x7524C0 Offset: 0x7524C0 VA: 0x7524C0
	|-Dictionary.Enumerator<byte, float>.MoveNext
	|
	|-RVA: 0x75255C Offset: 0x75255C VA: 0x75255C
	|-Dictionary.Enumerator<byte, uint>.MoveNext
	|
	|-RVA: 0x7525F8 Offset: 0x7525F8 VA: 0x7525F8
	|-Dictionary.Enumerator<char, IllegalWordsSearchEx.TrieNode>.MoveNext
	|-Dictionary.Enumerator<char, TrieNode>.MoveNext
	|-Dictionary.Enumerator<char, WordsSearch.TrieNode>.MoveNext
	|-Dictionary.Enumerator<char, object>.MoveNext
	|
	|-RVA: 0x75269C Offset: 0x75269C VA: 0x75269C
	|-Dictionary.Enumerator<Guid, object>.MoveNext
	|
	|-RVA: 0x752C50 Offset: 0x752C50 VA: 0x752C50
	|-Dictionary.Enumerator<int, AkCallbackManager.BankCallbackPackage>.MoveNext
	|-Dictionary.Enumerator<int, AkCallbackManager.EventCallbackPackage>.MoveNext
	|-Dictionary.Enumerator<int, ActivityDataManager.ActivityGroup>.MoveNext
	|-Dictionary.Enumerator<int, CharacterEquipmentDataManager.CharacterData>.MoveNext
	|-Dictionary.Enumerator<int, DailyTaskDataManager.GrowthTaskInfo>.MoveNext
	|-Dictionary.Enumerator<int, MatchRoomHeroModelProxy>.MoveNext
	|-Dictionary.Enumerator<int, Body>.MoveNext
	|-Dictionary.Enumerator<int, DecalRenderer>.MoveNext
	|-Dictionary.Enumerator<int, IGameSettingSubView>.MoveNext
	|-Dictionary.Enumerator<int, SampleUIMapView.SwitchButton>.MoveNext
	|-Dictionary.Enumerator<int, LanguageMono>.MoveNext
	|-Dictionary.Enumerator<int, List<PostProcessVolume>>.MoveNext
	|-Dictionary.Enumerator<int, Delegate>.MoveNext
	|-Dictionary.Enumerator<int, int[]>.MoveNext
	|-Dictionary.Enumerator<int, object>.MoveNext
	|-Dictionary.Enumerator<int, Type>.MoveNext
	|-Dictionary.Enumerator<int, WeakReference>.MoveNext
	|-Dictionary.Enumerator<int, PointerEventData>.MoveNext
	|-Dictionary.Enumerator<int, TerrainUtility.TerrainMap>.MoveNext
	|-Dictionary.Enumerator<int, GameObject>.MoveNext
	|
	|-RVA: 0x752750 Offset: 0x752750 VA: 0x752750
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.MoveNext
	|
	|-RVA: 0x7527FC Offset: 0x7527FC VA: 0x7527FC
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.MoveNext
	|
	|-RVA: 0x752898 Offset: 0x752898 VA: 0x752898
	|-Dictionary.Enumerator<int, bool>.MoveNext
	|
	|-RVA: 0x752934 Offset: 0x752934 VA: 0x752934
	|-Dictionary.Enumerator<int, char>.MoveNext
	|
	|-RVA: 0x7529D0 Offset: 0x7529D0 VA: 0x7529D0
	|-Dictionary.Enumerator<int, int>.MoveNext
	|
	|-RVA: 0x752A6C Offset: 0x752A6C VA: 0x752A6C
	|-Dictionary.Enumerator<int, Int32Enum>.MoveNext
	|
	|-RVA: 0x752B0C Offset: 0x752B0C VA: 0x752B0C
	|-Dictionary.Enumerator<int, long>.MoveNext
	|
	|-RVA: 0x752BB0 Offset: 0x752BB0 VA: 0x752BB0
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.MoveNext
	|
	|-RVA: 0x752CEC Offset: 0x752CEC VA: 0x752CEC
	|-Dictionary.Enumerator<int, float>.MoveNext
	|
	|-RVA: 0x752D88 Offset: 0x752D88 VA: 0x752D88
	|-Dictionary.Enumerator<int, uint>.MoveNext
	|
	|-RVA: 0x752E24 Offset: 0x752E24 VA: 0x752E24
	|-Dictionary.Enumerator<Int32Enum, bool>.MoveNext
	|
	|-RVA: 0x752EC0 Offset: 0x752EC0 VA: 0x752EC0
	|-Dictionary.Enumerator<Int32Enum, int>.MoveNext
	|
	|-RVA: 0x752FF8 Offset: 0x752FF8 VA: 0x752FF8
	|-Dictionary.Enumerator<Int32Enum, uint>.MoveNext
	|
	|-RVA: 0x753098 Offset: 0x753098 VA: 0x753098
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.MoveNext
	|
	|-RVA: 0x753138 Offset: 0x753138 VA: 0x753138
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.MoveNext
	|
	|-RVA: 0x750214 Offset: 0x750214 VA: 0x750214
	|-Dictionary.Enumerator<long, PlayerScoreData>.MoveNext
	|-Dictionary.Enumerator<long, GameVoiceData.VoiceInfo>.MoveNext
	|-Dictionary.Enumerator<long, object>.MoveNext
	|
	|-RVA: 0x750178 Offset: 0x750178 VA: 0x750178
	|-Dictionary.Enumerator<long, int>.MoveNext
	|
	|-RVA: 0x7502AC Offset: 0x7502AC VA: 0x7502AC
	|-Dictionary.Enumerator<IntPtr, object>.MoveNext
	|
	|-RVA: 0x750350 Offset: 0x750350 VA: 0x750350
	|-Dictionary.Enumerator<object, CommandInfo>.MoveNext
	|-Dictionary.Enumerator<string, CommandInfo>.MoveNext
	|
	|-RVA: 0x7503F4 Offset: 0x7503F4 VA: 0x7503F4
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.MoveNext
	|
	|-RVA: 0x750530 Offset: 0x750530 VA: 0x750530
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.MoveNext
	|
	|-RVA: 0x7505D0 Offset: 0x7505D0 VA: 0x7505D0
	|-Dictionary.Enumerator<object, bool>.MoveNext
	|-Dictionary.Enumerator<YamlNode, bool>.MoveNext
	|
	|-RVA: 0x75066C Offset: 0x75066C VA: 0x75066C
	|-Dictionary.Enumerator<object, byte>.MoveNext
	|
	|-RVA: 0x750708 Offset: 0x750708 VA: 0x750708
	|-Dictionary.Enumerator<object, short>.MoveNext
	|
	|-RVA: 0x7507A4 Offset: 0x7507A4 VA: 0x7507A4
	|-Dictionary.Enumerator<object, int>.MoveNext
	|-Dictionary.Enumerator<string, int>.MoveNext
	|-Dictionary.Enumerator<Collider, int>.MoveNext
	|-Dictionary.Enumerator<RectTransform, int>.MoveNext
	|
	|-RVA: 0x7508E0 Offset: 0x7508E0 VA: 0x7508E0
	|-Dictionary.Enumerator<object, long>.MoveNext
	|-Dictionary.Enumerator<string, long>.MoveNext
	|
	|-RVA: 0x750A18 Offset: 0x750A18 VA: 0x750A18
	|-Dictionary.Enumerator<object, ResourceLocator>.MoveNext
	|
	|-RVA: 0x750AB4 Offset: 0x750AB4 VA: 0x750AB4
	|-Dictionary.Enumerator<object, uint>.MoveNext
	|-Dictionary.Enumerator<string, uint>.MoveNext
	|
	|-RVA: 0x750B54 Offset: 0x750B54 VA: 0x750B54
	|-Dictionary.Enumerator<object, Playable>.MoveNext
	|
	|-RVA: 0x750BF0 Offset: 0x750BF0 VA: 0x750BF0
	|-Dictionary.Enumerator<ushort, LocalToolBaseCtrlr>.MoveNext
	|-Dictionary.Enumerator<ushort, RemoteToolBaseCtrlr>.MoveNext
	|-Dictionary.Enumerator<ushort, ToolBase>.MoveNext
	|-Dictionary.Enumerator<ushort, object>.MoveNext
	|
	|-RVA: 0x750F08 Offset: 0x750F08 VA: 0x750F08
	|-Dictionary.Enumerator<uint, BattlePlayerIcon>.MoveNext
	|-Dictionary.Enumerator<uint, BattleZoneData.BattleZoneInfo>.MoveNext
	|-Dictionary.Enumerator<uint, BuffData>.MoveNext
	|-Dictionary.Enumerator<uint, BattleTeam.PlayerInfo>.MoveNext
	|-Dictionary.Enumerator<uint, UIBuffEffCtrlBase>.MoveNext
	|-Dictionary.Enumerator<uint, ValueSliderControl>.MoveNext
	|-Dictionary.Enumerator<uint, IEntity>.MoveNext
	|-Dictionary.Enumerator<uint, HashSet<int>>.MoveNext
	|-Dictionary.Enumerator<uint, List<int>>.MoveNext
	|-Dictionary.Enumerator<uint, object>.MoveNext
	|-Dictionary.Enumerator<uint, string>.MoveNext
	|-Dictionary.Enumerator<uint, GameObject>.MoveNext
	|
	|-RVA: 0x750C94 Offset: 0x750C94 VA: 0x750C94
	|-Dictionary.Enumerator<uint, CustomValue>.MoveNext
	|
	|-RVA: 0x750D38 Offset: 0x750D38 VA: 0x750D38
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.MoveNext
	|
	|-RVA: 0x750DD0 Offset: 0x750DD0 VA: 0x750DD0
	|-Dictionary.Enumerator<uint, byte>.MoveNext
	|
	|-RVA: 0x750E6C Offset: 0x750E6C VA: 0x750E6C
	|-Dictionary.Enumerator<uint, int>.MoveNext
	|
	|-RVA: 0x750FA8 Offset: 0x750FA8 VA: 0x750FA8
	|-Dictionary.Enumerator<ulong, object>.MoveNext
	|
	|-RVA: 0x75104C Offset: 0x75104C VA: 0x75104C
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.MoveNext
	|
	|-RVA: 0x7510F0 Offset: 0x7510F0 VA: 0x7510F0
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.MoveNext
	|
	|-RVA: 0x751190 Offset: 0x751190 VA: 0x751190
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.MoveNext
	|
	|-RVA: 0x751230 Offset: 0x751230 VA: 0x751230
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.MoveNext
	|
	|-RVA: 0x7512D0 Offset: 0x7512D0 VA: 0x7512D0
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.MoveNext
	|-Dictionary.Enumerator<ValueTuple<string, Type>, IAssetLoadAction>.MoveNext
	|
	|-RVA: 0x751370 Offset: 0x751370 VA: 0x751370
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, List<ILightweightTrigger>>.MoveNext
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.MoveNext
	|
	|-RVA: 0x75140C Offset: 0x75140C VA: 0x75140C
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.MoveNext
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.MoveNext
	|
	|-RVA: 0x7514AC Offset: 0x7514AC VA: 0x7514AC
	|-Dictionary.Enumerator<Vector3, int>.MoveNext
	|
	|-RVA: 0x751548 Offset: 0x751548 VA: 0x751548
	|-Dictionary.Enumerator<Utils.MethodKey, List<MemberInfo>>.MoveNext
	|-Dictionary.Enumerator<Utils.MethodKey, object>.MoveNext
	|
	|-RVA: 0x7515E8 Offset: 0x7515E8 VA: 0x7515E8
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, List<YamlAttributeOverrides.AttributeMapping>>.MoveNext
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.MoveNext
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public KeyValuePair<TKey, TValue> get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x750980 Offset: 0x750980 VA: 0x750980
	|-Dictionary.Enumerator<AkAudioListener, AkObstructionOcclusion.ObstructionOcclusionValue>.get_Current
	|-Dictionary.Enumerator<TrieNode, TrieNode>.get_Current
	|-Dictionary.Enumerator<WordsSearch.TrieNode, WordsSearch.TrieNode>.get_Current
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.PostEffBuff>.get_Current
	|-Dictionary.Enumerator<LightweightTriggerBase, ITrigger>.get_Current
	|-Dictionary.Enumerator<Bone, Transform>.get_Current
	|-Dictionary.Enumerator<string, ReddotNode>.get_Current
	|-Dictionary.Enumerator<string, AbstractSceneLoader>.get_Current
	|-Dictionary.Enumerator<string, AssetBundleProxy>.get_Current
	|-Dictionary.Enumerator<string, TickTimeEvent>.get_Current
	|-Dictionary.Enumerator<string, FastStack<IEffect>>.get_Current
	|-Dictionary.Enumerator<string, Queue<GameObject>>.get_Current
	|-Dictionary.Enumerator<string, object>.get_Current
	|-Dictionary.Enumerator<string, GameObject>.get_Current
	|-Dictionary.Enumerator<Type, BaseView>.get_Current
	|-Dictionary.Enumerator<Type, SprotoTypeReader>.get_Current
	|-Dictionary.Enumerator<Type, PostProcessBundle>.get_Current
	|-Dictionary.Enumerator<XmlQualifiedName, SchemaElementDecl>.get_Current
	|-Dictionary.Enumerator<Collider, ILadder>.get_Current
	|-Dictionary.Enumerator<Collider, IRefactorReinforcedWall>.get_Current
	|-Dictionary.Enumerator<GameObject, GameObject>.get_Current
	|-Dictionary.Enumerator<RectTransform, GameObject>.get_Current
	|-Dictionary.Enumerator<Text, Action<Text>>.get_Current
	|-Dictionary.Enumerator<YamlNode, YamlNode>.get_Current
	|-Dictionary.Enumerator<object, object>.get_Current
	|-Dictionary.Enumerator<string, string>.get_Current
	|
	|-RVA: 0x751E00 Offset: 0x751E00 VA: 0x751E00
	|-Dictionary.Enumerator<U64Id, IAllowSorbEntity>.get_Current
	|-Dictionary.Enumerator<U64Id, MountedLMGInScene>.get_Current
	|-Dictionary.Enumerator<U64Id, ScoutCar>.get_Current
	|-Dictionary.Enumerator<U64Id, ISmokeEntity>.get_Current
	|-Dictionary.Enumerator<U64Id, ITipUiProxy>.get_Current
	|-Dictionary.Enumerator<U64Id, object>.get_Current
	|
	|-RVA: 0x75049C Offset: 0x75049C VA: 0x75049C
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.BuffVfx>.get_Current
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.get_Current
	|
	|-RVA: 0x752F64 Offset: 0x752F64 VA: 0x752F64
	|-Dictionary.Enumerator<SkillIndex, List<ISkillController>>.get_Current
	|-Dictionary.Enumerator<UIScreenEffectType, BaseUIScreenEffect>.get_Current
	|-Dictionary.Enumerator<PreBattleStage, PrepareTabBtn>.get_Current
	|-Dictionary.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.get_Current
	|-Dictionary.Enumerator<MonitorType, Monitor>.get_Current
	|-Dictionary.Enumerator<EntryType, GameObject>.get_Current
	|-Dictionary.Enumerator<Int32Enum, object>.get_Current
	|
	|-RVA: 0x750848 Offset: 0x750848 VA: 0x750848
	|-Dictionary.Enumerator<JsonProperty, JsonSerializerInternalReader.PropertyPresence>.get_Current
	|-Dictionary.Enumerator<object, Int32Enum>.get_Current
	|
	|-RVA: 0x7522F4 Offset: 0x7522F4 VA: 0x7522F4
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, Attachment>.get_Current
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.get_Current
	|
	|-RVA: 0x75242C Offset: 0x75242C VA: 0x75242C
	|-Dictionary.Enumerator<byte, RemoteCharacterController>.get_Current
	|-Dictionary.Enumerator<byte, object>.get_Current
	|
	|-RVA: 0x752600 Offset: 0x752600 VA: 0x752600
	|-Dictionary.Enumerator<char, IllegalWordsSearchEx.TrieNode>.get_Current
	|-Dictionary.Enumerator<char, TrieNode>.get_Current
	|-Dictionary.Enumerator<char, WordsSearch.TrieNode>.get_Current
	|-Dictionary.Enumerator<char, object>.get_Current
	|
	|-RVA: 0x752C58 Offset: 0x752C58 VA: 0x752C58
	|-Dictionary.Enumerator<int, AkCallbackManager.BankCallbackPackage>.get_Current
	|-Dictionary.Enumerator<int, AkCallbackManager.EventCallbackPackage>.get_Current
	|-Dictionary.Enumerator<int, ActivityDataManager.ActivityGroup>.get_Current
	|-Dictionary.Enumerator<int, CharacterEquipmentDataManager.CharacterData>.get_Current
	|-Dictionary.Enumerator<int, DailyTaskDataManager.GrowthTaskInfo>.get_Current
	|-Dictionary.Enumerator<int, MatchRoomHeroModelProxy>.get_Current
	|-Dictionary.Enumerator<int, Body>.get_Current
	|-Dictionary.Enumerator<int, DecalRenderer>.get_Current
	|-Dictionary.Enumerator<int, IGameSettingSubView>.get_Current
	|-Dictionary.Enumerator<int, SampleUIMapView.SwitchButton>.get_Current
	|-Dictionary.Enumerator<int, LanguageMono>.get_Current
	|-Dictionary.Enumerator<int, List<PostProcessVolume>>.get_Current
	|-Dictionary.Enumerator<int, Delegate>.get_Current
	|-Dictionary.Enumerator<int, int[]>.get_Current
	|-Dictionary.Enumerator<int, Type>.get_Current
	|-Dictionary.Enumerator<int, WeakReference>.get_Current
	|-Dictionary.Enumerator<int, PointerEventData>.get_Current
	|-Dictionary.Enumerator<int, TerrainUtility.TerrainMap>.get_Current
	|-Dictionary.Enumerator<int, GameObject>.get_Current
	|-Dictionary.Enumerator<int, object>.get_Current
	|
	|-RVA: 0x7528A0 Offset: 0x7528A0 VA: 0x7528A0
	|-Dictionary.Enumerator<int, bool>.get_Current
	|
	|-RVA: 0x7529D8 Offset: 0x7529D8 VA: 0x7529D8
	|-Dictionary.Enumerator<int, int>.get_Current
	|
	|-RVA: 0x752B14 Offset: 0x752B14 VA: 0x752B14
	|-Dictionary.Enumerator<int, long>.get_Current
	|
	|-RVA: 0x752CF4 Offset: 0x752CF4 VA: 0x752CF4
	|-Dictionary.Enumerator<int, float>.get_Current
	|
	|-RVA: 0x75021C Offset: 0x75021C VA: 0x75021C
	|-Dictionary.Enumerator<long, PlayerScoreData>.get_Current
	|-Dictionary.Enumerator<long, GameVoiceData.VoiceInfo>.get_Current
	|-Dictionary.Enumerator<long, object>.get_Current
	|
	|-RVA: 0x750358 Offset: 0x750358 VA: 0x750358
	|-Dictionary.Enumerator<string, CommandInfo>.get_Current
	|-Dictionary.Enumerator<object, CommandInfo>.get_Current
	|
	|-RVA: 0x7507AC Offset: 0x7507AC VA: 0x7507AC
	|-Dictionary.Enumerator<string, int>.get_Current
	|-Dictionary.Enumerator<Collider, int>.get_Current
	|-Dictionary.Enumerator<RectTransform, int>.get_Current
	|-Dictionary.Enumerator<object, int>.get_Current
	|
	|-RVA: 0x7508E8 Offset: 0x7508E8 VA: 0x7508E8
	|-Dictionary.Enumerator<string, long>.get_Current
	|-Dictionary.Enumerator<object, long>.get_Current
	|
	|-RVA: 0x750ABC Offset: 0x750ABC VA: 0x750ABC
	|-Dictionary.Enumerator<string, uint>.get_Current
	|-Dictionary.Enumerator<object, uint>.get_Current
	|
	|-RVA: 0x750BF8 Offset: 0x750BF8 VA: 0x750BF8
	|-Dictionary.Enumerator<ushort, LocalToolBaseCtrlr>.get_Current
	|-Dictionary.Enumerator<ushort, RemoteToolBaseCtrlr>.get_Current
	|-Dictionary.Enumerator<ushort, ToolBase>.get_Current
	|-Dictionary.Enumerator<ushort, object>.get_Current
	|
	|-RVA: 0x750F10 Offset: 0x750F10 VA: 0x750F10
	|-Dictionary.Enumerator<uint, BattlePlayerIcon>.get_Current
	|-Dictionary.Enumerator<uint, BattleZoneData.BattleZoneInfo>.get_Current
	|-Dictionary.Enumerator<uint, BuffData>.get_Current
	|-Dictionary.Enumerator<uint, BattleTeam.PlayerInfo>.get_Current
	|-Dictionary.Enumerator<uint, UIBuffEffCtrlBase>.get_Current
	|-Dictionary.Enumerator<uint, ValueSliderControl>.get_Current
	|-Dictionary.Enumerator<uint, IEntity>.get_Current
	|-Dictionary.Enumerator<uint, HashSet<int>>.get_Current
	|-Dictionary.Enumerator<uint, List<int>>.get_Current
	|-Dictionary.Enumerator<uint, string>.get_Current
	|-Dictionary.Enumerator<uint, GameObject>.get_Current
	|-Dictionary.Enumerator<uint, object>.get_Current
	|
	|-RVA: 0x7512D8 Offset: 0x7512D8 VA: 0x7512D8
	|-Dictionary.Enumerator<ValueTuple<string, Type>, IAssetLoadAction>.get_Current
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.get_Current
	|
	|-RVA: 0x751378 Offset: 0x751378 VA: 0x751378
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, List<ILightweightTrigger>>.get_Current
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.get_Current
	|
	|-RVA: 0x751414 Offset: 0x751414 VA: 0x751414
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.get_Current
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.get_Current
	|
	|-RVA: 0x751550 Offset: 0x751550 VA: 0x751550
	|-Dictionary.Enumerator<Utils.MethodKey, List<MemberInfo>>.get_Current
	|-Dictionary.Enumerator<Utils.MethodKey, object>.get_Current
	|
	|-RVA: 0x7505D8 Offset: 0x7505D8 VA: 0x7505D8
	|-Dictionary.Enumerator<YamlNode, bool>.get_Current
	|-Dictionary.Enumerator<object, bool>.get_Current
	|
	|-RVA: 0x7515F0 Offset: 0x7515F0 VA: 0x7515F0
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, List<YamlAttributeOverrides.AttributeMapping>>.get_Current
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.get_Current
	|
	|-RVA: 0x751C24 Offset: 0x751C24 VA: 0x751C24
	|-Dictionary.Enumerator<EntityID, Entity>.get_Current
	|
	|-RVA: 0x751CC8 Offset: 0x751CC8 VA: 0x751CC8
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.get_Current
	|
	|-RVA: 0x751D64 Offset: 0x751D64 VA: 0x751D64
	|-Dictionary.Enumerator<U64Id, int>.get_Current
	|
	|-RVA: 0x751E9C Offset: 0x751E9C VA: 0x751E9C
	|-Dictionary.Enumerator<LeaderBoardType, object>.get_Current
	|
	|-RVA: 0x751F38 Offset: 0x751F38 VA: 0x751F38
	|-Dictionary.Enumerator<TranslateEvent, object>.get_Current
	|
	|-RVA: 0x751FD8 Offset: 0x751FD8 VA: 0x751FD8
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.get_Current
	|
	|-RVA: 0x752074 Offset: 0x752074 VA: 0x752074
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.get_Current
	|
	|-RVA: 0x752114 Offset: 0x752114 VA: 0x752114
	|-Dictionary.Enumerator<ResolverContractKey, object>.get_Current
	|
	|-RVA: 0x7521B4 Offset: 0x7521B4 VA: 0x7521B4
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.get_Current
	|
	|-RVA: 0x752254 Offset: 0x752254 VA: 0x752254
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.get_Current
	|
	|-RVA: 0x752390 Offset: 0x752390 VA: 0x752390
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.get_Current
	|
	|-RVA: 0x7524C8 Offset: 0x7524C8 VA: 0x7524C8
	|-Dictionary.Enumerator<byte, float>.get_Current
	|
	|-RVA: 0x752564 Offset: 0x752564 VA: 0x752564
	|-Dictionary.Enumerator<byte, uint>.get_Current
	|
	|-RVA: 0x7526A4 Offset: 0x7526A4 VA: 0x7526A4
	|-Dictionary.Enumerator<Guid, object>.get_Current
	|
	|-RVA: 0x752758 Offset: 0x752758 VA: 0x752758
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.get_Current
	|
	|-RVA: 0x752804 Offset: 0x752804 VA: 0x752804
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.get_Current
	|
	|-RVA: 0x75293C Offset: 0x75293C VA: 0x75293C
	|-Dictionary.Enumerator<int, char>.get_Current
	|
	|-RVA: 0x752A74 Offset: 0x752A74 VA: 0x752A74
	|-Dictionary.Enumerator<int, Int32Enum>.get_Current
	|
	|-RVA: 0x752BB8 Offset: 0x752BB8 VA: 0x752BB8
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.get_Current
	|
	|-RVA: 0x752D90 Offset: 0x752D90 VA: 0x752D90
	|-Dictionary.Enumerator<int, uint>.get_Current
	|
	|-RVA: 0x752E2C Offset: 0x752E2C VA: 0x752E2C
	|-Dictionary.Enumerator<Int32Enum, bool>.get_Current
	|
	|-RVA: 0x752EC8 Offset: 0x752EC8 VA: 0x752EC8
	|-Dictionary.Enumerator<Int32Enum, int>.get_Current
	|
	|-RVA: 0x753000 Offset: 0x753000 VA: 0x753000
	|-Dictionary.Enumerator<Int32Enum, uint>.get_Current
	|
	|-RVA: 0x7530A0 Offset: 0x7530A0 VA: 0x7530A0
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.get_Current
	|
	|-RVA: 0x753140 Offset: 0x753140 VA: 0x753140
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.get_Current
	|
	|-RVA: 0x750180 Offset: 0x750180 VA: 0x750180
	|-Dictionary.Enumerator<long, int>.get_Current
	|
	|-RVA: 0x7502B4 Offset: 0x7502B4 VA: 0x7502B4
	|-Dictionary.Enumerator<IntPtr, object>.get_Current
	|
	|-RVA: 0x7503FC Offset: 0x7503FC VA: 0x7503FC
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.get_Current
	|
	|-RVA: 0x750538 Offset: 0x750538 VA: 0x750538
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.get_Current
	|
	|-RVA: 0x750674 Offset: 0x750674 VA: 0x750674
	|-Dictionary.Enumerator<object, byte>.get_Current
	|
	|-RVA: 0x750710 Offset: 0x750710 VA: 0x750710
	|-Dictionary.Enumerator<object, short>.get_Current
	|
	|-RVA: 0x750A20 Offset: 0x750A20 VA: 0x750A20
	|-Dictionary.Enumerator<object, ResourceLocator>.get_Current
	|
	|-RVA: 0x750B5C Offset: 0x750B5C VA: 0x750B5C
	|-Dictionary.Enumerator<object, Playable>.get_Current
	|
	|-RVA: 0x750C9C Offset: 0x750C9C VA: 0x750C9C
	|-Dictionary.Enumerator<uint, CustomValue>.get_Current
	|
	|-RVA: 0x750D40 Offset: 0x750D40 VA: 0x750D40
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.get_Current
	|
	|-RVA: 0x750DD8 Offset: 0x750DD8 VA: 0x750DD8
	|-Dictionary.Enumerator<uint, byte>.get_Current
	|
	|-RVA: 0x750E74 Offset: 0x750E74 VA: 0x750E74
	|-Dictionary.Enumerator<uint, int>.get_Current
	|
	|-RVA: 0x750FB0 Offset: 0x750FB0 VA: 0x750FB0
	|-Dictionary.Enumerator<ulong, object>.get_Current
	|
	|-RVA: 0x751054 Offset: 0x751054 VA: 0x751054
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.get_Current
	|
	|-RVA: 0x7510F8 Offset: 0x7510F8 VA: 0x7510F8
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.get_Current
	|
	|-RVA: 0x751198 Offset: 0x751198 VA: 0x751198
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.get_Current
	|
	|-RVA: 0x751238 Offset: 0x751238 VA: 0x751238
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.get_Current
	|
	|-RVA: 0x7514B4 Offset: 0x7514B4 VA: 0x7514B4
	|-Dictionary.Enumerator<Vector3, int>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x750994 Offset: 0x750994 VA: 0x750994
	|-Dictionary.Enumerator<AkAudioListener, AkObstructionOcclusion.ObstructionOcclusionValue>.Dispose
	|-Dictionary.Enumerator<TrieNode, TrieNode>.Dispose
	|-Dictionary.Enumerator<WordsSearch.TrieNode, WordsSearch.TrieNode>.Dispose
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.PostEffBuff>.Dispose
	|-Dictionary.Enumerator<LightweightTriggerBase, ITrigger>.Dispose
	|-Dictionary.Enumerator<Bone, Transform>.Dispose
	|-Dictionary.Enumerator<object, object>.Dispose
	|-Dictionary.Enumerator<string, AbstractSceneLoader>.Dispose
	|-Dictionary.Enumerator<string, AssetBundleProxy>.Dispose
	|-Dictionary.Enumerator<string, FastStack<IEffect>>.Dispose
	|-Dictionary.Enumerator<string, Queue<GameObject>>.Dispose
	|-Dictionary.Enumerator<string, object>.Dispose
	|-Dictionary.Enumerator<string, string>.Dispose
	|-Dictionary.Enumerator<string, GameObject>.Dispose
	|-Dictionary.Enumerator<Type, BaseView>.Dispose
	|-Dictionary.Enumerator<Type, PostProcessBundle>.Dispose
	|-Dictionary.Enumerator<XmlQualifiedName, SchemaElementDecl>.Dispose
	|-Dictionary.Enumerator<Collider, ILadder>.Dispose
	|-Dictionary.Enumerator<Collider, IRefactorReinforcedWall>.Dispose
	|-Dictionary.Enumerator<GameObject, GameObject>.Dispose
	|-Dictionary.Enumerator<RectTransform, GameObject>.Dispose
	|-Dictionary.Enumerator<Text, Action<Text>>.Dispose
	|-Dictionary.Enumerator<YamlNode, YamlNode>.Dispose
	|
	|-RVA: 0x751C3C Offset: 0x751C3C VA: 0x751C3C
	|-Dictionary.Enumerator<EntityID, Entity>.Dispose
	|
	|-RVA: 0x751CD8 Offset: 0x751CD8 VA: 0x751CD8
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.Dispose
	|
	|-RVA: 0x751E10 Offset: 0x751E10 VA: 0x751E10
	|-Dictionary.Enumerator<U64Id, IAllowSorbEntity>.Dispose
	|-Dictionary.Enumerator<U64Id, MountedLMGInScene>.Dispose
	|-Dictionary.Enumerator<U64Id, ScoutCar>.Dispose
	|-Dictionary.Enumerator<U64Id, ISmokeEntity>.Dispose
	|-Dictionary.Enumerator<U64Id, ITipUiProxy>.Dispose
	|-Dictionary.Enumerator<U64Id, object>.Dispose
	|
	|-RVA: 0x751D74 Offset: 0x751D74 VA: 0x751D74
	|-Dictionary.Enumerator<U64Id, int>.Dispose
	|
	|-RVA: 0x751EB0 Offset: 0x751EB0 VA: 0x751EB0
	|-Dictionary.Enumerator<LeaderBoardType, object>.Dispose
	|
	|-RVA: 0x7504AC Offset: 0x7504AC VA: 0x7504AC
	|-Dictionary.Enumerator<BuffData, AriticleBuffContainer.BuffVfx>.Dispose
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.Dispose
	|
	|-RVA: 0x752F78 Offset: 0x752F78 VA: 0x752F78
	|-Dictionary.Enumerator<SkillIndex, List<ISkillController>>.Dispose
	|-Dictionary.Enumerator<UIScreenEffectType, BaseUIScreenEffect>.Dispose
	|-Dictionary.Enumerator<PreBattleStage, PrepareTabBtn>.Dispose
	|-Dictionary.Enumerator<Int32Enum, object>.Dispose
	|-Dictionary.Enumerator<UIBattleFPControl.ESkillBtnEnum, SkillButton>.Dispose
	|-Dictionary.Enumerator<MonitorType, Monitor>.Dispose
	|-Dictionary.Enumerator<EntryType, GameObject>.Dispose
	|
	|-RVA: 0x751F4C Offset: 0x751F4C VA: 0x751F4C
	|-Dictionary.Enumerator<TranslateEvent, object>.Dispose
	|
	|-RVA: 0x751FE8 Offset: 0x751FE8 VA: 0x751FE8
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.Dispose
	|
	|-RVA: 0x752088 Offset: 0x752088 VA: 0x752088
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.Dispose
	|
	|-RVA: 0x75085C Offset: 0x75085C VA: 0x75085C
	|-Dictionary.Enumerator<JsonProperty, JsonSerializerInternalReader.PropertyPresence>.Dispose
	|-Dictionary.Enumerator<object, Int32Enum>.Dispose
	|
	|-RVA: 0x752128 Offset: 0x752128 VA: 0x752128
	|-Dictionary.Enumerator<ResolverContractKey, object>.Dispose
	|
	|-RVA: 0x7521C8 Offset: 0x7521C8 VA: 0x7521C8
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.Dispose
	|
	|-RVA: 0x752268 Offset: 0x752268 VA: 0x752268
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.Dispose
	|
	|-RVA: 0x752304 Offset: 0x752304 VA: 0x752304
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, Attachment>.Dispose
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.Dispose
	|
	|-RVA: 0x7523A4 Offset: 0x7523A4 VA: 0x7523A4
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.Dispose
	|
	|-RVA: 0x752440 Offset: 0x752440 VA: 0x752440
	|-Dictionary.Enumerator<byte, RemoteCharacterController>.Dispose
	|-Dictionary.Enumerator<byte, object>.Dispose
	|
	|-RVA: 0x7524DC Offset: 0x7524DC VA: 0x7524DC
	|-Dictionary.Enumerator<byte, float>.Dispose
	|
	|-RVA: 0x752578 Offset: 0x752578 VA: 0x752578
	|-Dictionary.Enumerator<byte, uint>.Dispose
	|
	|-RVA: 0x752614 Offset: 0x752614 VA: 0x752614
	|-Dictionary.Enumerator<char, IllegalWordsSearchEx.TrieNode>.Dispose
	|-Dictionary.Enumerator<char, TrieNode>.Dispose
	|-Dictionary.Enumerator<char, WordsSearch.TrieNode>.Dispose
	|-Dictionary.Enumerator<char, object>.Dispose
	|
	|-RVA: 0x7526BC Offset: 0x7526BC VA: 0x7526BC
	|-Dictionary.Enumerator<Guid, object>.Dispose
	|
	|-RVA: 0x752C6C Offset: 0x752C6C VA: 0x752C6C
	|-Dictionary.Enumerator<int, AkCallbackManager.BankCallbackPackage>.Dispose
	|-Dictionary.Enumerator<int, AkCallbackManager.EventCallbackPackage>.Dispose
	|-Dictionary.Enumerator<int, MatchRoomHeroModelProxy>.Dispose
	|-Dictionary.Enumerator<int, Body>.Dispose
	|-Dictionary.Enumerator<int, DecalRenderer>.Dispose
	|-Dictionary.Enumerator<int, IGameSettingSubView>.Dispose
	|-Dictionary.Enumerator<int, SampleUIMapView.SwitchButton>.Dispose
	|-Dictionary.Enumerator<int, LanguageMono>.Dispose
	|-Dictionary.Enumerator<int, List<PostProcessVolume>>.Dispose
	|-Dictionary.Enumerator<int, Delegate>.Dispose
	|-Dictionary.Enumerator<int, int[]>.Dispose
	|-Dictionary.Enumerator<int, object>.Dispose
	|-Dictionary.Enumerator<int, Type>.Dispose
	|-Dictionary.Enumerator<int, WeakReference>.Dispose
	|-Dictionary.Enumerator<int, PointerEventData>.Dispose
	|-Dictionary.Enumerator<int, TerrainUtility.TerrainMap>.Dispose
	|-Dictionary.Enumerator<int, GameObject>.Dispose
	|
	|-RVA: 0x752778 Offset: 0x752778 VA: 0x752778
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.Dispose
	|
	|-RVA: 0x752818 Offset: 0x752818 VA: 0x752818
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.Dispose
	|
	|-RVA: 0x7528B4 Offset: 0x7528B4 VA: 0x7528B4
	|-Dictionary.Enumerator<int, bool>.Dispose
	|
	|-RVA: 0x752950 Offset: 0x752950 VA: 0x752950
	|-Dictionary.Enumerator<int, char>.Dispose
	|
	|-RVA: 0x7529EC Offset: 0x7529EC VA: 0x7529EC
	|-Dictionary.Enumerator<int, int>.Dispose
	|
	|-RVA: 0x752A88 Offset: 0x752A88 VA: 0x752A88
	|-Dictionary.Enumerator<int, Int32Enum>.Dispose
	|
	|-RVA: 0x752B24 Offset: 0x752B24 VA: 0x752B24
	|-Dictionary.Enumerator<int, long>.Dispose
	|
	|-RVA: 0x752BD0 Offset: 0x752BD0 VA: 0x752BD0
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.Dispose
	|
	|-RVA: 0x752D08 Offset: 0x752D08 VA: 0x752D08
	|-Dictionary.Enumerator<int, float>.Dispose
	|
	|-RVA: 0x752DA4 Offset: 0x752DA4 VA: 0x752DA4
	|-Dictionary.Enumerator<int, uint>.Dispose
	|
	|-RVA: 0x752E40 Offset: 0x752E40 VA: 0x752E40
	|-Dictionary.Enumerator<Int32Enum, bool>.Dispose
	|
	|-RVA: 0x752EDC Offset: 0x752EDC VA: 0x752EDC
	|-Dictionary.Enumerator<Int32Enum, int>.Dispose
	|
	|-RVA: 0x753014 Offset: 0x753014 VA: 0x753014
	|-Dictionary.Enumerator<Int32Enum, uint>.Dispose
	|
	|-RVA: 0x7530B4 Offset: 0x7530B4 VA: 0x7530B4
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.Dispose
	|
	|-RVA: 0x753154 Offset: 0x753154 VA: 0x753154
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.Dispose
	|
	|-RVA: 0x75022C Offset: 0x75022C VA: 0x75022C
	|-Dictionary.Enumerator<long, PlayerScoreData>.Dispose
	|-Dictionary.Enumerator<long, GameVoiceData.VoiceInfo>.Dispose
	|-Dictionary.Enumerator<long, object>.Dispose
	|
	|-RVA: 0x750190 Offset: 0x750190 VA: 0x750190
	|-Dictionary.Enumerator<long, int>.Dispose
	|
	|-RVA: 0x7502C8 Offset: 0x7502C8 VA: 0x7502C8
	|-Dictionary.Enumerator<IntPtr, object>.Dispose
	|
	|-RVA: 0x750370 Offset: 0x750370 VA: 0x750370
	|-Dictionary.Enumerator<object, CommandInfo>.Dispose
	|-Dictionary.Enumerator<string, CommandInfo>.Dispose
	|
	|-RVA: 0x750410 Offset: 0x750410 VA: 0x750410
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.Dispose
	|
	|-RVA: 0x750550 Offset: 0x750550 VA: 0x750550
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.Dispose
	|
	|-RVA: 0x7505EC Offset: 0x7505EC VA: 0x7505EC
	|-Dictionary.Enumerator<object, bool>.Dispose
	|-Dictionary.Enumerator<YamlNode, bool>.Dispose
	|
	|-RVA: 0x750688 Offset: 0x750688 VA: 0x750688
	|-Dictionary.Enumerator<object, byte>.Dispose
	|
	|-RVA: 0x750724 Offset: 0x750724 VA: 0x750724
	|-Dictionary.Enumerator<object, short>.Dispose
	|
	|-RVA: 0x7507C0 Offset: 0x7507C0 VA: 0x7507C0
	|-Dictionary.Enumerator<object, int>.Dispose
	|-Dictionary.Enumerator<Collider, int>.Dispose
	|-Dictionary.Enumerator<RectTransform, int>.Dispose
	|
	|-RVA: 0x7508F8 Offset: 0x7508F8 VA: 0x7508F8
	|-Dictionary.Enumerator<object, long>.Dispose
	|
	|-RVA: 0x750A34 Offset: 0x750A34 VA: 0x750A34
	|-Dictionary.Enumerator<object, ResourceLocator>.Dispose
	|
	|-RVA: 0x750AD0 Offset: 0x750AD0 VA: 0x750AD0
	|-Dictionary.Enumerator<object, uint>.Dispose
	|
	|-RVA: 0x750B70 Offset: 0x750B70 VA: 0x750B70
	|-Dictionary.Enumerator<object, Playable>.Dispose
	|
	|-RVA: 0x750C0C Offset: 0x750C0C VA: 0x750C0C
	|-Dictionary.Enumerator<ushort, LocalToolBaseCtrlr>.Dispose
	|-Dictionary.Enumerator<ushort, RemoteToolBaseCtrlr>.Dispose
	|-Dictionary.Enumerator<ushort, ToolBase>.Dispose
	|-Dictionary.Enumerator<ushort, object>.Dispose
	|
	|-RVA: 0x750F24 Offset: 0x750F24 VA: 0x750F24
	|-Dictionary.Enumerator<uint, BattlePlayerIcon>.Dispose
	|-Dictionary.Enumerator<uint, BattleZoneData.BattleZoneInfo>.Dispose
	|-Dictionary.Enumerator<uint, BuffData>.Dispose
	|-Dictionary.Enumerator<uint, BattleTeam.PlayerInfo>.Dispose
	|-Dictionary.Enumerator<uint, UIBuffEffCtrlBase>.Dispose
	|-Dictionary.Enumerator<uint, ValueSliderControl>.Dispose
	|-Dictionary.Enumerator<uint, List<int>>.Dispose
	|-Dictionary.Enumerator<uint, object>.Dispose
	|-Dictionary.Enumerator<uint, string>.Dispose
	|-Dictionary.Enumerator<uint, GameObject>.Dispose
	|
	|-RVA: 0x750CB4 Offset: 0x750CB4 VA: 0x750CB4
	|-Dictionary.Enumerator<uint, CustomValue>.Dispose
	|
	|-RVA: 0x750D50 Offset: 0x750D50 VA: 0x750D50
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.Dispose
	|
	|-RVA: 0x750DEC Offset: 0x750DEC VA: 0x750DEC
	|-Dictionary.Enumerator<uint, byte>.Dispose
	|
	|-RVA: 0x750E88 Offset: 0x750E88 VA: 0x750E88
	|-Dictionary.Enumerator<uint, int>.Dispose
	|
	|-RVA: 0x750FC0 Offset: 0x750FC0 VA: 0x750FC0
	|-Dictionary.Enumerator<ulong, object>.Dispose
	|
	|-RVA: 0x75106C Offset: 0x75106C VA: 0x75106C
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.Dispose
	|
	|-RVA: 0x75110C Offset: 0x75110C VA: 0x75110C
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.Dispose
	|
	|-RVA: 0x7511AC Offset: 0x7511AC VA: 0x7511AC
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.Dispose
	|
	|-RVA: 0x75124C Offset: 0x75124C VA: 0x75124C
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.Dispose
	|
	|-RVA: 0x7512EC Offset: 0x7512EC VA: 0x7512EC
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.Dispose
	|-Dictionary.Enumerator<ValueTuple<string, Type>, IAssetLoadAction>.Dispose
	|
	|-RVA: 0x751388 Offset: 0x751388 VA: 0x751388
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, List<ILightweightTrigger>>.Dispose
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.Dispose
	|
	|-RVA: 0x751428 Offset: 0x751428 VA: 0x751428
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.Dispose
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, Terrain>.Dispose
	|
	|-RVA: 0x7514C4 Offset: 0x7514C4 VA: 0x7514C4
	|-Dictionary.Enumerator<Vector3, int>.Dispose
	|
	|-RVA: 0x751564 Offset: 0x751564 VA: 0x751564
	|-Dictionary.Enumerator<Utils.MethodKey, List<MemberInfo>>.Dispose
	|-Dictionary.Enumerator<Utils.MethodKey, object>.Dispose
	|
	|-RVA: 0x751604 Offset: 0x751604 VA: 0x751604
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, List<YamlAttributeOverrides.AttributeMapping>>.Dispose
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751C40 Offset: 0x751C40 VA: 0x751C40
	|-Dictionary.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751CDC Offset: 0x751CDC VA: 0x751CDC
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751D78 Offset: 0x751D78 VA: 0x751D78
	|-Dictionary.Enumerator<U64Id, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751E14 Offset: 0x751E14 VA: 0x751E14
	|-Dictionary.Enumerator<U64Id, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751EB4 Offset: 0x751EB4 VA: 0x751EB4
	|-Dictionary.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751F50 Offset: 0x751F50 VA: 0x751F50
	|-Dictionary.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751FEC Offset: 0x751FEC VA: 0x751FEC
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75208C Offset: 0x75208C VA: 0x75208C
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75212C Offset: 0x75212C VA: 0x75212C
	|-Dictionary.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7521CC Offset: 0x7521CC VA: 0x7521CC
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75226C Offset: 0x75226C VA: 0x75226C
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752308 Offset: 0x752308 VA: 0x752308
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7523A8 Offset: 0x7523A8 VA: 0x7523A8
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752444 Offset: 0x752444 VA: 0x752444
	|-Dictionary.Enumerator<byte, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7524E0 Offset: 0x7524E0 VA: 0x7524E0
	|-Dictionary.Enumerator<byte, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75257C Offset: 0x75257C VA: 0x75257C
	|-Dictionary.Enumerator<byte, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752618 Offset: 0x752618 VA: 0x752618
	|-Dictionary.Enumerator<char, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7526C0 Offset: 0x7526C0 VA: 0x7526C0
	|-Dictionary.Enumerator<Guid, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75277C Offset: 0x75277C VA: 0x75277C
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75281C Offset: 0x75281C VA: 0x75281C
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7528B8 Offset: 0x7528B8 VA: 0x7528B8
	|-Dictionary.Enumerator<int, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752954 Offset: 0x752954 VA: 0x752954
	|-Dictionary.Enumerator<int, char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7529F0 Offset: 0x7529F0 VA: 0x7529F0
	|-Dictionary.Enumerator<int, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752A8C Offset: 0x752A8C VA: 0x752A8C
	|-Dictionary.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752B28 Offset: 0x752B28 VA: 0x752B28
	|-Dictionary.Enumerator<int, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752BD4 Offset: 0x752BD4 VA: 0x752BD4
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752C70 Offset: 0x752C70 VA: 0x752C70
	|-Dictionary.Enumerator<int, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752D0C Offset: 0x752D0C VA: 0x752D0C
	|-Dictionary.Enumerator<int, float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752DA8 Offset: 0x752DA8 VA: 0x752DA8
	|-Dictionary.Enumerator<int, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752E44 Offset: 0x752E44 VA: 0x752E44
	|-Dictionary.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752EE0 Offset: 0x752EE0 VA: 0x752EE0
	|-Dictionary.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x752F7C Offset: 0x752F7C VA: 0x752F7C
	|-Dictionary.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x753018 Offset: 0x753018 VA: 0x753018
	|-Dictionary.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7530B8 Offset: 0x7530B8 VA: 0x7530B8
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x753158 Offset: 0x753158 VA: 0x753158
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750194 Offset: 0x750194 VA: 0x750194
	|-Dictionary.Enumerator<long, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750230 Offset: 0x750230 VA: 0x750230
	|-Dictionary.Enumerator<long, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7502CC Offset: 0x7502CC VA: 0x7502CC
	|-Dictionary.Enumerator<IntPtr, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750374 Offset: 0x750374 VA: 0x750374
	|-Dictionary.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750414 Offset: 0x750414 VA: 0x750414
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7504B0 Offset: 0x7504B0 VA: 0x7504B0
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750554 Offset: 0x750554 VA: 0x750554
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7505F0 Offset: 0x7505F0 VA: 0x7505F0
	|-Dictionary.Enumerator<object, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75068C Offset: 0x75068C VA: 0x75068C
	|-Dictionary.Enumerator<object, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750728 Offset: 0x750728 VA: 0x750728
	|-Dictionary.Enumerator<object, short>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7507C4 Offset: 0x7507C4 VA: 0x7507C4
	|-Dictionary.Enumerator<object, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750860 Offset: 0x750860 VA: 0x750860
	|-Dictionary.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7508FC Offset: 0x7508FC VA: 0x7508FC
	|-Dictionary.Enumerator<object, long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750998 Offset: 0x750998 VA: 0x750998
	|-Dictionary.Enumerator<object, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750A38 Offset: 0x750A38 VA: 0x750A38
	|-Dictionary.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750AD4 Offset: 0x750AD4 VA: 0x750AD4
	|-Dictionary.Enumerator<object, uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750B74 Offset: 0x750B74 VA: 0x750B74
	|-Dictionary.Enumerator<object, Playable>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750C10 Offset: 0x750C10 VA: 0x750C10
	|-Dictionary.Enumerator<ushort, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750CB8 Offset: 0x750CB8 VA: 0x750CB8
	|-Dictionary.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750D54 Offset: 0x750D54 VA: 0x750D54
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750DF0 Offset: 0x750DF0 VA: 0x750DF0
	|-Dictionary.Enumerator<uint, byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750E8C Offset: 0x750E8C VA: 0x750E8C
	|-Dictionary.Enumerator<uint, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750F28 Offset: 0x750F28 VA: 0x750F28
	|-Dictionary.Enumerator<uint, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x750FC4 Offset: 0x750FC4 VA: 0x750FC4
	|-Dictionary.Enumerator<ulong, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751070 Offset: 0x751070 VA: 0x751070
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751110 Offset: 0x751110 VA: 0x751110
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7511B0 Offset: 0x7511B0 VA: 0x7511B0
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751250 Offset: 0x751250 VA: 0x751250
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7512F0 Offset: 0x7512F0 VA: 0x7512F0
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75138C Offset: 0x75138C VA: 0x75138C
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x75142C Offset: 0x75142C VA: 0x75142C
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7514C8 Offset: 0x7514C8 VA: 0x7514C8
	|-Dictionary.Enumerator<Vector3, int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751568 Offset: 0x751568 VA: 0x751568
	|-Dictionary.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x751608 Offset: 0x751608 VA: 0x751608
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751C48 Offset: 0x751C48 VA: 0x751C48
	|-Dictionary.Enumerator<EntityID, Entity>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751CE4 Offset: 0x751CE4 VA: 0x751CE4
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751D80 Offset: 0x751D80 VA: 0x751D80
	|-Dictionary.Enumerator<U64Id, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751E1C Offset: 0x751E1C VA: 0x751E1C
	|-Dictionary.Enumerator<U64Id, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751EBC Offset: 0x751EBC VA: 0x751EBC
	|-Dictionary.Enumerator<LeaderBoardType, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751F58 Offset: 0x751F58 VA: 0x751F58
	|-Dictionary.Enumerator<TranslateEvent, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751FF4 Offset: 0x751FF4 VA: 0x751FF4
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752094 Offset: 0x752094 VA: 0x752094
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752134 Offset: 0x752134 VA: 0x752134
	|-Dictionary.Enumerator<ResolverContractKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7521D4 Offset: 0x7521D4 VA: 0x7521D4
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752274 Offset: 0x752274 VA: 0x752274
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752310 Offset: 0x752310 VA: 0x752310
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7523B0 Offset: 0x7523B0 VA: 0x7523B0
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75244C Offset: 0x75244C VA: 0x75244C
	|-Dictionary.Enumerator<byte, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7524E8 Offset: 0x7524E8 VA: 0x7524E8
	|-Dictionary.Enumerator<byte, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752584 Offset: 0x752584 VA: 0x752584
	|-Dictionary.Enumerator<byte, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752620 Offset: 0x752620 VA: 0x752620
	|-Dictionary.Enumerator<char, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7526C8 Offset: 0x7526C8 VA: 0x7526C8
	|-Dictionary.Enumerator<Guid, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752784 Offset: 0x752784 VA: 0x752784
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752824 Offset: 0x752824 VA: 0x752824
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7528C0 Offset: 0x7528C0 VA: 0x7528C0
	|-Dictionary.Enumerator<int, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75295C Offset: 0x75295C VA: 0x75295C
	|-Dictionary.Enumerator<int, char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7529F8 Offset: 0x7529F8 VA: 0x7529F8
	|-Dictionary.Enumerator<int, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752A94 Offset: 0x752A94 VA: 0x752A94
	|-Dictionary.Enumerator<int, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752B30 Offset: 0x752B30 VA: 0x752B30
	|-Dictionary.Enumerator<int, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752BDC Offset: 0x752BDC VA: 0x752BDC
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752C78 Offset: 0x752C78 VA: 0x752C78
	|-Dictionary.Enumerator<int, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752D14 Offset: 0x752D14 VA: 0x752D14
	|-Dictionary.Enumerator<int, float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752DB0 Offset: 0x752DB0 VA: 0x752DB0
	|-Dictionary.Enumerator<int, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752E4C Offset: 0x752E4C VA: 0x752E4C
	|-Dictionary.Enumerator<Int32Enum, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752EE8 Offset: 0x752EE8 VA: 0x752EE8
	|-Dictionary.Enumerator<Int32Enum, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x752F84 Offset: 0x752F84 VA: 0x752F84
	|-Dictionary.Enumerator<Int32Enum, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x753020 Offset: 0x753020 VA: 0x753020
	|-Dictionary.Enumerator<Int32Enum, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7530C0 Offset: 0x7530C0 VA: 0x7530C0
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x753160 Offset: 0x753160 VA: 0x753160
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75019C Offset: 0x75019C VA: 0x75019C
	|-Dictionary.Enumerator<long, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750238 Offset: 0x750238 VA: 0x750238
	|-Dictionary.Enumerator<long, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7502D4 Offset: 0x7502D4 VA: 0x7502D4
	|-Dictionary.Enumerator<IntPtr, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75037C Offset: 0x75037C VA: 0x75037C
	|-Dictionary.Enumerator<object, CommandInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75041C Offset: 0x75041C VA: 0x75041C
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7504B8 Offset: 0x7504B8 VA: 0x7504B8
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x75055C Offset: 0x75055C VA: 0x75055C
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7505F8 Offset: 0x7505F8 VA: 0x7505F8
	|-Dictionary.Enumerator<object, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750694 Offset: 0x750694 VA: 0x750694
	|-Dictionary.Enumerator<object, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750730 Offset: 0x750730 VA: 0x750730
	|-Dictionary.Enumerator<object, short>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7507CC Offset: 0x7507CC VA: 0x7507CC
	|-Dictionary.Enumerator<object, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750868 Offset: 0x750868 VA: 0x750868
	|-Dictionary.Enumerator<object, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750904 Offset: 0x750904 VA: 0x750904
	|-Dictionary.Enumerator<object, long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7509A0 Offset: 0x7509A0 VA: 0x7509A0
	|-Dictionary.Enumerator<object, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750A40 Offset: 0x750A40 VA: 0x750A40
	|-Dictionary.Enumerator<object, ResourceLocator>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750ADC Offset: 0x750ADC VA: 0x750ADC
	|-Dictionary.Enumerator<object, uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750B7C Offset: 0x750B7C VA: 0x750B7C
	|-Dictionary.Enumerator<object, Playable>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750C18 Offset: 0x750C18 VA: 0x750C18
	|-Dictionary.Enumerator<ushort, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750CC0 Offset: 0x750CC0 VA: 0x750CC0
	|-Dictionary.Enumerator<uint, CustomValue>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750D5C Offset: 0x750D5C VA: 0x750D5C
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750DF8 Offset: 0x750DF8 VA: 0x750DF8
	|-Dictionary.Enumerator<uint, byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750E94 Offset: 0x750E94 VA: 0x750E94
	|-Dictionary.Enumerator<uint, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750F30 Offset: 0x750F30 VA: 0x750F30
	|-Dictionary.Enumerator<uint, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x750FCC Offset: 0x750FCC VA: 0x750FCC
	|-Dictionary.Enumerator<ulong, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751078 Offset: 0x751078 VA: 0x751078
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751118 Offset: 0x751118 VA: 0x751118
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7511B8 Offset: 0x7511B8 VA: 0x7511B8
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751258 Offset: 0x751258 VA: 0x751258
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7512F8 Offset: 0x7512F8 VA: 0x7512F8
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751394 Offset: 0x751394 VA: 0x751394
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751434 Offset: 0x751434 VA: 0x751434
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7514D0 Offset: 0x7514D0 VA: 0x7514D0
	|-Dictionary.Enumerator<Vector3, int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751570 Offset: 0x751570 VA: 0x751570
	|-Dictionary.Enumerator<Utils.MethodKey, object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x751610 Offset: 0x751610 VA: 0x751610
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IEnumerator.Reset
	*/

	// RVA: -1 Offset: -1 Slot: 11
	private DictionaryEntry System.Collections.IDictionaryEnumerator.get_Entry() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751C50 Offset: 0x751C50 VA: 0x751C50
	|-Dictionary.Enumerator<EntityID, Entity>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751CEC Offset: 0x751CEC VA: 0x751CEC
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751D88 Offset: 0x751D88 VA: 0x751D88
	|-Dictionary.Enumerator<U64Id, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751E24 Offset: 0x751E24 VA: 0x751E24
	|-Dictionary.Enumerator<U64Id, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751EC4 Offset: 0x751EC4 VA: 0x751EC4
	|-Dictionary.Enumerator<LeaderBoardType, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751F60 Offset: 0x751F60 VA: 0x751F60
	|-Dictionary.Enumerator<TranslateEvent, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751FFC Offset: 0x751FFC VA: 0x751FFC
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75209C Offset: 0x75209C VA: 0x75209C
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75213C Offset: 0x75213C VA: 0x75213C
	|-Dictionary.Enumerator<ResolverContractKey, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7521DC Offset: 0x7521DC VA: 0x7521DC
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75227C Offset: 0x75227C VA: 0x75227C
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752318 Offset: 0x752318 VA: 0x752318
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7523B8 Offset: 0x7523B8 VA: 0x7523B8
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752454 Offset: 0x752454 VA: 0x752454
	|-Dictionary.Enumerator<byte, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7524F0 Offset: 0x7524F0 VA: 0x7524F0
	|-Dictionary.Enumerator<byte, float>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75258C Offset: 0x75258C VA: 0x75258C
	|-Dictionary.Enumerator<byte, uint>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752628 Offset: 0x752628 VA: 0x752628
	|-Dictionary.Enumerator<char, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7526D0 Offset: 0x7526D0 VA: 0x7526D0
	|-Dictionary.Enumerator<Guid, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75278C Offset: 0x75278C VA: 0x75278C
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75282C Offset: 0x75282C VA: 0x75282C
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7528C8 Offset: 0x7528C8 VA: 0x7528C8
	|-Dictionary.Enumerator<int, bool>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752964 Offset: 0x752964 VA: 0x752964
	|-Dictionary.Enumerator<int, char>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752A00 Offset: 0x752A00 VA: 0x752A00
	|-Dictionary.Enumerator<int, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752A9C Offset: 0x752A9C VA: 0x752A9C
	|-Dictionary.Enumerator<int, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752B38 Offset: 0x752B38 VA: 0x752B38
	|-Dictionary.Enumerator<int, long>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752BE4 Offset: 0x752BE4 VA: 0x752BE4
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752C80 Offset: 0x752C80 VA: 0x752C80
	|-Dictionary.Enumerator<int, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752D1C Offset: 0x752D1C VA: 0x752D1C
	|-Dictionary.Enumerator<int, float>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752DB8 Offset: 0x752DB8 VA: 0x752DB8
	|-Dictionary.Enumerator<int, uint>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752E54 Offset: 0x752E54 VA: 0x752E54
	|-Dictionary.Enumerator<Int32Enum, bool>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752EF0 Offset: 0x752EF0 VA: 0x752EF0
	|-Dictionary.Enumerator<Int32Enum, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x752F8C Offset: 0x752F8C VA: 0x752F8C
	|-Dictionary.Enumerator<Int32Enum, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x753028 Offset: 0x753028 VA: 0x753028
	|-Dictionary.Enumerator<Int32Enum, uint>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7530C8 Offset: 0x7530C8 VA: 0x7530C8
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x753168 Offset: 0x753168 VA: 0x753168
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7501A4 Offset: 0x7501A4 VA: 0x7501A4
	|-Dictionary.Enumerator<long, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750240 Offset: 0x750240 VA: 0x750240
	|-Dictionary.Enumerator<long, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7502DC Offset: 0x7502DC VA: 0x7502DC
	|-Dictionary.Enumerator<IntPtr, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750384 Offset: 0x750384 VA: 0x750384
	|-Dictionary.Enumerator<object, CommandInfo>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750424 Offset: 0x750424 VA: 0x750424
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7504C0 Offset: 0x7504C0 VA: 0x7504C0
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750564 Offset: 0x750564 VA: 0x750564
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750600 Offset: 0x750600 VA: 0x750600
	|-Dictionary.Enumerator<object, bool>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75069C Offset: 0x75069C VA: 0x75069C
	|-Dictionary.Enumerator<object, byte>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750738 Offset: 0x750738 VA: 0x750738
	|-Dictionary.Enumerator<object, short>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7507D4 Offset: 0x7507D4 VA: 0x7507D4
	|-Dictionary.Enumerator<object, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750870 Offset: 0x750870 VA: 0x750870
	|-Dictionary.Enumerator<object, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75090C Offset: 0x75090C VA: 0x75090C
	|-Dictionary.Enumerator<object, long>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7509A8 Offset: 0x7509A8 VA: 0x7509A8
	|-Dictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750A48 Offset: 0x750A48 VA: 0x750A48
	|-Dictionary.Enumerator<object, ResourceLocator>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750AE4 Offset: 0x750AE4 VA: 0x750AE4
	|-Dictionary.Enumerator<object, uint>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750B84 Offset: 0x750B84 VA: 0x750B84
	|-Dictionary.Enumerator<object, Playable>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750C20 Offset: 0x750C20 VA: 0x750C20
	|-Dictionary.Enumerator<ushort, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750CC8 Offset: 0x750CC8 VA: 0x750CC8
	|-Dictionary.Enumerator<uint, CustomValue>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750D64 Offset: 0x750D64 VA: 0x750D64
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750E00 Offset: 0x750E00 VA: 0x750E00
	|-Dictionary.Enumerator<uint, byte>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750E9C Offset: 0x750E9C VA: 0x750E9C
	|-Dictionary.Enumerator<uint, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750F38 Offset: 0x750F38 VA: 0x750F38
	|-Dictionary.Enumerator<uint, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x750FD4 Offset: 0x750FD4 VA: 0x750FD4
	|-Dictionary.Enumerator<ulong, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751080 Offset: 0x751080 VA: 0x751080
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751120 Offset: 0x751120 VA: 0x751120
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7511C0 Offset: 0x7511C0 VA: 0x7511C0
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751260 Offset: 0x751260 VA: 0x751260
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751300 Offset: 0x751300 VA: 0x751300
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75139C Offset: 0x75139C VA: 0x75139C
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x75143C Offset: 0x75143C VA: 0x75143C
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x7514D8 Offset: 0x7514D8 VA: 0x7514D8
	|-Dictionary.Enumerator<Vector3, int>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751578 Offset: 0x751578 VA: 0x751578
	|-Dictionary.Enumerator<Utils.MethodKey, object>.System.Collections.IDictionaryEnumerator.get_Entry
	|
	|-RVA: 0x751618 Offset: 0x751618 VA: 0x751618
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IDictionaryEnumerator.get_Entry
	*/

	// RVA: -1 Offset: -1 Slot: 9
	private object System.Collections.IDictionaryEnumerator.get_Key() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751C64 Offset: 0x751C64 VA: 0x751C64
	|-Dictionary.Enumerator<EntityID, Entity>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751D00 Offset: 0x751D00 VA: 0x751D00
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751D9C Offset: 0x751D9C VA: 0x751D9C
	|-Dictionary.Enumerator<U64Id, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751E38 Offset: 0x751E38 VA: 0x751E38
	|-Dictionary.Enumerator<U64Id, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751ED8 Offset: 0x751ED8 VA: 0x751ED8
	|-Dictionary.Enumerator<LeaderBoardType, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751F74 Offset: 0x751F74 VA: 0x751F74
	|-Dictionary.Enumerator<TranslateEvent, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752010 Offset: 0x752010 VA: 0x752010
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7520B0 Offset: 0x7520B0 VA: 0x7520B0
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752150 Offset: 0x752150 VA: 0x752150
	|-Dictionary.Enumerator<ResolverContractKey, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7521F0 Offset: 0x7521F0 VA: 0x7521F0
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752290 Offset: 0x752290 VA: 0x752290
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75232C Offset: 0x75232C VA: 0x75232C
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7523CC Offset: 0x7523CC VA: 0x7523CC
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752468 Offset: 0x752468 VA: 0x752468
	|-Dictionary.Enumerator<byte, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752504 Offset: 0x752504 VA: 0x752504
	|-Dictionary.Enumerator<byte, float>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7525A0 Offset: 0x7525A0 VA: 0x7525A0
	|-Dictionary.Enumerator<byte, uint>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75263C Offset: 0x75263C VA: 0x75263C
	|-Dictionary.Enumerator<char, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7526E4 Offset: 0x7526E4 VA: 0x7526E4
	|-Dictionary.Enumerator<Guid, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7527A0 Offset: 0x7527A0 VA: 0x7527A0
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752840 Offset: 0x752840 VA: 0x752840
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7528DC Offset: 0x7528DC VA: 0x7528DC
	|-Dictionary.Enumerator<int, bool>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752978 Offset: 0x752978 VA: 0x752978
	|-Dictionary.Enumerator<int, char>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752A14 Offset: 0x752A14 VA: 0x752A14
	|-Dictionary.Enumerator<int, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752AB0 Offset: 0x752AB0 VA: 0x752AB0
	|-Dictionary.Enumerator<int, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752B4C Offset: 0x752B4C VA: 0x752B4C
	|-Dictionary.Enumerator<int, long>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752BF8 Offset: 0x752BF8 VA: 0x752BF8
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752C94 Offset: 0x752C94 VA: 0x752C94
	|-Dictionary.Enumerator<int, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752D30 Offset: 0x752D30 VA: 0x752D30
	|-Dictionary.Enumerator<int, float>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752DCC Offset: 0x752DCC VA: 0x752DCC
	|-Dictionary.Enumerator<int, uint>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752E68 Offset: 0x752E68 VA: 0x752E68
	|-Dictionary.Enumerator<Int32Enum, bool>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752F04 Offset: 0x752F04 VA: 0x752F04
	|-Dictionary.Enumerator<Int32Enum, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x752FA0 Offset: 0x752FA0 VA: 0x752FA0
	|-Dictionary.Enumerator<Int32Enum, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75303C Offset: 0x75303C VA: 0x75303C
	|-Dictionary.Enumerator<Int32Enum, uint>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7530DC Offset: 0x7530DC VA: 0x7530DC
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75317C Offset: 0x75317C VA: 0x75317C
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7501B8 Offset: 0x7501B8 VA: 0x7501B8
	|-Dictionary.Enumerator<long, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750254 Offset: 0x750254 VA: 0x750254
	|-Dictionary.Enumerator<long, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7502F0 Offset: 0x7502F0 VA: 0x7502F0
	|-Dictionary.Enumerator<IntPtr, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750398 Offset: 0x750398 VA: 0x750398
	|-Dictionary.Enumerator<object, CommandInfo>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750438 Offset: 0x750438 VA: 0x750438
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7504D4 Offset: 0x7504D4 VA: 0x7504D4
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750578 Offset: 0x750578 VA: 0x750578
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750614 Offset: 0x750614 VA: 0x750614
	|-Dictionary.Enumerator<object, bool>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7506B0 Offset: 0x7506B0 VA: 0x7506B0
	|-Dictionary.Enumerator<object, byte>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75074C Offset: 0x75074C VA: 0x75074C
	|-Dictionary.Enumerator<object, short>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7507E8 Offset: 0x7507E8 VA: 0x7507E8
	|-Dictionary.Enumerator<object, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750884 Offset: 0x750884 VA: 0x750884
	|-Dictionary.Enumerator<object, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750920 Offset: 0x750920 VA: 0x750920
	|-Dictionary.Enumerator<object, long>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7509BC Offset: 0x7509BC VA: 0x7509BC
	|-Dictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750A5C Offset: 0x750A5C VA: 0x750A5C
	|-Dictionary.Enumerator<object, ResourceLocator>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750AF8 Offset: 0x750AF8 VA: 0x750AF8
	|-Dictionary.Enumerator<object, uint>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750B98 Offset: 0x750B98 VA: 0x750B98
	|-Dictionary.Enumerator<object, Playable>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750C34 Offset: 0x750C34 VA: 0x750C34
	|-Dictionary.Enumerator<ushort, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750CDC Offset: 0x750CDC VA: 0x750CDC
	|-Dictionary.Enumerator<uint, CustomValue>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750D78 Offset: 0x750D78 VA: 0x750D78
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750E14 Offset: 0x750E14 VA: 0x750E14
	|-Dictionary.Enumerator<uint, byte>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750EB0 Offset: 0x750EB0 VA: 0x750EB0
	|-Dictionary.Enumerator<uint, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750F4C Offset: 0x750F4C VA: 0x750F4C
	|-Dictionary.Enumerator<uint, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x750FE8 Offset: 0x750FE8 VA: 0x750FE8
	|-Dictionary.Enumerator<ulong, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751094 Offset: 0x751094 VA: 0x751094
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751134 Offset: 0x751134 VA: 0x751134
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7511D4 Offset: 0x7511D4 VA: 0x7511D4
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751274 Offset: 0x751274 VA: 0x751274
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751314 Offset: 0x751314 VA: 0x751314
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7513B0 Offset: 0x7513B0 VA: 0x7513B0
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x751450 Offset: 0x751450 VA: 0x751450
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x7514EC Offset: 0x7514EC VA: 0x7514EC
	|-Dictionary.Enumerator<Vector3, int>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75158C Offset: 0x75158C VA: 0x75158C
	|-Dictionary.Enumerator<Utils.MethodKey, object>.System.Collections.IDictionaryEnumerator.get_Key
	|
	|-RVA: 0x75162C Offset: 0x75162C VA: 0x75162C
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IDictionaryEnumerator.get_Key
	*/

	// RVA: -1 Offset: -1 Slot: 10
	private object System.Collections.IDictionaryEnumerator.get_Value() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x751C6C Offset: 0x751C6C VA: 0x751C6C
	|-Dictionary.Enumerator<EntityID, Entity>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751D08 Offset: 0x751D08 VA: 0x751D08
	|-Dictionary.Enumerator<U64Id, NaviPathManager.Inner_NaviPath>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751DA4 Offset: 0x751DA4 VA: 0x751DA4
	|-Dictionary.Enumerator<U64Id, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751E40 Offset: 0x751E40 VA: 0x751E40
	|-Dictionary.Enumerator<U64Id, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751EE0 Offset: 0x751EE0 VA: 0x751EE0
	|-Dictionary.Enumerator<LeaderBoardType, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751F7C Offset: 0x751F7C VA: 0x751F7C
	|-Dictionary.Enumerator<TranslateEvent, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752018 Offset: 0x752018 VA: 0x752018
	|-Dictionary.Enumerator<XPathNodeRef, XPathNodeRef>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7520B8 Offset: 0x7520B8 VA: 0x7520B8
	|-Dictionary.Enumerator<DefaultSerializationBinder.TypeNameKey, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752158 Offset: 0x752158 VA: 0x752158
	|-Dictionary.Enumerator<ResolverContractKey, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7521F8 Offset: 0x7521F8 VA: 0x7521F8
	|-Dictionary.Enumerator<ConvertUtils.TypeConvertKey, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752298 Offset: 0x752298 VA: 0x752298
	|-Dictionary.Enumerator<AnimationStateData.AnimationPair, float>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752334 Offset: 0x752334 VA: 0x752334
	|-Dictionary.Enumerator<Skin.AttachmentKeyTuple, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7523D4 Offset: 0x7523D4 VA: 0x7523D4
	|-Dictionary.Enumerator<SlotBlendModes.MaterialTexturePair, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752470 Offset: 0x752470 VA: 0x752470
	|-Dictionary.Enumerator<byte, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75250C Offset: 0x75250C VA: 0x75250C
	|-Dictionary.Enumerator<byte, float>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7525A8 Offset: 0x7525A8 VA: 0x7525A8
	|-Dictionary.Enumerator<byte, uint>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752644 Offset: 0x752644 VA: 0x752644
	|-Dictionary.Enumerator<char, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7526EC Offset: 0x7526EC VA: 0x7526EC
	|-Dictionary.Enumerator<Guid, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7527A8 Offset: 0x7527A8 VA: 0x7527A8
	|-Dictionary.Enumerator<int, UIAvatarCreator.AvatarInfo>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752848 Offset: 0x752848 VA: 0x752848
	|-Dictionary.Enumerator<int, UIMgr.LayerWithPanels>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7528E4 Offset: 0x7528E4 VA: 0x7528E4
	|-Dictionary.Enumerator<int, bool>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752980 Offset: 0x752980 VA: 0x752980
	|-Dictionary.Enumerator<int, char>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752A1C Offset: 0x752A1C VA: 0x752A1C
	|-Dictionary.Enumerator<int, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752AB8 Offset: 0x752AB8 VA: 0x752AB8
	|-Dictionary.Enumerator<int, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752B54 Offset: 0x752B54 VA: 0x752B54
	|-Dictionary.Enumerator<int, long>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752C00 Offset: 0x752C00 VA: 0x752C00
	|-Dictionary.Enumerator<int, Nullable<U64Id>>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752C9C Offset: 0x752C9C VA: 0x752C9C
	|-Dictionary.Enumerator<int, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752D38 Offset: 0x752D38 VA: 0x752D38
	|-Dictionary.Enumerator<int, float>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752DD4 Offset: 0x752DD4 VA: 0x752DD4
	|-Dictionary.Enumerator<int, uint>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752E70 Offset: 0x752E70 VA: 0x752E70
	|-Dictionary.Enumerator<Int32Enum, bool>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752F0C Offset: 0x752F0C VA: 0x752F0C
	|-Dictionary.Enumerator<Int32Enum, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x752FA8 Offset: 0x752FA8 VA: 0x752FA8
	|-Dictionary.Enumerator<Int32Enum, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x753044 Offset: 0x753044 VA: 0x753044
	|-Dictionary.Enumerator<Int32Enum, uint>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7530E4 Offset: 0x7530E4 VA: 0x7530E4
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<int, int>>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x753184 Offset: 0x753184 VA: 0x753184
	|-Dictionary.Enumerator<Int32Enum, ValueTuple<float, float>>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7501C0 Offset: 0x7501C0 VA: 0x7501C0
	|-Dictionary.Enumerator<long, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75025C Offset: 0x75025C VA: 0x75025C
	|-Dictionary.Enumerator<long, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7502F8 Offset: 0x7502F8 VA: 0x7502F8
	|-Dictionary.Enumerator<IntPtr, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7503A0 Offset: 0x7503A0 VA: 0x7503A0
	|-Dictionary.Enumerator<object, CommandInfo>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750440 Offset: 0x750440 VA: 0x750440
	|-Dictionary.Enumerator<object, GraphAnimator.RootPair>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7504DC Offset: 0x7504DC VA: 0x7504DC
	|-Dictionary.Enumerator<object, AriticleBuffContainer.BuffVfx>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750580 Offset: 0x750580 VA: 0x750580
	|-Dictionary.Enumerator<object, BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75061C Offset: 0x75061C VA: 0x75061C
	|-Dictionary.Enumerator<object, bool>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7506B8 Offset: 0x7506B8 VA: 0x7506B8
	|-Dictionary.Enumerator<object, byte>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750754 Offset: 0x750754 VA: 0x750754
	|-Dictionary.Enumerator<object, short>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7507F0 Offset: 0x7507F0 VA: 0x7507F0
	|-Dictionary.Enumerator<object, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75088C Offset: 0x75088C VA: 0x75088C
	|-Dictionary.Enumerator<object, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750928 Offset: 0x750928 VA: 0x750928
	|-Dictionary.Enumerator<object, long>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7509C4 Offset: 0x7509C4 VA: 0x7509C4
	|-Dictionary.Enumerator<object, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750A64 Offset: 0x750A64 VA: 0x750A64
	|-Dictionary.Enumerator<object, ResourceLocator>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750B00 Offset: 0x750B00 VA: 0x750B00
	|-Dictionary.Enumerator<object, uint>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750BA0 Offset: 0x750BA0 VA: 0x750BA0
	|-Dictionary.Enumerator<object, Playable>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750C3C Offset: 0x750C3C VA: 0x750C3C
	|-Dictionary.Enumerator<ushort, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750CE4 Offset: 0x750CE4 VA: 0x750CE4
	|-Dictionary.Enumerator<uint, CustomValue>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750D80 Offset: 0x750D80 VA: 0x750D80
	|-Dictionary.Enumerator<uint, SharedGameObjectSystem.ChannelData>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750E1C Offset: 0x750E1C VA: 0x750E1C
	|-Dictionary.Enumerator<uint, byte>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750EB8 Offset: 0x750EB8 VA: 0x750EB8
	|-Dictionary.Enumerator<uint, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750F54 Offset: 0x750F54 VA: 0x750F54
	|-Dictionary.Enumerator<uint, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x750FF0 Offset: 0x750FF0 VA: 0x750FF0
	|-Dictionary.Enumerator<ulong, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75109C Offset: 0x75109C VA: 0x75109C
	|-Dictionary.Enumerator<ValueTuple<byte, U64Id>, Int32Enum>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75113C Offset: 0x75113C VA: 0x75113C
	|-Dictionary.Enumerator<ValueTuple<int, int>, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7511DC Offset: 0x7511DC VA: 0x7511DC
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, bool>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75127C Offset: 0x75127C VA: 0x75127C
	|-Dictionary.Enumerator<ValueTuple<Int32Enum, Int32Enum>, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x75131C Offset: 0x75131C VA: 0x75131C
	|-Dictionary.Enumerator<ValueTuple<object, object>, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7513B8 Offset: 0x7513B8 VA: 0x7513B8
	|-Dictionary.Enumerator<ValueTuple<int, int, int>, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751458 Offset: 0x751458 VA: 0x751458
	|-Dictionary.Enumerator<TerrainUtility.TerrainMap.TileCoord, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x7514F4 Offset: 0x7514F4 VA: 0x7514F4
	|-Dictionary.Enumerator<Vector3, int>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751594 Offset: 0x751594 VA: 0x751594
	|-Dictionary.Enumerator<Utils.MethodKey, object>.System.Collections.IDictionaryEnumerator.get_Value
	|
	|-RVA: 0x751634 Offset: 0x751634 VA: 0x751634
	|-Dictionary.Enumerator<YamlAttributeOverrides.AttributeKey, object>.System.Collections.IDictionaryEnumerator.get_Value
	*/
}
