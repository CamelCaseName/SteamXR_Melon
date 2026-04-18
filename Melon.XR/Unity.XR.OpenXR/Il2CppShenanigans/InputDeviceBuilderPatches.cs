using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.XR.OpenXR.Il2CppShenanigans
{
    //[HarmonyLib.HarmonyPatch(typeof(InputDeviceBuilder), nameof(InputDeviceBuilder.AddChildControl))]
    //internal class InputDeviceBuilder_AddChildControl_Patch
    //{
    //    private static void Prefix(ref InputControlLayout layout, ref InputSystem.InputControl parent, ref InputControlLayout.ControlItem controlItem)
    //    {
    //        if (controlItem.layout.ToString().ToLowerInvariant() == "haptic")
    //        {
    //            controlItem.sizeInBits = 1;
    //            layout.m_StateSizeInBytes = 1;
    //            layout.m_StateFormat = new FourCC('B', 'I', 'T', ' ');
    //            parent.m_StateBlock = new()
    //            {
    //                format = InputStateBlock.FormatBit,
    //                sizeInBits = 1
    //            };
    //        }
    //    }
    //}

    [HarmonyLib.HarmonyPatch(typeof(InputDeviceBuilder), nameof(InputDeviceBuilder.ComputeStateLayout))]
    internal class InputDeviceBuilder_ComputeStateLayout_Patch
    {
        private static void Prefix(ref InputSystem.InputControl control)
        {
            if (control.layout.ToString().ToLowerInvariant() == "haptic")
            {
                //MelonLoader.MelonLogger.Msg("hook ran and setting the size again:(");
                control.m_StateBlock = new()
                {
                    format = InputStateBlock.FormatBit,
                    sizeInBits = 1
                };
            }
        }
    }
}
