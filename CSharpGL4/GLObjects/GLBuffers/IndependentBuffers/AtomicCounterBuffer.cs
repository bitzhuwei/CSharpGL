using System;

namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public partial class AtomicCounterBuffer : GLBuffer
    {
        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal AtomicCounterBuffer(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            this.Target = BufferTarget.AtomicCounterBuffer;
        }

        /// <summary>
        /// Creates a <see cref="AtomicCounterBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="length"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer Create(Type elementType, int length, BufferUsage usage)
        {
            return (GLBuffer.Create(IndependentBufferTarget.AtomicCounterBuffer, elementType, length, usage) as AtomicCounterBuffer);
        }
    }
}