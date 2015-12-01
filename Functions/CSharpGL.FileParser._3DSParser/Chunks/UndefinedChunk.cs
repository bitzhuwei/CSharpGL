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
            return string.Format("{0}(0x{1:X4}), position: {2}, length: {3}, read bytes: {4}",
                this.IsChunk ? "Unknown" : "Fake Chunk", ID, Position, Length, BytesRead);
        }

        internal override void Process(ParsingContext context)
        {
            this.SkipRemainingPart(context);

            var chunk = this;

            if (chunk.Length != chunk.BytesRead)
            {
                chunk.Length = chunk.BytesRead;
                this.IsChunk = false;
            }

        }

    }
}
