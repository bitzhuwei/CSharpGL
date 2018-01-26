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
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this byte[] array, BufferUsage usage)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UByte, usage, 0, array.Length);
        }
        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this byte[] array, BufferUsage usage, int first)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UByte, usage, first, array.Length);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this byte[] array, BufferUsage usage, int first, int count)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UByte, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this ushort[] array, BufferUsage usage)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UShort, usage, 0, array.Length);
        }
        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this ushort[] array, BufferUsage usage, int first)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UShort, usage, first, array.Length);
        }
        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this ushort[] array, BufferUsage usage, int first, int count)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UShort, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this uint[] array, BufferUsage usage)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UInt, usage, 0, array.Length);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this uint[] array, BufferUsage usage, int first)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UInt, usage, first, array.Length);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this uint[] array, BufferUsage usage, int first, int count)
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, IndexBufferElementType.UInt, usage, first, count);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type">NOTE: It's easy to fill wrong type here.</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer<T>(this T[] array, IndexBufferElementType type, BufferUsage usage) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, type, usage, 0, array.Length);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer<T>(this T[] array, IndexBufferElementType type, BufferUsage usage, int first) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            return GenIndexBuffer(array, type, usage, first, array.Length);
        }

        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer<T>(this T[] array, IndexBufferElementType type, BufferUsage usage, int first, int count) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (first < 0) { throw new ArgumentOutOfRangeException("first"); }
            if (count < 0) { throw new ArgumentOutOfRangeException("count"); }
            if (array.Length < first + count) { throw new ArgumentOutOfRangeException("first + count"); }

            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            //IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, first);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, count);// It's not necessary to call Dispose() for this unmanaged array.
            IndexBuffer buffer = GenIndexBuffer(unmanagedArray, type, usage);
            pinned.Free();

            return buffer;
        }

    }
}