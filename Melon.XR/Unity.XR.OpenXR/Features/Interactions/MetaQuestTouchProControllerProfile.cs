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
    // Token: 0x02000063 RID: 99
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class MetaQuestTouchProControllerProfile : OpenXRInteractionFeature
    {
        public MetaQuestTouchProControllerProfile() : base(ClassInjector.DerivedConstructorPointer<MetaQuestTouchProControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public MetaQuestTouchProControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x060002E3 RID: 739 RVA: 0x00009713 File Offset: 0x00007913
        protected internal override bool OnInstanceCreate(ulong instance)
		{
			return OpenXRRuntime.IsExtensionEnabled("XR_FB_touch_controller_pro") && base.OnInstanceCreate(instance);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000972C File Offset: 0x0000792C
		protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of<MetaQuestTouchProControllerProfile.QuestProTouchController>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Meta Quest Pro Touch Controller OpenXR", true)));
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00009770 File Offset: 0x00007970
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("QuestProTouchController");
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000977C File Offset: 0x0000797C
		protected override string GetDeviceLayoutName()
		{
			return "QuestProTouchController";
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00009784 File Offset: 0x00007984
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "questprotouchcontroller",
				localizedName = "Meta Quest Pro Touch Controller OpenXR",
				desiredInteractionProfile = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/system/click",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/click",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/a/touch",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/click",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
								userPaths = new List<string>
								{
									"/user/hand/left"
								}
							},
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/b/touch",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro",
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "thumbrestForce",
						localizedName = "Thumbrest Force",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"ThumbrestForce"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/thumbrest/force",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "stylusForce",
						localizedName = "Stylus Force",
						type = OpenXRInteractionFeature.ActionType.Axis1D,
						usages = new List<string>
						{
							"StylusForce"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/input/stylus_fb/force",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionPath = "/input/trigger/curl_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionPath = "/input/trigger/slide_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionPath = "/input/trigger/proximity_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
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
								interactionPath = "/input/thumb_fb/proximity_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "hapticTrigger",
						localizedName = "Haptic Trigger Output",
						type = OpenXRInteractionFeature.ActionType.Vibrate,
						usages = new List<string>
						{
							"HapticTrigger"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/output/trigger_haptic_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
							}
						}
					},
					new OpenXRInteractionFeature.ActionConfig
					{
						name = "hapticThumb",
						localizedName = "Haptic Thumb Output",
						type = OpenXRInteractionFeature.ActionType.Vibrate,
						usages = new List<string>
						{
							"HapticThumb"
						},
						bindings = new List<OpenXRInteractionFeature.ActionBinding>
						{
							new OpenXRInteractionFeature.ActionBinding
							{
								interactionPath = "/output/thumb_haptic_fb",
								interactionProfileName = "/interaction_profiles/facebook/touch_controller_pro"
							}
						}
					}
				}
			};
			base.AddActionMap(actionMap);
		}

		// Token: 0x040002DF RID: 735
		public const string featureId = "com.unity.openxr.feature.input.metaquestpro";

		// Token: 0x040002E0 RID: 736
		public const string profile = "/interaction_profiles/facebook/touch_controller_pro";

		// Token: 0x040002E1 RID: 737
		public const string buttonX = "/input/x/click";

		// Token: 0x040002E2 RID: 738
		public const string buttonXTouch = "/input/x/touch";

		// Token: 0x040002E3 RID: 739
		public const string buttonY = "/input/y/click";

		// Token: 0x040002E4 RID: 740
		public const string buttonYTouch = "/input/y/touch";

		// Token: 0x040002E5 RID: 741
		public const string menu = "/input/menu/click";

		// Token: 0x040002E6 RID: 742
		public const string buttonA = "/input/a/click";

		// Token: 0x040002E7 RID: 743
		public const string buttonATouch = "/input/a/touch";

		// Token: 0x040002E8 RID: 744
		public const string buttonB = "/input/b/click";

		// Token: 0x040002E9 RID: 745
		public const string buttonBTouch = "/input/b/touch";

		// Token: 0x040002EA RID: 746
		public const string system = "/input/system/click";

		// Token: 0x040002EB RID: 747
		public const string squeeze = "/input/squeeze/value";

		// Token: 0x040002EC RID: 748
		public const string trigger = "/input/trigger/value";

		// Token: 0x040002ED RID: 749
		public const string triggerTouch = "/input/trigger/touch";

		// Token: 0x040002EE RID: 750
		public const string thumbstick = "/input/thumbstick";

		// Token: 0x040002EF RID: 751
		public const string thumbstickClick = "/input/thumbstick/click";

		// Token: 0x040002F0 RID: 752
		public const string thumbstickTouch = "/input/thumbstick/touch";

		// Token: 0x040002F1 RID: 753
		public const string thumbrest = "/input/thumbrest/touch";

		// Token: 0x040002F2 RID: 754
		public const string grip = "/input/grip/pose";

		// Token: 0x040002F3 RID: 755
		public const string aim = "/input/aim/pose";

		// Token: 0x040002F4 RID: 756
		public const string haptic = "/output/haptic";

		// Token: 0x040002F5 RID: 757
		public const string thumbrestForce = "/input/thumbrest/force";

		// Token: 0x040002F6 RID: 758
		public const string stylusForce = "/input/stylus_fb/force";

		// Token: 0x040002F7 RID: 759
		public const string triggerCurl = "/input/trigger/curl_fb";

		// Token: 0x040002F8 RID: 760
		public const string triggerSlide = "/input/trigger/slide_fb";

		// Token: 0x040002F9 RID: 761
		public const string triggerProximity = "/input/trigger/proximity_fb";

		// Token: 0x040002FA RID: 762
		public const string thumbProximity = "/input/thumb_fb/proximity_fb";

		// Token: 0x040002FB RID: 763
		public const string hapticTrigger = "/output/trigger_haptic_fb";

		// Token: 0x040002FC RID: 764
		public const string hapticThumb = "/output/thumb_haptic_fb";

		// Token: 0x040002FD RID: 765
		private const string kDeviceLocalizedName = "Meta Quest Pro Touch Controller OpenXR";

		// Token: 0x02000064 RID: 100
		//[Preserve]
		[InputControlLayout(displayName = "Meta Quest Pro Touch Controller(OpenXR)", commonUsages = new string[]
		{
			"LeftHand",
			"RightHand"
		})]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class QuestProTouchController : XRControllerWithRumble
		{
			// Token: 0x170000AE RID: 174
			// (get) Token: 0x060002E9 RID: 745 RVA: 0x0000A408 File Offset: 0x00008608
			// (set) Token: 0x060002EA RID: 746 RVA: 0x0000A410 File Offset: 0x00008610
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"Primary2DAxis",
				"Joystick"
			}, usage = "Primary2DAxis")]
			public StickControl thumbstick { get; private set; }

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x060002EB RID: 747 RVA: 0x0000A419 File Offset: 0x00008619
			// (set) Token: 0x060002EC RID: 748 RVA: 0x0000A421 File Offset: 0x00008621
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripAxis",
				"squeeze"
			}, usage = "Grip")]
			public AxisControl grip { get; private set; }

			// Token: 0x170000B0 RID: 176
			// (get) Token: 0x060002ED RID: 749 RVA: 0x0000A42A File Offset: 0x0000862A
			// (set) Token: 0x060002EE RID: 750 RVA: 0x0000A432 File Offset: 0x00008632
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"GripButton",
				"squeezeClicked"
			}, usage = "GripButton")]
			public ButtonControl gripPressed { get; private set; }

			// Token: 0x170000B1 RID: 177
			// (get) Token: 0x060002EF RID: 751 RVA: 0x0000A43B File Offset: 0x0000863B
			// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000A443 File Offset: 0x00008643
			[InputControl(aliases = new string[]
			{
				"Primary",
				"menuButton",
				"systemButton"
			}, usage = "MenuButton")]
			//[Preserve]
			public ButtonControl menu { get; private set; }

			// Token: 0x170000B2 RID: 178
			// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000A44C File Offset: 0x0000864C
			// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000A454 File Offset: 0x00008654
			[InputControl(aliases = new string[]
			{
				"A",
				"X",
				"buttonA",
				"buttonX"
			}, usage = "PrimaryButton")]
			//[Preserve]
			public ButtonControl primaryButton { get; private set; }

			// Token: 0x170000B3 RID: 179
			// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000A45D File Offset: 0x0000865D
			// (set) Token: 0x060002F4 RID: 756 RVA: 0x0000A465 File Offset: 0x00008665
			[InputControl(aliases = new string[]
			{
				"ATouched",
				"XTouched",
				"ATouch",
				"XTouch",
				"buttonATouched",
				"buttonXTouched"
			}, usage = "PrimaryTouch")]
			//[Preserve]
			public ButtonControl primaryTouched { get; private set; }

			// Token: 0x170000B4 RID: 180
			// (get) Token: 0x060002F5 RID: 757 RVA: 0x0000A46E File Offset: 0x0000866E
			// (set) Token: 0x060002F6 RID: 758 RVA: 0x0000A476 File Offset: 0x00008676
			[InputControl(aliases = new string[]
			{
				"B",
				"Y",
				"buttonB",
				"buttonY"
			}, usage = "SecondaryButton")]
			//[Preserve]
			public ButtonControl secondaryButton { get; private set; }

			// Token: 0x170000B5 RID: 181
			// (get) Token: 0x060002F7 RID: 759 RVA: 0x0000A47F File Offset: 0x0000867F
			// (set) Token: 0x060002F8 RID: 760 RVA: 0x0000A487 File Offset: 0x00008687
			[InputControl(aliases = new string[]
			{
				"BTouched",
				"YTouched",
				"BTouch",
				"YTouch",
				"buttonBTouched",
				"buttonYTouched"
			}, usage = "SecondaryTouch")]
			//[Preserve]
			public ButtonControl secondaryTouched { get; private set; }

			// Token: 0x170000B6 RID: 182
			// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000A490 File Offset: 0x00008690
			// (set) Token: 0x060002FA RID: 762 RVA: 0x0000A498 File Offset: 0x00008698
			[InputControl(usage = "Trigger")]
			//[Preserve]
			public AxisControl trigger { get; private set; }

			// Token: 0x170000B7 RID: 183
			// (get) Token: 0x060002FB RID: 763 RVA: 0x0000A4A1 File Offset: 0x000086A1
			// (set) Token: 0x060002FC RID: 764 RVA: 0x0000A4A9 File Offset: 0x000086A9
			[InputControl(aliases = new string[]
			{
				"indexButton",
				"indexTouched",
				"triggerbutton"
			}, usage = "TriggerButton")]
			//[Preserve]
			public ButtonControl triggerPressed { get; private set; }

			// Token: 0x170000B8 RID: 184
			// (get) Token: 0x060002FD RID: 765 RVA: 0x0000A4B2 File Offset: 0x000086B2
			// (set) Token: 0x060002FE RID: 766 RVA: 0x0000A4BA File Offset: 0x000086BA
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"indexTouch",
				"indexNearTouched"
			}, usage = "TriggerTouch")]
			public ButtonControl triggerTouched { get; private set; }

			// Token: 0x170000B9 RID: 185
			// (get) Token: 0x060002FF RID: 767 RVA: 0x0000A4C3 File Offset: 0x000086C3
			// (set) Token: 0x06000300 RID: 768 RVA: 0x0000A4CB File Offset: 0x000086CB
			[InputControl(aliases = new string[]
			{
				"JoystickOrPadPressed",
				"thumbstickClick",
				"joystickClicked"
			}, usage = "Primary2DAxisClick")]
			//[Preserve]
			public ButtonControl thumbstickClicked { get; private set; }

			// Token: 0x170000BA RID: 186
			// (get) Token: 0x06000301 RID: 769 RVA: 0x0000A4D4 File Offset: 0x000086D4
			// (set) Token: 0x06000302 RID: 770 RVA: 0x0000A4DC File Offset: 0x000086DC
			//[Preserve]
			[InputControl(aliases = new string[]
			{
				"JoystickOrPadTouched",
				"thumbstickTouch",
				"joystickTouched"
			}, usage = "Primary2DAxisTouch")]
			public ButtonControl thumbstickTouched { get; private set; }

			// Token: 0x170000BB RID: 187
			// (get) Token: 0x06000303 RID: 771 RVA: 0x0000A4E5 File Offset: 0x000086E5
			// (set) Token: 0x06000304 RID: 772 RVA: 0x0000A4ED File Offset: 0x000086ED
			//[Preserve]
			[InputControl(usage = "ThumbrestTouch")]
			public ButtonControl thumbrestTouched { get; private set; }

			// Token: 0x170000BC RID: 188
			// (get) Token: 0x06000305 RID: 773 RVA: 0x0000A4F6 File Offset: 0x000086F6
			// (set) Token: 0x06000306 RID: 774 RVA: 0x0000A4FE File Offset: 0x000086FE
			//[Preserve]
			[InputControl(offset = 0U, aliases = new string[]
			{
				"device",
				"gripPose"
			}, usage = "Device")]
			public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

			// Token: 0x170000BD RID: 189
			// (get) Token: 0x06000307 RID: 775 RVA: 0x0000A507 File Offset: 0x00008707
			// (set) Token: 0x06000308 RID: 776 RVA: 0x0000A50F File Offset: 0x0000870F
			//[Preserve]
			[InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
			public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

			// Token: 0x170000BE RID: 190
			// (get) Token: 0x06000309 RID: 777 RVA: 0x0000A518 File Offset: 0x00008718
			// (set) Token: 0x0600030A RID: 778 RVA: 0x0000A520 File Offset: 0x00008720
			[InputControl(offset = 28U, usage = "IsTracked")]
			//[Preserve]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x170000BF RID: 191
			// (get) Token: 0x0600030B RID: 779 RVA: 0x0000A529 File Offset: 0x00008729
			// (set) Token: 0x0600030C RID: 780 RVA: 0x0000A531 File Offset: 0x00008731
			//[Preserve]
			[InputControl(offset = 32U, usage = "TrackingState")]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x0600030D RID: 781 RVA: 0x0000A53A File Offset: 0x0000873A
			// (set) Token: 0x0600030E RID: 782 RVA: 0x0000A542 File Offset: 0x00008742
			[InputControl(offset = 36U, noisy = true, alias = "gripPosition")]
			//[Preserve]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x170000C1 RID: 193
			// (get) Token: 0x0600030F RID: 783 RVA: 0x0000A54B File Offset: 0x0000874B
			// (set) Token: 0x06000310 RID: 784 RVA: 0x0000A553 File Offset: 0x00008753
			[InputControl(offset = 48U, noisy = true, alias = "gripOrientation")]
			//[Preserve]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x06000311 RID: 785 RVA: 0x0000A55C File Offset: 0x0000875C
			// (set) Token: 0x06000312 RID: 786 RVA: 0x0000A564 File Offset: 0x00008764
			//[Preserve]
			[InputControl(offset = 96U)]
			public Vector3Control pointerPosition { get; private set; }

			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x06000313 RID: 787 RVA: 0x0000A56D File Offset: 0x0000876D
			// (set) Token: 0x06000314 RID: 788 RVA: 0x0000A575 File Offset: 0x00008775
			[InputControl(offset = 108U, alias = "pointerOrientation")]
			//[Preserve]
			public QuaternionControl pointerRotation { get; private set; }

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000315 RID: 789 RVA: 0x0000A57E File Offset: 0x0000877E
			// (set) Token: 0x06000316 RID: 790 RVA: 0x0000A586 File Offset: 0x00008786
			//[Preserve]
			[InputControl(usage = "Haptic")]
			public HapticControl haptic { get; private set; }

			// Token: 0x170000C5 RID: 197
			// (get) Token: 0x06000317 RID: 791 RVA: 0x0000A58F File Offset: 0x0000878F
			// (set) Token: 0x06000318 RID: 792 RVA: 0x0000A597 File Offset: 0x00008797
			//[Preserve]
			[InputControl(usage = "ThumbrestForce")]
			public AxisControl thumbrestForce { get; private set; }

			// Token: 0x170000C6 RID: 198
			// (get) Token: 0x06000319 RID: 793 RVA: 0x0000A5A0 File Offset: 0x000087A0
			// (set) Token: 0x0600031A RID: 794 RVA: 0x0000A5A8 File Offset: 0x000087A8
			[InputControl(usage = "StylusForce")]
			//[Preserve]
			public AxisControl stylusForce { get; private set; }

			// Token: 0x170000C7 RID: 199
			// (get) Token: 0x0600031B RID: 795 RVA: 0x0000A5B1 File Offset: 0x000087B1
			// (set) Token: 0x0600031C RID: 796 RVA: 0x0000A5B9 File Offset: 0x000087B9
			//[Preserve]
			[InputControl(usage = "TriggerCurl")]
			public AxisControl triggerCurl { get; private set; }

			// Token: 0x170000C8 RID: 200
			// (get) Token: 0x0600031D RID: 797 RVA: 0x0000A5C2 File Offset: 0x000087C2
			// (set) Token: 0x0600031E RID: 798 RVA: 0x0000A5CA File Offset: 0x000087CA
			//[Preserve]
			[InputControl(usage = "TriggerSlide")]
			public AxisControl triggerSlide { get; private set; }

			// Token: 0x170000C9 RID: 201
			// (get) Token: 0x0600031F RID: 799 RVA: 0x0000A5D3 File Offset: 0x000087D3
			// (set) Token: 0x06000320 RID: 800 RVA: 0x0000A5DB File Offset: 0x000087DB
			//[Preserve]
			[InputControl(usage = "TriggerProximity")]
			public ButtonControl triggerProximity { get; private set; }

			// Token: 0x170000CA RID: 202
			// (get) Token: 0x06000321 RID: 801 RVA: 0x0000A5E4 File Offset: 0x000087E4
			// (set) Token: 0x06000322 RID: 802 RVA: 0x0000A5EC File Offset: 0x000087EC
			[InputControl(usage = "ThumbProximity")]
			//[Preserve]
			public ButtonControl thumbProximity { get; private set; }

			// Token: 0x170000CB RID: 203
			// (get) Token: 0x06000323 RID: 803 RVA: 0x0000A5F5 File Offset: 0x000087F5
			// (set) Token: 0x06000324 RID: 804 RVA: 0x0000A5FD File Offset: 0x000087FD
			[InputControl(usage = "HapticTrigger")]
			//[Preserve]
			public HapticControl hapticTrigger { get; private set; }

			// Token: 0x170000CC RID: 204
			// (get) Token: 0x06000325 RID: 805 RVA: 0x0000A606 File Offset: 0x00008806
			// (set) Token: 0x06000326 RID: 806 RVA: 0x0000A60E File Offset: 0x0000880E
			[InputControl(usage = "HapticThumb")]
			//[Preserve]
			public HapticControl hapticThumb { get; private set; }

			// Token: 0x06000327 RID: 807 RVA: 0x0000A618 File Offset: 0x00008818
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
				this.thumbrestForce = base.GetChildControl<AxisControl>("thumbrestForce");
				this.stylusForce = base.GetChildControl<AxisControl>("stylusForce");
				this.triggerCurl = base.GetChildControl<AxisControl>("triggerCurl");
				this.triggerSlide = base.GetChildControl<AxisControl>("triggerSlide");
				this.triggerProximity = base.GetChildControl<ButtonControl>("triggerProximity");
				this.thumbProximity = base.GetChildControl<ButtonControl>("thumbProximity");
				this.hapticTrigger = base.GetChildControl<HapticControl>("hapticTrigger");
				this.hapticThumb = base.GetChildControl<HapticControl>("hapticThumb");
			}
		}
	}
}
