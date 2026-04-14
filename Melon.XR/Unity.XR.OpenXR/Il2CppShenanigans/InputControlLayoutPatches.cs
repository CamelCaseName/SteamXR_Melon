using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.IO;
using Il2CppSystem.Reflection;
using Il2CppSystem.Runtime.InteropServices;
using JetBrains.Annotations;
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
    //this handles the most important place where the inputcontrolattribute is read
    public class InputControlLayout_AddControlItemsFromMembers_Patch
    {
        private static bool Prefix(Il2CppReferenceArray<Il2CppSystem.Reflection.MemberInfo> members, Il2CppSystem.Collections.Generic.List<InputControlLayout.ControlItem> controlItems, string layoutName)
        {
            //MelonLogger.Msg("invokkeeee");
            //MelonLogger.Msg("[XR Patch] patch triggered: " + members?.Length + " - " + layoutName);
            foreach (Il2CppSystem.Reflection.MemberInfo member in members)
            {
                HandleMember(controlItems, layoutName, member);
            }
            //MelonLogger.Msg("[XR Patch] Added ControlItems from members for: " + layoutName);

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
                        MelonLogger.Warning("test??");
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
                var systemType = System.Type.GetType(member.DeclaringType.AssemblyQualifiedName); //name is right here, needs the fully qualified name :)
                systemType ??= System.Type.GetType(member.DeclaringType.FullName);

                //MelonLogger.Msg("[XR Patch] adding control " + member.ToString() + " to type: " + member.DeclaringType.FullName);

                if (systemType is null)
                {
                    MelonLogger.Error("[XR Patch] " + member.DeclaringType.AssemblyQualifiedName + " system type was null!");
                    return;
                }
                var shenaniganAttributes = systemType.GetMember(member.Name)[0].GetCustomAttributes<InputControlAttribute>(false).ToArray();
                var attributes = new UnityEngine.InputSystem.Layouts.InputControlAttribute[shenaniganAttributes.Length];
                for (int i = 0; i < shenaniganAttributes.Length; i++)
                {
                    InputControlAttribute attribute = shenaniganAttributes[i];
                    attributes[i] = new()
                    {
                        //copy to unity builtin attribute
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

#nullable enable
    [HarmonyLib.HarmonyPatch(typeof(InputControlLayout), nameof(InputControlLayout.FromType))]
    public class InputControlLayout_FromType_Patch
    {
        private static bool Prefix(string name, Il2CppSystem.Type type, InputControlLayout __result)
        {
            List<InputControlLayout.ControlItem> controlLayouts = new();
            var systemType = System.Type.GetType(type.AssemblyQualifiedName); //name is right here, needs the fully qualified name :)

            systemType ??= System.Type.GetType(type.FullName);

            MelonLogger.Msg("[XR Patch] trying to build layout for: " + type.Name);
            //MelonLogger.Msg("full type: " + type.AssemblyQualifiedName);
            int count = 0;
            InputControlLayoutAttribute? layoutAttribute = default;
            if (systemType is not null)
            {
                //foreach (var attr in systemType.GetCustomAttributes<System.Attribute>())
                //{
                //    MelonLogger.Msg(attr.GetType().Name);
                //}

                System.Collections.Generic.IEnumerable<InputControlLayoutAttribute> attribs = systemType.GetCustomAttributes<InputControlLayoutAttribute>(true);
                count = attribs.Count();
                if (count > 0)
                {
                    layoutAttribute = attribs.First();
                }
            }

            if (count == 0)
            {
                var old = type.GetCustomAttribute<UnityEngine.InputSystem.Layouts.InputControlLayoutAttribute>();

                if (old is null)
                {
                    MelonLogger.Error(type.AssemblyQualifiedName + " was either from unity, but had no inputcontrollayout attribute, or was a system type but had no replacement attribute... Or system type could not be found....");
                    return false;
                }
                layoutAttribute = new()
                {
                    //canRunInBackground runs into an issue where its internal nullable is fucked
                    //the internal version is directly fucked... so we just say it can run in background?
                    canRunInBackground = true,
                    commonUsages = old.commonUsages,
                    description = old.description,
                    displayName = old.displayName,
                    hideInUI = old.hideInUI,
                    isGenericTypeOfDevice = old.isGenericTypeOfDevice,
                    isNoisy = old.isNoisy,
                    stateFormat = old.stateFormat,
                    stateType = old.stateType,
                    //same issue here :(
                    updateBeforeRender = true,
                    variants = old.variants
                };
            }

            FourCC stateFormat = default;
            if (layoutAttribute != null && layoutAttribute.stateType != null)
            {
                //jystick, pen and other low level goes here
                InputControlLayout.AddControlItems(layoutAttribute.stateType, controlLayouts, name);
                if (Il2CppType.Of<IInputStateTypeInfo>().IsAssignableFrom(layoutAttribute.stateType))
                {
                    stateFormat = Activator.CreateInstance(layoutAttribute.stateType).Cast<IInputStateTypeInfo>().format;
                }
            }
            else
            {
                //our own implementaions go here
                if (systemType is null)
                {
                    InputControlLayout.AddControlItems(type, controlLayouts, name);
                }
                else
                {
                    InjectInjectedFieldControls(systemType, controlLayouts, name);
                }
            }
            if (layoutAttribute != null && !string.IsNullOrEmpty(layoutAttribute.stateFormat))
            {
                stateFormat = new FourCC(layoutAttribute.stateFormat);
            }
            InternedString variants = new();
            if (layoutAttribute != null)
            {
                variants = new InternedString(layoutAttribute.variants);
            }
            InputControlLayout layout = new(name, type)
            {
                m_Controls = controlLayouts.ToArray().ToArray(),
                m_StateFormat = stateFormat,
                m_Variants = variants,
                m_UpdateBeforeRender = layoutAttribute?.updateBeforeRenderInternal,
                isGenericTypeOfDevice = (layoutAttribute != null && layoutAttribute.isGenericTypeOfDevice),
                hideInUI = (layoutAttribute != null && layoutAttribute.hideInUI),
                m_Description = (layoutAttribute?.description),
                m_DisplayName = (layoutAttribute?.displayName),
                canRunInBackground = layoutAttribute?.canRunInBackgroundInternal,
                isNoisy = (layoutAttribute != null && layoutAttribute.isNoisy)
            };
            if ((layoutAttribute?.commonUsages) != null)
            {
                InternedString[] interneds = new InternedString[layoutAttribute.commonUsages.Length];
                for (int i = 0; i < layoutAttribute.commonUsages.Length; i++)
                {
                    interneds[i] = new InternedString(layoutAttribute.commonUsages[i]);
                }
                layout.m_CommonUsages = interneds;
            }

            MelonLogger.Msg("[XR Patch] Created Input Layout for: " + layout.name);
            __result = layout;

            return false;
        }

        private static void InjectInjectedFieldControls(System.Type type, List<InputControlLayout.ControlItem> controlItems, string layoutName)
        {
            MelonLogger.Msg("[XR Patch] injecting controls manually for: " + type.Name);
            System.Reflection.FieldInfo[] fields = type.GetFields(System.Reflection.BindingFlags.DeclaredOnly | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            MelonLogger.Msg("[XR Patch] control has " + fields.Length + " fields.");
            foreach (var member in fields)
            {
                if (!(member.DeclaringType == typeof(InputControl)))
                {
                    System.Type valueType = member.FieldType;
                    //if (valueType != null && valueType.IsValueType && typeof(IInputStateTypeInfo).IsAssignableFrom(valueType))
                    //{
                    //    int controlCountBefore = controlItems.Count;
                    //    InputControlLayout.AddControlItems(valueType, controlItems, layoutName);
                    //    if (member as FieldInfo != null)
                    //    {
                    //        int fieldOffset = Marshal.OffsetOf(member.DeclaringType, member.Name).ToInt32();
                    //        int controlCountAfter = controlItems.Count;
                    //        for (int i = controlCountBefore; i < controlCountAfter; i++)
                    //        {
                    //            InputControlLayout.ControlItem controlLayout = controlItems[i];
                    //            if (controlItems[i].offset != 4294967295U)
                    //            {
                    //                controlLayout.offset += (uint)fieldOffset;
                    //                controlItems[i] = controlLayout;
                    //            }
                    //        }
                    //    }
                    //}
                    InputControlAttribute[] attributes = member.GetCustomAttributes<InputControlAttribute>(false).ToArray();
                    //MelonLogger.Msg("got " + attributes.Length + " attributes for the field " + member.Name);
                    if (attributes.Length != 0 || (!(valueType == null) && typeof(InputControl).IsAssignableFrom(valueType)))
                    {
                        foreach (InputControlAttribute attribute in attributes)
                        {
                            InputControlLayout.ControlItem controlItem2 = CreateControlItemFromMember(member, attribute);
                            controlItems.Add(controlItem2);
                        }
                    }
                }
            }
        }

        private static InputControlLayout.ControlItem CreateControlItemFromMember(System.Reflection.FieldInfo member, InputControlAttribute attribute)
        {
            string? name = attribute?.name;
            if (string.IsNullOrEmpty(name))
            {
                name = member.Name;
            }
            bool isModifyingChildControlByPath = name.Contains('/');
            string? displayName = attribute?.displayName;
            string? shortDisplayName = attribute?.shortDisplayName;
            string? layout = attribute?.layout;
            if (string.IsNullOrEmpty(layout) && !isModifyingChildControlByPath && (member.GetCustomAttribute<InputControlAttribute>(false) == null))
            {
                layout = InputControlLayout.InferLayoutFromValueType(Il2CppType.From(member.FieldType));
            }

            MelonLogger.Msg("[XR Patch] creating " + member.Name);
            //todo something triggers nullref after this one, but probably only after the offset setting
            string variants = string.Empty;
            if (attribute != null && !string.IsNullOrEmpty(attribute.variants))
            {
                variants = attribute.variants;
            }
            uint offset = uint.MaxValue;
            if (attribute != null && attribute.offset != 4294967295U)
            {
                offset = attribute.offset;
            }
            else if (!isModifyingChildControlByPath)
            {
                //var temp = System.Activator.CreateInstance(member.DeclaringType!);
                //var pobj = Unsafe.As<object, nint>(ref temp);
                //pobj += System.IntPtr.Size + GetFieldOffset(member.FieldHandle);
                offset = (uint)GetFieldOffset(member.FieldHandle);
            }
            uint bit = uint.MaxValue;
            if (attribute != null)
            {
                bit = attribute.bit;
            }
            uint sizeInBits = 0U;
            if (attribute != null)
            {
                sizeInBits = attribute.sizeInBits;
            }
            FourCC format = default;
            if (attribute != null && !string.IsNullOrEmpty(attribute.format))
            {
                format = new FourCC(attribute.format);
            }
            else if (!isModifyingChildControlByPath && bit == 4294967295U)
            {
                format = InputStateBlock.GetPrimitiveFormatFromType(Il2CppType.From(member.FieldType));
            }
            InternedString[] aliases = Array.Empty<InternedString>();
            if (attribute != null)
            {
                var l = attribute.aliases?.Length ?? 0;
                InternedString[] interneds = new InternedString[l + 1];
                interneds[0] = new(attribute.alias);
                for (int i = 0; i < l; i++)
                {
                    interneds[i + 1] = new InternedString(attribute.aliases[i]);
                }
                aliases = interneds;
            }
            InternedString[] usages = Array.Empty<InternedString>();
            if (attribute != null)
            {
                var l = attribute.usages?.Length ?? 0;
                InternedString[] interneds = new InternedString[l + 1];
                interneds[0] = new(attribute.usage);
                for (int i = 0; i < l; i++)
                {
                    interneds[i + 1] = new InternedString(attribute.usages[i]);
                }
                usages = interneds;
            }
            NamedValue[] parameters = Array.Empty<NamedValue>();
            if (attribute != null && !string.IsNullOrEmpty(attribute.parameters))
            {
                parameters = NamedValue.ParseMultiple(attribute.parameters);
            }
            NameAndParameters[] processors = Array.Empty<NameAndParameters>();
            if (attribute != null && !string.IsNullOrEmpty(attribute.processors))
            {
                processors = NameAndParameters.ParseMultiple(attribute.processors).ToArray<NameAndParameters>();
            }
            string useStateFrom = string.Empty;
            if (attribute != null && !string.IsNullOrEmpty(attribute.useStateFrom))
            {
                useStateFrom = attribute.useStateFrom;
            }
            bool isNoisy = false;
            if (attribute != null)
            {
                isNoisy = attribute.noisy;
            }
            bool dontReset = false;
            if (attribute != null)
            {
                dontReset = attribute.dontReset;
            }
            bool isSynthetic = false;
            if (attribute != null)
            {
                isSynthetic = attribute.synthetic;
            }
            int arraySize = 0;
            if (attribute != null)
            {
                arraySize = attribute.arraySize;
            }
            PrimitiveValue defaultState = default;
            if (attribute != null)
            {
                defaultState = PrimitiveValue.FromObject(attribute.defaultState);
            }
            PrimitiveValue minValue = default;
            PrimitiveValue maxValue = default;
            if (attribute != null)
            {
                minValue = PrimitiveValue.FromObject(attribute.minValue);
                maxValue = PrimitiveValue.FromObject(attribute.maxValue);
            }
            return new InputControlLayout.ControlItem
            {
                name = new InternedString(name),
                displayName = displayName,
                shortDisplayName = shortDisplayName,
                layout = new InternedString(layout),
                variants = new InternedString(variants),
                useStateFrom = useStateFrom,
                format = format,
                offset = offset,
                bit = bit,
                sizeInBits = sizeInBits,
                parameters = new ReadOnlyArray<NamedValue>(new Il2CppReferenceArray<NamedValue>(parameters)),
                processors = new ReadOnlyArray<NameAndParameters>(new Il2CppReferenceArray<NameAndParameters>(processors)),
                usages = new ReadOnlyArray<InternedString>(new Il2CppReferenceArray<InternedString>(usages)),
                aliases = new ReadOnlyArray<InternedString>(new Il2CppReferenceArray<InternedString>(aliases)),
                isModifyingExistingControl = isModifyingChildControlByPath,
                isFirstDefinedInThisLayout = true,
                isNoisy = isNoisy,
                dontReset = dontReset,
                isSynthetic = isSynthetic,
                arraySize = arraySize,
                defaultState = defaultState,
                minValue = minValue,
                maxValue = maxValue
            };
        }
        //public static int GetFieldOffset(this System.Reflection.FieldInfo fi) =>
        //            GetFieldOffset(fi.FieldHandle);

        public static int GetFieldOffset(System.RuntimeFieldHandle h) =>
                            System.Runtime.InteropServices.Marshal.ReadInt32(h.Value + (4 + IntPtr.Size)) & 0xFFFFFF;
    }
}
#nullable restore
