using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    class MappingFilenameChunk : ChunkBase
    {
        public string TextureFilename;

        public override string ToString()
        {
            return string.Format("{0}, TextureFilename: {1}", this.GetBasicInfo(), this.TextureFilename);
        }

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            string name;
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

                name = builder.ToString();
            }

            this.TextureFilename = Path.Combine(context.base_dir, name);
        }
    }
}
