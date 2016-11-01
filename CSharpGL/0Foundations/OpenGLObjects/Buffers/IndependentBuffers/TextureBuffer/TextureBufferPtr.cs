namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public partial class TextureBufferPtr : IndependentBufferPtr
    {
        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.TextureBuffer; }
        }

        /// <summary>
        /// TextureBufferObject matches <code>uniform samplerBuffer xxx;</code> in GLSL shader.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal TextureBufferPtr(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
        }
    }
}