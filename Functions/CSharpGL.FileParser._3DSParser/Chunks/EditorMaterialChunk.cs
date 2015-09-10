using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class EditorMaterialChunk : ChunkBase
    {
        //public string MaterialName;
        //public ThreeDSMaterial Material;
        //public ColorChunk AmbientColorChunk;
        //public ColorChunk DiffuseColorChunk;
        //public ColorChunk SpecularColorChunk;
        //public PercentageChunk ShininessChunk;

        public override void Process(ParsingContext context)
        {
            ProcessMaterialChunk(context);
        }

        void ProcessMaterialChunk(ParsingContext context)
        {
            var reader = context.reader;
            var chunk = this;

            //this.MaterialName = string.Empty;
            //ThreeDSMaterial m = new ThreeDSMaterial();

            while (chunk.BytesRead < chunk.Length)
            {
                ChunkBase child = reader.ReadChunk();
                child.Process(context);
                child.Parent = chunk;
                this.Childern.Add(child);

                chunk.BytesRead += child.BytesRead;
            }

            //this.Material = m;
        }
    }
}
