using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    /// <summary>
    /// 3ds文件有上千种Chunk，我们暂时不会都解析出来（也没必要全解析出来）。所以我们用一个“未定义的Chunk”类型来代表那些我们不想解析的Chunk类型。
    /// </summary>
    public class UndefinedChunk : ChunkBase
    {
        public ushort ID;
        public bool IsChunk { get; private set; }

        public UndefinedChunk()
        {
            this.IsChunk = true;
        }

        public override string ToString()
        {
            return string.Format("{3}(0x{0:X4}), length: {1}, read bytes: {2}", ID, Length, BytesRead,
                this.IsChunk ? "Unknown Chunk" : "Fake Chunk");
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

            reader.BaseStream.Position += length;
            chunk.BytesRead += length;
            if (chunk.Length != chunk.BytesRead)
            {
                chunk.Length = chunk.BytesRead;
                this.IsChunk = false;
            }
        }

    }
}
