using Il2CppInterop.Runtime.Injection;
using System;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

namespace UnityEngine.XR.OpenXR.Input
{
	// Token: 0x02000037 RID: 55
	//[Preserve]
	[MelonLoader.RegisterTypeInIl2Cpp(true)]
	public class HapticControl : InputControl
    {
        public HapticControl(IntPtr ptr) : base(ptr) { }
        // Token: 0x060000F4 RID: 244 RVA: 0x000040DE File Offset: 0x000022DE
        public HapticControl() : base(ClassInjector.DerivedConstructorPointer<HapticControl>())
        {
            ClassInjector.DerivedConstructorBody(this);
            Unsafe.AsRef(this.m_StateBlock).sizeInBits = 1U;
            Unsafe.AsRef(this.m_StateBlock).bitOffset = 0U;
            Unsafe.AsRef(this.m_StateBlock).byteOffset = 0U;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000410C File Offset: 0x0000230C
		public unsafe Haptic ReadUnprocessedValueFromState(void* statePtr)
		{
			return default(Haptic);
		}
	}
}
