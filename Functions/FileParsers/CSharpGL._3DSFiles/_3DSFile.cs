using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL._3DSFiles
{
    public class _3DSFile
    {
        Chunk mainChunk;

        protected _3DSFile() { }
        public static _3DSFile Parse(string filename)
        {
            if (!System.IO.File.Exists(filename)) { return null; }

            _3DSFile result = null;
            using (var fileStream = new FileStream(filename, FileMode.Open))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    result = Parse(reader);
                }
            }
            return result;
        }

        private static _3DSFile Parse(BinaryReader reader)
        {
            _3DSFile result = new _3DSFile();
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var id = reader.ReadUInt16();
                var length = reader.ReadUInt32();
                var chunk = new Chunk(id, length);
                result.mainChunk = chunk;
            }
            throw new NotImplementedException();
        }


    }
}
