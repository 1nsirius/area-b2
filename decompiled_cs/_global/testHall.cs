// Namespace: 
public class testHall : MonoBehaviour // TypeDefIndex: 5688
{
	// Fields
	private Vector3 rotationEuler; // 0xC
	public GameObject[] cameraObj; // 0x18
	public GameObject[] cameraPos; // 0x1C
	public GameObject uiAniObj; // 0x20
	private float autoRot; // 0x24
	private uint index; // 0x28
	private TestDrag DragScript; // 0x2C
	public GameObject TestDragObj; // 0x30
	private Vector2 lastDrag; // 0x34
	private Camera curCamera; // 0x3C
	private bool lerping; // 0x40
	private float lerpingTime; // 0x44
	private Vector3 lerpingBeginPos; // 0x48
	private Quaternion lerpingBeginRot; // 0x54
	private Transform[] defaultCameraObjTran; // 0x64
	private Transform[] defaultCameraPosTran; // 0x68
	public float sensitivityX; // 0x6C
	public float sensitivityY; // 0x70
	public float maxYUp; // 0x74
	public float maxYDown; // 0x78
	public float autoSpeed; // 0x7C
	public float cameraMoveTime; // 0x80
	public float delayAutoRotate; // 0x84
	public float yawMaxValue; // 0x88
	public LanguageMono titleText; // 0x8C
	public LanguageMono contentText; // 0x90
	private int[] titleIds; // 0x94
	private int[] contentIds; // 0x98
	public GameObject[] playerIcons; // 0x9C
	public GameObject camCtrGo; // 0xA0
	public GameObject objInfoNode; // 0xA4

	// Methods

	// RVA: 0x10D5724 Offset: 0x10D5724 VA: 0x10D5724
	private void Awake() { }

	// RVA: 0x10D5EBC Offset: 0x10D5EBC VA: 0x10D5EBC
	private void Start() { }

	// RVA: 0x10D6028 Offset: 0x10D6028 VA: 0x10D6028
	private void Update() { }

	// RVA: 0x10D66A4 Offset: 0x10D66A4 VA: 0x10D66A4
	private void LateUpdate() { }

	// RVA: 0x10D6E94 Offset: 0x10D6E94 VA: 0x10D6E94
	public void OnPointerClick(PointerEventData eventData) { }

	// RVA: 0x10D7178 Offset: 0x10D7178 VA: 0x10D7178
	private void SwitchCamera(uint index) { }

	// RVA: 0x10D76D4 Offset: 0x10D76D4 VA: 0x10D76D4
	private void OnHallSceneInActive() { }

	// RVA: 0x10D7788 Offset: 0x10D7788 VA: 0x10D7788
	private void OnDestroy() { }

	// RVA: 0x10D79CC Offset: 0x10D79CC VA: 0x10D79CC
	private void BackBtnCallback() { }

	// RVA: 0x10D6E04 Offset: 0x10D6E04 VA: 0x10D6E04
	private void SwitchCallBack() { }

	// RVA: 0x10D79D4 Offset: 0x10D79D4 VA: 0x10D79D4
	public void OnStateChangeEvent(EGameMusicStates eventData) { }

	// RVA: 0x10D65B8 Offset: 0x10D65B8 VA: 0x10D65B8
	private float ClampAngle(float angle, float min, float max) { }

	// RVA: 0x10D7A34 Offset: 0x10D7A34 VA: 0x10D7A34
	private float NormalizeAngle(float angle) { }

	// RVA: 0x10D7A80 Offset: 0x10D7A80 VA: 0x10D7A80
	public void .ctor() { }
}
