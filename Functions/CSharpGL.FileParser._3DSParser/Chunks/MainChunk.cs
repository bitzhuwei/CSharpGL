using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MainChunk : ChunkBase
    {
        internal override void Process(ParsingContext context)
        {
            var chunk = this;
            var reader = context.reader;

            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();
                child.Parent = this;
                this.Childern.Add(child);

                child.Process(context);

                chunk.BytesRead += child.BytesRead;
            }
        }
    }
}
