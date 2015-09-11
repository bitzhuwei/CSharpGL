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
        public static void Dump(this _3DEditorChunk chunk, ThreeDSModel4LegacyOpenGL model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is ObjectBlockChunk)
                {
                    (item as ObjectBlockChunk).Dump(model);
                }
                else if(item is MaterialBlockChunk)
                {
                    (item as MaterialBlockChunk).Dump(model);
                }
            }
        }
    }
}
