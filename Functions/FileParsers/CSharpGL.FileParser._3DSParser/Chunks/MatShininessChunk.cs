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

            /*
SHI_PER 0x0030 
0x0030：字格式的百分比。
父chunk：任何可能的chunk
子chunk：无
长度：头长度+内容长度
内容：
百分比（一个字0~100）
             */
            var child = reader.ReadChunk();
            this.percentage = reader.ReadUInt16();
            child.BytesRead += 2;

            chunk.BytesRead += child.BytesRead;
        }

        public override string ToString()
        {
            return string.Format("{0}, Shininess: {1}", this.GetBasicInfo(), Shininess);
        }
    }
}
