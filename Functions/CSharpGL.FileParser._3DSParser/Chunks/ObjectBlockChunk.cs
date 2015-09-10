using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class ObjectBlockChunk : ChunkBase
    {
        public StringChunk ObjectName;
        public ThreeDSMesh Mesh;

        public override void Process(ParsingContext context)
        {
            base.Process(context);
            // todo:
        }
    }
}
