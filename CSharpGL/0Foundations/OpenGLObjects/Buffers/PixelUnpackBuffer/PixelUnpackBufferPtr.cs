namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public class PixelUnpackBufferPtr : IndependentBufferPtr
    {
        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal PixelUnpackBufferPtr(
            uint bufferId, int length, int byteLength)
            : base(BufferTarget.PixelUnpackBuffer, bufferId, length, byteLength)
        {
        }
    }
}