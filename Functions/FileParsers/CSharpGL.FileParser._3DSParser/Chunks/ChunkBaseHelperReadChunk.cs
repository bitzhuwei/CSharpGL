using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public static partial class ChunkBaseHelper
    {

        public const uint HeaderLength = 6;

        public static ChunkBase ReadChunk(this BinaryReader reader)
        {
            long position = reader.BaseStream.Position;

            // 2 byte ID
            ushort id = reader.ReadUInt16();
            // 4 byte length
            uint length = reader.ReadUInt32();
            // 2 + 4 = 6
            uint bytesRead = HeaderLength;

            Type type;
            if (chunkIDDict.TryGetValue(id, out type))
            {
                object obj = Activator.CreateInstance(type);
                ChunkBase result = obj as ChunkBase;
                //result.ID = id;//不再需要记录ID，此对象的类型就指明了它的ID。
                result.Position = position;
                result.Length = length;
                result.BytesRead = bytesRead;
                return result;
            }
            else
            {
                return new UndefinedChunk() { Position = position, ID = id, Length = length, BytesRead = bytesRead, };
            }
        }
    }
}
