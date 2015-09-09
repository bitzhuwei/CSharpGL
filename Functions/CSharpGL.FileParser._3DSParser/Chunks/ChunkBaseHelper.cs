using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.FileParser._3DSParser.Chunks
{
    public static class ChunkBaseHelper
    {

        private static readonly Dictionary<Type, ushort> chunkTypeDict = new Dictionary<Type, ushort>();
        private static readonly Dictionary<ushort, Type> chunkIDDict = new Dictionary<ushort, Type>();

        static ChunkBaseHelper()
        {
            chunkTypeDict.Add(typeof(MainChunk), 0x4D4D);

            chunkIDDict.Add(0x4D4D, typeof(MainChunk));
        }

        public static ushort GetID(this ChunkBase chunk)
        {
            Type type = chunk.GetType();
            ushort value;
            if (type == typeof(UndefinedChunk))
            {
                value = (chunk as UndefinedChunk).ID;
            }
            else
            {
                value = chunkTypeDict[type];//如果此处不存在此type的key，说明static构造函数需要添加此类型的字典信息。
            }

            return value;
        }

        public static ChunkBase ReadChunk(this BinaryReader reader)
        {
            // 2 byte ID
            ushort id = reader.ReadUInt16();
            // 4 byte length
            uint length = reader.ReadUInt32();
            // 2 + 4 = 6
            int bytesRead = 6;

            Type type;
            if (chunkIDDict.TryGetValue(id, out type))
            {
                object obj = Activator.CreateInstance(type);
                ChunkBase result = obj as ChunkBase;
                //result.ID = id;//不再需要记录ID，此对象的类型就指明了它的ID。
                result.Length = length;
                result.BytesRead = bytesRead;
                return result;
            }
            else
            {
                return new UndefinedChunk() { ID = id, Length = length, BytesRead = bytesRead, };
            }
        }
        //public static T ReadChunk<T>(this BinaryReader reader) where T : ChunkBase, new()
        //{
        //    // 2 byte ID
        //    var ID = reader.ReadUInt16();
        //    if (ID != chunkTypeDict[typeof(T)])
        //    { throw new Exception(string.Format("chunk type not match!")); }

        //    // 4 byte length
        //    var Length = reader.ReadUInt32();

        //    // 2 + 4 = 6
        //    var BytesRead = 6;

        //    T result = new T() { ID = ID, Length = Length, BytesRead = BytesRead, };

        //    return result;
        //}
    }
}
