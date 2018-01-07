using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {

        /// <summary>
        /// Creates a <see cref="DrawElementsCmd"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer<T>(this T[] array, IndexBufferElementType type, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
            int byteLength = unmanagedArray.ByteLength;
            var buffers = new uint[1];
            {
                glGenBuffers(1, buffers);
                const uint target = GL.GL_ELEMENT_ARRAY_BUFFER;
                glBindBuffer(target, buffers[0]);
                glBufferData(target, byteLength, unmanagedArray.Header, (uint)usage);
                glBindBuffer(target, 0);
            }
            pinned.Free();

            var buffer = new IndexBuffer(
                 buffers[0], type, byteLength / type.GetSize(), byteLength);

            return buffer;
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this byte[] array, BufferUsage usage)
        {
            return GenIndexBuffer<byte>(array, IndexBufferElementType.UByte, usage);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this ushort[] array, BufferUsage usage)
        {
            return GenIndexBuffer<ushort>(array, IndexBufferElementType.UShort, usage);
        }

        /// <summary>
        /// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(this uint[] array, BufferUsage usage)
        {
            return GenIndexBuffer<uint>(array, IndexBufferElementType.UInt, usage);
        }

        ///// <summary>
        ///// 生成一个用于存储索引的VBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        ///// Generates a Vertex Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //private static IndexBuffer GenIndexBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        //{
        //    IndexBufferElementType elementType;
        //    if (typeof(T) == typeof(uint)) { elementType = IndexBufferElementType.UInt; }
        //    else if (typeof(T) == typeof(ushort)) { elementType = IndexBufferElementType.UShort; }
        //    else if (typeof(T) == typeof(byte)) { elementType = IndexBufferElementType.UByte; }
        //    else { throw new ArgumentException(string.Format("Only uint/ushort/byte are allowed!")); }

        //    GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
        //    IntPtr header = pinned.AddrOfPinnedObject();
        //    // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
        //    UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
        //    var buffers = new uint[1];
        //    {
        //        glGenBuffers(1, buffers);
        //        const uint target = GL.GL_ELEMENT_ARRAY_BUFFER;
        //        glBindBuffer(target, buffers[0]);
        //        glBufferData(target, unmanagedArray.ByteLength, unmanagedArray.Header, (uint)usage);
        //        glBindBuffer(target, 0);
        //    }
        //    pinned.Free();

        //    var buffer = new IndexBuffer(buffers[0], elementType, unmanagedArray.Length, unmanagedArray.ByteLength);


        //    return buffer;
        //}
    }
}