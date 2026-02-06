using MelonLoader;
using System;

namespace UnityEngine.XR.Management
{
	// Token: 0x02000005 RID: 5

	[MelonLoader.RegisterTypeInIl2Cpp(true)]
	public class XRGeneralSettings : ScriptableObject
    {
        public XRGeneralSettings(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000009 RID: 9 RVA: 0x000020FE File Offset: 0x000002FE
        // (set) Token: 0x0600000A RID: 10 RVA: 0x00002106 File Offset: 0x00000306
        public XRManagerSettings Manager
		{
			get
			{
				return this.m_LoaderManagerInstance;
			}
			set
			{
				this.m_LoaderManagerInstance = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000210F File Offset: 0x0000030F
		public static XRGeneralSettings Instance
		{
			get
			{
				return XRGeneralSettings.s_RuntimeSettingsInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020FE File Offset: 0x000002FE
		public XRManagerSettings AssignedSettings
		{
			get
			{
				return this.m_LoaderManagerInstance;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002116 File Offset: 0x00000316
		public bool InitManagerOnStart
		{
			get
			{
				return this.m_InitManagerOnStart;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000211E File Offset: 0x0000031E
		private void Awake()
		{
			MelonLogger.Msg("XRGeneral Settings awakening...");
			XRGeneralSettings.s_RuntimeSettingsInstance = this;
			Application.add_quitting(new System.Action(XRGeneralSettings.Quit));
			Object.DontDestroyOnLoad(XRGeneralSettings.s_RuntimeSettingsInstance);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000214C File Offset: 0x0000034C
		private static void Quit()
		{
			XRGeneralSettings instance = XRGeneralSettings.Instance;
			if (instance == null)
			{
				return;
			}
			instance.DeInitXRSDK();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000216F File Offset: 0x0000036F
		private void Start()
		{
			this.StartXRSDK();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002177 File Offset: 0x00000377
		private void OnDestroy()
		{
			this.DeInitXRSDK();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002180 File Offset: 0x00000380
		//[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		public static void AttemptInitializeXRSDKOnLoad()
		{
			XRGeneralSettings instance = XRGeneralSettings.Instance;
			if (instance == null || !instance.InitManagerOnStart)
			{
				return;
			}
			instance.InitXRSDK();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000021AC File Offset: 0x000003AC
		//[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		internal static void AttemptStartXRSDKOnBeforeSplashScreen()
		{
			XRGeneralSettings instance = XRGeneralSettings.Instance;
			if (instance == null || !instance.InitManagerOnStart)
			{
				return;
			}
			instance.StartXRSDK();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000021D8 File Offset: 0x000003D8
		private void InitXRSDK()
		{
			if (XRGeneralSettings.Instance == null || XRGeneralSettings.Instance.m_LoaderManagerInstance == null || !XRGeneralSettings.Instance.m_InitManagerOnStart)
			{
				return;
			}
			this.m_XRManager = XRGeneralSettings.Instance.m_LoaderManagerInstance;
			if (this.m_XRManager == null)
			{
				MelonLogger.Error("Assigned GameObject for XR Management loading is invalid. No XR Providers will be automatically loaded.");
				return;
			}
			this.m_XRManager.automaticLoading = false;
			this.m_XRManager.automaticRunning = false;
			this.m_XRManager.InitializeLoaderSync();
			this.m_ProviderIntialized = true;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002264 File Offset: 0x00000464
		private void StartXRSDK()
		{
			if (this.m_XRManager != null && this.m_XRManager.activeLoader != null)
			{
				this.m_XRManager.StartSubsystems();
				this.m_ProviderStarted = true;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002299 File Offset: 0x00000499
		private void StopXRSDK()
		{
			if (this.m_XRManager != null && this.m_XRManager.activeLoader != null)
			{
				this.m_XRManager.StopSubsystems();
				this.m_ProviderStarted = false;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000022CE File Offset: 0x000004CE
		private void DeInitXRSDK()
		{
			if (this.m_XRManager != null && this.m_XRManager.activeLoader != null)
			{
				this.m_XRManager.DeinitializeLoader();
				this.m_XRManager = null;
				this.m_ProviderIntialized = false;
			}
		}

		// Token: 0x04000008 RID: 8
		public static string k_SettingsKey = "com.unity.xr.management.loader_settings";

		// Token: 0x04000009 RID: 9
		internal static XRGeneralSettings s_RuntimeSettingsInstance = null;

		// Token: 0x0400000A RID: 10
		//[SerializeField]
		internal XRManagerSettings m_LoaderManagerInstance;

		// Token: 0x0400000B RID: 11
		//[Tooltip("Toggling this on/off will enable/disable the automatic startup of XR at run time.")]
		//[SerializeField]
		internal bool m_InitManagerOnStart = true;

		// Token: 0x0400000C RID: 12
		private XRManagerSettings m_XRManager;

		// Token: 0x0400000D RID: 13
		private bool m_ProviderIntialized;

		// Token: 0x0400000E RID: 14
		private bool m_ProviderStarted;
	}
}
