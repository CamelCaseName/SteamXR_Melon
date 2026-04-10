using Il2CppInterop.Runtime.Attributes;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.XR.Management
{
    // Token: 0x0200000A RID: 10
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public sealed class XRManagerSettings : ScriptableObject
    {
        public XRManagerSettings(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000007 RID: 7
        // (get) Token: 0x0600002B RID: 43 RVA: 0x000024F3 File Offset: 0x000006F3
        // (set) Token: 0x0600002C RID: 44 RVA: 0x000024FB File Offset: 0x000006FB
        public bool automaticLoading
        {
            get
            {
                return this.m_AutomaticLoading;
            }
            set
            {
                this.m_AutomaticLoading = value;
            }
        }

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x0600002D RID: 45 RVA: 0x00002504 File Offset: 0x00000704
        // (set) Token: 0x0600002E RID: 46 RVA: 0x0000250C File Offset: 0x0000070C
        public bool automaticRunning
        {
            get
            {
                return this.m_AutomaticRunning;
            }
            set
            {
                this.m_AutomaticRunning = value;
            }
        }

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x06000030 RID: 48 RVA: 0x00002515 File Offset: 0x00000715
        [HideFromIl2Cpp]
        public IReadOnlyList<XRLoader> activeLoaders
        {
            get
            {
                return this.m_Loaders;
            }
        }

        // Token: 0x1700000B RID: 11
        // (get) Token: 0x06000031 RID: 49 RVA: 0x0000251D File Offset: 0x0000071D
        public bool isInitializationComplete
        {
            get
            {
                return this.m_InitializationComplete;
            }
        }

        // Token: 0x1700000C RID: 12
        // (get) Token: 0x06000032 RID: 50 RVA: 0x00002525 File Offset: 0x00000725
        // (set) Token: 0x06000033 RID: 51 RVA: 0x0000252D File Offset: 0x0000072D
        //[HideInInspector]
        [HideFromIl2Cpp]
        public XRLoader activeLoader { get; private set; }

        // Token: 0x06000034 RID: 52 RVA: 0x00002536 File Offset: 0x00000736
        [HideFromIl2Cpp]
        public T ActiveLoaderAs<T>() where T : XRLoader
        {
            return this.activeLoader as T;
        }

        // Token: 0x06000035 RID: 53 RVA: 0x00002548 File Offset: 0x00000748
        public void InitializeLoaderSync()
        {
            if (this.activeLoader != null)
            {
                MelonLogger.Warning("XR Management has already initialized an active loader in this scene. Please make sure to stop all subsystems and deinitialize the active loader before initializing a new one.");
                return;
            }
            if (currentLoaders.Count == 0)
            {
                MelonLogger.Error("No Loaders to activate!");
                return;
            }
            foreach (XRLoader loader in this.currentLoaders)
            {
                if (loader != null && this.CheckGraphicsAPICompatibility(loader) && loader.Initialize())
                {
                    MelonLogger.Msg("Initialized OpenXRLoader: " + loader.name);
                    this.activeLoader = loader;
                    this.m_InitializationComplete = true;
                    return;
                }
            }
            this.activeLoader = null;
        }

        // Token: 0x06000036 RID: 54 RVA: 0x000025E0 File Offset: 0x000007E0
        [HideFromIl2Cpp]
        public IEnumerator InitializeLoader()
        {
            if (this.activeLoader != null)
            {
                MelonLogger.Warning("XR Management has already initialized an active loader in this scene. Please make sure to stop all subsystems and deinitialize the active loader before initializing a new one.");
                yield break;
            }
            if (currentLoaders.Count == 0)
            {
                MelonLogger.Error("No Loaders to activate!");
                yield break;
            }
            foreach (XRLoader loader in this.currentLoaders)
            {
                if (loader != null && this.CheckGraphicsAPICompatibility(loader) && loader.Initialize())
                {
                    MelonLogger.Msg("Initialized OpenXRLoader: " + loader.name);
                    this.activeLoader = loader;
                    this.m_InitializationComplete = true;
                    yield break;
                }
                yield return null;
            }
            this.activeLoader = null;
            yield break;
        }

        // Token: 0x06000037 RID: 55 RVA: 0x000025F0 File Offset: 0x000007F0
        public bool TryAddLoader(XRLoader loader, int index = -1)
        {
            if (loader == null || this.currentLoaders.Contains(loader))
            {
                MelonLogger.Msg("Added Loder was null");
                return false;
            }
            //we cant use the registered loaders because they would have to be set beforehand and uhh i cant
            //if (!this.m_RegisteredLoaders.Contains(loader))
            //{
            //    MelonLogger.Msg("Added Loder was not registered");
            //    return false;
            //}
            if (index < 0 || index >= this.currentLoaders.Count)
            {
                this.currentLoaders.Add(loader);
            }
            else
            {
                this.currentLoaders.Insert(index, loader);
            }
            return true;
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00002654 File Offset: 0x00000854
        public bool TryRemoveLoader(XRLoader loader)
        {
            bool removedLoader = true;
            if (this.currentLoaders.Contains(loader))
            {
                removedLoader = this.currentLoaders.Remove(loader);
            }
            return removedLoader;
        }

        // Token: 0x06000039 RID: 57 RVA: 0x00002680 File Offset: 0x00000880
        [HideFromIl2Cpp]
        public bool TrySetLoaders(List<XRLoader> reorderedLoaders)
        {
            List<XRLoader> originalLoaders = new List<XRLoader>(this.activeLoaders);
            this.currentLoaders.Clear();
            foreach (XRLoader loader in reorderedLoaders)
            {
                if (!this.TryAddLoader(loader, -1))
                {
                    this.currentLoaders = originalLoaders;
                    return false;
                }
            }
            return true;
        }

        // Token: 0x0600003A RID: 58 RVA: 0x000026F8 File Offset: 0x000008F8
        private void Awake()
        {
            MelonLogger.Msg("XRManager awaken");
            foreach (XRLoader loader in this.currentLoaders)
            {
                if (!this.m_RegisteredLoaders.Contains(loader))
                {
                    this.m_RegisteredLoaders.Add(loader);
                }
            }
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00002760 File Offset: 0x00000960
        private bool CheckGraphicsAPICompatibility(XRLoader loader)
        {
            GraphicsDeviceType deviceType = SystemInfo.graphicsDeviceType;
            List<GraphicsDeviceType> supportedDeviceTypes = loader.GetSupportedGraphicsDeviceTypes(false);
            if (supportedDeviceTypes.Count > 0 && !supportedDeviceTypes.Contains(deviceType))
            {
                MelonLogger.Warning(string.Format("The {0} does not support the initialized graphics device, {1}. Please change the preffered Graphics API in PlayerSettings. Attempting to start the next XR loader.", loader.name, deviceType.ToString()));
                return false;
            }
            return true;
        }

        // Token: 0x0600003C RID: 60 RVA: 0x000027B2 File Offset: 0x000009B2
        public void StartSubsystems()
        {
            if (!this.m_InitializationComplete)
            {
                MelonLogger.Warning("Call to StartSubsystems without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
                return;
            }
            if (this.activeLoader != null)
            {
                this.activeLoader.Start();
            }
        }

        // Token: 0x0600003D RID: 61 RVA: 0x000027E1 File Offset: 0x000009E1
        public void StopSubsystems()
        {
            if (!this.m_InitializationComplete)
            {
                MelonLogger.Warning("Call to StopSubsystems without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
                return;
            }
            if (this.activeLoader != null)
            {
                this.activeLoader.Stop();
            }
        }

        // Token: 0x0600003E RID: 62 RVA: 0x00002810 File Offset: 0x00000A10
        public void DeinitializeLoader()
        {
            if (!this.m_InitializationComplete)
            {
                MelonLogger.Warning("Call to DeinitializeLoader without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
                return;
            }
            this.StopSubsystems();
            if (this.activeLoader != null)
            {
                this.activeLoader.Deinitialize();
                this.activeLoader = null;
            }
            this.m_InitializationComplete = false;
        }

        // Token: 0x0600003F RID: 63 RVA: 0x0000285E File Offset: 0x00000A5E
        private void Start()
        {
            if (this.automaticLoading && this.automaticRunning)
            {
                this.StartSubsystems();
            }
        }

        // Token: 0x06000040 RID: 64 RVA: 0x00002876 File Offset: 0x00000A76
        private void OnDisable()
        {
            if (this.automaticLoading && this.automaticRunning)
            {
                this.StopSubsystems();
            }
        }

        // Token: 0x06000041 RID: 65 RVA: 0x0000288E File Offset: 0x00000A8E
        private void OnDestroy()
        {
            if (this.automaticLoading)
            {
                this.DeinitializeLoader();
            }
        }

        // Token: 0x1700000D RID: 13
        // (get) Token: 0x06000042 RID: 66 RVA: 0x00002515 File Offset: 0x00000715
        // (set) Token: 0x06000043 RID: 67 RVA: 0x0000289E File Offset: 0x00000A9E
        [HideFromIl2Cpp]
        internal List<XRLoader> currentLoaders
        {
            get
            {
                return this.m_Loaders;
            }
            set
            {
                this.m_Loaders = value;
            }
        }

        // Token: 0x1700000E RID: 14
        // (get) Token: 0x06000044 RID: 68 RVA: 0x000028A7 File Offset: 0x00000AA7
        [HideFromIl2Cpp]
        internal HashSet<XRLoader> registeredLoaders
        {
            get
            {
                return this.m_RegisteredLoaders;
            }
        }

        // Token: 0x04000019 RID: 25
        //[HideInInspector]
        private bool m_InitializationComplete;

        // Token: 0x0400001A RID: 26
        //[SerializeField]
        //[HideInInspector]
        private bool m_RequiresSettingsUpdate;

        // Token: 0x0400001B RID: 27
        //[SerializeField]
        //[Tooltip("Determines if the XR Manager instance is responsible for creating and destroying the appropriate loader instance.")]
        //[FormerlySerializedAs("AutomaticLoading")]
        private bool m_AutomaticLoading = false;

        // Token: 0x0400001C RID: 28
        //[Tooltip("Determines if the XR Manager instance is responsible for starting and stopping subsystems for the active loader instance.")]
        //[SerializeField]
        //[FormerlySerializedAs("AutomaticRunning")]
        private bool m_AutomaticRunning = false;

        // Token: 0x0400001D RID: 29
        //[FormerlySerializedAs("Loaders")]
        //[SerializeField]
        //[Tooltip("List of XR Loader instances arranged in desired load order.")]
        private List<XRLoader> m_Loaders = new List<XRLoader>();

        // Token: 0x0400001E RID: 30
        //[HideInInspector]
        //[SerializeField]
        private HashSet<XRLoader> m_RegisteredLoaders = new HashSet<XRLoader>();
    }
}
