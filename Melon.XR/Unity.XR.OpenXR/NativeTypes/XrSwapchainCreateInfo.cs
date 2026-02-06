using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000035 RID: 53
	public struct XrSwapchainCreateInfo
	{
		// Token: 0x0400016B RID: 363
		public uint Type;

		// Token: 0x0400016C RID: 364
		public unsafe void* Next;

		// Token: 0x0400016D RID: 365
		public ulong CreateFlags;

		// Token: 0x0400016E RID: 366
		public ulong UsageFlags;

		// Token: 0x0400016F RID: 367
		public long Format;

		// Token: 0x04000170 RID: 368
		public uint SampleCount;

		// Token: 0x04000171 RID: 369
		public uint Width;

		// Token: 0x04000172 RID: 370
		public uint Height;

		// Token: 0x04000173 RID: 371
		public uint FaceCount;

		// Token: 0x04000174 RID: 372
		public uint ArraySize;

		// Token: 0x04000175 RID: 373
		public uint MipCount;
	}
}
