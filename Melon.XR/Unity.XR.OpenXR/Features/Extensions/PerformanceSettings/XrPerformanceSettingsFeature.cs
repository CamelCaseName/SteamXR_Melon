using Il2CppAOT;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Runtime.InteropServices;
using UnityEngine.Events;
using UnityEngine.XR.Management;

namespace UnityEngine.XR.OpenXR.Features.Extensions.PerformanceSettings
{
	// Token: 0x02000070 RID: 112
	[MelonLoader.RegisterTypeInIl2Cpp(true)]
	public class XrPerformanceSettingsFeature : OpenXRFeature
    {
        public XrPerformanceSettingsFeature() : base(ClassInjector.DerivedConstructorPointer<XrPerformanceSettingsFeature>()) => ClassInjector.DerivedConstructorBody(this);
        public XrPerformanceSettingsFeature(IntPtr ptr) : base(ptr) { }
        // Token: 0x14000003 RID: 3
        // (add) Token: 0x06000404 RID: 1028 RVA: 0x0000D3B4 File Offset: 0x0000B5B4
        // (remove) Token: 0x06000405 RID: 1029 RVA: 0x0000D3E8 File Offset: 0x0000B5E8
        public static event Action<PerformanceChangeNotification> OnXrPerformanceChangeNotification;

		// Token: 0x06000406 RID: 1030 RVA: 0x0000D41B File Offset: 0x0000B61B
		public static bool SetPerformanceLevelHint(PerformanceDomain domain, PerformanceLevelHint level)
		{
			return OpenXRRuntime.IsExtensionEnabled("XR_EXT_performance_settings") && XrPerformanceSettingsFeature.NativeApi.xr_performance_settings_setPerformanceLevel(domain, level);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000D432 File Offset: 0x0000B632
		protected internal override bool OnInstanceCreate(ulong xrInstance)
		{
			return base.OnInstanceCreate(xrInstance) && OpenXRRuntime.IsExtensionEnabled("XR_EXT_performance_settings") && XrPerformanceSettingsFeature.NativeApi.xr_performance_settings_setEventCallback(new XrPerformanceSettingsFeature.NativeApi.XrPerformanceNotificationDelegate(XrPerformanceSettingsFeature.OnXrPerformanceNotificationCallback));
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000D45C File Offset: 0x0000B65C
		//[MonoPInvokeCallback(typeof(XrPerformanceSettingsFeature.NativeApi.XrPerformanceNotificationDelegate))]
		private static void OnXrPerformanceNotificationCallback(PerformanceChangeNotification notification)
		{
			UnityAction<PerformanceChangeNotification> onXrPerformanceChangeNotification = XrPerformanceSettingsFeature.OnXrPerformanceChangeNotification;
			if (onXrPerformanceChangeNotification == null)
			{
				return;
			}
			onXrPerformanceChangeNotification.Invoke(notification);
		}

		// Token: 0x040003C2 RID: 962
		public const string featureId = "com.unity.openxr.feature.extension.performance_settings";

		// Token: 0x040003C3 RID: 963
		public const string extensionString = "XR_EXT_performance_settings";

		// Token: 0x02000071 RID: 113
		internal static class NativeApi
		{
			// Token: 0x0600040A RID: 1034
			[DllImport("UnityOpenXR")]
			[return: MarshalAs(UnmanagedType.U1)]
			internal static extern bool xr_performance_settings_setEventCallback(XrPerformanceSettingsFeature.NativeApi.XrPerformanceNotificationDelegate callback);

			// Token: 0x0600040B RID: 1035
			[DllImport("UnityOpenXR")]
			[return: MarshalAs(UnmanagedType.U1)]
			internal static extern bool xr_performance_settings_setPerformanceLevel(PerformanceDomain domain, PerformanceLevelHint level);

			// Token: 0x02000072 RID: 114
			// (Invoke) Token: 0x0600040D RID: 1037
			internal delegate void XrPerformanceNotificationDelegate(PerformanceChangeNotification notification);
		}
	}
}
