//using MelonLoader;
//using System;
//using System.Collections.Generic;
//using UnityEngine.XR.OpenXR.Input;
//using static UnityEngine.XR.OpenXR.Features.OpenXRInteractionFeature;
//using ActionType = UnityEngine.XR.OpenXR.Features.OpenXRInteractionFeature.ActionType;

//namespace UnityEngine.XR.OpenXR
//{
//    public static unsafe class InputMap
//    {
//        private const string hpvr = "HPVR";
//        public static ActionConfig CombatBool { get; private set; } = new()
//        {
//            name = "combat",
//            localizedName = "Toggle Combat Mode",
//            type = ActionType.Binary,
//            bindings = new(){new() {

//        }}
//        };
//        public static ActionConfig CrouchBool { get; private set; } = new() { name = "crouch", localizedName = "Crouch", type = ActionType.Binary };
//        public static ActionConfig FlashBool { get; private set; } = new() { name = "flash", localizedName = "Flash your private bits", type = ActionType.Binary };
//        public static ActionConfig GameMenuBool { get; private set; } = new() { name = "menu", localizedName = "Open/Close Game Menu", type = ActionType.Binary };
//        public static ActionConfig GrabBool { get; private set; } = new() { name = "grab", localizedName = "Grabbing", type = ActionType.Binary };
//        public static ActionConfig Haptic { get; private set; } = new() { name = "haptic", localizedName = "Haptic/Vibration", type = ActionType.Vibrate };
//        public static ActionConfig HMDPose { get; private set; } = new() { name = "hmd_pose", localizedName = "HMD Pose", type = ActionType.Pose };
//        public static ActionConfig InteractUIBool { get; private set; } = new() { name = "ui_interact", localizedName = "UI Interaction", type = ActionType.Binary };
//        public static ActionConfig InventoryBool { get; private set; } = new() { name = "inventory", localizedName = "Open/Close Inventory", type = ActionType.Binary };
//        public static ActionConfig LeftHandPose { get; private set; } = new() { name = "left_hand_pose", localizedName = "Left Hand Pose", type = ActionType.Pose };
//        public static ActionConfig MasturbateBool { get; private set; } = new() { name = "masturbate", localizedName = "Masturbate", type = ActionType.Binary };
//        public static ActionConfig MemoriesBool { get; private set; } = new() { name = "memories", localizedName = "Open/Close Memories", type = ActionType.Binary };
//        public static ActionConfig MoveVec { get; private set; } = new() { name = "move", localizedName = "Move", type = ActionType.Axis2D };
//        public static ActionConfig OpportunitiesBool { get; private set; } = new() { name = "opportunities", localizedName = "Open/Close Opportunities", type = ActionType.Binary };
//        public static ActionConfig PeeBool { get; private set; } = new() { name = "pee", localizedName = "Pee", type = ActionType.Binary };
//        public static ActionConfig RightHandPose { get; private set; } = new() { name = "right_hand_pose", localizedName = "Right Hand Pose", type = ActionType.Pose };
//        public static ActionConfig SelfRadialBool { get; private set; } = new() { name = "self_radial", localizedName = "Player Radial", type = ActionType.Binary };
//        public static ActionConfig SnapTurnLeftBool { get; private set; } = new() { name = "snap_turn_left", localizedName = "SnapTurn (Left)", type = ActionType.Binary };
//        public static ActionConfig SnapTurnRightBool { get; private set; } = new() { name = "snap_turn_right", localizedName = "SnapTurn (Right)", type = ActionType.Binary };
//        public static ActionConfig UIRadialBool { get; private set; } = new() { name = "ui_radial", localizedName = "UI Radial", type = ActionType.Binary };
//        private static List<ActionConfig> actions = new();
//        private static Dictionary<ActionConfig, Action> actionLookup = new();
//        private static ulong SetHandle = 0;

