using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.Scripting;
using UnityEngine.XR.OpenXR.Input;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x02000069 RID: 105
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OculusTouchControllerProfile : OpenXRInteractionFeature
    {
        public OculusTouchControllerProfile() : base(ClassInjector.DerivedConstructorPointer<OculusTouchControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public OculusTouchControllerProfile(IntPtr ptr) : base(ptr) { }
        // Token: 0x06000375 RID: 885 RVA: 0x0000B668 File Offset: 0x00009868
        protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<OculusTouchControllerProfile.OculusTouchController>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Oculus Touch Controller OpenXR", true)));
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000B6AC File Offset: 0x000098AC
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("OculusTouchController");
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000B6B8 File Offset: 0x000098B8
		protected override string GetDeviceLayoutName()
		{
			return "OculusTouchController";
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000B6C0 File Offset: 0x000098C0
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "oculustouchcontroller",
				localizedName = "Oculus Touch Controller OpenXR",
				desiredInteractionProfile = "/interaction_profiles/oculus/touch_controller",
				manufacturer = "Oculus",
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/system/click",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/right"
								}
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
								interactionPath = "/input/x/click",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/click",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/right"
								}
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
								interactionPath = "/input/x/touch",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/touch",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/right"
								}
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
								interactionPath = "/input/y/click",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/click",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/right"
								}
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
								interactionPath = "/input/y/touch",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/touch",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller",
								userPaths = new List<string>
								{
									"/user/hand/right"
								}
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbrestTouched",
						localizedName = "Thumbrest Touched",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"ThumbrestTouch"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumbrest/touch",
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
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
								interactionProfileName = "/interaction_profiles/oculus/touch_controller"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x04000352 RID: 850
		public const string featureId = "com.unity.openxr.feature.input.oculustouch";

		// Token: 0x04000353 RID: 851
		public const string profile = "/interaction_profiles/oculus/touch_controller";

		// Token: 0x04000354 RID: 852
		public const string buttonX = "/input/x/click";

		// Token: 0x04000355 RID: 853
		public const string buttonXTouch = "/input/x/touch";

		// Token: 0x04000356 RID: 854
		public const string buttonY = "/input/y/click";

		// Token: 0x04000357 RID: 855
		public const string buttonYTouch = "/input/y/touch";

		// Token: 0x04000358 RID: 856
		public const string menu = "/input/menu/click";

		// Token: 0x04000359 RID: 857
		public const string buttonA = "/input/a/click";

		// Token: 0x0400035A RID: 858
		public const string buttonATouch = "/input/a/touch";

		// Token: 0x0400035B RID: 859
		public const string buttonB = "/input/b/click";

		// Token: 0x0400035C RID: 860
		public const string buttonBTouch = "/input/b/touch";

		// Token: 0x0400035D RID: 861
		public const string system = "/input/system/click";

		// Token: 0x0400035E RID: 862
		public const string squeeze = "/input/squeeze/value";

		// Token: 0x0400035F RID: 863
		public const string trigger = "/input/trigger/value";

		// Token: 0x04000360 RID: 864
		public const string triggerTouch = "/input/trigger/touch";

		// Token: 0x04000361 RID: 865
		public const string thumbstick = "/input/thumbstick";

		// Token: 0x04000362 RID: 866
		public const string thumbstickClick = "/input/thumbstick/click";

		// Token: 0x04000363 RID: 867
		public const string thumbstickTouch = "/input/thumbstick/touch";

		// Token: 0x04000364 RID: 868
		public const string thumbrest = "/input/thumbrest/touch";

		// Token: 0x04000365 RID: 869
		public const string grip = "/input/grip/pose";

		// Token: 0x04000366 RID: 870
		public const string aim = "/input/aim/pose";

		// Token: 0x04000367 RID: 871
		public const string haptic = "/output/haptic";

		// Token: 0x04000368 RID: 872
		private const string kDeviceLocalizedName = "Oculus Touch Controller OpenXR";

		// Token: 0x0200006A RID: 106
		//[InputControlLayout(displayName = "Oculus Touch Controller (OpenXR)", commonUsages = new string[]
		//{
		//	"LeftHand",
		//	"RightHand"
		//})]
		//[Preserve]
		public class OculusTouchController : XRControllerWithRumble
		{
			// Token: 0x170000EC RID: 236
			// (get) Token: 0x0600037A RID: 890 RVA: 0x0000BFF4 File Offset: 0x0000A1F4
			// (set) Token: 0x0600037B RID: 891 RVA: 0x0000BFFC File Offset: 0x0000A1FC
			//[InputControl(aliases = new string[]
			//{
			//	"Primary2DAxis",
			//	"Joystick"
			//}, usage = "Primary2DAxis")]
			//[Preserve]
			public StickControl thumbstick { get; private set; }

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x0600037C RID: 892 RVA: 0x0000C005 File Offset: 0x0000A205
			// (set) Token: 0x0600037D RID: 893 RVA: 0x0000C00D File Offset: 0x0000A20D
			//[InputControl(aliases = new string[]
			//{
			//	"GripAxis",
			//	"squeeze"
			//}, usage = "Grip")]
			//[Preserve]
			public AxisControl grip { get; private set; }

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x0600037E RID: 894 RVA: 0x0000C016 File Offset: 0x0000A216
			// (set) Token: 0x0600037F RID: 895 RVA: 0x0000C01E File Offset: 0x0000A21E
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"GripButton",
			//	"squeezeClicked"
			//}, usage = "GripButton")]
			public ButtonControl gripPressed { get; private set; }

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x06000380 RID: 896 RVA: 0x0000C027 File Offset: 0x0000A227
			// (set) Token: 0x06000381 RID: 897 RVA: 0x0000C02F File Offset: 0x0000A22F
			//[InputControl(aliases = new string[]
			//{
			//	"Primary",
			//	"menuButton",
			//	"systemButton"
			//}, usage = "MenuButton")]
			//[Preserve]
			public ButtonControl menu { get; private set; }

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x06000382 RID: 898 RVA: 0x0000C038 File Offset: 0x0000A238
			// (set) Token: 0x06000383 RID: 899 RVA: 0x0000C040 File Offset: 0x0000A240
			//[InputControl(aliases = new string[]
			//{
			//	"A",
			//	"X",
			//	"buttonA",
			//	"buttonX"
			//}, usage = "PrimaryButton")]
			//[Preserve]
			public ButtonControl primaryButton { get; private set; }

			// Token: 0x170000F1 RID: 241
			// (get) Token: 0x06000384 RID: 900 RVA: 0x0000C049 File Offset: 0x0000A249
			// (set) Token: 0x06000385 RID: 901 RVA: 0x0000C051 File Offset: 0x0000A251
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"ATouched",
			//	"XTouched",
			//	"ATouch",
			//	"XTouch",
			//	"buttonATouched",
			//	"buttonXTouched"
			//}, usage = "PrimaryTouch")]
			public ButtonControl primaryTouched { get; private set; }

			// Token: 0x170000F2 RID: 242
			// (get) Token: 0x06000386 RID: 902 RVA: 0x0000C05A File Offset: 0x0000A25A
			// (set) Token: 0x06000387 RID: 903 RVA: 0x0000C062 File Offset: 0x0000A262
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"B",
			//	"Y",
			//	"buttonB",
			//	"buttonY"
			//}, usage = "SecondaryButton")]
			public ButtonControl secondaryButton { get; private set; }

			// Token: 0x170000F3 RID: 243
			// (get) Token: 0x06000388 RID: 904 RVA: 0x0000C06B File Offset: 0x0000A26B
			// (set) Token: 0x06000389 RID: 905 RVA: 0x0000C073 File Offset: 0x0000A273
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"BTouched",
			//	"YTouched",
			//	"BTouch",
			//	"YTouch",
			//	"buttonBTouched",
			//	"buttonYTouched"
			//}, usage = "SecondaryTouch")]
			public ButtonControl secondaryTouched { get; private set; }

			// Token: 0x170000F4 RID: 244
			// (get) Token: 0x0600038A RID: 906 RVA: 0x0000C07C File Offset: 0x0000A27C
			// (set) Token: 0x0600038B RID: 907 RVA: 0x0000C084 File Offset: 0x0000A284
			//[InputControl(usage = "Trigger")]
			//[Preserve]
			public AxisControl trigger { get; private set; }

			// Token: 0x170000F5 RID: 245
			// (get) Token: 0x0600038C RID: 908 RVA: 0x0000C08D File Offset: 0x0000A28D
			// (set) Token: 0x0600038D RID: 909 RVA: 0x0000C095 File Offset: 0x0000A295
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"indexButton",
			//	"indexTouched",
			//	"triggerbutton"
			//}, usage = "TriggerButton")]
			public ButtonControl triggerPressed { get; private set; }

			// Token: 0x170000F6 RID: 246
			// (get) Token: 0x0600038E RID: 910 RVA: 0x0000C09E File Offset: 0x0000A29E
			// (set) Token: 0x0600038F RID: 911 RVA: 0x0000C0A6 File Offset: 0x0000A2A6
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"indexTouch",
			//	"indexNearTouched"
			//}, usage = "TriggerTouch")]
			public ButtonControl triggerTouched { get; private set; }

			// Token: 0x170000F7 RID: 247
			// (get) Token: 0x06000390 RID: 912 RVA: 0x0000C0AF File Offset: 0x0000A2AF
			// (set) Token: 0x06000391 RID: 913 RVA: 0x0000C0B7 File Offset: 0x0000A2B7
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"JoystickOrPadPressed",
			//	"thumbstickClick",
			//	"joystickClicked"
			//}, usage = "Primary2DAxisClick")]
			public ButtonControl thumbstickClicked { get; private set; }

			// Token: 0x170000F8 RID: 248
			// (get) Token: 0x06000392 RID: 914 RVA: 0x0000C0C0 File Offset: 0x0000A2C0
			// (set) Token: 0x06000393 RID: 915 RVA: 0x0000C0C8 File Offset: 0x0000A2C8
			//[Preserve]
			//[InputControl(aliases = new string[]
			//{
			//	"JoystickOrPadTouched",
			//	"thumbstickTouch",
			//	"joystickTouched"
			//}, usage = "Primary2DAxisTouch")]
			public ButtonControl thumbstickTouched { get; private set; }

			// Token: 0x170000F9 RID: 249
			// (get) Token: 0x06000394 RID: 916 RVA: 0x0000C0D1 File Offset: 0x0000A2D1
			// (set) Token: 0x06000395 RID: 917 RVA: 0x0000C0D9 File Offset: 0x0000A2D9
			//[InputControl(usage = "ThumbrestTouch")]
			//[Preserve]
			public ButtonControl thumbrestTouched { get; private set; }

			// Token: 0x170000FA RID: 250
			// (get) Token: 0x06000396 RID: 918 RVA: 0x0000C0E2 File Offset: 0x0000A2E2
			// (set) Token: 0x06000397 RID: 919 RVA: 0x0000C0EA File Offset: 0x0000A2EA
			//[Preserve]
			//[InputControl(offset = 0U, aliases = new string[]
			//{
			//	"device",
			//	"gripPose"
			//}, usage = "Device")]
			public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x06000398 RID: 920 RVA: 0x0000C0F3 File Offset: 0x0000A2F3
			// (set) Token: 0x06000399 RID: 921 RVA: 0x0000C0FB File Offset: 0x0000A2FB
			//[Preserve]
			//[InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
			public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x0600039A RID: 922 RVA: 0x0000C104 File Offset: 0x0000A304
			// (set) Token: 0x0600039B RID: 923 RVA: 0x0000C10C File Offset: 0x0000A30C
			//[InputControl(offset = 28U, usage = "IsTracked")]
			//[Preserve]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x0600039C RID: 924 RVA: 0x0000C115 File Offset: 0x0000A315
			// (set) Token: 0x0600039D RID: 925 RVA: 0x0000C11D File Offset: 0x0000A31D
			//[InputControl(offset = 32U, usage = "TrackingState")]
			//[Preserve]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x170000FE RID: 254
			// (get) Token: 0x0600039E RID: 926 RVA: 0x0000C126 File Offset: 0x0000A326
			// (set) Token: 0x0600039F RID: 927 RVA: 0x0000C12E File Offset: 0x0000A32E
			//[InputControl(offset = 36U, noisy = true, alias = "gripPosition")]
			//[Preserve]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x170000FF RID: 255
			// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000C137 File Offset: 0x0000A337
			// (set) Token: 0x060003A1 RID: 929 RVA: 0x0000C13F File Offset: 0x0000A33F
			//[Preserve]
			//[InputControl(offset = 48U, noisy = true, alias = "gripOrientation")]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x17000100 RID: 256
			// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000C148 File Offset: 0x0000A348
			// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000C150 File Offset: 0x0000A350
			//[InputControl(offset = 96U)]
			//[Preserve]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x17000101 RID: 257
			// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000C159 File Offset: 0x0000A359
			// (set) Token: 0x060003A5 RID: 933 RVA: 0x0000C161 File Offset: 0x0000A361
			//[InputControl(offset = 108U, alias = "pointerOrientation")]
			//[Preserve]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000C16A File Offset: 0x0000A36A
			// (set) Token: 0x060003A7 RID: 935 RVA: 0x0000C172 File Offset: 0x0000A372
			//[InputControl(usage = "Haptic")]
			//[Preserve]
			public HapticControl haptic { get; private set; }

			// Token: 0x060003A8 RID: 936 RVA: 0x0000C17C File Offset: 0x0000A37C
			public override void FinishSetup()
			{
				base.FinishSetup();
				this.thumbstick = base.GetChildControl<StickControl>("thumbstick");
				this.trigger = base.GetChildControl<AxisControl>("trigger");
				this.triggerPressed = base.GetChildControl<ButtonControl>("triggerPressed");
				this.triggerTouched = base.GetChildControl<ButtonControl>("triggerTouched");
				this.grip = base.GetChildControl<AxisControl>("grip");
				this.gripPressed = base.GetChildControl<ButtonControl>("gripPressed");
				this.menu = base.GetChildControl<ButtonControl>("menu");
				this.primaryButton = base.GetChildControl<ButtonControl>("primaryButton");
				this.primaryTouched = base.GetChildControl<ButtonControl>("primaryTouched");
				this.secondaryButton = base.GetChildControl<ButtonControl>("secondaryButton");
				this.secondaryTouched = base.GetChildControl<ButtonControl>("secondaryTouched");
				this.thumbstickClicked = base.GetChildControl<ButtonControl>("thumbstickClicked");
				this.thumbstickTouched = base.GetChildControl<ButtonControl>("thumbstickTouched");
				this.thumbrestTouched = base.GetChildControl<ButtonControl>("thumbrestTouched");
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
