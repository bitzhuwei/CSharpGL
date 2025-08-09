
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        // Get a specific property from a material
        public aiReturn aiGetMaterialProperty(string pKey, int type, int index, out aiMaterialProperty? pPropOut) {
            Debug.Assert(pKey != null);

            /*  Just search for a property with exactly this name ..
             *  could be improved by hashing, but it's possibly
             *  no worth the effort (we're bound to C structures,
             *  thus std::map or derivates are not applicable. */
            for (var i = 0; i < this.mNumProperties; ++i) {
                var prop = this.mProperties[i];

                if (prop != null /* just for safety ... */
                 && prop.mKey.StartsWith(pKey)
                 && (int.MaxValue == type || prop.mSemantic == type) /* UINT_MAX is a wild-card, but this is undocumented :-) */
                        && (int.MaxValue == index || prop.mIndex == index)) {
                    pPropOut = this.mProperties[i];
                    return aiReturn.aiReturn_SUCCESS;
                }
            }
            pPropOut = null;
            return aiReturn.aiReturn_FAILURE;
        }
    }
}