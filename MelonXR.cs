using Il2CppSystem.Collections.Generic;
using MelonLoader;
using SteamVR_Melon.Standalone;
using System;
using System.Runtime.InteropServices;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using UnityEngine.XR;

namespace SteamXR_Melon
{
    public static class MelonXR
    {
        public static XRDisplaySubsystem xrDisplay;
        public static XRInputSubsystem xrInput;

        public static void Initialize()
        {
            //load the plugin
            PluginImporter.LoadPlugin(OpenVRMagic.XRSDKOpenVR);
            OpenVREvents.Initialize();
            ScriptableObject.CreateInstance<OpenVRSettings>();

            //register and initialize the iunitysubsystem lifecycle for the plugin
            //display first then input

            //we need to trigger a rescan via accessing the subsystems first
            List<XRDisplaySubsystem> displays = new();
            SubsystemManager.GetSubsystems(displays);

            //ref https://docs.unity3d.com/Manual/xrsdk-runtime-discovery.html

            //now the openvr systems can be accessed inside the integrated descriptor list
            foreach (var d in SubsystemDescriptorStore.s_IntegratedDescriptors)
            {
                MelonLogger.Msg("display id: " + d.id);

                //MelonLogger.Msg("casting the descriptor");

                if (d.id.Contains("Display"))
                {
                    var disp = d.Cast<XRDisplaySubsystemDescriptor>();
                    //MelonLogger.Msg(disp.disablesLegacyVr);
                    MelonLogger.Msg("creating display instance");
                    var inst = disp.Create();

                    //MelonLogger.Msg("casting instance");
                    xrDisplay = inst.Cast<XRDisplaySubsystem>();
                    MelonLogger.Msg("Starting openvr subsystem instance");
                    xrDisplay.Start();
                }
                else if (d.id.Contains("Input"))
                {
                    var inp = d.Cast<XRInputSubsystemDescriptor>();
                    //MelonLogger.Msg(inp.disablesLegacyInput);
                    MelonLogger.Msg("creating input instance");
                    var inst = inp.Create();

                    MelonLogger.Msg("casting instance");
                    xrInput = inst.Cast<XRInputSubsystem>();
                    xrInput.Start();
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
