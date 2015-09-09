using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class UndefinedChunk : ChunkBase
    {
        //public override ushort GetChunkType()
        //{
        //    return 0x4D4D; // Main Chunk
        //}
        public ushort ID;

        public override string ToString()
        {
            return string.Format("type: {0}, length: {1}, read bytes: {2}", (ThreeDSChunkType)ID, Length, BytesRead);
        }
    }
}
