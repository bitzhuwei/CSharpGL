using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class FramesChunk : ChunkBase
    {
        public uint StartFrame;
        public uint EndFrame;

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            chunk.StartFrame = reader.ReadUInt32();
            chunk.EndFrame = reader.ReadUInt32();

            chunk.BytesRead += 4 + 4;

            this.SkipRemainingPart(context);
        }

        public override string ToString()
        {
            return string.Format("{0}, StartFrame: {1}, EndFrame: {2}",
                this.GetBasicInfo(), this.StartFrame, this.EndFrame);
        }
    }
}
