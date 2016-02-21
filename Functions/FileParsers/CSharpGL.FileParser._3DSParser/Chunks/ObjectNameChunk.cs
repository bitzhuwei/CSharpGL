using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class ObjectNameChunk : StringChunk
    {
        public string Name { get { return this.Content; } }

        public override string ToString()
        {
            return string.Format("{0}, Object Name: {1}", this.GetBasicInfo(), Name);
        }

        internal override void Process(ParsingContext context)
        {
            this.StringChunkProcess(context);

            this.ChunkBaseProcess(context);
        }
    }
}
