using Il2CppInterop.Runtime.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine.XR.OpenXR.Features;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x02000004 RID: 4
	[Serializable]
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRSettings : ScriptableObject
    {
        public OpenXRSettings(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
        public int featureCount
		{
			get
			{
				return this.features.Length;
			}
		}

        // Token: 0x06000004 RID: 4 RVA: 0x000020CA File Offset: 0x000002CA
        [HideFromIl2Cpp]
        public TFeature GetFeature<TFeature>() where TFeature : OpenXRFeature
		{
			return (TFeature)((object)this.GetFeature(typeof(TFeature)));
		}

        // Token: 0x06000005 RID: 5 RVA: 0x000020E4 File Offset: 0x000002E4
        [HideFromIl2Cpp]
        public OpenXRFeature GetFeature(Type featureType)
		{
			foreach (OpenXRFeature feature in this.features)
			{
				if (featureType.IsInstanceOfType(feature))
				{
					return feature;
				}
			}
			return null;
		}

        // Token: 0x06000006 RID: 6 RVA: 0x00002116 File Offset: 0x00000316
        [HideFromIl2Cpp]
        public OpenXRFeature[] GetFeatures<TFeature>()
		{
			return this.GetFeatures(typeof(TFeature));
		}

        // Token: 0x06000007 RID: 7 RVA: 0x00002128 File Offset: 0x00000328
        [HideFromIl2Cpp]
        public OpenXRFeature[] GetFeatures(Type featureType)
		{
			List<OpenXRFeature> result = new List<OpenXRFeature>();
			foreach (OpenXRFeature feature in this.features)
			{
				if (featureType.IsInstanceOfType(feature))
				{
					result.Add(feature);
				}
			}
			return result.ToArray();
		}

        // Token: 0x06000008 RID: 8 RVA: 0x0000216C File Offset: 0x0000036C
        [HideFromIl2Cpp]
        public int GetFeatures<TFeature>(List<TFeature> featuresOut) where TFeature : OpenXRFeature
		{
			featuresOut.Clear();
			OpenXRFeature[] array = this.features;
			for (int i = 0; i < array.Length; i++)
			{
				TFeature xrFeature = array[i] as TFeature;
				if (xrFeature != null)
				{
					featuresOut.Add(xrFeature);
				}
			}
			return featuresOut.Count;
		}

        // Token: 0x06000009 RID: 9 RVA: 0x000021B8 File Offset: 0x000003B8
        [HideFromIl2Cpp]
        public int GetFeatures(Type featureType, List<OpenXRFeature> featuresOut)
		{
			featuresOut.Clear();
			foreach (OpenXRFeature feature in this.features)
			{
				if (featureType.IsInstanceOfType(feature))
				{
					featuresOut.Add(feature);
				}
			}
			return featuresOut.Count;
		}

        // Token: 0x0600000A RID: 10 RVA: 0x000021FA File Offset: 0x000003FA
        [HideFromIl2Cpp]
        public OpenXRFeature[] GetFeatures()
		{
			OpenXRFeature[] array = this.features;
			return ((OpenXRFeature[])((array != null) ? array.Clone() : null)) ?? new OpenXRFeature[0];
		}

        // Token: 0x0600000B RID: 11 RVA: 0x0000221D File Offset: 0x0000041D
        [HideFromIl2Cpp]
        public int GetFeatures(List<OpenXRFeature> featuresOut)
		{
			featuresOut.Clear();
			featuresOut.AddRange(this.features);
			return featuresOut.Count;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002237 File Offset: 0x00000437
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002252 File Offset: 0x00000452
		public OpenXRSettings.RenderMode renderMode
		{
			get
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					return OpenXRSettings.Internal_GetRenderMode();
				}
				return this.m_renderMode;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetRenderMode(value);
					return;
				}
				this.m_renderMode = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000226F File Offset: 0x0000046F
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002277 File Offset: 0x00000477
		public bool autoColorSubmissionMode
		{
			get
			{
				return this.m_autoColorSubmissionMode;
			}
			set
			{
				this.m_autoColorSubmissionMode = value;
			}
		}

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000010 RID: 16 RVA: 0x00002280 File Offset: 0x00000480
        // (set) Token: 0x06000011 RID: 17 RVA: 0x000022FC File Offset: 0x000004FC
        [HideFromIl2Cpp]
        public OpenXRSettings.ColorSubmissionModeGroup[] colorSubmissionModes
		{
			get
			{
				if (this.m_autoColorSubmissionMode)
				{
					return new OpenXRSettings.ColorSubmissionModeGroup[]
					{
						OpenXRSettings.kDefaultColorMode
					};
				}
				if (OpenXRLoaderBase.Instance != null)
				{
					int arraySize = OpenXRSettings.Internal_GetColorSubmissionModes(null, 0);
					int[] array = new int[arraySize];
					OpenXRSettings.Internal_GetColorSubmissionModes(array, arraySize);
					return (from i in array
					select (OpenXRSettings.ColorSubmissionModeGroup)i).ToArray<OpenXRSettings.ColorSubmissionModeGroup>();
				}
				return this.m_colorSubmissionModes.m_List;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetColorSubmissionModes((from e in value
					select (int)e).ToArray<int>(), value.Length);
					return;
				}
				this.m_colorSubmissionModes.m_List = value;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002355 File Offset: 0x00000555
		private static void PermissionGrantedCallback(string permissionName)
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002357 File Offset: 0x00000557
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002372 File Offset: 0x00000572
		public OpenXRSettings.DepthSubmissionMode depthSubmissionMode
		{
			get
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					return OpenXRSettings.Internal_GetDepthSubmissionMode();
				}
				return this.m_depthSubmissionMode;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetDepthSubmissionMode(value);
					return;
				}
				this.m_depthSubmissionMode = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000238F File Offset: 0x0000058F
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000023AA File Offset: 0x000005AA
		public OpenXRSettings.SpaceWarpMotionVectorTextureFormat spacewarpMotionVectorTextureFormat
		{
			get
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					return OpenXRSettings.Internal_GetSpaceWarpMotionVectorTextureFormat();
				}
				return this.m_spacewarpMotionVectorTextureFormat;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetSpaceWarpMotionVectorTextureFormat(value);
					return;
				}
				this.m_spacewarpMotionVectorTextureFormat = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000023C7 File Offset: 0x000005C7
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000023CF File Offset: 0x000005CF
		public bool optimizeBufferDiscards
		{
			get
			{
				return this.m_optimizeBufferDiscards;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetOptimizeBufferDiscards(value);
					return;
				}
				this.m_optimizeBufferDiscards = value;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000023EC File Offset: 0x000005EC
		private void ApplyRenderSettings()
		{
			OpenXRSettings.Internal_SetSymmetricProjection(this.m_symmetricProjection);
			OpenXRSettings.Internal_SetRenderMode(this.m_renderMode);
			OpenXRSettings.Internal_SetColorSubmissionModes((from e in this.m_colorSubmissionModes.m_List
			select (int)e).ToArray<int>(), this.m_colorSubmissionModes.m_List.Length);
			OpenXRSettings.Internal_SetDepthSubmissionMode(this.m_depthSubmissionMode);
			OpenXRSettings.Internal_SetSpaceWarpMotionVectorTextureFormat(this.m_spacewarpMotionVectorTextureFormat);
			OpenXRSettings.Internal_SetOptimizeBufferDiscards(this.m_optimizeBufferDiscards);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002476 File Offset: 0x00000676
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000247E File Offset: 0x0000067E
		public bool symmetricProjection
		{
			get
			{
				return this.m_symmetricProjection;
			}
			set
			{
				if (OpenXRLoaderBase.Instance != null)
				{
					OpenXRSettings.Internal_SetSymmetricProjection(value);
					return;
				}
				this.m_symmetricProjection = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000249B File Offset: 0x0000069B
		public OpenXRSettings.BackendFovationApi foveatedRenderingApi
		{
			get
			{
				return OpenXRSettings.BackendFovationApi.Legacy;
			}
		}

		// Token: 0x0600001D RID: 29
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetRenderMode")]
		private static extern void Internal_SetRenderMode(OpenXRSettings.RenderMode renderMode);

		// Token: 0x0600001E RID: 30
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetRenderMode")]
		private static extern OpenXRSettings.RenderMode Internal_GetRenderMode();

		// Token: 0x0600001F RID: 31
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetDepthSubmissionMode")]
		private static extern void Internal_SetDepthSubmissionMode(OpenXRSettings.DepthSubmissionMode depthSubmissionMode);

		// Token: 0x06000020 RID: 32
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetDepthSubmissionMode")]
		private static extern OpenXRSettings.DepthSubmissionMode Internal_GetDepthSubmissionMode();

		// Token: 0x06000021 RID: 33
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetSpaceWarpMotionVectorTextureFormat")]
		private static extern void Internal_SetSpaceWarpMotionVectorTextureFormat(OpenXRSettings.SpaceWarpMotionVectorTextureFormat spaceWarpMotionVectorTextureFormat);

		// Token: 0x06000022 RID: 34
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetSpaceWarpMotionVectorTextureFormat")]
		private static extern OpenXRSettings.SpaceWarpMotionVectorTextureFormat Internal_GetSpaceWarpMotionVectorTextureFormat();

		// Token: 0x06000023 RID: 35
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetSymmetricProjection")]
		private static extern void Internal_SetSymmetricProjection([MarshalAs(UnmanagedType.I1)] bool enabled);

		// Token: 0x06000024 RID: 36
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetOptimizeMultiviewRenderRegions")]
		private static extern void Internal_SetOptimizeMultiviewRenderRegions([MarshalAs(UnmanagedType.I1)] bool enabled);

		// Token: 0x06000025 RID: 37
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetOptimizeBufferDiscards")]
		private static extern void Internal_SetOptimizeBufferDiscards([MarshalAs(UnmanagedType.I1)] bool enabled);

		// Token: 0x06000026 RID: 38
		[DllImport("UnityOpenXR", EntryPoint = "OculusFoveation_SetUsedApi")]
		private static extern void Internal_SetUsedFoveatedRenderingApi(OpenXRSettings.BackendFovationApi api);

		// Token: 0x06000027 RID: 39
		[DllImport("UnityOpenXR", EntryPoint = "OculusFoveation_GetUsedApi")]
		internal static extern OpenXRSettings.BackendFovationApi Internal_GetUsedFoveatedRenderingApi();

		// Token: 0x06000028 RID: 40
		[DllImport("UnityOpenXR", EntryPoint = "OculusFoveation_HasRequestedEyeTrackingPermissions")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool Internal_HasRequestedEyeTrackingPermissions();

		// Token: 0x06000029 RID: 41
		[DllImport("UnityOpenXR", EntryPoint = "OculusFoveation_GetHasEyeTrackingPermissions")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool Internal_GetHasEyeTrackingPermissions();

		// Token: 0x0600002A RID: 42
		[DllImport("UnityOpenXR", EntryPoint = "OculusFoveation_SetHasEyeTrackingPermissions")]
		internal static extern void Internal_SetHasEyeTrackingPermissions([MarshalAs(UnmanagedType.I1)] bool value);

		// Token: 0x0600002B RID: 43
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetColorSubmissionMode")]
		private static extern void Internal_SetColorSubmissionMode(OpenXRSettings.ColorSubmissionModeGroup[] colorSubmissionMode);

		// Token: 0x0600002C RID: 44
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetColorSubmissionModes")]
		private static extern void Internal_SetColorSubmissionModes(int[] colorSubmissionMode, int arraySize);

		// Token: 0x0600002D RID: 45
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetColorSubmissionModes")]
		private static extern int Internal_GetColorSubmissionModes([Out] int[] colorSubmissionMode, int arraySize);

		// Token: 0x0600002E RID: 46
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetIsUsingLegacyXRDisplay")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetIsUsingLegacyXRDisplay();

		// Token: 0x0600002F RID: 47 RVA: 0x0000249E File Offset: 0x0000069E
		private void Awake()
		{
			OpenXRSettings.s_RuntimeInstance = this;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000024A6 File Offset: 0x000006A6
		internal void ApplySettings()
		{
			this.ApplyRenderSettings();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000024B0 File Offset: 0x000006B0
		private static OpenXRSettings GetInstance(bool useActiveBuildTarget)
		{
			OpenXRSettings settings = OpenXRSettings.s_RuntimeInstance;
			if (settings == null)
			{
				settings = ScriptableObject.CreateInstance<OpenXRSettings>();
				Object.DontDestroyOnLoad(settings);
			}
			return settings;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000024D5 File Offset: 0x000006D5
		public static OpenXRSettings ActiveBuildTargetInstance
		{
			get
			{
				return OpenXRSettings.GetInstance(true);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024DD File Offset: 0x000006DD
		public static OpenXRSettings Instance
		{
			get
			{
				return OpenXRSettings.GetInstance(false);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000024E5 File Offset: 0x000006E5
		public static void SetAllowRecentering(bool allowRecentering, float floorOffset = 1.5f)
		{
			OpenXRSettings.Internal_SetAllowRecentering(allowRecentering, floorOffset);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000024EE File Offset: 0x000006EE
		public static void RefreshRecenterSpace()
		{
			OpenXRSettings.Internal_RegenerateTrackingOrigin();
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000024F5 File Offset: 0x000006F5
		public static bool AllowRecentering
		{
			get
			{
				return OpenXRSettings.Internal_GetAllowRecentering();
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000024FC File Offset: 0x000006FC
		public static float FloorOffset
		{
			get
			{
				return OpenXRSettings.Internal_GetFloorOffset();
			}
		}

		// Token: 0x06000038 RID: 56
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetAllowRecentering")]
		private static extern void Internal_SetAllowRecentering([MarshalAs(UnmanagedType.U1)] bool active, float height);

		// Token: 0x06000039 RID: 57
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_RegenerateTrackingOrigin")]
		private static extern void Internal_RegenerateTrackingOrigin();

		// Token: 0x0600003A RID: 58
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetAllowRecentering")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetAllowRecentering();

		// Token: 0x0600003B RID: 59
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetFloorOffsetHeight")]
		private static extern float Internal_GetFloorOffset();

		// Token: 0x04000006 RID: 6
		//[SerializeField]
		//[FormerlySerializedAs("extensions")]
		//[HideInInspector]
		internal OpenXRFeature[] features = new OpenXRFeature[0];

		// Token: 0x04000007 RID: 7
		public static readonly OpenXRSettings.ColorSubmissionModeGroup kDefaultColorMode;

		// Token: 0x04000008 RID: 8
		//[SerializeField]
		private OpenXRSettings.RenderMode m_renderMode = OpenXRSettings.RenderMode.SinglePassInstanced;

		// Token: 0x04000009 RID: 9
		//[SerializeField]
		private bool m_autoColorSubmissionMode = true;

		// Token: 0x0400000A RID: 10
		//[SerializeField]
		private OpenXRSettings.ColorSubmissionModeList m_colorSubmissionModes = new OpenXRSettings.ColorSubmissionModeList();

		// Token: 0x0400000B RID: 11
		//[SerializeField]
		private OpenXRSettings.DepthSubmissionMode m_depthSubmissionMode;

		// Token: 0x0400000C RID: 12
		//[SerializeField]
		private OpenXRSettings.SpaceWarpMotionVectorTextureFormat m_spacewarpMotionVectorTextureFormat;

		// Token: 0x0400000D RID: 13
		//[SerializeField]
		private bool m_optimizeBufferDiscards;

		// Token: 0x0400000E RID: 14
		//[SerializeField]
		private bool m_symmetricProjection;

		// Token: 0x0400000F RID: 15
		private const string LibraryName = "UnityOpenXR";

		// Token: 0x04000010 RID: 16
		private static OpenXRSettings s_RuntimeInstance;

		// Token: 0x02000005 RID: 5
		public enum ColorSubmissionModeGroup
		{
			// Token: 0x04000012 RID: 18
			//[InspectorName("8 bits per channel (LDR, default)")]
			kRenderTextureFormatGroup8888,
			// Token: 0x04000013 RID: 19
			//[InspectorName("10 bits floating-point per color channel, 2 bit alpha (HDR)")]
			kRenderTextureFormatGroup1010102_Float,
			// Token: 0x04000014 RID: 20
			//[InspectorName("16 bits floating-point per channel (HDR)")]
			kRenderTextureFormatGroup16161616_Float,
			// Token: 0x04000015 RID: 21
			//[InspectorName("5,6,5 bit packed (LDR, mobile)")]
			kRenderTextureFormatGroup565,
			// Token: 0x04000016 RID: 22
			//[InspectorName("11,11,10 bit packed floating-point (HDR)")]
			kRenderTextureFormatGroup111110_Float
		}

		// Token: 0x02000006 RID: 6
		[Serializable]
		public class ColorSubmissionModeList
		{
			// Token: 0x04000017 RID: 23
			public OpenXRSettings.ColorSubmissionModeGroup[] m_List = new OpenXRSettings.ColorSubmissionModeGroup[1];
		}

		// Token: 0x02000007 RID: 7
		public enum RenderMode
		{
			// Token: 0x04000019 RID: 25
			MultiPass,
			// Token: 0x0400001A RID: 26
			SinglePassInstanced
		}

		// Token: 0x02000008 RID: 8
		public enum DepthSubmissionMode
		{
			// Token: 0x0400001C RID: 28
			None,
			// Token: 0x0400001D RID: 29
			Depth16Bit,
			// Token: 0x0400001E RID: 30
			Depth24Bit
		}

		// Token: 0x02000009 RID: 9
		public enum BackendFovationApi : byte
		{
			// Token: 0x04000020 RID: 32
			Legacy,
			// Token: 0x04000021 RID: 33
			SRPFoveation
		}

		// Token: 0x0200000A RID: 10
		public enum SpaceWarpMotionVectorTextureFormat
		{
			// Token: 0x04000023 RID: 35
			RGBA16f,
			// Token: 0x04000024 RID: 36
			RG16f
		}
	}
}
