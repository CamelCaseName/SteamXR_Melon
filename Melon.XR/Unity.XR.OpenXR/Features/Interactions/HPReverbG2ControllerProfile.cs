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
    // Token: 0x0200005B RID: 91
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class HPReverbG2ControllerProfile : OpenXRInteractionFeature
    {
        public HPReverbG2ControllerProfile() : base(ClassInjector.DerivedConstructorPointer<HPReverbG2ControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public HPReverbG2ControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x0600022F RID: 559 RVA: 0x0000713E File Offset: 0x0000533E
        protected internal override bool OnInstanceCreate(ulong instance)
        {
            return OpenXRRuntime.IsExtensionEnabled("XR_EXT_hp_mixed_reality_controller") && base.OnInstanceCreate(instance);
        }

        // Token: 0x06000230 RID: 560 RVA: 0x00007158 File Offset: 0x00005358
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<HPReverbG2ControllerProfile.ReverbG2Controller>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("HP Reverb G2 Controller OpenXR", true)));
        }

        // Token: 0x06000231 RID: 561 RVA: 0x0000719C File Offset: 0x0000539C
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("ReverbG2Controller");
        }

        // Token: 0x06000232 RID: 562 RVA: 0x000071A8 File Offset: 0x000053A8
        protected override string GetDeviceLayoutName()
        {
            return "ReverbG2Controller";
        }

        // Token: 0x06000233 RID: 563 RVA: 0x000071B0 File Offset: 0x000053B0
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "hpreverbg2controller",
                localizedName = "HP Reverb G2 Controller OpenXR",
                desiredInteractionProfile = "/interaction_profiles/hp/mixed_reality_controller",
                manufacturer = "HP",
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller",
                                userPaths = new List<string>
                                {
                                    "/user/hand/left"
                                }
                            },
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/a/click",
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller",
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller",
                                userPaths = new List<string>
                                {
                                    "/user/hand/left"
                                }
                            },
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/b/click",
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller",
                                userPaths = new List<string>
                                {
                                    "/user/hand/right"
                                }
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
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
                                interactionProfileName = "/interaction_profiles/hp/mixed_reality_controller"
                            }
                        }
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x04000253 RID: 595
        public const string featureId = "com.unity.openxr.feature.input.hpreverb";

        // Token: 0x04000254 RID: 596
        public const string profile = "/interaction_profiles/hp/mixed_reality_controller";

        // Token: 0x04000255 RID: 597
        public const string buttonX = "/input/x/click";

        // Token: 0x04000256 RID: 598
        public const string buttonY = "/input/y/click";

        // Token: 0x04000257 RID: 599
        public const string buttonA = "/input/a/click";

        // Token: 0x04000258 RID: 600
        public const string buttonB = "/input/b/click";

        // Token: 0x04000259 RID: 601
        public const string menu = "/input/menu/click";

        // Token: 0x0400025A RID: 602
        public const string squeeze = "/input/squeeze/value";

        // Token: 0x0400025B RID: 603
        public const string trigger = "/input/trigger/value";

        // Token: 0x0400025C RID: 604
        public const string thumbstick = "/input/thumbstick";

        // Token: 0x0400025D RID: 605
        public const string thumbstickClick = "/input/thumbstick/click";

        // Token: 0x0400025E RID: 606
        public const string grip = "/input/grip/pose";

        // Token: 0x0400025F RID: 607
        public const string aim = "/input/aim/pose";

        // Token: 0x04000260 RID: 608
        public const string haptic = "/output/haptic";

        // Token: 0x04000261 RID: 609
        private const string kDeviceLocalizedName = "HP Reverb G2 Controller OpenXR";

        // Token: 0x0200005C RID: 92

        [InputControlLayout(displayName = "HP Reverb G2 Controller (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        })]
        //[Preserve]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class ReverbG2Controller : XRControllerWithRumble
        {
            // Token: 0x17000063 RID: 99
            // (get) Token: 0x06000235 RID: 565 RVA: 0x000077EB File Offset: 0x000059EB
            // (set) Token: 0x06000236 RID: 566 RVA: 0x000077F3 File Offset: 0x000059F3
            [InputControl(aliases = new string[]
            {
                "A",
                "X",
                "buttonA",
                "buttonX"
            }, usage = "PrimaryButton")]
            //[Preserve]
            public ButtonControl primaryButton { get; private set; }

            // Token: 0x17000064 RID: 100
            // (get) Token: 0x06000237 RID: 567 RVA: 0x000077FC File Offset: 0x000059FC
            // (set) Token: 0x06000238 RID: 568 RVA: 0x00007804 File Offset: 0x00005A04
            [InputControl(aliases = new string[]
            {
                "B",
                "Y",
                "buttonB",
                "buttonY"
            }, usage = "SecondaryButton")]
            //[Preserve]
            public ButtonControl secondaryButton { get; private set; }

            // Token: 0x17000065 RID: 101
            // (get) Token: 0x06000239 RID: 569 RVA: 0x0000780D File Offset: 0x00005A0D
            // (set) Token: 0x0600023A RID: 570 RVA: 0x00007815 File Offset: 0x00005A15
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Primary",
                "menubutton"
            }, usage = "MenuButton")]
            public ButtonControl menu { get; private set; }

            // Token: 0x17000066 RID: 102
            // (get) Token: 0x0600023B RID: 571 RVA: 0x0000781E File Offset: 0x00005A1E
            // (set) Token: 0x0600023C RID: 572 RVA: 0x00007826 File Offset: 0x00005A26
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "GripAxis",
                "squeeze"
            }, usage = "Grip")]
            public AxisControl grip { get; private set; }

            // Token: 0x17000067 RID: 103
            // (get) Token: 0x0600023D RID: 573 RVA: 0x0000782F File Offset: 0x00005A2F
            // (set) Token: 0x0600023E RID: 574 RVA: 0x00007837 File Offset: 0x00005A37
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "GripButton",
                "squeezeClicked"
            }, usage = "GripButton")]
            public ButtonControl gripPressed { get; private set; }

            // Token: 0x17000068 RID: 104
            // (get) Token: 0x0600023F RID: 575 RVA: 0x00007840 File Offset: 0x00005A40
            // (set) Token: 0x06000240 RID: 576 RVA: 0x00007848 File Offset: 0x00005A48
            [InputControl(usage = "Trigger")]
            //[Preserve]
            public AxisControl trigger { get; private set; }

            // Token: 0x17000069 RID: 105
            // (get) Token: 0x06000241 RID: 577 RVA: 0x00007851 File Offset: 0x00005A51
            // (set) Token: 0x06000242 RID: 578 RVA: 0x00007859 File Offset: 0x00005A59
            [InputControl(aliases = new string[]
            {
                "indexButton",
                "indexTouched",
                "triggerbutton"
            }, usage = "TriggerButton")]
            //[Preserve]
            public ButtonControl triggerPressed { get; private set; }

            // Token: 0x1700006A RID: 106
            // (get) Token: 0x06000243 RID: 579 RVA: 0x00007862 File Offset: 0x00005A62
            // (set) Token: 0x06000244 RID: 580 RVA: 0x0000786A File Offset: 0x00005A6A
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Primary2DAxis",
                "Joystick"
            }, usage = "Primary2DAxis")]
            public StickControl thumbstick { get; private set; }

            // Token: 0x1700006B RID: 107
            // (get) Token: 0x06000245 RID: 581 RVA: 0x00007873 File Offset: 0x00005A73
            // (set) Token: 0x06000246 RID: 582 RVA: 0x0000787B File Offset: 0x00005A7B
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "JoystickOrPadPressed",
                "thumbstickClick",
                "joystickClicked"
            }, usage = "Primary2DAxisClick")]
            public ButtonControl thumbstickClicked { get; private set; }

            // Token: 0x1700006C RID: 108
            // (get) Token: 0x06000247 RID: 583 RVA: 0x00007884 File Offset: 0x00005A84
            // (set) Token: 0x06000248 RID: 584 RVA: 0x0000788C File Offset: 0x00005A8C
            //[Preserve]
            [InputControl(offset = 0U, aliases = new string[]
            {
                "device",
                "gripPose"
            }, usage = "Device")]
            public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

            // Token: 0x1700006D RID: 109
            // (get) Token: 0x06000249 RID: 585 RVA: 0x00007895 File Offset: 0x00005A95
            // (set) Token: 0x0600024A RID: 586 RVA: 0x0000789D File Offset: 0x00005A9D
            [InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

            // Token: 0x1700006E RID: 110
            // (get) Token: 0x0600024B RID: 587 RVA: 0x000078A6 File Offset: 0x00005AA6
            // (set) Token: 0x0600024C RID: 588 RVA: 0x000078AE File Offset: 0x00005AAE
            [InputControl(offset = 29U)]
            //[Preserve]
            public new ButtonControl isTracked { get; private set; }

            // Token: 0x1700006F RID: 111
            // (get) Token: 0x0600024D RID: 589 RVA: 0x000078B7 File Offset: 0x00005AB7
            // (set) Token: 0x0600024E RID: 590 RVA: 0x000078BF File Offset: 0x00005ABF
            [InputControl(offset = 32U)]
            //[Preserve]
            public new IntegerControl trackingState { get; private set; }

            // Token: 0x17000070 RID: 112
            // (get) Token: 0x0600024F RID: 591 RVA: 0x000078C8 File Offset: 0x00005AC8
            // (set) Token: 0x06000250 RID: 592 RVA: 0x000078D0 File Offset: 0x00005AD0
            //[Preserve]
            [InputControl(offset = 36U, alias = "gripPosition")]
            public new Vector3Control devicePosition { get; private set; }

            // Token: 0x17000071 RID: 113
            // (get) Token: 0x06000251 RID: 593 RVA: 0x000078D9 File Offset: 0x00005AD9
            // (set) Token: 0x06000252 RID: 594 RVA: 0x000078E1 File Offset: 0x00005AE1
            //[Preserve]
            [InputControl(offset = 48U, alias = "gripOrientation")]
            public new QuaternionControl deviceRotation { get; private set; }

            // Token: 0x17000072 RID: 114
            // (get) Token: 0x06000253 RID: 595 RVA: 0x000078EA File Offset: 0x00005AEA
            // (set) Token: 0x06000254 RID: 596 RVA: 0x000078F2 File Offset: 0x00005AF2
            //[Preserve]
            [InputControl(offset = 96U)]
            public Vector3Control pointerPosition { get; private set; }

            // Token: 0x17000073 RID: 115
            // (get) Token: 0x06000255 RID: 597 RVA: 0x000078FB File Offset: 0x00005AFB
            // (set) Token: 0x06000256 RID: 598 RVA: 0x00007903 File Offset: 0x00005B03
            //[Preserve]
            [InputControl(offset = 108U, alias = "pointerOrientation")]
            public QuaternionControl pointerRotation { get; private set; }

            // Token: 0x17000074 RID: 116
            // (get) Token: 0x06000257 RID: 599 RVA: 0x0000790C File Offset: 0x00005B0C
            // (set) Token: 0x06000258 RID: 600 RVA: 0x00007914 File Offset: 0x00005B14
            [InputControl(usage = "Haptic")]
            //[Preserve]
            public HapticControl haptic { get; private set; }

            // Token: 0x06000259 RID: 601 RVA: 0x00007920 File Offset: 0x00005B20
            public override void FinishSetup()
            {
                base.FinishSetup();
                this.primaryButton = base.GetChildControl<ButtonControl>("primaryButton");
                this.secondaryButton = base.GetChildControl<ButtonControl>("secondaryButton");
                this.menu = base.GetChildControl<ButtonControl>("menu");
                this.grip = base.GetChildControl<AxisControl>("grip");
                this.gripPressed = base.GetChildControl<ButtonControl>("gripPressed");
                this.trigger = base.GetChildControl<AxisControl>("trigger");
                this.triggerPressed = base.GetChildControl<ButtonControl>("triggerPressed");
                this.thumbstick = base.GetChildControl<StickControl>("thumbstick");
                this.thumbstickClicked = base.GetChildControl<ButtonControl>("thumbstickClicked");
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
