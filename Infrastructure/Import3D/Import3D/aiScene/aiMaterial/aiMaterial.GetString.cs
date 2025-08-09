
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        // Get a string from the material
        private static aiReturn aiGetMaterialString(aiMaterial material, string pKey, int type, int index, out string? pOut) {
            pOut = null;
            aiMaterialProperty? prop;
            material.aiGetMaterialProperty(pKey, (int)type, index, out prop);
            if (prop == null) {
                return aiReturn.aiReturn_FAILURE;
            }

            if (aiPropertyTypeInfo.aiPTI_String == prop.mType) {
                Debug.Assert(prop.mDataLength >= 5);

                // The string is stored as 32 but length prefix followed by zero-terminated UTF8 data
                //pOut.length = static_cast < unsigned int> (*reinterpret_cast<uint32_t*>(prop.mData));

                //ai_assert(pOut.length + 1 + 4 == prop.mDataLength);
                //ai_assert(!prop.mData[prop.mDataLength - 1]);
                //memcpy(pOut.data, prop.mData + 4, pOut.length + 1);
                pOut = Marshal.PtrToStringAnsi((IntPtr)prop.mData);
            }
            else {
                // TODO - implement lexical cast as well
                Import3D.Log.WriteLine("Material property pKey was found, but is no string");
                return aiReturn.aiReturn_FAILURE;
            }
            return aiReturn.aiReturn_SUCCESS;
        }
    }
}