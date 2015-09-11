using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.ToModernOpenGL.ChunkDumpers
{
    public static partial class ChunkDumper
    {
        public static void Dump(this SpecularColorChunk chunk, ThreeDSModel4ModernOpengl model, ThreeDSMaterial4ModernOpenGL material)
        {
            material.Specular = new float[] { chunk.R, chunk.G, chunk.B, };
        }
    }
}
