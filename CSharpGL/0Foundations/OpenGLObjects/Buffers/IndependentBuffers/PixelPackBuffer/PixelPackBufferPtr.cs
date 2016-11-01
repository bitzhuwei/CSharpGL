namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public partial class PixelPackBufferPtr : IndependentBufferPtr
    {
        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.PixelPackBuffer; }
        }

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal PixelPackBufferPtr(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
        }
    }
}