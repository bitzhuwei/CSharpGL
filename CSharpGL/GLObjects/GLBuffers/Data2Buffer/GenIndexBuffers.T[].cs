using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// 生成若干用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates some Index Buffer Objects storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <param name="blockSize">How many elements per index buffer?(sometimes except the last one)</param>
        /// <returns></returns>
        public static IndexBuffer[] GenIndexBuffers<T>(this T[] array, IndexBufferElementType type, BufferUsage usage, int blockSize) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }

            const int first = 0;
            return GenIndexBuffers(array, type, usage, first, blockSize);
        }
        /// <summary>
        /// 生成若干用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates some Index Buffer Objects storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <param name="first"></param>
        /// <param name="blockSize">How many elements per index buffer?(sometimes except the last one)</param>
        /// <returns></returns>
        public static IndexBuffer[] GenIndexBuffers<T>(this T[] array, IndexBufferElementType type, BufferUsage usage, int first, int blockSize) where T : struct
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (first < 0) { throw new ArgumentOutOfRangeException("first"); }
            if (blockSize <= 0) { throw new ArgumentOutOfRangeException("count"); }
            if (array.Length <= first) { throw new ArgumentOutOfRangeException("first"); }

            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            //IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var list = new List<IndexBuffer>();
            int current = first;
            int totalLength = array.Length;
            do
            {
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, current);
                int length = (current + blockSize <= totalLength) ? blockSize : (totalLength - current);
                UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, length);// It's not necessary to call Dispose() for this unmanaged array.
                IndexBuffer buffer = GenIndexBuffer(unmanagedArray, type, usage);
                list.Add(buffer);

                current += length;

            } while (current < totalLength);
            pinned.Free();

            return list.ToArray();
        }

    }
}