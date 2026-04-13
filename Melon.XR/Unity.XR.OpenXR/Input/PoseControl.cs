using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;

namespace UnityEngine.XR.OpenXR.Input
{
	// Token: 0x02000041 RID: 65
	[Obsolete("OpenXR.Input.PoseControl is deprecated. Please use UnityEngine.InputSystem.XR.PoseControl instead.", false)]
	public class PoseControl : InputControl<Pose>
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00005041 File Offset: 0x00003241
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00005049 File Offset: 0x00003249
		//[Preserve]
		[InputControl(offset = 0U)]
		public ButtonControl isTracked { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005052 File Offset: 0x00003252
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000505A File Offset: 0x0000325A
		[InputControl(offset = 4U)]
		//[Preserve]
		public IntegerControl trackingState { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00005063 File Offset: 0x00003263
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000506B File Offset: 0x0000326B
		[InputControl(offset = 8U, noisy = true)]
		//[Preserve]
		public Vector3Control position { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00005074 File Offset: 0x00003274
		// (set) Token: 0x0600014A RID: 330 RVA: 0x0000507C File Offset: 0x0000327C
		//[Preserve]
		[InputControl(offset = 20U, noisy = true)]
		public QuaternionControl rotation { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00005085 File Offset: 0x00003285
		// (set) Token: 0x0600014C RID: 332 RVA: 0x0000508D File Offset: 0x0000328D
		//[Preserve]
		[InputControl(offset = 36U, noisy = true)]
		public Vector3Control velocity { get; private set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00005096 File Offset: 0x00003296
		// (set) Token: 0x0600014E RID: 334 RVA: 0x0000509E File Offset: 0x0000329E
		//[Preserve]
		[InputControl(offset = 48U, noisy = true)]
		public Vector3Control angularVelocity { get; private set; }

		// Token: 0x06000150 RID: 336 RVA: 0x000050B0 File Offset: 0x000032B0
		public override void FinishSetup()
		{
			this.isTracked = base.GetChildControl<ButtonControl>("isTracked");
			this.trackingState = base.GetChildControl<IntegerControl>("trackingState");
			this.position = base.GetChildControl<Vector3Control>("position");
			this.rotation = base.GetChildControl<QuaternionControl>("rotation");
			this.velocity = base.GetChildControl<Vector3Control>("velocity");
			this.angularVelocity = base.GetChildControl<Vector3Control>("angularVelocity");
			base.FinishSetup();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000512C File Offset: 0x0000332C
		public unsafe override Pose ReadUnprocessedValueFromState(void* statePtr)
		{
			return new Pose()
			{
				isTracked = (this.isTracked.ReadUnprocessedValueFromState(statePtr) > 0.5f),
				trackingState = (InputTrackingState)this.trackingState.ReadUnprocessedValueFromState(statePtr),
				position = this.position.ReadUnprocessedValueFromState(statePtr),
				rotation = this.rotation.ReadUnprocessedValueFromState(statePtr),
				velocity = this.velocity.ReadUnprocessedValueFromState(statePtr),
				angularVelocity = this.angularVelocity.ReadUnprocessedValueFromState(statePtr)
			};
		}

		// Token: 0x06000152 RID: 338 RVA: 0x000051BC File Offset: 0x000033BC
		public unsafe override void WriteValueIntoState(Pose value, void* statePtr)
		{
			this.isTracked.WriteValueIntoState(value.isTracked, statePtr);
			this.trackingState.WriteValueIntoState((uint)value.trackingState, statePtr);
			this.position.WriteValueIntoState(value.position, statePtr);
			this.rotation.WriteValueIntoState(value.rotation, statePtr);
			this.velocity.WriteValueIntoState(value.velocity, statePtr);
			this.angularVelocity.WriteValueIntoState(value.angularVelocity, statePtr);
		}
	}
}
