using Il2CppInterop.Runtime.Injection;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;
using UnityEngine.XR.OpenXR.Features.Extensions.PerformanceSettings;

namespace UnityEngine.XR.OpenXR.Features
{
    // Token: 0x02000042 RID: 66
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class FoveatedRenderingFeature : OpenXRFeature
    {
        public FoveatedRenderingFeature() : base(ClassInjector.DerivedConstructorPointer<FoveatedRenderingFeature>()) => ClassInjector.DerivedConstructorBody(this);
        public FoveatedRenderingFeature(IntPtr ptr) : base(ptr) { }
        // Token: 0x06000153 RID: 339 RVA: 0x0000523B File Offset: 0x0000343B
        protected internal override bool OnInstanceCreate(ulong instance)
		{
			FoveatedRenderingFeature.Internal_Unity_SetUseFoveatedRenderingLegacyMode(GraphicsSettings.defaultRenderPipeline == null);
			return base.OnInstanceCreate(instance);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00005254 File Offset: 0x00003454
		protected internal override IntPtr HookGetInstanceProcAddr(IntPtr func)
		{
			return FoveatedRenderingFeature.Internal_Unity_intercept_xrGetInstanceProcAddr(func);
		}

		// Token: 0x06000155 RID: 341
		[DllImport("UnityOpenXR", EntryPoint = "UnityFoveation_intercept_xrGetInstanceProcAddr")]
		private static extern IntPtr Internal_Unity_intercept_xrGetInstanceProcAddr(IntPtr func);

		// Token: 0x06000156 RID: 342
		[DllImport("UnityOpenXR", EntryPoint = "UnityFoveation_SetUseFoveatedRenderingLegacyMode")]
		private static extern void Internal_Unity_SetUseFoveatedRenderingLegacyMode([MarshalAs(UnmanagedType.I1)] bool value);

		// Token: 0x06000157 RID: 343
		[DllImport("UnityOpenXR", EntryPoint = "UnityFoveation_GetUseFoveatedRenderingLegacyMode")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool Internal_Unity_GetUseFoveatedRenderingLegacyMode();

		// Token: 0x0400019C RID: 412
		public const string featureId = "com.unity.openxr.feature.foveatedrendering";

		// Token: 0x0400019D RID: 413
		private const string Library = "UnityOpenXR";
	}
}
