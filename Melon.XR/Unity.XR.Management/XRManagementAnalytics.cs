using System;

namespace UnityEngine.XR.Management
{
	// Token: 0x02000008 RID: 8
	internal static class XRManagementAnalytics
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000024EC File Offset: 0x000006EC
		private static bool Initialize()
		{
			return XRManagementAnalytics.s_Initialized;
		}

		// Token: 0x04000010 RID: 16
		private const int kMaxEventsPerHour = 1000;

		// Token: 0x04000011 RID: 17
		private const int kMaxNumberOfElements = 1000;

		// Token: 0x04000012 RID: 18
		private const string kVendorKey = "unity.xrmanagement";

		// Token: 0x04000013 RID: 19
		private const string kEventBuild = "xrmanagment_build";

		// Token: 0x04000014 RID: 20
		private static bool s_Initialized;

		// Token: 0x02000009 RID: 9
		[Serializable]
		private struct BuildEvent
		{
			// Token: 0x04000015 RID: 21
			public string buildGuid;

			// Token: 0x04000016 RID: 22
			public string buildTarget;

			// Token: 0x04000017 RID: 23
			public string buildTargetGroup;

			// Token: 0x04000018 RID: 24
			public string[] assigned_loaders;
		}
	}
}
