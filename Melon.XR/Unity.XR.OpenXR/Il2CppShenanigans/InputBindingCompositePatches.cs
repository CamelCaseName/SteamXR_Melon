using System;
using System.Linq;
using System.Reflection;
using UnityEngine.InputSystem;

namespace UnityEngine.XR.OpenXR.Il2CppShenanigans
{
    [HarmonyLib.HarmonyPatch(typeof(UnityEngine.InputSystem.InputBindingComposite), nameof(UnityEngine.InputSystem.InputBindingComposite.GetExpectedControlLayoutName))]
    //this handles the most important place where the inputcontrolattribute is read
    public class InputBindingComposites_GetExpectedControlLayoutName_Patch
    {
        private static bool Prefix(string composite, string part, ref string __result)
        {
            if (string.IsNullOrEmpty(composite))
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (string.IsNullOrEmpty(part))
            {
                throw new ArgumentNullException(nameof(part));
            }
            Type compositeType = System.Type.GetType(InputBindingComposite.s_Composites.LookupTypeRegistration(composite).AssemblyQualifiedName);
            if (compositeType == null)
            {
                return false;
            }
            FieldInfo field = compositeType.GetField(part, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (field == null)
            {
                return false;
            }
            InputControlAttribute customAttribute = field.GetCustomAttributes<InputControlAttribute>(false).First();
            if (customAttribute == null)
            {
                return false;
            }
            __result = customAttribute.layout;
            return false;
        }
    }

    //this is the last instance where the inputcontrolattribute would be read, but it is only called from the editor so fuck it
    //[HarmonyLib.HarmonyPatch(typeof(UnityEngine.InputSystem.InputBindingComposite._GetPartNames_d__12), nameof(UnityEngine.InputSystem.InputBindingComposite._GetPartNames_d__12.MoveNext))]
    //public class InputBindingComposites_MoveNext_Patch
    //{

    //}
}
