using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class PercentageChunk : ChunkBase
    {
        protected ushort percentage;

        public override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var child = reader.ReadChunk();
            this.percentage = reader.ReadUInt16();
            child.BytesRead += 2;

            this.BytesRead += child.BytesRead;
        }
    }
}
