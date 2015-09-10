using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    class VerticesListChunk : ChunkBase
    {
        Vector[] vertexes;

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            ushort numVerts = reader.ReadUInt16();
            chunk.BytesRead += 2;
            Console.WriteLine("	Vertices: {0}", numVerts);
            Vector[] vertexes = new Vector[numVerts];

            for (int ii = 0; ii < vertexes.Length; ii++)
            {
                float f1 = reader.ReadSingle();
                float f2 = reader.ReadSingle();
                float f3 = reader.ReadSingle();

                vertexes[ii] = new Vector(f1, f3, -f2);
            }

            chunk.BytesRead += (uint)(vertexes.Length * (3 * 4));
            //SkipChunk ( chunk );

            this.vertexes = vertexes;
        }
    }
}
