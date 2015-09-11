using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class FacesMaterialChunk : ChunkBase
    {
        public string UsesMaterial;

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            {
                StringBuilder builder = new StringBuilder();

                byte b = reader.ReadByte();
                uint idx = 0;
                while (b != 0)
                {
                    builder.Append((char)b);
                    b = reader.ReadByte();
                    idx++;
                }
                chunk.BytesRead += idx + 1;

                this.UsesMaterial = builder.ToString();
            }

            {
                uint length = chunk.Length - chunk.BytesRead;
                reader.BaseStream.Position += length;
                chunk.BytesRead += length;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, UsesMaterial: {1}", this.GetBasicInfo(), UsesMaterial);
        }
    }
}
