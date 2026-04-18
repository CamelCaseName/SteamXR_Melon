using UnityEngine.InputSystem.Layouts;

namespace UnityEngine.XR.OpenXR.Il2CppShenanigans
{
    [HarmonyLib.HarmonyPatch(typeof(InputControlLayout.Cache), nameof(InputControlLayout.cache.FindOrLoadLayout))]
    public class InputControlLayoutCachePatches
    {
        private static void Prefix(string name, ref bool throwIfNotFound)
        {
            throwIfNotFound = false;
        }

        private static void Postfix(string name, bool throwIfNotFound, ref InputControlLayout __result)
        {
            //MelonLogger.Msg("cache search for " + name);

            if (__result is null)
            {
                var layout = InputControlLayout.s_Layouts.TryLoadLayoutInternal(new(name));
                if (layout != null)
                {
                    __result = layout;
                }
            }
        }

        //[HarmonyLib.HarmonyPatch(typeof(InputControlLayout.Collection), nameof(InputControlLayout.s_Layouts.TryLoadLayout))]
        //public class InputControlLayoutCachePatches
        //{
        //    private static bool Prefix(InternedString name, Dictionary<InternedString, InputControlLayout> table, ref InputControlLayout __result)
        //    {
        //        if (table != null && table.TryGetValue(name, out InputControlLayout layout))
        //        {
        //            __result = layout;
        //            return false;
        //        }
        //        layout = InputControlLayout.s_Layouts.TryLoadLayoutInternal(name);
        //        if (layout != null)
        //        {
        //            layout.m_Name = name;
        //            if (InputControlLayout.s_Layouts.layoutOverrideNames.Contains(name))
        //            {
        //                layout.isOverride = true;
        //            }
        //            if (!layout.isOverride && InputControlLayout.s_Layouts.baseLayoutTable.TryGetValue(name, out InternedString baseLayoutName))
        //            {
        //                Debug.Assert(!baseLayoutName.IsEmpty());
        //                InputControlLayout baseLayout = InputControlLayout.s_Layouts.TryLoadLayout(baseLayoutName, table) ?? throw new System.Exception(string.Format("Cannot find base layout '{0}' of layout '{1}'", baseLayoutName.m_StringOriginalCase, name.m_StringOriginalCase));
        //                layout.MergeLayout(baseLayout);
        //                if (layout.m_BaseLayouts.length == 0)
        //                {
        //                    layout.m_BaseLayouts.Append(baseLayoutName);
        //                }
        //            }
        //            if (InputControlLayout.s_Layouts.layoutOverrides.TryGetValue(name, out var overrides))
        //            {
        //                foreach (InternedString overrideName in overrides)
        //                {
        //                    InputControlLayout inputControlLayout = InputControlLayout.s_Layouts.TryLoadLayout(overrideName, null);
        //                    inputControlLayout.MergeLayout(layout);
        //                    inputControlLayout.m_BaseLayouts.Clear();
        //                    inputControlLayout.isOverride = false;
        //                    inputControlLayout.isGenericTypeOfDevice = layout.isGenericTypeOfDevice;
        //                    inputControlLayout.m_Name = layout.name;
        //                    inputControlLayout.m_BaseLayouts = layout.m_BaseLayouts;
        //                    layout = inputControlLayout;
        //                    layout.m_AppliedOverrides.Append(overrideName);
        //                }
        //            }
        //            if (table != null)
        //            {
        //                table[name] = layout;
        //            }
        //        }
        //        __result = layout;
        //        return false;
        //    }
        //}
    }
}
