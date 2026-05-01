using Il2CppAOT;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using SteamVR_Melon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR.Features;
using UnityEngine.XR.OpenXR.Features.Interactions;
using UnityEngine.XR.OpenXR.Input;

namespace UnityEngine.XR.OpenXR
{
    // Token: 0x02000012 RID: 18
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRLoaderBase : XRLoaderHelper
    {
        public OpenXRLoaderBase() : base(ClassInjector.DerivedConstructorPointer<OpenXRLoaderBase>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRLoaderBase(IntPtr ptr) : base(ptr) { }
        // Token: 0x1700000E RID: 14
        // (get) Token: 0x0600005C RID: 92 RVA: 0x000027E2 File Offset: 0x000009E2
        // (set) Token: 0x0600005D RID: 93 RVA: 0x000027E9 File Offset: 0x000009E9
        internal static OpenXRLoaderBase Instance { get; private set; }

        // Token: 0x1700000F RID: 15
        // (get) Token: 0x0600005E RID: 94 RVA: 0x000027F1 File Offset: 0x000009F1
        // (set) Token: 0x0600005F RID: 95 RVA: 0x000027F9 File Offset: 0x000009F9
        [HideFromIl2Cpp]
        internal OpenXRLoaderBase.LoaderState currentLoaderState { get; private set; }

        private Action OnApplicationRender = null;

        // Token: 0x17000010 RID: 16
        // (get) Token: 0x06000060 RID: 96 RVA: 0x00002802 File Offset: 0x00000A02
        internal XRDisplaySubsystem displaySubsystem
        {
            get
            {
                return this.GetLoadedSubsystem<XRDisplaySubsystem>();
            }
        }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000061 RID: 97 RVA: 0x0000280A File Offset: 0x00000A0A
        internal XRInputSubsystem inputSubsystem
        {
            get
            {
                OpenXRLoaderBase instance = OpenXRLoaderBase.Instance;
                if (instance == null)
                {
                    return null;
                }
                return instance.GetLoadedSubsystem<XRInputSubsystem>();
            }
        }

        // Token: 0x17000012 RID: 18
        // (get) Token: 0x06000062 RID: 98 RVA: 0x0000281C File Offset: 0x00000A1C
        private bool isInitialized
        {
            get
            {
                return this.currentLoaderState != OpenXRLoaderBase.LoaderState.Uninitialized && this.currentLoaderState != OpenXRLoaderBase.LoaderState.DeinitializeAttempted;
            }
        }

        // Token: 0x17000013 RID: 19
        // (get) Token: 0x06000063 RID: 99 RVA: 0x00002834 File Offset: 0x00000A34
        private bool isStarted
        {
            get
            {
                return this.runningStates.Contains(this.currentLoaderState);
            }
        }

        // Token: 0x06000064 RID: 100 RVA: 0x00002848 File Offset: 0x00000A48
        private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            ulong section = DiagnosticReport.GetSection("Unhandled Exception Report");
            DiagnosticReport.AddSectionEntry(section, "Is Terminating", string.Format("{0}", args.IsTerminating));
            Exception e = (Exception)args.ExceptionObject;
            DiagnosticReport.AddSectionEntry(section, "Message", e.Message ?? "");
            DiagnosticReport.AddSectionEntry(section, "Source", e.Source ?? "");
            DiagnosticReport.AddSectionEntry(section, "Stack Trace", "\n" + e.StackTrace);
            DiagnosticReport.DumpReport("Uncaught Exception");
        }

        // Token: 0x06000065 RID: 101 RVA: 0x000028E4 File Offset: 0x00000AE4
        public override bool Initialize()
        {
            if (this.currentLoaderState == OpenXRLoaderBase.LoaderState.Initialized)
            {
                return true;
            }
            if (!this.validLoaderInitStates.Contains(this.currentLoaderState))
            {
                return false;
            }
            if (OpenXRLoaderBase.Instance != null)
            {
                MelonLogger.Error("Only one OpenXRLoader can be initialized at any given time");
                return false;
            }
            DiagnosticReport.StartReport();
            try
            {
                if (this.InitializeInternal())
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                MelonLogger.Error(exception);
            }
            this.Deinitialize();
            OpenXRLoaderBase.Instance = null;
            OpenXRAnalytics.SendInitializeEvent(false);
            return false;
        }

        // Token: 0x06000066 RID: 102 RVA: 0x0000296C File Offset: 0x00000B6C
        private bool InitializeInternal()
        {
            OpenXRLoaderBase.Instance = this;
            OnApplicationRender = new System.Action(ProcessOpenXRMessageLoop);
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.InitializeAttempted;
            OpenXRLoaderBase.Internal_SetSuccessfullyInitialized(false);
            //todo re-enable??
            OpenXRInput.RegisterLayouts();
            OpenXRFeature.Initialize();
            if (!this.LoadOpenXRSymbols())
            {
                MelonLogger.Error("Failed to load openxr runtime loader.");
                return false;
            }
            OpenXRSettings.Instance.features = (from f in OpenXRSettings.Instance.features
                                                where f != null
                                                orderby f.priority descending, f.nameUi
                                                select f).ToArray<OpenXRFeature>();
            OpenXRFeature.HookGetInstanceProcAddr();
            if (!OpenXRLoaderBase.Internal_InitializeSession())
            {
                return false;
            }
            this.RequestOpenXRFeatures();
            OpenXRLoaderBase.RegisterOpenXRCallbacks();
            if (null != OpenXRSettings.Instance)
            {
                OpenXRSettings.Instance.ApplySettings();
            }
            if (!this.CreateSubsystems())
            {
                return false;
            }
            if (OpenXRFeature.requiredFeatureFailed)
            {
                return false;
            }
            this.SetApplicationInfo();
            OpenXRAnalytics.SendInitializeEvent(true);
            OpenXRFeature.ReceiveLoaderEvent(this, OpenXRFeature.LoaderEvent.SubsystemCreate);
            OpenXRLoaderBase.DebugLogEnabledSpecExtensions();
            UnityHooks.OnPreCull += OnApplicationRender;
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.Initialized;
            return true;
        }

        // Token: 0x06000067 RID: 103 RVA: 0x00002AA4 File Offset: 0x00000CA4
        private bool CreateSubsystems()
        {
            if (this.displaySubsystem == null)
            {
                this.CreateSubsystem<XRDisplaySubsystemDescriptor, XRDisplaySubsystem>(OpenXRLoaderBase.s_DisplaySubsystemDescriptors, "OpenXR Display");
                if (this.displaySubsystem == null)
                {
                    return false;
                }
            }
            if (this.inputSubsystem == null)
            {
                this.CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(OpenXRLoaderBase.s_InputSubsystemDescriptors, "OpenXR Input");
                if (this.inputSubsystem == null)
                {
                    return false;
                }
            }
            return true;
        }

        // Token: 0x06000068 RID: 104 RVA: 0x00002AF8 File Offset: 0x00000CF8
        internal void ProcessOpenXRMessageLoop()
        {
            if (this.currentOpenXRState == OpenXRFeature.NativeEvent.XrIdle || this.currentOpenXRState == OpenXRFeature.NativeEvent.XrStopping || this.currentOpenXRState == OpenXRFeature.NativeEvent.XrExiting || this.currentOpenXRState == OpenXRFeature.NativeEvent.XrLossPending || this.currentOpenXRState == OpenXRFeature.NativeEvent.XrInstanceLossPending)
            {
                float time = Time.realtimeSinceStartup;
                if ((double)time - this.lastPollCheckTime < 0.1)
                {
                    return;
                }
                this.lastPollCheckTime = (double)time;
            }
            //if (messagepump_Loop is null)
            //{
            //    Marshal.GetFunctionPointerForDelegate(messagepump_Loop);
            //}
            OpenXRLoaderBase.Internal_PumpMessageLoop();
        }

        // Token: 0x06000069 RID: 105 RVA: 0x00002B60 File Offset: 0x00000D60
        public override bool Start()
        {
            if (this.currentLoaderState == OpenXRLoaderBase.LoaderState.Started)
            {
                return true;
            }
            if (!this.validLoaderStartStates.Contains(this.currentLoaderState))
            {
                return false;
            }
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.StartAttempted;
            if (!this.StartInternal())
            {
                this.Stop();
                return false;
            }
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.Started;
            return true;
        }

        // Token: 0x0600006A RID: 106 RVA: 0x00002BB0 File Offset: 0x00000DB0
        private bool StartInternal()
        {
            if (!OpenXRLoaderBase.Internal_CreateSessionIfNeeded())
            {
                return false;
            }
            if (this.currentOpenXRState != OpenXRFeature.NativeEvent.XrReady || (this.currentLoaderState != OpenXRLoaderBase.LoaderState.StartAttempted && this.currentLoaderState != OpenXRLoaderBase.LoaderState.Started))
            {
                return true;
            }
            this.StartSubsystem<XRDisplaySubsystem>();
            XRDisplaySubsystem displaySubsystem = this.displaySubsystem;
            if (displaySubsystem != null && !displaySubsystem.running)
            {
                return false;
            }
            OpenXRLoaderBase.Internal_BeginSession();
            if (!this.actionSetsAttached)
            {
                OpenXRInput.AttachActionSets();
                this.actionSetsAttached = true;
            }
            XRDisplaySubsystem displaySubsystem2 = this.displaySubsystem;
            if (displaySubsystem2 != null && !displaySubsystem2.running)
            {
                this.StartSubsystem<XRDisplaySubsystem>();
            }
            XRInputSubsystem inputSubsystem = this.inputSubsystem;
            if (inputSubsystem != null && !inputSubsystem.running)
            {
                this.StartSubsystem<XRInputSubsystem>();
            }
            XRInputSubsystem inputSubsystem2 = this.inputSubsystem;
            bool flag = inputSubsystem2 != null && inputSubsystem2.running;
            XRDisplaySubsystem displaySubsystem3 = this.displaySubsystem;
            bool displayRunning = displaySubsystem3 != null && displaySubsystem3.running;
            if (flag && displayRunning)
            {
                OpenXRFeature.ReceiveLoaderEvent(this, OpenXRFeature.LoaderEvent.SubsystemStart);
                return true;
            }
            return false;
        }

        // Token: 0x0600006B RID: 107 RVA: 0x00002C8C File Offset: 0x00000E8C
        public override bool Stop()
        {
            if (this.currentLoaderState == OpenXRLoaderBase.LoaderState.Stopped)
            {
                return true;
            }
            if (!this.validLoaderStopStates.Contains(this.currentLoaderState))
            {
                return false;
            }
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.StopAttempted;
            XRInputSubsystem inputSubsystem = this.inputSubsystem;
            bool obj = inputSubsystem != null && inputSubsystem.running;
            XRDisplaySubsystem displaySubsystem = this.displaySubsystem;
            bool displayRunning = displaySubsystem != null && displaySubsystem.running;
            bool obj2 = obj;
            if ((obj2 || displayRunning))
            {
                OpenXRFeature.ReceiveLoaderEvent(this, OpenXRFeature.LoaderEvent.SubsystemStop);
            }
            if (obj2)
            {
                this.StopSubsystem<XRInputSubsystem>();
            }
            if (displayRunning)
            {
                this.StopSubsystem<XRDisplaySubsystem>();
            }
            this.StopInternal();
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.Stopped;
            return true;
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00002D11 File Offset: 0x00000F11
        private void StopInternal()
        {
            OpenXRLoaderBase.Internal_EndSession();
            this.ProcessOpenXRMessageLoop();
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00002D20 File Offset: 0x00000F20
        public override bool Deinitialize()
        {
            if (this.currentLoaderState == OpenXRLoaderBase.LoaderState.Uninitialized)
            {
                return true;
            }
            if (!this.validLoaderDeinitStates.Contains(this.currentLoaderState))
            {
                return false;
            }
            this.currentLoaderState = OpenXRLoaderBase.LoaderState.DeinitializeAttempted;
            bool result;
            try
            {
                OpenXRLoaderBase.Internal_RequestExitSession();
                UnityHooks.OnPreCull -= OnApplicationRender;
                this.ProcessOpenXRMessageLoop();
                OpenXRFeature.ReceiveLoaderEvent(this, OpenXRFeature.LoaderEvent.SubsystemDestroy);
                this.DestroySubsystem<XRInputSubsystem>();
                this.DestroySubsystem<XRDisplaySubsystem>();
                DiagnosticReport.DumpReport("System Shutdown");
                OpenXRLoaderBase.Internal_DestroySession();
                this.ProcessOpenXRMessageLoop();
                OpenXRLoaderBase.Internal_UnloadOpenXRLibrary();
                this.currentLoaderState = OpenXRLoaderBase.LoaderState.Uninitialized;
                this.actionSetsAttached = false;
                if (this.unhandledExceptionHandler != null)
                {
                    AppDomain.CurrentDomain.UnhandledException -= this.unhandledExceptionHandler;
                    this.unhandledExceptionHandler = null;
                }
                result = base.Deinitialize();
            }
            finally
            {
                OpenXRLoaderBase.Instance = null;
            }
            return result;
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00002DEC File Offset: 0x00000FEC
        [HideFromIl2Cpp]
        internal new void CreateSubsystem<TDescriptor, TSubsystem>(Il2CppSystem.Collections.Generic.List<TDescriptor> descriptors, string id) where TDescriptor : IntegratedSubsystemDescriptor<TSubsystem> where TSubsystem : IntegratedSubsystem
        {
            base.CreateSubsystem<TDescriptor, TSubsystem>(descriptors, id);
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00002DF6 File Offset: 0x00000FF6
        [HideFromIl2Cpp]
        internal new void StartSubsystem<T>() where T : IntegratedSubsystem
        {
            base.StartSubsystem<T>();
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00002DFE File Offset: 0x00000FFE
        [HideFromIl2Cpp]
        internal new void StopSubsystem<T>() where T : IntegratedSubsystem
        {
            base.StopSubsystem<T>();
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00002E06 File Offset: 0x00001006
        [HideFromIl2Cpp]
        internal new void DestroySubsystem<T>() where T : IntegratedSubsystem
        {
            base.DestroySubsystem<T>();
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00002E10 File Offset: 0x00001010
        private void SetApplicationInfo()
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Application.version));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse<byte>(data);
            }
            uint applicationVersionHash = BitConverter.ToUInt32(data, 0);
            OpenXRLoaderBase.Internal_SetApplicationInfo(Application.productName, Application.version, applicationVersionHash, Application.unityVersion);
        }

        // Token: 0x06000073 RID: 115 RVA: 0x00002E61 File Offset: 0x00001061
        internal static byte[] StringToWCHAR_T(string s)
        {
            return ((Environment.OSVersion.Platform == PlatformID.Unix) ? Encoding.UTF32 : Encoding.Unicode).GetBytes(s + "\0");
        }

        // Token: 0x06000074 RID: 116 RVA: 0x00002E8C File Offset: 0x0000108C
        private bool LoadOpenXRSymbols()
        {
            return OpenXRLoaderBase.Internal_LoadOpenXRLibrary(OpenXRLoaderBase.StringToWCHAR_T("openxr_loader"));
        }

        // Token: 0x06000075 RID: 117 RVA: 0x00002EA4 File Offset: 0x000010A4
        private void RequestOpenXRFeatures()
        {
            OpenXRSettings instance = OpenXRSettings.Instance;
            if (instance == null || instance.features == null)
            {
                return;
            }
            this.featureLoggingInfo = new List<OpenXRLoaderBase.FeatureLoggingInfo>(instance.featureCount);
            foreach (OpenXRFeature feature in instance.features)
            {
                if (!(feature == null) && feature.enabled)
                {
                    this.featureLoggingInfo.Add(new OpenXRLoaderBase.FeatureLoggingInfo(feature.nameUi, feature.version, feature.company, feature.openxrExtensionStrings));
                    if (!string.IsNullOrEmpty(feature.openxrExtensionStrings))
                    {
                        foreach (string extensionString in feature.openxrExtensionStrings.Split(' ', StringSplitOptions.None))
                        {
                            if (!string.IsNullOrWhiteSpace(extensionString))
                            {
                                OpenXRLoaderBase.Internal_RequestEnableExtensionString(extensionString);
                            }
                        }
                    }
                }
            }
        }

        // Token: 0x06000076 RID: 118 RVA: 0x00002F7C File Offset: 0x0000117C
        private void LogRequestedOpenXRFeatures()
        {
            OpenXRSettings instance = OpenXRSettings.Instance;
            if (instance == null || instance.features == null)
            {
                return;
            }
            StringBuilder requestedLog = new("");
            StringBuilder failedLog = new("");
            uint count = 0U;
            uint failedCount = 0U;
            foreach (OpenXRLoaderBase.FeatureLoggingInfo feature in this.featureLoggingInfo)
            {
                requestedLog.Append(string.Concat(new string[]
                {
                    "  ",
                    feature.m_nameUi,
                    ": Version=",
                    feature.m_version,
                    ", Company=\"",
                    feature.m_company,
                    "\""
                }));
                if (!string.IsNullOrEmpty(feature.m_openxrExtensionStrings))
                {
                    requestedLog.Append(", Extensions=\"" + feature.m_openxrExtensionStrings + "\"");
                    foreach (string extensionString in feature.m_openxrExtensionStrings.Split(' ', StringSplitOptions.None))
                    {
                        if (!string.IsNullOrWhiteSpace(extensionString) && !OpenXRLoaderBase.Internal_IsExtensionEnabled(extensionString))
                        {
                            failedCount += 1U;
                            failedLog.Append(string.Concat(new string[]
                            {
                                "  ",
                                extensionString,
                                ": Feature=\"",
                                feature.m_nameUi,
                                "\": Version=",
                                feature.m_version,
                                ", Company=\"",
                                feature.m_company,
                                "\"\n"
                            }));
                        }
                    }
                }
                requestedLog.Append('\n');
            }
            ulong section = DiagnosticReport.GetSection("OpenXR Runtime Info");
            DiagnosticReport.AddSectionBreak(section);
            DiagnosticReport.AddSectionEntry(section, "Features requested to be enabled", string.Format("({0})\n{1}", count, requestedLog.ToString()));
            DiagnosticReport.AddSectionBreak(section);
            DiagnosticReport.AddSectionEntry(section, "Requested feature extensions not supported by runtime", string.Format("({0})\n{1}", failedCount, failedLog.ToString()));
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00003198 File Offset: 0x00001398
        private static void DebugLogEnabledSpecExtensions()
        {
            ulong section = DiagnosticReport.GetSection("OpenXR Runtime Info");
            DiagnosticReport.AddSectionBreak(section);
            string[] extensions = OpenXRRuntime.GetEnabledExtensions();
            StringBuilder log = new(string.Format("({0})\n", extensions.Length));
            foreach (string extension in extensions)
            {
                log.Append(string.Format("  {0}: Version={1}\n", extension, OpenXRRuntime.GetExtensionVersion(extension)));
            }
            DiagnosticReport.AddSectionEntry(section, "Runtime extensions enabled", log.ToString());
        }

        // Token: 0x06000078 RID: 120 RVA: 0x00003220 File Offset: 0x00001420
        //todo fixx callback
        //[MonoPInvokeCallback(typeof(OpenXRLoaderBase.ReceiveNativeEventDelegate))]
        private static void ReceiveNativeEvent(OpenXRFeature.NativeEvent e, ulong payload)
        {
            OpenXRLoaderBase loader = OpenXRLoaderBase.Instance;
            if (loader != null)
            {
                loader.currentOpenXRState = e;
            }
            if (e != OpenXRFeature.NativeEvent.XrBeginSession)
            {
                switch (e)
                {
                    case OpenXRFeature.NativeEvent.XrReady:
                        loader.StartInternal();
                        break;
                    case OpenXRFeature.NativeEvent.XrFocused:
                        DiagnosticReport.DumpReport("System Startup Completed");
                        break;
                    case OpenXRFeature.NativeEvent.XrStopping:
                        loader.StopInternal();
                        break;
                    case OpenXRFeature.NativeEvent.XrRestartRequested:
                        OpenXRRestarter.Instance.ShutdownAndRestart();
                        break;
                    case OpenXRFeature.NativeEvent.XrRequestRestartLoop:
                        MelonLogger.Warning("XR Initialization failed, will try to restart xr periodically.");
                        OpenXRRestarter.Instance.PauseAndShutdownAndRestart();
                        break;
                    case OpenXRFeature.NativeEvent.XrRequestGetSystemLoop:
                        OpenXRRestarter.Instance.PauseAndRetryInitialization();
                        break;
                }
            }
            else
            {
                loader.LogRequestedOpenXRFeatures();
            }
            OpenXRFeature.ReceiveNativeEvent(e, payload);
            if ((loader == null || !loader.isStarted) && e != OpenXRFeature.NativeEvent.XrInstanceChanged)
            {
                return;
            }
            switch (e)
            {
                case OpenXRFeature.NativeEvent.XrExiting:
                    OpenXRRestarter.Instance.Shutdown();
                    return;
                case OpenXRFeature.NativeEvent.XrLossPending:
                    OpenXRRestarter.Instance.ShutdownAndRestart();
                    return;
                case OpenXRFeature.NativeEvent.XrInstanceLossPending:
                    OpenXRRestarter.Instance.Shutdown();
                    return;
                default:
                    return;
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x00003322 File Offset: 0x00001522
        internal static void RegisterOpenXRCallbacks()
        {
            CallbackDelegate = new(OpenXRLoaderBase.ReceiveNativeEvent);
            NativeCallback = Marshal.GetFunctionPointerForDelegate(CallbackDelegate);
            OpenXRLoaderBase.Internal_SetCallbacks(NativeCallback);
        }

        // Token: 0x0600007A RID: 122
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "main_LoadOpenXRLibrary")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_LoadOpenXRLibrary(byte[] loaderPath);

        // Token: 0x0600007B RID: 123
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "main_UnloadOpenXRLibrary")]
        internal static extern void Internal_UnloadOpenXRLibrary();

        // Token: 0x0600007C RID: 124
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "NativeConfig_SetCallbacks")]
        private static extern void Internal_SetCallbacks(IntPtr callback);
        //private static extern void Internal_SetCallbacks(OpenXRLoaderBase.ReceiveNativeEventDelegate callback);

        // Token: 0x0600007D RID: 125
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "NativeConfig_SetApplicationInfo")]
        private static extern void Internal_SetApplicationInfo(string applicationName, string applicationVersion, uint applicationVersionHash, string engineVersion);

