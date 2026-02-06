using System;
using System.Collections.Generic;
using UnityEngine.InputSystem.XR;

namespace UnityEngine.XR.OpenXR
{
    [Serializable]
    public class XRDeviceDescriptor : Il2CppSystem.Object
    {
        // Token: 0x06000C5B RID: 3163 RVA: 0x0003FDDF File Offset: 0x0003DFDF
        public string ToJson()
        {
            return UnityEngine.JsonUtility.ToJson(this);
        }

        // Token: 0x06000C5C RID: 3164 RVA: 0x0003FDE7 File Offset: 0x0003DFE7
        public static XRDeviceDescriptor FromJson(string json)
        {
            return JsonUtility.FromJson<XRDeviceDescriptor>(json);
        }

        // Token: 0x0400059B RID: 1435
        public string deviceName;

        // Token: 0x0400059C RID: 1436
        public string manufacturer;

        // Token: 0x0400059D RID: 1437
        public string serialNumber;

        // Token: 0x0400059E RID: 1438
        public InputDeviceCharacteristics characteristics;

        // Token: 0x0400059F RID: 1439
        public int deviceId;

        // Token: 0x040005A0 RID: 1440
        public List<XRFeatureDescriptor> inputFeatures;
    }
}
