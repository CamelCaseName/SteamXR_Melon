using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000033 RID: 51
	public struct XrQuaternionf
	{
		// Token: 0x060000F1 RID: 241 RVA: 0x0000406F File Offset: 0x0000226F
		public XrQuaternionf(float x, float y, float z, float w)
		{
			this.X = -x;
			this.Y = -y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004090 File Offset: 0x00002290
		public XrQuaternionf(Quaternion quaternion)
		{
			this.X = -quaternion.x;
			this.Y = -quaternion.y;
			this.Z = quaternion.z;
			this.W = quaternion.w;
		}

		// Token: 0x04000165 RID: 357
		public float X;

		// Token: 0x04000166 RID: 358
		public float Y;

		// Token: 0x04000167 RID: 359
		public float Z;

		// Token: 0x04000168 RID: 360
		public float W;
	}
}
