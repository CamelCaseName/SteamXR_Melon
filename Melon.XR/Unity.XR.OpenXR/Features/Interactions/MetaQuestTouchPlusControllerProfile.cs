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
    // Token: 0x02000061 RID: 97
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class MetaQuestTouchPlusControllerProfile : OpenXRInteractionFeature
    {
        public MetaQuestTouchPlusControllerProfile() : base(ClassInjector.DerivedConstructorPointer<MetaQuestTouchPlusControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public MetaQuestTouchPlusControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x060002A3 RID: 675 RVA: 0x0000878E File Offset: 0x0000698E
        protected internal override bool OnInstanceCreate(ulong instance)
		{
			return OpenXRRuntime.IsExtensionEnabled("XR_META_touch_controller_plus") && base.OnInstanceCreate(instance);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000087A8 File Offset: 0x000069A8
		protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<MetaQuestTouchPlusControllerProfile.QuestTouchPlusController>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Meta Quest Touch Plus Controller OpenXR", true)));
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000087EC File Offset: 0x000069EC
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("QuestTouchPlusController");
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000087F8 File Offset: 0x000069F8
		protected override string GetDeviceLayoutName()
		{
			return "QuestTouchPlusController";
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00008800 File Offset: 0x00006A00
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "questtouchpluscontroller",
				localizedName = "Meta Quest Touch Plus Controller OpenXR",
				desiredInteractionProfile = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/system/click",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/click",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/touch",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/click",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/touch",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus",
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
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
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerForce",
						localizedName = "Trigger Force",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"TriggerForce"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/force",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerCurl",
						localizedName = "Trigger Curl",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"TriggerCurl"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/curl_meta",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerSlide",
						localizedName = "Trigger Slide",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"TriggerSlide"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/slide_meta",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "triggerProximity",
						localizedName = "Trigger Proximity",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"TriggerProximity"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/trigger/proximity_meta",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbProximity",
						localizedName = "Thumb Proximity",
						type = OpenXRInteractionFeature.ActionType.Binary,
						usages = new List<string>
						{
							"ThumbProximity"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumb_meta/proximity_meta",
								interactionProfileName = "/interaction_profiles/meta/touch_controller_plus"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x040002A7 RID: 679
		public const string featureId = "com.unity.openxr.feature.input.metaquestplus";

		// Token: 0x040002A8 RID: 680
		public const string profile = "/interaction_profiles/meta/touch_controller_plus";

		// Token: 0x040002A9 RID: 681
		public const string buttonX = "/input/x/click";

		// Token: 0x040002AA RID: 682
		public const string buttonXTouch = "/input/x/touch";

		// Token: 0x040002AB RID: 683
		public const string buttonY = "/input/y/click";

		// Token: 0x040002AC RID: 684
		public const string buttonYTouch = "/input/y/touch";

		// Token: 0x040002AD RID: 685
		public const string menu = "/input/menu/click";

		// Token: 0x040002AE RID: 686
		public const string buttonA = "/input/a/click";

		// Token: 0x040002AF RID: 687
		public const string buttonATouch = "/input/a/touch";

		// Token: 0x040002B0 RID: 688
		public const string buttonB = "/input/b/click";

		// Token: 0x040002B1 RID: 689
		public const string buttonBTouch = "/input/b/touch";

		// Token: 0x040002B2 RID: 690
		public const string system = "/input/system/click";

		// Token: 0x040002B3 RID: 691
		public const string squeeze = "/input/squeeze/value";

		// Token: 0x040002B4 RID: 692
		public const string trigger = "/input/trigger/value";

		// Token: 0x040002B5 RID: 693
		public const string triggerTouch = "/input/trigger/touch";

		// Token: 0x040002B6 RID: 694
		public const string thumbstick = "/input/thumbstick";

		// Token: 0x040002B7 RID: 695
		public const string thumbstickClick = "/input/thumbstick/click";

		// Token: 0x040002B8 RID: 696
		public const string thumbstickTouch = "/input/thumbstick/touch";

		// Token: 0x040002B9 RID: 697
		public const string thumbrest = "/input/thumbrest/touch";

		// Token: 0x040002BA RID: 698
		public const string grip = "/input/grip/pose";

		// Token: 0x040002BB RID: 699
		public const string aim = "/input/aim/pose";

		// Token: 0x040002BC RID: 700
		public const string haptic = "/output/haptic";

		// Token: 0x040002BD RID: 701
		public const string triggerForce = "/input/trigger/force";

		// Token: 0x040002BE RID: 702
		public const string triggerCurl = "/input/trigger/curl_meta";

		// Token: 0x040002BF RID: 703
		public const string triggerSlide = "/input/trigger/slide_meta";

		// Token: 0x040002C0 RID: 704
		public const string triggerProximity = "/input/trigger/proximity_meta";

		// Token: 0x040002C1 RID: 705
		public const string thumbProximity = "/input/thumb_meta/proximity_meta";

		// Token: 0x040002C2 RID: 706
		private const string kDeviceLocalizedName = "Meta Quest Touch Plus Controller OpenXR";

		// Token: 0x02000062 RID: 98
		[InputControlLayout(displayName = "Meta Quest Touch Plus Controller(OpenXR)", commonUsages = new string[]
		{
			"LeftHand",
			"RightHand"
		})]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        //[Preserve]
        public class QuestTouchPlusController : XRControllerWithRumble
		{
			// Token: 0x17000092 RID: 146
			// (get) Token: 0x060002A9 RID: 681 RVA: 0x00009346 File Offset: 0x00007546
			// (set) Token: 0x060002AA RID: 682 RVA: 0x0000934E File Offset: 0x0000754E
			[InputControl(aliases = new string[]
			{
				"Primary2DAxis",
				"Joystick"
			}, usage = "Primary2DAxis")]
			//[Preserve]
			public StickControl thumbstick { get; private set; }

			// Token: 0x17000093 RID: 147
			// (get) Token: 0x060002AB RID: 683 RVA: 0x00009357 File Offset: 0x00007557
			// (set) Token: 0x060002AC RID: 684 RVA: 0x0000935F File Offset: 0x0000755F
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripAxis",
				"squeeze"
			}, usage = "Grip")]
			public AxisControl grip { get; private set; }

			// Token: 0x17000094 RID: 148
			// (get) Token: 0x060002AD RID: 685 RVA: 0x00009368 File Offset: 0x00007568
			// (set) Token: 0x060002AE RID: 686 RVA: 0x00009370 File Offset: 0x00007570
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripButton",
				"squeezeClicked"
			}, usage = "GripButton")]
			public ButtonControl gripPressed { get; private set; }

			// Token: 0x17000095 RID: 149
			// (get) Token: 0x060002AF RID: 687 RVA: 0x00009379 File Offset: 0x00007579
			// (set) Token: 0x060002B0 RID: 688 RVA: 0x00009381 File Offset: 0x00007581
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"Primary",
				"menuButton",
				"systemButton"
			}, usage = "MenuButton")]
			public ButtonControl menu { get; private set; }

			// Token: 0x17000096 RID: 150
			// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000938A File Offset: 0x0000758A
			// (set) Token: 0x060002B2 RID: 690 RVA: 0x00009392 File Offset: 0x00007592
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"A",
				"X",
				"buttonA",
				"buttonX"
			}, usage = "PrimaryButton")]
			public ButtonControl primaryButton { get; private set; }

			// Token: 0x17000097 RID: 151
			// (get) Token: 0x060002B3 RID: 691 RVA: 0x0000939B File Offset: 0x0000759B
			// (set) Token: 0x060002B4 RID: 692 RVA: 0x000093A3 File Offset: 0x000075A3
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"ATouched",
				"XTouched",
				"ATouch",
				"XTouch",
				"buttonATouched",
				"buttonXTouched"
			}, usage = "PrimaryTouch")]
			public ButtonControl primaryTouched { get; private set; }

			// Token: 0x17000098 RID: 152
			// (get) Token: 0x060002B5 RID: 693 RVA: 0x000093AC File Offset: 0x000075AC
			// (set) Token: 0x060002B6 RID: 694 RVA: 0x000093B4 File Offset: 0x000075B4
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"B",
				"Y",
				"buttonB",
				"buttonY"
			}, usage = "SecondaryButton")]
			public ButtonControl secondaryButton { get; private set; }

			// Token: 0x17000099 RID: 153
			// (get) Token: 0x060002B7 RID: 695 RVA: 0x000093BD File Offset: 0x000075BD
			// (set) Token: 0x060002B8 RID: 696 RVA: 0x000093C5 File Offset: 0x000075C5
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"BTouched",
				"YTouched",
				"BTouch",
				"YTouch",
				"buttonBTouched",
				"buttonYTouched"
			}, usage = "SecondaryTouch")]
			public ButtonControl secondaryTouched { get; private set; }

			// Token: 0x1700009A RID: 154
			// (get) Token: 0x060002B9 RID: 697 RVA: 0x000093CE File Offset: 0x000075CE
			// (set) Token: 0x060002BA RID: 698 RVA: 0x000093D6 File Offset: 0x000075D6
			//[Preserve]
			[InputControl(usage = "Trigger")]
			public AxisControl trigger { get; private set; }

			// Token: 0x1700009B RID: 155
			// (get) Token: 0x060002BB RID: 699 RVA: 0x000093DF File Offset: 0x000075DF
			// (set) Token: 0x060002BC RID: 700 RVA: 0x000093E7 File Offset: 0x000075E7
			[InputControl(aliases = new string[]
			{
				"indexButton",
				"indexTouched",
				"triggerbutton"
			}, usage = "TriggerButton")]
			//[Preserve]
			public ButtonControl triggerPressed { get; private set; }

			// Token: 0x1700009C RID: 156
			// (get) Token: 0x060002BD RID: 701 RVA: 0x000093F0 File Offset: 0x000075F0
			// (set) Token: 0x060002BE RID: 702 RVA: 0x000093F8 File Offset: 0x000075F8
			[InputControl(aliases = new string[]
			{
				"indexTouch",
				"indexNearTouched"
			}, usage = "TriggerTouch")]
			//[Preserve]
			public ButtonControl triggerTouched { get; private set; }

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x060002BF RID: 703 RVA: 0x00009401 File Offset: 0x00007601
			// (set) Token: 0x060002C0 RID: 704 RVA: 0x00009409 File Offset: 0x00007609
			[InputControl(aliases = new string[]
			{
				"JoystickOrPadPressed",
				"thumbstickClick",
				"joystickClicked"
			}, usage = "Primary2DAxisClick")]
			//[Preserve]
			public ButtonControl thumbstickClicked { get; private set; }

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x060002C1 RID: 705 RVA: 0x00009412 File Offset: 0x00007612
			// (set) Token: 0x060002C2 RID: 706 RVA: 0x0000941A File Offset: 0x0000761A
			[InputControl(aliases = new string[]
			{
				"JoystickOrPadTouched",
				"thumbstickTouch",
				"joystickTouched"
			}, usage = "Primary2DAxisTouch")]
			//[Preserve]
			public ButtonControl thumbstickTouched { get; private set; }

			// Token: 0x1700009F RID: 159
			// (get) Token: 0x060002C3 RID: 707 RVA: 0x00009423 File Offset: 0x00007623
			// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000942B File Offset: 0x0000762B
			//[Preserve]
			[InputControl(usage = "ThumbrestTouch")]
			public ButtonControl thumbrestTouched { get; private set; }

			// Token: 0x170000A0 RID: 160
			// (get) Token: 0x060002C5 RID: 709 RVA: 0x00009434 File Offset: 0x00007634
			// (set) Token: 0x060002C6 RID: 710 RVA: 0x0000943C File Offset: 0x0000763C
			//[Preserve]
			[InputControl(offset = 0U, aliases = new string[]
			{
				"device",
				"gripPose"
			}, usage = "Device")]
			public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

			// Token: 0x170000A1 RID: 161
			// (get) Token: 0x060002C7 RID: 711 RVA: 0x00009445 File Offset: 0x00007645
			// (set) Token: 0x060002C8 RID: 712 RVA: 0x0000944D File Offset: 0x0000764D
			//[Preserve]
			[InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
			public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x060002C9 RID: 713 RVA: 0x00009456 File Offset: 0x00007656
			// (set) Token: 0x060002CA RID: 714 RVA: 0x0000945E File Offset: 0x0000765E
			//[Preserve]
			[InputControl(offset = 28U, usage = "IsTracked")]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x060002CB RID: 715 RVA: 0x00009467 File Offset: 0x00007667
			// (set) Token: 0x060002CC RID: 716 RVA: 0x0000946F File Offset: 0x0000766F
			//[Preserve]
			[InputControl(offset = 32U, usage = "TrackingState")]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x060002CD RID: 717 RVA: 0x00009478 File Offset: 0x00007678
			// (set) Token: 0x060002CE RID: 718 RVA: 0x00009480 File Offset: 0x00007680
			//[Preserve]
			[InputControl(offset = 36U, noisy = true, alias = "gripPosition")]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x170000A5 RID: 165
			// (get) Token: 0x060002CF RID: 719 RVA: 0x00009489 File Offset: 0x00007689
			// (set) Token: 0x060002D0 RID: 720 RVA: 0x00009491 File Offset: 0x00007691
			//[Preserve]
			[InputControl(offset = 48U, noisy = true, alias = "gripOrientation")]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x170000A6 RID: 166
			// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000949A File Offset: 0x0000769A
			// (set) Token: 0x060002D2 RID: 722 RVA: 0x000094A2 File Offset: 0x000076A2
			[InputControl(offset = 96U)]
			//[Preserve]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x060002D3 RID: 723 RVA: 0x000094AB File Offset: 0x000076AB
			// (set) Token: 0x060002D4 RID: 724 RVA: 0x000094B3 File Offset: 0x000076B3
			//[Preserve]
			[InputControl(offset = 108U, alias = "pointerOrientation")]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x170000A8 RID: 168
			// (get) Token: 0x060002D5 RID: 725 RVA: 0x000094BC File Offset: 0x000076BC
			// (set) Token: 0x060002D6 RID: 726 RVA: 0x000094C4 File Offset: 0x000076C4
			//[Preserve]
			[InputControl(usage = "Haptic")]
			public HapticControl haptic { get; private set; }

			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x060002D7 RID: 727 RVA: 0x000094CD File Offset: 0x000076CD
			// (set) Token: 0x060002D8 RID: 728 RVA: 0x000094D5 File Offset: 0x000076D5
			[InputControl(usage = "TriggerForce")]
			//[Preserve]
			public AxisControl triggerForce { get; private set; }

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x060002D9 RID: 729 RVA: 0x000094DE File Offset: 0x000076DE
			// (set) Token: 0x060002DA RID: 730 RVA: 0x000094E6 File Offset: 0x000076E6
			[InputControl(usage = "TriggerCurl")]
			//[Preserve]
			public AxisControl triggerCurl { get; private set; }

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x060002DB RID: 731 RVA: 0x000094EF File Offset: 0x000076EF
			// (set) Token: 0x060002DC RID: 732 RVA: 0x000094F7 File Offset: 0x000076F7
			//[Preserve]
			[InputControl(usage = "TriggerSlide")]
			public AxisControl triggerSlide { get; private set; }

			// Token: 0x170000AC RID: 172
			// (get) Token: 0x060002DD RID: 733 RVA: 0x00009500 File Offset: 0x00007700
			// (set) Token: 0x060002DE RID: 734 RVA: 0x00009508 File Offset: 0x00007708
			[InputControl(usage = "TriggerProximity")]
			//[Preserve]
			public ButtonControl triggerProximity { get; private set; }

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x060002DF RID: 735 RVA: 0x00009511 File Offset: 0x00007711
			// (set) Token: 0x060002E0 RID: 736 RVA: 0x00009519 File Offset: 0x00007719
			//[Preserve]
			[InputControl(usage = "ThumbProximity")]
			public ButtonControl thumbProximity { get; private set; }

			// Token: 0x060002E1 RID: 737 RVA: 0x00009524 File Offset: 0x00007724
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
				this.triggerForce = base.GetChildControl<AxisControl>("triggerForce");
				this.triggerCurl = base.GetChildControl<AxisControl>("triggerCurl");
				this.triggerSlide = base.GetChildControl<AxisControl>("triggerSlide");
				this.triggerProximity = base.GetChildControl<ButtonControl>("triggerProximity");
				this.thumbProximity = base.GetChildControl<ButtonControl>("thumbProximity");
			}
		}
	}
}
