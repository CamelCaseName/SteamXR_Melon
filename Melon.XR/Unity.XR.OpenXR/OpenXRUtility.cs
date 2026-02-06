using System;
using System.Runtime.InteropServices;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x0200001D RID: 29
	public static class OpenXRUtility
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00003EEC File Offset: 0x000020EC
		private static Pose Inverse(Pose p)
		{
			Pose ret;
			ret.rotation = Quaternion.Inverse(p.rotation);
			ret.position = ret.rotation * -p.position;
			return ret;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003F2C File Offset: 0x0000212C
		public static Pose ComputePoseToWorldSpace(Transform t, Camera camera)
		{
			if (camera == null)
			{
				return default(Pose);
			}
			Transform cameraTransform = camera.transform;
			Pose headPose = CreatePose(cameraTransform.localPosition, cameraTransform.localRotation);
			Pose camPose = CreatePose(cameraTransform.position, cameraTransform.rotation);
			Pose transformPose = CreatePose(t.position, t.rotation);
			return transformPose.GetTransformedBy(OpenXRUtility.Inverse(camPose)).GetTransformedBy(headPose);
		}

		public static Pose CreatePose(Vector3 pos, Quaternion q)
		{
			Pose p = new();
			p.position = pos;	
			p.rotation = q;
			return p;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00003FA4 File Offset: 0x000021A4
		public static bool IsSessionFocused
		{
			get
			{
				return OpenXRUtility.Internal_IsSessionFocused();
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00003FAB File Offset: 0x000021AB
		public static bool IsUserPresent
		{
			get
			{
				return OpenXRUtility.Internal_GetUserPresence();
			}
		}

		// Token: 0x060000E5 RID: 229
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_IsSessionFocused")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_IsSessionFocused();

		// Token: 0x060000E6 RID: 230
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetUserPresence")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetUserPresence();

		// Token: 0x0400007F RID: 127
		private const string LibraryName = "UnityOpenXR";
	}
}
