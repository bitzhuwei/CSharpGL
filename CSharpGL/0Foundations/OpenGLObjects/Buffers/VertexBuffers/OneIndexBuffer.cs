using System;

namespace CSharpGL
{
    /// <summary>
    /// 用于存储索引的VBO。索引指定了<see cref="VertexAttributeBuffer&lt;T&gt;"/>里各个顶点的渲染顺序。
    /// Vertex Buffer Object storing vertex' indexes, which indicate the rendering order of each vertex.
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？只支持byte, ushort, uint。<para>type of index value. Only support byte, ushort, uint.</para></typeparam>
    public class OneIndexBuffer<T> : IndexBuffer<T> where T : struct
    {
        /// <summary>
        /// 用于存储索引的VBO。索引指定了<see cref="VertexAttributeBuffer&lt;T&gt;"/>里各个顶点的渲染顺序。
        /// Vertex Buffer Object storing vertex' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="usage"></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        public OneIndexBuffer(DrawMode mode, BufferUsage usage, int primCount = 1)
            : base(mode, usage, primCount)
        {
            if (typeof(uint) == typeof(T))
            {
                this.Type = IndexElementType.UnsignedInt;
            }
            else if (typeof(ushort) == typeof(T))
            {
                this.Type = IndexElementType.UnsighedShort;
            }
            else if (typeof(byte) == typeof(T))
            {
                this.Type = IndexElementType.UnsignedByte;
            }
            else
            { throw new ArgumentException(); }
        }

        /// <summary>
        /// 索引数组中有多少个元素。
        /// </summary>
        public int GetElementCount()
        {
            int result = 0;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    result = base.ByteLength / sizeof(byte);
                    break;

                case IndexElementType.UnsighedShort:
                    result = base.ByteLength / sizeof(ushort);
                    break;

                case IndexElementType.UnsignedInt:
                    result = base.ByteLength / sizeof(uint);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
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
            this.array = new UnmanagedArray<T>(elementCount);
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
                 buffers[0], this.Mode, 0, this.GetElementCount(), this.Type, this.Length, this.ByteLength);

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
}