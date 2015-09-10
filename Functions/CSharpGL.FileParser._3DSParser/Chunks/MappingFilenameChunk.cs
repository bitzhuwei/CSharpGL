using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    class MappingFilenameChunk : PercentageChunk
    {
        public ushort Useless { get { return this.percentage; } }

        public override string ToString()
        {
            return string.Format("{0}, Useless: {1}", base.ToString(), this.Useless);
        }
    }
}
