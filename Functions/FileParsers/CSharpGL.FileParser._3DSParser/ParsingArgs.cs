using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.FileParser._3DSParser
{
    public class ParsingArgs : EventArgs
    {
        public ParsingArgs(ThreeDSChunk chunk)
        {
            this.Chunk = chunk;
        }

        public ThreeDSChunk Chunk { get; set; }

        public override string ToString()
        {
            return string.Format("args: {0}", this.Chunk);
            //return base.ToString();
        }
    }
}
