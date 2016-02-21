using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public abstract class ChunkBase : ITreeNode, ICloneable
    {
        public ChunkBase Parent;
        public List<ChunkBase> Children;

        /// <summary>
        /// 此chunk的长度（字节数）
        /// </summary>
        public uint Length;

        /// <summary>
        /// 此chunk已经读了多少
        /// </summary>
        public uint BytesRead;

        /// <summary>
        /// 此chunk在文件中的位置。
        /// </summary>
        public long Position { get; internal set; }

        public ChunkBase()
        {
            this.Children = new List<ChunkBase>();
        }

        protected string GetBasicInfo()
        {
            return string.Format("[{0}(0x{1:X4}), position: {2}, length: {3}, read bytes: {4}]",
                this.GetType().Name, this.GetID(), this.Position, Length, BytesRead);
        }

        public override string ToString()
        {
            return GetBasicInfo();
        }

        internal virtual void Process(ParsingContext context)
        {
            ChunkBaseProcess(context);
        }

        internal void ChunkBaseProcess(ParsingContext context)
        {
            var chunk = this;
            var reader = context.reader;

            while (chunk.BytesRead + ChunkBaseHelper.HeaderLength < chunk.Length)//如果还能读出一个子chunk。
            {
                ChunkBase child = reader.ReadChunk();
                child.Parent = this;
                this.Children.Add(child);

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

        internal void SkipRemainingPart(ParsingContext context)
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
        }

        ITreeNode ITreeNode.Parent
        {
            get { return this.Parent; }
        }

        IList<ITreeNode> ITreeNode.Children
        {
            get
            {
                IList<ITreeNode> result = new List<ITreeNode>(this.Children.Count);
                foreach (var item in this.Children)
                {
                    result.Add(item);
                }

                return result;
            }
        }

        object ICloneable.Clone()
        {
            var result = this.MemberwiseClone() as ChunkBase;
            result.Parent = null;
            result.Children = new List<ChunkBase>();

            return result;
        }
    }
}
