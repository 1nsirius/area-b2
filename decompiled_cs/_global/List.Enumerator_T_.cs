// Namespace: 
[Serializable]
public struct List.Enumerator<T> : IEnumerator<T>, IDisposable, IEnumerator // TypeDefIndex: 1456
{
	// Fields
	private List<T> list; // 0x0
	private int index; // 0x0
	private int version; // 0x0
	private T current; // 0x0

	// Properties
	public T Current { get; }
	private object System.Collections.IEnumerator.Current { get; }

	// Methods

	// RVA: -1 Offset: -1
	internal void .ctor(List<T> list) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B2C4 Offset: 0x74B2C4 VA: 0x74B2C4
	|-List.Enumerator<CommandArg>..ctor
	|
	|-RVA: 0x74B33C Offset: 0x74B33C VA: 0x74B33C
	|-List.Enumerator<LogItem>..ctor
	|
	|-RVA: 0x74B3C8 Offset: 0x74B3C8 VA: 0x74B3C8
	|-List.Enumerator<decalInfo>..ctor
	|
	|-RVA: 0x74B464 Offset: 0x74B464 VA: 0x74B464
	|-List.Enumerator<objectIn2Bound>..ctor
	|
	|-RVA: 0x74B4F8 Offset: 0x74B4F8 VA: 0x74B4F8
	|-List.Enumerator<F2NormalButton.GraphicItem>..ctor
	|
	|-RVA: 0x74B580 Offset: 0x74B580 VA: 0x74B580
	|-List.Enumerator<Entity>..ctor
	|
	|-RVA: 0x74B608 Offset: 0x74B608 VA: 0x74B608
	|-List.Enumerator<StringTuple>..ctor
	|
	|-RVA: 0x74B694 Offset: 0x74B694 VA: 0x74B694
	|-List.Enumerator<U64Id>..ctor
	|
	|-RVA: 0x74B710 Offset: 0x74B710 VA: 0x74B710
	|-List.Enumerator<WordsSearch.WordsSearchTuple>..ctor
	|
	|-RVA: 0x74B798 Offset: 0x74B798 VA: 0x74B798
	|-List.Enumerator<ChildANA>..ctor
	|
	|-RVA: 0x74B810 Offset: 0x74B810 VA: 0x74B810
	|-List.Enumerator<RagdollBone>..ctor
	|
	|-RVA: 0x74B8A4 Offset: 0x74B8A4 VA: 0x74B8A4
	|-List.Enumerator<LogData>..ctor
	|
	|-RVA: 0x74B92C Offset: 0x74B92C VA: 0x74B92C
	|-List.Enumerator<ServerTimeManager.AddParam>..ctor
	|
	|-RVA: 0x74B9C4 Offset: 0x74B9C4 VA: 0x74B9C4
	|-List.Enumerator<RendererAndSubmeshIndex>..ctor
	|
	|-RVA: 0x74BA4C Offset: 0x74BA4C VA: 0x74BA4C
	|-List.Enumerator<BakedData.LightBakingData>..ctor
	|
	|-RVA: 0x74BAE0 Offset: 0x74BAE0 VA: 0x74BAE0
	|-List.Enumerator<BakedData.Lightmap>..ctor
	|
	|-RVA: 0x74BB68 Offset: 0x74BB68 VA: 0x74BB68
	|-List.Enumerator<BakedData.MeshBakingData>..ctor
	|
	|-RVA: 0x74BC08 Offset: 0x74BC08 VA: 0x74BC08
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>..ctor
	|
	|-RVA: 0x74BC90 Offset: 0x74BC90 VA: 0x74BC90
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>..ctor
	|
	|-RVA: 0x74BD18 Offset: 0x74BD18 VA: 0x74BD18
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>..ctor
	|
	|-RVA: 0x74BDA8 Offset: 0x74BDA8 VA: 0x74BDA8
	|-List.Enumerator<LoaderMeshInfo>..ctor
	|
	|-RVA: 0x74BE20 Offset: 0x74BE20 VA: 0x74BE20
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>..ctor
	|
	|-RVA: 0x74BEA8 Offset: 0x74BEA8 VA: 0x74BEA8
	|-List.Enumerator<ScanUtils.Result>..ctor
	|
	|-RVA: 0x74BF30 Offset: 0x74BF30 VA: 0x74BF30
	|-List.Enumerator<Pair>..ctor
	|
	|-RVA: 0x74BFB8 Offset: 0x74BFB8 VA: 0x74BFB8
	|-List.Enumerator<FVector2>..ctor
	|
	|-RVA: 0x74C040 Offset: 0x74C040 VA: 0x74C040
	|-List.Enumerator<FVector3>..ctor
	|
	|-RVA: 0x74C0CC Offset: 0x74C0CC VA: 0x74C0CC
	|-List.Enumerator<ShapeData>..ctor
	|
	|-RVA: 0x74C158 Offset: 0x74C158 VA: 0x74C158
	|-List.Enumerator<CCContact>..ctor
	|
	|-RVA: 0x74C1EC Offset: 0x74C1EC VA: 0x74C1EC
	|-List.Enumerator<Line>..ctor
	|
	|-RVA: 0x74C274 Offset: 0x74C274 VA: 0x74C274
	|-List.Enumerator<GetBackResult>..ctor
	|
	|-RVA: 0x74C30C Offset: 0x74C30C VA: 0x74C30C
	|-List.Enumerator<SubMeshInstance>..ctor
	|
	|-RVA: 0x74C394 Offset: 0x74C394 VA: 0x74C394
	|-List.Enumerator<GeometryCollection.ObjectInfo>..ctor
	|
	|-RVA: 0x74C428 Offset: 0x74C428 VA: 0x74C428
	|-List.Enumerator<JsonPosition>..ctor
	|
	|-RVA: 0x74C4B0 Offset: 0x74C4B0 VA: 0x74C4B0
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>..ctor
	|
	|-RVA: 0x74C544 Offset: 0x74C544 VA: 0x74C544
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>..ctor
	|
	|-RVA: 0x74C5D0 Offset: 0x74C5D0 VA: 0x74C5D0
	|-List.Enumerator<EventQueue.EventQueueEntry>..ctor
	|
	|-RVA: 0x74C65C Offset: 0x74C65C VA: 0x74C65C
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>..ctor
	|
	|-RVA: 0x74C6E8 Offset: 0x74C6E8 VA: 0x74C6E8
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>..ctor
	|
	|-RVA: 0x74C774 Offset: 0x74C774 VA: 0x74C774
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>..ctor
	|
	|-RVA: 0x74C7FC Offset: 0x74C7FC VA: 0x74C7FC
	|-List.Enumerator<bool>..ctor
	|
	|-RVA: 0x74C874 Offset: 0x74C874 VA: 0x74C874
	|-List.Enumerator<byte>..ctor
	|
	|-RVA: 0x74C8EC Offset: 0x74C8EC VA: 0x74C8EC
	|-List.Enumerator<char>..ctor
	|
	|-RVA: 0x74C964 Offset: 0x74C964 VA: 0x74C964
	|-List.Enumerator<DictionaryEntry>..ctor
	|
	|-RVA: 0x74C9EC Offset: 0x74C9EC VA: 0x74C9EC
	|-List.Enumerator<KeyValuePair<U64Id, object>>..ctor
	|
	|-RVA: 0x74CA70 Offset: 0x74CA70 VA: 0x74CA70
	|-List.Enumerator<KeyValuePair<DateTime, object>>..ctor
	|
	|-RVA: 0x74CAF4 Offset: 0x74CAF4 VA: 0x74CAF4
	|-List.Enumerator<KeyValuePair<int, int>>..ctor
	|
	|-RVA: 0x74CB7C Offset: 0x74CB7C VA: 0x74CB7C
	|-List.Enumerator<KeyValuePair<int, object>>..ctor
	|
	|-RVA: 0x74CC04 Offset: 0x74CC04 VA: 0x74CC04
	|-List.Enumerator<KeyValuePair<object, object>>..ctor
	|
	|-RVA: 0x74CC8C Offset: 0x74CC8C VA: 0x74CC8C
	|-List.Enumerator<KeyValuePair<uint, object>>..ctor
	|
	|-RVA: 0x74CD14 Offset: 0x74CD14 VA: 0x74CD14
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>..ctor
	|
	|-RVA: 0x74CDA4 Offset: 0x74CDA4 VA: 0x74CDA4
	|-List.Enumerator<DateTime>..ctor
	|
	|-RVA: 0x74CE20 Offset: 0x74CE20 VA: 0x74CE20
	|-List.Enumerator<DateTimeOffset>..ctor
	|
	|-RVA: 0x74CEA4 Offset: 0x74CEA4 VA: 0x74CEA4
	|-List.Enumerator<Decimal>..ctor
	|
	|-RVA: 0x74CF2C Offset: 0x74CF2C VA: 0x74CF2C
	|-List.Enumerator<double>..ctor
	|
	|-RVA: 0x74CFA8 Offset: 0x74CFA8 VA: 0x74CFA8
	|-List.Enumerator<short>..ctor
	|
	|-RVA: 0x74D020 Offset: 0x74D020 VA: 0x74D020
	|-List.Enumerator<int>..ctor
	|
	|-RVA: 0x74D098 Offset: 0x74D098 VA: 0x74D098
	|-List.Enumerator<Int32Enum>..ctor
	|
	|-RVA: 0x74D110 Offset: 0x74D110 VA: 0x74D110
	|-List.Enumerator<long>..ctor
	|
	|-RVA: 0x74D188 Offset: 0x74D188 VA: 0x74D188
	|-List.Enumerator<object>..ctor
	|
	|-RVA: 0x74D200 Offset: 0x74D200 VA: 0x74D200
	|-List.Enumerator<sbyte>..ctor
	|
	|-RVA: 0x74D278 Offset: 0x74D278 VA: 0x74D278
	|-List.Enumerator<float>..ctor
	|
	|-RVA: 0x74D2F0 Offset: 0x74D2F0 VA: 0x74D2F0
	|-List.Enumerator<TimeSpan>..ctor
	|
	|-RVA: 0x74D36C Offset: 0x74D36C VA: 0x74D36C
	|-List.Enumerator<ushort>..ctor
	|
	|-RVA: 0x74D3E4 Offset: 0x74D3E4 VA: 0x74D3E4
	|-List.Enumerator<uint>..ctor
	|
	|-RVA: 0x74D45C Offset: 0x74D45C VA: 0x74D45C
	|-List.Enumerator<ulong>..ctor
	|
	|-RVA: 0x74D4D4 Offset: 0x74D4D4 VA: 0x74D4D4
	|-List.Enumerator<ValueTuple<object, Vector3>>..ctor
	|
	|-RVA: 0x74D55C Offset: 0x74D55C VA: 0x74D55C
	|-List.Enumerator<ValueTuple<float, Vector3>>..ctor
	|
	|-RVA: 0x74D5E4 Offset: 0x74D5E4 VA: 0x74D5E4
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>..ctor
	|
	|-RVA: 0x74D67C Offset: 0x74D67C VA: 0x74D67C
	|-List.Enumerator<RangePositionInfo>..ctor
	|
	|-RVA: 0x74D704 Offset: 0x74D704 VA: 0x74D704
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>..ctor
	|
	|-RVA: 0x74D78C Offset: 0x74D78C VA: 0x74D78C
	|-List.Enumerator<TexturePacker.SpriteData>..ctor
	|
	|-RVA: 0x74D844 Offset: 0x74D844 VA: 0x74D844
	|-List.Enumerator<TestAudioData.AudioRecord>..ctor
	|
	|-RVA: 0x74D8E0 Offset: 0x74D8E0 VA: 0x74D8E0
	|-List.Enumerator<NativeList<int>>..ctor
	|
	|-RVA: 0x74D968 Offset: 0x74D968 VA: 0x74D968
	|-List.Enumerator<AnimatorClipInfo>..ctor
	|
	|-RVA: 0x74D9F0 Offset: 0x74D9F0 VA: 0x74D9F0
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>..ctor
	|
	|-RVA: 0x74DA78 Offset: 0x74DA78 VA: 0x74DA78
	|-List.Enumerator<BoneWeight>..ctor
	|
	|-RVA: 0x74DB14 Offset: 0x74DB14 VA: 0x74DB14
	|-List.Enumerator<Color32>..ctor
	|
	|-RVA: 0x74DB8C Offset: 0x74DB8C VA: 0x74DB8C
	|-List.Enumerator<Color>..ctor
	|
	|-RVA: 0x74DC14 Offset: 0x74DC14 VA: 0x74DC14
	|-List.Enumerator<CombineInstance>..ctor
	|
	|-RVA: 0x74DCA4 Offset: 0x74DCA4 VA: 0x74DCA4
	|-List.Enumerator<RaycastResult>..ctor
	|
	|-RVA: 0x74DD5C Offset: 0x74DD5C VA: 0x74DD5C
	|-List.Enumerator<IntervalTreeNode>..ctor
	|
	|-RVA: 0x74DDF0 Offset: 0x74DDF0 VA: 0x74DDF0
	|-List.Enumerator<IntervalTree.Entry<object>>..ctor
	|
	|-RVA: 0x74DE84 Offset: 0x74DE84 VA: 0x74DE84
	|-List.Enumerator<Matrix4x4>..ctor
	|
	|-RVA: 0x74DF3C Offset: 0x74DF3C VA: 0x74DF3C
	|-List.Enumerator<Playable>..ctor
	|
	|-RVA: 0x74DFC4 Offset: 0x74DFC4 VA: 0x74DFC4
	|-List.Enumerator<RaycastHit>..ctor
	|
	|-RVA: 0x74E06C Offset: 0x74E06C VA: 0x74E06C
	|-List.Enumerator<RenderTargetIdentifier>..ctor
	|
	|-RVA: 0x74E10C Offset: 0x74E10C VA: 0x74E10C
	|-List.Enumerator<GlyphRect>..ctor
	|
	|-RVA: 0x7CF73C Offset: 0x7CF73C VA: 0x7CF73C
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>..ctor
	|
	|-RVA: 0x7CF7D4 Offset: 0x7CF7D4 VA: 0x7CF7D4
	|-List.Enumerator<UICharInfo>..ctor
	|
	|-RVA: 0x7CF860 Offset: 0x7CF860 VA: 0x7CF860
	|-List.Enumerator<UILineInfo>..ctor
	|
	|-RVA: 0x7CF8E8 Offset: 0x7CF8E8 VA: 0x7CF8E8
	|-List.Enumerator<UIVertex>..ctor
	|
	|-RVA: 0x7CF978 Offset: 0x7CF978 VA: 0x7CF978
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>..ctor
	|
	|-RVA: 0x7CFA04 Offset: 0x7CFA04 VA: 0x7CFA04
	|-List.Enumerator<Vector2>..ctor
	|
	|-RVA: 0x7CFA8C Offset: 0x7CFA8C VA: 0x7CFA8C
	|-List.Enumerator<Vector3>..ctor
	|
	|-RVA: 0x7CFB18 Offset: 0x7CFB18 VA: 0x7CFB18
	|-List.Enumerator<Vector4>..ctor
	|
	|-RVA: 0x7CFBA0 Offset: 0x7CFBA0 VA: 0x7CFBA0
	|-List.Enumerator<LODGenerator.SkinnedRenderer>..ctor
	|
	|-RVA: 0x7CFC40 Offset: 0x7CFC40 VA: 0x7CFC40
	|-List.Enumerator<LODGenerator.StaticRenderer>..ctor
	|
	|-RVA: 0x7CFCD4 Offset: 0x7CFCD4 VA: 0x7CFCD4
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>..ctor
	*/

