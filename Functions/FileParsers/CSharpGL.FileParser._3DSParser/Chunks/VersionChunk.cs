using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public class VersionChunk : ChunkBase
    {
        /// <summary>
        /// 3DS File Version
        /// </summary>
        public int Version;

        internal override void Process(ParsingContext context)
        {
            var reader = context.reader;

            int version = reader.ReadInt32();

            this.Version = version;
            this.BytesRead += 4;
        }

        public override string ToString()
        {
            return string.Format("{0}, Version: {1}", this.GetBasicInfo(), Version);
        }
    }
}
