using System;
using System.Runtime.InteropServices;

namespace UnityEngine.XR.OpenXR.API
{
	// Token: 0x02000025 RID: 37
	public static class UnityXRDisplay
	{
		// Token: 0x060000E9 RID: 233
		[DllImport("UnityOpenXR", EntryPoint = "Display_CreateTexture")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool CreateTexture(UnityXRRenderTextureDesc desc, out uint id);

		// Token: 0x040000AB RID: 171
		public const uint kUnityXRRenderTextureIdDontCare = 0U;

		// Token: 0x040000AC RID: 172
		private const string k_UnityOpenXRLib = "UnityOpenXR";
	}
}
