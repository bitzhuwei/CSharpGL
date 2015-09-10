using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MatShininessChunk : PercentageChunk
    {
        public ushort Shininess { get { return this.percentage; } }
    }
}
