using System;

namespace UnityEngine.XR.OpenXR.Input
{
	// Token: 0x02000040 RID: 64
	[Obsolete("OpenXR.Input.Pose is deprecated, Please use UnityEngine.InputSystem.XR.PoseState instead", false)]
	public struct Pose
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004FDB File Offset: 0x000031DB
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004FE3 File Offset: 0x000031E3
		public bool isTracked { readonly get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004FEC File Offset: 0x000031EC
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00004FF4 File Offset: 0x000031F4
		public InputTrackingState trackingState { readonly get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00004FFD File Offset: 0x000031FD
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00005005 File Offset: 0x00003205
		public Vector3 position { readonly get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000500E File Offset: 0x0000320E
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00005016 File Offset: 0x00003216
		public Quaternion rotation { readonly get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000501F File Offset: 0x0000321F
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00005027 File Offset: 0x00003227
		public Vector3 velocity { readonly get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00005030 File Offset: 0x00003230
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00005038 File Offset: 0x00003238
		public Vector3 angularVelocity { readonly get; set; }
	}
}
