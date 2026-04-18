using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using System.Collections.Generic;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Input;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x02000052 RID: 82
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class EyeGazeInteraction : OpenXRInteractionFeature
    {
        public EyeGazeInteraction() : base(ClassInjector.DerivedConstructorPointer<EyeGazeInteraction>()) => ClassInjector.DerivedConstructorBody(this);
        public EyeGazeInteraction(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x060001D3 RID: 467 RVA: 0x00006043 File Offset: 0x00004243
        protected internal override bool OnInstanceCreate(ulong instance)
        {
            return OpenXRRuntime.IsExtensionEnabled("XR_EXT_eye_gaze_interaction") && base.OnInstanceCreate(instance);
        }

        // Token: 0x060001D4 RID: 468 RVA: 0x0000605C File Offset: 0x0000425C
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<EyeGazeInteraction.EyeGazeDevice>();
            string name = "EyeGaze";
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Eye Tracking OpenXR", true)));
        }

        // Token: 0x060001D5 RID: 469 RVA: 0x000060A4 File Offset: 0x000042A4
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("EyeGaze");
        }

        // Token: 0x060001D6 RID: 470 RVA: 0x000060B0 File Offset: 0x000042B0
        [HideFromIl2Cpp]
        protected override OpenXRInteractionFeature.InteractionProfileType GetInteractionProfileType()
        {
            if (!typeof(EyeGazeInteraction.EyeGazeDevice).IsSubclassOf(typeof(XRController)))
            {
                return OpenXRInteractionFeature.InteractionProfileType.Device;
            }
            return OpenXRInteractionFeature.InteractionProfileType.XRController;
        }

        // Token: 0x060001D7 RID: 471 RVA: 0x000060D0 File Offset: 0x000042D0
        protected override string GetDeviceLayoutName()
        {
            return "EyeGaze";
        }

        // Token: 0x060001D8 RID: 472 RVA: 0x000060D8 File Offset: 0x000042D8
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "eyegaze",
                localizedName = "Eye Tracking OpenXR",
                desiredInteractionProfile = "/interaction_profiles/ext/eye_gaze_interaction",
                manufacturer = "",
                serialNumber = "",
                deviceInfos = new List<OpenXRInteractionFeature.DeviceConfig>
                {
                    new OpenXRInteractionFeature.DeviceConfig
                    {
                        characteristics = (InputDeviceCharacteristics.HeadMounted | InputDeviceCharacteristics.EyeTracking | InputDeviceCharacteristics.TrackedDevice),
                        userPath = "/user/eyes_ext"
                    }
                },
                actions = new List<OpenXRInteractionFeature.ActionConfig>
                {
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "pose",
                        localizedName = "Pose",
                        type = OpenXRInteractionFeature.ActionType.Pose,
                        usages = new List<string>
                        {
                            "Device",
                            "gaze"
                        },
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/gaze_ext/pose",
                                interactionProfileName = "/interaction_profiles/ext/eye_gaze_interaction"
                            }
                        }
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x04000212 RID: 530
        public const string featureId = "com.unity.openxr.feature.input.eyetracking";

        // Token: 0x04000213 RID: 531
        private const string userPath = "/user/eyes_ext";

        // Token: 0x04000214 RID: 532
        private const string profile = "/interaction_profiles/ext/eye_gaze_interaction";

        // Token: 0x04000215 RID: 533
        private const string pose = "/input/gaze_ext/pose";

        // Token: 0x04000216 RID: 534
        private const string kDeviceLocalizedName = "Eye Tracking OpenXR";

        // Token: 0x04000217 RID: 535
        public const string extensionString = "XR_EXT_eye_gaze_interaction";

        // Token: 0x04000218 RID: 536
        private const string layoutName = "EyeGaze";

        // Token: 0x02000053 RID: 83
        //[Preserve]
        [InputControlLayout(displayName = "Eye Gaze (OpenXR)", isGenericTypeOfDevice = true)]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        public class EyeGazeDevice : OpenXRDevice
        {
            // Token: 0x17000046 RID: 70
            // (get) Token: 0x060001DA RID: 474 RVA: 0x000061DA File Offset: 0x000043DA
            // (set) Token: 0x060001DB RID: 475 RVA: 0x000061E2 File Offset: 0x000043E2
            //[Preserve]
            [InputControl(offset = 0U, usages = new string[]
            {
                "Device",
                "gaze"
            })]
            public UnityEngine.InputSystem.XR.PoseControl pose;

            // Token: 0x060001DC RID: 476 RVA: 0x000061EB File Offset: 0x000043EB
            private bool setUp = false;
            public override void FinishSetup()
            {
                if (!setUp)
                {
                    setUp = true;
                    base.FinishSetup();
                    this.pose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pose");
                }
            }
        }
    }
}
