using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public static partial class BufferHelper
    {
        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexAttributeBufferPtr"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBufferPtr GetOneIndexBufferPtr(this UnmanagedArray<byte> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBufferPtr<byte>(array, mode, usage, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexAttributeBufferPtr"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBufferPtr GetOneIndexBufferPtr(this UnmanagedArray<ushort> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBufferPtr<ushort>(array, mode, usage, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexAttributeBufferPtr"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBufferPtr GetOneIndexBufferPtr(this UnmanagedArray<uint> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBufferPtr<uint>(array, mode, usage, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexAttributeBufferPtr"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        private static OneIndexBufferPtr GetOneIndexBufferPtr<T>(this UnmanagedArray<T> array, DrawMode mode, BufferUsage usage, int primCount = 1) where T : struct
        {
            Type type = typeof(T);
            IndexElementType elementType = IndexElementType.UInt;
            if (type == typeof(byte))
            {
                elementType = IndexElementType.UByte;
            }
            else if (type == typeof(ushort))
            {
                elementType = IndexElementType.UShort;
            }
            else if (type == typeof(uint))
            {
                elementType = IndexElementType.UInt;
            }
            else
            {
                throw new ArgumentException(string.Format("Array's element type must be one of byte, ushort or uint!"));
            }

            if (glGenBuffers == null)
            {
                InitFunctions();
            }

            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, array.ByteLength, array.Header, (uint)usage);
            glBindBuffer(target, 0);

            var bufferPtr = new OneIndexBufferPtr(buffers[0], mode, elementType, array.Length, array.ByteLength, primCount);

            return bufferPtr;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public enum IndexElementType : uint
    {
        /// <summary>
        /// byte
        /// </summary>
        UByte = OpenGL.GL_UNSIGNED_BYTE,

        /// <summary>
        /// ushort
        /// </summary>
        UShort = OpenGL.GL_UNSIGNED_SHORT,

        /// <summary>
        /// uint
        /// </summary>
        UInt = OpenGL.GL_UNSIGNED_INT,
    }
}