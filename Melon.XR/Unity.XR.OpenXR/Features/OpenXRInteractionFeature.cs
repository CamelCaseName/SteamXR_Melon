using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace UnityEngine.XR.OpenXR.Features
{
    // Token: 0x02000047 RID: 71
    [Serializable]
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRInteractionFeature : OpenXRFeature
    {
        public OpenXRInteractionFeature() : base(ClassInjector.DerivedConstructorPointer<OpenXRInteractionFeature>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRInteractionFeature(IntPtr ptr) : base(ptr) { }
        // Token: 0x1700003B RID: 59
        // (get) Token: 0x0600019F RID: 415 RVA: 0x0000249B File Offset: 0x0000069B
        internal virtual bool IsAdditive
        {
            get
            {
                return false;
            }
        }

        // Token: 0x060001A0 RID: 416 RVA: 0x00002355 File Offset: 0x00000555
        protected virtual void RegisterDeviceLayout()
        {
        }

        // Token: 0x060001A1 RID: 417 RVA: 0x00002355 File Offset: 0x00000555
        protected virtual void UnregisterDeviceLayout()
        {
        }

        // Token: 0x060001A2 RID: 418 RVA: 0x00002355 File Offset: 0x00000555
        protected virtual void RegisterActionMapsWithRuntime()
        {
        }

        // Token: 0x060001A3 RID: 419 RVA: 0x0000570A File Offset: 0x0000390A
        protected internal override bool OnInstanceCreate(ulong xrSession)
        {
            this.RegisterDeviceLayout();
            return true;
        }

        // Token: 0x060001A4 RID: 420 RVA: 0x000052E1 File Offset: 0x000034E1
        [HideFromIl2Cpp]
        protected virtual OpenXRInteractionFeature.InteractionProfileType GetInteractionProfileType()
        {
            return OpenXRInteractionFeature.InteractionProfileType.XRController;
        }

        // Token: 0x060001A5 RID: 421 RVA: 0x00005713 File Offset: 0x00003913
        protected virtual string GetDeviceLayoutName()
        {
            return "";
        }

        // Token: 0x060001A6 RID: 422 RVA: 0x0000571A File Offset: 0x0000391A
        [HideFromIl2Cpp]
        internal void CreateActionMaps(List<OpenXRInteractionFeature.ActionMapConfig> configs)
        {
            OpenXRInteractionFeature.m_CreatedActionMaps = configs;
            this.RegisterActionMapsWithRuntime();
            OpenXRInteractionFeature.m_CreatedActionMaps = null;
        }

        // Token: 0x060001A7 RID: 423 RVA: 0x0000572E File Offset: 0x0000392E
        [HideFromIl2Cpp]
        protected void AddActionMap(OpenXRInteractionFeature.ActionMapConfig map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }
            if (OpenXRInteractionFeature.m_CreatedActionMaps == null)
            {
                throw new InvalidOperationException("ActionMap must be added from within the RegisterActionMapsWithRuntime method");
            }
            OpenXRInteractionFeature.m_CreatedActionMaps.Add(map);
        }

        // Token: 0x060001A8 RID: 424 RVA: 0x00002355 File Offset: 0x00000555
        [HideFromIl2Cpp]
        internal virtual void AddAdditiveActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, OpenXRInteractionFeature.ActionMapConfig additiveMap)
        {
        }

        // Token: 0x060001A9 RID: 425 RVA: 0x0000575B File Offset: 0x0000395B
        protected internal override void OnEnabledChange()
        {
            base.OnEnabledChange();
        }

        // Token: 0x060001AA RID: 426 RVA: 0x00005764 File Offset: 0x00003964
        internal static void RegisterLayouts()
        {
            foreach (OpenXRFeature feature in OpenXRSettings.Instance.GetFeatures<OpenXRInteractionFeature>())
            {
                if (feature.enabled)
                {
                    ((OpenXRInteractionFeature)feature).RegisterDeviceLayout();
                }
            }
        }

        // Token: 0x040001CA RID: 458
        private static List<OpenXRInteractionFeature.ActionMapConfig> m_CreatedActionMaps = null;

        // Token: 0x040001CB RID: 459
        private static Dictionary<OpenXRInteractionFeature.InteractionProfileType, Dictionary<string, bool>> m_InteractionProfileEnabledMaps = new Dictionary<OpenXRInteractionFeature.InteractionProfileType, Dictionary<string, bool>>();

        // Token: 0x02000048 RID: 72
        [Serializable]
        public enum ActionType
        {
            // Token: 0x040001CD RID: 461
            Binary = 1,
            // Token: 0x040001CE RID: 462
            Axis1D = 2,
            // Token: 0x040001CF RID: 463
            Axis2D = 3,
            // Token: 0x040001D0 RID: 464
            Pose = 4,
            // Token: 0x040001D1 RID: 465
            Vibrate = 100,
            // Token: 0x040001D2 RID: 466
            Count
        }

        // Token: 0x02000049 RID: 73
        [Serializable]
        public class ActionBinding
        {
            // Token: 0x040001D3 RID: 467
            public string interactionProfileName;

            // Token: 0x040001D4 RID: 468
            public string interactionPath;

            // Token: 0x040001D5 RID: 469
            public List<string> userPaths;
        }

        // Token: 0x0200004A RID: 74
        [Serializable]
        public class ActionConfig
        {
            // Token: 0x040001D6 RID: 470
            public string name;

            // Token: 0x040001D7 RID: 471
            public OpenXRInteractionFeature.ActionType type;

            // Token: 0x040001D8 RID: 472
            public string localizedName;

            // Token: 0x040001D9 RID: 473
            public List<OpenXRInteractionFeature.ActionBinding> bindings;

            // Token: 0x040001DA RID: 474
            public List<string> usages;

            // Token: 0x040001DB RID: 475
            public bool isAdditive;
        }

        // Token: 0x0200004B RID: 75
        public class DeviceConfig
        {
            // Token: 0x040001DC RID: 476
            public InputDeviceCharacteristics characteristics;

            // Token: 0x040001DD RID: 477
            public string userPath;
        }

        // Token: 0x0200004C RID: 76
        [Serializable]
        public class ActionMapConfig
        {
            // Token: 0x040001DE RID: 478
            public string name;

            // Token: 0x040001DF RID: 479
            public string localizedName;

            // Token: 0x040001E0 RID: 480
            public List<OpenXRInteractionFeature.DeviceConfig> deviceInfos;

            // Token: 0x040001E1 RID: 481
            public List<OpenXRInteractionFeature.ActionConfig> actions;

            // Token: 0x040001E2 RID: 482
            public string desiredInteractionProfile;

            // Token: 0x040001E3 RID: 483
            public string manufacturer;

            // Token: 0x040001E4 RID: 484
            public string serialNumber;
        }

        // Token: 0x0200004D RID: 77
        public static class UserPaths
        {
            // Token: 0x040001E5 RID: 485
            public const string leftHand = "/user/hand/left";

            // Token: 0x040001E6 RID: 486
            public const string rightHand = "/user/hand/right";

            // Token: 0x040001E7 RID: 487
            public const string head = "/user/head";

            // Token: 0x040001E8 RID: 488
            public const string gamepad = "/user/gamepad";

            // Token: 0x040001E9 RID: 489
            public const string treadmill = "/user/treadmill";
        }

        // Token: 0x0200004E RID: 78
        public enum InteractionProfileType
        {
            // Token: 0x040001EB RID: 491
            Device,
            // Token: 0x040001EC RID: 492
            XRController
        }
    }
}
