using MelonLoader;
using System;
using System.Runtime.InteropServices;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x0200001C RID: 28
	public static class OpenXRRuntime
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003B88 File Offset: 0x00001D88
		public static string name
		{
			get
			{
				IntPtr runtimeNamePtr;
				if (!OpenXRRuntime.Internal_GetRuntimeName(out runtimeNamePtr))
				{
					return "";
				}
				return Marshal.PtrToStringAnsi(runtimeNamePtr);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003BAC File Offset: 0x00001DAC
		public static string version
		{
			get
			{
				ushort major;
				ushort minor;
				uint patch;
				if (!OpenXRRuntime.Internal_GetRuntimeVersion(out major, out minor, out patch))
				{
					return "";
				}
				return string.Format("{0}.{1}.{2}", major, minor, patch);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003BE8 File Offset: 0x00001DE8
		public static string apiVersion
		{
			get
			{
				ushort major;
				ushort minor;
				uint patch;
				if (!OpenXRRuntime.Internal_GetAPIVersion(out major, out minor, out patch))
				{
					return "";
				}
				return string.Format("{0}.{1}.{2}", major, minor, patch);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003C24 File Offset: 0x00001E24
		public static string pluginVersion
		{
			get
			{
				IntPtr pluginVersionPtr;
				if (!OpenXRRuntime.Internal_GetPluginVersion(out pluginVersionPtr))
				{
					return "";
				}
				return Marshal.PtrToStringAnsi(pluginVersionPtr);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003C48 File Offset: 0x00001E48
		internal static bool isRuntimeAPIVersionGreaterThan1_1()
		{
			ushort major;
			ushort minor;
			uint patch;
			return OpenXRRuntime.Internal_GetAPIVersion(out major, out minor, out patch) && major >= 1 && minor >= 1;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003C6D File Offset: 0x00001E6D
		public static bool IsExtensionEnabled(string extensionName)
		{
			return OpenXRRuntime.Internal_IsExtensionEnabled(extensionName);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003C75 File Offset: 0x00001E75
		public static uint GetExtensionVersion(string extensionName)
		{
			return OpenXRRuntime.Internal_GetExtensionVersion(extensionName);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003C80 File Offset: 0x00001E80
		public static string[] GetEnabledExtensions()
		{
			string[] extensions = new string[OpenXRRuntime.Internal_GetEnabledExtensionCount()];
			for (int i = 0; i < extensions.Length; i++)
			{
				string extensionName;
				OpenXRRuntime.Internal_GetEnabledExtensionName((uint)i, out extensionName);
				extensions[i] = (extensionName ?? "");
			}
			return extensions;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003CC0 File Offset: 0x00001EC0
		public static string[] GetAvailableExtensions()
		{
			string[] extensions = new string[OpenXRRuntime.Internal_GetAvailableExtensionCount()];
			for (int i = 0; i < extensions.Length; i++)
			{
				string extensionName;
				OpenXRRuntime.Internal_GetAvailableExtensionName((uint)i, out extensionName);
				extensions[i] = (extensionName ?? "");
			}
			return extensions;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000C7 RID: 199 RVA: 0x00003D00 File Offset: 0x00001F00
		// (remove) Token: 0x060000C8 RID: 200 RVA: 0x00003D34 File Offset: 0x00001F34
		public static event Func<bool> wantsToQuit;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000C9 RID: 201 RVA: 0x00003D68 File Offset: 0x00001F68
		// (remove) Token: 0x060000CA RID: 202 RVA: 0x00003D9C File Offset: 0x00001F9C
		public static event Func<bool> wantsToRestart;

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003DCF File Offset: 0x00001FCF
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003DD6 File Offset: 0x00001FD6
		public static bool retryInitializationOnFormFactorErrors
		{
			get
			{
				return OpenXRRuntime.Internal_GetSoftRestartLoopAtInitialization();
			}
			set
			{
				OpenXRRuntime.Internal_SetSoftRestartLoopAtInitialization(value);
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003DE0 File Offset: 0x00001FE0
		private static bool InvokeEvent(Func<bool> func)
		{
			if (func == null)
			{
				return true;
			}
			foreach (Func<bool> invocation in func.GetInvocationList())
			{
				try
				{
					if (!invocation())
					{
						return false;
					}
				}
				catch (Exception exception)
				{
					MelonLogger.Error(exception);
				}
			}
			return true;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003E38 File Offset: 0x00002038
		internal static bool ShouldQuit()
		{
			return OpenXRRuntime.InvokeEvent(OpenXRRuntime.wantsToQuit);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003E44 File Offset: 0x00002044
		internal static bool ShouldRestart()
		{
			return OpenXRRuntime.InvokeEvent(OpenXRRuntime.wantsToRestart);
		}

		// Token: 0x060000D0 RID: 208
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetRuntimeName")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetRuntimeName(out IntPtr runtimeNamePtr);

		// Token: 0x060000D1 RID: 209
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetRuntimeVersion")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetRuntimeVersion(out ushort major, out ushort minor, out uint patch);

		// Token: 0x060000D2 RID: 210
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetAPIVersion")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetAPIVersion(out ushort major, out ushort minor, out uint patch);

		// Token: 0x060000D3 RID: 211
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetPluginVersion")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetPluginVersion(out IntPtr pluginVersionPtr);

		// Token: 0x060000D4 RID: 212
		[DllImport("UnityOpenXR", EntryPoint = "unity_ext_IsExtensionEnabled")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_IsExtensionEnabled(string extensionName);

		// Token: 0x060000D5 RID: 213
		[DllImport("UnityOpenXR", EntryPoint = "unity_ext_GetExtensionVersion")]
		private static extern uint Internal_GetExtensionVersion(string extensionName);

		// Token: 0x060000D6 RID: 214
		[DllImport("UnityOpenXR", EntryPoint = "unity_ext_GetEnabledExtensionCount")]
		private static extern uint Internal_GetEnabledExtensionCount();

		// Token: 0x060000D7 RID: 215
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "unity_ext_GetEnabledExtensionName")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetEnabledExtensionNamePtr(uint index, out IntPtr outName);

		// Token: 0x060000D8 RID: 216
		[DllImport("UnityOpenXR", EntryPoint = "session_SetSoftRestartLoopAtInitialization")]
		private static extern void Internal_SetSoftRestartLoopAtInitialization([MarshalAs(UnmanagedType.I1)] bool value);

		// Token: 0x060000D9 RID: 217
		[DllImport("UnityOpenXR", EntryPoint = "session_GetSoftRestartLoopAtInitialization")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetSoftRestartLoopAtInitialization();

		// Token: 0x060000DA RID: 218 RVA: 0x00003E50 File Offset: 0x00002050
		private static bool Internal_GetEnabledExtensionName(uint index, out string extensionName)
		{
			IntPtr extensionNamePtr;
			if (!OpenXRRuntime.Internal_GetEnabledExtensionNamePtr(index, out extensionNamePtr))
			{
				extensionName = "";
				return false;
			}
			extensionName = Marshal.PtrToStringAnsi(extensionNamePtr);
			return true;
		}

		// Token: 0x060000DB RID: 219
		[DllImport("UnityOpenXR", EntryPoint = "unity_ext_GetAvailableExtensionCount")]
		private static extern uint Internal_GetAvailableExtensionCount();

		// Token: 0x060000DC RID: 220
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "unity_ext_GetAvailableExtensionName")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetAvailableExtensionNamePtr(uint index, out IntPtr extensionName);

		// Token: 0x060000DD RID: 221 RVA: 0x00003E7C File Offset: 0x0000207C
		private static bool Internal_GetAvailableExtensionName(uint index, out string extensionName)
		{
			IntPtr extensionNamePtr;
			if (!OpenXRRuntime.Internal_GetAvailableExtensionNamePtr(index, out extensionNamePtr))
			{
				extensionName = "";
				return false;
			}
			extensionName = Marshal.PtrToStringAnsi(extensionNamePtr);
			return true;
		}

		// Token: 0x060000DE RID: 222
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "session_GetLastError")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetLastError(out IntPtr error);

		// Token: 0x060000DF RID: 223 RVA: 0x00003EA8 File Offset: 0x000020A8
		internal static bool GetLastError(out string error)
		{
			IntPtr errorPtr;
			if (!OpenXRRuntime.Internal_GetLastError(out errorPtr))
			{
				error = "";
				return false;
			}
			error = Marshal.PtrToStringAnsi(errorPtr);
			return true;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00003ED0 File Offset: 0x000020D0
		internal static void LogLastError()
		{
			string error;
			if (OpenXRRuntime.GetLastError(out error))
			{
				MelonLogger.Error(error);
			}
		}

		// Token: 0x0400007E RID: 126
		private const string LibraryName = "UnityOpenXR";
	}
}
