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
        public static void Dump(this LightChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is SpotlightChunk)
                {
                    (item as SpotlightChunk).Dump(model);
                }
            }
        }
    }
}
