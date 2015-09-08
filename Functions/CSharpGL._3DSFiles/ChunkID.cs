using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL._3DSFiles
{
    class ChunkID
    {
        public const UInt16 MAIN_CHUNK = 0x4D4D;
        public const UInt16 _3D_EDITOR_CHUNK = 0x3D3D;
        public const UInt16 OBJECT_BLOCK = 0x4000;
        public const UInt16 TRIANGULAR_MESH = 0x4100;
        public const UInt16 VERTICES_LIST = 0x4110;
        public const UInt16 FACES_DESCRIPTION = 0x4120;
        public const UInt16 MAPPING_COORDINATES_LIST = 0x4140;
    }
}
