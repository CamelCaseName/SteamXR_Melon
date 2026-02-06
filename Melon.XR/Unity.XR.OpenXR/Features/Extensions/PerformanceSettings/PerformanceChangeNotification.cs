using System;

namespace UnityEngine.XR.OpenXR.Features.Extensions.PerformanceSettings
{
	// Token: 0x02000077 RID: 119
	public struct PerformanceChangeNotification
	{
		// Token: 0x040003D5 RID: 981
		public PerformanceDomain domain;

		// Token: 0x040003D6 RID: 982
		public PerformanceSubDomain subDomain;

		// Token: 0x040003D7 RID: 983
		public PerformanceNotificationLevel fromLevel;

		// Token: 0x040003D8 RID: 984
		public PerformanceNotificationLevel toLevel;
	}
}
