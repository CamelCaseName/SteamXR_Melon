using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.XR;

namespace UnityEngine.XR.OpenXR.Features.Interactions
{
    // Token: 0x0200006B RID: 107
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class PalmPoseInteraction : OpenXRInteractionFeature
    {
        public PalmPoseInteraction() : base(ClassInjector.DerivedConstructorPointer<PalmPoseInteraction>()) => ClassInjector.DerivedConstructorBody(this);
        public PalmPoseInteraction(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000103 RID: 259
        // (get) Token: 0x060003AA RID: 938 RVA: 0x000052E1 File Offset: 0x000034E1
        internal override bool IsAdditive
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000C316 File Offset: 0x0000A516
		protected internal override bool OnInstanceCreate(ulong instance)
		{
			return OpenXRRuntime.IsExtensionEnabled("XR_EXT_palm_pose") && base.OnInstanceCreate(instance);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000C330 File Offset: 0x0000A530
		protected override void RegisterDeviceLayout()
		{
			var typeFromHandle = Il2CppType.Of< PalmPoseInteraction.PalmPose>();
			string name = null;
			InputDeviceMatcher inputDeviceMatcher = default(InputDeviceMatcher);
			inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
			InputSystem.InputSystem.RegisterLayout(typeFromHandle, name, new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher.WithProduct("Palm Pose Interaction OpenXR", true)));
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000C374 File Offset: 0x0000A574
		protected override void UnregisterDeviceLayout()
		{
			InputSystem.InputSystem.RemoveLayout("PalmPose");
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000C380 File Offset: 0x0000A580
		protected override string GetDeviceLayoutName()
		{
			return "PalmPose";
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000C388 File Offset: 0x0000A588
		protected override void RegisterActionMapsWithRuntime()
		{
			OpenXRInteractionFeature.ActionMapConfig actionMap = new OpenXRInteractionFeature.ActionMapConfig
			{
				name = "palmposeinteraction",
				localizedName = "Palm Pose Interaction OpenXR",
				desiredInteractionProfile = "/interaction_profiles/ext/palmpose",
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
						name = "palmpose",
						localizedName = "Palm Pose",
						type = OpenXRInteractionFeature.ActionType.Pose,
						bindings = this.AddBindingBasedOnRuntimeAPIVersion(),
						isAdditive = true
					}
				}
			};
			base.AddActionMap(actionMap);
		}

        // Token: 0x060003B0 RID: 944 RVA: 0x0000C46C File Offset: 0x0000A66C
        [HideFromIl2Cpp]
        internal List<OpenXRInteractionFeature.ActionBinding> AddBindingBasedOnRuntimeAPIVersion()
		{
			List<OpenXRInteractionFeature.ActionBinding> pairingActionBinding;
			if (OpenXRRuntime.isRuntimeAPIVersionGreaterThan1_1())
			{
				pairingActionBinding = new List<OpenXRInteractionFeature.ActionBinding>
				{
					new OpenXRInteractionFeature.ActionBinding
					{
						interactionPath = "/input/grip_surface/pose",
						interactionProfileName = "/interaction_profiles/ext/palmpose"
					}
				};
			}
			else
			{
				pairingActionBinding = new List<OpenXRInteractionFeature.ActionBinding>
				{
					new OpenXRInteractionFeature.ActionBinding
					{
						interactionPath = "/input/palm_ext/pose",
						interactionProfileName = "/interaction_profiles/ext/palmpose"
					}
				};
			}
			return pairingActionBinding;
		}

        // Token: 0x060003B1 RID: 945 RVA: 0x0000C4D4 File Offset: 0x0000A6D4
        [HideFromIl2Cpp]
        internal override void AddAdditiveActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, OpenXRInteractionFeature.ActionMapConfig additiveMap)
		{
			foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
			{
				if ((from d in actionMap.deviceInfos
				where d.userPath != null && (string.CompareOrdinal(d.userPath, "/user/hand/left") == 0 || string.CompareOrdinal(d.userPath, "/user/hand/right") == 0)
				select d).Any<OpenXRInteractionFeature.DeviceConfig>())
				{
					foreach (OpenXRInteractionFeature.ActionConfig additiveAction in from a in additiveMap.actions
					where a.isAdditive
					select a)
					{
						actionMap.actions.Add(additiveAction);
					}
				}
			}
		}

		// Token: 0x04000380 RID: 896
		public const string featureId = "com.unity.openxr.feature.input.palmpose";

		// Token: 0x04000381 RID: 897
		public const string palmPose = "/input/palm_ext/pose";

		// Token: 0x04000382 RID: 898
		public const string gripSurfacePose = "/input/grip_surface/pose";

		// Token: 0x04000383 RID: 899
		public const string profile = "/interaction_profiles/ext/palmpose";

		// Token: 0x04000384 RID: 900
		private const string kDeviceLocalizedName = "Palm Pose Interaction OpenXR";

		// Token: 0x04000385 RID: 901
		public const string extensionString = "XR_EXT_palm_pose";

		// Token: 0x0200006C RID: 108
		//[InputControlLayout(displayName = "Palm Pose (OpenXR)", commonUsages = new string[]
		//{
		//	"LeftHand",
		//	"RightHand"
		//})]
		//[Preserve]
		public class PalmPose : XRController
		{
			// Token: 0x17000104 RID: 260
			// (get) Token: 0x060003B3 RID: 947 RVA: 0x0000C5B8 File Offset: 0x0000A7B8
			// (set) Token: 0x060003B4 RID: 948 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
			//[Preserve]
			//[InputControl(offset = 0U)]
			public PoseControl palmPose { get; private set; }

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x060003B5 RID: 949 RVA: 0x0000C5C9 File Offset: 0x0000A7C9
			// (set) Token: 0x060003B6 RID: 950 RVA: 0x0000C5D1 File Offset: 0x0000A7D1
			//[InputControl(offset = 0U)]
			//[Preserve]
			public new ButtonControl isTracked { get; private set; }

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000C5DA File Offset: 0x0000A7DA
			// (set) Token: 0x060003B8 RID: 952 RVA: 0x0000C5E2 File Offset: 0x0000A7E2
			//[InputControl(offset = 4U)]
			//[Preserve]
			public new IntegerControl trackingState { get; private set; }

			// Token: 0x17000107 RID: 263
			// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000C5EB File Offset: 0x0000A7EB
			// (set) Token: 0x060003BA RID: 954 RVA: 0x0000C5F3 File Offset: 0x0000A7F3
			//[InputControl(offset = 8U, noisy = true, alias = "palmPosition")]
			//[Preserve]
			public new Vector3Control devicePosition { get; private set; }

			// Token: 0x17000108 RID: 264
			// (get) Token: 0x060003BB RID: 955 RVA: 0x0000C5FC File Offset: 0x0000A7FC
			// (set) Token: 0x060003BC RID: 956 RVA: 0x0000C604 File Offset: 0x0000A804
			//[Preserve]
			//[InputControl(offset = 20U, noisy = true, alias = "palmRotation")]
			public new QuaternionControl deviceRotation { get; private set; }

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x060003BD RID: 957 RVA: 0x0000C60D File Offset: 0x0000A80D
			// (set) Token: 0x060003BE RID: 958 RVA: 0x0000C615 File Offset: 0x0000A815
			//[Preserve]
			//[InputControl(offset = 8U, noisy = true)]
			public Vector3Control palmPosition { get; private set; }

			// Token: 0x1700010A RID: 266
			// (get) Token: 0x060003BF RID: 959 RVA: 0x0000C61E File Offset: 0x0000A81E
			// (set) Token: 0x060003C0 RID: 960 RVA: 0x0000C626 File Offset: 0x0000A826
			//[Preserve]
			//[InputControl(offset = 20U, noisy = true)]
			public QuaternionControl palmRotation { get; private set; }

			// Token: 0x060003C1 RID: 961 RVA: 0x0000C62F File Offset: 0x0000A82F
			public override void FinishSetup()
			{
				base.FinishSetup();
				this.palmPose = base.GetChildControl<PoseControl>("palmPose");
			}
		}
	}
}
