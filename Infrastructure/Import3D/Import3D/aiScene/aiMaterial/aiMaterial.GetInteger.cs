
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        public aiReturn aiGetMaterialInteger(string pKey, int type, int index, int* pOut) {
            return this.aiGetMaterialIntegerArray(pKey, type, index, pOut, null);
        }
    }
}