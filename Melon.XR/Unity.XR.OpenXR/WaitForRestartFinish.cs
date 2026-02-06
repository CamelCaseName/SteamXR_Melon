using MelonLoader;
using System;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x0200001E RID: 30
	internal sealed class WaitForRestartFinish : CustomYieldInstruction
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00003FB2 File Offset: 0x000021B2
		public WaitForRestartFinish(float timeout = 5f)
		{
			this.m_Timeout = Time.realtimeSinceStartup + timeout;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00003FC7 File Offset: 0x000021C7
		public override bool keepWaiting
		{
			get
			{
				if (!OpenXRRestarter.Instance.isRunning)
				{
					return false;
				}
				if (Time.realtimeSinceStartup > this.m_Timeout)
				{
					MelonLogger.Error("WaitForRestartFinish: Timeout");
					return false;
				}
				return true;
			}
		}

		// Token: 0x04000080 RID: 128
		private float m_Timeout;
	}
}
