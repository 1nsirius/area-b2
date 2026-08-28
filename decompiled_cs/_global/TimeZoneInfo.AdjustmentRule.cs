// Namespace: 
[TypeForwardedFromAttribute] // RVA: 0x4D8374 Offset: 0x4D8374 VA: 0x4D8374
[Serializable]
public sealed class TimeZoneInfo.AdjustmentRule : IEquatable<TimeZoneInfo.AdjustmentRule>, ISerializable, IDeserializationCallback // TypeDefIndex: 305
{
	// Fields
	private DateTime m_dateStart; // 0x8
	private DateTime m_dateEnd; // 0x10
	private TimeSpan m_daylightDelta; // 0x18
	private TimeZoneInfo.TransitionTime m_daylightTransitionStart; // 0x20
	private TimeZoneInfo.TransitionTime m_daylightTransitionEnd; // 0x38
	private TimeSpan m_baseUtcOffsetDelta; // 0x50

	// Properties
	public DateTime DateStart { get; }
	public DateTime DateEnd { get; }
	public TimeSpan DaylightDelta { get; }
	public TimeZoneInfo.TransitionTime DaylightTransitionStart { get; }
	public TimeZoneInfo.TransitionTime DaylightTransitionEnd { get; }

	// Methods

	// RVA: 0x1AD4FA4 Offset: 0x1AD4FA4 VA: 0x1AD4FA4
	public DateTime get_DateStart() { }

	// RVA: 0x1AD4FB0 Offset: 0x1AD4FB0 VA: 0x1AD4FB0
	public DateTime get_DateEnd() { }

	// RVA: 0x1AD3BD8 Offset: 0x1AD3BD8 VA: 0x1AD3BD8
	public TimeSpan get_DaylightDelta() { }

	// RVA: 0x1AD460C Offset: 0x1AD460C VA: 0x1AD460C
	public TimeZoneInfo.TransitionTime get_DaylightTransitionStart() { }

	// RVA: 0x1AD408C Offset: 0x1AD408C VA: 0x1AD408C
	public TimeZoneInfo.TransitionTime get_DaylightTransitionEnd() { }

	// RVA: 0x1AD3BE4 Offset: 0x1AD3BE4 VA: 0x1AD3BE4 Slot: 4
	public bool Equals(TimeZoneInfo.AdjustmentRule other) { }

	// RVA: 0x1AD6F04 Offset: 0x1AD6F04 VA: 0x1AD6F04 Slot: 2
	public override int GetHashCode() { }

	// RVA: 0x1AD6F10 Offset: 0x1AD6F10 VA: 0x1AD6F10
	private void .ctor() { }

	// RVA: 0x1ACB598 Offset: 0x1ACB598 VA: 0x1ACB598
	public static TimeZoneInfo.AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TimeZoneInfo.TransitionTime daylightTransitionStart, TimeZoneInfo.TransitionTime daylightTransitionEnd) { }

	// RVA: 0x1ACCA84 Offset: 0x1ACCA84 VA: 0x1ACCA84
	internal static TimeZoneInfo.AdjustmentRule CreateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TimeZoneInfo.TransitionTime daylightTransitionStart, TimeZoneInfo.TransitionTime daylightTransitionEnd, TimeSpan baseUtcOffsetDelta) { }

	// RVA: 0x1AD6F18 Offset: 0x1AD6F18 VA: 0x1AD6F18
	private static void ValidateAdjustmentRule(DateTime dateStart, DateTime dateEnd, TimeSpan daylightDelta, TimeZoneInfo.TransitionTime daylightTransitionStart, TimeZoneInfo.TransitionTime daylightTransitionEnd) { }

	// RVA: 0x1AD74F4 Offset: 0x1AD74F4 VA: 0x1AD74F4 Slot: 6
	private void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender) { }

	// RVA: 0x1AD76BC Offset: 0x1AD76BC VA: 0x1AD76BC Slot: 5
	private void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) { }

	// RVA: 0x1AD78C8 Offset: 0x1AD78C8 VA: 0x1AD78C8
	private void .ctor(SerializationInfo info, StreamingContext context) { }
}
