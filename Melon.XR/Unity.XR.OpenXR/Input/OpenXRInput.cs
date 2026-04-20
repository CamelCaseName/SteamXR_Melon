using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Playables;
using UnityEngine.XR.OpenXR.Features;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace UnityEngine.XR.OpenXR.Input
{
    // Token: 0x0200003A RID: 58
    public static class OpenXRInput
    {
        // Token: 0x060000FC RID: 252 RVA: 0x000041BC File Offset: 0x000023BC
        internal static void RegisterLayouts()
        {
            MelonLogger.Msg("Registering haptic control layout");
            InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<HapticControl>(), "Haptic", new Il2CppSystem.Nullable<InputDeviceMatcher>());
            //InputSystem.InputSystem.RegisterLayout
            MelonLogger.Msg("Registering openxrdevice control layout");
            InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<OpenXRDevice>(), "OpenXRDevice", new Il2CppSystem.Nullable<InputDeviceMatcher>());

            InputDeviceMatcher inputDeviceMatcher = new();
            inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            inputDeviceMatcher = inputDeviceMatcher.WithProduct("Head Tracking - OpenXR", true);
            inputDeviceMatcher = inputDeviceMatcher.WithManufacturer("OpenXR", true);

            MelonLogger.Msg("Registering openxrhmd control layout");
            InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<OpenXRHmd>(), "OpenXRHmd", new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher));
            OpenXRInteractionFeature.RegisterLayouts();
        }

        // Token: 0x060000FD RID: 253 RVA: 0x0000422C File Offset: 0x0000242C
        private static bool ValidateActionMapConfig(OpenXRInteractionFeature interactionFeature, OpenXRInteractionFeature.ActionMapConfig actionMapConfig)
        {
            bool valid = true;
            if (actionMapConfig.deviceInfos == null || actionMapConfig.deviceInfos.Count == 0)
            {
                MelonLogger.Error(string.Format("ActionMapConfig contains no `deviceInfos` in InteractionFeature '{0}'", interactionFeature.GetType()));
                valid = false;
            }
            if (actionMapConfig.actions == null || actionMapConfig.actions.Count == 0)
            {
                MelonLogger.Error(string.Format("ActionMapConfig contains no `actions` in InteractionFeature '{0}'", interactionFeature.GetType()));
                valid = false;
            }
            return valid;
        }

        // Token: 0x060000FE RID: 254 RVA: 0x00004294 File Offset: 0x00002494
        internal static void AttachActionSets()
        {
            MelonLogger.Msg("[HPVR Input] Attaching action sets");
            List<OpenXRInteractionFeature.ActionMapConfig> actionMaps = new();
            List<OpenXRInteractionFeature.ActionMapConfig> additiveActionMaps = new();
            foreach (OpenXRInteractionFeature interactionFeature in from f in OpenXRSettings.Instance.features.OfType<OpenXRInteractionFeature>()
                                                                    where f.enabled && !f.IsAdditive
                                                                    select f)
            {
                int start = actionMaps.Count;
                interactionFeature.CreateActionMaps(actionMaps);
                for (int index = actionMaps.Count - 1; index >= start; index--)
                {
                    if (!OpenXRInput.ValidateActionMapConfig(interactionFeature, actionMaps[index]))
                    {
                        actionMaps.RemoveAt(index);
                    }
                }
            }
            if (!OpenXRInput.RegisterDevices(actionMaps, false))
            {
                MelonLogger.Msg("[HPVR Input] Could not register devices");
                return;
            }
            foreach (OpenXRInteractionFeature openXRInteractionFeature in from f in OpenXRSettings.Instance.features.OfType<OpenXRInteractionFeature>()
                                                                          where f.enabled && f.IsAdditive
                                                                          select f)
            {
                MelonLogger.Msg("registeruing feature for:" + openXRInteractionFeature.name);
                openXRInteractionFeature.CreateActionMaps(additiveActionMaps);
                openXRInteractionFeature.AddAdditiveActions(actionMaps, additiveActionMaps[^1]);
            }
            Dictionary<string, List<OpenXRInput.SerializedBinding>> interactionProfiles = new();
            if (!OpenXRInput.CreateActions(actionMaps, interactionProfiles))
            {
                MelonLogger.Msg("[HPVR Input] Could not create actions");
                return;
            }
            if (additiveActionMaps.Count > 0)
            {
                OpenXRInput.RegisterDevices(additiveActionMaps, true);
                OpenXRInput.CreateActions(additiveActionMaps, interactionProfiles);
            }
            OpenXRInput.SetDpadBindingCustomValues();
            foreach (KeyValuePair<string, List<OpenXRInput.SerializedBinding>> kv in interactionProfiles)
            {
                if (!OpenXRInput.Internal_SuggestBindings(kv.Key, kv.Value.ToArray(), (uint)kv.Value.Count))
                {
                    OpenXRRuntime.LogLastError();
                }
            }
            if (!OpenXRInput.Internal_AttachActionSets())
            {
                OpenXRRuntime.LogLastError();
            }
        }

        // Token: 0x060000FF RID: 255 RVA: 0x00004478 File Offset: 0x00002678
        private static bool RegisterDevices(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, bool isAdditive)
        {
            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                foreach (OpenXRInteractionFeature.DeviceConfig deviceInfo in actionMap.deviceInfos)
                {
                    string localizedName = (actionMap.desiredInteractionProfile == null) ? OpenXRInput.UserPathToDeviceName(deviceInfo.userPath) : actionMap.localizedName;
                    if (OpenXRInput.Internal_RegisterDeviceDefinition(deviceInfo.userPath, actionMap.desiredInteractionProfile, isAdditive, (uint)deviceInfo.characteristics, localizedName, actionMap.manufacturer, actionMap.serialNumber) == 0UL)
                    {
                        OpenXRRuntime.LogLastError();
                        return false;
                    }
                }
            }
            return true;
        }

        // Token: 0x06000100 RID: 256 RVA: 0x00004554 File Offset: 0x00002754
        private static bool CreateActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, Dictionary<string, List<OpenXRInput.SerializedBinding>> interactionProfiles)
        {
            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                string actionMapLocalizedName = OpenXRInput.SanitizeStringForOpenXRPath(actionMap.localizedName);
                ulong actionSetId = OpenXRInput.Internal_CreateActionSet(OpenXRInput.SanitizeStringForOpenXRPath(actionMap.name), actionMapLocalizedName, default);
                if (actionSetId == 0UL)
                {
                    OpenXRRuntime.LogLastError();
                    return false;
                }
                List<string> deviceUserPaths = (from d in actionMap.deviceInfos
                                                select d.userPath).ToList<string>();
                foreach (OpenXRInteractionFeature.ActionConfig action in actionMap.actions)
                {
                    string[] allUserPaths = (from b in action.bindings
                                             where b.userPaths != null
                                             select b).SelectMany((OpenXRInteractionFeature.ActionBinding b) => b.userPaths).Distinct<string>().ToList<string>().Union(deviceUserPaths).ToArray<string>();
                    ulong actionSetId2 = actionSetId;
                    string name = OpenXRInput.SanitizeStringForOpenXRPath(action.name);
                    string localizedName = action.localizedName;
                    uint type = (uint)action.type;
                    OpenXRInput.SerializedGuid guid = default;
                    string[] userPaths = allUserPaths;
                    uint userPathCount = (uint)allUserPaths.Length;
                    bool isAdditive = action.isAdditive;
                    List<string> usages = action.usages;
                    string[] usages2 = (usages != null) ? usages.ToArray() : null;
                    List<string> usages3 = action.usages;
                    ulong actionId = OpenXRInput.Internal_CreateAction(actionSetId2, name, localizedName, type, guid, userPaths, userPathCount, isAdditive, usages2, (uint)((usages3 != null) ? usages3.Count : 0));
                    if (actionId == 0UL)
                    {
                        OpenXRRuntime.LogLastError();
                        return false;
                    }
                    foreach (OpenXRInteractionFeature.ActionBinding binding in action.bindings)
                    {
                        foreach (string userPath in (binding.userPaths ?? deviceUserPaths))
                        {
                            string interactionProfile = action.isAdditive ? actionMap.desiredInteractionProfile : (binding.interactionProfileName ?? actionMap.desiredInteractionProfile);
                            List<OpenXRInput.SerializedBinding> bindings;
                            if (!interactionProfiles.TryGetValue(interactionProfile, out bindings))
                            {
                                bindings = new List<OpenXRInput.SerializedBinding>();
                                interactionProfiles[interactionProfile] = bindings;
                            }
                            bindings.Add(new OpenXRInput.SerializedBinding
                            {
                                actionId = actionId,
                                path = userPath + binding.interactionPath
                            });
                        }
                    }
                }
            }
            return true;
        }

        // Token: 0x06000101 RID: 257 RVA: 0x00004854 File Offset: 0x00002A54
        private static void SetDpadBindingCustomValues()
        {
            DPadInteraction dpadFeature = OpenXRSettings.Instance.GetFeature<DPadInteraction>();
            if (dpadFeature != null && dpadFeature.enabled)
            {
                OpenXRInput.Internal_SetDpadBindingCustomValues(true, dpadFeature.forceThresholdLeft, dpadFeature.forceThresholdReleaseLeft, dpadFeature.centerRegionLeft, dpadFeature.wedgeAngleLeft, dpadFeature.isStickyLeft);
                OpenXRInput.Internal_SetDpadBindingCustomValues(false, dpadFeature.forceThresholdRight, dpadFeature.forceThresholdReleaseRight, dpadFeature.centerRegionRight, dpadFeature.wedgeAngleRight, dpadFeature.isStickyRight);
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x000048C5 File Offset: 0x00002AC5
        private static char SanitizeCharForOpenXRPath(char c)
        {
            if (char.IsLower(c) || char.IsDigit(c))
            {
                return c;
            }
            if (char.IsUpper(c))
            {
                return char.ToLower(c);
            }
            if (c == '-' || c == '.' || c == '_' || c == '/')
            {
                return c;
            }
            return '\0';
        }

        // Token: 0x06000103 RID: 259 RVA: 0x00004900 File Offset: 0x00002B00
        private static string SanitizeStringForOpenXRPath(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            int i = 0;
            while (i < input.Length && OpenXRInput.SanitizeCharForOpenXRPath(input[i]) == input[i])
            {
                i++;
            }
            if (i == input.Length)
            {
                return input;
            }
            StringBuilder sb = new(input, 0, i, input.Length);
            while (i < input.Length)
            {
                char c = OpenXRInput.SanitizeCharForOpenXRPath(input[i]);
                if (c != '\0')
                {
                    sb.Append(c);
                }
                i++;
            }
            return sb.ToString();
        }

        // Token: 0x06000104 RID: 260 RVA: 0x00004988 File Offset: 0x00002B88
        private static string GetActionHandleName(InputControl control)
        {
            InputControl inputControl = control;
            while (inputControl.parent != null && inputControl.parent.parent != null)
            {
                inputControl = inputControl.parent;
            }
            string controlName = OpenXRInput.SanitizeStringForOpenXRPath(inputControl.name);
            string virtualControlName;
            if (OpenXRInput.kVirtualControlMap.TryGetValue(controlName, out virtualControlName))
            {
                return virtualControlName;
            }
            return controlName;
        }

        // Token: 0x06000105 RID: 261 RVA: 0x000049D3 File Offset: 0x00002BD3
        public static void SendHapticImpulse(InputActionReference actionRef, float amplitude, float duration, InputSystem.InputDevice inputDevice = default)
        {
            OpenXRInput.SendHapticImpulse(actionRef, amplitude, 0f, duration, inputDevice);
        }

        // Token: 0x06000106 RID: 262 RVA: 0x000049E3 File Offset: 0x00002BE3
        public static void SendHapticImpulse(InputActionReference actionRef, float amplitude, float frequency, float duration, InputSystem.InputDevice inputDevice = default)
        {
            OpenXRInput.SendHapticImpulse(actionRef.action, amplitude, frequency, duration, inputDevice);
        }

        // Token: 0x06000107 RID: 263 RVA: 0x000049F5 File Offset: 0x00002BF5
        public static void SendHapticImpulse(InputAction action, float amplitude, float duration, InputSystem.InputDevice inputDevice = default)
        {
            OpenXRInput.SendHapticImpulse(action, amplitude, 0f, duration, inputDevice);
        }

        // Token: 0x06000108 RID: 264 RVA: 0x00004A08 File Offset: 0x00002C08
        public static void SendHapticImpulse(InputAction action, float amplitude, float frequency, float duration, InputSystem.InputDevice inputDevice = default)
        {
            if (action == null)
            {
                return;
            }
            ulong actionHandle = OpenXRInput.GetActionHandle(action, inputDevice);
            if (actionHandle == 0UL)
            {
                return;
            }
            amplitude = Mathf.Clamp(amplitude, 0f, 1f);
            duration = Mathf.Max(duration, 0f);
            OpenXRInput.Internal_SendHapticImpulse(OpenXRInput.GetDeviceId(inputDevice), actionHandle, amplitude, frequency, duration);
        }

        // Token: 0x06000109 RID: 265 RVA: 0x00004A55 File Offset: 0x00002C55
        public static void StopHaptics(InputActionReference actionRef, InputSystem.InputDevice inputDevice = default)
        {
            if (actionRef == null)
            {
                return;
            }
            OpenXRInput.StopHaptics(actionRef.action, inputDevice);
        }

        // Token: 0x0600010A RID: 266 RVA: 0x00004A6D File Offset: 0x00002C6D
        public static void SendHapticImpulse(InputSystem.InputDevice device, float amplitude, float frequency, float duration)
        {
            if (!device.IsValid())
            {
                return;
            }
            OpenXRInput.Internal_SendHapticImpulseNoISX(OpenXRInput.GetDeviceId(device), amplitude, frequency, duration);
        }

        // Token: 0x0600010B RID: 267 RVA: 0x00004A87 File Offset: 0x00002C87
        public static void StopHapticImpulse(InputSystem.InputDevice device)
        {
            if (!device.IsValid())
            {
                return;
            }
            OpenXRInput.Internal_StopHapticsNoISX(OpenXRInput.GetDeviceId(device));
        }

        // Token: 0x0600010C RID: 268 RVA: 0x00004AA0 File Offset: 0x00002CA0
        public static void StopHaptics(InputAction inputAction, InputSystem.InputDevice inputDevice = default)
        {
            if (inputAction == null)
            {
                return;
            }
            ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, inputDevice);
            if (actionHandle == 0UL)
            {
                return;
            }
            OpenXRInput.Internal_StopHaptics(OpenXRInput.GetDeviceId(inputDevice), actionHandle);
        }

        // Token: 0x0600010D RID: 269 RVA: 0x00004ACC File Offset: 0x00002CCC
        public static bool TryGetInputSourceName(InputAction inputAction, int index, out string name, OpenXRInput.InputSourceNameFlags flags = OpenXRInput.InputSourceNameFlags.All, InputSystem.InputDevice inputDevice = default)
        {
            name = "";
            if (index < 0)
            {
                return false;
            }
            ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, inputDevice);
            return actionHandle != 0UL && OpenXRInput.Internal_TryGetInputSourceName(OpenXRInput.GetDeviceId(inputDevice), actionHandle, (uint)index, (uint)flags, out name);
        }

        // Token: 0x0600010E RID: 270 RVA: 0x00004B04 File Offset: 0x00002D04
        public static bool GetActionIsActive(InputAction inputAction)
        {
            if (inputAction != null && inputAction.controls.Count > 0 && inputAction.controls[0].device != null)
            {
                for (int index = 0; index < inputAction.controls.Count; index++)
                {
                    uint deviceId = OpenXRInput.GetDeviceId(inputAction.controls[index].device);
                    if (deviceId != 0U)
                    {
                        string controlName = OpenXRInput.GetActionHandleName(inputAction.controls[index]);
                        if (OpenXRInput.Internal_GetActionIsActive(deviceId, controlName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Token: 0x0600010F RID: 271 RVA: 0x00004B92 File Offset: 0x00002D92
        public static bool GetActionIsActive(InputSystem.InputDevice device, InputFeatureUsage usage)
        {
            return OpenXRInput.GetActionIsActive(device, usage.name);
        }

        // Token: 0x06000110 RID: 272 RVA: 0x00004BA4 File Offset: 0x00002DA4
        public static bool GetActionIsActive(InputSystem.InputDevice device, string usageName)
        {
            uint deviceId = OpenXRInput.GetDeviceId(device);
            return deviceId != 0U && OpenXRInput.Internal_GetActionIsActiveNoISX(deviceId, usageName);
        }

        // Token: 0x06000111 RID: 273 RVA: 0x00004BC4 File Offset: 0x00002DC4
        public static bool TrySetControllerLateLatchAction(InputAction inputAction)
        {
            if (inputAction == null || inputAction.controls.Count != 1)
            {
                return false;
            }
            if (inputAction.controls[0].device == null)
            {
                return false;
            }
            uint deviceId = OpenXRInput.GetDeviceId(inputAction.controls[0].device);
            if (deviceId == 0U)
            {
                return false;
            }
            ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, default);
            return actionHandle != 0UL && OpenXRInput.Internal_TrySetControllerLateLatchAction(deviceId, actionHandle);
        }

        // Token: 0x06000112 RID: 274 RVA: 0x00004C32 File Offset: 0x00002E32
        public static bool TrySetControllerLateLatchAction(InputSystem.InputDevice device, InputFeatureUsage usage)
        {
            return OpenXRInput.TrySetControllerLateLatchAction(device, usage.name);
        }

        // Token: 0x06000113 RID: 275 RVA: 0x00004C44 File Offset: 0x00002E44
        public static bool TrySetControllerLateLatchAction(InputSystem.InputDevice device, string usageName)
        {
            uint deviceId = OpenXRInput.GetDeviceId(device);
            if (deviceId == 0U)
            {
                return false;
            }
            ulong actionHandle = OpenXRInput.GetActionHandle(device, usageName);
            return actionHandle != 0UL && OpenXRInput.Internal_TrySetControllerLateLatchAction(deviceId, actionHandle);
        }

        // Token: 0x06000114 RID: 276 RVA: 0x00004C71 File Offset: 0x00002E71
        public static ulong GetActionHandle(InputSystem.InputDevice device, InputFeatureUsage usage)
        {
            return OpenXRInput.GetActionHandle(device, usage.name);
        }

        // Token: 0x06000115 RID: 277 RVA: 0x00004C80 File Offset: 0x00002E80
        public static ulong GetActionHandle(InputSystem.InputDevice device, string usageName)
        {
            uint deviceId = OpenXRInput.GetDeviceId(device);
            if (deviceId == 0U)
            {
                return 0UL;
            }
            return OpenXRInput.Internal_GetActionIdNoISX(deviceId, usageName);
        }

        // Token: 0x06000116 RID: 278 RVA: 0x00004CA4 File Offset: 0x00002EA4
        public static ulong GetActionHandle(InputAction inputAction, InputSystem.InputDevice inputDevice = default)
        {
            if (inputAction == null || inputAction.controls.Count == 0)
            {
                return 0UL;
            }
            foreach (InputControl control in inputAction.controls)
            {
                if ((inputDevice == null || control.device == inputDevice) && control.device != null)
                {
                    uint deviceId = OpenXRInput.GetDeviceId(control.device);
                    if (deviceId != 0U)
                    {
                        string controlName = OpenXRInput.GetActionHandleName(control);
                        ulong xrAction = OpenXRInput.Internal_GetActionId(deviceId, controlName);
                        if (xrAction != 0UL)
                        {
                            return xrAction;
                        }
                    }
                }
            }
            return 0UL;
        }

        // Token: 0x06000117 RID: 279 RVA: 0x00004D50 File Offset: 0x00002F50
        private static uint GetDeviceId(InputSystem.InputDevice inputDevice)
        {
            if (inputDevice == null)
            {
                return 0U;
            }
            //return (uint)inputDevice.deviceId;
            //foreach (var dev in InputSystem.InputSystem.s_Manager.devices)
            //{
            //    if (dev.name == inputDevice.name)
            //    {
            //        return (uint)dev.deviceId;
            //    }
            //}
            //todo
            OpenXRInput.GetInternalDeviceIdCommand command = OpenXRInput.GetInternalDeviceIdCommand.Create();
            //if (inputDevice.ExecuteCommand<OpenXRInput.GetInternalDeviceIdCommand>(ref command) != 0L)
            unsafe
            {
                InputDeviceCommand* ptr = (InputDeviceCommand*)&command;
                if (inputDevice.ExecuteCommand(ptr) != 0L)
                {
                    return command.deviceId;
                }
            }
            return 0U;
        }

        // Token: 0x06000118 RID: 280 RVA: 0x00004D7A File Offset: 0x00002F7A
        //private static uint GetDeviceId(InputDevice inputDevice)
        //{
        //	return OpenXRInput.Internal_GetDeviceId(inputDevice.characteristics, inputDevice.name);
        //}

        // Token: 0x06000119 RID: 281 RVA: 0x00004D90 File Offset: 0x00002F90
        private static string UserPathToDeviceName(string userPath)
        {
            string[] array = userPath.Split(new char[]
            {
                '/',
                '_'
            });
            StringBuilder nameBuilder = new("OXR");
            foreach (string part in array)
            {
                if (part.Length != 0)
                {
                    string sanitizedPart = OpenXRInput.SanitizeStringForOpenXRPath(part);
                    nameBuilder.Append(char.ToUpper(sanitizedPart[0]));
                    nameBuilder.Append(sanitizedPart.Substring(1));
                }
            }
            return nameBuilder.ToString();
        }

        // Token: 0x0600011A RID: 282
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SetDpadBindingCustomValues")]
        private static extern void Internal_SetDpadBindingCustomValues([MarshalAs(UnmanagedType.I1)] bool isLeft, float forceThreshold, float forceThresholdReleased, float centerRegion, float wedgeAngle, [MarshalAs(UnmanagedType.I1)] bool isSticky);

        // Token: 0x0600011B RID: 283
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SendHapticImpulse")]
        private static extern void Internal_SendHapticImpulse(uint deviceId, ulong actionId, float amplitude, float frequency, float duration);

        // Token: 0x0600011C RID: 284
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SendHapticImpulseNoISX")]
        private static extern void Internal_SendHapticImpulseNoISX(uint deviceId, float amplitude, float frequency, float duration);

        // Token: 0x0600011D RID: 285
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_StopHaptics")]
        private static extern void Internal_StopHaptics(uint deviceId, ulong actionId);

        // Token: 0x0600011E RID: 286
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_StopHapticsNoISX")]
        private static extern void Internal_StopHapticsNoISX(uint deviceId);

        // Token: 0x0600011F RID: 287
        [DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetActionIdByControl")]
        private static extern ulong Internal_GetActionId(uint deviceId, string name);

        // Token: 0x06000120 RID: 288
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetActionIdByUsageName")]
        private static extern ulong Internal_GetActionIdNoISX(uint deviceId, string usageName);

        // Token: 0x06000121 RID: 289
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_TryGetInputSourceName")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Internal_TryGetInputSourceNamePtr(uint deviceId, ulong actionId, uint index, uint flags, out IntPtr outName);

        // Token: 0x06000122 RID: 290 RVA: 0x00004E0C File Offset: 0x0000300C
        internal static bool Internal_TryGetInputSourceName(uint deviceId, ulong actionId, uint index, uint flags, out string outName)
        {
            IntPtr outNamePtr;
            if (!OpenXRInput.Internal_TryGetInputSourceNamePtr(deviceId, actionId, index, flags, out outNamePtr))
            {
                outName = "";
                return false;
            }
            outName = Marshal.PtrToStringAnsi(outNamePtr);
            return true;
        }

        // Token: 0x06000123 RID: 291
        [DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_TrySetControllerLateLatchAction")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Internal_TrySetControllerLateLatchAction(uint deviceId, ulong actionId);

        // Token: 0x06000124 RID: 292
        [DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetActionIsActive")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Internal_GetActionIsActive(uint deviceId, string name);

        // Token: 0x06000125 RID: 293
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetActionIsActiveNoISX")]
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Internal_GetActionIsActiveNoISX(uint deviceId, string name);

        // Token: 0x06000126 RID: 294
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_RegisterDeviceDefinition")]
        private static extern ulong Internal_RegisterDeviceDefinition(string userPath, string interactionProfile, [MarshalAs(UnmanagedType.I1)] bool isAdditive, uint characteristics, string name, string manufacturer, string serialNumber);

        // Token: 0x06000127 RID: 295
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_CreateActionSet")]
        private static extern ulong Internal_CreateActionSet(string name, string localizedName, OpenXRInput.SerializedGuid guid);

        // Token: 0x06000128 RID: 296
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_CreateAction")]
        private static extern ulong Internal_CreateAction(ulong actionSetId, string name, string localizedName, uint actionType, OpenXRInput.SerializedGuid guid, string[] userPaths, uint userPathCount, [MarshalAs(UnmanagedType.I1)] bool isAdditive, string[] usages, uint usageCount);

        // Token: 0x06000129 RID: 297
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_SuggestBindings")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_SuggestBindings(string interactionProfile, OpenXRInput.SerializedBinding[] serializedBindings, uint serializedBindingCount);

        // Token: 0x0600012A RID: 298
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_AttachActionSets")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool Internal_AttachActionSets();

        // Token: 0x0600012B RID: 299
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetDeviceId")]
        private static extern uint Internal_GetDeviceId(InputDeviceCharacteristics characteristics, string name);

        // Token: 0x0600012C RID: 300 RVA: 0x00004E3C File Offset: 0x0000303C
        // Note: this type is marked as 'beforefieldinit'.
        static OpenXRInput()
        {
            Dictionary<string, OpenXRInteractionFeature.ActionType> dictionary = new();
            dictionary["Digital"] = OpenXRInteractionFeature.ActionType.Binary;
            dictionary["Button"] = OpenXRInteractionFeature.ActionType.Binary;
            dictionary["Axis"] = OpenXRInteractionFeature.ActionType.Axis1D;
            dictionary["Integer"] = OpenXRInteractionFeature.ActionType.Axis1D;
            dictionary["Analog"] = OpenXRInteractionFeature.ActionType.Axis1D;
            dictionary["Vector2"] = OpenXRInteractionFeature.ActionType.Axis2D;
            dictionary["Dpad"] = OpenXRInteractionFeature.ActionType.Axis2D;
            dictionary["Stick"] = OpenXRInteractionFeature.ActionType.Axis2D;
            dictionary["Pose"] = OpenXRInteractionFeature.ActionType.Pose;
            dictionary["Vector3"] = OpenXRInteractionFeature.ActionType.Pose;
            dictionary["Quaternion"] = OpenXRInteractionFeature.ActionType.Pose;
            dictionary["Haptic"] = OpenXRInteractionFeature.ActionType.Vibrate;
            OpenXRInput.ExpectedControlTypeToActionType = dictionary;
            Dictionary<string, string> dictionary2 = new();
            dictionary2["deviceposition"] = "devicepose";
            dictionary2["devicerotation"] = "devicepose";
            dictionary2["trackingstate"] = "devicepose";
            dictionary2["istracked"] = "devicepose";
            dictionary2["pointerposition"] = "pointer";
            dictionary2["pointerrotation"] = "pointer";
            OpenXRInput.kVirtualControlMap = dictionary2;
        }

        // Token: 0x04000177 RID: 375
        private static readonly Dictionary<string, OpenXRInteractionFeature.ActionType> ExpectedControlTypeToActionType;

        // Token: 0x04000178 RID: 376
        private const string s_devicePoseActionName = "devicepose";

        // Token: 0x04000179 RID: 377
        private const string s_pointerActionName = "pointer";

        // Token: 0x0400017A RID: 378
        private static readonly Dictionary<string, string> kVirtualControlMap;

        // Token: 0x0400017B RID: 379
        private const string Library = "UnityOpenXR";

        // Token: 0x0200003B RID: 59
        [StructLayout(LayoutKind.Explicit)]
        private struct SerializedGuid
        {
            // Token: 0x0400017C RID: 380
            [FieldOffset(0)]
            public Guid guid;

            // Token: 0x0400017D RID: 381
            [FieldOffset(0)]
            public ulong ulong1;

            // Token: 0x0400017E RID: 382
            [FieldOffset(8)]
            public ulong ulong2;
        }

        // Token: 0x0200003C RID: 60
        internal struct SerializedBinding
        {
            // Token: 0x0400017F RID: 383
            public ulong actionId;

            // Token: 0x04000180 RID: 384
            public string path;
        }

        // Token: 0x0200003D RID: 61
        [Flags]
        public enum InputSourceNameFlags
        {
            // Token: 0x04000182 RID: 386
            UserPath = 1,
            // Token: 0x04000183 RID: 387
            InteractionProfile = 2,
            // Token: 0x04000184 RID: 388
            Component = 4,
            // Token: 0x04000185 RID: 389
            All = 7
        }

        // Token: 0x0200003E RID: 62
        [StructLayout(LayoutKind.Explicit, Size = 12)]
        private struct GetInternalDeviceIdCommand : IInputDeviceCommandInfo
        {
            // Token: 0x17000029 RID: 41
            // (get) Token: 0x0600012D RID: 301 RVA: 0x00004F4D File Offset: 0x0000314D
            private static FourCC Type
            {
                get
                {
                    return new FourCC('X', 'R', 'D', 'I');
                }
            }

            // Token: 0x1700002A RID: 42
            // (get) Token: 0x0600012E RID: 302 RVA: 0x00004F5C File Offset: 0x0000315C
            public FourCC typeStatic
            {
                get
                {
                    return OpenXRInput.GetInternalDeviceIdCommand.Type;
                }
            }

            // Token: 0x0600012F RID: 303 RVA: 0x00004F64 File Offset: 0x00003164
            public static OpenXRInput.GetInternalDeviceIdCommand Create()
            {
                return new OpenXRInput.GetInternalDeviceIdCommand
                {
                    baseCommand = new InputDeviceCommand(OpenXRInput.GetInternalDeviceIdCommand.Type, 12)
                };
            }

            // Token: 0x04000186 RID: 390
            private const int k_BaseCommandSizeSize = 8;

            // Token: 0x04000187 RID: 391
            private const int k_Size = 12;

            // Token: 0x04000188 RID: 392
            [FieldOffset(0)]
            private InputDeviceCommand baseCommand;

            // Token: 0x04000189 RID: 393
            [FieldOffset(8)]
            public readonly uint deviceId;
        }
    }
}
