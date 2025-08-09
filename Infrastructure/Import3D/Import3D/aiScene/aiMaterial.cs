
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    public unsafe partial class aiMaterial {
        public const int DefaultNumAllocated = 5;

        /// <summary>List of all material properties loaded.</summary>
        public aiMaterialProperty[] mProperties = new aiMaterialProperty[DefaultNumAllocated];

        /// <summary>Number of properties in the data base</summary>
        public uint mNumProperties;

        /// <summary>Storage allocated</summary>
        public uint mNumAllocated = DefaultNumAllocated;

        public aiMaterial() {
        }



        /** @brief Retrieve a single float property with a specific key from the material.
        *
        * Pass one of the AI_MATKEY_XXX constants for the last three parameters (the
        * example reads the #AI_MATKEY_SHININESS_STRENGTH property of the first diffuse texture)
        * @code
        * float specStrength = 1.f; // default value, remains unmodified if we fail.
        * aiGetMaterialFloat(mat, AI_MATKEY_SHININESS_STRENGTH,
        *    (float*)&specStrength);
        * @endcode
        *
        * @param pMat Pointer to the input material. May not be NULL
        * @param pKey Key to search for. One of the AI_MATKEY_XXX constants.
        * @param pOut Receives the output float.
        * @param type (see the code sample above)
        * @param index (see the code sample above)
        * @return Specifies whether the key has been found. If not, the output
        *   float remains unmodified.*/
        // ---------------------------------------------------------------------------
        public aiReturn aiGetMaterialFloat(string pKey, int type, int index, float* pOut) {
            return this.aiGetMaterialFloatArray(pKey, type, index, pOut, null);
        }

        public aiReturn aiGetMaterialInteger(string pKey, int type, int index, int* pOut) {
            return this.aiGetMaterialIntegerArray(pKey, type, index, pOut, null);
        }

    }
}