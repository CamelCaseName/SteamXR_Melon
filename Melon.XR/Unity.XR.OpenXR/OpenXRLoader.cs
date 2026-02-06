using Il2CppInterop.Runtime.Injection;
using System;
using UnityEngine.XR.OpenXR.Features.Interactions;

namespace UnityEngine.XR.OpenXR
{
    // Token: 0x02000011 RID: 17
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRLoader : OpenXRLoaderBase
    {
        public OpenXRLoader() : base(ClassInjector.DerivedConstructorPointer<OpenXRLoader>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRLoader(IntPtr ptr) : base(ptr) { }
    }
}
