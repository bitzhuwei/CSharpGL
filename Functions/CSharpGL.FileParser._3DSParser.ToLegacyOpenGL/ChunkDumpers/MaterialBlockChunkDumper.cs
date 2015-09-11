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
        public static void Dump(this MaterialBlockChunk chunk, ThreeDSModel model)
        {
            foreach (var item in chunk.Children)
            {
                if(item is MaterialNameChunk)
                {
                    (item as MaterialNameChunk).Dump(model);
                }
                else if(item is AmbientColorChunk)
                {
                    (item as AmbientColorChunk).Dump(model);
                }
                else if (item is DiffuseColorChunk)
                {
                    (item as DiffuseColorChunk).Dump(model);
                }
                else if(item is SpecularColorChunk)
                {
                    (item as SpecularColorChunk).Dump(model);
                }
                else if(item is TextureMapChunk)
                {
                    (item as TextureMapChunk).Dump(model);
                }
                else if(item is BumpMapChunk)
                {
                    (item as BumpMapChunk).Dump(model);
                }
                else if(item is ReflectionMapChunk)
                {
                    (item as ReflectionMapChunk).Dump(model);
                }
            }
        }
    }
}