	// RVA: -1 Offset: -1 Slot: 5
	public void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B300 Offset: 0x74B300 VA: 0x74B300
	|-List.Enumerator<CommandArg>.Dispose
	|
	|-RVA: 0x74B380 Offset: 0x74B380 VA: 0x74B380
	|-List.Enumerator<LogItem>.Dispose
	|
	|-RVA: 0x74D1C4 Offset: 0x74D1C4 VA: 0x74D1C4
	|-List.Enumerator<CustomizableComp>.Dispose
	|-List.Enumerator<DynamicGoalTooltip>.Dispose
	|-List.Enumerator<IllegalWordsSearch.NodeInfo>.Dispose
	|-List.Enumerator<IllegalWordsSearchEx.TreeNode>.Dispose
	|-List.Enumerator<IllegalWordsSearchResult>.Dispose
	|-List.Enumerator<AssetRecord>.Dispose
	|-List.Enumerator<UnityCallBackRegister.UpdateItem>.Dispose
	|-List.Enumerator<AssetItem>.Dispose
	|-List.Enumerator<Transition>.Dispose
	|-List.Enumerator<MainCharacterController.TrapBombSkill.GetBackData>.Dispose
	|-List.Enumerator<IStateTranslate>.Dispose
	|-List.Enumerator<LocalToolBaseCtrlr.State>.Dispose
	|-List.Enumerator<TransitionWorker>.Dispose
	|-List.Enumerator<ICharacterProxy>.Dispose
	|-List.Enumerator<IDynamicGoalProxy>.Dispose
	|-List.Enumerator<ISurveillanceCamProxy>.Dispose
	|-List.Enumerator<IUniversalSceneTool>.Dispose
	|-List.Enumerator<ScoutCar>.Dispose
	|-List.Enumerator<IGizmosDrawable>.Dispose
	|-List.Enumerator<IEffect>.Dispose
	|-List.Enumerator<IEffectBehaviour>.Dispose
	|-List.Enumerator<ILightweightTrigger>.Dispose
	|-List.Enumerator<ITriggerSponsor>.Dispose
	|-List.Enumerator<TrapBombTrigger.PlaceData>.Dispose
	|-List.Enumerator<TrapBombTrigger>.Dispose
	|-List.Enumerator<DcelEdge>.Dispose
	|-List.Enumerator<DcelFace>.Dispose
	|-List.Enumerator<DcelTree>.Dispose
	|-List.Enumerator<Element<FixtureProxy>>.Dispose
	|-List.Enumerator<CurveKey>.Dispose
	|-List.Enumerator<DelaunayTriangle>.Dispose
	|-List.Enumerator<DTSweepConstraint>.Dispose
	|-List.Enumerator<Polygon>.Dispose
	|-List.Enumerator<TriangulationPoint>.Dispose
	|-List.Enumerator<Edge>.Dispose
	|-List.Enumerator<Node>.Dispose
	|-List.Enumerator<Point>.Dispose
	|-List.Enumerator<Trapezoid>.Dispose
	|-List.Enumerator<DetectedVertices>.Dispose
	|-List.Enumerator<MarchingSquares.GeomPoly>.Dispose
	|-List.Enumerator<Vertices>.Dispose
	|-List.Enumerator<Body>.Dispose
	|-List.Enumerator<Fixture>.Dispose
	|-List.Enumerator<FarseerJoint>.Dispose
	|-List.Enumerator<BaseTriggerGroup>.Dispose
	|-List.Enumerator<PanelArea>.Dispose
	|-List.Enumerator<BoundaryEdgeList>.Dispose
	|-List.Enumerator<JumpTrigger>.Dispose
	|-List.Enumerator<ReinforceTrigger>.Dispose
	|-List.Enumerator<RopeClimbingTrigger>.Dispose
	|-List.Enumerator<LockOutlineBtn>.Dispose
	|-List.Enumerator<BaseView>.Dispose
	|-List.Enumerator<LocWeaponInfo>.Dispose
	|-List.Enumerator<PreBattleEquipmentSettingView.PartUI>.Dispose
	|-List.Enumerator<PreBattleEquipmentSettingView.WeaponUI>.Dispose
	|-List.Enumerator<PreBattleSpawnRegionSelectView.PlayerUI>.Dispose
	|-List.Enumerator<PreBattleSpawnRegionSelectView.RegionUI>.Dispose
	|-List.Enumerator<SpawnRegionViewData.PlayerData>.Dispose
	|-List.Enumerator<SpawnRegionViewData.RegionData>.Dispose
	|-List.Enumerator<PermanentTextEntity>.Dispose
	|-List.Enumerator<OpTabButton>.Dispose
	|-List.Enumerator<ScrollTextEntity>.Dispose
	|-List.Enumerator<ITextEntity>.Dispose
	|-List.Enumerator<IMapPointView>.Dispose
	|-List.Enumerator<ScoreTextEntity>.Dispose
	|-List.Enumerator<UIBattleScreenTooltipsControl.IScreenTooltip>.Dispose
	|-List.Enumerator<UIBattleWarnEnemyTooltipsControl.WarnEnemyTooltip>.Dispose
	|-List.Enumerator<ITriStateBtnDisplay>.Dispose
	|-List.Enumerator<MVPCharacterData>.Dispose
	|-List.Enumerator<JsonSerializerInternalReader.CreatorPropertyContext>.Dispose
	|-List.Enumerator<SerializationCallback>.Dispose
	|-List.Enumerator<SelectOccPage2.PlayerOccCtrlr>.Dispose
	|-List.Enumerator<SoundBox>.Dispose
	|-List.Enumerator<Attachment>.Dispose
	|-List.Enumerator<BoneData>.Dispose
	|-List.Enumerator<SkeletonPartsRenderer>.Dispose
	|-List.Enumerator<client.Stat>.Dispose
	|-List.Enumerator<game.CharacterChoosePlayer>.Dispose
	|-List.Enumerator<Action<string, string>>.Dispose
	|-List.Enumerator<byte[]>.Dispose
	|-List.Enumerator<List<Point>>.Dispose
	|-List.Enumerator<List<int>>.Dispose
	|-List.Enumerator<int[]>.Dispose
	|-List.Enumerator<ModifierSpec>.Dispose
	|-List.Enumerator<IPAddress>.Dispose
	|-List.Enumerator<MonoChunkStream.Chunk>.Dispose
	|-List.Enumerator<WebConnection>.Dispose
	|-List.Enumerator<WebConnectionGroup>.Dispose
	|-List.Enumerator<object>.Dispose
	|-List.Enumerator<Assembly>.Dispose
	|-List.Enumerator<MemberInfo>.Dispose
	|-List.Enumerator<MethodInfo>.Dispose
	|-List.Enumerator<ExceptionDispatchInfo>.Dispose
	|-List.Enumerator<IContextProperty>.Dispose
	|-List.Enumerator<X509CertificateImpl>.Dispose
	|-List.Enumerator<string>.Dispose
	|-List.Enumerator<IAsyncLocal>.Dispose
	|-List.Enumerator<Task>.Dispose
	|-List.Enumerator<Thread>.Dispose
	|-List.Enumerator<Type>.Dispose
	|-List.Enumerator<TypeIdentifier>.Dispose
	|-List.Enumerator<XmlReflectionMember>.Dispose
	|-List.Enumerator<XmlQualifiedName>.Dispose
	|-List.Enumerator<ThermalImagerManager.ProjectorRenderAndMat>.Dispose
	|-List.Enumerator<UIBattleCharactersTooltipControl.CharacterTooltip>.Dispose
	|-List.Enumerator<UIBattleFPEffectsControl.DamageArrow>.Dispose
	|-List.Enumerator<UIBattleMiniCarControl.CicleFlag>.Dispose
	|-List.Enumerator<UIBattleMiniCarTooltipControl.MiniCarTooltip>.Dispose
	|-List.Enumerator<UIBattleResultUI.WinerCharacterTooltip>.Dispose
	|-List.Enumerator<UIBattleScanCharacterTooltipCtrl.ICharacterTooltip>.Dispose
	|-List.Enumerator<UIBattleSkullTooltipControl.SkullTooltip>.Dispose
	|-List.Enumerator<UIBattleSurveillanceCamControl.CicleFlag>.Dispose
	|-List.Enumerator<AudioAmbisonicExtensionDefinition>.Dispose
	|-List.Enumerator<AudioSpatializerExtensionDefinition>.Dispose
	|-List.Enumerator<Collider>.Dispose
	|-List.Enumerator<PersistentCall>.Dispose
	|-List.Enumerator<ISubsystem>.Dispose
	|-List.Enumerator<ISubsystemDescriptor>.Dispose
	|-List.Enumerator<ISubsystemDescriptorImpl>.Dispose
	|-List.Enumerator<IRenderPipeline>.Dispose
	|-List.Enumerator<GUILayoutEntry>.Dispose
	|-List.Enumerator<GameObject>.Dispose
	|-List.Enumerator<RectTransform>.Dispose
	|-List.Enumerator<RenderTexture>.Dispose
	|-List.Enumerator<Renderer>.Dispose
	|-List.Enumerator<PostProcessBundle>.Dispose
	|-List.Enumerator<PostProcessEffectSettings>.Dispose
	|-List.Enumerator<PostProcessLayer.SerializedBundleRef>.Dispose
	|-List.Enumerator<PostProcessVolume>.Dispose
	|-List.Enumerator<Texture2D>.Dispose
	|-List.Enumerator<TimelineClip>.Dispose
	|-List.Enumerator<Transform>.Dispose
	|-List.Enumerator<Selectable>.Dispose
	|-List.Enumerator<LuaEnv.CustomLoader>.Dispose
	|-List.Enumerator<Chunk>.Dispose
	|-List.Enumerator<ParsingEvent>.Dispose
	|-List.Enumerator<IObjectGraphVisitor<Nothing>>.Dispose
	|-List.Enumerator<YamlAttributeOverrides.AttributeMapping>.Dispose
	|
	|-RVA: 0x74B414 Offset: 0x74B414 VA: 0x74B414
	|-List.Enumerator<decalInfo>.Dispose
	|
	|-RVA: 0x74B4AC Offset: 0x74B4AC VA: 0x74B4AC
	|-List.Enumerator<objectIn2Bound>.Dispose
	|
	|-RVA: 0x74B538 Offset: 0x74B538 VA: 0x74B538
	|-List.Enumerator<F2NormalButton.GraphicItem>.Dispose
	|
	|-RVA: 0x74B5C0 Offset: 0x74B5C0 VA: 0x74B5C0
	|-List.Enumerator<Entity>.Dispose
	|
	|-RVA: 0x74B64C Offset: 0x74B64C VA: 0x74B64C
	|-List.Enumerator<StringTuple>.Dispose
	|
	|-RVA: 0x74B6D0 Offset: 0x74B6D0 VA: 0x74B6D0
	|-List.Enumerator<U64Id>.Dispose
	|
	|-RVA: 0x74B750 Offset: 0x74B750 VA: 0x74B750
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.Dispose
	|
	|-RVA: 0x74B7D4 Offset: 0x74B7D4 VA: 0x74B7D4
	|-List.Enumerator<ChildANA>.Dispose
	|
	|-RVA: 0x74B858 Offset: 0x74B858 VA: 0x74B858
	|-List.Enumerator<RagdollBone>.Dispose
	|
	|-RVA: 0x74B8E8 Offset: 0x74B8E8 VA: 0x74B8E8
	|-List.Enumerator<LogData>.Dispose
	|
	|-RVA: 0x74B974 Offset: 0x74B974 VA: 0x74B974
	|-List.Enumerator<ServerTimeManager.AddParam>.Dispose
	|
	|-RVA: 0x74BA04 Offset: 0x74BA04 VA: 0x74BA04
	|-List.Enumerator<RendererAndSubmeshIndex>.Dispose
	|
	|-RVA: 0x74BA94 Offset: 0x74BA94 VA: 0x74BA94
	|-List.Enumerator<BakedData.LightBakingData>.Dispose
	|
	|-RVA: 0x74BB20 Offset: 0x74BB20 VA: 0x74BB20
	|-List.Enumerator<BakedData.Lightmap>.Dispose
	|
	|-RVA: 0x74BBB4 Offset: 0x74BBB4 VA: 0x74BBB4
	|-List.Enumerator<BakedData.MeshBakingData>.Dispose
	|
	|-RVA: 0x74BC48 Offset: 0x74BC48 VA: 0x74BC48
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.Dispose
	|
	|-RVA: 0x74BCD0 Offset: 0x74BCD0 VA: 0x74BCD0
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.Dispose
	|
	|-RVA: 0x74BD5C Offset: 0x74BD5C VA: 0x74BD5C
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.Dispose
	|
	|-RVA: 0x74BDE4 Offset: 0x74BDE4 VA: 0x74BDE4
	|-List.Enumerator<LoaderMeshInfo>.Dispose
	|
	|-RVA: 0x74BE60 Offset: 0x74BE60 VA: 0x74BE60
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.Dispose
	|
	|-RVA: 0x74BEE8 Offset: 0x74BEE8 VA: 0x74BEE8
	|-List.Enumerator<ScanUtils.Result>.Dispose
	|
	|-RVA: 0x74BF70 Offset: 0x74BF70 VA: 0x74BF70
	|-List.Enumerator<Pair>.Dispose
	|
	|-RVA: 0x74BFF8 Offset: 0x74BFF8 VA: 0x74BFF8
	|-List.Enumerator<FVector2>.Dispose
	|
	|-RVA: 0x74C084 Offset: 0x74C084 VA: 0x74C084
	|-List.Enumerator<FVector3>.Dispose
	|
	|-RVA: 0x74C110 Offset: 0x74C110 VA: 0x74C110
	|-List.Enumerator<ShapeData>.Dispose
	|
	|-RVA: 0x74C1A0 Offset: 0x74C1A0 VA: 0x74C1A0
	|-List.Enumerator<CCContact>.Dispose
	|
	|-RVA: 0x74C230 Offset: 0x74C230 VA: 0x74C230
	|-List.Enumerator<Line>.Dispose
	|
	|-RVA: 0x74C2BC Offset: 0x74C2BC VA: 0x74C2BC
	|-List.Enumerator<GetBackResult>.Dispose
	|
	|-RVA: 0x74C350 Offset: 0x74C350 VA: 0x74C350
	|-List.Enumerator<SubMeshInstance>.Dispose
	|
	|-RVA: 0x74C3DC Offset: 0x74C3DC VA: 0x74C3DC
	|-List.Enumerator<GeometryCollection.ObjectInfo>.Dispose
	|
	|-RVA: 0x74C46C Offset: 0x74C46C VA: 0x74C46C
	|-List.Enumerator<JsonPosition>.Dispose
	|
	|-RVA: 0x74C4F8 Offset: 0x74C4F8 VA: 0x74C4F8
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.Dispose
	|
	|-RVA: 0x74C588 Offset: 0x74C588 VA: 0x74C588
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.Dispose
	|
	|-RVA: 0x74C614 Offset: 0x74C614 VA: 0x74C614
	|-List.Enumerator<EventQueue.EventQueueEntry>.Dispose
	|
	|-RVA: 0x74C6A0 Offset: 0x74C6A0 VA: 0x74C6A0
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.Dispose
	|
	|-RVA: 0x74C72C Offset: 0x74C72C VA: 0x74C72C
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.Dispose
	|
	|-RVA: 0x74C7B4 Offset: 0x74C7B4 VA: 0x74C7B4
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.Dispose
	|
	|-RVA: 0x74C838 Offset: 0x74C838 VA: 0x74C838
	|-List.Enumerator<bool>.Dispose
	|
	|-RVA: 0x74C8B0 Offset: 0x74C8B0 VA: 0x74C8B0
	|-List.Enumerator<byte>.Dispose
	|
	|-RVA: 0x74C928 Offset: 0x74C928 VA: 0x74C928
	|-List.Enumerator<char>.Dispose
	|
	|-RVA: 0x74C9A4 Offset: 0x74C9A4 VA: 0x74C9A4
	|-List.Enumerator<DictionaryEntry>.Dispose
	|
	|-RVA: 0x74CA2C Offset: 0x74CA2C VA: 0x74CA2C
	|-List.Enumerator<KeyValuePair<U64Id, object>>.Dispose
	|
	|-RVA: 0x74CAB0 Offset: 0x74CAB0 VA: 0x74CAB0
	|-List.Enumerator<KeyValuePair<DateTime, object>>.Dispose
	|
	|-RVA: 0x74CB34 Offset: 0x74CB34 VA: 0x74CB34
	|-List.Enumerator<KeyValuePair<int, int>>.Dispose
	|
	|-RVA: 0x74CBBC Offset: 0x74CBBC VA: 0x74CBBC
	|-List.Enumerator<KeyValuePair<int, object>>.Dispose
	|
	|-RVA: 0x74CC44 Offset: 0x74CC44 VA: 0x74CC44
	|-List.Enumerator<KeyValuePair<object, object>>.Dispose
	|
	|-RVA: 0x74CCCC Offset: 0x74CCCC VA: 0x74CCCC
	|-List.Enumerator<KeyValuePair<uint, Pillar>>.Dispose
	|-List.Enumerator<KeyValuePair<uint, object>>.Dispose
	|
	|-RVA: 0x74CD58 Offset: 0x74CD58 VA: 0x74CD58
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, GeometryData>>>.Dispose
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.Dispose
	|
	|-RVA: 0x74CDE0 Offset: 0x74CDE0 VA: 0x74CDE0
	|-List.Enumerator<DateTime>.Dispose
	|
	|-RVA: 0x74CE60 Offset: 0x74CE60 VA: 0x74CE60
	|-List.Enumerator<DateTimeOffset>.Dispose
	|
	|-RVA: 0x74CEE8 Offset: 0x74CEE8 VA: 0x74CEE8
	|-List.Enumerator<Decimal>.Dispose
	|
	|-RVA: 0x74CF68 Offset: 0x74CF68 VA: 0x74CF68
	|-List.Enumerator<double>.Dispose
	|
	|-RVA: 0x74CFE4 Offset: 0x74CFE4 VA: 0x74CFE4
	|-List.Enumerator<short>.Dispose
	|
	|-RVA: 0x74D05C Offset: 0x74D05C VA: 0x74D05C
	|-List.Enumerator<int>.Dispose
	|
	|-RVA: 0x74D0D4 Offset: 0x74D0D4 VA: 0x74D0D4
	|-List.Enumerator<Int32Enum>.Dispose
	|
	|-RVA: 0x74D14C Offset: 0x74D14C VA: 0x74D14C
	|-List.Enumerator<long>.Dispose
	|
	|-RVA: 0x74D23C Offset: 0x74D23C VA: 0x74D23C
	|-List.Enumerator<sbyte>.Dispose
	|
	|-RVA: 0x74D2B4 Offset: 0x74D2B4 VA: 0x74D2B4
	|-List.Enumerator<float>.Dispose
	|
	|-RVA: 0x74D32C Offset: 0x74D32C VA: 0x74D32C
	|-List.Enumerator<TimeSpan>.Dispose
	|
	|-RVA: 0x74D3A8 Offset: 0x74D3A8 VA: 0x74D3A8
	|-List.Enumerator<ushort>.Dispose
	|
	|-RVA: 0x74D420 Offset: 0x74D420 VA: 0x74D420
	|-List.Enumerator<uint>.Dispose
	|
	|-RVA: 0x74D498 Offset: 0x74D498 VA: 0x74D498
	|-List.Enumerator<ulong>.Dispose
	|
	|-RVA: 0x74D518 Offset: 0x74D518 VA: 0x74D518
	|-List.Enumerator<ValueTuple<object, Vector3>>.Dispose
	|-List.Enumerator<ValueTuple<SkinnedMeshRenderer, Vector3>>.Dispose
	|
	|-RVA: 0x74D5A0 Offset: 0x74D5A0 VA: 0x74D5A0
	|-List.Enumerator<ValueTuple<float, Vector3>>.Dispose
	|
	|-RVA: 0x74D630 Offset: 0x74D630 VA: 0x74D630
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.Dispose
	|
	|-RVA: 0x74D6BC Offset: 0x74D6BC VA: 0x74D6BC
	|-List.Enumerator<RangePositionInfo>.Dispose
	|
	|-RVA: 0x74D744 Offset: 0x74D744 VA: 0x74D744
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.Dispose
	|
	|-RVA: 0x74D7E8 Offset: 0x74D7E8 VA: 0x74D7E8
	|-List.Enumerator<TexturePacker.SpriteData>.Dispose
	|
	|-RVA: 0x74D890 Offset: 0x74D890 VA: 0x74D890
	|-List.Enumerator<TestAudioData.AudioRecord>.Dispose
	|
	|-RVA: 0x74D920 Offset: 0x74D920 VA: 0x74D920
	|-List.Enumerator<NativeList<int>>.Dispose
	|
	|-RVA: 0x74D9A8 Offset: 0x74D9A8 VA: 0x74D9A8
	|-List.Enumerator<AnimatorClipInfo>.Dispose
	|
	|-RVA: 0x74DA30 Offset: 0x74DA30 VA: 0x74DA30
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.Dispose
	|
	|-RVA: 0x74DAC4 Offset: 0x74DAC4 VA: 0x74DAC4
	|-List.Enumerator<BoneWeight>.Dispose
	|
	|-RVA: 0x74DB50 Offset: 0x74DB50 VA: 0x74DB50
	|-List.Enumerator<Color32>.Dispose
	|
	|-RVA: 0x74DBD0 Offset: 0x74DBD0 VA: 0x74DBD0
	|-List.Enumerator<Color>.Dispose
	|
	|-RVA: 0x74DC58 Offset: 0x74DC58 VA: 0x74DC58
	|-List.Enumerator<CombineInstance>.Dispose
	|
	|-RVA: 0x74DD00 Offset: 0x74DD00 VA: 0x74DD00
	|-List.Enumerator<RaycastResult>.Dispose
	|
	|-RVA: 0x74DDA4 Offset: 0x74DDA4 VA: 0x74DDA4
	|-List.Enumerator<IntervalTreeNode>.Dispose
	|
	|-RVA: 0x74DE38 Offset: 0x74DE38 VA: 0x74DE38
	|-List.Enumerator<IntervalTree.Entry<object>>.Dispose
	|
	|-RVA: 0x74DEE0 Offset: 0x74DEE0 VA: 0x74DEE0
	|-List.Enumerator<Matrix4x4>.Dispose
	|
	|-RVA: 0x74DF7C Offset: 0x74DF7C VA: 0x74DF7C
	|-List.Enumerator<Playable>.Dispose
	|
	|-RVA: 0x74E018 Offset: 0x74E018 VA: 0x74E018
	|-List.Enumerator<RaycastHit>.Dispose
	|
	|-RVA: 0x74E0B8 Offset: 0x74E0B8 VA: 0x74E0B8
	|-List.Enumerator<RenderTargetIdentifier>.Dispose
	|
	|-RVA: 0x74E150 Offset: 0x74E150 VA: 0x74E150
	|-List.Enumerator<GlyphRect>.Dispose
	|
	|-RVA: 0x7CF788 Offset: 0x7CF788 VA: 0x7CF788
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.Dispose
	|
	|-RVA: 0x7CF818 Offset: 0x7CF818 VA: 0x7CF818
	|-List.Enumerator<UICharInfo>.Dispose
	|
	|-RVA: 0x7CF8A4 Offset: 0x7CF8A4 VA: 0x7CF8A4
	|-List.Enumerator<UILineInfo>.Dispose
	|
	|-RVA: 0x7CF92C Offset: 0x7CF92C VA: 0x7CF92C
	|-List.Enumerator<UIVertex>.Dispose
	|
	|-RVA: 0x7CF9BC Offset: 0x7CF9BC VA: 0x7CF9BC
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.Dispose
	|
	|-RVA: 0x7CFA44 Offset: 0x7CFA44 VA: 0x7CFA44
	|-List.Enumerator<Vector2>.Dispose
	|
	|-RVA: 0x7CFAD0 Offset: 0x7CFAD0 VA: 0x7CFAD0
	|-List.Enumerator<Vector3>.Dispose
	|
	|-RVA: 0x7CFB5C Offset: 0x7CFB5C VA: 0x7CFB5C
	|-List.Enumerator<Vector4>.Dispose
	|
	|-RVA: 0x7CFBEC Offset: 0x7CFBEC VA: 0x7CFBEC
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.Dispose
	|
	|-RVA: 0x7CFC88 Offset: 0x7CFC88 VA: 0x7CFC88
	|-List.Enumerator<LODGenerator.StaticRenderer>.Dispose
	|
	|-RVA: 0x7CFD14 Offset: 0x7CFD14 VA: 0x7CFD14
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.Dispose
	*/

