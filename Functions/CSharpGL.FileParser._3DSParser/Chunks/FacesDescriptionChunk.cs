using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    class FacesDescriptionChunk : ChunkBase
    {
        public Triangle[] triangleIndexes;

        public override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            ushort numIdcs = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Console.WriteLine("	Indices: {0}", numIdcs);
            Triangle[] indexes = new Triangle[numIdcs];

            for (int ii = 0; ii < indexes.Length; ii++)
            {
                indexes[ii] = new Triangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());

                // flags
                reader.ReadUInt16();
            }
            chunk.BytesRead += (uint)((2 * 4) * indexes.Length);
            //SkipChunk ( chunk );

            this.triangleIndexes = indexes;
        }
    }
}
