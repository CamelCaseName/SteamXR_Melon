using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x02000034 RID: 52
	public struct XrPosef
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x000040C4 File Offset: 0x000022C4
		public XrPosef(Vector3 vec3, Quaternion quaternion)
		{
			this.Position = new XrVector3f(vec3);
			this.Orientation = new XrQuaternionf(quaternion);
		}

		// Token: 0x04000169 RID: 361
		public XrQuaternionf Orientation;

		// Token: 0x0400016A RID: 362
		public XrVector3f Position;
	}
}
