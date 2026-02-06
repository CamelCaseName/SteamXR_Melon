using System;

namespace UnityEngine.XR.OpenXR.NativeTypes
{
	// Token: 0x0200002B RID: 43
	[Flags]
	public enum XrViewStateFlags
	{
		// Token: 0x04000135 RID: 309
		None = 0,
		// Token: 0x04000136 RID: 310
		OrientationValid = 1,
		// Token: 0x04000137 RID: 311
		PositionValid = 2,
		// Token: 0x04000138 RID: 312
		OrientationTracked = 4,
		// Token: 0x04000139 RID: 313
		PositionTracked = 8
	}
}