	// RVA: -1 Offset: -1 Slot: 6
	public bool MoveNext() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B304 Offset: 0x74B304 VA: 0x74B304
	|-List.Enumerator<CommandArg>.MoveNext
	|
	|-RVA: 0x74B384 Offset: 0x74B384 VA: 0x74B384
	|-List.Enumerator<LogItem>.MoveNext
	|
	|-RVA: 0x74D1C8 Offset: 0x74D1C8 VA: 0x74D1C8
	|-List.Enumerator<CustomizableComp>.MoveNext
	|-List.Enumerator<DynamicGoalTooltip>.MoveNext
	|-List.Enumerator<IllegalWordsSearch.NodeInfo>.MoveNext
	|-List.Enumerator<IllegalWordsSearchEx.TreeNode>.MoveNext
	|-List.Enumerator<IllegalWordsSearchResult>.MoveNext
	|-List.Enumerator<AssetRecord>.MoveNext
	|-List.Enumerator<UnityCallBackRegister.UpdateItem>.MoveNext
	|-List.Enumerator<AssetItem>.MoveNext
	|-List.Enumerator<Transition>.MoveNext
	|-List.Enumerator<MainCharacterController.TrapBombSkill.GetBackData>.MoveNext
	|-List.Enumerator<IStateTranslate>.MoveNext
	|-List.Enumerator<LocalToolBaseCtrlr.State>.MoveNext
	|-List.Enumerator<TransitionWorker>.MoveNext
	|-List.Enumerator<ICharacterProxy>.MoveNext
	|-List.Enumerator<IDynamicGoalProxy>.MoveNext
	|-List.Enumerator<ISurveillanceCamProxy>.MoveNext
	|-List.Enumerator<IUniversalSceneTool>.MoveNext
	|-List.Enumerator<ScoutCar>.MoveNext
	|-List.Enumerator<IGizmosDrawable>.MoveNext
	|-List.Enumerator<IEffect>.MoveNext
	|-List.Enumerator<IEffectBehaviour>.MoveNext
	|-List.Enumerator<ILightweightTrigger>.MoveNext
	|-List.Enumerator<ITriggerSponsor>.MoveNext
	|-List.Enumerator<TrapBombTrigger.PlaceData>.MoveNext
	|-List.Enumerator<TrapBombTrigger>.MoveNext
	|-List.Enumerator<DcelEdge>.MoveNext
	|-List.Enumerator<DcelFace>.MoveNext
	|-List.Enumerator<DcelTree>.MoveNext
	|-List.Enumerator<Element<FixtureProxy>>.MoveNext
	|-List.Enumerator<CurveKey>.MoveNext
	|-List.Enumerator<DelaunayTriangle>.MoveNext
	|-List.Enumerator<DTSweepConstraint>.MoveNext
	|-List.Enumerator<Polygon>.MoveNext
	|-List.Enumerator<TriangulationPoint>.MoveNext
	|-List.Enumerator<Edge>.MoveNext
	|-List.Enumerator<Node>.MoveNext
	|-List.Enumerator<Point>.MoveNext
	|-List.Enumerator<Trapezoid>.MoveNext
	|-List.Enumerator<DetectedVertices>.MoveNext
	|-List.Enumerator<MarchingSquares.GeomPoly>.MoveNext
	|-List.Enumerator<Vertices>.MoveNext
	|-List.Enumerator<Body>.MoveNext
	|-List.Enumerator<Fixture>.MoveNext
	|-List.Enumerator<FarseerJoint>.MoveNext
	|-List.Enumerator<BaseTriggerGroup>.MoveNext
	|-List.Enumerator<PanelArea>.MoveNext
	|-List.Enumerator<BoundaryEdgeList>.MoveNext
	|-List.Enumerator<JumpTrigger>.MoveNext
	|-List.Enumerator<ReinforceTrigger>.MoveNext
	|-List.Enumerator<RopeClimbingTrigger>.MoveNext
	|-List.Enumerator<LockOutlineBtn>.MoveNext
	|-List.Enumerator<BaseView>.MoveNext
	|-List.Enumerator<LocWeaponInfo>.MoveNext
	|-List.Enumerator<PreBattleEquipmentSettingView.PartUI>.MoveNext
	|-List.Enumerator<PreBattleEquipmentSettingView.WeaponUI>.MoveNext
	|-List.Enumerator<PreBattleSpawnRegionSelectView.PlayerUI>.MoveNext
	|-List.Enumerator<PreBattleSpawnRegionSelectView.RegionUI>.MoveNext
	|-List.Enumerator<SpawnRegionViewData.PlayerData>.MoveNext
	|-List.Enumerator<SpawnRegionViewData.RegionData>.MoveNext
	|-List.Enumerator<PermanentTextEntity>.MoveNext
	|-List.Enumerator<OpTabButton>.MoveNext
	|-List.Enumerator<ScrollTextEntity>.MoveNext
	|-List.Enumerator<ITextEntity>.MoveNext
	|-List.Enumerator<IMapPointView>.MoveNext
	|-List.Enumerator<ScoreTextEntity>.MoveNext
	|-List.Enumerator<UIBattleScreenTooltipsControl.IScreenTooltip>.MoveNext
	|-List.Enumerator<UIBattleWarnEnemyTooltipsControl.WarnEnemyTooltip>.MoveNext
	|-List.Enumerator<ITriStateBtnDisplay>.MoveNext
	|-List.Enumerator<MVPCharacterData>.MoveNext
	|-List.Enumerator<JsonSerializerInternalReader.CreatorPropertyContext>.MoveNext
	|-List.Enumerator<SerializationCallback>.MoveNext
	|-List.Enumerator<SelectOccPage2.PlayerOccCtrlr>.MoveNext
	|-List.Enumerator<SoundBox>.MoveNext
	|-List.Enumerator<Attachment>.MoveNext
	|-List.Enumerator<BoneData>.MoveNext
	|-List.Enumerator<SkeletonPartsRenderer>.MoveNext
	|-List.Enumerator<client.Stat>.MoveNext
	|-List.Enumerator<game.CharacterChoosePlayer>.MoveNext
	|-List.Enumerator<Action<string, string>>.MoveNext
	|-List.Enumerator<byte[]>.MoveNext
	|-List.Enumerator<List<Point>>.MoveNext
	|-List.Enumerator<List<int>>.MoveNext
	|-List.Enumerator<int[]>.MoveNext
	|-List.Enumerator<ModifierSpec>.MoveNext
	|-List.Enumerator<IPAddress>.MoveNext
	|-List.Enumerator<MonoChunkStream.Chunk>.MoveNext
	|-List.Enumerator<WebConnection>.MoveNext
	|-List.Enumerator<WebConnectionGroup>.MoveNext
	|-List.Enumerator<object>.MoveNext
	|-List.Enumerator<Assembly>.MoveNext
	|-List.Enumerator<MemberInfo>.MoveNext
	|-List.Enumerator<MethodInfo>.MoveNext
	|-List.Enumerator<ExceptionDispatchInfo>.MoveNext
	|-List.Enumerator<IContextProperty>.MoveNext
	|-List.Enumerator<X509CertificateImpl>.MoveNext
	|-List.Enumerator<string>.MoveNext
	|-List.Enumerator<IAsyncLocal>.MoveNext
	|-List.Enumerator<Task>.MoveNext
	|-List.Enumerator<Thread>.MoveNext
	|-List.Enumerator<Type>.MoveNext
	|-List.Enumerator<TypeIdentifier>.MoveNext
	|-List.Enumerator<XmlReflectionMember>.MoveNext
	|-List.Enumerator<XmlQualifiedName>.MoveNext
	|-List.Enumerator<ThermalImagerManager.ProjectorRenderAndMat>.MoveNext
	|-List.Enumerator<UIBattleCharactersTooltipControl.CharacterTooltip>.MoveNext
	|-List.Enumerator<UIBattleFPEffectsControl.DamageArrow>.MoveNext
	|-List.Enumerator<UIBattleMiniCarControl.CicleFlag>.MoveNext
	|-List.Enumerator<UIBattleMiniCarTooltipControl.MiniCarTooltip>.MoveNext
	|-List.Enumerator<UIBattleResultUI.WinerCharacterTooltip>.MoveNext
	|-List.Enumerator<UIBattleScanCharacterTooltipCtrl.ICharacterTooltip>.MoveNext
	|-List.Enumerator<UIBattleSkullTooltipControl.SkullTooltip>.MoveNext
	|-List.Enumerator<UIBattleSurveillanceCamControl.CicleFlag>.MoveNext
	|-List.Enumerator<AudioAmbisonicExtensionDefinition>.MoveNext
	|-List.Enumerator<AudioSpatializerExtensionDefinition>.MoveNext
	|-List.Enumerator<Collider>.MoveNext
	|-List.Enumerator<PersistentCall>.MoveNext
	|-List.Enumerator<ISubsystem>.MoveNext
	|-List.Enumerator<ISubsystemDescriptor>.MoveNext
	|-List.Enumerator<ISubsystemDescriptorImpl>.MoveNext
	|-List.Enumerator<IRenderPipeline>.MoveNext
	|-List.Enumerator<GUILayoutEntry>.MoveNext
	|-List.Enumerator<GameObject>.MoveNext
	|-List.Enumerator<RectTransform>.MoveNext
	|-List.Enumerator<RenderTexture>.MoveNext
	|-List.Enumerator<Renderer>.MoveNext
	|-List.Enumerator<PostProcessBundle>.MoveNext
	|-List.Enumerator<PostProcessEffectSettings>.MoveNext
	|-List.Enumerator<PostProcessLayer.SerializedBundleRef>.MoveNext
	|-List.Enumerator<PostProcessVolume>.MoveNext
	|-List.Enumerator<Texture2D>.MoveNext
	|-List.Enumerator<TimelineClip>.MoveNext
	|-List.Enumerator<Transform>.MoveNext
	|-List.Enumerator<Selectable>.MoveNext
	|-List.Enumerator<LuaEnv.CustomLoader>.MoveNext
	|-List.Enumerator<Chunk>.MoveNext
	|-List.Enumerator<ParsingEvent>.MoveNext
	|-List.Enumerator<IObjectGraphVisitor<Nothing>>.MoveNext
	|-List.Enumerator<YamlAttributeOverrides.AttributeMapping>.MoveNext
	|
	|-RVA: 0x74B418 Offset: 0x74B418 VA: 0x74B418
	|-List.Enumerator<decalInfo>.MoveNext
	|
	|-RVA: 0x74B4B0 Offset: 0x74B4B0 VA: 0x74B4B0
	|-List.Enumerator<objectIn2Bound>.MoveNext
	|
	|-RVA: 0x74B53C Offset: 0x74B53C VA: 0x74B53C
	|-List.Enumerator<F2NormalButton.GraphicItem>.MoveNext
	|
	|-RVA: 0x74B5C4 Offset: 0x74B5C4 VA: 0x74B5C4
	|-List.Enumerator<Entity>.MoveNext
	|
	|-RVA: 0x74B650 Offset: 0x74B650 VA: 0x74B650
	|-List.Enumerator<StringTuple>.MoveNext
	|
	|-RVA: 0x74B6D4 Offset: 0x74B6D4 VA: 0x74B6D4
	|-List.Enumerator<U64Id>.MoveNext
	|
	|-RVA: 0x74B754 Offset: 0x74B754 VA: 0x74B754
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.MoveNext
	|
	|-RVA: 0x74B7D8 Offset: 0x74B7D8 VA: 0x74B7D8
	|-List.Enumerator<ChildANA>.MoveNext
	|
	|-RVA: 0x74B85C Offset: 0x74B85C VA: 0x74B85C
	|-List.Enumerator<RagdollBone>.MoveNext
	|
	|-RVA: 0x74B8EC Offset: 0x74B8EC VA: 0x74B8EC
	|-List.Enumerator<LogData>.MoveNext
	|
	|-RVA: 0x74B978 Offset: 0x74B978 VA: 0x74B978
	|-List.Enumerator<ServerTimeManager.AddParam>.MoveNext
	|
	|-RVA: 0x74BA08 Offset: 0x74BA08 VA: 0x74BA08
	|-List.Enumerator<RendererAndSubmeshIndex>.MoveNext
	|
	|-RVA: 0x74BA98 Offset: 0x74BA98 VA: 0x74BA98
	|-List.Enumerator<BakedData.LightBakingData>.MoveNext
	|
	|-RVA: 0x74BB24 Offset: 0x74BB24 VA: 0x74BB24
	|-List.Enumerator<BakedData.Lightmap>.MoveNext
	|
	|-RVA: 0x74BBB8 Offset: 0x74BBB8 VA: 0x74BBB8
	|-List.Enumerator<BakedData.MeshBakingData>.MoveNext
	|
	|-RVA: 0x74BC4C Offset: 0x74BC4C VA: 0x74BC4C
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.MoveNext
	|
	|-RVA: 0x74BCD4 Offset: 0x74BCD4 VA: 0x74BCD4
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.MoveNext
	|
	|-RVA: 0x74BD60 Offset: 0x74BD60 VA: 0x74BD60
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.MoveNext
	|
	|-RVA: 0x74BDE8 Offset: 0x74BDE8 VA: 0x74BDE8
	|-List.Enumerator<LoaderMeshInfo>.MoveNext
	|
	|-RVA: 0x74BE64 Offset: 0x74BE64 VA: 0x74BE64
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.MoveNext
	|
	|-RVA: 0x74BEEC Offset: 0x74BEEC VA: 0x74BEEC
	|-List.Enumerator<ScanUtils.Result>.MoveNext
	|
	|-RVA: 0x74BF74 Offset: 0x74BF74 VA: 0x74BF74
	|-List.Enumerator<Pair>.MoveNext
	|
	|-RVA: 0x74BFFC Offset: 0x74BFFC VA: 0x74BFFC
	|-List.Enumerator<FVector2>.MoveNext
	|
	|-RVA: 0x74C088 Offset: 0x74C088 VA: 0x74C088
	|-List.Enumerator<FVector3>.MoveNext
	|
	|-RVA: 0x74C114 Offset: 0x74C114 VA: 0x74C114
	|-List.Enumerator<ShapeData>.MoveNext
	|
	|-RVA: 0x74C1A4 Offset: 0x74C1A4 VA: 0x74C1A4
	|-List.Enumerator<CCContact>.MoveNext
	|
	|-RVA: 0x74C234 Offset: 0x74C234 VA: 0x74C234
	|-List.Enumerator<Line>.MoveNext
	|
	|-RVA: 0x74C2C0 Offset: 0x74C2C0 VA: 0x74C2C0
	|-List.Enumerator<GetBackResult>.MoveNext
	|
	|-RVA: 0x74C354 Offset: 0x74C354 VA: 0x74C354
	|-List.Enumerator<SubMeshInstance>.MoveNext
	|
	|-RVA: 0x74C3E0 Offset: 0x74C3E0 VA: 0x74C3E0
	|-List.Enumerator<GeometryCollection.ObjectInfo>.MoveNext
	|
	|-RVA: 0x74C470 Offset: 0x74C470 VA: 0x74C470
	|-List.Enumerator<JsonPosition>.MoveNext
	|
	|-RVA: 0x74C4FC Offset: 0x74C4FC VA: 0x74C4FC
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.MoveNext
	|
	|-RVA: 0x74C58C Offset: 0x74C58C VA: 0x74C58C
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.MoveNext
	|
	|-RVA: 0x74C618 Offset: 0x74C618 VA: 0x74C618
	|-List.Enumerator<EventQueue.EventQueueEntry>.MoveNext
	|
	|-RVA: 0x74C6A4 Offset: 0x74C6A4 VA: 0x74C6A4
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.MoveNext
	|
	|-RVA: 0x74C730 Offset: 0x74C730 VA: 0x74C730
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.MoveNext
	|
	|-RVA: 0x74C7B8 Offset: 0x74C7B8 VA: 0x74C7B8
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.MoveNext
	|
	|-RVA: 0x74C83C Offset: 0x74C83C VA: 0x74C83C
	|-List.Enumerator<bool>.MoveNext
	|
	|-RVA: 0x74C8B4 Offset: 0x74C8B4 VA: 0x74C8B4
	|-List.Enumerator<byte>.MoveNext
	|
	|-RVA: 0x74C92C Offset: 0x74C92C VA: 0x74C92C
	|-List.Enumerator<char>.MoveNext
	|
	|-RVA: 0x74C9A8 Offset: 0x74C9A8 VA: 0x74C9A8
	|-List.Enumerator<DictionaryEntry>.MoveNext
	|
	|-RVA: 0x74CA30 Offset: 0x74CA30 VA: 0x74CA30
	|-List.Enumerator<KeyValuePair<U64Id, object>>.MoveNext
	|
	|-RVA: 0x74CAB4 Offset: 0x74CAB4 VA: 0x74CAB4
	|-List.Enumerator<KeyValuePair<DateTime, object>>.MoveNext
	|
	|-RVA: 0x74CB38 Offset: 0x74CB38 VA: 0x74CB38
	|-List.Enumerator<KeyValuePair<int, int>>.MoveNext
	|
	|-RVA: 0x74CBC0 Offset: 0x74CBC0 VA: 0x74CBC0
	|-List.Enumerator<KeyValuePair<int, object>>.MoveNext
	|
	|-RVA: 0x74CC48 Offset: 0x74CC48 VA: 0x74CC48
	|-List.Enumerator<KeyValuePair<object, object>>.MoveNext
	|
	|-RVA: 0x74CCD0 Offset: 0x74CCD0 VA: 0x74CCD0
	|-List.Enumerator<KeyValuePair<uint, Pillar>>.MoveNext
	|-List.Enumerator<KeyValuePair<uint, object>>.MoveNext
	|
	|-RVA: 0x74CD5C Offset: 0x74CD5C VA: 0x74CD5C
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, GeometryData>>>.MoveNext
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.MoveNext
	|
	|-RVA: 0x74CDE4 Offset: 0x74CDE4 VA: 0x74CDE4
	|-List.Enumerator<DateTime>.MoveNext
	|
	|-RVA: 0x74CE64 Offset: 0x74CE64 VA: 0x74CE64
	|-List.Enumerator<DateTimeOffset>.MoveNext
	|
	|-RVA: 0x74CEEC Offset: 0x74CEEC VA: 0x74CEEC
	|-List.Enumerator<Decimal>.MoveNext
	|
	|-RVA: 0x74CF6C Offset: 0x74CF6C VA: 0x74CF6C
	|-List.Enumerator<double>.MoveNext
	|
	|-RVA: 0x74CFE8 Offset: 0x74CFE8 VA: 0x74CFE8
	|-List.Enumerator<short>.MoveNext
	|
	|-RVA: 0x74D060 Offset: 0x74D060 VA: 0x74D060
	|-List.Enumerator<int>.MoveNext
	|
	|-RVA: 0x74D0D8 Offset: 0x74D0D8 VA: 0x74D0D8
	|-List.Enumerator<Int32Enum>.MoveNext
	|
	|-RVA: 0x74D150 Offset: 0x74D150 VA: 0x74D150
	|-List.Enumerator<long>.MoveNext
	|
	|-RVA: 0x74D240 Offset: 0x74D240 VA: 0x74D240
	|-List.Enumerator<sbyte>.MoveNext
	|
	|-RVA: 0x74D2B8 Offset: 0x74D2B8 VA: 0x74D2B8
	|-List.Enumerator<float>.MoveNext
	|
	|-RVA: 0x74D330 Offset: 0x74D330 VA: 0x74D330
	|-List.Enumerator<TimeSpan>.MoveNext
	|
	|-RVA: 0x74D3AC Offset: 0x74D3AC VA: 0x74D3AC
	|-List.Enumerator<ushort>.MoveNext
	|
	|-RVA: 0x74D424 Offset: 0x74D424 VA: 0x74D424
	|-List.Enumerator<uint>.MoveNext
	|
	|-RVA: 0x74D49C Offset: 0x74D49C VA: 0x74D49C
	|-List.Enumerator<ulong>.MoveNext
	|
	|-RVA: 0x74D51C Offset: 0x74D51C VA: 0x74D51C
	|-List.Enumerator<ValueTuple<object, Vector3>>.MoveNext
	|-List.Enumerator<ValueTuple<SkinnedMeshRenderer, Vector3>>.MoveNext
	|
	|-RVA: 0x74D5A4 Offset: 0x74D5A4 VA: 0x74D5A4
	|-List.Enumerator<ValueTuple<float, Vector3>>.MoveNext
	|
	|-RVA: 0x74D634 Offset: 0x74D634 VA: 0x74D634
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.MoveNext
	|
	|-RVA: 0x74D6C0 Offset: 0x74D6C0 VA: 0x74D6C0
	|-List.Enumerator<RangePositionInfo>.MoveNext
	|
	|-RVA: 0x74D748 Offset: 0x74D748 VA: 0x74D748
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.MoveNext
	|
	|-RVA: 0x74D7EC Offset: 0x74D7EC VA: 0x74D7EC
	|-List.Enumerator<TexturePacker.SpriteData>.MoveNext
	|
	|-RVA: 0x74D894 Offset: 0x74D894 VA: 0x74D894
	|-List.Enumerator<TestAudioData.AudioRecord>.MoveNext
	|
	|-RVA: 0x74D924 Offset: 0x74D924 VA: 0x74D924
	|-List.Enumerator<NativeList<int>>.MoveNext
	|
	|-RVA: 0x74D9AC Offset: 0x74D9AC VA: 0x74D9AC
	|-List.Enumerator<AnimatorClipInfo>.MoveNext
	|
	|-RVA: 0x74DA34 Offset: 0x74DA34 VA: 0x74DA34
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.MoveNext
	|
	|-RVA: 0x74DAC8 Offset: 0x74DAC8 VA: 0x74DAC8
	|-List.Enumerator<BoneWeight>.MoveNext
	|
	|-RVA: 0x74DB54 Offset: 0x74DB54 VA: 0x74DB54
	|-List.Enumerator<Color32>.MoveNext
	|
	|-RVA: 0x74DBD4 Offset: 0x74DBD4 VA: 0x74DBD4
	|-List.Enumerator<Color>.MoveNext
	|
	|-RVA: 0x74DC5C Offset: 0x74DC5C VA: 0x74DC5C
	|-List.Enumerator<CombineInstance>.MoveNext
	|
	|-RVA: 0x74DD04 Offset: 0x74DD04 VA: 0x74DD04
	|-List.Enumerator<RaycastResult>.MoveNext
	|
	|-RVA: 0x74DDA8 Offset: 0x74DDA8 VA: 0x74DDA8
	|-List.Enumerator<IntervalTreeNode>.MoveNext
	|
	|-RVA: 0x74DE3C Offset: 0x74DE3C VA: 0x74DE3C
	|-List.Enumerator<IntervalTree.Entry<object>>.MoveNext
	|
	|-RVA: 0x74DEE4 Offset: 0x74DEE4 VA: 0x74DEE4
	|-List.Enumerator<Matrix4x4>.MoveNext
	|
	|-RVA: 0x74DF80 Offset: 0x74DF80 VA: 0x74DF80
	|-List.Enumerator<Playable>.MoveNext
	|
	|-RVA: 0x74E01C Offset: 0x74E01C VA: 0x74E01C
	|-List.Enumerator<RaycastHit>.MoveNext
	|
	|-RVA: 0x74E0BC Offset: 0x74E0BC VA: 0x74E0BC
	|-List.Enumerator<RenderTargetIdentifier>.MoveNext
	|
	|-RVA: 0x74E154 Offset: 0x74E154 VA: 0x74E154
	|-List.Enumerator<GlyphRect>.MoveNext
	|
	|-RVA: 0x7CF78C Offset: 0x7CF78C VA: 0x7CF78C
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.MoveNext
	|
	|-RVA: 0x7CF81C Offset: 0x7CF81C VA: 0x7CF81C
	|-List.Enumerator<UICharInfo>.MoveNext
	|
	|-RVA: 0x7CF8A8 Offset: 0x7CF8A8 VA: 0x7CF8A8
	|-List.Enumerator<UILineInfo>.MoveNext
	|
	|-RVA: 0x7CF930 Offset: 0x7CF930 VA: 0x7CF930
	|-List.Enumerator<UIVertex>.MoveNext
	|
	|-RVA: 0x7CF9C0 Offset: 0x7CF9C0 VA: 0x7CF9C0
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.MoveNext
	|
	|-RVA: 0x7CFA48 Offset: 0x7CFA48 VA: 0x7CFA48
	|-List.Enumerator<Vector2>.MoveNext
	|
	|-RVA: 0x7CFAD4 Offset: 0x7CFAD4 VA: 0x7CFAD4
	|-List.Enumerator<Vector3>.MoveNext
	|
	|-RVA: 0x7CFB60 Offset: 0x7CFB60 VA: 0x7CFB60
	|-List.Enumerator<Vector4>.MoveNext
	|
	|-RVA: 0x7CFBF0 Offset: 0x7CFBF0 VA: 0x7CFBF0
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.MoveNext
	|
	|-RVA: 0x7CFC8C Offset: 0x7CFC8C VA: 0x7CFC8C
	|-List.Enumerator<LODGenerator.StaticRenderer>.MoveNext
	|
	|-RVA: 0x7CFD18 Offset: 0x7CFD18 VA: 0x7CFD18
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.MoveNext
	*/

