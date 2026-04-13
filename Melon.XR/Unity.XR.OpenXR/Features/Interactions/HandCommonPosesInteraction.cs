using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Input;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x02000055 RID: 85
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class HandCommonPosesInteraction : OpenXRInteractionFeature
    {
        public HandCommonPosesInteraction() : base(ClassInjector.DerivedConstructorPointer<HandCommonPosesInteraction>()) => ClassInjector.DerivedConstructorBody(this);
        public HandCommonPosesInteraction(System.IntPtr ptr) : base(ptr) { }
        // Token: 0x17000047 RID: 71
        // (get) Token: 0x060001DF RID: 479 RVA: 0x000052E1 File Offset: 0x000034E1
        internal override bool IsAdditive
        {
            get
            {
                return true;
            }
        }

        // Token: 0x060001E0 RID: 480 RVA: 0x0000622C File Offset: 0x0000442C
        protected internal override bool OnInstanceCreate(ulong instance)
        {
            return OpenXRRuntime.IsExtensionEnabled("XR_EXT_hand_interaction") && base.OnInstanceCreate(instance);
        }

        // Token: 0x060001E1 RID: 481 RVA: 0x00006244 File Offset: 0x00004444
        protected override void RegisterDeviceLayout()
        {
            var typeFromHandle = Il2CppType.Of<HandCommonPosesInteraction.HandInteractionPoses>();
            string name = null;
            InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Hand Interaction Poses OpenXR", true)));
        }

        // Token: 0x060001E2 RID: 482 RVA: 0x00006288 File Offset: 0x00004488
        protected override void UnregisterDeviceLayout()
        {
            InputSystem.InputSystem.RemoveLayout("HandInteractionPoses");
        }

        // Token: 0x060001E3 RID: 483 RVA: 0x00006294 File Offset: 0x00004494
        [HideFromIl2Cpp]
        protected override OpenXRInteractionFeature.InteractionProfileType GetInteractionProfileType()
        {
            if (!typeof(HandCommonPosesInteraction.HandInteractionPoses).IsSubclassOf(typeof(XRController)))
            {
                return OpenXRInteractionFeature.InteractionProfileType.Device;
            }
            return OpenXRInteractionFeature.InteractionProfileType.XRController;
        }

        // Token: 0x060001E4 RID: 484 RVA: 0x000062B4 File Offset: 0x000044B4
        protected override string GetDeviceLayoutName()
        {
            return "HandInteractionPoses";
        }

        // Token: 0x060001E5 RID: 485 RVA: 0x000062BC File Offset: 0x000044BC
        protected override void RegisterActionMapsWithRuntime()
        {
            OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
            {
                name = "handinteractionposes",
                localizedName = "Hand Interaction Poses OpenXR",
                desiredInteractionProfile = "/interaction_profiles/unity/hand_interaction_poses",
                manufacturer = "",
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
                                interactionProfileName = "/interaction_profiles/unity/hand_interaction_poses"
                            }
                        },
                        isAdditive = true
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
                                interactionProfileName = "/interaction_profiles/unity/hand_interaction_poses"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "PokePose",
                        localizedName = "Poke Pose",
                        type = OpenXRInteractionFeature.ActionType.Pose,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/poke_ext/pose",
                                interactionProfileName = "/interaction_profiles/unity/hand_interaction_poses"
                            }
                        },
                        isAdditive = true
                    },
                    new OpenXRInteractionFeature.ActionConfig
                    {
                        name = "PinchPose",
                        localizedName = "Pinch Pose",
                        type = OpenXRInteractionFeature.ActionType.Pose,
                        bindings = new List<OpenXRInteractionFeature.ActionBinding>
                        {
                            new OpenXRInteractionFeature.ActionBinding
                            {
                                interactionPath = "/input/pinch_ext/pose",
                                interactionProfileName = "/interaction_profiles/unity/hand_interaction_poses"
                            }
                        },
                        isAdditive = true
                    }
                }
            };
            base.AddActionMap(actionMap);
        }

        // Token: 0x060001E6 RID: 486 RVA: 0x00006500 File Offset: 0x00004700
        [HideFromIl2Cpp]
        internal override void AddAdditiveActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, OpenXRInteractionFeature.ActionMapConfig additiveMap)
        {
            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                if ((from d in actionMap.deviceInfos
                     where d.userPath != null && (string.CompareOrdinal(d.userPath, "/user/hand/left") == 0 || string.CompareOrdinal(d.userPath, "/user/hand/right") == 0)
                     select d).Any<OpenXRInteractionFeature.DeviceConfig>())
                {
                    using (IEnumerator<OpenXRInteractionFeature.ActionConfig> enumerator2 = (from a in additiveMap.actions
                                                                                             where a.isAdditive
                                                                                             select a).GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            OpenXRInteractionFeature.ActionConfig additiveAction = enumerator2.Current;
                            bool duplicateFound = false;
                            Func<OpenXRInteractionFeature.ActionBinding, bool> predicate1 = null;
                            foreach (OpenXRInteractionFeature.ActionConfig poseAction in (from m in actionMap.actions
                                                                                          where m.type == OpenXRInteractionFeature.ActionType.Pose
                                                                                          select m).Distinct<OpenXRInteractionFeature.ActionConfig>().ToList<OpenXRInteractionFeature.ActionConfig>())
                            {
                                IEnumerable<OpenXRInteractionFeature.ActionBinding> bindings = poseAction.bindings;
                                Func<OpenXRInteractionFeature.ActionBinding, bool> predicate;
                                if ((predicate = predicate1) == null)
                                {
                                    predicate = (predicate1 = ((OpenXRInteractionFeature.ActionBinding b) => b.interactionPath != null && string.CompareOrdinal(b.interactionPath, additiveAction.bindings[0].interactionPath) == 0));
                                }
                                if (bindings.Where(predicate).Any<OpenXRInteractionFeature.ActionBinding>())
                                {
                                    poseAction.isAdditive = true;
                                    duplicateFound = true;
                                }
                            }
                            if (!duplicateFound)
                            {
                                actionMap.actions.Add(additiveAction);
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x0400021C RID: 540
        public const string featureId = "com.unity.openxr.feature.input.handinteractionposes";

        // Token: 0x0400021D RID: 541
        public const string profile = "/interaction_profiles/unity/hand_interaction_poses";

        // Token: 0x0400021E RID: 542
        public const string grip = "/input/grip/pose";

        // Token: 0x0400021F RID: 543
        public const string aim = "/input/aim/pose";

        // Token: 0x04000220 RID: 544
        public const string poke = "/input/poke_ext/pose";

        // Token: 0x04000221 RID: 545
        public const string pinch = "/input/pinch_ext/pose";

        // Token: 0x04000222 RID: 546
        private const string kDeviceLocalizedName = "Hand Interaction Poses OpenXR";

        // Token: 0x04000223 RID: 547
        public const string extensionString = "XR_EXT_hand_interaction";

        // Token: 0x02000056 RID: 86
        [InputControlLayout(displayName = "Hand Interaction Poses (OpenXR)", commonUsages = new string[]
        {
            "LeftHand",
            "RightHand"
        }, isGenericTypeOfDevice = true)]
        [MelonLoader.RegisterTypeInIl2Cpp(true)]
        ////[Preserve]
        public class HandInteractionPoses : OpenXRDevice
        {
            // Token: 0x17000048 RID: 72
            // (get) Token: 0x060001E8 RID: 488 RVA: 0x000066D4 File Offset: 0x000048D4
            // (set) Token: 0x060001E9 RID: 489 RVA: 0x000066DC File Offset: 0x000048DC
            [InputControl(offset = 0U, aliases = new string[]
            {
                "device",
                "gripPose"
            }, usage = "Device")]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl devicePose { get; private set; }

            // Token: 0x17000049 RID: 73
            // (get) Token: 0x060001EA RID: 490 RVA: 0x000066E5 File Offset: 0x000048E5
            // (set) Token: 0x060001EB RID: 491 RVA: 0x000066ED File Offset: 0x000048ED
            [InputControl(offset = 0U, alias = "aimPose", usage = "Pointer")]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl pointer { get; private set; }

            // Token: 0x1700004A RID: 74
            // (get) Token: 0x060001EC RID: 492 RVA: 0x000066F6 File Offset: 0x000048F6
            // (set) Token: 0x060001ED RID: 493 RVA: 0x000066FE File Offset: 0x000048FE
            [InputControl(offset = 0U)]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl pokePose { get; private set; }

            // Token: 0x1700004B RID: 75
            // (get) Token: 0x060001EE RID: 494 RVA: 0x00006707 File Offset: 0x00004907
            // (set) Token: 0x060001EF RID: 495 RVA: 0x0000670F File Offset: 0x0000490F
            [InputControl(offset = 0U)]
            //[Preserve]
            public UnityEngine.InputSystem.XR.PoseControl pinchPose { get; private set; }

            // Token: 0x060001F0 RID: 496 RVA: 0x00006718 File Offset: 0x00004918
            public override void FinishSetup()
            {
                base.FinishSetup();
                this.devicePose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("devicePose");
                this.pointer = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pointer");
                this.pokePose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pokePose");
                this.pinchPose = base.GetChildControl<UnityEngine.InputSystem.XR.PoseControl>("pinchPose");
            }
        }
    }
}
