// Namespace: 
private abstract class RemoteCharacterController.Command<TCommand> : RemoteCharacterController.ICommand, IDisposable // TypeDefIndex: 12631
{
	// Fields
	[CompilerGeneratedAttribute] // RVA: 0x579384 Offset: 0x579384 VA: 0x579384
	private float <EndTime>k__BackingField; // 0x0

	// Properties
	public float EndTime { get; set; }

	// Methods

	[CompilerGeneratedAttribute] // RVA: 0x667F40 Offset: 0x667F40 VA: 0x667F40
	// RVA: -1 Offset: -1 Slot: 4
	public float get_EndTime() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1042844 Offset: 0x1042844 VA: 0x1042844
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ChangePoseInWall>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_IntoWallSpace>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOn>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOver>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpace>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpaceByWindow>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LerpPos>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_PoseUpdate>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_StateUpdate>.get_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ThrowRope>.get_EndTime
	|-RemoteCharacterController.Command<object>.get_EndTime
	*/

	[CompilerGeneratedAttribute] // RVA: 0x667F50 Offset: 0x667F50 VA: 0x667F50
	// RVA: -1 Offset: -1 Slot: 5
	public void set_EndTime(float value) { }
	/* GenericInstMethod :
	|
	|-RVA: 0x104284C Offset: 0x104284C VA: 0x104284C
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ChangePoseInWall>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_IntoWallSpace>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOn>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOver>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpace>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpaceByWindow>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LerpPos>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_PoseUpdate>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_StateUpdate>.set_EndTime
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ThrowRope>.set_EndTime
	|-RemoteCharacterController.Command<object>.set_EndTime
	*/

	// RVA: -1 Offset: -1 Slot: 10
	public abstract void Start(RemoteCharacterController self);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-RemoteCharacterController.Command<object>.Start
	*/

	// RVA: -1 Offset: -1 Slot: 11
	public abstract void End(RemoteCharacterController self);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-RemoteCharacterController.Command<object>.End
	*/

	// RVA: -1 Offset: -1 Slot: 12
	public abstract void EndDirectly(RemoteCharacterController self);
	/* GenericInstMethod :
	|
	|-RVA: -1 Offset: -1
	|-RemoteCharacterController.Command<object>.EndDirectly
	*/

	// RVA: -1 Offset: -1
	public static TCommand Create() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1042854 Offset: 0x1042854 VA: 0x1042854
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ChangePoseInWall>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_IntoWallSpace>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOn>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_JumpOver>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpace>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LeaveWallSpaceByWindow>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_LerpPos>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_PoseUpdate>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_StateUpdate>.Create
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_ThrowRope>.Create
	|-RemoteCharacterController.Command<object>.Create
	*/

	// RVA: -1 Offset: -1 Slot: 13
	public virtual void Dispose() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1042920 Offset: 0x1042920 VA: 0x1042920
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_IntoWallSpace>.Dispose
	|-RemoteCharacterController.Command<object>.Dispose
	*/

	// RVA: -1 Offset: -1
	protected void .ctor() { }
	/* GenericInstMethod :
	|
	|-RVA: 0x1042A60 Offset: 0x1042A60 VA: 0x1042A60
	|-RemoteCharacterController.Command<RemoteCharacterController.Command_IntoWallSpace>..ctor
	|-RemoteCharacterController.Command<object>..ctor
	*/
}
