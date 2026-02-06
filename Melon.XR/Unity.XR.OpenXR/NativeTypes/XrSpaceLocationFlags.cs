using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x0200002A RID: 42
	[Flags]
	public enum XrSpaceLocationFlags
	{
		// Token: 0x0400012F RID: 303
		None = 0,
		// Token: 0x04000130 RID: 304
		OrientationValid = 1,
		// Token: 0x04000131 RID: 305
		PositionValid = 2,
		// Token: 0x04000132 RID: 306
		OrientationTracked = 4,
		// Token: 0x04000133 RID: 307
		PositionTracked = 8
	}
}
