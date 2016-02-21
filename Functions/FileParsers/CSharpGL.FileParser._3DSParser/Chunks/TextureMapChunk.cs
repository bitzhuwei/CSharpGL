using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class TextureMapChunk : ChunkBase
    {
        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            {
                var child = reader.ReadChunk();
                int per = reader.ReadUInt16();
                child.BytesRead += 2;
                chunk.BytesRead += child.BytesRead;
            }

            this.ChunkBaseProcess(context);
        }
    }
}