//        public static void Init()
//        {
//            actions.Add(CombatBool);
//            actions.Add(CrouchBool);
//            actions.Add(FlashBool);
//            actions.Add(GameMenuBool);
//            actions.Add(GrabBool);
//            actions.Add(Haptic);
//            actions.Add(HMDPose);
//            actions.Add(InteractUIBool);
//            actions.Add(InventoryBool);
//            actions.Add(LeftHandPose);
//            actions.Add(MasturbateBool);
//            actions.Add(MemoriesBool);
//            actions.Add(MoveVec);
//            actions.Add(OpportunitiesBool);
//            actions.Add(PeeBool);
//            actions.Add(RightHandPose);
//            actions.Add(SelfRadialBool);
//            actions.Add(SnapTurnLeftBool);
//            actions.Add(SnapTurnRightBool);
//            actions.Add(UIRadialBool);

//            //MelonLogger.Msg("hpvr openxr check instance");
//            //CheckXRInstance();

//            MelonLogger.Msg("hpvr openxr action registering:");
//            MakeSet();

//            MelonLogger.Msg("creating actions");
//            MakeAction(CombatBool, SetHandle);
//            MakeAction(CrouchBool, SetHandle);
//            MakeAction(FlashBool, SetHandle);
//            MakeAction(GameMenuBool, SetHandle);
//            MakeAction(GrabBool, SetHandle, true);
//            MakeAction(Haptic, SetHandle, true);
//            MakeAction(HMDPose, SetHandle);
//            MakeAction(InteractUIBool, SetHandle);
//            MakeAction(InventoryBool, SetHandle);
//            MakeAction(LeftHandPose, SetHandle);
//            MakeAction(MasturbateBool, SetHandle);
//            MakeAction(MemoriesBool, SetHandle);
//            MakeAction(MoveVec, SetHandle);
//            MakeAction(OpportunitiesBool, SetHandle);
//            MakeAction(PeeBool, SetHandle);
//            MakeAction(RightHandPose, SetHandle);
//            MakeAction(SelfRadialBool, SetHandle);
//            MakeAction(SnapTurnLeftBool, SetHandle);
//            MakeAction(SnapTurnRightBool, SetHandle);
//            MakeAction(UIRadialBool, SetHandle);
//            MelonLogger.Msg("done creating actions");

//            //MelonLogger.Msg("creating binding suggestions");
//            //MakeSuggestions("/interaction_profiles/khr/simple_controller", new()
//            //{
//            //    new(GameMenuBool, "/user/hand/left/input/menu/click"),
//            //    new(LeftHandPose, "/user/hand/left/input/grip/pose"),
//            //    new(RightHandPose, "/user/hand/right/input/grip/pose"),
//            //    new(Haptic, "/user/hand/left/output/haptic"),
//            //    new(Haptic, "/user/hand/right/output/haptic"),
//            //    new(InteractUIBool, "/user/hand/left/input/select/click"),
//            //    new(UIRadialBool, "/user/hand/right/input/select/click"),
//            //    new(SelfRadialBool, "/user/hand/right/input/menu/click")
//            //});
//            //MakeSuggestions("/interaction_profiles/oculus/touch_controller", new()
//            //{
//            //    new(CombatBool, "/user/hand/right/input/squeeze/value"),
//            //    //new(CrouchBool, "/user/hand//input/"),
//            //    new(FlashBool, "/user/hand/left/input/squeeze/value"),
//            //    new(GameMenuBool, "/user/hand/left/input/menu/click"),
//            //    new(GrabBool, "/user/hand/left/input/trigger/value"),
//            //    new(GrabBool, "/user/hand/right/input/trigger/value"),
//            //    new(Haptic, "/user/hand/left/output/haptic"),
//            //    new(Haptic, "/user/hand/right/output/haptic"),
//            //    new(InteractUIBool, "/user/hand/left/input/x/click"),
//            //    new(LeftHandPose, "/user/hand/left/input/grip/pose"),
//            //    //new(MemoriesBool, "/user/hand//input/"),
//            //    new(MoveVec, "/user/hand/left/input/thumbstick"),
//            //    new(PeeBool, "/user/hand/left/input/thumbstick/click"),
//            //    new(RightHandPose, "/user/hand/right/input/grip/pose"),
//            //    new(SelfRadialBool, "/user/hand/left/input/y/click"),
//            //    new(UIRadialBool, "/user/hand/right/input/b/click"),
//            //    new(InventoryBool, "/user/hand/right/input/thumbstick/dpad_up"),
//            //    new(MasturbateBool, "/user/hand/right/input/thumbstick/click"),
//            //    new(OpportunitiesBool, "/user/hand/right/input/thumbstick/dpad_down"),
//            //    new(SnapTurnLeftBool, "/user/hand/right/input/thumbstick/dpad_left"),
//            //    new(SnapTurnRightBool, "/user/hand/right/input/thumbstick/dpad_right"),
//            //});
//            //MelonLogger.Msg("done creating binding suggestions");

