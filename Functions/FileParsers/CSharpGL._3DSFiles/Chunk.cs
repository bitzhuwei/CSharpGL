using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL._3DSFiles
{
    public class Chunk
    {
        public UInt16 Identifier;
        public UInt32 Length;
        public UInt32 readBytes;
        public IList<Chunk> Children = new List<Chunk>();

        public Chunk(UInt16 id, UInt32 length)
        { this.Identifier = id; this.Length = length; }

        public static Chunk Parse(System.IO.BinaryReader reader)
        {
            var id = reader.ReadUInt16();
            if (id != ChunkID.MAIN_CHUNK) { return null; }

            var length = reader.ReadUInt32();
            var mainChunk = new Chunk(id, length);
            ReadSubChunk(mainChunk, reader);

            return mainChunk;
        }

        private static void ReadSubChunk(Chunk parentChunk, System.IO.BinaryReader reader)
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var chunk = ReadChunk(reader);
                switch (chunk.Identifier)
                {
                    case ChunkID._3D_EDITOR_CHUNK:
                        ReadSubChunk(chunk, reader);
                        break;
                    case ChunkID.OBJECT_BLOCK:
                        var i = 0;
                        do
                        {

                        } while (true);
                        ReadSubChunk(chunk, reader);
                        break;
                    case ChunkID.TRIANGULAR_MESH:
                        ReadSubChunk(chunk, reader);
                        break;
                    default:
                        break;
                }
            }
            throw new NotImplementedException();
        }

        private static Chunk ReadChunk(System.IO.BinaryReader reader)
        {
            var id = reader.ReadUInt16();
            var length = reader.ReadUInt32();
            var result = new Chunk(id, length);
            return result;
        }

    }

}