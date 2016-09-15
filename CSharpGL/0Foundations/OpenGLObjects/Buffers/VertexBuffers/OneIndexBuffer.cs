using System;

namespace CSharpGL
{
    /// <summary>
    /// 用于存储索引的VBO。索引指定了<see cref="VertexAttributeBuffer&lt;T&gt;"/>里各个顶点的渲染顺序。
    /// Vertex Buffer Object storing vertex' indexes, which indicate the rendering order of each vertex.
    /// </summary>
    public class OneIndexBuffer : IndexBuffer
    {
        /// <summary>
        /// 用于存储索引的VBO。索引指定了<see cref="VertexAttributeBuffer&lt;T&gt;"/>里各个顶点的渲染顺序。
        /// Vertex Buffer Object storing vertex' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="elementType">element type.</param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        public OneIndexBuffer(IndexElementType elementType, DrawMode mode, BufferUsage usage, int primCount = 1)
            : base(mode, usage, primCount)
        {
            this.Type = elementType;
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexElementType Type { get; private set; }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    this.array = new UnmanagedArray<byte>(elementCount);
                    break;

                case IndexElementType.UnsighedShort:
                    this.array = new UnmanagedArray<ushort>(elementCount);
                    break;

                case IndexElementType.UnsignedInt:
                    this.array = new UnmanagedArray<uint>(elementCount);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, buffers[0]);
            glBufferData(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, 0);

            var bufferPtr = new OneIndexBufferPtr(
                 buffers[0], this.Mode, this.Type, this.Length, this.ByteLength);

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
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,

        /// <summary>
        /// ushort
        /// </summary>
        UnsighedShort = OpenGL.GL_UNSIGNED_SHORT,

        /// <summary>
        /// uint
        /// </summary>
        UnsignedInt = OpenGL.GL_UNSIGNED_INT,
    }

    //public static class OneIndexBufferHelper
    //{
    //    public static
    //}
}