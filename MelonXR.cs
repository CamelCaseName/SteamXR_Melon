using MelonLoader;
using SteamVR_Melon.Standalone;
using System;
using System.Runtime.InteropServices;
using Unity.XR.OpenVR;
using UnityEngine;

namespace SteamXR_Melon
{
    public static class MelonXR
    {
        [DllImport("XRSDKOpenVR.dll", EntryPoint = "?Get@?$Singleton@VOpenVRSystem@@@@SAAEAVOpenVRSystem@@XZ", ExactSpelling = true)]
        private static extern IntPtr OpenVRSystem_Get();

        [DllImport("XRSDKOpenVR.dll", EntryPoint = "?Initialize@OpenVRSystem@@QEAA_NXZ", ExactSpelling = true)]
        private static extern void OpenVRSystem_Initialize(IntPtr _this);

        public static void Initialize()
        {

            PluginImporter.LoadPlugin(OpenVRMagic.XRSDKOpenVR);
            OpenVREvents.Initialize();
            ScriptableObject.CreateInstance<OpenVRSettings>();

            var openvr = OpenVRSystem_Get();
            //MelonLogger.Msg($"got openvr adress: {openvr:x}");
            OpenVRSystem_Initialize(openvr);
        }
    }
}
