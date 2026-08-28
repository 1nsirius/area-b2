// Namespace: 
public class UIClickEventRepeater : MonoBehaviour, IPointerClickHandler, IEventSystemHandler // TypeDefIndex: 5817
{
	// Fields
	private GameObject mTargetHandler; // 0xC

	// Methods

	// RVA: 0xAF12AC Offset: 0xAF12AC VA: 0xAF12AC
	public void SetTarget(GameObject t) { }

	// RVA: 0xAF12B4 Offset: 0xAF12B4 VA: 0xAF12B4 Slot: 4
	private void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(PointerEventData eventData) { }

	// RVA: -1 Offset: -1
	private void ThrowEvent2Default<T>(PointerEventData eventData, ExecuteEvents.EventFunction<T> handle) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x10BBFE8 Offset: 0x10BBFE8 VA: 0x10BBFE8
	|-UIClickEventRepeater.ThrowEvent2Default<object>
	|-UIClickEventRepeater.ThrowEvent2Default<IPointerClickHandler>
	*/

	// RVA: 0xAF1358 Offset: 0xAF1358 VA: 0xAF1358
	public void .ctor() { }
}
