// Namespace: 
[FlagsAttribute] // RVA: 0x558F90 Offset: 0x558F90 VA: 0x558F90
public enum AkEventPlayableBehavior.AkPlayableAction // TypeDefIndex: 6063
{
	// Fields
	public int value__; // 0x0
	public const AkEventPlayableBehavior.AkPlayableAction None = 0;
	public const AkEventPlayableBehavior.AkPlayableAction Playback = 1;
	public const AkEventPlayableBehavior.AkPlayableAction Retrigger = 2;
	public const AkEventPlayableBehavior.AkPlayableAction Stop = 4;
	public const AkEventPlayableBehavior.AkPlayableAction DelayedStop = 8;
	public const AkEventPlayableBehavior.AkPlayableAction Seek = 16;
	public const AkEventPlayableBehavior.AkPlayableAction FadeIn = 32;
	public const AkEventPlayableBehavior.AkPlayableAction FadeOut = 64;
}