//        }

//        //private static void CheckXRInstance()
//        //{
//        //    MelonLogger.Msg("do we have an instance?");
//        //    if (xr.CurrentInstance.HasValue)
//        //    {
//        //        MelonLogger.Msg("we have an xr instance");
//        //    }
//        //    else if (useNew)
//        //    {
//        //        MelonLogger.Msg("No instance yet, creating new one");
//        //        ApplicationInfo appinfo = new()
//        //        {
//        //            EngineVersion = 1,
//        //            ApplicationVersion = 1,
//        //            ApiVersion = Silk.NET.OpenXR.XR.CurrentLoaderApiLayerVersion
//        //        };
//        //        string engineName = "OpenXR Engine";
//        //        for (int i = 0; i < engineName.Length; i++)
//        //        {
//        //            appinfo.EngineName[i] = (byte)engineName[i];
//        //        }
//        //        string appName = "HPVR";
//        //        for (int i = 0; i < appName.Length; i++)
//        //        {
//        //            appinfo.ApplicationName[i] = (byte)appName[i];
//        //        }

//        //        InstanceCreateInfo instanceInfo = new()
//        //        {
//        //            ApplicationInfo = appinfo,
//        //            CreateFlags = InstanceCreateFlags.None,
//        //            //todo check what extension and feature layers we would need here
//        //        };
//        //        Instance inst = new();
//        //        var re2 = xr.CreateInstance(ref instanceInfo, ref inst);
//        //        if (re2 != Result.Success)
//        //        {
//        //            MelonLogger.Msg("EO: " + re2.ToString());
//        //        }
//        //        xr.CurrentInstance = inst;
//        //    }
//        //    else
//        //    {
//        //        MelonLogger.Msg("No Instance yet, grabbing the one from unity");
//        //        MelonLogger.Msg("Loading internal Unity XR Context function");
//        //        var process = Process.GetCurrentProcess();
//        //        foreach (ProcessModule module in process.Modules)
//        //        {
//        //            // MelonLogger.Msg(module.FileName);
//        //            if (!module.FileName.Contains("openxr_loader"))
//        //            {
//        //                continue;
//        //            }

//        //            MelonLogger.Msg("Found the openxr_loader module");

//        //            var getContextAddress = module.BaseAddress + GetUnityXRContext;
//        //            MelonLogger.Msg($"getContext Address: {getContextAddress:x} (offset {GetUnityXRContext:x})");

//        //            method = Marshal.GetDelegateForFunctionPointer<GetUnityOpenXRContext>(getContextAddress);
//        //            MelonLogger.Msg("got the delegate");

//        //            break;
//        //        }

//        //        MelonLogger.Msg("Running method");
//        //        var contextPtr = (ulong*)method();
//        //        MelonLogger.Msg($"context pointer sits at: 0x{(ulong)contextPtr:x}");
//        //        var context = (ulong*)*contextPtr;
//        //        MelonLogger.Msg($"context pointer is: 0x{(ulong)context:x}");
//        //        context += 0x50;
//        //        MelonLogger.Msg($"offset from +0x50 is: 0x{(ulong)context:x}");
//        //        MelonLogger.Msg($"instance handle is: 0x{*context:x}");
//        //        xr.CurrentInstance = new(*context);
//        //    }
//        //}

//        //private static readonly int GetUnityXRContext = 0x33d30;

//        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
//        //private delegate ulong GetUnityOpenXRContext();
//        //private static GetUnityOpenXRContext method;

