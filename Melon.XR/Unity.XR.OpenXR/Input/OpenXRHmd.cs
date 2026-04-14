using Il2CppInterop.Runtime.Injection;
using System;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Il2CppShenanigans;

namespace UnityEngine.XR.OpenXR.Input
{
    // Token: 0x02000039 RID: 57
    //[Preserve]
    [InputControlLayout(displayName = "OpenXR HMD")]
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    internal class OpenXRHmd : XRHMD
    {
        int i = 0;
        public OpenXRHmd() : base(ClassInjector.DerivedConstructorPointer<OpenXRHmd>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRHmd(IntPtr ptr) : base(ptr) { }
        // Token: 0x17000028 RID: 40
        // (get) Token: 0x060000F8 RID: 248 RVA: 0x00004189 File Offset: 0x00002389
        // (set) Token: 0x060000F9 RID: 249 RVA: 0x00004191 File Offset: 0x00002391
        //[Preserve]
        [InputControl]
        //private Il2CppReferenceField<ButtonControl> userPresence;
        private ButtonControl userPresence;

        // Token: 0x060000FA RID: 250 RVA: 0x0000419A File Offset: 0x0000239A
        public override void FinishSetup()
        {
            if (i == 0)
            {
                i++;
                base.FinishSetup();
            }

            this.userPresence = base.GetChildControl<ButtonControl>("UserPresence");
        }
    }
}