	// RVA: -1 Offset: -1
	private bool MoveNextRare() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B30C Offset: 0x74B30C VA: 0x74B30C
	|-List.Enumerator<CommandArg>.MoveNextRare
	|
	|-RVA: 0x74B38C Offset: 0x74B38C VA: 0x74B38C
	|-List.Enumerator<LogItem>.MoveNextRare
	|
	|-RVA: 0x74B420 Offset: 0x74B420 VA: 0x74B420
	|-List.Enumerator<decalInfo>.MoveNextRare
	|
	|-RVA: 0x74B4B8 Offset: 0x74B4B8 VA: 0x74B4B8
	|-List.Enumerator<objectIn2Bound>.MoveNextRare
	|
	|-RVA: 0x74B544 Offset: 0x74B544 VA: 0x74B544
	|-List.Enumerator<F2NormalButton.GraphicItem>.MoveNextRare
	|
	|-RVA: 0x74B5CC Offset: 0x74B5CC VA: 0x74B5CC
	|-List.Enumerator<Entity>.MoveNextRare
	|
	|-RVA: 0x74B658 Offset: 0x74B658 VA: 0x74B658
	|-List.Enumerator<StringTuple>.MoveNextRare
	|
	|-RVA: 0x74B6DC Offset: 0x74B6DC VA: 0x74B6DC
	|-List.Enumerator<U64Id>.MoveNextRare
	|
	|-RVA: 0x74B75C Offset: 0x74B75C VA: 0x74B75C
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.MoveNextRare
	|
	|-RVA: 0x74B7E0 Offset: 0x74B7E0 VA: 0x74B7E0
	|-List.Enumerator<ChildANA>.MoveNextRare
	|
	|-RVA: 0x74B864 Offset: 0x74B864 VA: 0x74B864
	|-List.Enumerator<RagdollBone>.MoveNextRare
	|
	|-RVA: 0x74B8F4 Offset: 0x74B8F4 VA: 0x74B8F4
	|-List.Enumerator<LogData>.MoveNextRare
	|
	|-RVA: 0x74B980 Offset: 0x74B980 VA: 0x74B980
	|-List.Enumerator<ServerTimeManager.AddParam>.MoveNextRare
	|
	|-RVA: 0x74BA10 Offset: 0x74BA10 VA: 0x74BA10
	|-List.Enumerator<RendererAndSubmeshIndex>.MoveNextRare
	|
	|-RVA: 0x74BAA0 Offset: 0x74BAA0 VA: 0x74BAA0
	|-List.Enumerator<BakedData.LightBakingData>.MoveNextRare
	|
	|-RVA: 0x74BB2C Offset: 0x74BB2C VA: 0x74BB2C
	|-List.Enumerator<BakedData.Lightmap>.MoveNextRare
	|
	|-RVA: 0x74BBC0 Offset: 0x74BBC0 VA: 0x74BBC0
	|-List.Enumerator<BakedData.MeshBakingData>.MoveNextRare
	|
	|-RVA: 0x74BC54 Offset: 0x74BC54 VA: 0x74BC54
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.MoveNextRare
	|
	|-RVA: 0x74BCDC Offset: 0x74BCDC VA: 0x74BCDC
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.MoveNextRare
	|
	|-RVA: 0x74BD68 Offset: 0x74BD68 VA: 0x74BD68
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.MoveNextRare
	|
	|-RVA: 0x74BDF0 Offset: 0x74BDF0 VA: 0x74BDF0
	|-List.Enumerator<LoaderMeshInfo>.MoveNextRare
	|
	|-RVA: 0x74BE6C Offset: 0x74BE6C VA: 0x74BE6C
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.MoveNextRare
	|
	|-RVA: 0x74BEF4 Offset: 0x74BEF4 VA: 0x74BEF4
	|-List.Enumerator<ScanUtils.Result>.MoveNextRare
	|
	|-RVA: 0x74BF7C Offset: 0x74BF7C VA: 0x74BF7C
	|-List.Enumerator<Pair>.MoveNextRare
	|
	|-RVA: 0x74C004 Offset: 0x74C004 VA: 0x74C004
	|-List.Enumerator<FVector2>.MoveNextRare
	|
	|-RVA: 0x74C090 Offset: 0x74C090 VA: 0x74C090
	|-List.Enumerator<FVector3>.MoveNextRare
	|
	|-RVA: 0x74C11C Offset: 0x74C11C VA: 0x74C11C
	|-List.Enumerator<ShapeData>.MoveNextRare
	|
	|-RVA: 0x74C1AC Offset: 0x74C1AC VA: 0x74C1AC
	|-List.Enumerator<CCContact>.MoveNextRare
	|
	|-RVA: 0x74C23C Offset: 0x74C23C VA: 0x74C23C
	|-List.Enumerator<Line>.MoveNextRare
	|
	|-RVA: 0x74C2C8 Offset: 0x74C2C8 VA: 0x74C2C8
	|-List.Enumerator<GetBackResult>.MoveNextRare
	|
	|-RVA: 0x74C35C Offset: 0x74C35C VA: 0x74C35C
	|-List.Enumerator<SubMeshInstance>.MoveNextRare
	|
	|-RVA: 0x74C3E8 Offset: 0x74C3E8 VA: 0x74C3E8
	|-List.Enumerator<GeometryCollection.ObjectInfo>.MoveNextRare
	|
	|-RVA: 0x74C478 Offset: 0x74C478 VA: 0x74C478
	|-List.Enumerator<JsonPosition>.MoveNextRare
	|
	|-RVA: 0x74C504 Offset: 0x74C504 VA: 0x74C504
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.MoveNextRare
	|
	|-RVA: 0x74C594 Offset: 0x74C594 VA: 0x74C594
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.MoveNextRare
	|
	|-RVA: 0x74C620 Offset: 0x74C620 VA: 0x74C620
	|-List.Enumerator<EventQueue.EventQueueEntry>.MoveNextRare
	|
	|-RVA: 0x74C6AC Offset: 0x74C6AC VA: 0x74C6AC
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.MoveNextRare
	|
	|-RVA: 0x74C738 Offset: 0x74C738 VA: 0x74C738
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.MoveNextRare
	|
	|-RVA: 0x74C7C0 Offset: 0x74C7C0 VA: 0x74C7C0
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.MoveNextRare
	|
	|-RVA: 0x74C844 Offset: 0x74C844 VA: 0x74C844
	|-List.Enumerator<bool>.MoveNextRare
	|
	|-RVA: 0x74C8BC Offset: 0x74C8BC VA: 0x74C8BC
	|-List.Enumerator<byte>.MoveNextRare
	|
	|-RVA: 0x74C934 Offset: 0x74C934 VA: 0x74C934
	|-List.Enumerator<char>.MoveNextRare
	|
	|-RVA: 0x74C9B0 Offset: 0x74C9B0 VA: 0x74C9B0
	|-List.Enumerator<DictionaryEntry>.MoveNextRare
	|
	|-RVA: 0x74CA38 Offset: 0x74CA38 VA: 0x74CA38
	|-List.Enumerator<KeyValuePair<U64Id, object>>.MoveNextRare
	|
	|-RVA: 0x74CABC Offset: 0x74CABC VA: 0x74CABC
	|-List.Enumerator<KeyValuePair<DateTime, object>>.MoveNextRare
	|
	|-RVA: 0x74CB40 Offset: 0x74CB40 VA: 0x74CB40
	|-List.Enumerator<KeyValuePair<int, int>>.MoveNextRare
	|
	|-RVA: 0x74CBC8 Offset: 0x74CBC8 VA: 0x74CBC8
	|-List.Enumerator<KeyValuePair<int, object>>.MoveNextRare
	|
	|-RVA: 0x74CC50 Offset: 0x74CC50 VA: 0x74CC50
	|-List.Enumerator<KeyValuePair<object, object>>.MoveNextRare
	|
	|-RVA: 0x74CCD8 Offset: 0x74CCD8 VA: 0x74CCD8
	|-List.Enumerator<KeyValuePair<uint, object>>.MoveNextRare
	|
	|-RVA: 0x74CD64 Offset: 0x74CD64 VA: 0x74CD64
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.MoveNextRare
	|
	|-RVA: 0x74CDEC Offset: 0x74CDEC VA: 0x74CDEC
	|-List.Enumerator<DateTime>.MoveNextRare
	|
	|-RVA: 0x74CE6C Offset: 0x74CE6C VA: 0x74CE6C
	|-List.Enumerator<DateTimeOffset>.MoveNextRare
	|
	|-RVA: 0x74CEF4 Offset: 0x74CEF4 VA: 0x74CEF4
	|-List.Enumerator<Decimal>.MoveNextRare
	|
	|-RVA: 0x74CF74 Offset: 0x74CF74 VA: 0x74CF74
	|-List.Enumerator<double>.MoveNextRare
	|
	|-RVA: 0x74CFF0 Offset: 0x74CFF0 VA: 0x74CFF0
	|-List.Enumerator<short>.MoveNextRare
	|
	|-RVA: 0x74D068 Offset: 0x74D068 VA: 0x74D068
	|-List.Enumerator<int>.MoveNextRare
	|
	|-RVA: 0x74D0E0 Offset: 0x74D0E0 VA: 0x74D0E0
	|-List.Enumerator<Int32Enum>.MoveNextRare
	|
	|-RVA: 0x74D158 Offset: 0x74D158 VA: 0x74D158
	|-List.Enumerator<long>.MoveNextRare
	|
	|-RVA: 0x74D1D0 Offset: 0x74D1D0 VA: 0x74D1D0
	|-List.Enumerator<object>.MoveNextRare
	|
	|-RVA: 0x74D248 Offset: 0x74D248 VA: 0x74D248
	|-List.Enumerator<sbyte>.MoveNextRare
	|
	|-RVA: 0x74D2C0 Offset: 0x74D2C0 VA: 0x74D2C0
	|-List.Enumerator<float>.MoveNextRare
	|
	|-RVA: 0x74D338 Offset: 0x74D338 VA: 0x74D338
	|-List.Enumerator<TimeSpan>.MoveNextRare
	|
	|-RVA: 0x74D3B4 Offset: 0x74D3B4 VA: 0x74D3B4
	|-List.Enumerator<ushort>.MoveNextRare
	|
	|-RVA: 0x74D42C Offset: 0x74D42C VA: 0x74D42C
	|-List.Enumerator<uint>.MoveNextRare
	|
	|-RVA: 0x74D4A4 Offset: 0x74D4A4 VA: 0x74D4A4
	|-List.Enumerator<ulong>.MoveNextRare
	|
	|-RVA: 0x74D524 Offset: 0x74D524 VA: 0x74D524
	|-List.Enumerator<ValueTuple<object, Vector3>>.MoveNextRare
	|
	|-RVA: 0x74D5AC Offset: 0x74D5AC VA: 0x74D5AC
	|-List.Enumerator<ValueTuple<float, Vector3>>.MoveNextRare
	|
	|-RVA: 0x74D63C Offset: 0x74D63C VA: 0x74D63C
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.MoveNextRare
	|
	|-RVA: 0x74D6C8 Offset: 0x74D6C8 VA: 0x74D6C8
	|-List.Enumerator<RangePositionInfo>.MoveNextRare
	|
	|-RVA: 0x74D750 Offset: 0x74D750 VA: 0x74D750
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.MoveNextRare
	|
	|-RVA: 0x74D7F4 Offset: 0x74D7F4 VA: 0x74D7F4
	|-List.Enumerator<TexturePacker.SpriteData>.MoveNextRare
	|
	|-RVA: 0x74D89C Offset: 0x74D89C VA: 0x74D89C
	|-List.Enumerator<TestAudioData.AudioRecord>.MoveNextRare
	|
	|-RVA: 0x74D92C Offset: 0x74D92C VA: 0x74D92C
	|-List.Enumerator<NativeList<int>>.MoveNextRare
	|
	|-RVA: 0x74D9B4 Offset: 0x74D9B4 VA: 0x74D9B4
	|-List.Enumerator<AnimatorClipInfo>.MoveNextRare
	|
	|-RVA: 0x74DA3C Offset: 0x74DA3C VA: 0x74DA3C
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.MoveNextRare
	|
	|-RVA: 0x74DAD0 Offset: 0x74DAD0 VA: 0x74DAD0
	|-List.Enumerator<BoneWeight>.MoveNextRare
	|
	|-RVA: 0x74DB5C Offset: 0x74DB5C VA: 0x74DB5C
	|-List.Enumerator<Color32>.MoveNextRare
	|
	|-RVA: 0x74DBDC Offset: 0x74DBDC VA: 0x74DBDC
	|-List.Enumerator<Color>.MoveNextRare
	|
	|-RVA: 0x74DC64 Offset: 0x74DC64 VA: 0x74DC64
	|-List.Enumerator<CombineInstance>.MoveNextRare
	|
	|-RVA: 0x74DD0C Offset: 0x74DD0C VA: 0x74DD0C
	|-List.Enumerator<RaycastResult>.MoveNextRare
	|
	|-RVA: 0x74DDB0 Offset: 0x74DDB0 VA: 0x74DDB0
	|-List.Enumerator<IntervalTreeNode>.MoveNextRare
	|
	|-RVA: 0x74DE44 Offset: 0x74DE44 VA: 0x74DE44
	|-List.Enumerator<IntervalTree.Entry<object>>.MoveNextRare
	|
	|-RVA: 0x74DEEC Offset: 0x74DEEC VA: 0x74DEEC
	|-List.Enumerator<Matrix4x4>.MoveNextRare
	|
	|-RVA: 0x74DF88 Offset: 0x74DF88 VA: 0x74DF88
	|-List.Enumerator<Playable>.MoveNextRare
	|
	|-RVA: 0x74E024 Offset: 0x74E024 VA: 0x74E024
	|-List.Enumerator<RaycastHit>.MoveNextRare
	|
	|-RVA: 0x74E0C4 Offset: 0x74E0C4 VA: 0x74E0C4
	|-List.Enumerator<RenderTargetIdentifier>.MoveNextRare
	|
	|-RVA: 0x74E15C Offset: 0x74E15C VA: 0x74E15C
	|-List.Enumerator<GlyphRect>.MoveNextRare
	|
	|-RVA: 0x7CF794 Offset: 0x7CF794 VA: 0x7CF794
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.MoveNextRare
	|
	|-RVA: 0x7CF824 Offset: 0x7CF824 VA: 0x7CF824
	|-List.Enumerator<UICharInfo>.MoveNextRare
	|
	|-RVA: 0x7CF8B0 Offset: 0x7CF8B0 VA: 0x7CF8B0
	|-List.Enumerator<UILineInfo>.MoveNextRare
	|
	|-RVA: 0x7CF938 Offset: 0x7CF938 VA: 0x7CF938
	|-List.Enumerator<UIVertex>.MoveNextRare
	|
	|-RVA: 0x7CF9C8 Offset: 0x7CF9C8 VA: 0x7CF9C8
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.MoveNextRare
	|
	|-RVA: 0x7CFA50 Offset: 0x7CFA50 VA: 0x7CFA50
	|-List.Enumerator<Vector2>.MoveNextRare
	|
	|-RVA: 0x7CFADC Offset: 0x7CFADC VA: 0x7CFADC
	|-List.Enumerator<Vector3>.MoveNextRare
	|
	|-RVA: 0x7CFB68 Offset: 0x7CFB68 VA: 0x7CFB68
	|-List.Enumerator<Vector4>.MoveNextRare
	|
	|-RVA: 0x7CFBF8 Offset: 0x7CFBF8 VA: 0x7CFBF8
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.MoveNextRare
	|
	|-RVA: 0x7CFC94 Offset: 0x7CFC94 VA: 0x7CFC94
	|-List.Enumerator<LODGenerator.StaticRenderer>.MoveNextRare
	|
	|-RVA: 0x7CFD20 Offset: 0x7CFD20 VA: 0x7CFD20
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.MoveNextRare
	*/