//        //private static void MakeSuggestions(string controller, List<Tuple<ActionConfig, string>> suggestions)
//        //{
//        //    ulong path = 0;
//        //    var res = xr.StringToPath(xr.CurrentInstance.Value, controller, ref path);
//        //    if (res != Result.Success)
//        //    {
//        //        MelonLogger.Msg("ERIRORR: " + res.ToString());
//        //    }

//        //    ActionSuggestedBinding[] bindings = new ActionSuggestedBinding[suggestions.Count];
//        //    for (int i = 0; i < suggestions.Count; i++)
//        //    {
//        //        ulong temppath = 0;
//        //        var tempres = xr.StringToPath(xr.CurrentInstance.Value, controller, ref temppath);
//        //        if (tempres != Result.Success)
//        //        {
//        //            MelonLogger.Msg(i + "-ERIRORR: " + tempres.ToString());
//        //        }
//        //        bindings[i] = new()
//        //        {
//        //            Action = actionLookup[suggestions[i].Item1],
//        //            Binding = temppath
//        //        };
//        //    }

//        //    fixed (ActionSuggestedBinding* s = bindings)
//        //    {
//        //        InteractionProfileSuggestedBinding suggest = new()
//        //        {
//        //            CountSuggestedBindings = (uint)bindings.Length,
//        //            InteractionProfile = path,
//        //            SuggestedBindings = s
//        //        };
//        //        res = xr.SuggestInteractionProfileBinding(xr.CurrentInstance.Value, ref suggest);
//        //        if (res != Result.Success)
//        //        {
//        //            MelonLogger.Msg("ERRR: " + res.ToString());
//        //        }
//        //    }
//        //}

//        private static void MakeSet()
//        {
//            ulong actionSetId = OpenXRInput.InternalCreateActionSet(OpenXRInput.SanitizeStringForOpenXRPath(hpvr), hpvr, default);
//            if (actionSetId == 0UL)
//            {
//                OpenXRRuntime.LogLastError();
//            }
//            MelonLogger.Msg("Created Action set");
//        }

//        private static void MakeAction(ActionConfig config, ulong set, bool isHandDependant = false)
//        {

//        }

//        //private static Action MakeAction(ActionConfig config, ulong set, bool isHandDependant = false)
//        //{
//        //    Action action = new();
//        //    ActionCreateInfo info = new()
//        //    {
//        //        ActionType = (Silk.NET.OpenXR.ActionType)config.type,
//        //    };
//        //    for (int i = 0; i < Math.Min(config.name.Length, 64); i++)
//        //    {
//        //        info.ActionName[i] = (byte)config.name[i];
//        //    }
//        //    for (int i = 0; i < Math.Min(config.localizedName.Length, 128); i++)
//        //    {
//        //        info.LocalizedActionName[i] = (byte)config.localizedName[i];
//        //    }
//        //    ulong path1 = 0;
//        //    var res = xr.StringToPath(xr.CurrentInstance.Value, "/user/hand/left", ref path1);
//        //    if (res != Result.Success)
//        //    {
//        //        MelonLogger.Msg("ERI333RORR: " + res.ToString());
//        //    }
//        //    ulong path2 = 0;
//        //    res = xr.StringToPath(xr.CurrentInstance.Value, "/user/hand/right", ref path2);
//        //    if (res != Result.Success)
//        //    {
//        //        MelonLogger.Msg("ERI222RORR: " + res.ToString());
//        //    }
//        //    ulong[] subPaths = { path1, path2 };
//        //    fixed (ulong* path = subPaths)
//        //    {
//        //        if (isHandDependant)
//        //        {
//        //            info.CountSubactionPaths = 2;
//        //            info.SubactionPaths = path;
//        //        }
//        //        res = xr.CreateAction(set, ref info, ref action);
//        //        if (res != Result.Success)
//        //        {
//        //            MelonLogger.Msg("EORRO: " + res.ToString());
//        //        }
//        //        actionLookup[config] = action;

//        //        return action;
//        //    }
//        //}
//    }
//}
