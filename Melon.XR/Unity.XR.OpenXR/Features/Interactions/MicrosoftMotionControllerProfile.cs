using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using System.Collections.Generic;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Input;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x02000067 RID: 103
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class MicrosoftMotionControllerProfile : OpenXRInteractionFeature
    {
        public MicrosoftMotionControllerProfile() : base(ClassInjector.DerivedConstructorPointer<MicrosoftMotionControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public MicrosoftMotionControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x06000348 RID: 840 RVA: 0x0000AD68 File Offset: 0x00008F68
        protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<MicrosoftMotionControllerProfile.WMRSpatialController>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Windows MR Controller OpenXR", true)));
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000ADAC File Offset: 0x00008FAC
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("WMRSpatialController");
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000ADB8 File Offset: 0x00008FB8
		protected override string GetDeviceLayoutName()
		{
			return "WMRSpatialController";
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000ADC0 File Offset: 0x00008FC0
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "microsoftmotioncontroller",
				localizedName = "Windows MR Controller OpenXR",
				desiredInteractionProfile = "/interaction_profiles/microsoft/motion_controller",
				manufacturer = "Microsoft",
				serialNumber = "",
				deviceInfos = new List<OpenXRInteractionFeature.DeviceConfig>
				{
					new OpenXRInteractionFeature.DeviceConfig
					{
						characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left),
						userPath = "/user/hand/left"
					},
					new OpenXRInteractionFeature.DeviceConfig
					{
						characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right),
						userPath = "/user/hand/right"
					}
				},
				actions = new List<OpenXRInteractionFeature.ActionConfig>
				{
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "joystick",
						localizedName = "Joystick",
						type = OpenXRInteractionFeature.ActionType.Axis2D,
						usages = new List<string>
						{
							"Primary2DAxis"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumbstick",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "touchpad",
						localizedName = "Touchpad",
						type = OpenXRInteractionFeature.ActionType.Axis2D,
						usages = new List<string>
						{
							"Secondary2DAxis"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trackpad",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "grip",
						localizedName = "Grip",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"Grip"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/squeeze/click",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "gripPressed",
						localizedName = "Grip Pressed",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"GripButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/squeeze/click",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "menu",
						localizedName = "Menu",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"MenuButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/menu/click",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "trigger",
						localizedName = "Trigger",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"Trigger"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/value",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerPressed",
						localizedName = "Trigger Pressed",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"TriggerButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/value",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "joystickClicked",
						localizedName = "JoystickClicked",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"Primary2DAxisClick"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumbstick/click",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "touchpadClicked",
						localizedName = "Touchpad Clicked",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"Secondary2DAxisClick"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trackpad/click",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "touchpadTouched",
						localizedName = "Touchpad Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"Secondary2DAxisTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trackpad/touch",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "devicePose",
						localizedName = "Device Pose",
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
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
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
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "haptic",
						localizedName = "Haptic Output",
						type = OpenXRInteractionFeature.ActionType.Vibrate,
						usages = new List<string>
						{
							"Haptic"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/output/haptic",
								interactionProfileName = "/interaction_profiles/microsoft/motion_controller"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x04000331 RID: 817
		public const string featureId = "com.unity.openxr.feature.input.microsoftmotioncontroller";

		// Token: 0x04000332 RID: 818
		public const string profile = "/interaction_profiles/microsoft/motion_controller";

		// Token: 0x04000333 RID: 819
		public const string menu = "/input/menu/click";

		// Token: 0x04000334 RID: 820
		public const string squeeze = "/input/squeeze/click";

		// Token: 0x04000335 RID: 821
		public const string trigger = "/input/trigger/value";

		// Token: 0x04000336 RID: 822
		public const string thumbstick = "/input/thumbstick";

		// Token: 0x04000337 RID: 823
		public const string thumbstickClick = "/input/thumbstick/click";

		// Token: 0x04000338 RID: 824
		public const string trackpad = "/input/trackpad";

		// Token: 0x04000339 RID: 825
		public const string trackpadClick = "/input/trackpad/click";

		// Token: 0x0400033A RID: 826
		public const string trackpadTouch = "/input/trackpad/touch";

		// Token: 0x0400033B RID: 827
		public const string grip = "/input/grip/pose";

		// Token: 0x0400033C RID: 828
		public const string aim = "/input/aim/pose";

		// Token: 0x0400033D RID: 829
		public const string haptic = "/output/haptic";

		// Token: 0x0400033E RID: 830
		private const string kDeviceLocalizedName = "Windows MR Controller OpenXR";

		// Token: 0x02000068 RID: 104
		//[Preserve]
		[InputControlLayout(displayName = "Windows MR Controller (OpenXR)", commonUsages = new string[]
		{
			"LeftHand",
			"RightHand"
		})]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class WMRSpatialController : XRControllerWithRumble
		{
			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x0600034D RID: 845 RVA: 0x0000B3CB File Offset: 0x000095CB
			// (set) Token: 0x0600034E RID: 846 RVA: 0x0000B3D3 File Offset: 0x000095D3
			[InputControl(aliases = new string[]
			{
				"Primary2DAxis",
				"thumbstickaxes",
				"thumbstick"
			}, usage = "Primary2DAxis")]
			//[Preserve]
			public StickControl joystick { get; private set; }

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x0600034F RID: 847 RVA: 0x0000B3DC File Offset: 0x000095DC
			// (set) Token: 0x06000350 RID: 848 RVA: 0x0000B3E4 File Offset: 0x000095E4
			[InputControl(aliases = new string[]
			{
				"Secondary2DAxis",
				"touchpadaxes",
				"trackpad"
			}, usage = "Secondary2DAxis")]
			//[Preserve]
			public StickControl touchpad { get; private set; }

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000351 RID: 849 RVA: 0x0000B3ED File Offset: 0x000095ED
			// (set) Token: 0x06000352 RID: 850 RVA: 0x0000B3F5 File Offset: 0x000095F5
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"gripaxis",
				"squeeze"
			}, usage = "Grip")]
			public AxisControl grip { get; private set; }

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x06000353 RID: 851 RVA: 0x0000B3FE File Offset: 0x000095FE
			// (set) Token: 0x06000354 RID: 852 RVA: 0x0000B406 File Offset: 0x00009606
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripButton",
				"squeezeClicked"
			}, usage = "GripButton")]
			public ButtonControl gripPressed { get; private set; }

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x06000355 RID: 853 RVA: 0x0000B40F File Offset: 0x0000960F
			// (set) Token: 0x06000356 RID: 854 RVA: 0x0000B417 File Offset: 0x00009617
			[InputControl(aliases = new string[]
			{
				"Primary",
				"menubutton"
			}, usage = "MenuButton")]
			//[Preserve]
			public ButtonControl menu { get; private set; }

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x06000357 RID: 855 RVA: 0x0000B420 File Offset: 0x00009620
			// (set) Token: 0x06000358 RID: 856 RVA: 0x0000B428 File Offset: 0x00009628
			[InputControl(aliases = new string[]
			{
				"triggeraxis"
			}, usage = "Trigger")]
			//[Preserve]
			public AxisControl trigger { get; private set; }

			// Token: 0x170000DF RID: 223
			// (get) Token: 0x06000359 RID: 857 RVA: 0x0000B431 File Offset: 0x00009631
			// (set) Token: 0x0600035A RID: 858 RVA: 0x0000B439 File Offset: 0x00009639
			[InputControl(alias = "triggerbutton", usage = "TriggerButton")]
			//[Preserve]
			public ButtonControl triggerPressed { get; private set; }

			// Token: 0x170000E0 RID: 224
			// (get) Token: 0x0600035B RID: 859 RVA: 0x0000B442 File Offset: 0x00009642
			// (set) Token: 0x0600035C RID: 860 RVA: 0x0000B44A File Offset: 0x0000964A
			[InputControl(aliases = new string[]
			{
				"joystickClicked",
				"thumbstickpressed"
			}, usage = "Primary2DAxisClick")]
			//[Preserve]
			public ButtonControl joystickClicked { get; private set; }

			// Token: 0x170000E1 RID: 225
			// (get) Token: 0x0600035D RID: 861 RVA: 0x0000B453 File Offset: 0x00009653
			// (set) Token: 0x0600035E RID: 862 RVA: 0x0000B45B File Offset: 0x0000965B
			[InputControl(aliases = new string[]
			{
				"joystickorpadpressed",
				"touchpadpressed",
				"trackpadClicked"
			}, usage = "Secondary2DAxisClick")]
			//[Preserve]
			public ButtonControl touchpadClicked { get; private set; }

			// Token: 0x170000E2 RID: 226
			// (get) Token: 0x0600035F RID: 863 RVA: 0x0000B464 File Offset: 0x00009664
			// (set) Token: 0x06000360 RID: 864 RVA: 0x0000B46C File Offset: 0x0000966C
			[InputControl(aliases = new string[]
			{
				"joystickorpadtouched",
				"touchpadtouched",
				"trackpadTouched"
			}, usage = "Secondary2DAxisTouch")]
			//[Preserve]
			public ButtonControl touchpadTouched { get; private set; }

			// Token: 0x170000E3 RID: 227
			// (get) Token: 0x06000361 RID: 865 RVA: 0x0000B475 File Offset: 0x00009675
			// (set) Token: 0x06000362 RID: 866 RVA: 0x0000B47D File Offset: 0x0000967D
			[InputControl(offset = 0U, aliases = new string[]
			{
				"device",
				"gripPose"
			}, usage = "Device")]
			//[Preserve]
			public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

			// Token: 0x170000E4 RID: 228
			// (get) Token: 0x06000363 RID: 867 RVA: 0x0000B486 File Offset: 0x00009686
			// (set) Token: 0x06000364 RID: 868 RVA: 0x0000B48E File Offset: 0x0000968E
			//[Preserve]
			[InputControl(offset = 0U, aliases = new string[]
			{
				"aimPose"
			}, usage = "Pointer")]
			public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

			// Token: 0x170000E5 RID: 229
			// (get) Token: 0x06000365 RID: 869 RVA: 0x0000B497 File Offset: 0x00009697
			// (set) Token: 0x06000366 RID: 870 RVA: 0x0000B49F File Offset: 0x0000969F
			[InputControl(offset = 32U)]
			//[Preserve]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x170000E6 RID: 230
			// (get) Token: 0x06000367 RID: 871 RVA: 0x0000B4A8 File Offset: 0x000096A8
			// (set) Token: 0x06000368 RID: 872 RVA: 0x0000B4B0 File Offset: 0x000096B0
			[InputControl(offset = 36U)]
			//[Preserve]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x170000E7 RID: 231
			// (get) Token: 0x06000369 RID: 873 RVA: 0x0000B4B9 File Offset: 0x000096B9
			// (set) Token: 0x0600036A RID: 874 RVA: 0x0000B4C1 File Offset: 0x000096C1
			[InputControl(offset = 40U, aliases = new string[]
			{
				"gripPosition"
			})]
			//[Preserve]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x170000E8 RID: 232
			// (get) Token: 0x0600036B RID: 875 RVA: 0x0000B4CA File Offset: 0x000096CA
			// (set) Token: 0x0600036C RID: 876 RVA: 0x0000B4D2 File Offset: 0x000096D2
			//[Preserve]
			[InputControl(offset = 52U, aliases = new string[]
			{
				"gripOrientation"
			})]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x170000E9 RID: 233
			// (get) Token: 0x0600036D RID: 877 RVA: 0x0000B4DB File Offset: 0x000096DB
			// (set) Token: 0x0600036E RID: 878 RVA: 0x0000B4E3 File Offset: 0x000096E3
			//[Preserve]
			[InputControl(offset = 100U)]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x170000EA RID: 234
			// (get) Token: 0x0600036F RID: 879 RVA: 0x0000B4EC File Offset: 0x000096EC
			// (set) Token: 0x06000370 RID: 880 RVA: 0x0000B4F4 File Offset: 0x000096F4
			//[Preserve]
			[InputControl(offset = 112U, aliases = new string[]
			{
				"pointerOrientation"
			})]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x06000371 RID: 881 RVA: 0x0000B4FD File Offset: 0x000096FD
			// (set) Token: 0x06000372 RID: 882 RVA: 0x0000B505 File Offset: 0x00009705
			[InputControl(usage = "Haptic")]
			//[Preserve]
			public HapticControl haptic { get; private set; }

			// Token: 0x06000373 RID: 883 RVA: 0x0000B510 File Offset: 0x00009710
			public override void FinishSetup()
			{
				base.FinishSetup();
				this.joystick = base.GetChildControl<StickControl>("joystick");
				this.trigger = base.GetChildControl<AxisControl>("trigger");
				this.touchpad = base.GetChildControl<StickControl>("touchpad");
				this.grip = base.GetChildControl<AxisControl>("grip");
				this.gripPressed = base.GetChildControl<ButtonControl>("gripPressed");
				this.menu = base.GetChildControl<ButtonControl>("menu");
				this.joystickClicked = base.GetChildControl<ButtonControl>("joystickClicked");
				this.triggerPressed = base.GetChildControl<ButtonControl>("triggerPressed");
				this.touchpadClicked = base.GetChildControl<ButtonControl>("touchpadClicked");
				this.touchpadTouched = base.GetChildControl<ButtonControl>("touchPadTouched");
				this.devicePose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("devicePose");
				this.pointer = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pointer");
				this.isTracked = base.GetChildControl<ButtonControl>("isTracked");
				this.trackingState = base.GetChildControl<IntegerControl>("trackingState");
				this.devicePosition = base.GetChildControl<Vector3Control>("devicePosition");
				this.deviceRotation = base.GetChildControl<QuaternionControl>("deviceRotation");
				this.pointerPosition = base.GetChildControl<Vector3Control>("pointerPosition");
				this.pointerRotation = base.GetChildControl<QuaternionControl>("pointerRotation");
				this.haptic = base.GetChildControl<HapticControl>("haptic");
			}
		}
	}
}
