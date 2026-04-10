using Il2CppSystem.Collections.Generic;
using MelonLoader;
using SteamVR_Melon.Standalone;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR.WindowsMR.Input;

namespace SteamXR_Melon
{
    public static class MelonXR
    {
        private static XRDisplaySubsystem xrDisplay;
        private static XRInputSubsystem xrInput;
        private static Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> list = new();

        public static void Initialize()
        {
            //load the plugin
            PluginImporter.LoadPlugin("UnityOpenXR");
            PluginImporter.LoadPlugin("openxr_loader");

            RegisterTypeInIl2Cpp.RegisterAssembly(typeof(XRGeneralSettings).Assembly);
            RegisterTypeInIl2Cpp.RegisterAssembly(typeof(OpenXRSettings).Assembly);

            OpenXRSettings.Instance.renderMode = OpenXRSettings.RenderMode.MultiPass;

            MelonLogger.Msg("Creating XRGeneralSettings");
            var obj = ScriptableObject.CreateInstance<XRGeneralSettings>();
            list.Add(obj);
            UnityEngine.Object.DontDestroyOnLoad(obj);
            MelonLogger.Msg("Creating XRManagerSettings");

            list.Add(list);

            XRGeneralSettings.Instance.Manager = ScriptableObject.CreateInstance<XRManagerSettings>();
            list.Add(XRGeneralSettings.Instance);
            UnityEngine.Object.DontDestroyOnLoad(XRGeneralSettings.Instance);
            list.Add(XRGeneralSettings.Instance.Manager);
            UnityEngine.Object.DontDestroyOnLoad(XRGeneralSettings.Instance.Manager);
            var loader = ScriptableObject.CreateInstance<OpenXRLoader>();
            UnityEngine.Object.DontDestroyOnLoad(loader);
            list.Add(loader);
            if (XRGeneralSettings.Instance.Manager.TryAddLoader(loader))
            {
                MelonLogger.Msg("Added OpenXRLoader");
            }
            //XRGeneralSettings.AttemptInitializeXRSDKOnLoad();

            MelonLogger.Msg("Initializing OpenXR Loader");
            XRGeneralSettings.Instance.Manager.InitializeLoaderSync();

            //register and initialize the iunitysubsystem lifecycle for the plugin
            //display first then input

            //we need to trigger a rescan via accessing the subsystems first
            List<XRDisplaySubsystem> displays = new();
            SubsystemManager.GetSubsystems(displays);

            //ref https://docs.unity3d.com/Manual/xrsdk-runtime-discovery.html

            //now the openxr systems can be accessed inside the integrated descriptor list
            foreach (var d in SubsystemDescriptorStore.s_IntegratedDescriptors)
            {
                MelonLogger.Msg("display id: " + d.id);

                //MelonLogger.Msg("casting the descriptor");

                if (d.id.Contains("Display") && xrDisplay is null)
                {
                    var disp = d.Cast<XRDisplaySubsystemDescriptor>();
                    //MelonLogger.Msg(disp.disablesLegacyVr);
                    MelonLogger.Msg("creating display instance");
                    var inst = disp.Create();

                    //MelonLogger.Msg("casting instance");
                    xrDisplay = inst.Cast<XRDisplaySubsystem>();
                }
                else if (d.id.Contains("Input") && xrInput is null)
                {
                    var inp = d.Cast<XRInputSubsystemDescriptor>();
                    //MelonLogger.Msg(inp.disablesLegacyInput);
                    MelonLogger.Msg("creating input instance");
                    var inst = inp.Create();

                    //MelonLogger.Msg("casting instance");
                    xrInput = inst.Cast<XRInputSubsystem>();
                }
            }

            MelonLogger.Msg("Starting XR Subsystems");
            XRGeneralSettings.Instance.Manager.StartSubsystems();

            foreach (var supported in XRGraphics.supportedDevices)
            {
                MelonLogger.Msg("supported: " + supported);
            }
        }
    }

    //ref https://github.com/Unity-Technologies/UnityCsReference/blob/5e328f0a4a3b155f977c7be4c91899c06f0eca83/Modules/Subsystems/IntegratedSubsystemDescriptor.bindings.cs
    public static class DescriptorExtender
    {
        public static IntegratedSubsystem Create<TSubsystem>(this IntegratedSubsystemDescriptor<TSubsystem> desc) where TSubsystem : IntegratedSubsystem
        {
            var m_Ptr = desc.Cast<IntegratedSubsystemDescriptor>().m_Ptr;
            MelonLogger.Msg($"m_ptr for {desc.id} 0x{m_Ptr:x}");
            IntPtr ptr = SubsystemDescriptorBindings.Create(m_Ptr);
            var subsystem = SubsystemManager.GetIntegratedSubsystemByPtr(ptr);

            if (subsystem != null)
            {
                subsystem.m_SubsystemDescriptor = desc.Cast<ISubsystemDescriptor>();
            }
            else
            {
                MelonLogger.Error("subsystem was null");
            }
            return subsystem;
        }
    }
}
