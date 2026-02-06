using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000028 RID: 40
	public static class XrResultExtensions
	{
		// Token: 0x060000EA RID: 234 RVA: 0x00003FF1 File Offset: 0x000021F1
		public static bool IsSuccess(this XrResult xrResult)
		{
			return xrResult >= XrResult.Success;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003FFA File Offset: 0x000021FA
		public static bool IsUnqualifiedSuccess(this XrResult xrResult)
		{
			return xrResult == XrResult.Success;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004000 File Offset: 0x00002200
		public static bool IsError(this XrResult xrResult)
		{
			return xrResult < XrResult.Success;
		}
	}
}
