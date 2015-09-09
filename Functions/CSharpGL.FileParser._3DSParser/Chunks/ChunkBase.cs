using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class ChunkBase
    {
        //public ushort ID;
        public uint Length;
        public int BytesRead;

        public override string ToString()
        {
            {
                return string.Format("type: {0}, length: {1}, read bytes: {2}", this.GetType().Name, Length, BytesRead);
            }
            //return base.ToString();
        }

        //public abstract ushort GetChunkType();
    }
}
