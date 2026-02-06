using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace XRHelpers
{
    internal static class InitializerStore<T>
    {
        private static readonly Type[] _intPtrTypeArray = { typeof(IntPtr) };
        private static readonly MethodInfo _getUninitializedObject = typeof(RuntimeHelpers).GetMethod(nameof(RuntimeHelpers.GetUninitializedObject))!;
        private static readonly MethodInfo _getTypeFromHandle = typeof(Type).GetMethod(nameof(Type.GetTypeFromHandle))!;
        private static readonly MethodInfo _createGCHandle = typeof(Il2CppObjectBase).GetMethod("CreateGCHandle", BindingFlags.Instance | BindingFlags.NonPublic)!;
        private static readonly FieldInfo _isWrapped = typeof(Il2CppObjectBase).GetField("isWrapped", BindingFlags.Instance | BindingFlags.NonPublic)!;
        private static Func<IntPtr, T>? _initializer;

        private static Func<IntPtr, T> Create()
        {
            var type = Il2CppClassPointerStore<T>.CreatedTypeRedirect ?? typeof(T);

            var dynamicMethod = new DynamicMethod($"Initializer<{typeof(T).AssemblyQualifiedName}>", type, _intPtrTypeArray);
            dynamicMethod.DefineParameter(0, ParameterAttributes.None, "pointer");

            var il = dynamicMethod.GetILGenerator();

            if (type.GetConstructor(new[] { typeof(IntPtr) }) is { } pointerConstructor)
            {
                // Base case: Il2Cpp constructor => call it directly
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Newobj, pointerConstructor);
            }
            else
            {
                // Special case: We have a parameterless constructor
                // However, it could be be user-made or implicit
                // In that case we set the GCHandle and then call the ctor and let GC destroy any objects created by DerivedConstructorPointer

                // var obj = (T)RuntimeHelpers.GetUninitializedObject(type);
                il.Emit(OpCodes.Ldtoken, type);
                il.Emit(OpCodes.Call, _getTypeFromHandle);
                il.Emit(OpCodes.Call, _getUninitializedObject);
                il.Emit(OpCodes.Castclass, type);

                // obj.CreateGCHandle(pointer);
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Callvirt, _createGCHandle);

                // obj.isWrapped = true;
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Stfld, _isWrapped);

                var parameterlessConstructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, Type.EmptyTypes);
                if (parameterlessConstructor != null)
                {
                    // obj..ctor();
                    il.Emit(OpCodes.Dup);
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Callvirt, parameterlessConstructor);
                }
            }

            il.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate<Func<IntPtr, T>>();
        }

        public static Func<IntPtr, T> Initializer => _initializer ??= Create();
    }

    public static class Unrestricted
    {
        public static T UnrestrictedCast<T>(this Il2CppObjectBase obj)
        {
            return Cast<T>(obj);
        }
        public static T Cast<T>(Il2CppObjectBase obj)
        {
            var ownClass = IL2CPP.il2cpp_object_get_class(obj.Pointer);
            if (RuntimeSpecificsStore.IsInjected(ownClass))
            {
                if (ClassInjectorBase.GetMonoObjectFromIl2CppPointer(obj.Pointer) is T monoObject)
                {
                    return monoObject;
                }
            }

            return InitializerStore<T>.Initializer(obj.Pointer);
        }
    }
}
