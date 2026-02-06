using Il2CppInterop.Runtime.Injection;
using System;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace UnityEngine.XR.OpenXR
{
    // Token: 0x02000017 RID: 23
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRLoaderNoPreInit : OpenXRLoaderBase
    {
        public OpenXRLoaderNoPreInit() : base(ClassInjector.DerivedConstructorPointer<OpenXRLoaderNoPreInit>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRLoaderNoPreInit(IntPtr ptr) : base(ptr) { }
    }
}
