using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MatShininessChunk : PercentageChunk
    {
        public ushort Shininess { get { return this.percentage; } }

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            var child = reader.ReadChunk();
            this.percentage = reader.ReadUInt16();
            child.BytesRead += 2;

            chunk.BytesRead += child.BytesRead;
        }
    }
}
