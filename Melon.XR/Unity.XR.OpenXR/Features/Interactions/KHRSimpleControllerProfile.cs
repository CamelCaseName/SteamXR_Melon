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
    // Token: 0x0200005F RID: 95
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class KHRSimpleControllerProfile : OpenXRInteractionFeature
    {
        public KHRSimpleControllerProfile() : base(ClassInjector.DerivedConstructorPointer<KHRSimpleControllerProfile>()) => ClassInjector.DerivedConstructorBody(this);
        public KHRSimpleControllerProfile(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x06000286 RID: 646 RVA: 0x000082E4 File Offset: 0x000064E4
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<KHRSimpleControllerProfile.KHRSimpleController>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("KHR Simple Controller OpenXR", true)));
        }

        // Token: 0x06000287 RID: 647 RVA: 0x00008328 File Offset: 0x00006528
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout(typeof(KHRSimpleControllerProfile.KHRSimpleController).Name);
        }

        // Token: 0x06000288 RID: 648 RVA: 0x0000833E File Offset: 0x0000653E
        protected override string GetDeviceLayoutName()
        {
            return "KHRSimpleController";
        }

        // Token: 0x06000289 RID: 649 RVA: 0x00008348 File Offset: 0x00006548
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "khrsimplecontroller",
                localizedName = "KHR Simple Controller OpenXR",
                desiredInteractionProfile = "/interaction_profiles/khr/simple_controller",
                manufacturer = "Khronos",
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
                        name = "select",
                        localizedName = "Select",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        usages = new List<string>
                        {
                            "PrimaryButton"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/select/click",
                                interactionProfileName = "/interaction_profiles/khr/simple_controller"
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
                                interactionProfileName = "/interaction_profiles/khr/simple_controller"
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
                                interactionProfileName = "/interaction_profiles/khr/simple_controller"
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
                                interactionProfileName = "/interaction_profiles/khr/simple_controller"
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
                                interactionProfileName = "/interaction_profiles/khr/simple_controller"
                            }
                        }
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x04000294 RID: 660
        public const string featureId = "com.unity.openxr.feature.input.khrsimpleprofile";

        // Token: 0x04000295 RID: 661
        public const string profile = "/interaction_profiles/khr/simple_controller";

        // Token: 0x04000296 RID: 662
        public const string select = "/input/select/click";

        // Token: 0x04000297 RID: 663
        public const string menu = "/input/menu/click";

        // Token: 0x04000298 RID: 664
        public const string grip = "/input/grip/pose";

        // Token: 0x04000299 RID: 665
        public const string aim = "/input/aim/pose";

        // Token: 0x0400029A RID: 666
        public const string haptic = "/output/haptic";

        // Token: 0x0400029B RID: 667
        private const string kDeviceLocalizedName = "KHR Simple Controller OpenXR";

        // Token: 0x02000060 RID: 96
        [InputControlLayout(displayName = "Khronos Simple Controller (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        })]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        //[Preserve]
        public class KHRSimpleController : XRControllerWithRumble
        {
            // Token: 0x17000087 RID: 135
            // (get) Token: 0x0600028B RID: 651 RVA: 0x00008603 File Offset: 0x00006803
            // (set) Token: 0x0600028C RID: 652 RVA: 0x0000860B File Offset: 0x0000680B
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Secondary",
                "selectbutton"
            }, usage = "PrimaryButton")]
            public ButtonControl select;

            // Token: 0x17000088 RID: 136
            // (get) Token: 0x0600028D RID: 653 RVA: 0x00008614 File Offset: 0x00006814
            // (set) Token: 0x0600028E RID: 654 RVA: 0x0000861C File Offset: 0x0000681C
            //[Preserve]
            [InputControl(aliases = new string[]
            {
                "Primary",
                "menubutton"
            }, usage = "MenuButton")]
            public ButtonControl menu;

            // Token: 0x17000089 RID: 137
            // (get) Token: 0x0600028F RID: 655 RVA: 0x00008625 File Offset: 0x00006825
            // (set) Token: 0x06000290 RID: 656 RVA: 0x0000862D File Offset: 0x0000682D
            //[Preserve]
            [InputControl(offset = 0U, aliases = new string[]
            {
                "device",
                "gripPose"
            }, usage = "Device")]
            public UnityEngine.InputSystem.XR.PoseControl devicePose;

            // Token: 0x1700008A RID: 138
            // (get) Token: 0x06000291 RID: 657 RVA: 0x00008636 File Offset: 0x00006836
            // (set) Token: 0x06000292 RID: 658 RVA: 0x0000863E File Offset: 0x0000683E
            //[Preserve]
            [InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
            public UnityEngine.InputSystem.XR.PoseControl pointer;

            // Token: 0x1700008B RID: 139
            // (get) Token: 0x06000293 RID: 659 RVA: 0x00008647 File Offset: 0x00006847
            // (set) Token: 0x06000294 RID: 660 RVA: 0x0000864F File Offset: 0x0000684F
            //[Preserve]
            [InputControl(offset = 2U)]
            public new ButtonControl isTracked;

            // Token: 0x1700008C RID: 140
            // (get) Token: 0x06000295 RID: 661 RVA: 0x00008658 File Offset: 0x00006858
            // (set) Token: 0x06000296 RID: 662 RVA: 0x00008660 File Offset: 0x00006860
            [InputControl(offset = 4U)]
            //[Preserve]
            public new IntegerControl trackingState;

            // Token: 0x1700008D RID: 141
            // (get) Token: 0x06000297 RID: 663 RVA: 0x00008669 File Offset: 0x00006869
            // (set) Token: 0x06000298 RID: 664 RVA: 0x00008671 File Offset: 0x00006871
            //[Preserve]
            [InputControl(offset = 8U, alias = "gripPosition")]
            public new Vector3Control devicePosition;

            // Token: 0x1700008E RID: 142
            // (get) Token: 0x06000299 RID: 665 RVA: 0x0000867A File Offset: 0x0000687A
            // (set) Token: 0x0600029A RID: 666 RVA: 0x00008682 File Offset: 0x00006882
            //[Preserve]
            [InputControl(offset = 20U, alias = "gripOrientation")]
            public new QuaternionControl deviceRotation;

            // Token: 0x1700008F RID: 143
            // (get) Token: 0x0600029B RID: 667 RVA: 0x0000868B File Offset: 0x0000688B
            // (set) Token: 0x0600029C RID: 668 RVA: 0x00008693 File Offset: 0x00006893
            [InputControl(offset = 68U)]
            //[Preserve]
            public Vector3Control pointerPosition;

            // Token: 0x17000090 RID: 144
            // (get) Token: 0x0600029D RID: 669 RVA: 0x0000869C File Offset: 0x0000689C
            // (set) Token: 0x0600029E RID: 670 RVA: 0x000086A4 File Offset: 0x000068A4
            //[Preserve]
            [InputControl(offset = 80U, alias = "pointerOrientation")]
            public QuaternionControl pointerRotation;

            // Token: 0x17000091 RID: 145
            // (get) Token: 0x0600029F RID: 671 RVA: 0x000086AD File Offset: 0x000068AD
            // (set) Token: 0x060002A0 RID: 672 RVA: 0x000086B5 File Offset: 0x000068B5
            //[Preserve]
            [InputControl(usage = "Haptic")]
            public HapticControl haptic;

            // Token: 0x060002A1 RID: 673 RVA: 0x000086C0 File Offset: 0x000068C0
            private bool setUp = false;
            public override void FinishSetup()
            {
                if (!setUp)
                {
                    setUp = true;
                    base.FinishSetup();
                    this.menu = base.GetChildControl<ButtonControl>("menu");
                    this.select = base.GetChildControl<ButtonControl>("select");
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
}
