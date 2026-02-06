using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000031 RID: 49
	public struct XrVector2f
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00004006 File Offset: 0x00002206
		public XrVector2f(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004016 File Offset: 0x00002216
		public XrVector2f(Vector2 value)
		{
			this.X = value.x;
			this.Y = value.y;
		}

		// Token: 0x04000160 RID: 352
		public float X;

		// Token: 0x04000161 RID: 353
		public float Y;
	}
}
