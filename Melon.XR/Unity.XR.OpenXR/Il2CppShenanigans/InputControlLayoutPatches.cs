using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Reflection;
using Il2CppSystem.Runtime.InteropServices;
using MelonLoader;
using System.Linq;
using System.Reflection;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.XR.OpenXR.Il2CppShenanigans
{
    [HarmonyLib.HarmonyPatch(typeof(InputControlLayout), nameof(InputControlLayout.AddControlItemsFromMembers))]
    public class InputControlLayoutPatches
    {
        private static bool Prefix(Il2CppReferenceArray<Il2CppSystem.Reflection.MemberInfo> members, Il2CppSystem.Collections.Generic.List<InputControlLayout.ControlItem> controlItems, string layoutName)
        {
            //MelonLogger.Msg("invokkeeee");
            //MelonLogger.Msg(members?.Length);
            //MelonLogger.Msg(controlItems?.Count);
            //MelonLogger.Msg(layoutName);
            foreach (Il2CppSystem.Reflection.MemberInfo member in members)
            {
                HandleMember(controlItems, layoutName, member);
            }

            return false;
        }

        private static void HandleMember(Il2CppSystem.Collections.Generic.List<InputControlLayout.ControlItem> controlItems, string layoutName, Il2CppSystem.Reflection.MemberInfo member)
        {
            //MelonLogger.Msg("member: " + member?.Name);
            if (!(member.DeclaringType == Il2CppType.Of<InputControl>()))
            {
                Il2CppSystem.Type valueType = TypeHelpers.GetValueType(member);
                if (valueType != null && valueType.IsValueType && Il2CppType.Of<IInputStateTypeInfo>().IsAssignableFrom(valueType))
                {
                    int controlCountBefore = controlItems.Count;
                    InputControlLayout.AddControlItems(valueType, controlItems, layoutName);
                    if (member as Il2CppSystem.Reflection.FieldInfo != null)
                    {
                        int fieldOffset = Marshal.OffsetOf(member.DeclaringType, member.Name).ToInt32();
                        int controlCountAfter = controlItems.Count;
                        for (int i = controlCountBefore; i < controlCountAfter; i++)
                        {
                            InputControlLayout.ControlItem controlLayout = controlItems[i];
                            if (controlItems[i].offset != 4294967295U)
                            {
                                controlLayout.offset += (uint)fieldOffset;
                                controlItems[i] = controlLayout;
                            }
                        }
                    }
                }
                //old state, no worky
                //InputControlAttribute[] attributes = member.GetCustomAttributes(false).ToArray<InputControlAttribute>().ToArray();
                //get the system equivalent of that member so we can grab the info from the managed side attribute...
                var systemType = System.Type.GetType(member.DeclaringType.AssemblyQualifiedName); //name is right here, but we no get type
                //MelonLogger.Msg("adding controls to type: " + member.DeclaringType.FullName);
                if (systemType is null)
                {
                    MelonLogger.Error(member.DeclaringType.FullName + " system type was null!");
                    return;
                }
                var shenaniganAttributes = systemType.GetMember(member.Name)[0].GetCustomAttributes<InputControlAttribute>(false).ToArray();
                var attributes = new UnityEngine.InputSystem.Layouts.InputControlAttribute[shenaniganAttributes.Length];
                for (int i = 0; i < shenaniganAttributes.Length; i++)
                {
                    InputControlAttribute attribute = shenaniganAttributes[i];
                    attributes[i] = new()
                    {
                        alias = attribute.alias,
                        aliases = attribute.aliases,
                        arraySize = attribute.arraySize,
                        bit = attribute.bit,
                        defaultState = attribute.defaultState,
                        displayName = attribute.displayName,
                        dontReset = attribute.dontReset,
                        format = attribute.format,
                        layout = attribute.layout,
                        maxValue = attribute.maxValue,
                        minValue = attribute.minValue,
                        name = attribute.name,
                        noisy = attribute.noisy,
                        offset = attribute.offset,
                        parameters = attribute.parameters,
                        processors = attribute.processors,
                        shortDisplayName = attribute.shortDisplayName,
                        sizeInBits = attribute.sizeInBits,
                        synthetic = attribute.synthetic,
                        usage = attribute.usage,
                        usages = attribute.usages,
                        useStateFrom = attribute.useStateFrom,
                        variants = attribute.variants,
                    };
                }
                if (attributes.Length != 0 || (!(valueType == null) && Il2CppType.Of<InputControl>().IsAssignableFrom(valueType) && member is not Il2CppSystem.Reflection.PropertyInfo))
                {
                    InputControlLayout.AddControlItemsFromMember(member, attributes, controlItems);
                }
            }
        }
    }
}
