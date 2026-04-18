
using Il2CppInterop.Runtime.Injection;
using System;
using UnityEngine.XR.OpenXR.Il2CppShenanigans;

namespace UnityEngine.XR.OpenXR.Input
{
    // Token: 0x02000038 RID: 56
    //[Preserve]
    [InputControlLayout(displayName = "OpenXR Action Map")]
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class OpenXRDevice : InputSystem.InputDevice
    {
        public OpenXRDevice() : base(ClassInjector.DerivedConstructorPointer<OpenXRDevice>()) => ClassInjector.DerivedConstructorBody(this);
        public OpenXRDevice(IntPtr ptr) : base(ptr) { }
        // Token: 0x060000F6 RID: 246 RVA: 0x00004124 File Offset: 0x00002324
        public override void FinishSetup()
        {
            base.FinishSetup();
            XRDeviceDescriptor deviceDescriptor = XRDeviceDescriptor.FromJson(base.description.capabilities);
            if (deviceDescriptor != null)
            {
                if ((deviceDescriptor.characteristics & InputDeviceCharacteristics.Left) != InputDeviceCharacteristics.None)
                {
                    //InputSystem.InputSystem.SetDeviceUsage(this, CommonUsages.LeftHand);
                    return;
                }
                if ((deviceDescriptor.characteristics & InputDeviceCharacteristics.Right) != InputDeviceCharacteristics.None)
                {
                    //InputSystem.InputSystem.SetDeviceUsage(this, CommonUsages.RightHand);
                }
            }
        }
    }
}
