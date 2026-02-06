using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000032 RID: 50
	public struct XrVector3f
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00004030 File Offset: 0x00002230
		public XrVector3f(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = -z;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004048 File Offset: 0x00002248
		public XrVector3f(Vector3 value)
		{
			this.X = value.x;
			this.Y = value.y;
			this.Z = -value.z;
		}

		// Token: 0x04000162 RID: 354
		public float X;

		// Token: 0x04000163 RID: 355
		public float Y;

		// Token: 0x04000164 RID: 356
		public float Z;
	}
}
