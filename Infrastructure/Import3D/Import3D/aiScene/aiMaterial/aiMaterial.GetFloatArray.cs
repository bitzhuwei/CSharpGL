
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        // Get an array of floating-point values from the material.
        public aiReturn aiGetMaterialFloatArray(string pKey, int type, int index, float* pOut, int* pMax) {
            Debug.Assert(pOut != null);

            aiMaterialProperty? prop;
            this.aiGetMaterialProperty(pKey, type, index, out prop);
            if (null == prop) {
                return aiReturn.aiReturn_FAILURE;
            }

            // data is given in floats, convert to ai_real
            int iWrite = 0;
            if (aiPropertyTypeInfo.aiPTI_Float == prop.mType || aiPropertyTypeInfo.aiPTI_Buffer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(float);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }

                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(prop.mData)[a];
                }

                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in doubles, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Double == prop.mType) {
                iWrite = prop.mDataLength / sizeof(double);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(double)(prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // data is given in ints, convert to float
            else if (aiPropertyTypeInfo.aiPTI_Integer == prop.mType) {
                iWrite = prop.mDataLength / sizeof(Int32);
                if (pMax != null) {
                    iWrite = Math.Min(*pMax, iWrite);
                    ;
                }
                for (var a = 0; a < iWrite; ++a) {
                    pOut[a] = (float)(Int32)(prop.mData)[a];
                }
                if (pMax != null) {
                    *pMax = iWrite;
                }
            }
            // a string ... read floats separated by spaces
            else {
                if (pMax != null) {
                    iWrite = *pMax;
                }
                // strings are zero-terminated with a 32 bit length prefix, so this is safe
                var cur = prop.mData + 4;
                Debug.Assert(prop.mDataLength >= 5);
                Debug.Assert(prop.mData[prop.mDataLength - 1] == 0);
                for (var a = 0; ; ++a) {
                    cur = fast_atoreal_move(cur, pOut[a]);
                    if (a == iWrite - 1) {
                        break;
                    }
                    if (!IsSpace(*cur)) {
                        Import3D.Log.WriteLine("Material property pKey is a string; failed to parse a float array out of it.");
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