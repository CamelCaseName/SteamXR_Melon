using System;

namespace UnityEngine.XR.OpenXR.API
{
	// Token: 0x02000024 RID: 36
	public struct UnityXRRenderTextureDesc
	{
		// Token: 0x040000A1 RID: 161
		public UnityXRRenderTextureFormat colorFormat;

		// Token: 0x040000A2 RID: 162
		public UnityXRTextureData color;

		// Token: 0x040000A3 RID: 163
		public UnityXRDepthTextureFormat depthFormat;

		// Token: 0x040000A4 RID: 164
		public UnityXRTextureData depth;

		// Token: 0x040000A5 RID: 165
		public UnityXRShadingRateFormat shadingRateFormat;

		// Token: 0x040000A6 RID: 166
		public UnityXRTextureData shadingRate;

		// Token: 0x040000A7 RID: 167
		public uint width;

		// Token: 0x040000A8 RID: 168
		public uint height;

		// Token: 0x040000A9 RID: 169
		public uint textureArrayLength;

		// Token: 0x040000AA RID: 170
		public uint flags;
	}
}
