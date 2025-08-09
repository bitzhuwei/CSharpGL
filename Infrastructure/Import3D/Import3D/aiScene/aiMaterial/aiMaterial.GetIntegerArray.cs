
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        public aiReturn aiGetMaterialIntegerArray(string pKey, int type, int index, int* pOut, int* pMax) {
            Debug.Assert(pOut != null);

            aiMaterialProperty? prop;
            this.aiGetMaterialProperty(pKey, type, index, out prop);
            if (prop == null) {
                return aiReturn.aiReturn_FAILURE;
            }

            // data is given in ints, simply copy it
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = Math.Max((prop.mDataLength / sizeof(Int32)), 1);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                }
                if (1 == prop.mDataLength) {
                    // bool type, 1 byte
                    *pOut = (int)(*prop.mData);
                }
                else {
                    var array = (int*)(prop.mData);
                    for (var a = 0; a < iWrite; ++a) {
                        var element = array[a];
                        pOut[a] = element;
                    }
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in floats convert to int
            else if (aiPropertyTypeInfo.aiPTI_Float == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                var array = (float*)(prop.mData);
                for (var a = 0; a < iWrite; ++a) {
                    var element = array[a];
                    pOut[a] = (int)element;
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // it is a string ... no way to read something out of this
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(0 != prop.mData[prop.mDataLength - 1]);
                for (var a = 0; ; ++a) {
                    pOut[a] = strtol10(cur, &cur);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!IsSpace(*cur)) {
                        Log.WriteLine($"Material property {pKey} is a string; failed to parse an integer array out of it.");
                        return aiReturn.aiReturn_FAILURE;
                    }
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            return aiReturn.aiReturn_SUCCESS;

        }
    }
}