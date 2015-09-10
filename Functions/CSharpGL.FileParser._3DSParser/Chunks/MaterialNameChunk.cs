using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MaterialNameChunk : StringChunk
    {
        public string MaterialName { get { return this.Content; } }
    }
}
