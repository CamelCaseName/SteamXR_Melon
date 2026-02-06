using System;
using System.Runtime.InteropServices;

namespace UnityEngine.XR.OpenXR
{
	// Token: 0x02000010 RID: 16
	internal class DiagnosticReport
	{
		// Token: 0x0600004F RID: 79
		[DllImport("UnityOpenXR", EntryPoint = "DiagnosticReport_StartReport")]
		public static extern void StartReport();

		// Token: 0x06000050 RID: 80
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "DiagnosticReport_GetSection")]
		public static extern ulong GetSection(string sectionName);

		// Token: 0x06000051 RID: 81
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "DiagnosticReport_AddSectionEntry")]
		public static extern void AddSectionEntry(ulong sectionHandle, string sectionEntry, string sectionBody);

		// Token: 0x06000052 RID: 82
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "DiagnosticReport_AddSectionBreak")]
		public static extern void AddSectionBreak(ulong sectionHandle);

		// Token: 0x06000053 RID: 83
		[DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "DiagnosticReport_AddEventEntry")]
		public static extern void AddEventEntry(string eventName, string eventData);

		// Token: 0x06000054 RID: 84
		[DllImport("UnityOpenXR", EntryPoint = "DiagnosticReport_DumpReport")]
		private static extern void Internal_DumpReport();

		// Token: 0x06000055 RID: 85
		[DllImport("UnityOpenXR", EntryPoint = "DiagnosticReport_DumpReportWithReason")]
		private static extern void Internal_DumpReport(string reason);

		// Token: 0x06000056 RID: 86
		[DllImport("UnityOpenXR", EntryPoint = "DiagnosticReport_GenerateReport")]
		private static extern IntPtr Internal_GenerateReport();

		// Token: 0x06000057 RID: 87
		[DllImport("UnityOpenXR", EntryPoint = "DiagnosticReport_ReleaseReport")]
		private static extern void Internal_ReleaseReport(IntPtr report);

		// Token: 0x06000058 RID: 88 RVA: 0x00002798 File Offset: 0x00000998
		internal static string GenerateReport()
		{
			string ret = "";
			IntPtr buffer = DiagnosticReport.Internal_GenerateReport();
			if (buffer != IntPtr.Zero)
			{
				ret = Marshal.PtrToStringAnsi(buffer);
				DiagnosticReport.Internal_ReleaseReport(buffer);
				buffer = IntPtr.Zero;
			}
			return ret;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000027D2 File Offset: 0x000009D2
		public static void DumpReport(string reason)
		{
			DiagnosticReport.Internal_DumpReport(reason);
		}

		// Token: 0x0400003F RID: 63
		private const string LibraryName = "UnityOpenXR";

		// Token: 0x04000040 RID: 64
		public static readonly ulong k_NullSection;
	}
}
