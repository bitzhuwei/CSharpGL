using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.ToLegacyOpenGL.ChunkDumpers
{
    public static partial class ChunkDumper
    {
        public static void Dump(this SmoothingGroupListChunk chunk, ThreeDSModel4LegacyOpenGL model,ThreeDSMesh4LegacyOpenGL mesh)
        {
            // nothing to do.
        }
    }
}
