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
        public static void Dump(this ReflectionMapChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is MappingFilenameChunk)
                {
                    (item as MappingFilenameChunk).Dump(model);
                }
                else if(item is MappingParametersChunk)
                {
                    (item as MappingParametersChunk).Dump(model);
                }
            }
        }
    }
}
