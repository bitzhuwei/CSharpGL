using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class PercentageChunk : ChunkBase
    {
        protected ushort percentage;

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;

            this.percentage = reader.ReadUInt16();

            this.BytesRead += 2;
        }

        public override string ToString()
        {
            return string.Format("{0}, percentage: {1}", base.ToString(), this.percentage);
        }
    }
}
