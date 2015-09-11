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
        public static void Dump(this KeyframeChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is MeshInformationBlockChunk)
                {
                    (item as MeshInformationBlockChunk).Dump(model);
                }
                else if(item is SpotLightInformationBlockChunk)
                {
                    (item as SpotLightInformationBlockChunk).Dump(model);
                }
                else if (item is FramesChunk)
                {
                    (item as FramesChunk).Dump(model);
                }
            }
        }
    }
}