	// RVA: -1 Offset: -1 Slot: 4
	public T get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B3A4 Offset: 0x74B3A4 VA: 0x74B3A4
	|-List.Enumerator<LogItem>.get_Current
	|
	|-RVA: 0x74D1E8 Offset: 0x74D1E8 VA: 0x74D1E8
	|-List.Enumerator<CustomizableComp>.get_Current
	|-List.Enumerator<DynamicGoalTooltip>.get_Current
	|-List.Enumerator<IllegalWordsSearch.NodeInfo>.get_Current
	|-List.Enumerator<IllegalWordsSearchEx.TreeNode>.get_Current
	|-List.Enumerator<IllegalWordsSearchResult>.get_Current
	|-List.Enumerator<AssetRecord>.get_Current
	|-List.Enumerator<UnityCallBackRegister.UpdateItem>.get_Current
	|-List.Enumerator<AssetItem>.get_Current
	|-List.Enumerator<Transition>.get_Current
	|-List.Enumerator<MainCharacterController.TrapBombSkill.GetBackData>.get_Current
	|-List.Enumerator<IStateTranslate>.get_Current
	|-List.Enumerator<LocalToolBaseCtrlr.State>.get_Current
	|-List.Enumerator<TransitionWorker>.get_Current
	|-List.Enumerator<ICharacterProxy>.get_Current
	|-List.Enumerator<IDynamicGoalProxy>.get_Current
	|-List.Enumerator<ISurveillanceCamProxy>.get_Current
	|-List.Enumerator<IUniversalSceneTool>.get_Current
	|-List.Enumerator<ScoutCar>.get_Current
	|-List.Enumerator<IGizmosDrawable>.get_Current
	|-List.Enumerator<IEffect>.get_Current
	|-List.Enumerator<IEffectBehaviour>.get_Current
	|-List.Enumerator<ILightweightTrigger>.get_Current
	|-List.Enumerator<ITriggerSponsor>.get_Current
	|-List.Enumerator<TrapBombTrigger.PlaceData>.get_Current
	|-List.Enumerator<TrapBombTrigger>.get_Current
	|-List.Enumerator<DcelEdge>.get_Current
	|-List.Enumerator<DcelFace>.get_Current
	|-List.Enumerator<DcelTree>.get_Current
	|-List.Enumerator<Element<FixtureProxy>>.get_Current
	|-List.Enumerator<CurveKey>.get_Current
	|-List.Enumerator<DelaunayTriangle>.get_Current
	|-List.Enumerator<DTSweepConstraint>.get_Current
	|-List.Enumerator<Polygon>.get_Current
	|-List.Enumerator<TriangulationPoint>.get_Current
	|-List.Enumerator<Edge>.get_Current
	|-List.Enumerator<Node>.get_Current
	|-List.Enumerator<Point>.get_Current
	|-List.Enumerator<Trapezoid>.get_Current
	|-List.Enumerator<DetectedVertices>.get_Current
	|-List.Enumerator<MarchingSquares.GeomPoly>.get_Current
	|-List.Enumerator<Vertices>.get_Current
	|-List.Enumerator<Body>.get_Current
	|-List.Enumerator<Fixture>.get_Current
	|-List.Enumerator<FarseerJoint>.get_Current
	|-List.Enumerator<BaseTriggerGroup>.get_Current
	|-List.Enumerator<PanelArea>.get_Current
	|-List.Enumerator<BoundaryEdgeList>.get_Current
	|-List.Enumerator<JumpTrigger>.get_Current
	|-List.Enumerator<ReinforceTrigger>.get_Current
	|-List.Enumerator<RopeClimbingTrigger>.get_Current
	|-List.Enumerator<LockOutlineBtn>.get_Current
	|-List.Enumerator<BaseView>.get_Current
	|-List.Enumerator<LocWeaponInfo>.get_Current
	|-List.Enumerator<PreBattleEquipmentSettingView.PartUI>.get_Current
	|-List.Enumerator<PreBattleEquipmentSettingView.WeaponUI>.get_Current
	|-List.Enumerator<PreBattleSpawnRegionSelectView.PlayerUI>.get_Current
	|-List.Enumerator<PreBattleSpawnRegionSelectView.RegionUI>.get_Current
	|-List.Enumerator<SpawnRegionViewData.PlayerData>.get_Current
	|-List.Enumerator<SpawnRegionViewData.RegionData>.get_Current
	|-List.Enumerator<PermanentTextEntity>.get_Current
	|-List.Enumerator<OpTabButton>.get_Current
	|-List.Enumerator<ScrollTextEntity>.get_Current
	|-List.Enumerator<ITextEntity>.get_Current
	|-List.Enumerator<IMapPointView>.get_Current
	|-List.Enumerator<ScoreTextEntity>.get_Current
	|-List.Enumerator<UIBattleScreenTooltipsControl.IScreenTooltip>.get_Current
	|-List.Enumerator<UIBattleWarnEnemyTooltipsControl.WarnEnemyTooltip>.get_Current
	|-List.Enumerator<ITriStateBtnDisplay>.get_Current
	|-List.Enumerator<MVPCharacterData>.get_Current
	|-List.Enumerator<JsonSerializerInternalReader.CreatorPropertyContext>.get_Current
	|-List.Enumerator<SerializationCallback>.get_Current
	|-List.Enumerator<SelectOccPage2.PlayerOccCtrlr>.get_Current
	|-List.Enumerator<SoundBox>.get_Current
	|-List.Enumerator<Attachment>.get_Current
	|-List.Enumerator<BoneData>.get_Current
	|-List.Enumerator<SkeletonPartsRenderer>.get_Current
	|-List.Enumerator<client.Stat>.get_Current
	|-List.Enumerator<game.CharacterChoosePlayer>.get_Current
	|-List.Enumerator<Action<string, string>>.get_Current
	|-List.Enumerator<byte[]>.get_Current
	|-List.Enumerator<List<Point>>.get_Current
	|-List.Enumerator<List<int>>.get_Current
	|-List.Enumerator<int[]>.get_Current
	|-List.Enumerator<IPAddress>.get_Current
	|-List.Enumerator<MonoChunkStream.Chunk>.get_Current
	|-List.Enumerator<WebConnection>.get_Current
	|-List.Enumerator<WebConnectionGroup>.get_Current
	|-List.Enumerator<Assembly>.get_Current
	|-List.Enumerator<MemberInfo>.get_Current
	|-List.Enumerator<X509CertificateImpl>.get_Current
	|-List.Enumerator<string>.get_Current
	|-List.Enumerator<Thread>.get_Current
	|-List.Enumerator<Type>.get_Current
	|-List.Enumerator<XmlReflectionMember>.get_Current
	|-List.Enumerator<XmlQualifiedName>.get_Current
	|-List.Enumerator<ThermalImagerManager.ProjectorRenderAndMat>.get_Current
	|-List.Enumerator<UIBattleCharactersTooltipControl.CharacterTooltip>.get_Current
	|-List.Enumerator<UIBattleFPEffectsControl.DamageArrow>.get_Current
	|-List.Enumerator<UIBattleMiniCarControl.CicleFlag>.get_Current
	|-List.Enumerator<UIBattleMiniCarTooltipControl.MiniCarTooltip>.get_Current
	|-List.Enumerator<UIBattleResultUI.WinerCharacterTooltip>.get_Current
	|-List.Enumerator<UIBattleScanCharacterTooltipCtrl.ICharacterTooltip>.get_Current
	|-List.Enumerator<UIBattleSkullTooltipControl.SkullTooltip>.get_Current
	|-List.Enumerator<UIBattleSurveillanceCamControl.CicleFlag>.get_Current
	|-List.Enumerator<AudioAmbisonicExtensionDefinition>.get_Current
	|-List.Enumerator<AudioSpatializerExtensionDefinition>.get_Current
	|-List.Enumerator<Collider>.get_Current
	|-List.Enumerator<PersistentCall>.get_Current
	|-List.Enumerator<ISubsystem>.get_Current
	|-List.Enumerator<ISubsystemDescriptor>.get_Current
	|-List.Enumerator<ISubsystemDescriptorImpl>.get_Current
	|-List.Enumerator<IRenderPipeline>.get_Current
	|-List.Enumerator<GUILayoutEntry>.get_Current
	|-List.Enumerator<GameObject>.get_Current
	|-List.Enumerator<RectTransform>.get_Current
	|-List.Enumerator<RenderTexture>.get_Current
	|-List.Enumerator<Renderer>.get_Current
	|-List.Enumerator<PostProcessBundle>.get_Current
	|-List.Enumerator<PostProcessEffectSettings>.get_Current
	|-List.Enumerator<PostProcessLayer.SerializedBundleRef>.get_Current
	|-List.Enumerator<PostProcessVolume>.get_Current
	|-List.Enumerator<Texture2D>.get_Current
	|-List.Enumerator<TimelineClip>.get_Current
	|-List.Enumerator<Transform>.get_Current
	|-List.Enumerator<Selectable>.get_Current
	|-List.Enumerator<LuaEnv.CustomLoader>.get_Current
	|-List.Enumerator<Chunk>.get_Current
	|-List.Enumerator<ParsingEvent>.get_Current
	|-List.Enumerator<IObjectGraphVisitor<Nothing>>.get_Current
	|-List.Enumerator<YamlAttributeOverrides.AttributeMapping>.get_Current
	|-List.Enumerator<ModifierSpec>.get_Current
	|-List.Enumerator<object>.get_Current
	|-List.Enumerator<MethodInfo>.get_Current
	|-List.Enumerator<ExceptionDispatchInfo>.get_Current
	|-List.Enumerator<IContextProperty>.get_Current
	|-List.Enumerator<IAsyncLocal>.get_Current
	|-List.Enumerator<Task>.get_Current
	|-List.Enumerator<TypeIdentifier>.get_Current
	|
	|-RVA: 0x74B438 Offset: 0x74B438 VA: 0x74B438
	|-List.Enumerator<decalInfo>.get_Current
	|
	|-RVA: 0x74B670 Offset: 0x74B670 VA: 0x74B670
	|-List.Enumerator<StringTuple>.get_Current
	|
	|-RVA: 0x74B6F4 Offset: 0x74B6F4 VA: 0x74B6F4
	|-List.Enumerator<U64Id>.get_Current
	|
	|-RVA: 0x74B774 Offset: 0x74B774 VA: 0x74B774
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.get_Current
	|
	|-RVA: 0x74B87C Offset: 0x74B87C VA: 0x74B87C
	|-List.Enumerator<RagdollBone>.get_Current
	|
	|-RVA: 0x74BA28 Offset: 0x74BA28 VA: 0x74BA28
	|-List.Enumerator<RendererAndSubmeshIndex>.get_Current
	|
	|-RVA: 0x74BE08 Offset: 0x74BE08 VA: 0x74BE08
	|-List.Enumerator<LoaderMeshInfo>.get_Current
	|
	|-RVA: 0x74BF0C Offset: 0x74BF0C VA: 0x74BF0C
	|-List.Enumerator<ScanUtils.Result>.get_Current
	|
	|-RVA: 0x74C01C Offset: 0x74C01C VA: 0x74C01C
	|-List.Enumerator<FVector2>.get_Current
	|
	|-RVA: 0x74C1C4 Offset: 0x74C1C4 VA: 0x74C1C4
	|-List.Enumerator<CCContact>.get_Current
	|
	|-RVA: 0x74C400 Offset: 0x74C400 VA: 0x74C400
	|-List.Enumerator<GeometryCollection.ObjectInfo>.get_Current
	|
	|-RVA: 0x74C490 Offset: 0x74C490 VA: 0x74C490
	|-List.Enumerator<JsonPosition>.get_Current
	|
	|-RVA: 0x74C5AC Offset: 0x74C5AC VA: 0x74C5AC
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.get_Current
	|
	|-RVA: 0x74CB58 Offset: 0x74CB58 VA: 0x74CB58
	|-List.Enumerator<KeyValuePair<int, int>>.get_Current
	|
	|-RVA: 0x74CCF0 Offset: 0x74CCF0 VA: 0x74CCF0
	|-List.Enumerator<KeyValuePair<uint, Pillar>>.get_Current
	|-List.Enumerator<KeyValuePair<uint, object>>.get_Current
	|
	|-RVA: 0x74CD7C Offset: 0x74CD7C VA: 0x74CD7C
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, GeometryData>>>.get_Current
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.get_Current
	|
	|-RVA: 0x74CF8C Offset: 0x74CF8C VA: 0x74CF8C
	|-List.Enumerator<double>.get_Current
	|
	|-RVA: 0x74D080 Offset: 0x74D080 VA: 0x74D080
	|-List.Enumerator<int>.get_Current
	|
	|-RVA: 0x74D170 Offset: 0x74D170 VA: 0x74D170
	|-List.Enumerator<long>.get_Current
	|
	|-RVA: 0x74D444 Offset: 0x74D444 VA: 0x74D444
	|-List.Enumerator<uint>.get_Current
	|
	|-RVA: 0x74D53C Offset: 0x74D53C VA: 0x74D53C
	|-List.Enumerator<ValueTuple<SkinnedMeshRenderer, Vector3>>.get_Current
	|-List.Enumerator<ValueTuple<object, Vector3>>.get_Current
	|
	|-RVA: 0x74D944 Offset: 0x74D944 VA: 0x74D944
	|-List.Enumerator<NativeList<int>>.get_Current
	|
	|-RVA: 0x74E03C Offset: 0x74E03C VA: 0x74E03C
	|-List.Enumerator<RaycastHit>.get_Current
	|
	|-RVA: 0x7CF9E0 Offset: 0x7CF9E0 VA: 0x7CF9E0
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.get_Current
	|
	|-RVA: 0x7CFAF4 Offset: 0x7CFAF4 VA: 0x7CFAF4
	|-List.Enumerator<Vector3>.get_Current
	|
	|-RVA: 0x7CFB80 Offset: 0x7CFB80 VA: 0x7CFB80
	|-List.Enumerator<Vector4>.get_Current
	|
	|-RVA: 0x74B324 Offset: 0x74B324 VA: 0x74B324
	|-List.Enumerator<CommandArg>.get_Current
	|
	|-RVA: 0x74B4D0 Offset: 0x74B4D0 VA: 0x74B4D0
	|-List.Enumerator<objectIn2Bound>.get_Current
	|
	|-RVA: 0x74B55C Offset: 0x74B55C VA: 0x74B55C
	|-List.Enumerator<F2NormalButton.GraphicItem>.get_Current
	|
	|-RVA: 0x74B5E4 Offset: 0x74B5E4 VA: 0x74B5E4
	|-List.Enumerator<Entity>.get_Current
	|
	|-RVA: 0x74B7F8 Offset: 0x74B7F8 VA: 0x74B7F8
	|-List.Enumerator<ChildANA>.get_Current
	|
	|-RVA: 0x74B90C Offset: 0x74B90C VA: 0x74B90C
	|-List.Enumerator<LogData>.get_Current
	|
	|-RVA: 0x74B998 Offset: 0x74B998 VA: 0x74B998
	|-List.Enumerator<ServerTimeManager.AddParam>.get_Current
	|
	|-RVA: 0x74BAB8 Offset: 0x74BAB8 VA: 0x74BAB8
	|-List.Enumerator<BakedData.LightBakingData>.get_Current
	|
	|-RVA: 0x74BB44 Offset: 0x74BB44 VA: 0x74BB44
	|-List.Enumerator<BakedData.Lightmap>.get_Current
	|
	|-RVA: 0x74BBD8 Offset: 0x74BBD8 VA: 0x74BBD8
	|-List.Enumerator<BakedData.MeshBakingData>.get_Current
	|
	|-RVA: 0x74BC6C Offset: 0x74BC6C VA: 0x74BC6C
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.get_Current
	|
	|-RVA: 0x74BCF4 Offset: 0x74BCF4 VA: 0x74BCF4
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.get_Current
	|
	|-RVA: 0x74BD80 Offset: 0x74BD80 VA: 0x74BD80
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.get_Current
	|
	|-RVA: 0x74BE84 Offset: 0x74BE84 VA: 0x74BE84
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.get_Current
	|
	|-RVA: 0x74BF94 Offset: 0x74BF94 VA: 0x74BF94
	|-List.Enumerator<Pair>.get_Current
	|
	|-RVA: 0x74C0A8 Offset: 0x74C0A8 VA: 0x74C0A8
	|-List.Enumerator<FVector3>.get_Current
	|
	|-RVA: 0x74C134 Offset: 0x74C134 VA: 0x74C134
	|-List.Enumerator<ShapeData>.get_Current
	|
	|-RVA: 0x74C254 Offset: 0x74C254 VA: 0x74C254
	|-List.Enumerator<Line>.get_Current
	|
	|-RVA: 0x74C2E0 Offset: 0x74C2E0 VA: 0x74C2E0
	|-List.Enumerator<GetBackResult>.get_Current
	|
	|-RVA: 0x74C374 Offset: 0x74C374 VA: 0x74C374
	|-List.Enumerator<SubMeshInstance>.get_Current
	|
	|-RVA: 0x74C51C Offset: 0x74C51C VA: 0x74C51C
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.get_Current
	|
	|-RVA: 0x74C638 Offset: 0x74C638 VA: 0x74C638
	|-List.Enumerator<EventQueue.EventQueueEntry>.get_Current
	|
	|-RVA: 0x74C6C4 Offset: 0x74C6C4 VA: 0x74C6C4
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.get_Current
	|
	|-RVA: 0x74C750 Offset: 0x74C750 VA: 0x74C750
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.get_Current
	|
	|-RVA: 0x74C7D8 Offset: 0x74C7D8 VA: 0x74C7D8
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.get_Current
	|
	|-RVA: 0x74C85C Offset: 0x74C85C VA: 0x74C85C
	|-List.Enumerator<bool>.get_Current
	|
	|-RVA: 0x74C8D4 Offset: 0x74C8D4 VA: 0x74C8D4
	|-List.Enumerator<byte>.get_Current
	|
	|-RVA: 0x74C94C Offset: 0x74C94C VA: 0x74C94C
	|-List.Enumerator<char>.get_Current
	|
	|-RVA: 0x74C9C8 Offset: 0x74C9C8 VA: 0x74C9C8
	|-List.Enumerator<DictionaryEntry>.get_Current
	|
	|-RVA: 0x74CA50 Offset: 0x74CA50 VA: 0x74CA50
	|-List.Enumerator<KeyValuePair<U64Id, object>>.get_Current
	|
	|-RVA: 0x74CAD4 Offset: 0x74CAD4 VA: 0x74CAD4
	|-List.Enumerator<KeyValuePair<DateTime, object>>.get_Current
	|
	|-RVA: 0x74CBE0 Offset: 0x74CBE0 VA: 0x74CBE0
	|-List.Enumerator<KeyValuePair<int, object>>.get_Current
	|
	|-RVA: 0x74CC68 Offset: 0x74CC68 VA: 0x74CC68
	|-List.Enumerator<KeyValuePair<object, object>>.get_Current
	|
	|-RVA: 0x74CE04 Offset: 0x74CE04 VA: 0x74CE04
	|-List.Enumerator<DateTime>.get_Current
	|
	|-RVA: 0x74CE84 Offset: 0x74CE84 VA: 0x74CE84
	|-List.Enumerator<DateTimeOffset>.get_Current
	|
	|-RVA: 0x74CF0C Offset: 0x74CF0C VA: 0x74CF0C
	|-List.Enumerator<Decimal>.get_Current
	|
	|-RVA: 0x74D008 Offset: 0x74D008 VA: 0x74D008
	|-List.Enumerator<short>.get_Current
	|
	|-RVA: 0x74D0F8 Offset: 0x74D0F8 VA: 0x74D0F8
	|-List.Enumerator<Int32Enum>.get_Current
	|
	|-RVA: 0x74D260 Offset: 0x74D260 VA: 0x74D260
	|-List.Enumerator<sbyte>.get_Current
	|
	|-RVA: 0x74D2D8 Offset: 0x74D2D8 VA: 0x74D2D8
	|-List.Enumerator<float>.get_Current
	|
	|-RVA: 0x74D350 Offset: 0x74D350 VA: 0x74D350
	|-List.Enumerator<TimeSpan>.get_Current
	|
	|-RVA: 0x74D3CC Offset: 0x74D3CC VA: 0x74D3CC
	|-List.Enumerator<ushort>.get_Current
	|
	|-RVA: 0x74D4BC Offset: 0x74D4BC VA: 0x74D4BC
	|-List.Enumerator<ulong>.get_Current
	|
	|-RVA: 0x74D5C4 Offset: 0x74D5C4 VA: 0x74D5C4
	|-List.Enumerator<ValueTuple<float, Vector3>>.get_Current
	|
	|-RVA: 0x74D654 Offset: 0x74D654 VA: 0x74D654
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.get_Current
	|
	|-RVA: 0x74D6E0 Offset: 0x74D6E0 VA: 0x74D6E0
	|-List.Enumerator<RangePositionInfo>.get_Current
	|
	|-RVA: 0x74D768 Offset: 0x74D768 VA: 0x74D768
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.get_Current
	|
	|-RVA: 0x74D80C Offset: 0x74D80C VA: 0x74D80C
	|-List.Enumerator<TexturePacker.SpriteData>.get_Current
	|
	|-RVA: 0x74D8B4 Offset: 0x74D8B4 VA: 0x74D8B4
	|-List.Enumerator<TestAudioData.AudioRecord>.get_Current
	|
	|-RVA: 0x74D9CC Offset: 0x74D9CC VA: 0x74D9CC
	|-List.Enumerator<AnimatorClipInfo>.get_Current
	|
	|-RVA: 0x74DA54 Offset: 0x74DA54 VA: 0x74DA54
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.get_Current
	|
	|-RVA: 0x74DAE8 Offset: 0x74DAE8 VA: 0x74DAE8
	|-List.Enumerator<BoneWeight>.get_Current
	|
	|-RVA: 0x74DB74 Offset: 0x74DB74 VA: 0x74DB74
	|-List.Enumerator<Color32>.get_Current
	|
	|-RVA: 0x74DBF4 Offset: 0x74DBF4 VA: 0x74DBF4
	|-List.Enumerator<Color>.get_Current
	|
	|-RVA: 0x74DC7C Offset: 0x74DC7C VA: 0x74DC7C
	|-List.Enumerator<CombineInstance>.get_Current
	|
	|-RVA: 0x74DD24 Offset: 0x74DD24 VA: 0x74DD24
	|-List.Enumerator<RaycastResult>.get_Current
	|
	|-RVA: 0x74DDC8 Offset: 0x74DDC8 VA: 0x74DDC8
	|-List.Enumerator<IntervalTreeNode>.get_Current
	|
	|-RVA: 0x74DE5C Offset: 0x74DE5C VA: 0x74DE5C
	|-List.Enumerator<IntervalTree.Entry<object>>.get_Current
	|
	|-RVA: 0x74DF04 Offset: 0x74DF04 VA: 0x74DF04
	|-List.Enumerator<Matrix4x4>.get_Current
	|
	|-RVA: 0x74DFA0 Offset: 0x74DFA0 VA: 0x74DFA0
	|-List.Enumerator<Playable>.get_Current
	|
	|-RVA: 0x74E0DC Offset: 0x74E0DC VA: 0x74E0DC
	|-List.Enumerator<RenderTargetIdentifier>.get_Current
	|
	|-RVA: 0x74E174 Offset: 0x74E174 VA: 0x74E174
	|-List.Enumerator<GlyphRect>.get_Current
	|
	|-RVA: 0x7CF7AC Offset: 0x7CF7AC VA: 0x7CF7AC
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.get_Current
	|
	|-RVA: 0x7CF83C Offset: 0x7CF83C VA: 0x7CF83C
	|-List.Enumerator<UICharInfo>.get_Current
	|
	|-RVA: 0x7CF8C8 Offset: 0x7CF8C8 VA: 0x7CF8C8
	|-List.Enumerator<UILineInfo>.get_Current
	|
	|-RVA: 0x7CF950 Offset: 0x7CF950 VA: 0x7CF950
	|-List.Enumerator<UIVertex>.get_Current
	|
	|-RVA: 0x7CFA68 Offset: 0x7CFA68 VA: 0x7CFA68
	|-List.Enumerator<Vector2>.get_Current
	|
	|-RVA: 0x7CFC10 Offset: 0x7CFC10 VA: 0x7CFC10
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.get_Current
	|
	|-RVA: 0x7CFCAC Offset: 0x7CFCAC VA: 0x7CFCAC
	|-List.Enumerator<LODGenerator.StaticRenderer>.get_Current
	|
	|-RVA: 0x7CFD38 Offset: 0x7CFD38 VA: 0x7CFD38
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 7
	private object System.Collections.IEnumerator.get_Current() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B32C Offset: 0x74B32C VA: 0x74B32C
	|-List.Enumerator<CommandArg>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B3B8 Offset: 0x74B3B8 VA: 0x74B3B8
	|-List.Enumerator<LogItem>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B454 Offset: 0x74B454 VA: 0x74B454
	|-List.Enumerator<decalInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B4E8 Offset: 0x74B4E8 VA: 0x74B4E8
	|-List.Enumerator<objectIn2Bound>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B570 Offset: 0x74B570 VA: 0x74B570
	|-List.Enumerator<F2NormalButton.GraphicItem>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B5F8 Offset: 0x74B5F8 VA: 0x74B5F8
	|-List.Enumerator<Entity>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B684 Offset: 0x74B684 VA: 0x74B684
	|-List.Enumerator<StringTuple>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B700 Offset: 0x74B700 VA: 0x74B700
	|-List.Enumerator<U64Id>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B788 Offset: 0x74B788 VA: 0x74B788
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B800 Offset: 0x74B800 VA: 0x74B800
	|-List.Enumerator<ChildANA>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B894 Offset: 0x74B894 VA: 0x74B894
	|-List.Enumerator<RagdollBone>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B91C Offset: 0x74B91C VA: 0x74B91C
	|-List.Enumerator<LogData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74B9B4 Offset: 0x74B9B4 VA: 0x74B9B4
	|-List.Enumerator<ServerTimeManager.AddParam>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BA3C Offset: 0x74BA3C VA: 0x74BA3C
	|-List.Enumerator<RendererAndSubmeshIndex>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BAD0 Offset: 0x74BAD0 VA: 0x74BAD0
	|-List.Enumerator<BakedData.LightBakingData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BB58 Offset: 0x74BB58 VA: 0x74BB58
	|-List.Enumerator<BakedData.Lightmap>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BBF8 Offset: 0x74BBF8 VA: 0x74BBF8
	|-List.Enumerator<BakedData.MeshBakingData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BC80 Offset: 0x74BC80 VA: 0x74BC80
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BD08 Offset: 0x74BD08 VA: 0x74BD08
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BD98 Offset: 0x74BD98 VA: 0x74BD98
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BE10 Offset: 0x74BE10 VA: 0x74BE10
	|-List.Enumerator<LoaderMeshInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BE98 Offset: 0x74BE98 VA: 0x74BE98
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BF20 Offset: 0x74BF20 VA: 0x74BF20
	|-List.Enumerator<ScanUtils.Result>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74BFA8 Offset: 0x74BFA8 VA: 0x74BFA8
	|-List.Enumerator<Pair>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C030 Offset: 0x74C030 VA: 0x74C030
	|-List.Enumerator<FVector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C0BC Offset: 0x74C0BC VA: 0x74C0BC
	|-List.Enumerator<FVector3>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C148 Offset: 0x74C148 VA: 0x74C148
	|-List.Enumerator<ShapeData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C1DC Offset: 0x74C1DC VA: 0x74C1DC
	|-List.Enumerator<CCContact>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C264 Offset: 0x74C264 VA: 0x74C264
	|-List.Enumerator<Line>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C2FC Offset: 0x74C2FC VA: 0x74C2FC
	|-List.Enumerator<GetBackResult>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C384 Offset: 0x74C384 VA: 0x74C384
	|-List.Enumerator<SubMeshInstance>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C418 Offset: 0x74C418 VA: 0x74C418
	|-List.Enumerator<GeometryCollection.ObjectInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C4A0 Offset: 0x74C4A0 VA: 0x74C4A0
	|-List.Enumerator<JsonPosition>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C534 Offset: 0x74C534 VA: 0x74C534
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C5C0 Offset: 0x74C5C0 VA: 0x74C5C0
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C64C Offset: 0x74C64C VA: 0x74C64C
	|-List.Enumerator<EventQueue.EventQueueEntry>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C6D8 Offset: 0x74C6D8 VA: 0x74C6D8
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C764 Offset: 0x74C764 VA: 0x74C764
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C7EC Offset: 0x74C7EC VA: 0x74C7EC
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C864 Offset: 0x74C864 VA: 0x74C864
	|-List.Enumerator<bool>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C8DC Offset: 0x74C8DC VA: 0x74C8DC
	|-List.Enumerator<byte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C954 Offset: 0x74C954 VA: 0x74C954
	|-List.Enumerator<char>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74C9DC Offset: 0x74C9DC VA: 0x74C9DC
	|-List.Enumerator<DictionaryEntry>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CA60 Offset: 0x74CA60 VA: 0x74CA60
	|-List.Enumerator<KeyValuePair<U64Id, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CAE4 Offset: 0x74CAE4 VA: 0x74CAE4
	|-List.Enumerator<KeyValuePair<DateTime, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CB6C Offset: 0x74CB6C VA: 0x74CB6C
	|-List.Enumerator<KeyValuePair<int, int>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CBF4 Offset: 0x74CBF4 VA: 0x74CBF4
	|-List.Enumerator<KeyValuePair<int, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CC7C Offset: 0x74CC7C VA: 0x74CC7C
	|-List.Enumerator<KeyValuePair<object, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CD04 Offset: 0x74CD04 VA: 0x74CD04
	|-List.Enumerator<KeyValuePair<uint, object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CD94 Offset: 0x74CD94 VA: 0x74CD94
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CE10 Offset: 0x74CE10 VA: 0x74CE10
	|-List.Enumerator<DateTime>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CE94 Offset: 0x74CE94 VA: 0x74CE94
	|-List.Enumerator<DateTimeOffset>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CF1C Offset: 0x74CF1C VA: 0x74CF1C
	|-List.Enumerator<Decimal>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74CF98 Offset: 0x74CF98 VA: 0x74CF98
	|-List.Enumerator<double>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D010 Offset: 0x74D010 VA: 0x74D010
	|-List.Enumerator<short>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D088 Offset: 0x74D088 VA: 0x74D088
	|-List.Enumerator<int>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D100 Offset: 0x74D100 VA: 0x74D100
	|-List.Enumerator<Int32Enum>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D178 Offset: 0x74D178 VA: 0x74D178
	|-List.Enumerator<long>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D1F0 Offset: 0x74D1F0 VA: 0x74D1F0
	|-List.Enumerator<object>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D268 Offset: 0x74D268 VA: 0x74D268
	|-List.Enumerator<sbyte>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D2E0 Offset: 0x74D2E0 VA: 0x74D2E0
	|-List.Enumerator<float>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D35C Offset: 0x74D35C VA: 0x74D35C
	|-List.Enumerator<TimeSpan>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D3D4 Offset: 0x74D3D4 VA: 0x74D3D4
	|-List.Enumerator<ushort>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D44C Offset: 0x74D44C VA: 0x74D44C
	|-List.Enumerator<uint>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D4C4 Offset: 0x74D4C4 VA: 0x74D4C4
	|-List.Enumerator<ulong>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D54C Offset: 0x74D54C VA: 0x74D54C
	|-List.Enumerator<ValueTuple<object, Vector3>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D5D4 Offset: 0x74D5D4 VA: 0x74D5D4
	|-List.Enumerator<ValueTuple<float, Vector3>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D66C Offset: 0x74D66C VA: 0x74D66C
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D6F4 Offset: 0x74D6F4 VA: 0x74D6F4
	|-List.Enumerator<RangePositionInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D77C Offset: 0x74D77C VA: 0x74D77C
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D834 Offset: 0x74D834 VA: 0x74D834
	|-List.Enumerator<TexturePacker.SpriteData>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D8D0 Offset: 0x74D8D0 VA: 0x74D8D0
	|-List.Enumerator<TestAudioData.AudioRecord>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D958 Offset: 0x74D958 VA: 0x74D958
	|-List.Enumerator<NativeList<int>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74D9E0 Offset: 0x74D9E0 VA: 0x74D9E0
	|-List.Enumerator<AnimatorClipInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DA68 Offset: 0x74DA68 VA: 0x74DA68
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DB04 Offset: 0x74DB04 VA: 0x74DB04
	|-List.Enumerator<BoneWeight>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DB7C Offset: 0x74DB7C VA: 0x74DB7C
	|-List.Enumerator<Color32>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DC04 Offset: 0x74DC04 VA: 0x74DC04
	|-List.Enumerator<Color>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DC94 Offset: 0x74DC94 VA: 0x74DC94
	|-List.Enumerator<CombineInstance>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DD4C Offset: 0x74DD4C VA: 0x74DD4C
	|-List.Enumerator<RaycastResult>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DDE0 Offset: 0x74DDE0 VA: 0x74DDE0
	|-List.Enumerator<IntervalTreeNode>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DE74 Offset: 0x74DE74 VA: 0x74DE74
	|-List.Enumerator<IntervalTree.Entry<object>>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DF2C Offset: 0x74DF2C VA: 0x74DF2C
	|-List.Enumerator<Matrix4x4>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74DFB4 Offset: 0x74DFB4 VA: 0x74DFB4
	|-List.Enumerator<Playable>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74E05C Offset: 0x74E05C VA: 0x74E05C
	|-List.Enumerator<RaycastHit>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74E0FC Offset: 0x74E0FC VA: 0x74E0FC
	|-List.Enumerator<RenderTargetIdentifier>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x74E184 Offset: 0x74E184 VA: 0x74E184
	|-List.Enumerator<GlyphRect>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CF7C4 Offset: 0x7CF7C4 VA: 0x7CF7C4
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CF850 Offset: 0x7CF850 VA: 0x7CF850
	|-List.Enumerator<UICharInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CF8D8 Offset: 0x7CF8D8 VA: 0x7CF8D8
	|-List.Enumerator<UILineInfo>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CF968 Offset: 0x7CF968 VA: 0x7CF968
	|-List.Enumerator<UIVertex>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CF9F4 Offset: 0x7CF9F4 VA: 0x7CF9F4
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFA7C Offset: 0x7CFA7C VA: 0x7CFA7C
	|-List.Enumerator<Vector2>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFB08 Offset: 0x7CFB08 VA: 0x7CFB08
	|-List.Enumerator<Vector3>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFB90 Offset: 0x7CFB90 VA: 0x7CFB90
	|-List.Enumerator<Vector4>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFC30 Offset: 0x7CFC30 VA: 0x7CFC30
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFCC4 Offset: 0x7CFCC4 VA: 0x7CFCC4
	|-List.Enumerator<LODGenerator.StaticRenderer>.System.Collections.IEnumerator.get_Current
	|
	|-RVA: 0x7CFD4C Offset: 0x7CFD4C VA: 0x7CFD4C
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.System.Collections.IEnumerator.get_Current
	*/

