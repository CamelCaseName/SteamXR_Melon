using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using Il2CppSystem.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x0200004F RID: 79
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class DPadInteraction : OpenXRInteractionFeature
    {
        public DPadInteraction() : base(ClassInjector.DerivedConstructorPointer<DPadInteraction>()) => ClassInjector.DerivedConstructorBody(this);
        public DPadInteraction(IntPtr ptr) : base(ptr) { }
        // Token: 0x1700003C RID: 60
        // (get) Token: 0x060001B1 RID: 433 RVA: 0x000052E1 File Offset: 0x000034E1
        internal override bool IsAdditive
        {
            get
            {
                return true;
            }
        }

        // Token: 0x060001B2 RID: 434 RVA: 0x000057B4 File Offset: 0x000039B4
        protected internal override bool OnInstanceCreate(ulong instance)
        {
            string[] array = this.extensionStrings;
            for (int i = 0; i < array.Length; i++)
            {
                if (!OpenXRRuntime.IsExtensionEnabled(array[i]))
                {
                    return false;
                }
            }
            return base.OnInstanceCreate(instance);
        }

        // Token: 0x060001B3 RID: 435 RVA: 0x000057EC File Offset: 0x000039EC
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<DPadInteraction.DPadDevice>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("DPad Interaction OpenXR", true)));
        }

        // Token: 0x060001B4 RID: 436 RVA: 0x00005830 File Offset: 0x00003A30
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("DPad");
        }

        // Token: 0x060001B5 RID: 437 RVA: 0x0000583C File Offset: 0x00003A3C
        protected override string GetDeviceLayoutName()
        {
            return "DPad";
        }

        // Token: 0x060001B6 RID: 438 RVA: 0x00005844 File Offset: 0x00003A44
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "dpadinteraction",
                localizedName = "DPad Interaction OpenXR",
                desiredInteractionProfile = "/interaction_profiles/unity/dpad",
                manufacturer = "",
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
                        name = "thumbstickDpadUp",
                        localizedName = " Thumbstick Dpad Up",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/thumbstick/dpad_up",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "thumbstickDpadDown",
                        localizedName = "Thumbstick Dpad Down",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/thumbstick/dpad_down",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "thumbstickDpadLeft",
                        localizedName = "Thumbstick Dpad Left",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/thumbstick/dpad_left",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "thumbstickDpadRight",
                        localizedName = "Thumbstick Dpad Right",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/thumbstick/dpad_right",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadDpadUp",
                        localizedName = "Trackpad Dpad Up",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/dpad_up",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadDpadDown",
                        localizedName = "Trackpad Dpad Down",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/dpad_down",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadDpadLeft",
                        localizedName = "Trackpad Dpad Left",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/dpad_left",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadDpadRight",
                        localizedName = "Trackpad Dpad Right",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/dpad_right",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "trackpadDpadCenter",
                        localizedName = "Trackpad Dpad Center",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/trackpad/dpad_center",
                                interactionProfileName = "/interaction_profiles/unity/dpad"
                            }
                        },
                        isAdditive = true
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x060001B7 RID: 439 RVA: 0x00005C20 File Offset: 0x00003E20
        [HideFromIl2Cpp]
        internal override void AddAdditiveActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, OpenXRInteractionFeature.ActionMapConfig additiveMap)
        {
            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                if ((from d in actionMap.deviceInfos
                     where d.userPath != null && (string.CompareOrdinal(d.userPath, "/user/hand/left") == 0 || string.CompareOrdinal(d.userPath, "/user/hand/right") == 0)
                     select d).Any<OpenXRInteractionFeature.DeviceConfig>())
                {
                    bool hasTrackPad = false;
                    bool hasThumbstick = false;
                    foreach (OpenXRInteractionFeature.ActionConfig action in actionMap.actions)
                    {
                        if (!hasTrackPad)
                        {
                            if (action.bindings.FirstOrDefault((OpenXRInteractionFeature.ActionBinding b) => b.interactionPath.Contains("trackpad")) != null)
                            {
                                hasTrackPad = true;
                            }
                        }
                        if (!hasThumbstick)
                        {
                            if (action.bindings.FirstOrDefault((OpenXRInteractionFeature.ActionBinding b) => b.interactionPath.Contains("thumbstick")) != null)
                            {
                                hasThumbstick = true;
                            }
                        }
                    }
                    foreach (OpenXRInteractionFeature.ActionConfig additiveAction in from a in additiveMap.actions
                                                                                     where a.isAdditive
                                                                                     select a)
                    {
                        if ((hasTrackPad && additiveAction.name.StartsWith("trackpad")) || (hasThumbstick && additiveAction.name.StartsWith("thumbstick")))
                        {
                            actionMap.actions.Add(additiveAction);
                        }
                    }
                }
            }
        }

        // Token: 0x040001ED RID: 493
        public const string featureId = "com.unity.openxr.feature.input.dpadinteraction";

        // Token: 0x040001EE RID: 494
        public float forceThresholdLeft = 0.5f;

        // Token: 0x040001EF RID: 495
        public float forceThresholdReleaseLeft = 0.4f;

        // Token: 0x040001F0 RID: 496
        public float centerRegionLeft = 0.5f;

        // Token: 0x040001F1 RID: 497
        public float wedgeAngleLeft = 1.5707964f;

        // Token: 0x040001F2 RID: 498
        public bool isStickyLeft;

        // Token: 0x040001F3 RID: 499
        public float forceThresholdRight = 0.5f;

        // Token: 0x040001F4 RID: 500
        public float forceThresholdReleaseRight = 0.4f;

        // Token: 0x040001F5 RID: 501
        public float centerRegionRight = 0.5f;

        // Token: 0x040001F6 RID: 502
        public float wedgeAngleRight = 1.5707964f;

        // Token: 0x040001F7 RID: 503
        public bool isStickyRight;

        // Token: 0x040001F8 RID: 504
        public const string thumbstickDpadUp = "/input/thumbstick/dpad_up";

        // Token: 0x040001F9 RID: 505
        public const string thumbstickDpadDown = "/input/thumbstick/dpad_down";

        // Token: 0x040001FA RID: 506
        public const string thumbstickDpadLeft = "/input/thumbstick/dpad_left";

        // Token: 0x040001FB RID: 507
        public const string thumbstickDpadRight = "/input/thumbstick/dpad_right";

        // Token: 0x040001FC RID: 508
        public const string trackpadDpadUp = "/input/trackpad/dpad_up";

        // Token: 0x040001FD RID: 509
        public const string trackpadDpadDown = "/input/trackpad/dpad_down";

        // Token: 0x040001FE RID: 510
        public const string trackpadDpadLeft = "/input/trackpad/dpad_left";

        // Token: 0x040001FF RID: 511
        public const string trackpadDpadRight = "/input/trackpad/dpad_right";

        // Token: 0x04000200 RID: 512
        public const string trackpadDpadCenter = "/input/trackpad/dpad_center";

        // Token: 0x04000201 RID: 513
        public const string profile = "/interaction_profiles/unity/dpad";

        // Token: 0x04000202 RID: 514
        private const string kDeviceLocalizedName = "DPad Interaction OpenXR";

        // Token: 0x04000203 RID: 515
        public string[] extensionStrings = new string[]
        {
            "XR_KHR_binding_modification",
            "XR_EXT_dpad_binding"
        };

        // Token: 0x02000050 RID: 80
        //[Preserve]
        [InputControlLayout(displayName = "D-Pad Binding (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        })]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class DPadDevice : XRController
        {

            // Token: 0x1700003D RID: 61
            // (get) Token: 0x060001B9 RID: 441 RVA: 0x00005E8B File Offset: 0x0000408B
            // (set) Token: 0x060001BA RID: 442 RVA: 0x00005E93 File Offset: 0x00004093
            //[Preserve]
            [InputControl]
            public ButtonControl thumbstickDpadUp;

            // Token: 0x1700003E RID: 62
            // (get) Token: 0x060001BB RID: 443 RVA: 0x00005E9C File Offset: 0x0000409C
            // (set) Token: 0x060001BC RID: 444 RVA: 0x00005EA4 File Offset: 0x000040A4
            [InputControl]
            //[Preserve]
            public ButtonControl thumbstickDpadDown;

            // Token: 0x1700003F RID: 63
            // (get) Token: 0x060001BD RID: 445 RVA: 0x00005EAD File Offset: 0x000040AD
            // (set) Token: 0x060001BE RID: 446 RVA: 0x00005EB5 File Offset: 0x000040B5
            //[Preserve]
            [InputControl]
            public ButtonControl thumbstickDpadLeft;

            // Token: 0x17000040 RID: 64
            // (get) Token: 0x060001BF RID: 447 RVA: 0x00005EBE File Offset: 0x000040BE
            // (set) Token: 0x060001C0 RID: 448 RVA: 0x00005EC6 File Offset: 0x000040C6
            [InputControl]
            //[Preserve]
            public ButtonControl thumbstickDpadRight;

            // Token: 0x17000041 RID: 65
            // (get) Token: 0x060001C1 RID: 449 RVA: 0x00005ECF File Offset: 0x000040CF
            // (set) Token: 0x060001C2 RID: 450 RVA: 0x00005ED7 File Offset: 0x000040D7
            //[Preserve]
            [InputControl]
            public ButtonControl trackpadDpadUp;

            // Token: 0x17000042 RID: 66
            // (get) Token: 0x060001C3 RID: 451 RVA: 0x00005EE0 File Offset: 0x000040E0
            // (set) Token: 0x060001C4 RID: 452 RVA: 0x00005EE8 File Offset: 0x000040E8
            //[Preserve]
            [InputControl]
            public ButtonControl trackpadDpadDown;

            // Token: 0x17000043 RID: 67
            // (get) Token: 0x060001C5 RID: 453 RVA: 0x00005EF1 File Offset: 0x000040F1
            // (set) Token: 0x060001C6 RID: 454 RVA: 0x00005EF9 File Offset: 0x000040F9
            //[Preserve]
            [InputControl]
            public ButtonControl trackpadDpadLeft;

            // Token: 0x17000044 RID: 68
            // (get) Token: 0x060001C7 RID: 455 RVA: 0x00005F02 File Offset: 0x00004102
            // (set) Token: 0x060001C8 RID: 456 RVA: 0x00005F0A File Offset: 0x0000410A
            //[Preserve]
            [InputControl]
            public ButtonControl trackpadDpadRight;

            // Token: 0x17000045 RID: 69
            // (get) Token: 0x060001C9 RID: 457 RVA: 0x00005F13 File Offset: 0x00004113
            // (set) Token: 0x060001CA RID: 458 RVA: 0x00005F1B File Offset: 0x0000411B
            //[Preserve]
            [InputControl]
            public ButtonControl trackpadDpadCenter;

            // Token: 0x060001CB RID: 459 RVA: 0x00005F24 File Offset: 0x00004124

            private bool setUp = false;
            public override void FinishSetup()
            {
                if (!setUp)
                {
                    setUp = true;
                    base.FinishSetup();
                    this.thumbstickDpadUp = base.GetChildControl<ButtonControl>("thumbstickDpadUp");
                    this.thumbstickDpadDown = base.GetChildControl<ButtonControl>("thumbstickDpadDown");
                    this.thumbstickDpadLeft = base.GetChildControl<ButtonControl>("thumbstickDpadLeft");
                    this.thumbstickDpadRight = base.GetChildControl<ButtonControl>("thumbstickDpadRight");
                    this.trackpadDpadUp = base.GetChildControl<ButtonControl>("trackpadDpadUp");
                    this.trackpadDpadDown = base.GetChildControl<ButtonControl>("trackpadDpadDown");
                    this.trackpadDpadLeft = base.GetChildControl<ButtonControl>("trackpadDpadLeft");
                    this.trackpadDpadRight = base.GetChildControl<ButtonControl>("trackpadDpadRight");
                    this.trackpadDpadCenter = base.GetChildControl<ButtonControl>("trackpadDpadCenter");
                }
            }
        }
    }
}
