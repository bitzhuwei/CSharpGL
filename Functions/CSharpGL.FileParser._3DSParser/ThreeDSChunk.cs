using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.FileParser._3DSParser
{
    /// <summary>
    /// *.3ds文件里的一个块
    /// </summary>
    public class ThreeDSChunk : IHasChunk
    {
        public ushort ID;
        public uint Length;
        public int BytesRead;

        public ThreeDSChunk(BinaryReader reader)
        {
            // 2 byte ID
            ID = reader.ReadUInt16();
            //Console.WriteLine ("ID: {0}", ID.ToString("x"));

            // 4 byte length
            Length = reader.ReadUInt32();
            //Console.WriteLine ("Length: {0}", Length);

            // = 6
            BytesRead = 6;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", (ThreeDSChunkType)ID, Length, BytesRead);
            //return base.ToString();
        }

        ThreeDSChunk IHasChunk.Chunk
        {
            get { return this; }
            set { throw new InvalidOperationException("This settor should never be invoked."); }
        }
    }
}
