using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Input;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x0200006E RID: 110
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class ValveIndexControllerProfile : OpenXRInteractionFeature
    {
        public ValveIndexControllerProfile() : base(ClassInjector.DerivedConstructorPointer<ValveIndexControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public ValveIndexControllerProfile(IntPtr ptr) : base(ptr) { }
        // Token: 0x060003C7 RID: 967 RVA: 0x0000C654 File Offset: 0x0000A854
        protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<ValveIndexControllerProfile.ValveIndexController>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Index Controller OpenXR", true)));
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000C698 File Offset: 0x0000A898
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("ValveIndexController");
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000C6A4 File Offset: 0x0000A8A4
		protected override string GetDeviceLayoutName()
		{
			return "ValveIndexController";
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000C6AC File Offset: 0x0000A8AC
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "valveindexcontroller",
				localizedName = "Index Controller OpenXR",
				desiredInteractionProfile = "/interaction_profiles/valve/index_controller",
				manufacturer = "Valve",
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
						name = "system",
						localizedName = "System",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"MenuButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/system/click",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "systemTouched",
						localizedName = "System Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"MenuTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/system/touch",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "primaryButton",
						localizedName = "Primary Button",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PrimaryButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/click",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "primaryTouched",
						localizedName = "Primary Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"PrimaryTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/touch",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "secondaryButton",
						localizedName = "Secondary Button",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"SecondaryButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/click",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "secondaryTouched",
						localizedName = "Secondary Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"SecondaryTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/touch",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionPath = "/input/squeeze/value",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionPath = "/input/squeeze/value",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "gripForce",
						localizedName = "Grip Force",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"GripForce"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/squeeze/force",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerPressed",
						localizedName = "Triggger Pressed",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"TriggerButton"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/click",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerTouched",
						localizedName = "Trigger Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"TriggerTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/touch",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbstick",
						localizedName = "Thumbstick",
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbstickClicked",
						localizedName = "Thumbstick Clicked",
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbstickTouched",
						localizedName = "Thumbstick Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"Primary2DAxisTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumbstick/touch",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "trackpad",
						localizedName = "Trackpad",
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "trackpadForce",
						localizedName = "Trackpad Force",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"Secondary2DAxisForce"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trackpad/force",
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "trackpadTouched",
						localizedName = "Trackpad Touched",
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
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
								interactionProfileName = "/interaction_profiles/valve/index_controller"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x04000390 RID: 912
		public const string featureId = "com.unity.openxr.feature.input.valveindex";

		// Token: 0x04000391 RID: 913
		public const string profile = "/interaction_profiles/valve/index_controller";

		// Token: 0x04000392 RID: 914
		public const string system = "/input/system/click";

		// Token: 0x04000393 RID: 915
		public const string systemTouch = "/input/system/touch";

		// Token: 0x04000394 RID: 916
		public const string buttonA = "/input/a/click";

		// Token: 0x04000395 RID: 917
		public const string buttonATouch = "/input/a/touch";

		// Token: 0x04000396 RID: 918
		public const string buttonB = "/input/b/click";

		// Token: 0x04000397 RID: 919
		public const string buttonBTouch = "/input/b/touch";

		// Token: 0x04000398 RID: 920
		public const string squeeze = "/input/squeeze/value";

		// Token: 0x04000399 RID: 921
		public const string squeezeForce = "/input/squeeze/force";

		// Token: 0x0400039A RID: 922
		public const string triggerClick = "/input/trigger/click";

		// Token: 0x0400039B RID: 923
		public const string trigger = "/input/trigger/value";

		// Token: 0x0400039C RID: 924
		public const string triggerTouch = "/input/trigger/touch";

		// Token: 0x0400039D RID: 925
		public const string thumbstick = "/input/thumbstick";

		// Token: 0x0400039E RID: 926
		public const string thumbstickClick = "/input/thumbstick/click";

		// Token: 0x0400039F RID: 927
		public const string thumbstickTouch = "/input/thumbstick/touch";

		// Token: 0x040003A0 RID: 928
		public const string trackpad = "/input/trackpad";

		// Token: 0x040003A1 RID: 929
		public const string trackpadForce = "/input/trackpad/force";

		// Token: 0x040003A2 RID: 930
		public const string trackpadTouch = "/input/trackpad/touch";

		// Token: 0x040003A3 RID: 931
		public const string grip = "/input/grip/pose";

		// Token: 0x040003A4 RID: 932
		public const string aim = "/input/aim/pose";

		// Token: 0x040003A5 RID: 933
		public const string haptic = "/output/haptic";

		// Token: 0x040003A6 RID: 934
		private const string kDeviceLocalizedName = "Index Controller OpenXR";

		// Token: 0x0200006F RID: 111
		[InputControlLayout(displayName = "Index Controller (OpenXR)", commonUsages = new string[]
		{
			"LeftHand",
			"RightHand"
		})]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        //[Preserve]
        public class ValveIndexController : XRControllerWithRumble
		{
			// Token: 0x1700010B RID: 267
			// (get) Token: 0x060003CC RID: 972 RVA: 0x0000D007 File Offset: 0x0000B207
			// (set) Token: 0x060003CD RID: 973 RVA: 0x0000D00F File Offset: 0x0000B20F
			[InputControl(alias = "systemButton", usage = "MenuButton")]
			//[Preserve]
			public ButtonControl system { get; private set; }

			// Token: 0x1700010C RID: 268
			// (get) Token: 0x060003CE RID: 974 RVA: 0x0000D018 File Offset: 0x0000B218
			// (set) Token: 0x060003CF RID: 975 RVA: 0x0000D020 File Offset: 0x0000B220
			[InputControl(usage = "MenuTouch")]
			//[Preserve]
			public ButtonControl systemTouched { get; private set; }

			// Token: 0x1700010D RID: 269
			// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000D029 File Offset: 0x0000B229
			// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000D031 File Offset: 0x0000B231
			//[Preserve]
			[InputControl(usage = "PrimaryButton")]
			public ButtonControl primaryButton { get; private set; }

			// Token: 0x1700010E RID: 270
			// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000D03A File Offset: 0x0000B23A
			// (set) Token: 0x060003D3 RID: 979 RVA: 0x0000D042 File Offset: 0x0000B242
			[InputControl(usage = "PrimaryTouch")]
			//[Preserve]
			public ButtonControl primaryTouched { get; private set; }

			// Token: 0x1700010F RID: 271
			// (get) Token: 0x060003D4 RID: 980 RVA: 0x0000D04B File Offset: 0x0000B24B
			// (set) Token: 0x060003D5 RID: 981 RVA: 0x0000D053 File Offset: 0x0000B253
			[InputControl(usage = "SecondaryButton")]
			//[Preserve]
			public ButtonControl secondaryButton { get; private set; }

			// Token: 0x17000110 RID: 272
			// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000D05C File Offset: 0x0000B25C
			// (set) Token: 0x060003D7 RID: 983 RVA: 0x0000D064 File Offset: 0x0000B264
			[InputControl(usage = "SecondaryTouch")]
			//[Preserve]
			public ButtonControl secondaryTouched { get; private set; }

			// Token: 0x17000111 RID: 273
			// (get) Token: 0x060003D8 RID: 984 RVA: 0x0000D06D File Offset: 0x0000B26D
			// (set) Token: 0x060003D9 RID: 985 RVA: 0x0000D075 File Offset: 0x0000B275
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripAxis",
				"squeeze"
			}, usage = "Grip")]
			public AxisControl grip { get; private set; }

			// Token: 0x17000112 RID: 274
			// (get) Token: 0x060003DA RID: 986 RVA: 0x0000D07E File Offset: 0x0000B27E
			// (set) Token: 0x060003DB RID: 987 RVA: 0x0000D086 File Offset: 0x0000B286
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripButton",
				"squeezeClicked"
			}, usage = "GripButton")]
			public ButtonControl gripPressed { get; private set; }

			// Token: 0x17000113 RID: 275
			// (get) Token: 0x060003DC RID: 988 RVA: 0x0000D08F File Offset: 0x0000B28F
			// (set) Token: 0x060003DD RID: 989 RVA: 0x0000D097 File Offset: 0x0000B297
			//[Preserve]
			[InputControl(alias = "squeezeForce", usage = "GripForce")]
			public AxisControl gripForce { get; private set; }

			// Token: 0x17000114 RID: 276
			// (get) Token: 0x060003DE RID: 990 RVA: 0x0000D0A0 File Offset: 0x0000B2A0
			// (set) Token: 0x060003DF RID: 991 RVA: 0x0000D0A8 File Offset: 0x0000B2A8
			[InputControl(usage = "Trigger")]
			//[Preserve]
			public AxisControl trigger { get; private set; }

			// Token: 0x17000115 RID: 277
			// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000D0B1 File Offset: 0x0000B2B1
			// (set) Token: 0x060003E1 RID: 993 RVA: 0x0000D0B9 File Offset: 0x0000B2B9
			[InputControl(usage = "TriggerButton")]
			//[Preserve]
			public ButtonControl triggerPressed { get; private set; }

			// Token: 0x17000116 RID: 278
			// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000D0C2 File Offset: 0x0000B2C2
			// (set) Token: 0x060003E3 RID: 995 RVA: 0x0000D0CA File Offset: 0x0000B2CA
			[InputControl(usage = "TriggerTouch")]
			//[Preserve]
			public ButtonControl triggerTouched { get; private set; }

			// Token: 0x17000117 RID: 279
			// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000D0D3 File Offset: 0x0000B2D3
			// (set) Token: 0x060003E5 RID: 997 RVA: 0x0000D0DB File Offset: 0x0000B2DB
			[InputControl(aliases = new string[]
			{
				"joystick",
				"Primary2DAxis"
			}, usage = "Primary2DAxis")]
			//[Preserve]
			public StickControl thumbstick { get; private set; }

			// Token: 0x17000118 RID: 280
			// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000D0E4 File Offset: 0x0000B2E4
			// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000D0EC File Offset: 0x0000B2EC
			[InputControl(alias = "joystickClicked", usage = "Primary2DAxisClick")]
			//[Preserve]
			public ButtonControl thumbstickClicked { get; private set; }

			// Token: 0x17000119 RID: 281
			// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0000D0F5 File Offset: 0x0000B2F5
			// (set) Token: 0x060003E9 RID: 1001 RVA: 0x0000D0FD File Offset: 0x0000B2FD
			[InputControl(alias = "joystickTouched", usage = "Primary2DAxisTouch")]
			//[Preserve]
			public ButtonControl thumbstickTouched { get; private set; }

			// Token: 0x1700011A RID: 282
			// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000D106 File Offset: 0x0000B306
			// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000D10E File Offset: 0x0000B30E
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"touchpad",
				"Secondary2DAxis"
			}, usage = "Secondary2DAxis")]
			public StickControl trackpad { get; private set; }

			// Token: 0x1700011B RID: 283
			// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000D117 File Offset: 0x0000B317
			// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000D11F File Offset: 0x0000B31F
			[InputControl(alias = "touchpadTouched", usage = "Secondary2DAxisTouch")]
			//[Preserve]
			public ButtonControl trackpadTouched { get; private set; }

			// Token: 0x1700011C RID: 284
			// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000D128 File Offset: 0x0000B328
			// (set) Token: 0x060003EF RID: 1007 RVA: 0x0000D130 File Offset: 0x0000B330
			//[Preserve]
			[InputControl(alias = "touchpadForce", usage = "Secondary2DAxisForce")]
			public AxisControl trackpadForce { get; private set; }

			// Token: 0x1700011D RID: 285
			// (get) Token: 0x060003F0 RID: 1008 RVA: 0x0000D139 File Offset: 0x0000B339
			// (set) Token: 0x060003F1 RID: 1009 RVA: 0x0000D141 File Offset: 0x0000B341
			[InputControl(offset = 0U, aliases = new string[]
			{
				"device",
				"gripPose"
			}, usage = "Device")]
			//[Preserve]
			public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

			// Token: 0x1700011E RID: 286
			// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000D14A File Offset: 0x0000B34A
			// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000D152 File Offset: 0x0000B352
			[InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
			//[Preserve]
			public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

			// Token: 0x1700011F RID: 287
			// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000D15B File Offset: 0x0000B35B
			// (set) Token: 0x060003F5 RID: 1013 RVA: 0x0000D163 File Offset: 0x0000B363
			[InputControl(offset = 53U)]
			//[Preserve]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x17000120 RID: 288
			// (get) Token: 0x060003F6 RID: 1014 RVA: 0x0000D16C File Offset: 0x0000B36C
			// (set) Token: 0x060003F7 RID: 1015 RVA: 0x0000D174 File Offset: 0x0000B374
			//[Preserve]
			[InputControl(offset = 56U)]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x17000121 RID: 289
			// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000D17D File Offset: 0x0000B37D
			// (set) Token: 0x060003F9 RID: 1017 RVA: 0x0000D185 File Offset: 0x0000B385
			//[Preserve]
			[InputControl(offset = 60U, alias = "gripPosition")]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x17000122 RID: 290
			// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000D18E File Offset: 0x0000B38E
			// (set) Token: 0x060003FB RID: 1019 RVA: 0x0000D196 File Offset: 0x0000B396
			[InputControl(offset = 72U, alias = "gripOrientation")]
			//[Preserve]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x17000123 RID: 291
			// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000D19F File Offset: 0x0000B39F
			// (set) Token: 0x060003FD RID: 1021 RVA: 0x0000D1A7 File Offset: 0x0000B3A7
			[InputControl(offset = 120U)]
			//[Preserve]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x17000124 RID: 292
			// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
			// (set) Token: 0x060003FF RID: 1023 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
			[InputControl(offset = 132U, alias = "pointerOrientation")]
			//[Preserve]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x17000125 RID: 293
			// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000D1C1 File Offset: 0x0000B3C1
			// (set) Token: 0x06000401 RID: 1025 RVA: 0x0000D1C9 File Offset: 0x0000B3C9
			//[Preserve]
			[InputControl(usage = "Haptic")]
			public HapticControl haptic { get; private set; }

			// Token: 0x06000402 RID: 1026 RVA: 0x0000D1D4 File Offset: 0x0000B3D4
			public override void FinishSetup()
			{
				base.FinishSetup();
				this.system = base.GetChildControl<ButtonControl>("system");
				this.systemTouched = base.GetChildControl<ButtonControl>("systemTouched");
				this.primaryButton = base.GetChildControl<ButtonControl>("primaryButton");
				this.primaryTouched = base.GetChildControl<ButtonControl>("primaryTouched");
				this.secondaryButton = base.GetChildControl<ButtonControl>("secondaryButton");
				this.secondaryTouched = base.GetChildControl<ButtonControl>("secondaryTouched");
				this.grip = base.GetChildControl<AxisControl>("grip");
				this.gripPressed = base.GetChildControl<ButtonControl>("gripPressed");
				this.gripForce = base.GetChildControl<AxisControl>("gripForce");
				this.trigger = base.GetChildControl<AxisControl>("trigger");
				this.triggerPressed = base.GetChildControl<ButtonControl>("triggerPressed");
				this.triggerTouched = base.GetChildControl<ButtonControl>("triggerTouched");
				this.thumbstick = base.GetChildControl<StickControl>("thumbstick");
				this.thumbstickClicked = base.GetChildControl<ButtonControl>("thumbstickClicked");
				this.thumbstickTouched = base.GetChildControl<ButtonControl>("thumbstickTouched");
				this.trackpad = base.GetChildControl<StickControl>("trackpad");
				this.trackpadTouched = base.GetChildControl<ButtonControl>("trackpadTouched");
				this.trackpadForce = base.GetChildControl<AxisControl>("trackpadForce");
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
