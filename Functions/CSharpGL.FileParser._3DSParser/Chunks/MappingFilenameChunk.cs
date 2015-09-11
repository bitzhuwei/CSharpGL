using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class MappingFilenameChunk : StringChunk
    {
        public string TextureFilename { get { return this.Content; } }

        public override string ToString()
        {
            return string.Format("{0}, TextureFilename: {1}", this.GetBasicInfo(), this.TextureFilename);
        }

    }
}
