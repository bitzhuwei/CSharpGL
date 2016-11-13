using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Array2Buffer
    {
        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this byte[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<byte>(header, array.Length);
            OneIndexBuffer buffer = GetOneIndexBuffer(unmanagedArray, mode, usage, IndexElementType.UByte, primCount);
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this ushort[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<ushort>(header, array.Length);
            OneIndexBuffer buffer = GetOneIndexBuffer(unmanagedArray, mode, usage, IndexElementType.UShort, primCount);
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this uint[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<uint>(header, array.Length);
            OneIndexBuffer buffer = GetOneIndexBuffer(unmanagedArray, mode, usage, IndexElementType.UInt, primCount);
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this UnmanagedArray<byte> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBuffer(array, mode, usage, IndexElementType.UByte, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this UnmanagedArray<ushort> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBuffer(array, mode, usage, IndexElementType.UShort, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GetOneIndexBuffer(this UnmanagedArray<uint> array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GetOneIndexBuffer(array, mode, usage, IndexElementType.UInt, primCount);
        }

        /// <summary>
        /// 获取一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Gets a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="elementType"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        private static OneIndexBuffer GetOneIndexBuffer(this UnmanagedArrayBase array, DrawMode mode, BufferUsage usage, IndexElementType elementType, int primCount = 1)
        {
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

            var buffer = new OneIndexBuffer(buffers[0], mode, elementType, array.Length, array.ByteLength, primCount);

            return buffer;
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