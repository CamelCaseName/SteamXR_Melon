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
    // Token: 0x02000065 RID: 101
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class MicrosoftHandInteraction : OpenXRInteractionFeature
    {
        public MicrosoftHandInteraction() : base(ClassInjector.DerivedConstructorPointer<MicrosoftHandInteraction>()) => ClassInjector.DerivedConstructorBody(this);
        public MicrosoftHandInteraction(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x06000329 RID: 809 RVA: 0x0000A83C File Offset: 0x00008A3C
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<MicrosoftHandInteraction.HoloLensHand>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("HoloLens Hand OpenXR", true)));
        }

        // Token: 0x0600032A RID: 810 RVA: 0x0000A880 File Offset: 0x00008A80
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("HoloLensHand");
        }

        // Token: 0x0600032B RID: 811 RVA: 0x0000A88C File Offset: 0x00008A8C
        protected override string GetDeviceLayoutName()
        {
            return "HoloLensHand";
        }

        // Token: 0x0600032C RID: 812 RVA: 0x0000A894 File Offset: 0x00008A94
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "microsofthandinteraction",
                localizedName = "HoloLens Hand OpenXR",
                desiredInteractionProfile = "/interaction_profiles/microsoft/hand_interaction",
                manufacturer = "Microsoft",
                serialNumber = "",
                deviceInfos = new List<OpenXRInteractionFeature.DeviceConfig>
                {
                    new OpenXRInteractionFeature.DeviceConfig
                    {
                        characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left),
                        userPath = "/user/hand/left"
                    },
                    new OpenXRInteractionFeature.DeviceConfig
                    {
                        characteristics = (InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right),
                        userPath = "/user/hand/right"
                    }
                },
                actions = new List<OpenXRInteractionFeature.ActionConfig>
                {
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "select",
                        localizedName = "Select",
                        type = OpenXRInteractionFeature.ActionType.Axis1D,
                        usages = new List<string>
                        {
                            "PrimaryAxis"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/select/value",
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
                            }
                        }
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "selectPressed",
                        localizedName = "Select Pressed",
                        type = OpenXRInteractionFeature.ActionType.Binary,
                        usages = new List<string>
                        {
                            "PrimaryButton"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/select/value",
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
                            }
                        }
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "squeeze",
                        localizedName = "Squeeze",
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
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
                            }
                        }
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "squeezePressed",
                        localizedName = "Squeeze Pressed",
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
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
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
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
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
                                interactionProfileName = "/interaction_profiles/microsoft/hand_interaction"
                            }
                        }
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x0400031D RID: 797
        public const string featureId = "com.unity.openxr.feature.input.handtracking";

        // Token: 0x0400031E RID: 798
        public const string extensionString = "XR_MSFT_hand_interaction";

        // Token: 0x0400031F RID: 799
        public const string profile = "/interaction_profiles/microsoft/hand_interaction";

        // Token: 0x04000320 RID: 800
        public const string select = "/input/select/value";

        // Token: 0x04000321 RID: 801
        public const string squeeze = "/input/squeeze/value";

        // Token: 0x04000322 RID: 802
        public const string grip = "/input/grip/pose";

        // Token: 0x04000323 RID: 803
        public const string aim = "/input/aim/pose";

        // Token: 0x04000324 RID: 804
        private const string kDeviceLocalizedName = "HoloLens Hand OpenXR";

        // Token: 0x02000066 RID: 102
        //[Preserve]
        [InputControlLayout(displayName = "Hololens Hand (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        })]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class HoloLensHand : XRController
        {
            // Token: 0x170000CD RID: 205
            // (get) Token: 0x0600032E RID: 814 RVA: 0x0000ABB9 File Offset: 0x00008DB9
            // (set) Token: 0x0600032F RID: 815 RVA: 0x0000ABC1 File Offset: 0x00008DC1
            [InputControl(usage = "PrimaryAxis")]
            //[Preserve]
            public AxisControl select;

            // Token: 0x170000CE RID: 206
            // (get) Token: 0x06000330 RID: 816 RVA: 0x0000ABCA File Offset: 0x00008DCA
            // (set) Token: 0x06000331 RID: 817 RVA: 0x0000ABD2 File Offset: 0x00008DD2
            [InputControl(aliases = new string[]
            {
                "Primary",
                "selectbutton"
            }, usages = new string[]
            {
                "PrimaryButton"
            })]
            //[Preserve]
            public ButtonControl selectPressed;

            // Token: 0x170000CF RID: 207
            // (get) Token: 0x06000332 RID: 818 RVA: 0x0000ABDB File Offset: 0x00008DDB
            // (set) Token: 0x06000333 RID: 819 RVA: 0x0000ABE3 File Offset: 0x00008DE3
            //[Preserve]
            [InputControl(alias = "Secondary", usage = "Grip")]
            public AxisControl squeeze;

            // Token: 0x170000D0 RID: 208
            // (get) Token: 0x06000334 RID: 820 RVA: 0x0000ABEC File Offset: 0x00008DEC
            // (set) Token: 0x06000335 RID: 821 RVA: 0x0000ABF4 File Offset: 0x00008DF4
            [InputControl(aliases = new string[]
            {
                "GripButton",
                "squeezeClicked"
            }, usages = new string[]
            {
                "GripButton"
            })]
            //[Preserve]
            public ButtonControl squeezePressed;

            //todo replace all these inputcontrol attributes by our own and rebuild the properties
            // Token: 0x170000D1 RID: 209
            // (get) Token: 0x06000336 RID: 822 RVA: 0x0000ABFD File Offset: 0x00008DFD
            // (set) Token: 0x06000337 RID: 823 RVA: 0x0000AC05 File Offset: 0x00008E05
            [InputControl(offset = 0U, alias = "device", usage = "Device")]
            //[Preserve]
            public PoseControl devicePose;

            // Token: 0x170000D2 RID: 210
            // (get) Token: 0x06000338 RID: 824 RVA: 0x0000AC0E File Offset: 0x00008E0E
            // (set) Token: 0x06000339 RID: 825 RVA: 0x0000AC16 File Offset: 0x00008E16
            [InputControl(offset = 0U, usage = "Pointer")]
            //[Preserve]
            public PoseControl pointer;

            // Token: 0x170000D3 RID: 211
            // (get) Token: 0x0600033A RID: 826 RVA: 0x0000AC1F File Offset: 0x00008E1F
            // (set) Token: 0x0600033B RID: 827 RVA: 0x0000AC27 File Offset: 0x00008E27
            [InputControl(offset = 132U)]
            //[Preserve]
            public new ButtonControl isTracked;

            // Token: 0x170000D4 RID: 212
            // (get) Token: 0x0600033C RID: 828 RVA: 0x0000AC30 File Offset: 0x00008E30
            // (set) Token: 0x0600033D RID: 829 RVA: 0x0000AC38 File Offset: 0x00008E38
            [InputControl(offset = 136U)]
            //[Preserve]
            public new IntegerControl trackingState;

            // Token: 0x170000D5 RID: 213
            // (get) Token: 0x0600033E RID: 830 RVA: 0x0000AC41 File Offset: 0x00008E41
            // (set) Token: 0x0600033F RID: 831 RVA: 0x0000AC49 File Offset: 0x00008E49
            [InputControl(offset = 20U, alias = "gripPosition")]
            //[Preserve]
            public new Vector3Control devicePosition;

            // Token: 0x170000D6 RID: 214
            // (get) Token: 0x06000340 RID: 832 RVA: 0x0000AC52 File Offset: 0x00008E52
            // (set) Token: 0x06000341 RID: 833 RVA: 0x0000AC5A File Offset: 0x00008E5A
            [InputControl(offset = 32U, alias = "gripOrientation")]
            //[Preserve]
            public new QuaternionControl deviceRotation;

            // Token: 0x170000D7 RID: 215
            // (get) Token: 0x06000342 RID: 834 RVA: 0x0000AC63 File Offset: 0x00008E63
            // (set) Token: 0x06000343 RID: 835 RVA: 0x0000AC6B File Offset: 0x00008E6B
            //[Preserve]
            [InputControl(offset = 80U)]
            public Vector3Control pointerPosition;

            // Token: 0x170000D8 RID: 216
            // (get) Token: 0x06000344 RID: 836 RVA: 0x0000AC74 File Offset: 0x00008E74
            // (set) Token: 0x06000345 RID: 837 RVA: 0x0000AC7C File Offset: 0x00008E7C
            [InputControl(offset = 92U, alias = "pointerOrientation")]
            //[Preserve]
            public QuaternionControl pointerRotation;

            // Token: 0x06000346 RID: 838 RVA: 0x0000AC88 File Offset: 0x00008E88
            private bool setUp = false;
            public override void FinishSetup()
            {
                if (!setUp)
                {
                    setUp = true;
                    base.FinishSetup();
                    this.select = base.GetChildControl<AxisControl>("select");
                    this.selectPressed = base.GetChildControl<ButtonControl>("selectPressed");
                    this.squeeze = base.GetChildControl<AxisControl>("squeeze");
                    this.squeezePressed = base.GetChildControl<ButtonControl>("squeezePressed");
                    this.devicePose = base.GetChildControl<PoseControl>("devicePose");
                    this.pointer = base.GetChildControl<PoseControl>("pointer");
                    this.isTracked = base.GetChildControl<ButtonControl>("isTracked");
                    this.trackingState = base.GetChildControl<IntegerControl>("trackingState");
                    this.devicePosition = base.GetChildControl<Vector3Control>("devicePosition");
                    this.deviceRotation = base.GetChildControl<QuaternionControl>("deviceRotation");
                    this.pointerPosition = base.GetChildControl<Vector3Control>("pointerPosition");
                    this.pointerRotation = base.GetChildControl<QuaternionControl>("pointerRotation");
                }
            }
        }
    }
}