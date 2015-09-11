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
        public static void Dump(this MappingFilenameChunk chunk, ThreeDSModel4LegacyOpenGL model, ThreeDSMaterial4LegacyOpenGL material)
        {
            material.TextureFilename = chunk.TextureFilename;
        }
    }
}
