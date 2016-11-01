namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public abstract partial class IndependentBufferPtr : BufferPtr
    {
        internal static OpenGL.glBindBufferRange glBindBufferRange;
        internal static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal IndependentBufferPtr(uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            if (glBindBufferRange == null)
            {
                glBindBufferRange = OpenGL.GetDelegateFor<OpenGL.glBindBufferRange>();
                glBindBufferBase = OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Id: {0}, {1}, ByteLength: {2}", this.BufferId, this.Target, this.ByteLength);
        }
    }
}