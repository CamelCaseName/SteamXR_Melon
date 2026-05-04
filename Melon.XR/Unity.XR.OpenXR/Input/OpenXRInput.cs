using MelonLoader;
using Silk.NET.OpenXR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.XR.OpenXR.Features;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace UnityEngine.XR.OpenXR.Input
{
    // Token: 0x0200003A RID: 58
    public static class OpenXRInput
    {
        private static readonly Dictionary<OpenXRInteractionFeature.ActionMapConfig, List<ulong>> actionSetIds = new();
        private static readonly Dictionary<OpenXRInteractionFeature.ActionConfig, List<ulong>> actionIds = new();
        public static readonly Dictionary<string, List<ulong>> namedActionIds = new();
        private static readonly Dictionary<ulong, List<OpenXRInteractionFeature.ActionBinding>> actionBindings = new();
        private static readonly List<OpenXRInteractionFeature.ActionMapConfig> actionMaps = new();
        private static readonly Dictionary<string, List<SerializedBinding>> interactionProfiles = new();
        private static readonly Dictionary<string, string> inputMap = new();
        private static Silk.NET.OpenXR.XR xr = null;
        private static Session session = default;

        //map between action name like Pee and unity openxr control name like "primaryButton"
        public static void AddInputMapping(Dictionary<string, string> inputmap)
        {
            foreach (var item in inputmap)
            {
                if (inputMap.TryAdd(item.Key, item.Value))
                {
                    MelonLogger.Msg($"[HPVR Input] added {item.Key} - {item.Value} to input map");
                }
                else
                {
                    MelonLogger.Msg($"[HPVR Input] could not add {item.Key} - {item.Value} to input map, duplicate");
                }
            }
        }

        public static bool GetBoolean(string actionName)
        {
            //MelonLogger.Msg("[HPVR Input] polling bool for " + actionName);
            if (inputMap.TryGetValue(actionName, out var openxrName))
            {
                MelonLogger.Msg("[HPVR Input] got mapped " + openxrName + " for " + actionName);
                if (namedActionIds.TryGetValue(openxrName.ToLower(), out var actionIds))
                {
                    ActionStateGetInfo info = new();
                    ActionStateBoolean state = new();
                    foreach (var action in actionIds)
                    {
                        MelonLogger.Msg($"[HPVR Input] action id: 0x{action:x}");
                        info.Action = new(action);
                        //poll here and return if good
                        var res = xr.GetActionStateBoolean(session, ref info, ref state);
                        if (res != Result.Success)
                        {
                            OpenXRRuntime.LogLastError();
                        }
                        if (state.IsActive > 0 && state.CurrentState == 1)
                        {
                            MelonLogger.Msg("[HPVR Input] was active");
                            return true;
                        }
                    }
                    MelonLogger.Msg("[HPVR Input] not active");
                }
                else
                {
                    MelonLogger.Msg("[HPVR Input] couldnt find any id for action: " + openxrName);
                }
            }
            else
            {
                MelonLogger.Msg("[HPVR Input] couldnt find any mapped input for " + actionName);
            }
            return false;
        }

        public static float GetFloat(string actionName)
        {


            return 0;
        }

        public static Vector2 GetVector2D(string actionName)
        {


            return Vector2.zeroVector;
        }

        public static Posef GetPose(string actionName)
        {


            return default;
        }

        // Token: 0x060000FC RID: 252 RVA: 0x000041BC File Offset: 0x000023BC
        public static void RegisterLayouts()
        {
            //MelonLogger.Msg("Registering haptic control layout");
            //InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<HapticControl>(), "Haptic", new Il2CppSystem.Nullable<InputDeviceMatcher>());
            ////InputSystem.InputSystem.RegisterLayout
            //MelonLogger.Msg("Registering openxrdevice control layout");
            //InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<OpenXRDevice>(), "OpenXRDevice", new Il2CppSystem.Nullable<InputDeviceMatcher>());

            //InputDeviceMatcher inputDeviceMatcher = new();
            //inputDeviceMatcher = inputDeviceMatcher.WithInterface("^(XRInput)", true);
            //inputDeviceMatcher = inputDeviceMatcher.WithProduct("Head Tracking - OpenXR", true);
            //inputDeviceMatcher = inputDeviceMatcher.WithManufacturer("OpenXR", true);

            //MelonLogger.Msg("Registering openxrhmd control layout");
            //InputSystem.InputSystem.RegisterLayout(Il2CppType.Of<OpenXRHmd>(), "OpenXRHmd", new Il2CppSystem.Nullable<InputDeviceMatcher>(inputDeviceMatcher));
            OpenXRInteractionFeature.RegisterLayouts();
        }

        // Token: 0x060000FD RID: 253 RVA: 0x0000422C File Offset: 0x0000242C
        public static bool ValidateActionMapConfig(OpenXRInteractionFeature interactionFeature, OpenXRInteractionFeature.ActionMapConfig actionMapConfig)
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
        public static void AttachActionSets()
        {
            MelonLogger.Msg("[HPVR Input] Attaching action sets");
            List<OpenXRInteractionFeature.ActionMapConfig> additiveActionMaps = new();
            foreach (OpenXRInteractionFeature interactionFeature in from f in OpenXRSettings.Instance.features.OfType<OpenXRInteractionFeature>()
                                                                    where f.enabled && !f.IsAdditive
                                                                    select f)
            {
                MelonLogger.Msg("registering feature for:" + interactionFeature.GetType().Name);
                int start = actionMaps.Count;
                interactionFeature.CreateActionMaps(actionMaps);
                for (int index = actionMaps.Count - 1; index >= start; index--)
                {
                    if (!ValidateActionMapConfig(interactionFeature, actionMaps[index]))
                    {
                        actionMaps.RemoveAt(index);
                    }
                }
            }
            //todo check if we need this
            if (!OpenXRInput.RegisterDevices(actionMaps, false))
            {
                MelonLogger.Msg("[HPVR Input] Could not register devices");
                return;
            }
            foreach (OpenXRInteractionFeature openXRInteractionFeature in from f in OpenXRSettings.Instance.features.OfType<OpenXRInteractionFeature>()
                                                                          where f.enabled && f.IsAdditive
                                                                          select f)
            {
                MelonLogger.Msg("registering additive feature for:" + openXRInteractionFeature.GetType().Name);
                openXRInteractionFeature.CreateActionMaps(additiveActionMaps);
                openXRInteractionFeature.AddAdditiveActions(actionMaps, additiveActionMaps[^1]);
            }
            if (!CreateActions(actionMaps, interactionProfiles))
            {
                MelonLogger.Msg("[HPVR Input] Could not create actions");
                return;
            }
            if (additiveActionMaps.Count > 0)
            {
                //OpenXRInput.RegisterDevices(additiveActionMaps, true);
                CreateActions(additiveActionMaps, interactionProfiles);
            }
            SetDpadBindingCustomValues();
            foreach (KeyValuePair<string, List<SerializedBinding>> profile in interactionProfiles)
            {
                if (!InternalSuggestBindings(profile.Key, profile.Value.ToArray(), (uint)profile.Value.Count))
                {
                    OpenXRRuntime.LogLastError();
                }
            }
            if (!InternalAttachActionSets())
            {
                OpenXRRuntime.LogLastError();
            }
        }

        // Token: 0x060000FF RID: 255 RVA: 0x00004478 File Offset: 0x00002678
        public static bool RegisterDevices(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, bool isAdditive)
        {
            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                foreach (OpenXRInteractionFeature.DeviceConfig deviceInfo in actionMap.deviceInfos)
                {
                    string localizedName = (actionMap.desiredInteractionProfile == null) ? OpenXRInput.UserPathToDeviceName(deviceInfo.userPath) : actionMap.localizedName;
                    if (OpenXRInput.InternalRegisterDeviceDefinition(deviceInfo.userPath, actionMap.desiredInteractionProfile, isAdditive, (uint)deviceInfo.characteristics, localizedName, actionMap.manufacturer, actionMap.serialNumber) == 0UL)
                    {
                        OpenXRRuntime.LogLastError();
                        return false;
                    }
                }
            }
            return true;
        }

        // Token: 0x06000100 RID: 256 RVA: 0x00004554 File Offset: 0x00002754
        public static unsafe bool CreateActions(List<OpenXRInteractionFeature.ActionMapConfig> actionMaps, Dictionary<string, List<SerializedBinding>> interactionProfiles)
        {
            xr ??= Silk.NET.OpenXR.XR.GetApi();

            if (session.Handle == 0)
            {
                unsafe
                {
                    ulong ses = 0;
                    InternalGetXRsession(&ses);
                    if (ses == 0)
                    {
                        OpenXRRuntime.LogLastError();
                    }
                    MelonLogger.Msg($"[HPVR Input] got session at 0x{ses:x}");
                    session = new(ses);
                    MelonLogger.Msg($"[HPVR Input] session obj: {session}");
                }
            }

            foreach (OpenXRInteractionFeature.ActionMapConfig actionMap in actionMaps)
            {
                string actionMapLocalizedName = SanitizeStringForOpenXRPath(actionMap.localizedName);
                ulong actionSetId = InternalCreateActionSet(SanitizeStringForOpenXRPath(actionMap.name), actionMapLocalizedName, default);
                if (actionSetId == 0UL)
                {
                    OpenXRRuntime.LogLastError();
                    return false;
                }
                MelonLogger.Msg($"[HPVR Input] registering action map for openxr - name: {actionMap.name}");

                if (actionSetIds.TryGetValue(actionMap, out var idList))
                {
                    idList.Add(actionSetId);
                }
                else
                {
                    actionSetIds.Add(actionMap, new() { actionSetId });
                }

                List<string> deviceUserPaths = (from d in actionMap.deviceInfos
                                                select d.userPath).ToList();
                foreach (OpenXRInteractionFeature.ActionConfig action in actionMap.actions)
                {
                    string[] allUserPaths = (from b in action.bindings
                                             where b.userPaths != null
                                             select b).SelectMany((OpenXRInteractionFeature.ActionBinding b) => b.userPaths).Distinct().ToList().Union(deviceUserPaths).ToArray();
                    ulong actionSetId2 = actionSetId;
                    string name = SanitizeStringForOpenXRPath(action.name);
                    string localizedName = action.localizedName;
                    uint type = (uint)action.type;
                    SerializedGuid guid = new() { guid = Guid.NewGuid() };
                    string[] userPaths = allUserPaths;
                    uint userPathCount = (uint)allUserPaths.Length;
                    bool isAdditive = action.isAdditive;
                    List<string> usages = action.usages;
                    string[] usages2 = usages?.ToArray();
                    List<string> usages3 = action.usages;
                    ulong result = InternalCreateAction(actionSetId2, name, localizedName, type, guid, userPaths, userPathCount, isAdditive, usages2, (uint)((usages3 != null) ? usages3.Count : 0));
                    if (result == 0UL)
                    {
                        MelonLogger.Error($"could not create {name} [type = {type}]");
                        OpenXRRuntime.LogLastError();
                        return false;
                    }
                    ulong actionId = result + 0x18f;
                    //ulong actionId = InternalGetActionIdByGUID(&guid);
                    //if (actionId == 0UL)
                    //{
                    //    MelonLogger.Error($"could not get id for {name} [type = {type}]");
                    //    OpenXRRuntime.LogLastError();
                    //    return false;
                    //}
                    MelonLogger.Msg($"Got id 0x{actionId:x} for {name} [type = {type}]");
                    if (actionIds.TryGetValue(action, out var actionidList))
                    {
                        actionidList.Add(actionId);
                    }
                    else
                    {
                        actionIds.Add(action, new() { actionId });
                    }
                    if (namedActionIds.TryGetValue(action.name.ToLower(), out var list))
                    {
                        list.Add(actionId);
                    }
                    else
                    {
                        namedActionIds.Add(action.name.ToLower(), new() { actionId });
                    }
                    actionBindings.Add(actionId, new());
                    foreach (OpenXRInteractionFeature.ActionBinding binding in action.bindings)
                    {
                        foreach (string userPath in (binding.userPaths ?? deviceUserPaths))
                        {
                            string interactionProfile = action.isAdditive ? actionMap.desiredInteractionProfile : (binding.interactionProfileName ?? actionMap.desiredInteractionProfile);
                            List<SerializedBinding> bindings;
                            if (!interactionProfiles.TryGetValue(interactionProfile, out bindings))
                            {
                                bindings = new List<SerializedBinding>();
                                interactionProfiles[interactionProfile] = bindings;
                            }
                            actionBindings[actionId].Add(binding);
                            bindings.Add(new SerializedBinding
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
        public static void SetDpadBindingCustomValues()
        {
            DPadInteraction dpadFeature = OpenXRSettings.Instance.GetFeature<DPadInteraction>();
            if (dpadFeature != null && dpadFeature.enabled)
            {
                InternalSetDpadBindingCustomValues(true, dpadFeature.forceThresholdLeft, dpadFeature.forceThresholdReleaseLeft, dpadFeature.centerRegionLeft, dpadFeature.wedgeAngleLeft, dpadFeature.isStickyLeft);
                InternalSetDpadBindingCustomValues(false, dpadFeature.forceThresholdRight, dpadFeature.forceThresholdReleaseRight, dpadFeature.centerRegionRight, dpadFeature.wedgeAngleRight, dpadFeature.isStickyRight);
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x000048C5 File Offset: 0x00002AC5
        public static char SanitizeCharForOpenXRPath(char c)
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
        public static string SanitizeStringForOpenXRPath(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            int i = 0;
            while (i < input.Length && SanitizeCharForOpenXRPath(input[i]) == input[i])
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
                char c = SanitizeCharForOpenXRPath(input[i]);
                if (c != '\0')
                {
                    sb.Append(c);
                }
                i++;
            }
            return sb.ToString();
        }

        // Token: 0x06000104 RID: 260 RVA: 0x00004988 File Offset: 0x00002B88
        //public static string GetActionHandleName(InputControl control)
        //{
        //    InputControl inputControl = control;
        //    while (inputControl.parent != null && inputControl.parent.parent != null)
        //    {
        //        inputControl = inputControl.parent;
        //    }
        //    string controlName = OpenXRInput.SanitizeStringForOpenXRPath(inputControl.name);
        //    string virtualControlName;
        //    if (OpenXRInput.kVirtualControlMap.TryGetValue(controlName, out virtualControlName))
        //    {
        //        return virtualControlName;
        //    }
        //    return controlName;
        //}

        // Token: 0x06000105 RID: 261 RVA: 0x000049D3 File Offset: 0x00002BD3
        //public static void SendHapticImpulse(InputActionReference actionRef, float amplitude, float duration, InputSystem.InputDevice inputDevice = default)
        //{
        //    OpenXRInput.SendHapticImpulse(actionRef, amplitude, 0f, duration, inputDevice);
        //}

        //// Token: 0x06000106 RID: 262 RVA: 0x000049E3 File Offset: 0x00002BE3
        //public static void SendHapticImpulse(InputActionReference actionRef, float amplitude, float frequency, float duration, InputSystem.InputDevice inputDevice = default)
        //{
        //    OpenXRInput.SendHapticImpulse(actionRef.action, amplitude, frequency, duration, inputDevice);
        //}

        //// Token: 0x06000107 RID: 263 RVA: 0x000049F5 File Offset: 0x00002BF5
        //public static void SendHapticImpulse(InputAction action, float amplitude, float duration, InputSystem.InputDevice inputDevice = default)
        //{
        //    OpenXRInput.SendHapticImpulse(action, amplitude, 0f, duration, inputDevice);
        //}

        //// Token: 0x06000108 RID: 264 RVA: 0x00004A08 File Offset: 0x00002C08
        //public static void SendHapticImpulse(InputAction action, float amplitude, float frequency, float duration, InputSystem.InputDevice inputDevice = default)
        //{
        //    if (action == null)
        //    {
        //        return;
        //    }
        //    ulong actionHandle = OpenXRInput.GetActionHandle(action, inputDevice);
        //    if (actionHandle == 0UL)
        //    {
        //        return;
        //    }
        //    amplitude = Mathf.Clamp(amplitude, 0f, 1f);
        //    duration = Mathf.Max(duration, 0f);
        //    OpenXRInput.InternalSendHapticImpulse(OpenXRInput.GetDeviceId(inputDevice), actionHandle, amplitude, frequency, duration);
        //}

        //// Token: 0x06000109 RID: 265 RVA: 0x00004A55 File Offset: 0x00002C55
        //public static void StopHaptics(InputActionReference actionRef, InputSystem.InputDevice inputDevice = default)
        //{
        //    if (actionRef == null)
        //    {
        //        return;
        //    }
        //    OpenXRInput.StopHaptics(actionRef.action, inputDevice);
        //}

        //// Token: 0x0600010A RID: 266 RVA: 0x00004A6D File Offset: 0x00002C6D
        //public static void SendHapticImpulse(InputSystem.InputDevice device, float amplitude, float frequency, float duration)
        //{
        //    if (!device.IsValid())
        //    {
        //        return;
        //    }
        //    OpenXRInput.InternalSendHapticImpulseNoISX(OpenXRInput.GetDeviceId(device), amplitude, frequency, duration);
        //}

        //// Token: 0x0600010B RID: 267 RVA: 0x00004A87 File Offset: 0x00002C87
        //public static void StopHapticImpulse(InputSystem.InputDevice device)
        //{
        //    if (!device.IsValid())
        //    {
        //        return;
        //    }
        //    OpenXRInput.InternalStopHapticsNoISX(OpenXRInput.GetDeviceId(device));
        //}

        //// Token: 0x0600010C RID: 268 RVA: 0x00004AA0 File Offset: 0x00002CA0
        //public static void StopHaptics(InputAction inputAction, InputSystem.InputDevice inputDevice = default)
        //{
        //    if (inputAction == null)
        //    {
        //        return;
        //    }
        //    ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, inputDevice);
        //    if (actionHandle == 0UL)
        //    {
        //        return;
        //    }
        //    OpenXRInput.InternalStopHaptics(OpenXRInput.GetDeviceId(inputDevice), actionHandle);
        //}

        //// Token: 0x0600010D RID: 269 RVA: 0x00004ACC File Offset: 0x00002CCC
        //public static bool TryGetInputSourceName(InputAction inputAction, int index, out string name, OpenXRInput.InputSourceNameFlags flags = OpenXRInput.InputSourceNameFlags.All, InputSystem.InputDevice inputDevice = default)
        //{
        //    name = "";
        //    if (index < 0)
        //    {
        //        return false;
        //    }
        //    ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, inputDevice);
        //    return actionHandle != 0UL && OpenXRInput.InternalTryGetInputSourceName(OpenXRInput.GetDeviceId(inputDevice), actionHandle, (uint)index, (uint)flags, out name);
        //}

        //// Token: 0x0600010E RID: 270 RVA: 0x00004B04 File Offset: 0x00002D04
        //public static bool GetActionIsActive(InputAction inputAction)
        //{
        //    if (inputAction != null && inputAction.controls.Count > 0 && inputAction.controls[0].device != null)
        //    {
        //        for (int index = 0; index < inputAction.controls.Count; index++)
        //        {
        //            uint deviceId = OpenXRInput.GetDeviceId(inputAction.controls[index].device);
        //            if (deviceId != 0U)
        //            {
        //                string controlName = OpenXRInput.GetActionHandleName(inputAction.controls[index]);
        //                if (OpenXRInput.InternalGetActionIsActive(deviceId, controlName))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        //// Token: 0x0600010F RID: 271 RVA: 0x00004B92 File Offset: 0x00002D92
        //public static bool GetActionIsActive(InputSystem.InputDevice device, InputFeatureUsage usage)
        //{
        //    return OpenXRInput.GetActionIsActive(device, usage.name);
        //}

        //// Token: 0x06000110 RID: 272 RVA: 0x00004BA4 File Offset: 0x00002DA4
        //public static bool GetActionIsActive(InputSystem.InputDevice device, string usageName)
        //{
        //    uint deviceId = OpenXRInput.GetDeviceId(device);
        //    return deviceId != 0U && OpenXRInput.InternalGetActionIsActiveNoISX(deviceId, usageName);
        //}

        //// Token: 0x06000111 RID: 273 RVA: 0x00004BC4 File Offset: 0x00002DC4
        //public static bool TrySetControllerLateLatchAction(InputAction inputAction)
        //{
        //    if (inputAction == null || inputAction.controls.Count != 1)
        //    {
        //        return false;
        //    }
        //    if (inputAction.controls[0].device == null)
        //    {
        //        return false;
        //    }
        //    uint deviceId = OpenXRInput.GetDeviceId(inputAction.controls[0].device);
        //    if (deviceId == 0U)
        //    {
        //        return false;
        //    }
        //    ulong actionHandle = OpenXRInput.GetActionHandle(inputAction, default);
        //    return actionHandle != 0UL && OpenXRInput.InternalTrySetControllerLateLatchAction(deviceId, actionHandle);
        //}

        //// Token: 0x06000112 RID: 274 RVA: 0x00004C32 File Offset: 0x00002E32
        //public static bool TrySetControllerLateLatchAction(InputSystem.InputDevice device, InputFeatureUsage usage)
        //{
        //    return OpenXRInput.TrySetControllerLateLatchAction(device, usage.name);
        //}

        //// Token: 0x06000113 RID: 275 RVA: 0x00004C44 File Offset: 0x00002E44
        //public static bool TrySetControllerLateLatchAction(InputSystem.InputDevice device, string usageName)
        //{
        //    uint deviceId = OpenXRInput.GetDeviceId(device);
        //    if (deviceId == 0U)
        //    {
        //        return false;
        //    }
        //    ulong actionHandle = OpenXRInput.GetActionHandle(device, usageName);
        //    return actionHandle != 0UL && OpenXRInput.InternalTrySetControllerLateLatchAction(deviceId, actionHandle);
        //}

        //// Token: 0x06000114 RID: 276 RVA: 0x00004C71 File Offset: 0x00002E71
        //public static ulong GetActionHandle(InputSystem.InputDevice device, InputFeatureUsage usage)
        //{
        //    return OpenXRInput.GetActionHandle(device, usage.name);
        //}

        //// Token: 0x06000115 RID: 277 RVA: 0x00004C80 File Offset: 0x00002E80
        //public static ulong GetActionHandle(InputSystem.InputDevice device, string usageName)
        //{
        //    uint deviceId = OpenXRInput.GetDeviceId(device);
        //    if (deviceId == 0U)
        //    {
        //        return 0UL;
        //    }
        //    return OpenXRInput.InternalGetActionIdNoISX(deviceId, usageName);
        //}

        //// Token: 0x06000116 RID: 278 RVA: 0x00004CA4 File Offset: 0x00002EA4
        //public static ulong GetActionHandle(InputAction inputAction, InputSystem.InputDevice inputDevice = default)
        //{
        //    if (inputAction == null || inputAction.controls.Count == 0)
        //    {
        //        return 0UL;
        //    }
        //    foreach (InputControl control in inputAction.controls)
        //    {
        //        if ((inputDevice == null || control.device == inputDevice) && control.device != null)
        //        {
        //            uint deviceId = OpenXRInput.GetDeviceId(control.device);
        //            if (deviceId != 0U)
        //            {
        //                string controlName = OpenXRInput.GetActionHandleName(control);
        //                ulong xrAction = OpenXRInput.InternalGetActionId(deviceId, controlName);
        //                if (xrAction != 0UL)
        //                {
        //                    return xrAction;
        //                }
        //            }
        //        }
        //    }
        //    return 0UL;
        //}

        //// Token: 0x06000117 RID: 279 RVA: 0x00004D50 File Offset: 0x00002F50
        //public static uint GetDeviceId(InputSystem.InputDevice inputDevice)
        //{
        //    if (inputDevice == null)
        //    {
        //        return 0U;
        //    }
        //    //return (uint)inputDevice.deviceId;
        //    //foreach (var dev in InputSystem.InputSystem.s_Manager.devices)
        //    //{
        //    //    if (dev.name == inputDevice.name)
        //    //    {
        //    //        return (uint)dev.deviceId;
        //    //    }
        //    //}
        //    //todo
        //    OpenXRInput.GetpublicDeviceIdCommand command = OpenXRInput.GetpublicDeviceIdCommand.Create();
        //    //if (inputDevice.ExecuteCommand<OpenXRInput.GetpublicDeviceIdCommand>(ref command) != 0L)
        //    unsafe
        //    {
        //        InputDeviceCommand* ptr = (InputDeviceCommand*)&command;
        //        if (inputDevice.ExecuteCommand(ptr) != 0L)
        //        {
        //            return command.deviceId;
        //        }
        //    }
        //    return 0U;
        //}

        // Token: 0x06000118 RID: 280 RVA: 0x00004D7A File Offset: 0x00002F7A
        //public static uint GetDeviceId(InputDevice inputDevice)
        //{
        //	return OpenXRInput.InternalGetDeviceId(inputDevice.characteristics, inputDevice.name);
        //}

        // Token: 0x06000119 RID: 281 RVA: 0x00004D90 File Offset: 0x00002F90
        public static string UserPathToDeviceName(string userPath)
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
                    string sanitizedPart = SanitizeStringForOpenXRPath(part);
                    nameBuilder.Append(char.ToUpper(sanitizedPart[0]));
                    nameBuilder.Append(sanitizedPart.Substring(1));
                }
            }
            return nameBuilder.ToString();
        }

        // Token: 0x0600011A RID: 282
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SetDpadBindingCustomValues")]
        public static extern void InternalSetDpadBindingCustomValues([MarshalAs(UnmanagedType.I1)] bool isLeft, float forceThreshold, float forceThresholdReleased, float centerRegion, float wedgeAngle, [MarshalAs(UnmanagedType.I1)] bool isSticky);

        // Token: 0x0600011B RID: 283
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SendHapticImpulse")]
        public static extern void InternalSendHapticImpulse(uint deviceId, ulong actionId, float amplitude, float frequency, float duration);

        // Token: 0x0600011C RID: 284
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_SendHapticImpulseNoISX")]
        public static extern void InternalSendHapticImpulseNoISX(uint deviceId, float amplitude, float frequency, float duration);

        // Token: 0x0600011D RID: 285
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_StopHaptics")]
        public static extern void InternalStopHaptics(uint deviceId, ulong actionId);

        // Token: 0x0600011E RID: 286
        [DllImport("UnityOpenXR", CallingConvention = CallingConvention.Cdecl, EntryPoint = "OpenXRInputProvider_StopHapticsNoISX")]
        public static extern void InternalStopHapticsNoISX(uint deviceId);

        // Token: 0x0600011F RID: 287
        [DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetActionIdByControl")]
        public static extern ulong InternalGetActionId(uint deviceId, string name);

        // Token: 0x06000120 RID: 288
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetActionIdByUsageName")]
        public static extern ulong InternalGetActionIdNoISX(uint deviceId, string usageName);

        // Token: 0x06000121 RID: 289
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_TryGetInputSourceName")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InternalTryGetInputSourceNamePtr(uint deviceId, ulong actionId, uint index, uint flags, out IntPtr outName);

        // Token: 0x06000122 RID: 290 RVA: 0x00004E0C File Offset: 0x0000300C
        public static bool InternalTryGetInputSourceName(uint deviceId, ulong actionId, uint index, uint flags, out string outName)
        {
            IntPtr outNamePtr;
            if (!InternalTryGetInputSourceNamePtr(deviceId, actionId, index, flags, out outNamePtr))
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
        public static extern bool InternalTrySetControllerLateLatchAction(uint deviceId, ulong actionId);

        // Token: 0x06000124 RID: 292
        [DllImport("UnityOpenXR", EntryPoint = "OpenXRInputProvider_GetActionIsActive")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InternalGetActionIsActive(uint deviceId, string name);

        // Token: 0x06000125 RID: 293
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetActionIsActiveNoISX")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InternalGetActionIsActiveNoISX(uint deviceId, string name);

        // Token: 0x06000126 RID: 294
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_RegisterDeviceDefinition")]
        public static extern ulong InternalRegisterDeviceDefinition(string userPath, string interactionProfile, [MarshalAs(UnmanagedType.I1)] bool isAdditive, uint characteristics, string name, string manufacturer, string serialNumber);

        // Token: 0x06000127 RID: 295
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_CreateActionSet")]
        public static extern ulong InternalCreateActionSet(string name, string localizedName, SerializedGuid guid);

        // Token: 0x06000128 RID: 296
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_CreateAction")]
        public static extern ulong InternalCreateAction(ulong actionSetId, string name, string localizedName, uint actionType, SerializedGuid guid, string[] userPaths, uint userPathCount, [MarshalAs(UnmanagedType.I1)] bool isAdditive, string[] usages, uint usageCount);

        // Token: 0x06000129 RID: 297
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_SuggestBindings")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InternalSuggestBindings(string interactionProfile, SerializedBinding[] serializedBindings, uint serializedBindingCount);

        // Token: 0x0600012A RID: 298
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_AttachActionSets")]
        [return: MarshalAs(UnmanagedType.U1)]
        public static extern bool InternalAttachActionSets();

        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetXRSession")]
        public static unsafe extern void InternalGetXRsession(ulong* xrSession);

        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetActionIdByGuid")]
        public static unsafe extern ulong InternalGetActionIdByGUID(SerializedGuid* guid);

        // Token: 0x0600012B RID: 299
        [DllImport("UnityOpenXR", CharSet = CharSet.Ansi, EntryPoint = "OpenXRInputProvider_GetDeviceId")]
        public static extern uint InternalGetDeviceId(InputDeviceCharacteristics characteristics, string name);

        // Token: 0x0600012C RID: 300 RVA: 0x00004E3C File Offset: 0x0000303C
        // Note: this type is marked as 'beforefieldinit'.
        static OpenXRInput()
        {
            Dictionary<string, OpenXRInteractionFeature.ActionType> dictionary = new()
            {
                ["Digital"] = OpenXRInteractionFeature.ActionType.Binary,
                ["Button"] = OpenXRInteractionFeature.ActionType.Binary,
                ["Axis"] = OpenXRInteractionFeature.ActionType.Axis1D,
                ["Integer"] = OpenXRInteractionFeature.ActionType.Axis1D,
                ["Analog"] = OpenXRInteractionFeature.ActionType.Axis1D,
                ["Vector2"] = OpenXRInteractionFeature.ActionType.Axis2D,
                ["Dpad"] = OpenXRInteractionFeature.ActionType.Axis2D,
                ["Stick"] = OpenXRInteractionFeature.ActionType.Axis2D,
                ["Pose"] = OpenXRInteractionFeature.ActionType.Pose,
                ["Vector3"] = OpenXRInteractionFeature.ActionType.Pose,
                ["Quaternion"] = OpenXRInteractionFeature.ActionType.Pose,
                ["Haptic"] = OpenXRInteractionFeature.ActionType.Vibrate
            };
            ExpectedControlTypeToActionType = dictionary;
            Dictionary<string, string> dictionary2 = new()
            {
                ["deviceposition"] = "devicepose",
                ["devicerotation"] = "devicepose",
                ["trackingstate"] = "devicepose",
                ["istracked"] = "devicepose",
                ["pointerposition"] = "pointer",
                ["pointerrotation"] = "pointer"
            };
            kVirtualControlMap = dictionary2;
        }

        // Token: 0x04000177 RID: 375
        public static readonly Dictionary<string, OpenXRInteractionFeature.ActionType> ExpectedControlTypeToActionType;

        // Token: 0x04000178 RID: 376
        public const string s_devicePoseActionName = "devicepose";

        // Token: 0x04000179 RID: 377
        public const string s_pointerActionName = "pointer";

        // Token: 0x0400017A RID: 378
        public static readonly Dictionary<string, string> kVirtualControlMap;

        // Token: 0x0400017B RID: 379
        public const string Library = "UnityOpenXR";

        // Token: 0x0200003B RID: 59
        [StructLayout(LayoutKind.Explicit)]
        public struct SerializedGuid
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
        public struct SerializedBinding
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
        public struct GetpublicDeviceIdCommand : IInputDeviceCommandInfo
        {
            // Token: 0x17000029 RID: 41
            // (get) Token: 0x0600012D RID: 301 RVA: 0x00004F4D File Offset: 0x0000314D
            public static FourCC Type
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
                    return Type;
                }
            }

            // Token: 0x0600012F RID: 303 RVA: 0x00004F64 File Offset: 0x00003164
            public static GetpublicDeviceIdCommand Create()
            {
                return new GetpublicDeviceIdCommand
                {
                    baseCommand = new InputDeviceCommand(Type, 12)
                };
            }

            // Token: 0x04000186 RID: 390
            public const int k_BaseCommandSizeSize = 8;

            // Token: 0x04000187 RID: 391
            public const int k_Size = 12;

            // Token: 0x04000188 RID: 392
            [FieldOffset(0)]
            public InputDeviceCommand baseCommand;

            // Token: 0x04000189 RID: 393
            [FieldOffset(8)]
            public readonly uint deviceId;
        }
    }
}
