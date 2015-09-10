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
            return string.Format("type: {0}, length: {1}, read bytes: {2}", (ThreeDSChunkType)ID, Length, BytesRead);
        }

        public override void Process(ParsingContext context)
        {
            //SkipChunk(context);
            int length = (int)this.Length - this.BytesRead;
            if (this.Parent != null)
            {
                var parent = this.Parent;
                var maxSkip = (int)(parent.Length - parent.BytesRead - this.BytesRead);
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = maxSkip;
                }
            }
            context.reader.ReadBytes(length);
            this.BytesRead += length;
        }

        public void Process(ParsingContext context, int maxSkip)
        {
            SkipChunk(context, maxSkip);
        }

        void SkipChunk(ParsingContext context, int maxSkip = -1)
        {
            int length = (int)this.Length - this.BytesRead;
            if (maxSkip != -1)
            {
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = maxSkip;
                }
            }
            context.reader.ReadBytes(length);
            this.BytesRead += length;
        }
    }
}
