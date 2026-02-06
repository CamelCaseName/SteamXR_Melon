using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine.SubsystemsImplementation;

namespace UnityEngine.XR.Management
{
    // Token: 0x02000007 RID: 7
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class XRLoaderHelper : XRLoader
    {
        public XRLoaderHelper() : base(ClassInjector.DerivedConstructorPointer<XRLoaderHelper>()) => ClassInjector.DerivedConstructorBody(this);
        public XRLoaderHelper(IntPtr ptr) : base(ptr) { }
        // Token: 0x06000021 RID: 33 RVA: 0x00002340 File Offset: 0x00000540
        [HideFromIl2Cpp]
        public override T GetLoadedSubsystem<T>()
        {
            Type subsystemType = typeof(T);
            IntegratedSubsystem subsystem;
            this.m_SubsystemInstanceMap.TryGetValue(subsystemType, out subsystem);
            return subsystem as T;
        }

        // Token: 0x06000022 RID: 34 RVA: 0x00002374 File Offset: 0x00000574
        [HideFromIl2Cpp]
        protected void StartSubsystem<T>() where T : IntegratedSubsystem
        {
            T subsystem = this.GetLoadedSubsystem<T>();
            if (subsystem != null)
            {
                subsystem.Start();
            }
        }

        // Token: 0x06000023 RID: 35 RVA: 0x0000239C File Offset: 0x0000059C
        [HideFromIl2Cpp]
        protected void StopSubsystem<T>() where T : IntegratedSubsystem
        {
            T subsystem = this.GetLoadedSubsystem<T>();
            if (subsystem != null)
            {
                subsystem.Stop();
            }
        }

        // Token: 0x06000024 RID: 36 RVA: 0x000023C4 File Offset: 0x000005C4
        [HideFromIl2Cpp]
        protected void DestroySubsystem<T>() where T : IntegratedSubsystem
        {
            T subsystem = this.GetLoadedSubsystem<T>();
            if (subsystem != null)
            {
                Type subsystemType = typeof(T);
                if (this.m_SubsystemInstanceMap.ContainsKey(subsystemType))
                {
                    this.m_SubsystemInstanceMap.Remove(subsystemType);
                }
                subsystem.Destroy();
            }
        }

        // Token: 0x06000025 RID: 37 RVA: 0x00002414 File Offset: 0x00000614
        [HideFromIl2Cpp]
        protected void CreateSubsystem<TDescriptorRestricted, TSubsystemRestricted>(Il2CppSystem.Collections.Generic.List<TDescriptorRestricted> descriptors, string id) where TDescriptorRestricted : IntegratedSubsystemDescriptor<TSubsystemRestricted> where TSubsystemRestricted : IntegratedSubsystem
        {
            if (descriptors == null)
            {
                throw new ArgumentNullException(nameof(descriptors));
            }

            GetSubsystemDescriptors(descriptors);
            if (descriptors.Count > 0)
            {
                foreach (TDescriptorRestricted descriptor in descriptors)
                {
                    IntegratedSubsystem subsys = null;
                    if (string.Compare(descriptor.id, id, true) == 0)
                    {
                        subsys = descriptor.Create();
                    }
                    if (subsys != null)
                    {
                        this.m_SubsystemInstanceMap[typeof(TSubsystemRestricted)] = subsys;
                        break;
                    }
                }
            }
        }
        public static void GetSubsystemDescriptors<TDescriptorRestricted>(Il2CppSystem.Collections.Generic.List<TDescriptorRestricted> descriptors) where TDescriptorRestricted : IntegratedSubsystemDescriptor
        {
            descriptors.Clear();
            AddDescriptorSubset(SubsystemDescriptorStore.s_IntegratedDescriptors, descriptors);
            AddDescriptorSubset(SubsystemDescriptorStore.s_StandaloneDescriptors, descriptors);
            AddDescriptorSubset(SubsystemDescriptorStore.s_DeprecatedDescriptors, descriptors);
        }

        public static void AddDescriptorSubset<TBaseTypeInList, TQueryType>(Il2CppSystem.Collections.Generic.List<TBaseTypeInList> copyFrom, Il2CppSystem.Collections.Generic.List<TQueryType> copyTo) where TBaseTypeInList : Il2CppSystem.Object where TQueryType : IntegratedSubsystemDescriptor
        {
            foreach (TBaseTypeInList t in copyFrom)
            {
                var maybe = t.TryCast<TQueryType>();
                if (maybe != null)
                {
                    //MelonLogger.Msg("added " + t.GetIl2CppType().Name + " as " + Il2CppType.Of<TQueryType>().Name);
                    copyTo.Add(maybe);
                }
                else
                {
                    //MelonLogger.Msg("could not cast " + t.GetIl2CppType().Name + " to " + Il2CppType.Of<TQueryType>().Name);
                }
            }
        }

        // Token: 0x06000028 RID: 40 RVA: 0x000024C6 File Offset: 0x000006C6
        //[HideFromIl2Cpp]
        public override bool Deinitialize()
        {
            this.m_SubsystemInstanceMap.Clear();
            return base.Deinitialize();
        }

        // Token: 0x0400000F RID: 15
        protected Dictionary<Type, IntegratedSubsystem> m_SubsystemInstanceMap = new Dictionary<Type, IntegratedSubsystem>();
    }
}
