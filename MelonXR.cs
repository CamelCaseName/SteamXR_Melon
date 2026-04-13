using Il2CppInterop.Runtime;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using SteamVR_Melon.Standalone;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.Rendering;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR.OpenXR.Features.Interactions;
using InputControlAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlAttribute;
using InputControlLayoutAttribute = UnityEngine.XR.OpenXR.Il2CppShenanigans.InputControlLayoutAttribute;

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
            UnityEngine.Object.DontDestroyOnLoad(obj);
            MelonLogger.Msg("Creating XRManagerSettings");

            XRGeneralSettings.Instance.Manager = ScriptableObject.CreateInstance<XRManagerSettings>();
            UnityEngine.Object.DontDestroyOnLoad(XRGeneralSettings.Instance);
            UnityEngine.Object.DontDestroyOnLoad(XRGeneralSettings.Instance.Manager);
            var loader = ScriptableObject.CreateInstance<OpenXRLoader>();
            UnityEngine.Object.DontDestroyOnLoad(loader);
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

                if (d.id.Contains("Display") && xrDisplay is null)
                {
                    var disp = d.Cast<XRDisplaySubsystemDescriptor>();
                    MelonLogger.Msg("creating display instance");
                    var inst = disp.Create();

                    xrDisplay = inst.Cast<XRDisplaySubsystem>();
                }
                else if (d.id.Contains("Input") && xrInput is null)
                {
                    var inp = d.Cast<XRInputSubsystemDescriptor>();
                    MelonLogger.Msg("creating input instance");
                    var inst = inp.Create();

                    xrInput = inst.Cast<XRInputSubsystem>();
                }
            }

            MelonLogger.Msg("Starting XR Subsystems");
            XRGeneralSettings.Instance.Manager.StartSubsystems();

            foreach (var supported in XRGraphics.supportedDevices)
            {
                MelonLogger.Msg("supported: " + supported);
            }
            list.Add(obj);
            list.Add(list);
            list.Add(XRGeneralSettings.Instance);
            list.Add(XRGeneralSettings.Instance.Manager);
            list.Add(loader);

            RegisterAllInputDevices();
        }

        private static void RegisterAllInputDevices()
        {
            Assembly assembly = typeof(DPadInteraction).Assembly;
            var types = from type in assembly.GetTypes()
                        where Attribute.IsDefined(type, typeof(InputControlLayoutAttribute))
                        select type;
            foreach (var type in types)
            {
                MelonLogger.Msg($"type found: {type.Name} populating....");
                var fields = from field in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)
                             where Attribute.IsDefined(field, typeof(InputControlAttribute))
                             select field;
                MelonLogger.Msg("field count found: " + fields.Count());
                InputControlLayout.Builder builder = new()
                {
                    type = Il2CppType.From(type)
                };

                MelonLogger.Msg("building " + type.Name);
                var layout = builder.Build();
                MelonLogger.Msg("built " + type.Name);
                if (fields.Any())
                {
                    InputSystem.s_Manager.RegisterControlLayout(type.Name, layout.type);
                    MelonLogger.Msg("registered " + type.Name);
                }
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
