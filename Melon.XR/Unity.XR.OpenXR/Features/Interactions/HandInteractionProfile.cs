using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using System.Collections.Generic;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x02000059 RID: 89
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class HandInteractionProfile : OpenXRInteractionFeature
    {
        public HandInteractionProfile() : base(ClassInjector.DerivedConstructorPointer<HandInteractionProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public HandInteractionProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x060001F9 RID: 505 RVA: 0x0000622C File Offset: 0x0000442C
        protected internal override bool OnInstanceCreate(ulong instance)
		{
			return OpenXRRuntime.IsExtensionEnabled("XR_EXT_hand_interaction") && base.OnInstanceCreate(instance);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000067B8 File Offset: 0x000049B8
		protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<HandInteractionProfile.HandInteraction>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Hand Interaction OpenXR", true)));
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000067FC File Offset: 0x000049FC
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("HandInteraction");
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00006808 File Offset: 0x00004A08
		protected override string GetDeviceLayoutName()
		{
			return "HandInteraction";
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00006810 File Offset: 0x00004A10
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "handinteraction",
				localizedName = "Hand Interaction OpenXR",
				desiredInteractionProfile = "/interaction_profiles/ext/hand_interaction_ext",
				manufacturer = "",
				serialNumber = "",
				deviceInfos = new List<OpenXRInteractionFeature.DeviceConfig>
				{
					new OpenXRInteractionFeature.DeviceConfig
					{
						characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left),
						userPath = "/user/hand/left"
					},
					new OpenXRInteractionFeature.DeviceConfig
					{
						characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Right),
						userPath = "/user/hand/right"
					}
				},
				actions = new List<OpenXRInteractionFeature.ActionConfig>
				{
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "devicePose",
						localizedName = "Grip Pose",
						type = OpenXRInteractionFeature.ActionType.Pose,
						usages = new List<string>
						{
							"Device"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/grip/pose",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "pointer",
						localizedName = "Pointer Pose",
						type = OpenXRInteractionFeature.ActionType.Pose,
						usages = new List<string>
						{
							"Pointer"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/aim/pose",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PokePose",
						localizedName = "Poke Pose",
						type = OpenXRInteractionFeature.ActionType.Pose,
						usages = new List<string>
						{
							"Poke"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/poke_ext/pose",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PinchPose",
						localizedName = "Pinch Pose",
						type = OpenXRInteractionFeature.ActionType.Pose,
						usages = new List<string>
						{
							"Pinch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/pinch_ext/pose",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PinchValue",
						localizedName = "Pinch Value",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"PinchValue"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/pinch_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PinchTouched",
						localizedName = "Pinch Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PinchTouched"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/pinch_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PinchReady",
						localizedName = "Pinch Ready",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PinchReady"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/pinch_ext/ready_ext",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PointerActivateValue",
						localizedName = "Pointer Activate Value",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"PointerActivateValue"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/aim_activate_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PointerActivated",
						localizedName = "Pointer Activated",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PointerActivated"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/aim_activate_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "PointerActivateReady",
						localizedName = "Pointer Activate Ready",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PointerActivateReady"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/aim_activate_ext/ready_ext",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "GraspValue",
						localizedName = "Grasp Value",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"GraspValue"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/grasp_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "GraspFirm",
						localizedName = "Grasp Firm",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"GraspFirm"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/grasp_ext/value",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "GraspReady",
						localizedName = "Grasp Ready",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"GraspReady"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/grasp_ext/ready_ext",
								interactionProfileName = "/interaction_profiles/ext/hand_interaction_ext"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x0400022E RID: 558
		public const string featureId = "com.unity.openxr.feature.input.handinteraction";

		// Token: 0x0400022F RID: 559
		public const string profile = "/interaction_profiles/ext/hand_interaction_ext";

		// Token: 0x04000230 RID: 560
		public const string grip = "/input/grip/pose";

		// Token: 0x04000231 RID: 561
		public const string aim = "/input/aim/pose";

		// Token: 0x04000232 RID: 562
		public const string poke = "/input/poke_ext/pose";

		// Token: 0x04000233 RID: 563
		public const string pinch = "/input/pinch_ext/pose";

		// Token: 0x04000234 RID: 564
		public const string pinchValue = "/input/pinch_ext/value";

		// Token: 0x04000235 RID: 565
		public const string pinchReady = "/input/pinch_ext/ready_ext";

		// Token: 0x04000236 RID: 566
		public const string pointerActivateValue = "/input/aim_activate_ext/value";

		// Token: 0x04000237 RID: 567
		public const string pointerActivateReady = "/input/aim_activate_ext/ready_ext";

		// Token: 0x04000238 RID: 568
		public const string graspValue = "/input/grasp_ext/value";

		// Token: 0x04000239 RID: 569
		public const string graspReady = "/input/grasp_ext/ready_ext";

		// Token: 0x0400023A RID: 570
		private const string kDeviceLocalizedName = "Hand Interaction OpenXR";

		// Token: 0x0400023B RID: 571
		public const string extensionString = "XR_EXT_hand_interaction";

		// Token: 0x0200005A RID: 90
		//[Preserve]
		[InputControlLayout(displayName = "Hand Interaction (OpenXR)", commonUsages = new string[]
		{
			"LeftHand",
			"RightHand"
		})]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class HandInteraction : XRController
		{
			// Token: 0x1700004C RID: 76
			// (get) Token: 0x060001FF RID: 511 RVA: 0x00006E1B File Offset: 0x0000501B
			// (set) Token: 0x06000200 RID: 512 RVA: 0x00006E23 File Offset: 0x00005023
			[InputControl(offset = 0U, aliases = new string[]
			{
				"device",
				"gripPose"
			}, usage = "Device")]
			//[Preserve]
			public PoseControl devicePose { get; private set; }

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x06000201 RID: 513 RVA: 0x00006E2C File Offset: 0x0000502C
			// (set) Token: 0x06000202 RID: 514 RVA: 0x00006E34 File Offset: 0x00005034
			//[Preserve]
			[InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
			public PoseControl pointer { get; private set; }

			// Token: 0x1700004E RID: 78
			// (get) Token: 0x06000203 RID: 515 RVA: 0x00006E3D File Offset: 0x0000503D
			// (set) Token: 0x06000204 RID: 516 RVA: 0x00006E45 File Offset: 0x00005045
			//[Preserve]
			[InputControl(offset = 0U, usage = "Poke")]
			public PoseControl pokePose { get; private set; }

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x06000205 RID: 517 RVA: 0x00006E4E File Offset: 0x0000504E
			// (set) Token: 0x06000206 RID: 518 RVA: 0x00006E56 File Offset: 0x00005056
			//[Preserve]
			[InputControl(offset = 0U, usage = "Pinch")]
			public PoseControl pinchPose { get; private set; }

			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000207 RID: 519 RVA: 0x00006E5F File Offset: 0x0000505F
			// (set) Token: 0x06000208 RID: 520 RVA: 0x00006E67 File Offset: 0x00005067
			//[Preserve]
			[InputControl(usage = "PinchValue")]
			public AxisControl pinchValue { get; private set; }

			// Token: 0x17000051 RID: 81
			// (get) Token: 0x06000209 RID: 521 RVA: 0x00006E70 File Offset: 0x00005070
			// (set) Token: 0x0600020A RID: 522 RVA: 0x00006E78 File Offset: 0x00005078
			//[Preserve]
			[InputControl(usage = "PinchTouched")]
			public ButtonControl pinchTouched { get; private set; }

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x0600020B RID: 523 RVA: 0x00006E81 File Offset: 0x00005081
			// (set) Token: 0x0600020C RID: 524 RVA: 0x00006E89 File Offset: 0x00005089
			//[Preserve]
			[InputControl(usage = "PinchReady")]
			public ButtonControl pinchReady { get; private set; }

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x0600020D RID: 525 RVA: 0x00006E92 File Offset: 0x00005092
			// (set) Token: 0x0600020E RID: 526 RVA: 0x00006E9A File Offset: 0x0000509A
			//[Preserve]
			[InputControl(usage = "PointerActivateValue")]
			public AxisControl pointerActivateValue { get; private set; }

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x0600020F RID: 527 RVA: 0x00006EA3 File Offset: 0x000050A3
			// (set) Token: 0x06000210 RID: 528 RVA: 0x00006EAB File Offset: 0x000050AB
			[InputControl(usage = "PointerActivated")]
			//[Preserve]
			public ButtonControl pointerActivated { get; private set; }

			// Token: 0x17000055 RID: 85
			// (get) Token: 0x06000211 RID: 529 RVA: 0x00006EB4 File Offset: 0x000050B4
			// (set) Token: 0x06000212 RID: 530 RVA: 0x00006EBC File Offset: 0x000050BC
			[InputControl(usage = "PointerActivateReady")]
			//[Preserve]
			public ButtonControl pointerActivateReady { get; private set; }

			// Token: 0x17000056 RID: 86
			// (get) Token: 0x06000213 RID: 531 RVA: 0x00006EC5 File Offset: 0x000050C5
			// (set) Token: 0x06000214 RID: 532 RVA: 0x00006ECD File Offset: 0x000050CD
			//[Preserve]
			[InputControl(usage = "GraspValue")]
			public AxisControl graspValue { get; private set; }

			// Token: 0x17000057 RID: 87
			// (get) Token: 0x06000215 RID: 533 RVA: 0x00006ED6 File Offset: 0x000050D6
			// (set) Token: 0x06000216 RID: 534 RVA: 0x00006EDE File Offset: 0x000050DE
			//[Preserve]
			[InputControl(usage = "GraspFirm")]
			public ButtonControl graspFirm { get; private set; }

			// Token: 0x17000058 RID: 88
			// (get) Token: 0x06000217 RID: 535 RVA: 0x00006EE7 File Offset: 0x000050E7
			// (set) Token: 0x06000218 RID: 536 RVA: 0x00006EEF File Offset: 0x000050EF
			[InputControl(usage = "GraspReady")]
			//[Preserve]
			public ButtonControl graspReady { get; private set; }

			// Token: 0x17000059 RID: 89
			// (get) Token: 0x06000219 RID: 537 RVA: 0x00006EF8 File Offset: 0x000050F8
			// (set) Token: 0x0600021A RID: 538 RVA: 0x00006F00 File Offset: 0x00005100
			//[Preserve]
			[InputControl(offset = 2U)]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x1700005A RID: 90
			// (get) Token: 0x0600021B RID: 539 RVA: 0x00006F09 File Offset: 0x00005109
			// (set) Token: 0x0600021C RID: 540 RVA: 0x00006F11 File Offset: 0x00005111
			//[Preserve]
			[InputControl(offset = 4U)]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x1700005B RID: 91
			// (get) Token: 0x0600021D RID: 541 RVA: 0x00006F1A File Offset: 0x0000511A
			// (set) Token: 0x0600021E RID: 542 RVA: 0x00006F22 File Offset: 0x00005122
			//[Preserve]
			[InputControl(offset = 8U, noisy = true, alias = "gripPosition")]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x1700005C RID: 92
			// (get) Token: 0x0600021F RID: 543 RVA: 0x00006F2B File Offset: 0x0000512B
			// (set) Token: 0x06000220 RID: 544 RVA: 0x00006F33 File Offset: 0x00005133
			[InputControl(offset = 20U, noisy = true, alias = "gripRotation")]
			//[Preserve]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x1700005D RID: 93
			// (get) Token: 0x06000221 RID: 545 RVA: 0x00006F3C File Offset: 0x0000513C
			// (set) Token: 0x06000222 RID: 546 RVA: 0x00006F44 File Offset: 0x00005144
			[InputControl(offset = 68U, noisy = true)]
			//[Preserve]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x1700005E RID: 94
			// (get) Token: 0x06000223 RID: 547 RVA: 0x00006F4D File Offset: 0x0000514D
			// (set) Token: 0x06000224 RID: 548 RVA: 0x00006F55 File Offset: 0x00005155
			[InputControl(offset = 80U, noisy = true)]
			//[Preserve]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x1700005F RID: 95
			// (get) Token: 0x06000225 RID: 549 RVA: 0x00006F5E File Offset: 0x0000515E
			// (set) Token: 0x06000226 RID: 550 RVA: 0x00006F66 File Offset: 0x00005166
			[InputControl(offset = 128U, noisy = true)]
			//[Preserve]
			public Vector3Control pokePosition { get; private set; }

			// Token: 0x17000060 RID: 96
			// (get) Token: 0x06000227 RID: 551 RVA: 0x00006F6F File Offset: 0x0000516F
			// (set) Token: 0x06000228 RID: 552 RVA: 0x00006F77 File Offset: 0x00005177
			[InputControl(offset = 140U, noisy = true)]
			//[Preserve]
			public QuaternionControl pokeRotation { get; private set; }

			// Token: 0x17000061 RID: 97
			// (get) Token: 0x06000229 RID: 553 RVA: 0x00006F80 File Offset: 0x00005180
			// (set) Token: 0x0600022A RID: 554 RVA: 0x00006F88 File Offset: 0x00005188
			[InputControl(offset = 188U, noisy = true)]
			//[Preserve]
			public Vector3Control pinchPosition { get; private set; }

			// Token: 0x17000062 RID: 98
			// (get) Token: 0x0600022B RID: 555 RVA: 0x00006F91 File Offset: 0x00005191
			// (set) Token: 0x0600022C RID: 556 RVA: 0x00006F99 File Offset: 0x00005199
			//[Preserve]
			[InputControl(offset = 200U, noisy = true)]
			public QuaternionControl pinchRotation { get; private set; }

			// Token: 0x0600022D RID: 557 RVA: 0x00006FA4 File Offset: 0x000051A4
			public override void FinishSetup()
			{
				base.FinishSetup();
				this.devicePose = base.GetChildControl<PoseControl>("devicePose");
				this.pointer = base.GetChildControl<PoseControl>("pointer");
				this.pokePose = base.GetChildControl<PoseControl>("pokePose");
				this.pinchPose = base.GetChildControl<PoseControl>("pinchPose");
				this.pinchValue = base.GetChildControl<AxisControl>("pinchValue");
				this.pinchTouched = base.GetChildControl<ButtonControl>("pinchTouched");
				this.pinchReady = base.GetChildControl<ButtonControl>("pinchReady");
				this.pointerActivateValue = base.GetChildControl<AxisControl>("pointerActivateValue");
				this.pointerActivated = base.GetChildControl<ButtonControl>("pointerActivated");
				this.pointerActivateReady = base.GetChildControl<ButtonControl>("pointerActivateReady");
				this.graspValue = base.GetChildControl<AxisControl>("graspValue");
				this.graspFirm = base.GetChildControl<ButtonControl>("graspFirm");
				this.graspReady = base.GetChildControl<ButtonControl>("graspReady");
				this.isTracked = base.GetChildControl<ButtonControl>("isTracked");
				this.trackingState = base.GetChildControl<IntegerControl>("trackingState");
				this.devicePosition = base.GetChildControl<Vector3Control>("devicePosition");
				this.deviceRotation = base.GetChildControl<QuaternionControl>("deviceRotation");
				this.pointerPosition = base.GetChildControl<Vector3Control>("pointerPosition");
				this.pointerRotation = base.GetChildControl<QuaternionControl>("pointerRotation");
				this.pokePosition = base.GetChildControl<Vector3Control>("pokePosition");
				this.pokeRotation = base.GetChildControl<QuaternionControl>("pokeRotation");
				this.pinchPosition = base.GetChildControl<Vector3Control>("pinchPosition");
				this.pinchRotation = base.GetChildControl<QuaternionControl>("pinchRotation");
			}
		}
	}
}
