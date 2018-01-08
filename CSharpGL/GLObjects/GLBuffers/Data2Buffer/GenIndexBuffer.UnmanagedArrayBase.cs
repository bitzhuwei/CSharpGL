using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this UnmanagedArrayBase array, IndexBufferElementType type, BufferUsage usage)
        {
            var ids = new uint[1];
            {
                glGenBuffers(1, ids);
                const uint target = GL.GL_ELEMENT_ARRAY_BUFFER;
                glBindBuffer(target, ids[0]);
                glBufferData(target, array.ByteLength, array.Header, (uint)usage);
                glBindBuffer(target, 0);
            }

            var buffer = new IndexBuffer(ids[0], type, array.ByteLength);

            return buffer;
        }

    }
}
