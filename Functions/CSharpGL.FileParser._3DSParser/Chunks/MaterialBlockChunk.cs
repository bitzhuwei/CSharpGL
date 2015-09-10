using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MaterialBlockChunk : ChunkBase
    {
        //public string MaterialName;
        //public ThreeDSMaterial Material;
        //public ColorChunk AmbientColorChunk;
        //public ColorChunk DiffuseColorChunk;
        //public ColorChunk SpecularColorChunk;
        //public PercentageChunk ShininessChunk;

        //internal override void Process(ParsingContext context)
        //{
        //    var reader = context.reader;
        //    var chunk = this;

        //    while (chunk.BytesRead < chunk.Length)
        //    {
        //        ChunkBase child = reader.ReadChunk();
        //        child.Parent = chunk;
        //        this.Childern.Add(child);

        //        child.Process(context);

        //        chunk.BytesRead += child.BytesRead;
        //    }
        //}
    }
}
