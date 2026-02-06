using Il2CppInterop.Runtime.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.XR.Management
{
    // Token: 0x02000006 RID: 6
    [MelonLoader.RegisterTypeInIl2Cpp(true)]
    public class XRLoader : ScriptableObject
    {
        public XRLoader(IntPtr ptr) : base(ptr) { }
        // Token: 0x0600001A RID: 26 RVA: 0x0000232B File Offset: 0x0000052B
        public virtual bool Initialize()
        {
            return true;
        }

        // Token: 0x0600001B RID: 27 RVA: 0x0000232B File Offset: 0x0000052B
        public virtual bool Start()
        {
            return true;
        }

        // Token: 0x0600001C RID: 28 RVA: 0x0000232B File Offset: 0x0000052B
        public virtual bool Stop()
        {
            return true;
        }

        // Token: 0x0600001D RID: 29 RVA: 0x0000232B File Offset: 0x0000052B
        public virtual bool Deinitialize()
        {
            return true;
        }

        // Token: 0x0600001E RID: 30
        [HideFromIl2Cpp]
        public virtual T GetLoadedSubsystem<T>() where T : IntegratedSubsystem { return null; }

        // Token: 0x0600001F RID: 31 RVA: 0x0000232E File Offset: 0x0000052E
        [HideFromIl2Cpp]
        public virtual List<GraphicsDeviceType> GetSupportedGraphicsDeviceTypes(bool buildingPlayer)
        {
            return new List<GraphicsDeviceType>();
        }
    }
}
