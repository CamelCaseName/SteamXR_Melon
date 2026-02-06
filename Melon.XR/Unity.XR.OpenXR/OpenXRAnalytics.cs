using System;
using System.Linq;
using UnityEngine.Analytics;
using UnityEngine.XR.OpenXR.Features;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x0200000C RID: 12
	internal static class OpenXRAnalytics
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00002553 File Offset: 0x00000753
		private static bool Initialize()
		{
			if (OpenXRAnalytics.s_Initialized)
			{
				return true;
			}
			if (Analytics.Analytics.RegisterEvent("openxr_initialize", 1000, 1000, "unity.openxr", "") != AnalyticsResult.Ok)
			{
				return false;
			}
			OpenXRAnalytics.s_Initialized = true;
			return true;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002587 File Offset: 0x00000787
		public static void SendInitializeEvent(bool success)
		{
			if (!OpenXRAnalytics.s_Initialized && !OpenXRAnalytics.Initialize())
			{
				return;
			}
			OpenXRAnalytics.SendPlayerAnalytics(OpenXRAnalytics.CreateInitializeEvent(success));
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000025A4 File Offset: 0x000007A4
		private static OpenXRAnalytics.InitializeEvent CreateInitializeEvent(bool success)
		{
			OpenXRAnalytics.InitializeEvent result = default(OpenXRAnalytics.InitializeEvent);
			result.success = success;
			result.runtime = OpenXRRuntime.name;
			result.runtime_version = OpenXRRuntime.version;
			result.plugin_version = OpenXRRuntime.pluginVersion;
			result.api_version = OpenXRRuntime.apiVersion;
			result.enabled_extensions = (from ext in OpenXRRuntime.GetEnabledExtensions()
			select string.Format("{0}_{1}", ext, OpenXRRuntime.GetExtensionVersion(ext))).ToArray<string>();
			result.available_extensions = (from ext in OpenXRRuntime.GetAvailableExtensions()
			select string.Format("{0}_{1}", ext, OpenXRRuntime.GetExtensionVersion(ext))).ToArray<string>();
			result.enabled_features = (from f in OpenXRSettings.Instance.features
			where f != null && f.enabled
			select f.GetType().FullName + "_" + f.version).ToArray<string>();
			result.failed_features = (from f in OpenXRSettings.Instance.features
			where f != null && f.failedInitialization
			select f.GetType().FullName + "_" + f.version).ToArray<string>();
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002718 File Offset: 0x00000918
		private static void SendPlayerAnalytics(OpenXRAnalytics.InitializeEvent data)
		{
            //Analytics.Analytics.SendEvent("openxr_initialize", data, 1, "");
		}

		// Token: 0x04000029 RID: 41
		private const int kMaxEventsPerHour = 1000;

		// Token: 0x0400002A RID: 42
		private const int kMaxNumberOfElements = 1000;

		// Token: 0x0400002B RID: 43
		private const string kVendorKey = "unity.openxr";

		// Token: 0x0400002C RID: 44
		private const string kEventInitialize = "openxr_initialize";

		// Token: 0x0400002D RID: 45
		private static bool s_Initialized;

		// Token: 0x0200000D RID: 13
		[Serializable]
		private struct InitializeEvent
		{
			// Token: 0x0400002E RID: 46
			public bool success;

			// Token: 0x0400002F RID: 47
			public string runtime;

			// Token: 0x04000030 RID: 48
			public string runtime_version;

			// Token: 0x04000031 RID: 49
			public string plugin_version;

			// Token: 0x04000032 RID: 50
			public string api_version;

			// Token: 0x04000033 RID: 51
			public string[] available_extensions;

			// Token: 0x04000034 RID: 52
			public string[] enabled_extensions;

			// Token: 0x04000035 RID: 53
			public string[] enabled_features;

			// Token: 0x04000036 RID: 54
			public string[] failed_features;
		}
	}
}
