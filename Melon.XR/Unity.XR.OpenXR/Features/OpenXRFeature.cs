using Il2CppInterop.Runtime.Attributes;
using MelonLoader;
using System;
using System.Runtime.InteropServices;
using UnityEngine.XR.OpenXR.NativeTypes;

namespace UnityEngine.XR.OpenXR.Features
{
	// Token: 0x02000043 RID: 67
	[Serializable]
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRFeature : ScriptableObject
    {
        public OpenXRFeature(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000037 RID: 55
        // (get) Token: 0x06000159 RID: 345 RVA: 0x00005264 File Offset: 0x00003464
        // (set) Token: 0x0600015A RID: 346 RVA: 0x0000526C File Offset: 0x0000346C
        internal bool failedInitialization ;

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00005275 File Offset: 0x00003475
		// (set) Token: 0x0600015C RID: 348 RVA: 0x0000527C File Offset: 0x0000347C
		internal static bool requiredFeatureFailed ;

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00005284 File Offset: 0x00003484
		// (set) Token: 0x0600015E RID: 350 RVA: 0x000052A8 File Offset: 0x000034A8
		public bool enabled
		{
			get
			{
				return this.m_enabled && (OpenXRLoaderBase.Instance == null || !this.failedInitialization);
			}
			set
			{
				if (this.enabled == value)
				{
					return;
				}
				//if (OpenXRLoaderBase.Instance != null)
				//{
				//	MelonLogger.Error("OpenXRFeature.enabled cannot be changed while OpenXR is running");
				//	return;
				//}
				this.m_enabled = value;
				this.OnEnabledChange();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600015F RID: 351 RVA: 0x000052D9 File Offset: 0x000034D9
		protected static IntPtr xrGetInstanceProcAddr
		{
			get
			{
				return OpenXRFeature.Internal_GetProcAddressPtr(false);
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00002550 File Offset: 0x00000750
		protected internal virtual IntPtr HookGetInstanceProcAddr(IntPtr func)
		{
			return func;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSubsystemCreate()
		{
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSubsystemStart()
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSubsystemStop()
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSubsystemDestroy()
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x000052E1 File Offset: 0x000034E1
		protected internal virtual bool OnInstanceCreate(ulong xrInstance)
		{
			return true;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSystemChange(ulong xrSystem)
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionCreate(ulong xrSession)
		{
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnAppSpaceChange(ulong xrSpace)
		{
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionStateChange(int oldState, int newState)
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionBegin(ulong xrSession)
		{
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionEnd(ulong xrSession)
		{
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionExiting(ulong xrSession)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionDestroy(ulong xrSession)
		{
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnInstanceDestroy(ulong xrInstance)
		{
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnSessionLossPending(ulong xrSession)
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnInstanceLossPending(ulong xrInstance)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnFormFactorChange(int xrFormFactor)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnViewConfigurationTypeChange(int xrViewConfigurationType)
		{
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnEnvironmentBlendModeChange(XrEnvironmentBlendMode xrEnvironmentBlendMode)
		{
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00002355 File Offset: 0x00000555
		protected internal virtual void OnEnabledChange()
		{
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000052E4 File Offset: 0x000034E4
		protected static string PathToString(ulong path)
		{
			IntPtr stringPtr;
			if (!OpenXRFeature.Internal_PathToStringPtr(path, out stringPtr))
			{
				return null;
			}
			return Marshal.PtrToStringAnsi(stringPtr);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00005304 File Offset: 0x00003504
		protected static ulong StringToPath(string str)
		{
			ulong id;
			if (!OpenXRFeature.Internal_StringToPath(str, out id))
			{
				return 0UL;
			}
			return id;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00005320 File Offset: 0x00003520
		protected static ulong GetCurrentInteractionProfile(ulong userPath)
		{
			ulong profileId;
			if (!OpenXRFeature.Internal_GetCurrentInteractionProfile(userPath, out profileId))
			{
				return 0UL;
			}
			return profileId;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000533B File Offset: 0x0000353B
		protected static ulong GetCurrentInteractionProfile(string userPath)
		{
			return OpenXRFeature.GetCurrentInteractionProfile(OpenXRFeature.StringToPath(userPath));
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00005348 File Offset: 0x00003548
		protected static ulong GetCurrentAppSpace()
		{
			ulong appSpaceId;
			if (!OpenXRFeature.Internal_GetAppSpace(out appSpaceId))
			{
				return 0UL;
			}
			return appSpaceId;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00005362 File Offset: 0x00003562
		protected static int GetViewConfigurationTypeForRenderPass(int renderPassIndex)
		{
			return OpenXRFeature.Internal_GetViewTypeFromRenderIndex(renderPassIndex);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000536A File Offset: 0x0000356A
		protected static void SetEnvironmentBlendMode(XrEnvironmentBlendMode xrEnvironmentBlendMode)
		{
			OpenXRFeature.Internal_SetEnvironmentBlendMode(xrEnvironmentBlendMode);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00005372 File Offset: 0x00003572
		protected static XrEnvironmentBlendMode GetEnvironmentBlendMode()
		{
			return OpenXRFeature.Internal_GetEnvironmentBlendMode();
		}

        // Token: 0x0600017D RID: 381 RVA: 0x00005379 File Offset: 0x00003579
        [HideFromIl2Cpp]
        protected void CreateSubsystem<TDescriptor, TSubsystem>(Il2CppSystem.Collections.Generic.List<TDescriptor> descriptors, string id) where TDescriptor : IntegratedSubsystemDescriptor<TSubsystem> where TSubsystem : IntegratedSubsystem
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				MelonLogger.Error("CreateSubsystem called before loader was initialized");
				return;
			}
			OpenXRLoaderBase.Instance.CreateSubsystem<TDescriptor, TSubsystem>(descriptors, id);
		}

        // Token: 0x0600017E RID: 382 RVA: 0x0000539F File Offset: 0x0000359F
        [HideFromIl2Cpp]
        protected void StartSubsystem<T>() where T : IntegratedSubsystem
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				MelonLogger.Error("StartSubsystem called before loader was initialized");
				return;
			}
			OpenXRLoaderBase.Instance.StartSubsystem<T>();
		}

        // Token: 0x0600017F RID: 383 RVA: 0x000053C3 File Offset: 0x000035C3
        [HideFromIl2Cpp]
        protected void StopSubsystem<T>() where T : IntegratedSubsystem
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				MelonLogger.Error("StopSubsystem called before loader was initialized");
				return;
			}
			OpenXRLoaderBase.Instance.StopSubsystem<T>();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000053E7 File Offset: 0x000035E7
		protected void DestroySubsystem<T>() where T : IntegratedSubsystem
		{
			if (OpenXRLoaderBase.Instance == null)
			{
				MelonLogger.Error("DestroySubsystem called before loader was initialized");
				return;
			}
			OpenXRLoaderBase.Instance.DestroySubsystem<T>();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00002355 File Offset: 0x00000555
		protected virtual void OnEnable()
		{
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00002355 File Offset: 0x00000555
		protected virtual void OnDisable()
		{
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00002355 File Offset: 0x00000555
		protected virtual void Awake()
		{
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000540C File Offset: 0x0000360C
		internal static bool ReceiveLoaderEvent(OpenXRLoaderBase loader, OpenXRFeature.LoaderEvent e)
		{
			OpenXRSettings instance = OpenXRSettings.Instance;
			if (instance == null)
			{
				return true;
			}
			foreach (OpenXRFeature feature in instance.features)
			{
				if (!(feature == null) && feature.enabled)
				{
					switch (e)
					{
					case OpenXRFeature.LoaderEvent.SubsystemCreate:
						feature.OnSubsystemCreate();
						break;
					case OpenXRFeature.LoaderEvent.SubsystemDestroy:
						feature.OnSubsystemDestroy();
						break;
					case OpenXRFeature.LoaderEvent.SubsystemStart:
						feature.OnSubsystemStart();
						break;
					case OpenXRFeature.LoaderEvent.SubsystemStop:
						feature.OnSubsystemStop();
						break;
					default:
						throw new ArgumentOutOfRangeException("e", e, null);
					}
				}
			}
			return true;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000054A0 File Offset: 0x000036A0
		internal static void ReceiveNativeEvent(OpenXRFeature.NativeEvent e, ulong payload)
		{
			if (null == OpenXRSettings.Instance)
			{
				return;
			}
			foreach (OpenXRFeature feature in OpenXRSettings.Instance.features)
			{
				if (!(feature == null) && feature.enabled)
				{
					switch (e)
					{
					case OpenXRFeature.NativeEvent.XrSetupConfigValues:
						feature.OnFormFactorChange(OpenXRFeature.Internal_GetFormFactor());
						feature.OnEnvironmentBlendModeChange(OpenXRFeature.Internal_GetEnvironmentBlendMode());
						feature.OnViewConfigurationTypeChange(OpenXRFeature.Internal_GetViewConfigurationType());
						break;
					case OpenXRFeature.NativeEvent.XrSystemIdChanged:
						feature.OnSystemChange(payload);
						break;
					case OpenXRFeature.NativeEvent.XrInstanceChanged:
						feature.failedInitialization = !feature.OnInstanceCreate(payload);
						OpenXRFeature.requiredFeatureFailed |= (feature.required && feature.failedInitialization);
						break;
					case OpenXRFeature.NativeEvent.XrSessionChanged:
						feature.OnSessionCreate(payload);
						break;
					case OpenXRFeature.NativeEvent.XrBeginSession:
						feature.OnSessionBegin(payload);
						break;
					case OpenXRFeature.NativeEvent.XrSessionStateChanged:
					{
						int oldState;
						int newState;
						OpenXRFeature.Internal_GetSessionState(out oldState, out newState);
						feature.OnSessionStateChange(oldState, newState);
						break;
					}
					case OpenXRFeature.NativeEvent.XrChangedSpaceApp:
						feature.OnAppSpaceChange(payload);
						break;
					case OpenXRFeature.NativeEvent.XrEndSession:
						feature.OnSessionEnd(payload);
						break;
					case OpenXRFeature.NativeEvent.XrDestroySession:
						feature.OnSessionDestroy(payload);
						break;
					case OpenXRFeature.NativeEvent.XrDestroyInstance:
						feature.OnInstanceDestroy(payload);
						break;
					case OpenXRFeature.NativeEvent.XrExiting:
						feature.OnSessionExiting(payload);
						break;
					case OpenXRFeature.NativeEvent.XrLossPending:
						feature.OnSessionLossPending(payload);
						break;
					case OpenXRFeature.NativeEvent.XrInstanceLossPending:
						feature.OnInstanceLossPending(payload);
						break;
					}
				}
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00005610 File Offset: 0x00003810
		internal static void Initialize()
		{
			OpenXRFeature.requiredFeatureFailed = false;
			OpenXRSettings instance = OpenXRSettings.Instance;
			if (instance == null || instance.features == null)
			{
				return;
			}
			foreach (OpenXRFeature feature in instance.features)
			{
				if (feature != null)
				{
					feature.failedInitialization = false;
				}
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00005664 File Offset: 0x00003864
		internal static void HookGetInstanceProcAddr()
		{
			IntPtr procAddr = OpenXRFeature.Internal_GetProcAddressPtr(true);
			OpenXRSettings instance = OpenXRSettings.Instance;
			if (instance != null && instance.features != null)
			{
				for (int featureIndex = instance.features.Length - 1; featureIndex >= 0; featureIndex--)
				{
					OpenXRFeature feature = instance.features[featureIndex];
					if (!(feature == null) && feature.enabled)
					{
						procAddr = feature.HookGetInstanceProcAddr(procAddr);
					}
				}
			}
			OpenXRFeature.Internal_SetProcAddressPtrAndLoadStage1(procAddr);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000056CC File Offset: 0x000038CC
		//protected ulong GetAction(InputAction inputAction)
		//{
		//	return OpenXRInput.GetActionHandle(inputAction, inputDevice: default);
		//}

		//// Token: 0x06000189 RID: 393 RVA: 0x000056D5 File Offset: 0x000038D5
		//protected ulong GetAction(InputSystem.InputDevice device, InputFeatureUsage usage)
		//{
		//	return OpenXRInput.GetActionHandle(device, usage);
		//}

		//// Token: 0x0600018A RID: 394 RVA: 0x000056DE File Offset: 0x000038DE
		//protected ulong GetAction(InputSystem.InputDevice device, string usageName)
		//{
		//	return OpenXRInput.GetActionHandle(device, usageName);
		//}

		// Token: 0x0600018B RID: 395 RVA: 0x000056E7 File Offset: 0x000038E7
		protected internal static ulong RegisterStatsDescriptor(string statName, OpenXRFeature.StatFlags statFlags)
		{
			return OpenXRFeature.runtime_RegisterStatsDescriptor(statName, statFlags);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000056F0 File Offset: 0x000038F0
		protected internal static void SetStatAsFloat(ulong statId, float value)
		{
			OpenXRFeature.runtime_SetStatAsFloat(statId, value);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000056F9 File Offset: 0x000038F9
		protected internal static void SetStatAsUInt(ulong statId, uint value)
		{
			OpenXRFeature.runtime_SetStatAsUInt(statId, value);
		}

		// Token: 0x0600018E RID: 398
		[DllImport("UnityOpenXR", EntryPoint = "Internal_PathToString")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_PathToStringPtr(ulong pathId, out IntPtr path);

		// Token: 0x0600018F RID: 399
		[DllImport("UnityOpenXR")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_StringToPath([MarshalAs(UnmanagedType.LPStr)] string str, out ulong pathId);

		// Token: 0x06000190 RID: 400
		[DllImport("UnityOpenXR")]
		[return: MarshalAs(UnmanagedType.U1)]
		private static extern bool Internal_GetCurrentInteractionProfile(ulong pathId, out ulong interactionProfile);

		// Token: 0x06000191 RID: 401
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetFormFactor")]
		private static extern int Internal_GetFormFactor();

		// Token: 0x06000192 RID: 402
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetViewConfigurationType")]
		private static extern int Internal_GetViewConfigurationType();

		// Token: 0x06000193 RID: 403
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetViewTypeFromRenderIndex")]
		private static extern int Internal_GetViewTypeFromRenderIndex(int renderPassIndex);

		// Token: 0x06000194 RID: 404
		[DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetXRSession")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool Internal_GetXRSession(out ulong xrSession);

		// Token: 0x06000195 RID: 405
		[DllImport("UnityOpenXR", EntryPoint = "session_GetSessionState")]
		private static extern void Internal_GetSessionState(out int oldState, out int newState);

		// Token: 0x06000196 RID: 406
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetEnvironmentBlendMode")]
		private static extern XrEnvironmentBlendMode Internal_GetEnvironmentBlendMode();

		// Token: 0x06000197 RID: 407
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetEnvironmentBlendMode")]
		private static extern void Internal_SetEnvironmentBlendMode(XrEnvironmentBlendMode xrEnvironmentBlendMode);

		// Token: 0x06000198 RID: 408
		[DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetAppSpace")]
		[return: MarshalAs(UnmanagedType.U1)]
		internal static extern bool Internal_GetAppSpace(out ulong appSpace);

		// Token: 0x06000199 RID: 409
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_GetProcAddressPtr")]
		internal static extern IntPtr Internal_GetProcAddressPtr([MarshalAs(UnmanagedType.I1)] bool loaderDefault);

		// Token: 0x0600019A RID: 410
		[DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetProcAddressPtrAndLoadStage1")]
		internal static extern void Internal_SetProcAddressPtrAndLoadStage1(IntPtr func);

		// Token: 0x0600019B RID: 411
		[DllImport("UnityOpenXR")]
		internal static extern ulong runtime_RegisterStatsDescriptor(string statName, OpenXRFeature.StatFlags statFlags);

		// Token: 0x0600019C RID: 412
		[DllImport("UnityOpenXR")]
		internal static extern void runtime_SetStatAsFloat(ulong statId, float value);

		// Token: 0x0600019D RID: 413
		[DllImport("UnityOpenXR")]
		internal static extern void runtime_SetStatAsUInt(ulong statId, uint value);

		// Token: 0x0400019E RID: 414
		//[FormerlySerializedAs("enabled")]
		//[HideInInspector]
		//[SerializeField]
		private bool m_enabled;

		// Token: 0x040001A1 RID: 417
		//[SerializeField]
		//[HideInInspector]
		internal string nameUi;

		// Token: 0x040001A2 RID: 418
		//[HideInInspector]
		//[SerializeField]
		internal string version;

		// Token: 0x040001A3 RID: 419
		//[HideInInspector]
		//[SerializeField]
		internal string featureIdInternal;

		// Token: 0x040001A4 RID: 420
		//[HideInInspector]
		//[SerializeField]
		internal string openxrExtensionStrings;

		// Token: 0x040001A5 RID: 421
		//[HideInInspector]
		//[SerializeField]
		internal string company;

		// Token: 0x040001A6 RID: 422
		//[SerializeField]
		//[HideInInspector]
		internal int priority;

		// Token: 0x040001A7 RID: 423
		//[SerializeField]
		//[HideInInspector]
		internal bool required;

		// Token: 0x040001A8 RID: 424
		[NonSerialized]
		internal bool internalFieldsUpdated;

		// Token: 0x040001A9 RID: 425
		private const string Library = "UnityOpenXR";

		// Token: 0x02000044 RID: 68
		internal enum LoaderEvent
		{
			// Token: 0x040001AB RID: 427
			SubsystemCreate,
			// Token: 0x040001AC RID: 428
			SubsystemDestroy,
			// Token: 0x040001AD RID: 429
			SubsystemStart,
			// Token: 0x040001AE RID: 430
			SubsystemStop
		}

		// Token: 0x02000045 RID: 69
		internal enum NativeEvent
		{
			// Token: 0x040001B0 RID: 432
			XrSetupConfigValues,
			// Token: 0x040001B1 RID: 433
			XrSystemIdChanged,
			// Token: 0x040001B2 RID: 434
			XrInstanceChanged,
			// Token: 0x040001B3 RID: 435
			XrSessionChanged,
			// Token: 0x040001B4 RID: 436
			XrBeginSession,
			// Token: 0x040001B5 RID: 437
			XrSessionStateChanged,
			// Token: 0x040001B6 RID: 438
			XrChangedSpaceApp,
			// Token: 0x040001B7 RID: 439
			XrEndSession,
			// Token: 0x040001B8 RID: 440
			XrDestroySession,
			// Token: 0x040001B9 RID: 441
			XrDestroyInstance,
			// Token: 0x040001BA RID: 442
			XrIdle,
			// Token: 0x040001BB RID: 443
			XrReady,
			// Token: 0x040001BC RID: 444
			XrSynchronized,
			// Token: 0x040001BD RID: 445
			XrVisible,
			// Token: 0x040001BE RID: 446
			XrFocused,
			// Token: 0x040001BF RID: 447
			XrStopping,
			// Token: 0x040001C0 RID: 448
			XrExiting,
			// Token: 0x040001C1 RID: 449
			XrLossPending,
			// Token: 0x040001C2 RID: 450
			XrInstanceLossPending,
			// Token: 0x040001C3 RID: 451
			XrRestartRequested,
			// Token: 0x040001C4 RID: 452
			XrRequestRestartLoop,
			// Token: 0x040001C5 RID: 453
			XrRequestGetSystemLoop
		}

		// Token: 0x02000046 RID: 70
		[Flags]
		protected internal enum StatFlags
		{
			// Token: 0x040001C7 RID: 455
			StatOptionNone = 0,
			// Token: 0x040001C8 RID: 456
			ClearOnUpdate = 1,
			// Token: 0x040001C9 RID: 457
			All = 1
		}
	}
}
