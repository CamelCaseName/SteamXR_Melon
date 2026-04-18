using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
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
    // Token: 0x0200005D RID: 93
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class HTCViveControllerProfile : OpenXRInteractionFeature
    {
        public HTCViveControllerProfile() : base(ClassInjector.DerivedConstructorPointer<HTCViveControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public HTCViveControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x0600025B RID: 603 RVA: 0x00007A70 File Offset: 0x00005C70
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<HTCViveControllerProfile.ViveController>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("HTC Vive Controller OpenXR", true)));
        }

        // Token: 0x0600025C RID: 604 RVA: 0x00007AB4 File Offset: 0x00005CB4
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("ViveController");
        }

        // Token: 0x0600025D RID: 605 RVA: 0x00007AC0 File Offset: 0x00005CC0
        protected override string GetDeviceLayoutName()
        {
            return "ViveController";
        }

        // Token: 0x0600025E RID: 606 RVA: 0x00007AC8 File Offset: 0x00005CC8
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "htcvivecontroller",
                localizedName = "HTC Vive Controller OpenXR",
                desiredInteractionProfile = "/interaction_profiles/htc/vive_controller",
                manufacturer = "HTC",
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
                            }
                        }
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "select",
                        localizedName = "Select",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        usages = new List<string>
                        {
                            "SystemButton"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/system/click",
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionPath = "/input/trigger/click",
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                            "Primary2DAxis"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad",
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                            "Primary2DAxisTouch"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/touch",
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
                            }
                        }
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadClicked",
                        localizedName = "Trackpad Clicked",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        usages = new List<string>
                        {
                            "Primary2DAxisClick"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/click",
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
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
                                interactionProfileName = "/interaction_profiles/htc/vive_controller"
                            }
                        }
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x04000274 RID: 628
        public const string featureId = "com.unity.openxr.feature.input.htcvive";

        // Token: 0x04000275 RID: 629
        public const string profile = "/interaction_profiles/htc/vive_controller";

        // Token: 0x04000276 RID: 630
        public const string system = "/input/system/click";

        // Token: 0x04000277 RID: 631
        public const string squeeze = "/input/squeeze/click";

        // Token: 0x04000278 RID: 632
        public const string menu = "/input/menu/click";

        // Token: 0x04000279 RID: 633
        public const string trigger = "/input/trigger/value";

        // Token: 0x0400027A RID: 634
        public const string triggerClick = "/input/trigger/click";

        // Token: 0x0400027B RID: 635
        public const string trackpad = "/input/trackpad";

        // Token: 0x0400027C RID: 636
        public const string trackpadClick = "/input/trackpad/click";

        // Token: 0x0400027D RID: 637
        public const string trackpadTouch = "/input/trackpad/touch";

        // Token: 0x0400027E RID: 638
        public const string grip = "/input/grip/pose";

        // Token: 0x0400027F RID: 639
        public const string aim = "/input/aim/pose";

        // Token: 0x04000280 RID: 640
        public const string haptic = "/output/haptic";

        // Token: 0x04000281 RID: 641
        private const string kDeviceLocalizedName = "HTC Vive Controller OpenXR";

        // Token: 0x0200005E RID: 94
        [InputControlLayout(displayName = "HTC Vive Controller (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        })]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        //[Preserve]
        public class ViveController : XRControllerWithRumble
        {
            // Token: 0x17000075 RID: 117
            // (get) Token: 0x06000260 RID: 608 RVA: 0x00008069 File Offset: 0x00006269
            // (set) Token: 0x06000261 RID: 609 RVA: 0x00008071 File Offset: 0x00006271
            [InputControl(aliases = new string[]
            {
                "Secondary",
                "selectbutton"
            }, usage = "SystemButton")]
            //[Preserve]
            public ButtonControl select;

            // Token: 0x17000076 RID: 118
            // (get) Token: 0x06000262 RID: 610 RVA: 0x0000807A File Offset: 0x0000627A
            // (set) Token: 0x06000263 RID: 611 RVA: 0x00008082 File Offset: 0x00006282
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "GripAxis",
                "squeeze"
            }, usage = "Grip")]
            public AxisControl grip;

            // Token: 0x17000077 RID: 119
            // (get) Token: 0x06000264 RID: 612 RVA: 0x0000808B File Offset: 0x0000628B
            // (set) Token: 0x06000265 RID: 613 RVA: 0x00008093 File Offset: 0x00006293
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "GripButton",
                "squeezeClicked"
            }, usage = "GripButton")]
            public ButtonControl gripPressed;

            // Token: 0x17000078 RID: 120
            // (get) Token: 0x06000266 RID: 614 RVA: 0x0000809C File Offset: 0x0000629C
            // (set) Token: 0x06000267 RID: 615 RVA: 0x000080A4 File Offset: 0x000062A4
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Primary",
                "menubutton"
            }, usage = "MenuButton")]
            public ButtonControl menu;

            // Token: 0x17000079 RID: 121
            // (get) Token: 0x06000268 RID: 616 RVA: 0x000080AD File Offset: 0x000062AD
            // (set) Token: 0x06000269 RID: 617 RVA: 0x000080B5 File Offset: 0x000062B5
            //[Preserve]
            [InputControl(alias = "triggeraxis", usage = "Trigger")]
            public AxisControl trigger;

            // Token: 0x1700007A RID: 122
            // (get) Token: 0x0600026A RID: 618 RVA: 0x000080BE File Offset: 0x000062BE
            // (set) Token: 0x0600026B RID: 619 RVA: 0x000080C6 File Offset: 0x000062C6
            //[Preserve]
            [InputControl(alias = "triggerbutton", usage = "TriggerButton")]
            public ButtonControl triggerPressed;

            // Token: 0x1700007B RID: 123
            // (get) Token: 0x0600026C RID: 620 RVA: 0x000080CF File Offset: 0x000062CF
            // (set) Token: 0x0600026D RID: 621 RVA: 0x000080D7 File Offset: 0x000062D7
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Primary2DAxis",
                "touchpadaxes",
                "touchpad"
            }, usage = "Primary2DAxis")]
            public StickControl trackpad;

            // Token: 0x1700007C RID: 124
            // (get) Token: 0x0600026E RID: 622 RVA: 0x000080E0 File Offset: 0x000062E0
            // (set) Token: 0x0600026F RID: 623 RVA: 0x000080E8 File Offset: 0x000062E8
            [InputControl(aliases = new string[]
            {
                "joystickorpadpressed",
                "touchpadpressed"
            }, usage = "Primary2DAxisClick")]
            //[Preserve]
            public ButtonControl trackpadClicked;

            // Token: 0x1700007D RID: 125
            // (get) Token: 0x06000270 RID: 624 RVA: 0x000080F1 File Offset: 0x000062F1
            // (set) Token: 0x06000271 RID: 625 RVA: 0x000080F9 File Offset: 0x000062F9
            [InputControl(aliases = new string[]
            {
                "joystickorpadtouched",
                "touchpadtouched"
            }, usage = "Primary2DAxisTouch")]
            //[Preserve]
            public ButtonControl trackpadTouched;

            // Token: 0x1700007E RID: 126
            // (get) Token: 0x06000272 RID: 626 RVA: 0x00008102 File Offset: 0x00006302
            // (set) Token: 0x06000273 RID: 627 RVA: 0x0000810A File Offset: 0x0000630A
            //[Preserve]
            [InputControl(offset = 0U, aliases = new string[]
            {
                "device",
                "gripPose"
            }, usage = "Device")]
            public UnityEngine.InputSystem.XR.PoseControl devicePose;

            // Token: 0x1700007F RID: 127
            // (get) Token: 0x06000274 RID: 628 RVA: 0x00008113 File Offset: 0x00006313
            // (set) Token: 0x06000275 RID: 629 RVA: 0x0000811B File Offset: 0x0000631B
            [InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl pointer;

            // Token: 0x17000080 RID: 128
            // (get) Token: 0x06000276 RID: 630 RVA: 0x00008124 File Offset: 0x00006324
            // (set) Token: 0x06000277 RID: 631 RVA: 0x0000812C File Offset: 0x0000632C
            [InputControl(offset = 26U)]
            //[Preserve]
            public new ButtonControl isTracked;

            // Token: 0x17000081 RID: 129
            // (get) Token: 0x06000278 RID: 632 RVA: 0x00008135 File Offset: 0x00006335
            // (set) Token: 0x06000279 RID: 633 RVA: 0x0000813D File Offset: 0x0000633D
            [InputControl(offset = 28U)]
            //[Preserve]
            public new IntegerControl trackingState;

            // Token: 0x17000082 RID: 130
            // (get) Token: 0x0600027A RID: 634 RVA: 0x00008146 File Offset: 0x00006346
            // (set) Token: 0x0600027B RID: 635 RVA: 0x0000814E File Offset: 0x0000634E
            //[Preserve]
            [InputControl(offset = 32U, alias = "gripPosition")]
            public new Vector3Control devicePosition;

            // Token: 0x17000083 RID: 131
            // (get) Token: 0x0600027C RID: 636 RVA: 0x00008157 File Offset: 0x00006357
            // (set) Token: 0x0600027D RID: 637 RVA: 0x0000815F File Offset: 0x0000635F
            [InputControl(offset = 44U, alias = "gripOrientation")]
            //[Preserve]
            public new QuaternionControl deviceRotation;

            // Token: 0x17000084 RID: 132
            // (get) Token: 0x0600027E RID: 638 RVA: 0x00008168 File Offset: 0x00006368
            // (set) Token: 0x0600027F RID: 639 RVA: 0x00008170 File Offset: 0x00006370
            [InputControl(offset = 92U)]
            //[Preserve]
            public Vector3Control pointerPosition;

            // Token: 0x17000085 RID: 133
            // (get) Token: 0x06000280 RID: 640 RVA: 0x00008179 File Offset: 0x00006379
            // (set) Token: 0x06000281 RID: 641 RVA: 0x00008181 File Offset: 0x00006381
            //[Preserve]
            [InputControl(offset = 104U, alias = "pointerOrientation")]
            public QuaternionControl pointerRotation;

            // Token: 0x17000086 RID: 134
            // (get) Token: 0x06000282 RID: 642 RVA: 0x0000818A File Offset: 0x0000638A
            // (set) Token: 0x06000283 RID: 643 RVA: 0x00008192 File Offset: 0x00006392
            [InputControl(usage = "Haptic")]
            //[Preserve]
            public HapticControl haptic;

            // Token: 0x06000284 RID: 644 RVA: 0x0000819C File Offset: 0x0000639C
            private bool setUp = false;
            public override void FinishSetup()
            {
                if (!setUp)
                {
                    setUp = true;
                    base.FinishSetup();
                    this.select = base.GetChildControl<ButtonControl>("select");
                    this.grip = base.GetChildControl<AxisControl>("grip");
                    this.gripPressed = base.GetChildControl<ButtonControl>("gripPressed");
                    this.menu = base.GetChildControl<ButtonControl>("menu");
                    this.trigger = base.GetChildControl<AxisControl>("trigger");
                    this.triggerPressed = base.GetChildControl<ButtonControl>("triggerPressed");
                    this.trackpad = base.GetChildControl<StickControl>("trackpad");
                    this.trackpadClicked = base.GetChildControl<ButtonControl>("trackpadClicked");
                    this.trackpadTouched = base.GetChildControl<ButtonControl>("trackpadTouched");
                    this.pointer = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pointer");
                    this.pointerPosition = base.GetChildControl<Vector3Control>("pointerPosition");
                    this.pointerRotation = base.GetChildControl<QuaternionControl>("pointerRotation");
                    this.devicePose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("devicePose");
                    this.isTracked = base.GetChildControl<ButtonControl>("isTracked");
                    this.trackingState = base.GetChildControl<IntegerControl>("trackingState");
                    this.devicePosition = base.GetChildControl<Vector3Control>("devicePosition");
                    this.deviceRotation = base.GetChildControl<QuaternionControl>("deviceRotation");
                    this.haptic = base.GetChildControl<HapticControl>("haptic");
                }
            }
        }
    }
}
