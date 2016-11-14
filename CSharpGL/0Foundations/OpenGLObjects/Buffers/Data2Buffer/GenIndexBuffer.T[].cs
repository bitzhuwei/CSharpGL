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
            return GenIndexBuffer<byte>(array, mode, usage, primCount);
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
            return GenIndexBuffer<ushort>(array, mode, usage, primCount);
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
            return GenIndexBuffer<uint>(array, mode, usage, primCount);
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
        private static OneIndexBuffer GenIndexBuffer<T>(this T[] array, DrawMode mode, BufferUsage usage, int primCount = 1) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
            OneIndexBuffer buffer = GenIndexBuffer(unmanagedArray, mode, usage, IndexElementType.UInt, primCount);
            pinned.Free();

            return buffer;
        }
    }
}