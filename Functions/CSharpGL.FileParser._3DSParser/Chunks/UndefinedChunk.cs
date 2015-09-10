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
            var chunk = this;
            var reader = context.reader;
            var parent = this.Parent;

            uint length = this.Length - this.BytesRead;

            //if ((parent != null) && (parent is TextureMapChunk))
            if ((parent != null))
            {
                var another = parent.Length - parent.BytesRead - this.BytesRead;
                length = Math.Min(length, another);
            }

            reader.ReadBytes((int)length);
            chunk.BytesRead += length;
            //while (chunk.BytesRead < chunk.Length)
            //{
            //    ChunkBase child = reader.ReadChunk();
            //    child.Parent = this;
            //    this.Childern.Add(child);

            //    child.Process(context);

            //    //chunk.BytesRead += child.BytesRead;
            //    chunk.BytesRead += child.Length;
            //    //Console.WriteLine ( "ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
            //}
        }
        //public override void Process(ParsingContext context)
        //{
        //    //SkipChunk(context);
        //    //
        //    var chunk = this;
        //    var reader = context.reader;

        //    while (chunk.BytesRead < chunk.Length)
        //    {
        //        ChunkBase child = reader.ReadChunk();
        //        child.Parent = this;
        //        this.Childern.Add(child);

        //        child.Process(context);

        //        chunk.BytesRead += child.BytesRead;
        //        //Console.WriteLine ( "ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
        //    }
        //    //
        //    //int length = (int)this.Length - this.BytesRead;
        //    //if (this.Parent != null)
        //    //{
        //    //    var parent = this.Parent;
        //    //    var maxSkip = (int)(parent.Length - parent.BytesRead - this.BytesRead);
        //    //    if (length > maxSkip)//Something wrong about 3ds file may happen here.
        //    //    {
        //    //        length = maxSkip;
        //    //    }
        //    //}
        //    //context.reader.ReadBytes(length);
        //    //this.BytesRead += length;
        //}

        public void Process(ParsingContext context, int maxSkip)
        {
            SkipChunk(context, maxSkip);
        }

        void SkipChunk(ParsingContext context, int maxSkip = -1)
        {
            uint length = this.Length - this.BytesRead;
            if (maxSkip != -1)
            {
                if (length > maxSkip)//Something wrong about 3ds file may happen here.
                {
                    length = (uint)maxSkip;
                }
            }
            context.reader.ReadBytes((int)length);
            this.BytesRead += length;
        }
    }
}
