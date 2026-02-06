using System;

namespace UnityEngine.XR.Management
{
	// Token: 0x02000004 RID: 4
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class XRConfigurationDataAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020BE File Offset: 0x000002BE
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020C6 File Offset: 0x000002C6
		public string displayName { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020CF File Offset: 0x000002CF
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D7 File Offset: 0x000002D7
		public string buildSettingsKey { get; set; }

		// Token: 0x06000007 RID: 7 RVA: 0x000020E0 File Offset: 0x000002E0
		private XRConfigurationDataAttribute()
		{
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020E8 File Offset: 0x000002E8
		public XRConfigurationDataAttribute(string displayName, string buildSettingsKey)
		{
			this.displayName = displayName;
			this.buildSettingsKey = buildSettingsKey;
		}
	}
}
