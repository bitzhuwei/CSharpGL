using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this byte[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer<byte>(array, mode, usage, IndexBufferElementType.UByte, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this ushort[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer<ushort>(array, mode, usage, IndexBufferElementType.UShort, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        public static OneIndexBuffer GenIndexBuffer(this uint[] array, DrawMode mode, BufferUsage usage, int primCount = 1)
        {
            return GenIndexBuffer<uint>(array, mode, usage, IndexBufferElementType.UInt, primCount);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="elementType"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <returns></returns>
        private static OneIndexBuffer GenIndexBuffer<T>(this T[] array, DrawMode mode, BufferUsage usage, IndexBufferElementType elementType, int primCount = 1) where T : struct
        {
            if (glGenBuffers == null)
            {
                InitFunctions();
            }

            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
            var buffers = new uint[1];
            {
                glGenBuffers(1, buffers);
                const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
                glBindBuffer(target, buffers[0]);
                glBufferData(target, unmanagedArray.ByteLength, unmanagedArray.Header, (uint)usage);
                glBindBuffer(target, 0);
            }
            pinned.Free();

            var buffer = new OneIndexBuffer(buffers[0], mode, elementType, unmanagedArray.Length, unmanagedArray.ByteLength, primCount);


            return buffer;
        }
    }
}