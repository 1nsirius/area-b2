namespace FGame
{

// Namespace: FGame
[ExtensionAttribute] // RVA: 0x553D90 Offset: 0x553D90 VA: 0x553D90
public static class CSharpAPIForLua // TypeDefIndex: 9836
{
	// Fields
	private static Dictionary<LuaFunction, Callback> mFuncDict; // 0x0
	private static Dictionary<LuaFunction, Callback<int>> mFuncDict_Integer; // 0x4
	private static Dictionary<LuaFunction, Callback<bool>> mFuncDict_Boolean; // 0x8
	private static Dictionary<LuaFunction, Callback<float>> mFuncDict_Float; // 0xC
	private static Dictionary<LuaFunction, Callback<Vector3>> mFuncDict_Vec3; // 0x10
	private static Dictionary<LuaFunction, Callback<string>> mFuncDict_String; // 0x14
	private static Dictionary<LuaFunction, Callback<SprotoTypeBase>> mFuncDict_Sproto; // 0x18
	private static Dictionary<LuaFunction, Callback<BlockingBoard>> mFuncDict_BB; // 0x1C
	private static Dictionary<int, ICollection<object>> Dicts; // 0x20
	private static Dictionary<string, DelayedAction> mDelayVolumeIndication; // 0x24

	// Methods

	// RVA: 0xBEE544 Offset: 0xBEE544 VA: 0xBEE544
	public static bool IsAttacker() { }

	// RVA: 0xBEE628 Offset: 0xBEE628 VA: 0xBEE628
	public static bool IsDefender() { }

	// RVA: 0xBEE714 Offset: 0xBEE714 VA: 0xBEE714
	public static bool IsMainCharacter(int bid) { }

	// RVA: 0xBEE7E4 Offset: 0xBEE7E4 VA: 0xBEE7E4
	public static int GetEnemyNum() { }

	// RVA: 0xBEE894 Offset: 0xBEE894 VA: 0xBEE894
	public static int GetPlayersNum(int camp) { }

	// RVA: 0xBEEA90 Offset: 0xBEEA90 VA: 0xBEEA90
	public static string Trim(string text) { }

	// RVA: 0xBEEB38 Offset: 0xBEEB38 VA: 0xBEEB38
	public static bool IsNullOrEmpty(string text) { }

	// RVA: 0xBEEB40 Offset: 0xBEEB40 VA: 0xBEEB40
	public static bool IsNull(GameObject go) { }

	// RVA: 0xBEEBFC Offset: 0xBEEBFC VA: 0xBEEBFC
	public static float RangeFloat(float min, float max) { }

	[ExtensionAttribute] // RVA: 0x646C70 Offset: 0x646C70 VA: 0x646C70
	// RVA: 0xBEEC04 Offset: 0xBEEC04 VA: 0xBEEC04
	public static void ResetCountDown(GameObjectEntity goe, float duration) { }

	// RVA: 0xBEECA8 Offset: 0xBEECA8 VA: 0xBEECA8
	public static int RangeInteger(int min, int max) { }

	// RVA: 0xBEECB0 Offset: 0xBEECB0 VA: 0xBEECB0
	public static void ReqEnterBattle(ulong battleID, string token) { }

	// RVA: 0xBEF524 Offset: 0xBEF524 VA: 0xBEF524
	public static void AddUIPointerClickEvent(GameObject go, LuaFunction func) { }

	// RVA: 0xBEF628 Offset: 0xBEF628 VA: 0xBEF628
	public static float Atan2(float y, float x) { }

	// RVA: 0xBEF6B0 Offset: 0xBEF6B0 VA: 0xBEF6B0
	public static void LoadLoobyScene() { }

	// RVA: 0xBEF760 Offset: 0xBEF760 VA: 0xBEF760
	public static void EnterLobbyState() { }

	// RVA: 0xBEF808 Offset: 0xBEF808 VA: 0xBEF808
	public static void SetCustomizableUiEnable(bool en) { }

	// RVA: 0xBEF8B8 Offset: 0xBEF8B8 VA: 0xBEF8B8
	public static string FloatToPercentStr(float f) { }

	// RVA: 0xBEF94C Offset: 0xBEF94C VA: 0xBEF94C
	public static void AddNormalTextEntity(int textInfoId, bool forceReplace, string[] formatStr) { }

	// RVA: 0xBEFA00 Offset: 0xBEFA00 VA: 0xBEFA00
	public static void Vibrate() { }

	// RVA: 0xBEFA08 Offset: 0xBEFA08 VA: 0xBEFA08
	public static void AddCommonds(string name, Action<CommandArg[]> proc, int min_arg_count = 0, int max_arg_count = -1, string help = "") { }

	// RVA: 0xBEFB28 Offset: 0xBEFB28 VA: 0xBEFB28
	public static void SetSceneStageToLoading() { }

	// RVA: 0xBEFC14 Offset: 0xBEFC14 VA: 0xBEFC14
	public static void DoString(string chunk) { }

	// RVA: 0xBEFCE4 Offset: 0xBEFCE4 VA: 0xBEFCE4
	public static int GetGoldCount() { }

	// RVA: 0xBEFDD0 Offset: 0xBEFDD0 VA: 0xBEFDD0
	public static int GetDiamondCount() { }

	// RVA: 0xBEFEBC Offset: 0xBEFEBC VA: 0xBEFEBC
	public static bool GetHasUnlockChar(int id) { }

	// RVA: 0xBEFF8C Offset: 0xBEFF8C VA: 0xBEFF8C
	public static void SetGameState(string state) { }

	// RVA: 0xBF003C Offset: 0xBF003C VA: 0xBF003C
	public static void SetGameingState(string state) { }

	// RVA: 0xBF00EC Offset: 0xBF00EC VA: 0xBF00EC
	public static void SetLobbyState(string state) { }

	// RVA: 0xBF019C Offset: 0xBF019C VA: 0xBF019C
	public static Transform Find(GameObject go, string path) { }

	// RVA: 0xBF0274 Offset: 0xBF0274 VA: 0xBF0274
	public static void SetActive(Transform trans, bool active) { }

	// RVA: 0xBF02C8 Offset: 0xBF02C8 VA: 0xBF02C8
	public static bool IsNull(object target) { }

	// RVA: 0xBF02E8 Offset: 0xBF02E8 VA: 0xBF02E8
	public static int GetDevType() { }

	// RVA: 0xBF02F0 Offset: 0xBF02F0 VA: 0xBF02F0
	public static GameObject LoadGameObject(AssetPool assetPool, Transform parent, string category, string bundle, string name) { }

	// RVA: 0xBF05E8 Offset: 0xBF05E8 VA: 0xBF05E8
	public static void DestroyGameObject(GameObject obj) { }

	// RVA: -1 Offset: -1
	public static T Instantiate<T>(T prefab, RectTransform parent) { }
	/* GenericInstMethod :
	|
	|-RVA: 0xCD9BA8 Offset: 0xCD9BA8 VA: 0xCD9BA8
	|-CSharpAPIForLua.Instantiate<object>
	|-CSharpAPIForLua.Instantiate<Object>
	*/

	// RVA: 0xBF06B0 Offset: 0xBF06B0 VA: 0xBF06B0
	public static void ClearRemoveableDict() { }

	// RVA: 0xBF0924 Offset: 0xBF0924 VA: 0xBF0924
	public static void AddMessengerListener_String(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF0AB4 Offset: 0xBF0AB4 VA: 0xBF0AB4
	public static void RemoveMessengerListener_String(MsgIdsEnum eventType, LuaFunction fnc) { }

	// RVA: 0xBF0C7C Offset: 0xBF0C7C VA: 0xBF0C7C
	public static void AddMessengerListener_Float(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF0E0C Offset: 0xBF0E0C VA: 0xBF0E0C
	public static void RemoveMessengerListener_Float(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF0FD4 Offset: 0xBF0FD4 VA: 0xBF0FD4
	public static void AddMessengerListener_Sproto(MsgIdsEnum eventType, Callback<SprotoTypeBase> fnc) { }

	// RVA: 0xBF106C Offset: 0xBF106C VA: 0xBF106C
	public static void RemoveMessengerListener_Sproto(MsgIdsEnum eventType, Callback<SprotoTypeBase> fnc) { }

	// RVA: 0xBF1104 Offset: 0xBF1104 VA: 0xBF1104
	public static void AddMessengerListener_NullArguments(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF127C Offset: 0xBF127C VA: 0xBF127C
	public static void RemoveMessengerListener_NullArguments(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1438 Offset: 0xBF1438 VA: 0xBF1438
	public static void AddMessengerListener_Integer(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF15C8 Offset: 0xBF15C8 VA: 0xBF15C8
	public static void RemoveMessengerListener_Integer(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1790 Offset: 0xBF1790 VA: 0xBF1790
	public static void AddMessengerListener_Boolean(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1920 Offset: 0xBF1920 VA: 0xBF1920
	public static void RemoveMessengerListener_Boolean(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1AE8 Offset: 0xBF1AE8 VA: 0xBF1AE8
	public static void AddMessengerListener_BlockingBoard(MsgIdsEnum eventType, LuaFunction fnc) { }

	// RVA: 0xBF1C78 Offset: 0xBF1C78 VA: 0xBF1C78
	public static void RemoveMessengerListener_BlockingBoard(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1E40 Offset: 0xBF1E40 VA: 0xBF1E40
	public static void AddMessengerListener_Vector3(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF1FD0 Offset: 0xBF1FD0 VA: 0xBF1FD0
	public static void RemoveMessengerListener_Vector3(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF2198 Offset: 0xBF2198 VA: 0xBF2198
	public static void AddMessengerListener_IntegerString(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF22B0 Offset: 0xBF22B0 VA: 0xBF22B0
	public static void AddMessengerListener_StringLong(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF23C8 Offset: 0xBF23C8 VA: 0xBF23C8
	public static void AddMessengerListener_StringBool(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF24E0 Offset: 0xBF24E0 VA: 0xBF24E0
	public static void AddMessengerListener_GuideOperateBool(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF25F8 Offset: 0xBF25F8 VA: 0xBF25F8
	public static void AddMessengerListener_IntegerInteger(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF2710 Offset: 0xBF2710 VA: 0xBF2710
	public static void AddMessengerListener_NullableIntegerInteger(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF2828 Offset: 0xBF2828 VA: 0xBF2828
	public static void AddMessengerListener_BoolIntegerString(int eventType, LuaFunction fnc) { }

	// RVA: 0xBF2940 Offset: 0xBF2940 VA: 0xBF2940
	public static void MessengerBroadcast(int eventType) { }

	// RVA: 0xBF29C8 Offset: 0xBF29C8 VA: 0xBF29C8
	public static void MessengerBroadcast_String(int eventType, string str) { }

	// RVA: 0xBF2A64 Offset: 0xBF2A64 VA: 0xBF2A64
	public static void LoadSoundBank(string bank) { }

	// RVA: 0xBF2AF4 Offset: 0xBF2AF4 VA: 0xBF2AF4
	public static void PlayDubbing(string soundEventName, float duration, int priority) { }

	// RVA: 0xBF2BC4 Offset: 0xBF2BC4 VA: 0xBF2BC4
	public static Quaternion LookRotation(Vector3 forward, Vector3 up) { }

	// RVA: 0xBF2C84 Offset: 0xBF2C84 VA: 0xBF2C84
	public static Vector3 InverseVector3(Quaternion rotation, Vector3 vec) { }

	// RVA: 0xBF2D60 Offset: 0xBF2D60 VA: 0xBF2D60
	public static float GetMagnitude(Vector3 vec) { }

	// RVA: 0xBF2D84 Offset: 0xBF2D84 VA: 0xBF2D84
	public static Vector3 Normalized(Vector3 vec) { }

	// RVA: 0xBF2DA8 Offset: 0xBF2DA8 VA: 0xBF2DA8
	public static void SetRotation(Transform t, Quaternion rot) { }

	// RVA: 0xBF2E00 Offset: 0xBF2E00 VA: 0xBF2E00
	public static void SetScale(Transform t, Vector3 scale) { }

	// RVA: 0xBF2E50 Offset: 0xBF2E50 VA: 0xBF2E50
	public static Quaternion GetEulerRotation(float x, float y, float z) { }

	// RVA: 0xBF2EF8 Offset: 0xBF2EF8 VA: 0xBF2EF8
	public static float DotVector3(Vector3 vec1, Vector3 vec2) { }

	// RVA: 0xBF2FB0 Offset: 0xBF2FB0 VA: 0xBF2FB0
	public static int DistToCamera(Vector3 worldPos) { }

	// RVA: 0xBF31A0 Offset: 0xBF31A0 VA: 0xBF31A0
	public static void ShowMaskPanel(float duration) { }

	// RVA: 0xBF3364 Offset: 0xBF3364 VA: 0xBF3364
	public static void HistMaskPanel() { }

	// RVA: 0xBF34A8 Offset: 0xBF34A8 VA: 0xBF34A8
	public static void SetAnchorFitPosition(RectTransform tran, Vector2 anchorMin, Vector2 anchorMax, Vector2 anchorPosition, float roll) { }

	// RVA: 0xBF3624 Offset: 0xBF3624 VA: 0xBF3624
	public static void ShowDialog(string title, string context, string yesText, string noText, UnityAction OnYes, UnityAction OnNo, UnityAction OnCloseBtnClick) { }

	// RVA: 0xBF3708 Offset: 0xBF3708 VA: 0xBF3708
	public static void ShowDialog(string title, string context, string yesText, UnityAction OnYes) { }

	// RVA: 0xBF37DC Offset: 0xBF37DC VA: 0xBF37DC
	public static void ShowDialog(string title, string context, float autocloseTime = -1) { }

	// RVA: 0xBF38A8 Offset: 0xBF38A8 VA: 0xBF38A8
	public static void RegistSprotoListnener(int key, Callback<SprotoTypeBase> handler) { }

	// RVA: 0xBF3940 Offset: 0xBF3940 VA: 0xBF3940
	public static void RemoveSprotoListener(int key, Callback<SprotoTypeBase> handler) { }

	// RVA: 0xBF39D8 Offset: 0xBF39D8 VA: 0xBF39D8
	public static void SetImageSprite(AssetPool assetPool, Image img, string path) { }

	// RVA: 0xBF3A9C Offset: 0xBF3A9C VA: 0xBF3A9C
	public static void SetImageSprite(AssetPool assetPool, Image img, string category, string bundle, string name) { }

	// RVA: 0xBF3D4C Offset: 0xBF3D4C VA: 0xBF3D4C
	public static void SetImageTransform(Image img, Vector2 anchorPos, Vector2 anchor, Vector2 pivot, Vector3 localEuler, Vector3 localScale, float width, float height, Color color) { }

	// RVA: 0xBF3FD4 Offset: 0xBF3FD4 VA: 0xBF3FD4
	public static void SetImageTransformLerp(Image img, float lerp, Vector2 bfVec, Vector2 afVec, Vector2 bfAnchor, Vector2 afAnchor, Vector2 bfPivot, Vector2 afPivot) { }

	// RVA: 0xBF4200 Offset: 0xBF4200 VA: 0xBF4200
	public static Image LoadOneImg(RectTransform rectParent, Vector2 anchorPos, Vector2 anchor, Vector2 sizeDelta, Vector2 pivot, Vector3 euler) { }

	// RVA: 0xBF45A0 Offset: 0xBF45A0 VA: 0xBF45A0
	public static RectTransform InstantiateOneRectTransform(AssetPool assetPool, RectTransform parent, string path) { }

	// RVA: 0xBF46B8 Offset: 0xBF46B8 VA: 0xBF46B8
	public static RectTransform InstantiateOneRectTransform(RectTransform pfb) { }

	// RVA: 0xBF47F0 Offset: 0xBF47F0 VA: 0xBF47F0
	public static void DestroyRectTransform(RectTransform rt) { }

	// RVA: 0xBF4894 Offset: 0xBF4894 VA: 0xBF4894
	public static void DestroyOneImg(Image img) { }

	// RVA: 0xBF4938 Offset: 0xBF4938 VA: 0xBF4938
	public static string GetLanguageById(int id) { }

	// RVA: 0xBF49E8 Offset: 0xBF49E8 VA: 0xBF49E8
	public static void ShowRectTransform(RectTransform rt, bool show) { }

	// RVA: 0xBF49F0 Offset: 0xBF49F0 VA: 0xBF49F0
	public static void OnPlayersWasVoiceing(string[] speakers) { }

	// RVA: 0xBF4D80 Offset: 0xBF4D80 VA: 0xBF4D80
	public static void OpenRoundStartView(game.RspUserGuideRoundStart.request req) { }

	// RVA: 0xBF507C Offset: 0xBF507C VA: 0xBF507C
	public static void SetScreenPosFromWorldPos(Vector3 worldPos, RectTransform rt) { }

	// RVA: 0xBF51FC Offset: 0xBF51FC VA: 0xBF51FC
	public static RectTransform CopyRectTransformsFromPath(string path, RectTransform rt) { }

	// RVA: 0xBF5E98 Offset: 0xBF5E98 VA: 0xBF5E98
	private static void CopyRectTransformInfos(RectTransform copy, RectTransform from) { }

	// RVA: 0xBF609C Offset: 0xBF609C VA: 0xBF609C
	public static void RemoveAllButUIHudTextPanel() { }

	// RVA: 0xBF6224 Offset: 0xBF6224 VA: 0xBF6224
	public static bool IsFPControlUIOpen() { }

	// RVA: 0xBF631C Offset: 0xBF631C VA: 0xBF631C
	public static void OnVoiceChannelCreated() { }

	// RVA: 0xBF640C Offset: 0xBF640C VA: 0xBF640C
	public static void OnUserJoined(string playerId) { }

	// RVA: 0xBF681C Offset: 0xBF681C VA: 0xBF681C
	public static void OnUserLeaved(string playerId) { }

	// RVA: 0xBF697C Offset: 0xBF697C VA: 0xBF697C
	public static void OnSelfLeaved() { }

	// RVA: 0xBF6BD8 Offset: 0xBF6BD8 VA: 0xBF6BD8
	public static void OnVolumeIndication(string playerId, float volume) { }

	// RVA: 0xBF7210 Offset: 0xBF7210 VA: 0xBF7210
	public static void ResetScoreData() { }

	// RVA: 0xBF675C Offset: 0xBF675C VA: 0xBF675C
	private static void GenerateNormalArgs(string playerId, out NormalArgs args) { }

	// RVA: 0xBF6BD0 Offset: 0xBF6BD0 VA: 0xBF6BD0
	private static void GenerateNormalArgs(long playerId, out NormalArgs args) { }

	// RVA: 0xBF66D0 Offset: 0xBF66D0 VA: 0xBF66D0
	public static void ReqOperateVoiceChannel(long operate_type) { }

	// RVA: 0xBF72D8 Offset: 0xBF72D8 VA: 0xBF72D8
	public static void SyncSelfVoiceInfos() { }

	// RVA: 0xBF7440 Offset: 0xBF7440 VA: 0xBF7440
	private static void .cctor() { }
}

} // namespace FGame
