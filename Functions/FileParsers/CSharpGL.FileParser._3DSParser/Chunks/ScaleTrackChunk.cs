using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class ScaleTrackChunk : ChunkBase
    {
        internal override void Process(ParsingContext context)
        {
            this.SkipRemainingPart(context);
        }
    }
}
