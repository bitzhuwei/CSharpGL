
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

    }
}