	// RVA: -1 Offset: -1 Slot: 8
	private void System.Collections.IEnumerator.Reset() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x74B334 Offset: 0x74B334 VA: 0x74B334
	|-List.Enumerator<CommandArg>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B3C0 Offset: 0x74B3C0 VA: 0x74B3C0
	|-List.Enumerator<LogItem>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B45C Offset: 0x74B45C VA: 0x74B45C
	|-List.Enumerator<decalInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B4F0 Offset: 0x74B4F0 VA: 0x74B4F0
	|-List.Enumerator<objectIn2Bound>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B578 Offset: 0x74B578 VA: 0x74B578
	|-List.Enumerator<F2NormalButton.GraphicItem>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B600 Offset: 0x74B600 VA: 0x74B600
	|-List.Enumerator<Entity>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B68C Offset: 0x74B68C VA: 0x74B68C
	|-List.Enumerator<StringTuple>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B708 Offset: 0x74B708 VA: 0x74B708
	|-List.Enumerator<U64Id>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B790 Offset: 0x74B790 VA: 0x74B790
	|-List.Enumerator<WordsSearch.WordsSearchTuple>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B808 Offset: 0x74B808 VA: 0x74B808
	|-List.Enumerator<ChildANA>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B89C Offset: 0x74B89C VA: 0x74B89C
	|-List.Enumerator<RagdollBone>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B924 Offset: 0x74B924 VA: 0x74B924
	|-List.Enumerator<LogData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74B9BC Offset: 0x74B9BC VA: 0x74B9BC
	|-List.Enumerator<ServerTimeManager.AddParam>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BA44 Offset: 0x74BA44 VA: 0x74BA44
	|-List.Enumerator<RendererAndSubmeshIndex>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BAD8 Offset: 0x74BAD8 VA: 0x74BAD8
	|-List.Enumerator<BakedData.LightBakingData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BB60 Offset: 0x74BB60 VA: 0x74BB60
	|-List.Enumerator<BakedData.Lightmap>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BC00 Offset: 0x74BC00 VA: 0x74BC00
	|-List.Enumerator<BakedData.MeshBakingData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BC88 Offset: 0x74BC88 VA: 0x74BC88
	|-List.Enumerator<AudioUtils.SceneToolDelayPostSoundEventNameData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BD10 Offset: 0x74BD10 VA: 0x74BD10
	|-List.Enumerator<GunSightView.RendererAndMaterialIndex>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BDA0 Offset: 0x74BDA0 VA: 0x74BDA0
	|-List.Enumerator<BattleConfiguration.SetP2WeaponCfg.WpIKOffsetInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BE18 Offset: 0x74BE18 VA: 0x74BE18
	|-List.Enumerator<LoaderMeshInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BEA0 Offset: 0x74BEA0 VA: 0x74BEA0
	|-List.Enumerator<ToolThroughWallHelper.PairedTransforms>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BF28 Offset: 0x74BF28 VA: 0x74BF28
	|-List.Enumerator<ScanUtils.Result>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74BFB0 Offset: 0x74BFB0 VA: 0x74BFB0
	|-List.Enumerator<Pair>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C038 Offset: 0x74C038 VA: 0x74C038
	|-List.Enumerator<FVector2>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C0C4 Offset: 0x74C0C4 VA: 0x74C0C4
	|-List.Enumerator<FVector3>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C150 Offset: 0x74C150 VA: 0x74C150
	|-List.Enumerator<ShapeData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C1E4 Offset: 0x74C1E4 VA: 0x74C1E4
	|-List.Enumerator<CCContact>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C26C Offset: 0x74C26C VA: 0x74C26C
	|-List.Enumerator<Line>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C304 Offset: 0x74C304 VA: 0x74C304
	|-List.Enumerator<GetBackResult>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C38C Offset: 0x74C38C VA: 0x74C38C
	|-List.Enumerator<SubMeshInstance>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C420 Offset: 0x74C420 VA: 0x74C420
	|-List.Enumerator<GeometryCollection.ObjectInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C4A8 Offset: 0x74C4A8 VA: 0x74C4A8
	|-List.Enumerator<JsonPosition>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C53C Offset: 0x74C53C VA: 0x74C53C
	|-List.Enumerator<ScreenOutlineRenderer.ProjectorRenderer>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C5C8 Offset: 0x74C5C8 VA: 0x74C5C8
	|-List.Enumerator<ScreenThermalImagerRenderer.ProjectorRenderer>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C654 Offset: 0x74C654 VA: 0x74C654
	|-List.Enumerator<EventQueue.EventQueueEntry>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C6E0 Offset: 0x74C6E0 VA: 0x74C6E0
	|-List.Enumerator<SkeletonRendererCustomMaterials.AtlasMaterialOverride>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C76C Offset: 0x74C76C VA: 0x74C76C
	|-List.Enumerator<SkeletonRendererCustomMaterials.SlotMaterialOverride>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C7F4 Offset: 0x74C7F4 VA: 0x74C7F4
	|-List.Enumerator<SkeletonUtilityKinematicShadow.TransformPair>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C86C Offset: 0x74C86C VA: 0x74C86C
	|-List.Enumerator<bool>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C8E4 Offset: 0x74C8E4 VA: 0x74C8E4
	|-List.Enumerator<byte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C95C Offset: 0x74C95C VA: 0x74C95C
	|-List.Enumerator<char>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74C9E4 Offset: 0x74C9E4 VA: 0x74C9E4
	|-List.Enumerator<DictionaryEntry>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CA68 Offset: 0x74CA68 VA: 0x74CA68
	|-List.Enumerator<KeyValuePair<U64Id, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CAEC Offset: 0x74CAEC VA: 0x74CAEC
	|-List.Enumerator<KeyValuePair<DateTime, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CB74 Offset: 0x74CB74 VA: 0x74CB74
	|-List.Enumerator<KeyValuePair<int, int>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CBFC Offset: 0x74CBFC VA: 0x74CBFC
	|-List.Enumerator<KeyValuePair<int, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CC84 Offset: 0x74CC84 VA: 0x74CC84
	|-List.Enumerator<KeyValuePair<object, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CD0C Offset: 0x74CD0C VA: 0x74CD0C
	|-List.Enumerator<KeyValuePair<uint, object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CD9C Offset: 0x74CD9C VA: 0x74CD9C
	|-List.Enumerator<KeyValuePair<JobHandle, KeyValuePair<GeometryDataJob_Parallel, object>>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CE18 Offset: 0x74CE18 VA: 0x74CE18
	|-List.Enumerator<DateTime>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CE9C Offset: 0x74CE9C VA: 0x74CE9C
	|-List.Enumerator<DateTimeOffset>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CF24 Offset: 0x74CF24 VA: 0x74CF24
	|-List.Enumerator<Decimal>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74CFA0 Offset: 0x74CFA0 VA: 0x74CFA0
	|-List.Enumerator<double>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D018 Offset: 0x74D018 VA: 0x74D018
	|-List.Enumerator<short>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D090 Offset: 0x74D090 VA: 0x74D090
	|-List.Enumerator<int>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D108 Offset: 0x74D108 VA: 0x74D108
	|-List.Enumerator<Int32Enum>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D180 Offset: 0x74D180 VA: 0x74D180
	|-List.Enumerator<long>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D1F8 Offset: 0x74D1F8 VA: 0x74D1F8
	|-List.Enumerator<object>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D270 Offset: 0x74D270 VA: 0x74D270
	|-List.Enumerator<sbyte>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D2E8 Offset: 0x74D2E8 VA: 0x74D2E8
	|-List.Enumerator<float>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D364 Offset: 0x74D364 VA: 0x74D364
	|-List.Enumerator<TimeSpan>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D3DC Offset: 0x74D3DC VA: 0x74D3DC
	|-List.Enumerator<ushort>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D454 Offset: 0x74D454 VA: 0x74D454
	|-List.Enumerator<uint>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D4CC Offset: 0x74D4CC VA: 0x74D4CC
	|-List.Enumerator<ulong>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D554 Offset: 0x74D554 VA: 0x74D554
	|-List.Enumerator<ValueTuple<object, Vector3>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D5DC Offset: 0x74D5DC VA: 0x74D5DC
	|-List.Enumerator<ValueTuple<float, Vector3>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D674 Offset: 0x74D674 VA: 0x74D674
	|-List.Enumerator<ValueTuple<Vector3, Vector3>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D6FC Offset: 0x74D6FC VA: 0x74D6FC
	|-List.Enumerator<RangePositionInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D784 Offset: 0x74D784 VA: 0x74D784
	|-List.Enumerator<XmlSchemaObjectTable.XmlSchemaObjectEntry>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D83C Offset: 0x74D83C VA: 0x74D83C
	|-List.Enumerator<TexturePacker.SpriteData>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D8D8 Offset: 0x74D8D8 VA: 0x74D8D8
	|-List.Enumerator<TestAudioData.AudioRecord>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D960 Offset: 0x74D960 VA: 0x74D960
	|-List.Enumerator<NativeList<int>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74D9E8 Offset: 0x74D9E8 VA: 0x74D9E8
	|-List.Enumerator<AnimatorClipInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DA70 Offset: 0x74DA70 VA: 0x74DA70
	|-List.Enumerator<BeforeRenderHelper.OrderBlock>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DB0C Offset: 0x74DB0C VA: 0x74DB0C
	|-List.Enumerator<BoneWeight>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DB84 Offset: 0x74DB84 VA: 0x74DB84
	|-List.Enumerator<Color32>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DC0C Offset: 0x74DC0C VA: 0x74DC0C
	|-List.Enumerator<Color>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DC9C Offset: 0x74DC9C VA: 0x74DC9C
	|-List.Enumerator<CombineInstance>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DD54 Offset: 0x74DD54 VA: 0x74DD54
	|-List.Enumerator<RaycastResult>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DDE8 Offset: 0x74DDE8 VA: 0x74DDE8
	|-List.Enumerator<IntervalTreeNode>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DE7C Offset: 0x74DE7C VA: 0x74DE7C
	|-List.Enumerator<IntervalTree.Entry<object>>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DF34 Offset: 0x74DF34 VA: 0x74DF34
	|-List.Enumerator<Matrix4x4>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74DFBC Offset: 0x74DFBC VA: 0x74DFBC
	|-List.Enumerator<Playable>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74E064 Offset: 0x74E064 VA: 0x74E064
	|-List.Enumerator<RaycastHit>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74E104 Offset: 0x74E104 VA: 0x74E104
	|-List.Enumerator<RenderTargetIdentifier>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x74E18C Offset: 0x74E18C VA: 0x74E18C
	|-List.Enumerator<GlyphRect>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CF7CC Offset: 0x7CF7CC VA: 0x7CF7CC
	|-List.Enumerator<AnimationOutputWeightProcessor.WeightInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CF858 Offset: 0x7CF858 VA: 0x7CF858
	|-List.Enumerator<UICharInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CF8E0 Offset: 0x7CF8E0 VA: 0x7CF8E0
	|-List.Enumerator<UILineInfo>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CF970 Offset: 0x7CF970 VA: 0x7CF970
	|-List.Enumerator<UIVertex>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CF9FC Offset: 0x7CF9FC VA: 0x7CF9FC
	|-List.Enumerator<UnitySynchronizationContext.WorkRequest>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFA84 Offset: 0x7CFA84 VA: 0x7CFA84
	|-List.Enumerator<Vector2>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFB10 Offset: 0x7CFB10 VA: 0x7CFB10
	|-List.Enumerator<Vector3>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFB98 Offset: 0x7CFB98 VA: 0x7CFB98
	|-List.Enumerator<Vector4>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFC38 Offset: 0x7CFC38 VA: 0x7CFC38
	|-List.Enumerator<LODGenerator.SkinnedRenderer>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFCCC Offset: 0x7CFCCC VA: 0x7CFCCC
	|-List.Enumerator<LODGenerator.StaticRenderer>.System.Collections.IEnumerator.Reset
	|
	|-RVA: 0x7CFD54 Offset: 0x7CFD54 VA: 0x7CFD54
	|-List.Enumerator<UniversalPlaceDebuggerComponent.FrameAction>.System.Collections.IEnumerator.Reset
	*/
}
