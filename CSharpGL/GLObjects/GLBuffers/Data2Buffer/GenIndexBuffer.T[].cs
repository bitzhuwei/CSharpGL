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
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count">count &lt;= 0 ? array.Length : count</param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this byte[] array, BufferUsage usage, int first = 0, int count = 0)
        {
            return GenIndexBuffer(array, IndexBufferElementType.UByte, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count">count &lt;= 0 ? array.Length : count</param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this ushort[] array, BufferUsage usage, int first = 0, int count = 0)
        {
            return GenIndexBuffer(array, IndexBufferElementType.UShort, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count">count &lt;= 0 ? array.Length : count</param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this uint[] array, BufferUsage usage, int first = 0, int count = 0)
        {
            return GenIndexBuffer(array, IndexBufferElementType.UInt, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count">count &lt;= 0 ? array.Length : count</param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer<T>(this T[] array, IndexBufferElementType type, BufferUsage usage, int first = 0, int count = 0) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>((IntPtr)(header.ToInt32() + first), count <= 0 ? array.Length : count);// It's not necessary to call Dispose() for this unmanaged array.
            IndexBuffer buffer = GenIndexBuffer(unmanagedArray, type, usage);
            pinned.Free();


            return buffer;
        }

    }
}