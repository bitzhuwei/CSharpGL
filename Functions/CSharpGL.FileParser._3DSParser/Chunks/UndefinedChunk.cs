using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class UndefinedChunk : ChunkBase
    {
        public ushort ID;

        public override string ToString()
        {
            return string.Format("0x{0:X4}, length: {1}, read bytes: {2}", ID, Length, BytesRead);
        }

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