        // Token: 0x0600007E RID: 126
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_RequestExitSession")]
        internal static extern void Internal_RequestExitSession();

        // Token: 0x0600007F RID: 127
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_InitializeSession")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_InitializeSession();

        // Token: 0x06000080 RID: 128
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_CreateSessionIfNeeded")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_CreateSessionIfNeeded();

        // Token: 0x06000081 RID: 129
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_BeginSession")]
        internal static extern void Internal_BeginSession();

        // Token: 0x06000082 RID: 130
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_EndSession")]
        internal static extern void Internal_EndSession();

        // Token: 0x06000083 RID: 131
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_DestroySession")]
        internal static extern void Internal_DestroySession();

        //Todo fix
        //private delegate void MessagePumpCallback();
        //private MessagePumpCallback messagepump_Loop = new MessagePumpCallback(() => { MelonLogger.Msg("Messagepump"); });
        // Token: 0x06000084 RID: 132
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "messagepump_PumpMessageLoop")]
        private static extern void Internal_PumpMessageLoop();

        // Token: 0x06000085 RID: 133
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "session_SetSuccessfullyInitialized")]
        internal static extern void Internal_SetSuccessfullyInitialized([MarshalAs(UnmanagedType.I1)] bool value);

        // Token: 0x06000086 RID: 134
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", CharSet = CharSet.Unicode, EntryPoint = "unity_ext_RequestEnableExtensionString")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_RequestEnableExtensionString(string extensionString);

        // Token: 0x06000087 RID: 135
        [HideFromIl2Cpp]
        [DllImport("UnityOpenXR", EntryPoint = "unity_ext_IsExtensionEnabled", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Internal_IsExtensionEnabled(string extensionName);

        // Token: 0x04000041 RID: 65
        private List<OpenXRLoaderBase.FeatureLoggingInfo> featureLoggingInfo;

        // Token: 0x04000042 RID: 66
        private const double k_IdlePollingWaitTimeInSeconds = 0.1;

        // Token: 0x04000043 RID: 67
        private static Il2CppSystem.Collections.Generic.List<XRDisplaySubsystemDescriptor> s_DisplaySubsystemDescriptors = new();

        // Token: 0x04000044 RID: 68
        private static Il2CppSystem.Collections.Generic.List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new();

        // Token: 0x04000047 RID: 71
        private List<OpenXRLoaderBase.LoaderState> validLoaderInitStates = new()
        {
            OpenXRLoaderBase.LoaderState.Uninitialized,
            OpenXRLoaderBase.LoaderState.InitializeAttempted
        };

        // Token: 0x04000048 RID: 72
        private List<OpenXRLoaderBase.LoaderState> validLoaderStartStates = new()
        {
            OpenXRLoaderBase.LoaderState.Initialized,
            OpenXRLoaderBase.LoaderState.StartAttempted,
            OpenXRLoaderBase.LoaderState.Stopped
        };

        // Token: 0x04000049 RID: 73
        private List<OpenXRLoaderBase.LoaderState> validLoaderStopStates = new()
        {
            OpenXRLoaderBase.LoaderState.StartAttempted,
            OpenXRLoaderBase.LoaderState.Started,
            OpenXRLoaderBase.LoaderState.StopAttempted
        };

        // Token: 0x0400004A RID: 74
        private List<OpenXRLoaderBase.LoaderState> validLoaderDeinitStates = new()
        {
            OpenXRLoaderBase.LoaderState.InitializeAttempted,
            OpenXRLoaderBase.LoaderState.Initialized,
            OpenXRLoaderBase.LoaderState.Stopped,
            OpenXRLoaderBase.LoaderState.DeinitializeAttempted
        };

        // Token: 0x0400004B RID: 75
        private List<OpenXRLoaderBase.LoaderState> runningStates = new()
        {
            OpenXRLoaderBase.LoaderState.Initialized,
            OpenXRLoaderBase.LoaderState.StartAttempted,
            OpenXRLoaderBase.LoaderState.Started
        };

        // Token: 0x0400004C RID: 76
        private OpenXRFeature.NativeEvent currentOpenXRState;

        // Token: 0x0400004D RID: 77
        private bool actionSetsAttached = false;

        // Token: 0x0400004E RID: 78
        private UnhandledExceptionEventHandler unhandledExceptionHandler;

        // Token: 0x0400004F RID: 79
        internal bool DisableValidationChecksOnEnteringPlaymode;

        // Token: 0x04000050 RID: 80
        private double lastPollCheckTime;
        private static ReceiveNativeEventDelegate CallbackDelegate;
        private static IntPtr NativeCallback;

        // Token: 0x04000051 RID: 81
        private const string LibraryName = "UnityOpenXR";

        // Token: 0x02000013 RID: 19
        private class FeatureLoggingInfo
        {
            // Token: 0x0600008A RID: 138 RVA: 0x00003401 File Offset: 0x00001601
            public FeatureLoggingInfo(string nameUi, string version, string company, string extensionStrings)
            {
                this.m_nameUi = nameUi;
                this.m_version = version;
                this.m_company = company;
                this.m_openxrExtensionStrings = extensionStrings;
            }

            // Token: 0x04000052 RID: 82
            public string m_nameUi;

            // Token: 0x04000053 RID: 83
            public string m_version;

            // Token: 0x04000054 RID: 84
            public string m_company;

            // Token: 0x04000055 RID: 85
            public string m_openxrExtensionStrings;
        }

        // Token: 0x02000014 RID: 20
        internal enum LoaderState
        {
            // Token: 0x04000057 RID: 87
            Uninitialized,
            // Token: 0x04000058 RID: 88
            InitializeAttempted,
            // Token: 0x04000059 RID: 89
            Initialized,
            // Token: 0x0400005A RID: 90
            StartAttempted,
            // Token: 0x0400005B RID: 91
            Started,
            // Token: 0x0400005C RID: 92
            StopAttempted,
            // Token: 0x0400005D RID: 93
            Stopped,
            // Token: 0x0400005E RID: 94
            DeinitializeAttempted
        }

        // Token: 0x02000015 RID: 21
        // (Invoke) Token: 0x0600008C RID: 140
        internal delegate void ReceiveNativeEventDelegate(OpenXRFeature.NativeEvent e, ulong payload);
    }
}
