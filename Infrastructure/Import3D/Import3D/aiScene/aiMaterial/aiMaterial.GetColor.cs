
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        public aiReturn aiGetMaterialColor(string key, int type, int index, Import3D.vec4* pOut) {
            int iMax = 4;
            aiReturn eRet = this.aiGetMaterialFloatArray(key, type, index, (float*)pOut, &iMax);

            // if no alpha channel is defined: set it to 1.0
            if (3 == iMax) {
                pOut->w = 1.0f;
            }

            return eRet;

        }
    }
}