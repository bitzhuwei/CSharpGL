using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    class SmoothingGroupListChunk : ChunkBase
    {
        internal override void Process(ParsingContext context)
        {
            var chunk = this;
            var reader = context.reader;
            var parent = this.Parent;

            uint length = this.Length - this.BytesRead;

            if ((parent != null))
            {
                var another = parent.Length - parent.BytesRead - this.BytesRead;
                length = Math.Min(length, another);
            }

            reader.ReadBytes((int)length);
            chunk.BytesRead += length;
        }
    }
}
