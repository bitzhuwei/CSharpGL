using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class ChunkBase
    {
        public ChunkBase Parent;
        public List<ChunkBase> Childern;

        public uint Length;
        public uint BytesRead;

        public ChunkBase()
        {
            this.Childern = new List<ChunkBase>();
        }

        protected string GetBasicInfo()
        {
            return string.Format("{0}(0x{3:X4}), length: {1}, read bytes: {2}",
                this.GetType().Name, Length, BytesRead, this.GetID());
        }

        public override string ToString()
        {
            return GetBasicInfo();
        }

        internal virtual void Process(ParsingContext context)
        {
            var chunk = this;
            var reader = context.reader;

            while (chunk.BytesRead + ChunkBaseHelper.HeaderLength < chunk.Length)//如果还能读出一个子chunk。
            {
                ChunkBase child = reader.ReadChunk();
                child.Parent = this;
                this.Childern.Add(child);

                child.Process(context);

                chunk.BytesRead += child.BytesRead;
            }

            {
                var parent = this.Parent;

                uint length = this.Length - this.BytesRead;
                if (length > 0)
                {
                    if ((parent != null))
                    {
                        var another = parent.Length - parent.BytesRead - this.BytesRead;
                        length = Math.Min(length, another);
                    }

                    reader.BaseStream.Position += length;
                    chunk.BytesRead += length;
                }
            }
        }


    }
}
