// Namespace: 
[TypeForwardedFromAttribute] // RVA: 0x4D83A8 Offset: 0x4D83A8 VA: 0x4D83A8
[Serializable]
public struct TimeZoneInfo.TransitionTime : IEquatable<TimeZoneInfo.TransitionTime>, ISerializable, IDeserializationCallback // TypeDefIndex: 306
{
	// Fields
	private DateTime m_timeOfDay; // 0x0
	private byte m_month; // 0x8
	private byte m_week; // 0x9
	private byte m_day; // 0xA
	private DayOfWeek m_dayOfWeek; // 0xC
	private bool m_isFixedDateRule; // 0x10

	// Properties
	public DateTime TimeOfDay { get; }
	public int Month { get; }
	public int Week { get; }
	public int Day { get; }
	public DayOfWeek DayOfWeek { get; }
	public bool IsFixedDateRule { get; }

	// Methods

	// RVA: 0x775E60 Offset: 0x775E60 VA: 0x775E60
	public DateTime get_TimeOfDay() { }

	// RVA: 0x775E6C Offset: 0x775E6C VA: 0x775E6C
	public int get_Month() { }

	// RVA: 0x775E74 Offset: 0x775E74 VA: 0x775E74
	public int get_Week() { }

	// RVA: 0x775E7C Offset: 0x775E7C VA: 0x775E7C
	public int get_Day() { }

	// RVA: 0x775E84 Offset: 0x775E84 VA: 0x775E84
	public DayOfWeek get_DayOfWeek() { }

	// RVA: 0x775E8C Offset: 0x775E8C VA: 0x775E8C
	public bool get_IsFixedDateRule() { }

	// RVA: 0x775E94 Offset: 0x775E94 VA: 0x775E94 Slot: 0
	public override bool Equals(object obj) { }

	// RVA: 0x1AD6C28 Offset: 0x1AD6C28 VA: 0x1AD6C28
	public static bool op_Inequality(TimeZoneInfo.TransitionTime t1, TimeZoneInfo.TransitionTime t2) { }

	// RVA: 0x775E9C Offset: 0x775E9C VA: 0x775E9C Slot: 4
	public bool Equals(TimeZoneInfo.TransitionTime other) { }

	// RVA: 0x775ECC Offset: 0x775ECC VA: 0x775ECC Slot: 2
	public override int GetHashCode() { }

	// RVA: 0x1ACB524 Offset: 0x1ACB524 VA: 0x1ACB524
	public static TimeZoneInfo.TransitionTime CreateFixedDateRule(DateTime timeOfDay, int month, int day) { }

	// RVA: 0x1ACCF20 Offset: 0x1ACCF20 VA: 0x1ACCF20
	public static TimeZoneInfo.TransitionTime CreateFloatingDateRule(DateTime timeOfDay, int month, int week, DayOfWeek dayOfWeek) { }

	// RVA: 0x1AD7C60 Offset: 0x1AD7C60 VA: 0x1AD7C60
	private static TimeZoneInfo.TransitionTime CreateTransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek, bool isFixedDateRule) { }

	// RVA: 0x1AD7CD4 Offset: 0x1AD7CD4 VA: 0x1AD7CD4
	private static void ValidateTransitionTime(DateTime timeOfDay, int month, int week, int day, DayOfWeek dayOfWeek) { }

	// RVA: 0x775EDC Offset: 0x775EDC VA: 0x775EDC Slot: 6
	private void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

	// RVA: 0x775EE4 Offset: 0x775EE4 VA: 0x775EE4 Slot: 5
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x775F00 Offset: 0x775F00 VA: 0x775F00
	private void .ctor(SerializationInfo info, StreamingContext context) { }
}
