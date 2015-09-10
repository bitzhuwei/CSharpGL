using CSharpGL.FileParser._3DSParser.Chunks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser
{
    /// <summary>
    /// *.3ds文件解析器。
    /// </summary>
    public partial class ThreeDSParser
    {

        /// <summary>
        /// 逐步解析*.3ds文件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_3dsFilename"></param>
        /// <returns></returns>
        public MainChunk Parse(string _3dsFilename)
        {
            var base_dir = new FileInfo(_3dsFilename).DirectoryName + "/";
            var file = new FileStream(_3dsFilename, FileMode.Open, FileAccess.Read);
            var reader = new BinaryReader(file);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            var context = new ParsingContext() { base_dir = base_dir, file = file, reader = reader, };

            ChunkBase chunk = reader.ReadChunk();
            //if (chunk.GetID() != (ushort)ThreeDSChunkType.MainChunk)
            if (chunk.GetType() != typeof(MainChunk))
            { throw new Exception("Not a proper 3DS file."); }

            chunk.Process(context);

            context.Dispose();

            return chunk as MainChunk;
        }

        //public event EventHandler<ParsingArgs> ChunkParsed;
        private ThreeDSModel model = new ThreeDSModel();
        private Dictionary<string, ThreeDSMaterial> materials = new Dictionary<string, ThreeDSMaterial>();
    }
}
